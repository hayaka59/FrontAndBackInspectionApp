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
            this.lblTranOSNGCount = new System.Windows.Forms.Label();
            this.lblTranOSCount = new System.Windows.Forms.Label();
            this.LblError = new System.Windows.Forms.Label();
            this.LblKensa = new System.Windows.Forms.Label();
            this.LsvLogErrorContent = new System.Windows.Forms.ListView();
            this.LsvLogContent = new System.Windows.Forms.ListView();
            this.LblSelectedFile = new System.Windows.Forms.Label();
            this.PicWaitContent = new System.Windows.Forms.PictureBox();
            this.PicWaitList = new System.Windows.Forms.PictureBox();
            this.BtnJobClear = new System.Windows.Forms.Button();
            this.BtnJobSelect = new System.Windows.Forms.Button();
            this.BtnUpdate = new System.Windows.Forms.Button();
            this.BtnBack = new System.Windows.Forms.Button();
            this.LblLogFileCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.LsvLogList = new System.Windows.Forms.ListView();
            this.PctLogo = new System.Windows.Forms.PictureBox();
            this.GrpSortBy = new System.Windows.Forms.GroupBox();
            this.CmbSortBy = new System.Windows.Forms.ComboBox();
            this.GrpInspectionDate = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DtTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.ChkInspectionDate = new System.Windows.Forms.CheckBox();
            this.DtTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CmbJudgement = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PicWaitContent)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicWaitList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PctLogo)).BeginInit();
            this.GrpSortBy.SuspendLayout();
            this.GrpInspectionDate.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            // lblTranOSNGCount
            // 
            this.lblTranOSNGCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.lblTranOSNGCount.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTranOSNGCount.ForeColor = System.Drawing.Color.White;
            this.lblTranOSNGCount.Location = new System.Drawing.Point(1512, 440);
            this.lblTranOSNGCount.Name = "lblTranOSNGCount";
            this.lblTranOSNGCount.Size = new System.Drawing.Size(300, 29);
            this.lblTranOSNGCount.TabIndex = 331;
            this.lblTranOSNGCount.Text = "lblTranOSNGCount";
            this.lblTranOSNGCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTranOSCount
            // 
            this.lblTranOSCount.BackColor = System.Drawing.Color.Blue;
            this.lblTranOSCount.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTranOSCount.ForeColor = System.Drawing.Color.White;
            this.lblTranOSCount.Location = new System.Drawing.Point(642, 439);
            this.lblTranOSCount.Name = "lblTranOSCount";
            this.lblTranOSCount.Size = new System.Drawing.Size(300, 29);
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
            // LsvLogErrorContent
            // 
            this.LsvLogErrorContent.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LsvLogErrorContent.FullRowSelect = true;
            this.LsvLogErrorContent.GridLines = true;
            this.LsvLogErrorContent.HideSelection = false;
            this.LsvLogErrorContent.Location = new System.Drawing.Point(964, 470);
            this.LsvLogErrorContent.MultiSelect = false;
            this.LsvLogErrorContent.Name = "LsvLogErrorContent";
            this.LsvLogErrorContent.Size = new System.Drawing.Size(856, 429);
            this.LsvLogErrorContent.TabIndex = 323;
            this.LsvLogErrorContent.UseCompatibleStateImageBehavior = false;
            // 
            // LsvLogContent
            // 
            this.LsvLogContent.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LsvLogContent.FullRowSelect = true;
            this.LsvLogContent.GridLines = true;
            this.LsvLogContent.HideSelection = false;
            this.LsvLogContent.Location = new System.Drawing.Point(96, 470);
            this.LsvLogContent.MultiSelect = false;
            this.LsvLogContent.Name = "LsvLogContent";
            this.LsvLogContent.Size = new System.Drawing.Size(856, 429);
            this.LsvLogContent.TabIndex = 322;
            this.LsvLogContent.UseCompatibleStateImageBehavior = false;
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
            this.BtnJobClear.Click += new System.EventHandler(this.BtnJobClear_Click);
            // 
            // BtnJobSelect
            // 
            this.BtnJobSelect.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnJobSelect.Image = global::FrontAndBackInspectionApp.Properties.Resources.search_file;
            this.BtnJobSelect.Location = new System.Drawing.Point(96, 76);
            this.BtnJobSelect.Name = "BtnJobSelect";
            this.BtnJobSelect.Size = new System.Drawing.Size(144, 46);
            this.BtnJobSelect.TabIndex = 345;
            this.BtnJobSelect.Text = "JOB選択";
            this.BtnJobSelect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnJobSelect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnJobSelect.UseVisualStyleBackColor = true;
            this.BtnJobSelect.Click += new System.EventHandler(this.BtnJobSelect_Click);
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
            this.BtnUpdate.Click += new System.EventHandler(this.BtnUpdate_Click);
            // 
            // BtnBack
            // 
            this.BtnBack.Font = new System.Drawing.Font("メイリオ", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnBack.Image = global::FrontAndBackInspectionApp.Properties.Resources.back_arrow;
            this.BtnBack.Location = new System.Drawing.Point(1652, 941);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(168, 50);
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
            this.LsvLogList.SelectedIndexChanged += new System.EventHandler(this.LsvLogList_SelectedIndexChanged);
            // 
            // PctLogo
            // 
            this.PctLogo.Image = global::FrontAndBackInspectionApp.Properties.Resources.株式会社Ai_R横黒色背景透明;
            this.PctLogo.Location = new System.Drawing.Point(654, 980);
            this.PctLogo.Name = "PctLogo";
            this.PctLogo.Size = new System.Drawing.Size(288, 42);
            this.PctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PctLogo.TabIndex = 353;
            this.PctLogo.TabStop = false;
            // 
            // GrpSortBy
            // 
            this.GrpSortBy.Controls.Add(this.CmbSortBy);
            this.GrpSortBy.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GrpSortBy.Location = new System.Drawing.Point(417, 70);
            this.GrpSortBy.Name = "GrpSortBy";
            this.GrpSortBy.Size = new System.Drawing.Size(207, 85);
            this.GrpSortBy.TabIndex = 355;
            this.GrpSortBy.TabStop = false;
            this.GrpSortBy.Text = "並び順";
            // 
            // CmbSortBy
            // 
            this.CmbSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSortBy.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CmbSortBy.FormattingEnabled = true;
            this.CmbSortBy.IntegralHeight = false;
            this.CmbSortBy.ItemHeight = 31;
            this.CmbSortBy.Location = new System.Drawing.Point(14, 30);
            this.CmbSortBy.Name = "CmbSortBy";
            this.CmbSortBy.Size = new System.Drawing.Size(177, 39);
            this.CmbSortBy.TabIndex = 265;
            // 
            // GrpInspectionDate
            // 
            this.GrpInspectionDate.Controls.Add(this.label4);
            this.GrpInspectionDate.Controls.Add(this.DtTimePickerTo);
            this.GrpInspectionDate.Controls.Add(this.ChkInspectionDate);
            this.GrpInspectionDate.Controls.Add(this.DtTimePickerFrom);
            this.GrpInspectionDate.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.GrpInspectionDate.Location = new System.Drawing.Point(655, 70);
            this.GrpInspectionDate.Name = "GrpInspectionDate";
            this.GrpInspectionDate.Size = new System.Drawing.Size(719, 85);
            this.GrpInspectionDate.TabIndex = 354;
            this.GrpInspectionDate.TabStop = false;
            this.GrpInspectionDate.Text = "検査日付";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(435, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 31);
            this.label4.TabIndex = 269;
            this.label4.Text = "～";
            // 
            // DtTimePickerTo
            // 
            this.DtTimePickerTo.CalendarFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DtTimePickerTo.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DtTimePickerTo.Location = new System.Drawing.Point(476, 30);
            this.DtTimePickerTo.Name = "DtTimePickerTo";
            this.DtTimePickerTo.Size = new System.Drawing.Size(218, 39);
            this.DtTimePickerTo.TabIndex = 268;
            // 
            // ChkInspectionDate
            // 
            this.ChkInspectionDate.AutoSize = true;
            this.ChkInspectionDate.Location = new System.Drawing.Point(17, 33);
            this.ChkInspectionDate.Name = "ChkInspectionDate";
            this.ChkInspectionDate.Size = new System.Drawing.Size(180, 35);
            this.ChkInspectionDate.TabIndex = 267;
            this.ChkInspectionDate.Text = "更新条件に含む";
            this.ChkInspectionDate.UseVisualStyleBackColor = true;
            // 
            // DtTimePickerFrom
            // 
            this.DtTimePickerFrom.CalendarFont = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DtTimePickerFrom.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.DtTimePickerFrom.Location = new System.Drawing.Point(211, 30);
            this.DtTimePickerFrom.Name = "DtTimePickerFrom";
            this.DtTimePickerFrom.Size = new System.Drawing.Size(218, 39);
            this.DtTimePickerFrom.TabIndex = 266;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox1.Location = new System.Drawing.Point(96, 911);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 85);
            this.groupBox1.TabIndex = 356;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "QR読取り番号";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.Image = global::FrontAndBackInspectionApp.Properties.Resources.search_file;
            this.button1.Location = new System.Drawing.Point(404, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 46);
            this.button1.TabIndex = 346;
            this.button1.Text = "抽出";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(19, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(371, 39);
            this.textBox1.TabIndex = 269;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CmbJudgement);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox2.Location = new System.Drawing.Point(964, 911);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(645, 85);
            this.groupBox2.TabIndex = 357;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "QR読取番号と判定結果";
            // 
            // CmbJudgement
            // 
            this.CmbJudgement.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbJudgement.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CmbJudgement.FormattingEnabled = true;
            this.CmbJudgement.IntegralHeight = false;
            this.CmbJudgement.ItemHeight = 31;
            this.CmbJudgement.Location = new System.Drawing.Point(396, 34);
            this.CmbJudgement.Name = "CmbJudgement";
            this.CmbJudgement.Size = new System.Drawing.Size(115, 39);
            this.CmbJudgement.TabIndex = 347;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button2.Image = global::FrontAndBackInspectionApp.Properties.Resources.search_file;
            this.button2.Location = new System.Drawing.Point(517, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 46);
            this.button2.TabIndex = 346;
            this.button2.Text = "抽出";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(19, 34);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(371, 39);
            this.textBox2.TabIndex = 269;
            // 
            // LogManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.GrpSortBy);
            this.Controls.Add(this.GrpInspectionDate);
            this.Controls.Add(this.PctLogo);
            this.Controls.Add(this.PicWaitList);
            this.Controls.Add(this.LblLogFileCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LsvLogList);
            this.Controls.Add(this.PicWaitContent);
            this.Controls.Add(this.BtnJobClear);
            this.Controls.Add(this.LblSelectedFile);
            this.Controls.Add(this.BtnJobSelect);
            this.Controls.Add(this.BtnUpdate);
            this.Controls.Add(this.lblTranOSNGCount);
            this.Controls.Add(this.lblTranOSCount);
            this.Controls.Add(this.LblError);
            this.Controls.Add(this.LblKensa);
            this.Controls.Add(this.LsvLogErrorContent);
            this.Controls.Add(this.LsvLogContent);
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
            ((System.ComponentModel.ISupportInitialize)(this.PctLogo)).EndInit();
            this.GrpSortBy.ResumeLayout(false);
            this.GrpInspectionDate.ResumeLayout(false);
            this.GrpInspectionDate.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label LblVersion;
        internal System.Windows.Forms.Label LblTitle;
        internal System.Windows.Forms.Label lblTranOSNGCount;
        internal System.Windows.Forms.Label lblTranOSCount;
        internal System.Windows.Forms.Label LblError;
        internal System.Windows.Forms.Label LblKensa;
        internal System.Windows.Forms.ListView LsvLogErrorContent;
        internal System.Windows.Forms.ListView LsvLogContent;
        internal System.Windows.Forms.Button BtnBack;
        internal System.Windows.Forms.Button BtnJobClear;
        internal System.Windows.Forms.Label LblSelectedFile;
        internal System.Windows.Forms.Button BtnJobSelect;
        internal System.Windows.Forms.Button BtnUpdate;
        private System.Windows.Forms.PictureBox PicWaitContent;
        private System.Windows.Forms.PictureBox PicWaitList;
        private System.Windows.Forms.Label LblLogFileCount;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView LsvLogList;
        internal System.Windows.Forms.PictureBox PctLogo;
        private System.Windows.Forms.GroupBox GrpSortBy;
        internal System.Windows.Forms.ComboBox CmbSortBy;
        private System.Windows.Forms.GroupBox GrpInspectionDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker DtTimePickerTo;
        private System.Windows.Forms.CheckBox ChkInspectionDate;
        private System.Windows.Forms.DateTimePicker DtTimePickerFrom;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        internal System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox2;
        internal System.Windows.Forms.ComboBox CmbJudgement;
    }
}