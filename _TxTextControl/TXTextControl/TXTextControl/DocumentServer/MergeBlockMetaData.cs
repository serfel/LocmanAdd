using System.Reflection;
using System.Runtime.CompilerServices;

namespace TXTextControl.DocumentServer
{
	[Obfuscation(Exclude = true)]
	internal class MergeBlockMetaData
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private DataShapingInfo dataShapingInfo_0;

		public string Name
		{
			[CompilerGenerated]
			get
			{
				return this.string_0;
			}
			[CompilerGenerated]
			set
			{
				this.string_0 = value;
			}
		}

		public DataShapingInfo DataShapingInfo
		{
			[CompilerGenerated]
			get
			{
				return this.dataShapingInfo_0;
			}
			[CompilerGenerated]
			set
			{
				this.dataShapingInfo_0 = value;
			}
		}

		public MergeBlockMetaData(string name)
		{
			this.Name = name;
		}

		public MergeBlockMetaData()
			: this("")
		{
		}
	}
}
