using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns21;
using TXTextControl.Windows.Forms.Ribbon;
using TXTextControl;
using TXTextControl.Windows.Forms;

namespace ns26
{
	internal class Class568 : ContentPanel
	{
		internal class Class574
		{
			[CompilerGenerated]
			private bool bool_0;

			[CompilerGenerated]
			private string string_0;

			internal bool Boolean_0
			{
				[CompilerGenerated]
				get
				{
					return this.bool_0;
				}
				[CompilerGenerated]
				set
				{
					this.bool_0 = value;
				}
			}

			internal string String_0
			{
				[CompilerGenerated]
				get
				{
					return this.string_0;
				}
				[CompilerGenerated]
				set
				{
					this.string_0 = value;
				}
			}

			internal Class574(string string_1)
			{
				this.String_0 = string_1;
			}

			public override string ToString()
			{
				return this.String_0;
			}
		}

		internal class Control15 : TextControl
		{
			private ResourceManager resourceManager_1 = new ResourceManager(typeof(TextControlCore));

			private List<RelatedFormField> list_0 = new List<RelatedFormField>();

			private Color color_3 = Color.FromArgb(60, 0, 0, 255);

			private Color color_4 = Color.FromArgb(60, 0, 255, 0);

			private bool bool_20;

			private bool bool_21;

			private List<IConditionalInstructionElement> list_1 = new List<IConditionalInstructionElement>();

			private int int_4 = -1;

			private string string_3;

			private ContentPanel contentPanel_0;

			internal Color Color_0
			{
				get
				{
					return Color.FromArgb(255, this.color_3.R, this.color_3.G, this.color_3.B);
				}
				set
				{
					this.color_3 = Color.FromArgb(60, value);
				}
			}

			internal Color Color_1
			{
				get
				{
					return Color.FromArgb(255, this.color_4.R, this.color_4.G, this.color_4.B);
				}
				set
				{
					this.color_4 = Color.FromArgb(60, value);
				}
			}

			protected override Size DefaultSize => new Size(200, 75);

			protected override Size DefaultMinimumSize => new Size(200, 75);

			internal Control15(ContentPanel contentPanel_1)
			{
				this.contentPanel_0 = contentPanel_1;
				this.Dock = DockStyle.Fill;
				base.ViewMode = ViewMode.Normal;
				base.ScrollBars = ScrollBars.None;
				base.AllowDrag = false;
				this.AllowDrop = false;
				base.AllowUndo = false;
				base.BorderStyle = TXTextControl.BorderStyle.None;
				base.EditMode = EditMode.ReadOnly;
				base.HideSelection = true;
				this.string_3 = this.resourceManager_1.GetString("LABEL_DefaultFormFieldName");
				this.color_3 = Color.FromArgb(60, Class568.color_0);
				this.color_4 = Color.FromArgb(60, Class568.color_1);
			}

			protected override void OnSizeChanged(EventArgs eventArgs_0)
			{
				this.method_44();
				base.OnSizeChanged(eventArgs_0);
			}

			protected override void OnHandleCreated(EventArgs eventArgs_0)
			{
				base.OnHandleCreated(eventArgs_0);
				this.method_43();
			}

			protected override void OnTextFieldClicked(TextFieldEventArgs textFieldEventArgs_0)
			{
				foreach (RelatedFormField item in this.list_0)
				{
					if (item.Int32_0 == textFieldEventArgs_0.TextField.Int32_0)
					{
						item.FormField_0.ScrollTo();
						break;
					}
				}
				base.OnTextFieldClicked(textFieldEventArgs_0);
			}

			internal void method_41(int int_5)
			{
				foreach (TextField textField in base.TextFields)
				{
					Color color2 = (textField.HighlightColor = ((int_5 == textField.Int32_0) ? this.color_4 : this.color_3));
				}
			}

			internal void method_42(List<IConditionalInstructionElement> list_2, int int_5)
			{
				this.list_1 = list_2;
				this.int_4 = int_5;
				this.method_43();
			}

			private void method_43()
			{
				if (!base.IsHandleCreated)
				{
					return;
				}
				base.ResetContents();
				base.Selection.FontSize = 180;
				base.InputFormat.RightToLeft = this.RightToLeft == RightToLeft.Yes;
				if (this.list_1.Count > 0)
				{
					if (this.list_1[0] is Condition)
					{
						(this.list_1[0] as Condition).Boolean_1 = true;
					}
					else
					{
						base.InputFormat.BulletedList = true;
						base.InputFormat.HangingIndent = 150;
					}
					foreach (IConditionalInstructionElement item in this.list_1)
					{
						object[] stringElements = item.StringElements;
						base.Selection.Text = stringElements[0].ToString();
						RelatedFormField relatedFormField;
						this.list_0.Add(relatedFormField = stringElements[1] as RelatedFormField);
						Color highlightColor = ((this.int_4 == relatedFormField.Int32_0) ? this.color_4 : this.color_3);
						string text = (string.IsNullOrEmpty(relatedFormField.FormField_0.Name) ? (this.string_3 + relatedFormField.Int32_0) : relatedFormField.FormField_0.Name);
						base.TextFields.Add(new TextField(text)
						{
							HighlightColor = highlightColor,
							HighlightMode = HighlightMode.Always,
							Int32_0 = relatedFormField.Int32_0
						});
						base.Selection.Text = stringElements[2].ToString() + "\r\n";
					}
					base.InputFormat.BulletedList = false;
				}
				this.method_44();
			}

			private void method_44()
			{
				if (!base.IsHandleCreated || this.contentPanel_0.Dpi.IsEmpty)
				{
					return;
				}
				bool flag = false;
				bool flag2 = false;
				int num = Control15.smethod_0(base.Width, this.contentPanel_0.Dpi.X);
				int num2 = Control15.smethod_0(base.Height, this.contentPanel_0.Dpi.X);
				LineCollection lines = base.Lines;
				if (lines.Count > 0)
				{
					foreach (Line item in lines)
					{
						if (item.TextBounds.Width > num)
						{
							flag = true;
							break;
						}
					}
					flag2 = lines[lines.Count].TextBounds.Bottom > num2;
				}
				if (this.bool_20 != flag || this.bool_21 != flag2)
				{
					if (!flag && !flag2)
					{
						base.ScrollBars = ScrollBars.None;
						this.bool_21 = false;
						this.bool_20 = false;
					}
					else if (flag && flag2)
					{
						base.ScrollBars = ScrollBars.Both;
						this.bool_21 = true;
						this.bool_20 = true;
					}
					else if (flag)
					{
						base.ScrollBars = ScrollBars.Horizontal;
						this.bool_20 = true;
						this.bool_21 = false;
					}
					else
					{
						base.ScrollBars = ScrollBars.Vertical;
						this.bool_20 = false;
						this.bool_21 = true;
					}
				}
			}

			private static int smethod_0(int int_5, float float_0)
			{
				return (int)((float)int_5 * 1440f / float_0);
			}
		}

		private SolidBrush solidBrush_0 = new SolidBrush(Color.FromArgb(80, 0, 255, 0));

		private SolidBrush solidBrush_1 = new SolidBrush(Color.White);

		private Label label_0;

		private TableLayoutPanel tableLayoutPanel_0;

		private TableLayoutPanel tableLayoutPanel_1;

		private ListBox listBox_0;

		private Label label_1;

		private TableLayoutPanel tableLayoutPanel_2;

		private Control control_0;

		private Label label_2;

		private TableLayoutPanel tableLayoutPanel_3;

		private Control control_1;

		private System.Windows.Forms.Button button_0;

		private System.Windows.Forms.Button button_1;

		private System.Windows.Forms.Button button_2;

		internal static Color color_0 = Color.Blue;

		internal static Color color_1 = Color.Red;

		private string string_0;

		internal Class568(Enum140 enum140_0, TextControl textControl_0, bool bool_0, Sidebar.SidebarContentLayout sidebarContentLayout_0, PointF pointF_0)
			: base(enum140_0, textControl_0, bool_0, sidebarContentLayout_0, pointF_0)
		{
			this.label_0.Text = base.m_rm.GetString("ID_CONDITIONALINSTRUCTIONS_OVERVIEW");
			this.label_1.Text = base.m_rm.GetString("ID_CONDITIONALINSTRUCTIONS_CONDITIONS");
			this.label_2.Text = base.m_rm.GetString("ID_CONDITIONALINSTRUCTIONS_INSTRUCTIONS");
			this.button_0.Text = base.m_rm.GetString("ID_CONDITIONALINSTRUCTIONS_NEW");
			this.button_1.Text = base.m_rm.GetString("ID_CONDITIONALINSTRUCTIONS_EDIT");
			this.button_2.Text = base.m_rm.GetString("ID_CONDITIONALINSTRUCTIONS_DELETE");
		}

		internal override void InitializeItems()
		{
			this.tableLayoutPanel_1 = new TableLayoutPanel
			{
				AutoSize = true,
				AutoSizeMode = AutoSizeMode.GrowAndShrink,
				Dock = DockStyle.Fill
			};
			this.label_0 = new Label
			{
				Name = Sidebar.ConditionalInstructionsItem.TXITEM_OverviewLabel.ToString(),
				AutoSize = true,
				Dock = DockStyle.Top,
				TextAlign = ContentAlignment.MiddleLeft
			};
			this.tableLayoutPanel_0 = new TableLayoutPanel
			{
				AutoSize = true,
				AutoSizeMode = AutoSizeMode.GrowAndShrink
			};
			this.tableLayoutPanel_0.Dock = DockStyle.Fill;
			this.tableLayoutPanel_0.BackColor = SystemColors.ActiveBorder;
			this.listBox_0 = new ListBox
			{
				Name = Sidebar.ConditionalInstructionsItem.TXITEM_Overview.ToString(),
				IntegralHeight = false,
				Dock = DockStyle.Fill,
				BorderStyle = System.Windows.Forms.BorderStyle.None,
				DrawMode = DrawMode.OwnerDrawVariable
			};
			this.listBox_0.Height = 75;
			this.listBox_0.SelectedIndexChanged += listBox_0_SelectedIndexChanged;
			this.listBox_0.DrawItem += listBox_0_DrawItem;
			this.listBox_0.MeasureItem += listBox_0_MeasureItem;
			this.label_1 = new Label
			{
				Name = Sidebar.ConditionalInstructionsItem.TXITEM_ConditionsLabel.ToString(),
				AutoSize = true,
				Dock = DockStyle.Top,
				TextAlign = ContentAlignment.MiddleLeft
			};
			this.tableLayoutPanel_2 = new TableLayoutPanel
			{
				AutoSize = true,
				AutoSizeMode = AutoSizeMode.GrowAndShrink
			};
			this.tableLayoutPanel_2.Dock = DockStyle.Fill;
			this.tableLayoutPanel_2.BackColor = SystemColors.ActiveBorder;
			if (!base.m_bIsDesignMode)
			{
				this.control_0 = new Control15(this)
				{
					Name = Sidebar.ConditionalInstructionsItem.TXITEM_Conditions.ToString(),
					Dock = DockStyle.Fill
				};
				this.control_0.Font = this.listBox_0.Font;
			}
			else
			{
				this.control_0 = new Control();
				this.control_0.Name = Sidebar.ConditionalInstructionsItem.TXITEM_Conditions.ToString();
				this.control_0.Dock = DockStyle.Fill;
				this.control_0.BackColor = Color.White;
			}
			this.label_2 = new Label
			{
				Name = Sidebar.ConditionalInstructionsItem.TXITEM_InstructionsLabel.ToString(),
				AutoSize = true,
				Dock = DockStyle.Top,
				TextAlign = ContentAlignment.MiddleLeft
			};
			this.tableLayoutPanel_3 = new TableLayoutPanel
			{
				AutoSize = true,
				AutoSizeMode = AutoSizeMode.GrowAndShrink
			};
			this.tableLayoutPanel_3.Dock = DockStyle.Fill;
			this.tableLayoutPanel_3.BackColor = SystemColors.ActiveBorder;
			if (!base.m_bIsDesignMode)
			{
				this.control_1 = new Control15(this)
				{
					Name = Sidebar.ConditionalInstructionsItem.TXITEM_Instructions.ToString()
				};
				this.control_1.Font = this.listBox_0.Font;
			}
			else
			{
				this.control_1 = new Control();
				this.control_1.Name = Sidebar.ConditionalInstructionsItem.TXITEM_Instructions.ToString();
				this.control_1.Dock = DockStyle.Fill;
				this.control_1.BackColor = Color.White;
			}
			this.button_0 = new System.Windows.Forms.Button
			{
				Name = Sidebar.ConditionalInstructionsItem.TXITEM_New.ToString(),
				AutoSize = true,
				AutoSizeMode = AutoSizeMode.GrowAndShrink
			};
			this.button_1 = new System.Windows.Forms.Button
			{
				Name = Sidebar.ConditionalInstructionsItem.TXITEM_Edit.ToString(),
				AutoSize = true,
				AutoSizeMode = AutoSizeMode.GrowAndShrink
			};
			this.button_2 = new System.Windows.Forms.Button
			{
				Name = Sidebar.ConditionalInstructionsItem.TXITEM_Delete.ToString(),
				AutoSize = true,
				AutoSizeMode = AutoSizeMode.GrowAndShrink
			};
			this.button_0.Click += button_0_Click;
			this.button_1.Click += button_1_Click;
			this.button_2.Click += button_2_Click;
			base.m_dicItems.Add(this.label_0.Name, this.label_0);
			base.m_dicItems.Add(this.label_1.Name, this.label_1);
			base.m_dicItems.Add(this.label_2.Name, this.label_2);
			base.m_dicItems.Add(this.button_0.Name, this.button_0);
			base.m_dicItems.Add(this.button_1.Name, this.button_1);
			base.m_dicItems.Add(this.button_2.Name, this.button_2);
		}

		internal override void AwareOfDPI_Intialize()
		{
			if (!base.m_pntDpi.IsEmpty)
			{
				this.listBox_0.Items.Clear();
				if (this.control_0 is TextControl)
				{
					TextControl textControl = this.control_0 as TextControl;
					textControl.PageUnit = MeasuringUnit.Twips;
					textControl.PageSize = new PageSize(16000.0, textControl.PageSize.Height);
					Font font3 = (this.control_0.Font = (this.control_1.Font = this.Font));
				}
				this.method_12();
			}
		}

		internal override void AwareOfDPI_Horizontal()
		{
			this.label_0.Margin = Class517.smethod_51(Class519.Class542.Class547.Padding_1, base.m_pntDpi);
			this.tableLayoutPanel_0.Margin = Class517.smethod_51(Class519.Class542.Class547.Padding_4, base.m_pntDpi);
			TableLayoutPanel tableLayoutPanel = this.tableLayoutPanel_0;
			ListBox listBox = this.listBox_0;
			Size size2 = (this.listBox_0.MinimumSize = Class517.smethod_48(Class519.Class542.Class547.Size_2, base.m_pntDpi));
			Size size5 = (tableLayoutPanel.MinimumSize = (listBox.Size = size2));
			this.label_1.Margin = Class517.smethod_51(Class519.Class542.Class547.Padding_1, base.m_pntDpi);
			this.tableLayoutPanel_2.Margin = Class517.smethod_51(Class519.Class542.Class547.Padding_4, base.m_pntDpi);
			TableLayoutPanel tableLayoutPanel2 = this.tableLayoutPanel_2;
			Control control = this.control_0;
			Size size7 = (this.control_0.MinimumSize = Class517.smethod_48(Class519.Class542.Class547.Size_2, base.m_pntDpi));
			Size size10 = (tableLayoutPanel2.MinimumSize = (control.Size = size7));
			this.label_2.Margin = Class517.smethod_51(Class519.Class542.Class547.Padding_1, base.m_pntDpi);
			this.tableLayoutPanel_3.Margin = Class517.smethod_51(Class519.Class542.Class547.Padding_4, base.m_pntDpi);
			TableLayoutPanel tableLayoutPanel3 = this.tableLayoutPanel_3;
			Control control2 = this.control_1;
			Size size12 = (this.control_1.MinimumSize = Class517.smethod_48(Class519.Class542.Class547.Size_2, base.m_pntDpi));
			Size size15 = (tableLayoutPanel3.MinimumSize = (control2.Size = size12));
			System.Windows.Forms.Button button = this.button_0;
			System.Windows.Forms.Button button2 = this.button_1;
			Padding padding2 = (this.button_2.Margin = Class517.smethod_51(Class519.Class542.Class547.Padding_7, base.m_pntDpi));
			Padding padding5 = (button.Margin = (button2.Margin = padding2));
			System.Windows.Forms.Button button3 = this.button_0;
			System.Windows.Forms.Button button4 = this.button_1;
			Size size17 = (this.button_2.MinimumSize = Class517.smethod_48(Class519.Class542.Class547.Size_0, base.m_pntDpi));
			Size size20 = (button3.MinimumSize = (button4.MinimumSize = size17));
			System.Windows.Forms.Button button5 = this.button_0;
			System.Windows.Forms.Button button6 = this.button_1;
			this.button_2.Dock = DockStyle.Top;
			button6.Dock = DockStyle.Top;
			button5.Dock = DockStyle.Top;
			this.method_8();
		}

		internal override void AwareOfDPI_Vertical()
		{
			this.label_0.Margin = Class517.smethod_51(Class519.Class542.Class547.Padding_0, base.m_pntDpi);
			this.tableLayoutPanel_0.Margin = Class517.smethod_51(Class519.Class542.Class547.Padding_3, base.m_pntDpi);
			TableLayoutPanel tableLayoutPanel = this.tableLayoutPanel_0;
			ListBox listBox = this.listBox_0;
			Size size2 = (this.listBox_0.MinimumSize = Class517.smethod_48(Class519.Class542.Class547.Size_1, base.m_pntDpi));
			Size size5 = (tableLayoutPanel.MinimumSize = (listBox.Size = size2));
			this.label_1.Margin = Class517.smethod_51(Class519.Class542.Class547.Padding_0, base.m_pntDpi);
			this.tableLayoutPanel_2.Margin = Class517.smethod_51(Class519.Class542.Class547.Padding_3, base.m_pntDpi);
			TableLayoutPanel tableLayoutPanel2 = this.tableLayoutPanel_2;
			Control control = this.control_0;
			Size size7 = (this.control_0.MinimumSize = Class517.smethod_48(Class519.Class542.Class547.Size_1, base.m_pntDpi));
			Size size10 = (tableLayoutPanel2.MinimumSize = (control.Size = size7));
			this.label_2.Margin = Class517.smethod_51(Class519.Class542.Class547.Padding_0, base.m_pntDpi);
			this.tableLayoutPanel_3.Margin = Class517.smethod_51(Class519.Class542.Class547.Padding_3, base.m_pntDpi);
			TableLayoutPanel tableLayoutPanel3 = this.tableLayoutPanel_3;
			Control control2 = this.control_1;
			Size size12 = (this.control_1.MinimumSize = Class517.smethod_48(Class519.Class542.Class547.Size_1, base.m_pntDpi));
			Size size15 = (tableLayoutPanel3.MinimumSize = (control2.Size = size12));
			System.Windows.Forms.Button button = this.button_0;
			System.Windows.Forms.Button button2 = this.button_1;
			Padding padding2 = (this.button_2.Margin = Class517.smethod_51(Class519.Class542.Class547.Padding_6, base.m_pntDpi));
			Padding padding5 = (button.Margin = (button2.Margin = padding2));
			System.Windows.Forms.Button button3 = this.button_0;
			System.Windows.Forms.Button button4 = this.button_1;
			Size size17 = (this.button_2.MinimumSize = Class517.smethod_48(Class519.Class542.Class547.Size_0, base.m_pntDpi));
			Size size20 = (button3.MinimumSize = (button4.MinimumSize = size17));
			System.Windows.Forms.Button button5 = this.button_0;
			System.Windows.Forms.Button button6 = this.button_1;
			this.button_2.Dock = DockStyle.Right;
			button6.Dock = DockStyle.Right;
			button5.Dock = DockStyle.Right;
			this.method_8();
		}

		internal override void AwareOfDPI_Dialog()
		{
			this.tableLayoutPanel_1.Margin = new Padding(0);
			this.label_0.Margin = Class517.smethod_51(Class519.Class542.Class547.Padding_2, base.m_pntDpi);
			this.tableLayoutPanel_0.Margin = Class517.smethod_51(Class519.Class542.Class547.Padding_5, base.m_pntDpi);
			TableLayoutPanel tableLayoutPanel = this.tableLayoutPanel_0;
			ListBox listBox = this.listBox_0;
			Size size2 = (this.listBox_0.MinimumSize = Class517.smethod_48(Class519.Class542.Class547.Size_3, base.m_pntDpi));
			Size size5 = (tableLayoutPanel.MinimumSize = (listBox.Size = size2));
			this.label_1.Margin = Class517.smethod_51(Class519.Class542.Class547.Padding_2, base.m_pntDpi);
			this.label_2.Margin = Class517.smethod_51(Class519.Class542.Class547.Padding_2, base.m_pntDpi);
			this.tableLayoutPanel_2.Margin = Class517.smethod_51(Class519.Class542.Class547.Padding_5, base.m_pntDpi);
			this.tableLayoutPanel_3.Margin = Class517.smethod_51(Class519.Class542.Class547.Padding_5, base.m_pntDpi);
			TableLayoutPanel tableLayoutPanel2 = this.tableLayoutPanel_2;
			Control control = this.control_0;
			Size size7 = (this.control_0.MinimumSize = Class517.smethod_48(Class519.Class542.Class547.Size_3, base.m_pntDpi));
			Size size10 = (tableLayoutPanel2.MinimumSize = (control.Size = size7));
			TableLayoutPanel tableLayoutPanel3 = this.tableLayoutPanel_3;
			Control control2 = this.control_1;
			Size size12 = (this.control_1.MinimumSize = Class517.smethod_48(Class519.Class542.Class547.Size_3, base.m_pntDpi));
			Size size15 = (tableLayoutPanel3.MinimumSize = (control2.Size = size12));
			System.Windows.Forms.Button button = this.button_0;
			System.Windows.Forms.Button button2 = this.button_1;
			Padding padding2 = (this.button_2.Margin = Class517.smethod_51(Class519.Class542.Class547.Padding_8, base.m_pntDpi));
			Padding padding5 = (button.Margin = (button2.Margin = padding2));
			System.Windows.Forms.Button button3 = this.button_0;
			System.Windows.Forms.Button button4 = this.button_1;
			Size size17 = (this.button_2.MinimumSize = Class517.smethod_48(Class519.Class542.Class547.Size_0, base.m_pntDpi));
			Size size20 = (button3.MinimumSize = (button4.MinimumSize = size17));
			System.Windows.Forms.Button button5 = this.button_0;
			System.Windows.Forms.Button button6 = this.button_1;
			this.button_2.Dock = DockStyle.Top;
			button6.Dock = DockStyle.Top;
			button5.Dock = DockStyle.Top;
			this.method_8();
		}

		internal override void HandleFontUpdated()
		{
			this.method_8();
		}

		internal override void SetHorizontalAlignment()
		{
			base.Controls.Clear();
			base.ColumnStyles.Clear();
			base.RowStyles.Clear();
			this.tableLayoutPanel_1.Controls.Clear();
			this.tableLayoutPanel_0.Controls.Clear();
			this.tableLayoutPanel_2.Controls.Clear();
			this.tableLayoutPanel_3.Controls.Clear();
			this.AutoSize = true;
			this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			base.ColumnCount = 5;
			base.ColumnStyles.Add(new ColumnStyle());
			base.ColumnStyles.Add(new ColumnStyle());
			base.ColumnStyles.Add(new ColumnStyle());
			base.ColumnStyles.Add(new ColumnStyle());
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			base.RowCount = 5;
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			base.Controls.Add(this.label_0, 0, 0);
			base.SetColumnSpan(this.label_0, 1);
			base.SetRowSpan(this.label_0, 1);
			base.Controls.Add(this.tableLayoutPanel_0, 0, 1);
			base.SetColumnSpan(this.tableLayoutPanel_0, 1);
			base.SetRowSpan(this.tableLayoutPanel_0, 4);
			this.tableLayoutPanel_0.Controls.Add(this.listBox_0, 0, 0);
			base.Controls.Add(this.button_0, 1, 1);
			base.SetColumnSpan(this.button_0, 1);
			base.SetRowSpan(this.button_0, 1);
			base.Controls.Add(this.button_1, 1, 2);
			base.SetColumnSpan(this.button_1, 1);
			base.SetRowSpan(this.button_1, 1);
			base.Controls.Add(this.button_2, 1, 3);
			base.SetColumnSpan(this.button_2, 1);
			base.SetRowSpan(this.button_2, 1);
			base.Controls.Add(this.label_1, 2, 0);
			base.SetColumnSpan(this.label_1, 1);
			base.SetRowSpan(this.label_1, 1);
			base.Controls.Add(this.tableLayoutPanel_2, 2, 1);
			base.SetColumnSpan(this.tableLayoutPanel_2, 1);
			base.SetRowSpan(this.tableLayoutPanel_2, 4);
			this.tableLayoutPanel_2.Controls.Add(this.control_0, 0, 0);
			base.Controls.Add(this.label_2, 3, 0);
			base.SetColumnSpan(this.label_2, 1);
			base.SetRowSpan(this.label_2, 1);
			base.Controls.Add(this.tableLayoutPanel_3, 3, 1);
			base.SetColumnSpan(this.tableLayoutPanel_3, 1);
			base.SetRowSpan(this.tableLayoutPanel_3, 4);
			this.tableLayoutPanel_3.Controls.Add(this.control_1, 0, 0);
			base.SetHorizontalAlignment();
		}

		internal override void SetVerticalAlignment()
		{
			base.Controls.Clear();
			base.ColumnStyles.Clear();
			base.RowStyles.Clear();
			this.tableLayoutPanel_1.Controls.Clear();
			this.tableLayoutPanel_0.Controls.Clear();
			this.tableLayoutPanel_2.Controls.Clear();
			this.tableLayoutPanel_3.Controls.Clear();
			this.AutoSize = true;
			this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			base.ColumnCount = 4;
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			base.ColumnStyles.Add(new ColumnStyle());
			base.ColumnStyles.Add(new ColumnStyle());
			base.ColumnStyles.Add(new ColumnStyle());
			base.RowCount = 8;
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			base.Controls.Add(this.label_0, 0, 0);
			base.SetColumnSpan(this.label_0, 4);
			base.SetRowSpan(this.label_0, 1);
			base.Controls.Add(this.tableLayoutPanel_0, 0, 1);
			base.SetColumnSpan(this.tableLayoutPanel_0, 4);
			base.SetRowSpan(this.tableLayoutPanel_0, 1);
			this.tableLayoutPanel_0.Controls.Add(this.listBox_0, 0, 0);
			base.Controls.Add(this.label_1, 0, 2);
			base.SetColumnSpan(this.label_1, 4);
			base.SetRowSpan(this.label_1, 1);
			base.Controls.Add(this.tableLayoutPanel_2, 0, 3);
			base.SetColumnSpan(this.tableLayoutPanel_2, 4);
			base.SetRowSpan(this.tableLayoutPanel_2, 1);
			this.tableLayoutPanel_2.Controls.Add(this.control_0, 0, 0);
			base.Controls.Add(this.label_2, 0, 4);
			base.SetColumnSpan(this.label_2, 4);
			base.SetRowSpan(this.label_2, 1);
			base.Controls.Add(this.tableLayoutPanel_3, 0, 5);
			base.SetColumnSpan(this.tableLayoutPanel_3, 4);
			base.SetRowSpan(this.tableLayoutPanel_3, 1);
			this.tableLayoutPanel_3.Controls.Add(this.control_1, 0, 0);
			base.Controls.Add(this.button_0, 1, 6);
			base.SetColumnSpan(this.button_0, 1);
			base.SetRowSpan(this.button_0, 1);
			base.Controls.Add(this.button_1, 2, 6);
			base.SetColumnSpan(this.button_1, 1);
			base.SetRowSpan(this.button_1, 1);
			base.Controls.Add(this.button_2, 3, 6);
			base.SetColumnSpan(this.button_2, 1);
			base.SetRowSpan(this.button_2, 1);
			base.SetVerticalAlignment();
		}

		internal override void SetDialogAlignment()
		{
			base.Controls.Clear();
			base.ColumnStyles.Clear();
			base.RowStyles.Clear();
			this.tableLayoutPanel_1.Controls.Clear();
			this.tableLayoutPanel_0.Controls.Clear();
			this.tableLayoutPanel_2.Controls.Clear();
			this.tableLayoutPanel_3.Controls.Clear();
			this.AutoSize = true;
			this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			base.ColumnCount = 2;
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
			base.RowCount = 4;
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.Controls.Add(this.label_0, 0, 0);
			base.SetColumnSpan(this.label_0, 2);
			base.SetRowSpan(this.label_0, 1);
			this.tableLayoutPanel_1.ColumnStyles.Clear();
			this.tableLayoutPanel_1.ColumnCount = 2;
			this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_1.RowStyles.Clear();
			this.tableLayoutPanel_1.RowCount = 4;
			this.tableLayoutPanel_1.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel_1.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel_1.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_0.Controls.Add(this.listBox_0, 0, 0);
			this.tableLayoutPanel_1.Controls.Add(this.tableLayoutPanel_0, 0, 0);
			this.tableLayoutPanel_1.SetColumnSpan(this.tableLayoutPanel_0, 1);
			this.tableLayoutPanel_1.SetRowSpan(this.tableLayoutPanel_0, 4);
			this.tableLayoutPanel_1.Controls.Add(this.button_0, 1, 0);
			this.tableLayoutPanel_1.SetColumnSpan(this.button_0, 1);
			this.tableLayoutPanel_1.SetRowSpan(this.button_0, 1);
			this.tableLayoutPanel_1.Controls.Add(this.button_1, 1, 1);
			this.tableLayoutPanel_1.SetColumnSpan(this.button_1, 1);
			this.tableLayoutPanel_1.SetRowSpan(this.button_1, 1);
			this.tableLayoutPanel_1.Controls.Add(this.button_2, 1, 2);
			this.tableLayoutPanel_1.SetColumnSpan(this.button_2, 1);
			this.tableLayoutPanel_1.SetRowSpan(this.button_2, 1);
			base.Controls.Add(this.tableLayoutPanel_1, 0, 1);
			base.SetColumnSpan(this.tableLayoutPanel_1, 2);
			base.SetRowSpan(this.tableLayoutPanel_1, 1);
			base.Controls.Add(this.label_1, 0, 2);
			base.SetColumnSpan(this.label_1, 1);
			base.SetRowSpan(this.label_1, 1);
			base.Controls.Add(this.tableLayoutPanel_2, 0, 3);
			base.SetColumnSpan(this.tableLayoutPanel_2, 1);
			base.SetRowSpan(this.tableLayoutPanel_2, 1);
			this.tableLayoutPanel_2.Controls.Add(this.control_0, 0, 0);
			base.Controls.Add(this.label_2, 1, 2);
			base.SetColumnSpan(this.label_2, 1);
			base.SetRowSpan(this.label_2, 1);
			this.label_2.Margin = new Padding(7, 0, 7, 14);
			base.Controls.Add(this.tableLayoutPanel_3, 1, 3);
			base.SetColumnSpan(this.tableLayoutPanel_3, 1);
			base.SetRowSpan(this.tableLayoutPanel_3, 1);
			this.tableLayoutPanel_3.Controls.Add(this.control_1, 0, 0);
			base.SetDialogAlignment();
		}

		internal override void UpdateTextControlBindings(TextControl oldTextcontrol, TextControl newTextControl)
		{
			if (oldTextcontrol != null)
			{
				oldTextcontrol.TextFieldEntered -= method_4;
				oldTextcontrol.TextFieldLeft -= method_5;
				oldTextcontrol.TextFieldDeleted -= method_3;
				oldTextcontrol.TextFieldCreated -= method_2;
				oldTextcontrol.PropertyChanged -= method_6;
				if (oldTextcontrol.Class456_0 != null)
				{
					oldTextcontrol.Class456_0.FormFieldNameChanged -= method_0;
					oldTextcontrol.Class456_0.ConditionalInstructionsChanged -= method_0;
				}
				oldTextcontrol.IsFormFieldValidationEnabledChanged -= method_1;
			}
			if (newTextControl != null && newTextControl.IsHandleCreated)
			{
				if (newTextControl.IsFormFieldValidationEnabled)
				{
					newTextControl.TextFieldEntered += method_4;
					newTextControl.TextFieldLeft += method_5;
					newTextControl.TextFieldDeleted += method_3;
					newTextControl.TextFieldCreated += method_2;
					newTextControl.PropertyChanged += method_6;
					base.TextControl.Class456_0.FormFieldNameChanged += method_0;
					base.TextControl.Class456_0.ConditionalInstructionsChanged += method_0;
				}
				newTextControl.IsFormFieldValidationEnabledChanged += method_1;
			}
			if (base.IsHandleCreated)
			{
				this.method_9(newTextControl);
				this.method_8();
				this.method_12();
			}
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			base.OnHandleCreated(eventArgs_0);
			this.method_10();
		}

		internal override void UpdateContent()
		{
			this.method_8();
		}

		private void listBox_0_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.listBox_0.SelectedItem != null)
			{
				this.method_11(this.listBox_0.SelectedItem.ToString());
			}
			bool flag = base.TextControl != null && (base.TextControl.EditMode == EditMode.ReadAndSelect || base.TextControl.EditMode == EditMode.ReadOnly);
			System.Windows.Forms.Button button = this.button_1;
			bool enabled = (this.button_2.Enabled = base.TextControl == null || (this.listBox_0.SelectedItem != null && !flag));
			button.Enabled = enabled;
		}

		protected override void OnFontChanged(EventArgs eventArgs_0)
		{
			base.OnFontChanged(eventArgs_0);
		}

		private void listBox_0_MeasureItem(object sender, MeasureItemEventArgs e)
		{
			if (e.Index >= 0 && e.Index < this.listBox_0.Items.Count)
			{
				Class574 @class = (Class574)this.listBox_0.Items[e.Index];
				Size size = TextRenderer.MeasureText(e.Graphics, @class.String_0, this.listBox_0.Font);
				e.ItemHeight = size.Height;
				e.ItemWidth = size.Width;
			}
		}

		private void listBox_0_DrawItem(object sender, DrawItemEventArgs e)
		{
			if (e.Index >= 0 && e.Index < this.listBox_0.Items.Count)
			{
				Class574 @class = (Class574)this.listBox_0.Items[e.Index];
				e.DrawBackground();
				new SolidBrush(e.ForeColor);
				float num = (float)e.Bounds.Height / 2f;
				bool flag;
				int num2 = ((!(flag = this.RightToLeft == RightToLeft.Yes)) ? (e.Bounds.X + (int)num) : (e.Bounds.Right - TextRenderer.MeasureText(e.Graphics, @class.String_0.ToString(), e.Font).Width - e.Bounds.X - (int)num));
				TextFormatFlags flags = (flag ? (TextFormatFlags.NoPrefix | TextFormatFlags.RightToLeft) : TextFormatFlags.NoPrefix);
				TextRenderer.DrawText(e.Graphics, @class.String_0.ToString(), e.Font, new Point(num2, e.Bounds.Y), e.ForeColor, flags);
				if (@class.Boolean_0)
				{
					float num3 = ((float)e.Bounds.Height - num) / 2f;
					float num4 = (flag ? ((float)e.Bounds.Right - num - (float)e.Bounds.X) : ((float)e.Bounds.X));
					RectangleF rect = new RectangleF(num4, (float)e.Bounds.Y + num3, num, num);
					e.Graphics.FillEllipse(new SolidBrush(Color.White), rect);
					e.Graphics.FillEllipse(this.solidBrush_0, rect);
				}
			}
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			if (base.TextControl != null)
			{
				base.TextControl.Class456_0.method_16(ref this.string_0);
				this.string_0 = null;
			}
		}

		private void button_1_Click(object sender, EventArgs e)
		{
			if (base.TextControl != null)
			{
				this.string_0 = this.listBox_0.SelectedItem.ToString();
				base.TextControl.Class456_0.method_16(ref this.string_0);
				this.string_0 = null;
			}
		}

		private void button_2_Click(object sender, EventArgs e)
		{
			if (base.TextControl != null)
			{
				string text = this.listBox_0.SelectedItem.ToString();
				base.TextControl.Class456_0.Class394_0.method_6(text);
				this.method_8();
				this.method_12();
			}
		}

		private void method_0(object sender, EventArgs e)
		{
			if (base.IsSidebarShown)
			{
				this.method_8();
				this.method_12();
			}
		}

		private void method_1(object sender, EventArgs e)
		{
			this.method_10();
		}

		private void method_2(object sender, TextFieldEventArgs e)
		{
			if (base.IsSidebarShown && e.TextField is FormField)
			{
				FormField formField = e.TextField as FormField;
				if ((formField.String_2 != null && formField.String_2.Length > 0) || (formField.String_3 != null && formField.String_3.Length > 0))
				{
					this.method_8();
				}
				this.method_12();
			}
		}

		private void method_3(object sender, TextFieldEventArgs e)
		{
			if (base.IsSidebarShown && e.TextField is FormField)
			{
				FormField formField = e.TextField as FormField;
				if ((formField.String_2 != null && formField.String_2.Length > 0) || (formField.String_3 != null && formField.String_3.Length > 0))
				{
					this.method_8();
				}
				this.method_12();
			}
		}

		private void method_4(object sender, TextFieldEventArgs e)
		{
			if (base.IsSidebarShown)
			{
				FormField formField = e.TextField as FormField;
				List<string> list = null;
				if (formField != null && base.TextControl.IsFormFieldValidationEnabled && ((formField.String_2 != null && formField.String_2.Length > 0) || (formField.String_3 != null && formField.String_3.Length > 0)))
				{
					list = base.TextControl.Class456_0.Class394_0.method_8(formField, (Class394.Enum47)3);
					int hashCode = formField.GetHashCode();
					this.method_13(list);
					(this.control_0 as Control15).method_41(hashCode);
					(this.control_1 as Control15).method_41(hashCode);
				}
			}
		}

		private void method_5(object sender, TextFieldEventArgs e)
		{
			if (base.IsSidebarShown)
			{
				this.method_13(null);
				(this.control_0 as Control15).method_41(-1);
				(this.control_1 as Control15).method_41(-1);
			}
		}

		private void method_6(object sender, PropertyChangedEventArgs e)
		{
			if (base.IsSidebarShown && e.PropertyName == "EditMode")
			{
				this.method_12();
			}
		}

		private List<IConditionalInstructionElement> method_7(List<object[]> list_0, Class394.Enum47 enum47_0)
		{
			List<IConditionalInstructionElement> list = new List<IConditionalInstructionElement>();
			foreach (object[] item in list_0)
			{
				IConditionalInstructionElement conditionalInstructionElement = ((enum47_0 == Class394.Enum47.const_0) ? Class403.smethod_4<Condition>((string)item[1]) : Class403.smethod_4<Instruction>((string)item[1]));
				int num = (int)item[0];
				foreach (FormField formField in base.TextControl.FormFields)
				{
					if (formField.GetHashCode() == num)
					{
						conditionalInstructionElement.RelatedFormField.FormField_0 = formField;
						break;
					}
				}
				if (conditionalInstructionElement.RelatedFormField.FormField_0 != null)
				{
					list.Add(conditionalInstructionElement);
				}
			}
			list.Sort();
			return list;
		}

		private void method_8()
		{
			if (base.IsSidebarShown && base.TextControl != null && base.TextControl.IsHandleCreated && base.TextControl.IsFormFieldValidationEnabled)
			{
				this.listBox_0.Items.Clear();
				this.listBox_0.SelectedIndexChanged -= listBox_0_SelectedIndexChanged;
				List<string> list_ = base.TextControl.Class456_0.Class394_0.List_1;
				list_.Sort();
				int selectedIndex = 0;
				for (int i = 0; i < list_.Count; i++)
				{
					string text = list_[i];
					this.listBox_0.Items.Add(new Class574(text));
					if (text == this.string_0)
					{
						selectedIndex = i;
					}
				}
				this.listBox_0.SelectedIndexChanged += listBox_0_SelectedIndexChanged;
				if (this.listBox_0.Items.Count > 0)
				{
					this.listBox_0.SelectedIndex = selectedIndex;
				}
				else if (!base.m_bIsDesignMode)
				{
					(this.control_0 as Control15).ResetContents();
					(this.control_1 as Control15).ResetContents();
				}
			}
			else if (!base.m_bIsDesignMode)
			{
				this.listBox_0.Items.Clear();
				(this.control_0 as Control15).ResetContents();
				(this.control_1 as Control15).ResetContents();
			}
		}

		private void method_9(TextControl textControl_0)
		{
			Control15 control = this.control_0 as Control15;
			Control15 control2 = this.control_1 as Control15;
			if (control != null)
			{
				Color color3 = (control.Color_0 = (control2.Color_0 = ((textControl_0 == null || textControl_0.DisplayColors.FormFieldColor.A == 0) ? Class568.color_0 : textControl_0.DisplayColors.FormFieldColor)));
				Color color6 = (control.Color_1 = (control2.Color_1 = ((textControl_0 == null || textControl_0.DisplayColors.ActiveFormFieldColor.A == 0) ? Class568.color_1 : textControl_0.DisplayColors.ActiveFormFieldColor)));
				this.solidBrush_0 = new SolidBrush(Color.FromArgb(60, control.Color_1));
			}
		}

		private void method_10()
		{
			if (base.TextControl != null)
			{
				base.TextControl.TextFieldEntered -= method_4;
				base.TextControl.TextFieldLeft -= method_5;
				base.TextControl.TextFieldDeleted -= method_3;
				base.TextControl.TextFieldCreated -= method_2;
				base.TextControl.PropertyChanged -= method_6;
				if (base.TextControl.Class456_0 != null)
				{
					base.TextControl.Class456_0.FormFieldNameChanged -= method_0;
					base.TextControl.Class456_0.ConditionalInstructionsChanged -= method_0;
				}
				if (base.TextControl.IsFormFieldValidationEnabled)
				{
					base.TextControl.TextFieldEntered += method_4;
					base.TextControl.TextFieldLeft += method_5;
					base.TextControl.TextFieldDeleted += method_3;
					base.TextControl.TextFieldCreated += method_2;
					base.TextControl.PropertyChanged += method_6;
					base.TextControl.Class456_0.FormFieldNameChanged += method_0;
					base.TextControl.Class456_0.ConditionalInstructionsChanged += method_0;
				}
				base.TextControl.IsFormFieldValidationEnabledChanged -= method_1;
				base.TextControl.IsFormFieldValidationEnabledChanged += method_1;
				if (base.IsHandleCreated)
				{
					this.method_9(base.TextControl);
					this.method_8();
					this.method_12();
				}
			}
		}

		private void method_11(string string_1)
		{
			if (string_1 != null)
			{
				int int_ = base.TextControl.FormFields.GetItem()?.GetHashCode() ?? (-1);
				List<object[]> list_ = base.TextControl.Class456_0.Class394_0.method_7(string_1, Class394.Enum47.const_0);
				List<IConditionalInstructionElement> list_2 = this.method_7(list_, Class394.Enum47.const_0);
				(this.control_0 as Control15).method_42(list_2, int_);
				List<object[]> list_3 = base.TextControl.Class456_0.Class394_0.method_7(string_1, Class394.Enum47.const_1);
				List<IConditionalInstructionElement> list_4 = this.method_7(list_3, Class394.Enum47.const_1);
				(this.control_1 as Control15).method_42(list_4, int_);
			}
		}

		private void method_12()
		{
			Label label = this.label_0;
			Label label2 = this.label_1;
			bool flag2 = (this.label_2.Enabled = base.TextControl == null || (base.TextControl.IsHandleCreated && base.TextControl.IsFormFieldValidationEnabled && base.TextControl.FormFields.Count > 0));
			bool enabled = (label2.Enabled = flag2);
			label.Enabled = enabled;
			bool flag4 = base.TextControl != null && ((base.TextControl.EditMode == EditMode.ReadAndSelect && base.TextControl.DocumentPermissions.ReadOnly) || base.TextControl.EditMode == EditMode.ReadOnly);
			this.button_0.Enabled = this.label_2.Enabled && !flag4;
			System.Windows.Forms.Button button = this.button_1;
			bool enabled2 = (this.button_2.Enabled = base.TextControl == null || (this.listBox_0.SelectedItem != null && !flag4));
			button.Enabled = enabled2;
		}

		private void method_13(List<string> list_0)
		{
			foreach (Class574 item in this.listBox_0.Items)
			{
				item.Boolean_0 = list_0?.Contains(item.String_0) ?? false;
			}
			this.listBox_0.Refresh();
		}
	}
}
