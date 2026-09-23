using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TXTextControl;

namespace TX_Text_Control_Words.FormFields
{
	public class CheckFormFieldDialog : Form
	{
		private CheckFormField m_field;

		private IContainer components;

		private ComboBox cbUncheckSymbol;

		private Label lblUncheckSymbol;

		private Label lblCheckSymbol;

		private ComboBox cbCheckSymbol;

		private System.Windows.Forms.Button btnCancel;

		private System.Windows.Forms.Button btnOK;

		private TableLayoutPanel tableLayoutPanel1;

		private TableLayoutPanel tableLayoutPanel2;

		public CheckFormFieldDialog(CheckFormField field)
		{
			this.InitializeComponent();
			this.m_field = field;
			this.cbCheckSymbol.Items.AddRange(new object[9] { '☒', '☑', '◉', '▣', '✔', '✓', '⚫', '◆', '➕' });
			this.cbUncheckSymbol.Items.AddRange(new object[9] { '☐', '⬜', '○', '✖', '✗', '⚪', '◇', '➖', '➕' });
			if (!this.cbCheckSymbol.Items.Contains(field.CheckedCharacter))
			{
				this.cbCheckSymbol.Items.Add(field.CheckedCharacter);
			}
			if (!this.cbUncheckSymbol.Items.Contains(field.UncheckedCharacter))
			{
				this.cbUncheckSymbol.Items.Add(field.UncheckedCharacter);
			}
			this.cbCheckSymbol.SelectedItem = field.CheckedCharacter;
			this.cbUncheckSymbol.SelectedItem = field.UncheckedCharacter;
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			this.m_field.UncheckedCharacter = this.cbUncheckSymbol.Text.First();
			this.m_field.CheckedCharacter = this.cbCheckSymbol.Text.First();
		}

		private void checkbox_TextChanged(object sender, EventArgs e)
		{
			this.btnOK.Enabled = this.IsDataValid();
		}

		private bool IsDataValid()
		{
			if (this.cbCheckSymbol.Text.Length == 1)
			{
				return this.cbUncheckSymbol.Text.Length == 1;
			}
			return false;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TX_Text_Control_Words.FormFields.CheckFormFieldDialog));
			this.cbUncheckSymbol = new System.Windows.Forms.ComboBox();
			this.lblUncheckSymbol = new System.Windows.Forms.Label();
			this.lblCheckSymbol = new System.Windows.Forms.Label();
			this.cbCheckSymbol = new System.Windows.Forms.ComboBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			base.SuspendLayout();
			resources.ApplyResources(this.cbUncheckSymbol, "cbUncheckSymbol");
			this.cbUncheckSymbol.FormattingEnabled = true;
			this.cbUncheckSymbol.Name = "cbUncheckSymbol";
			this.cbUncheckSymbol.TextChanged += new System.EventHandler(checkbox_TextChanged);
			resources.ApplyResources(this.lblUncheckSymbol, "lblUncheckSymbol");
			this.lblUncheckSymbol.Name = "lblUncheckSymbol";
			resources.ApplyResources(this.lblCheckSymbol, "lblCheckSymbol");
			this.lblCheckSymbol.Name = "lblCheckSymbol";
			resources.ApplyResources(this.cbCheckSymbol, "cbCheckSymbol");
			this.cbCheckSymbol.FormattingEnabled = true;
			this.cbCheckSymbol.Name = "cbCheckSymbol";
			this.cbCheckSymbol.TextChanged += new System.EventHandler(checkbox_TextChanged);
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Tag = "Abort the action.";
			this.btnCancel.UseVisualStyleBackColor = true;
			resources.ApplyResources(this.btnOK, "btnOK");
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Name = "btnOK";
			this.btnOK.Tag = "Confirm the action.";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(btnOK_Click);
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.lblCheckSymbol, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.lblUncheckSymbol, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.cbUncheckSymbol, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.cbCheckSymbol, 1, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
			this.tableLayoutPanel2.Controls.Add(this.btnOK, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnCancel, 1, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			base.AcceptButton = this.btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			base.CancelButton = this.btnCancel;
			resources.ApplyResources(this, "$this");
			base.Controls.Add(this.tableLayoutPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "CheckFormFieldDialog";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
