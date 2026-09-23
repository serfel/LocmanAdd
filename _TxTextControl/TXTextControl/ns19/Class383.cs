using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Xml;

namespace ns19
{
	internal class Class383 : Class381
	{
		internal class Class386
		{
			private Struct37 struct37_0;

			private Color color_0;

			internal float Single_0
			{
				get
				{
					if (this.struct37_0.Enum45_0 != Struct37.Enum45.const_8)
					{
						return this.struct37_0.Single_0 * 100f;
					}
					return this.struct37_0.Single_0;
				}
			}

			internal Color Color_0 => this.color_0;

			internal Class386(XmlElement xmlElement_0)
			{
				string attribute = xmlElement_0.GetAttribute("offset");
				string text = xmlElement_0.GetAttribute("stop-color");
				string text2 = xmlElement_0.GetAttribute("stop-opacity");
				if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(text2))
				{
					string attribute2 = xmlElement_0.GetAttribute("style");
					if (!string.IsNullOrEmpty(attribute2))
					{
						MatchCollection matchCollection = Class378.smethod_39(attribute2);
						for (int i = 0; i < matchCollection.Count; i++)
						{
							string[] string_;
							List<string> list = Class380.smethod_0(matchCollection[i].Value, out string_);
							foreach (string item in list)
							{
								if (item.Contains("stop-color:"))
								{
									text = item.Substring(item.IndexOf(':') + 1);
								}
								else if (item.Contains("stop-opacity:"))
								{
									text2 = item.Substring(item.IndexOf(':') + 1);
								}
							}
						}
					}
				}
				this.struct37_0 = new Struct37(attribute);
				this.color_0 = (string.IsNullOrEmpty(text) ? Color.Black : Class378.smethod_23(text).Value);
				int alpha = (string.IsNullOrEmpty(text2) ? 255 : ((int)Class378.smethod_24(text2)));
				this.color_0 = Color.FromArgb(alpha, this.color_0);
			}
		}

		protected List<Class386> list_0 = new List<Class386>();

		internal Class383(XmlElement xmlElement_0)
		{
			foreach (XmlNode childNode in xmlElement_0.ChildNodes)
			{
				if (childNode.Name == "stop")
				{
					this.list_0.Add(new Class386(childNode as XmlElement));
				}
			}
		}
	}
}
