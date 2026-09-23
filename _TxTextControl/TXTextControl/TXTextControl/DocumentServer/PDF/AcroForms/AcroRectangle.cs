using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace DocumentServer.PDF.AcroForms
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	public struct AcroRectangle
	{
		[CompilerGenerated]
		private int int_0;

		[CompilerGenerated]
		private int int_1;

		[CompilerGenerated]
		private int int_2;

		[CompilerGenerated]
		private int int_3;

		[XmlAttribute("left", DataType = "int")]
		public int Left
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

		[XmlAttribute("right", DataType = "int")]
		public int Right
		{
			[CompilerGenerated]
			get
			{
				return this.int_1;
			}
			[CompilerGenerated]
			set
			{
				this.int_1 = value;
			}
		}

		[XmlAttribute("top", DataType = "int")]
		public int Top
		{
			[CompilerGenerated]
			get
			{
				return this.int_2;
			}
			[CompilerGenerated]
			set
			{
				this.int_2 = value;
			}
		}

		[XmlAttribute("bottom", DataType = "int")]
		public int Bottom
		{
			[CompilerGenerated]
			get
			{
				return this.int_3;
			}
			[CompilerGenerated]
			set
			{
				this.int_3 = value;
			}
		}

		[XmlIgnore]
		public int Height => Math.Abs(this.Bottom - this.Top);

		[XmlIgnore]
		public int Width => this.Right - this.Left;

		[XmlIgnore]
		public int Y => this.Top;

		[XmlIgnore]
		public int X => this.Left;

		[XmlIgnore]
		public Size Size => new Size(this.Width, this.Height);

		[XmlIgnore]
		public Point Location => new Point(this.X, this.Y);

		public static implicit operator Rectangle(AcroRectangle xmlRectangle)
		{
			return new Rectangle(xmlRectangle.Left, xmlRectangle.Top, xmlRectangle.Width, xmlRectangle.Height);
		}

		public static implicit operator AcroRectangle(Rectangle rectangle)
		{
			AcroRectangle result = default(AcroRectangle);
			result.Left = rectangle.Left;
			result.Right = rectangle.Right;
			result.Top = rectangle.Top;
			result.Bottom = rectangle.Bottom;
			return result;
		}
	}
}
