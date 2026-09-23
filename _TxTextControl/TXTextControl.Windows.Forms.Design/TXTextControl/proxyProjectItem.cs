using System;
using System.Reflection;

namespace TXTextControl
{
	public class proxyProjectItem
	{
		private Assembly AssemblyDTE;

		private Type TypeProjectItem;

		private object _projectItem;

		public string Name => (string)this.TypeProjectItem.InvokeMember("Name", BindingFlags.GetProperty, null, this._projectItem, null);

		public object FileCodeModel => this.TypeProjectItem.InvokeMember("FileCodeModel", BindingFlags.GetProperty, null, this._projectItem, null);

		public proxyProjectItem(Assembly assemblyDTE, object referencedProjectItem)
		{
			this.AssemblyDTE = assemblyDTE;
			this.TypeProjectItem = this.AssemblyDTE.GetType("EnvDTE.ProjectItem");
			this._projectItem = referencedProjectItem;
		}

		public object Open()
		{
			return this.TypeProjectItem.InvokeMember("Open", BindingFlags.InvokeMethod, null, this._projectItem, new string[1] { "{7651A701-06E5-11D1-8EBD-00A0C90F26EA}" });
		}
	}
}
