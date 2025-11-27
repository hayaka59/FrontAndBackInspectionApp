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
            this.LsbJobInfo = new System.Windows.Forms.ListBox();
            this.lblTranOSNGCount = new System.Windows.Forms.Label();
            this.lblTranOSCount = new System.Windows.Forms.Label();
            this.LblError = new System.Windows.Forms.Label();
            this.LblKensa = new System.Windows.Forms.Label();
            this.LstError = new System.Windows.Forms.ListView();
            this.LstReadData = new System.Windows.Forms.ListView();
            this.Label1 = new System.Windows.Forms.Label();
            this.DTPicTo = new System.Windows.Forms.DateTimePicker();
            this.DTPicFrom = new System.Windows.Forms.DateTimePicker();
            this.ChkDateNarrow = new System.Windows.Forms.CheckBox();
            this.Label21 = new System.Windows.Forms.Label();
            this.LblSelectedFile = new System.Windows.Forms.Label();
            this.PicWaitContent = new System.Windows.Forms.PictureBox();
            this.PicWaitList = new System.Windows.Forms.PictureBox();
            this.BtnJobClear = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnDispLogContent = new System.Windows.Forms.Button();
            this.BtnUnLock = new System.Windows.Forms.Button();
            this.BtnBack = new System.Windows.Forms.Button();
            this.LblLogFileCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LsvLogList = new System.Windows.Forms.ListView();
            ((System.ComponentModel.ISupportInitialize)(this.PicWaitContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicWaitList)).BeginInit();
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
            // LsbJobInfo
            // 
            this.LsbJobInfo.BackColor = System.Drawing.Color.MistyRose;
            this.LsbJobInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LsbJobInfo.Enabled = false;
            this.LsbJobInfo.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LsbJobInfo.FormattingEnabled = true;
            this.LsbJobInfo.ItemHeight = 20;
            this.LsbJobInfo.Location = new System.Drawing.Point(499, 942);
            this.LsbJobInfo.Name = "LsbJobInfo";
            this.LsbJobInfo.Size = new System.Drawing.Size(206, 80);
            this.LsbJobInfo.TabIndex = 335;
            this.LsbJobInfo.Visible = false;
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
            this.LblError.Location = new System.Drawing.Point(964, 436);
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
            this.LblKensa.Location = new System.Drawing.Point(96, 436);
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
            this.LstError.Location = new System.Drawing.Point(964, 470);
            this.LstError.MultiSelect = false;
            this.LstError.Name = "LstError";
            this.LstError.Size = new System.Drawing.Size(856, 429);
            this.LstError.TabIndex = 323;
            this.LstError.UseCompatibleStateImageBehavior = false;
            // 
            // LstReadData
            // 
            this.LstReadData.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LstReadData.FullRowSelect = true;
            this.LstReadData.GridLines = true;
            this.LstReadData.HideSelection = false;
            this.LstReadData.Location = new System.Drawing.Point(96, 470);
            this.LstReadData.MultiSelect = false;
            this.LstReadData.Name = "LstReadData";
            this.LstReadData.Size = new System.Drawing.Size(856, 429);
            this.LstReadData.TabIndex = 322;
            this.LstReadData.UseCompatibleStateImageBehavior = false;
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label1.ForeColor = System.Drawing.Color.Black;
            this.Label1.Location = new System.Drawing.Point(993, 82);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(45, 30);
            this.Label1.TabIndex = 85;
            this.Label1.Text = "～";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DTPicTo
            // 
            this.DTPicTo.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DTPicTo.Location = new System.Drawing.Point(1044, 76);
            this.DTPicTo.Name = "DTPicTo";
            this.DTPicTo.Size = new System.Drawing.Size(196, 36);
            this.DTPicTo.TabIndex = 84;
            // 
            // DTPicFrom
            // 
            this.DTPicFrom.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DTPicFrom.Location = new System.Drawing.Point(791, 76);
            this.DTPicFrom.Name = "DTPicFrom";
            this.DTPicFrom.Size = new System.Drawing.Size(196, 36);
            this.DTPicFrom.TabIndex = 83;
            // 
            // ChkDateNarrow
            // 
            this.ChkDateNarrow.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ChkDateNarrow.Location = new System.Drawing.Point(619, 79);
            this.ChkDateNarrow.Name = "ChkDateNarrow";
            this.ChkDateNarrow.Size = new System.Drawing.Size(178, 29);
            this.ChkDateNarrow.TabIndex = 82;
            this.ChkDateNarrow.Text = "日付で絞り込む";
            this.ChkDateNarrow.UseVisualStyleBackColor = true;
            // 
            // Label21
            // 
            this.Label21.BackColor = System.Drawing.Color.Blue;
            this.Label21.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label21.ForeColor = System.Drawing.Color.White;
            this.Label21.Location = new System.Drawing.Point(449, 76);
            this.Label21.Name = "Label21";
            this.Label21.Size = new System.Drawing.Size(163, 35);
            this.Label21.TabIndex = 78;
            this.Label21.Text = "検索日付範囲";
            this.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblSelectedFile
            // 
            this.LblSelectedFile.BackColor = System.Drawing.Color.White;
            this.LblSelectedFile.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblSelectedFile.ForeColor = System.Drawing.Color.Black;
            this.LblSelectedFile.Location = new System.Drawing.Point(98, 125);
            this.LblSelectedFile.Name = "LblSelectedFile";
            this.LblSelectedFile.Size = new System.Drawing.Size(298, 36);
            this.LblSelectedFile.TabIndex = 346;
            this.LblSelectedFile.Text = "LblSelectedFile";
            this.LblSelectedFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PicWaitContent
            // 
            this.PicWaitContent.Image = global::FrontAndBackInspectionApp.Properties.Resources.waiting;
            this.PicWaitContent.Location = new System.Drawing.Point(909, 640);
            this.PicWaitContent.Name = "PicWaitContent";
            this.PicWaitContent.Size = new System.Drawing.Size(100, 100);
            this.PicWaitContent.TabIndex = 349;
            this.PicWaitContent.TabStop = false;
            // 
            // PicWaitList
            // 
            this.PicWaitList.Image = global::FrontAndBackInspectionApp.Properties.Resources.waiting;
            this.PicWaitList.Location = new System.Drawing.Point(909, 252);
            this.PicWaitList.Name = "PicWaitList";
            this.PicWaitList.Size = new System.Drawing.Size(100, 100);
            this.PicWaitList.TabIndex = 348;
            this.PicWaitList.TabStop = false;
            // 
            // BtnJobClear
            // 
            this.BtnJobClear.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnJobClear.Image = global::FrontAndBackInspectionApp.Properties.Resources.clear;
            this.BtnJobClear.Location = new System.Drawing.Point(254, 76);
            this.BtnJobClear.Name = "BtnJobClear";
            this.BtnJobClear.Size = new System.Drawing.Size(144, 46);
            this.BtnJobClear.TabIndex = 347;
            this.BtnJobClear.Text = "JOBクリア";
            this.BtnJobClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnJobClear.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Image = global::FrontAndBackInspectionApp.Properties.Resources.search_file;
            this.button1.Location = new System.Drawing.Point(96, 76);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 46);
            this.button1.TabIndex = 345;
            this.button1.Text = "JOB選択";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // BtnUpdate
            // 
            this.BtnUpdate.BackColor = System.Drawing.Color.LightGreen;
            this.BtnUpdate.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnUpdate.Image = global::FrontAndBackInspectionApp.Properties.Resources.update;
            this.BtnUpdate.Location = new System.Drawing.Point(1644, 76);
            this.BtnUpdate.Name = "BtnUpdate";
            this.BtnUpdate.Size = new System.Drawing.Size(168, 85);
            this.BtnUpdate.TabIndex = 344;
            this.BtnUpdate.Text = "更新";
            this.BtnUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnUpdate.UseVisualStyleBackColor = false;
            // 
            // BtnDispLogContent
            // 
            this.BtnDispLogContent.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnDispLogContent.Image = global::FrontAndBackInspectionApp.Properties.Resources.display_small;
            this.BtnDispLogContent.Location = new System.Drawing.Point(296, 942);
            this.BtnDispLogContent.Name = "BtnDispLogContent";
            this.BtnDispLogContent.Size = new System.Drawing.Size(180, 65);
            this.BtnDispLogContent.TabIndex = 87;
            this.BtnDispLogContent.Text = "ログ表示";
            this.BtnDispLogContent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnDispLogContent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnDispLogContent.UseVisualStyleBackColor = true;
            this.BtnDispLogContent.Visible = false;
            // 
            // BtnUnLock
            // 
            this.BtnUnLock.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnUnLock.Image = global::FrontAndBackInspectionApp.Properties.Resources.gear_small;
            this.BtnUnLock.Location = new System.Drawing.Point(96, 942);
            this.BtnUnLock.Name = "BtnUnLock";
            this.BtnUnLock.Size = new System.Drawing.Size(180, 65);
            this.BtnUnLock.TabIndex = 86;
            this.BtnUnLock.Text = "絞込解除";
            this.BtnUnLock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnUnLock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnUnLock.UseVisualStyleBackColor = true;
            this.BtnUnLock.Visible = false;
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
            // LblLogFileCount
            // 
            this.LblLogFileCount.BackColor = System.Drawing.Color.CornflowerBlue;
            this.LblLogFileCount.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblLogFileCount.ForeColor = System.Drawing.Color.White;
            this.LblLogFileCount.Location = new System.Drawing.Point(110, 181);
            this.LblLogFileCount.Name = "LblLogFileCount";
            this.LblLogFileCount.Size = new System.Drawing.Size(536, 23);
            this.LblLogFileCount.TabIndex = 351;
            this.LblLogFileCount.Text = "LblLogFileCount";
            this.LblLogFileCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(96, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1724, 31);
            this.label3.TabIndex = 350;
            this.label3.Text = "検査ログ一覧";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LsvLogList
            // 
            this.LsvLogList.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LsvLogList.FullRowSelect = true;
            this.LsvLogList.GridLines = true;
            this.LsvLogList.HideSelection = false;
            this.LsvLogList.Location = new System.Drawing.Point(96, 205);
            this.LsvLogList.Name = "LsvLogList";
            this.LsvLogList.Size = new System.Drawing.Size(1724, 221);
            this.LsvLogList.TabIndex = 352;
            this.LsvLogList.UseCompatibleStateImageBehavior = false;
            // 
            // LogManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.BtnDispLogContent);
            this.Controls.Add(this.DTPicTo);
            this.Controls.Add(this.BtnUnLock);
            this.Controls.Add(this.DTPicFrom);
            this.Controls.Add(this.PicWaitList);
            this.Controls.Add(this.ChkDateNarrow);
            this.Controls.Add(this.LblLogFileCount);
            this.Controls.Add(this.Label21);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LsvLogList);
            this.Controls.Add(this.PicWaitContent);
            this.Controls.Add(this.BtnJobClear);
            this.Controls.Add(this.LblSelectedFile);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.LsbJobInfo);
            this.Controls.Add(this.lblTranOSNGCount);
            this.Controls.Add(this.lblTranOSCount);
            this.Controls.Add(this.LblError);
            this.Controls.Add(this.LblKensa);
            this.Controls.Add(this.LstError);
            this.Controls.Add(this.LstReadData);
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
            ((System.ComponentModel.ISupportInitialize)(this.PicWaitContent)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicWaitList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label LblVersion;
        internal System.Windows.Forms.Label LblTitle;
        internal System.Windows.Forms.ListBox LsbJobInfo;
        internal System.Windows.Forms.Label lblTranOSNGCount;
        internal System.Windows.Forms.Label lblTranOSCount;
        internal System.Windows.Forms.Label LblError;
        internal System.Windows.Forms.Label LblKensa;
        internal System.Windows.Forms.ListView LstError;
        internal System.Windows.Forms.ListView LstReadData;
        internal System.Windows.Forms.Button BtnDispLogContent;
        internal System.Windows.Forms.Button BtnUnLock;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.DateTimePicker DTPicTo;
        internal System.Windows.Forms.DateTimePicker DTPicFrom;
        internal System.Windows.Forms.CheckBox ChkDateNarrow;
        internal System.Windows.Forms.Label Label21;
        internal System.Windows.Forms.Button BtnBack;
        internal System.Windows.Forms.Button BtnJobClear;
        internal System.Windows.Forms.Label LblSelectedFile;
        internal System.Windows.Forms.Button button1;
        internal System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.PictureBox PicWaitContent;
        private System.Windows.Forms.PictureBox PicWaitList;
        private System.Windows.Forms.Label LblLogFileCount;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView LsvLogList;
    }
}