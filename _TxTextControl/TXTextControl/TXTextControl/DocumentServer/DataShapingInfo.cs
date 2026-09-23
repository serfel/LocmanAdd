using System.Reflection;
using System.Runtime.CompilerServices;
using DocumentServer.DataShaping;

namespace TXTextControl.DocumentServer
{
	[Obfuscation(Exclude = true)]
	internal class DataShapingInfo
	{
		[CompilerGenerated]
		private FilterInstruction[] filterInstruction_0;

		[CompilerGenerated]
		private FilterInstruction[] filterInstruction_1;

		[CompilerGenerated]
		private SortingInstruction[] sortingInstruction_0;

		public FilterInstruction[] BlockMergingCondition
		{
			[CompilerGenerated]
			get
			{
				return this.filterInstruction_0;
			}
			[CompilerGenerated]
			set
			{
				this.filterInstruction_0 = value;
			}
		}

		public FilterInstruction[] Filters
		{
			[CompilerGenerated]
			get
			{
				return this.filterInstruction_1;
			}
			[CompilerGenerated]
			set
			{
				this.filterInstruction_1 = value;
			}
		}

		public SortingInstruction[] SortingInstructions
		{
			[CompilerGenerated]
			get
			{
				return this.sortingInstruction_0;
			}
			[CompilerGenerated]
			set
			{
				this.sortingInstruction_0 = value;
			}
		}
	}
}
