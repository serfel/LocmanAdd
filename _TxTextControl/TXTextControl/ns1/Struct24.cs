using TXTextControl;

namespace ns1
{
	internal struct Struct24
	{
		private PageSize pageSize_0;

		private PageMargins pageMargins_0;

		private bool bool_0;

		private string string_0;

		public PageSize PageSize_0
		{
			get
			{
				return this.pageSize_0;
			}
			set
			{
				this.pageSize_0 = value;
			}
		}

		public PageMargins PageMargins_0
		{
			get
			{
				return this.pageMargins_0;
			}
			set
			{
				this.pageMargins_0 = value;
			}
		}

		public bool Boolean_0
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}

		public string String_0
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}

		internal Struct24(PageSize pageSize_1, PageMargins pageMargins_1, bool bool_1, string string_1)
		{
			this.pageSize_0 = pageSize_1;
			this.pageMargins_0 = pageMargins_1;
			this.bool_0 = bool_1;
			this.string_0 = string_1;
		}
	}
}
