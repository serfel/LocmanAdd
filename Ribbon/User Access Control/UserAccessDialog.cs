/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace TX_Text_Control_Words {

	/*-------------------------------------------------------------------------------------------------------------
	** Class UserAccessDialog
	** Implements a dialog for managing the user's access permissions. The access can be granted and denied by 
	** selecting a user and clicking the corresponding button.
	** For granting the access for a user which has set an userpassword the password will be
	** requested.
	** The current author can be set by using the corresponding button. Setting a user as current author requires
	** the user has access permission. The current author is the first user in the collection 
	** of TextControl's Usernames.
	**-----------------------------------------------------------------------------------------------------------*/
	public partial class UserAccessDialog : Form, INotifyPropertyChanged {

		/*-------------------------------------------------------------------------------------------------------------
		** I N T E R F A C E  - Implementation INotifyPropertyChanged 
		**-----------------------------------------------------------------------------------------------------------*/

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged(string propertyName = "") {
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
				handler(this, new PropertyChangedEventArgs(propertyName));
		}
		
		/*-------------------------------------------------------------------------------------------------------------
		** M E M B E R S
		**-----------------------------------------------------------------------------------------------------------*/

		private BindingList<UserInfo> m_users; // Managed users
		private UserInfo m_CurrentAuthor;		// Current author
		
		/*-------------------------------------------------------------------------------------------------------------
		** P R O P E R T I E S
		**-----------------------------------------------------------------------------------------------------------*/

		public List<UserInfo> Users { get { return new List<UserInfo>(m_users); } }

		public UserInfo CurrentAuthor {
			get { return m_CurrentAuthor; }
			private set {
				if (value == null) {
					// Try to find the next author
					value = NextAuthor();
				}

				if (value == null || value != null && value.AccessGranted) {
					m_CurrentAuthor = value;
					OnPropertyChanged("CurrentAuthor");
				}
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** C O N S T R U C T O R
		**-----------------------------------------------------------------------------------------------------------*/

		public UserAccessDialog(List<UserInfo> users) {
			InitializeComponent();
			LocalizeDialog();

			// Enable/Disable the author button on change of the current author.
			PropertyChanged += (sender, eventargs) => { if (eventargs.PropertyName == "CurrentAuthor") EnableAuthorButton(); };
			// Update listbox's author with current author on change of the current author.
			PropertyChanged += (sender, eventargs) => { if (eventargs.PropertyName == "CurrentAuthor") m_lbUsers.Author = CurrentAuthor; };

			m_users = new BindingList<UserInfo>(users.ConvertAll(ui => new UserInfo(ui)).OrderBy(ui => ui.Name).ToList());	// Clone and sort list
			m_lbUsers.DataSource = m_users;

			// Set current author to the first one who has an access permission.
			try {
				CurrentAuthor = users.First((user) => user.AccessGranted);
			}
			catch {
				CurrentAuthor = null;
			}

			// Set the button's style
			StyleButtons();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** E V E N T H A N D L E R S
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** BtnGrantAccess_Click method
		** Requests the selected user's password for granting access. Sets the user as current author if none is set.
		**-----------------------------------------------------------------------------------------------------------*/
		private void BtnGrantAccess_Click(object sender, EventArgs e) {
			var userInfo = m_lbUsers.SelectedValue as UserInfo;
			if (userInfo != null) {
				// Request user password
				var dlgPwd = new UserPromptDialog(Лоцман_добавка.Properties.Resources.USER_ACC_DLG_ENTER_PASSWORD, Лоцман_добавка.Properties.Resources.USER_ACC_DLG_ENTER_PASSWORD_LABEL, "")
				{
					IsPassword = true,
					RightToLeft = RightToLeft,
				};
				if (dlgPwd.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
					// Validate user password
					if (userInfo.ValidatePassword(dlgPwd.Value)) {
						// Grant Access
						userInfo.AccessGranted = true;
						EnableAccessButtons(true);

						// Set new user as author if none author known
						CurrentAuthor = CurrentAuthor == null ? userInfo : CurrentAuthor;

					}
					else Utils.MessageBox.Show(this, Лоцман_добавка.Properties.Resources.USER_ACC_DLG_WRONG_PASSWORD, "Боцман", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}

			m_lbUsers.Invalidate();	// Redraw list box content
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnRevokeAccess_Click method
		** Revoke the access of the selected user and current author to none if the user was current author.
		**-----------------------------------------------------------------------------------------------------------*/
		private void BtnRevokeAccess_Click(object sender, EventArgs e) {
			var userInfo = m_lbUsers.SelectedValue as UserInfo;
			if (userInfo != null) {
				userInfo.AccessGranted = false;
				EnableAccessButtons(false);

				if (userInfo == CurrentAuthor) {
					CurrentAuthor = null;
				}
			}

			m_lbUsers.Invalidate();	// Redraw list box content
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnManage_Click method
		** Show the dialog for managing the users.
		**-----------------------------------------------------------------------------------------------------------*/
		private void BtnManage_Click(object sender, EventArgs e) {
			var dlg = new UserAdminDialog(new List<UserInfo>(m_users)) { 
				RightToLeft = RightToLeft,
			};

			if (dlg.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
				m_users = new BindingList<UserInfo>(dlg.Users.OrderBy(ui => ui.Name).ToList());
				m_lbUsers.DataSource = m_users;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnOK_Click method
		** Close dialog and set DialogResult to OK.
		**-----------------------------------------------------------------------------------------------------------*/
		private void BtnOK_Click(object sender, EventArgs e) {
			DialogResult = System.Windows.Forms.DialogResult.OK;
			Close();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** BtnCurrentAuthor_Click method
		** Set the current selected user as author if user has access permissions.
		**-----------------------------------------------------------------------------------------------------------*/
		private void BtnCurrentAuthor_Click(object sender, EventArgs e) {
			UserInfo userInfo = (UserInfo)m_lbUsers.SelectedItem;
			if (userInfo.AccessGranted) {
				CurrentAuthor = userInfo;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** LbUsers_SelectedValueChanged method
		** Update the button's enabling for granting, revoking access and setting the current author on change of
		** the selected user within the listbox.
		**-----------------------------------------------------------------------------------------------------------*/
		private void LbUsers_SelectedValueChanged(object sender, EventArgs e) {
			var userInfo = m_lbUsers.SelectedValue as UserInfo;
			if (userInfo != null) {
				EnableAccessButtons(userInfo.AccessGranted);
				EnableAuthorButton();
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** H E L P E R   M E T H O D S
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** EnableAccessButtons method
		** Update enable state of the access button's for granting and revoking access. 
		**-----------------------------------------------------------------------------------------------------------*/
		private void EnableAccessButtons(bool accessGranted) {
			m_btnGrantAccess.Enabled = !accessGranted;
			m_btnRevokeAccess.Enabled = accessGranted;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** EnableAuthorButton method
		** Update enable state of the author button for setting the current author. The button is enabled if the 
		** selected user has access permissions and is not the current author.
		**-----------------------------------------------------------------------------------------------------------*/
		private void EnableAuthorButton() {
			UserInfo selectedUser = m_lbUsers.SelectedItem as UserInfo;
			bool isUserSelected = selectedUser != null;
			bool isAuthorized = isUserSelected && selectedUser.AccessGranted;

			if (isAuthorized) {
				//	Author not available
				// OR 
				// Not equal to current author 
				// -> so this user can be set as new one
				if (CurrentAuthor == null
					|| (CurrentAuthor != null && CurrentAuthor != selectedUser)) {
					m_btnCurrentAuthor.Enabled = true;
					return;
				}
			}
			m_btnCurrentAuthor.Enabled = false;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** NextAuthor method
		** Returns the first user who can be set as author. The user requires granted access and is not equal to
		** the current author.
		**-----------------------------------------------------------------------------------------------------------*/
		private UserInfo NextAuthor() {

			foreach (var user in m_users) {
				if (user.AccessGranted)
					if (CurrentAuthor == null || (CurrentAuthor != null && CurrentAuthor != user))
						return user;
			}

			return null;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** StyleButtons method
		** Customize the buttons for current author, granting access, revoking access by adding an image in front of
		** the text based on the WingDings Font.
		**-----------------------------------------------------------------------------------------------------------*/
		private void StyleButtons() {
			string fontWingDings = "Wingdings";
			// Set PentaStar image for button CurrentAuthor
			int iWindDingsPentaStar = 171;
			char strWingDingsPentaStar = Convert.ToChar(iWindDingsPentaStar);
			SetCharAsImageToButton(strWingDingsPentaStar, fontWingDings, Color.Blue, m_btnCurrentAuthor);

			// Set accept mark image for button AccessGranted
			int iWingDingsAccessGranted = 252;
			char strWingDingsAccessGranted = Convert.ToChar(iWingDingsAccessGranted);
			SetCharAsImageToButton(strWingDingsAccessGranted, fontWingDings, Color.Green, m_btnGrantAccess);

			// Set revoke mark image for AccessRevoked 
			int iWingDingsAccessRevoked = 251;
			char strWingDingsAccessRevoked = Convert.ToChar(iWingDingsAccessRevoked);
			SetCharAsImageToButton(strWingDingsAccessRevoked, fontWingDings, Color.Red, m_btnRevokeAccess);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** SetCharAsImageToButton method
		** Set the char with the font and forecolor as image in front of the button's text.
		**-----------------------------------------------------------------------------------------------------------*/
		private void SetCharAsImageToButton(char c, string fontname, Color forecolor, Button button) {
			Bitmap bitmap = ConvertTextToImage(c.ToString(), fontname, Convert.ToInt16(m_btnCurrentAuthor.Font.Size + 5), Color.Transparent, forecolor, 25, 20);
			button.Image = bitmap;
			// Set image left of text
			button.TextImageRelation = TextImageRelation.ImageBeforeText;
			button.ImageAlign = ContentAlignment.MiddleLeft;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** ConvertTextToImage method
		** Converts the passed text with the passed font settings to an image.
		**-----------------------------------------------------------------------------------------------------------*/
		private Bitmap ConvertTextToImage(string txt, string fontname, int fontsize, Color bgcolor, Color fcolor, int width, int Height) {
			// Get DPI of dialog.
			float dlgDPI;
			using (Graphics g = CreateGraphics()) {
				dlgDPI = g.DpiX;
			}
			// Get width and height dependly on the DPI.
			int defaultDesignerDPI = 96;
			double dpiFactor = dlgDPI / defaultDesignerDPI;
			double dpiWidth = dpiFactor * width;
			double dpiHeight = dpiFactor * Height;

			Bitmap bmp = new Bitmap((int)dpiWidth, (int)dpiHeight);
			using (Graphics graphics = Graphics.FromImage(bmp)) {

				Font font = new Font(fontname, fontsize);
				graphics.FillRectangle(new SolidBrush(bgcolor), 0, 0, bmp.Width, bmp.Height);
				graphics.DrawString(txt, font, new SolidBrush(fcolor), 0, 0);
				graphics.Flush();
				font.Dispose();
			}
			return bmp;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** LocalizeDialog method
		**-----------------------------------------------------------------------------------------------------------*/
		private void LocalizeDialog() {
			this.Text = Лоцман_добавка.Properties.Resources.USER_ACC_DLG_TITLE;
			m_btnOK.Text = Лоцман_добавка.Properties.Resources.BTN_OK;
			m_btnCancel.Text = Лоцман_добавка.Properties.Resources.BTN_CANCEL;
			m_btnManage.Text = Лоцман_добавка.Properties.Resources.USER_ACC_DLG_BTN_MANAGE;
			m_btnGrantAccess.Text = Лоцман_добавка.Properties.Resources.USER_ACC_DLG_BTN_GRANT;
			m_btnRevokeAccess.Text = Лоцман_добавка.Properties.Resources.USER_ACC_DLG_BTN_REVOKE;
			m_btnCurrentAuthor.Text = Лоцман_добавка.Properties.Resources.USER_ACC_DLG_BTN_CURRENTAUTHOR;
			m_lblRegUsers.Text = Лоцман_добавка.Properties.Resources.USER_ACC_DLG_LBL_USERS;
		}
	}
}
