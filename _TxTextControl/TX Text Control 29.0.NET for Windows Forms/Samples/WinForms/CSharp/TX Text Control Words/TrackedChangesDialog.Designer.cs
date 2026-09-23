namespace TX_Text_Control_Words {
	partial class TrackedChangesDialog {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
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
			this.SuspendLayout();
			// 
			// labelReviewerAction
			// 
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
			// 
			// btnNext
			// 
			this.btnNext.Location = new System.Drawing.Point(417, 0);
			this.btnNext.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new System.Drawing.Size(75, 23);
			this.btnNext.TabIndex = 1;
			this.btnNext.Text = "&Next";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnAccept
			// 
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
			this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
			// 
			// btnReject
			// 
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
			this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
			// 
			// btnRejectAll
			// 
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
			this.btnRejectAll.Click += new System.EventHandler(this.btnRejectAll_Click);
			// 
			// btnAcceptAll
			// 
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
			this.btnAcceptAll.Click += new System.EventHandler(this.btnAcceptAll_Click);
			// 
			// labelChangeTime
			// 
			this.labelChangeTime.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.labelChangeTime, 3);
			this.labelChangeTime.Dock = System.Windows.Forms.DockStyle.Left;
			this.labelChangeTime.Location = new System.Drawing.Point(0, 253);
			this.labelChangeTime.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
			this.labelChangeTime.Name = "labelChangeTime";
			this.labelChangeTime.Size = new System.Drawing.Size(123, 13);
			this.labelChangeTime.TabIndex = 9;
			this.labelChangeTime.Text = "(9/5/2018 12:53:28 AM)";
			// 
			// btnClose
			// 
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
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// m_textControl
			// 
			this.m_textControl.AcceptsTab = false;
			this.m_textControl.EditMode = TXTextControl.EditMode.ReadOnly;
			this.m_textControl.Font = new System.Drawing.Font("Arial", 10F);
			this.m_textControl.Location = new System.Drawing.Point(15, 33);
			this.m_textControl.Name = "m_textControl";
			this.m_textControl.Size = new System.Drawing.Size(550, 159);
			this.m_textControl.TabIndex = 8;
			this.m_textControl.TabStop = false;
			this.m_textControl.UserNames = null;
			this.m_textControl.ViewMode = TXTextControl.ViewMode.Normal;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
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
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(492, 295);
			this.tableLayoutPanel1.TabIndex = 11;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 6;
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 3);
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
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
			// 
			// TrackedChangesDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(506, 309);
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TrackedChangesDialog";
			this.Padding = new System.Windows.Forms.Padding(7);
			this.RightToLeftLayout = true;
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Tracked Changes";
			this.Shown += new System.EventHandler(this.TrackedChangesDialog_Shown);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label labelReviewerAction;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnAccept;
		private System.Windows.Forms.Button btnReject;
		private System.Windows.Forms.Button btnRejectAll;
		private System.Windows.Forms.Button btnAcceptAll;
		private System.Windows.Forms.Label labelChangeTime;
		private System.Windows.Forms.Button btnClose;
		private TXTextControl.TextControl m_textControl;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;

	}
}