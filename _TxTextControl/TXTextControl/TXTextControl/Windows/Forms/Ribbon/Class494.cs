using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using TXTextControl;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class494
	{
		private Class474 class474_0;

		private string string_0 = "";

		private RibbonListView.Enum137 enum137_0 = RibbonListView.Enum137.const_9;

		private RibbonGroup ribbonGroup_0;

		private RibbonButton ribbonButton_0;

		private RibbonButton ribbonButton_1;

		private RibbonTextBox ribbonTextBox_0;

		private RibbonListView ribbonListView_0;

		private RibbonButton ribbonButton_2;

		private RibbonButton ribbonButton_3;

		private RibbonButton ribbonButton_4;

		private RibbonComboBox ribbonComboBox_0;

		private SelectionFormField selectionFormField_0;

		private DateFormField dateFormField_0;

		private bool bool_0;

		private bool bool_1 = true;

		internal RibbonGroup RibbonGroup_0
		{
			get
			{
				return this.ribbonGroup_0;
			}
			set
			{
				this.ribbonGroup_0 = value;
			}
		}

		internal RibbonTextBox RibbonTextBox_0
		{
			get
			{
				return this.ribbonTextBox_0;
			}
			set
			{
				if (this.ribbonTextBox_0 != null)
				{
					this.ribbonTextBox_0.UpButtonClicked -= ribbonTextBox_0_UpButtonClicked;
					this.ribbonTextBox_0.DownButtonClicked -= ribbonTextBox_0_DownButtonClicked;
					this.ribbonTextBox_0.TextValidated -= ribbonTextBox_0_TextValidated;
				}
				if ((this.ribbonTextBox_0 = value) != null)
				{
					this.ribbonTextBox_0.UpButtonClicked += ribbonTextBox_0_UpButtonClicked;
					this.ribbonTextBox_0.DownButtonClicked += ribbonTextBox_0_DownButtonClicked;
					this.ribbonTextBox_0.TextValidated += ribbonTextBox_0_TextValidated;
				}
			}
		}

		internal RibbonButton RibbonButton_0
		{
			get
			{
				return this.ribbonButton_4;
			}
			set
			{
				if (this.ribbonButton_4 != null)
				{
					this.ribbonButton_4.Click -= ribbonButton_4_Click;
				}
				if ((this.ribbonButton_4 = value) != null)
				{
					this.ribbonButton_4.Click += ribbonButton_4_Click;
				}
			}
		}

		internal RibbonButton RibbonButton_1
		{
			get
			{
				return this.ribbonButton_0;
			}
			set
			{
				if (this.ribbonButton_0 != null)
				{
					this.ribbonButton_0.Click -= ribbonButton_0_Click;
				}
				if ((this.ribbonButton_0 = value) != null)
				{
					this.ribbonButton_0.Click += ribbonButton_0_Click;
				}
			}
		}

		internal RibbonButton RibbonButton_2
		{
			get
			{
				return this.ribbonButton_1;
			}
			set
			{
				if (this.ribbonButton_1 != null)
				{
					this.ribbonButton_1.Click -= ribbonButton_1_Click;
				}
				if ((this.ribbonButton_1 = value) != null)
				{
					this.ribbonButton_1.Click += ribbonButton_1_Click;
				}
			}
		}

		internal RibbonListView RibbonListView_0
		{
			get
			{
				return this.ribbonListView_0;
			}
			set
			{
				if (this.ribbonListView_0 != null)
				{
					this.ribbonListView_0.KeyDown -= ribbonListView_0_KeyDown;
					this.ribbonListView_0.PropertyChanged -= ribbonListView_0_PropertyChanged;
					this.ribbonListView_0.EditItemTextBoxActivated -= ribbonListView_0_EditItemTextBoxActivated;
					this.ribbonListView_0.EditItemTextBoxDeactivated -= ribbonListView_0_EditItemTextBoxDeactivated;
					this.ribbonListView_0.MouseClick -= ribbonListView_0_MouseClick;
					this.ribbonListView_0.DropDownOpening -= ribbonListView_0_DropDownOpening;
					this.ribbonListView_0.DropDownClosed -= ribbonListView_0_DropDownClosed;
					this.ribbonListView_0.KeyUp -= ribbonListView_0_KeyUp;
				}
				if ((this.ribbonListView_0 = value) != null)
				{
					this.ribbonListView_0.KeyDown += ribbonListView_0_KeyDown;
					this.ribbonListView_0.PropertyChanged += ribbonListView_0_PropertyChanged;
					this.ribbonListView_0.EditItemTextBoxActivated += ribbonListView_0_EditItemTextBoxActivated;
					this.ribbonListView_0.EditItemTextBoxDeactivated += ribbonListView_0_EditItemTextBoxDeactivated;
					this.ribbonListView_0.MouseClick += ribbonListView_0_MouseClick;
					this.ribbonListView_0.DropDownOpening += ribbonListView_0_DropDownOpening;
					this.ribbonListView_0.DropDownClosed += ribbonListView_0_DropDownClosed;
					this.ribbonListView_0.KeyUp += ribbonListView_0_KeyUp;
				}
			}
		}

		internal RibbonButton RibbonButton_3
		{
			get
			{
				return this.ribbonButton_2;
			}
			set
			{
				if (this.ribbonButton_2 != null)
				{
					this.ribbonButton_2.Click -= ribbonButton_2_Click;
				}
				if ((this.ribbonButton_2 = value) != null)
				{
					this.ribbonButton_2.Click += ribbonButton_2_Click;
				}
			}
		}

		internal RibbonButton RibbonButton_4
		{
			get
			{
				return this.ribbonButton_3;
			}
			set
			{
				if (this.ribbonButton_3 != null)
				{
					this.ribbonButton_3.Click -= ribbonButton_3_Click;
				}
				if ((this.ribbonButton_3 = value) != null)
				{
					this.ribbonButton_3.Click += ribbonButton_3_Click;
				}
			}
		}

		internal RibbonComboBox RibbonComboBox_0
		{
			get
			{
				return this.ribbonComboBox_0;
			}
			set
			{
				if (this.ribbonComboBox_0 != null)
				{
					this.ribbonComboBox_0.SelectedIndexChanged -= ribbonComboBox_0_SelectedIndexChanged;
				}
				this.ribbonComboBox_0 = value;
				if (this.ribbonComboBox_0 != null)
				{
					this.ribbonComboBox_0.SelectedIndexChanged += ribbonComboBox_0_SelectedIndexChanged;
				}
			}
		}

		internal Class494(Class474 class474_1)
		{
			this.class474_0 = class474_1;
		}

		private void ribbonTextBox_0_TextValidated(object sender, EventArgs e)
		{
			this.method_0();
		}

		private void ribbonTextBox_0_UpButtonClicked(object sender, EventArgs e)
		{
			this.method_1();
		}

		private void ribbonTextBox_0_DownButtonClicked(object sender, EventArgs e)
		{
			this.method_2();
		}

		private void ribbonButton_4_Click(object sender, EventArgs e)
		{
			this.method_3();
		}

		private void ribbonButton_0_Click(object sender, EventArgs e)
		{
			this.method_4();
		}

		private void ribbonButton_1_Click(object sender, EventArgs e)
		{
			this.method_5();
		}

		private void ribbonListView_0_KeyDown(object sender, KeyEventArgs e)
		{
			this.method_6(e);
		}

		private void ribbonListView_0_EditItemTextBoxActivated(object sender, RibbonListView.RibbonListViewItemEventArgs e)
		{
			this.method_7(e);
		}

		private void ribbonListView_0_EditItemTextBoxDeactivated(object sender, RibbonListView.RibbonListViewItemEventArgs e)
		{
			this.method_8(e);
		}

		private void ribbonListView_0_MouseClick(object sender, MouseEventArgs e)
		{
			this.method_9();
		}

		private void ribbonListView_0_DropDownOpening(object sender, EventArgs e)
		{
			this.method_10();
		}

		private void ribbonListView_0_DropDownClosed(object sender, EventArgs e)
		{
			this.method_11();
		}

		private void ribbonListView_0_KeyUp(object sender, KeyEventArgs e)
		{
			this.method_12(e);
		}

		private void ribbonListView_0_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			this.method_13(e);
		}

		private void ribbonButton_2_Click(object sender, EventArgs e)
		{
			this.method_14();
		}

		private void ribbonButton_3_Click(object sender, EventArgs e)
		{
			this.method_15();
		}

		private void ribbonComboBox_0_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.method_16();
		}

		private void method_0()
		{
			this.method_24(0.0);
		}

		private void method_1()
		{
			this.method_24(this.class474_0.double_1);
		}

		private void method_2()
		{
			this.method_24(0.0 - this.class474_0.double_1);
		}

		private void method_3()
		{
			if (this.class474_0.TextControl == null)
			{
				return;
			}
			FormField item = this.class474_0.TextControl.FormFields.GetItem();
			SelectionFormField selectionFormField = item as SelectionFormField;
			if (selectionFormField != null)
			{
				selectionFormField.SelectedIndex = -1;
				return;
			}
			TextFormField textFormField = item as TextFormField;
			if (textFormField != null)
			{
				textFormField.Text = "";
				return;
			}
			DateFormField dateFormField = item as DateFormField;
			if (dateFormField != null)
			{
				dateFormField.Date = null;
			}
		}

		private void method_4()
		{
			this.method_23();
		}

		private void method_5()
		{
			this.method_21();
		}

		private void method_6(KeyEventArgs keyEventArgs_0)
		{
			if ((keyEventArgs_0.Modifiers & Keys.Control) == Keys.Control)
			{
				if ((keyEventArgs_0.Modifiers & Keys.Shift) == Keys.Shift && (keyEventArgs_0.KeyCode & Keys.N) == Keys.N)
				{
					this.method_23();
				}
				else if ((keyEventArgs_0.KeyCode & Keys.D) == Keys.D)
				{
					this.method_21();
				}
			}
			else if (keyEventArgs_0.KeyCode == Keys.Delete)
			{
				this.method_21();
			}
		}

		private void method_7(RibbonListView.RibbonListViewItemEventArgs ribbonListViewItemEventArgs_0)
		{
			this.enum137_0 = ribbonListViewItemEventArgs_0.Enum137_0;
			this.string_0 = ribbonListViewItemEventArgs_0.Item.Text;
			this.method_27(bool_2: false);
		}

		private void method_8(RibbonListView.RibbonListViewItemEventArgs ribbonListViewItemEventArgs_0)
		{
			if (this.method_22(ribbonListViewItemEventArgs_0, out var ribbonListViewItem_))
			{
				return;
			}
			if (ribbonListViewItem_ != null)
			{
				this.ribbonListView_0.SelectedItems = new RibbonListView.RibbonListViewItem[1] { ribbonListViewItem_ };
				this.ribbonListView_0.ScrollTo(ribbonListViewItem_);
			}
			else
			{
				RibbonListView.RibbonListViewItem[] array = new RibbonListView.RibbonListViewItem[this.ribbonListView_0.ItemsSource.Length - 1];
				int num = 0;
				for (int i = 0; i < this.ribbonListView_0.ItemsSource.Length; i++)
				{
					if (i != ribbonListViewItemEventArgs_0.Item.Int32_1)
					{
						array[num] = this.ribbonListView_0.ItemsSource[i];
						num++;
					}
				}
				this.ribbonListView_0.ItemsSource = array;
				if (this.ribbonListView_0.RibbonListViewItems.Count > 0 && !this.ribbonListView_0.Class553_0.Boolean_2)
				{
					ribbonListViewItem_ = this.ribbonListView_0.RibbonListViewItems[this.ribbonListView_0.RibbonListViewItems.Count - 1];
					this.ribbonListView_0.SelectedItems = new RibbonListView.RibbonListViewItem[1] { ribbonListViewItem_ };
					this.ribbonListView_0.ScrollTo(ribbonListViewItem_);
				}
			}
			this.method_27(bool_2: true);
		}

		private void method_9()
		{
			if (!this.bool_0 && !this.ribbonListView_0.Class553_0.Boolean_2 && this.ribbonListView_0.SelectedIndices.Length == 0)
			{
				if (this.bool_1)
				{
					this.method_23();
				}
				this.bool_1 = true;
			}
			this.bool_0 = false;
		}

		private void method_10()
		{
			this.bool_1 = false;
		}

		private void method_11()
		{
			if (this.ribbonListView_0.SelectedIndices.Length == 1)
			{
				RibbonListView.RibbonListViewItem ribbonListViewItem = this.ribbonListView_0.RibbonListViewItems[this.ribbonListView_0.SelectedIndices[0]];
				this.ribbonListView_0.ScrollTo(ribbonListViewItem);
				this.ribbonListView_0.RibbonListViewItem_1 = ribbonListViewItem;
			}
		}

		private void method_12(KeyEventArgs keyEventArgs_0)
		{
			if (keyEventArgs_0.KeyCode == Keys.Escape)
			{
				this.bool_0 = false;
			}
		}

		private void method_13(PropertyChangedEventArgs propertyChangedEventArgs_0)
		{
			if (propertyChangedEventArgs_0.PropertyName == "SelectedIndices")
			{
				this.method_27(bool_2: true);
				this.bool_1 = true;
				this.bool_0 = this.ribbonListView_0.SelectedIndices.Length == 0;
			}
		}

		private void method_14()
		{
			this.method_25(-1);
			if (this.ribbonButton_2.Enabled)
			{
				this.ribbonButton_2.Focus();
			}
			else
			{
				this.ribbonButton_3.Focus();
			}
		}

		private void method_15()
		{
			this.method_25(1);
			if (this.ribbonButton_3.Enabled)
			{
				this.ribbonButton_3.Focus();
			}
			else
			{
				this.ribbonButton_2.Focus();
			}
		}

		private void method_16()
		{
			if (this.dateFormField_0 != null)
			{
				this.dateFormField_0.DateFormat = ((this.ribbonComboBox_0.SelectedIndex == 0) ? "" : this.ribbonComboBox_0.SelectedItem.ToString());
			}
		}

		internal void method_17(TextFormField textFormField_0)
		{
			if (this.class474_0.RibbonGroupManager.method_0(this.ribbonGroup_0))
			{
				this.selectionFormField_0 = null;
				this.dateFormField_0 = null;
				if (textFormField_0 != null && this.class474_0.TextControl != null && (this.class474_0.TextControl.EditMode != EditMode.ReadAndSelect || !this.class474_0.TextControl.DocumentPermissions.ReadOnly))
				{
					this.ribbonGroup_0.Visible = true;
					this.method_26(textFormField_0, double.NaN);
				}
				else
				{
					this.ribbonGroup_0.Visible = false;
				}
			}
		}

		internal void method_18(SelectionFormField selectionFormField_1, int int_0, TextField textField_0)
		{
			if (!this.class474_0.RibbonGroupManager.method_0(this.ribbonGroup_0))
			{
				return;
			}
			this.selectionFormField_0 = textField_0 as SelectionFormField;
			this.dateFormField_0 = null;
			if (selectionFormField_1 != null && this.class474_0.TextControl != null && (this.class474_0.TextControl.EditMode != EditMode.ReadAndSelect || !this.class474_0.TextControl.DocumentPermissions.ReadOnly))
			{
				this.bool_1 = true;
				this.bool_0 = false;
				this.ribbonGroup_0.Visible = true;
				if (this.class474_0.RibbonGroupManager.method_2(this.ribbonGroup_0))
				{
					this.method_26(selectionFormField_1, double.NaN);
					if (selectionFormField_1.Items != null)
					{
						List<RibbonListView.RibbonListViewItem> list = new List<RibbonListView.RibbonListViewItem>();
						string[] items = selectionFormField_1.Items;
						foreach (string text in items)
						{
							if (!string.IsNullOrEmpty(text))
							{
								list.Add(new RibbonListView.RibbonListViewItem
								{
									Text = text,
									IsEditable = true
								});
							}
						}
						this.ribbonListView_0.ItemsSource = list.ToArray();
						if (int_0 == -1)
						{
							if (!string.IsNullOrEmpty(selectionFormField_1.Text))
							{
								foreach (RibbonListView.RibbonListViewItem ribbonListViewItem in this.ribbonListView_0.RibbonListViewItems)
								{
									if (ribbonListViewItem.Text == selectionFormField_1.Text)
									{
										this.ribbonListView_0.SelectedItems = new RibbonListView.RibbonListViewItem[1] { ribbonListViewItem };
										this.ribbonListView_0.ScrollTo(ribbonListViewItem);
										break;
									}
								}
							}
						}
						else
						{
							this.ribbonListView_0.SelectedIndices = new int[1] { int_0 };
							this.ribbonListView_0.ScrollTo(this.ribbonListView_0.SelectedItems[0]);
						}
					}
					else
					{
						this.ribbonListView_0.ItemsSource = new RibbonListView.RibbonListViewItem[0];
					}
				}
				this.ribbonButton_1.Enabled = this.ribbonListView_0.SelectedItems.Length > 0;
			}
			else
			{
				this.ribbonGroup_0.Visible = false;
			}
		}

		internal void method_19(DateFormField dateFormField_1)
		{
			if (!this.class474_0.RibbonGroupManager.method_0(this.ribbonGroup_0))
			{
				return;
			}
			this.selectionFormField_0 = null;
			this.dateFormField_0 = null;
			if (dateFormField_1 != null && this.class474_0.TextControl != null && (this.class474_0.TextControl.EditMode != EditMode.ReadAndSelect || !this.class474_0.TextControl.DocumentPermissions.ReadOnly))
			{
				this.ribbonGroup_0.Visible = true;
				this.method_26(dateFormField_1, double.NaN);
				this.ribbonComboBox_0.Items.Clear();
				this.ribbonComboBox_0.Items.Add(this.class474_0.m_rmResourceManager.GetString("LABEL_DefaultDateFormat"));
				this.ribbonComboBox_0.Items.AddRange(dateFormField_1.SupportedDateFormats);
				if (string.IsNullOrEmpty(dateFormField_1.DateFormat))
				{
					this.ribbonComboBox_0.SelectedIndex = 0;
				}
				else
				{
					this.ribbonComboBox_0.SelectedItem = dateFormField_1.DateFormat;
				}
			}
			else
			{
				this.ribbonGroup_0.Visible = false;
			}
			this.dateFormField_0 = dateFormField_1;
		}

		internal void method_20()
		{
			if (this.ribbonTextBox_0 != null)
			{
				this.class474_0.SetBasicRibbonTextBoxAppearance(this.ribbonTextBox_0, this.ribbonTextBox_0.DisplayMode != IconTextRelation.NoIconLabeled, showDropDownButtons: true, RibbonTextBox.InputValidationMode.OnlyDigits);
				this.ribbonTextBox_0.Nullable_0 = this.class474_0.int_1;
				if (this.ribbonTextBox_0.Name == RibbonFormFieldsTab.InternalRibbonItem.TXITEM_DateFormFieldEmptyWidth.ToString())
				{
					this.ribbonTextBox_0.Label = "";
				}
			}
		}

		private void method_21()
		{
			if (this.class474_0.TextControl == null || this.ribbonListView_0.SelectedIndices.Length <= 0)
			{
				return;
			}
			string[] array = new string[this.ribbonListView_0.ItemsSource.Length - this.ribbonListView_0.SelectedIndices.Length];
			int num = 0;
			for (int i = 0; i < this.ribbonListView_0.ItemsSource.Length; i++)
			{
				bool flag = true;
				for (int j = 0; j < this.ribbonListView_0.SelectedIndices.Length; j++)
				{
					if (this.ribbonListView_0.SelectedIndices[j] == i)
					{
						flag = false;
						break;
					}
				}
				if (flag)
				{
					array[num] = this.ribbonListView_0.ItemsSource[i].Text;
					num++;
				}
			}
			FormField item = this.class474_0.TextControl.FormFields.GetItem();
			SelectionFormField selectionFormField = item as SelectionFormField;
			selectionFormField.Items = array;
			if (this.class474_0.TextControl.IsFormFieldValidationEnabled)
			{
				this.class474_0.TextControl.Class456_0.method_14(selectionFormField);
			}
			int int_ = -1;
			if (array.Length > 0)
			{
				int_ = Math.Min(this.ribbonListView_0.SelectedIndices[0], array.Length - 1);
			}
			this.method_18(selectionFormField, int_, null);
		}

		private bool method_22(RibbonListView.RibbonListViewItemEventArgs ribbonListViewItemEventArgs_0, out RibbonListView.RibbonListViewItem ribbonListViewItem_0)
		{
			ribbonListViewItem_0 = null;
			if (this.class474_0.TextControl != null)
			{
				if (ribbonListViewItemEventArgs_0.Enum137_0 == RibbonListView.Enum137.const_2)
				{
					if (this.enum137_0 == RibbonListView.Enum137.const_3 || this.enum137_0 == RibbonListView.Enum137.const_7)
					{
						ribbonListViewItem_0 = ribbonListViewItemEventArgs_0.Item;
					}
					this.selectionFormField_0 = null;
					return false;
				}
				SelectionFormField selectionFormField;
				if (ribbonListViewItemEventArgs_0.Enum137_0 == RibbonListView.Enum137.const_10)
				{
					selectionFormField = this.selectionFormField_0;
				}
				else
				{
					FormField item = this.class474_0.TextControl.FormFields.GetItem();
					selectionFormField = item as SelectionFormField;
				}
				this.selectionFormField_0 = null;
				if (selectionFormField != null)
				{
					if (string.IsNullOrEmpty(ribbonListViewItemEventArgs_0.Item.Text))
					{
						if (this.enum137_0 != RibbonListView.Enum137.const_3 && this.enum137_0 != RibbonListView.Enum137.const_7)
						{
							return false;
						}
						MessageBox.Show(this.class474_0.m_rmResourceManager.GetString("MSG_LISTITEMCANNOTBEBLANK_TEXT"), this.class474_0.m_rmResourceManager.GetString("MSG_LISTITEMCANNOTBEBLANK_CAPTION"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						ribbonListViewItemEventArgs_0.Item.Text = this.string_0;
						ribbonListViewItem_0 = ribbonListViewItemEventArgs_0.Item;
						return false;
					}
					string[] array = new string[this.ribbonListView_0.ItemsSource.Length];
					int num = 0;
					for (int i = 0; i < array.Length; i++)
					{
						if ((array[i] = this.ribbonListView_0.ItemsSource[i].Text) == ribbonListViewItemEventArgs_0.Item.Text)
						{
							num++;
						}
					}
					if (num != 1)
					{
						MessageBox.Show(this.class474_0.m_rmResourceManager.GetString("MSG_LISTITEMALREADYEXISTS_TEXT"), this.class474_0.m_rmResourceManager.GetString("MSG_LISTITEMALREADYEXISTS_CAPTION"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						string value = (ribbonListViewItemEventArgs_0.Item.Text = this.string_0);
						if (!string.IsNullOrEmpty(value))
						{
							ribbonListViewItem_0 = ribbonListViewItemEventArgs_0.Item;
						}
						return false;
					}
					selectionFormField.Items = array;
					if (this.class474_0.TextControl.IsFormFieldValidationEnabled)
					{
						this.class474_0.TextControl.Class456_0.method_14(selectionFormField);
					}
					if (this.enum137_0 == RibbonListView.Enum137.const_0 && ribbonListViewItemEventArgs_0.Enum137_0 == RibbonListView.Enum137.const_1)
					{
						this.method_23();
						return true;
					}
				}
			}
			ribbonListViewItem_0 = ribbonListViewItemEventArgs_0.Item;
			return false;
		}

		private void method_23()
		{
			if (this.class474_0.TextControl != null)
			{
				this.ribbonListView_0.DeactivateEditItemTextBox();
				RibbonListView.RibbonListViewItem[] array = new RibbonListView.RibbonListViewItem[this.ribbonListView_0.ItemsSource.Length + 1];
				array[this.ribbonListView_0.ItemsSource.Length] = new RibbonListView.RibbonListViewItem
				{
					Text = "",
					IsEditable = true
				};
				Array.Copy(this.ribbonListView_0.ItemsSource, 0, array, 0, this.ribbonListView_0.ItemsSource.Length);
				this.ribbonListView_0.ItemsSource = array;
				this.ribbonListView_0.ActivateEditItemTextBox(array[this.ribbonListView_0.ItemsSource.Length - 1]);
			}
		}

		private void method_24(double double_0)
		{
			if (this.class474_0.TextControl != null)
			{
				FormField item = this.class474_0.TextControl.FormFields.GetItem();
				if (item != null)
				{
					double double_ = ((!string.IsNullOrEmpty(this.ribbonTextBox_0.Text)) ? ((double)TwipsConverter.DotNet2Tw(Convert.ToDouble(this.ribbonTextBox_0.Text) + double_0, this.class474_0.measuringUnit_0) * this.class474_0.double_0) : (-1.0));
					this.method_26(item, double_);
				}
			}
		}

		private void method_25(int int_0)
		{
			if (this.class474_0.TextControl == null || this.ribbonListView_0.SelectedItems.Length != 1)
			{
				return;
			}
			string[] array = new string[this.ribbonListView_0.ItemsSource.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = this.ribbonListView_0.ItemsSource[i].Text;
			}
			int num = this.ribbonListView_0.SelectedIndices[0];
			array[num + int_0] = this.ribbonListView_0.ItemsSource[num].Text;
			array[num] = this.ribbonListView_0.ItemsSource[num + int_0].Text;
			FormField item = this.class474_0.TextControl.FormFields.GetItem();
			SelectionFormField selectionFormField = item as SelectionFormField;
			if (selectionFormField != null)
			{
				selectionFormField.Items = array;
				if (this.class474_0.TextControl.IsFormFieldValidationEnabled)
				{
					this.class474_0.TextControl.Class456_0.method_14(selectionFormField);
				}
				List<RibbonListView.RibbonListViewItem> list = new List<RibbonListView.RibbonListViewItem>();
				string[] items = selectionFormField.Items;
				foreach (string text in items)
				{
					if (!string.IsNullOrEmpty(text))
					{
						list.Add(new RibbonListView.RibbonListViewItem
						{
							Text = text,
							IsEditable = true
						});
					}
				}
				this.ribbonListView_0.ItemsSource = list.ToArray();
			}
			this.ribbonButton_1.Enabled = true;
			this.ribbonListView_0.SelectedIndices = new int[1] { num + int_0 };
			int number = ((int_0 < 0) ? Math.Max(this.ribbonListView_0.SelectedIndices[0] - 1, 0) : Math.Min(this.ribbonListView_0.SelectedIndices[0] - 1, this.ribbonListView_0.RibbonListViewItems.Count - 1));
			this.ribbonListView_0.ScrollTo(this.ribbonListView_0.RibbonListViewItems[number]);
		}

		private void method_26(FormField formField_0, double double_0)
		{
			int num = (int)double_0;
			if (formField_0 is SelectionFormField)
			{
				SelectionFormField selectionFormField = formField_0 as SelectionFormField;
				if (num > 0 && selectionFormField.EmptyWidth != num)
				{
					int num2 = this.class474_0.method_42();
					selectionFormField.EmptyWidth = ((num2 != 0) ? Math.Min(num, num2) : num);
				}
				num = selectionFormField.EmptyWidth;
			}
			else
			{
				TextFormField textFormField = formField_0 as TextFormField;
				if (textFormField != null)
				{
					if (num > 0 && textFormField.EmptyWidth != num)
					{
						int num3 = this.class474_0.method_42();
						textFormField.EmptyWidth = ((num3 != 0) ? Math.Min(num, num3) : num);
					}
					num = textFormField.EmptyWidth;
				}
				else
				{
					DateFormField dateFormField = formField_0 as DateFormField;
					if (dateFormField != null)
					{
						if (num > 0 && dateFormField.EmptyWidth != num)
						{
							dateFormField.EmptyWidth = num;
						}
						num = dateFormField.EmptyWidth;
					}
				}
			}
			this.ribbonTextBox_0.Text = (TwipsConverter.Tw2DotNet(num, this.class474_0.measuringUnit_0, this.class474_0.int_1) / this.class474_0.double_0).ToString();
		}

		private void method_27(bool bool_2)
		{
			if (bool_2)
			{
				this.ribbonButton_2.Enabled = this.ribbonListView_0.SelectedItems.Length == 1 && this.ribbonListView_0.SelectedItems[0].Int32_1 > 0;
				this.ribbonButton_3.Enabled = this.ribbonListView_0.SelectedItems.Length == 1 && this.ribbonListView_0.SelectedItems[0].Int32_1 < this.ribbonListView_0.RibbonListViewItems.Count - 1;
				this.ribbonButton_4.Enabled = true;
				this.ribbonTextBox_0.Enabled = true;
				this.ribbonButton_0.Enabled = true;
				this.ribbonButton_1.Enabled = this.ribbonListView_0.SelectedItems.Length > 0;
			}
			else
			{
				RibbonButton ribbonButton = this.ribbonButton_0;
				RibbonButton ribbonButton2 = this.ribbonButton_1;
				RibbonTextBox ribbonTextBox = this.ribbonTextBox_0;
				RibbonButton ribbonButton3 = this.ribbonButton_4;
				RibbonButton ribbonButton4 = this.ribbonButton_2;
				this.ribbonButton_3.Enabled = false;
				ribbonButton4.Enabled = false;
				ribbonButton3.Enabled = false;
				ribbonTextBox.Enabled = false;
				ribbonButton2.Enabled = false;
				ribbonButton.Enabled = false;
			}
		}
	}
}
