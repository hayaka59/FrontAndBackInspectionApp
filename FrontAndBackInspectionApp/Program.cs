using FrontAndBackInspectionApp.表裏検査装置画面;
using Kinoshita.Lib;
using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;

namespace FrontAndBackInspectionApp
{
    static class Program
    {
        /// <summary>
        /// アプリケーションバージョン
        /// </summary>
        public static string Version;

        /// <summary>
        /// ビルド日時
        /// </summary>
        public static string BuildDate;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Mutex hMutex = null;

            try
            {
                // 多重起動チェック
                hMutex = new Mutex(false, Application.ProductName);
                if (hMutex.WaitOne(0, false) == false)
                {
                    MessageBox.Show("装置ログアプリは、二重起動禁止です", "確認", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Log.InitialyzeComponent();
                Log.OutPutLogFile(TraceEventType.Information,
                                        "〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓〓");
                Log.OutPutLogFile(TraceEventType.Information, $"ケース封入アプリ起動（{PubConstClass.DEF_VERSION}）");
                // バージョン情報及びビルド日付の取得
                Version = Application.ProductVersion;
                var info = new System.IO.FileInfo(Application.ExecutablePath);
                BuildDate = info.LastWriteTime.ToString("yyyy/MM/dd HH:mm:ss");

                // 検査処理クラス初期化
                try
                {
                    Log.OutPutLogFile(TraceEventType.Information, "■検査処理クラス初期化");

                    // 装置クラス初期化
                    try
                    {
                        Log.OutPutLogFile(TraceEventType.Information, "■装置クラス初期化");

                        CommonModule.ReadSystemDefinition();

                        SerialPort serial;
                        //SerialPort serialForLabel;

                        int[] comSpeed = { 4800, 9600, 19200, 38400, 57600, 115200 };
                        int[] comDataLength = { 8, 7 };
                        StopBits[] comStopBit = { StopBits.One, StopBits.Two };
                        Parity[] comParity = { Parity.None, Parity.Odd, Parity.Even, Parity.Mark, Parity.Space };

                        int iParityIndex = 0;
                        if (PubConstClass.pblComIsParity == "1")
                        {
                            iParityIndex = PubConstClass.pblComIsParity == "0" ? 1 : 2;
                        }

                        Log.OutPutLogFile(TraceEventType.Information, $"■装置クラス初期化：ポート名      ＝ {PubConstClass.pblComPort}");
                        Log.OutPutLogFile(TraceEventType.Information, $"■装置クラス初期化：ボーレート    ＝ {comSpeed[int.Parse(PubConstClass.pblComSpeed)]}");
                        Log.OutPutLogFile(TraceEventType.Information, $"■装置クラス初期化：データビット  ＝ {comDataLength[int.Parse(PubConstClass.pblComDataLength)]}");
                        Log.OutPutLogFile(TraceEventType.Information, $"■装置クラス初期化：ストップビット＝ {comStopBit[int.Parse(PubConstClass.pblComStopBit)]}");
                        Log.OutPutLogFile(TraceEventType.Information, $"■装置クラス初期化：パリティ      ＝ {comParity[iParityIndex]}");
                        
                        try
                        {
                            // SerialPortクラスの構築
                            serial = new SerialPort(PubConstClass.pblComPort)
                            {
                                BaudRate = comSpeed[int.Parse(PubConstClass.pblComSpeed)],
                                DataBits = comDataLength[int.Parse(PubConstClass.pblComDataLength)],
                                StopBits = comStopBit[int.Parse(PubConstClass.pblComStopBit)],
                                Parity = comParity[iParityIndex],
                                ParityReplace = (byte)127
                            };
                            //// ラベルプリンタ用シリアルポート
                            //serialForLabel = new SerialPort("COM3")
                            //{
                            //    BaudRate = 19200,
                            //    DataBits = 8,
                            //    StopBits = StopBits.One,
                            //    Parity = Parity.Even,
                            //    ParityReplace = (byte)127
                            //};
                        }
                        catch (Exception ex)
                        {   // 装置クラスで例外が起こっているので、運転はできない
                            /**
                             * シリアル設定でエラーが起こっている場合
                             * ①設定が違う：起動できなくなっているので、保守メニューには入れるようにする
                             * ②ポート故障：H/W故障だが、判別できない
                             */
                            Log.OutPutLogFile(TraceEventType.Critical,
                                "■シリアルポートエラー：シリアルポートの構築で例外({0})", ex);
                            throw new InvalidOperationException("シリアルポートの構成で失敗");
                        }
                        // 装置クラス初期化
                        ClassEquipment.Initialyze(serial);
                        // ラベルプリンタ用シリアルポート初期化
                        //ClassEquipment.InitialyzeForLabel(serialForLabel);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("装置側初期化に失敗しました。" + Environment.NewLine + "設定を確認して再起動してください");
                    }
                    finally
                    {
                        Log.OutPutLogFile(TraceEventType.Information, "■装置クラス初期化完了");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("検査処理クラス初期化に失敗しました。" + Environment.NewLine + "設定を確認して再起動してください");
                }
                finally
                {
                    Log.OutPutLogFile(TraceEventType.Information, "■検査処理クラス初期化完了");
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new FormMain());
                Application.Run(new MainMenuForm());
                //WorkGroupListForm.cs
            }
            catch (Exception ex)
            {
                MessageBox.Show("装置側初期化に失敗しました。" + Environment.NewLine + "設定を確認して再起動してください" +
                                Environment.NewLine + ex.Message, "エラー【Program.Main()】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {                
                Log.OutPutLogFile(TraceEventType.Information, "■装置クラス初期化完了");
                hMutex?.Dispose();               
            }
        }
    }
}
