using System.ComponentModel;
using ns21;

namespace TXTextControl
{
	/// <summary>The ParagraphStyle class defines a formatting style for paragraphs.</summary>
	public sealed class ParagraphStyle : FormattingStyle
	{
		/// <summary>Gets or sets the name of the style that TextControl automatically selects for the following paragraph after the user has pressed the ENTER key.</summary>
		public string FollowingStyle
		{
			get
			{
				return base.string_3;
			}
			set
			{
				base.enum59_0 |= Enum59.flag_10;
				base.string_3 = value;
			}
		}

		/// <summary>Gets or sets the style's bulleted or numbered list and/or its formatting attributes.</summary>
		public ListFormat ListFormat
		{
			get
			{
				return base.listFormat_0;
			}
			set
			{
				value.method_3(base.listFormat_0);
			}
		}

		/// <summary>Gets or sets the style's paragraph attributes.</summary>
		public ParagraphFormat ParagraphFormat
		{
			get
			{
				return base.paragraphFormat_0;
			}
			set
			{
				value.method_3(base.paragraphFormat_0);
			}
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal ParagraphStyle(TextControlCore textControlCore_1, string name)
			: base(textControlCore_1, name, Enum58.const_0)
		{
		}

		/// <summary>Creates a new instance of the ParagraphStyle class based on the TextControl root style named [Normal].</summary>
		/// <param name="name">Specifies the new style's name.</param>
		public ParagraphStyle(string name)
			: base(name, string.Empty, Enum58.const_0)
		{
		}

		/// <summary>Creates a new instance of the ParagraphStyle class based on the specified base style.</summary>
		/// <param name="name">Specifies the new style's name.</param>
		/// <param name="baseStyle">Specifies the name of the style the new style is based on.</param>
		public ParagraphStyle(string name, string baseStyle)
			: base(name, baseStyle, Enum58.const_0)
		{
		}

		/// <summary>Creates a new root style that has all attributes of the specified style.</summary>
		/// <param name="style">Is a style the attributes of which are used to initialize the new style.</param>
		public ParagraphStyle(ParagraphStyle style)
			: base(style)
		{
		}
	}
}
