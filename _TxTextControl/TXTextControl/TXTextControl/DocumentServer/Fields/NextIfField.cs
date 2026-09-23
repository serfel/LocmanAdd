using System;
using System.ComponentModel;
using ns1;
using DocumentServer.Properties;
using TXTextControl;

namespace DocumentServer.Fields
{
	/// <summary>The NextIfField class implements the MS Word specific NEXTIF field.</summary>
	public sealed class NextIfField : MailMergeFieldAdapter
	{
		public new const string TYPE_NAME = "NEXTIF";

		private string string_0 = string.Empty;

		private string string_1 = string.Empty;

		private IfField.RelationalOperator relationalOperator_0;

		private string string_2 = string.Empty;

		[Category("Properties")]
		public override string TypeName => "NEXTIF";

		/// <summary>Gets and sets the comparison operator the field.</summary>
		[Category("Appearance")]
		[Attribute1("PROP_IFFIELD_OPERATOR")]
		public IfField.RelationalOperator Operator
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

		/// <summary>Gets or sets the field's value of the field that has been specified in Expression1.</summary>
		[Category("Appearance")]
		[Attribute1("PROP_IFFIELD_FIELDVALUE")]
		public string FieldValue
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value ?? string.Empty;
			}
		}

		/// <summary>Gets the evaluation result of the two field expressions and the specified comparison operator.</summary>
		[Attribute1("PROP_NEXTIF_FIELD_RESULT")]
		[Browsable(false)]
		public bool Result => IfField.smethod_0(this.string_2, this.Expression2, this.Operator);

		/// <summary>Initializes a new instance of the NextIfField class with a connection to an existing ApplicationField.</summary>
		/// <param name="appField">Specifies the ApplicationField to be adapted.</param>
		public NextIfField(ApplicationField appField)
			: base(appField)
		{
			if (string.Compare(appField.TypeName, "NEXTIF") != 0)
			{
				throw new ArgumentException(string.Format(Resources.EXC_APPFIELD_TYPE_MISMATCH, "NEXTIF"));
			}
			this.GetParameters();
		}

		internal NextIfField(NextIfField field)
			: this(field.ApplicationField)
		{
			this.Expression1 = field.Expression1;
			this.Expression2 = field.Expression2;
			this.Operator = field.Operator;
			this.FieldValue = field.FieldValue;
		}

		/// <summary>Initializes a complete new instance of the NextIfField class without a connection to an existing ApplicationField.</summary>
		public NextIfField()
		{
		}

		protected override void GenerateAppField()
		{
			base.ApplicationField = new ApplicationField(ApplicationFieldFormat.MSWord, "NEXTIF", "{NEXTIF}", new string[0]);
		}

		protected override void SetParameters()
		{
			string[] array = new string[4]
			{
				"\"" + this.string_0 + "\"",
				null,
				null,
				null
			};
			switch (this.relationalOperator_0)
			{
			case IfField.RelationalOperator.Equals:
				array[1] = "=";
				break;
			case IfField.RelationalOperator.NotEqual:
				array[1] = "<>";
				break;
			case IfField.RelationalOperator.LessThan:
				array[1] = "<";
				break;
			case IfField.RelationalOperator.GreaterThan:
				array[1] = ">";
				break;
			case IfField.RelationalOperator.GreaterThanOrEqualTo:
				array[1] = ">=";
				break;
			case IfField.RelationalOperator.LessThanOrEqualTo:
				array[1] = "<=";
				break;
			}
			array[2] = "\"" + this.string_1 + "\"";
			array[3] = (base.PreserveFormatting ? "\\* MERGEFORMAT" : string.Empty);
			base.ApplicationField.Parameters = array;
		}

		protected override void GetParameters()
		{
			if (base.ApplicationField.Parameters != null && base.ApplicationField.Parameters.Length >= 3)
			{
				this.string_0 = base.ApplicationField.Parameters[0].TrimStart('"').TrimEnd('"');
				this.string_1 = base.ApplicationField.Parameters[2].TrimStart('"').TrimEnd('"');
				switch (base.ApplicationField.Parameters[1])
				{
				case "<":
					this.relationalOperator_0 = IfField.RelationalOperator.LessThan;
					break;
				case "=":
					this.relationalOperator_0 = IfField.RelationalOperator.Equals;
					break;
				case ">=":
					this.relationalOperator_0 = IfField.RelationalOperator.GreaterThanOrEqualTo;
					break;
				case ">":
					this.relationalOperator_0 = IfField.RelationalOperator.GreaterThan;
					break;
				case "<=":
					this.relationalOperator_0 = IfField.RelationalOperator.LessThanOrEqualTo;
					break;
				case "!=":
				case "<>":
					this.relationalOperator_0 = IfField.RelationalOperator.NotEqual;
					break;
				}
				base.m_bPreserveFormatting = base.ApplicationField.Parameters.Length >= 4 && base.ApplicationField.Parameters[3].Contains("\\* MERGEFORMAT");
			}
		}

		internal bool method_0(NextIfField nextIfField_0)
		{
			if (nextIfField_0 == null)
			{
				return false;
			}
			if (nextIfField_0.relationalOperator_0 == this.relationalOperator_0 && nextIfField_0.string_0 == this.string_0 && nextIfField_0.string_1 == this.string_1 && nextIfField_0.string_2 == this.string_2)
			{
				return base.Equals(nextIfField_0);
			}
			return false;
		}
	}
}
