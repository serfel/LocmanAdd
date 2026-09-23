using System;
using System.ComponentModel;
using DocumentServer.Properties;
using TXTextControl;

namespace DocumentServer.Fields
{
	/// <summary>The NextField class implements the MS Word specific NEXT field.</summary>
	public sealed class NextField : MailMergeFieldAdapter
	{
		public new const string TYPE_NAME = "NEXT";

		[Category("Properties")]
		public override string TypeName => "NEXT";

		/// <summary>Initializes a new instance of the NextField class with a connection to an existing ApplicationField.</summary>
		/// <param name="appField">Specifies the ApplicationField to be adapted.</param>
		public NextField(ApplicationField appField)
			: base(appField)
		{
			if (string.Compare(appField.TypeName, "NEXT") != 0)
			{
				throw new ArgumentException(string.Format(Resources.EXC_APPFIELD_TYPE_MISMATCH, "NEXT"));
			}
			this.GetParameters();
		}

		internal NextField(NextField field)
			: this(field.ApplicationField)
		{
		}

		/// <summary>Initializes a complete new instance of the NextField class without a connection to an existing ApplicationField.</summary>
		public NextField()
		{
		}

		protected override void GenerateAppField()
		{
			base.ApplicationField = new ApplicationField(ApplicationFieldFormat.MSWord, "NEXT", "{NEXT}", new string[0]);
		}

		protected override void SetParameters()
		{
			string[] parameters = new string[1] { base.PreserveFormatting ? "\\* MERGEFORMAT" : string.Empty };
			base.ApplicationField.Parameters = parameters;
		}

		protected override void GetParameters()
		{
			if (base.ApplicationField.Parameters != null)
			{
				base.m_bPreserveFormatting = base.ApplicationField.Parameters.Length >= 1 && base.ApplicationField.Parameters[0].Contains("\\* MERGEFORMAT");
			}
		}
	}
}
