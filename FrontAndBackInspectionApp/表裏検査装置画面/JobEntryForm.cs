using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontAndBackInspectionApp.表裏検査装置画面
{
    public partial class JobEntryForm : Form
    {
        public JobEntryForm()
        {
            InitializeComponent();
        }

        private void JobEntryForm_Load(object sender, EventArgs e)
        {
            try
            {
                LblTitle.Text = "表裏検査装置　ジョブ登録画面";
                LblVersion.Text = PubConstClass.DEF_VERSION;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【JobEntryForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            try
            {
                this.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【JobEntryForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
