using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>The HorizontalRibbonGroup class represents a logical group of controls as they appear on a RibbonTab.</summary>
	[ToolboxItem(false)]
	public class HorizontalRibbonGroup : RibbonGroup
	{
		private List<IRibbonItem>[] list_1 = new List<IRibbonItem>[3]
		{
			new List<IRibbonItem>(),
			new List<IRibbonItem>(),
			new List<IRibbonItem>()
		};

		internal List<IRibbonItem>[] List_1 => this.list_1;

		/// <summary>Initializes a new instance of the HorizontalRibbonGroup class.</summary>
		public HorizontalRibbonGroup()
		{
		}

		internal HorizontalRibbonGroup(HorizontalRibbonGroup parent)
			: base(parent)
		{
		}

		/// <summary>Adds a control of type RibbonButton, RibbonComboBox, RibbonLabel, RibbonListView, RibbonTextBox or RibbonSeperator to the end of a specific row inside the horizontal ribbon group.</summary>
		/// <param name="item">The control to be added to this group.</param>
		/// <param name="row">The row where to add the control.</param>
		public int Add(Control item, int row)
		{
			if (!(item is IRibbonItem))
			{
				throw new ArgumentException(base.m_rm.GetString("ERR_ADD_NOTRIBBONITEM"));
			}
			if (row >= 0 && row <= base.int_2)
			{
				int num = 0;
				while (true)
				{
					if (num < base.int_2)
					{
						if (!this.list_1[num].Contains((IRibbonItem)item))
						{
							num++;
							continue;
						}
						throw new ArgumentException(base.m_rm.GetString("ERR_ADD_ALREADYEXIST"));
					}
					if (!(item is RibbonButton) || ((RibbonButton)item).DisplayMode != IconTextRelation.LargeIconLabeled)
					{
						break;
					}
					throw new ArgumentException(base.m_rm.GetString("ERR_ADD_LARGEICONLABELED"));
				}
				this.list_1[row].Add((IRibbonItem)item);
				int result = base.ribbonItemCollection_0.method_0(item, null);
				base.method_2();
				return result;
			}
			throw new ArgumentException(base.m_rm.GetString("ERR_ADD_PARAMETERROW"));
		}

		/// <summary>Adds an array of controls to the end of a specific row. These controls must be objects of type RibbonButton, RibbonComboBox, RibbonLabel, RibbonListView, RibbonTextBox or RibbonSeperator.</summary>
		/// <param name="items">An array of controls to be added to this group.</param>
		/// <param name="row">The row where to add the controls.</param>
		public void AddRange(Control[] items, int row)
		{
			if (row >= 0 && row <= base.int_2)
			{
				foreach (Control control in items)
				{
					if (control is IRibbonItem)
					{
						for (int j = 0; j < base.int_2; j++)
						{
							if (this.list_1[j].Contains((IRibbonItem)control))
							{
								throw new ArgumentException(base.m_rm.GetString("ERR_ADDRANGE_ALREADYEXIST"));
							}
						}
						if (!(control is RibbonButton) || ((RibbonButton)control).DisplayMode != IconTextRelation.LargeIconLabeled)
						{
							this.list_1[row].Add((IRibbonItem)control);
							base.ribbonItemCollection_0.method_0(control, null);
							continue;
						}
						throw new ArgumentException(base.m_rm.GetString("ERR_ADD_LARGEICONLABELED"));
					}
					throw new ArgumentException(base.m_rm.GetString("ERR_ADDRANGE_NOTRIBBONITEM"));
				}
				base.method_2();
				return;
			}
			throw new ArgumentException(base.m_rm.GetString("ERR_ADD_PARAMETERROW"));
		}

		/// <summary>Inserts a control of type RibbonButton, RibbonComboBox, RibbonLabel, RibbonListView, RibbonTextBox or RibbonSeperator at the specified index.</summary>
		/// <param name="index">The zero-based index at which the control should be inserted.</param>
		/// <param name="item">The control to be inserted to this group.</param>
		/// <param name="row">The row where to insert the control.</param>
		public void Insert(int index, Control item, int row)
		{
			if (!(item is IRibbonItem))
			{
				throw new ArgumentException(base.m_rm.GetString("ERR_ADD_NOTRIBBONITEM"));
			}
			if (row >= 0 && row <= base.int_2)
			{
				int num = 0;
				while (true)
				{
					if (num < base.int_2)
					{
						if (!this.list_1[num].Contains((IRibbonItem)item))
						{
							num++;
							continue;
						}
						throw new ArgumentException(base.m_rm.GetString("ERR_ADD_ALREADYEXIST"));
					}
					if (!(item is RibbonButton) || ((RibbonButton)item).DisplayMode != IconTextRelation.LargeIconLabeled)
					{
						break;
					}
					throw new ArgumentException(base.m_rm.GetString("ERR_ADD_LARGEICONLABELED"));
				}
				this.list_1[row].Insert(index, (IRibbonItem)item);
				base.ribbonItemCollection_0.method_0(item, null);
				base.method_2();
				return;
			}
			throw new ArgumentException(base.m_rm.GetString("ERR_ADD_PARAMETERROW"));
		}

		/// <summary>Inserts an array of controls at the specified index. These controls must be objects of type RibbonButton, RibbonComboBox, RibbonLabel, RibbonListView, RibbonTextBox or RibbonSeperator.</summary>
		/// <param name="index">The zero-based index at which the controls should be inserted.</param>
		/// <param name="items">An array of controls to be inserted to this group.</param>
		/// <param name="row">The row where to insert the controls.</param>
		public void InsertRange(int index, Control[] items, int row)
		{
			if (row >= 0 && row <= base.int_2)
			{
				foreach (Control control in items)
				{
					if (control is IRibbonItem)
					{
						for (int j = 0; j < base.int_2; j++)
						{
							if (this.list_1[j].Contains((IRibbonItem)control))
							{
								throw new ArgumentException(base.m_rm.GetString("ERR_ADDRANGE_ALREADYEXIST"));
							}
						}
						if (!(control is RibbonButton) || ((RibbonButton)control).DisplayMode != IconTextRelation.LargeIconLabeled)
						{
							base.ribbonItemCollection_0.method_0(control, null);
							continue;
						}
						throw new ArgumentException(base.m_rm.GetString("ERR_ADD_LARGEICONLABELED"));
					}
					throw new ArgumentException(base.m_rm.GetString("ERR_ADDRANGE_NOTRIBBONITEM"));
				}
				this.list_1[row].InsertRange(index, (IRibbonItem[])items);
				base.method_2();
				return;
			}
			throw new ArgumentException(base.m_rm.GetString("ERR_ADD_PARAMETERROW"));
		}

		private List<IRibbonItem>[] method_6(List<IRibbonItem>[] list_2)
		{
			List<List<IRibbonItem>> list = new List<List<IRibbonItem>>();
			foreach (List<IRibbonItem> list2 in list_2)
			{
				if (list2.Count > 0)
				{
					list.Add(list2);
				}
			}
			return list.ToArray();
		}

		internal override void vmethod_0(Class560 class560_2, bool bool_7)
		{
			base.class560_1 = class560_2;
			base.bool_0 = true;
			base.class514_0.Controls.Clear();
			base.class514_0.RowCount = 8;
			base.class514_0.RowStyles.Clear();
			this.MinimumSize = new Size(Class517.smethod_33(this, !class560_2.Boolean_0), Class517.smethod_32(this));
			if (!class560_2.Boolean_0)
			{
				if (!bool_7)
				{
					base.ribbonMenuButton_0.Visible = false;
					base.class514_0.SetRowSpan(base.ribbonMenuButton_0, 1);
				}
				Class558 @class = (Class558)class560_2.Class557_0[0];
				List<IRibbonItem>[] array = (bool_7 ? this.method_6(((HorizontalRibbonGroup)base.ribbonGroup_0).List_1) : this.method_6(this.list_1));
				base.SetRowStyles(Math.Min(array.Length, base.int_2));
				int num = 0;
				base.class514_0.ColumnCount = 3;
				base.class514_0.ColumnStyles.Clear();
				int num2 = ((base.HorizontalContentAlignment == HorizontalAlignment.Center) ? 50 : ((base.HorizontalContentAlignment != HorizontalAlignment.Left) ? 100 : 0));
				base.class514_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, num2));
				base.class514_0.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
				int num3 = 1;
				while (num < array.Length && num < base.int_2)
				{
					Class514 class2 = new Class514(DockStyle.Top, array[num].Count, 1, this, this, bool_1: true);
					base.class514_0.Controls.Add(class2, 1, num3);
					for (int i = 0; i < @class.Class559_1[num].Length; i++)
					{
						Class559 class3 = @class.Class559_1[num][i];
						if (class3 == null)
						{
							continue;
						}
						Control control;
						if (bool_7)
						{
							Type type = class3.IRibbonItem_0.GetType();
							control = (Control)Activator.CreateInstance(type);
							Class517.smethod_3((Control)class3.IRibbonItem_0, control);
							if (control is IRibbonItem)
							{
								(control as IRibbonItem).AwareOfDPI(base.class498_0.PointF_0);
							}
							IScalable scalable;
							if ((scalable = control as IScalable) != null)
							{
								scalable.SetDisplayMode(class3.IconTextRelation_0);
							}
						}
						else
						{
							control = (Control)class3.IRibbonItem_0;
						}
						base.method_0(class2, control, i + 1, 0);
					}
					num++;
					num3 += 2;
				}
				int num4 = ((base.HorizontalContentAlignment == HorizontalAlignment.Center) ? 50 : ((base.HorizontalContentAlignment != HorizontalAlignment.Right) ? 100 : 0));
				base.class514_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, num4));
				base.bool_4 = true;
			}
			else
			{
				base.bool_4 = false;
				base.class514_0.ColumnCount = 1;
				base.class514_0.ColumnStyles.Clear();
				base.class514_0.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
				for (int j = 0; j < 8; j++)
				{
					base.class514_0.RowStyles.Add(new RowStyle(SizeType.AutoSize));
				}
				base.class514_0.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
				base.ribbonMenuButton_0.Visible = true;
				base.class514_0.Controls.Add(base.ribbonMenuButton_0, 0, 0);
				base.class514_0.SetRowSpan(base.ribbonMenuButton_0, 8);
			}
			base.bool_0 = false;
		}

		internal override RibbonGroup vmethod_1()
		{
			HorizontalRibbonGroup horizontalRibbonGroup = new HorizontalRibbonGroup(this);
			horizontalRibbonGroup.RightToLeft = this.RightToLeft;
			horizontalRibbonGroup.horizontalAlignment_0 = base.horizontalAlignment_0;
			horizontalRibbonGroup.Padding = Class517.smethod_51(Class519.Class523.Padding_2, base.class498_0.PointF_0);
			horizontalRibbonGroup.vmethod_0(base.Class560_0, bool_7: true);
			horizontalRibbonGroup.MinimumSize = new Size(Class517.smethod_33(this, bool_0: true), base.Height);
			return horizontalRibbonGroup;
		}

		protected override void Intialize(RibbonGroup parent)
		{
			base.ribbonItemCollection_0 = new RibbonItemCollection(parent);
			base.m_colTextColor = ((!base.Enabled) ? Color.FromArgb(base.int_1, parent.ForeColor) : Color.FromArgb(base.int_0, parent.ForeColor));
			base.ribbonGroup_0 = parent;
			base.BackColor = Color.Transparent;
			base.AutoSize = true;
			base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			base.Dock = DockStyle.Left;
			base.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			base.class514_0 = new Class514(DockStyle.Fill, 1, base.int_2 + 1, parent, this, bool_1: false);
			base.Controls.Add(base.class514_0);
			base.class514_0.RowCount = base.int_2 * 2 + 2;
			base.class514_0.RowStyles.Clear();
			for (int i = 0; i < base.class514_0.RowCount - 1; i++)
			{
				base.class514_0.RowStyles.Add(new RowStyle());
			}
			base.class514_0.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
		}
	}
}
