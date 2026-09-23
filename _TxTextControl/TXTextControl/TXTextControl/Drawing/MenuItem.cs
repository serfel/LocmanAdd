using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace TXTextControl.Drawing
{
	/// <summary>The Drawing.MenuItem class represents a bindable Windows Forms ToolStripMenuItem.</summary>
	public class MenuItem : ToolStripMenuItem, IBindableComponent, IComponent, IDisposable
	{
		private BindingContext bindingContext_0;

		private ControlBindingsCollection controlBindingsCollection_0;

		[Browsable(false)]
		public BindingContext BindingContext
		{
			get
			{
				if (this.bindingContext_0 == null)
				{
					this.bindingContext_0 = new BindingContext();
				}
				return this.bindingContext_0;
			}
			set
			{
				this.bindingContext_0 = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ControlBindingsCollection DataBindings
		{
			get
			{
				if (this.controlBindingsCollection_0 == null)
				{
					this.controlBindingsCollection_0 = new ControlBindingsCollection(this);
				}
				return this.controlBindingsCollection_0;
			}
		}
	}
}
