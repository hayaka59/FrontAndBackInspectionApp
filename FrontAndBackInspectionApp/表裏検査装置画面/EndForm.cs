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


        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnCancel_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnEnd_Click(object sender, EventArgs e)
        {
            try
            {
                Log.OutPutLogFile(TraceEventType.Information, "終了画面：「終了実行」ボタンクリック");
                // アプリケーションを終了します
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnEnd_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
