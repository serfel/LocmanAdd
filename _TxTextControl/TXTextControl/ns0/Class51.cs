using System.Collections.Generic;
using System.Text.RegularExpressions;
using TXTextControl.Barcode;

namespace ns0
{
	internal class Class51 : CodeGeneratorBase
	{
		private Class37 class37_0;

		private string string_0;

		internal override void UpdateBarcodeSettings(Class38 p_bstSettings)
		{
			string text = ((p_bstSettings.Text != null) ? p_bstSettings.Text : "01a");
			while (text.Length < p_bstSettings.UpperTextLength)
			{
				text += '0';
			}
			string string_ = p_bstSettings.String_1;
			p_bstSettings.Single_0 = this.GetBarcodeImage(p_bstSettings, text).float_0;
			p_bstSettings.String_1 = string_;
		}

		internal override bool IsTextValid(string input, int p_iMaxLength)
		{
			if (input.Length >= 3 && input.Length <= p_iMaxLength)
			{
				string pattern = "[a-zA-Z0-9 \\*\\-\\.!\"#$%&+'\\\\(),-:;<=>?\\[\\]\\{\\}\\@\\^_\\|\\~\\a\\b\\t\\n\\f\\r]{" + input.Length + "}";
				Regex regex = new Regex(pattern);
				if (regex.IsMatch(input))
				{
					return true;
				}
			}
			return false;
		}

		internal override Class37 GetBarcodeImage(Class38 p_bsSettings, string p_strText)
		{
			this.string_0 = p_strText;
			List<Class63> list = new List<Class63>();
			Class63 @class = new Class63(new int[6] { 2, 1, 1, 2, 1, 4 });
			@class.int_1 = 104;
			list.Add(@class);
			int num = @class.int_1;
			for (int i = 0; i < p_strText.Length; i++)
			{
				Class63 class2 = this.method_0(p_strText[i]);
				list.Add(class2);
				num += class2.int_1 * (i + 1);
			}
			num %= 103;
			Class63 item = this.method_1(num);
			Class63 class3 = new Class63(new int[7] { 2, 3, 3, 1, 1, 1, 2 });
			class3.int_1 = 106;
			list.Add(item);
			list.Add(class3);
			Class63[] class63_ = list.ToArray();
			Class64 class4 = new Class64();
			this.class37_0 = class4.method_13(class63_);
			p_bsSettings.String_1 = (p_bsSettings.Boolean_1 ? (p_strText + num) : p_strText);
			return this.class37_0;
		}

		private Class63 method_0(char char_0)
		{
			Class63 @class = new Class63(new int[0]);
			int num = 0;
			char[] array = new char[95]
			{
				' ', '!', '"', '#', '$', '%', '&', '\'', '(', ')',
				'*', '+', ',', '-', '.', '/', '0', '1', '2', '3',
				'4', '5', '6', '7', '8', '9', ':', ';', '<', '=',
				'>', '?', '@', 'A', 'B', 'C', 'D', 'E', 'F', 'G',
				'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q',
				'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '[',
				'$', ']', '^', '_', '`', 'a', 'b', 'c', 'd', 'e',
				'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o',
				'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y',
				'z', '{', '|', '}', '~'
			};
			int num2 = 0;
			while (true)
			{
				if (num2 < array.Length)
				{
					if (array[num2].Equals(char_0))
					{
						break;
					}
					num2++;
					continue;
				}
				return @class;
			}
			num = num2;
			switch (num)
			{
			case 0:
				@class = new Class63(new int[6] { 2, 1, 2, 2, 2, 2 });
				break;
			case 1:
				@class = new Class63(new int[6] { 2, 2, 2, 1, 2, 2 });
				break;
			case 2:
				@class = new Class63(new int[6] { 2, 2, 2, 2, 2, 1 });
				break;
			case 3:
				@class = new Class63(new int[6] { 1, 2, 1, 2, 2, 3 });
				break;
			case 4:
				@class = new Class63(new int[6] { 1, 2, 1, 3, 2, 2 });
				break;
			case 5:
				@class = new Class63(new int[6] { 1, 3, 1, 2, 2, 2 });
				break;
			case 6:
				@class = new Class63(new int[6] { 1, 2, 2, 2, 1, 3 });
				break;
			case 7:
				@class = new Class63(new int[6] { 1, 2, 2, 3, 1, 2 });
				break;
			case 8:
				@class = new Class63(new int[6] { 1, 3, 2, 2, 1, 2 });
				break;
			case 9:
				@class = new Class63(new int[6] { 2, 2, 1, 2, 1, 3 });
				break;
			case 10:
				@class = new Class63(new int[6] { 2, 2, 1, 3, 1, 2 });
				break;
			case 11:
				@class = new Class63(new int[6] { 2, 3, 1, 2, 1, 2 });
				break;
			case 12:
				@class = new Class63(new int[6] { 1, 1, 2, 2, 3, 2 });
				break;
			case 13:
				@class = new Class63(new int[6] { 1, 2, 2, 1, 3, 2 });
				break;
			case 14:
				@class = new Class63(new int[6] { 1, 2, 2, 2, 3, 2 });
				break;
			case 15:
				@class = new Class63(new int[6] { 1, 1, 3, 2, 2, 2 });
				break;
			case 16:
				@class = new Class63(new int[6] { 1, 2, 3, 1, 2, 2 });
				break;
			case 17:
				@class = new Class63(new int[6] { 1, 2, 3, 2, 2, 1 });
				break;
			case 18:
				@class = new Class63(new int[6] { 2, 2, 3, 2, 1, 1 });
				break;
			case 19:
				@class = new Class63(new int[6] { 2, 2, 1, 1, 3, 2 });
				break;
			case 20:
				@class = new Class63(new int[6] { 2, 2, 1, 2, 3, 1 });
				break;
			case 21:
				@class = new Class63(new int[6] { 2, 1, 3, 2, 1, 2 });
				break;
			case 22:
				@class = new Class63(new int[6] { 2, 2, 3, 1, 1, 2 });
				break;
			case 23:
				@class = new Class63(new int[6] { 3, 1, 2, 1, 3, 1 });
				break;
			case 24:
				@class = new Class63(new int[6] { 3, 1, 1, 2, 2, 2 });
				break;
			case 25:
				@class = new Class63(new int[6] { 3, 2, 1, 1, 2, 2 });
				break;
			case 26:
				@class = new Class63(new int[6] { 3, 2, 1, 2, 2, 1 });
				break;
			case 27:
				@class = new Class63(new int[6] { 3, 1, 2, 2, 1, 2 });
				break;
			case 28:
				@class = new Class63(new int[6] { 3, 2, 2, 1, 1, 2 });
				break;
			case 29:
				@class = new Class63(new int[6] { 3, 2, 2, 2, 1, 1 });
				break;
			case 30:
				@class = new Class63(new int[6] { 2, 1, 2, 1, 2, 3 });
				break;
			case 31:
				@class = new Class63(new int[6] { 2, 1, 2, 3, 2, 1 });
				break;
			case 32:
				@class = new Class63(new int[6] { 2, 3, 2, 1, 2, 1 });
				break;
			case 33:
				@class = new Class63(new int[6] { 1, 1, 1, 3, 2, 3 });
				break;
			case 34:
				@class = new Class63(new int[6] { 1, 3, 1, 1, 2, 3 });
				break;
			case 35:
				@class = new Class63(new int[6] { 1, 3, 1, 3, 2, 1 });
				break;
			case 36:
				@class = new Class63(new int[6] { 1, 1, 2, 3, 1, 3 });
				break;
			case 37:
				@class = new Class63(new int[6] { 1, 3, 2, 1, 1, 3 });
				break;
			case 38:
				@class = new Class63(new int[6] { 1, 3, 2, 3, 1, 1 });
				break;
			case 39:
				@class = new Class63(new int[6] { 2, 1, 1, 3, 1, 3 });
				break;
			case 40:
				@class = new Class63(new int[6] { 2, 3, 1, 1, 1, 3 });
				break;
			case 41:
				@class = new Class63(new int[6] { 2, 3, 1, 3, 1, 1 });
				break;
			case 42:
				@class = new Class63(new int[6] { 1, 1, 2, 1, 3, 3 });
				break;
			case 43:
				@class = new Class63(new int[6] { 1, 1, 2, 3, 3, 1 });
				break;
			case 44:
				@class = new Class63(new int[6] { 1, 3, 2, 1, 3, 1 });
				break;
			case 45:
				@class = new Class63(new int[6] { 1, 1, 3, 1, 2, 3 });
				break;
			case 46:
				@class = new Class63(new int[6] { 1, 1, 3, 3, 2, 1 });
				break;
			case 47:
				@class = new Class63(new int[6] { 1, 3, 3, 1, 2, 1 });
				break;
			case 48:
				@class = new Class63(new int[6] { 3, 1, 3, 1, 2, 1 });
				break;
			case 49:
				@class = new Class63(new int[6] { 2, 1, 1, 3, 3, 1 });
				break;
			case 50:
				@class = new Class63(new int[6] { 2, 3, 1, 1, 3, 1 });
				break;
			case 51:
				@class = new Class63(new int[6] { 2, 1, 3, 1, 1, 3 });
				break;
			case 52:
				@class = new Class63(new int[6] { 2, 1, 3, 3, 1, 1 });
				break;
			case 53:
				@class = new Class63(new int[6] { 2, 1, 3, 1, 3, 1 });
				break;
			case 54:
				@class = new Class63(new int[6] { 3, 1, 1, 1, 2, 3 });
				break;
			case 55:
				@class = new Class63(new int[6] { 3, 1, 1, 3, 2, 1 });
				break;
			case 56:
				@class = new Class63(new int[6] { 3, 3, 1, 1, 2, 1 });
				break;
			case 57:
				@class = new Class63(new int[6] { 3, 1, 2, 1, 1, 3 });
				break;
			case 58:
				@class = new Class63(new int[6] { 3, 1, 2, 3, 1, 1 });
				break;
			case 59:
				@class = new Class63(new int[6] { 3, 3, 2, 1, 1, 1 });
				break;
			case 60:
				@class = new Class63(new int[6] { 3, 1, 4, 1, 1, 1 });
				break;
			case 61:
				@class = new Class63(new int[6] { 2, 2, 1, 4, 1, 1 });
				break;
			case 62:
				@class = new Class63(new int[6] { 4, 3, 1, 1, 1, 1 });
				break;
			case 63:
				@class = new Class63(new int[6] { 1, 1, 1, 2, 2, 4 });
				break;
			case 64:
				@class = new Class63(new int[6] { 1, 1, 1, 4, 2, 2 });
				break;
			case 65:
				@class = new Class63(new int[6] { 1, 2, 1, 1, 2, 4 });
				break;
			case 66:
				@class = new Class63(new int[6] { 1, 2, 1, 4, 2, 1 });
				break;
			case 67:
				@class = new Class63(new int[6] { 1, 4, 1, 1, 2, 2 });
				break;
			case 68:
				@class = new Class63(new int[6] { 1, 4, 1, 2, 2, 1 });
				break;
			case 69:
				@class = new Class63(new int[6] { 1, 1, 2, 2, 1, 4 });
				break;
			case 70:
				@class = new Class63(new int[6] { 1, 1, 2, 4, 1, 2 });
				break;
			case 71:
				@class = new Class63(new int[6] { 1, 2, 2, 1, 1, 4 });
				break;
			case 72:
				@class = new Class63(new int[6] { 1, 2, 2, 4, 1, 1 });
				break;
			case 73:
				@class = new Class63(new int[6] { 1, 4, 2, 1, 1, 2 });
				break;
			case 74:
				@class = new Class63(new int[6] { 1, 4, 2, 2, 1, 1 });
				break;
			case 75:
				@class = new Class63(new int[6] { 2, 4, 1, 2, 1, 1 });
				break;
			case 76:
				@class = new Class63(new int[6] { 2, 2, 1, 1, 1, 4 });
				break;
			case 77:
				@class = new Class63(new int[6] { 4, 1, 3, 1, 1, 1 });
				break;
			case 78:
				@class = new Class63(new int[6] { 2, 4, 1, 1, 1, 2 });
				break;
			case 79:
				@class = new Class63(new int[6] { 1, 3, 4, 1, 1, 1 });
				break;
			case 80:
				@class = new Class63(new int[6] { 1, 1, 1, 2, 4, 2 });
				break;
			case 81:
				@class = new Class63(new int[6] { 1, 2, 1, 1, 4, 2 });
				break;
			case 82:
				@class = new Class63(new int[6] { 1, 2, 1, 2, 4, 1 });
				break;
			case 83:
				@class = new Class63(new int[6] { 1, 1, 4, 2, 1, 2 });
				break;
			case 84:
				@class = new Class63(new int[6] { 1, 2, 4, 1, 1, 2 });
				break;
			case 85:
				@class = new Class63(new int[6] { 1, 2, 4, 2, 1, 1 });
				break;
			case 86:
				@class = new Class63(new int[6] { 4, 1, 1, 2, 1, 2 });
				break;
			case 87:
				@class = new Class63(new int[6] { 4, 2, 1, 1, 1, 2 });
				break;
			case 88:
				@class = new Class63(new int[6] { 4, 2, 1, 2, 1, 1 });
				break;
			case 89:
				@class = new Class63(new int[6] { 2, 1, 2, 1, 4, 1 });
				break;
			case 90:
				@class = new Class63(new int[6] { 2, 1, 4, 1, 2, 1 });
				break;
			case 91:
				@class = new Class63(new int[6] { 4, 1, 2, 1, 2, 1 });
				break;
			case 92:
				@class = new Class63(new int[6] { 1, 1, 1, 1, 4, 3 });
				break;
			case 93:
				@class = new Class63(new int[6] { 1, 1, 1, 3, 4, 1 });
				break;
			case 94:
				@class = new Class63(new int[6] { 1, 3, 1, 1, 4, 1 });
				break;
			case 95:
				@class = new Class63(new int[6] { 1, 1, 4, 1, 1, 3 });
				break;
			case 96:
				@class = new Class63(new int[6] { 1, 1, 4, 3, 1, 1 });
				break;
			case 97:
				@class = new Class63(new int[6] { 4, 1, 1, 1, 1, 3 });
				break;
			case 98:
				@class = new Class63(new int[6] { 4, 1, 1, 3, 1, 1 });
				break;
			case 99:
				@class = new Class63(new int[6] { 1, 1, 3, 1, 4, 1 });
				break;
			case 100:
				@class = new Class63(new int[6] { 1, 1, 4, 1, 3, 1 });
				break;
			case 101:
				@class = new Class63(new int[6] { 3, 1, 1, 1, 4, 1 });
				break;
			case 102:
				@class = new Class63(new int[6] { 4, 1, 1, 1, 3, 1 });
				break;
			case 103:
				@class = new Class63(new int[6] { 2, 1, 1, 4, 1, 2 });
				break;
			case 104:
				@class = new Class63(new int[6] { 2, 1, 1, 2, 1, 4 });
				break;
			case 105:
				@class = new Class63(new int[6] { 2, 1, 1, 2, 3, 2 });
				break;
			case 106:
				@class = new Class63(new int[6] { 1, 1, 4, 3, 1, 1 });
				break;
			case 107:
				@class = new Class63(new int[6] { 4, 1, 1, 1, 1, 3 });
				break;
			case 108:
				@class = new Class63(new int[6] { 4, 1, 1, 3, 1, 1 });
				break;
			case 109:
				@class = new Class63(new int[6] { 1, 1, 3, 1, 4, 1 });
				break;
			}
			@class.int_1 = num;
			return @class;
		}

		private Class63 method_1(int int_0)
		{
			Class63 @class = new Class63(new int[0]);
			switch (int_0)
			{
			case 0:
				@class = new Class63(new int[6] { 2, 1, 2, 2, 2, 2 });
				break;
			case 1:
				@class = new Class63(new int[6] { 2, 2, 2, 1, 2, 2 });
				break;
			case 2:
				@class = new Class63(new int[6] { 2, 2, 2, 2, 2, 1 });
				break;
			case 3:
				@class = new Class63(new int[6] { 1, 2, 1, 2, 2, 3 });
				break;
			case 4:
				@class = new Class63(new int[6] { 1, 2, 1, 3, 2, 2 });
				break;
			case 5:
				@class = new Class63(new int[6] { 1, 3, 1, 2, 2, 2 });
				break;
			case 6:
				@class = new Class63(new int[6] { 1, 2, 2, 2, 1, 3 });
				break;
			case 7:
				@class = new Class63(new int[6] { 1, 2, 2, 3, 1, 2 });
				break;
			case 8:
				@class = new Class63(new int[6] { 1, 3, 2, 2, 1, 2 });
				break;
			case 9:
				@class = new Class63(new int[6] { 2, 2, 1, 2, 1, 3 });
				break;
			case 10:
				@class = new Class63(new int[6] { 2, 2, 1, 3, 1, 2 });
				break;
			case 11:
				@class = new Class63(new int[6] { 2, 3, 1, 2, 1, 2 });
				break;
			case 12:
				@class = new Class63(new int[6] { 1, 1, 2, 2, 3, 2 });
				break;
			case 13:
				@class = new Class63(new int[6] { 1, 2, 2, 1, 3, 2 });
				break;
			case 14:
				@class = new Class63(new int[6] { 1, 2, 2, 2, 3, 2 });
				break;
			case 15:
				@class = new Class63(new int[6] { 1, 1, 3, 2, 2, 2 });
				break;
			case 16:
				@class = new Class63(new int[6] { 1, 2, 3, 1, 2, 2 });
				break;
			case 17:
				@class = new Class63(new int[6] { 1, 2, 3, 2, 2, 1 });
				break;
			case 18:
				@class = new Class63(new int[6] { 2, 2, 3, 2, 1, 1 });
				break;
			case 19:
				@class = new Class63(new int[6] { 2, 2, 1, 1, 3, 2 });
				break;
			case 20:
				@class = new Class63(new int[6] { 2, 2, 1, 2, 3, 1 });
				break;
			case 21:
				@class = new Class63(new int[6] { 2, 1, 3, 2, 1, 2 });
				break;
			case 22:
				@class = new Class63(new int[6] { 2, 2, 3, 1, 1, 2 });
				break;
			case 23:
				@class = new Class63(new int[6] { 3, 1, 2, 1, 3, 1 });
				break;
			case 24:
				@class = new Class63(new int[6] { 3, 1, 1, 2, 2, 2 });
				break;
			case 25:
				@class = new Class63(new int[6] { 3, 2, 1, 1, 2, 2 });
				break;
			case 26:
				@class = new Class63(new int[6] { 3, 2, 1, 2, 2, 1 });
				break;
			case 27:
				@class = new Class63(new int[6] { 3, 1, 2, 2, 1, 2 });
				break;
			case 28:
				@class = new Class63(new int[6] { 3, 2, 2, 1, 1, 2 });
				break;
			case 29:
				@class = new Class63(new int[6] { 3, 2, 2, 2, 1, 1 });
				break;
			case 30:
				@class = new Class63(new int[6] { 2, 1, 2, 1, 2, 3 });
				break;
			case 31:
				@class = new Class63(new int[6] { 2, 1, 2, 3, 2, 1 });
				break;
			case 32:
				@class = new Class63(new int[6] { 2, 3, 2, 1, 2, 1 });
				break;
			case 33:
				@class = new Class63(new int[6] { 1, 1, 1, 3, 2, 3 });
				break;
			case 34:
				@class = new Class63(new int[6] { 1, 3, 1, 1, 2, 3 });
				break;
			case 35:
				@class = new Class63(new int[6] { 1, 3, 1, 3, 2, 1 });
				break;
			case 36:
				@class = new Class63(new int[6] { 1, 1, 2, 3, 1, 3 });
				break;
			case 37:
				@class = new Class63(new int[6] { 1, 3, 2, 1, 1, 3 });
				break;
			case 38:
				@class = new Class63(new int[6] { 1, 3, 2, 3, 1, 1 });
				break;
			case 39:
				@class = new Class63(new int[6] { 2, 1, 1, 3, 1, 3 });
				break;
			case 40:
				@class = new Class63(new int[6] { 2, 3, 1, 1, 1, 3 });
				break;
			case 41:
				@class = new Class63(new int[6] { 2, 3, 1, 3, 1, 1 });
				break;
			case 42:
				@class = new Class63(new int[6] { 1, 1, 2, 1, 3, 3 });
				break;
			case 43:
				@class = new Class63(new int[6] { 1, 1, 2, 3, 3, 1 });
				break;
			case 44:
				@class = new Class63(new int[6] { 1, 3, 2, 1, 3, 1 });
				break;
			case 45:
				@class = new Class63(new int[6] { 1, 1, 3, 1, 2, 3 });
				break;
			case 46:
				@class = new Class63(new int[6] { 1, 1, 3, 3, 2, 1 });
				break;
			case 47:
				@class = new Class63(new int[6] { 1, 3, 3, 1, 2, 1 });
				break;
			case 48:
				@class = new Class63(new int[6] { 3, 1, 3, 1, 2, 1 });
				break;
			case 49:
				@class = new Class63(new int[6] { 2, 1, 1, 3, 3, 1 });
				break;
			case 50:
				@class = new Class63(new int[6] { 2, 3, 1, 1, 3, 1 });
				break;
			case 51:
				@class = new Class63(new int[6] { 2, 1, 3, 1, 1, 3 });
				break;
			case 52:
				@class = new Class63(new int[6] { 2, 1, 3, 3, 1, 1 });
				break;
			case 53:
				@class = new Class63(new int[6] { 2, 1, 3, 1, 3, 1 });
				break;
			case 54:
				@class = new Class63(new int[6] { 3, 1, 1, 1, 2, 3 });
				break;
			case 55:
				@class = new Class63(new int[6] { 3, 1, 1, 3, 2, 1 });
				break;
			case 56:
				@class = new Class63(new int[6] { 3, 3, 1, 1, 2, 1 });
				break;
			case 57:
				@class = new Class63(new int[6] { 3, 1, 2, 1, 1, 3 });
				break;
			case 58:
				@class = new Class63(new int[6] { 3, 1, 2, 3, 1, 1 });
				break;
			case 59:
				@class = new Class63(new int[6] { 3, 3, 2, 1, 1, 1 });
				break;
			case 60:
				@class = new Class63(new int[6] { 3, 1, 4, 1, 1, 1 });
				break;
			case 61:
				@class = new Class63(new int[6] { 2, 2, 1, 4, 1, 1 });
				break;
			case 62:
				@class = new Class63(new int[6] { 4, 3, 1, 1, 1, 1 });
				break;
			case 63:
				@class = new Class63(new int[6] { 1, 1, 1, 2, 2, 4 });
				break;
			case 64:
				@class = new Class63(new int[6] { 1, 1, 1, 4, 2, 2 });
				break;
			case 65:
				@class = new Class63(new int[6] { 1, 2, 1, 1, 2, 4 });
				break;
			case 66:
				@class = new Class63(new int[6] { 1, 2, 1, 4, 2, 1 });
				break;
			case 67:
				@class = new Class63(new int[6] { 1, 4, 1, 1, 2, 2 });
				break;
			case 68:
				@class = new Class63(new int[6] { 1, 4, 1, 2, 2, 1 });
				break;
			case 69:
				@class = new Class63(new int[6] { 1, 1, 2, 2, 1, 4 });
				break;
			case 70:
				@class = new Class63(new int[6] { 1, 1, 2, 4, 1, 2 });
				break;
			case 71:
				@class = new Class63(new int[6] { 1, 2, 2, 1, 1, 4 });
				break;
			case 72:
				@class = new Class63(new int[6] { 1, 2, 2, 4, 1, 1 });
				break;
			case 73:
				@class = new Class63(new int[6] { 1, 4, 2, 1, 1, 2 });
				break;
			case 74:
				@class = new Class63(new int[6] { 1, 4, 2, 2, 1, 1 });
				break;
			case 75:
				@class = new Class63(new int[6] { 2, 4, 1, 2, 1, 1 });
				break;
			case 76:
				@class = new Class63(new int[6] { 2, 2, 1, 1, 1, 4 });
				break;
			case 77:
				@class = new Class63(new int[6] { 4, 1, 3, 1, 1, 1 });
				break;
			case 78:
				@class = new Class63(new int[6] { 2, 4, 1, 1, 1, 2 });
				break;
			case 79:
				@class = new Class63(new int[6] { 1, 3, 4, 1, 1, 1 });
				break;
			case 80:
				@class = new Class63(new int[6] { 1, 1, 1, 2, 4, 2 });
				break;
			case 81:
				@class = new Class63(new int[6] { 1, 2, 1, 1, 4, 2 });
				break;
			case 82:
				@class = new Class63(new int[6] { 1, 2, 1, 2, 4, 1 });
				break;
			case 83:
				@class = new Class63(new int[6] { 1, 1, 4, 2, 1, 2 });
				break;
			case 84:
				@class = new Class63(new int[6] { 1, 2, 4, 1, 1, 2 });
				break;
			case 85:
				@class = new Class63(new int[6] { 1, 2, 4, 2, 1, 1 });
				break;
			case 86:
				@class = new Class63(new int[6] { 4, 1, 1, 2, 1, 2 });
				break;
			case 87:
				@class = new Class63(new int[6] { 4, 2, 1, 1, 1, 2 });
				break;
			case 88:
				@class = new Class63(new int[6] { 4, 2, 1, 2, 1, 1 });
				break;
			case 89:
				@class = new Class63(new int[6] { 2, 1, 2, 1, 4, 1 });
				break;
			case 90:
				@class = new Class63(new int[6] { 2, 1, 4, 1, 2, 1 });
				break;
			case 91:
				@class = new Class63(new int[6] { 4, 1, 2, 1, 2, 1 });
				break;
			case 92:
				@class = new Class63(new int[6] { 1, 1, 1, 1, 4, 3 });
				break;
			case 93:
				@class = new Class63(new int[6] { 1, 1, 1, 3, 4, 1 });
				break;
			case 94:
				@class = new Class63(new int[6] { 1, 3, 1, 1, 4, 1 });
				break;
			case 95:
				@class = new Class63(new int[6] { 1, 1, 4, 1, 1, 3 });
				break;
			case 96:
				@class = new Class63(new int[6] { 1, 1, 4, 3, 1, 1 });
				break;
			case 97:
				@class = new Class63(new int[6] { 4, 1, 1, 1, 1, 3 });
				break;
			case 98:
				@class = new Class63(new int[6] { 4, 1, 1, 3, 1, 1 });
				break;
			case 99:
				@class = new Class63(new int[6] { 1, 1, 3, 1, 4, 1 });
				break;
			case 100:
				@class = new Class63(new int[6] { 1, 1, 4, 1, 3, 1 });
				break;
			case 101:
				@class = new Class63(new int[6] { 3, 1, 1, 1, 4, 1 });
				break;
			case 102:
				@class = new Class63(new int[6] { 4, 1, 1, 1, 3, 1 });
				break;
			case 103:
				@class = new Class63(new int[6] { 2, 1, 1, 4, 1, 2 });
				break;
			case 104:
				@class = new Class63(new int[6] { 2, 1, 1, 2, 1, 4 });
				break;
			case 105:
				@class = new Class63(new int[6] { 2, 1, 1, 2, 3, 2 });
				break;
			case 106:
				@class = new Class63(new int[6] { 1, 1, 4, 3, 1, 1 });
				break;
			case 107:
				@class = new Class63(new int[6] { 4, 1, 1, 1, 1, 3 });
				break;
			case 108:
				@class = new Class63(new int[6] { 4, 1, 1, 3, 1, 1 });
				break;
			case 109:
				@class = new Class63(new int[6] { 1, 1, 3, 1, 4, 1 });
				break;
			}
			@class.int_1 = int_0;
			return @class;
		}
	}
}
