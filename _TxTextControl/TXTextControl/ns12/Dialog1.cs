using DocumentServer.Fields;

namespace ns12
{
	internal class Dialog1 : MailMergeFieldDialogCommon
	{
		private IfField ifField_0;

		public string String_0
		{
			get
			{
				return this.ifField_0.Expression1;
			}
			set
			{
				this.ifField_0.Expression1 = value;
			}
		}

		public string String_1
		{
			get
			{
				return this.ifField_0.Expression2;
			}
			set
			{
				this.ifField_0.Expression2 = value;
			}
		}

		public string String_2
		{
			get
			{
				return this.ifField_0.TrueText;
			}
			set
			{
				this.ifField_0.TrueText = value;
			}
		}

		public string String_3
		{
			get
			{
				return this.ifField_0.FalseText;
			}
			set
			{
				this.ifField_0.FalseText = value;
			}
		}

		public int Int32_0
		{
			get
			{
				return (int)this.ifField_0.Operator;
			}
			set
			{
				if (0 <= value && value <= 5)
				{
					this.ifField_0.Operator = (IfField.RelationalOperator)value;
				}
			}
		}

		public Dialog1(IfField ifField_1)
			: base(ifField_1)
		{
			this.ifField_0 = ifField_1;
		}
	}
}
