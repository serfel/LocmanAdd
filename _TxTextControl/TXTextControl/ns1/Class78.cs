using System.Runtime.CompilerServices;
using TXTextControl;

namespace ns1
{
	internal class Class78
	{
		[CompilerGenerated]
		private bool bool_0;

		[CompilerGenerated]
		private ApplicationField applicationField_0;

		public bool Boolean_0
		{
			[CompilerGenerated]
			get
			{
				return this.bool_0;
			}
			[CompilerGenerated]
			private set
			{
				this.bool_0 = value;
			}
		}

		public ApplicationField ApplicationField_0
		{
			[CompilerGenerated]
			get
			{
				return this.applicationField_0;
			}
			[CompilerGenerated]
			private set
			{
				this.applicationField_0 = value;
			}
		}

		public Class78(ApplicationField applicationField_1, bool bool_1)
		{
			this.ApplicationField_0 = applicationField_1;
			this.Boolean_0 = bool_1;
		}

		public Class78(ApplicationField applicationField_1)
			: this(applicationField_1, bool_1: false)
		{
		}
	}
}
