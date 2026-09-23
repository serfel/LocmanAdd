using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class510 : Class500
	{
		private Dictionary<string, object> dictionary_0 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_1 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_2 = new Dictionary<string, object>();

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_TableOfContentsGroup_Items => this.dictionary_0;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_TableOfContentsPropertiesGroup_Items => this.dictionary_1;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_ParagraphStructureLevelsGroup_Items => this.dictionary_2;

		internal Class510(Control control_1, BindingAdapter bindingAdapter_1)
			: base(control_1, bindingAdapter_1)
		{
		}

		internal void method_10(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_0, ribbonGroup, RibbonReferencesTab.InternalRibbonItem.TXITEM_TableOfContentsGroup.ToString(), null, null);
			RibbonButton ribbonButton = new RibbonButton();
			ribbonButton.Name = RibbonReferencesTab.InternalRibbonItem.TXITEM_InsertTableOfContents.ToString();
			RibbonButton ribbonButton2 = ribbonButton;
			RibbonButton ribbonButton3 = new RibbonButton();
			ribbonButton3.Name = RibbonReferencesTab.InternalRibbonItem.TXITEM_DeleteTableOfContents.ToString();
			RibbonButton ribbonButton4 = ribbonButton3;
			RibbonButton ribbonButton5 = new RibbonButton();
			ribbonButton5.Name = RibbonReferencesTab.InternalRibbonItem.TXITEM_UpdateTableOfContents.ToString();
			RibbonButton ribbonButton6 = ribbonButton5;
			RibbonButton ribbonButton7 = new RibbonButton();
			ribbonButton7.Name = RibbonReferencesTab.InternalRibbonItem.TXITEM_ModifyTableOfContents.ToString();
			RibbonButton ribbonButton8 = ribbonButton7;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonButton2, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonButton4, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonButton6, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonButton8, "Click", hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[4] { ribbonButton2, ribbonButton4, ribbonButton6, ribbonButton8 });
			base.list_0.Add(ribbonGroup);
			Class517.smethod_29(this.dictionary_0);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_11(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_1, ribbonGroup, RibbonReferencesTab.InternalRibbonItem.TXITEM_TableOfContentsPropertiesGroup.ToString(), null, null);
			RibbonTextBox ribbonTextBox = new RibbonTextBox();
			ribbonTextBox.Name = RibbonReferencesTab.InternalRibbonItem.TXITEM_TOCMinimumStructureLevel.ToString();
			ribbonTextBox.TextBoxWidth = Class519.Class539.Int32_1;
			ribbonTextBox.DisplayMode = IconTextRelation.SmallIconLabeled;
			ribbonTextBox.TextAlign = (System.Windows.Forms.HorizontalAlignment)HorizontalAlignment.Right;
			RibbonTextBox ribbonTextBox2 = ribbonTextBox;
			RibbonTextBox ribbonTextBox3 = new RibbonTextBox();
			ribbonTextBox3.Name = RibbonReferencesTab.InternalRibbonItem.TXITEM_TOCMaximumStructureLevel.ToString();
			ribbonTextBox3.TextBoxWidth = Class519.Class539.Int32_1;
			ribbonTextBox3.DisplayMode = IconTextRelation.SmallIconLabeled;
			ribbonTextBox3.TextAlign = (System.Windows.Forms.HorizontalAlignment)HorizontalAlignment.Right;
			RibbonTextBox ribbonTextBox4 = ribbonTextBox3;
			RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
			ribbonToggleButton.Name = RibbonReferencesTab.InternalRibbonItem.TXITEM_TOCCreateHyperlinks.ToString();
			ribbonToggleButton.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
			RibbonTextBox ribbonTextBox5 = new RibbonTextBox();
			ribbonTextBox5.Name = RibbonReferencesTab.InternalRibbonItem.TXITEM_TOCTitle.ToString();
			ribbonTextBox5.TextBoxWidth = Class519.Class539.Int32_0;
			ribbonTextBox5.DisplayMode = IconTextRelation.SmallIconLabeled;
			ribbonTextBox5.TextAlign = (System.Windows.Forms.HorizontalAlignment)HorizontalAlignment.Left;
			RibbonTextBox ribbonTextBox6 = ribbonTextBox5;
			RibbonToggleButton ribbonToggleButton3 = new RibbonToggleButton();
			ribbonToggleButton3.Name = RibbonReferencesTab.InternalRibbonItem.TXITEM_TOCShowPageNumbers.ToString();
			ribbonToggleButton3.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonToggleButton ribbonToggleButton4 = ribbonToggleButton3;
			RibbonToggleButton ribbonToggleButton5 = new RibbonToggleButton();
			ribbonToggleButton5.Name = RibbonReferencesTab.InternalRibbonItem.TXITEM_TOCRightAlignPageNumbers.ToString();
			ribbonToggleButton5.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonToggleButton ribbonToggleButton6 = ribbonToggleButton5;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonTextBox2, "TextValidated", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonTextBox4, "TextValidated", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonToggleButton2, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonTextBox6, "TextValidated", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonToggleButton4, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonToggleButton6, "Click", hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[6] { ribbonTextBox2, ribbonTextBox4, ribbonToggleButton2, ribbonTextBox6, ribbonToggleButton4, ribbonToggleButton6 });
			base.list_0.Add(ribbonGroup);
			Class517.smethod_29(this.dictionary_1);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_12(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			ribbonGroup.RowCount = 2;
			RibbonGroup ribbonGroup2 = ribbonGroup;
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_2, ribbonGroup2, RibbonReferencesTab.InternalRibbonItem.TXITEM_ParagraphStructureLevelsGroup.ToString(), null, null);
			RibbonListView ribbonListView = new RibbonListView();
			ribbonListView.Name = RibbonReferencesTab.InternalRibbonItem.TXITEM_StructureLevelStyles.ToString();
			ribbonListView.MaxVisibleRows = 2;
			ribbonListView.MaxColumnCount = 1;
			ribbonListView.MinColumnCount = 1;
			ribbonListView.MinRowCount = 3;
			ribbonListView.HideSelectedItems = false;
			ribbonListView.MultiSelect = false;
			ribbonListView.ViewMode = (RibbonListView.ListViewMode)6;
			ribbonListView.ShowBorder = true;
			ribbonListView.ScrollButtonsVisible = true;
			ribbonListView.ShowItemsInDropDown = true;
			ribbonListView.Boolean_4 = false;
			ribbonListView.MinimumWidth = 250;
			RibbonListView ribbonListView2 = ribbonListView;
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonReferencesTab.InternalRibbonItem.TXITEM_AddParagraph.ToString();
			ribbonMenuButton.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonListView2, null, hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonMenuButton2, null, hasImage: true);
			ribbonGroup2.RibbonItems.AddRange(new Control[2] { ribbonListView2, ribbonMenuButton2 });
			base.list_0.Add(ribbonGroup2);
			Class517.smethod_29(this.dictionary_2);
			ribbonGroupCollection_0.Add(ribbonGroup2);
		}
	}
}
