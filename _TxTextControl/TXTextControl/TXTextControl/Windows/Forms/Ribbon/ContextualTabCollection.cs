using System.Collections.Generic;

namespace TXTextControl.Windows.Forms.Ribbon
{
	public class ContextualTabCollection : List<RibbonTab>
	{
		private ContextualTabGroup contextualTabGroup_0;

		internal ContextualTabCollection()
		{
		}

		internal ContextualTabCollection(ContextualTabGroup group)
		{
			this.contextualTabGroup_0 = group;
		}

		public new void Add(RibbonTab tab)
		{
			base.Add(tab);
			if (!this.contextualTabGroup_0.Visible || base.Count <= 1)
			{
				return;
			}
			Ribbon ribbon_ = this.contextualTabGroup_0.ribbon_0;
			if (ribbon_ != null)
			{
				RibbonTab page = base[base.Count - 2];
				int num = ribbon_.TabPages.IndexOf(page);
				if (num != -1)
				{
					ribbon_.TabPages.Insert(num + 1, tab);
					this.contextualTabGroup_0.method_0();
				}
			}
		}

		public new bool Remove(RibbonTab tab)
		{
			bool result = base.Remove(tab);
			if (this.contextualTabGroup_0.Visible)
			{
				Ribbon ribbon_ = this.contextualTabGroup_0.ribbon_0;
				if (ribbon_ != null)
				{
					if (ribbon_.TabPages.IndexOf(tab) == ribbon_.SelectedIndex)
					{
						ribbon_.SelectedIndex = -1;
					}
					ribbon_.TabPages.Remove(tab);
					this.contextualTabGroup_0.method_0();
					if (ribbon_.SelectedIndex == -1 && !ribbon_.Minimized)
					{
						ribbon_.method_7();
					}
				}
			}
			return result;
		}
	}
}
