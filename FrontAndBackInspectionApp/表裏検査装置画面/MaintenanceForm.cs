using Kinoshita.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontAndBackInspectionApp.表裏検査装置画面
{
    public partial class MaintenanceForm : Form
    {
        public MaintenanceForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームロード処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaintenanceForm_Load(object sender, EventArgs e)
        {
            try
            {
                LblTitle.Text = "表裏検査装置　保守画面";
                LblVersion.Text = PubConstClass.DEF_VERSION;

                Log.OutPutLogFile(TraceEventType.Information, "保守画面を表示しました");

                CommonModule.ReadSystemDefinition();

                #region エラーログ一覧のヘッダー設定
                // ListViewのカラムヘッダー設定
                LsvLogList.View = View.Details;
                ColumnHeader col1 = new ColumnHeader();
                ColumnHeader col2 = new ColumnHeader();
                ColumnHeader col3 = new ColumnHeader();
                col1.Text = "　　エラーログファイル名";
                col2.Text = "件数";
                col3.Text = "格納フォルダ";
                col1.TextAlign = HorizontalAlignment.Left;
                col2.TextAlign = HorizontalAlignment.Center;
                col3.TextAlign = HorizontalAlignment.Left;
                col1.Width = 600;         // エラーログファイル名
                col2.Width = 100;         // 件数
                col3.Width = 1100;        // 格納フォルダ
                ColumnHeader[] colHeaderList = new[] { col1, col2, col3 };
                LsvLogList.Columns.AddRange(colHeaderList);
                #endregion
                #region エラーログのヘッダー設定
                // ListViewのカラムヘッダー設定
                LsvLogContent.View = View.Details;
                ColumnHeader col01 = new ColumnHeader();
                ColumnHeader col02 = new ColumnHeader();
                ColumnHeader col03 = new ColumnHeader();
                ColumnHeader col04 = new ColumnHeader();
                col01.Text = "　　発生年月日 時分秒";
                col02.Text = "エラー番号";
                col03.Text = "エラー箇所";
                col04.Text = "　　　エラー内容";
                col01.TextAlign = HorizontalAlignment.Center;
                col02.TextAlign = HorizontalAlignment.Center;
                col03.TextAlign = HorizontalAlignment.Center;
                col04.TextAlign = HorizontalAlignment.Left;
                col01.Width = 200;         // 発生年月日 時分秒
                col02.Width = 150;         // エラー番号
                col03.Width = 300;         // エラー箇所
                col04.Width = 800;         // エラー内容
                ColumnHeader[] colHeaderOK = new[] { col01, col02, col03, col04 };
                LsvLogContent.Columns.AddRange(colHeaderOK);
                #endregion

                LblLogFileCount.Text = "";
                LblContentCount.Text = "";
                LblSelectedFile.Text = "";

                CmbSortBy.Items.Clear();
                CmbSortBy.Items.Add("ファイル作成順");
                CmbSortBy.Items.Add("ファイル名順");
                CmbSortBy.SelectedIndex = 0;

                // 号機名
                TxtMachineName.Text = PubConstClass.pblMachineName;

                // ディスク空き容量チェック
                TxtHddSpace.Text = PubConstClass.pblHddSpace;

                // パスワード
                TxtPassword.Text = PubConstClass.pblPassword;

                // ロゴ表示
                ChkIsDispLogo.Checked = (PubConstClass.pblLogoDisp == "1");
                PctLogo.Visible = ChkIsDispLogo.Checked;

                #region ログ保存
                CmbSaveMonth.Items.Clear();
                for (int N = 1; N <= 36; N++)
                {
                    CmbSaveMonth.Items.Add(N.ToString() + "ヶ月");
                }
                if (PubConstClass.pblLogSaveMonth != "")
                {
                    CmbSaveMonth.SelectedIndex = Convert.ToInt32(PubConstClass.pblLogSaveMonth) - 1;
                }
                else
                {
                    CmbSaveMonth.SelectedIndex = 0;
                }
                #endregion

                // ログフォルダ
                TxtLogFolder.Text = PubConstClass.pblLogFolder;
                // バックアップログフォルダ
                TxtBackupFolder.Text = PubConstClass.pblBackupFolder;

                // COMポート名
                CmbComPort.Items.Clear();
                for (int iIndex = 1; iIndex <= 15; iIndex++)
                    CmbComPort.Items.Add("COM" + Convert.ToString(iIndex));
                CmbComPort.SelectedIndex = Convert.ToInt32(PubConstClass.pblComPort.Substring(3, 1)) - 1;

                // COM通信速度
                CmbComSpeed.Items.Clear();
                CmbComSpeed.Items.Add("4800");
                CmbComSpeed.Items.Add("9600");
                CmbComSpeed.Items.Add("19200");
                CmbComSpeed.Items.Add("38400");
                CmbComSpeed.Items.Add("57600");
                CmbComSpeed.Items.Add("115200");
                CmbComSpeed.SelectedIndex = Convert.ToInt32(PubConstClass.pblComSpeed);

                // COMデータ長
                CmbComDataLength.Items.Clear();
                CmbComDataLength.Items.Add("8bit");
                CmbComDataLength.Items.Add("7bit");
                CmbComDataLength.SelectedIndex = Convert.ToInt32(PubConstClass.pblComDataLength);

                // COMパリティの有無
                CmbComIsParty.Items.Clear();
                CmbComIsParty.Items.Add("無効");
                CmbComIsParty.Items.Add("有効");
                CmbComIsParty.SelectedIndex = Convert.ToInt32(PubConstClass.pblComIsParity);

                // COMパリティ種別
                CmbComParityVar.Items.Clear();
                CmbComParityVar.Items.Add("奇数");
                CmbComParityVar.Items.Add("偶数");
                CmbComParityVar.SelectedIndex = Convert.ToInt32(PubConstClass.pblComParityVar);

                // COMストップビット
                CmbComStopBit.Items.Clear();
                CmbComStopBit.Items.Add("1bit");
                CmbComStopBit.Items.Add("2bit");
                CmbComStopBit.SelectedIndex = Convert.ToInt32(PubConstClass.pblComStopBit);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【MaintenanceForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkIsDispLogo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if(ChkIsDispLogo.Checked == true)
                {
                    PubConstClass.pblLogoDisp = "1";
                    PctLogo.Visible = true;
                }
                else
                {
                    PubConstClass.pblLogoDisp = "0";
                    PctLogo.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【ChkIsDispLogo_CheckedChanged】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「ログフォルダ選択」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSelectLogFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            try
            {
                fbd.Description = "ログ格納フォルダを選択してください。";

                fbd.RootFolder = Environment.SpecialFolder.Desktop;
                fbd.SelectedPath = TxtLogFolder.Text;

                // 新規フォルダ作成を表示
                fbd.ShowNewFolderButton = true;

                if (fbd.ShowDialog(this) == DialogResult.OK)
                    // 選択されたフォルダを表示する
                    TxtLogFolder.Text = fbd.SelectedPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnSelectLogFolder_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「バックアップログフォルダ選択」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void BtnSelectBackupFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            try
            {
                fbd.Description = "バックアップログ格納フォルダを選択してください。";

                fbd.RootFolder = Environment.SpecialFolder.Desktop;
                fbd.SelectedPath = TxtBackupFolder.Text;

                // 新規フォルダ作成を表示
                fbd.ShowNewFolderButton = true;

                if (fbd.ShowDialog(this) == DialogResult.OK)
                    // 選択されたフォルダを表示する
                    TxtBackupFolder.Text = fbd.SelectedPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnSelectBackupFolder_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「適用」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnApply_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;

            try
            {
                dialogResult = MessageBox.Show("設定を保存しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.OK)
                {
                    // 装置名称
                    PubConstClass.pblMachineName = TxtMachineName.Text;
                    // ディスク空き容量
                    PubConstClass.pblHddSpace = TxtHddSpace.Text;
                    // パスワード
                    PubConstClass.pblPassword = TxtPassword.Text;
                    // ロゴ表示
                    PubConstClass.pblLogoDisp = ChkIsDispLogo.Checked == true ?  "1": "0";
                    // ログの保存期間
                    PubConstClass.pblLogSaveMonth = (CmbSaveMonth.SelectedIndex + 1).ToString();

                    // 通信設定
                    PubConstClass.pblComPort = CmbComPort.SelectedItem.ToString();
                    PubConstClass.pblComSpeed = CmbComSpeed.SelectedIndex.ToString();
                    PubConstClass.pblComDataLength = CmbComDataLength.SelectedIndex.ToString();
                    PubConstClass.pblComIsParity = CmbComIsParty.SelectedIndex.ToString();
                    PubConstClass.pblComParityVar = CmbComParityVar.SelectedIndex.ToString();
                    PubConstClass.pblComStopBit = CmbComStopBit.SelectedIndex.ToString();

                    // ログ格納フォルダ
                    PubConstClass.pblLogFolder = TxtLogFolder.Text;

                    // バックアップログ格納フォルダ
                    PubConstClass.pblBackupFolder = TxtBackupFolder.Text;

                    // システム定義ファイルの書き込み処理
                    CommonModule.WriteSystemDefinition();

                    // ディスクの空き領域をチェック
                    CommonModule.CheckAvairableFreeSpace();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "【BtnApply_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「ログデータ手動削除」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnDeleteLogData_Click(object sender, EventArgs e)
        {
            string sPath;

            try
            {
                // 現在の日付（年月日）を求める
                DateTime dtCurrent = DateTime.Now;

                int intMinusMonth = CmbSaveMonth.SelectedIndex;
                // 現在日付から１ヶ月を減算
                DateTime dtPassDate = dtCurrent.AddMonths(-(intMinusMonth + 1));

                DialogResult dialogResult = MessageBox.Show($"現在の日付から{intMinusMonth + 1}ヶ月前は、{dtPassDate}です。" +
                                                            $"{Environment.NewLine}それ以前のデータを削除しますか？",
                                                            "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }

                //////////////////////////////////////////
                /// 操作履歴ログファイル格納パスの設定 ///
                //////////////////////////////////////////
                sPath = Environment.CurrentDirectory + @"\OPHISTORYLOG";
                CommonModule.DeleteOldFilesSub(sPath, "操作履歴ログ", (intMinusMonth + 1).ToString());

                //////////////////////////////////////
                /// 通信ログファイル格納パスの設定 ///
                //////////////////////////////////////
                sPath = Environment.CurrentDirectory + @"\OPHISTORYLOG";
                CommonModule.DeleteOldFilesSub(sPath, "通信ログ", (intMinusMonth + 1).ToString());

                MessageBox.Show("削除処理が完了しました。", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【メンテンス画面】【BtnDeleteLogData_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            SetEnableControl(false);
            PicWaitList.Visible = true;
            PicWaitList.Refresh();
            // エラーログ一覧表示処理
            ErrorLogList();
            PicWaitList.Visible = false;
            BtnUpdate.Enabled = true;
            SetEnableControl(true);
        }

        /// <summary>
        /// コントロールの有効／無効設定
        /// </summary>
        /// <param name="bEnabled"></param>
        private void SetEnableControl(bool bEnabled)
        {
            try
            {
                BtnJobSelect.Enabled = bEnabled;
                BtnJobClear.Enabled = bEnabled;
                GrpSortBy.Enabled = bEnabled;
                BtnUpdate.Enabled = bEnabled;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【SetEnableControl】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ログファイル一覧格納リスト
        private List<string> lstLogFileList = new List<string>();


        /// <summary>
        /// エラーログ一覧表示処理
        /// </summary>
        private void ErrorLogList()
        {
            string[] sArray;
            string[] sArrayJob;
            string sPath;

            try
            {
                sPath = "エラーログ\\";
                if (LblSelectedFile.Text != "")
                {
                    sArrayJob = LblSelectedFile.Text.Split('.');
                    sPath += sArrayJob[0] + "\\";
                }
                else
                {
                    sArrayJob = ".csv".Split('.');
                    sPath += "\\";
                }

                if (!Directory.Exists(CommonModule.IncludeTrailingPathDelimiter(PubConstClass.pblLogFolder) + sPath))
                {
                    //CommonModule.OutPutLogFile($"【エラーログ】JOB（{sArrayJob[0]}）は、未検査のJOBです");
                    Log.OutPutLogFile(TraceEventType.Information, $"【エラーログ】JOB（{sArrayJob[0]}）は、未検査のJOBです");
                    MessageBox.Show($"JOB（{sArrayJob[0]}）は、未検査のJOBです", "確認", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // ログファイル一覧格納リストのクリア
                lstLogFileList.Clear();
                // 検査ログ一覧のクリア
                LsvLogList.Items.Clear();
                // 検査ログの内容のクリア
                LsvLogContent.Items.Clear();

                List<string> lstFileList = new List<string>();
                lstFileList.Clear();
                if (CmbSortBy.SelectedIndex == 0)
                {
                    // ファイル作成順
                    foreach (string sTranFile in Directory.GetFiles(CommonModule.IncludeTrailingPathDelimiter(
                                                                          PubConstClass.pblLogFolder) +
                                                                          sPath,
                                                                          "*", SearchOption.AllDirectories).OrderByDescending(f => File.GetLastWriteTime(f)))
                    {
                        lstFileList.Add(sTranFile);
                    }
                }
                else
                {
                    // ファイル名順
                    foreach (string sTranFile in Directory.GetFiles(CommonModule.IncludeTrailingPathDelimiter(
                                                                          PubConstClass.pblLogFolder) +
                                                                          sPath,
                                                                          "*", SearchOption.AllDirectories))
                    {
                        lstFileList.Add(sTranFile);
                    }
                }

                // 検査ログ対象ファイルの取得
                foreach (string sTranFile in lstFileList)
                {
                    //CommonModule.OutPutLogFile($"エラーログ対象ファイル：{sTranFile}");
                    sArray = sTranFile.Split('\\');
                    string sFileName = sArray[sArray.Length - 1];
                    string sFileNameFullPath = sTranFile;

                    // 検査日付で絞り込む
                    if (ChkInspectionDate.Checked)
                    {
                        string[] sArrayDate = sFileName.Split('_');
                        if (!(int.Parse(dtTimePickerFrom.Value.ToString("yyyyMMdd")) <= int.Parse(sArrayDate[sArrayDate.Length - 1].Substring(0, 8)) &
                            int.Parse(dtTimePickerTo.Value.ToString("yyyyMMdd")) >= int.Parse(sArrayDate[sArrayDate.Length - 1].Substring(0, 8))))
                        {
                            // 該当しないので対象ファイルから外す
                            sFileName = "";
                            sFileNameFullPath = "";
                        }
                    }

                    if (sFileName != "")
                    {
                        string sPathName;

                        // OKログ
                        if (sArray[3] == "")
                        {
                            // JOB名でのフィルタ無し
                            sPathName = sArray[0] + "¥" + sArray[1] + "¥" + sArray[2] + "¥" + sArray[4];
                        }
                        else
                        {
                            // JOB名でのフィルタ有り
                            sPathName = sArray[0] + "¥" + sArray[1] + "¥" + sArray[2] + "¥" + sArray[3];
                        }

                        // 件数の取得
                        string[] Lines = File.ReadAllLines(sTranFile);
                        // 検査ログファイル一覧格納リストに追加
                        lstLogFileList.Add(sTranFile);

                        string[] col = new string[3];
                        ListViewItem itm;
                        col[0] = sArray[sArray.Length - 1];     // ファイル名
                        col[1] = $"{Lines.Length}件";           // 件数
                        col[2] = sPathName;                     // 格納フォルダ

                        // データの表示
                        itm = new ListViewItem(col);
                        LsvLogList.Items.Add(itm);
                        LsvLogList.Items[0].UseItemStyleForSubItems = false;
                        LsvLogList.Select();
                        LsvLogList.Items[0].EnsureVisible();
                    }
                }

                if (sArrayJob[0] == "")
                {
                    sArrayJob[0] = "指定なし";
                }
                LblLogFileCount.Text = $"JOB名（{sArrayJob[0]}）{LsvLogList.Items.Count:#,###} 件";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【ErrorLogList】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}
