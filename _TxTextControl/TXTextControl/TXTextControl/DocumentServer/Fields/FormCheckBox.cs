using System;
using System.Collections.Generic;
using System.ComponentModel;
using ns1;
using DocumentServer.Properties;
using TXTextControl;

namespace DocumentServer.Fields
{
	/// <summary>The FormText implements the MS Word specific FORMCHECKBOX field.</summary>
	public class FormCheckBox : FormFieldAdapter
	{
		public new const string TYPE_NAME = "FORMCHECKBOX";

		private int int_0;

		private bool bool_0;

		private bool bool_1 = true;

		private bool bool_2;

		private bool bool_3;

		private string string_0 = "";

		private string string_1 = "";

		[Category("Properties")]
		public override string TypeName => "FORMCHECKBOX";

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

		/// <summary>Specifies the maximum length of the field.</summary>
		[Category("Properties")]
		[Attribute1("PROP_FRMCHKBOX_SIZE")]
		public int Size
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
				this.SetParameters();
			}
		}

		[Category("Properties")]
		[Attribute1("PROP_FIELD_ENABLED")]
		public override bool Enabled
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

		/// <summary>Specifies whether the field is automatically resized or not.</summary>
		[Category("Properties")]
		[Attribute1("PROP_FRMCHKBOX_SIZEAUTO")]
		public bool SizeAuto
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

		/// <summary>Specifies whether the field is checked or not.</summary>
		[Category("Properties")]
		[Attribute1("PROP_FRMCHKBOX_CHECKED")]
		public bool Checked
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				this.bool_2 = value;
				base.ApplicationField.Text = (this.Checked ? "þ" : "\u00a8");
				this.SetParameters();
			}
		}

		[Category("Properties")]
		[Attribute1("PROP_FIELD_CALCONEXIT")]
		public override bool CalcOnExit
		{
			get
			{
				return this.bool_3;
			}
			set
			{
				this.bool_3 = value;
				this.SetParameters();
			}
		}

		/// <summary>Initializes a new instance of the FormText class with a connection to an existing ApplicationField.</summary>
		/// <param name="appField">Specifies the ApplicationField to be adapted.</param>
		public FormCheckBox(ApplicationField appField)
			: base(appField)
		{
			if (string.Compare(appField.TypeName, "FORMCHECKBOX") != 0)
			{
				throw new ArgumentException(string.Format(Resources.EXC_APPFIELD_TYPE_MISMATCH, "FORMCHECKBOX"));
			}
			this.GetParameters();
		}

		/// <summary>Initializes a complete new instance of the FormText class without a connection to an existing ApplicationField.</summary>
		public FormCheckBox()
		{
			this.GetParameters();
		}

		protected override void GenerateAppField()
		{
			base.ApplicationField = new ApplicationField(ApplicationFieldFormat.MSWord, "FORMCHECKBOX", "{FORMCHECKBOX}", new string[1] { "FORMCHECKBOX" });
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
				else if (text.Contains("w:size w:val"))
				{
					this.int_0 = Convert.ToInt32(text.Split('"').GetValue(1));
				}
				else if (text.Contains("w:enabled w:val"))
				{
					this.bool_1 = Convert.ToBoolean(text.Split('"').GetValue(1));
				}
				else if (text.Contains("w:default w:val"))
				{
					this.bool_2 = Convert.ToBoolean(text.Split('"').GetValue(1));
				}
				else if (text.Contains("w:sizeAuto w:val"))
				{
					this.bool_0 = Convert.ToBoolean(text.Split('"').GetValue(1));
				}
				else if (text.Contains("w:calcOnExit w:val"))
				{
					this.bool_3 = Convert.ToBoolean(text.Split('"').GetValue(1));
				}
				else if (text.Contains("w:helpText w:type=\"text\" w:val"))
				{
					this.string_0 = text.Split('"').GetValue(3).ToString();
				}
				else if (text.Contains("w:statusText w:type=\"text\" w:val"))
				{
					this.string_1 = text.Split('"').GetValue(3).ToString();
				}
			}
		}

		protected override void SetParameters()
		{
			List<string> list = new List<string>();
			list.Add("w:name w:val=\"" + base.Name + "\"");
			list.Add("w:calcOnExit w:val=\"" + this.bool_3 + "\"");
			list.Add("w:enabled w:val=\"" + this.bool_1 + "\"");
			if (this.int_0 != 0)
			{
				list.Add("w:size w:val=\"" + this.int_0 + "\"");
			}
			list.Add("w:default w:val=\"" + this.bool_2 + "\"");
			if (this.bool_0)
			{
				list.Add("w:sizeAuto w:val=\"" + this.bool_0 + "\"");
			}
			if (this.string_0 != "")
			{
				list.Add("w:helpText w:type=\"text\" w:val=\"" + this.string_0 + "\"");
			}
			if (this.string_1 != "")
			{
				list.Add("w:statusText w:type=\"text\" w:val=\"" + this.string_1 + "\"");
			}
			base.ApplicationField.Parameters = list.ToArray();
		}
	}
}
