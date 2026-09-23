using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using TX_Text_Control_Words.Properties;
using TXTextControl;

namespace TX_Text_Control_Words
{
	internal class AboutBox : Form
	{
		private IContainer components;

		private Label _lblProductName;

		private Label _lblVersion;

		private Label _lblCopyright;

		private Label _lblSubTitle;

		private System.Windows.Forms.Button _btnClose;

		private LinkLabel _linkLabel;

		private Label _lblApplicationType;

		private AboutBox(VersionInfo versionInfo)
		{
			this.InitializeComponent();
			this.Text = string.Format(Resources.ABOUTBOX_FORMAT_TITLE, AssemblyAttributes.AssemblyProduct);
			this._lblSubTitle.Text = (AssemblyAttributes.Is64BitAssembly ? "64-bit" : "32-bit") + " Windows Forms Edition";
			this._lblProductName.Text = base.ProductName;
			this._lblVersion.Text = $"Version {AssemblyAttributes.AssemblyVersion.Major.ToString()}.{AssemblyAttributes.AssemblyVersion.Minor.ToString()}";
			if (versionInfo.ServicePack > 0)
			{
				Label lblVersion = this._lblVersion;
				lblVersion.Text = lblVersion.Text + " Service Pack " + versionInfo.ServicePack;
			}
			this._lblCopyright.Text = AssemblyAttributes.AssemblyCopyright;
			this.BackgroundImage = new Bitmap(typeof(MainWindow), "Images.txwords_info.png");
			string text = AssemblyAttributes.AssemblyTitle.ToLower();
			this._lblApplicationType.Text = (text.Contains("ribbon") ? "" : Resources.ABOUTBOX_LBL_APPLICATIONTYPE);
			this._linkLabel.Text = Resources.ABOUTBOX_LINKLABEL_TEXT;
			this._btnClose.Text = Resources.ABOUTBOX_CLOSE_TEXT;
		}

		public static DialogResult Show(IWin32Window owner, VersionInfo versionInfo)
		{
			return new AboutBox(versionInfo).ShowDialog(owner);
		}

		private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("http://www.textcontrol.com/txtextcontrolwords/");
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
			this._lblProductName = new System.Windows.Forms.Label();
			this._lblVersion = new System.Windows.Forms.Label();
			this._lblCopyright = new System.Windows.Forms.Label();
			this._lblSubTitle = new System.Windows.Forms.Label();
			this._btnClose = new System.Windows.Forms.Button();
			this._linkLabel = new System.Windows.Forms.LinkLabel();
			this._lblApplicationType = new System.Windows.Forms.Label();
			base.SuspendLayout();
			this._lblProductName.BackColor = System.Drawing.Color.Transparent;
			this._lblProductName.Font = new System.Drawing.Font("Segoe UI", 16f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this._lblProductName.Location = new System.Drawing.Point(237, 8);
			this._lblProductName.Name = "_lblProductName";
			this._lblProductName.Size = new System.Drawing.Size(422, 35);
			this._lblProductName.TabIndex = 0;
			this._lblProductName.Text = base.ProductName;
			this._lblVersion.AutoSize = true;
			this._lblVersion.BackColor = System.Drawing.Color.Transparent;
			this._lblVersion.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this._lblVersion.ForeColor = System.Drawing.Color.White;
			this._lblVersion.Location = new System.Drawing.Point(239, 88);
			this._lblVersion.Name = "_lblVersion";
			this._lblVersion.Size = new System.Drawing.Size(58, 13);
			this._lblVersion.TabIndex = 2;
			this._lblVersion.Text = base.ProductVersion;
			this._lblCopyright.AutoSize = true;
			this._lblCopyright.BackColor = System.Drawing.Color.Transparent;
			this._lblCopyright.Font = new System.Drawing.Font("Segoe UI", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this._lblCopyright.ForeColor = System.Drawing.Color.White;
			this._lblCopyright.Location = new System.Drawing.Point(239, 217);
			this._lblCopyright.Name = "_lblCopyright";
			this._lblCopyright.Size = new System.Drawing.Size(16, 13);
			this._lblCopyright.TabIndex = 3;
			this._lblCopyright.Text = "…";
			this._lblSubTitle.BackColor = System.Drawing.Color.Transparent;
			this._lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this._lblSubTitle.Location = new System.Drawing.Point(238, 35);
			this._lblSubTitle.Name = "_lblSubTitle";
			this._lblSubTitle.Size = new System.Drawing.Size(340, 26);
			this._lblSubTitle.TabIndex = 5;
			this._lblSubTitle.Text = "…";
			this._btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this._btnClose.Location = new System.Drawing.Point(602, 212);
			this._btnClose.Name = "_btnClose";
			this._btnClose.Size = new System.Drawing.Size(75, 23);
			this._btnClose.TabIndex = 9;
			this._btnClose.Text = "Close";
			this._btnClose.UseVisualStyleBackColor = true;
			this._linkLabel.AutoSize = true;
			this._linkLabel.BackColor = System.Drawing.Color.Transparent;
			this._linkLabel.Font = new System.Drawing.Font("Segoe UI", 14.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
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
			this._linkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(LinkLabel_LinkClicked);
			this._lblApplicationType.BackColor = System.Drawing.Color.Transparent;
			this._lblApplicationType.Font = new System.Drawing.Font("Segoe UI", 10f);
			this._lblApplicationType.Location = new System.Drawing.Point(238, 61);
			this._lblApplicationType.Name = "_lblApplicationType";
			this._lblApplicationType.Size = new System.Drawing.Size(340, 18);
			this._lblApplicationType.TabIndex = 12;
			this._lblApplicationType.Text = "Windows Forms";
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			base.CancelButton = this._btnClose;
			base.ClientSize = new System.Drawing.Size(689, 241);
			base.Controls.Add(this._lblApplicationType);
			base.Controls.Add(this._linkLabel);
			base.Controls.Add(this._btnClose);
			base.Controls.Add(this._lblSubTitle);
			base.Controls.Add(this._lblCopyright);
			base.Controls.Add(this._lblVersion);
			base.Controls.Add(this._lblProductName);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "AboutBox";
			base.Padding = new System.Windows.Forms.Padding(9, 9, 9, 9);
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = base.ProductName;
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
