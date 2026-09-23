using System;
using System.ComponentModel;
using System.Data.Common;
using System.Data.SqlClient;

namespace ns16
{
	internal class Class150 : Class144
	{
		private const int int_0 = 4060;

		public override bool IsComplete
		{
			get
			{
				if (base.DbConnectionStringBuilder_0["Data Source"] is string && (base.DbConnectionStringBuilder_0["Data Source"] as string).Length != 0)
				{
					if (!(bool)base.DbConnectionStringBuilder_0["Integrated Security"] && (!(base.DbConnectionStringBuilder_0["User ID"] is string) || (base.DbConnectionStringBuilder_0["User ID"] as string).Length == 0))
					{
						return false;
					}
					return true;
				}
				return false;
			}
		}

		protected override PropertyDescriptor PropertyDescriptor_0 => this.GetProperties(new Attribute[0])["DataSource"];

		public Class150()
			: base("System.Data.SqlClient")
		{
			this.method_1();
		}

		public override void Reset()
		{
			base.Reset();
			this.method_1();
		}

		public override void Test()
		{
			string text = base.DbConnectionStringBuilder_0["Data Source"] as string;
			if (text != null && text.Length != 0)
			{
				string text2 = base.DbConnectionStringBuilder_0["Initial Catalog"] as string;
				try
				{
					base.Test();
				}
				catch (SqlException ex)
				{
					if (ex.Number == 4060 && text2 != null && text2.Length > 0)
					{
						throw new InvalidOperationException(Class144.smethod_0("SQLCONNECTION_PROPERTIES_CANT_TEST_NON_EXISTENT_DB"));
					}
					throw;
				}
				return;
			}
			throw new InvalidOperationException(Class144.smethod_0("SQLCONNECTION_PROPERTIES_MUST_SPECIFY_DATASOURCE"));
		}

		protected override string vmethod_0()
		{
			bool flag = (bool)base.DbConnectionStringBuilder_0["Pooling"];
			bool num = !base.DbConnectionStringBuilder_0.ShouldSerialize("Pooling");
			base.DbConnectionStringBuilder_0["Pooling"] = false;
			string connectionString = base.DbConnectionStringBuilder_0.ConnectionString;
			base.DbConnectionStringBuilder_0["Pooling"] = flag;
			if (num)
			{
				base.DbConnectionStringBuilder_0.Remove("Pooling");
			}
			return connectionString;
		}

		protected override void vmethod_1(DbConnection dbConnection_0)
		{
			if (dbConnection_0.ServerVersion.StartsWith("07", StringComparison.Ordinal) || dbConnection_0.ServerVersion.StartsWith("08", StringComparison.Ordinal))
			{
				throw new NotSupportedException(Class144.smethod_0("SQLCONNECTION_PROPERTIES_UNSUPPORTED_SQL_VERSION"));
			}
		}

		private void method_1()
		{
			this["Integrated Security"] = true;
		}
	}
}
