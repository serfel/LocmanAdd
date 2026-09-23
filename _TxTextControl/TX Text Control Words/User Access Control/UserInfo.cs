/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace TX_Text_Control_Words {

	/*-------------------------------------------------------------------------------------------------------------
	** Class UserInfo
	** Capsulates the user's info like name, password and current access permission. The password is stored as 
	** a SHA1 Hash.
	**-----------------------------------------------------------------------------------------------------------*/
	public class UserInfo : INotifyPropertyChanged {

		/*-------------------------------------------------------------------------------------------------------------
		** M E M B E R S
		**-----------------------------------------------------------------------------------------------------------*/

		private string m_name;						// User's name
		private byte[] m_passwordHash;			// User's password as SHA1 Hash
		private bool m_bAccessGranted = false; // User's access permission

		/*-------------------------------------------------------------------------------------------------------------
		** C O N S T R U C T O R S
		**-----------------------------------------------------------------------------------------------------------*/

		// This constructor is required for de-/serialization which will be done 
		// when saving and loading the application's settings.
		public UserInfo() { 
		}

		public UserInfo(string name, string password) {
			m_name = name;
			m_passwordHash = ComputeSHA1Hash(password);
		}

		/* Constructs a clone of the other user */
		public UserInfo(UserInfo other) {
			m_name = string.Copy(other.m_name);
			m_passwordHash = (byte[])other.m_passwordHash.Clone();
			m_bAccessGranted = other.m_bAccessGranted;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** P R O P E R T I E S
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** Name
		**-----------------------------------------------------------------------------------------------------------*/
		public string Name {
			get { return m_name; }
			set {
				m_name = value.Trim();
				//Debug.Assert(m_name == "", "User's name is empty.");
				OnPropertyChanged("Name");
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** Password
		** Store value as SHA1 Hash.
		**-----------------------------------------------------------------------------------------------------------*/
		public string Password {
			set {
				if (string.IsNullOrEmpty(value)) return;	// Providing null or an empty string does not change an existing password.
				PasswordHash = ComputeSHA1Hash(value);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** PasswordHash
		**-----------------------------------------------------------------------------------------------------------*/
		public byte[] PasswordHash {
			get { return m_passwordHash; }
			set {
				m_passwordHash = value;
				OnPropertyChanged("PasswordHash");
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** AccessGranted
		**-----------------------------------------------------------------------------------------------------------*/
		public bool AccessGranted {
			get { return m_bAccessGranted; }
			set {
				m_bAccessGranted = value;
				OnPropertyChanged("AccessGranted");
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** I N T E R F A C E  - Implementation INotifyPropertyChanged 
		**-----------------------------------------------------------------------------------------------------------*/

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged(string propertyName) {
			if (PropertyChanged != null) {
				var e = new PropertyChangedEventArgs(propertyName);
				PropertyChanged(this, e);
			}
		}


		/*-------------------------------------------------------------------------------------------------------------
		** P U B L I C   M E T H O D S
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** ValidatePassword method
		** Validates whether the passed password is equal to the set password of this user info by compairing
		** the SHA1 hashs.
		**-----------------------------------------------------------------------------------------------------------*/
		public bool ValidatePassword(string password) {
			if (string.IsNullOrEmpty(password)) return false;
			return m_passwordHash.SequenceEqual(ComputeSHA1Hash(password));
		}

		/*-------------------------------------------------------------------------------------------------------------
		** Equals method
		** Equals the object. This instance and the passed object are equal if the object is a UserInfo and 
		** the names are case insensitive equal.
		**-----------------------------------------------------------------------------------------------------------*/
		public override bool Equals(object obj) {
			if (obj == null) return false;
			var that = obj as UserInfo;
			return this.Equals(that);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** Equals method
		** This instance and the passed UserInfo are equal if the names are case insensitive equal.
		**-----------------------------------------------------------------------------------------------------------*/
		public bool Equals(UserInfo that) {
			if ((object)that == null) return false;
			return this.Name.Equals(that.Name, StringComparison.OrdinalIgnoreCase);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** ==  operator
		** These instances are equal if the names are case insensitive equal.
		**-----------------------------------------------------------------------------------------------------------*/
		public static bool operator ==(UserInfo a, UserInfo b) {
			if (object.ReferenceEquals(a, b)) return true;
			return a.Equals(b);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** !=  operator
		**-----------------------------------------------------------------------------------------------------------*/
		public static bool operator !=(UserInfo a, UserInfo b) {
			return !(a == b);
		}

		/*-------------------------------------------------------------------------------------------------------------
		** GetHashCode method
		**-----------------------------------------------------------------------------------------------------------*/
		public override int GetHashCode() {
			return base.GetHashCode();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** H E L P E R   M E T H O D S
		**-----------------------------------------------------------------------------------------------------------*/

		private static byte[] ComputeSHA1Hash(string text) {
			if (string.IsNullOrEmpty(text)) return new byte[0];
			var sha1 = new SHA1CryptoServiceProvider();
			return sha1.ComputeHash(Encoding.UTF8.GetBytes(text));
		}
	}
}