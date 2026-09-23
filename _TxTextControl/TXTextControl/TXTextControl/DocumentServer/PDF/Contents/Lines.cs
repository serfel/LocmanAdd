using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using TXTextControl;

namespace DocumentServer.PDF.Contents
{
	/// <summary>The Lines class implements functionality to find DocumentServer.PDF.Contents.ContentLine objects in a PDF document.</summary>
	public class Lines
	{
		private List<ContentLine> list_0 = new List<ContentLine>();

		/// <summary>Returns a list of DocumentServer.PDF.Contents.ContentLine objects in the PDF document.</summary>
		public List<ContentLine> ContentLines => this.list_0;

		/// <summary>Initializes a new DocumentServer.PDF.Contents.Lines class from a given file.</summary>
		/// <param name="filename">Specifies the PDF filename that is used to import the text lines.</param>
		public Lines(string filename)
		{
			if (!File.Exists(filename))
			{
				throw new FileNotFoundException();
			}
			LoadSettings loadSettings = new LoadSettings
			{
				PDFImportSettings = PDFImportSettings.LoadEmbeddedData
			};
			string string_;
			using (ServerTextControl serverTextControl = new ServerTextControl())
			{
				serverTextControl.Create();
				serverTextControl.Load(filename, StreamType.AdobePDF, loadSettings);
				string_ = (string)loadSettings.EmbeddedData[EmbeddedDataFormat.TextCoordinates];
			}
			this.method_0(string_);
		}

		/// <summary>Initializes a new DocumentServer.PDF.Contents.Lines class from a given byte array.</summary>
		/// <param name="data">Specifies data of a PDF document that is used to import the text lines.</param>
		public Lines(byte[] data)
		{
			if (data == null)
			{
				throw new NullReferenceException();
			}
			LoadSettings loadSettings = new LoadSettings
			{
				PDFImportSettings = PDFImportSettings.LoadEmbeddedData
			};
			string string_;
			using (ServerTextControl serverTextControl = new ServerTextControl())
			{
				serverTextControl.Create();
				serverTextControl.Load(data, BinaryStreamType.AdobePDF, loadSettings);
				string_ = (string)loadSettings.EmbeddedData[EmbeddedDataFormat.TextCoordinates];
			}
			this.method_0(string_);
		}

		/// <summary>Returns a list of DocumentServer.PDF.Contents.ContentLine found based on a string.</summary>
		/// <param name="text">The string to search for in the document.</param>
		public List<ContentLine> Find(string text)
		{
			return this.list_0.Where((ContentLine line) => line.Text.Contains(text)).ToList();
		}

		/// <summary>Returns a list of DocumentServer.PDF.Contents.ContentLine objects found through a regular expression.</summary>
		/// <param name="regex">The regular expression that is used in the find process.</param>
		/// <param name="options">The regular expression options.</param>
		public List<ContentLine> Find(string regex, RegexOptions options)
		{
			return this.list_0.Where((ContentLine line) => Regex.Match(line.Text, regex, options).Success).ToList();
		}

		/// <summary>Returns a list of DocumentServer.PDF.Contents.ContentLine objects at a geometric location with a given radius.</summary>
		/// <param name="position">The geometric location in the document to search for.</param>
		/// <param name="radius">The radius to define the search area.</param>
		/// <param name="partially">Specifies whether the lines have to be completely inside the given rectangle or just intersect with it.</param>
		public List<ContentLine> Find(PointF position, float radius = 100f, bool partially = false)
		{
			if (partially)
			{
				return this.method_1(position, radius);
			}
			return this.method_2(position, radius);
		}

		/// <summary>Returns a list of DocumentServer.PDF.Contents.ContentLine objects in a given rectangle.</summary>
		/// <param name="rectangle">The rectangle that is used for the find process.</param>
		/// <param name="partially">Specifies whether the lines have to be completely inside the given rectangle or just intersect with it.</param>
		public List<ContentLine> Find(RectangleF rectangle, bool partially = false)
		{
			if (partially)
			{
				return this.method_3(rectangle);
			}
			return this.method_4(rectangle);
		}

		private void method_0(string string_0)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(string_0);
			foreach (System.Xml.XmlElement item in xmlDocument.DocumentElement.SelectNodes("lines/line"))
			{
				XmlReader xmlReader = XmlReader.Create(new StringReader(item.OuterXml));
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(ContentLine), new XmlRootAttribute("line"));
				this.list_0.Add((ContentLine)xmlSerializer.Deserialize(xmlReader));
			}
		}

		private List<ContentLine> method_1(PointF pointF_0, float float_0)
		{
			return this.list_0.Where((ContentLine line) => line.Rectangle.IntersectsWithCircle(pointF_0, float_0)).ToList();
		}

		private List<ContentLine> method_2(PointF pointF_0, float float_0)
		{
			return this.list_0.Where((ContentLine line) => line.Rectangle.IsInsideCircle(pointF_0, float_0)).ToList();
		}

		private List<ContentLine> method_3(RectangleF rectangleF_0)
		{
			return this.list_0.Where((ContentLine line) => rectangleF_0.IntersectsWith(line.Rectangle)).ToList();
		}

		private List<ContentLine> method_4(RectangleF rectangleF_0)
		{
			return this.list_0.Where((ContentLine line) => rectangleF_0.Contains(line.Rectangle)).ToList();
		}
	}
}
