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
            this.TxtOperatorName = new System.Windows.Forms.TextBox();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.CmbOperatorName = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.LtbJobDataInfo = new System.Windows.Forms.ListBox();
            this.LblLogFileName = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.CmbJobName = new System.Windows.Forms.ComboBox();
            this.Label22 = new System.Windows.Forms.Label();
            this.LblVersion = new System.Windows.Forms.Label();
            this.BtnChange = new System.Windows.Forms.Button();
            this.BtnNew = new System.Windows.Forms.Button();
            this.BtnBack = new System.Windows.Forms.Button();
            this.BtnNewStart = new System.Windows.Forms.Button();
            this.GroupBox1.SuspendLayout();
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
            this.GroupBox1.Controls.Add(this.TxtOperatorName);
            this.GroupBox1.Controls.Add(this.BtnDelete);
            this.GroupBox1.Controls.Add(this.BtnChange);
            this.GroupBox1.Controls.Add(this.BtnNew);
            this.GroupBox1.Controls.Add(this.CmbOperatorName);
            this.GroupBox1.Location = new System.Drawing.Point(1011, 130);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(468, 224);
            this.GroupBox1.TabIndex = 325;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "オペレータの選択と編集";
            // 
            // TxtOperatorName
            // 
            this.TxtOperatorName.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtOperatorName.Location = new System.Drawing.Point(26, 153);
            this.TxtOperatorName.Name = "TxtOperatorName";
            this.TxtOperatorName.Size = new System.Drawing.Size(421, 36);
            this.TxtOperatorName.TabIndex = 4;
            // 
            // BtnDelete
            // 
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnDelete.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnDelete.Location = new System.Drawing.Point(311, 47);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(136, 55);
            this.BtnDelete.TabIndex = 3;
            this.BtnDelete.Text = "削除";
            this.BtnDelete.UseVisualStyleBackColor = true;
            // 
            // CmbOperatorName
            // 
            this.CmbOperatorName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbOperatorName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CmbOperatorName.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CmbOperatorName.FormattingEnabled = true;
            this.CmbOperatorName.Location = new System.Drawing.Point(26, 108);
            this.CmbOperatorName.Name = "CmbOperatorName";
            this.CmbOperatorName.Size = new System.Drawing.Size(421, 39);
            this.CmbOperatorName.TabIndex = 0;
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Blue;
            this.Label1.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(362, 132);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(635, 35);
            this.Label1.TabIndex = 324;
            this.Label1.Text = "選択JOB検査内容";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LtbJobDataInfo
            // 
            this.LtbJobDataInfo.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LtbJobDataInfo.FormattingEnabled = true;
            this.LtbJobDataInfo.ItemHeight = 28;
            this.LtbJobDataInfo.Location = new System.Drawing.Point(362, 167);
            this.LtbJobDataInfo.Name = "LtbJobDataInfo";
            this.LtbJobDataInfo.Size = new System.Drawing.Size(635, 620);
            this.LtbJobDataInfo.TabIndex = 323;
            // 
            // LblLogFileName
            // 
            this.LblLogFileName.BackColor = System.Drawing.Color.DarkGray;
            this.LblLogFileName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblLogFileName.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblLogFileName.ForeColor = System.Drawing.Color.Black;
            this.LblLogFileName.Location = new System.Drawing.Point(526, 809);
            this.LblLogFileName.Name = "LblLogFileName";
            this.LblLogFileName.Size = new System.Drawing.Size(955, 47);
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
            this.Label14.Location = new System.Drawing.Point(363, 809);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(163, 47);
            this.Label14.TabIndex = 319;
            this.Label14.Text = "検査ログ";
            this.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CmbJobName
            // 
            this.CmbJobName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbJobName.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CmbJobName.FormattingEnabled = true;
            this.CmbJobName.Location = new System.Drawing.Point(525, 74);
            this.CmbJobName.Name = "CmbJobName";
            this.CmbJobName.Size = new System.Drawing.Size(955, 36);
            this.CmbJobName.TabIndex = 318;
            // 
            // Label22
            // 
            this.Label22.BackColor = System.Drawing.Color.Blue;
            this.Label22.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label22.ForeColor = System.Drawing.Color.White;
            this.Label22.Location = new System.Drawing.Point(362, 75);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(163, 35);
            this.Label22.TabIndex = 317;
            this.Label22.Text = "ＪＯＢ名称";
            this.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblVersion
            // 
            this.LblVersion.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblVersion.ForeColor = System.Drawing.Color.Blue;
            this.LblVersion.Location = new System.Drawing.Point(1761, 1008);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(130, 30);
            this.LblVersion.TabIndex = 316;
            this.LblVersion.Text = "LblVersion";
            this.LblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnChange
            // 
            this.BtnChange.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnChange.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnChange.Image = global::FrontAndBackInspectionApp.Properties.Resources.update;
            this.BtnChange.Location = new System.Drawing.Point(168, 47);
            this.BtnChange.Name = "BtnChange";
            this.BtnChange.Size = new System.Drawing.Size(136, 55);
            this.BtnChange.TabIndex = 2;
            this.BtnChange.Text = "変更";
            this.BtnChange.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnChange.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnChange.UseVisualStyleBackColor = true;
            // 
            // BtnNew
            // 
            this.BtnNew.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnNew.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnNew.Image = global::FrontAndBackInspectionApp.Properties.Resources.new_plus;
            this.BtnNew.Location = new System.Drawing.Point(26, 47);
            this.BtnNew.Name = "BtnNew";
            this.BtnNew.Size = new System.Drawing.Size(136, 55);
            this.BtnNew.TabIndex = 1;
            this.BtnNew.Text = "追加";
            this.BtnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnNew.UseVisualStyleBackColor = true;
            // 
            // BtnBack
            // 
            this.BtnBack.Font = new System.Drawing.Font("メイリオ", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnBack.Image = global::FrontAndBackInspectionApp.Properties.Resources.back_arrow;
            this.BtnBack.Location = new System.Drawing.Point(1180, 874);
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
            this.BtnNewStart.Location = new System.Drawing.Point(362, 874);
            this.BtnNewStart.Name = "BtnNewStart";
            this.BtnNewStart.Size = new System.Drawing.Size(300, 64);
            this.BtnNewStart.TabIndex = 321;
            this.BtnNewStart.Text = "運転開始";
            this.BtnNewStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnNewStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnNewStart.UseVisualStyleBackColor = true;
            this.BtnNewStart.Click += new System.EventHandler(this.BtnNewStart_Click);
            // 
            // SelectJobForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.LtbJobDataInfo);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.BtnNewStart);
            this.Controls.Add(this.LblLogFileName);
            this.Controls.Add(this.Label14);
            this.Controls.Add(this.CmbJobName);
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
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label LblTitle;
        internal System.Windows.Forms.GroupBox GroupBox1;
        internal System.Windows.Forms.TextBox TxtOperatorName;
        internal System.Windows.Forms.Button BtnDelete;
        internal System.Windows.Forms.Button BtnChange;
        internal System.Windows.Forms.Button BtnNew;
        internal System.Windows.Forms.ComboBox CmbOperatorName;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ListBox LtbJobDataInfo;
        internal System.Windows.Forms.Button BtnBack;
        internal System.Windows.Forms.Button BtnNewStart;
        internal System.Windows.Forms.Label LblLogFileName;
        internal System.Windows.Forms.Label Label14;
        internal System.Windows.Forms.ComboBox CmbJobName;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.Label LblVersion;
    }
}