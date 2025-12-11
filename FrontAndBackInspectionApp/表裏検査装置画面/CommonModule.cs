using FrontAndBackInspectionApp;
using Kinoshita.Lib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.AxHost;

namespace FrontAndBackInspectionApp.表裏検査装置画面
{
    static class CommonModule
    {
        /// <summary>
        /// フォルダの末尾の「\」を保証する
        /// </summary>
        /// <param name="strCheckFolder">チェック対象のフォルダ名称</param>
        /// <returns>チェック後のフォルダ名称</returns>
        /// <remarks></remarks>
        public static string IncludeTrailingPathDelimiter(string strCheckFolder)
        {
            string IncludeTrailingPathDelimiter;
            try
            {
                if (strCheckFolder.Substring(strCheckFolder.Length - 1, 1) == @"\")
                    IncludeTrailingPathDelimiter = strCheckFolder;
                else
                    IncludeTrailingPathDelimiter = strCheckFolder + @"\";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【IncludeTrailingPathDelimiter】", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "";
            }
            return IncludeTrailingPathDelimiter;
        }

        /// <summary>
        /// システム定義ファイルの読込処理
        /// </summary>
        /// <remarks></remarks>
        public static void ReadSystemDefinition()
        {
            string strReadDataPath;
            string[] strArray;

            try
            {
                strReadDataPath = IncludeTrailingPathDelimiter(Application.StartupPath) + PubConstClass.DEF_FILENAME;

                using (StreamReader sr = new StreamReader(strReadDataPath, Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        strArray = sr.ReadLine().Split(',');
                        switch (strArray[0])
                        {
                            // 装置名称
                            case PubConstClass.DEF_MACHINE_NAME:
                                {
                                    PubConstClass.pblMachineName = strArray[1];
                                    break;
                                }
                            // ディスク空き容量
                            case PubConstClass.DEF_HDD_SPACE:
                                {
                                    PubConstClass.pblHddSpace = strArray[1];
                                    break;
                                }
                            // パスワード
                            case PubConstClass.DEF_PASSWORD:
                                {
                                    PubConstClass.pblPassword = strArray[1];
                                    break;
                                }
                            // ロゴ表示
                            case PubConstClass.DEF_LOGO_DISP:
                                {
                                    PubConstClass.pblLogoDisp = strArray[1];
                                    break;
                                }
                            // ログ保存期間
                            case PubConstClass.DEF_LOGSAVE_MONTH:
                                {
                                    PubConstClass.pblLogSaveMonth = strArray[1];
                                    break;
                                }
                            // ロフフォルダ
                            case PubConstClass.DEF_LOG_FOLDER:
                                {
                                    PubConstClass.pblLogFolder = strArray[1];
                                    break;
                                }
                            // バックアップログフォルダ
                            case PubConstClass.DEF_BACKUP_FOLDER:
                                {
                                    PubConstClass.pblBackupFolder = strArray[1];
                                    break;
                                }
                            // COMポート名
                            case PubConstClass.DEF_COMPORT:
                                {
                                    PubConstClass.pblComPort = strArray[1];
                                    break;
                                }
                            // COM通信速度
                            case PubConstClass.DEF_COM_SPEED:
                                {
                                    PubConstClass.pblComSpeed = strArray[1];
                                    break;
                                }
                            // COMデータ長
                            case PubConstClass.DEF_COM_DATA_LENGTH:
                                {
                                    PubConstClass.pblComDataLength = strArray[1];
                                    break;
                                }
                            // COMパリティ有無
                            case PubConstClass.DEF_COM_IS_PARITY:
                                {
                                    PubConstClass.pblComIsParity = strArray[1];
                                    break;
                                }
                            // COMパリティ種別
                            case PubConstClass.DEF_COM_PARITY_VAR:
                                {
                                    PubConstClass.pblComParityVar = strArray[1];
                                    break;
                                }
                            // COMストップビット
                            case PubConstClass.DEF_COM_STOPBIT:
                                {
                                    PubConstClass.pblComStopBit = strArray[1];
                                    break;
                                }
                            default:
                                {
                                    break;
                                }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【ReadSystemDefinition】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// システム定義ファイルの書込処理
        /// </summary>
        /// <remarks></remarks>
        public static void WriteSystemDefinition()
        {
            string strPutDataPath;

            try
            {
                strPutDataPath = IncludeTrailingPathDelimiter(Application.StartupPath) + PubConstClass.DEF_FILENAME;

                // 上書モードで書き込む
                using (StreamWriter sw = new StreamWriter(strPutDataPath, false, Encoding.Default))
                {
                    // 装置名称
                    sw.WriteLine(PubConstClass.DEF_MACHINE_NAME + "," + PubConstClass.pblMachineName);
                    // ディスク空き容量
                    sw.WriteLine(PubConstClass.DEF_HDD_SPACE + "," + PubConstClass.pblHddSpace);
                    // パスワード
                    sw.WriteLine(PubConstClass.DEF_PASSWORD + "," + PubConstClass.pblPassword);
                    // ロゴ表示
                    sw.WriteLine(PubConstClass.DEF_LOGO_DISP + "," + PubConstClass.pblLogoDisp);
                    // ログ保存期間
                    sw.WriteLine(PubConstClass.DEF_LOGSAVE_MONTH + "," + PubConstClass.pblLogSaveMonth);
                    // ログフォルダ
                    sw.WriteLine(PubConstClass.DEF_LOG_FOLDER + "," + PubConstClass.pblLogFolder);
                    // バックアップログフォルダ
                    sw.WriteLine(PubConstClass.DEF_BACKUP_FOLDER + "," + PubConstClass.pblBackupFolder);
                    // COMポート名
                    sw.WriteLine(PubConstClass.DEF_COMPORT + "," + PubConstClass.pblComPort);
                    // COM通信速度
                    sw.WriteLine(PubConstClass.DEF_COM_SPEED + "," + PubConstClass.pblComSpeed);
                    // COMデータ長
                    sw.WriteLine(PubConstClass.DEF_COM_DATA_LENGTH + "," + PubConstClass.pblComDataLength);
                    // COMパリティ有無
                    sw.WriteLine(PubConstClass.DEF_COM_IS_PARITY + "," + PubConstClass.pblComIsParity);
                    // COMパリティ種別
                    sw.WriteLine(PubConstClass.DEF_COM_PARITY_VAR + "," + PubConstClass.pblComParityVar);
                    // COMストップビット
                    sw.WriteLine(PubConstClass.DEF_COM_STOPBIT + "," + PubConstClass.pblComStopBit);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【WritetSystemDefinition】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void CheckAvairableFreeSpace()
        {
            long lngAvailableValue;
            string strMessage;

            try
            {
                DriveInfo drive = new DriveInfo(PubConstClass.pblLogFolder.Substring(0, 1));

                if (drive.IsReady == true)
                {
                    lngAvailableValue = drive.AvailableFreeSpace;

                    if ((lngAvailableValue / (double)1024 / 1024 / 1024) < Convert.ToDouble(PubConstClass.pblHddSpace))
                    {
                        strMessage = "ドライブ「" + PubConstClass.pblLogFolder.Substring(0, 1) + "」の空き領域（" +
                            (lngAvailableValue / (double)1024 / 1024 / 1024).ToString("F1") + " GB）が、" + PubConstClass.pblHddSpace + " GB より少なくなっています。";
                        // MsgBox("空き領域：" & (lngAvailableValue / 1024 / 1024 / 1024).ToString & " GB")                        
                        MessageBox.Show(strMessage, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【CheckAvairableFreeSpace】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 下記の古いファイルの削除処理
        /// 　① ～\LOG\RESULTS\検査ログ_YYYYMMDD_hhmmss.txt       
        /// 　② ～\LOG\ERROR\error_YYYYMMDD_hhmmss.txt
        /// 　------------------------------------------------------------
        /// 　③ ～\LOG\JOB\assign_元の封入ファイル名.txt
        /// 　④ ～\LOG\UNPROCESSED\unprocessed_元の封入ファイル名.csv
        /// 　⑤ ～\LOG\WORK\work_YYYYMMDD_hhmmss.csv
        /// 　------------------------------------------------------------
        /// 　⑥ ～\OPHISTORYLOG\操作履歴ログ_YYYYMMDD.LOG
        /// 　⑦ ～\OPHISTORYLOG\通信ログ_YYYYMMDD.LOG
        /// </summary>
        /// <returns></returns>
        public static bool DeleteOldFiles()
        {
            string sPath;
            string sDelDate;

            try
            {
                DateTime dtData = DateTime.Now;
                sDelDate = dtData.AddMonths(-int.Parse(PubConstClass.pblLogSaveMonth)).ToString("yyyyMMdd");

                //////////////////////////////
                /// 検査ログ格納パスの設定 ///
                //////////////////////////////
                //sPath = CommonModule.IncludeTrailingPathDelimiter(PubConstClass.pblSharedFolder2) + "RESULTS1";
                //DeleteOldFilesSub(sPath, "検査ログ", PubConstClass.pblLogSaveMonth);

                ////////////////////////////////
                /// エラーログ格納パスの設定 ///
                ////////////////////////////////
                //sPath = CommonModule.IncludeTrailingPathDelimiter(PubConstClass.pblSharedFolder2) + "ERROR1";
                //DeleteOldFilesSub(sPath, "error", PubConstClass.pblLogSaveMonth);

                //////////////////////////////////////////
                /// 操作履歴ログファイル格納パスの設定 ///
                //////////////////////////////////////////
                sPath = Environment.CurrentDirectory + @"\OPHISTORYLOG";
                DeleteOldFilesSub(sPath, "操作履歴ログ", PubConstClass.pblLogSaveMonth);

                //////////////////////////////////////
                /// 通信ログファイル格納パスの設定 ///
                //////////////////////////////////////
                sPath = Environment.CurrentDirectory + @"\OPHISTORYLOG";
                DeleteOldFilesSub(sPath, "通信ログ", PubConstClass.pblLogSaveMonth);

                return true;
            }
            catch (Exception ex)
            {
                Log.OutPutLogFile(TraceEventType.Error, "エラー【DeleteOldFiles】:" + ex.Message);
                MessageBox.Show(ex.StackTrace, "エラー【DeleteOldFiles】", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// 指定されたフォルダの指定されたファイル名を含むファイルの削除処理
        /// </summary>
        /// <param name="sPath"></param>
        /// <param name="sLogSaveMonth"></param>
        /// <returns> </returns>
        public static bool DeleteOldFilesSub(string sPath, string sPrefixName, string sLogSaveMonth)
        {
            string[] sAray;

            try
            {
                if (!Directory.Exists(sPath))
                {
                    // フォルダが存在しなかったら作成する
                    Directory.CreateDirectory(sPath);
                    Log.OutPutLogFile(TraceEventType.Information, $"フォルダ（{sPath}）を作成しました");
                    return true;
                }

                DateTime dtDataTime = DateTime.Now;
                DateTime sDelDateTime = dtDataTime.AddMonths(-int.Parse(sLogSaveMonth));
                Log.OutPutLogFile(TraceEventType.Information, $"削除基準年月日「{sDelDateTime}」【先頭文字：{sPrefixName}】");

                string[] tagetFiles = Directory.GetFiles(sPath);
                foreach (string file in tagetFiles)
                {
                    sAray = file.Split('\\');
                    if (sAray[sAray.Length - 1].Substring(0, sPrefixName.Length) == sPrefixName)
                    {
                        // 先頭文字が、sPrefixName と等しい場合は削除対象ファイルかどうか評価する 
                        DateTime creationTime = File.GetCreationTime(file);
                        if (creationTime < sDelDateTime)
                        {
                            File.Delete(file);
                            Log.OutPutLogFile(TraceEventType.Information, $"【DeleteOldFilesSub】削除しました: {file}");
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.OutPutLogFile(TraceEventType.Error, "エラー【DeleteOldFilesSub】:" + ex.Message);
                MessageBox.Show(ex.StackTrace, "エラー【DeleteOldFilesSub】", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        /// <summary>
        /// ジョブ登録情報の読取処理
        /// </summary>
        /// <param name="sFileName"></param>
        public static void ReadJobEntryListFile(string sFileName)
        {
            string sData;

            try
            {
                using (StreamReader sr = new StreamReader(sFileName, Encoding.Default))
                {
                    sData = sr.ReadLine();
                    PubConstClass.sJobEntryData = sData;                                       
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ジョブ登録ファイル読み込みエラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        /// <summary>
        /// 選択ジュブ項目を取得し表示する
        /// </summary>
        public static void GetSelectJobItem(TextBox textBox, ListBox listBox)
        {
            string[] sArray;
            double dData;
            string sData;
            string sMessage;
            try
            {
                int iIndex = 0;
                sArray = PubConstClass.sJobEntryData.Split(',');
                // JOB名
                textBox.Text = sArray[iIndex++];

                PubConstClass.sJobSettingData = "";
                listBox.Items.Clear();                
                dData = (double.Parse(sArray[iIndex++]) + 30) / 10;
                listBox.Items.Add($"用紙デプス          ：{dData:0.0} インチ");
                listBox.Items.Add($"カメラ読取位置（上）：{int.Parse(sArray[iIndex++]) + 1} ｍｍ");
                listBox.Items.Add($"カメラ読取位置（下）：{int.Parse(sArray[iIndex++]) + 1} ｍｍ");
                listBox.Items.Add($"照合桁              ：{int.Parse(sArray[iIndex++]) + 1} 桁");
                listBox.Items.Add($"照合開始位置（上）  ：{int.Parse(sArray[iIndex++]) + 1} 桁目から");
                listBox.Items.Add($"照合開始位置（下）  ：{int.Parse(sArray[iIndex++]) + 1} 桁目から");
                sData = sArray[iIndex++];
                if (sData == "0")
                {
                    listBox.Items.Add($"停止設定            ：停止なし");
                }
                else
                {
                    listBox.Items.Add($"停止設定            ：{int.Parse(sData)} 回");
                }
                sData = sArray[iIndex++];
                sMessage = "";
                switch (sData)
                {
                    case "0":
                        sMessage = "昇順";
                        break;
                    case "1":
                        sMessage = "降順";
                        break;
                    case "2":
                        sMessage = "検査なし";
                        break;
                }
                listBox.Items.Add($"連番検査            ：{sMessage}");
                listBox.Items.Add($"カメラJOB番号       ：{int.Parse(sArray[iIndex++]) + 1}");


                iIndex = 1;     // JOB名をスキップするために 1 に設定する
                PubConstClass.sJobSettingData = "Za,";
                PubConstClass.sJobSettingData += (double.Parse(sArray[iIndex++]) + 30).ToString("000") + ",";
                PubConstClass.sJobSettingData += (int.Parse(sArray[iIndex++]) + 1).ToString("000") + ",";
                PubConstClass.sJobSettingData += (int.Parse(sArray[iIndex++]) + 1).ToString("000") + ",";
                PubConstClass.sJobSettingData += (int.Parse(sArray[iIndex++]) + 1).ToString("0") + ",";
                PubConstClass.sJobSettingData += (int.Parse(sArray[iIndex++]) + 1).ToString("00") + ",";
                PubConstClass.sJobSettingData += (int.Parse(sArray[iIndex++]) + 1).ToString("00") + ",";

                // 停止設定
                PubConstClass.sJobSettingData += sArray[iIndex++] + ",";
                // 連番検査
                sData = sArray[iIndex++];
                //sMessage = "";
                switch (sData)
                {
                    case "0":
                        //sMessage = "昇順";
                        PubConstClass.sJobSettingData += "1,";
                        break;
                    case "1":
                        //sMessage = "降順";
                        PubConstClass.sJobSettingData += "2,";
                        break;
                    case "2":
                        //sMessage = "検査なし";
                        PubConstClass.sJobSettingData += "0,";
                        break;
                }
                // カメラJOB番号
                PubConstClass.sJobSettingData += (int.Parse(sArray[iIndex++]) + 1).ToString("000") + ",";

                listBox.Items.Add($"設定データ：{PubConstClass.sJobSettingData}");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "【GetSelectJobItem】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




    }
}
