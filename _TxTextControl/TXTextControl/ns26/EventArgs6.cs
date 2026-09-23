using System;
using System.Runtime.CompilerServices;
using DocumentServer.Fields;

namespace ns26
{
	internal class EventArgs6 : EventArgs
	{
		[CompilerGenerated]
		private MergeField mergeField_0;

		public MergeField MergeField_0
		{
			[CompilerGenerated]
			get
			{
				return this.mergeField_0;
			}
			[CompilerGenerated]
			private set
			{
				this.mergeField_0 = value;
			}
		}

		public EventArgs6(MergeField mergeField_1)
		{
			this.MergeField_0 = mergeField_1;
		}
	}
}
