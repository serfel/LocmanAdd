using System.Drawing;
using System.Drawing.Drawing2D;
using TXTextControl;

namespace ns19
{
	internal class Class377
	{
		private GraphicsPath graphicsPath_0;

		private Pen pen_0;

		private Def def_0;

		private ITransformAttribute[] itransformAttribute_0;

		private SizeF sizeF_0;

		private float float_0;

		internal GraphicsPath GraphicsPath_0 => this.graphicsPath_0;

		internal ITransformAttribute[] ITransformAttribute_0 => this.itransformAttribute_0;

		internal Pen Pen_0 => this.pen_0;

		internal Def Def_0 => this.def_0;

		internal SizeF SizeF_0 => this.sizeF_0;

		internal float Single_0 => this.float_0;

		internal Class377(GraphicsPath graphicsPath_1, ITransformAttribute[] itransformAttribute_1, Pen pen_1, Def def_1, SizeF sizeF_1, float float_1)
		{
			this.graphicsPath_0 = graphicsPath_1;
			this.itransformAttribute_0 = itransformAttribute_1;
			this.pen_0 = pen_1;
			this.def_0 = def_1;
			this.sizeF_0 = sizeF_1;
			this.float_0 = float_1;
		}
	}
}
