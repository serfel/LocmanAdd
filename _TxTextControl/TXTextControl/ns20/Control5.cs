using System;
using TXTextControl;
using TXTextControl.DataVisualization;

namespace ns20
{
	internal class Control5 : ControlList
	{
		internal Control5(TextControlCore textControlCore_0)
			: base(textControlCore_0)
		{
		}

		internal override ControlProxy CreateControlProxy(object control)
		{
			if (control != null && (control.GetType().Name != "Chart" || control.GetType().Namespace != "System.Windows.Forms.DataVisualization.Charting"))
			{
				throw new ArgumentException(base.m_tx.method_1().GetString("ERR_INVALIDCHART"));
			}
			return new Control9(control);
		}
	}
}
