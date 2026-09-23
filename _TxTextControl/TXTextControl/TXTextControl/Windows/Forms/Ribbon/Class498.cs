using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ns21;
using TXTextControl;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class498 : Panel
	{
		internal class Class499 : TableLayoutPanel
		{
			internal Class499()
			{
				base.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
				base.BackColor = Color.Transparent;
				base.AutoSize = true;
				base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
				base.Padding = new Padding(0);
				base.Margin = new Padding(0);
				base.Dock = DockStyle.Fill;
				base.RowCount = 1;
				base.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
				base.ColumnCount = 0;
				base.ColumnStyles.Clear();
				base.BackColor = Color.Transparent;
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

		internal class Control12 : Control
		{
			internal enum Enum136
			{
				const_0,
				const_1
			}

			private int int_0;

			private int int_1;

			private bool bool_0;

			private bool bool_1;

			private Class499 class499_0;

			private Class498 class498_0;

			private Enum136 enum136_0;

			private VisualStyleRenderer visualStyleRenderer_0;

			private VisualStyleRenderer visualStyleRenderer_1;

			private VisualStyleRenderer visualStyleRenderer_2;

			private VisualStyleRenderer visualStyleRenderer_3;

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

			internal int Int32_1
			{
				get
				{
					return this.int_1;
				}
				set
				{
					this.int_1 = value;
				}
			}

			internal bool Boolean_0
			{
				get
				{
					return base.Visible;
				}
				set
				{
					base.Visible = value && this.method_0();
				}
			}

			internal Control12(Enum136 enum136_1)
			{
				this.enum136_0 = enum136_1;
				try
				{
					this.visualStyleRenderer_0 = (this.visualStyleRenderer_2 = ((enum136_1 == Enum136.const_1) ? new VisualStyleRenderer(VisualStyleElement.Spin.DownHorizontal.Normal) : new VisualStyleRenderer(VisualStyleElement.Spin.UpHorizontal.Normal)));
					this.visualStyleRenderer_1 = ((enum136_1 == Enum136.const_1) ? new VisualStyleRenderer(VisualStyleElement.Spin.DownHorizontal.Hot) : new VisualStyleRenderer(VisualStyleElement.Spin.UpHorizontal.Hot));
					this.visualStyleRenderer_3 = ((enum136_1 == Enum136.const_1) ? new VisualStyleRenderer(VisualStyleElement.Spin.DownHorizontal.Pressed) : new VisualStyleRenderer(VisualStyleElement.Spin.UpHorizontal.Pressed));
				}
				catch
				{
				}
			}

			private bool method_0()
			{
				int num = this.class499_0.Location.X;
				if (this.enum136_0 == Enum136.const_0)
				{
					return num + this.int_1 > this.int_0;
				}
				return num < 0;
			}

			private void method_1()
			{
				int num = this.class499_0.Height;
				int num2 = this.class499_0.Location.X;
				int num3 = ((this.enum136_0 != 0) ? Math.Min(num2 + this.int_0, 0) : Math.Max(num2 - this.int_0, this.int_0 - this.int_1));
				this.class499_0.Dock = DockStyle.None;
				this.class499_0.MinimumSize = new Size(1, num);
				this.class499_0.Location = new Point(num3, 0);
				this.class498_0.method_9(this.int_1, bool_1: true);
				this.class498_0.Invalidate();
			}

			protected override void OnMouseDown(MouseEventArgs mevent)
			{
				this.visualStyleRenderer_0 = this.visualStyleRenderer_3;
				this.bool_1 = true;
				this.method_1();
				base.OnMouseDown(mevent);
				base.Invalidate();
			}

			protected override void OnMouseEnter(EventArgs eventargs)
			{
				if (!this.bool_1)
				{
					this.visualStyleRenderer_0 = this.visualStyleRenderer_1;
				}
				this.bool_0 = true;
				base.OnMouseEnter(eventargs);
				base.Invalidate();
			}

			protected override void OnMouseLeave(EventArgs eventargs)
			{
				if (!this.bool_1)
				{
					this.visualStyleRenderer_0 = this.visualStyleRenderer_2;
				}
				this.bool_0 = false;
				base.OnMouseLeave(eventargs);
				base.Invalidate();
			}

			protected override void OnMouseUp(MouseEventArgs mevent)
			{
				this.visualStyleRenderer_0 = (this.bool_0 ? this.visualStyleRenderer_1 : this.visualStyleRenderer_2);
				this.bool_1 = false;
				base.OnMouseUp(mevent);
				base.Invalidate();
			}

			protected override void OnPaint(PaintEventArgs pea)
			{
				if (this.visualStyleRenderer_0 != null)
				{
					this.visualStyleRenderer_0.DrawBackground(pea.Graphics, new Rectangle(0, 0, base.Width, base.Height));
				}
				base.OnPaint(pea);
			}

			protected override void OnParentChanged(EventArgs eventArgs_0)
			{
				if (base.Parent != null)
				{
					this.class498_0 = (Class498)base.Parent;
					this.class499_0 = this.class498_0.Class499_0;
				}
				base.OnParentChanged(eventArgs_0);
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

		private bool bool_0;

		private PointF pointF_0 = PointF.Empty;

		private Class499 class499_0 = new Class499();

		private RibbonGroupCollection ribbonGroupCollection_0;

		private Control control_0;

		private Class556 class556_0;

		private Class556[] class556_1 = new Class556[0];

		private Control12 control12_0 = new Control12(Control12.Enum136.const_0);

		private Control12 control12_1 = new Control12(Control12.Enum136.const_1);

		protected override Padding DefaultPadding => new Padding(0);

		protected override Padding DefaultMargin => new Padding(0);

		internal PointF PointF_0
		{
			get
			{
				return this.pointF_0;
			}
			set
			{
				if (this.pointF_0.X != value.X || this.pointF_0.Y != value.Y)
				{
					this.pointF_0 = value;
				}
			}
		}

		internal Class499 Class499_0 => this.class499_0;

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

		internal RibbonGroupCollection RibbonGroupCollection_0 => this.ribbonGroupCollection_0;

		internal Control Control_0 => this.control_0;

		protected override bool ScaleChildren => false;

		public Class498(Control control_1)
		{
			this.control_0 = control_1;
			this.method_6();
		}

		internal void method_0(PointF pointF_1)
		{
			if (this.pointF_0.X != pointF_1.X || this.pointF_0.Y != pointF_1.Y)
			{
				this.pointF_0 = pointF_1;
				int num3 = (this.control12_1.Width = (this.control12_0.Width = Class517.smethod_45(Class519.Class522.Int32_0, this.pointF_0.X)));
			}
		}

		private Class560[] method_1()
		{
			List<Class560> list = new List<Class560>();
			foreach (RibbonGroup item in this.ribbonGroupCollection_0)
			{
				if (item.Boolean_1)
				{
					if (item.Class560_0 == null)
					{
						item.method_4();
					}
					list.Add(item.Class560_0);
				}
			}
			return list.ToArray();
		}

		private Class556 method_2(Class556 class556_2)
		{
			int num = -1;
			Class560 @class = null;
			for (int i = 0; i < class556_2.Class560_0.Length; i++)
			{
				Class560 class560_ = class556_2.Class560_0[i].Class560_0;
				if (class560_ != null && (@class == null || class560_.Int32_1 < @class.Int32_1))
				{
					@class = class560_;
					num = i;
				}
			}
			if (@class != null)
			{
				Class560[] array = new Class560[class556_2.Class560_0.Length];
				for (int j = 0; j < class556_2.Class560_0.Length; j++)
				{
					if (j != num)
					{
						array[j] = class556_2.Class560_0[j];
					}
					else
					{
						array[j] = @class;
					}
				}
				return new Class556(class556_2.Int32_0, array, bool_1: false);
			}
			return null;
		}

		internal void method_3(int int_0)
		{
			if (!this.bool_0)
			{
				return;
			}
			foreach (RibbonGroup item in this.ribbonGroupCollection_0)
			{
				if (item.Boolean_1)
				{
					item.method_5();
				}
			}
			this.method_5();
			this.method_7(int_0);
		}

		internal void method_4()
		{
			foreach (RibbonGroup item in this.ribbonGroupCollection_0)
			{
				if (item.Boolean_3)
				{
					item.method_4();
				}
				item.Boolean_3 = false;
			}
			Class560[] class560_ = this.method_1();
			Class556 class556_ = new Class556(int.MaxValue, class560_, bool_1: false);
			this.method_8(class556_);
		}

		internal void method_5()
		{
			Class560[] class560_ = this.method_1();
			Class556 @class = new Class556(int.MaxValue, class560_, bool_1: false);
			List<Class556> list = new List<Class556>();
			list.Add(@class);
			while (@class != null)
			{
				if ((@class = this.method_2(@class)) != null)
				{
					list.Add(@class);
				}
			}
			int index = list.Count - 1;
			Class556 item = new Class556(list[index].Int32_0, list[index].Class560_0, bool_1: true);
			list.Add(item);
			this.class556_1 = list.ToArray();
		}

		private void method_6()
		{
			base.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			base.AutoSize = true;
			base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			base.Dock = DockStyle.Fill;
			base.BackColor = Color.Transparent;
			base.Controls.Add(this.class499_0);
			this.control12_0.Boolean_0 = false;
			base.Controls.Add(this.control12_0);
			this.control12_1.Location = new Point(0, 0);
			this.control12_1.Boolean_0 = false;
			base.Controls.Add(this.control12_1);
			this.ribbonGroupCollection_0 = new RibbonGroupCollection(this);
		}

		internal void method_7(int int_0)
		{
			for (int i = 0; i < this.class556_1.Length; i++)
			{
				Class556 @class = this.class556_1[i];
				if (@class.Int32_1 >= int_0 && int_0 > @class.Int32_0)
				{
					this.method_8(@class);
					break;
				}
			}
			if (this.RightToLeft == RightToLeft.Yes)
			{
				this.class499_0.Location = new Point(int_0 - this.class499_0.Location.X, this.class499_0.Location.Y);
			}
		}

		private void method_8(Class556 class556_2)
		{
			if (this.class556_0 == null)
			{
				this.class556_0 = class556_2;
				Class560[] class560_ = this.class556_0.Class560_0;
				foreach (Class560 @class in class560_)
				{
					@class.RibbonGroup_0.vmethod_0(@class, bool_7: false);
				}
				return;
			}
			for (int j = 0; j < class556_2.Class560_0.Length; j++)
			{
				if (class556_2.Class560_0.Length != this.class556_0.Class560_0.Length || class556_2.Class560_0[j] != this.class556_0.Class560_0[j])
				{
					class556_2.Class560_0[j].RibbonGroup_0.vmethod_0(class556_2.Class560_0[j], bool_7: false);
				}
			}
			this.method_9(class556_2.Int32_1, class556_2.Boolean_0);
			this.class556_0 = class556_2;
		}

		internal void method_9(int int_0, bool bool_1)
		{
			int num = base.Width - this.control12_0.Int32_0;
			bool flag = num > 0;
			this.control12_0.Int32_0 = base.Width;
			this.control12_0.Int32_1 = int_0;
			this.control12_0.Boolean_0 = bool_1;
			this.control12_1.Int32_0 = base.Width;
			this.control12_1.Int32_1 = int_0;
			this.control12_1.Boolean_0 = bool_1;
			if (!this.control12_0.Boolean_0 && !this.control12_1.Boolean_0)
			{
				this.class499_0.Dock = DockStyle.Fill;
			}
			else if (flag && this.control12_1.Boolean_0 && !this.control12_0.Boolean_0)
			{
				this.class499_0.Location = new Point(this.class499_0.Location.X + num, this.class499_0.Location.Y);
			}
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			if (base.Parent is MiniToolbar)
			{
				return;
			}
			uint num = 0u;
			Control control = base.Parent;
			while (control != null)
			{
				if (!(control is Ribbon))
				{
					if (!(control is RibbonDropDown))
					{
						control = control.Parent;
						continue;
					}
					num = (control as RibbonDropDown).uint_0;
					break;
				}
				num = (control as Ribbon).uint_0;
				break;
			}
			base.OnHandleCreated(eventArgs_0);
			this.bool_0 = true;
			PointF pointF_;
			if (num == 0)
			{
				Graphics graphics = base.CreateGraphics();
				pointF_ = new PointF(graphics.DpiX, graphics.DpiY);
				graphics.Dispose();
			}
			else
			{
				pointF_ = new PointF(num, num);
			}
			this.method_0(pointF_);
			this.method_3(base.Width);
		}

		protected override void OnPaint(PaintEventArgs pea)
		{
			base.OnPaint(pea);
			if (this.ribbonGroupCollection_0.Count <= 0 || !(this.ribbonGroupCollection_0[0] is Class497))
			{
				if (this.control12_0.Boolean_0)
				{
					this.control12_0.Location = new Point(base.Width - this.control12_0.Width, 0);
					this.control12_0.BringToFront();
				}
				if (this.control12_1.Boolean_0)
				{
					this.control12_1.BringToFront();
				}
			}
		}

		protected override void OnSizeChanged(EventArgs eventArgs_0)
		{
			if (base.Parent != null && !(base.Parent is MiniToolbar))
			{
				if (this.bool_0)
				{
					this.method_7(base.Width);
				}
				int num3 = (this.control12_0.Height = (this.control12_1.Height = base.Height));
			}
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
}
