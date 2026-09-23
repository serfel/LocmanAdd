using System;
using System.ComponentModel.Design;

namespace TXTextControl.Windows.Forms.Ribbon
{
	public class ApplicationMenuItemsEditor : CollectionEditor
	{
		private Type[] m_Types;

		public ApplicationMenuItemsEditor(Type type)
			: base(type)
		{
			this.m_Types = new Type[7]
			{
				typeof(RibbonButton),
				typeof(RibbonToggleButton),
				typeof(RibbonLabel),
				typeof(RibbonListView),
				typeof(RibbonSplitButton),
				typeof(RibbonMenuButton),
				typeof(RibbonSeperator)
			};
		}

		protected override Type[] CreateNewItemTypes()
		{
			return this.m_Types;
		}
	}
}
