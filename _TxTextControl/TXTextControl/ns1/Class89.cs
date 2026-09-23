using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.IO;
using DocumentServer.Win32;

namespace ns1
{
	internal class Class89 : UITypeEditor
	{
		internal const string string_0 = "Microsoft Word (*.docx)|*.docx|Internal TX TextControl Unicode Format (*.tx)|*.tx|Microsoft Word 97-2003 (*.doc)|*.doc|Rich Text Format (*.rtf)|*.rtf";

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
				path = OpenFileDialog.SelectFile("Microsoft Word (*.docx)|*.docx|Internal TX TextControl Unicode Format (*.tx)|*.tx|Microsoft Word 97-2003 (*.doc)|*.doc|Rich Text Format (*.rtf)|*.rtf", initialDir, null);
				if (path != null)
				{
					value = path;
				}
			}
			return value ?? "";
		}
	}
}
