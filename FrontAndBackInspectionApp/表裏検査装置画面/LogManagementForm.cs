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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FrontAndBackInspectionApp.表裏検査装置画面
{
    public partial class LogManagementForm : Form
    {
        public LogManagementForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームロード処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LogManagementForm_Load(object sender, EventArgs e)
        {
            try
            {
                LblTitle.Text = "表裏検査装置　ログ管理画面";
                LblVersion.Text = PubConstClass.DEF_VERSION;

                // ロゴ表示
                PctLogo.Visible = PubConstClass.pblLogoDisp == "1";

                LblSelectedFile.Text = "";
                PicWaitList.Visible = false;
                PicWaitContent.Visible = false;

                CmbSortBy.Items.Clear();
                CmbSortBy.Items.Add("ファイル作成順");
                CmbSortBy.Items.Add("ファイル名順");
                CmbSortBy.SelectedIndex = 0;

                // （OK）判定項目コンボボックス設定
                CmbOkCondition.Items.Clear();
                //CmbOkCondition.Items.Add("全判定項目");
                CmbOkCondition.Items.Add("読取結果");
                CmbOkCondition.Items.Add("表裏一致");
                CmbOkCondition.Items.Add("連番");
                CmbOkCondition.SelectedIndex = 0;
                // （OK）判定条件コンボボックス設定
                CmbOkJudgement.Items.Clear();
                CmbOkJudgement.Items.Add("全て");
                CmbOkJudgement.Items.Add("OK");
                CmbOkJudgement.Items.Add("NG");
                CmbOkJudgement.Items.Add("NC");
                CmbOkJudgement.Items.Add("--");
                CmbOkJudgement.SelectedIndex = 0;
                // （NG）判定項目コンボボックス設定
                CmbNgCondition.Items.Clear();
                //CmbNgCondition.Items.Add("全判定項目");
                CmbNgCondition.Items.Add("読取結果");
                CmbNgCondition.Items.Add("表裏一致");
                CmbNgCondition.Items.Add("連番");
                CmbNgCondition.SelectedIndex = 0;
                // （NG）判定条件コンボボックス設定
                CmbNgJudgement.Items.Clear();
                CmbNgJudgement.Items.Add("全て");
                CmbNgJudgement.Items.Add("OK");
                CmbNgJudgement.Items.Add("NG");
                CmbNgJudgement.Items.Add("NC");
                CmbNgJudgement.Items.Add("--");
                CmbNgJudgement.SelectedIndex = 0;

                #region 検査ログ一覧のヘッダー設定
                // ListViewのカラムヘッダー設定
                LsvLogList.View = View.Details;
                ColumnHeader col1 = new ColumnHeader();
                ColumnHeader col2 = new ColumnHeader();
                ColumnHeader col3 = new ColumnHeader();
                col1.Text = "　　検査ログファイル名";
                col2.Text = "件数";
                col3.Text = "格納フォルダ";
                col1.TextAlign = HorizontalAlignment.Left;
                col2.TextAlign = HorizontalAlignment.Center;
                col3.TextAlign = HorizontalAlignment.Left;
                col1.Width = 800;         // 検査ログファイル名
                col2.Width = 100;         // 件数
                col3.Width = 1100;        // 格納フォルダ
                ColumnHeader[] colHeaderList = new[] { col1, col2, col3 };
                LsvLogList.Columns.AddRange(colHeaderList);
                #endregion
                #region 検査履歴のヘッダー設定
                //LstReadData.View = View.Details;
                ColumnHeader colOK1 = new ColumnHeader();
                ColumnHeader colOK2 = new ColumnHeader();
                ColumnHeader colOK3 = new ColumnHeader();
                ColumnHeader colOK4 = new ColumnHeader();
                ColumnHeader colOK5 = new ColumnHeader();
                SetHeaderData(LsvLogContent, colOK1, colOK2, colOK3, colOK4, colOK5);
                #endregion
                #region エラー履歴のヘッダー設定
                //LstError.View = View.Details;
                ColumnHeader colNG1 = new ColumnHeader();
                ColumnHeader colNG2 = new ColumnHeader();
                ColumnHeader colNG3 = new ColumnHeader();
                ColumnHeader colNG4 = new ColumnHeader();
                ColumnHeader colNG5 = new ColumnHeader();
                SetHeaderData(LsvLogErrorContent, colNG1, colNG2, colNG3, colNG4, colNG5);
                #endregion

                #region 抽出後検査履歴のヘッダー設定
                //LstReadData.View = View.Details;
                ColumnHeader colOKEX1 = new ColumnHeader();
                ColumnHeader colOKEX2 = new ColumnHeader();
                ColumnHeader colOKEX3 = new ColumnHeader();
                ColumnHeader colOKEX4 = new ColumnHeader();
                ColumnHeader colOKEX5 = new ColumnHeader();
                SetHeaderData(LsvLogExtract, colOKEX1, colOKEX2, colOKEX3, colOKEX4, colOKEX5);
                #endregion
                #region 抽出後のエラー履歴のヘッダー設定
                //LstError.View = View.Details;
                ColumnHeader colNGEX1 = new ColumnHeader();
                ColumnHeader colNGEX2 = new ColumnHeader();
                ColumnHeader colNGEX3 = new ColumnHeader();
                ColumnHeader colNGEX4 = new ColumnHeader();
                ColumnHeader colNGEX5 = new ColumnHeader();
                SetHeaderData(LsvLogErrorExtract, colNGEX1, colNGEX2, colNGEX3, colNGEX4, colNGEX5);
                #endregion

                LblLogFileCount.Text = "0 件";
                lblTranOSCount.Text = "0 件";
                lblTranOSNGCount.Text = "0 件";

                // リストビューのダブルバッファを有効とする
                EnableDoubleBuffering(LsvLogContent);
                EnableDoubleBuffering(LsvLogErrorContent);

                #region 抽出用リストビューの設定
                // （検査履歴ビュー）位置を変更
                LsvLogContent.Location = new Point(96, 470);
                LsvLogExtract.Location = new Point(96, 470);
                // （検査履歴ビュー）サイズを変更
                LsvLogContent.Size = new Size(856, 429);
                LsvLogExtract.Size = new Size(856, 429);
                //（検査履歴ビュー）
                LsvLogContent.Visible = true;
                LsvLogExtract.Visible = false;          // 抽出用リストビューは非表示
                
                // （エラー履歴）位置を変更
                LsvLogErrorContent.Location = new Point(964, 470);
                LsvLogErrorExtract.Location = new Point(964, 470);
                // （エラー履歴）サイズを変更
                LsvLogErrorContent.Size = new Size(856, 429);
                LsvLogErrorExtract.Size = new Size(856, 429);
                // （エラー履歴）
                LsvLogErrorContent.Visible = true;
                LsvLogErrorExtract.Visible = false;     // 抽出用リストビューは非表示

                GrpOkExtract.Enabled = false;
                GrpNgExtract.Enabled = false;
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【LogManagementForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// リストビューのヘッダー設定
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="col1"></param>
        /// <param name="col2"></param>
        /// <param name="col3"></param>
        /// <param name="col4"></param>
        /// <param name="col5"></param>
        private void SetHeaderData(System.Windows.Forms.ListView listView, ColumnHeader col1, ColumnHeader col2, ColumnHeader col3, ColumnHeader col4, ColumnHeader col5)
        {
            try
            {
                listView.View = View.Details;

                col1.Text = "　　　日時";
                col2.Text = "読取番号（表裏）";
                col3.Text = "読取結果（表裏）";
                col4.Text = "表裏一致判定";
                col5.Text = "連番判定";

                col1.TextAlign = HorizontalAlignment.Center;
                col2.TextAlign = HorizontalAlignment.Center;
                col3.TextAlign = HorizontalAlignment.Center;
                col4.TextAlign = HorizontalAlignment.Center;
                col5.TextAlign = HorizontalAlignment.Center;

                col1.Width = 200;         // 
                col2.Width = 250;         // 
                col3.Width = 160;         // 
                col4.Width = 120;         // 
                col5.Width = 100;         // 
                ColumnHeader[] colHeader = new[] { col1, col2, col3, col4, col5 };
                listView.Columns.AddRange(colHeader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【SetHeaderData】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// コントロールのDoubleBufferedプロパティをTrueにする
        /// </summary>
        /// <param name="control"></param>
        private void EnableDoubleBuffering(Control control)
        {
            control.GetType().InvokeMember("DoubleBuffered",
                                            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                                            null/* TODO Change to default(_) if this is not a reference type */,
                                            control,
                                            new object[] { true }
                                            );
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

        private void LblKensa_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string[] col = new string[5];
                ListViewItem itm1;
                col[0] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                col[1] = "1234567890 / 0987654321";
                col[2] = "OK / OK";
                col[3] = "OK";
                col[4] = "OK";

                itm1 = new ListViewItem(col);
                LsvLogContent.Items.Add(itm1);
                LsvLogContent.Items[LsvLogContent.Items.Count - 1].UseItemStyleForSubItems = false;
                LsvLogContent.Select();
                LsvLogContent.Items[LsvLogContent.Items.Count - 1].EnsureVisible();

                if (LsvLogContent.Items.Count % 2 == 1)
                {
                    for (int iIndex = 0; iIndex < 5; iIndex++)
                    {
                        // 奇数行の色反転
                        LsvLogContent.Items[LsvLogContent.Items.Count - 1].SubItems[iIndex].BackColor = Color.FromArgb(200, 200, 230);
                    }
                }
                lblTranOSCount.Text = LsvLogContent.Items.Count.ToString() + " 件";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnRun_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LblError_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string[] col = new string[5];
                ListViewItem itm1;
                col[0] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                col[1] = "1234567890 / 0987654321";
                col[2] = "NG / NG";
                col[3] = "NG";
                col[4] = "NG";

                itm1 = new ListViewItem(col);
                LsvLogErrorContent.Items.Add(itm1);
                LsvLogErrorContent.Items[LsvLogErrorContent.Items.Count - 1].UseItemStyleForSubItems = false;
                LsvLogErrorContent.Select();
                LsvLogErrorContent.Items[LsvLogErrorContent.Items.Count - 1].EnsureVisible();

                if (LsvLogErrorContent.Items.Count % 2 == 1)
                {
                    for (int iIndex = 0; iIndex < 5; iIndex++)
                    {
                        // 奇数行の色反転
                        LsvLogErrorContent.Items[LsvLogErrorContent.Items.Count - 1].SubItems[iIndex].BackColor = Color.FromArgb(200, 200, 230);
                    }
                }
                lblTranOSNGCount.Text = LsvLogErrorContent.Items.Count.ToString() + " 件";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnStop_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SetEnableControl(false);

                PicWaitList.Visible = true;
                PicWaitList.Refresh();

                // 検査ログ一覧表示処理
                InspectionLogList();
                
                PicWaitList.Visible = false;

                SetEnableControl(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnUpdate_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                GrpInspectionDate.Enabled = bEnabled;
                //ChkInspectionDate.Enabled = bEnabled;
                //DtTimePickerFrom.Enabled = bEnabled;
                //DtTimePickerTo.Enabled = bEnabled;

                BtnUpdate.Enabled = bEnabled;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【SetEnableControl】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        string sSelectedFile = "";

        /// <summary>
        /// 
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
                    // ファイル名のみを表示する
                    LblSelectedFile.Text = sArray[sArray.Length - 1];

                    //// ジョブ登録情報の読取
                    //CommonModule.ReadJobEntryListFile(sSelectedFile);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnJobSelect_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnJobClear_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("JOB名をクリアしますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Cancel)
                {
                    return;
                }
                LblSelectedFile.Text = "";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnJobClear_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 検査ログ一覧表示処理
        /// </summary>
        private void InspectionLogList()
        {
            string[] sArray;            
            string sPath;

            try
            {
                // ログファイル一覧格納リストのクリア
                lstLogFileList.Clear();
                // 検査ログ一覧のクリア
                LsvLogList.Items.Clear();
                // 検査ログの内容のクリア
                LsvLogContent.Items.Clear();
                // エラー履歴ログの内容クリア
                LsvLogErrorContent.Items.Clear();

                List<string> lstFileList = new List<string>();
                lstFileList.Clear();

                sPath = PubConstClass.LOG_TYPE_INSPECTION_LOG + "\\";   // デバッグ用のパス

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
                    PicWaitList.Refresh();
                    //CommonModule.OutPutLogFile($"{sMes}検査ログ対象ファイル：{sTranFile}");
                    sArray = sTranFile.Split('\\');
                    string sFileName = sArray[sArray.Length - 1];
                    string sFileNameFullPath = sTranFile;
                    // 検査日付で絞り込む
                    if (ChkInspectionDate.Checked)
                    {
                        string[] sArrayDate = sFileName.Split('_');
                        if (!(int.Parse(DtTimePickerFrom.Value.ToString("yyyyMMdd")) <= int.Parse(sArrayDate[sArrayDate.Length - 2].Substring(0, 8)) &
                            int.Parse(DtTimePickerTo.Value.ToString("yyyyMMdd")) >= int.Parse(sArrayDate[sArrayDate.Length - 2].Substring(0, 8))))
                        {
                            // 該当しないので対象ファイルから外す
                            sFileName = "";
                            sFileNameFullPath = "";
                        }
                    }
                    // JOB名で絞り込む
                    if (LblSelectedFile.Text.Trim() != "")
                    {
                        string[] sArrayJob = sFileName.Split('_');
                        if (sArrayJob[1] != LblSelectedFile.Text.Replace(".csv","").Trim())
                        {
                            // 該当しないので対象ファイルから外す
                            sFileName = "";
                            sFileNameFullPath = "";
                        }
                    }

                    if (sFileName != "")
                    {
                        // 格納フォルダの取得
                        string sPathName = "";
                        for(int iIndex = 0; iIndex < sArray.Length - 1; iIndex++)
                        {
                            sPathName += sArray[iIndex] + "¥";
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
                LblLogFileCount.Text = $"表示件数：{LsvLogList.Items.Count:#,###} 件";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【InspectionLogList】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // ログファイル一覧格納リスト
        private readonly List<string> lstLogFileList = new List<string>();

        /// <summary>
        /// 検査ログデータの１行分の表示
        /// </summary>
        /// <param name="sData"></param>
        private void DisplayOneData(System.Windows.Forms.ListView listView, string sData)
        {
            try
            {
                PicWaitContent.Refresh();
                string[] sArray = sData.Split(',');
                string[] col = new string[5];
                ListViewItem itm;
                // 日時
                col[0] = sArray[0].Substring(0, sArray[0].Length);                
                // 読取番号（表裏）
                col[1] = CommonModule.ConversionReadingNumber(sArray[1].Substring(0, sArray[1].Length));
                // 読取結果（表裏）
                col[2] = CommonModule.ConversionReadingResults(sArray[2].Substring(0, sArray[2].Length));
                // 表裏一致判定
                col[3] = CommonModule.ConversionMatchingResults(sArray[3].Substring(0, sArray[3].Length));
                // 連番判定
                col[4] = CommonModule.ConversionSequentialResults(sArray[4].Substring(0, sArray[4].Length));
                // データの表示
                itm = new ListViewItem(col);
                listView.Items.Add(itm);
                if (listView.Items.Count % 2 == 1)
                {
                    for (int iIndex = 0; iIndex < 5; iIndex++)
                    {
                        // 奇数行の色反転
                        listView.Items[listView.Items.Count - 1].SubItems[iIndex].BackColor = Color.FromArgb(200, 200, 230);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【DisplayOneData】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 検査ログ一覧の選択クリック処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LsvLogList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sReadLogFile;
            string sData;
            int iCounter;

            try
            {
                if (LsvLogList.SelectedItems.Count == 0)
                {
                    return;
                }

                LsvLogContent.Items.Clear();
                LsvLogExtract.Items.Clear();
                LsvLogContent.Visible = true;
                LsvLogExtract.Visible = false;

                LsvLogErrorContent.Items.Clear();
                LsvLogErrorExtract.Items.Clear();
                LsvLogErrorContent.Visible = true;
                LsvLogErrorExtract.Visible = false;

                TxtOkQrNumber.Text = "";
                CmbOkCondition.SelectedIndex = 0;
                CmbOkJudgement.SelectedIndex = 0;

                TxtNgQrNumber.Text = "";
                CmbNgCondition.SelectedIndex = 0;
                CmbNgJudgement.SelectedIndex = 0;

                // 選択された検査ログファイルのフルパス名を取得する
                sReadLogFile = lstLogFileList[LsvLogList.SelectedItems[0].Index];
                SetEnableControl(false);                                
                PicWaitContent.Visible = true;
                iCounter = 0;
                using (StreamReader sr = new StreamReader(sReadLogFile, Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        sData = sr.ReadLine();
                        DisplayOneData(LsvLogContent, sData);
                        iCounter++;
                    }
                }
                SetEnableControl(true);
                PicWaitContent.Visible = false;
                lblTranOSCount.Text = $"表示ログ件数：{LsvLogContent.Items.Count:#,###} 件";
                LsvLogContent.Items[0].UseItemStyleForSubItems = false;
                LsvLogContent.Select();
                LsvLogContent.Items[0].EnsureVisible();
                // OK抽出グループの有効化
                GrpOkExtract.Enabled = true;

                // エラー履歴ログファイルのフルパス名を生成する
                string[] sAry = sReadLogFile.Split('\\');
                sAry[sAry.Length - 3] = PubConstClass.LOG_TYPE_ERROR_LOG;
                sReadLogFile = "";
                int iIndex = 0;
                foreach (var item in sAry)
                {
                    if (iIndex == sAry.Length - 1)
                    {
                        sReadLogFile += item;
                    }
                    else
                    {
                        sReadLogFile += item + "\\";
                    }
                    iIndex++;
                }
                // エラー履歴ログ内容表示処理
                DisplayErrorCntent(sReadLogFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【LsvLogList_SelectedIndexChanged】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// エラー履歴ログ内容表示処理
        /// </summary>
        /// <param name="sReadLogFile"></param>
        private void DisplayErrorCntent(string sReadLogFile)
        {
            string sData;
            int iCounter;

            try
            {
                if (!File.Exists(sReadLogFile))
                {
                    SetEnableControl(true);
                    PicWaitContent.Visible = false;
                    lblTranOSNGCount.Text = "表示ログ件数：0 件";
                    //MessageBox.Show($"エラー履歴ファイル（{sReadLogFile}）は存在しません", "確認", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string[] col = new string[5];
                    ListViewItem itm;
                    // 日時
                    col[0] = "           --";
                    // 読取番号（表裏）
                    col[1] = "エラー履歴は存在しません";
                    // 読取結果（表裏）
                    col[2] = "--";
                    // 表裏一致判定
                    col[3] = "--";
                    // 連番判定
                    col[4] = "--";
                    // データの表示
                    itm = new ListViewItem(col);
                    LsvLogErrorContent.Items.Add(itm);
                    for (int N = 0; N < 5; N++)
                    {
                        // 奇数行の色反転
                        LsvLogErrorContent.Items[0].SubItems[N].BackColor = Color.FromArgb(200, 200, 230);
                    }
                    // NG抽出グループの無効化
                    GrpNgExtract.Enabled = false;
                }
                else
                {
                    // エラー履歴ログファイルが存在する
                    iCounter = 0;
                    using (StreamReader sr = new StreamReader(sReadLogFile, Encoding.Default))
                    {
                        while (!sr.EndOfStream)
                        {
                            sData = sr.ReadLine();
                            DisplayOneData(LsvLogErrorContent, sData);
                            iCounter++;
                        }
                    }
                    SetEnableControl(true);
                    PicWaitContent.Visible = false;
                    lblTranOSNGCount.Text = $"表示ログ件数：{LsvLogErrorContent.Items.Count:#,###} 件";
                    LsvLogErrorContent.Items[0].UseItemStyleForSubItems = false;
                    LsvLogErrorContent.Select();
                    LsvLogErrorContent.Items[0].EnsureVisible();
                    // NG抽出グループの有効化
                    GrpNgExtract.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【DisplayErrorContent】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「抽出」ボタン処理（検査履歴）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOkExtraction_Click(object sender, EventArgs e)
        {
            string sData;
            List<string> lstResult = new List<string>();

            string[] sAray;

            try
            {
                if (CmbOkJudgement.Text == "全て")
                {
                    if (TxtOkQrNumber.Text.Trim() == "")
                    {
                        #region 全て抽出でQR読取番号の条件が無し
                        LsvLogContent.Visible = true;
                        LsvLogExtract.Visible = false;
                        return;
                        #endregion
                    }
                    else
                    {
                        #region 全て抽出でQR読取番号の条件が有る
                        int iIndex = CmbOkCondition.SelectedIndex + 2;
                        lstResult.Clear();
                        foreach (ListViewItem item in LsvLogContent.Items)
                        {
                            if (item.SubItems[1].Text.Contains(TxtOkQrNumber.Text.Trim()))
                            {
                                lstResult.Add(item.SubItems[0].Text + "," +
                                                item.SubItems[1].Text + "," +
                                                item.SubItems[2].Text + "," +
                                                item.SubItems[3].Text + "," +
                                                item.SubItems[4].Text);
                            }
                        }
                        #endregion
                    }
                }
                else
                {
                    int iIndex = CmbOkCondition.SelectedIndex + 2;
                    lstResult.Clear();
                    foreach (ListViewItem item in LsvLogContent.Items)
                    {
                        sData = item.SubItems[iIndex].Text;
                        if (sData.Contains(CmbOkJudgement.Text))
                        {
                            // 判定結果が一致する場合
                            if (TxtOkQrNumber.Text.Trim() == "")
                            {
                                #region QR読取番号の条件が無し
                                lstResult.Add(item.SubItems[0].Text + "," +
                                                item.SubItems[1].Text + "," +
                                                item.SubItems[2].Text + "," +
                                                item.SubItems[3].Text + "," +
                                                item.SubItems[4].Text);
                                #endregion
                            }
                            else
                            {
                                #region QR読取番号の条件が有る
                                if (item.SubItems[1].Text.Contains(TxtOkQrNumber.Text.Trim()))
                                {
                                    lstResult.Add(item.SubItems[0].Text + "," +
                                                    item.SubItems[1].Text + "," +
                                                    item.SubItems[2].Text + "," +
                                                    item.SubItems[3].Text + "," +
                                                    item.SubItems[4].Text);
                                }
                                #endregion
                            }
                        }
                    }
                }

                LsvLogExtract.Items.Clear();
                foreach (var item in lstResult)
                {
                    DisplayOneDataForResult(LsvLogExtract, item);
                }

                LsvLogContent.Visible = false;
                LsvLogExtract.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnOkExtraction_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「抽出」ボタン処理（エラー履歴）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNgExtraction_Click(object sender, EventArgs e)
        {
            string sData;
            List<string> lstResult = new List<string>();

            try
            {
                if (CmbNgJudgement.Text == "全て")
                {
                    if (TxtNgQrNumber.Text.Trim() == "")
                    {
                        #region 全て抽出でQR読取番号の条件が無し
                        LsvLogErrorContent.Visible = true;
                        LsvLogErrorExtract.Visible = false;
                        return;
                        #endregion
                    }
                    else
                    {
                        #region 全て抽出でQR読取番号の条件が有る
                        int iIndex = CmbNgCondition.SelectedIndex + 2;
                        lstResult.Clear();
                        foreach (ListViewItem item in LsvLogErrorContent.Items)
                        {
                            if (item.SubItems[1].Text.Contains(TxtNgQrNumber.Text.Trim()))
                            {
                                lstResult.Add(item.SubItems[0].Text + "," +
                                              item.SubItems[1].Text + "," +
                                              item.SubItems[2].Text + "," +
                                              item.SubItems[3].Text + "," +
                                              item.SubItems[4].Text);
                            }
                        }
                        #endregion
                    }
                }
                else
                {
                    int iIndex = CmbNgCondition.SelectedIndex + 2;
                    lstResult.Clear();
                    foreach (ListViewItem item in LsvLogErrorContent.Items)
                    {
                        sData = item.SubItems[iIndex].Text;
                        if (sData.Contains(CmbNgJudgement.Text))
                        {
                            // 判定結果が一致する場合
                            if (TxtNgQrNumber.Text.Trim() == "")
                            {
                                #region QR読取番号の条件が無し
                                lstResult.Add(item.SubItems[0].Text + "," +
                                              item.SubItems[1].Text + "," +
                                              item.SubItems[2].Text + "," +
                                              item.SubItems[3].Text + "," +
                                              item.SubItems[4].Text);
                                #endregion
                            }
                            else
                            {
                                #region QR読取番号の条件が有る
                                if (item.SubItems[1].Text.Contains(TxtNgQrNumber.Text.Trim()))
                                {
                                    lstResult.Add(item.SubItems[0].Text + "," +
                                                  item.SubItems[1].Text + "," +
                                                  item.SubItems[2].Text + "," +
                                                  item.SubItems[3].Text + "," +
                                                  item.SubItems[4].Text);
                                }
                                #endregion
                            }
                        }
                    }
                }

                LsvLogErrorExtract.Items.Clear();
                foreach (var item in lstResult)
                {
                    DisplayOneDataForResult(LsvLogErrorExtract, item);
                }

                LsvLogErrorContent.Visible = false;
                LsvLogErrorExtract.Visible = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnNgExtraction_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 抽出結果用の検査ログデータの１行分の表示
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="sData"></param>
        private void DisplayOneDataForResult(System.Windows.Forms.ListView listView, string sData)
        {
            try
            {
                PicWaitContent.Refresh();
                string[] sArray = sData.Split(',');
                string[] col = new string[5];
                ListViewItem itm;
                // 日時
                col[0] = sArray[0];
                // 読取番号（表裏）
                col[1] = sArray[1];
                // 読取結果（表裏）
                col[2] = sArray[2];
                // 表裏一致判定
                col[3] = sArray[3];
                // 連番判定
                col[4] = sArray[4];
                // データの表示
                itm = new ListViewItem(col);
                listView.Items.Add(itm);
                if (listView.Items.Count % 2 == 1)
                {
                    for (int iIndex = 0; iIndex < 5; iIndex++)
                    {
                        // 奇数行の色反転
                        listView.Items[listView.Items.Count - 1].SubItems[iIndex].BackColor = Color.FromArgb(200, 200, 230);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【DisplayOneDataForResult】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
