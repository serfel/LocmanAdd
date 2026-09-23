using System.Drawing;
using System.Windows.Forms;

namespace ns16
{
	internal class EventArgs0 : HelpEventArgs
	{
		private Enum29 enum29_0;

		public Enum29 Enum29_0 => this.enum29_0;

		public EventArgs0(Enum29 enum29_1, Point point_0)
			: base(point_0)
		{
			this.enum29_0 = enum29_1;
		}
	}
}
