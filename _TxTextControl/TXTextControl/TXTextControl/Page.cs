using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using ns21;

namespace TXTextControl
{
	/// <summary>A Page object represents a formatted page of a document.</summary>
	public class Page
	{
		private enum Enum70
		{
			const_0 = 1,
			const_1 = 2,
			const_2 = 4,
			const_3 = 8,
			const_4 = 0x10,
			const_5 = 0x20,
			const_6 = 0x3F
		}

		[Flags]
		public enum PageContent
		{
			Background = 0x1,
			HeadersAndFooters = 0x2,
			MainText = 0x4,
			ScreenElements = 0x8,
			All = 0x7
		}

		private Enum70 enum70_0;

		private TextControlCore textControlCore_0;

		private int int_0;

		private Rectangle rectangle_0 = default(Rectangle);

		private int int_1;

		private int int_2;

		private int int_3;

		private int int_4;

		private Rectangle rectangle_1 = default(Rectangle);

		/// <summary>Gets the bounding rectangle of the page, in twips, relative to the top of the document.</summary>
		public Rectangle Bounds
		{
			get
			{
				this.method_0(Enum70.const_0);
				return this.rectangle_0;
			}
		}

		/// <summary>Gets the header of the page.</summary>
		[Browsable(false)]
		public HeaderFooter Header
		{
			get
			{
				int section = this.Section;
				Enum93 @enum = (Enum93)this.textControlCore_0.method_30(Enum83.const_133, section, 0);
				if (this.NumberInSection == 1 && ((@enum & Enum93.const_5) != 0 || (@enum & Enum93.const_18) != 0))
				{
					return new HeaderFooter(this.textControlCore_0, HeaderFooterType.FirstPageHeader, section, (@enum & Enum93.const_18) != 0);
				}
				if ((@enum & Enum93.const_4) == 0 && (@enum & Enum93.const_17) == 0)
				{
					return null;
				}
				return new HeaderFooter(this.textControlCore_0, HeaderFooterType.Header, section, (@enum & Enum93.const_17) != 0);
			}
		}

		/// <summary>Gets the footer of the page.</summary>
		[Browsable(false)]
		public HeaderFooter Footer
		{
			get
			{
				int section = this.Section;
				Enum93 @enum = (Enum93)this.textControlCore_0.method_30(Enum83.const_133, section, 0);
				if (this.NumberInSection == 1 && ((@enum & Enum93.const_7) != 0 || (@enum & Enum93.const_20) != 0))
				{
					return new HeaderFooter(this.textControlCore_0, HeaderFooterType.FirstPageFooter, section, (@enum & Enum93.const_20) != 0);
				}
				if ((@enum & Enum93.const_6) == 0 && (@enum & Enum93.const_19) == 0)
				{
					return null;
				}
				return new HeaderFooter(this.textControlCore_0, HeaderFooterType.Footer, section, (@enum & Enum93.const_19) != 0);
			}
		}

		/// <summary>Gets the number of characters of the page, including the page break character at the end of the page.</summary>
		[Browsable(false)]
		public int Length
		{
			get
			{
				this.method_0(Enum70.const_5);
				return this.int_1;
			}
		}

		/// <summary>Gets the page's number.</summary>
		[Browsable(false)]
		public int Number => this.int_0;

		/// <summary>Gets the page number relative to the beginning of the section the page belongs to.</summary>
		[Browsable(false)]
		public int NumberInSection
		{
			get
			{
				this.method_0(Enum70.const_2);
				return this.int_2;
			}
		}

		/// <summary>Gets the number, one-based, of the section the page belongs to.</summary>
		[Browsable(false)]
		public int Section
		{
			get
			{
				this.method_0(Enum70.const_3);
				return this.int_3;
			}
		}

		/// <summary>Gets the number (one-based) of the page's first character.</summary>
		[Browsable(false)]
		public int Start
		{
			get
			{
				this.method_0(Enum70.const_4);
				return this.int_4;
			}
		}

		/// <summary>Gets the bounding rectangle of the page's text, in twips, relative to the top of the document.</summary>
		public Rectangle TextBounds
		{
			get
			{
				this.method_0(Enum70.const_1);
				return this.rectangle_1;
			}
		}

		internal Page(TextControlCore textControlCore_1, int iNumber)
		{
			this.textControlCore_0 = textControlCore_1;
			this.int_0 = iNumber;
		}

		public Metafile GetImage(PageContent contents)
		{
			IntPtr intPtr = this.textControlCore_0.method_66(Enum83.const_239, (uint)this.int_0, (int)contents);
			if (intPtr != IntPtr.Zero)
			{
				return new Metafile(intPtr, deleteEmf: true);
			}
			return null;
		}

		public Bitmap GetImage(int zoomFactor, PageContent contents)
		{
			IntPtr intPtr = IntPtr.Zero;
			Graphics graphics = null;
			Graphics graphics2 = null;
			Bitmap bitmap = null;
			if (zoomFactor >= 10 && zoomFactor <= 400)
			{
				try
				{
					graphics = Graphics.FromHwnd(this.textControlCore_0.IntPtr_0);
					graphics.PageUnit = GraphicsUnit.Point;
					graphics.PageScale = 0.05f * (float)zoomFactor / 100f;
					Rectangle bounds = this.Bounds;
					Point[] array = new Point[1]
					{
						new Point(bounds.Width, bounds.Height)
					};
					graphics.TransformPoints(CoordinateSpace.Device, CoordinateSpace.Page, array);
					bitmap = new Bitmap(array[0].X, array[0].Y, graphics);
					graphics2 = Graphics.FromImage(bitmap);
					Struct48 struct48_ = default(Struct48);
					struct48_.method_0();
					struct48_.ushort_1 = (ushort)this.int_0;
					struct48_.ushort_2 = (ushort)zoomFactor;
					struct48_.ushort_3 = 22;
					if ((contents & PageContent.Background) != 0)
					{
						struct48_.ushort_3 |= 32;
					}
					if ((contents & PageContent.HeadersAndFooters) == 0)
					{
						struct48_.ushort_3 |= 64;
					}
					if ((contents & PageContent.MainText) == 0)
					{
						struct48_.ushort_3 |= 128;
					}
					if ((contents & PageContent.ScreenElements) != 0)
					{
						struct48_.ushort_3 |= 256;
					}
					intPtr = graphics2.GetHdc();
					this.textControlCore_0.method_48(Enum83.const_55, (int)intPtr, ref struct48_);
					return bitmap;
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					if (intPtr != IntPtr.Zero)
					{
						graphics2.ReleaseHdc(intPtr);
					}
					graphics?.Dispose();
					graphics2?.Dispose();
				}
			}
			throw new ArgumentOutOfRangeException();
		}

		/// <summary>Selects the text of the page. The page break characters bounding the page and the header and/or footer belonging to the page are not selected.</summary>
		public void Select()
		{
			this.method_0((Enum70)48);
			this.textControlCore_0.method_5(TextPart.Auto, this.int_4 - 1, this.int_1);
		}

		private void method_0(Enum70 enum70_1)
		{
			if (this.int_0 != 0 && this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated && (enum70_1 & Enum70.const_6) != 0 && (this.enum70_0 & Enum70.const_6) == 0)
			{
				Struct45 struct45_ = default(Struct45);
				struct45_.method_0();
				if (this.textControlCore_0.method_50(Enum83.const_236, this.int_0, ref struct45_) != 0)
				{
					this.int_3 = (int)struct45_.uint_0;
					this.int_2 = (int)struct45_.uint_1;
					this.int_4 = (int)(struct45_.uint_2 + 1);
					this.int_1 = (int)struct45_.uint_3;
					this.rectangle_0.X = struct45_.struct83_0.int_0;
					this.rectangle_0.Y = struct45_.struct83_0.int_1;
					this.rectangle_0.Width = struct45_.struct83_0.int_2 - struct45_.struct83_0.int_0;
					this.rectangle_0.Height = struct45_.struct83_0.int_3 - struct45_.struct83_0.int_1;
					this.rectangle_1.X = struct45_.struct83_1.int_0;
					this.rectangle_1.Y = struct45_.struct83_1.int_1;
					this.rectangle_1.Width = struct45_.struct83_1.int_2 - struct45_.struct83_1.int_0;
					this.rectangle_1.Height = struct45_.struct83_1.int_3 - struct45_.struct83_1.int_1;
					this.enum70_0 |= Enum70.const_6;
				}
			}
		}
	}
}
