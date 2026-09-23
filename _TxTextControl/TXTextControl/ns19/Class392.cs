using System;
using System.Drawing.Drawing2D;
using TXTextControl;

namespace ns19
{
	internal class Class392 : ITransformAttribute
	{
		private float float_0;

		private bool bool_0;

		internal Class392(float[] float_1, bool bool_1)
		{
			this.float_0 = float_1[0];
			this.bool_0 = bool_1;
		}

		public void ApplyTransformation(GraphicsPath graphicsPath, ref GraphicsPath clipPath)
		{
			float m = (this.bool_0 ? ((float)Math.Tan((double)this.float_0 * (Math.PI / 180.0))) : 0f);
			float m2 = (this.bool_0 ? 0f : ((float)Math.Tan((double)this.float_0 * (Math.PI / 180.0))));
			Matrix matrix = new Matrix(1f, m2, m, 1f, 0f, 0f);
			graphicsPath.Transform(matrix);
			if (clipPath != null)
			{
				clipPath.Transform(matrix);
			}
		}
	}
}
