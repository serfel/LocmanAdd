using System;
using System.Reflection;

namespace TXTextControl
{
	public class proxyTextSelection
	{
		private Assembly AssemblyDTE;

		private Type TypeTextSelection;

		private object _textSelection;

		public string Text
		{
			get
			{
				return (string)this.TypeTextSelection.InvokeMember("Text", BindingFlags.GetProperty, null, this._textSelection, null);
			}
			set
			{
				this.TypeTextSelection.InvokeMember("Text", BindingFlags.SetProperty, null, this._textSelection, new string[1] { value });
			}
		}

		public proxyTextSelection(Assembly assemblyDTE, object referencedTextSelection)
		{
			this.AssemblyDTE = assemblyDTE;
			this.TypeTextSelection = this.AssemblyDTE.GetType("EnvDTE.TextSelection");
			this._textSelection = referencedTextSelection;
		}

		public void SelectAll()
		{
			this.TypeTextSelection.InvokeMember("SelectAll", BindingFlags.InvokeMethod, null, this._textSelection, null);
		}

		public void DeleteWhitespace(int Direction)
		{
			this.TypeTextSelection.InvokeMember("DeleteWhitespace", BindingFlags.InvokeMethod, null, this._textSelection, new object[1] { Direction });
		}

		public string Insert(string text, int flags)
		{
			return (string)this.TypeTextSelection.InvokeMember("Insert", BindingFlags.InvokeMethod, null, this._textSelection, new object[2] { text, flags });
		}
	}
}
