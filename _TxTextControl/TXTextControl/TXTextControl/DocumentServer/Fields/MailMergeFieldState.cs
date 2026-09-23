namespace DocumentServer.Fields
{
	internal abstract class MailMergeFieldState
	{
		public bool PreserveFormatting { get; private set; }

		public MailMergeFieldState(MailMergeFieldDialogCommon field)
		{
			this.PreserveFormatting = field.PreserveFormatting;
		}
	}
}
