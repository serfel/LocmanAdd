using System;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using ns21;
using ns22;

namespace TXTextControl
{
	/// <summary>An object of the Condition class is an element of the ConditionalInstruction class and represents the state of a FormField that has to be fulfilled to execute the instructions of the related ConditionalInstruction object.To create a condition, the Condition object has to be initialized with a FormField that is located inside the document.Furthermore, a comparison value has to be defined by the constructor's comparisonValue parameter.• The constructor's isChecked parameter value of a condition that references to a CheckFormField represents a check state to be fulfilled.• Conditions that are related to form fields of type TextFormField or SelectionFormField execute a comparison to the form field's Text property value.• In addition, the text of a SelectionFormField object can be compared with one of its SelectionFormField.Items array entries or checked whether or not the string equals to one of its SelectionFormField.Items array entries.• Up to four different comparison types can be applied to compare the Date property of DateFormField objects with a specified value: If the comparison value is an object of type System.DateTime, the year, month and day of month is compared with the current property value.</summary>
	public class Condition : IComparable, IConditionalInstructionElement
	{
		/// <summary>Determines how the condition is related to the previous condition inside the corresponding ConditionalInstruction.Conditions array.</summary>
		public enum LogicalConnectives
		{
			/// <summary>The condition is connected to the previous condition by a logical conjunction (ConditionA ∧ ConditionB)</summary>
			And,
			const_1
		}

		/// <summary>Determines the comparison operator that is used to compare the condition's form field value with the specified comparison value or the interpretation of that value.</summary>
		public enum ComparisonOperators
		{
			const_0 = 1,
			/// <summary>Form field value does not equal to the specified comparison value or the interpretation of that value.</summary>
			IsNot,
			/// <summary>Form field value contains the specified comparison value.</summary>
			Contains,
			/// <summary>Form field value starts with the specified comparison value.</summary>
			StartsWith,
			/// <summary>Form field value ends with the specified comparison value.</summary>
			EndsWith,
			/// <summary>Form field value does not contain the specified comparison value.</summary>
			DoesNotContain,
			/// <summary>Form field value does not start with the specified comparison value.</summary>
			DoesNotStartWith,
			/// <summary>Form field value does not end with the specified comparison value.</summary>
			DoesNotEndWith,
			/// <summary>Form field value is greater than the specified comparison value.</summary>
			IsGreaterThan,
			/// <summary>Form field value is greater than or equals to the specified comparison value.</summary>
			IsGreaterThanOrEqual,
			/// <summary>Form field value is less than the specified comparison value.</summary>
			IsLessThan,
			/// <summary>Form field value is less than or equals to the specified comparison value.</summary>
			IsLessThanOrEqual
		}

		/// <summary>Determines how the specified comparison value has to be interpreted when comparing it with the TextFormField's or SelectionFormField's Text property.</summary>
		public enum TextComparisonFlags
		{
			/// <summary>The comparison value has to be interpreted as custom text.</summary>
			CustomText,
			/// <summary>The comparison value has to be interpreted as a regular expression.</summary>
			Regex
		}

		/// <summary>Determines how the specified comparison value has to be interpreted when comparing it with the SelectionFormField's Text property.</summary>
		public enum ItemComparisonFlags
		{
			/// <summary>The comparison value represents an item of the SelectionFormField.Items array.</summary>
			SpecificItem,
			/// <summary>The condition checks whether or not the SelectionFormField's Text property value equals to one of its items.</summary>
			AnyItem
		}

		/// <summary>Determines the month that is compared with the condition's form field value.</summary>
		public enum Month
		{
			/// <summary>Represents the month January.</summary>
			January,
			/// <summary>Represents the month February.</summary>
			February,
			/// <summary>Represents the month March.</summary>
			March,
			/// <summary>Represents the month April.</summary>
			April,
			/// <summary>Represents the month May.</summary>
			May,
			/// <summary>Represents the month June.</summary>
			June,
			/// <summary>Represents the month July.</summary>
			July,
			/// <summary>Represents the month August.</summary>
			August,
			/// <summary>Represents the month September.</summary>
			September,
			/// <summary>Represents the month October.</summary>
			October,
			/// <summary>Represents the month November.</summary>
			November,
			/// <summary>Represents the month December.</summary>
			December
		}

		/// <summary>Determines how the condition's comparison value is interpreted by the condition.</summary>
		public enum ComparisonValueTypes
		{
			/// <summary>The condition tests the check state of the related condition's CheckFormField. If this enumeration value is returned by the Condition.ComparisonValueType property, the Condition.ComparisonValue property is set to true. The Condition.ComparisonOperator returns the enumeration value ComparisonOperators.Is, if the condition checks whether the check form field is checked. Otherwise ComparisonOperators.IsNot.</summary>
			CheckState = 1,
			/// <summary>The condition examines whether the related condition's FormField property does not provide a suitable value that can be used for comparison. Form field values of type TextFormField and SelectionFormField are not suitable for comparison, if their FormField.Text property value is an empty string. The corresponding value of a DateFormField cannot be compared, if its DateFormField.Date property returns null. If the ComparisonValueTypes.NoValue value is returned by the Condition.ComparisonValueType property, the Condition.ComparisonValue property is set to null. The ComparisonValueTypes.NoValue enumeration value can only be combined with the operator ComparisonOperators.Is or ComparisonOperators.IsNot.</summary>
			NoValue,
			/// <summary>The condition compares the FormField.Text property value of the related condition's TextFormField or SelectionFormField with the value of the Condition.ComparisonValue property. If this enumeration value is returned by the Condition.ComparisonValueType property, the Condition.ComparisonValue property value is an object of type string. Furthermore, all provided values of the ComparisonOperators enumeration can be set as Condition.ComparisonOperator property value.</summary>
			CustomText,
			/// <summary>The condition checks whether or not the FormField.Text property value of the related condition's TextFormField or SelectionFormField matches a specific regular expression. That regular expression is represented by the Condition.ComparisonValue property. It is an object of type string and conforms to the rules of the .NET Framework regular expression engine. The ComparisonValueTypes.Regex enumeration value can only be combined with the operator ComparisonOperators.Is or ComparisonOperators.IsNot.</summary>
			Regex,
			/// <summary>The condition compares the FormField.Text property value of the related condition's SelectionFormField with an item of SelectionFormField.Items string array collection. The representation of that item is an object of type string, which is specified by the Condition.ComparisonValue property. All provided values of the ComparisonOperators enumeration can be set as Condition.ComparisonOperator property value.</summary>
			SpecificItem,
			/// <summary>The condition examines whether the related condition's SelectionFormField.Text property value matches one of the SelectionFormField.Items string array collection values. If this enumeration value is returned by the Condition.ComparisonValueType property, the Condition.ComparisonValue property is set to null. The ComparisonValueTypes.AnyItem enumeration value can only be combined with the operator ComparisonOperators.Is or ComparisonOperators.IsNot.</summary>
			AnyItem,
			/// <summary>The condition compares the DateFormField.Date property value of the related condition's DateFormField with a date that is specified by the Condition.ComparisonValue property. If this enumeration value is returned by the Condition.ComparisonValueType property, the Condition.ComparisonValue property is an object of type System.DateTime. The ComparisonValueTypes.Date enumeration value can only be combined with the operator ComparisonOperators.Is, ComparisonOperators.IsNot,ComparisonOperators.IsGreaterThan, ComparisonOperators.IsGreaterThanOrEqual, ComparisonOperators.IsLessThan or ComparisonOperators.IsLessThanOrEqual.</summary>
			Date,
			/// <summary>The condition compares the DateFormField.Date property value of the related condition's DateFormField with a year that is specified by the Condition.ComparisonValue property. If this enumeration value is returned by the Condition.ComparisonValueType property, the Condition.ComparisonValue property represents an integer between 1601 and 9999. The ComparisonValueTypes.Year enumeration value can only be combined with the operator ComparisonOperators.Is, ComparisonOperators.IsNot, ComparisonOperators.IsGreaterThan, ComparisonOperators.IsGreaterThanOrEqual, ComparisonOperators.IsLessThan or ComparisonOperators.IsLessThanOrEqual.</summary>
			Year,
			/// <summary>The condition compares the DateFormField.Date property value of the related condition's DateFormField with a month that is specified by the Condition.ComparisonValue property. If this enumeration value is returned by the Condition.ComparisonValueType property, the Condition.ComparisonValueproperty is an object of type Condition.Month. The ComparisonValueTypes.Month enumeration value can only be combined with the operator ComparisonOperators.Is, ComparisonOperators.IsNot, ComparisonOperators.IsGreaterThan, ComparisonOperators.IsGreaterThanOrEqual, ComparisonOperators.IsLessThan or ComparisonOperators.IsLessThanOrEqual.</summary>
			Month,
			/// <summary>The condition compares the DateFormField.Date property value of the related condition's DateFormField with a day of the month that is specified by the Condition.ComparisonValue property. If this enumeration value is returned by the Condition.ComparisonValueType property, the Condition.ComparisonValue property represents an integer between 1 and 31. The ComparisonValueTypes.DayOfMonth enumeration value can only be combined with the operator ComparisonOperators.Is, ComparisonOperators.IsNot, ComparisonOperators.IsGreaterThan, ComparisonOperators.IsGreaterThanOrEqual, ComparisonOperators.IsLessThan or ComparisonOperators.IsLessThanOrEqual.</summary>
			DayOfMonth,
			/// <summary>The condition compares the DateFormField.Date property value of the related condition's DateFormField with a weekday that is specified by the Condition.ComparisonValue property. If this enumeration value is returned by the Condition.ComparisonValueType property, the Condition.ComparisonValue property is an object of type System.DayOfWeek. The ComparisonValueTypes.Weekday enumeration value can only be combined with the operator ComparisonOperators.Is or ComparisonOperators.IsNot.</summary>
			Weekday
		}

		internal ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private bool bool_0;

		private object object_0;

		private ComparisonOperators comparisonOperators_0;

		private ComparisonValueTypes comparisonValueTypes_0 = ComparisonValueTypes.NoValue;

		private LogicalOperators logicalOperators_0;

		[CompilerGenerated]
		private LogicalConnectives logicalConnectives_0;

		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private ValueTypes valueTypes_0;

		[CompilerGenerated]
		private int int_0;

		[CompilerGenerated]
		private bool bool_1;

		[CompilerGenerated]
		private string string_1;

		[CompilerGenerated]
		private RelatedFormField relatedFormField_0;

		/// <summary>Gets or sets a value of type Condition.LogicalConnectives that describes how the condition is related to the previous condition inside the corresponding ConditionalInstruction.Conditions array.</summary>
		public LogicalConnectives LogicalConnective
		{
			[CompilerGenerated]
			get
			{
				return this.logicalConnectives_0;
			}
			[CompilerGenerated]
			set
			{
				this.logicalConnectives_0 = value;
			}
		}

		/// <summary>Gets the FormField whose property value is to be compared with the condition's comparison value.</summary>
		public FormField FormField => ((IConditionalInstructionElement)this).RelatedFormField.FormField_0;

		/// <summary>Gets the operator that is used to compare the condition's form field value with the specified comparison value.</summary>
		public ComparisonOperators ComparisonOperator
		{
			get
			{
				this.method_15();
				return this.comparisonOperators_0;
			}
		}

		/// <summary>Gets the value that is compared with the condition's form field value.</summary>
		public object ComparisonValue
		{
			get
			{
				this.method_15();
				return this.object_0;
			}
		}

		/// <summary>Gets a value of type ComparisonValueTypes that determines how the condition's comparison value is interpreted.</summary>
		public ComparisonValueTypes ComparisonValueType
		{
			get
			{
				this.method_15();
				return this.comparisonValueTypes_0;
			}
		}

		internal string String_0
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

		internal int Int32_0
		{
			[CompilerGenerated]
			get
			{
				return this.int_0;
			}
			[CompilerGenerated]
			set
			{
				this.int_0 = value;
			}
		}

		internal bool Boolean_0
		{
			get
			{
				switch (((IConditionalInstructionElement)this).RelatedFormField.FormFieldType_0)
				{
				default:
					return false;
				case FormFieldType.CheckBoxFormField:
					return this.method_4();
				case FormFieldType.TextFormField:
					return this.method_6();
				case FormFieldType.DropDownListFormField:
				case FormFieldType.ComboBoxFormField:
					return this.method_5();
				case FormFieldType.DateFormField:
					return this.method_7();
				}
			}
		}

		internal bool Boolean_1
		{
			[CompilerGenerated]
			get
			{
				return this.bool_1;
			}
			[CompilerGenerated]
			set
			{
				this.bool_1 = value;
			}
		}

		internal LogicalOperators LogicalOperators_0
		{
			get
			{
				return this.logicalOperators_0;
			}
			set
			{
				this.logicalOperators_0 = value;
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
				if (Enum.IsDefined(typeof(LogicalConnectives), this.LogicalConnective) && Enum.IsDefined(typeof(LogicalOperators), this.LogicalOperators_0))
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
					string text3 = (this.Boolean_1 ? "IF" : this.LogicalConnective.ToString());
					string text4 = "";
					bool flag = this.ValueTypes_0 == ValueTypes.SpecificItem || this.ValueTypes_0 == ValueTypes.CustomValue || (((IConditionalInstructionElement)this).RelatedFormField.FormFieldType_0 == FormFieldType.DateFormField && this.ValueTypes_0 != ValueTypes.EmptyValue);
					if (((IConditionalInstructionElement)this).RelatedFormField.FormField_0 is SelectionFormField && flag)
					{
						switch (this.LogicalOperators_0)
						{
						case LogicalOperators.EqualsTo:
						case LogicalOperators.DoesNotEqualTo:
							text4 = ((this.ValueTypes_0 == ValueTypes.CustomValue) ? "_TEXTCOMPARISON" : "_ITEMCOMPARISON");
							break;
						case LogicalOperators.Contains:
						case LogicalOperators.StartsWith:
						case LogicalOperators.EndsWith:
						case LogicalOperators.DoesNotContain:
						case LogicalOperators.DoesNotStartWith:
						case LogicalOperators.DoesNotEndWith:
							text4 = ((this.ValueTypes_0 == ValueTypes.CustomValue) ? "_TEXTCOMPARISON_TEXT" : "_ITEMCOMPARISON_TEXT");
							break;
						case LogicalOperators.IsGreaterThan:
						case LogicalOperators.IsGreaterThanOrEqual:
						case LogicalOperators.IsLessThan:
						case LogicalOperators.IsLessThanOrEqual:
							text4 = ((this.ValueTypes_0 == ValueTypes.CustomValue) ? "_TEXTCOMPARISON_VALUE" : "_ITEMCOMPARISON_VALUE");
							break;
						}
					}
					text = this.resourceManager_0.GetString("ID_CONDITIONALINSTRUCTIONS_CONDITIONS_" + (text3 + "_" + ((IConditionalInstructionElement)this).RelatedFormField.FormFieldType_0.ToString() + text4).ToUpper());
					string text5 = "ID_CONDITIONALINSTRUCTIONS_CONDITIONS_" + string.Concat(((IConditionalInstructionElement)this).RelatedFormField.FormFieldType_0, "_", this.LogicalOperators_0, "_", this.ValueTypes_0).ToUpper();
					text2 = this.resourceManager_0.GetString(text5 + (flag ? "_START" : ""));
					if (flag)
					{
						string text6 = "";
						if (((IConditionalInstructionElement)this).RelatedFormField.FormFieldType_0 == FormFieldType.DateFormField)
						{
							switch (this.ValueTypes_0)
							{
							case ValueTypes.Date:
							{
								if (long.TryParse(this.String_0, out var result))
								{
									text6 = new DateTime(result).ToString("d", CultureInfo.CurrentUICulture);
								}
								break;
							}
							default:
								text6 = this.String_0;
								break;
							case ValueTypes.Month:
							case ValueTypes.DayOfMonth:
							case ValueTypes.DayOfWeek:
								string.Concat("ID_CONDITIONALINSTRUCTIONS_CONDITIONS_", ((IConditionalInstructionElement)this).RelatedFormField.FormFieldType_0, "_", this.ValueTypes_0, "_", this.String_0).ToUpper();
								text6 = this.resourceManager_0.GetString(string.Concat("ID_CONDITIONALINSTRUCTIONS_CONDITIONS_", ((IConditionalInstructionElement)this).RelatedFormField.FormFieldType_0, "_", this.ValueTypes_0, "_", this.String_0).ToUpper());
								break;
							}
						}
						else
						{
							text6 = this.String_0;
						}
						text2 = text2 + text6 + this.resourceManager_0.GetString(text5 + (flag ? "_END" : ""));
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

		internal Condition()
		{
			((IConditionalInstructionElement)this).RelatedFormField = new RelatedFormField();
		}

		/// <summary>Creates an instance of the Condition class that tests whether the CheckFormField's Checked property value equals the specified boolean value. The Condition.ComparisonValueType property is set to ComparisonValueTypes.CheckState.</summary>
		/// <param name="formField">Specifies the form field whose property value is to be compared with the condition's comparison value.</param>
		/// <param name="isChecked">Specifies the value that the CheckFormField.Checked property must have to fulfill the condition.</param>
		public Condition(CheckFormField formField, bool isChecked)
		{
			if (formField == null)
			{
				throw new ArgumentNullException();
			}
			((IConditionalInstructionElement)this).RelatedFormField = new RelatedFormField
			{
				FormField_0 = formField
			};
			this.method_10(isChecked);
		}

		public Condition(TextFormField formField, ComparisonOperators comparisonOperator, string comparisonValue)
		{
			if (formField == null)
			{
				throw new ArgumentNullException();
			}
			((IConditionalInstructionElement)this).RelatedFormField = new RelatedFormField
			{
				FormField_0 = formField
			};
			this.method_11(comparisonOperator, comparisonValue);
		}

		public Condition(TextFormField formField, ComparisonOperators comparisonOperator, string comparisonValue, TextComparisonFlags textComparisonFlag)
		{
			if (formField == null)
			{
				throw new ArgumentNullException();
			}
			((IConditionalInstructionElement)this).RelatedFormField = new RelatedFormField
			{
				FormField_0 = formField
			};
			this.method_12(comparisonOperator, comparisonValue, textComparisonFlag);
		}

		public Condition(SelectionFormField formField, ComparisonOperators comparisonOperator, string comparisonValue)
		{
			if (formField == null)
			{
				throw new ArgumentNullException();
			}
			((IConditionalInstructionElement)this).RelatedFormField = new RelatedFormField
			{
				FormField_0 = formField
			};
			this.method_11(comparisonOperator, comparisonValue);
		}

		public Condition(SelectionFormField formField, ComparisonOperators comparisonOperator, string comparisonValue, TextComparisonFlags textComparisonFlag)
		{
			if (formField == null)
			{
				throw new ArgumentNullException();
			}
			((IConditionalInstructionElement)this).RelatedFormField = new RelatedFormField
			{
				FormField_0 = formField
			};
			this.method_12(comparisonOperator, comparisonValue, textComparisonFlag);
		}

		public Condition(SelectionFormField formField, ComparisonOperators comparisonOperator, string comparisonValue, ItemComparisonFlags itemComparisonFlag)
		{
			if (formField == null)
			{
				throw new ArgumentNullException();
			}
			((IConditionalInstructionElement)this).RelatedFormField = new RelatedFormField
			{
				FormField_0 = formField
			};
			this.method_13(comparisonOperator, comparisonValue, itemComparisonFlag);
		}

		public Condition(DateFormField formField, ComparisonOperators comparisonOperator, DateTime? comparisonValue)
		{
			if (formField == null)
			{
				throw new ArgumentNullException();
			}
			((IConditionalInstructionElement)this).RelatedFormField = new RelatedFormField
			{
				FormField_0 = formField
			};
			this.method_14(comparisonOperator, comparisonValue, comparisonValue.HasValue ? ValueTypes.Date : ValueTypes.EmptyValue);
		}

		public Condition(DateFormField formField, ComparisonOperators comparisonOperator, int comparisonValue)
		{
			if (formField == null)
			{
				throw new ArgumentNullException();
			}
			ValueTypes valueTypes = ValueTypes.Undefined;
			if (comparisonValue >= 1601 && comparisonValue <= 9999)
			{
				valueTypes = ValueTypes.Year;
			}
			else
			{
				if (comparisonValue < 1 || comparisonValue > 31)
				{
					throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITION_COMPARISONVALUE_DATEFORMFIELD_YEAR_DAYOFMONTH"));
				}
				valueTypes = ValueTypes.DayOfMonth;
			}
			((IConditionalInstructionElement)this).RelatedFormField = new RelatedFormField
			{
				FormField_0 = formField
			};
			this.method_14(comparisonOperator, comparisonValue, valueTypes);
		}

		public Condition(DateFormField formField, ComparisonOperators comparisonOperator, Month comparisonValue)
		{
			if (formField == null)
			{
				throw new ArgumentNullException();
			}
			if (comparisonValue > Month.December)
			{
				throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITION_COMPARISONOPERATOR_DATEFORMFIELD_MONTH"));
			}
			((IConditionalInstructionElement)this).RelatedFormField = new RelatedFormField
			{
				FormField_0 = formField
			};
			this.method_14(comparisonOperator, comparisonValue, ValueTypes.Month);
		}

		public Condition(DateFormField formField, ComparisonOperators comparisonOperator, DayOfWeek comparisonValue)
		{
			if (formField == null)
			{
				throw new ArgumentNullException();
			}
			if (comparisonValue > DayOfWeek.Saturday)
			{
				throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITION_COMPARISONOPERATOR_DATEFORMFIELD_WEEKDAY"));
			}
			((IConditionalInstructionElement)this).RelatedFormField = new RelatedFormField
			{
				FormField_0 = formField
			};
			this.method_14(comparisonOperator, comparisonValue, ValueTypes.DayOfWeek);
		}

		private bool method_0(string string_2, string string_3)
		{
			string_3 = Class399.smethod_1(string_3);
			switch (this.LogicalOperators_0)
			{
			default:
				return false;
			case LogicalOperators.EqualsTo:
				return string_2 == string_3;
			case LogicalOperators.DoesNotEqualTo:
				return string_2 != string_3;
			case LogicalOperators.Contains:
				return string_2.Contains(string_3);
			case LogicalOperators.StartsWith:
				return string_2.StartsWith(string_3);
			case LogicalOperators.EndsWith:
				return string_2.EndsWith(string_3);
			case LogicalOperators.DoesNotContain:
				return !string_2.Contains(string_3);
			case LogicalOperators.DoesNotStartWith:
				return !string_2.StartsWith(string_3);
			case LogicalOperators.DoesNotEndWith:
				return !string_2.EndsWith(string_3);
			case LogicalOperators.IsGreaterThan:
			case LogicalOperators.IsGreaterThanOrEqual:
			case LogicalOperators.IsLessThan:
			case LogicalOperators.IsLessThanOrEqual:
			{
				decimal? num = this.method_1(string_2);
				decimal? num2 = this.method_1(string_3);
				if (!num.HasValue && !num2.HasValue)
				{
					return this.LogicalOperators_0 switch
					{
						LogicalOperators.IsGreaterThan => string.Compare(string_2, string_3, StringComparison.Ordinal) > 0, 
						LogicalOperators.IsGreaterThanOrEqual => string.Compare(string_2, string_3, StringComparison.Ordinal) >= 0, 
						LogicalOperators.IsLessThan => string.Compare(string_2, string_3, StringComparison.Ordinal) < 0, 
						LogicalOperators.IsLessThanOrEqual => string.Compare(string_2, string_3, StringComparison.Ordinal) <= 0, 
						_ => false, 
					};
				}
				if (num.HasValue == num2.HasValue)
				{
					return this.LogicalOperators_0 switch
					{
						LogicalOperators.IsGreaterThan => decimal.Compare(num.Value, num2.Value) > 0, 
						LogicalOperators.IsGreaterThanOrEqual => decimal.Compare(num.Value, num2.Value) >= 0, 
						LogicalOperators.IsLessThan => decimal.Compare(num.Value, num2.Value) < 0, 
						LogicalOperators.IsLessThanOrEqual => decimal.Compare(num.Value, num2.Value) <= 0, 
						_ => false, 
					};
				}
				return false;
			}
			case LogicalOperators.MatchesRegex:
				try
				{
					return new Regex(string_3).IsMatch(string_2);
				}
				catch
				{
					return false;
				}
			case LogicalOperators.DoesNotMatchRegex:
				try
				{
					return !new Regex(string_3).IsMatch(string_2);
				}
				catch
				{
					return false;
				}
			}
		}

		private decimal? method_1(string string_2)
		{
			CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
			if (decimal.TryParse(string_2, NumberStyles.Any, currentCulture, out var result))
			{
				return result;
			}
			return null;
		}

		private bool method_2(int int_1, int int_2)
		{
			return this.LogicalOperators_0 switch
			{
				LogicalOperators.IsGreaterThan => int_1.CompareTo(int_2) > 0, 
				LogicalOperators.IsGreaterThanOrEqual => int_1.CompareTo(int_2) >= 0, 
				LogicalOperators.IsLessThan => int_1.CompareTo(int_2) < 0, 
				LogicalOperators.IsLessThanOrEqual => int_1.CompareTo(int_2) <= 0, 
				LogicalOperators.EqualsTo => int_1 == int_2, 
				LogicalOperators.DoesNotEqualTo => int_1 != int_2, 
				_ => false, 
			};
		}

		private bool method_3(DateTime dateTime_0, DateTime dateTime_1)
		{
			switch (this.LogicalOperators_0)
			{
			default:
				return false;
			case LogicalOperators.IsGreaterThan:
				if (dateTime_0.Year <= dateTime_1.Year)
				{
					if (dateTime_0.Year == dateTime_1.Year)
					{
						return dateTime_0.DayOfYear > dateTime_1.DayOfYear;
					}
					return false;
				}
				return true;
			case LogicalOperators.IsGreaterThanOrEqual:
				if (dateTime_0.Year <= dateTime_1.Year && (dateTime_0.Year != dateTime_1.Year || dateTime_0.DayOfYear <= dateTime_1.DayOfYear))
				{
					if (dateTime_0.Year == dateTime_1.Year)
					{
						return dateTime_0.DayOfYear == dateTime_1.DayOfYear;
					}
					return false;
				}
				return true;
			case LogicalOperators.IsLessThan:
				if (dateTime_0.Year >= dateTime_1.Year)
				{
					if (dateTime_0.Year == dateTime_1.Year)
					{
						return dateTime_0.DayOfYear < dateTime_1.DayOfYear;
					}
					return false;
				}
				return true;
			case LogicalOperators.IsLessThanOrEqual:
				if (dateTime_0.Year >= dateTime_1.Year && (dateTime_0.Year != dateTime_1.Year || dateTime_0.DayOfYear >= dateTime_1.DayOfYear))
				{
					if (dateTime_0.Year == dateTime_1.Year)
					{
						return dateTime_0.DayOfYear == dateTime_1.DayOfYear;
					}
					return false;
				}
				return true;
			case LogicalOperators.EqualsTo:
				if (dateTime_0.Year == dateTime_1.Year)
				{
					return dateTime_0.DayOfYear == dateTime_1.DayOfYear;
				}
				return false;
			case LogicalOperators.DoesNotEqualTo:
				if (dateTime_0.Year == dateTime_1.Year)
				{
					return dateTime_0.DayOfYear != dateTime_1.DayOfYear;
				}
				return true;
			}
		}

		private bool method_4()
		{
			bool @checked = (((IConditionalInstructionElement)this).RelatedFormField.FormField_0 as CheckFormField).Checked;
			bool flag = this.ValueTypes_0 == ValueTypes.Checked || this.ValueTypes_0 == ValueTypes.Selected;
			flag = ((this.LogicalOperators_0 == LogicalOperators.EqualsTo) ? flag : (!flag));
			return @checked == flag;
		}

		private bool method_5()
		{
			string text = ((IConditionalInstructionElement)this).RelatedFormField.FormField_0.Text;
			switch (this.ValueTypes_0)
			{
			default:
			{
				string string_ = this.String_0;
				return this.method_0(text, string_);
			}
			case ValueTypes.EmptyValue:
				if (this.LogicalOperators_0 != LogicalOperators.EqualsTo)
				{
					return !string.IsNullOrEmpty(text);
				}
				return string.IsNullOrEmpty(text);
			case ValueTypes.SpecificItem:
			case ValueTypes.AnyItem:
			{
				string[] items = (((IConditionalInstructionElement)this).RelatedFormField.FormField_0 as SelectionFormField).Items;
				bool flag = false;
				string[] array = items;
				foreach (string text2 in array)
				{
					string text3 = ((this.ValueTypes_0 == ValueTypes.AnyItem) ? text : this.String_0);
					if (text3 == text2)
					{
						flag = true;
						break;
					}
				}
				if (this.ValueTypes_0 == ValueTypes.AnyItem)
				{
					if (this.LogicalOperators_0 != LogicalOperators.EqualsTo)
					{
						return !flag;
					}
					return flag;
				}
				if (flag)
				{
					return this.method_0(text, this.String_0);
				}
				return false;
			}
			}
		}

		private bool method_6()
		{
			string text = ((IConditionalInstructionElement)this).RelatedFormField.FormField_0.Text;
			if (this.ValueTypes_0 == ValueTypes.EmptyValue)
			{
				if (this.LogicalOperators_0 != LogicalOperators.EqualsTo)
				{
					return !string.IsNullOrEmpty(text);
				}
				return string.IsNullOrEmpty(text);
			}
			string string_ = this.String_0;
			return this.method_0(text, string_);
		}

		private bool method_7()
		{
			DateFormField dateFormField = ((IConditionalInstructionElement)this).RelatedFormField.FormField_0 as DateFormField;
			DateTime? date = dateFormField.Date;
			switch (this.ValueTypes_0)
			{
			case ValueTypes.EmptyValue:
				if (this.LogicalOperators_0 != LogicalOperators.EqualsTo)
				{
					return date.HasValue;
				}
				return !date.HasValue;
			default:
				return false;
			case ValueTypes.Date:
			{
				if (!string.IsNullOrEmpty(this.String_0) && long.TryParse(this.String_0, out var result2))
				{
					DateTime dateTime_ = new DateTime(result2);
					if (date.HasValue)
					{
						return this.method_3(date.Value, dateTime_);
					}
					return false;
				}
				return false;
			}
			case ValueTypes.Year:
			{
				if (!string.IsNullOrEmpty(this.String_0) && int.TryParse(this.String_0, out var result4))
				{
					if (date.HasValue)
					{
						return this.method_2(date.Value.Year, result4);
					}
					return false;
				}
				return false;
			}
			case ValueTypes.Month:
			{
				if (!string.IsNullOrEmpty(this.String_0) && int.TryParse(this.String_0, out var result3))
				{
					if (date.HasValue)
					{
						return this.method_2(date.Value.Month, result3 + 1);
					}
					return false;
				}
				return false;
			}
			case ValueTypes.DayOfMonth:
			{
				if (!string.IsNullOrEmpty(this.String_0) && int.TryParse(this.String_0, out var result5))
				{
					if (date.HasValue)
					{
						return this.method_2(date.Value.Day, result5);
					}
					return false;
				}
				return false;
			}
			case ValueTypes.DayOfWeek:
			{
				if (!string.IsNullOrEmpty(this.String_0) && int.TryParse(this.String_0, out var result))
				{
					if (date.HasValue)
					{
						return this.method_2((int)date.Value.DayOfWeek, result);
					}
					return false;
				}
				return false;
			}
			}
		}

		internal Condition method_8()
		{
			Condition condition = new Condition();
			condition.LogicalConnective = this.LogicalConnective;
			((IConditionalInstructionElement)condition).RelatedFormField.FormField_0 = ((IConditionalInstructionElement)this).RelatedFormField.FormField_0;
			condition.LogicalOperators_0 = this.LogicalOperators_0;
			condition.Int32_0 = this.Int32_0;
			condition.ValueTypes_0 = this.ValueTypes_0;
			condition.String_0 = this.String_0;
			((IConditionalInstructionElement)condition).ConditionalInstructionName = ((IConditionalInstructionElement)this).ConditionalInstructionName;
			return condition;
		}

		private void method_9(ComparisonOperators comparisonOperators_1)
		{
			switch (comparisonOperators_1)
			{
			case ComparisonOperators.const_0:
				this.logicalOperators_0 = LogicalOperators.EqualsTo;
				break;
			case ComparisonOperators.IsNot:
				this.logicalOperators_0 = LogicalOperators.DoesNotEqualTo;
				break;
			case ComparisonOperators.Contains:
				this.logicalOperators_0 = LogicalOperators.Contains;
				break;
			case ComparisonOperators.StartsWith:
				this.logicalOperators_0 = LogicalOperators.StartsWith;
				break;
			case ComparisonOperators.EndsWith:
				this.logicalOperators_0 = LogicalOperators.EndsWith;
				break;
			case ComparisonOperators.DoesNotContain:
				this.logicalOperators_0 = LogicalOperators.DoesNotContain;
				break;
			case ComparisonOperators.DoesNotStartWith:
				this.logicalOperators_0 = LogicalOperators.DoesNotStartWith;
				break;
			case ComparisonOperators.DoesNotEndWith:
				this.logicalOperators_0 = LogicalOperators.DoesNotEndWith;
				break;
			case ComparisonOperators.IsGreaterThan:
				this.logicalOperators_0 = LogicalOperators.IsGreaterThan;
				break;
			case ComparisonOperators.IsGreaterThanOrEqual:
				this.logicalOperators_0 = LogicalOperators.IsGreaterThanOrEqual;
				break;
			case ComparisonOperators.IsLessThan:
				this.logicalOperators_0 = LogicalOperators.IsLessThan;
				break;
			case ComparisonOperators.IsLessThanOrEqual:
				this.logicalOperators_0 = LogicalOperators.IsLessThanOrEqual;
				break;
			}
		}

		private void method_10(bool bool_2)
		{
			this.logicalOperators_0 = (bool_2 ? LogicalOperators.EqualsTo : LogicalOperators.DoesNotEqualTo);
			this.ValueTypes_0 = ValueTypes.Checked;
			this.String_0 = null;
			this.comparisonOperators_0 = (bool_2 ? ComparisonOperators.const_0 : ComparisonOperators.IsNot);
			this.object_0 = true;
			this.comparisonValueTypes_0 = ComparisonValueTypes.CheckState;
			this.bool_0 = true;
		}

		private void method_11(ComparisonOperators comparisonOperators_1, string string_2)
		{
			if (string.IsNullOrEmpty(string_2))
			{
				switch (comparisonOperators_1)
				{
				default:
					throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITION_COMPARISONVALUE_TEXT_NULL"));
				case ComparisonOperators.const_0:
				case ComparisonOperators.IsNot:
					this.logicalOperators_0 = ((comparisonOperators_1 == ComparisonOperators.const_0) ? LogicalOperators.EqualsTo : LogicalOperators.DoesNotEqualTo);
					this.ValueTypes_0 = ValueTypes.EmptyValue;
					this.String_0 = null;
					this.comparisonOperators_0 = comparisonOperators_1;
					this.object_0 = null;
					this.comparisonValueTypes_0 = ComparisonValueTypes.NoValue;
					this.bool_0 = true;
					break;
				}
			}
			else
			{
				this.method_12(comparisonOperators_1, string_2, TextComparisonFlags.CustomText);
			}
		}

		private void method_12(ComparisonOperators comparisonOperators_1, string string_2, TextComparisonFlags textComparisonFlags_0)
		{
			if (string.IsNullOrEmpty(string_2))
			{
				throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITION_COMPARISONVALUE_TEXTCOMPARISONFLAG"));
			}
			switch (comparisonOperators_1)
			{
			default:
				if (textComparisonFlags_0 == TextComparisonFlags.Regex)
				{
					throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITION_COMPARISONOPERATOR_TEXTCOMPARISONFLAG_REGEX"));
				}
				this.method_9(comparisonOperators_1);
				this.ValueTypes_0 = ValueTypes.CustomValue;
				this.comparisonValueTypes_0 = ComparisonValueTypes.CustomText;
				this.String_0 = string_2;
				break;
			case ComparisonOperators.const_0:
			case ComparisonOperators.IsNot:
				switch (textComparisonFlags_0)
				{
				case TextComparisonFlags.Regex:
					if (!ConditionalInstruction.smethod_0(string_2))
					{
						throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITION_COMPARISONVALUE_TEXTCOMPARISONFLAG_REGEX"));
					}
					this.logicalOperators_0 = ((comparisonOperators_1 == ComparisonOperators.const_0) ? LogicalOperators.MatchesRegex : LogicalOperators.DoesNotMatchRegex);
					goto IL_00bc;
				case TextComparisonFlags.CustomText:
					{
						this.logicalOperators_0 = ((comparisonOperators_1 == ComparisonOperators.const_0) ? LogicalOperators.EqualsTo : LogicalOperators.DoesNotEqualTo);
						goto IL_00bc;
					}
					IL_00bc:
					this.ValueTypes_0 = ValueTypes.CustomValue;
					this.comparisonValueTypes_0 = ((textComparisonFlags_0 == TextComparisonFlags.CustomText) ? ComparisonValueTypes.CustomText : ComparisonValueTypes.Regex);
					this.String_0 = string_2;
					break;
				}
				break;
			}
			this.comparisonOperators_0 = comparisonOperators_1;
			this.object_0 = string_2;
			this.bool_0 = true;
		}

		private void method_13(ComparisonOperators comparisonOperators_1, string string_2, ItemComparisonFlags itemComparisonFlags_0)
		{
			if (itemComparisonFlags_0 == ItemComparisonFlags.SpecificItem)
			{
				if (string.IsNullOrEmpty(string_2))
				{
					throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITION_COMPARISONVALUE_SPECIFICITEM_NULL"));
				}
				string[] items = (((IConditionalInstructionElement)this).RelatedFormField.FormField_0 as SelectionFormField).Items;
				bool flag = false;
				string[] array = items;
				foreach (string text in array)
				{
					if (text == string_2)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITION_COMPARISONVALUE_SPECIFICITEM_UNKNOWN_ITEM"));
				}
			}
			switch (comparisonOperators_1)
			{
			default:
				if (itemComparisonFlags_0 == ItemComparisonFlags.AnyItem)
				{
					throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITION_COMPARISONOPERATOR_ITEMCOMPARISONFLAG_ANYITEM"));
				}
				this.method_9(comparisonOperators_1);
				this.ValueTypes_0 = ValueTypes.SpecificItem;
				this.comparisonValueTypes_0 = ComparisonValueTypes.SpecificItem;
				this.String_0 = string_2;
				this.object_0 = string_2;
				break;
			case ComparisonOperators.const_0:
			case ComparisonOperators.IsNot:
				this.logicalOperators_0 = ((comparisonOperators_1 == ComparisonOperators.const_0) ? LogicalOperators.EqualsTo : LogicalOperators.DoesNotEqualTo);
				switch (itemComparisonFlags_0)
				{
				case ItemComparisonFlags.SpecificItem:
					this.ValueTypes_0 = ValueTypes.SpecificItem;
					this.comparisonValueTypes_0 = ComparisonValueTypes.SpecificItem;
					this.String_0 = string_2;
					this.object_0 = string_2;
					break;
				case ItemComparisonFlags.AnyItem:
					this.ValueTypes_0 = ValueTypes.AnyItem;
					this.comparisonValueTypes_0 = ComparisonValueTypes.AnyItem;
					this.String_0 = null;
					this.object_0 = null;
					break;
				}
				break;
			}
			this.comparisonOperators_0 = comparisonOperators_1;
			this.bool_0 = true;
		}

		private void method_14(ComparisonOperators comparisonOperators_1, object object_1, ValueTypes valueTypes_1)
		{
			switch (comparisonOperators_1)
			{
			default:
				throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITION_COMPARISONOPERATOR_DATEFORMFIELD"));
			case ComparisonOperators.const_0:
			case ComparisonOperators.IsNot:
			case ComparisonOperators.IsGreaterThan:
			case ComparisonOperators.IsGreaterThanOrEqual:
			case ComparisonOperators.IsLessThan:
			case ComparisonOperators.IsLessThanOrEqual:
				switch (valueTypes_1)
				{
				case ValueTypes.Date:
					this.ValueTypes_0 = ValueTypes.Date;
					this.comparisonValueTypes_0 = ComparisonValueTypes.Date;
					this.String_0 = ((DateTime)object_1).Ticks.ToString();
					break;
				case ValueTypes.Year:
					this.ValueTypes_0 = ValueTypes.Year;
					this.comparisonValueTypes_0 = ComparisonValueTypes.Year;
					this.String_0 = ((int)object_1).ToString();
					break;
				case ValueTypes.Month:
					this.ValueTypes_0 = ValueTypes.Month;
					this.comparisonValueTypes_0 = ComparisonValueTypes.Month;
					this.String_0 = ((int)object_1).ToString();
					break;
				case ValueTypes.DayOfMonth:
					this.ValueTypes_0 = ValueTypes.DayOfMonth;
					this.comparisonValueTypes_0 = ComparisonValueTypes.DayOfMonth;
					this.String_0 = ((int)object_1).ToString();
					break;
				case ValueTypes.EmptyValue:
				case ValueTypes.DayOfWeek:
					if (comparisonOperators_1 != ComparisonOperators.const_0 && comparisonOperators_1 != ComparisonOperators.IsNot)
					{
						throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITION_COMPARISONOPERATOR_DATEFORMFIELD_COMPARISONVALUE"));
					}
					this.ValueTypes_0 = valueTypes_1;
					if (valueTypes_1 == ValueTypes.EmptyValue)
					{
						this.comparisonValueTypes_0 = ComparisonValueTypes.NoValue;
						this.String_0 = null;
					}
					else
					{
						this.comparisonValueTypes_0 = ComparisonValueTypes.Weekday;
						this.String_0 = ((int)object_1).ToString();
					}
					break;
				}
				this.method_9(comparisonOperators_1);
				this.comparisonOperators_0 = comparisonOperators_1;
				this.object_0 = object_1;
				this.bool_0 = true;
				break;
			}
		}

		private void method_15()
		{
			if (!this.bool_0)
			{
				switch (((IConditionalInstructionElement)this).RelatedFormField.FormFieldType_0)
				{
				case FormFieldType.CheckBoxFormField:
					this.method_17();
					break;
				case FormFieldType.TextFormField:
					this.method_18();
					break;
				case FormFieldType.DropDownListFormField:
				case FormFieldType.ComboBoxFormField:
					this.method_19();
					break;
				case FormFieldType.DateFormField:
					this.method_20();
					break;
				}
				this.bool_0 = true;
			}
		}

		private void method_16()
		{
			switch (this.logicalOperators_0)
			{
			case LogicalOperators.Contains:
				this.comparisonOperators_0 = ComparisonOperators.Contains;
				break;
			case LogicalOperators.StartsWith:
				this.comparisonOperators_0 = ComparisonOperators.StartsWith;
				break;
			case LogicalOperators.EndsWith:
				this.comparisonOperators_0 = ComparisonOperators.EndsWith;
				break;
			case LogicalOperators.DoesNotContain:
				this.comparisonOperators_0 = ComparisonOperators.DoesNotContain;
				break;
			case LogicalOperators.DoesNotStartWith:
				this.comparisonOperators_0 = ComparisonOperators.DoesNotStartWith;
				break;
			case LogicalOperators.DoesNotEndWith:
				this.comparisonOperators_0 = ComparisonOperators.DoesNotEndWith;
				break;
			case LogicalOperators.IsGreaterThan:
				this.comparisonOperators_0 = ComparisonOperators.IsGreaterThan;
				break;
			case LogicalOperators.IsGreaterThanOrEqual:
				this.comparisonOperators_0 = ComparisonOperators.IsGreaterThanOrEqual;
				break;
			case LogicalOperators.IsLessThan:
				this.comparisonOperators_0 = ComparisonOperators.IsLessThan;
				break;
			case LogicalOperators.IsLessThanOrEqual:
				this.comparisonOperators_0 = ComparisonOperators.IsLessThanOrEqual;
				break;
			case LogicalOperators.EqualsTo:
			case LogicalOperators.MatchesRegex:
				this.comparisonOperators_0 = ComparisonOperators.const_0;
				break;
			case LogicalOperators.DoesNotEqualTo:
			case LogicalOperators.DoesNotMatchRegex:
				this.comparisonOperators_0 = ComparisonOperators.IsNot;
				break;
			}
		}

		private void method_17()
		{
			switch (this.logicalOperators_0)
			{
			default:
				throw new InvalidOperationException();
			case LogicalOperators.EqualsTo:
				this.comparisonOperators_0 = ComparisonOperators.const_0;
				break;
			case LogicalOperators.DoesNotEqualTo:
				this.comparisonOperators_0 = ComparisonOperators.IsNot;
				break;
			}
			switch (this.ValueTypes_0)
			{
			default:
				throw new InvalidOperationException();
			case ValueTypes.Checked:
			case ValueTypes.Unchecked:
				this.object_0 = this.ValueTypes_0 == ValueTypes.Checked;
				this.comparisonValueTypes_0 = ComparisonValueTypes.CheckState;
				break;
			}
		}

		private void method_18()
		{
			this.method_16();
			switch (this.ValueTypes_0)
			{
			case ValueTypes.CustomValue:
				this.object_0 = this.String_0;
				this.comparisonValueTypes_0 = ((this.logicalOperators_0 == LogicalOperators.MatchesRegex || this.logicalOperators_0 == LogicalOperators.DoesNotMatchRegex) ? ComparisonValueTypes.Regex : ComparisonValueTypes.CustomText);
				break;
			default:
				throw new InvalidOperationException();
			case ValueTypes.EmptyValue:
				this.object_0 = null;
				this.comparisonValueTypes_0 = ComparisonValueTypes.NoValue;
				break;
			}
		}

		private void method_19()
		{
			this.method_16();
			switch (this.ValueTypes_0)
			{
			default:
				throw new InvalidOperationException();
			case ValueTypes.EmptyValue:
				this.object_0 = null;
				this.comparisonValueTypes_0 = ComparisonValueTypes.NoValue;
				break;
			case ValueTypes.SpecificItem:
				this.object_0 = this.String_0;
				this.comparisonValueTypes_0 = ComparisonValueTypes.SpecificItem;
				break;
			case ValueTypes.AnyItem:
				this.object_0 = null;
				this.comparisonValueTypes_0 = ComparisonValueTypes.AnyItem;
				break;
			case ValueTypes.CustomValue:
				this.object_0 = this.String_0;
				this.comparisonValueTypes_0 = ((this.logicalOperators_0 == LogicalOperators.MatchesRegex || this.logicalOperators_0 == LogicalOperators.DoesNotMatchRegex) ? ComparisonValueTypes.Regex : ComparisonValueTypes.CustomText);
				break;
			}
		}

		private void method_20()
		{
			this.method_16();
			switch (this.ValueTypes_0)
			{
			case ValueTypes.EmptyValue:
				this.object_0 = null;
				this.comparisonValueTypes_0 = ComparisonValueTypes.NoValue;
				break;
			default:
				throw new InvalidOperationException();
			case ValueTypes.Date:
			{
				if (long.TryParse(this.String_0, out var result2))
				{
					this.object_0 = new DateTime(result2);
					this.comparisonValueTypes_0 = ComparisonValueTypes.Date;
				}
				break;
			}
			case ValueTypes.Year:
			case ValueTypes.Month:
			case ValueTypes.DayOfMonth:
			case ValueTypes.DayOfWeek:
			{
				if (int.TryParse(this.String_0, out var result))
				{
					switch (this.ValueTypes_0)
					{
					case ValueTypes.Month:
						this.object_0 = (Month)result;
						this.comparisonValueTypes_0 = ComparisonValueTypes.Month;
						break;
					case ValueTypes.Year:
					case ValueTypes.DayOfMonth:
						this.object_0 = result;
						this.comparisonValueTypes_0 = ((this.ValueTypes_0 == ValueTypes.Year) ? ComparisonValueTypes.Year : ComparisonValueTypes.DayOfMonth);
						break;
					case ValueTypes.DayOfWeek:
						this.object_0 = (DayOfWeek)result;
						this.comparisonValueTypes_0 = ComparisonValueTypes.Weekday;
						break;
					}
				}
				break;
			}
			}
		}

		public int CompareTo(object obj)
		{
			return this.Int32_0.CompareTo((obj as Condition).Int32_0);
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
