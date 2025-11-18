using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Diagnostics;

/// Kinoshitaクラスライブラリ名前空間
namespace Kinoshita.Lib
{
	/// <summary>
	/// 受信時に、応答で呼び出されるデリゲート
	/// </summary>
	/// <param name="comm_">登録したCommLibクラスのインスタンス</param>
	/// <param name="cmd_">先頭デリミタの直後にある識別子</param>
	/// <param name="cmd_body_">先頭・終端のデリミタを除いたコマンド全文</param>
	public delegate void CommLibEntryDelegate( CommLib comm_, char cmd_, string cmd_body_ );
	/// <summary>
	/// 通信ログをハンドルするようのイベントハンドラ
	/// </summary>
	public class DebugCommEventArgs : EventArgs 
	{
		public CommLib.CommLibEvent Type;
		public string Data;
        public int DataLen;
	}
	/// <summary>
	/// 通信ログ（送受信）をハンドリングするためのイベントハンドラデリゲート
	/// </summary>
	/// <param name="sender">CommLibインスタンス</param>
	/// <param name="e">通信電文本体</param>
	public delegate void DebugCommHandler( object sender, DebugCommEventArgs e);
	/// <summary>
	/// 通信処理ライブラリ
	/// 役割：シリアルから受信したデータを区切り、登録したデリゲートに返す
	/// 
	/// 使い方:
	///		comm = new CommLib(serialPort);		// シリアルポートクラスのインスタンスを渡して生成
	///		comm.EndDelimiter = new string({'cr'});	// 終端デリミタ（右例ではCR)
	///		comm.Add( new CommLibEntry( 'b', Command_b );	// ’ｂ’を受信時に応答
	///		comm.Start();	// 受信開始
	///		
	///		comm.Stop();	// 受信停止
	///
	/// </summary>
	public class CommLib
	{
		public enum CommLibEvent
		{
			Recv,	/// 受信
			Xmit,	/// 送信
			Err		/// エラー
		}
		// ----------------------------------------------------------------
		/// <summary>
		/// 解析したコマンドに該当する処理を行うためのDictionary
		/// </summary>
		private Dictionary<char, CommLibEntry> mapCmdEntry = new Dictionary<char,CommLibEntry>();
		private object syncMapCmdEntry = new object();
		/// <summary>
		/// 通信対象のシリアルポート
		/// </summary>
		private SerialPort serialPort;
		/// <summary>
		/// 受信スレッド
		/// </summary>
		private Thread recieveThread;
		/// <summary>
		/// 先頭デリミタ（この文字以降を電文とする、nullの場合は見ない)
		/// </summary>
		private string startDelimiter;
		/// <summary>
		/// 末尾デリミタ(この文字を終端区切りとする)
		/// </summary>
		private string endDelimiter;
		// ----------------------------------------------------------------
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public CommLib(SerialPort comPort_)
		{
            Trace.WriteLine("CommLib:" + System.Reflection.MethodBase.GetCurrentMethod().Name);
            // シリアルポートクラス
            serialPort = comPort_ ?? throw new ArgumentNullException( "comPort_", "SerialPortクラスを生成して渡して下さい");
			// デリミタの初期値
			startDelimiter = null;
			endDelimiter = Environment.NewLine;
			serialPort.NewLine = endDelimiter;
			serialPort.ReceivedBytesThreshold = 2;
            serialPort.Encoding = Encoding.GetEncoding(932);
        }
		/// <summary>
		/// 監視開始
		/// </summary>
		public virtual void Start()
		{
            Trace.WriteLine("CommLib:" + System.Reflection.MethodBase.GetCurrentMethod().Name);
			// 現状チェック
			if ( recieveThread != null )
				throw new InvalidOperationException(
					String.Format("CommLib：すでに実行中"));
            // 受信処理用のスレッドを作成
            Thread recieveThread_ = new Thread(new ThreadStart(ReciveThreadEntry))
            {
                IsBackground = true,    // バックグラウンドスレッドへ設定
                Priority = ThreadPriority.AboveNormal   // プロセスの通常優先度より１つ上にスケジューリング
            };
            recieveThread = recieveThread_;
			recieveThread.Start();

			// ポートのOpen状態を確認し開く
			if (!serialPort.IsOpen)
			{
				serialPort.Open();
			}
		}
		/// <summary>
		/// 現状の監視スレッドを止めて破棄する
		/// </summary>
		public virtual void Stop()
		{
            Trace.WriteLine("CommLib:" + System.Reflection.MethodBase.GetCurrentMethod().Name);
			// 現状チェック
			if ( recieveThread == null )
				throw new InvalidOperationException(
					String.Format("CommLib：すでに停止している"));
            // ポートを閉じる
            if (serialPort.IsOpen)
            {
                serialPort.DiscardInBuffer();
                serialPort.Close();
            }
			// スレッドを止める
			recieveThread.Interrupt();
			recieveThread.Join();
			recieveThread = null;
		}
		/// <summary>
		/// 該当データの送信
		/// </summary>
		/// <param name="xmitData_">送信データ</param>
		public virtual void Xmit(string xmitData_)
		{
            //Trace.WriteLine("CommLib:" + System.Reflection.MethodBase.GetCurrentMethod().Name);
			try
			{
				// シリアルポートがOpen済みか？
				if (serialPort.IsOpen)
				{
					var xmitBytes = Encoding.GetEncoding(932).GetBytes(xmitData_);
					serialPort.WriteTimeout = 1000;
					serialPort.Write(xmitBytes, 0, xmitBytes.Length);
					serialPort.BaseStream.Flush();
					// 送信電文通知
					if (EventComm != null)
					{
                        DebugCommEventArgs e = new DebugCommEventArgs
                        {
                            Type = CommLibEvent.Xmit,
                            Data = CtrlCodeToDisplayString(xmitData_),
                            DataLen = xmitData_.Length
                        };
                        EventComm(this, e);
					}
				}
				else
				{
					//throw new InvalidOperationException(
					//	"CommLib:シリアルポートがOpenしていない状態で送信");
				}
			}
			catch (ObjectDisposedException)
			{
				return;
			}
			catch (TimeoutException)
			{	// 送信タイムアウトが発生
			}
		}
		/// <summary>
		/// コマンドに応答するためのエントリを追加する
		/// </summary>
		/// <param name="entry_">CommLibEntryのインスタンス</param>
		public virtual void Add(CommLibEntry entry_)
		{
            Trace.WriteLine("CommLib:" + System.Reflection.MethodBase.GetCurrentMethod().Name);
			// エントリの追加
			lock (syncMapCmdEntry)
			{
				mapCmdEntry.Add(entry_.Cmd, entry_);
			}
		}

		// ----------------------------------------------------------------
        /// <summary>
        /// 制御コードを表記文字へ
        /// </summary>
        /// <param name="inStr">文字列</param>
        /// <returns>制御コードを変換した文字列</returns>
        private string CtrlCodeToDisplayString(string inStr)
        {
            string[] ctrlStr = { 
					"NUL", "SOH", "STX", "ETX", "EOT", "ENQ", "ACK", "BEL",
                    "BS",  "HT",  "LF",  "VT",  "NP",  "CR",  "SO",  "SI", 
                    "DLE", "DC1", "DC2", "DC3", "DC4", "NAK", "SYN", "ETB", 
                    "CAN", "EM",  "SUB", "ESC", "FS",  "GS",  "RS",  "US" };
            return Regex.Replace(inStr, @"\p{Cc}", str =>
            {
                int offset = str.Value[0];
                if (ctrlStr.Length > offset)
                {
                    return "[" + ctrlStr[offset] + "]";
                }
                else
                {
                    return string.Format("<{0:X2}>", (byte)str.Value[0]);
                }
            });
        }
        /// <summary>
		/// 受信スレッド
		/// </summary>
		private void ReciveThreadEntry( )
		{
            Trace.WriteLine("CommLib:" + System.Reflection.MethodBase.GetCurrentMethod().Name);
			try {
				for ( ;; ) {
                    // シリアルがOpenされないと、受信処理をしないようにする
                    if (serialPort.IsOpen)
                    {
                        System.Diagnostics.Trace.WriteLine(
                       String.Format("CommLib:受信開始"));
                        RecieveProc();
                        System.Diagnostics.Trace.WriteLine(
                           String.Format("CommLib:受信停止"));
                    }
                    else
                    {
                        Thread.Sleep(100);
                    }
                }
			} catch ( ThreadInterruptedException ) {
				// スレッド停止のためのInterrupt受付
				return;
			} catch ( Exception ex ) {
				// 不明な例外(コード内でトラップしていない)
				System.Diagnostics.Trace.Fail(
					String.Format("CommLib:トラップしていない例外({0})", ex));
			}
		}
		/// <summary>
		/// 受信処理
		/// 1行を受信し、デリミタを取り除いてエントリへ投げる
		/// </summary>
		private void RecieveProc()
		{
            Trace.WriteLine("CommLib:" + System.Reflection.MethodBase.GetCurrentMethod().Name);
            try
            {
                for (; ; )
                {
                    try
                    {
                        // 一行読み込む
                        string line = serialPort.ReadTo(endDelimiter);
                        // 受信電文通知
                        if (EventComm != null)
                        {
                            DebugCommEventArgs e = new DebugCommEventArgs
                            {
                                Type = CommLibEvent.Recv,
                                Data = CtrlCodeToDisplayString(line + endDelimiter),
                                DataLen = line.Length
                            };
                            EventComm(this, e);
                        }
                        // 先頭デリミタを探す(指定している場合)
                        if (startDelimiter != null)
                        {
                            // スタートデリミタを取り除いて処理
                            int startIndex = line.IndexOf(startDelimiter);
                            if (startIndex < 0) continue;		// 見つからなかった場合は受信電文無視
                            line = line.Substring(startIndex + startDelimiter.Length);
                        }
                        // 終端デリミタはReadLineで取れているはず
                        // 先頭文字を取る
                        if (line.Length > 0)
                        {
                            char topChar = line[0];
                            // 該当文字が、辞書に格納されているか
                            if (mapCmdEntry.ContainsKey(topChar))
                            {
                                // 辞書に有った場合は、エントリを処理
                                try
                                {
                                    lock (syncMapCmdEntry)
                                    {
                                        mapCmdEntry[topChar].CmdEntry(this, topChar, line.Substring(1));
                                    }
                                }
                                catch (Exception ex)
                                {
                                    // デリゲート内の例外は、相手先の話なので、
                                    // トラップして無視する
									Log.OutPutSerialLogFile(
										"□電文処理中の例外：{0}({1})", ex.Message, ex.StackTrace);
                                }
                            }
                            else
                            {
                                // 無い場合の該当電文の無視
                                System.Diagnostics.Trace.TraceInformation(
                                    String.Format("CommLib:先頭文字「{0}」は、解析対象文字ではありません", topChar));
                            }
                        }
                        else
                        {
                            // 空電文の無視
                            //System.Diagnostics.Trace.TraceInformation(
                            //    String.Format("CommLib:空電文は無視します"));
                        }
                    }
                    catch (TimeoutException)
                    {
                        // SerialPortの受信タイムアウト
                        System.Diagnostics.Trace.TraceWarning(
                            String.Format("CommLib:受信タイムアウト"));
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                // たぶん、シリアルポートが閉じられてしまうとトラップ
                System.Diagnostics.Trace.TraceError(
                    String.Format("CommLib:受信処理中のInvalidOperationException[{0}]", ex.Message));
            }
            catch (IOException)
            {
                // ReadTo待ちの際のClose
                System.Diagnostics.Trace.TraceWarning(
                    String.Format("ReadToのIOException"));
            }
        }
		// ----------------------------------------------------------------
		// プロパティ
		public virtual string StartDelimiter
		{
			get { return startDelimiter; }
			set { startDelimiter = value; }
		}
		public virtual string EndDelimiter
		{
			get { return endDelimiter; }
			set {
                endDelimiter = value ?? throw new ArgumentNullException(
						  "EndDelimiter", "nullはダメ");
//				serialPort.NewLine = endDelimiter;
			 }
		}
		/// <summary>
		/// 通信、送受信イベント
		/// </summary>
		public virtual event DebugCommHandler EventComm;
	}
	/// <summary>
	/// 各コマンドに対応するデリゲート
	/// このエントリに登録しているデリゲートは、
	/// プロセス優先度より一つ高い形で呼び出される
	/// </summary>
	public class CommLibEntry
	{
		// ----------------------------------------------------------------
		private char cmdChar_;						/// 先頭キャラ
		private CommLibEntryDelegate cmdDelegate_;	/// コマンド受信時に応答するデリゲート

		// ----------------------------------------------------------------
		public CommLibEntry( char cmd_, CommLibEntryDelegate entry_ )
		{
			// 引数チェック
			if ( Char.IsControl(cmd_) )	throw new ArgumentOutOfRangeException( "cmd_", "制御コード以外のASCIIコードを渡すこと");
            // パラメータを組む
            cmdChar_ = cmd_;
			cmdDelegate_ = entry_ ?? throw new ArgumentNullException( "entry_", "エントリーのnullは無しで");
		}

		// ----------------------------------------------------------------
		// プロパティ
		public char Cmd
		{
		  get { return cmdChar_; }
		} 
		internal CommLibEntryDelegate CmdEntry
		{
		  get { return cmdDelegate_; }
		}
	}
}
