using System.ComponentModel;
using ns1;
using TXTextControl;

namespace DocumentServer.Fields
{
	/// <summary>The abstract MailMergeFieldAdapter class is the base class of all special DocumentServer mail merge field adapters.</summary>
	public abstract class MailMergeFieldAdapter : FieldAdapter
	{
		protected bool m_bPreserveFormatting;

		/// <summary>Specifies whether the field's formatting should be preserved.</summary>
		[Category("Appearance")]
		[Attribute1("PROP_FIELD_PRESERVEFORMATTING")]
		public bool PreserveFormatting
		{
			get
			{
				return this.m_bPreserveFormatting;
			}
			set
			{
				this.m_bPreserveFormatting = value;
				this.SetParameters();
			}
		}

		/// <summary>Initializes a new instance of the MailMergeFieldAdapter class with a connection to an existing ApplicationField.</summary>
		/// <param name="appField">Specifies the to-be-adapted ApplicationField.</param>
		public MailMergeFieldAdapter(ApplicationField appField)
			: base(appField)
		{
		}

		/// <summary>Initializes a complete new instance of the MailMergeFieldAdapter class without a connection to an existing ApplicationField.</summary>
		public MailMergeFieldAdapter()
		{
		}

		protected bool Equals(MailMergeFieldAdapter field)
		{
			if (field == null)
			{
				return false;
			}
			if (field.PreserveFormatting == this.PreserveFormatting)
			{
				return base.Equals(field);
			}
			return false;
		}
	}
}
