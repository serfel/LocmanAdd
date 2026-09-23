using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace TX_Text_Control_Words.Charting
{
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class ChartDataGridDialog
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (ChartDataGridDialog.resourceMan == null)
				{
					ResourceManager resourceManager = (ChartDataGridDialog.resourceMan = new ResourceManager("TX_Text_Control_Words.Charting.ChartDataGridDialog", typeof(ChartDataGridDialog).Assembly));
				}
				return ChartDataGridDialog.resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return ChartDataGridDialog.resourceCulture;
			}
			set
			{
				ChartDataGridDialog.resourceCulture = value;
			}
		}

		internal static Point _cntxtMnuDataGrid_TrayLocation
		{
			get
			{
				object @object = ChartDataGridDialog.ResourceManager.GetObject("_cntxtMnuDataGrid.TrayLocation", ChartDataGridDialog.resourceCulture);
				return (Point)@object;
			}
		}

		internal ChartDataGridDialog()
		{
		}
	}
}
