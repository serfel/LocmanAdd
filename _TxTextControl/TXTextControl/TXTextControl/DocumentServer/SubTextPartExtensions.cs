using System;
using DocumentServer.DataShaping;
using DocumentServer.Json;
using DocumentServer.Properties;

namespace TXTextControl.DocumentServer
{
	internal static class SubTextPartExtensions
	{
		public static MergeBlockMetaData GetMergeBlockMetaData(this SubTextPart part)
		{
			if (!part.Name.StartsWith("txmb_"))
			{
				return null;
			}
			string text = part.Name.Substring("txmb_".Length);
			if (string.IsNullOrEmpty(text))
			{
				return null;
			}
			MergeBlockMetaData result = new MergeBlockMetaData(text);
			if (!string.IsNullOrEmpty(part.Data))
			{
				try
				{
					result = JsonConvert.Deserialize<MergeBlockMetaData>(part.Data);
					return result;
				}
				catch
				{
					return result;
				}
			}
			return result;
		}

		public static void StoreMergeBlockMetaData(this SubTextPart part, FilterInstruction[] filters, SortingInstruction[] sortingInstructions)
		{
			MergeBlockMetaData mergeBlockMetaData = part.GetMergeBlockMetaData();
			if (mergeBlockMetaData == null)
			{
				throw new Exception(Resources.EXC_SUBTEXTPART_IS_NO_MERGEBLOCK);
			}
			mergeBlockMetaData.DataShapingInfo = mergeBlockMetaData.DataShapingInfo ?? new DataShapingInfo();
			mergeBlockMetaData.DataShapingInfo.Filters = filters;
			mergeBlockMetaData.DataShapingInfo.SortingInstructions = sortingInstructions;
			if ((filters != null && filters.Length != 0) || (sortingInstructions != null && sortingInstructions.Length != 0))
			{
				part.Data = JsonConvert.Serialize(mergeBlockMetaData);
			}
			else
			{
				part.Data = "";
			}
		}
	}
}
