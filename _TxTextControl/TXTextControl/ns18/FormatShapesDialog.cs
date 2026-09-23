using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ns17;
using TXTextControl.Drawing;

namespace ns18
{
	internal class FormatShapesDialog : Form
	{
		internal enum Enum38
		{
			const_0 = 0,
			const_1 = 1,
			const_2 = 2,
			const_3 = 4,
			const_4 = 8,
			const_5 = 0x10,
			const_6 = 0x20,
			const_7 = 0x40,
			const_8 = 0x80,
			const_9 = 0x100,
			const_10 = 0x200,
			const_11 = 0x400,
			const_12 = 0x800
		}

		internal class Class372
		{
			private Color color_0;

			private string string_0;

			internal Color Color_0
			{
				get
				{
					return this.color_0;
				}
				set
				{
					this.color_0 = value;
				}
			}

			internal string String_0 => this.string_0;

			internal Class372(Color color_1, string string_1)
			{
				this.color_0 = color_1;
				this.string_0 = string_1;
			}

			public override string ToString()
			{
				return this.string_0;
			}
		}

		internal class Class373
		{
			internal enum Enum39 : uint
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

			internal enum Enum40
			{
				const_0 = -4,
				const_1 = -16,
				const_2 = -20
			}

			internal enum Enum41
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

			internal struct Struct32
			{
				internal int int_0;

				internal int int_1;

				internal int int_2;

				internal int int_3;

				internal Struct32(int int_4, int int_5, int int_6, int int_7)
				{
					this.int_0 = int_4;
					this.int_1 = int_5;
					this.int_2 = int_6;
					this.int_3 = int_7;
				}

				internal Struct32(Rectangle rectangle_0)
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

			[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
			internal struct Struct33
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

			[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
			internal struct Struct34
			{
				internal int int_0;

				internal int int_1;

				internal int int_2;

				internal int int_3;

				internal int int_4;

				internal int int_5;

				internal Struct33 struct33_0;

				internal int int_6;

				internal int int_7;

				internal Struct33 struct33_1;

				internal int int_8;

				internal int int_9;

				internal Struct33 struct33_2;

				internal Struct33 struct33_3;

				internal Struct33 struct33_4;

				internal int int_10;
			}

			internal static ushort smethod_0(int int_0)
			{
				return (ushort)((uint)int_0 & 0xFFFFu);
			}

			internal static IntPtr smethod_1(IntPtr intptr_0, int int_0)
			{
				if (IntPtr.Size != 4)
				{
					return Class373.GetWindowLongPtr(intptr_0, int_0);
				}
				return Class373.GetWindowLong(intptr_0, int_0);
			}

			[DllImport("user32.dll", CharSet = CharSet.Auto)]
			internal static extern IntPtr GetWindowLong(IntPtr intptr_0, int int_0);

			[DllImport("user32.dll", CharSet = CharSet.Auto)]
			internal static extern IntPtr GetWindowLongPtr(IntPtr intptr_0, int int_0);

			[DllImport("user32.dll", CharSet = CharSet.Auto)]
			internal static extern bool GetWindowRect(IntPtr intptr_0, ref Struct32 struct32_0);

			[DllImport("user32.dll", CharSet = CharSet.Auto)]
			public static extern bool SystemParametersInfoForDpi(int int_0, int int_1, ref Struct34 struct34_0, int int_2, uint uint_0);

			[DllImport("user32.dll")]
			internal static extern uint GetDpiForWindow(IntPtr intptr_0);

			[DllImport("user32.dll")]
			internal static extern bool AdjustWindowRectEx(ref Struct32 struct32_0, uint uint_0, bool bool_0, uint uint_1);

			[DllImport("user32.dll")]
			internal static extern bool SetWindowPos(IntPtr intptr_0, IntPtr intptr_1, int int_0, int int_1, int int_2, int int_3, uint uint_0);

			internal static uint smethod_2(IntPtr intptr_0)
			{
				uint result = 0u;
				try
				{
					result = Class373.GetDpiForWindow(intptr_0);
					return result;
				}
				catch
				{
					return result;
				}
			}

			[DllImport("user32.dll")]
			internal static extern bool AdjustWindowRectExForDpi(ref Struct32 struct32_0, uint uint_0, bool bool_0, uint uint_1, uint uint_2);

			internal static bool smethod_3(IntPtr intptr_0, ref Struct32 struct32_0, bool bool_0, uint uint_0)
			{
				uint uint_ = (uint)Class373.smethod_1(intptr_0, -16).ToInt32();
				uint uint_2 = (uint)Class373.smethod_1(intptr_0, -20).ToInt32();
				return Class373.smethod_4(ref struct32_0, uint_, bool_0, uint_2, uint_0);
			}

			internal static bool smethod_4(ref Struct32 struct32_0, uint uint_0, bool bool_0, uint uint_1, uint uint_2)
			{
				if (uint_2 != 0)
				{
					try
					{
						return Class373.AdjustWindowRectExForDpi(ref struct32_0, uint_0, bool_0, uint_1, uint_2);
					}
					catch
					{
					}
				}
				return Class373.AdjustWindowRectEx(ref struct32_0, uint_0, bool_0, uint_1);
			}
		}

		internal class Class374
		{
			public static Font smethod_0(uint uint_0)
			{
				if (uint_0 != 0)
				{
					try
					{
						Class373.Struct34 struct34_ = default(Class373.Struct34);
						Marshal.SizeOf(typeof(Class373.Struct33));
						struct34_.int_0 = Marshal.SizeOf((object)struct34_);
						if (Class373.SystemParametersInfoForDpi(41, struct34_.int_0, ref struct34_, 0, uint_0))
						{
							return Font.FromLogFont(struct34_.struct33_0);
						}
					}
					catch
					{
					}
				}
				return SystemFonts.CaptionFont;
			}

			public static Font smethod_1(uint uint_0)
			{
				if (uint_0 != 0)
				{
					try
					{
						Class373.Struct34 struct34_ = default(Class373.Struct34);
						struct34_.int_0 = Marshal.SizeOf((object)struct34_);
						if (Class373.SystemParametersInfoForDpi(41, struct34_.int_0, ref struct34_, 0, uint_0))
						{
							return Font.FromLogFont(struct34_.struct33_2);
						}
					}
					catch
					{
					}
				}
				return SystemFonts.MenuFont;
			}

			public static Font smethod_2(uint uint_0)
			{
				if (uint_0 != 0)
				{
					try
					{
						Class373.Struct34 struct34_ = default(Class373.Struct34);
						struct34_.int_0 = Marshal.SizeOf((object)struct34_);
						if (Class373.SystemParametersInfoForDpi(41, struct34_.int_0, ref struct34_, 0, uint_0))
						{
							return Font.FromLogFont(struct34_.struct33_4);
						}
					}
					catch
					{
					}
				}
				return SystemFonts.MessageBoxFont;
			}

			public static Font smethod_3(uint uint_0)
			{
				if (uint_0 != 0)
				{
					try
					{
						Class373.Struct34 struct34_ = default(Class373.Struct34);
						Marshal.SizeOf(typeof(Class373.Struct33));
						struct34_.int_0 = Marshal.SizeOf((object)struct34_);
						if (Class373.SystemParametersInfoForDpi(41, struct34_.int_0, ref struct34_, 0, uint_0))
						{
							return Font.FromLogFont(struct34_.struct33_1);
						}
					}
					catch
					{
					}
				}
				return SystemFonts.SmallCaptionFont;
			}

			public static Font smethod_4(uint uint_0)
			{
				if (uint_0 != 0)
				{
					try
					{
						Class373.Struct34 struct34_ = default(Class373.Struct34);
						Marshal.SizeOf(typeof(Class373.Struct33));
						struct34_.int_0 = Marshal.SizeOf((object)struct34_);
						if (Class373.SystemParametersInfoForDpi(41, struct34_.int_0, ref struct34_, 0, uint_0))
						{
							return Font.FromLogFont(struct34_.struct33_3);
						}
					}
					catch
					{
					}
				}
				return SystemFonts.StatusFont;
			}
		}

		internal class Class375
		{
			internal static uint smethod_0(Graphics graphics_0, Control control_0)
			{
				uint num = Class373.smethod_2(control_0.Handle);
				if (num != 0)
				{
					if (control_0.Font.IsSystemFont)
					{
						control_0.Font = Class374.smethod_2(num);
					}
					else
					{
						Graphics graphics = ((graphics_0 == null) ? control_0.CreateGraphics() : graphics_0);
						bool flag = false;
						if (((float)num != graphics.DpiX && control_0.Font.Unit != GraphicsUnit.Pixel) || (flag = num != 96 && control_0.Font.Unit == GraphicsUnit.Pixel))
						{
							control_0.Font = new Font(control_0.Font.Name, control_0.Font.Size * (float)num / (flag ? 96f : graphics.DpiX), control_0.Font.Style, control_0.Font.Unit);
						}
						if (graphics_0 == null)
						{
							graphics.Dispose();
						}
					}
				}
				return num;
			}

			internal static void smethod_1(uint uint_0, Class373.Struct32 struct32_0, Form form_0)
			{
				Control control = form_0.Controls[0];
				Size preferredSize = control.PreferredSize;
				struct32_0.int_2 = struct32_0.int_0 + preferredSize.Width + form_0.Padding.Left + form_0.Padding.Right;
				struct32_0.int_3 = struct32_0.int_1 + preferredSize.Height + form_0.Padding.Top + form_0.Padding.Bottom;
				Class373.smethod_3(form_0.Handle, ref struct32_0, bool_0: false, uint_0);
				Class373.SetWindowPos(form_0.Handle, IntPtr.Zero, struct32_0.int_0, struct32_0.int_1, struct32_0.int_2 - struct32_0.int_0, struct32_0.int_3 - struct32_0.int_1, 20u);
			}
		}

		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TXDrawing));

		private TXDrawing txdrawing_0;

		private MeasuringHelper.Enum33 enum33_0;

		private decimal decimal_0;

		private int int_0;

		private string string_0;

		private string string_1;

		private bool bool_0;

		private double[] double_0 = new double[4];

		private CheckState?[] nullable_0 = new CheckState?[3];

		private int?[] nullable_1 = new int?[3] { null, null, null };

		private int?[] nullable_2 = new int?[3] { null, null, null };

		private int? nullable_3 = null;

		private int? nullable_4 = null;

		private int? nullable_5 = null;

		private bool? nullable_6 = null;

		private bool? nullable_7 = null;

		private ColorDialog colorDialog_0 = new ColorDialog();

		private ColorDialog colorDialog_1 = new ColorDialog();

		private bool bool_1 = true;

		private uint uint_0;

		private IContainer icontainer_0;

		private TableLayoutPanel tableLayoutPanel1;

		private Button m_btnCancel;

		private Button m_btnOK;

		private TabControl tabControl1;

		internal TabPage m_tpgSizeAndDistance;

		private TableLayoutPanel m_tlpSizeAndDistance;

		private CheckBox m_cbxAutoSize;

		private TableLayoutPanel m_tlpOptionsHeader;

		private Label m_lblOptions;

		private Label label11;

		private TableLayoutPanel m_tlpDistanceHeader;

		private Label m_lblPosition;

		private Label label7;

		private TableLayoutPanel m_tlpScaleHeader;

		private Label m_lblScale;

		private Label label4;

		private TableLayoutPanel tableLayoutPanel10;

		private Label m_tlpSizeHeader;

		private Label label2;

		private Label m_lblSizeHeight;

		private Label m_lblSizeHeightMeasureUnit;

		private Label m_lblSizeWidth;

		private Label m_lblSizeWidthMeasureUnit;

		private Label m_lblScaleHeight;

		private Label m_lbScalePercentHeight;

		private Label m_lblScaleWidth;

		private Label m_lbScalePercentWidth;

		private Label m_lblPositionY;

		private Label m_lblPositionX;

		private Label m_lblMeasureUnitY;

		private Label m_lblMeasureUnitX;

		private NumericUpDown m_nudSizeHeight;

		private NumericUpDown m_nudSizeWidth;

		private NumericUpDown m_nudLocationY;

		private NumericUpDown m_nudScaleHeight;

		private NumericUpDown m_nudScaleWidth;

		private NumericUpDown m_nudLocationX;

		private CheckBox m_cbxMovable;

		private CheckBox m_cbxSizable;

		private TabPage m_tpgOutlineAndFill;

		private TableLayoutPanel m_tlpOutlineAndFill;

		private TableLayoutPanel m_tlpAppearanceHeader;

		private Label m_lblAppearance;

		private Label m_lblAppearanceSeparator;

		private TableLayoutPanel m_tlpShapeOutlineHeader;

		private Label m_lblShapeOutline;

		private Label m_lblShapeOutlineSeparator;

		private TableLayoutPanel m_tlpShapeFillHeader;

		private Label m_lblShapeFill;

		private Label m_lblShapeFillSeparator;

		private Label m_lblShapeFillTransparency;

		private Label m_lblShapeOutlineColor;

		private Label m_lblRotation;

		private Label m_lblFlip;

		private CheckBox m_cbxFlipHorizontal;

		private CheckBox m_cbxFlipVertical;

		private NumericUpDown m_nudRotation;

		private NumericUpDown m_nudShapeOutlineWidth;

		private Label m_lblShapeOutlineWidth;

		private NumericUpDown m_nudShapeFillTransparencyPercent;

		private Button m_btnShapeFillColor;

		private Button m_btnShapeOutlineColor;

		private Label m_lblShapeFillTransparencyPercent;

		private Label m_lblShapeOutlineWidthPT;

		private Label m_lblRotationDegree;

		private Label m_lblShapeFillColor;

		private ComboBox m_cmbxShapeFillColor;

		private ComboBox m_cmbxShapeOutlineColor;

		public FormatShapesDialog(TXDrawing txdrawing_1, int int_1)
		{
			this.txdrawing_0 = txdrawing_1;
			this.bool_0 = txdrawing_1.IsCanvasVisible;
			this.enum33_0 = ((!RegionInfo.CurrentRegion.IsMetric) ? MeasuringHelper.Enum33.const_0 : MeasuringHelper.Enum33.const_3);
			this.decimal_0 = (RegionInfo.CurrentRegion.IsMetric ? 1m : 0.1m);
			this.int_0 = (RegionInfo.CurrentRegion.IsMetric ? 1 : 3);
			this.InitializeComponent();
			Padding margin = new Padding(15, 0, 4, 0);
			this.m_nudSizeHeight.Margin = margin;
			this.m_nudSizeWidth.Margin = margin;
			this.m_nudScaleHeight.Margin = margin;
			this.m_nudScaleWidth.Margin = margin;
			this.m_nudLocationY.Margin = margin;
			this.m_nudLocationX.Margin = margin;
			Padding margin2 = new Padding(37, 3, 4, 3);
			this.m_nudShapeFillTransparencyPercent.Margin = margin2;
			this.m_nudShapeOutlineWidth.Margin = margin2;
			this.m_nudRotation.Margin = margin2;
			Padding margin3 = new Padding(37, 3, 4, 3);
			this.m_cmbxShapeFillColor.Margin = margin3;
			this.m_cmbxShapeOutlineColor.Margin = margin3;
			Padding margin4 = new Padding(37, 4, 4, 3);
			this.m_cbxFlipHorizontal.Margin = margin4;
			this.m_cbxFlipVertical.Margin = margin4;
			Padding margin5 = new Padding(7, 2, 4, 0);
			this.m_btnShapeFillColor.Margin = margin5;
			this.m_btnShapeOutlineColor.Margin = margin5;
			Padding margin6 = new Padding(3, 4, 3, 3);
			this.m_lblShapeFillColor.Margin = margin6;
			this.m_lblShapeFillTransparency.Margin = margin6;
			this.m_lblShapeFillTransparencyPercent.Margin = margin6;
			this.m_lblShapeOutlineColor.Margin = margin6;
			this.m_lblShapeOutlineWidth.Margin = margin6;
			this.m_lblShapeOutlineWidthPT.Margin = margin6;
			this.m_lblRotation.Margin = margin6;
			this.m_lblRotationDegree.Margin = margin6;
			this.m_lblFlip.Margin = margin6;
			this.method_2();
			this.method_3();
			this.method_7();
			this.tabControl1.SelectedIndex = int_1;
		}

		private Padding method_0(Padding padding_0, PointF pointF_0)
		{
			return new Padding(this.method_1(padding_0.Left, pointF_0.X), this.method_1(padding_0.Top, pointF_0.Y), this.method_1(padding_0.Right, pointF_0.X), this.method_1(padding_0.Bottom, pointF_0.Y));
		}

		private int method_1(int int_1, float float_0)
		{
			if (int_1 != int.MaxValue && int_1 != int.MinValue)
			{
				return (int)Math.Round((float)int_1 * (float_0 / 96f));
			}
			return int_1;
		}

		private void method_2()
		{
			this.Text = this.resourceManager_0.GetString("DLG_FSDLG_FORMAT_SHAPES");
			this.m_btnOK.Text = this.resourceManager_0.GetString("BTN_FSDLG_OK");
			this.m_btnCancel.Text = this.resourceManager_0.GetString("BTN_FSDLG_CANCEL");
			this.tabControl1.TabPages[0].Text = this.resourceManager_0.GetString("TAB_FSDLG_SIZE_AND_DISTANCE");
			this.m_tlpSizeHeader.Text = this.resourceManager_0.GetString("LBL_FSDLG_SIZE_HEADER");
			this.m_lblSizeHeight.Text = this.resourceManager_0.GetString("LBL_FSDLG_SIZE_HEIGHT");
			this.m_lblSizeHeightMeasureUnit.Text = (RegionInfo.CurrentRegion.IsMetric ? this.resourceManager_0.GetString("LBL_FSDLG_SIZE_HEIGHT_MEASURING_UNIT_MM") : this.resourceManager_0.GetString("LBL_FSDLG_SIZE_HEIGHT_MEASURING_UNIT_INCH"));
			this.m_lblSizeWidth.Text = this.resourceManager_0.GetString("LBL_FSDLG_SIZE_WIDTH");
			this.m_lblSizeWidthMeasureUnit.Text = (RegionInfo.CurrentRegion.IsMetric ? this.resourceManager_0.GetString("LBL_FSDLG_SIZE_WIDTH_MEASURING_UNIT_MM") : this.resourceManager_0.GetString("LBL_FSDLG_SIZE_WIDTH_MEASURING_UNIT_INCH"));
			this.m_lblScale.Text = this.resourceManager_0.GetString("LBL_FSDLG_SCALE_HEADER");
			this.m_lblScaleHeight.Text = this.resourceManager_0.GetString("LBL_FSDLG_SCALE_HEIGHT");
			this.m_lbScalePercentHeight.Text = this.resourceManager_0.GetString("LBL_FSDLG_SCALE_HEIGHT_PERCENT");
			this.m_lblScaleWidth.Text = this.resourceManager_0.GetString("LBL_FSDLG_SCALE_WIDTH");
			this.m_lbScalePercentWidth.Text = this.resourceManager_0.GetString("LBL_FSDLG_SCALE_WIDTH_PERCENT");
			this.m_lblPosition.Text = this.resourceManager_0.GetString("LBL_FSDLG_POSITION_HEADER");
			this.m_lblPositionY.Text = this.resourceManager_0.GetString("LBL_FSDLG_POSITION_TOP");
			this.m_lblMeasureUnitY.Text = (RegionInfo.CurrentRegion.IsMetric ? this.resourceManager_0.GetString("LBL_FSDLG_POSITION_TOP_MEASURING_UNIT_MM") : this.resourceManager_0.GetString("LBL_FSDLG_POSITION_TOP_MEASURING_UNIT_INCH"));
			this.m_lblPositionX.Text = this.resourceManager_0.GetString("LBL_FSDLG_POSITION_LEFT");
			this.m_lblMeasureUnitX.Text = (RegionInfo.CurrentRegion.IsMetric ? this.resourceManager_0.GetString("LBL_FSDLG_POSITION_LEFT_MEASURING_UNIT_MM") : this.resourceManager_0.GetString("LBL_FSDLG_POSITION_LEFT_MEASURING_UNIT_INCH"));
			this.m_lblOptions.Text = this.resourceManager_0.GetString("LBL_FSDLG_OPTIONS_HEADER");
			this.m_cbxMovable.Text = this.resourceManager_0.GetString("CHBX_FSDLG_MOVABLE");
			this.m_cbxSizable.Text = this.resourceManager_0.GetString("CHBX_FSDLG_SIZABLE");
			this.m_cbxAutoSize.Text = this.resourceManager_0.GetString("CHBX_FSDLG_SIZE_AUTOMATICALLY");
			this.tabControl1.TabPages[1].Text = this.resourceManager_0.GetString("TAB_FSDLG_OUTLINE_AND_FILL");
			this.m_lblShapeFill.Text = this.resourceManager_0.GetString("LBL_FSDLG_SHAPE_FILL_HEADER");
			this.m_lblShapeFillColor.Text = this.resourceManager_0.GetString("LBL_FSDLG_SHAPE_FILL_COLOR");
			this.string_0 = this.resourceManager_0.GetString("CMBX_FSDLG_SHAPE_FILL_ITEM_OTHER");
			this.m_btnShapeFillColor.Text = this.resourceManager_0.GetString("BTN_FSDLG_SHAPE_FILL_OTHER");
			this.m_lblShapeFillTransparency.Text = this.resourceManager_0.GetString("LBL_FSDLG_SHAPE_FILL_TRANSPARENCY");
			this.m_lblShapeFillTransparencyPercent.Text = this.resourceManager_0.GetString("LBL_FSDLG_SHAPE_FILL_TRANSPARENCY_MEASURING_UNIT");
			this.m_lblShapeOutline.Text = this.resourceManager_0.GetString("LBL_FSDLG_SHAPE_OUTLINE_HEADER");
			this.m_lblShapeOutlineColor.Text = this.resourceManager_0.GetString("LBL_FSDLG_SHAPE_OUTLINE_COLOR");
			this.string_1 = this.resourceManager_0.GetString("CMBX_FSDLG_SHAPE_OUTLINE_ITEM_OTHER");
			this.m_btnShapeOutlineColor.Text = this.resourceManager_0.GetString("BTN_FSDLG_SHAPE_OUTLINE_OTHER");
			this.m_lblShapeOutlineWidth.Text = this.resourceManager_0.GetString("LBL_FSDLG_SHAPE_OUTLINE_LINE_WIDTH");
			this.m_lblShapeOutlineWidthPT.Text = this.resourceManager_0.GetString("LBL_FSDLG_SHAPE_OUTLINE_LINE_WIDTH_MEASURING_UNIT");
			this.m_lblAppearance.Text = this.resourceManager_0.GetString("LBL_FSDLG_APPEARANCE_HEADER");
			this.m_lblRotation.Text = this.resourceManager_0.GetString("LBL_FSDLG_APPEARANCE_ROTATION");
			this.m_lblRotationDegree.Text = this.resourceManager_0.GetString("LBL_FSDLG_APPEARANCE_ROTATION_MEASURING_UNIT");
			this.m_lblFlip.Text = this.resourceManager_0.GetString("LBL_FSDLG_APPEARANCE_FLIP");
			this.m_cbxFlipHorizontal.Text = this.resourceManager_0.GetString("CHBX_FSDLG_APPEARANCE_FLIP_HORIZONTAL");
			this.m_cbxFlipVertical.Text = this.resourceManager_0.GetString("CHBX_FSDLG_APPEARANCE_FLIP_VERTICAL");
		}

		private void method_3()
		{
			this.method_4();
			this.method_6();
		}

		private void method_4()
		{
			NumericUpDown nudSizeWidth = this.m_nudSizeWidth;
			NumericUpDown nudSizeHeight = this.m_nudSizeHeight;
			NumericUpDown nudLocationX = this.m_nudLocationX;
			decimal num2 = (this.m_nudLocationY.Increment = this.decimal_0);
			decimal num4 = (nudLocationX.Increment = num2);
			decimal num7 = (nudSizeWidth.Increment = (nudSizeHeight.Increment = num4));
			NumericUpDown nudSizeWidth2 = this.m_nudSizeWidth;
			NumericUpDown nudSizeHeight2 = this.m_nudSizeHeight;
			NumericUpDown nudLocationX2 = this.m_nudLocationX;
			int num9 = (this.m_nudLocationY.DecimalPlaces = this.int_0);
			int num11 = (nudLocationX2.DecimalPlaces = num9);
			int num14 = (nudSizeWidth2.DecimalPlaces = (nudSizeHeight2.DecimalPlaces = num11));
			bool flag = this.txdrawing_0.Selection_0.IsCommonValueSelected(Selection.Attribute.LocationX);
			bool flag2 = this.txdrawing_0.Selection_0.IsCommonValueSelected(Selection.Attribute.LocationY);
			bool flag3 = this.txdrawing_0.Selection_0.IsCommonValueSelected(Selection.Attribute.SizeWidth);
			bool flag4 = this.txdrawing_0.Selection_0.IsCommonValueSelected(Selection.Attribute.SizeHeight);
			if (flag)
			{
				this.double_0[0] = this.txdrawing_0.Selection_0.Shapes[0].Location.X;
				double num15 = MeasuringHelper.Tw2DotNet(this.double_0[0], this.enum33_0);
				this.m_nudLocationX.Value = (decimal)num15;
			}
			else
			{
				this.m_nudLocationX.ResetText();
			}
			this.m_nudLocationX.ValueChanged += m_nudSizeHeight_ValueChanged;
			this.m_nudLocationX.Enter += m_nudScaleHeight_Enter;
			if (flag2)
			{
				this.double_0[1] = this.txdrawing_0.Selection_0.Shapes[0].Location.Y;
				double num16 = MeasuringHelper.Tw2DotNet(this.double_0[1], this.enum33_0);
				this.m_nudLocationY.Value = (decimal)num16;
			}
			else
			{
				this.m_nudLocationY.ResetText();
			}
			this.m_nudLocationY.ValueChanged += m_nudSizeHeight_ValueChanged;
			this.m_nudLocationY.Enter += m_nudScaleHeight_Enter;
			if (flag3 = this.txdrawing_0.Selection_0.IsCommonValueSelected(Selection.Attribute.SizeWidth))
			{
				this.double_0[2] = Math.Max(this.txdrawing_0.Selection_0.Shapes[0].Size.Width, 1);
				double num17 = MeasuringHelper.Tw2DotNet(this.double_0[2], this.enum33_0);
				this.m_nudSizeWidth.Value = (decimal)num17;
			}
			else
			{
				this.m_nudSizeWidth.ResetText();
				this.m_nudScaleWidth.ResetText();
				this.m_nudScaleWidth.Enabled = false;
			}
			this.m_nudSizeWidth.ValueChanged += m_nudSizeHeight_ValueChanged;
			this.m_nudSizeWidth.Enter += m_nudScaleHeight_Enter;
			this.m_nudScaleWidth.ValueChanged += m_nudScaleWidth_ValueChanged;
			this.m_nudScaleWidth.Enter += m_nudScaleHeight_Enter;
			if (flag4 = this.txdrawing_0.Selection_0.IsCommonValueSelected(Selection.Attribute.SizeHeight))
			{
				this.double_0[3] = Math.Max(this.txdrawing_0.Selection_0.Shapes[0].Size.Height, 1);
				double num18 = MeasuringHelper.Tw2DotNet(this.double_0[3], this.enum33_0);
				this.m_nudSizeHeight.Value = (decimal)num18;
			}
			else
			{
				this.m_nudSizeHeight.ResetText();
				this.m_nudScaleHeight.ResetText();
				this.m_nudScaleHeight.Enabled = false;
			}
			this.m_nudSizeHeight.ValueChanged += m_nudSizeHeight_ValueChanged;
			this.m_nudSizeHeight.Enter += m_nudScaleHeight_Enter;
			this.m_nudScaleHeight.ValueChanged += m_nudScaleHeight_ValueChanged;
			this.m_nudScaleHeight.Enter += m_nudScaleHeight_Enter;
			this.method_5(flag, flag2, flag3, flag4);
		}

		private void m_nudScaleHeight_Enter(object sender, EventArgs e)
		{
			NumericUpDown numericUpDown = (NumericUpDown)sender;
			numericUpDown.Select(0, numericUpDown.Text.Length);
		}

		private void method_5(bool bool_2, bool bool_3, bool bool_4, bool bool_5)
		{
			this.bool_1 = false;
			double num = (bool_2 ? MeasuringHelper.DotNet2Tw((double)this.m_nudLocationX.Value, this.enum33_0) : (-1));
			double num2 = (bool_3 ? MeasuringHelper.DotNet2Tw((double)this.m_nudLocationY.Value, this.enum33_0) : (-1));
			double num3 = (bool_4 ? MeasuringHelper.DotNet2Tw((double)this.m_nudSizeWidth.Value, this.enum33_0) : (-1));
			double num4 = (bool_5 ? MeasuringHelper.DotNet2Tw((double)this.m_nudSizeHeight.Value, this.enum33_0) : (-1));
			double num5 = double.MaxValue;
			double num6 = double.MaxValue;
			double num7 = double.MinValue;
			double num8 = double.MaxValue;
			double num9 = double.MinValue;
			double num10 = double.MaxValue;
			Shape[] shapes = this.txdrawing_0.Selection_0.Shapes;
			foreach (Shape shape in shapes)
			{
				num = (bool_2 ? num : ((double)shape.Location.X));
				num2 = (bool_3 ? num2 : ((double)shape.Location.Y));
				num3 = (bool_4 ? num3 : ((double)shape.Size.Width));
				num4 = (bool_5 ? num4 : ((double)shape.Size.Height));
				Class178 maxBounds = Helper.GetMaxBounds(new Class178(num, num2, Math.Max(num3, 1.0), Math.Max(num4, 1.0), bool_1: false), this.txdrawing_0.Class178_1, shape.Angle);
				double num11 = Math.Max(num3, maxBounds.Double_3 - (num - maxBounds.Double_0));
				double num12 = MeasuringHelper.Tw2DotNet(num11, this.enum33_0);
				if (num12 < num6)
				{
					num6 = num12;
				}
				double num13 = Math.Max(num4, maxBounds.Double_2 - (num2 - maxBounds.Double_1));
				double num14 = MeasuringHelper.Tw2DotNet(num13, this.enum33_0);
				if (num14 < num5)
				{
					num5 = num14;
				}
				double num15 = MeasuringHelper.Tw2DotNet(Math.Min(num, maxBounds.Double_0), this.enum33_0);
				double num16 = MeasuringHelper.Tw2DotNet(Math.Max(num, num + (num11 - num3)), this.enum33_0);
				if (num15 > num7)
				{
					num7 = num15;
				}
				if (num16 < num8)
				{
					num8 = num16;
				}
				double num17 = MeasuringHelper.Tw2DotNet(Math.Min(num2, maxBounds.Double_1), this.enum33_0);
				double num18 = MeasuringHelper.Tw2DotNet(Math.Max(num2, num2 + (num13 - num4)), this.enum33_0);
				if (num17 > num9)
				{
					num9 = num17;
				}
				if (num18 < num10)
				{
					num10 = num18;
				}
			}
			this.m_nudSizeWidth.Maximum = (decimal)num6;
			this.m_nudSizeHeight.Maximum = (decimal)num5;
			this.m_nudLocationX.Maximum = (decimal)num8;
			this.m_nudLocationX.Minimum = (decimal)num7;
			this.m_nudLocationY.Maximum = (decimal)num10;
			this.m_nudLocationY.Minimum = (decimal)num9;
			if (!bool_2)
			{
				this.m_nudLocationX.ResetText();
			}
			if (!bool_3)
			{
				this.m_nudLocationY.ResetText();
			}
			if (!bool_4)
			{
				this.m_nudSizeWidth.ResetText();
			}
			else
			{
				decimal val = (decimal)(100.0 * num6 / MeasuringHelper.Tw2DotNet(this.double_0[2], this.enum33_0));
				decimal val2 = 100m * this.m_nudSizeWidth.Value / (decimal)MeasuringHelper.Tw2DotNet(this.double_0[2], this.enum33_0);
				this.m_nudScaleWidth.Maximum = Math.Max(val, val2);
				this.m_nudScaleWidth.Value = Math.Max(this.m_nudScaleWidth.Minimum, val2);
			}
			if (!bool_5)
			{
				this.m_nudSizeHeight.ResetText();
			}
			else
			{
				decimal val3 = (decimal)(100.0 * num5 / MeasuringHelper.Tw2DotNet(this.double_0[3], this.enum33_0));
				decimal val4 = 100m * this.m_nudSizeHeight.Value / (decimal)MeasuringHelper.Tw2DotNet(this.double_0[3], this.enum33_0);
				this.m_nudScaleHeight.Maximum = Math.Max(val3, val4);
				this.m_nudScaleHeight.Value = Math.Max(this.m_nudScaleHeight.Minimum, val4);
			}
			this.bool_1 = true;
		}

		private void m_nudSizeHeight_ValueChanged(object sender, EventArgs e)
		{
			if (this.bool_1)
			{
				this.method_5(this.m_nudLocationX.Text != "", this.m_nudLocationY.Text != "", this.m_nudSizeWidth.Text != "", this.m_nudSizeHeight.Text != "");
			}
		}

		private void m_nudScaleWidth_ValueChanged(object sender, EventArgs e)
		{
			decimal val = (decimal)MeasuringHelper.Tw2DotNet(this.double_0[2] * (double)this.m_nudScaleWidth.Value / 100.0, this.enum33_0);
			this.m_nudSizeWidth.Value = Math.Min(this.m_nudSizeWidth.Maximum, val);
		}

		private void m_nudScaleHeight_ValueChanged(object sender, EventArgs e)
		{
			decimal val = (decimal)MeasuringHelper.Tw2DotNet(this.double_0[3] * (double)this.m_nudScaleHeight.Value / 100.0, this.enum33_0);
			this.m_nudSizeHeight.Value = Math.Min(this.m_nudSizeHeight.Maximum, val);
		}

		private void method_6()
		{
			ref CheckState? reference = ref this.nullable_0[0];
			CheckState value = (this.m_cbxMovable.CheckState = ((!this.txdrawing_0.Selection_0.IsCommonValueSelected(Selection.Attribute.Movable)) ? CheckState.Indeterminate : (this.txdrawing_0.Selection_0.Shapes[0].Movable ? CheckState.Checked : CheckState.Unchecked)));
			reference = value;
			ref CheckState? reference2 = ref this.nullable_0[1];
			CheckState value2 = (this.m_cbxSizable.CheckState = ((!this.txdrawing_0.Selection_0.IsCommonValueSelected(Selection.Attribute.Sizable)) ? CheckState.Indeterminate : (this.txdrawing_0.Selection_0.Shapes[0].Sizable ? CheckState.Checked : CheckState.Unchecked)));
			reference2 = value2;
			ref CheckState? reference3 = ref this.nullable_0[2];
			CheckState value3 = (this.m_cbxAutoSize.CheckState = ((!this.txdrawing_0.Selection_0.IsCommonValueSelected(Selection.Attribute.AutoSize)) ? CheckState.Indeterminate : (this.txdrawing_0.Selection_0.Shapes[0].AutoSize ? CheckState.Checked : CheckState.Unchecked)));
			reference3 = value3;
		}

		private void method_7()
		{
			this.method_8();
			this.method_11();
			this.method_14();
		}

		private void method_8()
		{
			this.m_cmbxShapeFillColor.DrawItem += m_cmbxShapeOutlineColor_DrawItem;
			this.m_cmbxShapeFillColor.DrawMode = DrawMode.OwnerDrawVariable;
			this.colorDialog_1.FullOpen = true;
			this.method_13(this.m_cmbxShapeFillColor, this.method_10(), this.txdrawing_0.Selection_0.Shapes[0].ShapeFill.Color, this.string_0);
			this.m_btnShapeFillColor.Click += m_btnShapeFillColor_Click;
			if (this.method_9())
			{
				this.nullable_4 = this.txdrawing_0.Selection_0.Shapes[0].ShapeFill.Color.A;
				this.m_nudShapeFillTransparencyPercent.Value = (decimal)(100.0 - (double)this.nullable_4.Value * (20.0 / 51.0));
			}
			else
			{
				this.m_nudShapeFillTransparencyPercent.ResetText();
			}
		}

		private void m_cmbxShapeOutlineColor_DrawItem(object sender, DrawItemEventArgs e)
		{
			Graphics graphics = e.Graphics;
			e.DrawBackground();
			Rectangle bounds = e.Bounds;
			if (e.Index >= 0)
			{
				Class372 @class = (Class372)((ComboBox)sender).Items[e.Index];
				Point location = new Point(e.Bounds.X + 2 + bounds.Height, e.Bounds.Y);
				TextRenderer.DrawText(e.Graphics, @class.String_0, e.Font, new Rectangle(location, new Size(bounds.Width - location.X, bounds.Height)), e.ForeColor, TextFormatFlags.NoPrefix | TextFormatFlags.VerticalCenter);
				graphics.FillRectangle(new SolidBrush(@class.Color_0), bounds.X + 1, bounds.Y + 1, bounds.Height - 2, bounds.Height - 2);
				graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black), 1f), bounds.X + 1, bounds.Y + 1, bounds.Height - 2, bounds.Height - 2);
			}
		}

		private bool method_9()
		{
			int a = this.txdrawing_0.Selection_0.Shapes[0].ShapeFill.Color.A;
			int num = 1;
			while (true)
			{
				if (num < this.txdrawing_0.Selection_0.Shapes.Length)
				{
					if (this.txdrawing_0.Selection_0.Shapes[num].ShapeFill.Color.A != a)
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}

		private bool method_10()
		{
			int r = this.txdrawing_0.Selection_0.Shapes[0].ShapeFill.Color.R;
			int g = this.txdrawing_0.Selection_0.Shapes[0].ShapeFill.Color.G;
			int b = this.txdrawing_0.Selection_0.Shapes[0].ShapeFill.Color.B;
			int num = 1;
			while (true)
			{
				if (num < this.txdrawing_0.Selection_0.Shapes.Length)
				{
					if (this.txdrawing_0.Selection_0.Shapes[num].ShapeFill.Color.R != r || this.txdrawing_0.Selection_0.Shapes[num].ShapeFill.Color.G != g || this.txdrawing_0.Selection_0.Shapes[num].ShapeFill.Color.B != b)
					{
						break;
					}
					num++;
					continue;
				}
				this.nullable_1 = new int?[3] { r, g, b };
				return true;
			}
			return false;
		}

		private void method_11()
		{
			this.m_cmbxShapeOutlineColor.DrawItem += m_cmbxShapeOutlineColor_DrawItem;
			this.m_cmbxShapeOutlineColor.DrawMode = DrawMode.OwnerDrawVariable;
			this.colorDialog_0.FullOpen = true;
			this.method_13(this.m_cmbxShapeOutlineColor, this.method_12(), this.txdrawing_0.Selection_0.Shapes[0].ShapeOutline.Color, this.string_1);
			this.m_btnShapeOutlineColor.Click += m_btnShapeOutlineColor_Click;
			this.m_nudShapeOutlineWidth.DecimalPlaces = 2;
			if (this.txdrawing_0.Selection_0.IsCommonValueSelected(Selection.Attribute.LineWidth))
			{
				this.nullable_3 = this.txdrawing_0.Selection_0.Shapes[0].ShapeOutline.Width;
				this.m_nudShapeOutlineWidth.Value = (decimal)this.nullable_3.Value / 20m;
			}
			else
			{
				this.m_nudShapeOutlineWidth.ResetText();
			}
		}

		private void m_btnShapeOutlineColor_Click(object sender, EventArgs e)
		{
			this.colorDialog_0.Color = ((Class372)this.m_cmbxShapeOutlineColor.SelectedItem).Color_0;
			if (this.colorDialog_0.ShowDialog() == DialogResult.OK)
			{
				this.method_13(this.m_cmbxShapeOutlineColor, bool_2: true, this.colorDialog_0.Color, this.string_1);
			}
		}

		private bool method_12()
		{
			int r = this.txdrawing_0.Selection_0.Shapes[0].ShapeOutline.Color.R;
			int g = this.txdrawing_0.Selection_0.Shapes[0].ShapeOutline.Color.G;
			int b = this.txdrawing_0.Selection_0.Shapes[0].ShapeOutline.Color.B;
			int num = 1;
			while (true)
			{
				if (num < this.txdrawing_0.Selection_0.Shapes.Length)
				{
					if (this.txdrawing_0.Selection_0.Shapes[num].ShapeOutline.Color.R != r || this.txdrawing_0.Selection_0.Shapes[num].ShapeOutline.Color.G != g || this.txdrawing_0.Selection_0.Shapes[num].ShapeOutline.Color.B != b)
					{
						break;
					}
					num++;
					continue;
				}
				this.nullable_2 = new int?[3] { r, g, b };
				return true;
			}
			return false;
		}

		private void method_13(ComboBox comboBox_0, bool bool_2, Color color_0, string string_2)
		{
			comboBox_0.Items.Clear();
			int num = -1;
			string text = ((comboBox_0 == this.m_cmbxShapeFillColor) ? "CMBX_FSDLG_SHAPE_FILL_ITEM_" : "CMBX_FSDLG_SHAPE_OUTLINE_ITEM_");
			Color[] color_ = this.txdrawing_0.Color_0;
			for (int i = 0; i < color_.Length; i++)
			{
				Color color_2 = color_[i];
				int num2 = comboBox_0.Items.Add(new Class372(color_2, this.txdrawing_0.method_19(text, color_2)));
				if (bool_2 && color_0.R == color_2.R && color_0.G == color_2.G && color_0.B == color_2.B)
				{
					num = num2;
				}
			}
			if (bool_2 && num == -1)
			{
				Class372 item = new Class372(color_0, string_2);
				comboBox_0.Items.Add(item);
			}
			if (bool_2)
			{
				comboBox_0.SelectedIndex = ((num != -1) ? num : (comboBox_0.Items.Count - 1));
			}
		}

		private void m_btnShapeFillColor_Click(object sender, EventArgs e)
		{
			this.colorDialog_1.Color = ((Class372)this.m_cmbxShapeFillColor.SelectedItem).Color_0;
			if (this.colorDialog_1.ShowDialog() == DialogResult.OK)
			{
				this.method_13(this.m_cmbxShapeFillColor, bool_2: true, this.colorDialog_1.Color, this.string_0);
			}
		}

		private void method_14()
		{
			if (this.txdrawing_0.Selection_0.IsCommonValueSelected(Selection.Attribute.Angle))
			{
				this.nullable_5 = this.txdrawing_0.Selection_0.Shapes[0].Angle;
				this.m_nudRotation.Value = this.nullable_5.Value;
			}
			else
			{
				this.m_nudRotation.ResetText();
			}
			if (this.txdrawing_0.Selection_0.IsCommonValueSelected(Selection.Attribute.FlipHorizontal))
			{
				this.nullable_6 = (this.txdrawing_0.Selection_0.Shapes[0].Flip & Flip.Horizontal) == Flip.Horizontal;
				this.m_cbxFlipHorizontal.Checked = this.nullable_6.Value;
			}
			else
			{
				this.m_cbxFlipHorizontal.CheckState = CheckState.Indeterminate;
			}
			if (this.txdrawing_0.Selection_0.IsCommonValueSelected(Selection.Attribute.FlipVertical))
			{
				this.nullable_7 = (this.txdrawing_0.Selection_0.Shapes[0].Flip & Flip.Vertical) == Flip.Vertical;
				this.m_cbxFlipVertical.Checked = this.nullable_7.Value;
			}
			else
			{
				this.m_cbxFlipVertical.CheckState = CheckState.Indeterminate;
			}
		}

		private void m_btnOK_Click(object sender, EventArgs e)
		{
			Enum38 @enum = this.method_15();
			if (@enum != 0)
			{
				bool flag = (@enum & Enum38.const_1) == Enum38.const_1;
				bool flag2 = (@enum & Enum38.const_2) == Enum38.const_2;
				bool flag3 = (@enum & Enum38.const_3) == Enum38.const_3;
				bool flag4 = (@enum & Enum38.const_4) == Enum38.const_4;
				bool flag5 = (@enum & Enum38.const_8) == Enum38.const_8;
				bool flag6 = (@enum & Enum38.const_9) == Enum38.const_9;
				bool flag7 = (@enum & Enum38.const_10) == Enum38.const_10;
				bool flag8 = (@enum & Enum38.const_11) == Enum38.const_11;
				bool flag9 = (@enum & Enum38.const_5) == Enum38.const_5;
				bool flag10 = (@enum & Enum38.const_6) == Enum38.const_6;
				bool flag11 = (@enum & Enum38.const_7) == Enum38.const_7;
				bool flag12 = false;
				bool flag13 = false;
				int enum30_ = 223;
				double num = (flag ? ((double)MeasuringHelper.DotNet2Tw((double)this.m_nudLocationX.Value, this.enum33_0)) : double.NaN);
				double num2 = (flag2 ? ((double)MeasuringHelper.DotNet2Tw((double)this.m_nudLocationY.Value, this.enum33_0)) : double.NaN);
				double num3 = (flag3 ? ((double)MeasuringHelper.DotNet2Tw((double)this.m_nudSizeWidth.Value, this.enum33_0)) : double.NaN);
				double num4 = (flag4 ? ((double)MeasuringHelper.DotNet2Tw((double)this.m_nudSizeHeight.Value, this.enum33_0)) : double.NaN);
				int? num5 = (flag6 ? new int?((int)(-Math.Round((this.m_nudShapeFillTransparencyPercent.Value - 100m) * 255m / 100m))) : null);
				Shape[] shapes = this.txdrawing_0.Selection_0.Shapes;
				foreach (Shape shape in shapes)
				{
					num = ((!flag) ? shape.Class174_0.Class178_1.Double_0 : num);
					num2 = ((!flag2) ? shape.Class174_0.Class178_1.Double_1 : num2);
					Class177 class177_ = new Class177(num, num2, bool_1: false);
					num3 = ((!flag3) ? shape.Class174_0.Class178_1.Double_3 : num3);
					num4 = ((!flag4) ? shape.Class174_0.Class178_1.Double_2 : num4);
					Class179 class179_ = new Class179(num3, num4, bool_1: false);
					shape.Class174_0.Class178_1 = new Class178(class177_, class179_);
					if (this.m_cbxMovable.CheckState != CheckState.Indeterminate)
					{
						flag13 |= shape.method_7(this.m_cbxMovable.Checked);
					}
					if (this.m_cbxSizable.CheckState != CheckState.Indeterminate)
					{
						flag12 |= shape.method_8(this.m_cbxSizable.Checked);
					}
					shape.Boolean_5 = ((this.m_cbxAutoSize.CheckState != CheckState.Indeterminate) ? this.m_cbxAutoSize.Checked : shape.AutoSize);
					int alpha = (num5.HasValue ? num5.Value : shape.ShapeFill.Color_0.A);
					shape.ShapeFill.Color_0 = (flag5 ? Color.FromArgb(alpha, ((Class372)this.m_cmbxShapeFillColor.SelectedItem).Color_0) : Color.FromArgb(alpha, shape.ShapeFill.Color_0));
					shape.ShapeOutline.Color_0 = (flag7 ? Color.FromArgb(shape.ShapeOutline.Color_0.A, ((Class372)this.m_cmbxShapeOutlineColor.SelectedItem).Color_0) : shape.ShapeOutline.Color_0);
					shape.ShapeOutline.Int32_0 = (flag8 ? ((int)this.m_nudShapeOutlineWidth.Value * 20) : shape.ShapeOutline.Int32_0);
					shape.Int32_4 = (flag9 ? ((int)this.m_nudRotation.Value) : shape.Angle);
					if (flag10 || flag11)
					{
						Flip flip = (((shape.Flip & Flip.Horizontal) == Flip.Horizontal) ? Flip.Horizontal : Flip.None);
						Flip flip2 = ((!flag10) ? flip : (this.m_cbxFlipHorizontal.Checked ? Flip.Horizontal : Flip.None));
						Flip flip3 = (((shape.Flip & Flip.Vertical) == Flip.Vertical) ? Flip.Vertical : Flip.None);
						Flip flip4 = ((!flag11) ? flip3 : (this.m_cbxFlipVertical.Checked ? Flip.Vertical : Flip.None));
						shape.Flip_1 = flip2 | flip4;
					}
					shape.Class174_0.method_1((Class174.Enum30)enum30_);
					shape.Class183_0.method_1();
				}
				if (flag13)
				{
					this.txdrawing_0.Selection_0.method_27();
				}
				if (flag12)
				{
					this.txdrawing_0.Selection_0.method_29();
				}
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		internal Enum38 method_15()
		{
			Enum38 @enum = Enum38.const_0;
			if (this.m_nudLocationX.Text != "" && this.m_nudLocationX.Value != (decimal)MeasuringHelper.Tw2DotNet(this.double_0[0], this.enum33_0))
			{
				@enum |= Enum38.const_1;
			}
			if (this.m_nudLocationY.Text != "" && this.m_nudLocationY.Value != (decimal)MeasuringHelper.Tw2DotNet(this.double_0[1], this.enum33_0))
			{
				@enum |= Enum38.const_2;
			}
			if (this.m_nudSizeWidth.Text != "" && this.m_nudSizeWidth.Value != (decimal)MeasuringHelper.Tw2DotNet(this.double_0[2], this.enum33_0))
			{
				@enum |= Enum38.const_3;
			}
			if (this.m_nudSizeHeight.Text != "" && this.m_nudSizeHeight.Value != (decimal)MeasuringHelper.Tw2DotNet(this.double_0[3], this.enum33_0))
			{
				@enum |= Enum38.const_4;
			}
			if (this.nullable_0[2] != this.m_cbxAutoSize.CheckState || this.nullable_0[1] != this.m_cbxSizable.CheckState || this.nullable_0[0] != this.m_cbxMovable.CheckState)
			{
				@enum |= Enum38.const_12;
			}
			if (this.m_cmbxShapeFillColor.SelectedItem != null)
			{
				Color color_ = ((Class372)this.m_cmbxShapeFillColor.SelectedItem).Color_0;
				if (color_.R != this.nullable_1[0] || color_.G != this.nullable_1[1] || color_.B != this.nullable_1[2])
				{
					@enum |= Enum38.const_8;
				}
			}
			if (this.m_nudShapeFillTransparencyPercent.Text != "")
			{
				_ = -((this.m_nudShapeFillTransparencyPercent.Value - 100m) * 255m / 100m);
				decimal num = Math.Round(-((this.m_nudShapeFillTransparencyPercent.Value - 100m) * 255m / 100m));
				int? num2 = this.nullable_4;
				if (num != (decimal)num2.GetValueOrDefault() || !num2.HasValue)
				{
					@enum |= Enum38.const_9;
				}
			}
			if (this.m_cmbxShapeOutlineColor.SelectedItem != null)
			{
				Color color_2 = ((Class372)this.m_cmbxShapeOutlineColor.SelectedItem).Color_0;
				if (color_2.R != this.nullable_2[0] || color_2.G != this.nullable_2[1] || color_2.B != this.nullable_2[2])
				{
					@enum |= Enum38.const_10;
				}
			}
			if (this.m_nudShapeOutlineWidth.Text != "")
			{
				decimal num3 = this.m_nudShapeOutlineWidth.Value * 20m;
				int? num4 = this.nullable_3;
				if (num3 != (decimal)num4.GetValueOrDefault() || !num4.HasValue)
				{
					@enum |= Enum38.const_11;
				}
			}
			if (this.m_nudRotation.Text != "")
			{
				int? num5 = this.nullable_5;
				decimal value = this.m_nudRotation.Value;
				if ((decimal)num5.GetValueOrDefault() != value || !num5.HasValue)
				{
					@enum |= Enum38.const_5;
				}
			}
			if (((this.m_cbxFlipHorizontal.CheckState != CheckState.Indeterminate) ? new bool?(this.m_cbxFlipHorizontal.Checked) : null) != this.nullable_6)
			{
				@enum |= Enum38.const_6;
			}
			if (((this.m_cbxFlipVertical.CheckState != CheckState.Indeterminate) ? new bool?(this.m_cbxFlipVertical.Checked) : null) != this.nullable_7)
			{
				@enum |= Enum38.const_7;
			}
			return @enum;
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			this.uint_0 = Class375.smethod_0(null, this);
			Class373.Struct32 struct32_ = default(Class373.Struct32);
			Class373.GetWindowRect(base.Handle, ref struct32_);
			Class375.smethod_1(this.uint_0, struct32_, this);
			base.OnHandleCreated(eventArgs_0);
		}

		protected override void WndProc(ref Message message)
		{
			int msg = message.Msg;
			if (msg == 736)
			{
				uint num = Class373.smethod_0(message.WParam.ToInt32());
				if (num != this.uint_0)
				{
					Class373.Struct32 struct32_ = (Class373.Struct32)Marshal.PtrToStructure(message.LParam, typeof(Class373.Struct32));
					this.Font = new Font(this.Font.Name, this.Font.Size * (float)num / (float)this.uint_0, this.Font.Style, this.Font.Unit);
					this.uint_0 = num;
					Class375.smethod_1(this.uint_0, struct32_, this);
				}
			}
			else
			{
				base.WndProc(ref message);
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.m_tpgSizeAndDistance = new System.Windows.Forms.TabPage();
			this.m_tlpSizeAndDistance = new System.Windows.Forms.TableLayoutPanel();
			this.m_cbxAutoSize = new System.Windows.Forms.CheckBox();
			this.m_tlpOptionsHeader = new System.Windows.Forms.TableLayoutPanel();
			this.m_lblOptions = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.m_tlpDistanceHeader = new System.Windows.Forms.TableLayoutPanel();
			this.m_lblPosition = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.m_tlpScaleHeader = new System.Windows.Forms.TableLayoutPanel();
			this.m_lblScale = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
			this.m_tlpSizeHeader = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.m_lblSizeHeight = new System.Windows.Forms.Label();
			this.m_lblSizeHeightMeasureUnit = new System.Windows.Forms.Label();
			this.m_lblSizeWidth = new System.Windows.Forms.Label();
			this.m_lblSizeWidthMeasureUnit = new System.Windows.Forms.Label();
			this.m_lblScaleHeight = new System.Windows.Forms.Label();
			this.m_lbScalePercentHeight = new System.Windows.Forms.Label();
			this.m_lblScaleWidth = new System.Windows.Forms.Label();
			this.m_lbScalePercentWidth = new System.Windows.Forms.Label();
			this.m_lblPositionY = new System.Windows.Forms.Label();
			this.m_lblPositionX = new System.Windows.Forms.Label();
			this.m_lblMeasureUnitY = new System.Windows.Forms.Label();
			this.m_lblMeasureUnitX = new System.Windows.Forms.Label();
			this.m_nudSizeHeight = new System.Windows.Forms.NumericUpDown();
			this.m_nudSizeWidth = new System.Windows.Forms.NumericUpDown();
			this.m_nudLocationY = new System.Windows.Forms.NumericUpDown();
			this.m_nudScaleHeight = new System.Windows.Forms.NumericUpDown();
			this.m_nudScaleWidth = new System.Windows.Forms.NumericUpDown();
			this.m_nudLocationX = new System.Windows.Forms.NumericUpDown();
			this.m_cbxMovable = new System.Windows.Forms.CheckBox();
			this.m_cbxSizable = new System.Windows.Forms.CheckBox();
			this.m_tpgOutlineAndFill = new System.Windows.Forms.TabPage();
			this.m_tlpOutlineAndFill = new System.Windows.Forms.TableLayoutPanel();
			this.m_tlpAppearanceHeader = new System.Windows.Forms.TableLayoutPanel();
			this.m_lblAppearance = new System.Windows.Forms.Label();
			this.m_lblAppearanceSeparator = new System.Windows.Forms.Label();
			this.m_tlpShapeOutlineHeader = new System.Windows.Forms.TableLayoutPanel();
			this.m_lblShapeOutline = new System.Windows.Forms.Label();
			this.m_lblShapeOutlineSeparator = new System.Windows.Forms.Label();
			this.m_tlpShapeFillHeader = new System.Windows.Forms.TableLayoutPanel();
			this.m_lblShapeFill = new System.Windows.Forms.Label();
			this.m_lblShapeFillSeparator = new System.Windows.Forms.Label();
			this.m_lblShapeFillTransparency = new System.Windows.Forms.Label();
			this.m_lblShapeOutlineColor = new System.Windows.Forms.Label();
			this.m_lblRotation = new System.Windows.Forms.Label();
			this.m_lblFlip = new System.Windows.Forms.Label();
			this.m_cbxFlipHorizontal = new System.Windows.Forms.CheckBox();
			this.m_cbxFlipVertical = new System.Windows.Forms.CheckBox();
			this.m_nudRotation = new System.Windows.Forms.NumericUpDown();
			this.m_nudShapeOutlineWidth = new System.Windows.Forms.NumericUpDown();
			this.m_lblShapeOutlineWidth = new System.Windows.Forms.Label();
			this.m_nudShapeFillTransparencyPercent = new System.Windows.Forms.NumericUpDown();
			this.m_btnShapeFillColor = new System.Windows.Forms.Button();
			this.m_btnShapeOutlineColor = new System.Windows.Forms.Button();
			this.m_lblShapeFillTransparencyPercent = new System.Windows.Forms.Label();
			this.m_lblShapeOutlineWidthPT = new System.Windows.Forms.Label();
			this.m_lblRotationDegree = new System.Windows.Forms.Label();
			this.m_lblShapeFillColor = new System.Windows.Forms.Label();
			this.m_cmbxShapeFillColor = new System.Windows.Forms.ComboBox();
			this.m_cmbxShapeOutlineColor = new System.Windows.Forms.ComboBox();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.m_tpgSizeAndDistance.SuspendLayout();
			this.m_tlpSizeAndDistance.SuspendLayout();
			this.m_tlpOptionsHeader.SuspendLayout();
			this.m_tlpDistanceHeader.SuspendLayout();
			this.m_tlpScaleHeader.SuspendLayout();
			this.tableLayoutPanel10.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.m_nudSizeHeight).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.m_nudSizeWidth).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.m_nudLocationY).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.m_nudScaleHeight).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.m_nudScaleWidth).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.m_nudLocationX).BeginInit();
			this.m_tpgOutlineAndFill.SuspendLayout();
			this.m_tlpOutlineAndFill.SuspendLayout();
			this.m_tlpAppearanceHeader.SuspendLayout();
			this.m_tlpShapeOutlineHeader.SuspendLayout();
			this.m_tlpShapeFillHeader.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.m_nudRotation).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.m_nudShapeOutlineWidth).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.m_nudShapeFillTransparencyPercent).BeginInit();
			base.SuspendLayout();
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20f));
			this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.m_btnCancel, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.m_btnOK, 1, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 7);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(383, 350);
			this.tableLayoutPanel1.TabIndex = 0;
			this.tableLayoutPanel1.SetColumnSpan(this.tabControl1, 3);
			this.tabControl1.Controls.Add(this.m_tpgSizeAndDistance);
			this.tabControl1.Controls.Add(this.m_tpgOutlineAndFill);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 7);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(383, 318);
			this.tabControl1.TabIndex = 1;
			this.m_tpgSizeAndDistance.Controls.Add(this.m_tlpSizeAndDistance);
			this.m_tpgSizeAndDistance.Location = new System.Drawing.Point(4, 22);
			this.m_tpgSizeAndDistance.Name = "m_tpgSizeAndDistance";
			this.m_tpgSizeAndDistance.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
			this.m_tpgSizeAndDistance.Size = new System.Drawing.Size(375, 292);
			this.m_tpgSizeAndDistance.TabIndex = 5;
			this.m_tpgSizeAndDistance.Text = "x";
			this.m_tpgSizeAndDistance.UseVisualStyleBackColor = true;
			this.m_tlpSizeAndDistance.AutoSize = true;
			this.m_tlpSizeAndDistance.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_tlpSizeAndDistance.ColumnCount = 7;
			this.m_tlpSizeAndDistance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpSizeAndDistance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpSizeAndDistance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpSizeAndDistance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpSizeAndDistance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpSizeAndDistance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpSizeAndDistance.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpSizeAndDistance.Controls.Add(this.m_cbxAutoSize, 4, 7);
			this.m_tlpSizeAndDistance.Controls.Add(this.m_tlpOptionsHeader, 0, 6);
			this.m_tlpSizeAndDistance.Controls.Add(this.m_tlpDistanceHeader, 0, 4);
			this.m_tlpSizeAndDistance.Controls.Add(this.m_tlpScaleHeader, 0, 2);
			this.m_tlpSizeAndDistance.Controls.Add(this.tableLayoutPanel10, 0, 0);
			this.m_tlpSizeAndDistance.Controls.Add(this.m_lblSizeHeight, 0, 1);
			this.m_tlpSizeAndDistance.Controls.Add(this.m_lblSizeHeightMeasureUnit, 2, 1);
			this.m_tlpSizeAndDistance.Controls.Add(this.m_lblSizeWidth, 4, 1);
			this.m_tlpSizeAndDistance.Controls.Add(this.m_lblSizeWidthMeasureUnit, 6, 1);
			this.m_tlpSizeAndDistance.Controls.Add(this.m_lblScaleHeight, 0, 3);
			this.m_tlpSizeAndDistance.Controls.Add(this.m_lbScalePercentHeight, 2, 3);
			this.m_tlpSizeAndDistance.Controls.Add(this.m_lblScaleWidth, 4, 3);
			this.m_tlpSizeAndDistance.Controls.Add(this.m_lbScalePercentWidth, 6, 3);
			this.m_tlpSizeAndDistance.Controls.Add(this.m_lblPositionY, 0, 5);
			this.m_tlpSizeAndDistance.Controls.Add(this.m_lblPositionX, 4, 5);
			this.m_tlpSizeAndDistance.Controls.Add(this.m_lblMeasureUnitY, 2, 5);
			this.m_tlpSizeAndDistance.Controls.Add(this.m_lblMeasureUnitX, 6, 5);
			this.m_tlpSizeAndDistance.Controls.Add(this.m_nudSizeHeight, 1, 1);
			this.m_tlpSizeAndDistance.Controls.Add(this.m_nudSizeWidth, 5, 1);
			this.m_tlpSizeAndDistance.Controls.Add(this.m_nudLocationY, 1, 5);
			this.m_tlpSizeAndDistance.Controls.Add(this.m_nudScaleHeight, 1, 3);
			this.m_tlpSizeAndDistance.Controls.Add(this.m_nudScaleWidth, 5, 3);
			this.m_tlpSizeAndDistance.Controls.Add(this.m_nudLocationX, 5, 5);
			this.m_tlpSizeAndDistance.Controls.Add(this.m_cbxMovable, 0, 7);
			this.m_tlpSizeAndDistance.Controls.Add(this.m_cbxSizable, 0, 8);
			this.m_tlpSizeAndDistance.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_tlpSizeAndDistance.Location = new System.Drawing.Point(3, 3);
			this.m_tlpSizeAndDistance.Margin = new System.Windows.Forms.Padding(0);
			this.m_tlpSizeAndDistance.Name = "m_tlpSizeAndDistance";
			this.m_tlpSizeAndDistance.Padding = new System.Windows.Forms.Padding(4, 11, 4, 4);
			this.m_tlpSizeAndDistance.RowCount = 9;
			this.m_tlpSizeAndDistance.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpSizeAndDistance.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpSizeAndDistance.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpSizeAndDistance.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpSizeAndDistance.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpSizeAndDistance.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpSizeAndDistance.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpSizeAndDistance.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpSizeAndDistance.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpSizeAndDistance.Size = new System.Drawing.Size(369, 286);
			this.m_tlpSizeAndDistance.TabIndex = 0;
			this.m_cbxAutoSize.AutoSize = true;
			this.m_tlpSizeAndDistance.SetColumnSpan(this.m_cbxAutoSize, 3);
			this.m_cbxAutoSize.Location = new System.Drawing.Point(258, 222);
			this.m_cbxAutoSize.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
			this.m_cbxAutoSize.Name = "m_cbxAutoSize";
			this.m_cbxAutoSize.Size = new System.Drawing.Size(31, 17);
			this.m_cbxAutoSize.TabIndex = 33;
			this.m_cbxAutoSize.Text = "x";
			this.m_cbxAutoSize.UseVisualStyleBackColor = true;
			this.m_tlpOptionsHeader.ColumnCount = 2;
			this.m_tlpSizeAndDistance.SetColumnSpan(this.m_tlpOptionsHeader, 37);
			this.m_tlpOptionsHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpOptionsHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpOptionsHeader.Controls.Add(this.m_lblOptions, 0, 0);
			this.m_tlpOptionsHeader.Controls.Add(this.label11, 1, 0);
			this.m_tlpOptionsHeader.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_tlpOptionsHeader.Location = new System.Drawing.Point(4, 200);
			this.m_tlpOptionsHeader.Margin = new System.Windows.Forms.Padding(0, 23, 0, 2);
			this.m_tlpOptionsHeader.Name = "m_tlpOptionsHeader";
			this.m_tlpOptionsHeader.RowCount = 1;
			this.m_tlpOptionsHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpOptionsHeader.Size = new System.Drawing.Size(361, 20);
			this.m_tlpOptionsHeader.TabIndex = 28;
			this.m_lblOptions.AutoSize = true;
			this.m_lblOptions.Location = new System.Drawing.Point(0, 0);
			this.m_lblOptions.Margin = new System.Windows.Forms.Padding(0);
			this.m_lblOptions.Name = "m_lblOptions";
			this.m_lblOptions.Size = new System.Drawing.Size(12, 13);
			this.m_lblOptions.TabIndex = 29;
			this.m_lblOptions.Text = "x";
			this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label11.Dock = System.Windows.Forms.DockStyle.Top;
			this.label11.Location = new System.Drawing.Point(15, 4);
			this.label11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(343, 2);
			this.label11.TabIndex = 30;
			this.label11.Text = "label11";
			this.m_tlpDistanceHeader.ColumnCount = 2;
			this.m_tlpSizeAndDistance.SetColumnSpan(this.m_tlpDistanceHeader, 37);
			this.m_tlpDistanceHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpDistanceHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpDistanceHeader.Controls.Add(this.m_lblPosition, 0, 0);
			this.m_tlpDistanceHeader.Controls.Add(this.label7, 1, 0);
			this.m_tlpDistanceHeader.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_tlpDistanceHeader.Location = new System.Drawing.Point(4, 137);
			this.m_tlpDistanceHeader.Margin = new System.Windows.Forms.Padding(0, 23, 0, 0);
			this.m_tlpDistanceHeader.Name = "m_tlpDistanceHeader";
			this.m_tlpDistanceHeader.RowCount = 1;
			this.m_tlpDistanceHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpDistanceHeader.Size = new System.Drawing.Size(361, 20);
			this.m_tlpDistanceHeader.TabIndex = 19;
			this.m_lblPosition.AutoSize = true;
			this.m_lblPosition.Location = new System.Drawing.Point(0, 0);
			this.m_lblPosition.Margin = new System.Windows.Forms.Padding(0);
			this.m_lblPosition.Name = "m_lblPosition";
			this.m_lblPosition.Size = new System.Drawing.Size(12, 13);
			this.m_lblPosition.TabIndex = 20;
			this.m_lblPosition.Text = "x";
			this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label7.Dock = System.Windows.Forms.DockStyle.Top;
			this.label7.Location = new System.Drawing.Point(15, 4);
			this.label7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(343, 2);
			this.label7.TabIndex = 21;
			this.label7.Text = "label7";
			this.m_tlpScaleHeader.ColumnCount = 2;
			this.m_tlpSizeAndDistance.SetColumnSpan(this.m_tlpScaleHeader, 37);
			this.m_tlpScaleHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpScaleHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpScaleHeader.Controls.Add(this.m_lblScale, 0, 0);
			this.m_tlpScaleHeader.Controls.Add(this.label4, 1, 0);
			this.m_tlpScaleHeader.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_tlpScaleHeader.Location = new System.Drawing.Point(4, 74);
			this.m_tlpScaleHeader.Margin = new System.Windows.Forms.Padding(0, 23, 0, 0);
			this.m_tlpScaleHeader.Name = "m_tlpScaleHeader";
			this.m_tlpScaleHeader.RowCount = 1;
			this.m_tlpScaleHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpScaleHeader.Size = new System.Drawing.Size(361, 20);
			this.m_tlpScaleHeader.TabIndex = 10;
			this.m_lblScale.AutoSize = true;
			this.m_lblScale.Location = new System.Drawing.Point(0, 0);
			this.m_lblScale.Margin = new System.Windows.Forms.Padding(0);
			this.m_lblScale.Name = "m_lblScale";
			this.m_lblScale.Size = new System.Drawing.Size(12, 13);
			this.m_lblScale.TabIndex = 11;
			this.m_lblScale.Text = "x";
			this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label4.Dock = System.Windows.Forms.DockStyle.Top;
			this.label4.Location = new System.Drawing.Point(13, 6);
			this.label4.Margin = new System.Windows.Forms.Padding(1, 6, 2, 3);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(346, 2);
			this.label4.TabIndex = 12;
			this.label4.Text = "label4";
			this.tableLayoutPanel10.ColumnCount = 2;
			this.m_tlpSizeAndDistance.SetColumnSpan(this.tableLayoutPanel10, 37);
			this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel10.Controls.Add(this.m_tlpSizeHeader, 0, 0);
			this.tableLayoutPanel10.Controls.Add(this.label2, 1, 0);
			this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel10.Location = new System.Drawing.Point(4, 11);
			this.tableLayoutPanel10.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel10.Name = "tableLayoutPanel10";
			this.tableLayoutPanel10.RowCount = 1;
			this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel10.Size = new System.Drawing.Size(361, 20);
			this.tableLayoutPanel10.TabIndex = 1;
			this.m_tlpSizeHeader.AutoSize = true;
			this.m_tlpSizeHeader.Location = new System.Drawing.Point(0, 0);
			this.m_tlpSizeHeader.Margin = new System.Windows.Forms.Padding(0);
			this.m_tlpSizeHeader.Name = "m_tlpSizeHeader";
			this.m_tlpSizeHeader.Size = new System.Drawing.Size(12, 13);
			this.m_tlpSizeHeader.TabIndex = 2;
			this.m_tlpSizeHeader.Text = "x";
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label2.Dock = System.Windows.Forms.DockStyle.Top;
			this.label2.Location = new System.Drawing.Point(15, 4);
			this.label2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(343, 2);
			this.label2.TabIndex = 3;
			this.label2.Text = "label2";
			this.m_lblSizeHeight.AutoSize = true;
			this.m_lblSizeHeight.Location = new System.Drawing.Point(4, 33);
			this.m_lblSizeHeight.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.m_lblSizeHeight.Name = "m_lblSizeHeight";
			this.m_lblSizeHeight.Size = new System.Drawing.Size(12, 13);
			this.m_lblSizeHeight.TabIndex = 4;
			this.m_lblSizeHeight.Text = "x";
			this.m_lblSizeHeightMeasureUnit.AutoSize = true;
			this.m_lblSizeHeightMeasureUnit.Location = new System.Drawing.Point(88, 33);
			this.m_lblSizeHeightMeasureUnit.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.m_lblSizeHeightMeasureUnit.Name = "m_lblSizeHeightMeasureUnit";
			this.m_lblSizeHeightMeasureUnit.Size = new System.Drawing.Size(12, 13);
			this.m_lblSizeHeightMeasureUnit.TabIndex = 6;
			this.m_lblSizeHeightMeasureUnit.Text = "x";
			this.m_lblSizeWidth.AutoSize = true;
			this.m_lblSizeWidth.Location = new System.Drawing.Point(254, 33);
			this.m_lblSizeWidth.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.m_lblSizeWidth.Name = "m_lblSizeWidth";
			this.m_lblSizeWidth.Size = new System.Drawing.Size(12, 13);
			this.m_lblSizeWidth.TabIndex = 7;
			this.m_lblSizeWidth.Text = "x";
			this.m_lblSizeWidthMeasureUnit.AutoSize = true;
			this.m_lblSizeWidthMeasureUnit.Location = new System.Drawing.Point(338, 33);
			this.m_lblSizeWidthMeasureUnit.Margin = new System.Windows.Forms.Padding(0, 2, 15, 0);
			this.m_lblSizeWidthMeasureUnit.Name = "m_lblSizeWidthMeasureUnit";
			this.m_lblSizeWidthMeasureUnit.Size = new System.Drawing.Size(12, 13);
			this.m_lblSizeWidthMeasureUnit.TabIndex = 9;
			this.m_lblSizeWidthMeasureUnit.Text = "x";
			this.m_lblScaleHeight.AutoSize = true;
			this.m_lblScaleHeight.Location = new System.Drawing.Point(4, 96);
			this.m_lblScaleHeight.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.m_lblScaleHeight.Name = "m_lblScaleHeight";
			this.m_lblScaleHeight.Size = new System.Drawing.Size(12, 13);
			this.m_lblScaleHeight.TabIndex = 13;
			this.m_lblScaleHeight.Text = "x";
			this.m_lbScalePercentHeight.AutoSize = true;
			this.m_lbScalePercentHeight.Location = new System.Drawing.Point(88, 96);
			this.m_lbScalePercentHeight.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.m_lbScalePercentHeight.Name = "m_lbScalePercentHeight";
			this.m_lbScalePercentHeight.Size = new System.Drawing.Size(12, 13);
			this.m_lbScalePercentHeight.TabIndex = 15;
			this.m_lbScalePercentHeight.Text = "x";
			this.m_lblScaleWidth.AutoSize = true;
			this.m_lblScaleWidth.Location = new System.Drawing.Point(254, 96);
			this.m_lblScaleWidth.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.m_lblScaleWidth.Name = "m_lblScaleWidth";
			this.m_lblScaleWidth.Size = new System.Drawing.Size(12, 13);
			this.m_lblScaleWidth.TabIndex = 16;
			this.m_lblScaleWidth.Text = "x";
			this.m_lbScalePercentWidth.AutoSize = true;
			this.m_lbScalePercentWidth.Location = new System.Drawing.Point(338, 96);
			this.m_lbScalePercentWidth.Margin = new System.Windows.Forms.Padding(0, 2, 15, 0);
			this.m_lbScalePercentWidth.Name = "m_lbScalePercentWidth";
			this.m_lbScalePercentWidth.Size = new System.Drawing.Size(12, 13);
			this.m_lbScalePercentWidth.TabIndex = 18;
			this.m_lbScalePercentWidth.Text = "x";
			this.m_lblPositionY.AutoSize = true;
			this.m_lblPositionY.Location = new System.Drawing.Point(4, 159);
			this.m_lblPositionY.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.m_lblPositionY.Name = "m_lblPositionY";
			this.m_lblPositionY.Size = new System.Drawing.Size(12, 13);
			this.m_lblPositionY.TabIndex = 22;
			this.m_lblPositionY.Text = "x";
			this.m_lblPositionX.AutoSize = true;
			this.m_lblPositionX.Location = new System.Drawing.Point(254, 159);
			this.m_lblPositionX.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.m_lblPositionX.Name = "m_lblPositionX";
			this.m_lblPositionX.Size = new System.Drawing.Size(12, 13);
			this.m_lblPositionX.TabIndex = 25;
			this.m_lblPositionX.Text = "x";
			this.m_lblMeasureUnitY.AutoSize = true;
			this.m_lblMeasureUnitY.Location = new System.Drawing.Point(88, 159);
			this.m_lblMeasureUnitY.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
			this.m_lblMeasureUnitY.Name = "m_lblMeasureUnitY";
			this.m_lblMeasureUnitY.Size = new System.Drawing.Size(12, 13);
			this.m_lblMeasureUnitY.TabIndex = 24;
			this.m_lblMeasureUnitY.Text = "x";
			this.m_lblMeasureUnitX.AutoSize = true;
			this.m_lblMeasureUnitX.Location = new System.Drawing.Point(338, 159);
			this.m_lblMeasureUnitX.Margin = new System.Windows.Forms.Padding(0, 2, 15, 0);
			this.m_lblMeasureUnitX.Name = "m_lblMeasureUnitX";
			this.m_lblMeasureUnitX.Size = new System.Drawing.Size(12, 13);
			this.m_lblMeasureUnitX.TabIndex = 27;
			this.m_lblMeasureUnitX.Text = "x";
			this.m_nudSizeHeight.Location = new System.Drawing.Point(16, 31);
			this.m_nudSizeHeight.Margin = new System.Windows.Forms.Padding(0);
			this.m_nudSizeHeight.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			this.m_nudSizeHeight.Name = "m_nudSizeHeight";
			this.m_nudSizeHeight.Size = new System.Drawing.Size(72, 20);
			this.m_nudSizeHeight.TabIndex = 5;
			this.m_nudSizeWidth.Location = new System.Drawing.Point(266, 31);
			this.m_nudSizeWidth.Margin = new System.Windows.Forms.Padding(0);
			this.m_nudSizeWidth.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			this.m_nudSizeWidth.Name = "m_nudSizeWidth";
			this.m_nudSizeWidth.Size = new System.Drawing.Size(72, 20);
			this.m_nudSizeWidth.TabIndex = 8;
			this.m_nudLocationY.Location = new System.Drawing.Point(16, 157);
			this.m_nudLocationY.Margin = new System.Windows.Forms.Padding(0);
			this.m_nudLocationY.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			this.m_nudLocationY.Minimum = new decimal(new int[4] { 1000, 0, 0, -2147483648 });
			this.m_nudLocationY.Name = "m_nudLocationY";
			this.m_nudLocationY.Size = new System.Drawing.Size(72, 20);
			this.m_nudLocationY.TabIndex = 23;
			this.m_nudScaleHeight.Location = new System.Drawing.Point(16, 94);
			this.m_nudScaleHeight.Margin = new System.Windows.Forms.Padding(0);
			this.m_nudScaleHeight.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			this.m_nudScaleHeight.Name = "m_nudScaleHeight";
			this.m_nudScaleHeight.Size = new System.Drawing.Size(72, 20);
			this.m_nudScaleHeight.TabIndex = 14;
			this.m_nudScaleHeight.Value = new decimal(new int[4] { 100, 0, 0, 0 });
			this.m_nudScaleWidth.Location = new System.Drawing.Point(266, 94);
			this.m_nudScaleWidth.Margin = new System.Windows.Forms.Padding(0);
			this.m_nudScaleWidth.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			this.m_nudScaleWidth.Name = "m_nudScaleWidth";
			this.m_nudScaleWidth.Size = new System.Drawing.Size(72, 20);
			this.m_nudScaleWidth.TabIndex = 17;
			this.m_nudScaleWidth.Value = new decimal(new int[4] { 100, 0, 0, 0 });
			this.m_nudLocationX.Location = new System.Drawing.Point(266, 157);
			this.m_nudLocationX.Margin = new System.Windows.Forms.Padding(0);
			this.m_nudLocationX.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			this.m_nudLocationX.Minimum = new decimal(new int[4] { 1000, 0, 0, -2147483648 });
			this.m_nudLocationX.Name = "m_nudLocationX";
			this.m_nudLocationX.Size = new System.Drawing.Size(72, 20);
			this.m_nudLocationX.TabIndex = 26;
			this.m_cbxMovable.AutoSize = true;
			this.m_tlpSizeAndDistance.SetColumnSpan(this.m_cbxMovable, 3);
			this.m_cbxMovable.Location = new System.Drawing.Point(8, 222);
			this.m_cbxMovable.Margin = new System.Windows.Forms.Padding(4, 0, 0, 6);
			this.m_cbxMovable.Name = "m_cbxMovable";
			this.m_cbxMovable.Size = new System.Drawing.Size(31, 17);
			this.m_cbxMovable.TabIndex = 31;
			this.m_cbxMovable.Text = "x";
			this.m_cbxMovable.UseVisualStyleBackColor = true;
			this.m_cbxSizable.AutoSize = true;
			this.m_tlpSizeAndDistance.SetColumnSpan(this.m_cbxSizable, 3);
			this.m_cbxSizable.Location = new System.Drawing.Point(8, 245);
			this.m_cbxSizable.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
			this.m_cbxSizable.Name = "m_cbxSizable";
			this.m_cbxSizable.Size = new System.Drawing.Size(31, 17);
			this.m_cbxSizable.TabIndex = 32;
			this.m_cbxSizable.Text = "x";
			this.m_cbxSizable.UseVisualStyleBackColor = true;
			this.m_tpgOutlineAndFill.Controls.Add(this.m_tlpOutlineAndFill);
			this.m_tpgOutlineAndFill.Location = new System.Drawing.Point(4, 22);
			this.m_tpgOutlineAndFill.Name = "m_tpgOutlineAndFill";
			this.m_tpgOutlineAndFill.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
			this.m_tpgOutlineAndFill.Size = new System.Drawing.Size(371, 292);
			this.m_tpgOutlineAndFill.TabIndex = 2;
			this.m_tpgOutlineAndFill.Text = "x";
			this.m_tpgOutlineAndFill.UseVisualStyleBackColor = true;
			this.m_tlpOutlineAndFill.ColumnCount = 4;
			this.m_tlpOutlineAndFill.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpOutlineAndFill.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpOutlineAndFill.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpOutlineAndFill.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpOutlineAndFill.Controls.Add(this.m_tlpAppearanceHeader, 0, 6);
			this.m_tlpOutlineAndFill.Controls.Add(this.m_tlpShapeOutlineHeader, 0, 3);
			this.m_tlpOutlineAndFill.Controls.Add(this.m_tlpShapeFillHeader, 0, 0);
			this.m_tlpOutlineAndFill.Controls.Add(this.m_lblShapeFillTransparency, 0, 2);
			this.m_tlpOutlineAndFill.Controls.Add(this.m_lblShapeOutlineColor, 0, 4);
			this.m_tlpOutlineAndFill.Controls.Add(this.m_lblRotation, 0, 7);
			this.m_tlpOutlineAndFill.Controls.Add(this.m_lblFlip, 0, 8);
			this.m_tlpOutlineAndFill.Controls.Add(this.m_cbxFlipHorizontal, 1, 8);
			this.m_tlpOutlineAndFill.Controls.Add(this.m_cbxFlipVertical, 1, 9);
			this.m_tlpOutlineAndFill.Controls.Add(this.m_nudRotation, 1, 7);
			this.m_tlpOutlineAndFill.Controls.Add(this.m_nudShapeOutlineWidth, 1, 5);
			this.m_tlpOutlineAndFill.Controls.Add(this.m_lblShapeOutlineWidth, 0, 5);
			this.m_tlpOutlineAndFill.Controls.Add(this.m_nudShapeFillTransparencyPercent, 1, 2);
			this.m_tlpOutlineAndFill.Controls.Add(this.m_btnShapeFillColor, 3, 1);
			this.m_tlpOutlineAndFill.Controls.Add(this.m_btnShapeOutlineColor, 3, 4);
			this.m_tlpOutlineAndFill.Controls.Add(this.m_lblShapeFillTransparencyPercent, 2, 2);
			this.m_tlpOutlineAndFill.Controls.Add(this.m_lblShapeOutlineWidthPT, 2, 5);
			this.m_tlpOutlineAndFill.Controls.Add(this.m_lblRotationDegree, 2, 7);
			this.m_tlpOutlineAndFill.Controls.Add(this.m_lblShapeFillColor, 0, 1);
			this.m_tlpOutlineAndFill.Controls.Add(this.m_cmbxShapeFillColor, 1, 1);
			this.m_tlpOutlineAndFill.Controls.Add(this.m_cmbxShapeOutlineColor, 1, 4);
			this.m_tlpOutlineAndFill.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_tlpOutlineAndFill.Location = new System.Drawing.Point(3, 3);
			this.m_tlpOutlineAndFill.Margin = new System.Windows.Forms.Padding(0);
			this.m_tlpOutlineAndFill.Name = "m_tlpOutlineAndFill";
			this.m_tlpOutlineAndFill.Padding = new System.Windows.Forms.Padding(4, 11, 4, 4);
			this.m_tlpOutlineAndFill.RowCount = 10;
			this.m_tlpOutlineAndFill.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpOutlineAndFill.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpOutlineAndFill.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpOutlineAndFill.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpOutlineAndFill.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpOutlineAndFill.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpOutlineAndFill.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpOutlineAndFill.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpOutlineAndFill.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpOutlineAndFill.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpOutlineAndFill.Size = new System.Drawing.Size(365, 286);
			this.m_tlpOutlineAndFill.TabIndex = 0;
			this.m_tlpAppearanceHeader.ColumnCount = 2;
			this.m_tlpOutlineAndFill.SetColumnSpan(this.m_tlpAppearanceHeader, 37);
			this.m_tlpAppearanceHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpAppearanceHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpAppearanceHeader.Controls.Add(this.m_lblAppearance, 0, 0);
			this.m_tlpAppearanceHeader.Controls.Add(this.m_lblAppearanceSeparator, 1, 0);
			this.m_tlpAppearanceHeader.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_tlpAppearanceHeader.Location = new System.Drawing.Point(4, 167);
			this.m_tlpAppearanceHeader.Margin = new System.Windows.Forms.Padding(0, 13, 0, 2);
			this.m_tlpAppearanceHeader.Name = "m_tlpAppearanceHeader";
			this.m_tlpAppearanceHeader.RowCount = 1;
			this.m_tlpAppearanceHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpAppearanceHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20f));
			this.m_tlpAppearanceHeader.Size = new System.Drawing.Size(357, 20);
			this.m_tlpAppearanceHeader.TabIndex = 19;
			this.m_lblAppearance.AutoSize = true;
			this.m_lblAppearance.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblAppearance.Location = new System.Drawing.Point(2, 0);
			this.m_lblAppearance.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_lblAppearance.Name = "m_lblAppearance";
			this.m_lblAppearance.Size = new System.Drawing.Size(12, 13);
			this.m_lblAppearance.TabIndex = 20;
			this.m_lblAppearance.Text = "x";
			this.m_lblAppearanceSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.m_lblAppearanceSeparator.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblAppearanceSeparator.Location = new System.Drawing.Point(19, 4);
			this.m_lblAppearanceSeparator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
			this.m_lblAppearanceSeparator.Name = "m_lblAppearanceSeparator";
			this.m_lblAppearanceSeparator.Size = new System.Drawing.Size(335, 2);
			this.m_lblAppearanceSeparator.TabIndex = 21;
			this.m_lblAppearanceSeparator.Text = "label9";
			this.m_tlpShapeOutlineHeader.ColumnCount = 2;
			this.m_tlpOutlineAndFill.SetColumnSpan(this.m_tlpShapeOutlineHeader, 37);
			this.m_tlpShapeOutlineHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpShapeOutlineHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpShapeOutlineHeader.Controls.Add(this.m_lblShapeOutline, 0, 0);
			this.m_tlpShapeOutlineHeader.Controls.Add(this.m_lblShapeOutlineSeparator, 1, 0);
			this.m_tlpShapeOutlineHeader.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_tlpShapeOutlineHeader.Location = new System.Drawing.Point(4, 89);
			this.m_tlpShapeOutlineHeader.Margin = new System.Windows.Forms.Padding(0, 13, 0, 2);
			this.m_tlpShapeOutlineHeader.Name = "m_tlpShapeOutlineHeader";
			this.m_tlpShapeOutlineHeader.RowCount = 1;
			this.m_tlpShapeOutlineHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpShapeOutlineHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20f));
			this.m_tlpShapeOutlineHeader.Size = new System.Drawing.Size(357, 20);
			this.m_tlpShapeOutlineHeader.TabIndex = 10;
			this.m_lblShapeOutline.AutoSize = true;
			this.m_lblShapeOutline.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblShapeOutline.Location = new System.Drawing.Point(2, 0);
			this.m_lblShapeOutline.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_lblShapeOutline.Name = "m_lblShapeOutline";
			this.m_lblShapeOutline.Size = new System.Drawing.Size(12, 13);
			this.m_lblShapeOutline.TabIndex = 11;
			this.m_lblShapeOutline.Text = "x";
			this.m_lblShapeOutlineSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.m_lblShapeOutlineSeparator.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblShapeOutlineSeparator.Location = new System.Drawing.Point(19, 4);
			this.m_lblShapeOutlineSeparator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
			this.m_lblShapeOutlineSeparator.Name = "m_lblShapeOutlineSeparator";
			this.m_lblShapeOutlineSeparator.Size = new System.Drawing.Size(335, 2);
			this.m_lblShapeOutlineSeparator.TabIndex = 12;
			this.m_lblShapeOutlineSeparator.Text = "label6";
			this.m_tlpShapeFillHeader.ColumnCount = 2;
			this.m_tlpOutlineAndFill.SetColumnSpan(this.m_tlpShapeFillHeader, 37);
			this.m_tlpShapeFillHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_tlpShapeFillHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_tlpShapeFillHeader.Controls.Add(this.m_lblShapeFill, 0, 0);
			this.m_tlpShapeFillHeader.Controls.Add(this.m_lblShapeFillSeparator, 1, 0);
			this.m_tlpShapeFillHeader.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_tlpShapeFillHeader.Location = new System.Drawing.Point(4, 11);
			this.m_tlpShapeFillHeader.Margin = new System.Windows.Forms.Padding(0, 0, 0, 2);
			this.m_tlpShapeFillHeader.Name = "m_tlpShapeFillHeader";
			this.m_tlpShapeFillHeader.RowCount = 1;
			this.m_tlpShapeFillHeader.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_tlpShapeFillHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20f));
			this.m_tlpShapeFillHeader.Size = new System.Drawing.Size(357, 20);
			this.m_tlpShapeFillHeader.TabIndex = 1;
			this.m_lblShapeFill.AutoSize = true;
			this.m_lblShapeFill.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblShapeFill.Location = new System.Drawing.Point(2, 0);
			this.m_lblShapeFill.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_lblShapeFill.Name = "m_lblShapeFill";
			this.m_lblShapeFill.Size = new System.Drawing.Size(12, 13);
			this.m_lblShapeFill.TabIndex = 2;
			this.m_lblShapeFill.Text = "x";
			this.m_lblShapeFillSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.m_lblShapeFillSeparator.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblShapeFillSeparator.Location = new System.Drawing.Point(19, 4);
			this.m_lblShapeFillSeparator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 0);
			this.m_lblShapeFillSeparator.Name = "m_lblShapeFillSeparator";
			this.m_lblShapeFillSeparator.Size = new System.Drawing.Size(335, 2);
			this.m_lblShapeFillSeparator.TabIndex = 3;
			this.m_lblShapeFillSeparator.Text = "label3";
			this.m_lblShapeFillTransparency.AutoSize = true;
			this.m_lblShapeFillTransparency.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblShapeFillTransparency.Location = new System.Drawing.Point(6, 56);
			this.m_lblShapeFillTransparency.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_lblShapeFillTransparency.Name = "m_lblShapeFillTransparency";
			this.m_lblShapeFillTransparency.Size = new System.Drawing.Size(12, 13);
			this.m_lblShapeFillTransparency.TabIndex = 7;
			this.m_lblShapeFillTransparency.Text = "x";
			this.m_lblShapeOutlineColor.AutoSize = true;
			this.m_lblShapeOutlineColor.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblShapeOutlineColor.Location = new System.Drawing.Point(6, 111);
			this.m_lblShapeOutlineColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_lblShapeOutlineColor.Name = "m_lblShapeOutlineColor";
			this.m_lblShapeOutlineColor.Size = new System.Drawing.Size(12, 13);
			this.m_lblShapeOutlineColor.TabIndex = 13;
			this.m_lblShapeOutlineColor.Text = "x";
			this.m_lblRotation.AutoSize = true;
			this.m_lblRotation.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblRotation.Location = new System.Drawing.Point(6, 189);
			this.m_lblRotation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_lblRotation.Name = "m_lblRotation";
			this.m_lblRotation.Size = new System.Drawing.Size(12, 13);
			this.m_lblRotation.TabIndex = 22;
			this.m_lblRotation.Text = "x";
			this.m_lblFlip.AutoSize = true;
			this.m_lblFlip.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblFlip.Location = new System.Drawing.Point(6, 209);
			this.m_lblFlip.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_lblFlip.Name = "m_lblFlip";
			this.m_lblFlip.Size = new System.Drawing.Size(12, 13);
			this.m_lblFlip.TabIndex = 25;
			this.m_lblFlip.Text = "x";
			this.m_cbxFlipHorizontal.AutoSize = true;
			this.m_cbxFlipHorizontal.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_cbxFlipHorizontal.Location = new System.Drawing.Point(20, 209);
			this.m_cbxFlipHorizontal.Margin = new System.Windows.Forms.Padding(0);
			this.m_cbxFlipHorizontal.Name = "m_cbxFlipHorizontal";
			this.m_cbxFlipHorizontal.Size = new System.Drawing.Size(72, 17);
			this.m_cbxFlipHorizontal.TabIndex = 26;
			this.m_cbxFlipHorizontal.Text = "x";
			this.m_cbxFlipHorizontal.UseVisualStyleBackColor = true;
			this.m_cbxFlipVertical.AutoSize = true;
			this.m_cbxFlipVertical.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_cbxFlipVertical.Location = new System.Drawing.Point(20, 226);
			this.m_cbxFlipVertical.Margin = new System.Windows.Forms.Padding(0);
			this.m_cbxFlipVertical.Name = "m_cbxFlipVertical";
			this.m_cbxFlipVertical.Size = new System.Drawing.Size(72, 17);
			this.m_cbxFlipVertical.TabIndex = 27;
			this.m_cbxFlipVertical.Text = "x";
			this.m_cbxFlipVertical.UseVisualStyleBackColor = true;
			this.m_nudRotation.Location = new System.Drawing.Point(20, 189);
			this.m_nudRotation.Margin = new System.Windows.Forms.Padding(0);
			this.m_nudRotation.Maximum = new decimal(new int[4] { 359, 0, 0, 0 });
			this.m_nudRotation.Name = "m_nudRotation";
			this.m_nudRotation.Size = new System.Drawing.Size(72, 20);
			this.m_nudRotation.TabIndex = 23;
			this.m_nudShapeOutlineWidth.Location = new System.Drawing.Point(20, 134);
			this.m_nudShapeOutlineWidth.Margin = new System.Windows.Forms.Padding(0);
			this.m_nudShapeOutlineWidth.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			this.m_nudShapeOutlineWidth.Name = "m_nudShapeOutlineWidth";
			this.m_nudShapeOutlineWidth.Size = new System.Drawing.Size(72, 20);
			this.m_nudShapeOutlineWidth.TabIndex = 17;
			this.m_lblShapeOutlineWidth.AutoSize = true;
			this.m_lblShapeOutlineWidth.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblShapeOutlineWidth.Location = new System.Drawing.Point(6, 134);
			this.m_lblShapeOutlineWidth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_lblShapeOutlineWidth.Name = "m_lblShapeOutlineWidth";
			this.m_lblShapeOutlineWidth.Size = new System.Drawing.Size(12, 13);
			this.m_lblShapeOutlineWidth.TabIndex = 16;
			this.m_lblShapeOutlineWidth.Text = "x";
			this.m_nudShapeFillTransparencyPercent.Location = new System.Drawing.Point(20, 56);
			this.m_nudShapeFillTransparencyPercent.Margin = new System.Windows.Forms.Padding(0);
			this.m_nudShapeFillTransparencyPercent.Name = "m_nudShapeFillTransparencyPercent";
			this.m_nudShapeFillTransparencyPercent.Size = new System.Drawing.Size(72, 20);
			this.m_nudShapeFillTransparencyPercent.TabIndex = 8;
			this.m_btnShapeFillColor.AutoSize = true;
			this.m_btnShapeFillColor.Location = new System.Drawing.Point(118, 33);
			this.m_btnShapeFillColor.Margin = new System.Windows.Forms.Padding(0);
			this.m_btnShapeFillColor.Name = "m_btnShapeFillColor";
			this.m_btnShapeFillColor.Size = new System.Drawing.Size(50, 23);
			this.m_btnShapeFillColor.TabIndex = 6;
			this.m_btnShapeFillColor.Text = "x";
			this.m_btnShapeFillColor.UseVisualStyleBackColor = true;
			this.m_btnShapeOutlineColor.AutoSize = true;
			this.m_btnShapeOutlineColor.Location = new System.Drawing.Point(118, 111);
			this.m_btnShapeOutlineColor.Margin = new System.Windows.Forms.Padding(0);
			this.m_btnShapeOutlineColor.Name = "m_btnShapeOutlineColor";
			this.m_btnShapeOutlineColor.Size = new System.Drawing.Size(50, 23);
			this.m_btnShapeOutlineColor.TabIndex = 15;
			this.m_btnShapeOutlineColor.Text = "x";
			this.m_btnShapeOutlineColor.UseVisualStyleBackColor = true;
			this.m_lblShapeFillTransparencyPercent.AutoSize = true;
			this.m_lblShapeFillTransparencyPercent.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblShapeFillTransparencyPercent.Location = new System.Drawing.Point(94, 56);
			this.m_lblShapeFillTransparencyPercent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_lblShapeFillTransparencyPercent.Name = "m_lblShapeFillTransparencyPercent";
			this.m_lblShapeFillTransparencyPercent.Size = new System.Drawing.Size(22, 13);
			this.m_lblShapeFillTransparencyPercent.TabIndex = 9;
			this.m_lblShapeFillTransparencyPercent.Text = "x";
			this.m_lblShapeOutlineWidthPT.AutoSize = true;
			this.m_lblShapeOutlineWidthPT.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblShapeOutlineWidthPT.Location = new System.Drawing.Point(94, 134);
			this.m_lblShapeOutlineWidthPT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_lblShapeOutlineWidthPT.Name = "m_lblShapeOutlineWidthPT";
			this.m_lblShapeOutlineWidthPT.Size = new System.Drawing.Size(22, 13);
			this.m_lblShapeOutlineWidthPT.TabIndex = 18;
			this.m_lblShapeOutlineWidthPT.Text = "x";
			this.m_lblRotationDegree.AutoSize = true;
			this.m_lblRotationDegree.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblRotationDegree.Location = new System.Drawing.Point(94, 189);
			this.m_lblRotationDegree.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_lblRotationDegree.Name = "m_lblRotationDegree";
			this.m_lblRotationDegree.Size = new System.Drawing.Size(22, 13);
			this.m_lblRotationDegree.TabIndex = 24;
			this.m_lblRotationDegree.Text = "x";
			this.m_lblShapeFillColor.AutoSize = true;
			this.m_lblShapeFillColor.Location = new System.Drawing.Point(6, 33);
			this.m_lblShapeFillColor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.m_lblShapeFillColor.Name = "m_lblShapeFillColor";
			this.m_lblShapeFillColor.Size = new System.Drawing.Size(12, 13);
			this.m_lblShapeFillColor.TabIndex = 4;
			this.m_lblShapeFillColor.Text = "x";
			this.m_tlpOutlineAndFill.SetColumnSpan(this.m_cmbxShapeFillColor, 2);
			this.m_cmbxShapeFillColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cmbxShapeFillColor.FormattingEnabled = true;
			this.m_cmbxShapeFillColor.Location = new System.Drawing.Point(20, 33);
			this.m_cmbxShapeFillColor.Margin = new System.Windows.Forms.Padding(0);
			this.m_cmbxShapeFillColor.Name = "m_cmbxShapeFillColor";
			this.m_cmbxShapeFillColor.Size = new System.Drawing.Size(98, 21);
			this.m_cmbxShapeFillColor.TabIndex = 5;
			this.m_tlpOutlineAndFill.SetColumnSpan(this.m_cmbxShapeOutlineColor, 2);
			this.m_cmbxShapeOutlineColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cmbxShapeOutlineColor.FormattingEnabled = true;
			this.m_cmbxShapeOutlineColor.Location = new System.Drawing.Point(20, 111);
			this.m_cmbxShapeOutlineColor.Margin = new System.Windows.Forms.Padding(0);
			this.m_cmbxShapeOutlineColor.Name = "m_cmbxShapeOutlineColor";
			this.m_cmbxShapeOutlineColor.Size = new System.Drawing.Size(98, 21);
			this.m_cmbxShapeOutlineColor.TabIndex = 14;
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Location = new System.Drawing.Point(304, 325);
			this.m_btnCancel.Margin = new System.Windows.Forms.Padding(6, 0, 0, 0);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
			this.m_btnCancel.TabIndex = 35;
			this.m_btnCancel.Text = "x";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			this.m_btnOK.Location = new System.Drawing.Point(223, 325);
			this.m_btnOK.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(75, 23);
			this.m_btnOK.TabIndex = 34;
			this.m_btnOK.Text = "x";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(m_btnOK_Click);
			base.AcceptButton = this.m_btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.m_btnCancel;
			base.ClientSize = new System.Drawing.Size(397, 364);
			base.Controls.Add(this.tableLayoutPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FormatShapesDialog";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.ShowIcon = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "x";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.m_tpgSizeAndDistance.ResumeLayout(false);
			this.m_tpgSizeAndDistance.PerformLayout();
			this.m_tlpSizeAndDistance.ResumeLayout(false);
			this.m_tlpSizeAndDistance.PerformLayout();
			this.m_tlpOptionsHeader.ResumeLayout(false);
			this.m_tlpOptionsHeader.PerformLayout();
			this.m_tlpDistanceHeader.ResumeLayout(false);
			this.m_tlpDistanceHeader.PerformLayout();
			this.m_tlpScaleHeader.ResumeLayout(false);
			this.m_tlpScaleHeader.PerformLayout();
			this.tableLayoutPanel10.ResumeLayout(false);
			this.tableLayoutPanel10.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.m_nudSizeHeight).EndInit();
			((System.ComponentModel.ISupportInitialize)this.m_nudSizeWidth).EndInit();
			((System.ComponentModel.ISupportInitialize)this.m_nudLocationY).EndInit();
			((System.ComponentModel.ISupportInitialize)this.m_nudScaleHeight).EndInit();
			((System.ComponentModel.ISupportInitialize)this.m_nudScaleWidth).EndInit();
			((System.ComponentModel.ISupportInitialize)this.m_nudLocationX).EndInit();
			this.m_tpgOutlineAndFill.ResumeLayout(false);
			this.m_tlpOutlineAndFill.ResumeLayout(false);
			this.m_tlpOutlineAndFill.PerformLayout();
			this.m_tlpAppearanceHeader.ResumeLayout(false);
			this.m_tlpAppearanceHeader.PerformLayout();
			this.m_tlpShapeOutlineHeader.ResumeLayout(false);
			this.m_tlpShapeOutlineHeader.PerformLayout();
			this.m_tlpShapeFillHeader.ResumeLayout(false);
			this.m_tlpShapeFillHeader.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.m_nudRotation).EndInit();
			((System.ComponentModel.ISupportInitialize)this.m_nudShapeOutlineWidth).EndInit();
			((System.ComponentModel.ISupportInitialize)this.m_nudShapeFillTransparencyPercent).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
