using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ns21;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>The RibbonTab class represents a tab in a Ribbon.</summary>
	[Designer("TXTextControl.Windows.Forms.Ribbon.RibbonTabDesigner, TXTextControl.Design.dll, Version=29.0.113.500, Culture=neutral, PublicKeyToken=17fff8a774004c66")]
	[ToolboxBitmap(typeof(RibbonTab))]
	[ToolboxItem(true)]
	public class RibbonTab : TabPage
	{
		private Color[] color_0 = new Color[7];

		internal Class498 class498_0;

		private bool bool_0 = true;

		private uint uint_0;

		private string string_0 = string.Empty;

		private bool bool_1 = true;

		private TextControl textControl_0;

		private int int_0 = -1;

		[CompilerGenerated]
		private bool bool_2;

		protected override Padding DefaultMargin => new Padding(0);

		protected override Padding DefaultPadding => new Padding(0);

		protected override Size DefaultSize => new Size(200, 40);

		/// <summary>Gets or sets the keyboard shortcut of the RibbonTab.</summary>
		[Category("Behavior")]
		[Attribute3("PROP_RIBBON_KEYTIP")]
		public virtual string KeyTip
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}

		/// <summary>Gets a collection of all RibbonGroups in a RibbonTab.</summary>
		[Category("Layout")]
		[Attribute3("PROP_RIBBON_RIBBONGROUPS")]
		public RibbonGroupCollection RibbonGroups => this.class498_0.RibbonGroupCollection_0;

		internal ContextMenuStrip ContextMenuStrip_0
		{
			get
			{
				Ribbon ribbon = base.Parent as Ribbon;
				return ((ribbon != null) ? (ribbon.Parent as RibbonForm) : null)?.contextMenuStrip_0;
			}
		}

		internal bool Boolean_0
		{
			[CompilerGenerated]
			get
			{
				return this.bool_2;
			}
			[CompilerGenerated]
			set
			{
				this.bool_2 = value;
			}
		}

		internal bool Boolean_1
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
			}
		}

		internal virtual TextControl TextControl_0
		{
			get
			{
				return this.textControl_0;
			}
			set
			{
				this.textControl_0 = value;
			}
		}

		internal int Int32_0
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}

		/// <summary>Initializes a new instance of the RibbonTab class.</summary>
		public RibbonTab()
		{
			this.bool_0 = VisualStyleRenderer.IsSupported;
			if (this.bool_0)
			{
				base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			}
			this.color_0 = Ribbon.smethod_0();
			this.class498_0 = new Class498(this);
			base.Controls.Add(this.class498_0);
		}

		protected override void OnPaint(PaintEventArgs pea)
		{
			if (this.bool_0)
			{
				Rectangle clientRectangle = base.ClientRectangle;
				Ribbon ribbon = base.Parent as Ribbon;
				Color color = ribbon?.DisplayColors.HighlightTabColor ?? this.color_0[1];
				Color color2 = ribbon?.DisplayColors.TabColor ?? this.color_0[0];
				LinearGradientBrush brush = new LinearGradientBrush(clientRectangle, color, color2, LinearGradientMode.Vertical);
				pea.Graphics.FillRectangle(brush, clientRectangle);
			}
		}

		internal virtual void vmethod_0(params object[] object_0)
		{
		}

		internal PointF method_0()
		{
			PointF result = this.class498_0.PointF_0;
			if (result.IsEmpty && base.IsHandleCreated)
			{
				Graphics graphics = base.CreateGraphics();
				result = new PointF(graphics.DpiX, graphics.DpiY);
				graphics.Dispose();
			}
			return result;
		}

		internal virtual void vmethod_1(uint uint_1)
		{
			if (uint_1 != 0)
			{
				this.class498_0.PointF_0 = new PointF(uint_1, uint_1);
				return;
			}
			Graphics graphics = base.CreateGraphics();
			this.class498_0.PointF_0 = new PointF(graphics.DpiX, graphics.DpiY);
			graphics.Dispose();
		}

		internal void method_1(bool bool_3)
		{
			foreach (RibbonGroup ribbonGroup in this.RibbonGroups)
			{
				ribbonGroup.method_5();
			}
			if (bool_3)
			{
				this.vmethod_0();
			}
			this.class498_0.method_5();
			this.class498_0.method_7(this.class498_0.Width);
		}

		protected override void WndProc(ref Message message)
		{
			switch (message.Msg)
			{
			default:
				base.WndProc(ref message);
				break;
			case 738:
			{
				uint num = Class429.smethod_15(message.HWnd);
				Font font = this.Font;
				Font font3 = (this.Font = new Font(font.FontFamily, font.SizeInPoints * (float)num / (float)this.uint_0, font.Style, GraphicsUnit.Point, font.GdiCharSet, font.GdiVerticalFont));
				this.vmethod_1(this.uint_0 = num);
				this.method_1(this.textControl_0 != null && this == (base.Parent as Ribbon).SelectedTab);
				break;
			}
			case 1:
				this.uint_0 = ((base.Parent is Ribbon) ? (base.Parent as Ribbon).uint_0 : Class429.smethod_15(message.HWnd));
				this.class498_0.PointF_0 = new PointF(this.uint_0, this.uint_0);
				base.WndProc(ref message);
				break;
			}
		}
	}
}
