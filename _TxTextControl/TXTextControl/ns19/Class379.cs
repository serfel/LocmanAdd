using System.Xml;
using TXTextControl;

namespace ns19
{
	internal class Class379 : Def
	{
		private string string_0 = "";

		private XmlNode xmlNode_0;

		public string Identifier => this.string_0;

		internal XmlNode XmlNode_0 => this.xmlNode_0;

		internal Class379(XmlNode xmlNode_1)
		{
			this.string_0 = xmlNode_1.Name;
			this.xmlNode_0 = xmlNode_1;
		}
	}
}
