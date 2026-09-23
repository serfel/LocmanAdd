using System.Data;
using System.Runtime.CompilerServices;

namespace DocumentServer.DataSources
{
	/// <summary>The DataRelationInfo class provides all necessary information about parent-child-relations between data tables.</summary>
	public class DataRelationInfo
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		[CompilerGenerated]
		private string string_2;

		[CompilerGenerated]
		private string string_3;

		[CompilerGenerated]
		private string string_4;

		/// <summary>Gets the data relation name if one was defined.</summary>
		public string RelationName
		{
			[CompilerGenerated]
			get
			{
				return this.string_0;
			}
			[CompilerGenerated]
			private set
			{
				this.string_0 = value;
			}
		}

		/// <summary>Gets the name of the parent table which is part of this data relation.</summary>
		public string ParentTableName
		{
			[CompilerGenerated]
			get
			{
				return this.string_1;
			}
			[CompilerGenerated]
			private set
			{
				this.string_1 = value;
			}
		}

		/// <summary>Gets the name of the child table which is part of this data relation.</summary>
		public string ChildTableName
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

		/// <summary>Gets the name of the parent column which is part of this data relation.</summary>
		public string ParentColumnName
		{
			[CompilerGenerated]
			get
			{
				return this.string_3;
			}
			[CompilerGenerated]
			private set
			{
				this.string_3 = value;
			}
		}

		/// <summary>Gets the name of the child column which is part of this data relation.</summary>
		public string ChildColumnName
		{
			[CompilerGenerated]
			get
			{
				return this.string_4;
			}
			[CompilerGenerated]
			private set
			{
				this.string_4 = value;
			}
		}

		internal DataRelationInfo(DataRelation dataRelation)
		{
			this.RelationName = dataRelation.RelationName;
			this.ParentTableName = dataRelation.ParentTable.TableName;
			this.ChildTableName = dataRelation.ChildTable.TableName;
			this.ParentColumnName = dataRelation.ParentColumns[0].ColumnName;
			this.ChildColumnName = dataRelation.ChildColumns[0].ColumnName;
		}
	}
}
