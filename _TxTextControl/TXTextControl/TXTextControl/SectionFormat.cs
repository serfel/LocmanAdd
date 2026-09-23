using System;
using System.ComponentModel;
using System.Drawing;
using ns21;

namespace TXTextControl
{
	/// <summary>An instance of the SectionFormat class represents the formatting attributes of a section.</summary>
	public class SectionFormat
	{
		/// <summary>Determines a certain section format attribute.</summary>
		public enum Attribute
		{
			/// <summary>Specifies the attribute set through the BreakKind property.</summary>
			BreakKind = 1,
			/// <summary>Specifies the attribute set through the Landscape property.</summary>
			Landscape = 4,
			/// <summary>Specifies the attribute set through the Columns property.</summary>
			Columns = 8,
			/// <summary>Specifies the attribute set through the ColumnWidths property.</summary>
			ColumnWidths = 0x10,
			/// <summary>Specifies the attribute set through the ColumnDistances property.</summary>
			ColumnDistances = 0x20,
			/// <summary>Specifies the attribute set through the ColumnLineWidth property.</summary>
			ColumnLineWidth = 0x40,
			/// <summary>Specifies the attribute set through the ColumnLineColor property.</summary>
			ColumnLineColor = 0x80,
			/// <summary>Specifies the attribute set through the EqualColumnWidth property.</summary>
			EqualColumnWidth = 0x100,
			/// <summary>Specifies the attribute set through the RestartPageNumbering property.</summary>
			RestartPageNumbering = 0x200,
			/// <summary>Specifies all attributes of the SectionFormat.</summary>
			All = 0x3FF
		}

		private Attribute attribute_0;

		private Attribute attribute_1;

		private Attribute attribute_2;

		private TextControlCore textControlCore_0;

		private int int_0;

		private SectionBreakKind sectionBreakKind_0 = SectionBreakKind.BeginAtNewPage;

		private int[] int_1;

		private Color color_0 = SystemColors.WindowText;

		private int int_2;

		private int int_3 = 1;

		private int[] int_4;

		private bool bool_0 = true;

		private bool bool_1;

		internal PageBorder pageBorder_0 = new PageBorder();

		internal PageMargins pageMargins_0 = new PageMargins();

		internal PageSize pageSize_0 = new PageSize();

		private bool bool_2;

		/// <summary>Gets or sets the kind of the section break the section starts with.</summary>
		[Browsable(false)]
		public SectionBreakKind BreakKind
		{
			get
			{
				this.method_3(Attribute.BreakKind);
				return this.sectionBreakKind_0;
			}
			set
			{
				this.sectionBreakKind_0 = value;
				this.attribute_0 |= Attribute.BreakKind;
				this.method_4();
			}
		}

		/// <summary>Gets the distances, in twips, between the columns on a page.</summary>
		[Browsable(false)]
		public int[] ColumnDistances
		{
			get
			{
				this.method_3(Attribute.ColumnDistances);
				return this.int_1;
			}
		}

		/// <summary>Gets or sets the color of a dividing line between two columns.</summary>
		[Browsable(false)]
		public Color ColumnLineColor
		{
			get
			{
				this.method_3(Attribute.ColumnLineColor);
				return this.color_0;
			}
			set
			{
				this.color_0 = value;
				this.attribute_0 |= Attribute.ColumnLineColor;
				this.method_4();
			}
		}

		/// <summary>Gets or sets the width of a dividing line between two columns.</summary>
		[Browsable(false)]
		public int ColumnLineWidth
		{
			get
			{
				this.method_3(Attribute.ColumnLineWidth);
				return this.int_2;
			}
			set
			{
				this.int_2 = value;
				this.attribute_0 |= Attribute.ColumnLineWidth;
				this.method_4();
			}
		}

		/// <summary>Gets or sets the number of columns on a page.</summary>
		[Browsable(false)]
		public int Columns
		{
			get
			{
				this.method_3(Attribute.Columns);
				return this.int_3;
			}
			set
			{
				this.int_3 = value;
				this.attribute_0 |= Attribute.Columns;
				this.method_4();
			}
		}

		/// <summary>Gets the widths, in twips, of the columns on a page.</summary>
		[Browsable(false)]
		public int[] ColumnWidths
		{
			get
			{
				this.method_3(Attribute.ColumnWidths);
				return this.int_4;
			}
		}

		/// <summary>Gets or sets a value indicating whether the columns on a page have all the same width and the same distance between them.</summary>
		[Browsable(false)]
		public bool EqualColumnWidth
		{
			get
			{
				this.method_3(Attribute.EqualColumnWidth);
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
				this.attribute_0 |= Attribute.EqualColumnWidth;
				this.method_4();
			}
		}

		/// <summary>Gets or sets a value indicating whether the section's page size is in landscape orientation.</summary>
		[Browsable(false)]
		public bool Landscape
		{
			get
			{
				this.method_3(Attribute.Landscape);
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
				this.attribute_0 |= Attribute.Landscape;
				this.method_4();
			}
		}

		/// <summary>Gets or sets the attributes of a section's page border.</summary>
		public PageBorder PageBorder
		{
			get
			{
				return this.pageBorder_0;
			}
			set
			{
				value.method_2(this.pageBorder_0);
				this.method_4();
			}
		}

		/// <summary>Gets or sets the section's page margins.</summary>
		public PageMargins PageMargins
		{
			get
			{
				return this.pageMargins_0;
			}
			set
			{
				value.method_3(this.pageMargins_0);
				this.method_4();
			}
		}

		/// <summary>Gets or sets the section's page size.</summary>
		public PageSize PageSize
		{
			get
			{
				return this.pageSize_0;
			}
			set
			{
				value.method_3(this.pageSize_0);
				this.method_4();
			}
		}

		/// <summary>Gets or sets a value indicating whether page numbering is restarted at the section's beginning.</summary>
		public bool RestartPageNumbering
		{
			get
			{
				this.method_3(Attribute.RestartPageNumbering);
				return this.bool_2;
			}
			set
			{
				this.bool_2 = value;
				this.attribute_0 |= Attribute.RestartPageNumbering;
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
				return num + this.pageMargins_0.Int32_0 + this.pageSize_0.Int32_0 + this.pageBorder_0.Int32_0;
			}
		}

		/// <summary>Creates an empty SectionFormat object. Further properties must be set.</summary>
		public SectionFormat()
		{
		}

		/// <summary>Creates a SectionFormat object for a section with equal column widths. The SectionFormat.EqualColumnWidth property is automatically set to true.</summary>
		/// <param name="columns">Specifies the number of columns for the section.</param>
		/// <param name="columnDistance">Specifies the distance between equal columns.</param>
		public SectionFormat(int columns, int columnDistance)
		{
			this.int_3 = columns;
			this.int_1 = new int[1];
			this.int_1[0] = columnDistance;
			this.bool_0 = true;
			this.attribute_0 |= (Attribute)296;
		}

		/// <summary>Creates a SectionFormat object for a section with individual column widths and distances. The SectionFormat.EqualColumnWidth property is automatically set to false.</summary>
		/// <param name="columns">Specifies the number of columns for the section.</param>
		/// <param name="columnWidths">Specifies the widths of the columns.</param>
		/// <param name="columnDistances">Specifies the distances between the columns.</param>
		public SectionFormat(int columns, int[] columnWidths, int[] columnDistances)
		{
			if (columnWidths.Length != columns)
			{
				throw new ArgumentOutOfRangeException("ColumnWidths", this.textControlCore_0.method_83("ERR_PAGECOLUMNWIDTHS"));
			}
			if (columnDistances.Length != columns - 1)
			{
				throw new ArgumentOutOfRangeException("ColumnDistances", this.textControlCore_0.method_83("ERR_PAGECOLUMNDISTANCES"));
			}
			this.int_3 = columns;
			this.int_4 = columnWidths;
			this.int_1 = columnDistances;
			this.bool_0 = false;
			this.attribute_0 |= (Attribute)312;
		}

		internal bool method_0(Attribute attribute_3)
		{
			this.method_3(attribute_3);
			return (this.attribute_2 & attribute_3) == 0;
		}

		internal void method_1(TextControlCore textControlCore_1, int int_5)
		{
			this.textControlCore_0 = textControlCore_1;
			this.int_0 = int_5;
			this.pageMargins_0.method_1(textControlCore_1, int_5);
			this.pageSize_0.method_1(textControlCore_1, int_5);
			this.pageBorder_0.method_1(textControlCore_1, int_5);
		}

		internal void method_2(SectionFormat sectionFormat_0)
		{
			sectionFormat_0.sectionBreakKind_0 = this.sectionBreakKind_0;
			sectionFormat_0.bool_1 = this.bool_1;
			sectionFormat_0.color_0 = this.color_0;
			sectionFormat_0.int_1 = this.int_1;
			sectionFormat_0.int_2 = this.int_2;
			sectionFormat_0.int_3 = this.int_3;
			sectionFormat_0.int_4 = this.int_4;
			sectionFormat_0.bool_0 = this.bool_0;
			sectionFormat_0.bool_2 = this.bool_2;
			this.pageMargins_0.method_3(sectionFormat_0.pageMargins_0);
			this.pageSize_0.method_3(sectionFormat_0.pageSize_0);
			this.pageBorder_0.method_2(sectionFormat_0.pageBorder_0);
			sectionFormat_0.attribute_0 = this.attribute_0;
		}

		private void method_3(Attribute attribute_3)
		{
			if (this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated)
			{
				return;
			}
			if (((attribute_3 & Attribute.BreakKind) != 0 && (this.attribute_1 & Attribute.BreakKind) == 0) || ((attribute_3 & Attribute.Landscape) != 0 && (this.attribute_1 & Attribute.Landscape) == 0) || ((attribute_3 & Attribute.EqualColumnWidth) != 0 && (this.attribute_1 & Attribute.EqualColumnWidth) == 0) || ((attribute_3 & Attribute.RestartPageNumbering) != 0 && (this.attribute_1 & Attribute.RestartPageNumbering) == 0))
			{
				this.attribute_2 &= (Attribute)(-774);
				Enum93 @enum = (Enum93)this.textControlCore_0.method_30(Enum83.const_234, this.int_0, 0);
				this.bool_1 = (@enum & Enum93.const_30) != 0;
				if (((uint)@enum & 0xC0000000u) == 0)
				{
					this.attribute_2 |= Attribute.Landscape;
				}
				this.bool_0 = (@enum & Enum93.const_10) == 0;
				if ((@enum & (Enum93)96u) == 0)
				{
					this.attribute_2 |= Attribute.EqualColumnWidth;
				}
				this.sectionBreakKind_0 = (((@enum & Enum93.const_12) != 0) ? SectionBreakKind.BeginAtNewLine : SectionBreakKind.BeginAtNewPage);
				if ((@enum & (Enum93)768u) == 0)
				{
					this.attribute_2 |= Attribute.BreakKind;
				}
				this.bool_2 = (@enum & Enum93.const_14) != 0;
				if ((@enum & (Enum93)3072u) == 0)
				{
					this.attribute_2 |= Attribute.RestartPageNumbering;
				}
				this.attribute_1 |= (Attribute)773;
			}
			if (((attribute_3 & Attribute.Columns) != 0 && (this.attribute_1 & Attribute.Columns) == 0) || ((attribute_3 & Attribute.ColumnWidths) != 0 && (this.attribute_1 & Attribute.ColumnWidths) == 0) || ((attribute_3 & Attribute.ColumnDistances) != 0 && (this.attribute_1 & Attribute.ColumnDistances) == 0))
			{
				this.attribute_2 &= (Attribute)(-57);
				this.int_3 = this.textControlCore_0.method_30(Enum83.const_251, Class429.smethod_3(0, this.int_0), 0);
				if (this.int_3 == 0)
				{
					this.attribute_2 |= (Attribute)56;
				}
				else if (((attribute_3 & Attribute.ColumnWidths) != 0 && (this.attribute_1 & Attribute.ColumnWidths) == 0) || ((attribute_3 & Attribute.ColumnDistances) != 0 && (this.attribute_1 & Attribute.ColumnDistances) == 0))
				{
					int[] array = new int[2 * this.int_3 - 1];
					this.textControlCore_0.method_41(Enum83.const_251, Class429.smethod_3(this.int_3, this.int_0), array);
					for (int i = 0; i < this.int_3; i++)
					{
						if (array[i] == -1)
						{
							this.attribute_2 |= Attribute.ColumnWidths;
							break;
						}
					}
					this.int_4 = null;
					if ((this.attribute_2 & Attribute.ColumnWidths) == 0)
					{
						this.int_4 = new int[this.int_3];
						Array.Copy(array, this.int_4, this.int_3);
					}
					for (int j = this.int_3; j < 2 * this.int_3 - 1; j++)
					{
						if (array[j] == -1)
						{
							this.attribute_2 |= Attribute.ColumnDistances;
							break;
						}
					}
					this.int_1 = null;
					if ((this.attribute_2 & Attribute.ColumnDistances) == 0)
					{
						this.int_1 = new int[this.int_3 - 1];
						Array.Copy(array, this.int_3, this.int_1, 0, this.int_3 - 1);
					}
					this.attribute_1 |= (Attribute)48;
				}
				this.attribute_1 |= Attribute.Columns;
			}
			if (((attribute_3 & Attribute.ColumnLineWidth) != 0 && (this.attribute_1 & Attribute.ColumnLineWidth) == 0) || ((attribute_3 & Attribute.ColumnLineColor) != 0 && (this.attribute_1 & Attribute.ColumnLineColor) == 0))
			{
				int[] array2 = new int[2];
				this.textControlCore_0.method_41(Enum83.const_256, this.int_0, array2);
				this.int_2 = array2[0];
				if (this.int_2 == -1)
				{
					this.attribute_2 |= Attribute.ColumnLineWidth;
					this.int_2 = 0;
				}
				if (array2[1] == int.MinValue)
				{
					this.attribute_2 |= Attribute.ColumnLineColor;
					this.color_0 = SystemColors.WindowText;
				}
				else
				{
					this.color_0 = Class429.smethod_2(array2[1]);
				}
			}
		}

		internal void method_4()
		{
			int int32_ = this.Int32_0;
			if (this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated || int32_ == 0)
			{
				return;
			}
			if (int32_ > 1)
			{
				this.textControlCore_0.method_10(bool_1: true);
				this.textControlCore_0.method_19(TextPart.Auto, null);
			}
			this.pageMargins_0.method_6();
			this.pageBorder_0.method_4();
			if ((this.attribute_0 & Attribute.BreakKind) != 0 || (this.attribute_0 & Attribute.Landscape) != 0 || (this.attribute_0 & Attribute.EqualColumnWidth) != 0 || (this.attribute_0 & Attribute.RestartPageNumbering) != 0)
			{
				int num = 0;
				if ((this.attribute_0 & Attribute.BreakKind) != 0)
				{
					num |= ((this.sectionBreakKind_0 == SectionBreakKind.BeginAtNewPage) ? 512 : 256);
				}
				if ((this.attribute_0 & Attribute.Landscape) != 0)
				{
					num |= (this.bool_1 ? 1073741824 : int.MinValue);
				}
				if ((this.attribute_0 & Attribute.EqualColumnWidth) != 0)
				{
					num |= (this.bool_0 ? 32 : 64);
				}
				if ((this.attribute_0 & Attribute.RestartPageNumbering) != 0)
				{
					num |= (this.bool_2 ? 1024 : 2048);
				}
				this.textControlCore_0.method_30(Enum83.const_235, this.int_0, num);
			}
			this.pageSize_0.Boolean_0 = this.bool_1;
			this.pageSize_0.method_6();
			if ((this.attribute_0 & Attribute.Columns) != 0)
			{
				bool flag = (((this.attribute_0 & Attribute.EqualColumnWidth) != 0) ? this.bool_0 : this.EqualColumnWidth);
				if ((this.attribute_0 & Attribute.ColumnWidths) == 0)
				{
					flag = true;
				}
				if (this.int_3 == 0)
				{
					throw new ArgumentOutOfRangeException("Columns", this.textControlCore_0.method_83("ERR_PAGECOLUMNS"));
				}
				if (flag)
				{
					int num2 = (((this.attribute_0 & Attribute.ColumnDistances) != 0) ? this.int_1[0] : (-1));
					this.textControlCore_0.method_30(Enum83.const_253, Class429.smethod_3(this.int_3, this.int_0), num2);
				}
				else
				{
					if ((this.attribute_0 & Attribute.ColumnWidths) == 0 || this.int_4.Length != this.int_3)
					{
						throw new ArgumentOutOfRangeException("ColumnWidths", this.textControlCore_0.method_83("ERR_PAGECOLUMNWIDTHS"));
					}
					if ((this.attribute_0 & Attribute.ColumnDistances) == 0 || this.int_1.Length != this.int_3 - 1)
					{
						throw new ArgumentOutOfRangeException("ColumnDistances", this.textControlCore_0.method_83("ERR_PAGECOLUMNDISTANCES"));
					}
					int[] destinationArray = new int[2 * this.int_3 - 1];
					Array.Copy(this.int_4, destinationArray, this.int_3);
					Array.Copy(this.int_1, 0, destinationArray, this.int_3, this.int_3 - 1);
					this.textControlCore_0.method_41(Enum83.const_252, Class429.smethod_3(this.int_3, this.int_0), destinationArray);
				}
			}
			if ((this.attribute_0 & Attribute.ColumnLineWidth) != 0 || (this.attribute_0 & Attribute.ColumnLineColor) != 0)
			{
				int[] array = new int[2]
				{
					((this.attribute_0 & Attribute.ColumnLineWidth) != 0) ? this.int_2 : (-1),
					((this.attribute_0 & Attribute.ColumnLineColor) != 0) ? Class429.smethod_0(this.color_0) : (-2147483648)
				};
				this.textControlCore_0.method_41(Enum83.const_257, this.int_0, array);
			}
			if (int32_ > 1)
			{
				this.textControlCore_0.method_20(TextPart.Auto);
				this.textControlCore_0.method_10(bool_1: false);
			}
			this.attribute_2 &= ~this.attribute_0;
			this.attribute_0 = (Attribute)0;
		}
	}
}
