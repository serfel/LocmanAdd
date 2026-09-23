using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ns21;
using ns27;
using TXTextControl;

namespace ns26
{
	internal class ManageConditionalInstructionsDialog : Form
	{
		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private Class456 class456_0;

		private bool bool_0;

		private List<ConditionalInstruction> list_0 = new List<ConditionalInstruction>();

		private List<string> list_1 = new List<string>();

		private bool bool_1;

		private uint uint_0;

		private IContainer icontainer_0;

		private TableLayoutPanel m_tlpMainPanel;

		private Label m_lblConditionalInstructions;

		private ListBox m_lbxConditionalInstructions;

		private System.Windows.Forms.Button m_btnNew;

		private System.Windows.Forms.Button m_btnEdit;

		private System.Windows.Forms.Button m_btnDelete;

		private TableLayoutPanel m_tlpBottomPanel;

		private System.Windows.Forms.Button m_btnCancel;

		private System.Windows.Forms.Button m_btnOK;

		internal ConditionalInstruction[] ConditionalInstruction_0 => this.list_0.ToArray();

		internal bool Boolean_0 => this.bool_0;

		internal ManageConditionalInstructionsDialog(Class456 class456_1)
		{
			this.class456_0 = class456_1;
			this.bool_1 = this.class456_0.TextControl_0.EditMode == EditMode.ReadAndSelect || this.class456_0.TextControl_0.EditMode == EditMode.ReadOnly;
			this.InitializeComponent();
			this.Text = this.resourceManager_0.GetString("ID_MANAGECONDITIONALINSTRUCTIONS_CAPTION");
			this.m_lblConditionalInstructions.Text = this.resourceManager_0.GetString("ID_MANAGECONDITIONALINSTRUCTIONS_ITEMS");
			this.m_btnNew.Text = this.resourceManager_0.GetString("ID_MANAGECONDITIONALINSTRUCTIONS_NEW");
			this.m_btnEdit.Text = this.resourceManager_0.GetString("ID_MANAGECONDITIONALINSTRUCTIONS_EDIT");
			this.m_btnDelete.Text = this.resourceManager_0.GetString("ID_MANAGECONDITIONALINSTRUCTIONS_DELETE");
			this.m_btnOK.Text = this.resourceManager_0.GetString("ID_MANAGECONDITIONALINSTRUCTIONS_OK");
			this.m_btnCancel.Text = this.resourceManager_0.GetString("ID_MANAGECONDITIONALINSTRUCTIONS_CANCEL");
			foreach (string item in this.class456_0.Class394_0.List_1)
			{
				ConditionalInstruction conditionalInstruction = this.class456_0.Class394_0.method_4(item);
				this.m_lbxConditionalInstructions.Items.Add(conditionalInstruction);
				this.list_0.Add(conditionalInstruction);
				this.list_1.Add(conditionalInstruction.Name);
			}
			if (this.m_lbxConditionalInstructions.Items.Count > 0)
			{
				this.m_lbxConditionalInstructions.SelectedIndex = 0;
			}
			this.method_4();
		}

		private void m_btnNew_Click(object sender, EventArgs e)
		{
			ConditionalInstructionDialog conditionalInstructionDialog = new ConditionalInstructionDialog(this.class456_0, null, this.list_1);
			conditionalInstructionDialog.RightToLeft = this.class456_0.TextControl_0.RightToLeft;
			if (conditionalInstructionDialog.ShowDialog(this.class456_0.TextControl_0) == DialogResult.OK)
			{
				ConditionalInstruction conditionalInstruction_ = this.method_0(conditionalInstructionDialog);
				this.method_1(conditionalInstruction_);
			}
		}

		private void m_btnEdit_Click(object sender, EventArgs e)
		{
			if (this.m_lbxConditionalInstructions.SelectedItem != null)
			{
				ConditionalInstruction conditionalInstruction_ = (this.m_lbxConditionalInstructions.SelectedItem as ConditionalInstruction).Copy();
				ConditionalInstructionDialog conditionalInstructionDialog = new ConditionalInstructionDialog(this.class456_0, conditionalInstruction_, this.list_1);
				conditionalInstructionDialog.RightToLeft = this.class456_0.TextControl_0.RightToLeft;
				if (conditionalInstructionDialog.ShowDialog(this.class456_0.TextControl_0) == DialogResult.OK)
				{
					ConditionalInstruction conditionalInstruction_2 = this.method_0(conditionalInstructionDialog);
					this.method_2(this.m_lbxConditionalInstructions.SelectedItem as ConditionalInstruction, conditionalInstruction_2);
				}
			}
		}

		private void m_btnDelete_Click(object sender, EventArgs e)
		{
			if (this.m_lbxConditionalInstructions.SelectedItem != null)
			{
				this.method_3(this.m_lbxConditionalInstructions.SelectedItem as ConditionalInstruction);
			}
		}

		private void m_lbxConditionalInstructions_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.method_4();
		}

		private void m_btnOK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
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

		private ConditionalInstruction method_0(ConditionalInstructionDialog conditionalInstructionDialog_0)
		{
			ConditionalInstruction conditionalInstruction = new ConditionalInstruction();
			conditionalInstruction.Name = conditionalInstructionDialog_0.String_0;
			ConditionalInstruction conditionalInstruction2 = conditionalInstruction;
			foreach (Class460 item in conditionalInstructionDialog_0.List_0)
			{
				conditionalInstruction2.List_0.Add(item.Condition_0);
			}
			foreach (Class461 item2 in conditionalInstructionDialog_0.List_1)
			{
				conditionalInstruction2.List_1.Add(item2.Instruction_0);
			}
			return conditionalInstruction2;
		}

		private void method_1(ConditionalInstruction conditionalInstruction_0)
		{
			this.m_lbxConditionalInstructions.Items.Add(conditionalInstruction_0);
			this.list_0.Add(conditionalInstruction_0);
			this.list_1.Add(conditionalInstruction_0.Name);
			this.m_lbxConditionalInstructions.SelectedIndex = this.m_lbxConditionalInstructions.Items.Count - 1;
			this.bool_0 = true;
		}

		private void method_2(ConditionalInstruction conditionalInstruction_0, ConditionalInstruction conditionalInstruction_1)
		{
			int selectedIndex = this.m_lbxConditionalInstructions.SelectedIndex;
			this.m_lbxConditionalInstructions.Items[selectedIndex] = conditionalInstruction_1;
			int index = this.list_0.IndexOf(conditionalInstruction_0);
			this.list_0.Remove(conditionalInstruction_0);
			this.list_1.Remove(conditionalInstruction_0.Name);
			this.list_0.Insert(index, conditionalInstruction_1);
			this.list_1.Insert(index, conditionalInstruction_0.Name);
			this.m_lbxConditionalInstructions.SelectedIndex = selectedIndex;
			this.bool_0 = true;
		}

		private void method_3(ConditionalInstruction conditionalInstruction_0)
		{
			int selectedIndex = this.m_lbxConditionalInstructions.SelectedIndex;
			this.m_lbxConditionalInstructions.Items.Remove(conditionalInstruction_0);
			this.list_0.Remove(conditionalInstruction_0);
			this.list_1.Remove(conditionalInstruction_0.Name);
			this.m_lbxConditionalInstructions.SelectedIndex = Math.Min(selectedIndex, this.m_lbxConditionalInstructions.Items.Count - 1);
			this.bool_0 = true;
		}

		private void method_4()
		{
			this.m_btnNew.Enabled = !this.bool_1 && this.class456_0.TextControl_0.FormFields.Count > 0;
			System.Windows.Forms.Button btnEdit = this.m_btnEdit;
			bool enabled = (this.m_btnDelete.Enabled = !this.bool_1 && this.m_lbxConditionalInstructions.SelectedItem != null);
			btnEdit.Enabled = enabled;
			this.m_btnOK.Enabled = !this.bool_1;
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
			this.m_tlpMainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.m_lblConditionalInstructions = new System.Windows.Forms.Label();
			this.m_lbxConditionalInstructions = new System.Windows.Forms.ListBox();
			this.m_btnNew = new System.Windows.Forms.Button();
			this.m_btnEdit = new System.Windows.Forms.Button();
			this.m_btnDelete = new System.Windows.Forms.Button();
			this.m_tlpBottomPanel = new System.Windows.Forms.TableLayoutPanel();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_tlpMainPanel.SuspendLayout();
			this.m_tlpBottomPanel.SuspendLayout();
			base.SuspendLayout();
			this.m_tlpMainPanel.AutoSize = true;
			this.m_tlpMainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_tlpMainPanel.ColumnCount = 2;
			this.m_tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpMainPanel.Controls.Add(this.m_lblConditionalInstructions, 0, 0);
			this.m_tlpMainPanel.Controls.Add(this.m_lbxConditionalInstructions, 0, 1);
			this.m_tlpMainPanel.Controls.Add(this.m_btnNew, 1, 1);
			this.m_tlpMainPanel.Controls.Add(this.m_btnEdit, 1, 2);
			this.m_tlpMainPanel.Controls.Add(this.m_btnDelete, 1, 3);
			this.m_tlpMainPanel.Controls.Add(this.m_tlpBottomPanel, 0, 5);
			this.m_tlpMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_tlpMainPanel.Location = new System.Drawing.Point(14, 13);
			this.m_tlpMainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.m_tlpMainPanel.Name = "m_tlpMainPanel";
			this.m_tlpMainPanel.RowCount = 6;
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpMainPanel.Size = new System.Drawing.Size(568, 384);
			this.m_tlpMainPanel.TabIndex = 0;
			this.m_lblConditionalInstructions.AutoSize = true;
			this.m_tlpMainPanel.SetColumnSpan(this.m_lblConditionalInstructions, 2);
			this.m_lblConditionalInstructions.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblConditionalInstructions.Location = new System.Drawing.Point(0, 0);
			this.m_lblConditionalInstructions.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
			this.m_lblConditionalInstructions.Name = "m_lblConditionalInstructions";
			this.m_lblConditionalInstructions.Size = new System.Drawing.Size(568, 25);
			this.m_lblConditionalInstructions.TabIndex = 0;
			this.m_lblConditionalInstructions.Text = "Conditional Instructions:";
			this.m_lbxConditionalInstructions.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lbxConditionalInstructions.FormattingEnabled = true;
			this.m_lbxConditionalInstructions.IntegralHeight = false;
			this.m_lbxConditionalInstructions.ItemHeight = 25;
			this.m_lbxConditionalInstructions.Location = new System.Drawing.Point(0, 37);
			this.m_lbxConditionalInstructions.Margin = new System.Windows.Forms.Padding(0, 6, 6, 6);
			this.m_lbxConditionalInstructions.MinimumSize = new System.Drawing.Size(466, 352);
			this.m_lbxConditionalInstructions.Name = "m_lbxConditionalInstructions";
			this.m_tlpMainPanel.SetRowSpan(this.m_lbxConditionalInstructions, 4);
			this.m_lbxConditionalInstructions.Size = new System.Drawing.Size(466, 352);
			this.m_lbxConditionalInstructions.TabIndex = 1;
			this.m_lbxConditionalInstructions.SelectedIndexChanged += new System.EventHandler(m_lbxConditionalInstructions_SelectedIndexChanged);
			this.m_btnNew.AutoSize = true;
			this.m_btnNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnNew.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnNew.Enabled = false;
			this.m_btnNew.Location = new System.Drawing.Point(418, 37);
			this.m_btnNew.Margin = new System.Windows.Forms.Padding(6, 6, 0, 6);
			this.m_btnNew.MinimumSize = new System.Drawing.Size(150, 44);
			this.m_btnNew.Name = "m_btnNew";
			this.m_btnNew.Size = new System.Drawing.Size(150, 44);
			this.m_btnNew.TabIndex = 2;
			this.m_btnNew.Text = "New...";
			this.m_btnNew.UseVisualStyleBackColor = true;
			this.m_btnNew.Click += new System.EventHandler(m_btnNew_Click);
			this.m_btnEdit.AutoSize = true;
			this.m_btnEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnEdit.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnEdit.Enabled = false;
			this.m_btnEdit.Location = new System.Drawing.Point(418, 93);
			this.m_btnEdit.Margin = new System.Windows.Forms.Padding(6, 6, 0, 6);
			this.m_btnEdit.MinimumSize = new System.Drawing.Size(150, 44);
			this.m_btnEdit.Name = "m_btnEdit";
			this.m_btnEdit.Size = new System.Drawing.Size(150, 44);
			this.m_btnEdit.TabIndex = 3;
			this.m_btnEdit.Text = "Edit...";
			this.m_btnEdit.UseVisualStyleBackColor = true;
			this.m_btnEdit.Click += new System.EventHandler(m_btnEdit_Click);
			this.m_btnDelete.AutoSize = true;
			this.m_btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnDelete.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnDelete.Enabled = false;
			this.m_btnDelete.Location = new System.Drawing.Point(418, 149);
			this.m_btnDelete.Margin = new System.Windows.Forms.Padding(6, 6, 0, 6);
			this.m_btnDelete.MinimumSize = new System.Drawing.Size(150, 44);
			this.m_btnDelete.Name = "m_btnDelete";
			this.m_btnDelete.Size = new System.Drawing.Size(150, 44);
			this.m_btnDelete.TabIndex = 4;
			this.m_btnDelete.Text = "Delete";
			this.m_btnDelete.UseVisualStyleBackColor = true;
			this.m_btnDelete.Click += new System.EventHandler(m_btnDelete_Click);
			this.m_tlpBottomPanel.AutoSize = true;
			this.m_tlpBottomPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_tlpBottomPanel.ColumnCount = 3;
			this.m_tlpMainPanel.SetColumnSpan(this.m_tlpBottomPanel, 2);
			this.m_tlpBottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpBottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpBottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpBottomPanel.Controls.Add(this.m_btnCancel, 2, 0);
			this.m_tlpBottomPanel.Controls.Add(this.m_btnOK, 1, 0);
			this.m_tlpBottomPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_tlpBottomPanel.Location = new System.Drawing.Point(0, 334);
			this.m_tlpBottomPanel.Margin = new System.Windows.Forms.Padding(0);
			this.m_tlpBottomPanel.Name = "m_tlpBottomPanel";
			this.m_tlpBottomPanel.RowCount = 1;
			this.m_tlpBottomPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpBottomPanel.Size = new System.Drawing.Size(568, 50);
			this.m_tlpBottomPanel.TabIndex = 5;
			this.m_tlpBottomPanel.TabStop = true;
			this.m_btnCancel.AutoSize = true;
			this.m_btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnCancel.Location = new System.Drawing.Point(418, 6);
			this.m_btnCancel.Margin = new System.Windows.Forms.Padding(6, 6, 0, 0);
			this.m_btnCancel.MinimumSize = new System.Drawing.Size(150, 44);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(150, 44);
			this.m_btnCancel.TabIndex = 7;
			this.m_btnCancel.Text = "Cancel";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			this.m_btnOK.AutoSize = true;
			this.m_btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnOK.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnOK.Location = new System.Drawing.Point(256, 6);
			this.m_btnOK.Margin = new System.Windows.Forms.Padding(6, 6, 6, 0);
			this.m_btnOK.MinimumSize = new System.Drawing.Size(150, 44);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(150, 44);
			this.m_btnOK.TabIndex = 6;
			this.m_btnOK.Text = "OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(m_btnOK_Click);
			base.AcceptButton = this.m_btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(12f, 25f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.m_btnCancel;
			base.ClientSize = new System.Drawing.Size(596, 410);
			base.Controls.Add(this.m_tlpMainPanel);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ManageConditionalInstructionsDialog";
			base.Padding = new System.Windows.Forms.Padding(14, 13, 14, 13);
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Conditional Instructions";
			this.m_tlpMainPanel.ResumeLayout(false);
			this.m_tlpMainPanel.PerformLayout();
			this.m_tlpBottomPanel.ResumeLayout(false);
			this.m_tlpBottomPanel.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
