using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using ns21;

namespace TXTextControl
{
	/// <summary>The StatusBar class represents a Windows Forms tool bar which can be used to show the position of the curent text input position and other status information of a Windows Forms TextControl.</summary>
	[ToolboxBitmap(typeof(StatusBar))]
	public class StatusBar : Control
	{
		private enum Enum144
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
			const_14 = 0x4000
		}

		/// <summary>The StatusBar.Colors class gets, sets or resets the display colors of a Windows Forms StatusBar control.</summary>
		public sealed class Colors : ColorBase
		{
			/// <summary>Gets or sets the color used for text and numbers.</summary>
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

			/// <summary>Gets or sets the background color at the left edge of the status bar.</summary>
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

			/// <summary>Gets or sets the background color at the right edge of the status bar.</summary>
			[Category("Appearance")]
			[Attribute3("PROP_SB_DISPLAYCOLORS_GRADIENTBACKCOLOR")]
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

			/// <summary>Gets or sets the color of the status bar's frames.</summary>
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

			/// <summary>Gets or sets the background color at the top of the status bar.</summary>
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

			/// <summary>Gets or sets the background color in the middle of the status bar.</summary>
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

			/// <summary>Gets or sets the background color at the bottom of the status bar.</summary>
			[Category("Appearance")]
			[Attribute3("PROP_SB_DISPLAYCOLORS_BACKCOLORBOTTOM")]
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

			/// <summary>Gets or sets the color of the light part of a separator.</summary>
			[Category("Appearance")]
			[Attribute3("PROP_SB_DISPLAYCOLORS_SEPARATORCOLORLIGHT")]
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

			/// <summary>Gets or sets the color of the dark part of a separator.</summary>
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

			/// <summary>Initializes a new instance of the StatusBar.Colors class. After creating the object with this constuctor, individual colors can be set. If the Colors object is assigned to the StatusBar.DisplayColors property, non-set colors are reset to their system dependent default values.</summary>
			public Colors()
				: base(9, 1136, 1137)
			{
			}

			public bool ShouldSerializeForeColor()
			{
				return base.m_aiColors[0] != Color.Empty;
			}

			/// <summary>Resets the status bar's ForeColor to its system dependent default value.</summary>
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

			/// <summary>Resets the status bar's BackColor to its system dependent default value.</summary>
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

			/// <summary>Resets the status bar's GradientBackColor to its system dependent default value.</summary>
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

			/// <summary>Resets the status bar's FrameColor to its system dependent default value.</summary>
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

			/// <summary>Resets the status bar's BackColorTop to its system dependent default value.</summary>
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

			/// <summary>Resets the status bar's BackColorMiddle to its system dependent default value.</summary>
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

			/// <summary>Resets the status bar's BackColorBottom to its system dependent default value.</summary>
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

			/// <summary>Resets the status bar's SeparatorColorLight to its system dependent default value.</summary>
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

			/// <summary>Resets the status bar's SeparatorColorDark to its system dependent default value.</summary>
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

		private string string_2;

		private Enum144 enum144_0 = (Enum144)20737;

		private StatusBarBorderStyle statusBarBorderStyle_0 = StatusBarBorderStyle.VerticalColorScheme;

		private string string_3 = string.Empty;

		private Colors colors_0 = new Colors();

		private string string_4 = string.Empty;

		private string string_5 = "/";

		private string string_6 = string.Empty;

		private string string_7 = "/";

		private string string_8 = string.Empty;

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

		protected override Size DefaultSize => new Size(200, 200);

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.ClassName = this.string_2;
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

		/// <summary>Gets or sets the border style of the status bar.</summary>
		[Category("Appearance")]
		[DefaultValue(StatusBarBorderStyle.VerticalColorScheme)]
		[Attribute3("PROP_SB_BORDERSTYLE")]
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
					if (base.IsHandleCreated)
					{
						Class429.SendMessage_1(base.Handle, 1124, 0, (int)this.statusBarBorderStyle_0 | (int)this.enum144_0);
					}
				}
			}
		}

		/// <summary>Gets or sets the text in the 'Column' area of the status bar.</summary>
		[Category("Appearance")]
		[Attribute3("PROP_SB_COLUMNTEXT")]
		[DefaultValue("")]
		public string ColumnText
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
					if (base.IsHandleCreated)
					{
						this.method_0();
					}
				}
			}
		}

		/// <summary>Gets or sets the colors of the status bar.</summary>
		[TypeConverter(typeof(Class417))]
		[Category("Appearance")]
		[Attribute3("PROP_SB_DISPLAYCOLORS")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
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

		/// <summary>Gets or sets the text in the 'Line' area of the status bar.</summary>
		[Category("Appearance")]
		[DefaultValue("")]
		[Attribute3("PROP_SB_LINETEXT")]
		public string LineText
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
					if (base.IsHandleCreated)
					{
						this.method_0();
					}
				}
			}
		}

		/// <summary>Gets or sets the text in the 'Page counter' area of the status bar.</summary>
		[DefaultValue("/")]
		[Category("Appearance")]
		[Attribute3("PROP_SB_PAGECOUNTERTEXT")]
		public string PageCounterText
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
					if (base.IsHandleCreated)
					{
						this.method_0();
					}
				}
			}
		}

		/// <summary>Gets or sets the text in the 'Page' area of the status bar.</summary>
		[Category("Appearance")]
		[DefaultValue("")]
		[Attribute3("PROP_SB_PAGETEXT")]
		public string PageText
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
					if (base.IsHandleCreated)
					{
						this.method_0();
					}
				}
			}
		}

		/// <summary>Gets or sets the text in the 'Section counter' area of the status bar.</summary>
		[DefaultValue("/")]
		[Category("Appearance")]
		[Attribute3("PROP_SB_SECTIONCOUNTERTEXT")]
		public string SectionCounterText
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
					if (base.IsHandleCreated)
					{
						this.method_0();
					}
				}
			}
		}

		/// <summary>Gets or sets the text in the 'Section' area of the status bar.</summary>
		[Category("Appearance")]
		[DefaultValue("")]
		[Attribute3("PROP_SB_SECTIONTEXT")]
		public string SectionText
		{
			get
			{
				return this.string_8;
			}
			set
			{
				if (this.string_8 != value)
				{
					this.string_8 = value;
					if (base.IsHandleCreated)
					{
						this.method_0();
					}
				}
			}
		}

		/// <summary>Specifies whether the status bar shows the column number of the current text input position.</summary>
		[Category("Appearance")]
		[DefaultValue(true)]
		[Attribute3("PROP_SB_SHOWCOLUMN")]
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
					if (base.IsHandleCreated)
					{
						this.method_0();
					}
				}
			}
		}

		/// <summary>Specifies whether the status bar shows the key state of the CAPSLOCK and the NUMLOCK key and the current insertion mode, insert or overwrite.</summary>
		[DefaultValue(true)]
		[Category("Appearance")]
		[Attribute3("PROP_SB_SHOWKEYSTATES")]
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
					this.enum144_0 &= (Enum144)(-129);
					if (!this.bool_1)
					{
						this.enum144_0 |= Enum144.const_7;
					}
					if (base.IsHandleCreated)
					{
						Class429.SendMessage_1(base.Handle, 1124, 1, (int)this.statusBarBorderStyle_0 | (int)this.enum144_0);
					}
				}
			}
		}

		/// <summary>Specifies whether the status bar shows the language of the text selection or the text input position.</summary>
		[Attribute3("PROP_SB_SHOWLANGUAGE")]
		[DefaultValue(true)]
		[Category("Appearance")]
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
					this.enum144_0 &= (Enum144)(-16385);
					if (this.bool_2)
					{
						this.enum144_0 |= Enum144.const_14;
					}
					if (base.IsHandleCreated)
					{
						Class429.SendMessage_1(base.Handle, 1124, 1, (int)this.statusBarBorderStyle_0 | (int)this.enum144_0);
					}
				}
			}
		}

		/// <summary>Specifies whether the status bar shows the line number of the current text input position.</summary>
		[DefaultValue(true)]
		[Category("Appearance")]
		[Attribute3("PROP_SB_SHOWLINE")]
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
					if (base.IsHandleCreated)
					{
						this.method_0();
					}
				}
			}
		}

		/// <summary>Specifies whether the status bar shows the page number of the current text input position.</summary>
		[Category("Appearance")]
		[DefaultValue(true)]
		[Attribute3("PROP_SB_SHOWPAGE")]
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
					if (base.IsHandleCreated)
					{
						this.method_0();
					}
				}
			}
		}

		/// <summary>Specifies whether the status bar shows the number of pages the document consists of.</summary>
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
					if (base.IsHandleCreated)
					{
						this.method_0();
					}
				}
			}
		}

		/// <summary>Specifies whether the status bar shows the section number of the current text input position.</summary>
		[DefaultValue(true)]
		[Category("Appearance")]
		[Attribute3("PROP_SB_SHOWSECTION")]
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
					if (base.IsHandleCreated)
					{
						this.method_0();
					}
				}
			}
		}

		/// <summary>Specifies whether the status bar shows the number of sections the document consists of.</summary>
		[Category("Appearance")]
		[DefaultValue(true)]
		[Attribute3("PROP_SB_SHOWSECTIONCOUNTER")]
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
					if (base.IsHandleCreated)
					{
						this.method_0();
					}
				}
			}
		}

		/// <summary>Specifies whether the status bar shows the current zoom factor.</summary>
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
					this.enum144_0 &= (Enum144)(-65);
					if (!this.bool_8)
					{
						this.enum144_0 |= Enum144.const_6;
					}
					if (base.IsHandleCreated)
					{
						Class429.SendMessage_1(base.Handle, 1124, 1, (int)this.statusBarBorderStyle_0 | (int)this.enum144_0);
					}
				}
			}
		}

		/// <summary>Specifies whether the status bar displays a track bar instead of a simple number to show and to set the zooming factor.</summary>
		[Attribute3("PROP_SB_SHOWZOOMTRACKBAR")]
		[DefaultValue(true)]
		[Category("Appearance")]
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
					this.enum144_0 &= (Enum144)(-4097);
					if (this.bool_9)
					{
						this.enum144_0 |= Enum144.const_12;
					}
					if (base.IsHandleCreated)
					{
						Class429.SendMessage_1(base.Handle, 1124, 1, (int)this.statusBarBorderStyle_0 | (int)this.enum144_0);
					}
				}
			}
		}

		public StatusBar()
		{
			this.class409_0 = new Class409();
			this.string_2 = "TX_STATUSBAR29_DOTNET";
			this.BackColor = SystemColors.Control;
			base.SetStyle(ControlStyles.UserPaint, value: false);
			this.Font = SystemFonts.MenuFont;
			this.method_1();
		}

		protected override void OnFontChanged(EventArgs eventArgs_0)
		{
			if (base.IsHandleCreated)
			{
				IntPtr intPtr = this.Font.ToHfont();
				Class429.SendMessage_1(base.Handle, 48, (int)intPtr, 1);
				Class429.DeleteObject(intPtr);
			}
			base.OnFontChanged(eventArgs_0);
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			base.OnHandleCreated(eventArgs_0);
			IntPtr intPtr = this.Font.ToHfont();
			Class429.SendMessage_1(base.Handle, 48, (int)intPtr, 0);
			Class429.DeleteObject(intPtr);
			Class429.SendMessage_1(base.Handle, 1124, 0, (int)this.statusBarBorderStyle_0 | (int)this.enum144_0);
			this.method_0();
			if (this.ForeColor != SystemColors.ControlText)
			{
				Class429.SendMessage_1(base.Handle, 2055, 0, Class429.smethod_0(this.ForeColor));
			}
			if (this.BackColor != SystemColors.Control)
			{
				Class429.SendMessage_1(base.Handle, 2057, 0, Class429.smethod_0(this.BackColor));
			}
			this.colors_0.method_5(base.Handle);
			this.colors_0.method_1();
			Class429.SendMessage_1(int_3: Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName switch
			{
				"de" => 49, 
				"en" => 1, 
				_ => 20000, 
			}, intptr_0: base.Handle, int_2: 2035, int_4: 0);
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
			case 2053:
			{
				ResourceManager resourceManager = new ResourceManager(typeof(TextControlCore));
				int int_ = message.WParam.ToInt32();
				TxString txString = (TxString)Class429.smethod_5(int_);
				string @string = resourceManager.GetString(txString.ToString());
				message.Result = IntPtr.Zero;
				if (@string != null)
				{
					int length = Math.Min(Class429.smethod_6(int_) - 1, @string.Length);
					if (message.LParam != IntPtr.Zero)
					{
						Marshal.Copy(@string.ToCharArray(), 0, message.LParam, length);
						message.Result = new IntPtr(1);
					}
				}
				break;
			}
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

		/// <summary>Resets all display colors of a status bar to their system dependent default values.</summary>
		public void ResetDisplayColors()
		{
			this.colors_0.method_3();
		}

		private void method_0()
		{
			string text = this.string_6;
			if (this.bool_4)
			{
				text += "%u";
			}
			text = text + "\t" + this.string_4;
			if (this.bool_3)
			{
				text += "%u";
			}
			text = text + "\t" + this.string_3;
			if (this.bool_0)
			{
				text += "%u";
			}
			text = text + "\t" + this.string_5;
			if (this.bool_5)
			{
				text += "%u";
			}
			text = text + "\t" + this.string_8;
			if (this.bool_6)
			{
				text += "%u";
			}
			text = text + "\t" + this.string_7;
			if (this.bool_7)
			{
				text += "%u";
			}
			this.enum144_0 &= (Enum144)(-2105);
			if (!this.bool_0)
			{
				this.enum144_0 |= Enum144.const_5;
			}
			if (!this.bool_3)
			{
				this.enum144_0 |= Enum144.const_4;
			}
			if (!this.bool_4 && !this.bool_5)
			{
				this.enum144_0 |= Enum144.const_3;
			}
			if (!this.bool_6 && !this.bool_7)
			{
				this.enum144_0 |= Enum144.const_11;
			}
			Class429.SendMessage_1(base.Handle, 1124, 0, (int)this.statusBarBorderStyle_0 | (int)this.enum144_0);
			IntPtr intPtr = Marshal.StringToBSTR(text);
			Class429.SendMessage_6(base.Handle, 1135, 2, intPtr);
			Marshal.FreeBSTR(intPtr);
		}

		private void method_1()
		{
			this.container_0 = new Container();
		}
	}
}
