using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	/// <summary>The FrameBase class is the base class of the Image, TextFrame, ChartFrame, BarcodeFrame and DrawingFrame classes.</summary>
	public class FrameBase
	{
		private enum Enum49
		{
			const_0 = 1,
			const_1 = 2,
			const_2 = 4,
			const_3 = 8,
			const_4 = 0x10,
			const_5 = 0x20,
			const_6 = 0x40,
			const_7 = 0x80,
			const_8 = 0x100,
			const_9 = 0x200,
			const_10 = 0x10000000,
			const_11 = 0x20000000,
			const_12 = 0x40000000,
			const_13 = 0x400,
			const_14 = 0x800,
			const_15 = 268963839,
			const_16 = 0x1000,
			const_17 = 0x2000,
			const_18 = 0x4000,
			const_19 = 0x8000,
			const_20 = 0x10000,
			const_21 = 0x20000,
			const_22 = 0x40000,
			const_23 = 0x80000,
			const_24 = 1879113727,
			const_25 = 1880032255,
			const_26 = 1879049215
		}

		private const int int_0 = 255;

		internal TextControlCore textControlCore_0;

		internal int int_1;

		internal TextPart textPart_0;

		private Enum107 enum107_0 = Enum107.const_0;

		private Enum49 enum49_0;

		private Enum49 enum49_1;

		internal MemoryStream memoryStream_0;

		internal UnmanagedMemoryStream unmanagedMemoryStream_0;

		private HorizontalAlignment horizontalAlignment_0 = HorizontalAlignment.Left;

		private int int_2;

		private FrameInsertionMode frameInsertionMode_0 = FrameInsertionMode.AsCharacter;

		private Point point_0 = new Point(0, 0);

		private string string_0 = string.Empty;

		private bool bool_0;

		private Size size_0 = new Size(0, 0);

		private bool bool_1;

		private int[] int_3 = new int[4];

		private int int_4;

		private int int_5;

		private string string_1 = string.Empty;

		private int int_6;

		private int int_7;

		private string string_2 = string.Empty;

		private int int_8;

		private int int_9 = 100;

		private ImageSaveMode imageSaveMode_0 = ImageSaveMode.SaveAsFileReference;

		private int int_10 = 100;

		private int[] int_11 = new int[4];

		private int int_12 = 15;

		private Color color_0 = SystemColors.Window;

		private byte byte_0;

		/// <summary>Gets or sets the frame's horizontal alignment when it is anchored to a paragraph.</summary>
		public HorizontalAlignment Alignment
		{
			get
			{
				this.method_3(Enum49.const_10);
				return this.horizontalAlignment_0;
			}
			set
			{
				if (value == HorizontalAlignment.Justify)
				{
					throw new ArgumentOutOfRangeException();
				}
				this.horizontalAlignment_0 = value;
				this.enum49_0 |= Enum49.const_10;
				this.method_4();
			}
		}

		/// <summary>Gets the frame's bounding rectangle relative to the upper left corner of the document.</summary>
		public Rectangle Bounds
		{
			get
			{
				if (this.int_1 == 0 || this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated)
				{
					throw new InvalidOperationException();
				}
				int[] array = new int[12];
				this.textControlCore_0.method_40(this.textPart_0, 1886, this.int_1, array);
				return new Rectangle(array[8], array[9], array[10] - array[8], array[11] - array[9]);
			}
		}

		[Browsable(false)]
		public int Int32_0
		{
			get
			{
				this.method_3(Enum49.const_12);
				return this.int_2;
			}
			set
			{
				this.int_2 = value;
				this.enum49_0 |= Enum49.const_12;
				this.method_4();
			}
		}

		/// <summary>Gets or sets a value determining whether the frame is treated as a single character or the document's text either flows around or overwrites the frame.</summary>
		[Browsable(false)]
		public FrameInsertionMode InsertionMode
		{
			get
			{
				this.method_3(Enum49.const_0);
				return this.frameInsertionMode_0;
			}
			set
			{
				if (value != FrameInsertionMode.AsCharacter && value != (FrameInsertionMode.DisplaceCompleteLines | FrameInsertionMode.MoveWithText) && value != (FrameInsertionMode.DisplaceText | FrameInsertionMode.MoveWithText) && value != (FrameInsertionMode.AboveTheText | FrameInsertionMode.MoveWithText) && value != (FrameInsertionMode.BelowTheText | FrameInsertionMode.MoveWithText) && value != (FrameInsertionMode.DisplaceCompleteLines | FrameInsertionMode.FixedOnPage) && value != (FrameInsertionMode.DisplaceText | FrameInsertionMode.FixedOnPage) && value != (FrameInsertionMode.AboveTheText | FrameInsertionMode.FixedOnPage) && value != (FrameInsertionMode.BelowTheText | FrameInsertionMode.FixedOnPage))
				{
					throw new ArgumentOutOfRangeException();
				}
				this.frameInsertionMode_0 = value;
				this.enum49_0 |= Enum49.const_0;
				this.method_4();
			}
		}

		/// <summary>Gets or sets, in twips, the frame's current location.</summary>
		[Browsable(false)]
		public Point Location
		{
			get
			{
				this.method_3(Enum49.const_5);
				return this.point_0;
			}
			set
			{
				this.point_0 = value;
				this.enum49_0 |= Enum49.const_5;
				this.method_4();
			}
		}

		/// <summary>Gets or sets a name for the frame.</summary>
		[Browsable(false)]
		public string Name
		{
			get
			{
				this.method_3(Enum49.const_11);
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
				this.enum49_0 |= Enum49.const_11;
				this.method_4();
			}
		}

		/// <summary>Determines whether a frame can be moved in the document at run time with the built-in mouse interface.</summary>
		[Browsable(false)]
		[DefaultValue(false)]
		public bool Moveable
		{
			get
			{
				this.method_3(Enum49.const_2);
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
				this.enum49_0 |= Enum49.const_2;
				this.method_4();
			}
		}

		/// <summary>Gets or sets the frame's size in twips.</summary>
		[Browsable(false)]
		public Size Size
		{
			get
			{
				this.method_3(Enum49.const_9);
				return this.size_0;
			}
			set
			{
				this.size_0 = value;
				this.enum49_0 |= Enum49.const_9;
				this.method_4();
			}
		}

		/// <summary>Determines whether the frame can be resized at run time with the built-in mouse interface.</summary>
		[Browsable(false)]
		[DefaultValue(false)]
		public bool Sizeable
		{
			get
			{
				this.method_3(Enum49.const_3);
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
				this.enum49_0 |= Enum49.const_3;
				this.method_4();
			}
		}

		/// <summary>Gets or sets the distances, in twips, between the frame and the document's text.</summary>
		[Browsable(false)]
		public int[] TextDistances
		{
			get
			{
				this.method_3(Enum49.const_1);
				return (int[])this.int_3.Clone();
			}
			set
			{
				if (value.Length != 4 && value.Rank != 1)
				{
					throw new ArgumentOutOfRangeException();
				}
				value.CopyTo(this.int_3, 0);
				this.enum49_0 |= Enum49.const_1;
				this.method_4();
			}
		}

		/// <summary>Read only. Gets the frame's character position in the document's text (one-based).</summary>
		[Browsable(false)]
		public int TextPosition
		{
			get
			{
				this.method_3(Enum49.const_4);
				return this.int_4;
			}
		}

		[Browsable(false)]
		internal int Int32_1
		{
			get
			{
				this.method_3(Enum49.const_19);
				return this.int_5;
			}
			set
			{
				this.int_5 = value;
				this.enum49_0 |= Enum49.const_19;
				this.method_4();
			}
		}

		[Browsable(false)]
		internal string String_0
		{
			get
			{
				this.method_3(Enum49.const_16);
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
				this.enum49_0 |= Enum49.const_16;
				this.method_4();
			}
		}

		[Browsable(false)]
		internal int Int32_2
		{
			get
			{
				this.method_3(Enum49.const_17);
				return this.int_6;
			}
			set
			{
				this.int_6 = value;
				this.enum49_0 |= Enum49.const_17;
				this.method_4();
			}
		}

		[Browsable(false)]
		internal int Int32_3
		{
			get
			{
				this.method_3(Enum49.const_18);
				return this.int_7;
			}
			set
			{
				this.int_7 = value;
				this.enum49_0 |= Enum49.const_18;
				this.method_4();
			}
		}

		[Browsable(false)]
		internal string String_1
		{
			get
			{
				this.method_3(Enum49.const_13);
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
				this.enum49_0 |= Enum49.const_13;
				this.method_4();
			}
		}

		[Browsable(false)]
		internal int Int32_4
		{
			get
			{
				this.method_3(Enum49.const_14);
				return this.int_8;
			}
			set
			{
				this.int_8 = value;
				this.enum49_0 |= Enum49.const_14;
				this.method_4();
			}
		}

		[DefaultValue(100)]
		[Browsable(false)]
		internal int Int32_5
		{
			get
			{
				this.method_3(Enum49.const_7);
				return this.int_9;
			}
			set
			{
				this.int_9 = value;
				this.enum49_0 |= Enum49.const_7;
				this.method_4();
			}
		}

		[Browsable(false)]
		internal ImageSaveMode ImageSaveMode_0
		{
			get
			{
				this.method_3(Enum49.const_6);
				return this.imageSaveMode_0;
			}
			set
			{
				this.imageSaveMode_0 = value;
				this.enum49_0 |= Enum49.const_6;
				this.method_4();
			}
		}

		[Browsable(false)]
		[DefaultValue(100)]
		internal int Int32_6
		{
			get
			{
				this.method_3(Enum49.const_8);
				return this.int_10;
			}
			set
			{
				this.int_10 = value;
				this.enum49_0 |= Enum49.const_8;
				this.method_4();
			}
		}

		[Browsable(false)]
		internal int[] Int32_7
		{
			get
			{
				this.method_3(Enum49.const_21);
				return (int[])this.int_11.Clone();
			}
			set
			{
				if (value.Length != 4 && value.Rank != 1)
				{
					throw new ArgumentOutOfRangeException();
				}
				value.CopyTo(this.int_11, 0);
				this.enum49_0 |= Enum49.const_21;
				this.method_4();
			}
		}

		[DefaultValue(15)]
		[Browsable(false)]
		internal int Int32_8
		{
			get
			{
				this.method_3(Enum49.const_20);
				return this.int_12;
			}
			set
			{
				this.int_12 = value;
				this.enum49_0 |= Enum49.const_20;
				this.method_4();
			}
		}

		[Browsable(false)]
		internal Color Color_0
		{
			get
			{
				this.method_3(Enum49.const_22);
				return this.color_0;
			}
			set
			{
				this.color_0 = value;
				this.enum49_0 |= Enum49.const_22;
				this.method_4();
			}
		}

		[Browsable(false)]
		[DefaultValue(0)]
		internal byte Byte_0
		{
			get
			{
				this.method_3(Enum49.const_23);
				return this.byte_0;
			}
			set
			{
				this.byte_0 = value;
				this.enum49_0 |= Enum49.const_23;
				this.method_4();
			}
		}

		internal FrameBase(Enum107 iType)
		{
			this.enum107_0 = iType;
		}

		internal FrameBase(Size size, Enum107 iType)
		{
			this.size_0 = size;
			this.enum49_0 |= Enum49.const_9;
			this.enum107_0 = iType;
		}

		internal FrameBase(string strFileName, int iFilterIndex, Enum107 iType)
		{
			this.string_2 = strFileName;
			this.enum49_0 |= Enum49.const_13;
			this.int_8 = iFilterIndex;
			this.enum49_0 |= Enum49.const_14;
			this.enum107_0 = iType;
		}

		internal FrameBase(MemoryStream stream, Enum107 iType)
		{
			this.memoryStream_0 = stream;
			this.int_8 = 0;
			this.enum49_0 |= Enum49.const_14;
			this.enum107_0 = iType;
		}

		internal FrameBase(UnmanagedMemoryStream stream, Enum107 iType)
		{
			this.unmanagedMemoryStream_0 = stream;
			this.int_8 = 0;
			this.enum49_0 |= Enum49.const_14;
			this.enum107_0 = iType;
		}

		internal FrameBase(TextControlCore textControlCore_1, TextPart iTextPart, int iObjectID, Enum107 iType)
		{
			this.textControlCore_0 = textControlCore_1;
			this.int_1 = iObjectID;
			this.enum107_0 = iType;
			this.textPart_0 = iTextPart;
		}

		internal FrameBase(System.Drawing.Image image, Enum107 iType)
		{
			ImageFormat imageFormat = image.RawFormat;
			if (imageFormat.Equals(ImageFormat.Bmp))
			{
				this.int_8 = 1;
			}
			else if (imageFormat.Equals(ImageFormat.Tiff))
			{
				this.int_8 = 2;
			}
			else if (imageFormat.Equals(ImageFormat.Png))
			{
				this.int_8 = 4;
			}
			else if (imageFormat.Equals(ImageFormat.Jpeg))
			{
				this.int_8 = 5;
			}
			else if (imageFormat.Equals(ImageFormat.Gif))
			{
				this.int_8 = 6;
			}
			else
			{
				this.int_8 = 1;
				imageFormat = ImageFormat.Bmp;
			}
			this.memoryStream_0 = new MemoryStream();
			image.Save(this.memoryStream_0, imageFormat);
			this.enum49_0 |= Enum49.const_14;
			this.enum107_0 = iType;
		}

		/// <summary>Changes the frame's z-order.</summary>
		/// <param name="zOrder">Specifies how the z-order is changed.</param>
		public bool ChangeZOrder(ZOrder zOrder)
		{
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated && Enum.IsDefined(typeof(ZOrder), zOrder))
			{
				Struct69 struct69_ = new Struct69(1900)
				{
					int_5 = (int)zOrder
				};
				return 2 == Class429.smethod_5(this.textControlCore_0.method_62(this.textPart_0, Enum83.const_268, this.int_1, ref struct69_));
			}
			return false;
		}

		public override bool Equals(object obj)
		{
			if (obj != null && !(obj.GetType() != base.GetType()))
			{
				if (this.textControlCore_0 != null)
				{
					_ = this.textControlCore_0.IntPtr_0;
					if (this.int_1 != 0)
					{
						FrameBase frameBase = (FrameBase)obj;
						if (frameBase.textControlCore_0 != null)
						{
							_ = frameBase.textControlCore_0.IntPtr_0;
							if (frameBase.int_1 != 0)
							{
								if (this.int_1 == frameBase.int_1)
								{
									return this.textControlCore_0.IntPtr_0 == frameBase.textControlCore_0.IntPtr_0;
								}
								return false;
							}
						}
						return base.Equals(obj);
					}
				}
				return base.Equals(obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			if (this.textControlCore_0 != null)
			{
				_ = this.textControlCore_0.IntPtr_0;
				if (this.int_1 != 0)
				{
					return this.int_1 ^ this.textControlCore_0.IntPtr_0.ToInt32();
				}
			}
			return base.GetHashCode();
		}

		internal void method_0(TextControlCore textControlCore_1, int int_13, TextPart textPart_1)
		{
			this.textControlCore_0 = textControlCore_1;
			this.int_1 = int_13;
			this.textPart_0 = textPart_1;
		}

		internal bool method_1(TextControlCore textControlCore_1, TextPart textPart_1, int int_13, int int_14, Point point_1, int int_15, int int_16, IntPtr intptr_0)
		{
			bool flag = false;
			TxError txError = TxError.ERR_NOERROR;
			int num = 0;
			textControlCore_1.method_18(textPart_1);
			Struct69 struct69_ = new Struct69(int_13, int_14, new Class429.Struct82(point_1.X, point_1.Y), int_15, int_16);
			this.method_5(ref struct69_);
			try
			{
				textControlCore_1.method_19(textPart_1, null);
				textControlCore_1.method_23(bool_1: true);
				if (this.memoryStream_0 != null)
				{
					struct69_.intptr_0 = Marshal.AllocHGlobal((int)this.memoryStream_0.Length);
					Marshal.Copy(this.memoryStream_0.GetBuffer(), 0, struct69_.intptr_0, (int)this.memoryStream_0.Length);
				}
				else if (this.unmanagedMemoryStream_0 != null)
				{
					struct69_.intptr_0 = Marshal.AllocHGlobal((int)this.unmanagedMemoryStream_0.Length);
					this.unmanagedMemoryStream_0.Position = 0L;
					for (int i = 0; i < this.unmanagedMemoryStream_0.Length; i++)
					{
						Marshal.WriteByte(struct69_.intptr_0, i, (byte)this.unmanagedMemoryStream_0.ReadByte());
					}
				}
				if (((textControlCore_1.enum56_0 & Enum56.const_2) != 0 && this.enum107_0 == Enum107.const_1) || ((textControlCore_1.enum56_0 & Enum56.const_3) != 0 && this.enum107_0 == Enum107.const_6) || ((textControlCore_1.enum56_0 & Enum56.const_4) != 0 && this.enum107_0 == Enum107.const_7) || ((textControlCore_1.enum56_0 & Enum56.const_5) != 0 && this.enum107_0 == Enum107.const_8) || ((textControlCore_1.enum56_0 & Enum56.const_6) != 0 && this.enum107_0 == Enum107.const_9))
				{
					struct69_.uint_0 |= 8192u;
				}
				int num2;
				if (intptr_0 != IntPtr.Zero)
				{
					struct69_.ushort_4 = (ushort)this.enum107_0;
					num2 = textControlCore_1.method_63(textPart_1, Enum83.const_266, intptr_0, ref struct69_);
				}
				else
				{
					num2 = textControlCore_1.method_62(textPart_1, Enum83.const_266, (int)this.enum107_0, ref struct69_);
				}
				num = Class429.smethod_5(num2);
				if (num != 0)
				{
					this.method_0(textControlCore_1, num, textPart_1);
					this.enum49_0 &= (Enum49)(-268963840);
					this.method_4();
					flag = true;
				}
				else
				{
					switch (Class429.smethod_6(num2))
					{
					case 1:
						txError = TxError.ERR_IMG_BADFILE;
						break;
					case 2:
						txError = TxError.ERR_IMG_UNKNOWN;
						break;
					case 3:
						txError = TxError.ERR_IMG_UNSUPPORTED;
						break;
					case 4:
						txError = TxError.ERR_IMG_UNKNOWN;
						break;
					case 5:
						txError = TxError.ERR_IMG_UNKNOWN;
						break;
					case 6:
						txError = TxError.ERR_IMG_BADFILTER;
						break;
					case 7:
						txError = TxError.ERR_IMG_UNSUPPFILTER;
						break;
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				struct69_.method_0();
				textControlCore_1.method_23(bool_1: false);
				textControlCore_1.method_20(textPart_1);
			}
			if (txError != 0)
			{
				throw new TextEditorException(textControlCore_1.method_83(txError.ToString()));
			}
			if (flag && this.enum107_0 == Enum107.const_6)
			{
				TextPart textPart = (TextPart)Class429.smethod_3(0, num);
				textControlCore_1.method_9(textPart);
				textControlCore_1.method_29(textPart, 2039, 0, 0);
			}
			return flag;
		}

		internal bool method_2(TextPart textPart_1)
		{
			if (this.int_1 != 0)
			{
				return 0 != this.textControlCore_0.method_29(textPart_1, 1237, this.int_1, 0);
			}
			return false;
		}

		private void method_3(Enum49 enum49_2)
		{
			if (this.int_1 == 0 || this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated)
			{
				return;
			}
			if (((enum49_2 & Enum49.const_15) != 0 && (this.enum49_1 & Enum49.const_15) == 0) || (enum49_2 & Enum49.const_5) != 0 || (enum49_2 & Enum49.const_4) != 0)
			{
				Struct69 struct69_ = new Struct69(1900)
				{
					string_0 = new string('\0', 255),
					int_3 = 255
				};
				if (this.textControlCore_0.method_62(this.textPart_0, Enum83.const_267, this.int_1, ref struct69_) != 0)
				{
					this.frameInsertionMode_0 = (FrameInsertionMode)(1 << (int)struct69_.ushort_1);
					if (struct69_.ushort_1 == 1)
					{
						this.frameInsertionMode_0 = ((struct69_.int_5 < 0) ? FrameInsertionMode.BelowTheText : FrameInsertionMode.AboveTheText);
					}
					if ((struct69_.uint_0 & 0x400u) != 0)
					{
						this.frameInsertionMode_0 |= FrameInsertionMode.MoveWithText;
					}
					if ((struct69_.uint_0 & 0x400) == 0 && this.frameInsertionMode_0 != FrameInsertionMode.AsCharacter)
					{
						this.frameInsertionMode_0 |= FrameInsertionMode.FixedOnPage;
					}
					this.int_4 = struct69_.int_0;
					this.point_0 = new Point(struct69_.int_1, struct69_.int_2);
					this.size_0 = new Size(struct69_.struct82_0.int_0, struct69_.struct82_0.int_1);
					this.int_9 = struct69_.ushort_2;
					this.int_10 = struct69_.ushort_3;
					this.int_3 = new int[4]
					{
						struct69_.struct83_0.int_0,
						struct69_.struct83_0.int_1,
						struct69_.struct83_0.int_2,
						struct69_.struct83_0.int_3
					};
					this.bool_0 = (struct69_.uint_0 & 0x100) == 0;
					this.bool_1 = (struct69_.uint_0 & 0x200) == 0;
					this.imageSaveMode_0 = (((struct69_.uint_0 & 0x10u) != 0) ? ImageSaveMode.SaveAsData : (((struct69_.uint_0 & 0x800u) != 0) ? ImageSaveMode.SaveAsFileReference : ImageSaveMode.Auto));
					this.string_2 = KernelHelper.GetString(struct69_.string_0);
					this.int_8 = struct69_.int_4;
					this.horizontalAlignment_0 = (((struct69_.uint_0 & 2u) != 0) ? HorizontalAlignment.Left : (((struct69_.uint_0 & 4u) != 0) ? HorizontalAlignment.Right : (((struct69_.uint_0 & 8u) != 0) ? HorizontalAlignment.Center : ((HorizontalAlignment)0))));
					this.byte_0 = (byte)struct69_.ushort_5;
					this.enum49_1 |= Enum49.const_15;
				}
			}
			if ((enum49_2 & Enum49.const_11) != 0 && (this.enum49_1 & Enum49.const_11) == 0)
			{
				IntPtr intPtr = this.textControlCore_0.method_64(this.textPart_0, Enum83.const_258, (uint)this.int_1, 0);
				this.string_0 = string.Empty;
				if (intPtr != IntPtr.Zero)
				{
					this.string_0 = Marshal.PtrToStringBSTR(intPtr);
					Marshal.FreeBSTR(intPtr);
				}
				this.enum49_1 |= Enum49.const_11;
			}
			if ((enum49_2 & Enum49.const_12) != 0 && (this.enum49_1 & Enum49.const_12) == 0)
			{
				this.int_2 = this.textControlCore_0.method_29(this.textPart_0, 1930, this.int_1, 0);
				this.enum49_1 |= Enum49.const_12;
			}
			if ((enum49_2 & Enum49.const_16) != 0 && (this.enum49_1 & Enum49.const_16) == 0)
			{
				IntPtr intPtr2 = Marshal.AllocHGlobal(510);
				if (this.textControlCore_0.method_38(this.textPart_0, 1664, this.int_1, intPtr2) != 0)
				{
					this.string_1 = Marshal.PtrToStringUni(intPtr2);
					this.enum49_1 |= Enum49.const_16;
				}
				Marshal.FreeHGlobal(intPtr2);
			}
			if ((enum49_2 & Enum49.const_17) != 0 && (this.enum49_1 & Enum49.const_17) == 0)
			{
				this.int_6 = this.textControlCore_0.method_29(this.textPart_0, 1245, this.int_1, 0);
				this.enum49_1 |= Enum49.const_17;
			}
			if (((enum49_2 & Enum49.const_18) != 0 && (this.enum49_1 & Enum49.const_18) == 0) || ((enum49_2 & Enum49.const_19) != 0 && (this.enum49_1 & Enum49.const_19) == 0))
			{
				int num = this.textControlCore_0.method_29(this.textPart_0, 1248, this.int_1, 0);
				this.int_7 = Class429.smethod_5(num);
				this.int_5 = Class429.smethod_6(num);
				this.enum49_1 |= (Enum49)49152;
			}
			if ((enum49_2 & Enum49.const_20) != 0 && (this.enum49_1 & Enum49.const_20) == 0)
			{
				int[] array = new int[1];
				if (this.textControlCore_0.method_40(this.textPart_0, 1881, this.int_1, array) != 0)
				{
					this.int_12 = array[0];
					this.enum49_1 |= Enum49.const_20;
				}
			}
			if ((enum49_2 & Enum49.const_21) != 0 && (this.enum49_1 & Enum49.const_21) == 0 && this.textControlCore_0.method_40(this.textPart_0, 1883, this.int_1, this.int_11) != 0)
			{
				this.enum49_1 |= Enum49.const_21;
			}
			if ((enum49_2 & Enum49.const_22) != 0 && (this.enum49_1 & Enum49.const_22) == 0)
			{
				int[] array2 = new int[1];
				if (this.textControlCore_0.method_40(this.textPart_0, 1879, this.int_1, array2) != 0)
				{
					this.color_0 = Class429.smethod_2(array2[0]);
					this.enum49_1 |= Enum49.const_22;
				}
			}
		}

		private void method_4()
		{
			if (this.int_1 != 0 && this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
			{
				if ((this.enum49_0 & Enum49.const_15) != 0)
				{
					Struct69 struct69_ = new Struct69(1900);
					this.method_5(ref struct69_);
					this.textControlCore_0.method_62(this.textPart_0, Enum83.const_268, this.int_1, ref struct69_);
				}
				if ((this.enum49_0 & Enum49.const_11) != 0)
				{
					this.textControlCore_0.method_37(this.textPart_0, 1929, this.int_1, this.string_0);
				}
				if ((this.enum49_0 & Enum49.const_12) != 0)
				{
					this.textControlCore_0.method_29(this.textPart_0, 1931, this.int_1, this.int_2);
				}
				if ((this.enum49_0 & Enum49.const_16) != 0)
				{
					this.textControlCore_0.method_37(this.textPart_0, 1665, this.int_1, this.string_1);
				}
				if ((this.enum49_0 & Enum49.const_17) != 0)
				{
					this.textControlCore_0.method_29(this.textPart_0, 1246, this.int_1, this.int_6);
				}
				if ((this.enum49_0 & Enum49.const_18) != 0 || (this.enum49_0 & Enum49.const_19) != 0)
				{
					int num = Class429.smethod_3(((this.enum49_0 & Enum49.const_18) != 0) ? this.int_7 : (-1), ((this.enum49_0 & Enum49.const_19) != 0) ? this.int_5 : (-1));
					this.textControlCore_0.method_29(this.textPart_0, 1249, this.int_1, num);
				}
				if ((this.enum49_0 & Enum49.const_20) != 0)
				{
					this.textControlCore_0.method_29(this.textPart_0, 1882, this.int_1, this.int_12);
				}
				if ((this.enum49_0 & Enum49.const_21) != 0)
				{
					this.textControlCore_0.method_40(this.textPart_0, 1884, this.int_1, this.int_11);
				}
				if ((this.enum49_0 & Enum49.const_22) != 0)
				{
					this.textControlCore_0.method_29(this.textPart_0, 1880, this.int_1, Class429.smethod_0(this.color_0));
				}
				this.enum49_0 = (Enum49)0;
			}
		}

		private void method_5(ref Struct69 struct69_0)
		{
			if ((this.enum49_0 & Enum49.const_1) != 0)
			{
				struct69_0.struct83_0.int_0 = this.int_3[0];
				struct69_0.struct83_0.int_1 = this.int_3[1];
				struct69_0.struct83_0.int_2 = this.int_3[2];
				struct69_0.struct83_0.int_3 = this.int_3[3];
			}
			if ((this.enum49_0 & Enum49.const_2) != 0)
			{
				if (!this.bool_0)
				{
					struct69_0.uint_0 &= 4294967231u;
					struct69_0.uint_0 |= 256u;
				}
				else
				{
					struct69_0.uint_0 &= 4294967039u;
					struct69_0.uint_0 |= 64u;
				}
			}
			if ((this.enum49_0 & Enum49.const_3) != 0)
			{
				if (!this.bool_1)
				{
					struct69_0.uint_0 &= 4294967167u;
					struct69_0.uint_0 |= 512u;
				}
				else
				{
					struct69_0.uint_0 &= 4294966783u;
					struct69_0.uint_0 |= 128u;
				}
			}
			if ((this.enum49_0 & Enum49.const_6) != 0)
			{
				struct69_0.uint_0 &= 4294965231u;
				if (this.imageSaveMode_0 == ImageSaveMode.SaveAsData)
				{
					struct69_0.uint_0 |= 16u;
				}
				if (this.imageSaveMode_0 == ImageSaveMode.SaveAsFileReference)
				{
					struct69_0.uint_0 |= 2048u;
				}
				if (this.imageSaveMode_0 == ImageSaveMode.Auto)
				{
					struct69_0.uint_0 |= 65536u;
				}
			}
			if ((this.enum49_0 & Enum49.const_13) != 0)
			{
				struct69_0.string_0 = this.string_2;
				struct69_0.int_3 = this.string_2.Length + 1;
			}
			if ((this.enum49_0 & Enum49.const_14) != 0)
			{
				struct69_0.int_4 = this.int_8;
			}
			if ((this.enum49_0 & Enum49.const_7) != 0)
			{
				struct69_0.ushort_2 = (ushort)this.int_9;
			}
			if ((this.enum49_0 & Enum49.const_8) != 0)
			{
				struct69_0.ushort_3 = (ushort)this.int_10;
			}
			if ((this.enum49_0 & Enum49.const_9) != 0)
			{
				struct69_0.struct82_0.int_0 = this.size_0.Width;
				struct69_0.struct82_0.int_1 = this.size_0.Height;
			}
			if ((this.enum49_0 & Enum49.const_5) != 0)
			{
				struct69_0.uint_0 &= 4294967281u;
				struct69_0.int_1 = this.point_0.X;
				struct69_0.int_2 = this.point_0.Y;
			}
			if ((this.enum49_0 & Enum49.const_10) != 0)
			{
				struct69_0.int_1 = 0;
				struct69_0.uint_0 &= 4294967281u;
				switch (this.horizontalAlignment_0)
				{
				case HorizontalAlignment.Left:
					struct69_0.uint_0 |= 2u;
					break;
				case HorizontalAlignment.Right:
					struct69_0.uint_0 |= 4u;
					break;
				case HorizontalAlignment.Center:
					struct69_0.uint_0 |= 8u;
					break;
				}
			}
			if ((this.enum49_0 & Enum49.const_0) != 0)
			{
				struct69_0.ushort_1 = Struct69.smethod_0((int)this.frameInsertionMode_0);
				if ((this.frameInsertionMode_0 & FrameInsertionMode.MoveWithText) != 0)
				{
					struct69_0.uint_0 |= 1024u;
				}
				struct69_0.int_5 = (this.frameInsertionMode_0 & ~(FrameInsertionMode.MoveWithText | FrameInsertionMode.FixedOnPage)) switch
				{
					FrameInsertionMode.AsCharacter => 0, 
					FrameInsertionMode.BelowTheText => int.MinValue, 
					_ => int.MaxValue, 
				};
			}
			if ((this.enum49_0 & Enum49.const_23) != 0)
			{
				struct69_0.ushort_5 = this.byte_0;
			}
		}
	}
}
