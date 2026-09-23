using System.ComponentModel;
using System.Drawing;
using ns21;

namespace TXTextControl
{
	/// <summary>The PageBorder represents the attributes of a border, which is drawn in the margin area of a page.</summary>
	public class PageBorder
	{
		/// <summary>Determines a certain page border attribute.</summary>
		public enum Attribute
		{
			/// <summary>Specifies the attribute set through the LeftLineWidth property.</summary>
			LeftLineWidth = 1,
			/// <summary>Specifies the attribute set through the TopLineWidth property.</summary>
			TopLineWidth = 2,
			/// <summary>Specifies the attribute set through the RightLineWidth property.</summary>
			RightLineWidth = 4,
			/// <summary>Specifies the attribute set through the BottomLineWidth property.</summary>
			BottomLineWidth = 8,
			/// <summary>Specifies the attribute set through the LeftLineColor property.</summary>
			LeftLineColor = 0x10,
			/// <summary>Specifies the attribute set through the TopLineColor property.</summary>
			TopLineColor = 0x20,
			/// <summary>Specifies the attribute set through the RightLineColor property.</summary>
			RightLineColor = 0x40,
			/// <summary>Specifies the attribute set through the BottomLineColor property.</summary>
			BottomLineColor = 0x80,
			/// <summary>Specifies the attribute set through the LeftDistance property.</summary>
			LeftDistance = 0x100,
			/// <summary>Specifies the attribute set through the TopDistance property.</summary>
			TopDistance = 0x200,
			/// <summary>Specifies the attribute set through the RightDistance property.</summary>
			RightDistance = 0x400,
			/// <summary>Specifies the attribute set through the BottomDistance property.</summary>
			BottomDistance = 0x800,
			/// <summary>Specifies the attribute set through the MeasureFromText property.</summary>
			MeasureFromText = 0x1000,
			/// <summary>Specifies the attribute set through the FirstPageOnly property.</summary>
			FirstPageOnly = 0x2000,
			/// <summary>Specifies the attribute set through the OmitFirstPage property.</summary>
			OmitFirstPage = 0x4000,
			/// <summary>Specifies the attribute set through the SurroundHeader property.</summary>
			SurroundHeader = 0x8000,
			/// <summary>Specifies the attribute set through the SurroundFooter property.</summary>
			SurroundFooter = 0x10000,
			/// <summary>Specifies all attributes of the PageSize.</summary>
			All = 0x1FFFF
		}

		/// <summary>Represents the default distance of a page border from the edge of the page.</summary>
		public const int DefaultDistance = 454;

		private Attribute attribute_0;

		private Attribute attribute_1;

		private Attribute attribute_2;

		private TextControlCore textControlCore_0;

		private int int_0;

		private Color color_0 = SystemColors.WindowText;

		private int int_1 = 454;

		private int int_2;

		private bool bool_0;

		private Color color_1 = SystemColors.WindowText;

		private int int_3 = 454;

		private int int_4;

		private bool bool_1;

		private bool bool_2;

		private Color color_2 = SystemColors.WindowText;

		private int int_5 = 454;

		private int int_6;

		private bool bool_3;

		private bool bool_4;

		private Color color_3 = SystemColors.WindowText;

		private int int_7 = 454;

		private int int_8;

		/// <summary>Gets or sets the color of the bottom border line.</summary>
		[Browsable(false)]
		public Color BottomLineColor
		{
			get
			{
				this.method_3(Attribute.BottomLineColor);
				return this.color_0;
			}
			set
			{
				this.color_0 = value;
				this.attribute_0 |= Attribute.BottomLineColor;
				this.method_4();
			}
		}

		/// <summary>Gets or sets the distance, in twips, of the bottom border line either from the edge of the page or from the text, depending on the MeasureFromText property.</summary>
		[Browsable(false)]
		public int BottomDistance
		{
			get
			{
				this.method_3(Attribute.BottomDistance);
				return this.int_1;
			}
			set
			{
				this.int_1 = value;
				this.attribute_0 |= Attribute.BottomDistance;
				this.method_4();
			}
		}

		/// <summary>Gets or sets the width of the bottom border line.</summary>
		[Browsable(false)]
		public int BottomLineWidth
		{
			get
			{
				this.method_3(Attribute.BottomLineWidth);
				return this.int_2;
			}
			set
			{
				this.int_2 = value;
				this.attribute_0 |= Attribute.BottomLineWidth;
				this.method_4();
			}
		}

		/// <summary>Gets or sets a value indicating whether the page border is drawn only on the first page of the section.</summary>
		[Browsable(false)]
		public bool FirstPageOnly
		{
			get
			{
				this.method_3(Attribute.FirstPageOnly);
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
				this.bool_2 = false;
				this.attribute_0 |= (Attribute)24576;
				this.method_4();
			}
		}

		/// <summary>Gets or sets the color of the left border line.</summary>
		[Browsable(false)]
		public Color LeftLineColor
		{
			get
			{
				this.method_3(Attribute.LeftLineColor);
				return this.color_1;
			}
			set
			{
				this.color_1 = value;
				this.attribute_0 |= Attribute.LeftLineColor;
				this.method_4();
			}
		}

		/// <summary>Gets or sets the distance, in twips, of the left border line either from the edge of the page or from the text, depending on the MeasureFromText property.</summary>
		[Browsable(false)]
		public int LeftDistance
		{
			get
			{
				this.method_3(Attribute.LeftDistance);
				return this.int_3;
			}
			set
			{
				this.int_3 = value;
				this.attribute_0 |= Attribute.LeftDistance;
				this.method_4();
			}
		}

		/// <summary>Gets or sets the width of the left border line.</summary>
		[Browsable(false)]
		public int LeftLineWidth
		{
			get
			{
				this.method_3(Attribute.LeftLineWidth);
				return this.int_4;
			}
			set
			{
				this.int_4 = value;
				this.attribute_0 |= Attribute.LeftLineWidth;
				this.method_4();
			}
		}

		/// <summary>Gets or sets a value indicating whether the page border's distances are measured from the text.</summary>
		[Browsable(false)]
		public bool MeasureFromText
		{
			get
			{
				this.method_3(Attribute.MeasureFromText);
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
				this.attribute_0 |= Attribute.MeasureFromText;
				this.method_4();
			}
		}

		/// <summary>Gets or sets a value indicating whether the page border is not drawn on the first page of the section.</summary>
		[Browsable(false)]
		public bool OmitFirstPage
		{
			get
			{
				this.method_3(Attribute.OmitFirstPage);
				return this.bool_2;
			}
			set
			{
				this.bool_2 = value;
				this.bool_0 = false;
				this.attribute_0 |= (Attribute)24576;
				this.method_4();
			}
		}

		/// <summary>Gets or sets the color of the right border line.</summary>
		[Browsable(false)]
		public Color RightLineColor
		{
			get
			{
				this.method_3(Attribute.RightLineColor);
				return this.color_2;
			}
			set
			{
				this.color_2 = value;
				this.attribute_0 |= Attribute.RightLineColor;
				this.method_4();
			}
		}

		/// <summary>Gets or sets the distance, in twips, of the right border line either from the edge of the page or from the text, depending on the MeasureFromText property.</summary>
		[Browsable(false)]
		public int RightDistance
		{
			get
			{
				this.method_3(Attribute.RightDistance);
				return this.int_5;
			}
			set
			{
				this.int_5 = value;
				this.attribute_0 |= Attribute.RightDistance;
				this.method_4();
			}
		}

		/// <summary>Gets or sets the width of the right border line.</summary>
		[Browsable(false)]
		public int RightLineWidth
		{
			get
			{
				this.method_3(Attribute.RightLineWidth);
				return this.int_6;
			}
			set
			{
				this.int_6 = value;
				this.attribute_0 |= Attribute.RightLineWidth;
				this.method_4();
			}
		}

		/// <summary>Gets or sets a value indicating whether the page border surrounds the section's footer.</summary>
		[Browsable(false)]
		public bool SurroundFooter
		{
			get
			{
				this.method_3(Attribute.SurroundFooter);
				return this.bool_3;
			}
			set
			{
				this.bool_3 = value;
				this.attribute_0 |= Attribute.SurroundFooter;
				this.method_4();
			}
		}

		/// <summary>Gets or sets a value indicating whether the page border surrounds the section's header.</summary>
		[Browsable(false)]
		public bool SurroundHeader
		{
			get
			{
				this.method_3(Attribute.SurroundHeader);
				return this.bool_4;
			}
			set
			{
				this.bool_4 = value;
				this.attribute_0 |= Attribute.SurroundHeader;
				this.method_4();
			}
		}

		/// <summary>Gets or sets the color of the top border line.</summary>
		[Browsable(false)]
		public Color TopLineColor
		{
			get
			{
				this.method_3(Attribute.TopLineColor);
				return this.color_3;
			}
			set
			{
				this.color_3 = value;
				this.attribute_0 |= Attribute.TopLineColor;
				this.method_4();
			}
		}

		/// <summary>Gets or sets the distance, in twips, of the top border line either from the edge of the page or from the text, depending on the MeasureFromText property.</summary>
		[Browsable(false)]
		public int TopDistance
		{
			get
			{
				this.method_3(Attribute.TopDistance);
				return this.int_7;
			}
			set
			{
				this.int_7 = value;
				this.attribute_0 |= Attribute.TopDistance;
				this.method_4();
			}
		}

		/// <summary>Gets or sets the width of the top border line.</summary>
		[Browsable(false)]
		public int TopLineWidth
		{
			get
			{
				this.method_3(Attribute.TopLineWidth);
				return this.int_8;
			}
			set
			{
				this.int_8 = value;
				this.attribute_0 |= Attribute.TopLineWidth;
				this.method_4();
			}
		}

		internal int Int32_0
		{
			get
			{
				int num = 0;
				for (int i = 0; i < 32; i++)
				{
					if (((uint)this.attribute_0 & (uint)(1 << i)) != 0)
					{
						num++;
					}
				}
				return num;
			}
		}

		/// <summary>Creates an empty PageBorder object. Further properties must be set.</summary>
		public PageBorder()
		{
		}

		/// <summary>Creates a PageBorder object with equal line widths, colors and distances from the edge of the page.</summary>
		/// <param name="lineWidth">Specifies the width for all border lines.</param>
		/// <param name="distance">Specifies the distance of the border lines from the edge of the page.</param>
		/// <param name="lineColor">Specifies the color for all border lines.</param>
		public PageBorder(int lineWidth, int distance, Color lineColor)
		{
			this.int_4 = lineWidth;
			this.int_8 = lineWidth;
			this.int_6 = lineWidth;
			this.int_2 = lineWidth;
			this.attribute_0 |= (Attribute)15;
			this.int_3 = distance;
			this.int_7 = distance;
			this.int_5 = distance;
			this.int_1 = distance;
			this.attribute_0 |= (Attribute)3840;
			this.color_1 = lineColor;
			this.color_3 = lineColor;
			this.color_2 = lineColor;
			this.color_0 = lineColor;
			this.attribute_0 |= (Attribute)240;
		}

		internal bool method_0(Attribute attribute_3)
		{
			this.method_3(attribute_3);
			return (this.attribute_2 & attribute_3) == 0;
		}

		internal void method_1(TextControlCore textControlCore_1, int int_9)
		{
			this.textControlCore_0 = textControlCore_1;
			this.int_0 = int_9;
		}

		internal void method_2(PageBorder pageBorder_0)
		{
			pageBorder_0.int_4 = this.int_4;
			pageBorder_0.int_8 = this.int_8;
			pageBorder_0.int_6 = this.int_6;
			pageBorder_0.int_2 = this.int_2;
			pageBorder_0.color_1 = this.color_1;
			pageBorder_0.color_3 = this.color_3;
			pageBorder_0.color_2 = this.color_2;
			pageBorder_0.color_0 = this.color_0;
			pageBorder_0.int_3 = this.int_3;
			pageBorder_0.int_7 = this.int_7;
			pageBorder_0.int_5 = this.int_5;
			pageBorder_0.int_1 = this.int_1;
			pageBorder_0.bool_1 = this.bool_1;
			pageBorder_0.bool_0 = this.bool_0;
			pageBorder_0.bool_2 = this.bool_2;
			pageBorder_0.bool_4 = this.bool_4;
			pageBorder_0.bool_3 = this.bool_3;
			pageBorder_0.attribute_0 = this.attribute_0;
		}

		private void method_3(Attribute attribute_3)
		{
			if (this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated || (attribute_3 & Attribute.All) == 0 || (this.attribute_1 & Attribute.All) != 0)
			{
				return;
			}
			this.attribute_2 &= (Attribute)(-131072);
			Struct70 struct70_ = new Struct70(-1);
			this.textControlCore_0.method_79(Enum83.const_283, this.int_0, ref struct70_);
			this.int_4 = struct70_.short_0;
			if (this.int_4 == -1)
			{
				this.attribute_2 |= Attribute.LeftLineWidth;
				this.int_4 = 0;
			}
			this.int_8 = struct70_.short_1;
			if (this.int_8 == -1)
			{
				this.attribute_2 |= Attribute.TopLineWidth;
				this.int_8 = 0;
			}
			this.int_6 = struct70_.short_2;
			if (this.int_6 == -1)
			{
				this.attribute_2 |= Attribute.RightLineWidth;
				this.int_6 = 0;
			}
			this.int_2 = struct70_.short_3;
			if (this.int_2 == -1)
			{
				this.attribute_2 |= Attribute.BottomLineWidth;
				this.int_2 = 0;
			}
			this.int_3 = struct70_.short_4;
			if (this.int_3 == -1)
			{
				this.attribute_2 |= Attribute.LeftDistance;
				this.int_3 = 454;
			}
			this.int_7 = struct70_.short_5;
			if (this.int_7 == -1)
			{
				this.attribute_2 |= Attribute.TopDistance;
				this.int_7 = 454;
			}
			this.int_5 = struct70_.short_6;
			if (this.int_5 == -1)
			{
				this.attribute_2 |= Attribute.RightDistance;
				this.int_5 = 454;
			}
			this.int_1 = struct70_.short_7;
			if (this.int_1 == -1)
			{
				this.attribute_2 |= Attribute.BottomDistance;
				this.int_1 = 454;
			}
			if (struct70_.uint_0 == 2147483648u)
			{
				this.attribute_2 |= Attribute.LeftLineColor;
				this.color_1 = SystemColors.WindowText;
			}
			else
			{
				this.color_1 = KernelHelper.TxColor2SysDrawingColor(struct70_.uint_0, bBkGnd: false);
			}
			if (struct70_.uint_1 == 2147483648u)
			{
				this.attribute_2 |= Attribute.TopLineColor;
				this.color_3 = SystemColors.WindowText;
			}
			else
			{
				this.color_3 = KernelHelper.TxColor2SysDrawingColor(struct70_.uint_1, bBkGnd: false);
			}
			if (struct70_.uint_2 == 2147483648u)
			{
				this.attribute_2 |= Attribute.RightLineColor;
				this.color_2 = SystemColors.WindowText;
			}
			else
			{
				this.color_2 = KernelHelper.TxColor2SysDrawingColor(struct70_.uint_2, bBkGnd: false);
			}
			if (struct70_.uint_3 == 2147483648u)
			{
				this.attribute_2 |= Attribute.BottomLineColor;
				this.color_0 = SystemColors.WindowText;
			}
			else
			{
				this.color_0 = KernelHelper.TxColor2SysDrawingColor(struct70_.uint_3, bBkGnd: false);
			}
			this.bool_4 = false;
			this.bool_3 = false;
			this.bool_1 = (struct70_.uint_4 & 1) != 0;
			if ((struct70_.uint_4 & 0x10001) == 0)
			{
				this.attribute_2 |= Attribute.MeasureFromText;
			}
			else if (this.bool_1)
			{
				this.bool_4 = (struct70_.uint_4 & 2) != 0;
				if ((struct70_.uint_4 & 0x20002) == 0)
				{
					this.attribute_2 |= Attribute.SurroundHeader;
				}
				this.bool_3 = (struct70_.uint_4 & 4) != 0;
				if ((struct70_.uint_4 & 0x40004) == 0)
				{
					this.attribute_2 |= Attribute.SurroundFooter;
				}
			}
			this.bool_0 = (struct70_.uint_4 & 8) != 0;
			if ((struct70_.uint_4 & 0x80008) == 0)
			{
				this.attribute_2 |= Attribute.FirstPageOnly;
			}
			this.bool_2 = (struct70_.uint_4 & 0x10) != 0;
			if ((struct70_.uint_4 & 0x100010) == 0)
			{
				this.attribute_2 |= Attribute.OmitFirstPage;
			}
			this.attribute_1 |= Attribute.All;
		}

		internal void method_4()
		{
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated && this.attribute_0 != 0)
			{
				Struct70 struct70_ = new Struct70(-1);
				if ((this.attribute_0 & Attribute.LeftLineWidth) != 0)
				{
					struct70_.short_0 = (short)this.int_4;
				}
				if ((this.attribute_0 & Attribute.TopLineWidth) != 0)
				{
					struct70_.short_1 = (short)this.int_8;
				}
				if ((this.attribute_0 & Attribute.RightLineWidth) != 0)
				{
					struct70_.short_2 = (short)this.int_6;
				}
				if ((this.attribute_0 & Attribute.BottomLineWidth) != 0)
				{
					struct70_.short_3 = (short)this.int_2;
				}
				if ((this.attribute_0 & Attribute.LeftDistance) != 0)
				{
					struct70_.short_4 = (short)this.int_3;
				}
				if ((this.attribute_0 & Attribute.TopDistance) != 0)
				{
					struct70_.short_5 = (short)this.int_7;
				}
				if ((this.attribute_0 & Attribute.RightDistance) != 0)
				{
					struct70_.short_6 = (short)this.int_5;
				}
				if ((this.attribute_0 & Attribute.BottomDistance) != 0)
				{
					struct70_.short_7 = (short)this.int_1;
				}
				if ((this.attribute_0 & Attribute.LeftLineColor) != 0)
				{
					struct70_.uint_0 = KernelHelper.SysDrawingColor2TxColor(this.color_1, bBkGnd: false);
				}
				if ((this.attribute_0 & Attribute.TopLineColor) != 0)
				{
					struct70_.uint_1 = KernelHelper.SysDrawingColor2TxColor(this.color_3, bBkGnd: false);
				}
				if ((this.attribute_0 & Attribute.RightLineColor) != 0)
				{
					struct70_.uint_2 = KernelHelper.SysDrawingColor2TxColor(this.color_2, bBkGnd: false);
				}
				if ((this.attribute_0 & Attribute.BottomLineColor) != 0)
				{
					struct70_.uint_3 = KernelHelper.SysDrawingColor2TxColor(this.color_0, bBkGnd: false);
				}
				if ((this.attribute_0 & Attribute.MeasureFromText) != 0)
				{
					struct70_.uint_4 |= (uint)(this.bool_1 ? 1 : 65536);
				}
				if ((this.attribute_0 & Attribute.SurroundHeader) != 0)
				{
					struct70_.uint_4 |= (uint)(this.bool_4 ? 2 : 131072);
				}
				if ((this.attribute_0 & Attribute.SurroundFooter) != 0)
				{
					struct70_.uint_4 |= (uint)(this.bool_3 ? 4 : 262144);
				}
				if ((this.attribute_0 & Attribute.FirstPageOnly) != 0)
				{
					struct70_.uint_4 |= (uint)(this.bool_0 ? 8 : 524288);
				}
				if ((this.attribute_0 & Attribute.OmitFirstPage) != 0)
				{
					struct70_.uint_4 |= (uint)(this.bool_2 ? 16 : 1048576);
				}
				this.textControlCore_0.method_79(Enum83.const_284, this.int_0, ref struct70_);
				this.attribute_2 &= ~this.attribute_0;
				this.attribute_0 = (Attribute)0;
			}
		}
	}
}
