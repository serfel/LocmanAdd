using System.Drawing;
using System.Windows.Forms;

namespace ns16
{
	internal sealed class Class158
	{
		private Class158()
		{
		}

		public static int smethod_0(Label label_0)
		{
			return Class158.smethod_1(label_0, label_0.Width);
		}

		public static int smethod_1(Label label_0, int int_0)
		{
			return Class158.smethod_7(label_0, label_0.UseCompatibleTextRendering, int_0);
		}

		public static int smethod_2(CheckBox checkBox_0)
		{
			return Class158.smethod_7(checkBox_0, checkBox_0.UseCompatibleTextRendering, checkBox_0.Width);
		}

		public static void smethod_3(Control control_0)
		{
			control_0.Left = control_0.Parent.Right - control_0.Parent.Padding.Left - control_0.Margin.Left - control_0.Width;
			if ((control_0.Anchor & AnchorStyles.Left) == 0 || (control_0.Anchor & AnchorStyles.Right) == 0)
			{
				control_0.Anchor &= ~AnchorStyles.Left;
				control_0.Anchor |= AnchorStyles.Right;
			}
		}

		public static void smethod_4(Control control_0, Control control_1)
		{
			control_0.Left = control_1.Right - control_0.Width;
			if ((control_0.Anchor & AnchorStyles.Left) == 0 || (control_0.Anchor & AnchorStyles.Right) == 0)
			{
				control_0.Anchor &= ~AnchorStyles.Left;
				control_0.Anchor |= AnchorStyles.Right;
			}
		}

		public static void smethod_5(Control control_0)
		{
			control_0.Left = control_0.Parent.Left + control_0.Parent.Padding.Left + control_0.Margin.Left;
			if ((control_0.Anchor & AnchorStyles.Left) == 0 || (control_0.Anchor & AnchorStyles.Right) == 0)
			{
				control_0.Anchor &= ~AnchorStyles.Right;
				control_0.Anchor |= AnchorStyles.Left;
			}
		}

		public static void smethod_6(Control control_0, Control control_1)
		{
			control_0.Left = control_1.Left;
			if ((control_0.Anchor & AnchorStyles.Left) == 0 || (control_0.Anchor & AnchorStyles.Right) == 0)
			{
				control_0.Anchor &= ~AnchorStyles.Right;
				control_0.Anchor |= AnchorStyles.Left;
			}
		}

		private static int smethod_7(Control control_0, bool bool_0, int int_0)
		{
			using Graphics graphics = Graphics.FromHwnd(control_0.Handle);
			if (bool_0)
			{
				return graphics.MeasureString(control_0.Text, control_0.Font, control_0.Width).ToSize().Height;
			}
			return TextRenderer.MeasureText(graphics, control_0.Text, control_0.Font, new Size(int_0, int.MaxValue), TextFormatFlags.WordBreak).Height;
		}
	}
}
