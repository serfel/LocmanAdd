using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms.VisualStyles;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>The RibbonToggleButton class is a checkable button control which can be added to a RibbonGroup or to a RibbonMenuButton where it is stored as an item of the drop-down menu.</summary>
	public class RibbonToggleButton : RibbonButton
	{
		[Obfuscation(Exclude = true)]
		private static readonly object CheckedChangedEvent = new object();

		/// <summary>Gets or set a value indicating whether this RibbonToggleButton is checked.</summary>
		[Category("Appearance")]
		[DefaultValue(false)]
		public bool Checked
		{
			get
			{
				return base.m_bChecked;
			}
			set
			{
				this.method_19(value, bool_13: false);
			}
		}

		/// <summary>Occurs when the value of the Checked property changes.</summary>
		public event EventHandler CheckedChanged
		{
			add
			{
				base.Events.AddHandler(RibbonToggleButton.CheckedChangedEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(RibbonToggleButton.CheckedChangedEvent, value);
			}
		}

		/// <summary>Initializes a new instance of the RibbonToggleButton class.</summary>
		public RibbonToggleButton()
		{
		}

		internal void method_18()
		{
			if (base.iribbonItem_0 != null)
			{
				((RibbonToggleButton)base.iribbonItem_0).Checked = this.Checked;
			}
		}

		protected override void OnClick(EventArgs eventArgs_0)
		{
			if (base.Enabled)
			{
				Class517.smethod_28(this);
				if (base.iribbonItem_0 != null)
				{
					(base.iribbonItem_0 as RibbonToggleButton).OnClick(new EventArgs());
				}
				else if (base.m_rgRibbonGroup == null || !base.m_rgRibbonGroup.Boolean_2)
				{
					this.method_19(!base.m_bChecked, bool_13: true);
					base.OnClick(eventArgs_0);
				}
			}
		}

		internal void method_19(bool bool_12, bool bool_13)
		{
			if (base.m_bChecked == (base.m_bChecked = bool_12))
			{
				return;
			}
			if (base.iribbonItem_0 != null)
			{
				((RibbonToggleButton)base.iribbonItem_0).method_19(bool_12, bool_13);
			}
			else
			{
				if (bool_13)
				{
					EventHandler eventHandler = (EventHandler)base.Events[RibbonToggleButton.CheckedChangedEvent];
					if (eventHandler != null)
					{
						EventArgs e = new EventArgs();
						eventHandler(this, e);
					}
				}
				this.vmethod_0("Checked");
			}
			try
			{
				base.m_vsrToggleRenderer = new VisualStyleRenderer(base.GetCurrentToggleStyle());
			}
			catch
			{
			}
			base.Invalidate();
			if (base.m_tsiToolStripItem != null)
			{
				((Class563)base.m_tsiToolStripItem).method_0();
			}
		}

		protected override void PaintBackground(Graphics graphics_0)
		{
			if (base.m_vsrBackgroundRenderer == null)
			{
				return;
			}
			if (base.m_bsButtonStructure.IconTextRelation_0 == IconTextRelation.SmallIconLabeled)
			{
				base.m_vsrBackgroundRenderer.DrawBackground(graphics_0, base.m_bsButtonStructure.Rectangle_0);
				if (base.m_bChecked)
				{
					base.m_vsrToggleRenderer.DrawBackground(graphics_0, base.m_bsButtonStructure.Rectangle_1);
				}
			}
			else
			{
				base.m_vsrToggleRenderer.DrawBackground(graphics_0, base.m_bsButtonStructure.Rectangle_1);
			}
		}
	}
}
