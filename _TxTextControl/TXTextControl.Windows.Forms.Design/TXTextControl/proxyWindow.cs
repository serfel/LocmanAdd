using System;
using System.Reflection;

namespace TXTextControl
{
	public class proxyWindow
	{
		private Assembly AssemblyDTE;

		private Type TypeWindow;

		private object _window;

		public string Name => (string)this.TypeWindow.InvokeMember("Name", BindingFlags.GetProperty, null, this._window, null);

		public proxyWindow(Assembly assemblyDTE, object referencedWindow)
		{
			this.AssemblyDTE = assemblyDTE;
			this.TypeWindow = this.AssemblyDTE.GetType("EnvDTE.Window");
			this._window = referencedWindow;
		}

		public void Open()
		{
			this.TypeWindow.InvokeMember("Name", BindingFlags.GetProperty, null, this._window, null);
		}
	}
}
