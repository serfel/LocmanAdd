using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using TXTextControl;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class478 : BindingAdapter
	{
		private Class507 class507_0;

		private int int_0 = 15;

		private MeasuringUnit measuringUnit_0 = MeasuringUnit.Millimeter;

		private int int_1 = 1;

		private double double_0 = 1.0;

		private string string_0;

		internal override Class500 RibbonGroupManager
		{
			get
			{
				return this.class507_0;
			}
			set
			{
				this.class507_0 = value as Class507;
			}
		}

		internal Class478()
		{
		}

		private void method_0(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonPageLayoutTab.InternalRibbonItem.TXITEM_Orientation_Portrait.ToString(), null, this);
				ribbonToggleButton.Click += method_39;
				RibbonToggleButton ribbonToggleButton2 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonPageLayoutTab.InternalRibbonItem.TXITEM_Orientation_Landscape.ToString(), null, this);
				ribbonToggleButton2.Click += method_39;
				ribbonMenuButton.DropDownItems.AddRange(new Control[2] { ribbonToggleButton, ribbonToggleButton2 });
			}
		}

		private void method_1(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonPageLayoutTab.InternalRibbonItem.TXITEM_Columns_One.ToString(), null, this);
				ribbonToggleButton.Click += method_42;
				RibbonToggleButton ribbonToggleButton2 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonPageLayoutTab.InternalRibbonItem.TXITEM_Columns_Two.ToString(), null, this);
				ribbonToggleButton2.Click += method_42;
				RibbonToggleButton ribbonToggleButton3 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonPageLayoutTab.InternalRibbonItem.TXITEM_Columns_Three.ToString(), null, this);
				ribbonToggleButton3.Click += method_42;
				RibbonSeperator ribbonSeperator = new RibbonSeperator();
				ribbonSeperator.Name = RibbonPageLayoutTab.InternalRibbonItem.TXITEM_ColumnsSeperator1.ToString();
				RibbonSeperator ribbonSeperator2 = ribbonSeperator;
				((IRibbonItem)ribbonSeperator2).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonSeperator2.Name, ribbonSeperator2);
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonPageLayoutTab.InternalRibbonItem.TXITEM_Columns_MoreColumns.ToString(), null, this);
				ribbonButton.Click += method_42;
				ribbonMenuButton.DropDownItems.AddRange(new Control[5] { ribbonToggleButton, ribbonToggleButton2, ribbonToggleButton3, ribbonSeperator2, ribbonButton });
			}
		}

		private void method_2(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				RibbonLabel ribbonLabel = new RibbonLabel();
				ribbonLabel.Text = base.m_rmResourceManager.GetString(RibbonPageLayoutTab.InternalRibbonItem.TXITEM_Breaks_PageBreaks.ToString().Replace("TXITEM_", "HEADER_"));
				ribbonLabel.Name = RibbonPageLayoutTab.InternalRibbonItem.TXITEM_Breaks_PageBreaks.ToString();
				RibbonLabel ribbonLabel2 = ribbonLabel;
				((IRibbonItem)ribbonLabel2).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonLabel2.Name, ribbonLabel2);
				RibbonSeperator ribbonSeperator = new RibbonSeperator();
				ribbonSeperator.Name = RibbonPageLayoutTab.InternalRibbonItem.TXITEM_Breaks_Seperator1.ToString();
				RibbonSeperator ribbonSeperator2 = ribbonSeperator;
				((IRibbonItem)ribbonSeperator2).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonSeperator2.Name, ribbonSeperator2);
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonPageLayoutTab.InternalRibbonItem.TXITEM_Breaks_Page.ToString(), null, this);
				ribbonButton.Click += method_43;
				RibbonButton ribbonButton2 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonPageLayoutTab.InternalRibbonItem.TXITEM_Breaks_Column.ToString(), null, this);
				ribbonButton2.Click += method_43;
				RibbonButton ribbonButton3 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonPageLayoutTab.InternalRibbonItem.TXITEM_Breaks_TextWrapping.ToString(), null, this);
				ribbonButton3.Click += method_43;
				RibbonLabel ribbonLabel3 = new RibbonLabel();
				ribbonLabel3.Text = base.m_rmResourceManager.GetString(RibbonPageLayoutTab.InternalRibbonItem.TXITEM_Breaks_SectionBreaks.ToString().Replace("TXITEM_", "HEADER_"));
				ribbonLabel3.Name = RibbonPageLayoutTab.InternalRibbonItem.TXITEM_Breaks_SectionBreaks.ToString();
				RibbonLabel ribbonLabel4 = ribbonLabel3;
				((IRibbonItem)ribbonLabel4).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonLabel4.Name, ribbonLabel4);
				RibbonSeperator ribbonSeperator3 = new RibbonSeperator();
				ribbonSeperator3.Name = RibbonPageLayoutTab.InternalRibbonItem.TXITEM_Breaks_Seperator2.ToString();
				RibbonSeperator ribbonSeperator4 = ribbonSeperator3;
				((IRibbonItem)ribbonSeperator4).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonSeperator4.Name, ribbonSeperator4);
				RibbonButton ribbonButton4 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonPageLayoutTab.InternalRibbonItem.TXITEM_Breaks_NextPage.ToString(), null, this);
				ribbonButton4.Click += method_43;
				RibbonButton ribbonButton5 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonPageLayoutTab.InternalRibbonItem.TXITEM_Breaks_Continuous.ToString(), null, this);
				ribbonButton5.Click += method_43;
				ribbonMenuButton.DropDownItems.AddRange(new Control[9] { ribbonLabel2, ribbonSeperator2, ribbonButton, ribbonButton2, ribbonButton3, ribbonLabel4, ribbonSeperator4, ribbonButton4, ribbonButton5 });
			}
		}

		private void method_3(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageBorders_Left.ToString(), null, this);
				ribbonToggleButton.CheckedChanged += method_44;
				RibbonToggleButton ribbonToggleButton2 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageBorders_Top.ToString(), null, this);
				ribbonToggleButton2.CheckedChanged += method_44;
				RibbonToggleButton ribbonToggleButton3 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageBorders_Right.ToString(), null, this);
				ribbonToggleButton3.CheckedChanged += method_44;
				RibbonToggleButton ribbonToggleButton4 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageBorders_Bottom.ToString(), null, this);
				ribbonToggleButton4.CheckedChanged += method_44;
				RibbonSeperator ribbonSeperator = new RibbonSeperator();
				ribbonSeperator.Name = RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageBordersSeperator1.ToString();
				RibbonSeperator ribbonSeperator2 = ribbonSeperator;
				((IRibbonItem)ribbonSeperator2).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonSeperator2.Name, ribbonSeperator2);
				RibbonToggleButton ribbonToggleButton5 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageBorders_All.ToString(), null, this);
				ribbonToggleButton5.CheckedChanged += method_44;
				ribbonMenuButton.DropDownItems.AddRange(new Control[6] { ribbonToggleButton, ribbonToggleButton2, ribbonToggleButton3, ribbonToggleButton4, ribbonSeperator2, ribbonToggleButton5 });
			}
		}

		internal override void AwareOfDPI(PointF dpi)
		{
			base.AwareOfDPI(dpi);
			base.SetColorGalleryItems(this.class507_0.TXITEM_PageBackgroundAndBordersGroup_Items[RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
			base.SetColorGalleryItems(this.class507_0.TXITEM_PageBackgroundAndBordersGroup_Items[RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageLineColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
			base.SetLineWidthItemsImages(this.class507_0.TXITEM_PageBackgroundAndBordersGroup_Items[RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageLineWidth.ToString()] as RibbonMenuButton, base.m_pntDPI);
			if (base.m_txTextControl != null)
			{
				this.method_30();
				this.method_26();
			}
			this.SetDialogUnit();
		}

		internal override bool SetDialogUnit()
		{
			if (base.SetDialogUnit())
			{
				switch (base.m_iDialogUnit)
				{
				case 0:
				{
					bool flag = true;
					try
					{
						RegionInfo regionInfo = new RegionInfo(Thread.CurrentThread.CurrentCulture.LCID);
						flag = regionInfo.IsMetric;
					}
					catch
					{
					}
					this.measuringUnit_0 = ((!flag) ? MeasuringUnit.CentiInch : MeasuringUnit.Millimeter);
					this.int_1 = (flag ? 1 : 3);
					this.double_0 = (flag ? 1 : 100);
					this.string_0 = (flag ? base.m_rmResourceManager.GetString("LABEL_PageSizeMetric") : base.m_rmResourceManager.GetString("LABEL_PageSizeNonMetric"));
					break;
				}
				case 1:
					this.measuringUnit_0 = MeasuringUnit.Millimeter;
					this.int_1 = 1;
					this.double_0 = 1.0;
					this.string_0 = base.m_rmResourceManager.GetString("LABEL_PageSizeMetric");
					break;
				case 2:
					this.measuringUnit_0 = MeasuringUnit.CentiInch;
					this.int_1 = 3;
					this.double_0 = 100.0;
					this.string_0 = base.m_rmResourceManager.GetString("LABEL_PageSizeNonMetric");
					break;
				case 3:
					this.measuringUnit_0 = MeasuringUnit.Centimeter;
					this.int_1 = 2;
					this.double_0 = 1.0;
					this.string_0 = base.m_rmResourceManager.GetString("LABEL_PageSizeMetricCentimeter");
					break;
				}
				return true;
			}
			return false;
		}

		internal override void SetRibbonItemAppearance(Dictionary<string, object> groupItemsDictionary, Control ribbonItem, string eventName, bool hasImage)
		{
			base.SetBasicRibbonItemAppearance(groupItemsDictionary, ribbonItem, hasImage);
			switch (ribbonItem.Name)
			{
			case "TXITEM_Orientation":
				this.method_0(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_PageSize":
				(ribbonItem as RibbonMenuButton).DropDownOpening += method_40;
				break;
			case "TXITEM_Columns":
				this.method_1(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_Breaks":
				this.method_2(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_PageColor":
				base.Set_TXITEM_Color_DropDown(groupItemsDictionary, ribbonItem, RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageColor_Automatic.ToString(), RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageColorSeperator1.ToString(), RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageColor_Gallery.ToString(), RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageColorSeperator2.ToString(), RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageColor_MoreColors.ToString());
				break;
			case "TXITEM_PageBorders":
				this.method_3(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_PageLineColor":
				base.Set_TXITEM_Color_DropDown(groupItemsDictionary, ribbonItem, RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageLineColor_Automatic.ToString(), RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageLineColorSeperator1.ToString(), RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageLineColor_Gallery.ToString(), RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageLineColorSeperator2.ToString(), RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageLineColor_MoreColors.ToString());
				break;
			case "TXITEM_PageLineWidth":
				base.Set_TXITEM_LineWidth_DropDown(groupItemsDictionary, ribbonItem);
				break;
			}
			if (!string.IsNullOrEmpty(eventName))
			{
				Class517.smethod_23(ribbonItem, eventName, ribbonItem.Name + "_Handler", this);
			}
		}

		internal override void OnDisconnectingTextControl()
		{
			base.m_txTextControl.PageFormatChanged -= method_45;
			base.m_txTextControl.DocumentLoaded -= method_45;
			base.m_txTextControl.SectionChanged -= method_45;
		}

		internal override void OnTextControlConnected()
		{
			base.m_txTextControl.PageFormatChanged += method_45;
			base.m_txTextControl.DocumentLoaded += method_45;
			base.m_txTextControl.SectionChanged += method_45;
		}

		private void method_4()
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.SectionFormatDialog(0);
			}
		}

		private void method_5(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null && ribbonToggleButton_0 != null && ((IRibbonItem)ribbonToggleButton_0).IsDefaultRibbonTabItem)
			{
				bool landscape;
				switch (ribbonToggleButton_0.Name)
				{
				default:
					return;
				case "TXITEM_Orientation_Landscape":
					landscape = true;
					break;
				case "TXITEM_Orientation_Portrait":
					landscape = false;
					break;
				}
				base.m_txTextControl.Select(base.m_txTextControl.Selection.Start, 0);
				base.m_txTextControl.Sections.GetItem().Format.Landscape = landscape;
			}
		}

		private void method_6(RibbonMenuButton ribbonMenuButton_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			PaperSize[] supportedPaperSizes = base.m_txTextControl.GetSupportedPaperSizes();
			bool flag = ribbonMenuButton_0.DropDownItems.Count != supportedPaperSizes.Length;
			for (int i = 0; i < supportedPaperSizes.Length; i++)
			{
				if (flag)
				{
					break;
				}
				PaperSize paperSize = supportedPaperSizes[i];
				PaperSize paperSize2 = ribbonMenuButton_0.DropDownItems[i].Tag as PaperSize;
				flag = paperSize2 == null || paperSize.Height != paperSize2.Height || paperSize.Width != paperSize2.Width || paperSize.Name != paperSize2.Name;
			}
			if (flag)
			{
				ribbonMenuButton_0.DropDownItems.Clear();
				List<Control> list = new List<Control>();
				PaperSize[] array = supportedPaperSizes;
				foreach (PaperSize paperSize_ in array)
				{
					RibbonButton item = this.method_21(null, paperSize_);
					list.Add(item);
				}
				ribbonMenuButton_0.DropDownItems.AddRange(list.ToArray());
				this.method_22();
			}
		}

		private void method_7(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				ribbonToggleButton_0.Checked = true;
				base.m_txTextControl.Select(base.m_txTextControl.Selection.Start, 0);
				PaperSize paperSize = ribbonToggleButton_0.Tag as PaperSize;
				double width = TwipsConverter.Tw2DotNet(paperSize.Width, base.m_txTextControl.PageUnit);
				double height = TwipsConverter.Tw2DotNet(paperSize.Height, base.m_txTextControl.PageUnit);
				PageSize pageSize = new PageSize(width, height);
				Section item = base.m_txTextControl.Sections.GetItem();
				pageSize.Boolean_0 = item.Format.Landscape;
				item.Format.PageSize = pageSize;
			}
		}

		private void method_8()
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.SectionFormatDialog(2);
			}
		}

		private void method_9(RibbonButton ribbonButton_0)
		{
			if (base.m_txTextControl != null)
			{
				switch (ribbonButton_0.Name)
				{
				case "TXITEM_Columns_MoreColumns":
					base.m_txTextControl.SectionFormatDialog(2);
					break;
				case "TXITEM_Columns_Three":
					this.method_23(3);
					break;
				case "TXITEM_Columns_Two":
					this.method_23(2);
					break;
				case "TXITEM_Columns_One":
					this.method_23(1);
					break;
				}
			}
		}

		private void method_10(RibbonButton ribbonButton_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.Select(base.m_txTextControl.Selection.Start, 0);
				switch (ribbonButton_0.Name)
				{
				case "TXITEM_Breaks_Continuous":
					base.m_txTextControl.Sections.Add(SectionBreakKind.BeginAtNewLine);
					break;
				case "TXITEM_Breaks_NextPage":
					base.m_txTextControl.Sections.Add(SectionBreakKind.BeginAtNewPage);
					break;
				case "TXITEM_Breaks_Page":
					base.m_txTextControl.TextChars.Add(ControlChars.PageBreak);
					base.m_txTextControl.ScrollLocation = new Point(base.m_txTextControl.InputPosition.Location.X, base.m_txTextControl.InputPosition.Location.Y - 1440);
					return;
				case "TXITEM_Breaks_Column":
					base.m_txTextControl.TextChars.Add(ControlChars.ColumnBreak);
					break;
				case "TXITEM_Breaks_TextWrapping":
					base.m_txTextControl.TextChars.Add(ControlChars.LineBreak);
					break;
				}
				this.method_25(base.m_txTextControl.InputPosition.TextPosition);
			}
		}

		private void method_11()
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.SectionFormatDialog(3);
			}
		}

		private void method_12(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				switch (ribbonToggleButton_0.Name)
				{
				case "TXITEM_PageLineColor_Automatic":
					this.method_33(SystemColors.WindowText);
					this.method_30();
					break;
				case "TXITEM_PageColor_Automatic":
					base.m_txTextControl.BackColor = SystemColors.Window;
					break;
				}
				ribbonToggleButton_0.Checked = true;
			}
		}

		private void method_13(RibbonListView ribbonListView_0, RibbonListView.RibbonListViewItemEventArgs ribbonListViewItemEventArgs_0)
		{
			if (base.m_txTextControl != null)
			{
				switch (ribbonListView_0.Name)
				{
				case "TXITEM_PageLineColor_Gallery":
					this.method_33((Color)ribbonListViewItemEventArgs_0.Item.Tag);
					this.method_30();
					break;
				case "TXITEM_PageColor_Gallery":
					base.m_txTextControl.BackColor = (Color)ribbonListViewItemEventArgs_0.Item.Tag;
					break;
				}
			}
		}

		private void method_14(RibbonButton ribbonButton_0)
		{
			if (base.m_txTextControl != null)
			{
				switch (ribbonButton_0.Name)
				{
				case "TXITEM_PageLineColor_MoreColors":
					base.m_txTextControl.SectionFormatDialog(3);
					this.method_30();
					break;
				case "TXITEM_PageColor_MoreColors":
					base.m_txTextControl.PageColorDialog();
					break;
				}
			}
		}

		private void method_15(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				RibbonToggleButton ribbonToggleButton = this.class507_0.TXITEM_PageBackgroundAndBordersGroup_Items[RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageBorders_Left.ToString()] as RibbonToggleButton;
				RibbonToggleButton ribbonToggleButton2 = this.class507_0.TXITEM_PageBackgroundAndBordersGroup_Items[RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageBorders_Top.ToString()] as RibbonToggleButton;
				RibbonToggleButton ribbonToggleButton3 = this.class507_0.TXITEM_PageBackgroundAndBordersGroup_Items[RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageBorders_Right.ToString()] as RibbonToggleButton;
				RibbonToggleButton ribbonToggleButton4 = this.class507_0.TXITEM_PageBackgroundAndBordersGroup_Items[RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageBorders_Bottom.ToString()] as RibbonToggleButton;
				RibbonToggleButton ribbonToggleButton5 = this.class507_0.TXITEM_PageBackgroundAndBordersGroup_Items[RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageBorders_All.ToString()] as RibbonToggleButton;
				string name;
				if ((name = ribbonToggleButton_0.Name) != null && name == "TXITEM_PageBorders_All")
				{
					bool flag = (ribbonToggleButton4.Checked = ribbonToggleButton5.Checked);
					bool flag3 = (ribbonToggleButton3.Checked = flag);
					bool checked2 = (ribbonToggleButton2.Checked = flag3);
					ribbonToggleButton.Checked = checked2;
				}
				ribbonToggleButton5.Checked = ribbonToggleButton.Checked && ribbonToggleButton2.Checked && ribbonToggleButton3.Checked && ribbonToggleButton4.Checked;
				int num = this.method_28();
				this.method_38(ribbonToggleButton.Checked ? num : 0, ribbonToggleButton2.Checked ? num : 0, ribbonToggleButton3.Checked ? num : 0, ribbonToggleButton4.Checked ? num : 0);
			}
		}

		private void method_16(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				int num = (int)(ribbonToggleButton_0.Tag as object[])[0];
				string text;
				if ((text = (string)(ribbonToggleButton_0.Tag as object[])[1]) != null && text == "TXITEM_PageLineWidth")
				{
					this.int_0 = ((num != 0) ? num : this.int_0);
					this.method_37(num);
					this.method_34();
				}
			}
		}

		private void method_17()
		{
			if (this.class507_0.Boolean_0)
			{
				this.UpdateRibbonTab();
			}
		}

		internal override void UpdateRibbonTab(params object[] args)
		{
			this.method_18();
			this.method_24();
			this.method_19();
		}

		private void method_18()
		{
			RibbonGroup ribbonGroup_ = this.class507_0.Dictionary_0[RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageSetupGroup.ToString()] as RibbonGroup;
			if (this.class507_0.method_0(ribbonGroup_))
			{
				this.method_20();
				this.method_22();
			}
		}

		private void method_19()
		{
			RibbonGroup ribbonGroup_ = this.class507_0.TXITEM_PageBackgroundAndBordersGroup_Items[RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageBackgroundAndBordersGroup.ToString()] as RibbonGroup;
			if (this.class507_0.method_0(ribbonGroup_))
			{
				this.method_26();
				this.method_27();
				this.method_34();
				this.method_30();
			}
		}

		private void method_20()
		{
			RibbonMenuButton ribbonMenuButton = this.class507_0.Dictionary_0[RibbonPageLayoutTab.InternalRibbonItem.TXITEM_Orientation.ToString()] as RibbonMenuButton;
			if (!this.class507_0.method_3(ribbonMenuButton))
			{
				return;
			}
			bool? flag = null;
			Section section = ((base.m_txTextControl != null) ? base.m_txTextControl.Sections.GetItem() : null);
			if (section != null)
			{
				flag = section.Format.Landscape;
			}
			foreach (Control dropDownItem in ribbonMenuButton.DropDownItems)
			{
				RibbonToggleButton ribbonToggleButton = dropDownItem as RibbonToggleButton;
				if (ribbonToggleButton != null && ((IRibbonItem)ribbonToggleButton).IsDefaultRibbonTabItem)
				{
					switch (ribbonToggleButton.Name)
					{
					case "TXITEM_Orientation_Landscape":
						ribbonToggleButton.Checked = flag.HasValue && flag.Value;
						break;
					case "TXITEM_Orientation_Portrait":
						ribbonToggleButton.Checked = flag.HasValue && !flag.Value;
						break;
					}
				}
			}
		}

		private RibbonButton method_21(Dictionary<string, object> dictionary_0, PaperSize paperSize_0)
		{
			RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.LargeIconLabeled, bool_0: false, "TXITEM_PageSize_" + paperSize_0.Name, null, this);
			ribbonButton.Text = paperSize_0.Name;
			double num = Math.Round(TwipsConverter.Tw2DotNet(paperSize_0.Height, this.measuringUnit_0, this.int_1) / this.double_0, this.int_1);
			double num2 = Math.Round(TwipsConverter.Tw2DotNet(paperSize_0.Width, this.measuringUnit_0, this.int_1) / this.double_0, this.int_1);
			ribbonButton.Boolean_1 = true;
			ribbonButton.Description = num + " x " + num2 + " " + this.string_0;
			ribbonButton.Tag = paperSize_0;
			ribbonButton.IsAddToQuickAccessToolbarEnabled = false;
			ribbonButton.Click += method_41;
			return ribbonButton;
		}

		private void method_22()
		{
			RibbonMenuButton ribbonMenuButton = this.class507_0.Dictionary_0[RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageSize.ToString()] as RibbonMenuButton;
			if (!this.class507_0.method_2(ribbonMenuButton))
			{
				return;
			}
			Section section = ((base.m_txTextControl != null) ? base.m_txTextControl.Sections.GetItem() : null);
			PageSize pageSize = section?.Format.PageSize;
			bool flag = false;
			foreach (Control dropDownItem in ribbonMenuButton.DropDownItems)
			{
				RibbonToggleButton ribbonToggleButton = dropDownItem as RibbonToggleButton;
				if (ribbonToggleButton == null || !((IRibbonItem)ribbonToggleButton).IsDefaultRibbonTabItem)
				{
					continue;
				}
				if (pageSize != null)
				{
					PaperSize paperSize = ribbonToggleButton.Tag as PaperSize;
					double num = (section.Format.Landscape ? TwipsConverter.Tw2DotNet(paperSize.Height, base.m_txTextControl.PageUnit) : TwipsConverter.Tw2DotNet(paperSize.Width, base.m_txTextControl.PageUnit));
					double num2 = (section.Format.Landscape ? TwipsConverter.Tw2DotNet(paperSize.Width, base.m_txTextControl.PageUnit) : TwipsConverter.Tw2DotNet(paperSize.Height, base.m_txTextControl.PageUnit));
					if (ribbonToggleButton.Checked = pageSize.Width == num && pageSize.Height == num2 && !flag)
					{
						flag = true;
					}
				}
				else
				{
					ribbonToggleButton.Checked = false;
				}
			}
		}

		private void method_23(int int_2)
		{
			base.m_txTextControl.Select(base.m_txTextControl.Selection.Start, 0);
			Section item = base.m_txTextControl.Sections.GetItem();
			if (item != null)
			{
				item.Format.EqualColumnWidth = true;
				item.Format.Columns = int_2;
			}
		}

		private void method_24()
		{
			RibbonMenuButton ribbonMenuButton = this.class507_0.Dictionary_1[RibbonPageLayoutTab.InternalRibbonItem.TXITEM_Columns.ToString()] as RibbonMenuButton;
			if (!this.class507_0.method_3(ribbonMenuButton))
			{
				return;
			}
			int num = -1;
			Section section = ((base.m_txTextControl != null) ? base.m_txTextControl.Sections.GetItem() : null);
			if (section != null)
			{
				num = section.Format.Columns;
			}
			foreach (Control dropDownItem in ribbonMenuButton.DropDownItems)
			{
				RibbonToggleButton ribbonToggleButton = dropDownItem as RibbonToggleButton;
				if (ribbonToggleButton != null && ((IRibbonItem)ribbonToggleButton).IsDefaultRibbonTabItem)
				{
					switch (ribbonToggleButton.Name)
					{
					case "TXITEM_Columns_Three":
						ribbonToggleButton.Checked = num == 3;
						break;
					case "TXITEM_Columns_Two":
						ribbonToggleButton.Checked = num == 2;
						break;
					case "TXITEM_Columns_One":
						ribbonToggleButton.Checked = num == 1;
						break;
					}
				}
			}
		}

		private void method_25(int int_2)
		{
			Point scrollLocation = base.m_txTextControl.ScrollLocation;
			scrollLocation = ((int_2 + 1 > base.m_txTextControl.TextChars.Count) ? new Point(0, base.m_txTextControl.Lines[base.m_txTextControl.Lines.Count].TextBounds.Y) : new Point(0, base.m_txTextControl.TextChars[int_2 + 1].Bounds.Y));
			base.m_txTextControl.ScrollLocation = scrollLocation;
		}

		private void method_26()
		{
			RibbonMenuButton ribbonMenuButton = this.class507_0.TXITEM_PageBackgroundAndBordersGroup_Items[RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageColor.ToString()] as RibbonMenuButton;
			RibbonToggleButton ribbonToggleButton = this.class507_0.TXITEM_PageBackgroundAndBordersGroup_Items[RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageColor_Automatic.ToString()] as RibbonToggleButton;
			if (this.class507_0.method_2(ribbonMenuButton) || this.class507_0.method_2(ribbonToggleButton))
			{
				Color? nullable_ = null;
				if (base.m_txTextControl != null)
				{
					nullable_ = base.m_txTextControl.BackColor;
				}
				Class517.smethod_59(ribbonMenuButton, nullable_, bool_0: true, base.m_pntDPI);
				Class517.smethod_59(ribbonMenuButton, nullable_, bool_0: false, base.m_pntDPI);
				ribbonToggleButton.Checked = base.m_txTextControl != null && base.m_txTextControl.BackColor.IsNamedColor && base.m_txTextControl.BackColor.Name == SystemColors.Window.Name;
			}
		}

		private void method_27()
		{
			RibbonMenuButton object_ = this.class507_0.TXITEM_PageBackgroundAndBordersGroup_Items[RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageBorders.ToString()] as RibbonMenuButton;
			if (this.class507_0.method_3(object_))
			{
				RibbonToggleButton ribbonToggleButton = this.class507_0.TXITEM_PageBackgroundAndBordersGroup_Items[RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageBorders_Left.ToString()] as RibbonToggleButton;
				RibbonToggleButton ribbonToggleButton2 = this.class507_0.TXITEM_PageBackgroundAndBordersGroup_Items[RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageBorders_Top.ToString()] as RibbonToggleButton;
				RibbonToggleButton ribbonToggleButton3 = this.class507_0.TXITEM_PageBackgroundAndBordersGroup_Items[RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageBorders_Right.ToString()] as RibbonToggleButton;
				RibbonToggleButton ribbonToggleButton4 = this.class507_0.TXITEM_PageBackgroundAndBordersGroup_Items[RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageBorders_Bottom.ToString()] as RibbonToggleButton;
				RibbonToggleButton ribbonToggleButton5 = this.class507_0.TXITEM_PageBackgroundAndBordersGroup_Items[RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageBorders_All.ToString()] as RibbonToggleButton;
				Section section = ((base.m_txTextControl != null) ? base.m_txTextControl.Sections.GetItem() : null);
				if (section != null)
				{
					PageBorder pageBorder = section.Format.PageBorder;
					ribbonToggleButton.Checked = pageBorder.LeftLineWidth > 0;
					ribbonToggleButton2.Checked = pageBorder.TopLineWidth > 0;
					ribbonToggleButton3.Checked = pageBorder.RightLineWidth > 0;
					ribbonToggleButton4.Checked = pageBorder.BottomLineWidth > 0;
					ribbonToggleButton5.Checked = ribbonToggleButton.Checked && ribbonToggleButton2.Checked && ribbonToggleButton3.Checked && ribbonToggleButton4.Checked;
				}
				else
				{
					ribbonToggleButton5.Checked = false;
					ribbonToggleButton4.Checked = false;
					ribbonToggleButton3.Checked = false;
					ribbonToggleButton2.Checked = false;
					ribbonToggleButton.Checked = false;
				}
			}
		}

		private int method_28()
		{
			int? num = this.method_35();
			if (num.HasValue && num.Value != 0)
			{
				return num.Value;
			}
			return this.int_0;
		}

		private bool method_29(PageBorder pageBorder_0, bool bool_0, bool bool_1, bool bool_2, bool bool_3)
		{
			if (bool_0 && pageBorder_0.LeftLineWidth == 0)
			{
				return false;
			}
			if (bool_1 && pageBorder_0.TopLineWidth == 0)
			{
				return false;
			}
			if (bool_2 && pageBorder_0.RightLineWidth == 0)
			{
				return false;
			}
			if (bool_3 && pageBorder_0.BottomLineWidth == 0)
			{
				return false;
			}
			return true;
		}

		private void method_30()
		{
			RibbonToggleButton object_ = this.class507_0.TXITEM_PageBackgroundAndBordersGroup_Items[RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageLineColor_Automatic.ToString()] as RibbonToggleButton;
			if (this.class507_0.method_2(object_))
			{
				RibbonMenuButton ribbonMenuButton_ = this.class507_0.TXITEM_PageBackgroundAndBordersGroup_Items[RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageLineColor.ToString()] as RibbonMenuButton;
				Color? nullable_ = ((base.m_txTextControl != null) ? this.method_31() : null);
				Class517.smethod_59(ribbonMenuButton_, nullable_, bool_0: false, base.m_pntDPI);
				(this.class507_0.TXITEM_PageBackgroundAndBordersGroup_Items[RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageLineColor_Automatic.ToString()] as RibbonToggleButton).Checked = nullable_.HasValue && nullable_.Value.IsNamedColor && nullable_.Value.Name == SystemColors.WindowText.Name;
			}
		}

		private Color? method_31()
		{
			Color? color = null;
			Section item = base.m_txTextControl.Sections.GetItem();
			if (item != null)
			{
				PageBorder pageBorder = item.Format.PageBorder;
				if (pageBorder.LeftLineWidth > 0)
				{
					pageBorder.LeftLineColor.ToArgb();
					color = pageBorder.LeftLineColor;
				}
				if (pageBorder.TopLineWidth > 0)
				{
					Color? color2 = (color = this.method_32(color, pageBorder.TopLineColor));
					if (!color2.HasValue)
					{
						return null;
					}
				}
				if (pageBorder.RightLineWidth > 0)
				{
					Color? color3 = (color = this.method_32(color, pageBorder.RightLineColor));
					if (!color3.HasValue)
					{
						return null;
					}
				}
				if (pageBorder.BottomLineWidth > 0)
				{
					Color? color4 = (color = this.method_32(color, pageBorder.BottomLineColor));
					if (!color4.HasValue)
					{
						return null;
					}
				}
			}
			return color ?? new Color?(SystemColors.WindowText);
		}

		private Color? method_32(Color? nullable_0, Color color_0)
		{
			int num = color_0.ToArgb();
			if (nullable_0.HasValue)
			{
				if (nullable_0.Value.ToArgb() != num)
				{
					return null;
				}
			}
			else
			{
				nullable_0 = color_0;
			}
			return nullable_0;
		}

		private void method_33(Color color_0)
		{
			Section item = base.m_txTextControl.Sections.GetItem();
			if (item != null)
			{
				PageBorder pageBorder = new PageBorder();
				pageBorder.LeftLineColor = color_0;
				pageBorder.TopLineColor = color_0;
				pageBorder.RightLineColor = color_0;
				pageBorder.BottomLineColor = color_0;
				item.Format.PageBorder = pageBorder;
			}
		}

		private void method_34()
		{
			RibbonMenuButton ribbonMenuButton = this.class507_0.TXITEM_PageBackgroundAndBordersGroup_Items[RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageLineWidth.ToString()] as RibbonMenuButton;
			if (!this.class507_0.method_3(ribbonMenuButton))
			{
				return;
			}
			int? num = ((base.m_txTextControl != null) ? this.method_35() : null);
			foreach (IRibbonItem dropDownItem in ribbonMenuButton.DropDownItems)
			{
				if (dropDownItem.IsDefaultRibbonTabItem)
				{
					RibbonToggleButton ribbonToggleButton = dropDownItem as RibbonToggleButton;
					if (ribbonToggleButton != null)
					{
						int? num2 = (ribbonToggleButton.Tag as object[])[0] as int?;
						ribbonToggleButton.Checked = num2 == num || (num.HasValue && num.Value == 0 && num2.Value == this.int_0);
					}
				}
			}
		}

		private int? method_35()
		{
			int? num = null;
			int value = -1;
			bool flag = false;
			int int_ = -1;
			bool flag2 = false;
			int int_2 = -1;
			bool flag3 = false;
			int int_3 = -1;
			bool flag4 = false;
			Section item = base.m_txTextControl.Sections.GetItem();
			if (item != null)
			{
				PageBorder pageBorder = item.Format.PageBorder;
				flag = (value = pageBorder.LeftLineWidth) == 0;
				flag2 = (int_ = pageBorder.TopLineWidth) == 0;
				flag3 = (int_2 = pageBorder.RightLineWidth) == 0;
				flag4 = (int_3 = pageBorder.BottomLineWidth) == 0;
			}
			if (flag && flag2 && flag3 && flag4)
			{
				num = 0;
			}
			else
			{
				if (!flag)
				{
					num = value;
				}
				if (!flag2)
				{
					int? num2 = (num = this.method_36(num, int_));
					if (!num2.HasValue)
					{
						return null;
					}
				}
				if (!flag3)
				{
					int? num3 = (num = this.method_36(num, int_2));
					if (!num3.HasValue)
					{
						return null;
					}
				}
				if (!flag4)
				{
					int? num4 = (num = this.method_36(num, int_3));
					if (!num4.HasValue)
					{
						return null;
					}
				}
			}
			return num;
		}

		private int? method_36(int? nullable_0, int int_2)
		{
			if (nullable_0.HasValue)
			{
				if (nullable_0 != int_2)
				{
					return null;
				}
			}
			else
			{
				nullable_0 = int_2;
			}
			return nullable_0;
		}

		private void method_37(int int_2)
		{
			if (base.m_txTextControl != null)
			{
				Section item = base.m_txTextControl.Sections.GetItem();
				if (item != null)
				{
					PageBorder pageBorder = item.Format.PageBorder;
					bool flag = pageBorder.LeftLineWidth > 0;
					bool flag2 = pageBorder.TopLineWidth > 0;
					bool flag3 = pageBorder.RightLineWidth > 0;
					bool flag4 = pageBorder.BottomLineWidth > 0;
					PageBorder pageBorder2 = new PageBorder();
					pageBorder2.LeftLineWidth = (flag ? int_2 : 0);
					pageBorder2.TopLineWidth = (flag2 ? int_2 : 0);
					pageBorder2.RightLineWidth = (flag3 ? int_2 : 0);
					pageBorder2.BottomLineWidth = (flag4 ? int_2 : 0);
					item.Format.PageBorder = pageBorder2;
				}
			}
		}

		private void method_38(int int_2, int int_3, int int_4, int int_5)
		{
			base.m_txTextControl.Select(base.m_txTextControl.Selection.Start, 0);
			Section item = base.m_txTextControl.Sections.GetItem();
			if (item != null)
			{
				PageBorder pageBorder = new PageBorder();
				pageBorder.LeftLineWidth = int_2;
				pageBorder.TopLineWidth = int_3;
				pageBorder.RightLineWidth = int_4;
				pageBorder.BottomLineWidth = int_5;
				item.Format.PageBorder = pageBorder;
			}
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_PageSetupGroup_Handler(object sender, EventArgs e)
		{
			this.method_4();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_PageMargins_Handler(object sender, EventArgs e)
		{
			this.method_4();
		}

		private void method_39(object sender, EventArgs e)
		{
			this.method_5(sender as RibbonToggleButton);
		}

		private void method_40(object sender, EventArgs e)
		{
			this.method_6(sender as RibbonMenuButton);
		}

		private void method_41(object sender, EventArgs e)
		{
			this.method_7(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_ColumnsAndBreaksGroup_Handler(object sender, EventArgs e)
		{
			this.method_8();
		}

		private void method_42(object sender, EventArgs e)
		{
			this.method_9(sender as RibbonButton);
		}

		private void method_43(object sender, EventArgs e)
		{
			this.method_10(sender as RibbonButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_PageBackgroundAndBordersGroup_Handler(object sender, EventArgs e)
		{
			this.method_11();
		}

		protected override void DefaultColorButton_Click(object sender, EventArgs e)
		{
			this.method_12(sender as RibbonToggleButton);
		}

		protected override void ColorListView_ItemClick(object sender, RibbonListView.RibbonListViewItemEventArgs e)
		{
			this.method_13(sender as RibbonListView, e);
		}

		protected override void MoreColorsButton_Click(object sender, EventArgs e)
		{
			this.method_14(sender as RibbonButton);
		}

		private void method_44(object sender, EventArgs e)
		{
			this.method_15(sender as RibbonToggleButton);
		}

		protected override void LineWidthItem_Click(object sender, EventArgs e)
		{
			this.method_16(sender as RibbonToggleButton);
		}

		internal void method_45(object sender, EventArgs e)
		{
			this.method_17();
		}
	}
}
