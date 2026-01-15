namespace FrontAndBackSimulatorApp
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.LblVersion = new System.Windows.Forms.Label();
            this.LsbRecvBox = new System.Windows.Forms.ListBox();
            this.LsbSendBox = new System.Windows.Forms.ListBox();
            this.SerialPortQr = new System.IO.Ports.SerialPort(this.components);
            this.LblError = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.TimSendData = new System.Windows.Forms.Timer(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.CmbReadOmote = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CmbReadUra = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CmbMatchDetection = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CmbSerialNumJudg = new System.Windows.Forms.ComboBox();
            this.TxtReadOmote = new System.Windows.Forms.TextBox();
            this.TxtReadUra = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.CmbError = new System.Windows.Forms.ComboBox();
            this.BtnSendData = new System.Windows.Forms.Button();
            this.BtnError = new System.Windows.Forms.Button();
            this.BtnConfirmation = new System.Windows.Forms.Button();
            this.BtnStop = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.BtnEnd = new System.Windows.Forms.Button();
            this.ChkIsNull = new System.Windows.Forms.CheckBox();
            this.BtnAuto = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.CmbTimer = new System.Windows.Forms.ComboBox();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblVersion
            // 
            this.LblVersion.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblVersion.ForeColor = System.Drawing.Color.Blue;
            this.LblVersion.Location = new System.Drawing.Point(796, 566);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(147, 25);
            this.LblVersion.TabIndex = 343;
            this.LblVersion.Text = "LblVersion";
            this.LblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LsbRecvBox
            // 
            this.LsbRecvBox.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LsbRecvBox.FormattingEnabled = true;
            this.LsbRecvBox.ItemHeight = 24;
            this.LsbRecvBox.Location = new System.Drawing.Point(12, 22);
            this.LsbRecvBox.Name = "LsbRecvBox";
            this.LsbRecvBox.Size = new System.Drawing.Size(549, 196);
            this.LsbRecvBox.TabIndex = 12;
            // 
            // LsbSendBox
            // 
            this.LsbSendBox.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LsbSendBox.FormattingEnabled = true;
            this.LsbSendBox.ItemHeight = 24;
            this.LsbSendBox.Location = new System.Drawing.Point(11, 22);
            this.LsbSendBox.Name = "LsbSendBox";
            this.LsbSendBox.Size = new System.Drawing.Size(549, 196);
            this.LsbSendBox.TabIndex = 13;
            // 
            // LblError
            // 
            this.LblError.BackColor = System.Drawing.Color.LightCoral;
            this.LblError.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblError.ForeColor = System.Drawing.Color.Blue;
            this.LblError.Location = new System.Drawing.Point(53, 556);
            this.LblError.Name = "LblError";
            this.LblError.Size = new System.Drawing.Size(727, 45);
            this.LblError.TabIndex = 344;
            this.LblError.Text = "LblError";
            this.LblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblError.Visible = false;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.LsbRecvBox);
            this.groupBox8.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox8.Location = new System.Drawing.Point(383, 254);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(570, 230);
            this.groupBox8.TabIndex = 356;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "受信データ";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.LsbSendBox);
            this.groupBox7.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.groupBox7.Location = new System.Drawing.Point(383, 16);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(570, 230);
            this.groupBox7.TabIndex = 355;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "送信データ";
            // 
            // TimSendData
            // 
            this.TimSendData.Tick += new System.EventHandler(this.TimSendData_Tick);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.CmbReadOmote);
            this.groupBox4.Location = new System.Drawing.Point(178, 281);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(92, 60);
            this.groupBox4.TabIndex = 370;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "読取結果【表】";
            // 
            // CmbReadOmote
            // 
            this.CmbReadOmote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbReadOmote.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CmbReadOmote.FormattingEnabled = true;
            this.CmbReadOmote.Location = new System.Drawing.Point(6, 18);
            this.CmbReadOmote.Name = "CmbReadOmote";
            this.CmbReadOmote.Size = new System.Drawing.Size(80, 32);
            this.CmbReadOmote.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CmbReadUra);
            this.groupBox1.ForeColor = System.Drawing.Color.Red;
            this.groupBox1.Location = new System.Drawing.Point(178, 347);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(92, 60);
            this.groupBox1.TabIndex = 371;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "読取結果【裏】";
            // 
            // CmbReadUra
            // 
            this.CmbReadUra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbReadUra.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CmbReadUra.FormattingEnabled = true;
            this.CmbReadUra.Location = new System.Drawing.Point(6, 18);
            this.CmbReadUra.Name = "CmbReadUra";
            this.CmbReadUra.Size = new System.Drawing.Size(80, 32);
            this.CmbReadUra.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CmbMatchDetection);
            this.groupBox2.Location = new System.Drawing.Point(278, 281);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(92, 60);
            this.groupBox2.TabIndex = 372;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "表裏一致判定";
            // 
            // CmbMatchDetection
            // 
            this.CmbMatchDetection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMatchDetection.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CmbMatchDetection.FormattingEnabled = true;
            this.CmbMatchDetection.Location = new System.Drawing.Point(6, 18);
            this.CmbMatchDetection.Name = "CmbMatchDetection";
            this.CmbMatchDetection.Size = new System.Drawing.Size(80, 32);
            this.CmbMatchDetection.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CmbSerialNumJudg);
            this.groupBox3.Location = new System.Drawing.Point(278, 346);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(92, 60);
            this.groupBox3.TabIndex = 373;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "連番判定";
            // 
            // CmbSerialNumJudg
            // 
            this.CmbSerialNumJudg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSerialNumJudg.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CmbSerialNumJudg.FormattingEnabled = true;
            this.CmbSerialNumJudg.Location = new System.Drawing.Point(6, 18);
            this.CmbSerialNumJudg.Name = "CmbSerialNumJudg";
            this.CmbSerialNumJudg.Size = new System.Drawing.Size(80, 32);
            this.CmbSerialNumJudg.TabIndex = 0;
            // 
            // TxtReadOmote
            // 
            this.TxtReadOmote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtReadOmote.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtReadOmote.Location = new System.Drawing.Point(11, 18);
            this.TxtReadOmote.MaxLength = 17;
            this.TxtReadOmote.Name = "TxtReadOmote";
            this.TxtReadOmote.Size = new System.Drawing.Size(127, 31);
            this.TxtReadOmote.TabIndex = 375;
            this.TxtReadOmote.Text = "123456789";
            this.TxtReadOmote.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TxtReadUra
            // 
            this.TxtReadUra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtReadUra.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtReadUra.Location = new System.Drawing.Point(11, 18);
            this.TxtReadUra.MaxLength = 17;
            this.TxtReadUra.Name = "TxtReadUra";
            this.TxtReadUra.Size = new System.Drawing.Size(127, 31);
            this.TxtReadUra.TabIndex = 376;
            this.TxtReadUra.Text = "123456789";
            this.TxtReadUra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.TxtReadOmote);
            this.groupBox5.Location = new System.Drawing.Point(22, 281);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(150, 60);
            this.groupBox5.TabIndex = 371;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "照合データ【表】";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.TxtReadUra);
            this.groupBox6.ForeColor = System.Drawing.Color.Red;
            this.groupBox6.Location = new System.Drawing.Point(22, 347);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(150, 60);
            this.groupBox6.TabIndex = 376;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "照合データ【裏】";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.CmbError);
            this.groupBox9.Location = new System.Drawing.Point(40, 192);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(92, 60);
            this.groupBox9.TabIndex = 371;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "エラー番号";
            // 
            // CmbError
            // 
            this.CmbError.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbError.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CmbError.FormattingEnabled = true;
            this.CmbError.IntegralHeight = false;
            this.CmbError.ItemHeight = 24;
            this.CmbError.Location = new System.Drawing.Point(6, 18);
            this.CmbError.MaxDropDownItems = 10;
            this.CmbError.Name = "CmbError";
            this.CmbError.Size = new System.Drawing.Size(80, 32);
            this.CmbError.TabIndex = 0;
            // 
            // BtnSendData
            // 
            this.BtnSendData.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnSendData.Image = global::FrontAndBackSimulatorApp.Properties.Resources.qr_code;
            this.BtnSendData.Location = new System.Drawing.Point(33, 413);
            this.BtnSendData.Name = "BtnSendData";
            this.BtnSendData.Size = new System.Drawing.Size(331, 53);
            this.BtnSendData.TabIndex = 345;
            this.BtnSendData.Text = "照合結果送信（D）";
            this.BtnSendData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSendData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnSendData.UseVisualStyleBackColor = true;
            this.BtnSendData.Click += new System.EventHandler(this.BtnSendData_Click);
            // 
            // BtnError
            // 
            this.BtnError.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnError.Image = global::FrontAndBackSimulatorApp.Properties.Resources.warning;
            this.BtnError.Location = new System.Drawing.Point(138, 201);
            this.BtnError.Name = "BtnError";
            this.BtnError.Size = new System.Drawing.Size(198, 45);
            this.BtnError.TabIndex = 369;
            this.BtnError.Text = "エラー（E）";
            this.BtnError.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnError.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnError.UseVisualStyleBackColor = true;
            this.BtnError.Click += new System.EventHandler(this.BtnError_Click);
            // 
            // BtnConfirmation
            // 
            this.BtnConfirmation.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnConfirmation.Image = global::FrontAndBackSimulatorApp.Properties.Resources.bubble;
            this.BtnConfirmation.Location = new System.Drawing.Point(40, 38);
            this.BtnConfirmation.Name = "BtnConfirmation";
            this.BtnConfirmation.Size = new System.Drawing.Size(257, 45);
            this.BtnConfirmation.TabIndex = 361;
            this.BtnConfirmation.Text = "確認（A）";
            this.BtnConfirmation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnConfirmation.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnConfirmation.UseVisualStyleBackColor = true;
            this.BtnConfirmation.Click += new System.EventHandler(this.BtnConfirmation_Click);
            // 
            // BtnStop
            // 
            this.BtnStop.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnStop.Image = global::FrontAndBackSimulatorApp.Properties.Resources.standing;
            this.BtnStop.Location = new System.Drawing.Point(40, 141);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(257, 45);
            this.BtnStop.TabIndex = 359;
            this.BtnStop.Text = "停止（C）";
            this.BtnStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnStop.UseVisualStyleBackColor = true;
            this.BtnStop.Click += new System.EventHandler(this.BtnStop_Click);
            // 
            // BtnStart
            // 
            this.BtnStart.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnStart.Image = global::FrontAndBackSimulatorApp.Properties.Resources.running_icon;
            this.BtnStart.Location = new System.Drawing.Point(40, 90);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(257, 45);
            this.BtnStart.TabIndex = 358;
            this.BtnStart.Text = "開始（B）";
            this.BtnStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // BtnEnd
            // 
            this.BtnEnd.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnEnd.Image = global::FrontAndBackSimulatorApp.Properties.Resources.exit_icon_small;
            this.BtnEnd.Location = new System.Drawing.Point(794, 504);
            this.BtnEnd.Name = "BtnEnd";
            this.BtnEnd.Size = new System.Drawing.Size(149, 45);
            this.BtnEnd.TabIndex = 342;
            this.BtnEnd.Text = " 終了";
            this.BtnEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEnd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnEnd.UseVisualStyleBackColor = true;
            this.BtnEnd.Click += new System.EventHandler(this.BtnEnd_Click);
            // 
            // ChkIsNull
            // 
            this.ChkIsNull.AutoSize = true;
            this.ChkIsNull.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.ChkIsNull.Location = new System.Drawing.Point(38, 481);
            this.ChkIsNull.Name = "ChkIsNull";
            this.ChkIsNull.Size = new System.Drawing.Size(259, 28);
            this.ChkIsNull.TabIndex = 377;
            this.ChkIsNull.Text = "Dコマンドの先頭にNULLを付与";
            this.ChkIsNull.UseVisualStyleBackColor = true;
            // 
            // BtnAuto
            // 
            this.BtnAuto.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnAuto.Image = global::FrontAndBackSimulatorApp.Properties.Resources.qr_code;
            this.BtnAuto.Location = new System.Drawing.Point(481, 496);
            this.BtnAuto.Name = "BtnAuto";
            this.BtnAuto.Size = new System.Drawing.Size(210, 53);
            this.BtnAuto.TabIndex = 378;
            this.BtnAuto.Text = "自動送信開始";
            this.BtnAuto.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAuto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnAuto.UseVisualStyleBackColor = true;
            this.BtnAuto.Click += new System.EventHandler(this.BtnAuto_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.CmbTimer);
            this.groupBox10.Location = new System.Drawing.Point(383, 489);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(92, 60);
            this.groupBox10.TabIndex = 379;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "送信間隔";
            // 
            // CmbTimer
            // 
            this.CmbTimer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTimer.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CmbTimer.FormattingEnabled = true;
            this.CmbTimer.Location = new System.Drawing.Point(6, 18);
            this.CmbTimer.Name = "CmbTimer";
            this.CmbTimer.Size = new System.Drawing.Size(80, 32);
            this.CmbTimer.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.BtnAuto);
            this.Controls.Add(this.ChkIsNull);
            this.Controls.Add(this.groupBox9);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.BtnSendData);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.BtnError);
            this.Controls.Add(this.BtnConfirmation);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.BtnStart);
            this.Controls.Add(this.BtnEnd);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.LblError);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "■メインメニュー画面■";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnError;
        private System.Windows.Forms.Button BtnConfirmation;
        private System.Windows.Forms.Button BtnStop;
        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnSendData;
        private System.Windows.Forms.Button BtnEnd;
        internal System.Windows.Forms.Label LblVersion;
        private System.Windows.Forms.ListBox LsbRecvBox;
        private System.Windows.Forms.ListBox LsbSendBox;
        internal System.IO.Ports.SerialPort SerialPortQr;
        internal System.Windows.Forms.Label LblError;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Timer TimSendData;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox CmbReadOmote;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox CmbReadUra;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox CmbMatchDetection;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox CmbSerialNumJudg;
        private System.Windows.Forms.TextBox TxtReadOmote;
        private System.Windows.Forms.TextBox TxtReadUra;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.ComboBox CmbError;
        private System.Windows.Forms.CheckBox ChkIsNull;
        private System.Windows.Forms.Button BtnAuto;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.ComboBox CmbTimer;
    }
}

