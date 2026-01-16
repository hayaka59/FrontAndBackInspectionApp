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
    public partial class PasswordForm : Form
    {
        Form _callingForm;

        public PasswordForm(Form form)
        {
            _callingForm = form;
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordForm_Load(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【PasswordForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「キャンセル」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Log.OutPutLogFile(TraceEventType.Information, "パスワード画面：「キャンセル」ボタンクリック");
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnCancel_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「OK」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOK_Click(object sender, EventArgs e)
        {
            try
            {
                Log.OutPutLogFile(TraceEventType.Information, "パスワード画面：「OK」ボタンクリック");
                if (PubConstClass.pblPassword != null)
                {
                    // パスワードが設定されていない時はパスワードチェックしない
                    if (MskTxtPassword.Text != PubConstClass.pblPassword)
                    {
                        MessageBox.Show("パスワードが違います。", "パスワードエラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                this.Hide();
                _callingForm.Hide();
                MaintenanceForm form = new MaintenanceForm();
                form.ShowDialog();
                _callingForm.Show();
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnOK_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MskTxtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // RETURNキーが押された時の処理
                e.Handled = true;
                BtnOK.PerformClick(); // OKボタンのクリックイベントを呼び出す
            }
        }
    }
}
