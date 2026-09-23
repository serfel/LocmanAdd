using System.Runtime.CompilerServices;
using DocumentServer.Fields;

namespace ns12
{
	internal class Class137 : MailMergeFieldState
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		[CompilerGenerated]
		private int int_0;

		public string String_0
		{
			[CompilerGenerated]
			get
			{
				return this.string_0;
			}
			[CompilerGenerated]
			private set
			{
				this.string_0 = value;
			}
		}

		public string String_1
		{
			[CompilerGenerated]
			get
			{
				return this.string_1;
			}
			[CompilerGenerated]
			private set
			{
				this.string_1 = value;
			}
		}

		public int Int32_0
		{
			[CompilerGenerated]
			get
			{
				return this.int_0;
			}
			[CompilerGenerated]
			private set
			{
				this.int_0 = value;
			}
		}

		public Class137(Dialog2 dialog2_0)
			: base(dialog2_0)
		{
			this.String_0 = dialog2_0.String_1;
			this.String_1 = dialog2_0.String_0;
			this.Int32_0 = dialog2_0.Int32_0;
		}
	}
}
