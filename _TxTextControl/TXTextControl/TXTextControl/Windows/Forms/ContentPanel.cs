using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms
{
	internal abstract class ContentPanel : TableLayoutPanel, IContainerControl
	{
		internal enum Enum140
		{
			const_0,
			const_1,
			const_2
		}

		internal class EventArgs4 : EventArgs
		{
			private Control control_0;

			internal Control Control_0 => this.control_0;

			internal EventArgs4(Control control_1)
			{
				this.control_0 = control_1;
			}
		}

		internal class EventArgs5 : EventArgs
		{
			private Control control_0;

			internal Control Control_0 => this.control_0;

			internal EventArgs5(Control control_1)
			{
				this.control_0 = control_1;
			}
		}

		internal ResourceManager m_rm = new ResourceManager(typeof(TextControlCore));

		internal Enum140 m_cpaPanelAlignment;

		private TextControl m_txTextControl;

		internal bool m_bIsDesignMode;

		private Control m_ctrlActiveControl;

		private bool m_bNoFocusSet = true;

		protected Sidebar.SidebarContentLayout m_sclContentLayout;

		protected Dictionary<string, Control> m_dicItems = new Dictionary<string, Control>();

		protected PointF m_pntDpi = PointF.Empty;

		protected bool IsSidebarShown
		{
			get
			{
				if (this.Sidebar != null)
				{
					return this.Sidebar.IsShown;
				}
				return true;
			}
		}

		internal Enum140 PanelAlignment
		{
			get
			{
				return this.m_cpaPanelAlignment;
			}
			set
			{
				if (this.m_cpaPanelAlignment != (this.m_cpaPanelAlignment = value))
				{
					this.SetAlignment(this.m_cpaPanelAlignment, this.m_pntDpi);
				}
			}
		}

		internal PointF Dpi => this.m_pntDpi;

		internal Sidebar Sidebar { get; set; }

		internal TextControl TextControl
		{
			get
			{
				return this.m_txTextControl;
			}
			set
			{
				if (value != null && value.method_2())
				{
					return;
				}
				TextControl txTextControl = this.m_txTextControl;
				if (this.m_txTextControl != (this.m_txTextControl = value))
				{
					if (this.m_txTextControl != null)
					{
						this.RightToLeft = this.TextControl.RightToLeft;
					}
					this.UpdateTextControlBindings(txTextControl, value);
				}
			}
		}

		public Control ActiveControl
		{
			get
			{
				return this.m_ctrlActiveControl;
			}
			set
			{
				if (this.m_ctrlActiveControl != null)
				{
					this.m_ctrlActiveControl.LostFocus -= ActiveControl_LostFocus;
				}
				if (this.m_ctrlActiveControl != value)
				{
					if (this.m_ctrlActiveControl != null)
					{
						this.OnControlDeactivated(new EventArgs5(this.m_ctrlActiveControl));
					}
					if (value != null)
					{
						this.OnControlActivated(new EventArgs4(value));
					}
				}
				this.m_ctrlActiveControl = value;
				if (this.m_ctrlActiveControl != null)
				{
					this.m_ctrlActiveControl.LostFocus += ActiveControl_LostFocus;
					this.CheckGotFocus();
				}
			}
		}

		internal event EventHandler ControlActivated;

		internal event EventHandler ControlDeactivated;

		internal ContentPanel(Enum140 panelAlignment, TextControl textControl, bool isDesignMode, Sidebar.SidebarContentLayout contentLayout, PointF dpi)
		{
			base.SetStyle(ControlStyles.ContainerControl, value: true);
			this.m_pntDpi = dpi;
			this.m_bIsDesignMode = isDesignMode;
			this.m_sclContentLayout = contentLayout;
			this.AutoSize = true;
			this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			if (this.TextControl != null)
			{
				this.RightToLeft = this.TextControl.RightToLeft;
			}
			this.m_cpaPanelAlignment = panelAlignment;
			this.InitializeItems();
			this.SetAlignment(this.m_cpaPanelAlignment, this.m_pntDpi);
			this.TextControl = textControl;
		}

		internal virtual Control FindItem(string itemName)
		{
			this.m_dicItems.TryGetValue(itemName, out var value);
			return value;
		}

		internal virtual void UpdateTextControlBindings(TextControl oldTextcontrol, TextControl newTextControl)
		{
		}

		internal virtual void UpdateContent()
		{
		}

		internal virtual void DoLayout()
		{
		}

		internal virtual void DoSuspendLayout()
		{
		}

		internal virtual void InitializeItems()
		{
		}

		internal virtual void SetDialogAlignment()
		{
			if (!this.m_pntDpi.IsEmpty)
			{
				this.AwareOfDPI_Dialog();
			}
		}

		internal virtual void SetHorizontalAlignment()
		{
			if (!this.m_pntDpi.IsEmpty)
			{
				this.AwareOfDPI_Horizontal();
			}
		}

		internal virtual void SetVerticalAlignment()
		{
			if (!this.m_pntDpi.IsEmpty)
			{
				this.AwareOfDPI_Vertical();
			}
		}

		internal virtual void AwareOfDPI_Intialize()
		{
		}

		internal virtual void AwareOfDPI_Dialog()
		{
		}

		internal virtual void AwareOfDPI_Horizontal()
		{
		}

		internal virtual void AwareOfDPI_Vertical()
		{
		}

		internal virtual void HandleFontUpdated()
		{
		}

		internal void AwareOfDPI(PointF dpi)
		{
			if (dpi.X != this.m_pntDpi.X || dpi.Y != this.m_pntDpi.Y)
			{
				this.m_pntDpi = dpi;
				Class517.smethod_0(this.m_pntDpi);
				this.AwareOfDPI_Intialize();
				switch (this.m_cpaPanelAlignment)
				{
				case Enum140.const_0:
					this.AwareOfDPI_Dialog();
					break;
				case Enum140.const_1:
					this.AwareOfDPI_Horizontal();
					break;
				case Enum140.const_2:
					this.AwareOfDPI_Vertical();
					break;
				}
			}
		}

		internal void SetAlignment(Enum140 panelAlignment, PointF dpi)
		{
			this.DoSuspendLayout();
			this.m_pntDpi = dpi;
			this.AwareOfDPI_Intialize();
			switch (panelAlignment)
			{
			case Enum140.const_0:
				this.SetDialogAlignment();
				break;
			case Enum140.const_1:
				this.SetHorizontalAlignment();
				break;
			case Enum140.const_2:
				this.SetVerticalAlignment();
				break;
			}
			this.DoLayout();
		}

		protected virtual void OnControlActivated(EventArgs4 eventArgs4_0)
		{
			if (this.ControlActivated != null)
			{
				this.ControlActivated(this, eventArgs4_0);
			}
		}

		protected virtual void OnControlDeactivated(EventArgs5 eventArgs5_0)
		{
			if (this.ControlDeactivated != null)
			{
				this.ControlDeactivated(this, eventArgs5_0);
			}
		}

		public bool ActivateControl(Control active)
		{
			if (this.IsChildControl(base.Controls, active))
			{
				active.Select();
				this.m_ctrlActiveControl = active;
				return true;
			}
			return false;
		}

		private bool IsChildControl(ControlCollection collection, Control active)
		{
			if (collection.Contains(active))
			{
				return true;
			}
			foreach (Control item in collection)
			{
				if (this.IsChildControl(item.Controls, active))
				{
					return true;
				}
			}
			return false;
		}

		private void ActiveControl_LostFocus(object sender, EventArgs e)
		{
			(sender as Control).LostFocus -= ActiveControl_LostFocus;
			this.CheckLostFocus();
			if (this.m_ctrlActiveControl != null)
			{
				this.OnControlDeactivated(new EventArgs5(this.m_ctrlActiveControl));
			}
			this.m_ctrlActiveControl = null;
		}

		private void CheckGotFocus()
		{
			if (this.m_bNoFocusSet)
			{
				this.OnContentPanelGotFocus();
			}
		}

		private void CheckLostFocus()
		{
			if (!base.ContainsFocus)
			{
				this.OnContentPanelLostFocus();
			}
		}

		protected virtual void OnContentPanelGotFocus()
		{
			this.m_bNoFocusSet = false;
		}

		protected virtual void OnContentPanelLostFocus()
		{
			this.m_bNoFocusSet = true;
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			if (this.m_ctrlActiveControl != null && (keyData & (Keys.Control | Keys.Alt)) == 0)
			{
				Keys keys = keyData & Keys.KeyCode;
				switch (keys)
				{
				case Keys.Left:
				case Keys.Up:
				case Keys.Right:
				case Keys.Down:
				{
					bool forward2 = keys == Keys.Right || keys == Keys.Down;
					Control control = this;
					if (this.ActiveControl != null)
					{
						control = this.ActiveControl.Parent;
					}
					if (control.SelectNextControl(this.ActiveControl, forward2, tabStopOnly: false, nested: false, wrap: true))
					{
						this.ActiveControl.Focus();
						return true;
					}
					break;
				}
				case Keys.Tab:
				{
					bool forward = (keyData & Keys.Shift) == 0;
					if (base.SelectNextControl(this.m_ctrlActiveControl, forward, tabStopOnly: true, nested: true, wrap: true))
					{
						this.ActiveControl.Focus();
						return true;
					}
					break;
				}
				}
			}
			return base.ProcessDialogKey(keyData);
		}

		protected override bool ProcessMnemonic(char charCode)
		{
			if (base.Controls.Count == 0)
			{
				return false;
			}
			Control activeControl = this.ActiveControl;
			bool flag = false;
			bool flag2 = false;
			Control control = activeControl;
			do
			{
				control = base.GetNextControl(control, forward: true);
				if (control == null)
				{
					if (flag2)
					{
						break;
					}
					flag2 = true;
					continue;
				}
				MethodInfo method = control.GetType().GetMethod("ProcessMnemonic", BindingFlags.Instance | BindingFlags.NonPublic);
				if (!(method != null) || !(bool)method.Invoke(control, new object[1] { charCode }))
				{
					continue;
				}
				if (control.Name != null)
				{
					switch (control.Name)
					{
					case "TXITEM_CustomPropertiesLabel":
					case "TXITEM_EmbeddedFilesLabel":
					case "TXITEM_FindOptionsLabel":
						base.SelectNextControl(control, forward: false, tabStopOnly: true, nested: true, wrap: false);
						if (this.m_ctrlActiveControl != null && this.m_ctrlActiveControl is Sidebar.Class584)
						{
							(this.m_ctrlActiveControl as Sidebar.Class584).Checked = !(this.m_ctrlActiveControl as Sidebar.Class584).Checked;
							flag = true;
						}
						break;
					}
				}
				if (!flag && this.m_ctrlActiveControl != null && !this.m_ctrlActiveControl.Focused)
				{
					this.m_ctrlActiveControl.Focus();
				}
				flag = true;
				break;
			}
			while (control != activeControl);
			return flag;
		}
	}
}
