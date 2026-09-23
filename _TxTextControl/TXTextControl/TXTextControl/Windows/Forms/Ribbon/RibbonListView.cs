using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ns21;
using ns27;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	/// <summary>The RibbonListView class is a list view control, which displays a collection of items that can be displayed using one of three different views.</summary>
	[ToolboxItem(false)]
	public class RibbonListView : ScrollableControl, INotifyPropertyChanged, IRibbonItem, IContentItem, IEnabledItem
	{
		public delegate void EditItemTextBoxActivatedEventHandler(object sender, RibbonListViewItemEventArgs e);

		public delegate void EditItemTextBoxDeactivatedEventHandler(object sender, RibbonListViewItemEventArgs e);

		public delegate void ItemClickedEventHandler(object sender, RibbonListViewItemEventArgs e);

		public delegate void ItemDropDownClosedEventHandler(object sender, RibbonListViewItemEventArgs e);

		public delegate void ItemDropDownOpeningEventHandler(object sender, RibbonListViewItemEventArgs e);

		public delegate void ItemMouseDownEventHandler(object sender, RibbonListViewItemEventArgs e);

		public delegate void ItemMouseUpEventHandler(object sender, RibbonListViewItemEventArgs e);

		public delegate void ItemMouseEnterEventHandler(object sender, RibbonListViewItemEventArgs e);

		public delegate void ItemMouseLeaveEventHandler(object sender, RibbonListViewItemEventArgs e);

		/// <summary>Determines the view mode of the RibbonListView:</summary>
		public enum ListViewMode
		{
			/// <summary>A RibbonListViewItem displayes its icon.</summary>
			Icon = 1,
			/// <summary>A RibbonListViewItem displayes its text.</summary>
			Text = 2,
			/// <summary>A RibbonListViewItem a drop-down.</summary>
			DropDown = 4
		}

		/// <summary>The RibbonListViewItem class represents an item in a RibbonListView control.</summary>
		public class RibbonListViewItem
		{
			private bool bool_0;

			private bool bool_1;

			private bool bool_2;

			private int int_0;

			private int int_1;

			private int int_2;

			private object object_0;

			private string string_0 = "";

			private System.Drawing.Image image_0;

			private Rectangle rectangle_0 = Rectangle.Empty;

			private Rectangle rectangle_1 = Rectangle.Empty;

			private Rectangle rectangle_2 = Rectangle.Empty;

			private RibbonListView ribbonListView_0;

			private RibbonToolTip ribbonToolTip_0 = new RibbonToolTip();

			private Point point_0 = Point.Empty;

			private Size size_0 = Size.Empty;

			internal TextFormatFlags textFormatFlags_0 = TextFormatFlags.NoPrefix | TextFormatFlags.RightToLeft | TextFormatFlags.VerticalCenter;

			internal TextFormatFlags textFormatFlags_1 = TextFormatFlags.NoPrefix | TextFormatFlags.VerticalCenter;

			private RibbonListViewItemDropDown ribbonListViewItemDropDown_0;

			[CompilerGenerated]
			private string string_1;

			[CompilerGenerated]
			private RibbonListViewItem ribbonListViewItem_0;

			/// <summary>Gets an object of type RibbonListView.RibbonListViewItemDropDown to access settings of the drop-down menu, that is displayed for each RibbonListViewItem when the RibbonListView.ViewMode property includes the ListViewMode.DropDown enumeration.</summary>
			public RibbonListViewItemDropDown DropDown => this.ribbonListViewItemDropDown_0;

			/// <summary>Gets or sets the icon for this RibbonListViewItem.</summary>
			[Category("Appearance")]
			[DefaultValue(null)]
			public System.Drawing.Image Icon
			{
				get
				{
					return this.image_0;
				}
				set
				{
					this.image_0 = value;
					if (this.ribbonListView_0 != null)
					{
						this.method_4();
						this.ribbonListView_0.method_11(bool_20: false);
					}
				}
			}

			/// <summary>Gets or sets a value indicating whether this RibbonListViewItem is editable.</summary>
			[Category("Appearance")]
			[DefaultValue(false)]
			public bool IsEditable
			{
				get
				{
					if (this.bool_1)
					{
						if (this.ribbonListView_0 != null)
						{
							return (this.ribbonListView_0.ViewMode & ListViewMode.Text) == ListViewMode.Text;
						}
						return true;
					}
					return false;
				}
				set
				{
					this.bool_1 = value;
					if (this.bool_2 && this.ribbonListView_0 != null)
					{
						this.ribbonListView_0.method_30(bool_20: false, Enum137.const_4);
					}
				}
			}

			/// <summary>Gets or sets a value indicating whether this RibbonListViewItem is selected.</summary>
			[Browsable(false)]
			public bool IsSelected
			{
				get
				{
					return this.bool_0;
				}
				set
				{
					if (this.bool_0 != (this.bool_0 = value) && this.ribbonListView_0 != null)
					{
						List<RibbonListViewItem> list = new List<RibbonListViewItem>(this.ribbonListView_0.SelectedItems);
						if (this.bool_0)
						{
							list.Add(this);
						}
						else
						{
							list.Remove(this);
						}
						this.ribbonListView_0.SelectedItems = list.ToArray();
					}
				}
			}

			/// <summary>Gets or sets the data associated with this RibbonListViewItem.</summary>
			[DefaultValue(null)]
			[Category("Data")]
			public object Tag
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

			/// <summary>Gets or sets the RibbonListViewItem's text</summary>
			[DefaultValue("")]
			[Category("Appearance")]
			public string Text
			{
				get
				{
					return this.string_0;
				}
				set
				{
					if (this.string_0 != (this.string_0 = value) && this.ribbonListView_0 != null)
					{
						this.method_4();
						this.ribbonListView_0.method_11(bool_20: false);
					}
				}
			}

			/// <summary>Gets an object of type RibbonToolTip that displays text when the mouse pointer hovers over the item.</summary>
			[Category("Misc")]
			[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
			public RibbonToolTip ToolTip => this.ribbonToolTip_0;

			internal Rectangle Rectangle_0
			{
				get
				{
					return this.rectangle_0;
				}
				set
				{
					this.rectangle_0 = value;
					if (this.ribbonListViewItemDropDown_0.Control14_0 != null)
					{
						this.ribbonListViewItemDropDown_0.Control14_0.Location = new Point(this.rectangle_0.Right - this.ribbonListViewItemDropDown_0.Control14_0.Width - this.ribbonListViewItemDropDown_0.Control14_0.Margin.Right, this.rectangle_0.Y + (this.rectangle_0.Height / 2 - this.ribbonListViewItemDropDown_0.Control14_0.Height / 2));
					}
				}
			}

			internal int Int32_0
			{
				get
				{
					return this.int_1;
				}
				set
				{
					this.int_1 = value;
				}
			}

			[Obfuscation(Exclude = true)]
			internal string String_0
			{
				[CompilerGenerated]
				get
				{
					return this.string_1;
				}
				[CompilerGenerated]
				set
				{
					this.string_1 = value;
				}
			}

			internal int Int32_1
			{
				get
				{
					return this.int_2;
				}
				set
				{
					this.int_2 = value;
				}
			}

			internal bool Boolean_0
			{
				get
				{
					return this.ribbonListViewItemDropDown_0.Boolean_0;
				}
				set
				{
					this.method_3(value);
				}
			}

			internal bool Boolean_1
			{
				get
				{
					return this.bool_2;
				}
				set
				{
					this.bool_2 = false;
				}
			}

			internal Point Point_0
			{
				get
				{
					return this.point_0;
				}
				set
				{
					this.point_0 = value;
				}
			}

			internal RibbonListViewItem RibbonListViewItem_0
			{
				[CompilerGenerated]
				get
				{
					return this.ribbonListViewItem_0;
				}
				[CompilerGenerated]
				set
				{
					this.ribbonListViewItem_0 = value;
				}
			}

			internal RibbonListView RibbonListView_0
			{
				get
				{
					return this.ribbonListView_0;
				}
				set
				{
					this.ribbonListView_0 = value;
					this.ribbonToolTip_0.Control_0 = this.ribbonListView_0;
				}
			}

			internal int Int32_2
			{
				get
				{
					return this.int_0;
				}
				set
				{
					this.int_0 = value;
				}
			}

			internal Size Size_0 => this.size_0;

			internal Rectangle Rectangle_1 => this.rectangle_2;

			/// <summary>Initializes a new instance of the RibbonListViewItem class.</summary>
			public RibbonListViewItem()
			{
				this.ribbonListViewItemDropDown_0 = new RibbonListViewItemDropDown(this);
			}

			internal void method_0()
			{
				this.ribbonToolTip_0.Dispose();
				if (this.image_0 != null)
				{
					this.image_0.Dispose();
				}
			}

			internal void method_1(Graphics graphics_0)
			{
				bool boolean_ = this.ribbonListView_0.Boolean_2;
				bool flag = this.string_0 != "" && this.ribbonListView_0.Boolean_1;
				if (boolean_ || flag)
				{
					VisualStyleRenderer visualStyleRenderer = null;
					try
					{
						VisualStyleElement element = (this.ribbonListView_0.HideSelectedItems ? VisualStyleElement.ToolBar.Button.Normal : ((this.ribbonListView_0.RibbonListViewItem_0 == this) ? Class517.smethod_14(this.bool_0) : Class517.smethod_13((!boolean_ || this.image_0 != null) && this.bool_0)));
						visualStyleRenderer = new VisualStyleRenderer(element);
					}
					catch
					{
					}
					visualStyleRenderer?.DrawBackground(graphics_0, this.rectangle_0);
					if (boolean_)
					{
						System.Drawing.Image image = ((this.image_0 != null) ? this.image_0 : (this.bool_0 ? Class517.Bitmap_2 : Class517.Bitmap_4));
						Rectangle destRect = new Rectangle(this.point_0.X + this.rectangle_1.X, this.point_0.Y + this.rectangle_1.Y, this.rectangle_1.Width, this.rectangle_1.Height);
						graphics_0.DrawImage(image, destRect, 0, 0, this.rectangle_1.Width, this.rectangle_1.Height, GraphicsUnit.Pixel, this.ribbonListView_0.imageAttributes_0);
					}
					if (flag)
					{
						int width = this.ribbonListView_0.int_8 - this.rectangle_2.X - this.ribbonListView_0.Padding_0.Right;
						int x = this.point_0.X + this.rectangle_2.X;
						TextRenderer.DrawText(bounds: new Rectangle(x, this.point_0.Y + this.rectangle_2.Y, width, this.rectangle_2.Height), dc: graphics_0, text: this.string_0, font: this.ribbonListView_0.Font, foreColor: this.ribbonListView_0.color_0, flags: (this.ribbonListView_0.Boolean_0 ? this.textFormatFlags_0 : this.textFormatFlags_1) | TextFormatFlags.EndEllipsis);
					}
				}
			}

			internal void method_2(bool bool_3)
			{
				this.bool_0 = bool_3;
			}

			internal void method_3(bool bool_3)
			{
				if (this.ribbonListViewItemDropDown_0.Boolean_0 = bool_3)
				{
					if (this.ribbonListViewItemDropDown_0.Control14_0 == null)
					{
						this.ribbonListViewItemDropDown_0.Control14_0 = new Control14();
						this.ribbonListViewItemDropDown_0.Control14_0.RibbonListViewItem_0 = this;
						this.ribbonListView_0.Controls.Add(this.ribbonListViewItemDropDown_0.Control14_0);
					}
				}
				else if (this.ribbonListViewItemDropDown_0.Control14_0 != null)
				{
					this.ribbonListViewItemDropDown_0.Control14_0.Dispose();
					this.ribbonListViewItemDropDown_0.Control14_0 = null;
				}
				this.method_4();
			}

			internal void method_4()
			{
				if (this.ribbonListView_0 == null || ((IRibbonItem)this.ribbonListView_0).DPI.IsEmpty)
				{
					return;
				}
				bool flag = (this.ribbonListView_0.ViewMode & ListViewMode.Icon) == ListViewMode.Icon;
				bool flag2 = (this.ribbonListView_0.ViewMode & ListViewMode.Text) == ListViewMode.Text;
				int num = 0;
				int val = 0;
				int y = 0;
				int num2 = 0;
				int y2 = 0;
				Size size = default(Size);
				System.Drawing.Image image = null;
				if (flag)
				{
					image = ((this.image_0 != null) ? this.image_0 : Class517.Bitmap_2);
					num = image.Width;
					val = image.Height;
				}
				if (flag2 && this.string_0 != "")
				{
					size = TextRenderer.MeasureText(this.string_0, this.ribbonListView_0.Font, Size.Empty, TextFormatFlags.NoPrefix | TextFormatFlags.VerticalCenter);
					val = Math.Max(val, size.Height);
					num += ((num > 0) ? this.ribbonListView_0.int_9 : 0);
					num2 = num;
					num += size.Width;
					if (num + this.ribbonListView_0.Padding_0.Horizontal > this.ribbonListView_0.int_2)
					{
						num = this.ribbonListView_0.int_2 - this.ribbonListView_0.Padding_0.Horizontal;
						size = new Size(num - num2, size.Height);
					}
				}
				if (this.ribbonListViewItemDropDown_0.Boolean_0)
				{
					Size preferredSize = this.ribbonListViewItemDropDown_0.Control14_0.PreferredSize;
					val = Math.Max(val, preferredSize.Height);
					num += preferredSize.Width + Class517.smethod_45(this.ribbonListViewItemDropDown_0.Control14_0.Margin.Horizontal, ((IRibbonItem)this.RibbonListView_0).DPI.X);
				}
				int val2 = Class517.smethod_45(this.ribbonListView_0.EditItemTextBoxEmptyWidth, ((IRibbonItem)this.RibbonListView_0).DPI.X);
				this.size_0 = new Size(Class517.smethod_15(Math.Max(val2, num)), Class517.smethod_15(val));
				bool flag3 = flag;
				bool flag4 = flag2 && this.string_0 != "";
				if (flag3 && flag4)
				{
					if (image.Height > size.Height)
					{
						y2 = (int)((double)this.size_0.Height / 2.0 - (double)size.Height / 2.0);
					}
					else
					{
						y = (int)((double)this.size_0.Height / 2.0 - (double)image.Height / 2.0);
					}
				}
				if (flag3)
				{
					int x = (this.ribbonListView_0.Boolean_0 ? (num - image.Width) : 0);
					this.rectangle_1 = new Rectangle(x, y, image.Width, image.Height);
				}
				if (flag4)
				{
					num2 = ((!this.ribbonListView_0.Boolean_0) ? num2 : 0);
					this.rectangle_2 = new Rectangle(num2, y2, size.Width, size.Height);
				}
			}

			public override string ToString()
			{
				if (this.ribbonListView_0 != null && (this.ribbonListView_0.ViewMode & ListViewMode.Text) != ListViewMode.Text)
				{
					return base.ToString();
				}
				return this.string_0;
			}
		}

		/// <summary>The RibbonListViewItemDropDown class provides properties to modify the settings of the drop-down menu, that is displayed for each RibbonListViewItem when the RibbonListView.ViewMode property includes the ListViewMode.DropDown enumeration.</summary>
		public class RibbonListViewItemDropDown
		{
			private string[] string_0 = new string[0];

			private string string_1;

			private string string_2 = string.Empty;

			private int int_0;

			private int int_1 = -1;

			private bool bool_0;

			private bool bool_1 = true;

			private RibbonListViewItem ribbonListViewItem_0;

			private Control14 control14_0;

			[CompilerGenerated]
			private bool bool_2;

			/// <summary>Gets or sets all items that are displayed when the drop-down menu is opened.</summary>
			public string[] Items
			{
				get
				{
					return this.string_0;
				}
				set
				{
					if (value == null)
					{
						this.string_0 = new string[0];
					}
					else
					{
						this.string_0 = value;
					}
					for (int i = 0; i < this.string_0.Length; i++)
					{
						string text = this.string_0[i];
						if (text == null)
						{
							this.string_0[i] = "";
						}
					}
				}
			}

			/// <summary>Gets or sets the minimum width, in 1/96 inch, of the displayed drop-down.</summary>
			public int MinimumWidth
			{
				get
				{
					return this.int_0;
				}
				set
				{
					int num = this.int_0;
					if (this.int_0 != (this.int_0 = value) && this.int_0 > num && this.ribbonListViewItem_0.RibbonListView_0 != null)
					{
						this.ribbonListViewItem_0.method_4();
						this.ribbonListViewItem_0.RibbonListView_0.method_11(bool_20: true);
					}
				}
			}

			/// <summary>Gets or sets the index of the currently selected drop-down item.</summary>
			public int SelectedIndex
			{
				get
				{
					return this.int_1;
				}
				set
				{
					if (value >= -1 && value < this.string_0.Length)
					{
						if (this.int_1 != (this.int_1 = value))
						{
							if (this.int_1 == -1)
							{
								this.string_1 = null;
							}
							else
							{
								this.string_1 = this.string_0[this.int_1];
							}
							this.string_2 = this.string_1;
							if (this.bool_0)
							{
								this.control14_0.Invalidate();
							}
						}
						return;
					}
					throw new IndexOutOfRangeException();
				}
			}

			/// <summary>Gets or sets the current selected drop-down item.</summary>
			public string SelectedItem
			{
				get
				{
					return this.string_1;
				}
				set
				{
					this.int_1 = -1;
					this.string_1 = null;
					this.string_2 = string.Empty;
					int num = 0;
					while (true)
					{
						if (num < this.string_0.Length)
						{
							string text = this.string_0[num];
							if (text == value)
							{
								break;
							}
							num++;
							continue;
						}
						return;
					}
					this.int_1 = num;
					this.string_2 = (this.string_1 = value);
					if (this.bool_0)
					{
						this.control14_0.Invalidate();
					}
				}
			}

			/// <summary>Gets or sets a value indicating whether space for a check mark is shown on the left edge of the drop-down menu.</summary>
			public bool ShowCheckMargin
			{
				[CompilerGenerated]
				get
				{
					return this.bool_2;
				}
				[CompilerGenerated]
				set
				{
					this.bool_2 = value;
				}
			}

			/// <summary>Gets or sets a value indicating whether the value of the RibbonListViewItemDropDown.Text property is displayed to the left of the drop-down button.</summary>
			public bool ShowText
			{
				get
				{
					return this.bool_1;
				}
				set
				{
					if (this.bool_1 != (this.bool_1 = value) && this.ribbonListViewItem_0.RibbonListView_0 != null)
					{
						this.ribbonListViewItem_0.method_4();
						this.ribbonListViewItem_0.RibbonListView_0.method_11(bool_20: true);
					}
				}
			}

			/// <summary>Gets or sets the text that is displayed to the left of the drop-down button, if the RibbonListViewItemDropDown.ShowText property is set to true.</summary>
			public string Text
			{
				get
				{
					return this.string_2;
				}
				set
				{
					string text = ((value == null) ? string.Empty : value);
					if (this.string_2 != (this.string_2 = text) && this.control14_0 != null && this.bool_1)
					{
						this.control14_0.Invalidate();
					}
				}
			}

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

			internal Control14 Control14_0
			{
				get
				{
					return this.control14_0;
				}
				set
				{
					this.control14_0 = value;
				}
			}

			internal RibbonListViewItemDropDown(RibbonListViewItem ribbonListViewItem)
			{
				this.ribbonListViewItem_0 = ribbonListViewItem;
			}
		}

		/// <summary>An instance of the RibbonListViewItemCollection class contains controls of type RibbonListViewItem and can be obtained with the RibbonListView.RibbonListViewItems property.</summary>
		public class RibbonListViewItemCollection : CollectionBase, IEnumerator
		{
			private int int_0 = -1;

			private RibbonListView ribbonListView_0;

			private bool bool_0;

			public RibbonListViewItem this[int number] => (RibbonListViewItem)base.List[number];

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

			internal RibbonListViewItemCollection(RibbonListView parent)
			{
				this.ribbonListView_0 = parent;
			}

			public int Add(RibbonListViewItem item)
			{
				int result = -1;
				if (!this.bool_0 && (result = this.method_2(item)) != -1)
				{
					this.ribbonListView_0.method_11(bool_20: false);
				}
				return result;
			}

			internal int method_0(RibbonListViewItem ribbonListViewItem_0)
			{
				int num = 0;
				foreach (RibbonListViewItem inner in base.InnerList)
				{
					if (ribbonListViewItem_0 != inner)
					{
						num++;
						continue;
					}
					return num;
				}
				return -1;
			}

			internal RibbonListViewItem method_1(int int_1, int int_2)
			{
				if (int_1 < 0)
				{
					return base.InnerList[0] as RibbonListViewItem;
				}
				bool flag = false;
				foreach (RibbonListViewItem inner in base.InnerList)
				{
					if (inner.Int32_2 == int_1)
					{
						flag = true;
						if (inner.Int32_0 == int_2)
						{
							return inner;
						}
					}
					else if (flag && inner.Int32_2 > int_1)
					{
						return inner;
					}
				}
				return base.InnerList[base.InnerList.Count - 1] as RibbonListViewItem;
			}

			internal int method_2(RibbonListViewItem ribbonListViewItem_0)
			{
				int result = -1;
				if (ribbonListViewItem_0 != null)
				{
					this.ribbonListView_0.method_30(bool_20: false, Enum137.const_5);
					result = base.InnerList.Add(ribbonListViewItem_0);
					ribbonListViewItem_0.RibbonListView_0 = this.ribbonListView_0;
					ribbonListViewItem_0.method_4();
				}
				return result;
			}

			internal void method_3(bool bool_1)
			{
				this.ribbonListView_0.method_30(bool_20: false, Enum137.const_5);
				foreach (RibbonListViewItem inner in base.InnerList)
				{
					inner.Boolean_0 = false;
				}
				base.Clear();
				if (this.ribbonListView_0.method_0(new int[0]) && bool_1 && ((IContentItem)this.ribbonListView_0).Original == null)
				{
					this.ribbonListView_0.vmethod_0("SelectedIndices");
					this.ribbonListView_0.vmethod_0("SelectedItems");
				}
				this.ribbonListView_0.method_11(bool_20: false);
			}

			public new void Clear()
			{
				if (!this.bool_0)
				{
					this.method_3(bool_1: true);
				}
			}

			public new void RemoveAt(int index)
			{
				if (!this.bool_0)
				{
					this.ribbonListView_0.method_30(bool_20: false, Enum137.const_5);
					base.RemoveAt(index);
					this.ribbonListView_0.method_11(bool_20: false);
				}
			}

			protected override void OnRemoveComplete(int index, object value)
			{
				RibbonListViewItem ribbonListViewItem = (RibbonListViewItem)value;
				if (ribbonListViewItem.IsSelected)
				{
					RibbonListViewItem[] array = new RibbonListViewItem[this.ribbonListView_0.SelectedItems.Length - 1];
					int num = 0;
					for (int i = 0; i < this.ribbonListView_0.SelectedItems.Length; i++)
					{
						if (this.ribbonListView_0.SelectedItems[i] != ribbonListViewItem)
						{
							array[num] = this.ribbonListView_0.SelectedItems[i];
							num++;
						}
					}
					if (this.ribbonListView_0.method_1(array) && ((IContentItem)this.ribbonListView_0).Original == null)
					{
						this.ribbonListView_0.vmethod_0("SelectedIndices");
						this.ribbonListView_0.vmethod_0("SelectedItems");
					}
				}
				this.ribbonListView_0.Invalidate();
				base.OnRemoveComplete(index, value);
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

		internal enum Enum137
		{
			const_0,
			const_1,
			const_2,
			const_3,
			const_4,
			const_5,
			const_6,
			const_7,
			const_8,
			const_9,
			const_10
		}

		/// <summary>The RibbonListViewItemEventArgs class provides data for the RibbonListView.EditItemTextBoxActivated, RibbonListView.EditItemTextBoxDeactivated, RibbonListView.ItemClick, ItemMouseEnter or ItemMouseLeave event.</summary>
		public class RibbonListViewItemEventArgs : EventArgs
		{
			private RibbonListViewItem ribbonListViewItem_0;

			private Enum137 enum137_0 = Enum137.const_9;

			/// <summary>Gets an object of type RibbonListViewItem that represents the handled item.</summary>
			public RibbonListViewItem Item => this.ribbonListViewItem_0;

			internal Enum137 Enum137_0
			{
				get
				{
					return this.enum137_0;
				}
				set
				{
					this.enum137_0 = value;
				}
			}

			internal RibbonListViewItemEventArgs(RibbonListViewItem item)
			{
				this.ribbonListViewItem_0 = item;
			}
		}

		internal class Class553
		{
			internal enum Enum138
			{
				const_0,
				const_1,
				const_2,
				const_3,
				const_4,
				const_5
			}

			private bool bool_0;

			private bool bool_1;

			private bool bool_2;

			private bool bool_3;

			internal bool bool_4 = true;

			private int int_0 = 15;

			private int int_1;

			private int int_2 = 2;

			private Rectangle rectangle_0 = default(Rectangle);

			private Rectangle rectangle_1 = default(Rectangle);

			private Rectangle rectangle_2 = default(Rectangle);

			private Rectangle rectangle_3 = default(Rectangle);

			private RibbonListView ribbonListView_0;

			private Enum138 enum138_0 = Enum138.const_5;

			private System.Windows.Forms.Timer timer_0;

			private VisualStyleRenderer visualStyleRenderer_0;

			private VisualStyleRenderer visualStyleRenderer_1;

			private VisualStyleRenderer visualStyleRenderer_2;

			private VisualStyleRenderer visualStyleRenderer_3;

			internal bool Boolean_0
			{
				get
				{
					if (this.ribbonListView_0.DropDownItems.Count <= 0)
					{
						if (this.ribbonListView_0.ShowItemsInDropDown)
						{
							return this.ribbonListView_0.RibbonListViewItems.Count > 0;
						}
						return false;
					}
					return true;
				}
			}

			internal bool Boolean_1 => this.enum138_0 == Enum138.const_2;

			internal bool Boolean_2 => this.enum138_0 != Enum138.const_4;

			internal bool Boolean_3
			{
				get
				{
					return this.bool_4;
				}
				set
				{
					this.bool_4 = value;
				}
			}

			internal int Int32_0
			{
				get
				{
					return this.int_1;
				}
				set
				{
					this.int_1 = value;
				}
			}

			internal bool Boolean_4
			{
				get
				{
					return this.bool_3;
				}
				set
				{
					this.bool_3 = value;
				}
			}

			internal int Int32_1
			{
				get
				{
					return this.int_0;
				}
				set
				{
					this.int_0 = value;
				}
			}

			internal Class553(RibbonListView ribbonListView_1)
			{
				try
				{
					this.visualStyleRenderer_0 = new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal);
					this.visualStyleRenderer_1 = new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal);
					this.visualStyleRenderer_2 = new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal);
					this.visualStyleRenderer_3 = new VisualStyleRenderer(VisualStyleElement.Button.GroupBox.Normal);
				}
				catch
				{
				}
				this.ribbonListView_0 = ribbonListView_1;
			}

			private void timer_0_Tick(object sender, EventArgs e)
			{
				(sender as System.Windows.Forms.Timer).Interval = 100;
				if (this.bool_1)
				{
					if (this.bool_0)
					{
						this.method_8(this.int_1 - 1);
					}
					else
					{
						this.method_2();
					}
				}
				else if (this.bool_2)
				{
					this.method_8(this.int_1 + 1);
				}
				else
				{
					this.method_2();
				}
			}

			internal bool method_0()
			{
				this.bool_1 = false;
				if (this.bool_4)
				{
					if (this.enum138_0 == Enum138.const_0)
					{
						if (this.bool_0)
						{
							this.bool_1 = true;
							this.method_1();
							this.method_8(this.int_1 - 1);
						}
						return true;
					}
					if (this.enum138_0 == Enum138.const_1)
					{
						if (this.bool_2)
						{
							this.method_1();
							this.method_8(this.int_1 + 1);
						}
						return true;
					}
				}
				if (this.Boolean_0 && this.enum138_0 == Enum138.const_2)
				{
					this.ribbonListView_0.method_35();
					return true;
				}
				return false;
			}

			private void method_1()
			{
				this.timer_0 = new System.Windows.Forms.Timer
				{
					Interval = 500
				};
				this.timer_0.Tick += timer_0_Tick;
				this.timer_0.Start();
			}

			internal void method_2()
			{
				if (this.timer_0 != null)
				{
					this.timer_0.Stop();
					try
					{
						this.timer_0.Dispose();
						this.timer_0 = null;
					}
					catch
					{
						this.timer_0 = null;
					}
				}
				this.bool_1 = false;
			}

			internal Enum138 method_3(Point point_0)
			{
				if (this.rectangle_0.Contains(point_0))
				{
					if (this.rectangle_1.Contains(point_0))
					{
						return Enum138.const_0;
					}
					if (this.rectangle_2.Contains(point_0))
					{
						return Enum138.const_1;
					}
					if (this.rectangle_3.Contains(point_0))
					{
						return Enum138.const_2;
					}
					return Enum138.const_3;
				}
				return Enum138.const_4;
			}

			internal void method_4(Graphics graphics_0)
			{
				Color color = Color.FromArgb(65, this.ribbonListView_0.ForeColor);
				if (this.visualStyleRenderer_3 != null)
				{
					this.visualStyleRenderer_3.DrawBackground(graphics_0, this.rectangle_0);
				}
				if (this.bool_4)
				{
					if (this.visualStyleRenderer_0 != null)
					{
						this.visualStyleRenderer_0.DrawBackground(graphics_0, this.rectangle_1);
					}
					Color color_ = ((!this.bool_0 || !this.ribbonListView_0.Enabled) ? color : this.ribbonListView_0.ForeColor);
					Class517.smethod_17(graphics_0, this.rectangle_1, color_, ArrowDirection.Up, ((IRibbonItem)this.ribbonListView_0).DPI);
					if (this.visualStyleRenderer_1 != null)
					{
						this.visualStyleRenderer_1.DrawBackground(graphics_0, this.rectangle_2);
					}
					Color color_2 = ((!this.bool_2 || !this.ribbonListView_0.Enabled) ? color : this.ribbonListView_0.ForeColor);
					Class517.smethod_17(graphics_0, this.rectangle_2, color_2, ArrowDirection.Down, ((IRibbonItem)this.ribbonListView_0).DPI);
				}
				if (this.int_2 == 3)
				{
					if (this.visualStyleRenderer_2 != null)
					{
						this.visualStyleRenderer_2.DrawBackground(graphics_0, this.rectangle_3);
					}
					Color color_3 = (this.ribbonListView_0.Enabled ? this.ribbonListView_0.ForeColor : color);
					Class517.smethod_18(graphics_0, this.rectangle_3, color_3, ((IRibbonItem)this.ribbonListView_0).DPI);
				}
			}

			internal void method_5()
			{
				this.bool_0 = this.int_1 > 0;
				this.bool_2 = this.ribbonListView_0.RowCount > this.ribbonListView_0.MaxVisibleRows && this.int_1 < this.ribbonListView_0.RowCount - this.ribbonListView_0.MaxVisibleRows;
			}

			internal void method_6()
			{
				int x = ((!this.ribbonListView_0.bool_15) ? (this.ribbonListView_0.Width - this.int_0) : 0);
				int y = 0;
				int width = this.int_0;
				int height = this.ribbonListView_0.Height;
				this.rectangle_0 = new Rectangle(x, 0, width, height);
				this.int_2 = (this.Boolean_0 ? 3 : 2);
				int num = ((height / this.int_2 < this.ribbonListView_0.int_13) ? (height / this.int_2) : this.ribbonListView_0.int_13);
				this.rectangle_1 = new Rectangle(x, y, width, num);
				this.rectangle_2 = new Rectangle(x, height - num * (this.int_2 - 1), width, num);
				this.rectangle_3 = new Rectangle(x, height - num, width, num);
				this.method_5();
			}

			internal bool method_7(Enum138 enum138_1)
			{
				bool flag = this.enum138_0 != (this.enum138_0 = enum138_1);
				if (this.bool_3 && flag)
				{
					try
					{
						switch (enum138_1)
						{
						case Enum138.const_0:
							this.visualStyleRenderer_0 = ((!this.bool_0 || !this.ribbonListView_0.Enabled) ? new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Disabled) : new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Hot));
							this.visualStyleRenderer_1 = ((!this.bool_2 || !this.ribbonListView_0.Enabled) ? new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Disabled) : new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal));
							this.visualStyleRenderer_2 = (this.ribbonListView_0.Enabled ? new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal) : new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Disabled));
							return flag;
						case Enum138.const_1:
							this.visualStyleRenderer_0 = ((!this.bool_0 || !this.ribbonListView_0.Enabled) ? new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Disabled) : new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal));
							this.visualStyleRenderer_1 = ((!this.bool_2 || !this.ribbonListView_0.Enabled) ? new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Disabled) : new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Hot));
							this.visualStyleRenderer_2 = (this.ribbonListView_0.Enabled ? new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal) : new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Disabled));
							return flag;
						case Enum138.const_2:
							this.visualStyleRenderer_0 = ((!this.bool_0 || !this.ribbonListView_0.Enabled) ? new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Disabled) : new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal));
							this.visualStyleRenderer_1 = ((!this.bool_2 || !this.ribbonListView_0.Enabled) ? new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Disabled) : new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal));
							this.visualStyleRenderer_2 = (this.ribbonListView_0.Enabled ? new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Hot) : new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Disabled));
							return flag;
						default:
							this.visualStyleRenderer_0 = ((!this.bool_0 || !this.ribbonListView_0.Enabled) ? new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Disabled) : new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal));
							this.visualStyleRenderer_1 = ((!this.bool_2 || !this.ribbonListView_0.Enabled) ? new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Disabled) : new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal));
							this.visualStyleRenderer_2 = (this.ribbonListView_0.Enabled ? new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal) : new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Disabled));
							return flag;
						}
					}
					catch
					{
						return flag;
					}
				}
				return flag;
			}

			internal void method_8(int int_3)
			{
				if (this.int_1 != (this.int_1 = int_3))
				{
					this.method_5();
					this.ribbonListView_0.method_14();
					this.ribbonListView_0.Invalidate();
				}
			}
		}

		internal class Class554 : TableLayoutPanel
		{
			protected override Padding DefaultMargin => new Padding(0);

			internal Class554(Control control_0)
			{
				this.AutoSize = true;
				this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
				this.Dock = DockStyle.Left;
				base.RowCount = 3;
				base.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
				base.RowStyles.Add(new RowStyle());
				base.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
				base.Controls.Add(control_0, 0, 1);
			}

			protected override void WndProc(ref Message message)
			{
				Class429.Enum121 msg = (Class429.Enum121)message.Msg;
				if (msg != Class429.Enum121.const_56)
				{
					base.WndProc(ref message);
				}
			}
		}

		internal class Class555 : TextBox
		{
			private bool bool_0;

			private bool bool_1;

			internal bool Boolean_0
			{
				get
				{
					return this.bool_0;
				}
				set
				{
					if (this.bool_0 != (this.bool_0 = value))
					{
						this.bool_1 = true;
						base.Visible = value;
					}
				}
			}

			protected override void OnKeyPress(KeyPressEventArgs keyPressEventArgs_0)
			{
				base.OnKeyPress(keyPressEventArgs_0);
				if (keyPressEventArgs_0.KeyChar == '\r')
				{
					keyPressEventArgs_0.Handled = true;
				}
			}

			protected override void OnVisibleChanged(EventArgs eventArgs_0)
			{
				if (this.bool_1)
				{
					base.OnVisibleChanged(eventArgs_0);
				}
				this.bool_1 = true;
			}

			protected override void WndProc(ref Message message)
			{
				Class429.Enum121 msg = (Class429.Enum121)message.Msg;
				if (msg != Class429.Enum121.const_56)
				{
					base.WndProc(ref message);
				}
			}
		}

		internal class Control14 : Control
		{
			private RibbonListViewItem ribbonListViewItem_0;

			private int int_0;

			private Padding padding_0;

			private PointF pointF_0 = PointF.Empty;

			private Rectangle rectangle_0 = Rectangle.Empty;

			private Rectangle rectangle_1 = Rectangle.Empty;

			private bool bool_0;

			private VisualStyleRenderer visualStyleRenderer_0;

			private VisualStyleRenderer visualStyleRenderer_1;

			private VisualStyleRenderer visualStyleRenderer_2;

			internal RibbonListViewItem RibbonListViewItem_0
			{
				get
				{
					return this.ribbonListViewItem_0;
				}
				set
				{
					this.ribbonListViewItem_0 = value;
					this.method_0(this.ribbonListViewItem_0.RibbonListView_0.pointF_0);
				}
			}

			internal Control14()
			{
				try
				{
					this.visualStyleRenderer_0 = new VisualStyleRenderer(VisualStyleElement.Button.GroupBox.Normal);
					this.visualStyleRenderer_2 = new VisualStyleRenderer(VisualStyleElement.Button.GroupBox.Normal);
				}
				catch
				{
				}
				base.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			}

			public override Size GetPreferredSize(Size proposedSize)
			{
				int num = Class517.smethod_45(this.ribbonListViewItem_0.DropDown.MinimumWidth, this.pointF_0.X);
				int num2 = TextRenderer.MeasureText("A", this.ribbonListViewItem_0.RibbonListView_0.Font, Size.Empty, TextFormatFlags.NoPrefix | TextFormatFlags.VerticalCenter).Height;
				int num3 = 0;
				if (this.ribbonListViewItem_0.DropDown.ShowText)
				{
					string[] items = this.ribbonListViewItem_0.DropDown.Items;
					foreach (string text in items)
					{
						num3 = Math.Max(num3, TextRenderer.MeasureText(text, this.ribbonListViewItem_0.RibbonListView_0.Font, Size.Empty, TextFormatFlags.NoPrefix | TextFormatFlags.VerticalCenter).Width);
					}
					this.rectangle_0 = new Rectangle(this.padding_0.Left, this.padding_0.Top, num3, num2);
					num3 += this.padding_0.Horizontal;
				}
				num2 += this.padding_0.Vertical + 1;
				this.rectangle_1 = new Rectangle(num3, 0, this.int_0, num2);
				num3 += this.int_0;
				if (num3 < num)
				{
					num3 = num;
					this.rectangle_0.Width = num - this.int_0;
					this.rectangle_1.X = this.rectangle_0.Right;
				}
				return new Size(num3, num2);
			}

			protected override void OnPaint(PaintEventArgs pea)
			{
				if (this.ribbonListViewItem_0.DropDown.ShowText && this.visualStyleRenderer_0 != null)
				{
					this.visualStyleRenderer_0.DrawBackground(pea.Graphics, new Rectangle(0, 0, base.Width, base.Height));
				}
				if (this.ribbonListViewItem_0.DropDown.ShowText && !string.IsNullOrEmpty(this.ribbonListViewItem_0.DropDown.SelectedItem))
				{
					TextRenderer.DrawText(pea.Graphics, (this.ribbonListViewItem_0.DropDown.Text == null) ? "" : this.ribbonListViewItem_0.DropDown.Text, this.ribbonListViewItem_0.RibbonListView_0.Font, this.rectangle_0, this.ribbonListViewItem_0.RibbonListView_0.color_0, (this.ribbonListViewItem_0.RibbonListView_0.Boolean_0 ? this.ribbonListViewItem_0.textFormatFlags_0 : this.ribbonListViewItem_0.textFormatFlags_1) | TextFormatFlags.EndEllipsis);
				}
				if (this.visualStyleRenderer_2 != null)
				{
					this.visualStyleRenderer_2.DrawBackground(pea.Graphics, this.rectangle_1);
				}
				if (this.visualStyleRenderer_1 != null)
				{
					this.visualStyleRenderer_1.DrawBackground(pea.Graphics, this.rectangle_1);
				}
				Color color = Color.FromArgb(65, this.ribbonListViewItem_0.RibbonListView_0.ForeColor);
				Color color_ = (this.ribbonListViewItem_0.RibbonListView_0.Enabled ? this.ribbonListViewItem_0.RibbonListView_0.ForeColor : color);
				Class517.smethod_17(pea.Graphics, this.rectangle_1, color_, ArrowDirection.Down, this.ribbonListViewItem_0.RibbonListView_0.pointF_0);
				base.OnPaint(pea);
			}

			protected override void OnMouseMove(MouseEventArgs mevent)
			{
				if (this.bool_0 != (this.bool_0 = this.rectangle_1.Contains(mevent.Location)))
				{
					this.method_2();
				}
				base.OnMouseMove(mevent);
			}

			protected override void OnMouseEnter(EventArgs eventargs)
			{
				base.PointToClient(Control.MousePosition);
				if (this.bool_0 != (this.bool_0 = this.rectangle_1.Contains(base.PointToClient(Control.MousePosition))))
				{
					this.method_2();
				}
				base.OnMouseEnter(eventargs);
			}

			protected override void OnMouseLeave(EventArgs eventargs)
			{
				bool num = this.bool_0;
				this.bool_0 = false;
				if (num)
				{
					this.method_2();
				}
				base.OnMouseLeave(eventargs);
			}

			protected override void OnClick(EventArgs eventArgs_0)
			{
				this.ribbonListViewItem_0.RibbonListView_0.method_2(base.Location, (Control.ModifierKeys & Keys.Control) == Keys.Control || this.ribbonListViewItem_0.RibbonListView_0.bool_2);
				if (this.bool_0)
				{
					this.method_1();
				}
				base.OnClick(eventArgs_0);
			}

			protected override void WndProc(ref Message message)
			{
				Class429.Enum121 msg = (Class429.Enum121)message.Msg;
				if (msg != Class429.Enum121.const_56)
				{
					base.WndProc(ref message);
				}
			}

			internal void method_0(PointF pointF_1)
			{
				if (this.pointF_0.X != pointF_1.X || this.pointF_0.Y != pointF_1.Y)
				{
					this.pointF_0 = pointF_1;
					this.int_0 = Class466.smethod_4((uint)pointF_1.X);
					this.padding_0 = Class517.smethod_51(new Padding(1, 0, 1, 1), pointF_1);
					base.Size = base.PreferredSize;
				}
			}

			internal void method_1()
			{
				if (this.ribbonListViewItem_0.DropDown.Items.Length > 0)
				{
					RibbonDropDown ribbonDropDown = new RibbonDropDown();
					ribbonDropDown.AutoClose = true;
					ribbonDropDown.Font = this.Font;
					RibbonDropDown ribbonDropDown2 = ribbonDropDown;
					ribbonDropDown2.ShowCheckMargin = this.ribbonListViewItem_0.DropDown.ShowCheckMargin;
					string[] items = this.ribbonListViewItem_0.DropDown.Items;
					foreach (string text in items)
					{
						ribbonDropDown2.Items.Add(new ToolStripMenuItem(text));
					}
					bool flag;
					RibbonListView ribbonListView = ((flag = this.ribbonListViewItem_0.RibbonListView_0.ribbonListView_1 != null) ? this.ribbonListViewItem_0.RibbonListView_0.ribbonListView_1 : this.ribbonListViewItem_0.RibbonListView_0);
					ribbonListView.method_24(flag ? this.ribbonListViewItem_0.RibbonListViewItem_0 : this.ribbonListViewItem_0);
					ribbonDropDown2.Closed += method_4;
					if (this.ribbonListViewItem_0.DropDown.SelectedIndex >= 0 && ribbonDropDown2.ShowCheckMargin)
					{
						(ribbonDropDown2.Items[this.ribbonListViewItem_0.DropDown.SelectedIndex] as ToolStripMenuItem).Checked = true;
					}
					if (this.ribbonListViewItem_0.DropDown.ShowText)
					{
						ribbonDropDown2.Show(this, new Point(0, this.rectangle_1.Bottom), ToolStripDropDownDirection.BelowRight);
					}
					else
					{
						ribbonDropDown2.Show(this.ribbonListViewItem_0.RibbonListView_0, new Point(this.ribbonListViewItem_0.Rectangle_0.X, this.ribbonListViewItem_0.Rectangle_0.Bottom), ToolStripDropDownDirection.BelowRight);
					}
					ribbonDropDown2.ItemClicked += method_5;
				}
			}

			private void method_2()
			{
				if (this.bool_0)
				{
					this.visualStyleRenderer_1 = (this.ribbonListViewItem_0.RibbonListView_0.Enabled ? new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Hot) : new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Disabled));
				}
				else
				{
					this.visualStyleRenderer_1 = (this.ribbonListViewItem_0.RibbonListView_0.Enabled ? new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal) : new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Disabled));
				}
				base.Invalidate();
			}

			private void method_3(RibbonListViewItem ribbonListViewItem_1, string string_0)
			{
				ribbonListViewItem_1.DropDown.SelectedItem = string_0;
				if (this.ribbonListViewItem_0.RibbonListViewItem_0 != null)
				{
					this.ribbonListViewItem_0.RibbonListViewItem_0.DropDown.SelectedItem = string_0;
				}
				RibbonListViewItem ribbonListViewItem = ribbonListViewItem_1.RibbonListViewItem_0;
				if (ribbonListViewItem != null)
				{
					this.method_3(ribbonListViewItem, string_0);
				}
			}

			private void method_4(object sender, ToolStripDropDownClosedEventArgs e)
			{
				bool flag;
				RibbonListView ribbonListView = ((flag = this.ribbonListViewItem_0.RibbonListView_0.ribbonListView_1 != null) ? this.ribbonListViewItem_0.RibbonListView_0.ribbonListView_1 : this.ribbonListViewItem_0.RibbonListView_0);
				ribbonListView.method_23(flag ? this.ribbonListViewItem_0.RibbonListViewItem_0 : this.ribbonListViewItem_0);
			}

			private void method_5(object sender, ToolStripItemClickedEventArgs e)
			{
				int num = 0;
				string text;
				while (true)
				{
					if (num < this.ribbonListViewItem_0.DropDown.Items.Length)
					{
						text = this.ribbonListViewItem_0.DropDown.Items[num];
						if (text == e.ClickedItem.Text)
						{
							break;
						}
						num++;
						continue;
					}
					return;
				}
				this.method_3(this.ribbonListViewItem_0, text);
				base.Invalidate();
			}
		}

		private bool bool_0 = true;

		private bool bool_1;

		private bool bool_2;

		private int int_0 = 15;

		private int int_1;

		private bool bool_3;

		private PointF pointF_0 = PointF.Empty;

		private Color color_0;

		private ImageAttributes imageAttributes_0;

		private VisualStyleRenderer visualStyleRenderer_0;

		private RibbonDropDown ribbonDropDown_0;

		private Padding padding_0;

		private Padding padding_1;

		private int int_2;

		private int int_3;

		private int int_4;

		private int int_5;

		private int int_6;

		private bool bool_4 = true;

		private int int_7 = 1;

		private int int_8;

		private int int_9;

		private bool bool_5 = true;

		private RibbonItemCollection ribbonItemCollection_0;

		private RibbonListViewItem[] ribbonListViewItem_0;

		private bool bool_6;

		private bool bool_7;

		private string string_0 = string.Empty;

		private int? nullable_0 = null;

		private int? nullable_1 = null;

		private int int_10 = 1;

		private int int_11 = 1;

		private bool bool_8;

		private RibbonItemCollection ribbonItemCollection_1;

		private RibbonListViewItemCollection ribbonListViewItemCollection_0;

		private int int_12 = 1;

		private int int_13;

		private int[] int_14 = new int[0];

		private bool bool_9;

		private bool bool_10;

		private RibbonToolTip ribbonToolTip_0;

		private ListViewMode listViewMode_0 = ListViewMode.Icon;

		internal RibbonListView ribbonListView_0;

		private bool bool_11 = true;

		private bool bool_12;

		private bool bool_13;

		private bool bool_14;

		private bool bool_15;

		private RibbonListViewItem ribbonListViewItem_1;

		private RibbonListViewItem ribbonListViewItem_2;

		internal RibbonListViewItem ribbonListViewItem_3;

		private bool bool_16;

		private Class553 class553_0;

		private bool bool_17 = true;

		private bool bool_18;

		private RibbonGroup ribbonGroup_0;

		private RibbonListView ribbonListView_1;

		private RibbonListViewItem ribbonListViewItem_4;

		internal Class555 class555_0 = new Class555
		{
			Visible = false,
			Margin = new Padding(0),
			TextAlign = System.Windows.Forms.HorizontalAlignment.Left,
			Padding = new Padding(3)
		};

		private string string_1 = string.Empty;

		private float float_0 = 2f;

		private int int_15;

		private int int_16;

		[Obfuscation(Exclude = true)]
		private static readonly object DropDownClosedEvent = new object();

		[Obfuscation(Exclude = true)]
		private static readonly object DropDownOpeningEvent = new object();

		[Obfuscation(Exclude = true)]
		private static readonly object EventEditItemTextBoxActivated = new object();

		[Obfuscation(Exclude = true)]
		private static readonly object EventEditItemTextBoxDeactivated = new object();

		[Obfuscation(Exclude = true)]
		private static readonly object EventItemClick = new object();

		[Obfuscation(Exclude = true)]
		private static readonly object EventItemDropDownClosed = new object();

		[Obfuscation(Exclude = true)]
		private static readonly object EventItemDropDownOpening = new object();

		[Obfuscation(Exclude = true)]
		private static readonly object EventItemMouseDown = new object();

		[Obfuscation(Exclude = true)]
		private static readonly object EventItemMouseUp = new object();

		[Obfuscation(Exclude = true)]
		private static readonly object EventItemMouseEnter = new object();

		[Obfuscation(Exclude = true)]
		private static readonly object EventItemMouseLeave = new object();

		private PropertyChangedEventHandler propertyChangedEventHandler_0;

		[CompilerGenerated]
		private bool bool_19;

		/// <summary>Gets or sets the amount of space between the cell's item and the cell's border.</summary>
		[Category("Layout")]
		public Padding CellPadding
		{
			get
			{
				return this.padding_1;
			}
			set
			{
				if (!this.padding_1.Equals(value))
				{
					PointF pointF_ = (this.pointF_0.IsEmpty ? new PointF(96f, 96f) : this.pointF_0);
					this.padding_0 = Class517.smethod_51(this.padding_1 = value, pointF_);
					this.method_11(bool_20: false);
					this.vmethod_0("CellPadding");
				}
			}
		}

		/// <summary>Gets the number of columns in this RibbonListView.</summary>
		[Browsable(false)]
		public int ColumnCount => this.int_7;

		/// <summary>Gets the width, in 1/96 inch, for each column in this RibbonListView.</summary>
		[Browsable(false)]
		public int ColumnWidth
		{
			get
			{
				float num = (this.pointF_0.IsEmpty ? 96f : this.pointF_0.X);
				return (int)((float)this.int_8 * 96f / num);
			}
		}

		/// <summary>Gets or sets a value whether a selected RibbonListViewItem can be deselected by clicking into a cell that does not contain a RibbonListViewItem or clicking on it in combination with the pressed Ctrl key.</summary>
		[Category("Behavior")]
		[DefaultValue(true)]
		public bool Deselectable
		{
			get
			{
				return this.bool_5;
			}
			set
			{
				if (this.bool_5 != (this.bool_5 = value))
				{
					this.vmethod_0("Deselectable");
				}
			}
		}

		/// <summary>Gets the collection of controls in the drop-down menu that is associated with this RibbonListView.</summary>
		[Category("Behavior")]
		public RibbonItemCollection DropDownItems => this.ribbonItemCollection_0;

		/// <summary>Gets or sets a value, in 1/96 inch, specifying the width of the edit item text box for an item where no text is set.</summary>
		[Category("Behavior")]
		public int EditItemTextBoxEmptyWidth
		{
			get
			{
				return this.int_6;
			}
			set
			{
				if (this.int_6 != (this.int_6 = Math.Min(value, this.int_3)))
				{
					if (string.IsNullOrEmpty(this.class555_0.Text) && this.ribbonListViewItem_4 != null)
					{
						this.class555_0.Width = Class517.smethod_45(this.int_6, this.pointF_0.X);
					}
					this.vmethod_0("EditItemTextBoxEmptyWidth");
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether the RibbonListViewItems are displayed inside the RibbonListView or not.</summary>
		[DefaultValue(false)]
		[Category("Behavior")]
		public bool HideItems
		{
			get
			{
				return this.bool_6;
			}
			set
			{
				if (this.bool_6 != (this.bool_6 = value))
				{
					base.Invalidate();
					this.vmethod_0("HideItems");
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether the selected RibbonListViewItems are highlighted inside the RibbonListView or not.</summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		public bool HideSelectedItems
		{
			get
			{
				return this.bool_7;
			}
			set
			{
				if (this.bool_7 != (this.bool_7 = value))
				{
					base.Invalidate();
					this.vmethod_0("HideSelectedItems");
				}
			}
		}

		/// <summary>Gets or sets an array of RibbonListViewItems used to generate the content of this RibbonListView.</summary>
		[Category("Data")]
		[DefaultValue(null)]
		public RibbonListViewItem[] ItemsSource
		{
			get
			{
				return this.ribbonListViewItem_0;
			}
			set
			{
				if (this.method_31(value) && this.ribbonListView_1 == null)
				{
					this.method_11(bool_20: false);
					this.vmethod_0("ItemsSource");
				}
			}
		}

		/// <summary>Gets or sets the keyboard shortcut of the RibbonListView.</summary>
		[Attribute3("PROP_RIBBON_KEYTIP")]
		[Category("Behavior")]
		public string KeyTip
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}

		/// <summary>Gets or sets a value specifying the maximum number of columns in this RibbonListView.</summary>
		[Category("Behavior")]
		[DefaultValue(null)]
		public int? MaxColumnCount
		{
			get
			{
				return this.nullable_1;
			}
			set
			{
				if (this.nullable_1 != (this.nullable_1 = value))
				{
					this.method_11(bool_20: true);
					this.vmethod_0("MaxColumnCount");
				}
			}
		}

		/// <summary>Gets or sets a value, in 1/96 inch, specifying the maximum column width in this RibbonListView.</summary>
		[Category("Behavior")]
		[DefaultValue(null)]
		public int MaxColumnWidth
		{
			get
			{
				return this.int_3;
			}
			set
			{
				float num = (this.pointF_0.IsEmpty ? 96f : this.pointF_0.X);
				bool flag = this.int_3 != (this.int_3 = value);
				bool flag2 = false;
				if ((this.int_2 = Class517.smethod_45(this.int_3, num)) < this.int_8)
				{
					if (flag2 = this.int_3 < this.int_4)
					{
						this.int_4 = this.int_3;
					}
					this.method_11(bool_20: false);
				}
				if (flag)
				{
					this.vmethod_0("MaxColumnWidth");
					if (flag2)
					{
						this.vmethod_0("MinColumnWidth");
					}
					if (this.int_3 < this.int_6)
					{
						this.EditItemTextBoxEmptyWidth = this.int_3;
					}
				}
			}
		}

		/// <summary>Gets or sets a value specifying the maximum number of rows that are displayed by the RibbonListView.</summary>
		[Category("Behavior")]
		[DefaultValue(null)]
		public int? MaxVisibleRows
		{
			get
			{
				return this.nullable_0;
			}
			set
			{
				if (this.nullable_0 != (this.nullable_0 = value))
				{
					this.method_11(bool_20: false);
					this.vmethod_0("MaxVisibleRows");
				}
			}
		}

		/// <summary>Gets or sets the minimum number of columns in this RibbonListView.</summary>
		[Category("Behavior")]
		[DefaultValue(1)]
		public int MinColumnCount
		{
			get
			{
				return this.int_10;
			}
			set
			{
				if (this.int_10 != (this.int_10 = value))
				{
					this.method_11(bool_20: false);
					this.vmethod_0("MinColumnCount");
				}
			}
		}

		/// <summary>Gets or sets the minimum width, in 1/96 inch, of a column.</summary>
		public int MinColumnWidth
		{
			get
			{
				return this.int_4;
			}
			set
			{
				int num = this.int_4;
				int num2 = Math.Min(value, this.int_3);
				if (this.int_4 != (this.int_4 = num2))
				{
					if (this.int_4 > num)
					{
						this.method_11(bool_20: true);
					}
					this.vmethod_0("MinColumnWidth");
				}
			}
		}

		/// <summary>Gets or sets the minimum width, in 1/96 inch, of the RibbonListView.</summary>
		public int MinimumWidth
		{
			get
			{
				return this.int_5;
			}
			set
			{
				int num = this.int_5;
				if (this.int_5 != (this.int_5 = value))
				{
					if (this.int_5 > num)
					{
						this.method_11(bool_20: true);
					}
					this.vmethod_0("MinimumWidth");
				}
			}
		}

		/// <summary>Gets or sets the minimum number of rows in this RibbonListView.</summary>
		[Category("Behavior")]
		[DefaultValue(1)]
		public int MinRowCount
		{
			get
			{
				return this.int_11;
			}
			set
			{
				if (this.int_11 != (this.int_11 = value))
				{
					this.method_11(bool_20: false);
					this.vmethod_0("MinColumnCount");
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether multiple items can be selected.</summary>
		[DefaultValue(false)]
		[Category("Behavior")]
		public bool MultiSelect
		{
			get
			{
				return this.bool_8;
			}
			set
			{
				if (this.bool_8 != (this.bool_8 = value))
				{
					this.vmethod_0("MultiSelect");
				}
			}
		}

		/// <summary>Gets the RibbonItemCollection that contains this RibbonListView.</summary>
		[Category("Behavior")]
		public RibbonItemCollection ParentCollection
		{
			get
			{
				return this.ribbonItemCollection_1;
			}
			internal set
			{
				this.ribbonItemCollection_1 = value;
			}
		}

		/// <summary>Gets a collection containing all items in this RibbonListView.</summary>
		[Category("Behavior")]
		public RibbonListViewItemCollection RibbonListViewItems => this.ribbonListViewItemCollection_0;

		/// <summary>Gets the number of rows in this RibbonListView.</summary>
		[Browsable(false)]
		public int RowCount => this.int_12;

		/// <summary>Gets the height, in 1/96 inch, for each row in this RibbonListView.</summary>
		[Browsable(false)]
		public int RowHeight
		{
			get
			{
				float num = (this.pointF_0.IsEmpty ? 96f : this.pointF_0.Y);
				return (int)((float)this.int_13 * num / 96f);
			}
		}

		/// <summary>Gets or sets a value whether the scroll bars buttons should be displayed or not.</summary>
		[Category("Appearance")]
		[DefaultValue(false)]
		public bool ScrollButtonsVisible
		{
			get
			{
				return this.class553_0.Boolean_3;
			}
			set
			{
				bool boolean_ = this.class553_0.Boolean_3;
				bool flag2 = (this.class553_0.Boolean_3 = value);
				if (boolean_ != flag2)
				{
					this.method_11(bool_20: false);
					base.Invalidate();
					this.vmethod_0("ScrollButtonsVisible");
				}
			}
		}

		/// <summary>Gets or sets the indexes of the selected items in this RibbonListView.</summary>
		[Browsable(false)]
		public int[] SelectedIndices
		{
			get
			{
				return this.int_14;
			}
			set
			{
				if (this.method_0(value) && this.ribbonListView_1 == null)
				{
					base.Invalidate();
					this.vmethod_0("SelectedIndices");
					this.vmethod_0("SelectedItems");
				}
			}
		}

		/// <summary>Gets or sets the items that are selected in this RibbonListView.</summary>
		[Browsable(false)]
		public RibbonListViewItem[] SelectedItems
		{
			get
			{
				RibbonListViewItem[] array = new RibbonListViewItem[this.int_14.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = this.ribbonListViewItemCollection_0[this.int_14[i]];
				}
				return array;
			}
			set
			{
				if (this.method_1(value) && this.ribbonListView_1 == null)
				{
					base.Invalidate();
					this.vmethod_0("SelectedIndices");
					this.vmethod_0("SelectedItems");
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether an item is set to selected after choosing it by using arrow keys.</summary>
		public bool SelectWithArrowKeys
		{
			get
			{
				return this.bool_3;
			}
			set
			{
				if (this.bool_3 != (this.bool_3 = value))
				{
					this.vmethod_0("SelectWithArrowKeys");
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether this RibbonListView is surrounded by a border or not.</summary>
		[Category("Appearance")]
		[DefaultValue(false)]
		public bool ShowBorder
		{
			get
			{
				return this.bool_9;
			}
			set
			{
				if (this.bool_9 != (this.bool_9 = value))
				{
					base.Invalidate();
					this.vmethod_0("ShowBorder");
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether this RibbonListView's drop down menu displays additionally to the drop down items the control's RibbonListViewItems or not.</summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		public bool ShowItemsInDropDown
		{
			get
			{
				return this.bool_10;
			}
			set
			{
				if (this.bool_10 != (this.bool_10 = value))
				{
					this.method_11(bool_20: false);
					base.Invalidate();
					this.vmethod_0("ShowItemsInDropDown");
				}
			}
		}

		/// <summary>Gets an object of type RibbonToolTip that displays text when the mouse pointer hovers over RibbonListView's scroll bar or drop-down button.</summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Category("Misc")]
		public RibbonToolTip ToolTip => this.ribbonToolTip_0;

		/// <summary>Gets or sets the mode in which this RibbonListView displays its items.</summary>
		[DefaultValue(ListViewMode.Icon)]
		[Category("Appearance")]
		public ListViewMode ViewMode
		{
			get
			{
				return this.listViewMode_0;
			}
			set
			{
				if (this.listViewMode_0 != (this.listViewMode_0 = value))
				{
					this.bool_11 = (this.listViewMode_0 & ListViewMode.Icon) == ListViewMode.Icon;
					this.bool_12 = (this.listViewMode_0 & ListViewMode.Text) == ListViewMode.Text;
					this.bool_13 = (this.listViewMode_0 & ListViewMode.DropDown) == ListViewMode.DropDown;
					this.method_11(bool_20: false);
					this.vmethod_0("ViewMode");
				}
			}
		}

		private Padding Padding_0 => this.padding_0;

		private RibbonListViewItem RibbonListViewItem_0 => this.ribbonListViewItem_1;

		private bool Boolean_0 => this.bool_15;

		private bool Boolean_1
		{
			get
			{
				return this.bool_12;
			}
			set
			{
				this.bool_12 = value;
			}
		}

		private bool Boolean_2
		{
			get
			{
				return this.bool_11;
			}
			set
			{
				this.bool_11 = value;
			}
		}

		internal bool Boolean_3
		{
			get
			{
				if (!this.bool_16)
				{
					return this.bool_4;
				}
				return this.ribbonListView_1.Boolean_3;
			}
			set
			{
				if (this.bool_16)
				{
					this.ribbonListView_1.Boolean_3 = value;
				}
				else
				{
					this.bool_4 = value;
				}
			}
		}

		internal RibbonListViewItem RibbonListViewItem_1
		{
			get
			{
				return this.ribbonListViewItem_3;
			}
			set
			{
				this.ribbonListViewItem_3 = value;
			}
		}

		internal bool Boolean_4
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				this.bool_2 = value;
			}
		}

		internal bool Boolean_5
		{
			get
			{
				return this.bool_16;
			}
			set
			{
				this.bool_16 = value;
			}
		}

		internal Class553 Class553_0 => this.class553_0;

		public new Color DefaultBackColor => Color.Transparent;

		protected override Size DefaultMinimumSize => new Size(1, 1);

		protected override Size DefaultSize => new Size(1, 1);

		public new bool Enabled
		{
			get
			{
				if (this.bool_17)
				{
					return base.Enabled;
				}
				return false;
			}
			set
			{
				base.Enabled = value;
			}
		}

		public override Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				Color foreColor = base.ForeColor;
				Color color2 = (base.ForeColor = value);
				if (foreColor != color2)
				{
					this.color_0 = ((this.int_1 == 0) ? value : ControlPaint.LightLight(value));
				}
			}
		}

		public new bool Visible
		{
			get
			{
				return base.Visible;
			}
			set
			{
				bool internalVisible = (base.Visible = value);
				((IRibbonItem)this).InternalVisible = internalVisible;
			}
		}

		PointF IRibbonItem.DPI => this.pointF_0;

		bool IRibbonItem.HasSmallIcon
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		bool IRibbonItem.HasLargeIcon
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		bool IRibbonItem.InternalVisible
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				if (this.bool_0 == (this.bool_0 = value))
				{
					return;
				}
				if (!((IRibbonItem)this).IsRibbonDropDownItem)
				{
					Class517.smethod_25(this.ribbonGroup_0);
				}
				if (this.ribbonGroup_0 != null && this.ribbonGroup_0.Boolean_0)
				{
					return;
				}
				foreach (Control item in this.ribbonItemCollection_0)
				{
					RibbonButton ribbonButton = item as RibbonButton;
					if (ribbonButton != null)
					{
						((IRibbonItem)ribbonButton).OwnerEnabled = value;
					}
				}
			}
		}

		bool IRibbonItem.IsDefaultRibbonTabItem
		{
			[CompilerGenerated]
			get
			{
				return this.bool_19;
			}
			[CompilerGenerated]
			set
			{
				this.bool_19 = value;
			}
		}

		bool IRibbonItem.IsRibbonDropDownItem
		{
			get
			{
				return this.bool_14;
			}
			set
			{
				this.bool_14 = value;
			}
		}

		bool IRibbonItem.IsUpdatingItemEnabled
		{
			get
			{
				return this.bool_18;
			}
			set
			{
				if (this.bool_18 = value)
				{
					this.method_12(bool_20: true);
				}
			}
		}

		bool IRibbonItem.OwnerEnabled
		{
			get
			{
				return this.bool_17;
			}
			set
			{
				if (this.bool_17 != (this.bool_17 = value))
				{
					this.method_17();
				}
			}
		}

		RibbonGroup IRibbonItem.RibbonGroup
		{
			get
			{
				return this.ribbonGroup_0;
			}
			set
			{
				if (this.ribbonGroup_0 != (this.ribbonGroup_0 = value) && this.ribbonGroup_0 != null)
				{
					base.Font = this.ribbonGroup_0.Font;
					((IRibbonItem)this).IsUpdatingItemEnabled = true;
				}
			}
		}

		IRibbonItem IContentItem.Original
		{
			get
			{
				return this.ribbonListView_1;
			}
			set
			{
				this.ribbonListView_1 = (RibbonListView)value;
			}
		}

		bool IEnabledItem.Enabled
		{
			get
			{
				return this.Enabled;
			}
			set
			{
				this.Enabled = value;
			}
		}

		/// <summary>Occurs as the RibbonListView's drop-down menu is closed.</summary>
		public event EventHandler DropDownClosed
		{
			add
			{
				base.Events.AddHandler(RibbonListView.DropDownClosedEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(RibbonListView.DropDownClosedEvent, value);
			}
		}

		/// <summary>Occurs as the RibbonListView's drop-down menu is opening.</summary>
		public event EventHandler DropDownOpening
		{
			add
			{
				base.Events.AddHandler(RibbonListView.DropDownOpeningEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(RibbonListView.DropDownOpeningEvent, value);
			}
		}

		/// <summary>Occurs when the edit item text box is displayed.</summary>
		public event EditItemTextBoxActivatedEventHandler EditItemTextBoxActivated
		{
			add
			{
				base.Events.AddHandler(RibbonListView.EventEditItemTextBoxActivated, value);
			}
			remove
			{
				base.Events.RemoveHandler(RibbonListView.EventEditItemTextBoxActivated, value);
			}
		}

		/// <summary>Occurs when the edit item text box is closed.</summary>
		public event EditItemTextBoxDeactivatedEventHandler EditItemTextBoxDeactivated
		{
			add
			{
				base.Events.AddHandler(RibbonListView.EventEditItemTextBoxDeactivated, value);
			}
			remove
			{
				base.Events.RemoveHandler(RibbonListView.EventEditItemTextBoxDeactivated, value);
			}
		}

		/// <summary>Occurs when an RibbonListViewItem is clicked.</summary>
		public event ItemClickedEventHandler ItemClick
		{
			add
			{
				base.Events.AddHandler(RibbonListView.EventItemClick, value);
			}
			remove
			{
				base.Events.RemoveHandler(RibbonListView.EventItemClick, value);
			}
		}

		/// <summary>Occurs as a RibbonListViewItem's drop-down menu is closed.</summary>
		public event ItemDropDownClosedEventHandler ItemDropDownClosed
		{
			add
			{
				base.Events.AddHandler(RibbonListView.EventItemDropDownClosed, value);
			}
			remove
			{
				base.Events.RemoveHandler(RibbonListView.EventItemDropDownClosed, value);
			}
		}

		/// <summary>Occurs as a RibbonListViewItem's drop-down menu is opening.</summary>
		public event ItemDropDownOpeningEventHandler ItemDropDownOpening
		{
			add
			{
				base.Events.AddHandler(RibbonListView.EventItemDropDownOpening, value);
			}
			remove
			{
				base.Events.RemoveHandler(RibbonListView.EventItemDropDownOpening, value);
			}
		}

		/// <summary>Occurs when the mouse pointer is over a RibbonListViewItem and the mouse button is pressed.</summary>
		public event ItemMouseDownEventHandler ItemMouseDown
		{
			add
			{
				base.Events.AddHandler(RibbonListView.EventItemMouseDown, value);
			}
			remove
			{
				base.Events.RemoveHandler(RibbonListView.EventItemMouseDown, value);
			}
		}

		/// <summary>Occurs when the mouse pointer is over a RibbonListViewItem and the mouse button is released.</summary>
		public event ItemMouseUpEventHandler ItemMouseUp
		{
			add
			{
				base.Events.AddHandler(RibbonListView.EventItemMouseUp, value);
			}
			remove
			{
				base.Events.RemoveHandler(RibbonListView.EventItemMouseUp, value);
			}
		}

		/// <summary>Occurs when the mouse pointer enters a RibbonListViewItem.</summary>
		public event ItemMouseEnterEventHandler ItemMouseEnter
		{
			add
			{
				base.Events.AddHandler(RibbonListView.EventItemMouseEnter, value);
			}
			remove
			{
				base.Events.RemoveHandler(RibbonListView.EventItemMouseEnter, value);
			}
		}

		/// <summary>Occurs when the mouse pointer leaves a RibbonListViewItem.</summary>
		public event ItemMouseLeaveEventHandler ItemMouseLeave
		{
			add
			{
				base.Events.AddHandler(RibbonListView.EventItemMouseLeave, value);
			}
			remove
			{
				base.Events.RemoveHandler(RibbonListView.EventItemMouseLeave, value);
			}
		}

		public event PropertyChangedEventHandler PropertyChanged
		{
			add
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChangedEventHandler_0;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange(ref this.propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
				}
				while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
			}
			remove
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChangedEventHandler_0;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange(ref this.propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
				}
				while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
			}
		}

		/// <summary>Initializes a new instance of the RibbonListView class.</summary>
		public RibbonListView()
		{
			try
			{
				this.visualStyleRenderer_0 = new VisualStyleRenderer(VisualStyleElement.Button.GroupBox.Normal);
			}
			catch
			{
			}
			base.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			this.padding_1 = Class519.Class529.Padding_0;
			this.int_3 = Class519.Class529.Int32_3;
			this.ribbonItemCollection_0 = new RibbonItemCollection(this);
			this.class553_0 = new Class553(this);
			base.BackColor = this.DefaultBackColor;
			this.color_0 = base.ForeColor;
			this.ribbonListViewItemCollection_0 = new RibbonListViewItemCollection(this);
			base.AutoSize = true;
			this.ribbonToolTip_0 = new RibbonToolTip(this);
			this.class555_0.KeyDown += class555_0_KeyDown;
		}

		private bool method_0(int[] int_17)
		{
			if (int_17 == null)
			{
				throw new ArgumentNullException();
			}
			int[] array = this.int_14;
			bool flag = int_17.Length != array.Length;
			this.method_10();
			Array.Sort(int_17);
			int num = 0;
			while (true)
			{
				if (num < int_17.Length)
				{
					int num2 = int_17[num];
					if (0 <= num2 && num2 < this.ribbonListViewItemCollection_0.Count)
					{
						this.ribbonListViewItemCollection_0[num2].method_2(bool_3: true);
						flag = ((!flag) ? (num2 != array[num]) : flag);
						num++;
						continue;
					}
					throw new ArgumentOutOfRangeException();
				}
				this.int_14 = int_17;
				if (flag)
				{
					this.Refresh();
				}
				break;
			}
			return flag;
		}

		private bool method_1(RibbonListViewItem[] ribbonListViewItem_5)
		{
			if (ribbonListViewItem_5 == null)
			{
				throw new ArgumentNullException();
			}
			int[] array = this.int_14;
			this.method_10();
			this.int_14 = new int[ribbonListViewItem_5.Length];
			int num = 0;
			bool flag;
			while (true)
			{
				if (num < ribbonListViewItem_5.Length)
				{
					RibbonListViewItem ribbonListViewItem = ribbonListViewItem_5[num];
					if ((this.int_14[num] = this.ribbonListViewItemCollection_0.method_0(ribbonListViewItem)) != -1)
					{
						ribbonListViewItem.method_2(bool_3: true);
						num++;
						continue;
					}
					throw new ArgumentException();
				}
				Array.Sort(this.int_14);
				if (flag = array.Length != this.int_14.Length)
				{
					break;
				}
				for (int i = 0; i < this.int_14.Length; i++)
				{
					if (flag)
					{
						break;
					}
					flag = this.int_14[i] != array[i];
				}
				break;
			}
			return flag;
		}

		private bool method_2(Point point_0, bool bool_20)
		{
			bool result = false;
			if (!this.method_7(point_0, out var ribbonListViewItem_, out var _))
			{
				for (int i = 0; i < this.ribbonListViewItemCollection_0.Count; i++)
				{
					RibbonListViewItem ribbonListViewItem = this.ribbonListViewItemCollection_0[i];
					if (ribbonListViewItem.Rectangle_0.Contains(point_0))
					{
						bool result2;
						if ((result2 = this.method_4(ribbonListViewItem, bool_20)) && this.ribbonListView_1 != null)
						{
							this.method_5();
						}
						return result2;
					}
				}
				if ((!this.bool_8 && this.bool_5) || (this.bool_8 && this.bool_5 && !bool_20))
				{
					result = this.int_14.Length != 0;
					this.method_10();
				}
			}
			else
			{
				result = this.method_6(ribbonListViewItem_, bool_20);
			}
			base.Invalidate();
			if (this.ribbonListView_1 != null)
			{
				this.ribbonListView_1.Invalidate();
			}
			return result;
		}

		private bool method_3(bool bool_20)
		{
			bool flag = false;
			if (!this.ribbonListViewItem_2.IsSelected)
			{
				return this.method_4(this.ribbonListViewItem_2, bool_20);
			}
			flag = this.method_6(this.ribbonListViewItem_2, bool_20);
			base.Invalidate();
			if (this.ribbonListView_1 != null)
			{
				this.ribbonListView_1.Invalidate();
			}
			return flag;
		}

		private bool method_4(RibbonListViewItem ribbonListViewItem_5, bool bool_20)
		{
			int[] int_ = ((!this.bool_8 || !bool_20) ? new int[1] { ribbonListViewItem_5.Int32_1 } : this.method_8(this.int_14, ribbonListViewItem_5.Int32_1));
			bool result = this.method_0(int_);
			this.ribbonListViewItem_2 = ribbonListViewItem_5;
			base.Invalidate();
			if (this.ribbonListView_1 != null)
			{
				this.ribbonListView_1.Invalidate();
			}
			return result;
		}

		private void method_5()
		{
			if (this.ribbonListView_1 != null)
			{
				if (this.ribbonListView_1.method_0(this.int_14))
				{
					this.ribbonListView_1.vmethod_0("SelectedIndices");
					this.ribbonListView_1.vmethod_0("SelectedItems");
				}
			}
			else
			{
				this.vmethod_0("SelectedIndices");
				this.vmethod_0("SelectedItems");
			}
		}

		private bool method_6(RibbonListViewItem ribbonListViewItem_5, bool bool_20)
		{
			this.ribbonListViewItem_2 = ribbonListViewItem_5;
			if (this.bool_8)
			{
				if (bool_20)
				{
					this.method_9(this.ribbonListViewItem_2);
					return false;
				}
				return this.method_0(new int[1] { this.ribbonListViewItem_2.Int32_1 });
			}
			if (bool_20 && this.bool_5)
			{
				this.method_9(this.ribbonListViewItem_2);
				return true;
			}
			return false;
		}

		private bool method_7(Point point_0, out RibbonListViewItem ribbonListViewItem_5, out int int_17)
		{
			int[] array = this.int_14;
			int num = 0;
			int num2;
			while (true)
			{
				if (num < array.Length)
				{
					num2 = array[num];
					if (this.ribbonListViewItemCollection_0[num2].Rectangle_0.Contains(point_0))
					{
						break;
					}
					num++;
					continue;
				}
				ribbonListViewItem_5 = null;
				int_17 = -1;
				return false;
			}
			int_17 = num2;
			ribbonListViewItem_5 = this.ribbonListViewItemCollection_0[num2];
			return true;
		}

		private int[] method_8(int[] int_17, int int_18)
		{
			int[] array = new int[int_17.Length + 1];
			for (int i = 0; i < int_17.Length; i++)
			{
				array[i] = int_17[i];
			}
			array[int_17.Length] = int_18;
			return array;
		}

		private void method_9(RibbonListViewItem ribbonListViewItem_5)
		{
			ribbonListViewItem_5.method_2(bool_3: false);
			int[] array = new int[this.int_14.Length - 1];
			int num = 0;
			for (int i = 0; i < this.int_14.Length; i++)
			{
				int num2 = this.int_14[i];
				if (this.ribbonListViewItemCollection_0[num2] != ribbonListViewItem_5)
				{
					array[num] = num2;
					num++;
				}
			}
			this.int_14 = array;
			if (this.ribbonListView_1 != null)
			{
				this.ribbonListView_1.method_0(this.int_14);
			}
		}

		private void method_10()
		{
			foreach (RibbonListViewItem item in this.ribbonListViewItemCollection_0)
			{
				item.method_2(bool_3: false);
			}
			this.int_14 = new int[0];
		}

		internal void method_11(bool bool_20)
		{
			if (!this.pointF_0.IsEmpty && !base.IsDisposed && !this.bool_16 && this.bool_18)
			{
				bool[] array = this.method_13();
				bool[] array2 = this.method_16();
				this.class553_0.method_6();
				this.method_14();
				if (this.ribbonItemCollection_0.Count > 0)
				{
					this.class553_0.Boolean_4 = true;
				}
				if ((array2[0] || bool_20) && this.ribbonGroup_0 != null && !this.bool_14 && this.ribbonListView_1 == null)
				{
					this.ribbonGroup_0.method_2();
				}
				base.Invalidate();
				if (array[0])
				{
					this.vmethod_0("ColumnWidth");
				}
				if (array[1])
				{
					this.vmethod_0("RowHeight");
				}
				if (array2[2])
				{
					this.vmethod_0("ColumnCount");
				}
				if (array2[3])
				{
					this.vmethod_0("RowCount");
				}
			}
		}

		private void method_12(bool bool_20)
		{
			this.bool_15 = (this.ribbonGroup_0 != null && this.ribbonGroup_0.RightToLeft == RightToLeft.Yes) || this.RightToLeft == RightToLeft.Yes;
			foreach (RibbonListViewItem item in this.ribbonListViewItemCollection_0)
			{
				item.method_4();
			}
			this.method_11(bool_20);
		}

		private bool[] method_13()
		{
			int num = 0;
			Graphics graphics = base.CreateGraphics();
			int num2 = (this.bool_12 ? TextRenderer.MeasureText(graphics, "X", this.Font, new Size(1, 1), TextFormatFlags.NoPrefix | TextFormatFlags.VerticalCenter).Height : 0);
			graphics.Dispose();
			foreach (RibbonListViewItem item in this.ribbonListViewItemCollection_0)
			{
				item.Boolean_0 = this.bool_13;
				if (num < item.Size_0.Width)
				{
					num = item.Size_0.Width;
				}
				if (num2 < item.Size_0.Height)
				{
					num2 = item.Size_0.Height;
				}
			}
			int val = Class517.smethod_45(this.int_4, this.pointF_0.X);
			bool flag = this.int_8 != (this.int_8 = Math.Max(num + this.padding_0.Horizontal, val));
			bool flag2 = this.int_13 != (this.int_13 = num2 + this.padding_0.Vertical);
			return new bool[2] { flag, flag2 };
		}

		private void method_14()
		{
			if (this.ribbonListViewItemCollection_0.Count <= 0)
			{
				return;
			}
			int num = 0;
			int num2 = (this.bool_15 ? (this.int_15 - this.int_8) : 0);
			int num3 = -this.class553_0.Int32_0 * this.int_13;
			int num4 = 0;
			int num5 = 0;
			for (int i = 0; i < this.ribbonListViewItemCollection_0.Count; i++)
			{
				RibbonListViewItem ribbonListViewItem = this.ribbonListViewItemCollection_0[i];
				ribbonListViewItem.Int32_1 = i;
				int num6 = (this.bool_15 ? (num2 + (this.int_8 - ribbonListViewItem.Size_0.Width - this.padding_0.Left)) : (num2 + this.padding_0.Left));
				ribbonListViewItem.Point_0 = new Point(num6, num3 + this.padding_0.Top);
				ribbonListViewItem.Rectangle_0 = new Rectangle(num2, num3, this.int_8, this.int_13);
				ribbonListViewItem.Int32_0 = num4;
				ribbonListViewItem.Int32_2 = num5;
				this.int_12 = num5 + 1;
				num++;
				if (num == this.int_7)
				{
					num = 0;
					num2 = (this.bool_15 ? (this.int_15 - this.int_8) : 0);
					num3 += this.int_13;
					num4 = 0;
					num5++;
				}
				else
				{
					num2 += (this.bool_15 ? (-this.int_8) : this.int_8);
					num4++;
				}
			}
		}

		private void method_15(int int_17, int int_18, int int_19)
		{
			this.int_7 = int_18;
			int num = this.int_8 * this.int_7;
			int num2 = num / this.int_8;
			this.int_12 = ((this.ribbonListViewItemCollection_0.Count <= 0) ? 1 : ((this.ribbonListViewItemCollection_0.Count % num2 != 0) ? (this.ribbonListViewItemCollection_0.Count / num2 + 1) : (this.ribbonListViewItemCollection_0.Count / num2)));
			int num3 = ((this.int_12 > this.int_0) ? (this.int_13 * this.int_0) : (this.int_13 * this.int_12));
			base.Size = new Size(int_17, num3);
			this.method_14();
			if (this.int_12 > this.int_0)
			{
				this.class553_0.Boolean_4 = true;
				this.nullable_0 = this.int_0;
				this.class553_0.method_6();
				int number = ((int_19 > this.int_12 - this.int_0) ? (this.int_12 - this.int_0) : int_19);
				this.ScrollTo(this.ribbonListViewItemCollection_0[number]);
				this.class553_0.method_5();
			}
			else
			{
				this.class553_0.Boolean_4 = false;
				this.class553_0.bool_4 = false;
				this.nullable_0 = null;
			}
		}

		private bool[] method_16()
		{
			int num = this.int_15;
			int num2 = this.int_16;
			bool flag;
			bool flag2;
			bool flag3;
			if (this.ribbonListViewItemCollection_0.Count > 0)
			{
				int num3 = Math.Max(this.int_15, this.int_8 * this.int_10);
				int num4 = (this.nullable_1.HasValue ? Math.Min(num3 / this.int_8, this.nullable_1.Value) : (num3 / this.int_8));
				int num5 = ((this.ribbonListViewItemCollection_0.Count % num4 != 0) ? (this.ribbonListViewItemCollection_0.Count / num4 + 1) : (this.ribbonListViewItemCollection_0.Count / num4));
				if ((this.class553_0.Boolean_3 && this.nullable_0.HasValue && num5 > this.nullable_0) || this.class553_0.Boolean_0)
				{
					int num6 = Math.Max(Math.Max(this.int_15 - this.class553_0.Int32_1, num3 - this.class553_0.Int32_1), this.int_8 * this.int_10);
					int num7 = (this.nullable_1.HasValue ? Math.Min(num6 / this.int_8, this.nullable_1.Value) : (num6 / this.int_8));
					int num8 = ((this.ribbonListViewItemCollection_0.Count % num7 != 0) ? (this.ribbonListViewItemCollection_0.Count / num7 + 1) : (this.ribbonListViewItemCollection_0.Count / num7));
					bool boolean_ = this.class553_0.Boolean_4;
					this.class553_0.Boolean_4 = true;
					flag = !boolean_;
					flag2 = this.int_7 != (this.int_7 = num7);
					flag3 = this.int_12 != (this.int_12 = num8);
					num = num6 + this.class553_0.Int32_1;
				}
				else
				{
					bool boolean_2 = this.class553_0.Boolean_4;
					this.class553_0.Boolean_4 = false;
					flag = boolean_2;
					flag2 = this.int_7 != (this.int_7 = num4);
					flag3 = this.int_12 != (this.int_12 = num5);
					num = num3;
				}
				num2 = (this.nullable_0.HasValue ? (this.int_13 * this.nullable_0.Value) : (this.int_13 * this.int_12));
			}
			else
			{
				num = this.int_10 * Class517.smethod_45(this.int_4, this.pointF_0.X) + this.class553_0.Int32_1;
				int num9 = this.int_7;
				this.int_7 = 0;
				flag2 = num9 != 0;
				int num10 = this.int_12;
				this.int_12 = 0;
				flag3 = num10 != 0;
				bool boolean_3 = this.class553_0.Boolean_4;
				this.class553_0.Boolean_4 = false;
				flag = boolean_3;
			}
			num = Math.Max(Class517.smethod_45(this.int_5, this.pointF_0.X), num);
			bool flag4 = this.int_15 != num;
			bool flag5 = this.int_16 != num2;
			this.bool_18 = false;
			base.Size = new Size(num, Math.Max(this.int_11 * this.int_13, num2));
			this.bool_18 = true;
			if (flag2)
			{
				this.class553_0.Int32_0 = 0;
			}
			return new bool[5] { flag4, flag5, flag2, flag3, flag };
		}

		private void method_17()
		{
			this.int_1 = ((!this.Enabled) ? 65 : 0);
			this.color_0 = ((this.int_1 == 0) ? this.ForeColor : ControlPaint.LightLight(this.ForeColor));
			this.imageAttributes_0 = Class517.smethod_20(this.int_1);
			foreach (Control item in this.ribbonItemCollection_0)
			{
				(item as IRibbonItem).OwnerEnabled = this.Enabled;
			}
		}

		internal void method_18()
		{
			EventHandler eventHandler = (EventHandler)base.Events[RibbonListView.DropDownClosedEvent];
			if (eventHandler != null)
			{
				EventArgs e = new EventArgs();
				eventHandler(this, e);
			}
		}

		internal void method_19()
		{
			EventHandler eventHandler = (EventHandler)base.Events[RibbonListView.DropDownOpeningEvent];
			if (eventHandler != null)
			{
				EventArgs e = new EventArgs();
				eventHandler(this, e);
			}
		}

		internal void method_20(RibbonListViewItem ribbonListViewItem_5, Enum137 enum137_0)
		{
			EditItemTextBoxActivatedEventHandler editItemTextBoxActivatedEventHandler = (EditItemTextBoxActivatedEventHandler)base.Events[RibbonListView.EventEditItemTextBoxActivated];
			if (editItemTextBoxActivatedEventHandler != null)
			{
				RibbonListViewItemEventArgs ribbonListViewItemEventArgs = new RibbonListViewItemEventArgs(ribbonListViewItem_5);
				ribbonListViewItemEventArgs.Enum137_0 = enum137_0;
				RibbonListView sender = (this.bool_16 ? this.ribbonListView_1 : this);
				editItemTextBoxActivatedEventHandler(sender, ribbonListViewItemEventArgs);
			}
		}

		internal void method_21(RibbonListViewItem ribbonListViewItem_5, Enum137 enum137_0)
		{
			EditItemTextBoxDeactivatedEventHandler editItemTextBoxDeactivatedEventHandler = (EditItemTextBoxDeactivatedEventHandler)base.Events[RibbonListView.EventEditItemTextBoxDeactivated];
			if (editItemTextBoxDeactivatedEventHandler != null)
			{
				RibbonListViewItemEventArgs ribbonListViewItemEventArgs = new RibbonListViewItemEventArgs(ribbonListViewItem_5);
				ribbonListViewItemEventArgs.Enum137_0 = enum137_0;
				RibbonListView sender = (this.bool_16 ? this.ribbonListView_1 : this);
				editItemTextBoxDeactivatedEventHandler(sender, ribbonListViewItemEventArgs);
			}
		}

		internal void method_22(RibbonListViewItem ribbonListViewItem_5)
		{
			if (!this.bool_6)
			{
				ItemClickedEventHandler itemClickedEventHandler = (ItemClickedEventHandler)base.Events[RibbonListView.EventItemClick];
				if (itemClickedEventHandler != null)
				{
					RibbonListViewItemEventArgs e = new RibbonListViewItemEventArgs(ribbonListViewItem_5);
					RibbonListView sender = (this.bool_16 ? this.ribbonListView_1 : this);
					itemClickedEventHandler(sender, e);
				}
			}
		}

		internal void method_23(RibbonListViewItem ribbonListViewItem_5)
		{
			if (!this.bool_6)
			{
				ItemDropDownClosedEventHandler itemDropDownClosedEventHandler = (ItemDropDownClosedEventHandler)base.Events[RibbonListView.EventItemDropDownClosed];
				if (itemDropDownClosedEventHandler != null)
				{
					RibbonListViewItemEventArgs e = new RibbonListViewItemEventArgs(ribbonListViewItem_5);
					RibbonListView sender = (this.bool_16 ? this.ribbonListView_1 : this);
					itemDropDownClosedEventHandler(sender, e);
				}
			}
		}

		internal void method_24(RibbonListViewItem ribbonListViewItem_5)
		{
			if (!this.bool_6)
			{
				ItemDropDownOpeningEventHandler itemDropDownOpeningEventHandler = (ItemDropDownOpeningEventHandler)base.Events[RibbonListView.EventItemDropDownOpening];
				if (itemDropDownOpeningEventHandler != null)
				{
					RibbonListViewItemEventArgs e = new RibbonListViewItemEventArgs(ribbonListViewItem_5);
					RibbonListView sender = (this.bool_16 ? this.ribbonListView_1 : this);
					itemDropDownOpeningEventHandler(sender, e);
				}
			}
		}

		internal void method_25(RibbonListViewItem ribbonListViewItem_5)
		{
			if (!this.bool_6 && this.ribbonListViewItem_1 != null)
			{
				this.ribbonListViewItem_1.ToolTip.method_3(null, 0, this.ribbonListViewItem_1.ToolTip.Control_0, this.pointF_0);
				ItemMouseDownEventHandler itemMouseDownEventHandler = (ItemMouseDownEventHandler)base.Events[RibbonListView.EventItemMouseDown];
				if (itemMouseDownEventHandler != null)
				{
					RibbonListViewItemEventArgs e = new RibbonListViewItemEventArgs(ribbonListViewItem_5);
					RibbonListView sender = (this.bool_16 ? this.ribbonListView_1 : this);
					itemMouseDownEventHandler(sender, e);
				}
			}
		}

		internal void method_26(RibbonListViewItem ribbonListViewItem_5)
		{
			if (!this.bool_6)
			{
				this.ribbonListViewItem_1.ToolTip.method_3(null, 0, this.ribbonListViewItem_1.ToolTip.Control_0, this.pointF_0);
				ItemMouseUpEventHandler itemMouseUpEventHandler = (ItemMouseUpEventHandler)base.Events[RibbonListView.EventItemMouseUp];
				if (itemMouseUpEventHandler != null)
				{
					RibbonListViewItemEventArgs e = new RibbonListViewItemEventArgs(ribbonListViewItem_5);
					RibbonListView sender = (this.bool_16 ? this.ribbonListView_1 : this);
					itemMouseUpEventHandler(sender, e);
				}
			}
		}

		internal void method_27(RibbonListViewItem ribbonListViewItem_5)
		{
			if (!this.bool_6)
			{
				this.ribbonListViewItem_1.ToolTip.method_3(null, 0, this.ribbonListViewItem_1.ToolTip.Control_0, this.pointF_0);
				ItemMouseEnterEventHandler itemMouseEnterEventHandler = (ItemMouseEnterEventHandler)base.Events[RibbonListView.EventItemMouseEnter];
				if (itemMouseEnterEventHandler != null)
				{
					RibbonListViewItem item = (this.bool_16 ? this.ribbonListView_1.RibbonListViewItems[this.ribbonListViewItem_1.Int32_1] : this.ribbonListViewItem_1);
					RibbonListViewItemEventArgs e = new RibbonListViewItemEventArgs(item);
					RibbonListView sender = (this.bool_16 ? this.ribbonListView_1 : this);
					itemMouseEnterEventHandler(sender, e);
				}
			}
		}

		internal void method_28(RibbonListViewItem ribbonListViewItem_5)
		{
			if (!this.bool_6)
			{
				ribbonListViewItem_5.ToolTip.method_2();
				ItemMouseEnterEventHandler itemMouseEnterEventHandler = (ItemMouseEnterEventHandler)base.Events[RibbonListView.EventItemMouseLeave];
				if (itemMouseEnterEventHandler != null)
				{
					RibbonListViewItem item = (this.bool_16 ? this.ribbonListView_1.RibbonListViewItems[this.ribbonListViewItem_1.Int32_1] : this.ribbonListViewItem_1);
					RibbonListViewItemEventArgs ribbonListViewItemEventArgs = new RibbonListViewItemEventArgs(item);
					ribbonListViewItemEventArgs.Enum137_0 = Enum137.const_8;
					RibbonListView sender = (this.bool_16 ? this.ribbonListView_1 : this);
					itemMouseEnterEventHandler(sender, ribbonListViewItemEventArgs);
				}
			}
		}

		internal virtual void vmethod_0(string string_2)
		{
			PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChangedEventHandler_0;
			if (propertyChangedEventHandler != null)
			{
				RibbonListView sender = (this.bool_16 ? this.ribbonListView_1 : this);
				propertyChangedEventHandler(sender, new PropertyChangedEventArgs(string_2));
			}
		}

		public void ActivateEditItemTextBox(RibbonListViewItem item)
		{
			this.method_29(item, Enum137.const_0);
		}

		/// <summary>Closes the text box that is displayed to edit an item.</summary>
		public void DeactivateEditItemTextBox()
		{
			this.method_30(bool_20: false, Enum137.const_0);
		}

		public void ScrollTo(RibbonListViewItem item)
		{
			if (item == null)
			{
				return;
			}
			bool flag = false;
			foreach (RibbonListViewItem item2 in this.ribbonListViewItemCollection_0)
			{
				if (item == item2)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				int num = (this.nullable_0.HasValue ? Math.Min(Math.Max(0, this.int_12 - this.nullable_0.Value), item.Int32_2) : 0);
				this.class553_0.method_8(num);
			}
		}

		internal void method_29(RibbonListViewItem ribbonListViewItem_5, Enum137 enum137_0)
		{
			this.method_30(bool_20: false, enum137_0);
			if (ribbonListViewItem_5 == null || !ribbonListViewItem_5.IsEditable || !base.IsHandleCreated || !this.Enabled || this.ribbonGroup_0.Boolean_2)
			{
				return;
			}
			foreach (RibbonListViewItem item in this.ribbonListViewItemCollection_0)
			{
				if (ribbonListViewItem_5 == item)
				{
					this.ribbonListViewItem_4 = ribbonListViewItem_5;
					bool bool_ = (Control.ModifierKeys & Keys.Control) == Keys.Control || this.bool_2;
					if (this.method_4(this.ribbonListViewItem_4, bool_))
					{
						this.method_5();
					}
					if (ribbonListViewItem_5.Rectangle_0.Top < 0 || ribbonListViewItem_5.Rectangle_0.Bottom > base.Height)
					{
						this.ScrollTo(this.ribbonListViewItem_4);
					}
					this.class555_0.Text = (this.string_1 = this.ribbonListViewItem_4.Text);
					int num;
					if (!string.IsNullOrEmpty(this.ribbonListViewItem_4.Text))
					{
						num = this.int_8 - this.ribbonListViewItem_4.Rectangle_1.X - this.int_9;
					}
					else
					{
						int num3 = (this.class555_0.Width = Class517.smethod_45(this.int_6, this.pointF_0.X));
						num = num3;
					}
					int num4 = num;
					this.class555_0.Bounds = new Rectangle(new Point(this.ribbonListViewItem_4.Point_0.X + this.ribbonListViewItem_4.Rectangle_1.X, (int)((float)(this.ribbonListViewItem_4.Point_0.Y + this.ribbonListViewItem_4.Rectangle_1.Y) - this.float_0)), new Size(num4, this.ribbonListViewItem_4.Rectangle_1.Height));
					this.class555_0.Boolean_0 = true;
					this.class555_0.Focus();
					this.ribbonListViewItem_4.Boolean_1 = true;
					this.method_20(this.ribbonListViewItem_4, enum137_0);
					break;
				}
			}
		}

		internal void method_30(bool bool_20, Enum137 enum137_0)
		{
			RibbonListViewItem ribbonListViewItem = this.ribbonListViewItem_4;
			this.ribbonListViewItem_4 = null;
			if (ribbonListViewItem != null)
			{
				if (!bool_20)
				{
					ribbonListViewItem.Text = this.class555_0.Text;
				}
				this.class555_0.Boolean_0 = false;
				ribbonListViewItem.Boolean_1 = false;
				this.method_21(ribbonListViewItem, enum137_0);
				if (this.ribbonListViewItem_4 == null)
				{
					base.Focus();
				}
			}
		}

		protected override AccessibleObject CreateAccessibilityInstance()
		{
			return new Control13(this);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				((IContentItem)this).ToolTip.Dispose();
				this.class555_0.Dispose();
				if (this.ribbonDropDown_0 != null)
				{
					this.ribbonDropDown_0.Dispose();
				}
				if (this.ribbonListViewItem_0 != null)
				{
					RibbonListViewItem[] array = this.ribbonListViewItem_0;
					foreach (RibbonListViewItem ribbonListViewItem in array)
					{
						ribbonListViewItem.method_0();
					}
				}
				foreach (Control dropDownItem in this.DropDownItems)
				{
					dropDownItem.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		protected override void OnEnabledChanged(EventArgs eventArgs_0)
		{
			this.method_17();
			base.OnEnabledChanged(eventArgs_0);
		}

		protected override void OnFontChanged(EventArgs eventArgs_0)
		{
			this.ribbonToolTip_0.Font_0 = base.Font;
			this.class555_0.Font = base.Font;
			foreach (Control item in this.ribbonItemCollection_0)
			{
				item.Font = base.Font;
			}
			base.OnFontChanged(eventArgs_0);
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			base.OnHandleCreated(eventArgs_0);
			if (((IContentItem)this).Original == null)
			{
				base.Controls.Add(this.class555_0);
			}
		}

		protected override void OnPaint(PaintEventArgs pea)
		{
			pea.Graphics.FillRectangle(new SolidBrush(base.BackColor), pea.ClipRectangle);
			if (this.bool_9 && this.visualStyleRenderer_0 != null)
			{
				this.visualStyleRenderer_0.DrawBackground(pea.Graphics, new Rectangle(0, 0, base.Width, base.Height));
			}
			if (!this.bool_6 || this.bool_16)
			{
				foreach (RibbonListViewItem item in this.ribbonListViewItemCollection_0)
				{
					item.method_1(pea.Graphics);
				}
			}
			if (this.class553_0.Boolean_4)
			{
				this.class553_0.method_4(pea.Graphics);
			}
			base.OnPaint(pea);
		}

		protected override void OnSizeChanged(EventArgs eventArgs_0)
		{
			this.int_15 = base.Width;
			this.int_16 = base.Height;
			this.method_11(bool_20: true);
			base.OnSizeChanged(eventArgs_0);
		}

		protected override void WndProc(ref Message message)
		{
			Class429.Enum121 msg = (Class429.Enum121)message.Msg;
			if (msg != Class429.Enum121.const_56)
			{
				base.WndProc(ref message);
			}
		}

		void IRibbonItem.AwareOfDPI(PointF dpi)
		{
			if (dpi.X == this.pointF_0.X && dpi.Y == this.pointF_0.Y)
			{
				return;
			}
			this.class555_0.Font = this.Font;
			this.pointF_0 = dpi;
			this.int_9 = Class517.smethod_45(Class519.Class529.Int32_2, this.pointF_0.X);
			base.Margin = Class517.smethod_51(Class519.Class523.Padding_3, dpi);
			this.int_13 = Class517.smethod_45(Class519.Class529.Int32_1, this.pointF_0.Y);
			this.int_8 = Class517.smethod_45(Class519.Class529.Int32_0, this.pointF_0.X);
			this.padding_0 = Class517.smethod_51(this.padding_1, this.pointF_0);
			this.int_2 = Class517.smethod_45(this.int_3, this.pointF_0.X);
			this.class553_0.Int32_1 = Class517.smethod_45(Class519.Class529.Class530.Int32_0, this.pointF_0.X);
			this.class553_0.method_6();
			this.float_0 = Class517.smethod_45(2, this.pointF_0.Y);
			this.int_15 = 0;
			this.int_16 = 0;
			this.method_12(bool_20: false);
			foreach (IRibbonItem item in this.ribbonItemCollection_0)
			{
				item.AwareOfDPI(dpi);
			}
		}

		SizeF IRibbonItem.GetSize(IconTextRelation scaleMode)
		{
			return new SizeF(base.Width, base.Height);
		}

		void IRibbonItem.ParentVisibleChanged(bool isVisible)
		{
			this.method_30(bool_20: false, Enum137.const_10);
			foreach (Control dropDownItem in this.DropDownItems)
			{
				(dropDownItem as IRibbonItem).ParentVisibleChanged(isVisible);
			}
		}

		void IRibbonItem.PerformStandardKeyboardAction()
		{
			if (this.class553_0.Boolean_4)
			{
				this.ribbonListViewItem_2 = null;
				this.method_35();
			}
		}

		void IRibbonItem.SetDropDownItemSize()
		{
		}

		void IRibbonItem.SetParentCollection(RibbonItemCollection parentCollection)
		{
			this.ribbonItemCollection_1 = parentCollection;
		}

		private bool method_31(RibbonListViewItem[] ribbonListViewItem_5)
		{
			if (this.method_32(ribbonListViewItem_5, this.ribbonListViewItem_0))
			{
				return false;
			}
			this.ribbonListViewItemCollection_0.method_3(bool_1: true);
			if (ribbonListViewItem_5 == null)
			{
				this.ribbonListViewItemCollection_0.Boolean_0 = false;
			}
			else
			{
				List<RibbonListViewItem> list = new List<RibbonListViewItem>();
				foreach (RibbonListViewItem ribbonListViewItem in ribbonListViewItem_5)
				{
					this.ribbonListViewItemCollection_0.method_2(ribbonListViewItem);
					if (ribbonListViewItem.IsSelected)
					{
						list.Add(ribbonListViewItem);
					}
				}
				this.SelectedItems = list.ToArray();
				this.ribbonListViewItemCollection_0.Boolean_0 = true;
			}
			this.ribbonListViewItem_0 = ribbonListViewItem_5;
			return true;
		}

		private bool method_32(RibbonListViewItem[] ribbonListViewItem_5, RibbonListViewItem[] ribbonListViewItem_6)
		{
			if (ribbonListViewItem_5 == null && ribbonListViewItem_6 == null)
			{
				return true;
			}
			if (ribbonListViewItem_5 != null && ribbonListViewItem_6 != null && ribbonListViewItem_5.Length == ribbonListViewItem_6.Length)
			{
				int num = 0;
				while (true)
				{
					if (num < ribbonListViewItem_5.Length)
					{
						if (ribbonListViewItem_5[num] != ribbonListViewItem_6[num])
						{
							break;
						}
						num++;
						continue;
					}
					return true;
				}
				return false;
			}
			return false;
		}

		protected override void OnGotFocus(EventArgs eventArgs_0)
		{
			if (this.class553_0.Boolean_0 && this.ribbonListViewItemCollection_0.Count == 0)
			{
				this.class553_0.method_7(Class553.Enum138.const_2);
				base.Invalidate();
			}
			else if (!this.ribbonGroup_0.Boolean_2)
			{
				if (this.ribbonListViewItemCollection_0.Count != 0 && !this.bool_6 && !this.bool_7)
				{
					int number = ((this.int_14.Length > 0) ? this.int_14[this.int_14.Length - 1] : 0);
					this.ribbonListViewItem_1 = this.ribbonListViewItemCollection_0[number];
				}
				else
				{
					this.ribbonListViewItem_1 = null;
				}
				base.Invalidate();
			}
			else
			{
				this.ribbonListViewItem_1 = null;
			}
			base.OnGotFocus(eventArgs_0);
		}

		protected override void OnLostFocus(EventArgs eventArgs_0)
		{
			if (this.ribbonListViewItem_1 != null)
			{
				this.method_28(this.ribbonListViewItem_1);
				this.ribbonListViewItem_1 = null;
			}
			this.class553_0.method_7(Class553.Enum138.const_4);
			base.Invalidate();
			base.OnLostFocus(eventArgs_0);
		}

		protected override bool IsInputKey(Keys keyData)
		{
			switch (keyData)
			{
			case Keys.Escape:
				return true;
			case Keys.F2:
				return true;
			case Keys.Return:
			case Keys.Space:
				return true;
			default:
				return base.IsInputKey(keyData);
			case Keys.Left:
			case Keys.Up:
			case Keys.Right:
			case Keys.Down:
				return true;
			}
		}

		protected override void OnKeyDown(KeyEventArgs keyEventArgs_0)
		{
			if (this.Enabled)
			{
				base.OnKeyDown(keyEventArgs_0);
				switch (keyEventArgs_0.KeyCode)
				{
				case Keys.F2:
					this.method_29((this.ribbonListViewItem_1 != null) ? this.ribbonListViewItem_1 : this.ribbonListViewItem_2, Enum137.const_3);
					break;
				case Keys.Return:
				case Keys.Escape:
				case Keys.Left:
				case Keys.Up:
				case Keys.Right:
				case Keys.Down:
					this.method_34(keyEventArgs_0.KeyCode);
					break;
				}
			}
		}

		private void class555_0_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyData)
			{
			case Keys.Escape:
				this.method_30(bool_20: true, Enum137.const_2);
				break;
			case Keys.Return:
				this.method_30(bool_20: false, Enum137.const_1);
				break;
			}
		}

		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			if (!this.Enabled)
			{
				return;
			}
			if (this.ribbonListViewItem_4 != null)
			{
				this.method_30(bool_20: false, Enum137.const_6);
			}
			if (this.class553_0.Boolean_4 && this.class553_0.Boolean_2)
			{
				this.ribbonListViewItem_2 = null;
				this.bool_1 = !this.class553_0.method_0();
			}
			else
			{
				this.bool_1 = true;
				if ((!this.bool_6 || this.bool_16) && !this.ribbonGroup_0.Boolean_2)
				{
					bool bool_ = (Control.ModifierKeys & Keys.Control) == Keys.Control || this.bool_2;
					if (this.method_2(mevent.Location, bool_))
					{
						this.method_5();
					}
				}
			}
			if (this.ribbonListViewItem_2 != null && (this.ribbonGroup_0 == null || !this.ribbonGroup_0.Boolean_2))
			{
				RibbonListViewItem ribbonListViewItem_ = (this.bool_16 ? this.ribbonListView_1.RibbonListViewItems[this.ribbonListViewItem_2.Int32_1] : this.ribbonListViewItem_2);
				this.method_25(ribbonListViewItem_);
			}
			base.OnMouseDown(mevent);
			if (this.ribbonToolTip_0 != null)
			{
				this.ribbonToolTip_0.method_2();
			}
			if (!this.Focused)
			{
				base.Focus();
			}
		}

		protected override void OnMouseClick(MouseEventArgs mouseEventArgs_0)
		{
			if (this.int_14.Length == 1 && this.ribbonListViewItemCollection_0[this.int_14[0]] == this.ribbonListViewItem_2)
			{
				if (this.ribbonListViewItem_3 != this.ribbonListViewItem_2)
				{
					this.ribbonListViewItem_3 = this.ribbonListViewItem_2;
				}
				else
				{
					this.method_29(this.ribbonListViewItem_2, Enum137.const_7);
					this.ribbonListViewItem_3 = null;
				}
			}
			else
			{
				this.ribbonListViewItem_3 = null;
			}
			base.OnMouseClick(mouseEventArgs_0);
		}

		protected override void OnMouseLeave(EventArgs eventargs)
		{
			if (this.Enabled)
			{
				if (this.ribbonListViewItem_1 != null)
				{
					this.method_28(this.ribbonListViewItem_1);
					this.ribbonListViewItem_1 = null;
				}
				this.class553_0.method_7(Class553.Enum138.const_4);
				base.Invalidate();
				base.OnMouseLeave(eventargs);
				if (this.ribbonToolTip_0 != null)
				{
					this.ribbonToolTip_0.method_2();
				}
			}
		}

		protected override void OnMouseMove(MouseEventArgs mevent)
		{
			if (!this.Enabled)
			{
				return;
			}
			bool flag = this.ribbonListViewItem_1 != null;
			if (!this.ribbonGroup_0.Boolean_2 && !this.bool_6)
			{
				bool? flag2;
				bool? flag3 = (flag2 = this.method_39(mevent.Location));
				if (flag3.HasValue)
				{
					this.class553_0.method_7(Class553.Enum138.const_4);
					if (flag2.Value)
					{
						base.Invalidate();
					}
					base.OnMouseMove(mevent);
					return;
				}
			}
			if (this.class553_0.method_7(this.class553_0.method_3(mevent.Location)))
			{
				base.Invalidate();
				if (this.class553_0.Boolean_2)
				{
					if (!this.ribbonToolTip_0.Boolean_1)
					{
						Point? point = this.method_38();
						if (!this.bool_16)
						{
							this.ribbonToolTip_0.method_3(point, 0, this.ribbonToolTip_0.Control_0, this.pointF_0);
						}
					}
				}
				else if (!this.bool_16 && this.ribbonToolTip_0 != null && this.ribbonToolTip_0.Boolean_1)
				{
					this.ribbonToolTip_0.method_2();
				}
			}
			else if (flag && this.ribbonListViewItem_1 == null)
			{
				base.Invalidate();
			}
			base.OnMouseMove(mevent);
		}

		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			if (!this.Enabled)
			{
				return;
			}
			this.class553_0.method_2();
			if (this.ribbonGroup_0 == null || !this.ribbonGroup_0.Boolean_2)
			{
				if (this.ribbonListViewItem_1 != null)
				{
					RibbonListViewItem ribbonListViewItem_ = (this.bool_16 ? this.ribbonListView_1.RibbonListViewItems[this.ribbonListViewItem_1.Int32_1] : this.ribbonListViewItem_1);
					this.method_26(ribbonListViewItem_);
				}
				if (this.ribbonListViewItem_2 != null && (mevent == null || mevent.Button == MouseButtons.Left))
				{
					RibbonListViewItem ribbonListViewItem_2 = (this.bool_16 ? this.ribbonListView_1.RibbonListViewItems[this.ribbonListViewItem_2.Int32_1] : this.ribbonListViewItem_2);
					this.method_22(ribbonListViewItem_2);
				}
			}
			if (this.bool_1 && this.Boolean_3)
			{
				Class517.smethod_28(this);
			}
			this.bool_1 = false;
			base.OnMouseUp(mevent);
		}

		protected override void OnRightToLeftChanged(EventArgs eventArgs_0)
		{
			this.method_11(bool_20: false);
			foreach (RibbonListViewItem item in this.ribbonListViewItemCollection_0)
			{
				item.method_4();
			}
			base.OnRightToLeftChanged(eventArgs_0);
		}

		private void method_34(Keys keys_0)
		{
			if (!this.Enabled)
			{
				return;
			}
			if (keys_0 == Keys.Return)
			{
				if (this.class553_0.Boolean_1)
				{
					this.ribbonListViewItem_2 = null;
					this.method_35();
				}
				else if (this.ribbonListViewItem_1 != null)
				{
					this.ribbonListViewItem_2 = this.ribbonListViewItem_1;
					this.bool_1 = true;
					bool bool_ = (Control.ModifierKeys & Keys.Control) == Keys.Control || this.bool_2;
					if (this.method_3(bool_))
					{
						this.method_5();
					}
				}
				this.OnMouseUp(null);
				this.OnClick(null);
				return;
			}
			if (this.ribbonListViewItem_1 == null && this.ribbonListViewItem_2 != null)
			{
				this.ribbonListViewItem_1 = this.ribbonListViewItem_2;
			}
			if (this.ribbonListViewItem_1 == null)
			{
				return;
			}
			RibbonListViewItem ribbonListViewItem = null;
			int num = 0;
			int num2 = 0;
			switch (keys_0)
			{
			default:
				return;
			case Keys.Left:
				if (this.ribbonListViewItem_1.Int32_0 - 1 < 0)
				{
					num = this.int_7 - 1;
					num2 = this.ribbonListViewItem_1.Int32_2 - 1;
				}
				else
				{
					num = this.ribbonListViewItem_1.Int32_0 - 1;
					num2 = this.ribbonListViewItem_1.Int32_2;
				}
				ribbonListViewItem = this.ribbonListViewItemCollection_0.method_1(num2, num);
				break;
			case Keys.Up:
				num2 = Math.Max(this.ribbonListViewItem_1.Int32_2 - 1, 0);
				ribbonListViewItem = this.ribbonListViewItemCollection_0.method_1(num2, this.ribbonListViewItem_1.Int32_0);
				break;
			case Keys.Right:
				num = this.ribbonListViewItem_1.Int32_0 + 1;
				ribbonListViewItem = this.ribbonListViewItemCollection_0.method_1(this.ribbonListViewItem_1.Int32_2, num);
				num2 = ribbonListViewItem.Int32_2;
				break;
			case Keys.Down:
				if (Control.ModifierKeys == Keys.Alt && (this.listViewMode_0 & ListViewMode.DropDown) == ListViewMode.DropDown)
				{
					this.ribbonListViewItem_1.DropDown.Control14_0.method_1();
				}
				else if (this.ribbonListViewItem_1.Int32_2 + 1 < this.int_12)
				{
					num2 = this.ribbonListViewItem_1.Int32_2 + 1;
					ribbonListViewItem = this.ribbonListViewItemCollection_0.method_1(num2, this.ribbonListViewItem_1.Int32_0);
				}
				break;
			case Keys.Escape:
			{
				Control control = this;
				while (control != null && !(control is Ribbon) && !(control is RibbonDropDown))
				{
					control = control.Parent;
				}
				if (control != null)
				{
					this.ribbonListViewItem_3 = null;
					if (control is Ribbon)
					{
						((Ribbon)control).method_10();
					}
					if (control is RibbonDropDown)
					{
						this.ribbonListViewItem_1 = null;
						((RibbonDropDown)control).Close();
					}
					else if (this.bool_5)
					{
						this.ribbonListViewItem_1 = null;
						this.SelectedItems = new RibbonListViewItem[0];
					}
				}
				break;
			}
			}
			if (ribbonListViewItem == null || this.ribbonListViewItem_1 == ribbonListViewItem)
			{
				return;
			}
			this.class553_0.method_7(Class553.Enum138.const_3);
			this.method_28(this.ribbonListViewItem_1);
			this.ribbonListViewItem_1 = ribbonListViewItem;
			if (num2 >= this.class553_0.Int32_0 + this.MaxVisibleRows)
			{
				this.class553_0.method_8(num2 - this.MaxVisibleRows.Value + 1);
			}
			else if (num2 < this.class553_0.Int32_0)
			{
				this.class553_0.method_8(num2);
			}
			if (this.ribbonListViewItem_1 != null && this.bool_3)
			{
				this.ribbonListViewItem_2 = this.ribbonListViewItem_1;
				this.bool_1 = true;
				bool bool_2 = (Control.ModifierKeys & Keys.Control) == Keys.Control || this.bool_2;
				if (this.method_3(bool_2))
				{
					this.ribbonListViewItem_3 = this.ribbonListViewItem_2;
					this.method_5();
				}
			}
			this.method_27(this.ribbonListViewItem_1);
			base.Invalidate();
		}

		internal void method_35()
		{
			RibbonDropDown ribbonDropDown = this.method_36();
			ribbonDropDown.Owner = Class517.smethod_1(base.Parent);
			int num = ((!this.bool_10) ? base.Height : 0);
			if (this.bool_15)
			{
				ribbonDropDown.Show(this, new Point(base.Width, num), ToolStripDropDownDirection.BelowLeft);
			}
			else
			{
				ribbonDropDown.Show(this, new Point(0, num));
			}
		}

		private RibbonDropDown method_36()
		{
			this.method_19();
			if (this.ribbonDropDown_0 == null)
			{
				this.ribbonDropDown_0 = new RibbonDropDown();
				this.ribbonDropDown_0.Closed += ribbonDropDown_0_Closed;
			}
			Size size3 = (this.ribbonDropDown_0.Size = (this.ribbonDropDown_0.MaximumSize = default(Size)));
			int num = base.Width;
			int num2 = 27;
			if (this.bool_10)
			{
				this.ribbonListView_0 = this.method_37();
				ToolStripControlHost toolStripControlHost = new ToolStripControlHost(this.ribbonListView_0);
				toolStripControlHost.Dock = this.ribbonListView_0.Dock;
				toolStripControlHost.Margin = new Padding(0);
				this.ribbonDropDown_0.Items.Add(toolStripControlHost);
			}
			foreach (Control item in this.ribbonItemCollection_0)
			{
				if (item.Visible)
				{
					(item as IRibbonItem).SetDropDownItemSize();
					num = Math.Max(item.Width, num);
					ToolStripControlHost toolStripControlHost2 = new ToolStripControlHost(item);
					toolStripControlHost2.Font = item.Font;
					ToolStripControlHost toolStripControlHost = toolStripControlHost2;
					toolStripControlHost.Dock = item.Dock;
					this.ribbonDropDown_0.Items.Add(toolStripControlHost);
				}
			}
			if (this.ribbonListView_0 != null)
			{
				this.ribbonListView_0.method_15(num, this.int_7, this.class553_0.Int32_0);
			}
			this.ribbonDropDown_0.MaximumSize = new Size(this.ribbonDropDown_0.Width - num2, this.ribbonDropDown_0.Height);
			return this.ribbonDropDown_0;
		}

		private RibbonListView method_37()
		{
			RibbonListView ribbonListView = new RibbonListView();
			((IRibbonItem)ribbonListView).AwareOfDPI(this.pointF_0);
			((IContentItem)ribbonListView).Original = this;
			ribbonListView.BackColor = this.BackColor;
			ribbonListView.ForeColor = this.ForeColor;
			((IRibbonItem)ribbonListView).RibbonGroup = this.ribbonGroup_0;
			ribbonListView.Boolean_5 = true;
			ribbonListView.Boolean_3 = this.Boolean_3;
			ribbonListView.Boolean_4 = this.Boolean_4;
			ribbonListView.ViewMode = this.ViewMode;
			ribbonListView.ShowBorder = false;
			ribbonListView.ShowItemsInDropDown = false;
			ribbonListView.HideSelectedItems = false;
			ribbonListView.MultiSelect = this.MultiSelect;
			ribbonListView.MaxColumnCount = this.MaxColumnCount;
			ribbonListView.MinColumnCount = this.ColumnCount;
			ribbonListView.int_8 = this.int_8;
			ribbonListView.int_13 = this.int_13;
			ribbonListView.Enabled = this.Enabled;
			ribbonListView.ItemsSource = Class517.smethod_5(this, ribbonListView);
			ribbonListView.SelectedIndices = this.int_14;
			Class517.smethod_7(this, ribbonListView);
			ribbonListView.class555_0.Boolean_0 = false;
			return ribbonListView;
		}

		private void ribbonDropDown_0_Closed(object sender, ToolStripDropDownClosedEventArgs e)
		{
			this.ribbonListView_0 = null;
			((RibbonDropDown)sender).Items.Clear();
			this.method_18();
		}

		private Point? method_38()
		{
			if (this.bool_14)
			{
				return null;
			}
			int num = (this.bool_15 ? this.class553_0.Int32_1 : (base.Width - this.class553_0.Int32_1));
			int num2 = ((this.ribbonGroup_0 is HorizontalRibbonGroup) ? base.Parent.Location.Y : base.Location.Y);
			int num3 = this.ribbonGroup_0.Height - num2;
			return new Point(num, num3);
		}

		private bool? method_39(Point point_0)
		{
			if (this.ribbonListViewItem_1 != null)
			{
				if (this.ribbonListViewItem_1.Rectangle_0.Contains(point_0))
				{
					return false;
				}
				this.method_28(this.ribbonListViewItem_1);
				this.ribbonListViewItem_1 = null;
			}
			foreach (RibbonListViewItem item in this.ribbonListViewItemCollection_0)
			{
				if (item.Rectangle_0.Contains(point_0))
				{
					this.ribbonListViewItem_1 = item;
					this.method_27(this.ribbonListViewItem_1);
					return true;
				}
			}
			return null;
		}
	}
}
