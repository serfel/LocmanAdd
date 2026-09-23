using System;
using System.Drawing;
using System.Reflection;

namespace DocumentServer.ProxyClasses.Barcodes
{
	internal abstract class ControlProxy
	{
		protected static Type s_controlType;

		protected static Assembly s_controlAssembly;

		internal static readonly byte[] TXPubKeyToken = new byte[8]// { 107, 131, 254, 154, 117, 207, 182, 56 };
																		{ 23, 255, 248, 167, 116, 0, 76, 102 };

		public object Control { get; protected set; }

		public Assembly ControlAssembly => ControlProxy.s_controlAssembly;

		internal abstract Color BackColor { get; set; }

		internal abstract Color ForeColor { get; set; }

		internal abstract double Width { get; set; }

		internal abstract double Height { get; set; }

		protected ControlProxy(double width, double height)
		{
			try
			{
				this.Control = Activator.CreateInstance(ControlProxy.s_controlType);
			}
			catch
			{
			}
			if (this.Control != null)
			{
				this.Width = width;
				this.Height = height;
			}
		}

		protected ControlProxy(object control)
		{
			this.Control = control;
		}

		protected static void LoadControlAssembly(AssemblyName controlAsmName)
		{
			if (!(ControlProxy.s_controlAssembly != null))
			{
				try
				{
					ControlProxy.s_controlAssembly = Assembly.Load(controlAsmName);
				}
				catch
				{
				}
			}
		}

		protected static void LoadControlType(string controlTypeName)
		{
			if (!(ControlProxy.s_controlAssembly == null))
			{
				ControlProxy.s_controlType = ControlProxy.s_controlAssembly.GetType(controlTypeName);
			}
		}
	}
}
