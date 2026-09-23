using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace DocumentServer.PDF.AcroForms
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AcroButtonFieldFlags
	{
		[CompilerGenerated]
		private bool bool_0;

		[CompilerGenerated]
		private bool bool_1;

		[XmlAttribute("IsRadio", DataType = "boolean")]
		public bool IsRadio
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

		[XmlAttribute("IsPushbutton", DataType = "boolean")]
		public bool IsPushbutton
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
	}
}
