using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using ns21;

namespace TXTextControl.ServerVisualisation
{
	[ToolboxItem(false)]
	public class StatusBarViewGenerator : Component
	{
		private enum Enum132
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
			const_10 = 0x400,
			const_11 = 0x800,
			const_12 = 0x1000,
			const_13 = 0x2000,
			const_14 = 0x4000,
			const_15 = 0x8000
		}

		public sealed class Colors : ColorBase
		{
			[Attribute3("PROP_SB_DISPLAYCOLORS_FORECOLOR")]
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

			[Attribute3("PROP_SB_DISPLAYCOLORS_BACKCOLOR")]
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

			[Attribute3("PROP_SB_DISPLAYCOLORS_GRADIENTBACKCOLOR")]
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
			[Attribute3("PROP_SB_DISPLAYCOLORS_FRAMECOLOR")]
			public Color FrameColor
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
			[Attribute3("PROP_SB_DISPLAYCOLORS_BACKCOLORTOP")]
			public Color BackColorTop
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

			[Attribute3("PROP_SB_DISPLAYCOLORS_BACKCOLORMIDDLE")]
			[Category("Appearance")]
			public Color BackColorMiddle
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

			[Attribute3("PROP_SB_DISPLAYCOLORS_BACKCOLORBOTTOM")]
			[Category("Appearance")]
			public Color BackColorBottom
			{
				get
				{
					return base.GetColor(6);
				}
				set
				{
					base.SetColor(value, 6);
				}
			}

			[Attribute3("PROP_SB_DISPLAYCOLORS_SEPARATORCOLORLIGHT")]
			[Category("Appearance")]
			public Color SeparatorColorLight
			{
				get
				{
					return base.GetColor(7);
				}
				set
				{
					base.SetColor(value, 7);
				}
			}

			[Attribute3("PROP_SB_DISPLAYCOLORS_SEPARATORCOLORDARK")]
			[Category("Appearance")]
			public Color SeparatorColorDark
			{
				get
				{
					return base.GetColor(8);
				}
				set
				{
					base.SetColor(value, 8);
				}
			}

			public Colors()
				: base(9, 1136, 1137)
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

			public bool ShouldSerializeFrameColor()
			{
				return base.m_aiColors[3] != Color.Empty;
			}

			public void ResetFrameColor()
			{
				ref Color reference = ref base.m_aiColors[3];
				reference = Color.Empty;
				base.method_0();
			}

			public bool ShouldSerializeBackColorTop()
			{
				return base.m_aiColors[4] != Color.Empty;
			}

			public void ResetBackColorTop()
			{
				ref Color reference = ref base.m_aiColors[4];
				reference = Color.Empty;
				base.method_0();
			}

			public bool ShouldSerializeBackColorMiddle()
			{
				return base.m_aiColors[5] != Color.Empty;
			}

			public void ResetBackColorMiddle()
			{
				ref Color reference = ref base.m_aiColors[5];
				reference = Color.Empty;
				base.method_0();
			}

			public bool ShouldSerializeBackColorBottom()
			{
				return base.m_aiColors[6] != Color.Empty;
			}

			public void ResetBackColorBottom()
			{
				ref Color reference = ref base.m_aiColors[6];
				reference = Color.Empty;
				base.method_0();
			}

			public bool ShouldSerializeSeparatorColorLight()
			{
				return base.m_aiColors[7] != Color.Empty;
			}

			public void ResetSeparatorColorLight()
			{
				ref Color reference = ref base.m_aiColors[7];
				reference = Color.Empty;
				base.method_0();
			}

			public bool ShouldSerializeSeparatorColorDark()
			{
				return base.m_aiColors[8] != Color.Empty;
			}

			public void ResetSeparatorColorDark()
			{
				ref Color reference = ref base.m_aiColors[8];
				reference = Color.Empty;
				base.method_0();
			}
		}

		private const string string_0 = "%u";

		private const string string_1 = "\t";

		private Container container_0;

		private Class409 class409_0;

		private TextControlCore.Delegate7 delegate7_0;

		private Enum132 enum132_0 = (Enum132)53505;

		public IntPtr intptr_0 = IntPtr.Zero;

		private StatusBarBorderStyle statusBarBorderStyle_0 = StatusBarBorderStyle.VerticalColorScheme;

		private string string_2 = string.Empty;

		private Colors colors_0 = new Colors();

		private Font font_0 = new Font("Arial", 10f);

		private string string_3 = string.Empty;

		private Point point_0 = new Point(0, 0);

		private string string_4 = "/";

		private string string_5 = string.Empty;

		private int int_0;

		private string string_6 = "/";

		private string string_7 = string.Empty;

		private bool bool_0 = true;

		private bool bool_1 = true;

		private bool bool_2 = true;

		private bool bool_3 = true;

		private bool bool_4 = true;

		private bool bool_5 = true;

		private bool bool_6 = true;

		private bool bool_7 = true;

		private bool bool_8 = true;

		private bool bool_9 = true;

		private UserInput userInput_0 = new UserInput(bIsDialog: false);

		private View view_0 = new View(typeof(StatusBarViewGenerator));

		[Category("Appearance")]
		[Attribute3("PROP_SB_BORDERSTYLE")]
		[DefaultValue(StatusBarBorderStyle.VerticalColorScheme)]
		public StatusBarBorderStyle BorderStyle
		{
			get
			{
				return this.statusBarBorderStyle_0;
			}
			set
			{
				if (this.statusBarBorderStyle_0 != value)
				{
					this.statusBarBorderStyle_0 = value;
					if (this.intptr_0 != IntPtr.Zero)
					{
						Class429.SendMessage_1(this.intptr_0, 1124, 0, (int)this.statusBarBorderStyle_0 | (int)this.enum132_0);
					}
				}
			}
		}

		[Attribute3("PROP_SB_COLUMNTEXT")]
		[DefaultValue("")]
		[Category("Appearance")]
		public string ColumnText
		{
			get
			{
				return this.string_2;
			}
			set
			{
				if (this.string_2 != value)
				{
					this.string_2 = value;
					if (this.intptr_0 != IntPtr.Zero)
					{
						this.method_1();
					}
				}
			}
		}

		[Category("Appearance")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Attribute3("PROP_SB_DISPLAYCOLORS")]
		[RefreshProperties(RefreshProperties.Repaint)]
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

		[Category("Appearance")]
		[Attribute3("PROP_FONT")]
		public Font Font
		{
			get
			{
				return this.font_0;
			}
			set
			{
				if (!this.font_0.Equals(value))
				{
					this.font_0 = (Font)value.Clone();
					if (this.intptr_0 != IntPtr.Zero)
					{
						IntPtr intPtr = this.Font.ToHfont();
						Class429.SendMessage_1(this.intptr_0, 48, (int)intPtr, 1);
						Class429.DeleteObject(intPtr);
					}
				}
			}
		}

		[Attribute3("PROP_SB_LINETEXT")]
		[Category("Appearance")]
		[DefaultValue("")]
		public string LineText
		{
			get
			{
				return this.string_3;
			}
			set
			{
				if (this.string_3 != value)
				{
					this.string_3 = value;
					if (this.intptr_0 != IntPtr.Zero)
					{
						this.method_1();
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

		[Attribute3("PROP_SB_PAGECOUNTERTEXT")]
		[Category("Appearance")]
		[DefaultValue("/")]
		public string PageCounterText
		{
			get
			{
				return this.string_4;
			}
			set
			{
				if (this.string_4 != value)
				{
					this.string_4 = value;
					if (this.intptr_0 != IntPtr.Zero)
					{
						this.method_1();
					}
				}
			}
		}

		[Category("Appearance")]
		[Attribute3("PROP_SB_PAGETEXT")]
		[DefaultValue("")]
		public string PageText
		{
			get
			{
				return this.string_5;
			}
			set
			{
				if (this.string_5 != value)
				{
					this.string_5 = value;
					if (this.intptr_0 != IntPtr.Zero)
					{
						this.method_1();
					}
				}
			}
		}

		[DefaultValue(0)]
		[Attribute3("PROP_SB_RESOLUTION")]
		[Category("Appearance")]
		public int Resolution
		{
			get
			{
				if (this.intptr_0 != IntPtr.Zero)
				{
					this.int_0 = Class429.SendMessage_1(this.intptr_0, 2138, 0, 0);
				}
				return this.int_0;
			}
			set
			{
				if (this.int_0 != value)
				{
					this.int_0 = value;
					if (this.intptr_0 != IntPtr.Zero)
					{
						Class429.SendMessage_1(this.intptr_0, 2139, value, 0);
					}
				}
			}
		}

		[Category("Appearance")]
		[Attribute3("PROP_SB_SECTIONCOUNTERTEXT")]
		[DefaultValue("/")]
		public string SectionCounterText
		{
			get
			{
				return this.string_6;
			}
			set
			{
				if (this.string_6 != value)
				{
					this.string_6 = value;
					if (this.intptr_0 != IntPtr.Zero)
					{
						this.method_1();
					}
				}
			}
		}

		[DefaultValue("")]
		[Attribute3("PROP_SB_SECTIONTEXT")]
		[Category("Appearance")]
		public string SectionText
		{
			get
			{
				return this.string_7;
			}
			set
			{
				if (this.string_7 != value)
				{
					this.string_7 = value;
					if (this.intptr_0 != IntPtr.Zero)
					{
						this.method_1();
					}
				}
			}
		}

		[Attribute3("PROP_SB_SHOWCOLUMN")]
		[Category("Appearance")]
		[DefaultValue(true)]
		public bool ShowColumn
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				if (this.bool_0 != value)
				{
					this.bool_0 = value;
					if (this.intptr_0 != IntPtr.Zero)
					{
						this.method_1();
					}
				}
			}
		}

		[Category("Appearance")]
		[Attribute3("PROP_SB_SHOWKEYSTATES")]
		[DefaultValue(true)]
		public bool ShowKeyStates
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				if (this.bool_1 != value)
				{
					this.bool_1 = value;
					this.enum132_0 &= (Enum132)(-129);
					if (!this.bool_1)
					{
						this.enum132_0 |= Enum132.const_7;
					}
					if (this.intptr_0 != IntPtr.Zero)
					{
						Class429.SendMessage_1(this.intptr_0, 1124, 1, (int)this.statusBarBorderStyle_0 | (int)this.enum132_0);
					}
				}
			}
		}

		[Category("Appearance")]
		[DefaultValue(true)]
		[Attribute3("PROP_SB_SHOWLANGUAGE")]
		public bool ShowLanguage
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				if (this.bool_2 != value)
				{
					this.bool_2 = value;
					this.enum132_0 &= (Enum132)(-16385);
					if (this.bool_2)
					{
						this.enum132_0 |= Enum132.const_14;
					}
					if (this.intptr_0 != IntPtr.Zero)
					{
						Class429.SendMessage_1(this.intptr_0, 1124, 1, (int)this.statusBarBorderStyle_0 | (int)this.enum132_0);
					}
				}
			}
		}

		[DefaultValue(true)]
		[Attribute3("PROP_SB_SHOWLINE")]
		[Category("Appearance")]
		public bool ShowLine
		{
			get
			{
				return this.bool_3;
			}
			set
			{
				if (this.bool_3 != value)
				{
					this.bool_3 = value;
					if (this.intptr_0 != IntPtr.Zero)
					{
						this.method_1();
					}
				}
			}
		}

		[Category("Appearance")]
		[Attribute3("PROP_SB_SHOWPAGE")]
		[DefaultValue(true)]
		public bool ShowPage
		{
			get
			{
				return this.bool_4;
			}
			set
			{
				if (this.bool_4 != value)
				{
					this.bool_4 = value;
					if (this.intptr_0 != IntPtr.Zero)
					{
						this.method_1();
					}
				}
			}
		}

		[Category("Appearance")]
		[DefaultValue(true)]
		[Attribute3("PROP_SB_SHOWPAGECOUNTER")]
		public bool ShowPageCounter
		{
			get
			{
				return this.bool_5;
			}
			set
			{
				if (this.bool_5 != value)
				{
					this.bool_5 = value;
					if (this.intptr_0 != IntPtr.Zero)
					{
						this.method_1();
					}
				}
			}
		}

		[Category("Appearance")]
		[Attribute3("PROP_SB_SHOWSECTION")]
		[DefaultValue(true)]
		public bool ShowSection
		{
			get
			{
				return this.bool_6;
			}
			set
			{
				if (this.bool_6 != value)
				{
					this.bool_6 = value;
					if (this.intptr_0 != IntPtr.Zero)
					{
						this.method_1();
					}
				}
			}
		}

		[DefaultValue(true)]
		[Attribute3("PROP_SB_SHOWSECTIONCOUNTER")]
		[Category("Appearance")]
		public bool ShowSectionCounter
		{
			get
			{
				return this.bool_7;
			}
			set
			{
				if (this.bool_7 != value)
				{
					this.bool_7 = value;
					if (this.intptr_0 != IntPtr.Zero)
					{
						this.method_1();
					}
				}
			}
		}

		[DefaultValue(true)]
		[Category("Appearance")]
		[Attribute3("PROP_SB_SHOWZOOM")]
		public bool ShowZoom
		{
			get
			{
				return this.bool_8;
			}
			set
			{
				if (this.bool_8 != value)
				{
					this.bool_8 = value;
					this.enum132_0 &= (Enum132)(-65);
					if (!this.bool_8)
					{
						this.enum132_0 |= Enum132.const_6;
					}
					if (this.intptr_0 != IntPtr.Zero)
					{
						Class429.SendMessage_1(this.intptr_0, 1124, 1, (int)this.statusBarBorderStyle_0 | (int)this.enum132_0);
					}
				}
			}
		}

		[Attribute3("PROP_SB_SHOWZOOMTRACKBAR")]
		[Category("Appearance")]
		[DefaultValue(true)]
		public bool ShowZoomTrackBar
		{
			get
			{
				return this.bool_9;
			}
			set
			{
				if (this.bool_9 != value)
				{
					this.bool_9 = value;
					this.enum132_0 &= (Enum132)(-4097);
					if (this.bool_9)
					{
						this.enum132_0 |= Enum132.const_12;
					}
					if (this.intptr_0 != IntPtr.Zero)
					{
						Class429.SendMessage_1(this.intptr_0, 1124, 1, (int)this.statusBarBorderStyle_0 | (int)this.enum132_0);
					}
				}
			}
		}

		[Browsable(false)]
		public UserInput UserInput => this.userInput_0;

		[Browsable(false)]
		public View View => this.view_0;

		public StatusBarViewGenerator()
		{
			this.method_2();
		}

		public bool Create()
		{
			this.class409_0 = new Class409();
			this.intptr_0 = Class429.CreateWindowEx(0u, "TX_STATUSBAR29_DOTNET", "", 2147483648u, 0, 0, 1000, 1000, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
			if (this.intptr_0 == IntPtr.Zero)
			{
				return false;
			}
			IntPtr intPtr = this.font_0.ToHfont();
			Class429.SendMessage_1(this.intptr_0, 48, (int)intPtr, 0);
			Class429.DeleteObject(intPtr);
			Class429.SendMessage_1(this.intptr_0, 1124, 0, (int)this.statusBarBorderStyle_0 | (int)this.enum132_0);
			this.method_1();
			this.colors_0.method_5(this.intptr_0);
			this.colors_0.method_1();
			Class429.SendMessage_1(int_3: Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName switch
			{
				"de" => 49, 
				"en" => 1, 
				_ => 20000, 
			}, intptr_0: this.intptr_0, int_2: 2035, int_4: 0);
			this.userInput_0.method_0(this.intptr_0);
			this.view_0.method_0(this.intptr_0);
			this.delegate7_0 = method_0;
			Class429.SendMessage_40(this.intptr_0, 1138, 0, this.delegate7_0);
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

		public bool ShouldSerializeFont()
		{
			return !this.font_0.Equals(new Font("Arial", 10f));
		}

		public void ResetFont()
		{
			this.Font = new Font("Arial", 10f);
		}

		private bool method_0(IntPtr intptr_1)
		{
			Class429.Struct84 @struct = (Class429.Struct84)Marshal.PtrToStructure(intptr_1, typeof(Class429.Struct84));
			this.view_0.method_1((Enum84)@struct.uint_0, 0u);
			return true;
		}

		private void method_1()
		{
			string text = this.string_5;
			if (this.bool_4)
			{
				text += "%u";
			}
			text = text + "\t" + this.string_3;
			if (this.bool_3)
			{
				text += "%u";
			}
			text = text + "\t" + this.string_2;
			if (this.bool_0)
			{
				text += "%u";
			}
			text = text + "\t" + this.string_4;
			if (this.bool_5)
			{
				text += "%u";
			}
			text = text + "\t" + this.string_7;
			if (this.bool_6)
			{
				text += "%u";
			}
			text = text + "\t" + this.string_6;
			if (this.bool_7)
			{
				text += "%u";
			}
			this.enum132_0 &= (Enum132)(-2105);
			if (!this.bool_0)
			{
				this.enum132_0 |= Enum132.const_5;
			}
			if (!this.bool_3)
			{
				this.enum132_0 |= Enum132.const_4;
			}
			if (!this.bool_4 && !this.bool_5)
			{
				this.enum132_0 |= Enum132.const_3;
			}
			if (!this.bool_6 && !this.bool_7)
			{
				this.enum132_0 |= Enum132.const_11;
			}
			Class429.SendMessage_1(this.intptr_0, 1124, 0, (int)this.statusBarBorderStyle_0 | (int)this.enum132_0);
			IntPtr intPtr = Marshal.StringToBSTR(text);
			Class429.SendMessage_6(this.intptr_0, 1135, 2, intPtr);
			Marshal.FreeBSTR(intPtr);
		}

		private void method_2()
		{
			this.container_0 = new Container();
		}
	}
}
