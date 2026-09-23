using System;
using System.Drawing;
using ns21;

namespace TXTextControl.ServerVisualisation
{
	public class DrawShapeEventArgs : EventArgs
	{
		public enum Shape
		{
			MoveAndSizeFrame = 1,
			TableBorderMovingLine,
			DropCaret
		}

		private Class429.Struct83 struct83_0;

		private int int_0;

		public Point Location => new Point(this.struct83_0.int_0, this.struct83_0.int_1);

		public Shape Kind => (Shape)this.int_0;

		public Size Size => new Size(this.struct83_0.int_2 - this.struct83_0.int_0, this.struct83_0.int_3 - this.struct83_0.int_1);

		internal DrawShapeEventArgs(int iShape, Class429.Struct83 rect)
		{
			this.struct83_0 = rect;
			this.int_0 = iShape;
		}
	}
}
