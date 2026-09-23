using System.Drawing;
using System.Drawing.Drawing2D;
using TXTextControl;

namespace ns19
{
	internal class Class390 : ITransformAttribute
	{
		private float float_0;

		private PointF pointF_0 = new PointF(0f, 0f);

		internal Class390(float[] float_1)
		{
			this.float_0 = float_1[0];
			if (float_1.Length > 1)
			{
				float x = float_1[1];
				float y = ((float_1.Length == 3) ? float_1[2] : 0f);
				this.pointF_0 = new PointF(x, y);
			}
		}

		public void ApplyTransformation(GraphicsPath graphicsPath, ref GraphicsPath clipPath)
		{
			Matrix matrix = new Matrix();
			matrix.RotateAt(this.float_0, this.pointF_0);
			graphicsPath.Transform(matrix);
			if (clipPath != null)
			{
				clipPath.Transform(matrix);
			}
		}
	}
}
