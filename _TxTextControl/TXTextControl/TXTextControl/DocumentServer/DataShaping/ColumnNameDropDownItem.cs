using System.Reflection;
using System.Runtime.CompilerServices;

namespace DocumentServer.DataShaping
{
	[Obfuscation(Exclude = true)]
	internal class ColumnNameDropDownItem
	{
		[CompilerGenerated]
		private string string_0;

		public string ColumnName
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

		public ColumnNameDropDownItem(string columnName)
		{
			this.ColumnName = columnName;
		}
	}
}
