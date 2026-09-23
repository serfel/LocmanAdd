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
using TXTextControl.Windows.Forms;

namespace ns26
{
	internal class ConditionalInstructionDialog : Form
	{
		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private string string_0;

		private List<string> list_0;

		private uint uint_0;

		private IContainer icontainer_0;

		private TableLayoutPanel m_tlpMainPanel;

		private Class458 m_cgvConditons;

		private Label m_lblInstructions;

		private TableLayoutPanel m_tlpName;

		private Label m_lblName;

		private TextBox m_tbxName;

		private Label m_lblConditions;

		private System.Windows.Forms.Button m_btnOK;

		private System.Windows.Forms.Button m_btnCancel;

		private Panel m_pnlInstructionsScrollViewer;

		private Panel m_pnlConditionsScrollViewer;

		private Class459 m_igvInstructions;

		internal string String_0 => this.m_tbxName.Text;

		internal List<Row> List_0 => this.m_cgvConditons.List_1;

		internal List<Row> List_1 => this.m_igvInstructions.List_1;

		internal ConditionalInstructionDialog(Class456 class456_0, ConditionalInstruction conditionalInstruction_0, List<string> list_1)
		{
			this.list_0 = list_1;
			this.InitializeComponent();
			this.Text = this.resourceManager_0.GetString("ID_CONDITIONALINSTRUCTION_CAPTION");
			this.m_lblName.Text = this.resourceManager_0.GetString("ID_CONDITIONALINSTRUCTION_NAME");
			this.m_lblConditions.Text = this.resourceManager_0.GetString("ID_CONDITIONALINSTRUCTION_CONDITIONS");
			this.m_lblInstructions.Text = this.resourceManager_0.GetString("ID_CONDITIONALINSTRUCTION_INSTRUCTIONS");
			this.m_btnOK.Text = this.resourceManager_0.GetString("ID_CONDITIONALINSTRUCTION_OK");
			this.m_btnCancel.Text = this.resourceManager_0.GetString("ID_CONDITIONALINSTRUCTION_CANCEL");
			if (conditionalInstruction_0 != null)
			{
				this.m_tbxName.Text = (this.string_0 = conditionalInstruction_0.Name);
			}
			this.m_cgvConditons.method_7(class456_0.Class394_0.Dictionary_1, (conditionalInstruction_0 != null) ? conditionalInstruction_0.Conditions : new IConditionalInstructionElement[0]);
			this.m_igvInstructions.method_7(class456_0.Class394_0.Dictionary_1, (conditionalInstruction_0 != null) ? conditionalInstruction_0.Instructions : new IConditionalInstructionElement[0]);
			this.m_cgvConditons.AllRowsAreValidChanged += m_tbxName_TextChanged;
			this.m_igvInstructions.AllRowsAreValidChanged += m_tbxName_TextChanged;
			this.m_igvInstructions.TextControl_0 = class456_0.TextControl_0;
		}

		private void m_btnOK_Click(object sender, EventArgs e)
		{
			foreach (Class460 item in this.m_cgvConditons.List_1)
			{
				((IConditionalInstructionElement)item.Condition_0).ConditionalInstructionName = this.m_tbxName.Text;
			}
			foreach (Class461 item2 in this.m_igvInstructions.List_1)
			{
				((IConditionalInstructionElement)item2.Instruction_0).ConditionalInstructionName = this.m_tbxName.Text;
			}
			base.DialogResult = DialogResult.OK;
		}

		private void m_tbxName_TextChanged(object sender, EventArgs e)
		{
			this.m_btnOK.Enabled = this.method_0(this.m_tbxName.Text) && this.m_igvInstructions.Boolean_0 && this.m_cgvConditons.Boolean_0;
		}

		private bool method_0(string string_1)
		{
			if (string_1 == this.string_0)
			{
				return true;
			}
			if (string.IsNullOrEmpty(string_1))
			{
				return false;
			}
			foreach (string item in this.list_0)
			{
				if (item == string_1)
				{
					return false;
				}
			}
			return true;
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			Graphics graphics = base.CreateGraphics();
			this.uint_0 = Class468.smethod_0(graphics, this);
			PointF pointF_ = ((this.uint_0 != 0) ? new PointF(this.uint_0, this.uint_0) : new PointF(graphics.DpiX, graphics.DpiY));
			graphics.Dispose();
			this.m_cgvConditons.method_0(pointF_);
			this.m_igvInstructions.method_0(pointF_);
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
					PointF pointF_ = new PointF(this.uint_0, this.uint_0);
					this.m_cgvConditons.method_0(pointF_);
					this.m_igvInstructions.method_0(pointF_);
					Class468.smethod_1(this.uint_0, struct83_, this);
				}
			}
			else
			{
				base.WndProc(ref message);
			}
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
			this.m_tlpName = new System.Windows.Forms.TableLayoutPanel();
			this.m_lblName = new System.Windows.Forms.Label();
			this.m_tbxName = new System.Windows.Forms.TextBox();
			this.m_lblConditions = new System.Windows.Forms.Label();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_pnlInstructionsScrollViewer = new System.Windows.Forms.Panel();
			this.m_igvInstructions = new ns26.Class459();
			this.m_pnlConditionsScrollViewer = new System.Windows.Forms.Panel();
			this.m_cgvConditons = new ns26.Class458();
			this.m_lblInstructions = new System.Windows.Forms.Label();
			this.m_tlpMainPanel.SuspendLayout();
			this.m_tlpName.SuspendLayout();
			this.m_pnlInstructionsScrollViewer.SuspendLayout();
			this.m_pnlConditionsScrollViewer.SuspendLayout();
			base.SuspendLayout();
			this.m_tlpMainPanel.AutoSize = true;
			this.m_tlpMainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_tlpMainPanel.ColumnCount = 3;
			this.m_tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpMainPanel.Controls.Add(this.m_tlpName, 0, 0);
			this.m_tlpMainPanel.Controls.Add(this.m_lblConditions, 0, 1);
			this.m_tlpMainPanel.Controls.Add(this.m_btnOK, 1, 6);
			this.m_tlpMainPanel.Controls.Add(this.m_btnCancel, 2, 6);
			this.m_tlpMainPanel.Controls.Add(this.m_pnlInstructionsScrollViewer, 0, 5);
			this.m_tlpMainPanel.Controls.Add(this.m_pnlConditionsScrollViewer, 0, 2);
			this.m_tlpMainPanel.Controls.Add(this.m_lblInstructions, 0, 4);
			this.m_tlpMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_tlpMainPanel.Location = new System.Drawing.Point(7, 7);
			this.m_tlpMainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.m_tlpMainPanel.Name = "m_tlpMainPanel";
			this.m_tlpMainPanel.RowCount = 7;
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpMainPanel.Size = new System.Drawing.Size(331, 262);
			this.m_tlpMainPanel.TabIndex = 2;
			this.m_tlpName.AutoSize = true;
			this.m_tlpName.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_tlpName.ColumnCount = 2;
			this.m_tlpMainPanel.SetColumnSpan(this.m_tlpName, 3);
			this.m_tlpName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpName.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpName.Controls.Add(this.m_lblName, 0, 0);
			this.m_tlpName.Controls.Add(this.m_tbxName, 1, 0);
			this.m_tlpName.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_tlpName.Location = new System.Drawing.Point(0, 0);
			this.m_tlpName.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
			this.m_tlpName.Name = "m_tlpName";
			this.m_tlpName.RowCount = 1;
			this.m_tlpName.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpName.Size = new System.Drawing.Size(331, 23);
			this.m_tlpName.TabIndex = 0;
			this.m_tlpName.TabStop = true;
			this.m_lblName.AutoSize = true;
			this.m_lblName.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_lblName.Location = new System.Drawing.Point(0, 0);
			this.m_lblName.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
			this.m_lblName.Name = "m_lblName";
			this.m_lblName.Size = new System.Drawing.Size(38, 20);
			this.m_lblName.TabIndex = 1;
			this.m_lblName.Text = "Name:";
			this.m_lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_tbxName.Location = new System.Drawing.Point(44, 0);
			this.m_tbxName.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
			this.m_tbxName.Name = "m_tbxName";
			this.m_tbxName.Size = new System.Drawing.Size(206, 20);
			this.m_tbxName.TabIndex = 2;
			this.m_tbxName.TextChanged += new System.EventHandler(m_tbxName_TextChanged);
			this.m_lblConditions.AutoSize = true;
			this.m_tlpMainPanel.SetColumnSpan(this.m_lblConditions, 3);
			this.m_lblConditions.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblConditions.Location = new System.Drawing.Point(0, 31);
			this.m_lblConditions.Margin = new System.Windows.Forms.Padding(0, 6, 0, 3);
			this.m_lblConditions.Name = "m_lblConditions";
			this.m_lblConditions.Size = new System.Drawing.Size(331, 13);
			this.m_lblConditions.TabIndex = 3;
			this.m_lblConditions.Text = "Condition(s):";
			this.m_btnOK.AutoSize = true;
			this.m_btnOK.Enabled = false;
			this.m_btnOK.Location = new System.Drawing.Point(175, 216);
			this.m_btnOK.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.m_btnOK.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(75, 23);
			this.m_btnOK.TabIndex = 7;
			this.m_btnOK.Text = "OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(m_btnOK_Click);
			this.m_btnCancel.AutoSize = true;
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Location = new System.Drawing.Point(256, 216);
			this.m_btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
			this.m_btnCancel.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
			this.m_btnCancel.TabIndex = 8;
			this.m_btnCancel.Text = "Cancel";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			this.m_pnlInstructionsScrollViewer.AutoScroll = true;
			this.m_pnlInstructionsScrollViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_tlpMainPanel.SetColumnSpan(this.m_pnlInstructionsScrollViewer, 3);
			this.m_pnlInstructionsScrollViewer.Controls.Add(this.m_igvInstructions);
			this.m_pnlInstructionsScrollViewer.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_pnlInstructionsScrollViewer.Location = new System.Drawing.Point(0, 144);
			this.m_pnlInstructionsScrollViewer.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.m_pnlInstructionsScrollViewer.Name = "m_pnlInstructionsScrollViewer";
			this.m_pnlInstructionsScrollViewer.Size = new System.Drawing.Size(331, 66);
			this.m_pnlInstructionsScrollViewer.TabIndex = 9;
			this.m_igvInstructions.AutoSize = true;
			this.m_igvInstructions.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_igvInstructions.ColumnCount = 2;
			this.m_igvInstructions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_igvInstructions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 329f));
			this.m_igvInstructions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_igvInstructions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 333f));
			this.m_igvInstructions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_igvInstructions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 272f));
			this.m_igvInstructions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_igvInstructions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 268f));
			this.m_igvInstructions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_igvInstructions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 267f));
			this.m_igvInstructions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_igvInstructions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 270f));
			this.m_igvInstructions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_igvInstructions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 275f));
			this.m_igvInstructions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_igvInstructions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 272f));
			this.m_igvInstructions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_igvInstructions.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 272f));
			this.m_igvInstructions.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_igvInstructions.Location = new System.Drawing.Point(0, 0);
			this.m_igvInstructions.Margin = new System.Windows.Forms.Padding(0);
			this.m_igvInstructions.MinimumSize = new System.Drawing.Size(154, 76);
			this.m_igvInstructions.Name = "m_igvInstructions";
			this.m_igvInstructions.Size = new System.Drawing.Size(312, 76);
			this.m_igvInstructions.TabIndex = 7;
			this.m_igvInstructions.TabStop = true;
			this.m_igvInstructions.Int32_0 = 4;
			this.m_pnlConditionsScrollViewer.AutoScroll = true;
			this.m_pnlConditionsScrollViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_tlpMainPanel.SetColumnSpan(this.m_pnlConditionsScrollViewer, 3);
			this.m_pnlConditionsScrollViewer.Controls.Add(this.m_cgvConditons);
			this.m_pnlConditionsScrollViewer.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_pnlConditionsScrollViewer.Location = new System.Drawing.Point(0, 50);
			this.m_pnlConditionsScrollViewer.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.m_pnlConditionsScrollViewer.Name = "m_pnlConditionsScrollViewer";
			this.m_pnlConditionsScrollViewer.Size = new System.Drawing.Size(331, 66);
			this.m_pnlConditionsScrollViewer.TabIndex = 10;
			this.m_cgvConditons.AutoSize = true;
			this.m_cgvConditons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_cgvConditons.ColumnCount = 2;
			this.m_cgvConditons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_cgvConditons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 329f));
			this.m_cgvConditons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_cgvConditons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 333f));
			this.m_cgvConditons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_cgvConditons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 272f));
			this.m_cgvConditons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_cgvConditons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 268f));
			this.m_cgvConditons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_cgvConditons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 267f));
			this.m_cgvConditons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_cgvConditons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 270f));
			this.m_cgvConditons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_cgvConditons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 275f));
			this.m_cgvConditons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_cgvConditons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 272f));
			this.m_cgvConditons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_cgvConditons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 272f));
			this.m_cgvConditons.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_cgvConditons.Location = new System.Drawing.Point(0, 0);
			this.m_cgvConditons.Margin = new System.Windows.Forms.Padding(0);
			this.m_cgvConditons.MinimumSize = new System.Drawing.Size(154, 76);
			this.m_cgvConditons.Name = "m_cgvConditons";
			this.m_cgvConditons.Size = new System.Drawing.Size(312, 76);
			this.m_cgvConditons.TabIndex = 4;
			this.m_cgvConditons.TabStop = true;
			this.m_cgvConditons.Int32_0 = 4;
			this.m_lblInstructions.AutoSize = true;
			this.m_lblInstructions.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblInstructions.Location = new System.Drawing.Point(0, 125);
			this.m_lblInstructions.Margin = new System.Windows.Forms.Padding(0, 6, 0, 3);
			this.m_lblInstructions.Name = "m_lblInstructions";
			this.m_lblInstructions.Size = new System.Drawing.Size(172, 13);
			this.m_lblInstructions.TabIndex = 5;
			this.m_lblInstructions.Text = "Perform these actions:";
			base.AcceptButton = this.m_btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.m_btnCancel;
			base.ClientSize = new System.Drawing.Size(345, 276);
			base.Controls.Add(this.m_tlpMainPanel);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Margin = new System.Windows.Forms.Padding(2);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ConditionalInstructionDialog";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Conditional Instruction";
			this.m_tlpMainPanel.ResumeLayout(false);
			this.m_tlpMainPanel.PerformLayout();
			this.m_tlpName.ResumeLayout(false);
			this.m_tlpName.PerformLayout();
			this.m_pnlInstructionsScrollViewer.ResumeLayout(false);
			this.m_pnlInstructionsScrollViewer.PerformLayout();
			this.m_pnlConditionsScrollViewer.ResumeLayout(false);
			this.m_pnlConditionsScrollViewer.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
