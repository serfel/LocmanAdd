using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TXTextControl;

namespace TX_Text_Control_Words.FormFields
{
	public class TextFormFieldDialog : Form
	{
		private TextFormField m_field;

		private IContainer components;

		private EmptyWidthControl emptyWidthControl;

		private TableLayoutPanel tableLayoutPanel1;

		private TableLayoutPanel tableLayoutPanel3;

		private System.Windows.Forms.Button btnOK;

		private System.Windows.Forms.Button btnCancel;

		public TextFormFieldDialog(TextFormField field)
		{
			this.InitializeComponent();
			this.m_field = field;
			this.emptyWidthControl.Value = field.EmptyWidth;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			this.m_field.EmptyWidth = this.emptyWidthControl.Value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TX_Text_Control_Words.FormFields.TextFormFieldDialog));
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.emptyWidthControl = new TX_Text_Control_Words.FormFields.EmptyWidthControl();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			base.SuspendLayout();
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.emptyWidthControl, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
			this.tableLayoutPanel3.Controls.Add(this.btnOK, 1, 0);
			this.tableLayoutPanel3.Controls.Add(this.btnCancel, 2, 0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			resources.ApplyResources(this.btnOK, "btnOK");
			this.btnOK.Name = "btnOK";
			this.btnOK.Tag = "Confirm the action.";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(btnOK_Click);
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Tag = "Abort the action.";
			this.btnCancel.UseVisualStyleBackColor = true;
			resources.ApplyResources(this.emptyWidthControl, "emptyWidthControl");
			this.emptyWidthControl.Name = "emptyWidthControl";
			this.emptyWidthControl.Value = 102;
			base.AcceptButton = this.btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			resources.ApplyResources(this, "$this");
			base.CancelButton = this.btnCancel;
			base.Controls.Add(this.tableLayoutPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "TextFormFieldDialog";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
