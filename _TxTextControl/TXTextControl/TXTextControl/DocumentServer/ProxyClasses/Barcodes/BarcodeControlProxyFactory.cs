using System;
using ns9;
using TXTextControl.DataVisualization;

namespace DocumentServer.ProxyClasses.Barcodes
{
	internal static class BarcodeControlProxyFactory
	{
		internal static BarcodeControlProxy MakeControlProxy(BarcodeFrame frame)
		{
			string fullName = frame.Barcode.GetType().FullName;
			if (fullName == "TXTextControl.Barcode.TXBarcodeControl")
			{
				return new Control2(frame);
			}
			if (!(fullName == "TXTextControl.WPF.Barcode.TXBarcodeControl"))
			{
				throw new Exception("Barcode type “" + fullName + "” not supported.");
			}
			return new Control3(frame);
		}
	}
}
