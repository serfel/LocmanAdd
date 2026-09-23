using System;
using ns21;

namespace TXTextControl.ServerVisualisation
{
	public class DocumentSizeChangedEventArgs : EventArgs
	{
		private TextControlCore textControlCore_0;

		private Class429.Struct83 struct83_0;

		public int Width => this.struct83_0.int_2 - this.struct83_0.int_0;

		public int Height => this.struct83_0.int_3 - this.struct83_0.int_1;

		internal DocumentSizeChangedEventArgs(TextControlCore textControlCore_1)
		{
			this.textControlCore_0 = textControlCore_1;
			this.struct83_0 = default(Class429.Struct83);
			this.textControlCore_0.method_32(Enum83.const_53, 1, ref this.struct83_0);
		}
	}
}
