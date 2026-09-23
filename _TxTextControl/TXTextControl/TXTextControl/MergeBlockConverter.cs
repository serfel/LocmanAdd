using System.Collections.Generic;
using ns21;

namespace TXTextControl
{
	internal static class MergeBlockConverter
	{
		public const string BlockNamePrefix = "txmb_";

		internal static int DocumentTargetsToSubTextParts(TextControlCore textControlCore_0, out List<string> blockNamesInvalid)
		{
			SubTextPartCollection subTextPartCollection = new SubTextPartCollection(textControlCore_0, TextPart.Auto);
			DocumentTargetCollection documentTargetCollection = new DocumentTargetCollection(textControlCore_0, TextPart.Auto);
			int num = 0;
			blockNamesInvalid = new List<string>();
			List<Class404> markers = MergeBlockConverter.GetLegacyBlockMarkers(documentTargetCollection);
			blockNamesInvalid.AddRange(MergeBlockConverter.RemoveInvalid(ref markers));
			int count = markers.Count;
			if (count > 0)
			{
				textControlCore_0.method_14(TextPart.Auto, 0, 0);
			}
			for (int i = 0; i < markers.Count; i++)
			{
				Class404 @class = markers[i];
				if (@class.Enum69_0 != 0)
				{
					continue;
				}
				Class404 class2 = null;
				for (int j = i + 1; j < markers.Count; j++)
				{
					Class404 class3 = markers[j];
					if (class3.String_0 == @class.String_0)
					{
						class2 = class3;
						break;
					}
				}
				if (class2 == null)
				{
					continue;
				}
				int num2 = @class.Int32_0 - 1;
				int int_ = class2.Int32_0 - @class.Int32_0;
				textControlCore_0.method_5(TextPart.Auto, num2, int_);
				textControlCore_0.method_7(TextPart.Auto, out var int_2, out var int_3);
				int num3 = int_2 + int_3;
				if (int_2 == num2 && class2.Int32_0 - 1 == num3)
				{
					SubTextPart subTextPart = new SubTextPart("txmb_" + @class.String_0, 0);
					SubTextPartCollection.AddResult addResult = subTextPartCollection.Add(subTextPart);
					if (addResult == SubTextPartCollection.AddResult.Successful)
					{
						documentTargetCollection.Remove(@class.DocumentTarget_0);
						documentTargetCollection.Remove(class2.DocumentTarget_0);
						num++;
					}
					else
					{
						blockNamesInvalid.Add(@class.String_0);
					}
				}
				else
				{
					blockNamesInvalid.Add(@class.String_0);
				}
			}
			if (count > 0)
			{
				textControlCore_0.method_15(TextPart.Auto);
			}
			return num;
		}

		internal static bool SubTextPartsToDocumentTargets(TextControlCore textControlCore_0)
		{
			bool result = false;
			SubTextPartCollection subTextPartCollection = new SubTextPartCollection(textControlCore_0, TextPart.Auto);
			DocumentTargetCollection targets = new DocumentTargetCollection(textControlCore_0, TextPart.Auto);
			List<string> list = new List<string>();
			SubTextPartCollection.SubTextPartEnumerator enumerator = subTextPartCollection.GetEnumerator();
			while (enumerator.MoveNext())
			{
				SubTextPart subTextPart = (SubTextPart)enumerator.Current;
				if (MergeBlockConverter.IsMergeBlock(subTextPart))
				{
					if (MergeBlockConverter.ConvertToLegacyBlock(subTextPart, textControlCore_0, subTextPartCollection, targets))
					{
						enumerator.Reset();
						result = true;
					}
					else
					{
						list.Add(subTextPart.Name.Substring("txmb_".Length));
					}
				}
			}
			if (list.Count > 0)
			{
				throw new MergeBlockConversionException(list);
			}
			return result;
		}

		internal static bool IsMergeBlockSaveable(StreamType iStreamType)
		{
			if (iStreamType != StreamType.PlainAnsiText && iStreamType != StreamType.PlainText && iStreamType != StreamType.XMLFormat && iStreamType != StreamType.AdobePDF && iStreamType != StreamType.AdobePDFA)
			{
				return iStreamType != StreamType.CascadingStylesheet;
			}
			return false;
		}

		private static List<Class404> GetLegacyBlockMarkers(DocumentTargetCollection targets)
		{
			List<Class404> list = new List<Class404>();
			foreach (DocumentTarget target in targets)
			{
				Class404 @class = new Class404(target);
				if (@class.Enum69_0 != Enum69.const_2)
				{
					list.Add(@class);
				}
			}
			return list;
		}

		private static List<string> RemoveInvalid(ref List<Class404> markers)
		{
			List<Class404> list = new List<Class404>();
			List<string> list2 = new List<string>();
			Stack<Class404> stack = new Stack<Class404>();
			foreach (Class404 marker in markers)
			{
				switch (marker.Enum69_0)
				{
				case Enum69.const_0:
					stack.Push(marker);
					break;
				case Enum69.const_1:
					if (!MergeBlockConverter.ContainsMarkerWithName(stack, marker.String_0))
					{
						break;
					}
					while (stack.Count > 0)
					{
						Class404 @class = stack.Pop();
						if (!(@class.String_0 == marker.String_0))
						{
							list2.Add(@class.String_0);
							continue;
						}
						list.Add(@class);
						list.Add(marker);
						break;
					}
					break;
				}
			}
			foreach (Class404 item in stack)
			{
				list2.Add(item.String_0);
			}
			list.Sort(new Class405());
			markers = list;
			return list2;
		}

		private static bool IsMergeBlock(SubTextPart part)
		{
			return part.Name.ToLower().StartsWith("txmb_");
		}

		private static bool ContainsMarkerWithName(Stack<Class404> stack, string blockName)
		{
			foreach (Class404 item in stack)
			{
				if (item.String_0 == blockName)
				{
					return true;
				}
			}
			return false;
		}

		private static bool ConvertToLegacyBlock(SubTextPart part, TextControlCore textControlCore_0, SubTextPartCollection parts, DocumentTargetCollection targets)
		{
			if (!part.Name.ToLower().StartsWith("txmb_"))
			{
				return false;
			}
			string text = part.Name.Substring("txmb_".Length);
			int num = part.Start - 1;
			int int_ = num + part.Length;
			textControlCore_0.method_5(TextPart.Auto, num, 0);
			DocumentTarget documentTarget = new DocumentTarget("blockstart_" + text);
			if (!targets.Add(documentTarget))
			{
				return false;
			}
			textControlCore_0.method_5(TextPart.Auto, int_, 0);
			DocumentTarget documentTarget2 = new DocumentTarget("blockend_" + text);
			if (!targets.Add(documentTarget2))
			{
				targets.Remove(documentTarget);
				return false;
			}
			parts.Remove(part, keepText: true, keepNested: true);
			return true;
		}
	}
}
