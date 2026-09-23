using ns21;

namespace TXTextControl
{
	internal interface ITextControl
	{
		string ѕуть—охранени€ { get; set; }
		int FileFilterIndex { get; set; }
		int OpenFileDialog(string strFilter, out string strFileName);

		int SaveFileDialog(string strFilter, out string strFileName);

		void CheckStreamType(StreamType iStreamType);

		PageSize GetPageSize();

		PageMargins GetPageMargins();

		int GetFontSize();

		string GetFontName();

		FontUnderlineStyle GetFontUnderlineStyle();

		bool GetFontBold();

		bool GetFontItalic();

		bool GetFontStrikeout();

		int GetBackColor();

		uint GetDocumentBackColor();

		void SetDocumentBackColor(uint uiColor);

		ViewMode GetViewMode();

		string GetVersionKey();

		Enum116 GetControlType();

		string GetLicGUID();

		string GetTrialSearchString();

		int GetIsInDesignMode();

		IConditionalInstructionsManager GetConditionalInstructionsManager();
	}
}
