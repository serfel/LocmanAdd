using System;
using System.Drawing;
using System.Globalization;
using System.Resources;
using TXTextControl;

namespace ns21
{
	internal class Class406
	{
		internal enum Enum72
		{
			const_0,
			const_1,
			const_2,
			const_3,
			const_4,
			const_5
		}

		private static ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private static string[][] string_0 = new string[24][]
		{
			new string[2] { "TXITEM_FontGroup_DialogBoxLauncher", "CharacterFormatting" },
			new string[2] { "TXITEM_ParagraphGroup_DialogBoxLauncher", "ParagraphFormatting" },
			new string[2] { "TXITEM_StylesGroup_DialogBoxLauncher", "StylesFormatting" },
			new string[2] { "TXITEM_FormulaGroup_DialogBoxLauncher", "FormulaEditing" },
			new string[2] { "TXITEM_NumberFormatGroup_DialogBoxLauncher", "FormulaEditing" },
			new string[2] { "TXITEM_ObjectArrangeGroup_DialogBoxLauncher", "LayoutAndPosition" },
			new string[2] { "TXITEM_ObjectSizeGroup_DialogBoxLauncher", "SizeAndDistance" },
			new string[2] { "TXITEM_TextFrame_BordersandBackgroundGroup_DialogBoxLauncher", "FrameAndColor" },
			new string[2] { "TXITEM_Drawing_BordersandBackgroundGroup_DialogBoxLauncher", "OutlineAndFill" },
			new string[2] { "TXITEM_Barcode_ColorsAndAlignmentGroup_DialogBoxLauncher", "TypeAndColor" },
			new string[2] { "TXITEM_Chart_TypeAndAppearanceGroup_DialogBoxLauncher", "TypeAndAppearance" },
			new string[2] { "TXITEM_PageSetupGroup_DialogBoxLauncher", "MarginsAndPaper" },
			new string[2] { "TXITEM_ColumnsAndBreaksGroup_DialogBoxLauncher", "PageLayout_Columns" },
			new string[2] { "TXITEM_PageBackgroundAndBordersGroup_DialogBoxLauncher", "PageLayout_Frames" },
			new string[2] { "TXITEM_ReadOnlyExceptionsGroup_DialogBoxLauncher", "AddUsers" },
			new string[2] { "TXITEM_BordersAndBackgroundGroup_DialogBoxLauncher", "Table_FrameAndColor" },
			new string[2] { "TXITEM_TableAlignmentGroup_DialogBoxLauncher", "SizeAndFormatting" },
			new string[2] { "TXITEM_PasteText", "IDS_IDM_PASTETEXT" },
			new string[2] { "TXITEM_PastePlainText", "IDS_IDM_PASTEPLAINTEXT" },
			new string[2] { "TXITEM_PasteImage", "IDS_IDM_PASTEIMAGE" },
			new string[2] { "TXITEM_PasteTextFrame", "IDS_IDM_PASTETEXTFRAME" },
			new string[2] { "TXITEM_PasteChart", "IDS_IDM_PASTECHART" },
			new string[2] { "TXITEM_PasteBarcode", "IDS_IDM_PASTEBARCODE" },
			new string[2] { "TXITEM_PasteDrawing", "IDS_IDM_PASTEDRAWING" }
		};

		internal Class406()
		{
		}

		internal static Bitmap smethod_0(string string_1, Enum72 enum72_0, int int_0, ImageProvider.ImageSetting imageSetting_0)
		{
			double num = int_0;
			double num2 = num / 96.0;
			bool flag = false;
			int num3 = ((flag = num2 % 2.0 == 0.0) ? ((int)num2) : ((int)Math.Ceiling(num2)));
			num = num3 * 96;
			Bitmap bitmap = null;
			Size empty = Size.Empty;
			if (enum72_0 == Enum72.const_0)
			{
				empty = new Size(16, 16);
				bitmap = ImageProvider.GetBitmap(string_1, ImageProvider.ImageKind.Small_16x16, num, imageSetting_0);
			}
			else
			{
				empty = new Size(32, 32);
				bitmap = ImageProvider.GetBitmap(string_1, ImageProvider.ImageKind.Large_32x32, num, imageSetting_0);
				if (bitmap == null)
				{
					empty = new Size(76, 76);
					bitmap = ImageProvider.GetBitmap(string_1, ImageProvider.ImageKind.Large_76x76, num, imageSetting_0);
				}
			}
			if (bitmap != null && !flag)
			{
				Bitmap bitmap2 = new Bitmap((int)((double)empty.Width * num2), (int)((double)empty.Height * num2));
				Graphics graphics = Graphics.FromImage(bitmap2);
				graphics.DrawImage(bitmap, new Rectangle(0, 0, bitmap2.Width, bitmap2.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel);
				bitmap.Dispose();
				graphics.Dispose();
				return bitmap2;
			}
			return bitmap;
		}

		internal static string smethod_1(string string_1, Enum72 enum72_0, CultureInfo cultureInfo_0)
		{
			if (string_1.Length > 7)
			{
				string text = string_1.Substring(7);
				string text2 = "";
				switch (enum72_0)
				{
				case Enum72.const_2:
				{
					text2 = "LABEL_" + text;
					string text4 = ((cultureInfo_0 == null) ? Class406.resourceManager_0.GetString(text2) : Class406.resourceManager_0.GetString(text2, cultureInfo_0));
					if (string.IsNullOrEmpty(text4))
					{
						text2 = "HEADER_" + text;
						text4 = ((cultureInfo_0 == null) ? Class406.resourceManager_0.GetString(text2) : Class406.resourceManager_0.GetString(text2, cultureInfo_0));
						if (string.IsNullOrEmpty(text4))
						{
							return Class406.smethod_2(string_1, "", cultureInfo_0, 17, Class406.string_0.Length);
						}
						return text4;
					}
					return text4;
				}
				case Enum72.const_3:
				{
					text2 = "TOOLTIPTITLE_" + text;
					string text3 = ((cultureInfo_0 == null) ? Class406.resourceManager_0.GetString(text2) : Class406.resourceManager_0.GetString(text2, cultureInfo_0));
					if (string.IsNullOrEmpty(text3) && string_1.EndsWith("DialogBoxLauncher"))
					{
						return Class406.smethod_2(string_1, "TOOLTIPTITLE_", cultureInfo_0, 0, 17);
					}
					return text3;
				}
				case Enum72.const_4:
				{
					text2 = "TOOLTIP_" + text;
					string text5 = ((cultureInfo_0 == null) ? Class406.resourceManager_0.GetString(text2) : Class406.resourceManager_0.GetString(text2, cultureInfo_0));
					if (string.IsNullOrEmpty(text5) && string_1.EndsWith("DialogBoxLauncher"))
					{
						return Class406.smethod_2(string_1, "TOOLTIP_", cultureInfo_0, 0, 17);
					}
					return text5;
				}
				case Enum72.const_5:
					text2 = "KEYTIP_" + text;
					if (cultureInfo_0 != null)
					{
						return Class406.resourceManager_0.GetString(text2, cultureInfo_0);
					}
					return Class406.resourceManager_0.GetString(text2);
				}
			}
			return string.Empty;
		}

		private static string smethod_2(string string_1, string string_2, CultureInfo cultureInfo_0, int int_0, int int_1)
		{
			int num = int_0;
			string[] array;
			while (true)
			{
				if (num < int_1)
				{
					array = Class406.string_0[num];
					if (array[0] == string_1)
					{
						break;
					}
					num++;
					continue;
				}
				return string.Empty;
			}
			string name = string_2 + array[1];
			if (cultureInfo_0 != null)
			{
				return Class406.resourceManager_0.GetString(name, cultureInfo_0);
			}
			return Class406.resourceManager_0.GetString(name);
		}
	}
}
