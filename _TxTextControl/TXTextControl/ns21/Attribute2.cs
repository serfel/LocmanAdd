using System;
using System.ComponentModel;
using System.Resources;
using TXTextControl;

namespace ns21
{
	[AttributeUsage(AttributeTargets.All)]
	internal class Attribute2 : CategoryAttribute
	{
		public Attribute2(string string_0)
			: base(string_0)
		{
		}

		protected override string GetLocalizedString(string key)
		{
			ResourceManager resourceManager = new ResourceManager(typeof(TextControlCore));
			return resourceManager.GetString(key);
		}
	}
}
