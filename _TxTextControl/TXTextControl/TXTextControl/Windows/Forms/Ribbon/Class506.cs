using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class506 : Class500
	{
		private Dictionary<string, object> dictionary_0 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_1 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_2 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_3 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_4 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_5 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_6 = new Dictionary<string, object>();

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_PageGroup_Items => this.dictionary_0;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_TableGroup_Items => this.dictionary_1;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_IllustrationsGroup_Items => this.dictionary_2;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_LinksGroup_Items => this.dictionary_3;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_HeaderFooterGroup_Items => this.dictionary_4;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_TextGroup_Items => this.dictionary_5;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_SymbolsGroup_Items => this.dictionary_6;

		internal Class506(Control control_1, BindingAdapter bindingAdapter_1)
			: base(control_1, bindingAdapter_1)
		{
		}

		internal void method_10(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_0, ribbonGroup, RibbonInsertTab.InternalRibbonItem.TXITEM_PageGroup.ToString(), null, null);
			RibbonButton ribbonButton = new RibbonButton();
			ribbonButton.Name = RibbonInsertTab.InternalRibbonItem.TXITEM_InsertPage.ToString();
			RibbonButton ribbonButton2 = ribbonButton;
			RibbonButton ribbonButton3 = new RibbonButton();
			ribbonButton3.Name = RibbonInsertTab.InternalRibbonItem.TXITEM_InsertPageBreak.ToString();
			RibbonButton ribbonButton4 = ribbonButton3;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonButton2, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonButton4, "Click", hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[2] { ribbonButton2, ribbonButton4 });
			base.list_0.Add(ribbonGroup);
			Class517.smethod_29(this.dictionary_0);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_11(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_1, ribbonGroup, RibbonInsertTab.InternalRibbonItem.TXITEM_TableGroup.ToString(), null, null);
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonInsertTab.InternalRibbonItem.TXITEM_InsertTable.ToString();
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonMenuButton2, null, hasImage: true);
			ribbonGroup.RibbonItems.Add(ribbonMenuButton2);
			base.list_0.Add(ribbonGroup);
			Class517.smethod_29(this.dictionary_1);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_12(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_2, ribbonGroup, RibbonInsertTab.InternalRibbonItem.TXITEM_IllustrationsGroup.ToString(), null, null);
			RibbonSplitButton ribbonSplitButton = new RibbonSplitButton();
			ribbonSplitButton.Name = RibbonInsertTab.InternalRibbonItem.TXITEM_InsertImage.ToString();
			RibbonSplitButton ribbonSplitButton2 = ribbonSplitButton;
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonInsertTab.InternalRibbonItem.TXITEM_InsertChart.ToString();
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			RibbonMenuButton ribbonMenuButton3 = new RibbonMenuButton();
			ribbonMenuButton3.Name = RibbonInsertTab.InternalRibbonItem.TXITEM_InsertShape.ToString();
			RibbonMenuButton ribbonMenuButton4 = ribbonMenuButton3;
			RibbonSplitButton ribbonSplitButton3 = new RibbonSplitButton();
			ribbonSplitButton3.Name = RibbonInsertTab.InternalRibbonItem.TXITEM_InsertBarcode.ToString();
			RibbonSplitButton ribbonSplitButton4 = ribbonSplitButton3;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonSplitButton2, "ButtonClick", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonMenuButton2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonMenuButton4, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonSplitButton4, "ButtonClick", hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[4] { ribbonSplitButton2, ribbonMenuButton2, ribbonMenuButton4, ribbonSplitButton4 });
			base.list_0.AddRange(new IEnabledItem[3] { ribbonSplitButton2, ribbonMenuButton2, ribbonSplitButton4 });
			foreach (Control dropDownItem in ribbonMenuButton4.DropDownItems)
			{
				if (dropDownItem.Name != "TXITEM_DrawingMarkerLines")
				{
					base.list_0.Add(dropDownItem as IEnabledItem);
				}
			}
			Class517.smethod_29(this.dictionary_2);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_13(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_3, ribbonGroup, RibbonInsertTab.InternalRibbonItem.TXITEM_LinksGroup.ToString(), null, null);
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonInsertTab.InternalRibbonItem.TXITEM_InsertHyperlink.ToString();
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			RibbonMenuButton ribbonMenuButton3 = new RibbonMenuButton();
			ribbonMenuButton3.Name = RibbonInsertTab.InternalRibbonItem.TXITEM_InsertBookmark.ToString();
			RibbonMenuButton ribbonMenuButton4 = ribbonMenuButton3;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonMenuButton2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonMenuButton4, null, hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[2] { ribbonMenuButton2, ribbonMenuButton4 });
			base.list_0.Add(ribbonMenuButton2);
			foreach (Control dropDownItem in ribbonMenuButton4.DropDownItems)
			{
				if (dropDownItem.Name != "TXITEM_DocumentTargetMarkers")
				{
					base.list_0.Add(dropDownItem as IEnabledItem);
				}
			}
			Class517.smethod_29(this.dictionary_3);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_14(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_4, ribbonGroup, RibbonInsertTab.InternalRibbonItem.TXITEM_HeaderFooterGroup.ToString(), null, null);
			RibbonSplitButton ribbonSplitButton = new RibbonSplitButton();
			ribbonSplitButton.Name = RibbonInsertTab.InternalRibbonItem.TXITEM_InsertHeader.ToString();
			RibbonSplitButton ribbonSplitButton2 = ribbonSplitButton;
			RibbonSplitButton ribbonSplitButton3 = new RibbonSplitButton();
			ribbonSplitButton3.Name = RibbonInsertTab.InternalRibbonItem.TXITEM_InsertFooter.ToString();
			RibbonSplitButton ribbonSplitButton4 = ribbonSplitButton3;
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonInsertTab.InternalRibbonItem.TXITEM_InsertPageNumber.ToString();
			ribbonMenuButton.Enabled = false;
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonSplitButton2, "ButtonClick", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonSplitButton4, "ButtonClick", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_4, ribbonMenuButton2, null, hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[3] { ribbonSplitButton2, ribbonSplitButton4, ribbonMenuButton2 });
			base.list_0.AddRange(new IEnabledItem[3]
			{
				this.dictionary_4[RibbonInsertTab.InternalRibbonItem.TXITEM_RemoveHeader.ToString()] as IEnabledItem,
				this.dictionary_4[RibbonInsertTab.InternalRibbonItem.TXITEM_RemoveFooter.ToString()] as IEnabledItem,
				ribbonMenuButton2
			});
			Class517.smethod_29(this.dictionary_4);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_15(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_5, ribbonGroup, RibbonInsertTab.InternalRibbonItem.TXITEM_TextGroup.ToString(), null, null);
			RibbonSplitButton ribbonSplitButton = new RibbonSplitButton();
			ribbonSplitButton.Name = RibbonInsertTab.InternalRibbonItem.TXITEM_InsertTextFrame.ToString();
			RibbonSplitButton ribbonSplitButton2 = ribbonSplitButton;
			RibbonButton ribbonButton = new RibbonButton();
			ribbonButton.Name = RibbonInsertTab.InternalRibbonItem.TXITEM_InsertFile.ToString();
			RibbonButton ribbonButton2 = ribbonButton;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_5, ribbonSplitButton2, "ButtonClick", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_5, ribbonButton2, "Click", hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[2] { ribbonSplitButton2, ribbonButton2 });
			base.list_0.AddRange(new IEnabledItem[2]
			{
				this.dictionary_5[RibbonInsertTab.InternalRibbonItem.TXITEM_AddTextFrame.ToString()] as IEnabledItem,
				ribbonButton2
			});
			Class517.smethod_29(this.dictionary_5);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_16(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_6, ribbonGroup, RibbonInsertTab.InternalRibbonItem.TXITEM_SymbolsGroup.ToString(), null, null);
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonInsertTab.InternalRibbonItem.TXITEM_InsertSymbol.ToString();
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_6, ribbonMenuButton2, null, hasImage: true);
			ribbonGroup.RibbonItems.Add(ribbonMenuButton2);
			base.list_0.Add(ribbonMenuButton2);
			Class517.smethod_29(this.dictionary_6);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}
	}
}
