using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TX_Text_Control_Words.Properties;
using TXTextControl;

namespace TX_Text_Control_Words.User_Access_Control
{
	public class AddEditableRegionDialog : Form
	{
		private UserAccessControl m_uac;

		private IContainer components;

		private ListBox m_lbUsers;

		private TableLayoutPanel tableLayoutPanel1;

		private Label m_lblRegUsers;

		private TableLayoutPanel tableLayoutPanel2;

		private System.Windows.Forms.Button m_btnOK;

		private System.Windows.Forms.Button m_btnCancel;

		private TableLayoutPanel tableLayoutPanel3;

		private System.Windows.Forms.Button m_btnManage;

		public AddEditableRegionDialog(UserAccessControl uac)
		{
			this.InitializeComponent();
			this.m_uac = uac;
			this.m_lbUsers.DisplayMember = "Name";
			ListBox.ObjectCollection items = this.m_lbUsers.Items;
			object[] items2 = this.m_uac.KnownUsers.ToArray();
			items.AddRange(items2);
			this.m_uac.KnownUsers.CollectionChanged += KnownUsers_CollectionChanged;
			this.LocalizeDialog();
		}

		private void KnownUsers_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			this.m_lbUsers.Items.Clear();
			ExtendedObservableCollection<UserInfo> source = (ExtendedObservableCollection<UserInfo>)sender;
			ListBox.ObjectCollection items = this.m_lbUsers.Items;
			object[] items2 = source.ToArray();
			items.AddRange(items2);
			this.m_btnOK.Enabled = false;
		}

		private void m_btnOK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			foreach (UserInfo selectedItem in this.m_lbUsers.SelectedItems)
			{
				this.m_uac.ConnectedTextControl.EditableRegions.Add(new EditableRegion(selectedItem.Name, 0));
			}
			base.Close();
		}

		private void m_btnManage_Click(object sender, EventArgs e)
		{
			this.m_uac.ShowUserAdminDialog();
		}

		private void m_lbUsers_SelectedValueChanged(object sender, EventArgs e)
		{
			this.m_btnOK.Enabled = this.m_lbUsers.SelectedItems.Count > 0;
		}

		private void m_btnCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Cancel;
			base.Close();
		}

		private void LocalizeDialog()
		{
			this.Text = Resources.USER_ADD_REGION_DLG_TITLE;
			this.m_btnOK.Text = Resources.BTN_OK;
			this.m_btnCancel.Text = Resources.BTN_CANCEL;
			this.m_btnManage.Text = Resources.USER_ACC_DLG_BTN_MANAGE;
			this.m_lblRegUsers.Text = Resources.USER_ACC_DLG_LBL_USERS;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.m_lbUsers = new System.Windows.Forms.ListBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.m_lblRegUsers = new System.Windows.Forms.Label();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.m_btnManage = new System.Windows.Forms.Button();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			base.SuspendLayout();
			this.m_lbUsers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lbUsers.FormattingEnabled = true;
			this.m_lbUsers.IntegralHeight = false;
			this.m_lbUsers.ItemHeight = 15;
			this.m_lbUsers.Location = new System.Drawing.Point(2, 22);
			this.m_lbUsers.Margin = new System.Windows.Forms.Padding(2);
			this.m_lbUsers.Name = "m_lbUsers";
			this.m_lbUsers.Size = new System.Drawing.Size(202, 189);
			this.m_lbUsers.TabIndex = 1;
			this.m_lbUsers.SelectedValueChanged += new System.EventHandler(m_lbUsers_SelectedValueChanged);
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.m_lbUsers, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.m_lblRegUsers, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 7);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(309, 150);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(309, 217);
			this.tableLayoutPanel1.TabIndex = 1;
			this.m_lblRegUsers.AutoSize = true;
			this.m_lblRegUsers.Location = new System.Drawing.Point(2, 0);
			this.m_lblRegUsers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 5);
			this.m_lblRegUsers.Name = "m_lblRegUsers";
			this.m_lblRegUsers.Size = new System.Drawing.Size(38, 15);
			this.m_lblRegUsers.TabIndex = 0;
			this.m_lblRegUsers.Text = "Users:";
			this.tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.m_btnManage, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.m_btnOK, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.m_btnCancel, 0, 1);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(206, 20);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 4;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(103, 193);
			this.tableLayoutPanel2.TabIndex = 2;
			this.m_btnManage.AutoSize = true;
			this.m_btnManage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnManage.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnManage.Location = new System.Drawing.Point(3, 65);
			this.m_btnManage.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.m_btnManage.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnManage.Name = "m_btnManage";
			this.m_btnManage.Size = new System.Drawing.Size(100, 25);
			this.m_btnManage.TabIndex = 4;
			this.m_btnManage.Text = "Manage Users...";
			this.m_btnManage.UseVisualStyleBackColor = true;
			this.m_btnManage.Click += new System.EventHandler(m_btnManage_Click);
			this.m_btnOK.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnOK.Enabled = false;
			this.m_btnOK.Location = new System.Drawing.Point(3, 3);
			this.m_btnOK.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.m_btnOK.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(100, 25);
			this.m_btnOK.TabIndex = 2;
			this.m_btnOK.Text = "OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(m_btnOK_Click);
			this.m_btnCancel.AutoSize = true;
			this.m_btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnCancel.Location = new System.Drawing.Point(3, 34);
			this.m_btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.m_btnCancel.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(100, 25);
			this.m_btnCancel.TabIndex = 3;
			this.m_btnCancel.Text = "Cancel";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			this.m_btnCancel.Click += new System.EventHandler(m_btnCancel_Click);
			this.tableLayoutPanel3.AutoSize = true;
			this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel3.ColumnCount = 4;
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 2);
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(2, 215);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(305, 1);
			this.tableLayoutPanel3.TabIndex = 3;
			base.AcceptButton = this.m_btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			base.CancelButton = this.m_btnCancel;
			base.ClientSize = new System.Drawing.Size(321, 231);
			base.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "AddEditableRegionDialog";
			base.Padding = new System.Windows.Forms.Padding(7);
			this.RightToLeftLayout = true;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add Editable Region";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
