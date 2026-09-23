using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using TXTextControl;

namespace DocumentServer.Fields
{
	/// <summary>The ComboBoxContentControl implements the MS Word specific combo box content control field.</summary>
	public class ComboBoxContentControl : ContentControlFieldAdapter
	{
		private List<ComboBoxListItem> list_0 = new List<ComboBoxListItem>();

		internal const string string_0 = "comboBox";

		/// <summary>Gets or sets the list items of the combo box content control field.</summary>
		[Category("Properties")]
		public List<ComboBoxListItem> ListItems
		{
			get
			{
				return this.list_0;
			}
			set
			{
				this.list_0 = value;
				this.SetParameters();
			}
		}

		/// <summary>Initializes a new instance of the ComboBoxContentControl class with a connection to an existing ApplicationField.</summary>
		/// <param name="appField">Specifies the ApplicationField to be adapted.</param>
		public ComboBoxContentControl(ApplicationField appField)
			: base(appField)
		{
			this.list_0 = new List<ComboBoxListItem>();
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(appField.Parameters[0]);
			XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
			xmlNamespaceManager.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			foreach (XmlNode item in xmlDocument.SelectNodes("/w:sdt/w:sdtPr/w:comboBox", xmlNamespaceManager))
			{
				foreach (XmlNode childNode in item.ChildNodes)
				{
					if (childNode.LocalName == "listItem")
					{
						ComboBoxListItem comboBoxListItem = new ComboBoxListItem();
						if (childNode.Attributes["w:displayText"] != null)
						{
							comboBoxListItem.DisplayText = childNode.Attributes["w:displayText"].Value;
						}
						if (childNode.Attributes["w:displayText"] != null)
						{
							comboBoxListItem.Value = childNode.Attributes["w:value"].Value;
						}
						this.list_0.Add(comboBoxListItem);
					}
				}
			}
		}

		/// <summary>Initializes complete new instance of the ComboBoxContentControl class without a connection to an existing ApplicationField.</summary>
		public ComboBoxContentControl()
		{
		}

		protected override void SetParameters()
		{
			XmlDocument xmlBaseStructure = base.XmlBaseStructure;
			XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlBaseStructure.NameTable);
			xmlNamespaceManager.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			XmlNode xmlNode = xmlBaseStructure.SelectSingleNode("/w:sdt/w:sdtPr", xmlNamespaceManager);
			System.Xml.XmlElement xmlElement = xmlBaseStructure.CreateElement("w:comboBox", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			foreach (ComboBoxListItem listItem in this.ListItems)
			{
				System.Xml.XmlElement xmlElement2 = xmlBaseStructure.CreateElement("w:listItem", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
				xmlElement2.SetAttribute("displayText", "http://schemas.openxmlformats.org/wordprocessingml/2006/main", listItem.DisplayText);
				xmlElement2.SetAttribute("value", "http://schemas.openxmlformats.org/wordprocessingml/2006/main", listItem.Value);
				xmlElement.AppendChild(xmlElement2);
			}
			xmlNode.AppendChild(xmlElement);
			base.ApplicationField.Parameters = new string[1] { xmlBaseStructure.OuterXml };
		}
	}
}
