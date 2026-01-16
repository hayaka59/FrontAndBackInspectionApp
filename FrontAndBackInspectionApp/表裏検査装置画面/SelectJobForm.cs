using Kinoshita.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FrontAndBackInspectionApp.表裏検査装置画面
{
    public partial class SelectJobForm : Form
    {
        private List<string> majorDivisionList = new List<string>();    // 大区分リスト
        private List<string> subDivisionList   = new List<string>();    // 小区分リスト
        private int iLastMajorDivisionIndex    = -1;                    // 最後に選択した大区分コンボボックスのインデックス
        private int iLastSubDivisionIndex      = -1;                    // 最後に選択した小区分コンボボックスのインデックス

        public SelectJobForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームロード処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectJobForm_Load(object sender, EventArgs e)
        {
            try
            {
                LblTitle.Text = "表裏検査装置　ジョブ選択画面";
                LblVersion.Text = PubConstClass.DEF_VERSION;

                // ロゴ表示
                PctLogo.Visible = PubConstClass.pblLogoDisp == "1";

                LblJobName.Text = "";
                // 大区分と小区分設定ファイルの読取処理
                LoadDivisionSettingFile();

                // 選択JOB検査内容表示リストビューの設定
                LtbJobDataInfo.DrawMode = DrawMode.OwnerDrawFixed;
                LtbJobDataInfo.DrawItem += LtbJobDataInfo_DrawItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【SelectJobForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// リストビューのカスタム描画処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LtbJobDataInfo_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            // 背景色を交互に設定
            //Color backColor = (e.Index % 2 == 0) ? Color.LightGray : Color.White;
            Color backColor = (e.Index % 2 != 0) ? Color.LightCyan : Color.White;
            // 選択状態ならハイライト
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                backColor = SystemColors.Highlight;
            }
            using (SolidBrush brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }
            // テキスト描画
            using (SolidBrush textBrush = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
                                      e.Font, textBrush, e.Bounds);
            }
            e.DrawFocusRectangle();
        }

        /// <summary>
        /// 「戻る」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnBack_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「運転開始」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNewStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (LblJobName.Text.Trim() == "")
                {
                    MessageBox.Show("JOBを選択して下さい", "確認", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // 禁則文字のチェック
                if (!CheckInvalidString(CmbMajorDivision.Text.Trim(), "大区分項目"))
                {
                    return;
                }
                if (!CheckInvalidString(CmbSubDivision.Text.Trim(), "小区分項目"))
                {
                    return;
                }
                Log.OutPutLogFile(TraceEventType.Information, "JOB選択画面画面：「運転開始」ボタンクリック");
                this.Hide();
                DrivingForm form = new DrivingForm(CmbMajorDivision.Text, CmbSubDivision.Text, LblLogFileName.Text);
                form.ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnNewStart_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        string sSelectedFile = "";

        /// <summary>
        /// 「JO選択」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnJobSelect_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();

                Log.OutPutLogFile(TraceEventType.Information, "登録画面：「JO選択」ボタンクリック");
                // 初期表示するフォルダの指定（「空の文字列」の時は現在のディレクトリを表示）
                //ofd.InitialDirectory = @"C:\";
                // 「ファイルの種類」に表示される選択肢の指定
                ofd.Filter = "CSVファイル(*.csv;*.CSV)|*.csv;*.CSV|すべてのファイル(*.*)|*.*";
                // 「ファイルの種類」ではじめに「CSVファイル(*.csv;*.CSV)」を選択
                ofd.FilterIndex = 1;
                // タイトルを設定
                ofd.Title = "JOB設定ファイルを選択してください";
                // ダイアログボックスを閉じる前に現在のディレクトリを復元
                ofd.RestoreDirectory = true;
                // 存在しないファイルの名前が指定されたとき警告を表示
                ofd.CheckFileExists = true;
                // 存在しないパスが指定されたとき警告を表示
                ofd.CheckPathExists = true;
                // ダイアログを表示する
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // 「OK」ボタンがクリック（選択されたファイル名を表示）
                    sSelectedFile = ofd.FileName;
                    string[] sArray = sSelectedFile.Split('\\');

                    // ジョブ登録情報の読取
                    CommonModule.ReadJobEntryListFile(sSelectedFile);
                    // 選択ジョブ項目を取得し表示
                    CommonModule.GetSelectJobItem(LblJobName, LtbJobDataInfo);
                    LblSetteiInfo.Text = $"設定データ：{PubConstClass.sJobSettingData}";
                    // 検査ログ・ファイル名の更新
                    UpdateLogFileName();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnJobSelect_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 検査ログ・ファイル名の更新処理
        /// </summary>
        private void UpdateLogFileName()
        {
            try
            {
                if (LblJobName.Text.Trim() == "")
                {
                    return;
                }
                if (CmbMajorDivision.Items.Count <= 0)
                {
                    return;
                }
                if (CmbSubDivision.Items.Count <= 0)
                {
                    return;
                }
                // 禁則文字のチェック
                if (!CheckInvalidString(CmbMajorDivision.Text.Trim(), "大区分項目"))
                {
                    return;
                }
                if (!CheckInvalidString(CmbSubDivision.Text.Trim(), "小区分項目"))
                {
                    return;
                }
                string sLogFileName = DateTime.Now.ToString("yyyyMMdd_HHmmss") + "_";
                sLogFileName += PubConstClass.pblMachineName + "_";
                sLogFileName += LblJobName.Text + "_";
                sLogFileName += CmbMajorDivision.Text + "_";
                sLogFileName += CmbSubDivision.Text + ".csv";
                // 検査ログファイル名の表示
                LblLogFileName.Text = sLogFileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【UpdateLogFileName】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 大区分コンボボックスの選択処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbMajorDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                iLastMajorDivisionIndex = CmbMajorDivision.SelectedIndex;
                UpdateLogFileName();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【CmbBroadDivision_SelectedIndexChanged】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 小区分コンボボックスの選択処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmbSubDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                iLastSubDivisionIndex = CmbSubDivision.SelectedIndex;
                UpdateLogFileName();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【CmbSubDivision_SelectedIndexChanged】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「追加」ボタン処理（大区分）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEntry_Click(object sender, EventArgs e)
        {
            try
            {
                EntryDivision(CmbMajorDivision, ref majorDivisionList, "大区分項目");
                if (majorDivisionList.Count > 0)
                {
                    BtnDelete.Enabled = true;
                    BtnUpdate.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnEntry_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「追加」ボタン処理（小区分）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEntrySub_Click(object sender, EventArgs e)
        {
            try
            {
                EntryDivision(CmbSubDivision, ref subDivisionList, "小区分項目");
                if (subDivisionList.Count > 0)
                {
                    BtnDeleteSub.Enabled = true;
                    BtnUpdateSub.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnEntrySub_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 大区分、小区分の追加処理 
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="divisonList"></param>
        /// <param name="sMessage"></param>
        private void EntryDivision(System.Windows.Forms.ComboBox comboBox, ref List<string> divisonList, string sMessage)
        {
            DialogResult result;

            try
            {
                // 入力項目が空白のチェック
                if (comboBox.Text.Trim() == "")
                {
                    MessageBox.Show($"{sMessage}を入力してください", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // 同一項目の存在チェック
                if (divisonList.Contains(comboBox.Text))
                {
                    MessageBox.Show($"同じ{sMessage}（{comboBox.Text}）が存在します", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // 禁則文字のチェック
                if (!CheckInvalidString(comboBox.Text.Trim(), sMessage))
                {
                    return;
                }

                result = MessageBox.Show($"{sMessage}（{comboBox.Text}）を追加しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    divisonList.Add(comboBox.Text);
                    // 大区分設定ファイルの保存処理
                    SaveDivisionSettingFile();
                    // 大区分と小区分設定ファイルの読取処理
                    LoadDivisionSettingFile();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【EntryDivision】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「削除」ボタン処理（大区分）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DeleteDivision(CmbMajorDivision, ref majorDivisionList, "大区分項目");
                if (majorDivisionList.Count < 1)
                {
                    BtnDelete.Enabled = false;
                    BtnUpdate.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnDelete_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「削除」ボタン処理（小区分）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteSub_Click(object sender, EventArgs e)
        {
            try
            {

                DeleteDivision(CmbSubDivision, ref subDivisionList, "小区分項目");
                if (subDivisionList.Count < 1)
                {
                    BtnDeleteSub.Enabled = false;
                    BtnUpdateSub.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnDeleteSub_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 大区分と小区分設定ファイルの読取処理
        /// コンボボックスの初期化
        /// </summary>
        private void LoadDivisionSettingFile()
        {
            string sData;
            string sFileName;
            string sReadFilePath;

            try
            {
                sFileName = "大区分設定ファイル.txt";
                sReadFilePath = $"{CommonModule.IncludeTrailingPathDelimiter(Application.StartupPath)}{sFileName}";
                majorDivisionList.Clear();
                using (StreamReader sr = new StreamReader(sReadFilePath, Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        sData = sr.ReadLine();
                        if (sData.Trim() != "")
                        {
                            majorDivisionList.Add(sData);
                        }                        
                    }
                }

                sFileName = "小区分設定ファイル.txt";
                sReadFilePath = $"{CommonModule.IncludeTrailingPathDelimiter(Application.StartupPath)}{sFileName}";
                subDivisionList.Clear();
                using (StreamReader sr = new StreamReader(sReadFilePath, Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        sData = sr.ReadLine();
                        if (sData.Trim() != "")
                        {
                            subDivisionList.Add(sData);
                        }
                    }
                }
                // 大区分コンボボックス初期化
                CmbMajorDivision.Items.Clear();
                if (majorDivisionList.Count > 0)
                {
                    foreach (string item in majorDivisionList)
                    {
                        CmbMajorDivision.Items.Add(item);
                    }
                    CmbMajorDivision.SelectedIndex = 0;
                }
                else
                {
                    CmbMajorDivision.Text = "";
                    BtnDelete.Enabled = false;
                }
                LblMajorCounter.Text = $"大区分項目数：{majorDivisionList.Count}";

                // 小区分コンボボックス初期化
                CmbSubDivision.Items.Clear();
                if (subDivisionList.Count > 0)
                {
                    foreach (string item in subDivisionList)
                    {
                        CmbSubDivision.Items.Add(item);
                    }
                    CmbSubDivision.SelectedIndex = 0;
                }
                else
                {
                    CmbSubDivision.Text = "";
                    BtnDeleteSub.Enabled = false;
                }
                LblSubCounter.Text = $"小区分項目数：{subDivisionList.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【LoadingDivisionSettingFile】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 大区分と小区分設定ファイルの読取処理
        /// </summary>
        private void SaveDivisionSettingFile()
        {
            string sFileName;
            string sSaveDataPath;

            try
            {
                sFileName = "大区分設定ファイル.txt";
                sSaveDataPath = $"{CommonModule.IncludeTrailingPathDelimiter(Application.StartupPath)}{sFileName}";

                // 上書モードで書き込む
                using (StreamWriter sw = new StreamWriter(sSaveDataPath, false, Encoding.Default))
                {
                    foreach (string item in majorDivisionList)
                    {
                        if (item.Trim() != "")
                        {
                            sw.WriteLine(item);
                        }                        
                    }
                }

                sFileName = "小区分設定ファイル.txt";
                sSaveDataPath = $"{CommonModule.IncludeTrailingPathDelimiter(Application.StartupPath)}{sFileName}";

                // 上書モードで書き込む
                using (StreamWriter sw = new StreamWriter(sSaveDataPath, false, Encoding.Default))
                {
                    foreach (string item in subDivisionList)
                    {
                        if (item.Trim() != "")
                        {
                            sw.WriteLine(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【SelectJobForm_FormClosed】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LblVersion_DoubleClick(object sender, EventArgs e)
        {
            LblSetteiInfo.Visible = !LblSetteiInfo.Visible;
        }

        // 禁則文字のリスト
        //private static readonly char[] InvalidFileNameChars = Path.GetInvalidFileNameChars();
        private static readonly char[] InvalidFileNameChars = new char[] { '\\', '/', ':', '*', '?', '"', '<', '>', '|', '.' , '_' };

        /// <summary>
        /// ファイル名に使用できない文字が含まれているかを判定する
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private bool IsFileNameValid(string fileName)
        {
            return fileName.Any(ch => InvalidFileNameChars.Contains(ch));
        }

        /// <summary>
        /// 禁則文字が含まれているかをチェックする
        /// </summary>
        /// <param name="sCheckString"></param>
        /// <returns></returns>
        private bool CheckInvalidString(string sCheckString, string sMessage)
        {
            try
            {
                bool isValid = IsFileNameValid(sCheckString.Trim());
                if (isValid)
                {
                    string sData = "";
                    foreach (char c in InvalidFileNameChars)
                    {
                        sData += c + " ";
                    }
                    MessageBox.Show($"{sMessage}に禁則文字（{sData}）が含まれています", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【CheckInvalidString】", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// 「更新」ボタン処理（大区分）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            UpdateDivision(CmbMajorDivision, ref majorDivisionList, iLastMajorDivisionIndex, "大区分項目");
        }

        /// <summary>
        /// 「更新」ボタン処理（小区分）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUpdateSub_Click(object sender, EventArgs e)
        {
            UpdateDivision(CmbSubDivision, ref subDivisionList, iLastSubDivisionIndex, "小区分項目");
        }

        /// <summary>
        /// 大区分、小区分の更新処理
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="divisonList"></param>
        /// <param name="iLastDivisionIndex"></param>
        /// <param name="sMessage"></param>
        private void UpdateDivision(System.Windows.Forms.ComboBox comboBox, ref List<string> divisonList, int iLastDivisionIndex, string sMessage)
        {
            DialogResult result;

            try
            {
                // 入力項目が空白のチェック
                if (comboBox.Text.Trim() == "")
                {
                    MessageBox.Show($"{sMessage}を入力してください", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // 同一項目の存在チェック
                if (divisonList.Contains(comboBox.Text))
                {
                    MessageBox.Show($"同じ{sMessage}（{comboBox.Text}）が存在します", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (iLastDivisionIndex < 0)
                {
                    MessageBox.Show($"{sMessage}を選択してください", "確認", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string sOldValue = divisonList[iLastDivisionIndex];
                string sNewValue = comboBox.Text.Trim();


                // 禁則文字のチェック
                if (!CheckInvalidString(sNewValue, sMessage))
                {
                    return;
                }

                string sNL = Environment.NewLine;
                result = MessageBox.Show($"「{sOldValue}」を{sNL}「{sNewValue}」{sNL}に変更しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    // 大区分リスト内容の更新
                    divisonList[iLastDivisionIndex] = sNewValue;
                    // 大区分設定ファイルの保存処理
                    SaveDivisionSettingFile();
                    // 大区分と小区分設定ファイルの読取処理
                    LoadDivisionSettingFile();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【UpdateDivision】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comboBox"></param>
        /// <param name="divisonList"></param>
        /// <param name="sMessage"></param>
        private void DeleteDivision(System.Windows.Forms.ComboBox comboBox, ref List<string> divisonList, string sMessage)
        {
            DialogResult result;

            try
            {
                // 入力項目が空白のチェック
                if (comboBox.Text.Trim() == "")
                {
                    MessageBox.Show($"{sMessage}を入力してください", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // 削除項目の存在チェック
                if (!divisonList.Contains(comboBox.Text))
                {
                    MessageBox.Show($"削除対象の{sMessage}（{comboBox.Text}）が存在しません", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                result = MessageBox.Show($"{sMessage}（{comboBox.Text}）を削除しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    divisonList.Remove(comboBox.Text);
                    // 大区分設定ファイルの保存処理
                    SaveDivisionSettingFile();
                    // 大区分と小区分設定ファイルの読取処理
                    LoadDivisionSettingFile();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【DeleteDivision】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbDivision_Leave(object sender, EventArgs e)
        {
            UpdateLogFileName();
        }
    }
}
