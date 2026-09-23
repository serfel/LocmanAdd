using System;
using System.Collections.Generic;
using System.Diagnostics;
using ns1;

namespace TXTextControl.DocumentServer
{
	internal static class MergeBlockExtensions
	{
		public static bool Contain(this List<Class86> mergeBlocks, ApplicationField field)
		{
			int nFldStart = field.Start;
			int nFldEnd = nFldStart - 1 + field.Length;
			if (mergeBlocks != null)
			{
				return mergeBlocks.Find((Class86 block) => block.Int32_0 <= nFldStart && block.Int32_2 >= nFldEnd) != null;
			}
			return false;
		}

		public static List<Class86> GetMergeBlocks(this ServerTextControl serverTextControl_0, TraceSource traceSource, bool justGetPositions, object textComponent)
		{
			List<Class86> list = new List<Class86>();
			int offset = 0;
			Class86 mergeBlock;
			while (serverTextControl_0.GetMergeBlock(out mergeBlock, offset, justGetPositions, textComponent))
			{
				if (mergeBlock != null)
				{
					list.Add(mergeBlock);
					offset = mergeBlock.Int32_2;
				}
			}
			return list;
		}

		public static bool GetMergeBlock(this ServerTextControl serverTextControl_0, out Class86 mergeBlock, int offset, bool justGetPositions, object textComponent)
		{
			mergeBlock = null;
			foreach (SubTextPart subTextPart in serverTextControl_0.SubTextParts)
			{
				if (subTextPart.Start >= offset && !string.IsNullOrEmpty(subTextPart.Name) && subTextPart.Name.StartsWith("txmb_", StringComparison.OrdinalIgnoreCase))
				{
					byte[] binaryData = null;
					if (!justGetPositions)
					{
						subTextPart.Save(out binaryData, BinaryStreamType.InternalUnicodeFormat);
						MergeBlockExtensions.RemoveOutermostSubTextPartFromBlockData(ref binaryData, textComponent);
					}
					mergeBlock = new Class86(subTextPart, binaryData, textComponent);
					return true;
				}
			}
			return false;
		}

		private static void RemoveOutermostSubTextPartFromBlockData(ref byte[] blockData, object textComponent)
		{
			using ServerTextControl serverTextControl = new ServerTextControl(textComponent.GetType());
			serverTextControl.Create();
			serverTextControl.Load(blockData, BinaryStreamType.InternalUnicodeFormat, new LoadSettings
			{
				ApplicationFieldFormat = ApplicationFieldFormat.MSWordTXFormFields
			});
			SubTextPart subTextPart = null;
			foreach (SubTextPart subTextPart2 in serverTextControl.SubTextParts)
			{
				if (subTextPart == null)
				{
					subTextPart = subTextPart2;
					break;
				}
			}
			if (subTextPart != null)
			{
				serverTextControl.SubTextParts.Remove(subTextPart, keepText: true, keepNested: true);
				serverTextControl.Save(out blockData, BinaryStreamType.InternalUnicodeFormat);
			}
		}
	}
}
