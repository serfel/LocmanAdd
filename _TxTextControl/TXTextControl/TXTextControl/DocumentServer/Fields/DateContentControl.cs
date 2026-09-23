using System;
using System.ComponentModel;
using System.Xml;
using TXTextControl;

namespace DocumentServer.Fields
{
	/// <summary>The DateContentControl implements the MS Word specific date content control field.</summary>
	public class DateContentControl : ContentControlFieldAdapter
	{
		private DateTime dateTime_0;

		private string string_0 = "M/d/yyyy";

		private string string_1 = "en-US";

		private string string_2 = "dateTime";

		private string string_3 = "gregorian";

		internal const string string_4 = "date";

		/// <summary>Gets or sets the date of the content control field.</summary>
		[Category("Properties")]
		public DateTime Date
		{
			get
			{
				return this.dateTime_0;
			}
			set
			{
				this.dateTime_0 = value;
				base.ApplicationField.Text = this.dateTime_0.ToString(this.DateFormat);
				this.SetParameters();
			}
		}

		/// <summary>Gets or sets the date format of the content control field.</summary>
		[Category("Properties")]
		public string DateFormat
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
				this.SetParameters();
			}
		}

		/// <summary>Gets or sets the language ID of the content control field.</summary>
		[Category("Properties")]
		public string LanguageID
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
				this.SetParameters();
			}
		}

		/// <summary>Gets or sets the translation that shall be performed on the displayed date in a date picker structured document tag.</summary>
		[Category("Properties")]
		public string StoreMappedDataAs
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
				this.SetParameters();
			}
		}

		/// <summary>Gets or sets the calendar type of the content control field.</summary>
		[Category("Properties")]
		public string Calendar
		{
			get
			{
				return this.string_3;
			}
			set
			{
				this.string_3 = value;
				this.SetParameters();
			}
		}

		/// <summary>Initializes a new instance of the DateContentControl class with a connection to an existing ApplicationField.</summary>
		/// <param name="appField">Specifies the ApplicationField to be adapted.</param>
		public DateContentControl(ApplicationField applicationField)
			: base(applicationField)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(ApplicationField.Parameters[0]);
			XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
			xmlNamespaceManager.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			foreach (XmlNode item in xmlDocument.SelectNodes("/w:sdt/w:sdtPr/w:date", xmlNamespaceManager))
			{
				if (item.Attributes["w:fullDate"].Value != null)
				{
					this.dateTime_0 = Convert.ToDateTime(item.Attributes["w:fullDate"].Value);
				}
				foreach (XmlNode childNode in item.ChildNodes)
				{
					switch (childNode.LocalName)
					{
					case "calendar":
						if (childNode.Attributes["w:val"] != null)
						{
							this.string_3 = childNode.Attributes["w:val"].Value;
						}
						break;
					case "storeMappedDataAs":
						if (childNode.Attributes["w:val"] != null)
						{
							this.string_2 = childNode.Attributes["w:val"].Value;
						}
						break;
					case "lid":
						if (childNode.Attributes["w:val"] != null)
						{
							this.string_1 = childNode.Attributes["w:val"].Value;
						}
						break;
					case "dateFormat":
						if (childNode.Attributes["w:val"] != null)
						{
							this.string_0 = childNode.Attributes["w:val"].Value;
						}
						break;
					}
				}
			}
			this.Date = this.dateTime_0;
		}

		/// <summary>Initializes complete new instance of the DateContentControl class without a connection to an existing ApplicationField.</summary>
		public DateContentControl()
		{
		}

		protected override void SetParameters()
		{
			XmlDocument xmlBaseStructure = base.XmlBaseStructure;
			XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlBaseStructure.NameTable);
			xmlNamespaceManager.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			XmlNode xmlNode = xmlBaseStructure.SelectSingleNode("/w:sdt/w:sdtPr", xmlNamespaceManager);
			System.Xml.XmlElement xmlElement = xmlBaseStructure.CreateElement("w:date", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			_ = this.Date;
			xmlElement.SetAttribute("fullDate", "http://schemas.openxmlformats.org/wordprocessingml/2006/main", this.Date.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ssZ"));
			System.Xml.XmlElement xmlElement2 = xmlBaseStructure.CreateElement("w:dateFormat", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			if (this.DateFormat != null)
			{
				xmlElement2.SetAttribute("val", "http://schemas.openxmlformats.org/wordprocessingml/2006/main", this.DateFormat);
			}
			System.Xml.XmlElement xmlElement3 = xmlBaseStructure.CreateElement("w:lid", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			if (this.LanguageID != null)
			{
				xmlElement3.SetAttribute("val", "http://schemas.openxmlformats.org/wordprocessingml/2006/main", this.LanguageID);
			}
			System.Xml.XmlElement xmlElement4 = xmlBaseStructure.CreateElement("w:storeMappedDataAs", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			if (this.StoreMappedDataAs != null)
			{
				xmlElement4.SetAttribute("val", "http://schemas.openxmlformats.org/wordprocessingml/2006/main", this.StoreMappedDataAs);
			}
			System.Xml.XmlElement xmlElement5 = xmlBaseStructure.CreateElement("w:calendar", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			if (this.Calendar != null)
			{
				xmlElement5.SetAttribute("val", "http://schemas.openxmlformats.org/wordprocessingml/2006/main", this.Calendar);
			}
			xmlElement.AppendChild(xmlElement2);
			xmlElement.AppendChild(xmlElement3);
			xmlElement.AppendChild(xmlElement4);
			xmlElement.AppendChild(xmlElement5);
			xmlNode.AppendChild(xmlElement);
			base.ApplicationField.Parameters = new string[1] { xmlBaseStructure.OuterXml };
		}
	}
}
