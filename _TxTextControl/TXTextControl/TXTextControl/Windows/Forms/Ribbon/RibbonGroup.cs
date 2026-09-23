using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns21;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>The RibbonGroup class represents a logical group of controls as they appear on a RibbonTab and is the base class of the HorizontalRibbonGroup class.</summary>
	[ToolboxItem(false)]
	public class RibbonGroup : Panel, IEnabledItem, IRibbonToolStripItemProvider
	{
		internal bool bool_0;

		private bool bool_1 = true;

		private bool bool_2 = true;

		internal bool bool_3;

		internal bool bool_4 = true;

		internal bool bool_5 = true;

		internal int int_0 = 200;

		internal int int_1 = 125;

		internal int int_2 = 3;

		private System.Drawing.Image image_0;

		protected internal Color m_colTextColor;

		private ContextMenuStrip contextMenuStrip_0;

		protected internal ResourceManager m_rm = new ResourceManager(typeof(TextControlCore));

		private Ribbon ribbon_0;

		internal RibbonGroup ribbonGroup_0;

		internal Class498 class498_0;

		internal Class515 class515_0;

		internal RibbonItemCollection ribbonItemCollection_0;

		internal Class514 class514_0;

		internal RibbonMenuButton ribbonMenuButton_0;

		private Class560 class560_0;

		internal Class560 class560_1;

		internal ToolStripItem toolStripItem_0;

		internal HorizontalAlignment horizontalAlignment_0 = HorizontalAlignment.Left;

		private List<IRibbonToolStripItemProvider> list_0 = new List<IRibbonToolStripItemProvider>();

		[CompilerGenerated]
		private bool bool_6;

		/// <summary>Gets an object of type DialogBoxLauncher which represents the RibbonGroup's dialog box launcher item.</summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Behavior")]
		public DialogBoxLauncher DialogBoxLauncher => this.class515_0.DialogBoxLauncher_0;

		/// <summary>Gets or sets the ribbon group's horizontal content alignment.</summary>
		[DefaultValue(HorizontalAlignment.Left)]
		[Category("Appearance")]
		public HorizontalAlignment HorizontalContentAlignment
		{
			get
			{
				return this.horizontalAlignment_0;
			}
			set
			{
				if (value != HorizontalAlignment.Justify && this.horizontalAlignment_0 != (this.horizontalAlignment_0 = value) && this.class560_1 != null)
				{
					this.vmethod_0(this.class560_1, bool_7: false);
				}
			}
		}

		/// <summary>Gets or sets a value whether the RibbonGroup can be added to the quick access toolbar.</summary>
		[DefaultValue(true)]
		[Category("Behavior")]
		public bool IsAddToQuickAccessToolbarEnabled
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

		/// <summary>Gets or sets the keyboard shortcut of the RibbonGroup.</summary>
		[Attribute3("PROP_RIBBON_KEYTIP")]
		[Category("Behavior")]
		public string KeyTip
		{
			get
			{
				return this.ribbonMenuButton_0.KeyTip;
			}
			set
			{
				this.ribbonMenuButton_0.KeyTip = value;
			}
		}

		/// <summary>Gets or sets an icon for this RibbonGroup.</summary>
		[DefaultValue(null)]
		[Category("Appearance")]
		public System.Drawing.Image LargeIcon
		{
			get
			{
				return this.ribbonMenuButton_0.LargeIcon;
			}
			set
			{
				this.ribbonMenuButton_0.LargeIcon = value;
			}
		}

		/// <summary>Gets a collection of all items contained in this group.</summary>
		[Category("Behavior")]
		public RibbonItemCollection RibbonItems => this.ribbonItemCollection_0;

		/// <summary>Gets or sets the number of rows in the RibbonGroup.</summary>
		[Category("Behavior")]
		public int RowCount
		{
			get
			{
				return this.int_2;
			}
			set
			{
				if (this.int_2 != (this.int_2 = value))
				{
					if (this.int_2 < 0 || this.int_2 > 3)
					{
						throw new ArgumentException(this.m_rm.GetString("ERR_ROWCOUNT"));
					}
					this.method_2();
				}
			}
		}

		/// <summary>Gets or sets a value whether the RibbonGroup's seperator is shown.</summary>
		[Category("Appearance")]
		[DefaultValue(null)]
		public bool ShowSeperator
		{
			get
			{
				return this.bool_5;
			}
			set
			{
				if (this.bool_5 != (this.bool_5 = value))
				{
					base.Invalidate();
				}
			}
		}

		/// <summary>Gets or sets a 16x16 1/96 inch icon for this RibbonGroup.</summary>
		[DefaultValue(null)]
		[Category("Appearance")]
		public System.Drawing.Image SmallIcon
		{
			get
			{
				return this.image_0;
			}
			set
			{
				System.Drawing.Image image2 = (this.image_0 = (this.ribbonMenuButton_0.SmallIcon = value));
				if (this.toolStripItem_0 != null)
				{
					Class517.smethod_57(this.toolStripItem_0, value, this.class498_0.PointF_0);
				}
			}
		}

		/// <summary>Gets an object of type RibbonToolTip that displays text when the mouse pointer hovers over this RibbonGroup.</summary>
		[Category("Misc")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public RibbonToolTip ToolTip => this.ribbonMenuButton_0.ToolTip;

		internal List<IRibbonToolStripItemProvider> List_0 => this.list_0;

		internal bool Boolean_0 => this.bool_0;

		internal ContextMenuStrip ContextMenuStrip_0 => this.contextMenuStrip_0;

		internal PointF PointF_0 => this.class498_0.PointF_0;

		internal Class515 Class515_0 => this.class515_0;

		internal string String_0 => base.Name;

		internal bool Boolean_1
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				if (this.bool_1 == (this.bool_1 = value) || this.class498_0 == null)
				{
					return;
				}
				Class517.smethod_25(this);
				((IRibbonItem)this.ribbonMenuButton_0).OwnerEnabled = value;
				foreach (IRibbonItem item in this.ribbonItemCollection_0)
				{
					item.OwnerEnabled = value;
				}
			}
		}

		internal bool Boolean_2
		{
			get
			{
				if (this.Class498_0 != null && this.Class498_0.Control_0 is MiniToolbar)
				{
					return (this.Class498_0.Control_0 as MiniToolbar).Boolean_2;
				}
				if (this.Ribbon_0 != null)
				{
					return this.Ribbon_0.ReadOnly;
				}
				return false;
			}
		}

		internal Class514 Class514_0 => this.class514_0;

		internal Ribbon Ribbon_0
		{
			get
			{
				if (this.ribbon_0 == null && this.Class498_0 != null)
				{
					RibbonTab ribbonTab = ((this.ribbonGroup_0 == null) ? (this.Class498_0.Control_0 as RibbonTab) : (this.ribbonGroup_0.Class498_0.Control_0 as RibbonTab));
					if (ribbonTab != null)
					{
						this.ribbon_0 = ribbonTab.Parent as Ribbon;
					}
				}
				return this.ribbon_0;
			}
		}

		internal Class498 Class498_0
		{
			get
			{
				return this.class498_0;
			}
			set
			{
				this.class498_0 = value;
			}
		}

		internal RibbonMenuButton RibbonMenuButton_0 => this.ribbonMenuButton_0;

		internal Class560 Class560_0 => this.class560_0;

		internal Color Color_0 => this.m_colTextColor;

		internal bool Boolean_3
		{
			[CompilerGenerated]
			get
			{
				return this.bool_6;
			}
			[CompilerGenerated]
			set
			{
				this.bool_6 = value;
			}
		}

		protected override Padding DefaultMargin => Class519.Class523.Padding_0;

		protected override Size DefaultMinimumSize => Class519.Class523.Size_0;

		protected override Padding DefaultPadding => Class519.Class523.Padding_1;

		protected override Size DefaultSize => Class519.Class523.Size_1;

		public new bool Visible
		{
			get
			{
				return base.Visible;
			}
			set
			{
				bool boolean_ = (base.Visible = value);
				this.Boolean_1 = boolean_;
			}
		}

		bool IEnabledItem.Enabled
		{
			get
			{
				return base.Enabled;
			}
			set
			{
				base.Enabled = value;
			}
		}

		ToolStripItem IRibbonToolStripItemProvider.ToolStripItem
		{
			get
			{
				if (this.toolStripItem_0 == null)
				{
					this.toolStripItem_0 = ((this.ribbonMenuButton_0 != null) ? new Class564(this.ribbonMenuButton_0) : new Class564(new RibbonMenuButton()));
					Class517.smethod_57(this.toolStripItem_0, this.image_0, this.class498_0.PointF_0);
					((Class564)this.toolStripItem_0).ShowDropDownArrow = false;
					((IRibbonToolStripItemProvider)this.ribbonMenuButton_0).ToolStripItem = this.toolStripItem_0;
				}
				if (this.class515_0.Boolean_1)
				{
					this.class515_0.Boolean_1 = false;
					return this.class515_0.DialogBoxLauncher_0.ToolStripItem_0;
				}
				return this.toolStripItem_0;
			}
			set
			{
			}
		}

		bool IRibbonToolStripItemProvider.IsToolStripItemAdded
		{
			get
			{
				bool result = false;
				if (this.class515_0.Boolean_1)
				{
					result = (this.class515_0.DialogBoxLauncher_0.ToolStripItem_0 as IRibbonToolStripItem).IsToolStripItemAdded;
				}
				else if (this.toolStripItem_0 != null)
				{
					result = (this.toolStripItem_0 as IRibbonToolStripItem).IsToolStripItemAdded;
				}
				return result;
			}
		}

		/// <summary>Initializes a new instance of the RibbonGroup class.</summary>
		public RibbonGroup()
		{
			this.ribbonMenuButton_0 = new RibbonMenuButton(this);
			((IRibbonItem)this.ribbonMenuButton_0).RibbonGroup = this;
			this.ribbonMenuButton_0.Dock = DockStyle.Fill;
			this.bool_0 = true;
			this.ribbonMenuButton_0.Visible = false;
			this.bool_0 = false;
			this.ribbonMenuButton_0.Boolean_2 = true;
			this.Intialize(this);
			this.class515_0 = new Class515(this);
		}

		internal RibbonGroup(RibbonGroup parent)
		{
			base.Font = parent.Font;
			this.bool_3 = true;
			this.Intialize(parent);
			this.toolStripItem_0 = ((IRibbonToolStripItemProvider)parent).ToolStripItem;
			this.Class498_0 = parent.Class498_0;
			this.class515_0 = new Class515(this);
			Class517.smethod_3(parent.Class515_0, this.class515_0);
			Class517.smethod_3(parent.Class515_0.DialogBoxLauncher_0, this.class515_0.DialogBoxLauncher_0);
			this.class515_0.DialogBoxLauncher_0.ToolStripItem_0 = parent.Class515_0.DialogBoxLauncher_0.ToolStripItem_0;
			this.class515_0.method_0(parent.PointF_0);
			base.Text = parent.Text;
		}

		internal static int smethod_0(Font font_0, int int_3, PointF pointF_0, bool bool_7)
		{
			double num = RibbonButton.smethod_0(font_0, pointF_0);
			double num2 = Class517.smethod_45(2, pointF_0.Y);
			double num3 = ((!bool_7) ? Class515.smethod_0(font_0, pointF_0.Y) : 0.0);
			double num4 = Class517.smethod_45(Class519.Class523.Padding_1.Vertical, pointF_0.Y);
			return (int)(num * (double)int_3 + num2 + num3 + num4);
		}

		internal virtual void vmethod_0(Class560 class560_2, bool bool_7)
		{
			this.class560_1 = class560_2;
			this.bool_0 = true;
			this.class514_0.Controls.Clear();
			this.class514_0.RowCount = 8;
			this.class514_0.RowStyles.Clear();
			this.MinimumSize = new Size(Class517.smethod_33(this, !class560_2.Boolean_0), Class517.smethod_32(this));
			if (!class560_2.Boolean_0)
			{
				this.SetRowStyles(this.int_2);
				if (!bool_7)
				{
					this.ribbonMenuButton_0.Visible = false;
					this.class514_0.SetRowSpan(this.ribbonMenuButton_0, 1);
				}
				this.class514_0.ColumnCount = Math.Max(3, class560_2.Class557_0.Length + 2);
				this.class514_0.ColumnStyles.Clear();
				int num = ((this.HorizontalContentAlignment == HorizontalAlignment.Center) ? 50 : ((this.HorizontalContentAlignment != HorizontalAlignment.Left) ? 100 : 0));
				this.class514_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, num));
				for (int i = 0; i < class560_2.Class557_0.Length; i++)
				{
					this.class514_0.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
					for (int j = 0; j < this.int_2; j++)
					{
						Class559 @class;
						if ((@class = class560_2.Class557_0[i].Class559_0[j]) == null)
						{
							break;
						}
						Control control;
						if (bool_7)
						{
							Type type = @class.IRibbonItem_0.GetType();
							control = (Control)Activator.CreateInstance(type);
							Class517.smethod_3((Control)@class.IRibbonItem_0, control);
							if (control is IRibbonItem)
							{
								(control as IRibbonItem).AwareOfDPI(this.class498_0.PointF_0);
							}
						}
						else
						{
							control = (Control)@class.IRibbonItem_0;
						}
						IScalable scalable;
						if ((scalable = control as IScalable) != null)
						{
							scalable.SetDisplayMode(@class.IconTextRelation_0);
						}
						bool flag = control is RibbonListView;
						bool flag2 = @class.IconTextRelation_0 == IconTextRelation.LargeIconLabeled;
						int value = (flag ? 7 : ((!flag2) ? 1 : 7));
						int int_ = ((!flag2 && !flag) ? (j * 2 + 1) : 0);
						if (flag)
						{
							control = new RibbonListView.Class554(control);
						}
						this.method_0(this.class514_0, control, i + 1, int_);
						this.class514_0.SetRowSpan(control, value);
					}
				}
				int num2 = ((this.HorizontalContentAlignment == HorizontalAlignment.Center) ? 50 : ((this.HorizontalContentAlignment != HorizontalAlignment.Right) ? 100 : 0));
				this.class514_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, num2));
				this.bool_4 = true;
			}
			else
			{
				this.bool_4 = false;
				this.class514_0.ColumnCount = 1;
				this.class514_0.ColumnStyles.Clear();
				this.class514_0.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
				this.ribbonMenuButton_0.Visible = true;
				this.class514_0.Controls.Add(this.ribbonMenuButton_0, 0, 0);
				this.class514_0.SetRowSpan(this.ribbonMenuButton_0, 8);
			}
			this.bool_0 = false;
		}

		internal void method_0(Class514 class514_1, Control control_0, int int_3, int int_4)
		{
			int val = control_0.Width;
			class514_1.Controls.Add(control_0, int_3, int_4);
			control_0.Width = Math.Max(val, control_0.Width);
		}

		internal void method_1()
		{
			Class517.smethod_0(this.class498_0.PointF_0);
			((IRibbonItem)this.ribbonMenuButton_0).AwareOfDPI(this.class498_0.PointF_0);
			this.class515_0.method_0(this.class498_0.PointF_0);
		}

		internal virtual RibbonGroup vmethod_1()
		{
			RibbonGroup ribbonGroup = new RibbonGroup(this);
			ribbonGroup.RowCount = this.int_2;
			ribbonGroup.RightToLeft = this.RightToLeft;
			ribbonGroup.horizontalAlignment_0 = this.horizontalAlignment_0;
			ribbonGroup.Padding = Class517.smethod_51(Class519.Class523.Padding_2, this.class498_0.PointF_0);
			ribbonGroup.vmethod_0(this.Class560_0, bool_7: true);
			Size size3 = (ribbonGroup.MinimumSize = (ribbonGroup.Size = new Size(Class517.smethod_33(this, bool_0: true), base.Height)));
			return ribbonGroup;
		}

		internal void method_2()
		{
			this.method_3(this.Visible && !this.bool_0 && !this.bool_3);
		}

		internal void method_3(bool bool_7)
		{
			Class498 @class;
			if (bool_7 && base.Parent != null && (@class = (Class498)base.Parent.Parent) != null && @class.Boolean_0)
			{
				this.method_5();
				@class.method_5();
				@class.method_7(@class.Width);
			}
		}

		protected virtual void Intialize(RibbonGroup parent)
		{
			this.m_colTextColor = ((!base.Enabled) ? Color.FromArgb(this.int_1, parent.ForeColor) : Color.FromArgb(this.int_0, parent.ForeColor));
			this.ribbonItemCollection_0 = new RibbonItemCollection(parent);
			this.ribbonGroup_0 = parent;
			base.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			base.BackColor = Color.Transparent;
			base.AutoSize = true;
			base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			base.Dock = DockStyle.Left;
			this.class514_0 = new Class514(DockStyle.Fill, 1, this.int_2 + 1, parent, this, bool_1: false);
			base.Controls.Add(this.class514_0);
		}

		internal void method_4()
		{
			Class560 @class = new Class560(this);
			@class.method_2();
			this.class560_0 = @class;
		}

		internal void method_5()
		{
			List<Class560> list = new List<Class560>();
			Class560 @class = new Class560(this);
			bool flag;
			if (!(flag = @class.method_2()))
			{
				list.Add(@class);
			}
			else
			{
				while (flag)
				{
					list.Add(@class);
					Class560 class2 = new Class560(this);
					if (flag = class2.method_7(@class))
					{
						@class.Class560_0 = class2;
						@class = class2;
					}
				}
			}
			if (this.ribbonMenuButton_0 != null && !(this is Class497))
			{
				Class560 class2 = new Class560(this);
				class2.method_6();
				list.Add(class2);
				@class.Class560_0 = class2;
			}
			this.class560_0 = list[0];
		}

		protected void SetRowStyles(int rows)
		{
			switch (rows)
			{
			default:
			{
				for (int i = 0; i < 7; i++)
				{
					this.class514_0.RowStyles.Add(new RowStyle(SizeType.AutoSize));
				}
				break;
			}
			case 1:
				this.class514_0.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
				this.class514_0.RowStyles.Add(new RowStyle(SizeType.AutoSize));
				this.class514_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 0f));
				this.class514_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 0f));
				this.class514_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 0f));
				this.class514_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 0f));
				this.class514_0.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
				break;
			case 2:
				this.class514_0.RowStyles.Add(new RowStyle(SizeType.Percent, 45f));
				this.class514_0.RowStyles.Add(new RowStyle(SizeType.AutoSize));
				this.class514_0.RowStyles.Add(new RowStyle(SizeType.Percent, 10f));
				this.class514_0.RowStyles.Add(new RowStyle(SizeType.AutoSize));
				this.class514_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 0f));
				this.class514_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 0f));
				this.class514_0.RowStyles.Add(new RowStyle(SizeType.Percent, 45f));
				break;
			case 3:
				this.class514_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 0f));
				this.class514_0.RowStyles.Add(new RowStyle(SizeType.AutoSize));
				this.class514_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 0f));
				this.class514_0.RowStyles.Add(new RowStyle(SizeType.AutoSize));
				this.class514_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 0f));
				this.class514_0.RowStyles.Add(new RowStyle(SizeType.AutoSize));
				this.class514_0.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
				break;
			}
			int num = ((!(this.Class498_0.Control_0 is MiniToolbar)) ? this.class515_0.Size_0.Height : 0);
			this.class514_0.RowStyles.Add(new RowStyle(SizeType.Absolute, num));
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.toolStripItem_0 != null)
				{
					this.toolStripItem_0.Dispose();
				}
				if (this.image_0 != null)
				{
					this.image_0.Dispose();
				}
				if (this.ribbonMenuButton_0 != null)
				{
					this.ribbonMenuButton_0.Dispose();
				}
				this.class515_0.DialogBoxLauncher_0.Dispose();
			}
			base.Dispose(disposing);
		}

		protected override void OnEnabledChanged(EventArgs eventArgs_0)
		{
			foreach (IRibbonItem item in this.ribbonItemCollection_0)
			{
				item.OwnerEnabled = base.Enabled;
			}
			this.m_colTextColor = ((!base.Enabled) ? Color.FromArgb(this.int_1, this.ForeColor) : Color.FromArgb(this.int_0, this.ForeColor));
			this.class515_0.DialogBoxLauncher_0.Enabled = base.Enabled;
			base.OnEnabledChanged(eventArgs_0);
		}

		protected override void OnFontChanged(EventArgs eventArgs_0)
		{
			if (this.ribbonItemCollection_0 != null)
			{
				foreach (Control item in this.ribbonItemCollection_0)
				{
					try
					{
						item.Font = base.Font;
					}
                    catch { }
				}
			}
			if (this.ribbonMenuButton_0 != null)
			{
				this.ribbonMenuButton_0.Font = base.Font;
			}
			if (this.class515_0 != null)
			{
				this.class515_0.DialogBoxLauncher_0.ToolTip.Font_0 = base.Font;
			}
			base.OnFontChanged(eventArgs_0);
		}

		protected override void OnForeColorChanged(EventArgs eventArgs_0)
		{
			this.m_colTextColor = ((!base.Enabled) ? Color.FromArgb(this.int_1, this.ForeColor) : Color.FromArgb(this.int_0, this.ForeColor));
			base.OnForeColorChanged(eventArgs_0);
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			base.OnHandleCreated(eventArgs_0);
			RibbonTab ribbonTab = ((this.ribbonGroup_0 == null) ? (this.Class498_0.Control_0 as RibbonTab) : (this.ribbonGroup_0.Class498_0.Control_0 as RibbonTab));
			if (ribbonTab != null)
			{
				this.ribbon_0 = ribbonTab.Parent as Ribbon;
				if (this.ContextMenuStrip == null)
				{
					this.ContextMenuStrip = ribbonTab.ContextMenuStrip_0;
				}
				this.contextMenuStrip_0 = this.ContextMenuStrip;
				if (this.class515_0.DialogBoxLauncher_0.ContextMenuStrip == null)
				{
					this.class515_0.DialogBoxLauncher_0.ContextMenuStrip = ribbonTab.ContextMenuStrip_0;
				}
			}
		}

		protected override void OnPaint(PaintEventArgs pea)
		{
			pea.Graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			base.OnPaint(pea);
			if (this.bool_5)
			{
				try
				{
					int num = 1;
					int num2 = ((this.RightToLeft != RightToLeft.Yes) ? (base.Width - num) : 0);
					pea.Graphics.DrawLine(new Pen(Ribbon.smethod_0()[6], num), new Point(num2, 0), new Point(num2, base.Height));
				}
				catch
				{
				}
			}
			if (this.bool_4 && !(this.Class498_0.Control_0 is MiniToolbar))
			{
				this.class515_0.method_1(pea.Graphics);
			}
		}

		protected override void OnPaddingChanged(EventArgs eventArgs_0)
		{
			base.MinimumSize = new Size(base.MinimumSize.Width, Class517.smethod_32(this));
			base.OnPaddingChanged(eventArgs_0);
		}

		protected override void OnSizeChanged(EventArgs eventArgs_0)
		{
			base.OnSizeChanged(eventArgs_0);
			this.class515_0.method_2();
		}

		protected override void OnTextChanged(EventArgs eventArgs_0)
		{
			if (this.ribbonGroup_0 == null)
			{
				this.toolStripItem_0.Text = base.Text;
			}
			this.class515_0.method_3();
			if (this.ribbonMenuButton_0 != null)
			{
				this.ribbonMenuButton_0.Text = base.Text;
			}
			base.OnTextChanged(eventArgs_0);
		}

		protected override void OnVisibleChanged(EventArgs eventArgs_0)
		{
			if (this.Visible && this.Boolean_3)
			{
				Class517.smethod_25(this);
				this.Boolean_3 = false;
			}
			foreach (Control ribbonItem in this.RibbonItems)
			{
				(ribbonItem as IRibbonItem).ParentVisibleChanged(base.Visible);
			}
			base.OnVisibleChanged(eventArgs_0);
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
