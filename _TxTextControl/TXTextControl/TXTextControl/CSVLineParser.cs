using System.Collections.Generic;

namespace TXTextControl
{
	internal static class CSVLineParser
	{
		private enum Enum134
		{
			const_0,
			const_1,
			const_2,
			const_3,
			const_4
		}

		private static Enum134 m_state;

		private static Enum134 m_previousState;

		private static char m_charSplit;

		private static char m_charQuote;

		private static string m_currentItem;

		private static List<string> m_result;

		public static List<string> ParseLine(string line, char charDelim, char charQuote)
		{
			CSVLineParser.Init(charDelim, charQuote);
			if (line == string.Empty)
			{
				return CSVLineParser.m_result;
			}
			foreach (char char_ in line)
			{
				CSVLineParser.ProcessChar(char_);
			}
			if (CSVLineParser.m_state == Enum134.const_3 || CSVLineParser.m_state == Enum134.const_0)
			{
				CSVLineParser.m_result.Add(CSVLineParser.m_currentItem);
			}
			return CSVLineParser.m_result;
		}

		private static void Init(char charSplit, char charQuote)
		{
			CSVLineParser.m_charSplit = charSplit;
			CSVLineParser.m_charQuote = charQuote;
			CSVLineParser.m_state = Enum134.const_0;
			CSVLineParser.m_result = new List<string>();
			CSVLineParser.m_currentItem = string.Empty;
		}

		private static void ProcessChar(char char_0)
		{
			switch (CSVLineParser.m_state)
			{
			case Enum134.const_0:
				CSVLineParser.InitialState(char_0);
				break;
			case Enum134.const_1:
				CSVLineParser.AfterQuotedValueState(char_0);
				break;
			case Enum134.const_2:
				CSVLineParser.QuotedValueState(char_0);
				break;
			case Enum134.const_3:
				CSVLineParser.UnquotedValueState(char_0);
				break;
			case Enum134.const_4:
				CSVLineParser.EscapedCharacterState(char_0);
				break;
			}
		}

		private static void InitialState(char char_0)
		{
			if (char_0 == CSVLineParser.m_charQuote)
			{
				CSVLineParser.m_state = Enum134.const_2;
			}
			else if (char_0 == CSVLineParser.m_charSplit)
			{
				CSVLineParser.m_result.Add(string.Empty);
			}
			else if (char_0 == '\\')
			{
				CSVLineParser.m_previousState = Enum134.const_3;
				CSVLineParser.m_state = Enum134.const_4;
			}
			else
			{
				CSVLineParser.m_currentItem += char_0;
				CSVLineParser.m_state = Enum134.const_3;
			}
		}

		private static void AfterQuotedValueState(char char_0)
		{
			if (char_0 == CSVLineParser.m_charSplit)
			{
				CSVLineParser.m_state = Enum134.const_0;
			}
		}

		private static void QuotedValueState(char char_0)
		{
			if (char_0 == CSVLineParser.m_charQuote)
			{
				CSVLineParser.m_result.Add(CSVLineParser.m_currentItem);
				CSVLineParser.m_currentItem = string.Empty;
				CSVLineParser.m_state = Enum134.const_1;
			}
			else if (char_0 == CSVLineParser.m_charSplit)
			{
				CSVLineParser.m_currentItem += char_0;
			}
			else
			{
				CSVLineParser.UnquotedValueState(char_0);
			}
		}

		private static void UnquotedValueState(char char_0)
		{
			if (char_0 == '\\')
			{
				CSVLineParser.m_previousState = CSVLineParser.m_state;
				CSVLineParser.m_state = Enum134.const_4;
			}
			else if (char_0 == CSVLineParser.m_charSplit)
			{
				CSVLineParser.m_result.Add(CSVLineParser.m_currentItem);
				CSVLineParser.m_currentItem = string.Empty;
				CSVLineParser.m_state = Enum134.const_0;
			}
			else
			{
				CSVLineParser.m_currentItem += char_0;
			}
		}

		private static void EscapedCharacterState(char char_0)
		{
			switch (CSVLineParser.m_previousState)
			{
			case Enum134.const_2:
				if (char_0 != CSVLineParser.m_charQuote && char_0 != '\\')
				{
					CSVLineParser.m_currentItem += 92 + char_0;
				}
				else
				{
					CSVLineParser.m_currentItem += char_0;
				}
				break;
			case Enum134.const_3:
				if (char_0 == '\\')
				{
					CSVLineParser.m_currentItem += char_0;
				}
				else
				{
					CSVLineParser.m_currentItem += 92 + char_0;
				}
				break;
			}
			CSVLineParser.m_state = CSVLineParser.m_previousState;
		}
	}
}
