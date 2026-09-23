using System;
using System.Collections.Generic;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class560
	{
		private bool bool_0;

		private int int_0;

		private int int_1;

		private int int_2;

		private RibbonGroup ribbonGroup_0;

		private Class557[] class557_0 = new Class557[0];

		private Class560 class560_0;

		internal Class557[] Class557_0 => this.class557_0;

		internal bool Boolean_0 => this.bool_0;

		internal Class560 Class560_0
		{
			get
			{
				return this.class560_0;
			}
			set
			{
				this.class560_0 = value;
				this.class560_0.method_10(this);
			}
		}

		internal RibbonGroup RibbonGroup_0 => this.ribbonGroup_0;

		internal int Int32_0 => this.int_0;

		internal int Int32_1 => this.int_1;

		internal Class560(RibbonGroup ribbonGroup_1)
		{
			this.ribbonGroup_0 = ribbonGroup_1;
			this.int_2 = ribbonGroup_1.RowCount;
		}

		private int method_0()
		{
			int num = 0;
			Class557[] array = this.class557_0;
			foreach (Class557 @class in array)
			{
				num += @class.method_0();
			}
			return Math.Max(this.ribbonGroup_0.MinimumSize.Width, num + this.ribbonGroup_0.Padding.Horizontal);
		}

		private void method_1(Class557 class557_1, IconTextRelation iconTextRelation_0, List<Class559> list_0)
		{
			for (int i = 0; i < class557_1.Int32_0; i++)
			{
				IScalable scalable = class557_1.Class559_0[i].IRibbonItem_0 as IScalable;
				IconTextRelation iconTextRelation_ = ((scalable == null || scalable.IsScalable) ? ((class557_1.Class559_0[i].IconTextRelation_0 > iconTextRelation_0) ? iconTextRelation_0 : class557_1.Class559_0[i].IconTextRelation_0) : scalable.DefaultDisplayMode);
				Class559 item = ((scalable != null) ? new Class559(class557_1.Class559_0[i].IRibbonItem_0, iconTextRelation_) : new Class559(class557_1.Class559_0[i].IRibbonItem_0));
				list_0.Insert(0, item);
			}
		}

		internal bool method_2()
		{
			this.ribbonGroup_0.method_1();
			if (this.ribbonGroup_0 is HorizontalRibbonGroup)
			{
				this.method_3();
				return false;
			}
			if (this.ribbonGroup_0 is Class497)
			{
				this.method_5();
				return false;
			}
			this.method_4();
			return true;
		}

		private void method_3()
		{
			Class558 @class = new Class558(this.ribbonGroup_0.RowCount);
			HorizontalRibbonGroup horizontalRibbonGroup = (HorizontalRibbonGroup)this.ribbonGroup_0;
			for (int i = 0; i < horizontalRibbonGroup.RowCount; i++)
			{
				@class.Class559_1[i] = new Class559[horizontalRibbonGroup.List_1[i].Count];
				for (int j = 0; j < horizontalRibbonGroup.List_1[i].Count; j++)
				{
					IRibbonItem ribbonItem = horizontalRibbonGroup.List_1[i][j];
					ribbonItem.AwareOfDPI(ribbonItem.RibbonGroup.Class498_0.PointF_0);
					if (!ribbonItem.InternalVisible)
					{
						continue;
					}
					IScalable scalable = ribbonItem as IScalable;
					if (scalable != null)
					{
						@class.Class559_1[i][j] = new Class559(ribbonItem, scalable.DefaultDisplayMode);
						if (ribbonItem is RibbonMenuButton)
						{
							((RibbonMenuButton)ribbonItem).DropDownItems.method_5(this.ribbonGroup_0);
						}
					}
					else
					{
						@class.Class559_1[i][j] = new Class559(ribbonItem);
					}
				}
			}
			this.class557_0 = new Class558[1] { @class };
			this.int_0 = Math.Max(this.ribbonGroup_0.MinimumSize.Width, @class.method_2() + this.ribbonGroup_0.Padding.Horizontal);
			int num = this.ribbonGroup_0.Class515_0.Size_0.Width + this.ribbonGroup_0.Padding.Horizontal;
			if (this.int_0 < num)
			{
				this.int_0 = num;
			}
		}

		private void method_4()
		{
			List<Class557> list = new List<Class557>();
			int num = 0;
			int num2 = -1;
			foreach (IRibbonItem ribbonItem in this.ribbonGroup_0.RibbonItems)
			{
				ribbonItem.AwareOfDPI(ribbonItem.RibbonGroup.Class498_0.PointF_0);
				if (!ribbonItem.InternalVisible)
				{
					continue;
				}
				IScalable scalable = ribbonItem as IScalable;
				bool flag;
				bool flag2 = ((flag = scalable != null) && scalable.DefaultDisplayMode == IconTextRelation.LargeIconLabeled) || ribbonItem is RibbonListView;
				if (num2 == -1 || flag2 || num == this.int_2)
				{
					num2++;
					Class557 @class = new Class557(this.ribbonGroup_0.RowCount);
					if (flag2 && flag && !scalable.IsScalable)
					{
						@class.Boolean_0 = false;
					}
					list.Add(@class);
					num = 0;
				}
				if (flag)
				{
					list[num2].Class559_0[num] = new Class559(ribbonItem, scalable.DefaultDisplayMode);
				}
				else
				{
					list[num2].Class559_0[num] = new Class559(ribbonItem);
				}
				num = ((!flag2) ? (num + 1) : this.int_2);
				if (ribbonItem is IContentItem && ribbonItem is RibbonMenuButton)
				{
					((RibbonMenuButton)ribbonItem).DropDownItems.method_5(this.ribbonGroup_0);
				}
			}
			this.class557_0 = list.ToArray();
			this.int_0 = this.method_0();
			int num3 = this.ribbonGroup_0.Class515_0.Size_0.Width + this.ribbonGroup_0.Padding.Horizontal;
			if (this.int_0 < num3)
			{
				this.int_0 = num3;
			}
		}

		private void method_5()
		{
			List<Class557> list = new List<Class557>();
			list.Add(new Class557(this.ribbonGroup_0.RowCount));
			int num = 0;
			list[0].Class559_0 = new Class559[this.ribbonGroup_0.RibbonItems.Count];
			foreach (IRibbonItem ribbonItem in this.ribbonGroup_0.RibbonItems)
			{
				ribbonItem.AwareOfDPI(ribbonItem.RibbonGroup.Class498_0.PointF_0);
				IScalable scalable = ribbonItem as IScalable;
				if (scalable != null)
				{
					list[0].Class559_0[num] = new Class559(ribbonItem, scalable.DefaultDisplayMode);
				}
				else
				{
					list[0].Class559_0[num] = new Class559(ribbonItem);
				}
				num++;
				if (ribbonItem is IContentItem && ribbonItem is RibbonMenuButton)
				{
					((RibbonMenuButton)ribbonItem).DropDownItems.method_5(this.ribbonGroup_0);
				}
			}
			this.class557_0 = list.ToArray();
			this.int_0 = this.method_0();
		}

		internal void method_6()
		{
			this.bool_0 = true;
			this.int_0 = (int)((IRibbonItem)this.ribbonGroup_0.RibbonMenuButton_0).GetSize(IconTextRelation.LargeIconLabeled).Width + this.ribbonGroup_0.Padding.Horizontal;
		}

		internal bool method_7(Class560 class560_1)
		{
			int num = class560_1.Class557_0.Length - 1;
			while (true)
			{
				if (num > 0)
				{
					if (this.method_9(num, class560_1))
					{
						break;
					}
					num--;
					continue;
				}
				int num2 = class560_1.Class557_0.Length - 1;
				while (true)
				{
					if (num2 >= 0)
					{
						if (this.method_11(num2, class560_1))
						{
							break;
						}
						num2--;
						continue;
					}
					return false;
				}
				return true;
			}
			return true;
		}

		private bool method_8(Class557[] class557_1, int int_3, int int_4)
		{
			if (int_3 == int_4)
			{
				return true;
			}
			if (class557_1[int_3 + 1].Int32_0 == 3)
			{
				return true;
			}
			return false;
		}

		private bool method_9(int int_3, Class560 class560_1)
		{
			if (int_3 != -1)
			{
				Class557[] array = class560_1.Class557_0;
				Class557 @class = array[int_3];
				int num = @class.Int32_0;
				if (num < this.int_2 && this.method_8(array, int_3, array.Length - 1))
				{
					List<int> list = new List<int>();
					List<Class559> list2 = new List<Class559>();
					bool flag = false;
					IconTextRelation iconTextRelation = ((@class.IconTextRelation_0 == IconTextRelation.LargeIconLabeled) ? IconTextRelation.SmallIconLabeled : @class.IconTextRelation_0);
					this.method_1(@class, iconTextRelation, list2);
					int num2 = int_3 - 1;
					while (num2 >= 0 && num < this.int_2)
					{
						Class557 class2 = array[num2];
						if (class2.Boolean_0 && class2.IconTextRelation_0 >= @class.IconTextRelation_0 && num + class2.Int32_0 <= this.int_2)
						{
							if (class2.IconTextRelation_0 != (IconTextRelation)((int)iconTextRelation * 2) && class2.IconTextRelation_0 != iconTextRelation)
							{
								break;
							}
							num += class2.Int32_0;
							this.method_1(class2, iconTextRelation, list2);
							list.Add(num2);
							flag = true;
							num2--;
							continue;
						}
						return false;
					}
					if (flag)
					{
						this.class557_0 = new Class557[array.Length - list.Count];
						int num3 = 0;
						for (int i = 0; i < array.Length; i++)
						{
							if (!list.Contains(i))
							{
								Class557 class3 = array[i];
								this.class557_0[num3] = new Class557(this.ribbonGroup_0.RowCount);
								if (i != int_3)
								{
									this.class557_0[num3].method_1(class3.Class559_0);
								}
								else
								{
									this.class557_0[num3].method_1(list2.ToArray());
								}
								num3++;
							}
						}
						int num4 = this.method_0();
						int num5 = this.ribbonGroup_0.Class515_0.Size_0.Width + this.ribbonGroup_0.Padding.Horizontal;
						if (num4 >= num5)
						{
							this.int_0 = num4;
							return this.int_0 < class560_1.Int32_0;
						}
						return false;
					}
				}
			}
			return false;
		}

		private void method_10(Class560 class560_1)
		{
			this.int_1 = class560_1.Int32_0 - this.int_0;
		}

		private bool method_11(int int_3, Class560 class560_1)
		{
			IconTextRelation iconTextRelation_ = class560_1.Class557_0[int_3].IconTextRelation_0;
			if (iconTextRelation_ == IconTextRelation.SmallIconUnlabeled)
			{
				return false;
			}
			this.class557_0 = new Class557[class560_1.Class557_0.Length];
			for (int i = 0; i < this.class557_0.Length; i++)
			{
				this.class557_0[i] = new Class557(this.ribbonGroup_0.RowCount);
				if (i != int_3)
				{
					this.class557_0[i].method_1(class560_1.Class557_0[i].Class559_0);
					continue;
				}
				Class557 @class = class560_1.Class557_0[int_3];
				IconTextRelation iconTextRelation = (IconTextRelation)((int)iconTextRelation_ / 2);
				for (int j = 0; j < @class.Int32_0; j++)
				{
					IScalable scalable = @class.Class559_0[j].IRibbonItem_0 as IScalable;
					IconTextRelation iconTextRelation_2 = ((scalable == null || scalable.IsScalable) ? ((@class.Class559_0[j].IconTextRelation_0 == iconTextRelation_) ? iconTextRelation : @class.Class559_0[j].IconTextRelation_0) : scalable.DefaultDisplayMode);
					this.class557_0[int_3].Class559_0[j] = ((scalable != null) ? new Class559(@class.Class559_0[j].IRibbonItem_0, iconTextRelation_2) : new Class559(@class.Class559_0[j].IRibbonItem_0));
				}
			}
			int num = this.method_0();
			int num2 = this.ribbonGroup_0.Class515_0.Size_0.Width + this.ribbonGroup_0.Padding.Horizontal;
			if (num > num2)
			{
				this.int_0 = num;
				return this.int_0 < class560_1.Int32_0;
			}
			return false;
		}
	}
}
