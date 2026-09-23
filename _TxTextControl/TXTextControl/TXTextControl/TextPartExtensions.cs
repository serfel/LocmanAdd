using ns21;

namespace TXTextControl
{
	internal static class TextPartExtensions
	{
		public static string ToDescription(this TextPart iTextPart)
		{
			switch (iTextPart)
			{
			case TextPart.Auto:
				return "Automatic mode";
			case TextPart.MainText:
				return "Main text";
			default:
			{
				if (Class429.smethod_5((int)iTextPart) == 0)
				{
					return "Textframe: " + Class429.smethod_6((int)iTextPart);
				}
				TextPart textPart = (TextPart)Class429.smethod_5((int)iTextPart);
				return textPart.ToString() + ", Section: " + Class429.smethod_6((int)iTextPart);
			}
			}
		}
	}
}
