using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TX_Text_Control_Words.Properties;

namespace TX_Text_Control_Words
{
	public class LimitPreviewDataDialog : Form
	{
		private IContainer components;

		private TableLayoutPanel tableLayoutPanel1;

		private Label m_lblText;

		private NumericUpDown m_nudResultsCount;

		private TableLayoutPanel tableLayoutPanel2;

		private Button m_btnCancel;

		private Button m_btnOK;

		internal int MaxPreviews => (int)this.m_nudResultsCount.Value;

		public LimitPreviewDataDialog()
		{
			this.InitializeComponent();
			this.Text = Resources.LIMIT_PREVIEW_DATA_DLG_TITLE;
			this.m_lblText.Text = Resources.LIMIT_PREVIEW_DATA_DLG_TEXT;
			this.m_btnOK.Text = Resources.LIMIT_PREVIEW_DATA_DLG_OK;
			this.m_btnCancel.Text = Resources.LIMIT_PREVIEW_DATA_DLG_CANCEL;
		}

		private void m_btnOK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		private void m_btnCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.m_lblText = new System.Windows.Forms.Label();
			this.m_nudResultsCount = new System.Windows.Forms.NumericUpDown();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.m_nudResultsCount).BeginInit();
			this.tableLayoutPanel2.SuspendLayout();
			base.SuspendLayout();
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.m_lblText, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.m_nudResultsCount, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(7);
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(273, 66);
			this.tableLayoutPanel1.TabIndex = 0;
			this.m_lblText.AutoSize = true;
			this.m_lblText.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_lblText.Location = new System.Drawing.Point(7, 7);
			this.m_lblText.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.m_lblText.Name = "m_lblText";
			this.m_lblText.Size = new System.Drawing.Size(132, 20);
			this.m_lblText.TabIndex = 0;
			this.m_lblText.Text = "&Number of preview results:";
			this.m_lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_nudResultsCount.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_nudResultsCount.Location = new System.Drawing.Point(177, 7);
			this.m_nudResultsCount.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.m_nudResultsCount.Maximum = new decimal(new int[4] { 1000000, 0, 0, 0 });
			this.m_nudResultsCount.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			this.m_nudResultsCount.Name = "m_nudResultsCount";
			this.m_nudResultsCount.Size = new System.Drawing.Size(89, 20);
			this.m_nudResultsCount.TabIndex = 1;
			this.m_nudResultsCount.Value = new decimal(new int[4] { 2, 0, 0, 0 });
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 3;
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.m_btnCancel, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.m_btnOK, 1, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(7, 33);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26f));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(259, 26);
			this.tableLayoutPanel2.TabIndex = 2;
			this.m_btnCancel.AutoSize = true;
			this.m_btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnCancel.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnCancel.Location = new System.Drawing.Point(184, 3);
			this.m_btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
			this.m_btnCancel.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
			this.m_btnCancel.TabIndex = 3;
			this.m_btnCancel.Text = "Cancel";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			this.m_btnCancel.Click += new System.EventHandler(m_btnCancel_Click);
			this.m_btnOK.AutoSize = true;
			this.m_btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnOK.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnOK.Location = new System.Drawing.Point(103, 3);
			this.m_btnOK.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.m_btnOK.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(75, 23);
			this.m_btnOK.TabIndex = 2;
			this.m_btnOK.Text = "OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(m_btnOK_Click);
			base.AcceptButton = this.m_btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			base.CancelButton = this.m_btnOK;
			base.ClientSize = new System.Drawing.Size(273, 66);
			base.Controls.Add(this.tableLayoutPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "LimitPreviewDataDialog";
			this.RightToLeftLayout = true;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Limit Preview Data";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.m_nudResultsCount).EndInit();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
