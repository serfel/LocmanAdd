using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using DocumentServer.Properties;
using TXTextControl;

namespace DocumentServer.Fields
{
	/// <summary>The abstract ContentControlFieldAdapter class is the base class of all Microsoft Word content control field adapter classes.</summary>
	public abstract class ContentControlFieldAdapter : FieldAdapter
	{
		private string m_strTitle = "";

		private string m_strTag = "";

		private string m_strType;

		private long m_nID;

		private bool m_bContentDeletable = true;

		private bool m_bContentEditable = true;

		private List<DocPart> m_placeholder = new List<DocPart>();

		public new const string TYPE_NAME = "SDTBLOCK";

		internal const string XMLElementName = "";

		[Category("Properties")]
		public override string TypeName => "SDTBLOCK";

		/// <summary>Gets or sets the content control's title.</summary>
		[Category("Properties")]
		public string Title
		{
			get
			{
				return this.m_strTitle;
			}
			set
			{
				this.m_strTitle = value;
				this.SetParameters();
			}
		}

		/// <summary>Gets or sets the content control's tag.</summary>
		[Category("Properties")]
		public string Tag
		{
			get
			{
				return this.m_strTag;
			}
			set
			{
				this.m_strTag = value;
				this.SetParameters();
			}
		}

		[Category("Properties")]
		public long Int64_0
		{
			get
			{
				return this.m_nID;
			}
			set
			{
				this.m_nID = value;
				this.SetParameters();
			}
		}

		/// <summary>Specifies whether the content of the content control field should be deletable or not.</summary>
		[Category("Properties")]
		public bool ContentDeletable
		{
			get
			{
				return this.m_bContentDeletable;
			}
			set
			{
				this.m_bContentDeletable = value;
				this.SetParameters();
			}
		}

		/// <summary>Specifies whether the content of the content control field should be editable or not.</summary>
		[Category("Properties")]
		public bool ContentEditable
		{
			get
			{
				return this.m_bContentEditable;
			}
			set
			{
				this.m_bContentEditable = value;
				this.SetParameters();
			}
		}

		/// <summary>Gets or sets the type of the content control field.</summary>
		[Category("Properties")]
		public string Type
		{
			get
			{
				return this.m_strType;
			}
			set
			{
				this.m_strType = value;
				this.SetParameters();
			}
		}

		/// <summary>Gets or sets the placeholder field part of the content control field.</summary>
		[Category("Properties")]
		public List<DocPart> Placeholder
		{
			get
			{
				return this.m_placeholder;
			}
			set
			{
				this.m_placeholder = value;
				this.SetParameters();
			}
		}

		[Category("Properties")]
		[Browsable(false)]
		public XmlDocument XmlBaseStructure
		{
			get
			{
				XmlDocument xmlDocument = new XmlDocument();
				System.Xml.XmlElement xmlElement = xmlDocument.CreateElement("w:sdt", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
				xmlElement.SetAttribute("xmlns:m", "http://schemas.openxmlformats.org/officeDocument/2006/math");
				xmlElement.SetAttribute("xmlns:mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
				xmlElement.SetAttribute("xmlns:o", "urn:schemas-microsoft-com:office:office");
				xmlElement.SetAttribute("xmlns:r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships");
				xmlElement.SetAttribute("xmlns:v", "urn:schemas-microsoft-com:vml");
				xmlElement.SetAttribute("xmlns:w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
				xmlElement.SetAttribute("xmlns:w10", "urn:schemas-microsoft-com:office:word");
				xmlElement.SetAttribute("xmlns:w14", "http://schemas.microsoft.com/office/word/2010/wordml");
				xmlElement.SetAttribute("xmlns:w15", "http://schemas.microsoft.com/office/word/2012/wordml");
				xmlElement.SetAttribute("xmlns:wne", "http://schemas.microsoft.com/office/word/2006/wordml");
				xmlElement.SetAttribute("xmlns:wp", "http://schemas.openxmlformats.org/drawingml/2006/wordprocessingDrawing");
				xmlElement.SetAttribute("xmlns:wp14", "http://schemas.microsoft.com/office/word/2010/wordprocessingDrawing");
				xmlElement.SetAttribute("xmlns:wpc", "http://schemas.microsoft.com/office/word/2010/wordprocessingCanvas");
				xmlElement.SetAttribute("xmlns:wpg", "http://schemas.microsoft.com/office/word/2010/wordprocessingGroup");
				xmlElement.SetAttribute("xmlns:wpi", "http://schemas.microsoft.com/office/word/2010/wordprocessingInk");
				xmlElement.SetAttribute("xmlns:wps", "http://schemas.microsoft.com/office/word/2010/wordprocessingShape");
				XmlNode xmlNode = xmlDocument.AppendChild(xmlElement);
				System.Xml.XmlElement newChild = xmlDocument.CreateElement("w:sdtPr", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
				XmlNode xmlNode2 = xmlNode.AppendChild(newChild);
				System.Xml.XmlElement xmlElement2 = xmlDocument.CreateElement("w:alias", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
				xmlElement2.SetAttribute("w:val", this.Title);
				System.Xml.XmlElement xmlElement3 = xmlDocument.CreateElement("w:tag", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
				xmlElement3.SetAttribute("w:val", this.Tag);
				System.Xml.XmlElement xmlElement4 = xmlDocument.CreateElement("w:id", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
				xmlElement4.SetAttribute("w:val", this.Int64_0.ToString());
				System.Xml.XmlElement xmlElement5 = xmlDocument.CreateElement("w:lock", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
				xmlElement5.SetAttribute("w:val", "sdtContentLocked");
				System.Xml.XmlElement xmlElement6 = xmlDocument.CreateElement("w:lock", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
				xmlElement6.SetAttribute("w:val", "ContentLocked");
				if (this.Placeholder != null)
				{
					System.Xml.XmlElement xmlElement7 = xmlDocument.CreateElement("w:placeholder", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
					foreach (DocPart item in this.Placeholder)
					{
						System.Xml.XmlElement xmlElement8 = xmlDocument.CreateElement("w:docPart", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
						xmlElement8.SetAttribute("w:val", item.Value);
						xmlElement7.AppendChild(xmlElement8);
					}
					xmlNode2.AppendChild(xmlElement7);
				}
				System.Xml.XmlElement newChild2 = xmlDocument.CreateElement("w:text", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
				xmlNode2.AppendChild(xmlElement2);
				xmlNode2.AppendChild(xmlElement3);
				xmlNode2.AppendChild(xmlElement4);
				if (!this.ContentDeletable)
				{
					xmlNode2.AppendChild(xmlElement5);
				}
				if (!this.ContentEditable)
				{
					xmlNode2.AppendChild(xmlElement6);
				}
				if (this.Type == "PLAINTEXT")
				{
					xmlNode2.AppendChild(newChild2);
				}
				System.Xml.XmlElement newChild3 = xmlDocument.CreateElement("w:sdtEndPr", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
				xmlNode.AppendChild(newChild3);
				return xmlDocument;
			}
		}

		/// <summary>Initializes a new instance of the ContentControlFieldAdapter class with a connection to an existing ApplicationField.</summary>
		/// <param name="appField">Specifies the ApplicationField to be adapted.</param>
		public ContentControlFieldAdapter(ApplicationField appField)
			: base(appField)
		{
			this.GetParameters();
		}

		/// <summary>Initializes a complete new instance of the ContentControlFieldAdapter class without a connection to an existing ApplicationField.</summary>
		public ContentControlFieldAdapter()
		{
		}

		protected override void GenerateAppField()
		{
			base.ApplicationField = new ApplicationField(ApplicationFieldFormat.MSWord, "SDTBLOCK", "Field", new string[1] { this.XmlBaseStructure.OuterXml });
		}

		public static ContentControlFieldAdapter CreateContentControl(ApplicationField appField)
		{
			if (appField.TypeName != "SDTRUN" && appField.TypeName != "SDTBLOCK")
			{
				throw new ArgumentException(Resources.EXC_APPFIELD_NO_CONTENT_CONTROL, "appField");
			}
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(appField.Parameters[0]);
			XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
			xmlNamespaceManager.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			IEnumerator enumerator = xmlDocument.SelectNodes("/w:sdt/w:sdtPr", xmlNamespaceManager).GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					{
						IEnumerator enumerator2 = ((XmlNode)enumerator.Current).ChildNodes.GetEnumerator();
						try
						{
							while (enumerator2.MoveNext())
							{
								switch (((XmlNode)enumerator2.Current).LocalName)
								{
								case "date":
									return new DateContentControl(appField);
								case "dropDownList":
									return new DropDownListContentControl(appField);
								case "comboBox":
									return new ComboBoxContentControl(appField);
								case "checkbox":
									return new CheckBoxContentControl(appField);
								case "text":
									return new PlainTextContentControl(appField);
								}
							}
						}
						finally
						{
							IDisposable disposable2 = enumerator2 as IDisposable;
							if (disposable2 != null)
							{
								disposable2.Dispose();
							}
						}
					}
					return new RichTextContentControl(appField);
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			throw new ArgumentException(Resources.EXC_APPFIELD_UNKNOWN_CONTENT_CNTRL, "appField");
		}

		protected override void GetParameters()
		{
			if (base.ApplicationField.TypeName != "SDTRUN" && base.ApplicationField.TypeName != "SDTBLOCK" && base.ApplicationField.Parameters[0] == null)
			{
				return;
			}
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(base.ApplicationField.Parameters[0]);
			XmlNamespaceManager xmlNamespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
			xmlNamespaceManager.AddNamespace("w", "http://schemas.openxmlformats.org/wordprocessingml/2006/main");
			foreach (XmlNode item in xmlDocument.SelectNodes("/w:sdt/w:sdtPr", xmlNamespaceManager))
			{
				foreach (XmlNode childNode in item.ChildNodes)
				{
					switch (childNode.LocalName)
					{
					case "comboBox":
						this.m_strType = "COMBOBOX";
						break;
					case "checkbox":
						this.m_strType = "CHECKBOX";
						break;
					case "alias":
						if (childNode.Attributes["w:val"] != null)
						{
							this.m_strTitle = childNode.Attributes["w:val"].Value;
						}
						break;
					case "placeholder":
						this.m_placeholder = new List<DocPart>();
						foreach (XmlNode childNode2 in xmlDocument.SelectSingleNode("/w:sdt/w:sdtPr/w:placeholder", xmlNamespaceManager).ChildNodes)
						{
							if (childNode2.Attributes["w:val"] != null)
							{
								this.m_placeholder.Add(new DocPart(childNode2.Attributes["w:val"].Value));
							}
						}
						break;
					case "id":
						if (childNode.Attributes["w:val"] != null)
						{
							this.m_nID = Convert.ToInt32(childNode.Attributes["w:val"].Value);
						}
						break;
					case "dropDownList":
						this.m_strType = "DROPDOWNLIST";
						break;
					case "tag":
						if (childNode.Attributes["w:val"] != null)
						{
							this.m_strTag = childNode.Attributes["w:val"].Value;
						}
						break;
					case "lock":
						if (childNode.Attributes["w:val"] != null)
						{
							if (childNode.Attributes["w:val"].Value == "sdtContentLocked")
							{
								this.m_bContentDeletable = false;
							}
							else
							{
								this.m_bContentEditable = false;
							}
						}
						break;
					case "date":
						this.m_strType = "DATE";
						break;
					case "text":
						this.m_strType = "PLAINTEXT";
						break;
					}
				}
			}
		}
	}
}
