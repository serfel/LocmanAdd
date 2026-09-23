using System;
using System.ComponentModel.Design;

namespace TXTextControl.Windows.Forms.Ribbon
{
	public class RibbonTabCollectionEditor : CollectionEditor
	{
		private Type[] m_Types;

		public RibbonTabCollectionEditor(Type type)
			: base(type)
		{
			this.m_Types = new Type[14]
			{
				typeof(RibbonTab),
				typeof(RibbonFormattingTab),
				typeof(RibbonInsertTab),
				typeof(RibbonTableLayoutTab),
				typeof(RibbonFrameLayoutTab),
				typeof(RibbonChartLayoutTab),
				typeof(RibbonPageLayoutTab),
				typeof(RibbonViewTab),
				typeof(RibbonProofingTab),
				typeof(RibbonReportingTab),
				typeof(RibbonPermissionsTab),
				typeof(RibbonFormulaTab),
				typeof(RibbonFormFieldsTab),
				typeof(RibbonReferencesTab)
			};
		}

		protected override Type[] CreateNewItemTypes()
		{
			return this.m_Types;
		}
	}
}
