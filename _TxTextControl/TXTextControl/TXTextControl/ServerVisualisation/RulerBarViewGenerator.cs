using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.InteropServices;
using System.Threading;
using ns21;

namespace TXTextControl.ServerVisualisation
{
	[ToolboxItem(false)]
	public class RulerBarViewGenerator : Component
	{
		private enum Enum131
		{
			const_0 = 1,
			const_1 = 14,
			const_2 = 0x10,
			const_3 = 0x40,
			const_4 = 0x200,
			const_5 = 0x800,
			const_6 = 0x1000,
			const_7 = 0x8000,
			const_8 = 39519
		}

		public sealed class Colors : ColorBase
		{
			[Attribute3("PROP_RL_DISPLAYCOLORS_FORECOLOR")]
			[Category("Appearance")]
			public Color ForeColor
			{
				get
				{
					return base.GetColor(0);
				}
				set
				{
					base.SetColor(value, 0);
				}
			}

			[Attribute3("PROP_RL_DISPLAYCOLORS_BACKCOLOR")]
			[Category("Appearance")]
			public Color BackColor
			{
				get
				{
					return base.GetColor(1);
				}
				set
				{
					base.SetColor(value, 1);
				}
			}

			[Attribute3("PROP_RL_DISPLAYCOLORS_GRADIENTBACKCOLOR")]
			[Category("Appearance")]
			public Color GradientBackColor
			{
				get
				{
					return base.GetColor(2);
				}
				set
				{
					base.SetColor(value, 2);
				}
			}

			[Category("Appearance")]
			[Attribute3("PROP_RL_DISPLAYCOLORS_SEPARATORCOLORLIGHT")]
			public Color SeparatorColorLight
			{
				get
				{
					return base.GetColor(3);
				}
				set
				{
					base.SetColor(value, 3);
				}
			}

			[Category("Appearance")]
			[Attribute3("PROP_RL_DISPLAYCOLORS_SEPARATORCOLORDARK")]
			public Color SeparatorColorDark
			{
				get
				{
					return base.GetColor(4);
				}
				set
				{
					base.SetColor(value, 4);
				}
			}

			[Category("Appearance")]
			[Attribute3("PROP_RL_DISPLAYCOLORS_RULERCOLOR")]
			public Color RulerColor
			{
				get
				{
					return base.GetColor(5);
				}
				set
				{
					base.SetColor(value, 5);
				}
			}

			public Colors()
				: base(6, 1229, 1230)
			{
			}

			public bool ShouldSerializeForeColor()
			{
				return base.m_aiColors[0] != Color.Empty;
			}

			public void ResetForeColor()
			{
				ref Color reference = ref base.m_aiColors[0];
				reference = Color.Empty;
				base.method_0();
			}

			public bool ShouldSerializeBackColor()
			{
				return base.m_aiColors[1] != Color.Empty;
			}

			public void ResetBackColor()
			{
				ref Color reference = ref base.m_aiColors[1];
				reference = Color.Empty;
				base.method_0();
			}

			public bool ShouldSerializeGradientBackColor()
			{
				return base.m_aiColors[2] != Color.Empty;
			}

			public void ResetGradientBackColor()
			{
				ref Color reference = ref base.m_aiColors[2];
				reference = Color.Empty;
				base.method_0();
			}

			public bool ShouldSerializeSeparatorColorLight()
			{
				return base.m_aiColors[3] != Color.Empty;
			}

			public void ResetSeparatorColorLight()
			{
				ref Color reference = ref base.m_aiColors[3];
				reference = Color.Empty;
				base.method_0();
			}

			public bool ShouldSerializeSeparatorColorDark()
			{
				return base.m_aiColors[4] != Color.Empty;
			}

			public void ResetSeparatorColorDark()
			{
				ref Color reference = ref base.m_aiColors[4];
				reference = Color.Empty;
				base.method_0();
			}

			public bool ShouldSerializeRulerColor()
			{
				return base.m_aiColors[5] != Color.Empty;
			}

			public void ResetRulerColor()
			{
				ref Color reference = ref base.m_aiColors[5];
				reference = Color.Empty;
				base.method_0();
			}
		}

		private Container container_0;

		private Class409 class409_0;

		private TextControlCore.Delegate7 delegate7_0;

		private Enum131 enum131_0 = (Enum131)301663;

		public IntPtr intptr_0 = IntPtr.Zero;

		private RulerBarAlignment rulerBarAlignment_0 = RulerBarAlignment.Top;

		private RulerBarBorderStyle rulerBarBorderStyle_0 = RulerBarBorderStyle.ColorScheme;

		private Colors colors_0 = new Colors();

		private RulerBarFormulaMode rulerBarFormulaMode_0;

		private Point point_0 = new Point(0, 0);

		private int int_0;

		private int int_1;

		private RulerBarScaleUnit rulerBarScaleUnit_0;

		private UserInput userInput_0 = new UserInput(bIsDialog: false);

		private View view_0 = new View(typeof(RulerBarViewGenerator));

		[Attribute3("PROP_RL_ALIGNMENT")]
		[DefaultValue(RulerBarAlignment.Top)]
		[Category("Appearance")]
		public RulerBarAlignment Alignment
		{
			get
			{
				return this.rulerBarAlignment_0;
			}
			set
			{
				if (this.rulerBarAlignment_0 != value)
				{
					if (value == RulerBarAlignment.Left && (this.rulerBarBorderStyle_0 == RulerBarBorderStyle.Simple3D || this.rulerBarBorderStyle_0 == RulerBarBorderStyle.Fixed3D))
					{
						ResourceManager resourceManager = new ResourceManager(typeof(TextControlCore));
						throw new NotSupportedException(resourceManager.GetString("ERR_RULERBAR_1"));
					}
					this.rulerBarAlignment_0 = value;
					if (this.intptr_0 != IntPtr.Zero)
					{
						Class429.SendMessage_1(this.intptr_0, 1226, 0, (int)this.rulerBarBorderStyle_0 | (int)this.enum131_0 | (int)this.rulerBarAlignment_0 | this.int_0 | (int)this.rulerBarFormulaMode_0);
					}
				}
			}
		}

		[Attribute3("PROP_RL_BORDERSTYLE")]
		[Category("Appearance")]
		[DefaultValue(RulerBarBorderStyle.ColorScheme)]
		public RulerBarBorderStyle BorderStyle
		{
			get
			{
				return this.rulerBarBorderStyle_0;
			}
			set
			{
				if (this.rulerBarBorderStyle_0 != value)
				{
					if (this.rulerBarAlignment_0 == RulerBarAlignment.Left && (value == RulerBarBorderStyle.Simple3D || value == RulerBarBorderStyle.Fixed3D))
					{
						ResourceManager resourceManager = new ResourceManager(typeof(TextControlCore));
						throw new NotSupportedException(resourceManager.GetString("ERR_RULERBAR_1"));
					}
					this.rulerBarBorderStyle_0 = value;
					if (this.intptr_0 != IntPtr.Zero)
					{
						Class429.SendMessage_1(this.intptr_0, 1226, 0, (int)this.rulerBarBorderStyle_0 | (int)this.enum131_0 | (int)this.rulerBarAlignment_0 | this.int_0 | (int)this.rulerBarFormulaMode_0);
					}
				}
			}
		}

		[RefreshProperties(RefreshProperties.Repaint)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Appearance")]
		[Attribute3("PROP_RL_DISPLAYCOLORS")]
		[TypeConverter(typeof(Class417))]
		public Colors DisplayColors
		{
			get
			{
				return this.colors_0;
			}
			set
			{
				value.method_2(this.colors_0);
				this.colors_0.method_0();
			}
		}

		[Attribute3("PROP_RL_ENABLEPAGEMARGINS")]
		[DefaultValue(true)]
		[Category("Appearance")]
		public bool EnablePageMargins
		{
			get
			{
				if ((this.enum131_0 & Enum131.const_5) == 0)
				{
					return false;
				}
				return true;
			}
			set
			{
				if (this.EnablePageMargins != value)
				{
					this.enum131_0 ^= Enum131.const_5;
					if (this.intptr_0 != IntPtr.Zero)
					{
						Class429.SendMessage_1(this.intptr_0, 1226, 0, (int)this.rulerBarBorderStyle_0 | (int)this.enum131_0 | (int)this.rulerBarAlignment_0 | this.int_0 | (int)this.rulerBarFormulaMode_0);
					}
				}
			}
		}

		[DefaultValue(RulerBarFormulaMode.None)]
		[Attribute3("PROP_RL_FORMULAMODE")]
		[Category("Appearance")]
		public RulerBarFormulaMode FormulaMode
		{
			get
			{
				return this.rulerBarFormulaMode_0;
			}
			set
			{
				if (this.rulerBarFormulaMode_0 != value)
				{
					this.rulerBarFormulaMode_0 = value;
					if (this.intptr_0 != IntPtr.Zero)
					{
						Class429.SendMessage_1(this.intptr_0, 1226, 0, (int)this.rulerBarBorderStyle_0 | (int)this.enum131_0 | (int)this.rulerBarAlignment_0 | this.int_0 | (int)this.rulerBarFormulaMode_0);
					}
				}
			}
		}

		[Browsable(false)]
		public Point Location
		{
			get
			{
				return this.point_0;
			}
			set
			{
				this.point_0 = value;
				if (this.intptr_0 != IntPtr.Zero)
				{
					Class429.SetWindowPos(this.intptr_0, IntPtr.Zero, this.point_0.X, this.point_0.Y, 0, 0, 29u);
				}
			}
		}

		[Attribute3("PROP_RL_READONLY")]
		[Category("Behavior")]
		[DefaultValue(false)]
		public bool ReadOnly
		{
			get
			{
				if (this.int_0 != 0)
				{
					return true;
				}
				return false;
			}
			set
			{
				int num = (value ? 524288 : 0);
				if (num != this.int_0)
				{
					this.int_0 = num;
					if (this.intptr_0 != IntPtr.Zero)
					{
						Class429.SendMessage_1(this.intptr_0, 1226, 0, (int)this.rulerBarBorderStyle_0 | (int)this.enum131_0 | (int)this.rulerBarAlignment_0 | this.int_0 | (int)this.rulerBarFormulaMode_0);
					}
				}
			}
		}

		[Category("Appearance")]
		[Attribute3("PROP_RL_RESOLUTION")]
		[DefaultValue(0)]
		public int Resolution
		{
			get
			{
				if (this.intptr_0 != IntPtr.Zero)
				{
					this.int_1 = Class429.SendMessage_1(this.intptr_0, 2138, 0, 0);
				}
				return this.int_1;
			}
			set
			{
				if (this.int_1 != value)
				{
					this.int_1 = value;
					if (this.intptr_0 != IntPtr.Zero)
					{
						Class429.SendMessage_1(this.intptr_0, 2139, value, 0);
					}
				}
			}
		}

		[DefaultValue(RulerBarScaleUnit.Auto)]
		[Category("Appearance")]
		[Attribute3("PROP_RL_SCALEUNIT")]
		public RulerBarScaleUnit ScaleUnit
		{
			get
			{
				return this.rulerBarScaleUnit_0;
			}
			set
			{
				if (this.rulerBarScaleUnit_0 != value)
				{
					this.rulerBarScaleUnit_0 = value;
					if (this.intptr_0 != IntPtr.Zero)
					{
						this.method_1();
					}
				}
			}
		}

		[Browsable(false)]
		public UserInput UserInput => this.userInput_0;

		[Browsable(false)]
		public View View => this.view_0;

		public RulerBarViewGenerator()
		{
			this.method_2();
		}

		public bool Create()
		{
			this.class409_0 = new Class409();
			this.intptr_0 = Class429.CreateWindowEx(0u, "TX_RULERBAR29_DOTNET", "", 2147483648u, 0, 0, 1000, 1000, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
			if (this.intptr_0 == IntPtr.Zero)
			{
				return false;
			}
			Class429.SendMessage_1(this.intptr_0, 1226, 0, (int)this.rulerBarBorderStyle_0 | (int)this.enum131_0 | (int)this.rulerBarAlignment_0 | this.int_0 | (int)this.rulerBarFormulaMode_0);
			this.method_1();
			this.colors_0.method_5(this.intptr_0);
			this.colors_0.method_1();
			this.userInput_0.method_0(this.intptr_0);
			this.view_0.method_0(this.intptr_0);
			this.delegate7_0 = method_0;
			Class429.SendMessage_40(this.intptr_0, 1231, 0, this.delegate7_0);
			return true;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.container_0 != null)
			{
				this.container_0.Dispose();
			}
			if (this.intptr_0 != IntPtr.Zero)
			{
				Class429.DestroyWindow(this.intptr_0);
				this.intptr_0 = IntPtr.Zero;
			}
			base.Dispose(disposing);
		}

		public bool ShouldSerializeDisplayColors()
		{
			return !this.colors_0.method_4();
		}

		public void ResetDisplayColors()
		{
			this.colors_0.method_3();
		}

		public bool ShouldSerializeLocation()
		{
			return !this.point_0.IsEmpty;
		}

		public void ResetMaxSize()
		{
			this.point_0 = Point.Empty;
		}

		private bool method_0(IntPtr intptr_1)
		{
			Class429.Struct84 @struct = (Class429.Struct84)Marshal.PtrToStructure(intptr_1, typeof(Class429.Struct84));
			this.view_0.method_1((Enum84)@struct.uint_0, 0u);
			return true;
		}

		private void method_1()
		{
			bool flag = true;
			switch (this.rulerBarScaleUnit_0)
			{
			case RulerBarScaleUnit.Auto:
				try
				{
					RegionInfo regionInfo = new RegionInfo(Thread.CurrentThread.CurrentCulture.LCID);
					flag = regionInfo.IsMetric;
				}
				catch
				{
				}
				if (flag)
				{
					Class429.SendMessage_1(this.intptr_0, 1224, 100, Class429.smethod_3(1, 10));
				}
				else
				{
					Class429.SendMessage_1(this.intptr_0, 1224, 254, Class429.smethod_3(1, 8));
				}
				break;
			case RulerBarScaleUnit.Millimeter:
				Class429.SendMessage_1(this.intptr_0, 1224, 100, Class429.smethod_3(1, 10));
				break;
			case RulerBarScaleUnit.Centimeter:
				Class429.SendMessage_1(this.intptr_0, 1224, 100, Class429.smethod_3(1, 2));
				break;
			case RulerBarScaleUnit.Inch:
				Class429.SendMessage_1(this.intptr_0, 1224, 254, Class429.smethod_3(1, 8));
				break;
			}
		}

		private void method_2()
		{
			this.container_0 = new Container();
		}
	}
}
