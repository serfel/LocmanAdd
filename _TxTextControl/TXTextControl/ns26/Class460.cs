using System;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;
using TXTextControl;
using TXTextControl.Windows.Forms;

namespace ns26
{
	internal class Class460 : Row
	{
		internal class Class462 : Panel
		{
			private TextBox textBox_0;

			protected override Padding DefaultPadding => new Padding(1);

			internal TextBox TextBox_0 => this.textBox_0;

			internal Class462()
			{
				this.AutoSize = true;
				this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
				this.BackColor = Color.Transparent;
				this.Dock = DockStyle.Top;
				this.textBox_0 = new TextBox
				{
					Dock = DockStyle.Top,
					BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
				};
				this.textBox_0.Margin = new Padding(0);
				base.Controls.Add(this.textBox_0);
			}
		}

		internal class Class463 : TableLayoutPanel
		{
			protected ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

			private ComboBox comboBox_0;

			private ComboBox comboBox_1;

			private TextBox textBox_0;

			private Class460 class460_0;

			internal Class463(Class460 class460_1)
			{
				this.class460_0 = class460_1;
				this.method_1();
			}

			protected override void OnHandleCreated(EventArgs eventArgs_0)
			{
				base.OnHandleCreated(eventArgs_0);
				this.comboBox_0.SelectionChangeCommitted += comboBox_0_SelectionChangeCommitted;
				this.comboBox_1.SelectionChangeCommitted += comboBox_1_SelectionChangeCommitted;
				this.textBox_0.TextChanged += textBox_0_TextChanged;
				this.textBox_0.Enter += textBox_0_Enter;
				this.textBox_0.Leave += textBox_0_Leave;
			}

			internal void method_0(PointF pointF_0)
			{
				this.method_9(pointF_0);
				base.ColumnStyles[0].Width = this.method_8(0, this.comboBox_0.Margin.Horizontal, null, this.comboBox_0.Font, pointF_0, "ID_CONDITIONALINSTRUCTION_CBX_ROW_EMPTYVALUE", "ID_CONDITIONALINSTRUCTION_CBX_ROW_DATE", "ID_CONDITIONALINSTRUCTION_CBX_ROW_YEAR", "ID_CONDITIONALINSTRUCTION_CBX_ROW_MONTH", "ID_CONDITIONALINSTRUCTION_CBX_ROW_DAYOFMONTH", "ID_CONDITIONALINSTRUCTION_CBX_ROW_DAYOFWEEK");
				int num = Math.Max(this.textBox_0.PreferredHeight, Math.Max(this.comboBox_0.PreferredHeight, this.comboBox_1.PreferredHeight));
				this.MinimumSize = new Size((int)this.method_3(pointF_0), num);
				this.MaximumSize = new Size(int.MaxValue, num);
			}

			private void comboBox_0_SelectionChangeCommitted(object sender, EventArgs e)
			{
				if (this.comboBox_0.SelectedItem != null)
				{
					this.class460_0.Condition_0.ValueTypes_0 = (ValueTypes)(this.comboBox_0.SelectedItem as Class464).Object_0;
					this.class460_0.Condition_0.String_0 = null;
					this.method_7();
					this.class460_0.method_8();
				}
			}

			private void comboBox_1_SelectionChangeCommitted(object sender, EventArgs e)
			{
				this.class460_0.Condition_0.String_0 = null;
				if (this.comboBox_1.SelectedIndex != -1)
				{
					Class464 @class = this.comboBox_0.SelectedItem as Class464;
					this.class460_0.Condition_0.ValueTypes_0 = (ValueTypes)@class.Object_0;
					this.class460_0.Condition_0.String_0 = this.comboBox_1.SelectedIndex.ToString();
					this.class460_0.method_8();
				}
			}

			private void textBox_0_Enter(object sender, EventArgs e)
			{
				if (!this.method_5())
				{
					this.textBox_0.Text = "";
					this.textBox_0.ForeColor = SystemColors.WindowText;
				}
			}

			private void textBox_0_TextChanged(object sender, EventArgs e)
			{
				this.method_5();
				this.class460_0.method_8();
			}

			private void textBox_0_Leave(object sender, EventArgs e)
			{
				if (!this.method_5())
				{
					this.method_4();
				}
			}

			private void method_1()
			{
				this.AutoSize = true;
				this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
				Padding padding3 = (base.Margin = (base.Padding = new Padding(0)));
				base.ColumnCount = 2;
				base.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute));
				base.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
				base.RowCount = 1;
				base.RowStyles.Add(new RowStyle());
				this.comboBox_0 = new ComboBox
				{
					DropDownStyle = ComboBoxStyle.DropDownList,
					Dock = DockStyle.Top
				};
				base.Controls.Add(this.comboBox_0, 0, 0);
				this.comboBox_1 = new ComboBox
				{
					DropDownStyle = ComboBoxStyle.DropDownList,
					Visible = false,
					Dock = DockStyle.Top
				};
				base.Controls.Add(this.comboBox_1, 1, 0);
				this.textBox_0 = new TextBox
				{
					Visible = false,
					Dock = DockStyle.Top
				};
				base.Controls.Add(this.textBox_0, 1, 0);
			}

			internal void method_2(bool bool_0)
			{
				this.comboBox_0.Items.Clear();
				if (bool_0)
				{
					this.comboBox_0.Items.Add(new Class464(this.resourceManager_0.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_EMPTYVALUE"), ValueTypes.EmptyValue));
				}
				this.comboBox_0.Items.AddRange(new object[4]
				{
					new Class464(this.resourceManager_0.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_DATE"), ValueTypes.Date),
					new Class464(this.resourceManager_0.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_YEAR"), ValueTypes.Year),
					new Class464(this.resourceManager_0.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_MONTH"), ValueTypes.Month),
					new Class464(this.resourceManager_0.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_DAYOFMONTH"), ValueTypes.DayOfMonth)
				});
				if (bool_0)
				{
					this.comboBox_0.Items.Add(new Class464(this.resourceManager_0.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_DAYOFWEEK"), ValueTypes.DayOfWeek));
				}
				if (!bool_0 && (this.class460_0.Condition_0.ValueTypes_0 == ValueTypes.EmptyValue || this.class460_0.Condition_0.ValueTypes_0 == ValueTypes.DayOfWeek))
				{
					this.class460_0.Condition_0.ValueTypes_0 = ValueTypes.Undefined;
					this.class460_0.Condition_0.String_0 = null;
				}
				this.method_7();
			}

			internal float method_3(PointF pointF_0)
			{
				float num = this.method_8(0, this.comboBox_0.Margin.Horizontal, null, this.comboBox_0.Font, pointF_0, "ID_CONDITIONALINSTRUCTION_CBX_ROW_EMPTYVALUE", "ID_CONDITIONALINSTRUCTION_CBX_ROW_DATE", "ID_CONDITIONALINSTRUCTION_CBX_ROW_YEAR", "ID_CONDITIONALINSTRUCTION_CBX_ROW_MONTH", "ID_CONDITIONALINSTRUCTION_CBX_ROW_DAYOFMONTH", "ID_CONDITIONALINSTRUCTION_CBX_ROW_DAYOFWEEK");
				return num + this.method_8((int)(75f * pointF_0.X / 96f), this.comboBox_1.Margin.Horizontal, null, this.comboBox_1.Font, pointF_0, "ID_CONDITIONALINSTRUCTION_CBX_ROW_MONTH_0", "ID_CONDITIONALINSTRUCTION_CBX_ROW_MONTH_1", "ID_CONDITIONALINSTRUCTION_CBX_ROW_MONTH_2", "ID_CONDITIONALINSTRUCTION_CBX_ROW_MONTH_3", "ID_CONDITIONALINSTRUCTION_CBX_ROW_MONTH_4", "ID_CONDITIONALINSTRUCTION_CBX_ROW_MONTH_5", "ID_CONDITIONALINSTRUCTION_CBX_ROW_MONTH_6", "ID_CONDITIONALINSTRUCTION_CBX_ROW_MONTH_7", "ID_CONDITIONALINSTRUCTION_CBX_ROW_MONTH_8", "ID_CONDITIONALINSTRUCTION_CBX_ROW_MONTH_9", "ID_CONDITIONALINSTRUCTION_CBX_ROW_MONTH_10", "ID_CONDITIONALINSTRUCTION_CBX_ROW_MONTH_11", "ID_CONDITIONALINSTRUCTION_CBX_ROW_DAYOFWEEK_0", "ID_CONDITIONALINSTRUCTION_CBX_ROW_DAYOFWEEK_1", "ID_CONDITIONALINSTRUCTION_CBX_ROW_DAYOFWEEK_2", "ID_CONDITIONALINSTRUCTION_CBX_ROW_DAYOFWEEK_3", "ID_CONDITIONALINSTRUCTION_CBX_ROW_DAYOFWEEK_4", "ID_CONDITIONALINSTRUCTION_CBX_ROW_DAYOFWEEK_5", "ID_CONDITIONALINSTRUCTION_CBX_ROW_DAYOFWEEK_6");
			}

			private void method_4()
			{
				if (string.IsNullOrEmpty(this.class460_0.Condition_0.String_0))
				{
					this.textBox_0.ForeColor = Color.Gray;
					switch (this.class460_0.Condition_0.ValueTypes_0)
					{
					case ValueTypes.Date:
						this.textBox_0.Text = "[" + CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern + "]";
						break;
					case ValueTypes.Year:
						this.textBox_0.Text = "[yyyy]";
						break;
					case ValueTypes.DayOfMonth:
						this.textBox_0.Text = "[1-31]";
						break;
					case ValueTypes.Month:
						break;
					}
					return;
				}
				this.textBox_0.ForeColor = SystemColors.WindowText;
				switch (this.class460_0.Condition_0.ValueTypes_0)
				{
				case ValueTypes.Date:
				{
					if (long.TryParse(this.class460_0.Condition_0.String_0, out var result))
					{
						DateTime dateTime = new DateTime(result);
						this.textBox_0.Text = dateTime.ToString("d", CultureInfo.CurrentUICulture);
					}
					else
					{
						this.textBox_0.ForeColor = Color.Gray;
						this.textBox_0.Text = "[" + CultureInfo.CurrentUICulture.DateTimeFormat.ShortDatePattern + "]";
					}
					break;
				}
				case ValueTypes.Year:
				case ValueTypes.DayOfMonth:
					this.textBox_0.Text = this.class460_0.Condition_0.String_0.ToString();
					break;
				case ValueTypes.Month:
					break;
				}
			}

			private bool method_5()
			{
				bool result = false;
				switch (this.class460_0.Condition_0.ValueTypes_0)
				{
				case ValueTypes.Date:
				{
					DateTime result4 = DateTime.Now;
					this.class460_0.Condition_0.String_0 = ((result = DateTime.TryParse(this.textBox_0.Text, CultureInfo.CurrentUICulture.DateTimeFormat, DateTimeStyles.AllowWhiteSpaces, out result4) && result4.Year >= 1601 && result4.Year <= 9999) ? result4.Ticks.ToString() : null);
					break;
				}
				case ValueTypes.Year:
				{
					this.class460_0.Condition_0.String_0 = ((result = int.TryParse(this.textBox_0.Text, out var result3) && result3 >= 1601 && result3 <= 9999) ? result3.ToString() : null);
					break;
				}
				case ValueTypes.DayOfMonth:
				{
					this.class460_0.Condition_0.String_0 = ((result = int.TryParse(this.textBox_0.Text, out var result2) && result2 >= 1 && result2 <= 31) ? result2.ToString() : null);
					break;
				}
				}
				return result;
			}

			internal void method_6()
			{
				foreach (Class464 item in this.comboBox_0.Items)
				{
					if (this.class460_0.Condition_0.ValueTypes_0 == (ValueTypes)item.Object_0)
					{
						this.comboBox_0.SelectedItem = item;
						return;
					}
				}
				this.comboBox_0.SelectedItem = null;
			}

			private void method_7()
			{
				this.comboBox_1.Items.Clear();
				this.textBox_0.Text = "";
				switch (this.class460_0.Condition_0.ValueTypes_0)
				{
				case ValueTypes.Date:
				case ValueTypes.Year:
				case ValueTypes.DayOfMonth:
					this.comboBox_1.Visible = false;
					this.textBox_0.Visible = true;
					this.method_4();
					return;
				case ValueTypes.Undefined:
				case ValueTypes.EmptyValue:
					this.comboBox_1.Visible = false;
					this.textBox_0.Visible = false;
					return;
				}
				this.textBox_0.Visible = false;
				this.textBox_0.Text = "";
				this.comboBox_1.Items.Clear();
				switch (this.class460_0.Condition_0.ValueTypes_0)
				{
				case ValueTypes.Month:
				{
					for (int j = 0; j < 12; j++)
					{
						this.comboBox_1.Items.Add(new Class464(this.resourceManager_0.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_MONTH_" + j), j));
					}
					break;
				}
				case ValueTypes.DayOfWeek:
				{
					for (int i = 0; i < 7; i++)
					{
						this.comboBox_1.Items.Add(new Class464(this.resourceManager_0.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_DAYOFWEEK_" + i), i));
					}
					break;
				}
				}
				if (!string.IsNullOrEmpty(this.class460_0.Condition_0.String_0) && int.TryParse(this.class460_0.Condition_0.String_0, out var result))
				{
					this.comboBox_1.SelectedIndex = result;
				}
				this.comboBox_1.Visible = true;
			}

			private float method_8(int int_0, int int_1, object object_0, Font font_0, PointF pointF_0, params string[] string_0)
			{
				Control control = object_0 as Control;
				float num = ((object_0 != null) ? ((control != null) ? TextRenderer.MeasureText(control.Text, font_0, default(Size), TextFormatFlags.NoPrefix).Width : TextRenderer.MeasureText(object_0.ToString(), font_0, default(Size), TextFormatFlags.NoPrefix).Width) : 0);
				foreach (string name in string_0)
				{
					int num2 = TextRenderer.MeasureText(this.resourceManager_0.GetString(name), font_0, default(Size), TextFormatFlags.NoPrefix).Width;
					num = Math.Max(num, num2);
				}
				float num3 = (float)(Class517.smethod_45(SystemInformation.VerticalScrollBarWidth, pointF_0.X) + int_1) + 4f * pointF_0.X / 96f;
				return Math.Max(int_0, num) + num3;
			}

			private void method_9(PointF pointF_0)
			{
				Padding margin = Class517.smethod_51(new Padding(3, 0, 3, 0), pointF_0);
				this.comboBox_0.Margin = margin;
				this.comboBox_1.Margin = margin;
				this.textBox_0.Margin = margin;
			}
		}

		private float float_0;

		private float float_1;

		private float float_2;

		private bool bool_0;

		private bool bool_1;

		private Label label_0;

		private Label label_1;

		private Label label_2;

		private ComboBox comboBox_0;

		private Label label_3;

		private ComboBox comboBox_1;

		private ComboBox comboBox_2;

		private ComboBox comboBox_3;

		private Class462 class462_0;

		private Class463 class463_0;

		private Label label_4;

		[CompilerGenerated]
		private Condition condition_0;

		internal Condition Condition_0
		{
			[CompilerGenerated]
			get
			{
				return this.condition_0;
			}
			[CompilerGenerated]
			set
			{
				this.condition_0 = value;
			}
		}

		internal override bool IsFirstRow
		{
			get
			{
				return base.m_bIsFirstRow;
			}
			set
			{
				if (base.m_bIsFirstRow != (base.m_bIsFirstRow = value))
				{
					Label label = this.label_0;
					Label label2 = this.label_1;
					bool flag = (this.label_2.Visible = base.m_bIsFirstRow);
					bool visible = (label2.Visible = flag);
					label.Visible = visible;
					this.comboBox_0.Visible = !base.m_bIsFirstRow;
				}
			}
		}

		internal bool Boolean_0
		{
			get
			{
				return this.label_3.Visible;
			}
			set
			{
				this.label_3.Visible = value;
			}
		}

		internal bool Boolean_1
		{
			get
			{
				return this.label_4.Visible;
			}
			set
			{
				this.label_4.Visible = value;
			}
		}

		internal Class460(Class457 class457_0, Condition condition_1)
			: base(class457_0)
		{
			if ((this.Condition_0 = condition_1) == null)
			{
				this.Condition_0 = new Condition();
			}
			this.method_0();
			this.method_1();
			this.method_2();
			this.method_3();
			this.method_4(this.Condition_0.LogicalOperators_0 != LogicalOperators.EqualsTo && this.Condition_0.LogicalOperators_0 != LogicalOperators.DoesNotEqualTo && this.Condition_0.LogicalOperators_0 != LogicalOperators.Undefined, this.Condition_0.LogicalOperators_0 == LogicalOperators.MatchesRegex || this.Condition_0.LogicalOperators_0 == LogicalOperators.DoesNotMatchRegex);
			this.method_7();
			this.method_8();
		}

		protected override void InitializeComponents()
		{
			base.RowCount = 2;
			base.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
			base.RowStyles.Add(new RowStyle(SizeType.AutoSize, 0f));
			base.ColumnCount = 9;
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 0f));
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 0f));
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 0f));
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 0f));
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 0f));
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 0f));
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			base.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 0f));
			base.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize, 0f));
			this.label_0 = new Label();
			this.label_1 = new Label();
			this.label_2 = new Label();
			this.comboBox_0 = new ComboBox();
			this.label_3 = new Label();
			this.comboBox_1 = new ComboBox();
			this.comboBox_2 = new ComboBox();
			this.comboBox_3 = new ComboBox();
			this.class462_0 = new Class462();
			this.class463_0 = new Class463(this);
			this.label_4 = new Label();
			base.m_btnAddNewRow = new System.Windows.Forms.Button();
			base.m_btnRemoveRow = new System.Windows.Forms.Button();
			this.label_0.AutoSize = true;
			this.label_0.Text = base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_LBL_ROW_FORMFIELDVALUE");
			this.label_1.AutoSize = true;
			this.label_1.Text = base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_LBL_ROW_COMPARISON");
			this.label_2.AutoSize = true;
			this.label_2.Text = base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_LBL_ROW_COMPARETO");
			this.comboBox_0.Dock = DockStyle.Top;
			this.comboBox_0.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_0.Items.AddRange(new object[2]
			{
				new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_AND"), Condition.LogicalConnectives.And),
				new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_OR"), Condition.LogicalConnectives.const_1)
			});
			this.comboBox_0.SelectedIndex = 0;
			this.comboBox_0.Visible = false;
			this.label_3.AutoSize = true;
			this.label_3.Dock = DockStyle.Right;
			this.label_3.Text = base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_LBL_ROW_LEFTPARANTHESIS");
			this.label_3.TextAlign = ContentAlignment.MiddleRight;
			this.label_3.Visible = false;
			this.comboBox_1.Dock = DockStyle.Top;
			this.comboBox_1.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_2.Dock = DockStyle.Top;
			this.comboBox_2.DropDownStyle = ComboBoxStyle.DropDownList;
			this.comboBox_3.Dock = DockStyle.Top;
			this.class462_0.Dock = DockStyle.Top;
			this.class462_0.Visible = true;
			this.class463_0.Dock = DockStyle.Top;
			this.class463_0.Visible = true;
			this.label_4.AutoSize = true;
			this.label_4.Dock = DockStyle.Left;
			this.label_4.Text = base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_LBL_ROW_RIGHTPARANTHESIS");
			this.label_4.TextAlign = ContentAlignment.MiddleLeft;
			this.label_4.Visible = false;
			base.m_btnAddNewRow.AutoSize = true;
			base.m_btnAddNewRow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			base.m_btnAddNewRow.Enabled = false;
			base.m_btnRemoveRow.AutoSize = true;
			base.m_btnRemoveRow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			base.m_btnRemoveRow.Enabled = false;
			base.Controls.Add(this.label_0, 2, 0);
			base.Controls.Add(this.label_1, 3, 0);
			base.Controls.Add(this.label_2, 4, 0);
			base.Controls.Add(this.comboBox_0, 0, 1);
			base.Controls.Add(this.label_3, 1, 1);
			base.Controls.Add(this.comboBox_1, 2, 1);
			base.Controls.Add(this.comboBox_2, 3, 1);
			base.Controls.Add(this.comboBox_3, 4, 1);
			base.Controls.Add(this.label_4, 5, 1);
			base.Controls.Add(base.m_btnAddNewRow, 7, 1);
			base.Controls.Add(base.m_btnRemoveRow, 8, 1);
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			base.OnHandleCreated(eventArgs_0);
			this.comboBox_0.SelectionChangeCommitted += comboBox_0_SelectionChangeCommitted;
			this.comboBox_1.SelectionChangeCommitted += comboBox_1_SelectionChangeCommitted;
			this.comboBox_2.SelectionChangeCommitted += comboBox_2_SelectionChangeCommitted;
			this.comboBox_3.SelectionChangeCommitted += comboBox_3_SelectionChangeCommitted;
			this.comboBox_3.TextChanged += comboBox_3_TextChanged;
			this.class462_0.TextBox_0.TextChanged += comboBox_3_TextChanged;
		}

		internal override void AwareOfDpi(PointF newDpi)
		{
			base.AwareOfDpi(newDpi);
			this.method_9(newDpi);
			base.m_btnAddNewRow.Image = ResourceProvider.GetSmallIcon(ResourceProvider.GeneralItem.TXITEM_Add.ToString(), newDpi.X);
			base.m_btnRemoveRow.Image = ResourceProvider.GetSmallIcon(ResourceProvider.GeneralItem.TXITEM_Remove.ToString(), newDpi.X);
			base.ColumnStyles[0].Width = Row.GetPreferredComboBoxColumnWidth(this.comboBox_0, null, base.m_pntDpi, null);
			base.ColumnStyles[1].Width = this.label_3.PreferredSize.Width + this.label_3.Margin.Horizontal;
			float maxWidth = base.GetMaxWidth(0, this.label_0.Margin.Horizontal, this.label_0, this.label_0.Font);
			base.ColumnStyles[2].Width = Math.Max(maxWidth, Class517.smethod_45(Class519.Class551.Int32_0, base.m_pntDpi.X));
			this.comboBox_1.MinimumSize = new Size((int)base.ColumnStyles[2].Width - this.comboBox_1.Margin.Horizontal, 0);
			base.UpdateFormFieldNames(this.comboBox_1, base.ColumnStyles[2].Width - (float)(Class517.smethod_45(SystemInformation.VerticalScrollBarWidth, base.m_pntDpi.X) + this.comboBox_1.Margin.Horizontal));
			this.comboBox_1.DropDownWidth = (int)Row.GetPreferredComboBoxColumnWidth(this.comboBox_1, this.label_0, base.m_pntDpi, null);
			base.ColumnStyles[3].Width = base.GetMaxWidth(0, this.comboBox_2.Margin.Horizontal, this.label_1, this.comboBox_2.Font, "ID_CONDITIONALINSTRUCTION_CBX_ROW_EQUALSTO", "ID_CONDITIONALINSTRUCTION_CBX_ROW_DOESNOTEQUALTO", "ID_CONDITIONALINSTRUCTION_CBX_ROW_MATCHESREGEX", "ID_CONDITIONALINSTRUCTION_CBX_ROW_DOESNOTMATCHREGEX", "ID_CONDITIONALINSTRUCTION_CBX_ROW_ISGREATERTHAN", "ID_CONDITIONALINSTRUCTION_CBX_ROW_ISGREATERTHANOREQUAL", "ID_CONDITIONALINSTRUCTION_CBX_ROW_ISLESSTHAN", "ID_CONDITIONALINSTRUCTION_CBX_ROW_ISLESSTHANOREQUAL", "ID_CONDITIONALINSTRUCTION_CBX_ROW_CONTAINS", "ID_CONDITIONALINSTRUCTION_CBX_ROW_DOESNOTCONTAIN", "ID_CONDITIONALINSTRUCTION_CBX_ROW_STARTSWITH", "ID_CONDITIONALINSTRUCTION_CBX_ROW_DOESNOTSTARTWITH", "ID_CONDITIONALINSTRUCTION_CBX_ROW_ENDSWITH", "ID_CONDITIONALINSTRUCTION_CBX_ROW_DOESNOTENDWITH", "ID_CONDITIONALINSTRUCTION_CBX_ROW_EQUALSTODATE", "ID_CONDITIONALINSTRUCTION_CBX_ROW_DOESNOTEQUALTODATE", "ID_CONDITIONALINSTRUCTION_CBX_ROW_ISGREATERTHANDATE", "ID_CONDITIONALINSTRUCTION_CBX_ROW_ISGREATERTHANOREQUALDATE", "ID_CONDITIONALINSTRUCTION_CBX_ROW_ISLESSTHANDATE", "ID_CONDITIONALINSTRUCTION_CBX_ROW_ISLESSTHANOREQUALDATE");
			this.float_0 = base.GetMaxWidth(Class517.smethod_45(150, base.m_pntDpi.X), this.comboBox_3.Margin.Horizontal, this.label_2, this.comboBox_3.Font, "ID_CONDITIONALINSTRUCTION_CBX_ROW_EMPTYVALUE", "ID_CONDITIONALINSTRUCTION_CBX_ROW_ANYITEM", "ID_CONDITIONALINSTRUCTION_CBX_ROW_CHECKED", "ID_CONDITIONALINSTRUCTION_CBX_ROW_SELECTED");
			this.class462_0.MaximumSize = new Size((int)this.float_0, 0);
			this.class463_0.Font = this.Font;
			this.class463_0.method_0(base.m_pntDpi);
			this.float_2 = this.class463_0.method_3(base.m_pntDpi);
			base.ColumnStyles[4].Width = Math.Max(this.float_2, this.float_0);
			this.float_1 = base.GetMaxWidth(50, this.comboBox_3.Margin.Horizontal, null, this.comboBox_3.Font, "ID_CONDITIONALINSTRUCTION_CBX_ROW_CHECKED");
			this.float_2 = this.class463_0.method_3(base.m_pntDpi);
			switch (((IConditionalInstructionElement)this.Condition_0).RelatedFormField.FormFieldType_0)
			{
			default:
				this.comboBox_3.MaximumSize = new Size((int)this.float_0, 0);
				break;
			case FormFieldType.DateFormField:
				this.comboBox_3.MaximumSize = new Size((int)this.float_2, 0);
				break;
			case FormFieldType.CheckBoxFormField:
				this.comboBox_3.MaximumSize = new Size((int)this.float_1, 0);
				break;
			}
			this.comboBox_3.MinimumSize = Size.Empty;
			base.ColumnStyles[5].Width = this.label_4.PreferredSize.Width + this.label_4.Margin.Horizontal;
			int num = (int)Math.Floor((float)this.class462_0.Padding.Vertical * base.m_pntDpi.X / 96f);
			if (num % 2 == 1)
			{
				num--;
			}
			this.class462_0.MinimumSize = new Size(0, this.class462_0.TextBox_0.PreferredHeight + num);
		}

		private void comboBox_0_SelectionChangeCommitted(object sender, EventArgs e)
		{
			this.Condition_0.LogicalConnective = (Condition.LogicalConnectives)this.comboBox_0.SelectedIndex;
			this.method_8();
			base.OnPropertyChanged("LogicalConnective");
		}

		private void comboBox_1_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (this.comboBox_1.SelectedItem != null)
			{
				this.bool_0 = true;
				this.bool_1 = false;
				this.comboBox_3.ResetText();
				this.class462_0.TextBox_0.Clear();
				this.class462_0.BackColor = Color.Transparent;
				base.CurrentFormField = this.comboBox_1.SelectedItem as FormFieldItem;
				this.Condition_0.LogicalOperators_0 = LogicalOperators.Undefined;
				((IConditionalInstructionElement)this.Condition_0).RelatedFormField.FormField_0 = base.CurrentFormField.FormField_0;
				this.Condition_0.ValueTypes_0 = ValueTypes.Undefined;
				this.Condition_0.String_0 = null;
				this.method_2();
				this.comboBox_3.Enabled = false;
				this.method_4(bool_2: false, bool_3: false);
				this.method_7();
				this.method_8();
				this.bool_0 = false;
			}
		}

		private void comboBox_2_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (this.comboBox_2.SelectedItem == null)
			{
				return;
			}
			this.comboBox_3.TextChanged -= comboBox_3_TextChanged;
			Class464 @class = this.comboBox_2.SelectedItem as Class464;
			LogicalOperators logicalOperators = (LogicalOperators)@class.Object_0;
			switch (((IConditionalInstructionElement)this.Condition_0).RelatedFormField.FormFieldType_0)
			{
			case FormFieldType.TextFormField:
			case FormFieldType.DropDownListFormField:
			case FormFieldType.ComboBoxFormField:
			case FormFieldType.DateFormField:
			{
				bool flag = logicalOperators == LogicalOperators.MatchesRegex || logicalOperators == LogicalOperators.DoesNotMatchRegex;
				bool flag2 = false;
				switch (((IConditionalInstructionElement)this.Condition_0).RelatedFormField.FormFieldType_0)
				{
				case FormFieldType.DropDownListFormField:
				case FormFieldType.ComboBoxFormField:
				{
					bool flag3 = this.Condition_0.LogicalOperators_0 == LogicalOperators.MatchesRegex || this.Condition_0.LogicalOperators_0 == LogicalOperators.DoesNotMatchRegex;
					flag2 = flag != flag3 && (base.CurrentFormField.FormField_0 as SelectionFormField).Items.Length > 0;
					break;
				}
				}
				switch (logicalOperators)
				{
				default:
					if (flag2 || this.Condition_0.LogicalOperators_0 == LogicalOperators.EqualsTo || this.Condition_0.LogicalOperators_0 == LogicalOperators.DoesNotEqualTo || this.Condition_0.LogicalOperators_0 == LogicalOperators.Undefined)
					{
						this.method_4(bool_2: true, flag);
						this.method_7();
					}
					break;
				case LogicalOperators.EqualsTo:
				case LogicalOperators.DoesNotEqualTo:
					if (flag2 || (this.Condition_0.LogicalOperators_0 != LogicalOperators.EqualsTo && this.Condition_0.LogicalOperators_0 != LogicalOperators.DoesNotEqualTo))
					{
						this.method_4(bool_2: false, flag);
						this.method_7();
					}
					break;
				}
				break;
			}
			}
			this.Condition_0.LogicalOperators_0 = logicalOperators;
			if (this.bool_1 != (this.bool_1 = this.Condition_0.LogicalOperators_0 == LogicalOperators.MatchesRegex || this.Condition_0.LogicalOperators_0 == LogicalOperators.DoesNotMatchRegex))
			{
				this.comboBox_3.ResetText();
				this.class462_0.TextBox_0.Clear();
				this.class462_0.BackColor = Color.Transparent;
			}
			this.method_8();
			this.comboBox_3.TextChanged += comboBox_3_TextChanged;
		}

		private void comboBox_3_SelectionChangeCommitted(object sender, EventArgs e)
		{
			if (this.comboBox_3.SelectedItem != null)
			{
				Class464 @class = this.comboBox_3.SelectedItem as Class464;
				this.Condition_0.ValueTypes_0 = (ValueTypes)@class.Object_0;
				ValueTypes valueTypes_ = this.Condition_0.ValueTypes_0;
				if (valueTypes_ == ValueTypes.SpecificItem)
				{
					this.Condition_0.String_0 = @class.String_0;
				}
				else
				{
					this.Condition_0.String_0 = null;
				}
				this.method_8();
			}
		}

		private void comboBox_3_TextChanged(object sender, EventArgs e)
		{
			if (this.comboBox_3.SelectedIndex < 0)
			{
				this.Condition_0.ValueTypes_0 = ValueTypes.CustomValue;
				this.Condition_0.String_0 = (sender as Control).Text;
				this.method_8();
			}
		}

		private void method_0()
		{
			this.comboBox_0.SelectedIndex = (int)(Enum.IsDefined(typeof(Condition.LogicalConnectives), this.Condition_0.LogicalConnective) ? this.Condition_0.LogicalConnective : ((Condition.LogicalConnectives)(-1)));
		}

		private void method_1()
		{
			this.comboBox_1.SuspendLayout();
			this.comboBox_1.Items.Clear();
			this.comboBox_1.Items.AddRange(base.m_gvParent.List_0.ToArray());
			if (this.comboBox_1.Items.Count > 0)
			{
				if (((IConditionalInstructionElement)this.Condition_0).RelatedFormField.FormField_0 == null)
				{
					FormFieldItem formFieldItem2 = (FormFieldItem)(this.comboBox_1.SelectedItem = (base.CurrentFormField = base.m_gvParent.List_0[0]));
					((IConditionalInstructionElement)this.Condition_0).RelatedFormField.FormField_0 = base.CurrentFormField.FormField_0;
				}
				else
				{
					foreach (FormFieldItem item in this.comboBox_1.Items)
					{
						if (item.Int32_0 == ((IConditionalInstructionElement)this.Condition_0).RelatedFormField.Int32_0)
						{
							this.comboBox_1.SelectedItem = item;
							base.CurrentFormField = item;
							break;
						}
					}
				}
			}
			this.comboBox_1.ResumeLayout(performLayout: false);
		}

		private void method_2()
		{
			this.comboBox_2.SuspendLayout();
			this.comboBox_2.Items.Clear();
			switch (((IConditionalInstructionElement)this.Condition_0).RelatedFormField.FormFieldType_0)
			{
			case FormFieldType.CheckBoxFormField:
				this.comboBox_2.Items.AddRange(new object[2]
				{
					new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_EQUALSTO"), LogicalOperators.EqualsTo),
					new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_DOESNOTEQUALTO"), LogicalOperators.DoesNotEqualTo)
				});
				break;
			case FormFieldType.TextFormField:
			case FormFieldType.DropDownListFormField:
			case FormFieldType.ComboBoxFormField:
				this.comboBox_2.Items.AddRange(new object[14]
				{
					new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_EQUALSTO"), LogicalOperators.EqualsTo),
					new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_DOESNOTEQUALTO"), LogicalOperators.DoesNotEqualTo),
					new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_MATCHESREGEX"), LogicalOperators.MatchesRegex),
					new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_DOESNOTMATCHREGEX"), LogicalOperators.DoesNotMatchRegex),
					new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_CONTAINS"), LogicalOperators.Contains),
					new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_STARTSWITH"), LogicalOperators.StartsWith),
					new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_ENDSWITH"), LogicalOperators.EndsWith),
					new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_DOESNOTCONTAIN"), LogicalOperators.DoesNotContain),
					new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_DOESNOTSTARTWITH"), LogicalOperators.DoesNotStartWith),
					new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_DOESNOTENDWITH"), LogicalOperators.DoesNotEndWith),
					new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_ISGREATERTHAN"), LogicalOperators.IsGreaterThan),
					new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_ISGREATERTHANOREQUAL"), LogicalOperators.IsGreaterThanOrEqual),
					new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_ISLESSTHAN"), LogicalOperators.IsLessThan),
					new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_ISLESSTHANOREQUAL"), LogicalOperators.IsLessThanOrEqual)
				});
				break;
			case FormFieldType.DateFormField:
				this.comboBox_2.Items.AddRange(new object[6]
				{
					new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_EQUALSTODATE"), LogicalOperators.EqualsTo),
					new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_DOESNOTEQUALTODATE"), LogicalOperators.DoesNotEqualTo),
					new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_ISGREATERTHANDATE"), LogicalOperators.IsGreaterThan),
					new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_ISGREATERTHANOREQUALDATE"), LogicalOperators.IsGreaterThanOrEqual),
					new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_ISLESSTHANDATE"), LogicalOperators.IsLessThan),
					new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_ISLESSTHANOREQUALDATE"), LogicalOperators.IsLessThanOrEqual)
				});
				break;
			}
			this.comboBox_2.ResumeLayout(performLayout: false);
		}

		private void method_3()
		{
			if (Enum.IsDefined(typeof(LogicalOperators), this.Condition_0.LogicalOperators_0) && this.Condition_0.LogicalOperators_0 != 0)
			{
				foreach (Class464 item in this.comboBox_2.Items)
				{
					if ((LogicalOperators)item.Object_0 == this.Condition_0.LogicalOperators_0)
					{
						this.comboBox_2.SelectedItem = item;
						this.bool_1 = this.Condition_0.LogicalOperators_0 == LogicalOperators.MatchesRegex || this.Condition_0.LogicalOperators_0 == LogicalOperators.DoesNotMatchRegex;
						break;
					}
				}
			}
			else
			{
				this.comboBox_2.SelectedIndex = -1;
			}
		}

		private void method_4(bool bool_2, bool bool_3)
		{
			base.SuspendLayout();
			this.comboBox_3.Items.Clear();
			FormFieldType formFieldType_ = ((IConditionalInstructionElement)this.Condition_0).RelatedFormField.FormFieldType_0;
			if (formFieldType_ == FormFieldType.TextFormField)
			{
				this.comboBox_3.DropDownStyle = ComboBoxStyle.DropDown;
				this.comboBox_3.MaximumSize = new Size((int)this.float_0, 0);
				this.method_6(bool_2);
			}
			else
			{
				this.method_5();
				switch (((IConditionalInstructionElement)this.Condition_0).RelatedFormField.FormFieldType_0)
				{
				case FormFieldType.CheckBoxFormField:
					this.comboBox_3.DropDownStyle = ComboBoxStyle.DropDownList;
					this.comboBox_3.MaximumSize = new Size((int)this.float_1, 0);
					this.comboBox_3.Items.AddRange(new object[1]
					{
						new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_CHECKED"), ValueTypes.Checked)
					});
					break;
				case FormFieldType.DropDownListFormField:
				case FormFieldType.ComboBoxFormField:
				{
					this.comboBox_3.DropDownStyle = ComboBoxStyle.DropDown;
					this.comboBox_3.MaximumSize = new Size((int)this.float_0, 0);
					string[] items = (base.CurrentFormField.FormField_0 as SelectionFormField).Items;
					foreach (string text in items)
					{
						if (!string.IsNullOrEmpty(text))
						{
							this.comboBox_3.Items.Add(new Class464(text, ValueTypes.SpecificItem));
						}
					}
					if (this.comboBox_3.Items.Count > 0 && !bool_3)
					{
						if (!bool_2)
						{
							this.comboBox_3.Items.AddRange(new object[2]
							{
								new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_EMPTYVALUE"), ValueTypes.EmptyValue),
								new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_ANYITEM"), ValueTypes.AnyItem)
							});
							if (base.IsHandleCreated && !this.bool_0 && this.comboBox_3.Text.Length == 0)
							{
								this.Condition_0.ValueTypes_0 = ValueTypes.EmptyValue;
							}
						}
						else if (this.Condition_0.ValueTypes_0 == ValueTypes.EmptyValue || this.Condition_0.ValueTypes_0 == ValueTypes.AnyItem)
						{
							this.Condition_0.ValueTypes_0 = ValueTypes.Undefined;
						}
					}
					else
					{
						this.method_6(bool_2 || bool_3);
					}
					break;
				}
				case FormFieldType.DateFormField:
					this.class463_0.method_2(!bool_2);
					break;
				}
			}
			base.ResumeLayout(performLayout: true);
		}

		private void method_5()
		{
			FormFieldType formFieldType_ = ((IConditionalInstructionElement)this.Condition_0).RelatedFormField.FormFieldType_0;
			if (formFieldType_ == FormFieldType.DateFormField)
			{
				base.Controls.Remove(this.comboBox_3);
				base.Controls.Remove(this.class462_0);
				base.Controls.Add(this.class463_0, 4, 1);
			}
			else if (!base.Controls.Contains(this.comboBox_3))
			{
				base.Controls.Remove(this.class463_0);
				base.Controls.Remove(this.class462_0);
				base.Controls.Add(this.comboBox_3, 4, 1);
			}
		}

		private void method_6(bool bool_2)
		{
			if (!bool_2)
			{
				base.Controls.Remove(this.class462_0);
				base.Controls.Remove(this.class463_0);
				this.comboBox_3.Text = this.class462_0.Text;
				this.comboBox_3.Items.Add(new Class464(base.m_rm.GetString("ID_CONDITIONALINSTRUCTION_CBX_ROW_EMPTYVALUE"), ValueTypes.EmptyValue));
				if (base.IsHandleCreated && !this.bool_0 && this.comboBox_3.Text.Length == 0)
				{
					this.Condition_0.ValueTypes_0 = ValueTypes.EmptyValue;
				}
				base.Controls.Add(this.comboBox_3, 4, 1);
			}
			else
			{
				base.Controls.Remove(this.comboBox_3);
				base.Controls.Remove(this.class463_0);
				if (this.Condition_0.ValueTypes_0 == ValueTypes.EmptyValue)
				{
					this.Condition_0.ValueTypes_0 = ValueTypes.Undefined;
					this.class462_0.TextBox_0.ResetText();
				}
				base.Controls.Add(this.class462_0, 4, 1);
			}
		}

		private void method_7()
		{
			if (((IConditionalInstructionElement)this.Condition_0).RelatedFormField.FormFieldType_0 == FormFieldType.DateFormField)
			{
				this.class463_0.method_6();
			}
			else if (base.Controls.Contains(this.comboBox_3))
			{
				bool flag = Enum.IsDefined(typeof(ValueTypes), this.Condition_0.ValueTypes_0);
				switch (((IConditionalInstructionElement)this.Condition_0).RelatedFormField.FormFieldType_0)
				{
				case FormFieldType.CheckBoxFormField:
					switch (this.Condition_0.ValueTypes_0)
					{
					default:
						this.comboBox_3.SelectedIndex = 0;
						break;
					case ValueTypes.Checked:
					case ValueTypes.Selected:
						this.comboBox_2.SelectedIndex = (int)(this.Condition_0.LogicalOperators_0 - 1);
						this.comboBox_3.SelectedIndex = 0;
						break;
					case ValueTypes.Unchecked:
					case ValueTypes.Deselected:
						this.comboBox_2.SelectedIndex = 1;
						this.comboBox_3.SelectedIndex = 0;
						break;
					}
					this.Condition_0.ValueTypes_0 = ((((IConditionalInstructionElement)this.Condition_0).RelatedFormField.FormFieldType_0 == FormFieldType.CheckBoxFormField) ? ValueTypes.Checked : ValueTypes.Selected);
					break;
				case FormFieldType.TextFormField:
					if (this.Condition_0.ValueTypes_0 == ValueTypes.EmptyValue)
					{
						this.comboBox_3.SelectedIndex = 0;
					}
					else
					{
						this.comboBox_3.Text = (flag ? this.Condition_0.String_0 : "");
					}
					break;
				case FormFieldType.DropDownListFormField:
				case FormFieldType.ComboBoxFormField:
					if (this.Condition_0.ValueTypes_0 == ValueTypes.CustomValue)
					{
						this.comboBox_3.Text = this.Condition_0.String_0;
					}
					else if (flag && this.Condition_0.ValueTypes_0 != 0)
					{
						foreach (Class464 item in this.comboBox_3.Items)
						{
							if (this.Condition_0.ValueTypes_0 == ValueTypes.SpecificItem)
							{
								if (item.String_0 == this.Condition_0.String_0)
								{
									this.comboBox_3.SelectedItem = item;
									break;
								}
							}
							else if (this.Condition_0.ValueTypes_0 == (ValueTypes)item.Object_0)
							{
								this.comboBox_3.SelectedItem = item;
								break;
							}
						}
					}
					else
					{
						this.comboBox_3.SelectedIndex = -1;
						this.comboBox_3.ResetText();
					}
					break;
				}
			}
			else
			{
				this.class462_0.TextBox_0.Text = this.Condition_0.String_0;
			}
		}

		private void method_8()
		{
			bool bIsValidRow = false;
			if (this.comboBox_0.SelectedItem != null)
			{
				switch (this.Condition_0.LogicalOperators_0)
				{
				default:
					this.class462_0.Enabled = true;
					this.comboBox_3.Enabled = true;
					this.class463_0.Enabled = true;
					if (!Enum.IsDefined(typeof(ValueTypes), this.Condition_0.ValueTypes_0))
					{
						break;
					}
					if (((IConditionalInstructionElement)this.Condition_0).RelatedFormField.FormFieldType_0 == FormFieldType.DateFormField)
					{
						switch (this.Condition_0.LogicalOperators_0)
						{
						default:
							bIsValidRow = this.Condition_0.ValueTypes_0 != 0 && this.Condition_0.ValueTypes_0 != ValueTypes.EmptyValue && this.Condition_0.ValueTypes_0 != ValueTypes.DayOfWeek && ((this.Condition_0.ValueTypes_0 != ValueTypes.Date && this.Condition_0.ValueTypes_0 != ValueTypes.Year && this.Condition_0.ValueTypes_0 != ValueTypes.Month && this.Condition_0.ValueTypes_0 != ValueTypes.DayOfMonth) || !string.IsNullOrEmpty(this.Condition_0.String_0));
							break;
						case LogicalOperators.EqualsTo:
						case LogicalOperators.DoesNotEqualTo:
							bIsValidRow = this.Condition_0.ValueTypes_0 != 0 && ((this.Condition_0.ValueTypes_0 != ValueTypes.Date && this.Condition_0.ValueTypes_0 != ValueTypes.Year && this.Condition_0.ValueTypes_0 != ValueTypes.Month && this.Condition_0.ValueTypes_0 != ValueTypes.DayOfMonth && this.Condition_0.ValueTypes_0 != ValueTypes.DayOfWeek) || !string.IsNullOrEmpty(this.Condition_0.String_0));
							break;
						}
					}
					else
					{
						switch (this.Condition_0.LogicalOperators_0)
						{
						default:
							bIsValidRow = this.Condition_0.ValueTypes_0 != 0 && this.Condition_0.ValueTypes_0 != ValueTypes.EmptyValue && (this.Condition_0.ValueTypes_0 != ValueTypes.CustomValue || !string.IsNullOrEmpty(this.Condition_0.String_0));
							break;
						case LogicalOperators.EqualsTo:
						case LogicalOperators.DoesNotEqualTo:
							bIsValidRow = this.Condition_0.ValueTypes_0 != 0 && (this.Condition_0.ValueTypes_0 != ValueTypes.CustomValue || !string.IsNullOrEmpty(this.Condition_0.String_0));
							break;
						}
					}
					break;
				case LogicalOperators.MatchesRegex:
				case LogicalOperators.DoesNotMatchRegex:
					this.class462_0.Enabled = true;
					this.comboBox_3.Enabled = true;
					this.class463_0.Enabled = true;
					if (!string.IsNullOrEmpty(this.Condition_0.String_0) && ConditionalInstruction.smethod_0(this.Condition_0.String_0))
					{
						this.class462_0.BackColor = Color.Transparent;
						bIsValidRow = true;
						break;
					}
					if (string.IsNullOrEmpty(this.Condition_0.String_0))
					{
						this.class462_0.BackColor = Color.Transparent;
					}
					else
					{
						this.class462_0.BackColor = Color.Red;
					}
					bIsValidRow = false;
					break;
				case LogicalOperators.Undefined:
					this.class462_0.Enabled = false;
					this.comboBox_3.Enabled = false;
					this.class463_0.Enabled = false;
					break;
				}
			}
			if (base.m_bIsValidRow != (base.m_bIsValidRow = bIsValidRow))
			{
				base.OnPropertyChanged("IsValidCondition");
			}
		}

		private void method_9(PointF pointF_0)
		{
			Padding margin = Class517.smethod_51(new Padding(3, 0, 3, 0), pointF_0);
			Padding margin2 = Class517.smethod_51(new Padding(3, 3, 3, 7), pointF_0);
			this.label_0.Margin = margin2;
			this.label_1.Margin = margin2;
			this.label_2.Margin = margin2;
			this.comboBox_0.Margin = margin;
			this.label_3.Margin = margin;
			this.comboBox_1.Margin = margin;
			this.comboBox_2.Margin = margin;
			this.comboBox_3.Margin = margin;
			this.class462_0.Margin = margin;
			this.label_4.Margin = margin;
			base.m_btnAddNewRow.Margin = margin;
			base.m_btnRemoveRow.Margin = margin;
			base.m_btnAddNewRow.Padding = new Padding(1, 1, 0, 0);
			base.m_btnRemoveRow.Padding = new Padding(1, 1, 0, 0);
		}
	}
}
