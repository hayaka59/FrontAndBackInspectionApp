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
    public partial class SelectJobForm : Form
    {
        public SelectJobForm()
        {
            InitializeComponent();
        }

        private void SelectJobForm_Load(object sender, EventArgs e)
        {
            try
            {
                LblTitle.Text = "表裏検査装置　ジョブ選択画面";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【SelectJobForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
