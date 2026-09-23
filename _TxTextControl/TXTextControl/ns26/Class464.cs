using System.Drawing;
using System.Runtime.CompilerServices;

namespace ns26
{
	internal class Class464
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		[CompilerGenerated]
		private object object_0;

		internal string String_0
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

		internal string String_1
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

		internal object Object_0
		{
			[CompilerGenerated]
			get
			{
				return this.object_0;
			}
			[CompilerGenerated]
			set
			{
				this.object_0 = value;
			}
		}

		internal Class464(string string_2, object object_1)
		{
			this.String_0 = string_2;
			this.String_1 = string_2;
			this.Object_0 = object_1;
		}

		internal Class464(string string_2, Font font_0, object object_1)
		{
			this.String_0 = string_2;
			this.String_1 = string_2;
			this.Object_0 = object_1;
		}

		public override string ToString()
		{
			return this.String_1;
		}
	}
}
