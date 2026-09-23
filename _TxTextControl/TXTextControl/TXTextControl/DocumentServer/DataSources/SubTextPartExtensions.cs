using System;
using System.Collections.Generic;
using System.Linq;
using ns6;
using TXTextControl;

namespace DocumentServer.DataSources
{
	internal static class SubTextPartExtensions
	{
		public static SubTextPart[] GetFirstGenChildren(this SubTextPart subTextPart)
		{
			SubTextPart[] array = new SubTextPart[0];
			try
			{
				array = subTextPart.GetChildren();
			}
			catch
			{
			}
			if (array == null)
			{
				return new SubTextPart[0];
			}
			return array.Where((SubTextPart part) => part.NestedLevel == subTextPart.NestedLevel + 1).ToArray();
		}

		public static bool Contains(this SubTextPart part, TextField field)
		{
			int num = field.Start + field.Length;
			int num2 = part.Start + part.Length;
			if (field.Start >= part.Start)
			{
				return num <= num2;
			}
			return false;
		}

		public static bool Contain(this IEnumerable<SubTextPart> subTextParts, TextField field)
		{
			return subTextParts.Any((SubTextPart subTextPart_0) => subTextPart_0.Contains(field));
		}

		public static IList<MergeBlockInfo> GetMergeBlocksFlattened(this Class103 textControl)
		{
			List<MergeBlockInfo> list = new List<MergeBlockInfo>();
			if (textControl.SubTextPartCollection_0.Count == 0)
			{
				return list;
			}
			foreach (SubTextPart item in textControl.SubTextPartCollection_0)
			{
				if (!string.IsNullOrEmpty(item.Name) && item.Name.StartsWith("txmb_", StringComparison.OrdinalIgnoreCase))
				{
					list.Add(new MergeBlockInfo(item));
				}
			}
			list.Sort(MergeBlockInfo.IComparer_0);
			return list;
		}
	}
}
