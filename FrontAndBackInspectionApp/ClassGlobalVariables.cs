using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontAndBackInspectionApp
{
    class ClassGlobalVariables
    {

        public static Boolean IsInspect = false;
        
        #region 通信ポート設定
        // 使用ポート
        public static string strUsePort = "";
        // 通信ポート
        public static string strComPort = "";
        // 通信ボーレート
        public static string strComBaud = "";
        // データ長
        public static string strComLength = "";
        // パリティ（無効／有効）
        public static string strComParity = "";
        // パリティ（偶数／奇数）
        public static string strComEvenOdd = "";
        // ストップビット
        public static string strComStopBit = "";
        // OCR通信ポート
        public static string strOcrPort = "";
        #endregion
    }
}
