using ns21;

namespace TXTextControl
{
	internal interface IConditionalInstructionsManager
	{
		Class394 Core { get; }

		bool IsFormFieldValidationEnabled { get; }

		void OnConditionalInstructionsChanged(TextPart textPart);
	}
}
