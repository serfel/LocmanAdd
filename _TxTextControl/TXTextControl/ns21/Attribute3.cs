using System;
using System.ComponentModel;
using System.Resources;
using TXTextControl;

namespace ns21
{
	[AttributeUsage(AttributeTargets.All)]
	internal class Attribute3 : DescriptionAttribute
	{
		private bool bool_0;

		public override string Description
		{
			get
			{
				if (!this.bool_0)
				{
					ResourceManager resourceManager = new ResourceManager(typeof(TextControlCore));
					base.DescriptionValue = resourceManager.GetString(base.Description);
					this.bool_0 = true;
				}
				return base.DescriptionValue;
			}
		}

		public Attribute3(string string_0)
			: base(string_0)
		{
		}
	}
}
