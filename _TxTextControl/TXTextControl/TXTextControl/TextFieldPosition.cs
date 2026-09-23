namespace TXTextControl
{
	/// <summary>Specifies special text input positions at the beginning and the end of a TextField.</summary>
	public enum TextFieldPosition
	{
		/// <summary>The specified position is inside the field.</summary>
		InsideTextField = 1,
		/// <summary>The specified position is outside the field.</summary>
		OutsideTextField,
		/// <summary>The specified position is inside the next field. This member is only possible, if there are two following text fields without any character bewteen the fields. In this case InsideTextField is in the first field, OutsideTextField is between the fields and InsideNextTextField is in the second field.</summary>
		InsideNextTextField
	}
}
