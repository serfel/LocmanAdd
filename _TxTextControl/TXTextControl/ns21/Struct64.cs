using System.Runtime.InteropServices;

namespace ns21
{
	[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 30)]
	internal struct Struct64
	{
		internal ushort ushort_0;

		internal Class429.Struct82 struct82_0;

		internal bool bool_0;

		internal bool bool_1;

		internal Class429.Struct82 struct82_1;

		internal bool bool_2;

		internal Struct64(Struct64 struct64_0)
		{
			this.ushort_0 = struct64_0.ushort_0;
			this.struct82_0 = struct64_0.struct82_0;
			this.bool_0 = struct64_0.bool_0;
			this.bool_1 = struct64_0.bool_1;
			this.struct82_1 = struct64_0.struct82_1;
			this.bool_2 = struct64_0.bool_2;
		}

		internal void method_0()
		{
			this.ushort_0 = 30;
			this.struct82_0 = default(Class429.Struct82);
			this.bool_0 = false;
			this.bool_1 = false;
			this.struct82_1 = default(Class429.Struct82);
			this.bool_2 = false;
		}

		internal bool method_1(Struct64 struct64_0)
		{
			if (this.struct82_0.method_0(struct64_0.struct82_0) && this.struct82_1.method_0(struct64_0.struct82_1) && this.bool_0 == struct64_0.bool_0 && this.bool_1 == struct64_0.bool_1)
			{
				return this.bool_2 == struct64_0.bool_2;
			}
			return false;
		}
	}
}
