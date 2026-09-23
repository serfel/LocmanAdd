using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
using ns21;

namespace TXTextControl
{
	/// <summary>The RulerBar class represents a Windows Forms tool bar which can be used to show or to set indents, margins and tabs of a Windows Forms TextControl.</summary>
	[ToolboxBitmap(typeof(RulerBar))]
	public class RulerBar : Control
	{
		private enum Enum142
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

		/// <summary>The RulerBar.Colors class gets, sets or resets the display colors of a Windows Forms RulerBar control.</summary>
		public sealed class Colors : ColorBase
		{
			/// <summary>Gets or sets the color used for the numbers of the ruler.</summary>
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

			/// <summary>Gets or sets the background color at the left or top edge of the ruler bar.</summary>
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

			/// <summary>Gets or sets the background color at the right or bottom edge of the ruler bar.</summary>
			[Category("Appearance")]
			[Attribute3("PROP_RL_DISPLAYCOLORS_GRADIENTBACKCOLOR")]
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

			/// <summary>Gets or sets the color of light separators.</summary>
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

			/// <summary>Gets or sets the color of dark separators.</summary>
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

			/// <summary>Gets or sets the color of the ruler.</summary>
			[Attribute3("PROP_RL_DISPLAYCOLORS_RULERCOLOR")]
			[Category("Appearance")]
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

			/// <summary>Initializes a new instance of the RulerBar.Colors class. After creating the object with this constuctor, individual colors can be set. If the Colors object is assigned to the RulerBar.DisplayColors property, non-set colors are reset to their system dependent default values.</summary>
			public Colors()
				: base(6, 1229, 1230)
			{
			}

			public bool ShouldSerializeForeColor()
			{
				return base.m_aiColors[0] != Color.Empty;
			}

			/// <summary>Resets the ruler bar's ForeColor to its system dependent default value.</summary>
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

			/// <summary>Resets the ruler bar's BackColor to its system dependent default value.</summary>
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

			/// <summary>Resets the ruler bar's GradientBackColor to its system dependent default value.</summary>
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

			/// <summary>Resets the ruler bar's SeparatorColorLight to its system dependent default value.</summary>
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

			/// <summary>Resets the ruler bar's SeparatorColorDark to its system dependent default value.</summary>
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

			/// <summary>Resets the ruler bar's RulerColor to its system dependent default value.</summary>
			public void ResetRulerColor()
			{
				ref Color reference = ref base.m_aiColors[5];
				reference = Color.Empty;
				base.method_0();
			}
		}

		private Container container_0;

		private Class409 class409_0;

		private string string_0;

		private Enum142 enum142_0 = Enum142.const_8;

		private RulerBarAlignment rulerBarAlignment_0 = RulerBarAlignment.Top;

		private RulerBarBorderStyle rulerBarBorderStyle_0 = RulerBarBorderStyle.ColorScheme;

		private Colors colors_0 = new Colors();

		private RulerBarFormulaMode rulerBarFormulaMode_0;

		private int int_0;

		private RulerBarScaleUnit rulerBarScaleUnit_0;

		private ButtonBar buttonBar_0;

		protected override Size DefaultSize => new Size(200, 200);

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.ClassName = this.string_0;
				if (createParams.Width == 0)
				{
					createParams.Width = 200;
				}
				if (createParams.Height == 0)
				{
					createParams.Height = 200;
				}
				return createParams;
			}
		}

		/// <summary>Gets or sets a value specifying the alignment of the ruler bar in the document.</summary>
		[Category("Appearance")]
		[DefaultValue(RulerBarAlignment.Top)]
		[Attribute3("PROP_RL_ALIGNMENT")]
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
					if (base.IsHandleCreated)
					{
						Class429.SendMessage_1(base.Handle, 1226, 0, (int)this.rulerBarBorderStyle_0 | (int)this.enum142_0 | (int)this.rulerBarAlignment_0 | this.int_0 | (int)this.rulerBarFormulaMode_0);
					}
				}
			}
		}

		/// <summary>Gets or sets the border style of the ruler bar.</summary>
		[DefaultValue(RulerBarBorderStyle.ColorScheme)]
		[Category("Appearance")]
		[Attribute3("PROP_RL_BORDERSTYLE")]
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
					if (base.IsHandleCreated)
					{
						Class429.SendMessage_1(base.Handle, 1226, 0, (int)this.rulerBarBorderStyle_0 | (int)this.enum142_0 | (int)this.rulerBarAlignment_0 | this.int_0 | (int)this.rulerBarFormulaMode_0);
					}
				}
			}
		}

		/// <summary>Gets or sets the colors of the ruler bar.</summary>
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

		public override DockStyle Dock
		{
			get
			{
				return base.Dock;
			}
			set
			{
				switch (value)
				{
				case DockStyle.Top:
				case DockStyle.Bottom:
					this.Alignment = RulerBarAlignment.Top;
					break;
				case DockStyle.Left:
				case DockStyle.Right:
					this.Alignment = RulerBarAlignment.Left;
					break;
				}
				base.Dock = value;
			}
		}

		/// <summary>Enables or disables the setting of page margins.</summary>
		[Category("Appearance")]
		[DefaultValue(true)]
		[Attribute3("PROP_RL_ENABLEPAGEMARGINS")]
		public bool EnablePageMargins
		{
			get
			{
				if ((this.enum142_0 & Enum142.const_5) == 0)
				{
					return false;
				}
				return true;
			}
			set
			{
				if (this.EnablePageMargins != value)
				{
					this.enum142_0 ^= Enum142.const_5;
					if (base.IsHandleCreated)
					{
						Class429.SendMessage_1(base.Handle, 1226, 0, (int)this.rulerBarBorderStyle_0 | (int)this.enum142_0 | (int)this.rulerBarAlignment_0 | this.int_0 | (int)this.rulerBarFormulaMode_0);
					}
				}
			}
		}

		/// <summary>Gets or sets a value specifying whether the ruler bar shows cell references when the current input position is in a table cell.</summary>
		[DefaultValue(RulerBarFormulaMode.None)]
		[Category("Appearance")]
		[Attribute3("PROP_RL_FORMULAMODE")]
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
					if (base.IsHandleCreated)
					{
						Class429.SendMessage_1(base.Handle, 1226, 0, (int)this.rulerBarBorderStyle_0 | (int)this.enum142_0 | (int)this.rulerBarAlignment_0 | this.int_0 | (int)this.rulerBarFormulaMode_0);
					}
				}
			}
		}

		/// <summary>Gets or sets a value determining the ruler bar's read only mode.</summary>
		[DefaultValue(false)]
		[Attribute3("PROP_RL_READONLY")]
		[Category("Behavior")]
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
					if (base.IsHandleCreated)
					{
						Class429.SendMessage_1(base.Handle, 1226, 0, (int)this.rulerBarBorderStyle_0 | (int)this.enum142_0 | (int)this.rulerBarAlignment_0 | this.int_0 | (int)this.rulerBarFormulaMode_0);
					}
				}
			}
		}

		/// <summary>Gets or sets the unit of the ruler bar's scale.</summary>
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
					if (base.IsHandleCreated)
					{
						this.method_0();
					}
				}
			}
		}

		public ButtonBar ButtonBar_0
		{
			set
			{
				this.buttonBar_0 = value;
				if (base.IsHandleCreated)
				{
					Class429.SendMessage_1(base.Handle, 1225, (this.buttonBar_0 != null) ? ((int)this.buttonBar_0.Handle) : 0, 0);
				}
			}
		}

		public RulerBar()
		{
			this.class409_0 = new Class409();
			this.string_0 = "TX_RULERBAR29_DOTNET";
			base.SetStyle(ControlStyles.UserPaint, value: false);
			this.method_1();
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			base.OnHandleCreated(eventArgs_0);
			if (this.buttonBar_0 != null)
			{
				Class429.SendMessage_1(base.Handle, 1225, (int)this.buttonBar_0.Handle, 0);
			}
			Class429.SendMessage_1(base.Handle, 1226, 0, (int)this.rulerBarBorderStyle_0 | (int)this.enum142_0 | (int)this.rulerBarAlignment_0 | this.int_0 | (int)this.rulerBarFormulaMode_0);
			if (this.ForeColor != SystemColors.ControlText)
			{
				Class429.SendMessage_1(base.Handle, 2055, 0, Class429.smethod_0(this.ForeColor));
			}
			if (this.BackColor != SystemColors.Control)
			{
				Class429.SendMessage_1(base.Handle, 2057, 0, Class429.smethod_0(this.BackColor));
			}
			this.method_0();
			this.colors_0.method_5(base.Handle);
			this.colors_0.method_1();
			if (base.DesignMode)
			{
				base.SetStyle(ControlStyles.ResizeRedraw, value: true);
			}
		}

		protected override void OnBackColorChanged(EventArgs eventArgs_0)
		{
			base.OnBackColorChanged(eventArgs_0);
			if (base.IsHandleCreated)
			{
				Class429.SendMessage_1(base.Handle, 2057, (this.BackColor == SystemColors.Control) ? 1 : 0, Class429.smethod_0(this.BackColor));
			}
		}

		protected override void OnForeColorChanged(EventArgs eventArgs_0)
		{
			base.OnForeColorChanged(eventArgs_0);
			if (base.IsHandleCreated)
			{
				Class429.SendMessage_1(base.Handle, 2055, (this.ForeColor == SystemColors.ControlText) ? 1 : 0, Class429.smethod_0(this.ForeColor));
			}
		}

		protected override void OnPaint(PaintEventArgs pea)
		{
			Graphics graphics = pea.Graphics;
			Rectangle rectangle = Rectangle.Ceiling(graphics.ClipBounds);
			Class429.Struct83 struct83_ = default(Class429.Struct83);
			struct83_.int_0 = rectangle.Left;
			struct83_.int_1 = rectangle.Top;
			struct83_.int_2 = rectangle.Right;
			struct83_.int_3 = rectangle.Bottom;
			IntPtr intPtr = default(IntPtr);
			intPtr = graphics.GetHdc();
			Class429.SendMessage_3(base.Handle, 2033, (int)intPtr, ref struct83_);
			graphics.ReleaseHdc(intPtr);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.container_0 != null)
			{
				this.container_0.Dispose();
			}
			base.Dispose(disposing);
			if (this.class409_0 != null)
			{
				this.class409_0.Dispose();
			}
		}

		protected override void WndProc(ref Message message)
		{
			switch (message.Msg)
			{
			default:
				base.WndProc(ref message);
				break;
			case 738:
			case 739:
				this.DefWndProc(ref message);
				break;
			}
		}

		public bool ShouldSerializeDisplayColors()
		{
			return !this.colors_0.method_4();
		}

		/// <summary>Resets all display colors of a ruler bar to their system dependent default values.</summary>
		public void ResetDisplayColors()
		{
			this.colors_0.method_3();
		}

		private void method_0()
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
					Class429.SendMessage_1(base.Handle, 1224, 100, Class429.smethod_3(1, 10));
				}
				else
				{
					Class429.SendMessage_1(base.Handle, 1224, 254, Class429.smethod_3(1, 8));
				}
				break;
			case RulerBarScaleUnit.Millimeter:
				Class429.SendMessage_1(base.Handle, 1224, 100, Class429.smethod_3(1, 10));
				break;
			case RulerBarScaleUnit.Centimeter:
				Class429.SendMessage_1(base.Handle, 1224, 100, Class429.smethod_3(1, 2));
				break;
			case RulerBarScaleUnit.Inch:
				Class429.SendMessage_1(base.Handle, 1224, 254, Class429.smethod_3(1, 8));
				break;
			}
		}

		private void method_1()
		{
			this.container_0 = new Container();
		}
	}
}
