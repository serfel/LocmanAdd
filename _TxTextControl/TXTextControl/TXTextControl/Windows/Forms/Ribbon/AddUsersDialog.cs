using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ns21;
using ns27;
using TXTextControl;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class AddUsersDialog : Form
	{
		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private List<Class486> list_0 = new List<Class486>();

		private List<Class486> list_1 = new List<Class486>();

		private RibbonListView.RibbonListViewItem[] ribbonListViewItem_0;

		private Class479 class479_0;

		private TextControl textControl_0;

		private uint uint_0;

		private IContainer icontainer_0;

		private TableLayoutPanel TXITEM_MainPanel;

		private Label TXITEM_UsersLabel;

		private System.Windows.Forms.Button TXITEM_AddButton;

		private TableLayoutPanel TXITEM_BottomPanel;

		private System.Windows.Forms.Button TXITEM_Cancel;

		private ListBox TXITEM_UsersListBox;

		private Label TXITEM_NewUserLabel;

		private System.Windows.Forms.Button TXITEM_DeleteUserButton;

		private System.Windows.Forms.Button TXITEM_OK;

		internal ComboBox TXITEM_NewUserComboBox;

		internal RibbonListView.RibbonListViewItem[] RibbonListViewItem_0 => this.ribbonListViewItem_0;

		internal AddUsersDialog(TextControl textControl_1, RibbonListView.RibbonListViewItem[] ribbonListViewItem_1, Class479 class479_1)
		{
			this.InitializeComponent();
			this.textControl_0 = textControl_1;
			this.Text = this.resourceManager_0.GetString("ID_ADDUSERSDIALOG_CAPTION");
			this.TXITEM_NewUserLabel.Text = this.resourceManager_0.GetString("ID_ADDUSERSDIALOG_NEWUSER");
			this.TXITEM_AddButton.Text = this.resourceManager_0.GetString("ID_ADDUSERSDIALOG_ADD");
			this.TXITEM_UsersLabel.Text = this.resourceManager_0.GetString("ID_ADDUSERSDIALOG_USERS");
			this.TXITEM_DeleteUserButton.Text = this.resourceManager_0.GetString("ID_ADDUSERSDIALOG_DELETE");
			this.TXITEM_OK.Text = this.resourceManager_0.GetString("ID_ADDUSERSDIALOG_OK");
			this.TXITEM_Cancel.Text = this.resourceManager_0.GetString("ID_ADDUSERSDIALOG_CANCEL");
			this.ribbonListViewItem_0 = ribbonListViewItem_1;
			this.class479_0 = class479_1;
			for (int i = 0; i < ribbonListViewItem_1.Length; i++)
			{
				Class486 @class = ribbonListViewItem_1[i].Tag as Class486;
				if (!string.IsNullOrEmpty(@class.String_0))
				{
					@class.Boolean_0 = true;
					@class.String_1 = @class.String_0;
					this.list_1.Add(@class);
				}
			}
			this.TXITEM_UsersListBox.Items.AddRange(this.list_1.ToArray());
			if (this.TXITEM_UsersListBox.Items.Count > 0)
			{
				this.TXITEM_UsersListBox.SelectedIndex = 0;
			}
			this.TXITEM_DeleteUserButton.Enabled = this.TXITEM_UsersListBox.SelectedItem != null;
		}

		private void method_0()
		{
			string text = this.TXITEM_NewUserComboBox.Text;
			foreach (Class486 item in this.TXITEM_UsersListBox.Items)
			{
				if (text == item.String_0)
				{
					MessageBox.Show(this, this.resourceManager_0.GetString("ID_ADDUSERSDIALOG_ADD_MSG1_TEXT"), this.resourceManager_0.GetString("ID_ADDUSERSDIALOG_ADD_MSG1_TITLE"), MessageBoxButtons.OK, MessageBoxIcon.Hand);
					return;
				}
			}
			Class486 class2 = this.method_1(this.list_0, this.TXITEM_NewUserComboBox.Text);
			if (class2 != null)
			{
				this.list_0.Remove(class2);
			}
			else
			{
				class2 = new Class486(this.TXITEM_NewUserComboBox.Text);
			}
			this.list_1.Add(class2);
			this.TXITEM_UsersListBox.SelectedIndex = this.TXITEM_UsersListBox.Items.Add(class2);
			this.TXITEM_DeleteUserButton.Enabled = this.TXITEM_UsersListBox.SelectedItem != null;
			this.TXITEM_NewUserComboBox.Text = "";
		}

		private Class486 method_1(List<Class486> list_2, string string_0)
		{
			foreach (Class486 item in list_2)
			{
				if (item.String_0 == string_0)
				{
					return item;
				}
			}
			return null;
		}

		private void AddUsersDialog_Shown(object sender, EventArgs e)
		{
			this.TXITEM_NewUserComboBox.Focus();
		}

		private void TXITEM_AddButton_Click(object sender, EventArgs e)
		{
			this.method_0();
		}

		private void TXITEM_DeleteUserButton_Click(object sender, EventArgs e)
		{
			int selectedIndex = this.TXITEM_UsersListBox.SelectedIndex;
			Class486 @class = this.TXITEM_UsersListBox.SelectedItem as Class486;
			if (@class.Boolean_0)
			{
				this.list_0.Add(@class);
			}
			this.list_1.Remove(@class);
			this.TXITEM_UsersListBox.Items.Remove(this.TXITEM_UsersListBox.SelectedItem);
			if (this.TXITEM_UsersListBox.Items.Count > 0)
			{
				if (selectedIndex < this.TXITEM_UsersListBox.Items.Count)
				{
					this.TXITEM_UsersListBox.SelectedIndex = selectedIndex;
				}
				else
				{
					this.TXITEM_UsersListBox.SelectedIndex = this.TXITEM_UsersListBox.Items.Count - 1;
				}
			}
			this.TXITEM_DeleteUserButton.Enabled = this.TXITEM_UsersListBox.SelectedItem != null;
		}

		private void TXITEM_NewUserComboBox_Enter(object sender, EventArgs e)
		{
			base.AcceptButton = null;
		}

		private void TXITEM_NewUserComboBox_TextChanged(object sender, EventArgs e)
		{
			this.TXITEM_AddButton.Enabled = this.TXITEM_NewUserComboBox.Text.Length > 0;
		}

		private void TXITEM_NewUserComboBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Return && this.TXITEM_NewUserComboBox.Text.Length > 0)
			{
				this.method_0();
			}
		}

		private void TXITEM_NewUserComboBox_Leave(object sender, EventArgs e)
		{
			base.AcceptButton = this.TXITEM_OK;
		}

		private void TXITEM_OK_Click(object sender, EventArgs e)
		{
			bool flag = false;
			foreach (IFormattedText textPart in this.textControl_0.TextParts)
			{
				foreach (EditableRegion editableRegion3 in textPart.EditableRegions)
				{
					foreach (Class486 item in this.list_0)
					{
						if (item.String_0 == editableRegion3.UserName)
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					break;
				}
			}
			if (flag)
			{
				if (MessageBox.Show(this, this.resourceManager_0.GetString("ID_ADDUSERSDIALOG_DELETE_MSG1_TEXT"), this.resourceManager_0.GetString("ID_ADDUSERSDIALOG_DELETE_MSG1_TITLE"), MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
				{
					return;
				}
				foreach (IFormattedText textPart2 in this.textControl_0.TextParts)
				{
					for (int num = textPart2.EditableRegions.Count; num > 0; num--)
					{
						EditableRegion editableRegion2 = textPart2.EditableRegions[num];
						foreach (Class486 item2 in this.list_0)
						{
							if (item2.String_0 == editableRegion2.UserName)
							{
								textPart2.EditableRegions.Remove(editableRegion2, selectedPart: false);
								break;
							}
						}
					}
				}
			}
			this.ribbonListViewItem_0 = new RibbonListView.RibbonListViewItem[this.list_1.Count + 1];
			this.ribbonListViewItem_0[0] = this.class479_0.RibbonListViewItem_0;
			for (int i = 0; i < this.list_1.Count; i++)
			{
				Class486 @class = this.list_1[i];
				RibbonListView.RibbonListViewItem ribbonListViewItem = this.class479_0.method_24(@class.String_0, @class);
				ribbonListViewItem.IsSelected = @class.EditableRegion_0 != null;
				ribbonListViewItem.Tag = @class;
				this.ribbonListViewItem_0[i + 1] = ribbonListViewItem;
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			this.uint_0 = Class468.smethod_0(null, this);
			Class429.Struct83 struct83_ = default(Class429.Struct83);
			Class429.GetWindowRect(base.Handle, ref struct83_);
			Class468.smethod_1(this.uint_0, struct83_, this);
			base.OnHandleCreated(eventArgs_0);
		}

		protected override void WndProc(ref Message message)
		{
			int msg = message.Msg;
			if (msg == 736)
			{
				uint num = Class429.smethod_5(message.WParam.ToInt32());
				if (num != this.uint_0)
				{
					Class429.Struct83 struct83_ = (Class429.Struct83)Marshal.PtrToStructure(message.LParam, typeof(Class429.Struct83));
					this.Font = new Font(this.Font.Name, this.Font.Size * (float)num / (float)this.uint_0, this.Font.Style, this.Font.Unit);
					this.uint_0 = num;
					Class468.smethod_1(this.uint_0, struct83_, this);
				}
			}
			else
			{
				base.WndProc(ref message);
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.TXITEM_MainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.TXITEM_UsersLabel = new System.Windows.Forms.Label();
			this.TXITEM_UsersListBox = new System.Windows.Forms.ListBox();
			this.TXITEM_AddButton = new System.Windows.Forms.Button();
			this.TXITEM_BottomPanel = new System.Windows.Forms.TableLayoutPanel();
			this.TXITEM_DeleteUserButton = new System.Windows.Forms.Button();
			this.TXITEM_OK = new System.Windows.Forms.Button();
			this.TXITEM_Cancel = new System.Windows.Forms.Button();
			this.TXITEM_NewUserLabel = new System.Windows.Forms.Label();
			this.TXITEM_NewUserComboBox = new System.Windows.Forms.ComboBox();
			this.TXITEM_MainPanel.SuspendLayout();
			this.TXITEM_BottomPanel.SuspendLayout();
			base.SuspendLayout();
			this.TXITEM_MainPanel.AutoSize = true;
			this.TXITEM_MainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TXITEM_MainPanel.ColumnCount = 2;
			this.TXITEM_MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.TXITEM_MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_UsersLabel, 0, 2);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_UsersListBox, 0, 3);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_AddButton, 1, 1);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_BottomPanel, 0, 4);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_NewUserLabel, 0, 0);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_NewUserComboBox, 0, 1);
			this.TXITEM_MainPanel.Dock = System.Windows.Forms.DockStyle.Right;
			this.TXITEM_MainPanel.Location = new System.Drawing.Point(-43, 7);
			this.TXITEM_MainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.TXITEM_MainPanel.Name = "TXITEM_MainPanel";
			this.TXITEM_MainPanel.RowCount = 5;
			this.TXITEM_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.TXITEM_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_MainPanel.Size = new System.Drawing.Size(304, 238);
			this.TXITEM_MainPanel.TabIndex = 0;
			this.TXITEM_UsersLabel.AutoSize = true;
			this.TXITEM_MainPanel.SetColumnSpan(this.TXITEM_UsersLabel, 2);
			this.TXITEM_UsersLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_UsersLabel.Location = new System.Drawing.Point(0, 45);
			this.TXITEM_UsersLabel.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.TXITEM_UsersLabel.Name = "TXITEM_UsersLabel";
			this.TXITEM_UsersLabel.Size = new System.Drawing.Size(304, 13);
			this.TXITEM_UsersLabel.TabIndex = 3;
			this.TXITEM_UsersLabel.Text = "Users:";
			this.TXITEM_MainPanel.SetColumnSpan(this.TXITEM_UsersListBox, 2);
			this.TXITEM_UsersListBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TXITEM_UsersListBox.FormattingEnabled = true;
			this.TXITEM_UsersListBox.Location = new System.Drawing.Point(0, 61);
			this.TXITEM_UsersListBox.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.TXITEM_UsersListBox.Name = "TXITEM_UsersListBox";
			this.TXITEM_UsersListBox.Size = new System.Drawing.Size(304, 148);
			this.TXITEM_UsersListBox.TabIndex = 4;
			this.TXITEM_AddButton.AutoSize = true;
			this.TXITEM_AddButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TXITEM_AddButton.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_AddButton.Enabled = false;
			this.TXITEM_AddButton.Location = new System.Drawing.Point(229, 16);
			this.TXITEM_AddButton.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
			this.TXITEM_AddButton.MinimumSize = new System.Drawing.Size(75, 23);
			this.TXITEM_AddButton.Name = "TXITEM_AddButton";
			this.TXITEM_AddButton.Size = new System.Drawing.Size(75, 23);
			this.TXITEM_AddButton.TabIndex = 2;
			this.TXITEM_AddButton.Text = "Add";
			this.TXITEM_AddButton.UseVisualStyleBackColor = true;
			this.TXITEM_AddButton.Click += new System.EventHandler(TXITEM_AddButton_Click);
			this.TXITEM_BottomPanel.AutoSize = true;
			this.TXITEM_BottomPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TXITEM_BottomPanel.ColumnCount = 4;
			this.TXITEM_MainPanel.SetColumnSpan(this.TXITEM_BottomPanel, 2);
			this.TXITEM_BottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TXITEM_BottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.TXITEM_BottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TXITEM_BottomPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TXITEM_BottomPanel.Controls.Add(this.TXITEM_DeleteUserButton, 0, 0);
			this.TXITEM_BottomPanel.Controls.Add(this.TXITEM_OK, 2, 0);
			this.TXITEM_BottomPanel.Controls.Add(this.TXITEM_Cancel, 3, 0);
			this.TXITEM_BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.TXITEM_BottomPanel.Location = new System.Drawing.Point(0, 212);
			this.TXITEM_BottomPanel.Margin = new System.Windows.Forms.Padding(0);
			this.TXITEM_BottomPanel.Name = "TXITEM_BottomPanel";
			this.TXITEM_BottomPanel.RowCount = 1;
			this.TXITEM_BottomPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_BottomPanel.Size = new System.Drawing.Size(304, 26);
			this.TXITEM_BottomPanel.TabIndex = 5;
			this.TXITEM_DeleteUserButton.AutoSize = true;
			this.TXITEM_DeleteUserButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TXITEM_DeleteUserButton.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_DeleteUserButton.Enabled = false;
			this.TXITEM_DeleteUserButton.Location = new System.Drawing.Point(0, 3);
			this.TXITEM_DeleteUserButton.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
			this.TXITEM_DeleteUserButton.MinimumSize = new System.Drawing.Size(75, 23);
			this.TXITEM_DeleteUserButton.Name = "TXITEM_DeleteUserButton";
			this.TXITEM_DeleteUserButton.Size = new System.Drawing.Size(75, 23);
			this.TXITEM_DeleteUserButton.TabIndex = 1;
			this.TXITEM_DeleteUserButton.Text = "Delete";
			this.TXITEM_DeleteUserButton.UseVisualStyleBackColor = true;
			this.TXITEM_DeleteUserButton.Click += new System.EventHandler(TXITEM_DeleteUserButton_Click);
			this.TXITEM_OK.AutoSize = true;
			this.TXITEM_OK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TXITEM_OK.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_OK.Location = new System.Drawing.Point(148, 3);
			this.TXITEM_OK.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.TXITEM_OK.MinimumSize = new System.Drawing.Size(75, 23);
			this.TXITEM_OK.Name = "TXITEM_OK";
			this.TXITEM_OK.Size = new System.Drawing.Size(75, 23);
			this.TXITEM_OK.TabIndex = 0;
			this.TXITEM_OK.Text = "OK";
			this.TXITEM_OK.UseVisualStyleBackColor = true;
			this.TXITEM_OK.Click += new System.EventHandler(TXITEM_OK_Click);
			this.TXITEM_Cancel.AutoSize = true;
			this.TXITEM_Cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TXITEM_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.TXITEM_Cancel.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_Cancel.Location = new System.Drawing.Point(229, 3);
			this.TXITEM_Cancel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
			this.TXITEM_Cancel.MinimumSize = new System.Drawing.Size(75, 23);
			this.TXITEM_Cancel.Name = "TXITEM_Cancel";
			this.TXITEM_Cancel.Size = new System.Drawing.Size(75, 23);
			this.TXITEM_Cancel.TabIndex = 2;
			this.TXITEM_Cancel.Text = "Cancel";
			this.TXITEM_Cancel.UseVisualStyleBackColor = true;
			this.TXITEM_NewUserLabel.AutoSize = true;
			this.TXITEM_MainPanel.SetColumnSpan(this.TXITEM_NewUserLabel, 2);
			this.TXITEM_NewUserLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_NewUserLabel.Location = new System.Drawing.Point(0, 0);
			this.TXITEM_NewUserLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.TXITEM_NewUserLabel.Name = "TXITEM_NewUserLabel";
			this.TXITEM_NewUserLabel.Size = new System.Drawing.Size(304, 13);
			this.TXITEM_NewUserLabel.TabIndex = 0;
			this.TXITEM_NewUserLabel.Text = "New User:";
			this.TXITEM_NewUserComboBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_NewUserComboBox.FormattingEnabled = true;
			this.TXITEM_NewUserComboBox.Location = new System.Drawing.Point(0, 16);
			this.TXITEM_NewUserComboBox.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
			this.TXITEM_NewUserComboBox.Name = "TXITEM_NewUserComboBox";
			this.TXITEM_NewUserComboBox.Size = new System.Drawing.Size(223, 21);
			this.TXITEM_NewUserComboBox.TabIndex = 6;
			this.TXITEM_NewUserComboBox.TextChanged += new System.EventHandler(TXITEM_NewUserComboBox_TextChanged);
			this.TXITEM_NewUserComboBox.Enter += new System.EventHandler(TXITEM_NewUserComboBox_Enter);
			this.TXITEM_NewUserComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(TXITEM_NewUserComboBox_KeyDown);
			this.TXITEM_NewUserComboBox.Leave += new System.EventHandler(TXITEM_NewUserComboBox_Leave);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.TXITEM_Cancel;
			base.ClientSize = new System.Drawing.Size(268, 252);
			base.Controls.Add(this.TXITEM_MainPanel);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "AddUsersDialog";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Add Users";
			base.Shown += new System.EventHandler(AddUsersDialog_Shown);
			this.TXITEM_MainPanel.ResumeLayout(false);
			this.TXITEM_MainPanel.PerformLayout();
			this.TXITEM_BottomPanel.ResumeLayout(false);
			this.TXITEM_BottomPanel.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
