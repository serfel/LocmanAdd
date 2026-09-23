namespace TXTextControl
{
	/// <summary>Determines the format of an ApplicationField.</summary>
	public enum ApplicationFieldFormat
	{
		/// <summary>This value can only be used with the LoadSettings.ApplicationFieldFormat property.</summary>
		None = 0,
		/// <summary>The field is supported and defined through Microsoft Word.</summary>
		MSWord = 7,
		/// <summary>The field is supported and defined through the Heiler HighEdit component.</summary>
		HighEdit = 8,
		/// <summary>This value can only be used with the LoadSettings.ApplicationFieldFormat property.</summary>
		MSWordTXFormFields = 12
	}
}
