using System;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using TXTextControl.DataVisualization;
using DocumentServer.ProxyClasses.Barcodes;

namespace ns9
{
	internal class Control2 : BarcodeControlProxy
	{
		private static readonly AssemblyName assemblyName_0;

		public const string string_0 = "TXTextControl.Barcode.TXBarcodeControl";

		static Control2()
		{
			Control2.assemblyName_0 = new AssemblyName
			{
				Name = "TXBarcode.Windows.Forms",
				Version = new Version(29, 0, 500, 500),
				CultureInfo = new CultureInfo("")
			};
			Control2.assemblyName_0.SetPublicKeyToken(DocumentServer.ProxyClasses.Barcodes.ControlProxy.TXPubKeyToken);
			DocumentServer.ProxyClasses.Barcodes.ControlProxy.LoadControlAssembly(Control2.assemblyName_0);
			DocumentServer.ProxyClasses.Barcodes.ControlProxy.LoadControlType("TXTextControl.Barcode.TXBarcodeControl");
		}

		internal Control2(double double_0, double double_1)
			: base(double_0, double_1)
		{
		}

		internal Control2(BarcodeFrame barcodeFrame_0)
			: base(barcodeFrame_0)
		{
		}

		protected override Color GetBackColor()
		{
			if (base.Control == null)
			{
				return Color.Transparent;
			}
			return (Color)base.MemberInfos.propertyInfo_2.GetValue(base.Control, null);
		}

		protected override void SetBackColor(Color color)
		{
			if (base.Control != null)
			{
				base.MemberInfos.propertyInfo_2.SetValue(base.Control, color, null);
			}
		}

		protected override Color GetForeColor()
		{
			if (base.Control == null)
			{
				return SystemColors.WindowText;
			}
			return (Color)base.MemberInfos.propertyInfo_4.GetValue(base.Control, null);
		}

		protected override void SetForeColor(Color color)
		{
			if (base.Control != null)
			{
				base.MemberInfos.propertyInfo_4.SetValue(base.Control, color, null);
			}
		}
	}
}
