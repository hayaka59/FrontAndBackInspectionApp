namespace FrontAndBackInspectionApp.表裏検査装置画面
{
    partial class MainMenuForm
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
            this.TimDateTime = new System.Windows.Forms.Timer(this.components);
            this.LblDateTime = new System.Windows.Forms.Label();
            this.LblVersion = new System.Windows.Forms.Label();
            this.LblTitle = new System.Windows.Forms.Label();
            this.BtnEntry = new System.Windows.Forms.Button();
            this.BtnInspect = new System.Windows.Forms.Button();
            this.BtnEnd = new System.Windows.Forms.Button();
            this.BtnLogManagement = new System.Windows.Forms.Button();
            this.BtnMaintenance = new System.Windows.Forms.Button();
            this.SuspendLayout();
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
            this.LblDateTime.Location = new System.Drawing.Point(1449, 6);
            this.LblDateTime.Name = "LblDateTime";
            this.LblDateTime.Size = new System.Drawing.Size(436, 46);
            this.LblDateTime.TabIndex = 319;
            this.LblDateTime.Text = "年月日時分秒";
            this.LblDateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblVersion
            // 
            this.LblVersion.Font = new System.Drawing.Font("メイリオ", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblVersion.ForeColor = System.Drawing.Color.Blue;
            this.LblVersion.Location = new System.Drawing.Point(1761, 1008);
            this.LblVersion.Name = "LblVersion";
            this.LblVersion.Size = new System.Drawing.Size(130, 25);
            this.LblVersion.TabIndex = 315;
            this.LblVersion.Text = "LblVersion";
            this.LblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitle
            // 
            this.LblTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.LblTitle.Font = new System.Drawing.Font("メイリオ", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(0, 2);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.Size = new System.Drawing.Size(1903, 50);
            this.LblTitle.TabIndex = 314;
            this.LblTitle.Text = "LblTitle";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnEntry
            // 
            this.BtnEntry.Font = new System.Drawing.Font("メイリオ", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnEntry.Image = global::FrontAndBackInspectionApp.Properties.Resources.entry_big;
            this.BtnEntry.Location = new System.Drawing.Point(301, 265);
            this.BtnEntry.Name = "BtnEntry";
            this.BtnEntry.Size = new System.Drawing.Size(1300, 180);
            this.BtnEntry.TabIndex = 2;
            this.BtnEntry.Text = "登　　録";
            this.BtnEntry.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEntry.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnEntry.UseVisualStyleBackColor = true;
            this.BtnEntry.Click += new System.EventHandler(this.BtnEntry_Click);
            // 
            // BtnInspect
            // 
            this.BtnInspect.Font = new System.Drawing.Font("メイリオ", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnInspect.Image = global::FrontAndBackInspectionApp.Properties.Resources.camera;
            this.BtnInspect.Location = new System.Drawing.Point(301, 80);
            this.BtnInspect.Name = "BtnInspect";
            this.BtnInspect.Size = new System.Drawing.Size(1300, 180);
            this.BtnInspect.TabIndex = 1;
            this.BtnInspect.Text = "検査処理";
            this.BtnInspect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnInspect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnInspect.UseVisualStyleBackColor = true;
            this.BtnInspect.Click += new System.EventHandler(this.BtnInspect_Click);
            // 
            // BtnEnd
            // 
            this.BtnEnd.Font = new System.Drawing.Font("メイリオ", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnEnd.Image = global::FrontAndBackInspectionApp.Properties.Resources.exit;
            this.BtnEnd.Location = new System.Drawing.Point(301, 824);
            this.BtnEnd.Name = "BtnEnd";
            this.BtnEnd.Size = new System.Drawing.Size(1300, 180);
            this.BtnEnd.TabIndex = 322;
            this.BtnEnd.Text = "終　　了";
            this.BtnEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEnd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnEnd.UseVisualStyleBackColor = true;
            this.BtnEnd.Click += new System.EventHandler(this.BtnEnd_Click);
            // 
            // BtnLogManagement
            // 
            this.BtnLogManagement.Font = new System.Drawing.Font("メイリオ", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnLogManagement.Image = global::FrontAndBackInspectionApp.Properties.Resources.download;
            this.BtnLogManagement.Location = new System.Drawing.Point(301, 450);
            this.BtnLogManagement.Name = "BtnLogManagement";
            this.BtnLogManagement.Size = new System.Drawing.Size(1300, 180);
            this.BtnLogManagement.TabIndex = 3;
            this.BtnLogManagement.Text = "ログ管理";
            this.BtnLogManagement.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnLogManagement.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnLogManagement.UseVisualStyleBackColor = true;
            // 
            // BtnMaintenance
            // 
            this.BtnMaintenance.Font = new System.Drawing.Font("メイリオ", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.BtnMaintenance.Image = global::FrontAndBackInspectionApp.Properties.Resources.maintenance_icon;
            this.BtnMaintenance.Location = new System.Drawing.Point(301, 637);
            this.BtnMaintenance.Name = "BtnMaintenance";
            this.BtnMaintenance.Size = new System.Drawing.Size(1300, 180);
            this.BtnMaintenance.TabIndex = 4;
            this.BtnMaintenance.Text = "保　　守";
            this.BtnMaintenance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnMaintenance.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnMaintenance.UseVisualStyleBackColor = true;
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.BtnEntry);
            this.Controls.Add(this.BtnInspect);
            this.Controls.Add(this.BtnEnd);
            this.Controls.Add(this.BtnLogManagement);
            this.Controls.Add(this.BtnMaintenance);
            this.Controls.Add(this.LblDateTime);
            this.Controls.Add(this.LblVersion);
            this.Controls.Add(this.LblTitle);
            this.Font = new System.Drawing.Font("メイリオ", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "表裏検査画面";
            this.Load += new System.EventHandler(this.MainMenuForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FunctionKey_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.Timer TimDateTime;
        internal System.Windows.Forms.Label LblDateTime;
        internal System.Windows.Forms.Label LblVersion;
        internal System.Windows.Forms.Label LblTitle;
        private System.Windows.Forms.Button BtnEnd;
        private System.Windows.Forms.Button BtnLogManagement;
        private System.Windows.Forms.Button BtnMaintenance;
        private System.Windows.Forms.Button BtnInspect;
        private System.Windows.Forms.Button BtnEntry;
    }
}