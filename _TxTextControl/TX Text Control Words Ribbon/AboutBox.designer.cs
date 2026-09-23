namespace TX_Text_Control_Words
{
    partial class AboutBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }



        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this._lblProductName = new System.Windows.Forms.Label();
			this._lblVersion = new System.Windows.Forms.Label();
			this._lblCopyright = new System.Windows.Forms.Label();
			this._lblSubTitle = new System.Windows.Forms.Label();
			this._btnClose = new System.Windows.Forms.Button();
			this._linkLabel = new System.Windows.Forms.LinkLabel();
			this._lblApplicationType = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// _lblProductName
			// 
			this._lblProductName.BackColor = System.Drawing.Color.Transparent;
			this._lblProductName.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._lblProductName.Location = new System.Drawing.Point(237, 8);
			this._lblProductName.Name = "_lblProductName";
			this._lblProductName.Size = new System.Drawing.Size(422, 35);
			this._lblProductName.TabIndex = 0;
			this._lblProductName.Text = this.ProductName;
			// 
			// _lblVersion
			// 
			this._lblVersion.AutoSize = true;
			this._lblVersion.BackColor = System.Drawing.Color.Transparent;
			this._lblVersion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._lblVersion.ForeColor = System.Drawing.Color.White;
			this._lblVersion.Location = new System.Drawing.Point(239, 88);
			this._lblVersion.Name = "_lblVersion";
			this._lblVersion.Size = new System.Drawing.Size(58, 13);
			this._lblVersion.TabIndex = 2;
			this._lblVersion.Text = this.ProductVersion;
			// 
			// _lblCopyright
			// 
			this._lblCopyright.AutoSize = true;
			this._lblCopyright.BackColor = System.Drawing.Color.Transparent;
			this._lblCopyright.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._lblCopyright.ForeColor = System.Drawing.Color.White;
			this._lblCopyright.Location = new System.Drawing.Point(239, 217);
			this._lblCopyright.Name = "_lblCopyright";
			this._lblCopyright.Size = new System.Drawing.Size(16, 13);
			this._lblCopyright.TabIndex = 3;
			this._lblCopyright.Text = "…";
			// 
			// _lblSubTitle
			// 
			this._lblSubTitle.BackColor = System.Drawing.Color.Transparent;
			this._lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._lblSubTitle.Location = new System.Drawing.Point(238, 35);
			this._lblSubTitle.Name = "_lblSubTitle";
			this._lblSubTitle.Size = new System.Drawing.Size(340, 26);
			this._lblSubTitle.TabIndex = 5;
			this._lblSubTitle.Text = "…";
			// 
			// _btnClose
			// 
			this._btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._btnClose.Location = new System.Drawing.Point(602, 212);
			this._btnClose.Name = "_btnClose";
			this._btnClose.Size = new System.Drawing.Size(75, 23);
			this._btnClose.TabIndex = 9;
			this._btnClose.Text = "Close";
			this._btnClose.UseVisualStyleBackColor = true;
			// 
			// _linkLabel
			// 
			this._linkLabel.AutoSize = true;
			this._linkLabel.BackColor = System.Drawing.Color.Transparent;
			this._linkLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this._linkLabel.ForeColor = System.Drawing.Color.White;
			this._linkLabel.LinkArea = new System.Windows.Forms.LinkArea(27, 19);
			this._linkLabel.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
			this._linkLabel.LinkColor = System.Drawing.Color.White;
			this._linkLabel.Location = new System.Drawing.Point(237, 166);
			this._linkLabel.Name = "_linkLabel";
			this._linkLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._linkLabel.Size = new System.Drawing.Size(422, 31);
			this._linkLabel.TabIndex = 11;
			this._linkLabel.TabStop = true;
			this._linkLabel.Text = "For more information visit www.textcontrol.com.";
			this._linkLabel.UseCompatibleTextRendering = true;
			this._linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabel_LinkClicked);
			// 
			// _lblApplicationType
			// 
			this._lblApplicationType.BackColor = System.Drawing.Color.Transparent;
			this._lblApplicationType.Font = new System.Drawing.Font("Segoe UI", 10F);
			this._lblApplicationType.Location = new System.Drawing.Point(238, 61);
			this._lblApplicationType.Name = "_lblApplicationType";
			this._lblApplicationType.Size = new System.Drawing.Size(340, 18);
			this._lblApplicationType.TabIndex = 12;
			this._lblApplicationType.Text = "Windows Forms";
			// 
			// AboutBox
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.CancelButton = this._btnClose;
			this.ClientSize = new System.Drawing.Size(689, 241);
			this.Controls.Add(this._lblApplicationType);
			this.Controls.Add(this._linkLabel);
			this.Controls.Add(this._btnClose);
			this.Controls.Add(this._lblSubTitle);
			this.Controls.Add(this._lblCopyright);
			this.Controls.Add(this._lblVersion);
			this.Controls.Add(this._lblProductName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "AboutBox";
			this.Padding = new System.Windows.Forms.Padding(9, 9, 9, 9);
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = this.ProductName;
			this.ResumeLayout(false);
			this.PerformLayout();

        }



        private System.Windows.Forms.Label _lblProductName;
        private System.Windows.Forms.Label _lblVersion;
        private System.Windows.Forms.Label _lblCopyright;
        private System.Windows.Forms.Label _lblSubTitle;
        private System.Windows.Forms.Button _btnClose;
        private System.Windows.Forms.LinkLabel _linkLabel;
		  private System.Windows.Forms.Label _lblApplicationType;

    }
}
