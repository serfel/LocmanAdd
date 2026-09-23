using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class563 : ToolStripButton, IRibbonToolStripItem
	{
		private object object_0;

		private MethodInfo methodInfo_0;

		private PropertyInfo propertyInfo_0;

		private RibbonToggleButton ribbonToggleButton_0;

		private PointF pointF_0 = PointF.Empty;

		[CompilerGenerated]
		private bool bool_0;

		protected override ToolStripItemDisplayStyle DefaultDisplayStyle => ToolStripItemDisplayStyle.Image;

		bool IRibbonToolStripItem.IsToolStripItemAdded
		{
			[CompilerGenerated]
			get
			{
				return this.bool_0;
			}
			[CompilerGenerated]
			set
			{
				this.bool_0 = value;
			}
		}

		RibbonTab IRibbonToolStripItem.RibbonTab => Class517.smethod_19(this.object_0);

		object IRibbonToolStripItem.Parent => this.object_0;

		PointF IRibbonToolStripItem.DPI
		{
			get
			{
				if (this.pointF_0.IsEmpty)
				{
					if (this.object_0 is IRibbonItem)
					{
						return (this.object_0 as IRibbonItem).DPI;
					}
					if (this.object_0 is DialogBoxLauncher)
					{
						return (this.object_0 as DialogBoxLauncher).RibbonGroup_0.PointF_0;
					}
					return this.pointF_0;
				}
				return this.pointF_0;
			}
			set
			{
				if (this.pointF_0.X != value.X || this.pointF_0.Y != value.Y)
				{
					this.pointF_0 = value;
					if (this.ribbonToggleButton_0 != null && this.ribbonToggleButton_0.SmallIcon == null)
					{
						this.Image = (this.ribbonToggleButton_0.Checked ? Class517.Bitmap_3 : Class517.Bitmap_4);
					}
					else
					{
						Class517.smethod_57(this, (this.object_0 is DialogBoxLauncher) ? (this.object_0 as DialogBoxLauncher).ToolStripItemImage : (this.object_0 as RibbonButton).SmallIcon, this.pointF_0);
					}
				}
			}
		}

		internal Class563(object object_1)
		{
			if (object_1 is RibbonButton)
			{
				this.Text = (object_1 as RibbonButton).Text;
			}
			base.ImageScaling = ToolStripItemImageScaling.None;
			base.AutoToolTip = false;
			this.object_0 = object_1;
			this.methodInfo_0 = this.object_0.GetType().GetMethod("InvokeOnClick", BindingFlags.Instance | BindingFlags.NonPublic, Type.DefaultBinder, new Type[1] { typeof(EventArgs) }, null);
			this.propertyInfo_0 = this.object_0.GetType().GetProperty("ToolTip");
			this.ribbonToggleButton_0 = this.object_0 as RibbonToggleButton;
		}

		internal void method_0()
		{
			if (this.ribbonToggleButton_0 != null && !this.pointF_0.IsEmpty)
			{
				base.Checked = this.ribbonToggleButton_0.Checked;
				if (this.ribbonToggleButton_0.SmallIcon == null)
				{
					this.Image = (this.ribbonToggleButton_0.Checked ? Class517.Bitmap_3 : Class517.Bitmap_4);
				}
			}
		}

		protected override void OnClick(EventArgs eventArgs_0)
		{
			this.methodInfo_0.Invoke(this.object_0, new object[1] { eventArgs_0 });
		}

		protected override void OnMouseEnter(EventArgs eventArgs_0)
		{
			RibbonToolTip ribbonToolTip = (RibbonToolTip)this.propertyInfo_0.GetValue(this.object_0, null);
			ribbonToolTip.method_3(new Point(this.Bounds.X, this.Bounds.Bottom), base.Width, base.Parent, ((IRibbonToolStripItem)this).DPI);
			base.OnMouseEnter(eventArgs_0);
		}

		protected override void OnMouseLeave(EventArgs eventArgs_0)
		{
			RibbonToolTip ribbonToolTip = (RibbonToolTip)this.propertyInfo_0.GetValue(this.object_0, null);
			ribbonToolTip.method_2();
			base.OnMouseLeave(eventArgs_0);
		}

		protected override void OnParentChanged(ToolStrip oldParent, ToolStrip newParent)
		{
			if (newParent != null && !this.pointF_0.IsEmpty)
			{
				Class517.smethod_0(this.pointF_0);
				if (this.ribbonToggleButton_0 != null)
				{
					this.method_0();
				}
			}
			base.OnParentChanged(oldParent, newParent);
		}
	}
}
