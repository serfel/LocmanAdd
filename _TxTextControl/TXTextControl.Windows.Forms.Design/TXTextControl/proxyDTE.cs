using System;
using System.Reflection;

namespace TXTextControl
{
	public class proxyDTE
	{
		private object _dte;

		private Assembly AssemblyDTE;

		private Type TypeDTE;

		private Type TypeDocument;

		public object ActiveDocument => this.TypeDTE.InvokeMember("ActiveDocument", BindingFlags.GetProperty, null, this._dte, null);

		public string Name => (string)this.TypeDTE.InvokeMember("Name", BindingFlags.GetProperty, null, this._dte, null);

		public object Documents => this.TypeDTE.InvokeMember("Documents", BindingFlags.GetProperty, null, this._dte, null);

		public proxyDTE(Assembly assemblyDTE, object referencedDTE)
		{
			this._dte = referencedDTE;
			this.AssemblyDTE = assemblyDTE;
			this.TypeDTE = this.AssemblyDTE.GetType("EnvDTE.DTE");
			this.TypeDocument = this.AssemblyDTE.GetType("EnvDTE.Document");
		}
	}
}
