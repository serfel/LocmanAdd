using System;
using System.Collections;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>An instance of the RibbonItemCollection class contains controls of type RibbonButton, RibbonComboBox, RibbonLabel, RibbonListView, RibbonTextBox or RibbonSeperator and can be obtained with the RibbonGroup.RibbonItems, Ribbon.ApplicationMenuHelpPaneItems, Ribbon.ApplicationMenuItems, RibbonMenuButton.DropDownItems or RibbonListView.DropDownItems property.</summary>
	public class RibbonItemCollection : CollectionBase, IEnumerable, IEnumerator
	{
		private int int_0 = -1;

		private object object_0;

		private bool bool_0 = true;

		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		public Control this[int number] => (Control)base.List[number];

		internal bool Boolean_0
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}

		internal object Object_0
		{
			get
			{
				return this.object_0;
			}
			set
			{
				this.object_0 = value;
			}
		}

		public object Current
		{
			get
			{
				try
				{
					return base.List[this.int_0];
				}
				catch (IndexOutOfRangeException)
				{
					throw new InvalidOperationException();
				}
			}
		}

		internal RibbonItemCollection()
		{
		}

		internal RibbonItemCollection(object parent)
		{
			this.object_0 = parent;
		}

		/// <summary>Adds a control of the type RibbonButton, RibbonComboBox, RibbonLabel, RibbonListView, RibbonTextBox or RibbonSeperator to the end of the collection.</summary>
		/// <param name="item">The control to be added to the end of this collection.</param>
		public int Add(Control item)
		{
			int result = -1;
			if (item != null)
			{
				if (!(item is IRibbonItem))
				{
					throw new ArgumentException(this.resourceManager_0.GetString("ERR_ADD_NOTRIBBONITEM"));
				}
				if (base.InnerList.Contains(item))
				{
					throw new ArgumentException(this.resourceManager_0.GetString("ERR_ADD_ALREADYEXIST"));
				}
				result = this.method_0(item, this.object_0 as HorizontalRibbonGroup);
				RibbonGroup ribbonGroup = this.object_0 as RibbonGroup;
				if (ribbonGroup is Class497)
				{
					ribbonGroup.method_3(bool_7: true);
				}
				else if (ribbonGroup != null)
				{
					ribbonGroup.method_2();
				}
				else if (this.object_0 is RibbonListView)
				{
					(this.object_0 as RibbonListView).method_11(bool_20: false);
				}
			}
			return result;
		}

		/// <summary>Adds an array of controls to the end of the collection. These controls must be objects of type RibbonButton, RibbonComboBox, RibbonLabel, RibbonListView, RibbonTextBox or RibbonSeperator.</summary>
		/// <param name="items">An array of controls to be added to the end of this collection.</param>
		public void AddRange(Control[] items)
		{
			HorizontalRibbonGroup horizontalRibbonGroup_ = this.object_0 as HorizontalRibbonGroup;
			int num = 0;
			while (true)
			{
				if (num < items.Length)
				{
					Control control = items[num];
					if (control is IRibbonItem)
					{
						if (!base.InnerList.Contains(control))
						{
							this.method_0(control, horizontalRibbonGroup_);
							num++;
							continue;
						}
						throw new ArgumentException(this.resourceManager_0.GetString("ERR_ADDRANGE_ALREADYEXIST"));
					}
					throw new ArgumentException(this.resourceManager_0.GetString("ERR_ADDRANGE_NOTRIBBONITEM"));
				}
				RibbonGroup ribbonGroup = this.object_0 as RibbonGroup;
				if (ribbonGroup != null)
				{
					ribbonGroup.method_2();
				}
				else if (this.object_0 is RibbonListView)
				{
					(this.object_0 as RibbonListView).method_11(bool_20: false);
				}
				break;
			}
		}

		/// <summary>Determines whether a control is in the collection.</summary>
		/// <param name="item">The item to locate in this collection.</param>
		public bool Contains(Control ribbonItem)
		{
			return base.InnerList.Contains(ribbonItem);
		}

		/// <summary>Inserts a control of the type RibbonButton, RibbonComboBox, RibbonLabel, RibbonListView, RibbonTextBox or RibbonSeperator at the specified index.</summary>
		/// <param name="index">The zero-based index at which the control should be inserted.</param>
		/// <param name="item">The control to be inserted.</param>
		public void Insert(int index, Control item)
		{
			if (item != null)
			{
				if (!(item is IRibbonItem))
				{
					throw new ArgumentException(this.resourceManager_0.GetString("ERR_ADD_NOTRIBBONITEM"));
				}
				if (base.InnerList.Contains(item))
				{
					throw new ArgumentException(this.resourceManager_0.GetString("ERR_ADD_ALREADYEXIST"));
				}
				this.method_2(index, item, this.object_0 as HorizontalRibbonGroup);
				RibbonGroup ribbonGroup = this.object_0 as RibbonGroup;
				if (ribbonGroup != null)
				{
					ribbonGroup.method_2();
				}
				else if (this.object_0 is RibbonListView)
				{
					(this.object_0 as RibbonListView).method_11(bool_20: false);
				}
			}
		}

		/// <summary>Inserts an array of controls at the specified index. These controls must be objects of type RibbonButton, RibbonComboBox, RibbonLabel, RibbonListView, RibbonTextBox or RibbonSeperator.</summary>
		/// <param name="index">The zero-based index at which the controls should be inserted.</param>
		/// <param name="items">An array of controlsto be inserted.</param>
		public void InsertRange(int index, Control[] items)
		{
			HorizontalRibbonGroup horizontalRibbonGroup_ = this.object_0 as HorizontalRibbonGroup;
			int num = index;
			int num2 = 0;
			while (true)
			{
				if (num2 < items.Length)
				{
					Control control = items[num2];
					if (control is IRibbonItem)
					{
						if (!base.InnerList.Contains(control))
						{
							this.method_2(num, control, horizontalRibbonGroup_);
							num++;
							num2++;
							continue;
						}
						throw new ArgumentException(this.resourceManager_0.GetString("ERR_ADDRANGE_ALREADYEXIST"));
					}
					throw new ArgumentException(this.resourceManager_0.GetString("ERR_ADDRANGE_NOTRIBBONITEM"));
				}
				RibbonGroup ribbonGroup = this.object_0 as RibbonGroup;
				if (ribbonGroup != null)
				{
					ribbonGroup.method_2();
				}
				else if (this.object_0 is RibbonListView)
				{
					(this.object_0 as RibbonListView).method_11(bool_20: false);
				}
				break;
			}
		}

		/// <summary>Removes a control of the type RibbonButton, RibbonComboBox, RibbonLabel, RibbonListView, RibbonTextBox or RibbonSeperator from this collection.</summary>
		/// <param name="item">The control to be removed from this collection.</param>
		public void Remove(Control item)
		{
			if (base.InnerList.Contains(item))
			{
				base.InnerList.Remove(item);
				(item as IRibbonItem).SetParentCollection(null);
				(item as IRibbonItem).OwnerEnabled = true;
				RibbonGroup ribbonGroup = this.object_0 as RibbonGroup;
				if (ribbonGroup != null)
				{
					this.method_3(ribbonGroup as HorizontalRibbonGroup, item as IRibbonItem);
					ribbonGroup.method_2();
				}
				else if (this.object_0 is RibbonListView)
				{
					(this.object_0 as RibbonListView).method_11(bool_20: false);
				}
			}
		}

		internal int method_0(Control control_0, HorizontalRibbonGroup horizontalRibbonGroup_0)
		{
			(control_0 as IRibbonItem).SetParentCollection(this);
			this.method_1(control_0);
			int result = base.InnerList.Add(control_0);
			if (horizontalRibbonGroup_0 != null)
			{
				horizontalRibbonGroup_0.List_1[0].Add((IRibbonItem)control_0);
			}
			this.method_4(control_0);
			return result;
		}

		private void method_1(Control control_0)
		{
			RibbonSeperator ribbonSeperator = control_0 as RibbonSeperator;
			PropertyInfo property = this.object_0.GetType().GetProperty("Enabled");
			if (property != null)
			{
				(control_0 as IRibbonItem).OwnerEnabled = (bool)property.GetValue(this.object_0, null);
			}
			if (!(this.object_0 is Class497) && !(this.object_0 is RibbonMenuButton) && !(this.object_0 is RibbonListView))
			{
				(control_0 as IRibbonItem).IsRibbonDropDownItem = false;
				control_0.Dock = DockStyle.None;
				if (ribbonSeperator != null)
				{
					if (!(this.object_0 is HorizontalRibbonGroup))
					{
						throw new ArgumentException(this.resourceManager_0.GetString("ERR_ADD_RIBBONSEPERATOR"));
					}
					ribbonSeperator.Alignment = RibbonSeperator.SeperatorAlignment.Vertical;
				}
			}
			else
			{
				(control_0 as IRibbonItem).IsRibbonDropDownItem = true;
				control_0.Dock = DockStyle.Top;
				if (ribbonSeperator != null)
				{
					ribbonSeperator.Alignment = RibbonSeperator.SeperatorAlignment.Horizontal;
				}
			}
		}

		private void method_2(int int_1, Control control_0, HorizontalRibbonGroup horizontalRibbonGroup_0)
		{
			(control_0 as IRibbonItem).SetParentCollection(this);
			this.method_1(control_0);
			base.InnerList.Insert(int_1, control_0);
			if (horizontalRibbonGroup_0 != null)
			{
				horizontalRibbonGroup_0.List_1[0].Insert(int_1, (IRibbonItem)control_0);
			}
			this.method_4(control_0);
		}

		private void method_3(HorizontalRibbonGroup horizontalRibbonGroup_0, IRibbonItem iribbonItem_0)
		{
			if (horizontalRibbonGroup_0 == null || iribbonItem_0 == null)
			{
				return;
			}
			int num = 0;
			while (true)
			{
				if (num < horizontalRibbonGroup_0.List_1.Length)
				{
					if (horizontalRibbonGroup_0.List_1[num].Contains(iribbonItem_0))
					{
						break;
					}
					num++;
					continue;
				}
				return;
			}
			horizontalRibbonGroup_0.List_1[num].Remove(iribbonItem_0);
		}

		private void method_4(Control control_0)
		{
			if (control_0 is IRibbonItem)
			{
				((IRibbonItem)control_0).RibbonGroup = ((this.object_0 is RibbonGroup) ? ((RibbonGroup)this.object_0) : ((IRibbonItem)this.object_0).RibbonGroup);
				RibbonGroup ribbonGroup = ((IRibbonItem)control_0).RibbonGroup;
				if (ribbonGroup != null && ribbonGroup.Class498_0 != null)
				{
					Class517.smethod_6((IRibbonItem)control_0, ribbonGroup);
				}
			}
		}

		internal void method_5(RibbonGroup ribbonGroup_0)
		{
			if (ribbonGroup_0 == null || ribbonGroup_0.Class498_0 == null)
			{
				return;
			}
			foreach (IRibbonItem inner in base.InnerList)
			{
				Class517.smethod_6(inner, ribbonGroup_0);
			}
		}

		protected override void OnClear()
		{
			base.OnClear();
			base.InnerList.Clear();
			RibbonGroup ribbonGroup = this.object_0 as RibbonGroup;
			if (ribbonGroup != null)
			{
				ribbonGroup.method_2();
			}
			else if (this.object_0 is RibbonListView)
			{
				(this.object_0 as RibbonListView).method_11(bool_20: false);
			}
		}

		public new void RemoveAt(int index)
		{
			if (0 <= index && index < base.InnerList.Count)
			{
				object obj = base.InnerList[index];
				base.InnerList.RemoveAt(index);
				(obj as IRibbonItem).SetParentCollection(null);
				(obj as IRibbonItem).OwnerEnabled = true;
				RibbonGroup ribbonGroup = this.object_0 as RibbonGroup;
				if (ribbonGroup != null)
				{
					this.method_3(ribbonGroup as HorizontalRibbonGroup, obj as IRibbonItem);
					ribbonGroup.method_2();
				}
				else if (this.object_0 is RibbonListView)
				{
					(this.object_0 as RibbonListView).method_11(bool_20: false);
				}
			}
		}

		public bool MoveNext()
		{
			this.int_0++;
			return this.int_0 < base.List.Count;
		}

		public void Reset()
		{
			this.int_0 = -1;
		}
	}
}
