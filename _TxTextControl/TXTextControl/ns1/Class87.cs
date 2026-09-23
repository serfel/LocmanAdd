using System.Collections.Generic;
using TXTextControl;

namespace ns1
{
	internal class Class87 : IComparer<DocumentTarget>
	{
		public int Compare(DocumentTarget x, DocumentTarget y)
		{
			return x.Start - y.Start;
		}
	}
}
