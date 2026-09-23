using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using ns16;
using DocumentServer.Properties;
using DocumentServer.Windows.Forms;

namespace DocumentServer.Data.ConnectionUI
{
	[Obfuscation(Exclude = true)]
	internal class AddPropertyDialog : HighDpiForm
	{
		private DatabaseConnectionDialog databaseConnectionDialog_0;

		private IContainer icontainer_0;

		private Label propertyLabel;

		private TextBox propertyTextBox;

		private System.Windows.Forms.Button okButton;

		private System.Windows.Forms.Button cancelButton;

		private TableLayoutPanel tableLayoutPanel1;

		public string PropertyName => this.propertyTextBox.Text;

		public AddPropertyDialog()
		{
			this.InitializeComponent();
			if (this.icontainer_0 == null)
			{
				this.icontainer_0 = new Container();
			}
			this.icontainer_0.Add(new Class166(this));
			this.Text = Resources.ADDPROPERTY_DIALOG_TITLE;
			this.propertyLabel.Text = Resources.ADDPROPERTY_DIALOG_LABEL_PROPERTY;
			this.okButton.Text = Resources.ADDPROPERTY_DIALOG_BUTTON_OK;
			this.cancelButton.Text = Resources.ADDPROPERTY_DIALOG_BUTTON_CANCEL;
		}

		public AddPropertyDialog(DatabaseConnectionDialog mainDialog)
			: this()
		{
			this.databaseConnectionDialog_0 = mainDialog;
		}

		protected override void OnHelpRequested(HelpEventArgs hevent)
		{
			Control control = Class157.smethod_4(this);
			Enum29 enum29_ = Enum29.const_25;
			if (control == this.propertyTextBox)
			{
				enum29_ = Enum29.const_26;
			}
			if (control == this.okButton)
			{
				enum29_ = Enum29.const_27;
			}
			if (control == this.cancelButton)
			{
				enum29_ = Enum29.const_28;
			}
			EventArgs0 eventArgs = new EventArgs0(enum29_, hevent.MousePos);
			this.databaseConnectionDialog_0.method_7(eventArgs);
			hevent.Handled = eventArgs.Handled;
			if (!eventArgs.Handled)
			{
				base.OnHelpRequested(hevent);
			}
		}

		protected override void WndProc(ref Message message)
		{
			if (this.databaseConnectionDialog_0.Boolean_0 && Class157.smethod_0(ref message))
			{
				Class157.smethod_3(this, ref message);
			}
			base.WndProc(ref message);
		}

		private void propertyTextBox_TextChanged(object sender, EventArgs e)
		{
			this.okButton.Enabled = this.propertyTextBox.Text.Trim().Length > 0;
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
			System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(DocumentServer.Data.ConnectionUI.AddPropertyDialog));
			this.propertyLabel = new System.Windows.Forms.Label();
			this.propertyTextBox = new System.Windows.Forms.TextBox();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1.SuspendLayout();
			base.SuspendLayout();
			componentResourceManager.ApplyResources(this.propertyLabel, "propertyLabel");
			this.tableLayoutPanel1.SetColumnSpan(this.propertyLabel, 3);
			this.propertyLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.propertyLabel.Name = "propertyLabel";
			this.tableLayoutPanel1.SetColumnSpan(this.propertyTextBox, 3);
			componentResourceManager.ApplyResources(this.propertyTextBox, "propertyTextBox");
			this.propertyTextBox.Name = "propertyTextBox";
			this.propertyTextBox.TextChanged += new System.EventHandler(propertyTextBox_TextChanged);
			componentResourceManager.ApplyResources(this.okButton, "okButton");
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Name = "okButton";
			componentResourceManager.ApplyResources(this.cancelButton, "cancelButton");
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Name = "cancelButton";
			componentResourceManager.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.cancelButton, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.propertyLabel, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.propertyTextBox, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.okButton, 1, 2);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			base.AcceptButton = this.okButton;
			componentResourceManager.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.cancelButton;
			base.Controls.Add(this.tableLayoutPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.HelpButton = true;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "AddPropertyDialog";
			base.ShowInTaskbar = false;
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
