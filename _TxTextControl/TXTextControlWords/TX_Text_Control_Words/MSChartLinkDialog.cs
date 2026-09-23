using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace TX_Text_Control_Words
{
	public class MSChartLinkDialog : Form
	{
		private IContainer components;

		private Button btnOK;

		private LinkLabel linkLabel1;

		public static DialogResult Show(Form owner)
		{
			MSChartLinkDialog mSChartLinkDialog = new MSChartLinkDialog();
			mSChartLinkDialog.RightToLeft = owner.RightToLeft;
			return mSChartLinkDialog.ShowDialog(owner);
		}

		private MSChartLinkDialog()
		{
			this.InitializeComponent();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://www.microsoft.com/download/en/details.aspx?id=14422");
		}

		private void frmMSChartLink_Load(object sender, EventArgs e)
		{
			this.Text = base.ProductName;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.btnOK = new System.Windows.Forms.Button();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			base.SuspendLayout();
			this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.btnOK.Location = new System.Drawing.Point(172, 61);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "&OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(btnOK_Click);
			this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(80, 17);
			this.linkLabel1.Location = new System.Drawing.Point(12, 9);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(235, 47);
			this.linkLabel1.TabIndex = 2;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Microsoft Chart Controls for .NET are not installed. You can download them from www.microsoft.com.";
			this.linkLabel1.UseCompatibleTextRendering = true;
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			base.ClientSize = new System.Drawing.Size(259, 96);
			base.Controls.Add(this.linkLabel1);
			base.Controls.Add(this.btnOK);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "MSChartLinkDialog";
			this.RightToLeftLayout = true;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Microsoft Chart Controls";
			base.Load += new System.EventHandler(frmMSChartLink_Load);
			base.ResumeLayout(false);
		}
	}
}
