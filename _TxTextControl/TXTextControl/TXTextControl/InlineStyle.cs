using System;
using System.ComponentModel;
using ns21;

namespace TXTextControl
{
	/// <summary>The InlineStyle object defines a formatting style that can be used to format single words in a line of text.</summary>
	public sealed class InlineStyle : FormattingStyle
	{
		/// <summary>Determines the style's attributes.</summary>
		[Flags]
		public enum Attributes
		{
			/// <summary>Specifies the attribute set through the style's FontName property.</summary>
			FontName = 0x1,
			/// <summary>Specifies the attribute set through the style's FontSize property.</summary>
			FontSize = 0x2,
			/// <summary>Specifies the attribute set through the style's Bold property.</summary>
			Bold = 0x4,
			/// <summary>Specifies the attribute set through the style's Italic property.</summary>
			Italic = 0x8,
			/// <summary>Specifies the attribute set through the style's Underline property.</summary>
			Underline = 0x10,
			/// <summary>Specifies the attribute set through the style's Strikeout property.</summary>
			Strikeout = 0x20,
			/// <summary>Specifies the attribute set through the style's Baseline property.</summary>
			Baseline = 0x40,
			/// <summary>Specifies the attribute set through the style's ForeColor property.</summary>
			ForeColor = 0x80,
			/// <summary>Specifies the attribute set through the style's TextBackColor property.</summary>
			TextBackColor = 0x100
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal InlineStyle(TextControlCore textControlCore_1, string name)
			: base(textControlCore_1, name, Enum58.const_1)
		{
		}

		/// <summary>Creates a new instance of the InlineStyle class based on the TextControl root style named [Normal].</summary>
		/// <param name="name">Specifies the new style's name.</param>
		public InlineStyle(string name)
			: base(name, string.Empty, Enum58.const_1)
		{
		}

		/// <summary>Creates a new instance of the InlineStyle class based on the specified base style.</summary>
		/// <param name="name">Specifies the new style's name.</param>
		/// <param name="baseStyle">Specifies the name of the style the new style based on.</param>
		public InlineStyle(string name, string baseStyle)
			: base(name, baseStyle, Enum58.const_1)
		{
		}

		/// <summary>Creates a new root style that has all attributes of the specified style.</summary>
		/// <param name="style">Is a style the attributes of which are used to initialize the new style.</param>
		public InlineStyle(InlineStyle style)
			: base(style)
		{
		}

		public bool IsInheritedFromParagraph(Attributes attributes)
		{
			return ((uint)base.enum59_1 & (uint)attributes) != 0;
		}

		public void ResetToParagraph(Attributes attributes)
		{
			base.uint_0 |= (uint)attributes;
		}
	}
}
