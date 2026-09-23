using System;
using System.ComponentModel;
using System.Resources;
using DocumentServer.Properties;

namespace ns1
{
	[AttributeUsage(AttributeTargets.All)]
	internal class Attribute1 : DescriptionAttribute
	{
		private bool bool_0;

		public override string Description
		{
			get
			{
				if (!this.bool_0)
				{
					ResourceManager resourceManager = new ResourceManager(typeof(Resources));
					base.DescriptionValue = resourceManager.GetString(base.Description);
					this.bool_0 = true;
				}
				return base.DescriptionValue;
			}
		}

		public Attribute1(string string_0)
			: base(string_0)
		{
		}
	}
}
