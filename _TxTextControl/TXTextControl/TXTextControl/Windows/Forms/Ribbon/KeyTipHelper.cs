using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ns21;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal static class KeyTipHelper
	{
		internal static void DrawKeyTips(Control cntlTopLevel, string strPrefix, Graphics grfxIn)
		{
			VisualStyleRenderer renderer = new VisualStyleRenderer(VisualStyleElement.ToolTip.Standard.Normal);
			IntPtr intPtr = IntPtr.Zero;
			Graphics graphics = grfxIn;
			Control control = null;
			IRibbonItem ribbonItem = null;
			if (grfxIn == null)
			{
				intPtr = Class429.GetDCEx(cntlTopLevel.Handle, IntPtr.Zero, 32u);
				graphics = Graphics.FromHdc(intPtr);
			}
			while ((control = KeyTipHelper.GetNextRibbonItem(cntlTopLevel, control, tabStopOnly: false, nested: true)) != null)
			{
				ribbonItem = control as IRibbonItem;
				if (ribbonItem.KeyTip != string.Empty && (strPrefix == string.Empty || ribbonItem.KeyTip.StartsWith(strPrefix)))
				{
					Rectangle rItem = new Rectangle(0, 0, control.Width, control.Height);
					rItem.Offset(cntlTopLevel.PointToClient(control.PointToScreen(default(Point))));
					KeyTipHelper.DrawKeyTip(graphics, rItem, ribbonItem.KeyTip, renderer, cntlTopLevel.Font);
				}
			}
			if (grfxIn == null)
			{
				graphics.Dispose();
				Class429.ReleaseDC(cntlTopLevel.Handle, intPtr);
			}
		}

		internal static void DrawKeyTip(Graphics grfx, Rectangle rItem, string strKeyTip, VisualStyleRenderer renderer, Font font)
		{
			SizeF sizeF = grfx.MeasureString(strKeyTip, font);
			Rectangle rectangle = new Rectangle(rItem.Left + rItem.Width / 2 - (int)sizeF.Width / 2, rItem.Top + rItem.Height / 4 * 3, (int)sizeF.Width, (int)sizeF.Height);
			rectangle.Inflate((strKeyTip.Length == 1) ? 3 : 0, 0);
			renderer.DrawBackground(grfx, rectangle);
			IntPtr hdc = grfx.GetHdc();
			IntPtr intPtr = font.ToHfont();
			IntPtr intptr_ = Class429.SelectObject(hdc, intPtr);
			Class429.Struct83 struct83_ = new Class429.Struct83(rectangle);
			int int_ = Class429.SetBkMode(hdc, 1);
			Class429.DrawText(hdc, strKeyTip, -1, ref struct83_, 5u);
			Class429.SetBkMode(hdc, int_);
			Class429.SelectObject(hdc, intptr_);
			Class429.DeleteObject(intPtr);
			grfx.ReleaseHdc(hdc);
		}

		internal static Control GetNextRibbonItem(Control parent, Control cntl, bool tabStopOnly, bool nested)
		{
			Control control = cntl;
			do
			{
				cntl = parent.GetNextControl(cntl, forward: true);
				if (cntl == null)
				{
					break;
				}
				if (cntl.CanSelect && (!tabStopOnly || cntl.TabStop) && (nested || cntl.Parent == parent) && cntl is IRibbonItem)
				{
					return cntl;
				}
			}
			while (cntl != control);
			return null;
		}

		internal static bool SelectRibbonItemFromKeyTip(Control parent, char char_0, ref string strKeyTipPrefix, out Control selected)
		{
			int num = 0;
			string text = strKeyTipPrefix + char.ToUpper(char_0);
			Control control = null;
			Control control2 = null;
			IRibbonItem ribbonItem = null;
			selected = null;
			while ((control = KeyTipHelper.GetNextRibbonItem(parent, control, tabStopOnly: false, nested: true)) != null)
			{
				ribbonItem = control as IRibbonItem;
				if (ribbonItem != null && ribbonItem.KeyTip != string.Empty && ribbonItem.KeyTip.StartsWith(text))
				{
					control2 = control;
					num++;
					if (ribbonItem.KeyTip.Length == 1)
					{
						break;
					}
				}
			}
			if (num > 0)
			{
				if (num == 1)
				{
					if (control2 is IRibbonItem)
					{
						((IRibbonItem)control2).PerformStandardKeyboardAction();
					}
					strKeyTipPrefix = string.Empty;
					selected = control2;
				}
				else
				{
					strKeyTipPrefix = text;
				}
			}
			return num > 0;
		}
	}
}
