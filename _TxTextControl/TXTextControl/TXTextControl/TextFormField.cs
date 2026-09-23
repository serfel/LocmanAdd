using System.ComponentModel;
using ns21;

namespace TXTextControl
{
	/// <summary>An object of the TextFormField class represents a text input field on a form.</summary>
	public class TextFormField : FormField
	{
		/// <summary>Gets or sets the horizontal extension, in twips, of the form field, when it is empty.</summary>
		[Browsable(false)]
		public int EmptyWidth
		{
			get
			{
				return base.Int32_1;
			}
			set
			{
				base.Int32_1 = value;
			}
		}

		/// <summary>Initializes a new instance of the TextFormField class.</summary>
		/// <param name="emptyWidth">Specifies the horizontal extension, in twips, of the form field, when it is empty.</param>
		public TextFormField(int emptyWidth)
		{
			base.Int32_1 = emptyWidth;
			base.enum105_0 = Enum105.const_10;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal TextFormField(TextControlCore textControlCore_1, TextPart iTextPart, int iFieldID)
			: base(textControlCore_1, iTextPart, iFieldID)
		{
			base.enum105_0 = Enum105.const_10;
		}
	}
}
