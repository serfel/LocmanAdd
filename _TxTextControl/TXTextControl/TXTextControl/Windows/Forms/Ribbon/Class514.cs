using System;
using System.Drawing;
using System.Windows.Forms;
using ns21;
using TXTextControl;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class514 : TableLayoutPanel
	{
		private RibbonGroup ribbonGroup_0;

		private RibbonGroup ribbonGroup_1;

		private bool bool_0;

		internal Class514(DockStyle dockStyle_0, int int_0, int int_1, RibbonGroup ribbonGroup_2, RibbonGroup ribbonGroup_3, bool bool_1)
		{
			base.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			base.SetStyle(ControlStyles.StandardDoubleClick, value: false);
			this.ribbonGroup_0 = ribbonGroup_2;
			this.ribbonGroup_1 = ribbonGroup_3;
			this.bool_0 = bool_1;
			base.Size = new Size(0, 0);
			base.AutoSize = true;
			base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			base.Margin = new Padding(0);
			base.Padding = new Padding(0);
			base.Dock = dockStyle_0;
			base.RowCount = int_1;
			for (int i = 0; i < int_1; i++)
			{
				base.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			}
			base.ColumnCount = int_0 + 2;
			int num = ((ribbonGroup_3.HorizontalContentAlignment == HorizontalAlignment.Center) ? 50 : ((ribbonGroup_3.HorizontalContentAlignment != HorizontalAlignment.Left) ? 100 : 0));
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, num));
			for (int j = 0; j < int_0; j++)
			{
				base.ColumnStyles.Add(new ColumnStyle());
			}
			int num2 = ((ribbonGroup_3.HorizontalContentAlignment == HorizontalAlignment.Center) ? 50 : ((ribbonGroup_3.HorizontalContentAlignment != HorizontalAlignment.Right) ? 100 : 0));
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, num2));
		}

		protected override void OnClick(EventArgs eventArgs_0)
		{
			if (this.ribbonGroup_1.DialogBoxLauncher.Visible && this.ribbonGroup_1.DialogBoxLauncher.Enabled && this.ribbonGroup_1.Class515_0.Boolean_1 && !this.ribbonGroup_1.Boolean_2)
			{
				this.ribbonGroup_0.DialogBoxLauncher.method_1(eventArgs_0);
			}
			base.OnClick(eventArgs_0);
		}

		public override Size GetPreferredSize(Size proposedSize)
		{
			Size preferredSize = base.GetPreferredSize(proposedSize);
			if (!this.bool_0 && !this.ribbonGroup_0.PointF_0.IsEmpty && !(this.ribbonGroup_0 is Class497))
			{
				return new Size(preferredSize.Width, RibbonGroup.smethod_0(this.ribbonGroup_0.Font, this.ribbonGroup_0.RowCount, this.ribbonGroup_0.PointF_0, this.ribbonGroup_0.bool_4));
			}
			return preferredSize;
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
