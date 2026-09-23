using System.Drawing;
using System.Drawing.Drawing2D;
using TXTextControl;

namespace ns19
{
	internal class Class389 : ITransformAttribute
	{
		private PointF pointF_0;

		internal Class389(float[] float_0)
		{
			float x = float_0[0];
			float y = ((float_0.Length > 1) ? float_0[1] : 0f);
			this.pointF_0 = new PointF(x, y);
		}

		public void ApplyTransformation(GraphicsPath graphicsPath, ref GraphicsPath clipPath)
		{
			Matrix matrix = new Matrix();
			matrix.Translate(this.pointF_0.X, this.pointF_0.Y);
			graphicsPath.Transform(matrix);
			if (clipPath != null)
			{
				clipPath.Transform(matrix);
			}
		}
	}
}
