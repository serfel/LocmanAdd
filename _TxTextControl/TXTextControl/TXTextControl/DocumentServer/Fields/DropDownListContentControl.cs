using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using TXTextControl;

namespace DocumentServer.Fields
{
	/// <summary>The DropDownListContentControl implements the MS Word specific drop down list content control field.</summary>
	public class DropDownListContentControl : ContentControlFieldAdapter
	{
		private List<DropDownListItem> list_0 = new List<DropDownListItem>();

		internal const string string_0 = "dropDownList";

		[Category("Properties")]
		public List<DropDownListItem> ListItems
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

		/// <summary>Initializes a new instance of the DropDownListContentControl class with a connection to an existing ApplicationField.</summary>
		/// <param name="appField">Specifies the ApplicationField to be adapted.</param>
		public DropDownListContentControl(ApplicationField ApplicationField)
			: base(ApplicationField)
		{
			this.list_0 = new List<DropDownListItem>();
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(ApplicationField.Parameters[0]);
			XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
			xmlNamespaceManager.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			foreach (XmlNode item in xmlDocument.SelectNodes("/w:sdt/w:sdtPr/w:dropDownList", xmlNamespaceManager))
			{
				foreach (XmlNode childNode in item.ChildNodes)
				{
					if (childNode.LocalName == "listItem")
					{
						DropDownListItem dropDownListItem = new DropDownListItem();
						if (childNode.Attributes["w:value"] != null)
						{
							dropDownListItem.Value = childNode.Attributes["w:value"].Value;
						}
						if (childNode.Attributes["w:displayText"] != null)
						{
							dropDownListItem.DisplayText = childNode.Attributes["w:displayText"].Value;
						}
						this.list_0.Add(dropDownListItem);
					}
				}
			}
		}

		/// <summary>Initializes complete new instance of the DropDownListContentControl class without a connection to an existing ApplicationField.</summary>
		public DropDownListContentControl()
		{
		}

		protected override void SetParameters()
		{
			XmlDocument xmlBaseStructure = base.XmlBaseStructure;
			XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlBaseStructure.NameTable);
			xmlNamespaceManager.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			XmlNode xmlNode = xmlBaseStructure.SelectSingleNode("/w:sdt/w:sdtPr", xmlNamespaceManager);
			System.Xml.XmlElement xmlElement = xmlBaseStructure.CreateElement("w:dropDownList", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			foreach (DropDownListItem listItem in this.ListItems)
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
