using System.Runtime.CompilerServices;

namespace DocumentServer.Fields
{
	public class DocPart
	{
		[CompilerGenerated]
		private string string_0;

		public string Value
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

		public DocPart(string value)
		{
			this.Value = value;
		}
	}
}
