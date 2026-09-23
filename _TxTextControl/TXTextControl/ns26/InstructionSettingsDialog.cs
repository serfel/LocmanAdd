using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ns21;
using ns27;
using TXTextControl.Windows.Forms.Ribbon;
using TXTextControl;
using TXTextControl.Windows.Forms;

namespace ns26
{
	internal class InstructionSettingsDialog : Form
	{
		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private Class516 class516_0;

		private Class516 class516_1;

		private Class516 class516_2;

		private Class461 class461_0;

		private bool bool_0;

		private string[] string_0;

		private uint uint_0;

		private IContainer icontainer_0;

		private TableLayoutPanel m_tlpMainPanel;

		private System.Windows.Forms.Button m_btnOK;

		private System.Windows.Forms.Button m_btnCancel;

		private CheckBox m_chbxIsInitialInstruction;

		private ComboBox m_cmbxElseInstructionValue;

		private CheckBox m_chbxElseInstruction;

		private CheckBox m_chbxIsFormFieldChangeInstruction;

		private PictureBox m_pbxIsInitialinstruction;

		private TableLayoutPanel m_tlpIsInitialInstruction;

		private TableLayoutPanel m_tlpIsFormFieldChangeInstruction;

		private PictureBox m_pbxIsFormFieldChangeInstruction;

		private PictureBox m_pbxElseInstruction;

		private System.Windows.Forms.Button m_btnSpecifyItems;

		private TableLayoutPanel m_tlpElseInstructionValueControls;

		internal InstructionSettingsDialog(Class461 class461_1)
		{
			this.class461_0 = class461_1;
			this.InitializeComponent();
			this.Text = this.resourceManager_0.GetString("ID_INSTRUCTION_ADVANCED_SETTINGS_CAPTION");
			this.m_chbxIsInitialInstruction.Text = this.resourceManager_0.GetString("ID_INSTRUCTION_ADVANCED_SETTINGS_IS_INITIAL_INSTRUCTION");
			this.m_chbxIsFormFieldChangeInstruction.Text = this.resourceManager_0.GetString("ID_INSTRUCTION_ADVANCED_SETTINGS_HANDLE_FORM_FIELD_CHANGED");
			this.m_chbxElseInstruction.Text = ((this.class461_0.Instruction_0.Commands_0 != Commands.SetNewItems) ? this.resourceManager_0.GetString("ID_INSTRUCTION_ADVANCED_SETTINGS_ELSE_INSTRUCTION") : this.resourceManager_0.GetString("ID_INSTRUCTION_ADVANCED_SETTINGS_ELSE_INSTRUCTION_SETITEMS"));
			this.m_btnSpecifyItems.Text = this.resourceManager_0.GetString("ID_INSTRUCTION_ADVANCED_SETTINGS_ELSE_INSTRUCTION_BUTTON");
			this.m_btnOK.Text = this.resourceManager_0.GetString("ID_INSTRUCTION_ADVANCED_SETTINGS_ELSE_INSTRUCTION_OK");
			this.m_btnCancel.Text = this.resourceManager_0.GetString("ID_INSTRUCTION_ADVANCED_SETTINGS_ELSE_INSTRUCTION_CANCEL");
			this.m_chbxIsFormFieldChangeInstruction.Checked = class461_1.Instruction_0.IsFormFieldChangeInstruction;
			this.m_chbxIsInitialInstruction.Checked = class461_1.Instruction_0.IsInitialInstruction;
			this.m_chbxElseInstruction.Checked = (this.m_cmbxElseInstructionValue.Enabled = (this.m_btnSpecifyItems.Enabled = class461_1.Instruction_0.IsElseInstructionEnabled));
			this.method_2();
			this.m_cmbxElseInstructionValue.TextChanged += m_cmbxElseInstructionValue_TextChanged;
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			Graphics graphics = base.CreateGraphics();
			this.uint_0 = Class468.smethod_0(graphics, this);
			PointF pointF = ((this.uint_0 != 0) ? new PointF(this.uint_0, this.uint_0) : new PointF(graphics.DpiX, graphics.DpiY));
			if (this.class461_0.Instruction_0.Commands_0 != Commands.SetNewItems)
			{
				this.m_cmbxElseInstructionValue.MinimumSize = new Size((int)Row.GetPreferredComboBoxColumnWidth(this.m_cmbxElseInstructionValue, null, pointF, null), 0);
			}
			graphics.Dispose();
			PictureBox pbxIsInitialinstruction = this.m_pbxIsInitialinstruction;
			PictureBox pbxIsFormFieldChangeInstruction = this.m_pbxIsFormFieldChangeInstruction;
			System.Drawing.Image image2 = (this.m_pbxElseInstruction.Image = ResourceProvider.GetSmallIcon(ResourceProvider.FileMenuItem.TXITEM_About.ToString(), pointF.X));
			System.Drawing.Image image5 = (pbxIsInitialinstruction.Image = (pbxIsFormFieldChangeInstruction.Image = image2));
			this.class516_0 = new Class516(this.resourceManager_0.GetString("TOOLTIPTITLE_IS_INITIAL_INSTRUCTION"), this.resourceManager_0.GetString("TOOLTIP_IS_INITIAL_INSTRUCTION"), pointF, this.m_pbxIsInitialinstruction);
			this.class516_1 = new Class516(this.resourceManager_0.GetString("TOOLTIPTITLE_IS_FORM_FIELD_CHANGE_INSTRUCTION"), this.resourceManager_0.GetString("TOOLTIP_IS_FORM_FIELD_CHANGE_INSTRUCTION"), pointF, this.m_pbxIsFormFieldChangeInstruction);
			this.class516_2 = ((this.class461_0.Instruction_0.Commands_0 == Commands.SetNewItems) ? new Class516(this.resourceManager_0.GetString("TOOLTIPTITLE_IS_ELSE_INSTRUCTION_ITEMS"), this.resourceManager_0.GetString("TOOLTIP_IS_ELSE_INSTRUCTION_ITEMS"), pointF, this.m_pbxElseInstruction) : new Class516(this.resourceManager_0.GetString("TOOLTIPTITLE_IS_ELSE_INSTRUCTION"), this.resourceManager_0.GetString("TOOLTIP_IS_ELSE_INSTRUCTION"), pointF, this.m_pbxElseInstruction));
			Class429.Struct83 struct83_ = default(Class429.Struct83);
			Class429.GetWindowRect(base.Handle, ref struct83_);
			Class468.smethod_1(this.uint_0, struct83_, this);
			base.OnHandleCreated(eventArgs_0);
		}

		protected override void OnClosing(CancelEventArgs cancelEventArgs_0)
		{
			if (base.DialogResult == DialogResult.OK)
			{
				this.class461_0.Instruction_0.IsInitialInstruction = this.m_chbxIsInitialInstruction.Checked;
				this.class461_0.Instruction_0.IsFormFieldChangeInstruction = this.m_chbxIsFormFieldChangeInstruction.Checked;
				if (this.class461_0.Instruction_0.IsElseInstructionEnabled = this.m_chbxElseInstruction.Checked)
				{
					switch (this.class461_0.Instruction_0.Commands_0)
					{
					case Commands.SetNewValue:
						switch (((IConditionalInstructionElement)this.class461_0.Instruction_0).RelatedFormField.FormFieldType_0)
						{
						case FormFieldType.CheckBoxFormField:
							this.class461_0.Instruction_0.ElseInstructionValue = this.m_cmbxElseInstructionValue.SelectedIndex == 0;
							break;
						case FormFieldType.TextFormField:
						case FormFieldType.DropDownListFormField:
						case FormFieldType.ComboBoxFormField:
							this.class461_0.Instruction_0.ElseInstructionValue = ((this.m_cmbxElseInstructionValue.SelectedIndex == this.m_cmbxElseInstructionValue.Items.Count - 1) ? "" : this.m_cmbxElseInstructionValue.Text);
							break;
						case FormFieldType.DateFormField:
							if (this.m_cmbxElseInstructionValue.SelectedIndex == 0)
							{
								this.class461_0.Instruction_0.ElseInstructionValue = null;
							}
							else
							{
								this.class461_0.Instruction_0.ElseInstructionValue = this.method_0().Value;
							}
							break;
						}
						break;
					case Commands.SetNewItems:
						this.class461_0.Instruction_0.ElseInstructionValue = this.string_0;
						break;
					case Commands.AllowFillIn:
					case Commands.DenyFillIn:
					case Commands.SetValueAsValid:
					case Commands.SetValueAsInvalid:
						this.class461_0.Instruction_0.ElseInstructionValue = this.m_cmbxElseInstructionValue.SelectedIndex == 0;
						break;
					}
				}
				else
				{
					this.class461_0.Instruction_0.method_5();
				}
			}
			base.OnClosing(cancelEventArgs_0);
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
					PointF pointF_ = new PointF(this.uint_0, this.uint_0);
					PictureBox pbxIsInitialinstruction = this.m_pbxIsInitialinstruction;
					PictureBox pbxIsFormFieldChangeInstruction = this.m_pbxIsFormFieldChangeInstruction;
					System.Drawing.Image image2 = (this.m_pbxElseInstruction.Image = ResourceProvider.GetSmallIcon(ResourceProvider.FileMenuItem.TXITEM_About.ToString(), pointF_.X));
					System.Drawing.Image image5 = (pbxIsInitialinstruction.Image = (pbxIsFormFieldChangeInstruction.Image = image2));
					this.class516_0.method_1(pointF_);
					this.class516_1.method_1(pointF_);
					this.class516_2.method_1(pointF_);
				}
			}
			else
			{
				base.WndProc(ref message);
			}
		}

		private void m_pbxIsInitialinstruction_MouseHover(object sender, EventArgs e)
		{
			this.class516_0.method_2();
		}

		private void m_pbxIsFormFieldChangeInstruction_MouseHover(object sender, EventArgs e)
		{
			this.class516_1.method_2();
		}

		private void m_chbxElseInstruction_CheckedChanged(object sender, EventArgs e)
		{
			ComboBox cmbxElseInstructionValue = this.m_cmbxElseInstructionValue;
			bool enabled = (this.m_btnSpecifyItems.Enabled = this.m_chbxElseInstruction.Checked);
			cmbxElseInstructionValue.Enabled = enabled;
			this.m_btnOK.Enabled = this.class461_0.Instruction_0.Commands_0 == Commands.SetNewItems || !this.m_chbxElseInstruction.Checked || this.m_cmbxElseInstructionValue.Text.Length > 0;
		}

		private void m_cmbxElseInstructionValue_Enter(object sender, EventArgs e)
		{
			if (!this.method_0().HasValue)
			{
				this.bool_0 = true;
				this.m_cmbxElseInstructionValue.ResetText();
				this.bool_0 = false;
				this.m_cmbxElseInstructionValue.ForeColor = SystemColors.WindowText;
			}
		}

		private void m_cmbxElseInstructionValue_TextChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				if (((IConditionalInstructionElement)this.class461_0.Instruction_0).RelatedFormField.FormFieldType_0 == FormFieldType.DateFormField)
				{
					this.m_btnOK.Enabled = !this.m_chbxElseInstruction.Checked || this.m_cmbxElseInstructionValue.SelectedIndex >= 0 || this.method_0().HasValue;
				}
				else
				{
					this.m_btnOK.Enabled = this.class461_0.Instruction_0.Commands_0 == Commands.SetNewItems || !this.m_chbxElseInstruction.Checked || this.m_btnSpecifyItems.Visible || this.m_cmbxElseInstructionValue.Text.Length > 0;
				}
			}
		}

		private void m_cmbxElseInstructionValue_Leave(object sender, EventArgs e)
		{
			if (this.m_cmbxElseInstructionValue.SelectedIndex < 0 && !this.method_0().HasValue)
			{
				this.method_1(null);
			}
		}

		private void m_pbxElseInstruction_MouseHover(object sender, EventArgs e)
		{
			this.class516_2.method_2();
		}

		private void m_btnSpecifyItems_Click(object sender, EventArgs e)
		{
			NewItemsDialog newItemsDialog = new NewItemsDialog(this.string_0, (this.class461_0.m_gvParent as Class459).TextControl_0);
			if (newItemsDialog.ShowDialog() == DialogResult.OK)
			{
				this.string_0 = newItemsDialog.String_0;
			}
		}

		private DateTime? method_0()
		{
			DateTime result = DateTime.Now;
			if (DateTime.TryParse(this.m_cmbxElseInstructionValue.Text, CultureInfo.CurrentUICulture.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces, out result) && result.Year >= 1601 && result.Year <= 9999)
			{
				return result;
			}
			return null;
		}

		private void method_1(long? nullable_0)
		{
			this.m_cmbxElseInstructionValue.ForeColor = SystemColors.WindowText;
			if (nullable_0.HasValue)
			{
				DateTime dateTime = new DateTime(nullable_0.Value);
				this.m_cmbxElseInstructionValue.Text = dateTime.ToString("d", CultureInfo.CurrentUICulture);
			}
			else
			{
				this.m_cmbxElseInstructionValue.ForeColor = Color.Gray;
				this.m_cmbxElseInstructionValue.Text = "[" + CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern + "]";
			}
		}

		private void method_2()
		{
			switch (this.class461_0.Instruction_0.Commands_0)
			{
			case Commands.SetNewValue:
				switch (((IConditionalInstructionElement)this.class461_0.Instruction_0).RelatedFormField.FormFieldType_0)
				{
				case FormFieldType.CheckBoxFormField:
					this.m_cmbxElseInstructionValue.DropDownStyle = ComboBoxStyle.DropDownList;
					this.m_cmbxElseInstructionValue.Items.AddRange(new string[2]
					{
						this.resourceManager_0.GetString("ID_INSTRUCTION_ADVANCED_SETTINGS_ELSE_INSTRUCTION_CHECKED"),
						this.resourceManager_0.GetString("ID_INSTRUCTION_ADVANCED_SETTINGS_ELSE_INSTRUCTION_UNCHECKED")
					});
					if (this.class461_0.Instruction_0.IsElseInstructionEnabled)
					{
						this.m_cmbxElseInstructionValue.SelectedIndex = ((!(bool)this.class461_0.Instruction_0.ElseInstructionValue) ? 1 : 0);
					}
					break;
				case FormFieldType.TextFormField:
				case FormFieldType.DropDownListFormField:
				case FormFieldType.ComboBoxFormField:
					if (((IConditionalInstructionElement)this.class461_0.Instruction_0).RelatedFormField.FormFieldType_0 != FormFieldType.TextFormField)
					{
						this.m_cmbxElseInstructionValue.Items.AddRange((this.class461_0.Instruction_0.FormField as SelectionFormField).Items);
					}
					this.m_cmbxElseInstructionValue.Items.Add(this.resourceManager_0.GetString("ID_INSTRUCTION_ADVANCED_SETTINGS_ELSE_INSTRUCTION_EMPTYVALUE"));
					if (this.class461_0.Instruction_0.IsElseInstructionEnabled)
					{
						if (this.class461_0.Instruction_0.ElseInstructionValue.ToString().Length == 0)
						{
							this.m_cmbxElseInstructionValue.SelectedIndex = this.m_cmbxElseInstructionValue.Items.Count - 1;
						}
						else
						{
							this.m_cmbxElseInstructionValue.Text = this.class461_0.Instruction_0.ElseInstructionValue.ToString();
						}
					}
					break;
				case FormFieldType.DateFormField:
					this.m_cmbxElseInstructionValue.Items.Add(this.resourceManager_0.GetString("ID_INSTRUCTION_ADVANCED_SETTINGS_ELSE_INSTRUCTION_EMPTYVALUE"));
					if (this.class461_0.Instruction_0.IsElseInstructionEnabled)
					{
						if (this.class461_0.Instruction_0.ElseInstructionValue == null)
						{
							this.m_cmbxElseInstructionValue.SelectedIndex = 0;
						}
						else
						{
							this.method_1(((DateTime)this.class461_0.Instruction_0.ElseInstructionValue).Ticks);
						}
					}
					else
					{
						this.method_1(null);
					}
					this.m_cmbxElseInstructionValue.Enter += m_cmbxElseInstructionValue_Enter;
					this.m_cmbxElseInstructionValue.Leave += m_cmbxElseInstructionValue_Leave;
					break;
				}
				break;
			case Commands.SetNewItems:
			{
				string[] string_ = this.class461_0.CurrentFormField.String_1;
				if (this.class461_0.Instruction_0.IsElseInstructionEnabled)
				{
					this.string_0 = this.class461_0.Instruction_0.ElseInstructionValue as string[];
				}
				else
				{
					this.string_0 = ((string_.Length > 0) ? string_ : (this.class461_0.Instruction_0.FormField as SelectionFormField).Items);
				}
				this.m_cmbxElseInstructionValue.Visible = false;
				this.m_btnSpecifyItems.Visible = true;
				break;
			}
			case Commands.AllowFillIn:
			case Commands.DenyFillIn:
			case Commands.SetValueAsValid:
			case Commands.SetValueAsInvalid:
				switch (this.class461_0.Instruction_0.Commands_0)
				{
				case Commands.AllowFillIn:
				case Commands.DenyFillIn:
					this.m_cmbxElseInstructionValue.DropDownStyle = ComboBoxStyle.DropDownList;
					this.m_cmbxElseInstructionValue.Items.AddRange(new string[2]
					{
						this.resourceManager_0.GetString("ID_INSTRUCTION_ADVANCED_SETTINGS_ELSE_INSTRUCTION_ALLOWFILLIN"),
						this.resourceManager_0.GetString("ID_INSTRUCTION_ADVANCED_SETTINGS_ELSE_INSTRUCTION_DENYFILLIN")
					});
					break;
				case Commands.SetValueAsValid:
				case Commands.SetValueAsInvalid:
					this.m_cmbxElseInstructionValue.DropDownStyle = ComboBoxStyle.DropDownList;
					this.m_cmbxElseInstructionValue.Items.AddRange(new string[2]
					{
						this.resourceManager_0.GetString("ID_INSTRUCTION_ADVANCED_SETTINGS_ELSE_INSTRUCTION_SETVALUEASVALID"),
						this.resourceManager_0.GetString("ID_INSTRUCTION_ADVANCED_SETTINGS_ELSE_INSTRUCTION_SETVALUEASINVALID")
					});
					break;
				}
				if (this.class461_0.Instruction_0.IsElseInstructionEnabled)
				{
					this.m_cmbxElseInstructionValue.SelectedIndex = ((!(bool)this.class461_0.Instruction_0.ElseInstructionValue) ? 1 : 0);
				}
				break;
			}
			this.m_btnOK.Enabled = this.class461_0.Instruction_0.Commands_0 == Commands.SetNewItems || !this.m_chbxElseInstruction.Checked || this.m_cmbxElseInstructionValue.Text.Length > 0;
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
			this.m_tlpIsInitialInstruction = new System.Windows.Forms.TableLayoutPanel();
			this.m_chbxIsInitialInstruction = new System.Windows.Forms.CheckBox();
			this.m_pbxIsInitialinstruction = new System.Windows.Forms.PictureBox();
			this.m_tlpIsFormFieldChangeInstruction = new System.Windows.Forms.TableLayoutPanel();
			this.m_chbxIsFormFieldChangeInstruction = new System.Windows.Forms.CheckBox();
			this.m_pbxIsFormFieldChangeInstruction = new System.Windows.Forms.PictureBox();
			this.m_chbxElseInstruction = new System.Windows.Forms.CheckBox();
			this.m_tlpElseInstructionValueControls = new System.Windows.Forms.TableLayoutPanel();
			this.m_cmbxElseInstructionValue = new System.Windows.Forms.ComboBox();
			this.m_btnSpecifyItems = new System.Windows.Forms.Button();
			this.m_pbxElseInstruction = new System.Windows.Forms.PictureBox();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_tlpMainPanel.SuspendLayout();
			this.m_tlpIsInitialInstruction.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.m_pbxIsInitialinstruction).BeginInit();
			this.m_tlpIsFormFieldChangeInstruction.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.m_pbxIsFormFieldChangeInstruction).BeginInit();
			this.m_tlpElseInstructionValueControls.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.m_pbxElseInstruction).BeginInit();
			base.SuspendLayout();
			this.m_tlpMainPanel.AutoSize = true;
			this.m_tlpMainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_tlpMainPanel.ColumnCount = 3;
			this.m_tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpMainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpMainPanel.Controls.Add(this.m_tlpIsInitialInstruction, 0, 0);
			this.m_tlpMainPanel.Controls.Add(this.m_tlpIsFormFieldChangeInstruction, 0, 1);
			this.m_tlpMainPanel.Controls.Add(this.m_chbxElseInstruction, 0, 2);
			this.m_tlpMainPanel.Controls.Add(this.m_tlpElseInstructionValueControls, 0, 3);
			this.m_tlpMainPanel.Controls.Add(this.m_btnOK, 1, 4);
			this.m_tlpMainPanel.Controls.Add(this.m_btnCancel, 2, 4);
			this.m_tlpMainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_tlpMainPanel.Location = new System.Drawing.Point(7, 7);
			this.m_tlpMainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.m_tlpMainPanel.Name = "m_tlpMainPanel";
			this.m_tlpMainPanel.RowCount = 5;
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpMainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpMainPanel.Size = new System.Drawing.Size(264, 208);
			this.m_tlpMainPanel.TabIndex = 0;
			this.m_tlpIsInitialInstruction.AutoSize = true;
			this.m_tlpIsInitialInstruction.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_tlpIsInitialInstruction.ColumnCount = 3;
			this.m_tlpMainPanel.SetColumnSpan(this.m_tlpIsInitialInstruction, 3);
			this.m_tlpIsInitialInstruction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpIsInitialInstruction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpIsInitialInstruction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpIsInitialInstruction.Controls.Add(this.m_chbxIsInitialInstruction, 0, 0);
			this.m_tlpIsInitialInstruction.Controls.Add(this.m_pbxIsInitialinstruction, 1, 0);
			this.m_tlpIsInitialInstruction.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_tlpIsInitialInstruction.Location = new System.Drawing.Point(0, 2);
			this.m_tlpIsInitialInstruction.Margin = new System.Windows.Forms.Padding(0, 2, 5, 5);
			this.m_tlpIsInitialInstruction.Name = "m_tlpIsInitialInstruction";
			this.m_tlpIsInitialInstruction.RowCount = 1;
			this.m_tlpIsInitialInstruction.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpIsInitialInstruction.Size = new System.Drawing.Size(259, 50);
			this.m_tlpIsInitialInstruction.TabIndex = 0;
			this.m_chbxIsInitialInstruction.AutoSize = true;
			this.m_chbxIsInitialInstruction.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_chbxIsInitialInstruction.Location = new System.Drawing.Point(0, 1);
			this.m_chbxIsInitialInstruction.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.m_chbxIsInitialInstruction.Name = "m_chbxIsInitialInstruction";
			this.m_chbxIsInitialInstruction.Size = new System.Drawing.Size(111, 17);
			this.m_chbxIsInitialInstruction.TabIndex = 0;
			this.m_chbxIsInitialInstruction.Text = "&Is initial instruction\t";
			this.m_chbxIsInitialInstruction.UseVisualStyleBackColor = true;
			this.m_pbxIsInitialinstruction.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_pbxIsInitialinstruction.Location = new System.Drawing.Point(113, 0);
			this.m_pbxIsInitialinstruction.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
			this.m_pbxIsInitialinstruction.Name = "m_pbxIsInitialinstruction";
			this.m_pbxIsInitialinstruction.Size = new System.Drawing.Size(100, 50);
			this.m_pbxIsInitialinstruction.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.m_pbxIsInitialinstruction.TabIndex = 6;
			this.m_pbxIsInitialinstruction.TabStop = false;
			this.m_pbxIsInitialinstruction.MouseHover += new System.EventHandler(m_pbxIsInitialinstruction_MouseHover);
			this.m_tlpIsFormFieldChangeInstruction.AutoSize = true;
			this.m_tlpIsFormFieldChangeInstruction.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_tlpIsFormFieldChangeInstruction.ColumnCount = 3;
			this.m_tlpMainPanel.SetColumnSpan(this.m_tlpIsFormFieldChangeInstruction, 3);
			this.m_tlpIsFormFieldChangeInstruction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpIsFormFieldChangeInstruction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpIsFormFieldChangeInstruction.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpIsFormFieldChangeInstruction.Controls.Add(this.m_chbxIsFormFieldChangeInstruction, 0, 0);
			this.m_tlpIsFormFieldChangeInstruction.Controls.Add(this.m_pbxIsFormFieldChangeInstruction, 1, 0);
			this.m_tlpIsFormFieldChangeInstruction.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_tlpIsFormFieldChangeInstruction.Location = new System.Drawing.Point(0, 59);
			this.m_tlpIsFormFieldChangeInstruction.Margin = new System.Windows.Forms.Padding(0, 2, 5, 5);
			this.m_tlpIsFormFieldChangeInstruction.Name = "m_tlpIsFormFieldChangeInstruction";
			this.m_tlpIsFormFieldChangeInstruction.RowCount = 1;
			this.m_tlpIsFormFieldChangeInstruction.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpIsFormFieldChangeInstruction.Size = new System.Drawing.Size(259, 50);
			this.m_tlpIsFormFieldChangeInstruction.TabIndex = 0;
			this.m_chbxIsFormFieldChangeInstruction.AutoSize = true;
			this.m_chbxIsFormFieldChangeInstruction.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_chbxIsFormFieldChangeInstruction.Location = new System.Drawing.Point(0, 1);
			this.m_chbxIsFormFieldChangeInstruction.Margin = new System.Windows.Forms.Padding(0, 1, 0, 0);
			this.m_chbxIsFormFieldChangeInstruction.Name = "m_chbxIsFormFieldChangeInstruction";
			this.m_chbxIsFormFieldChangeInstruction.Size = new System.Drawing.Size(246, 17);
			this.m_chbxIsFormFieldChangeInstruction.TabIndex = 1;
			this.m_chbxIsFormFieldChangeInstruction.Text = "&Perform instruction on form field value changes";
			this.m_chbxIsFormFieldChangeInstruction.UseVisualStyleBackColor = true;
			this.m_pbxIsFormFieldChangeInstruction.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_pbxIsFormFieldChangeInstruction.Location = new System.Drawing.Point(248, 0);
			this.m_pbxIsFormFieldChangeInstruction.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
			this.m_pbxIsFormFieldChangeInstruction.Name = "m_pbxIsFormFieldChangeInstruction";
			this.m_pbxIsFormFieldChangeInstruction.Size = new System.Drawing.Size(100, 50);
			this.m_pbxIsFormFieldChangeInstruction.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.m_pbxIsFormFieldChangeInstruction.TabIndex = 6;
			this.m_pbxIsFormFieldChangeInstruction.TabStop = false;
			this.m_pbxIsFormFieldChangeInstruction.MouseHover += new System.EventHandler(m_pbxIsFormFieldChangeInstruction_MouseHover);
			this.m_chbxElseInstruction.AutoSize = true;
			this.m_tlpMainPanel.SetColumnSpan(this.m_chbxElseInstruction, 3);
			this.m_chbxElseInstruction.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_chbxElseInstruction.Location = new System.Drawing.Point(0, 117);
			this.m_chbxElseInstruction.Margin = new System.Windows.Forms.Padding(0, 3, 5, 0);
			this.m_chbxElseInstruction.Name = "m_chbxElseInstruction";
			this.m_chbxElseInstruction.Size = new System.Drawing.Size(259, 17);
			this.m_chbxElseInstruction.TabIndex = 2;
			this.m_chbxElseInstruction.Text = "In case the condition is not fulfilled, set the &value to:";
			this.m_chbxElseInstruction.UseVisualStyleBackColor = true;
			this.m_chbxElseInstruction.CheckedChanged += new System.EventHandler(m_chbxElseInstruction_CheckedChanged);
			this.m_tlpElseInstructionValueControls.AutoSize = true;
			this.m_tlpElseInstructionValueControls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_tlpElseInstructionValueControls.ColumnCount = 4;
			this.m_tlpMainPanel.SetColumnSpan(this.m_tlpElseInstructionValueControls, 3);
			this.m_tlpElseInstructionValueControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpElseInstructionValueControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpElseInstructionValueControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpElseInstructionValueControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpElseInstructionValueControls.Controls.Add(this.m_cmbxElseInstructionValue, 0, 0);
			this.m_tlpElseInstructionValueControls.Controls.Add(this.m_btnSpecifyItems, 1, 0);
			this.m_tlpElseInstructionValueControls.Controls.Add(this.m_pbxElseInstruction, 2, 0);
			this.m_tlpElseInstructionValueControls.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_tlpElseInstructionValueControls.Location = new System.Drawing.Point(18, 139);
			this.m_tlpElseInstructionValueControls.Margin = new System.Windows.Forms.Padding(18, 5, 5, 10);
			this.m_tlpElseInstructionValueControls.Name = "m_tlpElseInstructionValueControls";
			this.m_tlpElseInstructionValueControls.RowCount = 1;
			this.m_tlpElseInstructionValueControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpElseInstructionValueControls.Size = new System.Drawing.Size(241, 86);
			this.m_tlpElseInstructionValueControls.TabIndex = 10;
			this.m_cmbxElseInstructionValue.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_cmbxElseInstructionValue.FormattingEnabled = true;
			this.m_cmbxElseInstructionValue.Location = new System.Drawing.Point(2, 1);
			this.m_cmbxElseInstructionValue.Margin = new System.Windows.Forms.Padding(2, 1, 0, 0);
			this.m_cmbxElseInstructionValue.Name = "m_cmbxElseInstructionValue";
			this.m_cmbxElseInstructionValue.Size = new System.Drawing.Size(118, 21);
			this.m_cmbxElseInstructionValue.TabIndex = 3;
			this.m_btnSpecifyItems.AutoSize = true;
			this.m_btnSpecifyItems.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnSpecifyItems.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnSpecifyItems.Location = new System.Drawing.Point(122, 0);
			this.m_btnSpecifyItems.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
			this.m_btnSpecifyItems.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnSpecifyItems.Name = "m_btnSpecifyItems";
			this.m_btnSpecifyItems.Size = new System.Drawing.Size(117, 23);
			this.m_btnSpecifyItems.TabIndex = 4;
			this.m_btnSpecifyItems.Text = "&Specify items to set...";
			this.m_btnSpecifyItems.UseVisualStyleBackColor = true;
			this.m_btnSpecifyItems.Visible = false;
			this.m_btnSpecifyItems.Click += new System.EventHandler(m_btnSpecifyItems_Click);
			this.m_pbxElseInstruction.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_pbxElseInstruction.Location = new System.Drawing.Point(241, 2);
			this.m_pbxElseInstruction.Margin = new System.Windows.Forms.Padding(2, 2, 0, 0);
			this.m_pbxElseInstruction.Name = "m_pbxElseInstruction";
			this.m_pbxElseInstruction.Size = new System.Drawing.Size(10, 84);
			this.m_pbxElseInstruction.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.m_pbxElseInstruction.TabIndex = 9;
			this.m_pbxElseInstruction.TabStop = false;
			this.m_pbxElseInstruction.MouseHover += new System.EventHandler(m_pbxElseInstruction_MouseHover);
			this.m_btnOK.AutoSize = true;
			this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.m_btnOK.Enabled = false;
			this.m_btnOK.Location = new System.Drawing.Point(108, 238);
			this.m_btnOK.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.m_btnOK.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(75, 23);
			this.m_btnOK.TabIndex = 5;
			this.m_btnOK.Text = "OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnCancel.AutoSize = true;
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Location = new System.Drawing.Point(189, 238);
			this.m_btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
			this.m_btnCancel.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
			this.m_btnCancel.TabIndex = 6;
			this.m_btnCancel.Text = "Cancel";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			base.AcceptButton = this.m_btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.m_btnCancel;
			base.ClientSize = new System.Drawing.Size(278, 222);
			base.Controls.Add(this.m_tlpMainPanel);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Margin = new System.Windows.Forms.Padding(2);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "InstructionSettingsDialog";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Advanced Settings";
			this.m_tlpMainPanel.ResumeLayout(false);
			this.m_tlpMainPanel.PerformLayout();
			this.m_tlpIsInitialInstruction.ResumeLayout(false);
			this.m_tlpIsInitialInstruction.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.m_pbxIsInitialinstruction).EndInit();
			this.m_tlpIsFormFieldChangeInstruction.ResumeLayout(false);
			this.m_tlpIsFormFieldChangeInstruction.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.m_pbxIsFormFieldChangeInstruction).EndInit();
			this.m_tlpElseInstructionValueControls.ResumeLayout(false);
			this.m_tlpElseInstructionValueControls.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.m_pbxElseInstruction).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
