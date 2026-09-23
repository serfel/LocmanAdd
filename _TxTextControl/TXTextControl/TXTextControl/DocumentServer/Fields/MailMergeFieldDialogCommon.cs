namespace DocumentServer.Fields
{
	internal abstract class MailMergeFieldDialogCommon
	{
		private MailMergeFieldAdapter m_field;

		public bool PreserveFormatting
		{
			get
			{
				return this.m_field.PreserveFormatting;
			}
			set
			{
				this.m_field.PreserveFormatting = value;
			}
		}

		public MailMergeFieldDialogCommon(MailMergeFieldAdapter field)
		{
			this.m_field = field;
		}
	}
}
