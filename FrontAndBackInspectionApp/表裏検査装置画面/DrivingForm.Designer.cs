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
            this.LblTitle = new System.Windows.Forms.Label();
            this.LblVersion = new System.Windows.Forms.Label();
            this.LsbJobInfo = new System.Windows.Forms.ListBox();
            this.lblTranGSNGCount = new System.Windows.Forms.Label();
            this.lblTranOSNGCount = new System.Windows.Forms.Label();
            this.lblTranGSCount = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.LblError7 = new System.Windows.Forms.Label();
            this.LblError8 = new System.Windows.Forms.Label();
            this.LblError6 = new System.Windows.Forms.Label();
            this.LblError5 = new System.Windows.Forms.Label();
            this.LblError3 = new System.Windows.Forms.Label();
            this.LblError4 = new System.Windows.Forms.Label();
            this.LblError2 = new System.Windows.Forms.Label();
            this.LblError1 = new System.Windows.Forms.Label();
            this.LstErrorGS = new System.Windows.Forms.ListView();
            this.LstErrorOS = new System.Windows.Forms.ListView();
            this.BtnErrorReset = new System.Windows.Forms.Button();
            this.BtnMarkReadStart = new System.Windows.Forms.Button();
            this.BtnStop = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.BtnRun = new System.Windows.Forms.Button();
            this.LstReadDataGS = new System.Windows.Forms.ListView();
            this.lblTranOSCount = new System.Windows.Forms.Label();
            this.BtnBack = new System.Windows.Forms.Button();
            this.LblDateTime = new System.Windows.Forms.Label();
            this.Label22 = new System.Windows.Forms.Label();
            this.LstReadDataOS = new System.Windows.Forms.ListView();
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
            this.LblVersion.Location = new System.Drawing.Point(1761, 1008);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(129, 27);
            this.LblVersion.TabIndex = 317;
            this.LblVersion.Text = "LblVersion";
            this.LblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LsbJobInfo
            // 
            this.LsbJobInfo.BackColor = System.Drawing.SystemColors.Control;
            this.LsbJobInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LsbJobInfo.Enabled = false;
            this.LsbJobInfo.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LsbJobInfo.FormattingEnabled = true;
            this.LsbJobInfo.ItemHeight = 20;
            this.LsbJobInfo.Location = new System.Drawing.Point(1358, 149);
            this.LsbJobInfo.Name = "LsbJobInfo";
            this.LsbJobInfo.Size = new System.Drawing.Size(213, 540);
            this.LsbJobInfo.TabIndex = 344;
            // 
            // lblTranGSNGCount
            // 
            this.lblTranGSNGCount.BackColor = System.Drawing.Color.Silver;
            this.lblTranGSNGCount.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTranGSNGCount.Location = new System.Drawing.Point(1198, 860);
            this.lblTranGSNGCount.Name = "lblTranGSNGCount";
            this.lblTranGSNGCount.Size = new System.Drawing.Size(147, 20);
            this.lblTranGSNGCount.TabIndex = 343;
            this.lblTranGSNGCount.Text = "lblTranOSNGCount";
            this.lblTranGSNGCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTranOSNGCount
            // 
            this.lblTranOSNGCount.BackColor = System.Drawing.Color.Silver;
            this.lblTranOSNGCount.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTranOSNGCount.Location = new System.Drawing.Point(1198, 452);
            this.lblTranOSNGCount.Name = "lblTranOSNGCount";
            this.lblTranOSNGCount.Size = new System.Drawing.Size(147, 20);
            this.lblTranOSNGCount.TabIndex = 342;
            this.lblTranOSNGCount.Text = "lblTranOSNGCount";
            this.lblTranOSNGCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTranGSCount
            // 
            this.lblTranGSCount.BackColor = System.Drawing.Color.Silver;
            this.lblTranGSCount.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTranGSCount.Location = new System.Drawing.Point(686, 860);
            this.lblTranGSCount.Name = "lblTranGSCount";
            this.lblTranGSCount.Size = new System.Drawing.Size(147, 20);
            this.lblTranGSCount.TabIndex = 341;
            this.lblTranGSCount.Text = "lblTranGSCount";
            this.lblTranGSCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Label3.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label3.ForeColor = System.Drawing.Color.White;
            this.Label3.Location = new System.Drawing.Point(845, 483);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(500, 27);
            this.Label3.TabIndex = 340;
            this.Label3.Text = "　■　エラー履歴（G／S）　■";
            this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.Label2.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label2.ForeColor = System.Drawing.Color.White;
            this.Label2.Location = new System.Drawing.Point(845, 75);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(500, 27);
            this.Label2.TabIndex = 339;
            this.Label2.Text = "　■　エラー履歴（O／S）　■";
            this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblError7
            // 
            this.LblError7.BackColor = System.Drawing.Color.LightSalmon;
            this.LblError7.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblError7.Location = new System.Drawing.Point(1358, 692);
            this.LblError7.Name = "LblError7";
            this.LblError7.Size = new System.Drawing.Size(213, 80);
            this.LblError7.TabIndex = 338;
            this.LblError7.Text = "LblError7";
            this.LblError7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblError8
            // 
            this.LblError8.BackColor = System.Drawing.Color.LightSalmon;
            this.LblError8.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblError8.Location = new System.Drawing.Point(1358, 787);
            this.LblError8.Name = "LblError8";
            this.LblError8.Size = new System.Drawing.Size(213, 80);
            this.LblError8.TabIndex = 337;
            this.LblError8.Text = "LblError8";
            this.LblError8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblError6
            // 
            this.LblError6.BackColor = System.Drawing.Color.LightSalmon;
            this.LblError6.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblError6.Location = new System.Drawing.Point(1358, 594);
            this.LblError6.Name = "LblError6";
            this.LblError6.Size = new System.Drawing.Size(213, 80);
            this.LblError6.TabIndex = 336;
            this.LblError6.Text = "LblError6";
            this.LblError6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblError5
            // 
            this.LblError5.BackColor = System.Drawing.Color.LightSalmon;
            this.LblError5.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblError5.Location = new System.Drawing.Point(1358, 498);
            this.LblError5.Name = "LblError5";
            this.LblError5.Size = new System.Drawing.Size(213, 80);
            this.LblError5.TabIndex = 335;
            this.LblError5.Text = "LblError5";
            this.LblError5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblError3
            // 
            this.LblError3.BackColor = System.Drawing.Color.LightSalmon;
            this.LblError3.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblError3.Location = new System.Drawing.Point(1358, 307);
            this.LblError3.Name = "LblError3";
            this.LblError3.Size = new System.Drawing.Size(213, 80);
            this.LblError3.TabIndex = 334;
            this.LblError3.Text = "LblError3";
            this.LblError3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblError4
            // 
            this.LblError4.BackColor = System.Drawing.Color.LightSalmon;
            this.LblError4.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblError4.Location = new System.Drawing.Point(1358, 402);
            this.LblError4.Name = "LblError4";
            this.LblError4.Size = new System.Drawing.Size(213, 80);
            this.LblError4.TabIndex = 333;
            this.LblError4.Text = "LblError4";
            this.LblError4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblError2
            // 
            this.LblError2.BackColor = System.Drawing.Color.LightSalmon;
            this.LblError2.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblError2.Location = new System.Drawing.Point(1358, 212);
            this.LblError2.Name = "LblError2";
            this.LblError2.Size = new System.Drawing.Size(213, 80);
            this.LblError2.TabIndex = 332;
            this.LblError2.Text = "LblError2";
            this.LblError2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblError1
            // 
            this.LblError1.BackColor = System.Drawing.Color.LightSalmon;
            this.LblError1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblError1.Location = new System.Drawing.Point(1358, 118);
            this.LblError1.Name = "LblError1";
            this.LblError1.Size = new System.Drawing.Size(213, 80);
            this.LblError1.TabIndex = 331;
            this.LblError1.Text = "LblError1";
            this.LblError1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LstErrorGS
            // 
            this.LstErrorGS.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LstErrorGS.FullRowSelect = true;
            this.LstErrorGS.GridLines = true;
            this.LstErrorGS.HideSelection = false;
            this.LstErrorGS.Location = new System.Drawing.Point(845, 510);
            this.LstErrorGS.MultiSelect = false;
            this.LstErrorGS.Name = "LstErrorGS";
            this.LstErrorGS.Size = new System.Drawing.Size(500, 350);
            this.LstErrorGS.TabIndex = 330;
            this.LstErrorGS.UseCompatibleStateImageBehavior = false;
            // 
            // LstErrorOS
            // 
            this.LstErrorOS.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LstErrorOS.FullRowSelect = true;
            this.LstErrorOS.GridLines = true;
            this.LstErrorOS.HideSelection = false;
            this.LstErrorOS.Location = new System.Drawing.Point(845, 102);
            this.LstErrorOS.MultiSelect = false;
            this.LstErrorOS.Name = "LstErrorOS";
            this.LstErrorOS.Size = new System.Drawing.Size(500, 350);
            this.LstErrorOS.TabIndex = 329;
            this.LstErrorOS.UseCompatibleStateImageBehavior = false;
            // 
            // BtnErrorReset
            // 
            this.BtnErrorReset.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnErrorReset.Location = new System.Drawing.Point(1308, 896);
            this.BtnErrorReset.Name = "BtnErrorReset";
            this.BtnErrorReset.Size = new System.Drawing.Size(220, 70);
            this.BtnErrorReset.TabIndex = 328;
            this.BtnErrorReset.Text = "エラー解除";
            this.BtnErrorReset.UseVisualStyleBackColor = true;
            // 
            // BtnMarkReadStart
            // 
            this.BtnMarkReadStart.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnMarkReadStart.Location = new System.Drawing.Point(1069, 896);
            this.BtnMarkReadStart.Name = "BtnMarkReadStart";
            this.BtnMarkReadStart.Size = new System.Drawing.Size(220, 70);
            this.BtnMarkReadStart.TabIndex = 327;
            this.BtnMarkReadStart.Text = "読取テスト";
            this.BtnMarkReadStart.UseVisualStyleBackColor = true;
            // 
            // BtnStop
            // 
            this.BtnStop.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnStop.Location = new System.Drawing.Point(595, 896);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(220, 70);
            this.BtnStop.TabIndex = 321;
            this.BtnStop.Text = "停止";
            this.BtnStop.UseVisualStyleBackColor = true;
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Blue;
            this.Label1.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label1.ForeColor = System.Drawing.Color.White;
            this.Label1.Location = new System.Drawing.Point(333, 483);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(500, 27);
            this.Label1.TabIndex = 326;
            this.Label1.Text = "　■　検査履歴（G／S）　■";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnRun
            // 
            this.BtnRun.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnRun.Location = new System.Drawing.Point(355, 896);
            this.BtnRun.Name = "BtnRun";
            this.BtnRun.Size = new System.Drawing.Size(220, 70);
            this.BtnRun.TabIndex = 320;
            this.BtnRun.Text = "検査開始";
            this.BtnRun.UseVisualStyleBackColor = true;
            // 
            // LstReadDataGS
            // 
            this.LstReadDataGS.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LstReadDataGS.FullRowSelect = true;
            this.LstReadDataGS.GridLines = true;
            this.LstReadDataGS.HideSelection = false;
            this.LstReadDataGS.Location = new System.Drawing.Point(333, 510);
            this.LstReadDataGS.MultiSelect = false;
            this.LstReadDataGS.Name = "LstReadDataGS";
            this.LstReadDataGS.Size = new System.Drawing.Size(500, 350);
            this.LstReadDataGS.TabIndex = 325;
            this.LstReadDataGS.UseCompatibleStateImageBehavior = false;
            // 
            // lblTranOSCount
            // 
            this.lblTranOSCount.BackColor = System.Drawing.Color.Silver;
            this.lblTranOSCount.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTranOSCount.Location = new System.Drawing.Point(687, 452);
            this.lblTranOSCount.Name = "lblTranOSCount";
            this.lblTranOSCount.Size = new System.Drawing.Size(147, 20);
            this.lblTranOSCount.TabIndex = 324;
            this.lblTranOSCount.Text = "lblTranOSCount";
            this.lblTranOSCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnBack
            // 
            this.BtnBack.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnBack.Location = new System.Drawing.Point(829, 896);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(220, 70);
            this.BtnBack.TabIndex = 319;
            this.BtnBack.Text = "戻る";
            this.BtnBack.UseVisualStyleBackColor = true;
            // 
            // LblDateTime
            // 
            this.LblDateTime.BackColor = System.Drawing.Color.LemonChiffon;
            this.LblDateTime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.LblDateTime.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblDateTime.Location = new System.Drawing.Point(1358, 75);
            this.LblDateTime.Name = "LblDateTime";
            this.LblDateTime.Size = new System.Drawing.Size(213, 30);
            this.LblDateTime.TabIndex = 323;
            this.LblDateTime.Text = "LblDateTime";
            this.LblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label22
            // 
            this.Label22.BackColor = System.Drawing.Color.Blue;
            this.Label22.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Label22.ForeColor = System.Drawing.Color.White;
            this.Label22.Location = new System.Drawing.Point(334, 75);
            this.Label22.Name = "Label22";
            this.Label22.Size = new System.Drawing.Size(500, 27);
            this.Label22.TabIndex = 322;
            this.Label22.Text = "　■　検査履歴（O／S）　■";
            this.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LstReadDataOS
            // 
            this.LstReadDataOS.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LstReadDataOS.FullRowSelect = true;
            this.LstReadDataOS.GridLines = true;
            this.LstReadDataOS.HideSelection = false;
            this.LstReadDataOS.Location = new System.Drawing.Point(334, 102);
            this.LstReadDataOS.MultiSelect = false;
            this.LstReadDataOS.Name = "LstReadDataOS";
            this.LstReadDataOS.Size = new System.Drawing.Size(500, 350);
            this.LstReadDataOS.TabIndex = 318;
            this.LstReadDataOS.UseCompatibleStateImageBehavior = false;
            // 
            // DrivingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.LsbJobInfo);
            this.Controls.Add(this.lblTranGSNGCount);
            this.Controls.Add(this.lblTranOSNGCount);
            this.Controls.Add(this.lblTranGSCount);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.LblError7);
            this.Controls.Add(this.LblError8);
            this.Controls.Add(this.LblError6);
            this.Controls.Add(this.LblError5);
            this.Controls.Add(this.LblError3);
            this.Controls.Add(this.LblError4);
            this.Controls.Add(this.LblError2);
            this.Controls.Add(this.LblError1);
            this.Controls.Add(this.LstErrorGS);
            this.Controls.Add(this.LstErrorOS);
            this.Controls.Add(this.BtnErrorReset);
            this.Controls.Add(this.BtnMarkReadStart);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.BtnRun);
            this.Controls.Add(this.LstReadDataGS);
            this.Controls.Add(this.lblTranOSCount);
            this.Controls.Add(this.BtnBack);
            this.Controls.Add(this.LblDateTime);
            this.Controls.Add(this.Label22);
            this.Controls.Add(this.LstReadDataOS);
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

        }

        #endregion

        internal System.Windows.Forms.Label LblTitle;
        internal System.Windows.Forms.Label LblVersion;
        internal System.Windows.Forms.ListBox LsbJobInfo;
        internal System.Windows.Forms.Label lblTranGSNGCount;
        internal System.Windows.Forms.Label lblTranOSNGCount;
        internal System.Windows.Forms.Label lblTranGSCount;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label LblError7;
        internal System.Windows.Forms.Label LblError8;
        internal System.Windows.Forms.Label LblError6;
        internal System.Windows.Forms.Label LblError5;
        internal System.Windows.Forms.Label LblError3;
        internal System.Windows.Forms.Label LblError4;
        internal System.Windows.Forms.Label LblError2;
        internal System.Windows.Forms.Label LblError1;
        internal System.Windows.Forms.ListView LstErrorGS;
        internal System.Windows.Forms.ListView LstErrorOS;
        internal System.Windows.Forms.Button BtnErrorReset;
        internal System.Windows.Forms.Button BtnMarkReadStart;
        internal System.Windows.Forms.Button BtnStop;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button BtnRun;
        internal System.Windows.Forms.ListView LstReadDataGS;
        internal System.Windows.Forms.Label lblTranOSCount;
        internal System.Windows.Forms.Button BtnBack;
        internal System.Windows.Forms.Label LblDateTime;
        internal System.Windows.Forms.Label Label22;
        internal System.Windows.Forms.ListView LstReadDataOS;
    }
}