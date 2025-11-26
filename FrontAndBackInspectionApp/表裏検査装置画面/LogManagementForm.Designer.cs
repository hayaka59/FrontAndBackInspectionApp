namespace FrontAndBackInspectionApp.表裏検査装置画面
{
    partial class LogManagementForm
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
            this.LblVersion = new System.Windows.Forms.Label();
            this.LblTitle = new System.Windows.Forms.Label();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.LsbJobInfo = new System.Windows.Forms.ListBox();
            this.LblWaiting = new System.Windows.Forms.Label();
            this.lblTranOSNGCount = new System.Windows.Forms.Label();
            this.lblTranOSCount = new System.Windows.Forms.Label();
            this.LblError = new System.Windows.Forms.Label();
            this.LblKensa = new System.Windows.Forms.Label();
            this.LstError = new System.Windows.Forms.ListView();
            this.LstReadData = new System.Windows.Forms.ListView();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.LblLogFileCount = new System.Windows.Forms.Label();
            this.BtnDispLogContent = new System.Windows.Forms.Button();
            this.BtnUnLock = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.DTPicTo = new System.Windows.Forms.DateTimePicker();
            this.DTPicFrom = new System.Windows.Forms.DateTimePicker();
            this.CmbLogFileName = new System.Windows.Forms.ComboBox();
            this.ChkDateNarrow = new System.Windows.Forms.CheckBox();
            this.Label22 = new System.Windows.Forms.Label();
            this.Label21 = new System.Windows.Forms.Label();
            this.CmbJobName = new System.Windows.Forms.ComboBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.BtnBack = new System.Windows.Forms.Button();
            this.GroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblVersion
            // 
            this.LblVersion.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblVersion.ForeColor = System.Drawing.Color.Blue;
            this.LblVersion.Location = new System.Drawing.Point(1700, 1000);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(170, 30);
            this.LblVersion.TabIndex = 319;
            this.LblVersion.Text = "LblVersion";
            this.LblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitle
            // 
            this.LblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.LblTitle.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(1, 2);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(1903, 50);
            this.LblTitle.TabIndex = 318;
            this.LblTitle.Text = "LblTitle";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnCancel.Location = new System.Drawing.Point(886, 525);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(128, 35);
            this.BtnCancel.TabIndex = 337;
            this.BtnCancel.Text = "キャンセル";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Visible = false;
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Location = new System.Drawing.Point(731, 483);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(438, 33);
            this.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressBar1.TabIndex = 336;
            this.ProgressBar1.Visible = false;
            // 
            // LsbJobInfo
            // 
            this.LsbJobInfo.BackColor = System.Drawing.SystemColors.Control;
            this.LsbJobInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LsbJobInfo.Enabled = false;
            this.LsbJobInfo.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LsbJobInfo.FormattingEnabled = true;
            this.LsbJobInfo.ItemHeight = 20;
            this.LsbJobInfo.Location = new System.Drawing.Point(1664, 80);
            this.LsbJobInfo.Name = "LsbJobInfo";
            this.LsbJobInfo.Size = new System.Drawing.Size(206, 160);
            this.LsbJobInfo.TabIndex = 335;
            // 
            // LblWaiting
            // 
            this.LblWaiting.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.LblWaiting.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblWaiting.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LblWaiting.Font = new System.Drawing.Font("メイリオ", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblWaiting.ForeColor = System.Drawing.Color.Blue;
            this.LblWaiting.Location = new System.Drawing.Point(721, 432);
            this.LblWaiting.Name = "LblWaiting";
            this.LblWaiting.Size = new System.Drawing.Size(460, 137);
            this.LblWaiting.TabIndex = 334;
            this.LblWaiting.Text = "表示処理中です";
            this.LblWaiting.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.LblWaiting.Visible = false;
            // 
            // lblTranOSNGCount
            // 
            this.lblTranOSNGCount.BackColor = System.Drawing.Color.Transparent;
            this.lblTranOSNGCount.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTranOSNGCount.Location = new System.Drawing.Point(1621, 902);
            this.lblTranOSNGCount.Name = "lblTranOSNGCount";
            this.lblTranOSNGCount.Size = new System.Drawing.Size(191, 29);
            this.lblTranOSNGCount.TabIndex = 331;
            this.lblTranOSNGCount.Text = "lblTranOSNGCount";
            this.lblTranOSNGCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTranOSCount
            // 
            this.lblTranOSCount.BackColor = System.Drawing.Color.Transparent;
            this.lblTranOSCount.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTranOSCount.Location = new System.Drawing.Point(753, 902);
            this.lblTranOSCount.Name = "lblTranOSCount";
            this.lblTranOSCount.Size = new System.Drawing.Size(191, 29);
            this.lblTranOSCount.TabIndex = 326;
            this.lblTranOSCount.Text = "lblTranOSCount";
            this.lblTranOSCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblError
            // 
            this.LblError.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.LblError.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblError.ForeColor = System.Drawing.Color.White;
            this.LblError.Location = new System.Drawing.Point(956, 264);
            this.LblError.Name = "LblError";
            this.LblError.Size = new System.Drawing.Size(856, 35);
            this.LblError.TabIndex = 325;
            this.LblError.Text = "エラー履歴";
            this.LblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblError.DoubleClick += new System.EventHandler(this.LblError_DoubleClick);
            // 
            // LblKensa
            // 
            this.LblKensa.BackColor = System.Drawing.Color.Blue;
            this.LblKensa.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblKensa.ForeColor = System.Drawing.Color.White;
            this.LblKensa.Location = new System.Drawing.Point(88, 264);
            this.LblKensa.Name = "LblKensa";
            this.LblKensa.Size = new System.Drawing.Size(856, 35);
            this.LblKensa.TabIndex = 324;
            this.LblKensa.Text = "検査履歴";
            this.LblKensa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblKensa.DoubleClick += new System.EventHandler(this.LblKensa_DoubleClick);
            // 
            // LstError
            // 
            this.LstError.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LstError.FullRowSelect = true;
            this.LstError.GridLines = true;
            this.LstError.HideSelection = false;
            this.LstError.Location = new System.Drawing.Point(956, 298);
            this.LstError.MultiSelect = false;
            this.LstError.Name = "LstError";
            this.LstError.Size = new System.Drawing.Size(856, 601);
            this.LstError.TabIndex = 323;
            this.LstError.UseCompatibleStateImageBehavior = false;
            // 
            // LstReadData
            // 
            this.LstReadData.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LstReadData.FullRowSelect = true;
            this.LstReadData.GridLines = true;
            this.LstReadData.HideSelection = false;
            this.LstReadData.Location = new System.Drawing.Point(88, 298);
            this.LstReadData.MultiSelect = false;
            this.LstReadData.Name = "LstReadData";
            this.LstReadData.Size = new System.Drawing.Size(856, 601);
            this.LstReadData.TabIndex = 322;
            this.LstReadData.UseCompatibleStateImageBehavior = false;
            // 
            // GroupBox3
            // 
            this.GroupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.GroupBox3.Controls.Add(this.LblLogFileCount);
            this.GroupBox3.Controls.Add(this.BtnDispLogContent);
            this.GroupBox3.Controls.Add(this.BtnUnLock);
            this.GroupBox3.Controls.Add(this.Label1);
            this.GroupBox3.Controls.Add(this.DTPicTo);
            this.GroupBox3.Controls.Add(this.DTPicFrom);
            this.GroupBox3.Controls.Add(this.CmbLogFileName);
            this.GroupBox3.Controls.Add(this.ChkDateNarrow);
            this.GroupBox3.Controls.Add(this.Label22);
            this.GroupBox3.Controls.Add(this.Label21);
            this.GroupBox3.Controls.Add(this.CmbJobName);
            this.GroupBox3.Controls.Add(this.Label9);
            this.GroupBox3.Controls.Add(this.Label5);
            this.GroupBox3.Location = new System.Drawing.Point(342, 65);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(1222, 181);
            this.GroupBox3.TabIndex = 321;
            this.GroupBox3.TabStop = false;
            // 
            // LblLogFileCount
            // 
            this.LblLogFileCount.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblLogFileCount.Location = new System.Drawing.Point(982, 136);
            this.LblLogFileCount.Name = "LblLogFileCount";
            this.LblLogFileCount.Size = new System.Drawing.Size(220, 25);
            this.LblLogFileCount.TabIndex = 88;
            this.LblLogFileCount.Text = "LblLogFileCount";
            this.LblLogFileCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnDispLogContent
            // 
            this.BtnDispLogContent.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnDispLogContent.Image = global::FrontAndBackInspectionApp.Properties.Resources.display_small;
            this.BtnDispLogContent.Location = new System.Drawing.Point(1023, 53);
            this.BtnDispLogContent.Name = "BtnDispLogContent";
            this.BtnDispLogContent.Size = new System.Drawing.Size(180, 65);
            this.BtnDispLogContent.TabIndex = 87;
            this.BtnDispLogContent.Text = "ログ表示";
            this.BtnDispLogContent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnDispLogContent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnDispLogContent.UseVisualStyleBackColor = true;
            // 
            // BtnUnLock
            // 
            this.BtnUnLock.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnUnLock.Image = global::FrontAndBackInspectionApp.Properties.Resources.gear_small;
            this.BtnUnLock.Location = new System.Drawing.Point(823, 53);
            this.BtnUnLock.Name = "BtnUnLock";
            this.BtnUnLock.Size = new System.Drawing.Size(180, 65);
            this.BtnUnLock.TabIndex = 86;
            this.BtnUnLock.Text = "絞込解除";
            this.BtnUnLock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnUnLock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnUnLock.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(564, 96);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(45, 30);
            this.Label1.TabIndex = 85;
            this.Label1.Text = "～";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DTPicTo
            // 
            this.DTPicTo.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DTPicTo.Location = new System.Drawing.Point(615, 93);
            this.DTPicTo.Name = "DTPicTo";
            this.DTPicTo.Size = new System.Drawing.Size(196, 36);
            this.DTPicTo.TabIndex = 84;
            // 
            // DTPicFrom
            // 
            this.DTPicFrom.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DTPicFrom.Location = new System.Drawing.Point(362, 93);
            this.DTPicFrom.Name = "DTPicFrom";
            this.DTPicFrom.Size = new System.Drawing.Size(196, 36);
            this.DTPicFrom.TabIndex = 83;
            // 
            // CmbLogFileName
            // 
            this.CmbLogFileName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbLogFileName.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CmbLogFileName.FormattingEnabled = true;
            this.CmbLogFileName.Location = new System.Drawing.Point(186, 132);
            this.CmbLogFileName.Name = "CmbLogFileName";
            this.CmbLogFileName.Size = new System.Drawing.Size(778, 39);
            this.CmbLogFileName.TabIndex = 81;
            // 
            // ChkDateNarrow
            // 
            this.ChkDateNarrow.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ChkDateNarrow.Location = new System.Drawing.Point(190, 96);
            this.ChkDateNarrow.Name = "ChkDateNarrow";
            this.ChkDateNarrow.Size = new System.Drawing.Size(178, 29);
            this.ChkDateNarrow.TabIndex = 82;
            this.ChkDateNarrow.Text = "日付で絞り込む";
            this.ChkDateNarrow.UseVisualStyleBackColor = true;
            // 
            // Label22
            // 
            this.Label22.BackColor = System.Drawing.Color.Blue;
            this.Label22.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label22.ForeColor = System.Drawing.Color.White;
            this.Label22.Location = new System.Drawing.Point(20, 134);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(163, 35);
            this.Label22.TabIndex = 80;
            this.Label22.Text = "選択ログ";
            this.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label21
            // 
            this.Label21.BackColor = System.Drawing.Color.Blue;
            this.Label21.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label21.ForeColor = System.Drawing.Color.White;
            this.Label21.Location = new System.Drawing.Point(20, 93);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(163, 35);
            this.Label21.TabIndex = 78;
            this.Label21.Text = "検索日付範囲";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CmbJobName
            // 
            this.CmbJobName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbJobName.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CmbJobName.FormattingEnabled = true;
            this.CmbJobName.Location = new System.Drawing.Point(186, 51);
            this.CmbJobName.Name = "CmbJobName";
            this.CmbJobName.Size = new System.Drawing.Size(625, 39);
            this.CmbJobName.TabIndex = 76;
            // 
            // Label9
            // 
            this.Label9.BackColor = System.Drawing.Color.Blue;
            this.Label9.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label9.ForeColor = System.Drawing.Color.White;
            this.Label9.Location = new System.Drawing.Point(20, 53);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(163, 35);
            this.Label9.TabIndex = 75;
            this.Label9.Text = "ジョブ選択";
            this.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.Color.MidnightBlue;
            this.Label5.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label5.ForeColor = System.Drawing.Color.White;
            this.Label5.Location = new System.Drawing.Point(4, 15);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(1219, 30);
            this.Label5.TabIndex = 66;
            this.Label5.Text = "ログ選択";
            this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnBack
            // 
            this.BtnBack.Font = new System.Drawing.Font("メイリオ", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnBack.Image = global::FrontAndBackInspectionApp.Properties.Resources.back_arrow;
            this.BtnBack.Location = new System.Drawing.Point(1604, 947);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(208, 50);
            this.BtnBack.TabIndex = 320;
            this.BtnBack.Text = "戻る";
            this.BtnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnBack.UseVisualStyleBackColor = true;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // LogManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.LsbJobInfo);
            this.Controls.Add(this.LblWaiting);
            this.Controls.Add(this.lblTranOSNGCount);
            this.Controls.Add(this.lblTranOSCount);
            this.Controls.Add(this.LblError);
            this.Controls.Add(this.LblKensa);
            this.Controls.Add(this.LstError);
            this.Controls.Add(this.LstReadData);
            this.Controls.Add(this.GroupBox3);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.LblTitle);
            this.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LogManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ログ管理画面";
            this.Load += new System.EventHandler(this.LogManagementForm_Load);
            this.GroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label LblVersion;
        internal System.Windows.Forms.Label LblTitle;
        internal System.Windows.Forms.Button BtnCancel;
        internal System.Windows.Forms.ProgressBar ProgressBar1;
        internal System.Windows.Forms.ListBox LsbJobInfo;
        internal System.Windows.Forms.Label LblWaiting;
        internal System.Windows.Forms.Label lblTranOSNGCount;
        internal System.Windows.Forms.Label lblTranOSCount;
        internal System.Windows.Forms.Label LblError;
        internal System.Windows.Forms.Label LblKensa;
        internal System.Windows.Forms.ListView LstError;
        internal System.Windows.Forms.ListView LstReadData;
        internal System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Label LblLogFileCount;
        internal System.Windows.Forms.Button BtnDispLogContent;
        internal System.Windows.Forms.Button BtnUnLock;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.DateTimePicker DTPicTo;
        internal System.Windows.Forms.DateTimePicker DTPicFrom;
        internal System.Windows.Forms.ComboBox CmbLogFileName;
        internal System.Windows.Forms.CheckBox ChkDateNarrow;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.Label Label21;
        internal System.Windows.Forms.ComboBox CmbJobName;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Button BtnBack;
    }
}