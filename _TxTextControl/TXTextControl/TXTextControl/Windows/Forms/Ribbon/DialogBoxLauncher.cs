using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	[ToolboxItem(false)]
	[TypeConverter(typeof(ExpandableObjectConverter))]
	public class DialogBoxLauncher : Component, IEnabledItem, IRibbonToolStripItemProvider
	{
		private bool bool_0 = true;

		private bool bool_1 = true;

		private Padding padding_0;

		private int int_0;

		private ContextMenuStrip contextMenuStrip_0;

		private ImageAttributes imageAttributes_0;

		private RibbonGroup ribbonGroup_0;

		private RibbonToolTip ribbonToolTip_0;

		private ToolStripItem toolStripItem_0;

		[Obfuscation(Exclude = true)]
		private static readonly object EventClick = new object();

		[CompilerGenerated]
		private Rectangle rectangle_0;

		[CompilerGenerated]
		private Rectangle rectangle_1;

		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private Size size_0;

		[CompilerGenerated]
		private bool bool_2;

		[Category("Behavior")]
		public ContextMenuStrip ContextMenuStrip
		{
			get
			{
				return this.contextMenuStrip_0;
			}
			set
			{
				if (this.contextMenuStrip_0 != (this.contextMenuStrip_0 = value) && this.contextMenuStrip_0 != null)
				{
					this.contextMenuStrip_0.Opening += contextMenuStrip_0_Opening;
					this.contextMenuStrip_0.Closed += contextMenuStrip_0_Closed;
				}
			}
		}

		public bool Enabled
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				if (this.bool_0 != (this.bool_0 = value))
				{
					this.int_0 = ((!this.bool_0) ? 65 : 0);
					this.imageAttributes_0 = Class517.smethod_20(this.int_0);
					this.ribbonGroup_0.Invalidate();
				}
			}
		}

		[Category("Appearance")]
		[DefaultValue(null)]
		public System.Drawing.Image ToolStripItemImage
		{
			get
			{
				return this.toolStripItem_0.Image;
			}
			set
			{
				Class517.smethod_57(this.toolStripItem_0, value, this.ribbonGroup_0.class498_0.PointF_0);
			}
		}

		[Category("Misc")]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public RibbonToolTip ToolTip => this.ribbonToolTip_0;

		[Category("Behavior")]
		public bool Visible
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				if (this.bool_1 != (this.bool_1 = value) && this.ribbonGroup_0.IsHandleCreated)
				{
					this.method_0();
					this.ribbonGroup_0.Invalidate();
				}
			}
		}

		internal Rectangle Rectangle_0
		{
			[CompilerGenerated]
			get
			{
				return this.rectangle_0;
			}
			[CompilerGenerated]
			set
			{
				this.rectangle_0 = value;
			}
		}

		internal Rectangle Rectangle_1
		{
			[CompilerGenerated]
			get
			{
				return this.rectangle_1;
			}
			[CompilerGenerated]
			set
			{
				this.rectangle_1 = value;
			}
		}

		internal string String_0
		{
			[CompilerGenerated]
			get
			{
				return this.string_0;
			}
			[CompilerGenerated]
			set
			{
				this.string_0 = value;
			}
		}

		internal ImageAttributes ImageAttributes_0 => this.imageAttributes_0;

		internal Padding Padding_0
		{
			get
			{
				return this.padding_0;
			}
			set
			{
				this.padding_0 = value;
			}
		}

		internal RibbonGroup RibbonGroup_0 => this.ribbonGroup_0;

		internal Size Size_0
		{
			[CompilerGenerated]
			get
			{
				return this.size_0;
			}
			[CompilerGenerated]
			set
			{
				this.size_0 = value;
			}
		}

		internal ToolStripItem ToolStripItem_0
		{
			get
			{
				return this.toolStripItem_0;
			}
			set
			{
				this.toolStripItem_0 = value;
			}
		}

		bool IEnabledItem.Enabled
		{
			get
			{
				return this.Enabled;
			}
			set
			{
				this.Enabled = value;
			}
		}

		bool IRibbonToolStripItemProvider.IsAddToQuickAccessToolbarEnabled
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

		ToolStripItem IRibbonToolStripItemProvider.ToolStripItem
		{
			get
			{
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
				if (this.toolStripItem_0 != null)
				{
					result = (this.toolStripItem_0 as IRibbonToolStripItem).IsToolStripItemAdded;
				}
				return result;
			}
		}

		public event EventHandler Click
		{
			add
			{
				base.Events.AddHandler(DialogBoxLauncher.EventClick, value);
			}
			remove
			{
				base.Events.RemoveHandler(DialogBoxLauncher.EventClick, value);
			}
		}

		internal DialogBoxLauncher(RibbonGroup ribbonGroup)
		{
			this.ribbonGroup_0 = ribbonGroup;
			this.toolStripItem_0 = new Class563(this);
			this.ribbonToolTip_0 = new RibbonToolTip(ribbonGroup);
			this.int_0 = ((!this.bool_0) ? 65 : 0);
			this.imageAttributes_0 = Class517.smethod_20(this.int_0);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.ribbonToolTip_0.Dispose();
				this.toolStripItem_0.Dispose();
			}
			base.Dispose(disposing);
		}

		[Obfuscation(Exclude = true)]
		internal void InvokeOnClick(EventArgs eventArgs_0)
		{
			this.method_1(eventArgs_0);
		}

		internal void method_0()
		{
			int num = (this.bool_1 ? this.Size_0.Width : 0);
			this.ribbonGroup_0.Class515_0.Padding_1 = new Padding(this.ribbonGroup_0.Class515_0.Padding_0.Left, this.ribbonGroup_0.Class515_0.Padding_0.Top, this.ribbonGroup_0.Class515_0.Padding_0.Right + num, this.ribbonGroup_0.Class515_0.Padding_0.Bottom);
			if (this.bool_1)
			{
				this.ribbonGroup_0.Class515_0.method_2();
			}
		}

		private void contextMenuStrip_0_Opening(object sender, CancelEventArgs e)
		{
			this.ribbonGroup_0.Class515_0.Boolean_0 = true;
		}

		private void contextMenuStrip_0_Closed(object sender, ToolStripDropDownClosedEventArgs e)
		{
			this.ribbonGroup_0.Class515_0.Boolean_0 = false;
		}

		internal void method_1(EventArgs eventArgs_0)
		{
			((EventHandler)base.Events[DialogBoxLauncher.EventClick])?.Invoke(this, eventArgs_0);
		}
	}
}
