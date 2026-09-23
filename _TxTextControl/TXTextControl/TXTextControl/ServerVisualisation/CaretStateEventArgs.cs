using System;
using System.Drawing;
using ns21;

namespace TXTextControl.ServerVisualisation
{
	public class CaretStateEventArgs : EventArgs
	{
		private Struct64 struct64_0 = default(Struct64);

		private IntPtr intptr_0 = IntPtr.Zero;

		public Point Location => new Point(this.struct64_0.struct82_0.int_0, this.struct64_0.struct82_0.int_1);

		public Size Size => new Size(this.struct64_0.struct82_1.int_0, this.struct64_0.struct82_1.int_1);

		public bool Visibility => this.struct64_0.bool_1;

		public Direction Direction
		{
			get
			{
				if (!this.struct64_0.bool_2)
				{
					return Direction.LeftToRight;
				}
				return Direction.RightToLeft;
			}
		}

		internal CaretStateEventArgs(IntPtr handle)
		{
			this.intptr_0 = handle;
		}

		internal bool method_0()
		{
			Struct64 @struct = new Struct64(this.struct64_0);
			this.struct64_0.method_0();
			Class429.SendMessage_50(this.intptr_0, 2065, 0, ref this.struct64_0);
			return !@struct.method_1(this.struct64_0);
		}
	}
}
