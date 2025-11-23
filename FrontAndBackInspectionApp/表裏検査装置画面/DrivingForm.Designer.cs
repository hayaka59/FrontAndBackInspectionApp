namespace FrontAndBackInspectionApp.表裏検査装置画面
{
    partial class DrivingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LblTitle = new System.Windows.Forms.Label();
            this.LblVersion = new System.Windows.Forms.Label();
            this.LtbJobDataInfo = new System.Windows.Forms.ListBox();
            this.lblTranOSNGCount = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.LstError = new System.Windows.Forms.ListView();
            this.lblTranOSCount = new System.Windows.Forms.Label();
            this.Label22 = new System.Windows.Forms.Label();
            this.LstReadData = new System.Windows.Forms.ListView();
            this.BtnStop = new System.Windows.Forms.Button();
            this.BtnRun = new System.Windows.Forms.Button();
            this.BtnBack = new System.Windows.Forms.Button();
            this.TxtJobName = new System.Windows.Forms.TextBox();
            this.TimDateTime = new System.Windows.Forms.Timer(this.components);
            this.LblDateTime = new System.Windows.Forms.Label();
            this.LblNGCount = new System.Windows.Forms.Label();
            this.LblOKCount = new System.Windows.Forms.Label();
            this.LblTotalCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LblTitle
            // 
            this.LblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.LblTitle.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(-1, -1);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(1903, 50);
            this.LblTitle.TabIndex = 316;
            this.LblTitle.Text = "LblTitle";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblVersion
            // 
            this.LblVersion.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblVersion.ForeColor = System.Drawing.Color.Blue;
            this.LblVersion.Location = new System.Drawing.Point(1700, 1000);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(170, 30);
            this.LblVersion.TabIndex = 317;
            this.LblVersion.Text = "LblVersion";
            this.LblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LtbJobDataInfo
            // 
            this.LtbJobDataInfo.BackColor = System.Drawing.Color.White;
            this.LtbJobDataInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LtbJobDataInfo.Enabled = false;
            this.LtbJobDataInfo.Font = new System.Drawing.Font("ＭＳ ゴシック", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LtbJobDataInfo.FormattingEnabled = true;
            this.LtbJobDataInfo.ItemHeight = 24;
            this.LtbJobDataInfo.Location = new System.Drawing.Point(1210, 208);
            this.LtbJobDataInfo.Name = "LtbJobDataInfo";
            this.LtbJobDataInfo.Size = new System.Drawing.Size(500, 362);
            this.LtbJobDataInfo.TabIndex = 344;
            // 
            // lblTranOSNGCount
            // 
            this.lblTranOSNGCount.BackColor = System.Drawing.Color.Transparent;
            this.lblTranOSNGCount.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTranOSNGCount.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTranOSNGCount.Location = new System.Drawing.Point(944, 832);
            this.lblTranOSNGCount.Name = "lblTranOSNGCount";
            this.lblTranOSNGCount.Size = new System.Drawing.Size(255, 35);
            this.lblTranOSNGCount.TabIndex = 342;
            this.lblTranOSNGCount.Text = "lblTranOSNGCount";
            this.lblTranOSNGCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Label2.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.Location = new System.Drawing.Point(699, 75);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(500, 27);
            this.Label2.TabIndex = 339;
            this.Label2.Text = "エラー履歴";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LstError
            // 
            this.LstError.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LstError.FullRowSelect = true;
            this.LstError.GridLines = true;
            this.LstError.HideSelection = false;
            this.LstError.Location = new System.Drawing.Point(699, 102);
            this.LstError.MultiSelect = false;
            this.LstError.Name = "LstError";
            this.LstError.Size = new System.Drawing.Size(500, 730);
            this.LstError.TabIndex = 329;
            this.LstError.UseCompatibleStateImageBehavior = false;
            // 
            // lblTranOSCount
            // 
            this.lblTranOSCount.BackColor = System.Drawing.Color.Transparent;
            this.lblTranOSCount.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTranOSCount.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTranOSCount.Location = new System.Drawing.Point(433, 832);
            this.lblTranOSCount.Name = "lblTranOSCount";
            this.lblTranOSCount.Size = new System.Drawing.Size(255, 35);
            this.lblTranOSCount.TabIndex = 324;
            this.lblTranOSCount.Text = "lblTranOSCount";
            this.lblTranOSCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Label22
            // 
            this.Label22.BackColor = System.Drawing.Color.Blue;
            this.Label22.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label22.ForeColor = System.Drawing.Color.White;
            this.Label22.Location = new System.Drawing.Point(188, 75);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(500, 27);
            this.Label22.TabIndex = 322;
            this.Label22.Text = "検査履歴";
            this.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LstReadData
            // 
            this.LstReadData.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LstReadData.FullRowSelect = true;
            this.LstReadData.GridLines = true;
            this.LstReadData.HideSelection = false;
            this.LstReadData.Location = new System.Drawing.Point(188, 102);
            this.LstReadData.MultiSelect = false;
            this.LstReadData.Name = "LstReadData";
            this.LstReadData.Size = new System.Drawing.Size(500, 730);
            this.LstReadData.TabIndex = 318;
            this.LstReadData.UseCompatibleStateImageBehavior = false;
            // 
            // BtnStop
            // 
            this.BtnStop.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnStop.Image = global::FrontAndBackInspectionApp.Properties.Resources.standing;
            this.BtnStop.Location = new System.Drawing.Point(433, 896);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(220, 70);
            this.BtnStop.TabIndex = 321;
            this.BtnStop.Text = "停止";
            this.BtnStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // BtnRun
            // 
            this.BtnRun.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnRun.Image = global::FrontAndBackInspectionApp.Properties.Resources.running_icon;
            this.BtnRun.Location = new System.Drawing.Point(193, 896);
            this.BtnRun.Name = "BtnRun";
            this.BtnRun.Size = new System.Drawing.Size(220, 70);
            this.BtnRun.TabIndex = 320;
            this.BtnRun.Text = "検査開始";
            this.BtnRun.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnRun.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnRun.UseVisualStyleBackColor = true;
            this.BtnRun.Click += new System.EventHandler(this.BtnRun_Click);
            // 
            // BtnBack
            // 
            this.BtnBack.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnBack.Image = global::FrontAndBackInspectionApp.Properties.Resources.back_arrow;
            this.BtnBack.Location = new System.Drawing.Point(1481, 896);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(220, 70);
            this.BtnBack.TabIndex = 319;
            this.BtnBack.Text = "戻る";
            this.BtnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnBack.UseVisualStyleBackColor = true;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // TxtJobName
            // 
            this.TxtJobName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtJobName.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtJobName.Location = new System.Drawing.Point(1210, 173);
            this.TxtJobName.Name = "TxtJobName";
            this.TxtJobName.Size = new System.Drawing.Size(500, 36);
            this.TxtJobName.TabIndex = 345;
            this.TxtJobName.Text = "チューリッヒ①ハガキ";
            // 
            // TimDateTime
            // 
            this.TimDateTime.Tick += new System.EventHandler(this.TimDateTime_Tick);
            // 
            // LblDateTime
            // 
            this.LblDateTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.LblDateTime.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblDateTime.ForeColor = System.Drawing.Color.Yellow;
            this.LblDateTime.Location = new System.Drawing.Point(1456, 3);
            this.LblDateTime.Name = "LblDateTime";
            this.LblDateTime.Size = new System.Drawing.Size(436, 46);
            this.LblDateTime.TabIndex = 346;
            this.LblDateTime.Text = "年月日時分秒";
            this.LblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblNGCount
            // 
            this.LblNGCount.BackColor = System.Drawing.Color.White;
            this.LblNGCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblNGCount.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblNGCount.ForeColor = System.Drawing.Color.Black;
            this.LblNGCount.Location = new System.Drawing.Point(1317, 119);
            this.LblNGCount.Name = "LblNGCount";
            this.LblNGCount.Size = new System.Drawing.Size(108, 36);
            this.LblNGCount.TabIndex = 355;
            this.LblNGCount.Text = "99,999";
            this.LblNGCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblOKCount
            // 
            this.LblOKCount.BackColor = System.Drawing.Color.White;
            this.LblOKCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblOKCount.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblOKCount.ForeColor = System.Drawing.Color.Black;
            this.LblOKCount.Location = new System.Drawing.Point(1317, 75);
            this.LblOKCount.Name = "LblOKCount";
            this.LblOKCount.Size = new System.Drawing.Size(108, 36);
            this.LblOKCount.TabIndex = 354;
            this.LblOKCount.Text = "99,999";
            this.LblOKCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTotalCount
            // 
            this.LblTotalCount.BackColor = System.Drawing.Color.White;
            this.LblTotalCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LblTotalCount.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblTotalCount.ForeColor = System.Drawing.Color.Black;
            this.LblTotalCount.Location = new System.Drawing.Point(1577, 75);
            this.LblTotalCount.Name = "LblTotalCount";
            this.LblTotalCount.Size = new System.Drawing.Size(108, 36);
            this.LblTotalCount.TabIndex = 353;
            this.LblTotalCount.Text = "99,999";
            this.LblTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(1420, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 36);
            this.label7.TabIndex = 352;
            this.label7.Text = "件";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(1420, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 36);
            this.label5.TabIndex = 351;
            this.label5.Text = "件";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(1680, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 36);
            this.label4.TabIndex = 350;
            this.label4.Text = "件";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(1210, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 36);
            this.label3.TabIndex = 349;
            this.label3.Text = "NG";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(1210, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 36);
            this.label1.TabIndex = 348;
            this.label1.Text = "OK";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(1470, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 36);
            this.label6.TabIndex = 347;
            this.label6.Text = "表裏NG";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(1577, 119);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 36);
            this.label8.TabIndex = 358;
            this.label8.Text = "99,999";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(1680, 119);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 36);
            this.label9.TabIndex = 357;
            this.label9.Text = "件";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label10.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(1470, 119);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 36);
            this.label10.TabIndex = 356;
            this.label10.Text = "連番NG";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DrivingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.LblNGCount);
            this.Controls.Add(this.LblOKCount);
            this.Controls.Add(this.LblTotalCount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LblDateTime);
            this.Controls.Add(this.TxtJobName);
            this.Controls.Add(this.LtbJobDataInfo);
            this.Controls.Add(this.lblTranOSNGCount);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.LstError);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.BtnRun);
            this.Controls.Add(this.lblTranOSCount);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.Label22);
            this.Controls.Add(this.LstReadData);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.LblTitle);
            this.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DrivingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "検査画面";
            this.Load += new System.EventHandler(this.DrivingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label LblTitle;
        internal System.Windows.Forms.Label LblVersion;
        internal System.Windows.Forms.ListBox LtbJobDataInfo;
        internal System.Windows.Forms.Label lblTranOSNGCount;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.ListView LstError;
        internal System.Windows.Forms.Button BtnStop;
        internal System.Windows.Forms.Button BtnRun;
        internal System.Windows.Forms.Label lblTranOSCount;
        internal System.Windows.Forms.Button BtnBack;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.ListView LstReadData;
        private System.Windows.Forms.TextBox TxtJobName;
        internal System.Windows.Forms.Timer TimDateTime;
        internal System.Windows.Forms.Label LblDateTime;
        internal System.Windows.Forms.Label LblNGCount;
        internal System.Windows.Forms.Label LblOKCount;
        internal System.Windows.Forms.Label LblTotalCount;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.Label label5;
        internal System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label label10;
    }
}