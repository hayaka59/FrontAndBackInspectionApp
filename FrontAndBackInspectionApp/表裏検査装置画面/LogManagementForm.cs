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

                CmbJudgement.Items.Clear();
                CmbJudgement.Items.Add("全て");
                CmbJudgement.Items.Add("NG");
                CmbJudgement.Items.Add("RE");
                CmbJudgement.Items.Add("SE");
                CmbJudgement.SelectedIndex = 0;

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
                col1.Width = 600;         // 検査ログファイル名
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

                lblTranOSCount.Text = "0 件";
                lblTranOSNGCount.Text = "0 件";

                // リストビューのダブルバッファを有効とする
                EnableDoubleBuffering(LsvLogContent);
                EnableDoubleBuffering(LsvLogErrorContent);
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
        private void SetHeaderData(ListView listView, ColumnHeader col1, ColumnHeader col2, ColumnHeader col3, ColumnHeader col4, ColumnHeader col5)
        {
            try
            {
                listView.View = View.Details;

                col1.Text = "　　　日時";
                col2.Text = "読取番号（表裏）";
                col3.Text = "読取結果（表裏）";
                col4.Text = "裏表一致判定";
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
            string sTitle = "デバッグ用";

            try
            {
                // ログファイル一覧格納リストのクリア
                lstLogFileList.Clear();
                // 検査ログ一覧のクリア
                LsvLogList.Items.Clear();
                // 検査ログの内容のクリア
                LsvLogContent.Items.Clear();

                //string[] sAryFileName;
                //string sFileNameForFilter;
             
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
                        if (!(int.Parse(DtTimePickerFrom.Value.ToString("yyyyMMdd")) <= int.Parse(sArrayDate[sArrayDate.Length - 1].Substring(0, 8)) &
                            int.Parse(DtTimePickerTo.Value.ToString("yyyyMMdd")) >= int.Parse(sArrayDate[sArrayDate.Length - 1].Substring(0, 8))))
                        {
                            // 該当しないので対象ファイルから外す
                            sFileName = "";
                            sFileNameFullPath = "";
                        }
                    }

                    if (sFileName != "")
                    {
                        string sPathName;

                        // JOB名でのフィルタ無しでOKログ
                        //sPathName = sArray[0] + "¥" + sArray[1] + "¥" + sArray[2] + "¥" + sArray[4] + "¥" + sArray[5];
                        sPathName = sArray[0] + "¥" + sArray[1] + "¥" + sArray[2] + "¥" + sArray[4];

                        // 件数の取得
                        string[] Lines = File.ReadAllLines(sTranFile);
                        // 検査ログファイル一覧格納リストに追加
                        lstLogFileList.Add(sTranFile);

                        string[] col = new string[3];
                        ListViewItem itm;
                        col[0] = sArray[sArray.Length - 1];     // ファイル名
                        col[1] = $"{Lines.Length - 1}件";       // 件数
                        col[2] = sPathName;                     // 格納フォルダ

                        // データの表示
                        itm = new ListViewItem(col);
                        LsvLogList.Items.Add(itm);
                        LsvLogList.Items[0].UseItemStyleForSubItems = false;
                        LsvLogList.Select();
                        LsvLogList.Items[0].EnsureVisible();
                    }
                }

                //if (sArrayJob[0] == "")
                //{
                //    sArrayJob[0] = "指定なし";
                //}                
                LblLogFileCount.Text = $"{sTitle}{LsvLogList.Items.Count:#,###} 件";
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
        private void DisplayOneData(string sData)
        {
            // ●（01）日付
            // ●（02）時刻
            // 　（03）期待値
            // ●（04）読取値
            // ●（05）判定

            try
            {
                PicWaitContent.Refresh();
                //Application.DoEvents();
                string[] sArray = sData.Split(',');
                // "日付","期待値","読取値","判定","正解データファイル名","重量期待値[g]","重量測定値[g]","重量公差","フラップ最大長[mm]","フラップ積算長[mm]","フラップ検出回数[回]","イベント（コメント）","受領日","作業員情報（機械情報）","物件情報（DPS/BPO/Broad等）","エラーコード","生産管理番号","仕分けコード１","仕分けコード２","ファイル名（画像）","ファイルパス（画像）","工場コード",
                string[] col = new string[11];
                ListViewItem itm;
                col[0] = sArray[0].Substring(0, sArray[0].Length);      // 
                col[1] = sArray[1].Substring(0, sArray[1].Length);      // 
                col[2] = sArray[2].Substring(0, sArray[2].Length);      // 
                col[3] = sArray[3].Substring(0, sArray[3].Length);      // 
                col[4] = sArray[4].Substring(0, sArray[4].Length);      // 

                //col[5] = sArray[13].Substring(1, sArray[13].Length - 2);    // 受領日
                //col[6] = sArray[14].Substring(1, sArray[14].Length - 2);    // 作業員情報
                //col[7] = sArray[15].Substring(1, sArray[15].Length - 2);    // 物件情報
                //col[8] = sArray[16].Substring(1, sArray[16].Length - 2);    // エラーCD
                //col[9] = sArray[18].Substring(1, sArray[18].Length - 2);    // 仕分①
                //col[10] = sArray[19].Substring(1, sArray[19].Length - 2);   // 仕分②

                // データの表示
                itm = new ListViewItem(col);
                LsvLogContent.Items.Add(itm);
                LsvLogContent.Items[LsvLogContent.Items.Count - 1].UseItemStyleForSubItems = false;
                LsvLogContent.Select();
                LsvLogContent.Items[LsvLogContent.Items.Count - 1].EnsureVisible();

                if (LsvLogContent.Items.Count % 2 == 1)
                {
                    for (int iIndex = 0; iIndex < 11; iIndex++)
                    {
                        // 奇数行の色反転
                        LsvLogContent.Items[LsvLogContent.Items.Count - 1].SubItems[iIndex].BackColor = Color.FromArgb(200, 200, 230);
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

                sReadLogFile = lstLogFileList[LsvLogList.SelectedItems[0].Index];

                SetEnableControl(false);
                PicWaitContent.Visible = true;
                iCounter = 0;
                //PubConstClass.lstJobEntryList.Clear();
                using (StreamReader sr = new StreamReader(sReadLogFile, Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        //PicWaitContent.Refresh();
                        sData = sr.ReadLine();
                        if (iCounter > 0)
                        {
                            DisplayOneData(sData);
                        }
                        else
                        {
                            //CommonModule.OutPutLogFile($"ヘッダー情報をスキップ：{sData}");
                            //CommonModule.OutPutLogFile("ヘッダー情報をスキップ");
                        }
                        iCounter++;
                    }
                }
                SetEnableControl(true);
                PicWaitContent.Visible = false;
                lblTranOSCount.Text = $"表示ログ件数：{LsvLogContent.Items.Count:#,###} 件";

                LsvLogContent.Items[0].UseItemStyleForSubItems = false;
                LsvLogContent.Select();
                LsvLogContent.Items[0].EnsureVisible();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【LsvLogList_SelectedIndexChanged】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}
