using System;
using System.Drawing;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl.ServerVisualisation
{
	public class DrawComboboxEventArgs : EventArgs
	{
		private Class429.Struct83 struct83_0;

		private SelectionFormField selectionFormField_0;

		private string string_0;

		private int int_0;

		private bool bool_0;

		private bool bool_1;

		public bool Bold => this.bool_0;

		public string FontName => this.string_0;

		public int FontSize => this.int_0;

		public bool Italic => this.bool_1;

		public Point Location => new Point(this.struct83_0.int_0, this.struct83_0.int_1);

		public SelectionFormField SelectionFormField => this.selectionFormField_0;

		public Size Size => new Size(this.struct83_0.int_2 - this.struct83_0.int_0, this.struct83_0.int_3 - this.struct83_0.int_1);

		internal DrawComboboxEventArgs(TextControlCore m_tx, Class429.Struct83 rect)
		{
			this.struct83_0 = rect;
			if (this.struct83_0.int_2 - this.struct83_0.int_0 == 0)
			{
				return;
			}
			Struct78 struct78_ = new Struct78(bool_3: true);
			try
			{
				if (m_tx.method_81(Enum83.const_334, ref struct78_) != 0)
				{
					this.selectionFormField_0 = new SelectionFormField(m_tx, TextPart.Auto, struct78_.ushort_2);
					this.string_0 = Marshal.PtrToStringBSTR(struct78_.intptr_0);
					this.int_0 = struct78_.int_0;
					this.bool_0 = struct78_.bool_1;
					this.bool_1 = struct78_.bool_2;
				}
			}
			catch
			{
			}
			finally
			{
				struct78_.method_0();
			}
		}
	}
}
