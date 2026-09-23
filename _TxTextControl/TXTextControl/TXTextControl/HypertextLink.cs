using System.ComponentModel;
using ns21;

namespace TXTextControl
{
	/// <summary>The HypertextLink class represents a hypertext link in a Text Control document that points to a target outside of the document.</summary>
	public class HypertextLink : TextField
	{
		/// <summary>Gets or sets a string that specifies the target to where the hypertext link points.</summary>
		[Browsable(false)]
		public string Target
		{
			get
			{
				return base.String_0;
			}
			set
			{
				base.String_0 = value;
			}
		}

		/// <summary>Initializes a new instance of the HypertextLink class.</summary>
		/// <param name="text">Specifies the visible text of the hypertext link.</param>
		/// <param name="target">Specifies a string specifying to where the hypertext link points.</param>
		public HypertextLink(string text, string target)
			: base(text)
		{
			base.String_0 = target;
			base.enum105_0 = Enum105.const_1;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal HypertextLink(TextControlCore textControlCore_1, TextPart iTextPart, int iFieldID)
			: base(textControlCore_1, iTextPart, iFieldID)
		{
			base.enum105_0 = Enum105.const_1;
		}
	}
}
