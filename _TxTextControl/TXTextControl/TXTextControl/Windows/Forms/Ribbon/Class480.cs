using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using ns23;
using TXTextControl;
using TXTextControl.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class480 : BindingAdapter
	{
		private Class509 class509_0;

		private OpenFileDialog openFileDialog_0 = new OpenFileDialog
		{
			Filter = "Dictionaries|*.dic|User Dictionaries|*.txd",
			Multiselect = true
		};

		private OpenFileDialog openFileDialog_1 = new OpenFileDialog
		{
			Filter = "Thesaurus File|*.dat",
			Multiselect = true
		};

		private Class415 class415_0;

		private Point point_0 = Point.Empty;

		private Size size_0 = Size.Empty;

		private bool bool_0 = true;

		private bool bool_1 = true;

		internal override Class500 RibbonGroupManager
		{
			get
			{
				return this.class509_0;
			}
			set
			{
				this.class509_0 = value as Class509;
			}
		}

		internal Class415 Class415_0
		{
			get
			{
				return this.class415_0;
			}
			set
			{
				this.class415_0 = value;
			}
		}

		private void method_0(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonSplitButton ribbonSplitButton = control_0 as RibbonSplitButton;
			if (ribbonSplitButton != null)
			{
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonProofingTab.InternalRibbonItem.TXITEM_AcceptTrackedChange_AcceptAndMoveToNext.ToString(), null, this);
				ribbonButton.Click += TXITEM_AcceptTrackedChange_Handler;
				RibbonButton ribbonButton2 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonProofingTab.InternalRibbonItem.TXITEM_AcceptTrackedChange_AcceptThisChange.ToString(), null, this);
				ribbonButton2.Click += method_40;
				RibbonButton ribbonButton3 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonProofingTab.InternalRibbonItem.TXITEM_AcceptTrackedChange_AcceptAllChanges.ToString(), null, this);
				ribbonButton3.Click += method_41;
				RibbonButton ribbonButton4 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonProofingTab.InternalRibbonItem.TXITEM_AcceptTrackedChange_AcceptAllChangesAndStopTracking.ToString(), null, this);
				ribbonButton4.Click += method_42;
				ribbonSplitButton.DropDownItems.AddRange(new Control[4] { ribbonButton, ribbonButton2, ribbonButton3, ribbonButton4 });
			}
		}

		private void method_1(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonSplitButton ribbonSplitButton = control_0 as RibbonSplitButton;
			if (ribbonSplitButton != null)
			{
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonProofingTab.InternalRibbonItem.TXITEM_RejectTrackedChange_RejectAndMoveToNext.ToString(), null, this);
				ribbonButton.Click += TXITEM_RejectTrackedChange_Handler;
				RibbonButton ribbonButton2 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonProofingTab.InternalRibbonItem.TXITEM_RejectTrackedChange_RejectThisChange.ToString(), null, this);
				ribbonButton2.Click += method_43;
				RibbonButton ribbonButton3 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonProofingTab.InternalRibbonItem.TXITEM_RejectTrackedChange_RejectAllChanges.ToString(), null, this);
				ribbonButton3.Click += method_44;
				RibbonButton ribbonButton4 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonProofingTab.InternalRibbonItem.TXITEM_RejectTrackedChange_RejectAllChangesAndStopTracking.ToString(), null, this);
				ribbonButton4.Click += method_45;
				ribbonSplitButton.DropDownItems.AddRange(new Control[4] { ribbonButton, ribbonButton2, ribbonButton3, ribbonButton4 });
			}
		}

		private void method_2(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonSplitButton)
			{
				RibbonSplitButton ribbonSplitButton = (RibbonSplitButton)control_0;
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonProofingTab.InternalRibbonItem.TXITEM_TrackedChanges_Sidebars_Vertical.ToString(), "null", this);
				ribbonToggleButton.CheckedChanged += method_49;
				RibbonToggleButton ribbonToggleButton2 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonProofingTab.InternalRibbonItem.TXITEM_TrackedChanges_Sidebars_Horizontal.ToString(), null, this);
				ribbonToggleButton2.CheckedChanged += method_49;
				ribbonSplitButton.DropDownItems.AddRange(new Control[2] { ribbonToggleButton, ribbonToggleButton2 });
			}
		}

		private void method_3(Dictionary<string, object> dictionary_0, Control control_0)
		{
			RibbonMenuButton ribbonMenuButton = control_0 as RibbonMenuButton;
			if (ribbonMenuButton != null)
			{
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonProofingTab.InternalRibbonItem.TXITEM_ShowMarkup_AllReviewers.ToString(), null, this);
				(ribbonButton as RibbonToggleButton).Checked = true;
				(ribbonButton as RibbonToggleButton).CheckedChanged += method_50;
				RibbonSeperator ribbonSeperator = new RibbonSeperator();
				ribbonSeperator.Name = RibbonProofingTab.InternalRibbonItem.TXITEM_ShowMarkupSeperator1.ToString();
				ribbonSeperator.Visible = false;
				RibbonSeperator ribbonSeperator2 = ribbonSeperator;
				dictionary_0.Add(ribbonSeperator2.Name, ribbonSeperator2);
				ribbonMenuButton.DropDownItems.AddRange(new Control[2] { ribbonButton, ribbonSeperator2 });
			}
		}

		internal override void AwareOfDPI(PointF dpi)
		{
			base.AwareOfDPI(dpi);
			RibbonProofingTab.InternalRibbonItem[] array = new RibbonProofingTab.InternalRibbonItem[2]
			{
				RibbonProofingTab.InternalRibbonItem.TXITEM_TrackedChanges_Dialog,
				RibbonProofingTab.InternalRibbonItem.TXITEM_TrackedChanges_Sidebars
			};
			RibbonProofingTab.InternalRibbonItem[] array2 = array;
			foreach (RibbonProofingTab.InternalRibbonItem internalRibbonItem in array2)
			{
				RibbonButton ribbonButton = this.class509_0.TXITEM_TrackChangesGroup_Items[internalRibbonItem.ToString()] as RibbonButton;
				if (ribbonButton.SmallIcon == null)
				{
					ribbonButton.SmallIcon = Class517.smethod_53(internalRibbonItem.ToString(), ImageProvider.ImageKind.Small_16x16, dpi);
				}
			}
		}

		internal override void SetRibbonItemAppearance(Dictionary<string, object> groupItemsDictionary, Control ribbonItem, string eventName, bool hasImage)
		{
			base.SetBasicRibbonItemAppearance(groupItemsDictionary, ribbonItem, hasImage);
			switch (ribbonItem.Name)
			{
			case "TXITEM_TrackedChanges_Sidebars":
				this.method_2(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_ShowMarkup":
				this.method_3(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_RejectTrackedChange":
				this.method_1(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_AcceptTrackedChange":
				this.method_0(groupItemsDictionary, ribbonItem);
				break;
			}
			if (eventName != null)
			{
				Class517.smethod_23(ribbonItem, eventName, ribbonItem.Name + "_Handler", this);
			}
		}

		internal override void OnDisconnectingTextControl()
		{
			this.class415_0 = null;
			base.m_txTextControl.TrackedChangeCreated -= method_53;
			base.m_txTextControl.TrackedChangeDeleted -= method_52;
		}

		internal override void OnTextControlConnected()
		{
			if ((this.class415_0 = new Class415(base.m_txTextControl.SpellChecker, bool_1: false)).Object_0 == null)
			{
				this.class415_0 = null;
			}
			else if (base.m_txTextControl.SpellChecker == null)
			{
				base.m_txTextControl.SpellChecker = this.class415_0.Object_0 as Component;
			}
			RibbonToggleButton ribbonToggleButton = this.class509_0.TXITEM_SpellingAndHyphenationGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_EnableSpellChecking.ToString()] as RibbonToggleButton;
			ribbonToggleButton.Checked = base.m_txTextControl.IsSpellCheckingEnabled;
			RibbonToggleButton ribbonToggleButton2 = this.class509_0.TXITEM_SpellingAndHyphenationGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_EnableHyphenations.ToString()] as RibbonToggleButton;
			ribbonToggleButton2.Checked = base.m_txTextControl.IsHyphenationEnabled;
			RibbonButton ribbonButton = this.class509_0.TXITEM_SpellingAndHyphenationGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_Spelling.ToString()] as RibbonButton;
			ribbonButton.Enabled = base.m_txTextControl.IsSpellCheckingEnabled;
			if (this.class415_0 != null)
			{
				this.openFileDialog_0.InitialDirectory = Class517.smethod_22(this.class415_0.method_38(), "Dictionaries");
			}
			if (this.class415_0 != null)
			{
				this.openFileDialog_1.InitialDirectory = Class517.smethod_22(this.class415_0.method_38(), "SynonymLists");
			}
			RibbonToggleButton ribbonToggleButton3 = this.class509_0.TXITEM_TrackChangesGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_TrackChanges.ToString()] as RibbonToggleButton;
			ribbonToggleButton3.Checked = base.m_txTextControl.IsTrackChangesEnabled;
			base.m_txTextControl.TrackedChangeCreated += method_53;
			base.m_txTextControl.TrackedChangeDeleted += method_52;
		}

		private void method_4(bool bool_2)
		{
			if (base.m_txTextControl != null && base.m_txTextControl.SpellChecker != null)
			{
				RibbonButton ribbonButton = this.class509_0.TXITEM_SpellingAndHyphenationGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_Spelling.ToString()] as RibbonButton;
				base.m_txTextControl.IsSpellCheckingEnabled = bool_2;
				ribbonButton.Enabled = base.m_txTextControl.IsSpellCheckingEnabled && base.m_txTextControl.CanEdit;
			}
		}

		private void method_5(bool bool_2)
		{
			if (base.m_txTextControl != null && base.m_txTextControl.SpellChecker != null)
			{
				base.m_txTextControl.IsHyphenationEnabled = bool_2;
			}
		}

		private void method_6()
		{
			if (base.m_txTextControl != null)
			{
				ThesaurusDialog thesaurusDialog = new ThesaurusDialog(base.m_txTextControl);
				thesaurusDialog.Boolean_0 = true;
				thesaurusDialog.ShowDialog();
			}
		}

		private void method_7()
		{
			if (base.m_txTextControl != null && base.m_txTextControl.SpellChecker != null)
			{
				base.m_txTextControl.SpellCheckDialog();
			}
		}

		private void method_8()
		{
			if (this.class415_0 == null || this.openFileDialog_0.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			string[] fileNames = this.openFileDialog_0.FileNames;
			if (fileNames.Length > 0)
			{
				this.openFileDialog_0.InitialDirectory = Path.GetDirectoryName(fileNames[0]);
				string[] array = fileNames;
				foreach (string string_ in array)
				{
					this.class415_0.method_13(this.class415_0.CollectionBase_0, string_);
				}
			}
		}

		private void method_9()
		{
			if (this.class415_0 == null || this.openFileDialog_1.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			string[] fileNames = this.openFileDialog_1.FileNames;
			if (fileNames.Length > 0)
			{
				this.openFileDialog_1.InitialDirectory = Path.GetDirectoryName(fileNames[0]);
				string[] array = fileNames;
				foreach (string string_ in array)
				{
					this.class415_0.method_14(this.class415_0.CollectionBase_4, string_);
				}
			}
		}

		private void method_10()
		{
			if (base.m_txTextControl != null && base.m_txTextControl.SpellChecker != null)
			{
				MethodInfo method = base.m_txTextControl.SpellChecker.GetType().GetMethod("OptionsDialog", new Type[0]);
				if (method != null)
				{
					method.Invoke(base.m_txTextControl.SpellChecker, null);
				}
			}
		}

		private void method_11(bool bool_2)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.IsTrackChangesEnabled = bool_2;
			}
		}

		private void method_12()
		{
			if (base.m_txTextControl != null)
			{
				TrackedChangeCollection trackedChanges = base.m_txTextControl.TrackedChanges;
				TrackedChange item = trackedChanges.GetItem();
				if (item != null)
				{
					trackedChanges.Remove(item, accept: true);
				}
				item = trackedChanges.GetItem();
				if (item == null)
				{
					item = trackedChanges.GetItem(next: true);
				}
				item?.Select();
			}
		}

		private void method_13()
		{
			if (base.m_txTextControl != null)
			{
				TrackedChangeCollection trackedChanges = base.m_txTextControl.TrackedChanges;
				TrackedChange item = trackedChanges.GetItem();
				if (item != null)
				{
					trackedChanges.Remove(item, accept: true);
				}
			}
		}

		private void method_14()
		{
			if (base.m_txTextControl != null)
			{
				TrackedChangeCollection trackedChanges = base.m_txTextControl.TrackedChanges;
				TrackedChangeCollection.TrackedChangeEnumerator enumerator = trackedChanges.GetEnumerator();
				while (enumerator.MoveNext())
				{
					trackedChanges.Remove(enumerator.Current as TrackedChange, accept: true);
					enumerator.Reset();
				}
			}
		}

		private void method_15()
		{
			if (base.m_txTextControl != null)
			{
				TrackedChangeCollection trackedChanges = base.m_txTextControl.TrackedChanges;
				TrackedChangeCollection.TrackedChangeEnumerator enumerator = trackedChanges.GetEnumerator();
				while (enumerator.MoveNext())
				{
					trackedChanges.Remove(enumerator.Current as TrackedChange, accept: true);
					enumerator.Reset();
				}
				(this.class509_0.TXITEM_TrackChangesGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_TrackChanges.ToString()] as RibbonToggleButton).Checked = false;
				base.m_txTextControl.IsTrackChangesEnabled = false;
			}
		}

		private void method_16()
		{
			if (base.m_txTextControl != null)
			{
				TrackedChangeCollection trackedChanges = base.m_txTextControl.TrackedChanges;
				TrackedChange item = trackedChanges.GetItem();
				if (item != null)
				{
					trackedChanges.Remove(item, accept: false);
				}
				item = trackedChanges.GetItem();
				if (item == null)
				{
					item = trackedChanges.GetItem(next: true);
				}
				item?.Select();
			}
		}

		private void method_17()
		{
			if (base.m_txTextControl != null)
			{
				TrackedChangeCollection trackedChanges = base.m_txTextControl.TrackedChanges;
				TrackedChange item = trackedChanges.GetItem();
				if (item != null)
				{
					trackedChanges.Remove(item, accept: false);
				}
			}
		}

		private void method_18()
		{
			if (base.m_txTextControl != null)
			{
				TrackedChangeCollection trackedChanges = base.m_txTextControl.TrackedChanges;
				TrackedChangeCollection.TrackedChangeEnumerator enumerator = trackedChanges.GetEnumerator();
				while (enumerator.MoveNext())
				{
					trackedChanges.Remove(enumerator.Current as TrackedChange, accept: false);
					enumerator.Reset();
				}
			}
		}

		private void method_19()
		{
			if (base.m_txTextControl != null)
			{
				TrackedChangeCollection trackedChanges = base.m_txTextControl.TrackedChanges;
				TrackedChangeCollection.TrackedChangeEnumerator enumerator = trackedChanges.GetEnumerator();
				while (enumerator.MoveNext())
				{
					trackedChanges.Remove(enumerator.Current as TrackedChange, accept: false);
					enumerator.Reset();
				}
				(this.class509_0.TXITEM_TrackChangesGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_TrackChanges.ToString()] as RibbonToggleButton).Checked = false;
				base.m_txTextControl.IsTrackChangesEnabled = false;
			}
		}

		private void method_20()
		{
			if (base.m_txTextControl != null)
			{
				TrackedChangesDialog trackedChangesDialog = new TrackedChangesDialog(base.m_txTextControl);
				trackedChangesDialog.Show(base.m_txTextControl);
			}
		}

		private void method_21(RibbonSplitButton ribbonSplitButton_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			RibbonProofingTab ribbonProofingTab = this.class509_0.Control_0 as RibbonProofingTab;
			if (ribbonProofingTab == null)
			{
				return;
			}
			if (ribbonSplitButton_0.Checked)
			{
				bool @checked = (this.class509_0.TXITEM_TrackChangesGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_TrackedChanges_Sidebars_Vertical.ToString()] as RibbonToggleButton).Checked;
				bool checked2 = (this.class509_0.TXITEM_TrackChangesGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_TrackedChanges_Sidebars_Horizontal.ToString()] as RibbonToggleButton).Checked;
				bool flag = ribbonProofingTab.TrackedChangesSidebar != null && @checked;
				bool flag2 = ribbonProofingTab.TrackedChangesHorizontalSidebar != null && checked2;
				if (ribbonProofingTab.TrackedChangesSidebar != null && (flag || (!ribbonProofingTab.TrackedChangesSidebar.IsShown && !flag2)))
				{
					if (ribbonProofingTab.TrackedChangesSidebar.ContentLayout != Sidebar.SidebarContentLayout.TrackedChanges)
					{
						if (ribbonProofingTab.TrackedChangesSidebar.IsShown && !ribbonProofingTab.TrackedChangesSidebar.IsPinned)
						{
							ribbonProofingTab.TrackedChangesSidebar.IsShown = false;
						}
						ribbonProofingTab.TrackedChangesSidebar.ContentLayout = Sidebar.SidebarContentLayout.TrackedChanges;
						this.bool_1 = false;
					}
					ribbonProofingTab.TrackedChangesSidebar.IsPinned = @checked;
					this.bool_1 = true;
					ribbonProofingTab.TrackedChangesSidebar.IsShown = true;
				}
				else if (ribbonProofingTab.TrackedChangesHorizontalSidebar != null)
				{
					if (ribbonProofingTab.TrackedChangesHorizontalSidebar.ContentLayout != Sidebar.SidebarContentLayout.TrackedChanges)
					{
						if (ribbonProofingTab.TrackedChangesHorizontalSidebar.IsShown && !ribbonProofingTab.TrackedChangesHorizontalSidebar.IsPinned)
						{
							ribbonProofingTab.TrackedChangesHorizontalSidebar.IsShown = false;
						}
						ribbonProofingTab.TrackedChangesHorizontalSidebar.ContentLayout = Sidebar.SidebarContentLayout.TrackedChanges;
						this.bool_1 = false;
					}
					ribbonProofingTab.TrackedChangesHorizontalSidebar.IsPinned = checked2;
					this.bool_1 = true;
					ribbonProofingTab.TrackedChangesHorizontalSidebar.IsShown = true;
				}
				else
				{
					ribbonSplitButton_0.Checked = false;
				}
			}
			else
			{
				if (ribbonProofingTab.TrackedChangesSidebar != null && ribbonProofingTab.TrackedChangesSidebar.ContentLayout == Sidebar.SidebarContentLayout.TrackedChanges)
				{
					ribbonProofingTab.TrackedChangesSidebar.IsShown = false;
				}
				if (ribbonProofingTab.TrackedChangesHorizontalSidebar != null && ribbonProofingTab.TrackedChangesHorizontalSidebar.ContentLayout == Sidebar.SidebarContentLayout.TrackedChanges)
				{
					ribbonProofingTab.TrackedChangesHorizontalSidebar.IsShown = false;
				}
			}
		}

		private void method_22(Sidebar sidebar_0, string string_0)
		{
			if (!this.bool_0)
			{
				return;
			}
			switch (string_0)
			{
			case "ContentLayout":
			{
				if (sidebar_0.ContentLayout == Sidebar.SidebarContentLayout.TrackedChanges)
				{
					break;
				}
				if (!sidebar_0.IsPinned && sidebar_0.SidebarContentLayout_0 == Sidebar.SidebarContentLayout.TrackedChanges)
				{
					this.point_0 = sidebar_0.DialogLocation;
					this.size_0 = sidebar_0.DialogSize;
				}
				RibbonSplitButton ribbonSplitButton = this.class509_0.TXITEM_TrackChangesGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_TrackedChanges.ToString()] as RibbonSplitButton;
				RibbonProofingTab ribbonProofingTab2 = this.class509_0.Control_0 as RibbonProofingTab;
				if (ribbonSplitButton != null && ribbonSplitButton.Name == RibbonProofingTab.InternalRibbonItem.TXITEM_TrackedChanges_Sidebars.ToString())
				{
					if (sidebar_0 == ribbonProofingTab2.TrackedChangesSidebar)
					{
						bool flag = ribbonProofingTab2.TrackedChangesHorizontalSidebar != null && ribbonProofingTab2.TrackedChangesHorizontalSidebar.ContentLayout == Sidebar.SidebarContentLayout.TrackedChanges;
						ribbonSplitButton.Checked = flag && ribbonProofingTab2.TrackedChangesHorizontalSidebar.IsShown;
					}
					else if (sidebar_0 == ribbonProofingTab2.TrackedChangesHorizontalSidebar)
					{
						bool flag2 = ribbonProofingTab2.TrackedChangesSidebar != null && ribbonProofingTab2.TrackedChangesSidebar.ContentLayout == Sidebar.SidebarContentLayout.TrackedChanges;
						ribbonSplitButton.Checked = flag2 && ribbonProofingTab2.TrackedChangesSidebar.IsShown;
					}
				}
				break;
			}
			case "IsShown":
			case "IsPinned":
			{
				if (sidebar_0.ContentLayout != Sidebar.SidebarContentLayout.TrackedChanges)
				{
					break;
				}
				RibbonButton ribbonButton = this.class509_0.TXITEM_TrackChangesGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_TrackedChanges.ToString()] as RibbonButton;
				RibbonProofingTab ribbonProofingTab = this.class509_0.Control_0 as RibbonProofingTab;
				switch (string_0)
				{
				case "IsPinned":
					Class517.smethod_38(new Sidebar[3] { sidebar_0, ribbonProofingTab.TrackedChangesSidebar, ribbonProofingTab.TrackedChangesHorizontalSidebar }, RibbonProofingTab.InternalRibbonItem.TXITEM_TrackedChanges_Sidebars.ToString(), new object[3]
					{
						ribbonButton,
						this.class509_0.TXITEM_TrackChangesGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_TrackedChanges_Sidebars_Vertical.ToString()],
						this.class509_0.TXITEM_TrackChangesGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_TrackedChanges_Sidebars_Horizontal.ToString()]
					});
					break;
				case "IsShown":
				{
					if (!(ribbonButton.Name == RibbonProofingTab.InternalRibbonItem.TXITEM_TrackedChanges_Sidebars.ToString()))
					{
						break;
					}
					RibbonToggleButton ribbonToggleButton = this.class509_0.TXITEM_TrackChangesGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_TrackedChanges_Sidebars_Vertical.ToString()] as RibbonToggleButton;
					RibbonToggleButton ribbonToggleButton2 = this.class509_0.TXITEM_TrackChangesGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_TrackedChanges_Sidebars_Horizontal.ToString()] as RibbonToggleButton;
					if (sidebar_0 == ribbonProofingTab.TrackedChangesSidebar)
					{
						if (sidebar_0.IsShown)
						{
							ribbonToggleButton.Checked = sidebar_0.IsPinned;
						}
						if (ribbonProofingTab.TrackedChangesHorizontalSidebar != null && ribbonProofingTab.TrackedChangesHorizontalSidebar.ContentLayout == Sidebar.SidebarContentLayout.TrackedChanges)
						{
							this.bool_0 = false;
							ribbonProofingTab.TrackedChangesHorizontalSidebar.IsShown = false;
							this.bool_0 = true;
						}
					}
					else if (sidebar_0 == ribbonProofingTab.TrackedChangesHorizontalSidebar)
					{
						if (sidebar_0.IsShown)
						{
							ribbonToggleButton2.Checked = sidebar_0.IsPinned;
						}
						if (ribbonProofingTab.TrackedChangesSidebar != null && ribbonProofingTab.TrackedChangesSidebar.ContentLayout == Sidebar.SidebarContentLayout.TrackedChanges)
						{
							this.bool_0 = false;
							ribbonProofingTab.TrackedChangesSidebar.IsShown = false;
							this.bool_0 = true;
						}
					}
					(ribbonButton as RibbonSplitButton).Checked = sidebar_0.IsShown;
					break;
				}
				}
				break;
			}
			}
		}

		private void method_23(Sidebar sidebar_0)
		{
			if (sidebar_0.ContentLayout == Sidebar.SidebarContentLayout.TrackedChanges)
			{
				Class517.smethod_39(sidebar_0, this.point_0, this.size_0, bool_0: true);
			}
		}

		private void method_24(Sidebar sidebar_0)
		{
			if (sidebar_0.ContentLayout == Sidebar.SidebarContentLayout.TrackedChanges && this.bool_1)
			{
				this.point_0 = sidebar_0.DialogLocation;
				this.size_0 = sidebar_0.DialogSize;
			}
		}

		private void method_25(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			RibbonProofingTab ribbonProofingTab = this.class509_0.Control_0 as RibbonProofingTab;
			switch (ribbonToggleButton_0.Name)
			{
			case "TXITEM_TrackedChanges_Sidebars_Horizontal":
				if (ribbonToggleButton_0.Checked)
				{
					(this.class509_0.TXITEM_TrackChangesGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_TrackedChanges_Sidebars_Vertical.ToString()] as RibbonToggleButton).Checked = false;
					if (ribbonProofingTab.TrackedChangesSidebar != null && ribbonProofingTab.TrackedChangesSidebar.ContentLayout == Sidebar.SidebarContentLayout.TrackedChanges)
					{
						this.bool_0 = false;
						ribbonProofingTab.TrackedChangesSidebar.IsShown = false;
						this.bool_0 = true;
					}
					if (ribbonProofingTab.TrackedChangesHorizontalSidebar.ContentLayout != Sidebar.SidebarContentLayout.TrackedChanges)
					{
						ribbonProofingTab.TrackedChangesHorizontalSidebar.ContentLayout = Sidebar.SidebarContentLayout.TrackedChanges;
						this.bool_1 = false;
					}
					this.bool_0 = false;
					ribbonProofingTab.TrackedChangesHorizontalSidebar.IsPinned = true;
					this.bool_1 = true;
					this.bool_0 = true;
					ribbonProofingTab.TrackedChangesHorizontalSidebar.IsShown = true;
					(this.class509_0.TXITEM_TrackChangesGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_TrackedChanges_Sidebars.ToString()] as RibbonSplitButton).Checked = true;
				}
				else
				{
					ribbonProofingTab.TrackedChangesHorizontalSidebar.IsShown = false;
				}
				break;
			case "TXITEM_TrackedChanges_Sidebars_Vertical":
				if (ribbonToggleButton_0.Checked)
				{
					(this.class509_0.TXITEM_TrackChangesGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_TrackedChanges_Sidebars_Horizontal.ToString()] as RibbonToggleButton).Checked = false;
					if (ribbonProofingTab.TrackedChangesHorizontalSidebar != null && ribbonProofingTab.TrackedChangesHorizontalSidebar.ContentLayout == Sidebar.SidebarContentLayout.TrackedChanges)
					{
						this.bool_0 = false;
						ribbonProofingTab.TrackedChangesHorizontalSidebar.IsShown = false;
						this.bool_0 = true;
					}
					if (ribbonProofingTab.TrackedChangesSidebar.ContentLayout != Sidebar.SidebarContentLayout.TrackedChanges)
					{
						ribbonProofingTab.TrackedChangesSidebar.ContentLayout = Sidebar.SidebarContentLayout.TrackedChanges;
						this.bool_1 = false;
					}
					this.bool_0 = false;
					ribbonProofingTab.TrackedChangesSidebar.IsPinned = true;
					this.bool_1 = true;
					this.bool_0 = true;
					ribbonProofingTab.TrackedChangesSidebar.IsShown = true;
					(this.class509_0.TXITEM_TrackChangesGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_TrackedChanges_Sidebars.ToString()] as RibbonSplitButton).Checked = true;
				}
				else
				{
					ribbonProofingTab.TrackedChangesSidebar.IsShown = false;
				}
				break;
			}
		}

		private void method_26()
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.TrackedChanges.GetItem(next: false)?.Select();
			}
		}

		private void method_27()
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.TrackedChanges.GetItem(next: true)?.Select();
			}
		}

		private void method_28(bool bool_2)
		{
			if (base.m_txTextControl != null)
			{
				foreach (TrackedChange trackedChange in base.m_txTextControl.TrackedChanges)
				{
					trackedChange.Active = bool_2;
				}
			}
			RibbonMenuButton ribbonMenuButton = this.class509_0.TXITEM_TrackChangesGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_ShowMarkup.ToString()] as RibbonMenuButton;
			foreach (Control dropDownItem in ribbonMenuButton.DropDownItems)
			{
				if (dropDownItem is RibbonToggleButton && dropDownItem.Name.StartsWith("Reviewer_"))
				{
					(dropDownItem as RibbonToggleButton).Checked = bool_2;
				}
			}
		}

		private void method_29(RibbonToggleButton ribbonToggleButton_0)
		{
			RibbonMenuButton ribbonMenuButton = this.class509_0.TXITEM_TrackChangesGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_ShowMarkup.ToString()] as RibbonMenuButton;
			string text = ribbonToggleButton_0.Tag.ToString();
			bool @checked = ribbonToggleButton_0.Checked;
			if (base.m_txTextControl != null)
			{
				foreach (TrackedChange trackedChange in base.m_txTextControl.TrackedChanges)
				{
					if (trackedChange.UserName == text)
					{
						trackedChange.Active = @checked;
					}
				}
			}
			this.method_39(ribbonMenuButton.DropDownItems);
		}

		private void method_30()
		{
			if (base.m_txTextControl != null && base.m_txTextControl.SpellChecker != null)
			{
				base.m_txTextControl.IsLanguageDetectionEnabled = false;
				base.m_txTextControl.IsLanguageDetectionEnabled = true;
			}
		}

		private void method_31()
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.LanguageDialog();
			}
		}

		private void method_32(TrackedChangeEventArgs trackedChangeEventArgs_0)
		{
			RibbonMenuButton ribbonMenuButton = this.class509_0.TXITEM_TrackChangesGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_ShowMarkup.ToString()] as RibbonMenuButton;
			this.method_37(trackedChangeEventArgs_0.TrackedChange.UserName, ribbonMenuButton.DropDownItems);
		}

		private void method_33(TrackedChangeEventArgs trackedChangeEventArgs_0)
		{
			RibbonMenuButton ribbonMenuButton = this.class509_0.TXITEM_TrackChangesGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_ShowMarkup.ToString()] as RibbonMenuButton;
			this.method_38(trackedChangeEventArgs_0.TrackedChange.UserName, ribbonMenuButton.DropDownItems);
		}

		internal override void UpdateRibbonTab(params object[] args)
		{
		}

		internal void method_34()
		{
			int num = ((base.m_txTextControl == null) ? 666 : ((base.m_txTextControl.SpellChecker == null) ? (-1) : this.class415_0.method_38()));
			if (num == -1)
			{
				Control obj = this.class509_0.TXITEM_SpellingAndHyphenationGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_SpellingAndHyphenationGroup.ToString()] as Control;
				Control obj2 = this.class509_0.TXITEM_LanguageGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_DetectLanguages.ToString()] as Control;
				(this.class509_0.TXITEM_ProofingSettingsGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_ProofingSettingsGroup.ToString()] as Control).Enabled = false;
				obj2.Enabled = false;
				obj.Enabled = false;
			}
			else
			{
				(this.class509_0.TXITEM_SpellingAndHyphenationGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_EnableHyphenations.ToString()] as Control).Enabled = num >= 4;
				Control obj3 = this.class509_0.TXITEM_SpellingAndHyphenationGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_Thesaurus.ToString()] as Control;
				bool enabled = ((this.class509_0.TXITEM_ProofingSettingsGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_LoadThesaurusFile.ToString()] as Control).Enabled = num >= 7);
				obj3.Enabled = enabled;
				(this.class509_0.TXITEM_LanguageGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_DetectLanguages.ToString()] as Control).Enabled = num >= 5;
			}
		}

		internal void method_35(Sidebar sidebar_0)
		{
			if (sidebar_0 != null)
			{
				sidebar_0.PropertyChanged -= method_46;
			}
			if (base.m_txTextControl == null)
			{
				return;
			}
			RibbonProofingTab ribbonProofingTab = this.class509_0.Control_0 as RibbonProofingTab;
			if (ribbonProofingTab == null)
			{
				return;
			}
			RibbonButton ribbonButton = this.class509_0.TXITEM_TrackChangesGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_TrackedChanges.ToString()] as RibbonButton;
			RibbonButton ribbonButton2;
			if (ribbonProofingTab.TrackedChangesHorizontalSidebar == null && ribbonProofingTab.TrackedChangesSidebar == null)
			{
				if (!(ribbonButton is RibbonSplitButton) && !(ribbonButton is RibbonToggleButton))
				{
					return;
				}
				ribbonButton2 = this.class509_0.TXITEM_TrackChangesGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_TrackedChanges_Dialog.ToString()] as RibbonButton;
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
				if (bool_7 = ribbonProofingTab.TrackedChangesHorizontalSidebar != null)
				{
					bool_6 = ribbonProofingTab.TrackedChangesHorizontalSidebar.ContentLayout == Sidebar.SidebarContentLayout.TrackedChanges;
					this.point_0 = ribbonProofingTab.TrackedChangesHorizontalSidebar.DialogLocation;
					this.size_0 = ribbonProofingTab.TrackedChangesHorizontalSidebar.DialogSize;
					bool_ = ribbonProofingTab.TrackedChangesHorizontalSidebar.IsShown;
					bool_3 = ribbonProofingTab.TrackedChangesHorizontalSidebar.IsPinned;
					ribbonProofingTab.TrackedChangesHorizontalSidebar.PropertyChanged -= method_46;
					ribbonProofingTab.TrackedChangesHorizontalSidebar.PropertyChanged += method_46;
					ribbonProofingTab.TrackedChangesHorizontalSidebar.DialogOpening -= method_47;
					ribbonProofingTab.TrackedChangesHorizontalSidebar.DialogOpening += method_47;
					ribbonProofingTab.TrackedChangesHorizontalSidebar.DialogClosed -= method_48;
					ribbonProofingTab.TrackedChangesHorizontalSidebar.DialogClosed += method_48;
				}
				bool bool_8;
				if (bool_8 = ribbonProofingTab.TrackedChangesSidebar != null)
				{
					bool_5 = ribbonProofingTab.TrackedChangesSidebar.ContentLayout == Sidebar.SidebarContentLayout.TrackedChanges;
					this.point_0 = ribbonProofingTab.TrackedChangesSidebar.DialogLocation;
					this.size_0 = ribbonProofingTab.TrackedChangesSidebar.DialogSize;
					bool_2 = ribbonProofingTab.TrackedChangesSidebar.IsShown;
					bool_4 = ribbonProofingTab.TrackedChangesSidebar.IsPinned;
					ribbonProofingTab.TrackedChangesSidebar.PropertyChanged -= method_46;
					ribbonProofingTab.TrackedChangesSidebar.PropertyChanged += method_46;
					ribbonProofingTab.TrackedChangesSidebar.DialogOpening -= method_47;
					ribbonProofingTab.TrackedChangesSidebar.DialogOpening += method_47;
					ribbonProofingTab.TrackedChangesSidebar.DialogClosed -= method_48;
					ribbonProofingTab.TrackedChangesSidebar.DialogClosed += method_48;
				}
				ribbonButton2 = this.method_36(bool_5, bool_6, ribbonButton, bool_8, bool_7, bool_2, bool_, bool_4, bool_3);
			}
			if (ribbonButton2 != null)
			{
				Class517.smethod_37(RibbonProofingTab.InternalRibbonItem.TXITEM_TrackedChanges.ToString(), ribbonButton, this.class509_0.TXITEM_TrackChangesGroup_Items, ribbonButton2);
			}
		}

		private RibbonButton method_36(bool bool_2, bool bool_3, RibbonButton ribbonButton_0, bool bool_4, bool bool_5, bool bool_6, bool bool_7, bool bool_8, bool bool_9)
		{
			RibbonButton ribbonButton = this.class509_0.TXITEM_TrackChangesGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_TrackedChanges_Sidebars.ToString()] as RibbonSplitButton;
			(ribbonButton as RibbonSplitButton).Checked = (bool_2 && bool_6) || (bool_3 && bool_7);
			RibbonToggleButton ribbonToggleButton = this.class509_0.TXITEM_TrackChangesGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_TrackedChanges_Sidebars_Vertical.ToString()] as RibbonToggleButton;
			if (ribbonToggleButton.Visible = bool_4)
			{
				ribbonToggleButton.Checked = (bool_8 && bool_2) || !bool_9 || !bool_3;
			}
			RibbonToggleButton ribbonToggleButton2 = this.class509_0.TXITEM_TrackChangesGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_TrackedChanges_Sidebars_Horizontal.ToString()] as RibbonToggleButton;
			if (ribbonToggleButton2.Visible = bool_5)
			{
				ribbonToggleButton2.Checked = bool_9 && bool_3 && (!bool_8 || !bool_2);
			}
			if (ribbonButton_0 == ribbonButton)
			{
				return null;
			}
			return ribbonButton;
		}

		private void method_37(string string_0, RibbonItemCollection ribbonItemCollection_0)
		{
			foreach (TrackedChange trackedChange in base.m_txTextControl.TrackedChanges)
			{
				if (trackedChange.UserName == string_0)
				{
					return;
				}
			}
			foreach (Control item in ribbonItemCollection_0)
			{
				if (item is RibbonToggleButton && item.Name.StartsWith("Reviewer_") && item.Tag.ToString() == string_0)
				{
					ribbonItemCollection_0.Remove(item);
					break;
				}
			}
			bool flag = false;
			foreach (Control item2 in ribbonItemCollection_0)
			{
				if (item2 is RibbonToggleButton && item2.Name.StartsWith("Reviewer_"))
				{
					flag = true;
					break;
				}
			}
			if ((this.class509_0.TXITEM_TrackChangesGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_ShowMarkupSeperator1.ToString()] as RibbonSeperator).Visible = flag)
			{
				this.method_39(ribbonItemCollection_0);
			}
		}

		private void method_38(string string_0, RibbonItemCollection ribbonItemCollection_0)
		{
			foreach (Control item in ribbonItemCollection_0)
			{
				if (item is RibbonToggleButton && item.Name.StartsWith("Reviewer_") && item.Tag.ToString() == string_0)
				{
					return;
				}
			}
			string text = ((string_0 == string.Empty) ? base.m_rmResourceManager.GetString("ID_TRACKEDCHANGES_UNKNOWNUSER") : string_0);
			RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
			ribbonToggleButton.Name = "Reviewer_" + string_0;
			ribbonToggleButton.Tag = string_0;
			ribbonToggleButton.Checked = true;
			ribbonToggleButton.Text = text;
			ribbonToggleButton.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
			ribbonToggleButton2.CheckedChanged += method_51;
			ribbonItemCollection_0.Add(ribbonToggleButton2);
			(this.class509_0.TXITEM_TrackChangesGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_ShowMarkupSeperator1.ToString()] as RibbonSeperator).Visible = true;
		}

		private void method_39(RibbonItemCollection ribbonItemCollection_0)
		{
			RibbonToggleButton ribbonToggleButton = this.class509_0.TXITEM_TrackChangesGroup_Items[RibbonProofingTab.InternalRibbonItem.TXITEM_ShowMarkup_AllReviewers.ToString()] as RibbonToggleButton;
			foreach (Control item in ribbonItemCollection_0)
			{
				if (item is RibbonToggleButton && item.Name.StartsWith("Reviewer_") && !(item as RibbonToggleButton).Checked)
				{
					ribbonToggleButton.Checked = false;
					return;
				}
			}
			ribbonToggleButton.Checked = true;
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_EnableSpellChecking_Handler(object sender, EventArgs e)
		{
			this.method_4((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_EnableHyphenations_Handler(object sender, EventArgs e)
		{
			this.method_5((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_Thesaurus_Handler(object sender, EventArgs e)
		{
			this.method_6();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_Spelling_Handler(object sender, EventArgs e)
		{
			this.method_7();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_LoadDictionary_Handler(object sender, EventArgs e)
		{
			this.method_8();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_LoadThesaurusFile_Handler(object sender, EventArgs e)
		{
			this.method_9();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_SpellingOptions_Handler(object sender, EventArgs e)
		{
			this.method_10();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_TrackChanges_Handler(object sender, EventArgs e)
		{
			this.method_11((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_AcceptTrackedChange_Handler(object sender, EventArgs e)
		{
			this.method_12();
		}

		private void method_40(object sender, EventArgs e)
		{
			this.method_13();
		}

		private void method_41(object sender, EventArgs e)
		{
			this.method_14();
		}

		private void method_42(object sender, EventArgs e)
		{
			this.method_15();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_RejectTrackedChange_Handler(object sender, EventArgs e)
		{
			this.method_16();
		}

		private void method_43(object sender, EventArgs e)
		{
			this.method_17();
		}

		private void method_44(object sender, EventArgs e)
		{
			this.method_18();
		}

		private void method_45(object sender, EventArgs e)
		{
			this.method_19();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_TrackedChanges_Handler(object sender, EventArgs e)
		{
			this.method_20();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_TrackedChanges_Sidebars_Handler(object sender, EventArgs e)
		{
			this.method_21(sender as RibbonSplitButton);
		}

		private void method_46(object sender, PropertyChangedEventArgs e)
		{
			this.method_22(sender as Sidebar, e.PropertyName);
		}

		private void method_47(object sender, EventArgs e)
		{
			this.method_23(sender as Sidebar);
		}

		private void method_48(object sender, EventArgs e)
		{
			this.method_24(sender as Sidebar);
		}

		private void method_49(object sender, EventArgs e)
		{
			this.method_25(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_PreviousTrackedChange_Handler(object sender, EventArgs e)
		{
			this.method_26();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_NextTrackedChange_Handler(object sender, EventArgs e)
		{
			this.method_27();
		}

		private void method_50(object sender, EventArgs e)
		{
			this.method_28((sender as RibbonToggleButton).Checked);
		}

		private void method_51(object sender, EventArgs e)
		{
			this.method_29(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_DetectLanguages_Handler(object sender, EventArgs e)
		{
			this.method_30();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_SetLanguage_Handler(object sender, EventArgs e)
		{
			this.method_31();
		}

		private void method_52(object sender, TrackedChangeEventArgs e)
		{
			this.method_32(e);
		}

		private void method_53(object sender, TrackedChangeEventArgs e)
		{
			this.method_33(e);
		}
	}
}
