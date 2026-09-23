using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DocumentServer.DataShaping;

namespace ns13
{
	internal class FilterDesigner : UserControl
	{
		private string[] string_0 = new string[0];

		private List<FilterDesignerRow> list_0 = new List<FilterDesignerRow>();

		private IContainer icontainer_0;

		private TableLayoutPanel m_layoutPanel;

		private Panel m_mainPanel;

		private FilterDesignerRow m_firstRow;

		public string[] String_0
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value ?? new string[0];
				this.method_3();
			}
		}

		public FilterInstruction[] FilterInstruction_0
		{
			get
			{
				return (from filterDesignerRow_0 in this.list_0
					where filterDesignerRow_0.Boolean_2
					select filterDesignerRow_0.FilterInstruction_0).ToArray();
			}
			set
			{
				this.method_0();
				if (value == null || value.Length == 0)
				{
					return;
				}
				this.list_0[0].FilterInstruction_0 = value[0];
				if (value.Length >= 2)
				{
					this.list_0[1].FilterInstruction_0 = value[1];
					for (int i = 2; i < value.Length; i++)
					{
						this.method_1(value[i]);
					}
					this.method_1();
				}
				if (this.list_0.Count > 1)
				{
					this.m_firstRow.FieldSelected -= method_2;
					FilterDesignerRow filterDesignerRow = this.list_0.Last();
					filterDesignerRow.FieldSelected += method_2;
					filterDesignerRow.method_2();
				}
			}
		}

		public FilterDesigner(string[] string_1)
		{
			this.InitializeComponent();
			foreach (RowStyle item in this.m_layoutPanel.RowStyles.OfType<RowStyle>())
			{
				item.Height = 0f;
				item.SizeType = SizeType.AutoSize;
			}
			this.m_firstRow.method_2();
			this.m_firstRow.FieldSelected += method_2;
			this.list_0.Add(this.m_firstRow);
			this.method_1();
			if (string_1 != null && string_1.Length != 0)
			{
				this.String_0 = string_1;
			}
		}

		public FilterDesigner()
			: this(null)
		{
		}

		public void method_0()
		{
			this.list_0 = new List<FilterDesignerRow>();
			this.list_0.Add(this.m_firstRow);
			this.m_layoutPanel.Controls.Clear();
			this.m_layoutPanel.RowCount = 1;
			RowStyle[] array = this.m_layoutPanel.RowStyles.OfType<RowStyle>().Take(2).ToArray();
			this.m_layoutPanel.RowStyles.Clear();
			this.m_layoutPanel.RowStyles.Add(array[0]);
			this.m_layoutPanel.RowStyles.Add(array[1]);
			this.m_firstRow.method_4();
			this.m_firstRow.FieldSelected -= method_2;
			this.m_firstRow.FieldSelected += method_2;
			this.m_layoutPanel.Controls.Add(this.m_firstRow, 0, 0);
			this.method_1();
		}

		private void method_1(FilterInstruction filterInstruction_0 = null)
		{
			this.m_layoutPanel.RowStyles.Add(new RowStyle(SizeType.AutoSize));
			this.m_layoutPanel.RowCount++;
			FilterDesignerRow filterDesignerRow = new FilterDesignerRow(this.string_0)
			{
				FilterInstruction_0 = filterInstruction_0
			};
			this.m_layoutPanel.Controls.Add(filterDesignerRow, 0, this.m_layoutPanel.RowCount - 1);
			this.list_0.Add(filterDesignerRow);
		}

		private void method_2(object sender, EventArgs e)
		{
			FilterDesignerRow obj = sender as FilterDesignerRow;
			obj.FieldSelected -= method_2;
			if (obj != this.m_firstRow)
			{
				this.method_1();
			}
			FilterDesignerRow filterDesignerRow = this.list_0.Last();
			filterDesignerRow.method_2();
			filterDesignerRow.FieldSelected += method_2;
		}

		private void method_3()
		{
			foreach (FilterDesignerRow item in this.list_0)
			{
				item.String_0 = this.string_0;
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
			this.m_firstRow = new ns13.FilterDesignerRow();
			this.m_mainPanel = new System.Windows.Forms.Panel();
			this.m_layoutPanel.SuspendLayout();
			this.m_mainPanel.SuspendLayout();
			base.SuspendLayout();
			this.m_layoutPanel.AutoSize = true;
			this.m_layoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_layoutPanel.ColumnCount = 1;
			this.m_layoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.m_layoutPanel.Controls.Add(this.m_firstRow, 0, 0);
			this.m_layoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_layoutPanel.Location = new System.Drawing.Point(0, 0);
			this.m_layoutPanel.Margin = new System.Windows.Forms.Padding(0);
			this.m_layoutPanel.Name = "m_layoutPanel";
			this.m_layoutPanel.RowCount = 1;
			this.m_layoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.m_layoutPanel.Size = new System.Drawing.Size(555, 144);
			this.m_layoutPanel.TabIndex = 0;
			this.m_firstRow.AutoSize = true;
			this.m_firstRow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_firstRow.BackColor = System.Drawing.SystemColors.Control;
			this.m_firstRow.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_firstRow.FilterInstruction_0 = null;
			this.m_firstRow.Boolean_0 = true;
			this.m_firstRow.Location = new System.Drawing.Point(0, 0);
			this.m_firstRow.Margin = new System.Windows.Forms.Padding(0);
			this.m_firstRow.Name = "m_firstRow";
			this.m_firstRow.Boolean_1 = false;
			this.m_firstRow.Size = new System.Drawing.Size(555, 38);
			this.m_firstRow.TabIndex = 0;
			this.m_mainPanel.AutoScroll = true;
			this.m_mainPanel.AutoSize = true;
			this.m_mainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_mainPanel.Controls.Add(this.m_layoutPanel);
			this.m_mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_mainPanel.Location = new System.Drawing.Point(0, 0);
			this.m_mainPanel.Margin = new System.Windows.Forms.Padding(2);
			this.m_mainPanel.Name = "m_mainPanel";
			this.m_mainPanel.Size = new System.Drawing.Size(555, 144);
			this.m_mainPanel.TabIndex = 1;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(this.m_mainPanel);
			base.Margin = new System.Windows.Forms.Padding(0);
			this.MaximumSize = new System.Drawing.Size(555, 144);
			this.MinimumSize = new System.Drawing.Size(555, 144);
			base.Name = "FilterDesigner";
			base.Size = new System.Drawing.Size(555, 144);
			this.m_layoutPanel.ResumeLayout(false);
			this.m_layoutPanel.PerformLayout();
			this.m_mainPanel.ResumeLayout(false);
			this.m_mainPanel.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
