using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>The RibbonMenuButton class is a button control that displays a drop-down menu when clicked.</summary>
	public class RibbonMenuButton : RibbonButton, IRibbonItem
	{
		protected bool m_bIsDropDownOpen;

		internal RibbonDropDown ribbonDropDown_0;

		private RibbonGroup ribbonGroup_0;

		private RibbonItemCollection ribbonItemCollection_1;

		[Obfuscation(Exclude = true)]
		private static readonly object DropDownClosedEvent = new object();

		[Obfuscation(Exclude = true)]
		private static readonly object DropDownOpeningEvent = new object();

		/// <summary>Gets the collection of controls in the drop-down menu that is associated with this RibbonMenuButton.</summary>
		[Category("Behavior")]
		public RibbonItemCollection DropDownItems => this.ribbonItemCollection_1;

		internal bool Boolean_2
		{
			get
			{
				return base.m_bDrawLargeIconBorder;
			}
			set
			{
				base.m_bDrawLargeIconBorder = value;
			}
		}

		/// <summary>Occurs as the RibbonMenuButton's drop-down menu is closed.</summary>
		public event EventHandler DropDownClosed
		{
			add
			{
				base.Events.AddHandler(RibbonMenuButton.DropDownClosedEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(RibbonMenuButton.DropDownClosedEvent, value);
			}
		}

		/// <summary>Occurs as the RibbonMenuButton's drop-down menu is opening.</summary>
		public event EventHandler DropDownOpening
		{
			add
			{
				base.Events.AddHandler(RibbonMenuButton.DropDownOpeningEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(RibbonMenuButton.DropDownOpeningEvent, value);
			}
		}

		/// <summary>Initializes a new instance of the RibbonMenuButton class.</summary>
		public RibbonMenuButton()
		{
			base.m_bHasDropDown = true;
			this.ribbonItemCollection_1 = new RibbonItemCollection(this);
		}

		internal RibbonMenuButton(RibbonGroup parent)
		{
			this.ribbonGroup_0 = parent;
			base.m_bHasDropDown = true;
			this.ribbonItemCollection_1 = new RibbonItemCollection(this.ribbonGroup_0);
		}

		internal RibbonDropDown method_18()
		{
			this.method_21();
			if (this.ribbonDropDown_0 == null)
			{
				this.ribbonDropDown_0 = new RibbonDropDown();
				this.ribbonDropDown_0.Closed += ribbonDropDown_0_Closed;
			}
			Size size3 = (this.ribbonDropDown_0.Size = (this.ribbonDropDown_0.MaximumSize = default(Size)));
			int num = 27;
			if (this.ribbonGroup_0 != null)
			{
				this.ribbonDropDown_0 = new RibbonDropDown();
				RibbonGroup ribbonGroup = this.ribbonGroup_0.vmethod_1();
				ribbonGroup.ShowSeperator = false;
				this.ribbonDropDown_0.Items.Add(new ToolStripControlHost(ribbonGroup));
				this.ribbonDropDown_0.Size = ribbonGroup.Size;
			}
			else
			{
				Class517.smethod_2(this.ribbonDropDown_0, this.ribbonItemCollection_1);
			}
			this.ribbonDropDown_0.MaximumSize = new Size(this.ribbonDropDown_0.Width - num, this.ribbonDropDown_0.Height);
			return this.ribbonDropDown_0;
		}

		private void ribbonDropDown_0_Closed(object sender, ToolStripDropDownClosedEventArgs e)
		{
			this.m_bIsDropDownOpen = false;
			this.method_20();
		}

		private void method_19(bool bool_12)
		{
			RibbonDropDown ribbonDropDown = this.method_18();
			if (ribbonDropDown.Items.Count <= 0)
			{
				return;
			}
			ribbonDropDown.Owner = Class517.smethod_1(base.Parent);
			if (bool_12)
			{
				ribbonDropDown.Boolean_0 = true;
			}
			base.m_rttToolTip.method_2();
			if (base.m_bIsRibbonDropDownItem)
			{
				if (base.m_bIsRightToLeft)
				{
					ribbonDropDown.Show(this, new Point(0, 0), ToolStripDropDownDirection.BelowLeft);
				}
				else
				{
					ribbonDropDown.Show(this, new Point(base.Width, 0));
				}
			}
			else if (base.m_bIsRightToLeft)
			{
				ribbonDropDown.Show(this, new Point(base.Width, base.Height), ToolStripDropDownDirection.BelowLeft);
			}
			else
			{
				ribbonDropDown.Show(this, new Point(0, base.Height));
			}
		}

		protected override void CreateToolStripItem()
		{
			base.m_tsiToolStripItem = new Class564(this);
			base.m_tsiToolStripItem.Enabled = base.Enabled;
			Class517.smethod_57(base.m_tsiToolStripItem, base.m_imgSmallIcon, base.m_pntDpi);
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (!disposing)
			{
				return;
			}
			foreach (Control item in this.ribbonItemCollection_1)
			{
				item.Dispose();
			}
			if (this.ribbonDropDown_0 != null)
			{
				this.ribbonDropDown_0.Dispose();
			}
		}

		protected override void OnKeyDown(KeyEventArgs kevent)
		{
			if (base.Enabled)
			{
				if (kevent.KeyCode == Keys.Return)
				{
					this.method_19(bool_12: false);
				}
				base.OnKeyDown(kevent);
			}
		}

		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			if (base.Enabled)
			{
				if (mevent.Button == MouseButtons.Left)
				{
					this.method_19(bool_12: false);
				}
				base.OnMouseDown(mevent);
			}
		}

		void IRibbonItem.ParentVisibleChanged(bool isVisible)
		{
			foreach (Control dropDownItem in this.DropDownItems)
			{
				(dropDownItem as IRibbonItem).ParentVisibleChanged(isVisible);
			}
		}

		void IRibbonItem.PerformStandardKeyboardAction()
		{
			this.method_19(bool_12: true);
		}

		internal void method_20()
		{
			EventHandler eventHandler = (EventHandler)base.Events[RibbonMenuButton.DropDownClosedEvent];
			if (eventHandler != null)
			{
				EventArgs e = new EventArgs();
				eventHandler(this, e);
			}
		}

		internal void method_21()
		{
			EventHandler eventHandler = (EventHandler)base.Events[RibbonMenuButton.DropDownOpeningEvent];
			if (eventHandler != null)
			{
				EventArgs e = new EventArgs();
				eventHandler(this, e);
			}
			if (this.ribbonItemCollection_1.Count > 0)
			{
				this.m_bIsDropDownOpen = true;
			}
		}
	}
}
