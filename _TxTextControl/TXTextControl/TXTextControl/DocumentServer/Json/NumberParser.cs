using System.Globalization;
using System.Reflection;
using System.Text;

namespace DocumentServer.Json
{
	[Obfuscation(Exclude = true)]
	internal class NumberParser : Parser<double?>
	{
		private enum Enum25
		{
			const_0,
			const_1,
			const_2,
			const_3,
			const_4,
			const_5,
			const_6,
			const_7
		}

		private Enum25 enum25_0;

		private bool bool_0;

		private StringBuilder stringBuilder_0;

		protected override bool IsDone => this.enum25_0 == Enum25.const_7;

		public NumberParser(string number, int pos)
			: base(number, pos)
		{
			this.enum25_0 = Enum25.const_0;
			this.bool_0 = false;
			this.stringBuilder_0 = new StringBuilder();
		}

		protected override void ParseNextTokens()
		{
			switch (this.enum25_0)
			{
			case Enum25.const_0:
				this.method_0();
				break;
			case Enum25.const_1:
				this.method_1();
				break;
			case Enum25.const_2:
				this.method_2();
				break;
			case Enum25.const_3:
				this.method_3();
				break;
			case Enum25.const_4:
				this.method_4();
				break;
			case Enum25.const_5:
				this.method_5();
				break;
			case Enum25.const_6:
				this.method_6();
				break;
			}
		}

		private void method_0()
		{
			char c = base.Consume();
			if (c >= '1' && c <= '9')
			{
				this.stringBuilder_0.Append(c);
				if (!base.HasMoreTokens)
				{
					this.method_8();
				}
				else
				{
					this.enum25_0 = Enum25.const_2;
				}
				return;
			}
			switch (c)
			{
			default:
				throw new UnexpectedTokenException(base.m_pos - 1, c);
			case '0':
				this.stringBuilder_0.Append('0');
				this.enum25_0 = Enum25.const_1;
				break;
			case '-':
				if (this.bool_0)
				{
					throw new UnexpectedTokenException(base.m_pos - 1, '-');
				}
				this.bool_0 = true;
				this.stringBuilder_0.Append('-');
				break;
			}
		}

		private void method_1()
		{
			switch (base.Consume())
			{
			default:
				base.Unconsume();
				this.method_8();
				return;
			case 'E':
			case 'e':
				this.stringBuilder_0.Append('e');
				this.enum25_0 = Enum25.const_4;
				break;
			case '.':
				this.stringBuilder_0.Append('.');
				this.enum25_0 = Enum25.const_3;
				break;
			}
			if (!base.HasMoreTokens)
			{
				this.method_8();
			}
		}

		private void method_2()
		{
			char c = base.Consume();
			if (c >= '0' && c <= '9')
			{
				this.stringBuilder_0.Append(c);
			}
			else
			{
				switch (c)
				{
				default:
					base.Unconsume();
					this.method_8();
					return;
				case 'E':
				case 'e':
					this.stringBuilder_0.Append('e');
					this.enum25_0 = Enum25.const_4;
					break;
				case '.':
					this.stringBuilder_0.Append('.');
					this.enum25_0 = Enum25.const_3;
					break;
				}
			}
			if (!base.HasMoreTokens)
			{
				this.method_8();
			}
		}

		private void method_3()
		{
			char c = base.Consume();
			if (c >= '0' && c <= '9')
			{
				this.stringBuilder_0.Append(c);
			}
			else
			{
				if (c != 'E' && c != 'e')
				{
					base.Unconsume();
					this.method_8();
					return;
				}
				this.stringBuilder_0.Append('e');
				this.enum25_0 = Enum25.const_4;
			}
			if (!base.HasMoreTokens)
			{
				this.method_8();
			}
		}

		private void method_4()
		{
			char c = base.Peek();
			if (c >= '0' && c <= '9')
			{
				this.enum25_0 = Enum25.const_5;
				return;
			}
			if (c != '-' && c != '+')
			{
				throw new UnexpectedTokenException(base.m_pos, c);
			}
			this.stringBuilder_0.Append(c);
			base.Consume();
			this.enum25_0 = Enum25.const_5;
		}

		private void method_5()
		{
			char c = base.Consume();
			if (c >= '0' && c <= '9')
			{
				this.stringBuilder_0.Append(c);
				if (!base.HasMoreTokens)
				{
					this.method_8();
				}
				else
				{
					this.enum25_0 = Enum25.const_6;
				}
				return;
			}
			throw new UnexpectedTokenException(base.m_pos - 1, c);
		}

		private void method_6()
		{
			char c = base.Consume();
			if (c >= '0' && c <= '9')
			{
				this.stringBuilder_0.Append(c);
				if (!base.HasMoreTokens)
				{
					this.method_8();
				}
			}
			else
			{
				base.Unconsume();
				this.method_8();
			}
		}

		private void method_7()
		{
			string text = this.stringBuilder_0.ToString();
			if (text.EndsWith("."))
			{
				throw new InvalidNumberFormatException(base.m_pos - text.Length, text);
			}
			if (!double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out var result))
			{
				throw new InvalidNumberFormatException(base.m_pos - text.Length, text);
			}
			base.m_result = result;
		}

		private void method_8()
		{
			this.method_7();
			this.enum25_0 = Enum25.const_7;
		}
	}
}
