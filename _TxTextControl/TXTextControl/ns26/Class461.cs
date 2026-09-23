using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;
using TXTextControl;
using TXTextControl.Windows.Forms;

namespace ns26
{
	internal class Class461 : Row
	{
		private bool bool_0;

		private bool bool_1;

		private Label label_0;

		private Label label_1;

		private ComboBox comboBox_0;

		private ComboBox comboBox_1;

		private ComboBox comboBox_2;

		private System.Windows.Forms.Button button_0;

		private System.Windows.Forms.Button button_1;

		[CompilerGenerated]
		private Instruction instruction_0;

		internal Instruction Instruction_0
		{
			[CompilerGenerated]
			get
			{
				return this.instruction_0;
			}
			[CompilerGenerated]
			set
			{
				this.instruction_0 = value;
			}
		}

		internal ComboBox ComboBox_0 => this.comboBox_1;

		internal override bool IsFirstRow
		{
			get
			{
				return base.m_bIsFirstRow;
			}
			set
			{
				if (base.m_bIsFirstRow != (base.m_bIsFirstRow = value))
				{
					Label label = this.label_0;
					bool visible = (this.label_1.Visible = base.m_bIsFirstRow);
					label.Visible = visible;
				}
			}
		}

		internal Class461(Class457 class457_0, Instruction instruction_1)
			: base(class457_0)
		{
			if ((this.Instruction_0 = instruction_1) == null)
			{
				this.Instruction_0 = new Instruction();
			}
			this.method_1();
			this.method_2();
			if (this.Instruction_0.Commands_0 == Commands.SetNewItems)
			{
				this.method_5(this.Instruction_0.String_0);
			}
			this.method_6(base.CurrentFormField.String_1);
			this.method_7();
			this.method_10();
		}

		protected override void InitializeComponents()
		{
			base.RowCount = 2;
			base.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
			base.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
			base.ColumnCount = 7;
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 0f));
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 0f));
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 0f));
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			base.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 0f));
			base.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 0f));
			base.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 0f));
			this.label_0 = new Label();
			this.label_1 = new Label();
			this.comboBox_0 = new ComboBox();
			this.comboBox_1 = new ComboBox();
			this.comboBox_2 = new ComboBox();
			this.button_0 = new System.Windows.Forms.Button();
			this.button_1 = new System.Windows.Forms.Button();
			base.m_btnAddNewRow = new System.Windows.Forms.Button();
			base.m_btnRemoveRow = new System.Windows.Forms.Button();
			this.label_0.AutoSize = true;
			this.label_0.Dock = DockStyle.Top;
			this.label_0.Text = base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_LBL_ROW_INSTRUCTIONFORMFIELD");
			this.label_1.AutoSize = true;
			this.label_1.Dock = DockStyle.Top;
			this.label_1.Text = base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_LBL_ROW_INSTRUCTIONTYPE");
			this.comboBox_0.Dock = DockStyle.Top;
			this.comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_1.Dock = DockStyle.Top;
			this.comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_2.Dock = DockStyle.Top;
			this.comboBox_2.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_2.Visible = false;
			this.button_0.AutoSize = true;
			this.button_0.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.button_0.Dock = DockStyle.Left;
			this.button_0.Text = base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_BTN_ROW_INSTRUCTION_SPECIFYITEMS");
			this.button_0.Visible = false;
			this.button_1.AutoSize = true;
			this.button_1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.button_1.Enabled = false;
			this.button_1.ImageAlign = ContentAlignment.MiddleCenter;
			base.m_btnAddNewRow.AutoSize = true;
			base.m_btnAddNewRow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			base.m_btnAddNewRow.Enabled = false;
			base.m_btnAddNewRow.ImageAlign = ContentAlignment.MiddleCenter;
			base.m_btnRemoveRow.AutoSize = true;
			base.m_btnRemoveRow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			base.m_btnRemoveRow.Enabled = false;
			base.m_btnRemoveRow.ImageAlign = ContentAlignment.MiddleCenter;
			base.Controls.Add(this.label_0, 0, 0);
			base.Controls.Add(this.label_1, 1, 0);
			base.Controls.Add(this.comboBox_0, 0, 1);
			base.Controls.Add(this.comboBox_1, 1, 1);
			base.Controls.Add(this.comboBox_2, 2, 1);
			base.Controls.Add(this.button_1, 4, 1);
			base.Controls.Add(base.m_btnAddNewRow, 5, 1);
			base.Controls.Add(base.m_btnRemoveRow, 6, 1);
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			base.OnHandleCreated(eventArgs_0);
			this.comboBox_0.SelectionChangeCommitted += comboBox_0_SelectionChangeCommitted;
			this.comboBox_1.SelectionChangeCommitted += comboBox_1_SelectionChangeCommitted;
			this.comboBox_2.Enter += comboBox_2_Enter;
			this.comboBox_2.TextChanged += comboBox_2_TextChanged;
			this.comboBox_2.Leave += comboBox_2_Leave;
			this.button_0.Click += button_0_Click;
			this.button_1.Click += button_1_Click;
		}

		private void button_1_Click(object sender, EventArgs e)
		{
			InstructionSettingsDialog instructionSettingsDialog = new InstructionSettingsDialog(this);
			instructionSettingsDialog.Owner = (base.m_gvParent as Class459).TextControl_0.FindForm();
			instructionSettingsDialog.ShowDialog();
		}

		internal override void AwareOfDpi(PointF newDpi)
		{
			base.AwareOfDpi(newDpi);
			this.method_11(newDpi);
			this.button_1.Image = ResourceProvider.GetSmallIcon(ResourceProvider.GeneralItem.TXITEM_AdvancedSettings.ToString(), newDpi.X);
			base.m_btnAddNewRow.Image = ResourceProvider.GetSmallIcon(ResourceProvider.GeneralItem.TXITEM_Add.ToString(), newDpi.X);
			base.m_btnRemoveRow.Image = ResourceProvider.GetSmallIcon(ResourceProvider.GeneralItem.TXITEM_Remove.ToString(), newDpi.X);
			base.ColumnStyles[0].Width = Class517.smethod_45(Class519.Class551.Int32_0, base.m_pntDpi.X);
			this.comboBox_0.MinimumSize = new Size((int)base.ColumnStyles[0].Width - this.comboBox_0.Margin.Horizontal, 0);
			base.UpdateFormFieldNames(this.comboBox_0, base.ColumnStyles[0].Width - (float)(SystemInformation.VerticalScrollBarWidth + this.comboBox_0.Margin.Horizontal));
			base.ColumnStyles[1].Width = base.GetMaxWidth(0, this.comboBox_1.Margin.Horizontal, this.label_1, this.comboBox_1.Font, "ID_CONDITIONALINSTRUCTION_LBL_ROW_INSTRUCTIONTYPE_ALLOWFILLIN", "ID_CONDITIONALINSTRUCTION_LBL_ROW_INSTRUCTIONTYPE_DENYFILLIN", "ID_CONDITIONALINSTRUCTION_LBL_ROW_INSTRUCTIONTYPE_SETNEWVALUE", "ID_CONDITIONALINSTRUCTION_LBL_ROW_INSTRUCTIONTYPE_SETNEWITEMS", "ID_CONDITIONALINSTRUCTION_LBL_ROW_INSTRUCTIONTYPE_SETVALUEASVALID", "ID_CONDITIONALINSTRUCTION_LBL_ROW_INSTRUCTIONTYPE_SETVALUEASINVALID");
			float val = base.GetMaxWidth(0, this.comboBox_2.Margin.Horizontal, null, this.comboBox_2.Font, "ID_CONDITIONALINSTRUCTION_CBX_ROW_INSTRUCTION_EMPTYVALUE") + (float)this.comboBox_2.Margin.Horizontal;
			int num = this.button_0.PreferredSize.Width + this.button_0.Margin.Horizontal;
			base.ColumnStyles[2].Width = Math.Max(val, num);
			this.method_10();
		}

		private void comboBox_0_SelectionChangeCommitted(object sender, EventArgs e)
		{
			FormFieldItem currentFormField = base.CurrentFormField;
			base.CurrentFormField = this.comboBox_0.SelectedItem as FormFieldItem;
			if (base.CurrentFormField != currentFormField)
			{
				if (base.CurrentFormField != null)
				{
					((IConditionalInstructionElement)this.Instruction_0).RelatedFormField.FormField_0 = base.CurrentFormField.FormField_0;
					this.Instruction_0.String_0 = null;
					this.Instruction_0.Commands_0 = Commands.Undefined;
					this.Instruction_0.ValueTypes_0 = ValueTypes.Undefined;
					this.method_2();
					this.method_6(base.CurrentFormField.String_1);
				}
				this.method_10();
				if (currentFormField != base.CurrentFormField)
				{
					base.OnPropertyChanged("CurrentFormField");
				}
			}
		}

		private void comboBox_1_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (!this.bool_0 && this.comboBox_1.SelectedItem != null)
			{
				this.Instruction_0.String_0 = null;
				this.Instruction_0.ValueTypes_0 = ValueTypes.Undefined;
				this.bool_0 = true;
				this.Instruction_0.Commands_0 = (Commands)(this.comboBox_1.SelectedItem as Class464).Object_0;
				(base.m_gvParent as Class459).method_11();
				foreach (Class461 item in base.m_gvParent.List_1)
				{
					if (item != this)
					{
						item.method_3();
					}
				}
				this.method_6(base.CurrentFormField.String_1);
				this.method_0();
			}
			this.method_10();
			this.bool_0 = false;
		}

		private void comboBox_2_SelectedValueChanged(object sender, EventArgs e)
		{
			Class464 @class = this.comboBox_2.SelectedItem as Class464;
			if (@class != null)
			{
				this.Instruction_0.ValueTypes_0 = (ValueTypes)@class.Object_0;
				this.Instruction_0.String_0 = ((((IConditionalInstructionElement)this.Instruction_0).RelatedFormField.FormField_0 is CheckFormField || this.Instruction_0.ValueTypes_0 == ValueTypes.EmptyValue) ? null : new string[1] { @class.ToString() });
			}
			else
			{
				this.Instruction_0.String_0 = null;
				this.Instruction_0.ValueTypes_0 = ValueTypes.Undefined;
			}
			this.method_10();
		}

		private void comboBox_2_Enter(object sender, EventArgs e)
		{
			if (((IConditionalInstructionElement)this.Instruction_0).RelatedFormField.FormFieldType_0 == FormFieldType.DateFormField && this.Instruction_0.ValueTypes_0 != ValueTypes.EmptyValue && !this.method_9())
			{
				this.bool_1 = true;
				this.comboBox_2.ResetText();
				this.bool_1 = false;
				this.comboBox_2.ForeColor = SystemColors.WindowText;
			}
		}

		private void comboBox_2_TextChanged(object sender, EventArgs e)
		{
			if (!this.bool_1)
			{
				Class464 @class = this.comboBox_2.SelectedItem as Class464;
				if (@class != null)
				{
					this.Instruction_0.ValueTypes_0 = (ValueTypes)@class.Object_0;
					this.Instruction_0.String_0 = ((((IConditionalInstructionElement)this.Instruction_0).RelatedFormField.FormField_0 is CheckFormField || this.Instruction_0.ValueTypes_0 == ValueTypes.EmptyValue) ? null : new string[1] { @class.ToString() });
				}
				else if (((IConditionalInstructionElement)this.Instruction_0).RelatedFormField.FormFieldType_0 == FormFieldType.DateFormField)
				{
					this.method_9();
				}
				else if (this.comboBox_2.Text.Length > 0)
				{
					this.Instruction_0.String_0 = new string[1] { this.comboBox_2.Text };
					this.Instruction_0.ValueTypes_0 = ValueTypes.CustomValue;
				}
				else
				{
					this.Instruction_0.String_0 = null;
					this.Instruction_0.ValueTypes_0 = ValueTypes.Undefined;
				}
				this.method_10();
			}
		}

		private void comboBox_2_Leave(object sender, EventArgs e)
		{
			if (((IConditionalInstructionElement)this.Instruction_0).RelatedFormField.FormFieldType_0 == FormFieldType.DateFormField && this.Instruction_0.ValueTypes_0 != ValueTypes.EmptyValue && !this.method_9())
			{
				this.method_8();
			}
			this.method_10();
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			NewItemsDialog newItemsDialog = new NewItemsDialog(base.CurrentFormField.String_1, (base.m_gvParent as Class459).TextControl_0);
			if (newItemsDialog.ShowDialog() == DialogResult.OK)
			{
				this.Instruction_0.String_0 = newItemsDialog.String_0;
				this.Instruction_0.ValueTypes_0 = ((this.Instruction_0.String_0.Length == 0) ? ValueTypes.EmptyValue : ValueTypes.CustomValue);
				this.method_5(this.Instruction_0.String_0);
			}
		}

		private void method_0()
		{
			this.Instruction_0.IsInitialInstruction = true;
			this.Instruction_0.IsFormFieldChangeInstruction = true;
			switch (this.Instruction_0.Commands_0)
			{
			default:
				this.Instruction_0.IsElseInstructionEnabled = false;
				break;
			case Commands.AllowFillIn:
			case Commands.DenyFillIn:
			case Commands.SetValueAsValid:
			case Commands.SetValueAsInvalid:
				this.Instruction_0.IsElseInstructionEnabled = true;
				break;
			}
			this.Instruction_0.method_5();
		}

		private void method_1()
		{
			this.comboBox_0.SuspendLayout();
			this.comboBox_0.Items.Clear();
			this.comboBox_0.Items.AddRange(base.m_gvParent.List_0.ToArray());
			if (this.comboBox_0.Items.Count > 0)
			{
				if (((IConditionalInstructionElement)this.Instruction_0).RelatedFormField.FormField_0 == null)
				{
					FormFieldItem formFieldItem2 = (FormFieldItem)(this.comboBox_0.SelectedItem = (base.CurrentFormField = base.m_gvParent.List_0[0]));
					((IConditionalInstructionElement)this.Instruction_0).RelatedFormField.FormField_0 = base.CurrentFormField.FormField_0;
				}
				else
				{
					foreach (FormFieldItem item in this.comboBox_0.Items)
					{
						if (item.Int32_0 == ((IConditionalInstructionElement)this.Instruction_0).RelatedFormField.Int32_0)
						{
							this.comboBox_0.SelectedItem = item;
							base.CurrentFormField = item;
							break;
						}
					}
				}
			}
			this.comboBox_0.ResumeLayout(performLayout: false);
		}

		private void method_2()
		{
			this.bool_0 = true;
			(base.m_gvParent as Class459).method_11();
			this.comboBox_1.Enabled = !base.CurrentFormField.Boolean_0;
			this.method_3();
			foreach (Class461 item in base.m_gvParent.List_1)
			{
				if (item != this)
				{
					item.method_3();
				}
			}
			this.bool_0 = false;
		}

		internal void method_3()
		{
			this.bool_0 = true;
			this.comboBox_1.Items.Clear();
			List<Class464> list = this.method_4();
			int selectedIndex = -1;
			foreach (Class464 item in list)
			{
				this.comboBox_1.Items.Add(item);
				if (this.Instruction_0.Commands_0 == (Commands)item.Object_0)
				{
					selectedIndex = this.comboBox_1.Items.Count - 1;
				}
			}
			this.comboBox_1.SelectedIndex = selectedIndex;
			this.bool_0 = false;
		}

		private List<Class464> method_4()
		{
			List<Commands> list = ((((IConditionalInstructionElement)this.Instruction_0).RelatedFormField.FormFieldType_0 == FormFieldType.ComboBoxFormField || ((IConditionalInstructionElement)this.Instruction_0).RelatedFormField.FormFieldType_0 == FormFieldType.DropDownListFormField) ? new List<Commands>(new Commands[6]
			{
				Commands.AllowFillIn,
				Commands.DenyFillIn,
				Commands.SetNewValue,
				Commands.SetValueAsValid,
				Commands.SetValueAsInvalid,
				Commands.SetNewItems
			}) : new List<Commands>(new Commands[5]
			{
				Commands.AllowFillIn,
				Commands.DenyFillIn,
				Commands.SetNewValue,
				Commands.SetValueAsValid,
				Commands.SetValueAsInvalid
			}));
			List<Class464> list2 = new List<Class464>();
			foreach (Commands item in list)
			{
				switch (item)
				{
				case Commands.AllowFillIn:
				case Commands.DenyFillIn:
					if ((!base.CurrentFormField.Boolean_1 && !base.CurrentFormField.Boolean_2) || this.Instruction_0.Commands_0 == Commands.AllowFillIn || this.Instruction_0.Commands_0 == Commands.DenyFillIn)
					{
						list2.Add(new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_LBL_ROW_INSTRUCTIONTYPE_" + item.ToString().ToUpper()), item));
					}
					break;
				case Commands.SetNewValue:
					if (!base.CurrentFormField.Boolean_3 || this.Instruction_0.Commands_0 == Commands.SetNewValue)
					{
						list2.Add(new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_LBL_ROW_INSTRUCTIONTYPE_SETNEWVALUE"), Commands.SetNewValue));
					}
					break;
				case Commands.SetNewItems:
					if (!base.CurrentFormField.Boolean_6 || this.Instruction_0.Commands_0 == Commands.SetNewItems)
					{
						list2.Add(new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_LBL_ROW_INSTRUCTIONTYPE_SETNEWITEMS"), Commands.SetNewItems));
					}
					break;
				case Commands.SetValueAsValid:
				case Commands.SetValueAsInvalid:
					if ((!base.CurrentFormField.Boolean_4 && !base.CurrentFormField.Boolean_5) || this.Instruction_0.Commands_0 == Commands.SetValueAsValid || this.Instruction_0.Commands_0 == Commands.SetValueAsInvalid)
					{
						list2.Add(new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_LBL_ROW_INSTRUCTIONTYPE_" + item.ToString().ToUpper()), item));
					}
					break;
				}
			}
			return list2;
		}

		private void method_5(string[] string_0)
		{
			base.CurrentFormField.String_1 = string_0;
			foreach (Class461 item in base.m_gvParent.List_1)
			{
				if (item.CurrentFormField == base.CurrentFormField && item.Instruction_0.Commands_0 == Commands.SetNewValue)
				{
					item.method_6(item.CurrentFormField.String_1);
					item.method_7();
					break;
				}
			}
		}

		internal void method_6(string[] string_0)
		{
			base.SuspendLayout();
			this.bool_1 = true;
			this.comboBox_2.ResetText();
			this.bool_1 = false;
			this.comboBox_2.Items.Clear();
			if (this.Instruction_0.Commands_0 == Commands.SetNewItems)
			{
				if (base.Controls.Contains(this.comboBox_2))
				{
					base.Controls.Remove(this.comboBox_2);
				}
				if (!base.Controls.Contains(this.button_0))
				{
					base.Controls.Add(this.button_0, 2, 1);
				}
			}
			else if (!base.Controls.Contains(this.comboBox_2))
			{
				if (base.Controls.Contains(this.button_0))
				{
					base.Controls.Remove(this.button_0);
				}
				base.Controls.Add(this.comboBox_2, 2, 1);
			}
			switch (this.Instruction_0.Commands_0)
			{
			default:
				switch (this.Instruction_0.Commands_0)
				{
				case Commands.SetNewValue:
				{
					this.button_0.Visible = false;
					this.comboBox_2.Visible = true;
					this.comboBox_2.SelectedValueChanged -= comboBox_2_SelectedValueChanged;
					ComboBoxStyle comboBoxStyle2 = (this.comboBox_2.DropDownStyle = ((((IConditionalInstructionElement)this.Instruction_0).RelatedFormField.FormFieldType_0 == FormFieldType.DropDownListFormField || ((IConditionalInstructionElement)this.Instruction_0).RelatedFormField.FormFieldType_0 == FormFieldType.ComboBoxFormField || ((IConditionalInstructionElement)this.Instruction_0).RelatedFormField.FormFieldType_0 == FormFieldType.TextFormField || ((IConditionalInstructionElement)this.Instruction_0).RelatedFormField.FormFieldType_0 == FormFieldType.DateFormField) ? ComboBoxStyle.DropDown : ComboBoxStyle.DropDownList));
					if (comboBoxStyle2 == ComboBoxStyle.DropDownList)
					{
						this.comboBox_2.SelectedValueChanged += comboBox_2_SelectedValueChanged;
					}
					switch (((IConditionalInstructionElement)this.Instruction_0).RelatedFormField.FormFieldType_0)
					{
					case FormFieldType.CheckBoxFormField:
						this.comboBox_2.Items.Add(new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_INSTRUCTION_CHECKED"), ValueTypes.Checked));
						this.comboBox_2.Items.Add(new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_INSTRUCTION_UNCHECKED"), ValueTypes.Unchecked));
						break;
					case FormFieldType.DropDownListFormField:
					case FormFieldType.ComboBoxFormField:
						_ = this.comboBox_2.Font;
						foreach (string string_ in string_0)
						{
							this.comboBox_2.Items.Add(new Class464(string_, ValueTypes.CustomValue));
						}
						this.comboBox_2.Items.Add(new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_INSTRUCTION_EMPTYVALUE"), ValueTypes.EmptyValue));
						break;
					case FormFieldType.TextFormField:
					case FormFieldType.DateFormField:
						this.comboBox_2.Items.Add(new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_INSTRUCTION_EMPTYVALUE"), ValueTypes.EmptyValue));
						this.method_8();
						break;
					}
					break;
				}
				case Commands.SetNewItems:
				{
					Instruction instruction = this.Instruction_0;
					string[] array2 = (this.Instruction_0.String_0 = string_0);
					instruction.ValueTypes_0 = ((array2.Length == 0) ? ValueTypes.EmptyValue : ValueTypes.CustomValue);
					this.button_0.Visible = true;
					this.comboBox_2.Visible = false;
					break;
				}
				}
				break;
			case Commands.Undefined:
			case Commands.AllowFillIn:
			case Commands.DenyFillIn:
			case Commands.SetValueAsValid:
			case Commands.SetValueAsInvalid:
				this.button_0.Visible = false;
				this.comboBox_2.Visible = false;
				break;
			}
			base.ResumeLayout(performLayout: true);
		}

		internal void method_7()
		{
			this.comboBox_2.SelectedValueChanged -= comboBox_2_SelectedValueChanged;
			if (this.Instruction_0.Commands_0 == Commands.SetNewValue)
			{
				switch (((IConditionalInstructionElement)this.Instruction_0).RelatedFormField.FormFieldType_0)
				{
				case FormFieldType.CheckBoxFormField:
					switch (this.Instruction_0.ValueTypes_0)
					{
					default:
						this.comboBox_2.SelectedIndex = -1;
						break;
					case ValueTypes.Checked:
					case ValueTypes.Selected:
						this.comboBox_2.SelectedIndex = 0;
						break;
					case ValueTypes.Unchecked:
					case ValueTypes.Deselected:
						this.comboBox_2.SelectedIndex = 1;
						break;
					}
					break;
				case FormFieldType.TextFormField:
				case FormFieldType.DropDownListFormField:
				case FormFieldType.ComboBoxFormField:
				case FormFieldType.DateFormField:
					if (this.Instruction_0.ValueTypes_0 == ValueTypes.EmptyValue)
					{
						foreach (Class464 item in this.comboBox_2.Items)
						{
							if ((ValueTypes)item.Object_0 == ValueTypes.EmptyValue)
							{
								this.comboBox_2.SelectedItem = item;
								break;
							}
						}
					}
					else
					{
						this.method_8();
					}
					break;
				}
			}
			this.comboBox_2.SelectedValueChanged += comboBox_2_SelectedValueChanged;
		}

		private void method_8()
		{
			this.comboBox_2.ForeColor = SystemColors.WindowText;
			this.bool_1 = true;
			if (((IConditionalInstructionElement)this.Instruction_0).RelatedFormField.FormFieldType_0 == FormFieldType.DateFormField)
			{
				if (this.Instruction_0.ValueTypes_0 != ValueTypes.EmptyValue)
				{
					string s = ((this.Instruction_0.String_0 == null || this.Instruction_0.String_0.Length <= 0) ? "" : this.Instruction_0.String_0[0]);
					if (long.TryParse(s, out var result))
					{
						DateTime dateTime = new DateTime(result);
						this.comboBox_2.Text = dateTime.ToString("d", CultureInfo.CurrentUICulture);
					}
					else
					{
						this.comboBox_2.ForeColor = Color.Gray;
						this.comboBox_2.Text = "[" + CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern + "]";
					}
				}
				else
				{
					this.comboBox_2.SelectedIndex = 0;
				}
			}
			else
			{
				this.comboBox_2.Text = ((this.Instruction_0.String_0 == null || this.Instruction_0.String_0.Length <= 0) ? "" : this.Instruction_0.String_0[0]);
			}
			this.bool_1 = false;
		}

		private bool method_9()
		{
			bool flag = false;
			DateTime result = DateTime.Now;
			if (flag = DateTime.TryParse(this.comboBox_2.Text, CultureInfo.CurrentUICulture.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces, out result) && result.Year >= 1601 && result.Year <= 9999)
			{
				this.Instruction_0.String_0 = new string[1] { result.Ticks.ToString() };
				this.Instruction_0.ValueTypes_0 = ValueTypes.Date;
			}
			else
			{
				this.Instruction_0.String_0 = null;
				this.Instruction_0.ValueTypes_0 = ValueTypes.Undefined;
			}
			return flag;
		}

		private void method_10()
		{
			bool flag = false;
			switch (this.Instruction_0.Commands_0)
			{
			case Commands.SetNewValue:
				flag = ((((IConditionalInstructionElement)this.Instruction_0).RelatedFormField.FormFieldType_0 != FormFieldType.DateFormField) ? (this.comboBox_2.SelectedIndex >= 0 || this.comboBox_2.Text.Length > 0) : (this.comboBox_2.SelectedIndex == 0 || this.method_9()));
				break;
			case Commands.SetNewItems:
				flag = true;
				break;
			case Commands.AllowFillIn:
			case Commands.DenyFillIn:
			case Commands.SetValueAsValid:
			case Commands.SetValueAsInvalid:
				flag = true;
				break;
			}
			if (base.m_bIsValidRow != (base.m_bIsValidRow = flag))
			{
				this.button_1.Enabled = flag;
				base.OnPropertyChanged("IsValidCondition");
			}
		}

		private void method_11(PointF pointF_0)
		{
			Padding margin = Class517.smethod_51(new Padding(3, 0, 3, 0), pointF_0);
			Padding margin2 = Class517.smethod_51(new Padding(3, 3, 3, 7), pointF_0);
			this.label_0.Margin = margin2;
			this.label_1.Margin = margin2;
			this.comboBox_0.Margin = margin;
			this.comboBox_1.Margin = margin;
			this.comboBox_2.Margin = margin;
			this.button_0.Margin = margin;
			this.button_1.Margin = margin;
			base.m_btnAddNewRow.Margin = margin;
			base.m_btnRemoveRow.Margin = margin;
			this.button_1.Padding = new Padding(1, 1, 0, 0);
			base.m_btnAddNewRow.Padding = new Padding(1, 1, 0, 0);
			base.m_btnRemoveRow.Padding = new Padding(1, 1, 0, 0);
		}
	}
}
