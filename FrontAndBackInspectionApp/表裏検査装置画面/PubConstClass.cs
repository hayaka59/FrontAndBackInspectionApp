using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontAndBackInspectionApp.表裏検査装置画面
{
    public class PubConstClass
    {
        public const string CMD_SEND_A = "ZA";      // 
        public const string CMD_SEND_B = "ZB";      // 
        public const string CMD_SEND_C = "ZC";      // 
        public const string CMD_SEND_D = "ZD";      // 
        public const string CMD_SEND_E = "ZE";      // 

        public const string CMD_RECIEVE_a = "Za";   // 
        public const string CMD_RECIEVE_b = "Zb";   // 
        public const string CMD_RECIEVE_c = "Zc";   // 
        public const string CMD_RECIEVE_d = "Zd";   // 
        public const string CMD_RECIEVE_e = "Ze";   // 

        // システム定数
        public const string DEF_VERSION = "Ver.20.25.12.19";                    // バージョン情報（メジャー.マイナー.ビルド.リビジョン） 
        // システム定義ファイル
        public const string DEF_FILENAME = "FrontAndBackInspectionApp.def";
        // システム情報
        public static string sJobEntryData = "";    // 登録ジョブ情報
        public static bool bRunFlag = false;        // 運転中フラグ

        public static string sJobSettingData = "";  // JOB設定データ格納変数

        public const string LOG_TYPE_FULL_LOG       = "全数ログ";
        public const string LOG_TYPE_INSPECTION_LOG = "検査ログ";
        public const string LOG_TYPE_ERROR_LOG      = "エラー履歴ログ";

        public const string DEF_ERROR_FILE = "ErrorMessage.txt";                // エラーメッセージファイル名称
        public static Dictionary<string, string> dicErrorCodeData;              // エラーコード変換用辞書
        public static bool bIsOpenErrorMessage = false;                         // エラーメッセージ画面表示・非表示フラグ
        public static bool bIsErrorMessage = false;                             // true：エラーメッセージ／false：情報メッセージ

        /// <summary>
        /// 保守画面
        /// </summary>
        // 保守項目定数（システム設定）
        public const string DEF_MACHINE_NAME    = "装置名称";
        public const string DEF_HDD_SPACE       = "ディスク空き容量";
        public const string DEF_PASSWORD        = "パスワード";
        public const string DEF_LOGO_DISP       = "ロゴ表示";
        public const string DEF_LOGSAVE_MONTH   = "ログ保存期間";
        // 保守項目定数（フォルダ設定）
        public const string DEF_LOG_FOLDER      = "ログフォルダ";
        public const string DEF_BACKUP_FOLDER   = "バックアップログフォルダ";
        // COMポート１定数
        public const string DEF_COMPORT         = "COMポート名";
        public const string DEF_COM_SPEED       = "COM通信速度";
        public const string DEF_COM_DATA_LENGTH = "COMデータ長";
        public const string DEF_COM_IS_PARITY 　= "COMパリティ有無";
        public const string DEF_COM_PARITY_VAR  = "COMパリティ種別";
        public const string DEF_COM_STOPBIT     = "COMストップビット";        
        // 保守項目変数（システム設定）
        public static string pblMachineName;        // 号機名
        public static string pblHddSpace;           // ディスク空き容量
        public static string pblPassword;           // パスワード
        public static string pblLogoDisp;           // ロゴ表示
        public static string pblLogSaveMonth;       // ログ保存期間
        // 保守項目変数（フォルダ設定）
        public static string pblLogFolder;          // ロフフォルダ
        public static string pblBackupFolder;       // バックアップログフォルダ       
        // COMポート１変数
        public static string pblComPort;            // COMポート名
        public static string pblComSpeed;           // 通信速度
        public static string pblComDataLength;      // データ長（0：8bit／1：7bit）
        public static string pblComIsParity;        // パリティの有無（0：無効／1：有効）
        public static string pblComParityVar;       // パリティ種別（0：奇数／1：偶数）
        public static string pblComStopBit;         // ストップビット（0：1bit／1：2bit）
    }
}
