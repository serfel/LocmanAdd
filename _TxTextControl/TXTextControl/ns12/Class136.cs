using System.Runtime.CompilerServices;
using DocumentServer.Fields;

namespace ns12
{
	internal class Class136 : MailMergeFieldState
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		[CompilerGenerated]
		private string string_2;

		[CompilerGenerated]
		private string string_3;

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

		public string String_2
		{
			[CompilerGenerated]
			get
			{
				return this.string_2;
			}
			[CompilerGenerated]
			private set
			{
				this.string_2 = value;
			}
		}

		public string String_3
		{
			[CompilerGenerated]
			get
			{
				return this.string_3;
			}
			[CompilerGenerated]
			private set
			{
				this.string_3 = value;
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

		public Class136(Dialog1 dialog1_0)
			: base(dialog1_0)
		{
			this.String_0 = dialog1_0.String_0;
			this.String_1 = dialog1_0.String_1;
			this.String_2 = dialog1_0.String_3;
			this.String_3 = dialog1_0.String_2;
			this.Int32_0 = dialog1_0.Int32_0;
		}
	}
}
