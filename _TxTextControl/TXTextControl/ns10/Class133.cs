using System.Collections.Generic;
using DocumentServer.DataSources;

namespace ns10
{
	internal class Class133 : IComparer<MergeBlockInfo>
	{
		int IComparer<MergeBlockInfo>.Compare(MergeBlockInfo x, MergeBlockInfo y)
		{
			return x.Int32_0 - y.Int32_0;
		}
	}
}
