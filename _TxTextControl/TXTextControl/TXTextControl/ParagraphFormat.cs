using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using ns21;

namespace TXTextControl
{
	/// <summary>An instance of the ParagraphFormat class represents the formatting attributes of a paragraph.</summary>
	[TypeConverter(typeof(Class417))]
	public class ParagraphFormat
	{
		/// <summary>Determines a certain paragraph format attribute.</summary>
		public enum Attribute
		{
			/// <summary>Specifies the attribute set through the Alignment property.</summary>
			Alignment = 1,
			/// <summary>Specifies the attribute set through the LeftIndent property.</summary>
			LeftIndent = 2,
			/// <summary>Specifies the attribute set through the RightIndent property.</summary>
			RightIndent = 4,
			/// <summary>Specifies the attribute set through the TopDistance property.</summary>
			TopDistance = 8,
			/// <summary>Specifies the attribute set through the BottomDistance property.</summary>
			BottomDistance = 0x10,
			/// <summary>Specifies the attribute set through the LineSpacing property.</summary>
			LineSpacing = 0x20,
			/// <summary>Specifies the attribute set through the AbsoluteLineSpacing property.</summary>
			AbsoluteLineSpacing = 0x40,
			/// <summary>Specifies the attribute set through the TabPositions property.</summary>
			TabPositions = 0x80,
			/// <summary>Specifies the attribute set through the TabTypes property.</summary>
			TabTypes = 0x100,
			/// <summary>Specifies the attribute set through the Frame property.</summary>
			Frame = 0x200,
			/// <summary>Specifies the attribute set through the FrameStyle property.</summary>
			FrameStyle = 0x400,
			/// <summary>Specifies the attribute set through the FrameLineWidth property.</summary>
			FrameLineWidth = 0x800,
			/// <summary>Specifies the attribute set through the FrameDistance property.</summary>
			FrameDistance = 0x1000,
			/// <summary>Specifies the attribute set through the HangingIndent property.</summary>
			HangingIndent = 0x2000,
			/// <summary>Specifies the attribute set through the KeepLinesTogether property.</summary>
			KeepLinesTogether = 0x4000,
			/// <summary>Specifies the attribute set through the KeepWithNext property.</summary>
			KeepWithNext = 0x8000,
			/// <summary>Specifies the attribute set through the PageBreakBefore property.</summary>
			PageBreakBefore = 0x10000,
			/// <summary>Specifies the attribute set through the WidowOrphanLines property.</summary>
			WidowOrphanLines = 0x20000,
			/// <summary>Specifies the attribute set through the Direction property.</summary>
			Direction = 0x40000,
			/// <summary>Specifies the attribute set through the Justification property.</summary>
			Justification = 0x80000,
			/// <summary>Specifies the attribute set through the BackColor property.</summary>
			BackColor = 0x100000,
			/// <summary>Specifies the attribute set through the FrameLineColor property.</summary>
			FrameLineColor = 0x200000,
			TabLeaders = 0x400000,
			/// <summary>Specifies the attribute set through the StructureLevel property.</summary>
			StructureLevel = 0x800000,
			/// <summary>Specifies all attributes of the ParagraphFormat.</summary>
			All = 0xFFFFFF
		}

		private const int int_0 = 1134;

		internal const int int_1 = 20;

		/// <summary>Represents the maximum number of tabs in a line.</summary>
		public const int MaxTabs = 14;

		public const int MaxLevel = 10;

		private int int_2 = -1;

		private Attribute attribute_0;

		private Attribute attribute_1;

		private Attribute attribute_2;

		private TextControlCore textControlCore_0;

		private TextPart textPart_0;

		private HorizontalAlignment horizontalAlignment_0 = HorizontalAlignment.Left;

		private int int_3;

		private int int_4;

		private int int_5;

		private int int_6;

		private int int_7;

		private int int_8 = 100;

		private int int_9;

		private int[] int_10 = new int[14];

		private int[] int_11 = new int[14];

		private TabType[] tabType_0 = new TabType[14];

		private TabLeader[] tabLeader_0 = new TabLeader[14];

		private Frame frame_0 = Frame.None;

		private FrameStyle frameStyle_0 = FrameStyle.Single;

		private int int_12 = 20;

		private Color color_0 = SystemColors.WindowText;

		private Color color_1 = Color.Transparent;

		private int int_13;

		private bool bool_0;

		private bool bool_1;

		private bool bool_2;

		private int int_14;

		private Direction direction_0 = Direction.LeftToRight;

		private Justification justification_0 = Justification.Spaces;

		private int int_15;

		/// <summary>Gets or sets the line spacing of a paragraph in twips.</summary>
		[Browsable(false)]
		[DefaultValue(0)]
		public int AbsoluteLineSpacing
		{
			get
			{
				this.method_10(Attribute.AbsoluteLineSpacing);
				return this.int_9;
			}
			set
			{
				if (value < 20 || value > 32000)
				{
					throw new ArgumentOutOfRangeException();
				}
				this.int_9 = value;
				this.attribute_0 |= Attribute.AbsoluteLineSpacing;
				this.int_8 = 100;
				this.attribute_0 &= (Attribute)(-33);
				this.method_11();
			}
		}

		/// <summary>Gets or sets the horizontal text alignment.</summary>
		[Attribute3("PROP_PARA_ALIGNMENT")]
		[DefaultValue(HorizontalAlignment.Left)]
		public HorizontalAlignment Alignment
		{
			get
			{
				this.method_10(Attribute.Alignment);
				return this.horizontalAlignment_0;
			}
			set
			{
				this.horizontalAlignment_0 = value;
				this.attribute_0 |= Attribute.Alignment;
				this.method_11();
			}
		}

		/// <summary>Gets or sets the background color of a paragraph.</summary>
		[Attribute3("PROP_PARA_BACKCOLOR")]
		public Color BackColor
		{
			get
			{
				this.method_10(Attribute.BackColor);
				return this.color_1;
			}
			set
			{
				this.color_1 = value;
				this.attribute_0 |= Attribute.BackColor;
				this.method_11();
			}
		}

		/// <summary>Gets or sets the bottom distance, in twips, between this and the next paragraph.</summary>
		[DefaultValue(0)]
		[Attribute3("PROP_PARA_BOTTOMDISTANCE")]
		public int BottomDistance
		{
			get
			{
				this.method_10(Attribute.BottomDistance);
				return this.int_7;
			}
			set
			{
				ParagraphFormat.smethod_0(this.int_3, this.int_4, this.int_5, this.int_6, value);
				this.int_7 = value;
				this.attribute_0 |= Attribute.BottomDistance;
				this.method_11();
			}
		}

		/// <summary>Gets or sets the writing direction.</summary>
		[DefaultValue(Direction.LeftToRight)]
		[Attribute3("PROP_PARA_DIRECTION")]
		public Direction Direction
		{
			get
			{
				this.method_10(Attribute.Direction);
				return this.direction_0;
			}
			set
			{
				this.direction_0 = value;
				this.attribute_0 |= Attribute.Direction;
				this.method_11();
			}
		}

		/// <summary>Gets or sets a frame around the paragraph.</summary>
		[Attribute3("PROP_PARA_FRAME")]
		[DefaultValue(Frame.None)]
		public Frame Frame
		{
			get
			{
				this.method_10(Attribute.Frame);
				return this.frame_0;
			}
			set
			{
				this.frame_0 = value;
				this.attribute_0 |= Attribute.Frame;
				this.method_11();
			}
		}

		/// <summary>Gets or sets the style of the paragraph's frame.</summary>
		[Attribute3("PROP_PARA_FRAMESTYLE")]
		[DefaultValue(FrameStyle.Single)]
		public FrameStyle FrameStyle
		{
			get
			{
				this.method_10(Attribute.FrameStyle);
				return this.frameStyle_0;
			}
			set
			{
				this.frameStyle_0 = value;
				this.attribute_0 |= Attribute.FrameStyle;
				this.method_11();
			}
		}

		/// <summary>Gets or sets the color used for the frame lines of a paragraph.</summary>
		[Attribute3("PROP_PARA_FRAMELINECOLOR")]
		public Color FrameLineColor
		{
			get
			{
				this.method_10(Attribute.FrameLineColor);
				return this.color_0;
			}
			set
			{
				this.color_0 = value;
				this.attribute_0 |= Attribute.FrameLineColor;
				this.method_11();
			}
		}

		/// <summary>Gets or sets the line width, in twips, of the paragraph's frame.</summary>
		[DefaultValue(20)]
		[Attribute3("PROP_PARA_FRAMELINEWIDTH")]
		public int FrameLineWidth
		{
			get
			{
				this.method_10(Attribute.FrameLineWidth);
				return this.int_12;
			}
			set
			{
				if (value <= 0 || value > 32767)
				{
					throw new ArgumentOutOfRangeException();
				}
				this.int_12 = value;
				this.attribute_0 |= Attribute.FrameLineWidth;
				this.method_11();
			}
		}

		/// <summary>Gets or sets the distance, in twips, between the text and the paragraph's frame.</summary>
		[DefaultValue(0)]
		[Attribute3("PROP_PARA_FRAMEDISTANCE")]
		public int FrameDistance
		{
			get
			{
				this.method_10(Attribute.FrameDistance);
				return this.int_13;
			}
			set
			{
				if (value < 0 || value > 32767)
				{
					throw new ArgumentOutOfRangeException();
				}
				this.int_13 = value;
				this.attribute_0 |= Attribute.FrameDistance;
				this.method_11();
			}
		}

		/// <summary>Gets or sets the distance, in twips, for the hanging indent.</summary>
		[Attribute3("PROP_PARA_HANGINGINDENT")]
		[DefaultValue(0)]
		public int HangingIndent
		{
			get
			{
				this.method_10(Attribute.HangingIndent);
				return this.int_4;
			}
			set
			{
				ParagraphFormat.smethod_0(this.int_3, value, this.int_5, this.int_6, this.int_7);
				this.int_4 = value;
				this.attribute_0 |= Attribute.HangingIndent;
				this.method_11();
			}
		}

		/// <summary>Gets or sets the kind of justification in documents containing Arabic or Hebrew characters.</summary>
		[DefaultValue(Justification.Spaces)]
		[Attribute3("PROP_PARA_JUSTIFICATION")]
		public Justification Justification
		{
			get
			{
				this.method_10(Attribute.Justification);
				return this.justification_0;
			}
			set
			{
				this.justification_0 = value;
				this.attribute_0 |= Attribute.Justification;
				this.method_11();
			}
		}

		/// <summary>Gets or sets a value indicating whether a page break is allowed within the paragraph.</summary>
		[DefaultValue(false)]
		[Attribute3("PROP_PARA_KEEPLINESTOGETHER")]
		public bool KeepLinesTogether
		{
			get
			{
				this.method_10(Attribute.KeepLinesTogether);
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
				this.attribute_0 |= Attribute.KeepLinesTogether;
				this.method_11();
			}
		}

		/// <summary>If this property is set to true, the paragraph is displayed on the same page as its following paragraph.</summary>
		[Attribute3("PROP_PARA_KEEPWITHNEXT")]
		[DefaultValue(false)]
		public bool KeepWithNext
		{
			get
			{
				this.method_10(Attribute.KeepWithNext);
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
				this.attribute_0 |= Attribute.KeepWithNext;
				this.method_11();
			}
		}

		/// <summary>Gets or sets the distance, in twips, between the left edge of the Text Control and the left edge of the text.</summary>
		[DefaultValue(0)]
		[Attribute3("PROP_PARA_LEFTINDENT")]
		public int LeftIndent
		{
			get
			{
				this.method_10(Attribute.LeftIndent);
				return this.int_3;
			}
			set
			{
				ParagraphFormat.smethod_0(value, this.int_4, this.int_5, this.int_6, this.int_7);
				this.int_3 = value;
				this.attribute_0 |= Attribute.LeftIndent;
				this.method_11();
			}
		}

		/// <summary>Specifies the line spacing of a paragraph as a percentage of the font size.</summary>
		[Attribute3("PROP_PARA_LINESPACING")]
		[DefaultValue(100)]
		public int LineSpacing
		{
			get
			{
				this.method_10(Attribute.LineSpacing);
				return this.int_8;
			}
			set
			{
				if (value < 1 || value > 10000)
				{
					throw new ArgumentOutOfRangeException();
				}
				this.int_8 = value;
				this.attribute_0 |= Attribute.LineSpacing;
				this.int_9 = 0;
				this.attribute_0 &= (Attribute)(-65);
				this.method_11();
			}
		}

		/// <summary>If this property is set to true, the paragraph is always displayed on top of a page.</summary>
		[DefaultValue(false)]
		[Attribute3("PROP_PARA_PAGEBREAKBEFORE")]
		public bool PageBreakBefore
		{
			get
			{
				this.method_10(Attribute.PageBreakBefore);
				return this.bool_2;
			}
			set
			{
				this.bool_2 = value;
				this.attribute_0 |= Attribute.PageBreakBefore;
				this.method_11();
			}
		}

		/// <summary>Gets or sets the distance, in twips, between the right edge of a Text Control document and the right edge of the text.</summary>
		[DefaultValue(0)]
		[Attribute3("PROP_PARA_RIGHTINDENT")]
		public int RightIndent
		{
			get
			{
				this.method_10(Attribute.RightIndent);
				return this.int_5;
			}
			set
			{
				ParagraphFormat.smethod_0(this.int_3, this.int_4, value, this.int_6, this.int_7);
				this.int_5 = value;
				this.attribute_0 |= Attribute.RightIndent;
				this.method_11();
			}
		}

		/// <summary>Gets or sets the structure level of a paragraph in the document.</summary>
		[DefaultValue(0)]
		[Attribute3("PROP_PARA_STRUCTURELEVEL")]
		public int StructureLevel
		{
			get
			{
				this.method_10(Attribute.StructureLevel);
				return this.int_15;
			}
			set
			{
				if (value < 0 || value > 10)
				{
					throw new ArgumentOutOfRangeException();
				}
				this.int_15 = value;
				this.attribute_0 |= Attribute.StructureLevel;
				this.method_11();
			}
		}

		/// <summary>Gets or sets an array containing the tab leaders in a paragraph.</summary>
		[Attribute3("PROP_PARA_TABLEADERS")]
		public TabLeader[] TabLeaders
		{
			get
			{
				this.method_10(Attribute.TabLeaders);
				return (TabLeader[])this.tabLeader_0.Clone();
			}
			set
			{
				value.CopyTo(this.tabLeader_0, 0);
				this.attribute_0 |= Attribute.TabLeaders;
				this.method_11();
			}
		}

		/// <summary>Gets or sets an array containing the absolute tab stop positions, in twips, in a paragraph.</summary>
		[Attribute3("PROP_PARA_TABPOSITIONS")]
		public int[] TabPositions
		{
			get
			{
				this.method_10(Attribute.TabPositions);
				return (int[])this.int_10.Clone();
			}
			set
			{
				for (int i = 0; i < 14; i++)
				{
					if (value[i] < 0 || value[i] > 32767)
					{
						throw new ArgumentOutOfRangeException();
					}
				}
				value.CopyTo(this.int_10, 0);
				this.attribute_0 |= Attribute.TabPositions;
				this.method_11();
			}
		}

		/// <summary>Gets or sets an array containing the tab types in a paragraph.</summary>
		[Attribute3("PROP_PARA_TABTYPES")]
		public TabType[] TabTypes
		{
			get
			{
				this.method_10(Attribute.TabTypes);
				return (TabType[])this.tabType_0.Clone();
			}
			set
			{
				value.CopyTo(this.tabType_0, 0);
				this.attribute_0 |= Attribute.TabTypes;
				this.method_11();
			}
		}

		/// <summary>Gets or sets a top distance, in twips, between this and the previous paragraph.</summary>
		[DefaultValue(0)]
		[Attribute3("PROP_PARA_TOPDISTANCE")]
		public int TopDistance
		{
			get
			{
				this.method_10(Attribute.TopDistance);
				return this.int_6;
			}
			set
			{
				ParagraphFormat.smethod_0(this.int_3, this.int_4, this.int_5, value, this.int_7);
				this.int_6 = value;
				this.attribute_0 |= Attribute.TopDistance;
				this.method_11();
			}
		}

		/// <summary>Gets or sets the number of lines for widow/orphan control.</summary>
		[Attribute3("PROP_PARA_WIDOWORPHANLINES")]
		[DefaultValue(0)]
		public int WidowOrphanLines
		{
			get
			{
				this.method_10(Attribute.WidowOrphanLines);
				return this.int_14;
			}
			set
			{
				if (value < 0 || value > 3)
				{
					throw new ArgumentOutOfRangeException();
				}
				this.int_14 = value;
				this.attribute_0 |= Attribute.WidowOrphanLines;
				this.method_11();
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

		/// <summary>Creates an empty ParagraphFormat object with all properties set to their default values.</summary>
		public ParagraphFormat()
		{
			this.method_5();
		}

		/// <summary>Creates a new ParagraphFormat object with the specified horizontal alignment. All other properties are set to their default values.</summary>
		/// <param name="alignment">Specifies one of the HorizontalAlignment values.</param>
		public ParagraphFormat(HorizontalAlignment alignment)
		{
			this.method_5();
			this.Alignment = alignment;
			this.attribute_0 |= Attribute.Alignment;
		}

		internal ParagraphFormat(int iPosition)
		{
			this.method_5();
			this.int_2 = iPosition;
		}

		public bool ShouldSerializeBackColor()
		{
			return this.color_1 != Color.Transparent;
		}

		public void ResetBackColor()
		{
			this.BackColor = Color.Transparent;
		}

		public bool ShouldSerializeFrameLineColor()
		{
			return this.color_0 != SystemColors.WindowText;
		}

		public void ResetFrameLineColor()
		{
			this.FrameLineColor = SystemColors.WindowText;
		}

		public bool ShouldSerializeTabLeaders()
		{
			int num = 0;
			while (true)
			{
				if (num < 14)
				{
					if (this.tabLeader_0[num] != 0)
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}

		public void ResetTabLeaders()
		{
			for (int i = 0; i < 14; i++)
			{
				this.tabLeader_0[i] = TabLeader.None;
			}
		}

		public bool ShouldSerializeTabPositions()
		{
			int num = 0;
			while (true)
			{
				if (num < 14)
				{
					if (this.int_10[num] != this.int_11[num])
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}

		public void ResetTabPositions()
		{
			this.int_11.CopyTo(this.int_10, 0);
		}

		public bool ShouldSerializeTabTypes()
		{
			int num = 0;
			while (true)
			{
				if (num < 14)
				{
					if (this.tabType_0[num] != TabType.LeftTab)
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}

		public void ResetTabTypes()
		{
			for (int i = 0; i < 14; i++)
			{
				this.tabType_0[i] = TabType.LeftTab;
			}
		}

		internal bool method_0()
		{
			if (this.horizontalAlignment_0 == HorizontalAlignment.Left && this.int_3 == 0 && this.int_4 == 0 && this.int_5 == 0 && this.int_6 == 0 && this.int_7 == 0 && this.int_8 == 100 && !this.ShouldSerializeTabPositions() && !this.ShouldSerializeTabTypes() && !this.ShouldSerializeTabLeaders() && this.frame_0 == Frame.None && this.frameStyle_0 == FrameStyle.Single && this.int_12 == 20 && this.int_13 == 0 && !this.bool_0 && !this.bool_1 && !this.bool_2 && this.int_14 == 0 && this.direction_0 == Direction.LeftToRight && this.justification_0 == Justification.Spaces && this.color_0 == SystemColors.WindowText && this.color_1 == Color.Transparent)
			{
				return this.int_15 == 0;
			}
			return false;
		}

		internal void method_1(TextControlCore textControlCore_1, TextPart textPart_1)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = textPart_1;
		}

		internal void method_2(TextControlCore textControlCore_1, TextPart textPart_1, int int_16)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = textPart_1;
			this.int_2 = int_16;
		}

		internal void method_3(ParagraphFormat paragraphFormat_0)
		{
			paragraphFormat_0.attribute_0 = this.attribute_0;
			paragraphFormat_0.horizontalAlignment_0 = this.horizontalAlignment_0;
			paragraphFormat_0.int_3 = this.int_3;
			paragraphFormat_0.int_4 = this.int_4;
			paragraphFormat_0.int_5 = this.int_5;
			paragraphFormat_0.int_6 = this.int_6;
			paragraphFormat_0.int_7 = this.int_7;
			paragraphFormat_0.int_8 = this.int_8;
			paragraphFormat_0.int_9 = this.int_9;
			this.int_10.CopyTo(paragraphFormat_0.int_10, 0);
			this.tabType_0.CopyTo(paragraphFormat_0.tabType_0, 0);
			this.tabLeader_0.CopyTo(paragraphFormat_0.tabLeader_0, 0);
			paragraphFormat_0.frame_0 = this.frame_0;
			paragraphFormat_0.frameStyle_0 = this.frameStyle_0;
			paragraphFormat_0.int_12 = this.int_12;
			paragraphFormat_0.int_13 = this.int_13;
			paragraphFormat_0.bool_0 = this.bool_0;
			paragraphFormat_0.bool_1 = this.bool_1;
			paragraphFormat_0.bool_2 = this.bool_2;
			paragraphFormat_0.int_14 = this.int_14;
			paragraphFormat_0.direction_0 = this.direction_0;
			paragraphFormat_0.justification_0 = this.justification_0;
			paragraphFormat_0.color_0 = this.color_0;
			paragraphFormat_0.color_1 = this.color_1;
			paragraphFormat_0.int_15 = this.int_15;
		}

		internal bool method_4(Attribute attribute_3)
		{
			return (this.attribute_0 & attribute_3) != 0;
		}

		internal void method_5()
		{
			for (int i = 0; i < 14; i++)
			{
				this.int_11[i] = (i + 1) * 1134;
			}
			this.horizontalAlignment_0 = HorizontalAlignment.Left;
			this.int_3 = 0;
			this.int_4 = 0;
			this.int_5 = 0;
			this.int_6 = 0;
			this.int_7 = 0;
			this.int_8 = 100;
			this.int_9 = 0;
			this.ResetTabPositions();
			this.ResetTabTypes();
			this.ResetTabLeaders();
			this.frame_0 = Frame.None;
			this.frameStyle_0 = FrameStyle.Single;
			this.int_12 = 20;
			this.int_13 = 0;
			this.bool_0 = false;
			this.bool_1 = false;
			this.bool_2 = false;
			this.int_14 = 0;
			this.direction_0 = Direction.LeftToRight;
			this.justification_0 = Justification.Spaces;
			this.color_0 = SystemColors.WindowText;
			this.color_1 = Color.Transparent;
			this.int_15 = 0;
		}

		internal bool method_6(Attribute attribute_3)
		{
			this.method_10(attribute_3);
			return (this.attribute_2 & attribute_3) == 0;
		}

		internal void method_7()
		{
			this.method_5();
			this.attribute_0 = Attribute.All;
			this.method_11();
		}

		internal void method_8()
		{
			this.attribute_0 = (Attribute)0;
		}

		internal void method_9()
		{
			this.attribute_0 = Attribute.All;
		}

		internal static void smethod_0(int int_16, int int_17, int int_18, int int_19, int int_20)
		{
			TxError txError = TxError.ERR_NOERROR;
			if (int_16 < 0 || int_16 > 32767)
			{
				txError = TxError.ERR_INDENT;
			}
			if (int_17 > 32767)
			{
				txError = TxError.ERR_INDENT;
			}
			if (int_18 < 0 || int_18 > 32767)
			{
				txError = TxError.ERR_INDENT;
			}
			if (int_19 < 0 || int_19 > 32767)
			{
				txError = TxError.ERR_INDENT;
			}
			if (int_20 < 0 || int_20 > 32767)
			{
				txError = TxError.ERR_INDENT;
			}
			if (int_16 + int_17 < 0)
			{
				txError = TxError.ERR_INDENT;
			}
			if (txError != 0)
			{
				ResourceManager resourceManager = new ResourceManager(typeof(TextControlCore));
				throw new ArgumentOutOfRangeException(resourceManager.GetString(txError.ToString()));
			}
		}

		private void method_10(Attribute attribute_3)
		{
			if (this.int_2 == 0 || this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated)
			{
				return;
			}
			if (this.int_2 > 0)
			{
				this.textControlCore_0.method_14(this.textPart_0, this.int_2 - 1, 0);
			}
			if ((attribute_3 & Attribute.Alignment) != 0 && (this.attribute_1 & Attribute.Alignment) == 0)
			{
				int num = this.textControlCore_0.method_29(this.textPart_0, 1127, 0, 0);
				this.attribute_2 &= (Attribute)(-2);
				switch (num)
				{
				case 1:
				case 2:
				case 3:
				case 4:
					this.horizontalAlignment_0 = (HorizontalAlignment)num;
					break;
				case 5:
					this.horizontalAlignment_0 = HorizontalAlignment.Left;
					this.attribute_2 |= Attribute.Alignment;
					break;
				}
				this.attribute_1 |= Attribute.Alignment;
			}
			if ((attribute_3 & Attribute.StructureLevel) != 0 && (this.attribute_1 & Attribute.StructureLevel) == 0)
			{
				this.int_15 = this.textControlCore_0.method_29(this.textPart_0, 2014, 0, 0);
				this.attribute_2 &= (Attribute)(-8388609);
				if (this.int_15 == -1)
				{
					this.int_15 = 0;
					this.attribute_2 |= Attribute.StructureLevel;
				}
				this.attribute_1 |= Attribute.StructureLevel;
			}
			if (((attribute_3 & Attribute.LeftIndent) != 0 && (this.attribute_1 & Attribute.LeftIndent) == 0) || ((attribute_3 & Attribute.RightIndent) != 0 && (this.attribute_1 & Attribute.RightIndent) == 0) || ((attribute_3 & Attribute.HangingIndent) != 0 && (this.attribute_1 & Attribute.HangingIndent) == 0) || ((attribute_3 & Attribute.TopDistance) != 0 && (this.attribute_1 & Attribute.TopDistance) == 0) || ((attribute_3 & Attribute.BottomDistance) != 0 && (this.attribute_1 & Attribute.BottomDistance) == 0))
			{
				int[] array = new int[5];
				if (this.textControlCore_0.method_40(this.textPart_0, 1144, 0, array) != 0)
				{
					this.attribute_2 &= (Attribute)(-8223);
					if (array[0] != 32768 && array[2] != 32768)
					{
						this.int_3 = array[0] + array[2];
						this.int_4 = -array[2];
					}
					else
					{
						this.int_3 = 0;
						this.int_4 = 0;
						this.attribute_2 |= (Attribute)8194;
					}
					this.int_5 = array[1];
					this.int_6 = array[3];
					this.int_7 = array[4];
					if (this.int_5 == 32768)
					{
						this.attribute_2 |= Attribute.RightIndent;
						this.int_5 = 0;
					}
					if (this.int_6 == 32768)
					{
						this.attribute_2 |= Attribute.TopDistance;
						this.int_6 = 0;
					}
					if (this.int_7 == 32768)
					{
						this.attribute_2 |= Attribute.BottomDistance;
						this.int_7 = 0;
					}
					this.attribute_1 |= (Attribute)8222;
				}
			}
			if (((attribute_3 & Attribute.LineSpacing) != 0 && (this.attribute_1 & Attribute.LineSpacing) == 0) || ((attribute_3 & Attribute.AbsoluteLineSpacing) != 0 && (this.attribute_1 & Attribute.AbsoluteLineSpacing) == 0))
			{
				int num2 = this.textControlCore_0.method_29(this.textPart_0, 1138, 0, 0);
				this.int_8 = Class429.smethod_5(num2);
				this.int_9 = Class429.smethod_6(num2);
				this.attribute_2 &= (Attribute)(-97);
				if (this.int_8 == 0)
				{
					this.attribute_2 |= Attribute.LineSpacing;
					this.int_8 = 100;
				}
				if (this.int_9 == 0)
				{
					this.attribute_2 |= Attribute.AbsoluteLineSpacing;
				}
				this.attribute_1 |= (Attribute)96;
			}
			if (((attribute_3 & Attribute.Frame) != 0 && (this.attribute_1 & Attribute.Frame) == 0) || ((attribute_3 & Attribute.FrameStyle) != 0 && (this.attribute_1 & Attribute.FrameStyle) == 0) || ((attribute_3 & Attribute.FrameLineWidth) != 0 && (this.attribute_1 & Attribute.FrameLineWidth) == 0) || ((attribute_3 & Attribute.FrameDistance) != 0 && (this.attribute_1 & Attribute.FrameDistance) == 0))
			{
				int[] array2 = new int[1];
				int num3 = this.textControlCore_0.method_40(this.textPart_0, 1153, 0, array2);
				this.frame_0 = (Frame)(num3 & 0x8F);
				if (this.frame_0 == (Frame)0 && (num3 & 0x8F0000) == 9371648)
				{
					this.frame_0 = Frame.None;
				}
				this.frameStyle_0 = (FrameStyle)(num3 & 0x60);
				this.int_12 = Class429.smethod_5(array2[0]);
				this.int_13 = Class429.smethod_6(array2[0]);
				this.attribute_2 &= (Attribute)(-7681);
				if (this.frame_0 == (Frame)0)
				{
					this.attribute_2 |= Attribute.Frame;
					this.frame_0 = Frame.None;
				}
				if (this.frameStyle_0 == (FrameStyle)0)
				{
					this.attribute_2 |= Attribute.FrameStyle;
					this.frameStyle_0 = FrameStyle.Single;
				}
				if (this.int_12 == 0)
				{
					this.attribute_2 |= Attribute.FrameLineWidth;
					this.int_12 = 20;
				}
				if (this.int_13 == 65535)
				{
					this.attribute_2 |= Attribute.FrameDistance;
					this.int_13 = 0;
				}
				this.attribute_1 |= (Attribute)7680;
			}
			if (((attribute_3 & Attribute.FrameLineColor) != 0 && (this.attribute_1 & Attribute.FrameLineColor) == 0) || ((attribute_3 & Attribute.BackColor) != 0 && (this.attribute_1 & Attribute.BackColor) == 0))
			{
				int[] array3 = new int[2];
				int[] array4 = array3;
				this.textControlCore_0.method_40(this.textPart_0, 1984, 0, array4);
				this.attribute_2 &= (Attribute)(-3145729);
				if (array4[0] == int.MinValue)
				{
					this.attribute_2 |= Attribute.BackColor;
					this.color_1 = Color.Transparent;
				}
				else
				{
					this.color_1 = KernelHelper.TxColor2SysDrawingColor((uint)array4[0], bBkGnd: true);
				}
				if (array4[1] == int.MinValue)
				{
					this.attribute_2 |= Attribute.FrameLineColor;
					this.color_0 = SystemColors.WindowText;
				}
				else
				{
					this.color_0 = KernelHelper.TxColor2SysDrawingColor((uint)array4[1], bBkGnd: false);
				}
				this.attribute_1 |= (Attribute)3145728;
			}
			if (((attribute_3 & Attribute.KeepLinesTogether) != 0 && (this.attribute_1 & Attribute.KeepLinesTogether) == 0) || ((attribute_3 & Attribute.KeepWithNext) != 0 && (this.attribute_1 & Attribute.KeepWithNext) == 0) || ((attribute_3 & Attribute.PageBreakBefore) != 0 && (this.attribute_1 & Attribute.PageBreakBefore) == 0) || ((attribute_3 & Attribute.WidowOrphanLines) != 0 && (this.attribute_1 & Attribute.WidowOrphanLines) == 0) || ((attribute_3 & Attribute.Direction) != 0 && (this.attribute_1 & Attribute.Direction) == 0) || ((attribute_3 & Attribute.Justification) != 0 && (this.attribute_1 & Attribute.Justification) == 0))
			{
				Enum97 @enum = (Enum97)this.textControlCore_0.method_29(this.textPart_0, 1207, 0, 0);
				this.attribute_2 &= (Attribute)(-1032193);
				this.bool_0 = (@enum & Enum97.const_0) != 0;
				if ((@enum & (Enum97)65537) == 0)
				{
					this.attribute_2 |= Attribute.KeepLinesTogether;
				}
				this.bool_1 = (@enum & Enum97.const_2) != 0;
				if ((@enum & (Enum97)524296) == 0)
				{
					this.attribute_2 |= Attribute.KeepWithNext;
				}
				this.bool_2 = (@enum & Enum97.const_3) != 0;
				if ((@enum & (Enum97)1048592) == 0)
				{
					this.attribute_2 |= Attribute.PageBreakBefore;
				}
				this.int_14 = (((@enum & Enum97.const_4) != 0) ? 1 : (((@enum & Enum97.const_5) != 0) ? 2 : (((@enum & Enum97.const_6) != 0) ? 3 : 0)));
				if (this.int_14 == 0 && (@enum & Enum97.const_18) != Enum97.const_18)
				{
					this.attribute_2 |= Attribute.WidowOrphanLines;
				}
				this.direction_0 = (((@enum & Enum97.const_8) == 0) ? Direction.LeftToRight : Direction.RightToLeft);
				if ((@enum & (Enum97)16777472) == 0)
				{
					this.attribute_2 |= Attribute.Direction;
				}
				this.justification_0 = (((@enum & Enum97.const_21) != 0 && (@enum & Enum97.const_20) != 0) ? Justification.Spaces : (((@enum & Enum97.const_9) != 0 && (@enum & Enum97.const_10) != 0) ? Justification.Kashida : (((@enum & Enum97.const_9) == 0 || (@enum & Enum97.const_21) == 0) ? Justification.Spaces : Justification.SpacesAndKashida)));
				if ((@enum & (Enum97)100664832) == 0)
				{
					this.attribute_2 |= Attribute.Justification;
				}
				this.attribute_1 |= (Attribute)1032192;
			}
			if (((attribute_3 & Attribute.TabLeaders) != 0 && (this.attribute_1 & Attribute.TabLeaders) == 0) || ((attribute_3 & Attribute.TabPositions) != 0 && (this.attribute_1 & Attribute.TabPositions) == 0) || ((attribute_3 & Attribute.TabTypes) != 0 && (this.attribute_1 & Attribute.TabTypes) == 0))
			{
				byte[] array5 = new byte[56];
				this.textControlCore_0.method_42(this.textPart_0, 2012, 1, array5);
				for (int i = 0; i < 14; i++)
				{
					this.tabType_0[i] = (TabType)array5[i * 4];
					this.int_10[i] = Class429.smethod_4(array5[i * 4 + 1], array5[i * 4 + 2]);
					this.tabLeader_0[i] = (TabLeader)array5[i * 4 + 3];
				}
				this.attribute_1 |= (Attribute)4194688;
				this.attribute_2 &= (Attribute)(-4194689);
				if (this.tabType_0[0] == (TabType)0)
				{
					this.attribute_2 |= (Attribute)4194688;
				}
				for (int j = 0; j < 14; j++)
				{
					if (this.tabLeader_0[j] == (TabLeader)255)
					{
						this.attribute_2 |= Attribute.TabLeaders;
					}
				}
			}
			if (this.int_2 > 0)
			{
				this.textControlCore_0.method_15(this.textPart_0);
			}
		}

		internal void method_11()
		{
			if (this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated || this.attribute_0 == (Attribute)0)
			{
				return;
			}
			switch (this.int_2)
			{
			default:
				this.textControlCore_0.method_14(this.textPart_0, this.int_2 - 1, 0);
				break;
			case 0:
				this.textControlCore_0.method_12(this.textPart_0);
				break;
			case -1:
				break;
			}
			this.attribute_2 &= ~this.attribute_0;
			if ((this.attribute_0 & Attribute.Alignment) != 0)
			{
				this.textControlCore_0.method_29(this.textPart_0, 1155, (int)this.horizontalAlignment_0, 0);
			}
			if ((this.attribute_0 & Attribute.StructureLevel) != 0)
			{
				this.textControlCore_0.method_29(this.textPart_0, 2015, this.int_15, 0);
			}
			if ((this.attribute_0 & Attribute.LeftIndent) != 0 || (this.attribute_0 & Attribute.RightIndent) != 0 || (this.attribute_0 & Attribute.HangingIndent) != 0 || (this.attribute_0 & Attribute.TopDistance) != 0 || (this.attribute_0 & Attribute.BottomDistance) != 0)
			{
				int[] array = new int[5] { 32768, 32768, 32768, 32768, 32768 };
				if ((this.attribute_0 & Attribute.LeftIndent) != 0 || (this.attribute_0 & Attribute.HangingIndent) != 0)
				{
					array[0] = this.int_3 + this.int_4;
				}
				if ((this.attribute_0 & Attribute.RightIndent) != 0)
				{
					array[1] = this.int_5;
				}
				if ((this.attribute_0 & Attribute.HangingIndent) != 0)
				{
					array[2] = -this.int_4;
				}
				if ((this.attribute_0 & Attribute.TopDistance) != 0)
				{
					array[3] = this.int_6;
				}
				if ((this.attribute_0 & Attribute.BottomDistance) != 0)
				{
					array[4] = this.int_7;
				}
				this.textControlCore_0.method_40(this.textPart_0, 1163, 0, array);
			}
			if ((this.attribute_0 & Attribute.LineSpacing) != 0)
			{
				this.textControlCore_0.method_29(this.textPart_0, 1161, this.int_8, 0);
			}
			if ((this.attribute_0 & Attribute.AbsoluteLineSpacing) != 0)
			{
				this.textControlCore_0.method_29(this.textPart_0, 1161, this.int_9, 1);
			}
			if ((this.attribute_0 & Attribute.TabPositions) != 0 || (this.attribute_0 & Attribute.TabTypes) != 0 || (this.attribute_0 & Attribute.TabLeaders) != 0)
			{
				byte[] array2 = new byte[56];
				this.textControlCore_0.method_42(this.textPart_0, 2012, 1, array2);
				for (int i = 0; i < 14; i++)
				{
					if ((this.attribute_0 & Attribute.TabTypes) != 0)
					{
						array2[i * 4] = (byte)this.tabType_0[i];
					}
					if ((this.attribute_0 & Attribute.TabPositions) != 0)
					{
						array2[i * 4 + 1] = (byte)(this.int_10[i] % 256);
						array2[i * 4 + 2] = (byte)(this.int_10[i] / 256);
					}
					if ((this.attribute_0 & Attribute.TabLeaders) != 0)
					{
						array2[i * 4 + 3] = (byte)this.tabLeader_0[i];
					}
				}
				this.textControlCore_0.method_42(this.textPart_0, 2013, 1, array2);
			}
			if ((this.attribute_0 & Attribute.Frame) != 0 || (this.attribute_0 & Attribute.FrameStyle) != 0 || (this.attribute_0 & Attribute.FrameLineWidth) != 0 || (this.attribute_0 & Attribute.FrameDistance) != 0)
			{
				int num = 0;
				int num2 = 0;
				int num3 = -1;
				if ((this.attribute_0 & Attribute.Frame) != 0)
				{
					num |= (int)this.frame_0;
					if ((num & 1) == 0)
					{
						num |= 0x10000;
					}
					if ((num & 2) == 0)
					{
						num |= 0x20000;
					}
					if ((num & 4) == 0)
					{
						num |= 0x40000;
					}
					if ((num & 8) == 0)
					{
						num |= 0x80000;
					}
					if ((num & 0x80) == 0)
					{
						num |= 0x800000;
					}
				}
				if ((this.attribute_0 & Attribute.FrameStyle) != 0)
				{
					num |= (int)this.frameStyle_0;
				}
				if ((this.attribute_0 & Attribute.FrameLineWidth) != 0)
				{
					num2 = this.int_12;
				}
				if ((this.attribute_0 & Attribute.FrameDistance) != 0)
				{
					num3 = this.int_13;
				}
				this.textControlCore_0.method_29(this.textPart_0, 1171, num, Class429.smethod_3(num2, num3));
			}
			if ((this.attribute_0 & Attribute.FrameLineColor) != 0 || (this.attribute_0 & Attribute.BackColor) != 0)
			{
				int[] array3 = new int[2] { -2147483648, 0 };
				if ((this.attribute_0 & Attribute.BackColor) != 0)
				{
					array3[0] = (int)KernelHelper.SysDrawingColor2TxColor(this.color_1, bBkGnd: true);
				}
				array3[1] = int.MinValue;
				if ((this.attribute_0 & Attribute.FrameLineColor) != 0)
				{
					array3[1] = (int)KernelHelper.SysDrawingColor2TxColor(this.color_0, bBkGnd: false);
				}
				this.textControlCore_0.method_41(Enum83.const_315, 0, array3);
			}
			if ((this.attribute_0 & Attribute.KeepLinesTogether) != 0 || (this.attribute_0 & Attribute.KeepWithNext) != 0 || (this.attribute_0 & Attribute.PageBreakBefore) != 0 || (this.attribute_0 & Attribute.WidowOrphanLines) != 0 || (this.attribute_0 & Attribute.Direction) != 0 || (this.attribute_0 & Attribute.Justification) != 0)
			{
				Enum97 @enum = (Enum97)0;
				if ((this.attribute_0 & Attribute.KeepLinesTogether) != 0)
				{
					@enum |= (this.bool_0 ? Enum97.const_0 : Enum97.const_11);
				}
				if ((this.attribute_0 & Attribute.KeepWithNext) != 0)
				{
					@enum |= (this.bool_1 ? Enum97.const_2 : Enum97.const_13);
				}
				if ((this.attribute_0 & Attribute.PageBreakBefore) != 0)
				{
					@enum |= (this.bool_2 ? Enum97.const_3 : Enum97.const_14);
				}
				if ((this.attribute_0 & Attribute.WidowOrphanLines) != 0)
				{
					@enum |= ((this.int_14 == 0) ? Enum97.const_18 : ((this.int_14 == 1) ? Enum97.const_4 : ((this.int_14 == 2) ? Enum97.const_5 : Enum97.const_6)));
				}
				if ((this.attribute_0 & Attribute.Direction) != 0)
				{
					@enum |= ((this.direction_0 == Direction.RightToLeft) ? Enum97.const_8 : Enum97.const_19);
				}
				if ((this.attribute_0 & Attribute.Justification) != 0)
				{
					@enum |= ((this.justification_0 == Justification.Spaces) ? ((Enum97)100663296) : ((this.justification_0 == Justification.Kashida) ? ((Enum97)1536) : ((Enum97)67109376)));
				}
				this.textControlCore_0.method_29(this.textPart_0, 1208, (int)@enum, 0);
			}
			if (this.int_2 >= 0)
			{
				this.textControlCore_0.method_15(this.textPart_0);
			}
			this.attribute_0 = (Attribute)0;
		}

		internal Attribute method_12(Attribute attribute_3, Attribute attribute_4)
		{
			Attribute attribute = (Attribute)0;
			Attribute attribute2 = this.attribute_2;
			this.attribute_1 &= ~attribute_3;
			if ((attribute_4 & Attribute.Alignment) != 0)
			{
				HorizontalAlignment horizontalAlignment = this.horizontalAlignment_0;
				this.method_10(Attribute.Alignment);
				if (horizontalAlignment != this.horizontalAlignment_0 || (attribute2 & Attribute.Alignment) != (this.attribute_2 & Attribute.Alignment))
				{
					attribute |= Attribute.Alignment;
				}
			}
			if ((attribute_4 & Attribute.StructureLevel) != 0)
			{
				int num = this.int_15;
				this.method_10(Attribute.StructureLevel);
				if (num != this.int_15 || (attribute2 & Attribute.StructureLevel) != (this.attribute_2 & Attribute.StructureLevel))
				{
					attribute |= Attribute.StructureLevel;
				}
			}
			if ((attribute_4 & Attribute.Direction) != 0)
			{
				Direction direction = this.direction_0;
				this.method_10(Attribute.Direction);
				if (direction != this.direction_0 || (attribute2 & Attribute.Direction) != (this.attribute_2 & Attribute.Direction))
				{
					attribute |= Attribute.Direction;
				}
			}
			if ((attribute_4 & (Attribute)8222) != 0)
			{
				int num2 = this.int_3;
				int num3 = this.int_4;
				int num4 = this.int_5;
				int num5 = this.int_6;
				int num6 = this.int_7;
				this.method_10((Attribute)8222);
				if (num2 != this.int_3 || (attribute2 & Attribute.LeftIndent) != (this.attribute_2 & Attribute.LeftIndent))
				{
					attribute |= Attribute.LeftIndent;
				}
				if (num3 != this.int_4 || (attribute2 & Attribute.HangingIndent) != (this.attribute_2 & Attribute.HangingIndent))
				{
					attribute |= Attribute.HangingIndent;
				}
				if (num4 != this.int_5 || (attribute2 & Attribute.RightIndent) != (this.attribute_2 & Attribute.RightIndent))
				{
					attribute |= Attribute.RightIndent;
				}
				if (num5 != this.int_6 || (attribute2 & Attribute.TopDistance) != (this.attribute_2 & Attribute.TopDistance))
				{
					attribute |= Attribute.TopDistance;
				}
				if (num6 != this.int_7 || (attribute2 & Attribute.BottomDistance) != (this.attribute_2 & Attribute.BottomDistance))
				{
					attribute |= Attribute.BottomDistance;
				}
			}
			if ((attribute_4 & Attribute.LineSpacing) != 0)
			{
				int num7 = this.int_8;
				this.method_10(Attribute.LineSpacing);
				if (num7 != this.int_8 || (attribute2 & Attribute.LineSpacing) != (this.attribute_2 & Attribute.LineSpacing))
				{
					attribute |= Attribute.LineSpacing;
				}
			}
			return attribute;
		}

		internal void method_13()
		{
			this.attribute_1 = (Attribute)0;
		}
	}
}
