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
    public partial class DrivingForm : Form
    {
        public DrivingForm()
        {
            InitializeComponent();
        }

        private void DrivingForm_Load(object sender, EventArgs e)
        {
            try
            {
                LblTitle.Text = "表裏検査装置　検査画面";
                LblVersion.Text = PubConstClass.DEF_VERSION;

                TimDateTime.Interval = 1000;
                TimDateTime.Enabled = true; 

                // 選択ジョブ項目を取得し表示
                CommonModule.GetSelectJobItem(TxtJobName, LtbJobDataInfo);

                // 選択JOB検査内容表示リストビューの設定
                LtbJobDataInfo.DrawMode = DrawMode.OwnerDrawFixed;
                LtbJobDataInfo.DrawItem += LtbJobDataInfo_DrawItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【DrivingForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// リストビューのカスタム描画処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LtbJobDataInfo_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            // 背景色を交互に設定
            //Color backColor = (e.Index % 2 == 0) ? Color.LightGray : Color.White;
            Color backColor = (e.Index % 2 != 0) ? Color.LightCyan : Color.White;
            // 選択状態ならハイライト
            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                backColor = SystemColors.Highlight;
            }
            using (SolidBrush brush = new SolidBrush(backColor))
            {
                e.Graphics.FillRectangle(brush, e.Bounds);
            }
            // テキスト描画
            using (SolidBrush textBrush = new SolidBrush(e.ForeColor))
            {
                e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
                                      e.Font, textBrush, e.Bounds);
            }
            e.DrawFocusRectangle();
        }

        /// <summary>
        /// 
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
        private void BtnRun_Click(object sender, EventArgs e)
        {
            try
            {


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnRun_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStop_Click(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnStop_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 現在時刻表示タイマー処理
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
    }
}
