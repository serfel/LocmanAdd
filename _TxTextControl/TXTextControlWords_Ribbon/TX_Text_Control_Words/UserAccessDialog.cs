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
	public class UserAccessDialog : Form, INotifyPropertyChanged
	{
		private BindingList<UserInfo> m_users;

		private UserInfo m_CurrentAuthor;

		private IContainer components;

		private TableLayoutPanel tableLayoutPanel1;

		private UserInfoListBox m_lbUsers;

		private Label m_lblRegUsers;

		private TableLayoutPanel tableLayoutPanel2;

		private Button m_btnGrantAccess;

		private Button m_btnRevokeAccess;

		private TableLayoutPanel tableLayoutPanel3;

		private Button m_btnCancel;

		private Button m_btnOK;

		private Button m_btnManage;

		private Button m_btnCurrentAuthor;

		public List<UserInfo> Users => new List<UserInfo>(this.m_users);

		public UserInfo CurrentAuthor
		{
			get
			{
				return this.m_CurrentAuthor;
			}
			private set
			{
				if (value == null)
				{
					value = this.NextAuthor();
				}
				if (value == null || (value != null && value.AccessGranted))
				{
					this.m_CurrentAuthor = value;
					this.OnPropertyChanged("CurrentAuthor");
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string propertyName = "")
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		public UserAccessDialog(List<UserInfo> users)
		{
			this.InitializeComponent();
			this.LocalizeDialog();
			this.PropertyChanged += delegate(object sender, PropertyChangedEventArgs eventargs)
			{
				if (eventargs.PropertyName == "CurrentAuthor")
				{
					this.EnableAuthorButton();
				}
			};
			this.PropertyChanged += delegate(object sender, PropertyChangedEventArgs eventargs)
			{
				if (eventargs.PropertyName == "CurrentAuthor")
				{
					this.m_lbUsers.Author = this.CurrentAuthor;
				}
			};
			this.m_users = new BindingList<UserInfo>((from ui in users.ConvertAll((UserInfo ui) => new UserInfo(ui))
				orderby ui.Name
				select ui).ToList());
			this.m_lbUsers.DataSource = this.m_users;
			try
			{
				this.CurrentAuthor = users.First((UserInfo user) => user.AccessGranted);
			}
			catch
			{
				this.CurrentAuthor = null;
			}
			this.StyleButtons();
		}

		private void BtnGrantAccess_Click(object sender, EventArgs e)
		{
			UserInfo userInfo = this.m_lbUsers.SelectedValue as UserInfo;
			if (userInfo != null)
			{
				UserPromptDialog userPromptDialog = new UserPromptDialog(Resources.USER_ACC_DLG_ENTER_PASSWORD, Resources.USER_ACC_DLG_ENTER_PASSWORD_LABEL, "")
				{
					IsPassword = true,
					RightToLeft = this.RightToLeft
				};
				if (userPromptDialog.ShowDialog(this) == DialogResult.OK)
				{
					if (userInfo.ValidatePassword(userPromptDialog.Value))
					{
						userInfo.AccessGranted = true;
						this.EnableAccessButtons(accessGranted: true);
						this.CurrentAuthor = ((this.CurrentAuthor == null) ? userInfo : this.CurrentAuthor);
					}
					else
					{
						TX_Text_Control_Words.Utils.MessageBox.Show(this, Resources.USER_ACC_DLG_WRONG_PASSWORD, base.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
			}
			this.m_lbUsers.Invalidate();
		}

		private void BtnRevokeAccess_Click(object sender, EventArgs e)
		{
			UserInfo userInfo = this.m_lbUsers.SelectedValue as UserInfo;
			if (userInfo != null)
			{
				userInfo.AccessGranted = false;
				this.EnableAccessButtons(accessGranted: false);
				if (userInfo == this.CurrentAuthor)
				{
					this.CurrentAuthor = null;
				}
			}
			this.m_lbUsers.Invalidate();
		}

		private void BtnManage_Click(object sender, EventArgs e)
		{
			UserAdminDialog userAdminDialog = new UserAdminDialog(new List<UserInfo>(this.m_users))
			{
				RightToLeft = this.RightToLeft
			};
			if (userAdminDialog.ShowDialog(this) == DialogResult.OK)
			{
				this.m_users = new BindingList<UserInfo>(userAdminDialog.Users.OrderBy((UserInfo ui) => ui.Name).ToList());
				this.m_lbUsers.DataSource = this.m_users;
			}
		}

		private void BtnOK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		private void BtnCurrentAuthor_Click(object sender, EventArgs e)
		{
			UserInfo userInfo = (UserInfo)this.m_lbUsers.SelectedItem;
			if (userInfo.AccessGranted)
			{
				this.CurrentAuthor = userInfo;
			}
		}

		private void LbUsers_SelectedValueChanged(object sender, EventArgs e)
		{
			UserInfo userInfo = this.m_lbUsers.SelectedValue as UserInfo;
			if (userInfo != null)
			{
				this.EnableAccessButtons(userInfo.AccessGranted);
				this.EnableAuthorButton();
			}
		}

		private void EnableAccessButtons(bool accessGranted)
		{
			this.m_btnGrantAccess.Enabled = !accessGranted;
			this.m_btnRevokeAccess.Enabled = accessGranted;
		}

		private void EnableAuthorButton()
		{
			UserInfo userInfo = this.m_lbUsers.SelectedItem as UserInfo;
			if (userInfo != null && userInfo.AccessGranted && (this.CurrentAuthor == null || (this.CurrentAuthor != null && this.CurrentAuthor != userInfo)))
			{
				this.m_btnCurrentAuthor.Enabled = true;
			}
			else
			{
				this.m_btnCurrentAuthor.Enabled = false;
			}
		}

		private UserInfo NextAuthor()
		{
			foreach (UserInfo user in this.m_users)
			{
				if (user.AccessGranted && (this.CurrentAuthor == null || (this.CurrentAuthor != null && this.CurrentAuthor != user)))
				{
					return user;
				}
			}
			return null;
		}

		private void StyleButtons()
		{
			string fontname = "Wingdings";
			char c = Convert.ToChar(171);
			this.SetCharAsImageToButton(c, fontname, Color.Blue, this.m_btnCurrentAuthor);
			char c2 = Convert.ToChar(252);
			this.SetCharAsImageToButton(c2, fontname, Color.Green, this.m_btnGrantAccess);
			char c3 = Convert.ToChar(251);
			this.SetCharAsImageToButton(c3, fontname, Color.Red, this.m_btnRevokeAccess);
		}

		private void SetCharAsImageToButton(char c, string fontname, Color forecolor, Button button)
		{
			Bitmap bitmap = (Bitmap)(button.Image = this.ConvertTextToImage(c.ToString(), fontname, Convert.ToInt16(this.m_btnCurrentAuthor.Font.Size + 5f), Color.Transparent, forecolor, 25, 20));
			button.TextImageRelation = TextImageRelation.ImageBeforeText;
			button.ImageAlign = ContentAlignment.MiddleLeft;
		}

		private Bitmap ConvertTextToImage(string txt, string fontname, int fontsize, Color bgcolor, Color fcolor, int width, int Height)
		{
			float dpiX;
			using (Graphics graphics = base.CreateGraphics())
			{
				dpiX = graphics.DpiX;
			}
			int num = 96;
			double num2 = dpiX / (float)num;
			double num3 = num2 * (double)width;
			double num4 = num2 * (double)Height;
			Bitmap bitmap = new Bitmap((int)num3, (int)num4);
			using Graphics graphics2 = Graphics.FromImage(bitmap);
			Font font = new Font(fontname, fontsize);
			graphics2.FillRectangle(new SolidBrush(bgcolor), 0, 0, bitmap.Width, bitmap.Height);
			graphics2.DrawString(txt, font, new SolidBrush(fcolor), 0f, 0f);
			graphics2.Flush();
			font.Dispose();
			return bitmap;
		}

		private void LocalizeDialog()
		{
			this.Text = Resources.USER_ACC_DLG_TITLE;
			this.m_btnOK.Text = Resources.BTN_OK;
			this.m_btnCancel.Text = Resources.BTN_CANCEL;
			this.m_btnManage.Text = Resources.USER_ACC_DLG_BTN_MANAGE;
			this.m_btnGrantAccess.Text = Resources.USER_ACC_DLG_BTN_GRANT;
			this.m_btnRevokeAccess.Text = Resources.USER_ACC_DLG_BTN_REVOKE;
			this.m_btnCurrentAuthor.Text = Resources.USER_ACC_DLG_BTN_CURRENTAUTHOR;
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.m_lbUsers = new TX_Text_Control_Words.UserInfoListBox();
			this.m_lblRegUsers = new System.Windows.Forms.Label();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.m_btnManage = new System.Windows.Forms.Button();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.m_btnCurrentAuthor = new System.Windows.Forms.Button();
			this.m_btnGrantAccess = new System.Windows.Forms.Button();
			this.m_btnRevokeAccess = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			base.SuspendLayout();
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.m_lbUsers, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.m_lblRegUsers, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
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
			this.m_lbUsers.Author = null;
			this.m_lbUsers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lbUsers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.m_lbUsers.FormattingEnabled = true;
			this.m_lbUsers.IntegralHeight = false;
			this.m_lbUsers.ItemHeight = 16;
			this.m_lbUsers.Location = new System.Drawing.Point(0, 21);
			this.m_lbUsers.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
			this.m_lbUsers.Name = "m_lbUsers";
			this.m_lbUsers.Size = new System.Drawing.Size(247, 240);
			this.m_lbUsers.TabIndex = 1;
			this.m_lbUsers.SelectedValueChanged += new System.EventHandler(LbUsers_SelectedValueChanged);
			this.m_lblRegUsers.AutoSize = true;
			this.m_lblRegUsers.Location = new System.Drawing.Point(0, 0);
			this.m_lblRegUsers.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
			this.m_lblRegUsers.Name = "m_lblRegUsers";
			this.m_lblRegUsers.Size = new System.Drawing.Size(38, 15);
			this.m_lblRegUsers.TabIndex = 0;
			this.m_lblRegUsers.Text = "&Users:";
			this.tableLayoutPanel3.AutoSize = true;
			this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel3.ColumnCount = 4;
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 2);
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.Controls.Add(this.m_btnManage, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.m_btnCancel, 3, 0);
			this.tableLayoutPanel3.Controls.Add(this.m_btnOK, 2, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 264);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(354, 28);
			this.tableLayoutPanel3.TabIndex = 3;
			this.m_btnManage.AutoSize = true;
			this.m_btnManage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnManage.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnManage.Location = new System.Drawing.Point(0, 3);
			this.m_btnManage.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
			this.m_btnManage.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnManage.Name = "m_btnManage";
			this.m_btnManage.Size = new System.Drawing.Size(100, 25);
			this.m_btnManage.TabIndex = 4;
			this.m_btnManage.Text = "Manage Users...";
			this.m_btnManage.UseVisualStyleBackColor = true;
			this.m_btnManage.Click += new System.EventHandler(BtnManage_Click);
			this.m_btnCancel.AutoSize = true;
			this.m_btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnCancel.Location = new System.Drawing.Point(279, 3);
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
			this.m_btnOK.Location = new System.Drawing.Point(198, 3);
			this.m_btnOK.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.m_btnOK.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(75, 25);
			this.m_btnOK.TabIndex = 5;
			this.m_btnOK.Text = "OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(BtnOK_Click);
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.m_btnCurrentAuthor, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.m_btnGrantAccess, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.m_btnRevokeAccess, 0, 1);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(252, 20);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 3;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.Size = new System.Drawing.Size(100, 93);
			this.tableLayoutPanel2.TabIndex = 2;
			this.m_btnCurrentAuthor.AutoSize = true;
			this.m_btnCurrentAuthor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnCurrentAuthor.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnCurrentAuthor.Location = new System.Drawing.Point(3, 65);
			this.m_btnCurrentAuthor.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.m_btnCurrentAuthor.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnCurrentAuthor.Name = "m_btnCurrentAuthor";
			this.m_btnCurrentAuthor.Size = new System.Drawing.Size(97, 25);
			this.m_btnCurrentAuthor.TabIndex = 4;
			this.m_btnCurrentAuthor.Text = "Current Author";
			this.m_btnCurrentAuthor.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.m_btnCurrentAuthor.UseVisualStyleBackColor = true;
			this.m_btnCurrentAuthor.Click += new System.EventHandler(BtnCurrentAuthor_Click);
			this.m_btnGrantAccess.AutoSize = true;
			this.m_btnGrantAccess.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnGrantAccess.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnGrantAccess.Enabled = false;
			this.m_btnGrantAccess.Location = new System.Drawing.Point(3, 3);
			this.m_btnGrantAccess.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.m_btnGrantAccess.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnGrantAccess.Name = "m_btnGrantAccess";
			this.m_btnGrantAccess.Size = new System.Drawing.Size(97, 25);
			this.m_btnGrantAccess.TabIndex = 2;
			this.m_btnGrantAccess.Text = "Grant Access";
			this.m_btnGrantAccess.UseVisualStyleBackColor = true;
			this.m_btnGrantAccess.Click += new System.EventHandler(BtnGrantAccess_Click);
			this.m_btnRevokeAccess.AutoSize = true;
			this.m_btnRevokeAccess.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnRevokeAccess.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnRevokeAccess.Enabled = false;
			this.m_btnRevokeAccess.Location = new System.Drawing.Point(3, 34);
			this.m_btnRevokeAccess.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.m_btnRevokeAccess.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnRevokeAccess.Name = "m_btnRevokeAccess";
			this.m_btnRevokeAccess.Size = new System.Drawing.Size(97, 25);
			this.m_btnRevokeAccess.TabIndex = 3;
			this.m_btnRevokeAccess.Text = "Revoke Access";
			this.m_btnRevokeAccess.UseVisualStyleBackColor = true;
			this.m_btnRevokeAccess.Click += new System.EventHandler(BtnRevokeAccess_Click);
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
			base.Name = "UserAccessDialog";
			base.Padding = new System.Windows.Forms.Padding(7);
			this.RightToLeftLayout = true;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "UserAccessDialog";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
