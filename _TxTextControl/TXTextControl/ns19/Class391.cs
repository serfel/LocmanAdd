using System.Drawing;
using System.Drawing.Drawing2D;
using TXTextControl;

namespace ns19
{
	internal class Class391 : ITransformAttribute
	{
		private PointF pointF_0;

		internal float Single_0 => this.pointF_0.X;

		internal Class391(float[] float_0)
		{
			float num = float_0[0];
			float y = ((float_0.Length > 1) ? float_0[1] : num);
			this.pointF_0 = new PointF(num, y);
		}

		internal Class391(PointF pointF_1)
		{
			this.pointF_0 = pointF_1;
		}

		public void ApplyTransformation(GraphicsPath graphicsPath, ref GraphicsPath clipPath)
		{
			Matrix matrix = new Matrix();
			matrix.Scale(this.pointF_0.X, this.pointF_0.Y);
			graphicsPath.Transform(matrix);
			if (clipPath != null)
			{
				clipPath.Transform(matrix);
			}
		}
	}
}
