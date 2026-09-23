/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System.Collections.Generic;

namespace TX_Text_Control_Words {

	/*------------------------------------------------------------------------------------------------
	** Class CSVLineParser
	** Implements methods for extending the Charting class.
	** Provides functionalities for setting a chart's style to 3D and initialize a Series with
	** a set of data.
	**----------------------------------------------------------------------------------------------*/
	class CSVLineParser {

		/*------------------------------------------------------------------------------------------------
		** E N U M S
		**----------------------------------------------------------------------------------------------*/

		enum ParserState {
			Initial,
			AfterQuotedValue,
			QuotedValue,
			UnquotedValue,
			EscapedCharacter,
		}

		/*------------------------------------------------------------------------------------------------
		** M E M B E R S
		**----------------------------------------------------------------------------------------------*/

		private ParserState m_State;
		private ParserState m_PreviousState;
		private char m_CharSplit;
		private char m_CharQuote;
		private string m_CurrentItem;

		/*------------------------------------------------------------------------------------------------
		** P R O P E R T I E S
		**----------------------------------------------------------------------------------------------*/

		public List<string> Result;

		/*------------------------------------------------------------------------------------------------
		** P U B L I C   M E T H O D S
		**----------------------------------------------------------------------------------------------*/

		/*------------------------------------------------------------------------------------------------
		** ParseLine method
		** Parse a string formatted as CSV data and return the values as strings.
		**----------------------------------------------------------------------------------------------*/
		public List<string> ParseLine(string line, char charDelim, char charQuote) {
			InitParserState(charDelim, charQuote);

			if (line == string.Empty) return Result;

			// Parse
			foreach (var c in line) ProcessChar(c);

			// Add current item if inside an unquoted value or right behind a separator
			if ((m_State == ParserState.UnquotedValue) || (m_State == ParserState.Initial)) Result.Add(m_CurrentItem);

			return Result;
		}

		/*------------------------------------------------------------------------------------------------
		** P R I V A T E   M E T H O D S
		**----------------------------------------------------------------------------------------------*/

		/*------------------------------------------------------------------------------------------------
		** InitParserState method
		** Initialize the parser by resetting the temporary variables of the parser.
		**----------------------------------------------------------------------------------------------*/
		private void InitParserState(char charSplit, char charQuote) {
			m_CharSplit = charSplit;
			m_CharQuote = charQuote;
			m_State = ParserState.Initial;
			Result = new List<string>();
			m_CurrentItem = string.Empty;
		}

		/*------------------------------------------------------------------------------------------------
		** ProcessChar method
		** Process char by considering the current parsing state.
		**----------------------------------------------------------------------------------------------*/
		private void ProcessChar(char c) {
			switch (m_State) {
				case ParserState.Initial:
					InitialState(c);
					break;

				case ParserState.AfterQuotedValue:
					AfterQuotedValueState(c);
					break;

				case ParserState.QuotedValue:
					QuotedValueState(c);
					break;

				case ParserState.UnquotedValue:
					UnquotedValueState(c);
					break;

				case ParserState.EscapedCharacter:
					EscapedCharacterState(c);
					break;
			}
		}

		/*------------------------------------------------------------------------------------------------
		** InitialState method
		** Process char on state Initial.
		**----------------------------------------------------------------------------------------------*/
		private void InitialState(char c) {
			if (c == m_CharQuote) {
				m_State = ParserState.QuotedValue;
			}
			else if (c == m_CharSplit) Result.Add(string.Empty);
			else if (c == '\\') {
				m_PreviousState = ParserState.UnquotedValue;
				m_State = ParserState.EscapedCharacter;
			}
			else {
				m_CurrentItem += c;
				m_State = ParserState.UnquotedValue;
			}
		}

		/*------------------------------------------------------------------------------------------------
		** AfterQuotedValueState method
		** Process char on state AfterQuotedValue.
		**----------------------------------------------------------------------------------------------*/
		private void AfterQuotedValueState(char c) {
			if (c == m_CharSplit) m_State = ParserState.Initial;
		}

		/*------------------------------------------------------------------------------------------------
		** QuotedValueState method
		** Process char on state QuotedValue.
		**----------------------------------------------------------------------------------------------*/
		private void QuotedValueState(char c) {
			if (c == m_CharQuote) {
				Result.Add(m_CurrentItem);
				m_CurrentItem = string.Empty;
				m_State = ParserState.AfterQuotedValue;
			}
			else if (c == m_CharSplit) m_CurrentItem += c;
			else UnquotedValueState(c);
		}

		/*------------------------------------------------------------------------------------------------
		** UnquotedValueState method
		** Process char on state UnquotedValue.
		**----------------------------------------------------------------------------------------------*/
		private void UnquotedValueState(char c) {
			if (c == '\\') {
				m_PreviousState = m_State;
				m_State = ParserState.EscapedCharacter;
			}
			else if (c == m_CharSplit) {
				Result.Add(m_CurrentItem);
				m_CurrentItem = string.Empty;
				m_State = ParserState.Initial;
			}
			else m_CurrentItem += c;
		}

		/*------------------------------------------------------------------------------------------------
		** EscapedCharacterState method
		** Process char on state EscapedCharacter.
		**----------------------------------------------------------------------------------------------*/
		private void EscapedCharacterState(char c) {
			switch (m_PreviousState) {
				case ParserState.QuotedValue:
					if ((c == m_CharQuote) || (c == '\\')) m_CurrentItem += c;
					else m_CurrentItem += '\\' + c;
					break;

				case ParserState.UnquotedValue:
					if (c == '\\') m_CurrentItem += c;
					else m_CurrentItem += '\\' + c;
					break;
			}

			m_State = m_PreviousState;
		}
	}
}
