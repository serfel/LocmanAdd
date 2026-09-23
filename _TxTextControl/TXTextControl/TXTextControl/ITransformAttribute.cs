using System.Drawing.Drawing2D;

namespace TXTextControl
{
	internal interface ITransformAttribute
	{
		void ApplyTransformation(GraphicsPath graphicsPath, ref GraphicsPath clipPath);
	}
}
