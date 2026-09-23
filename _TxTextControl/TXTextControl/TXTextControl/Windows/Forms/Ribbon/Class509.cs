using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class509 : Class500
	{
		private Dictionary<string, object> dictionary_0 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_1 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_2 = new Dictionary<string, object>();

		private Dictionary<string, object> dictionary_3 = new Dictionary<string, object>();

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_SpellingAndHyphenationGroup_Items => this.dictionary_0;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_ProofingSettingsGroup_Items => this.dictionary_1;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_TrackChangesGroup_Items => this.dictionary_2;

		[Obfuscation(Exclude = true)]
		internal Dictionary<string, object> TXITEM_LanguageGroup_Items => this.dictionary_3;

		internal Class509(Control control_1, BindingAdapter bindingAdapter_1)
			: base(control_1, bindingAdapter_1)
		{
		}

		internal void method_10(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_0, ribbonGroup, RibbonProofingTab.InternalRibbonItem.TXITEM_SpellingAndHyphenationGroup.ToString(), null, null);
			RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
			ribbonToggleButton.Name = RibbonProofingTab.InternalRibbonItem.TXITEM_EnableSpellChecking.ToString();
			RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
			RibbonToggleButton ribbonToggleButton3 = new RibbonToggleButton();
			ribbonToggleButton3.Name = RibbonProofingTab.InternalRibbonItem.TXITEM_EnableHyphenations.ToString();
			RibbonToggleButton ribbonToggleButton4 = ribbonToggleButton3;
			RibbonButton ribbonButton = new RibbonButton();
			ribbonButton.Name = RibbonProofingTab.InternalRibbonItem.TXITEM_Thesaurus.ToString();
			RibbonButton ribbonButton2 = ribbonButton;
			RibbonButton ribbonButton3 = new RibbonButton();
			ribbonButton3.Name = RibbonProofingTab.InternalRibbonItem.TXITEM_Spelling.ToString();
			RibbonButton ribbonButton4 = ribbonButton3;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonToggleButton2, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonToggleButton4, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonButton2, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_0, ribbonButton4, "Click", hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[4] { ribbonToggleButton2, ribbonToggleButton4, ribbonButton2, ribbonButton4 });
			base.list_0.Add(ribbonGroup);
			Class517.smethod_29(this.dictionary_0);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_11(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_1, ribbonGroup, RibbonProofingTab.InternalRibbonItem.TXITEM_ProofingSettingsGroup.ToString(), null, null);
			RibbonButton ribbonButton = new RibbonButton();
			ribbonButton.Name = RibbonProofingTab.InternalRibbonItem.TXITEM_LoadDictionary.ToString();
			RibbonButton ribbonButton2 = ribbonButton;
			RibbonButton ribbonButton3 = new RibbonButton();
			ribbonButton3.Name = RibbonProofingTab.InternalRibbonItem.TXITEM_LoadThesaurusFile.ToString();
			RibbonButton ribbonButton4 = ribbonButton3;
			RibbonButton ribbonButton5 = new RibbonButton();
			ribbonButton5.Name = RibbonProofingTab.InternalRibbonItem.TXITEM_SpellingOptions.ToString();
			RibbonButton ribbonButton6 = ribbonButton5;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonButton2, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonButton4, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_1, ribbonButton6, "Click", hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[3] { ribbonButton2, ribbonButton4, ribbonButton6 });
			base.list_0.Add(ribbonGroup);
			Class517.smethod_29(this.dictionary_1);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_12(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_2, ribbonGroup, RibbonProofingTab.InternalRibbonItem.TXITEM_TrackChangesGroup.ToString(), null, null);
			RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
			ribbonToggleButton.Name = RibbonProofingTab.InternalRibbonItem.TXITEM_TrackChanges.ToString();
			ribbonToggleButton.IsScalable = false;
			RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
			RibbonSplitButton ribbonSplitButton = new RibbonSplitButton();
			ribbonSplitButton.Name = RibbonProofingTab.InternalRibbonItem.TXITEM_AcceptTrackedChange.ToString();
			ribbonSplitButton.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonSplitButton ribbonSplitButton2 = ribbonSplitButton;
			RibbonSplitButton ribbonSplitButton3 = new RibbonSplitButton();
			ribbonSplitButton3.Name = RibbonProofingTab.InternalRibbonItem.TXITEM_RejectTrackedChange.ToString();
			ribbonSplitButton3.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonSplitButton ribbonSplitButton4 = ribbonSplitButton3;
			RibbonButton ribbonButton = new RibbonButton();
			ribbonButton.Name = RibbonProofingTab.InternalRibbonItem.TXITEM_TrackedChanges.ToString();
			ribbonButton.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonButton ribbonButton2 = ribbonButton;
			RibbonSplitButton ribbonSplitButton5 = new RibbonSplitButton();
			ribbonSplitButton5.Name = RibbonProofingTab.InternalRibbonItem.TXITEM_TrackedChanges_Sidebars.ToString();
			ribbonSplitButton5.DisplayMode = IconTextRelation.SmallIconLabeled;
			ribbonSplitButton5.Checkable = true;
			RibbonSplitButton ribbonItem = ribbonSplitButton5;
			RibbonButton ribbonButton3 = new RibbonButton();
			ribbonButton3.Name = RibbonProofingTab.InternalRibbonItem.TXITEM_PreviousTrackedChange.ToString();
			ribbonButton3.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonButton ribbonButton4 = ribbonButton3;
			RibbonButton ribbonButton5 = new RibbonButton();
			ribbonButton5.Name = RibbonProofingTab.InternalRibbonItem.TXITEM_NextTrackedChange.ToString();
			ribbonButton5.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonButton ribbonButton6 = ribbonButton5;
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
			ribbonMenuButton.Name = RibbonProofingTab.InternalRibbonItem.TXITEM_ShowMarkup.ToString();
			ribbonMenuButton.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonToggleButton2, "CheckedChanged", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonSplitButton2, "ButtonClick", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonSplitButton4, "ButtonClick", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonButton2, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonItem, "ButtonClick", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonButton4, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonButton6, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_2, ribbonMenuButton2, null, hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[7] { ribbonToggleButton2, ribbonSplitButton2, ribbonSplitButton4, ribbonButton2, ribbonButton4, ribbonButton6, ribbonMenuButton2 });
			base.list_0.Add(ribbonGroup);
			Class517.smethod_29(this.dictionary_2);
			ribbonButton2.Name = RibbonProofingTab.InternalRibbonItem.TXITEM_TrackedChanges_Dialog.ToString();
			this.dictionary_2.Add(ribbonButton2.Name, ribbonButton2);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}

		internal void method_13(RibbonGroupCollection ribbonGroupCollection_0)
		{
			RibbonGroup ribbonGroup = new RibbonGroup();
			base.bindingAdapter_0.SetRibbonGroupAppearance(this.dictionary_3, ribbonGroup, RibbonProofingTab.InternalRibbonItem.TXITEM_LanguageGroup.ToString(), null, null);
			RibbonButton ribbonButton = new RibbonButton();
			ribbonButton.Name = RibbonProofingTab.InternalRibbonItem.TXITEM_DetectLanguages.ToString();
			RibbonButton ribbonButton2 = ribbonButton;
			RibbonButton ribbonButton3 = new RibbonButton();
			ribbonButton3.Name = RibbonProofingTab.InternalRibbonItem.TXITEM_SetLanguage.ToString();
			RibbonButton ribbonButton4 = ribbonButton3;
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonButton2, "Click", hasImage: true);
			base.bindingAdapter_0.SetRibbonItemAppearance(this.dictionary_3, ribbonButton4, "Click", hasImage: true);
			ribbonGroup.RibbonItems.AddRange(new Control[2] { ribbonButton2, ribbonButton4 });
			base.list_0.Add(ribbonGroup);
			Class517.smethod_29(this.dictionary_3);
			ribbonGroupCollection_0.Add(ribbonGroup);
		}
	}
}
