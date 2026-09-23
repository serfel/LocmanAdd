/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TX_Text_Control_Words.Properties;
using TXTextControl.DataVisualization;

namespace TX_Text_Control_Words {

	/*------------------------------------------------------------------------------------------------
	** Class ChartDataGridDialog
	** Implements a dialog which displays a data grid for editing the chart's data.
	**----------------------------------------------------------------------------------------------*/
	internal partial class ChartDataGridDialog : Form {

		/*------------------------------------------------------------------------------------------------
		** M E M B E R S
		**----------------------------------------------------------------------------------------------*/

		private ChartFrame m_chartFrame;
		private Chart m_chart;
		private TXChartDataSheet m_sheet;


		/*------------------------------------------------------------------------------------------------
		** S T A T I C
		**----------------------------------------------------------------------------------------------*/

		/*------------------------------------------------------------------------------------------------
		** ShowDialog method
		** Shows the Chart Data Grid Dialog
		**----------------------------------------------------------------------------------------------*/
		internal static DialogResult ShowDialog(ChartFrame chartFrame, Form owner) {
			var dlg = new ChartDataGridDialog(chartFrame) {
				RightToLeft = owner.RightToLeft
			};

			return dlg.ShowDialog(owner);
		}

		/*------------------------------------------------------------------------------------------------
		** C O N S T R U C T O R
		**----------------------------------------------------------------------------------------------*/
		private ChartDataGridDialog(ChartFrame chartFrame) {
			m_chartFrame = chartFrame;
			m_chart = (Chart)chartFrame.Chart;
			InitializeComponent();

			Localize();
		}


		/*------------------------------------------------------------------------------------------------
		** E V E N T H A N D L E R S
		**----------------------------------------------------------------------------------------------*/

		/*------------------------------------------------------------------------------------------------
		** frmEditChartData_Load method
		** Shows the Chart Data Grid Dialog
		**----------------------------------------------------------------------------------------------*/
		private void frmEditChartData_Load(object sender, EventArgs e) {
			m_sheet = new TXChartDataSheet(_dataGridView);
			m_sheet.DisplayChartData(m_chart);

			m_sheet.ValueChanged += Sheet_ValueChanged;
			m_sheet.AxisLabelChanged += Sheet_AxisLabelChanged;
			m_sheet.SeriesNameChanged += Sheet_SeriesNameChanged;
		}

		/*------------------------------------------------------------------------------------------------
		** E V E N T H A N D L E R S  -  S H E E T
		**----------------------------------------------------------------------------------------------*/

		/*------------------------------------------------------------------------------------------------
		** Sheet_SeriesNameChanged method
		** Updates the corresponding chart's seriesname on change of the sheet's seriesname.
		**----------------------------------------------------------------------------------------------*/
		private void Sheet_SeriesNameChanged(object sender, TXChartDataSheet.SeriesNameChangedEventArgs e) {
			bool bRefresh = false;

			// Add new serie to chart if none corresponding series is available
			if (e.Index >= m_chart.Series.Count) {
				SetDataTableHeight(e.Index + 1);
				bRefresh = true;
			}

			// Update the chart's seriesname
			try {
				m_chart.Series[e.Index].Name = e.NewName;
				m_chartFrame.Refresh();
			}
			catch (TargetInvocationException tie) {
				Utils.MessageBox.Show(this, tie.InnerException.Message, Application.ProductName);
				e.Cancel = true;
				e.OldName = m_chart.Series[e.Index].Name;
			}

			// Update the displayed chart data if new chartserie is added
			if (bRefresh) m_sheet.DisplayChartData(m_chart);
		}

		/*------------------------------------------------------------------------------------------------
		** Sheet_AxisLabelChanged method
		** Updates the datatable's width and axis's labels and refreshs the displayed chart data on
		** change of the data sheet.
		**----------------------------------------------------------------------------------------------*/
		private void Sheet_AxisLabelChanged(object sender, TXChartDataSheet.AxisLabelChangedEventArgs e) {
			bool bRefresh = false;

			if (e.Index >= m_chart.Series[0].Points.Count) {
				SetDataTableWidth(e.Index + 1);
				bRefresh = true;
			}

			foreach (Series series in m_chart.Series) {
				series.Points[e.Index].AxisLabel = e.NewLabel;
			}
			m_chartFrame.Refresh();

			if (bRefresh) m_sheet.DisplayChartData(m_chart);
		}

		/*------------------------------------------------------------------------------------------------
		** SetDataTableHeight method
		** Adds additional series specified by the passed parameter.
		** The height is the count of series. So each serie represents one row.
		**----------------------------------------------------------------------------------------------*/
		private void SetDataTableHeight(int height) {
			SeriesChartType chartType = SeriesChartType.Column;
			int nWidth = 0;

			// Add missing series:

			int nAdd = height - m_chart.Series.Count;
			if (nAdd <= 0) return;   // This method can only increase the data table height

			if (m_chart.Series.Count != 0) {
				var series = m_chart.Series[0];
				chartType = series.ChartType;
				nWidth = series.Points.Count;
			}

			for (int i = 0; i < nAdd; ++i) {
				var series = new Series();
				series.ChartType = chartType;
				series.Init(nWidth, 0D);
				m_chart.Series.Add(series);
			}
		}

		/*------------------------------------------------------------------------------------------------
		** SetDataTableWidth method
		** Adds additional points to series.
		** The count of the additional points is calculated by the difference of the first serie's points
		** and the passed parameter. So each datapoint represents one column.
		**----------------------------------------------------------------------------------------------*/
		private void SetDataTableWidth(int width) {
			if (m_chart.Series.Count == 0) return;

			// Add missing points to all existing series
			int nAdd = width - m_chart.Series[0].Points.Count;
			if (nAdd <= 0) return;  // This method can only increase the data table width

			foreach (Series series in m_chart.Series) {
				for (int i = 0; i < nAdd; ++i) {
					var point = new DataPoint(0D, 0D);
					series.Points.Add(point);
				}
			}
		}

		/*------------------------------------------------------------------------------------------------
		** Sheet_ValueChanged method
		** Updates the width and height of the datatable and updates the Y - value of the corresponding 
		** datapoint on change of this datapoint.
		**----------------------------------------------------------------------------------------------*/
		void Sheet_ValueChanged(object sender, TXChartDataSheet.ValueChangedEventArgs e) {
			double newValue;
			bool bRefresh = false;
			Double.TryParse(e.NewValue, out newValue);

			// Enlarge data table if necessary
			if (e.Row >= m_chart.Series.Count) {
				SetDataTableHeight(e.Row + 1);
				bRefresh = true;
			}
			if (e.Column >= m_chart.Series[0].Points.Count) {
				SetDataTableWidth(e.Column + 1);
				bRefresh = true;
			}

			try {
				DataPoint point = m_chart.Series[e.Row].Points[e.Column];
				point.YValues.SetValue(newValue, 0);
				m_chartFrame.Refresh();
			}
			catch (Exception exc) {
				Utils.MessageBox.Show(this, exc.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}

			if (bRefresh) m_sheet.DisplayChartData(m_chart);
		}

		/*------------------------------------------------------------------------------------------------
		** E V E N T H A N D L E R S  -  C O N T E X T M E N U
		**----------------------------------------------------------------------------------------------*/

		/*------------------------------------------------------------------------------------------------
		** CntxtMnuDataGrid_Opening method
		** Updates the contextmenu's menuitems on opening the context menu.
		**----------------------------------------------------------------------------------------------*/
		private void CntxtMnuDataGrid_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
			copyToolStripMenuItem.Enabled = _dataGridView.SelectedCells.Count > 0;

			deleteRowsToolStripMenuItem.Enabled = (m_sheet.SelectionRectangle.Top > 0);
			deleteColumnsToolStripMenuItem.Enabled = (m_sheet.SelectionRectangle.Left > 0);

			pasteToolStripMenuItem.Enabled
				= Clipboard.ContainsText() && ((_dataGridView.SelectedCells.Count == 1)
					&& ((_dataGridView.SelectedCells[0].RowIndex > 0) || (_dataGridView.SelectedCells[0].ColumnIndex > 0)));
		}

		/*------------------------------------------------------------------------------------------------
		** CopyToolStripMenuItem_Click method
		** Copies the datagridview's content to the clipboard on click.
		**----------------------------------------------------------------------------------------------*/
		private void CopyToolStripMenuItem_Click(object sender, EventArgs e) {
			try {
				Clipboard.SetDataObject(_dataGridView.GetClipboardContent());
			}
			catch { }
		}

		/*------------------------------------------------------------------------------------------------
		** PasteToolStripMenuItem_Click method
		** Pastes CSV-Data from Clipboard in the datagridview on click.
		**----------------------------------------------------------------------------------------------*/
		private void PasteToolStripMenuItem_Click(object sender, EventArgs e) {
			PasteCSVFromClipboard();
		}

		/*------------------------------------------------------------------------------------------------
		** DeleteRowsToolStripMenuItem_Click method
		** Removes all selected series from the chart on click and refreshs the ChartFrame and
		** the displayed chart data.
		**----------------------------------------------------------------------------------------------*/
		private void DeleteRowsToolStripMenuItem_Click(object sender, EventArgs e) {
			int nTop = m_sheet.SelectionRectangle.Top;
			int nBottom = m_sheet.SelectionRectangle.Bottom;
			if (nTop > m_chart.Series.Count) return;

			for (int i = Math.Min(m_chart.Series.Count - 1, nBottom - 2); i >= (nTop - 1); --i) {
				m_chart.Series.RemoveAt(i);
			}

			// Refresh chart
			m_chartFrame.Refresh();

			// Refresh displayed chart data
			m_sheet.DisplayChartData(m_chart);
		}

		/*------------------------------------------------------------------------------------------------
		** DeleteColumnsToolStripMenuItem_Click method
		** Removes on click all corresponding datapoints from the chart and refreshs the ChartFrame and
		** the displayed chart data.
		**----------------------------------------------------------------------------------------------*/
		private void DeleteColumnsToolStripMenuItem_Click(object sender, EventArgs e) {
			if (m_chart.Series.Count == 0) return;

			int nLeft = m_sheet.SelectionRectangle.Left;
			int nRight = m_sheet.SelectionRectangle.Right;

			foreach (var series in m_chart.Series) {
				if (nLeft > series.Points.Count) continue;
				for (int i = Math.Min(series.Points.Count - 1, nRight - 2); i >= (nLeft - 1); --i) {
					series.Points.RemoveAt(i);
				}
			}

			// Refresh chart
			m_chartFrame.Refresh();

			// Refresh displayed chart data
			m_sheet.DisplayChartData(m_chart);
		}

		/*------------------------------------------------------------------------------------------------
		** E V E N T H A N D L E R S  -  D A T A G R I D V I E W
		**----------------------------------------------------------------------------------------------*/

		/*------------------------------------------------------------------------------------------------
		** DataGridView_KeyDown method
		** Paste CSV Data from Clipboard when Ctrl + V or Shift + Ins is pressed and any cells is selected. 
		**----------------------------------------------------------------------------------------------*/
		private void DataGridView_KeyDown(object sender, KeyEventArgs e) {
			// Ctrl+V or Shift+Ins
			if ((e.Shift && (e.KeyCode == Keys.Insert)) || (e.Control && (e.KeyCode == Keys.V))) {
				if (_dataGridView.SelectedCells.Count != 0) {
					if ((_dataGridView.SelectedCells[0].RowIndex == 0) && (_dataGridView.SelectedCells[0].ColumnIndex == 0)) return;
					PasteCSVFromClipboard();
				}
			}
		}

		/*------------------------------------------------------------------------------------------------
		** H E L P E R   M E T H O D S
		**----------------------------------------------------------------------------------------------*/

		/*------------------------------------------------------------------------------------------------
		** Localize method
		** Localize the dialog by setting string resources.
		**----------------------------------------------------------------------------------------------*/
		private void Localize() {

			this.Text = Resources.CHARTDATAGRID_DLG_TITLE;

			// Context menu
			this.copyToolStripMenuItem.Text = Resources.CHARTDATAGRID_DLG_CTX_COPY;
			this.pasteToolStripMenuItem.Text = Resources.CHARTDATAGRID_DLG_CTX_PASTE;
			this.deleteRowsToolStripMenuItem.Text = Resources.CHARTDATAGRID_DLG_CTX_DELETEROWS;
			this.deleteColumnsToolStripMenuItem.Text = Resources.CHARTDATAGRID_DLG_CTX_DELETECOLUMNS;
		}

		/*------------------------------------------------------------------------------------------------
		** PasteCSVFromClipboard method
		** Paste CSV Data from Clipboard in current selected cell. 
		**----------------------------------------------------------------------------------------------*/
		private void PasteCSVFromClipboard() {
			char charSplit = ',';

			var dataObj = Clipboard.GetDataObject();
			if (!dataObj.GetDataPresent(DataFormats.CommaSeparatedValue)) {
				PasteTextFromClipboard();
				return;
			}

			string strCSV = string.Empty;

			object objData = dataObj.GetData(DataFormats.CommaSeparatedValue);
			if (objData is string)  // String data (e. g. when copying from DataGridView)
         {
				strCSV = (string)objData;
			}
			else if (objData is System.IO.Stream)  // Excel does this, for example
         {
				var stream = (System.IO.Stream)dataObj.GetData(DataFormats.CommaSeparatedValue);
				var reader = new System.IO.StreamReader(stream, System.Text.Encoding.Default);
				strCSV = reader.ReadToEnd();
				charSplit = ';';
			}
			else return;

			// Get array of lines
			var lines = strCSV.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

			// Get values by using the CSV Line Parser
			var data = new List<List<string>>();
			var csvLineParser = new CSVLineParser();

			foreach (var line in lines) {
				if (line == "\0") continue;
				data.Add(csvLineParser.ParseLine(line, charSplit, '"'));
			}

			// Paste data
			PasteDataToCurrentCellPosition(data);
		}

		/*------------------------------------------------------------------------------------------------
		** PasteDataToCurrentCellPosition method
		**----------------------------------------------------------------------------------------------*/
		private void PasteDataToCurrentCellPosition(List<List<string>> data) {
			if (!ValidateParsedCSVData(data)) return;

			var cell = _dataGridView.SelectedCells[0];
			int x = cell.ColumnIndex;
			int y = cell.RowIndex;

			for (int j = (data.Count - 1); j >= 0; --j) {
				// Prevent writing values outside of grid bounds
				if ((y + j) > (_dataGridView.RowCount - 1)) break;

				var line = data[j];
				for (int i = (line.Count - 1); i >= 0; --i) {
					// Prevent writing values outside of grid bounds
					if ((x + i) > (_dataGridView.ColumnCount - 1)) break;

					// Paste value into cell
					_dataGridView.Rows[y + j].Cells[x + i].Value = line[i];
				}
			}
		}

		/*------------------------------------------------------------------------------------------------
		** ValidateParsedCSVData method
		** Validates the data. The data is valid if the data is not empty and all items has the them count.
		** Returns true if the data is valid else false.
		**----------------------------------------------------------------------------------------------*/
		private bool ValidateParsedCSVData(List<List<string>> data) {
			if (data.Count == 0) return false;

			int nLineLen = data[0].Count;
			if (nLineLen == 0) return false;

			for (int i = 1; i < data.Count; ++i) {
				if (nLineLen != data[i].Count) return false;
			}

			return true;
		}

		/*------------------------------------------------------------------------------------------------
		** PasteTextFromClipboard method
		** Pastes text from the clipboard if available in the first selected cell.
		**----------------------------------------------------------------------------------------------*/
		private void PasteTextFromClipboard() {
			if (!Clipboard.ContainsText()) return;
			_dataGridView.SelectedCells[0].Value = Clipboard.GetText();
		}
	}
}
