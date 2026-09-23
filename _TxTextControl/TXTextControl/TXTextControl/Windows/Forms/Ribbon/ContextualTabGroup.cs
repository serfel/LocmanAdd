using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>An object of the ContextualTabGroup class represents a group of ribbon tabs which are only shown in a certain context.</summary>
	[ToolboxItem(false)]
	public class ContextualTabGroup : Component
	{
		internal Ribbon ribbon_0;

		private ContextualTabCollection contextualTabCollection_0;

		private string string_0 = string.Empty;

		private string string_1 = string.Empty;

		private Color color_0 = Color.LightGray;

		private bool bool_0;

		/// <summary>Gets a list of all RibbonTab objects contained in this group.</summary>
		[Category("Layout")]
		[Editor("TXTextControl.Windows.Forms.Ribbon.RibbonTabCollectionEditor, TXTextControl.Design.dll, Version=29.0.113.500, Culture=neutral, PublicKeyToken=17fff8a774004c66", typeof(UITypeEditor))]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ContextualTabCollection ContextualTabs => this.contextualTabCollection_0;

		/// <summary>Gets or sets the group's header.</summary>
		[Category("Appearance")]
		[DefaultValue("")]
		public string Header
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
				if (this.Visible)
				{
					this.method_0();
				}
			}
		}

		/// <summary>Gets or sets the group's name.</summary>
		[Browsable(false)]
		public string Name
		{
			get
			{
				string text = this.string_1;
				if (string.IsNullOrEmpty(text))
				{
					if (this.Site != null)
					{
						text = this.Site.Name;
					}
					if (text == null)
					{
						text = "";
					}
				}
				return text;
			}
			set
			{
				this.string_1 = value;
			}
		}

		/// <summary>Gets or sets the background color of the group's label.</summary>
		[Category("Appearance")]
		public Color BackColor
		{
			get
			{
				return this.color_0;
			}
			set
			{
				this.color_0 = value;
				if (this.Visible)
				{
					this.method_0();
				}
			}
		}

		/// <summary>Gets or sets the group's visibility.</summary>
		[Category("Appearance")]
		[DefaultValue(false)]
		public bool Visible
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				if (value == this.bool_0)
				{
					return;
				}
				this.bool_0 = value;
				if (this.ribbon_0 == null)
				{
					return;
				}
				if (this.bool_0)
				{
					int selectedIndex = this.ribbon_0.SelectedIndex;
					foreach (RibbonTab item in this.contextualTabCollection_0)
					{
						if (item.Int32_0 > 0 && item.Int32_0 < this.ribbon_0.TabPages.Count)
						{
							this.ribbon_0.TabPages.Insert(item.Int32_0, item);
						}
						else
						{
							this.ribbon_0.TabPages.Add(item);
						}
					}
					if (selectedIndex != this.ribbon_0.SelectedIndex)
					{
						this.ribbon_0.SelectedIndex = selectedIndex;
					}
				}
				else
				{
					foreach (RibbonTab item2 in this.contextualTabCollection_0)
					{
						item2.Int32_0 = this.ribbon_0.TabPages.IndexOf(item2);
						if (item2.Int32_0 == this.ribbon_0.SelectedIndex)
						{
							this.ribbon_0.SelectedIndex = -1;
						}
					}
					foreach (RibbonTab item3 in this.contextualTabCollection_0)
					{
						this.ribbon_0.TabPages.Remove(item3);
					}
					if (this.ribbon_0.SelectedIndex == -1 && !this.ribbon_0.Minimized)
					{
						this.ribbon_0.method_7();
					}
				}
				this.method_0();
			}
		}

		/// <summary>Initializes a new instance of the ContextualTabGroup class.</summary>
		public ContextualTabGroup()
		{
			this.contextualTabCollection_0 = new ContextualTabCollection(this);
		}

		internal void method_0()
		{
			if (this.ribbon_0 != null)
			{
				RibbonForm ribbonForm = this.ribbon_0.Parent as RibbonForm;
				if (ribbonForm != null)
				{
					ribbonForm.method_13(bool_5: true);
					ribbonForm.method_14();
				}
			}
		}
	}
}
