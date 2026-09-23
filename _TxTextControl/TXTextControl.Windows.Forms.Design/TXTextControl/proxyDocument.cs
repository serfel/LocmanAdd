using System;
using System.Reflection;

namespace TXTextControl
{
	public class proxyDocument
	{
		private Assembly AssemblyDTE;

		private Type TypeDocument;

		private object _document;

		public string Name => (string)this.TypeDocument.InvokeMember("Name", BindingFlags.GetProperty, null, this._document, null);

		public object Selection => this.TypeDocument.InvokeMember("Selection", BindingFlags.GetProperty, null, this._document, null);

		public object ProjectItem => this.TypeDocument.InvokeMember("ProjectItem", BindingFlags.GetProperty, null, this._document, null);

		public proxyDocument(Assembly assemblyDTE, object referencedDocument)
		{
			this.AssemblyDTE = assemblyDTE;
			this.TypeDocument = this.AssemblyDTE.GetType("EnvDTE.Document");
			this._document = referencedDocument;
		}

		public bool MarkText(string strText, int iFlags)
		{
			return (bool)this.TypeDocument.InvokeMember("MarkText", BindingFlags.InvokeMethod, null, this._document, new object[2] { strText, iFlags });
		}

		public bool ReplaceText(string strText, string strReplace, int iFlags)
		{
			return (bool)this.TypeDocument.InvokeMember("ReplaceText", BindingFlags.InvokeMethod, null, this._document, new object[3] { strText, strReplace, iFlags });
		}
	}
}
