namespace TXTextControl
{
	internal interface IConditionalInstructionElement
	{
		string ConditionalInstructionName { get; set; }

		bool IsValid { get; }

		RelatedFormField RelatedFormField { get; set; }

		object[] StringElements { get; }

		string ToJson();
	}
}
