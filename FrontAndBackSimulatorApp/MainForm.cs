using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontAndBackSimulatorApp
{
    public partial class MainForm : Form
    {
        private delegate void Delegate_RcvDataToTextBox(string data);

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                // バージョン表示
                LblVersion.Text = PubConstClass.DEF_VERSION;
                PubConstClass.objSyncHist = new object();
                CommonModule.OutPutLogFile("〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓");
                CommonModule.OutPutLogFile("【" + "シミュレータ" + "】を起動しました。");
                CommonModule.OutPutLogFile("■シミュレータ★バージョン「" + PubConstClass.DEF_VERSION + "」");

                CommonModule.ReadSystemDefinition();
                
                String sTitle = "";
                #region シリアルポートの設定
                // データ受信イベントの設定
                SerialPortQr.DataReceived += new SerialDataReceivedEventHandler(SerialPortQr_DataReceived);
                // シリアルポート名の設定
                SerialPortQr.PortName = PubConstClass.pblComPort;
                sTitle += PubConstClass.pblComPort + "／";
                // シリアルポートの通信速度指定
                switch (PubConstClass.pblComSpeed)
                {
                    case "0":
                        {
                            SerialPortQr.BaudRate = 4800;
                            sTitle += "4800bps／";
                            break;
                        }

                    case "1":
                        {
                            SerialPortQr.BaudRate = 9600;
                            sTitle += "9600bps／";
                            break;
                        }

                    case "2":
                        {
                            SerialPortQr.BaudRate = 19200;
                            sTitle += "19200bps／";
                            break;
                        }

                    case "3":
                        {
                            SerialPortQr.BaudRate = 38400;
                            sTitle += "38400bps／";
                            break;
                        }

                    case "4":
                        {
                            SerialPortQr.BaudRate = 57600;
                            sTitle += "57600bps／";
                            break;
                        }

                    case "5":
                        {
                            SerialPortQr.BaudRate = 115200;
                            sTitle += "115200bps／";
                            break;
                        }

                    default:
                        {
                            SerialPortQr.BaudRate = 38400;
                            break;
                        }
                }
                // シリアルポートのパリティ指定
                switch (PubConstClass.pblComParityVar)
                {
                    case "0":
                        {
                            SerialPortQr.Parity = Parity.Odd;
                            sTitle += "奇数／";
                            break;
                        }

                    case "1":
                        {
                            SerialPortQr.Parity = Parity.Even;
                            sTitle += "偶数／";
                            break;
                        }

                    default:
                        {
                            SerialPortQr.Parity = Parity.Even;
                            break;
                        }
                }
                // シリアルポートのパリティ有無
                if (PubConstClass.pblComIsParity == "0")
                {
                    SerialPortQr.Parity = Parity.None;
                    sTitle += "パリティ無し／";
                }
                // シリアルポートのビット数指定
                switch (PubConstClass.pblComDataLength)
                {
                    case "0":
                        {
                            SerialPortQr.DataBits = 8;
                            sTitle += "8ビット／";
                            break;
                        }

                    case "1":
                        {
                            SerialPortQr.DataBits = 7;
                            sTitle += "7ビット／";
                            break;
                        }

                    default:
                        {
                            SerialPortQr.DataBits = 8;
                            break;
                        }
                }
                // シリアルポートのストップビット指定
                switch (PubConstClass.pblComStopBit)
                {
                    case "0":
                        {
                            SerialPortQr.StopBits = StopBits.One;
                            sTitle += "ストップビット１ ］";
                            break;
                        }

                    case "1":
                        {
                            SerialPortQr.StopBits = StopBits.Two;
                            sTitle += "ストップビット２ ］";
                            break;
                        }

                    default:
                        {
                            SerialPortQr.StopBits = StopBits.One;
                            break;
                        }
                }
                #endregion

                PubConstClass.pblMainFormTitle = $"【メインメニュー画面】 ［{sTitle}］ ";
                this.Text = PubConstClass.pblMainFormTitle;

                // 読取結果（表）の初期化
                CmbReadOmote.Items.Clear();
                CmbReadOmote.Items.Add("OK");
                CmbReadOmote.Items.Add("NG");
                CmbReadOmote.SelectedIndex = 0;
                // 読取結果（裏）の初期化
                CmbReadUra.Items.Clear();
                CmbReadUra.Items.Add("OK");
                CmbReadUra.Items.Add("NG");
                CmbReadUra.SelectedIndex = 0;
                // 表裏一致判定の初期化
                CmbMatchDetection.Items.Clear();
                CmbMatchDetection.Items.Add("OK");
                CmbMatchDetection.Items.Add("NG");
                CmbMatchDetection.Items.Add("NC");
                CmbMatchDetection.SelectedIndex = 0;
                // 連番判定の初期化 
                CmbSerialNumJudg.Items.Clear();
                CmbSerialNumJudg.Items.Add("OK");
                CmbSerialNumJudg.Items.Add("NG");
                CmbSerialNumJudg.Items.Add("NC");
                CmbSerialNumJudg.Items.Add("--");
                CmbSerialNumJudg.SelectedIndex = 0;

                // シリアルポートのオープン
                SerialPortQr.Open();
                LblError.Visible = false;
            }
            catch (Exception ex)
            {
                LblError.Text = ex.Message;
                LblError.Visible = true;
                MessageBox.Show(ex.Message, "【MainForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// データ送信（シリアル通信）
        /// </summary>
        /// <param name="cmd"></param>
        private void SendDataToSerial(string cmd)
        {
            try
            {
                // 送信データのセット
                byte[] dat = Encoding.GetEncoding("SHIFT-JIS").GetBytes(cmd + "\r");
                SerialPortQr.Write(dat, 0, dat.GetLength(0));
                LsbSendBox.Items.Add($"{cmd}<CR>");
                LsbSendBox.SelectedIndex = LsbSendBox.Items.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【SendDataToSerial】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「確認」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConfirmation_Click(object sender, EventArgs e)
        {
            SendDataToSerial(PubConstClass.CMD_SEND_A);
        }

        /// <summary>
        /// 「開始」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStart_Click(object sender, EventArgs e)
        {
            SendDataToSerial(PubConstClass.CMD_SEND_B);
        }

        /// <summary>
        /// 「停止」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStop_Click(object sender, EventArgs e)
        {
            SendDataToSerial(PubConstClass.CMD_SEND_C);
        }

        /// <summary>
        /// 「リセット」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnReset_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnReset_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「終了」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEnd_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("アプリを終了しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    this.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnEnd_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// データ受信
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks></remarks>
        private void SerialPortQr_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data;
            object[] args = new object[1];

            data = "";

            try
            {
                // シリアルポートをオープンしていない場合、処理を行わない。
                if (SerialPortQr.IsOpen == false)
                    return;
                // <CR>まで読み込む
                data = SerialPortQr.ReadTo("\r");

                // 受信データの格納
                BeginInvoke(new Delegate_RcvDataToTextBox(RcvDataToTextBox), data.ToString() + "\r");
            }
            catch (TimeoutException)
            {
                // ディスカードするデータ
                CommonModule.OutPutLogFile("■データ受信タイムアウトエラー：<CR>未受信で切り捨てたデータ：" + data);
            }
            catch (Exception ex)
            {
                CommonModule.OutPutLogFile("【SerialPortQr_DataReceived】" + ex.Message);
            }
        }

        /// <summary>
        /// 受信データによる各コマンド処理
        /// </summary>
        /// <param name="data">受信した文字列</param>
        /// <remarks></remarks>
        private void RcvDataToTextBox(string data)
        {
            string strMessage;

            try
            {
                CommonModule.OutPutLogFile("受信データ：" + data.Replace("\r", "<CR>"));

                LsbRecvBox.Items.Add(data.Replace("\r", "<CR>"));
                LsbRecvBox.SelectedIndex = LsbRecvBox.Items.Count - 1;

                // 受信データの先頭１文字を取得
                string sCommandType = data.Substring(0, 2);
                switch (sCommandType)
                {
                    case PubConstClass.CMD_RECIEVE_a:
                        // JOB設定内容
                        //LsbRecvBox.Items.Add($"設定データ：{data}");
                        break;

                    case PubConstClass.CMD_RECIEVE_b:
                        // 開始コマンド
                        BtnStart.PerformClick();
                        break;

                    case PubConstClass.CMD_RECIEVE_c:
                        // 停止コマンド
                        BtnStop.PerformClick();
                        break;

                    default:
                        // 未定義コマンド
                        break;
                }
            }
            catch (Exception ex)
            {
                strMessage = "【RcvDataToTextBox】" + ex.Message;
                CommonModule.OutPutLogFile(strMessage);
                MessageBox.Show(strMessage, "システムエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int iSendNumber = 1;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSendData_Click(object sender, EventArgs e)
        {
            string sData = "ZD,";

            try
            {
                // 読取番号（表裏）
                sData += $"{iSendNumber:D9}/";
                sData += $"{iSendNumber:D9},";
                // 読取結果（表裏）
                sData += (CmbReadOmote.SelectedIndex == 0) ? "0/" : "1/";
                sData += (CmbReadUra.SelectedIndex == 0) ?   "0," : "1,";
                // 表裏一致判定
                sData += (CmbMatchDetection.SelectedIndex == 0) ? "0," :
                          (CmbMatchDetection.SelectedIndex == 1) ? "1," : "2,";
                // 連番判定
                sData += (CmbSerialNumJudg.SelectedIndex == 0) ? "0" :
                          (CmbSerialNumJudg.SelectedIndex == 1) ? "1" :
                          (CmbSerialNumJudg.SelectedIndex == 2) ? "2" : "3";

                SendDataToSerial(sData);

                iSendNumber++;
                TxtReadOmote.Text = $"{iSendNumber:D9}";
                TxtReadUra.Text = $"{iSendNumber:D9}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnSendData_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
