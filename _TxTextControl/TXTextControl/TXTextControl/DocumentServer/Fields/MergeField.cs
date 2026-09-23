using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using ns1;
using DocumentServer.DataSources;
using DocumentServer.Properties;
using TXTextControl;

namespace DocumentServer.Fields
{
	/// <summary>The MergeField class implements the MS Word specific MERGEFIELD field.</summary>
	[DebuggerDisplay("Name: {Name}")]
	public sealed class MergeField : MailMergeFieldAdapter
	{
		public new const string TYPE_NAME = "MERGEFIELD";

		private string string_0 = string.Empty;

		private string string_1 = string.Empty;

		private string string_2 = string.Empty;

		private string string_3 = string.Empty;

		private string string_4 = string.Empty;

		private IFormatProvider iformatProvider_0 = CultureInfo.CurrentCulture;

		private bool bool_0;

		private bool bool_1;

		private TextFormatOptions textFormatOptions_0;

		[Category("Properties")]
		public override string TypeName => "MERGEFIELD";

		/// <summary>Gets and sets the name of the field.</summary>
		[Category("Properties")]
		[Attribute1("PROP_FIELD_NAME")]
		public string Name
		{
			get
			{
				return base.ApplicationField.Name ?? string.Empty;
			}
			set
			{
				base.ApplicationField.Name = value ?? string.Empty;
				this.SetParameters();
			}
		}

		/// <summary>Gets and sets the text of the field.</summary>
		[Category("Properties")]
		[Attribute1("PROP_FIELD_TEXT")]
		public string Text
		{
			get
			{
				string text = base.ApplicationField.Text ?? string.Empty;
				if (text.StartsWith(this.TextBefore, ignoreCase: true, CultureInfo.CurrentCulture))
				{
					text = text.Substring(this.TextBefore.Length, Math.Max(0, text.Length - this.TextBefore.Length));
				}
				if (text.EndsWith(this.TextAfter, ignoreCase: true, CultureInfo.CurrentCulture))
				{
					text = text.Substring(0, Math.Max(0, text.Length - this.TextAfter.Length));
				}
				return text;
			}
			set
			{
				value = value ?? string.Empty;
				this.string_4 = value;
				if (value.Length == 0)
				{
					base.ApplicationField.Text = "";
					return;
				}
				decimal result2;
				if (this.string_2.Length != 0)
				{
					if (DateTime.TryParse(value, this.iformatProvider_0, DateTimeStyles.None, out var result))
					{
						try
						{
							value = result.ToString(this.method_1(this.string_2));
						}
						catch
						{
						}
					}
				}
				else if (this.string_3.Length != 0 && decimal.TryParse(value, NumberStyles.Float, this.iformatProvider_0, out result2))
				{
					try
					{
						value = result2.ToString(this.string_3);
					}
					catch
					{
					}
				}
				if (this.TextBefore != string.Empty && !value.StartsWith(this.TextBefore, StringComparison.OrdinalIgnoreCase))
				{
					value = $"{this.TextBefore}{value}";
				}
				if (this.TextAfter != string.Empty && !value.ToLower().EndsWith(this.TextAfter.ToLower()))
				{
					value = $"{value}{this.TextAfter}";
				}
				switch (this.textFormatOptions_0)
				{
				case TextFormatOptions.Uppercase:
					value = value.ToUpper();
					break;
				case TextFormatOptions.Lowercase:
					value = value.ToLower();
					break;
				case TextFormatOptions.FirstCapital:
				{
					TextInfo textInfo = new CultureInfo("en-US", useUserOverride: false).TextInfo;
					value = ((!value.All((char char_0) => !char.IsLetter(char_0) || char.IsUpper(char_0))) ? (textInfo.ToUpper(value.Substring(0, 1)) + value.Substring(1)) : (textInfo.ToUpper(value.Substring(0, 1)) + textInfo.ToLower(value.Substring(1))));
					break;
				}
				case TextFormatOptions.TitleCase:
				{
					TextInfo textInfo = new CultureInfo("en-US", useUserOverride: false).TextInfo;
					value = textInfo.ToLower(value);
					value = textInfo.ToTitleCase(value);
					break;
				}
				}
				base.ApplicationField.Text = value;
			}
		}

		/// <summary>Gets and sets the text format of the field.</summary>
		[Category("Appearance")]
		[Attribute1("PROP_MERGEFLD_TEXTFORMAT")]
		public TextFormatOptions TextFormat
		{
			get
			{
				return this.textFormatOptions_0;
			}
			set
			{
				this.textFormatOptions_0 = value;
				this.Text = this.string_4;
				this.SetParameters();
			}
		}

		/// <summary>Gets and sets the text of the field that is displayed before the field's text.</summary>
		[Category("Appearance")]
		[Attribute1("PROP_MERGEFLD_TEXTBEFORE")]
		public string TextBefore
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value ?? string.Empty;
				this.Text = this.string_4;
				this.SetParameters();
			}
		}

		/// <summary>Gets and sets the text of the field that is displayed after the field's text.</summary>
		[Category("Appearance")]
		[Attribute1("PROP_MERGEFLD_TEXTAFTER")]
		public string TextAfter
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value ?? string.Empty;
				this.Text = this.string_4;
				this.SetParameters();
			}
		}

		/// <summary>Specifies whether the field is a mapped field.</summary>
		[Category("Properties")]
		[Attribute1("PROP_MERGEFLD_MAPPED")]
		public bool Mapped
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

		/// <summary>Specifies a string format which is applied to date / time values.</summary>
		[Category("Appearance")]
		[Attribute1("PROP_MERGEFLD_DATETIMEFORMAT")]
		public string DateTimeFormat
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value ?? string.Empty;
				this.Text = this.string_4;
				this.SetParameters();
			}
		}

		/// <summary>Specifies a string format which is applied to numeric values.</summary>
		[Category("Appearance")]
		[Attribute1("PROP_MERGEFLD_NUMERICFORMAT")]
		public string NumericFormat
		{
			get
			{
				return this.string_3;
			}
			set
			{
				this.string_3 = value ?? string.Empty;
				this.Text = this.string_4;
				this.SetParameters();
			}
		}

		/// <summary>Specifies whether the field's formatting is vertical.</summary>
		[Category("Appearance")]
		[Attribute1("PROP_MERGEFLD_VERTICALFORMATTING")]
		public bool VerticalFormatting
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

		internal bool Boolean_0 => this.Name.IsChildColumnName();

		internal string[] String_0 => this.Name.ToChildTableNames();

		internal string String_1 => this.Name.ToChildColumnName();

		internal IFormatProvider IFormatProvider_0
		{
			get
			{
				return this.iformatProvider_0;
			}
			set
			{
				this.iformatProvider_0 = value;
				this.Text = this.string_4;
				this.SetParameters();
			}
		}

		/// <summary>nitializes a new instance of the MergeField class with a connection to an existing ApplicationField.</summary>
		/// <param name="appField">Specifies the ApplicationField to be adapted.</param>
		public MergeField(ApplicationField appField)
			: base(appField)
		{
			if (string.Compare(appField.TypeName, "MERGEFIELD") != 0)
			{
				throw new ArgumentException(string.Format(Resources.EXC_APPFIELD_TYPE_MISMATCH, "MERGEFIELD"));
			}
			this.GetParameters();
		}

		internal MergeField(MergeField mergeField)
			: this(mergeField.ApplicationField)
		{
			this.TextFormat = mergeField.TextFormat;
			this.TextBefore = mergeField.TextBefore;
			this.TextAfter = mergeField.TextAfter;
			this.DateTimeFormat = mergeField.DateTimeFormat;
			this.NumericFormat = mergeField.NumericFormat;
			this.Text = mergeField.Text;
		}

		/// <summary>Initializes a complete new instance of the MergeField class without a connection to an existing ApplicationField.</summary>
		public MergeField()
		{
			this.GetParameters();
		}

		protected override void GenerateAppField()
		{
			base.ApplicationField = new ApplicationField(ApplicationFieldFormat.MSWord, "MERGEFIELD", "{MERGEFIELD}", new string[1] { "MERGEFIELD" });
		}

		protected override void SetParameters()
		{
			List<string> list = new List<string>();
			list.Add(this.Name);
			if (this.bool_0)
			{
				list.Add("\\m");
			}
			if (this.bool_1)
			{
				list.Add("\\v");
			}
			if (this.string_1 != string.Empty)
			{
				list.Add("\\f \"" + this.string_1 + "\"");
			}
			if (this.string_0 != string.Empty)
			{
				list.Add("\\b \"" + this.string_0 + "\"");
			}
			if (this.string_2 != string.Empty)
			{
				list.Add("\\@ \"" + this.string_2 + "\"");
			}
			if (this.string_3 != string.Empty)
			{
				list.Add("\\# \"" + this.string_3 + "\"");
			}
			if (this.textFormatOptions_0 != 0)
			{
				switch (this.textFormatOptions_0)
				{
				case TextFormatOptions.Uppercase:
					list.Add("\\* Upper");
					break;
				case TextFormatOptions.Lowercase:
					list.Add("\\* Lower");
					break;
				case TextFormatOptions.FirstCapital:
					list.Add("\\* FirstCap");
					break;
				case TextFormatOptions.TitleCase:
					list.Add("\\* Caps");
					break;
				}
			}
			if (base.m_bPreserveFormatting)
			{
				list.Add("\\* MERGEFORMAT");
			}
			base.ApplicationField.Parameters = list.ToArray();
		}

		protected override void GetParameters()
		{
			if (base.ApplicationField.Parameters == null)
			{
				return;
			}
			string text = base.ApplicationField.Parameters[0];
			if (!base.ApplicationField.Name.Equals(text, StringComparison.OrdinalIgnoreCase))
			{
				base.ApplicationField.Name = text;
			}
			string[] parameters = base.ApplicationField.Parameters;
			foreach (string text2 in parameters)
			{
				if (text2.Contains("\\m"))
				{
					this.bool_0 = true;
				}
				if (text2.Contains("\\@"))
				{
					this.string_2 = text2.Substring(4, Math.Max(0, text2.Length - 5));
				}
				if (text2.Contains("\\#"))
				{
					this.string_3 = text2.Substring(4, Math.Max(0, text2.Length - 5));
				}
				if (text2.Contains("\\v"))
				{
					this.bool_1 = true;
				}
				if (text2.Contains("\\b"))
				{
					this.string_0 = text2.Substring(4, Math.Max(0, text2.Length - 5));
				}
				else if (text2.Contains("\\f"))
				{
					this.string_1 = text2.Substring(4, Math.Max(0, text2.Length - 5));
				}
				else if (text2.Contains("\\*"))
				{
					switch (text2.Substring(3, Math.Max(0, text2.Length - 3)))
					{
					case "MERGEFORMAT":
						base.m_bPreserveFormatting = true;
						break;
					case "Caps":
						this.textFormatOptions_0 = TextFormatOptions.TitleCase;
						break;
					case "FirstCap":
						this.textFormatOptions_0 = TextFormatOptions.FirstCapital;
						break;
					case "Lower":
						this.textFormatOptions_0 = TextFormatOptions.Lowercase;
						break;
					case "Upper":
						this.textFormatOptions_0 = TextFormatOptions.Uppercase;
						break;
					}
				}
			}
			this.string_4 = base.ApplicationField.Text;
			if (this.string_4.StartsWith(this.string_0))
			{
				this.string_4 = this.string_4.Substring(this.string_0.Length);
			}
			if (this.string_4.EndsWith(this.string_1))
			{
				this.string_4 = this.string_4.Substring(0, this.string_4.Length - this.string_1.Length);
			}
		}

		internal bool method_0(MergeField mergeField_0)
		{
			if (mergeField_0 == null)
			{
				return false;
			}
			if (mergeField_0.bool_0 == this.bool_0 && mergeField_0.bool_1 == this.bool_1 && mergeField_0.Name == this.Name && mergeField_0.Text == this.Text && mergeField_0.string_1 == this.string_1 && mergeField_0.string_0 == this.string_0 && mergeField_0.textFormatOptions_0 == this.textFormatOptions_0)
			{
				return base.Equals(mergeField_0);
			}
			return false;
		}

		private string method_1(string string_5)
		{
			int num = -1;
			for (int i = 0; i < string_5.Length; i++)
			{
				if (string_5[i] == '\'')
				{
					num = ((num == -1) ? i : (-1));
				}
			}
			if (num != -1)
			{
				string_5 = string_5.Insert(num, "\"");
				string_5 = ((string_5.Length <= num + 2) ? (string_5 + "\"") : string_5.Insert(num + 2, "\""));
			}
			return string_5;
		}
	}
}
