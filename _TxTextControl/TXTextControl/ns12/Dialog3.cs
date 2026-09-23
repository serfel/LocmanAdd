using DocumentServer.Fields;

namespace ns12
{
	internal class Dialog3 : MailMergeFieldDialogCommon
	{
		private MergeField mergeField_0;

		public string String_0
		{
			get
			{
				return this.mergeField_0.Text;
			}
			set
			{
				this.mergeField_0.Text = value;
			}
		}

		public string String_1
		{
			get
			{
				return this.mergeField_0.Name;
			}
			set
			{
				this.mergeField_0.Name = value;
			}
		}

		public string String_2
		{
			get
			{
				return this.mergeField_0.TextBefore;
			}
			set
			{
				this.mergeField_0.TextBefore = value;
			}
		}

		public string String_3
		{
			get
			{
				return this.mergeField_0.TextAfter;
			}
			set
			{
				this.mergeField_0.TextAfter = value;
			}
		}

		public string String_4
		{
			get
			{
				return this.mergeField_0.DateTimeFormat;
			}
			set
			{
				this.mergeField_0.DateTimeFormat = value;
			}
		}

		public string String_5
		{
			get
			{
				return this.mergeField_0.NumericFormat;
			}
			set
			{
				this.mergeField_0.NumericFormat = value;
			}
		}

		public int Int32_0
		{
			get
			{
				return (int)this.mergeField_0.TextFormat;
			}
			set
			{
				if (0 <= value && value <= 4)
				{
					this.mergeField_0.TextFormat = (TextFormatOptions)value;
				}
			}
		}

		public Dialog3(MergeField mergeField_1)
			: base(mergeField_1)
		{
			this.mergeField_0 = mergeField_1;
		}
	}
}
