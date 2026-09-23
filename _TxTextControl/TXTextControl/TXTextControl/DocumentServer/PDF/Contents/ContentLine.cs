using System.Drawing;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace DocumentServer.PDF.Contents
{
	/// <summary>The ContentLine class implements the text coordinates in a PDF document.</summary>
	[XmlRoot("line")]
	public class ContentLine
	{
		[CompilerGenerated]
		private int int_0;

		[CompilerGenerated]
		private float float_0;

		[CompilerGenerated]
		private float float_1;

		[CompilerGenerated]
		private float float_2;

		[CompilerGenerated]
		private float float_3;

		[CompilerGenerated]
		private string string_0;

		/// <summary>Returns the page number that contains the line.</summary>
		[XmlAttribute("page", DataType = "int")]
		public int Page
		{
			[CompilerGenerated]
			get
			{
				return this.int_0;
			}
			[CompilerGenerated]
			set
			{
				this.int_0 = value;
			}
		}

		/// <summary>Returns the horizontal coordinate of the line in Points.</summary>
		[XmlAttribute("xpos", DataType = "float")]
		public float X
		{
			[CompilerGenerated]
			get
			{
				return this.float_0;
			}
			[CompilerGenerated]
			set
			{
				this.float_0 = value;
			}
		}

		/// <summary>Returns the vertical coordinate of the line in Points.</summary>
		[XmlAttribute("ypos", DataType = "float")]
		public float Y
		{
			[CompilerGenerated]
			get
			{
				return this.float_1;
			}
			[CompilerGenerated]
			set
			{
				this.float_1 = value;
			}
		}

		/// <summary>Returns the width of the line in Points.</summary>
		[XmlAttribute("width", DataType = "float")]
		public float Width
		{
			[CompilerGenerated]
			get
			{
				return this.float_2;
			}
			[CompilerGenerated]
			set
			{
				this.float_2 = value;
			}
		}

		/// <summary>Returns the height of the line in Points.</summary>
		[XmlAttribute("height", DataType = "float")]
		public float Height
		{
			[CompilerGenerated]
			get
			{
				return this.float_3;
			}
			[CompilerGenerated]
			set
			{
				this.float_3 = value;
			}
		}

		/// <summary>Returns the text of the line.</summary>
		[XmlAttribute("text", DataType = "string")]
		public string Text
		{
			[CompilerGenerated]
			get
			{
				return this.string_0;
			}
			[CompilerGenerated]
			set
			{
				this.string_0 = value;
			}
		}

		/// <summary>Returns the rectangle bounds of the line.</summary>
		public RectangleF Rectangle => new RectangleF(this.X, this.Y, this.Width, this.Height);

		/// <summary>Initializes a complete new instance of the ContentLine class.</summary>
		public ContentLine()
		{
		}
	}
}
