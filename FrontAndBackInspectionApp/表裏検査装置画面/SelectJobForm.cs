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

        /// <summary>
        /// フォームロード処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectJobForm_Load(object sender, EventArgs e)
        {
            try
            {
                LblTitle.Text = "表裏検査装置　ジョブ選択画面";
                LblVersion.Text = PubConstClass.DEF_VERSION;

                TxtJobName.Text = "";
                // 大区分コンボボックス初期化
                CmbBroadDivision.Items.Clear();
                CmbBroadDivision.Items.Add("大区分１");
                CmbBroadDivision.Items.Add("大区分２");
                CmbBroadDivision.Items.Add("大区分３");
                CmbBroadDivision.SelectedIndex = 0;
                // 小区分コンボボックス初期化
                CmbSubDivision.Items.Clear();
                CmbSubDivision.Items.Add("小区分１");
                CmbSubDivision.Items.Add("小区分２");
                CmbSubDivision.Items.Add("小区分３");
                CmbSubDivision.SelectedIndex = 0;

                // 選択JOB検査内容表示リストビューの設定
                LtbJobDataInfo.DrawMode = DrawMode.OwnerDrawFixed;
                LtbJobDataInfo.DrawItem += LtbJobDataInfo_DrawItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【SelectJobForm_Load】", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// 「運転開始」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        string sSelectedFile = "";

        /// <summary>
        /// 「JO選択」ボタン処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnJobSelect_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();

                Log.OutPutLogFile(TraceEventType.Information, "登録画面：「JO選択」ボタンクリック");
                // 初期表示するフォルダの指定（「空の文字列」の時は現在のディレクトリを表示）
                //ofd.InitialDirectory = @"C:\";
                // 「ファイルの種類」に表示される選択肢の指定
                ofd.Filter = "CSVファイル(*.csv;*.CSV)|*.csv;*.CSV|すべてのファイル(*.*)|*.*";
                // 「ファイルの種類」ではじめに「CSVファイル(*.csv;*.CSV)」を選択
                ofd.FilterIndex = 1;
                // タイトルを設定
                ofd.Title = "JOB設定ファイルを選択してください";
                // ダイアログボックスを閉じる前に現在のディレクトリを復元
                ofd.RestoreDirectory = true;
                // 存在しないファイルの名前が指定されたとき警告を表示
                ofd.CheckFileExists = true;
                // 存在しないパスが指定されたとき警告を表示
                ofd.CheckPathExists = true;
                // ダイアログを表示する
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // 「OK」ボタンがクリック（選択されたファイル名を表示）
                    sSelectedFile = ofd.FileName;
                    string[] sArray = sSelectedFile.Split('\\');

                    // ジョブ登録情報の読取
                    CommonModule.ReadJobEntryListFile(sSelectedFile);
                    // 選択ジョブ項目を取得し表示
                    GetSelectJobItem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "【BtnJobSelect_Click】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 選択ジュブ項目を取得し表示する
        /// </summary>
        private void GetSelectJobItem()
        {
            string[] sArray;
            double dData;
            string sData;
            string sMessage;
            try
            {
                int iIndex = 0;
                sArray = PubConstClass.sJobEntryData.Split(',');
                // JOB名
                TxtJobName.Text = sArray[iIndex++];

                LtbJobDataInfo.Items.Clear();
                dData = (double.Parse(sArray[iIndex++]) + 30) / 10;
                LtbJobDataInfo.Items.Add($"用紙デプス          ：{dData.ToString("0.0")} インチ");
                LtbJobDataInfo.Items.Add($"カメラ読取位置（上）：{int.Parse(sArray[iIndex++]) + 1} ｍｍ");
                LtbJobDataInfo.Items.Add($"カメラ読取位置（下）：{int.Parse(sArray[iIndex++]) + 1} ｍｍ");
                LtbJobDataInfo.Items.Add($"照合桁              ：{int.Parse(sArray[iIndex++]) + 1} 桁");
                LtbJobDataInfo.Items.Add($"照合開始位置（上）  ：{int.Parse(sArray[iIndex++]) + 1} 桁目から");
                LtbJobDataInfo.Items.Add($"照合開始位置（下）  ：{int.Parse(sArray[iIndex++]) + 1} 桁目から");
                sData = sArray[iIndex++];
                if (sData == "0")
                {
                    LtbJobDataInfo.Items.Add($"停止設定            ：停止なし");
                }
                else
                {
                    LtbJobDataInfo.Items.Add($"停止設定            ：{int.Parse(sData)} 回");
                }
                sData = sArray[iIndex++];
                sMessage = "";
                switch (sData)
                {
                    case "0":
                        sMessage = "昇順";
                        break;
                    case "1":
                        sMessage = "降順";
                        break;
                    case "2":
                        sMessage = "検査なし";
                        break;
                }
                LtbJobDataInfo.Items.Add($"連番検査            ：{sMessage}");                
                LtbJobDataInfo.Items.Add($"カメラJOB番号       ：{int.Parse(sArray[iIndex++]) + 1}");

                string sLogFileName = "装置名称_";
                sLogFileName += TxtJobName.Text + "_";
                sLogFileName += CmbBroadDivision.SelectedItem.ToString() + "_";
                sLogFileName += CmbSubDivision.SelectedItem.ToString() + "_";
                sLogFileName += DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".log";
                // 
                LblLogFileName.Text = sLogFileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, "【GetSelectJobItem】", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
