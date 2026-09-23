using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using TXTextControl;

namespace ns21
{
	internal class Class429
	{
		internal enum Enum121
		{
			const_0 = 1,
			const_1 = 2,
			const_2 = 6,
			const_3 = 7,
			const_4 = 8,
			const_5 = 10,
			const_6 = 12,
			const_7 = 13,
			const_8 = 14,
			const_9 = 0xF,
			const_10 = 0x10,
			const_11 = 18,
			const_12 = 28,
			const_13 = 0x1F,
			const_14 = 0x20,
			const_15 = 33,
			const_16 = 36,
			const_17 = 48,
			const_18 = 61,
			const_19 = 70,
			const_20 = 71,
			const_21 = 81,
			const_22 = 123,
			const_23 = 131,
			const_24 = 132,
			const_25 = 133,
			const_26 = 134,
			const_27 = 0x100,
			const_28 = 257,
			const_29 = 258,
			const_30 = 259,
			const_31 = 260,
			const_32 = 261,
			const_33 = 262,
			const_34 = 263,
			const_35 = 273,
			const_36 = 276,
			const_37 = 277,
			const_38 = 288,
			const_39 = 0x200,
			const_40 = 513,
			const_41 = 514,
			const_42 = 515,
			const_43 = 516,
			const_44 = 517,
			const_45 = 518,
			const_46 = 519,
			const_47 = 520,
			const_48 = 521,
			const_49 = 522,
			const_50 = 523,
			const_51 = 524,
			const_52 = 528,
			const_53 = 529,
			const_54 = 530,
			const_55 = 736,
			const_56 = 738,
			const_57 = 739,
			const_58 = 768,
			const_59 = 769,
			const_60 = 770,
			const_61 = 771,
			const_62 = 791,
			const_63 = 792,
			const_64 = 794,
			const_65 = 0x3FF,
			const_66 = 0x400,
			const_67 = 269,
			const_68 = 270,
			const_69 = 271,
			const_70 = 641,
			const_71 = 642,
			const_72 = 4864,
			const_73 = 4877,
			const_74 = 4904,
			const_75 = 4907
		}

		internal enum Enum122
		{
			const_0 = 3,
			const_1 = 4,
			const_2 = 5,
			const_3 = 0,
			const_4 = 6,
			const_5 = 7,
			const_6 = 0x100,
			const_7 = 0x200,
			const_8 = 768
		}

		internal enum Enum123 : uint
		{
			const_0 = 0x80000000u,
			const_1 = 0x40000000u,
			const_2 = 0x10000000u,
			const_3 = 0x100000u,
			const_4 = 0x200000u,
			const_5 = 0x8000000u,
			const_6 = 0x800000u,
			const_7 = 0x1000u,
			const_8 = 0x2000u,
			const_9 = 0x4000u,
			const_10 = 0x400000u,
			const_11 = 12582912u
		}

		internal enum Enum124 : uint
		{
			const_0 = 1u,
			const_1 = 2u,
			const_2 = 4u,
			const_3 = 8u,
			const_4 = 0x10u,
			const_5 = 0x20u
		}

		internal enum Enum125 : uint
		{
			const_0 = 1u,
			const_1 = 2u,
			const_2 = 4u,
			const_3 = 8u,
			const_4 = 0x10u,
			const_5 = 0x20u,
			const_6 = 0x40u,
			const_7 = 0x80u
		}

		internal enum Enum126
		{
			const_0 = -2,
			const_1 = -1,
			const_2 = 0,
			const_3 = 1,
			const_4 = 2,
			const_5 = 3,
			const_6 = 4,
			const_7 = 4,
			const_8 = 5,
			const_9 = 6,
			const_10 = 7,
			const_11 = 8,
			const_12 = 9,
			const_13 = 10,
			const_14 = 11,
			const_15 = 12,
			const_16 = 13,
			const_17 = 14,
			const_18 = 0xF,
			const_19 = 0x10,
			const_20 = 17,
			const_21 = 18,
			const_22 = 8,
			const_23 = 9,
			const_24 = 10,
			const_25 = 17,
			const_26 = 19,
			const_27 = 20,
			const_28 = 21
		}

		internal enum Enum127
		{
			const_0 = -4,
			const_1 = -16,
			const_2 = -20
		}

		internal enum Enum128
		{
			const_0,
			const_1,
			const_2
		}

		internal enum Enum129
		{
			const_0 = 9,
			const_1 = 37,
			const_2 = 38,
			const_3 = 39,
			const_4 = 40
		}

		internal struct Struct82
		{
			internal int int_0;

			internal int int_1;

			internal Struct82(int int_2, int int_3)
			{
				this.int_0 = int_2;
				this.int_1 = int_3;
			}

			internal bool method_0(Struct82 struct82_0)
			{
				if (struct82_0.int_0 == this.int_0)
				{
					return struct82_0.int_1 == this.int_1;
				}
				return false;
			}
		}

		internal struct Struct83
		{
			internal int int_0;

			internal int int_1;

			internal int int_2;

			internal int int_3;

			internal Struct83(int int_4, int int_5, int int_6, int int_7)
			{
				this.int_0 = int_4;
				this.int_1 = int_5;
				this.int_2 = int_6;
				this.int_3 = int_7;
			}

			internal Struct83(Rectangle rectangle_0)
			{
				this.int_0 = rectangle_0.Left;
				this.int_1 = rectangle_0.Top;
				this.int_2 = rectangle_0.Right;
				this.int_3 = rectangle_0.Bottom;
			}

			internal Rectangle method_0()
			{
				return new Rectangle(this.int_0, this.int_1, this.int_2 - this.int_0, this.int_3 - this.int_1);
			}
		}

		internal struct Struct84
		{
			internal IntPtr intptr_0;

			internal IntPtr intptr_1;

			internal uint uint_0;
		}

		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		internal struct Struct85
		{
			internal Struct82 struct82_0;

			internal Struct82 struct82_1;

			internal Struct82 struct82_2;

			internal Struct82 struct82_3;

			internal Struct82 struct82_4;
		}

		public struct Struct86
		{
			public IntPtr intptr_0;

			public IntPtr intptr_1;

			public int int_0;

			public int int_1;

			public int int_2;

			public int int_3;

			public int int_4;
		}

		internal struct Struct87
		{
			internal IntPtr intptr_0;

			internal int int_0;

			internal IntPtr intptr_1;

			internal IntPtr intptr_2;

			internal int int_1;

			internal Struct82 struct82_0;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		internal struct Struct88
		{
			internal int int_0;

			internal int int_1;

			internal int int_2;

			internal int int_3;

			internal int int_4;

			internal byte byte_0;

			internal byte byte_1;

			internal byte byte_2;

			internal byte byte_3;

			internal byte byte_4;

			internal byte byte_5;

			internal byte byte_6;

			internal byte byte_7;

			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
			internal string string_0;
		}

		internal struct Struct89
		{
			internal int int_0;

			internal int int_1;

			internal int int_2;

			internal int int_3;
		}

		internal struct Struct90
		{
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
			internal Struct83[] struct83_0;

			internal IntPtr intptr_0;
		}

		internal struct Struct91
		{
			internal Struct92 struct92_0;

			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.Struct)]
			internal Struct93[] struct93_0;
		}

		internal struct Struct92
		{
			internal uint uint_0;

			internal int int_0;

			internal int int_1;

			internal ushort ushort_0;

			internal ushort ushort_1;

			internal ushort ushort_2;

			internal uint uint_1;

			internal int int_2;

			internal int int_3;

			internal uint uint_2;

			internal uint uint_3;
		}

		internal struct Struct93
		{
			internal byte byte_0;

			internal byte byte_1;

			internal byte byte_2;

			internal byte byte_3;
		}

		public struct Struct94
		{
			public Struct82 struct82_0;

			public uint uint_0;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		internal struct Struct95
		{
			internal int int_0;

			internal int int_1;

			internal int int_2;

			internal int int_3;

			internal int int_4;

			internal int int_5;

			internal Struct88 struct88_0;

			internal int int_6;

			internal int int_7;

			internal Struct88 struct88_1;

			internal int int_8;

			internal int int_9;

			internal Struct88 struct88_2;

			internal Struct88 struct88_3;

			internal Struct88 struct88_4;

			internal int int_10;
		}

		internal const int int_0 = 1;

		internal const int int_1 = 0;

		internal static int smethod_0(Color color_0)
		{
			return Color.FromArgb(0, color_0.B, color_0.G, color_0.R).ToArgb();
		}

		internal static int smethod_1(Color? nullable_0)
		{
			if (!nullable_0.HasValue)
			{
				return int.MinValue;
			}
			return Class429.smethod_0(nullable_0.Value);
		}

		internal static Color smethod_2(int int_2)
		{
			return Color.FromArgb(int_2 & 0xFF, (int_2 & 0xFF00) >> 8, (int_2 & 0xFF0000) >> 16);
		}

		internal static int smethod_3(int int_2, int int_3)
		{
			if (int_2 <= 65535 && int_2 >= -32768)
			{
				if (int_3 > 65535 || int_3 < -32768)
				{
					throw new ArgumentOutOfRangeException();
				}
				short num = (short)int_2;
				short num2 = (short)int_3;
				return (num2 << 16) | (ushort)num;
			}
			throw new ArgumentOutOfRangeException();
		}

		internal static ushort smethod_4(byte byte_0, byte byte_1)
		{
			return (ushort)((byte_1 << 8) | byte_0);
		}

		internal static ushort smethod_5(int int_2)
		{
			return (ushort)((uint)int_2 & 0xFFFFu);
		}

		internal static ushort smethod_6(int int_2)
		{
			return (ushort)((uint)(int_2 >> 16) & 0xFFFFu);
		}

		internal static short smethod_7(IntPtr intptr_0)
		{
			int num = (int)(long)intptr_0;
			return (short)(num & 0xFFFF);
		}

		internal static int smethod_8(IntPtr intptr_0)
		{
			int num = (int)(long)intptr_0;
			return (short)((num >> 16) & 0xFFFF);
		}

		internal static byte smethod_9(ushort ushort_0)
		{
			return (byte)ushort_0;
		}

		internal static byte smethod_10(ushort ushort_0)
		{
			return (byte)(ushort_0 >> 8);
		}

		internal static IntPtr smethod_11(IntPtr intptr_0, int int_2)
		{
			if (IntPtr.Size != 4)
			{
				return Class429.GetWindowLongPtr(intptr_0, int_2);
			}
			return Class429.GetWindowLong(intptr_0, int_2);
		}

		internal static IntPtr smethod_12(IntPtr intptr_0, int int_2, IntPtr intptr_1)
		{
			if (IntPtr.Size != 4)
			{
				return Class429.SetWindowLongPtr(intptr_0, int_2, intptr_1);
			}
			return Class429.SetWindowLong(intptr_0, int_2, intptr_1);
		}

		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		internal static extern IntPtr GlobalLock(IntPtr intptr_0);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		internal static extern bool GlobalUnlock(IntPtr intptr_0);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
		internal static extern IntPtr GlobalFree(IntPtr intptr_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern IntPtr CreateWindowEx(uint uint_0, string string_0, string string_1, uint uint_1, int int_2, int int_3, int int_4, int int_5, IntPtr intptr_0, IntPtr intptr_1, IntPtr intptr_2, IntPtr intptr_3);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern IntPtr CallWindowProc(IntPtr intptr_0, IntPtr intptr_1, int int_2, IntPtr intptr_2, IntPtr intptr_3);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern bool DestroyWindow(IntPtr intptr_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern IntPtr SetFocus(IntPtr intptr_0);

		[DllImport("user32.dll")]
		internal static extern int DrawText(IntPtr intptr_0, string string_0, int int_2, ref Struct83 struct83_0, uint uint_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern IntPtr GetFocus();

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern bool TranslateMessage(ref Struct87 struct87_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern bool DispatchMessage(ref Struct87 struct87_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern bool IsChild(IntPtr intptr_0, IntPtr intptr_1);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern bool PeekMessage(out Struct87 struct87_0, IntPtr intptr_0, uint uint_0, uint uint_1, Enum128 enum128_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern IntPtr ClientToScreen(IntPtr intptr_0, ref Struct82 struct82_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern IntPtr ScreenToClient(IntPtr intptr_0, ref Struct82 struct82_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern bool GetClientRect(IntPtr intptr_0, ref Struct83 struct83_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern bool GetWindowRect(IntPtr intptr_0, ref Struct83 struct83_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern bool IsZoomed(IntPtr intptr_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern int GetClassName(IntPtr intptr_0, StringBuilder stringBuilder_0, int int_2);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern IntPtr GetWindowLong(IntPtr intptr_0, int int_2);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern IntPtr GetWindowLongPtr(IntPtr intptr_0, int int_2);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern IntPtr SetWindowLong(IntPtr intptr_0, int int_2, IntPtr intptr_1);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern IntPtr SetWindowLongPtr(IntPtr intptr_0, int int_2, IntPtr intptr_1);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern IntPtr LoadBitmap(IntPtr intptr_0, IntPtr intptr_1);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		internal static extern bool DeleteObject(IntPtr intptr_0);

		[DllImport("gdi32.dll", CharSet = CharSet.Auto)]
		internal static extern int SetBkMode(IntPtr intptr_0, int int_2);

		[DllImport("user32.dll")]
		internal static extern bool SetWindowPos(IntPtr intptr_0, IntPtr intptr_1, int int_2, int int_3, int int_4, int int_5, uint uint_0);

		[DllImport("user32.dll")]
		internal static extern bool ShowWindow(IntPtr intptr_0, int int_2);

		[DllImport("user32.dll")]
		internal static extern IntPtr GetCapture();

		[DllImport("user32.dll")]
		internal static extern IntPtr SetCapture(IntPtr intptr_0);

		[DllImport("user32.dll")]
		internal static extern bool ReleaseCapture();

		[DllImport("user32.dll")]
		internal static extern int GetWindowText(IntPtr intptr_0, StringBuilder stringBuilder_0, int int_2);

		[DllImport("user32.dll")]
		internal static extern int GetWindowTextLength(IntPtr intptr_0);

		[DllImport("user32.dll")]
		internal static extern bool AdjustWindowRectEx(ref Struct83 struct83_0, uint uint_0, bool bool_0, uint uint_1);

		[DllImport("user32.dll")]
		internal static extern bool MessageBeep(int int_2);

		[DllImport("user32.dll")]
		internal static extern int GetSystemMetrics(int int_2);

		[DllImport("user32.dll")]
		internal static extern IntPtr DefWindowProc(IntPtr intptr_0, int int_2, IntPtr intptr_1, IntPtr intptr_2);

		[DllImport("user32.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
		public static extern uint RealGetWindowClassW(IntPtr intptr_0, StringBuilder stringBuilder_0, uint uint_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern bool PostMessage(IntPtr intptr_0, int int_2, int int_3, int int_4);

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		internal static extern int SendMessage(IntPtr intptr_0, int int_2, int int_3, ref Struct62 struct62_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_1(IntPtr intptr_0, int int_2, int int_3, int int_4);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_2(IntPtr intptr_0, int int_2, IntPtr intptr_1, int int_3);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_3(IntPtr intptr_0, int int_2, int int_3, ref Struct83 struct83_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_4(IntPtr intptr_0, int int_2, IntPtr intptr_1, ref Struct83 struct83_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_5(IntPtr intptr_0, int int_2, int int_3, ref Struct82 struct82_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern IntPtr SendMessage_6(IntPtr intptr_0, int int_2, int int_3, IntPtr intptr_1);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_7(IntPtr intptr_0, int int_2, int int_3, int[] int_4);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_8(IntPtr intptr_0, int int_2, int int_3, byte[] byte_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_9(IntPtr intptr_0, int int_2, int int_3, short[] short_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_10(IntPtr intptr_0, int int_2, int int_3, TabType[] tabType_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_11(IntPtr intptr_0, int int_2, int int_3, TabLeader[] tabLeader_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_12(IntPtr intptr_0, int int_2, int int_3, ref Struct53 struct53_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_13(IntPtr intptr_0, int int_2, int int_3, ref Struct61 struct61_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_14(IntPtr intptr_0, int int_2, int int_3, ref Struct48 struct48_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_15(IntPtr intptr_0, int int_2, int int_3, ref Struct76 struct76_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_16(IntPtr intptr_0, int int_2, int int_3, ref Struct77 struct77_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_17(IntPtr intptr_0, int int_2, int int_3, ref Struct50 struct50_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_18(IntPtr intptr_0, int int_2, int int_3, ref Struct45 struct45_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern IntPtr SendMessage_19(IntPtr intptr_0, int int_2, int int_3, ref Struct46 struct46_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern IntPtr SendMessage_20(IntPtr intptr_0, int int_2, int int_3, ref Struct47 struct47_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_21(IntPtr intptr_0, int int_2, int int_3, ref Struct49 struct49_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_22(IntPtr intptr_0, int int_2, int int_3, ref Struct59 struct59_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_23(IntPtr intptr_0, int int_2, int int_3, ref Struct60 struct60_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_24(IntPtr intptr_0, int int_2, int int_3, ref Struct56 struct56_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_25(IntPtr intptr_0, int int_2, int int_3, ref Struct57 struct57_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_26(IntPtr intptr_0, int int_2, int int_3, ref Struct58 struct58_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_27(IntPtr intptr_0, int int_2, int int_3, ref Struct55 struct55_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_28(IntPtr intptr_0, int int_2, int int_3, ref Struct69 struct69_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_29(IntPtr intptr_0, int int_2, IntPtr intptr_1, ref Struct69 struct69_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern IntPtr SendMessage_30(IntPtr intptr_0, int int_2, uint uint_0, int int_3);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern IntPtr SendMessage_31(IntPtr intptr_0, int int_2, uint uint_0, int[] int_3);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern IntPtr SendMessage_32(IntPtr intptr_0, int int_2, uint uint_0, IntPtr intptr_1);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern IntPtr SendMessage_33(IntPtr intptr_0, int int_2, int int_3, ref Struct72 struct72_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_34(IntPtr intptr_0, int int_2, IntPtr intptr_1, ref Struct72 struct72_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_35(IntPtr intptr_0, int int_2, int int_3, ref Struct51 struct51_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_36(IntPtr intptr_0, int int_2, int int_3, ref Struct52 struct52_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_37(IntPtr intptr_0, int int_2, int int_3, ref Struct73 struct73_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_38(IntPtr intptr_0, int int_2, IntPtr intptr_1, ref Struct71 struct71_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_39(IntPtr intptr_0, int int_2, int int_3, ref Struct44 struct44_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_40(IntPtr intptr_0, int int_2, int int_3, TextControlCore.Delegate7 delegate7_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_41(IntPtr intptr_0, int int_2, int int_3, TextControlCore.Delegate8 delegate8_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_42(IntPtr intptr_0, int int_2, int int_3, TextControlCore.Delegate9 delegate9_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_43(IntPtr intptr_0, int int_2, int int_3, TextControlCore.Delegate10 delegate10_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_44(IntPtr intptr_0, int int_2, int int_3, TextControlCore.Delegate12 delegate12_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_45(IntPtr intptr_0, int int_2, int int_3, TextControlCore.Delegate11 delegate11_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_46(IntPtr intptr_0, int int_2, int int_3, Struct75[] struct75_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_47(IntPtr intptr_0, int int_2, int int_3, out Struct75 struct75_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_48(IntPtr intptr_0, Enum121 enum121_0, int int_2, ref Struct85 struct85_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_49(IntPtr intptr_0, int int_2, int int_3, ref Struct70 struct70_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_50(IntPtr intptr_0, int int_2, int int_3, ref Struct64 struct64_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_51(IntPtr intptr_0, int int_2, int int_3, ref Struct79 struct79_0);

		[DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SendMessage")]
		internal static extern int SendMessage_52(IntPtr intptr_0, int int_2, int int_3, ref Struct78 struct78_0);

		[DllImport("dwmapi.dll")]
		internal static extern int DwmExtendFrameIntoClientArea(IntPtr intptr_0, ref Struct89 struct89_0);

		[DllImport("dwmapi.dll")]
		internal static extern bool DwmDefWindowProc(IntPtr intptr_0, int int_2, IntPtr intptr_1, IntPtr intptr_2, ref IntPtr intptr_3);

		[DllImport("dwmapi.dll")]
		internal static extern int DwmIsCompositionEnabled(ref int int_2);

		[DllImport("gdi32.dll")]
		internal static extern IntPtr CreateDIBSection(IntPtr intptr_0, ref Struct91 struct91_0, uint uint_0, IntPtr intptr_1, IntPtr intptr_2, uint uint_1);

		[DllImport("gdi32.dll")]
		internal static extern IntPtr SelectObject(IntPtr intptr_0, IntPtr intptr_1);

		[DllImport("gdi32.dll")]
		internal static extern IntPtr CreateCompatibleDC(IntPtr intptr_0);

		[DllImport("gdi32.dll")]
		internal static extern bool DeleteDC(IntPtr intptr_0);

		[DllImport("user32.dll")]
		internal static extern IntPtr GetDCEx(IntPtr intptr_0, IntPtr intptr_1, uint uint_0);

		[DllImport("user32.dll")]
		internal static extern bool ReleaseDC(IntPtr intptr_0, IntPtr intptr_1);

		[DllImport("gdi32.dll")]
		internal static extern bool BitBlt(IntPtr intptr_0, int int_2, int int_3, int int_4, int int_5, IntPtr intptr_1, int int_6, int int_7, uint uint_0);

		[DllImport("user32.dll")]
		private static extern int FillRect(IntPtr intptr_0, [In] ref Struct83 struct83_0, IntPtr intptr_1);

		[DllImport("gdi32.dll")]
		private static extern IntPtr GetStockObject(int int_2);

		[DllImport("gdi32.dll")]
		public static extern IntPtr CreateSolidBrush(int int_2);

		[DllImport("gdi32.dll")]
		private static extern bool Rectangle(IntPtr intptr_0, int int_2, int int_3, int int_4, int int_5);

		[DllImport("gdi32.dll")]
		private static extern IntPtr CreatePen(int int_2, int int_3, int int_4);

		[DllImport("gdi32.dll")]
		private static extern bool MoveToEx(IntPtr intptr_0, int int_2, int int_3, IntPtr intptr_1);

		[DllImport("gdi32.dll")]
		private static extern bool LineTo(IntPtr intptr_0, int int_2, int int_3);

		[DllImport("user32.dll")]
		internal static extern bool AdjustWindowRectExForDpi(ref Struct83 struct83_0, uint uint_0, bool bool_0, uint uint_1, uint uint_2);

		internal static bool smethod_13(IntPtr intptr_0, ref Struct83 struct83_0, bool bool_0, uint uint_0)
		{
			uint uint_ = (uint)Class429.smethod_11(intptr_0, -16).ToInt32();
			uint uint_2 = (uint)Class429.smethod_11(intptr_0, -20).ToInt32();
			return Class429.smethod_14(ref struct83_0, uint_, bool_0, uint_2, uint_0);
		}

		internal static bool smethod_14(ref Struct83 struct83_0, uint uint_0, bool bool_0, uint uint_1, uint uint_2)
		{
			if (uint_2 != 0)
			{
				try
				{
					return Class429.AdjustWindowRectExForDpi(ref struct83_0, uint_0, bool_0, uint_1, uint_2);
				}
				catch
				{
				}
			}
			return Class429.AdjustWindowRectEx(ref struct83_0, uint_0, bool_0, uint_1);
		}

		[DllImport("user32.dll")]
		internal static extern uint GetDpiForWindow(IntPtr intptr_0);

		internal static uint smethod_15(IntPtr intptr_0)
		{
			uint result = 0u;
			try
			{
				result = Class429.GetDpiForWindow(intptr_0);
				return result;
			}
			catch
			{
				return result;
			}
		}

		[DllImport("user32.dll", CharSet = CharSet.Auto)]
		public static extern bool SystemParametersInfoForDpi(int int_2, int int_3, ref Struct95 struct95_0, int int_4, uint uint_0);

		[DllImport("user32.dll")]
		internal static extern int GetSystemMetricsForDpi(int int_2, uint uint_0);

		internal static void smethod_16(Graphics graphics_0, Rectangle rectangle_0, Color color_0)
		{
			IntPtr hdc = graphics_0.GetHdc();
			IntPtr intPtr = Class429.CreateSolidBrush(Class429.smethod_0(color_0));
			Struct83 struct83_ = new Struct83(rectangle_0);
			Class429.FillRect(hdc, ref struct83_, intPtr);
			Class429.DeleteObject(intPtr);
			graphics_0.ReleaseHdc(hdc);
		}

		internal static void smethod_17(Graphics graphics_0, Rectangle rectangle_0, Color color_0)
		{
			IntPtr hdc = graphics_0.GetHdc();
			IntPtr intptr_ = Class429.SelectObject(hdc, Class429.GetStockObject(5));
			IntPtr intptr_2 = Class429.CreatePen(0, 0, Class429.smethod_0(color_0));
			IntPtr intptr_3 = Class429.SelectObject(hdc, intptr_2);
			Class429.Rectangle(hdc, rectangle_0.Left, rectangle_0.Top, rectangle_0.Right, rectangle_0.Bottom);
			Class429.DeleteObject(Class429.SelectObject(hdc, intptr_3));
			Class429.SelectObject(hdc, intptr_);
			graphics_0.ReleaseHdc(hdc);
		}

		internal static void smethod_18(Graphics graphics_0, int int_2, int int_3, int int_4, int int_5, Color color_0)
		{
			IntPtr hdc = graphics_0.GetHdc();
			IntPtr intptr_ = Class429.CreatePen(0, 0, Class429.smethod_0(color_0));
			IntPtr intptr_2 = Class429.SelectObject(hdc, intptr_);
			Class429.MoveToEx(hdc, int_2, int_3, IntPtr.Zero);
			Class429.LineTo(hdc, int_4, int_5);
			Class429.DeleteObject(Class429.SelectObject(hdc, intptr_2));
			graphics_0.ReleaseHdc(hdc);
		}
	}
}
