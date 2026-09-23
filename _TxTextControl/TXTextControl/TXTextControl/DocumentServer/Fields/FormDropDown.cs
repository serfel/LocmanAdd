using System;
using System.Collections.Generic;
using System.ComponentModel;
using ns1;
using DocumentServer.Properties;
using TXTextControl;

namespace DocumentServer.Fields
{
	/// <summary>The FormDropDown class implements the MS Word specific FORMDROPDOWN field.</summary>
	public class FormDropDown : FormFieldAdapter
	{
		public new const string TYPE_NAME = "FORMDROPDOWN";

		private bool bool_0;

		private bool bool_1;

		private string string_0 = "";

		private string string_1 = "";

		private List<string> list_0;

		[Category("Properties")]
		public override string TypeName => "FORMDROPDOWN";

		[Category("Properties")]
		[Attribute1("PROP_FIELD_HELPTEXT")]
		public override string HelpText
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

		/// <summary>Gets and sets the list entries of the drop down field.</summary>
		[Category("Properties")]
		[Attribute1("PROP_FRMDRPDN_LISTENTRIES")]
		public IEnumerable<string> ListEntries
		{
			get
			{
				if (this.list_0 == null)
				{
					this.list_0 = new List<string>();
				}
				return this.list_0;
			}
			set
			{
				this.list_0 = new List<string>(value);
				this.SetParameters();
			}
		}

		[Category("Properties")]
		[Attribute1("PROP_FIELD_STATUSTEXT")]
		public override string StatusText
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

		/// <summary>Initializes a new instance of the FormDropDown class with a connection to an existing ApplicationField.</summary>
		/// <param name="appField">Specifies the ApplicationField to be adapted.</param>
		public FormDropDown(ApplicationField appField)
			: base(appField)
		{
			if (string.Compare(appField.TypeName, "FORMDROPDOWN") != 0)
			{
				throw new ArgumentException(string.Format(Resources.EXC_APPFIELD_TYPE_MISMATCH, "FORMDROPDOWN"));
			}
			this.list_0 = new List<string>();
			this.GetParameters();
		}

		/// <summary>Initializes a complete new instance of the FormDropDown class without a connection to an existing ApplicationField.</summary>
		public FormDropDown()
		{
		}

		protected override void GenerateAppField()
		{
			base.ApplicationField = new ApplicationField(ApplicationFieldFormat.MSWord, "FORMDROPDOWN", "{FORMDROPDOWN}", new string[0]);
		}

		protected override void GetParameters()
		{
			if (base.ApplicationField.Parameters == null)
			{
				return;
			}
			string[] parameters = base.ApplicationField.Parameters;
			foreach (string text in parameters)
			{
				if (text.Contains("w:name w:val"))
				{
					base.Name = text.Split('"').GetValue(1).ToString();
				}
				else if (text.Contains("w:enabled w:val"))
				{
					this.bool_0 = Convert.ToBoolean(text.Split('"').GetValue(1));
				}
				else if (text.Contains("w:calcOnExit w:val"))
				{
					this.bool_1 = Convert.ToBoolean(text.Split('"').GetValue(1));
				}
				else if (text.Contains("w:helpText w:type=\"text\" w:val"))
				{
					this.string_0 = text.Split('"').GetValue(3).ToString();
				}
				else if (text.Contains("w:statusText w:type=\"text\" w:val"))
				{
					this.string_1 = text.Split('"').GetValue(3).ToString();
				}
				else if (text.Contains("w:listEntry w:val="))
				{
					this.list_0.Add(text.Split('"').GetValue(1).ToString());
				}
			}
		}

		protected override void SetParameters()
		{
			List<string> list = new List<string>();
			list.Add("w:name w:val=\"" + base.Name + "\"");
			if (this.bool_1)
			{
				list.Add("w:calcOnExit w:val=\"" + this.bool_1 + "\"");
			}
			if (this.bool_0)
			{
				list.Add("w:enabled w:val=\"" + this.bool_0 + "\"");
			}
			if (this.string_0 != "")
			{
				list.Add("w:helpText w:type=\"text\" w:val=\"" + this.string_0 + "\"");
			}
			if (this.string_1 != "")
			{
				list.Add("w:statusText w:type=\"text\" w:val=\"" + this.string_1 + "\"");
			}
			foreach (string item in this.list_0)
			{
				list.Add("w:listEntry w:val=\"" + item + "\"");
			}
			base.ApplicationField.Parameters = list.ToArray();
		}
	}
}
