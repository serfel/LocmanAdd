using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using TX_Text_Control_Words.Properties;
using TXTextControl;

namespace TX_Text_Control_Words
{
	public class TrackedChangesDialog : Form
	{
		private TrackedChangeCollection m_tcc;

		private IContainer components;

		private Label labelReviewerAction;

		private System.Windows.Forms.Button btnNext;

		private System.Windows.Forms.Button btnAccept;

		private System.Windows.Forms.Button btnReject;

		private System.Windows.Forms.Button btnRejectAll;

		private System.Windows.Forms.Button btnAcceptAll;

		private Label labelChangeTime;

		private System.Windows.Forms.Button btnClose;

		private TextControl m_textControl;

		private TableLayoutPanel tableLayoutPanel1;

		private TableLayoutPanel tableLayoutPanel2;

		public TrackedChangesDialog()
		{
			this.InitializeComponent();
			this.LocalizeDialog();
		}

		public TrackedChangesDialog(TrackedChangeCollection trackedChanges)
			: this()
		{
			this.m_tcc = trackedChanges;
		}

		public TrackedChangesDialog(TrackedChangeCollection trackedChanges, string[] usernames)
			: this(trackedChanges)
		{
			this.m_textControl.UserNames = usernames;
		}

		private void btnNext_Click(object sender, EventArgs e)
		{
			this.Next();
		}

		private new void Refresh()
		{
			this.UpdateTrackedChangeInfo();
			this.UpdateEnableStates();
		}

		private void btnReject_Click(object sender, EventArgs e)
		{
			TrackedChange item = this.m_tcc.GetItem();
			if (item != null)
			{
				this.m_tcc.Remove(item, accept: false);
			}
			this.Next();
		}

		private void btnAcceptAll_Click(object sender, EventArgs e)
		{
			TrackedChangeCollection.TrackedChangeEnumerator enumerator = this.m_tcc.GetEnumerator();
			while (enumerator.MoveNext())
			{
				this.m_tcc.Remove(enumerator.Current as TrackedChange, accept: true);
				enumerator.Reset();
			}
			this.Next();
		}

		private void btnRejectAll_Click(object sender, EventArgs e)
		{
			TrackedChangeCollection.TrackedChangeEnumerator enumerator = this.m_tcc.GetEnumerator();
			while (enumerator.MoveNext())
			{
				this.m_tcc.Remove(enumerator.Current as TrackedChange, accept: false);
				enumerator.Reset();
			}
			this.Next();
		}

		private void btnAccept_Click(object sender, EventArgs e)
		{
			TrackedChange item = this.m_tcc.GetItem();
			if (item != null)
			{
				this.m_tcc.Remove(item, accept: true);
			}
			this.Next();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void TrackedChangesDialog_Shown(object sender, EventArgs e)
		{
			if (this.m_tcc != null && this.m_tcc.Count > 0)
			{
				this.m_tcc[1].Select();
				this.Refresh();
			}
		}

		private void LocalizeDialog()
		{
			this.Text = Resources.TRACKED_CHANGES_DLG_TITLE;
			this.btnAccept.Text = Resources.TRACKED_CHANGES_DLG_BTN_ACCEPT;
			this.btnAcceptAll.Text = Resources.TRACKED_CHANGES_DLG_BTN_ACCEPTALL;
			this.btnReject.Text = Resources.TRACKED_CHANGES_DLG_BTN_REJECT;
			this.btnRejectAll.Text = Resources.TRACKED_CHANGES_DLG_BTN_REJECTALL;
			this.btnNext.Text = Resources.TRACKED_CHANGES_DLG_BTN_NEXT;
			this.btnClose.Text = Resources.TRACKED_CHANGES_DLG_BTN_CLOSE;
		}

		private void UpdateEnableStates()
		{
			bool flag = this.m_tcc.Count > 0;
			bool flag2 = this.m_tcc.GetItem(next: true) != null;
			bool flag3 = this.m_tcc.GetItem() != null;
			this.btnNext.Enabled = flag2 && flag;
			System.Windows.Forms.Button button = this.btnAccept;
			System.Windows.Forms.Button button2 = this.btnReject;
			System.Windows.Forms.Button button3 = this.btnRejectAll;
			bool flag5 = (this.btnAcceptAll.Enabled = flag && flag3);
			bool flag7 = (button3.Enabled = flag5);
			bool enabled = (button2.Enabled = flag7);
			button.Enabled = enabled;
		}

		private void UpdateTrackedChangeInfo()
		{
			TrackedChange item = this.m_tcc.GetItem();
			if (item != null)
			{
				string format = "({0})";
				this.labelChangeTime.Text = string.Format(format, item.ChangeTime.ToLocalTime());
				string text = ((item.ChangeKind == ChangeKind.InsertedText) ? Resources.TRACKED_CHANGES_DLG_CHANGEKIND_INSERTEDTEXT : Resources.TRACKED_CHANGES_DLG_CHANGEKIND_DELETEDTEXT);
				string text2 = ((item.UserName != "") ? item.UserName : new ResourceManager("TXTextControl.TextControlCore", typeof(ApplicationField).Assembly).GetString("ID_TRACKEDCHANGES_UNKNOWNUSER"));
				this.labelReviewerAction.Text = string.Join(" ", text2, text);
				BinaryStreamType binaryStreamType = BinaryStreamType.InternalUnicodeFormat;
				item.Save(out var binaryData, binaryStreamType);
				this.m_textControl.Load(binaryData, binaryStreamType);
			}
			else
			{
				this.labelChangeTime.Text = "";
				this.labelReviewerAction.Text = "";
				this.m_textControl.ResetContents();
			}
		}

		private void Next()
		{
			this.m_tcc.GetItem(next: true)?.Select();
			this.Refresh();
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
			this.labelReviewerAction = new System.Windows.Forms.Label();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnAccept = new System.Windows.Forms.Button();
			this.btnReject = new System.Windows.Forms.Button();
			this.btnRejectAll = new System.Windows.Forms.Button();
			this.btnAcceptAll = new System.Windows.Forms.Button();
			this.labelChangeTime = new System.Windows.Forms.Label();
			this.btnClose = new System.Windows.Forms.Button();
			this.m_textControl = new TXTextControl.TextControl();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			base.SuspendLayout();
			this.labelReviewerAction.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.labelReviewerAction, 2);
			this.labelReviewerAction.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelReviewerAction.Location = new System.Drawing.Point(0, 5);
			this.labelReviewerAction.Margin = new System.Windows.Forms.Padding(0, 5, 3, 0);
			this.labelReviewerAction.Name = "labelReviewerAction";
			this.labelReviewerAction.Size = new System.Drawing.Size(411, 13);
			this.labelReviewerAction.TabIndex = 10;
			this.labelReviewerAction.Text = "Unknown Reviewer Inserted:";
			this.labelReviewerAction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnNext.Location = new System.Drawing.Point(417, 0);
			this.btnNext.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(75, 23);
			this.btnNext.TabIndex = 1;
			this.btnNext.Text = "&Next";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(btnNext_Click);
			this.btnAccept.AutoSize = true;
			this.btnAccept.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnAccept.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnAccept.Location = new System.Drawing.Point(0, 3);
			this.btnAccept.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
			this.btnAccept.MinimumSize = new System.Drawing.Size(75, 23);
			this.btnAccept.Name = "btnAccept";
			this.btnAccept.Size = new System.Drawing.Size(75, 23);
			this.btnAccept.TabIndex = 2;
			this.btnAccept.Text = "&Accept";
			this.btnAccept.UseVisualStyleBackColor = true;
			this.btnAccept.Click += new System.EventHandler(btnAccept_Click);
			this.btnReject.AutoSize = true;
			this.btnReject.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnReject.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnReject.Location = new System.Drawing.Point(81, 3);
			this.btnReject.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.btnReject.MinimumSize = new System.Drawing.Size(75, 23);
			this.btnReject.Name = "btnReject";
			this.btnReject.Size = new System.Drawing.Size(75, 23);
			this.btnReject.TabIndex = 3;
			this.btnReject.Text = "&Reject";
			this.btnReject.UseVisualStyleBackColor = true;
			this.btnReject.Click += new System.EventHandler(btnReject_Click);
			this.btnRejectAll.AutoSize = true;
			this.btnRejectAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnRejectAll.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnRejectAll.Location = new System.Drawing.Point(243, 3);
			this.btnRejectAll.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.btnRejectAll.MinimumSize = new System.Drawing.Size(75, 23);
			this.btnRejectAll.Name = "btnRejectAll";
			this.btnRejectAll.Size = new System.Drawing.Size(75, 23);
			this.btnRejectAll.TabIndex = 5;
			this.btnRejectAll.Text = "R&eject All";
			this.btnRejectAll.UseVisualStyleBackColor = true;
			this.btnRejectAll.Click += new System.EventHandler(btnRejectAll_Click);
			this.btnAcceptAll.AutoSize = true;
			this.btnAcceptAll.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnAcceptAll.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnAcceptAll.Location = new System.Drawing.Point(162, 3);
			this.btnAcceptAll.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.btnAcceptAll.MinimumSize = new System.Drawing.Size(75, 23);
			this.btnAcceptAll.Name = "btnAcceptAll";
			this.btnAcceptAll.Size = new System.Drawing.Size(75, 23);
			this.btnAcceptAll.TabIndex = 4;
			this.btnAcceptAll.Text = "A&ccept All";
			this.btnAcceptAll.UseVisualStyleBackColor = true;
			this.btnAcceptAll.Click += new System.EventHandler(btnAcceptAll_Click);
			this.labelChangeTime.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.labelChangeTime, 3);
			this.labelChangeTime.Dock = System.Windows.Forms.DockStyle.Left;
			this.labelChangeTime.Location = new System.Drawing.Point(0, 253);
			this.labelChangeTime.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
			this.labelChangeTime.Name = "labelChangeTime";
			this.labelChangeTime.Size = new System.Drawing.Size(123, 13);
			this.labelChangeTime.TabIndex = 9;
			this.labelChangeTime.Text = "(9/5/2018 12:53:28 AM)";
			this.btnClose.AutoSize = true;
			this.btnClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Dock = System.Windows.Forms.DockStyle.Top;
			this.btnClose.Location = new System.Drawing.Point(417, 3);
			this.btnClose.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
			this.btnClose.MinimumSize = new System.Drawing.Size(75, 23);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 7;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(btnClose_Click);
			this.m_textControl.AcceptsTab = false;
			this.m_textControl.EditMode = TXTextControl.EditMode.ReadOnly;
			this.m_textControl.Font = new System.Drawing.Font("Arial", 10f);
			this.m_textControl.Location = new System.Drawing.Point(15, 33);
			this.m_textControl.Name = "m_textControl";
			this.m_textControl.Size = new System.Drawing.Size(550, 159);
			this.m_textControl.TabIndex = 8;
			this.m_textControl.TabStop = false;
			this.m_textControl.UserNames = null;
			this.m_textControl.ViewMode = TXTextControl.ViewMode.Normal;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.btnNext, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.m_textControl, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelChangeTime, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelReviewerAction, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 7);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 4;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(492, 295);
			this.tableLayoutPanel1.TabIndex = 11;
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 6;
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 3);
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.btnClose, 5, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnRejectAll, 3, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnAccept, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnReject, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnAcceptAll, 2, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 269);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.Size = new System.Drawing.Size(492, 26);
			this.tableLayoutPanel2.TabIndex = 12;
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			base.CancelButton = this.btnClose;
			base.ClientSize = new System.Drawing.Size(506, 309);
			base.Controls.Add(this.tableLayoutPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "TrackedChangesDialog";
			base.Padding = new System.Windows.Forms.Padding(7);
			this.RightToLeftLayout = true;
			base.ShowIcon = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Tracked Changes";
			base.Shown += new System.EventHandler(TrackedChangesDialog_Shown);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
