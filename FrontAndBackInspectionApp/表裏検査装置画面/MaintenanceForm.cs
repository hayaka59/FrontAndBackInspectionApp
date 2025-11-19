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
    public partial class MaintenanceForm : Form
    {
        public MaintenanceForm()
        {
            InitializeComponent();
        }

        private void MaintenanceForm_Load(object sender, EventArgs e)
        {
            try
            {
                LblTitle.Text = "表裏検査装置　保守画面";
                LblVersion.Text = PubConstClass.DEF_VERSION;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【MaintenanceForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
