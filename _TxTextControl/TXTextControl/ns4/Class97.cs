using System.Data;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ns4
{
	internal class Class97
	{
		private string string_0;

		[CompilerGenerated]
		private DataRelation dataRelation_0;

		public DataRelation DataRelation_0
		{
			[CompilerGenerated]
			get
			{
				return this.dataRelation_0;
			}
			[CompilerGenerated]
			private set
			{
				this.dataRelation_0 = value;
			}
		}

		[Obfuscation(Exclude = true)]
		public string Description
		{
			get
			{
				if (this.string_0 == null)
				{
					this.string_0 = $"{this.DataRelation_0.ParentTable.TableName}[\"{this.DataRelation_0.ParentColumns[0]}\"] -> {this.DataRelation_0.ChildTable.TableName}[\"{this.DataRelation_0.ChildColumns[0]}\"]";
				}
				return this.string_0;
			}
		}

		[Obfuscation(Exclude = true)]
		public string RelationName
		{
			get
			{
				if (this.DataRelation_0 == null)
				{
					return "";
				}
				return this.DataRelation_0.RelationName;
			}
		}

		public Class97(DataRelation dataRelation_1)
		{
			this.DataRelation_0 = dataRelation_1;
		}
	}
}
