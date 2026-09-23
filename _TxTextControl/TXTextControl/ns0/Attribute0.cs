using System;
using System.ComponentModel;
using System.Resources;
using TXTextControl.Barcode;

namespace ns0
{
	[AttributeUsage(AttributeTargets.All)]
	internal class Attribute0 : DescriptionAttribute
	{
		private bool bool_0;

		public override string Description
		{
			get
			{
				if (!this.bool_0)
				{
					ResourceManager resourceManager = new ResourceManager(typeof(TXBarcodeCore));
					base.DescriptionValue = resourceManager.GetString(base.Description);
					this.bool_0 = true;
				}
				return base.DescriptionValue;
			}
		}

		public Attribute0(string string_0)
			: base(string_0)
		{
		}
	}
}
