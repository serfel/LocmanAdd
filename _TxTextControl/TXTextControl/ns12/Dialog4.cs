using DocumentServer.Fields;

namespace ns12
{
	internal class Dialog4 : MailMergeFieldDialogCommon
	{
		private NextIfField nextIfField_0;

		public string String_0
		{
			get
			{
				return this.nextIfField_0.Expression1;
			}
			set
			{
				this.nextIfField_0.Expression1 = value;
			}
		}

		public string String_1
		{
			get
			{
				return this.nextIfField_0.Expression2;
			}
			set
			{
				this.nextIfField_0.Expression2 = value;
			}
		}

		public int Int32_0
		{
			get
			{
				return (int)this.nextIfField_0.Operator;
			}
			set
			{
				if (0 <= value && value <= 5)
				{
					this.nextIfField_0.Operator = (IfField.RelationalOperator)value;
				}
			}
		}

		public Dialog4(NextIfField nextIfField_1)
			: base(nextIfField_1)
		{
			this.nextIfField_0 = nextIfField_1;
		}
	}
}
