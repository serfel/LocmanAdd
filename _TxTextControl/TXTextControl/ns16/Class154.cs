using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using DocumentServer.Properties;
using DocumentServer.Windows.Forms;

namespace ns16
{
	internal class Class154
	{
		public class Class155 : ICollection, IEnumerable
		{
			private ICollection<Class153> icollection_0;

			private Class154 class154_0;

			public int Count => this.icollection_0.Count;

			public bool Boolean_0 => false;

			public bool IsSynchronized => false;

			public object SyncRoot
			{
				get
				{
					throw new NotSupportedException();
				}
			}

			public Class155(Class154 class154_1)
			{
				this.icollection_0 = new List<Class153>();
				this.class154_0 = class154_1;
			}

			public void method_0(Class153 class153_0)
			{
				if (class153_0 == null)
				{
					throw new ArgumentNullException("item");
				}
				if (!this.icollection_0.Contains(class153_0))
				{
					this.icollection_0.Add(class153_0);
				}
			}

			public bool method_1(Class153 class153_0)
			{
				return this.icollection_0.Contains(class153_0);
			}

			public bool method_2(Class153 class153_0)
			{
				bool result = this.icollection_0.Remove(class153_0);
				if (class153_0 == this.class154_0.class153_0)
				{
					this.class154_0.class153_0 = null;
				}
				return result;
			}

			public void method_3()
			{
				this.icollection_0.Clear();
				this.class154_0.class153_0 = null;
			}

			public void method_4(Class153[] class153_0, int int_0)
			{
				this.icollection_0.CopyTo(class153_0, int_0);
			}

			public IEnumerator GetEnumerator()
			{
				return this.icollection_0.GetEnumerator();
			}

			public void CopyTo(Array array, int index)
			{
				throw new NotSupportedException();
			}
		}

		public const string string_0 = "MicrosoftSqlServerFile";

		private static Class154 class154_0;

		private static Class154 class154_1;

		private static Class154 class154_2;

		private static Class154 class154_3;

		private string string_1;

		private string string_2;

		private Class153 class153_0;

		private Class155 class155_0;

		private static ResourceManager resourceManager_0;

		public static Class154 Class154_0
		{
			get
			{
				if (Class154.class154_0 == null)
				{
					Class154.class154_0 = new Class154("MicrosoftSqlServer", Class154.smethod_2("DATASOURCE_MS_SQL_SERVER"));
					Class154.class154_0.Class155_0.method_0(Class153.Class153_0);
					Class154.class154_0.Class155_0.method_0(Class153.Class153_1);
					Class154.class154_0.Class153_0 = Class153.Class153_0;
				}
				return Class154.class154_0;
			}
		}

		public static Class154 Class154_1
		{
			get
			{
				if (Class154.class154_1 == null)
				{
					Class154.class154_1 = new Class154("MicrosoftSqlServerFile", Class154.smethod_2("DATASOURCE_MS_SQL_SERVER_FILE"));
					Class154.class154_1.Class155_0.method_0(Class153.Class153_0);
				}
				return Class154.class154_1;
			}
		}

		public static Class154 Class154_2
		{
			get
			{
				if (Class154.class154_2 == null)
				{
					Class154.class154_2 = new Class154("MicrosoftAccess", Class154.smethod_2("DATASOURCE_MS_ACCESS"));
					Class154.class154_2.Class155_0.method_0(Class153.Class153_1);
				}
				return Class154.class154_2;
			}
		}

		public static Class154 Class154_3
		{
			get
			{
				if (Class154.class154_3 == null)
				{
					Class154.class154_3 = new Class154("OdbcDsn", Class154.smethod_2("DATASOURCE_MS_ODBC_DSN"));
					Class154.class154_3.Class155_0.method_0(Class153.Class153_2);
				}
				return Class154.class154_3;
			}
		}

		public string String_0 => this.string_1;

		public string String_1
		{
			get
			{
				if (this.string_2 == null)
				{
					return this.string_1;
				}
				return this.string_2;
			}
		}

		public Class153 Class153_0
		{
			get
			{
				switch (this.class155_0.Count)
				{
				default:
					if (this.string_1 == null)
					{
						return null;
					}
					return this.class153_0;
				case 1:
				{
					IEnumerator enumerator = this.class155_0.GetEnumerator();
					enumerator.MoveNext();
					return (Class153)enumerator.Current;
				}
				case 0:
					return null;
				}
			}
			set
			{
				if (this.class155_0.Count == 1 && this.class153_0 != value)
				{
					throw new InvalidOperationException(Class154.smethod_2("DATASOURCE_CANT_CHANGE_SINGLE_DATAPROVIDER"));
				}
				if (value != null && !this.class155_0.method_1(value))
				{
					throw new InvalidOperationException(Class154.smethod_2("DATASOURCE_DATAPROVIDER_NOT_FOUND"));
				}
				this.class153_0 = value;
			}
		}

		public Class155 Class155_0 => this.class155_0;

		static Class154()
		{
			Class154.resourceManager_0 = new ResourceManager(typeof(Resources));
		}

		private Class154()
		{
			this.string_2 = Class154.smethod_2("DATASOURCE_UNSPECIFIED_DISPLAY_NAME");
			this.class155_0 = new Class155(this);
		}

		public Class154(string string_3, string string_4)
		{
			if (string_3 == null)
			{
				throw new ArgumentNullException("name");
			}
			this.string_1 = string_3;
			this.string_2 = string_4;
			this.class155_0 = new Class155(this);
		}

		public static void smethod_0(DatabaseConnectionDialog databaseConnectionDialog_0)
		{
			databaseConnectionDialog_0.Class142_0.method_0(Class154.Class154_0);
			databaseConnectionDialog_0.Class142_0.method_0(Class154.Class154_1);
			databaseConnectionDialog_0.Class142_0.method_0(Class154.Class154_2);
			databaseConnectionDialog_0.Class142_0.method_0(Class154.Class154_3);
			databaseConnectionDialog_0.Class154_0.Class155_0.method_0(Class153.Class153_0);
			databaseConnectionDialog_0.Class154_0.Class155_0.method_0(Class153.Class153_1);
			databaseConnectionDialog_0.Class154_0.Class155_0.method_0(Class153.Class153_2);
			databaseConnectionDialog_0.Class142_0.method_0(databaseConnectionDialog_0.Class154_0);
		}

		internal static Class154 smethod_1()
		{
			return new Class154();
		}

		protected static string smethod_2(string string_3)
		{
			return Class154.resourceManager_0.GetString(string_3);
		}
	}
}
