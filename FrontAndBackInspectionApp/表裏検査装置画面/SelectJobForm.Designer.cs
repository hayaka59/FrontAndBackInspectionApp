namespace FrontAndBackInspectionApp.表裏検査装置画面
{
    partial class SelectJobForm
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
            this.LblTitle = new System.Windows.Forms.Label();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnEntry = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.CmbBroadDivision = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.LtbJobDataInfo = new System.Windows.Forms.ListBox();
            this.LblLogFileName = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.Label22 = new System.Windows.Forms.Label();
            this.LblVersion = new System.Windows.Forms.Label();
            this.BtnBack = new System.Windows.Forms.Button();
            this.BtnNewStart = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnEntrySub = new System.Windows.Forms.Button();
            this.BtnDeleteSub = new System.Windows.Forms.Button();
            this.CmbSubDivision = new System.Windows.Forms.ComboBox();
            this.BtnJobSelect = new System.Windows.Forms.Button();
            this.TxtJobName = new System.Windows.Forms.TextBox();
            this.GroupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblTitle
            // 
            this.LblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.LblTitle.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(0, -1);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(1903, 50);
            this.LblTitle.TabIndex = 315;
            this.LblTitle.Text = "LblTitle";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.BtnEntry);
            this.GroupBox1.Controls.Add(this.BtnDelete);
            this.GroupBox1.Controls.Add(this.CmbBroadDivision);
            this.GroupBox1.Location = new System.Drawing.Point(885, 167);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(715, 103);
            this.GroupBox1.TabIndex = 325;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "大区分の選択";
            // 
            // BtnEntry
            // 
            this.BtnEntry.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnEntry.Image = global::FrontAndBackInspectionApp.Properties.Resources.new_plus;
            this.BtnEntry.Location = new System.Drawing.Point(387, 31);
            this.BtnEntry.Name = "BtnEntry";
            this.BtnEntry.Size = new System.Drawing.Size(150, 50);
            this.BtnEntry.TabIndex = 327;
            this.BtnEntry.Text = "追加";
            this.BtnEntry.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEntry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnEntry.UseVisualStyleBackColor = true;
            // 
            // BtnDelete
            // 
            this.BtnDelete.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnDelete.Image = global::FrontAndBackInspectionApp.Properties.Resources.delete;
            this.BtnDelete.Location = new System.Drawing.Point(544, 31);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(150, 50);
            this.BtnDelete.TabIndex = 328;
            this.BtnDelete.Text = "削除";
            this.BtnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnDelete.UseVisualStyleBackColor = true;
            // 
            // CmbBroadDivision
            // 
            this.CmbBroadDivision.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CmbBroadDivision.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CmbBroadDivision.FormattingEnabled = true;
            this.CmbBroadDivision.Location = new System.Drawing.Point(17, 37);
            this.CmbBroadDivision.Name = "CmbBroadDivision";
            this.CmbBroadDivision.Size = new System.Drawing.Size(360, 39);
            this.CmbBroadDivision.TabIndex = 0;
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Blue;
            this.Label1.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(235, 132);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(635, 35);
            this.Label1.TabIndex = 324;
            this.Label1.Text = "選択JOB検査内容";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LtbJobDataInfo
            // 
            this.LtbJobDataInfo.Font = new System.Drawing.Font("ＭＳ ゴシック", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LtbJobDataInfo.FormattingEnabled = true;
            this.LtbJobDataInfo.ItemHeight = 27;
            this.LtbJobDataInfo.Location = new System.Drawing.Point(235, 167);
            this.LtbJobDataInfo.Name = "LtbJobDataInfo";
            this.LtbJobDataInfo.Size = new System.Drawing.Size(635, 598);
            this.LtbJobDataInfo.TabIndex = 323;
            // 
            // LblLogFileName
            // 
            this.LblLogFileName.BackColor = System.Drawing.Color.DarkGray;
            this.LblLogFileName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblLogFileName.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblLogFileName.ForeColor = System.Drawing.Color.Black;
            this.LblLogFileName.Location = new System.Drawing.Point(399, 809);
            this.LblLogFileName.Name = "LblLogFileName";
            this.LblLogFileName.Size = new System.Drawing.Size(1182, 47);
            this.LblLogFileName.TabIndex = 320;
            this.LblLogFileName.Text = "検査ログ";
            this.LblLogFileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label14
            // 
            this.Label14.BackColor = System.Drawing.Color.Blue;
            this.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Label14.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label14.ForeColor = System.Drawing.Color.White;
            this.Label14.Location = new System.Drawing.Point(236, 809);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(163, 47);
            this.Label14.TabIndex = 319;
            this.Label14.Text = "検査ログ";
            this.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label22
            // 
            this.Label22.BackColor = System.Drawing.Color.Blue;
            this.Label22.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label22.ForeColor = System.Drawing.Color.White;
            this.Label22.Location = new System.Drawing.Point(235, 77);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(150, 35);
            this.Label22.TabIndex = 317;
            this.Label22.Text = "ＪＯＢ名称";
            this.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblVersion
            // 
            this.LblVersion.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblVersion.ForeColor = System.Drawing.Color.Blue;
            this.LblVersion.Location = new System.Drawing.Point(1700, 1000);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(170, 30);
            this.LblVersion.TabIndex = 316;
            this.LblVersion.Text = "LblVersion";
            this.LblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnBack
            // 
            this.BtnBack.Font = new System.Drawing.Font("メイリオ", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnBack.Image = global::FrontAndBackInspectionApp.Properties.Resources.back_arrow;
            this.BtnBack.Location = new System.Drawing.Point(1280, 883);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(300, 64);
            this.BtnBack.TabIndex = 322;
            this.BtnBack.Text = "戻る";
            this.BtnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnBack.UseVisualStyleBackColor = true;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // BtnNewStart
            // 
            this.BtnNewStart.Font = new System.Drawing.Font("メイリオ", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnNewStart.Image = global::FrontAndBackInspectionApp.Properties.Resources.running_icon;
            this.BtnNewStart.Location = new System.Drawing.Point(235, 883);
            this.BtnNewStart.Name = "BtnNewStart";
            this.BtnNewStart.Size = new System.Drawing.Size(300, 64);
            this.BtnNewStart.TabIndex = 321;
            this.BtnNewStart.Text = "運転開始";
            this.BtnNewStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnNewStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnNewStart.UseVisualStyleBackColor = true;
            this.BtnNewStart.Click += new System.EventHandler(this.BtnNewStart_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnEntrySub);
            this.groupBox2.Controls.Add(this.BtnDeleteSub);
            this.groupBox2.Controls.Add(this.CmbSubDivision);
            this.groupBox2.Location = new System.Drawing.Point(885, 290);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(715, 103);
            this.groupBox2.TabIndex = 329;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "小区分の選択";
            // 
            // BtnEntrySub
            // 
            this.BtnEntrySub.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnEntrySub.Image = global::FrontAndBackInspectionApp.Properties.Resources.new_plus;
            this.BtnEntrySub.Location = new System.Drawing.Point(387, 31);
            this.BtnEntrySub.Name = "BtnEntrySub";
            this.BtnEntrySub.Size = new System.Drawing.Size(150, 50);
            this.BtnEntrySub.TabIndex = 327;
            this.BtnEntrySub.Text = "追加";
            this.BtnEntrySub.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEntrySub.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnEntrySub.UseVisualStyleBackColor = true;
            // 
            // BtnDeleteSub
            // 
            this.BtnDeleteSub.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnDeleteSub.Image = global::FrontAndBackInspectionApp.Properties.Resources.delete;
            this.BtnDeleteSub.Location = new System.Drawing.Point(544, 31);
            this.BtnDeleteSub.Name = "BtnDeleteSub";
            this.BtnDeleteSub.Size = new System.Drawing.Size(150, 50);
            this.BtnDeleteSub.TabIndex = 328;
            this.BtnDeleteSub.Text = "削除";
            this.BtnDeleteSub.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnDeleteSub.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnDeleteSub.UseVisualStyleBackColor = true;
            // 
            // CmbSubDivision
            // 
            this.CmbSubDivision.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CmbSubDivision.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CmbSubDivision.FormattingEnabled = true;
            this.CmbSubDivision.Location = new System.Drawing.Point(17, 37);
            this.CmbSubDivision.Name = "CmbSubDivision";
            this.CmbSubDivision.Size = new System.Drawing.Size(360, 39);
            this.CmbSubDivision.TabIndex = 0;
            // 
            // BtnJobSelect
            // 
            this.BtnJobSelect.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnJobSelect.Image = global::FrontAndBackInspectionApp.Properties.Resources.search_file;
            this.BtnJobSelect.Location = new System.Drawing.Point(902, 76);
            this.BtnJobSelect.Name = "BtnJobSelect";
            this.BtnJobSelect.Size = new System.Drawing.Size(360, 60);
            this.BtnJobSelect.TabIndex = 338;
            this.BtnJobSelect.Text = "JOB選択";
            this.BtnJobSelect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnJobSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnJobSelect.UseVisualStyleBackColor = true;
            this.BtnJobSelect.Click += new System.EventHandler(this.BtnJobSelect_Click);
            // 
            // TxtJobName
            // 
            this.TxtJobName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtJobName.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtJobName.Location = new System.Drawing.Point(382, 76);
            this.TxtJobName.Name = "TxtJobName";
            this.TxtJobName.Size = new System.Drawing.Size(488, 36);
            this.TxtJobName.TabIndex = 340;
            this.TxtJobName.Text = "チューリッヒ①ハガキ";
            // 
            // SelectJobForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.TxtJobName);
            this.Controls.Add(this.BtnJobSelect);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.LtbJobDataInfo);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.BtnNewStart);
            this.Controls.Add(this.LblLogFileName);
            this.Controls.Add(this.Label14);
            this.Controls.Add(this.Label22);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.LblTitle);
            this.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectJobForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JOB選択画面";
            this.Load += new System.EventHandler(this.SelectJobForm_Load);
            this.GroupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label LblTitle;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.ComboBox CmbBroadDivision;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ListBox LtbJobDataInfo;
        internal System.Windows.Forms.Button BtnBack;
        internal System.Windows.Forms.Button BtnNewStart;
        internal System.Windows.Forms.Label LblLogFileName;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.Label LblVersion;
        internal System.Windows.Forms.Button BtnEntry;
        internal System.Windows.Forms.Button BtnDelete;
        internal System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Button BtnEntrySub;
        internal System.Windows.Forms.Button BtnDeleteSub;
        internal System.Windows.Forms.ComboBox CmbSubDivision;
        internal System.Windows.Forms.Button BtnJobSelect;
        private System.Windows.Forms.TextBox TxtJobName;
    }
}