using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ns21;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>The RibbonTextBox class is a control that can be used to display or edit unformatted text.</summary>
	[ToolboxItem(false)]
	public class RibbonTextBox : Control, IRibbonItem, IContentItem, IScalable
	{
		/// <summary>Determines the validation mode that is used to validate the inserted text in the RibbonTextBox:</summary>
		public enum InputValidationMode
		{
			/// <summary>All characters are valid to be inserted into the text box.</summary>
			All,
			/// <summary>Only letters or digits are valid text box characters.</summary>
			LettersOrDigits,
			/// <summary>Only letters or digits are valid text box characters.</summary>
			OnlyLetters,
			/// <summary>Only digits are valid text box characters.</summary>
			OnlyDigits,
			/// <summary>Only integers are valid text box characters.</summary>
			OnlyIntegers
		}

		internal class Class561
		{
			private bool bool_0 = true;

			private bool bool_1;

			private bool bool_2;

			private bool bool_3;

			private bool bool_4 = true;

			private int int_0;

			private Rectangle rectangle_0 = Rectangle.Empty;

			private Rectangle rectangle_1 = Rectangle.Empty;

			private Rectangle rectangle_2 = Rectangle.Empty;

			private RibbonTextBox ribbonTextBox_0;

			private VisualStyleRenderer visualStyleRenderer_0;

			private VisualStyleRenderer visualStyleRenderer_1;

			private VisualStyleRenderer visualStyleRenderer_2;

			internal bool Boolean_0
			{
				get
				{
					return this.bool_0;
				}
				set
				{
					this.bool_0 = value;
				}
			}

			internal bool Boolean_1 => this.bool_3;

			internal bool Boolean_2
			{
				get
				{
					return this.bool_4;
				}
				set
				{
					this.bool_4 = value;
				}
			}

			internal int Int32_0 => this.int_0;

			internal Class561(RibbonTextBox ribbonTextBox_1)
			{
				try
				{
					this.visualStyleRenderer_2 = new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal);
					this.visualStyleRenderer_1 = new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal);
					this.visualStyleRenderer_0 = new VisualStyleRenderer(VisualStyleElement.Button.GroupBox.Normal);
				}
				catch
				{
				}
				this.ribbonTextBox_0 = ribbonTextBox_1;
				this.method_3();
			}

			internal bool method_0()
			{
				if (!this.bool_2 && !this.bool_1)
				{
					return false;
				}
				if (this.bool_2)
				{
					if (this.bool_4)
					{
						this.ribbonTextBox_0.method_14();
					}
				}
				else if (this.bool_0)
				{
					this.ribbonTextBox_0.method_12();
				}
				return true;
			}

			internal void method_1(Graphics graphics_0)
			{
				if (this.visualStyleRenderer_0 != null)
				{
					this.visualStyleRenderer_0.DrawBackground(graphics_0, this.rectangle_0);
				}
				Color color = Color.FromArgb(65, this.ribbonTextBox_0.ForeColor);
				if (this.visualStyleRenderer_1 != null)
				{
					this.visualStyleRenderer_1.DrawBackground(graphics_0, this.rectangle_1);
				}
				Color color_ = ((!this.bool_0 || !this.ribbonTextBox_0.Enabled) ? color : this.ribbonTextBox_0.ForeColor);
				Class517.smethod_17(graphics_0, this.rectangle_1, color_, ArrowDirection.Down, ((IRibbonItem)this.ribbonTextBox_0).DPI);
				if (this.visualStyleRenderer_2 != null)
				{
					this.visualStyleRenderer_2.DrawBackground(graphics_0, this.rectangle_2);
				}
				Color color_2 = ((!this.bool_4 || !this.ribbonTextBox_0.Enabled) ? color : this.ribbonTextBox_0.ForeColor);
				Class517.smethod_17(graphics_0, this.rectangle_2, color_2, ArrowDirection.Up, ((IRibbonItem)this.ribbonTextBox_0).DPI);
			}

			internal void method_2()
			{
				try
				{
					this.visualStyleRenderer_2 = ((!this.bool_4 || !this.ribbonTextBox_0.Enabled) ? new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Disabled) : new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal));
					this.visualStyleRenderer_1 = ((!this.bool_0 || !this.ribbonTextBox_0.Enabled) ? new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Disabled) : new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal));
				}
				catch
				{
				}
			}

			internal void method_3()
			{
				if (!((IRibbonItem)this.ribbonTextBox_0).DPI.IsEmpty)
				{
					this.int_0 = Class517.smethod_45(Class519.Class531.UpDownButtons.UpDownButtonsWidth, ((IRibbonItem)this.ribbonTextBox_0).DPI.X);
					int x = ((!this.ribbonTextBox_0.bool_1) ? (this.ribbonTextBox_0.Width - this.int_0) : 0);
					int y = this.ribbonTextBox_0.Rectangle_0.Y;
					int width = this.int_0;
					int height = this.ribbonTextBox_0.Rectangle_0.Height;
					this.rectangle_0 = new Rectangle(x, y, width, height);
					int num = height / 2;
					this.rectangle_2 = new Rectangle(x, y + 1, width, num);
					this.rectangle_1 = new Rectangle(x, this.ribbonTextBox_0.Rectangle_0.Bottom - num, width, num);
				}
			}

			internal bool method_4(Point point_0)
			{
				bool flag = this.bool_3;
				bool flag2 = this.bool_2;
				bool flag3 = this.bool_1;
				try
				{
					if (this.bool_3 = this.rectangle_0.Contains(point_0) && !this.ribbonTextBox_0.ribbonGroup_0.Boolean_2)
					{
						if (this.bool_2 = this.rectangle_2.Contains(point_0))
						{
							this.visualStyleRenderer_2 = ((!this.bool_4 || !this.ribbonTextBox_0.Enabled) ? new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Disabled) : new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Hot));
							this.visualStyleRenderer_1 = ((!this.bool_0 || !this.ribbonTextBox_0.Enabled) ? new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Disabled) : new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal));
						}
						else if (this.bool_1 = this.rectangle_1.Contains(point_0))
						{
							this.visualStyleRenderer_2 = ((!this.bool_4 || !this.ribbonTextBox_0.Enabled) ? new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Disabled) : new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal));
							this.visualStyleRenderer_1 = ((!this.bool_0 || !this.ribbonTextBox_0.Enabled) ? new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Disabled) : new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Hot));
						}
						else
						{
							this.visualStyleRenderer_2 = ((!this.bool_4 || !this.ribbonTextBox_0.Enabled) ? new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Disabled) : new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal));
							this.visualStyleRenderer_1 = ((!this.bool_0 || !this.ribbonTextBox_0.Enabled) ? new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Disabled) : new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal));
						}
					}
					else
					{
						this.bool_1 = false;
						this.bool_2 = false;
						this.visualStyleRenderer_2 = (this.visualStyleRenderer_1 = new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal));
					}
				}
				catch
				{
				}
				if (this.bool_3 == flag && this.bool_2 == flag2)
				{
					return this.bool_1 != flag3;
				}
				return true;
			}
		}

		internal class Class562 : TextBox
		{
			private bool bool_0;

			private bool bool_1;

			private bool bool_2;

			private RibbonTextBox ribbonTextBox_0;

			internal RibbonTextBox RibbonTextBox_0
			{
				get
				{
					return this.ribbonTextBox_0;
				}
				set
				{
					this.ribbonTextBox_0 = value;
				}
			}

			protected override Padding DefaultMargin => new Padding(2, 0, 2, 0);

			protected override Size DefaultSize => new Size(50, 13);

			internal Class562()
			{
				base.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
				base.BorderStyle = System.Windows.Forms.BorderStyle.None;
				this.AutoSize = false;
				base.ShortcutsEnabled = false;
				this.ShortcutsEnabled = true;
			}

			protected override void OnEnter(EventArgs eventArgs_0)
			{
				this.ribbonTextBox_0.String_1 = base.Text;
				base.OnEnter(eventArgs_0);
			}

			protected override void OnFontChanged(EventArgs eventArgs_0)
			{
				if (base.IsHandleCreated)
				{
					base.Height = TextRenderer.MeasureText("A", base.Font).Height + Class517.smethod_45(Class519.Class531.InternalTextBox.HightOffset, ((IRibbonItem)this.ribbonTextBox_0).DPI.Y);
				}
				base.OnFontChanged(eventArgs_0);
			}

			protected override void OnHandleCreated(EventArgs eventArgs_0)
			{
				base.OnHandleCreated(eventArgs_0);
				base.Height = TextRenderer.MeasureText("A", base.Font).Height + Class517.smethod_45(Class519.Class531.InternalTextBox.HightOffset, ((IRibbonItem)this.ribbonTextBox_0).DPI.Y);
			}

			protected override void OnKeyDown(KeyEventArgs keyEventArgs_0)
			{
				base.OnKeyDown(keyEventArgs_0);
				this.ribbonTextBox_0.OnKeyDown(keyEventArgs_0);
				if (this.bool_2 = keyEventArgs_0.KeyData == Keys.Return)
				{
					this.ribbonTextBox_0.method_11(this.Text, bool_13: true);
				}
			}

			protected override void OnLostFocus(EventArgs eventArgs_0)
			{
				if (!this.bool_1)
				{
					this.bool_0 = true;
					this.bool_2 = true;
					this.ribbonTextBox_0.method_11(this.Text, bool_13: true);
				}
				this.bool_1 = false;
				base.OnLostFocus(eventArgs_0);
				this.ribbonTextBox_0.OnLostFocus(new EventArgs());
			}

			protected override void OnKeyPress(KeyPressEventArgs keyPressEventArgs_0)
			{
				base.OnKeyPress(keyPressEventArgs_0);
				keyPressEventArgs_0.Handled = !this.ribbonTextBox_0.method_5(keyPressEventArgs_0.KeyChar);
				if (keyPressEventArgs_0.KeyChar == '\r')
				{
					keyPressEventArgs_0.Handled = true;
				}
			}

			protected override void OnLeave(EventArgs eventArgs_0)
			{
				if (!this.bool_0)
				{
					this.bool_1 = true;
					this.bool_2 = true;
					this.ribbonTextBox_0.method_11(this.Text, bool_13: true);
				}
				this.bool_0 = false;
				base.OnLeave(eventArgs_0);
			}

			protected override void OnTextChanged(EventArgs eventArgs_0)
			{
				base.OnTextChanged(eventArgs_0);
				this.ribbonTextBox_0.OnTextChanged(new EventArgs());
			}

			protected override void WndProc(ref Message message)
			{
				Class429.Enum121 msg = (Class429.Enum121)message.Msg;
				if (msg != Class429.Enum121.const_56)
				{
					base.WndProc(ref message);
				}
			}
		}

		private bool bool_0 = true;

		private bool bool_1;

		private bool bool_2;

		private bool bool_3 = true;

		private bool bool_4;

		private bool bool_5 = true;

		private bool bool_6;

		private bool bool_7;

		private bool bool_8 = true;

		private int int_0;

		private int int_1;

		private int? nullable_0 = null;

		private int int_2;

		private PointF pointF_0 = PointF.Empty;

		private string string_0;

		private string string_1;

		private string string_2 = string.Empty;

		private string string_3 = "";

		private string string_4;

		private string string_5 = "";

		private string string_6 = "";

		private Color color_0;

		private System.Windows.Forms.HorizontalAlignment horizontalAlignment_0 = System.Windows.Forms.HorizontalAlignment.Right;

		private IconTextRelation iconTextRelation_0 = IconTextRelation.SmallIconLabeled;

		private IconTextRelation iconTextRelation_1 = IconTextRelation.SmallIconLabeled;

		private System.Drawing.Image image_0;

		private System.Drawing.Image image_1;

		protected ImageAttributes m_iaImageAttribute;

		private InputValidationMode inputValidationMode_0;

		private Class562 class562_0;

		private Padding padding_0;

		private Padding padding_1;

		private Padding padding_2;

		private Padding padding_3;

		private Padding padding_4;

		private NumberFormatInfo numberFormatInfo_0;

		private Rectangle rectangle_0;

		private Rectangle rectangle_1;

		private Point point_0;

		private Rectangle rectangle_2 = default(Rectangle);

		private Rectangle rectangle_3 = default(Rectangle);

		private Rectangle rectangle_4 = default(Rectangle);

		private RibbonGroup ribbonGroup_0;

		private RibbonItemCollection ribbonItemCollection_0;

		private RibbonTextBox ribbonTextBox_0;

		private RibbonTextBox ribbonTextBox_1;

		private RibbonToolTip ribbonToolTip_0;

		private Size size_0;

		private Size size_1;

		private SizeF sizeF_0 = default(SizeF);

		private TextFormatFlags textFormatFlags_0 = TextFormatFlags.NoPrefix | TextFormatFlags.RightToLeft;

		private TextFormatFlags textFormatFlags_1 = TextFormatFlags.NoPrefix;

		private VisualStyleRenderer visualStyleRenderer_0;

		private Class561 class561_0;

		[Obfuscation(Exclude = true)]
		private static readonly object EventDownButtonClicked = new object();

		[Obfuscation(Exclude = true)]
		private static readonly object EventTextValidated = new object();

		[Obfuscation(Exclude = true)]
		private static readonly object EventUpButtonClicked = new object();

		[CompilerGenerated]
		private bool bool_9;

		[CompilerGenerated]
		private bool bool_10;

		[CompilerGenerated]
		private bool bool_11;

		[CompilerGenerated]
		private bool bool_12;

		/// <summary>Sets the RibbonTextBox's superordinate display settings and gets its corresponding text icon relation rendering to the current group's width.</summary>
		[Category("Appearance")]
		[DefaultValue(IconTextRelation.SmallIconLabeled)]
		public IconTextRelation DisplayMode
		{
			get
			{
				return this.iconTextRelation_1;
			}
			set
			{
				if (this.iconTextRelation_0 != (this.iconTextRelation_0 = value))
				{
					((IScalable)this).SetDisplayMode(this.iconTextRelation_0);
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether the RibbonTextBox changes its display mode when the related ribbon group is scaled by resizing the application.</summary>
		[Category("Behavior")]
		[DefaultValue(true)]
		public bool IsScalable
		{
			get
			{
				return this.bool_3;
			}
			set
			{
				if (this.bool_3 = (this.bool_3 = value))
				{
					this.ribbonGroup_0.method_2();
				}
			}
		}

		/// <summary>Gets or sets the keyboard shortcut of the RibbonTextBox.</summary>
		[Attribute3("PROP_RIBBON_KEYTIP")]
		[Category("Behavior")]
		public string KeyTip
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
			}
		}

		/// <summary>Gets or sets the text that is displayed before the text box.</summary>
		public string Label
		{
			get
			{
				return this.string_3;
			}
			set
			{
				if (this.string_3 != (this.string_3 = value))
				{
					this.bool_4 = this.string_3 != null && this.string_3.Length > 0;
					if (this.method_8() && this.ribbonGroup_0 != null)
					{
						this.ribbonGroup_0.method_2();
					}
					base.Invalidate();
				}
			}
		}

		/// <summary>Gets or sets a 32x32 1/96 inch icon for this RibbonTextBox.</summary>
		public System.Drawing.Image LargeIcon
		{
			get
			{
				return this.image_0;
			}
			set
			{
				if (this.image_0 != (this.image_0 = value) && this.iconTextRelation_1 == IconTextRelation.LargeIconLabeled)
				{
					base.Invalidate();
				}
			}
		}

		/// <summary>Gets the RibbonItemCollection that contains this RibbonTextBox.</summary>
		public RibbonItemCollection ParentCollection => this.ribbonItemCollection_0;

		/// <summary>Gets or sets the number of characters in the current selection in the text box.</summary>
		public int SelectionLength
		{
			get
			{
				return this.class562_0.SelectionLength;
			}
			set
			{
				this.class562_0.SelectionLength = value;
				if (this.ribbonTextBox_0 != null)
				{
					this.ribbonTextBox_0.class562_0.SelectionLength = value;
				}
			}
		}

		/// <summary>Gets or sets the starting position of the text selected in the text box</summary>
		public int SelectionStart
		{
			get
			{
				return this.class562_0.SelectionStart;
			}
			set
			{
				this.class562_0.SelectionStart = value;
				if (this.ribbonTextBox_0 != null)
				{
					this.ribbonTextBox_0.class562_0.SelectionStart = value;
				}
			}
		}

		/// <summary>Gets or sets the text of the current selection in the text box.</summary>
		public string SelectedText
		{
			get
			{
				return this.class562_0.SelectedText;
			}
			set
			{
				this.class562_0.SelectedText = value;
				if (this.ribbonTextBox_0 != null)
				{
					this.ribbonTextBox_0.class562_0.SelectedText = value;
				}
			}
		}

		/// <summary>Gets or sets a 16x16 1/96 inch icon for this RibbonTextBox.</summary>
		public System.Drawing.Image SmallIcon
		{
			get
			{
				return this.image_1;
			}
			set
			{
				if (this.image_1 != (this.image_1 = value) && (this.iconTextRelation_1 == IconTextRelation.SmallIconLabeled || this.iconTextRelation_1 == IconTextRelation.SmallIconUnlabeled))
				{
					base.Invalidate();
				}
			}
		}

		/// <summary>Gets or sets a value whether the text box's up down buttons are shown or not.</summary>
		public bool ShowUpDownButtons
		{
			get
			{
				return this.bool_6;
			}
			set
			{
				if (this.bool_6 != (this.bool_6 = value) && this.method_8() && this.ribbonGroup_0 != null)
				{
					this.ribbonGroup_0.method_2();
				}
			}
		}

		/// <summary>Gets or sets how text is aligned in the text box.</summary>
		public System.Windows.Forms.HorizontalAlignment TextAlign
		{
			get
			{
				return this.horizontalAlignment_0;
			}
			set
			{
				if (this.horizontalAlignment_0 != (this.horizontalAlignment_0 = value) && this.class562_0 != null)
				{
					this.class562_0.TextAlign = this.horizontalAlignment_0;
				}
			}
		}

		/// <summary>Gets or sets the text that is displayed behind the text box.</summary>
		public string TextBoxLabel
		{
			get
			{
				return this.string_6;
			}
			set
			{
				if (this.string_6 != (this.string_6 = value))
				{
					this.bool_7 = this.string_6 != null && this.string_6.Length > 0;
					if (this.method_8() && this.ribbonGroup_0 != null)
					{
						this.ribbonGroup_0.method_2();
					}
					base.Invalidate();
				}
			}
		}

		/// <summary>Gets or sets the width, in 1/96 inch, of the text box.</summary>
		public int TextBoxWidth
		{
			get
			{
				return this.int_2;
			}
			set
			{
				if (this.int_2 != (this.int_2 = value))
				{
					float float_ = (this.pointF_0.IsEmpty ? 96f : this.pointF_0.X);
					this.class562_0.Width = Class517.smethod_45(this.int_2, float_);
				}
			}
		}

		/// <summary>Gets an object of type RibbonToolTip that displays text when the mouse pointer hovers over the item.</summary>
		[Category("Misc")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public RibbonToolTip ToolTip => this.ribbonToolTip_0;

		/// <summary>Gets or sets the RibbonTextBox's input validation mode that is used to validate the inserted text in the text box.</summary>
		public InputValidationMode ValidationMode
		{
			get
			{
				return this.inputValidationMode_0;
			}
			set
			{
				this.inputValidationMode_0 = value;
			}
		}

		internal RibbonTextBox RibbonTextBox_0
		{
			get
			{
				return this.ribbonTextBox_0;
			}
			set
			{
				this.ribbonTextBox_0 = value;
			}
		}

		internal string String_0 => base.Name;

		internal string String_1
		{
			get
			{
				return this.string_5;
			}
			set
			{
				this.string_5 = value;
			}
		}

		internal Rectangle Rectangle_0 => this.rectangle_3;

		internal int? Nullable_0
		{
			get
			{
				return this.nullable_0;
			}
			set
			{
				this.nullable_0 = value;
				this.method_11(this.class562_0.Text, bool_13: false);
			}
		}

		public new bool CanSelect => true;

		protected override Padding DefaultMargin => new Padding(0);

		protected override Size DefaultSize => new Size(0, 0);

		public new bool Enabled
		{
			get
			{
				if (this.bool_5)
				{
					return base.Enabled;
				}
				return false;
			}
			set
			{
				base.Enabled = value;
			}
		}

		public override Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				this.color_0 = ((this.int_1 == 0) ? value : ControlPaint.LightLight(value));
				base.ForeColor = value;
			}
		}

		/// <summary>Overridden. Gets or sets the text that is inserted in the text box.</summary>
		public override string Text
		{
			get
			{
				return this.class562_0.Text;
			}
			set
			{
				this.method_11(value, bool_13: false);
				if (this.ribbonTextBox_0 != null)
				{
					this.ribbonTextBox_0.class562_0.Text = this.class562_0.Text;
				}
			}
		}

		public new bool Visible
		{
			get
			{
				return base.Visible;
			}
			set
			{
				bool internalVisible = (base.Visible = value);
				((IRibbonItem)this).InternalVisible = internalVisible;
			}
		}

		IRibbonItem IContentItem.Original
		{
			get
			{
				return this.ribbonTextBox_1;
			}
			set
			{
				this.ribbonTextBox_1 = (RibbonTextBox)value;
			}
		}

		PointF IRibbonItem.DPI => this.pointF_0;

		bool IRibbonItem.HasSmallIcon
		{
			[CompilerGenerated]
			get
			{
				return this.bool_9;
			}
			[CompilerGenerated]
			set
			{
				this.bool_9 = value;
			}
		}

		bool IRibbonItem.HasLargeIcon
		{
			[CompilerGenerated]
			get
			{
				return this.bool_10;
			}
			[CompilerGenerated]
			set
			{
				this.bool_10 = value;
			}
		}

		bool IRibbonItem.InternalVisible
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				if (this.bool_0 != (this.bool_0 = value) && !((IRibbonItem)this).IsRibbonDropDownItem)
				{
					Class517.smethod_25(this.ribbonGroup_0);
				}
			}
		}

		bool IRibbonItem.IsDefaultRibbonTabItem
		{
			[CompilerGenerated]
			get
			{
				return this.bool_11;
			}
			[CompilerGenerated]
			set
			{
				this.bool_11 = value;
			}
		}

		bool IRibbonItem.IsRibbonDropDownItem
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				this.bool_2 = value;
			}
		}

		bool IRibbonItem.IsUpdatingItemEnabled
		{
			[CompilerGenerated]
			get
			{
				return this.bool_12;
			}
			[CompilerGenerated]
			set
			{
				this.bool_12 = value;
			}
		}

		bool IRibbonItem.OwnerEnabled
		{
			get
			{
				return this.bool_5;
			}
			set
			{
				if (this.bool_5 != (this.bool_5 = value))
				{
					this.method_10();
				}
			}
		}

		RibbonGroup IRibbonItem.RibbonGroup
		{
			get
			{
				return this.ribbonGroup_0;
			}
			set
			{
				if (this.ribbonGroup_0 != (this.ribbonGroup_0 = value) && this.ribbonGroup_0 != null)
				{
					base.Font = this.ribbonGroup_0.Font;
					((IRibbonItem)this).IsUpdatingItemEnabled = true;
					if (this.ribbonGroup_0.Ribbon_0 != null)
					{
						this.class562_0.ReadOnly = this.ribbonGroup_0.Boolean_2;
					}
				}
			}
		}

		IconTextRelation IScalable.DefaultDisplayMode => this.iconTextRelation_0;

		/// <summary>Occurs as the text box's down button is clicked.</summary>
		public event EventHandler DownButtonClicked
		{
			add
			{
				base.Events.AddHandler(RibbonTextBox.EventDownButtonClicked, value);
			}
			remove
			{
				base.Events.RemoveHandler(RibbonTextBox.EventDownButtonClicked, value);
			}
		}

		/// <summary>Occurs when text box's text is validated.</summary>
		public event EventHandler TextValidated
		{
			add
			{
				base.Events.AddHandler(RibbonTextBox.EventTextValidated, value);
			}
			remove
			{
				base.Events.RemoveHandler(RibbonTextBox.EventTextValidated, value);
			}
		}

		/// <summary>Occurs as the text box's up button is clicked.</summary>
		public event EventHandler UpButtonClicked
		{
			add
			{
				base.Events.AddHandler(RibbonTextBox.EventUpButtonClicked, value);
			}
			remove
			{
				base.Events.RemoveHandler(RibbonTextBox.EventUpButtonClicked, value);
			}
		}

		/// <summary>Initializes a new instance of the RibbonTextBox class.</summary>
		public RibbonTextBox()
		{
			base.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			try
			{
				this.visualStyleRenderer_0 = new VisualStyleRenderer(VisualStyleElement.Button.GroupBox.Normal);
			}
			catch
			{
			}
			this.class562_0 = new Class562();
			this.class562_0.RibbonTextBox_0 = this;
			this.class562_0.TextAlign = this.horizontalAlignment_0;
			this.class562_0.SizeChanged += class562_0_SizeChanged;
			this.int_2 = (this.class562_0.Width = Class519.Class531.InternalTextBox.TextBoxWidth);
			this.class561_0 = new Class561(this);
			this.numberFormatInfo_0 = CultureInfo.CurrentCulture.NumberFormat;
			this.string_0 = this.numberFormatInfo_0.NumberDecimalSeparator;
			this.string_1 = this.numberFormatInfo_0.NumberGroupSeparator;
			this.string_4 = this.numberFormatInfo_0.NegativeSign;
			base.BackColor = Color.Transparent;
			this.color_0 = this.ForeColor;
			this.ribbonToolTip_0 = new RibbonToolTip(this);
			this.method_8();
		}

		private void method_0(Graphics graphics_0)
		{
			IconTextRelation iconTextRelation = this.iconTextRelation_1;
			if (iconTextRelation == IconTextRelation.LargeIconLabeled)
			{
				if (this.image_0 != null && this.iconTextRelation_1 == IconTextRelation.LargeIconLabeled)
				{
					graphics_0.DrawImage(this.image_0, this.rectangle_1, 0, 0, this.image_0.Width, this.image_0.Height, GraphicsUnit.Pixel, this.m_iaImageAttribute);
				}
			}
			else if (this.image_1 != null && (this.iconTextRelation_1 == IconTextRelation.SmallIconLabeled || this.iconTextRelation_1 == IconTextRelation.SmallIconUnlabeled))
			{
				graphics_0.DrawImage(this.image_1, this.rectangle_0, 0, 0, this.image_1.Width, this.image_1.Height, GraphicsUnit.Pixel, this.m_iaImageAttribute);
			}
			if (this.iconTextRelation_1 != IconTextRelation.SmallIconUnlabeled)
			{
				TextRenderer.DrawText(graphics_0, this.string_3, this.Font, this.rectangle_2, this.color_0, this.bool_1 ? this.textFormatFlags_0 : this.textFormatFlags_1);
			}
			TextRenderer.DrawText(graphics_0, this.string_6, this.Font, this.rectangle_4, this.color_0, this.bool_1 ? this.textFormatFlags_0 : this.textFormatFlags_1);
		}

		private int method_1()
		{
			IconTextRelation iconTextRelation = this.iconTextRelation_1;
			if (iconTextRelation == IconTextRelation.LargeIconLabeled)
			{
				if (this.bool_2)
				{
					return Math.Max(this.rectangle_1.Height + this.padding_1.Vertical, Math.Max(this.class562_0.Height + this.class562_0.Margin.Vertical, Math.Max(this.size_0.Height + this.padding_0.Vertical, this.size_1.Height + this.padding_4.Vertical)));
				}
				return Math.Max(this.class562_0.Height + this.class562_0.Margin.Vertical, Math.Max(this.size_0.Height + this.padding_0.Vertical, this.size_1.Height + this.padding_4.Vertical)) + this.rectangle_1.Height + this.padding_1.Vertical + 2;
			}
			return Math.Max(this.rectangle_0.Height + this.padding_2.Vertical, Math.Max(this.class562_0.Height + this.class562_0.Margin.Vertical, Math.Max(this.size_0.Height + this.padding_0.Vertical, this.size_1.Height + this.padding_4.Vertical)));
		}

		private Size method_2(string string_7)
		{
			if (!string.IsNullOrEmpty(string_7))
			{
				return TextRenderer.MeasureText(string_7, this.Font, new Size(1, 1), this.bool_1 ? this.textFormatFlags_0 : this.textFormatFlags_1);
			}
			return new Size(0, TextRenderer.MeasureText("A", this.Font, new Size(1, 1), this.bool_1 ? this.textFormatFlags_0 : this.textFormatFlags_1).Height);
		}

		private bool method_3(char char_0)
		{
			if (!char.IsNumber(char_0) && !char_0.ToString().Equals(this.string_4))
			{
				return char_0 == '\b';
			}
			return true;
		}

		private bool method_4(char char_0)
		{
			string text = char_0.ToString();
			if (!char.IsDigit(char_0) && !text.Equals(this.string_0) && !text.Equals(this.string_1) && !text.Equals(this.string_4) && char_0 != '\b')
			{
				return false;
			}
			return true;
		}

		internal bool method_5(char char_0)
		{
			switch (this.ValidationMode)
			{
			default:
				return false;
			case InputValidationMode.All:
				return true;
			case InputValidationMode.LettersOrDigits:
				if (!char.IsLetter(char_0))
				{
					return this.method_4(char_0);
				}
				return true;
			case InputValidationMode.OnlyLetters:
				return char.IsLetter(char_0);
			case InputValidationMode.OnlyDigits:
				return this.method_4(char_0);
			case InputValidationMode.OnlyIntegers:
				return this.method_3(char_0);
			}
		}

		internal void method_6()
		{
			this.class562_0.ClearUndo();
		}

		internal void method_7()
		{
			this.class562_0.Focus();
		}

		private bool method_8()
		{
			this.Dock = ((this.iconTextRelation_1 != IconTextRelation.LargeIconLabeled || this.bool_2) ? DockStyle.Top : DockStyle.Left);
			this.size_0 = this.method_2(this.string_3);
			this.size_1 = this.method_2(this.string_6);
			if (!base.Controls.Contains(this.class562_0))
			{
				base.Controls.Add(this.class562_0);
			}
			return this.method_9();
		}

		private bool method_9()
		{
			float num = this.sizeF_0.Width;
			SizeF sizeF = (this.sizeF_0 = ((IRibbonItem)this).GetSize(this.iconTextRelation_1));
			bool result = num != sizeF.Width;
			this.bool_8 = false;
			this.MinimumSize = this.sizeF_0.ToSize();
			this.bool_8 = true;
			if (base.Width > 0)
			{
				switch (this.iconTextRelation_1)
				{
				case IconTextRelation.LargeIconLabeled:
				{
					int num2;
					int num3;
					int num4;
					int num5;
					if (this.bool_2)
					{
						num2 = (this.bool_1 ? (base.Width - this.rectangle_1.Width - this.padding_1.Left) : this.padding_1.Left);
						num3 = (int)this.sizeF_0.Width / 2 - this.rectangle_1.Height / 2;
						num4 = (this.bool_1 ? (base.Width - this.rectangle_1.Width - this.padding_1.Horizontal - this.padding_0.Left - this.size_0.Width) : (this.rectangle_1.Width + this.padding_1.Horizontal + this.padding_0.Left));
						num5 = (int)this.sizeF_0.Height / 2 - this.size_0.Height / 2;
					}
					else
					{
						num2 = (int)this.sizeF_0.Width / 2 - this.rectangle_1.Width / 2;
						num3 = this.padding_1.Top;
						num4 = (this.bool_1 ? (base.Width - this.padding_0.Left - this.size_0.Width) : this.padding_0.Left);
						num5 = this.rectangle_1.Height + this.padding_1.Vertical + this.padding_0.Top;
					}
					this.rectangle_1 = new Rectangle(new Point(num2, num3), this.rectangle_1.Size);
					this.rectangle_2 = new Rectangle(new Point(num4, num5), this.size_0);
					break;
				}
				default:
				{
					int num2 = (this.bool_1 ? (base.Width - this.rectangle_0.Width - this.padding_2.Horizontal) : this.padding_2.Left);
					int num3 = (int)this.sizeF_0.Height / 2 - this.rectangle_0.Height / 2;
					int num4 = (this.bool_1 ? (base.Width - this.rectangle_0.Width - this.padding_2.Horizontal - this.padding_0.Left - this.size_0.Width) : (this.rectangle_0.Width + this.padding_2.Horizontal + this.padding_0.Left));
					int num5 = (int)this.sizeF_0.Height / 2 - this.size_0.Height / 2;
					this.rectangle_0 = new Rectangle(new Point(num2, num3), this.rectangle_0.Size);
					this.rectangle_2 = new Rectangle(new Point(num4, num5), this.size_0);
					break;
				}
				case IconTextRelation.NoIconLabeled:
					this.rectangle_2 = new Rectangle(new Point(this.padding_0.Left, (int)this.sizeF_0.Height / 2 - this.size_0.Height / 2), this.size_0);
					break;
				}
				int num6 = (this.bool_1 ? this.padding_4.Right : (base.Width - this.size_1.Width - this.padding_4.Horizontal));
				int num7 = (this.bool_1 ? (-this.class561_0.Int32_0) : this.class561_0.Int32_0);
				num6 -= (this.bool_6 ? num7 : 0);
				this.rectangle_4 = (this.bool_7 ? new Rectangle(new Point(num6, this.rectangle_2.Y), this.size_1) : new Rectangle(new Point(num6, 0), this.size_1));
				int num8 = ((this.iconTextRelation_1 != IconTextRelation.LargeIconLabeled || this.bool_2) ? ((int)this.sizeF_0.Height / 2 - this.class562_0.Height / 2) : (this.rectangle_1.Height + this.padding_1.Vertical + (((int)this.sizeF_0.Height - this.rectangle_1.Height - this.padding_1.Vertical) / 2 - this.class562_0.Height / 2)));
				num7 = ((this.bool_1 && this.bool_6) ? this.class561_0.Int32_0 : 0);
				int num9 = (this.bool_1 ? (this.padding_4.Right + this.size_1.Width + this.class562_0.Margin.Right + num7) : (this.rectangle_4.X - this.class562_0.Margin.Horizontal - this.class562_0.Width));
				this.point_0 = new Point(num9, num8);
				this.class562_0.Location = this.point_0;
				int num10 = this.class562_0.Bounds.Width + this.padding_3.Horizontal + this.size_1.Width + this.padding_4.Horizontal;
				num10 += (this.bool_6 ? (this.class561_0.Int32_0 + this.class562_0.Margin.Horizontal) : 0);
				int num11 = ((!this.bool_1) ? (this.class562_0.Bounds.X - this.padding_3.Left) : 0);
				this.rectangle_3 = new Rectangle(num11, this.class562_0.Bounds.Y - this.padding_3.Top, num10, this.class562_0.Bounds.Height + this.padding_3.Vertical);
				if (this.bool_6)
				{
					this.class561_0.method_3();
				}
			}
			return result;
		}

		private void method_10()
		{
			this.int_1 = ((!this.Enabled) ? 65 : 0);
			this.color_0 = (this.Enabled ? this.ForeColor : ControlPaint.LightLight(this.ForeColor));
			this.m_iaImageAttribute = Class517.smethod_20(this.int_1);
		}

		internal void method_11(string string_7, bool bool_13)
		{
			bool flag = true;
			if (string_7 != null && string_7.Length > 0)
			{
				switch (this.inputValidationMode_0)
				{
				case InputValidationMode.All:
					this.class562_0.Text = string_7;
					break;
				case InputValidationMode.LettersOrDigits:
					foreach (char c in string_7)
					{
						if (!char.IsLetter(c) && !this.method_4(c))
						{
							this.class562_0.Text = this.string_5;
							flag = false;
							break;
						}
					}
					if (flag)
					{
						this.class562_0.Text = string_7;
					}
					break;
				case InputValidationMode.OnlyLetters:
					foreach (char c2 in string_7)
					{
						if (!char.IsLetter(c2))
						{
							this.class562_0.Text = this.string_5;
							flag = false;
							break;
						}
					}
					if (flag)
					{
						this.class562_0.Text = string_7;
					}
					break;
				case InputValidationMode.OnlyDigits:
				{
					if (decimal.TryParse(string_7, NumberStyles.Any, CultureInfo.CurrentCulture, out var result2))
					{
						this.class562_0.Text = (this.nullable_0.HasValue ? result2.ToString("F" + this.nullable_0.Value) : result2.ToString("F"));
					}
					else
					{
						this.class562_0.Text = this.string_5;
					}
					break;
				}
				case InputValidationMode.OnlyIntegers:
				{
					if (int.TryParse(string_7, out var result))
					{
						this.class562_0.Text = result.ToString();
					}
					else
					{
						this.class562_0.Text = this.string_5;
					}
					break;
				}
				}
				if (this.ribbonTextBox_1 != null)
				{
					this.ribbonTextBox_1.Text = this.class562_0.Text;
				}
			}
			else
			{
				this.class562_0.Text = string_7;
			}
			if (bool_13)
			{
				this.method_13();
			}
		}

		protected override AccessibleObject CreateAccessibilityInstance()
		{
			return new Control13(this);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				((IContentItem)this).ToolTip.Dispose();
				this.class562_0.Dispose();
				if (this.image_1 != null)
				{
					this.image_1.Dispose();
				}
				if (this.image_0 != null)
				{
					this.image_0.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		protected override void OnEnabledChanged(EventArgs eventArgs_0)
		{
			this.method_10();
			base.OnEnabledChanged(eventArgs_0);
		}

		protected override void OnFontChanged(EventArgs eventArgs_0)
		{
			this.ribbonToolTip_0.Font_0 = base.Font;
			base.OnFontChanged(eventArgs_0);
		}

		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			if (mevent.Button == MouseButtons.Left && this.bool_6 && this.class561_0.Boolean_1 && !this.ribbonGroup_0.Boolean_2)
			{
				this.class561_0.method_0();
			}
			this.ribbonToolTip_0.method_2();
			base.OnMouseDown(mevent);
		}

		protected override void OnMouseEnter(EventArgs eventargs)
		{
			Point? point = Class517.smethod_21(this);
			this.ribbonToolTip_0.method_3(point, base.Width, this.ribbonToolTip_0.Control_0, this.pointF_0);
			if (eventargs != null)
			{
				base.OnMouseEnter(eventargs);
			}
		}

		protected override void OnMouseLeave(EventArgs eventargs)
		{
			if (this.bool_6)
			{
				this.class561_0.method_2();
				this.class561_0.method_4(default(Point));
				base.Invalidate();
			}
			this.ribbonToolTip_0.method_2();
			base.OnMouseLeave(eventargs);
		}

		protected override void OnMouseMove(MouseEventArgs mevent)
		{
			if (this.bool_6 && this.class561_0.method_4(mevent.Location))
			{
				base.Invalidate();
			}
			base.OnMouseMove(mevent);
		}

		protected override void OnPaint(PaintEventArgs pea)
		{
			if (this.visualStyleRenderer_0 != null)
			{
				this.visualStyleRenderer_0.DrawBackground(pea.Graphics, new Rectangle(this.rectangle_3.Location, new Size(this.rectangle_3.Width + this.int_0, this.rectangle_3.Height)));
			}
			this.method_0(pea.Graphics);
			if (this.bool_6)
			{
				this.class561_0.method_1(pea.Graphics);
			}
			base.OnPaint(pea);
		}

		protected override void OnRightToLeftChanged(EventArgs eventArgs_0)
		{
			if (this.bool_1 != (this.bool_1 = (this.ribbonGroup_0 != null && this.ribbonGroup_0.RightToLeft == RightToLeft.Yes) || this.RightToLeft == RightToLeft.Yes))
			{
				this.method_9();
			}
			base.OnRightToLeftChanged(eventArgs_0);
		}

		protected override void OnSizeChanged(EventArgs eventArgs_0)
		{
			base.OnSizeChanged(eventArgs_0);
			if (this.bool_8)
			{
				this.method_8();
			}
			base.Height = (int)this.sizeF_0.Height;
		}

		protected override void WndProc(ref Message message)
		{
			Class429.Enum121 msg = (Class429.Enum121)message.Msg;
			if (msg != Class429.Enum121.const_56)
			{
				base.WndProc(ref message);
			}
		}

		void IRibbonItem.AwareOfDPI(PointF dpi)
		{
			if (dpi.X != this.pointF_0.X || dpi.Y != this.pointF_0.Y)
			{
				float num = ((this.pointF_0.X > 0f) ? (dpi.X / this.pointF_0.X) : 1f);
				this.pointF_0 = dpi;
				this.int_0 = Class517.smethod_45(Class519.Class531.Int32_0, dpi.X);
				this.padding_0 = Class517.smethod_51(Class519.Class531.Padding_0, dpi);
				this.padding_1 = Class517.smethod_51(Class519.Class531.Padding_1, dpi);
				this.padding_2 = Class517.smethod_51(Class519.Class531.Padding_2, dpi);
				this.padding_3 = Class517.smethod_51(Class519.Class531.Padding_3, dpi);
				this.padding_4 = Class517.smethod_51(Class519.Class531.Padding_4, dpi);
				this.rectangle_0 = Class517.smethod_50(Class519.Class531.Rectangle_0, dpi);
				this.rectangle_1 = Class517.smethod_50(Class519.Class531.Rectangle_1, dpi);
				this.point_0 = Class517.smethod_49(Class519.Class531.Point_0, dpi);
				this.size_0 = Class517.smethod_48(Class519.Class531.Size_0, dpi);
				this.rectangle_1 = Class517.smethod_50(Class519.Class531.Rectangle_1, dpi);
				this.rectangle_0 = Class517.smethod_50(Class519.Class531.Rectangle_0, dpi);
				this.size_1 = Class517.smethod_48(Class519.Class531.Size_1, dpi);
				base.Margin = Class517.smethod_51(Class519.Class523.Padding_3, dpi);
				this.bool_8 = false;
				base.Width = (int)((float)base.Width * num);
				this.class562_0.Width = Class517.smethod_45(this.int_2, dpi.X);
				this.bool_8 = true;
				this.method_8();
			}
		}

		SizeF IRibbonItem.GetSize(IconTextRelation scaleMode)
		{
			int num = this.method_1();
			int num2 = 0;
			switch (scaleMode)
			{
			case IconTextRelation.LargeIconLabeled:
				if (this.bool_2)
				{
					num2 = this.rectangle_1.Width + this.padding_1.Horizontal + this.size_0.Width + this.padding_0.Horizontal + this.class562_0.Width + this.class562_0.Margin.Horizontal;
					num2 += (this.bool_7 ? (this.size_1.Width + this.padding_4.Horizontal) : this.padding_4.Horizontal);
					num2 += (this.bool_6 ? this.class561_0.Int32_0 : 0);
					return new Size(num2, num);
				}
				num2 = this.size_0.Width + this.padding_0.Horizontal + this.class562_0.Width + this.class562_0.Margin.Horizontal;
				num2 += (this.bool_7 ? (this.size_1.Width + this.padding_4.Horizontal) : this.padding_4.Horizontal);
				num2 += (this.bool_6 ? this.class561_0.Int32_0 : 0);
				return new Size(Math.Max(num2, this.rectangle_1.Width + this.padding_1.Horizontal), num);
			case IconTextRelation.NoIconLabeled:
				num2 = this.size_0.Width + this.padding_0.Horizontal + this.class562_0.Width + this.class562_0.Margin.Horizontal;
				num2 += (this.bool_7 ? (this.size_1.Width + this.padding_4.Horizontal) : this.padding_4.Horizontal);
				num2 += (this.bool_6 ? this.class561_0.Int32_0 : 0);
				return new Size(num2, num);
			case IconTextRelation.SmallIconUnlabeled:
				num2 = this.rectangle_0.Width + this.padding_2.Horizontal + this.class562_0.Width + this.class562_0.Margin.Horizontal;
				num2 += (this.bool_7 ? (this.size_1.Width + this.padding_4.Horizontal) : this.padding_4.Horizontal);
				num2 += (this.bool_6 ? this.class561_0.Int32_0 : 0);
				return new Size(num2, num);
			default:
				return this.sizeF_0;
			case IconTextRelation.SmallIconLabeled:
				num2 = this.rectangle_0.Width + this.padding_2.Horizontal + this.size_0.Width + this.padding_0.Horizontal + this.class562_0.Width + this.class562_0.Margin.Horizontal;
				num2 += (this.bool_7 ? (this.size_1.Width + this.padding_4.Horizontal) : this.padding_4.Horizontal);
				num2 += (this.bool_6 ? this.class561_0.Int32_0 : 0);
				return new Size(num2, num);
			}
		}

		void IRibbonItem.ParentVisibleChanged(bool isVisible)
		{
		}

		void IRibbonItem.PerformStandardKeyboardAction()
		{
			this.class562_0.Focus();
		}

		void IRibbonItem.SetDropDownItemSize()
		{
			DockStyle dock = base.Dock;
			base.Dock = DockStyle.None;
			base.Size = ((IRibbonItem)this).GetSize(this.iconTextRelation_1).ToSize();
			base.Dock = dock;
		}

		void IRibbonItem.SetParentCollection(RibbonItemCollection parentCollection)
		{
			this.ribbonItemCollection_0 = parentCollection;
		}

		void IScalable.SetDisplayMode(IconTextRelation value)
		{
			this.iconTextRelation_1 = value;
			this.method_8();
			base.Width = (int)this.sizeF_0.Width;
		}

		private void class562_0_SizeChanged(object sender, EventArgs e)
		{
			if (this.method_8() && this.ribbonGroup_0 != null)
			{
				this.ribbonGroup_0.method_2();
			}
		}

		internal void method_12()
		{
			((EventHandler)base.Events[RibbonTextBox.EventDownButtonClicked])?.Invoke(this, new EventArgs());
		}

		internal void method_13()
		{
			((EventHandler)base.Events[RibbonTextBox.EventTextValidated])?.Invoke(this, new EventArgs());
		}

		internal void method_14()
		{
			((EventHandler)base.Events[RibbonTextBox.EventUpButtonClicked])?.Invoke(this, new EventArgs());
		}
	}
}
