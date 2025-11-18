using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinoshita.Lib
{
    /// <summary>
    /// 各種動作記録用コンポーネント
    /// 記録条件ごとのリスナーを追加していく
    /// </summary>
    public static class Log
    {
        // ------------------------------------------
#if DEBUG
        static TraceSource operationLog_;
#else
        static TraceSource operationLog_ = new TraceSource("Kot72", SourceLevels.Information);
#endif

#if DEBUG
        static TraceSource comunicationLog_;
#else
        static TraceSource comunicationLog_ = new TraceSource("Kot72", SourceLevels.Off);
#endif

        // ------------------------------------------
        /// <summary>
        /// ログコンポーネントの初期化</br>
        /// 操作履歴ログと通信履歴ログの初期化を行う
        /// </summary>
        public static void InitialyzeComponent()
        {
            if (System.IO.File.Exists(Environment.CurrentDirectory + @"\LoggingOperationLog.txt"))
            {
                // 操作ログを残す
                operationLog_ = new TraceSource("Kot72", SourceLevels.Information);
                //operationLog_ = new TraceSource("Kot72", SourceLevels.All);
            }
            else
            {
                // 操作履歴ログを残さない
                operationLog_ = new TraceSource("Kot72", SourceLevels.Off);
            }

            if (System.IO.File.Exists(Environment.CurrentDirectory + @"\LoggingComunicationLog.txt"))
            {
                // 通信履歴ログを残す               
                comunicationLog_ = new TraceSource("Kot72", SourceLevels.ActivityTracing);
            }
            else
            {
                // 通信履歴ログを残さない
                comunicationLog_ = new TraceSource("Kot72", SourceLevels.Off);
            }

            // 操作履歴ログ初期化
            //operationLog_.Listeners.Remove("Default");
            operationLog_.Listeners.Add(
                new CustumTraceLitner(0, "OPHISTORYLOG" + Path.DirectorySeparatorChar, "操作履歴ログ_{0:yyyyMMdd}.LOG", null));
            // 通信履歴ログ初期化
            //comunicationLog_.Listeners.Remove("Default");
            comunicationLog_.Listeners.Add(
                new CustumTraceLitner(0, "OPHISTORYLOG" + Path.DirectorySeparatorChar, "通信ログ_{0:yyyyMMdd}.LOG", null));
        }
        /// <summary>
        /// 通信履歴ログへの出力
        /// </summary>
        /// <param name="_level">
        /// トレースレベル<see cref="TraceEventType"/></cr>
        /// 作成時のスイッチはSourceLevels.Information
        /// </param>
        /// <param name="_message"></param>
        /// <param name="args"></param>
        public static void OutPutSerialLogFile(string _message, params object[] args)
        {
            // 通信履歴ログへの出力
            if (args != null)
            {
                comunicationLog_.TraceEvent(TraceEventType.Transfer, 0, _message, args);
                operationLog_.TraceEvent(TraceEventType.Transfer, 0, _message, args);
            }
            else
            {
                comunicationLog_.TraceEvent(TraceEventType.Transfer, 0, _message);
                operationLog_.TraceEvent(TraceEventType.Transfer, 0, _message);
            }
        }
        public static void OutPutLogFile(TraceEventType _level, string _message, params object[] args)
        {
            // 操作履歴ログへの出力
            if (args != null)
            {
                operationLog_.TraceEvent(_level, 0, _message, args);
            }
            else
            {
                operationLog_.TraceEvent(_level, 0, _message);
            }
        }
    }
    class CustumTraceLitner : TraceListener
    {
        #region フィールド
        private readonly object syncObj_ = new object();
        #endregion
        #region コンストラクタ
        /// <summary>
        /// デフォルトコンストラクタ(引数無し)
        /// </summary>
        public CustumTraceLitner() :
            this(-1, null, null, null, null, null, null)
        { }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="_maxSize">
        /// ファイルの最大容量を指定する。</br>
        /// 指定のファイル容量で分割を行う。</br>
        /// 0を指定すると、分割しない。
        /// -1を指定すると、<see cref="DefaultMaxSize"/>で分割する</param>
        public CustumTraceLitner(long _maxSize) :
            this(_maxSize, null, null, null, null, null, null)
        { }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="_outPutFolder">
        /// ログファイルの記録フォルダを指定する。</br>
        /// 存在しないフォルダの場合は、出力する段階で例外となる
        /// </param>
        public CustumTraceLitner(string _outPutFolder) :
            this(-1, _outPutFolder, null, null, null, null, null)
        { }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="_outPutFolder">
        /// ログファイルの記録フォルダを指定する。</br>
        /// 存在しないフォルダの場合は、出力する段階で例外となる
        /// </param>
        /// <param name="_appName">
        /// アプリケーション名称を指定する
        /// </param>
        public CustumTraceLitner(string _outPutFolder, string _appName) :
            this(-1, _outPutFolder, null, null, null, null, _appName)
        { }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="_outPutFolder">
        /// ログファイルの記録フォルダを指定する。</br>
        /// 存在しないフォルダの場合は、出力する段階で例外となる
        /// </param>
        /// <param name="_filter">
        /// <param name="filter">メッセージの出力を制御する <see cref="TraceFilter"/>。</param>
        /// </param>
        public CustumTraceLitner(string _outPutFolder, TraceFilter _filter) :
            this(-1, _outPutFolder, null, null, null, _filter, null)
        { }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="_outPutFolder">
        /// ログファイルの記録フォルダを指定する。</br>
        /// 存在しないフォルダの場合は、出力する段階で例外となる
        /// </param>
        /// <param name="filter">メッセージの出力を制御する <see cref="TraceFilter"/>。</param>
        /// <param name="_appName">
        /// アプリケーション名称を指定する
        /// </param>
        public CustumTraceLitner(string _outPutFolder, TraceFilter _filter, string _appName) :
            this(-1, _outPutFolder, null, null, null, _filter, _appName)
        { }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="_maxSize"></param>
        /// <param name="_outPutFolder">
        /// ログファイルの記録フォルダを指定する。</br>
        /// 存在しないフォルダの場合は、出力する段階で例外となる
        /// </param>
        /// <param name="_fileNameFormat">
        /// ファイル名の複合書式文字列を表す<br/>
        /// {0}:日付<br></br>
        /// {1}:ファイル番号<br></br>
        /// </param>
        /// <param name="_dateTimeFormat">
        /// 日付の複合書式文字列を表す<br/>
        /// </param>
        public CustumTraceLitner(long _maxSize, string _outPutFolder, string _fileNameFormat, string _dateTimeFormat) :
            this(_maxSize, _outPutFolder, _fileNameFormat, _dateTimeFormat, null, null, null)
        { }
        public CustumTraceLitner(long _maxSize, string _outPutFolder, string _fileNameFormat, string _dateTimeFormat, Encoding _encoding, TraceFilter _filter, string _appName)
            : base(_appName)
        {
            // プロパティ初期化
            FileNumber = 0;                             // 0より開始
            LastUpdate = DateTime.MinValue;     // 日付の最小値より
            Filter = _filter;                                   // 指定のTraceFilter

            if (_maxSize < 0)
            {   // 負の場合は、優先すべき値を代入
                if (Attributes.ContainsKey("maxSize") == true)
                {   // 最大値のプロパティ値を入れておく
                    MaxSize = long.Parse(Attributes["maxSize"]);
                }
                else
                {   // TraceListnerとして指定していないので、Default値を入れておく
                    MaxSize = DefaultMaxSize;
                }
            }
            else
            {   // 指定の最大値を入れておく
                MaxSize = _maxSize;
            }
            if (_outPutFolder == null)
            {   // 出力先ディレクトリの、優先すべき値を代入
                if (Attributes.ContainsKey("outputDirectory") == true)
                {   // TraceListnerの属性指定があれば、それを使用
                    OutputDirectory = Attributes["outputDirectory"];
                }
                else
                {   // 指定無しの場合は、アプリケーションのスタートアップパスへ
                    OutputDirectory = System.Windows.Forms.Application.StartupPath + Path.DirectorySeparatorChar;
                }
            }
            else
            {   // 指定のディレクトリ値を入れておく
                OutputDirectory = _outPutFolder;
            }
            if (_fileNameFormat == null)
            {   // ファイル名フォーマットの、優先すべき値を代入
                if (Attributes.ContainsKey("fileNameFormat") == true)
                {   // TraceListnerの属性指定があれば、それを使用
                    FileNameFormat = Attributes["fileNameFormat"];
                }
                else
                {   // 指定無しの場合は、Default値へ
                    FileNameFormat = DefaultFileNameFormat;
                }
            }
            else
            {   // 指定があれば、それで入れる
                FileNameFormat = _fileNameFormat;
            }
            if (_dateTimeFormat == null)
            {   // 日付書式の優先すべき値を代入
                if (Attributes.ContainsKey("dateTimeFormat") == true)
                {   // TraceListnerの属性指定があれば、それを使用
                    DateTimeFormat = Attributes["dateTimeFormat"];
                }
                else
                {   // 指定無しの場合は、Default値へ
                    DateTimeFormat = DefaultDateTimeFormat;
                }
            }
            else
            {   // 指定があれば、それで入れる
                DateTimeFormat = _dateTimeFormat;
            }
            if (_encoding == null)
            {
                if (this.Attributes.ContainsKey("encoding") == true)
                {
                    this.Encording = Encoding.GetEncoding(this.Attributes["encoding"]);
                }
                else
                {
                    this.Encording = this.DefaultEncording;
                }
            }
            else
            {
                this.Encording = _encoding;
            }
        }
        #endregion
        #region Dispose
        /// <summary>
        /// すべてのリソースの解放
        /// </summary>
        /// <param name="disposing">
        /// マネージリソースを解放するかどうかを表す
        /// </param>
        /// <remarks><paramref name="disposiong"/>に<see langword="false"/>を指定してはいけません</remarks>
        protected override void Dispose(bool disposing)
        {
            if (disposing == true)
            {
                Close();
            }
            base.Dispose(disposing);
        }
        #endregion
        #region メソッド(Virtual)
        /// <summary>
        /// 付随するオプション文字列を生成し付与します
        /// </summary>
        /// <param name="_eventCache">固有のトレースイベント情報を表す</param>
        /// <returns></returns>
        protected virtual string CreateOptionString(TraceEventCache _eventCache)
        {
            StringBuilder builder = new StringBuilder();
            string indent = new string(' ', IndentSize * (IndentLevel + 1));

            if ((this.TraceOutputOptions & TraceOptions.ProcessId) != 0)
            {   // Process Idを付与
                builder.AppendLine(indent + "Process Id=" + _eventCache.ProcessId);
            }
            if ((this.TraceOutputOptions & TraceOptions.LogicalOperationStack) != 0)
            {   // スタック
                bool first = false;
                foreach (Object obj in _eventCache.LogicalOperationStack)
                {
                    if (first == true)
                    {
                        builder.Append(indent + "LogicalOperationStack=" + obj.ToString());
                    }
                    else
                    {
                        builder.Append(", " + obj.ToString());
                    }
                    first = true;
                }
                builder.AppendLine();
            }
            if ((this.TraceOutputOptions & TraceOptions.ThreadId) != 0)
            {   // スレッドIDを付与
                builder.AppendLine(indent + "Thread Id=" + _eventCache.ThreadId);
            }
            if ((this.TraceOutputOptions & TraceOptions.Timestamp) != 0)
            {   // タイムスタンプ
                builder.AppendLine(indent + "TimeStanp=" + _eventCache.Timestamp);
            }
            if ((this.TraceOutputOptions & TraceOptions.DateTime) != 0)
            {   // 日付付与
                builder.AppendLine(indent + "DateTime" + _eventCache.DateTime.ToString("o", CultureInfo.CurrentCulture));
            }
            if ((this.TraceOutputOptions & TraceOptions.Callstack) != 0)
            {   // コールスタック（呼び出し履歴付加)
                builder.AppendLine(indent + "CallStack=" + _eventCache.Callstack);
            }
            return builder.ToString();
        }
        /// <summary>
        /// トレース情報に対応するメッセージを生成する
        /// </summary>
        /// <param name="_eventCache">固有のトレースイベント情報を表す<see cref="TraceEventCache"/></param>
        /// <param name="source">メッセージを出力するアプリケーション名を表す</param>
        /// <param name="_eventType">トレースイベントの種類を表す<see cref="TraceEventType"/></param>
        /// <param name="_id">トレースイベントの識別子を表す</param>
        /// <param name="_message">メッセージとして出力する文字列する</param>
        /// <returns>作成したトレースメッセージを表す</returns>
        protected virtual string CreateMessage(TraceEventCache _eventCache, string source, TraceEventType _eventType, int _id, string _message)
        {
            DateTime localTime;
            TimeZoneInfo tzi = TimeZoneInfo.Local;
            localTime = TimeZoneInfo.ConvertTimeFromUtc(_eventCache.DateTime, tzi);

            if (TraceOutputOptions == TraceOptions.None)
            {
                return string.Format(
                    CultureInfo.CurrentCulture,
                    DateTimeFormat + ":{1,12}: {2}", localTime, _eventType.ToString(), _message);
            }
            else
            {
                return string.Format(
                    CultureInfo.CurrentCulture,
                    DateTimeFormat + ":{1,12}: {2}", localTime, _eventType.ToString(), _message) + Environment.NewLine + CreateOptionString(_eventCache);
            }
        }
        /// <summary>
        /// トレース情報に対応するトレースメッセージを作成します。
        /// </summary>
        /// <param name="_eventCache">固有のトレースイベント情報を表す<see cref="TraceEventCache"/></param>
        /// <param name="source">メッセージを出力するアプリケーション名を表す</param>
        /// <param name="_eventType">トレースイベントの種類を表す<see cref="TraceEventType"/></param>
        /// <param name="_id">トレースイベントの識別子を表す</param>
        /// <param name="args">メッセージとして出力するデータを表す </param>
        /// <returns>作成したトレースメッセージを表す</returns>
        protected virtual string CreateMessage(TraceEventCache _eventCache, string _source, TraceEventType _eventType, int _id, params object[] args)
        {
            if (args != null && args.Length > 0)
            {
                StringBuilder builder = new StringBuilder(args[0].ToString());
                for (int i = 1; i < args.Length; i++)
                {
                    if (args[i] != null)
                    {
                        builder.Append(", " + args[i].ToString());
                    }
                }
                return CreateMessage(_eventCache, _source, _eventType, _id, builder.ToString());
            }
            else
            {
                return CreateMessage(_eventCache, _source, _eventType, _id, null as string);
            }
        }
        /// <summary>
        /// トレース情報に対応するトレースメッセージを作成します。
        /// </summary>
        /// <param name="_eventCache">固有のトレースイベント情報を表す<see cref="TraceEventCache"/></param>
        /// <param name="source">メッセージを出力するアプリケーション名を表す</param>
        /// <param name="_eventType">トレースイベントの種類を表す<see cref="TraceEventType"/></param>
        /// <param name="_id">トレースイベントの識別子を表す</param>
        /// <param name="_format">メッセージの複合書式指定文字列を表す</param>
        /// <param name="args"><paramref name="format"/> に対応する出力データを表す object[]。</param>
        /// <returns></returns>
        protected virtual string CreateMessage(TraceEventCache _eventCache, string _source, TraceEventType _eventType, int _id, string _format, params object[] args)
        {
            if (args != null)
            {
                return CreateMessage(_eventCache, _source, _eventType, _id, string.Format(CultureInfo.CurrentCulture, _format, args));
            }
            else
            {
                return CreateMessage(_eventCache, _source, _eventType, _id, _format);
            }
        }
        #endregion
        #region メソッド(内部)
        private void CalculateFileSize(int _appendLength)
        {
            DateTime now = DateTime.Now;

            if (Writer == null || now.Date != LastUpdate)
            {
                CloseStream();
                this.FileNumber = 0;
                this.LastUpdate = now.Date;
                string path = string.Format(CultureInfo.CurrentCulture, OutputDirectory + FileNameFormat, LastUpdate, FileNumber);
                this.CurrentFile = new FileInfo(path);

                if (Writer == null)
                {
                    if (CurrentFile.Directory.Exists == false)
                    {
                        Directory.CreateDirectory(OutputDirectory);
                        CurrentFile.Directory.Create();
                    }
                }
            }
            CurrentFile.Refresh();
            while (CurrentFile.Exists == true && MaxSize > 0 && CurrentFile.Length + _appendLength > MaxSize)
            {
                CloseStream();
                FileNumber += 1;
                this.CurrentFile = new FileInfo(
                    string.Format(CultureInfo.CurrentCulture, OutputDirectory + FileNameFormat, LastUpdate, FileNumber));
            }
            if (Writer == null)
            {
                Writer = new StreamWriter(
                    new FileStream(CurrentFile.FullName, FileMode.Append, FileAccess.Write, FileShare.Read),
                    this.Encording);
            }
        }
        private void WriteInternal(string _message)
        {
            try
            {
                if (NeedIndent == true && IndentLevel > 0)
                {	// 出力行に対して、インデントが必要な場合
                    NeedIndent = false;
                    _message = new string(' ', IndentSize * IndentLevel) + _message;
                }
                CalculateFileSize(this.Encording.GetByteCount(_message));
                Writer.Write(_message);
                Writer.Flush();
            }
            catch (Exception)
            {
                return;
            }
        }
        /// <summary>
        /// ストリームを閉じる
        /// 一緒に、ストリームは破棄する
        /// </summary>
        private void CloseStream()
        {
            try
            {
                if (Writer != null)
                {
                    Writer.Flush();
                    Writer.Close();
                    Writer.Dispose();
                    Writer = null;
                }
            }
            catch (Exception)
            {
                Debug.WriteLine("LOG:Close中の例外");
                return;
            }
        }
        #endregion
        #region メソッド(override)
        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, params object[] data)
        {
            lock (syncObj_)
            {
                if (Filter == null || Filter.ShouldTrace(eventCache, source, eventType, id, null, null, null, data) == true)
                {
                    WriteInternal(CreateMessage(eventCache, source, eventType, id, data));
                }
            }
        }
        public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, object data)
        {
            lock (syncObj_)
            {
                if (Filter == null || Filter.ShouldTrace(eventCache, source, eventType, id, null, null, data, null) == true)
                {
                    WriteInternal(CreateMessage(eventCache, source, eventType, id, data));
                }
            }
        }
        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string format, params object[] args)
        {
            lock (syncObj_)
            {
                if (Filter == null || Filter.ShouldTrace(eventCache, source, eventType, id, format, args, null, null) == true)
                {
                    WriteInternal(CreateMessage(eventCache, source, eventType, id, format.TrimEnd(new char[] { '\r', '\n' }) + Environment.NewLine, args));
                }
            }
        }
        public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message)
        {
            lock (syncObj_)
            {
                if (Filter == null || Filter.ShouldTrace(eventCache, source, eventType, id, message, null, null, null) == true)
                {
                    message = message.TrimEnd(new char[] { '\r', '\n' }) + Environment.NewLine;
                    WriteInternal(CreateMessage(eventCache, source, eventType, id, message));
                }
            }
        }
        public override void Write(string message)
        {
            lock (syncObj_)
            {
                WriteInternal(message);
            }
        }
        public override void WriteLine(string message)
        {
            lock (syncObj_)
            {
                message.TrimEnd(new char[] { '\r', '\n' });
                WriteInternal(message + Environment.NewLine);
            }
        }
        #endregion
        #region プロパティ
        /// <summary>
        ///  スレッドセーフかどうか？
        /// </summary>
        public override bool IsThreadSafe { get { return true; } }
        /// <summary>テキストライタを取得または設定します。</summary>
        public TextWriter Writer { get; set; }
        /// <summary>
        /// 1ファイルの最大サイズ
        /// </summary>
        public long MaxSize { get; set; }
        /// <summary>
        /// 同年月日のファイルの通し番号
        /// </summary>
        public int FileNumber { get; protected set; }
        /// <summary>
        /// ファイル名の書式を取得/設定します
        /// {0}：日時部分
        /// {1}：ファイル通番部分
        /// </summary>
        public string FileNameFormat { get; set; }
        /// <summary>
        /// 出力ファイルに付随する日時書式部分を取得/設定します
        /// <see cref="DateTime"/>
        /// </summary>
        public string DateTimeFormat { get; set; }
        /// <summary>
        /// ファイルの最終更新日時を取得/設定します
        /// </summary>
        public DateTime LastUpdate { get; protected set; }
        /// <summary>
        /// ログファイルを出力するディレクトリを設定します
        /// </summary>
        public string OutputDirectory { get; set; }
        /// <summary>
        /// 記録するエンコーディング形式を設定／取得する
        /// </summary>
        public Encoding Encording { get; set; }
        /// <summary>
        /// 最大サイズを指定しない場合のデフォルト値
        /// </summary>
        public long DefaultMaxSize { get { return (1024 * 1024); } }
        /// <summary>
        /// ファイルネームの書式文字列の指定
        /// </summary>
        public string DefaultFileNameFormat { get { return "{0}_{1}"; } }
        /// <summary>
        /// 日付書式のDefault値
        /// </summary>
        public string DefaultDateTimeFormat { get { return "{0:yyyy/MM/dd HH:mm:ss.fff}"; } }
        /// <summary>
        /// テキストエンコーディングのDefault値
        /// </summary>
        public Encoding DefaultEncording { get { return Encoding.GetEncoding(932); } }
        /// <summary>
        /// 現在開いているファイル情報を取得
        /// </summary>
        public FileInfo CurrentFile { get; set; }
        /// <summary>サポートされるカスタム属性を取得します。</summary>
        /// <returns>カスタム属性名を表す string[]。</returns>
        protected override string[] GetSupportedAttributes()
        {
            return new string[] { "maxSize", "outputDirectory", "fileNameFormat", "datetimeFormat", "encoding" };
        }
        #endregion
    }



}
