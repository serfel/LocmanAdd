using System;
using System.Data;
using System.Runtime.CompilerServices;

namespace DocumentServer.DataSources
{
	/// <summary>The DataTableInfo class provides basic information about a data table in a data source.</summary>
	public class DataTableInfo
	{
		private DataTableInfo dataTableInfo_0;

		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private DataColumnInfoCollection dataColumnInfoCollection_0;

		[CompilerGenerated]
		private DataRelationInfoCollection dataRelationInfoCollection_0;

		[CompilerGenerated]
		private DataTableInfoCollection dataTableInfoCollection_0;

		[CompilerGenerated]
		private Type type_0;

		/// <summary>Gets the table name.</summary>
		public string TableName
		{
			[CompilerGenerated]
			get
			{
				return this.string_0;
			}
			[CompilerGenerated]
			internal set
			{
				this.string_0 = value;
			}
		}

		/// <summary>Gets a DataColumnInfoCollection representing the columns of this data table.</summary>
		public DataColumnInfoCollection Columns
		{
			[CompilerGenerated]
			get
			{
				return this.dataColumnInfoCollection_0;
			}
			[CompilerGenerated]
			internal set
			{
				this.dataColumnInfoCollection_0 = value;
			}
		}

		/// <summary>Gets a DataRelationInfoCollection representing the parent-child-relationships this table has with other data tables.</summary>
		public DataRelationInfoCollection ChildRelations
		{
			[CompilerGenerated]
			get
			{
				return this.dataRelationInfoCollection_0;
			}
			[CompilerGenerated]
			internal set
			{
				this.dataRelationInfoCollection_0 = value;
			}
		}

		/// <summary>Gets a DataTableInfoCollection representing the child-tables this table has.</summary>
		public DataTableInfoCollection ChildTables
		{
			[CompilerGenerated]
			get
			{
				return this.dataTableInfoCollection_0;
			}
			[CompilerGenerated]
			internal set
			{
				this.dataTableInfoCollection_0 = value;
			}
		}

		internal Type Type_0
		{
			[CompilerGenerated]
			get
			{
				return this.type_0;
			}
			[CompilerGenerated]
			private set
			{
				this.type_0 = value;
			}
		}

		internal DataTableInfo(DataTable table, DataTableInfo parent)
		{
			this.TableName = table.TableName;
			this.dataTableInfo_0 = parent;
			this.method_0(table);
			this.method_1(table);
		}

		internal DataTableInfo(DataTable table)
			: this(table, null)
		{
		}

		internal DataTableInfo(string tableName, Type type)
		{
			this.TableName = tableName;
			this.Columns = new DataColumnInfoCollection();
			this.ChildRelations = new DataRelationInfoCollection();
			this.ChildTables = new DataTableInfoCollection();
			this.Type_0 = type;
		}

		internal DataTableInfo(string tableName)
			: this(tableName, null)
		{
		}

		private void method_0(DataTable dataTable_0)
		{
			this.Columns = new DataColumnInfoCollection();
			foreach (DataColumn column in dataTable_0.Columns)
			{
				this.Columns.method_0(new DataColumnInfo(column, this));
			}
		}

		private void method_1(DataTable dataTable_0)
		{
			this.ChildRelations = new DataRelationInfoCollection();
			this.ChildTables = new DataTableInfoCollection();
			foreach (DataRelation childRelation in dataTable_0.ChildRelations)
			{
				if (!this.method_2(childRelation.ChildTable.TableName))
				{
					this.ChildRelations.method_0(new DataRelationInfo(childRelation));
					this.ChildTables.method_0(new DataTableInfo(childRelation.ChildTable, this));
				}
			}
		}

		private bool method_2(string string_1)
		{
			if (this.dataTableInfo_0 == null)
			{
				return false;
			}
			if (this.dataTableInfo_0.TableName == this.TableName)
			{
				return true;
			}
			return this.dataTableInfo_0.method_2(string_1);
		}
	}
}
