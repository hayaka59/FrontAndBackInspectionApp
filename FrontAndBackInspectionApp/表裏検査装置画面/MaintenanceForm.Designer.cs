namespace FrontAndBackInspectionApp.表裏検査装置画面
{
    partial class MaintenanceForm
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
            this.TabControl1 = new System.Windows.Forms.TabControl();
            this.TabPage3 = new System.Windows.Forms.TabPage();
            this.GroupBox25 = new System.Windows.Forms.GroupBox();
            this.ChkIsDispLogo = new System.Windows.Forms.CheckBox();
            this.GroupBox12 = new System.Windows.Forms.GroupBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.GroupBox7 = new System.Windows.Forms.GroupBox();
            this.CmbComStopBit = new System.Windows.Forms.ComboBox();
            this.Label28 = new System.Windows.Forms.Label();
            this.CmbComParityVar = new System.Windows.Forms.ComboBox();
            this.Label27 = new System.Windows.Forms.Label();
            this.CmbComIsParty = new System.Windows.Forms.ComboBox();
            this.Label26 = new System.Windows.Forms.Label();
            this.CmbComDataLength = new System.Windows.Forms.ComboBox();
            this.Label24 = new System.Windows.Forms.Label();
            this.CmbComSpeed = new System.Windows.Forms.ComboBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.CmbComPort = new System.Windows.Forms.ComboBox();
            this.Label23 = new System.Windows.Forms.Label();
            this.GroupBox6 = new System.Windows.Forms.GroupBox();
            this.TxtHddSpace = new System.Windows.Forms.TextBox();
            this.Label29 = new System.Windows.Forms.Label();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.TxtMachineName = new System.Windows.Forms.TextBox();
            this.Label32 = new System.Windows.Forms.Label();
            this.TabPage5 = new System.Windows.Forms.TabPage();
            this.GroupBox9 = new System.Windows.Forms.GroupBox();
            this.TxtBackupFolder = new System.Windows.Forms.TextBox();
            this.BtnSelectBackupFolder = new System.Windows.Forms.Button();
            this.Label35 = new System.Windows.Forms.Label();
            this.GroupBox8 = new System.Windows.Forms.GroupBox();
            this.TxtLogFolder = new System.Windows.Forms.TextBox();
            this.Label33 = new System.Windows.Forms.Label();
            this.GroupBox11 = new System.Windows.Forms.GroupBox();
            this.CmbSaveMonth = new System.Windows.Forms.ComboBox();
            this.Label36 = new System.Windows.Forms.Label();
            this.PctLogo = new System.Windows.Forms.PictureBox();
            this.BtnApply = new System.Windows.Forms.Button();
            this.BtnDeleteLogData = new System.Windows.Forms.Button();
            this.BtnSelectLogFolder = new System.Windows.Forms.Button();
            this.BtnBack = new System.Windows.Forms.Button();
            this.TabControl1.SuspendLayout();
            this.TabPage3.SuspendLayout();
            this.GroupBox25.SuspendLayout();
            this.GroupBox12.SuspendLayout();
            this.GroupBox7.SuspendLayout();
            this.GroupBox6.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.TabPage5.SuspendLayout();
            this.GroupBox9.SuspendLayout();
            this.GroupBox8.SuspendLayout();
            this.GroupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PctLogo)).BeginInit();
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
            // TabControl1
            // 
            this.TabControl1.Controls.Add(this.TabPage3);
            this.TabControl1.Controls.Add(this.TabPage5);
            this.TabControl1.Location = new System.Drawing.Point(370, 82);
            this.TabControl1.Name = "TabControl1";
            this.TabControl1.SelectedIndex = 0;
            this.TabControl1.Size = new System.Drawing.Size(1167, 738);
            this.TabControl1.TabIndex = 321;
            // 
            // TabPage3
            // 
            this.TabPage3.Controls.Add(this.GroupBox11);
            this.TabPage3.Controls.Add(this.GroupBox25);
            this.TabPage3.Controls.Add(this.GroupBox12);
            this.TabPage3.Controls.Add(this.GroupBox7);
            this.TabPage3.Controls.Add(this.GroupBox6);
            this.TabPage3.Controls.Add(this.GroupBox5);
            this.TabPage3.Location = new System.Drawing.Point(4, 33);
            this.TabPage3.Name = "TabPage3";
            this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage3.Size = new System.Drawing.Size(1159, 701);
            this.TabPage3.TabIndex = 2;
            this.TabPage3.Text = "システム設定";
            this.TabPage3.UseVisualStyleBackColor = true;
            // 
            // GroupBox25
            // 
            this.GroupBox25.Controls.Add(this.ChkIsDispLogo);
            this.GroupBox25.Location = new System.Drawing.Point(225, 350);
            this.GroupBox25.Name = "GroupBox25";
            this.GroupBox25.Size = new System.Drawing.Size(328, 69);
            this.GroupBox25.TabIndex = 9;
            this.GroupBox25.TabStop = false;
            this.GroupBox25.Text = "ロゴ表示";
            // 
            // ChkIsDispLogo
            // 
            this.ChkIsDispLogo.Location = new System.Drawing.Point(56, 30);
            this.ChkIsDispLogo.Name = "ChkIsDispLogo";
            this.ChkIsDispLogo.Size = new System.Drawing.Size(189, 24);
            this.ChkIsDispLogo.TabIndex = 0;
            this.ChkIsDispLogo.Text = "ロゴを表示する";
            this.ChkIsDispLogo.UseVisualStyleBackColor = true;
            this.ChkIsDispLogo.CheckedChanged += new System.EventHandler(this.ChkIsDispLogo_CheckedChanged);
            // 
            // GroupBox12
            // 
            this.GroupBox12.Controls.Add(this.TxtPassword);
            this.GroupBox12.Location = new System.Drawing.Point(225, 254);
            this.GroupBox12.Name = "GroupBox12";
            this.GroupBox12.Size = new System.Drawing.Size(328, 80);
            this.GroupBox12.TabIndex = 4;
            this.GroupBox12.TabStop = false;
            this.GroupBox12.Text = "パスワード設定";
            // 
            // TxtPassword
            // 
            this.TxtPassword.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtPassword.Location = new System.Drawing.Point(32, 31);
            this.TxtPassword.MaxLength = 4;
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.Size = new System.Drawing.Size(260, 31);
            this.TxtPassword.TabIndex = 0;
            this.TxtPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // GroupBox7
            // 
            this.GroupBox7.Controls.Add(this.CmbComStopBit);
            this.GroupBox7.Controls.Add(this.Label28);
            this.GroupBox7.Controls.Add(this.CmbComParityVar);
            this.GroupBox7.Controls.Add(this.Label27);
            this.GroupBox7.Controls.Add(this.CmbComIsParty);
            this.GroupBox7.Controls.Add(this.Label26);
            this.GroupBox7.Controls.Add(this.CmbComDataLength);
            this.GroupBox7.Controls.Add(this.Label24);
            this.GroupBox7.Controls.Add(this.CmbComSpeed);
            this.GroupBox7.Controls.Add(this.Label6);
            this.GroupBox7.Controls.Add(this.CmbComPort);
            this.GroupBox7.Controls.Add(this.Label23);
            this.GroupBox7.Location = new System.Drawing.Point(601, 74);
            this.GroupBox7.Name = "GroupBox7";
            this.GroupBox7.Size = new System.Drawing.Size(341, 260);
            this.GroupBox7.TabIndex = 3;
            this.GroupBox7.TabStop = false;
            this.GroupBox7.Text = "ＲＳ－２３２Ｃ設定";
            // 
            // CmbComStopBit
            // 
            this.CmbComStopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbComStopBit.FormattingEnabled = true;
            this.CmbComStopBit.Location = new System.Drawing.Point(185, 206);
            this.CmbComStopBit.Name = "CmbComStopBit";
            this.CmbComStopBit.Size = new System.Drawing.Size(121, 32);
            this.CmbComStopBit.TabIndex = 93;
            // 
            // Label28
            // 
            this.Label28.BackColor = System.Drawing.Color.Blue;
            this.Label28.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label28.ForeColor = System.Drawing.Color.White;
            this.Label28.Location = new System.Drawing.Point(24, 206);
            this.Label28.Name = "Label28";
            this.Label28.Size = new System.Drawing.Size(160, 30);
            this.Label28.TabIndex = 92;
            this.Label28.Text = "ストップビット";
            this.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CmbComParityVar
            // 
            this.CmbComParityVar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbComParityVar.FormattingEnabled = true;
            this.CmbComParityVar.Location = new System.Drawing.Point(185, 171);
            this.CmbComParityVar.Name = "CmbComParityVar";
            this.CmbComParityVar.Size = new System.Drawing.Size(121, 32);
            this.CmbComParityVar.TabIndex = 91;
            // 
            // Label27
            // 
            this.Label27.BackColor = System.Drawing.Color.Blue;
            this.Label27.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label27.ForeColor = System.Drawing.Color.White;
            this.Label27.Location = new System.Drawing.Point(24, 172);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(160, 30);
            this.Label27.TabIndex = 90;
            this.Label27.Text = "パリティ種別";
            this.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CmbComIsParty
            // 
            this.CmbComIsParty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbComIsParty.FormattingEnabled = true;
            this.CmbComIsParty.Location = new System.Drawing.Point(185, 135);
            this.CmbComIsParty.Name = "CmbComIsParty";
            this.CmbComIsParty.Size = new System.Drawing.Size(121, 32);
            this.CmbComIsParty.TabIndex = 89;
            // 
            // Label26
            // 
            this.Label26.BackColor = System.Drawing.Color.Blue;
            this.Label26.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label26.ForeColor = System.Drawing.Color.White;
            this.Label26.Location = new System.Drawing.Point(24, 136);
            this.Label26.Name = "Label26";
            this.Label26.Size = new System.Drawing.Size(160, 30);
            this.Label26.TabIndex = 88;
            this.Label26.Text = "パリティ無効／有効";
            this.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CmbComDataLength
            // 
            this.CmbComDataLength.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbComDataLength.FormattingEnabled = true;
            this.CmbComDataLength.Location = new System.Drawing.Point(185, 100);
            this.CmbComDataLength.Name = "CmbComDataLength";
            this.CmbComDataLength.Size = new System.Drawing.Size(121, 32);
            this.CmbComDataLength.TabIndex = 87;
            // 
            // Label24
            // 
            this.Label24.BackColor = System.Drawing.Color.Blue;
            this.Label24.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label24.ForeColor = System.Drawing.Color.White;
            this.Label24.Location = new System.Drawing.Point(24, 101);
            this.Label24.Name = "Label24";
            this.Label24.Size = new System.Drawing.Size(160, 30);
            this.Label24.TabIndex = 86;
            this.Label24.Text = "データ長";
            this.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CmbComSpeed
            // 
            this.CmbComSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbComSpeed.FormattingEnabled = true;
            this.CmbComSpeed.Location = new System.Drawing.Point(185, 65);
            this.CmbComSpeed.Name = "CmbComSpeed";
            this.CmbComSpeed.Size = new System.Drawing.Size(121, 32);
            this.CmbComSpeed.TabIndex = 85;
            // 
            // Label6
            // 
            this.Label6.BackColor = System.Drawing.Color.Blue;
            this.Label6.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label6.ForeColor = System.Drawing.Color.White;
            this.Label6.Location = new System.Drawing.Point(24, 66);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(160, 30);
            this.Label6.TabIndex = 84;
            this.Label6.Text = "通信速度";
            this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CmbComPort
            // 
            this.CmbComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbComPort.FormattingEnabled = true;
            this.CmbComPort.Location = new System.Drawing.Point(185, 29);
            this.CmbComPort.Name = "CmbComPort";
            this.CmbComPort.Size = new System.Drawing.Size(121, 32);
            this.CmbComPort.TabIndex = 83;
            // 
            // Label23
            // 
            this.Label23.BackColor = System.Drawing.Color.Blue;
            this.Label23.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label23.ForeColor = System.Drawing.Color.White;
            this.Label23.Location = new System.Drawing.Point(24, 31);
            this.Label23.Name = "Label23";
            this.Label23.Size = new System.Drawing.Size(160, 30);
            this.Label23.TabIndex = 82;
            this.Label23.Text = "ポート";
            this.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GroupBox6
            // 
            this.GroupBox6.Controls.Add(this.TxtHddSpace);
            this.GroupBox6.Controls.Add(this.Label29);
            this.GroupBox6.Location = new System.Drawing.Point(225, 166);
            this.GroupBox6.Name = "GroupBox6";
            this.GroupBox6.Size = new System.Drawing.Size(328, 75);
            this.GroupBox6.TabIndex = 2;
            this.GroupBox6.TabStop = false;
            this.GroupBox6.Text = "ディスク空き容量チェック";
            // 
            // TxtHddSpace
            // 
            this.TxtHddSpace.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtHddSpace.Location = new System.Drawing.Point(23, 33);
            this.TxtHddSpace.MaxLength = 4;
            this.TxtHddSpace.Name = "TxtHddSpace";
            this.TxtHddSpace.Size = new System.Drawing.Size(85, 31);
            this.TxtHddSpace.TabIndex = 90;
            this.TxtHddSpace.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label29
            // 
            this.Label29.BackColor = System.Drawing.Color.Transparent;
            this.Label29.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label29.ForeColor = System.Drawing.Color.Black;
            this.Label29.Location = new System.Drawing.Point(114, 34);
            this.Label29.Name = "Label29";
            this.Label29.Size = new System.Drawing.Size(178, 30);
            this.Label29.TabIndex = 89;
            this.Label29.Text = "ＧＢ未満で警告を表示";
            this.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.TxtMachineName);
            this.GroupBox5.Controls.Add(this.Label32);
            this.GroupBox5.Location = new System.Drawing.Point(225, 74);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(328, 75);
            this.GroupBox5.TabIndex = 1;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "装置名称";
            // 
            // TxtMachineName
            // 
            this.TxtMachineName.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtMachineName.Location = new System.Drawing.Point(120, 29);
            this.TxtMachineName.MaxLength = 100;
            this.TxtMachineName.Name = "TxtMachineName";
            this.TxtMachineName.Size = new System.Drawing.Size(178, 31);
            this.TxtMachineName.TabIndex = 89;
            this.TxtMachineName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Label32
            // 
            this.Label32.BackColor = System.Drawing.Color.Blue;
            this.Label32.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label32.ForeColor = System.Drawing.Color.White;
            this.Label32.Location = new System.Drawing.Point(19, 29);
            this.Label32.Name = "Label32";
            this.Label32.Size = new System.Drawing.Size(100, 30);
            this.Label32.TabIndex = 88;
            this.Label32.Text = "装置名称";
            this.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TabPage5
            // 
            this.TabPage5.Controls.Add(this.GroupBox9);
            this.TabPage5.Controls.Add(this.GroupBox8);
            this.TabPage5.Location = new System.Drawing.Point(4, 33);
            this.TabPage5.Name = "TabPage5";
            this.TabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage5.Size = new System.Drawing.Size(1159, 701);
            this.TabPage5.TabIndex = 4;
            this.TabPage5.Text = "フォルダ設定";
            this.TabPage5.UseVisualStyleBackColor = true;
            // 
            // GroupBox9
            // 
            this.GroupBox9.Controls.Add(this.TxtBackupFolder);
            this.GroupBox9.Controls.Add(this.BtnSelectBackupFolder);
            this.GroupBox9.Controls.Add(this.Label35);
            this.GroupBox9.Location = new System.Drawing.Point(30, 177);
            this.GroupBox9.Name = "GroupBox9";
            this.GroupBox9.Size = new System.Drawing.Size(1085, 95);
            this.GroupBox9.TabIndex = 3;
            this.GroupBox9.TabStop = false;
            this.GroupBox9.Text = "ログバックアップフォルダ";
            // 
            // TxtBackupFolder
            // 
            this.TxtBackupFolder.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtBackupFolder.Location = new System.Drawing.Point(185, 32);
            this.TxtBackupFolder.Name = "TxtBackupFolder";
            this.TxtBackupFolder.Size = new System.Drawing.Size(728, 39);
            this.TxtBackupFolder.TabIndex = 93;
            // 
            // BtnSelectBackupFolder
            // 
            this.BtnSelectBackupFolder.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnSelectBackupFolder.Image = global::FrontAndBackInspectionApp.Properties.Resources.folder_ref;
            this.BtnSelectBackupFolder.Location = new System.Drawing.Point(919, 25);
            this.BtnSelectBackupFolder.Name = "BtnSelectBackupFolder";
            this.BtnSelectBackupFolder.Size = new System.Drawing.Size(150, 50);
            this.BtnSelectBackupFolder.TabIndex = 89;
            this.BtnSelectBackupFolder.Text = "選択";
            this.BtnSelectBackupFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSelectBackupFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnSelectBackupFolder.UseVisualStyleBackColor = true;
            this.BtnSelectBackupFolder.Click += new System.EventHandler(this.BtnSelectBackupFolder_Click);
            // 
            // Label35
            // 
            this.Label35.BackColor = System.Drawing.Color.Blue;
            this.Label35.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label35.ForeColor = System.Drawing.Color.White;
            this.Label35.Location = new System.Drawing.Point(21, 31);
            this.Label35.Name = "Label35";
            this.Label35.Size = new System.Drawing.Size(160, 40);
            this.Label35.TabIndex = 88;
            this.Label35.Text = "フォルダ①";
            this.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GroupBox8
            // 
            this.GroupBox8.Controls.Add(this.TxtLogFolder);
            this.GroupBox8.Controls.Add(this.BtnSelectLogFolder);
            this.GroupBox8.Controls.Add(this.Label33);
            this.GroupBox8.Location = new System.Drawing.Point(30, 62);
            this.GroupBox8.Name = "GroupBox8";
            this.GroupBox8.Size = new System.Drawing.Size(1085, 87);
            this.GroupBox8.TabIndex = 2;
            this.GroupBox8.TabStop = false;
            this.GroupBox8.Text = "ログフォルダ";
            // 
            // TxtLogFolder
            // 
            this.TxtLogFolder.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtLogFolder.Location = new System.Drawing.Point(185, 32);
            this.TxtLogFolder.Name = "TxtLogFolder";
            this.TxtLogFolder.Size = new System.Drawing.Size(728, 39);
            this.TxtLogFolder.TabIndex = 90;
            // 
            // Label33
            // 
            this.Label33.BackColor = System.Drawing.Color.Blue;
            this.Label33.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label33.ForeColor = System.Drawing.Color.White;
            this.Label33.Location = new System.Drawing.Point(23, 31);
            this.Label33.Name = "Label33";
            this.Label33.Size = new System.Drawing.Size(160, 40);
            this.Label33.TabIndex = 88;
            this.Label33.Text = "フォルダ";
            this.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GroupBox11
            // 
            this.GroupBox11.Controls.Add(this.CmbSaveMonth);
            this.GroupBox11.Controls.Add(this.BtnDeleteLogData);
            this.GroupBox11.Controls.Add(this.Label36);
            this.GroupBox11.Location = new System.Drawing.Point(225, 435);
            this.GroupBox11.Name = "GroupBox11";
            this.GroupBox11.Size = new System.Drawing.Size(328, 147);
            this.GroupBox11.TabIndex = 10;
            this.GroupBox11.TabStop = false;
            this.GroupBox11.Text = "ログ保存";
            // 
            // CmbSaveMonth
            // 
            this.CmbSaveMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbSaveMonth.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.CmbSaveMonth.FormattingEnabled = true;
            this.CmbSaveMonth.IntegralHeight = false;
            this.CmbSaveMonth.Location = new System.Drawing.Point(120, 33);
            this.CmbSaveMonth.Name = "CmbSaveMonth";
            this.CmbSaveMonth.Size = new System.Drawing.Size(178, 32);
            this.CmbSaveMonth.TabIndex = 90;
            // 
            // Label36
            // 
            this.Label36.BackColor = System.Drawing.Color.Blue;
            this.Label36.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label36.ForeColor = System.Drawing.Color.White;
            this.Label36.Location = new System.Drawing.Point(19, 34);
            this.Label36.Name = "Label36";
            this.Label36.Size = new System.Drawing.Size(100, 30);
            this.Label36.TabIndex = 88;
            this.Label36.Text = "保存期間";
            this.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PctLogo
            // 
            this.PctLogo.Image = global::FrontAndBackInspectionApp.Properties.Resources.株式会社Ai_R横黒色背景透明;
            this.PctLogo.Location = new System.Drawing.Point(1604, 944);
            this.PctLogo.Name = "PctLogo";
            this.PctLogo.Size = new System.Drawing.Size(288, 42);
            this.PctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PctLogo.TabIndex = 324;
            this.PctLogo.TabStop = false;
            // 
            // BtnApply
            // 
            this.BtnApply.Font = new System.Drawing.Font("メイリオ", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnApply.Image = global::FrontAndBackInspectionApp.Properties.Resources.check;
            this.BtnApply.Location = new System.Drawing.Point(367, 841);
            this.BtnApply.Name = "BtnApply";
            this.BtnApply.Size = new System.Drawing.Size(300, 50);
            this.BtnApply.TabIndex = 322;
            this.BtnApply.Text = "適用";
            this.BtnApply.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnApply.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnApply.UseVisualStyleBackColor = true;
            this.BtnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // BtnDeleteLogData
            // 
            this.BtnDeleteLogData.Font = new System.Drawing.Font("メイリオ", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnDeleteLogData.Image = global::FrontAndBackInspectionApp.Properties.Resources.clear;
            this.BtnDeleteLogData.Location = new System.Drawing.Point(19, 80);
            this.BtnDeleteLogData.Name = "BtnDeleteLogData";
            this.BtnDeleteLogData.Size = new System.Drawing.Size(280, 50);
            this.BtnDeleteLogData.TabIndex = 89;
            this.BtnDeleteLogData.Text = "ログデータ手動削除";
            this.BtnDeleteLogData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnDeleteLogData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnDeleteLogData.UseVisualStyleBackColor = true;
            // 
            // BtnSelectLogFolder
            // 
            this.BtnSelectLogFolder.Font = new System.Drawing.Font("メイリオ", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnSelectLogFolder.Image = global::FrontAndBackInspectionApp.Properties.Resources.folder_ref;
            this.BtnSelectLogFolder.Location = new System.Drawing.Point(919, 25);
            this.BtnSelectLogFolder.Name = "BtnSelectLogFolder";
            this.BtnSelectLogFolder.Size = new System.Drawing.Size(150, 50);
            this.BtnSelectLogFolder.TabIndex = 89;
            this.BtnSelectLogFolder.Text = "選択";
            this.BtnSelectLogFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnSelectLogFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnSelectLogFolder.UseVisualStyleBackColor = true;
            this.BtnSelectLogFolder.Click += new System.EventHandler(this.BtnSelectLogFolder_Click);
            // 
            // BtnBack
            // 
            this.BtnBack.Font = new System.Drawing.Font("メイリオ", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnBack.Image = global::FrontAndBackInspectionApp.Properties.Resources.back_arrow;
            this.BtnBack.Location = new System.Drawing.Point(1230, 841);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(300, 50);
            this.BtnBack.TabIndex = 320;
            this.BtnBack.Text = "戻る";
            this.BtnBack.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnBack.UseVisualStyleBackColor = true;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // MaintenanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.PctLogo);
            this.Controls.Add(this.BtnApply);
            this.Controls.Add(this.TabControl1);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.LblTitle);
            this.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MaintenanceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.Load += new System.EventHandler(this.MaintenanceForm_Load);
            this.TabControl1.ResumeLayout(false);
            this.TabPage3.ResumeLayout(false);
            this.GroupBox25.ResumeLayout(false);
            this.GroupBox12.ResumeLayout(false);
            this.GroupBox12.PerformLayout();
            this.GroupBox7.ResumeLayout(false);
            this.GroupBox6.ResumeLayout(false);
            this.GroupBox6.PerformLayout();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.TabPage5.ResumeLayout(false);
            this.GroupBox9.ResumeLayout(false);
            this.GroupBox9.PerformLayout();
            this.GroupBox8.ResumeLayout(false);
            this.GroupBox8.PerformLayout();
            this.GroupBox11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PctLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label LblVersion;
        internal System.Windows.Forms.Label LblTitle;
        internal System.Windows.Forms.PictureBox PctLogo;
        internal System.Windows.Forms.Button BtnApply;
        internal System.Windows.Forms.TabControl TabControl1;
        internal System.Windows.Forms.TabPage TabPage3;
        internal System.Windows.Forms.GroupBox GroupBox25;
        internal System.Windows.Forms.CheckBox ChkIsDispLogo;
        internal System.Windows.Forms.GroupBox GroupBox12;
        internal System.Windows.Forms.TextBox TxtPassword;
        internal System.Windows.Forms.GroupBox GroupBox7;
        internal System.Windows.Forms.ComboBox CmbComStopBit;
        internal System.Windows.Forms.Label Label28;
        internal System.Windows.Forms.ComboBox CmbComParityVar;
        internal System.Windows.Forms.Label Label27;
        internal System.Windows.Forms.ComboBox CmbComIsParty;
        internal System.Windows.Forms.Label Label26;
        internal System.Windows.Forms.ComboBox CmbComDataLength;
        internal System.Windows.Forms.Label Label24;
        internal System.Windows.Forms.ComboBox CmbComSpeed;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.ComboBox CmbComPort;
        internal System.Windows.Forms.Label Label23;
        internal System.Windows.Forms.GroupBox GroupBox6;
        internal System.Windows.Forms.TextBox TxtHddSpace;
        internal System.Windows.Forms.Label Label29;
        internal System.Windows.Forms.GroupBox GroupBox5;
        internal System.Windows.Forms.TextBox TxtMachineName;
        internal System.Windows.Forms.Label Label32;
        internal System.Windows.Forms.TabPage TabPage5;
        internal System.Windows.Forms.GroupBox GroupBox9;
        internal System.Windows.Forms.TextBox TxtBackupFolder;
        internal System.Windows.Forms.Button BtnSelectBackupFolder;
        internal System.Windows.Forms.Label Label35;
        internal System.Windows.Forms.GroupBox GroupBox8;
        internal System.Windows.Forms.TextBox TxtLogFolder;
        internal System.Windows.Forms.Button BtnSelectLogFolder;
        internal System.Windows.Forms.Label Label33;
        internal System.Windows.Forms.Button BtnBack;
        internal System.Windows.Forms.GroupBox GroupBox11;
        internal System.Windows.Forms.ComboBox CmbSaveMonth;
        internal System.Windows.Forms.Button BtnDeleteLogData;
        internal System.Windows.Forms.Label Label36;
    }
}