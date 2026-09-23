using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Reflection;
using TXTextControl.DataVisualization;

namespace ns20
{
	internal class Control9 : ControlProxy
	{
		private Type type_0;

		private Type type_1;

		internal Control9(object object_0)
		{
			if (object_0 == null)
			{
				this.method_0(null);
				base.m_Control = Activator.CreateInstance(base.m_typeControl);
			}
			else
			{
				this.method_0(object_0.GetType());
				base.m_Control = object_0;
			}
		}

		private void method_0(Type type_2)
		{
			Assembly assembly;
			if (type_2 == null)
			{
				Version version = Environment.Version;
				AssemblyName assemblyName = new AssemblyName();
				assemblyName.Name = "System.Windows.Forms.DataVisualization";
				assemblyName.Version = ((version.Major >= 4) ? new Version(4, 0, 0, 0) : new Version(3, 5, 0, 0));
				assemblyName.CultureInfo = new CultureInfo("");
				byte[] publicKeyToken = new byte[8] { 49, 191, 56, 86, 173, 54, 78, 53 };
				assemblyName.SetPublicKeyToken(publicKeyToken);
				assemblyName.ProcessorArchitecture = ProcessorArchitecture.MSIL;
				assembly = Assembly.Load(assemblyName);
			}
			else
			{
				assembly = Assembly.GetAssembly(type_2);
			}
			base.m_typeControl = assembly.GetType("System.Windows.Forms.DataVisualization.Charting.Chart");
			this.type_0 = assembly.GetType("System.Windows.Forms.DataVisualization.Charting.ChartSerializer");
			this.type_1 = assembly.GetType("System.Windows.Forms.DataVisualization.Charting.PrintingManager");
		}

		internal override void Load(Stream stream)
		{
			object[] parameters = new object[1] { stream };
			Type[] types = new Type[1] { stream.GetType() };
			object value = base.m_typeControl.GetProperty("Serializer").GetValue(base.m_Control, null);
			this.type_0.GetMethod("Load", types).Invoke(value, parameters);
		}

		internal override void Save(Stream stream)
		{
			object[] parameters = new object[1] { stream };
			Type[] types = new Type[1] { stream.GetType() };
			object value = base.m_typeControl.GetProperty("Serializer").GetValue(base.m_Control, null);
			this.type_0.GetMethod("Save", types).Invoke(value, parameters);
		}

		internal override void SaveImage(Stream stream, ImageFormat format)
		{
			object[] parameters = new object[2] { stream, format };
			Type[] types = new Type[2]
			{
				stream.GetType(),
				format.GetType()
			};
			base.m_typeControl.GetMethod("SaveImage", types).Invoke(base.m_Control, parameters);
		}

		internal override void PrintPaint(Graphics graphics, Rectangle position)
		{
			object[] parameters = new object[2] { graphics, position };
			object value = base.m_typeControl.GetProperty("Printing").GetValue(base.m_Control, null);
			this.type_1.GetMethod("PrintPaint").Invoke(value, parameters);
		}
	}
}
