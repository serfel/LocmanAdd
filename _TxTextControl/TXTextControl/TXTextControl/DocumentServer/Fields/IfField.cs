using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using ns1;
using DocumentServer.Properties;
using TXTextControl;

namespace DocumentServer.Fields
{
	/// <summary>The IfField class implements the MS Word specific IF field.</summary>
	public sealed class IfField : MailMergeFieldAdapter
	{
		public enum RelationalOperator
		{
			Equals,
			NotEqual,
			LessThan,
			GreaterThan,
			GreaterThanOrEqualTo,
			LessThanOrEqualTo
		}

		public new const string TYPE_NAME = "IF";

		private string string_0 = string.Empty;

		private string string_1 = string.Empty;

		private string string_2 = string.Empty;

		private string string_3 = string.Empty;

		private RelationalOperator relationalOperator_0;

		private string string_4 = string.Empty;

		[Category("Properties")]
		public override string TypeName => "IF";

		/// <summary>Gets and sets the displayed text of the field.</summary>
		[Category("Properties")]
		[Attribute1("PROP_FIELD_TEXT")]
		public string Text
		{
			get
			{
				return base.ApplicationField.Text ?? string.Empty;
			}
			set
			{
				base.ApplicationField.Text = value ?? string.Empty;
				this.SetParameters();
			}
		}

		/// <summary>Gets and sets the operator of the field.</summary>
		[Category("Appearance")]
		[Attribute1("PROP_IFFIELD_OPERATOR")]
		public RelationalOperator Operator
		{
			get
			{
				return this.relationalOperator_0;
			}
			set
			{
				this.relationalOperator_0 = value;
				this.SetParameters();
			}
		}

		/// <summary>Gets and sets the first expression text that should be compared.</summary>
		[Category("Appearance")]
		[Attribute1("PROP_IFFIELD_EXPRESSION1")]
		public string Expression1
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value ?? string.Empty;
				this.SetParameters();
			}
		}

		/// <summary>Gets and sets the second expression text that should be compared to Expression1.</summary>
		[Category("Appearance")]
		[Attribute1("PROP_IFFIELD_EXPRESSION2")]
		public string Expression2
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value ?? string.Empty;
				this.SetParameters();
			}
		}

		/// <summary>Gets and sets the text that should be displayed when the comparison is true.</summary>
		[Category("Appearance")]
		[Attribute1("PROP_IFFIELD_TRUETEXT")]
		public string TrueText
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value ?? string.Empty;
				this.SetParameters();
			}
		}

		/// <summary>Gets and sets the text that should be displayed when the comparison is false.</summary>
		[Category("Appearance")]
		[Attribute1("PROP_IFFIELD_FALSETEXT")]
		public string FalseText
		{
			get
			{
				return this.string_3;
			}
			set
			{
				this.string_3 = value ?? string.Empty;
				this.SetParameters();
			}
		}

		/// <summary>Gets or sets the field's value of the field that has been specified in Expression1.</summary>
		[Category("Appearance")]
		[Attribute1("PROP_IFFIELD_FIELDVALUE")]
		public string FieldValue
		{
			get
			{
				return this.string_4;
			}
			set
			{
				this.string_4 = value ?? string.Empty;
				if (IfField.smethod_0(this.string_4, this.Expression2, this.Operator))
				{
					this.Text = this.TrueText;
				}
				else
				{
					this.Text = this.FalseText;
				}
				this.SetParameters();
			}
		}

		/// <summary>Initializes a new instance of the IfField class with a connection to an existing ApplicationField.</summary>
		/// <param name="appField">Specifies the ApplicationField to be adapted.</param>
		public IfField(ApplicationField appField)
			: base(appField)
		{
			if (string.Compare(appField.TypeName, "IF") != 0)
			{
				throw new ArgumentException(string.Format(Resources.EXC_APPFIELD_TYPE_MISMATCH, "IF"));
			}
			this.GetParameters();
		}

		internal IfField(IfField ifField)
			: this(ifField.ApplicationField)
		{
			this.Expression1 = ifField.Expression1;
			this.Expression2 = ifField.Expression2;
			this.FalseText = ifField.FalseText;
			this.TrueText = ifField.TrueText;
			this.Operator = ifField.Operator;
			this.FieldValue = ifField.FieldValue;
		}

		/// <summary>Initializes a complete new instance of the IfField class without a connection to an existing ApplicationField.</summary>
		public IfField()
		{
		}

		protected override void GenerateAppField()
		{
			base.ApplicationField = new ApplicationField(ApplicationFieldFormat.MSWord, "IF", "{IF}", new string[0]);
		}

		protected override void SetParameters()
		{
			string[] array = new string[6]
			{
				"\"" + this.string_0 + "\"",
				null,
				null,
				null,
				null,
				null
			};
			switch (this.relationalOperator_0)
			{
			case RelationalOperator.Equals:
				array[1] = "=";
				break;
			case RelationalOperator.NotEqual:
				array[1] = "<>";
				break;
			case RelationalOperator.LessThan:
				array[1] = "<";
				break;
			case RelationalOperator.GreaterThan:
				array[1] = ">";
				break;
			case RelationalOperator.GreaterThanOrEqualTo:
				array[1] = ">=";
				break;
			case RelationalOperator.LessThanOrEqualTo:
				array[1] = "<=";
				break;
			}
			array[2] = "\"" + this.string_1 + "\"";
			array[3] = "\"" + this.string_2 + "\"";
			array[4] = "\"" + this.string_3 + "\"";
			array[5] = (base.PreserveFormatting ? "\\* MERGEFORMAT" : string.Empty);
			base.ApplicationField.Parameters = array;
		}

		protected override void GetParameters()
		{
			if (base.ApplicationField.Parameters == null || base.ApplicationField.Parameters.Length < 4)
			{
				return;
			}
			this.string_0 = base.ApplicationField.Parameters[0].TrimStart('"').TrimEnd('"');
			this.string_1 = base.ApplicationField.Parameters[2].TrimStart('"').TrimEnd('"');
			switch (base.ApplicationField.Parameters[1])
			{
			case "<":
				this.relationalOperator_0 = RelationalOperator.LessThan;
				break;
			case "=":
				this.relationalOperator_0 = RelationalOperator.Equals;
				break;
			case ">=":
				this.relationalOperator_0 = RelationalOperator.GreaterThanOrEqualTo;
				break;
			case ">":
				this.relationalOperator_0 = RelationalOperator.GreaterThan;
				break;
			case "<=":
				this.relationalOperator_0 = RelationalOperator.LessThanOrEqualTo;
				break;
			case "!=":
			case "<>":
				this.relationalOperator_0 = RelationalOperator.NotEqual;
				break;
			}
			this.string_2 = base.ApplicationField.Parameters[3].TrimStart('"').TrimEnd('"');
			if (base.ApplicationField.Parameters.Length != 4)
			{
				if (base.ApplicationField.Parameters[4].Contains("\\* MERGEFORMAT"))
				{
					base.m_bPreserveFormatting = true;
					return;
				}
				this.string_3 = base.ApplicationField.Parameters[4].TrimStart('"').TrimEnd('"');
				base.m_bPreserveFormatting = base.ApplicationField.Parameters.Length >= 6 && base.ApplicationField.Parameters[5].Contains("\\* MERGEFORMAT");
			}
		}

		internal bool method_0(IfField ifField_0)
		{
			if (ifField_0 == null)
			{
				return false;
			}
			if (ifField_0.relationalOperator_0 == this.relationalOperator_0 && ifField_0.string_0 == this.string_0 && ifField_0.string_1 == this.string_1 && ifField_0.string_3 == this.string_3 && ifField_0.string_4 == this.string_4 && ifField_0.Text == this.Text && ifField_0.string_2 == this.string_2)
			{
				return base.Equals(ifField_0);
			}
			return false;
		}

		internal static bool smethod_0(string string_5, string string_6, RelationalOperator relationalOperator_1)
		{
			bool result = false;
			double num;
			double num2;
			if (IfField.IsNumeric(string_5) && IfField.IsNumeric(string_6))
			{
				num = Convert.ToDouble(string_5);
				num2 = Convert.ToDouble(string_6);
			}
			else
			{
				num = string_5.CompareTo(string_6);
				num2 = 0.0;
			}
			switch (relationalOperator_1)
			{
			case RelationalOperator.Equals:
				result = num == num2;
				break;
			case RelationalOperator.NotEqual:
				result = num != num2;
				break;
			case RelationalOperator.LessThan:
				result = num < num2;
				break;
			case RelationalOperator.GreaterThan:
				result = num > num2;
				break;
			case RelationalOperator.GreaterThanOrEqualTo:
				result = num >= num2;
				break;
			case RelationalOperator.LessThanOrEqualTo:
				result = num <= num2;
				break;
			}
			return result;
		}

		public static bool IsNumeric(string value)
		{
			return new Regex("(^[-+]?\\d+(,?\\d*)*\\.?\\d*([Ee][-+]\\d*)?$)|(^[-+]?\\d?(,?\\d*)*\\.\\d+([Ee][-+]\\d*)?$)", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.IgnorePatternWhitespace).Match(value).Success;
		}
	}
}
