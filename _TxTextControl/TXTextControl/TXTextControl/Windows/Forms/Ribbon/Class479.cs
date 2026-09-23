using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using TXTextControl;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class479 : BindingAdapter
	{
		private Class508 class508_0;

		private List<Class486> list_0 = new List<Class486>();

		[CompilerGenerated]
		private RibbonListView.RibbonListViewItem ribbonListViewItem_0;

		internal override Class500 RibbonGroupManager
		{
			get
			{
				return this.class508_0;
			}
			set
			{
				this.class508_0 = value as Class508;
				this.RibbonListViewItem_0 = this.method_24(base.m_rmResourceManager.GetString("LABEL_AllUsersItem"), new Class486(""));
			}
		}

		internal RibbonListView.RibbonListViewItem RibbonListViewItem_0
		{
			[CompilerGenerated]
			get
			{
				return this.ribbonListViewItem_0;
			}
			[CompilerGenerated]
			set
			{
				this.ribbonListViewItem_0 = value;
			}
		}

		private void method_0(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonListView)
			{
				RibbonListView ribbonListView = control_0 as RibbonListView;
				ribbonListView.ItemClick += method_32;
				ribbonListView.ItemsSource = new RibbonListView.RibbonListViewItem[1] { this.RibbonListViewItem_0 };
				RibbonSeperator ribbonSeperator = new RibbonSeperator();
				ribbonSeperator.Name = RibbonPermissionsTab.InternalRibbonItem.TXITEM_UsersSeperator1.ToString();
				RibbonSeperator ribbonSeperator2 = ribbonSeperator;
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonPermissionsTab.InternalRibbonItem.TXITEM_Users_Dialog.ToString(), null, this);
				ribbonButton.Click += TXITEM_ReadOnlyExceptionsGroup_Handler;
				ribbonListView.DropDownItems.AddRange(new Control[2] { ribbonSeperator2, ribbonButton });
			}
		}

		internal override void AwareOfDPI(PointF dpi)
		{
			base.AwareOfDPI(dpi);
			(this.class508_0.TXITEM_ReadOnlyExceptionsGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_Users.ToString()] as RibbonListView).MinimumSize = Class517.smethod_48(Class519.Class534.Size_0, dpi);
		}

		internal override void SetRibbonItemAppearance(Dictionary<string, object> groupItemsDictionary, Control ribbonItem, string eventName, bool hasImage)
		{
			base.SetBasicRibbonItemAppearance(groupItemsDictionary, ribbonItem, hasImage);
			string name;
			if ((name = ribbonItem.Name) != null && name == "TXITEM_Users")
			{
				this.method_0(groupItemsDictionary, ribbonItem);
			}
			if (eventName != null)
			{
				Class517.smethod_23(ribbonItem, eventName, ribbonItem.Name + "_Handler", this);
			}
		}

		internal override void OnDisconnectingTextControl()
		{
			base.m_txTextControl.DocumentLoaded -= method_33;
			base.m_txTextControl.ContentsReset -= method_34;
			base.m_txTextControl.EditableRegionCreated -= method_35;
			base.m_txTextControl.EditableRegionEntered -= method_36;
			base.m_txTextControl.EditableRegionLeft -= method_37;
			base.m_txTextControl.EditableRegionDeleted -= method_37;
			this.method_27();
		}

		internal override void OnTextControlConnected()
		{
			base.m_txTextControl.DocumentLoaded += method_33;
			base.m_txTextControl.ContentsReset += method_34;
			base.m_txTextControl.EditableRegionCreated += method_35;
			base.m_txTextControl.EditableRegionEntered += method_36;
			base.m_txTextControl.EditableRegionLeft += method_37;
			base.m_txTextControl.EditableRegionDeleted += method_37;
			this.method_30();
			this.method_27();
		}

		private void method_1(bool bool_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.DocumentPermissions.AllowFormatting = bool_0;
				this.method_19();
			}
		}

		private void method_2(bool bool_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.DocumentPermissions.AllowFormattingStyles = bool_0;
				this.method_19();
			}
		}

		private void method_3(bool bool_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.DocumentPermissions.AllowPrinting = bool_0;
				this.method_19();
			}
		}

		private void method_4(bool bool_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.DocumentPermissions.AllowCopy = bool_0;
				this.method_19();
			}
		}

		private void method_5(bool bool_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.DocumentPermissions.AllowEditingFormFields = bool_0;
				this.method_19();
			}
		}

		private void method_6(bool bool_0)
		{
			if (base.m_txTextControl != null)
			{
				HorizontalRibbonGroup obj = this.class508_0.TXITEM_ReadOnlyExceptionsGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_ReadOnlyExceptionsGroup.ToString()] as HorizontalRibbonGroup;
				bool visible = (base.m_txTextControl.DocumentPermissions.ReadOnly = bool_0);
				obj.Visible = visible;
				this.method_19();
			}
		}

		private void method_7()
		{
			if (base.m_txTextControl != null)
			{
				RibbonListView ribbonListView = this.class508_0.TXITEM_ReadOnlyExceptionsGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_Users.ToString()] as RibbonListView;
				AddUsersDialog addUsersDialog = new AddUsersDialog(base.m_txTextControl, ribbonListView.ItemsSource, this);
				addUsersDialog.TXITEM_NewUserComboBox.DropDownStyle = ((this.class508_0.Control_0 as RibbonPermissionsTab).AllowAddingUserNames ? ComboBoxStyle.DropDown : ComboBoxStyle.DropDownList);
				string[] registeredUserNames = (this.class508_0.Control_0 as RibbonPermissionsTab).RegisteredUserNames;
				registeredUserNames = ((registeredUserNames == null) ? new string[0] : registeredUserNames);
				addUsersDialog.TXITEM_NewUserComboBox.Items.AddRange(registeredUserNames);
				if (addUsersDialog.ShowDialog() == DialogResult.OK)
				{
					ribbonListView.ItemsSource = addUsersDialog.RibbonListViewItem_0;
				}
			}
		}

		private void method_8(RibbonListView ribbonListView_0, RibbonListView.RibbonListViewItemEventArgs ribbonListViewItemEventArgs_0)
		{
			Class486 @class = ribbonListViewItemEventArgs_0.Item.Tag as Class486;
			if (ribbonListViewItemEventArgs_0.Item.IsSelected)
			{
				EditableRegion editableRegion = new EditableRegion((@class != null) ? @class.String_0 : "", 0);
				editableRegion.HighlightMode = ((!(this.class508_0.TXITEM_EditRestrictedDocumentGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_HighlightEditableRegions.ToString()] as RibbonToggleButton).Checked) ? HighlightMode.Never : HighlightMode.Always);
				EditableRegionCollection.AddResult addResult = base.m_txTextControl.EditableRegions.Add(editableRegion);
				if (ribbonListViewItemEventArgs_0.Item.IsSelected = addResult == EditableRegionCollection.AddResult.Successful || addResult == EditableRegionCollection.AddResult.Combined)
				{
					@class.EditableRegion_0 = editableRegion;
				}
				else if (base.m_txTextControl.Selection.Length == 0)
				{
					MessageBox.Show(base.m_rmResourceManager.GetString("MSG_EDITABLE_REGION_NO_SELECTION_TEXT"), base.m_rmResourceManager.GetString("MSG_EDITABLE_REGION_NO_SELECTION_CAPTION"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			else if (@class.EditableRegion_0 != null)
			{
				base.m_txTextControl.EditableRegions.Remove(@class.EditableRegion_0, base.m_txTextControl.Selection.Length > 0);
			}
			ribbonListView_0.ScrollTo(ribbonListViewItemEventArgs_0.Item);
		}

		private void method_9(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.EditMode = ((!ribbonToggleButton_0.Checked) ? EditMode.Edit : ((EditMode)2050));
				ribbonToggleButton_0.Checked = base.m_txTextControl.EditMode == EditMode.ReadAndSelect;
				(this.class508_0.TXITEM_ReadOnlyExceptionsGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_ReadOnlyExceptionsGroup.ToString()] as RibbonGroup).Visible = !ribbonToggleButton_0.Checked && (this.class508_0.TXITEM_RestrictEditingGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_ReadOnly.ToString()] as RibbonToggleButton).Checked;
			}
		}

		private void method_10()
		{
			if (base.m_txTextControl != null)
			{
				this.method_30();
			}
		}

		private void method_11()
		{
			if (base.m_txTextControl != null)
			{
				RibbonToggleButton ribbonToggleButton = this.class508_0.TXITEM_EditRestrictedDocumentGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_EnforceProtection.ToString()] as RibbonToggleButton;
				string[] string_ = ((!ribbonToggleButton.Checked) ? null : ((base.m_txTextControl.UserNames == null) ? new string[0] : base.m_txTextControl.UserNames));
				this.method_26(base.m_txTextControl.InputPosition.TextPosition + 1, string_)?.ScrollTo();
			}
		}

		private void method_12()
		{
			if (base.m_txTextControl != null)
			{
				RibbonToggleButton ribbonToggleButton = this.class508_0.TXITEM_EditRestrictedDocumentGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_EnforceProtection.ToString()] as RibbonToggleButton;
				string[] string_ = ((!ribbonToggleButton.Checked) ? null : ((base.m_txTextControl.UserNames == null) ? new string[0] : base.m_txTextControl.UserNames));
				this.method_25(base.m_txTextControl.InputPosition.TextPosition + 1, string_)?.ScrollTo();
			}
		}

		private void method_13()
		{
			this.method_30();
			if (base.m_txTextControl.EditMode == EditMode.Edit)
			{
				base.m_txTextControl.DocumentPermissions.ReadOnly = false;
			}
			RibbonGroup ribbonGroup_ = this.class508_0.TXITEM_ReadOnlyExceptionsGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_ReadOnlyExceptionsGroup.ToString()] as RibbonGroup;
			if (this.class508_0.method_0(ribbonGroup_))
			{
				this.method_27();
				foreach (EditableRegion editableRegion in base.m_txTextControl.EditableRegions)
				{
					if (this.method_23(editableRegion))
					{
						break;
					}
				}
			}
			if (this.class508_0.Boolean_0)
			{
				this.UpdateRibbonTab();
			}
		}

		private void method_14()
		{
			base.m_txTextControl.DocumentPermissions.ReadOnly = false;
			this.method_27();
			if (this.class508_0.Boolean_0)
			{
				this.UpdateRibbonTab();
			}
		}

		private void method_15(EditableRegionEventArgs editableRegionEventArgs_0)
		{
			RibbonGroup ribbonGroup_ = this.class508_0.TXITEM_ReadOnlyExceptionsGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_ReadOnlyExceptionsGroup.ToString()] as RibbonGroup;
			if (this.class508_0.method_0(ribbonGroup_))
			{
				this.method_28(editableRegionEventArgs_0.EditableRegion, bool_0: true);
				this.method_23(editableRegionEventArgs_0.EditableRegion);
			}
		}

		private void method_16(EditableRegionEventArgs editableRegionEventArgs_0)
		{
			RibbonGroup ribbonGroup_ = this.class508_0.TXITEM_ReadOnlyExceptionsGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_ReadOnlyExceptionsGroup.ToString()] as RibbonGroup;
			if (this.class508_0.method_0(ribbonGroup_))
			{
				RibbonListView ribbonListView_ = this.class508_0.TXITEM_ReadOnlyExceptionsGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_Users.ToString()] as RibbonListView;
				this.method_31(ribbonListView_, editableRegionEventArgs_0.EditableRegion, bool_0: true);
			}
		}

		private void method_17(EditableRegionEventArgs editableRegionEventArgs_0)
		{
			RibbonGroup ribbonGroup_ = this.class508_0.TXITEM_ReadOnlyExceptionsGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_ReadOnlyExceptionsGroup.ToString()] as RibbonGroup;
			if (this.class508_0.method_0(ribbonGroup_))
			{
				RibbonListView ribbonListView_ = this.class508_0.TXITEM_ReadOnlyExceptionsGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_Users.ToString()] as RibbonListView;
				this.method_31(ribbonListView_, editableRegionEventArgs_0.EditableRegion, bool_0: false);
			}
		}

		internal void method_18()
		{
			this.method_20();
		}

		internal override void UpdateRibbonTab(params object[] args)
		{
			this.method_21();
			this.method_22();
			this.method_19();
		}

		private void method_19()
		{
			RibbonToggleButton ribbonToggleButton = this.class508_0.TXITEM_RestrictFormattingGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_AllowFormatting.ToString()] as RibbonToggleButton;
			RibbonToggleButton ribbonToggleButton2 = this.class508_0.TXITEM_RestrictFormattingGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_AllowFormattingStyles.ToString()] as RibbonToggleButton;
			RibbonToggleButton ribbonToggleButton3 = this.class508_0.TXITEM_RestrictEditingGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_ReadOnly.ToString()] as RibbonToggleButton;
			RibbonToggleButton ribbonToggleButton4 = this.class508_0.TXITEM_RestrictEditingGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_AllowPrinting.ToString()] as RibbonToggleButton;
			RibbonToggleButton ribbonToggleButton5 = this.class508_0.TXITEM_RestrictEditingGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_AllowCopy.ToString()] as RibbonToggleButton;
			RibbonToggleButton ribbonToggleButton6 = this.class508_0.TXITEM_RestrictEditingGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_FillInFormFields.ToString()] as RibbonToggleButton;
			bool enabled = (ribbonToggleButton2.Enabled = !ribbonToggleButton3.Checked);
			ribbonToggleButton.Enabled = enabled;
			RibbonToggleButton ribbonToggleButton7 = this.class508_0.TXITEM_EditRestrictedDocumentGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_EnforceProtection.ToString()] as RibbonToggleButton;
			ribbonToggleButton7.Enabled = ribbonToggleButton3.Checked || !ribbonToggleButton.Checked || !ribbonToggleButton2.Checked || !ribbonToggleButton4.Checked || !ribbonToggleButton5.Checked || ribbonToggleButton6.Checked;
			(this.class508_0.TXITEM_ReadOnlyExceptionsGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_ReadOnlyExceptionsGroup.ToString()] as HorizontalRibbonGroup).Visible = !ribbonToggleButton7.Checked && ribbonToggleButton3.Checked;
		}

		internal void method_20()
		{
			RibbonToggleButton ribbonToggleButton = this.class508_0.TXITEM_EditRestrictedDocumentGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_EnforceProtection.ToString()] as RibbonToggleButton;
			bool flag2 = (ribbonToggleButton.Checked = base.m_txTextControl.EditMode == EditMode.ReadAndSelect);
			bool flag3 = flag2;
			(this.class508_0.TXITEM_RestrictEditingGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_RestrictEditingGroup.ToString()] as RibbonGroup).Enabled = !flag3;
			(this.class508_0.TXITEM_RestrictFormattingGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_RestrictFormattingGroup.ToString()] as RibbonGroup).Enabled = !flag3;
			(this.class508_0.TXITEM_ReadOnlyExceptionsGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_ReadOnlyExceptionsGroup.ToString()] as HorizontalRibbonGroup).Visible = !flag3 && (this.class508_0.TXITEM_RestrictEditingGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_ReadOnly.ToString()] as RibbonToggleButton).Checked;
		}

		private void method_21()
		{
			RibbonToggleButton ribbonToggleButton = this.class508_0.TXITEM_RestrictFormattingGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_AllowFormatting.ToString()] as RibbonToggleButton;
			ribbonToggleButton.Checked = base.m_txTextControl.DocumentPermissions.AllowFormatting;
			RibbonToggleButton ribbonToggleButton2 = this.class508_0.TXITEM_RestrictFormattingGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_AllowFormattingStyles.ToString()] as RibbonToggleButton;
			ribbonToggleButton2.Checked = base.m_txTextControl.DocumentPermissions.AllowFormattingStyles;
		}

		private void method_22()
		{
			RibbonToggleButton ribbonToggleButton = this.class508_0.TXITEM_RestrictEditingGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_AllowPrinting.ToString()] as RibbonToggleButton;
			ribbonToggleButton.Checked = base.m_txTextControl.DocumentPermissions.AllowPrinting;
			RibbonToggleButton ribbonToggleButton2 = this.class508_0.TXITEM_RestrictEditingGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_AllowCopy.ToString()] as RibbonToggleButton;
			ribbonToggleButton2.Checked = base.m_txTextControl.DocumentPermissions.AllowCopy;
			RibbonToggleButton ribbonToggleButton3 = this.class508_0.TXITEM_RestrictEditingGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_FillInFormFields.ToString()] as RibbonToggleButton;
			ribbonToggleButton3.Checked = base.m_txTextControl.DocumentPermissions.AllowEditingFormFields;
			RibbonToggleButton ribbonToggleButton4 = this.class508_0.TXITEM_RestrictEditingGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_ReadOnly.ToString()] as RibbonToggleButton;
			ribbonToggleButton4.Checked = base.m_txTextControl.DocumentPermissions.ReadOnly;
		}

		private bool method_23(EditableRegion editableRegion_0)
		{
			if (editableRegion_0.Start <= base.m_txTextControl.InputPosition.TextPosition + 1 && base.m_txTextControl.InputPosition.TextPosition + 1 <= editableRegion_0.Start + editableRegion_0.Length)
			{
				RibbonListView ribbonListView_ = this.class508_0.TXITEM_ReadOnlyExceptionsGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_Users.ToString()] as RibbonListView;
				this.method_31(ribbonListView_, editableRegion_0, bool_0: true);
				return true;
			}
			return false;
		}

		internal RibbonListView.RibbonListViewItem method_24(string string_0, Class486 class486_0)
		{
			RibbonListView.RibbonListViewItem ribbonListViewItem = new RibbonListView.RibbonListViewItem();
			ribbonListViewItem.Text = string_0;
			ribbonListViewItem.Tag = class486_0;
			RibbonListView.RibbonListViewItem ribbonListViewItem2 = ribbonListViewItem;
			string title;
			string description;
			if (string.IsNullOrEmpty(class486_0.String_0))
			{
				title = base.m_rmResourceManager.GetString("TOOLTIPTITLE_AllUsersItem");
				description = base.m_rmResourceManager.GetString("TOOLTIP_AllUsersItem");
			}
			else
			{
				title = string.Format(base.m_rmResourceManager.GetString("TOOLTIPTITLE_UserItem"), class486_0.String_0);
				description = string.Format(base.m_rmResourceManager.GetString("TOOLTIP_UserItem"), class486_0.String_0);
			}
			ribbonListViewItem2.ToolTip.Title = title;
			ribbonListViewItem2.ToolTip.Description = description;
			return ribbonListViewItem2;
		}

		private EditableRegion method_25(int int_0, string[] string_0)
		{
			if (base.m_txTextControl.EditableRegions.Count > 0)
			{
				EditableRegion editableRegion = null;
				{
					foreach (EditableRegion editableRegion2 in base.m_txTextControl.EditableRegions)
					{
						if (editableRegion == null && (string.IsNullOrEmpty(editableRegion2.UserName) || string_0 == null || Array.IndexOf(string_0, editableRegion2.UserName) != -1))
						{
							editableRegion = editableRegion2;
						}
						if (editableRegion2.Start > int_0 && (string.IsNullOrEmpty(editableRegion2.UserName) || string_0 == null || Array.IndexOf(string_0, editableRegion2.UserName) != -1))
						{
							return editableRegion2;
						}
					}
					return editableRegion;
				}
			}
			return null;
		}

		private EditableRegion method_26(int int_0, string[] string_0)
		{
			if (base.m_txTextControl.EditableRegions.Count > 0)
			{
				EditableRegion editableRegion = null;
				int num = base.m_txTextControl.EditableRegions.Count;
				EditableRegion editableRegion2;
				while (true)
				{
					if (num > 0)
					{
						editableRegion2 = base.m_txTextControl.EditableRegions[num];
						if (editableRegion == null && (string.IsNullOrEmpty(editableRegion2.UserName) || string_0 == null || Array.IndexOf(string_0, editableRegion2.UserName) != -1))
						{
							editableRegion = editableRegion2;
						}
						if (editableRegion2.Start < int_0 && (string.IsNullOrEmpty(editableRegion2.UserName) || string_0 == null || Array.IndexOf(string_0, editableRegion2.UserName) != -1))
						{
							break;
						}
						num--;
						continue;
					}
					return editableRegion;
				}
				return editableRegion2;
			}
			return null;
		}

		private void method_27()
		{
			this.RibbonListViewItem_0.IsSelected = false;
			(this.RibbonListViewItem_0.Tag as Class486).EditableRegion_0 = null;
			if (base.m_txTextControl != null)
			{
				Dictionary<string, RibbonListView.RibbonListViewItem> dictionary = new Dictionary<string, RibbonListView.RibbonListViewItem>();
				dictionary.Add("", this.RibbonListViewItem_0);
				foreach (IFormattedText textPart in base.m_txTextControl.TextParts)
				{
					foreach (EditableRegion editableRegion in textPart.EditableRegions)
					{
						string text = (string.IsNullOrEmpty(editableRegion.UserName) ? "" : editableRegion.UserName);
						if (!dictionary.TryGetValue(text, out var value))
						{
							value = this.method_24(text, new Class486(text));
							dictionary.Add(text, value);
						}
					}
				}
				RibbonListView ribbonListView = this.class508_0.TXITEM_ReadOnlyExceptionsGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_Users.ToString()] as RibbonListView;
				if (base.m_txTextControl.EditableRegions.Count > 0)
				{
					EditableRegion[] items = base.m_txTextControl.EditableRegions.GetItems();
					if (items != null && items.Length > 0)
					{
						EditableRegion[] array = items;
						foreach (EditableRegion editableRegion_ in array)
						{
							this.method_31(ribbonListView, editableRegion_, bool_0: true);
						}
					}
				}
				RibbonListView.RibbonListViewItem[] array2 = new RibbonListView.RibbonListViewItem[dictionary.Values.Count];
				dictionary.Values.CopyTo(array2, 0);
				ribbonListView.ItemsSource = array2;
			}
			else
			{
				RibbonListView ribbonListView2 = this.class508_0.TXITEM_ReadOnlyExceptionsGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_Users.ToString()] as RibbonListView;
				ribbonListView2.ItemsSource = new RibbonListView.RibbonListViewItem[1] { this.RibbonListViewItem_0 };
			}
		}

		private void method_28(EditableRegion editableRegion_0, bool bool_0)
		{
			string text = (string.IsNullOrEmpty(editableRegion_0.UserName) ? "" : editableRegion_0.UserName);
			RibbonListView ribbonListView = this.class508_0.TXITEM_ReadOnlyExceptionsGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_Users.ToString()] as RibbonListView;
			RibbonListView.RibbonListViewItem[] itemsSource = ribbonListView.ItemsSource;
			int num = 0;
			while (true)
			{
				if (num < itemsSource.Length)
				{
					RibbonListView.RibbonListViewItem ribbonListViewItem = itemsSource[num];
					Class486 @class = ribbonListViewItem.Tag as Class486;
					if (@class == null || !(@class.String_0 == text))
					{
						num++;
						continue;
					}
					break;
				}
				List<RibbonListView.RibbonListViewItem> list = new List<RibbonListView.RibbonListViewItem>(ribbonListView.ItemsSource);
				RibbonListView.RibbonListViewItem item = this.method_24(text, new Class486(editableRegion_0.UserName));
				list.Add(item);
				ribbonListView.ItemsSource = list.ToArray();
				break;
			}
		}

		private void method_29(RibbonListView.RibbonListViewItem ribbonListViewItem_1, EditableRegion editableRegion_0, int int_0, bool bool_0)
		{
			if (editableRegion_0.Start <= int_0 && int_0 <= editableRegion_0.Start + editableRegion_0.Length)
			{
				ribbonListViewItem_1.IsSelected = true;
				(ribbonListViewItem_1.Tag as Class486).EditableRegion_0 = editableRegion_0;
			}
			else if (bool_0)
			{
				ribbonListViewItem_1.IsSelected = false;
				(ribbonListViewItem_1.Tag as Class486).EditableRegion_0 = null;
			}
		}

		private void method_30()
		{
			bool @checked = (this.class508_0.TXITEM_EditRestrictedDocumentGroup_Items[RibbonPermissionsTab.InternalRibbonItem.TXITEM_HighlightEditableRegions.ToString()] as RibbonToggleButton).Checked;
			foreach (IFormattedText textPart in base.m_txTextControl.TextParts)
			{
				if (@checked)
				{
					foreach (EditableRegion editableRegion3 in textPart.EditableRegions)
					{
						if (editableRegion3.HighlightMode != HighlightMode.Always)
						{
							editableRegion3.HighlightMode = HighlightMode.Always;
						}
					}
					continue;
				}
				foreach (EditableRegion editableRegion4 in textPart.EditableRegions)
				{
					if (editableRegion4.HighlightMode != HighlightMode.Never)
					{
						editableRegion4.HighlightMode = HighlightMode.Never;
					}
				}
			}
			base.m_txTextControl.Invalidate();
		}

		private void method_31(RibbonListView ribbonListView_0, EditableRegion editableRegion_0, bool bool_0)
		{
			RibbonListView.RibbonListViewItem ribbonListViewItem = null;
			RibbonListView.RibbonListViewItem[] itemsSource = ribbonListView_0.ItemsSource;
			foreach (RibbonListView.RibbonListViewItem ribbonListViewItem2 in itemsSource)
			{
				Class486 @class = ribbonListViewItem2.Tag as Class486;
				string text = (string.IsNullOrEmpty(editableRegion_0.UserName) ? "" : editableRegion_0.UserName);
				if (@class != null && @class.String_0 == text)
				{
					bool flag2 = (ribbonListViewItem2.IsSelected = bool_0);
					@class.EditableRegion_0 = (flag2 ? editableRegion_0 : null);
					if (ribbonListViewItem2.IsSelected && ribbonListViewItem == null)
					{
						ribbonListViewItem = ribbonListViewItem2;
					}
					break;
				}
			}
			if (ribbonListViewItem != null)
			{
				ribbonListView_0.ScrollTo(ribbonListViewItem);
			}
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_AllowFormatting_Handler(object sender, EventArgs e)
		{
			this.method_1((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_AllowFormattingStyles_Handler(object sender, EventArgs e)
		{
			this.method_2((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_AllowPrinting_Handler(object sender, EventArgs e)
		{
			this.method_3((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_AllowCopy_Handler(object sender, EventArgs e)
		{
			this.method_4((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_FillInFormFields_Handler(object sender, EventArgs e)
		{
			this.method_5((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_ReadOnly_Handler(object sender, EventArgs e)
		{
			this.method_6((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_ReadOnlyExceptionsGroup_Handler(object sender, EventArgs e)
		{
			this.method_7();
		}

		private void method_32(object sender, RibbonListView.RibbonListViewItemEventArgs e)
		{
			this.method_8(sender as RibbonListView, e);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_EnforceProtection_Handler(object sender, EventArgs e)
		{
			this.method_9(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_HighlightEditableRegions_Handler(object sender, EventArgs e)
		{
			this.method_10();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_PreviousEditableRegion_Handler(object sender, EventArgs e)
		{
			this.method_11();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_NextEditableRegion_Handler(object sender, EventArgs e)
		{
			this.method_12();
		}

		internal void method_33(object sender, EventArgs e)
		{
			this.method_13();
		}

		internal void method_34(object sender, EventArgs e)
		{
			this.method_14();
		}

		private void method_35(object sender, EditableRegionEventArgs e)
		{
			this.method_15(e);
		}

		private void method_36(object sender, EditableRegionEventArgs e)
		{
			this.method_16(e);
		}

		private void method_37(object sender, EditableRegionEventArgs e)
		{
			this.method_17(e);
		}
	}
}
