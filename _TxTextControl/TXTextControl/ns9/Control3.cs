using System;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using TXTextControl.DataVisualization;
using DocumentServer.ProxyClasses.Barcodes;

namespace ns9
{
	internal class Control3 : BarcodeControlProxy
	{
		private static readonly AssemblyName assemblyName_0;

		public const string string_0 = "TXTextControl.WPF.Barcode.TXBarcodeControl";

		static Control3()
		{
			Control3.assemblyName_0 = new AssemblyName
			{
				Name = "TXBarcode.WPF",
				Version = new Version(29, 0, 500, 500),
				CultureInfo = new CultureInfo("")
			};
			Control3.assemblyName_0.SetPublicKeyToken(DocumentServer.ProxyClasses.Barcodes.ControlProxy.TXPubKeyToken);
			DocumentServer.ProxyClasses.Barcodes.ControlProxy.LoadControlAssembly(Control3.assemblyName_0);
			DocumentServer.ProxyClasses.Barcodes.ControlProxy.LoadControlType("TXTextControl.WPF.Barcode.TXBarcodeControl");
		}

		internal Control3(double double_0, double double_1)
			: base(double_0, double_1)
		{
		}

		internal Control3(BarcodeFrame barcodeFrame_0)
			: base(barcodeFrame_0)
		{
		}

		protected override Color GetBackColor()
		{
			if (base.Control == null)
			{
				return SystemColors.Window;
			}
			return this.method_1(base.MemberInfos.propertyInfo_2, SystemColors.Window);
		}

		protected override void SetBackColor(Color color)
		{
			if (base.Control != null)
			{
				this.method_0(color, base.MemberInfos.propertyInfo_2, SystemColors.Window);
			}
		}

		protected override Color GetForeColor()
		{
			if (base.Control == null)
			{
				return SystemColors.WindowText;
			}
			return this.method_1(base.MemberInfos.propertyInfo_4, SystemColors.WindowText);
		}

		protected override void SetForeColor(Color color)
		{
			if (base.Control != null)
			{
				this.method_0(color, base.MemberInfos.propertyInfo_4, SystemColors.WindowText);
			}
		}

		private void method_0(Color color_0, PropertyInfo propertyInfo_0, Color color_1)
		{
			Type propertyType = propertyInfo_0.PropertyType;
			if (color_0 == color_1)
			{
				propertyInfo_0.SetValue(base.Control, null, null);
				return;
			}
			Type obj = propertyType.GetGenericArguments()[0];
			object obj2 = Activator.CreateInstance(obj);
			obj.GetProperty("A").SetValue(obj2, color_0.A, null);
			obj.GetProperty("R").SetValue(obj2, color_0.R, null);
			obj.GetProperty("G").SetValue(obj2, color_0.G, null);
			obj.GetProperty("B").SetValue(obj2, color_0.B, null);
			propertyInfo_0.SetValue(base.Control, obj2, null);
		}

		private Color method_1(PropertyInfo propertyInfo_0, Color color_0)
		{
			object value = propertyInfo_0.GetValue(base.Control, null);
			if (value == null)
			{
				return color_0;
			}
			Type type = value.GetType();
			return Color.FromArgb(Convert.ToInt32((byte)type.GetProperty("A").GetValue(value, null)), Convert.ToInt32((byte)type.GetProperty("R").GetValue(value, null)), Convert.ToInt32((byte)type.GetProperty("G").GetValue(value, null)), Convert.ToInt32((byte)type.GetProperty("B").GetValue(value, null)));
		}
	}
}
