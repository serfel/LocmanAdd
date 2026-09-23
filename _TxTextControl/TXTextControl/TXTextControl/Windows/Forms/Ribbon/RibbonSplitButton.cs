using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>The RibbonSplitButton class is a control that has a primary button that responds to a Click event and a secondary button that displays a drop-down menu when clicked.</summary>
	public class RibbonSplitButton : RibbonMenuButton
	{
		private bool bool_12;

		private bool bool_13;

		private bool bool_14 = true;

		private bool bool_15 = true;

		private VisualStyleRenderer visualStyleRenderer_0;

		private VisualStyleRenderer visualStyleRenderer_1;

		[Obfuscation(Exclude = true)]
		private static readonly object ButtonClickEvent = new object();

		[Obfuscation(Exclude = true)]
		private static readonly object CheckedChangedEvent = new object();

		/// <summary>Gets or set a value indicating whether the primary button is enabled.</summary>
		[Category("Behavior")]
		[DefaultValue(true)]
		public bool ButtonEnabled
		{
			get
			{
				return base.m_bButtonEnabled;
			}
			set
			{
				if (base.m_bButtonEnabled != (base.m_bButtonEnabled = value))
				{
					base.UpdateEnableRendering();
					this.vmethod_0("ButtonEnabled");
					base.Invalidate();
				}
			}
		}

		/// <summary>Gets or set a value indicating whether the primary button is checkable.</summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		public bool Checkable
		{
			get
			{
				return this.bool_12;
			}
			set
			{
				this.method_23(base.m_bChecked, this.bool_12 != (this.bool_12 = value) && base.m_bChecked, bool_18: false);
			}
		}

		/// <summary>Gets or set a value indicating whether the primary button is checked.</summary>
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
				this.method_23(value, bool_17: false, bool_18: false);
			}
		}

		/// <summary>Occurs as the primary button is clicked.</summary>
		public event EventHandler ButtonClick
		{
			add
			{
				base.Events.AddHandler(RibbonSplitButton.ButtonClickEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(RibbonSplitButton.ButtonClickEvent, value);
			}
		}

		/// <summary>Occurs when the value of the Checked property changes.</summary>
		public event EventHandler CheckedChanged
		{
			add
			{
				base.Events.AddHandler(RibbonSplitButton.CheckedChangedEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(RibbonSplitButton.CheckedChangedEvent, value);
			}
		}

		/// <summary>Initializes a new instance of the RibbonSplitButton class.</summary>
		public RibbonSplitButton()
		{
			try
			{
				this.visualStyleRenderer_0 = new VisualStyleRenderer(VisualStyleElement.Button.GroupBox.Normal);
				this.visualStyleRenderer_1 = new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal);
			}
			catch
			{
			}
		}

		protected override void CreateToolStripItem()
		{
			base.m_tsiToolStripItem = new Class565(this);
			base.m_tsiToolStripItem.Enabled = base.Enabled;
			Class517.smethod_57(base.m_tsiToolStripItem, base.m_imgSmallIcon, base.m_pntDpi);
		}

		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			if (!base.Enabled)
			{
				return;
			}
			this.bool_13 = false;
			if (mevent.Button == MouseButtons.Left)
			{
				base.m_bIsInside = true;
				if (base.m_bsButtonStructure.Rectangle_2.Contains(mevent.Location))
				{
					base.OnMouseDown(mevent);
				}
				else
				{
					this.bool_13 = base.m_bButtonEnabled;
				}
			}
			else
			{
				base.OnMouseDown(mevent);
			}
		}

		protected override void OnMouseMove(MouseEventArgs mevent)
		{
			if (base.Enabled)
			{
				if (!base.m_bIsDropDownOpen && ((this.bool_14 != (this.bool_14 = base.m_bsButtonStructure.Rectangle_0.Contains(mevent.Location))) | (this.bool_15 != (this.bool_15 = base.m_bsButtonStructure.Rectangle_2.Contains(mevent.Location)))))
				{
					base.Invalidate();
				}
				base.OnMouseMove(mevent);
			}
		}

		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			if (base.Enabled)
			{
				if (this.bool_13)
				{
					this.method_22();
				}
				base.OnMouseUp(mevent);
			}
		}

		protected override void PaintBackground(Graphics graphics_0)
		{
			if (this.visualStyleRenderer_0 == null)
			{
				return;
			}
			if (base.m_bIsInside)
			{
				this.visualStyleRenderer_0.DrawBackground(graphics_0, new Rectangle(0, 0, base.Width, base.Height));
			}
			if (base.Enabled && this.bool_12 && base.m_bChecked && base.m_bButtonEnabled)
			{
				if (base.m_bsButtonStructure.IconTextRelation_0 == IconTextRelation.SmallIconLabeled)
				{
					base.m_vsrBackgroundRenderer.DrawBackground(graphics_0, base.m_bsButtonStructure.Rectangle_0);
				}
				base.m_vsrToggleRenderer.DrawBackground(graphics_0, base.m_bsButtonStructure.Rectangle_1);
			}
			else if (this.bool_14 && base.m_bButtonEnabled)
			{
				base.m_vsrBackgroundRenderer.DrawBackground(graphics_0, base.m_bsButtonStructure.Rectangle_0);
			}
			if (this.bool_15)
			{
				base.m_vsrBackgroundRenderer.DrawBackground(graphics_0, base.m_bsButtonStructure.Rectangle_2);
			}
		}

		protected override void UpdateBackgroundBounds(ButtonStructure buttonStructure)
		{
			IconTextRelation iconTextRelation = base.m_bsButtonStructure.IconTextRelation_0;
			int num;
			if (iconTextRelation == IconTextRelation.LargeIconLabeled)
			{
				if (base.m_bIsRibbonDropDownItem)
				{
					if (base.m_bIsRightToLeft)
					{
						num = base.m_szArrowBoundsHorizontalLargeIcon.Width + base.m_padArrowMarginsHorizontalLargeIcon.Horizontal + Class517.smethod_45(4, base.m_pntDpi.X);
						base.m_bsButtonStructure.Rectangle_0 = new Rectangle(num - Class517.smethod_45(1, base.m_pntDpi.X), 0, base.m_bsButtonStructure.Size_0.Width - num + Class517.smethod_45(1, base.m_pntDpi.X), base.m_bsButtonStructure.Size_0.Height);
						base.m_bsButtonStructure.Rectangle_2 = new Rectangle(0, 0, num, base.m_bsButtonStructure.Size_0.Height);
						base.m_bsButtonStructure.Nullable_5 = new Rectangle(base.m_padArrowMarginsHorizontalLargeIcon.Left, base.m_bsButtonStructure.Size_0.Height / 2 - base.m_szArrowBoundsHorizontalLargeIcon.Height / 2, base.m_szArrowBoundsHorizontalLargeIcon.Width, base.m_szArrowBoundsHorizontalLargeIcon.Height);
					}
					else
					{
						num = base.m_bsButtonStructure.Size_0.Width - base.m_padArrowMarginsHorizontalLargeIcon.Horizontal - base.m_szArrowBoundsHorizontalLargeIcon.Width;
						base.m_bsButtonStructure.Rectangle_0 = new Rectangle(0, 0, num, base.m_bsButtonStructure.Size_0.Height);
						base.m_bsButtonStructure.Rectangle_2 = new Rectangle(num, 0, base.m_bsButtonStructure.Size_0.Width - num, base.m_bsButtonStructure.Size_0.Height);
						base.m_bsButtonStructure.Nullable_5 = new Rectangle(num + base.m_padArrowMarginsHorizontalLargeIcon.Left, base.m_bsButtonStructure.Size_0.Height / 2 - base.m_szArrowBoundsHorizontalLargeIcon.Height / 2, base.m_szArrowBoundsHorizontalLargeIcon.Width, base.m_szArrowBoundsHorizontalLargeIcon.Height);
					}
				}
				else
				{
					int num2 = base.m_padImageMarginsLargeIcon.Vertical + base.m_szLargeImageSize.Height;
					base.m_bsButtonStructure.Rectangle_0 = new Rectangle(0, 0, base.m_bsButtonStructure.Size_0.Width, num2 + Class517.smethod_45(1, base.m_pntDpi.Y));
					base.m_bsButtonStructure.Rectangle_2 = new Rectangle(0, num2 - Class517.smethod_45(1, base.m_pntDpi.Y), base.m_bsButtonStructure.Size_0.Width, base.m_bsButtonStructure.Size_0.Height - num2);
				}
				base.m_bsButtonStructure.Rectangle_1 = base.m_bsButtonStructure.Rectangle_0;
				return;
			}
			if (base.m_bIsRightToLeft)
			{
				num = (base.m_bIsRibbonDropDownItem ? (base.m_szArrowBoundsHorizontalSmallIcon.Width + base.m_padArrowMarginsSmallIcon.Horizontal + Class517.smethod_45(4, base.m_pntDpi.X)) : (base.m_szArrowBoundsVertical.Width + base.m_padArrowMarginsSmallIcon.Horizontal + Class517.smethod_45(3, base.m_pntDpi.X)));
				base.m_bsButtonStructure.Rectangle_0 = new Rectangle(num - Class517.smethod_45(1, base.m_pntDpi.X), 0, base.m_bsButtonStructure.Size_0.Width - num + Class517.smethod_45(1, base.m_pntDpi.X), base.m_bsButtonStructure.Size_0.Height);
				base.m_bsButtonStructure.Rectangle_2 = new Rectangle(0, 0, num, base.m_bsButtonStructure.Size_0.Height);
			}
			else
			{
				num = (base.m_bIsRibbonDropDownItem ? (buttonStructure.Size_0.Width - base.m_szArrowBoundsHorizontalSmallIcon.Width - base.m_padArrowMarginsSmallIcon.Horizontal - Class517.smethod_45(4, base.m_pntDpi.X)) : (buttonStructure.Size_0.Width - base.m_szArrowBoundsVertical.Width - base.m_padArrowMarginsSmallIcon.Horizontal - Class517.smethod_45(4, base.m_pntDpi.X)));
				base.m_bsButtonStructure.Rectangle_0 = new Rectangle(0, 0, num + Class517.smethod_45(1, base.m_pntDpi.X), base.m_bsButtonStructure.Size_0.Height);
				base.m_bsButtonStructure.Rectangle_2 = new Rectangle(num, 0, base.m_bsButtonStructure.Size_0.Width - num, base.m_bsButtonStructure.Size_0.Height);
			}
			if (base.m_bsButtonStructure.IconTextRelation_0 == IconTextRelation.SmallIconLabeled)
			{
				int num3 = Math.Max(base.m_padImageMarginsScmallIcon.Vertical + base.m_szSmallImageSize.Height, base.m_bsButtonStructure.Size_0.Height);
				int num4 = base.m_szSmallImageSize.Width + base.m_padImageMarginsScmallIcon.Horizontal;
				base.m_bsButtonStructure.Rectangle_1 = (base.m_bIsRightToLeft ? new Rectangle(buttonStructure.Size_0.Width - num4, 0, num4, num3) : new Rectangle(0, 0, num4, num3));
			}
			else
			{
				base.m_bsButtonStructure.Rectangle_1 = base.m_bsButtonStructure.Rectangle_0;
			}
			if (base.m_bIsRibbonDropDownItem)
			{
				base.m_bsButtonStructure.Nullable_6 = (base.m_bIsRightToLeft ? new Rectangle(base.m_padArrowMarginsSmallIcon.Left, base.m_bsButtonStructure.Size_0.Height / 2 - base.m_szArrowBoundsHorizontalSmallIcon.Height / 2 - Class517.smethod_45(1, base.m_pntDpi.Y), base.m_szArrowBoundsHorizontalSmallIcon.Width, base.m_szArrowBoundsHorizontalSmallIcon.Height) : new Rectangle(num + base.m_padArrowMarginsSmallIcon.Left + Class517.smethod_45(3, base.m_pntDpi.X), base.m_bsButtonStructure.Size_0.Height / 2 - base.m_szArrowBoundsHorizontalSmallIcon.Height / 2 - Class517.smethod_45(1, base.m_pntDpi.Y), base.m_szArrowBoundsHorizontalSmallIcon.Width, base.m_szArrowBoundsHorizontalSmallIcon.Height));
			}
			else
			{
				base.m_bsButtonStructure.Nullable_4 = (base.m_bIsRightToLeft ? new Rectangle(base.m_padArrowMarginsSmallIcon.Left + Class517.smethod_45(2, base.m_pntDpi.X), base.m_bsButtonStructure.Size_0.Height / 2 - base.m_szArrowBoundsVertical.Height / 2, base.m_szArrowBoundsVertical.Width, base.m_szArrowBoundsVertical.Height) : new Rectangle(num + base.m_padArrowMarginsSmallIcon.Left + Class517.smethod_45(2, base.m_pntDpi.X), base.m_bsButtonStructure.Size_0.Height / 2 - base.m_szArrowBoundsVertical.Height / 2, base.m_szArrowBoundsVertical.Width, base.m_szArrowBoundsVertical.Height));
			}
		}

		internal void method_22()
		{
			Class517.smethod_28(this);
			if (base.iribbonItem_0 != null)
			{
				(base.iribbonItem_0 as RibbonSplitButton).method_22();
			}
			else if (base.m_rgRibbonGroup == null || !base.m_rgRibbonGroup.Boolean_2)
			{
				this.method_23(!base.m_bChecked, bool_17: false, bool_18: true);
				EventHandler eventHandler = (EventHandler)base.Events[RibbonSplitButton.ButtonClickEvent];
				if (eventHandler != null)
				{
					EventArgs e = new EventArgs();
					eventHandler(this, e);
				}
			}
		}

		internal bool method_23(bool bool_16, bool bool_17, bool bool_18)
		{
			bool flag;
			if (((flag = base.m_bChecked != (base.m_bChecked = bool_16)) && this.bool_12) || bool_17)
			{
				if (base.iribbonItem_0 != null)
				{
					((RibbonSplitButton)base.iribbonItem_0).method_23(bool_16, bool_17, bool_18);
				}
				else if (flag)
				{
					if (bool_18)
					{
						EventHandler eventHandler = (EventHandler)base.Events[RibbonSplitButton.CheckedChangedEvent];
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
					((Class565)base.m_tsiToolStripItem).Invalidate();
				}
				return true;
			}
			return false;
		}
	}
}
