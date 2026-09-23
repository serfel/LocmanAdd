using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;
using TXTextControl;
using TXTextControl.Windows.Forms;

namespace ns26
{
	internal class Class572 : ContentPanel
	{
		internal class Class585 : ListViewItem
		{
			private Bitmap bitmap_0;

			private StringFormat stringFormat_0 = new StringFormat
			{
				Trimming = StringTrimming.EllipsisCharacter,
				FormatFlags = StringFormatFlags.NoWrap
			};

			private bool bool_0;

			[CompilerGenerated]
			private bool bool_1;

			[CompilerGenerated]
			private bool bool_2;

			[CompilerGenerated]
			private bool bool_3;

			internal bool Boolean_0
			{
				[CompilerGenerated]
				get
				{
					return this.bool_1;
				}
				[CompilerGenerated]
				set
				{
					this.bool_1 = value;
				}
			}

			internal bool Boolean_1
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

			internal bool Boolean_2
			{
				[CompilerGenerated]
				get
				{
					return this.bool_3;
				}
				[CompilerGenerated]
				set
				{
					this.bool_3 = value;
				}
			}

			internal Class585(string string_0, Bitmap bitmap_1, bool bool_4)
			{
				this.bitmap_0 = bitmap_1;
				this.bool_0 = bool_4;
				base.Text = string_0;
			}

			internal void method_0(Graphics graphics_0, bool bool_4, Rectangle rectangle_0, Font font_0)
			{
				graphics_0.FillRectangle(new SolidBrush(Color.White), rectangle_0);
				if (bool_4)
				{
					graphics_0.DrawImage(this.bitmap_0, new Point(rectangle_0.X, rectangle_0.Y + 4));
				}
				else
				{
					Rectangle rectangle = new Rectangle(rectangle_0.Location, rectangle_0.Size);
					rectangle.Offset(0, (int)(((float)rectangle.Height - graphics_0.MeasureString(base.Text, font_0).Height) / 2f));
					graphics_0.DrawString(base.Text, font_0, new SolidBrush(SystemColors.WindowText), rectangle, this.stringFormat_0);
					if (this.bool_0)
					{
						Rectangle rectangle2 = new Rectangle(rectangle_0.Width - rectangle_0.Height, rectangle_0.Y, rectangle_0.Height, rectangle_0.Height);
						graphics_0.FillRectangle(new SolidBrush(Color.White), rectangle2);
						graphics_0.DrawString("¶", font_0, new SolidBrush(SystemColors.WindowText), rectangle2, new StringFormat
						{
							LineAlignment = StringAlignment.Center,
							Alignment = StringAlignment.Center
						});
					}
				}
				if (this.Boolean_1)
				{
					this.Boolean_0 = false;
					graphics_0.DrawRectangle(new Pen(new SolidBrush(Color.Blue), 1f), new Rectangle(rectangle_0.X, rectangle_0.Y, rectangle_0.Width - 1, rectangle_0.Height - 1));
				}
				else if (this.Boolean_0 && !this.Boolean_2)
				{
					graphics_0.DrawRectangle(new Pen(new SolidBrush(Color.Gray), 1f), new Rectangle(rectangle_0.X, rectangle_0.Y, rectangle_0.Width - 1, rectangle_0.Height - 1));
				}
			}
		}

		private ListBox listBox_0;

		private Sidebar.Class584 class584_0;

		private System.Windows.Forms.Button button_0;

		private TextControl textControl_0;

		private Size size_0;

		private Size size_1;

		private bool bool_0;

		private int int_0 = -1;

		private int int_1 = -1;

		internal Class572(Enum140 enum140_0, TextControl textControl_1, bool bool_1, Sidebar.SidebarContentLayout sidebarContentLayout_0, PointF pointF_0)
			: base(enum140_0, textControl_1, bool_1, sidebarContentLayout_0, pointF_0)
		{
			this.class584_0.Text = base.m_rm.GetString("ID_STYLES_SHOW_PREVIEW");
			this.button_0.Text = base.m_rm.GetString("ID_STYLES_MANAGE_STYLES");
		}

		protected override void OnSizeChanged(EventArgs eventArgs_0)
		{
			base.OnSizeChanged(eventArgs_0);
			this.listBox_0.Refresh();
		}

		internal override void InitializeItems()
		{
			this.class584_0 = new Sidebar.Class584
			{
				Name = Sidebar.StylesItem.TXITEM_ShowPreview.ToString()
			};
			this.class584_0.CheckedChanged += class584_0_CheckedChanged;
			this.button_0 = new System.Windows.Forms.Button
			{
				Name = Sidebar.StylesItem.TXITEM_ManageStyles.ToString(),
				UseVisualStyleBackColor = true
			};
			this.button_0.Click += button_0_Click;
			this.listBox_0 = new ListBox
			{
				Name = Sidebar.StylesItem.TXITEM_Styles.ToString(),
				IntegralHeight = false
			};
			this.listBox_0.DrawMode = DrawMode.OwnerDrawFixed;
			this.listBox_0.DrawItem += listBox_0_DrawItem;
			this.listBox_0.MouseDown += listBox_0_MouseDown;
			this.listBox_0.MouseMove += listBox_0_MouseMove;
			this.listBox_0.MouseLeave += listBox_0_MouseLeave;
			this.listBox_0.MouseEnter += listBox_0_MouseEnter;
			this.listBox_0.KeyDown += listBox_0_KeyDown;
			this.listBox_0.SelectedIndexChanged += listBox_0_SelectedIndexChanged;
			base.m_dicItems.Add(this.listBox_0.Name, this.listBox_0);
			base.m_dicItems.Add(this.class584_0.Name, this.class584_0);
			base.m_dicItems.Add(this.button_0.Name, this.button_0);
		}

		internal override void AwareOfDPI_Intialize()
		{
			if (!base.m_pntDpi.IsEmpty)
			{
				this.size_0 = Class517.smethod_48(Class519.Class542.Class545.Size_3, base.m_pntDpi);
				this.size_1 = Class517.smethod_48(Class519.Class542.Class545.Size_4, base.m_pntDpi);
				this.listBox_0.ItemHeight = (this.class584_0.Checked ? (this.size_0.Height + Class517.smethod_45(8, base.m_pntDpi.X)) : this.size_1.Height);
				Size size3 = (this.button_0.Size = (this.button_0.MinimumSize = Class517.smethod_48(Class519.Class542.Class545.Size_5, base.m_pntDpi)));
				this.listBox_0.Margin = Class517.smethod_51(Class519.Class542.Class545.Padding_0, base.m_pntDpi);
				this.class584_0.Margin = Class517.smethod_51(Class519.Class542.Class545.Padding_1, base.m_pntDpi);
				this.button_0.Margin = Class517.smethod_51(Class519.Class542.Class545.Padding_2, base.m_pntDpi);
				this.method_6();
			}
		}

		internal override void AwareOfDPI_Vertical()
		{
			if (!base.m_pntDpi.IsEmpty)
			{
				this.listBox_0.MinimumSize = Size.Empty;
				this.listBox_0.MinimumSize = Class517.smethod_48(Class519.Class542.Class545.Size_0, base.m_pntDpi);
				this.listBox_0.Size = this.listBox_0.MinimumSize;
			}
			base.AwareOfDPI_Vertical();
		}

		internal override void AwareOfDPI_Horizontal()
		{
			if (!base.m_pntDpi.IsEmpty)
			{
				this.listBox_0.MinimumSize = Size.Empty;
				this.listBox_0.MinimumSize = Class517.smethod_48(Class519.Class542.Class545.Size_1, base.m_pntDpi);
				this.listBox_0.Size = this.listBox_0.MinimumSize;
			}
			base.AwareOfDPI_Horizontal();
		}

		internal override void AwareOfDPI_Dialog()
		{
			Size size = Class517.smethod_48(Class519.Class542.Class545.Size_2, base.m_pntDpi);
			this.listBox_0.MinimumSize = size;
			this.listBox_0.MaximumSize = size;
			this.listBox_0.MaximumSize = new Size(int.MaxValue, int.MaxValue);
			base.AwareOfDPI_Dialog();
		}

		internal override void UpdateContent()
		{
			this.method_6();
		}

		internal override void SetHorizontalAlignment()
		{
			this.method_4();
			base.SetHorizontalAlignment();
		}

		internal override void SetVerticalAlignment()
		{
			this.method_4();
			base.SetVerticalAlignment();
		}

		internal override void SetDialogAlignment()
		{
			this.method_4();
			base.SetDialogAlignment();
		}

		internal override void UpdateTextControlBindings(TextControl oldTextcontrol, TextControl newTextControl)
		{
			if (oldTextcontrol != null)
			{
				this.listBox_0.Items.Clear();
				oldTextcontrol.InputFormat.StyleNamesChanged -= method_0;
				oldTextcontrol.InputFormat.StyleNameChanged -= method_1;
			}
			if (newTextControl != null)
			{
				this.method_6();
				newTextControl.InputFormat.StyleNamesChanged += method_0;
				newTextControl.InputFormat.StyleNameChanged += method_1;
			}
		}

		private void method_0(object sender, EventArgs e)
		{
			this.method_6();
		}

		private void method_1(object sender, EventArgs e)
		{
			this.method_3();
		}

		private void class584_0_CheckedChanged(object sender, EventArgs e)
		{
			if (!base.m_pntDpi.IsEmpty)
			{
				this.method_8(this.class584_0.Checked);
			}
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			if (base.TextControl != null)
			{
				base.TextControl.FormattingStylesDialog();
			}
		}

		private void listBox_0_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (this.listBox_0.Items.Count > 0 && e.Index >= 0)
			{
				float num = 1f;
				if (base.m_pntDpi.X != e.Graphics.DpiX)
				{
					num = base.m_pntDpi.X / e.Graphics.DpiX;
				}
				(this.listBox_0.Items[e.Index] as Class585).method_0(e.Graphics, this.bool_0, e.Bounds, new Font("Microsoft Sans Serif", 10f * num, FontStyle.Regular, GraphicsUnit.Point, 0));
			}
		}

		private void listBox_0_KeyDown(object sender, KeyEventArgs e)
		{
			if (base.TextControl != null && (e.KeyCode == Keys.Return || e.KeyCode == Keys.Space))
			{
				this.method_7(this.int_0, bool_1: true);
			}
		}

		private void listBox_0_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				this.method_7(this.int_0, bool_1: true);
			}
		}

		private void listBox_0_MouseEnter(object sender, EventArgs e)
		{
			Point p = this.listBox_0.PointToClient(Control.MousePosition);
			this.method_9(this.listBox_0.IndexFromPoint(p), bool_1: true);
		}

		private void listBox_0_MouseMove(object sender, EventArgs e)
		{
			Point p = this.listBox_0.PointToClient(Control.MousePosition);
			this.method_9(this.listBox_0.IndexFromPoint(p), bool_1: false);
		}

		private void listBox_0_MouseLeave(object sender, EventArgs e)
		{
			if (this.int_0 >= 0)
			{
				(this.listBox_0.Items[this.int_0] as Class585).Boolean_2 = true;
				this.listBox_0.Invalidate(this.listBox_0.GetItemRectangle(this.int_0));
			}
		}

		private void listBox_0_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.method_9(this.listBox_0.SelectedIndex, bool_1: false);
		}

		private Class585[] method_2()
		{
			Class585[] array = new Class585[0];
			if (this.method_5() && base.TextControl != null)
			{
				string[] styleNames = base.TextControl.InputFormat.StyleNames;
				array = new Class585[styleNames.Length];
				ParagraphStyleCollection paragraphStyleCollection = new ParagraphStyleCollection(base.TextControl.textControlCore_0);
				InlineStyleCollection inlineStyleCollection = new InlineStyleCollection(base.TextControl.textControlCore_0);
				ParagraphStyleCollection paragraphStyleCollection2 = new ParagraphStyleCollection(this.textControl_0.textControlCore_0);
				InlineStyleCollection inlineStyleCollection2 = new InlineStyleCollection(this.textControl_0.textControlCore_0);
				bool flag = base.TextControl.RightToLeft == RightToLeft.Yes;
				for (int i = 0; i < array.Length; i++)
				{
					string text = styleNames[i];
					bool bool_;
					Bitmap bitmap_ = Class517.smethod_41(text, this.textControl_0, new FormattingStyleCollection[4] { paragraphStyleCollection, inlineStyleCollection, paragraphStyleCollection2, inlineStyleCollection2 }, flag, this.size_0, out bool_, base.m_pntDpi);
					Class585 @class = (array[i] = new Class585(text, bitmap_, bool_));
				}
			}
			return array;
		}

		private void method_3()
		{
			if (!base.IsSidebarShown || base.TextControl == null)
			{
				return;
			}
			int num = 0;
			while (base.TextControl.InputFormat.StyleName != null && num < this.listBox_0.Items.Count)
			{
				Class585 @class = this.listBox_0.Items[num] as Class585;
				if (!(@class.Text == base.TextControl.InputFormat.StyleName))
				{
					num++;
					continue;
				}
				this.int_0 = num;
				this.method_7(this.int_0, bool_1: false);
				return;
			}
			this.method_7(-1, bool_1: false);
		}

		private void method_4()
		{
			base.Controls.Clear();
			base.ColumnStyles.Clear();
			base.RowStyles.Clear();
			this.AutoSize = true;
			this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			base.ColumnCount = 1;
			base.ColumnStyles.Add(new ColumnStyle());
			base.RowCount = 3;
			base.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.Controls.Add(this.listBox_0, 0, 0);
			base.Controls.Add(this.class584_0, 0, 1);
			base.Controls.Add(this.button_0, 0, 2);
			this.listBox_0.Dock = DockStyle.Fill;
			this.class584_0.Dock = DockStyle.Top;
			this.button_0.Dock = DockStyle.Left;
			this.button_0.AutoSize = true;
		}

		private bool method_5()
		{
			if (this.textControl_0 == null && base.TextControl != null)
			{
				try
				{
					this.textControl_0 = new TextControl();
					this.textControl_0.AllowDrag = false;
					this.textControl_0.AllowDrop = false;
					this.textControl_0.AllowUndo = false;
					this.textControl_0.CreateControl();
				}
				catch
				{
					return false;
				}
				this.textControl_0.PageUnit = MeasuringUnit.Twips;
				this.textControl_0.Location = base.TextControl.Location;
				this.textControl_0.Size = new Size(0, 0);
				this.textControl_0.ViewMode = ViewMode.PageView;
				this.textControl_0.Visible = false;
				this.textControl_0.PageMargins = new PageMargins(0.0, 0.0, 0.0, 0.0);
				return true;
			}
			return true;
		}

		private void method_6()
		{
			if (base.IsSidebarShown && !base.m_pntDpi.IsEmpty)
			{
				this.listBox_0.Items.Clear();
				this.int_1 = -1;
				this.int_0 = -1;
				this.listBox_0.Items.AddRange(this.method_2());
				this.method_3();
			}
		}

		private void method_7(int int_2, bool bool_1)
		{
			if (this.int_1 >= 0 && this.listBox_0.Items.Count > this.int_1)
			{
				(this.listBox_0.Items[this.int_1] as Class585).Boolean_1 = false;
				this.listBox_0.Invalidate(this.listBox_0.GetItemRectangle(this.int_1));
			}
			this.int_1 = int_2;
			if (int_2 >= 0)
			{
				Class585 @class = this.listBox_0.Items[int_2] as Class585;
				@class.Boolean_1 = true;
				this.listBox_0.SelectedItem = @class;
				this.listBox_0.Invalidate(this.listBox_0.GetItemRectangle(int_2));
				if (bool_1 && base.TextControl != null)
				{
					base.TextControl.InputFormat.StyleName = @class.Text;
				}
			}
		}

		private void method_8(bool bool_1)
		{
			if (this.bool_0 != (this.bool_0 = bool_1))
			{
				this.listBox_0.ItemHeight = (this.bool_0 ? (this.size_0.Height + Class517.smethod_45(8, base.m_pntDpi.X)) : this.size_1.Height);
				this.listBox_0.Width = 1;
			}
		}

		private void method_9(int int_2, bool bool_1)
		{
			int num = this.int_0;
			if (num != (this.int_0 = int_2))
			{
				if (this.int_0 >= 0)
				{
					(this.listBox_0.Items[this.int_0] as Class585).Boolean_2 = false;
					(this.listBox_0.Items[this.int_0] as Class585).Boolean_0 = true;
					this.listBox_0.SelectedIndex = this.int_0;
					this.listBox_0.Invalidate(this.listBox_0.GetItemRectangle(this.int_0));
				}
				if (num >= 0 && this.listBox_0.Items.Count > num)
				{
					(this.listBox_0.Items[num] as Class585).Boolean_2 = false;
					(this.listBox_0.Items[num] as Class585).Boolean_0 = false;
					this.listBox_0.Invalidate(this.listBox_0.GetItemRectangle(num));
				}
			}
			else if (bool_1 && this.int_0 >= 0)
			{
				(this.listBox_0.Items[this.int_0] as Class585).Boolean_2 = false;
				(this.listBox_0.Items[this.int_0] as Class585).Boolean_0 = true;
				this.listBox_0.Invalidate(this.listBox_0.GetItemRectangle(this.int_0));
			}
		}
	}
}
