using System.Runtime.CompilerServices;

namespace DocumentServer.Fields
{
	public class ComboBoxListItem
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		public string DisplayText
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

		public string Value
		{
			[CompilerGenerated]
			get
			{
				return this.string_1;
			}
			[CompilerGenerated]
			set
			{
				this.string_1 = value;
			}
		}

		public ComboBoxListItem()
		{
			this.DisplayText = "";
			this.Value = "";
		}

		public ComboBoxListItem(string displayText, string value)
		{
			this.DisplayText = displayText;
			this.Value = value;
		}
	}
}
