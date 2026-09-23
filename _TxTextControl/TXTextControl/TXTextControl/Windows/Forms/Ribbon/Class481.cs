using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using TXTextControl;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class481 : BindingAdapter
	{
		private Class510 class510_0;

		private string string_0;

		private bool bool_0;

		internal override Class500 RibbonGroupManager
		{
			get
			{
				return this.class510_0;
			}
			set
			{
				this.class510_0 = value as Class510;
			}
		}

		private void method_0(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = control_0 as RibbonMenuButton;
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonReferencesTab.InternalRibbonItem.TXITEM_AddParagraphBodyText.ToString(), null, this);
				ribbonToggleButton.Tag = 0;
				ribbonToggleButton.Click += method_20;
				RibbonToggleButton ribbonToggleButton2 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonReferencesTab.InternalRibbonItem.TXITEM_AddParagraphLevel1.ToString(), null, this);
				ribbonToggleButton2.Tag = 1;
				ribbonToggleButton2.Click += method_20;
				RibbonToggleButton ribbonToggleButton3 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonReferencesTab.InternalRibbonItem.TXITEM_AddParagraphLevel2.ToString(), null, this);
				ribbonToggleButton3.Tag = 2;
				ribbonToggleButton3.Click += method_20;
				RibbonToggleButton ribbonToggleButton4 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonReferencesTab.InternalRibbonItem.TXITEM_AddParagraphLevel3.ToString(), null, this);
				ribbonToggleButton4.Tag = 3;
				ribbonToggleButton4.Click += method_20;
				RibbonToggleButton ribbonToggleButton5 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonReferencesTab.InternalRibbonItem.TXITEM_AddParagraphLevel4.ToString(), null, this);
				ribbonToggleButton5.Tag = 4;
				ribbonToggleButton5.Click += method_20;
				RibbonToggleButton ribbonToggleButton6 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonReferencesTab.InternalRibbonItem.TXITEM_AddParagraphLevel5.ToString(), null, this);
				ribbonToggleButton6.Tag = 5;
				ribbonToggleButton6.Click += method_20;
				RibbonToggleButton ribbonToggleButton7 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonReferencesTab.InternalRibbonItem.TXITEM_AddParagraphLevel6.ToString(), null, this);
				ribbonToggleButton7.Tag = 6;
				ribbonToggleButton7.Click += method_20;
				RibbonToggleButton ribbonToggleButton8 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonReferencesTab.InternalRibbonItem.TXITEM_AddParagraphLevel7.ToString(), null, this);
				ribbonToggleButton8.Tag = 7;
				ribbonToggleButton8.Click += method_20;
				RibbonToggleButton ribbonToggleButton9 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonReferencesTab.InternalRibbonItem.TXITEM_AddParagraphLevel8.ToString(), null, this);
				ribbonToggleButton9.Tag = 8;
				ribbonToggleButton9.Click += method_20;
				RibbonToggleButton ribbonToggleButton10 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonReferencesTab.InternalRibbonItem.TXITEM_AddParagraphLevel9.ToString(), null, this);
				ribbonToggleButton10.Tag = 9;
				ribbonToggleButton10.Click += method_20;
				RibbonToggleButton ribbonToggleButton11 = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, RibbonReferencesTab.InternalRibbonItem.TXITEM_AddParagraphLevel10.ToString(), null, this);
				ribbonToggleButton11.Tag = 10;
				ribbonToggleButton11.Click += method_20;
				ribbonMenuButton.DropDownItems.AddRange(new Control[11]
				{
					ribbonToggleButton, ribbonToggleButton2, ribbonToggleButton3, ribbonToggleButton4, ribbonToggleButton5, ribbonToggleButton6, ribbonToggleButton7, ribbonToggleButton8, ribbonToggleButton9, ribbonToggleButton10,
					ribbonToggleButton11
				});
			}
		}

		internal override void SetRibbonItemAppearance(Dictionary<string, object> groupItemsDictionary, Control ribbonItem, string eventName, bool hasImage)
		{
			base.SetBasicRibbonItemAppearance(groupItemsDictionary, ribbonItem, hasImage);
			switch (ribbonItem.Name)
			{
			case "TXITEM_AddParagraph":
				this.method_0(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_StructureLevelStyles":
			{
				RibbonListView ribbonListView = ribbonItem as RibbonListView;
				ribbonListView.ItemDropDownOpening += method_19;
				ribbonListView.ItemDropDownClosed += method_18;
				break;
			}
			case "TXITEM_TOCTitle":
				base.SetBasicRibbonTextBoxAppearance(ribbonItem as RibbonTextBox, hasImage, showDropDownButtons: false, RibbonTextBox.InputValidationMode.All);
				break;
			case "TXITEM_TOCMaximumStructureLevel":
				base.SetBasicRibbonTextBoxAppearance(ribbonItem as RibbonTextBox, hasImage, showDropDownButtons: false, RibbonTextBox.InputValidationMode.OnlyIntegers);
				break;
			case "TXITEM_TOCMinimumStructureLevel":
				base.SetBasicRibbonTextBoxAppearance(ribbonItem as RibbonTextBox, hasImage, showDropDownButtons: false, RibbonTextBox.InputValidationMode.OnlyIntegers);
				break;
			}
			if (eventName != null)
			{
				Class517.smethod_23(ribbonItem, eventName, ribbonItem.Name + "_Handler", this);
			}
		}

		internal override void OnDisconnectingTextControl()
		{
			if (this.bool_0)
			{
				this.bool_0 = false;
				base.m_txTextControl.DocumentLoaded -= method_21;
				base.m_txTextControl.ContentsReset -= method_22;
				base.m_txTextControl.InputFormat.StyleNamesChanged -= method_23;
				base.m_txTextControl.InputFormat.StyleNameChanged -= method_24;
				base.m_txTextControl.InputParagraphChanged -= method_25;
				base.m_txTextControl.ParagraphFormatChanged -= method_26;
				base.m_txTextControl.TableOfContentsEntered -= method_27;
				base.m_txTextControl.TableOfContentsLeft -= method_28;
				base.m_txTextControl.TableOfContentsDeleted -= method_29;
				base.m_txTextControl.FormattingStyleListChanged -= method_30;
				base.m_txTextControl.FormattingStyleChanged -= method_31;
			}
		}

		internal override void OnTextControlConnected()
		{
			if (base.m_txTextControl.GetVersionInfo().Level >= VersionInfo.ProductLevel.Enterprise)
			{
				this.bool_0 = true;
				base.m_txTextControl.DocumentLoaded += method_21;
				base.m_txTextControl.ContentsReset += method_22;
				base.m_txTextControl.InputFormat.StyleNamesChanged += method_23;
				base.m_txTextControl.InputFormat.StyleNameChanged += method_24;
				base.m_txTextControl.InputParagraphChanged += method_25;
				base.m_txTextControl.ParagraphFormatChanged += method_26;
				base.m_txTextControl.TableOfContentsEntered += method_27;
				base.m_txTextControl.TableOfContentsLeft += method_28;
				base.m_txTextControl.TableOfContentsDeleted += method_29;
				base.m_txTextControl.FormattingStyleListChanged += method_30;
				base.m_txTextControl.FormattingStyleChanged += method_31;
			}
		}

		private void method_1(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				ribbonToggleButton_0.Checked = true;
				if (((IRibbonItem)ribbonToggleButton_0).IsDefaultRibbonTabItem)
				{
					int structureLevel = (int)ribbonToggleButton_0.Tag;
					base.m_txTextControl.Selection.ParagraphFormat.StructureLevel = structureLevel;
				}
			}
		}

		private void method_2()
		{
			this.UpdateRibbonTab();
		}

		private void method_3()
		{
			this.UpdateRibbonTab();
		}

		private void method_4()
		{
			this.method_15();
		}

		private void method_5()
		{
			this.method_17();
		}

		private void method_6()
		{
			this.method_16();
		}

		private void method_7()
		{
			this.method_16();
		}

		private void method_8(TableOfContentsEventArgs tableOfContentsEventArgs_0)
		{
			this.method_12(bool_1: true);
			this.method_13(tableOfContentsEventArgs_0.TableOfContents);
		}

		private void method_9()
		{
			this.method_12(bool_1: false);
			this.method_13(null);
		}

		private void method_10()
		{
			this.method_15();
			this.method_17();
		}

		private void method_11()
		{
			this.method_15();
			this.method_17();
		}

		internal override void UpdateRibbonTab(params object[] args)
		{
			if (this.class510_0.Boolean_0)
			{
				TableOfContents tableOfContents = (this.bool_0 ? base.m_txTextControl.TablesOfContents.GetItem() : null);
				this.method_12(tableOfContents != null);
				this.method_13(tableOfContents);
				this.method_14();
			}
		}

		private void method_12(bool bool_1)
		{
			RibbonGroup ribbonGroup = this.class510_0.TXITEM_TableOfContentsGroup_Items[RibbonReferencesTab.InternalRibbonItem.TXITEM_TableOfContentsGroup.ToString()] as RibbonGroup;
			if (this.class510_0.method_0(ribbonGroup))
			{
				bool_1 &= base.m_txTextControl.CanEdit;
				RibbonButton ribbonButton = this.class510_0.TXITEM_TableOfContentsGroup_Items[RibbonReferencesTab.InternalRibbonItem.TXITEM_InsertTableOfContents.ToString()] as RibbonButton;
				RibbonButton ribbonButton2 = this.class510_0.TXITEM_TableOfContentsGroup_Items[RibbonReferencesTab.InternalRibbonItem.TXITEM_DeleteTableOfContents.ToString()] as RibbonButton;
				RibbonButton ribbonButton3 = this.class510_0.TXITEM_TableOfContentsGroup_Items[RibbonReferencesTab.InternalRibbonItem.TXITEM_UpdateTableOfContents.ToString()] as RibbonButton;
				RibbonButton ribbonButton4 = this.class510_0.TXITEM_TableOfContentsGroup_Items[RibbonReferencesTab.InternalRibbonItem.TXITEM_ModifyTableOfContents.ToString()] as RibbonButton;
				ribbonButton.Enabled = !bool_1;
				ribbonButton2.Enabled = bool_1;
				ribbonButton3.Enabled = bool_1;
				ribbonButton4.Enabled = bool_1;
				ribbonGroup.Enabled = base.m_txTextControl.CanEdit;
			}
		}

		private void method_13(TableOfContents tableOfContents_0)
		{
			RibbonGroup ribbonGroup = this.class510_0.TXITEM_TableOfContentsPropertiesGroup_Items[RibbonReferencesTab.InternalRibbonItem.TXITEM_TableOfContentsPropertiesGroup.ToString()] as RibbonGroup;
			if (this.class510_0.method_0(ribbonGroup))
			{
				RibbonTextBox ribbonTextBox = this.class510_0.TXITEM_TableOfContentsPropertiesGroup_Items[RibbonReferencesTab.InternalRibbonItem.TXITEM_TOCMinimumStructureLevel.ToString()] as RibbonTextBox;
				RibbonTextBox ribbonTextBox2 = this.class510_0.TXITEM_TableOfContentsPropertiesGroup_Items[RibbonReferencesTab.InternalRibbonItem.TXITEM_TOCMaximumStructureLevel.ToString()] as RibbonTextBox;
				RibbonToggleButton ribbonToggleButton = this.class510_0.TXITEM_TableOfContentsPropertiesGroup_Items[RibbonReferencesTab.InternalRibbonItem.TXITEM_TOCCreateHyperlinks.ToString()] as RibbonToggleButton;
				RibbonTextBox ribbonTextBox3 = this.class510_0.TXITEM_TableOfContentsPropertiesGroup_Items[RibbonReferencesTab.InternalRibbonItem.TXITEM_TOCTitle.ToString()] as RibbonTextBox;
				RibbonToggleButton ribbonToggleButton2 = this.class510_0.TXITEM_TableOfContentsPropertiesGroup_Items[RibbonReferencesTab.InternalRibbonItem.TXITEM_TOCShowPageNumbers.ToString()] as RibbonToggleButton;
				RibbonToggleButton ribbonToggleButton3 = this.class510_0.TXITEM_TableOfContentsPropertiesGroup_Items[RibbonReferencesTab.InternalRibbonItem.TXITEM_TOCRightAlignPageNumbers.ToString()] as RibbonToggleButton;
				ribbonTextBox.Text = ((tableOfContents_0 != null) ? tableOfContents_0.MinimumStructureLevel.ToString() : "1");
				ribbonTextBox2.Text = ((tableOfContents_0 != null) ? tableOfContents_0.MaximumStructureLevel.ToString() : "10");
				ribbonToggleButton.Checked = tableOfContents_0?.HasLinks ?? false;
				ribbonTextBox3.Text = ((tableOfContents_0 != null) ? tableOfContents_0.Title : base.m_rmResourceManager.GetString("LABEL_TOCTitleTextBoxText"));
				ribbonToggleButton2.Checked = tableOfContents_0?.HasPageNumbers ?? true;
				ribbonToggleButton3.Checked = tableOfContents_0?.HasRightAlignedPageNumbers ?? true;
				ribbonToggleButton3.Enabled = tableOfContents_0?.HasPageNumbers ?? true;
				ribbonGroup.Enabled = base.m_txTextControl.CanEdit && tableOfContents_0 != null;
			}
		}

		private void method_14()
		{
			RibbonGroup ribbonGroup = this.class510_0.TXITEM_ParagraphStructureLevelsGroup_Items[RibbonReferencesTab.InternalRibbonItem.TXITEM_ParagraphStructureLevelsGroup.ToString()] as RibbonGroup;
			if (this.class510_0.method_0(ribbonGroup))
			{
				if (this.bool_0)
				{
					this.method_15();
					this.method_17();
					this.method_16();
				}
				ribbonGroup.Enabled = this.bool_0 && base.m_txTextControl.CanEdit;
			}
		}

		private void method_15()
		{
			RibbonListView ribbonListView = this.class510_0.TXITEM_ParagraphStructureLevelsGroup_Items[RibbonReferencesTab.InternalRibbonItem.TXITEM_StructureLevelStyles.ToString()] as RibbonListView;
			if (!this.class510_0.method_2(ribbonListView) || base.m_txTextControl == null)
			{
				return;
			}
			List<RibbonListView.RibbonListViewItem> list = new List<RibbonListView.RibbonListViewItem>();
			ParagraphStyleCollection paragraphStyles = base.m_txTextControl.ParagraphStyles;
			string[] items = new string[11]
			{
				base.m_rmResourceManager.GetString("HEADER_StructureLevelStyles_BodyText"),
				base.m_rmResourceManager.GetString("HEADER_StructureLevelStyles_Level1"),
				base.m_rmResourceManager.GetString("HEADER_StructureLevelStyles_Level2"),
				base.m_rmResourceManager.GetString("HEADER_StructureLevelStyles_Level3"),
				base.m_rmResourceManager.GetString("HEADER_StructureLevelStyles_Level4"),
				base.m_rmResourceManager.GetString("HEADER_StructureLevelStyles_Level5"),
				base.m_rmResourceManager.GetString("HEADER_StructureLevelStyles_Level6"),
				base.m_rmResourceManager.GetString("HEADER_StructureLevelStyles_Level7"),
				base.m_rmResourceManager.GetString("HEADER_StructureLevelStyles_Level8"),
				base.m_rmResourceManager.GetString("HEADER_StructureLevelStyles_Level9"),
				base.m_rmResourceManager.GetString("HEADER_StructureLevelStyles_Level10")
			};
			foreach (ParagraphStyle item in paragraphStyles)
			{
				string name = item.Name;
				if (name == "TOC_Title" || name.StartsWith("TOC_Level"))
				{
					continue;
				}
				_ = item.ParagraphFormat.StructureLevel;
				RibbonListView.RibbonListViewItem ribbonListViewItem = new RibbonListView.RibbonListViewItem();
				string text2 = (string)(ribbonListViewItem.Tag = (ribbonListViewItem.Text = name));
				ribbonListViewItem.DropDown.Items = items;
				ribbonListViewItem.DropDown.ShowCheckMargin = true;
				int structureLevel = item.ParagraphFormat.StructureLevel;
				if (structureLevel >= 0)
				{
					ribbonListViewItem.DropDown.SelectedItem = ribbonListViewItem.DropDown.Items[structureLevel];
					if (structureLevel == 0)
					{
						ribbonListViewItem.DropDown.Text = null;
					}
				}
				else
				{
					ribbonListViewItem.DropDown.SelectedItem = null;
				}
				list.Add(ribbonListViewItem);
			}
			ribbonListView.ItemsSource = list.ToArray();
		}

		private void method_16()
		{
			RibbonMenuButton ribbonMenuButton = this.class510_0.TXITEM_ParagraphStructureLevelsGroup_Items[RibbonReferencesTab.InternalRibbonItem.TXITEM_AddParagraph.ToString()] as RibbonMenuButton;
			if (!this.class510_0.method_2(ribbonMenuButton))
			{
				return;
			}
			ParagraphFormat paragraphFormat = base.m_txTextControl.Selection.ParagraphFormat;
			int num = (base.m_txTextControl.Selection.IsCommonValueSelected(ParagraphFormat.Attribute.StructureLevel) ? paragraphFormat.StructureLevel : (-1));
			foreach (Control dropDownItem in ribbonMenuButton.DropDownItems)
			{
				RibbonToggleButton ribbonToggleButton = dropDownItem as RibbonToggleButton;
				if (ribbonToggleButton != null && ((IRibbonItem)ribbonToggleButton).IsDefaultRibbonTabItem)
				{
					ribbonToggleButton.Checked = num == (int)ribbonToggleButton.Tag;
				}
			}
		}

		private void method_17()
		{
			RibbonListView ribbonListView = this.class510_0.TXITEM_ParagraphStructureLevelsGroup_Items[RibbonReferencesTab.InternalRibbonItem.TXITEM_StructureLevelStyles.ToString()] as RibbonListView;
			if (!this.class510_0.method_2(ribbonListView))
			{
				return;
			}
			string styleName = base.m_txTextControl.InputFormat.StyleName;
			RibbonListView.RibbonListViewItem ribbonListViewItem = null;
			RibbonListView.RibbonListViewItem[] itemsSource = ribbonListView.ItemsSource;
			foreach (RibbonListView.RibbonListViewItem ribbonListViewItem2 in itemsSource)
			{
				if (ribbonListViewItem2.Tag.ToString() == styleName)
				{
					ribbonListViewItem = ribbonListViewItem2;
					break;
				}
			}
			if (ribbonListViewItem != null)
			{
				ribbonListView.SelectedItems = new RibbonListView.RibbonListViewItem[1] { ribbonListViewItem };
				ribbonListView.ScrollTo(ribbonListViewItem);
			}
			else
			{
				ribbonListView.SelectedItems = new RibbonListView.RibbonListViewItem[0];
			}
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertTableOfContents_Handler(object sender, EventArgs e)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.TableOfContentsDialog();
			}
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_DeleteTableOfContents_Handler(object sender, EventArgs e)
		{
			if (base.m_txTextControl != null)
			{
				TableOfContents item = base.m_txTextControl.TablesOfContents.GetItem();
				if (item != null)
				{
					base.m_txTextControl.TablesOfContents.Remove(item);
				}
			}
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_UpdateTableOfContents_Handler(object sender, EventArgs e)
		{
			if (base.m_txTextControl != null)
			{
				TableOfContents item = base.m_txTextControl.TablesOfContents.GetItem();
				if (item != null && item.Update() == TableOfContentsCollection.AddResult.ContentNotFound)
				{
					MessageBox.Show(base.m_rmResourceManager.GetString("MSG_TOC_NO_CONTENTS_CAPTION"), base.m_rmResourceManager.GetString("MSG_TOC_NO_CONTENTS"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_ModifyTableOfContents_Handler(object sender, EventArgs e)
		{
			if (base.m_txTextControl != null && base.m_txTextControl.TableOfContentsDialog() == DialogResult.OK)
			{
				TableOfContents item = base.m_txTextControl.TablesOfContents.GetItem();
				if (item != null)
				{
					this.method_13(item);
				}
			}
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_TOCMinimumStructureLevel_Handler(object sender, EventArgs e)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			TableOfContents item = base.m_txTextControl.TablesOfContents.GetItem();
			if (item == null)
			{
				return;
			}
			short minimumStructureLevel = item.MinimumStructureLevel;
			if (short.TryParse((sender as RibbonTextBox).Text, out var result))
			{
				try
				{
					item.MinimumStructureLevel = result;
				}
				catch (Exception ex)
				{
					(sender as RibbonTextBox).Text = minimumStructureLevel.ToString();
					throw ex;
				}
			}
			else
			{
				(sender as RibbonTextBox).Text = minimumStructureLevel.ToString();
			}
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_TOCMaximumStructureLevel_Handler(object sender, EventArgs e)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			TableOfContents item = base.m_txTextControl.TablesOfContents.GetItem();
			if (item == null)
			{
				return;
			}
			short maximumStructureLevel = item.MaximumStructureLevel;
			if (short.TryParse((sender as RibbonTextBox).Text, out var result))
			{
				try
				{
					item.MaximumStructureLevel = result;
				}
				catch (Exception ex)
				{
					(sender as RibbonTextBox).Text = maximumStructureLevel.ToString();
					throw ex;
				}
			}
			else
			{
				(sender as RibbonTextBox).Text = maximumStructureLevel.ToString();
			}
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_TOCCreateHyperlinks_Handler(object sender, EventArgs e)
		{
			if (base.m_txTextControl != null)
			{
				TableOfContents item = base.m_txTextControl.TablesOfContents.GetItem();
				if (item != null)
				{
					item.HasLinks = (sender as RibbonToggleButton).Checked;
				}
			}
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_TOCTitle_Handler(object sender, EventArgs e)
		{
			if (base.m_txTextControl != null)
			{
				TableOfContents item = base.m_txTextControl.TablesOfContents.GetItem();
				if (item != null)
				{
					item.Title = (sender as RibbonTextBox).Text;
				}
			}
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_TOCShowPageNumbers_Handler(object sender, EventArgs e)
		{
			if (base.m_txTextControl != null)
			{
				bool @checked = (sender as RibbonToggleButton).Checked;
				RibbonToggleButton ribbonToggleButton = this.class510_0.TXITEM_TableOfContentsPropertiesGroup_Items[RibbonReferencesTab.InternalRibbonItem.TXITEM_TOCRightAlignPageNumbers.ToString()] as RibbonToggleButton;
				ribbonToggleButton.Enabled = @checked;
				TableOfContents item = base.m_txTextControl.TablesOfContents.GetItem();
				if (item != null)
				{
					item.HasPageNumbers = @checked;
				}
			}
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_TOCRightAlignPageNumbers_Handler(object sender, EventArgs e)
		{
			if (base.m_txTextControl != null)
			{
				TableOfContents item = base.m_txTextControl.TablesOfContents.GetItem();
				if (item != null)
				{
					item.HasRightAlignedPageNumbers = (sender as RibbonToggleButton).Checked;
				}
			}
		}

		private void method_18(object sender, RibbonListView.RibbonListViewItemEventArgs e)
		{
			if (base.m_txTextControl != null && this.string_0 != (this.string_0 = e.Item.DropDown.SelectedItem))
			{
				ParagraphStyle item = base.m_txTextControl.ParagraphStyles.GetItem(e.Item.Tag.ToString());
				item.ParagraphFormat.StructureLevel = e.Item.DropDown.SelectedIndex;
				item.Apply();
			}
			if (e.Item.DropDown.SelectedIndex == 0)
			{
				e.Item.DropDown.Text = "";
			}
			this.string_0 = null;
		}

		private void method_19(object sender, RibbonListView.RibbonListViewItemEventArgs e)
		{
			this.string_0 = e.Item.DropDown.SelectedItem;
		}

		private void method_20(object sender, EventArgs e)
		{
			this.method_1(sender as RibbonToggleButton);
		}

		private void method_21(object sender, EventArgs e)
		{
			this.method_2();
		}

		private void method_22(object sender, EventArgs e)
		{
			this.method_3();
		}

		private void method_23(object sender, EventArgs e)
		{
			this.method_4();
		}

		private void method_24(object sender, EventArgs e)
		{
			this.method_5();
		}

		private void method_25(object sender, EventArgs e)
		{
			this.method_6();
		}

		private void method_26(object sender, EventArgs e)
		{
			this.method_7();
		}

		private void method_27(object sender, TableOfContentsEventArgs e)
		{
			this.method_8(e);
		}

		private void method_28(object sender, TableOfContentsEventArgs e)
		{
			this.method_9();
		}

		private void method_29(object sender, TableOfContentsEventArgs e)
		{
			this.method_9();
		}

		private void method_30(object sender, EventArgs e)
		{
			this.method_10();
		}

		private void method_31(object sender, EventArgs e)
		{
			this.method_11();
		}
	}
}
