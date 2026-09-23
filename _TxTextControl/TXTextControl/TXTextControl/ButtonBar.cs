using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ns21;

namespace TXTextControl
{
	/// <summary>The ButtonBar class represents a Windows Forms tool bar which can be used to show or to set font and paragraph attributes of a Windows Forms TextControl.</summary>
	[ToolboxBitmap(typeof(ButtonBar))]
	public class ButtonBar : Control
	{
		/// <summary>The ButtonBar.Colors class gets, sets or resets the display colors of a Windows Forms ButtonBar control.</summary>
		public sealed class Colors : ColorBase
		{
			/// <summary>Gets or sets the color used for text and the button images.</summary>
			[Attribute3("PROP_BB_DISPLAYCOLORS_FORECOLOR")]
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

			/// <summary>Gets or sets the background color at the left edge of the button bar.</summary>
			[Category("Appearance")]
			[Attribute3("PROP_BB_DISPLAYCOLORS_BACKCOLOR")]
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

			/// <summary>Gets or sets the background color at the right edge of the button bar.</summary>
			[Attribute3("PROP_BB_DISPLAYCOLORS_GRADIENTBACKCOLOR")]
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

			/// <summary>Gets or sets the color of the light part of a separator.</summary>
			[Category("Appearance")]
			[Attribute3("PROP_BB_DISPLAYCOLORS_SEPARATORCOLORLIGHT")]
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

			/// <summary>Gets or sets the color of the dark part of a separator.</summary>
			[Attribute3("PROP_BB_DISPLAYCOLORS_SEPARATORCOLORDARK")]
			[Category("Appearance")]
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

			/// <summary>Gets or sets the background color of the combo boxes.</summary>
			[Category("Appearance")]
			[Attribute3("PROP_BB_DISPLAYCOLORS_COMBOBOXBACKCOLOR")]
			public Color ComboBoxBackColor
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

			/// <summary>Gets or sets the background color at the top of a button.</summary>
			[Attribute3("PROP_BB_DISPLAYCOLORS_BUTTONBACKCOLORTOP")]
			[Category("Appearance")]
			public Color ButtonBackColorTop
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

			/// <summary>Gets or sets the background color in the middle of a button.</summary>
			[Category("Appearance")]
			[Attribute3("PROP_BB_DISPLAYCOLORS_BUTTONBACKCOLORMIDDLE")]
			public Color ButtonBackColorMiddle
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

			/// <summary>Gets or sets the background color at the bottom of a button.</summary>
			[Category("Appearance")]
			[Attribute3("PROP_BB_DISPLAYCOLORS_BUTTONBACKCOLORBOTTOM")]
			public Color ButtonBackColorBottom
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

			/// <summary>Gets or sets the background color at the top of a button, if the mouse cursor is over the button.</summary>
			[Attribute3("PROP_BB_DISPLAYCOLORS_BUTTONHOTTRACKTOP")]
			[Category("Appearance")]
			public Color ButtonHotTrackTop
			{
				get
				{
					return base.GetColor(9);
				}
				set
				{
					base.SetColor(value, 9);
				}
			}

			/// <summary>Gets or sets the background color at the bottom of a button, if the mouse cursor is over the button.</summary>
			[Category("Appearance")]
			[Attribute3("PROP_BB_DISPLAYCOLORS_BUTTONHOTTRACKBOTTOM")]
			public Color ButtonHotTrackBottom
			{
				get
				{
					return base.GetColor(10);
				}
				set
				{
					base.SetColor(value, 10);
				}
			}

			/// <summary>Gets or sets the background color at the top of a button used when the button is selected.</summary>
			[Category("Appearance")]
			[Attribute3("PROP_BB_DISPLAYCOLORS_BUTTONSELECTEDTOP")]
			public Color ButtonSelectedTop
			{
				get
				{
					return base.GetColor(11);
				}
				set
				{
					base.SetColor(value, 11);
				}
			}

			/// <summary>Gets or sets the background color at the bottom of a button used when the button is selected.</summary>
			[Attribute3("PROP_BB_DISPLAYCOLORS_BUTTONSELECTEDBOTTOM")]
			[Category("Appearance")]
			public Color ButtonSelectedBottom
			{
				get
				{
					return base.GetColor(12);
				}
				set
				{
					base.SetColor(value, 12);
				}
			}

			/// <summary>Gets or sets the background color at the top of a button used when the button is pressed down.</summary>
			[Category("Appearance")]
			[Attribute3("PROP_BB_DISPLAYCOLORS_BUTTONPRESSEDTOP")]
			public Color ButtonPressedTop
			{
				get
				{
					return base.GetColor(13);
				}
				set
				{
					base.SetColor(value, 13);
				}
			}

			/// <summary>Gets or sets the background color at the bottom of a button used when the button is pressed down.</summary>
			[Category("Appearance")]
			[Attribute3("PROP_BB_DISPLAYCOLORS_BUTTONPRESSEDBOTTOM")]
			public Color ButtonPressedBottom
			{
				get
				{
					return base.GetColor(14);
				}
				set
				{
					base.SetColor(value, 14);
				}
			}

			/// <summary>Gets or sets the frame color of a selected or pressed button.</summary>
			[Category("Appearance")]
			[Attribute3("PROP_BB_DISPLAYCOLORS_BUTTONFRAMECOLOR")]
			public Color ButtonFrameColor
			{
				get
				{
					return base.GetColor(15);
				}
				set
				{
					base.SetColor(value, 15);
				}
			}

			/// <summary>Initializes a new instance of the ButtonBar.Colors class. After creating the object with this constuctor, individual colors can be set. If the Colors object is assigned to the ButtonBar.DisplayColors property, non-set colors are reset to their system dependent default values.</summary>
			public Colors()
				: base(16, 1044, 1045)
			{
			}

			public bool ShouldSerializeForeColor()
			{
				return base.m_aiColors[0] != Color.Empty;
			}

			/// <summary>Resets the button bar's ForeColor to its system dependent default value.</summary>
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

			/// <summary>Resets the button bar's BackColor to its system dependent default value.</summary>
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

			/// <summary>Resets the button bar's GradientBackColor to its system dependent default value.</summary>
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

			/// <summary>Resets the button bar's SeparatorColorLight to its system dependent default value.</summary>
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

			/// <summary>Resets the button bar's SeparatorColorDark to its system dependent default value.</summary>
			public void ResetSeparatorColorDark()
			{
				ref Color reference = ref base.m_aiColors[4];
				reference = Color.Empty;
				base.method_0();
			}

			public bool ShouldSerializeComboBoxBackColor()
			{
				return base.m_aiColors[5] != Color.Empty;
			}

			/// <summary>Resets the button bar's ComboBoxBackColor to its system dependent default value.</summary>
			public void ResetComboBoxBackColor()
			{
				ref Color reference = ref base.m_aiColors[5];
				reference = Color.Empty;
				base.method_0();
			}

			public bool ShouldSerializeButtonBackColorTop()
			{
				return base.m_aiColors[6] != Color.Empty;
			}

			/// <summary>Resets the button bar's ButtonBackColorTop to its system dependent default value.</summary>
			public void ResetButtonBackColorTop()
			{
				ref Color reference = ref base.m_aiColors[6];
				reference = Color.Empty;
				base.method_0();
			}

			public bool ShouldSerializeButtonBackColorMiddle()
			{
				return base.m_aiColors[7] != Color.Empty;
			}

			/// <summary>Resets the button bar's ButtonBackColorMiddle to its system dependent default value.</summary>
			public void ResetButtonBackColorMiddle()
			{
				ref Color reference = ref base.m_aiColors[7];
				reference = Color.Empty;
				base.method_0();
			}

			public bool ShouldSerializeButtonBackColorBottom()
			{
				return base.m_aiColors[8] != Color.Empty;
			}

			/// <summary>Resets the button bar's ButtonBackColorBottom to its system dependent default value.</summary>
			public void ResetButtonBackColorBottom()
			{
				ref Color reference = ref base.m_aiColors[8];
				reference = Color.Empty;
				base.method_0();
			}

			public bool ShouldSerializeButtonHotTrackTop()
			{
				return base.m_aiColors[9] != Color.Empty;
			}

			/// <summary>Resets the button bar's ButtonHotTrackTop to its system dependent default value.</summary>
			public void ResetButtonHotTrackTop()
			{
				ref Color reference = ref base.m_aiColors[9];
				reference = Color.Empty;
				base.method_0();
			}

			public bool ShouldSerializeButtonHotTrackBottom()
			{
				return base.m_aiColors[10] != Color.Empty;
			}

			/// <summary>Resets the button bar's ButtonHotTrackBottom to its system dependent default value.</summary>
			public void ResetButtonHotTrackBottom()
			{
				ref Color reference = ref base.m_aiColors[10];
				reference = Color.Empty;
				base.method_0();
			}

			public bool ShouldSerializeButtonSelectedTop()
			{
				return base.m_aiColors[11] != Color.Empty;
			}

			/// <summary>Resets the button bar's ButtonSelectedTop to its system dependent default value.</summary>
			public void ResetButtonSelectedTop()
			{
				ref Color reference = ref base.m_aiColors[11];
				reference = Color.Empty;
				base.method_0();
			}

			public bool ShouldSerializeButtonSelectedBottom()
			{
				return base.m_aiColors[12] != Color.Empty;
			}

			/// <summary>Resets the button bar's ButtonSelectedBottom to its system dependent default value.</summary>
			public void ResetButtonSelectedBottom()
			{
				ref Color reference = ref base.m_aiColors[12];
				reference = Color.Empty;
				base.method_0();
			}

			public bool ShouldSerializeButtonPressedTop()
			{
				return base.m_aiColors[13] != Color.Empty;
			}

			/// <summary>Resets the button bar's ButtonPressedTop to its system dependent default value.</summary>
			public void ResetButtonPressedTop()
			{
				ref Color reference = ref base.m_aiColors[13];
				reference = Color.Empty;
				base.method_0();
			}

			public bool ShouldSerializeButtonPressedBottom()
			{
				return base.m_aiColors[14] != Color.Empty;
			}

			/// <summary>Resets the button bar's ButtonPressedBottom to its system dependent default value.</summary>
			public void ResetButtonPressedBottom()
			{
				ref Color reference = ref base.m_aiColors[14];
				reference = Color.Empty;
				base.method_0();
			}

			public bool ShouldSerializeButtonFrameColor()
			{
				return base.m_aiColors[15] != Color.Empty;
			}

			/// <summary>Resets the button bar's ButtonFrameColor to its system dependent default value.</summary>
			public void ResetButtonFrameColor()
			{
				ref Color reference = ref base.m_aiColors[15];
				reference = Color.Empty;
				base.method_0();
			}
		}

		private const int int_0 = 31;

		private Container container_0;

		private Class409 class409_0;

		private string string_0;

		private ButtonBarBorderStyle buttonBarBorderStyle_0 = ButtonBarBorderStyle.ColorScheme;

		private ButtonStyle buttonStyle_0 = ButtonStyle.ColorScheme;

		private Button[] button_0 = new Button[31]
		{
			Button.StyleComboBox,
			Button.FontNameComboBox,
			Button.FontSizeComboBox,
			Button.FontBoldButton,
			Button.FontItalicButton,
			Button.FontUnderlineButton,
			Button.AlignmentLeftButton,
			Button.AlignmentRightButton,
			Button.AlignmentCenteredButton,
			Button.AlignmentJustifiedButton,
			Button.ListBulletedButton,
			Button.ListNumberedButton,
			Button.ListStructuredButton,
			Button.ZoomComboBox,
			Button.ControlCharsButton,
			Button.TabSelectionButton,
			Button.None,
			Button.None,
			Button.None,
			Button.None,
			Button.None,
			Button.None,
			Button.None,
			Button.None,
			Button.None,
			Button.None,
			Button.None,
			Button.None,
			Button.None,
			Button.None,
			Button.None
		};

		private Button[] button_1 = new Button[31]
		{
			Button.StyleComboBox,
			Button.FontNameComboBox,
			Button.FontSizeComboBox,
			Button.FontBoldButton,
			Button.FontItalicButton,
			Button.FontUnderlineButton,
			Button.AlignmentLeftButton,
			Button.AlignmentRightButton,
			Button.AlignmentCenteredButton,
			Button.AlignmentJustifiedButton,
			Button.ListBulletedButton,
			Button.ListNumberedButton,
			Button.ListStructuredButton,
			Button.ZoomComboBox,
			Button.ControlCharsButton,
			Button.TabSelectionButton,
			Button.None,
			Button.None,
			Button.None,
			Button.None,
			Button.None,
			Button.None,
			Button.None,
			Button.None,
			Button.None,
			Button.None,
			Button.None,
			Button.None,
			Button.None,
			Button.None,
			Button.None
		};

		private int[] int_1 = new int[31]
		{
			10, 0, 0, 10, 0, 0, 10, 0, 0, 0,
			10, 0, 0, 10, 10, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0
		};

		private int[] int_2 = new int[31]
		{
			10, 0, 0, 10, 0, 0, 10, 0, 0, 0,
			10, 0, 0, 10, 10, 0, 0, 0, 0, 0,
			0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
			0
		};

		private bool[] bool_0 = new bool[31]
		{
			false, false, false, true, false, false, true, false, false, false,
			true, false, false, true, true, false, false, false, false, false,
			false, false, false, false, false, false, false, false, false, false,
			false
		};

		private bool[] bool_1 = new bool[31]
		{
			false, false, false, true, false, false, true, false, false, false,
			true, false, false, true, true, false, false, false, false, false,
			false, false, false, false, false, false, false, false, false, false,
			false
		};

		private Colors colors_0 = new Colors();

		private int int_3;

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

		/// <summary>Gets or sets the border style of the button bar.</summary>
		[Attribute3("PROP_BB_BORDERSTYLE")]
		[DefaultValue(ButtonBarBorderStyle.ColorScheme)]
		[Category("Appearance")]
		public ButtonBarBorderStyle BorderStyle
		{
			get
			{
				return this.buttonBarBorderStyle_0;
			}
			set
			{
				if (this.buttonBarBorderStyle_0 != value)
				{
					this.buttonBarBorderStyle_0 = value;
					if (base.IsHandleCreated)
					{
						Class429.SendMessage_1(base.Handle, 1036, 0, (int)this.buttonBarBorderStyle_0 | (int)this.buttonStyle_0 | this.int_3);
					}
				}
			}
		}

		/// <summary>Gets or sets the painting style of the buttons.</summary>
		[DefaultValue(ButtonStyle.ColorScheme)]
		[Attribute3("PROP_BB_BUTTONSTYLE")]
		[Category("Appearance")]
		public ButtonStyle ButtonStyle
		{
			get
			{
				return this.buttonStyle_0;
			}
			set
			{
				if (this.buttonStyle_0 != value)
				{
					this.buttonStyle_0 = value;
					if (base.IsHandleCreated)
					{
						Class429.SendMessage_1(base.Handle, 1036, 0, (int)this.buttonBarBorderStyle_0 | (int)this.buttonStyle_0 | this.int_3);
					}
				}
			}
		}

		/// <summary>Gets or sets an array of buttons the button bar consists of.</summary>
		[RefreshProperties(RefreshProperties.Repaint)]
		[Attribute3("PROP_BB_BUTTONPOSITIONS")]
		[Category("Appearance")]
		public Button[] ButtonPositions
		{
			get
			{
				if (base.IsHandleCreated)
				{
					this.method_0();
				}
				return (Button[])this.button_1.Clone();
			}
			set
			{
				if (value.Length > this.button_1.Length)
				{
					throw new ArgumentOutOfRangeException();
				}
				int num = -1;
				if (value.Length == this.button_1.Length)
				{
					num = 0;
					for (int i = 0; i < this.button_1.Length; i++)
					{
						if (value[i] != this.button_1[i])
						{
							num = ((num == 0) ? (i + 1) : (-1));
						}
					}
				}
				if (base.IsHandleCreated)
				{
					if (num > 0)
					{
						this.method_2(value, num);
					}
					else
					{
						this.method_1(value, this.int_2, this.bool_1);
					}
					this.method_0();
				}
				else
				{
					value.CopyTo(this.button_1, 0);
				}
			}
		}

		/// <summary>Gets or sets an array of additional offsets, in pixels, between the buttons.</summary>
		[RefreshProperties(RefreshProperties.Repaint)]
		[Attribute3("PROP_BB_BUTTONOFFSETS")]
		[Category("Appearance")]
		public int[] ButtonOffsets
		{
			get
			{
				if (base.IsHandleCreated)
				{
					this.method_0();
				}
				return (int[])this.int_2.Clone();
			}
			set
			{
				if (value.Length > this.int_2.Length)
				{
					throw new ArgumentOutOfRangeException();
				}
				if (base.IsHandleCreated)
				{
					this.method_1(this.button_1, value, this.bool_1);
				}
				value.CopyTo(this.int_2, 0);
			}
		}

		/// <summary>Gets or sets an array of boolean values specifying whether or not a separator is drawn between two buttons.</summary>
		[Category("Appearance")]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Attribute3("PROP_BB_BUTTONSEPARATORS")]
		public bool[] ButtonSeparators
		{
			get
			{
				if (base.IsHandleCreated)
				{
					this.method_0();
				}
				return (bool[])this.bool_1.Clone();
			}
			set
			{
				if (value.Length > this.bool_1.Length)
				{
					throw new ArgumentOutOfRangeException();
				}
				if (base.IsHandleCreated)
				{
					this.method_1(this.button_1, this.int_2, value);
				}
				value.CopyTo(this.bool_1, 0);
			}
		}

		/// <summary>Gets or sets the colors of the button bar.</summary>
		[Attribute3("PROP_BB_DISPLAYCOLORS")]
		[TypeConverter(typeof(Class417))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[RefreshProperties(RefreshProperties.Repaint)]
		[Category("Appearance")]
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

		/// <summary>Gets or sets a value determining the button bar's read only mode.</summary>
		[DefaultValue(false)]
		[Category("Behavior")]
		[Attribute3("PROP_BB_READONLY")]
		public bool ReadOnly
		{
			get
			{
				if (this.int_3 != 0)
				{
					return true;
				}
				return false;
			}
			set
			{
				int num = (value ? 2048 : 0);
				if (num != this.int_3)
				{
					this.int_3 = num;
					if (base.IsHandleCreated)
					{
						Class429.SendMessage_1(base.Handle, 1036, 0, (int)this.buttonBarBorderStyle_0 | (int)this.buttonStyle_0 | this.int_3);
					}
				}
			}
		}

		public ButtonBar()
		{
			this.class409_0 = new Class409();
			this.string_0 = "TX_BUTTONBAR29_DOTNET";
			this.BackColor = SystemColors.Control;
			base.SetStyle(ControlStyles.UserPaint, value: false);
			this.method_3();
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			base.OnHandleCreated(eventArgs_0);
			Class429.SendMessage_1(base.Handle, 1036, 0, (int)this.buttonBarBorderStyle_0 | (int)this.buttonStyle_0 | this.int_3);
			this.method_1(this.button_1, this.int_2, this.bool_1);
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

		public bool ShouldSerializeButtonPositions()
		{
			int num = 0;
			while (true)
			{
				if (num < this.button_0.Length)
				{
					if (this.button_0[num] != this.button_1[num])
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

		/// <summary>Resets the button array to its default state.</summary>
		public void ResetButtonPositions()
		{
			for (int i = 0; i < this.button_0.Length; i++)
			{
				this.button_1[i] = this.button_0[i];
			}
			this.ButtonPositions = this.button_1;
		}

		public bool ShouldSerializeButtonOffsets()
		{
			int num = 0;
			while (true)
			{
				if (num < this.int_1.Length)
				{
					if (this.int_1[num] != this.int_2[num])
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

		/// <summary>Resets the offset array to its default state.</summary>
		public void ResetButtonOffsets()
		{
			for (int i = 0; i < this.int_1.Length; i++)
			{
				this.int_2[i] = this.int_1[i];
			}
			this.ButtonOffsets = this.int_2;
		}

		public bool ShouldSerializeButtonSeparators()
		{
			int num = 0;
			while (true)
			{
				if (num < this.bool_0.Length)
				{
					if (this.bool_0[num] != this.bool_1[num])
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

		/// <summary>Resets the separator array to its default state.</summary>
		public void ResetButtonSeparators()
		{
			for (int i = 0; i < this.bool_0.Length; i++)
			{
				this.bool_1[i] = this.bool_0[i];
			}
			this.ButtonSeparators = this.bool_1;
		}

		public bool ShouldSerializeDisplayColors()
		{
			return !this.colors_0.method_4();
		}

		/// <summary>Resets all display colors of a button bar to their system dependent default values.</summary>
		public void ResetDisplayColors()
		{
			this.colors_0.method_3();
		}

		private void method_0()
		{
			Struct75 struct75_ = default(Struct75);
			Button[] array = (Button[])Enum.GetValues(typeof(Button));
			for (int i = 0; i < this.button_1.Length; i++)
			{
				this.button_1[i] = Button.None;
			}
			Button[] array2 = array;
			foreach (Button button in array2)
			{
				if (button != 0)
				{
					struct75_.uint_0 = (uint)button;
					int num = Class429.SendMessage_47(base.Handle, 1038, 0, out struct75_);
					if (num > 0)
					{
						this.button_1[num - 1] = button;
						this.int_2[num - 1] = struct75_.int_0;
						this.bool_1[num - 1] = (((struct75_.uint_2 & 0x8000u) != 0) ? true : false);
					}
				}
			}
		}

		private void method_1(Button[] button_2, int[] int_4, bool[] bool_2)
		{
			Struct75[] array = new Struct75[this.button_1.Length];
			for (int i = 0; i < button_2.Length; i++)
			{
				array[i].uint_0 = (uint)button_2[i];
				array[i].uint_1 = 0u;
				array[i].uint_2 = (bool_2[i] ? 32768u : 0u);
				array[i].int_0 = int_4[i];
			}
			Class429.SendMessage_46(base.Handle, 1040, this.button_1.Length, array);
		}

		private void method_2(Button[] button_2, int int_4)
		{
			Struct75[] array = new Struct75[1];
			array[0].uint_0 = (uint)((button_2[int_4 - 1] == Button.None) ? this.button_1[int_4 - 1] : button_2[int_4 - 1]);
			array[0].uint_1 = 0u;
			array[0].uint_2 = 0u;
			array[0].int_0 = 0;
			Class429.SendMessage_46(base.Handle, 1039, (button_2[int_4 - 1] != 0) ? int_4 : 0, array);
		}

		private void method_3()
		{
			this.container_0 = new Container();
		}
	}
}
