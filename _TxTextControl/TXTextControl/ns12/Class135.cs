using System.Runtime.CompilerServices;
using DocumentServer.Fields;

namespace ns12
{
	internal class Class135 : MailMergeFieldState
	{
		[CompilerGenerated]
		private string string_0;

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

		public Class135(Dialog0 dialog0_0)
			: base(dialog0_0)
		{
			this.String_0 = dialog0_0.String_0;
		}
	}
}
