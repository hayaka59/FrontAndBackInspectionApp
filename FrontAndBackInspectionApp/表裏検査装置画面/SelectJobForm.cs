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
                LblVersion.Text = PubConstClass.DEF_VERSION;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【SelectJobForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, "【BtnBack_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnNewStart_Click(object sender, EventArgs e)
        {
            try
            {
                Log.OutPutLogFile(TraceEventType.Information, "JOB選択画面画面：「運転開始」ボタンクリック");
                DrivingForm form = new DrivingForm();
                form.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnNewStart_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
