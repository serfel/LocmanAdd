using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TXTextControl
{
	public class MergeBlockConversionException : Exception
	{
		[CompilerGenerated]
		private List<string> list_0;

		public List<string> BlockNamesUnconverted
		{
			[CompilerGenerated]
			get
			{
				return this.list_0;
			}
			[CompilerGenerated]
			private set
			{
				this.list_0 = value;
			}
		}

		public MergeBlockConversionException(List<string> blockNamesUnconverted)
			: base("One or more merge blocks could not be converted.")
		{
			this.BlockNamesUnconverted = blockNamesUnconverted;
		}
	}
}
