using System.Runtime.CompilerServices;
using TXTextControl;

namespace ns21
{
	internal class Class404
	{
		internal const string string_0 = "blockstart_";

		internal const string string_1 = "blockend_";

		[CompilerGenerated]
		private string string_2;

		[CompilerGenerated]
		private Enum69 enum69_0;

		[CompilerGenerated]
		private DocumentTarget documentTarget_0;

		internal string String_0
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

		internal Enum69 Enum69_0
		{
			[CompilerGenerated]
			get
			{
				return this.enum69_0;
			}
			[CompilerGenerated]
			private set
			{
				this.enum69_0 = value;
			}
		}

		internal DocumentTarget DocumentTarget_0
		{
			[CompilerGenerated]
			get
			{
				return this.documentTarget_0;
			}
			[CompilerGenerated]
			private set
			{
				this.documentTarget_0 = value;
			}
		}

		internal int Int32_0 => this.DocumentTarget_0.Start;

		internal Class404(DocumentTarget documentTarget_1)
		{
			this.DocumentTarget_0 = documentTarget_1;
			this.Enum69_0 = Class404.smethod_1(documentTarget_1.TargetName);
			this.String_0 = Class404.smethod_0(documentTarget_1, this.Enum69_0);
		}

		private static string smethod_0(DocumentTarget documentTarget_1, Enum69 enum69_1)
		{
			return enum69_1 switch
			{
				Enum69.const_0 => documentTarget_1.TargetName.Substring("blockstart_".Length).ToLower(), 
				Enum69.const_1 => documentTarget_1.TargetName.Substring("blockend_".Length).ToLower(), 
				_ => "", 
			};
		}

		private static Enum69 smethod_1(string string_3)
		{
			string_3 = string_3.ToLower();
			if (string_3.StartsWith("blockstart_"))
			{
				return Enum69.const_0;
			}
			if (string_3.StartsWith("blockend_"))
			{
				return Enum69.const_1;
			}
			return Enum69.const_2;
		}
	}
}
