using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class513 : Class500
	{
		private Dictionary<string, object> dictionary_0 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_1 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_2 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_3 = new Dictionary<string, object>();

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_DocumentViewsGroup_Items => this.dictionary_0;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_ZoomGroup_Items => this.dictionary_1;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_ToolbarsGroup_Items => this.dictionary_2;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_ShowGroup_Items => this.dictionary_3;

		internal Class513(Control control_1, BindingAdapter bindingAdapter_1)
			: base(control_1, bindingAdapter_1)
		{
		}

		internal void method_10(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_0, ribbonGroup, RibbonViewTab.InternalRibbonItem.TXITEM_DocumentViewsGroup.ToString(), null, null);
			RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
			ribbonToggleButton.Name = RibbonViewTab.InternalRibbonItem.TXITEM_PrintLayout.ToString();
			RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
			RibbonToggleButton ribbonToggleButton3 = new RibbonToggleButton();
			ribbonToggleButton3.Name = RibbonViewTab.InternalRibbonItem.TXITEM_Draft.ToString();
			RibbonToggleButton ribbonToggleButton4 = ribbonToggleButton3;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonToggleButton2, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonToggleButton4, "Click", hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[2] { ribbonToggleButton2, ribbonToggleButton4 });
			Class517.smethod_29(this.dictionary_0);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_11(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_1, ribbonGroup, RibbonViewTab.InternalRibbonItem.TXITEM_ZoomGroup.ToString(), null, null);
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonViewTab.InternalRibbonItem.TXITEM_ZoomFactor.ToString();
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			RibbonButton ribbonButton = new RibbonButton();
			ribbonButton.Name = RibbonViewTab.InternalRibbonItem.TXITEM_Zoom100.ToString();
			RibbonButton ribbonButton2 = ribbonButton;
			RibbonButton ribbonButton3 = new RibbonButton();
			ribbonButton3.Name = RibbonViewTab.InternalRibbonItem.TXITEM_FullPage.ToString();
			ribbonButton3.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonButton ribbonButton4 = ribbonButton3;
			RibbonButton ribbonButton5 = new RibbonButton();
			ribbonButton5.Name = RibbonViewTab.InternalRibbonItem.TXITEM_PageWidth.ToString();
			ribbonButton5.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonButton ribbonButton6 = ribbonButton5;
			RibbonButton ribbonButton7 = new RibbonButton();
			ribbonButton7.Name = RibbonViewTab.InternalRibbonItem.TXITEM_TextWidth.ToString();
			ribbonButton7.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonButton ribbonButton8 = ribbonButton7;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonMenuButton2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonButton2, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonButton4, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonButton6, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonButton8, null, hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[5] { ribbonMenuButton2, ribbonButton2, ribbonButton4, ribbonButton6, ribbonButton8 });
			Class517.smethod_29(this.dictionary_1);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_12(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_2, ribbonGroup, RibbonViewTab.InternalRibbonItem.TXITEM_ToolbarsGroup.ToString(), null, null);
			RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
			ribbonToggleButton.Name = RibbonViewTab.InternalRibbonItem.TXITEM_HorizontalRuler.ToString();
			ribbonToggleButton.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
			RibbonToggleButton ribbonToggleButton3 = new RibbonToggleButton();
			ribbonToggleButton3.Name = RibbonViewTab.InternalRibbonItem.TXITEM_VerticalRuler.ToString();
			ribbonToggleButton3.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonToggleButton ribbonToggleButton4 = ribbonToggleButton3;
			RibbonToggleButton ribbonToggleButton5 = new RibbonToggleButton();
			ribbonToggleButton5.Name = RibbonViewTab.InternalRibbonItem.TXITEM_StatusBar.ToString();
			ribbonToggleButton5.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonToggleButton ribbonToggleButton6 = ribbonToggleButton5;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonToggleButton2, "CheckedChanged", hasImage: false);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonToggleButton4, "CheckedChanged", hasImage: false);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonToggleButton6, "CheckedChanged", hasImage: false);
			ribbonGroup.RibbonItems.AddRange(new Control[3] { ribbonToggleButton2, ribbonToggleButton4, ribbonToggleButton6 });
			Class517.smethod_29(this.dictionary_2);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_13(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_3, ribbonGroup, RibbonViewTab.InternalRibbonItem.TXITEM_ShowGroup.ToString(), null, null);
			RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
			ribbonToggleButton.Name = RibbonViewTab.InternalRibbonItem.TXITEM_ShowTableGridlines.ToString();
			ribbonToggleButton.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
			RibbonToggleButton ribbonToggleButton3 = new RibbonToggleButton();
			ribbonToggleButton3.Name = RibbonViewTab.InternalRibbonItem.TXITEM_ShowBookmarkMarkers.ToString();
			ribbonToggleButton3.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonToggleButton ribbonToggleButton4 = ribbonToggleButton3;
			RibbonToggleButton ribbonToggleButton5 = new RibbonToggleButton();
			ribbonToggleButton5.Name = RibbonViewTab.InternalRibbonItem.TXITEM_ShowTextFrameMarkersLines.ToString();
			ribbonToggleButton5.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonToggleButton ribbonToggleButton6 = ribbonToggleButton5;
			RibbonToggleButton ribbonToggleButton7 = new RibbonToggleButton();
			ribbonToggleButton7.Name = RibbonViewTab.InternalRibbonItem.TXITEM_ShowDrawingFrameMarkersLines.ToString();
			ribbonToggleButton7.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonToggleButton ribbonToggleButton8 = ribbonToggleButton7;
			RibbonToggleButton ribbonToggleButton9 = new RibbonToggleButton();
			ribbonToggleButton9.Name = RibbonViewTab.InternalRibbonItem.TXITEM_ShowControlChars.ToString();
			ribbonToggleButton9.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonToggleButton ribbonToggleButton10 = ribbonToggleButton9;
			RibbonToggleButton ribbonToggleButton11 = new RibbonToggleButton();
			ribbonToggleButton11.Name = RibbonViewTab.InternalRibbonItem.TXITEM_ShowFrameAnchors.ToString();
			ribbonToggleButton11.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonToggleButton ribbonToggleButton12 = ribbonToggleButton11;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonToggleButton2, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonToggleButton4, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonToggleButton6, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonToggleButton8, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonToggleButton10, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonToggleButton12, "CheckedChanged", hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[6] { ribbonToggleButton2, ribbonToggleButton4, ribbonToggleButton6, ribbonToggleButton8, ribbonToggleButton10, ribbonToggleButton12 });
			Class517.smethod_29(this.dictionary_3);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}
	}
}
