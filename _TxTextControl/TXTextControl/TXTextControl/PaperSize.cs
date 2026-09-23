namespace TXTextControl
{
	/// <summary>The PaperSize class is used with the TextControl.GetSupportedPaperSizes and WPF.TextControl.GetSupportedPaperSizes methods, which return the names and the sizes of all currently supported paper sizes.</summary>
	public class PaperSize
	{
		private int int_0;

		private int int_1;

		private string string_0;

		/// <summary>Gets the width of the paper size, in twips.</summary>
		public int Width => this.int_0;

		/// <summary>Gets the height of the paper size, in twips.</summary>
		public int Height => this.int_1;

		/// <summary>Gets the name of the paper size.</summary>
		public string Name => this.string_0;

		internal PaperSize(int iWidth, int iHeight, string strName)
		{
			this.int_0 = iWidth;
			this.int_1 = iHeight;
			this.string_0 = strName;
		}
	}
}
