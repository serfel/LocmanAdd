using System;
using System.Linq;
using System.Windows.Forms;
using TXTextControl;

namespace TX_Text_Control_Words
{
	public class UserAccessControl
	{
		private TextControl m_textControl;

		public ExtendedObservableCollection<UserInfo> KnownUsers { get; private set; }

		public TextControl ConnectedTextControl => this.m_textControl;

		public UserAccessControl(TextControl textControl)
		{
			this.KnownUsers = new ExtendedObservableCollection<UserInfo>();
			this.m_textControl = textControl;
			this.KnownUsers.CollectionChanged += UserAccessControl_KnownUsersChanged;
		}

		public UserAccessControl(ref TextControl textControl)
		{
			this.KnownUsers = new ExtendedObservableCollection<UserInfo>();
			this.m_textControl = textControl;
			this.KnownUsers.CollectionChanged += UserAccessControl_KnownUsersChanged;
		}

		private void UserAccessControl_KnownUsersChanged(object sender, EventArgs e)
		{
			this.m_textControl.UserNames = (from userInfo in this.KnownUsers
				where userInfo.AccessGranted
				select userInfo.Name).ToArray();
		}

		public DialogResult ShowUserAccessDialog(Form owner = null)
		{
			UserAccessDialog userAccessDialog = new UserAccessDialog(this.KnownUsers.ToList())
			{
				RightToLeft = this.m_textControl.RightToLeft
			};
			if (owner != null)
			{
				userAccessDialog.Owner = owner;
				userAccessDialog.StartPosition = FormStartPosition.CenterParent;
			}
			DialogResult dialogResult = userAccessDialog.ShowDialog(owner);
			if (dialogResult == DialogResult.OK)
			{
				this.KnownUsers.Set(userAccessDialog.Users);
				UserAccessControl.SetCurrentAuthor(userAccessDialog.CurrentAuthor, this.KnownUsers);
			}
			return dialogResult;
		}

		public DialogResult ShowUserAdminDialog(Form owner = null)
		{
			UserAdminDialog userAdminDialog = new UserAdminDialog(this.KnownUsers.ToList())
			{
				Owner = owner,
				RightToLeft = this.m_textControl.RightToLeft
			};
			DialogResult dialogResult = userAdminDialog.ShowDialog(owner);
			if (dialogResult == DialogResult.OK)
			{
				this.KnownUsers.Set(userAdminDialog.Users);
			}
			return dialogResult;
		}

		private static bool SetCurrentAuthor(UserInfo author, ExtendedObservableCollection<UserInfo> users)
		{
			int num = users.IndexOf(author);
			if (num >= 0)
			{
				users.Move(users.IndexOf(author), 0);
				return true;
			}
			return false;
		}
	}
}
