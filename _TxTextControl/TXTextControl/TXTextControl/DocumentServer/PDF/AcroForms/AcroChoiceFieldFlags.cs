using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace DocumentServer.PDF.AcroForms
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AcroChoiceFieldFlags
	{
		[CompilerGenerated]
		private bool bool_0;

		[CompilerGenerated]
		private bool bool_1;

		[CompilerGenerated]
		private bool bool_2;

		[CompilerGenerated]
		private bool bool_3;

		[CompilerGenerated]
		private bool bool_4;

		[CompilerGenerated]
		private bool bool_5;

		[XmlAttribute("IsComboBox", DataType = "boolean")]
		public bool IsComboBox
		{
			[CompilerGenerated]
			get
			{
				return this.bool_0;
			}
			[CompilerGenerated]
			set
			{
				this.bool_0 = value;
			}
		}

		[XmlAttribute("CanEdit", DataType = "boolean")]
		public bool CanEdit
		{
			[CompilerGenerated]
			get
			{
				return this.bool_1;
			}
			[CompilerGenerated]
			set
			{
				this.bool_1 = value;
			}
		}

		[XmlAttribute("Sort", DataType = "boolean")]
		public bool Sort
		{
			[CompilerGenerated]
			get
			{
				return this.bool_2;
			}
			[CompilerGenerated]
			set
			{
				this.bool_2 = value;
			}
		}

		[XmlAttribute("MultiSelect", DataType = "boolean")]
		public bool MultiSelect
		{
			[CompilerGenerated]
			get
			{
				return this.bool_3;
			}
			[CompilerGenerated]
			set
			{
				this.bool_3 = value;
			}
		}

		[XmlAttribute("DoNotSpellCheck", DataType = "boolean")]
		public bool DoNotSpellCheck
		{
			[CompilerGenerated]
			get
			{
				return this.bool_4;
			}
			[CompilerGenerated]
			set
			{
				this.bool_4 = value;
			}
		}

		[XmlAttribute("CommitOnSelChange", DataType = "boolean")]
		public bool CommitOnSelChange
		{
			[CompilerGenerated]
			get
			{
				return this.bool_5;
			}
			[CompilerGenerated]
			set
			{
				this.bool_5 = value;
			}
		}
	}
}
