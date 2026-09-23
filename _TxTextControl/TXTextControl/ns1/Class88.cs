using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using DocumentServer.Win32;

namespace ns1
{
	internal class Class88 : UITypeEditor
	{
		internal const string string_0 = "Report Data Source Configuration (*.rdsc)|*.rdsc";

		public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
		{
			return UITypeEditorEditStyle.Modal;
		}

		public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
		{
			if (context != null && provider != null)
			{
				string path = value as string;
				string initialDir = "";
				try
				{
					initialDir = Path.GetDirectoryName(path);
				}
				catch
				{
				}
				path = OpenFileDialog.SelectFile("Report Data Source Configuration (*.rdsc)|*.rdsc", initialDir, null);
				if (path != null)
				{
					value = path;
				}
			}
			return value ?? "";
		}
	}
}
