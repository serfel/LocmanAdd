using System;

namespace TXTextControl.Drawing
{
	/// <summary>The ShapeEventArgs class provides data for all events that occur with shapes.</summary>
	public class ShapeEventArgs : EventArgs
	{
		private Shape shape_0;

		/// <summary>Gets an object of type Shape that represents the shape which causes the event.</summary>
		public Shape Shape => this.shape_0;

		internal ShapeEventArgs(Shape shape)
		{
			this.shape_0 = shape;
		}
	}
}
