using System.Reflection;
using System.Runtime.CompilerServices;

namespace DocumentServer.DataShaping
{
	[Obfuscation(Exclude = true)]
	internal class LogicalOperatorItem
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private LogicalOperator logicalOperator_0;

		public string Text
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

		public LogicalOperator LogicalOperator
		{
			[CompilerGenerated]
			get
			{
				return this.logicalOperator_0;
			}
			[CompilerGenerated]
			private set
			{
				this.logicalOperator_0 = value;
			}
		}

		public LogicalOperatorItem(LogicalOperator logOp)
		{
			this.LogicalOperator = logOp;
			this.Text = logOp.ToLocalizedString();
		}
	}
}
