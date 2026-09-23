using System;
using System.Collections.Generic;
using ns26;
using TXTextControl.DocumentServer;
using DocumentServer.Fields;

namespace TXTextControl.Windows.Forms
{
	internal static class FieldNavigatorExtensions
	{
		public static bool IsInside(this ApplicationField field, TXITEM_MainPanel.Class579 block)
		{
			int num = field.Start + field.Length;
			if (block.Int32_0 <= field.Start)
			{
				return block.Int32_1 >= num;
			}
			return false;
		}

		public static bool IsInside(this ApplicationField field, IEnumerable<TXITEM_MainPanel.Class579> blocks)
		{
			foreach (TXITEM_MainPanel.Class579 block in blocks)
			{
				if (field.IsInside(block))
				{
					return true;
				}
			}
			return false;
		}

		public static IList<TXITEM_MainPanel.Class579> GetMergeBlocksFlattened(this TextControl textControl)
		{
			List<TXITEM_MainPanel.Class579> list = new List<TXITEM_MainPanel.Class579>();
			if (textControl.SubTextParts.Count == 0)
			{
				return list;
			}
			List<SubTextPart> list2 = new List<SubTextPart>();
			foreach (SubTextPart subTextPart in textControl.SubTextParts)
			{
				if (!string.IsNullOrEmpty(subTextPart.Name) && subTextPart.Name.StartsWith(MailMerge.MergeBlockNamePrefix, StringComparison.OrdinalIgnoreCase))
				{
					list2.Add(subTextPart);
				}
			}
			foreach (SubTextPart item2 in list2)
			{
				TXITEM_MainPanel.Class579 item = new TXITEM_MainPanel.Class579(item2, textControl);
				list.Add(item);
			}
			list.Sort(TXITEM_MainPanel.Class579.IComparer_1);
			return list;
		}

		public static MergeField ToFieldAdapter(this ApplicationField field)
		{
			string typeName;
			if ((typeName = field.TypeName) != null && typeName == "MERGEFIELD")
			{
				return new MergeField(field);
			}
			return null;
		}
	}
}
