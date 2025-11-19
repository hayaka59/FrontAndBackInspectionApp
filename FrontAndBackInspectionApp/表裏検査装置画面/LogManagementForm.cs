using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontAndBackInspectionApp.表裏検査装置画面
{
    public partial class LogManagementForm : Form
    {
        public LogManagementForm()
        {
            InitializeComponent();
        }

        private void LogManagementForm_Load(object sender, EventArgs e)
        {
            try
            {
                LblTitle.Text = "表裏検査装置　ログ管理画面";
                LblVersion.Text = PubConstClass.DEF_VERSION;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【LogManagementForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
