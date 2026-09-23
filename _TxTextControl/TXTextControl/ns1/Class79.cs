using System;
using System.ComponentModel;
using System.Drawing.Design;
using DocumentServer.Win32;

namespace ns1
{
	internal class Class79 : UITypeEditor
	{
		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			if (context != null && provider != null)
			{
				string initialPath = value as string;
				initialPath = FolderBrowserDialog.SelectFolder(null, initialPath, IntPtr.Zero);
				if (initialPath != null)
				{
					value = initialPath;
				}
			}
			return value;
		}
	}
}
