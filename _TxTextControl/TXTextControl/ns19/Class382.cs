using System.Drawing;

namespace ns19
{
	internal class Class382 : Class381
	{
		private SolidBrush solidBrush_0;

		internal Class382(Color color_0)
		{
			this.solidBrush_0 = new SolidBrush(color_0);
		}

		internal override Brush vmethod_0(Class376 class376_0, Class377 class377_0)
		{
			return this.solidBrush_0;
		}
	}
}
