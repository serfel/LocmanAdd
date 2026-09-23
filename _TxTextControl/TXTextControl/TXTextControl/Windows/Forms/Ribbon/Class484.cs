using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using TXTextControl;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class484 : BindingAdapter
	{
		private Class513 class513_0;

		internal override Class500 RibbonGroupManager
		{
			get
			{
				return this.class513_0;
			}
			set
			{
				this.class513_0 = value as Class513;
			}
		}

		private void method_0(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonViewTab.InternalRibbonItem.TXITEM_ZoomFactor_25.ToString(), null, this);
				ribbonToggleButton.Tag = 25;
				ribbonToggleButton.Click += method_22;
				RibbonToggleButton ribbonToggleButton2 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonViewTab.InternalRibbonItem.TXITEM_ZoomFactor_50.ToString(), null, this);
				ribbonToggleButton2.Tag = 50;
				ribbonToggleButton2.Click += method_22;
				RibbonToggleButton ribbonToggleButton3 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonViewTab.InternalRibbonItem.TXITEM_ZoomFactor_75.ToString(), null, this);
				ribbonToggleButton3.Tag = 75;
				ribbonToggleButton3.Click += method_22;
				RibbonToggleButton ribbonToggleButton4 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonViewTab.InternalRibbonItem.TXITEM_ZoomFactor_100.ToString(), null, this);
				ribbonToggleButton4.Tag = 100;
				ribbonToggleButton4.Click += method_22;
				RibbonToggleButton ribbonToggleButton5 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonViewTab.InternalRibbonItem.TXITEM_ZoomFactor_150.ToString(), null, this);
				ribbonToggleButton5.Tag = 150;
				ribbonToggleButton5.Click += method_22;
				RibbonToggleButton ribbonToggleButton6 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonViewTab.InternalRibbonItem.TXITEM_ZoomFactor_200.ToString(), null, this);
				ribbonToggleButton6.Tag = 200;
				ribbonToggleButton6.Click += method_22;
				RibbonToggleButton ribbonToggleButton7 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonViewTab.InternalRibbonItem.TXITEM_ZoomFactor_400.ToString(), null, this);
				ribbonToggleButton7.Tag = 400;
				ribbonToggleButton7.Click += method_22;
				ribbonMenuButton.DropDownItems.AddRange(new Control[7] { ribbonToggleButton, ribbonToggleButton2, ribbonToggleButton3, ribbonToggleButton4, ribbonToggleButton5, ribbonToggleButton6, ribbonToggleButton7 });
			}
		}

		internal override void SetRibbonItemAppearance(Dictionary<string, object> groupItemsDictionary, Control ribbonItem, string eventName, bool hasImage)
		{
			base.SetBasicRibbonItemAppearance(groupItemsDictionary, ribbonItem, hasImage);
			switch (ribbonItem.Name)
			{
			case "TXITEM_FullPage":
			case "TXITEM_PageWidth":
			case "TXITEM_TextWidth":
				(ribbonItem as RibbonButton).Click += method_23;
				break;
			case "TXITEM_ZoomFactor":
				this.method_0(groupItemsDictionary, ribbonItem);
				break;
			}
			if (!string.IsNullOrEmpty(eventName))
			{
				Class517.smethod_23(ribbonItem, eventName, ribbonItem.Name + "_Handler", this);
			}
		}

		internal override void OnDisconnectingTextControl()
		{
			base.m_txTextControl.Zoomed -= method_24;
		}

		internal override void OnTextControlConnected()
		{
			base.m_txTextControl.Zoomed += method_24;
		}

		private void method_1()
		{
			this.method_21("TXITEM_PrintLayout");
		}

		private void method_2()
		{
			this.method_21("TXITEM_Draft");
		}

		private void method_3(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				ribbonToggleButton_0.Checked = true;
				if (((IRibbonItem)ribbonToggleButton_0).IsDefaultRibbonTabItem)
				{
					int zoomFactor = (int)ribbonToggleButton_0.Tag;
					base.m_txTextControl.ZoomFactor = zoomFactor;
				}
			}
		}

		private void method_4()
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.ZoomFactor = 100;
			}
		}

		private void method_5(RibbonButton ribbonButton_0)
		{
			if (base.m_txTextControl != null && ribbonButton_0 != null)
			{
				switch (ribbonButton_0.Name)
				{
				case "TXITEM_TextWidth":
					base.m_txTextControl.Zoom(ZoomOption.TextWidth);
					break;
				case "TXITEM_PageWidth":
					base.m_txTextControl.Zoom(ZoomOption.PageWidth);
					break;
				case "TXITEM_FullPage":
					base.m_txTextControl.Zoom(ZoomOption.WholePage);
					break;
				}
			}
		}

		private void method_6(bool bool_0)
		{
			if (base.m_txTextControl != null && base.m_txTextControl.RulerBar != null)
			{
				base.m_txTextControl.RulerBar.Visible = bool_0;
			}
		}

		private void method_7(bool bool_0)
		{
			if (base.m_txTextControl != null && base.m_txTextControl.VerticalRulerBar != null)
			{
				base.m_txTextControl.VerticalRulerBar.Visible = bool_0;
			}
		}

		private void method_8(bool bool_0)
		{
			if (base.m_txTextControl != null && base.m_txTextControl.StatusBar != null)
			{
				base.m_txTextControl.StatusBar.Visible = bool_0;
			}
		}

		private void method_9(bool bool_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.Tables.GridLines = bool_0;
			}
		}

		private void method_10(bool bool_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.DocumentTargetMarkers = bool_0;
			}
		}

		private void method_11(bool bool_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.TextFrameMarkerLines = bool_0;
			}
		}

		private void method_12(bool bool_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.DrawingMarkerLines = bool_0;
			}
		}

		private void method_13(bool bool_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.ControlChars = bool_0;
			}
		}

		private void method_14(bool bool_0)
		{
			if (base.m_txTextControl != null)
			{
				PermanentControlChar permanentControlChar = (PermanentControlChar)0;
				bool flag = (base.m_txTextControl.PermanentControlChars & PermanentControlChar.All) == PermanentControlChar.All;
				permanentControlChar = (PermanentControlChar)0 | ((flag || (base.m_txTextControl.PermanentControlChars & PermanentControlChar.ForcedLineBreak) == PermanentControlChar.ForcedLineBreak) ? PermanentControlChar.ForcedLineBreak : ((PermanentControlChar)0));
				permanentControlChar |= ((flag || (base.m_txTextControl.PermanentControlChars & PermanentControlChar.ForcedPageBreak) == PermanentControlChar.ForcedPageBreak) ? PermanentControlChar.ForcedPageBreak : ((PermanentControlChar)0));
				permanentControlChar |= ((flag || (base.m_txTextControl.PermanentControlChars & PermanentControlChar.Hyphen) == PermanentControlChar.Hyphen) ? PermanentControlChar.Hyphen : ((PermanentControlChar)0));
				permanentControlChar |= ((flag || (base.m_txTextControl.PermanentControlChars & PermanentControlChar.NonBreakingSpace) == PermanentControlChar.NonBreakingSpace) ? PermanentControlChar.NonBreakingSpace : ((PermanentControlChar)0));
				permanentControlChar |= ((flag || (base.m_txTextControl.PermanentControlChars & PermanentControlChar.ParagraphEnd) == PermanentControlChar.ParagraphEnd) ? PermanentControlChar.ParagraphEnd : ((PermanentControlChar)0));
				permanentControlChar |= ((flag || (base.m_txTextControl.PermanentControlChars & PermanentControlChar.SectionBreak) == PermanentControlChar.SectionBreak) ? PermanentControlChar.SectionBreak : ((PermanentControlChar)0));
				permanentControlChar |= ((flag || (base.m_txTextControl.PermanentControlChars & PermanentControlChar.Space) == PermanentControlChar.Space) ? PermanentControlChar.Space : ((PermanentControlChar)0));
				permanentControlChar |= ((flag || (base.m_txTextControl.PermanentControlChars & PermanentControlChar.Tab) == PermanentControlChar.Tab) ? PermanentControlChar.Tab : ((PermanentControlChar)0));
				permanentControlChar |= ((flag || (base.m_txTextControl.PermanentControlChars & PermanentControlChar.TableCellEnd) == PermanentControlChar.TableCellEnd) ? PermanentControlChar.TableCellEnd : ((PermanentControlChar)0));
				permanentControlChar |= (bool_0 ? (base.m_txTextControl.PermanentControlChars | PermanentControlChar.ObjectAnchor) : ((PermanentControlChar)0));
				base.m_txTextControl.PermanentControlChars = permanentControlChar;
			}
		}

		private void method_15()
		{
			this.method_17();
		}

		internal override void UpdateRibbonTab(params object[] args)
		{
			this.method_16();
			this.method_17();
			this.method_18();
			this.method_19();
		}

		internal void method_16()
		{
			RibbonGroup ribbonGroup_ = this.class513_0.TXITEM_DocumentViewsGroup_Items[RibbonViewTab.InternalRibbonItem.TXITEM_DocumentViewsGroup.ToString()] as RibbonGroup;
			if (this.class513_0.method_0(ribbonGroup_))
			{
				RibbonToggleButton ribbonToggleButton = this.class513_0.TXITEM_DocumentViewsGroup_Items[RibbonViewTab.InternalRibbonItem.TXITEM_PrintLayout.ToString()] as RibbonToggleButton;
				if (this.class513_0.method_2(ribbonToggleButton))
				{
					ribbonToggleButton.Checked = base.m_txTextControl.ViewMode == ViewMode.PageView;
				}
				RibbonToggleButton ribbonToggleButton2 = this.class513_0.TXITEM_DocumentViewsGroup_Items[RibbonViewTab.InternalRibbonItem.TXITEM_Draft.ToString()] as RibbonToggleButton;
				if (this.class513_0.method_2(ribbonToggleButton2))
				{
					ribbonToggleButton2.Checked = base.m_txTextControl.ViewMode == ViewMode.Normal;
				}
			}
		}

		private void method_17()
		{
			RibbonMenuButton ribbonMenuButton = this.class513_0.TXITEM_ZoomGroup_Items[RibbonViewTab.InternalRibbonItem.TXITEM_ZoomFactor.ToString()] as RibbonMenuButton;
			if (!this.class513_0.method_2(ribbonMenuButton))
			{
				return;
			}
			int zoomFactor = base.m_txTextControl.ZoomFactor;
			foreach (Control dropDownItem in ribbonMenuButton.DropDownItems)
			{
				RibbonToggleButton ribbonToggleButton = dropDownItem as RibbonToggleButton;
				if (ribbonToggleButton != null && ((IRibbonItem)ribbonToggleButton).IsDefaultRibbonTabItem)
				{
					ribbonToggleButton.Checked = zoomFactor == (int)ribbonToggleButton.Tag;
				}
			}
		}

		internal void method_18()
		{
			RibbonGroup ribbonGroup_ = this.class513_0.TXITEM_ToolbarsGroup_Items[RibbonViewTab.InternalRibbonItem.TXITEM_ToolbarsGroup.ToString()] as RibbonGroup;
			if (this.class513_0.method_0(ribbonGroup_))
			{
				RibbonToggleButton ribbonToggleButton = this.class513_0.TXITEM_ToolbarsGroup_Items[RibbonViewTab.InternalRibbonItem.TXITEM_HorizontalRuler.ToString()] as RibbonToggleButton;
				if (this.class513_0.method_2(ribbonToggleButton))
				{
					this.method_20(ribbonToggleButton, base.m_txTextControl.RulerBar);
				}
				RibbonToggleButton ribbonToggleButton2 = this.class513_0.TXITEM_ToolbarsGroup_Items[RibbonViewTab.InternalRibbonItem.TXITEM_VerticalRuler.ToString()] as RibbonToggleButton;
				if (this.class513_0.method_2(ribbonToggleButton2))
				{
					this.method_20(ribbonToggleButton2, base.m_txTextControl.VerticalRulerBar);
				}
				RibbonToggleButton ribbonToggleButton3 = this.class513_0.TXITEM_ToolbarsGroup_Items[RibbonViewTab.InternalRibbonItem.TXITEM_StatusBar.ToString()] as RibbonToggleButton;
				if (this.class513_0.method_2(ribbonToggleButton3))
				{
					this.method_20(ribbonToggleButton3, base.m_txTextControl.StatusBar);
				}
			}
		}

		internal void method_19()
		{
			RibbonGroup ribbonGroup_ = this.class513_0.TXITEM_ShowGroup_Items[RibbonViewTab.InternalRibbonItem.TXITEM_ShowGroup.ToString()] as RibbonGroup;
			if (this.class513_0.method_0(ribbonGroup_))
			{
				RibbonToggleButton ribbonToggleButton = this.class513_0.TXITEM_ShowGroup_Items[RibbonViewTab.InternalRibbonItem.TXITEM_ShowTableGridlines.ToString()] as RibbonToggleButton;
				if (this.class513_0.method_2(ribbonToggleButton))
				{
					ribbonToggleButton.Checked = base.m_txTextControl != null && base.m_txTextControl.Tables.GridLines;
				}
				RibbonToggleButton ribbonToggleButton2 = this.class513_0.TXITEM_ShowGroup_Items[RibbonViewTab.InternalRibbonItem.TXITEM_ShowBookmarkMarkers.ToString()] as RibbonToggleButton;
				if (this.class513_0.method_2(ribbonToggleButton2))
				{
					ribbonToggleButton2.Checked = base.m_txTextControl != null && base.m_txTextControl.DocumentTargetMarkers;
				}
				RibbonToggleButton ribbonToggleButton3 = this.class513_0.TXITEM_ShowGroup_Items[RibbonViewTab.InternalRibbonItem.TXITEM_ShowTextFrameMarkersLines.ToString()] as RibbonToggleButton;
				if (this.class513_0.method_2(ribbonToggleButton3))
				{
					ribbonToggleButton3.Checked = base.m_txTextControl != null && base.m_txTextControl.TextFrameMarkerLines;
				}
				RibbonToggleButton ribbonToggleButton4 = this.class513_0.TXITEM_ShowGroup_Items[RibbonViewTab.InternalRibbonItem.TXITEM_ShowDrawingFrameMarkersLines.ToString()] as RibbonToggleButton;
				if (this.class513_0.method_2(ribbonToggleButton4))
				{
					ribbonToggleButton4.Checked = base.m_txTextControl != null && base.m_txTextControl.DrawingMarkerLines;
				}
				RibbonToggleButton ribbonToggleButton5 = this.class513_0.TXITEM_ShowGroup_Items[RibbonViewTab.InternalRibbonItem.TXITEM_ShowControlChars.ToString()] as RibbonToggleButton;
				if (this.class513_0.method_2(ribbonToggleButton5))
				{
					ribbonToggleButton5.Checked = base.m_txTextControl != null && base.m_txTextControl.ControlChars;
				}
				RibbonToggleButton ribbonToggleButton6 = this.class513_0.TXITEM_ShowGroup_Items[RibbonViewTab.InternalRibbonItem.TXITEM_ShowFrameAnchors.ToString()] as RibbonToggleButton;
				if (this.class513_0.method_2(ribbonToggleButton6))
				{
					ribbonToggleButton6.Checked = base.m_txTextControl != null && (base.m_txTextControl.PermanentControlChars & PermanentControlChar.ObjectAnchor) == PermanentControlChar.ObjectAnchor;
				}
			}
		}

		private void method_20(Control control_0, Control control_1)
		{
			if (control_1 != null)
			{
				(control_0 as RibbonToggleButton).Checked = control_1.Visible;
			}
			else
			{
				control_0.Enabled = false;
			}
		}

		private void method_21(string string_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			RibbonToggleButton ribbonToggleButton = this.class513_0.TXITEM_DocumentViewsGroup_Items[RibbonViewTab.InternalRibbonItem.TXITEM_PrintLayout.ToString()] as RibbonToggleButton;
			RibbonToggleButton ribbonToggleButton2 = this.class513_0.TXITEM_DocumentViewsGroup_Items[RibbonViewTab.InternalRibbonItem.TXITEM_Draft.ToString()] as RibbonToggleButton;
			switch (string_0)
			{
			case "TXITEM_Draft":
				base.m_txTextControl.ViewMode = ViewMode.Normal;
				ribbonToggleButton2.Checked = true;
				if (this.class513_0.method_2(ribbonToggleButton))
				{
					ribbonToggleButton.Checked = false;
				}
				break;
			case "TXITEM_PrintLayout":
				base.m_txTextControl.ViewMode = ViewMode.PageView;
				ribbonToggleButton.Checked = true;
				if (this.class513_0.method_2(ribbonToggleButton2))
				{
					ribbonToggleButton2.Checked = false;
				}
				break;
			}
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_PrintLayout_Handler(object sender, EventArgs e)
		{
			this.method_1();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_Draft_Handler(object sender, EventArgs e)
		{
			this.method_2();
		}

		private void method_22(object sender, EventArgs e)
		{
			this.method_3(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_Zoom100_Handler(object sender, EventArgs e)
		{
			this.method_4();
		}

		private void method_23(object sender, EventArgs e)
		{
			this.method_5(sender as RibbonButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_HorizontalRuler_Handler(object sender, EventArgs e)
		{
			this.method_6((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_VerticalRuler_Handler(object sender, EventArgs e)
		{
			this.method_7((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_StatusBar_Handler(object sender, EventArgs e)
		{
			this.method_8((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_ShowTableGridlines_Handler(object sender, EventArgs e)
		{
			this.method_9((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_ShowBookmarkMarkers_Handler(object sender, EventArgs e)
		{
			this.method_10((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_ShowTextFrameMarkersLines_Handler(object sender, EventArgs e)
		{
			this.method_11((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_ShowDrawingFrameMarkersLines_Handler(object sender, EventArgs e)
		{
			this.method_12((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_ShowControlChars_Handler(object sender, EventArgs e)
		{
			this.method_13((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_ShowFrameAnchors_Handler(object sender, EventArgs e)
		{
			this.method_14((sender as RibbonToggleButton).Checked);
		}

		private void method_24(object sender, EventArgs e)
		{
			this.method_15();
		}
	}
}
