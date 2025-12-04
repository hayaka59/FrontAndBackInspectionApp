using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrontAndBackInspectionApp.表裏検査装置画面
{
    public partial class DrivingForm : Form
    {
        private string _broadDivision;
        private string _subDivision;

        public DrivingForm(string broadDivision, string subDivision)
        {
            InitializeComponent();

            _broadDivision = broadDivision;
            _subDivision = subDivision;
        }

        /// <summary>
        /// フォームロード処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DrivingForm_Load(object sender, EventArgs e)
        {
            try
            {
                LblTitle.Text = "表裏検査装置　検査画面";
                LblVersion.Text = PubConstClass.DEF_VERSION;

                // ロゴ表示
                PctLogo.Visible = PubConstClass.pblLogoDisp == "1" ? true : false;

                // 現在時刻表示タイマー設定
                TimDateTime.Interval = 1000;
                TimDateTime.Enabled = true;

                LblOKCount.Text = "0";
                LblNGCount.Text = "0";
                LblMatchingErrorCount.Text = "0";
                LblSeqNumErrorCount.Text = "0";

                LblBroadDivision.Text= _broadDivision;  // 大区分の名称
                LblSubDivision.Text= _subDivision;      // 小区分の名称

                #region 検査履歴のヘッダー設定
                //LstReadData.View = View.Details;
                ColumnHeader colOK1 = new ColumnHeader();
                ColumnHeader colOK2 = new ColumnHeader();
                ColumnHeader colOK3 = new ColumnHeader();
                ColumnHeader colOK4 = new ColumnHeader();
                ColumnHeader colOK5 = new ColumnHeader();
                SetHeaderData(LstReadData, colOK1, colOK2, colOK3, colOK4, colOK5);
                #endregion

                #region エラー履歴のヘッダー設定
                //LstError.View = View.Details;
                ColumnHeader colNG1 = new ColumnHeader();
                ColumnHeader colNG2 = new ColumnHeader();
                ColumnHeader colNG3 = new ColumnHeader();
                ColumnHeader colNG4 = new ColumnHeader();
                ColumnHeader colNG5 = new ColumnHeader();
                SetHeaderData(LstError, colNG1, colNG2, colNG3, colNG4, colNG5);
                #endregion

                lblTranOSCount.Text = "0 件";
                lblTranOSNGCount.Text = "0 件";

                // リストビューのダブルバッファを有効とする
                EnableDoubleBuffering(LstReadData);
                EnableDoubleBuffering(LstError);

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
        /// ヘッダータイトルの作成
        /// </summary>
        /// <param name="listView"></param>
        /// <param name="col1"></param>
        /// <param name="col2"></param>
        /// <param name="col3"></param>
        /// <param name="col4"></param>
        /// <param name="col5"></param>
        private void SetHeaderData(ListView listView, ColumnHeader col1, ColumnHeader col2, ColumnHeader col3, ColumnHeader col4, ColumnHeader col5)
        {
            try
            {
                listView.View = View.Details;
                
                col1.Text = "　　　日時";
                col2.Text = "読取番号（表裏）";
                col3.Text = "読取結果（表裏）";
                col4.Text = "裏表一致判定";
                col5.Text = "連番判定";

                col1.TextAlign = HorizontalAlignment.Center;
                col2.TextAlign = HorizontalAlignment.Center;
                col3.TextAlign = HorizontalAlignment.Center;
                col4.TextAlign = HorizontalAlignment.Center;
                col5.TextAlign = HorizontalAlignment.Center;
                
                col1.Width = 200;         // 日時
                col2.Width = 250;         // 読取番号（表裏）
                col3.Width = 160;         // 読取結果（表裏）
                col4.Width = 120;         // 表裏一致判定
                col5.Width = 100;         // 連続判定
                ColumnHeader[] colHeader = new[] { col1, col2, col3, col4, col5 };
                listView.Columns.AddRange(colHeader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【SetHeaderData】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// コントロールのDoubleBufferedプロパティをTrueにする
        /// </summary>
        /// <param name="control"></param>
        private void EnableDoubleBuffering(Control control)
        {
            control.GetType().InvokeMember("DoubleBuffered",
                                            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                                            null/* TODO Change to default(_) if this is not a reference type */,
                                            control,
                                            new object[] { true }
                                            );
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
        /// 「戻る」ボタン処理
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
        /// 「検査開始」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnRun_Click(object sender, EventArgs e)
        {
            try
            {
                string[] col = new string[5];
                ListViewItem itm1;
                col[0]= DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                col[1]= "1234567890 / 0987654321";
                col[2]= "OK / OK";
                col[3]= "OK";
                col[4]= "OK";

                itm1 = new ListViewItem(col);
                LstReadData.Items.Add(itm1);
                LstReadData.Items[LstReadData.Items.Count - 1].UseItemStyleForSubItems = false;
                LstReadData.Select();
                LstReadData.Items[LstReadData.Items.Count - 1].EnsureVisible();

                if (LstReadData.Items.Count % 2 == 1)
                {
                    for (int iIndex = 0; iIndex < 5; iIndex++)
                    {
                        // 奇数行の色反転
                        LstReadData.Items[LstReadData.Items.Count - 1].SubItems[iIndex].BackColor = Color.FromArgb(200, 200, 230);
                    }
                }
                lblTranOSCount.Text = LstReadData.Items.Count.ToString() + " 件"; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnRun_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「停止」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnStop_Click(object sender, EventArgs e)
        {
            try
            {
                string[] col = new string[5];
                ListViewItem itm1;
                col[0] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
                col[1] = "1234567890 / 0987654321";
                col[2] = "NG / NG";
                col[3] = "NG";
                col[4] = "NG";

                itm1 = new ListViewItem(col);
                LstError.Items.Add(itm1);
                LstError.Items[LstError.Items.Count - 1].UseItemStyleForSubItems = false;
                LstError.Select();
                LstError.Items[LstError.Items.Count - 1].EnsureVisible();

                if (LstError.Items.Count % 2 == 1)
                {
                    for (int iIndex = 0; iIndex < 5; iIndex++)
                    {
                        // 奇数行の色反転
                        LstError.Items[LstError.Items.Count - 1].SubItems[iIndex].BackColor = Color.FromArgb(200, 200, 230);
                    }
                }
                lblTranOSNGCount.Text = LstError.Items.Count.ToString() + " 件";
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="label"></param>
        /// <param name="sMessage"></param>
        private void ClearCounter(System.Windows.Forms.Label label, string sMessage)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show($"{sMessage}をクリアしますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    label.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【ClearCounter】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 「」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOKClear_Click(object sender, EventArgs e)
        {
            ClearCounter(LblOKCount, "「OKカウンタ」");
        }

        /// <summary>
        /// 「」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNGClear_Click(object sender, EventArgs e)
        {
            ClearCounter(LblNGCount, "「NGカウンタ」");
        }

        /// <summary>
        /// 「」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMatchingErrorClear_Click(object sender, EventArgs e)
        {
            ClearCounter(LblMatchingErrorCount, "「表裏NGカウンタ」");
        }

        /// <summary>
        /// 「」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSeqNumErrorClear_Click(object sender, EventArgs e)
        {
            ClearCounter(LblSeqNumErrorCount, "「連番NGカウンタ」");
        }

        /// <summary>
        /// 「一斉クリア」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAllClear_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("全てのカウンタをクリアしますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.OK)
                {
                    LblOKCount.Text = "0";
                    LblNGCount.Text = "0";
                    LblMatchingErrorCount.Text = "0";
                    LblSeqNumErrorCount.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnAllClear_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LblOk_Click(object sender, EventArgs e)
        {
            LblOKCount.Text = (int.Parse(LblOKCount.Text.Trim())+1).ToString();
        }

        private void LblNg_Click(object sender, EventArgs e)
        {
            LblNGCount.Text = (int.Parse(LblNGCount.Text.Trim()) + 1).ToString();
        }

        private void LblMatching_Click(object sender, EventArgs e)
        {
            LblMatchingErrorCount.Text = (int.Parse(LblMatchingErrorCount.Text.Trim()) + 1).ToString();
        }

        private void LblSeqNum_Click(object sender, EventArgs e)
        {
            LblSeqNumErrorCount.Text = (int.Parse(LblSeqNumErrorCount.Text.Trim()) + 1).ToString();
        }
    }
}
