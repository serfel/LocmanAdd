using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TX_Text_Control_Words
{
	public class InputBoxDialog : Form
	{
		private bool _bAllowEmptyString;

		private TextBox m_txtInput;

		private Button m_btnCancel;

		private Button m_btnOK;

		private Button m_btnFont;

		private TableLayoutPanel tableLayoutPanel1;

		private Container _components;

		public bool HasFontButton
		{
			get
			{
				return this.m_btnFont.Visible;
			}
			set
			{
				this.m_btnFont.Visible = value;
			}
		}

		public Font SelectedFont { get; set; }

		public string TextInput => this.m_txtInput.Text;

		public bool AllowEmptyString
		{
			get
			{
				return this._bAllowEmptyString;
			}
			set
			{
				this._bAllowEmptyString = value;
				if (this._bAllowEmptyString)
				{
					this.m_btnOK.Enabled = true;
				}
			}
		}

		public InputBoxDialog(string strCaption, string strText)
		{
			this.InitializeComponent();
			this.AllowEmptyString = false;
			this.SelectedFont = new Font("Calibri", 12f);
			this.Text = strCaption;
			this.m_txtInput.Text = strText;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this._components != null)
			{
				this._components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TX_Text_Control_Words.InputBoxDialog));
			this.m_txtInput = new System.Windows.Forms.TextBox();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_btnFont = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1.SuspendLayout();
			base.SuspendLayout();
			this.tableLayoutPanel1.SetColumnSpan(this.m_txtInput, 4);
			resources.ApplyResources(this.m_txtInput, "m_txtInput");
			this.m_txtInput.Name = "m_txtInput";
			this.m_txtInput.TextChanged += new System.EventHandler(TxtInput_TextChanged);
			resources.ApplyResources(this.m_btnCancel, "m_btnCancel");
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Click += new System.EventHandler(BtnCancel_Click);
			resources.ApplyResources(this.m_btnOK, "m_btnOK");
			this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Click += new System.EventHandler(BtnOK_Click);
			resources.ApplyResources(this.m_btnFont, "m_btnFont");
			this.m_btnFont.Name = "m_btnFont";
			this.m_btnFont.Click += new System.EventHandler(BtnFont_Click);
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.m_btnFont, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.m_txtInput, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.m_btnCancel, 3, 2);
			this.tableLayoutPanel1.Controls.Add(this.m_btnOK, 2, 2);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			base.AcceptButton = this.m_btnOK;
			resources.ApplyResources(this, "$this");
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			base.CancelButton = this.m_btnCancel;
			base.Controls.Add(this.tableLayoutPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "InputBoxDialog";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		public static bool ShowInputBox(string strCaption, ref string strInput, Form owner)
		{
			return InputBoxDialog.ShowInputBox(strCaption, ref strInput, owner, allowEmptyString: false);
		}

		public static bool ShowInputBox(string strCaption, ref string strInput, Form owner, bool allowEmptyString)
		{
			InputBoxDialog inputBoxDialog = new InputBoxDialog(strCaption, strInput);
			inputBoxDialog.RightToLeft = owner.RightToLeft;
			inputBoxDialog.AllowEmptyString = allowEmptyString;
			DialogResult dialogResult = inputBoxDialog.ShowDialog(owner);
			if (dialogResult == DialogResult.OK)
			{
				strInput = inputBoxDialog.m_txtInput.Text;
			}
			return dialogResult == DialogResult.OK;
		}

		private void BtnOK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		private void TxtInput_TextChanged(object sender, EventArgs e)
		{
			if (!this._bAllowEmptyString)
			{
				this.m_btnOK.Enabled = this.m_txtInput.Text.Length > 0;
			}
		}

		private void BtnFont_Click(object sender, EventArgs e)
		{
			FontDialog fontDialog = new FontDialog
			{
				Font = this.SelectedFont
			};
			if (fontDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.SelectedFont = fontDialog.Font;
			}
		}
	}
}
