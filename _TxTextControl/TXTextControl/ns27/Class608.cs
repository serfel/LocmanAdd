using System;
using System.Collections.Generic;
using System.Drawing;
using Interop.UIAutomationCore;
using ns21;
using TXTextControl;

namespace ns27
{
	internal class Class608 : ITextRangeProvider
	{
		private IRawElementProviderSimple irawElementProviderSimple_0;

		private TextControl textControl_0;

		private TextPart textPart_0;

		internal int int_0;

		internal int int_1;

		internal Class608(TextControl textControl_1, int int_2, int int_3, TextPart textPart_1, IRawElementProviderSimple irawElementProviderSimple_1)
		{
			this.textControl_0 = textControl_1;
			this.textPart_0 = textPart_1;
			this.int_0 = int_2;
			this.int_1 = int_3;
			this.irawElementProviderSimple_0 = irawElementProviderSimple_1;
		}

		string ITextRangeProvider.GetText(int maxLength)
		{
			if (!this.textControl_0.textControlCore_0.isHandleCreated)
			{
				throw new InvalidOperationException();
			}
			string string_ = "";
			if (this.int_1 > this.int_0)
			{
				SaveSettings saveSettings = new SaveSettings();
				saveSettings.TextPart = this.textPart_0;
				SaveSettings saveSettings2 = saveSettings;
				this.textControl_0.textControlCore_0.method_14(this.textPart_0, this.int_0, this.int_1 - this.int_0);
				saveSettings2.method_4(out string_, StringStreamType.PlainText, this.textControl_0.textControlCore_0, Enum104.const_7);
				this.textControl_0.textControlCore_0.method_15(this.textPart_0);
			}
			if (string_.Length > maxLength && maxLength != -1)
			{
				return string_.Substring(0, maxLength);
			}
			return string_;
		}

		void ITextRangeProvider.Select()
		{
			if (!this.textControl_0.textControlCore_0.isHandleCreated)
			{
				throw new InvalidOperationException();
			}
			this.textControl_0.textControlCore_0.method_5(this.textPart_0, this.int_0, this.int_1 - this.int_0);
		}

		double[] ITextRangeProvider.GetBoundingRectangles()
		{
			double[] result = new double[0];
			if (this.int_1 > this.int_0)
			{
				LineCollection lineCollection = new LineCollection(this.textControl_0.textControlCore_0, this.textPart_0);
				TextCharCollection textCharCollection = new TextCharCollection(this.textControl_0.textControlCore_0, this.textPart_0);
				Line item = lineCollection.GetItem(this.int_0);
				Line item2 = lineCollection.GetItem(this.int_1);
				if (item == null || item2 == null)
				{
					throw new InvalidOperationException();
				}
				int number = item.Number;
				int num = item2.Number;
				if (num > number && this.int_1 == item2.Start - 1)
				{
					num--;
				}
				int num2 = num - number + 1;
				List<double> list = new List<double>();
				Class429.Struct83 struct83_ = default(Class429.Struct83);
				Class429.GetClientRect(this.textControl_0.textControlCore_0.IntPtr_0, ref struct83_);
				Rectangle rect = struct83_.method_0();
				for (int i = 0; i < num2; i++)
				{
					Line line = lineCollection[number + i];
					Class429.Struct83 struct83_2 = new Class429.Struct83(line.TextBounds);
					this.textControl_0.textControlCore_0.method_33(this.textPart_0, Enum83.const_320, Class429.smethod_3(2, 6), ref struct83_2);
					Rectangle rectangle = struct83_2.method_0();
					if (i == 0 && this.int_0 > line.Start - 1)
					{
						Class429.Struct83 struct83_3 = new Class429.Struct83(textCharCollection[this.int_0 + 1].Bounds);
						this.textControl_0.textControlCore_0.method_33(this.textPart_0, Enum83.const_320, Class429.smethod_3(2, 6), ref struct83_3);
						rectangle.Width = rectangle.Right - struct83_3.int_0;
						rectangle.X = struct83_3.int_0;
					}
					if (i == num2 - 1)
					{
						int length = line.Length;
						int num3 = line.Start + length - 1;
						if (number + i < lineCollection.Count)
						{
							num3--;
						}
						if (length > 1 && this.int_1 < num3)
						{
							Class429.Struct83 struct83_4 = new Class429.Struct83(textCharCollection[this.int_1].Bounds);
							this.textControl_0.textControlCore_0.method_33(this.textPart_0, Enum83.const_320, Class429.smethod_3(2, 6), ref struct83_4);
							rectangle.Width = struct83_4.int_2 - rectangle.Left;
						}
					}
					rectangle.Intersect(rect);
					if (!rectangle.IsEmpty)
					{
						Point p = new Point(rectangle.X, rectangle.Y);
						p = this.textControl_0.PointToScreen(p);
						list.Add(p.X);
						list.Add(p.Y);
						list.Add(rectangle.Width);
						list.Add(rectangle.Height);
					}
				}
				if (list.Count > 0)
				{
					result = list.ToArray();
				}
			}
			return result;
		}

		IRawElementProviderSimple ITextRangeProvider.GetEnclosingElement()
		{
			return this.irawElementProviderSimple_0;
		}

		void ITextRangeProvider.ScrollIntoView(int alignToTop)
		{
			if (this.textPart_0 != TextPart.MainText)
			{
				return;
			}
			TextCharCollection textCharCollection = new TextCharCollection(this.textControl_0.textControlCore_0, this.textPart_0);
			if (alignToTop == 1)
			{
				TextChar textChar = textCharCollection[this.int_0 + 1];
				if (textChar != null)
				{
					Rectangle bounds = textChar.Bounds;
					this.textControl_0.textControlCore_0.method_30(Enum83.const_43, 2, bounds.Top);
				}
				return;
			}
			TextChar textChar2 = textCharCollection[this.int_1];
			if (textChar2 != null)
			{
				Class429.Struct83 struct83_ = default(Class429.Struct83);
				Class429.GetClientRect(this.textControl_0.textControlCore_0.IntPtr_0, ref struct83_);
				this.textControl_0.textControlCore_0.method_33(this.textPart_0, Enum83.const_320, Class429.smethod_3(2, 1), ref struct83_);
				Rectangle bounds2 = textChar2.Bounds;
				this.textControl_0.textControlCore_0.method_30(Enum83.const_43, 2, bounds2.Bottom - (struct83_.int_3 - struct83_.int_1));
			}
		}

		ITextRangeProvider ITextRangeProvider.Clone()
		{
			return new Class608(this.textControl_0, this.int_0, this.int_1, this.textPart_0, this.irawElementProviderSimple_0);
		}

		int ITextRangeProvider.Compare(ITextRangeProvider range)
		{
			Class608 @class = this.method_0(range);
			if (this.int_0 == @class.int_0 && this.int_1 == @class.int_1)
			{
				return 1;
			}
			return 0;
		}

		int ITextRangeProvider.CompareEndpoints(TextPatternRangeEndpoint endpoint, ITextRangeProvider targetRange, TextPatternRangeEndpoint targetEndpoint)
		{
			Class608 @class = this.method_0(targetRange);
			int num = ((endpoint == TextPatternRangeEndpoint.TextPatternRangeEndpoint_Start) ? this.int_0 : this.int_1);
			int num2 = ((targetEndpoint == TextPatternRangeEndpoint.TextPatternRangeEndpoint_Start) ? @class.int_0 : @class.int_1);
			if (num != num2)
			{
				if (num >= num2)
				{
					return 1;
				}
				return -1;
			}
			return 0;
		}

		void ITextRangeProvider.ExpandToEnclosingUnit(TextUnit unit)
		{
			this.method_1(unit);
		}

		int ITextRangeProvider.Move(TextUnit unit, int count)
		{
			int num = 0;
			int num2 = this.method_1(unit);
			switch (unit)
			{
			case TextUnit.TextUnit_Character:
				if (count < 0)
				{
					num = -Math.Min(this.int_0, -count);
				}
				if (count > 0)
				{
					int num3 = this.textControl_0.textControlCore_0.method_29(this.textPart_0, 1136, 0, 0);
					num = Math.Min(num3 - this.int_1, count);
				}
				this.int_0 += num;
				this.int_1 += num;
				break;
			case TextUnit.TextUnit_Word:
				if (count < 0)
				{
					int[] array = new int[3];
					int num4 = count;
					while (this.int_0 > 0 && num4 < 0)
					{
						array[0] = this.int_0 - 1;
						this.textControl_0.textControlCore_0.method_40(this.textPart_0, 1989, 3, array);
						this.int_0 = array[1];
						this.int_1 = array[2];
						num4++;
					}
					num = count - num4;
				}
				if (count > 0)
				{
					int num5 = this.textControl_0.textControlCore_0.method_29(this.textPart_0, 1136, 0, 0);
					int[] array2 = new int[3];
					int num6 = count;
					while (this.int_1 < num5 && num6 > 0)
					{
						array2[0] = this.int_1;
						this.textControl_0.textControlCore_0.method_41(Enum83.const_319, 3, array2);
						this.int_0 = array2[1];
						this.int_1 = array2[2];
						num6--;
					}
					num = count - num6;
				}
				break;
			case TextUnit.TextUnit_Line:
			{
				if (num2 == 0)
				{
					break;
				}
				LineCollection lineCollection = new LineCollection(this.textControl_0.textControlCore_0, this.textPart_0);
				if (lineCollection == null)
				{
					break;
				}
				if (count < 0)
				{
					num = -Math.Min(num2 - 1, -count);
				}
				if (count > 0)
				{
					num = Math.Min(lineCollection.Count - num2, count);
				}
				if (num != 0)
				{
					Line line = lineCollection[num2 + num];
					if (line != null)
					{
						this.int_0 = line.Start - 1;
						this.int_1 = line.Start + line.Length - 1;
					}
				}
				break;
			}
			case TextUnit.TextUnit_Paragraph:
			{
				if (num2 == 0)
				{
					break;
				}
				ParagraphCollection paragraphCollection = new ParagraphCollection(this.textControl_0.textControlCore_0, this.textPart_0);
				if (paragraphCollection == null)
				{
					break;
				}
				if (count < 0)
				{
					num = -Math.Min(num2 - 1, -count);
				}
				if (count > 0)
				{
					num = Math.Min(paragraphCollection.Count - num2, count);
				}
				if (num != 0)
				{
					Paragraph paragraph = paragraphCollection[num2 + num];
					if (paragraph != null)
					{
						this.int_0 = paragraph.Start - 1;
						this.int_1 = paragraph.Start + paragraph.Length - 1;
					}
				}
				break;
			}
			case TextUnit.TextUnit_Page:
			{
				if (num2 == 0 || this.textPart_0 != TextPart.MainText)
				{
					break;
				}
				PageCollection pageCollection = new PageCollection(this.textControl_0.textControlCore_0);
				if (pageCollection == null)
				{
					break;
				}
				if (count < 0)
				{
					num = -Math.Min(num2 - 1, -count);
				}
				if (count > 0)
				{
					num = Math.Min(pageCollection.Count - num2, count);
				}
				if (num != 0)
				{
					Page page = pageCollection[num2 + num];
					if (page != null)
					{
						this.int_0 = page.Start - 1;
						this.int_1 = page.Start + page.Length - 1;
					}
				}
				break;
			}
			}
			return num;
		}

		int ITextRangeProvider.MoveEndpointByUnit(TextPatternRangeEndpoint endpoint, TextUnit unit, int count)
		{
			int num = 0;
			int num2 = ((endpoint == TextPatternRangeEndpoint.TextPatternRangeEndpoint_Start) ? this.int_0 : this.int_1);
			switch (unit)
			{
			case TextUnit.TextUnit_Character:
				if (count < 0)
				{
					num = -Math.Min(num2, -count);
				}
				if (count > 0)
				{
					int num4 = this.textControl_0.textControlCore_0.method_29(this.textPart_0, 1136, 0, 0);
					num = Math.Min(num4 - num2, count);
				}
				if (num != 0)
				{
					if (endpoint == TextPatternRangeEndpoint.TextPatternRangeEndpoint_Start)
					{
						this.int_0 = (this.int_0 += num);
					}
					if (endpoint == TextPatternRangeEndpoint.TextPatternRangeEndpoint_End)
					{
						this.int_1 = (this.int_1 += num);
					}
				}
				break;
			case TextUnit.TextUnit_Word:
				if (count < 0)
				{
					int[] array = new int[3];
					int num5 = count;
					while (num2 > 0 && num5 < 0)
					{
						array[0] = num2 - 1;
						this.textControl_0.textControlCore_0.method_40(this.textPart_0, 1989, 3, array);
						num2 = array[1];
						num5++;
					}
					switch (endpoint)
					{
					case TextPatternRangeEndpoint.TextPatternRangeEndpoint_Start:
						this.int_0 = num2;
						break;
					case TextPatternRangeEndpoint.TextPatternRangeEndpoint_End:
						this.int_1 = num2;
						break;
					}
					num = count - num5;
				}
				else if (count > 0)
				{
					int num6 = this.textControl_0.textControlCore_0.method_29(this.textPart_0, 1136, 0, 0);
					int[] array2 = new int[3];
					int num7 = count;
					while (num2 < num6 && num7 > 0)
					{
						array2[0] = num2;
						this.textControl_0.textControlCore_0.method_40(this.textPart_0, 1989, 3, array2);
						num2 = array2[2];
						num7--;
					}
					switch (endpoint)
					{
					case TextPatternRangeEndpoint.TextPatternRangeEndpoint_Start:
						this.int_0 = num2;
						break;
					case TextPatternRangeEndpoint.TextPatternRangeEndpoint_End:
						this.int_1 = num2;
						break;
					}
					num = count - num7;
				}
				break;
			case TextUnit.TextUnit_Line:
			{
				LineCollection lineCollection = new LineCollection(this.textControl_0.textControlCore_0, this.textPart_0);
				if (lineCollection == null)
				{
					break;
				}
				Line item = lineCollection.GetItem(num2);
				int number = item.Number;
				if (count < 0)
				{
					num = -Math.Min(number - 1, -count);
				}
				if (count > 0)
				{
					num = Math.Min(lineCollection.Count - number, count);
				}
				if (num == 0)
				{
					break;
				}
				Line line = lineCollection[number + num];
				if (line != null)
				{
					if (endpoint == TextPatternRangeEndpoint.TextPatternRangeEndpoint_Start)
					{
						this.int_0 = line.Start - 1;
					}
					if (endpoint == TextPatternRangeEndpoint.TextPatternRangeEndpoint_End)
					{
						this.int_1 = line.Start - 1;
					}
				}
				break;
			}
			case TextUnit.TextUnit_Paragraph:
			{
				ParagraphCollection paragraphCollection = new ParagraphCollection(this.textControl_0.textControlCore_0, this.textPart_0);
				if (paragraphCollection == null)
				{
					break;
				}
				Paragraph item3 = paragraphCollection.GetItem(num2);
				int number3 = item3.Number;
				if (count < 0)
				{
					num = -Math.Min(number3 - 1, -count);
				}
				if (count > 0)
				{
					num = Math.Min(paragraphCollection.Count - number3, count);
				}
				if (num == 0)
				{
					break;
				}
				Paragraph paragraph = paragraphCollection[number3 + num];
				if (paragraph != null)
				{
					if (endpoint == TextPatternRangeEndpoint.TextPatternRangeEndpoint_Start)
					{
						this.int_0 = paragraph.Start - 1;
					}
					if (endpoint == TextPatternRangeEndpoint.TextPatternRangeEndpoint_End)
					{
						this.int_1 = paragraph.Start - 1;
					}
				}
				break;
			}
			case TextUnit.TextUnit_Page:
			{
				if (this.textPart_0 != TextPart.MainText)
				{
					break;
				}
				PageCollection pageCollection = new PageCollection(this.textControl_0.textControlCore_0);
				if (pageCollection == null)
				{
					break;
				}
				Page item2 = pageCollection.GetItem(num2);
				int number2 = item2.Number;
				if (count < 0)
				{
					num = -Math.Min(number2 - 1, -count);
				}
				if (count > 0)
				{
					num = Math.Min(pageCollection.Count - number2, count);
				}
				if (num == 0)
				{
					break;
				}
				Page page = pageCollection[number2 + num];
				if (page != null)
				{
					if (endpoint == TextPatternRangeEndpoint.TextPatternRangeEndpoint_Start)
					{
						this.int_0 = page.Start - 1;
					}
					if (endpoint == TextPatternRangeEndpoint.TextPatternRangeEndpoint_End)
					{
						this.int_1 = page.Start - 1;
					}
				}
				break;
			}
			case TextUnit.TextUnit_Format:
			case TextUnit.TextUnit_Document:
				if (endpoint == TextPatternRangeEndpoint.TextPatternRangeEndpoint_Start && count < 0)
				{
					this.int_0 = 0;
					num = -1;
				}
				if (endpoint == TextPatternRangeEndpoint.TextPatternRangeEndpoint_End && count > 0)
				{
					int num3 = (this.int_1 = this.textControl_0.textControlCore_0.method_29(this.textPart_0, 1136, 0, 0));
					num = 1;
				}
				break;
			}
			if (this.int_1 < this.int_0)
			{
				if (endpoint == TextPatternRangeEndpoint.TextPatternRangeEndpoint_Start)
				{
					this.int_1 = Math.Max(this.int_1, this.int_0);
				}
				else
				{
					this.int_0 = Math.Min(this.int_0, this.int_1);
				}
			}
			return num;
		}

		void ITextRangeProvider.MoveEndpointByRange(TextPatternRangeEndpoint endpoint, ITextRangeProvider targetRange, TextPatternRangeEndpoint targetEndpoint)
		{
			Class608 @class = this.method_0(targetRange);
			int num = ((targetEndpoint == TextPatternRangeEndpoint.TextPatternRangeEndpoint_Start) ? @class.int_0 : @class.int_1);
			if (endpoint == TextPatternRangeEndpoint.TextPatternRangeEndpoint_Start)
			{
				this.int_0 = num;
				this.int_1 = Math.Max(this.int_1, this.int_0);
			}
			else
			{
				this.int_1 = num;
				this.int_0 = Math.Min(this.int_0, this.int_1);
			}
		}

		object ITextRangeProvider.GetAttributeValue(int attributeId)
		{
			if (!this.textControl_0.textControlCore_0.isHandleCreated)
			{
				throw new InvalidOperationException();
			}
			object obj = null;
			this.textControl_0.textControlCore_0.method_16(this.textPart_0, this.int_0, this.int_1 - this.int_0);
			Selection selection = this.textControl_0.Selection;
			switch (attributeId)
			{
			case 40001:
				obj = (selection.IsCommonValueSelected(Selection.Attribute.TextBackColor) ? ((object)Class429.smethod_0(selection.TextBackColor)) : Class605.smethod_1());
				break;
			case 40004:
				obj = (selection.IsCommonValueSelected(Selection.Attribute.Culture) ? ((object)selection.Culture.LCID) : Class605.smethod_1());
				break;
			case 40005:
				obj = (selection.IsCommonValueSelected(Selection.Attribute.FontName) ? selection.FontName : Class605.smethod_1());
				break;
			case 40006:
				obj = (selection.IsCommonValueSelected(Selection.Attribute.FontSize) ? ((object)((double)selection.FontSize / 20.0)) : Class605.smethod_1());
				break;
			case 40007:
				obj = (selection.IsCommonValueSelected(Selection.Attribute.Bold) ? ((object)(selection.Bold ? 700 : 400)) : Class605.smethod_1());
				break;
			case 40008:
				obj = (selection.IsCommonValueSelected(Selection.Attribute.ForeColor) ? ((object)Class429.smethod_0(selection.ForeColor)) : Class605.smethod_1());
				break;
			case 40009:
			{
				HorizontalAlignment alignment = selection.ParagraphFormat.Alignment;
				obj = (selection.IsCommonValueSelected(ParagraphFormat.Attribute.Alignment) ? ((object)(alignment switch
				{
					HorizontalAlignment.Center => 1, 
					HorizontalAlignment.Right => 2, 
					HorizontalAlignment.Left => 0, 
					_ => 3, 
				})) : Class605.smethod_1());
				break;
			}
			case 40010:
			case 40011:
			case 40012:
			{
				int[] array = new int[5];
				int num = 0;
				this.textControl_0.textControlCore_0.method_40(this.textPart_0, 1144, 0, array);
				switch (attributeId)
				{
				case 40010:
					num = array[2];
					break;
				case 40011:
					num = array[0];
					break;
				case 40012:
					num = array[1];
					break;
				}
				obj = ((num != 32768) ? ((object)((double)num / 20.0)) : Class605.smethod_1());
				break;
			}
			case 40014:
				obj = (selection.IsCommonValueSelected(Selection.Attribute.Italic) ? ((object)selection.Italic) : Class605.smethod_1());
				break;
			case 40015:
			{
				DocumentPermissions.Enum50 @enum = (DocumentPermissions.Enum50)this.textControl_0.textControlCore_0.method_30(Enum83.const_321, 2, 0);
				obj = (((@enum & DocumentPermissions.Enum50.const_4) != 0) ? true : false);
				break;
			}
			case 40016:
			{
				bool flag2 = selection.Baseline < 0;
				obj = (selection.IsCommonValueSelected(Selection.Attribute.Baseline) ? ((object)flag2) : Class605.smethod_1());
				break;
			}
			case 40017:
			{
				bool flag = selection.Baseline > 0;
				obj = (selection.IsCommonValueSelected(Selection.Attribute.Baseline) ? ((object)flag) : Class605.smethod_1());
				break;
			}
			case 40018:
			case 40019:
			case 40020:
			case 40021:
			{
				int num2 = 0;
				if (this.textPart_0 == TextPart.MainText)
				{
					Class429.Struct83 struct83_ = default(Class429.Struct83);
					this.textControl_0.textControlCore_0.method_33(this.textPart_0, Enum83.const_59, 65535, ref struct83_);
					switch (attributeId)
					{
					case 40018:
						num2 = struct83_.int_3;
						break;
					case 40019:
						num2 = struct83_.int_0;
						break;
					case 40020:
						num2 = struct83_.int_1;
						break;
					case 40021:
						num2 = struct83_.int_2;
						break;
					}
				}
				obj = ((num2 != -1) ? ((object)((double)num2 / 20.0)) : Class605.smethod_1());
				break;
			}
			case 40026:
				obj = (selection.IsCommonValueSelected(Selection.Attribute.Strikeout) ? ((object)(selection.Strikeout ? 1 : 0)) : Class605.smethod_1());
				break;
			case 40027:
				if (selection.IsCommonValueSelected(ParagraphFormat.Attribute.TabPositions))
				{
					int[] tabPositions = selection.ParagraphFormat.TabPositions;
					double[] array2 = new double[tabPositions.Length];
					for (int i = 0; i < tabPositions.Length; i++)
					{
						array2[i] = (double)tabPositions[i] / 20.0;
					}
					obj = array2;
				}
				else
				{
					obj = Class605.smethod_1();
				}
				break;
			case 40028:
				obj = (selection.IsCommonValueSelected(ParagraphFormat.Attribute.Direction) ? ((object)((selection.ParagraphFormat.Direction != Direction.LeftToRight) ? 1 : 0)) : Class605.smethod_1());
				break;
			case 40030:
			{
				FontUnderlineStyle underline = selection.Underline;
				obj = (selection.IsCommonValueSelected(Selection.Attribute.Underline) ? ((object)(underline switch
				{
					FontUnderlineStyle.SingleWordsOnly => 2, 
					FontUnderlineStyle.Doubled => 3, 
					FontUnderlineStyle.Single => 1, 
					FontUnderlineStyle.None => 0, 
					_ => -1, 
				})) : Class605.smethod_1());
				break;
			}
			case 40033:
				obj = (selection.IsCommonValueSelected(Selection.Attribute.FormattingStyle) ? selection.FormattingStyle : Class605.smethod_1());
				break;
			default:
				obj = Class605.smethod_0();
				break;
			}
			this.textControl_0.textControlCore_0.method_17(this.textPart_0);
			return obj;
		}

		ITextRangeProvider ITextRangeProvider.FindAttribute(int attributeId, object val, int backward)
		{
			return null;
		}

		ITextRangeProvider ITextRangeProvider.FindText(string text, int backward, int ignoreCase)
		{
			return null;
		}

		void ITextRangeProvider.AddToSelection()
		{
			throw new InvalidOperationException();
		}

		void ITextRangeProvider.RemoveFromSelection()
		{
			throw new InvalidOperationException();
		}

		IRawElementProviderSimple[] ITextRangeProvider.GetChildren()
		{
			return null;
		}

		private Class608 method_0(ITextRangeProvider itextRangeProvider_0)
		{
			Class608 @class = itextRangeProvider_0 as Class608;
			if (@class == null || !@class.textControl_0.textControlCore_0.isHandleCreated || @class.textControl_0.textControlCore_0.IntPtr_0 != this.textControl_0.textControlCore_0.IntPtr_0)
			{
				throw new ArgumentException();
			}
			return @class;
		}

		private int method_1(TextUnit textUnit_0)
		{
			int result = 0;
			switch (textUnit_0)
			{
			case TextUnit.TextUnit_Character:
			{
				int num2 = this.textControl_0.textControlCore_0.method_29(this.textPart_0, 1136, 0, 0);
				if (this.int_0 < num2)
				{
					this.int_1 = this.int_0 + 1;
					result = this.int_0 + 1;
				}
				break;
			}
			case TextUnit.TextUnit_Word:
			{
				int[] array = new int[3] { this.int_0, 0, 0 };
				this.textControl_0.textControlCore_0.method_40(this.textPart_0, 1989, 3, array);
				this.int_0 = array[1];
				this.int_1 = array[2];
				break;
			}
			case TextUnit.TextUnit_Line:
			{
				LineCollection lineCollection = new LineCollection(this.textControl_0.textControlCore_0, this.textPart_0);
				Line item3 = lineCollection.GetItem(this.int_0);
				this.int_0 = item3.Start - 1;
				this.int_1 = item3.Start + item3.Length - 1;
				result = item3.Number;
				break;
			}
			case TextUnit.TextUnit_Paragraph:
			{
				ParagraphCollection paragraphCollection = new ParagraphCollection(this.textControl_0.textControlCore_0, this.textPart_0);
				Paragraph item2 = paragraphCollection.GetItem(this.int_0);
				this.int_0 = item2.Start - 1;
				this.int_1 = item2.Start + item2.Length - 1;
				result = item2.Number;
				break;
			}
			case TextUnit.TextUnit_Page:
				if (this.textPart_0 == TextPart.MainText)
				{
					PageCollection pageCollection = new PageCollection(this.textControl_0.textControlCore_0);
					Page item = pageCollection.GetItem(this.int_0);
					this.int_0 = item.Start - 1;
					this.int_1 = item.Start + item.Length - 1;
					result = item.Number;
				}
				break;
			case TextUnit.TextUnit_Format:
			case TextUnit.TextUnit_Document:
			{
				int num = this.textControl_0.textControlCore_0.method_29(this.textPart_0, 1136, 0, 0);
				this.int_0 = 0;
				this.int_1 = num;
				result = 1;
				break;
			}
			}
			return result;
		}
	}
}
