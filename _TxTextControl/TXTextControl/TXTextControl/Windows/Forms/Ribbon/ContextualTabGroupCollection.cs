using System.Collections.Generic;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>The ContextualTabGroupCollection class represents all groups of ribbon tabs which are only shown in a certain context.</summary>
	public class ContextualTabGroupCollection : List<ContextualTabGroup>
	{
		private Ribbon ribbon_0;

		internal ContextualTabGroupCollection()
		{
		}

		internal ContextualTabGroupCollection(Ribbon ribbon)
		{
			this.ribbon_0 = ribbon;
		}

		public new void Add(ContextualTabGroup group)
		{
			group.ribbon_0 = this.ribbon_0;
			base.Add(group);
		}
	}
}
