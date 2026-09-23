using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TX_Text_Control_Words.Properties;
using TX_Text_Control_Words.Utils;
using TXTextControl.DataVisualization;

namespace TX_Text_Control_Words
{
	internal class ChartDataGridDialog : Form
	{
		private ChartFrame m_chartFrame;

		private Chart m_chart;

		private TXChartDataSheet m_sheet;

		private IContainer components;

		private DataGridView _dataGridView;

		private ContextMenuStrip _cntxtMnuDataGrid;

		private ToolStripMenuItem copyToolStripMenuItem;

		private ToolStripMenuItem pasteToolStripMenuItem;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripMenuItem deleteRowsToolStripMenuItem;

		private ToolStripMenuItem deleteColumnsToolStripMenuItem;

		internal static DialogResult ShowDialog(ChartFrame chartFrame, Form owner)
		{
			ChartDataGridDialog chartDataGridDialog = new ChartDataGridDialog(chartFrame)
			{
				RightToLeft = owner.RightToLeft
			};
			return chartDataGridDialog.ShowDialog(owner);
		}

		private ChartDataGridDialog(ChartFrame chartFrame)
		{
			this.m_chartFrame = chartFrame;
			this.m_chart = (Chart)chartFrame.Chart;
			this.InitializeComponent();
			this.Localize();
		}

		private void frmEditChartData_Load(object sender, EventArgs e)
		{
			this.m_sheet = new TXChartDataSheet(this._dataGridView);
			this.m_sheet.DisplayChartData(this.m_chart);
			this.m_sheet.ValueChanged += Sheet_ValueChanged;
			this.m_sheet.AxisLabelChanged += Sheet_AxisLabelChanged;
			this.m_sheet.SeriesNameChanged += Sheet_SeriesNameChanged;
		}

		private void Sheet_SeriesNameChanged(object sender, TXChartDataSheet.SeriesNameChangedEventArgs e)
		{
			bool flag = false;
			if (e.Index >= this.m_chart.Series.Count)
			{
				this.SetDataTableHeight(e.Index + 1);
				flag = true;
			}
			try
			{
				this.m_chart.Series[e.Index].Name = e.NewName;
				this.m_chartFrame.Refresh();
			}
			catch (TargetInvocationException ex)
			{
				TX_Text_Control_Words.Utils.MessageBox.Show(this, ex.InnerException.Message, Application.ProductName);
				e.Cancel = true;
				e.OldName = this.m_chart.Series[e.Index].Name;
			}
			if (flag)
			{
				this.m_sheet.DisplayChartData(this.m_chart);
			}
		}

		private void Sheet_AxisLabelChanged(object sender, TXChartDataSheet.AxisLabelChangedEventArgs e)
		{
			bool flag = false;
			if (e.Index >= this.m_chart.Series[0].Points.Count)
			{
				this.SetDataTableWidth(e.Index + 1);
				flag = true;
			}
			foreach (Series item in this.m_chart.Series)
			{
				item.Points[e.Index].AxisLabel = e.NewLabel;
			}
			this.m_chartFrame.Refresh();
			if (flag)
			{
				this.m_sheet.DisplayChartData(this.m_chart);
			}
		}

		private void SetDataTableHeight(int height)
		{
			SeriesChartType chartType = SeriesChartType.Column;
			int count = 0;
			int num = height - this.m_chart.Series.Count;
			if (num > 0)
			{
				if (this.m_chart.Series.Count != 0)
				{
					Series series = this.m_chart.Series[0];
					chartType = series.ChartType;
					count = series.Points.Count;
				}
				for (int i = 0; i < num; i++)
				{
					Series series2 = new Series();
					series2.ChartType = chartType;
					series2.Init(count, 0.0);
					this.m_chart.Series.Add(series2);
				}
			}
		}

		private void SetDataTableWidth(int width)
		{
			if (this.m_chart.Series.Count == 0)
			{
				return;
			}
			int num = width - this.m_chart.Series[0].Points.Count;
			if (num <= 0)
			{
				return;
			}
			foreach (Series item2 in this.m_chart.Series)
			{
				for (int i = 0; i < num; i++)
				{
					DataPoint item = new DataPoint(0.0, 0.0);
					item2.Points.Add(item);
				}
			}
		}

		private void Sheet_ValueChanged(object sender, TXChartDataSheet.ValueChangedEventArgs e)
		{
			bool flag = false;
			double.TryParse(e.NewValue, out var result);
			if (e.Row >= this.m_chart.Series.Count)
			{
				this.SetDataTableHeight(e.Row + 1);
				flag = true;
			}
			if (e.Column >= this.m_chart.Series[0].Points.Count)
			{
				this.SetDataTableWidth(e.Column + 1);
				flag = true;
			}
			try
			{
				DataPoint dataPoint = this.m_chart.Series[e.Row].Points[e.Column];
				dataPoint.YValues.SetValue(result, 0);
				this.m_chartFrame.Refresh();
			}
			catch (Exception ex)
			{
				TX_Text_Control_Words.Utils.MessageBox.Show(this, ex.Message, base.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			if (flag)
			{
				this.m_sheet.DisplayChartData(this.m_chart);
			}
		}

		private void CntxtMnuDataGrid_Opening(object sender, CancelEventArgs e)
		{
			this.copyToolStripMenuItem.Enabled = this._dataGridView.SelectedCells.Count > 0;
			this.deleteRowsToolStripMenuItem.Enabled = this.m_sheet.SelectionRectangle.Top > 0;
			this.deleteColumnsToolStripMenuItem.Enabled = this.m_sheet.SelectionRectangle.Left > 0;
			this.pasteToolStripMenuItem.Enabled = Clipboard.ContainsText() && this._dataGridView.SelectedCells.Count == 1 && (this._dataGridView.SelectedCells[0].RowIndex > 0 || this._dataGridView.SelectedCells[0].ColumnIndex > 0);
		}

		private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Clipboard.SetDataObject(this._dataGridView.GetClipboardContent());
			}
			catch
			{
			}
		}

		private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.PasteCSVFromClipboard();
		}

		private void DeleteRowsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			int top = this.m_sheet.SelectionRectangle.Top;
			int bottom = this.m_sheet.SelectionRectangle.Bottom;
			if (top <= this.m_chart.Series.Count)
			{
				for (int num = Math.Min(this.m_chart.Series.Count - 1, bottom - 2); num >= top - 1; num--)
				{
					this.m_chart.Series.RemoveAt(num);
				}
				this.m_chartFrame.Refresh();
				this.m_sheet.DisplayChartData(this.m_chart);
			}
		}

		private void DeleteColumnsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (this.m_chart.Series.Count == 0)
			{
				return;
			}
			int left = this.m_sheet.SelectionRectangle.Left;
			int right = this.m_sheet.SelectionRectangle.Right;
			foreach (Series item in this.m_chart.Series)
			{
				if (left <= item.Points.Count)
				{
					for (int num = Math.Min(item.Points.Count - 1, right - 2); num >= left - 1; num--)
					{
						item.Points.RemoveAt(num);
					}
				}
			}
			this.m_chartFrame.Refresh();
			this.m_sheet.DisplayChartData(this.m_chart);
		}

		private void DataGridView_KeyDown(object sender, KeyEventArgs e)
		{
			if (((e.Shift && e.KeyCode == Keys.Insert) || (e.Control && e.KeyCode == Keys.V)) && this._dataGridView.SelectedCells.Count != 0 && (this._dataGridView.SelectedCells[0].RowIndex != 0 || this._dataGridView.SelectedCells[0].ColumnIndex != 0))
			{
				this.PasteCSVFromClipboard();
			}
		}

		private void Localize()
		{
			this.Text = Resources.CHARTDATAGRID_DLG_TITLE;
			this.copyToolStripMenuItem.Text = Resources.CHARTDATAGRID_DLG_CTX_COPY;
			this.pasteToolStripMenuItem.Text = Resources.CHARTDATAGRID_DLG_CTX_PASTE;
			this.deleteRowsToolStripMenuItem.Text = Resources.CHARTDATAGRID_DLG_CTX_DELETEROWS;
			this.deleteColumnsToolStripMenuItem.Text = Resources.CHARTDATAGRID_DLG_CTX_DELETECOLUMNS;
		}

		private void PasteCSVFromClipboard()
		{
			char charDelim = ',';
			IDataObject dataObject = Clipboard.GetDataObject();
			if (!dataObject.GetDataPresent(DataFormats.CommaSeparatedValue))
			{
				this.PasteTextFromClipboard();
				return;
			}
			string empty = string.Empty;
			object data = dataObject.GetData(DataFormats.CommaSeparatedValue);
			if (data is string)
			{
				empty = (string)data;
			}
			else
			{
				if (!(data is Stream))
				{
					return;
				}
				Stream stream = (Stream)dataObject.GetData(DataFormats.CommaSeparatedValue);
				StreamReader streamReader = new StreamReader(stream, Encoding.Default);
				empty = streamReader.ReadToEnd();
				charDelim = ';';
			}
			string[] array = empty.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
			List<List<string>> list = new List<List<string>>();
			CSVLineParser cSVLineParser = new CSVLineParser();
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (!(text == "\0"))
				{
					list.Add(cSVLineParser.ParseLine(text, charDelim, '"'));
				}
			}
			this.PasteDataToCurrentCellPosition(list);
		}

		private void PasteDataToCurrentCellPosition(List<List<string>> data)
		{
			if (!this.ValidateParsedCSVData(data))
			{
				return;
			}
			DataGridViewCell dataGridViewCell = this._dataGridView.SelectedCells[0];
			int columnIndex = dataGridViewCell.ColumnIndex;
			int rowIndex = dataGridViewCell.RowIndex;
			int num = data.Count - 1;
			while (num >= 0 && rowIndex + num <= this._dataGridView.RowCount - 1)
			{
				List<string> list = data[num];
				int num2 = list.Count - 1;
				while (num2 >= 0 && columnIndex + num2 <= this._dataGridView.ColumnCount - 1)
				{
					this._dataGridView.Rows[rowIndex + num].Cells[columnIndex + num2].Value = list[num2];
					num2--;
				}
				num--;
			}
		}

		private bool ValidateParsedCSVData(List<List<string>> data)
		{
			if (data.Count == 0)
			{
				return false;
			}
			int count = data[0].Count;
			if (count == 0)
			{
				return false;
			}
			for (int i = 1; i < data.Count; i++)
			{
				if (count != data[i].Count)
				{
					return false;
				}
			}
			return true;
		}

		private void PasteTextFromClipboard()
		{
			if (Clipboard.ContainsText())
			{
				this._dataGridView.SelectedCells[0].Value = Clipboard.GetText();
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
			this._dataGridView = new System.Windows.Forms.DataGridView();
			this._cntxtMnuDataGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.deleteRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)this._dataGridView).BeginInit();
			this._cntxtMnuDataGrid.SuspendLayout();
			base.SuspendLayout();
			this._dataGridView.AllowUserToAddRows = false;
			this._dataGridView.AllowUserToDeleteRows = false;
			this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this._dataGridView.ContextMenuStrip = this._cntxtMnuDataGrid;
			this._dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this._dataGridView.Location = new System.Drawing.Point(0, 0);
			this._dataGridView.Name = "_dataGridView";
			dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this._dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle;
			this._dataGridView.RowHeadersWidth = 70;
			this._dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this._dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this._dataGridView.Size = new System.Drawing.Size(601, 219);
			this._dataGridView.TabIndex = 0;
			this._dataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(DataGridView_KeyDown);
			this._cntxtMnuDataGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[5] { this.copyToolStripMenuItem, this.pasteToolStripMenuItem, this.toolStripSeparator1, this.deleteRowsToolStripMenuItem, this.deleteColumnsToolStripMenuItem });
			this._cntxtMnuDataGrid.Name = "_cntxtMnuDataGrid";
			this._cntxtMnuDataGrid.Size = new System.Drawing.Size(159, 98);
			this._cntxtMnuDataGrid.Opening += new System.ComponentModel.CancelEventHandler(CntxtMnuDataGrid_Opening);
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.copyToolStripMenuItem.Text = "Copy";
			this.copyToolStripMenuItem.Click += new System.EventHandler(CopyToolStripMenuItem_Click);
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.pasteToolStripMenuItem.Text = "Paste";
			this.pasteToolStripMenuItem.Click += new System.EventHandler(PasteToolStripMenuItem_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
			this.deleteRowsToolStripMenuItem.Name = "deleteRowsToolStripMenuItem";
			this.deleteRowsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.deleteRowsToolStripMenuItem.Text = "Delete Rows";
			this.deleteRowsToolStripMenuItem.Click += new System.EventHandler(DeleteRowsToolStripMenuItem_Click);
			this.deleteColumnsToolStripMenuItem.Name = "deleteColumnsToolStripMenuItem";
			this.deleteColumnsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.deleteColumnsToolStripMenuItem.Text = "Delete Columns";
			this.deleteColumnsToolStripMenuItem.Click += new System.EventHandler(DeleteColumnsToolStripMenuItem_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			base.ClientSize = new System.Drawing.Size(601, 219);
			base.Controls.Add(this._dataGridView);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(100, 50);
			base.Name = "ChartDataGridDialog";
			this.RightToLeftLayout = true;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Datasheet";
			base.Load += new System.EventHandler(frmEditChartData_Load);
			((System.ComponentModel.ISupportInitialize)this._dataGridView).EndInit();
			this._cntxtMnuDataGrid.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
