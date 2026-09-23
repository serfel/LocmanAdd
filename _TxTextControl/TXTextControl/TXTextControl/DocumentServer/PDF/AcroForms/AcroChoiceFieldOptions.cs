using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace DocumentServer.PDF.AcroForms
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public class AcroChoiceFieldOptions
	{
		[CompilerGenerated]
		private string[] string_0;

		[XmlElement("ChoiceFieldElement")]
		public string[] ChoiceFieldElements
		{
			[CompilerGenerated]
			get
			{
				return this.string_0;
			}
			[CompilerGenerated]
			set
			{
				this.string_0 = value;
			}
		}
	}
}
