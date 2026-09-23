using System;
using System.Reflection;

namespace TXTextControl
{
	public class proxyDocuments
	{
		private Assembly AssemblyDTE;

		private Type TypeDocuments;

		private object _documents;

		public int Count => (int)this.TypeDocuments.InvokeMember("Count", BindingFlags.GetProperty, null, this._documents, null);

		public proxyDocuments(Assembly assemblyDTE, object referencedDocuments)
		{
			this.AssemblyDTE = assemblyDTE;
			this.TypeDocuments = this.AssemblyDTE.GetType("EnvDTE.Documents");
			this._documents = referencedDocuments;
		}

		public object Item(int Index)
		{
			return this.TypeDocuments.InvokeMember("Item", BindingFlags.InvokeMethod, null, this._documents, new object[1] { Index });
		}
	}
}
