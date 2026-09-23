using System;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using ns21;
using ns22;

namespace TXTextControl
{
	/// <summary>An object of the Instruction class is an element of the ConditionalInstruction class and represents actions that are execute´d when the corresponding conditions are fulfilled.To specify such an instruction, the Instruction object has to be initialized with a FormField that is located inside the document.In this context, up to four different types of actions can be executed: Changing the FormField.Enabled property, marking the form field value as valid or invalid, setting a new value and replacing the SelectionFormField.Items array with another string array.To specify a value that is set by the specified action when the defined requirements of the ConditionalInstruction.Conditions array are fulfilled, the constructor's instructionValue parameter must be used.</summary>
	public class Instruction : IComparable, IConditionalInstructionElement
	{
		/// <summary>Determines the type of action to execute.</summary>
		public enum InstructionTypes
		{
			/// <summary>The instruction sets the FormField.Enabled property to true or false. This enumeration value is used in combination with an instruction value of type boolean that represents the new desired FormField.Enabled value.</summary>
			IsEnabled = 1,
			/// <summary>The instruction marks the form field value as valid or invalid. This enumeration value is used in combination with an instruction value of type boolean. To retrieve the result of an instruction with that instruction type, the ConditionalInstructionCollection.IsValueValid method is provided.</summary>
			IsValueValid,
			/// <summary>The instruction sets a new value to a FormField type specific property. If the related FormField is an object of type CheckFormField, the instruction type is used in combination with an instruction value of type boolean that represents the new desired CheckFormField.Checked property value. At form fields of type TextFormField and SelectionFormField, the Text property is updated with a string value. The corresponding property of date form fields is the DateFormField.Date property. To update that property, the Instruction.InstructionValue property needs a value of type System.DateTime.</summary>
			SetValue,
			/// <summary>The instruction replaces the SelectionFormField.Items array with the string array that is represented by Instruction.InstructionValue property.</summary>
			SetItems
		}

		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private bool bool_0;

		private object object_0;

		private InstructionTypes instructionTypes_0;

		private bool bool_1 = true;

		private bool bool_2 = true;

		private object object_1;

		private bool bool_3;

		[CompilerGenerated]
		private bool bool_4;

		[CompilerGenerated]
		private string[] string_0;

		[CompilerGenerated]
		private Commands commands_0;

		[CompilerGenerated]
		private ValueTypes valueTypes_0;

		[CompilerGenerated]
		private string string_1;

		[CompilerGenerated]
		private RelatedFormField relatedFormField_0;

		/// <summary>Gets the value that is set by the specified action when the defined requirements of the ConditionalInstruction.Conditions array are not fulfilled and the Instruction.IsElseInstructionEnabled property is set to true.</summary>
		public object ElseInstructionValue
		{
			get
			{
				return this.object_1;
			}
			internal set
			{
				this.object_1 = value;
			}
		}

		/// <summary>Gets or sets a value indicating whether this Instruction allows to execute else instructions.</summary>
		public bool IsElseInstructionEnabled
		{
			[CompilerGenerated]
			get
			{
				return this.bool_4;
			}
			[CompilerGenerated]
			set
			{
				this.bool_4 = value;
			}
		}

		/// <summary>Gets or sets a value indicating whether this Instruction listens to value changes of the related conditions' form fields.</summary>
		public bool IsFormFieldChangeInstruction
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				this.bool_2 = value;
			}
		}

		/// <summary>Gets or sets a value indicating whether this Instruction is handled when the document is initialized as a form.</summary>
		public bool IsInitialInstruction
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
			}
		}

		/// <summary>Gets the FormField to which the specified action is executed.</summary>
		public FormField FormField => ((IConditionalInstructionElement)this).RelatedFormField.FormField_0;

		/// <summary>Gets the value that is set by the specified action when the defined requirements of the ConditionalInstruction.Conditions array are fulfilled.</summary>
		public object InstructionValue
		{
			get
			{
				this.method_7();
				return this.object_0;
			}
		}

		/// <summary>Gets the type of action to execute.</summary>
		public InstructionTypes InstructionType
		{
			get
			{
				this.method_7();
				return this.instructionTypes_0;
			}
		}

		internal string[] String_0
		{
			[CompilerGenerated]
			get
			{
				return this.string_0;
			}
			[CompilerGenerated]
			set
			{
				this.string_0 = value;
			}
		}

		internal Commands Commands_0
		{
			[CompilerGenerated]
			get
			{
				return this.commands_0;
			}
			[CompilerGenerated]
			set
			{
				this.commands_0 = value;
			}
		}

		internal bool Boolean_0
		{
			get
			{
				switch (this.Commands_0)
				{
				default:
					return false;
				case Commands.SetNewValue:
					switch (this.ValueTypes_0)
					{
					case ValueTypes.Checked:
					case ValueTypes.Selected:
						return !(((IConditionalInstructionElement)this).RelatedFormField.FormField_0 as CheckFormField).Checked;
					case ValueTypes.Unchecked:
					case ValueTypes.Deselected:
						return (((IConditionalInstructionElement)this).RelatedFormField.FormField_0 as CheckFormField).Checked;
					case ValueTypes.EmptyValue:
						if (((IConditionalInstructionElement)this).RelatedFormField.FormFieldType_0 == FormFieldType.DateFormField)
						{
							return (((IConditionalInstructionElement)this).RelatedFormField.FormField_0 as DateFormField).Date.HasValue;
						}
						return !string.IsNullOrEmpty(((IConditionalInstructionElement)this).RelatedFormField.FormField_0.Text);
					default:
						return false;
					case ValueTypes.SpecificItem:
					case ValueTypes.CustomValue:
						return ((IConditionalInstructionElement)this).RelatedFormField.FormField_0.Text != this.String_0[0];
					case ValueTypes.Date:
					{
						if (((IConditionalInstructionElement)this).RelatedFormField.FormFieldType_0 == FormFieldType.DateFormField && this.String_0 != null && this.String_0.Length == 1 && long.TryParse(this.String_0[0], out var result))
						{
							DateTime dateTime = new DateTime(result);
							if (dateTime.Year >= 1601 && dateTime.Year <= 9999)
							{
								DateTime? date = (((IConditionalInstructionElement)this).RelatedFormField.FormField_0 as DateFormField).Date;
								if (!date.HasValue || date.Value.Year != dateTime.Year || date.Value.DayOfYear != dateTime.DayOfYear)
								{
									return true;
								}
							}
						}
						return false;
					}
					}
				case Commands.SetNewItems:
				{
					string[] items = (((IConditionalInstructionElement)this).RelatedFormField.FormField_0 as SelectionFormField).Items;
					if (items.Length != this.String_0.Length)
					{
						return true;
					}
					int num = 0;
					while (true)
					{
						if (num < items.Length)
						{
							if (items[num] != this.String_0[num])
							{
								break;
							}
							num++;
							continue;
						}
						return false;
					}
					return true;
				}
				case Commands.AllowFillIn:
				case Commands.DenyFillIn:
				case Commands.SetValueAsValid:
				case Commands.SetValueAsInvalid:
					return true;
				}
			}
		}

		internal ValueTypes ValueTypes_0
		{
			[CompilerGenerated]
			get
			{
				return this.valueTypes_0;
			}
			[CompilerGenerated]
			set
			{
				this.valueTypes_0 = value;
			}
		}

		string IConditionalInstructionElement.ConditionalInstructionName
		{
			[CompilerGenerated]
			get
			{
				return this.string_1;
			}
			[CompilerGenerated]
			set
			{
				this.string_1 = value;
			}
		}

		bool IConditionalInstructionElement.IsValid
		{
			get
			{
				if (Enum.IsDefined(typeof(Commands), this.Commands_0))
				{
					return Enum.IsDefined(typeof(ValueTypes), this.ValueTypes_0);
				}
				return false;
			}
		}

		RelatedFormField IConditionalInstructionElement.RelatedFormField
		{
			[CompilerGenerated]
			get
			{
				return this.relatedFormField_0;
			}
			[CompilerGenerated]
			set
			{
				this.relatedFormField_0 = value;
			}
		}

		object[] IConditionalInstructionElement.StringElements
		{
			get
			{
				string text = "";
				string text2 = "";
				if (((IConditionalInstructionElement)this).IsValid)
				{
					string text3 = "ID_CONDITIONALINSTRUCTIONS_INSTRUCTIONS_" + (this.Commands_0.ToString() + "_" + ((IConditionalInstructionElement)this).RelatedFormField.FormFieldType_0).ToUpper();
					switch (this.Commands_0)
					{
					default:
					{
						bool flag = this.ValueTypes_0 == ValueTypes.SpecificItem || this.ValueTypes_0 == ValueTypes.CustomValue || this.ValueTypes_0 == ValueTypes.Date;
						text3 = text3 + "_" + this.ValueTypes_0.ToString().ToUpper();
						if (flag)
						{
							text = this.resourceManager_0.GetString(text3);
							text2 = this.method_3(text3, this.String_0);
						}
						else
						{
							text = this.resourceManager_0.GetString(text3 + "_START");
							text2 = this.resourceManager_0.GetString(text3 + "_END");
						}
						break;
					}
					case Commands.AllowFillIn:
					case Commands.DenyFillIn:
					case Commands.SetValueAsValid:
					case Commands.SetValueAsInvalid:
						text = this.resourceManager_0.GetString(text3 + "_START");
						text2 = this.resourceManager_0.GetString(text3 + "_END");
						break;
					}
					if (this.IsElseInstructionEnabled)
					{
						string text4 = "_ELSE_";
						switch (this.Commands_0)
						{
						case Commands.AllowFillIn:
						case Commands.DenyFillIn:
							text4 = ((!(bool)this.ElseInstructionValue) ? (text4 + Commands.DenyFillIn.ToString().ToUpper()) : (text4 + Commands.AllowFillIn.ToString().ToUpper()));
							text2 += this.resourceManager_0.GetString(text3 + text4);
							break;
						case Commands.SetNewValue:
							switch (this.ValueTypes_0)
							{
							case ValueTypes.Checked:
							case ValueTypes.Unchecked:
								text4 = ((!(bool)this.ElseInstructionValue) ? (text4 + ValueTypes.Unchecked.ToString().ToUpper()) : (text4 + ValueTypes.Checked.ToString().ToUpper()));
								text2 += this.resourceManager_0.GetString(text3 + text4);
								break;
							case ValueTypes.EmptyValue:
							case ValueTypes.CustomValue:
							case ValueTypes.Date:
								switch (((IConditionalInstructionElement)this).RelatedFormField.FormFieldType_0)
								{
								case FormFieldType.TextFormField:
								case FormFieldType.DropDownListFormField:
								case FormFieldType.ComboBoxFormField:
									text2 = ((this.ElseInstructionValue.ToString().Length != 0) ? (text2 + this.method_3(text3 + text4 + ValueTypes.CustomValue.ToString().ToUpper(), new string[1] { this.ElseInstructionValue.ToString() })) : (text2 + this.resourceManager_0.GetString(text3 + text4 + ValueTypes.EmptyValue.ToString().ToUpper())));
									break;
								case FormFieldType.DateFormField:
									text2 = ((this.ElseInstructionValue != null) ? (text2 + this.method_3(text3 + text4 + ValueTypes.CustomValue.ToString().ToUpper(), new string[1] { ((DateTime)this.ElseInstructionValue).Ticks.ToString() })) : (text2 + this.resourceManager_0.GetString(text3 + text4 + ValueTypes.EmptyValue.ToString().ToUpper())));
									break;
								}
								break;
							}
							break;
						case Commands.SetNewItems:
						{
							string[] array = (string[])this.ElseInstructionValue;
							text2 = ((array.Length != 0) ? (text2 + this.method_3(text3 + text4 + ValueTypes.CustomValue.ToString().ToUpper(), array)) : (text2 + this.resourceManager_0.GetString(text3 + text4 + ValueTypes.EmptyValue.ToString().ToUpper())));
							break;
						}
						case Commands.SetValueAsValid:
						case Commands.SetValueAsInvalid:
							text4 = ((!(bool)this.ElseInstructionValue) ? (text4 + Commands.SetValueAsInvalid.ToString().ToUpper()) : (text4 + Commands.SetValueAsValid.ToString().ToUpper()));
							text2 += this.resourceManager_0.GetString(text3 + text4);
							break;
						}
					}
				}
				if (string.IsNullOrEmpty(text))
				{
					text = "";
				}
				if (string.IsNullOrEmpty(text2))
				{
					text2 = "";
				}
				return new object[3]
				{
					text,
					((IConditionalInstructionElement)this).RelatedFormField,
					text2
				};
			}
		}

		internal Instruction()
		{
			((IConditionalInstructionElement)this).RelatedFormField = new RelatedFormField();
		}

		public Instruction(FormField formField, InstructionTypes instructionType, object instructionValue)
		{
			if (formField == null)
			{
				throw new ArgumentNullException();
			}
			((IConditionalInstructionElement)this).RelatedFormField = new RelatedFormField
			{
				FormField_0 = formField
			};
			this.method_4(instructionType, instructionValue);
			this.method_5();
		}

		public Instruction(FormField formField, InstructionTypes instructionType, object instructionValue, object elseInstructionValue)
		{
			if (formField == null)
			{
				throw new ArgumentNullException();
			}
			((IConditionalInstructionElement)this).RelatedFormField = new RelatedFormField
			{
				FormField_0 = formField
			};
			this.method_4(instructionType, instructionValue);
			this.object_1 = elseInstructionValue;
			this.method_6(instructionType, this.object_1);
			if (this.object_1 is DateTime)
			{
				DateTime dateTime = (DateTime)this.object_1;
				this.object_1 = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
			}
			else if (this.object_1 == null && (formField is TextFormField || formField is SelectionFormField))
			{
				this.object_1 = string.Empty;
			}
			this.IsElseInstructionEnabled = true;
			this.bool_3 = true;
		}

		internal void method_0()
		{
			switch (this.Commands_0)
			{
			case Commands.SetNewValue:
				switch (this.ValueTypes_0)
				{
				case ValueTypes.Checked:
				case ValueTypes.Selected:
					(((IConditionalInstructionElement)this).RelatedFormField.FormField_0 as CheckFormField).Checked = true;
					break;
				case ValueTypes.Unchecked:
				case ValueTypes.Deselected:
					(((IConditionalInstructionElement)this).RelatedFormField.FormField_0 as CheckFormField).Checked = false;
					break;
				case ValueTypes.EmptyValue:
					if (((IConditionalInstructionElement)this).RelatedFormField.FormFieldType_0 == FormFieldType.DateFormField)
					{
						(((IConditionalInstructionElement)this).RelatedFormField.FormField_0 as DateFormField).Date = null;
					}
					else
					{
						((IConditionalInstructionElement)this).RelatedFormField.FormField_0.Text = "";
					}
					break;
				case ValueTypes.SpecificItem:
				case ValueTypes.CustomValue:
				{
					string text = Class399.smethod_1(this.String_0[0]);
					((IConditionalInstructionElement)this).RelatedFormField.FormField_0.Text = text;
					break;
				}
				case ValueTypes.Date:
				{
					if (((IConditionalInstructionElement)this).RelatedFormField.FormFieldType_0 == FormFieldType.DateFormField && this.String_0 != null && this.String_0.Length == 1 && long.TryParse(this.String_0[0], out var result))
					{
						DateTime value = new DateTime(result);
						if (value.Year >= 1601 && value.Year <= 9999)
						{
							(((IConditionalInstructionElement)this).RelatedFormField.FormField_0 as DateFormField).Date = value;
						}
					}
					break;
				}
				case ValueTypes.AnyItem:
					break;
				}
				break;
			case Commands.SetNewItems:
				(((IConditionalInstructionElement)this).RelatedFormField.FormField_0 as SelectionFormField).Items = this.String_0;
				break;
			}
		}

		internal void method_1()
		{
			switch (((IConditionalInstructionElement)this).RelatedFormField.FormFieldType_0)
			{
			case FormFieldType.CheckBoxFormField:
			{
				CheckFormField checkFormField = ((IConditionalInstructionElement)this).RelatedFormField.FormField_0 as CheckFormField;
				bool flag = (bool)this.ElseInstructionValue;
				if (checkFormField.Checked != flag)
				{
					checkFormField.Checked = flag;
				}
				break;
			}
			case FormFieldType.TextFormField:
			case FormFieldType.DropDownListFormField:
			case FormFieldType.ComboBoxFormField:
				this.FormField.Text = this.ElseInstructionValue.ToString();
				break;
			case FormFieldType.DateFormField:
			{
				DateFormField dateFormField = ((IConditionalInstructionElement)this).RelatedFormField.FormField_0 as DateFormField;
				if (this.ElseInstructionValue == null)
				{
					if (dateFormField.Date.HasValue)
					{
						dateFormField.Date = null;
					}
				}
				else
				{
					if (!long.TryParse(this.ElseInstructionValue.ToString(), out var result))
					{
						break;
					}
					DateTime value = new DateTime(result);
					if (value.Year >= 1601 && value.Year <= 9999)
					{
						DateTime? date = dateFormField.Date;
						if (!date.HasValue || date.Value.Year != value.Year || date.Value.DayOfYear != value.DayOfYear)
						{
							dateFormField.Date = value;
						}
					}
				}
				break;
			}
			}
		}

		internal Instruction method_2()
		{
			Instruction instruction = new Instruction();
			((IConditionalInstructionElement)instruction).RelatedFormField.FormField_0 = ((IConditionalInstructionElement)this).RelatedFormField.FormField_0;
			instruction.Commands_0 = this.Commands_0;
			instruction.ValueTypes_0 = this.ValueTypes_0;
			if (this.String_0 != null)
			{
				instruction.String_0 = new string[this.String_0.Length];
				for (int i = 0; i < this.String_0.Length; i++)
				{
					instruction.String_0[i] = this.String_0[i];
				}
			}
			instruction.IsElseInstructionEnabled = this.IsElseInstructionEnabled;
			instruction.IsFormFieldChangeInstruction = this.IsFormFieldChangeInstruction;
			instruction.IsInitialInstruction = this.IsInitialInstruction;
			instruction.ElseInstructionValue = this.ElseInstructionValue;
			return instruction;
		}

		private string method_3(string string_2, string[] string_3)
		{
			string text = this.resourceManager_0.GetString(string_2 + "_VALUE_START");
			string @string = this.resourceManager_0.GetString(string_2 + "_VALUE_SEPARATOR");
			if (this.Commands_0 == Commands.SetNewItems)
			{
				for (int i = 0; i < string_3.Length - 1; i++)
				{
					text = text + string_3[i] + @string;
				}
				text += string_3[string_3.Length - 1];
			}
			else
			{
				string text2 = string_3[0];
				if (((IConditionalInstructionElement)this).RelatedFormField.FormFieldType_0 == FormFieldType.DateFormField && long.TryParse(text2, out var result))
				{
					text2 = new DateTime(result).ToString("d", CultureInfo.CurrentUICulture);
				}
				text += text2;
			}
			return text + this.resourceManager_0.GetString(string_2 + "_VALUE_END");
		}

		private void method_4(InstructionTypes instructionTypes_1, object object_2)
		{
			switch (instructionTypes_1)
			{
			case InstructionTypes.IsEnabled:
				if (!(object_2 is bool))
				{
					throw new ArgumentException(this.resourceManager_0.GetString("ERR_INSTRUCTION_INSTRUCTIONTYPE_ISENABLED"));
				}
				this.Commands_0 = (((bool)object_2) ? Commands.AllowFillIn : Commands.DenyFillIn);
				this.ValueTypes_0 = ValueTypes.Undefined;
				this.object_0 = object_2;
				this.String_0 = null;
				break;
			case InstructionTypes.IsValueValid:
				if (object_2.GetType() != typeof(bool))
				{
					throw new ArgumentException(this.resourceManager_0.GetString("ERR_INSTRUCTION_INSTRUCTIONTYPE_ISVALUEVALID"));
				}
				this.Commands_0 = (((bool)object_2) ? Commands.SetValueAsValid : Commands.SetValueAsInvalid);
				this.ValueTypes_0 = ValueTypes.Undefined;
				this.object_0 = object_2;
				this.String_0 = null;
				break;
			case InstructionTypes.SetValue:
				this.Commands_0 = Commands.SetNewValue;
				switch (((IConditionalInstructionElement)this).RelatedFormField.FormField_0.GetType().Name)
				{
				case "DateFormField":
				{
					if (object_2 == null)
					{
						this.ValueTypes_0 = ValueTypes.EmptyValue;
						this.object_0 = object_2;
						this.String_0 = null;
						break;
					}
					if (!(object_2 is DateTime))
					{
						throw new ArgumentException(this.resourceManager_0.GetString("ERR_INSTRUCTION_INSTRUCTIONTYPE_SETVALUE_DATE"));
					}
					DateTime dateTime = (DateTime)object_2;
					dateTime = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
					if (dateTime.Year >= 1601 && dateTime.Year <= 9999)
					{
						this.ValueTypes_0 = ValueTypes.Date;
						this.object_0 = object_2;
						this.String_0 = new string[1] { dateTime.Ticks.ToString() };
						break;
					}
					throw new ArgumentException(this.resourceManager_0.GetString("ERR_INSTRUCTION_INSTRUCTIONTYPE_SETVALUE_DATE_YEAR"));
				}
				case "TextFormField":
				case "SelectionFormField":
				{
					if (object_2 != null && !(object_2 is string))
					{
						throw new ArgumentException(this.resourceManager_0.GetString("ERR_INSTRUCTION_INSTRUCTIONTYPE_SETVALUE_TEXT"));
					}
					string text = object_2 as string;
					if (text == null)
					{
						text = "";
					}
					this.ValueTypes_0 = ((text.Length == 0) ? ValueTypes.EmptyValue : ValueTypes.CustomValue);
					this.object_0 = object_2;
					this.String_0 = ((this.ValueTypes_0 == ValueTypes.EmptyValue) ? null : new string[1] { text });
					break;
				}
				case "CheckFormField":
					if (!(object_2 is bool))
					{
						throw new ArgumentException(this.resourceManager_0.GetString("ERR_INSTRUCTION_INSTRUCTIONTYPE_SETVALUE_CHECKED"));
					}
					this.ValueTypes_0 = (((bool)object_2) ? ValueTypes.Checked : ValueTypes.Unchecked);
					this.object_0 = object_2;
					this.String_0 = null;
					break;
				}
				break;
			case InstructionTypes.SetItems:
			{
				this.Commands_0 = Commands.SetNewItems;
				if (!(((IConditionalInstructionElement)this).RelatedFormField.FormField_0 is SelectionFormField))
				{
					throw new ArgumentException(this.resourceManager_0.GetString("ERR_INSTRUCTION_INSTRUCTIONTYPE_SETNEWITEMS_FORMFIELDTYPE"));
				}
				if (object_2 == null)
				{
					this.Commands_0 = Commands.SetNewItems;
					string[] array2 = (string[])(this.object_0 = (this.String_0 = new string[0]));
					this.ValueTypes_0 = ValueTypes.EmptyValue;
					break;
				}
				string[] array3 = object_2 as string[];
				if (array3 == null)
				{
					throw new ArgumentException(this.resourceManager_0.GetString("ERR_INSTRUCTION_INSTRUCTIONTYPE_SETNEWITEMS_TYPE"));
				}
				string[] array4 = array3;
				foreach (string value in array4)
				{
					if (string.IsNullOrEmpty(value))
					{
						throw new ArgumentException(this.resourceManager_0.GetString("ERR_INSTRUCTION_INSTRUCTIONTYPE_SETNEWITEMS_ELEMENT_NULL"));
					}
				}
				this.String_0 = array3;
				this.ValueTypes_0 = ((array3.Length > 0) ? ValueTypes.CustomValue : ValueTypes.EmptyValue);
				this.object_0 = object_2;
				break;
			}
			}
			this.instructionTypes_0 = instructionTypes_1;
			this.bool_0 = true;
		}

		internal void method_5()
		{
			if (this.bool_3)
			{
				return;
			}
			switch (this.Commands_0)
			{
			case Commands.SetNewValue:
				switch (((IConditionalInstructionElement)this).RelatedFormField.FormFieldType_0)
				{
				case FormFieldType.CheckBoxFormField:
					this.object_1 = !(bool)this.InstructionValue;
					break;
				case FormFieldType.TextFormField:
				case FormFieldType.DropDownListFormField:
				case FormFieldType.ComboBoxFormField:
					this.object_1 = "";
					break;
				case FormFieldType.DateFormField:
					this.object_1 = null;
					break;
				}
				break;
			case Commands.SetNewItems:
				this.object_1 = new string[0];
				break;
			case Commands.AllowFillIn:
			case Commands.SetValueAsValid:
				this.object_1 = false;
				break;
			case Commands.DenyFillIn:
			case Commands.SetValueAsInvalid:
				this.object_1 = true;
				break;
			}
		}

		private void method_6(InstructionTypes instructionTypes_1, object object_2)
		{
			switch (instructionTypes_1)
			{
			case InstructionTypes.IsEnabled:
				if (!(object_2 is bool))
				{
					throw new ArgumentException(this.resourceManager_0.GetString("ERR_ELSE_INSTRUCTION_ENABLED"));
				}
				break;
			case InstructionTypes.IsValueValid:
				if (object_2.GetType() != typeof(bool))
				{
					throw new ArgumentException(this.resourceManager_0.GetString("ERR_ELSE_INSTRUCTION_VALID"));
				}
				break;
			case InstructionTypes.SetValue:
				switch (((IConditionalInstructionElement)this).RelatedFormField.FormField_0.GetType().Name)
				{
				case "DateFormField":
					if (object_2 != null)
					{
						if (!(object_2 is DateTime))
						{
							throw new ArgumentException(this.resourceManager_0.GetString("ERR_ELSE_INSTRUCTION_SETVALUE_DATE"));
						}
						DateTime dateTime = (DateTime)object_2;
						if (dateTime.Year < 1601 || dateTime.Year > 9999)
						{
							throw new ArgumentException(this.resourceManager_0.GetString("ERR_ELSE_INSTRUCTION_SETVALUE_DATE_YEAR"));
						}
					}
					break;
				case "TextFormField":
				case "SelectionFormField":
					if (object_2 != null && !(object_2 is string))
					{
						throw new ArgumentException(this.resourceManager_0.GetString("ERR_ELSE_INSTRUCTION_SETVALUE_TEXT"));
					}
					break;
				case "CheckFormField":
					if (!(object_2 is bool))
					{
						throw new ArgumentException(this.resourceManager_0.GetString("ERR_ELSE_INSTRUCTION_SETVALUE_CHECKED"));
					}
					break;
				}
				break;
			case InstructionTypes.SetItems:
			{
				if (object_2 == null)
				{
					object_2 = new string[0];
					break;
				}
				string[] array = object_2 as string[];
				if (array == null)
				{
					throw new ArgumentException(this.resourceManager_0.GetString("ERR_ELSE_INSTRUCTION_SETNEWITEMS_TYPE"));
				}
				string[] array2 = array;
				int num = 0;
				while (true)
				{
					if (num < array2.Length)
					{
						string value = array2[num];
						if (string.IsNullOrEmpty(value))
						{
							break;
						}
						num++;
						continue;
					}
					return;
				}
				throw new ArgumentException(this.resourceManager_0.GetString("ERR_ELSE_INSTRUCTION_SETNEWITEMS_ELEMENT_NULL"));
			}
			}
		}

		private void method_7()
		{
			if (this.bool_0)
			{
				return;
			}
			switch (this.Commands_0)
			{
			case Commands.AllowFillIn:
			case Commands.DenyFillIn:
				this.instructionTypes_0 = InstructionTypes.IsEnabled;
				this.object_0 = this.Commands_0 == Commands.AllowFillIn;
				break;
			case Commands.SetNewValue:
				this.instructionTypes_0 = InstructionTypes.SetValue;
				switch (((IConditionalInstructionElement)this).RelatedFormField.FormFieldType_0)
				{
				case FormFieldType.CheckBoxFormField:
					this.object_0 = this.ValueTypes_0 == ValueTypes.Checked || this.ValueTypes_0 == ValueTypes.Selected;
					break;
				case FormFieldType.TextFormField:
				case FormFieldType.DropDownListFormField:
				case FormFieldType.ComboBoxFormField:
					this.object_0 = ((this.ValueTypes_0 == ValueTypes.EmptyValue) ? "" : this.String_0[0]);
					break;
				case FormFieldType.DateFormField:
				{
					long result;
					if (this.ValueTypes_0 == ValueTypes.EmptyValue)
					{
						this.object_0 = null;
					}
					else if (long.TryParse(this.String_0[0], out result))
					{
						this.object_0 = new DateTime(result);
					}
					break;
				}
				}
				break;
			case Commands.SetNewItems:
				this.instructionTypes_0 = InstructionTypes.SetItems;
				this.object_0 = ((this.ValueTypes_0 == ValueTypes.EmptyValue) ? new string[0] : this.String_0);
				break;
			case Commands.SetValueAsValid:
			case Commands.SetValueAsInvalid:
				this.instructionTypes_0 = InstructionTypes.IsValueValid;
				this.object_0 = this.Commands_0 == Commands.SetValueAsValid;
				break;
			}
			this.bool_0 = true;
		}

		public int CompareTo(object obj)
		{
			Instruction instruction = obj as Instruction;
			int int32_ = ((IConditionalInstructionElement)this).RelatedFormField.Int32_0;
			int int32_2 = ((IConditionalInstructionElement)instruction).RelatedFormField.Int32_0;
			if (int32_ == int32_2)
			{
				return ((int)this.Commands_0).CompareTo((int)instruction.Commands_0);
			}
			return int32_.CompareTo(int32_2);
		}

		string IConditionalInstructionElement.ToJson()
		{
			return Class403.smethod_0(this);
		}

		public override string ToString()
		{
			object[] stringElements = ((IConditionalInstructionElement)this).StringElements;
			return string.Concat(stringElements[0], (stringElements[1] as RelatedFormField).FormField_0.Name, stringElements[2]);
		}
	}
}
