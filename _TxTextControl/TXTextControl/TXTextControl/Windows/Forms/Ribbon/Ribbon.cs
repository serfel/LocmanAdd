using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ns21;
using ns27;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>The Ribbon class is a command bar that organizes the features of an application into a series of tabs at the top of the application window.</summary>
	[Designer("TXTextControl.Windows.Forms.Ribbon.RibbonDesigner, TXTextControl.Design.dll, Version=29.0.113.500, Culture=neutral, PublicKeyToken=17fff8a774004c66")]
	[ToolboxBitmap(typeof(Ribbon))]
	[ToolboxItem(true)]
	public class Ribbon : TabControl
	{
		private class Class495 : NativeWindow
		{
			private Ribbon ribbon_0;

			private int int_0;

			public int Int32_0 => this.int_0;

			public Class495(Ribbon ribbon_1)
			{
				this.ribbon_0 = ribbon_1;
			}

			protected override void WndProc(ref Message message_0)
			{
				switch (message_0.Msg)
				{
				case 512:
					if (this.ribbon_0.int_5 > 0 && this.ribbon_0.int_5 != this.ribbon_0.SelectedIndex)
					{
						using Graphics graphics_ = Graphics.FromHwnd(this.ribbon_0.Handle);
						VisualStyleRenderer visualStyleRenderer_ = new VisualStyleRenderer(VisualStyleElement.Tab.TabItem.Normal);
						Rectangle tabRect = this.ribbon_0.GetTabRect(this.ribbon_0.int_5);
						this.ribbon_0.method_20(graphics_, this.ribbon_0.int_5, tabRect, visualStyleRenderer_);
					}
					break;
				case 70:
					this.int_0 = ((Class429.Struct86)message_0.GetLParam(typeof(Class429.Struct86))).int_0;
					break;
				case 2:
					this.ReleaseHandle();
					break;
				}
				base.WndProc(ref message_0);
			}
		}

		public new class ControlCollection : TabControl.ControlCollection
		{
			private Ribbon ribbon_0;

			public ControlCollection(Ribbon owner)
				: base(owner)
			{
				this.ribbon_0 = owner;
			}

			public override void Add(Control value)
			{
				if (!(value is RibbonTab))
				{
					throw new ArgumentException(this.ribbon_0.resourceManager_0.GetString("ERR_RIBBON_ADDRIBBONTAB"));
				}
				int num = 0;
					foreach (Control item in this)
					{
						if (item.GetType() != typeof(AppMenuTab) && item.GetType() != typeof(RibbonChartLayoutTab) && item.GetType() != typeof(RibbonFormattingTab) && item.GetType() != typeof(RibbonFormFieldsTab) && item.GetType() != typeof(RibbonFormulaTab) && item.GetType() != typeof(RibbonFrameLayoutTab) && item.GetType() != typeof(RibbonInsertTab) && item.GetType() != typeof(RibbonPageLayoutTab) && item.GetType() != typeof(RibbonPermissionsTab) && item.GetType() != typeof(RibbonProofingTab) && item.GetType() != typeof(RibbonReferencesTab) && item.GetType() != typeof(RibbonReportingTab) && item.GetType() != typeof(RibbonTableLayoutTab) && item.GetType() != typeof(RibbonViewTab))
						{
							num++;
						}
					}
					if (num == 3)
					{
						throw new ArgumentException(this.ribbon_0.resourceManager_0.GetString("ERR_RIBBON_TRIALVERSION"));
					}
				base.Add(value);
			}

			public override void Remove(Control value)
			{
				if (value == this.ribbon_0.ribbonTab_0 && !this.ribbon_0.bool_3)
				{
					throw new ArgumentException(this.ribbon_0.resourceManager_0.GetString("ERR_RIBBON_REMOVEAPPMENU"));
				}
				base.Remove(value);
				if (this.ribbon_0.SelectedIndex == 0 && this.ribbon_0.bool_4)
				{
					this.ribbon_0.SelectedIndex = -1;
				}
				if (this.ribbon_0.SelectedIndex == -1 && !this.ribbon_0.Minimized)
				{
					if (this.Count > 1 && this.ribbon_0.bool_4)
					{
						this.ribbon_0.SelectedIndex = 1;
					}
					if (this.Count > 0 && !this.ribbon_0.bool_4)
					{
						this.ribbon_0.SelectedIndex = 0;
					}
				}
			}
		}

		/// <summary>The Ribbon.Colors class gets, sets or resets the display colors of a Windows Forms Ribbon control.</summary>
		public sealed class Colors
		{
			private Color[] color_0 = new Color[7];

			private Color[] color_1 = new Color[7];

			private Ribbon ribbon_0;

			/// <summary>Gets or sets the background color of a ribbon tab.</summary>
			[RefreshProperties(RefreshProperties.Repaint)]
			[Category("Appearance")]
			[Attribute3("PROP_RIBBON_DISPLAYCOLORS_TAB")]
			public Color TabColor
			{
				get
				{
					return this.color_1[0];
				}
				set
				{
					this.color_1[0] = value;
					this.method_4();
				}
			}

			/// <summary>Gets or sets the highlight color of a ribbon tab which is used when a tab is selected.</summary>
			[Category("Appearance")]
			[RefreshProperties(RefreshProperties.Repaint)]
			[Attribute3("PROP_RIBBON_DISPLAYCOLORS_TABHIGHLIGHT")]
			public Color HighlightTabColor
			{
				get
				{
					return this.color_1[1];
				}
				set
				{
					this.color_1[1] = value;
					this.method_4();
				}
			}

			/// <summary>Gets or sets the menu color of a ribbon.</summary>
			[Category("Appearance")]
			[Attribute3("PROP_RIBBON_DISPLAYCOLORS_MENU")]
			[RefreshProperties(RefreshProperties.Repaint)]
			public Color MenuColor
			{
				get
				{
					return this.color_1[2];
				}
				set
				{
					this.color_1[2] = value;
					this.method_4();
				}
			}

			/// <summary>Gets or sets the background color of a ribbon's application menu.</summary>
			[Attribute3("PROP_RIBBON_DISPLAYCOLORS_APPMENU")]
			[RefreshProperties(RefreshProperties.Repaint)]
			[Category("Appearance")]
			public Color ApplicationMenuColor
			{
				get
				{
					return this.color_1[3];
				}
				set
				{
					this.color_1[3] = value;
				}
			}

			/// <summary>Gets or sets the color of a ribbon's first tab, which opens the application menu.</summary>
			[Attribute3("PROP_RIBBON_DISPLAYCOLORS_APPMENUTAB")]
			[RefreshProperties(RefreshProperties.Repaint)]
			[Category("Appearance")]
			public Color ApplicationMenuTabColor
			{
				get
				{
					return this.color_1[4];
				}
				set
				{
					this.color_1[4] = value;
					this.method_4();
				}
			}

			/// <summary>Gets or sets the highlight color of a ribbon's first tab which is used, when the mouse pointer is moved over it.</summary>
			[RefreshProperties(RefreshProperties.Repaint)]
			[Attribute3("PROP_RIBBON_DISPLAYCOLORS_APPMENUTABHIGHLIGHT")]
			[Category("Appearance")]
			public Color ApplicationMenuTabHighlightColor
			{
				get
				{
					return this.color_1[5];
				}
				set
				{
					this.color_1[5] = value;
					this.method_4();
				}
			}

			/// <summary>Initializes a new instance of the Ribbon.Colors class. After creating the object with this constuctor, individual colors can be set. If the Colors object is assigned to the Windows.Forms.Ribbon.Ribbon.DisplayColors property, non-set colors are reset to their system dependent default values.</summary>
			public Colors()
			{
				this.color_0 = Ribbon.smethod_0();
				for (int i = 0; i < 7; i++)
				{
					ref Color reference = ref this.color_1[i];
					reference = this.color_0[i];
				}
			}

			public bool ShouldSerializeTabColor()
			{
				return this.color_1[0] != this.color_0[0];
			}

			/// <summary>Resets the ribbon's TabColor to its system dependent default value.</summary>
			public void ResetTabColor()
			{
				ref Color reference = ref this.color_1[0];
				reference = this.color_0[0];
				this.method_4();
			}

			public bool ShouldSerializeHighlightTabColor()
			{
				return this.color_1[1] != this.color_0[1];
			}

			/// <summary>Resets the ribbon's HighlightTabColor to its system dependent default value.</summary>
			public void ResetHighlightTabColor()
			{
				ref Color reference = ref this.color_1[1];
				reference = this.color_0[1];
				this.method_4();
			}

			public bool ShouldSerializeMenuColor()
			{
				return this.color_1[2] != this.color_0[2];
			}

			/// <summary>Resets the ribbon's MenuColor to its system dependent default value.</summary>
			public void ResetMenuColor()
			{
				ref Color reference = ref this.color_1[2];
				reference = this.color_0[2];
				this.method_4();
			}

			public bool ShouldSerializeApplicationMenuColor()
			{
				return this.color_1[3] != this.color_0[3];
			}

			/// <summary>Resets the ribbon's ApplicationMenuColor to its system dependent default value.</summary>
			public void ResetApplicationMenuColor()
			{
				ref Color reference = ref this.color_1[3];
				reference = this.color_0[3];
			}

			public bool ShouldSerializeApplicationMenuTabColor()
			{
				return this.color_1[4] != this.color_0[4];
			}

			/// <summary>Resets the ribbon's ApplicationMenuTabColor to its system dependent default value.</summary>
			public void ResetApplicationMenuTabColor()
			{
				ref Color reference = ref this.color_1[4];
				reference = this.color_0[4];
				this.method_4();
			}

			public bool ShouldSerializeApplicationMenuTabHighlightColor()
			{
				return this.color_1[5] != this.color_0[5];
			}

			/// <summary>Resets the ribbon's ApplicationMenuTabHighlightColor to its system dependent default value.</summary>
			public void ResetApplicationMenuTabHighlightColor()
			{
				ref Color reference = ref this.color_1[5];
				reference = this.color_0[5];
				this.method_4();
			}

			public void method_0(Colors colors_0)
			{
				for (int i = 0; i < this.color_1.Length; i++)
				{
					ref Color reference = ref colors_0.color_1[i];
					reference = this.color_1[i];
				}
			}

			public void method_1()
			{
				for (int i = 0; i < this.color_1.Length; i++)
				{
					ref Color reference = ref this.color_1[i];
					reference = this.color_0[i];
				}
				this.method_4();
			}

			public bool method_2()
			{
				int num = 0;
				while (true)
				{
					if (num < this.color_1.Length)
					{
						if (this.color_1[num] != this.color_0[num])
						{
							break;
						}
						num++;
						continue;
					}
					return true;
				}
				return false;
			}

			public void method_3(Ribbon ribbon_1)
			{
				this.ribbon_0 = ribbon_1;
			}

			private void method_4()
			{
				if (this.ribbon_0 != null)
				{
					this.ribbon_0.Invalidate(invalidateChildren: true);
				}
			}
		}

		public enum Enum135
		{
			const_0,
			const_1,
			const_2
		}

		public const int int_0 = 116;

		public const int int_1 = 200;

		public const int int_2 = 40;

		public const int int_3 = 10;

		public const int int_4 = 7;

		private Class601 class601_0;

		private Color[] color_0 = new Color[7];

		private RibbonDropDown ribbonDropDown_0;

		private RibbonDropDown ribbonDropDown_1;

		private int int_5 = -1;

		private int int_6 = -1;

		private int int_7 = -1;

		private Padding padding_0 = new Padding(0);

		private int int_8;

		private TableLayoutPanel tableLayoutPanel_0;

		private Class495 class495_0;

		private ResourceManager resourceManager_0;

		private IntPtr intptr_0 = IntPtr.Zero;

		private ContextualTabGroupCollection contextualTabGroupCollection_0;

		private RibbonGroup ribbonGroup_0 = new Class497();

		private RibbonGroup ribbonGroup_1 = new Class497();

		private RibbonTab ribbonTab_0 = new AppMenuTab();

		private bool bool_0 = true;

		public uint uint_0;

		private IntPtr intptr_1 = IntPtr.Zero;

		private TextControl textControl_0;

		private Colors colors_0 = new Colors();

		private bool bool_1;

		private bool bool_2;

		private bool bool_3;

		private bool bool_4 = true;

		private string string_0 = string.Empty;

		public Enum135 enum135_0;

		protected override Padding DefaultMargin => new Padding(0);

		protected override Padding DefaultPadding => new Padding(0);

		public TextControl TextControl_0
		{
			get
			{
				return this.textControl_0;
			}
			set
			{
				this.textControl_0 = value;
				foreach (Control control in base.Controls)
				{
					if (control is RibbonTab)
					{
						((RibbonTab)control).TextControl_0 = value;
					}
				}
			}
		}

		/// <summary>Gets a collection of all items which are displayed on the Application Menu.</summary>
		[Editor("TXTextControl.Windows.Forms.Ribbon.ApplicationMenuItemsEditor, TXTextControl.Design.dll", typeof(UITypeEditor))]
		[Attribute3("PROP_RIBBON_APPLICATIONMENUITEMS")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Layout")]
		public RibbonItemCollection ApplicationMenuItems => this.ribbonGroup_0.RibbonItems;

		/// <summary>Gets a collection of all items which are displayed on the help pane of the Application Menu.</summary>
		[Attribute3("PROP_RIBBON_APPLICATIONMENUHELPPANEITEMS")]
		[Category("Layout")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Editor("TXTextControl.Windows.Forms.Ribbon.ApplicationMenuItemsEditor, TXTextControl.Design.dll", typeof(UITypeEditor))]
		public RibbonItemCollection ApplicationMenuHelpPaneItems => this.ribbonGroup_1.RibbonItems;

		/// <summary>Gets a collection of all contextual tab groups of this ribbon.</summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Layout")]
		[Attribute3("PROP_RIBBON_CONTEXTUALTABGROUPS")]
		[Editor("TXTextControl.Windows.Forms.Ribbon.ContextualTabGroupEditor, TXTextControl.Design.dll", typeof(UITypeEditor))]
		public ContextualTabGroupCollection ContextualTabGroups => this.contextualTabGroupCollection_0;

		/// <summary>Gets or sets the colors of the ribbon.</summary>
		[Attribute3("PROP_RIBBON_DISPLAYCOLORS")]
		[TypeConverter(typeof(Class417))]
		[RefreshProperties(RefreshProperties.Repaint)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Appearance")]
		public Colors DisplayColors
		{
			get
			{
				return this.colors_0;
			}
			set
			{
				value.method_0(this.colors_0);
				base.Invalidate(invalidateChildren: true);
			}
		}

		/// <summary>Gets or sets a value determining whether the ribbon is shown minimized.</summary>
		[DefaultValue(false)]
		[Category("Behavior")]
		[Attribute3("PROP_RIBBON_MINIMIZED")]
		public bool Minimized
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				if (this.bool_1 == value)
				{
					return;
				}
				this.bool_1 = value;
				if (!base.IsHandleCreated)
				{
					return;
				}
				if (this.bool_1)
				{
					this.int_7 = base.SelectedIndex;
					base.SelectedIndex = -1;
					this.int_8 = base.Height;
					base.Height = base.GetTabRect(0).Bottom + 1;
					if (this.ribbonDropDown_1 == null)
					{
						this.method_29();
					}
					return;
				}
				if (this.ribbonDropDown_1 != null && this.ribbonDropDown_1.Visible)
				{
					this.ribbonDropDown_1.Close();
				}
				base.Height = this.int_8;
				if (this.int_7 == -1)
				{
					this.method_7();
				}
				else
				{
					base.SelectedIndex = this.int_7;
				}
				this.int_6 = -1;
			}
		}

		/// <summary>Gets or sets a value determining the ribbon's read only mode.</summary>
		[Attribute3("PROP_RIBBON_READONLY")]
		[DefaultValue(false)]
		[Category("Behavior")]
		public bool ReadOnly
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				if (this.bool_2 == value)
				{
					return;
				}
				this.bool_2 = value;
				foreach (Control control in base.Controls)
				{
					if (control is RibbonTab)
					{
						((RibbonTab)control).Boolean_1 = value;
					}
				}
			}
		}

		/// <summary>Gets or sets a value defining whether the first tab of the ribbon is an application menu.</summary>
		[Attribute3("PROP_RIBBON_HASAPPMENU")]
		[DefaultValue(true)]
		[Category("Behavior")]
		public bool HasApplicationMenu
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
					if (this.bool_4)
					{
						this.method_3();
						return;
					}
					this.bool_3 = true;
					this.TabPages.RemoveAt(0);
					this.bool_3 = false;
				}
			}
		}

		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new TabPageCollection TabPages => base.TabPages;

		/// <summary>Initializes a new instance of the Ribbon class.</summary>
		public Ribbon()
		{
			this.class601_0 = new Class601(TypeDescriptor.GetProvider(typeof(object)));
			TypeDescriptor.AddProvider(this.class601_0, typeof(object));
			this.bool_0 = VisualStyleRenderer.IsSupported;
			base.Alignment = TabAlignment.Top;
			base.HotTrack = true;
			base.Appearance = TabAppearance.Normal;
			if (this.bool_0)
			{
				base.SetStyle(ControlStyles.UserPaint | ControlStyles.Opaque, value: true);
			}
			base.SetStyle(ControlStyles.OptimizedDoubleBuffer, !this.RightToLeftLayout);
			base.SetStyle(ControlStyles.Selectable, value: false);
			this.color_0 = Ribbon.smethod_0();
			this.class495_0 = new Class495(this);
			this.Font = SystemFonts.MenuFont;
			this.Dock = DockStyle.Top;
			this.resourceManager_0 = new ResourceManager(typeof(TextControlCore));
			if (this.bool_4)
			{
				this.method_3();
			}
			this.colors_0.method_3(this);
			this.contextualTabGroupCollection_0 = new ContextualTabGroupCollection(this);
			//
		}

		protected override void Dispose(bool disposing)
		{
			if (this.intptr_1 != IntPtr.Zero)
			{
				Class429.DeleteObject(this.intptr_1);
				this.intptr_1 = IntPtr.Zero;
			}
			if (this.ribbonDropDown_0 != null)
			{
				this.ribbonDropDown_0.Dispose();
			}
			TypeDescriptor.RemoveProvider(this.class601_0, typeof(object));
			this.class495_0.ReleaseHandle();
			base.Dispose(disposing);
		}

		protected override void OnRightToLeftChanged(EventArgs eventArgs_0)
		{
			if (base.IsHandleCreated)
			{
				base.OnRightToLeftChanged(eventArgs_0);
			}
			if (this.ribbonDropDown_0 != null)
			{
				this.ribbonDropDown_0.RightToLeft = this.RightToLeft;
			}
			if (this.ribbonDropDown_1 != null)
			{
				this.ribbonDropDown_1.RightToLeft = this.RightToLeft;
			}
		}

		protected override void OnRightToLeftLayoutChanged(EventArgs eventArgs_0)
		{
			base.SetStyle(ControlStyles.OptimizedDoubleBuffer, !this.RightToLeftLayout);
			base.OnRightToLeftLayoutChanged(eventArgs_0);
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			Graphics graphics = Graphics.FromHwnd(base.Handle);
			uint uint_ = ((this.uint_0 != 0) ? this.uint_0 : ((uint)graphics.DpiX));
			if (this.uint_0 != 0)
			{
				if ((float)this.uint_0 != graphics.DpiX && this.Font.IsSystemFont)
				{
					this.Font = Class467.smethod_1(this.uint_0);
				}
				else
				{
					Class468.smethod_2(this.uint_0, graphics, this);
				}
			}
			graphics.Dispose();
			if (this.intptr_1 == IntPtr.Zero)
			{
				this.intptr_1 = this.Font.ToHfont();
			}
			Class429.SendMessage_2(base.Handle, 48, this.intptr_1, 0);
			base.OnHandleCreated(eventArgs_0);
			if (this.TabPages.Count > 0)
			{
				foreach (ContextualTabGroup item in this.contextualTabGroupCollection_0)
				{
					if (item.Visible)
					{
						continue;
					}
					foreach (RibbonTab contextualTab in item.ContextualTabs)
					{
						contextualTab.Int32_0 = this.TabPages.IndexOf(contextualTab);
						if (contextualTab.Int32_0 == base.SelectedIndex)
						{
							base.SelectedIndex = -1;
						}
						this.TabPages.Remove(contextualTab);
					}
				}
				if (base.SelectedIndex == 0 && this.bool_4)
				{
					base.SelectedIndex = -1;
				}
				if (!this.bool_1 && base.SelectedIndex == -1)
				{
					this.method_7();
				}
				if (base.SelectedTab != null)
				{
					(base.SelectedTab as RibbonTab).Boolean_0 = true;
					if (this.textControl_0 != null)
					{
						(base.SelectedTab as RibbonTab).vmethod_0();
					}
				}
			}
			this.method_0(uint_);
		}

		private void method_0(uint uint_1)
		{
			int val = DpiConverter.DPI96toPix(116, uint_1);
			int num = DpiConverter.DPI96toPix(200, uint_1);
			int num2 = DpiConverter.DPI96toPix(40, uint_1);
			int num3 = DpiConverter.DPI96toPix(10, uint_1);
			int num4 = 0;
			if (this.TabPages.Count > 0)
			{
				Rectangle tabRect = base.GetTabRect(0);
				Rectangle rectangle_ = new Rectangle(0, 0, 100, 100);
				Class429.Struct83 struct83_ = new Class429.Struct83(rectangle_);
				Class429.SendMessage_3(base.Handle, 4904, 0, ref struct83_);
				this.padding_0 = new Padding(struct83_.int_0 - rectangle_.Left, struct83_.int_1 - rectangle_.Top - tabRect.Bottom, rectangle_.Right - struct83_.int_2, rectangle_.Bottom - struct83_.int_3);
				TabPageCollection tabPageCollection = this.TabPages;
				for (int i = (this.bool_4 ? 1 : 0); i < tabPageCollection.Count; i++)
				{
					Control.ControlCollection controls = tabPageCollection[i].Controls;
					if (controls.Count > 0)
					{
						Control control = controls[0];
						if (control != null)
						{
							num4 = Math.Max(num4, control.PreferredSize.Height);
						}
					}
				}
				num4 += tabRect.Bottom + this.padding_0.Top + this.padding_0.Bottom;
				if (this.bool_1)
				{
					base.Height = tabRect.Bottom + 1;
					this.int_8 = Math.Max(num4, val);
					this.method_29();
				}
				else
				{
					base.Height = Math.Max(num4, val);
				}
			}
			this.ribbonGroup_0.MinimumSize = new Size(num, num2);
			this.ribbonGroup_1.MinimumSize = new Size(num, num2);
			Class429.SendMessage_1(base.Handle, 4907, 0, Class429.smethod_3(num3, 0));
		}

		private void method_1(uint uint_1)
		{
			this.ribbonGroup_0.Class498_0.method_0(new PointF(uint_1, uint_1));
			foreach (IRibbonItem ribbonItem3 in this.ribbonGroup_0.RibbonItems)
			{
				ribbonItem3.AwareOfDPI(new PointF(uint_1, uint_1));
			}
			foreach (IRibbonItem ribbonItem4 in this.ribbonGroup_1.RibbonItems)
			{
				ribbonItem4.AwareOfDPI(new PointF(uint_1, uint_1));
			}
		}

		protected override void OnControlAdded(ControlEventArgs controlEventArgs_0)
		{
			base.OnControlAdded(controlEventArgs_0);
			RibbonTab ribbonTab = controlEventArgs_0.Control as RibbonTab;
			if (ribbonTab != null)
			{
				ribbonTab.TextControl_0 = this.textControl_0;
			}
		}

		protected override void OnFontChanged(EventArgs eventArgs_0)
		{
			base.OnFontChanged(eventArgs_0);
			if (base.IsHandleCreated)
			{
				if (this.intptr_1 != IntPtr.Zero)
				{
					Class429.DeleteObject(this.intptr_1);
				}
				this.intptr_1 = this.Font.ToHfont();
				Class429.SendMessage_2(base.Handle, 48, this.intptr_1, 1);
			}
		}

		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			base.OnMouseUp(mevent);
			if (!this.bool_1 && this.Focused)
			{
				this.method_6();
			}
		}

		protected override void OnMouseWheel(MouseEventArgs mouseEventArgs_0)
		{
			base.OnMouseWheel(mouseEventArgs_0);
			this.method_2(base.PointToScreen(mouseEventArgs_0.Location), mouseEventArgs_0.Delta);
		}

		public int method_2(Point point_0, int int_9)
		{
			int result = 0;
			Rectangle rectangle = new Rectangle(default(Point), base.Size);
			point_0 = base.PointToClient(point_0);
			if (rectangle.Contains(point_0))
			{
				int count = this.TabPages.Count;
				int num = base.SelectedIndex;
				if (num >= 0 && count > ((!this.bool_4) ? 1 : 2))
				{
					Form form = base.Parent as Form;
					if (form != null)
					{
						Control activeControl = form.ActiveControl;
						if (int_9 < 0)
						{
							if (num < count - 1)
							{
								base.SelectedIndex = num + 1;
								if (activeControl != form.ActiveControl)
								{
									form.ActiveControl = activeControl;
								}
							}
						}
						else if (int_9 > 0 && num > (this.bool_4 ? 1 : 0))
						{
							base.SelectedIndex = num - 1;
							if (activeControl != form.ActiveControl)
							{
								form.ActiveControl = activeControl;
							}
						}
					}
				}
				result = 1;
			}
			return result;
		}

		public bool ShouldSerializeDisplayColors()
		{
			return !this.colors_0.method_2();
		}

		public void ResetDisplayColors()
		{
			this.colors_0.method_1();
		}

		protected override void OnDeselected(TabControlEventArgs tabControlEventArgs_0)
		{
			base.OnDeselected(tabControlEventArgs_0);
			if (tabControlEventArgs_0.TabPage != null)
			{
				(tabControlEventArgs_0.TabPage as RibbonTab).Boolean_0 = false;
			}
		}

		protected override void OnSelecting(TabControlCancelEventArgs tabControlCancelEventArgs_0)
		{
			base.OnSelecting(tabControlCancelEventArgs_0);
			if (this.bool_4 && tabControlCancelEventArgs_0.TabPageIndex == 0 && this.ribbonDropDown_0 != null && !this.ribbonDropDown_0.Visible && !base.DesignMode)
			{
				Rectangle tabRect = base.GetTabRect(0);
				this.tableLayoutPanel_0.RowStyles[0].Height = tabRect.Height;
				this.tableLayoutPanel_0.RowStyles[2].Height = tabRect.Height;
				TabPage tabPage = this.TabPages[0];
				Class498 @class = tabPage.Controls[0] as Class498;
				if (@class != null)
				{
					@class.Font = this.Font;
					tabPage.Controls.Remove(@class);
					@class.Margin = new Padding(5);
					this.tableLayoutPanel_0.Controls.Add(@class, 0, 1);
				}
				this.ribbonDropDown_0.BackColor = this.DisplayColors.ApplicationMenuColor;
				Point position = base.Parent.PointToScreen(base.Location);
				this.ribbonDropDown_0.Show(position, this.RightToLeftLayout ? ToolStripDropDownDirection.BelowLeft : ToolStripDropDownDirection.BelowRight);
				tabControlCancelEventArgs_0.Cancel = true;
			}
			else if (tabControlCancelEventArgs_0.TabPage != null)
			{
				(tabControlCancelEventArgs_0.TabPage as RibbonTab).Boolean_0 = true;
				if (this.textControl_0 != null)
				{
					(tabControlCancelEventArgs_0.TabPage as RibbonTab).vmethod_0();
				}
			}
		}

		private void method_3()
		{
			if (this.ribbonDropDown_0 == null)
			{
				this.ribbonTab_0.Text = this.resourceManager_0.GetString("Ribbon_File");
				this.ribbonTab_0.KeyTip = this.resourceManager_0.GetString("KEYTIP_FileTab");
				this.ribbonGroup_1.ShowSeperator = false;
				this.ribbonTab_0.RibbonGroups.Add(this.ribbonGroup_0);
				this.ribbonTab_0.RibbonGroups.Add(this.ribbonGroup_1);
				this.ribbonDropDown_0 = this.method_4();
			}
			if (this.TabPages.Count == 0)
			{
				this.TabPages.Add(this.ribbonTab_0);
			}
			else
			{
				this.TabPages.Insert(0, this.ribbonTab_0);
			}
		}

		private RibbonDropDown method_4()
		{
			this.tableLayoutPanel_0 = new TableLayoutPanel();
			this.tableLayoutPanel_0.ColumnCount = 1;
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
			this.tableLayoutPanel_0.Margin = new Padding(0);
			this.tableLayoutPanel_0.RowCount = 3;
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.AutoSize));
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
			this.tableLayoutPanel_0.AutoSize = true;
			this.tableLayoutPanel_0.BackColor = Color.Transparent;
			ToolStripControlHost value = new ToolStripControlHost(this.tableLayoutPanel_0);
			RibbonDropDown ribbonDropDown = new Class470(this);
			ribbonDropDown.Padding = new Padding(0);
			ribbonDropDown.Items.Add(value);
			ribbonDropDown.Closed += method_5;
			ribbonDropDown.RightToLeft = this.RightToLeft;
			return ribbonDropDown;
		}

		private void method_5(object sender, ToolStripDropDownClosedEventArgs e)
		{
			foreach (Control control in this.tableLayoutPanel_0.Controls)
			{
				if (this.tableLayoutPanel_0.GetRow(control) == 1)
				{
					Class498 @class = control as Class498;
					if (@class != null)
					{
						@class.Margin = new Padding(0);
						this.tableLayoutPanel_0.Controls.Remove(control);
						this.TabPages[0].Controls.Add(@class);
					}
				}
			}
			if (this.bool_0)
			{
				Rectangle tabRect = base.GetTabRect(0);
				base.Invalidate(tabRect);
			}
			if (this.bool_1 && base.SelectedIndex == 0)
			{
				base.SelectedIndex = -1;
			}
			if (this.enum135_0 == Enum135.const_0)
			{
				this.method_6();
			}
			if (base.SelectedTab != null)
			{
				(base.SelectedTab as RibbonTab).Boolean_0 = true;
			}
		}

		private void method_6()
		{
			if (this.intptr_0 != IntPtr.Zero)
			{
				Class429.SetFocus(this.intptr_0);
				this.intptr_0 = IntPtr.Zero;
			}
		}

		public void method_7()
		{
			int count = this.TabPages.Count;
			if (this.bool_4 && count > 1)
			{
				base.SelectedIndex = 1;
			}
			if (!this.bool_4 && count > 0)
			{
				base.SelectedIndex = 0;
			}
		}

		protected override Control.ControlCollection CreateControlsInstance()
		{
			return new ControlCollection(this);
		}

		public static Color[] smethod_0()
		{
			Color[] array = new Color[7];
			switch (Environment.OSVersion.Version.Major)
			{
			case 10:
			{
				ref Color reference36 = ref array[0];
				reference36 = Color.FromArgb(245, 246, 247);
				ref Color reference37 = ref array[1];
				reference37 = Color.FromArgb(245, 246, 247);
				ref Color reference38 = ref array[2];
				reference38 = Color.FromArgb(255, 255, 255);
				ref Color reference39 = ref array[3];
				reference39 = Color.FromArgb(246, 247, 248);
				ref Color reference40 = ref array[4];
				reference40 = Color.FromArgb(25, 121, 202);
				ref Color reference41 = ref array[5];
				reference41 = Color.FromArgb(41, 140, 225);
				ref Color reference42 = ref array[6];
				reference42 = Color.FromArgb(218, 219, 220);
				break;
			}
			case 5:
				if (VisualStyleRenderer.IsSupported)
				{
					ref Color reference22 = ref array[0];
					reference22 = Color.FromArgb(220, 231, 245);
					ref Color reference23 = ref array[1];
					reference23 = Color.FromArgb(251, 253, 255);
					ref Color reference24 = ref array[2];
					reference24 = Color.FromArgb(223, 233, 245);
					ref Color reference25 = ref array[3];
					reference25 = Color.FromArgb(239, 245, 250);
					ref Color reference26 = ref array[4];
					reference26 = Color.FromArgb(26, 64, 136);
					ref Color reference27 = ref array[5];
					reference27 = Color.FromArgb(71, 125, 204);
					ref Color reference28 = ref array[6];
					reference28 = Color.FromArgb(186, 201, 219);
				}
				else
				{
					ref Color reference29 = ref array[0];
					reference29 = Color.FromArgb(212, 208, 200);
					ref Color reference30 = ref array[1];
					reference30 = Color.FromArgb(212, 208, 200);
					ref Color reference31 = ref array[2];
					reference31 = Color.FromArgb(212, 208, 200);
					ref Color reference32 = ref array[3];
					reference32 = Color.FromArgb(235, 233, 229);
					ref Color reference33 = ref array[4];
					reference33 = Color.FromArgb(26, 64, 136);
					ref Color reference34 = ref array[5];
					reference34 = Color.FromArgb(71, 125, 204);
					ref Color reference35 = ref array[6];
					reference35 = Color.FromArgb(166, 166, 166);
				}
				break;
			case 6:
				switch (Environment.OSVersion.Version.Minor)
				{
				case 0:
				case 1:
				{
					ref Color reference15 = ref array[0];
					reference15 = Color.FromArgb(220, 231, 245);
					ref Color reference16 = ref array[1];
					reference16 = Color.FromArgb(251, 253, 255);
					ref Color reference17 = ref array[2];
					reference17 = Color.FromArgb(223, 233, 245);
					ref Color reference18 = ref array[3];
					reference18 = Color.FromArgb(239, 245, 250);
					ref Color reference19 = ref array[4];
					reference19 = Color.FromArgb(26, 64, 136);
					ref Color reference20 = ref array[5];
					reference20 = Color.FromArgb(71, 125, 204);
					ref Color reference21 = ref array[6];
					reference21 = Color.FromArgb(186, 201, 219);
					break;
				}
				case 2:
				{
					ref Color reference8 = ref array[0];
					reference8 = Color.FromArgb(245, 246, 247);
					ref Color reference9 = ref array[1];
					reference9 = Color.FromArgb(245, 246, 247);
					ref Color reference10 = ref array[2];
					reference10 = Color.FromArgb(255, 255, 255);
					ref Color reference11 = ref array[3];
					reference11 = Color.FromArgb(246, 247, 248);
					ref Color reference12 = ref array[4];
					reference12 = Color.FromArgb(25, 121, 202);
					ref Color reference13 = ref array[5];
					reference13 = Color.FromArgb(41, 140, 225);
					ref Color reference14 = ref array[6];
					reference14 = Color.FromArgb(218, 219, 220);
					break;
				}
				default:
				{
					ref Color reference = ref array[0];
					reference = Color.FromArgb(245, 246, 247);
					ref Color reference2 = ref array[1];
					reference2 = Color.FromArgb(245, 246, 247);
					ref Color reference3 = ref array[2];
					reference3 = Color.FromArgb(255, 255, 255);
					ref Color reference4 = ref array[3];
					reference4 = Color.FromArgb(246, 247, 248);
					ref Color reference5 = ref array[4];
					reference5 = Color.FromArgb(25, 121, 202);
					ref Color reference6 = ref array[5];
					reference6 = Color.FromArgb(41, 140, 225);
					ref Color reference7 = ref array[6];
					reference7 = Color.FromArgb(218, 219, 220);
					break;
				}
				}
				break;
			}
			return array;
		}

		protected override void OnKeyDown(KeyEventArgs keyEventArgs_0)
		{
			if (this.Focused && keyEventArgs_0.KeyCode == Keys.Escape)
			{
				if (this.enum135_0 > Enum135.const_0)
				{
					this.enum135_0--;
					this.string_0 = string.Empty;
					this.method_11();
				}
				if (this.enum135_0 == Enum135.const_0)
				{
					this.method_18();
					this.method_10();
				}
			}
			if ((keyEventArgs_0.KeyCode == Keys.Right || keyEventArgs_0.KeyCode == Keys.Left) && this.enum135_0 > Enum135.const_0)
			{
				this.enum135_0 = Enum135.const_0;
				this.string_0 = string.Empty;
				this.method_18();
				this.method_11();
			}
			base.OnKeyDown(keyEventArgs_0);
		}

		protected override void OnKeyPress(KeyPressEventArgs keyPressEventArgs_0)
		{
			if (this.Focused && char.IsLetterOrDigit(keyPressEventArgs_0.KeyChar))
			{
				if (this.method_14(keyPressEventArgs_0.KeyChar))
				{
					this.method_11();
				}
				else
				{
					Class429.MessageBeep(0);
					this.method_10();
				}
			}
			base.OnKeyPress(keyPressEventArgs_0);
		}

		private void method_8(IntPtr intptr_2)
		{
			if (this.enum135_0 != 0)
			{
				RibbonDropDown ribbonDropDown = Control.FromHandle(intptr_2) as RibbonDropDown;
				if (ribbonDropDown != null && ribbonDropDown.Boolean_0)
				{
					this.method_11();
				}
				else
				{
					this.enum135_0 = Enum135.const_0;
					this.string_0 = string.Empty;
					this.method_18();
					this.method_10();
				}
			}
			if (this.textControl_0 == null || !this.textControl_0.IsHandleCreated)
			{
				return;
			}
			StringBuilder stringBuilder = new StringBuilder(256);
			if (Class429.GetClassName(this.textControl_0.Handle, stringBuilder, stringBuilder.Capacity) == 0)
			{
				return;
			}
			StringBuilder stringBuilder2 = new StringBuilder(256);
			if (Class429.GetClassName(intptr_2, stringBuilder2, stringBuilder2.Capacity) != 0)
			{
				string text = stringBuilder.ToString();
				if (text.Equals(stringBuilder2.ToString()))
				{
					this.intptr_0 = intptr_2;
				}
			}
		}

		private void method_9(IntPtr intptr_2)
		{
			if (this.enum135_0 != 0)
			{
				RibbonDropDown ribbonDropDown = Control.FromHandle(intptr_2) as RibbonDropDown;
				Control control = base.Parent;
				this.string_0 = string.Empty;
				if (ribbonDropDown == null || !ribbonDropDown.Boolean_0)
				{
					this.enum135_0 = Enum135.const_0;
					this.method_18();
				}
				control?.Invalidate(invalidateChildren: true);
			}
		}

		public void method_10()
		{
			this.method_6();
		}

		public void method_11()
		{
			Control control = base.Parent;
			if (control != null)
			{
				control.Invalidate(invalidateChildren: true);
				control.Update();
			}
			switch (this.enum135_0)
			{
			case Enum135.const_1:
				this.method_13(this.string_0, null);
				break;
			case Enum135.const_2:
			{
				RibbonTab ribbonTab = this.TabPages[base.SelectedIndex] as RibbonTab;
				if (ribbonTab != null)
				{
					KeyTipHelper.DrawKeyTips(ribbonTab, this.string_0, null);
				}
				break;
			}
			}
		}

		public void method_12(IntPtr intptr_2)
		{
			if (this.enum135_0 == Enum135.const_0)
			{
				this.method_13(string.Empty, null);
				return;
			}
			this.enum135_0 = Enum135.const_0;
			this.string_0 = string.Empty;
			Class429.SendMessage_1(intptr_2, 31, 0, 0);
			this.method_10();
		}

		private void method_13(string string_1, Graphics graphics_0)
		{
			VisualStyleRenderer renderer = new VisualStyleRenderer(VisualStyleElement.ToolTip.Standard.Normal);
			IntPtr hdc = IntPtr.Zero;
			Graphics graphics = graphics_0;
			int count = this.TabPages.Count;
			if (graphics_0 == null)
			{
				hdc = Class429.GetDCEx(base.Handle, IntPtr.Zero, 32u);
				graphics = Graphics.FromHdc(hdc);
			}
			for (int i = 0; i < count; i++)
			{
				string keyTip = ((RibbonTab)this.TabPages[i]).KeyTip;
				if (string_1 == string.Empty || keyTip.StartsWith(string_1))
				{
					KeyTipHelper.DrawKeyTip(graphics, base.GetTabRect(i), keyTip, renderer, this.Font);
				}
			}
			RibbonForm ribbonForm = base.Parent as RibbonForm;
			if (ribbonForm != null && ribbonForm.HasQuickAccessToolbar)
			{
				DockStyle dock = ribbonForm.toolStrip_0.Dock;
				int num = ribbonForm.toolStrip_0.Items.Count - ((dock != 0) ? 1 : 2);
				int num2 = ((dock == DockStyle.None) ? 1 : 0);
				int num3 = 1;
				while (num2 < num)
				{
					ToolStripItem toolStripItem = ribbonForm.toolStrip_0.Items[num2];
					string text = ((num3 < 10) ? num3.ToString() : ("0" + (num3 - 9)));
					if (string_1 == string.Empty || text.StartsWith(string_1))
					{
						Rectangle bounds = toolStripItem.Bounds;
						bounds.Offset(base.PointToClient(ribbonForm.toolStrip_0.PointToScreen(default(Point))));
						KeyTipHelper.DrawKeyTip(graphics, bounds, text, renderer, this.Font);
					}
					num2++;
					num3++;
				}
			}
			if (graphics_0 == null)
			{
				Class429.ReleaseDC(base.Handle, hdc);
				graphics.Dispose();
			}
		}

		public bool method_14(char char_0)
		{
			bool flag = false;
			bool result = false;
			switch (this.enum135_0)
			{
			case Enum135.const_0:
			case Enum135.const_1:
				if (result = this.method_15(char_0))
				{
					if (this.string_0 == string.Empty && !this.bool_1)
					{
						flag = true;
						if (base.SelectedIndex == 0 && this.bool_4)
						{
							flag = false;
						}
						if (this.ribbonDropDown_0 != null && this.ribbonDropDown_0.Visible)
						{
							flag = false;
						}
					}
					this.enum135_0 = ((!flag) ? Enum135.const_1 : Enum135.const_2);
				}
				else
				{
					result = this.method_16(char_0);
				}
				break;
			case Enum135.const_2:
			{
				RibbonTab ribbonTab = this.TabPages[base.SelectedIndex] as RibbonTab;
				if (ribbonTab != null)
				{
					result = KeyTipHelper.SelectRibbonItemFromKeyTip(ribbonTab, char_0, ref this.string_0, out var selected);
					if (selected != null && this.Focused && (selected.GetType() == typeof(RibbonButton) || selected.GetType() == typeof(RibbonToggleButton)))
					{
						this.method_10();
					}
				}
				break;
			}
			}
			return result;
		}

		private bool method_15(char char_0)
		{
			int num = 0;
			int num2 = -1;
			string text = this.string_0 + char.ToUpper(char_0);
			int count = this.TabPages.Count;
			for (int i = 0; i < count; i++)
			{
				string keyTip = ((RibbonTab)this.TabPages[i]).KeyTip;
				if (keyTip != null && keyTip.StartsWith(text))
				{
					num2 = i;
					num++;
					if (keyTip.Length == 1)
					{
						break;
					}
				}
			}
			if (num > 0)
			{
				if (num == 1 && base.SelectedIndex != num2)
				{
					if (num2 == 0 && this.bool_4 && this.ribbonDropDown_0 != null)
					{
						this.ribbonDropDown_0.Boolean_0 = true;
					}
					if ((num2 > 0 || (num2 == 0 && !this.bool_4)) && this.bool_1 && this.ribbonDropDown_1 != null)
					{
						this.ribbonDropDown_1.Boolean_0 = true;
					}
					base.SelectedIndex = num2;
					this.string_0 = string.Empty;
				}
				else
				{
					Form form = base.Parent as Form;
					if (form != null)
					{
						form.ActiveControl = this;
					}
					this.string_0 = ((num == 1) ? string.Empty : text);
				}
			}
			return num > 0;
		}

		private bool method_16(char char_0)
		{
			int num = 0;
			int index = -1;
			string value = this.string_0 + char.ToUpper(char_0);
			RibbonForm ribbonForm = base.Parent as RibbonForm;
			if (ribbonForm != null && ribbonForm.HasQuickAccessToolbar)
			{
				DockStyle dock = ribbonForm.toolStrip_0.Dock;
				int num2 = ribbonForm.toolStrip_0.Items.Count - ((dock != 0) ? 1 : 2);
				int num3 = ((dock == DockStyle.None) ? 1 : 0);
				int num4 = 1;
				while (num3 < num2)
				{
					string text = ((num4 < 10) ? num4.ToString() : ("0" + (num4 - 9)));
					if (text.StartsWith(value))
					{
						index = num3;
						num++;
						if (text.Length == 1)
						{
							break;
						}
					}
					num3++;
					num4++;
				}
				if (num > 0)
				{
					if (num == 1)
					{
						ToolStripItem toolStripItem = ribbonForm.toolStrip_0.Items[index];
						if (toolStripItem is ToolStripDropDownItem)
						{
							((ToolStripDropDownItem)toolStripItem).ShowDropDown();
						}
						else
						{
							toolStripItem.PerformClick();
						}
						this.enum135_0 = Enum135.const_0;
						this.string_0 = string.Empty;
						this.method_18();
						if (this.Focused)
						{
							this.method_10();
						}
					}
					else
					{
						ribbonForm.ActiveControl = this;
						this.string_0 = value;
					}
				}
			}
			return num > 0;
		}

		public void method_17()
		{
			if (base.IsHandleCreated && this.enum135_0 != 0)
			{
				Class429.SetCapture(base.Handle);
			}
		}

		public void method_18()
		{
			if (base.IsHandleCreated && Class429.GetCapture() == base.Handle)
			{
				Class429.ReleaseCapture();
			}
		}

		protected override void OnPaint(PaintEventArgs pea)
		{
			base.OnPaint(pea);
			if (!this.bool_0)
			{
				return;
			}
			Color menuColor = this.DisplayColors.MenuColor;
			Graphics graphics = pea.Graphics;
			Rectangle clientRectangle = base.ClientRectangle;
			if (this.TabPages.Count == 0)
			{
				Class429.smethod_16(graphics, clientRectangle, menuColor);
				return;
			}
			Rectangle tabRect = base.GetTabRect(0);
			Pen pen = new Pen(this.color_0[6]);
			clientRectangle.Height = tabRect.Bottom;
			Class429.smethod_16(graphics, clientRectangle, menuColor);
			if (base.ClientRectangle.Height > clientRectangle.Height)
			{
				Rectangle rect = new Rectangle(0, clientRectangle.Height, clientRectangle.Width, base.ClientRectangle.Height - clientRectangle.Height - 1);
				if (rect.Height > 0)
				{
					Color highlightTabColor = this.DisplayColors.HighlightTabColor;
					Color tabColor = this.DisplayColors.TabColor;
					LinearGradientBrush brush = new LinearGradientBrush(rect, highlightTabColor, tabColor, LinearGradientMode.Vertical);
					graphics.FillRectangle(brush, rect);
				}
				if (this.ribbonDropDown_1 != null && this.ribbonDropDown_1.Visible)
				{
					graphics.DrawLine(new Pen(menuColor), rect.Left, rect.Top, rect.Right, rect.Top);
				}
				else
				{
					graphics.DrawLine(pen, rect.Left, rect.Top, rect.Right, rect.Top);
					graphics.DrawLine(pen, rect.Left, rect.Bottom, rect.Right, rect.Bottom);
				}
			}
			this.method_19(graphics, pea.ClipRectangle);
			foreach (ContextualTabGroup contextualTabGroup in this.ContextualTabGroups)
			{
				if (contextualTabGroup.Visible)
				{
					Rectangle rectangle = this.method_23(contextualTabGroup);
					if (!rectangle.IsEmpty)
					{
						Class429.smethod_18(graphics, rectangle.Left, 0, rectangle.Left, rectangle.Bottom, this.color_0[6]);
						Class429.smethod_18(graphics, rectangle.Right, 0, rectangle.Right, rectangle.Bottom, this.color_0[6]);
					}
				}
			}
			if (this.Focused && this.enum135_0 == Enum135.const_1)
			{
				this.method_13(this.string_0, graphics);
			}
		}

		private void method_19(Graphics graphics_0, Rectangle rectangle_0)
		{
			if (!base.Visible)
			{
				return;
			}
			int num = base.SelectedIndex;
			int tabCount = base.TabCount;
			if (tabCount == 0)
			{
				return;
			}
			this.int_5 = this.method_25();
			VisualStyleRenderer visualStyleRenderer = new VisualStyleRenderer(VisualStyleElement.Tab.TabItem.Normal);
			for (int i = 0; i < tabCount; i++)
			{
				Rectangle tabRect = base.GetTabRect(i);
				tabRect.Inflate(-1, 0);
				if (tabRect.Right >= 3 && tabRect.IntersectsWith(rectangle_0))
				{
					TabItemState tabItemState_ = TabItemState.Normal;
					if (i == num)
					{
						tabItemState_ = TabItemState.Selected;
						tabRect.Height++;
					}
					else if (i == this.int_5)
					{
						tabItemState_ = TabItemState.Hot;
					}
					else if (i == 0 && this.bool_4)
					{
						tabItemState_ = TabItemState.Selected;
					}
					if (i == 0 && this.bool_4)
					{
						this.method_21(graphics_0, tabRect, tabItemState_);
						continue;
					}
					visualStyleRenderer.SetParameters(visualStyleRenderer.Class, visualStyleRenderer.Part, (int)tabItemState_);
					this.method_20(graphics_0, i, tabRect, visualStyleRenderer);
				}
			}
		}

		private void method_20(Graphics graphics_0, int int_9, Rectangle rectangle_0, VisualStyleRenderer visualStyleRenderer_0)
		{
			if (this.class495_0.Int32_0 > 0 && rectangle_0.X >= this.class495_0.Int32_0)
			{
				return;
			}
			TabPage tabPage = this.TabPages[int_9];
			TabItemState tabItemState = (TabItemState)visualStyleRenderer_0.State;
			switch (tabItemState)
			{
			default:
				Class429.smethod_16(graphics_0, rectangle_0, this.DisplayColors.MenuColor);
				break;
			case TabItemState.Selected:
			{
				Rectangle rectangle_ = new Rectangle(rectangle_0.Location, rectangle_0.Size);
				Class429.smethod_17(graphics_0, rectangle_, this.color_0[6]);
				rectangle_.Inflate(-1, -1);
				rectangle_.Height++;
				Class429.smethod_16(graphics_0, rectangle_, this.DisplayColors.HighlightTabColor);
				break;
			}
			case TabItemState.Hot:
			case TabItemState.Disabled:
				visualStyleRenderer_0.DrawBackground(graphics_0, rectangle_0);
				break;
			}
			System.Drawing.Image image = this.method_24(tabPage.ImageIndex, tabPage.ImageKey);
			if (image != null)
			{
				bool flag = tabItemState == TabItemState.Selected;
				Point point = new Point(flag ? 8 : 6, 2);
				int num = point.X + image.Width;
				if (base.Alignment == TabAlignment.Bottom)
				{
					point.Y = rectangle_0.Bottom - image.Height - (flag ? 4 : 2);
				}
				if (this.RightToLeftLayout)
				{
					point.X = rectangle_0.Right - num;
				}
				graphics_0.DrawImageUnscaled(image, point);
				rectangle_0.X += num;
				rectangle_0.Width -= num;
			}
			TextRenderer.DrawText(graphics_0, tabPage.Text, this.Font, rectangle_0, visualStyleRenderer_0.GetColor(ColorProperty.TextColor), TextFormatFlags.HorizontalCenter | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter);
		}

		public void method_21(Graphics graphics_0, Rectangle rectangle_0, TabItemState tabItemState_0)
		{
			if (this.class495_0.Int32_0 <= 0 || rectangle_0.X < this.class495_0.Int32_0)
			{
				switch (tabItemState_0)
				{
				case TabItemState.Hot:
				case TabItemState.Selected:
				{
					Rectangle rectangle_ = new Rectangle(rectangle_0.Location, rectangle_0.Size);
					Class429.smethod_17(graphics_0, rectangle_, this.color_0[6]);
					rectangle_.Inflate(-1, -1);
					rectangle_.Height++;
					Class429.smethod_16(graphics_0, rectangle_, (tabItemState_0 == TabItemState.Hot) ? this.DisplayColors.ApplicationMenuTabHighlightColor : this.DisplayColors.ApplicationMenuTabColor);
					break;
				}
				}
				TextRenderer.DrawText(graphics_0, this.TabPages[0].Text, this.Font, rectangle_0, Color.White, TextFormatFlags.HorizontalCenter | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter);
			}
		}

		public void method_22(Graphics graphics_0, ContextualTabGroup contextualTabGroup_0, Rectangle rectangle_0)
		{
			Pen pen = new Pen(this.color_0[6]);
			Brush brush = new SolidBrush(contextualTabGroup_0.BackColor);
			rectangle_0.Height--;
			graphics_0.FillRectangle(brush, rectangle_0);
			graphics_0.DrawRectangle(pen, rectangle_0);
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddString(contextualTabGroup_0.Header, this.Font.FontFamily, (int)this.Font.Style, DpiConverter.PointToPix(this.Font.Size, graphics_0.DpiY), rectangle_0, new StringFormat(StringFormatFlags.NoWrap)
			{
				Alignment = StringAlignment.Center,
				LineAlignment = StringAlignment.Center,
				Trimming = StringTrimming.EllipsisCharacter
			});
			if (this.RightToLeftLayout)
			{
				Matrix matrix = new Matrix();
				matrix.Scale(-1f, 1f);
				graphicsPath.Transform(matrix);
				matrix.Reset();
				matrix.Translate(rectangle_0.Left + rectangle_0.Right, 0f);
				graphicsPath.Transform(matrix);
			}
			graphics_0.SmoothingMode = SmoothingMode.HighQuality;
			graphics_0.FillPath(Brushes.Black, graphicsPath);
			graphicsPath.Dispose();
		}

		public Rectangle method_23(ContextualTabGroup contextualTabGroup_0)
		{
			Rectangle rectangle = default(Rectangle);
			if (contextualTabGroup_0.Visible)
			{
				foreach (RibbonTab contextualTab in contextualTabGroup_0.ContextualTabs)
				{
					int num = this.TabPages.IndexOf(contextualTab);
					if (num > 0)
					{
						Rectangle tabRect = base.GetTabRect(num);
						rectangle = (rectangle.IsEmpty ? tabRect : Rectangle.Union(rectangle, tabRect));
					}
				}
				return rectangle;
			}
			return rectangle;
		}

		private System.Drawing.Image method_24(int int_9, string string_1)
		{
			if (base.ImageList == null)
			{
				return null;
			}
			if (int_9 > -1)
			{
				return base.ImageList.Images[int_9];
			}
			if (string_1.Length > 0)
			{
				return base.ImageList.Images[string_1];
			}
			return null;
		}

		private int method_25()
		{
			Class429.Struct94 @struct = default(Class429.Struct94);
			Point point = base.PointToClient(Control.MousePosition);
			@struct.struct82_0.int_0 = point.X;
			@struct.struct82_0.int_1 = point.Y;
			GCHandle gCHandle = GCHandle.Alloc(@struct, GCHandleType.Pinned);
			int result = (int)Class429.SendMessage_6(base.Handle, 4877, 0, gCHandle.AddrOfPinnedObject());
			gCHandle.Free();
			return result;
		}

		protected override void OnSelected(TabControlEventArgs tabControlEventArgs_0)
		{
			base.OnSelected(tabControlEventArgs_0);
			if (this.bool_1 && this.ribbonDropDown_1 != null && !this.ribbonDropDown_1.Visible && (tabControlEventArgs_0.TabPageIndex > 0 || (tabControlEventArgs_0.TabPageIndex == 0 && !this.bool_4)))
			{
				Rectangle tabRect = base.GetTabRect(0);
				Point position = base.Parent.PointToScreen(base.Location);
				position.Offset(0, tabRect.Bottom + 1);
				this.ribbonDropDown_1.Width = base.Width;
				this.method_27(tabControlEventArgs_0.TabPageIndex);
				this.ribbonDropDown_1.Show(position, this.RightToLeftLayout ? ToolStripDropDownDirection.BelowLeft : ToolStripDropDownDirection.BelowRight);
				this.method_26();
			}
		}

		private void method_26()
		{
			Rectangle rc = new Rectangle(0, base.GetTabRect(0).Bottom, base.Width, 1);
			base.Invalidate(rc);
		}

		private void ribbonDropDown_1_Closed(object sender, ToolStripDropDownClosedEventArgs e)
		{
			this.method_28(this.int_6);
			base.SelectedIndex = -1;
			this.method_26();
			if (this.enum135_0 == Enum135.const_0)
			{
				this.method_6();
			}
		}

		private void method_27(int int_9)
		{
			if (this.ribbonDropDown_1 != null)
			{
				this.ribbonDropDown_1.Padding = this.padding_0;
				TabPage tabPage = this.TabPages[int_9];
				Class498 @class = tabPage.Controls[0] as Class498;
				if (@class != null)
				{
					tabPage.Controls.Remove(@class);
					@class.Size = new Size(this.ribbonDropDown_1.Width - this.padding_0.Left - this.padding_0.Right, this.ribbonDropDown_1.Height - this.padding_0.Top - this.padding_0.Bottom);
					ToolStripControlHost toolStripControlHost = new ToolStripControlHost(@class);
					toolStripControlHost.AutoSize = false;
					this.ribbonDropDown_1.Items.Add(toolStripControlHost);
					this.int_6 = (this.int_7 = int_9);
				}
			}
		}

		private void method_28(int int_9)
		{
			if (this.ribbonDropDown_1 != null)
			{
				this.ribbonDropDown_1.Padding = new Padding(0);
				ToolStripControlHost toolStripControlHost = this.ribbonDropDown_1.Items[0] as ToolStripControlHost;
				this.ribbonDropDown_1.Items.Remove(toolStripControlHost);
				TabPage tabPage = this.TabPages[int_9];
				Class498 @class = toolStripControlHost.Control as Class498;
				if (@class != null)
				{
					tabPage.Controls.Add(@class);
				}
				this.int_6 = -1;
			}
		}

		private void method_29()
		{
			if (this.ribbonDropDown_1 == null)
			{
				Rectangle tabRect = base.GetTabRect(0);
				this.ribbonDropDown_1 = new RibbonDropDown(null);
				this.ribbonDropDown_1.AutoSize = false;
				this.ribbonDropDown_1.BackColor = this.DisplayColors.TabColor;
				this.ribbonDropDown_1.Closed += ribbonDropDown_1_Closed;
				this.ribbonDropDown_1.Font = this.Font;
				this.ribbonDropDown_1.Height = this.int_8 - tabRect.Bottom;
				this.ribbonDropDown_1.RightToLeft = this.RightToLeft;
			}
		}

		protected override void WndProc(ref Message message)
		{
			bool flag = true;
			switch (message.Msg)
			{
			case 7:
				this.method_8(message.WParam);
				break;
			case 8:
				this.method_9(message.WParam);
				break;
			case 1:
				this.uint_0 = Class429.smethod_15(message.HWnd);
				break;
			case 738:
			{
				uint num2 = Class429.smethod_15(message.HWnd);
				if (num2 != 0 && num2 != this.uint_0)
				{
					Class429.Struct83 struct83_ = default(Class429.Struct83);
					Class429.GetWindowRect(message.HWnd, ref struct83_);
					Class429.SetWindowPos(message.HWnd, IntPtr.Zero, 0, 0, (int)((struct83_.int_2 - struct83_.int_0) * num2 / (long)this.uint_0), (int)((struct83_.int_3 - struct83_.int_1) * num2 / (long)this.uint_0), 30u);
					Font font = this.Font;
					Font font3 = (this.Font = new Font(font.FontFamily, font.SizeInPoints * (float)num2 / (float)this.uint_0, font.Style, GraphicsUnit.Point, font.GdiCharSet, font.GdiVerticalFont));
					TabPage tabPage = this.TabPages[0];
					Class498 @class = tabPage.Controls[0] as Class498;
					if (@class != null)
					{
						@class.Font = this.Font;
					}
					this.uint_0 = num2;
					this.method_0(num2);
					this.method_1(num2);
					if (this.ribbonDropDown_0 != null)
					{
						if (this.ribbonDropDown_0.Visible)
						{
							this.ribbonDropDown_0.Close();
						}
						this.ribbonDropDown_0.Font = font3;
					}
					if (this.ribbonDropDown_1 != null)
					{
						Rectangle tabRect = base.GetTabRect(0);
						if (this.ribbonDropDown_1.Visible)
						{
							this.ribbonDropDown_1.Close();
						}
						this.ribbonDropDown_1.Font = font3;
						this.ribbonDropDown_1.Height = this.int_8 - tabRect.Bottom;
					}
				}
				flag = false;
				break;
			}
			case 739:
				this.method_0(this.uint_0);
				flag = false;
				break;
			case 528:
				if (Class429.smethod_5(message.WParam.ToInt32()) == 1)
				{
					StringBuilder stringBuilder = new StringBuilder(16);
					if (Class429.RealGetWindowClassW(message.LParam, stringBuilder, 16u) != 0 && stringBuilder.ToString() == "msctls_updown32")
					{
						this.class495_0.ReleaseHandle();
						this.class495_0.AssignHandle(message.LParam);
					}
				}
				break;
			case 33:
			{
				if (!this.bool_1 || this.ribbonDropDown_1 == null || !this.ribbonDropDown_1.Visible)
				{
					break;
				}
				int num = message.LParam.ToInt32();
				if (Class429.smethod_6(num) != 513)
				{
					break;
				}
				Point pt = base.PointToClient(Cursor.Position);
				int tabCount = base.TabCount;
				for (int i = 0; i < tabCount; i++)
				{
					if (base.GetTabRect(i).Contains(pt) && i != this.int_6)
					{
						this.ribbonDropDown_1.Close();
						base.SelectedIndex = i;
					}
				}
				break;
			}
			}
			if (flag)
			{
				base.WndProc(ref message);
			}
		}
	}
}
