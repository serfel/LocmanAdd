using DocumentServer.Fields;

namespace ns12
{
	internal class Dialog2 : MailMergeFieldDialogCommon
	{
		private IncludeText includeText_0;

		public string String_0
		{
			get
			{
				return this.includeText_0.Filename;
			}
			set
			{
				if (value != string.Empty)
				{
					this.includeText_0.Filename = value;
				}
			}
		}

		public string String_1
		{
			get
			{
				return this.includeText_0.Bookmark;
			}
			set
			{
				this.includeText_0.Bookmark = value;
			}
		}

		public int Int32_0
		{
			get
			{
				return (int)this.includeText_0.TextFormat;
			}
			set
			{
				if (0 <= value && value <= 4)
				{
					this.includeText_0.TextFormat = (TextFormatOptions)value;
				}
			}
		}

		public Dialog2(IncludeText includeText_1)
			: base(includeText_1)
		{
			this.includeText_0 = includeText_1;
		}
	}
}
