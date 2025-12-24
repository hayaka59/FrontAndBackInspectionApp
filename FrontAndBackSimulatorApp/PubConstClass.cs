using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontAndBackSimulatorApp
{
    internal class PubConstClass
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

        public const string DEF_VERSION = "Ver.20.25.12.24";                        // バージョン情報（メジャー.マイナー.ビルド.リビジョン） 
        public static object objSyncHist;

        public const string DEF_FILENAME = "FrontAndBackSimulatorApp.def";          // DEFファイル名称

        // 保守画面
        // COMポート
        public const string DEF_COMPORT         = "COMポート名";
        public const string DEF_COM_SPEED       = "COM通信速度";
        public const string DEF_COM_DATA_LENGTH = "COMデータ長";
        public const string DEF_COM_IS_PARITY   = "COMパリティ有無";
        public const string DEF_COM_PARITY_VAR  = "COMパリティ種別";
        public const string DEF_COM_STOPBIT     = "COMストップビット";

        public static string pblMainFormTitle;
        // COMポート
        public static string pblComPort;                                        // COMポート名
        public static string pblComSpeed;                                       // 通信速度
        public static string pblComDataLength;                                  // データ長（0：8bit／1：7bit）
        public static string pblComIsParity;                                    // パリティの有無（0：無効／1：有効）
        public static string pblComParityVar;                                   // パリティ種別（0：奇数／1：偶数）
        public static string pblComStopBit;                                     // ストップビット（0：1bit／1：2bit）
    }
}
