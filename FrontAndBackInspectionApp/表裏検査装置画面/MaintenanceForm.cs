using Kinoshita.Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontAndBackInspectionApp.表裏検査装置画面
{
    public partial class MaintenanceForm : Form
    {
        public MaintenanceForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームロード処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MaintenanceForm_Load(object sender, EventArgs e)
        {
            try
            {
                LblTitle.Text = "表裏検査装置　保守画面";
                LblVersion.Text = PubConstClass.DEF_VERSION;

                Log.OutPutLogFile(TraceEventType.Information, "保守画面を表示しました");

                CommonModule.ReadSystemDefinition();

                // 号機名
                TxtMachineName.Text = PubConstClass.pblMachineName;

                // ディスク空き容量チェック
                TxtHddSpace.Text = PubConstClass.pblHddSpace;

                // パスワード
                TxtPassword.Text = PubConstClass.pblPassword;

                // ロゴ表示
                ChkIsDispLogo.Checked = (PubConstClass.pblLogoDisp == "1") ? true : false;

                #region ログ保存
                CmbSaveMonth.Items.Clear();
                for (int N = 1; N <= 36; N++)
                {
                    CmbSaveMonth.Items.Add(N.ToString() + "ヶ月");
                }
                if (PubConstClass.pblLogSaveMonth != "")
                {
                    CmbSaveMonth.SelectedIndex = Convert.ToInt32(PubConstClass.pblLogSaveMonth) - 1;
                }
                else
                {
                    CmbSaveMonth.SelectedIndex = 0;
                }
                #endregion

                // ログフォルダ
                TxtLogFoloder.Text = PubConstClass.pblLogFolder;
                // バックアップログフォルダ
                TxtBackupFolder.Text = PubConstClass.pblBackupFolder;

                // COMポート名
                CmbComPort.Items.Clear();
                for (int iIndex = 1; iIndex <= 15; iIndex++)
                    CmbComPort.Items.Add("COM" + Convert.ToString(iIndex));
                CmbComPort.SelectedIndex = Convert.ToInt32(PubConstClass.pblComPort.Substring(3, 1)) - 1;

                // COM通信速度
                CmbComSpeed.Items.Clear();
                CmbComSpeed.Items.Add("4800");
                CmbComSpeed.Items.Add("9600");
                CmbComSpeed.Items.Add("19200");
                CmbComSpeed.Items.Add("38400");
                CmbComSpeed.Items.Add("57600");
                CmbComSpeed.Items.Add("115200");
                CmbComSpeed.SelectedIndex = Convert.ToInt32(PubConstClass.pblComSpeed);

                // COMデータ長
                CmbComDataLength.Items.Clear();
                CmbComDataLength.Items.Add("8bit");
                CmbComDataLength.Items.Add("7bit");
                CmbComDataLength.SelectedIndex = Convert.ToInt32(PubConstClass.pblComDataLength);

                // COMパリティの有無
                CmbComIsParty.Items.Clear();
                CmbComIsParty.Items.Add("無効");
                CmbComIsParty.Items.Add("有効");
                CmbComIsParty.SelectedIndex = Convert.ToInt32(PubConstClass.pblComIsParity);

                // COMパリティ種別
                CmbComParityVar.Items.Clear();
                CmbComParityVar.Items.Add("奇数");
                CmbComParityVar.Items.Add("偶数");
                CmbComParityVar.SelectedIndex = Convert.ToInt32(PubConstClass.pblComParityVar);

                // COMストップビット
                CmbComStopBit.Items.Clear();
                CmbComStopBit.Items.Add("1bit");
                CmbComStopBit.Items.Add("2bit");
                CmbComStopBit.SelectedIndex = Convert.ToInt32(PubConstClass.pblComStopBit);





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【MaintenanceForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「戻る」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnBack_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChkIsDispLogo_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if(ChkIsDispLogo.Checked == true)
                {
                    PubConstClass.pblLogoDisp = "1";
                    PctLogo.Visible = true;
                }
                else
                {
                    PubConstClass.pblLogoDisp = "0";
                    PctLogo.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【ChkIsDispLogo_CheckedChanged】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
