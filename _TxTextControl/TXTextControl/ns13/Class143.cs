using System.Windows.Forms;

namespace ns13
{
	internal class Class143 : CheckedListBox
	{
		private bool bool_0;

		public Class143()
		{
			base.CheckOnClick = true;
		}

		protected override void OnItemCheck(ItemCheckEventArgs ice)
		{
			if (this.bool_0)
			{
				return;
			}
			this.bool_0 = true;
			if (ice.CurrentValue == CheckState.Checked)
			{
				ice.NewValue = CheckState.Checked;
				this.bool_0 = false;
				return;
			}
			for (int i = 0; i < base.Items.Count; i++)
			{
				if (i != ice.Index)
				{
					base.SetItemChecked(i, value: false);
				}
			}
			this.bool_0 = false;
			base.OnItemCheck(ice);
		}
	}
}
