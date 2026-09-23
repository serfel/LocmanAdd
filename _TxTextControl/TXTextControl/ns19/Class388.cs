using System.Drawing.Drawing2D;
using TXTextControl;

namespace ns19
{
	internal class Class388 : ITransformAttribute
	{
		private float[] float_0;

		internal Class388(float[] float_1)
		{
			this.float_0 = float_1;
		}

		public void ApplyTransformation(GraphicsPath graphicsPath, ref GraphicsPath clipPath)
		{
			Matrix matrix = new Matrix(this.float_0[0], this.float_0[1], this.float_0[2], this.float_0[3], this.float_0[4], this.float_0[5]);
			graphicsPath.Transform(matrix);
			if (clipPath != null)
			{
				clipPath.Transform(matrix);
			}
		}
	}
}
