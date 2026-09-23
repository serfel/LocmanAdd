using System;
using System.Collections.Generic;
using System.ComponentModel;
using ns1;
using DocumentServer.Properties;
using TXTextControl;

namespace DocumentServer.Fields
{
	/// <summary>The DateField implements the MS Word specific DATEFIELD field.</summary>
	public sealed class DateField : MailMergeFieldAdapter
	{
		public new const string TYPE_NAME = "DATE";

		private DateTime dateTime_0;

		private string string_0 = string.Empty;

		[Category("Properties")]
		public override string TypeName => "DATE";

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

		/// <summary>Sets the date of the field.</summary>
		[Category("Properties")]
		[Attribute1("PROP_DATEFIELD_DATE")]
		public DateTime Date
		{
			get
			{
				return this.dateTime_0;
			}
			set
			{
				this.dateTime_0 = value;
				try
				{
					this.Text = this.dateTime_0.ToString(this.Format);
				}
				catch (FormatException)
				{
					this.Text = this.dateTime_0.ToShortDateString();
				}
				this.SetParameters();
			}
		}

		/// <summary>Gets and sets the format of the field.</summary>
		[Category("Appearance")]
		[Attribute1("PROP_DATEFIELD_FORMAT")]
		public string Format
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
				this.SetParameters();
			}
		}

		/// <summary>Initializes new instance of the DateField class with a connection to an existing ApplicationField.</summary>
		/// <param name="appField">Specifies the ApplicationField to be adapted.</param>
		public DateField(ApplicationField appField)
			: base(appField)
		{
			if (string.Compare(appField.TypeName, "DATE") != 0)
			{
				throw new ArgumentException(string.Format(Resources.EXC_APPFIELD_TYPE_MISMATCH, "DATE"));
			}
			this.GetParameters();
		}

		internal DateField(DateField dateField)
			: this(dateField.ApplicationField)
		{
			this.Format = dateField.Format;
			this.Date = dateField.Date;
		}

		/// <summary>Initializes a complete new instance of the DateField class without a connection to an existing ApplicationField.</summary>
		public DateField()
		{
		}

		protected override void GenerateAppField()
		{
			base.ApplicationField = new ApplicationField(ApplicationFieldFormat.MSWord, "DATE", "{DATE}", new string[0]);
		}

		protected override void SetParameters()
		{
			List<string> list = new List<string>();
			if (this.string_0 != string.Empty)
			{
				list.Add("\\@ \"" + this.string_0 + "\"");
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
			this.string_0 = base.ApplicationField.Parameters[0];
			if (this.string_0.StartsWith("\\@ "))
			{
				this.string_0 = this.string_0.Remove(0, 4).Trim('"');
			}
			string[] parameters = base.ApplicationField.Parameters;
			for (int i = 0; i < parameters.Length; i++)
			{
				if (parameters[i].Contains("\\* MERGEFORMAT"))
				{
					base.m_bPreserveFormatting = true;
				}
			}
		}

		internal bool method_0(DateField dateField_0)
		{
			if (dateField_0 == null)
			{
				return false;
			}
			if (dateField_0.dateTime_0 == this.dateTime_0 && dateField_0.string_0 == this.string_0 && dateField_0.Text == this.Text)
			{
				return base.Equals(dateField_0);
			}
			return false;
		}
	}
}
