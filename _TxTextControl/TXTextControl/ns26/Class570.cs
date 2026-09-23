using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Resources;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ns21;
using TXTextControl.Windows.Forms.Ribbon;
using TXTextControl;
using TXTextControl.Windows.Forms;

namespace ns26
{
	internal class Class570 : ContentPanel
	{
		internal class Control16 : Control
		{
			private VisualStyleRenderer visualStyleRenderer_0;

			private System.Drawing.Image image_0;

			private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

			private ImageAttributes imageAttributes_0;

			private Rectangle rectangle_0;

			private PointF pointF_0 = PointF.Empty;

			private bool bool_0;

			internal Control16(bool bool_1)
			{
				base.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
				try
				{
					this.visualStyleRenderer_0 = new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal);
				}
				catch
				{
				}
				this.bool_0 = bool_1;
				this.imageAttributes_0 = Class517.smethod_20((!base.Enabled) ? 65 : 0);
				this.BackColor = Color.Transparent;
				this.Dock = DockStyle.Right;
			}

			internal void method_0(PointF pointF_1)
			{
				if (this.pointF_0.X != pointF_1.X || this.pointF_0.Y != pointF_1.Y)
				{
					this.pointF_0 = pointF_1;
					this.image_0 = (this.bool_0 ? Class517.Bitmap_1 : Class517.Bitmap_0);
					this.rectangle_0 = new Rectangle(size: this.MaximumSize = (this.MinimumSize = Class517.smethod_48(Class519.Class542.Class543.Size_3, this.pointF_0)), location: new Point(0, 0));
					base.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_3, this.pointF_0);
				}
			}

			protected override void OnEnabledChanged(EventArgs eventArgs_0)
			{
				this.imageAttributes_0 = Class517.smethod_20((!base.Enabled) ? 65 : 0);
				base.OnEnabledChanged(eventArgs_0);
			}

			protected override void OnMouseEnter(EventArgs eventargs)
			{
				if (this.visualStyleRenderer_0 != null)
				{
					this.visualStyleRenderer_0 = new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Hot);
					base.Invalidate();
				}
				base.OnMouseEnter(eventargs);
			}

			protected override void OnMouseLeave(EventArgs eventargs)
			{
				if (this.visualStyleRenderer_0 != null)
				{
					this.visualStyleRenderer_0 = new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal);
					base.Invalidate();
				}
				base.OnMouseLeave(eventargs);
			}

			protected override void OnPaint(PaintEventArgs pea)
			{
				Rectangle bounds = new Rectangle(0, 0, base.Width, base.Height);
				if (this.visualStyleRenderer_0 != null)
				{
					this.visualStyleRenderer_0.DrawBackground(pea.Graphics, bounds);
				}
				pea.Graphics.DrawImage(this.image_0, this.rectangle_0, 0, 0, this.image_0.Width, this.image_0.Height, GraphicsUnit.Pixel, this.imageAttributes_0);
				base.OnPaint(pea);
			}
		}

		private bool bool_0;

		private Label label_0;

		internal TextBox textBox_0;

		private Label label_1;

		private TextBox textBox_1;

		private CheckBox checkBox_0;

		private Label label_2;

		private Label label_3;

		private TableLayoutPanel tableLayoutPanel_0;

		private TableLayoutPanel tableLayoutPanel_1;

		private CheckBox checkBox_1;

		private CheckBox checkBox_2;

		private Control control_0;

		private CheckBox checkBox_3;

		private CheckBox checkBox_4;

		private CheckBox checkBox_5;

		private TableLayoutPanel tableLayoutPanel_2;

		private Control control_1;

		private System.Windows.Forms.Button button_0;

		private System.Windows.Forms.Button button_1;

		internal System.Windows.Forms.Button button_2;

		internal Class570(Enum140 enum140_0, TextControl textControl_0, bool bool_1, Sidebar.SidebarContentLayout sidebarContentLayout_0, PointF pointF_0)
			: base(enum140_0, textControl_0, bool_1, sidebarContentLayout_0, pointF_0)
		{
			if (this.bool_0)
			{
				this.label_0.Text = base.m_rm.GetString("ID_REPLACE_FIND_WHAT");
				this.label_1.Text = base.m_rm.GetString("ID_REPLACE_REPLACE_WITH");
				this.label_2.Text = ((enum140_0 == Enum140.const_1) ? base.m_rm.GetString("ID_REPLACE_FIND_OPTIONS_HORIZONTAL") : base.m_rm.GetString("ID_REPLACE_FIND_OPTIONS"));
				this.checkBox_1.Text = base.m_rm.GetString("ID_REPLACE_MATCH_CASE");
				this.checkBox_2.Text = base.m_rm.GetString("ID_REPLACE_MATCH_WHOLE_WORD");
				this.checkBox_3.Text = base.m_rm.GetString("ID_REPLACE_SEARCH_IN_MAIN_TEXT");
				this.checkBox_4.Text = base.m_rm.GetString("ID_REPLACE_SEARCH_IN_TEXT_FRAMES");
				this.checkBox_5.Text = base.m_rm.GetString("ID_REPLACE_SEARCH_IN_HEADER_FOOTERS");
				this.button_0.Text = base.m_rm.GetString("ID_REPLACE_REPLACE");
				this.button_1.Text = base.m_rm.GetString("ID_REPLACE_REPLACE_ALL");
				this.button_2.Text = base.m_rm.GetString("ID_REPLACE_CANCEL");
			}
			else
			{
				this.label_0.Text = base.m_rm.GetString("ID_FIND_FIND_WHAT");
				this.label_2.Text = ((enum140_0 == Enum140.const_1) ? base.m_rm.GetString("ID_FIND_FIND_OPTIONS_HORIZONTAL") : base.m_rm.GetString("ID_FIND_FIND_OPTIONS"));
				this.checkBox_1.Text = base.m_rm.GetString("ID_FIND_MATCH_CASE");
				this.checkBox_2.Text = base.m_rm.GetString("ID_FIND_MATCH_WHOLE_WORD");
				this.checkBox_3.Text = base.m_rm.GetString("ID_FIND_SEARCH_IN_MAIN_TEXT");
				this.checkBox_4.Text = base.m_rm.GetString("ID_FIND_SEARCH_IN_TEXT_FRAMES");
				this.checkBox_5.Text = base.m_rm.GetString("ID_FIND_SEARCH_IN_HEADER_FOOTERS");
				this.button_2.Text = base.m_rm.GetString("ID_FIND_CANCEL");
			}
			this.method_1();
			this.method_2();
		}

		internal override void DoLayout()
		{
			base.ResumeLayout(performLayout: false);
			base.PerformLayout();
			this.tableLayoutPanel_0.ResumeLayout(performLayout: false);
			this.tableLayoutPanel_0.PerformLayout();
			this.tableLayoutPanel_1.ResumeLayout(performLayout: false);
			this.tableLayoutPanel_1.PerformLayout();
			this.tableLayoutPanel_2.ResumeLayout(performLayout: false);
			this.tableLayoutPanel_2.PerformLayout();
		}

		internal override void DoSuspendLayout()
		{
			base.SuspendLayout();
			this.tableLayoutPanel_0.SuspendLayout();
			this.tableLayoutPanel_1.SuspendLayout();
			this.tableLayoutPanel_2.SuspendLayout();
		}

		internal override void InitializeItems()
		{
			this.bool_0 = base.m_sclContentLayout == Sidebar.SidebarContentLayout.Replace;
			base.Name = "TXITEM_MainPanel";
			this.AutoSize = true;
			this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.label_0 = new Label
			{
				Name = Sidebar.FindAndReplaceItem.TXITEM_FindWhatLabel.ToString(),
				AutoSize = true,
				Dock = DockStyle.Top,
				TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			};
			this.textBox_0 = new TextBox
			{
				Name = Sidebar.FindAndReplaceItem.TXITEM_FindWhatTextBox.ToString(),
				Dock = DockStyle.Top
			};
			this.textBox_0.TextChanged += textBox_0_TextChanged;
			this.label_3 = new Label
			{
				Name = Sidebar.FindAndReplaceItem.TXITEM_FindOptionsSeparator.ToString(),
				AutoSize = false,
				BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
			};
			this.label_3.MinimumSize = Class519.Class542.Class543.Size_0;
			this.tableLayoutPanel_0 = new TableLayoutPanel
			{
				AutoSize = true,
				AutoSizeMode = AutoSizeMode.GrowAndShrink
			};
			this.checkBox_0 = new Sidebar.Class584
			{
				Name = Sidebar.FindAndReplaceItem.TXITEM_FindOptionsToggleItem.ToString(),
				Checked = false,
				Appearance = Appearance.Button,
				FlatStyle = FlatStyle.Flat
			};
			this.checkBox_0.Text = "";
			this.checkBox_0.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.checkBox_0.Image = (this.checkBox_0.Checked ? Class517.Bitmap_7 : Class517.Bitmap_8);
			this.checkBox_0.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.checkBox_0.CheckedChanged += checkBox_0_CheckedChanged;
			this.label_2 = new Label
			{
				Name = Sidebar.FindAndReplaceItem.TXITEM_FindOptionsLabel.ToString(),
				AutoSize = true,
				Dock = DockStyle.Top,
				TextAlign = System.Drawing.ContentAlignment.MiddleLeft
			};
			this.tableLayoutPanel_1 = new TableLayoutPanel
			{
				AutoSize = true,
				AutoSizeMode = AutoSizeMode.GrowAndShrink,
				Visible = this.checkBox_0.Checked
			};
			this.tableLayoutPanel_1.Paint += tableLayoutPanel_1_Paint;
			this.checkBox_1 = new Sidebar.Class584
			{
				Name = Sidebar.FindAndReplaceItem.TXITEM_MatchCase.ToString(),
				AutoSize = true,
				BackColor = Color.Transparent,
				Dock = DockStyle.Top,
				FlatStyle = FlatStyle.System
			};
			this.checkBox_2 = new Sidebar.Class584
			{
				Name = Sidebar.FindAndReplaceItem.TXITEM_MatchWholeWord.ToString(),
				AutoSize = true,
				BackColor = Color.Transparent,
				Dock = DockStyle.Top,
				FlatStyle = FlatStyle.System
			};
			this.control_0 = ((base.m_cpaPanelAlignment == Enum140.const_1) ? ((Control)new Control16(bool_1: true)) : ((Control)new Sidebar.Class584
			{
				AutoSize = true,
				BackColor = Color.Transparent,
				Dock = DockStyle.Top,
				FlatStyle = FlatStyle.System
			}));
			this.control_0.Name = Sidebar.FindAndReplaceItem.TXITEM_SearchUp.ToString();
			this.checkBox_3 = new Sidebar.Class584
			{
				Name = Sidebar.FindAndReplaceItem.TXITEM_SearchInMainText.ToString(),
				AutoSize = true,
				BackColor = Color.Transparent,
				Dock = DockStyle.Top,
				Checked = true,
				FlatStyle = FlatStyle.System
			};
			this.checkBox_3.CheckedChanged += checkBox_5_CheckedChanged;
			this.checkBox_4 = new Sidebar.Class584
			{
				Name = Sidebar.FindAndReplaceItem.TXITEM_SearchInTextFrames.ToString(),
				AutoSize = true,
				BackColor = Color.Transparent,
				Dock = DockStyle.Top,
				FlatStyle = FlatStyle.System
			};
			this.checkBox_4.CheckedChanged += checkBox_5_CheckedChanged;
			this.checkBox_5 = new Sidebar.Class584
			{
				Name = Sidebar.FindAndReplaceItem.TXITEM_SearchInHeaderFooters.ToString(),
				AutoSize = true,
				BackColor = Color.Transparent,
				Dock = DockStyle.Top,
				FlatStyle = FlatStyle.System
			};
			this.checkBox_5.CheckedChanged += checkBox_5_CheckedChanged;
			this.tableLayoutPanel_2 = new TableLayoutPanel
			{
				AutoSize = true,
				AutoSizeMode = AutoSizeMode.GrowAndShrink,
				Dock = DockStyle.Top
			};
			if (base.m_cpaPanelAlignment == Enum140.const_1)
			{
				this.control_1 = new Control16(bool_1: false);
			}
			else
			{
				this.control_1 = new System.Windows.Forms.Button
				{
					AutoSize = true,
					AutoSizeMode = AutoSizeMode.GrowAndShrink,
					Dock = DockStyle.Top,
					UseVisualStyleBackColor = true,
					Enabled = false
				};
			}
			this.control_1.Name = Sidebar.FindAndReplaceItem.TXITEM_FindNext.ToString();
			this.control_1.Click += control_1_Click;
			this.button_2 = new System.Windows.Forms.Button
			{
				Name = Sidebar.FindAndReplaceItem.TXITEM_Cancel.ToString(),
				AutoSize = true,
				AutoSizeMode = AutoSizeMode.GrowAndShrink,
				Dock = DockStyle.Top,
				Visible = false,
				UseVisualStyleBackColor = true
			};
			this.button_2.Click += button_2_Click;
			base.m_dicItems.Add(this.label_0.Name, this.label_0);
			base.m_dicItems.Add(this.textBox_0.Name, this.textBox_0);
			base.m_dicItems.Add(this.checkBox_0.Name, this.checkBox_0);
			base.m_dicItems.Add(this.label_2.Name, this.label_2);
			base.m_dicItems.Add(this.label_3.Name, this.label_3);
			base.m_dicItems.Add(this.checkBox_1.Name, this.checkBox_1);
			base.m_dicItems.Add(this.checkBox_2.Name, this.checkBox_2);
			base.m_dicItems.Add(this.control_0.Name, this.control_0);
			base.m_dicItems.Add(this.checkBox_3.Name, this.checkBox_3);
			base.m_dicItems.Add(this.checkBox_4.Name, this.checkBox_4);
			base.m_dicItems.Add(this.checkBox_5.Name, this.checkBox_5);
			base.m_dicItems.Add(this.control_1.Name, this.control_1);
			base.m_dicItems.Add(this.button_2.Name, this.button_2);
			if (this.bool_0)
			{
				this.label_1 = new Label
				{
					Name = Sidebar.FindAndReplaceItem.TXITEM_ReplaceWithLabel.ToString(),
					AutoSize = true,
					Dock = DockStyle.Top,
					TextAlign = System.Drawing.ContentAlignment.MiddleLeft
				};
				this.textBox_1 = new TextBox
				{
					Name = Sidebar.FindAndReplaceItem.TXITEM_ReplaceWithTextBox.ToString(),
					Dock = DockStyle.Top
				};
				this.button_0 = new System.Windows.Forms.Button
				{
					Name = Sidebar.FindAndReplaceItem.TXITEM_Replace.ToString(),
					AutoSize = true,
					AutoSizeMode = AutoSizeMode.GrowAndShrink,
					Dock = DockStyle.Top,
					UseVisualStyleBackColor = true,
					Enabled = false
				};
				this.button_0.Click += button_0_Click;
				this.button_1 = new System.Windows.Forms.Button
				{
					Name = Sidebar.FindAndReplaceItem.TXITEM_ReplaceAll.ToString(),
					AutoSize = true,
					AutoSizeMode = AutoSizeMode.GrowAndShrink,
					Dock = DockStyle.Top,
					UseVisualStyleBackColor = true,
					Enabled = false
				};
				this.button_1.Click += button_1_Click;
				base.m_dicItems.Add(this.label_1.Name, this.label_1);
				base.m_dicItems.Add(this.textBox_1.Name, this.textBox_1);
				base.m_dicItems.Add(this.button_0.Name, this.button_0);
				base.m_dicItems.Add(this.button_1.Name, this.button_1);
			}
		}

		internal override void AwareOfDPI_Intialize()
		{
			if (!base.m_pntDpi.IsEmpty)
			{
				CheckBox checkBox = this.checkBox_1;
				CheckBox checkBox2 = this.checkBox_2;
				CheckBox checkBox3 = this.checkBox_3;
				CheckBox checkBox4 = this.checkBox_4;
				this.checkBox_5.FlatStyle = FlatStyle.Standard;
				checkBox4.FlatStyle = FlatStyle.Standard;
				checkBox3.FlatStyle = FlatStyle.Standard;
				checkBox2.FlatStyle = FlatStyle.Standard;
				checkBox.FlatStyle = FlatStyle.Standard;
				CheckBox checkBox5 = this.checkBox_1;
				CheckBox checkBox6 = this.checkBox_2;
				CheckBox checkBox7 = this.checkBox_3;
				CheckBox checkBox8 = this.checkBox_4;
				this.checkBox_5.FlatStyle = FlatStyle.System;
				checkBox8.FlatStyle = FlatStyle.System;
				checkBox7.FlatStyle = FlatStyle.System;
				checkBox6.FlatStyle = FlatStyle.System;
				checkBox5.FlatStyle = FlatStyle.System;
				if (this.control_0 is CheckBox)
				{
					(this.control_0 as CheckBox).FlatStyle = FlatStyle.Standard;
					(this.control_0 as CheckBox).FlatStyle = FlatStyle.System;
				}
				base.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_1, base.m_pntDpi);
				Size size3 = (this.textBox_0.Size = (this.textBox_0.MinimumSize = Class517.smethod_48(Class519.Class542.Class543.Size_4, base.m_pntDpi)));
				Size size6 = (this.checkBox_0.MaximumSize = (this.checkBox_0.MinimumSize = Class517.smethod_48(Class519.Class542.Size_4, base.m_pntDpi)));
				if (base.m_cpaPanelAlignment != Enum140.const_1)
				{
					Size size9 = (this.control_1.Size = (this.control_1.MinimumSize = Class517.smethod_48(Class519.Class542.Class543.Size_6, base.m_pntDpi)));
				}
				Size size12 = (this.button_2.Size = (this.button_2.MinimumSize = Class517.smethod_48(Class519.Class542.Class543.Size_7, base.m_pntDpi)));
				if (this.bool_0)
				{
					Size size15 = (this.textBox_1.Size = (this.textBox_1.MinimumSize = Class517.smethod_48(Class519.Class542.Class543.Size_5, base.m_pntDpi)));
					Size size18 = (this.button_0.Size = (this.button_0.MinimumSize = Class517.smethod_48(Class519.Class542.Class543.Size_8, base.m_pntDpi)));
					Size size21 = (this.button_1.Size = (this.button_1.MinimumSize = Class517.smethod_48(Class519.Class542.Class543.Size_9, base.m_pntDpi)));
				}
			}
		}

		internal override void SetHorizontalAlignment()
		{
			base.Controls.Clear();
			base.ColumnStyles.Clear();
			base.RowStyles.Clear();
			this.tableLayoutPanel_0.Controls.Clear();
			this.tableLayoutPanel_0.ColumnStyles.Clear();
			this.tableLayoutPanel_0.RowStyles.Clear();
			this.tableLayoutPanel_1.Controls.Clear();
			this.tableLayoutPanel_1.ColumnStyles.Clear();
			this.tableLayoutPanel_1.RowStyles.Clear();
			this.tableLayoutPanel_2.Controls.Clear();
			this.tableLayoutPanel_2.ColumnStyles.Clear();
			this.tableLayoutPanel_2.RowStyles.Clear();
			int num = (this.bool_0 ? 5 : 0);
			base.ColumnCount = 5 + num;
			for (int i = 0; i < base.ColumnCount; i++)
			{
				base.ColumnStyles.Add(new ColumnStyle());
			}
			base.RowCount = 1;
			base.RowStyles.Add(new RowStyle());
			base.Controls.Add(this.label_0, 0, 0);
			base.SetColumnSpan(this.label_0, 1);
			base.Controls.Add(this.textBox_0, 1, 0);
			base.SetColumnSpan(this.textBox_0, 1);
			if (this.control_0 is CheckBox)
			{
				this.control_0 = new Control16(bool_1: true);
				this.method_2();
			}
			base.Controls.Add(this.control_0, 2, 0);
			if (this.control_1 is System.Windows.Forms.Button)
			{
				this.control_1 = new Control16(bool_1: false);
				this.method_1();
			}
			base.Controls.Add(this.control_1, 3, 0);
			if (this.bool_0)
			{
				base.Controls.Add(this.label_1, 5, 0);
				base.SetColumnSpan(this.label_1, 1);
				base.Controls.Add(this.textBox_1, 6, 0);
				base.SetColumnSpan(this.textBox_1, 1);
				base.Controls.Add(this.button_0, 7, 0);
				base.Controls.Add(this.button_1, 8, 0);
			}
			base.Controls.Add(this.tableLayoutPanel_0, 4 + num, 0);
			base.SetColumnSpan(this.tableLayoutPanel_0, 1);
			this.label_3.Dock = DockStyle.Left;
			this.tableLayoutPanel_0.ColumnCount = 4;
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_0.Controls.Add(this.label_3, 0, 0);
			base.SetColumnSpan(this.label_3, 1);
			this.tableLayoutPanel_0.Controls.Add(this.checkBox_0, 1, 0);
			base.SetColumnSpan(this.checkBox_0, 1);
			this.tableLayoutPanel_0.Controls.Add(this.label_2, 2, 0);
			base.SetColumnSpan(this.label_2, 1);
			this.label_2.Text = ((base.m_cpaPanelAlignment == Enum140.const_1) ? base.m_rm.GetString(this.bool_0 ? "ID_REPLACE_FIND_OPTIONS_HORIZONTAL" : "ID_FIND_FIND_OPTIONS_HORIZONTAL") : base.m_rm.GetString(this.bool_0 ? "ID_REPLACE_FIND_OPTIONS" : "ID_FIND_FIND_OPTIONS"));
			this.tableLayoutPanel_0.Controls.Add(this.tableLayoutPanel_1, 3, 0);
			this.tableLayoutPanel_0.SetColumnSpan(this.tableLayoutPanel_1, 1);
			this.tableLayoutPanel_1.Visible = this.checkBox_0.Checked;
			this.tableLayoutPanel_1.ColumnCount = 5;
			this.tableLayoutPanel_1.RowCount = 1;
			for (int j = 0; j < this.tableLayoutPanel_1.ColumnCount; j++)
			{
				this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle());
			}
			this.tableLayoutPanel_1.Controls.Add(this.checkBox_1, 0, 0);
			base.SetColumnSpan(this.checkBox_1, 1);
			this.tableLayoutPanel_1.Controls.Add(this.checkBox_2, 1, 0);
			base.SetColumnSpan(this.checkBox_2, 1);
			this.tableLayoutPanel_1.Controls.Add(this.checkBox_3, 2, 0);
			base.SetColumnSpan(this.checkBox_3, 1);
			this.tableLayoutPanel_1.Controls.Add(this.checkBox_4, 3, 0);
			base.SetColumnSpan(this.checkBox_4, 1);
			this.tableLayoutPanel_1.Controls.Add(this.checkBox_5, 4, 0);
			base.SetColumnSpan(this.checkBox_5, 1);
			this.method_3();
			base.SetHorizontalAlignment();
		}

		internal override void AwareOfDPI_Horizontal()
		{
			base.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_0, base.m_pntDpi);
			this.label_3.MaximumSize = Class517.smethod_48(Class519.Class542.Class543.Size_2, base.m_pntDpi);
			this.label_0.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_4, base.m_pntDpi);
			this.textBox_0.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_5, base.m_pntDpi);
			this.control_0.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_6, base.m_pntDpi);
			this.control_1.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_7, base.m_pntDpi);
			this.tableLayoutPanel_0.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_8, base.m_pntDpi);
			this.label_3.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_9, base.m_pntDpi);
			this.checkBox_0.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_10, base.m_pntDpi);
			this.checkBox_0.Image = (this.checkBox_0.Checked ? Class517.Bitmap_7 : Class517.Bitmap_8);
			this.label_2.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_11, base.m_pntDpi);
			this.tableLayoutPanel_1.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_12, base.m_pntDpi);
			this.checkBox_1.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_13, base.m_pntDpi);
			this.checkBox_2.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_14, base.m_pntDpi);
			this.checkBox_3.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_15, base.m_pntDpi);
			this.checkBox_4.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_16, base.m_pntDpi);
			this.checkBox_5.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_17, base.m_pntDpi);
			this.button_2.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_18, base.m_pntDpi);
			if (this.bool_0)
			{
				this.label_1.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_19, base.m_pntDpi);
				this.textBox_1.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_20, base.m_pntDpi);
				this.button_0.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_21, base.m_pntDpi);
				this.button_1.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_22, base.m_pntDpi);
			}
			this.method_0(base.m_pntDpi);
		}

		internal override void SetVerticalAlignment()
		{
			base.Controls.Clear();
			base.ColumnStyles.Clear();
			base.RowStyles.Clear();
			this.tableLayoutPanel_0.Controls.Clear();
			this.tableLayoutPanel_0.ColumnStyles.Clear();
			this.tableLayoutPanel_0.RowStyles.Clear();
			this.tableLayoutPanel_1.Controls.Clear();
			this.tableLayoutPanel_1.ColumnStyles.Clear();
			this.tableLayoutPanel_1.RowStyles.Clear();
			this.tableLayoutPanel_2.Controls.Clear();
			this.tableLayoutPanel_2.ColumnStyles.Clear();
			this.tableLayoutPanel_2.RowStyles.Clear();
			base.ColumnCount = 3;
			int num = (this.bool_0 ? 2 : 0);
			base.RowCount = 10 + num;
			base.ColumnStyles.Add(new ColumnStyle());
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			base.ColumnStyles.Add(new ColumnStyle());
			for (int i = 0; i < base.RowCount; i++)
			{
				base.RowStyles.Add(new RowStyle());
			}
			base.Controls.Add(this.label_0, 0, 0);
			base.SetColumnSpan(this.label_0, 3);
			base.Controls.Add(this.textBox_0, 0, 1);
			base.SetColumnSpan(this.textBox_0, 3);
			if (this.bool_0)
			{
				base.Controls.Add(this.label_1, 0, 2);
				base.SetColumnSpan(this.label_1, 3);
				base.Controls.Add(this.textBox_1, 0, 3);
				base.SetColumnSpan(this.textBox_1, 3);
			}
			base.Controls.Add(this.label_2, 0, 2 + num);
			base.SetColumnSpan(this.label_2, 1);
			this.label_2.Text = ((base.m_cpaPanelAlignment == Enum140.const_1) ? base.m_rm.GetString(this.bool_0 ? "ID_REPLACE_FIND_OPTIONS_HORIZONTAL" : "ID_FIND_FIND_OPTIONS_HORIZONTAL") : base.m_rm.GetString(this.bool_0 ? "ID_REPLACE_FIND_OPTIONS" : "ID_FIND_FIND_OPTIONS"));
			this.label_3.Dock = DockStyle.Top;
			base.Controls.Add(this.label_3, 1, 2 + num);
			base.SetColumnSpan(this.label_3, 2);
			base.Controls.Add(this.checkBox_1, 0, 3 + num);
			base.SetColumnSpan(this.checkBox_1, 3);
			base.Controls.Add(this.checkBox_2, 0, 4 + num);
			base.SetColumnSpan(this.checkBox_2, 3);
			if (this.control_0 is Control16)
			{
				this.control_0 = new Sidebar.Class584
				{
					AutoSize = true,
					BackColor = Color.Transparent,
					Dock = DockStyle.Top,
					FlatStyle = FlatStyle.System
				};
				this.method_2();
			}
			base.Controls.Add(this.control_0, 0, 5 + num);
			base.SetColumnSpan(this.control_0, 3);
			base.Controls.Add(this.checkBox_3, 0, 6 + num);
			base.SetColumnSpan(this.checkBox_3, 3);
			base.Controls.Add(this.checkBox_4, 0, 7 + num);
			base.SetColumnSpan(this.checkBox_4, 3);
			base.Controls.Add(this.checkBox_5, 0, 8 + num);
			base.SetColumnSpan(this.checkBox_5, 3);
			this.tableLayoutPanel_2.ColumnCount = 4;
			this.tableLayoutPanel_2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_2.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_2.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_2.ColumnStyles.Add(new ColumnStyle());
			if (this.bool_0)
			{
				if (this.control_1 is Control16)
				{
					this.control_1 = new System.Windows.Forms.Button
					{
						AutoSize = true,
						AutoSizeMode = AutoSizeMode.GrowAndShrink,
						Dock = DockStyle.Top,
						UseVisualStyleBackColor = true
					};
					this.method_1();
				}
				if (this.button_2.Visible)
				{
					this.tableLayoutPanel_2.Controls.Add(this.control_1, 1, 0);
					this.tableLayoutPanel_2.Controls.Add(this.button_0, 2, 0);
					this.tableLayoutPanel_2.Controls.Add(this.button_1, 1, 1);
					this.tableLayoutPanel_2.Controls.Add(this.button_2, 2, 1);
				}
				else
				{
					this.tableLayoutPanel_2.Controls.Add(this.button_0, 1, 0);
					this.tableLayoutPanel_2.Controls.Add(this.button_1, 2, 0);
					this.tableLayoutPanel_2.Controls.Add(this.control_1, 3, 0);
				}
			}
			else
			{
				if (this.control_1 is Control16)
				{
					this.control_1 = new System.Windows.Forms.Button
					{
						AutoSize = true,
						AutoSizeMode = AutoSizeMode.GrowAndShrink,
						Dock = DockStyle.Top,
						UseVisualStyleBackColor = true
					};
					this.method_1();
				}
				this.tableLayoutPanel_2.Controls.Add(this.control_1, 1, 0);
				this.tableLayoutPanel_2.Controls.Add(this.button_2, 2, 0);
				base.Controls.Add(this.tableLayoutPanel_2, 1, 3);
			}
			base.Controls.Add(this.tableLayoutPanel_2, 0, 9 + num);
			base.SetColumnSpan(this.tableLayoutPanel_2, 3);
			this.method_3();
			base.SetVerticalAlignment();
		}

		internal override void AwareOfDPI_Vertical()
		{
			base.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_1, base.m_pntDpi);
			this.label_3.MaximumSize = Class517.smethod_48(Class519.Class542.Class543.Size_1, base.m_pntDpi);
			this.label_0.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_23, base.m_pntDpi);
			this.textBox_0.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_24, base.m_pntDpi);
			this.label_2.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_25, base.m_pntDpi);
			this.label_3.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_26, base.m_pntDpi);
			this.checkBox_1.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_27, base.m_pntDpi);
			this.checkBox_2.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_28, base.m_pntDpi);
			this.control_0.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_29, base.m_pntDpi);
			this.checkBox_3.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_30, base.m_pntDpi);
			this.checkBox_4.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_31, base.m_pntDpi);
			this.checkBox_5.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_32, base.m_pntDpi);
			this.tableLayoutPanel_2.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_33, base.m_pntDpi);
			this.control_1.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_34, base.m_pntDpi);
			this.button_2.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_35, base.m_pntDpi);
			if (this.control_1 is Control16)
			{
				Size size3 = (this.control_1.Size = (this.control_1.MinimumSize = Class517.smethod_48(Class519.Class542.Class543.Size_6, base.m_pntDpi)));
			}
			if (this.bool_0)
			{
				this.label_1.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_36, base.m_pntDpi);
				this.textBox_1.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_37, base.m_pntDpi);
				this.button_0.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_38, base.m_pntDpi);
				this.button_1.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_39, base.m_pntDpi);
			}
			this.method_0(base.m_pntDpi);
		}

		internal override void SetDialogAlignment()
		{
			base.Controls.Clear();
			base.ColumnStyles.Clear();
			base.RowStyles.Clear();
			this.tableLayoutPanel_0.Controls.Clear();
			this.tableLayoutPanel_0.ColumnStyles.Clear();
			this.tableLayoutPanel_0.RowStyles.Clear();
			this.tableLayoutPanel_1.Controls.Clear();
			this.tableLayoutPanel_1.ColumnStyles.Clear();
			this.tableLayoutPanel_1.RowStyles.Clear();
			this.tableLayoutPanel_2.Controls.Clear();
			this.tableLayoutPanel_2.ColumnStyles.Clear();
			this.tableLayoutPanel_2.RowStyles.Clear();
			base.ColumnCount = 3;
			base.RowCount = (this.bool_0 ? 7 : 4);
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			base.ColumnStyles.Add(new ColumnStyle());
			base.ColumnStyles.Add(new ColumnStyle());
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel_0.Dock = DockStyle.Top;
			this.tableLayoutPanel_0.ColumnCount = 2;
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_0.RowCount = 2;
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle());
			this.label_2.Text = ((base.m_cpaPanelAlignment == Enum140.const_1) ? base.m_rm.GetString(this.bool_0 ? "ID_REPLACE_FIND_OPTIONS_HORIZONTAL" : "ID_FIND_FIND_OPTIONS_HORIZONTAL") : base.m_rm.GetString(this.bool_0 ? "ID_REPLACE_FIND_OPTIONS" : "ID_FIND_FIND_OPTIONS"));
			this.tableLayoutPanel_0.Controls.Add(this.label_2, 0, 0);
			this.label_3.Dock = DockStyle.Top;
			this.tableLayoutPanel_0.Controls.Add(this.label_3, 1, 0);
			this.tableLayoutPanel_0.SetColumnSpan(this.label_3, 1);
			this.tableLayoutPanel_1.Visible = true;
			this.tableLayoutPanel_1.ColumnCount = 2;
			this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_1.RowCount = 3;
			this.tableLayoutPanel_1.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel_1.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel_1.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel_1.Controls.Add(this.checkBox_1, 0, 0);
			this.tableLayoutPanel_1.SetColumnSpan(this.checkBox_1, 1);
			this.tableLayoutPanel_1.Controls.Add(this.checkBox_2, 0, 1);
			this.tableLayoutPanel_1.SetColumnSpan(this.checkBox_2, 1);
			if (this.control_0 is Control16)
			{
				this.control_0 = new Sidebar.Class584
				{
					AutoSize = true,
					BackColor = Color.Transparent,
					Dock = DockStyle.Top,
					FlatStyle = FlatStyle.System
				};
				this.method_2();
			}
			this.tableLayoutPanel_1.Controls.Add(this.control_0, 0, 2);
			this.tableLayoutPanel_1.SetColumnSpan(this.control_0, 1);
			this.tableLayoutPanel_1.Controls.Add(this.checkBox_3, 1, 0);
			this.tableLayoutPanel_1.SetColumnSpan(this.checkBox_3, 1);
			this.tableLayoutPanel_1.Controls.Add(this.checkBox_4, 1, 1);
			this.tableLayoutPanel_1.SetColumnSpan(this.checkBox_4, 1);
			this.tableLayoutPanel_1.Controls.Add(this.checkBox_5, 1, 2);
			this.tableLayoutPanel_1.SetColumnSpan(this.checkBox_5, 1);
			this.tableLayoutPanel_0.Controls.Add(this.tableLayoutPanel_1, 0, 1);
			this.tableLayoutPanel_0.SetColumnSpan(this.tableLayoutPanel_1, 2);
			base.Controls.Add(this.label_0, 0, 0);
			base.SetColumnSpan(this.label_0, 3);
			base.Controls.Add(this.textBox_0, 0, 1);
			base.SetColumnSpan(this.textBox_0, 3);
			this.tableLayoutPanel_2.ColumnCount = 3;
			this.tableLayoutPanel_2.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_2.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_2.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_2.RowCount = 2;
			this.tableLayoutPanel_2.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel_2.RowStyles.Add(new RowStyle());
			if (this.bool_0)
			{
				base.RowStyles.Add(new RowStyle());
				base.RowStyles.Add(new RowStyle());
				base.RowStyles.Add(new RowStyle());
				base.Controls.Add(this.label_1, 0, 2);
				base.SetColumnSpan(this.label_1, 3);
				base.Controls.Add(this.textBox_1, 0, 3);
				base.SetColumnSpan(this.textBox_1, 3);
				base.Controls.Add(this.tableLayoutPanel_0, 0, 4);
				base.SetColumnSpan(this.tableLayoutPanel_0, 3);
				if (this.control_1 is Control16)
				{
					this.control_1 = new System.Windows.Forms.Button
					{
						AutoSize = true,
						AutoSizeMode = AutoSizeMode.GrowAndShrink,
						Dock = DockStyle.Top,
						UseVisualStyleBackColor = true
					};
					this.method_1();
				}
				if (this.button_2.Visible)
				{
					this.tableLayoutPanel_2.Controls.Add(this.control_1, 0, 0);
					this.tableLayoutPanel_2.Controls.Add(this.button_0, 1, 0);
					this.tableLayoutPanel_2.Controls.Add(this.button_1, 0, 1);
					this.tableLayoutPanel_2.Controls.Add(this.button_2, 1, 1);
				}
				else
				{
					this.tableLayoutPanel_2.Controls.Add(this.button_0, 0, 0);
					this.tableLayoutPanel_2.Controls.Add(this.button_1, 1, 0);
					this.tableLayoutPanel_2.Controls.Add(this.control_1, 2, 0);
				}
				base.Controls.Add(this.tableLayoutPanel_2, 1, 5);
			}
			else
			{
				base.Controls.Add(this.tableLayoutPanel_0, 0, 2);
				base.SetColumnSpan(this.tableLayoutPanel_0, 3);
				if (this.control_1 is Control16)
				{
					this.control_1 = new System.Windows.Forms.Button
					{
						AutoSize = true,
						AutoSizeMode = AutoSizeMode.GrowAndShrink,
						Dock = DockStyle.Top,
						UseVisualStyleBackColor = true
					};
					this.method_1();
				}
				this.tableLayoutPanel_2.Controls.Add(this.control_1, 1, 0);
				this.tableLayoutPanel_2.Controls.Add(this.button_2, 2, 0);
				base.Controls.Add(this.tableLayoutPanel_2, 1, 3);
			}
			base.SetColumnSpan(this.tableLayoutPanel_2, 2);
			this.method_3();
			base.SetDialogAlignment();
		}

		internal override void AwareOfDPI_Dialog()
		{
			base.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_2, base.m_pntDpi);
			this.label_3.MaximumSize = Class517.smethod_48(Class519.Class542.Class543.Size_1, base.m_pntDpi);
			this.label_0.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_40, base.m_pntDpi);
			this.textBox_0.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_41, base.m_pntDpi);
			this.tableLayoutPanel_0.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_42, base.m_pntDpi);
			this.label_2.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_43, base.m_pntDpi);
			this.label_3.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_44, base.m_pntDpi);
			this.tableLayoutPanel_1.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_45, base.m_pntDpi);
			this.checkBox_1.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_46, base.m_pntDpi);
			this.checkBox_2.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_47, base.m_pntDpi);
			this.control_0.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_48, base.m_pntDpi);
			this.checkBox_3.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_49, base.m_pntDpi);
			this.checkBox_4.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_50, base.m_pntDpi);
			this.checkBox_5.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_51, base.m_pntDpi);
			this.tableLayoutPanel_2.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_52, base.m_pntDpi);
			this.control_1.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_53, base.m_pntDpi);
			this.button_2.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_54, base.m_pntDpi);
			if (this.control_1 is Control16)
			{
				Size size3 = (this.control_1.Size = (this.control_1.MinimumSize = Class517.smethod_48(Class519.Class542.Class543.Size_6, base.m_pntDpi)));
			}
			if (this.bool_0)
			{
				this.label_1.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_55, base.m_pntDpi);
				this.textBox_1.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_56, base.m_pntDpi);
				this.button_0.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_57, base.m_pntDpi);
				this.button_1.Margin = Class517.smethod_51(Class519.Class542.Class543.Padding_58, base.m_pntDpi);
			}
			this.method_0(base.m_pntDpi);
		}

		private void checkBox_5_CheckedChanged(object sender, EventArgs e)
		{
			this.method_3();
		}

		private void tableLayoutPanel_1_Paint(object sender, PaintEventArgs e)
		{
			if (base.m_cpaPanelAlignment == Enum140.const_1)
			{
				ControlPaint.DrawBorder(e.Graphics, new Rectangle(0, 0, this.tableLayoutPanel_1.Width, this.tableLayoutPanel_1.Height), SystemColors.ActiveBorder, ButtonBorderStyle.Solid);
			}
		}

		private void checkBox_0_CheckedChanged(object sender, EventArgs e)
		{
			if (base.m_cpaPanelAlignment == Enum140.const_1)
			{
				if (this.tableLayoutPanel_1.Visible = this.checkBox_0.Checked)
				{
					this.checkBox_0.Image = Class517.Bitmap_7;
				}
				else
				{
					this.checkBox_0.Image = Class517.Bitmap_8;
				}
			}
		}

		private void textBox_0_TextChanged(object sender, EventArgs e)
		{
			this.method_3();
		}

		private void control_1_Click(object sender, EventArgs e)
		{
			if (base.TextControl != null)
			{
				FindOptions findOptions = (FindOptions)0;
				if (this.checkBox_1.Checked)
				{
					findOptions |= FindOptions.MatchCase;
				}
				if (this.checkBox_2.Checked)
				{
					findOptions |= FindOptions.MatchWholeWord;
				}
				if (this.control_0 is CheckBox && (this.control_0 as CheckBox).Checked)
				{
					findOptions |= FindOptions.Reverse;
				}
				Enum55 @enum = (Enum55)0;
				if (this.checkBox_3.Checked)
				{
					@enum |= Enum55.flag_1;
				}
				if (this.checkBox_4.Checked)
				{
					@enum |= Enum55.flag_2;
				}
				if (this.checkBox_5.Checked)
				{
					@enum |= Enum55.flag_3;
				}
				base.TextControl.method_37(this.textBox_0.Text, findOptions, @enum);
			}
		}

		private void control_0_Click(object sender, EventArgs e)
		{
			if (base.TextControl != null)
			{
				FindOptions findOptions = FindOptions.Reverse;
				if (this.checkBox_1.Checked)
				{
					findOptions |= FindOptions.MatchCase;
				}
				if (this.checkBox_2.Checked)
				{
					findOptions |= FindOptions.MatchWholeWord;
				}
				Enum55 @enum = (Enum55)0;
				if (this.checkBox_3.Checked)
				{
					@enum |= Enum55.flag_1;
				}
				if (this.checkBox_4.Checked)
				{
					@enum |= Enum55.flag_2;
				}
				if (this.checkBox_5.Checked)
				{
					@enum |= Enum55.flag_3;
				}
				base.TextControl.method_37(this.textBox_0.Text, findOptions, @enum);
			}
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			if (base.TextControl != null)
			{
				FindOptions findOptions = (FindOptions)0;
				if (this.checkBox_1.Checked)
				{
					findOptions |= FindOptions.MatchCase;
				}
				if (this.checkBox_2.Checked)
				{
					findOptions |= FindOptions.MatchWholeWord;
				}
				if (this.control_0 is CheckBox && (this.control_0 as CheckBox).Checked)
				{
					findOptions |= FindOptions.Reverse;
				}
				Enum55 @enum = (Enum55)0;
				if (this.checkBox_3.Checked)
				{
					@enum |= Enum55.flag_1;
				}
				if (this.checkBox_4.Checked)
				{
					@enum |= Enum55.flag_2;
				}
				if (this.checkBox_5.Checked)
				{
					@enum |= Enum55.flag_3;
				}
				base.TextControl.method_38(this.textBox_0.Text, this.textBox_1.Text, findOptions, @enum);
			}
		}

		private void button_1_Click(object sender, EventArgs e)
		{
			if (base.TextControl != null)
			{
				FindOptions findOptions = FindOptions.Reverse;
				if (this.checkBox_1.Checked)
				{
					findOptions |= FindOptions.MatchCase;
				}
				if (this.checkBox_2.Checked)
				{
					findOptions |= FindOptions.MatchWholeWord;
				}
				Enum55 @enum = Enum55.flag_0;
				if (this.checkBox_3.Checked)
				{
					@enum |= Enum55.flag_1;
				}
				if (this.checkBox_4.Checked)
				{
					@enum |= Enum55.flag_2;
				}
				if (this.checkBox_5.Checked)
				{
					@enum |= Enum55.flag_3;
				}
				base.TextControl.method_38(this.textBox_0.Text, this.textBox_1.Text, findOptions, @enum);
			}
		}

		private void button_2_Click(object sender, EventArgs e)
		{
			if (base.Parent is Sidebar)
			{
				Sidebar sidebar = base.Parent as Sidebar;
				if (sidebar.Boolean_0 && sidebar.Parent is Form)
				{
					(sidebar.Parent as Form).Close();
				}
			}
		}

		private void method_0(PointF pointF_0)
		{
			if (this.control_0 is Control16)
			{
				(this.control_0 as Control16).method_0(pointF_0);
			}
			if (this.control_1 is Control16)
			{
				(this.control_1 as Control16).method_0(pointF_0);
			}
		}

		private void method_1()
		{
			this.control_1.Name = Sidebar.FindAndReplaceItem.TXITEM_FindNext.ToString();
			if (this.bool_0)
			{
				this.control_1.Text = base.m_rm.GetString("ID_REPLACE_FIND_NEXT");
			}
			else
			{
				this.control_1.Text = base.m_rm.GetString("ID_FIND_FIND_NEXT");
			}
			this.control_1.Click -= control_1_Click;
			this.control_1.Click += control_1_Click;
		}

		private void method_2()
		{
			this.control_0.Name = Sidebar.FindAndReplaceItem.TXITEM_SearchUp.ToString();
			if (this.bool_0)
			{
				this.control_0.Text = base.m_rm.GetString("ID_REPLACE_SEARCH_UP");
			}
			else
			{
				this.control_0.Text = base.m_rm.GetString("ID_FIND_SEARCH_UP");
			}
			if (this.control_0 is Control16)
			{
				this.control_0.Click -= control_0_Click;
				this.control_0.Click += control_0_Click;
			}
		}

		private void method_3()
		{
			bool flag = !this.checkBox_3.Checked && !this.checkBox_4.Checked && !this.checkBox_5.Checked;
			bool flag2 = this.textBox_0.Text.Length > 0;
			this.control_1.Enabled = !flag && flag2;
			this.control_0.Enabled = base.m_cpaPanelAlignment != Enum140.const_1 || this.control_1.Enabled;
			if (this.bool_0)
			{
				System.Windows.Forms.Button button = this.button_0;
				bool enabled2 = (this.button_1.Enabled = this.control_1.Enabled);
				button.Enabled = enabled2;
			}
		}
	}
}
