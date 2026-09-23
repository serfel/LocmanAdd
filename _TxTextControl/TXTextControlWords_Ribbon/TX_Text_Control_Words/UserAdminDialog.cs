using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TX_Text_Control_Words.Properties;
using TX_Text_Control_Words.Utils;

namespace TX_Text_Control_Words
{
	public class UserAdminDialog : Form
	{
		private BindingList<UserInfo> m_users;

		private IContainer components;

		private TableLayoutPanel tableLayoutPanel1;

		private ListBox m_lbUsers;

		private Label m_lblUsers;

		private TableLayoutPanel tableLayoutPanel2;

		private Button m_btnNew;

		private Button m_btnEdit;

		private Button m_btnDelete;

		private TableLayoutPanel tableLayoutPanel3;

		private Button m_btnCancel;

		private Button m_btnOK;

		public List<UserInfo> Users => new List<UserInfo>(this.m_users);

		public UserAdminDialog(List<UserInfo> users)
		{
			this.InitializeComponent();
			this.LocalizeDialog();
			this.m_users = new BindingList<UserInfo>((from ui in users.ConvertAll((UserInfo ui) => new UserInfo(ui))
				orderby ui.Name
				select ui).ToList());
			this.m_lbUsers.DataSource = this.m_users;
		}

		private void LbUsers_SelectedValueChanged(object sender, EventArgs e)
		{
			this.m_btnEdit.Enabled = this.m_lbUsers.SelectedValue != null;
			this.m_btnDelete.Enabled = this.m_lbUsers.SelectedValue != null;
		}

		private void BtnEdit_Click(object sender, EventArgs e)
		{
			UserInfo userInfo = this.m_lbUsers.SelectedValue as UserInfo;
			if (userInfo == null)
			{
				return;
			}
			EditUserDialog dlg = new EditUserDialog(userInfo)
			{
				RequestCurrentPassword = true,
				AllowEmptyPassword = true,
				RightToLeft = this.RightToLeft
			};
			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				if (!dlg.Username.Equals(userInfo.Name, StringComparison.OrdinalIgnoreCase) && this.m_users.Any((UserInfo ui) => ui.Name.Equals(dlg.Username, StringComparison.OrdinalIgnoreCase)))
				{
					TX_Text_Control_Words.Utils.MessageBox.Show(this, Resources.EDIT_USER_DLG_USER_EXISTS, base.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				userInfo.Name = dlg.Username;
				userInfo.Password = dlg.NewPassword;
			}
		}

		private void BtnDelete_Click(object sender, EventArgs e)
		{
			UserInfo userInfo = this.m_lbUsers.SelectedValue as UserInfo;
			if (userInfo != null)
			{
				this.m_users.Remove(userInfo);
			}
		}

		private void BtnNew_Click(object sender, EventArgs e)
		{
			EditUserDialog dlg = new EditUserDialog
			{
				RightToLeft = this.RightToLeft,
				Owner = this
			};
			if (dlg.ShowDialog(this) == DialogResult.OK)
			{
				if (this.m_users.Any((UserInfo ui) => ui.Name.Equals(dlg.Username, StringComparison.OrdinalIgnoreCase)))
				{
					TX_Text_Control_Words.Utils.MessageBox.Show(this, Resources.EDIT_USER_DLG_USER_EXISTS, base.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					this.m_users.Add(new UserInfo(dlg.Username, dlg.NewPassword));
				}
			}
		}

		private void BtnOK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		private void LocalizeDialog()
		{
			this.Text = Resources.USER_ADMIN_DLG_TITLE;
			this.m_btnOK.Text = Resources.BTN_OK;
			this.m_btnCancel.Text = Resources.BTN_CANCEL;
			this.m_btnDelete.Text = Resources.USER_ADMIN_DLG_BTN_DELETE;
			this.m_btnNew.Text = Resources.USER_ADMIN_DLG_BTN_NEW;
			this.m_btnEdit.Text = Resources.USER_ADMIN_DLG_BTN_EDIT;
			this.m_lblUsers.Text = Resources.USER_ADMIN_DLG_LBL_USERS;
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.m_lbUsers = new System.Windows.Forms.ListBox();
			this.m_lblUsers = new System.Windows.Forms.Label();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.m_btnNew = new System.Windows.Forms.Button();
			this.m_btnEdit = new System.Windows.Forms.Button();
			this.m_btnDelete = new System.Windows.Forms.Button();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			base.SuspendLayout();
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.m_lbUsers, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.m_lblUsers, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 2);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 7);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(309, 292);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(354, 292);
			this.tableLayoutPanel1.TabIndex = 0;
			this.tableLayoutPanel1.SetColumnSpan(this.m_lbUsers, 2);
			this.m_lbUsers.DisplayMember = "Name";
			this.m_lbUsers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lbUsers.FormattingEnabled = true;
			this.m_lbUsers.IntegralHeight = false;
			this.m_lbUsers.ItemHeight = 15;
			this.m_lbUsers.Location = new System.Drawing.Point(0, 21);
			this.m_lbUsers.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
			this.m_lbUsers.Name = "m_lbUsers";
			this.m_lbUsers.Size = new System.Drawing.Size(269, 240);
			this.m_lbUsers.TabIndex = 1;
			this.m_lbUsers.SelectedValueChanged += new System.EventHandler(LbUsers_SelectedValueChanged);
			this.m_lblUsers.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.m_lblUsers, 3);
			this.m_lblUsers.Location = new System.Drawing.Point(0, 0);
			this.m_lblUsers.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
			this.m_lblUsers.Name = "m_lblUsers";
			this.m_lblUsers.Size = new System.Drawing.Size(38, 15);
			this.m_lblUsers.TabIndex = 0;
			this.m_lblUsers.Text = "Users:";
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.m_btnNew, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.m_btnEdit, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.m_btnDelete, 0, 2);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(274, 20);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 3;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.Size = new System.Drawing.Size(78, 93);
			this.tableLayoutPanel2.TabIndex = 2;
			this.m_btnNew.AutoSize = true;
			this.m_btnNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnNew.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnNew.Location = new System.Drawing.Point(3, 3);
			this.m_btnNew.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.m_btnNew.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnNew.Name = "m_btnNew";
			this.m_btnNew.Size = new System.Drawing.Size(75, 25);
			this.m_btnNew.TabIndex = 2;
			this.m_btnNew.Text = "New…";
			this.m_btnNew.UseVisualStyleBackColor = true;
			this.m_btnNew.Click += new System.EventHandler(BtnNew_Click);
			this.m_btnEdit.AutoSize = true;
			this.m_btnEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnEdit.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnEdit.Enabled = false;
			this.m_btnEdit.Location = new System.Drawing.Point(3, 34);
			this.m_btnEdit.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.m_btnEdit.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnEdit.Name = "m_btnEdit";
			this.m_btnEdit.Size = new System.Drawing.Size(75, 25);
			this.m_btnEdit.TabIndex = 3;
			this.m_btnEdit.Text = "Edit…";
			this.m_btnEdit.UseVisualStyleBackColor = true;
			this.m_btnEdit.Click += new System.EventHandler(BtnEdit_Click);
			this.m_btnDelete.AutoSize = true;
			this.m_btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnDelete.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnDelete.Enabled = false;
			this.m_btnDelete.Location = new System.Drawing.Point(3, 65);
			this.m_btnDelete.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.m_btnDelete.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnDelete.Name = "m_btnDelete";
			this.m_btnDelete.Size = new System.Drawing.Size(75, 25);
			this.m_btnDelete.TabIndex = 4;
			this.m_btnDelete.Text = "Delete";
			this.m_btnDelete.UseVisualStyleBackColor = true;
			this.m_btnDelete.Click += new System.EventHandler(BtnDelete_Click);
			this.tableLayoutPanel3.AutoSize = true;
			this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 2);
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.Controls.Add(this.m_btnCancel, 1, 0);
			this.tableLayoutPanel3.Controls.Add(this.m_btnOK, 0, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(195, 264);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(159, 28);
			this.tableLayoutPanel3.TabIndex = 3;
			this.m_btnCancel.AutoSize = true;
			this.m_btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnCancel.Location = new System.Drawing.Point(84, 3);
			this.m_btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
			this.m_btnCancel.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(75, 25);
			this.m_btnCancel.TabIndex = 6;
			this.m_btnCancel.Text = "Cancel";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			this.m_btnOK.AutoSize = true;
			this.m_btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnOK.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnOK.Location = new System.Drawing.Point(3, 3);
			this.m_btnOK.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.m_btnOK.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(75, 25);
			this.m_btnOK.TabIndex = 5;
			this.m_btnOK.Text = "OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(BtnOK_Click);
			base.AcceptButton = this.m_btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			base.CancelButton = this.m_btnCancel;
			base.ClientSize = new System.Drawing.Size(368, 305);
			base.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Margin = new System.Windows.Forms.Padding(2);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "UserAdminDialog";
			base.Padding = new System.Windows.Forms.Padding(7);
			this.RightToLeftLayout = true;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "UserAdminDialog";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
