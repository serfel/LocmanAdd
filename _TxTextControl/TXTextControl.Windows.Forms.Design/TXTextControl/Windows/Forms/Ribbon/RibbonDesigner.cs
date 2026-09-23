using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Security.Permissions;
using System.Windows.Forms.Design;

namespace TXTextControl.Windows.Forms.Ribbon
{
	[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
	public class RibbonDesigner : ParentControlDesigner
	{
		private DesignerActionListCollection actionLists;

		private bool m_bRibbonSelected;

		private int m_iLastSelectedTabIndex;

		public override DesignerActionListCollection ActionLists
		{
			get
			{
				if (this.actionLists == null)
				{
					this.actionLists = new DesignerActionListCollection();
					this.actionLists.Add(new RibbonActionList(base.Component));
				}
				return this.actionLists;
			}
		}

		public override void Initialize(IComponent component)
		{
			base.Initialize(component);
			base.AutoResizeHandles = true;
			ISelectionService selectionService = (ISelectionService)this.GetService(typeof(ISelectionService));
			if (selectionService != null)
			{
				selectionService.SelectionChanged += OnSelectionChanged;
			}
		}

		protected override void OnCreateHandle()
		{
			base.OnCreateHandle();
			Ribbon ribbon = this.Control as Ribbon;
			if (ribbon != null)
			{
				this.m_iLastSelectedTabIndex = ribbon.SelectedIndex;
				ribbon.SelectedIndexChanged += Ribbon_SelectedIndexChanged;
			}
		}

		private void OnSelectionChanged(object sender, EventArgs e)
		{
			ISelectionService selectionService = (ISelectionService)this.GetService(typeof(ISelectionService));
			this.m_bRibbonSelected = false;
			if (selectionService == null)
			{
				return;
			}
			ICollection selectedComponents = selectionService.GetSelectedComponents();
			Ribbon ribbon = (Ribbon)base.Component;
			foreach (object item in selectedComponents)
			{
				if (item == ribbon)
				{
					this.m_bRibbonSelected = true;
				}
			}
		}

		private void Ribbon_SelectedIndexChanged(object sender, EventArgs e)
		{
			Ribbon ribbon = this.Control as Ribbon;
			if (ribbon != null)
			{
				if (ribbon.SelectedIndex == 0 && ribbon.HasApplicationMenu)
				{
					ribbon.SelectedIndex = Math.Max(0, Math.Min(this.m_iLastSelectedTabIndex, ribbon.TabCount - 1));
				}
				this.m_iLastSelectedTabIndex = ribbon.SelectedIndex;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				ISelectionService selectionService = (ISelectionService)this.GetService(typeof(ISelectionService));
				if (selectionService != null)
				{
					selectionService.SelectionChanged -= OnSelectionChanged;
				}
			}
			base.Dispose(disposing);
		}

		protected override bool GetHitTest(Point point)
		{
			Ribbon ribbon = this.Control as Ribbon;
			if (ribbon != null && this.m_bRibbonSelected)
			{
				Point pt = this.Control.PointToClient(point);
				return !ribbon.DisplayRectangle.Contains(pt);
			}
			return false;
		}
	}
}
