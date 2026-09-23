using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ns21;
using ns27;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>The RibbonForm class represents a Windows Forms form that can draw a Ribbon Quick Access Toolbar and contextual tabs in its border.</summary>
	public class RibbonForm : Form
	{
		public new class ControlCollection : Control.ControlCollection
		{
			private RibbonForm ribbonForm_0;

			public ControlCollection(RibbonForm owner)
				: base(owner)
			{
				this.ribbonForm_0 = owner;
			}

			public override void Add(Control value)
			{
				if (base.Contains(value))
				{
					return;
				}
				if (value is Ribbon)
				{
					if (this.ribbonForm_0.ribbon_0 != null)
					{
						throw new ArgumentException(this.ribbonForm_0.resources.GetString("ERR_RIBBON_ADDRIBBON"));
					}
					this.ribbonForm_0.ribbon_0 = (Ribbon)value;
					base.Add(value);
				}
				else
				{
					base.Add(value);
				}
			}

			public override void Remove(Control value)
			{
				base.Remove(value);
				if (value == this.ribbonForm_0.ribbon_0)
				{
					this.ribbonForm_0.ribbon_0 = null;
				}
			}
		}

		private const int int_0 = 1;

		private const int int_1 = 2;

		private const int int_2 = 5;

		private Class429.Struct89 struct89_0 = default(Class429.Struct89);

		private bool bool_0;

		private bool bool_1 = true;

		private bool bool_2 = true;

		private ResourceManager resources;

		private uint uint_0;

		private ToolStripDropDownButton toolStripDropDownButton_0;

		private Class496 class496_0;

		private Ribbon ribbon_0;

		private ToolStripMenuItem toolStripMenuItem_0;

		private ToolStripMenuItem toolStripMenuItem_1;

		private ToolStripItem[] toolStripItem_0 = new ToolStripItem[0];

		internal ToolStrip toolStrip_0;

		private int int_3;

		private bool bool_3 = true;

		internal ContextMenuStrip contextMenuStrip_0;

		private ToolStripMenuItem toolStripMenuItem_2;

		private ToolStripMenuItem toolStripMenuItem_3;

		private ToolStripMenuItem toolStripMenuItem_4;

		private bool bool_4 = true;

		private QuickAccessToolbarPosition quickAccessToolbarPosition_0 = QuickAccessToolbarPosition.AboveRibbon;

		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				if (this.bool_0)
				{
					createParams.ClassStyle |= 3;
				}
				return createParams;
			}
		}

		/// <summary>Gets or sets a value defining whether a quick access toolbar is shown in the caption area of the RibbonForm.</summary>
		[Attribute3("PROP_RIBBON_HASQAT")]
		[Category("Behavior")]
		[DefaultValue(true)]
		public bool HasQuickAccessToolbar
		{
			get
			{
				return this.bool_4;
			}
			set
			{
				if (this.bool_4 == value)
				{
					return;
				}
				this.bool_4 = value;
				if (this.bool_4)
				{
					if (this.toolStrip_0 == null)
					{
						this.method_0();
					}
					this.contextMenuStrip_0.Items.Insert(0, this.toolStripMenuItem_2);
					this.contextMenuStrip_0.Items.Insert(1, new ToolStripSeparator());
					this.contextMenuStrip_0.Items.Insert(2, this.toolStripMenuItem_3);
					this.contextMenuStrip_0.Items.Insert(3, new ToolStripSeparator());
				}
				else
				{
					for (int i = 0; i < 4; i++)
					{
						this.contextMenuStrip_0.Items.RemoveAt(0);
					}
				}
				if (!base.IsHandleCreated)
				{
					return;
				}
				if (this.bool_4 && this.toolStrip_0 != null)
				{
					base.Controls.Add(this.toolStrip_0);
					if (this.toolStrip_0.Dock == DockStyle.None)
					{
						this.toolStrip_0.Location = this.method_10();
					}
					if (this.ribbon_0 != null)
					{
						this.ribbon_0.SendToBack();
					}
				}
				else
				{
					base.Controls.Remove(this.toolStrip_0);
				}
				this.method_13(bool_5: true);
			}
		}

		/// <summary>Gets or sets a value defining the position of the quick access toolbar, above or below the ribbon.</summary>
		[Attribute3("PROP_RIBBON_QATPOSITION")]
		[Category("Behavior")]
		[DefaultValue(QuickAccessToolbarPosition.AboveRibbon)]
		public QuickAccessToolbarPosition QuickAccessToolbarPosition
		{
			get
			{
				return this.quickAccessToolbarPosition_0;
			}
			set
			{
				if (this.quickAccessToolbarPosition_0 != value)
				{
					this.quickAccessToolbarPosition_0 = value;
					if (base.IsHandleCreated)
					{
						this.method_5(value);
					}
				}
			}
		}

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public new Padding Padding
		{
			get
			{
				return base.Padding;
			}
			set
			{
				base.Padding = value;
			}
		}

		/// <summary>Initializes a new instance of the RibbonForm class.</summary>
		public RibbonForm()
		{
			this.bool_3 = VisualStyleRenderer.IsSupported;
			if (Environment.OSVersion.Version.Major >= 6)
			{
				int num = 0;
				Class429.DwmIsCompositionEnabled(ref num);
				this.bool_0 = num == 1;
				if (this.bool_0)
				{
					this.bool_0 = this.bool_3;
				}
			}
			this.resources = new ResourceManager(typeof(TextControlCore));
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.Opaque | ControlStyles.AllPaintingInWmPaint, value: true);
			this.BackColor = SystemColors.Window;
			this.DoubleBuffered = true;
			this.contextMenuStrip_0 = new ContextMenuStrip();
			this.contextMenuStrip_0.Opening += contextMenuStrip_0_Opening;
			this.toolStripMenuItem_2 = new ToolStripMenuItem(this.resources.GetString("QAT_Remove"));
			this.toolStripMenuItem_3 = new ToolStripMenuItem(this.resources.GetString("QAT_ShowBelow"));
			this.toolStripMenuItem_3.Click += toolStripMenuItem_1_Click;
			this.toolStripMenuItem_4 = new ToolStripMenuItem(this.resources.GetString("QAT_Minimize"));
			this.toolStripMenuItem_4.Click += toolStripMenuItem_0_Click;
			this.contextMenuStrip_0.Items.Add(this.toolStripMenuItem_2);
			this.contextMenuStrip_0.Items.Add(new ToolStripSeparator());
			this.contextMenuStrip_0.Items.Add(this.toolStripMenuItem_3);
			this.contextMenuStrip_0.Items.Add(new ToolStripSeparator());
			this.contextMenuStrip_0.Items.Add(this.toolStripMenuItem_4);
		}

		private void method_0()
		{
			if (this.toolStrip_0 != null)
			{
				return;
			}
			this.toolStrip_0 = new ToolStrip();
			this.toolStrip_0.GripStyle = ToolStripGripStyle.Hidden;
			this.toolStrip_0.OverflowButton.DropDownDirection = ((this.RightToLeft == RightToLeft.Yes) ? ToolStripDropDownDirection.BelowLeft : ToolStripDropDownDirection.BelowRight);
			this.toolStrip_0.RightToLeftChanged += toolStrip_0_RightToLeftChanged;
			this.class496_0 = new Class496(this);
			this.toolStrip_0.Renderer = this.class496_0;
			this.toolStripDropDownButton_0 = new Class566();
			if (this.bool_0 && this.quickAccessToolbarPosition_0 == QuickAccessToolbarPosition.AboveRibbon)
			{
				this.toolStrip_0.Dock = DockStyle.None;
				this.toolStrip_0.Items.Add(new ToolStripSeparator());
				this.toolStrip_0.Items.Add(this.toolStripDropDownButton_0);
				this.toolStrip_0.Items.Add(new ToolStripSeparator());
				this.toolStripMenuItem_1 = new ToolStripMenuItem(this.resources.GetString("QAT_ShowBelow"));
			}
			else
			{
				this.toolStrip_0.Dock = DockStyle.Top;
				this.toolStrip_0.Items.Add(this.toolStripDropDownButton_0);
				this.toolStripMenuItem_1 = new ToolStripMenuItem(this.resources.GetString("QAT_ShowAbove"));
				if (!this.bool_0)
				{
					this.toolStripMenuItem_1.Enabled = false;
				}
			}
			this.toolStripDropDownButton_0.BackColor = Color.Transparent;
			this.toolStripDropDownButton_0.DropDownItems.Add(new ToolStripSeparator());
			this.toolStripMenuItem_1.Click += toolStripMenuItem_1_Click;
			this.toolStripDropDownButton_0.DropDownItems.Add(this.toolStripMenuItem_1);
			this.toolStripDropDownButton_0.DropDownItems.Add(new ToolStripSeparator());
			this.toolStripMenuItem_0 = new ToolStripMenuItem(this.resources.GetString("QAT_Minimize"));
			this.toolStripMenuItem_0.Click += toolStripMenuItem_0_Click;
			this.toolStripMenuItem_0.Checked = this.toolStripMenuItem_4.Checked;
			this.toolStripDropDownButton_0.DropDownItems.Add(this.toolStripMenuItem_0);
			this.toolStripDropDownButton_0.ToolTipText = this.resources.GetString("TOOLTIPTITLE_QAT_Adapt");
			this.method_15();
		}

		public void SetQuickAccessToolbarStandardItems(RibbonButton[] items)
		{
			if (this.toolStrip_0 != null && this.toolStripDropDownButton_0 != null)
			{
				ToolStripItem[] array = this.toolStripItem_0;
				foreach (ToolStripItem toolStripItem in array)
				{
					this.toolStrip_0.Items.Remove(toolStripItem);
					this.toolStripDropDownButton_0.DropDownItems.RemoveByKey(toolStripItem.Name);
				}
			}
			int num = items.Length;
			this.toolStripItem_0 = new ToolStripItem[num];
			for (int j = 0; j < num; j++)
			{
				this.toolStripItem_0[j] = this.method_3(items[j]);
				this.toolStripItem_0[j].Name = j.ToString();
				this.toolStripItem_0[j].BackColor = Color.Transparent;
				this.toolStripItem_0[j].MouseUp += method_2;
			}
			this.method_15();
		}

		protected override void OnPaint(PaintEventArgs pea)
		{
			Rectangle rect = this.method_7();
			Graphics graphics = pea.Graphics;
			using (Brush brush = new SolidBrush(this.BackColor))
			{
				graphics.FillRectangle(brush, rect);
			}
			if (this.bool_0)
			{
				if (base.DesignMode)
				{
					this.method_6(graphics, this.bool_2);
				}
				else
				{
					VisualStyleRenderer visualStyleRenderer_ = new VisualStyleRenderer("CompositedWindow::Window", 0, 0);
					this.method_19(graphics, base.ClientRectangle, this.method_8(graphics), visualStyleRenderer_);
					if (this.ribbon_0 != null)
					{
						foreach (ContextualTabGroup contextualTabGroup in this.ribbon_0.ContextualTabGroups)
						{
							if (contextualTabGroup.Visible)
							{
								Rectangle rectangle = this.ribbon_0.method_23(contextualTabGroup);
								Rectangle rectangle_ = Rectangle.FromLTRB(rectangle.Left, 5, Math.Min(rectangle.Right, rect.Right - 4 * Class466.smethod_1(this.uint_0).Width), this.struct89_0.int_2);
								if (rectangle_.Right > rectangle_.Left + 5)
								{
									this.ribbon_0.method_22(graphics, contextualTabGroup, rectangle_);
								}
							}
						}
					}
				}
				if (base.Icon != null)
				{
					Bitmap bitmap = base.Icon.ToBitmap();
					graphics.DrawImage(bitmap, this.method_9(graphics));
					bitmap.Dispose();
				}
			}
			base.OnPaint(pea);
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			this.Padding = new Padding(this.struct89_0.int_0, this.struct89_0.int_2, this.struct89_0.int_1, this.struct89_0.int_3);
			if (this.ribbon_0 != null)
			{
				this.toolStripMenuItem_4.Checked = this.ribbon_0.Minimized;
			}
			if (this.bool_4)
			{
				this.method_0();
				base.Controls.Add(this.toolStrip_0);
				if (this.quickAccessToolbarPosition_0 == QuickAccessToolbarPosition.AboveRibbon)
				{
					this.toolStrip_0.Location = this.method_10();
				}
			}
			if (this.ribbon_0 != null)
			{
				this.ribbon_0.SendToBack();
				if (!this.ribbon_0.Minimized)
				{
					this.ribbon_0.method_7();
				}
			}
			if (this.uint_0 != 0)
			{
				Font font = Class467.smethod_1(this.uint_0);
				if (this.toolStrip_0 != null)
				{
					this.toolStrip_0.Font = font;
				}
				if (this.contextMenuStrip_0 != null)
				{
					this.contextMenuStrip_0.Font = font;
				}
			}
			base.OnHandleCreated(eventArgs_0);
			if (this.class496_0 != null)
			{
				this.class496_0.Boolean_0 = base.DesignMode;
			}
		}

		protected override void OnControlAdded(ControlEventArgs controlEventArgs_0)
		{
			base.OnControlAdded(controlEventArgs_0);
			if (controlEventArgs_0.Control != this.toolStrip_0 && controlEventArgs_0.Control != this.ribbon_0 && base.Controls.Contains(this.toolStrip_0))
			{
				if (this.toolStrip_0 != null)
				{
					this.toolStrip_0.SendToBack();
				}
				if (this.ribbon_0 != null)
				{
					this.ribbon_0.SendToBack();
				}
			}
		}

		protected override void OnActivated(EventArgs eventArgs_0)
		{
			base.OnActivated(eventArgs_0);
			if (this.bool_0)
			{
				Class429.DwmExtendFrameIntoClientArea(base.Handle, ref this.struct89_0);
			}
		}

		protected override void OnResize(EventArgs eventArgs_0)
		{
			base.OnResize(eventArgs_0);
			if (this.bool_0 && this.toolStrip_0 != null && this.toolStrip_0.Dock == DockStyle.None)
			{
				this.method_13(bool_5: false);
			}
		}

		private void method_1(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
			if (toolStripMenuItem == null || this.toolStrip_0 == null)
			{
				return;
			}
			toolStripMenuItem.Checked = !toolStripMenuItem.Checked;
			if (toolStripMenuItem.Checked)
			{
				_ = this.toolStrip_0.Items.Count;
				int num = this.toolStrip_0.Items.Count - 1;
				if (this.toolStrip_0.Dock == DockStyle.None)
				{
					num--;
				}
				ToolStripItem[] array = this.toolStripItem_0;
				int num2 = 0;
				ToolStripItem toolStripItem;
				while (true)
				{
					if (num2 < array.Length)
					{
						toolStripItem = array[num2];
						if (toolStripItem.Name == toolStripMenuItem.Name)
						{
							break;
						}
						num2++;
						continue;
					}
					return;
				}
				this.toolStrip_0.Items.Insert(num, toolStripItem);
			}
			else
			{
				this.toolStrip_0.Items.RemoveByKey(toolStripMenuItem.Name);
			}
		}

		private void method_2(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				this.contextMenuStrip_0.Show(this, base.PointToClient(Control.MousePosition));
				this.contextMenuStrip_0.Items[0].Tag = sender;
			}
		}

		private void toolStrip_0_RightToLeftChanged(object sender, EventArgs e)
		{
			if (this.toolStrip_0 != null)
			{
				this.toolStrip_0.OverflowButton.DropDownDirection = ((this.RightToLeft == RightToLeft.Yes) ? ToolStripDropDownDirection.BelowLeft : ToolStripDropDownDirection.BelowRight);
			}
		}

		private void contextMenuStrip_0_Opening(object sender, CancelEventArgs e)
		{
			ContextMenuStrip contextMenuStrip = sender as ContextMenuStrip;
			Control sourceControl = contextMenuStrip.SourceControl;
			if (this.bool_4)
			{
				this.toolStripMenuItem_2.Click -= toolStripMenuItem_2_Click;
				this.toolStripMenuItem_2.Click -= toolStripMenuItem_2_Click_1;
				if (sourceControl == this)
				{
					this.toolStripMenuItem_2.Enabled = true;
					this.toolStripMenuItem_2.Text = this.resources.GetString("QAT_Remove");
					this.toolStripMenuItem_2.Click += toolStripMenuItem_2_Click;
				}
				else
				{
					IRibbonToolStripItemProvider ribbonToolStripItemProvider = sourceControl as IRibbonToolStripItemProvider;
					this.toolStripMenuItem_2.Enabled = ribbonToolStripItemProvider != null && !ribbonToolStripItemProvider.IsToolStripItemAdded && ribbonToolStripItemProvider.IsAddToQuickAccessToolbarEnabled;
					this.toolStripMenuItem_2.Text = this.resources.GetString("QAT_Add");
					this.toolStripMenuItem_2.Click += toolStripMenuItem_2_Click_1;
					this.toolStripMenuItem_2.Tag = ribbonToolStripItemProvider;
				}
				this.toolStripMenuItem_3.Text = this.resources.GetString((this.toolStrip_0.Dock == DockStyle.None) ? "QAT_ShowBelow" : "QAT_ShowAbove");
				this.toolStripMenuItem_3.Enabled = (this.bool_0 ? true : false);
			}
		}

		private void toolStripMenuItem_2_Click(object sender, EventArgs e)
		{
			if (this.toolStrip_0 == null || this.toolStripDropDownButton_0 == null)
			{
				return;
			}
			ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
			if (toolStripMenuItem == null)
			{
				return;
			}
			ToolStripItem toolStripItem = toolStripMenuItem.Tag as ToolStripItem;
			if (toolStripItem == null)
			{
				return;
			}
			this.toolStrip_0.Items.Remove(toolStripItem);
			IRibbonToolStripItem ribbonToolStripItem = toolStripItem as IRibbonToolStripItem;
			if (ribbonToolStripItem != null)
			{
				ribbonToolStripItem.IsToolStripItemAdded = false;
				IRibbonToolStripItemProvider ribbonToolStripItemProvider = ribbonToolStripItem.Parent as IRibbonToolStripItemProvider;
				RibbonGroup ribbonGroup = ((ribbonToolStripItemProvider is RibbonGroup) ? (ribbonToolStripItemProvider as RibbonGroup) : (ribbonToolStripItemProvider as IRibbonItem).RibbonGroup);
				ribbonGroup.List_0.Remove(ribbonToolStripItemProvider);
			}
			bool flag = false;
			if (toolStripItem.Name != string.Empty)
			{
				ToolStripItem[] array = this.toolStripDropDownButton_0.DropDownItems.Find(toolStripItem.Name, searchAllChildren: false);
				if (array.GetLength(0) == 1)
				{
					ToolStripMenuItem toolStripMenuItem2 = array[0] as ToolStripMenuItem;
					if (toolStripMenuItem2 != null)
					{
						toolStripMenuItem2.Checked = false;
						flag = true;
					}
				}
			}
			if (!flag)
			{
				toolStripItem.MouseUp -= method_2;
			}
		}

		private void toolStripMenuItem_2_Click_1(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
			if (toolStripMenuItem == null)
			{
				return;
			}
			IRibbonToolStripItemProvider ribbonToolStripItemProvider = toolStripMenuItem.Tag as IRibbonToolStripItemProvider;
			if (ribbonToolStripItemProvider == null)
			{
				return;
			}
			ToolStripItem toolStripItem = ribbonToolStripItemProvider.ToolStripItem;
			if (toolStripItem != null)
			{
				toolStripItem.MouseUp += method_2;
				if (this.method_4(toolStripItem))
				{
					(toolStripItem as IRibbonToolStripItem).IsToolStripItemAdded = true;
					RibbonGroup ribbonGroup = ((ribbonToolStripItemProvider is RibbonGroup) ? (ribbonToolStripItemProvider as RibbonGroup) : (ribbonToolStripItemProvider as IRibbonItem).RibbonGroup);
					ribbonGroup.List_0.Add(ribbonToolStripItemProvider);
				}
			}
		}

		private ToolStripItem method_3(Control control_0)
		{
			if (control_0 != null)
			{
				IRibbonToolStripItemProvider ribbonToolStripItemProvider = control_0 as IRibbonToolStripItemProvider;
				if (ribbonToolStripItemProvider != null)
				{
					return ribbonToolStripItemProvider.ToolStripItem;
				}
			}
			return null;
		}

		private bool method_4(ToolStripItem toolStripItem_1)
		{
			if (this.toolStrip_0 != null && !this.toolStrip_0.Items.Contains(toolStripItem_1))
			{
				int num = this.toolStrip_0.Items.Count - 1;
				if (this.toolStrip_0.Dock == DockStyle.None)
				{
					num--;
				}
				this.toolStrip_0.Items.Insert(num, toolStripItem_1);
				return true;
			}
			return false;
		}

		private void toolStripMenuItem_1_Click(object sender, EventArgs e)
		{
			this.quickAccessToolbarPosition_0 = ((this.quickAccessToolbarPosition_0 != QuickAccessToolbarPosition.AboveRibbon) ? QuickAccessToolbarPosition.AboveRibbon : QuickAccessToolbarPosition.BelowRibbon);
			this.method_5(this.quickAccessToolbarPosition_0);
		}

		private void method_5(QuickAccessToolbarPosition quickAccessToolbarPosition_1)
		{
			if (this.bool_4 && this.toolStrip_0 != null)
			{
				ToolStripItemCollection items = this.toolStrip_0.Items;
				if (quickAccessToolbarPosition_1 == QuickAccessToolbarPosition.BelowRibbon)
				{
					this.toolStrip_0.MaximumSize = Size.Empty;
					this.toolStrip_0.Dock = DockStyle.Top;
					this.toolStripMenuItem_1.Text = this.resources.GetString("QAT_ShowAbove");
					items.RemoveAt(0);
					items.RemoveAt(items.Count - 1);
				}
				else
				{
					this.toolStrip_0.Dock = DockStyle.None;
					this.toolStripMenuItem_1.Text = this.resources.GetString("QAT_ShowBelow");
					items.Insert(0, new ToolStripSeparator());
					items.Add(new ToolStripSeparator());
					this.toolStrip_0.Location = this.method_10();
				}
				if (base.IsHandleCreated)
				{
					Graphics graphics = Graphics.FromHwnd(base.Handle);
					base.Invalidate(this.method_8(graphics));
					graphics.Dispose();
				}
			}
		}

		private void toolStripMenuItem_0_Click(object sender, EventArgs e)
		{
			if (this.toolStripMenuItem_4 != null)
			{
				this.toolStripMenuItem_4.Checked = !this.toolStripMenuItem_4.Checked;
				if (this.ribbon_0 != null)
				{
					this.ribbon_0.Minimized = this.toolStripMenuItem_4.Checked;
				}
				if (this.toolStripMenuItem_0 != null)
				{
					this.toolStripMenuItem_0.Checked = this.toolStripMenuItem_4.Checked;
				}
			}
		}

		private void method_6(Graphics graphics_0, bool bool_5)
		{
			Size size = Class466.smethod_2(this.uint_0);
			Size size2 = Class466.smethod_1(this.uint_0);
			Rectangle bounds = new Rectangle(-size.Width, 0, base.Width, this.struct89_0.int_2);
			Rectangle bounds2 = new Rectangle(new Point(this.method_7().Right - size2.Width, size.Height), size2);
			bounds2.Inflate(-1, -1);
			VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer(bool_5 ? VisualStyleElement.Window.Caption.Active : VisualStyleElement.Window.Caption.Inactive);
			visualStyleRenderer.DrawBackground(graphics_0, bounds);
			Rectangle rectangle = this.method_8(graphics_0);
			graphics_0.DrawString(this.Text, Class467.smethod_0(this.uint_0), bool_5 ? SystemBrushes.ActiveCaptionText : SystemBrushes.InactiveCaptionText, rectangle, new StringFormat(StringFormatFlags.NoWrap)
			{
				Alignment = StringAlignment.Center,
				LineAlignment = StringAlignment.Center,
				Trimming = StringTrimming.EllipsisWord
			});
			visualStyleRenderer = new VisualStyleRenderer(bool_5 ? VisualStyleElement.Window.CloseButton.Normal : VisualStyleElement.Window.CloseButton.Disabled);
			visualStyleRenderer.DrawBackground(graphics_0, bounds2);
			visualStyleRenderer = new VisualStyleRenderer(bool_5 ? VisualStyleElement.Window.MaxButton.Normal : VisualStyleElement.Window.MaxButton.Disabled);
			bounds2.Offset(-size2.Width, 0);
			visualStyleRenderer.DrawBackground(graphics_0, bounds2);
			visualStyleRenderer = new VisualStyleRenderer(bool_5 ? VisualStyleElement.Window.MinButton.Normal : VisualStyleElement.Window.MinButton.Disabled);
			bounds2.Offset(-size2.Width, 0);
			visualStyleRenderer.DrawBackground(graphics_0, bounds2);
		}

		private Rectangle method_7()
		{
			Class429.Struct83 struct83_ = default(Class429.Struct83);
			Class429.GetClientRect(base.Handle, ref struct83_);
			struct83_.int_0 += this.struct89_0.int_0;
			struct83_.int_1 += this.struct89_0.int_2;
			struct83_.int_2 -= this.struct89_0.int_1;
			struct83_.int_3 -= this.struct89_0.int_3;
			return struct83_.method_0();
		}

		private Rectangle method_8(Graphics graphics_0)
		{
			Rectangle rectangle = this.method_7();
			int num = DpiConverter.DPI96toPix(5, this.method_11(graphics_0));
			int num2 = DpiConverter.DPI96toPix(3, this.method_11(graphics_0)) + Class466.smethod_3(this.uint_0).Width;
			return Rectangle.FromLTRB(Math.Max(this.int_3 + num, (this.toolStrip_0 == null || !this.bool_4 || this.toolStrip_0.Dock != 0) ? num2 : (this.toolStrip_0.Right + num)), (base.IsHandleCreated && Class429.IsZoomed(base.Handle)) ? Class466.smethod_2(this.uint_0).Height : 0, rectangle.Right - 4 * Class466.smethod_1(this.uint_0).Width, this.struct89_0.int_2);
		}

		private Rectangle method_9(Graphics graphics_0)
		{
			Size size = Class466.smethod_3(this.uint_0);
			Point location = new Point(DpiConverter.DPI96toPix(1, this.method_11(graphics_0)), (this.struct89_0.int_2 - size.Height) / 2);
			if (base.IsHandleCreated && Class429.IsZoomed(base.Handle))
			{
				location.Offset(0, Class466.smethod_2(this.uint_0).Height / 2);
			}
			return new Rectangle(location, size);
		}

		private Point method_10()
		{
			int num = DpiConverter.DPI96toPix(3, this.method_11(null)) + Class466.smethod_3(this.uint_0).Width;
			Point result = new Point(num, (this.struct89_0.int_2 - this.toolStrip_0.Height) / 2);
			if (base.IsHandleCreated && Class429.IsZoomed(base.Handle))
			{
				result.Offset(0, Class466.smethod_2(this.uint_0).Height / 2 - 1);
			}
			return result;
		}

		internal uint method_11(Graphics graphics_0)
		{
			uint num = this.uint_0;
			if (num == 0)
			{
				if (graphics_0 != null)
				{
					num = (uint)graphics_0.DpiX;
				}
				else
				{
					num = 96u;
					if (base.IsHandleCreated)
					{
						graphics_0 = Graphics.FromHwnd(base.Handle);
						num = (uint)graphics_0.DpiX;
						graphics_0.Dispose();
					}
				}
			}
			return num;
		}

		internal uint method_12()
		{
			return this.uint_0;
		}

		internal void method_13(bool bool_5)
		{
			int num = base.Width - 4 * Class466.smethod_1(this.uint_0).Width;
			this.int_3 = 0;
			if (this.ribbon_0 != null)
			{
				foreach (ContextualTabGroup contextualTabGroup in this.ribbon_0.ContextualTabGroups)
				{
					if (!contextualTabGroup.Visible)
					{
						continue;
					}
					foreach (RibbonTab contextualTab in contextualTabGroup.ContextualTabs)
					{
						int num2 = this.ribbon_0.TabPages.IndexOf(contextualTab);
						if (num2 > 0)
						{
							Rectangle tabRect = this.ribbon_0.GetTabRect(num2);
							num = Math.Min(num, tabRect.Left);
							this.int_3 = Math.Max(this.int_3, tabRect.Right);
						}
					}
				}
			}
			if (this.bool_4 && this.toolStrip_0 != null && this.toolStrip_0.Dock == DockStyle.None)
			{
				this.toolStrip_0.Location = this.method_10();
				this.toolStrip_0.MaximumSize = new Size(num - this.toolStrip_0.Left, 0);
			}
			if (this.bool_0 && bool_5)
			{
				base.Invalidate(new Rectangle(0, 0, base.Width, this.struct89_0.int_2));
			}
		}

		internal void method_14()
		{
			if (!this.bool_4 || this.toolStrip_0 == null)
			{
				return;
			}
			foreach (ToolStripItem item in this.toolStrip_0.Items)
			{
				IRibbonToolStripItem ribbonToolStripItem = item as IRibbonToolStripItem;
				if (ribbonToolStripItem != null)
				{
					RibbonTab ribbonTab = ribbonToolStripItem.RibbonTab;
					if (ribbonTab != null)
					{
						bool flag = !(ribbonToolStripItem.Parent is RibbonButton) || (ribbonToolStripItem.Parent as IRibbonItem).OwnerEnabled;
						item.Enabled = this.ribbon_0.TabPages.Contains(ribbonTab) && flag;
					}
				}
			}
		}

		private void method_15()
		{
			if (this.toolStrip_0 != null && this.toolStripDropDownButton_0 != null)
			{
				int num = ((this.toolStrip_0.Dock == DockStyle.None) ? 1 : 0);
				int num2 = 0;
				ToolStripItem[] array = this.toolStripItem_0;
				foreach (ToolStripItem toolStripItem in array)
				{
					this.toolStrip_0.Items.Insert(num++, toolStripItem);
					ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
					toolStripMenuItem.Text = toolStripItem.Text;
					toolStripMenuItem.Checked = true;
					toolStripMenuItem.Click += method_1;
					toolStripMenuItem.Name = toolStripItem.Name;
					this.toolStripDropDownButton_0.DropDownItems.Insert(num2++, toolStripMenuItem);
				}
				this.method_16();
			}
		}

		private void method_16()
		{
			if (!base.IsHandleCreated)
			{
				return;
			}
			PointF pointF;
			if (this.uint_0 != 0)
			{
				pointF = new PointF(this.uint_0, this.uint_0);
			}
			else
			{
				Graphics graphics = base.CreateGraphics();
				pointF = new PointF(graphics.DpiX, graphics.DpiY);
				graphics.Dispose();
			}
			Class517.smethod_0(pointF);
			for (int i = 0; i < this.toolStrip_0.Items.Count; i++)
			{
				ToolStripItem toolStripItem = this.toolStrip_0.Items[i];
				if (toolStripItem is IRibbonToolStripItem)
				{
					(toolStripItem as IRibbonToolStripItem).DPI = pointF;
				}
			}
			(this.toolStripDropDownButton_0 as Class566).method_0(pointF);
		}

		protected override void WndProc(ref Message message)
		{
			bool flag = true;
			if (this.bool_0)
			{
				IntPtr intptr_ = IntPtr.Zero;
				if (Class429.DwmDefWindowProc(message.HWnd, message.Msg, message.WParam, message.LParam, ref intptr_))
				{
					message.Result = intptr_;
					return;
				}
				switch (message.Msg)
				{
				case 131:
					if (message.WParam.ToInt32() == 1)
					{
						if (this.bool_1)
						{
							_ = (Class429.Struct90)message.GetLParam(typeof(Class429.Struct90));
							Class429.DefWindowProc(message.HWnd, message.Msg, message.WParam, message.LParam);
							Class429.Struct90 @struct = (Class429.Struct90)message.GetLParam(typeof(Class429.Struct90));
							@struct.struct83_0[0].int_1 -= this.struct89_0.int_2;
							Marshal.StructureToPtr((object)@struct, message.LParam, fDeleteOld: false);
						}
						else
						{
							Class429.Struct90 @struct = (Class429.Struct90)message.GetLParam(typeof(Class429.Struct90));
							@struct.struct83_0[0].int_0 = @struct.struct83_0[0].int_0;
							@struct.struct83_0[0].int_1 = @struct.struct83_0[0].int_1;
							@struct.struct83_0[0].int_2 = @struct.struct83_0[0].int_2;
							@struct.struct83_0[0].int_3 = @struct.struct83_0[0].int_3;
							Marshal.StructureToPtr((object)@struct, message.LParam, fDeleteOld: false);
						}
						message.Result = IntPtr.Zero;
						flag = false;
					}
					break;
				case 132:
					if (intptr_ == IntPtr.Zero)
					{
						intptr_ = this.method_18(message.HWnd, message.WParam, message.LParam);
						if (intptr_.ToInt32() != 0)
						{
							flag = false;
						}
					}
					message.Result = intptr_;
					break;
				case 134:
					this.bool_2 = ((message.WParam.ToInt32() == 1) ? true : false);
					if (this.class496_0 != null)
					{
						this.class496_0.Boolean_1 = this.bool_2;
					}
					if (base.DesignMode)
					{
						base.Invalidate(invalidateChildren: true);
					}
					break;
				case 1:
				{
					this.uint_0 = Class429.smethod_15(message.HWnd);
					this.method_17(message.HWnd, this.uint_0);
					Class429.Struct83 struct83_ = default(Class429.Struct83);
					Class429.GetWindowRect(message.HWnd, ref struct83_);
					Class429.SetWindowPos(message.HWnd, IntPtr.Zero, struct83_.int_0, struct83_.int_1, struct83_.int_2 - struct83_.int_0, struct83_.int_3 - struct83_.int_1, 32u);
					flag = true;
					message.Result = IntPtr.Zero;
					break;
				}
				}
			}
			switch (message.Msg)
			{
			case 529:
				if (this.bool_3 && Control.MouseButtons == MouseButtons.None)
				{
					this.ribbon_0.method_12(message.HWnd);
				}
				break;
			case 530:
				if (this.bool_3)
				{
					this.ribbon_0.method_11();
					this.ribbon_0.method_17();
				}
				break;
			case 288:
				message.Result = (this.ribbon_0.method_14((char)Class429.smethod_5(message.WParam.ToInt32())) ? ((IntPtr)Class429.smethod_3(0, 1)) : ((IntPtr)Class429.smethod_3(0, 0)));
				flag = false;
				break;
			case 2127:
				base.WndProc(ref message);
				flag = false;
				if (this.ribbon_0 != null)
				{
					Point point_ = new Point(Class429.smethod_7(message.LParam), Class429.smethod_8(message.LParam));
					message.Result = (IntPtr)this.ribbon_0.method_2(point_, Class429.smethod_8(message.WParam));
				}
				break;
			case 736:
			{
				Class429.Struct83 struct2 = (Class429.Struct83)Marshal.PtrToStructure(message.LParam, typeof(Class429.Struct83));
				this.uint_0 = Class429.smethod_5(message.WParam.ToInt32());
				this.method_17(message.HWnd, this.uint_0);
				this.Padding = new Padding(this.struct89_0.int_0, this.struct89_0.int_2, this.struct89_0.int_1, this.struct89_0.int_3);
				Class429.DwmExtendFrameIntoClientArea(base.Handle, ref this.struct89_0);
				Class429.SetWindowPos(message.HWnd, IntPtr.Zero, struct2.int_0, struct2.int_1, struct2.int_2 - struct2.int_0, struct2.int_3 - struct2.int_1, 52u);
				Font font = Class467.smethod_1(this.uint_0);
				if (this.toolStrip_0 != null)
				{
					this.toolStrip_0.Font = font;
					this.method_16();
				}
				if (this.contextMenuStrip_0 != null)
				{
					this.contextMenuStrip_0.Font = font;
				}
				this.method_13(bool_5: false);
				flag = false;
				break;
			}
			}
			if (flag)
			{
				base.WndProc(ref message);
			}
		}

		private void method_17(IntPtr intptr_0, uint uint_1)
		{
			Class429.Struct83 struct83_ = default(Class429.Struct83);
			this.struct89_0.int_0 = 0;
			this.struct89_0.int_1 = 0;
			this.struct89_0.int_2 = 0;
			this.struct89_0.int_3 = 0;
			Class429.smethod_13(intptr_0, ref struct83_, bool_0: false, uint_1);
			this.struct89_0.int_2 = -struct83_.int_1;
			if (!this.bool_1)
			{
				this.struct89_0.int_0 = -struct83_.int_0;
				this.struct89_0.int_1 = struct83_.int_2;
				this.struct89_0.int_3 = struct83_.int_3;
			}
		}

		private IntPtr method_18(IntPtr intptr_0, IntPtr intptr_1, IntPtr intptr_2)
		{
			Class429.Struct82 @struct = new Class429.Struct82((short)Class429.smethod_5(intptr_2.ToInt32()), (short)Class429.smethod_6(intptr_2.ToInt32()));
			Class429.Struct83 struct83_ = default(Class429.Struct83);
			Class429.GetWindowRect(intptr_0, ref struct83_);
			Graphics graphics = Graphics.FromHwnd(intptr_0);
			Rectangle rectangle = this.method_9(graphics);
			graphics.Dispose();
			rectangle.Offset(struct83_.int_0 + 8, struct83_.int_1);
			if (rectangle.Contains(new Point(@struct.int_0, @struct.int_1)))
			{
				return new IntPtr(3);
			}
			Class429.Struct83 struct83_2 = default(Class429.Struct83);
			uint num = (uint)Class429.smethod_11(intptr_0, -16).ToInt32();
			uint uint_ = (uint)Class429.smethod_11(intptr_0, -20).ToInt32();
			Class429.smethod_14(ref struct83_2, num & 0xFF3FFFFFu, bool_0: false, uint_, this.uint_0);
			int num2 = 1;
			int num3 = 1;
			if (@struct.int_1 >= struct83_.int_1 && @struct.int_1 < struct83_.int_1 - struct83_2.int_1)
			{
				num2 = 0;
			}
			else if (@struct.int_1 < struct83_.int_3 && @struct.int_1 >= struct83_.int_3 - struct83_2.int_3)
			{
				num2 = 2;
			}
			if (@struct.int_0 >= struct83_.int_0 && @struct.int_0 < struct83_.int_0 - struct83_2.int_0)
			{
				num3 = 0;
			}
			else if (@struct.int_0 < struct83_.int_2 && @struct.int_0 >= struct83_.int_2 - struct83_2.int_2)
			{
				num3 = 2;
			}
			int[,] array = new int[3, 3]
			{
				{ 13, 12, 14 },
				{ 10, 0, 11 },
				{ 16, 15, 17 }
			};
			if (array[num2, num3] == 0 && @struct.int_1 >= struct83_.int_1 && @struct.int_1 < struct83_.int_1 + this.struct89_0.int_2)
			{
				return new IntPtr(2);
			}
			return new IntPtr(array[num2, num3]);
		}

		private void method_19(Graphics graphics_0, Rectangle rectangle_0, Rectangle rectangle_1, VisualStyleRenderer visualStyleRenderer_0)
		{
			IntPtr hdc = graphics_0.GetHdc();
			IntPtr intPtr = Class429.CreateCompatibleDC(hdc);
			if (intPtr != IntPtr.Zero)
			{
				Class429.Struct91 struct91_ = default(Class429.Struct91);
				struct91_.struct92_0.uint_0 = (uint)Marshal.SizeOf(typeof(Class429.Struct92));
				struct91_.struct92_0.int_0 = rectangle_0.Width;
				struct91_.struct92_0.int_1 = -rectangle_0.Height;
				struct91_.struct92_0.ushort_0 = 1;
				struct91_.struct92_0.ushort_1 = 32;
				struct91_.struct92_0.ushort_2 = 0;
				IntPtr intPtr2 = Class429.CreateDIBSection(hdc, ref struct91_, 0u, IntPtr.Zero, IntPtr.Zero, 0u);
				if (intPtr2 != IntPtr.Zero)
				{
					Font font = Class467.smethod_0(this.uint_0);
					IntPtr intPtr3 = font.ToHfont();
					IntPtr intptr_ = Class429.SelectObject(intPtr, intPtr3);
					IntPtr intptr_2 = Class429.SelectObject(intPtr, intPtr2);
					Graphics graphics = Graphics.FromHdc(intPtr);
					SizeF sizeF = graphics.MeasureString(this.Text, font);
					rectangle_1.Offset(0, (rectangle_1.Bottom - rectangle_1.Top - (int)sizeF.Height) / 2 + 1);
					visualStyleRenderer_0.DrawText(graphics, rectangle_1, this.Text, drawDisabled: false, TextFormatFlags.HorizontalCenter | TextFormatFlags.WordEllipsis);
					Class429.BitBlt(hdc, 0, 0, rectangle_0.Width, this.struct89_0.int_2, intPtr, 0, 0, 13369376u);
					graphics.Dispose();
					Class429.SelectObject(intPtr, intptr_2);
					Class429.SelectObject(intPtr, intptr_);
					Class429.DeleteObject(intPtr3);
					Class429.DeleteObject(intPtr2);
				}
				Class429.DeleteDC(intPtr);
			}
			graphics_0.ReleaseHdc(hdc);
		}

		protected override Control.ControlCollection CreateControlsInstance()
		{
			return new ControlCollection(this);
		}
	}
}
