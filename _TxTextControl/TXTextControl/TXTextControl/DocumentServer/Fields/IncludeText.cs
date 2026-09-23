using System;
using System.Collections.Generic;
using System.ComponentModel;
using ns1;
using DocumentServer.Properties;
using TXTextControl;

namespace DocumentServer.Fields
{
	/// <summary>The IncludeText class implements the MS Word specific INCLUDETEXT field.</summary>
	public sealed class IncludeText : MailMergeFieldAdapter
	{
		public new const string TYPE_NAME = "INCLUDETEXT";

		private string string_0;

		private string string_1;

		private TextFormatOptions textFormatOptions_0;

		[Category("Properties")]
		public override string TypeName => "INCLUDETEXT";

		/// <summary>Gets and sets the file name of the document that should be inserted.</summary>
		[Category("Properties")]
		[Attribute1("PROP_INCLTEXT_FILENAME")]
		public string Filename
		{
			get
			{
				return this.string_0.Replace("\\\\", "\\");
			}
			set
			{
				if (value.Contains("\\\\"))
				{
					this.string_0 = value;
				}
				else
				{
					this.string_0 = value.Replace("\\", "\\\\");
				}
				this.SetParameters();
			}
		}

		/// <summary>Gets and sets the bookmark switch of the field.</summary>
		[Category("Properties")]
		[Attribute1("PROP_INCLTEXT_BOOKMARK")]
		public string Bookmark
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

		/// <summary>Gets and sets the text format of the field.</summary>
		[Category("Appearance")]
		[Attribute1("PROP_INCLTEXT_TEXTFORMAT")]
		public TextFormatOptions TextFormat
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

		/// <summary>Initializes a new instance of the IncludeText class with a connection to an existing ApplicationField.</summary>
		/// <param name="appField">Specifies the ApplicationField to be adapted.</param>
		public IncludeText(ApplicationField appField)
			: base(appField)
		{
			if (string.Compare(appField.TypeName, "INCLUDETEXT") != 0)
			{
				throw new ArgumentException(string.Format(Resources.EXC_APPFIELD_TYPE_MISMATCH, "INCLUDETEXT"));
			}
			this.GetParameters();
		}

		/// <summary>Initializes a complete new instance of the IncludeText class without a connection to an existing ApplicationField.</summary>
		public IncludeText()
		{
			this.GetParameters();
		}

		protected override void GenerateAppField()
		{
			base.ApplicationField = new ApplicationField(ApplicationFieldFormat.MSWord, "INCLUDETEXT", "{INCLUDETEXT}", new string[1] { "INCLUDETEXT" });
		}

		protected override void SetParameters()
		{
			List<string> list = new List<string>();
			if (this.Filename != "")
			{
				list.Add(string.Format("{0}{1}{2}", "\"", this.Filename, "\""));
			}
			if (this.Bookmark != "" && this.Bookmark != null)
			{
				list.Add(this.Bookmark);
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
			this.string_0 = base.ApplicationField.Parameters[0].Replace("\"", "");
			if (base.ApplicationField.Parameters.Length > 1 && !base.ApplicationField.Parameters[1].Contains("\\*"))
			{
				this.string_1 = base.ApplicationField.Parameters[1];
			}
			string[] parameters = base.ApplicationField.Parameters;
			foreach (string text in parameters)
			{
				if (text.Contains("\\*"))
				{
					switch (text.Substring(3, Math.Max(0, text.Length - 3)))
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
		}

		internal bool method_0(IncludeText includeText_0)
		{
			if (includeText_0 == null)
			{
				return false;
			}
			if (includeText_0.string_1 == this.string_1 && includeText_0.string_0 == this.string_0 && includeText_0.textFormatOptions_0 == this.textFormatOptions_0)
			{
				return base.Equals(includeText_0);
			}
			return false;
		}
	}
}
