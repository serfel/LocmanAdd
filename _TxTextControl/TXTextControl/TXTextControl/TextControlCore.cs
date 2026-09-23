using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Threading;
using ns20;
using ns21;

namespace TXTextControl
{
	[Obfuscation(Exclude = true)]
	internal class TextControlCore
	{
		internal delegate bool Delegate7(IntPtr intptr_0);

		internal delegate bool Delegate8(int int_0, IntPtr intptr_0);

		internal delegate bool Delegate9(IntPtr intptr_0, IntPtr intptr_1, IntPtr intptr_2);

		internal delegate IntPtr Delegate10(IntPtr intptr_0, ushort ushort_0);

		internal delegate ushort Delegate11(IntPtr intptr_0, ushort ushort_0, ushort ushort_1, IntPtr intptr_1, bool bool_0, ushort ushort_2);

		internal delegate IntPtr Delegate12(IntPtr intptr_0, IntPtr intptr_1);

		internal const string string_0 = "Standard";

		internal const string string_1 = "Display";

		internal static readonly string[] string_2 = new string[6] { "SOFTWARE\\Microsoft\\.NETFramework\\v4.0.30319\\AssemblyFoldersEx\\", "SOFTWARE\\Microsoft\\.NETFramework\\v4.5\\AssemblyFoldersEx\\", "SOFTWARE\\Microsoft\\.NETFramework\\v2.0.50727\\AssemblyFoldersEx\\", "SOFTWARE\\Microsoft\\.NETFramework\\v3.0\\AssemblyFoldersEx\\", "SOFTWARE\\Microsoft\\.NETFramework\\v3.5\\AssemblyFoldersEx\\", "SOFTWARE\\Microsoft\\.NETFramework\\AssemblyFolders\\" };

		private ResourceManager resourceManager_0;

		private IntPtr intptr = IntPtr.Zero;

		private bool bool_0;

		private object textControl;

		private Delegate8 delegate8_0;

		internal Class408 class408_0;

		internal Control6 control6_0;

		internal Control5 control5_0;

		internal Control4 control4_0;

		private MeasuringUnit measuringUnit_0 = MeasuringUnit.Twips;

		private Enum57 enum57_0;

		internal Enum56 enum56_0 = Enum56.const_8;

		private int int_0;

		internal bool isHandleCreated => this.intptr != IntPtr.Zero;

		internal IntPtr IntPtr_0
		{
			get
			{
				return this.intptr;
			}
			set
			{
				this.intptr = value;
				if (this.intptr != IntPtr.Zero)
				{
					this.delegate8_0 = null;
					int int_;
					switch (Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName)
					{
					case "de":
						int_ = 49;
						break;
					case "en":
						int_ = 1;
						break;
					default:
						int_ = 20000;
						this.delegate8_0 = method_82;
						break;
					}
					this.method_74(Enum83.const_176, int_, this.delegate8_0);
				}
			}
		}

		internal bool Boolean_1
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}

		internal bool Boolean_2
		{
			get
			{
				bool result = false;
				if (this.intptr != IntPtr.Zero)
				{
					Class429.Enum123 @enum = (Class429.Enum123)Class429.smethod_11(this.intptr, -20).ToInt32();
					if ((@enum & Class429.Enum123.const_7) != 0)
					{
						result = true;
					}
				}
				return result;
			}
		}

		internal MeasuringUnit MeasuringUnit_0
		{
			get
			{
				return this.measuringUnit_0;
			}
			set
			{
				this.measuringUnit_0 = value;
			}
		}

		internal Enum57 Enum57_0
		{
			get
			{
				if (this.isHandleCreated)
				{
					int[] array = new int[1];
					int[] array2 = array;
					this.method_41(Enum83.const_25, 0, array2);
					this.enum57_0 = ((((uint)array2[0] & 0x20u) != 0) ? Enum57.const_1 : Enum57.const_0);
				}
				return this.enum57_0;
			}
			set
			{
				if (this.enum57_0 != value)
				{
					this.enum57_0 = value;
					if (this.isHandleCreated)
					{
						this.method_30(Enum83.const_40, 0, (this.enum57_0 == Enum57.const_1) ? 32 : 2048);
					}
				}
			}
		}

		internal TextControlCore(ResourceManager resourceManager_1, object objTX, MeasuringUnit iPageUnit)
		{
			this.resourceManager_0 = resourceManager_1;
			this.textControl = objTX;
			this.measuringUnit_0 = iPageUnit;
			this.control6_0 = new Control6(this);
			this.control5_0 = new Control5(this);
			this.control4_0 = new Control4(this);
		}

		internal ITextControl GetTextControl()
		{
			return this.textControl as ITextControl;
		}

		internal ResourceManager method_1()
		{
			return this.resourceManager_0;
		}

		internal void method_2(Enum56 enum56_1, bool bool_1)
		{
			if (bool_1)
			{
				this.enum56_0 |= enum56_1;
			}
			else
			{
				this.enum56_0 &= ~enum56_1;
			}
		}

		internal void method_3(string[] string_3)
		{
			if (string_3 != null && string_3.Length != 0)
			{
				IntPtr intPtr = IntPtr.Zero;
				try
				{
					char[] array = KernelHelper.StringArray2CharArray(string_3);
					intPtr = Marshal.AllocHGlobal(array.Length * 2);
					Marshal.Copy(array, 0, intPtr, array.Length);
					this.method_38(TextPart.Auto, 1994, string_3.Length, intPtr);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					Marshal.FreeHGlobal(intPtr);
				}
			}
			else
			{
				this.method_29(TextPart.Auto, 1994, 0, 0);
			}
		}

		internal void method_4(DialogUnit dialogUnit_0)
		{
			if (dialogUnit_0 == DialogUnit.Auto)
			{
				bool flag = true;
				try
				{
					RegionInfo regionInfo = new RegionInfo(Thread.CurrentThread.CurrentCulture.LCID);
					flag = regionInfo.IsMetric;
				}
				catch
				{
				}
				dialogUnit_0 = (flag ? DialogUnit.Millimeter : DialogUnit.Inch);
			}
			this.method_29(TextPart.Auto, 2141, (int)dialogUnit_0, 0);
		}

		internal void method_5(TextPart textPart_0, int int_1, int int_2)
		{
			if (this.isHandleCreated)
			{
				int[] int_3 = new int[2]
				{
					int_1 + int_2,
					int_1
				};
				this.method_40(textPart_0, 1158, 1, int_3);
			}
		}

		internal void method_6(TextPart textPart_0, int int_1, int int_2)
		{
			if (this.isHandleCreated)
			{
				int[] int_3 = new int[2]
				{
					int_1,
					int_1 + int_2
				};
				this.method_40(textPart_0, 1158, 1, int_3);
			}
		}

		internal void method_7(TextPart textPart_0, out int int_1, out int int_2)
		{
			int[] array = new int[2];
			int[] array2 = array;
			this.method_40(textPart_0, 1132, 0, array2);
			int_1 = Math.Min(array2[0], array2[1]);
			int_2 = Math.Max(array2[0], array2[1]) - int_1;
		}

		internal void method_8()
		{
			int[] array = new int[3] { -1, 0, 0 };
			this.method_40(TextPart.Auto, 1989, 0, array);
			if (array[1] != array[2])
			{
				this.method_5(TextPart.Auto, array[1], array[2] - array[1]);
			}
		}

		internal void method_9(TextPart textPart_0)
		{
			ITextControl textControl = this.GetTextControl();
			this.method_37(textPart_0, 1644, textControl.GetFontSize() | 0x8000, textControl.GetFontName());
			int num = 0;
			switch (textControl.GetFontUnderlineStyle())
			{
			case FontUnderlineStyle.Doubled:
				num = 4672;
				break;
			case FontUnderlineStyle.DoubledWordsOnly:
				num = 4288;
				break;
			case FontUnderlineStyle.None:
				num = 20992;
				break;
			case FontUnderlineStyle.Single:
				num = 16912;
				break;
			case FontUnderlineStyle.SingleWordsOnly:
				num = 16528;
				break;
			}
			this.method_29(textPart_0, 1154, (textControl.GetFontBold() ? 4 : 1024) | (textControl.GetFontItalic() ? 8 : 2048) | num | (textControl.GetFontStrikeout() ? 32 : 8192), 0);
		}

		internal void method_10(bool bool_1)
		{
			if (bool_1)
			{
				this.int_0++;
				if (this.int_0 == 1)
				{
					this.method_30(Enum83.const_30, 128, 0);
				}
			}
			else
			{
				this.int_0--;
				if (this.int_0 == 0)
				{
					this.method_30(Enum83.const_30, 256, 0);
				}
			}
		}

		internal void method_11()
		{
			Class429.SendMessage_1(this.IntPtr_0, 1157, 256, 0);
			this.int_0 = 0;
		}

		internal void method_12(TextPart textPart_0)
		{
			int[] int_ = new int[2] { 0, -1 };
			if (this.method_40(textPart_0, 1955, 0, int_) != 0)
			{
				this.method_10(bool_1: true);
			}
		}

		internal bool method_13(TextPart textPart_0, Enum57 enum57_1)
		{
			if (enum57_1 != 0 && this.method_29(textPart_0, 1955, (int)enum57_1, 0) != 0)
			{
				this.method_10(bool_1: true);
				return true;
			}
			return false;
		}

		internal void method_14(TextPart textPart_0, int int_1, int int_2)
		{
			int[] int_3 = new int[2]
			{
				int_1 + int_2,
				int_1
			};
			if (this.method_40(textPart_0, 1955, 0, int_3) != 0)
			{
				this.method_10(bool_1: true);
			}
		}

		internal void method_15(TextPart textPart_0)
		{
			this.method_29(textPart_0, 1956, 0, 0);
			this.method_10(bool_1: false);
		}

		internal void method_16(TextPart textPart_0, int int_1, int int_2)
		{
			int[] int_3 = new int[2]
			{
				int_1 + int_2,
				int_1
			};
			this.method_40(textPart_0, 1955, 0, int_3);
		}

		internal void method_17(TextPart textPart_0)
		{
			this.method_29(textPart_0, 1956, 0, 0);
		}

		internal void method_18(TextPart textPart_0)
		{
			int[] array = new int[2];
			int[] array2 = array;
			this.method_40(textPart_0, 1132, 0, array2);
			if (array2[0] != array2[1])
			{
				array2[1] = array2[0];
				this.method_40(textPart_0, 1158, 1, array2);
			}
		}

		internal void method_19(TextPart textPart_0, string string_3)
		{
			this.method_37(textPart_0, 1874, 1, (string_3 == null || string_3 == string.Empty) ? null : string_3);
		}

		internal void method_20(TextPart textPart_0)
		{
			this.method_29(textPart_0, 1874, 2, 0);
		}

		internal void method_21(TextPart textPart_0)
		{
			this.method_29(textPart_0, 1874, 4, 0);
		}

		internal void method_22(TextPart textPart_0)
		{
			this.method_29(textPart_0, 1874, 8, 0);
		}

		internal void method_23(bool bool_1)
		{
			this.method_30(Enum83.const_40, 0, bool_1 ? 2 : 16384);
		}

		private void method_24(TextPart textPart_0)
		{
			if (textPart_0 != 0)
			{
				if (Class429.smethod_5((int)textPart_0) == 0)
				{
					Class429.SendMessage_1(this.IntPtr_0, 1878, 0, Class429.smethod_6((int)textPart_0));
				}
				else if (textPart_0 == TextPart.MainText)
				{
					Class429.SendMessage_1(this.IntPtr_0, 1878, 0, -1);
				}
				else
				{
					Class429.SendMessage_1(this.IntPtr_0, 1286, Class429.smethod_6((int)textPart_0), Class429.smethod_5((int)textPart_0));
				}
			}
		}

		private void method_25(TextPart textPart_0)
		{
			if (textPart_0 != 0)
			{
				if (Class429.smethod_5((int)textPart_0) != 0 && textPart_0 != TextPart.MainText)
				{
					Class429.SendMessage_1(this.IntPtr_0, 1286, 0, 0);
				}
				else
				{
					Class429.SendMessage_1(this.IntPtr_0, 1878, 0, 0);
				}
			}
		}

		internal string method_26()
		{
			IntPtr intPtr = Marshal.AllocHGlobal(512);
			Enum95 @enum = (Enum95)this.method_38(TextPart.Auto, 1631, 256, intPtr);
			string str = Marshal.PtrToStringUni(intPtr, 256);
			Marshal.FreeHGlobal(intPtr);
			return @enum switch
			{
				Enum95.const_0 => "Display", 
				Enum95.const_1 => "Standard", 
				Enum95.const_2 => KernelHelper.GetString(str), 
				_ => string.Empty, 
			};
		}

		internal void method_27(string string_3)
		{
			Enum95 int_;
			string string_4;
			if (string_3 == "Standard")
			{
				int_ = Enum95.const_1;
				string_4 = null;
			}
			else if (string_3 == "Display")
			{
				int_ = Enum95.const_0;
				string_4 = null;
			}
			else
			{
				int_ = Enum95.const_2;
				string_4 = string_3;
			}
			this.method_39(Enum83.const_168, (int)int_, string_4);
		}

		public string[] GetSupportedFonts()
		{
			string[] result = null;
			if (this.isHandleCreated)
			{
				IntPtr intPtr = this.method_64(TextPart.Auto, Enum83.const_162, 0u, 0);
				IntPtr intPtr2 = Class429.GlobalLock(intPtr);
				try
				{
					if (intPtr2 != IntPtr.Zero)
					{
						return KernelHelper.Ptr2StringArray(intPtr2);
					}
					return result;
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					if (intPtr2 != IntPtr.Zero)
					{
						Class429.GlobalUnlock(intPtr);
					}
					if (intPtr != IntPtr.Zero)
					{
						Marshal.FreeHGlobal(intPtr);
					}
				}
			}
			return result;
		}

		public PaperSize[] GetSupportedPaperSizes()
		{
			PaperSize[] result = null;
			if (this.isHandleCreated)
			{
				IntPtr intPtr = this.method_66(Enum83.const_317, 0u, 0);
				try
				{
					if (intPtr != IntPtr.Zero)
					{
						return KernelHelper.Ptr2PaperSizeArray(intPtr);
					}
					return result;
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					if (intPtr != IntPtr.Zero)
					{
						Class429.GlobalFree(intPtr);
					}
				}
			}
			return result;
		}

		internal bool method_28(string string_3, string string_4)
		{
			bool result = false;
			try
			{
				Assembly assembly = this.class408_0.method_2("txpdf", "29.0.1600.500");
				Type type = assembly.GetType("TXTextControl.TXFilter");
				Type[] types = new Type[2]
				{
					typeof(string),
					typeof(string)
				};
				object[] parameters = new object[2] { string_3, string_4 };
				result = (bool)type.GetMethod("VerifyPassword", types).Invoke(null, parameters);
				return result;
			}
			catch
			{
				return result;
			}
		}

		internal int method_29(TextPart textPart_0, int int_1, int int_2, int int_3)
		{
			this.method_24(textPart_0);
			int result = Class429.SendMessage_1(this.IntPtr_0, int_1, int_2, int_3);
			this.method_25(textPart_0);
			this.method_84();
			return result;
		}

		internal int method_30(Enum83 enum83_0, int int_1, int int_2)
		{
			int result = Class429.SendMessage_1(this.IntPtr_0, (int)enum83_0, int_1, int_2);
			this.method_84();
			return result;
		}

		internal int method_31(Enum83 enum83_0, IntPtr intptr_1, int int_1)
		{
			int result = Class429.SendMessage_2(this.IntPtr_0, (int)enum83_0, intptr_1, int_1);
			this.method_84();
			return result;
		}

		internal int method_32(Enum83 enum83_0, int int_1, ref Class429.Struct83 struct83_0)
		{
			int result = Class429.SendMessage_3(this.IntPtr_0, (int)enum83_0, int_1, ref struct83_0);
			this.method_84();
			return result;
		}

		internal int method_33(TextPart textPart_0, Enum83 enum83_0, int int_1, ref Class429.Struct83 struct83_0)
		{
			this.method_24(textPart_0);
			int result = Class429.SendMessage_3(this.IntPtr_0, (int)enum83_0, int_1, ref struct83_0);
			this.method_25(textPart_0);
			this.method_84();
			return result;
		}

		internal int method_34(Enum83 enum83_0, IntPtr intptr_1, ref Class429.Struct83 struct83_0)
		{
			int result = Class429.SendMessage_4(this.IntPtr_0, (int)enum83_0, intptr_1, ref struct83_0);
			this.method_84();
			return result;
		}

		internal int method_35(TextPart textPart_0, Enum83 enum83_0, int int_1, ref Class429.Struct82 struct82_0)
		{
			this.method_24(textPart_0);
			int result = Class429.SendMessage_5(this.IntPtr_0, (int)enum83_0, int_1, ref struct82_0);
			this.method_25(textPart_0);
			this.method_84();
			return result;
		}

		internal int method_36(Enum83 enum83_0, int int_1, ref Class429.Struct82 struct82_0)
		{
			int result = Class429.SendMessage_5(this.IntPtr_0, (int)enum83_0, int_1, ref struct82_0);
			this.method_84();
			return result;
		}

		internal int method_37(TextPart textPart_0, int int_1, int int_2, string string_3)
		{
			this.method_24(textPart_0);
			IntPtr intPtr = Marshal.StringToBSTR(string_3);
			int result = Class429.SendMessage_6(this.IntPtr_0, int_1, int_2, intPtr).ToInt32();
			Marshal.FreeBSTR(intPtr);
			this.method_25(textPart_0);
			this.method_84();
			return result;
		}

		internal int method_38(TextPart textPart_0, int int_1, int int_2, IntPtr intptr_1)
		{
			this.method_24(textPart_0);
			int result = Class429.SendMessage_6(this.IntPtr_0, int_1, int_2, intptr_1).ToInt32();
			this.method_25(textPart_0);
			this.method_84();
			return result;
		}

		internal IntPtr method_39(Enum83 enum83_0, int int_1, string string_3)
		{
			IntPtr intPtr = Marshal.StringToBSTR(string_3);
			IntPtr result = Class429.SendMessage_6(this.IntPtr_0, (int)enum83_0, int_1, intPtr);
			Marshal.FreeBSTR(intPtr);
			this.method_84();
			return result;
		}

		internal int method_40(TextPart textPart_0, int int_1, int int_2, int[] int_3)
		{
			this.method_24(textPart_0);
			int result = Class429.SendMessage_7(this.IntPtr_0, int_1, int_2, int_3);
			this.method_25(textPart_0);
			this.method_84();
			return result;
		}

		internal int method_41(Enum83 enum83_0, int int_1, int[] int_2)
		{
			int result = Class429.SendMessage_7(this.IntPtr_0, (int)enum83_0, int_1, int_2);
			this.method_84();
			return result;
		}

		internal int method_42(TextPart textPart_0, int int_1, int int_2, byte[] byte_0)
		{
			this.method_24(textPart_0);
			int result = Class429.SendMessage_8(this.IntPtr_0, int_1, int_2, byte_0);
			this.method_25(textPart_0);
			this.method_84();
			return result;
		}

		internal int method_43(TextPart textPart_0, int int_1, int int_2, short[] short_0)
		{
			this.method_24(textPart_0);
			int result = Class429.SendMessage_9(this.IntPtr_0, int_1, int_2, short_0);
			this.method_25(textPart_0);
			this.method_84();
			return result;
		}

		internal int method_44(TextPart textPart_0, int int_1, int int_2, TabType[] tabType_0)
		{
			this.method_24(textPart_0);
			int result = Class429.SendMessage_10(this.IntPtr_0, int_1, int_2, tabType_0);
			this.method_25(textPart_0);
			this.method_84();
			return result;
		}

		internal int method_45(TextPart textPart_0, int int_1, int int_2, TabLeader[] tabLeader_0)
		{
			this.method_24(textPart_0);
			int result = Class429.SendMessage_11(this.IntPtr_0, int_1, int_2, tabLeader_0);
			this.method_25(textPart_0);
			this.method_84();
			return result;
		}

		internal int method_46(TextPart textPart_0, int int_1, int int_2, ref Struct53 struct53_0)
		{
			this.method_24(textPart_0);
			int result = Class429.SendMessage_12(this.IntPtr_0, int_1, int_2, ref struct53_0);
			this.method_25(textPart_0);
			this.method_84();
			return result;
		}

		internal int method_47(TextPart textPart_0, int int_1, int int_2, ref Struct61 struct61_0)
		{
			this.method_24(textPart_0);
			int result = Class429.SendMessage_13(this.IntPtr_0, int_1, int_2, ref struct61_0);
			this.method_25(textPart_0);
			this.method_84();
			return result;
		}

		internal int method_48(Enum83 enum83_0, int int_1, ref Struct48 struct48_0)
		{
			int result = Class429.SendMessage_14(this.IntPtr_0, (int)enum83_0, int_1, ref struct48_0);
			this.method_84();
			return result;
		}

		internal int method_49(Enum83 enum83_0, int int_1, ref Struct50 struct50_0)
		{
			int result = Class429.SendMessage_17(this.IntPtr_0, (int)enum83_0, int_1, ref struct50_0);
			this.method_84();
			return result;
		}

		internal int method_50(Enum83 enum83_0, int int_1, ref Struct45 struct45_0)
		{
			int result = Class429.SendMessage_18(this.IntPtr_0, (int)enum83_0, int_1, ref struct45_0);
			this.method_84();
			return result;
		}

		internal int method_51(Enum83 enum83_0, int int_1, ref Struct49 struct49_0)
		{
			int result = Class429.SendMessage_21(this.IntPtr_0, (int)enum83_0, int_1, ref struct49_0);
			this.method_84();
			return result;
		}

		internal int method_52(Enum83 enum83_0, int int_1, ref Struct76 struct76_0)
		{
			int result = Class429.SendMessage_15(this.IntPtr_0, (int)enum83_0, int_1, ref struct76_0);
			this.method_84();
			return result;
		}

		internal int method_53(TextPart textPart_0, Enum83 enum83_0, int int_1, ref Struct59 struct59_0)
		{
			this.method_24(textPart_0);
			int result = Class429.SendMessage_22(this.IntPtr_0, (int)enum83_0, int_1, ref struct59_0);
			this.method_25(textPart_0);
			this.method_84();
			return result;
		}

		internal int method_54(TextPart textPart_0, Enum83 enum83_0, int int_1, ref Struct60 struct60_0)
		{
			this.method_24(textPart_0);
			int result = Class429.SendMessage_23(this.IntPtr_0, (int)enum83_0, int_1, ref struct60_0);
			this.method_25(textPart_0);
			this.method_84();
			return result;
		}

		internal int method_55(TextPart textPart_0, Enum83 enum83_0, int int_1, ref Struct56 struct56_0)
		{
			this.method_24(textPart_0);
			int result = Class429.SendMessage_24(this.IntPtr_0, (int)enum83_0, int_1, ref struct56_0);
			this.method_25(textPart_0);
			this.method_84();
			return result;
		}

		internal int method_56(TextPart textPart_0, Enum83 enum83_0, int int_1, ref Struct57 struct57_0)
		{
			this.method_24(textPart_0);
			int result = Class429.SendMessage_25(this.IntPtr_0, (int)enum83_0, int_1, ref struct57_0);
			this.method_25(textPart_0);
			this.method_84();
			return result;
		}

		internal int method_57(TextPart textPart_0, Enum83 enum83_0, int int_1, ref Struct58 struct58_0)
		{
			this.method_24(textPart_0);
			int result = Class429.SendMessage_26(this.IntPtr_0, (int)enum83_0, int_1, ref struct58_0);
			this.method_25(textPart_0);
			this.method_84();
			return result;
		}

		internal IntPtr method_58(TextPart textPart_0, Enum83 enum83_0, int int_1, ref Struct46 struct46_0)
		{
			this.method_24(textPart_0);
			IntPtr result = Class429.SendMessage_19(this.IntPtr_0, (int)enum83_0, int_1, ref struct46_0);
			this.method_25(textPart_0);
			this.method_84();
			return result;
		}

		internal IntPtr method_59(TextPart textPart_0, Enum83 enum83_0, int int_1, ref Struct47 struct47_0)
		{
			this.method_24(textPart_0);
			IntPtr result = Class429.SendMessage_20(this.IntPtr_0, (int)enum83_0, int_1, ref struct47_0);
			this.method_25(textPart_0);
			this.method_84();
			return result;
		}

		internal int method_60(TextPart textPart_0, Enum83 enum83_0, int int_1, ref Struct77 struct77_0)
		{
			this.method_24(textPart_0);
			int result = Class429.SendMessage_16(this.IntPtr_0, (int)enum83_0, int_1, ref struct77_0);
			this.method_25(textPart_0);
			this.method_84();
			return result;
		}

		internal int method_61(TextPart textPart_0, Enum83 enum83_0, int int_1, ref Struct55 struct55_0)
		{
			this.method_24(textPart_0);
			int result = Class429.SendMessage_27(this.IntPtr_0, (int)enum83_0, int_1, ref struct55_0);
			this.method_25(textPart_0);
			this.method_84();
			return result;
		}

		internal int method_62(TextPart textPart_0, Enum83 enum83_0, int int_1, ref Struct69 struct69_0)
		{
			this.method_24(textPart_0);
			int result = Class429.SendMessage_28(this.IntPtr_0, (int)enum83_0, int_1, ref struct69_0);
			this.method_25(textPart_0);
			this.method_84();
			return result;
		}

		internal int method_63(TextPart textPart_0, Enum83 enum83_0, IntPtr intptr_1, ref Struct69 struct69_0)
		{
			this.method_24(textPart_0);
			int result = Class429.SendMessage_29(this.IntPtr_0, (int)enum83_0, intptr_1, ref struct69_0);
			this.method_25(textPart_0);
			this.method_84();
			return result;
		}

		internal IntPtr method_64(TextPart textPart_0, Enum83 enum83_0, uint uint_0, int int_1)
		{
			this.method_24(textPart_0);
			IntPtr result = Class429.SendMessage_30(this.IntPtr_0, (int)enum83_0, uint_0, int_1);
			this.method_25(textPart_0);
			this.method_84();
			return result;
		}

		internal IntPtr method_65(TextPart textPart_0, Enum83 enum83_0, uint uint_0, int[] int_1)
		{
			this.method_24(textPart_0);
			IntPtr result = Class429.SendMessage_31(this.IntPtr_0, (int)enum83_0, uint_0, int_1);
			this.method_25(textPart_0);
			this.method_84();
			return result;
		}

		internal IntPtr method_66(Enum83 enum83_0, uint uint_0, int int_1)
		{
			IntPtr result = Class429.SendMessage_30(this.IntPtr_0, (int)enum83_0, uint_0, int_1);
			this.method_84();
			return result;
		}

		internal IntPtr method_67(Enum83 enum83_0, int int_1, ref Struct72 struct72_0)
		{
			IntPtr result = Class429.SendMessage_33(this.IntPtr_0, (int)enum83_0, int_1, ref struct72_0);
			this.method_84();
			return result;
		}

		internal int method_68(Enum83 enum83_0, string string_3, ref Struct72 struct72_0)
		{
			IntPtr intPtr = Marshal.StringToBSTR(string_3);
			int result = Class429.SendMessage_34(this.IntPtr_0, (int)enum83_0, intPtr, ref struct72_0);
			Marshal.FreeBSTR(intPtr);
			this.method_84();
			return result;
		}

		internal int method_69(TextPart textPart_0, Enum83 enum83_0, int int_1, ref Struct51 struct51_0)
		{
			this.method_24(textPart_0);
			int result = Class429.SendMessage_35(this.IntPtr_0, (int)enum83_0, int_1, ref struct51_0);
			this.method_25(textPart_0);
			this.method_84();
			return result;
		}

		internal int method_70(TextPart textPart_0, Enum83 enum83_0, int int_1, ref Struct52 struct52_0)
		{
			this.method_24(textPart_0);
			int result = Class429.SendMessage_36(this.IntPtr_0, (int)enum83_0, int_1, ref struct52_0);
			this.method_25(textPart_0);
			this.method_84();
			return result;
		}

		internal int method_71(Enum83 enum83_0, string string_3, ref Struct71 struct71_0)
		{
			IntPtr intPtr = Marshal.StringToBSTR(string_3);
			int result = Class429.SendMessage_38(this.IntPtr_0, (int)enum83_0, intPtr, ref struct71_0);
			Marshal.FreeBSTR(intPtr);
			this.method_84();
			return result;
		}

		internal int method_72(TextPart textPart_0, Enum83 enum83_0, int int_1, ref Struct44 struct44_0)
		{
			this.method_24(textPart_0);
			int result = Class429.SendMessage_39(this.IntPtr_0, (int)enum83_0, int_1, ref struct44_0);
			this.method_25(textPart_0);
			this.method_84();
			return result;
		}

		internal int method_73(Enum83 enum83_0, int int_1, Delegate7 delegate7_0)
		{
			int result = Class429.SendMessage_40(this.IntPtr_0, (int)enum83_0, int_1, delegate7_0);
			this.method_84();
			return result;
		}

		internal int method_74(Enum83 enum83_0, int int_1, Delegate8 delegate8_1)
		{
			int result = Class429.SendMessage_41(this.IntPtr_0, (int)enum83_0, int_1, delegate8_1);
			this.method_84();
			return result;
		}

		internal int method_75(Enum83 enum83_0, int int_1, Delegate9 delegate9_0)
		{
			int result = Class429.SendMessage_42(this.IntPtr_0, (int)enum83_0, int_1, delegate9_0);
			this.method_84();
			return result;
		}

		internal int method_76(Enum83 enum83_0, int int_1, Delegate10 delegate10_0)
		{
			int result = Class429.SendMessage_43(this.IntPtr_0, (int)enum83_0, int_1, delegate10_0);
			this.method_84();
			return result;
		}

		internal int method_77(Enum83 enum83_0, int int_1, Delegate12 delegate12_0)
		{
			int result = Class429.SendMessage_44(this.IntPtr_0, (int)enum83_0, int_1, delegate12_0);
			this.method_84();
			return result;
		}

		internal int method_78(Enum83 enum83_0, int int_1, Delegate11 delegate11_0)
		{
			int result = Class429.SendMessage_45(this.IntPtr_0, (int)enum83_0, int_1, delegate11_0);
			this.method_84();
			return result;
		}

		internal int method_79(Enum83 enum83_0, int int_1, ref Struct70 struct70_0)
		{
			int result = Class429.SendMessage_49(this.IntPtr_0, (int)enum83_0, int_1, ref struct70_0);
			this.method_84();
			return result;
		}

		internal int method_80(Enum83 enum83_0, ref Struct79 struct79_0)
		{
			int result = Class429.SendMessage_51(this.IntPtr_0, (int)enum83_0, 0, ref struct79_0);
			this.method_84();
			return result;
		}

		internal int method_81(Enum83 enum83_0, ref Struct78 struct78_0)
		{
			int result = Class429.SendMessage_52(this.IntPtr_0, (int)enum83_0, 0, ref struct78_0);
			this.method_84();
			return result;
		}

		private bool method_82(int int_1, IntPtr intptr_1)
		{
			bool result = false;
			TxString txString = (TxString)Class429.smethod_5(int_1);
			string @string = this.resourceManager_0.GetString(txString.ToString());
			if (@string != null)
			{
				int length = Math.Min(Class429.smethod_6(int_1) - 1, @string.Length);
				if (intptr_1 != IntPtr.Zero)
				{
					Marshal.Copy(@string.ToCharArray(), 0, intptr_1, length);
					result = true;
				}
			}
			return result;
		}

		internal string method_83(string string_3)
		{
			return this.resourceManager_0.GetString(string_3);
		}

		private void method_84()
		{
			//return;

			if (!this.bool_0)
			{
				return;
			}
			this.bool_0 = false;
			int num = this.class408_0.GetErrorCode();
			if (num == 0)
			{
				return;
			}
			this.method_11();
			Class429.SendMessage_1(this.IntPtr_0, 1323, 0, 0);
			Class429.SendMessage_1(this.IntPtr_0, 1874, 2, 0);
			ushort num2 = Class429.smethod_5(num);
			Enum113 @enum = (Enum113)Class429.smethod_9(Class429.smethod_6(num));
			Enum112 enum2 = (Enum112)Class429.smethod_10(Class429.smethod_6(num));
			if (@enum == Enum113.const_0 && Class429.smethod_10(num2) == 29)
			{
				throw new FilterException((FilterException.FilterError)Class429.smethod_9(num2));
			}
			string name = string.Empty;
			Enum112 enum3 = enum2;
			if (enum3 == Enum112.const_13)
			{
				switch (num2)
				{
				case 1:
					name = "ERR_NEEDSPROFLICENSE";
					break;
				case 2:
					name = "ERR_NEEDSENTERLICENSE";
					break;
				case 3:
					name = "ERR_NEEDSSERVERLICENSE";
					break;
				}
				throw new LicenseLevelException(this.resourceManager_0.GetString(name));
			}
			TxError txError = this.method_85(@enum, enum2, num2);
			name = this.resourceManager_0.GetString(txError.ToString()) + $"\n({@enum:X}-{num2:X4})";
			throw new TextEditorException(name);
		}

		private TxError method_85(Enum113 enum113_0, Enum112 enum112_0, ushort ushort_0)
		{
			TxError result = TxError.ERR_UNKNOWN;
			switch (enum112_0)
			{
			case Enum112.const_1:
			case Enum112.const_2:
				result = TxError.ERR_OUTOFMEMORY;
				break;
			case Enum112.const_3:
				result = TxError.ERR_INTERNAL;
				break;
			case Enum112.const_4:
				result = TxError.ERR_FILEIO;
				break;
			case Enum112.const_5:
				result = TxError.ERR_64K;
				break;
			case Enum112.const_6:
				result = TxError.ERR_CLIPBOARD;
				break;
			case Enum112.const_0:
			case Enum112.const_7:
			case Enum112.const_8:
			case Enum112.const_9:
			case Enum112.const_10:
				switch (enum113_0)
				{
				case Enum113.const_0:
					switch (enum112_0)
					{
					case Enum112.const_7:
						switch (ushort_0)
						{
						case 11270:
							result = TxError.ERR_TXOBJVERSION;
							break;
						case 6912:
							result = TxError.ERR_TXFLT_NOTAVAILABLE;
							break;
						case 2052:
							result = TxError.ERR_IC_NOTAVAILABLE;
							break;
						}
						break;
					case Enum112.const_8:
						switch (ushort_0)
						{
						case 2051:
							result = TxError.ERR_IC_INCOMPATIBLE;
							break;
						case 11272:
						case 11273:
						case 11275:
							result = TxError.ERR_TXOBJVERSION;
							break;
						case 6913:
						case 6916:
							result = TxError.ERR_TXFLT_INCOMPATIBLE;
							break;
						}
						break;
					case Enum112.const_9:
						switch (ushort_0)
						{
						case 11271:
							result = TxError.ERR_NOERROR;
							break;
						case 2050:
							result = TxError.ERR_NOERROR;
							break;
						}
						break;
					case Enum112.const_10:
						switch (ushort_0)
						{
						default:
							result = TxError.ERR_INVALIDPROPVAL;
							break;
						case 14349:
							result = TxError.ERR_LEFTRIGHTMARGIN;
							break;
						case 14350:
							result = TxError.ERR_TOPBOTTOMMARGIN;
							break;
						case 11267:
							result = TxError.ERR_OBJECTTOOLARGE;
							break;
						case 11268:
							result = TxError.ERR_OBJECTMODE;
							break;
						case 11269:
							result = TxError.ERR_OBJECTINVALID;
							break;
						case 9729:
						case 9730:
							result = TxError.ERR_TEXTAREATOOSMALL;
							break;
						}
						break;
					case Enum112.const_0:
						result = ushort_0 switch
						{
							3584 => TxError.ERR_CONTROLTOOSMALL, 
							1036 => TxError.ERR_OBJECTSAVE, 
							10240 => TxError.ERR_ZOOM, 
							5128 => TxError.ERR_DEVICE, 
							_ => TxError.ERR_INTERNAL, 
						};
						break;
					}
					break;
				case Enum113.const_2:
					switch (enum112_0)
					{
					case Enum112.const_7:
						result = TxError.ERR_ICFLT_NOTAVAILABLE;
						break;
					case Enum112.const_8:
						result = TxError.ERR_IMG_INTERFACE;
						break;
					case Enum112.const_10:
						result = TxError.ERR_INVALIDPROPVAL;
						break;
					}
					break;
				case Enum113.const_3:
					switch (ushort_0)
					{
					case 297:
					case 298:
					case 299:
						result = TxError.ERR_IMG_UNSUPPORTED;
						break;
					case 257:
						result = TxError.ERR_IMG_BADFILE;
						break;
					case 259:
					case 263:
					case 265:
						result = TxError.ERR_IMG_UNKNOWN;
						break;
					case 266:
						result = TxError.ERR_IMG_ABORT;
						break;
					case 258:
					case 269:
						result = TxError.ERR_IMG_SIZE;
						break;
					}
					break;
				case Enum113.const_4:
					switch (enum112_0)
					{
					case Enum112.const_10:
						result = TxError.ERR_INVALIDPROPVAL;
						break;
					}
					break;
				}
				break;
			case Enum112.const_11:
				result = TxError.ERR_INVALIDPROPVAL;
				break;
			case Enum112.const_12:
				result = TxError.ERR_INVALIDFORMAT;
				break;
			case Enum112.const_13:
				result = TxError.ERR_NOERROR;
				break;
			case Enum112.const_14:
				result = TxError.ERR_TOO_COMPLEX;
				break;
			}
			return result;
		}
	}
}
