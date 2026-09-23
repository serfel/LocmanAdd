using System;
using System.Drawing;
using ns21;

namespace TXTextControl.ServerVisualisation
{
	public class DrawDateControlEventArgs : EventArgs
	{
		private Class429.Struct83 struct83_0;

		private DateFormField dateFormField_0;

		public Point Location => new Point(this.struct83_0.int_0, this.struct83_0.int_1);

		public DateFormField DateFormField => this.dateFormField_0;

		internal DrawDateControlEventArgs(TextControlCore m_tx, Class429.Struct83 rect)
		{
			this.struct83_0 = rect;
			if (this.struct83_0.int_2 - this.struct83_0.int_0 != 0)
			{
				Struct78 struct78_ = new Struct78(bool_3: false);
				if (m_tx.method_81(Enum83.const_334, ref struct78_) != 0)
				{
					this.dateFormField_0 = new DateFormField(m_tx, TextPart.Auto, struct78_.ushort_2);
				}
			}
		}
	}
}
