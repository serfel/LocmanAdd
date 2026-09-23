using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns11;
using DocumentServer.DataShaping;
using DocumentServer.Properties;

namespace ns13
{
	internal class FilterDesignerRow : UserControl
	{
		private bool bool_0;

		private bool bool_1 = true;

		private BindingList<ColumnNameDropDownItem> bindingList_0 = new BindingList<ColumnNameDropDownItem>();

		[CompilerGenerated]
		private EventHandler eventHandler_0;

		private IContainer icontainer_0;

		private TableLayoutPanel m_layoutPanel;

		private ComboBox m_cbField;

		private ComboBox m_cbComparison;

		private TextBox m_txtCompareTo;

		private Label m_lblField;

		private Label m_lblComparison;

		private Label m_lblCompareTo;

		private ComboBox m_cbOperator;

		public FilterInstruction FilterInstruction_0
		{
			get
			{
				string text = this.m_cbField.SelectedValue as string;
				if (text == null)
				{
					return null;
				}
				LogicalOperator logicalOperator = (LogicalOperator)this.m_cbOperator.SelectedValue;
				RelationalOperator comparisonOperator = (RelationalOperator)this.m_cbComparison.SelectedValue;
				double double_;
				object compareTo = ((!Class134.smethod_1(this.m_txtCompareTo.Text, out double_)) ? this.m_txtCompareTo.Text : ((object)double_));
				return new FilterInstruction(text, comparisonOperator, compareTo, logicalOperator);
			}
			set
			{
				if (value != null)
				{
					this.bool_1 = true;
					ComboBox cbOperator = this.m_cbOperator;
					this.m_cbField.Enabled = true;
					cbOperator.Enabled = true;
					if (!this.bindingList_0.Any((ColumnNameDropDownItem itm) => itm.ColumnName == value.ColumnName))
					{
						this.bindingList_0.Add(new ColumnNameDropDownItem(value.ColumnName));
					}
					this.m_cbField.SelectedValue = value.ColumnName;
					this.m_cbOperator.SelectedValue = value.LogicalOperator;
					this.m_cbComparison.SelectedValue = value.ComparisonOperator;
					this.m_txtCompareTo.Text = string.Format(CultureInfo.InvariantCulture, "{0}", new object[1] { value.CompareTo });
					if (this.m_cbField.SelectedIndex > -1)
					{
						ComboBox cbComparison = this.m_cbComparison;
						this.m_txtCompareTo.Enabled = true;
						cbComparison.Enabled = true;
					}
					this.bool_1 = false;
				}
			}
		}

		[Browsable(false)]
		public string[] String_0
		{
			set
			{
				this.bool_1 = true;
				value = value ?? new string[0];
				this.bindingList_0 = new BindingList<ColumnNameDropDownItem>(value.Select((string name) => new ColumnNameDropDownItem(name)).ToList());
				this.m_cbField.DataSource = this.bindingList_0;
				this.m_cbField.SelectedIndex = -1;
				this.bool_1 = false;
			}
		}

		[Category("Behavior")]
		public bool Boolean_0
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				Label lblCompareTo = this.m_lblCompareTo;
				Label lblComparison = this.m_lblComparison;
				bool flag2 = (this.m_lblField.Visible = value);
				bool visible = (lblComparison.Visible = flag2);
				lblCompareTo.Visible = visible;
				RowStyle rowStyle = this.m_layoutPanel.RowStyles[0];
				if (value)
				{
					rowStyle.SizeType = SizeType.AutoSize;
				}
				else
				{
					rowStyle.SizeType = SizeType.Absolute;
					rowStyle.Height = 0f;
				}
				this.bool_0 = value;
			}
		}

		[Category("Behavior")]
		public bool Boolean_1
		{
			get
			{
				return this.m_cbOperator.Visible;
			}
			set
			{
				this.m_cbOperator.Visible = value;
			}
		}

		public bool Boolean_2
		{
			get
			{
				if (!this.m_cbOperator.Enabled && this.m_cbOperator.Visible)
				{
					return false;
				}
				return this.m_cbField.SelectedIndex > -1;
			}
		}

		public event EventHandler FieldSelected
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public FilterDesignerRow(string[] string_0)
		{
			this.InitializeComponent();
			this.method_1();
			this.method_0(string_0 ?? new string[0]);
			this.bool_1 = false;
		}

		private void method_0(string[] string_0)
		{
			RelationalOperatorItem[] dataSource = new RelationalOperatorItem[8]
			{
				new RelationalOperatorItem(RelationalOperator.Equals),
				new RelationalOperatorItem(RelationalOperator.GreaterThan),
				new RelationalOperatorItem(RelationalOperator.GreaterThanOrEqualTo),
				new RelationalOperatorItem(RelationalOperator.LessThan),
				new RelationalOperatorItem(RelationalOperator.LessThanOrEqualTo),
				new RelationalOperatorItem(RelationalOperator.NotEqual),
				new RelationalOperatorItem(RelationalOperator.IsBlank),
				new RelationalOperatorItem(RelationalOperator.IsNotBlank)
			};
			LogicalOperatorItem[] dataSource2 = new LogicalOperatorItem[2]
			{
				new LogicalOperatorItem(LogicalOperator.And),
				new LogicalOperatorItem(LogicalOperator.const_1)
			};
			this.m_cbOperator.DataSource = dataSource2;
			this.m_cbComparison.DataSource = dataSource;
			ComboBox cbOperator = this.m_cbOperator;
			this.m_cbComparison.SelectedIndex = 0;
			cbOperator.SelectedIndex = 0;
			this.bindingList_0 = new BindingList<ColumnNameDropDownItem>(string_0.Select((string name) => new ColumnNameDropDownItem(name)).ToList());
			this.m_cbField.DataSource = this.bindingList_0;
			this.m_cbField.SelectedIndex = -1;
		}

		public FilterDesignerRow()
			: this(null)
		{
		}

		private void method_1()
		{
			this.m_lblField.Text = Resources.FILTERDESIGNER_LBL_FIELD;
			this.m_lblComparison.Text = Resources.FILTERDESIGNER_LBL_COMPARISON;
			this.m_lblCompareTo.Text = Resources.FILTERDESIGNER_LBL_COMPARE_TO;
		}

		public void method_2()
		{
			ComboBox cbOperator = this.m_cbOperator;
			this.m_cbField.Enabled = true;
			cbOperator.Enabled = true;
		}

		public void method_3()
		{
			ComboBox cbOperator = this.m_cbOperator;
			ComboBox cbField = this.m_cbField;
			ComboBox cbComparison = this.m_cbComparison;
			this.m_txtCompareTo.Enabled = false;
			cbComparison.Enabled = false;
			cbField.Enabled = false;
			cbOperator.Enabled = false;
			this.m_cbField.SelectedIndex = -1;
			ComboBox cbOperator2 = this.m_cbOperator;
			this.m_cbComparison.SelectedIndex = 0;
			cbOperator2.SelectedIndex = 0;
		}

		internal void method_4()
		{
			ComboBox cbOperator = this.m_cbOperator;
			this.m_cbField.Enabled = true;
			cbOperator.Enabled = true;
			this.m_cbField.SelectedIndex = -1;
			ComboBox cbOperator2 = this.m_cbOperator;
			this.m_cbComparison.SelectedIndex = 0;
			cbOperator2.SelectedIndex = 0;
			ComboBox cbComparison = this.m_cbComparison;
			this.m_txtCompareTo.Enabled = false;
			cbComparison.Enabled = false;
			this.m_txtCompareTo.Text = "";
		}

		protected virtual void vmethod_0()
		{
			if (this.eventHandler_0 != null)
			{
				this.eventHandler_0(this, EventArgs.Empty);
			}
		}

		private void m_cbField_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.bool_1)
			{
				ComboBox cbComparison = this.m_cbComparison;
				this.m_txtCompareTo.Enabled = true;
				cbComparison.Enabled = true;
				this.vmethod_0();
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.m_layoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.m_cbField = new System.Windows.Forms.ComboBox();
			this.m_cbComparison = new System.Windows.Forms.ComboBox();
			this.m_txtCompareTo = new System.Windows.Forms.TextBox();
			this.m_lblField = new System.Windows.Forms.Label();
			this.m_lblComparison = new System.Windows.Forms.Label();
			this.m_lblCompareTo = new System.Windows.Forms.Label();
			this.m_cbOperator = new System.Windows.Forms.ComboBox();
			this.m_layoutPanel.SuspendLayout();
			base.SuspendLayout();
			this.m_layoutPanel.AutoSize = true;
			this.m_layoutPanel.ColumnCount = 4;
			this.m_layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90f));
			this.m_layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210f));
			this.m_layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 210f));
			this.m_layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 280f));
			this.m_layoutPanel.Controls.Add(this.m_cbField, 1, 1);
			this.m_layoutPanel.Controls.Add(this.m_cbComparison, 2, 1);
			this.m_layoutPanel.Controls.Add(this.m_txtCompareTo, 3, 1);
			this.m_layoutPanel.Controls.Add(this.m_lblField, 1, 0);
			this.m_layoutPanel.Controls.Add(this.m_lblComparison, 2, 0);
			this.m_layoutPanel.Controls.Add(this.m_lblCompareTo, 3, 0);
			this.m_layoutPanel.Controls.Add(this.m_cbOperator, 0, 1);
			this.m_layoutPanel.Location = new System.Drawing.Point(0, 0);
			this.m_layoutPanel.Margin = new System.Windows.Forms.Padding(0);
			this.m_layoutPanel.Name = "m_layoutPanel";
			this.m_layoutPanel.RowCount = 2;
			this.m_layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0f));
			this.m_layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_layoutPanel.Size = new System.Drawing.Size(790, 34);
			this.m_layoutPanel.TabIndex = 1;
			this.m_cbField.DisplayMember = "ColumnName";
			this.m_cbField.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cbField.Enabled = false;
			this.m_cbField.FormattingEnabled = true;
			this.m_cbField.Location = new System.Drawing.Point(93, 3);
			this.m_cbField.Name = "m_cbField";
			this.m_cbField.Size = new System.Drawing.Size(200, 28);
			this.m_cbField.TabIndex = 1;
			this.m_cbField.ValueMember = "ColumnName";
			this.m_cbField.SelectedIndexChanged += new System.EventHandler(m_cbField_SelectedIndexChanged);
			this.m_cbComparison.DisplayMember = "Text";
			this.m_cbComparison.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cbComparison.Enabled = false;
			this.m_cbComparison.FormattingEnabled = true;
			this.m_cbComparison.Location = new System.Drawing.Point(303, 3);
			this.m_cbComparison.Name = "m_cbComparison";
			this.m_cbComparison.Size = new System.Drawing.Size(200, 28);
			this.m_cbComparison.TabIndex = 2;
			this.m_cbComparison.ValueMember = "RelationalOperator";
			this.m_txtCompareTo.Enabled = false;
			this.m_txtCompareTo.Location = new System.Drawing.Point(513, 3);
			this.m_txtCompareTo.MinimumSize = new System.Drawing.Size(200, 4);
			this.m_txtCompareTo.Name = "m_txtCompareTo";
			this.m_txtCompareTo.Size = new System.Drawing.Size(270, 26);
			this.m_txtCompareTo.TabIndex = 3;
			this.m_lblField.AutoSize = true;
			this.m_lblField.Location = new System.Drawing.Point(93, 0);
			this.m_lblField.Name = "m_lblField";
			this.m_lblField.Size = new System.Drawing.Size(47, 1);
			this.m_lblField.TabIndex = 4;
			this.m_lblField.Text = "Field:";
			this.m_lblField.Visible = false;
			this.m_lblComparison.AutoSize = true;
			this.m_lblComparison.Location = new System.Drawing.Point(303, 0);
			this.m_lblComparison.Name = "m_lblComparison";
			this.m_lblComparison.Size = new System.Drawing.Size(98, 1);
			this.m_lblComparison.TabIndex = 5;
			this.m_lblComparison.Text = "Comparison:";
			this.m_lblComparison.Visible = false;
			this.m_lblCompareTo.AutoSize = true;
			this.m_lblCompareTo.Location = new System.Drawing.Point(513, 0);
			this.m_lblCompareTo.Name = "m_lblCompareTo";
			this.m_lblCompareTo.Size = new System.Drawing.Size(96, 1);
			this.m_lblCompareTo.TabIndex = 6;
			this.m_lblCompareTo.Text = "Compare to:";
			this.m_lblCompareTo.Visible = false;
			this.m_cbOperator.DisplayMember = "Text";
			this.m_cbOperator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cbOperator.Enabled = false;
			this.m_cbOperator.FormattingEnabled = true;
			this.m_cbOperator.Location = new System.Drawing.Point(3, 3);
			this.m_cbOperator.Name = "m_cbOperator";
			this.m_cbOperator.Size = new System.Drawing.Size(80, 28);
			this.m_cbOperator.TabIndex = 7;
			this.m_cbOperator.ValueMember = "LogicalOperator";
			base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 20f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = false;
			this.BackColor = System.Drawing.SystemColors.Control;
			base.Controls.Add(this.m_layoutPanel);
			base.Margin = new System.Windows.Forms.Padding(0);
			base.Name = "FilterDesignerRow";
			base.Size = new System.Drawing.Size(795, 34);
			this.m_layoutPanel.ResumeLayout(false);
			this.m_layoutPanel.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
