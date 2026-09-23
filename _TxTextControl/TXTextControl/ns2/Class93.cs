using System.Web.UI.WebControls;

namespace ns2
{
	internal class Class93
	{
		private Button button_0;

		public string String_0
		{
			get
			{
				return this.button_0.ToolTip;
			}
			set
			{
				this.button_0.ToolTip = value;
			}
		}

		public bool Boolean_0
		{
			get
			{
				return this.button_0.Visible;
			}
			set
			{
				this.button_0.Visible = value;
			}
		}

		public Class93(Button button_1)
		{
			this.button_0 = button_1;
		}
	}
}
