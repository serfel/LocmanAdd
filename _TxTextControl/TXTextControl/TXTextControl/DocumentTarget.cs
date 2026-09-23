using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	/// <summary>The DocumentTarget class represents a text position in a Text Control document that can be a target of a document link or a bookmark.</summary>
	public class DocumentTarget
	{
		private enum Enum51
		{
			const_0 = 1,
			const_1 = 2,
			const_2 = 4,
			const_3 = 8,
			const_4 = 0x10,
			const_5 = 0x20,
			const_6 = 0x40,
			const_7 = 0x7F,
			const_8 = 0x1000,
			const_9 = 0x2000,
			const_10 = 12415
		}

		internal TextControlCore textControlCore_0;

		private int int_0;

		private int int_1;

		private TextPart textPart_0;

		private Enum51 enum51_0;

		private Enum51 enum51_1;

		private AutoGenerationType autoGenerationType_0 = AutoGenerationType.None;

		private Rectangle rectangle_0 = new Rectangle(0, 0, 0, 0);

		private bool bool_0 = true;

		private int int_2;

		private string string_0 = string.Empty;

		private int int_3;

		private string string_1 = string.Empty;

		/// <summary>Gets the type of auto-generation.</summary>
		public AutoGenerationType AutoGenerationType
		{
			get
			{
				this.method_2(Enum51.const_6);
				return this.autoGenerationType_0;
			}
		}

		/// <summary>Gets the bounding rectangle of a target.</summary>
		public Rectangle Bounds
		{
			get
			{
				this.method_2(Enum51.const_9);
				return this.rectangle_0;
			}
		}

		/// <summary>Returns true, if the target's position is the same as the current text input position.</summary>
		public bool ContainsInputPosition
		{
			get
			{
				bool flag = false;
				if (this.textControlCore_0 != null)
				{
					IntPtr intPtr = this.textControlCore_0.method_64(this.textPart_0, Enum83.const_312, 3u, 0);
					if (intPtr != IntPtr.Zero)
					{
						try
						{
							int[] array = KernelHelper.PtrInt16ToIntArray(intPtr);
							int num = 0;
							while (true)
							{
								if (num >= array.Length)
								{
									return flag;
								}
								if (flag)
								{
									break;
								}
								if (array[num] == this.int_1)
								{
									flag = true;
								}
								num++;
							}
							return flag;
						}
						catch (Exception ex)
						{
							throw ex;
						}
						finally
						{
							Class429.GlobalFree(intPtr);
						}
					}
				}
				return flag;
			}
		}

		/// <summary>Specifies whether the target can be deleted by the end-user while the document is being edited.</summary>
		public bool Deleteable
		{
			get
			{
				this.method_2(Enum51.const_5);
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
				this.enum51_0 |= Enum51.const_5;
				this.method_3();
			}
		}

		public int Int32_0
		{
			get
			{
				this.method_2(Enum51.const_2);
				return this.int_2;
			}
			set
			{
				this.int_2 = value;
				this.enum51_0 |= Enum51.const_2;
				this.method_3();
			}
		}

		/// <summary>Relates a user-defined name to a target, that can be any kind of text in addition to the target's TargetName.</summary>
		public string Name
		{
			get
			{
				this.method_2(Enum51.const_1);
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
				this.enum51_0 |= Enum51.const_1;
				this.method_3();
			}
		}

		public int Number
		{
			get
			{
				if (this.int_0 == 0)
				{
					this.method_2(Enum51.const_3);
				}
				return this.int_0;
			}
		}

		/// <summary>Gets the character position (one-based) of the target.</summary>
		public int Start
		{
			get
			{
				this.method_2(Enum51.const_0);
				return this.int_3;
			}
		}

		/// <summary>Gets or sets the target name.</summary>
		public string TargetName
		{
			get
			{
				this.method_2(Enum51.const_8);
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
				this.enum51_0 |= Enum51.const_8;
				this.method_3();
			}
		}

		/// <summary>Creates a new instance of the DocumentTarget class with the specified target name.</summary>
		/// <param name="targetName">Specifies the name of the target.</param>
		public DocumentTarget(string targetName)
		{
			this.string_1 = targetName;
			this.int_3 = 0;
		}

		/// <summary>Creates a new instance of the DocumentTarget class with the specified target name and position.</summary>
		/// <param name="targetName">Specifies the name of the target.</param>
		/// <param name="position">Specifies the one-based character position where to insert the target.</param>
		public DocumentTarget(string targetName, int position)
		{
			if (position < 1)
			{
				throw new ArgumentException();
			}
			this.string_1 = targetName;
			this.int_3 = position;
		}

		internal DocumentTarget(TextControlCore textControlCore_1, TextPart iTextPart, int iNumber, int iInternalID)
		{
			this.textControlCore_0 = textControlCore_1;
			this.int_0 = iNumber;
			this.textPart_0 = iTextPart;
			this.int_1 = iInternalID;
		}

		public override bool Equals(object obj)
		{
			if (obj != null && !(obj.GetType() != base.GetType()))
			{
				DocumentTarget documentTarget = (DocumentTarget)obj;
				if (this.int_1 != 0 && documentTarget.int_1 != 0)
				{
					return this.int_1 == documentTarget.int_1;
				}
				return base.Equals(obj);
			}
			return false;
		}

		public override int GetHashCode()
		{
			if (this.int_1 == 0)
			{
				this.method_2(Enum51.const_4);
			}
			if (this.int_1 == 0)
			{
				return base.GetHashCode();
			}
			return this.int_1;
		}

		internal bool method_0()
		{
			bool flag = false;
			Struct46 struct46_ = new Struct46(this.int_1, this.int_0, this.int_2, this.string_0, Enum52.const_3);
			try
			{
				return (this.textControlCore_0.method_58(this.textPart_0, Enum83.const_307, 0, ref struct46_) != IntPtr.Zero) ? true : false;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (struct46_.intptr_0 != IntPtr.Zero)
				{
					Marshal.FreeBSTR(struct46_.intptr_0);
				}
			}
		}

		/// <summary>Sets the current text input position to the target's position and scrolls it into the visible part of the document.</summary>
		public bool ScrollTo()
		{
			bool flag = false;
			Struct46 struct46_ = new Struct46(this.int_1, this.int_0, this.int_2, this.string_0, Enum52.const_3);
			try
			{
				return this.textControlCore_0.method_58(this.textPart_0, Enum83.const_311, 0, ref struct46_) != IntPtr.Zero;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (struct46_.intptr_0 != IntPtr.Zero)
				{
					Marshal.FreeBSTR(struct46_.intptr_0);
				}
			}
		}

		internal bool method_1(TextControlCore textControlCore_1, TextPart textPart_1, int int_4)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = textPart_1;
			if (int_4 == 0)
			{
				this.method_2(Enum51.const_4);
			}
			else
			{
				this.int_1 = int_4;
			}
			return this.int_1 != 0;
		}

		private void method_2(Enum51 enum51_2)
		{
			if (this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated || (this.int_1 == 0 && this.int_0 == 0 && this.int_2 == 0 && this.string_0 == string.Empty && this.string_1 == string.Empty) || (enum51_2 & Enum51.const_10) == 0 || this.enum51_1 == Enum51.const_10)
			{
				return;
			}
			Struct46 struct46_ = new Struct46(this.int_1, this.int_0, this.int_2, this.string_0, Enum52.const_3);
			if (this.int_1 == 0 && this.int_0 == 0 && this.int_2 == 0 && this.string_0 == string.Empty)
			{
				struct46_.intptr_1 = Marshal.StringToBSTR(this.string_1);
			}
			if ((enum51_2 & Enum51.const_8) != 0)
			{
				struct46_.ushort_5 |= 1;
			}
			try
			{
				this.enum51_1 = (Enum51)0;
				if (!(this.textControlCore_0.method_58(this.textPart_0, Enum83.const_310, 0, ref struct46_) != IntPtr.Zero))
				{
					return;
				}
				this.int_1 = struct46_.ushort_4;
				this.int_0 = (int)struct46_.uint_4;
				this.int_3 = (int)(struct46_.uint_0 + 1);
				this.bool_0 = (struct46_.ushort_1 & 0x40) == 0;
				this.autoGenerationType_0 = (((struct46_.ushort_1 & 0x100) == 0) ? AutoGenerationType.None : AutoGenerationType.TableOfContents);
				this.int_2 = (int)struct46_.uint_3;
				if (struct46_.intptr_0 != IntPtr.Zero)
				{
					this.string_0 = Marshal.PtrToStringBSTR(struct46_.intptr_0);
				}
				this.int_0 = (int)struct46_.uint_4;
				this.enum51_1 |= Enum51.const_7;
				if ((enum51_2 & Enum51.const_8) != 0)
				{
					if (struct46_.intptr_1 != IntPtr.Zero)
					{
						this.string_1 = Marshal.PtrToStringBSTR(struct46_.intptr_1);
					}
					this.enum51_1 |= Enum51.const_8;
				}
				if ((enum51_2 & Enum51.const_9) != 0)
				{
					Struct44 struct44_ = new Struct44((int)struct46_.uint_0);
					int num = this.textControlCore_0.method_72(this.textPart_0, Enum83.const_54, 0, ref struct44_);
					this.rectangle_0 = new Rectangle(struct44_.struct83_0.int_0, struct44_.struct83_0.int_1 + num, 0, struct44_.struct83_0.int_3 - struct44_.struct83_0.int_1);
					this.enum51_1 |= Enum51.const_9;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (struct46_.intptr_0 != IntPtr.Zero)
				{
					Marshal.FreeBSTR(struct46_.intptr_0);
				}
				if (struct46_.intptr_1 != IntPtr.Zero)
				{
					Marshal.FreeBSTR(struct46_.intptr_1);
				}
			}
		}

		internal void method_3()
		{
			if (this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated || this.enum51_0 == (Enum51)0 || (this.int_0 == 0 && this.int_1 == 0))
			{
				return;
			}
			Struct46 struct46_ = new Struct46(this.int_1, this.int_0, 0, string.Empty, Enum52.const_3)
			{
				ushort_1 = 0,
				uint_2 = 2147483648u,
				uint_3 = uint.MaxValue,
				intptr_0 = IntPtr.Zero
			};
			if ((this.enum51_0 & Enum51.const_2) != 0)
			{
				struct46_.uint_3 = (uint)this.int_2;
			}
			if ((this.enum51_0 & Enum51.const_1) != 0)
			{
				struct46_.intptr_0 = Marshal.StringToBSTR(this.string_0);
			}
			if ((this.enum51_0 & Enum51.const_5) != 0)
			{
				struct46_.ushort_1 = (ushort)(this.bool_0 ? 128 : 64);
			}
			if ((this.enum51_0 & Enum51.const_8) != 0)
			{
				struct46_.intptr_1 = Marshal.StringToBSTR(this.string_1);
			}
			try
			{
				this.textControlCore_0.method_58(this.textPart_0, Enum83.const_308, 0, ref struct46_);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (struct46_.intptr_0 != IntPtr.Zero)
				{
					Marshal.FreeBSTR(struct46_.intptr_0);
				}
				if (struct46_.intptr_1 != IntPtr.Zero)
				{
					Marshal.FreeBSTR(struct46_.intptr_1);
				}
			}
		}
	}
}
