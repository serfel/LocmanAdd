using System.Collections.Generic;
using System.ComponentModel;
using System.Resources;
using System.Windows.Forms;
using TXTextControl;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class500
	{
		protected BindingAdapter bindingAdapter_0;

		protected Control control_0;

		protected ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		protected List<IEnabledItem> list_0 = new List<IEnabledItem>();

		protected List<IEnabledItem> list_1 = new List<IEnabledItem>();

		protected List<IEnabledItem> list_2 = new List<IEnabledItem>();

		protected List<IEnabledItem> list_3 = new List<IEnabledItem>();

		protected List<IEnabledItem> list_4 = new List<IEnabledItem>();

		internal BindingAdapter BindingAdapter_0 => this.bindingAdapter_0;

		internal Control Control_0 => this.control_0;

		internal bool Boolean_0
		{
			get
			{
				if (this.control_0 is RibbonTab)
				{
					if (this.bindingAdapter_0.TextControl != null)
					{
						if (!(this.control_0 as RibbonTab).Boolean_0)
						{
							return Class517.smethod_58(this.control_0 as RibbonTab);
						}
						return true;
					}
					return false;
				}
				return this.bindingAdapter_0.TextControl != null;
			}
		}

		internal Class500(Control control_1, BindingAdapter bindingAdapter_1)
		{
			this.control_0 = control_1;
			this.bindingAdapter_0 = bindingAdapter_1;
			this.bindingAdapter_0.RibbonGroupManager = this;
		}

		internal bool method_0(RibbonGroup ribbonGroup_0)
		{
			if (this.control_0 is RibbonTab)
			{
				if (this.bindingAdapter_0.TextControl != null)
				{
					if (!(this.control_0 as RibbonTab).Boolean_0)
					{
						return ribbonGroup_0.List_0.Count > 0;
					}
					return true;
				}
				return false;
			}
			return this.bindingAdapter_0.TextControl != null;
		}

		internal bool method_1(params object[] object_0)
		{
			int num = 0;
			while (true)
			{
				if (num < object_0.Length)
				{
					object object_ = object_0[num];
					if (this.method_2(object_))
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}

		internal bool method_2(object object_0)
		{
			if (this.control_0 is RibbonTab)
			{
				IRibbonToolStripItemProvider ribbonToolStripItemProvider = object_0 as IRibbonToolStripItemProvider;
				RibbonGroup ribbonGroup = (object_0 as IRibbonItem)?.RibbonGroup;
				if (this.bindingAdapter_0.TextControl != null)
				{
					if (!(this.control_0 as RibbonTab).Boolean_0 && (ribbonToolStripItemProvider == null || !ribbonToolStripItemProvider.IsToolStripItemAdded))
					{
						return ((IRibbonToolStripItemProvider)ribbonGroup)?.IsToolStripItemAdded ?? false;
					}
					return true;
				}
				return false;
			}
			return this.bindingAdapter_0.TextControl != null;
		}

		internal bool method_3(object object_0)
		{
			if (this.control_0 is RibbonTab)
			{
				IRibbonToolStripItemProvider iribbonToolStripItemProvider_ = object_0 as IRibbonToolStripItemProvider;
				RibbonGroup ribbonGroup = (object_0 as IRibbonItem)?.RibbonGroup;
				if (this.bindingAdapter_0.TextControl != null)
				{
					if (!(this.control_0 as RibbonTab).Boolean_0 && !this.method_4(iribbonToolStripItemProvider_))
					{
						return ((IRibbonToolStripItemProvider)ribbonGroup)?.IsToolStripItemAdded ?? false;
					}
					return true;
				}
				return false;
			}
			return this.bindingAdapter_0.TextControl != null;
		}

		private bool method_4(IRibbonToolStripItemProvider iribbonToolStripItemProvider_0)
		{
			if (iribbonToolStripItemProvider_0 == null)
			{
				return false;
			}
			if (iribbonToolStripItemProvider_0.IsToolStripItemAdded)
			{
				return true;
			}
			if (iribbonToolStripItemProvider_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = iribbonToolStripItemProvider_0 as RibbonMenuButton;
				foreach (Control dropDownItem in ribbonMenuButton.DropDownItems)
				{
					if (this.method_4(dropDownItem as IRibbonToolStripItemProvider))
					{
						return true;
					}
				}
			}
			return false;
		}

		internal virtual void vmethod_0(object sender, PropertyChangedEventArgs e)
		{
			if (this.bindingAdapter_0 != null && this.bindingAdapter_0.TextControl != null)
			{
				switch (e.PropertyName)
				{
				case "CanStyleFormat":
					this.method_9();
					break;
				case "CanParagraphFormat":
					this.method_8();
					break;
				case "CanDocumentFormat":
					this.method_7();
					break;
				case "CanCharacterFormat":
					this.method_6();
					break;
				case "CanEdit":
					this.vmethod_1();
					break;
				}
			}
		}

		internal void method_5()
		{
			this.vmethod_1();
			this.method_6();
			this.method_7();
			this.method_8();
			this.method_9();
		}

		protected virtual void vmethod_1()
		{
			bool enabled = this.bindingAdapter_0.TextControl == null || this.bindingAdapter_0.TextControl.CanEdit;
			foreach (IEnabledItem item in this.list_0)
			{
				item.Enabled = enabled;
			}
		}

		internal void method_6()
		{
			bool enabled = this.bindingAdapter_0.TextControl == null || this.bindingAdapter_0.TextControl.CanCharacterFormat;
			foreach (IEnabledItem item in this.list_1)
			{
				item.Enabled = enabled;
			}
		}

		internal void method_7()
		{
			bool enabled = this.bindingAdapter_0.TextControl == null || this.bindingAdapter_0.TextControl.CanDocumentFormat;
			foreach (IEnabledItem item in this.list_2)
			{
				item.Enabled = enabled;
			}
		}

		internal void method_8()
		{
			bool enabled = this.bindingAdapter_0.TextControl == null || this.bindingAdapter_0.TextControl.CanParagraphFormat;
			foreach (IEnabledItem item in this.list_3)
			{
				item.Enabled = enabled;
			}
		}

		internal void method_9()
		{
			bool enabled = this.bindingAdapter_0.TextControl == null || this.bindingAdapter_0.TextControl.CanStyleFormat;
			foreach (IEnabledItem item in this.list_4)
			{
				item.Enabled = enabled;
			}
		}
	}
}
