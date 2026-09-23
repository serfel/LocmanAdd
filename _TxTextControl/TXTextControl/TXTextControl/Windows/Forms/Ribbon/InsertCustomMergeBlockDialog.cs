using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ns21;
using ns27;
using TXTextControl;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class InsertCustomMergeBlockDialog : Form
	{
		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private uint uint_0;

		private IContainer icontainer_0;

		private TableLayoutPanel TXITEM_MainPanel;

		public Label TXITEM_InsertMergeBlockDialogLabel;

		public TextBox TXITEM_InsertMergeBlockDialogText;

		public System.Windows.Forms.Button TXITEM_Cancel;

		public System.Windows.Forms.Button TXITEM_OK;

		internal string String_0 => this.TXITEM_InsertMergeBlockDialogText.Text;

		internal InsertCustomMergeBlockDialog(TextControl textControl_0)
		{
			this.InitializeComponent();
			this.Text = this.resourceManager_0.GetString("ID_INSERTCUSTOMMERGEBLOCK_CAPTION");
			this.TXITEM_InsertMergeBlockDialogLabel.Text = this.resourceManager_0.GetString("ID_INSERTCUSTOMMERGEBLOCK_TEXT");
			this.TXITEM_OK.Text = this.resourceManager_0.GetString("ID_INSERTCUSTOMMERGEBLOCK_OK");
			this.TXITEM_Cancel.Text = this.resourceManager_0.GetString("ID_INSERTCUSTOMMERGEBLOCK_CANCEL");
			this.RightToLeft = textControl_0.RightToLeft;
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			this.uint_0 = Class468.smethod_0(null, this);
			Class429.Struct83 struct83_ = default(Class429.Struct83);
			Class429.GetWindowRect(base.Handle, ref struct83_);
			Class468.smethod_1(this.uint_0, struct83_, this);
			base.OnHandleCreated(eventArgs_0);
		}

		protected override void WndProc(ref Message message)
		{
			int msg = message.Msg;
			if (msg == 736)
			{
				uint num = Class429.smethod_5(message.WParam.ToInt32());
				if (num != this.uint_0)
				{
					Class429.Struct83 struct83_ = (Class429.Struct83)Marshal.PtrToStructure(message.LParam, typeof(Class429.Struct83));
					this.Font = new Font(this.Font.Name, this.Font.Size * (float)num / (float)this.uint_0, this.Font.Style, this.Font.Unit);
					this.uint_0 = num;
					Class468.smethod_1(this.uint_0, struct83_, this);
				}
			}
			else
			{
				base.WndProc(ref message);
			}
		}

		private void TXITEM_OK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.TXITEM_MainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.TXITEM_OK = new System.Windows.Forms.Button();
			this.TXITEM_InsertMergeBlockDialogLabel = new System.Windows.Forms.Label();
			this.TXITEM_InsertMergeBlockDialogText = new System.Windows.Forms.TextBox();
			this.TXITEM_Cancel = new System.Windows.Forms.Button();
			this.TXITEM_MainPanel.SuspendLayout();
			base.SuspendLayout();
			this.TXITEM_MainPanel.AutoSize = true;
			this.TXITEM_MainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TXITEM_MainPanel.ColumnCount = 3;
			this.TXITEM_MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.TXITEM_MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TXITEM_MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_OK, 1, 2);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_InsertMergeBlockDialogLabel, 0, 0);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_InsertMergeBlockDialogText, 0, 1);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_Cancel, 2, 2);
			this.TXITEM_MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TXITEM_MainPanel.Location = new System.Drawing.Point(14, 13);
			this.TXITEM_MainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.TXITEM_MainPanel.Name = "TXITEM_MainPanel";
			this.TXITEM_MainPanel.RowCount = 3;
			this.TXITEM_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_MainPanel.Size = new System.Drawing.Size(486, 136);
			this.TXITEM_MainPanel.TabIndex = 2;
			this.TXITEM_OK.AutoSize = true;
			this.TXITEM_OK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TXITEM_OK.Location = new System.Drawing.Point(174, 80);
			this.TXITEM_OK.Margin = new System.Windows.Forms.Padding(6, 6, 6, 0);
			this.TXITEM_OK.MinimumSize = new System.Drawing.Size(150, 44);
			this.TXITEM_OK.Name = "TXITEM_OK";
			this.TXITEM_OK.Size = new System.Drawing.Size(150, 44);
			this.TXITEM_OK.TabIndex = 2;
			this.TXITEM_OK.Text = "&OK";
			this.TXITEM_OK.UseVisualStyleBackColor = true;
			this.TXITEM_OK.Click += new System.EventHandler(TXITEM_OK_Click);
			this.TXITEM_InsertMergeBlockDialogLabel.AutoSize = true;
			this.TXITEM_MainPanel.SetColumnSpan(this.TXITEM_InsertMergeBlockDialogLabel, 3);
			this.TXITEM_InsertMergeBlockDialogLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_InsertMergeBlockDialogLabel.Location = new System.Drawing.Point(0, 0);
			this.TXITEM_InsertMergeBlockDialogLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
			this.TXITEM_InsertMergeBlockDialogLabel.Name = "TXITEM_InsertMergeBlockDialogLabel";
			this.TXITEM_InsertMergeBlockDialogLabel.Size = new System.Drawing.Size(486, 25);
			this.TXITEM_InsertMergeBlockDialogLabel.TabIndex = 0;
			this.TXITEM_InsertMergeBlockDialogLabel.Text = "Name:";
			this.TXITEM_MainPanel.SetColumnSpan(this.TXITEM_InsertMergeBlockDialogText, 3);
			this.TXITEM_InsertMergeBlockDialogText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TXITEM_InsertMergeBlockDialogText.Location = new System.Drawing.Point(0, 37);
			this.TXITEM_InsertMergeBlockDialogText.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
			this.TXITEM_InsertMergeBlockDialogText.MinimumSize = new System.Drawing.Size(496, 20);
			this.TXITEM_InsertMergeBlockDialogText.Name = "TXITEM_InsertMergeBlockDialogText";
			this.TXITEM_InsertMergeBlockDialogText.Size = new System.Drawing.Size(496, 31);
			this.TXITEM_InsertMergeBlockDialogText.TabIndex = 1;
			this.TXITEM_Cancel.AutoSize = true;
			this.TXITEM_Cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TXITEM_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.TXITEM_Cancel.Location = new System.Drawing.Point(336, 80);
			this.TXITEM_Cancel.Margin = new System.Windows.Forms.Padding(6, 6, 0, 0);
			this.TXITEM_Cancel.MinimumSize = new System.Drawing.Size(150, 44);
			this.TXITEM_Cancel.Name = "TXITEM_Cancel";
			this.TXITEM_Cancel.Size = new System.Drawing.Size(150, 44);
			this.TXITEM_Cancel.TabIndex = 3;
			this.TXITEM_Cancel.Text = "&Cancel";
			this.TXITEM_Cancel.UseVisualStyleBackColor = true;
			base.AcceptButton = this.TXITEM_OK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(12f, 25f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.TXITEM_Cancel;
			base.ClientSize = new System.Drawing.Size(514, 162);
			base.Controls.Add(this.TXITEM_MainPanel);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "InsertCustomMergeBlockDialog";
			base.Padding = new System.Windows.Forms.Padding(14, 13, 14, 13);
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Insert Custom Merge Block";
			this.TXITEM_MainPanel.ResumeLayout(false);
			this.TXITEM_MainPanel.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
