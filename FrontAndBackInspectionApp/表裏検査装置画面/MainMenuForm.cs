using FrontAndBackInspectionApp;
using Kinoshita.Lib;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FrontAndBackInspectionApp.表裏検査装置画面
{
    public partial class MainMenuForm : Form
    {

        public MainMenuForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// フォームロード処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            try
            {
                LblTitle.Text = "表裏検査装置　メインメニュー";
                LblVersion.Text = PubConstClass.DEF_VERSION;

                TimDateTime.Interval = 1000;        // 1秒ごとにタイマーイベントを発生させる
                TimDateTime.Enabled = true;         // タイマーを有効にする
                KeyPreview = true;             // フォームでキーイベントを取得できるようにする

                // ログファイル及び操作履歴ファイルの削除処理
                //CommonModule.DeleteOldFiles();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【MainMenuForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「終了」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEnd_Click(object sender, EventArgs e)
        {
            try
            {
                Log.OutPutLogFile(TraceEventType.Information, "■【メインメニュー画面（MainmenuForm）】「終了」ボタンクリック");
                DialogResult dialogResult = MessageBox.Show("終了しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnEnd_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 現在時刻表示タイマー
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimDateTime_Tick(object sender, EventArgs e)
        {
            try
            {
                // 現在時刻の表示
                LblDateTime.Text = DateTime.Now.ToString("yyyy年MM月dd日(ddd) HH:mm:ss");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【TimDateTime_Tick】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ファンクションキー押下処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FunctionKey_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                switch (e.KeyCode)
                {
                    case Keys.F12:
                        Log.OutPutLogFile(TraceEventType.Information, "■「F12：終了」キー押下");
                        BtnEnd_Click(sender, e);
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【FunctionKey_KeyDown】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「検査処理」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnInspect_Click(object sender, EventArgs e)
        {
            try
            {
                Log.OutPutLogFile(TraceEventType.Information, "メインメニュー画面：「検査処理」ボタンクリック");
                SelectJobForm form = new SelectJobForm();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnInspect_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「登録」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEntry_Click(object sender, EventArgs e)
        {
            try
            {
                Log.OutPutLogFile(TraceEventType.Information, "メインメニュー画面：「登録」ボタンクリック");
                JobEntryForm form = new JobEntryForm();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnEntry_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLogManagement_Click(object sender, EventArgs e)
        {
            try
            {
                Log.OutPutLogFile(TraceEventType.Information, "メインメニュー画面：「ログ管理」ボタンクリック");
                LogManagementForm form = new LogManagementForm();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnLogManagement_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnMaintenance_Click(object sender, EventArgs e)
        {
            try
            {
                Log.OutPutLogFile(TraceEventType.Information, "メインメニュー画面：「保守」ボタンクリック");
                MaintenanceForm　form = new MaintenanceForm();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnMaintenance_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
