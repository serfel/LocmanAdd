using System;
using System.Collections;
using System.ComponentModel;
using ns1;
using DocumentServer.Properties;
using TXTextControl;

namespace DocumentServer.Fields
{
	/// <summary>The FormText class implements the MS Word specific FORMTEXT field.</summary>
	public sealed class FormText : FormFieldAdapter
	{
		public enum FormTextBoxType
		{
			RegularText,
			Number,
			Date,
			CurrentDate,
			CurrentTime,
			Calculation
		}

		public new const string TYPE_NAME = "FORMTEXT";

		private string[] string_0;

		private bool bool_0;

		private bool bool_1;

		private TextFormatOptions textFormatOptions_0;

		private FormTextBoxType formTextBoxType_0;

		private int int_0;

		private string string_1 = "";

		private string string_2 = "";

		[Category("Properties")]
		public override string TypeName => "FORMTEXT";

		/// <summary>Gets and sets the maximum length of the field.</summary>
		[Category("Properties")]
		[Attribute1("PROP_FRMTEXT_MAXLENGTH")]
		public int MaxLength
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
				if ((base.Text.Length > this.int_0) & (this.int_0 != 0))
				{
					base.Text = base.Text.Substring(0, this.int_0);
				}
				this.SetParameters();
			}
		}

		[Category("Properties")]
		[Attribute1("PROP_FIELD_HELPTEXT")]
		public override string HelpText
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
				this.SetParameters();
			}
		}

		[Category("Properties")]
		[Attribute1("PROP_FIELD_STATUSTEXT")]
		public override string StatusText
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
				this.SetParameters();
			}
		}

		[Category("Properties")]
		[Attribute1("PROP_FIELD_ENABLED")]
		public override bool Enabled
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
				this.SetParameters();
			}
		}

		[Category("Properties")]
		[Attribute1("PROP_FIELD_CALCONEXIT")]
		public override bool CalcOnExit
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
				this.SetParameters();
			}
		}

		/// <summary>Gets or sets the TextFormatOptions of the field.</summary>
		[Category("Properties")]
		[Attribute1("PROP_FRMTEXT_FORMAT")]
		public TextFormatOptions Format
		{
			get
			{
				return this.textFormatOptions_0;
			}
			set
			{
				this.textFormatOptions_0 = value;
				this.SetParameters();
			}
		}

		/// <summary>Gets or sets the type of the field.</summary>
		[Category("Properties")]
		[Attribute1("PROP_FRMTEXT_TYPE")]
		public FormTextBoxType Type
		{
			get
			{
				return this.formTextBoxType_0;
			}
			set
			{
				this.formTextBoxType_0 = value;
				this.SetParameters();
			}
		}

		/// <summary>Initializes a new instance of the FormText class with a connection to an existing ApplicationField.</summary>
		/// <param name="appField">Specifies the ApplicationField to be adapted.</param>
		public FormText(ApplicationField appField)
			: base(appField)
		{
			if (string.Compare(appField.TypeName, "FORMTEXT") != 0)
			{
				throw new ArgumentException(string.Format(Resources.EXC_APPFIELD_TYPE_MISMATCH, "FORMTEXT"));
			}
			this.string_0 = base.ApplicationField.Parameters ?? new string[0];
			this.GetParameters();
		}

		/// <summary>Initializes a complete new instance of the FormText class without a connection to an existing ApplicationField.</summary>
		public FormText()
		{
		}

		protected override void GenerateAppField()
		{
			base.ApplicationField = new ApplicationField(ApplicationFieldFormat.MSWord, "FORMTEXT", "{FORMTEXT}", new string[0]);
		}

		protected override void GetParameters()
		{
			if (this.string_0 == null)
			{
				return;
			}
			string[] array = this.string_0;
			foreach (string text in array)
			{
				if (text.Contains("w:name w:val"))
				{
					base.Name = text.Split('"').GetValue(1).ToString();
				}
				else if (text.Contains("w:maxLength w:val"))
				{
					this.int_0 = Convert.ToInt32(text.Split('"').GetValue(1));
				}
				else if (text.Contains("w:enabled w:val"))
				{
					this.bool_0 = Convert.ToBoolean(text.Split('"').GetValue(1));
				}
				else if (text.Contains("w:calcOnExit w:val"))
				{
					this.bool_1 = Convert.ToBoolean(text.Split('"').GetValue(1));
				}
				else if (text.Contains("w:default w:val"))
				{
					base.Text = text.Split('"').GetValue(1).ToString();
				}
				else if (text.Contains("w:helpText w:type=\"text\" w:val"))
				{
					this.string_1 = text.Split('"').GetValue(3).ToString();
				}
				else if (text.Contains("w:statusText w:type=\"text\" w:val"))
				{
					this.string_2 = text.Split('"').GetValue(3).ToString();
				}
				else if (text.Contains("w:format w:val"))
				{
					switch (text.Split('"').GetValue(1).ToString()
						.ToLower())
					{
					case "first capital":
						this.textFormatOptions_0 = TextFormatOptions.FirstCapital;
						break;
					case "title case":
						this.textFormatOptions_0 = TextFormatOptions.TitleCase;
						break;
					case "lowercase":
						this.textFormatOptions_0 = TextFormatOptions.Lowercase;
						break;
					case "uppercase":
						this.textFormatOptions_0 = TextFormatOptions.Uppercase;
						break;
					}
				}
				else if (text.Contains("w:type w:val"))
				{
					switch (text.Split('"').GetValue(1).ToString())
					{
					case "calculated":
						this.formTextBoxType_0 = FormTextBoxType.Calculation;
						break;
					case "currentTime":
						this.formTextBoxType_0 = FormTextBoxType.CurrentTime;
						break;
					case "currentDate":
						this.formTextBoxType_0 = FormTextBoxType.CurrentDate;
						break;
					case "date":
						this.formTextBoxType_0 = FormTextBoxType.Date;
						break;
					case "number":
						this.formTextBoxType_0 = FormTextBoxType.Number;
						break;
					case "regular":
						this.formTextBoxType_0 = FormTextBoxType.RegularText;
						break;
					}
				}
			}
		}

		protected override void SetParameters()
		{
			ArrayList arrayList = new ArrayList();
			arrayList.Add("w:name w:val=\"" + base.Name + "\"");
			if (this.bool_1)
			{
				arrayList.Add("w:calcOnExit w:val=\"" + this.bool_1 + "\"");
			}
			if (base.Text != "")
			{
				arrayList.Add("w:default w:val=\"" + base.Text + "\"");
			}
			if (this.string_1 != "")
			{
				arrayList.Add("w:helpText w:type=\"text\" w:val=\"" + this.string_1.ToString() + "\"");
			}
			if (this.string_2 != "")
			{
				arrayList.Add("w:statusText w:type=\"text\" w:val=\"" + this.string_2.ToString() + "\"");
			}
			if (this.bool_0)
			{
				arrayList.Add("w:enabled w:val=\"" + this.bool_0 + "\"");
			}
			if (this.textFormatOptions_0 != 0)
			{
				string text = "";
				switch (this.textFormatOptions_0)
				{
				case TextFormatOptions.Uppercase:
					text = "Uppercase";
					break;
				case TextFormatOptions.Lowercase:
					text = "Lowercase";
					break;
				case TextFormatOptions.FirstCapital:
					text = "First capital";
					break;
				case TextFormatOptions.TitleCase:
					text = "Title case";
					break;
				}
				arrayList.Add("w:format w:val=\"" + text + "\"");
			}
			if (this.int_0 != 0)
			{
				arrayList.Add("w:maxLength w:val=\"" + this.int_0 + "\"");
			}
			string text2 = "";
			switch (this.formTextBoxType_0)
			{
			case FormTextBoxType.RegularText:
				text2 = "regular";
				break;
			case FormTextBoxType.Number:
				text2 = "number";
				break;
			case FormTextBoxType.Date:
				text2 = "date";
				break;
			case FormTextBoxType.CurrentDate:
				text2 = "currentDate";
				break;
			case FormTextBoxType.CurrentTime:
				text2 = "currentTime";
				break;
			case FormTextBoxType.Calculation:
				text2 = "calculated";
				break;
			}
			arrayList.Add("w:type w:val=\"" + text2 + "\"");
			this.string_0 = arrayList.ToArray(System.Type.GetType("System.String")) as string[];
			base.ApplicationField.Parameters = this.string_0;
		}
	}
}
