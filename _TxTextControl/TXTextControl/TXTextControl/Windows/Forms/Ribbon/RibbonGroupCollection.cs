using System;
using System.Collections;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>An instance of the RibbonGroupCollection class contains objects of type RibbonGroup and can be obtained with the RibbonTab.RibbonGroups property.</summary>
	public class RibbonGroupCollection : CollectionBase, IEnumerator
	{
		private Class498 class498_0;

		private int int_0 = -1;

		public RibbonGroup this[int number] => (RibbonGroup)base.List[number];

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

		internal RibbonGroupCollection(Class498 owner)
		{
			this.class498_0 = owner;
		}

		public int Add(RibbonGroup ribbonGroup)
		{
			int result = -1;
			if (!this.class498_0.Class499_0.Controls.Contains(ribbonGroup))
			{
				this.class498_0.Class499_0.ColumnCount++;
				this.class498_0.Class499_0.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
				ribbonGroup.Class498_0 = this.class498_0;
				this.class498_0.Class499_0.Controls.Add(ribbonGroup, this.class498_0.Class499_0.ColumnCount - 1, 0);
				result = base.InnerList.Add(ribbonGroup);
				Class517.smethod_25(ribbonGroup);
				{
					foreach (IRibbonItem ribbonItem in ribbonGroup.RibbonItems)
					{
						Class517.smethod_6(ribbonItem, ribbonGroup);
					}
					return result;
				}
			}
			return result;
		}

		public void Insert(int index, RibbonGroup ribbonGroup)
		{
			if (this.class498_0.Class499_0.Controls.Contains(ribbonGroup))
			{
				return;
			}
			this.class498_0.Class499_0.ColumnCount++;
			this.class498_0.Class499_0.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
			ribbonGroup.Class498_0 = this.class498_0;
			foreach (Control control in this.class498_0.Class499_0.Controls)
			{
				int column = this.class498_0.Class499_0.GetColumn(control);
				if (column >= index)
				{
					this.class498_0.Class499_0.SetColumn(control, column + 1);
				}
			}
			this.class498_0.Class499_0.Controls.Add(ribbonGroup, index, 0);
			base.InnerList.Insert(index, ribbonGroup);
			Class517.smethod_25(ribbonGroup);
			foreach (IRibbonItem ribbonItem in ribbonGroup.RibbonItems)
			{
				Class517.smethod_6(ribbonItem, ribbonGroup);
			}
		}

		public void Remove(RibbonGroup ribbonGroup)
		{
			if (!this.class498_0.Class499_0.Contains(ribbonGroup))
			{
				return;
			}
			int column = this.class498_0.Class499_0.GetColumn(ribbonGroup);
			foreach (Control control in this.class498_0.Class499_0.Controls)
			{
				int column2 = this.class498_0.Class499_0.GetColumn(control);
				if (column2 > column)
				{
					this.class498_0.Class499_0.SetColumn(control, column2 - 1);
				}
			}
			this.class498_0.Class499_0.Controls.Remove(ribbonGroup);
			ribbonGroup.Class498_0 = null;
			base.InnerList.Remove(ribbonGroup);
			this.class498_0.Class499_0.ColumnCount--;
			this.class498_0.Class499_0.ColumnStyles.RemoveAt(this.class498_0.Class499_0.ColumnStyles.Count - 1);
			Class517.smethod_25(ribbonGroup);
		}

		public new void RemoveAt(int index)
		{
			RibbonGroup ribbonGroup = this.class498_0.Class499_0.GetControlFromPosition(index, 0) as RibbonGroup;
			if (ribbonGroup == null)
			{
				return;
			}
			foreach (Control control in this.class498_0.Class499_0.Controls)
			{
				int column = this.class498_0.Class499_0.GetColumn(control);
				if (column > index)
				{
					this.class498_0.Class499_0.SetColumn(control, column - 1);
				}
			}
			this.class498_0.Class499_0.Controls.Remove(ribbonGroup);
			ribbonGroup.Class498_0 = null;
			base.InnerList.Remove(ribbonGroup);
			this.class498_0.Class499_0.ColumnCount--;
			this.class498_0.Class499_0.ColumnStyles.RemoveAt(this.class498_0.Class499_0.ColumnStyles.Count - 1);
			Class517.smethod_25(ribbonGroup);
		}

		protected override void OnClear()
		{
			this.class498_0.Class499_0.Controls.Clear();
			this.class498_0.Class499_0.ColumnCount = 0;
			this.class498_0.Class499_0.ColumnStyles.Clear();
			base.OnClear();
		}

		protected override void OnRemove(int index, object value)
		{
			if (base.InnerList.Contains(value) && index >= 0 && index < this.class498_0.Class499_0.ColumnCount)
			{
				this.class498_0.Controls.Remove((RibbonGroup)value);
				for (int i = index; i < this.class498_0.Controls.Count; i++)
				{
					Control controlFromPosition = this.class498_0.Class499_0.GetControlFromPosition(i + 1, 0);
					this.class498_0.Class499_0.Controls.Add(controlFromPosition, i, 0);
				}
				this.class498_0.Class499_0.ColumnCount--;
				this.class498_0.Class499_0.ColumnStyles.RemoveAt(this.class498_0.Class499_0.ColumnCount);
			}
			base.OnRemove(index, value);
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
