namespace TXTextControl
{
	/// <summary>Determines the justification.</summary>
	public enum Justification
	{
		/// <summary>To justify a line additional space is added to the spaces between the words.</summary>
		Spaces = 1,
		/// <summary>To justify a line Kashida lines are inserted.</summary>
		Kashida,
		/// <summary>To justify a line both kinds of justification are used.</summary>
		SpacesAndKashida
	}
}
