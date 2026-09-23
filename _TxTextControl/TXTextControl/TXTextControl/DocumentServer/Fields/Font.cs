namespace DocumentServer.Fields
{
	public struct Font
	{
		public string Name;

		public string Family;

		public int Size;

		public bool Bold;

		public bool Italic;

		public bool Strikeout;

		public bool Underline;

		public Font(string name, string family, int size, bool bold, bool italic, bool strikeout, bool underline)
		{
			this.Name = name;
			this.Family = family;
			this.Size = size;
			this.Bold = bold;
			this.Italic = italic;
			this.Strikeout = strikeout;
			this.Underline = underline;
		}
	}
}
