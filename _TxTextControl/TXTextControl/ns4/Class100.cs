using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using DocumentServer.DataBaseConnection;

namespace ns4
{
	internal class Class100 : DbConnectionAdapter
	{
		private DataSet dataSet_0;

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

		internal override bool IsConnected => this.dataSet_0 != null;

		internal Class100(TextReader textReader_0)
		{
			this.dataSet_0 = new DataSet();
			this.dataSet_0.ReadXml(textReader_0, XmlReadMode.Auto);
			this.GetTableAndViewNames();
		}

		internal Class100(string string_0)
		{
			this.dataSet_0 = new DataSet();
			this.dataSet_0.ReadXml(string_0, XmlReadMode.Auto);
			this.GetTableAndViewNames();
		}

		internal override DataTable GetTable(string strTable)
		{
			return this.dataSet_0.Tables[strTable];
		}

		internal override void SelectTable(string strTableName)
		{
			if (this.dataSet_0 != null)
			{
				base.m_selectedTable = new Class98(this.GetTable(strTableName));
			}
		}

		internal override void Close()
		{
			this.dataSet_0 = null;
		}

		internal override void GetTableAndViewNames()
		{
			base.m_tableNames = new List<string>();
			base.m_viewNames = new List<string>();
			if (this.dataSet_0 == null)
			{
				return;
			}
			foreach (DataTable table in this.dataSet_0.Tables)
			{
				base.TableNames.Add(table.TableName);
			}
		}

		internal override DataSet GetDataSet(List<string> tableNames)
		{
			return this.dataSet_0;
		}

		internal override DataSet GetDataSet()
		{
			return this.dataSet_0;
		}

		internal override bool AddDataRelation(string mainTableName, string mainColName, string childTableName, string childColName)
		{
			return this.AddDataRelation("", mainTableName, mainColName, childTableName, childColName);
		}

		internal override bool AddDataRelation(string relationName, string mainTableName, string mainColName, string childTableName, string childColName)
		{
			if (!this.dataSet_0.Tables.Contains(mainTableName))
			{
				return false;
			}
			if (!this.dataSet_0.Tables.Contains(childTableName))
			{
				return false;
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
			catch
			{
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
	}
}
