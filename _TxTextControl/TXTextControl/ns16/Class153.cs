using System;
using System.Collections.Generic;
using System.Reflection;
using System.Resources;
using DocumentServer.Data.ConnectionUI;
using DocumentServer.Properties;

namespace ns16
{
	internal class Class153
	{
		private static Class153 class153_0;

		private static Class153 class153_1;

		private static Class153 class153_2;

		private string string_0;

		private string string_1;

		private string string_2;

		private string string_3;

		private IDictionary<string, string> idictionary_0;

		private IDictionary<string, Type> idictionary_1;

		private IDictionary<string, Type> idictionary_2;

		private static ResourceManager resourceManager_0;

		public static Class153 Class153_0
		{
			get
			{
				if (Class153.class153_0 == null)
				{
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					dictionary.Add(Class154.Class154_0.String_0, Class153.smethod_0("DATAPROVIDER_SQL_DATASOURCE_DESCRIPTION"));
					dictionary.Add("MicrosoftSqlServerFile", Class153.smethod_0("DATAPROVIDER_SQL_FILEDATASOURCE_DESCRIPTION"));
					Dictionary<string, Type> dictionary2 = new Dictionary<string, Type>();
					dictionary2.Add(Class154.Class154_0.String_0, typeof(SqlConnectionUIControl));
					dictionary2.Add("MicrosoftSqlServerFile", typeof(SqlFileConnectionUIControl));
					dictionary2.Add(string.Empty, typeof(SqlConnectionUIControl));
					Dictionary<string, Type> dictionary3 = new Dictionary<string, Type>();
					dictionary3.Add("MicrosoftSqlServerFile", typeof(Class151));
					dictionary3.Add(string.Empty, typeof(Class150));
					Class153.class153_0 = new Class153("System.Data.SqlClient", Class153.smethod_0("DATAPROVIDER_SQL"), Class153.smethod_0("DATAPROVIDER_SQL_SHORT"), Class153.smethod_0("DATAPROVIDER_SQL_DESCRIPTION"), dictionary, dictionary2, dictionary3);
				}
				return Class153.class153_0;
			}
		}

		public static Class153 Class153_1
		{
			get
			{
				if (Class153.class153_1 == null)
				{
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					dictionary.Add(Class154.Class154_0.String_0, Class153.smethod_0("DATAPROVIDER_OLEDB_SQLDATASOURCE_DESCRIPTION"));
					dictionary.Add(Class154.Class154_2.String_0, Class153.smethod_0("DATAPROVIDER_OLEDB_ACCESS_DATA_SOURCE_DESCRIPTION"));
					Dictionary<string, Type> dictionary2 = new Dictionary<string, Type>();
					dictionary2.Add(Class154.Class154_0.String_0, typeof(SqlConnectionUIControl));
					dictionary2.Add(Class154.Class154_2.String_0, typeof(AccessConnectionUIControl));
					dictionary2.Add(string.Empty, typeof(OleDBConnectionUIControl));
					Dictionary<string, Type> dictionary3 = new Dictionary<string, Type>();
					dictionary3.Add(Class154.Class154_0.String_0, typeof(Class148));
					dictionary3.Add(Class154.Class154_2.String_0, typeof(Class149));
					dictionary3.Add(string.Empty, typeof(Class146));
					Class153.class153_1 = new Class153("System.Data.OleDb", Class153.smethod_0("DATAPROVIDER_OLEDB"), Class153.smethod_0("DATAPROVIDER_OLEDB_SHORT"), Class153.smethod_0("DATAPROVIDER_OLEDB_DESCRIPTION"), dictionary, dictionary2, dictionary3);
				}
				return Class153.class153_1;
			}
		}

		public static Class153 Class153_2
		{
			get
			{
				if (Class153.class153_2 == null)
				{
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					dictionary.Add(Class154.Class154_3.String_0, Class153.smethod_0("DATAPROVIDER_ODBC_DATASOURCE_DESCRIPTION"));
					Dictionary<string, Type> dictionary2 = new Dictionary<string, Type>();
					dictionary2.Add(string.Empty, typeof(OdbcConnectionUIControl));
					Class153.class153_2 = new Class153("System.Data.Odbc", Class153.smethod_0("DATAPROVIDER_ODBC"), Class153.smethod_0("DATAPROVIDER_ODBC_SHORT"), Class153.smethod_0("DATAPROVIDER_ODBC_DESCRIPTION"), dictionary, dictionary2, typeof(Class145));
				}
				return Class153.class153_2;
			}
		}

		[Obfuscation(Exclude = true)]
		public string Name => this.string_0;

		[Obfuscation(Exclude = true)]
		public string DisplayName
		{
			get
			{
				if (this.string_1 == null)
				{
					return this.string_0;
				}
				return this.string_1;
			}
		}

		[Obfuscation(Exclude = true)]
		public string ShortDisplayName => this.string_2;

		[Obfuscation(Exclude = true)]
		public string Description => this.vmethod_0(null);

		static Class153()
		{
			Class153.resourceManager_0 = new ResourceManager(typeof(Resources));
		}

		public Class153(string string_4, string string_5, string string_6)
			: this(string_4, string_5, string_6, null, null)
		{
		}

		public Class153(string string_4, string string_5, string string_6, string string_7)
		{
			if (string_4 == null)
			{
				throw new ArgumentNullException("name");
			}
			this.string_0 = string_4;
			this.string_1 = string_5;
			this.string_2 = string_6;
			this.string_3 = string_7;
		}

		public Class153(string string_4, string string_5, string string_6, string string_7, Type type_0)
			: this(string_4, string_5, string_6, string_7)
		{
			if (type_0 == null)
			{
				throw new ArgumentNullException("connectionPropertiesType");
			}
			this.idictionary_2 = new Dictionary<string, Type>();
			this.idictionary_2.Add(string.Empty, type_0);
		}

		public Class153(string string_4, string string_5, string string_6, string string_7, Type type_0, Type type_1)
			: this(string_4, string_5, string_6, string_7, type_1)
		{
			if (type_0 == null)
			{
				throw new ArgumentNullException("connectionUIControlType");
			}
			this.idictionary_1 = new Dictionary<string, Type>();
			this.idictionary_1.Add(string.Empty, type_0);
		}

		public Class153(string string_4, string string_5, string string_6, string string_7, IDictionary<string, Type> idictionary_3, Type type_0)
			: this(string_4, string_5, string_6, string_7, type_0)
		{
			this.idictionary_1 = idictionary_3;
		}

		public Class153(string string_4, string string_5, string string_6, string string_7, IDictionary<string, string> idictionary_3, IDictionary<string, Type> idictionary_4, Type type_0)
			: this(string_4, string_5, string_6, string_7, idictionary_4, type_0)
		{
			this.idictionary_0 = idictionary_3;
		}

		public Class153(string string_4, string string_5, string string_6, string string_7, IDictionary<string, string> idictionary_3, IDictionary<string, Type> idictionary_4, IDictionary<string, Type> idictionary_5)
			: this(string_4, string_5, string_6, string_7)
		{
			this.idictionary_0 = idictionary_3;
			this.idictionary_1 = idictionary_4;
			this.idictionary_2 = idictionary_5;
		}

		public virtual string vmethod_0(Class154 class154_0)
		{
			if (this.idictionary_0 != null && class154_0 != null && this.idictionary_0.ContainsKey(class154_0.String_0))
			{
				return this.idictionary_0[class154_0.String_0];
			}
			return this.string_3;
		}

		public IDataConnectionUIControl method_0()
		{
			return this.vmethod_1(null);
		}

		public virtual IDataConnectionUIControl vmethod_1(Class154 class154_0)
		{
			string text = null;
			if ((this.idictionary_1 != null && class154_0 != null && this.idictionary_1.ContainsKey(text = class154_0.String_0)) || this.idictionary_1.ContainsKey(text = string.Empty))
			{
				return Activator.CreateInstance(this.idictionary_1[text]) as IDataConnectionUIControl;
			}
			return null;
		}

		public IDataConnectionProperties method_1()
		{
			return this.vmethod_2(null);
		}

		public virtual IDataConnectionProperties vmethod_2(Class154 class154_0)
		{
			string text = null;
			if (this.idictionary_2 != null && ((class154_0 != null && this.idictionary_2.ContainsKey(text = class154_0.String_0)) || this.idictionary_2.ContainsKey(text = string.Empty)))
			{
				return Activator.CreateInstance(this.idictionary_2[text]) as IDataConnectionProperties;
			}
			return null;
		}

		protected static string smethod_0(string string_4)
		{
			return Class153.resourceManager_0.GetString(string_4);
		}
	}
}
