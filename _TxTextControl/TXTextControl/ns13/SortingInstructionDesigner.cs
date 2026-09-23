using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DocumentServer.DataShaping;
using DocumentServer.Properties;

namespace ns13
{
	internal class SortingInstructionDesigner : UserControl
	{
		private string[] string_0 = new string[0];

		private bool bool_0 = true;

		private BindingList<ColumnNameDropDownItem>[] bindingList_0 = new BindingList<ColumnNameDropDownItem>[3];

		private IContainer icontainer_0;

		private TableLayoutPanel m_layoutPanel;

		private Label m_lblSepSortBy;

		private Label m_lblSepThenBy1;

		private Label m_lblSepThenBy0;

		private RadioButton m_rbDescending0;

		private Label m_lblSortBy;

		private ComboBox m_cbSortBy;

		private ComboBox m_cbThenBy0;

		private ComboBox m_cbThenBy1;

		private Label m_lblThenBy0;

		private Label m_lblThenBy1;

		private RadioButton m_rbAscending0;

		private RadioButton m_rbDescending1;

		private RadioButton m_rbAscending2;

		private RadioButton m_rbDescending2;

		private RadioButton m_rbAscending1;

		private TableLayoutPanel m_layoutPanelSortBy;

		private TableLayoutPanel m_layoutPanelThenBy0;

		private TableLayoutPanel m_layoutPanelThenBy1;

		public string[] String_0
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value ?? new string[0];
				this.method_2();
			}
		}

		public SortingInstruction[] SortingInstruction_0
		{
			get
			{
				List<SortingInstruction> list = new List<SortingInstruction>();
				if (this.m_cbSortBy.SelectedIndex > -1)
				{
					list.Add(new SortingInstruction((string)this.m_cbSortBy.SelectedValue, this.SortOrder_0));
					if (this.m_cbThenBy0.SelectedIndex > -1)
					{
						list.Add(new SortingInstruction((string)this.m_cbThenBy0.SelectedValue, this.SortOrder_1));
						if (this.m_cbThenBy1.SelectedIndex > -1)
						{
							list.Add(new SortingInstruction((string)this.m_cbThenBy1.SelectedValue, this.SortOrder_2));
						}
					}
				}
				return list.ToArray();
			}
			set
			{
				this.method_0();
				if (value != null && value.Length != 0 && !value.Any((SortingInstruction instr) => instr == null))
				{
					this.method_3(value);
				}
			}
		}

		private DocumentServer.DataShaping.SortOrder SortOrder_0
		{
			get
			{
				if (!this.m_rbAscending0.Checked)
				{
					return DocumentServer.DataShaping.SortOrder.Descending;
				}
				return DocumentServer.DataShaping.SortOrder.Ascending;
			}
		}

		private DocumentServer.DataShaping.SortOrder SortOrder_1
		{
			get
			{
				if (!this.m_rbAscending1.Checked)
				{
					return DocumentServer.DataShaping.SortOrder.Descending;
				}
				return DocumentServer.DataShaping.SortOrder.Ascending;
			}
		}

		private DocumentServer.DataShaping.SortOrder SortOrder_2
		{
			get
			{
				if (!this.m_rbAscending2.Checked)
				{
					return DocumentServer.DataShaping.SortOrder.Descending;
				}
				return DocumentServer.DataShaping.SortOrder.Ascending;
			}
		}

		public SortingInstructionDesigner(string[] string_1)
		{
			this.InitializeComponent();
			this.method_1();
			this.bool_0 = false;
			if (string_1 != null && string_1.Length != 0)
			{
				this.String_0 = string_1;
			}
		}

		public SortingInstructionDesigner()
			: this(null)
		{
		}

		public void method_0()
		{
			this.m_cbSortBy.SelectedIndex = -1;
		}

		private void m_cbSortBy_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				if (this.m_cbSortBy.SelectedIndex > -1)
				{
					RadioButton rbAscending = this.m_rbAscending0;
					this.m_rbDescending0.Enabled = true;
					rbAscending.Enabled = true;
					this.m_cbThenBy0.Enabled = true;
					return;
				}
				this.m_cbSortBy.SelectedIndex = -1;
				this.m_cbThenBy0.SelectedIndex = -1;
				this.m_rbAscending0.Checked = true;
				RadioButton rbAscending2 = this.m_rbAscending0;
				RadioButton rbDescending = this.m_rbDescending0;
				this.m_cbThenBy0.Enabled = false;
				rbDescending.Enabled = false;
				rbAscending2.Enabled = false;
			}
		}

		private void m_cbThenBy0_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				if (this.m_cbThenBy0.SelectedIndex > -1)
				{
					RadioButton rbAscending = this.m_rbAscending1;
					this.m_rbDescending1.Enabled = true;
					rbAscending.Enabled = true;
					this.m_cbThenBy1.Enabled = true;
					return;
				}
				this.m_cbThenBy0.SelectedIndex = -1;
				this.m_cbThenBy1.SelectedIndex = -1;
				this.m_rbAscending1.Checked = true;
				RadioButton rbAscending2 = this.m_rbAscending1;
				RadioButton rbDescending = this.m_rbDescending1;
				this.m_cbThenBy1.Enabled = false;
				rbDescending.Enabled = false;
				rbAscending2.Enabled = false;
			}
		}

		private void m_cbThenBy1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.bool_0)
			{
				if (this.m_cbThenBy1.SelectedIndex > -1)
				{
					RadioButton rbAscending = this.m_rbAscending2;
					this.m_rbDescending2.Enabled = true;
					rbAscending.Enabled = true;
				}
				else
				{
					this.m_cbThenBy1.SelectedIndex = -1;
					this.m_rbAscending2.Checked = true;
					RadioButton rbAscending2 = this.m_rbAscending2;
					this.m_rbDescending2.Enabled = false;
					rbAscending2.Enabled = false;
				}
			}
		}

		private void method_1()
		{
			this.m_lblSortBy.Text = Resources.SORTDESIGNER_SORT_BY;
			string text2 = (this.m_lblThenBy0.Text = (this.m_lblThenBy1.Text = Resources.SORTDESIGNER_THEN_BY));
			RadioButton rbAscending = this.m_rbAscending0;
			RadioButton rbAscending2 = this.m_rbAscending1;
			string text3 = (this.m_rbAscending2.Text = Resources.SORTDESIGNER_ASCENDING);
			text2 = (rbAscending.Text = (rbAscending2.Text = text3));
			RadioButton rbDescending = this.m_rbDescending0;
			RadioButton rbDescending2 = this.m_rbDescending1;
			text3 = (this.m_rbDescending2.Text = Resources.SORTDESIGNER_DESCENDING);
			text2 = (rbDescending.Text = (rbDescending2.Text = text3));
		}

		private void method_2()
		{
			this.bool_0 = true;
			List<ColumnNameDropDownItem> list = this.string_0.Select((string str) => new ColumnNameDropDownItem(str)).ToList();
			this.bindingList_0[0] = new BindingList<ColumnNameDropDownItem>(list);
			this.bindingList_0[1] = new BindingList<ColumnNameDropDownItem>(list);
			this.bindingList_0[2] = new BindingList<ColumnNameDropDownItem>(list);
			this.m_cbSortBy.DataSource = this.bindingList_0[0];
			this.m_cbThenBy0.DataSource = this.bindingList_0[1];
			this.m_cbThenBy1.DataSource = this.bindingList_0[2];
			ComboBox cbSortBy = this.m_cbSortBy;
			ComboBox cbThenBy = this.m_cbThenBy0;
			this.m_cbThenBy1.SelectedIndex = -1;
			cbThenBy.SelectedIndex = -1;
			cbSortBy.SelectedIndex = -1;
			this.bool_0 = false;
		}

		private void method_3(SortingInstruction[] sortingInstruction_0)
		{
			ComboBox comboBox = null;
			RadioButton radioButton = null;
			RadioButton radioButton2 = null;
			BindingList<ColumnNameDropDownItem> bindingList = null;
			int num = Math.Min(sortingInstruction_0.Length, 3);
			for (int i = 0; i < num; i++)
			{
				SortingInstruction instr = sortingInstruction_0[i];
				bindingList = this.bindingList_0[i];
				switch (i)
				{
				case 0:
					comboBox = this.m_cbSortBy;
					radioButton = this.m_rbAscending0;
					radioButton2 = this.m_rbDescending0;
					break;
				case 1:
					comboBox = this.m_cbThenBy0;
					radioButton = this.m_rbAscending1;
					radioButton2 = this.m_rbDescending1;
					break;
				case 2:
					comboBox = this.m_cbThenBy1;
					radioButton = this.m_rbAscending2;
					radioButton2 = this.m_rbDescending2;
					break;
				}
				if (!bindingList.Any((ColumnNameDropDownItem itm) => itm.ColumnName == instr.OrderBy))
				{
					bindingList.Add(new ColumnNameDropDownItem(instr.OrderBy));
				}
				comboBox.SelectedValue = instr.OrderBy;
				if (instr.SortOrder == DocumentServer.DataShaping.SortOrder.Ascending)
				{
					radioButton.Checked = true;
				}
				else
				{
					radioButton2.Checked = true;
				}
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
			this.m_lblSortBy = new System.Windows.Forms.Label();
			this.m_lblSepThenBy1 = new System.Windows.Forms.Label();
			this.m_lblSepSortBy = new System.Windows.Forms.Label();
			this.m_lblSepThenBy0 = new System.Windows.Forms.Label();
			this.m_cbSortBy = new System.Windows.Forms.ComboBox();
			this.m_cbThenBy0 = new System.Windows.Forms.ComboBox();
			this.m_cbThenBy1 = new System.Windows.Forms.ComboBox();
			this.m_lblThenBy0 = new System.Windows.Forms.Label();
			this.m_lblThenBy1 = new System.Windows.Forms.Label();
			this.m_layoutPanelSortBy = new System.Windows.Forms.TableLayoutPanel();
			this.m_rbDescending0 = new System.Windows.Forms.RadioButton();
			this.m_rbAscending0 = new System.Windows.Forms.RadioButton();
			this.m_layoutPanelThenBy0 = new System.Windows.Forms.TableLayoutPanel();
			this.m_rbAscending1 = new System.Windows.Forms.RadioButton();
			this.m_rbDescending1 = new System.Windows.Forms.RadioButton();
			this.m_layoutPanelThenBy1 = new System.Windows.Forms.TableLayoutPanel();
			this.m_rbAscending2 = new System.Windows.Forms.RadioButton();
			this.m_rbDescending2 = new System.Windows.Forms.RadioButton();
			this.m_layoutPanel.SuspendLayout();
			this.m_layoutPanelSortBy.SuspendLayout();
			this.m_layoutPanelThenBy0.SuspendLayout();
			this.m_layoutPanelThenBy1.SuspendLayout();
			base.SuspendLayout();
			this.m_layoutPanel.AutoSize = true;
			this.m_layoutPanel.ColumnCount = 4;
			this.m_layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20f));
			this.m_layoutPanel.Controls.Add(this.m_lblSortBy, 0, 0);
			this.m_layoutPanel.Controls.Add(this.m_lblSepThenBy1, 1, 4);
			this.m_layoutPanel.Controls.Add(this.m_lblSepSortBy, 1, 0);
			this.m_layoutPanel.Controls.Add(this.m_lblSepThenBy0, 1, 2);
			this.m_layoutPanel.Controls.Add(this.m_cbSortBy, 0, 1);
			this.m_layoutPanel.Controls.Add(this.m_cbThenBy0, 0, 3);
			this.m_layoutPanel.Controls.Add(this.m_cbThenBy1, 0, 5);
			this.m_layoutPanel.Controls.Add(this.m_lblThenBy0, 0, 2);
			this.m_layoutPanel.Controls.Add(this.m_lblThenBy1, 0, 4);
			this.m_layoutPanel.Controls.Add(this.m_layoutPanelSortBy, 2, 1);
			this.m_layoutPanel.Controls.Add(this.m_layoutPanelThenBy0, 2, 3);
			this.m_layoutPanel.Controls.Add(this.m_layoutPanelThenBy1, 2, 5);
			this.m_layoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_layoutPanel.Location = new System.Drawing.Point(0, 0);
			this.m_layoutPanel.Name = "m_layoutPanel";
			this.m_layoutPanel.RowCount = 6;
			this.m_layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_layoutPanel.Size = new System.Drawing.Size(833, 195);
			this.m_layoutPanel.TabIndex = 0;
			this.m_lblSortBy.AutoSize = true;
			this.m_lblSortBy.Location = new System.Drawing.Point(3, 3);
			this.m_lblSortBy.Margin = new System.Windows.Forms.Padding(3);
			this.m_lblSortBy.MinimumSize = new System.Drawing.Size(0, 25);
			this.m_lblSortBy.Name = "m_lblSortBy";
			this.m_lblSortBy.Size = new System.Drawing.Size(59, 25);
			this.m_lblSortBy.TabIndex = 7;
			this.m_lblSortBy.Text = "&Sort by";
			this.m_lblSepThenBy1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.m_layoutPanel.SetColumnSpan(this.m_lblSepThenBy1, 3);
			this.m_lblSepThenBy1.Location = new System.Drawing.Point(81, 145);
			this.m_lblSepThenBy1.Margin = new System.Windows.Forms.Padding(10, 15, 0, 0);
			this.m_lblSepThenBy1.Name = "m_lblSepThenBy1";
			this.m_lblSepThenBy1.Size = new System.Drawing.Size(600, 2);
			this.m_lblSepThenBy1.TabIndex = 2;
			this.m_lblSepSortBy.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.m_layoutPanel.SetColumnSpan(this.m_lblSepSortBy, 3);
			this.m_lblSepSortBy.Location = new System.Drawing.Point(81, 15);
			this.m_lblSepSortBy.Margin = new System.Windows.Forms.Padding(10, 15, 0, 0);
			this.m_lblSepSortBy.Name = "m_lblSepSortBy";
			this.m_lblSepSortBy.Size = new System.Drawing.Size(600, 2);
			this.m_lblSepSortBy.TabIndex = 0;
			this.m_lblSepThenBy0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.m_layoutPanel.SetColumnSpan(this.m_lblSepThenBy0, 3);
			this.m_lblSepThenBy0.Location = new System.Drawing.Point(81, 80);
			this.m_lblSepThenBy0.Margin = new System.Windows.Forms.Padding(10, 15, 0, 0);
			this.m_lblSepThenBy0.Name = "m_lblSepThenBy0";
			this.m_lblSepThenBy0.Size = new System.Drawing.Size(600, 2);
			this.m_lblSepThenBy0.TabIndex = 1;
			this.m_layoutPanel.SetColumnSpan(this.m_cbSortBy, 2);
			this.m_cbSortBy.DisplayMember = "ColumnName";
			this.m_cbSortBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cbSortBy.FormattingEnabled = true;
			this.m_cbSortBy.Location = new System.Drawing.Point(3, 34);
			this.m_cbSortBy.Name = "m_cbSortBy";
			this.m_cbSortBy.Size = new System.Drawing.Size(300, 28);
			this.m_cbSortBy.TabIndex = 3;
			this.m_cbSortBy.ValueMember = "ColumnName";
			this.m_cbSortBy.SelectedIndexChanged += new System.EventHandler(m_cbSortBy_SelectedIndexChanged);
			this.m_layoutPanel.SetColumnSpan(this.m_cbThenBy0, 2);
			this.m_cbThenBy0.DisplayMember = "ColumnName";
			this.m_cbThenBy0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cbThenBy0.Enabled = false;
			this.m_cbThenBy0.FormattingEnabled = true;
			this.m_cbThenBy0.Location = new System.Drawing.Point(3, 99);
			this.m_cbThenBy0.Name = "m_cbThenBy0";
			this.m_cbThenBy0.Size = new System.Drawing.Size(300, 28);
			this.m_cbThenBy0.TabIndex = 4;
			this.m_cbThenBy0.ValueMember = "ColumnName";
			this.m_cbThenBy0.SelectedIndexChanged += new System.EventHandler(m_cbThenBy0_SelectedIndexChanged);
			this.m_layoutPanel.SetColumnSpan(this.m_cbThenBy1, 2);
			this.m_cbThenBy1.DisplayMember = "ColumnName";
			this.m_cbThenBy1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cbThenBy1.Enabled = false;
			this.m_cbThenBy1.FormattingEnabled = true;
			this.m_cbThenBy1.Location = new System.Drawing.Point(3, 164);
			this.m_cbThenBy1.Name = "m_cbThenBy1";
			this.m_cbThenBy1.Size = new System.Drawing.Size(300, 28);
			this.m_cbThenBy1.TabIndex = 5;
			this.m_cbThenBy1.ValueMember = "ColumnName";
			this.m_cbThenBy1.SelectedIndexChanged += new System.EventHandler(m_cbThenBy1_SelectedIndexChanged);
			this.m_lblThenBy0.AutoSize = true;
			this.m_lblThenBy0.Location = new System.Drawing.Point(3, 68);
			this.m_lblThenBy0.Margin = new System.Windows.Forms.Padding(3);
			this.m_lblThenBy0.MinimumSize = new System.Drawing.Size(0, 25);
			this.m_lblThenBy0.Name = "m_lblThenBy0";
			this.m_lblThenBy0.Size = new System.Drawing.Size(65, 25);
			this.m_lblThenBy0.TabIndex = 6;
			this.m_lblThenBy0.Text = "&Then by";
			this.m_lblThenBy1.AutoSize = true;
			this.m_lblThenBy1.Location = new System.Drawing.Point(3, 133);
			this.m_lblThenBy1.Margin = new System.Windows.Forms.Padding(3);
			this.m_lblThenBy1.MinimumSize = new System.Drawing.Size(0, 25);
			this.m_lblThenBy1.Name = "m_lblThenBy1";
			this.m_lblThenBy1.Size = new System.Drawing.Size(65, 25);
			this.m_lblThenBy1.TabIndex = 8;
			this.m_lblThenBy1.Text = "&Then by";
			this.m_layoutPanelSortBy.AutoSize = true;
			this.m_layoutPanelSortBy.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_layoutPanelSortBy.ColumnCount = 2;
			this.m_layoutPanelSortBy.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_layoutPanelSortBy.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_layoutPanelSortBy.Controls.Add(this.m_rbDescending0, 1, 0);
			this.m_layoutPanelSortBy.Controls.Add(this.m_rbAscending0, 0, 0);
			this.m_layoutPanelSortBy.Location = new System.Drawing.Point(309, 31);
			this.m_layoutPanelSortBy.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.m_layoutPanelSortBy.Name = "m_layoutPanelSortBy";
			this.m_layoutPanelSortBy.RowCount = 1;
			this.m_layoutPanelSortBy.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_layoutPanelSortBy.Size = new System.Drawing.Size(240, 30);
			this.m_layoutPanelSortBy.TabIndex = 15;
			this.m_rbDescending0.AutoSize = true;
			this.m_rbDescending0.Enabled = false;
			this.m_rbDescending0.Location = new System.Drawing.Point(118, 3);
			this.m_rbDescending0.Name = "m_rbDescending0";
			this.m_rbDescending0.Size = new System.Drawing.Size(119, 24);
			this.m_rbDescending0.TabIndex = 10;
			this.m_rbDescending0.Text = "Descending";
			this.m_rbDescending0.UseVisualStyleBackColor = true;
			this.m_rbAscending0.AutoSize = true;
			this.m_rbAscending0.Checked = true;
			this.m_rbAscending0.Enabled = false;
			this.m_rbAscending0.Location = new System.Drawing.Point(3, 3);
			this.m_rbAscending0.Name = "m_rbAscending0";
			this.m_rbAscending0.Size = new System.Drawing.Size(109, 24);
			this.m_rbAscending0.TabIndex = 9;
			this.m_rbAscending0.TabStop = true;
			this.m_rbAscending0.Text = "Ascending";
			this.m_rbAscending0.UseVisualStyleBackColor = true;
			this.m_layoutPanelThenBy0.AutoSize = true;
			this.m_layoutPanelThenBy0.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_layoutPanelThenBy0.ColumnCount = 2;
			this.m_layoutPanelThenBy0.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_layoutPanelThenBy0.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_layoutPanelThenBy0.Controls.Add(this.m_rbAscending1, 0, 0);
			this.m_layoutPanelThenBy0.Controls.Add(this.m_rbDescending1, 1, 0);
			this.m_layoutPanelThenBy0.Location = new System.Drawing.Point(309, 96);
			this.m_layoutPanelThenBy0.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.m_layoutPanelThenBy0.Name = "m_layoutPanelThenBy0";
			this.m_layoutPanelThenBy0.RowCount = 1;
			this.m_layoutPanelThenBy0.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_layoutPanelThenBy0.Size = new System.Drawing.Size(240, 30);
			this.m_layoutPanelThenBy0.TabIndex = 16;
			this.m_rbAscending1.AutoSize = true;
			this.m_rbAscending1.Checked = true;
			this.m_rbAscending1.Enabled = false;
			this.m_rbAscending1.Location = new System.Drawing.Point(3, 3);
			this.m_rbAscending1.Name = "m_rbAscending1";
			this.m_rbAscending1.Size = new System.Drawing.Size(109, 24);
			this.m_rbAscending1.TabIndex = 11;
			this.m_rbAscending1.TabStop = true;
			this.m_rbAscending1.Text = "Ascending";
			this.m_rbAscending1.UseVisualStyleBackColor = true;
			this.m_rbDescending1.AutoSize = true;
			this.m_rbDescending1.Enabled = false;
			this.m_rbDescending1.Location = new System.Drawing.Point(118, 3);
			this.m_rbDescending1.Name = "m_rbDescending1";
			this.m_rbDescending1.Size = new System.Drawing.Size(119, 24);
			this.m_rbDescending1.TabIndex = 12;
			this.m_rbDescending1.Text = "Descending";
			this.m_rbDescending1.UseVisualStyleBackColor = true;
			this.m_layoutPanelThenBy1.AutoSize = true;
			this.m_layoutPanelThenBy1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_layoutPanelThenBy1.ColumnCount = 2;
			this.m_layoutPanelThenBy1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_layoutPanelThenBy1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.m_layoutPanelThenBy1.Controls.Add(this.m_rbAscending2, 0, 0);
			this.m_layoutPanelThenBy1.Controls.Add(this.m_rbDescending2, 1, 0);
			this.m_layoutPanelThenBy1.Location = new System.Drawing.Point(309, 161);
			this.m_layoutPanelThenBy1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.m_layoutPanelThenBy1.Name = "m_layoutPanelThenBy1";
			this.m_layoutPanelThenBy1.RowCount = 1;
			this.m_layoutPanelThenBy1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_layoutPanelThenBy1.Size = new System.Drawing.Size(240, 30);
			this.m_layoutPanelThenBy1.TabIndex = 17;
			this.m_rbAscending2.AutoSize = true;
			this.m_rbAscending2.Checked = true;
			this.m_rbAscending2.Enabled = false;
			this.m_rbAscending2.Location = new System.Drawing.Point(3, 3);
			this.m_rbAscending2.Name = "m_rbAscending2";
			this.m_rbAscending2.Size = new System.Drawing.Size(109, 24);
			this.m_rbAscending2.TabIndex = 13;
			this.m_rbAscending2.TabStop = true;
			this.m_rbAscending2.Text = "Ascending";
			this.m_rbAscending2.UseVisualStyleBackColor = true;
			this.m_rbDescending2.AutoSize = true;
			this.m_rbDescending2.Enabled = false;
			this.m_rbDescending2.Location = new System.Drawing.Point(118, 3);
			this.m_rbDescending2.Name = "m_rbDescending2";
			this.m_rbDescending2.Size = new System.Drawing.Size(119, 24);
			this.m_rbDescending2.TabIndex = 14;
			this.m_rbDescending2.Text = "Descending";
			this.m_rbDescending2.UseVisualStyleBackColor = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(9f, 20f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(this.m_layoutPanel);
			base.Name = "SortingInstructionDesigner";
			base.Size = new System.Drawing.Size(833, 222);
			this.m_layoutPanel.ResumeLayout(false);
			this.m_layoutPanel.PerformLayout();
			this.m_layoutPanelSortBy.ResumeLayout(false);
			this.m_layoutPanelSortBy.PerformLayout();
			this.m_layoutPanelThenBy0.ResumeLayout(false);
			this.m_layoutPanelThenBy0.PerformLayout();
			this.m_layoutPanelThenBy1.ResumeLayout(false);
			this.m_layoutPanelThenBy1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
