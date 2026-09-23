using System;
using System.Reflection;

namespace DocumentServer.Json
{
	[Obfuscation(Exclude = true)]
	internal abstract class Parser<T>
	{
		protected int m_pos;

		protected string m_input;

		protected T m_result;

		public int Position => this.m_pos;

		protected abstract bool IsDone { get; }

		protected bool HasMoreTokens => this.m_pos < this.m_input.Length;

		public Parser(string input, int start)
		{
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}
			if (start < 0)
			{
				throw new ArgumentException("Start position must be >= 0.", "start");
			}
			this.m_result = default(T);
			this.m_input = input;
			this.m_pos = start;
		}

		public T Parse()
		{
			if (this.m_input.Length == 0)
			{
				throw new UnexpectedEndOfInputException(this.m_pos);
			}
			this.White();
			while (this.HasMoreTokens && !this.IsDone)
			{
				this.ParseNextTokens();
			}
			if (!this.IsDone)
			{
				throw new UnexpectedEndOfInputException(this.m_pos);
			}
			return this.m_result;
		}

		protected abstract void ParseNextTokens();

		protected char Peek()
		{
			return this.Peek(1)[0];
		}

		protected string Peek(int chars)
		{
			if (!this.HasMoreTokens || chars > this.m_input.Length - this.m_pos)
			{
				throw new UnexpectedEndOfInputException(this.m_input.Length);
			}
			return this.m_input.Substring(this.m_pos, chars);
		}

		protected string Consume(int chars)
		{
			string result = this.Peek(chars);
			this.m_pos += chars;
			return result;
		}

		protected char Consume()
		{
			return this.Consume(1)[0];
		}

		protected void Unconsume()
		{
			this.m_pos--;
			if (this.m_pos < 0)
			{
				throw new UnknownParseErrorException(this.m_pos, "Position is negative after unconsuming a character.");
			}
		}

		protected void White()
		{
			while (this.HasMoreTokens && char.IsWhiteSpace(this.m_input, this.m_pos))
			{
				this.m_pos++;
			}
			if (!this.HasMoreTokens)
			{
				throw new UnexpectedEndOfInputException(this.m_pos);
			}
		}
	}
}
