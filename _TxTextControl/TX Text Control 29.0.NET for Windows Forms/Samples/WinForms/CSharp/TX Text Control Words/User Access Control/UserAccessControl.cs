/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Forms;
using TXTextControl;
using System.Collections.Specialized;
using System.Diagnostics;

namespace TX_Text_Control_Words {

	/*-------------------------------------------------------------------------------------------------------
	** Class UserAccessControl
	**-----------------------------------------------------------------------------------------------------*/
	public class UserAccessControl {


		/*-------------------------------------------------------------------------------------------------------
		** M E M B E R S
		**-----------------------------------------------------------------------------------------------------*/
		
		/* This UserAccessControl instance manages the users of this TextControl */
		private TextControl m_textControl;

		/*-------------------------------------------------------------------------------------------------------
		** P R O P E R T I E S
		**-----------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------
		** KnownUsers
		** Corresponding TextControl which is managed/connected to this user access control.
		**-----------------------------------------------------------------------------------------------------*/
		public ExtendedObservableCollection<UserInfo> KnownUsers {
			get;
			private set;
		}

		/*-------------------------------------------------------------------------------------------------------
		** ConnectedTextControl
		** Corresponding TextControl which is managed/connected to this user access control.
		**-----------------------------------------------------------------------------------------------------*/
		public TextControl ConnectedTextControl {
			get {
				return m_textControl;
			}
		}

		/*-------------------------------------------------------------------------------------------------------
		** C O N S T R U C T O R S
		**-----------------------------------------------------------------------------------------------------*/

		public UserAccessControl(TextControl textControl) {
			KnownUsers = new ExtendedObservableCollection<UserInfo>();
			m_textControl = textControl;

			KnownUsers.CollectionChanged += UserAccessControl_KnownUsersChanged;
		}

		public UserAccessControl(ref TextControl textControl) {
			KnownUsers = new ExtendedObservableCollection<UserInfo>();
			m_textControl = textControl;

			KnownUsers.CollectionChanged += UserAccessControl_KnownUsersChanged;
		}

		/*-------------------------------------------------------------------------------------------------------
		** E V E N T H A N D L E R
		**-----------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------
		** UserAccessControl_KnownUsersChanged method
		** Update TextControl's UserNames with the known users which has granted access permissions.
		**-----------------------------------------------------------------------------------------------------*/
		private void UserAccessControl_KnownUsersChanged(object sender, EventArgs e) {
			m_textControl.UserNames = (from userInfo in KnownUsers where userInfo.AccessGranted select userInfo.Name).ToArray();
		}

		/*-------------------------------------------------------------------------------------------------------
		** P U B L I C   M E T H O D S
		**-----------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------
		** ShowUserAccessDialog method
		** Shows a dialog for managing the user's access state.
		**-----------------------------------------------------------------------------------------------------*/
		public DialogResult ShowUserAccessDialog(Form owner = null) {
			UserAccessDialog dlg = new UserAccessDialog(KnownUsers.ToList()) { 
				RightToLeft = m_textControl.RightToLeft,
			};

			if (owner != null) {
				dlg.Owner = owner;
				dlg.StartPosition = FormStartPosition.CenterParent;
			}

			DialogResult result = dlg.ShowDialog(owner);
			if (result == DialogResult.OK) {
				KnownUsers.Set(dlg.Users);
				if (!SetCurrentAuthor(dlg.CurrentAuthor, KnownUsers))
					System.Diagnostics.Debug.WriteLine("Current Author not found.");
			}

			return result;
		}

		/*-------------------------------------------------------------------------------------------------------
		** ShowUserAdminDialog method
		** Shows a dialog for managing the users.
		**-----------------------------------------------------------------------------------------------------*/
		public DialogResult ShowUserAdminDialog(Form owner = null) {
			UserAdminDialog dlg = new UserAdminDialog(KnownUsers.ToList()) { 
				Owner = owner,
				RightToLeft = m_textControl.RightToLeft
			};

			DialogResult result = dlg.ShowDialog(owner);
			if (result == DialogResult.OK) {
				KnownUsers.Set(dlg.Users);
			}

			return result;
		}

		/*-------------------------------------------------------------------------------------------------------
		** SetCurrentAuthor method
		** Sets the current author which is the first one. The passed author will be moved to the first position
		** in the collection.
		**-----------------------------------------------------------------------------------------------------*/
		private static bool SetCurrentAuthor(UserInfo author, ExtendedObservableCollection<UserInfo> users) {
			int authorIndex = users.IndexOf(author);

			if (authorIndex >= 0) {
				users.Move(users.IndexOf(author), 0);
				return true;
			}

			return false;
		}
	}// class UserAccessControl

	/*-------------------------------------------------------------------------------------------------------
	** ExtendedObservableCollection<T>
	**-----------------------------------------------------------------------------------------------------*/
	public class ExtendedObservableCollection<T> : ObservableCollection<T> {

		public void Set(ICollection<T> newItems) {
			this.Items.Clear();
			foreach (var ui in newItems) this.Items.Add(ui);

			OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}
	}
}
