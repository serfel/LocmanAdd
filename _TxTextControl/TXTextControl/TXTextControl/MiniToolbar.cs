using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns21;
using TXTextControl.Windows.Forms.Ribbon;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl
{
	/// <summary>The MiniToolbar class is the base class of the built-in mini toolbars TextMiniToolbar and ObjectMiniToolbar of a Windows Forms TextControl.</summary>
	public class MiniToolbar : RibbonDropDown
	{
		private Class498 class498_0;

		protected TextControl m_txTextControl;

		private PointF pointF_0 = PointF.Empty;

		private bool bool_3 = true;

		[CompilerGenerated]
		private bool bool_4;

		/// <summary>Gets a collection of all ribbon groups in a MiniToolbar.</summary>
		public RibbonGroupCollection RibbonGroups => this.class498_0.RibbonGroupCollection_0;

		internal TextControl TextControl_0
		{
			get
			{
				return this.m_txTextControl;
			}
			set
			{
				this.m_txTextControl = value;
			}
		}

		internal bool Boolean_2
		{
			[CompilerGenerated]
			get
			{
				return this.bool_4;
			}
			[CompilerGenerated]
			set
			{
				this.bool_4 = value;
			}
		}

		internal Class498 Class498_0 => this.class498_0;

		/// <summary>Initializes a new instance of the MiniToolbar class.</summary>
		public MiniToolbar()
		{
			this.class498_0 = new Class498(this);
			this.Items.Add(new ToolStripControlHost(this.class498_0));
		}

		internal virtual void vmethod_0(PointF pointF_1)
		{
			if (pointF_1.X == this.pointF_0.X && pointF_1.Y == this.pointF_0.Y)
			{
				return;
			}
			float num;
			if (this.pointF_0.X == 0f)
			{
				Graphics graphics = base.CreateGraphics();
				num = pointF_1.X / graphics.DpiX;
				graphics.Dispose();
			}
			else
			{
				num = pointF_1.X / this.pointF_0.X;
			}
			this.pointF_0 = pointF_1;
			if (this.class498_0 == null)
			{
				return;
			}
			this.class498_0.method_0(pointF_1);
			foreach (RibbonGroup item in this.class498_0.RibbonGroupCollection_0)
			{
				item.Font = new Font(item.Font.FontFamily, item.Font.Size * num);
				item.Boolean_3 = true;
			}
		}

		internal void method_5()
		{
			if (this.bool_3)
			{
				base.uint_0 = Class429.smethod_15(this.m_txTextControl.Handle);
			}
			PointF pointF_ = new PointF(base.uint_0, base.uint_0);
			this.vmethod_0(pointF_);
			this.method_6();
		}

		private void method_6()
		{
			foreach (RibbonGroup ribbonGroup in this.RibbonGroups)
			{
				if (ribbonGroup.Boolean_3)
				{
					this.Class498_0.method_4();
					break;
				}
			}
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (!disposing || this.class498_0 == null)
			{
				return;
			}
			foreach (RibbonGroup item in this.class498_0.RibbonGroupCollection_0)
			{
				item.Dispose();
			}
		}

		protected override bool IsInputKey(Keys keyData)
		{
			return true;
		}

		protected override void OnOpening(CancelEventArgs cancelEventArgs_0)
		{
			this.MaximumSize = new Size(base.Width - 27, int.MaxValue);
			base.OnOpening(cancelEventArgs_0);
		}

		protected override void OnClosed(ToolStripDropDownClosedEventArgs toolStripDropDownClosedEventArgs_0)
		{
			this.MaximumSize = new Size(int.MaxValue, this.MaximumSize.Height);
			base.OnClosed(toolStripDropDownClosedEventArgs_0);
		}

		protected override void WndProc(ref Message message)
		{
			switch (message.Msg)
			{
			default:
				base.WndProc(ref message);
				break;
			case 256:
			case 257:
			case 258:
				if (base.Visible)
				{
					base.Close();
				}
				if (this.m_txTextControl != null && this.m_txTextControl.IsHandleCreated)
				{
					IntPtr focus = Class429.GetFocus();
					if (focus != IntPtr.Zero && (focus == this.m_txTextControl.Handle || Class429.IsChild(this.m_txTextControl.Handle, focus)))
					{
						Class429.SendMessage_32(focus, message.Msg, (uint)message.WParam.ToInt32(), message.LParam);
					}
				}
				base.WndProc(ref message);
				break;
			case 1:
				base.uint_0 = Class429.smethod_15(message.HWnd);
				if (base.uint_0 == 0)
				{
					this.bool_3 = false;
					Graphics graphics = Graphics.FromHwnd(message.HWnd);
					base.uint_0 = (uint)graphics.DpiX;
					graphics.Dispose();
				}
				break;
			}
		}
	}
}
