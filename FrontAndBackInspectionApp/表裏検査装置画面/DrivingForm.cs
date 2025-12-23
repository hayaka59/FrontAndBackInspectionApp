using Kinoshita.Lib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FrontAndBackInspectionApp.ClassEquipment;

namespace FrontAndBackInspectionApp.表裏検査装置画面
{
    public partial class DrivingForm : Form
    {
        private readonly string _broadDivision;     // 大区分の名称
        private readonly string _subDivision;       // 小区分の名称
        private readonly string _inspectionLogName; // 検査ログファイル名

        private int iStatus;                        // 検査中ステータス
        private int iOkCount;                       // OKカウンタ
        private int iNgCount;                       // NGカウンタ
        private int iMatchingErrorCount;            // 表裏NGカウンタ
        private int iSeqNumErrorCount;              // 連番NGカウンタ

        private const int DEF_STATUS_STOP  = 0;     // 停止中
        private const int DEF_STATUS_RUN   = 1;     // 検査中
        private const int DEF_STATUS_ERROR = 2;     // エラー

        /// <summary>
        /// 
        /// </summary>
        /// <param name="broadDivision"></param>
        /// <param name="subDivision"></param>
        /// <param name="inspectionLogName"></param>
        public DrivingForm(string broadDivision, string subDivision, string inspectionLogName)
        {
            InitializeComponent();

            _broadDivision = broadDivision;
            _subDivision = subDivision;
            _inspectionLogName = inspectionLogName;
        }

        /// <summary>
        /// フォームロード処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrivingForm_Load(object sender, EventArgs e)
        {
            try
            {
                LblTitle.Text = "表裏検査装置　検査画面";
                LblVersion.Text = PubConstClass.DEF_VERSION;

                // ロゴ表示
                PctLogo.Visible = PubConstClass.pblLogoDisp == "1";

                // 現在時刻表示タイマー設定
                TimDateTime.Interval = 1000;
                TimDateTime.Enabled = true;

                // カウンタ初期化
                LblOKCount.Text = "0";
                LblNGCount.Text = "0";
                LblMatchingErrorCount.Text = "0";
                LblSeqNumErrorCount.Text = "0";
                iOkCount = 0;
                iNgCount = 0;
                iMatchingErrorCount = 0;
                iSeqNumErrorCount = 0;

                LblBroadDivision.Text= _broadDivision;  // 大区分の名称
                LblSubDivision.Text= _subDivision;      // 小区分の名称

                #region 検査履歴のヘッダー設定
                //LstReadData.View = View.Details;
                ColumnHeader colOK1 = new ColumnHeader();
                ColumnHeader colOK2 = new ColumnHeader();
                ColumnHeader colOK3 = new ColumnHeader();
                ColumnHeader colOK4 = new ColumnHeader();
                ColumnHeader colOK5 = new ColumnHeader();
                SetHeaderData(LstReadData, colOK1, colOK2, colOK3, colOK4, colOK5);
                #endregion

                #region エラー履歴のヘッダー設定
                //LstError.View = View.Details;
                ColumnHeader colNG1 = new ColumnHeader();
                ColumnHeader colNG2 = new ColumnHeader();
                ColumnHeader colNG3 = new ColumnHeader();
                ColumnHeader colNG4 = new ColumnHeader();
                ColumnHeader colNG5 = new ColumnHeader();
                SetHeaderData(LstError, colNG1, colNG2, colNG3, colNG4, colNG5);
                #endregion

                lblTranOSCount.Text = "0 件";
                lblTranOSNGCount.Text = "0 件";

                // リストビューのダブルバッファを有効とする
                EnableDoubleBuffering(LstReadData);
                EnableDoubleBuffering(LstError);

                // 選択ジョブ項目を取得し表示
                CommonModule.GetSelectJobItem(TxtJobName, LtbJobDataInfo);
                LblSetteiInfo.Text = $"設定データ：{PubConstClass.sJobSettingData}";

                // 選択JOB検査内容表示リストビューの設定
                LtbJobDataInfo.DrawMode = DrawMode.OwnerDrawFixed;
                LtbJobDataInfo.DrawItem += LtbJobDataInfo_DrawItem;
                
                // 全数ログフォルダのチェックと作成
                string folderPath = Path.Combine(PubConstClass.pblLogFolder, PubConstClass.LOG_TYPE_FULL_LOG);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                    Log.OutPutLogFile(TraceEventType.Information, $"【DrivingForm】フォルダを作成しました：{folderPath}");
                }
                // 検査ログフォルダのチェックと作成
                folderPath = Path.Combine(PubConstClass.pblLogFolder, PubConstClass.LOG_TYPE_INSPECTION_LOG);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                    Log.OutPutLogFile(TraceEventType.Information, $"【DrivingForm】フォルダを作成しました：{folderPath}");
                }
                // エラー履歴ログフォルダのチェックと作成
                folderPath = Path.Combine(PubConstClass.pblLogFolder, PubConstClass.LOG_TYPE_ERROR_LOG);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                    Log.OutPutLogFile(TraceEventType.Information, $"【DrivingForm】フォルダを作成しました：{folderPath}");
                }

                ClassGlobalVariables.IsInspect = true;
                // 装置からのコマンドデータ受信イベントハンドラーの登録
                ClassEquipment.CommandDataReceiveEvent += new EventHandler<EquipmentCommandDataReceiveEventArgs>(EquipmentCommandDataReceiveEvent);

                SetStatus(DEF_STATUS_STOP); // 停止中ステータスへ変更

                // 設定データの送信
                ClassEquipment.SendCommandData(PubConstClass.sJobSettingData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【DrivingForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ヘッダータイトルの作成
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
                col4.Text = "表裏一致判定";
                col5.Text = "連番判定";

                col1.TextAlign = HorizontalAlignment.Center;
                col2.TextAlign = HorizontalAlignment.Center;
                col3.TextAlign = HorizontalAlignment.Center;
                col4.TextAlign = HorizontalAlignment.Center;
                col5.TextAlign = HorizontalAlignment.Center;
                
                col1.Width = 200;         // 日時
                col2.Width = 250;         // 読取番号（表裏）
                col3.Width = 160;         // 読取結果（表裏）
                col4.Width = 120;         // 表裏一致判定
                col5.Width = 100;         // 連続判定
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

        /// <summary>www
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
        /// 「検査開始」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRun_Click(object sender, EventArgs e)
        {
            try
            {
                // シリアルデータ送信
                ClassEquipment.SendCommandData(PubConstClass.CMD_SEND_Zb);

                SetStatus(DEF_STATUS_RUN); // 検査中ステータスへ変更
                BtnStop.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnRun_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「停止」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStop_Click(object sender, EventArgs e)
        {
            try
            {
                // シリアルデータ送信
                ClassEquipment.SendCommandData(PubConstClass.CMD_SEND_Zc);

                SetStatus(DEF_STATUS_STOP); // 停止中ステータスへ変更
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnStop_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 現在時刻表示タイマー処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimDateTime_Tick(object sender, EventArgs e)
        {
            try
            {
                // 現在時刻の表示
                LblDateTime.Text = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH:mm:ss");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【TimDateTime_Tick】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// カウンタをクリアする処理
        /// </summary>
        /// <param name="label"></param>
        /// <param name="sMessage"></param>
        private void ClearCounter(System.Windows.Forms.Label label, string sMessage)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show($"{sMessage}をクリアしますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    label.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【ClearCounter】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「クリア」ボタン処理（OKカウンタ）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOKClear_Click(object sender, EventArgs e)
        {
            ClearCounter(LblOKCount, "「OKカウンタ」");
        }

        /// <summary>
        /// 「クリア」ボタン処理（NGカウンタ）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNGClear_Click(object sender, EventArgs e)
        {
            ClearCounter(LblNGCount, "「NGカウンタ」");
        }

        /// <summary>
        /// 「クリア」ボタン処理（表裏NGカウンタ）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMatchingErrorClear_Click(object sender, EventArgs e)
        {
            ClearCounter(LblMatchingErrorCount, "「表裏NGカウンタ」");
        }

        /// <summary>
        /// 「クリア」ボタン処理（連番NGカウンタ）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSeqNumErrorClear_Click(object sender, EventArgs e)
        {
            ClearCounter(LblSeqNumErrorCount, "「連番NGカウンタ」");
        }

        /// <summary>
        /// 「一斉クリア」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAllClear_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("全てのカウンタをクリアしますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    LblOKCount.Text = "0";
                    LblNGCount.Text = "0";
                    LblMatchingErrorCount.Text = "0";
                    LblSeqNumErrorCount.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnAllClear_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ステータス表示
        /// </summary>
        /// <param name="status"></param>
        private void SetStatus(int status)
        {
            try
            {
                iStatus = status;

                switch (status)
                {
                    case DEF_STATUS_STOP:
                        LblStatus.Text = "停止中";
                        LblStatus.BackColor = Color.LightGray;
                        LblStatus.ForeColor = Color.Black;
                        SetControlEnable(true);
                        break;

                    case DEF_STATUS_RUN:
                        LblStatus.Text = "検査中";
                        LblStatus.BackColor = Color.LightGreen;
                        LblStatus.ForeColor = Color.Black;
                        SetControlEnable(false);
                        break;

                    case DEF_STATUS_ERROR:
                        LblStatus.Text = "エラー";
                        LblStatus.BackColor = Color.OrangeRed;
                        LblStatus.ForeColor = Color.White;
                        break;

                    case 3:
                        LblStatus.Text = "手動登録中";
                        LblStatus.BackColor = Color.Orange;
                        LblStatus.ForeColor = Color.White;
                        break;

                    default:
                        LblStatus.Text = "停止中";
                        LblStatus.BackColor = Color.LightGray;
                        LblStatus.ForeColor = Color.Black;
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【SetStatus】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// コントロールの有効/無効設定
        /// </summary>
        /// <param name="bEnable"></param>
        private void SetControlEnable(bool bEnable)
        {
            try
            {
                BtnRun.Enabled = bEnable;
                BtnStop.Enabled = bEnable;
                BtnBack.Enabled = bEnable;

                BtnOKClear.Enabled = bEnable;
                BtnNGClear.Enabled = bEnable;
                BtnMatchingErrorClear.Enabled = bEnable;
                BtnSeqNumErrorClear.Enabled = bEnable;
                BtnAllClear.Enabled = bEnable;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【SetControlEnable】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 装置からのコマンド受信イベント処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void EquipmentCommandDataReceiveEvent(Object sender, EquipmentCommandDataReceiveEventArgs e)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    Invoke(new Action(delegate
                    {
                        string sMessage = e.ReceiveData;
                        CommandReceiveProcessing(sMessage);
                    }));
                    return;
                }
                catch (Exception ex)
                {
                    Log.OutPutLogFile(TraceEventType.Error, "■装置からのコマンドデータ受信エラー：{0}", ex.StackTrace);
                }
            }
        }

        /// <summary>
        /// コマンド受信処理
        /// </summary>
        /// <param name="sData"></param>
        private void CommandReceiveProcessing(string sData)
        {
            try
            {
                // 先頭文字切り出し
                string s = sData.Substring(0, 1);
                switch (s)
                {
                    case PubConstClass.CMD_RECIEVE_A:
                        #region JOB設定内容要求コマンド受信処理
                        // 設定データの送信
                        ClassEquipment.SendCommandData(PubConstClass.sJobSettingData);
                        break;
                    #endregion

                    case PubConstClass.CMD_RECIEVE_B:
                        #region 動作開始要求コマンド受信処理
                        SetStatus(DEF_STATUS_RUN);  // 検査中ステータスへ変更
                        BtnStop.Enabled = true;     // 「停止」ボタン有効化
                        // エラーメッセージ非表示
                        LblErrorMessage.Visible = false;
                        LblErrorContent.Visible = false;
                        break;
                    #endregion

                    case PubConstClass.CMD_RECIEVE_C:
                        #region 停止要求コマンド受信処理
                        SetStatus(DEF_STATUS_STOP);   // 停止中ステータスへ変更
                        break;
                    #endregion

                    case PubConstClass.CMD_RECIEVE_D:
                        #region 照合結果データ受信処理
                        MatchingResultDataReceptionProcessing(sData);
                        break;
                    #endregion

                    case PubConstClass.CMD_RECIEVE_E:
                        #region エラーデータ受信処理
                        MyProcError(sData);
                        break;
                    #endregion

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.OutPutLogFile(TraceEventType.Error, "エラー【CommandReceiveProcessing】:" + ex.Message);
                //MessageBox.Show(ex.Message, "エラー【CommandReceiveProcessing】", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 照合結果データ受信・判定・表示処理
        /// </summary>
        /// <param name="sData"></param>
        private void MatchingResultDataReceptionProcessing(string sData)
        {
            string[] sAry;

            try
            {
                sAry = sData.Split(',');

                // 全数ログの書き込み処理
                SaveHistoryLog(PubConstClass.LOG_TYPE_FULL_LOG, sAry[1], sAry[2], sAry[3], sAry[4], sAry[5], sAry[6]);

                // 表裏マッチング結果／表側読取結果／裏側読取結果／連番検査結果
                if (sAry[3] == "0" && sAry[4] == "0" && sAry[5] == "0" && (sAry[6] == "0" || sAry[6] == "3"))
                {
                    // 検査履歴（OK履歴）
                    DisplayOKayHistory(sAry[1], sAry[2], sAry[3], sAry[4], sAry[5], sAry[6]);
                    SaveHistoryLog(PubConstClass.LOG_TYPE_INSPECTION_LOG, sAry[1], sAry[2], sAry[3], sAry[4], sAry[5], sAry[6]);
                }
                else
                {
                    // エラー履歴
                    DisplayErrorHistory(sAry[1], sAry[2], sAry[3], sAry[4], sAry[5], sAry[6]);
                    SaveHistoryLog(PubConstClass.LOG_TYPE_ERROR_LOG, sAry[1], sAry[2], sAry[3], sAry[4], sAry[5], sAry[6]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー【MatchingResultDataReceptionProcessing】", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 履歴ログ（全数／検査（OK）ログ／エラーログ）の格納処理
        /// </summary>
        /// <param name="sLogType"></param>
        /// <param name="sData1"></param>
        /// <param name="sData2"></param>
        /// <param name="sData3"></param>
        /// <param name="sData4"></param>
        private void SaveHistoryLog(string sLogType, string sData1, string sData2, string sData3, string sData4, string sData5, string sData6)
        {
            string sData = "";
            string sFolderPath;
            string sFileName;

            try
            {
                sData += DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + ",";
                sData += $"{sData1},{sData2},{sData3},{sData4},{sData5},{sData6}";

                sFolderPath = Path.Combine(PubConstClass.pblLogFolder, sLogType);
                sFolderPath = Path.Combine(sFolderPath, DateTime.Now.ToString("yyyyMMdd"));
                if (!Directory.Exists(sFolderPath))
                {
                    Directory.CreateDirectory(sFolderPath);
                    Log.OutPutLogFile(TraceEventType.Information, $"【{sLogType}】フォルダを作成しました：{sFolderPath}");
                }
                sFileName = Path.Combine(sFolderPath, _inspectionLogName);

                // 全数ログ書込処理
                using (StreamWriter sw = new StreamWriter(sFileName, true, Encoding.Default))
                {
                    // データを追加モードで書き込む
                    sw.WriteLine(sData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー【SaveHistoryLog】", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 検査履歴ログの表示
        /// </summary>
        /// <param name="sData1"></param>
        /// <param name="sData2"></param>
        /// <param name="sData3"></param>
        /// <param name="sData4"></param>
        private void DisplayOKayHistory(string sData1, string sData2, string sData3, string sData4, string sData5, string sData6)
        {
            string[] col = new string[5];

            try
            {
                ListViewItem itm1;

                // 日時
                col[0] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                // 読取番号（表裏）
                col[1] = $"{sData1} / {sData2}";
                // 読取結果（表裏）
                col[2] = CommonModule.ConversionReadingResults($"{sData3}/{sData4}");
                // 表裏一致判定
                col[3] = CommonModule.ConversionMatchingResults(sData5);
                // 連番判定
                col[4] = CommonModule.ConversionSequentialResults(sData6);

                itm1 = new ListViewItem(col);
                LstReadData.Items.Add(itm1);
                LstReadData.Items[LstReadData.Items.Count - 1].UseItemStyleForSubItems = false;
                LstReadData.Select();
                LstReadData.Items[LstReadData.Items.Count - 1].EnsureVisible();

                if (LstReadData.Items.Count % 2 == 1)
                {
                    for (int iIndex = 0; iIndex < 5; iIndex++)
                    {
                        // 奇数行の色反転
                        LstReadData.Items[LstReadData.Items.Count - 1].SubItems[iIndex].BackColor = Color.FromArgb(200, 200, 230);
                    }
                }
                lblTranOSCount.Text = LstReadData.Items.Count.ToString() + " 件";
            
                iOkCount++;
                LblOKCount.Text = iOkCount.ToString("#,###,##0");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー【DisplayOKayHistory】", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// エラー履歴ログの表示処理
        /// </summary>
        /// <param name="sData1"></param>
        /// <param name="sData2"></param>
        /// <param name="sData3"></param>
        /// <param name="sData4"></param>
        private void DisplayErrorHistory(string sData1, string sData2, string sData3, string sData4, string sData5, string sData6)
        {
            string[] col = new string[5];

            try
            {                
                ListViewItem itm1;

                // 日時
                col[0] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                // 読取番号（表裏）
                col[1] = $"{sData1} / {sData2}";
                // 読取結果（表裏）
                col[2] = CommonModule.ConversionReadingResults($"{sData3}/{sData4}");
                // 表裏一致判定
                col[3] = CommonModule.ConversionMatchingResults(sData5);
                // 連番判定
                col[4] = CommonModule.ConversionSequentialResults(sData6);

                itm1 = new ListViewItem(col);
                LstError.Items.Add(itm1);
                LstError.Items[LstError.Items.Count - 1].UseItemStyleForSubItems = false;
                LstError.Select();
                LstError.Items[LstError.Items.Count - 1].EnsureVisible();

                if (LstError.Items.Count % 2 == 1)
                {
                    for (int iIndex = 0; iIndex < 5; iIndex++)
                    {
                        // 奇数行の色反転
                        LstError.Items[LstError.Items.Count - 1].SubItems[iIndex].BackColor = Color.FromArgb(200, 200, 230);
                    }
                }
                lblTranOSNGCount.Text = LstError.Items.Count.ToString() + " 件";
                // NGカウンタ加算
                iNgCount++;
                if (sData3 == "1")
                {
                    // 表裏NGカウンタ加算
                    iMatchingErrorCount++;
                }
                if(sData4 == "1")
                {
                    // 連番NGカウンタ加算
                    iSeqNumErrorCount++;
                }
                LblNGCount.Text = iNgCount.ToString("#,###,##0");
                LblMatchingErrorCount.Text = iMatchingErrorCount.ToString("#,###,##0");
                LblSeqNumErrorCount.Text = iSeqNumErrorCount.ToString("#,###,##0");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "エラー【DisplayErrorHistory】", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void LblVersion_DoubleClick(object sender, EventArgs e)
        {
            LblSetteiInfo.Visible = !LblSetteiInfo.Visible;
        }


        /// <summary>
        /// エラーコマンド処理
        /// </summary>
        /// <param name="sData"></param>
        private void MyProcError(string sData)
        {
            string sErrorCode;
            string sSaveFileName = "";
            string sErrorData;

            try
            {
                LblErrorMessage.Text = $"エラーコマンド「Z{sData}<CR>」受信";
                LblErrorMessage.Visible = true;

                SetStatus(DEF_STATUS_ERROR);   // エラーステータスへ変更

                sErrorCode = sData.Substring(2, 3);

                //if (sErrorCode == "005" || sErrorCode == "013" || sErrorCode == "050")
                if (sErrorCode == "003")
                {
                    // 停止中（005：用紙終了／013：セットカウントエラー／050：リジェクト停止）
                    PubConstClass.bIsErrorMessage = false;
                }
                else
                {
                    // エラー
                    PubConstClass.bIsErrorMessage = true;
                }

                ErrorMessageForm form = ErrorMessageForm.GetInstance();

                sErrorData = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + ",";
                sErrorData += sErrorCode + ",";
                if (PubConstClass.dicErrorCodeData.ContainsKey(sErrorCode))
                {
                    // 存在する場合
                    form.SetMessage($"{sErrorCode},{PubConstClass.dicErrorCodeData[sErrorCode]}");
                    Log.OutPutLogFile(TraceEventType.Information, $"エラー内容：{sErrorCode},{PubConstClass.dicErrorCodeData[sErrorCode]}");
                    sErrorData += PubConstClass.dicErrorCodeData[sErrorCode];
                }
                else
                {
                    form.SetMessage($"{sErrorCode},未定義エラー番号,未定義のエラー番号です。");
                    Log.OutPutLogFile(TraceEventType.Information, $"エラー内容：{sErrorCode},未定義エラー番号,未定義のエラー番号です。");
                    sErrorData += "未定義エラー番号,未定義のエラー番号です。";
                }
                LblErrorContent.Text = sErrorData;
                LblErrorContent.Visible = true;

                string sFolder = CommonModule.IncludeTrailingPathDelimiter(PubConstClass.pblLogFolder);
                sFolder += CommonModule.IncludeTrailingPathDelimiter("エラーログ") + DateTime.Now.ToString("yyyyMMdd");
                if (!Directory.Exists(sFolder))
                {
                    Directory.CreateDirectory(sFolder);
                    Log.OutPutLogFile(TraceEventType.Information, $"エラーフォルダを作成しました：{sFolder}");
                }

                // エラーファイル名の生成
                sSaveFileName += CommonModule.IncludeTrailingPathDelimiter(sFolder);
                sSaveFileName += $"エラーログ_{DateTime.Now:yyyyMMdd}.csv";

                // エラーデータ書込処理
                using (StreamWriter sw = new StreamWriter(sSaveFileName, true, Encoding.Default))
                {
                    // エラーデータを追加モードで書き込む
                    sw.WriteLine(sErrorData);
                }
                // エラーメッセージウィンドウ表示設定の場合
                if (PubConstClass.pblErrorWindow == "1")
                {
                    if (!PubConstClass.bIsOpenErrorMessage)
                    {
                        PubConstClass.bIsOpenErrorMessage = true;
                        // エラーダイアログ表示
                        form.ShowDialog();
                    }
                    else
                    {
                        form.Show();
                    }
                }
                else
                {
                    //Log.OutPutLogFile(TraceEventType.Information, $"【デバッグ】エラーメッセージウィンドウ非表示【{sErrorData}】");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【MyProcError】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
