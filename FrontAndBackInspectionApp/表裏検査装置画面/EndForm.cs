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
    public partial class EndForm : Form
    {
        public EndForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EndForm_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【EndForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Log.OutPutLogFile(TraceEventType.Information, "終了画面：「キャンセル」ボタンクリック");
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnCancel_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEnd_Click(object sender, EventArgs e)
        {
            try
            {
                Log.OutPutLogFile(TraceEventType.Information, "終了画面：「終了実行」ボタンクリック");

                if (ChkShutDown.Checked)
                { 
                    TryShutdownWindows();
                }                
                // アプリケーションを終了します
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnEnd_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void TryShutdownWindows()
        {
            var psi = new ProcessStartInfo
            {
                FileName = "shutdown",
                Arguments = "/s /t 0", // /s: シャットダウン, /t 0: 即時
                UseShellExecute = true,
                Verb = "runas",        // 管理者として実行（UAC昇格）
                CreateNoWindow = true
            };

            //var psi = new ProcessStartInfo
            //{
            //    FileName = "notepad",
            //    //Arguments = "/s /t 0", // /s: シャットダウン, /t 0: 即時
            //    UseShellExecute = true,
            //    //Verb = "runas",        // 管理者として実行（UAC昇格）
            //    CreateNoWindow = false
            //};

            try
            {
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                // 権限拒否などの例外ハンドリング
                MessageBox.Show("シャットダウンの開始に失敗しました。\n" + ex.Message,
                                "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
