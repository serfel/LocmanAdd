using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using TXTextControl;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class483 : BindingAdapter
	{
		private Class512 class512_0;

		internal override Class500 RibbonGroupManager
		{
			get
			{
				return this.class512_0;
			}
			set
			{
				this.class512_0 = value as Class512;
			}
		}

		private void method_0(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_SelectTableCell.ToString(), "Click", this);
				RibbonButton ribbonButton2 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_SelectTableCol.ToString(), "Click", this);
				RibbonButton ribbonButton3 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_SelectTableRow.ToString(), "Click", this);
				RibbonButton ribbonButton4 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_SelectTableAll.ToString(), "Click", this);
				ribbonMenuButton.DropDownItems.AddRange(new Control[4] { ribbonButton, ribbonButton2, ribbonButton3, ribbonButton4 });
			}
		}

		private void method_1(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_DeleteTableCell.ToString(), "Click", this);
				RibbonButton ribbonButton2 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_DeleteTableCol.ToString(), "Click", this);
				RibbonButton ribbonButton3 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_DeleteTableRow.ToString(), "Click", this);
				RibbonButton ribbonButton4 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_DeleteTableAll.ToString(), "Click", this);
				ribbonMenuButton.DropDownItems.AddRange(new Control[4] { ribbonButton, ribbonButton2, ribbonButton3, ribbonButton4 });
			}
		}

		private void method_2(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_SplitTableAbove.ToString(), "Click", this);
				RibbonButton ribbonButton2 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_SplitTableBelow.ToString(), "Click", this);
				ribbonMenuButton.DropDownItems.AddRange(new Control[2] { ribbonButton, ribbonButton2 });
			}
		}

		private void method_3()
		{
			RibbonMenuButton ribbonMenuButton = this.class512_0.TXITEM_BordersAndBackgroundGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableFrameLines.ToString()] as RibbonMenuButton;
			foreach (Control dropDownItem in ribbonMenuButton.DropDownItems)
			{
				if (dropDownItem is RibbonToggleButton && (dropDownItem as IRibbonItem).IsDefaultRibbonTabItem)
				{
					string text = dropDownItem.Name.Replace("TXITEM_Table", "");
					string string_ = "TextControl_InputFormat_" + text + "Changed";
					Class517.smethod_24(base.m_txTextControl.InputFormat, text + "Changed", string_, this);
				}
			}
		}

		private void method_4(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableLeftFrameLine.ToString(), "Click", this);
				RibbonToggleButton ribbonToggleButton2 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableTopFrameLine.ToString(), "Click", this);
				RibbonToggleButton ribbonToggleButton3 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableRightFrameLine.ToString(), "Click", this);
				RibbonToggleButton ribbonToggleButton4 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableBottomFrameLine.ToString(), "Click", this);
				RibbonSeperator ribbonSeperator = new RibbonSeperator();
				ribbonSeperator.Name = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableFrameLinesSeperator1.ToString();
				RibbonSeperator ribbonSeperator2 = ribbonSeperator;
				((IRibbonItem)ribbonSeperator2).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonSeperator2.Name, ribbonSeperator2);
				RibbonToggleButton ribbonToggleButton5 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableBoxFrame.ToString(), "Click", this);
				RibbonToggleButton ribbonToggleButton6 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableAllFrameLines.ToString(), "Click", this);
				RibbonSeperator ribbonSeperator3 = new RibbonSeperator();
				ribbonSeperator3.Name = RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableFrameLinesSeperator2.ToString();
				RibbonSeperator ribbonSeperator4 = ribbonSeperator3;
				((IRibbonItem)ribbonSeperator4).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonSeperator4.Name, ribbonSeperator4);
				RibbonToggleButton ribbonToggleButton7 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableInnerHorizontalFrameLines.ToString(), "Click", this);
				RibbonToggleButton ribbonToggleButton8 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableInnerVerticalFrameLines.ToString(), "Click", this);
				ribbonMenuButton.DropDownItems.AddRange(new Control[10] { ribbonToggleButton, ribbonToggleButton2, ribbonToggleButton3, ribbonToggleButton4, ribbonSeperator2, ribbonToggleButton5, ribbonToggleButton6, ribbonSeperator4, ribbonToggleButton7, ribbonToggleButton8 });
			}
		}

		private void method_5(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_InsertTableRowAbove.ToString(), "Click", this);
				RibbonButton ribbonButton2 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_InsertTableRowBelow.ToString(), "Click", this);
				RibbonButton ribbonButton3 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_InsertTableColLeft.ToString(), "Click", this);
				RibbonButton ribbonButton4 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_InsertTableColRight.ToString(), "Click", this);
				ribbonMenuButton.DropDownItems.AddRange(new Control[4] { ribbonButton, ribbonButton2, ribbonButton3, ribbonButton4 });
			}
		}

		internal override void AwareOfDPI(PointF dpi)
		{
			base.AwareOfDPI(dpi);
			base.SetColorGalleryItems(this.class512_0.TXITEM_BordersAndBackgroundGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableLineColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
			base.SetColorGalleryItems(this.class512_0.TXITEM_BordersAndBackgroundGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableBackColor_Gallery.ToString()] as RibbonListView, base.m_pntDPI);
			base.SetLineWidthItemsImages(this.class512_0.TXITEM_BordersAndBackgroundGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableLineWidth.ToString()] as RibbonMenuButton, base.m_pntDPI);
		}

		internal override void SetRibbonItemAppearance(Dictionary<string, object> groupItemsDictionary, Control ribbonItem, string eventName, bool hasImage)
		{
			base.SetBasicRibbonItemAppearance(groupItemsDictionary, ribbonItem, hasImage);
			switch (ribbonItem.Name)
			{
			case "TXITEM_SelectTable":
			case "TXITEM_TableSelect":
				this.method_0(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_DeleteTable":
			case "TXITEM_TableDelete":
				this.method_1(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_SplitTable":
				this.method_2(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_TableFrameLines":
				this.method_4(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_TableLineColor":
				base.Set_TXITEM_Color_DropDown(groupItemsDictionary, ribbonItem, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableLineColor_Automatic.ToString(), RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableLineColorSeperator1.ToString(), RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableLineColor_Gallery.ToString(), RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableLineColorSeperator2.ToString(), RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableLineColor_MoreColors.ToString());
				break;
			case "TXITEM_TableBackColor":
				base.Set_TXITEM_Color_DropDown(groupItemsDictionary, ribbonItem, RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableBackColor_Transparent.ToString(), RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableBackColorSeperator1.ToString(), RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableBackColor_Gallery.ToString(), RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableBackColorSeperator2.ToString(), RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableBackColor_MoreColors.ToString());
				break;
			case "TXITEM_TableLineWidth":
				base.Set_TXITEM_LineWidth_DropDown(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_TableInsert":
				this.method_5(groupItemsDictionary, ribbonItem);
				break;
			}
			if (eventName != null)
			{
				Class517.smethod_23(ribbonItem, eventName, ribbonItem.Name + "_Handler", this);
			}
		}

		internal override void OnDisconnectingTextControl()
		{
			base.m_txTextControl.InputPositionChanged -= method_86;
			base.m_txTextControl.InputFormat.LeftFrameLineChanged -= method_87;
			base.m_txTextControl.InputFormat.TopFrameLineChanged -= method_88;
			base.m_txTextControl.InputFormat.RightFrameLineChanged -= method_89;
			base.m_txTextControl.InputFormat.BottomFrameLineChanged -= method_90;
			base.m_txTextControl.InputFormat.BoxFrameChanged -= method_91;
			base.m_txTextControl.InputFormat.AllFrameLinesChanged -= method_92;
			base.m_txTextControl.InputFormat.InnerHorizontalFrameLinesChanged -= method_93;
			base.m_txTextControl.InputFormat.InnerVerticalFrameLinesChanged -= method_94;
			base.m_txTextControl.InputFormat.FrameLineWidthChanged -= method_95;
			base.m_txTextControl.InputFormat.FrameFillColorChanged -= method_96;
			base.m_txTextControl.InputFormat.FrameLineColorChanged -= method_97;
			base.m_txTextControl.InputFormat.LeftAlignedChanged -= InputFormat_AlignedChanged;
			base.m_txTextControl.InputFormat.CenteredChanged -= InputFormat_AlignedChanged;
			base.m_txTextControl.InputFormat.RightAlignedChanged -= InputFormat_AlignedChanged;
			base.m_txTextControl.InputFormat.JustifiedChanged -= InputFormat_AlignedChanged;
			base.m_txTextControl.InputFormat.TopAlignedChanged -= InputFormat_AlignedChanged;
			base.m_txTextControl.InputFormat.VerticallyCenteredChanged -= InputFormat_AlignedChanged;
			base.m_txTextControl.InputFormat.BottomAlignedChanged -= InputFormat_AlignedChanged;
		}

		internal override void OnTextControlConnected()
		{
			base.m_txTextControl.InputPositionChanged += method_86;
			base.m_txTextControl.InputFormat.LeftFrameLineChanged += method_87;
			base.m_txTextControl.InputFormat.TopFrameLineChanged += method_88;
			base.m_txTextControl.InputFormat.RightFrameLineChanged += method_89;
			base.m_txTextControl.InputFormat.BottomFrameLineChanged += method_90;
			base.m_txTextControl.InputFormat.BoxFrameChanged += method_91;
			base.m_txTextControl.InputFormat.AllFrameLinesChanged += method_92;
			base.m_txTextControl.InputFormat.InnerHorizontalFrameLinesChanged += method_93;
			base.m_txTextControl.InputFormat.InnerVerticalFrameLinesChanged += method_94;
			base.m_txTextControl.InputFormat.FrameLineWidthChanged += method_95;
			base.m_txTextControl.InputFormat.FrameFillColorChanged += method_96;
			base.m_txTextControl.InputFormat.FrameLineColorChanged += method_97;
			base.m_txTextControl.InputFormat.LeftAlignedChanged += InputFormat_AlignedChanged;
			base.m_txTextControl.InputFormat.CenteredChanged += InputFormat_AlignedChanged;
			base.m_txTextControl.InputFormat.RightAlignedChanged += InputFormat_AlignedChanged;
			base.m_txTextControl.InputFormat.JustifiedChanged += InputFormat_AlignedChanged;
			base.m_txTextControl.InputFormat.TopAlignedChanged += InputFormat_AlignedChanged;
			base.m_txTextControl.InputFormat.VerticallyCenteredChanged += InputFormat_AlignedChanged;
			base.m_txTextControl.InputFormat.BottomAlignedChanged += InputFormat_AlignedChanged;
		}

		private void method_6()
		{
			Table item;
			TableCell item2;
			if (base.m_txTextControl != null && (item = base.m_txTextControl.Tables.GetItem()) != null && (item2 = item.Cells.GetItem()) != null)
			{
				item2.Select();
				if (this.class512_0.Control_0 is TextMiniToolbar)
				{
					(this.class512_0.Control_0 as TextMiniToolbar).Close();
				}
			}
		}

		private void method_7()
		{
			Table item;
			TableColumn item2;
			if (base.m_txTextControl != null && (item = base.m_txTextControl.Tables.GetItem()) != null && (item2 = item.Columns.GetItem()) != null)
			{
				item2.Select();
				if (this.class512_0.Control_0 is TextMiniToolbar)
				{
					(this.class512_0.Control_0 as TextMiniToolbar).Close();
				}
			}
		}

		private void method_8()
		{
			Table item;
			TableRow item2;
			if (base.m_txTextControl != null && (item = base.m_txTextControl.Tables.GetItem()) != null && (item2 = item.Rows.GetItem()) != null)
			{
				item2.Select();
				if (this.class512_0.Control_0 is TextMiniToolbar)
				{
					(this.class512_0.Control_0 as TextMiniToolbar).Close();
				}
			}
		}

		private void method_9()
		{
			Table item;
			if (base.m_txTextControl != null && (item = base.m_txTextControl.Tables.GetItem()) != null)
			{
				item.Select();
				if (this.class512_0.Control_0 is TextMiniToolbar)
				{
					(this.class512_0.Control_0 as TextMiniToolbar).Close();
				}
			}
		}

		private void method_10(bool bool_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.Tables.GridLines = bool_0;
			}
		}

		private void method_11()
		{
			if (base.m_txTextControl != null && base.m_txTextControl.Tables.GetItem() != null)
			{
				base.m_txTextControl.TableFormatDialog();
			}
		}

		private void method_12()
		{
			Table item;
			if (base.m_txTextControl != null && (item = base.m_txTextControl.Tables.GetItem()) != null && item.Cells.CanRemove)
			{
				item.Cells.Remove();
				if (this.class512_0.Control_0 is TextMiniToolbar && ((item = base.m_txTextControl.Tables.GetItem()) == null || !item.Cells.CanRemove))
				{
					(this.class512_0.Control_0 as TextMiniToolbar).Close();
				}
			}
		}

		private void method_13()
		{
			Table item;
			if (base.m_txTextControl != null && (item = base.m_txTextControl.Tables.GetItem()) != null && item.Columns.CanRemove)
			{
				item.Columns.Remove();
				if (this.class512_0.Control_0 is TextMiniToolbar && ((item = base.m_txTextControl.Tables.GetItem()) == null || !item.Columns.CanRemove))
				{
					(this.class512_0.Control_0 as TextMiniToolbar).Close();
				}
			}
		}

		private void method_14()
		{
			Table item;
			if (base.m_txTextControl != null && (item = base.m_txTextControl.Tables.GetItem()) != null && item.Rows.CanRemove)
			{
				item.Rows.Remove();
				if (this.class512_0.Control_0 is TextMiniToolbar && ((item = base.m_txTextControl.Tables.GetItem()) == null || !item.Rows.CanRemove))
				{
					(this.class512_0.Control_0 as TextMiniToolbar).Close();
				}
			}
		}

		private void method_15()
		{
			Table item;
			if (base.m_txTextControl != null && (item = base.m_txTextControl.Tables.GetItem()) != null)
			{
				item.method_1();
				if (this.class512_0.Control_0 is TextMiniToolbar && base.m_txTextControl.Tables.GetItem() == null)
				{
					(this.class512_0.Control_0 as TextMiniToolbar).Close();
				}
			}
		}

		private void method_16()
		{
			Table item;
			if (base.m_txTextControl != null && (item = base.m_txTextControl.Tables.GetItem()) != null)
			{
				item.Rows.Add(TableAddPosition.Before, 1);
			}
		}

		private void method_17()
		{
			Table item;
			if (base.m_txTextControl != null && (item = base.m_txTextControl.Tables.GetItem()) != null)
			{
				item.Rows.Add(TableAddPosition.After, 1);
			}
		}

		private void method_18()
		{
			Table item;
			if (base.m_txTextControl != null && (item = base.m_txTextControl.Tables.GetItem()) != null)
			{
				item.Columns.Add(TableAddPosition.Before);
			}
		}

		private void method_19()
		{
			Table item;
			if (base.m_txTextControl != null && (item = base.m_txTextControl.Tables.GetItem()) != null)
			{
				item.Columns.Add(TableAddPosition.After);
			}
		}

		private void method_20()
		{
			Table item;
			if (base.m_txTextControl != null && (item = base.m_txTextControl.Tables.GetItem()) != null)
			{
				item.MergeCells();
			}
		}

		private void method_21()
		{
			Table item;
			if (base.m_txTextControl != null && (item = base.m_txTextControl.Tables.GetItem()) != null)
			{
				item.SplitCells();
			}
		}

		private void method_22()
		{
			Table item;
			if (base.m_txTextControl != null && (item = base.m_txTextControl.Tables.GetItem()) != null)
			{
				item.Split(TableAddPosition.Before);
			}
		}

		private void method_23()
		{
			Table item;
			if (base.m_txTextControl != null && (item = base.m_txTextControl.Tables.GetItem()) != null)
			{
				item.Split(TableAddPosition.After);
			}
		}

		private void method_24()
		{
			if (base.m_txTextControl != null && base.m_txTextControl.Tables.GetItem() != null)
			{
				base.m_txTextControl.TableFormatDialog();
			}
		}

		private void method_25(bool bool_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.LeftFrameLine = bool_0;
			}
		}

		private void method_26(bool bool_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.TopFrameLine = bool_0;
			}
		}

		private void method_27(bool bool_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.RightFrameLine = bool_0;
			}
		}

		private void method_28(bool bool_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.BottomFrameLine = bool_0;
			}
		}

		private void method_29(bool bool_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.BoxFrame = bool_0;
			}
		}

		private void method_30(bool bool_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.AllFrameLines = bool_0;
			}
		}

		private void method_31(bool bool_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.InnerHorizontalFrameLines = bool_0;
			}
		}

		private void method_32(bool bool_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.InnerVerticalFrameLines = bool_0;
			}
		}

		private void method_33(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				switch (ribbonToggleButton_0.Name)
				{
				case "TXITEM_TableLineColor_Automatic":
					base.m_txTextControl.InputFormat.FrameLineColor = SystemColors.WindowText;
					break;
				case "TXITEM_TableBackColor_Transparent":
					base.m_txTextControl.InputFormat.FrameFillColor = Color.Transparent;
					break;
				}
				ribbonToggleButton_0.Checked = true;
			}
		}

		private void method_34(RibbonListView ribbonListView_0, Color color_0)
		{
			if (base.m_txTextControl != null)
			{
				switch (ribbonListView_0.Name)
				{
				case "TXITEM_TableLineColor_Gallery":
					base.m_txTextControl.InputFormat.FrameLineColor = color_0;
					break;
				case "TXITEM_TableBackColor_Gallery":
					base.m_txTextControl.InputFormat.FrameFillColor = color_0;
					break;
				}
			}
		}

		private void method_35(RibbonButton ribbonButton_0)
		{
			if (base.m_txTextControl != null)
			{
				switch (ribbonButton_0.Name)
				{
				case "TXITEM_TableBackColor_MoreColors":
					base.m_txTextControl.FrameFillColorDialog();
					break;
				case "TXITEM_TableLineColor_MoreColors":
					base.m_txTextControl.FrameLineColorDialog();
					break;
				}
			}
		}

		private void method_36(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			int? frameLineWidth = (int)(ribbonToggleButton_0.Tag as object[])[0];
			base.m_txTextControl.InputFormat.FrameLineWidth = frameLineWidth;
			frameLineWidth = base.m_txTextControl.InputFormat.FrameLineWidth;
			RibbonMenuButton ribbonMenuButton = this.class512_0.TXITEM_BordersAndBackgroundGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableLineWidth.ToString()] as RibbonMenuButton;
			foreach (IRibbonItem dropDownItem in ribbonMenuButton.DropDownItems)
			{
				if (dropDownItem.IsDefaultRibbonTabItem)
				{
					RibbonToggleButton ribbonToggleButton = dropDownItem as RibbonToggleButton;
					ribbonToggleButton.Checked = (ribbonToggleButton.Tag as object[])[0] as int? == frameLineWidth;
				}
			}
		}

		private void method_37()
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.TableFormatDialog(1);
			}
		}

		private void method_38(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.TopAligned = true;
				base.m_txTextControl.InputFormat.LeftAligned = true;
				ribbonToggleButton_0.Checked = base.m_txTextControl.InputFormat.TopAligned.HasValue && base.m_txTextControl.InputFormat.TopAligned.Value && base.m_txTextControl.InputFormat.LeftAligned.HasValue && base.m_txTextControl.InputFormat.LeftAligned.Value;
			}
		}

		private void method_39(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.TopAligned = true;
				base.m_txTextControl.InputFormat.Centered = true;
				ribbonToggleButton_0.Checked = base.m_txTextControl.InputFormat.TopAligned.HasValue && base.m_txTextControl.InputFormat.TopAligned.Value && base.m_txTextControl.InputFormat.Centered.HasValue && base.m_txTextControl.InputFormat.Centered.Value;
			}
		}

		private void method_40(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.TopAligned = true;
				base.m_txTextControl.InputFormat.RightAligned = true;
				ribbonToggleButton_0.Checked = base.m_txTextControl.InputFormat.TopAligned.HasValue && base.m_txTextControl.InputFormat.TopAligned.Value && base.m_txTextControl.InputFormat.RightAligned.HasValue && base.m_txTextControl.InputFormat.RightAligned.Value;
			}
		}

		private void method_41(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.TopAligned = true;
				base.m_txTextControl.InputFormat.Justified = true;
				ribbonToggleButton_0.Checked = base.m_txTextControl.InputFormat.TopAligned.HasValue && base.m_txTextControl.InputFormat.TopAligned.Value && base.m_txTextControl.InputFormat.Justified.HasValue && base.m_txTextControl.InputFormat.Justified.Value;
			}
		}

		private void method_42(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.VerticallyCentered = true;
				base.m_txTextControl.InputFormat.LeftAligned = true;
				ribbonToggleButton_0.Checked = base.m_txTextControl.InputFormat.VerticallyCentered.HasValue && base.m_txTextControl.InputFormat.VerticallyCentered.Value && base.m_txTextControl.InputFormat.LeftAligned.HasValue && base.m_txTextControl.InputFormat.LeftAligned.Value;
			}
		}

		private void method_43(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.VerticallyCentered = true;
				base.m_txTextControl.InputFormat.Centered = true;
				ribbonToggleButton_0.Checked = base.m_txTextControl.InputFormat.VerticallyCentered.HasValue && base.m_txTextControl.InputFormat.VerticallyCentered.Value && base.m_txTextControl.InputFormat.Centered.HasValue && base.m_txTextControl.InputFormat.Centered.Value;
			}
		}

		private void method_44(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.VerticallyCentered = true;
				base.m_txTextControl.InputFormat.RightAligned = true;
				ribbonToggleButton_0.Checked = base.m_txTextControl.InputFormat.VerticallyCentered.HasValue && base.m_txTextControl.InputFormat.VerticallyCentered.Value && base.m_txTextControl.InputFormat.RightAligned.HasValue && base.m_txTextControl.InputFormat.RightAligned.Value;
			}
		}

		private void method_45(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.VerticallyCentered = true;
				base.m_txTextControl.InputFormat.Justified = true;
				ribbonToggleButton_0.Checked = base.m_txTextControl.InputFormat.VerticallyCentered.HasValue && base.m_txTextControl.InputFormat.VerticallyCentered.Value && base.m_txTextControl.InputFormat.Justified.HasValue && base.m_txTextControl.InputFormat.Justified.Value;
			}
		}

		private void method_46(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.BottomAligned = true;
				base.m_txTextControl.InputFormat.LeftAligned = true;
				ribbonToggleButton_0.Checked = base.m_txTextControl.InputFormat.BottomAligned.HasValue && base.m_txTextControl.InputFormat.BottomAligned.Value && base.m_txTextControl.InputFormat.LeftAligned.HasValue && base.m_txTextControl.InputFormat.LeftAligned.Value;
			}
		}

		private void method_47(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.BottomAligned = true;
				base.m_txTextControl.InputFormat.Centered = true;
				ribbonToggleButton_0.Checked = base.m_txTextControl.InputFormat.BottomAligned.HasValue && base.m_txTextControl.InputFormat.BottomAligned.Value && base.m_txTextControl.InputFormat.Centered.HasValue && base.m_txTextControl.InputFormat.Centered.Value;
			}
		}

		private void method_48(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.BottomAligned = true;
				base.m_txTextControl.InputFormat.RightAligned = true;
				ribbonToggleButton_0.Checked = base.m_txTextControl.InputFormat.BottomAligned.HasValue && base.m_txTextControl.InputFormat.BottomAligned.Value && base.m_txTextControl.InputFormat.RightAligned.HasValue && base.m_txTextControl.InputFormat.RightAligned.Value;
			}
		}

		private void method_49(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.InputFormat.BottomAligned = true;
				base.m_txTextControl.InputFormat.Justified = true;
				ribbonToggleButton_0.Checked = base.m_txTextControl.InputFormat.BottomAligned.HasValue && base.m_txTextControl.InputFormat.BottomAligned.Value && base.m_txTextControl.InputFormat.Justified.HasValue && base.m_txTextControl.InputFormat.Justified.Value;
			}
		}

		private void method_50()
		{
			Table item;
			if (base.m_txTextControl != null && (item = base.m_txTextControl.Tables.GetItem()) != null)
			{
				int length = base.m_txTextControl.Selection.Length;
				if (item.MergeCells() && base.m_txTextControl.Selection.Length != length && this.class512_0.Control_0 is TextMiniToolbar)
				{
					(this.class512_0.Control_0 as TextMiniToolbar).Close();
				}
			}
		}

		private void method_51()
		{
			Table item;
			if (base.m_txTextControl != null && (item = base.m_txTextControl.Tables.GetItem()) != null)
			{
				int length = base.m_txTextControl.Selection.Length;
				if (item.SplitCells() && base.m_txTextControl.Selection.Length != length && this.class512_0.Control_0 is TextMiniToolbar)
				{
					(this.class512_0.Control_0 as TextMiniToolbar).Close();
				}
			}
		}

		private void method_52()
		{
			if (this.class512_0.Boolean_0)
			{
				this.method_66();
			}
		}

		private void method_53()
		{
			this.method_73();
		}

		private void method_54()
		{
			this.method_74();
		}

		private void method_55()
		{
			this.method_75();
		}

		private void method_56()
		{
			this.method_76();
		}

		private void method_57()
		{
			this.method_77();
		}

		private void method_58()
		{
			this.method_78();
		}

		private void method_59()
		{
			this.method_79();
		}

		private void method_60()
		{
			this.method_80();
		}

		private void method_61()
		{
			this.method_83();
		}

		private void method_62()
		{
			this.method_81();
		}

		private void method_63()
		{
			this.method_82();
		}

		private void method_64()
		{
			RibbonGroup ribbonGroup_ = this.class512_0.TXITEM_TableAlignmentGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableAlignmentGroup.ToString()] as RibbonGroup;
			if (this.class512_0.method_0(ribbonGroup_))
			{
				Table item = base.m_txTextControl.Tables.GetItem();
				this.method_84(ribbonGroup_, item, item != null && base.m_txTextControl.CanEdit);
			}
		}

		internal void method_65()
		{
			if (this.class512_0.Boolean_0)
			{
				this.UpdateRibbonTab();
			}
		}

		internal override void UpdateRibbonTab(params object[] args)
		{
			Table table = null;
			bool flag = false;
			if (base.m_txTextControl != null)
			{
				flag = base.m_txTextControl.CanEdit;
				table = base.m_txTextControl.Tables.GetItem();
				this.method_67(table);
				table = (base.m_txTextControl.CanTableFormat ? table : null);
			}
			if (flag && table != null)
			{
				this.method_68(table);
				this.method_69(table);
				this.method_70(table);
				this.method_71(table);
			}
			else
			{
				IEnabledItem obj = this.class512_0.TXITEM_RowsAndColumnsGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_RowsAndColumnsGroup.ToString()] as IEnabledItem;
				IEnabledItem obj2 = this.class512_0.TXITEM_MergeGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_MergeGroup.ToString()] as IEnabledItem;
				IEnabledItem obj3 = this.class512_0.TXITEM_BordersAndBackgroundGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_BordersAndBackgroundGroup.ToString()] as IEnabledItem;
				(this.class512_0.TXITEM_TableAlignmentGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableAlignmentGroup.ToString()] as IEnabledItem).Enabled = false;
				obj3.Enabled = false;
				obj2.Enabled = false;
				obj.Enabled = false;
			}
		}

		private void method_66()
		{
			Table table = null;
			bool flag = false;
			if (base.m_txTextControl != null)
			{
				flag = base.m_txTextControl.CanEdit;
				table = base.m_txTextControl.Tables.GetItem();
				this.method_67(table);
				table = (base.m_txTextControl.CanTableFormat ? table : null);
			}
			if (flag && table != null)
			{
				this.method_68(table);
				this.method_69(table);
				return;
			}
			IEnabledItem obj = this.class512_0.TXITEM_RowsAndColumnsGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_RowsAndColumnsGroup.ToString()] as IEnabledItem;
			IEnabledItem obj2 = this.class512_0.TXITEM_MergeGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_MergeGroup.ToString()] as IEnabledItem;
			IEnabledItem obj3 = this.class512_0.TXITEM_BordersAndBackgroundGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_BordersAndBackgroundGroup.ToString()] as IEnabledItem;
			(this.class512_0.TXITEM_TableAlignmentGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableAlignmentGroup.ToString()] as IEnabledItem).Enabled = false;
			obj3.Enabled = false;
			obj2.Enabled = false;
			obj.Enabled = false;
		}

		private void method_67(Table table_0)
		{
			RibbonGroup ribbonGroup = this.class512_0.TXITEM_TableLayoutGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableLayoutGroup.ToString()] as RibbonGroup;
			if (!this.class512_0.method_0(ribbonGroup) || !(ribbonGroup.Enabled = table_0 != null || base.m_txTextControl == null))
			{
				return;
			}
			RibbonMenuButton ribbonMenuButton = this.class512_0.TXITEM_TableLayoutGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_SelectTable.ToString()] as RibbonMenuButton;
			if (this.class512_0.method_2(ribbonMenuButton))
			{
				foreach (Control dropDownItem in ribbonMenuButton.DropDownItems)
				{
					switch (dropDownItem.Name)
					{
					case "TXITEM_SelectTableRow":
						dropDownItem.Enabled = base.m_txTextControl == null || table_0.Rows.GetItem() != null;
						break;
					case "TXITEM_SelectTableCol":
						dropDownItem.Enabled = base.m_txTextControl == null || table_0.Columns.GetItem() != null;
						break;
					case "TXITEM_SelectTableCell":
						dropDownItem.Enabled = base.m_txTextControl == null || table_0.Cells.GetItem() != null;
						break;
					}
				}
			}
			RibbonToggleButton ribbonToggleButton = this.class512_0.TXITEM_TableLayoutGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableGridLines.ToString()] as RibbonToggleButton;
			if (this.class512_0.method_2(ribbonToggleButton))
			{
				ribbonToggleButton.Checked = base.m_txTextControl == null || base.m_txTextControl.Tables.GridLines;
			}
			RibbonButton ribbonButton = this.class512_0.TXITEM_TableLayoutGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableProperties.ToString()] as RibbonButton;
			if (this.class512_0.method_2(ribbonButton))
			{
				((IEnabledItem)ribbonButton).Enabled = base.m_txTextControl == null || base.m_txTextControl.CanTableFormat;
			}
		}

		private void method_68(Table table_0)
		{
			RibbonGroup ribbonGroup = this.class512_0.TXITEM_RowsAndColumnsGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_RowsAndColumnsGroup.ToString()] as RibbonGroup;
			if (this.class512_0.method_0(ribbonGroup) && (ribbonGroup.Enabled = table_0 != null || base.m_txTextControl == null))
			{
				RibbonButton ribbonButton = this.class512_0.TXITEM_RowsAndColumnsGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_InsertTableRowAbove.ToString()] as RibbonButton;
				RibbonButton ribbonButton2 = this.class512_0.TXITEM_RowsAndColumnsGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_InsertTableRowBelow.ToString()] as RibbonButton;
				if (this.class512_0.method_2(ribbonButton) || this.class512_0.method_2(ribbonButton2))
				{
					bool enabled = (ribbonButton2.Enabled = base.m_txTextControl == null || table_0.Rows.CanAdd);
					ribbonButton.Enabled = enabled;
				}
				RibbonButton ribbonButton3 = this.class512_0.TXITEM_RowsAndColumnsGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_InsertTableColLeft.ToString()] as RibbonButton;
				RibbonButton ribbonButton4 = this.class512_0.TXITEM_RowsAndColumnsGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_InsertTableColRight.ToString()] as RibbonButton;
				if (this.class512_0.method_2(ribbonButton3) || this.class512_0.method_2(ribbonButton4))
				{
					bool enabled2 = (ribbonButton4.Enabled = base.m_txTextControl == null || table_0.Columns.CanAdd);
					ribbonButton3.Enabled = enabled2;
				}
			}
		}

		private void method_69(Table table_0)
		{
			RibbonGroup ribbonGroup = this.class512_0.TXITEM_MergeGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_MergeGroup.ToString()] as RibbonGroup;
			if (this.class512_0.method_0(ribbonGroup) && (ribbonGroup.Enabled = table_0 != null || base.m_txTextControl == null))
			{
				RibbonButton ribbonButton = this.class512_0.TXITEM_MergeGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_MergeTableCells.ToString()] as RibbonButton;
				if (this.class512_0.method_2(ribbonButton))
				{
					ribbonButton.Enabled = base.m_txTextControl == null || table_0.CanMergeCells;
				}
				RibbonButton ribbonButton2 = this.class512_0.TXITEM_MergeGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_SplitTableCells.ToString()] as RibbonButton;
				if (this.class512_0.method_2(ribbonButton2))
				{
					ribbonButton2.Enabled = base.m_txTextControl == null || table_0.CanSplitCells;
				}
				RibbonMenuButton ribbonMenuButton = this.class512_0.TXITEM_MergeGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_SplitTable.ToString()] as RibbonMenuButton;
				if (this.class512_0.method_2(ribbonMenuButton))
				{
					ribbonMenuButton.Enabled = base.m_txTextControl == null || table_0.CanSplit;
				}
			}
		}

		private void method_70(Table table_0)
		{
			RibbonGroup ribbonGroup = this.class512_0.TXITEM_BordersAndBackgroundGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_BordersAndBackgroundGroup.ToString()] as RibbonGroup;
			if (this.class512_0.method_0(ribbonGroup))
			{
				ribbonGroup.Enabled = table_0 != null || base.m_txTextControl == null;
				this.method_72();
				this.method_81();
				this.method_82();
				this.method_83();
			}
		}

		private void method_71(Table table_0)
		{
			RibbonGroup ribbonGroup_ = this.class512_0.TXITEM_TableAlignmentGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableAlignmentGroup.ToString()] as RibbonGroup;
			if (this.class512_0.method_0(ribbonGroup_))
			{
				this.method_84(ribbonGroup_, table_0, bool_0: true);
			}
		}

		protected override Color? GetCurrentColor(string colorButtonName)
		{
			Color? result = null;
			if (base.m_txTextControl != null)
			{
				switch (colorButtonName)
				{
				case "TXITEM_TableBackColor":
					return base.m_txTextControl.InputFormat.FrameFillColor;
				case "TXITEM_TableLineColor":
					return base.m_txTextControl.InputFormat.FrameLineColor;
				}
			}
			return result;
		}

		private void method_72()
		{
			RibbonMenuButton object_ = this.class512_0.TXITEM_BordersAndBackgroundGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableFrameLines.ToString()] as RibbonMenuButton;
			if (this.class512_0.method_3(object_))
			{
				this.method_73();
				this.method_74();
				this.method_75();
				this.method_76();
				this.method_77();
				this.method_78();
				this.method_79();
				this.method_80();
			}
		}

		private void method_73()
		{
			RibbonToggleButton ribbonToggleButton = this.class512_0.TXITEM_BordersAndBackgroundGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableLeftFrameLine.ToString()] as RibbonToggleButton;
			if (this.class512_0.method_2(ribbonToggleButton))
			{
				ribbonToggleButton.Checked = base.m_txTextControl.InputFormat.LeftFrameLine;
			}
		}

		private void method_74()
		{
			RibbonToggleButton ribbonToggleButton = this.class512_0.TXITEM_BordersAndBackgroundGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableTopFrameLine.ToString()] as RibbonToggleButton;
			if (this.class512_0.method_2(ribbonToggleButton))
			{
				ribbonToggleButton.Checked = base.m_txTextControl.InputFormat.TopFrameLine;
			}
		}

		private void method_75()
		{
			RibbonToggleButton ribbonToggleButton = this.class512_0.TXITEM_BordersAndBackgroundGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableRightFrameLine.ToString()] as RibbonToggleButton;
			if (this.class512_0.method_2(ribbonToggleButton))
			{
				ribbonToggleButton.Checked = base.m_txTextControl.InputFormat.RightFrameLine;
			}
		}

		private void method_76()
		{
			RibbonToggleButton ribbonToggleButton = this.class512_0.TXITEM_BordersAndBackgroundGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableBottomFrameLine.ToString()] as RibbonToggleButton;
			if (this.class512_0.method_2(ribbonToggleButton))
			{
				ribbonToggleButton.Checked = base.m_txTextControl.InputFormat.BottomFrameLine;
			}
		}

		private void method_77()
		{
			RibbonToggleButton ribbonToggleButton = this.class512_0.TXITEM_BordersAndBackgroundGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableBoxFrame.ToString()] as RibbonToggleButton;
			if (this.class512_0.method_2(ribbonToggleButton))
			{
				ribbonToggleButton.Checked = base.m_txTextControl.InputFormat.BoxFrame;
			}
		}

		private void method_78()
		{
			RibbonToggleButton ribbonToggleButton = this.class512_0.TXITEM_BordersAndBackgroundGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableAllFrameLines.ToString()] as RibbonToggleButton;
			if (this.class512_0.method_2(ribbonToggleButton))
			{
				ribbonToggleButton.Checked = base.m_txTextControl.InputFormat.AllFrameLines;
			}
		}

		private void method_79()
		{
			RibbonToggleButton ribbonToggleButton = this.class512_0.TXITEM_BordersAndBackgroundGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableInnerHorizontalFrameLines.ToString()] as RibbonToggleButton;
			if (this.class512_0.method_2(ribbonToggleButton))
			{
				ribbonToggleButton.Checked = base.m_txTextControl.InputFormat.InnerHorizontalFrameLines;
			}
		}

		private void method_80()
		{
			RibbonToggleButton ribbonToggleButton = this.class512_0.TXITEM_BordersAndBackgroundGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableInnerVerticalFrameLines.ToString()] as RibbonToggleButton;
			if (this.class512_0.method_2(ribbonToggleButton))
			{
				ribbonToggleButton.Checked = base.m_txTextControl.InputFormat.InnerVerticalFrameLines;
			}
		}

		private void method_81()
		{
			RibbonMenuButton ribbonMenuButton = this.class512_0.TXITEM_BordersAndBackgroundGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableBackColor.ToString()] as RibbonMenuButton;
			if (this.class512_0.method_2(ribbonMenuButton))
			{
				Class517.smethod_59(ribbonMenuButton, base.m_txTextControl.InputFormat.FrameFillColor, bool_0: false, base.m_pntDPI);
			}
			RibbonToggleButton ribbonToggleButton = this.class512_0.TXITEM_BordersAndBackgroundGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableBackColor_Transparent.ToString()] as RibbonToggleButton;
			if (this.class512_0.method_2(ribbonToggleButton))
			{
				ribbonToggleButton.Checked = base.m_txTextControl.InputFormat.FrameFillColor.HasValue && base.m_txTextControl.InputFormat.FrameFillColor.HasValue && base.m_txTextControl.InputFormat.FrameFillColor.Value.Name == Color.Transparent.Name;
			}
		}

		private void method_82()
		{
			RibbonMenuButton ribbonMenuButton = this.class512_0.TXITEM_BordersAndBackgroundGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableLineColor.ToString()] as RibbonMenuButton;
			if (this.class512_0.method_2(ribbonMenuButton))
			{
				Class517.smethod_59(ribbonMenuButton, base.m_txTextControl.InputFormat.FrameLineColor, bool_0: false, base.m_pntDPI);
			}
			RibbonToggleButton ribbonToggleButton = this.class512_0.TXITEM_BordersAndBackgroundGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableLineColor_Automatic.ToString()] as RibbonToggleButton;
			if (this.class512_0.method_2(ribbonToggleButton))
			{
				ribbonToggleButton.Checked = base.m_txTextControl.InputFormat.FrameLineColor.HasValue && base.m_txTextControl.InputFormat.FrameLineColor.Value.IsNamedColor && base.m_txTextControl.InputFormat.FrameLineColor.Value.Name == SystemColors.WindowText.Name;
			}
		}

		private void method_83()
		{
			RibbonMenuButton ribbonMenuButton = this.class512_0.TXITEM_BordersAndBackgroundGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableLineWidth.ToString()] as RibbonMenuButton;
			if (!this.class512_0.method_3(ribbonMenuButton))
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

		private void method_84(RibbonGroup ribbonGroup_0, Table table_0, bool bool_0)
		{
			ribbonGroup_0.Enabled = table_0 != null && bool_0;
			if (table_0 != null)
			{
				RibbonToggleButton ribbonToggleButton = this.class512_0.TXITEM_TableAlignmentGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_CellAlignTopLeft.ToString()] as RibbonToggleButton;
				if (this.class512_0.method_2(ribbonToggleButton))
				{
					ribbonToggleButton.Checked = base.m_txTextControl.InputFormat.LeftAligned.HasValue && base.m_txTextControl.InputFormat.LeftAligned.Value && base.m_txTextControl.InputFormat.TopAligned.HasValue && base.m_txTextControl.InputFormat.TopAligned.Value;
				}
				RibbonToggleButton ribbonToggleButton2 = this.class512_0.TXITEM_TableAlignmentGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_CellAlignTopCentered.ToString()] as RibbonToggleButton;
				if (this.class512_0.method_2(ribbonToggleButton2))
				{
					ribbonToggleButton2.Checked = base.m_txTextControl.InputFormat.Centered.HasValue && base.m_txTextControl.InputFormat.Centered.Value && base.m_txTextControl.InputFormat.TopAligned.HasValue && base.m_txTextControl.InputFormat.TopAligned.Value;
				}
				RibbonToggleButton ribbonToggleButton3 = this.class512_0.TXITEM_TableAlignmentGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_CellAlignTopRight.ToString()] as RibbonToggleButton;
				if (this.class512_0.method_2(ribbonToggleButton3))
				{
					ribbonToggleButton3.Checked = base.m_txTextControl.InputFormat.RightAligned.HasValue && base.m_txTextControl.InputFormat.RightAligned.Value && base.m_txTextControl.InputFormat.TopAligned.HasValue && base.m_txTextControl.InputFormat.TopAligned.Value;
				}
				RibbonToggleButton ribbonToggleButton4 = this.class512_0.TXITEM_TableAlignmentGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_CellAlignTopJustified.ToString()] as RibbonToggleButton;
				if (this.class512_0.method_2(ribbonToggleButton4))
				{
					ribbonToggleButton4.Checked = base.m_txTextControl.InputFormat.Justified.HasValue && base.m_txTextControl.InputFormat.Justified.Value && base.m_txTextControl.InputFormat.TopAligned.HasValue && base.m_txTextControl.InputFormat.TopAligned.Value;
				}
				RibbonToggleButton ribbonToggleButton5 = this.class512_0.TXITEM_TableAlignmentGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_CellAlignMiddleLeft.ToString()] as RibbonToggleButton;
				if (this.class512_0.method_2(ribbonToggleButton5))
				{
					ribbonToggleButton5.Checked = base.m_txTextControl.InputFormat.LeftAligned.HasValue && base.m_txTextControl.InputFormat.LeftAligned.Value && base.m_txTextControl.InputFormat.VerticallyCentered.HasValue && base.m_txTextControl.InputFormat.VerticallyCentered.Value;
				}
				RibbonToggleButton ribbonToggleButton6 = this.class512_0.TXITEM_TableAlignmentGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_CellAlignMiddleCentered.ToString()] as RibbonToggleButton;
				if (this.class512_0.method_2(ribbonToggleButton6))
				{
					ribbonToggleButton6.Checked = base.m_txTextControl.InputFormat.Centered.HasValue && base.m_txTextControl.InputFormat.Centered.Value && base.m_txTextControl.InputFormat.VerticallyCentered.HasValue && base.m_txTextControl.InputFormat.VerticallyCentered.Value;
				}
				RibbonToggleButton ribbonToggleButton7 = this.class512_0.TXITEM_TableAlignmentGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_CellAlignMiddleRight.ToString()] as RibbonToggleButton;
				if (this.class512_0.method_2(ribbonToggleButton7))
				{
					ribbonToggleButton7.Checked = base.m_txTextControl.InputFormat.RightAligned.HasValue && base.m_txTextControl.InputFormat.RightAligned.Value && base.m_txTextControl.InputFormat.VerticallyCentered.HasValue && base.m_txTextControl.InputFormat.VerticallyCentered.Value;
				}
				RibbonToggleButton ribbonToggleButton8 = this.class512_0.TXITEM_TableAlignmentGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_CellAlignMiddleJustified.ToString()] as RibbonToggleButton;
				if (this.class512_0.method_2(ribbonToggleButton8))
				{
					ribbonToggleButton8.Checked = base.m_txTextControl.InputFormat.Justified.HasValue && base.m_txTextControl.InputFormat.Justified.Value && base.m_txTextControl.InputFormat.VerticallyCentered.HasValue && base.m_txTextControl.InputFormat.VerticallyCentered.Value;
				}
				RibbonToggleButton ribbonToggleButton9 = this.class512_0.TXITEM_TableAlignmentGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_CellAlignBottomLeft.ToString()] as RibbonToggleButton;
				if (this.class512_0.method_2(ribbonToggleButton9))
				{
					ribbonToggleButton9.Checked = base.m_txTextControl.InputFormat.LeftAligned.HasValue && base.m_txTextControl.InputFormat.LeftAligned.Value && base.m_txTextControl.InputFormat.BottomAligned.HasValue && base.m_txTextControl.InputFormat.BottomAligned.Value;
				}
				RibbonToggleButton ribbonToggleButton10 = this.class512_0.TXITEM_TableAlignmentGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_CellAlignBottomCentered.ToString()] as RibbonToggleButton;
				if (this.class512_0.method_2(ribbonToggleButton10))
				{
					ribbonToggleButton10.Checked = base.m_txTextControl.InputFormat.Centered.HasValue && base.m_txTextControl.InputFormat.Centered.Value && base.m_txTextControl.InputFormat.BottomAligned.HasValue && base.m_txTextControl.InputFormat.BottomAligned.Value;
				}
				RibbonToggleButton ribbonToggleButton11 = this.class512_0.TXITEM_TableAlignmentGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_CellAlignBottomRight.ToString()] as RibbonToggleButton;
				if (this.class512_0.method_2(ribbonToggleButton11))
				{
					ribbonToggleButton11.Checked = base.m_txTextControl.InputFormat.LeftAligned.HasValue && base.m_txTextControl.InputFormat.RightAligned.Value && base.m_txTextControl.InputFormat.BottomAligned.HasValue && base.m_txTextControl.InputFormat.BottomAligned.Value;
				}
				RibbonToggleButton ribbonToggleButton12 = this.class512_0.TXITEM_TableAlignmentGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_CellAlignBottomJustified.ToString()] as RibbonToggleButton;
				if (this.class512_0.method_2(ribbonToggleButton12))
				{
					ribbonToggleButton12.Checked = base.m_txTextControl.InputFormat.LeftAligned.HasValue && base.m_txTextControl.InputFormat.Justified.Value && base.m_txTextControl.InputFormat.BottomAligned.HasValue && base.m_txTextControl.InputFormat.BottomAligned.Value;
				}
			}
		}

		internal void method_85(Table table_0)
		{
			if (!((this.class512_0.TXITEM_TableLayoutGroup_Items[RibbonTableLayoutTab.InternalRibbonItem.TXITEM_TableLayoutGroup.ToString()] as RibbonGroup).Visible = table_0 != null || base.m_txTextControl == null))
			{
				return;
			}
			RibbonMenuButton ribbonMenuButton = this.class512_0.TXITEM_TableLayoutGroup_Items[TextMiniToolbar.InternalRibbonItem.TXITEM_TableSelect.ToString()] as RibbonMenuButton;
			foreach (Control dropDownItem in ribbonMenuButton.DropDownItems)
			{
				switch (dropDownItem.Name)
				{
				case "TXITEM_SelectTableRow":
					dropDownItem.Enabled = base.m_txTextControl == null || table_0.Rows.GetItem() != null;
					break;
				case "TXITEM_SelectTableCol":
					dropDownItem.Enabled = base.m_txTextControl == null || table_0.Columns.GetItem() != null;
					break;
				case "TXITEM_SelectTableCell":
					dropDownItem.Enabled = base.m_txTextControl == null || table_0.Cells.GetItem() != null;
					break;
				}
			}
			(this.class512_0.TXITEM_TableLayoutGroup_Items[TextMiniToolbar.InternalRibbonItem.TXITEM_TableSelect.ToString()] as RibbonMenuButton).Visible = base.m_txTextControl != null && base.m_txTextControl.Selection.Length == 0;
			(this.class512_0.TXITEM_TableLayoutGroup_Items[TextMiniToolbar.InternalRibbonItem.TXITEM_TableMergeCells.ToString()] as RibbonButton).Visible = table_0?.CanMergeCells ?? true;
			(this.class512_0.TXITEM_TableLayoutGroup_Items[TextMiniToolbar.InternalRibbonItem.TXITEM_TableInsert.ToString()] as RibbonMenuButton).Visible = table_0 == null || table_0.Rows.CanAdd || table_0.Columns.CanAdd;
			(this.class512_0.TXITEM_TableLayoutGroup_Items[TextMiniToolbar.InternalRibbonItem.TXITEM_TableSplitCells.ToString()] as RibbonButton).Visible = table_0?.CanSplitCells ?? true;
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_SelectTableCell_Handler(object sender, EventArgs e)
		{
			this.method_6();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_SelectTableCol_Handler(object sender, EventArgs e)
		{
			this.method_7();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_SelectTableRow_Handler(object sender, EventArgs e)
		{
			this.method_8();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_SelectTableAll_Handler(object sender, EventArgs e)
		{
			this.method_9();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_TableGridLines_Handler(object sender, EventArgs e)
		{
			this.method_10((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_TableProperties_Handler(object sender, EventArgs e)
		{
			this.method_11();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_DeleteTableCell_Handler(object sender, EventArgs e)
		{
			this.method_12();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_DeleteTableCol_Handler(object sender, EventArgs e)
		{
			this.method_13();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_DeleteTableRow_Handler(object sender, EventArgs e)
		{
			this.method_14();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_DeleteTableAll_Handler(object sender, EventArgs e)
		{
			this.method_15();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertTableRowAbove_Handler(object sender, EventArgs e)
		{
			this.method_16();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertTableRowBelow_Handler(object sender, EventArgs e)
		{
			this.method_17();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertTableColLeft_Handler(object sender, EventArgs e)
		{
			this.method_18();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertTableColRight_Handler(object sender, EventArgs e)
		{
			this.method_19();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_MergeTableCells_Handler(object sender, EventArgs e)
		{
			this.method_20();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_SplitTableCells_Handler(object sender, EventArgs e)
		{
			this.method_21();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_SplitTableAbove_Handler(object sender, EventArgs e)
		{
			this.method_22();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_SplitTableBelow_Handler(object sender, EventArgs e)
		{
			this.method_23();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_BordersAndBackgroundGroup_Handler(object sender, EventArgs e)
		{
			this.method_24();
		}

		[Obfuscation(Exclude = true)]
		protected void TXITEM_TableLeftFrameLine_Handler(object sender, EventArgs e)
		{
			this.method_25((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		protected void TXITEM_TableTopFrameLine_Handler(object sender, EventArgs e)
		{
			this.method_26((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		protected void TXITEM_TableRightFrameLine_Handler(object sender, EventArgs e)
		{
			this.method_27((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		protected void TXITEM_TableBottomFrameLine_Handler(object sender, EventArgs e)
		{
			this.method_28((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		protected void TXITEM_TableBoxFrame_Handler(object sender, EventArgs e)
		{
			this.method_29((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		protected void TXITEM_TableAllFrameLines_Handler(object sender, EventArgs e)
		{
			this.method_30((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		protected void TXITEM_TableInnerHorizontalFrameLines_Handler(object sender, EventArgs e)
		{
			this.method_31((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		protected void TXITEM_TableInnerVerticalFrameLines_Handler(object sender, EventArgs e)
		{
			this.method_32((sender as RibbonToggleButton).Checked);
		}

		protected override void DefaultColorButton_Click(object sender, EventArgs e)
		{
			this.method_33(sender as RibbonToggleButton);
		}

		protected override void ColorListView_ItemClick(object sender, RibbonListView.RibbonListViewItemEventArgs e)
		{
			this.method_34(sender as RibbonListView, (Color)e.Item.Tag);
		}

		protected override void MoreColorsButton_Click(object sender, EventArgs e)
		{
			this.method_35(sender as RibbonButton);
		}

		protected override void LineWidthItem_Click(object sender, EventArgs e)
		{
			this.method_36(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_TableAlignmentGroup_Handler(object sender, EventArgs e)
		{
			this.method_37();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_CellAlignTopLeft_Handler(object sender, EventArgs e)
		{
			this.method_38(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_CellAlignTopCentered_Handler(object sender, EventArgs e)
		{
			this.method_39(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_CellAlignTopRight_Handler(object sender, EventArgs e)
		{
			this.method_40(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_CellAlignTopJustified_Handler(object sender, EventArgs e)
		{
			this.method_41(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_CellAlignMiddleLeft_Handler(object sender, EventArgs e)
		{
			this.method_42(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_CellAlignMiddleCentered_Handler(object sender, EventArgs e)
		{
			this.method_43(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_CellAlignMiddleRight_Handler(object sender, EventArgs e)
		{
			this.method_44(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_CellAlignMiddleJustified_Handler(object sender, EventArgs e)
		{
			this.method_45(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_CellAlignBottomLeft_Handler(object sender, EventArgs e)
		{
			this.method_46(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_CellAlignBottomCentered_Handler(object sender, EventArgs e)
		{
			this.method_47(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_CellAlignBottomRight_Handler(object sender, EventArgs e)
		{
			this.method_48(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_CellAlignBottomJustified_Handler(object sender, EventArgs e)
		{
			this.method_49(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_TableMergeCells_Handler(object sender, EventArgs e)
		{
			this.method_50();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_TableSplitCells_Handler(object sender, EventArgs e)
		{
			this.method_51();
		}

		internal void method_86(object sender, EventArgs e)
		{
			this.method_52();
		}

		[Obfuscation(Exclude = true)]
		internal void InputFormat_AlignedChanged(object sender, EventArgs e)
		{
			this.method_64();
		}

		internal void method_87(object sender, EventArgs e)
		{
			this.method_53();
		}

		internal void method_88(object sender, EventArgs e)
		{
			this.method_54();
		}

		internal void method_89(object sender, EventArgs e)
		{
			this.method_55();
		}

		internal void method_90(object sender, EventArgs e)
		{
			this.method_56();
		}

		internal void method_91(object sender, EventArgs e)
		{
			this.method_57();
		}

		internal void method_92(object sender, EventArgs e)
		{
			this.method_58();
		}

		internal void method_93(object sender, EventArgs e)
		{
			this.method_59();
		}

		internal void method_94(object sender, EventArgs e)
		{
			this.method_60();
		}

		internal void method_95(object sender, EventArgs e)
		{
			this.method_61();
		}

		internal void method_96(object sender, EventArgs e)
		{
			this.method_62();
		}

		internal void method_97(object sender, EventArgs e)
		{
			this.method_63();
		}
	}
}
