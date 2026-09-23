#define TRACE
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using DocumentServer.DataBaseConnection;

namespace ns4
{
	internal class Class99 : DbConnectionAdapter
	{
		private enum Enum16
		{
			const_0 = -1,
			const_1
		}

		private enum Enum17
		{
			const_0 = 4,
			const_1,
			const_2,
			const_3
		}

		private DbProviderFactory dbProviderFactory_0;

		private DataSet dataSet_0;

		private Enum16 enum16_0 = Enum16.const_0;

		private TraceSource traceSource_0;

		private const string string_0 = "select * from [{0}]";

		private const string string_1 = "select * from `{0}`";

		[CompilerGenerated]
		private string string_2;

		[CompilerGenerated]
		private DbConnection dbConnection_0;

		internal override List<DataRelation> DataRelations
		{
			get
			{
				List<DataRelation> list = new List<DataRelation>();
				if (this.dataSet_0 != null)
				{
					foreach (DataRelation relation in this.dataSet_0.Relations)
					{
						list.Add(relation);
					}
					return list;
				}
				return list;
			}
		}

		internal string String_0
		{
			[CompilerGenerated]
			get
			{
				return this.string_2;
			}
			[CompilerGenerated]
			private set
			{
				this.string_2 = value;
			}
		}

		internal string String_1
		{
			get
			{
				if (this.DbConnection_0 == null)
				{
					return string.Empty;
				}
				return this.DbConnection_0.ConnectionString;
			}
		}

		internal DbConnection DbConnection_0
		{
			[CompilerGenerated]
			get
			{
				return this.dbConnection_0;
			}
			[CompilerGenerated]
			private set
			{
				this.dbConnection_0 = value;
			}
		}

		internal DataSet DataSet_0 => this.dataSet_0;

		internal override bool IsConnected => this.DbConnection_0 != null;

		internal Class99(Class102 class102_0)
			: this(class102_0, null)
		{
		}

		internal Class99(Class102 class102_0, TraceSource traceSource_1)
		{
			if (class102_0 == null)
			{
				throw new ArgumentNullException("config");
			}
			this.traceSource_0 = traceSource_1;
			this.method_1(class102_0.String_1, class102_0.String_2);
			if (this.DbConnection_0 != null)
			{
				this.GetTableAndViewNames();
				this.method_0(class102_0.List_0);
				this.SelectTable(class102_0.String_0);
			}
		}

		internal Class99(string string_3, string string_4, TraceSource traceSource_1)
		{
			this.traceSource_0 = traceSource_1;
			this.method_1(string_3, string_4);
			if (this.DbConnection_0 != null)
			{
				this.GetTableAndViewNames();
			}
		}

		internal override DataTable GetTable(string strTable)
		{
			if (this.DbConnection_0 == null)
			{
				return null;
			}
			if (this.dataSet_0 != null && this.dataSet_0.Tables.Contains(strTable))
			{
				return this.dataSet_0.Tables[strTable];
			}
			DataTable dataTable = new DataTable(strTable);
			DbDataAdapter dbDataAdapter = this.dbProviderFactory_0.CreateDataAdapter();
			DbCommand dbCommand = this.dbProviderFactory_0.CreateCommand();
			dbCommand.Connection = this.DbConnection_0;
			dbCommand.CommandType = CommandType.Text;
			dbCommand.CommandText = this.method_2(strTable);
			try
			{
				dbDataAdapter.SelectCommand = dbCommand;
				dbDataAdapter.Fill(dataTable);
			}
			catch (Exception ex)
			{
				if (this.traceSource_0 == null)
				{
					throw;
				}
				this.traceSource_0.TraceEvent(TraceEventType.Error, 4, ex.Message);
				dataTable = null;
			}
			if (dataTable != null)
			{
				if (this.dataSet_0 == null)
				{
					this.dataSet_0 = new DataSet();
				}
				if (!this.dataSet_0.Tables.Contains(dataTable.TableName))
				{
					this.dataSet_0.Tables.Add(dataTable);
				}
			}
			return dataTable;
		}

		internal override void SelectTable(string strTableName)
		{
			if (this.DbConnection_0 != null)
			{
				base.m_selectedTable = new Class98(this.GetTable(strTableName));
			}
		}

		internal override void Close()
		{
			if (this.DbConnection_0 != null)
			{
				if (this.DbConnection_0.State != 0)
				{
					this.DbConnection_0.Close();
				}
				this.DbConnection_0 = null;
				if (this.dataSet_0 != null)
				{
					this.dataSet_0.Clear();
				}
				this.dataSet_0 = null;
			}
		}

		internal override void GetTableAndViewNames()
		{
			base.m_tableNames = new List<string>();
			base.m_viewNames = new List<string>();
			if (this.DbConnection_0 == null)
			{
				return;
			}
			try
			{
				foreach (DataRow row in this.DbConnection_0.GetSchema("Tables").Rows)
				{
					if (!(row["TABLE_SCHEMA"].ToString().ToLowerInvariant() == "sys"))
					{
						string text = row["TABLE_NAME"].ToString();
						if (!text.StartsWith("msys", StringComparison.OrdinalIgnoreCase))
						{
							base.TableNames.Add(text);
						}
					}
				}
				foreach (DataRow row2 in this.DbConnection_0.GetSchema("Views").Rows)
				{
					if (!(row2["TABLE_SCHEMA"].ToString().ToLowerInvariant() == "sys"))
					{
						base.ViewNames.Add(row2["TABLE_NAME"].ToString());
					}
				}
			}
			catch (Exception ex)
			{
				if (this.traceSource_0 != null)
				{
					this.traceSource_0.TraceEvent(TraceEventType.Error, 5, ex.Message);
					if (this.DbConnection_0 != null && this.DbConnection_0.State != 0)
					{
						this.DbConnection_0.Close();
					}
					this.DbConnection_0 = null;
					this.dbProviderFactory_0 = null;
					this.enum16_0 = Enum16.const_0;
					if (this.dataSet_0 != null)
					{
						this.dataSet_0.Clear();
					}
					this.dataSet_0 = null;
					return;
				}
				throw;
			}
		}

		private void method_0(List<Class101> list_0)
		{
			foreach (Class101 item in list_0)
			{
				this.AddDataRelation(item.String_4, item.String_0, item.String_1, item.String_2, item.String_3);
			}
		}

		private void method_1(string string_3, string string_4)
		{
			if (this.DbConnection_0 != null && this.DbConnection_0.State != 0)
			{
				this.DbConnection_0.Close();
			}
			this.DbConnection_0 = null;
			this.dbProviderFactory_0 = null;
			this.enum16_0 = Enum16.const_0;
			base.m_selectedTable = null;
			if (this.dataSet_0 != null)
			{
				this.dataSet_0.Clear();
			}
			this.dataSet_0 = null;
			try
			{
				this.dbProviderFactory_0 = DbProviderFactories.GetFactory(string_3);
				this.DbConnection_0 = this.dbProviderFactory_0.CreateConnection();
				this.DbConnection_0.ConnectionString = string_4;
				this.DbConnection_0.Open();
				this.method_3();
				this.String_0 = string_3;
				this.dataSet_0 = new DataSet();
			}
			catch (Exception ex)
			{
				if (this.traceSource_0 != null)
				{
					this.traceSource_0.TraceEvent(TraceEventType.Error, 6, ex.Message);
					if (this.DbConnection_0 != null && this.DbConnection_0.State != 0)
					{
						this.DbConnection_0.Close();
					}
					this.DbConnection_0 = null;
					this.dbProviderFactory_0 = null;
					this.enum16_0 = Enum16.const_0;
					if (this.dataSet_0 != null)
					{
						this.dataSet_0.Clear();
					}
					this.dataSet_0 = null;
					this.String_0 = string.Empty;
					throw;
				}
				throw;
			}
		}

		internal override DataSet GetDataSet(List<string> tableNames)
		{
			if (this.DbConnection_0 == null)
			{
				return null;
			}
			DataSet dataSet = new DataSet();
			DbDataAdapter dbDataAdapter = this.dbProviderFactory_0.CreateDataAdapter();
			DbCommand dbCommand = this.dbProviderFactory_0.CreateCommand();
			dbCommand.Connection = this.DbConnection_0;
			dbCommand.CommandType = CommandType.Text;
			foreach (string tableName in tableNames)
			{
				dbCommand.CommandText = this.method_2(tableName);
				try
				{
					dbDataAdapter.SelectCommand = dbCommand;
					dbDataAdapter.Fill(dataSet, tableName);
				}
				catch
				{
				}
			}
			return dataSet;
		}

		internal override DataSet GetDataSet()
		{
			List<string> list = new List<string>();
			list.AddRange(base.TableNames);
			list.AddRange(base.ViewNames);
			return this.GetDataSet(list);
		}

		private string method_2(string string_3)
		{
			if (this.enum16_0 == Enum16.const_1)
			{
				return $"select * from `{string_3}`";
			}
			return $"select * from [{string_3}]";
		}

		internal override bool AddDataRelation(string mainTableName, string mainColName, string childTableName, string childColName)
		{
			return this.AddDataRelation("", mainTableName, mainColName, childTableName, childColName);
		}

		internal override bool AddDataRelation(string relationName, string mainTableName, string mainColName, string childTableName, string childColName)
		{
			if (this.dataSet_0 == null)
			{
				this.dataSet_0 = new DataSet();
			}
			if (!this.dataSet_0.Tables.Contains(mainTableName))
			{
				this.GetTable(mainTableName);
			}
			if (!this.dataSet_0.Tables.Contains(childTableName))
			{
				this.GetTable(childTableName);
			}
			DataRelation dataRelation = null;
			try
			{
				dataRelation = new DataRelation(relationName, this.dataSet_0.Tables[mainTableName].Columns[mainColName], this.dataSet_0.Tables[childTableName].Columns[childColName], createConstraints: false);
				this.dataSet_0.Relations.Add(dataRelation);
			}
			catch (ArgumentException)
			{
				return true;
			}
			catch (Exception ex2)
			{
				if (this.traceSource_0 != null)
				{
					this.traceSource_0.TraceEvent(TraceEventType.Warning, 7, ex2.Message);
					if (dataRelation != null)
					{
						try
						{
							this.dataSet_0.Relations.Remove(dataRelation);
						}
						catch
						{
						}
					}
					return false;
				}
				throw;
			}
			return true;
		}

		internal override bool RemoveDataRelation(string name)
		{
			if (this.dataSet_0 == null)
			{
				return false;
			}
			if (!this.dataSet_0.Relations.Contains(name))
			{
				return false;
			}
			this.dataSet_0.Relations.Remove(name);
			return true;
		}

		private void method_3()
		{
			this.enum16_0 = Enum16.const_0;
			if (this.DbConnection_0 != null && this.DbConnection_0 is OdbcConnection)
			{
				OdbcConnection odbcConnection = this.DbConnection_0 as OdbcConnection;
				if (!string.IsNullOrEmpty(odbcConnection.Driver) && odbcConnection.Driver.ToLower().Contains("myodbc"))
				{
					this.enum16_0 = Enum16.const_1;
				}
			}
		}
	}
}
