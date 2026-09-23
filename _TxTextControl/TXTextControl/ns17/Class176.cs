using System;

namespace ns17
{
	internal class Class176
	{
		private byte byte_0 = byte.MaxValue;

		private byte byte_1;

		private byte byte_2;

		private byte byte_3;

		private string string_0;

		internal byte Byte_0
		{
			get
			{
				return this.byte_0;
			}
			set
			{
				this.byte_0 = value;
			}
		}

		internal byte Byte_1
		{
			get
			{
				return this.byte_1;
			}
			set
			{
				this.byte_1 = value;
			}
		}

		internal byte Byte_2
		{
			get
			{
				return this.byte_2;
			}
			set
			{
				this.byte_2 = value;
			}
		}

		internal byte Byte_3
		{
			get
			{
				return this.byte_3;
			}
			set
			{
				this.byte_3 = value;
			}
		}

		internal string String_0 => this.string_0;

		internal static Class176 smethod_0(byte byte_4, byte byte_5, byte byte_6)
		{
			Class176 @class = new Class176();
			@class.byte_0 = byte.MaxValue;
			@class.byte_3 = byte_4;
			@class.byte_2 = byte_5;
			@class.byte_1 = byte_6;
			return @class;
		}

		internal static Class176 smethod_1(byte byte_4, byte byte_5, byte byte_6, byte byte_7)
		{
			Class176 @class = new Class176();
			@class.byte_0 = byte_4;
			@class.byte_3 = byte_5;
			@class.byte_2 = byte_6;
			@class.byte_1 = byte_7;
			return @class;
		}

		internal static Class176 smethod_2(string string_1, byte byte_4, byte byte_5, byte byte_6, byte byte_7)
		{
			Class176 @class = new Class176();
			@class.string_0 = string_1;
			@class.byte_0 = byte_4;
			@class.byte_3 = byte_5;
			@class.byte_2 = byte_6;
			@class.byte_1 = byte_7;
			return @class;
		}

		internal static Class176 smethod_3(string string_1)
		{
			Class176 @class = new Class176();
			@class.string_0 = string_1;
			return @class;
		}

		internal int method_0()
		{
			byte[] value = new byte[4] { this.byte_0, this.byte_3, this.byte_2, this.byte_1 };
			return BitConverter.ToInt32(value, 0);
		}
	}
}
