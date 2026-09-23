using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using DocumentServer.DataSources;
using DocumentServer.Properties;
using TXTextControl;

namespace DocumentServer.Windows.Forms
{
	[Obfuscation(Exclude = true)]
	internal class MergeBlockListItem
	{
		[CompilerGenerated]
		private MergeBlockInfo mergeBlockInfo_0;

		public MergeBlockInfo MergeBlockInfo
		{
			[CompilerGenerated]
			get
			{
				return this.mergeBlockInfo_0;
			}
			[CompilerGenerated]
			private set
			{
				this.mergeBlockInfo_0 = value;
			}
		}

		public SubTextPart SubTextPart => this.MergeBlockInfo.SubTextPart_0;

		[Obfuscation(Exclude = true)]
		public string Name
		{
			get
			{
				return this.MergeBlockInfo.TableName;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new Exception(Resources.EXC_EDIT_MERGE_BLOCKS_EMPTY_BLOCK_NAME);
				}
				this.MergeBlockInfo.TableName = value;
			}
		}

		public MergeBlockListItem(MergeBlockInfo mergeBlockInfo)
		{
			this.MergeBlockInfo = mergeBlockInfo;
		}

		public void ScrollToBlock()
		{
			if (this.MergeBlockInfo != null)
			{
				this.MergeBlockInfo.method_1();
			}
		}
	}
}
