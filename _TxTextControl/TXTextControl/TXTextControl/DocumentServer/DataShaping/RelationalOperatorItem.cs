using System.Reflection;
using System.Runtime.CompilerServices;

namespace DocumentServer.DataShaping
{
	[Obfuscation(Exclude = true)]
	internal class RelationalOperatorItem
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private RelationalOperator relationalOperator_0;

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

		public RelationalOperator RelationalOperator
		{
			[CompilerGenerated]
			get
			{
				return this.relationalOperator_0;
			}
			[CompilerGenerated]
			set
			{
				this.relationalOperator_0 = value;
			}
		}

		public RelationalOperatorItem(RelationalOperator relOp)
		{
			this.RelationalOperator = relOp;
			this.Text = relOp.ToLocalizedString();
		}
	}
}
