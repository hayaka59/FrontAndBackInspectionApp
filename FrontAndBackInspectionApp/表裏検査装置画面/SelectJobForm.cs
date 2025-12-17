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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontAndBackInspectionApp.表裏検査装置画面
{
    public partial class SelectJobForm : Form
    {
        private List<string> majorDivisionList = new List<string>();    // 大区分リスト
        private List<string> subDivisionList = new List<string>();      // 小区分リスト

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

                TxtJobName.Text = "";
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
                if (TxtJobName.Text.Trim() == "")
                {
                    MessageBox.Show("JOBを選択して下さい", "確認", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Log.OutPutLogFile(TraceEventType.Information, "JOB選択画面画面：「運転開始」ボタンクリック");
                DrivingForm form = new DrivingForm(CmbMajorDivision.Text, CmbSubDivision.Text, LblLogFileName.Text);
                form.ShowDialog();
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
                    CommonModule.GetSelectJobItem(TxtJobName, LtbJobDataInfo);
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
                if (TxtJobName.Text.Trim() == "")
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
                string sLogFileName = "装置名称_";
                sLogFileName += TxtJobName.Text + "_";
                sLogFileName += CmbMajorDivision.SelectedItem.ToString() + "_";
                sLogFileName += CmbSubDivision.SelectedItem.ToString() + "_";
                sLogFileName += DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv";
                // 検査ログファイル名の表示
                LblLogFileName.Text = sLogFileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【UpdateLogFileName】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbBroadDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                UpdateLogFileName();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【CmbBroadDivision_SelectedIndexChanged】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void CmbSubDivision_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
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
            DialogResult result;

            try
            {
                if (CmbMajorDivision.Text.Trim() == "")
                {
                    MessageBox.Show("大区分項目を入力してください", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (majorDivisionList.Contains(CmbMajorDivision.Text))
                {
                    MessageBox.Show($"同じ大区分項目（{CmbMajorDivision.Text}）が存在します", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                result = MessageBox.Show($"大区分（{CmbMajorDivision.Text}）を追加しますか？","確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    majorDivisionList.Add(CmbMajorDivision.Text);
                    // 大区分設定ファイルの保存処理
                    SaveDivisionSettingFile();
                    // 大区分と小区分設定ファイルの読取処理
                    LoadDivisionSettingFile();
                    // 「削除」ボタンを有効にする
                    BtnDelete.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnEntry_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「削除」ボタン処理（大区分）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result;

            try
            {
                if (majorDivisionList.Count < 1)
                {
                    BtnDelete.Enabled = false;
                    return;
                }                
                result = MessageBox.Show($"大区分（{CmbMajorDivision.Text}）を削除しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    majorDivisionList.Remove(CmbMajorDivision.Text);
                    // 大区分設定ファイルの保存処理
                    SaveDivisionSettingFile();
                    // 大区分と小区分設定ファイルの読取処理
                    LoadDivisionSettingFile();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnDelete_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「追加」ボタン処理（小区分）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEntrySub_Click(object sender, EventArgs e)
        {
            DialogResult result;

            try
            {
                if (CmbSubDivision.Text.Trim() == "")
                {
                    MessageBox.Show("小区分項目を入力してください", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (subDivisionList.Contains(CmbSubDivision.Text))
                {
                    MessageBox.Show($"同じ小区分項目（{CmbSubDivision.Text}）が存在します", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                result = MessageBox.Show($"小区分（{CmbSubDivision.Text}）を追加しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    subDivisionList.Add(CmbSubDivision.Text);
                    // 大区分設定ファイルの保存処理
                    SaveDivisionSettingFile();
                    // 大区分と小区分設定ファイルの読取処理
                    LoadDivisionSettingFile();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnEntrySub_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「削除」ボタン処理（小区分）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteSub_Click(object sender, EventArgs e)
        {
            DialogResult result;

            try
            {
                result = MessageBox.Show($"小区分（{CmbSubDivision.Text}）を削除しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    subDivisionList.Remove(CmbSubDivision.Text);
                    // 大区分設定ファイルの保存処理
                    SaveDivisionSettingFile();
                    // 大区分と小区分設定ファイルの読取処理
                    LoadDivisionSettingFile();
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
    }
}
