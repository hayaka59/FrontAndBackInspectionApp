using Kinoshita.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontAndBackInspectionApp.表裏検査装置画面
{
    public partial class JobEntryForm : Form
    {
        public JobEntryForm()
        {
            InitializeComponent();
        }

        private void JobEntryForm_Load(object sender, EventArgs e)
        {
            try
            {
                LblTitle.Text = "表裏検査装置　ジョブ登録画面";
                LblVersion.Text = PubConstClass.DEF_VERSION;

                // ロゴ表示
                PctLogo.Visible = PubConstClass.pblLogoDisp == "1";

                TxtJobName.Text = "";
                LblSelectedFile.Text = "";

                // 用紙デプスコンボボックス設定
                CmbPaperDepth.IntegralHeight = false;
                CmbPaperDepth.MaxDropDownItems = 10;
                CmbPaperDepth.Items.Clear();
                double dIndex = 0.0;
                for (int iIndex = 30; iIndex <= 200; iIndex++)
                {
                    dIndex = iIndex / 10.0;
                    CmbPaperDepth.Items.Add(dIndex.ToString("0.0"));
                }
                CmbPaperDepth.SelectedIndex = 0;

                // カメラ読取位置（上）コンボボックス設定
                SetComboboxItems(CmbCameraReadingPosTop, 1, 500, 0);
                // カメラ読取位置（下）コンボボックス設定
                SetComboboxItems(CmbCameraReadingPosBottom, 1, 500, 0);
                // 照合桁コンボボックス設定
                SetComboboxItems(CmbVerificationDigit, 1, 9, 8);
                // 照合開始位置（上）コンボボックス設定
                SetComboboxItems(CmbVerificationStartPosTop, 1, 50, 0);
                // 照合開始位置（下）コンボボックス設定
                SetComboboxItems(CmbVerificationStartPosBottom, 1, 50, 0);

                // 停止設定コンボボックス設定
                CmbStopSetting.IntegralHeight = false;
                CmbStopSetting.MaxDropDownItems = 10;
                CmbStopSetting.Items.Clear();
                CmbStopSetting.Items.Add("停止なし");
                for (int iIndex = 1; iIndex <= 9; iIndex++)
                {
                    CmbStopSetting.Items.Add(iIndex.ToString("0"));
                }
                CmbStopSetting.SelectedIndex = 0;

                // 連番検査コンボボックス設定
                CmbSerialNumberInspection.Items.Clear();
                CmbSerialNumberInspection.Items.Add("昇順");
                CmbSerialNumberInspection.Items.Add("降順");
                CmbSerialNumberInspection.Items.Add("検査なし");
                CmbSerialNumberInspection.SelectedIndex = 2;

                // カメラJOB番号コンボボックス設定
                SetComboboxItems(CmbCameraJobNumber, 1, 100, 0);

                BtnCopyItem.Enabled = false;    // 「項目コピー」ボタン使用不可
                BtnPasteItem.Enabled = false;   // 「項目貼付け」ボタン使用不可
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【JobEntryForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetComboboxItems(ComboBox comboBox, int iFrom, int iTo, int iSelectedIndex)
        {
            try
            {
                comboBox.IntegralHeight = false;
                comboBox.MaxDropDownItems = 10;
                comboBox.Items.Clear();
                for (int iIndex = iFrom; iIndex <= iTo; iIndex++)
                {
                    comboBox.Items.Add(iIndex);
                }
                comboBox.SelectedIndex = iSelectedIndex;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【SetComboboxItems】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void BtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【JobEntryForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        string sSelectedFile = "";

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
                    // ファイル名のみを表示する
                    LblSelectedFile.Text = sArray[sArray.Length - 1];

                    // ジョブ登録情報の読取
                    CommonModule.ReadJobEntryListFile(sSelectedFile);
                    // 登録ジョブ項目を取得し表示
                    GetEntryJobItem();

                    BtnAdd.Enabled = true;          // 「新規保存」　ボタン使用可
                    BtnUpdate.Enabled = true;       // 「保存」　　　ボタン使用可                    
                    BtnDelete.Enabled = true;       // 「削除」　　　ボタン使用可
                    BtnCopyItem.Enabled = true;     // 「項目コピー」ボタン使用可
                    //BtnPasteItem.Enabled = true;    // 「項目貼付け」ボタン使用可能
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnJobSelect_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show($"ジョブデータを新規追加しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Cancel)
            {
                return;
            }
            // 設定画面の項目クリア
            ClearDisplayData();

            // 選択中ジョブフィル名クリア
            LblSelectedFile.Text = "";
            BtnAdd.Enabled = false;         // 「新規保存」　ボタン使用不可
            BtnUpdate.Enabled = true;       // 「保存」　　　ボタン使用可
            BtnDelete.Enabled = false;      // 「削除」　　　ボタン使用不可
            BtnCopyItem.Enabled = false;    // 「項目コピー」ボタン使用不可
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtJobName.Text.Trim() == "")
                {
                    MessageBox.Show("JOB名を入力して下さい", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (LblSelectedFile.Text.Trim() == "")
                    {
                        LblSelectedFile.Text = TxtJobName.Text + ".csv";
                    }
                }

                //CheckInvalidString(TxtJobName.Text, "JOB名");
                if (CheckInvalidString(TxtJobName.Text, "JOB名") == false)
                {
                    return;
                }

                // ファイル名長チェック
                if (TxtJobName.Text.Length > PubConstClass.MaxFileNameLength)
                {
                    string sError = $"ファイル名が長すぎます。（最大 {PubConstClass.MaxFileNameLength} 文字）";
                    MessageBox.Show(sError, "確認", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sMessage = $"{Environment.NewLine}JOB名：{TxtJobName.Text}";
                DialogResult dialogResult = MessageBox.Show($"下記ジョブデータを更新しますか？{sMessage}", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }

                if (LblSelectedFile.Text != (TxtJobName.Text + ".csv"))
                {
                    string sPutDataPath = "";
                    sPutDataPath += CommonModule.IncludeTrailingPathDelimiter(Application.StartupPath);
                    sPutDataPath += "\\JOB\\";
                    sPutDataPath += LblSelectedFile.Text;
                    File.Delete(sPutDataPath);
                    LblSelectedFile.Text = TxtJobName.Text + ".csv";
                }

                // 全てのジョブ登録データ名称の取得
                string sFeederData = GetAllJobEntryData();

                // ジョブファイルの保存
                WriteNewJobFile(LblSelectedFile.Text, sFeederData);

            }
            catch (Exception ex)
            {
                Log.OutPutLogFile(TraceEventType.Error, $"【BtnUpdate_Click】{ex.StackTrace}");
                MessageBox.Show(ex.StackTrace, "【BtnUpdate_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// 「削除」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (LblSelectedFile.Text.Trim() == "")
                {
                    MessageBox.Show("JOBを選択して下さい", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    return;
                }

                DialogResult dialogResult = MessageBox.Show($"JOB設定ファイル（{LblSelectedFile.Text}）を削除しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }

                if (File.Exists(sSelectedFile))
                {
                    File.Delete(sSelectedFile);
                    ClearDisplayData();
                    Log.OutPutLogFile(TraceEventType.Information, $"JOB設定ファイル（{sSelectedFile}）を削除しました");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnDelete_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private List<string> lstCopyItem = new List<string>();

        private void BtnCopyItem_Click(object sender, EventArgs e)
        {
            try
            {
                //if (PubConstClass.lstGroupInfo.Count == 0)
                if (LblSelectedFile.Text.Trim() == "")
                {
                    MessageBox.Show("JOB選択してください", "確認", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string sMessage = Environment.NewLine + Environment.NewLine;
                sMessage += $"{LblPaperDepth.Text}：{CmbPaperDepth.Text}{Environment.NewLine}";
                sMessage += $"{LblCameraReadingPosTop.Text}：{CmbCameraReadingPosTop.Text}{Environment.NewLine}";
                sMessage += $"{LblCameraReadingPosBottom.Text}：{CmbCameraReadingPosBottom.Text}{Environment.NewLine}";
                sMessage += $"{LblVerificationDigit.Text}：{CmbVerificationDigit.Text}{Environment.NewLine}";
                sMessage += $"{LblVerificationStartPosTop.Text}：{CmbVerificationStartPosTop.Text}{Environment.NewLine}";
                sMessage += $"{LblVerificationStartPosBottom.Text}：{CmbVerificationStartPosBottom.Text}{Environment.NewLine}";
                sMessage += $"{LblStopSetting.Text}：{CmbStopSetting.Text}{Environment.NewLine}";
                sMessage += $"{LblSerialNumberInspection.Text}：{CmbSerialNumberInspection.Text}{Environment.NewLine}";
                sMessage += $"{LblCameraJobNumber.Text}：{CmbCameraJobNumber.Text}{Environment.NewLine}";

                DialogResult dialogResult = MessageBox.Show($"下記の表示項目をコピーしますか？{sMessage}", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                // 「項目貼付け」ボタン使用可
                BtnPasteItem.Enabled = true;

                lstCopyItem.Clear();
                lstCopyItem.Add(CmbPaperDepth.Text);
                lstCopyItem.Add(CmbCameraReadingPosTop.Text);
                lstCopyItem.Add(CmbCameraReadingPosBottom.Text);
                lstCopyItem.Add(CmbVerificationDigit.Text);
                lstCopyItem.Add(CmbVerificationStartPosTop.Text);
                lstCopyItem.Add(CmbVerificationStartPosBottom.Text);
                lstCopyItem.Add(CmbStopSetting.Text);
                lstCopyItem.Add(CmbSerialNumberInspection.Text);
                lstCopyItem.Add(CmbCameraJobNumber.Text);

                BtnPasteItem.Enabled = true;    // 「項目貼付け」ボタン使用可能
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnCopyItem_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPasteItem_Click(object sender, EventArgs e)
        {
            int iIndex;
            try
            {
                iIndex = 0;
                string sMessage = Environment.NewLine + Environment.NewLine;
                sMessage += $"{LblPaperDepth.Text                }：{lstCopyItem[iIndex++]}{Environment.NewLine}";
                sMessage += $"{LblCameraReadingPosTop.Text       }：{lstCopyItem[iIndex++]}{Environment.NewLine}";
                sMessage += $"{LblCameraReadingPosBottom.Text    }：{lstCopyItem[iIndex++]}{Environment.NewLine}";
                sMessage += $"{LblVerificationDigit.Text         }：{lstCopyItem[iIndex++]}{Environment.NewLine}";
                sMessage += $"{LblVerificationStartPosTop.Text   }：{lstCopyItem[iIndex++]}{Environment.NewLine}";
                sMessage += $"{LblVerificationStartPosBottom.Text}：{lstCopyItem[iIndex++]}{Environment.NewLine}";
                sMessage += $"{LblStopSetting.Text               }：{lstCopyItem[iIndex++]}{Environment.NewLine}";
                sMessage += $"{LblSerialNumberInspection.Text    }：{lstCopyItem[iIndex++]}{Environment.NewLine}";
                sMessage += $"{LblCameraJobNumber.Text           }：{lstCopyItem[iIndex++]}{Environment.NewLine}";

                DialogResult dialogResult = MessageBox.Show($"コピーした下記項目を貼り付けますか？{sMessage}", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                iIndex = 0;
                CmbPaperDepth.Text                 = lstCopyItem[iIndex++];
                CmbCameraReadingPosTop.Text        = lstCopyItem[iIndex++];
                CmbCameraReadingPosBottom.Text     = lstCopyItem[iIndex++];
                CmbVerificationDigit.Text          = lstCopyItem[iIndex++];
                CmbVerificationStartPosTop.Text    = lstCopyItem[iIndex++];
                CmbVerificationStartPosBottom.Text = lstCopyItem[iIndex++];
                CmbStopSetting.Text                = lstCopyItem[iIndex++];
                CmbSerialNumberInspection.Text     = lstCopyItem[iIndex++];
                CmbCameraJobNumber.Text            = lstCopyItem[iIndex++];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnPasteItem_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 設定画面の項目をクリアする
        /// </summary>
        private void ClearDisplayData()
        {
            try
            {
                // JOB名
                TxtJobName.Text = "";
                // 選択ジョブファイル名クリア
                LblSelectedFile.Text = "";

                // 用紙デプス
                CmbPaperDepth.SelectedIndex = 0;
                // カメラ読取位置（上）
                CmbCameraReadingPosTop.SelectedIndex = 0;
                // カメラ読取位置（下）
                CmbCameraReadingPosBottom.SelectedIndex = 0;
                // 照合桁              
                CmbVerificationDigit.SelectedIndex = 0;
                // 照合開始位置（上）  
                CmbVerificationStartPosTop.SelectedIndex = 0;
                // 照合開始位置（下）  
                CmbVerificationStartPosBottom.SelectedIndex = 0;
                // 停止設定            
                CmbStopSetting.SelectedIndex = 0;
                // 連番検査            
                CmbSerialNumberInspection.SelectedIndex = 0;
                // カメラJOB番号       
                CmbCameraJobNumber.SelectedIndex = 0;

                // 「保存」ボタンを使用不可とする
                BtnUpdate.Enabled = false;
                // 「削除」ボタンを使用不可とする
                BtnDelete.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【ClearDisplayData】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 全てのジョブ登録データ名称の取得
        /// </summary>
        /// <returns></returns>
        private string GetAllJobEntryData()
        {
            try
            {
                string sData = "";
                // JOB名
                sData += TxtJobName.Text.Trim() + ",";
                // 用紙デプス
                sData += CmbPaperDepth.SelectedIndex + ",";
                // カメラ読取位置（上）
                sData += CmbCameraReadingPosTop.SelectedIndex + ",";
                // カメラ読取位置（下）
                sData += CmbCameraReadingPosBottom.SelectedIndex + ",";
                // 照合桁              
                sData += CmbVerificationDigit.SelectedIndex + ",";
                // 照合開始位置（上）  
                sData += CmbVerificationStartPosTop.SelectedIndex + ",";
                // 照合開始位置（下）  
                sData += CmbVerificationStartPosBottom.SelectedIndex + ",";
                // 停止設定            
                sData += CmbStopSetting.SelectedIndex + ",";
                // 連番検査            
                sData += CmbSerialNumberInspection.SelectedIndex + ",";
                // カメラJOB番号       
                sData += CmbCameraJobNumber.SelectedIndex + ",";

                return sData;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【GetAllJobEntryData】", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
        }


        /// <summary>
        /// 登録ジュブ項目を取得し表示する
        /// </summary>
        /// <param name="iJobIndex"></param>
        private void GetEntryJobItem()
        {
            string[] sArray;

            try
            {
                int iIndex = 0;
                sArray = PubConstClass.sJobEntryData.Split(',');
                // JOB名
                TxtJobName.Text = sArray[iIndex++];

                // 用紙デプス
                CmbPaperDepth.SelectedIndex = int.TryParse(sArray[iIndex++], out int iIdx) ? iIdx : 0;
                // カメラ読取位置（上）
                CmbCameraReadingPosTop.SelectedIndex = int.TryParse(sArray[iIndex++], out iIdx) ? iIdx : 0;
                // カメラ読取位置（下）
                CmbCameraReadingPosBottom.SelectedIndex = int.TryParse(sArray[iIndex++], out iIdx) ? iIdx : 0;
                // 照合桁              
                CmbVerificationDigit.SelectedIndex = int.TryParse(sArray[iIndex++], out iIdx) ? iIdx : 0;
                // 照合開始位置（上）  
                CmbVerificationStartPosTop.SelectedIndex = int.TryParse(sArray[iIndex++], out iIdx) ? iIdx : 0;
                // 照合開始位置（下）  
                CmbVerificationStartPosBottom.SelectedIndex = int.TryParse(sArray[iIndex++], out iIdx) ? iIdx : 0;
                // 停止設定            
                CmbStopSetting.SelectedIndex = int.TryParse(sArray[iIndex++], out iIdx) ? iIdx : 0;
                // 連番検査            
                CmbSerialNumberInspection.SelectedIndex = int.TryParse(sArray[iIndex++], out iIdx) ? iIdx : 0;
                // カメラJOB番号       
                CmbCameraJobNumber.SelectedIndex = int.TryParse(sArray[iIndex++], out iIdx) ? iIdx : 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "【GetEntryJobItem】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sFileName"></param>
        /// <param name="sFeederData"></param>
        /// <param name="sPocketData"></param>
        private void WriteNewJobFile(string sFileName, string sFeederData)
        {
            string sPutDataPath = "";

            string sError = "";
            try
            {
                sPutDataPath += CommonModule.IncludeTrailingPathDelimiter(Application.StartupPath);
                sPutDataPath += "\\JOB\\";
                if (!Directory.Exists(sPutDataPath))
                {
                    // JOBフォルダが存在しない場合は作成する                                                                                                                                                                                                                                                                                 
                    Directory.CreateDirectory(sPutDataPath);
                }                                                          
                sPutDataPath += sFileName;


                // ファイル名長チェック
                if (sFileName.Length > PubConstClass.MaxFileNameLength)
                {
                    sError = $"ファイル名が長すぎます。（最大 {PubConstClass.MaxFileNameLength} 文字）";
                }
                // フルパス長チェック
                if (sPutDataPath.Length > PubConstClass.MaxPathLength)
                {
                    sError = $"パス全体が長すぎます。（最大 {PubConstClass.MaxPathLength} 文字）";
                }
                // 警告メッセージの表示
                if (sError != "")
                {
                    MessageBox.Show(sError, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 上書モードで書き込む
                using (StreamWriter sw = new StreamWriter(sPutDataPath, false, Encoding.Default))
                {
                    // フィーダー設定データ書込
                    sw.WriteLine(sFeederData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【WriteNewJobFile】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        // 禁則文字のリスト
        //private static readonly char[] InvalidFileNameChars = Path.GetInvalidFileNameChars();
        //private static readonly char[] InvalidFileNameChars = new char[] { '\\', '/', ':', '*', '?', '"', '<', '>', '|' };
        private static readonly char[] InvalidFileNameChars = new char[] { '\\', '/', ':', '*', '?', '"', '<', '>', '|', '.', '_' };
        /// <summary>
        /// ファイル名に使用できない文字が含まれているかを判定する
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private bool IsFileNameValid(string fileName)
        {
            return fileName.Any(ch => InvalidFileNameChars.Contains(ch));
        }
    }
}
