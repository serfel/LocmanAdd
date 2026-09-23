using System.Collections.Generic;

namespace TX_Text_Control_Words
{
	internal class CSVLineParser
	{
		private enum ParserState
		{
			Initial,
			AfterQuotedValue,
			QuotedValue,
			UnquotedValue,
			EscapedCharacter
		}

		private ParserState m_State;

		private ParserState m_PreviousState;

		private char m_CharSplit;

		private char m_CharQuote;

		private string m_CurrentItem;

		public List<string> Result;

		public List<string> ParseLine(string line, char charDelim, char charQuote)
		{
			this.InitParserState(charDelim, charQuote);
			if (line == string.Empty)
			{
				return this.Result;
			}
			foreach (char c in line)
			{
				this.ProcessChar(c);
			}
			if (this.m_State == ParserState.UnquotedValue || this.m_State == ParserState.Initial)
			{
				this.Result.Add(this.m_CurrentItem);
			}
			return this.Result;
		}

		private void InitParserState(char charSplit, char charQuote)
		{
			this.m_CharSplit = charSplit;
			this.m_CharQuote = charQuote;
			this.m_State = ParserState.Initial;
			this.Result = new List<string>();
			this.m_CurrentItem = string.Empty;
		}

		private void ProcessChar(char c)
		{
			switch (this.m_State)
			{
			case ParserState.Initial:
				this.InitialState(c);
				break;
			case ParserState.AfterQuotedValue:
				this.AfterQuotedValueState(c);
				break;
			case ParserState.QuotedValue:
				this.QuotedValueState(c);
				break;
			case ParserState.UnquotedValue:
				this.UnquotedValueState(c);
				break;
			case ParserState.EscapedCharacter:
				this.EscapedCharacterState(c);
				break;
			}
		}

		private void InitialState(char c)
		{
			if (c == this.m_CharQuote)
			{
				this.m_State = ParserState.QuotedValue;
			}
			else if (c == this.m_CharSplit)
			{
				this.Result.Add(string.Empty);
			}
			else if (c == '\\')
			{
				this.m_PreviousState = ParserState.UnquotedValue;
				this.m_State = ParserState.EscapedCharacter;
			}
			else
			{
				this.m_CurrentItem += c;
				this.m_State = ParserState.UnquotedValue;
			}
		}

		private void AfterQuotedValueState(char c)
		{
			if (c == this.m_CharSplit)
			{
				this.m_State = ParserState.Initial;
			}
		}

		private void QuotedValueState(char c)
		{
			if (c == this.m_CharQuote)
			{
				this.Result.Add(this.m_CurrentItem);
				this.m_CurrentItem = string.Empty;
				this.m_State = ParserState.AfterQuotedValue;
			}
			else if (c == this.m_CharSplit)
			{
				this.m_CurrentItem += c;
			}
			else
			{
				this.UnquotedValueState(c);
			}
		}

		private void UnquotedValueState(char c)
		{
			if (c == '\\')
			{
				this.m_PreviousState = this.m_State;
				this.m_State = ParserState.EscapedCharacter;
			}
			else if (c == this.m_CharSplit)
			{
				this.Result.Add(this.m_CurrentItem);
				this.m_CurrentItem = string.Empty;
				this.m_State = ParserState.Initial;
			}
			else
			{
				this.m_CurrentItem += c;
			}
		}

		private void EscapedCharacterState(char c)
		{
			switch (this.m_PreviousState)
			{
			case ParserState.QuotedValue:
				if (c == this.m_CharQuote || c == '\\')
				{
					this.m_CurrentItem += c;
				}
				else
				{
					this.m_CurrentItem += 92 + c;
				}
				break;
			case ParserState.UnquotedValue:
				if (c == '\\')
				{
					this.m_CurrentItem += c;
				}
				else
				{
					this.m_CurrentItem += 92 + c;
				}
				break;
			}
			this.m_State = this.m_PreviousState;
		}
	}
}
