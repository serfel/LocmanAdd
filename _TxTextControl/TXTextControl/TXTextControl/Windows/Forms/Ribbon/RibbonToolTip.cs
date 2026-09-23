using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>The RibbonToolTip class represents a small rectangular pop-up window that displays the title and/or a brief description of a ribbon item's purpose when the user rests the pointer on the control.</summary>
	[ToolboxItem(false)]
	public class RibbonToolTip : Component
	{
		internal class Class567 : ToolTip
		{
			private bool bool_0;

			private Control control_0;

			private Point? nullable_0;

			private RibbonToolTip ribbonToolTip_0;

			private Timer timer_0 = new Timer();

			private VisualStyleRenderer visualStyleRenderer_0;

			internal Class567(RibbonToolTip ribbonToolTip_1)
			{
				try
				{
					this.visualStyleRenderer_0 = new VisualStyleRenderer(VisualStyleElement.ToolTip.Standard.Normal);
				}
				catch
				{
				}
				this.bool_0 = LicenseManager.UsageMode == LicenseUsageMode.Designtime;
				this.ribbonToolTip_0 = ribbonToolTip_1;
				base.OwnerDraw = true;
				base.IsBalloon = false;
				base.Draw += Class567_Draw;
				base.Popup += Class567_Popup;
				this.timer_0.Tick += timer_0_Tick;
			}

			internal void method_0()
			{
				this.timer_0.Enabled = false;
				if (this.control_0 != null)
				{
					base.Hide(this.control_0);
				}
			}

			private void method_1(Graphics graphics_0, Rectangle rectangle_0)
			{
				if (this.visualStyleRenderer_0 != null)
				{
					this.visualStyleRenderer_0.DrawBackground(graphics_0, rectangle_0);
				}
				else
				{
					graphics_0.FillRectangle(new SolidBrush(SystemColors.Window), rectangle_0);
				}
				TextRenderer.DrawText(graphics_0, this.ribbonToolTip_0.Title, this.ribbonToolTip_0.Font_1, this.ribbonToolTip_0.Rectangle_1, SystemColors.ControlText, this.ribbonToolTip_0.TextFormatFlags_1);
				TextRenderer.DrawText(graphics_0, this.ribbonToolTip_0.Description, this.ribbonToolTip_0.Font_0, this.ribbonToolTip_0.Rectangle_0, SystemColors.ControlText, this.ribbonToolTip_0.TextFormatFlags_0);
			}

			internal void method_2(Point? nullable_1, Control control_1)
			{
				if (!this.bool_0)
				{
					this.control_0 = control_1;
					this.timer_0.Enabled = true;
					this.timer_0.Interval = 500;
					this.nullable_0 = nullable_1;
					this.timer_0.Start();
				}
			}

			private void timer_0_Tick(object sender, EventArgs e)
			{
				Point point;
				if (this.nullable_0.HasValue)
				{
					point = this.nullable_0.Value;
				}
				else
				{
					point = this.control_0.PointToClient(Control.MousePosition);
					point.Offset(0, 20);
				}
				base.Show("Dummy", this.control_0, point);
				this.timer_0.Enabled = false;
			}

			private void Class567_Draw(object sender, DrawToolTipEventArgs e)
			{
				this.method_1(e.Graphics, e.Bounds);
			}

			private void Class567_Popup(object sender, PopupEventArgs e)
			{
				this.ribbonToolTip_0.method_4();
				e.ToolTipSize = this.ribbonToolTip_0.Size_0;
			}
		}

		private bool bool_0;

		private bool bool_1;

		private bool bool_2;

		private bool bool_3;

		private int int_0;

		private int int_1;

		private string string_0 = "";

		private string string_1 = "";

		private Control control_0;

		private PointF pointF_0 = PointF.Empty;

		private Size size_0;

		private Size size_1;

		private Size size_2;

		private Rectangle rectangle_0;

		private Rectangle rectangle_1;

		private Font font_0;

		private Font font_1;

		private Padding padding_0;

		private Padding padding_1;

		private Class567 class567_0;

		private TextFormatFlags textFormatFlags_0 = TextFormatFlags.NoPrefix | TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak;

		private TextFormatFlags textFormatFlags_1 = TextFormatFlags.NoPrefix | TextFormatFlags.RightToLeft | TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak;

		private TextFormatFlags textFormatFlags_2 = TextFormatFlags.NoPrefix;

		private TextFormatFlags textFormatFlags_3 = TextFormatFlags.NoPrefix | TextFormatFlags.RightToLeft;

		[Obfuscation(Exclude = true)]
		private static readonly object OpeningEvent = new object();

		/// <summary>Gets or sets the description for the RibbonToolTip window.</summary>
		[Category("Appearance")]
		[DefaultValue("")]
		public string Description
		{
			get
			{
				return this.string_0;
			}
			set
			{
				if (this.string_0 != (this.string_0 = value))
				{
					this.method_1();
				}
			}
		}

		/// <summary>Gets or sets the title for the RibbonToolTip window.</summary>
		[DefaultValue("")]
		[Category("Appearance")]
		public string Title
		{
			get
			{
				return this.string_1;
			}
			set
			{
				if (this.string_1 != (this.string_1 = value))
				{
					this.method_1();
					this.class567_0.ToolTipTitle = this.string_1;
				}
			}
		}

		internal Rectangle Rectangle_0 => this.rectangle_0;

		internal TextFormatFlags TextFormatFlags_0
		{
			get
			{
				if (!this.Boolean_0)
				{
					return this.textFormatFlags_0;
				}
				return this.textFormatFlags_1;
			}
		}

		internal Font Font_0
		{
			get
			{
				return this.font_0;
			}
			set
			{
				if (this.font_0 != (this.font_0 = value))
				{
					this.font_1 = new Font(this.font_0, FontStyle.Bold);
					this.method_1();
				}
			}
		}

		internal Font Font_1
		{
			get
			{
				if (!this.bool_0)
				{
					return this.font_0;
				}
				return this.font_1;
			}
		}

		internal Control Control_0
		{
			get
			{
				return this.control_0;
			}
			set
			{
				this.control_0 = value;
			}
		}

		internal bool Boolean_0
		{
			get
			{
				if (this.control_0 is IRibbonItem)
				{
					if ((this.control_0 as IRibbonItem).RibbonGroup != null && (this.control_0 as IRibbonItem).RibbonGroup.RightToLeft == RightToLeft.Yes)
					{
						return true;
					}
					return this.control_0.RightToLeft == RightToLeft.Yes;
				}
				if (this.control_0 is RibbonGroup && (this.control_0 as RibbonGroup).Class498_0 != null)
				{
					return (this.control_0 as RibbonGroup).Class498_0.Control_0.RightToLeft == RightToLeft.Yes;
				}
				return false;
			}
		}

		internal Rectangle Rectangle_1 => this.rectangle_1;

		internal TextFormatFlags TextFormatFlags_1
		{
			get
			{
				if (!this.Boolean_0)
				{
					return this.textFormatFlags_2;
				}
				return this.textFormatFlags_3;
			}
		}

		internal bool Boolean_1 => this.bool_3;

		internal Size Size_0
		{
			get
			{
				int width = 0;
				int height = 0;
				if (this.bool_2)
				{
					width = (this.bool_1 ? (this.size_2.Width + this.padding_1.Horizontal) : (this.size_1.Width + this.padding_0.Horizontal));
					int num = (this.bool_1 ? (this.size_2.Height + this.padding_1.Vertical) : 0);
					int num2 = (this.bool_0 ? (this.size_1.Height + this.padding_0.Vertical) : 0);
					height = num + num2;
				}
				return new Size(width, height);
			}
		}

		/// <summary>Occurs as the the RibbonToolTip window is opening.</summary>
		public event EventHandler Opening
		{
			add
			{
				base.Events.AddHandler(RibbonToolTip.OpeningEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(RibbonToolTip.OpeningEvent, value);
			}
		}

		internal RibbonToolTip()
		{
			this.class567_0 = new Class567(this);
		}

		internal RibbonToolTip(Control parent)
		{
			this.control_0 = parent;
			this.Font_0 = parent.Font;
			this.class567_0 = new Class567(this);
		}

		protected override void Dispose(bool disposing)
		{
			this.class567_0.Dispose();
			base.Dispose(disposing);
		}

		private void method_0(PointF pointF_1)
		{
			if (this.pointF_0.X != pointF_1.X || this.pointF_0.Y != pointF_1.Y)
			{
				this.pointF_0 = pointF_1;
				this.size_0 = Class517.smethod_48(Class519.Class541.Size_0, this.pointF_0);
				this.int_0 = Class517.smethod_45(Class519.Class541.Int32_0, this.pointF_0.Y);
				this.int_1 = Class517.smethod_45(Class519.Class541.Int32_1, this.pointF_0.Y);
				this.padding_0 = Class517.smethod_51(Class519.Class541.Padding_0, this.pointF_0);
				this.padding_1 = Class517.smethod_51(Class519.Class541.Padding_1, this.pointF_0);
				this.method_1();
			}
		}

		private void method_1()
		{
			this.bool_1 = this.string_1 != null && this.string_1.Length > 0;
			this.bool_0 = this.string_0 != null && this.string_0.Length > 0;
			this.bool_2 = this.bool_1 || this.bool_0;
			if (this.bool_2)
			{
				if (this.bool_1)
				{
					this.size_2 = TextRenderer.MeasureText(this.string_1, this.Font_1, new Size(this.size_0.Width, this.int_0), this.TextFormatFlags_1);
					this.size_2 = (this.bool_0 ? new Size(Math.Max(this.size_0.Width - this.padding_1.Horizontal, this.size_2.Width), this.size_2.Height) : this.size_2);
				}
				if (this.bool_0)
				{
					int width = (this.bool_1 ? (this.size_2.Width + this.padding_1.Horizontal - this.padding_0.Horizontal) : this.size_0.Width);
					this.size_1 = TextRenderer.MeasureText(this.string_0, this.font_0, new Size(width, this.int_1), this.TextFormatFlags_0);
					this.size_1 = (this.bool_1 ? new Size(this.size_2.Width + this.padding_1.Horizontal - this.padding_0.Horizontal, this.size_1.Height) : this.size_1);
				}
				int y = (this.bool_1 ? (this.padding_1.Top + this.size_2.Height + this.padding_0.Top) : this.padding_0.Top);
				if (this.Boolean_0)
				{
					Size size = this.Size_0;
					this.rectangle_1 = new Rectangle(size.Width - this.padding_1.Right - this.size_2.Width, this.padding_1.Top, this.size_2.Width, this.size_2.Height);
					this.rectangle_0 = new Rectangle(size.Width - this.padding_0.Right - this.size_1.Width, y, this.size_1.Width, this.size_1.Height);
				}
				else
				{
					this.rectangle_1 = new Rectangle(this.padding_1.Left, this.padding_1.Top, this.size_2.Width, this.size_2.Height);
					this.rectangle_0 = new Rectangle(this.padding_0.Left, y, this.size_1.Width, this.size_1.Height);
				}
			}
		}

		internal void method_2()
		{
			if (this.bool_2)
			{
				this.bool_3 = false;
				this.class567_0.method_0();
			}
		}

		internal void method_3(Point? nullable_0, int int_2, Control control_1, PointF pointF_1)
		{
			if (this.bool_2)
			{
				this.Font_0 = control_1.Font;
				this.method_0(pointF_1);
				this.bool_3 = true;
				if (this.Boolean_0 && nullable_0.HasValue)
				{
					this.class567_0.method_2(new Point(nullable_0.Value.X + int_2 - this.Size_0.Width, nullable_0.Value.Y), control_1);
				}
				else
				{
					this.class567_0.method_2(nullable_0, control_1);
				}
			}
		}

		internal void method_4()
		{
			EventHandler eventHandler = (EventHandler)base.Events[RibbonToolTip.OpeningEvent];
			if (eventHandler != null)
			{
				EventArgs e = new EventArgs();
				eventHandler(this, e);
			}
		}
	}
}
