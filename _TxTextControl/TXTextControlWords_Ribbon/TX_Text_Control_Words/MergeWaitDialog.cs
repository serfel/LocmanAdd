using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TX_Text_Control_Words.Properties;

namespace TX_Text_Control_Words
{
	internal class MergeWaitDialog : Form
	{
		private bool m_bMayClose;

		private IContainer components;

		private ProgressBar _progBar;

		private Label m_lblMerging;

		public MergeWaitDialog()
		{
			this.InitializeComponent();
			this.LocalizeDialog();
		}

		private void LocalizeDialog()
		{
			this.Text = Resources.MERGE_WAIT_DLG_TITLE;
			this.m_lblMerging.Text = Resources.MERGE_WAIT_DLG_LBL_MERGING;
		}

		public void CloseDialog()
		{
			this.m_bMayClose = true;
			base.Close();
		}

		private void MergeWaitDialog_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing && !this.m_bMayClose)
			{
				e.Cancel = true;
			}
			else
			{
				this.m_bMayClose = false;
			}
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
			this._progBar = new System.Windows.Forms.ProgressBar();
			this.m_lblMerging = new System.Windows.Forms.Label();
			base.SuspendLayout();
			this._progBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this._progBar.Location = new System.Drawing.Point(12, 34);
			this._progBar.MarqueeAnimationSpeed = 50;
			this._progBar.Name = "_progBar";
			this._progBar.Size = new System.Drawing.Size(226, 23);
			this._progBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this._progBar.TabIndex = 0;
			this._progBar.Value = 100;
			this.m_lblMerging.AutoSize = true;
			this.m_lblMerging.Location = new System.Drawing.Point(12, 9);
			this.m_lblMerging.Name = "m_lblMerging";
			this.m_lblMerging.Size = new System.Drawing.Size(51, 13);
			this.m_lblMerging.TabIndex = 1;
			this.m_lblMerging.Text = "Merging…";
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			base.ClientSize = new System.Drawing.Size(250, 82);
			base.Controls.Add(this.m_lblMerging);
			base.Controls.Add(this._progBar);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "MergeWaitDialog";
			this.RightToLeftLayout = true;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Please wait";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(MergeWaitDialog_FormClosing);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
