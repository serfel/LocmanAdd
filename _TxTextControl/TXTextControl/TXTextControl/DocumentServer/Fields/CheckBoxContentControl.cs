using System;
using System.ComponentModel;
using System.Xml;
using ns1;
using TXTextControl;

namespace DocumentServer.Fields
{
	/// <summary>The CheckBoxContentControl implements the MS Word specific check box content control field.</summary>
	public class CheckBoxContentControl : ContentControlFieldAdapter
	{
		private bool bool_0;

		internal const string string_0 = "checkbox";

		/// <summary>Specifies whether the field is checked or not.</summary>
		[Category("Properties")]
		[Attribute1("PROP_FRMCHKBOX_CHECKED")]
		public bool Checked
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
				base.ApplicationField.Text = (this.bool_0 ? "☒\r\n" : "☐\r\n");
				this.SetParameters();
			}
		}

		/// <summary>Initializes a new instance of the CheckBoxContentControl class with a connection to an existing ApplicationField.</summary>
		/// <param name="appField">Specifies the ApplicationField to be adapted.</param>
		public CheckBoxContentControl(ApplicationField ApplicationField)
			: base(ApplicationField)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(ApplicationField.Parameters[0]);
			XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
			xmlNamespaceManager.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			xmlNamespaceManager.AddNamespace("w14", "http://schemas.microsoft.com/office/word/2010/wordml");
			foreach (XmlNode item in xmlDocument.SelectNodes("/w:sdt/w:sdtPr/w14:checkbox", xmlNamespaceManager))
			{
				foreach (XmlNode childNode in item.ChildNodes)
				{
					if (childNode.LocalName == "checked" && childNode.Attributes["w14:val"] != null)
					{
						this.bool_0 = Convert.ToInt32(childNode.Attributes["w14:val"].Value) != 0;
					}
				}
			}
		}

		/// <summary>Initializes complete new instance of the CheckBoxContentControl class without a connection to an existing ApplicationField.</summary>
		public CheckBoxContentControl()
		{
		}

		protected override void SetParameters()
		{
			XmlDocument xmlBaseStructure = base.XmlBaseStructure;
			XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlBaseStructure.NameTable);
			xmlNamespaceManager.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			XmlNode xmlNode = xmlBaseStructure.SelectSingleNode("/w:sdt/w:sdtPr", xmlNamespaceManager);
			System.Xml.XmlElement xmlElement = xmlBaseStructure.CreateElement("w14:checkbox", "http://schemas.microsoft.com/office/word/2010/wordml");
			System.Xml.XmlElement xmlElement2 = xmlBaseStructure.CreateElement("w14:checked", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			xmlElement2.SetAttribute("val", "http://schemas.openxmlformats.org/wordprocessingml/2006/main", (this.Checked ? 1 : 0).ToString());
			xmlElement.AppendChild(xmlElement2);
			xmlNode.AppendChild(xmlElement);
			base.ApplicationField.Parameters = new string[1] { xmlBaseStructure.OuterXml };
		}
	}
}
