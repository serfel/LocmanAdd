using System;
using System.Reflection;

namespace TXTextControl
{
	public class proxyFileCodeModel
	{
		private Assembly AssemblyDTE;

		private Type TypeFileCodeModel;

		private object _fileCodeModel;

		public string Language => (string)this.TypeFileCodeModel.InvokeMember("Language", BindingFlags.GetProperty, null, this._fileCodeModel, null);

		public proxyFileCodeModel(Assembly assemblyDTE, object referencedFileCodeModel)
		{
			this.AssemblyDTE = assemblyDTE;
			this.TypeFileCodeModel = this.AssemblyDTE.GetType("EnvDTE.FileCodeModel");
			this._fileCodeModel = referencedFileCodeModel;
		}
	}
}
