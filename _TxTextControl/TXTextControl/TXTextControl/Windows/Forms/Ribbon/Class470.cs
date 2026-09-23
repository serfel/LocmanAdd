using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ns21;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class470 : RibbonDropDown
	{
		private Ribbon ribbon_0;

		private Color[] color_0 = new Color[7];

		internal Class470(Ribbon ribbon_1)
		{
			this.ribbon_0 = ribbon_1;
			this.color_0 = Ribbon.smethod_0();
		}

		protected override void OnPaint(PaintEventArgs pea)
		{
			base.OnPaint(pea);
			if (this.ribbon_0 != null && this.ribbon_0.TabCount > 0)
			{
				Rectangle tabRect = this.ribbon_0.GetTabRect(0);
				Pen pen = new Pen(this.color_0[6]);
				Rectangle clipRectangle = pea.ClipRectangle;
				tabRect.Inflate(-1, 0);
				if (this.RightToLeft == RightToLeft.Yes)
				{
					tabRect.Offset(base.ClientRectangle.Right - tabRect.Right - tabRect.Left, 0);
				}
				this.ribbon_0.method_21(pea.Graphics, tabRect, TabItemState.Selected);
				pea.Graphics.DrawLine(pen, clipRectangle.Left, tabRect.Bottom, clipRectangle.Right, tabRect.Bottom);
				pea.Graphics.DrawLine(pen, clipRectangle.Left, base.Height - tabRect.Bottom, clipRectangle.Right, base.Height - tabRect.Bottom);
			}
		}

		protected override void WndProc(ref Message message)
		{
			Class429.Enum121 msg = (Class429.Enum121)message.Msg;
			if (msg == Class429.Enum121.const_15 && this.ribbon_0 != null && this.ribbon_0.TabCount > 0)
			{
				Point pt = base.PointToClient(Cursor.Position);
				Rectangle tabRect = this.ribbon_0.GetTabRect(0);
				if (this.RightToLeft == RightToLeft.Yes)
				{
					tabRect.Offset(base.ClientRectangle.Right - tabRect.Right - tabRect.Left, 0);
				}
				if (tabRect.Contains(pt))
				{
					base.Close();
					message.Result = new IntPtr(4);
					return;
				}
			}
			base.WndProc(ref message);
		}
	}
}
