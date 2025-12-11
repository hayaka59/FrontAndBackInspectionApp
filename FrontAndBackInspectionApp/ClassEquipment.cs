using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;
using Kinoshita.Lib;
//using MTQI2App.画面;
using System.Windows.Forms;

namespace FrontAndBackInspectionApp
{    
    /// <summary>
    /// 装置クラス
    /// </summary>
    public static class ClassEquipment
    {
        #region フィールド
        /// <summary>
        /// 装置クラス通信用
        /// </summary>
        static CommLib commEquipment_;

        /// <summary>
        /// ラベラークラス通信用
        /// </summary>
        static CommLib commEquipmentForLabel_;
        #endregion

        #region イベント
        /// <summary>
        /// 封緘検査結果通知イベント
        /// </summary>
        public static event EventHandler<EquipmentCommandDataReceiveEventArgs> CommandDataReceiveEvent;

        public static event EventHandler<EquipmentCommandDataReceiveEventArgs> CommandDataReceiveEventForLabel;

        /// <summary>
        /// 装置からのコマンドデータ受信イベント
        /// </summary>
        public class EquipmentCommandDataReceiveEventArgs : EventArgs
        {
            public EquipmentCommandDataReceiveEventArgs(String receiveData)
            {
                ReceiveData = receiveData;
            }
            public String ReceiveData { get; set; }
        }
        #endregion

        #region 構築・初期化
        /// <summary>
        /// 装置クラスコンストラクタ
        /// </summary>
        static ClassEquipment()
        {
        }
        public static void Initialyze(SerialPort _commPort)
        {
            // 装置コマンド解析初期化
            try
            {
                commEquipment_ = new CommLib(_commPort)
                {
                    EndDelimiter = "\r"
                };
                commEquipment_.EventComm += new DebugCommHandler(CommEquipment_EventComm);
                commEquipment_.Add(new CommLibEntry('Z', new CommLibEntryDelegate(Ctrl_Z_Cmd)));
                commEquipment_.Start();
                // CommLibクラス内で開くようにする：20160308
                // _commPort.Open();
            }
            catch (Exception ex)
            {
                Log.OutPutLogFile(TraceEventType.Critical,
                    "■装置側シリアルポートの初期化に失敗しました：{0}", ex);
                throw;
            }
        }

        public static void InitialyzeForLabel(SerialPort _commPort)
        {
            // 装置コマンド解析初期化
            try
            {
                commEquipmentForLabel_ = new CommLib(_commPort)
                {
                    EndDelimiter = "\r"
                };
                commEquipmentForLabel_.EventComm += new DebugCommHandler(CommEquipment_EventComm_ForLabel);
                commEquipmentForLabel_.Add(new CommLibEntry('Z', new CommLibEntryDelegate(Ctrl_Z_Cmd_ForLabel)));
                commEquipmentForLabel_.Start();
            }
            catch (Exception ex)
            {
                Log.OutPutLogFile(TraceEventType.Critical,
                    "■ラベラー側シリアルポートの初期化に失敗しました：{0}", ex);
                throw;
            }
        }
        #endregion

        /// <summary>
        /// 装置へコマンドデータを送信
        /// </summary>
        /// <param name="sData"></param>
        public static void SendCommandData(string sData)
        {
            Ctrl_Send_Command_Data(commEquipment_, sData);
        }

        public static void SendCommandDataForLabel(string sData)
        {
            Ctrl_Send_Command_Data_ForLabel(commEquipmentForLabel_, sData);
        }

        #region 装置送受信（ログ）
        /// <summary>
        /// 送受信解析のイベント部分
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void CommEquipment_EventComm(object sender, DebugCommEventArgs e)
        {
            switch (e.Type)
            {
                case CommLib.CommLibEvent.Recv:
                    if (e.DataLen > 0)
                    {
                        Log.OutPutSerialLogFile("■受信({0:D2})：{1}", e.DataLen, e.Data);                        
                    }
                    break;
                case CommLib.CommLibEvent.Xmit:
                    Log.OutPutSerialLogFile("□送信({0:D2})：{1}", e.DataLen, e.Data);
                    break;
                default:
                    Log.OutPutSerialLogFile("〓エラー({0:D2})：{1}", e.DataLen, e.Data);
                    break;
            }
        }

        static void CommEquipment_EventComm_ForLabel(object sender, DebugCommEventArgs e)
        {
            switch (e.Type)
            {
                case CommLib.CommLibEvent.Recv:
                    if (e.DataLen > 0)
                    {
                        Log.OutPutSerialLogFile("■【ラベラー】受信({0:D2})：{1}", e.DataLen, e.Data);
                    }
                    break;
                case CommLib.CommLibEvent.Xmit:
                    Log.OutPutSerialLogFile("□【ラベラー】送信({0:D2})：{1}", e.DataLen, e.Data);
                    break;
                default:
                    Log.OutPutSerialLogFile("〓【ラベラー】エラー({0:D2})：{1}", e.DataLen, e.Data);
                    break;
            }
        }
        #endregion

        #region 装置送信コマンド類
        /// <summary>
        /// 指定データを装置へ送信する
        /// </summary>
        /// <param name="_commLib"></param>
        /// <param name="sData"></param>
        static void Ctrl_Send_Command_Data(CommLib _commLib, string sData)
        {
            if (_commLib == null) return;
            _commLib.Xmit(sData + string.Format("\r"));
        }
        static void Ctrl_Send_Command_Data_ForLabel(CommLib _commLib, string sData)
        {
            if (_commLib == null) return;
            _commLib.Xmit(sData + string.Format("\r"));
        }
        #endregion

        #region 装置受信コマンド類
        static void Ctrl_Z_Cmd(CommLib _commLib, char _cmd, string _body)
        {
            if (CommandDataReceiveEvent == null)
            {
                // イベントハンドラーが登録されていない
                return;
            }

            // 検査中か確認
            if (!ClassGlobalVariables.IsInspect)
            {
                //MessageBox.Show("検査中ではありません。", "【Ctrl_Z_Cmd】", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Log.OutPutLogFile(TraceEventType.Error, "【検査中以外に「Z{0}」コマンドを受信した】",_body);
                return;
            }

            var watch = new Stopwatch();
            watch.Start();

            //string[] cmdArray = _body.Split(',');
            if (_body.Length > 0)
            {   // 装置状態取り出し
                ThreadPool.QueueUserWorkItem(new WaitCallback(delegate (object newStatus) {
                    var e = new EquipmentCommandDataReceiveEventArgs((string)newStatus);
                    CommandDataReceiveEvent.Invoke(null, e);
                }), _body);
            }

            watch.Stop();
            Log.OutPutLogFile(TraceEventType.Verbose,
                "□装置状態テキスト通知[{0:N3}ms]", watch.ElapsedMilliseconds / (Stopwatch.Frequency / 1000.0f));
        }

        static void Ctrl_Z_Cmd_ForLabel(CommLib _commLib, char _cmd, string _body)
        {
            if (CommandDataReceiveEventForLabel == null)
            {
                // イベントハンドラーが登録されていない
                return;
            }

            // 検査中か確認
            if (!ClassGlobalVariables.IsInspect)
            {
                //MessageBox.Show("検査中ではありません。", "【Ctrl_Z_Cmd】", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Log.OutPutLogFile(TraceEventType.Error, "【検査中以外に「Z{0}」コマンドを受信した】", _body);
                return;
            }

            var watch = new Stopwatch();
            watch.Start();

            //string[] cmdArray = _body.Split(',');
            if (_body.Length > 0)
            {   // 装置状態取り出し
                ThreadPool.QueueUserWorkItem(new WaitCallback(delegate (object newStatus) {
                    var e = new EquipmentCommandDataReceiveEventArgs((string)newStatus);
                    CommandDataReceiveEventForLabel.Invoke(null, e);
                }), _body);
            }

            watch.Stop();
            Log.OutPutLogFile(TraceEventType.Verbose,
                "□ラベル状態テキスト通知[{0:N3}ms]", watch.ElapsedMilliseconds / (Stopwatch.Frequency / 1000.0f));
        }

        #endregion

    }
}
