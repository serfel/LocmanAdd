using System;
using System.ComponentModel.Design;

namespace TXTextControl.Windows.Forms.Ribbon
{
	public class ContextualTabGroupEditor : CollectionEditor
	{
		private Type[] m_Types;

		public ContextualTabGroupEditor(Type type)
			: base(type)
		{
			this.m_Types = new Type[1] { typeof(ContextualTabGroup) };
		}

		protected override Type[] CreateNewItemTypes()
		{
			return this.m_Types;
		}
	}
}
