using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using ns21;
using TXTextControl;
using TXTextControl.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class473 : BindingAdapter
	{
		internal enum GalleryItems
		{
			BulletCharacter_00B7,
			BulletCharacter_002D,
			BulletCharacter_002A,
			BulletCharacter_00A8,
			BulletCharacter_00AE,
			NumberedListFormat_ArabicNumbers,
			NumberedListFormat_CapitalLetters,
			NumberedListFormat_Letters,
			NumberedListFormat_RomanNumbers,
			NumberedListFormat_SmallRomanNumbers,
			StructuredListFormat_ArabicNumbers,
			StructuredListFormat_CapitalLetters,
			StructuredListFormat_Letters,
			StructuredListFormat_RomanNumbers,
			StructuredListFormat_SmallRomanNumbers
		}

		private Class502 class502_0;

		private GotoDialog gotoDialog_0;

		private TextControl textControl_0;

		private RibbonListView.RibbonListViewItem[] ribbonListViewItem_0 = new RibbonListView.RibbonListViewItem[0];

		private Enum57 enum57_0;

		private bool bool_0;

		private Point point_0 = Point.Empty;

		private Size size_0 = Size.Empty;

		private Point point_1 = Point.Empty;

		private Size size_1 = Size.Empty;

		private Point point_2 = Point.Empty;

		private Size size_2 = Size.Empty;

		private Point point_3 = Point.Empty;

		private Size size_3 = Size.Empty;

		private bool bool_1 = true;

		private bool bool_2 = true;

		internal bool bool_3;

		internal override Class500 RibbonGroupManager
		{
			get
			{
				return this.class502_0;
			}
			set
			{
				this.class502_0 = value as Class502;
			}
		}

		internal Class473(Control control_0)
		{
			this.enum57_0 = ((control_0 is MiniToolbar) ? Enum57.const_1 : Enum57.const_0);
		}

		private void method_0(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonSplitButton ribbonSplitButton = control_0 as RibbonSplitButton;
			ribbonSplitButton.DropDownOpening += method_151;
			RibbonItemCollection dropDownItems = ribbonSplitButton.DropDownItems;
			this.method_1(dictionary_0, dropDownItems, Enum114.const_20, RibbonFormattingTab.InternalRibbonItem.TXITEM_PasteText.ToString(), ClipboardFormat.PlainText);
			this.method_1(dictionary_0, dropDownItems, Enum114.const_21, RibbonFormattingTab.InternalRibbonItem.TXITEM_PastePlainText.ToString(), ClipboardFormat.PlainText);
			this.method_1(dictionary_0, dropDownItems, Enum114.const_22, RibbonFormattingTab.InternalRibbonItem.TXITEM_PasteImage.ToString(), ClipboardFormat.PlainText);
			this.method_1(dictionary_0, dropDownItems, Enum114.const_23, RibbonFormattingTab.InternalRibbonItem.TXITEM_PasteTextFrame.ToString(), ClipboardFormat.TXTextControlTextframe);
			this.method_1(dictionary_0, dropDownItems, Enum114.const_24, RibbonFormattingTab.InternalRibbonItem.TXITEM_PasteChart.ToString(), ClipboardFormat.Chart);
			this.method_1(dictionary_0, dropDownItems, Enum114.const_59, RibbonFormattingTab.InternalRibbonItem.TXITEM_PasteBarcode.ToString(), ClipboardFormat.Barcode);
			this.method_1(dictionary_0, dropDownItems, Enum114.const_60, RibbonFormattingTab.InternalRibbonItem.TXITEM_PasteDrawing.ToString(), ClipboardFormat.Drawing);
		}

		private void method_1(Dictionary<string, object> dictionary_0, RibbonItemCollection ribbonItemCollection_0, Enum114 enum114_0, string string_0, ClipboardFormat clipboardFormat_0)
		{
			int num = (int)(enum114_0 + 300);
			TxString txString = (TxString)num;
			string @string = base.m_rmResourceManager.GetString(txString.ToString());
			RibbonButton ribbonButton = new RibbonButton();
			ribbonButton.Name = string_0;
			ribbonButton.DisplayMode = IconTextRelation.SmallIconLabeled;
			ribbonButton.Text = @string;
			ribbonButton.Tag = (int)clipboardFormat_0;
			ribbonButton.Click += method_152;
			IRibbonItem ribbonItem = ribbonButton;
			ribbonItem.HasSmallIcon = true;
			ribbonItem.IsDefaultRibbonTabItem = true;
			dictionary_0.Add(ribbonButton.Name, ribbonButton);
			ribbonItemCollection_0.Add(ribbonButton);
		}

		private void method_2(RibbonComboBox ribbonComboBox_0)
		{
			ribbonComboBox_0.Items.Clear();
			try
			{
				ribbonComboBox_0.Items.AddRange(base.m_txTextControl.InputFormat.GetFontFamilies());
			}
            catch { }
		}

		private void method_3(RibbonComboBox ribbonComboBox_0)
		{
			ribbonComboBox_0.Items.Clear();
			try
			{
				ribbonComboBox_0.Items.AddRange(base.m_txTextControl.InputFormat.GetFontSizes());
				if (base.m_txTextControl.InputFormat.FontSize.HasValue)
				{
					ribbonComboBox_0.Text = MeasureConverter.Convert(base.m_txTextControl.InputFormat.FontSize, typeof(double), null, null).ToString();
				}
			}
			catch { }
		}

		private void method_4(Dictionary<string, object> dictionary_0, RibbonSplitButton ribbonSplitButton_0)
		{
			ribbonSplitButton_0.DropDownItems.Clear();
			FontUnderlineStyle[] underlineStyles = base.m_txTextControl.InputFormat.UnderlineStyles;
			foreach (FontUnderlineStyle fontUnderlineStyle in underlineStyles)
			{
				RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
				ribbonToggleButton.DisplayMode = IconTextRelation.SmallIconLabeled;
				ribbonToggleButton.Name = "TXITEM_Underline_" + fontUnderlineStyle;
				RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
				ribbonToggleButton2.Text = base.m_rmResourceManager.GetString(ribbonToggleButton2.Name.Substring(17));
				((IRibbonItem)ribbonToggleButton2).IsDefaultRibbonTabItem = true;
				ribbonToggleButton2.CheckedChanged += method_159;
				ribbonSplitButton_0.DropDownItems.Add(ribbonToggleButton2);
				if (dictionary_0.ContainsKey(ribbonToggleButton2.Name))
				{
					dictionary_0.Remove(ribbonToggleButton2.Name);
				}
				dictionary_0.Add(ribbonToggleButton2.Name, ribbonToggleButton2);
			}
		}

		private void method_5(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.NoIconLabeled, bool_0: false, RibbonFormattingTab.InternalRibbonItem.TXITEM_ChangeCase_Sentence.ToString(), null, this);
				ribbonButton.Click += method_160;
				RibbonButton ribbonButton2 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.NoIconLabeled, bool_0: false, RibbonFormattingTab.InternalRibbonItem.TXITEM_ChangeCase_Lower.ToString(), null, this);
				ribbonButton2.Click += method_160;
				RibbonButton ribbonButton3 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.NoIconLabeled, bool_0: false, RibbonFormattingTab.InternalRibbonItem.TXITEM_ChangeCase_Upper.ToString(), null, this);
				ribbonButton3.Click += method_160;
				RibbonButton ribbonButton4 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.NoIconLabeled, bool_0: false, RibbonFormattingTab.InternalRibbonItem.TXITEM_ChangeCase_Capitalize.ToString(), null, this);
				ribbonButton4.Click += method_160;
				RibbonButton ribbonButton5 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.NoIconLabeled, bool_0: false, RibbonFormattingTab.InternalRibbonItem.TXITEM_ChangeCase_Toggle.ToString(), null, this);
				ribbonButton5.Click += method_160;
				ribbonMenuButton.DropDownItems.AddRange(new Control[5] { ribbonButton, ribbonButton2, ribbonButton3, ribbonButton4, ribbonButton5 });
			}
		}

		private void method_6(Dictionary<string, object> dictionary_0, Control control_0, string string_0, string string_1, string string_2, string string_3, string string_4)
		{
			if (control_0 is RibbonSplitButton)
			{
				RibbonSplitButton ribbonSplitButton = (RibbonSplitButton)control_0;
				ribbonSplitButton.DropDownOpening += method_161;
				RibbonLabel ribbonLabel = new RibbonLabel();
				ribbonLabel.Text = base.m_rmResourceManager.GetString(string_0.Replace("TXITEM_", "HEADER_"));
				ribbonLabel.Name = string_0;
				RibbonLabel ribbonLabel2 = ribbonLabel;
				((IRibbonItem)ribbonLabel2).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonLabel2.Name, ribbonLabel2);
				RibbonSeperator ribbonSeperator = new RibbonSeperator();
				ribbonSeperator.Name = string_1;
				RibbonSeperator ribbonSeperator2 = ribbonSeperator;
				((IRibbonItem)ribbonSeperator2).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonSeperator2.Name, ribbonSeperator2);
				RibbonListView ribbonListView = this.method_7(dictionary_0, string_2);
				RibbonSeperator ribbonSeperator3 = new RibbonSeperator();
				ribbonSeperator3.Name = string_3;
				RibbonSeperator ribbonSeperator4 = ribbonSeperator3;
				((IRibbonItem)ribbonSeperator4).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonSeperator4.Name, ribbonSeperator4);
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, string_4, null, this);
				ribbonButton.Click += method_163;
				ribbonSplitButton.DropDownItems.AddRange(new Control[5] { ribbonLabel2, ribbonSeperator2, ribbonListView, ribbonSeperator4, ribbonButton });
			}
		}

		private RibbonListView method_7(Dictionary<string, object> dictionary_0, string string_0)
		{
			RibbonListView ribbonListView = new RibbonListView();
			((IRibbonItem)ribbonListView).IsDefaultRibbonTabItem = true;
			ribbonListView.Name = string_0;
			ribbonListView.Deselectable = false;
			ribbonListView.MinColumnCount = 4;
			string_0.Substring(0, 3);
			ribbonListView.ItemClick += method_162;
			dictionary_0.Add(ribbonListView.Name, ribbonListView);
			return ribbonListView;
		}

		private void method_8(RibbonListView ribbonListView_0, PointF pointF_0)
		{
			ribbonListView_0.RibbonListViewItems.Clear();
			Size size = Class517.smethod_48(Class519.Class532.Size_1, pointF_0);
			ribbonListView_0.RibbonListViewItems.Add(this.method_9(GalleryItems.BulletCharacter_00B7, new Bitmap(size.Width, size.Height)));
			ribbonListView_0.RibbonListViewItems.Add(this.method_9(GalleryItems.BulletCharacter_002D, new Bitmap(size.Width, size.Height)));
			ribbonListView_0.RibbonListViewItems.Add(this.method_9(GalleryItems.BulletCharacter_002A, new Bitmap(size.Width, size.Height)));
			ribbonListView_0.RibbonListViewItems.Add(this.method_9(GalleryItems.BulletCharacter_00A8, new Bitmap(size.Width, size.Height)));
			ribbonListView_0.RibbonListViewItems.Add(this.method_9(GalleryItems.BulletCharacter_00AE, new Bitmap(size.Width, size.Height)));
		}

		private RibbonListView.RibbonListViewItem method_9(GalleryItems galleryItems_0, Bitmap bitmap_0)
		{
			string[] array = galleryItems_0.ToString().Split('_');
			object obj = ((array[1][0] == '0') ? new string(Convert.ToChar(Convert.ToInt32(array[1], 16)), 1) : array[1]);
			Graphics graphics = Graphics.FromImage(bitmap_0);
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = StringAlignment.Center;
			stringFormat.LineAlignment = StringAlignment.Center;
			graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixelGridFit;
			float num = base.m_pntDPI.X / graphics.DpiX;
			graphics.DrawString((string)obj, new Font("Symbol", 18f * num), new SolidBrush(Color.Black), new Rectangle(0, 0, bitmap_0.Width, bitmap_0.Height), stringFormat);
			graphics.Dispose();
			RibbonListView.RibbonListViewItem ribbonListViewItem = new RibbonListView.RibbonListViewItem();
			ribbonListViewItem.Tag = obj;
			ribbonListViewItem.Icon = bitmap_0;
			return ribbonListViewItem;
		}

		private void method_10(RibbonListView ribbonListView_0, string string_0, PointF pointF_0)
		{
			ribbonListView_0.RibbonListViewItems.Clear();
			_ = string_0 == "StructuredList";
			string text = "TXITEM_" + string_0 + "_Gallery_";
			ribbonListView_0.RibbonListViewItems.Add(this.method_11((GalleryItems)Enum.Parse(typeof(GalleryItems), string_0 + "Format_ArabicNumbers"), text + "ArabicNumbers", pointF_0));
			ribbonListView_0.RibbonListViewItems.Add(this.method_11((GalleryItems)Enum.Parse(typeof(GalleryItems), string_0 + "Format_CapitalLetters"), text + "CapitalLetters", pointF_0));
			ribbonListView_0.RibbonListViewItems.Add(this.method_11((GalleryItems)Enum.Parse(typeof(GalleryItems), string_0 + "Format_Letters"), text + "Letters", pointF_0));
			ribbonListView_0.RibbonListViewItems.Add(this.method_11((GalleryItems)Enum.Parse(typeof(GalleryItems), string_0 + "Format_RomanNumbers"), text + "RomanNumbers", pointF_0));
			ribbonListView_0.RibbonListViewItems.Add(this.method_11((GalleryItems)Enum.Parse(typeof(GalleryItems), string_0 + "Format_SmallRomanNumbers"), text + "SmallRomanNumbers", pointF_0));
		}

		private RibbonListView.RibbonListViewItem method_11(GalleryItems galleryItems_0, string string_0, PointF pointF_0)
		{
			string[] array = galleryItems_0.ToString().Split('_');
			object tag = Enum.Parse(typeof(NumFormat), array[1]);
			RibbonListView.RibbonListViewItem ribbonListViewItem = new RibbonListView.RibbonListViewItem();
			ribbonListViewItem.String_0 = string_0;
			ribbonListViewItem.Tag = tag;
			RibbonListView.RibbonListViewItem ribbonListViewItem2 = ribbonListViewItem;
			ribbonListViewItem2.Icon = Class517.smethod_55(ribbonListViewItem2.String_0, ImageProvider.ImageKind.Large_76x76, Class517.smethod_48(Class519.Class532.Size_2, pointF_0), pointF_0);
			return ribbonListViewItem2;
		}

		private void method_12(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
			this.method_13(dictionary_0, ribbonMenuButton.DropDownItems, RibbonFormattingTab.InternalRibbonItem.TXITEM_LineSpacing_100.ToString());
			this.method_13(dictionary_0, ribbonMenuButton.DropDownItems, RibbonFormattingTab.InternalRibbonItem.TXITEM_LineSpacing_115.ToString());
			this.method_13(dictionary_0, ribbonMenuButton.DropDownItems, RibbonFormattingTab.InternalRibbonItem.TXITEM_LineSpacing_150.ToString());
			this.method_13(dictionary_0, ribbonMenuButton.DropDownItems, RibbonFormattingTab.InternalRibbonItem.TXITEM_LineSpacing_200.ToString());
			this.method_13(dictionary_0, ribbonMenuButton.DropDownItems, RibbonFormattingTab.InternalRibbonItem.TXITEM_LineSpacing_250.ToString());
			this.method_13(dictionary_0, ribbonMenuButton.DropDownItems, RibbonFormattingTab.InternalRibbonItem.TXITEM_LineSpacing_300.ToString());
			ribbonMenuButton.DropDownOpening += method_164;
		}

		private void method_13(Dictionary<string, object> dictionary_0, RibbonItemCollection ribbonItemCollection_0, string string_0)
		{
			RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
			ribbonToggleButton.DisplayMode = IconTextRelation.NoIconLabeled;
			RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
			int num = Convert.ToInt32(string_0.Substring(string_0.LastIndexOf('_') + 1));
			ribbonToggleButton2.Text = ((double)num / 100.0).ToString((num % 10 == 0) ? "F1" : "F2");
			ribbonToggleButton2.Name = string_0;
			ribbonItemCollection_0.Add(ribbonToggleButton2);
			((IRibbonItem)ribbonToggleButton2).IsDefaultRibbonTabItem = true;
			dictionary_0.Add(ribbonToggleButton2.Name, ribbonToggleButton2);
			ribbonToggleButton2.Click += method_165;
		}

		private void method_14(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFormattingTab.InternalRibbonItem.TXITEM_LeftFrameLine.ToString(), "Click", this);
				RibbonToggleButton ribbonToggleButton2 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFormattingTab.InternalRibbonItem.TXITEM_TopFrameLine.ToString(), "Click", this);
				RibbonToggleButton ribbonToggleButton3 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFormattingTab.InternalRibbonItem.TXITEM_RightFrameLine.ToString(), "Click", this);
				RibbonToggleButton ribbonToggleButton4 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFormattingTab.InternalRibbonItem.TXITEM_BottomFrameLine.ToString(), "Click", this);
				RibbonSeperator ribbonSeperator = new RibbonSeperator();
				ribbonSeperator.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_BordersSeperator1.ToString();
				RibbonSeperator ribbonSeperator2 = ribbonSeperator;
				((IRibbonItem)ribbonSeperator2).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonSeperator2.Name, ribbonSeperator2);
				RibbonToggleButton ribbonToggleButton5 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFormattingTab.InternalRibbonItem.TXITEM_BoxFrame.ToString(), "Click", this);
				RibbonToggleButton ribbonToggleButton6 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFormattingTab.InternalRibbonItem.TXITEM_AllFrameLines.ToString(), "Click", this);
				RibbonSeperator ribbonSeperator3 = new RibbonSeperator();
				ribbonSeperator3.Name = RibbonFormattingTab.InternalRibbonItem.TXITEM_BordersSeperator2.ToString();
				RibbonSeperator ribbonSeperator4 = ribbonSeperator3;
				((IRibbonItem)ribbonSeperator4).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonSeperator4.Name, ribbonSeperator4);
				RibbonToggleButton ribbonToggleButton7 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFormattingTab.InternalRibbonItem.TXITEM_InnerHorizontalFrameLines.ToString(), "Click", this);
				RibbonToggleButton ribbonToggleButton8 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFormattingTab.InternalRibbonItem.TXITEM_InnerVerticalFrameLines.ToString(), "Click", this);
				ribbonToggleButton8.Visible = false;
				ribbonToggleButton8.IsAddToQuickAccessToolbarEnabled = false;
				ribbonMenuButton.DropDownItems.AddRange(new Control[10] { ribbonToggleButton, ribbonToggleButton2, ribbonToggleButton3, ribbonToggleButton4, ribbonSeperator2, ribbonToggleButton5, ribbonToggleButton6, ribbonSeperator4, ribbonToggleButton7, ribbonToggleButton8 });
			}
		}

		private void method_15(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonSplitButton)
			{
				RibbonSplitButton ribbonSplitButton = (RibbonSplitButton)control_0;
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFormattingTab.InternalRibbonItem.TXITEM_Find_Sidebars_Vertical.ToString(), "null", this);
				ribbonToggleButton.CheckedChanged += method_169;
				RibbonToggleButton ribbonToggleButton2 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFormattingTab.InternalRibbonItem.TXITEM_Find_Sidebars_Horizontal.ToString(), null, this);
				ribbonToggleButton2.CheckedChanged += method_169;
				ribbonSplitButton.DropDownItems.AddRange(new Control[2] { ribbonToggleButton, ribbonToggleButton2 });
			}
		}

		private void method_16(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonSplitButton)
			{
				RibbonSplitButton ribbonSplitButton = (RibbonSplitButton)control_0;
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFormattingTab.InternalRibbonItem.TXITEM_Replace_Sidebars_Vertical.ToString(), "null", this);
				ribbonToggleButton.CheckedChanged += method_171;
				RibbonToggleButton ribbonToggleButton2 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFormattingTab.InternalRibbonItem.TXITEM_Replace_Sidebars_Horizontal.ToString(), null, this);
				ribbonToggleButton2.CheckedChanged += method_171;
				ribbonSplitButton.DropDownItems.AddRange(new Control[2] { ribbonToggleButton, ribbonToggleButton2 });
			}
		}

		private void method_17(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonSplitButton)
			{
				RibbonSplitButton ribbonSplitButton = (RibbonSplitButton)control_0;
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFormattingTab.InternalRibbonItem.TXITEM_Goto_Sidebars_Vertical.ToString(), "null", this);
				ribbonToggleButton.CheckedChanged += method_173;
				RibbonToggleButton ribbonToggleButton2 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonFormattingTab.InternalRibbonItem.TXITEM_Goto_Sidebars_Horizontal.ToString(), null, this);
				ribbonToggleButton2.CheckedChanged += method_173;
				ribbonSplitButton.DropDownItems.AddRange(new Control[2] { ribbonToggleButton, ribbonToggleButton2 });
			}
		}

		internal override void AwareOfDPI(PointF dpi)
		{
			base.AwareOfDPI(dpi);
			RibbonComboBox ribbonComboBox = this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_FontFamily.ToString()] as RibbonComboBox;
			ribbonComboBox.Size = new Size(Class517.smethod_45(Class519.Class532.Int32_0, dpi.X), ribbonComboBox.Size.Height);
			RibbonComboBox ribbonComboBox2 = this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_FontSize.ToString()] as RibbonComboBox;
			ribbonComboBox2.Size = new Size(Class517.smethod_45(Class519.Class532.Int32_1, dpi.X), ribbonComboBox2.Size.Height);
			base.SetColorGalleryItems(this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_TextBackColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
			base.SetColorGalleryItems(this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_TextColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
			this.method_8(this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_BulletedList_Gallery.ToString()] as RibbonListView, dpi);
			this.method_10(this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_NumberedList_Gallery.ToString()] as RibbonListView, "NumberedList", dpi);
			this.method_10(this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_StructuredList_Gallery.ToString()] as RibbonListView, "StructuredList", dpi);
			base.SetColorGalleryItems(this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_BackColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
			base.SetColorGalleryItems(this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_FrameLineColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
			base.SetLineWidthItemsImages(this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_FrameLineWidth.ToString()] as RibbonMenuButton, base.m_pntDPI);
			RibbonFormattingTab.InternalRibbonItem[] array = new RibbonFormattingTab.InternalRibbonItem[6]
			{
				RibbonFormattingTab.InternalRibbonItem.TXITEM_Find_Dialog,
				RibbonFormattingTab.InternalRibbonItem.TXITEM_Find_Sidebars,
				RibbonFormattingTab.InternalRibbonItem.TXITEM_Goto_Dialog,
				RibbonFormattingTab.InternalRibbonItem.TXITEM_Goto_Sidebars,
				RibbonFormattingTab.InternalRibbonItem.TXITEM_Replace_Dialog,
				RibbonFormattingTab.InternalRibbonItem.TXITEM_Replace_Sidebars
			};
			RibbonFormattingTab.InternalRibbonItem[] array2 = array;
			foreach (RibbonFormattingTab.InternalRibbonItem internalRibbonItem in array2)
			{
				RibbonButton ribbonButton = this.class502_0.TXITEM_EditingGroup_Items[internalRibbonItem.ToString()] as RibbonButton;
				if (ribbonButton.SmallIcon == null)
				{
					ribbonButton.SmallIcon = Class517.smethod_53(internalRibbonItem.ToString(), ImageProvider.ImageKind.Small_16x16, dpi);
				}
			}
		}

		internal override void AwareOfDPI_MiniToolbar(PointF dpi)
		{
			if (base.m_pntDPI.X != dpi.X || base.m_pntDPI.Y != dpi.Y)
			{
				base.AwareOfDPI_MiniToolbar(dpi);
				RibbonComboBox ribbonComboBox = this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_FontFamily.ToString()] as RibbonComboBox;
				ribbonComboBox.Size = new Size(Class517.smethod_45(Class519.Class532.Int32_0, dpi.X), ribbonComboBox.Size.Height);
				RibbonComboBox ribbonComboBox2 = this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_FontSize.ToString()] as RibbonComboBox;
				ribbonComboBox2.Size = new Size(Class517.smethod_45(Class519.Class532.Int32_1, dpi.X), ribbonComboBox2.Size.Height);
				base.SetColorGalleryItems(this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_TextBackColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
				base.SetColorGalleryItems(this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_TextColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
				this.method_36();
				this.method_37();
				this.method_8(this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_BulletedList_Gallery.ToString()] as RibbonListView, dpi);
				this.method_10(this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_NumberedList_Gallery.ToString()] as RibbonListView, "NumberedList", dpi);
				this.method_10(this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_StructuredList_Gallery.ToString()] as RibbonListView, "StructuredList", dpi);
			}
			this.method_20(dpi);
			this.method_18();
		}

		internal override void SetRibbonItemAppearance(Dictionary<string, object> groupItemsDictionary, Control ribbonItem, string eventName, bool hasImage)
		{
			switch (ribbonItem.Name)
			{
			case "TXITEM_Bold":
			case "TXITEM_Italic":
			case "TXITEM_Underline":
				(ribbonItem as RibbonButton).Boolean_0 = true;
				hasImage = false;
				break;
			}
			base.SetBasicRibbonItemAppearance(groupItemsDictionary, ribbonItem, hasImage);
			switch (ribbonItem.Name)
			{
			case "TXITEM_Paste":
				this.method_0(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_FontFamily":
			{
				RibbonComboBox ribbonComboBox = ribbonItem as RibbonComboBox;
				((IRibbonItem)ribbonComboBox).IsDefaultRibbonTabItem = true;
				ribbonComboBox.KeyDown += method_153;
				ribbonComboBox.SelectionChangeCommitted += method_154;
				ribbonComboBox.LostFocus += method_155;
				break;
			}
			case "TXITEM_FontSize":
			{
				RibbonComboBox ribbonComboBox2 = ribbonItem as RibbonComboBox;
				((IRibbonItem)ribbonComboBox2).IsDefaultRibbonTabItem = true;
				ribbonComboBox2.KeyDown += method_156;
				ribbonComboBox2.SelectionChangeCommitted += method_157;
				ribbonComboBox2.LostFocus += method_158;
				break;
			}
			case "TXITEM_ChangeCase":
				this.method_5(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_TextBackColor":
				base.Set_TXITEM_Color_DropDown(groupItemsDictionary, ribbonItem, RibbonFormattingTab.InternalRibbonItem.TXITEM_TextBackColor_Transparent.ToString(), RibbonFormattingTab.InternalRibbonItem.TXITEM_TextBackColorSeperator1.ToString(), RibbonFormattingTab.InternalRibbonItem.TXITEM_TextBackColor_Gallery.ToString(), RibbonFormattingTab.InternalRibbonItem.TXITEM_TextBackColorSeperator2.ToString(), RibbonFormattingTab.InternalRibbonItem.TXITEM_TextBackColor_MoreColors.ToString());
				break;
			case "TXITEM_TextColor":
				base.Set_TXITEM_Color_DropDown(groupItemsDictionary, ribbonItem, RibbonFormattingTab.InternalRibbonItem.TXITEM_TextColor_Automatic.ToString(), RibbonFormattingTab.InternalRibbonItem.TXITEM_TextColorSeperator1.ToString(), RibbonFormattingTab.InternalRibbonItem.TXITEM_TextColor_Gallery.ToString(), RibbonFormattingTab.InternalRibbonItem.TXITEM_TextColorSeperator2.ToString(), RibbonFormattingTab.InternalRibbonItem.TXITEM_TextColor_MoreColors.ToString());
				break;
			case "TXITEM_BulletedList":
				this.method_6(groupItemsDictionary, ribbonItem, RibbonFormattingTab.InternalRibbonItem.TXITEM_BulletedList_Characters.ToString(), RibbonFormattingTab.InternalRibbonItem.TXITEM_BulletedListSeperator1.ToString(), RibbonFormattingTab.InternalRibbonItem.TXITEM_BulletedList_Gallery.ToString(), RibbonFormattingTab.InternalRibbonItem.TXITEM_BulletedListSeperator2.ToString(), RibbonFormattingTab.InternalRibbonItem.TXITEM_BulletedList_Format.ToString());
				break;
			case "TXITEM_NumberedList":
				this.method_6(groupItemsDictionary, ribbonItem, RibbonFormattingTab.InternalRibbonItem.TXITEM_NumberedList_Numbers.ToString(), RibbonFormattingTab.InternalRibbonItem.TXITEM_NumberedListSeperator1.ToString(), RibbonFormattingTab.InternalRibbonItem.TXITEM_NumberedList_Gallery.ToString(), RibbonFormattingTab.InternalRibbonItem.TXITEM_NumberedListSeperator2.ToString(), RibbonFormattingTab.InternalRibbonItem.TXITEM_NumberedList_Format.ToString());
				break;
			case "TXITEM_StructuredList":
				this.method_6(groupItemsDictionary, ribbonItem, RibbonFormattingTab.InternalRibbonItem.TXITEM_StructuredList_Numbers.ToString(), RibbonFormattingTab.InternalRibbonItem.TXITEM_StructuredListSeperator1.ToString(), RibbonFormattingTab.InternalRibbonItem.TXITEM_StructuredList_Gallery.ToString(), RibbonFormattingTab.InternalRibbonItem.TXITEM_StructuredListSeperator2.ToString(), RibbonFormattingTab.InternalRibbonItem.TXITEM_StructuredList_Format.ToString());
				break;
			case "TXITEM_LineSpacing":
				this.method_12(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_Borders":
				this.method_14(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_BackColor":
				base.Set_TXITEM_Color_DropDown(groupItemsDictionary, ribbonItem, RibbonFormattingTab.InternalRibbonItem.TXITEM_BackColor_Transparent.ToString(), RibbonFormattingTab.InternalRibbonItem.TXITEM_BackColorSeperator1.ToString(), RibbonFormattingTab.InternalRibbonItem.TXITEM_BackColor_Gallery.ToString(), RibbonFormattingTab.InternalRibbonItem.TXITEM_BackColorSeperator2.ToString(), RibbonFormattingTab.InternalRibbonItem.TXITEM_BackColor_MoreColors.ToString());
				break;
			case "TXITEM_FrameLineColor":
				base.Set_TXITEM_Color_DropDown(groupItemsDictionary, ribbonItem, RibbonFormattingTab.InternalRibbonItem.TXITEM_FrameLineColor_Automatic.ToString(), RibbonFormattingTab.InternalRibbonItem.TXITEM_FrameLineColorSeperator1.ToString(), RibbonFormattingTab.InternalRibbonItem.TXITEM_FrameLineColor_Gallery.ToString(), RibbonFormattingTab.InternalRibbonItem.TXITEM_FrameLineColorSeperator2.ToString(), RibbonFormattingTab.InternalRibbonItem.TXITEM_FrameLineColor_MoreColors.ToString());
				break;
			case "TXITEM_FrameLineWidth":
				base.Set_TXITEM_LineWidth_DropDown(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_StyleName":
				if (this.class502_0.Control_0 is TextMiniToolbar)
				{
					this.bool_0 = false;
					RibbonListView ribbonListView = new RibbonListView();
					ribbonListView.Name = TextMiniToolbar.InternalRibbonItem.TXITEM_StyleNameGallery.ToString();
					ribbonListView.BackColor = Color.White;
					ribbonListView.MinColumnCount = 1;
					ribbonListView.MaxVisibleRows = 10;
					ribbonListView.CellPadding = Class519.Class532.Padding_3;
					ribbonListView.ShowBorder = false;
					ribbonListView.Deselectable = false;
					ribbonListView.ShowItemsInDropDown = false;
					ribbonListView.ScrollButtonsVisible = true;
					ribbonListView.HideSelectedItems = false;
					RibbonListView ribbonListView2 = ribbonListView;
					ribbonListView2.ItemClick -= method_167;
					RibbonMenuButton ribbonMenuButton = ribbonItem as RibbonMenuButton;
					ribbonMenuButton.DropDownOpening += method_176;
					groupItemsDictionary.Add(ribbonListView2.Name, ribbonListView2);
					ribbonMenuButton.DropDownItems.Add(ribbonListView2);
				}
				else
				{
					(ribbonItem as RibbonListView).ItemClick += method_167;
				}
				break;
			case "TXITEM_Find_Sidebars":
				this.method_15(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_Replace_Sidebars":
				this.method_16(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_Goto_Sidebars":
				this.method_17(groupItemsDictionary, ribbonItem);
				break;
			}
			if (eventName != null)
			{
				Class517.smethod_23(ribbonItem, eventName, ribbonItem.Name + "_Handler", this);
			}
		}

		internal override void OnDisconnectingTextControl()
		{
			base.m_txTextControl.InputFormat.FontFamilyChanged -= method_212;
			base.m_txTextControl.InputFormat.FontSizeChanged -= method_213;
			base.m_txTextControl.InputFormat.BoldChanged -= method_214;
			base.m_txTextControl.InputFormat.ItalicChanged -= method_215;
			base.m_txTextControl.InputFormat.UnderlineChanged -= method_216;
			base.m_txTextControl.InputFormat.UnderlineStyleChanged -= method_217;
			base.m_txTextControl.InputFormat.StrikeoutChanged -= method_218;
			base.m_txTextControl.InputFormat.SubscriptChanged -= method_219;
			base.m_txTextControl.InputFormat.SuperscriptChanged -= method_220;
			base.m_txTextControl.InputFormat.TextBackColorChanged -= method_244;
			base.m_txTextControl.InputFormat.TextColorChanged -= method_243;
			base.m_txTextControl.InputFormat.BulletedListChanged -= method_221;
			base.m_txTextControl.InputFormat.NumberedListChanged -= method_222;
			base.m_txTextControl.InputFormat.StructuredListChanged -= method_223;
			base.m_txTextControl.InputFormat.LeftToRightChanged -= method_224;
			base.m_txTextControl.InputFormat.RightToLeftChanged -= method_225;
			base.m_txTextControl.InputFormat.LeftAlignedChanged -= method_226;
			base.m_txTextControl.InputFormat.CenteredChanged -= method_227;
			base.m_txTextControl.InputFormat.RightAlignedChanged -= method_228;
			base.m_txTextControl.InputFormat.JustifiedChanged -= method_229;
			base.m_txTextControl.InputFormat.LeftFrameLineChanged -= method_230;
			base.m_txTextControl.InputFormat.TopFrameLineChanged -= method_231;
			base.m_txTextControl.InputFormat.RightFrameLineChanged -= method_232;
			base.m_txTextControl.InputFormat.BottomFrameLineChanged -= method_233;
			base.m_txTextControl.InputFormat.BoxFrameChanged -= method_234;
			base.m_txTextControl.InputFormat.AllFrameLinesChanged -= method_235;
			base.m_txTextControl.InputFormat.InnerHorizontalFrameLinesChanged -= method_236;
			base.m_txTextControl.InputFormat.InnerVerticalFrameLinesChanged -= method_237;
			base.m_txTextControl.InputFormat.FrameFillColorChanged -= method_239;
			base.m_txTextControl.InputFormat.FrameLineColorChanged -= method_240;
			base.m_txTextControl.InputFormat.FrameLineWidthChanged -= method_238;
			base.m_txTextControl.InputFormat.StyleNamesChanged -= method_241;
			base.m_txTextControl.InputFormat.StyleNameChanged -= method_242;
		}

		internal override void OnTextControlConnected()
		{
			RibbonComboBox ribbonComboBox_ = this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_FontFamily.ToString()] as RibbonComboBox;
			this.method_2(ribbonComboBox_);
			base.m_txTextControl.InputFormat.FontFamilyChanged += method_212;
			RibbonComboBox ribbonComboBox_2 = this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_FontSize.ToString()] as RibbonComboBox;
			this.method_3(ribbonComboBox_2);
			base.m_txTextControl.InputFormat.FontSizeChanged += method_213;
			base.m_txTextControl.InputFormat.BoldChanged += method_214;
			base.m_txTextControl.InputFormat.ItalicChanged += method_215;
			base.m_txTextControl.InputFormat.StrikeoutChanged += method_218;
			base.m_txTextControl.InputFormat.SubscriptChanged += method_219;
			base.m_txTextControl.InputFormat.SuperscriptChanged += method_220;
			base.m_txTextControl.InputFormat.LeftToRightChanged += method_224;
			base.m_txTextControl.InputFormat.RightToLeftChanged += method_225;
			base.m_txTextControl.InputFormat.BulletedListChanged += method_221;
			base.m_txTextControl.InputFormat.NumberedListChanged += method_222;
			base.m_txTextControl.InputFormat.StructuredListChanged += method_223;
			base.m_txTextControl.InputFormat.FrameLineWidthChanged += method_238;
			base.m_txTextControl.InputFormat.LeftAlignedChanged += method_226;
			base.m_txTextControl.InputFormat.CenteredChanged += method_227;
			base.m_txTextControl.InputFormat.RightAlignedChanged += method_228;
			base.m_txTextControl.InputFormat.JustifiedChanged += method_229;
			RibbonSplitButton ribbonSplitButton_ = this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Underline.ToString()] as RibbonSplitButton;
			this.method_4(this.class502_0.TXITEM_FontGroup_Items, ribbonSplitButton_);
			base.m_txTextControl.InputFormat.UnderlineChanged += method_216;
			base.m_txTextControl.InputFormat.UnderlineStyleChanged += method_217;
			base.m_txTextControl.InputFormat.LeftFrameLineChanged += method_230;
			base.m_txTextControl.InputFormat.TopFrameLineChanged += method_231;
			base.m_txTextControl.InputFormat.RightFrameLineChanged += method_232;
			base.m_txTextControl.InputFormat.BottomFrameLineChanged += method_233;
			base.m_txTextControl.InputFormat.BoxFrameChanged += method_234;
			base.m_txTextControl.InputFormat.AllFrameLinesChanged += method_235;
			base.m_txTextControl.InputFormat.InnerHorizontalFrameLinesChanged += method_236;
			base.m_txTextControl.InputFormat.InnerVerticalFrameLinesChanged += method_237;
			base.m_txTextControl.InputFormat.FrameFillColorChanged += method_239;
			base.m_txTextControl.InputFormat.FrameLineColorChanged += method_240;
			base.m_txTextControl.InputFormat.TextColorChanged += method_243;
			base.m_txTextControl.InputFormat.TextBackColorChanged += method_244;
			base.m_txTextControl.InputFormat.StyleNamesChanged += method_241;
			base.m_txTextControl.InputFormat.StyleNameChanged += method_242;
		}

		private void method_18()
		{
			RibbonListView ribbonListView = this.class502_0.TXITEM_StylesGroup_Items[TextMiniToolbar.InternalRibbonItem.TXITEM_StyleNameGallery.ToString()] as RibbonListView;
			if (ribbonListView != null)
			{
				ribbonListView.SelectedItems = this.method_64(base.m_txTextControl.InputFormat.StyleName, ribbonListView);
				if (ribbonListView.SelectedItems.Length > 0)
				{
					this.method_19(ribbonListView, ribbonListView.SelectedItems[0]);
					ribbonListView.HideSelectedItems = false;
				}
				else
				{
					ribbonListView.HideSelectedItems = true;
				}
			}
		}

		private void method_19(RibbonListView ribbonListView_0, RibbonListView.RibbonListViewItem ribbonListViewItem_1)
		{
			if (ribbonListViewItem_1.Int32_1 > ribbonListView_0.MaxVisibleRows)
			{
				int number = ribbonListView_0.RibbonListViewItems.Count - ribbonListView_0.MaxVisibleRows.Value;
				if (ribbonListViewItem_1.Int32_1 > ribbonListView_0.RibbonListViewItems.Count - ribbonListView_0.MaxVisibleRows)
				{
					ribbonListView_0.ScrollTo(ribbonListView_0.RibbonListViewItems[number]);
				}
				else
				{
					ribbonListView_0.ScrollTo(ribbonListViewItem_1);
				}
			}
			else
			{
				ribbonListView_0.ScrollTo(ribbonListView_0.RibbonListViewItems[0]);
			}
		}

		private void method_20(PointF pointF_0)
		{
			if (!pointF_0.IsEmpty)
			{
				RibbonListView ribbonListView = this.class502_0.TXITEM_StylesGroup_Items[TextMiniToolbar.InternalRibbonItem.TXITEM_StyleNameGallery.ToString()] as RibbonListView;
				if (ribbonListView != null)
				{
					this.ribbonListViewItem_0 = this.method_63(Class517.smethod_48(Class519.Class532.Size_0, pointF_0), base.m_txTextControl.InputFormat.StyleNames);
					ribbonListView.ItemsSource = ((this.ribbonListViewItem_0.Length > 0) ? this.ribbonListViewItem_0 : new RibbonListView.RibbonListViewItem[1] { ribbonListView.RibbonListViewItems[0] });
					ribbonListView.MaxVisibleRows = Math.Min(10, ribbonListView.ItemsSource.Length);
					ribbonListView.Width = Class517.smethod_45(Class519.Class532.Size_0.Width, pointF_0.X);
				}
			}
		}

		internal void method_21()
		{
			RibbonComboBox ribbonComboBox_ = this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_FontFamily.ToString()] as RibbonComboBox;
			this.method_2(ribbonComboBox_);
			RibbonComboBox ribbonComboBox_2 = this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_FontSize.ToString()] as RibbonComboBox;
			this.method_3(ribbonComboBox_2);
			RibbonSplitButton ribbonSplitButton_ = this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Underline.ToString()] as RibbonSplitButton;
			this.method_4(this.class502_0.TXITEM_FontGroup_Items, ribbonSplitButton_);
			this.class502_0.method_6();
		}

		internal override void UpdateRibbonTab(params object[] args)
		{
			this.method_23();
			this.method_24();
			this.method_25();
			this.method_26();
		}

		internal void method_22()
		{
			this.method_27();
			this.method_28();
			this.method_38();
			this.method_39();
			this.method_29();
			this.method_30();
			this.method_40();
			this.method_31();
			this.method_32();
			this.method_36();
			this.method_37();
			this.method_44();
			this.method_45();
			this.method_46();
			this.method_47();
		}

		private void method_23()
		{
			RibbonGroup ribbonGroup_ = this.class502_0.TXITEM_ClipboardGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_ClipboardGroup.ToString()] as RibbonGroup;
			if (this.class502_0.method_0(ribbonGroup_))
			{
				RibbonSplitButton ribbonSplitButton = this.class502_0.TXITEM_ClipboardGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Paste.ToString()] as RibbonSplitButton;
				if (this.class502_0.method_2(ribbonSplitButton))
				{
					ribbonSplitButton.Enabled = base.m_txTextControl.CanPaste;
				}
				RibbonButton ribbonButton = this.class502_0.TXITEM_ClipboardGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Cut.ToString()] as RibbonButton;
				if (this.class502_0.method_2(ribbonButton))
				{
					ribbonButton.Enabled = base.m_txTextControl.CanCopy && base.m_txTextControl.CanEdit;
				}
				RibbonButton ribbonButton2 = this.class502_0.TXITEM_ClipboardGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Copy.ToString()] as RibbonButton;
				if (this.class502_0.method_2(ribbonButton2))
				{
					ribbonButton2.Enabled = base.m_txTextControl.CanCopy;
				}
			}
		}

		private void method_24()
		{
			RibbonGroup ribbonGroup_ = this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_FontGroup.ToString()] as RibbonGroup;
			if (this.class502_0.method_0(ribbonGroup_))
			{
				this.method_27();
				this.method_28();
				this.method_29();
				this.method_30();
				this.method_31();
				this.method_32();
				this.method_33();
				this.method_34();
				this.method_35();
				this.method_36();
				this.method_37();
			}
		}

		private void method_25()
		{
			RibbonGroup ribbonGroup_ = this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_ParagraphGroup.ToString()] as RibbonGroup;
			if (this.class502_0.method_0(ribbonGroup_))
			{
				this.method_38();
				this.method_39();
				this.method_40();
				this.method_41();
				this.method_42();
				this.method_43();
				this.method_44();
				this.method_45();
				this.method_46();
				this.method_47();
				this.method_48();
				this.method_57();
				this.method_58();
			}
		}

		private void method_26()
		{
			RibbonGroup ribbonGroup_ = this.class502_0.TXITEM_StylesGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_StylesGroup.ToString()] as RibbonGroup;
			if (this.class502_0.method_0(ribbonGroup_))
			{
				this.method_60();
				this.method_61();
			}
		}

		private void method_27()
		{
			RibbonGroup object_ = this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_FontGroup.ToString()] as RibbonGroup;
			if (this.class502_0.method_2(object_))
			{
				RibbonComboBox ribbonComboBox = this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_FontFamily.ToString()] as RibbonComboBox;
				if (base.m_txTextControl.InputFormat.FontFamily != null)
				{
					ribbonComboBox.Text = base.m_txTextControl.InputFormat.FontFamily;
				}
				else
				{
					ribbonComboBox.Text = "";
				}
			}
		}

		private void method_28()
		{
			RibbonGroup object_ = this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_FontGroup.ToString()] as RibbonGroup;
			if (this.class502_0.method_2(object_))
			{
				RibbonComboBox ribbonComboBox = this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_FontSize.ToString()] as RibbonComboBox;
				if (base.m_txTextControl.InputFormat.FontSize.HasValue)
				{
					ribbonComboBox.Text = MeasureConverter.Convert(base.m_txTextControl.InputFormat.FontSize, typeof(double), null, null).ToString();
				}
				else
				{
					ribbonComboBox.Text = "";
				}
			}
		}

		private void method_29()
		{
			RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Bold.ToString()] as RibbonToggleButton;
			if (this.class502_0.method_2(ribbonToggleButton))
			{
				bool? bold = base.m_txTextControl.InputFormat.Bold;
				ribbonToggleButton.Checked = bold.HasValue && bold.Value;
			}
		}

		private void method_30()
		{
			RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Italic.ToString()] as RibbonToggleButton;
			if (this.class502_0.method_2(ribbonToggleButton))
			{
				bool? italic = base.m_txTextControl.InputFormat.Italic;
				ribbonToggleButton.Checked = italic.HasValue && italic.Value;
			}
		}

		private void method_31()
		{
			RibbonSplitButton ribbonSplitButton = this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Underline.ToString()] as RibbonSplitButton;
			if (this.class502_0.method_2(ribbonSplitButton))
			{
				bool? underline = base.m_txTextControl.InputFormat.Underline;
				ribbonSplitButton.Checked = underline.HasValue && underline.Value;
			}
		}

		private void method_32()
		{
			RibbonSplitButton ribbonSplitButton = this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Underline.ToString()] as RibbonSplitButton;
			if (!this.class502_0.method_3(ribbonSplitButton))
			{
				return;
			}
			string text = "TXITEM_Underline_" + base.m_txTextControl.InputFormat.UnderlineStyle;
			foreach (Control dropDownItem in ribbonSplitButton.DropDownItems)
			{
				IRibbonItem ribbonItem = dropDownItem as IRibbonItem;
				if (ribbonItem.IsDefaultRibbonTabItem)
				{
					RibbonToggleButton ribbonToggleButton = ribbonItem as RibbonToggleButton;
					ribbonToggleButton.Checked = ribbonToggleButton.Name == text;
				}
			}
		}

		private void method_33()
		{
			RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Strikeout.ToString()] as RibbonToggleButton;
			if (this.class502_0.method_2(ribbonToggleButton))
			{
				bool? strikeout = base.m_txTextControl.InputFormat.Strikeout;
				ribbonToggleButton.Checked = strikeout.HasValue && strikeout.Value;
			}
		}

		private void method_34()
		{
			RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Subscript.ToString()] as RibbonToggleButton;
			if (this.class502_0.method_2(ribbonToggleButton))
			{
				bool? subscript = base.m_txTextControl.InputFormat.Subscript;
				ribbonToggleButton.Checked = subscript.HasValue && subscript.Value;
			}
		}

		private void method_35()
		{
			RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Superscript.ToString()] as RibbonToggleButton;
			if (this.class502_0.method_2(ribbonToggleButton))
			{
				bool? superscript = base.m_txTextControl.InputFormat.Superscript;
				ribbonToggleButton.Checked = superscript.HasValue && superscript.Value;
			}
		}

		private void method_36()
		{
			RibbonMenuButton ribbonMenuButton = this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_TextBackColor.ToString()] as RibbonMenuButton;
			if (this.class502_0.method_2(ribbonMenuButton))
			{
				Class517.smethod_59(ribbonMenuButton, base.m_txTextControl.InputFormat.TextBackColor, bool_0: false, base.m_pntDPI);
			}
			RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_TextBackColor_Transparent.ToString()] as RibbonToggleButton;
			if (this.class502_0.method_2(ribbonToggleButton))
			{
				ribbonToggleButton.Checked = base.m_txTextControl.InputFormat.TextBackColor.HasValue && base.m_txTextControl.InputFormat.TextBackColor.Value.IsNamedColor && base.m_txTextControl.InputFormat.TextBackColor.Value.Name == Color.Transparent.Name;
			}
		}

		private void method_37()
		{
			RibbonMenuButton ribbonMenuButton = this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_TextColor.ToString()] as RibbonMenuButton;
			if (this.class502_0.method_2(ribbonMenuButton))
			{
				Class517.smethod_59(ribbonMenuButton, base.m_txTextControl.InputFormat.TextColor, bool_0: false, base.m_pntDPI);
			}
			RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_FontGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_TextColor_Automatic.ToString()] as RibbonToggleButton;
			if (this.class502_0.method_2(ribbonToggleButton))
			{
				ribbonToggleButton.Checked = base.m_txTextControl.InputFormat.TextColor.HasValue && base.m_txTextControl.InputFormat.TextColor.Value.IsNamedColor && base.m_txTextControl.InputFormat.TextColor.Value.Name == SystemColors.WindowText.Name;
			}
		}

		private void method_38()
		{
			RibbonSplitButton ribbonSplitButton = this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_BulletedList.ToString()] as RibbonSplitButton;
			if (this.class502_0.method_2(ribbonSplitButton))
			{
				bool? bulletedList = base.m_txTextControl.InputFormat.BulletedList;
				ribbonSplitButton.Checked = bulletedList.HasValue && bulletedList.Value;
			}
		}

		private void method_39()
		{
			RibbonSplitButton ribbonSplitButton = this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_NumberedList.ToString()] as RibbonSplitButton;
			if (this.class502_0.method_2(ribbonSplitButton))
			{
				bool? numberedList = base.m_txTextControl.InputFormat.NumberedList;
				ribbonSplitButton.Checked = numberedList.HasValue && numberedList.Value;
			}
		}

		private void method_40()
		{
			RibbonSplitButton ribbonSplitButton = this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_StructuredList.ToString()] as RibbonSplitButton;
			if (this.class502_0.method_2(ribbonSplitButton))
			{
				bool? structuredList = base.m_txTextControl.InputFormat.StructuredList;
				ribbonSplitButton.Checked = structuredList.HasValue && structuredList.Value;
			}
		}

		private void method_41()
		{
			RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_LeftToRight.ToString()] as RibbonToggleButton;
			if (this.class502_0.method_2(ribbonToggleButton))
			{
				bool? leftToRight = base.m_txTextControl.InputFormat.LeftToRight;
				ribbonToggleButton.Checked = leftToRight.HasValue && leftToRight.Value;
			}
		}

		private void method_42()
		{
			RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_RightToLeft.ToString()] as RibbonToggleButton;
			if (this.class502_0.method_2(ribbonToggleButton))
			{
				bool? rightToLeft = base.m_txTextControl.InputFormat.RightToLeft;
				ribbonToggleButton.Checked = rightToLeft.HasValue && rightToLeft.Value;
			}
		}

		private void method_43()
		{
			RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_ControlChars.ToString()] as RibbonToggleButton;
			if (this.class502_0.method_2(ribbonToggleButton))
			{
				ribbonToggleButton.Checked = base.m_txTextControl != null && base.m_txTextControl.ControlChars;
			}
		}

		private void method_44()
		{
			RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_LeftAligned.ToString()] as RibbonToggleButton;
			if (this.class502_0.method_2(ribbonToggleButton))
			{
				bool? leftAligned = base.m_txTextControl.InputFormat.LeftAligned;
				ribbonToggleButton.Checked = leftAligned.HasValue && leftAligned.Value;
			}
		}

		private void method_45()
		{
			RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Centered.ToString()] as RibbonToggleButton;
			if (this.class502_0.method_2(ribbonToggleButton))
			{
				bool? centered = base.m_txTextControl.InputFormat.Centered;
				ribbonToggleButton.Checked = centered.HasValue && centered.Value;
			}
		}

		private void method_46()
		{
			RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_RightAligned.ToString()] as RibbonToggleButton;
			if (this.class502_0.method_2(ribbonToggleButton))
			{
				bool? rightAligned = base.m_txTextControl.InputFormat.RightAligned;
				ribbonToggleButton.Checked = rightAligned.HasValue && rightAligned.Value;
			}
		}

		private void method_47()
		{
			RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Justified.ToString()] as RibbonToggleButton;
			if (this.class502_0.method_2(ribbonToggleButton))
			{
				bool? justified = base.m_txTextControl.InputFormat.Justified;
				ribbonToggleButton.Checked = justified.HasValue && justified.Value;
			}
		}

		private void method_48()
		{
			RibbonMenuButton object_ = this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Borders.ToString()] as RibbonMenuButton;
			if (this.class502_0.method_3(object_))
			{
				this.method_49();
				this.method_50();
				this.method_51();
				this.method_52();
				this.method_53();
				this.method_54();
				this.method_55();
				this.method_56();
				this.method_59();
			}
		}

		private void method_49()
		{
			RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_LeftFrameLine.ToString()] as RibbonToggleButton;
			if (this.class502_0.method_2(ribbonToggleButton))
			{
				ribbonToggleButton.Checked = base.m_txTextControl.InputFormat.LeftFrameLine;
			}
		}

		private void method_50()
		{
			RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_TopFrameLine.ToString()] as RibbonToggleButton;
			if (this.class502_0.method_2(ribbonToggleButton))
			{
				ribbonToggleButton.Checked = base.m_txTextControl.InputFormat.TopFrameLine;
			}
		}

		private void method_51()
		{
			RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_RightFrameLine.ToString()] as RibbonToggleButton;
			if (this.class502_0.method_2(ribbonToggleButton))
			{
				ribbonToggleButton.Checked = base.m_txTextControl.InputFormat.RightFrameLine;
			}
		}

		private void method_52()
		{
			RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_BottomFrameLine.ToString()] as RibbonToggleButton;
			if (this.class502_0.method_2(ribbonToggleButton))
			{
				ribbonToggleButton.Checked = base.m_txTextControl.InputFormat.BottomFrameLine;
			}
		}

		private void method_53()
		{
			RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_BoxFrame.ToString()] as RibbonToggleButton;
			if (this.class502_0.method_2(ribbonToggleButton))
			{
				ribbonToggleButton.Checked = base.m_txTextControl.InputFormat.BoxFrame;
			}
		}

		private void method_54()
		{
			RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_AllFrameLines.ToString()] as RibbonToggleButton;
			if (this.class502_0.method_2(ribbonToggleButton))
			{
				ribbonToggleButton.Checked = base.m_txTextControl.InputFormat.AllFrameLines;
			}
		}

		private void method_55()
		{
			RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_InnerHorizontalFrameLines.ToString()] as RibbonToggleButton;
			if (this.class502_0.method_2(ribbonToggleButton))
			{
				ribbonToggleButton.Checked = base.m_txTextControl.InputFormat.InnerHorizontalFrameLines;
			}
		}

		private void method_56()
		{
			RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_InnerVerticalFrameLines.ToString()] as RibbonToggleButton;
			if (this.class502_0.method_2(ribbonToggleButton))
			{
				ribbonToggleButton.Checked = base.m_txTextControl.InputFormat.InnerVerticalFrameLines;
			}
		}

		private void method_57()
		{
			RibbonMenuButton ribbonMenuButton = this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_BackColor.ToString()] as RibbonMenuButton;
			if (this.class502_0.method_2(ribbonMenuButton))
			{
				Class517.smethod_59(ribbonMenuButton, base.m_txTextControl.InputFormat.FrameFillColor, bool_0: false, base.m_pntDPI);
			}
			RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_BackColor_Transparent.ToString()] as RibbonToggleButton;
			if (this.class502_0.method_2(ribbonToggleButton))
			{
				ribbonToggleButton.Checked = base.m_txTextControl.InputFormat.FrameFillColor.HasValue && base.m_txTextControl.InputFormat.FrameFillColor.HasValue && base.m_txTextControl.InputFormat.FrameFillColor.Value.Name == Color.Transparent.Name;
			}
		}

		private void method_58()
		{
			RibbonMenuButton ribbonMenuButton = this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_FrameLineColor.ToString()] as RibbonMenuButton;
			if (this.class502_0.method_2(ribbonMenuButton))
			{
				Class517.smethod_59(ribbonMenuButton, base.m_txTextControl.InputFormat.FrameLineColor, bool_0: false, base.m_pntDPI);
			}
			RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_FrameLineColor_Automatic.ToString()] as RibbonToggleButton;
			if (this.class502_0.method_2(ribbonToggleButton))
			{
				ribbonToggleButton.Checked = base.m_txTextControl.InputFormat.FrameLineColor.HasValue && base.m_txTextControl.InputFormat.FrameLineColor.Value.IsNamedColor && base.m_txTextControl.InputFormat.FrameLineColor.Value.Name == SystemColors.WindowText.Name;
			}
		}

		private void method_59()
		{
			RibbonMenuButton ribbonMenuButton = this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_FrameLineWidth.ToString()] as RibbonMenuButton;
			if (!this.class502_0.method_3(ribbonMenuButton))
			{
				return;
			}
			int? frameLineWidth = base.m_txTextControl.InputFormat.FrameLineWidth;
			foreach (IRibbonItem dropDownItem in ribbonMenuButton.DropDownItems)
			{
				if (dropDownItem.IsDefaultRibbonTabItem)
				{
					RibbonToggleButton ribbonToggleButton = dropDownItem as RibbonToggleButton;
					ribbonToggleButton.Checked = (ribbonToggleButton.Tag as object[])[0] as int? == frameLineWidth;
				}
			}
		}

		private void method_60()
		{
			RibbonGroup ribbonGroup = this.class502_0.TXITEM_StylesGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_StylesGroup.ToString()] as RibbonGroup;
			if (this.class502_0.method_2(ribbonGroup))
			{
				this.method_67(base.m_pntDPI);
				if (ribbonGroup != null && !ribbonGroup.Visible)
				{
					ribbonGroup.method_3(bool_7: true);
				}
			}
		}

		private void method_61()
		{
			RibbonGroup object_ = this.class502_0.TXITEM_StylesGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_StylesGroup.ToString()] as RibbonGroup;
			if (this.class502_0.method_2(object_))
			{
				this.method_66();
			}
		}

		protected override Color? GetCurrentColor(string colorButtonName)
		{
			Color? result = null;
			if (base.m_txTextControl != null)
			{
				switch (colorButtonName)
				{
				case "TXITEM_FrameLineColor":
					return base.m_txTextControl.InputFormat.FrameLineColor;
				case "TXITEM_BackColor":
					return base.m_txTextControl.InputFormat.FrameFillColor;
				case "TXITEM_TextColor":
					return base.m_txTextControl.InputFormat.TextColor;
				case "TXITEM_TextBackColor":
					return base.m_txTextControl.InputFormat.TextBackColor;
				}
			}
			return result;
		}

		private RibbonListView.RibbonListViewItem method_62(RibbonListView.RibbonListViewItem ribbonListViewItem_1, RibbonListView ribbonListView_0, out RibbonListView ribbonListView_1)
		{
			if (((IContentItem)ribbonListView_0).Original != null && ribbonListViewItem_1 != null)
			{
				ribbonListView_1 = ((IContentItem)ribbonListView_0).Original as RibbonListView;
				return ribbonListView_1.RibbonListViewItems[ribbonListViewItem_1.Int32_1];
			}
			ribbonListView_1 = ribbonListView_0;
			return ribbonListViewItem_1;
		}

		private RibbonListView.RibbonListViewItem[] method_63(Size size_4, string[] string_0)
		{
			RibbonListView.RibbonListViewItem[] array = new RibbonListView.RibbonListViewItem[0];
			if (this.method_65())
			{
				array = new RibbonListView.RibbonListViewItem[string_0.Length];
				ParagraphStyleCollection paragraphStyleCollection = new ParagraphStyleCollection(base.m_txTextControl.textControlCore_0);
				InlineStyleCollection inlineStyleCollection = new InlineStyleCollection(base.m_txTextControl.textControlCore_0);
				ParagraphStyleCollection paragraphStyleCollection2 = new ParagraphStyleCollection(this.textControl_0.textControlCore_0);
				InlineStyleCollection inlineStyleCollection2 = new InlineStyleCollection(this.textControl_0.textControlCore_0);
				bool flag = this.class502_0.Control_0.RightToLeft == RightToLeft.Yes;
				for (int i = 0; i < array.Length; i++)
				{
					string text = string_0[i];
					bool flag2;
					Bitmap bitmap = Class517.smethod_41(text, this.textControl_0, new FormattingStyleCollection[4] { paragraphStyleCollection, inlineStyleCollection, paragraphStyleCollection2, inlineStyleCollection2 }, flag, size_4, out flag2, base.m_pntDPI);
					RibbonListView.RibbonListViewItem ribbonListViewItem = new RibbonListView.RibbonListViewItem();
					ribbonListViewItem.Icon = bitmap;
					ribbonListViewItem.Tag = new object[4] { text, bitmap, true, false };
					array[i] = ribbonListViewItem;
				}
			}
			return array;
		}

		private RibbonListView.RibbonListViewItem[] method_64(string string_0, RibbonListView ribbonListView_0)
		{
			if (string_0 != null)
			{
				foreach (RibbonListView.RibbonListViewItem ribbonListViewItem in ribbonListView_0.RibbonListViewItems)
				{
					if (ribbonListViewItem.Tag != null && (ribbonListViewItem.Tag as object[])[0].ToString() == string_0)
					{
						return new RibbonListView.RibbonListViewItem[1] { ribbonListViewItem };
					}
				}
			}
			return new RibbonListView.RibbonListViewItem[0];
		}

		private bool method_65()
		{
			if (this.textControl_0 == null && base.m_txTextControl != null)
			{
				try
				{
					this.textControl_0 = new TextControl();
					this.textControl_0.AllowDrag = false;
					this.textControl_0.AllowDrop = false;
					this.textControl_0.AllowUndo = false;
					this.textControl_0.CreateControl();
				}
				catch
				{
					return false;
				}
				this.textControl_0.PageUnit = MeasuringUnit.Twips;
				this.textControl_0.Location = base.m_txTextControl.Location;
				this.textControl_0.ViewMode = ViewMode.PageView;
				this.textControl_0.Visible = false;
				return true;
			}
			return true;
		}

		private void method_66()
		{
			RibbonListView ribbonListView = this.class502_0.TXITEM_StylesGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_StyleName.ToString()] as RibbonListView;
			if (base.m_txTextControl != null)
			{
				if (ribbonListView != null)
				{
					ribbonListView.SelectedItems = this.method_64(base.m_txTextControl.InputFormat.StyleName, ribbonListView);
					if (ribbonListView.SelectedItems.Length > 0)
					{
						ribbonListView.ScrollTo(ribbonListView.SelectedItems[0]);
						ribbonListView.HideItems = false;
					}
					else
					{
						ribbonListView.HideItems = true;
					}
				}
			}
			else
			{
				ribbonListView.HideItems = true;
			}
		}

		private void method_67(PointF pointF_0)
		{
			if (pointF_0.IsEmpty)
			{
				return;
			}
			RibbonListView ribbonListView = this.class502_0.TXITEM_StylesGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_StyleName.ToString()] as RibbonListView;
			if (ribbonListView != null)
			{
				if (base.m_txTextControl != null && (this.ribbonListViewItem_0 = this.method_63(Class517.smethod_48(Class519.Class532.Size_0, pointF_0), base.m_txTextControl.InputFormat.StyleNames)).Length > 0)
				{
					ribbonListView.ItemsSource = this.ribbonListViewItem_0;
					ribbonListView.Width = Class517.smethod_45(Class519.Class532.Size_0.Width, pointF_0.X);
					return;
				}
				Size size = Class517.smethod_48(Class519.Class532.Size_0, pointF_0);
				ribbonListView.ItemsSource = new RibbonListView.RibbonListViewItem[1]
				{
					new RibbonListView.RibbonListViewItem
					{
						Icon = new Bitmap(size.Width, size.Height)
					}
				};
			}
		}

		internal void method_68(Sidebar sidebar_0)
		{
			if (sidebar_0 != null)
			{
				sidebar_0.PropertyChanged -= method_166;
			}
			RibbonFormattingTab ribbonFormattingTab = this.class502_0.Control_0 as RibbonFormattingTab;
			if (ribbonFormattingTab != null && ribbonFormattingTab.StylesSidebar != null)
			{
				this.point_3 = ribbonFormattingTab.StylesSidebar.DialogLocation;
				this.size_3 = ribbonFormattingTab.StylesSidebar.DialogSize;
				ribbonFormattingTab.StylesSidebar.PropertyChanged -= method_166;
				ribbonFormattingTab.StylesSidebar.PropertyChanged += method_166;
				ribbonFormattingTab.StylesSidebar.DialogOpening -= method_174;
				ribbonFormattingTab.StylesSidebar.DialogOpening += method_174;
				ribbonFormattingTab.StylesSidebar.DialogClosed -= method_175;
				ribbonFormattingTab.StylesSidebar.DialogClosed += method_175;
				this.bool_3 = ribbonFormattingTab.StylesSidebar.IsPinned;
			}
		}

		internal void method_69(Sidebar sidebar_0)
		{
			if (sidebar_0 != null)
			{
				sidebar_0.PropertyChanged -= method_168;
			}
			if (base.m_txTextControl == null)
			{
				return;
			}
			RibbonFormattingTab ribbonFormattingTab = this.class502_0.Control_0 as RibbonFormattingTab;
			if (ribbonFormattingTab == null)
			{
				return;
			}
			RibbonButton ribbonButton = this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Find.ToString()] as RibbonButton;
			RibbonButton ribbonButton2;
			if (ribbonFormattingTab.FindHorizontalSidebar == null && ribbonFormattingTab.FindSidebar == null)
			{
				if (!(ribbonButton is RibbonSplitButton) && !(ribbonButton is RibbonToggleButton))
				{
					return;
				}
				ribbonButton2 = this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Find_Dialog.ToString()] as RibbonButton;
			}
			else
			{
				bool bool_ = false;
				bool bool_2 = false;
				bool bool_3 = false;
				bool bool_4 = false;
				bool bool_5 = false;
				bool bool_6 = false;
				bool bool_7;
				if (bool_7 = ribbonFormattingTab.FindHorizontalSidebar != null)
				{
					bool_6 = ribbonFormattingTab.FindHorizontalSidebar.ContentLayout == Sidebar.SidebarContentLayout.Find;
					this.point_1 = ribbonFormattingTab.FindHorizontalSidebar.DialogLocation;
					this.size_1 = ribbonFormattingTab.FindHorizontalSidebar.DialogSize;
					bool_ = ribbonFormattingTab.FindHorizontalSidebar.IsShown;
					bool_3 = ribbonFormattingTab.FindHorizontalSidebar.IsPinned;
					ribbonFormattingTab.FindHorizontalSidebar.PropertyChanged -= method_168;
					ribbonFormattingTab.FindHorizontalSidebar.PropertyChanged += method_168;
					ribbonFormattingTab.FindHorizontalSidebar.DialogOpening -= method_174;
					ribbonFormattingTab.FindHorizontalSidebar.DialogOpening += method_174;
					ribbonFormattingTab.FindHorizontalSidebar.DialogClosed -= method_175;
					ribbonFormattingTab.FindHorizontalSidebar.DialogClosed += method_175;
				}
				bool bool_8;
				if (bool_8 = ribbonFormattingTab.FindSidebar != null)
				{
					bool_5 = ribbonFormattingTab.FindSidebar.ContentLayout == Sidebar.SidebarContentLayout.Find;
					this.point_1 = ribbonFormattingTab.FindSidebar.DialogLocation;
					this.size_1 = ribbonFormattingTab.FindSidebar.DialogSize;
					bool_2 = ribbonFormattingTab.FindSidebar.IsShown;
					bool_4 = ribbonFormattingTab.FindSidebar.IsPinned;
					ribbonFormattingTab.FindSidebar.PropertyChanged -= method_168;
					ribbonFormattingTab.FindSidebar.PropertyChanged += method_168;
					ribbonFormattingTab.FindSidebar.DialogOpening -= method_174;
					ribbonFormattingTab.FindSidebar.DialogOpening += method_174;
					ribbonFormattingTab.FindSidebar.DialogClosed -= method_175;
					ribbonFormattingTab.FindSidebar.DialogClosed += method_175;
				}
				ribbonButton2 = this.method_70(bool_5, bool_6, ribbonButton, bool_8, bool_7, bool_2, bool_, bool_4, bool_3);
			}
			if (ribbonButton2 != null)
			{
				Class517.smethod_37(RibbonFormattingTab.InternalRibbonItem.TXITEM_Find.ToString(), ribbonButton, this.class502_0.TXITEM_EditingGroup_Items, ribbonButton2);
			}
		}

		private RibbonButton method_70(bool bool_4, bool bool_5, RibbonButton ribbonButton_0, bool bool_6, bool bool_7, bool bool_8, bool bool_9, bool bool_10, bool bool_11)
		{
			RibbonButton ribbonButton = this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Find_Sidebars.ToString()] as RibbonSplitButton;
			(ribbonButton as RibbonSplitButton).Checked = (bool_4 && bool_8) || (bool_5 && bool_9);
			RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Find_Sidebars_Vertical.ToString()] as RibbonToggleButton;
			if (ribbonToggleButton.Visible = bool_6)
			{
				ribbonToggleButton.Checked = (bool_10 && bool_4) || !bool_11 || !bool_5;
			}
			RibbonToggleButton ribbonToggleButton2 = this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Find_Sidebars_Horizontal.ToString()] as RibbonToggleButton;
			if (ribbonToggleButton2.Visible = bool_7)
			{
				ribbonToggleButton2.Checked = bool_11 && bool_5 && (!bool_10 || !bool_4);
			}
			if (ribbonButton_0 == ribbonButton)
			{
				return null;
			}
			return ribbonButton;
		}

		internal void method_71(Sidebar sidebar_0)
		{
			if (sidebar_0 != null)
			{
				sidebar_0.PropertyChanged -= method_170;
			}
			if (base.m_txTextControl == null)
			{
				return;
			}
			RibbonFormattingTab ribbonFormattingTab = this.class502_0.Control_0 as RibbonFormattingTab;
			if (ribbonFormattingTab == null)
			{
				return;
			}
			RibbonButton ribbonButton = this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Replace.ToString()] as RibbonButton;
			RibbonButton ribbonButton2;
			if (ribbonFormattingTab.ReplaceHorizontalSidebar == null && ribbonFormattingTab.ReplaceSidebar == null)
			{
				if (!(ribbonButton is RibbonSplitButton) && !(ribbonButton is RibbonToggleButton))
				{
					return;
				}
				ribbonButton2 = this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Replace_Dialog.ToString()] as RibbonButton;
			}
			else
			{
				bool bool_ = false;
				bool bool_2 = false;
				bool bool_3 = false;
				bool bool_4 = false;
				bool bool_5 = false;
				bool bool_6 = false;
				bool bool_7;
				if (bool_7 = ribbonFormattingTab.ReplaceHorizontalSidebar != null)
				{
					bool_6 = ribbonFormattingTab.ReplaceHorizontalSidebar.ContentLayout == Sidebar.SidebarContentLayout.Replace;
					this.point_2 = ribbonFormattingTab.ReplaceHorizontalSidebar.DialogLocation;
					this.size_2 = ribbonFormattingTab.ReplaceHorizontalSidebar.DialogSize;
					bool_ = ribbonFormattingTab.ReplaceHorizontalSidebar.IsShown;
					bool_3 = ribbonFormattingTab.ReplaceHorizontalSidebar.IsPinned;
					ribbonFormattingTab.ReplaceHorizontalSidebar.PropertyChanged -= method_170;
					ribbonFormattingTab.ReplaceHorizontalSidebar.PropertyChanged += method_170;
					ribbonFormattingTab.ReplaceHorizontalSidebar.DialogOpening -= method_174;
					ribbonFormattingTab.ReplaceHorizontalSidebar.DialogOpening += method_174;
					ribbonFormattingTab.ReplaceHorizontalSidebar.DialogClosed -= method_175;
					ribbonFormattingTab.ReplaceHorizontalSidebar.DialogClosed += method_175;
				}
				bool bool_8;
				if (bool_8 = ribbonFormattingTab.ReplaceSidebar != null)
				{
					bool_5 = ribbonFormattingTab.ReplaceSidebar.ContentLayout == Sidebar.SidebarContentLayout.Replace;
					this.point_2 = ribbonFormattingTab.ReplaceSidebar.DialogLocation;
					this.size_2 = ribbonFormattingTab.ReplaceSidebar.DialogSize;
					bool_2 = ribbonFormattingTab.ReplaceSidebar.IsShown;
					bool_4 = ribbonFormattingTab.ReplaceSidebar.IsPinned;
					ribbonFormattingTab.ReplaceSidebar.PropertyChanged -= method_170;
					ribbonFormattingTab.ReplaceSidebar.PropertyChanged += method_170;
					ribbonFormattingTab.ReplaceSidebar.DialogOpening -= method_174;
					ribbonFormattingTab.ReplaceSidebar.DialogOpening += method_174;
					ribbonFormattingTab.ReplaceSidebar.DialogClosed -= method_175;
					ribbonFormattingTab.ReplaceSidebar.DialogClosed += method_175;
				}
				ribbonButton2 = this.method_72(bool_5, bool_6, ribbonButton, bool_8, bool_7, bool_2, bool_, bool_4, bool_3);
			}
			if (ribbonButton2 != null)
			{
				Class517.smethod_37(RibbonFormattingTab.InternalRibbonItem.TXITEM_Replace.ToString(), ribbonButton, this.class502_0.TXITEM_EditingGroup_Items, ribbonButton2);
			}
		}

		private RibbonButton method_72(bool bool_4, bool bool_5, RibbonButton ribbonButton_0, bool bool_6, bool bool_7, bool bool_8, bool bool_9, bool bool_10, bool bool_11)
		{
			RibbonButton ribbonButton = this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Replace_Sidebars.ToString()] as RibbonSplitButton;
			(ribbonButton as RibbonSplitButton).Checked = (bool_4 && bool_8) || (bool_5 && bool_9);
			RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Replace_Sidebars_Vertical.ToString()] as RibbonToggleButton;
			if (ribbonToggleButton.Visible = bool_6)
			{
				ribbonToggleButton.Checked = (bool_10 && bool_4) || !bool_11 || !bool_5;
			}
			RibbonToggleButton ribbonToggleButton2 = this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Replace_Sidebars_Horizontal.ToString()] as RibbonToggleButton;
			if (ribbonToggleButton2.Visible = bool_7)
			{
				ribbonToggleButton2.Checked = bool_11 && bool_5 && (!bool_10 || !bool_4);
			}
			if (ribbonButton_0 == ribbonButton)
			{
				return null;
			}
			return ribbonButton;
		}

		internal void method_73(Sidebar sidebar_0)
		{
			if (sidebar_0 != null)
			{
				sidebar_0.PropertyChanged -= method_172;
			}
			if (base.m_txTextControl == null)
			{
				return;
			}
			RibbonFormattingTab ribbonFormattingTab = this.class502_0.Control_0 as RibbonFormattingTab;
			if (ribbonFormattingTab == null)
			{
				return;
			}
			RibbonButton ribbonButton = this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Goto.ToString()] as RibbonButton;
			RibbonButton ribbonButton2;
			if (ribbonFormattingTab.GotoHorizontalSidebar == null && ribbonFormattingTab.GotoSidebar == null)
			{
				if (!(ribbonButton is RibbonSplitButton) && !(ribbonButton is RibbonToggleButton))
				{
					return;
				}
				ribbonButton2 = this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Goto_Dialog.ToString()] as RibbonButton;
			}
			else
			{
				bool bool_ = false;
				bool bool_2 = false;
				bool bool_3 = false;
				bool bool_4 = false;
				bool bool_5 = false;
				bool bool_6 = false;
				bool bool_7;
				if (bool_7 = ribbonFormattingTab.GotoHorizontalSidebar != null)
				{
					bool_6 = ribbonFormattingTab.GotoHorizontalSidebar.ContentLayout == Sidebar.SidebarContentLayout.Goto;
					this.point_0 = ribbonFormattingTab.GotoHorizontalSidebar.DialogLocation;
					this.size_0 = ribbonFormattingTab.GotoHorizontalSidebar.DialogSize;
					bool_ = ribbonFormattingTab.GotoHorizontalSidebar.IsShown;
					bool_3 = ribbonFormattingTab.GotoHorizontalSidebar.IsPinned;
					ribbonFormattingTab.GotoHorizontalSidebar.PropertyChanged -= method_172;
					ribbonFormattingTab.GotoHorizontalSidebar.PropertyChanged += method_172;
					ribbonFormattingTab.GotoHorizontalSidebar.DialogOpening -= method_174;
					ribbonFormattingTab.GotoHorizontalSidebar.DialogOpening += method_174;
					ribbonFormattingTab.GotoHorizontalSidebar.DialogClosed -= method_175;
					ribbonFormattingTab.GotoHorizontalSidebar.DialogClosed += method_175;
				}
				bool bool_8;
				if (bool_8 = ribbonFormattingTab.GotoSidebar != null)
				{
					bool_5 = ribbonFormattingTab.GotoSidebar.ContentLayout == Sidebar.SidebarContentLayout.Goto;
					this.point_0 = ribbonFormattingTab.GotoSidebar.DialogLocation;
					this.size_0 = ribbonFormattingTab.GotoSidebar.DialogSize;
					bool_2 = ribbonFormattingTab.GotoSidebar.IsShown;
					bool_4 = ribbonFormattingTab.GotoSidebar.IsPinned;
					ribbonFormattingTab.GotoSidebar.PropertyChanged -= method_172;
					ribbonFormattingTab.GotoSidebar.PropertyChanged += method_172;
					ribbonFormattingTab.GotoSidebar.DialogOpening -= method_174;
					ribbonFormattingTab.GotoSidebar.DialogOpening += method_174;
					ribbonFormattingTab.GotoSidebar.DialogClosed -= method_175;
					ribbonFormattingTab.GotoSidebar.DialogClosed += method_175;
				}
				ribbonButton2 = this.method_74(bool_5, bool_6, ribbonButton, bool_8, bool_7, bool_2, bool_, bool_4, bool_3);
			}
			if (ribbonButton2 != null)
			{
				Class517.smethod_37(RibbonFormattingTab.InternalRibbonItem.TXITEM_Goto.ToString(), ribbonButton, this.class502_0.TXITEM_EditingGroup_Items, ribbonButton2);
			}
		}

		private RibbonButton method_74(bool bool_4, bool bool_5, RibbonButton ribbonButton_0, bool bool_6, bool bool_7, bool bool_8, bool bool_9, bool bool_10, bool bool_11)
		{
			RibbonButton ribbonButton = this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Goto_Sidebars.ToString()] as RibbonSplitButton;
			(ribbonButton as RibbonSplitButton).Checked = (bool_4 && bool_8) || (bool_5 && bool_9);
			RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Goto_Sidebars_Vertical.ToString()] as RibbonToggleButton;
			if (ribbonToggleButton.Visible = bool_6)
			{
				ribbonToggleButton.Checked = (bool_10 && bool_4) || !bool_11 || !bool_5;
			}
			RibbonToggleButton ribbonToggleButton2 = this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Goto_Sidebars_Horizontal.ToString()] as RibbonToggleButton;
			if (ribbonToggleButton2.Visible = bool_7)
			{
				ribbonToggleButton2.Checked = bool_11 && bool_5 && (!bool_10 || !bool_4);
			}
			if (ribbonButton_0 == ribbonButton)
			{
				return null;
			}
			return ribbonButton;
		}

		private void method_75()
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.Paste();
			}
		}

		private void method_76(RibbonSplitButton ribbonSplitButton_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			IList clipboardFormats = base.m_txTextControl.GetClipboardFormats();
			ClipboardFormat clipboardFormat = ClipboardFormat.PlainText;
			ClipboardFormat clipboardFormat2 = ClipboardFormat.PlainText;
			if (clipboardFormats != null)
			{
				clipboardFormat = (clipboardFormats.Contains(ClipboardFormat.TXTextControlFormat) ? ClipboardFormat.TXTextControlFormat : (clipboardFormats.Contains(ClipboardFormat.RichTextFormat) ? ClipboardFormat.RichTextFormat : (clipboardFormats.Contains(ClipboardFormat.HTMLFormat) ? ClipboardFormat.HTMLFormat : ((ClipboardFormat)0))));
				clipboardFormat2 = (clipboardFormats.Contains(ClipboardFormat.TXTextControlImage) ? ClipboardFormat.TXTextControlImage : (clipboardFormats.Contains(ClipboardFormat.Image) ? ClipboardFormat.Image : ((ClipboardFormat)0)));
			}
			foreach (Control dropDownItem in ribbonSplitButton_0.DropDownItems)
			{
				if (dropDownItem is RibbonButton && (dropDownItem as IRibbonItem).IsDefaultRibbonTabItem)
				{
					RibbonButton ribbonButton = dropDownItem as RibbonButton;
					switch (dropDownItem.Name)
					{
					case "TXITEM_PasteText":
						ribbonButton.Enabled = clipboardFormats?.Contains(clipboardFormat) ?? false;
						ribbonButton.Tag = (int)clipboardFormat;
						break;
					case "TXITEM_PastePlainText":
						ribbonButton.Enabled = clipboardFormats?.Contains((ClipboardFormat)ribbonButton.Tag) ?? false;
						break;
					case "TXITEM_PasteImage":
						ribbonButton.Enabled = clipboardFormats?.Contains(clipboardFormat2) ?? false;
						ribbonButton.Tag = (int)clipboardFormat2;
						break;
					case "TXITEM_PasteTextFrame":
						ribbonButton.Enabled = clipboardFormats?.Contains((ClipboardFormat)ribbonButton.Tag) ?? false;
						break;
					case "TXITEM_PasteChart":
						ribbonButton.Enabled = clipboardFormats?.Contains((ClipboardFormat)ribbonButton.Tag) ?? false;
						break;
					case "TXITEM_PasteBarcode":
						ribbonButton.Enabled = clipboardFormats?.Contains((ClipboardFormat)ribbonButton.Tag) ?? false;
						break;
					case "TXITEM_PasteDrawing":
						ribbonButton.Enabled = clipboardFormats?.Contains((ClipboardFormat)ribbonButton.Tag) ?? false;
						break;
					}
				}
			}
		}

		private void method_77(RibbonButton ribbonButton_0)
		{
			if (base.m_txTextControl != null && ribbonButton_0 != null)
			{
				ClipboardFormat clipboardFormat = ((ribbonButton_0.Tag != null && ribbonButton_0.Tag.GetType() == typeof(int)) ? ((ClipboardFormat)ribbonButton_0.Tag) : ((ClipboardFormat)0));
				if (clipboardFormat != 0)
				{
					base.m_txTextControl.Paste(clipboardFormat);
				}
			}
		}

		private void method_78()
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.method_36(bool_20: false);
			}
		}

		private void method_79()
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.method_35(bool_20: false);
			}
		}

		private void method_80()
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.FontDialog();
			}
		}

		private void method_81(RibbonComboBox ribbonComboBox_0, Keys keys_0)
		{
			if (base.m_txTextControl == null || (keys_0 != Keys.Return && keys_0 != Keys.Return))
			{
				return;
			}
			base.m_bTextControlChanged = true;
			if (ribbonComboBox_0.Items.Contains(ribbonComboBox_0.Text))
			{
				if (base.m_txTextControl.InputFormat.FontFamily != ribbonComboBox_0.Text)
				{
					base.m_txTextControl.InputFormat.FontFamily = ribbonComboBox_0.Text;
				}
			}
			else
			{
				string fontFamily = base.m_txTextControl.InputFormat.FontFamily;
				if (fontFamily == null)
				{
					ribbonComboBox_0.Text = "";
				}
				else if (ribbonComboBox_0.Items.Contains(fontFamily))
				{
					ribbonComboBox_0.SelectedItem = fontFamily;
				}
				else
				{
					ribbonComboBox_0.Text = fontFamily;
				}
			}
			if (!(this.class502_0.Control_0 is MiniToolbar))
			{
				base.m_txTextControl.Focus();
			}
		}

		private void method_82(string string_0)
		{
			if (base.m_txTextControl != null && !base.m_bTextControlChanged)
			{
				base.m_bTextControlChanged = true;
				if (base.m_txTextControl.InputFormat.FontFamily != string_0)
				{
					base.m_txTextControl.textControlCore_0.Enum57_0 = this.enum57_0;
					base.m_txTextControl.InputFormat.FontFamily = string_0;
					base.m_txTextControl.textControlCore_0.Enum57_0 = Enum57.const_0;
				}
				if (!(this.class502_0.Control_0 is MiniToolbar))
				{
					base.m_txTextControl.Focus();
				}
			}
			base.m_bTextControlChanged = false;
		}

		private void method_83(RibbonComboBox ribbonComboBox_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			if (!base.m_bTextControlChanged)
			{
				base.m_bTextControlChanged = true;
				string fontFamily = base.m_txTextControl.InputFormat.FontFamily;
				if (fontFamily == null)
				{
					ribbonComboBox_0.Text = "";
				}
				else if (ribbonComboBox_0.Items.Contains(fontFamily))
				{
					ribbonComboBox_0.SelectedItem = fontFamily;
				}
				else
				{
					ribbonComboBox_0.Text = fontFamily;
				}
			}
			base.m_bTextControlChanged = false;
		}

		private void method_84(RibbonComboBox ribbonComboBox_0, Keys keys_0)
		{
			if (base.m_txTextControl == null || (keys_0 != Keys.Return && keys_0 != Keys.Return))
			{
				return;
			}
			base.m_bTextControlChanged = true;
			if (double.TryParse(ribbonComboBox_0.Text, out var result))
			{
				string text2 = (ribbonComboBox_0.Text = result.ToString("0.#"));
				int num = (int)(double.Parse(ribbonComboBox_0.Text) * 20.0);
				if (base.m_txTextControl.InputFormat.FontSize != num)
				{
					base.m_txTextControl.InputFormat.FontSize = num;
				}
			}
			else if (!base.m_txTextControl.InputFormat.FontSize.HasValue)
			{
				ribbonComboBox_0.Text = "";
			}
			else
			{
				string text3 = ((double)base.m_txTextControl.InputFormat.FontSize.Value / 20.0).ToString("0.#");
				if (ribbonComboBox_0.Items.Contains(text3))
				{
					ribbonComboBox_0.SelectedItem = text3;
				}
				else
				{
					ribbonComboBox_0.Text = text3;
				}
			}
			if (!(this.class502_0.Control_0 is MiniToolbar))
			{
				base.m_txTextControl.Focus();
			}
		}

		private void method_85(RibbonComboBox ribbonComboBox_0)
		{
			if (base.m_txTextControl != null && !base.m_bTextControlChanged)
			{
				base.m_bTextControlChanged = true;
				int num = (int)(double.Parse(ribbonComboBox_0.SelectedItem.ToString()) * 20.0);
				if (base.m_txTextControl.InputFormat.FontSize != num)
				{
					base.m_txTextControl.textControlCore_0.Enum57_0 = this.enum57_0;
					base.m_txTextControl.InputFormat.FontSize = num;
					base.m_txTextControl.textControlCore_0.Enum57_0 = Enum57.const_0;
				}
				if (!(this.class502_0.Control_0 is MiniToolbar))
				{
					Class517.smethod_28(ribbonComboBox_0);
				}
				if (!(this.class502_0.Control_0 is MiniToolbar))
				{
					base.m_txTextControl.Focus();
				}
			}
			base.m_bTextControlChanged = false;
		}

		private void method_86(RibbonComboBox ribbonComboBox_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			if (!base.m_bTextControlChanged)
			{
				if (!base.m_txTextControl.InputFormat.FontSize.HasValue)
				{
					ribbonComboBox_0.Text = "";
				}
				else
				{
					string text = ((double)base.m_txTextControl.InputFormat.FontSize.Value / 20.0).ToString("0.#");
					if (ribbonComboBox_0.Items.Contains(text))
					{
						ribbonComboBox_0.SelectedItem = text;
					}
					else
					{
						ribbonComboBox_0.Text = text;
					}
				}
			}
			base.m_bTextControlChanged = false;
		}

		private void method_87()
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.textControlCore_0.Enum57_0 = this.enum57_0;
				base.m_txTextControl.Selection.GrowFont();
				base.m_txTextControl.textControlCore_0.Enum57_0 = Enum57.const_0;
			}
		}

		private void method_88()
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.textControlCore_0.Enum57_0 = this.enum57_0;
				base.m_txTextControl.Selection.ShrinkFont();
				base.m_txTextControl.textControlCore_0.Enum57_0 = Enum57.const_0;
			}
		}

		private void method_89()
		{
			if (base.m_txTextControl != null)
			{
				Selection selection = base.m_txTextControl.Selection;
				selection.FormattingStyle = "[Normal]";
				selection.RemoveInlineStyles();
			}
		}

		private void method_90(bool bool_4)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.textControlCore_0.Enum57_0 = this.enum57_0;
				base.m_txTextControl.InputFormat.Bold = bool_4;
				base.m_txTextControl.textControlCore_0.Enum57_0 = Enum57.const_0;
			}
		}

		private void method_91(bool bool_4)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.textControlCore_0.Enum57_0 = this.enum57_0;
				base.m_txTextControl.InputFormat.Italic = bool_4;
				base.m_txTextControl.textControlCore_0.Enum57_0 = Enum57.const_0;
			}
		}

		private void method_92(bool bool_4)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.textControlCore_0.Enum57_0 = this.enum57_0;
				base.m_txTextControl.InputFormat.Underline = bool_4;
				base.m_txTextControl.textControlCore_0.Enum57_0 = Enum57.const_0;
			}
		}

		private void method_93(RibbonToggleButton ribbonToggleButton_0)
		{
			FontUnderlineStyle underlineStyle = (FontUnderlineStyle)Enum.Parse(typeof(FontUnderlineStyle), ribbonToggleButton_0.Name.Substring(17));
			base.m_txTextControl.textControlCore_0.Enum57_0 = this.enum57_0;
			base.m_txTextControl.InputFormat.UnderlineStyle = underlineStyle;
			base.m_txTextControl.textControlCore_0.Enum57_0 = Enum57.const_0;
		}

		private void method_94(bool bool_4)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.Strikeout = bool_4;
			}
		}

		private void method_95(bool bool_4)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.Subscript = bool_4;
			}
		}

		private void method_96(bool bool_4)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.Superscript = bool_4;
			}
		}

		private void method_97(RibbonButton ribbonButton_0)
		{
			if (base.m_txTextControl == null || base.m_txTextControl.Selection.Length == 0)
			{
				return;
			}
			string text = base.m_txTextControl.Selection.Text;
			switch (ribbonButton_0.Name)
			{
			case "TXITEM_ChangeCase_Toggle":
			{
				StringBuilder stringBuilder = new StringBuilder();
				string text2 = text;
				foreach (char c in text2)
				{
					stringBuilder.Append(char.IsLower(c) ? char.ToUpper(c) : char.ToLower(c));
				}
				base.m_txTextControl.Selection.Text = stringBuilder.ToString();
				break;
			}
			case "TXITEM_ChangeCase_Capitalize":
				base.m_txTextControl.Selection.Text = new CultureInfo(CultureInfo.CurrentUICulture.Name, useUserOverride: false).TextInfo.ToTitleCase(text);
				break;
			case "TXITEM_ChangeCase_Upper":
				base.m_txTextControl.Selection.Text = text.ToUpper();
				break;
			case "TXITEM_ChangeCase_Lower":
				base.m_txTextControl.Selection.Text = text.ToLower();
				break;
			case "TXITEM_ChangeCase_Sentense":
				base.m_txTextControl.Selection.Text = text.Substring(0, 1).ToUpper() + text.Substring(1, text.Length - 1).ToLower();
				break;
			}
		}

		private void method_98()
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.ParagraphFormatDialog();
			}
		}

		private void method_99(RibbonSplitButton ribbonSplitButton_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			RibbonListView ribbonListView = ribbonSplitButton_0.DropDownItems[2] as RibbonListView;
			switch (ribbonSplitButton_0.Name)
			{
			case "TXITEM_StructuredList":
			{
				NumFormat structuredListFormat = base.m_txTextControl.InputFormat.StructuredListFormat;
				if (structuredListFormat != 0)
				{
					foreach (RibbonListView.RibbonListViewItem ribbonListViewItem4 in ribbonListView.RibbonListViewItems)
					{
						NumFormat numberFormat = (NumFormat)ribbonListViewItem4.Tag;
						if (structuredListFormat == numberFormat)
						{
							ribbonListView.SelectedItems = new RibbonListView.RibbonListViewItem[1] { ribbonListViewItem4 };
							return;
						}
					}
				}
				ribbonListView.SelectedItems = new RibbonListView.RibbonListViewItem[0];
				break;
			}
			case "TXITEM_NumberedList":
			{
				NumFormat numberedListFormat = base.m_txTextControl.InputFormat.NumberedListFormat;
				if (numberedListFormat != 0)
				{
					foreach (RibbonListView.RibbonListViewItem ribbonListViewItem5 in ribbonListView.RibbonListViewItems)
					{
						NumFormat numberFormat2 = (NumFormat)ribbonListViewItem5.Tag;
						if (numberFormat2 == numberedListFormat)
						{
							ribbonListView.SelectedItems = new RibbonListView.RibbonListViewItem[1] { ribbonListViewItem5 };
							return;
						}
					}
				}
				ribbonListView.SelectedItems = new RibbonListView.RibbonListViewItem[0];
				break;
			}
			case "TXITEM_BulletedList":
			{
				char? bulletCharacter = base.m_txTextControl.InputFormat.BulletCharacter;
				if (((int?)bulletCharacter).HasValue)
				{
					string text = bulletCharacter.Value.ToString();
					foreach (RibbonListView.RibbonListViewItem ribbonListViewItem6 in ribbonListView.RibbonListViewItems)
					{
						string text2 = (string)ribbonListViewItem6.Tag;
						if (text2 == text)
						{
							ribbonListView.SelectedItems = new RibbonListView.RibbonListViewItem[1] { ribbonListViewItem6 };
							return;
						}
					}
				}
				ribbonListView.SelectedItems = new RibbonListView.RibbonListViewItem[0];
				break;
			}
			}
		}

		private void method_100(bool bool_4)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.BulletedList = bool_4;
			}
		}

		private void method_101(bool bool_4)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.NumberedList = bool_4;
			}
		}

		private void method_102(bool bool_4)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.StructuredList = bool_4;
			}
		}

		private void method_103(RibbonListView ribbonListView_0, RibbonListView.RibbonListViewItemEventArgs ribbonListViewItemEventArgs_0)
		{
			if (base.m_txTextControl != null)
			{
				switch (ribbonListView_0.Name)
				{
				case "TXITEM_StructuredList_Gallery":
					base.m_txTextControl.InputFormat.StructuredListFormat = (NumFormat)ribbonListViewItemEventArgs_0.Item.Tag;
					break;
				case "TXITEM_NumberedList_Gallery":
					base.m_txTextControl.InputFormat.NumberedListFormat = (NumFormat)ribbonListViewItemEventArgs_0.Item.Tag;
					break;
				case "TXITEM_BulletedList_Gallery":
					base.m_txTextControl.InputFormat.BulletCharacter = ((string)ribbonListViewItemEventArgs_0.Item.Tag)[0];
					break;
				}
			}
		}

		private void method_104()
		{
			base.m_txTextControl.ListFormatDialog();
		}

		private void method_105()
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.Selection.DecreaseIndent();
			}
		}

		private void method_106()
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.Selection.IncreaseIndent();
			}
		}

		private void method_107(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.LeftToRight = ribbonToggleButton_0.Checked;
				ribbonToggleButton_0.Checked = base.m_txTextControl.InputFormat.LeftToRight.HasValue && base.m_txTextControl.InputFormat.LeftToRight.Value;
			}
		}

		private void method_108(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.RightToLeft = ribbonToggleButton_0.Checked;
				ribbonToggleButton_0.Checked = base.m_txTextControl.InputFormat.RightToLeft.HasValue && base.m_txTextControl.InputFormat.RightToLeft.Value;
			}
		}

		private void method_109()
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.TabDialog();
			}
		}

		private void method_110(bool bool_4)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.ControlChars = bool_4;
			}
		}

		private void method_111(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.LeftAligned = ribbonToggleButton_0.Checked;
				ribbonToggleButton_0.Checked = base.m_txTextControl.InputFormat.LeftAligned.HasValue && base.m_txTextControl.InputFormat.LeftAligned.Value;
			}
		}

		private void method_112(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.Centered = ribbonToggleButton_0.Checked;
				ribbonToggleButton_0.Checked = base.m_txTextControl.InputFormat.Centered.HasValue && base.m_txTextControl.InputFormat.Centered.Value;
			}
		}

		private void method_113(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.RightAligned = ribbonToggleButton_0.Checked;
				ribbonToggleButton_0.Checked = base.m_txTextControl.InputFormat.RightAligned.HasValue && base.m_txTextControl.InputFormat.RightAligned.Value;
			}
		}

		private void method_114(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.Justified = ribbonToggleButton_0.Checked;
				ribbonToggleButton_0.Checked = base.m_txTextControl.InputFormat.Justified.HasValue && base.m_txTextControl.InputFormat.Justified.Value;
			}
		}

		private void method_115(RibbonMenuButton ribbonMenuButton_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			int? lineSpacing = base.m_txTextControl.InputFormat.LineSpacing;
			foreach (RibbonToggleButton dropDownItem in ribbonMenuButton_0.DropDownItems)
			{
				dropDownItem.Checked = lineSpacing.HasValue && string.Concat(lineSpacing.Value) == dropDownItem.Name.Substring(dropDownItem.Name.LastIndexOf('_') + 1);
			}
		}

		private void method_116(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				double num = Math.Round(Convert.ToDouble(ribbonToggleButton_0.Text) * 100.0);
				base.m_txTextControl.InputFormat.LineSpacing = (int)num;
			}
		}

		private void method_117()
		{
			if (base.m_txTextControl != null)
			{
				RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_InnerVerticalFrameLines.ToString()] as RibbonToggleButton;
				ribbonToggleButton.Visible = base.m_txTextControl.Tables.GetItem() != null;
			}
		}

		private void method_118(bool bool_4)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.LeftFrameLine = bool_4;
			}
		}

		private void method_119(bool bool_4)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.TopFrameLine = bool_4;
			}
		}

		private void method_120(bool bool_4)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.RightFrameLine = bool_4;
			}
		}

		private void method_121(bool bool_4)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.BottomFrameLine = bool_4;
			}
		}

		private void method_122(bool bool_4)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.BoxFrame = bool_4;
			}
		}

		private void method_123(bool bool_4)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.AllFrameLines = bool_4;
			}
		}

		private void method_124(bool bool_4)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.InnerHorizontalFrameLines = bool_4;
			}
		}

		private void method_125(bool bool_4)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.InnerVerticalFrameLines = bool_4;
			}
		}

		private void method_126(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			int? frameLineWidth = (int)(ribbonToggleButton_0.Tag as object[])[0];
			base.m_txTextControl.InputFormat.FrameLineWidth = frameLineWidth;
			frameLineWidth = base.m_txTextControl.InputFormat.FrameLineWidth;
			RibbonMenuButton ribbonMenuButton = this.class502_0.TXITEM_ParagraphGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_FrameLineWidth.ToString()] as RibbonMenuButton;
			foreach (IRibbonItem dropDownItem in ribbonMenuButton.DropDownItems)
			{
				if (dropDownItem.IsDefaultRibbonTabItem)
				{
					RibbonToggleButton ribbonToggleButton = dropDownItem as RibbonToggleButton;
					ribbonToggleButton.Checked = (ribbonToggleButton.Tag as object[])[0] as int? == frameLineWidth;
				}
			}
		}

		private void method_127()
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			RibbonFormattingTab ribbonFormattingTab = this.class502_0.Control_0 as RibbonFormattingTab;
			if (ribbonFormattingTab != null && ribbonFormattingTab.StylesSidebar != null)
			{
				if (ribbonFormattingTab.StylesSidebar.ContentLayout != Sidebar.SidebarContentLayout.Styles)
				{
					if (ribbonFormattingTab.StylesSidebar.IsShown && !ribbonFormattingTab.StylesSidebar.IsPinned)
					{
						ribbonFormattingTab.StylesSidebar.IsShown = false;
					}
					ribbonFormattingTab.StylesSidebar.ContentLayout = Sidebar.SidebarContentLayout.Styles;
					ribbonFormattingTab.StylesSidebar.IsPinned = this.bool_3;
					ribbonFormattingTab.StylesSidebar.IsShown = true;
				}
				else
				{
					if (!ribbonFormattingTab.StylesSidebar.IsShown)
					{
						ribbonFormattingTab.StylesSidebar.IsPinned = this.bool_3;
					}
					ribbonFormattingTab.StylesSidebar.IsShown = !ribbonFormattingTab.StylesSidebar.IsShown;
				}
			}
			else
			{
				base.m_txTextControl.FormattingStylesDialog();
			}
		}

		private void method_128(Sidebar sidebar_0, string string_0)
		{
			if (string_0 == "IsPinned" && sidebar_0.ContentLayout == Sidebar.SidebarContentLayout.Styles)
			{
				this.bool_3 = sidebar_0.IsPinned;
			}
		}

		private void method_129(RibbonListView ribbonListView_0, RibbonListView.RibbonListViewItemEventArgs ribbonListViewItemEventArgs_0)
		{
			if (base.m_txTextControl != null)
			{
				RibbonListView ribbonListView_;
				RibbonListView.RibbonListViewItem ribbonListViewItem = this.method_62(ribbonListViewItemEventArgs_0.Item, ribbonListView_0, out ribbonListView_);
				if (this.class502_0.Control_0 is TextMiniToolbar)
				{
					this.method_19(ribbonListView_, ribbonListViewItem);
				}
				else
				{
					ribbonListView_.ScrollTo(ribbonListViewItem);
				}
				base.m_txTextControl.textControlCore_0.Enum57_0 = this.enum57_0;
				string styleName = (ribbonListViewItem.Tag as object[])[0].ToString();
				base.m_txTextControl.InputFormat.StyleName = styleName;
				base.m_txTextControl.textControlCore_0.Enum57_0 = Enum57.const_0;
			}
		}

		private void method_130()
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.Find();
			}
		}

		private void method_131(RibbonSplitButton ribbonSplitButton_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			RibbonFormattingTab ribbonFormattingTab = this.class502_0.Control_0 as RibbonFormattingTab;
			if (ribbonFormattingTab == null)
			{
				return;
			}
			if (ribbonSplitButton_0.Checked)
			{
				bool @checked = (this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Find_Sidebars_Vertical.ToString()] as RibbonToggleButton).Checked;
				bool checked2 = (this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Find_Sidebars_Horizontal.ToString()] as RibbonToggleButton).Checked;
				bool flag = ribbonFormattingTab.FindSidebar != null && @checked;
				bool flag2 = ribbonFormattingTab.FindHorizontalSidebar != null && checked2;
				if (ribbonFormattingTab.FindSidebar != null && (flag || (!ribbonFormattingTab.FindSidebar.IsShown && !flag2)))
				{
					if (ribbonFormattingTab.FindSidebar.ContentLayout != Sidebar.SidebarContentLayout.Find)
					{
						if (ribbonFormattingTab.FindSidebar.IsShown && !ribbonFormattingTab.FindSidebar.IsPinned)
						{
							ribbonFormattingTab.FindSidebar.IsShown = false;
						}
						ribbonFormattingTab.FindSidebar.ContentLayout = Sidebar.SidebarContentLayout.Find;
						this.bool_2 = false;
					}
					ribbonFormattingTab.FindSidebar.IsPinned = @checked;
					this.bool_2 = true;
					ribbonFormattingTab.FindSidebar.IsShown = true;
				}
				else if (ribbonFormattingTab.FindHorizontalSidebar != null)
				{
					if (ribbonFormattingTab.FindHorizontalSidebar.ContentLayout != Sidebar.SidebarContentLayout.Find)
					{
						if (ribbonFormattingTab.FindHorizontalSidebar.IsShown && !ribbonFormattingTab.FindHorizontalSidebar.IsPinned)
						{
							ribbonFormattingTab.FindHorizontalSidebar.IsShown = false;
						}
						ribbonFormattingTab.FindHorizontalSidebar.ContentLayout = Sidebar.SidebarContentLayout.Find;
						this.bool_2 = false;
					}
					ribbonFormattingTab.FindHorizontalSidebar.IsPinned = checked2;
					this.bool_2 = true;
					ribbonFormattingTab.FindHorizontalSidebar.IsShown = true;
				}
				else
				{
					ribbonSplitButton_0.Checked = false;
				}
			}
			else
			{
				if (ribbonFormattingTab.FindSidebar != null && ribbonFormattingTab.FindSidebar.ContentLayout == Sidebar.SidebarContentLayout.Find)
				{
					ribbonFormattingTab.FindSidebar.IsShown = false;
				}
				if (ribbonFormattingTab.FindHorizontalSidebar != null && ribbonFormattingTab.FindHorizontalSidebar.ContentLayout == Sidebar.SidebarContentLayout.Find)
				{
					ribbonFormattingTab.FindHorizontalSidebar.IsShown = false;
				}
			}
		}

		private void method_132(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			RibbonFormattingTab ribbonFormattingTab = this.class502_0.Control_0 as RibbonFormattingTab;
			switch (ribbonToggleButton_0.Name)
			{
			case "TXITEM_Find_Sidebars_Horizontal":
				if (ribbonToggleButton_0.Checked)
				{
					(this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Find_Sidebars_Vertical.ToString()] as RibbonToggleButton).Checked = false;
					if (ribbonFormattingTab.FindSidebar != null && ribbonFormattingTab.FindSidebar.ContentLayout == Sidebar.SidebarContentLayout.Find)
					{
						this.bool_1 = false;
						ribbonFormattingTab.FindSidebar.IsShown = false;
						this.bool_1 = true;
					}
					if (ribbonFormattingTab.FindHorizontalSidebar.ContentLayout != Sidebar.SidebarContentLayout.Find)
					{
						ribbonFormattingTab.FindHorizontalSidebar.ContentLayout = Sidebar.SidebarContentLayout.Find;
						this.bool_2 = false;
					}
					this.bool_1 = false;
					ribbonFormattingTab.FindHorizontalSidebar.IsPinned = true;
					this.bool_2 = true;
					this.bool_1 = true;
					ribbonFormattingTab.FindHorizontalSidebar.IsShown = true;
					(this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Find_Sidebars.ToString()] as RibbonSplitButton).Checked = true;
				}
				else
				{
					ribbonFormattingTab.FindHorizontalSidebar.IsShown = false;
				}
				break;
			case "TXITEM_Find_Sidebars_Vertical":
				if (ribbonToggleButton_0.Checked)
				{
					(this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Find_Sidebars_Horizontal.ToString()] as RibbonToggleButton).Checked = false;
					if (ribbonFormattingTab.FindHorizontalSidebar != null && ribbonFormattingTab.FindHorizontalSidebar.ContentLayout == Sidebar.SidebarContentLayout.Find)
					{
						this.bool_1 = false;
						ribbonFormattingTab.FindHorizontalSidebar.IsShown = false;
						this.bool_1 = true;
					}
					if (ribbonFormattingTab.FindSidebar.ContentLayout != Sidebar.SidebarContentLayout.Find)
					{
						ribbonFormattingTab.FindSidebar.ContentLayout = Sidebar.SidebarContentLayout.Find;
						this.bool_2 = false;
					}
					this.bool_1 = false;
					ribbonFormattingTab.FindSidebar.IsPinned = true;
					this.bool_2 = true;
					this.bool_1 = true;
					ribbonFormattingTab.FindSidebar.IsShown = true;
					(this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Find_Sidebars.ToString()] as RibbonSplitButton).Checked = true;
				}
				else
				{
					ribbonFormattingTab.FindSidebar.IsShown = false;
				}
				break;
			}
		}

		private void method_133(Sidebar sidebar_0, string string_0)
		{
			if (!this.bool_1)
			{
				return;
			}
			switch (string_0)
			{
			case "ContentLayout":
			{
				if (sidebar_0.ContentLayout == Sidebar.SidebarContentLayout.Find)
				{
					break;
				}
				if (!sidebar_0.IsPinned && sidebar_0.SidebarContentLayout_0 == Sidebar.SidebarContentLayout.Find)
				{
					this.point_1 = sidebar_0.DialogLocation;
					this.size_1 = sidebar_0.DialogSize;
				}
				RibbonSplitButton ribbonSplitButton = this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Find.ToString()] as RibbonSplitButton;
				RibbonFormattingTab ribbonFormattingTab2 = this.class502_0.Control_0 as RibbonFormattingTab;
				if (ribbonSplitButton != null && ribbonSplitButton.Name == RibbonFormattingTab.InternalRibbonItem.TXITEM_Find_Sidebars.ToString())
				{
					if (sidebar_0 == ribbonFormattingTab2.FindSidebar)
					{
						bool flag2 = ribbonFormattingTab2.FindHorizontalSidebar != null && ribbonFormattingTab2.FindHorizontalSidebar.ContentLayout == Sidebar.SidebarContentLayout.Find;
						ribbonSplitButton.Checked = flag2 && ribbonFormattingTab2.FindHorizontalSidebar.IsShown;
					}
					else if (sidebar_0 == ribbonFormattingTab2.FindHorizontalSidebar)
					{
						bool flag3 = ribbonFormattingTab2.FindSidebar != null && ribbonFormattingTab2.FindSidebar.ContentLayout == Sidebar.SidebarContentLayout.Find;
						ribbonSplitButton.Checked = flag3 && ribbonFormattingTab2.FindSidebar.IsShown;
					}
				}
				break;
			}
			case "IsShown":
			case "IsPinned":
			{
				if (sidebar_0.ContentLayout != Sidebar.SidebarContentLayout.Find)
				{
					break;
				}
				RibbonButton ribbonButton = this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Find.ToString()] as RibbonButton;
				RibbonFormattingTab ribbonFormattingTab = this.class502_0.Control_0 as RibbonFormattingTab;
				switch (string_0)
				{
				case "IsPinned":
					Class517.smethod_38(new Sidebar[3] { sidebar_0, ribbonFormattingTab.FindSidebar, ribbonFormattingTab.FindHorizontalSidebar }, RibbonFormattingTab.InternalRibbonItem.TXITEM_Find_Sidebars.ToString(), new object[3]
					{
						ribbonButton,
						this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Find_Sidebars_Vertical.ToString()],
						this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Find_Sidebars_Horizontal.ToString()]
					});
					break;
				case "IsShown":
				{
					if (!(ribbonButton.Name == RibbonFormattingTab.InternalRibbonItem.TXITEM_Find_Sidebars.ToString()))
					{
						break;
					}
					RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Find_Sidebars_Vertical.ToString()] as RibbonToggleButton;
					RibbonToggleButton ribbonToggleButton2 = this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Find_Sidebars_Horizontal.ToString()] as RibbonToggleButton;
					if (sidebar_0 == ribbonFormattingTab.FindSidebar)
					{
						if (sidebar_0.IsShown)
						{
							ribbonToggleButton.Checked = sidebar_0.IsPinned;
						}
						if (ribbonFormattingTab.FindHorizontalSidebar != null && ribbonFormattingTab.FindHorizontalSidebar.ContentLayout == Sidebar.SidebarContentLayout.Find)
						{
							this.bool_1 = false;
							ribbonFormattingTab.FindHorizontalSidebar.IsShown = false;
							this.bool_1 = true;
						}
					}
					else if (sidebar_0 == ribbonFormattingTab.FindHorizontalSidebar)
					{
						if (sidebar_0.IsShown)
						{
							ribbonToggleButton2.Checked = sidebar_0.IsPinned;
						}
						if (ribbonFormattingTab.FindSidebar != null && ribbonFormattingTab.FindSidebar.ContentLayout == Sidebar.SidebarContentLayout.Find)
						{
							this.bool_1 = false;
							ribbonFormattingTab.FindSidebar.IsShown = false;
							this.bool_1 = true;
						}
					}
					bool flag = ((ribbonButton as RibbonSplitButton).Checked = sidebar_0.IsShown);
					if (!flag && !sidebar_0.IsPinned)
					{
						this.point_1 = sidebar_0.DialogLocation;
						this.size_1 = sidebar_0.DialogSize;
					}
					break;
				}
				}
				break;
			}
			}
		}

		private void method_134()
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.Replace();
			}
		}

		private void method_135(RibbonSplitButton ribbonSplitButton_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			RibbonFormattingTab ribbonFormattingTab = this.class502_0.Control_0 as RibbonFormattingTab;
			if (ribbonFormattingTab == null)
			{
				return;
			}
			if (ribbonSplitButton_0.Checked)
			{
				bool @checked = (this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Replace_Sidebars_Vertical.ToString()] as RibbonToggleButton).Checked;
				bool checked2 = (this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Replace_Sidebars_Horizontal.ToString()] as RibbonToggleButton).Checked;
				bool flag = ribbonFormattingTab.ReplaceSidebar != null && @checked;
				bool flag2 = ribbonFormattingTab.ReplaceHorizontalSidebar != null && checked2;
				if (ribbonFormattingTab.ReplaceSidebar != null && (flag || (!ribbonFormattingTab.ReplaceSidebar.IsShown && !flag2)))
				{
					if (ribbonFormattingTab.ReplaceSidebar.ContentLayout != Sidebar.SidebarContentLayout.Replace)
					{
						if (ribbonFormattingTab.ReplaceSidebar.IsShown && !ribbonFormattingTab.ReplaceSidebar.IsPinned)
						{
							ribbonFormattingTab.ReplaceSidebar.IsShown = false;
						}
						ribbonFormattingTab.ReplaceSidebar.ContentLayout = Sidebar.SidebarContentLayout.Replace;
						this.bool_2 = false;
					}
					ribbonFormattingTab.ReplaceSidebar.IsPinned = @checked;
					this.bool_2 = true;
					ribbonFormattingTab.ReplaceSidebar.IsShown = true;
				}
				else if (ribbonFormattingTab.ReplaceHorizontalSidebar != null)
				{
					if (ribbonFormattingTab.ReplaceHorizontalSidebar.ContentLayout != Sidebar.SidebarContentLayout.Replace)
					{
						if (ribbonFormattingTab.ReplaceHorizontalSidebar.IsShown && !ribbonFormattingTab.ReplaceHorizontalSidebar.IsPinned)
						{
							ribbonFormattingTab.ReplaceHorizontalSidebar.IsShown = false;
						}
						ribbonFormattingTab.ReplaceHorizontalSidebar.ContentLayout = Sidebar.SidebarContentLayout.Replace;
						this.bool_2 = false;
					}
					ribbonFormattingTab.ReplaceHorizontalSidebar.IsPinned = checked2;
					this.bool_2 = true;
					ribbonFormattingTab.ReplaceHorizontalSidebar.IsShown = true;
				}
				else
				{
					ribbonSplitButton_0.Checked = false;
				}
			}
			else
			{
				if (ribbonFormattingTab.ReplaceSidebar != null && ribbonFormattingTab.ReplaceSidebar.ContentLayout == Sidebar.SidebarContentLayout.Replace)
				{
					ribbonFormattingTab.ReplaceSidebar.IsShown = false;
				}
				if (ribbonFormattingTab.ReplaceHorizontalSidebar != null && ribbonFormattingTab.ReplaceHorizontalSidebar.ContentLayout == Sidebar.SidebarContentLayout.Replace)
				{
					ribbonFormattingTab.ReplaceHorizontalSidebar.IsShown = false;
				}
			}
		}

		private void method_136(Sidebar sidebar_0, string string_0)
		{
			if (!this.bool_1)
			{
				return;
			}
			switch (string_0)
			{
			case "ContentLayout":
			{
				if (sidebar_0.ContentLayout == Sidebar.SidebarContentLayout.Replace)
				{
					break;
				}
				if (!sidebar_0.IsPinned && sidebar_0.SidebarContentLayout_0 == Sidebar.SidebarContentLayout.Replace)
				{
					this.point_2 = sidebar_0.DialogLocation;
					this.size_2 = sidebar_0.DialogSize;
				}
				RibbonSplitButton ribbonSplitButton = this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Replace.ToString()] as RibbonSplitButton;
				RibbonFormattingTab ribbonFormattingTab2 = this.class502_0.Control_0 as RibbonFormattingTab;
				if (ribbonSplitButton != null && ribbonSplitButton.Name == RibbonFormattingTab.InternalRibbonItem.TXITEM_Replace_Sidebars.ToString())
				{
					if (sidebar_0 == ribbonFormattingTab2.ReplaceSidebar)
					{
						bool flag2 = ribbonFormattingTab2.ReplaceHorizontalSidebar != null && ribbonFormattingTab2.ReplaceHorizontalSidebar.ContentLayout == Sidebar.SidebarContentLayout.Replace;
						ribbonSplitButton.Checked = flag2 && ribbonFormattingTab2.ReplaceHorizontalSidebar.IsShown;
					}
					else if (sidebar_0 == ribbonFormattingTab2.ReplaceHorizontalSidebar)
					{
						bool flag3 = ribbonFormattingTab2.ReplaceSidebar != null && ribbonFormattingTab2.ReplaceSidebar.ContentLayout == Sidebar.SidebarContentLayout.Replace;
						ribbonSplitButton.Checked = flag3 && ribbonFormattingTab2.ReplaceSidebar.IsShown;
					}
				}
				break;
			}
			case "IsShown":
			case "IsPinned":
			{
				if (sidebar_0.ContentLayout != Sidebar.SidebarContentLayout.Replace)
				{
					break;
				}
				RibbonButton ribbonButton = this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Replace.ToString()] as RibbonButton;
				RibbonFormattingTab ribbonFormattingTab = this.class502_0.Control_0 as RibbonFormattingTab;
				switch (string_0)
				{
				case "IsPinned":
					Class517.smethod_38(new Sidebar[3] { sidebar_0, ribbonFormattingTab.ReplaceSidebar, ribbonFormattingTab.ReplaceHorizontalSidebar }, RibbonFormattingTab.InternalRibbonItem.TXITEM_Replace_Sidebars.ToString(), new object[3]
					{
						ribbonButton,
						this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Replace_Sidebars_Vertical.ToString()],
						this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Replace_Sidebars_Horizontal.ToString()]
					});
					break;
				case "IsShown":
				{
					if (!(ribbonButton.Name == RibbonFormattingTab.InternalRibbonItem.TXITEM_Replace_Sidebars.ToString()))
					{
						break;
					}
					RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Replace_Sidebars_Vertical.ToString()] as RibbonToggleButton;
					RibbonToggleButton ribbonToggleButton2 = this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Replace_Sidebars_Horizontal.ToString()] as RibbonToggleButton;
					if (sidebar_0 == ribbonFormattingTab.ReplaceSidebar)
					{
						if (sidebar_0.IsShown)
						{
							ribbonToggleButton.Checked = sidebar_0.IsPinned;
						}
						if (ribbonFormattingTab.ReplaceHorizontalSidebar != null && ribbonFormattingTab.ReplaceHorizontalSidebar.ContentLayout == Sidebar.SidebarContentLayout.Replace)
						{
							this.bool_1 = false;
							ribbonFormattingTab.ReplaceHorizontalSidebar.IsShown = false;
							this.bool_1 = true;
						}
					}
					else if (sidebar_0 == ribbonFormattingTab.ReplaceHorizontalSidebar)
					{
						if (sidebar_0.IsShown)
						{
							ribbonToggleButton2.Checked = sidebar_0.IsPinned;
						}
						if (ribbonFormattingTab.ReplaceSidebar != null && ribbonFormattingTab.ReplaceSidebar.ContentLayout == Sidebar.SidebarContentLayout.Replace)
						{
							this.bool_1 = false;
							ribbonFormattingTab.ReplaceSidebar.IsShown = false;
							this.bool_1 = true;
						}
					}
					bool flag = ((ribbonButton as RibbonSplitButton).Checked = sidebar_0.IsShown);
					if (!flag && !sidebar_0.IsPinned)
					{
						this.point_2 = sidebar_0.DialogLocation;
						this.size_2 = sidebar_0.DialogSize;
					}
					break;
				}
				}
				break;
			}
			}
		}

		private void method_137(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			RibbonFormattingTab ribbonFormattingTab = this.class502_0.Control_0 as RibbonFormattingTab;
			switch (ribbonToggleButton_0.Name)
			{
			case "TXITEM_Replace_Sidebars_Horizontal":
				if (ribbonToggleButton_0.Checked)
				{
					(this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Replace_Sidebars_Vertical.ToString()] as RibbonToggleButton).Checked = false;
					if (ribbonFormattingTab.ReplaceSidebar != null && ribbonFormattingTab.ReplaceSidebar.ContentLayout == Sidebar.SidebarContentLayout.Replace)
					{
						this.bool_1 = false;
						ribbonFormattingTab.ReplaceSidebar.IsShown = false;
						this.bool_1 = true;
					}
					if (ribbonFormattingTab.ReplaceHorizontalSidebar.ContentLayout != Sidebar.SidebarContentLayout.Replace)
					{
						ribbonFormattingTab.ReplaceHorizontalSidebar.ContentLayout = Sidebar.SidebarContentLayout.Replace;
						this.bool_2 = false;
					}
					this.bool_1 = false;
					ribbonFormattingTab.ReplaceHorizontalSidebar.IsPinned = true;
					this.bool_2 = true;
					this.bool_1 = true;
					ribbonFormattingTab.ReplaceHorizontalSidebar.IsShown = true;
					(this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Replace_Sidebars.ToString()] as RibbonSplitButton).Checked = true;
				}
				else
				{
					ribbonFormattingTab.ReplaceHorizontalSidebar.IsShown = false;
				}
				break;
			case "TXITEM_Replace_Sidebars_Vertical":
				if (ribbonToggleButton_0.Checked)
				{
					(this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Replace_Sidebars_Horizontal.ToString()] as RibbonToggleButton).Checked = false;
					if (ribbonFormattingTab.ReplaceHorizontalSidebar != null && ribbonFormattingTab.ReplaceHorizontalSidebar.ContentLayout == Sidebar.SidebarContentLayout.Replace)
					{
						this.bool_1 = false;
						ribbonFormattingTab.ReplaceHorizontalSidebar.IsShown = false;
						this.bool_1 = true;
					}
					if (ribbonFormattingTab.ReplaceSidebar.ContentLayout != Sidebar.SidebarContentLayout.Replace)
					{
						ribbonFormattingTab.ReplaceSidebar.ContentLayout = Sidebar.SidebarContentLayout.Replace;
						this.bool_2 = false;
					}
					this.bool_1 = false;
					ribbonFormattingTab.ReplaceSidebar.IsPinned = true;
					this.bool_2 = true;
					this.bool_1 = true;
					ribbonFormattingTab.ReplaceSidebar.IsShown = true;
					(this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Replace_Sidebars.ToString()] as RibbonSplitButton).Checked = true;
				}
				else
				{
					ribbonFormattingTab.ReplaceSidebar.IsShown = false;
				}
				break;
			}
		}

		private void method_138()
		{
			if (base.m_txTextControl != null)
			{
				if (this.gotoDialog_0 == null)
				{
					this.gotoDialog_0 = new GotoDialog(base.m_txTextControl);
					this.gotoDialog_0.Closed += gotoDialog_0_Closed;
					this.gotoDialog_0.Show(base.m_txTextControl);
				}
				else
				{
					this.gotoDialog_0.Focus();
				}
			}
		}

		private void method_139()
		{
			this.gotoDialog_0 = null;
		}

		private void method_140(RibbonSplitButton ribbonSplitButton_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			RibbonFormattingTab ribbonFormattingTab = this.class502_0.Control_0 as RibbonFormattingTab;
			if (ribbonFormattingTab == null)
			{
				return;
			}
			if (ribbonSplitButton_0.Checked)
			{
				bool @checked = (this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Goto_Sidebars_Vertical.ToString()] as RibbonToggleButton).Checked;
				bool checked2 = (this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Goto_Sidebars_Horizontal.ToString()] as RibbonToggleButton).Checked;
				bool flag = ribbonFormattingTab.GotoSidebar != null && @checked;
				bool flag2 = ribbonFormattingTab.GotoHorizontalSidebar != null && checked2;
				if (ribbonFormattingTab.GotoSidebar != null && (flag || (!ribbonFormattingTab.GotoSidebar.IsShown && !flag2)))
				{
					if (ribbonFormattingTab.GotoSidebar.ContentLayout != Sidebar.SidebarContentLayout.Goto)
					{
						if (ribbonFormattingTab.GotoSidebar.IsShown && !ribbonFormattingTab.GotoSidebar.IsPinned)
						{
							ribbonFormattingTab.GotoSidebar.IsShown = false;
						}
						ribbonFormattingTab.GotoSidebar.ContentLayout = Sidebar.SidebarContentLayout.Goto;
						this.bool_2 = false;
					}
					ribbonFormattingTab.GotoSidebar.IsPinned = @checked;
					this.bool_2 = true;
					ribbonFormattingTab.GotoSidebar.IsShown = true;
				}
				else if (ribbonFormattingTab.GotoHorizontalSidebar != null)
				{
					if (ribbonFormattingTab.GotoHorizontalSidebar.ContentLayout != Sidebar.SidebarContentLayout.Goto)
					{
						if (ribbonFormattingTab.GotoHorizontalSidebar.IsShown && !ribbonFormattingTab.GotoHorizontalSidebar.IsPinned)
						{
							ribbonFormattingTab.GotoHorizontalSidebar.IsShown = false;
						}
						ribbonFormattingTab.GotoHorizontalSidebar.ContentLayout = Sidebar.SidebarContentLayout.Goto;
						this.bool_2 = false;
					}
					ribbonFormattingTab.GotoHorizontalSidebar.IsPinned = checked2;
					this.bool_2 = true;
					ribbonFormattingTab.GotoHorizontalSidebar.IsShown = true;
				}
				else
				{
					ribbonSplitButton_0.Checked = false;
				}
			}
			else
			{
				if (ribbonFormattingTab.GotoSidebar != null && ribbonFormattingTab.GotoSidebar.ContentLayout == Sidebar.SidebarContentLayout.Goto)
				{
					ribbonFormattingTab.GotoSidebar.IsShown = false;
				}
				if (ribbonFormattingTab.GotoHorizontalSidebar != null && ribbonFormattingTab.GotoHorizontalSidebar.ContentLayout == Sidebar.SidebarContentLayout.Goto)
				{
					ribbonFormattingTab.GotoHorizontalSidebar.IsShown = false;
				}
			}
		}

		private void method_141(Sidebar sidebar_0, string string_0)
		{
			if (!this.bool_1)
			{
				return;
			}
			switch (string_0)
			{
			case "ContentLayout":
			{
				if (sidebar_0.ContentLayout == Sidebar.SidebarContentLayout.Goto)
				{
					break;
				}
				if (!sidebar_0.IsPinned && sidebar_0.SidebarContentLayout_0 == Sidebar.SidebarContentLayout.Goto)
				{
					this.point_0 = sidebar_0.DialogLocation;
					this.size_0 = sidebar_0.DialogSize;
				}
				RibbonSplitButton ribbonSplitButton = this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Goto.ToString()] as RibbonSplitButton;
				RibbonFormattingTab ribbonFormattingTab2 = this.class502_0.Control_0 as RibbonFormattingTab;
				if (ribbonSplitButton != null && ribbonSplitButton.Name == RibbonFormattingTab.InternalRibbonItem.TXITEM_Goto_Sidebars.ToString())
				{
					if (sidebar_0 == ribbonFormattingTab2.GotoSidebar)
					{
						bool flag2 = ribbonFormattingTab2.GotoHorizontalSidebar != null && ribbonFormattingTab2.GotoHorizontalSidebar.ContentLayout == Sidebar.SidebarContentLayout.Goto;
						ribbonSplitButton.Checked = flag2 && ribbonFormattingTab2.GotoHorizontalSidebar.IsShown;
					}
					else if (sidebar_0 == ribbonFormattingTab2.GotoHorizontalSidebar)
					{
						bool flag3 = ribbonFormattingTab2.GotoSidebar != null && ribbonFormattingTab2.GotoSidebar.ContentLayout == Sidebar.SidebarContentLayout.Goto;
						ribbonSplitButton.Checked = flag3 && ribbonFormattingTab2.GotoSidebar.IsShown;
					}
				}
				break;
			}
			case "IsShown":
			case "IsPinned":
			{
				if (sidebar_0.ContentLayout != Sidebar.SidebarContentLayout.Goto)
				{
					break;
				}
				RibbonButton ribbonButton = this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Goto.ToString()] as RibbonButton;
				RibbonFormattingTab ribbonFormattingTab = this.class502_0.Control_0 as RibbonFormattingTab;
				switch (string_0)
				{
				case "IsPinned":
					Class517.smethod_38(new Sidebar[3] { sidebar_0, ribbonFormattingTab.GotoSidebar, ribbonFormattingTab.GotoHorizontalSidebar }, RibbonFormattingTab.InternalRibbonItem.TXITEM_Goto_Sidebars.ToString(), new object[3]
					{
						ribbonButton,
						this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Goto_Sidebars_Vertical.ToString()],
						this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Goto_Sidebars_Horizontal.ToString()]
					});
					break;
				case "IsShown":
				{
					if (!(ribbonButton.Name == RibbonFormattingTab.InternalRibbonItem.TXITEM_Goto_Sidebars.ToString()))
					{
						break;
					}
					RibbonToggleButton ribbonToggleButton = this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Goto_Sidebars_Vertical.ToString()] as RibbonToggleButton;
					RibbonToggleButton ribbonToggleButton2 = this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Goto_Sidebars_Horizontal.ToString()] as RibbonToggleButton;
					if (sidebar_0 == ribbonFormattingTab.GotoSidebar)
					{
						if (sidebar_0.IsShown)
						{
							ribbonToggleButton.Checked = sidebar_0.IsPinned;
						}
						if (ribbonFormattingTab.GotoHorizontalSidebar != null && ribbonFormattingTab.GotoHorizontalSidebar.ContentLayout == Sidebar.SidebarContentLayout.Goto)
						{
							this.bool_1 = false;
							ribbonFormattingTab.GotoHorizontalSidebar.IsShown = false;
							this.bool_1 = true;
						}
					}
					else if (sidebar_0 == ribbonFormattingTab.GotoHorizontalSidebar)
					{
						if (sidebar_0.IsShown)
						{
							ribbonToggleButton2.Checked = sidebar_0.IsPinned;
						}
						if (ribbonFormattingTab.GotoSidebar != null && ribbonFormattingTab.GotoSidebar.ContentLayout == Sidebar.SidebarContentLayout.Goto)
						{
							this.bool_1 = false;
							ribbonFormattingTab.GotoSidebar.IsShown = false;
							this.bool_1 = true;
						}
					}
					bool flag = ((ribbonButton as RibbonSplitButton).Checked = sidebar_0.IsShown);
					if (!flag && !sidebar_0.IsPinned)
					{
						this.point_0 = sidebar_0.DialogLocation;
						this.size_0 = sidebar_0.DialogSize;
					}
					break;
				}
				}
				break;
			}
			}
		}

		private void method_142(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			RibbonFormattingTab ribbonFormattingTab = this.class502_0.Control_0 as RibbonFormattingTab;
			switch (ribbonToggleButton_0.Name)
			{
			case "TXITEM_Goto_Sidebars_Horizontal":
				if (ribbonToggleButton_0.Checked)
				{
					(this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Goto_Sidebars_Vertical.ToString()] as RibbonToggleButton).Checked = false;
					if (ribbonFormattingTab.GotoSidebar != null && ribbonFormattingTab.GotoSidebar.ContentLayout == Sidebar.SidebarContentLayout.Goto)
					{
						this.bool_1 = false;
						ribbonFormattingTab.GotoSidebar.IsShown = false;
						this.bool_1 = true;
					}
					if (ribbonFormattingTab.GotoHorizontalSidebar.ContentLayout != Sidebar.SidebarContentLayout.Goto)
					{
						ribbonFormattingTab.GotoHorizontalSidebar.ContentLayout = Sidebar.SidebarContentLayout.Goto;
						this.bool_2 = false;
					}
					this.bool_1 = false;
					ribbonFormattingTab.GotoHorizontalSidebar.IsPinned = true;
					this.bool_2 = true;
					this.bool_1 = true;
					ribbonFormattingTab.GotoHorizontalSidebar.IsShown = true;
					(this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Goto_Sidebars.ToString()] as RibbonSplitButton).Checked = true;
				}
				else
				{
					ribbonFormattingTab.GotoHorizontalSidebar.IsShown = false;
				}
				break;
			case "TXITEM_Goto_Sidebars_Vertical":
				if (ribbonToggleButton_0.Checked)
				{
					(this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Goto_Sidebars_Horizontal.ToString()] as RibbonToggleButton).Checked = false;
					if (ribbonFormattingTab.GotoHorizontalSidebar != null && ribbonFormattingTab.GotoHorizontalSidebar.ContentLayout == Sidebar.SidebarContentLayout.Goto)
					{
						this.bool_1 = false;
						ribbonFormattingTab.GotoHorizontalSidebar.IsShown = false;
						this.bool_1 = true;
					}
					if (ribbonFormattingTab.GotoSidebar.ContentLayout != Sidebar.SidebarContentLayout.Goto)
					{
						ribbonFormattingTab.GotoSidebar.ContentLayout = Sidebar.SidebarContentLayout.Goto;
						this.bool_2 = false;
					}
					this.bool_1 = false;
					ribbonFormattingTab.GotoSidebar.IsPinned = true;
					this.bool_2 = true;
					this.bool_1 = true;
					ribbonFormattingTab.GotoSidebar.IsShown = true;
					(this.class502_0.TXITEM_EditingGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Goto_Sidebars.ToString()] as RibbonSplitButton).Checked = true;
				}
				else
				{
					ribbonFormattingTab.GotoSidebar.IsShown = false;
				}
				break;
			}
		}

		private void method_143(Sidebar sidebar_0)
		{
			switch (sidebar_0.ContentLayout)
			{
			case Sidebar.SidebarContentLayout.Goto:
				Class517.smethod_39(sidebar_0, this.point_0, this.size_0, bool_0: false);
				break;
			case Sidebar.SidebarContentLayout.Styles:
				Class517.smethod_39(sidebar_0, this.point_3, this.size_3, bool_0: true);
				break;
			case Sidebar.SidebarContentLayout.FieldNavigator:
			case Sidebar.SidebarContentLayout.TrackedChanges:
				break;
			case Sidebar.SidebarContentLayout.Find:
				Class517.smethod_39(sidebar_0, this.point_1, this.size_1, bool_0: false);
				break;
			case Sidebar.SidebarContentLayout.Replace:
				Class517.smethod_39(sidebar_0, this.point_2, this.size_2, bool_0: false);
				break;
			}
		}

		private void method_144(Sidebar sidebar_0)
		{
			switch (sidebar_0.ContentLayout)
			{
			case Sidebar.SidebarContentLayout.Goto:
				if (this.bool_2)
				{
					this.point_0 = sidebar_0.DialogLocation;
					this.size_0 = sidebar_0.DialogSize;
				}
				break;
			case Sidebar.SidebarContentLayout.Styles:
				if (this.bool_2)
				{
					this.point_3 = sidebar_0.DialogLocation;
					this.size_3 = sidebar_0.DialogSize;
				}
				break;
			case Sidebar.SidebarContentLayout.Find:
				if (this.bool_2)
				{
					this.point_1 = sidebar_0.DialogLocation;
					this.size_1 = sidebar_0.DialogSize;
				}
				break;
			case Sidebar.SidebarContentLayout.Replace:
				if (this.bool_2)
				{
					this.point_2 = sidebar_0.DialogLocation;
					this.size_2 = sidebar_0.DialogSize;
				}
				break;
			case Sidebar.SidebarContentLayout.FieldNavigator:
			case Sidebar.SidebarContentLayout.TrackedChanges:
				break;
			}
		}

		private void method_145()
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.SelectAll();
			}
		}

		private void method_146(bool bool_4)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.SelectObjects = bool_4;
			}
		}

		private void method_147(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				switch (ribbonToggleButton_0.Name)
				{
				case "TXITEM_FrameLineColor_Automatic":
					base.m_txTextControl.InputFormat.FrameLineColor = SystemColors.WindowText;
					break;
				case "TXITEM_BackColor_Transparent":
					base.m_txTextControl.InputFormat.FrameFillColor = Color.Transparent;
					break;
				case "TXITEM_TextColor_Automatic":
					base.m_txTextControl.textControlCore_0.Enum57_0 = this.enum57_0;
					base.m_txTextControl.InputFormat.TextColor = SystemColors.WindowText;
					base.m_txTextControl.textControlCore_0.Enum57_0 = Enum57.const_0;
					break;
				case "TXITEM_TextBackColor_Transparent":
					base.m_txTextControl.textControlCore_0.Enum57_0 = this.enum57_0;
					base.m_txTextControl.InputFormat.TextBackColor = Color.Transparent;
					base.m_txTextControl.textControlCore_0.Enum57_0 = Enum57.const_0;
					break;
				}
				ribbonToggleButton_0.Checked = true;
			}
		}

		private void method_148(RibbonListView ribbonListView_0, RibbonListView.RibbonListViewItemEventArgs ribbonListViewItemEventArgs_0)
		{
			if (base.m_txTextControl != null)
			{
				switch (ribbonListView_0.Name)
				{
				case "TXITEM_TextColor_Gallery":
					base.m_txTextControl.textControlCore_0.Enum57_0 = this.enum57_0;
					base.m_txTextControl.InputFormat.TextColor = (Color)ribbonListViewItemEventArgs_0.Item.Tag;
					base.m_txTextControl.textControlCore_0.Enum57_0 = Enum57.const_0;
					break;
				case "TXITEM_TextBackColor_Gallery":
					base.m_txTextControl.textControlCore_0.Enum57_0 = this.enum57_0;
					base.m_txTextControl.InputFormat.TextBackColor = (Color)ribbonListViewItemEventArgs_0.Item.Tag;
					base.m_txTextControl.textControlCore_0.Enum57_0 = Enum57.const_0;
					break;
				case "TXITEM_FrameLineColor_Gallery":
					base.m_txTextControl.InputFormat.FrameLineColor = (Color)ribbonListViewItemEventArgs_0.Item.Tag;
					break;
				case "TXITEM_BackColor_Gallery":
					base.m_txTextControl.InputFormat.FrameFillColor = (Color)ribbonListViewItemEventArgs_0.Item.Tag;
					break;
				}
			}
		}

		private void method_149(RibbonButton ribbonButton_0)
		{
			if (base.m_txTextControl != null)
			{
				switch (ribbonButton_0.Name)
				{
				case "TXITEM_FrameLineColor_MoreColors":
					base.m_txTextControl.FrameLineColorDialog();
					break;
				case "TXITEM_BackColor_MoreColors":
					base.m_txTextControl.FrameFillColorDialog();
					break;
				case "TXITEM_TextColor_MoreColors":
					base.m_txTextControl.textControlCore_0.Enum57_0 = this.enum57_0;
					base.m_txTextControl.ForeColorDialog();
					base.m_txTextControl.textControlCore_0.Enum57_0 = Enum57.const_0;
					break;
				case "TXITEM_TextBackColor_MoreColors":
					base.m_txTextControl.textControlCore_0.Enum57_0 = this.enum57_0;
					base.m_txTextControl.TextBackColorDialog();
					base.m_txTextControl.textControlCore_0.Enum57_0 = Enum57.const_0;
					break;
				}
			}
		}

		private void method_150(RibbonMenuButton ribbonMenuButton_0)
		{
			if (this.bool_0)
			{
				return;
			}
			this.bool_0 = true;
			foreach (Control dropDownItem in ribbonMenuButton_0.DropDownItems)
			{
				if (dropDownItem.Name == TextMiniToolbar.InternalRibbonItem.TXITEM_StyleNameGallery.ToString())
				{
					(dropDownItem as RibbonListView).ItemClick += method_167;
					base.m_txTextControl.InputFormat.StyleNamesChanged += method_241;
					this.method_20(PointF.Empty);
					base.m_txTextControl.InputFormat.StyleNameChanged += method_242;
					this.method_18();
					break;
				}
			}
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_Paste_Handler(object sender, EventArgs e)
		{
			this.method_75();
		}

		private void method_151(object sender, EventArgs e)
		{
			this.method_76(sender as RibbonSplitButton);
		}

		private void method_152(object sender, EventArgs e)
		{
			this.method_77(sender as RibbonButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_Cut_Handler(object sender, EventArgs e)
		{
			this.method_78();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_Copy_Handler(object sender, EventArgs e)
		{
			this.method_79();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_FontGroup_Handler(object sender, EventArgs e)
		{
			this.method_80();
		}

		private void method_153(object sender, KeyEventArgs e)
		{
			this.method_81(sender as RibbonComboBox, e.KeyData);
		}

		private void method_154(object sender, EventArgs e)
		{
			this.method_82((sender as RibbonComboBox).SelectedItem.ToString());
		}

		private void method_155(object sender, EventArgs e)
		{
			this.method_83(sender as RibbonComboBox);
		}

		private void method_156(object sender, KeyEventArgs e)
		{
			this.method_84(sender as RibbonComboBox, e.KeyData);
		}

		private void method_157(object sender, EventArgs e)
		{
			this.method_85(sender as RibbonComboBox);
		}

		private void method_158(object sender, EventArgs e)
		{
			this.method_86(sender as RibbonComboBox);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_IncreaseFont_Handler(object sender, EventArgs e)
		{
			this.method_87();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_DecreaseFont_Handler(object sender, EventArgs e)
		{
			this.method_88();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_ClearFormatting_Handler(object sender, EventArgs e)
		{
			this.method_89();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_Bold_Handler(object sender, EventArgs e)
		{
			this.method_90((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_Italic_Handler(object sender, EventArgs e)
		{
			this.method_91((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_Underline_Handler(object sender, EventArgs e)
		{
			this.method_92((sender as RibbonSplitButton).Checked);
		}

		private void method_159(object sender, EventArgs e)
		{
			this.method_93(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_Strikeout_Handler(object sender, EventArgs e)
		{
			this.method_94((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_Subscript_Handler(object sender, EventArgs e)
		{
			this.method_95((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_Superscript_Handler(object sender, EventArgs e)
		{
			this.method_96((sender as RibbonToggleButton).Checked);
		}

		private void method_160(object sender, EventArgs e)
		{
			this.method_97(sender as RibbonButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_ParagraphGroup_Handler(object sender, EventArgs e)
		{
			this.method_98();
		}

		private void method_161(object sender, EventArgs e)
		{
			this.method_99(sender as RibbonSplitButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_BulletedList_Handler(object sender, EventArgs e)
		{
			this.method_100((sender as RibbonSplitButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_NumberedList_Handler(object sender, EventArgs e)
		{
			this.method_101((sender as RibbonSplitButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_StructuredList_Handler(object sender, EventArgs e)
		{
			this.method_102((sender as RibbonSplitButton).Checked);
		}

		private void method_162(object sender, RibbonListView.RibbonListViewItemEventArgs e)
		{
			this.method_103(sender as RibbonListView, e);
		}

		private void method_163(object sender, EventArgs e)
		{
			this.method_104();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_DecreaseIndent_Handler(object sender, EventArgs e)
		{
			this.method_105();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_IncreaseIndent_Handler(object sender, EventArgs e)
		{
			this.method_106();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_LeftToRight_Handler(object sender, EventArgs e)
		{
			this.method_107(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_RightToLeft_Handler(object sender, EventArgs e)
		{
			this.method_108(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_EditTabs_Handler(object sender, EventArgs e)
		{
			this.method_109();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_ControlChars_Handler(object sender, EventArgs e)
		{
			this.method_110((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_LeftAligned_Handler(object sender, EventArgs e)
		{
			this.method_111(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_Centered_Handler(object sender, EventArgs e)
		{
			this.method_112(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_RightAligned_Handler(object sender, EventArgs e)
		{
			this.method_113(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_Justified_Handler(object sender, EventArgs e)
		{
			this.method_114(sender as RibbonToggleButton);
		}

		private void method_164(object sender, EventArgs e)
		{
			this.method_115(sender as RibbonMenuButton);
		}

		private void method_165(object sender, EventArgs e)
		{
			this.method_116(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_Borders_Handler(object sender, EventArgs e)
		{
			this.method_117();
		}

		[Obfuscation(Exclude = true)]
		protected void TXITEM_LeftFrameLine_Handler(object sender, EventArgs e)
		{
			this.method_118((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		protected void TXITEM_TopFrameLine_Handler(object sender, EventArgs e)
		{
			this.method_119((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		protected void TXITEM_RightFrameLine_Handler(object sender, EventArgs e)
		{
			this.method_120((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		protected void TXITEM_BottomFrameLine_Handler(object sender, EventArgs e)
		{
			this.method_121((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		protected void TXITEM_BoxFrame_Handler(object sender, EventArgs e)
		{
			this.method_122((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		protected void TXITEM_AllFrameLines_Handler(object sender, EventArgs e)
		{
			this.method_123((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		protected void TXITEM_InnerHorizontalFrameLines_Handler(object sender, EventArgs e)
		{
			this.method_124((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		protected void TXITEM_InnerVerticalFrameLines_Handler(object sender, EventArgs e)
		{
			this.method_125((sender as RibbonToggleButton).Checked);
		}

		protected override void LineWidthItem_Click(object sender, EventArgs e)
		{
			this.method_126(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_StylesGroup_Handler(object sender, EventArgs e)
		{
			this.method_127();
		}

		private void method_166(object sender, PropertyChangedEventArgs e)
		{
			this.method_128(sender as Sidebar, e.PropertyName);
		}

		private void method_167(object sender, RibbonListView.RibbonListViewItemEventArgs e)
		{
			this.method_129(sender as RibbonListView, e);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_Find_Handler(object sender, EventArgs e)
		{
			this.method_130();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_Find_Sidebars_Handler(object sender, EventArgs e)
		{
			this.method_131(sender as RibbonSplitButton);
		}

		private void method_168(object sender, PropertyChangedEventArgs e)
		{
			this.method_133(sender as Sidebar, e.PropertyName);
		}

		private void method_169(object sender, EventArgs e)
		{
			this.method_132(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_Replace_Handler(object sender, EventArgs e)
		{
			this.method_134();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_Replace_Sidebars_Handler(object sender, EventArgs e)
		{
			this.method_135(sender as RibbonSplitButton);
		}

		private void method_170(object sender, PropertyChangedEventArgs e)
		{
			this.method_136(sender as Sidebar, e.PropertyName);
		}

		private void method_171(object sender, EventArgs e)
		{
			this.method_137(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_Goto_Handler(object sender, EventArgs e)
		{
			this.method_138();
		}

		private void gotoDialog_0_Closed(object sender, EventArgs e)
		{
			this.method_139();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_Goto_Sidebars_Handler(object sender, EventArgs e)
		{
			this.method_140(sender as RibbonSplitButton);
		}

		private void method_172(object sender, PropertyChangedEventArgs e)
		{
			this.method_141(sender as Sidebar, e.PropertyName);
		}

		private void method_173(object sender, EventArgs e)
		{
			this.method_142(sender as RibbonToggleButton);
		}

		private void method_174(object sender, EventArgs e)
		{
			this.method_143(sender as Sidebar);
		}

		private void method_175(object sender, EventArgs e)
		{
			this.method_144(sender as Sidebar);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_SelectAll_Handler(object sender, EventArgs e)
		{
			this.method_145();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_SelectObjects_Handler(object sender, EventArgs e)
		{
			this.method_146((sender as RibbonToggleButton).Checked);
		}

		protected override void DefaultColorButton_Click(object sender, EventArgs e)
		{
			this.method_147(sender as RibbonToggleButton);
		}

		protected override void ColorListView_ItemClick(object sender, RibbonListView.RibbonListViewItemEventArgs e)
		{
			this.method_148(sender as RibbonListView, e);
		}

		protected override void MoreColorsButton_Click(object sender, EventArgs e)
		{
			this.method_149(sender as RibbonButton);
		}

		private void method_176(object sender, EventArgs e)
		{
			this.method_150(sender as RibbonMenuButton);
		}

		private void method_177()
		{
			this.method_27();
		}

		private void method_178()
		{
			this.method_28();
		}

		private void method_179()
		{
			this.method_29();
		}

		private void method_180()
		{
			this.method_30();
		}

		private void method_181()
		{
			this.method_31();
		}

		private void method_182()
		{
			this.method_32();
		}

		private void method_183()
		{
			this.method_33();
		}

		private void method_184()
		{
			this.method_34();
		}

		private void method_185()
		{
			this.method_35();
		}

		private void method_186()
		{
			this.method_36();
		}

		private void method_187()
		{
			this.method_37();
		}

		private void method_188()
		{
			this.method_38();
		}

		private void method_189()
		{
			this.method_39();
		}

		private void method_190()
		{
			this.method_40();
		}

		private void method_191()
		{
			this.method_41();
		}

		private void method_192()
		{
			this.method_42();
		}

		private void method_193()
		{
			this.method_44();
		}

		private void method_194()
		{
			this.method_45();
		}

		private void method_195()
		{
			this.method_46();
		}

		private void method_196()
		{
			this.method_47();
		}

		private void method_197()
		{
			this.method_49();
		}

		private void method_198()
		{
			this.method_50();
		}

		private void method_199()
		{
			this.method_51();
		}

		private void method_200()
		{
			this.method_52();
		}

		private void method_201()
		{
			this.method_53();
		}

		private void method_202()
		{
			this.method_54();
		}

		private void method_203()
		{
			this.method_55();
		}

		private void method_204()
		{
			this.method_56();
		}

		private void method_205()
		{
			this.method_57();
		}

		private void method_206()
		{
			this.method_58();
		}

		private void method_207()
		{
			this.method_59();
		}

		private void method_208()
		{
			this.method_60();
		}

		private void method_209()
		{
			this.method_61();
		}

		internal void method_210()
		{
			(this.class502_0.TXITEM_ClipboardGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Copy.ToString()] as Control).Enabled = base.m_txTextControl.CanCopy;
			(this.class502_0.TXITEM_ClipboardGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Cut.ToString()] as Control).Enabled = base.m_txTextControl.CanCopy && base.m_txTextControl.CanEdit;
		}

		internal void method_211()
		{
			(this.class502_0.TXITEM_ClipboardGroup_Items[RibbonFormattingTab.InternalRibbonItem.TXITEM_Paste.ToString()] as Control).Enabled = base.m_txTextControl.CanPaste;
		}

		internal void method_212(object sender, EventArgs e)
		{
			this.method_177();
		}

		internal void method_213(object sender, EventArgs e)
		{
			this.method_178();
		}

		internal void method_214(object sender, EventArgs e)
		{
			this.method_179();
		}

		internal void method_215(object sender, EventArgs e)
		{
			this.method_180();
		}

		internal void method_216(object sender, EventArgs e)
		{
			this.method_181();
		}

		internal void method_217(object sender, EventArgs e)
		{
			this.method_182();
		}

		internal void method_218(object sender, EventArgs e)
		{
			this.method_183();
		}

		internal void method_219(object sender, EventArgs e)
		{
			this.method_184();
		}

		internal void method_220(object sender, EventArgs e)
		{
			this.method_185();
		}

		internal void method_221(object sender, EventArgs e)
		{
			this.method_188();
		}

		internal void method_222(object sender, EventArgs e)
		{
			this.method_189();
		}

		internal void method_223(object sender, EventArgs e)
		{
			this.method_190();
		}

		internal void method_224(object sender, EventArgs e)
		{
			this.method_191();
		}

		internal void method_225(object sender, EventArgs e)
		{
			this.method_192();
		}

		internal void method_226(object sender, EventArgs e)
		{
			this.method_193();
		}

		internal void method_227(object sender, EventArgs e)
		{
			this.method_194();
		}

		internal void method_228(object sender, EventArgs e)
		{
			this.method_195();
		}

		internal void method_229(object sender, EventArgs e)
		{
			this.method_196();
		}

		internal void method_230(object sender, EventArgs e)
		{
			this.method_197();
		}

		internal void method_231(object sender, EventArgs e)
		{
			this.method_198();
		}

		internal void method_232(object sender, EventArgs e)
		{
			this.method_199();
		}

		internal void method_233(object sender, EventArgs e)
		{
			this.method_200();
		}

		internal void method_234(object sender, EventArgs e)
		{
			this.method_201();
		}

		internal void method_235(object sender, EventArgs e)
		{
			this.method_202();
		}

		internal void method_236(object sender, EventArgs e)
		{
			this.method_203();
		}

		internal void method_237(object sender, EventArgs e)
		{
			this.method_204();
		}

		internal void method_238(object sender, EventArgs e)
		{
			this.method_207();
		}

		internal void method_239(object sender, EventArgs e)
		{
			this.method_205();
		}

		internal void method_240(object sender, EventArgs e)
		{
			this.method_206();
		}

		internal void method_241(object sender, EventArgs e)
		{
			this.method_208();
		}

		internal void method_242(object sender, EventArgs e)
		{
			this.method_209();
		}

		internal void method_243(object sender, EventArgs e)
		{
			this.method_187();
		}

		internal void method_244(object sender, EventArgs e)
		{
			this.method_186();
		}
	}
}
