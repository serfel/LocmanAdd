using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ns13;
using DocumentServer.DataShaping;
using DocumentServer.DataSources;
using DocumentServer.Properties;
using TXTextControl;
using TXTextControl.DocumentServer;

namespace DocumentServer.Windows.Forms
{
	/// <summary>The FilterAndSortDialog class allows the user to specify filters and sorting instructions for merge blocks.</summary>
	public class FilterAndSortDialog : HighDpiForm
	{
		private IContainer icontainer_0;

		private TableLayoutPanel m_layoutPanel;

		private TabControl m_tabControl;

		private TabPage m_tabPageFilter;

		private TabPage m_tabPageSort;

		private System.Windows.Forms.Button m_btnCancel;

		private System.Windows.Forms.Button m_btnOK;

		private System.Windows.Forms.Button m_btnClearAll;

		private FilterDesigner m_filterDesigner;

		private SortingInstructionDesigner m_sortingInstructionDesigner;

		/// <summary>Gets the filter instructions which were created using the dialog or sets the filter instructions which are shown when the dialog is opened.</summary>
		public FilterInstruction[] Filters
		{
			get
			{
				return this.m_filterDesigner.FilterInstruction_0;
			}
			set
			{
				this.m_filterDesigner.FilterInstruction_0 = value;
			}
		}

		/// <summary>Gets the sorting instructions which were created using the dialog or sets the sorting instructions which are shown when the dialog is opened.</summary>
		public SortingInstruction[] SortingInstructions
		{
			get
			{
				return this.m_sortingInstructionDesigner.SortingInstruction_0;
			}
			set
			{
				this.m_sortingInstructionDesigner.SortingInstruction_0 = value;
			}
		}

		/// <summary>Creates a FilterAndSortDialog object using a list of strings as a source for possible table column names.</summary>
		/// <param name="fieldNames">Specifies the possible column names.</param>
		public FilterAndSortDialog(string[] fieldNames)
		{
			this.method_2(fieldNames);
		}

		public FilterAndSortDialog(DataTableInfo table)
		{
			string[] string_ = ((table != null) ? table.Columns.Select((DataColumnInfo dataColumnInfo_0) => dataColumnInfo_0.ColumnName).ToArray() : new string[0]);
			this.method_2(string_);
		}

		public new void Show(IWin32Window owner)
		{
			throw new NotSupportedException();
		}

		public new void Show()
		{
			this.Show(null);
		}

		/// <summary>Stores filters and sorting instructions created with the dialog in a SubTextPart object if the SubTextPart is a merge block. Throws an exception if the SubTextPart object is not a merge block.</summary>
		/// <param name="subTextPart">The SubTextPart object to add the filters and sorting instructions to.</param>
		public void StoreBlockMetaData(SubTextPart subTextPart)
		{
			subTextPart.StoreMergeBlockMetaData(this.Filters, this.SortingInstructions);
		}

		private void method_2(string[] string_0)
		{
			this.method_4();
			this.method_3();
			if (string_0 != null)
			{
				this.m_filterDesigner.String_0 = string_0;
				this.m_sortingInstructionDesigner.String_0 = string_0;
			}
		}

		private void m_btnClearAll_Click(object sender, EventArgs e)
		{
			switch (this.m_tabControl.SelectedIndex)
			{
			case 1:
				this.m_sortingInstructionDesigner.method_0();
				break;
			case 0:
				this.m_filterDesigner.method_0();
				break;
			}
		}

		private void m_btnOK_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		private void method_3()
		{
			this.Text = Resources.FILTERANDSORTDLG_TITLE;
			this.m_btnOK.Text = Resources.FILTERANDSORTDLG_BTN_OK;
			this.m_btnCancel.Text = Resources.FILTERANDSORTDLG_BTN_CANCEL;
			this.m_btnClearAll.Text = Resources.FILTERANDSORTDLG_BTN_CLEAR_ALL;
			this.m_tabPageFilter.Text = Resources.FILTERANDSORTDLG_TAB_FILTER;
			this.m_tabPageSort.Text = Resources.FILTERANDSORTDLG_TAB_SORT;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void method_4()
		{
			this.m_layoutPanel = new TableLayoutPanel();
			this.m_tabControl = new TabControl();
			this.m_tabPageFilter = new TabPage();
			this.m_filterDesigner = new FilterDesigner();
			this.m_tabPageSort = new TabPage();
			this.m_sortingInstructionDesigner = new SortingInstructionDesigner();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_btnClearAll = new System.Windows.Forms.Button();
			this.m_layoutPanel.SuspendLayout();
			this.m_tabControl.SuspendLayout();
			this.m_tabPageFilter.SuspendLayout();
			this.m_tabPageSort.SuspendLayout();
			base.SuspendLayout();
			this.m_layoutPanel.ColumnCount = 4;
			this.m_layoutPanel.ColumnStyles.Add(new ColumnStyle());
			this.m_layoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.m_layoutPanel.ColumnStyles.Add(new ColumnStyle());
			this.m_layoutPanel.ColumnStyles.Add(new ColumnStyle());
			this.m_layoutPanel.Controls.Add(this.m_tabControl, 0, 0);
			this.m_layoutPanel.Controls.Add(this.m_btnCancel, 3, 1);
			this.m_layoutPanel.Controls.Add(this.m_btnOK, 2, 1);
			this.m_layoutPanel.Controls.Add(this.m_btnClearAll, 0, 1);
			this.m_layoutPanel.Dock = DockStyle.Fill;
			this.m_layoutPanel.Location = new Point(7, 7);
			this.m_layoutPanel.Margin = new Padding(0);
			this.m_layoutPanel.Name = "m_layoutPanel";
			this.m_layoutPanel.RowCount = 2;
			this.m_layoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.m_layoutPanel.RowStyles.Add(new RowStyle());
			this.m_layoutPanel.Size = new Size(647, 213);
			this.m_layoutPanel.TabIndex = 0;
			this.m_layoutPanel.SetColumnSpan(this.m_tabControl, 4);
			this.m_tabControl.Controls.Add(this.m_tabPageFilter);
			this.m_tabControl.Controls.Add(this.m_tabPageSort);
			this.m_tabControl.Dock = DockStyle.Fill;
			this.m_tabControl.Location = new Point(2, 2);
			this.m_tabControl.Margin = new Padding(2);
			this.m_tabControl.Name = "m_tabControl";
			this.m_tabControl.SelectedIndex = 0;
			this.m_tabControl.Size = new Size(643, 178);
			this.m_tabControl.TabIndex = 0;
			this.m_tabPageFilter.BackColor = SystemColors.Control;
			this.m_tabPageFilter.Controls.Add(this.m_filterDesigner);
			this.m_tabPageFilter.Location = new Point(4, 22);
			this.m_tabPageFilter.Margin = new Padding(2);
			this.m_tabPageFilter.Name = "m_tabPageFilter";
			this.m_tabPageFilter.Padding = new Padding(2);
			this.m_tabPageFilter.Size = new Size(635, 152);
			this.m_tabPageFilter.TabIndex = 0;
			this.m_tabPageFilter.Text = "Filter";
			this.m_filterDesigner.AutoSize = true;
			this.m_filterDesigner.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.m_filterDesigner.Dock = DockStyle.Fill;
			this.m_filterDesigner.String_0 = new string[0];
			this.m_filterDesigner.FilterInstruction_0 = new FilterInstruction[0];
			this.m_filterDesigner.Location = new Point(2, 2);
			this.m_filterDesigner.Margin = new Padding(0);
			this.m_filterDesigner.MaximumSize = new Size(555, 144);
			this.m_filterDesigner.MinimumSize = new Size(549, 140);
			this.m_filterDesigner.Name = "m_filterDesigner";
			this.m_filterDesigner.Size = new Size(555, 144);
			this.m_filterDesigner.TabIndex = 0;
			this.m_tabPageSort.BackColor = SystemColors.Control;
			this.m_tabPageSort.Controls.Add(this.m_sortingInstructionDesigner);
			this.m_tabPageSort.Location = new Point(4, 22);
			this.m_tabPageSort.Margin = new Padding(2);
			this.m_tabPageSort.Name = "m_tabPageSort";
			this.m_tabPageSort.Padding = new Padding(2);
			this.m_tabPageSort.Size = new Size(635, 152);
			this.m_tabPageSort.TabIndex = 1;
			this.m_tabPageSort.Text = "Sort";
			this.m_sortingInstructionDesigner.Dock = DockStyle.Fill;
			this.m_sortingInstructionDesigner.String_0 = new string[0];
			this.m_sortingInstructionDesigner.Location = new Point(2, 2);
			this.m_sortingInstructionDesigner.Margin = new Padding(1);
			this.m_sortingInstructionDesigner.Name = "m_sortingInstructionDesigner";
			this.m_sortingInstructionDesigner.Size = new Size(631, 148);
			this.m_sortingInstructionDesigner.SortingInstruction_0 = new SortingInstruction[0];
			this.m_sortingInstructionDesigner.TabIndex = 0;
			this.m_btnCancel.AutoSize = true;
			this.m_btnCancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.m_btnCancel.DialogResult = DialogResult.Cancel;
			this.m_btnCancel.Dock = DockStyle.Top;
			this.m_btnCancel.Location = new Point(573, 184);
			this.m_btnCancel.Margin = new Padding(2);
			this.m_btnCancel.MinimumSize = new Size(72, 23);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Padding = new Padding(5, 2, 5, 2);
			this.m_btnCancel.Size = new Size(72, 27);
			this.m_btnCancel.TabIndex = 1;
			this.m_btnCancel.Text = "Cancel";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			this.m_btnOK.AutoSize = true;
			this.m_btnOK.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.m_btnOK.DialogResult = DialogResult.OK;
			this.m_btnOK.Dock = DockStyle.Top;
			this.m_btnOK.Location = new Point(497, 184);
			this.m_btnOK.Margin = new Padding(2);
			this.m_btnOK.MinimumSize = new Size(72, 23);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Padding = new Padding(5, 2, 5, 2);
			this.m_btnOK.Size = new Size(72, 27);
			this.m_btnOK.TabIndex = 2;
			this.m_btnOK.Text = "OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += m_btnOK_Click;
			this.m_btnClearAll.AutoSize = true;
			this.m_btnClearAll.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.m_btnClearAll.Dock = DockStyle.Top;
			this.m_btnClearAll.Location = new Point(2, 184);
			this.m_btnClearAll.Margin = new Padding(2);
			this.m_btnClearAll.MinimumSize = new Size(72, 23);
			this.m_btnClearAll.Name = "m_btnClearAll";
			this.m_btnClearAll.Padding = new Padding(5, 2, 5, 2);
			this.m_btnClearAll.Size = new Size(72, 27);
			this.m_btnClearAll.TabIndex = 3;
			this.m_btnClearAll.Text = "&Clear All";
			this.m_btnClearAll.UseVisualStyleBackColor = true;
			this.m_btnClearAll.Click += m_btnClearAll_Click;
			base.AcceptButton = this.m_btnOK;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.CancelButton = this.m_btnCancel;
			base.ClientSize = new Size(661, 227);
			base.Controls.Add(this.m_layoutPanel);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.Margin = new Padding(2);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "FilterAndSortDialog";
			base.Padding = new Padding(7);
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterParent;
			this.Text = "Filter and Sort";
			this.m_layoutPanel.ResumeLayout(performLayout: false);
			this.m_layoutPanel.PerformLayout();
			this.m_tabControl.ResumeLayout(performLayout: false);
			this.m_tabPageFilter.ResumeLayout(performLayout: false);
			this.m_tabPageFilter.PerformLayout();
			this.m_tabPageSort.ResumeLayout(performLayout: false);
			base.ResumeLayout(performLayout: false);
		}
	}
}
