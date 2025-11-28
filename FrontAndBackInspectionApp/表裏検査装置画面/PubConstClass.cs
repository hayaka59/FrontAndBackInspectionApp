using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontAndBackInspectionApp.表裏検査装置画面
{
    public class PubConstClass
    {
        // システム定数
        public const string DEF_VERSION = "Ver.20.25.11.28";                    // バージョン情報（メジャー.マイナー.ビルド.リビジョン） 
        // システム定義ファイル
        public const string DEF_FILENAME = "FrontAndBackInspectionApp.def";
        // システム情報
        public static string sJobEntryData = "";    // 登録ジョブ情報
        public static bool bRunFlag = false;        // 運転中フラグ

        /// <summary>
        /// 保守画面
        /// </summary>
        // 保守項目（定数）
        public const string DEF_MACHINE_NAME    = "号機名称";
        public const string DEF_LOGSAVE_MONTH   = "ログ保存期間";
        public const string DEF_HDD_SPACE       = "ディスク空き容量";        
        public const string DEF_SHARED_FOLDER1  = "共有フォルダ１";
        public const string DEF_SHARED_FOLDER2  = "共有フォルダ２";
        public const string DEF_SHARED_FOLDER3  = "共有フォルダ３";
        public const string DEF_IP_ADDRESS      = "IPアドレス";
        public const string DEF_PORT            = "ポート番号";
        public const string DEF_DEFAULT_PRINTER = "通常使うプリンタ名";
        public const string DEF_QR_STRING       = "QR文字列";
        // COMポート１（定数）
        public const string DEF_COMPORT         = "COMポート名";
        public const string DEF_COM_SPEED       = "COM通信速度";
        public const string DEF_COM_DATA_LENGTH = "COMデータ長";
        public const string DEF_COM_IS_PARITY 　= "COMパリティ有無";
        public const string DEF_COM_PARITY_VAR  = "COMパリティ種別";
        public const string DEF_COM_STOPBIT     = "COMストップビット";
        
        // 保守項目（変数）
        public static string pblMachineName;        // 号機名                
        public static string pblSaveLogMonth;       // ログ保存期間
        public static string pblHddSpace;           // ディスク空き容量
        public static string pblSharedFolder1;      // 共有フォルダ１
        public static string pblSharedFolder2;      // 共有フォルダ２
        public static string pblSharedFolder3;      // 共有フォルダ３
        public static string pblIPAddress;          // ラベルプリンタ用のIPアドレス
        public static string pblPort;               // ラベルプリンタ用のポート
        public static string pblDefaultPrinter;     // 通常使うプリンタ名
        public static string pblQrString;           // QR文字列
        // COMポート１（変数）
        public static string pblComPort;            // COMポート名
        public static string pblComSpeed;           // 通信速度
        public static string pblComDataLength;      // データ長（0：8bit／1：7bit）
        public static string pblComIsParity;        // パリティの有無（0：無効／1：有効）
        public static string pblComParityVar;       // パリティ種別（0：奇数／1：偶数）
        public static string pblComStopBit;         // ストップビット（0：1bit／1：2bit）
    }
}
