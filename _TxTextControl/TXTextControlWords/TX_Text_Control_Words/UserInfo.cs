using System;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace TX_Text_Control_Words
{
	public class UserInfo : INotifyPropertyChanged
	{
		private string m_name;

		private byte[] m_passwordHash;

		private bool m_bAccessGranted;

		public string Name
		{
			get
			{
				return this.m_name;
			}
			set
			{
				this.m_name = value.Trim();
				this.OnPropertyChanged("Name");
			}
		}

		public string Password
		{
			set
			{
				if (!string.IsNullOrEmpty(value))
				{
					this.PasswordHash = UserInfo.ComputeSHA1Hash(value);
				}
			}
		}

		public byte[] PasswordHash
		{
			get
			{
				return this.m_passwordHash;
			}
			set
			{
				this.m_passwordHash = value;
				this.OnPropertyChanged("PasswordHash");
			}
		}

		public bool AccessGranted
		{
			get
			{
				return this.m_bAccessGranted;
			}
			set
			{
				this.m_bAccessGranted = value;
				this.OnPropertyChanged("AccessGranted");
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public UserInfo()
		{
		}

		public UserInfo(string name, string password)
		{
			this.m_name = name;
			this.m_passwordHash = UserInfo.ComputeSHA1Hash(password);
		}

		public UserInfo(UserInfo other)
		{
			this.m_name = string.Copy(other.m_name);
			this.m_passwordHash = (byte[])other.m_passwordHash.Clone();
			this.m_bAccessGranted = other.m_bAccessGranted;
		}

		protected virtual void OnPropertyChanged(string propertyName)
		{
			if (this.PropertyChanged != null)
			{
				PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
				this.PropertyChanged(this, e);
			}
		}

		public bool ValidatePassword(string password)
		{
			if (string.IsNullOrEmpty(password))
			{
				return false;
			}
			return this.m_passwordHash.SequenceEqual(UserInfo.ComputeSHA1Hash(password));
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			UserInfo that = obj as UserInfo;
			return this.Equals(that);
		}

		public bool Equals(UserInfo that)
		{
			if ((object)that == null)
			{
				return false;
			}
			return this.Name.Equals(that.Name, StringComparison.OrdinalIgnoreCase);
		}

		public static bool operator ==(UserInfo a, UserInfo b)
		{
			if ((object)a == b)
			{
				return true;
			}
			return a.Equals(b);
		}

		public static bool operator !=(UserInfo a, UserInfo b)
		{
			return !(a == b);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		private static byte[] ComputeSHA1Hash(string text)
		{
			if (string.IsNullOrEmpty(text))
			{
				return new byte[0];
			}
			SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();
			return sHA1CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(text));
		}
	}
}
