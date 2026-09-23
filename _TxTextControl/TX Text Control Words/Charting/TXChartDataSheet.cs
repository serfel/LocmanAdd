/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Windows.Forms.DataVisualization.Charting;

namespace TX_Text_Control_Words {

	/*------------------------------------------------------------------------------------------------
	** Class TXChartDataSheet
	** DataGridView adapter class.
	**----------------------------------------------------------------------------------------------*/
	class TXChartDataSheet {

		/*------------------------------------------------------------------------------------------------
		** M E M B E R S
		**----------------------------------------------------------------------------------------------*/

		private bool _bDisableEvents;     // Disables cell changed event while initializing grid.
		private Size _dataAreaSize;
		private DataGridView _dataGridView;
		private const int NumberOfRows = 1024;
		private const int NumberOfColumns = 128;
		private const string HeaderCellFontFamilyName = "Arial";
		private const float HeaderCellFontSize = 9;

		/*------------------------------------------------------------------------------------------------
		** P U B L I C    C L A S S E S  -  E V E N T A R G S  
		**----------------------------------------------------------------------------------------------*/

		/*------------------------------------------------------------------------------------------------
		** Class ValueChangedEventArgs
		**----------------------------------------------------------------------------------------------*/
		public class ValueChangedEventArgs : EventArgs {
			public string NewValue { get; private set; }
			public int Row { get; private set; }
			public int Column { get; private set; }

			public ValueChangedEventArgs(int row, int column, string newValue) {
				Row = row;
				Column = column;
				NewValue = newValue;
			}
		}

		/*------------------------------------------------------------------------------------------------
		** Class AxisLabelChangedEventArgs
		**----------------------------------------------------------------------------------------------*/
		public class AxisLabelChangedEventArgs : EventArgs {
			public string NewLabel { get; private set; }
			public int Index { get; private set; }

			public AxisLabelChangedEventArgs(int index, string newLabel) {
				Index = index;
				NewLabel = newLabel;
			}
		}

		/*------------------------------------------------------------------------------------------------
		** Class SeriesNameChangedEventArgs
		**----------------------------------------------------------------------------------------------*/
		public class SeriesNameChangedEventArgs : CancelEventArgs {
			public string NewName { get; private set; }
			public int Index { get; private set; }
			public string OldName;

			public SeriesNameChangedEventArgs(int index, string newName) {
				Index = index;
				NewName = newName;
				OldName = string.Empty;
			}
		}

		/*------------------------------------------------------------------------------------------------
		** S T A T I C
		**----------------------------------------------------------------------------------------------*/

		// Default background colors for grid
		private static readonly Color AxisLabelCellColor = Color.FromArgb(253, 219, 219);
		private static readonly Color SeriesNameCellColor = Color.FromArgb(223, 219, 249);
		private static readonly Color ValueCellColor = Color.FromArgb(239, 223, 253);

		/*------------------------------------------------------------------------------------------------
		** C O N S T R U C T O R
		**----------------------------------------------------------------------------------------------*/
		public TXChartDataSheet(DataGridView dataGridView) {
			_dataGridView = dataGridView;
			_dataGridView.CellValueChanged += new DataGridViewCellEventHandler(DataGridView_CellValueChanged);
			InitGrid();
		}

		/*------------------------------------------------------------------------------------------------
		** E V E N T H A N D L E R
		**----------------------------------------------------------------------------------------------*/

		/*------------------------------------------------------------------------------------------------
		** DataGridView_CellValueChanged method
		** Throws change events for SeriesName, AxisLabel and Value on change of datagrid's cellvalue
		** changed. Depending on which cell's value is changed. This process can be cancled by 
		** the flag _bDisableEvents.
		**----------------------------------------------------------------------------------------------*/
		private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
			if (_bDisableEvents) return;

			if ((e.ColumnIndex == 0) && (e.RowIndex >= 1)) {
				// Series name cell
				ChangeSeriesName(e);
			}
			else if ((e.RowIndex == 0) && (e.ColumnIndex >= 1)) {
				// Axis label cell
				ChangeAxisLabel(e);
			}
			else if ((e.ColumnIndex >= 1) && (e.RowIndex >= 1)) {
				// Value cell
				ChangeValue(e);
			}
		}

		/*------------------------------------------------------------------------------------------------
		** ChangeValue method
		**	Extracts the string value from the changed cell and invokes a ValueChanged exception
		**	with passing the changed value and the coordinates relative to cell (x = 1, y = 1).
		**----------------------------------------------------------------------------------------------*/
		private void ChangeValue(DataGridViewCellEventArgs e) {
			string strValue = GetStrValAtCoord(e.RowIndex, e.ColumnIndex);
			OnValueChanged(e.RowIndex - 1, e.ColumnIndex - 1, strValue);
		}

		/*------------------------------------------------------------------------------------------------
		** GetStrValAtCoord method
		**	Returns the cell's value with the passed coordinates from datagrid if string value is set else
		** returns an empty string.
		**----------------------------------------------------------------------------------------------*/
		private string GetStrValAtCoord(int row, int col) {
			string strValue;
			object value = _dataGridView.Rows[row].Cells[col].Value;
			strValue = (value != null) ? value.ToString() : string.Empty;
			return strValue;
		}

		/*------------------------------------------------------------------------------------------------
		** ChangeAxisLabel method
		**	Process the DataGridViewCellEventArgs in case of the changed cell contains an AxisLabel.
		** Extracts the changed cell's value and passing this by throwing an AxisLabelChanged event.
		**----------------------------------------------------------------------------------------------*/
		private void ChangeAxisLabel(DataGridViewCellEventArgs e) {
			string strValue;
			object value = _dataGridView.Rows[0].Cells[e.ColumnIndex].Value;
			strValue = (value != null) ? value.ToString() : string.Empty;

			OnAxisLabelChanged(e.ColumnIndex - 1, strValue);
		}

		/*------------------------------------------------------------------------------------------------
		** ChangeAxisLabel method
		**	Process the DataGridViewCellEventArgs in case of the changed cell contains a seriesname.
		** Extracts the changed cell's value and passing this by throwing a SeriesNameChanged event.
		**----------------------------------------------------------------------------------------------*/
		private void ChangeSeriesName(DataGridViewCellEventArgs e) {
			string strValue;

			DataGridViewCell cell = _dataGridView.Rows[e.RowIndex].Cells[0];
			object value = cell.Value;
			strValue = (value != null) ? value.ToString() : string.Empty;

			var args = new SeriesNameChangedEventArgs(e.RowIndex - 1, strValue);
			OnSeriesNameChanged(args);
			if (args.Cancel) cell.Value = args.OldName;
		}

		/*------------------------------------------------------------------------------------------------
		** E V E N T S
		**----------------------------------------------------------------------------------------------*/

		/*------------------------------------------------------------------------------------------------
		** ValueChanged event
		**----------------------------------------------------------------------------------------------*/
		public event EventHandler<ValueChangedEventArgs> ValueChanged;
		protected virtual void OnValueChanged(int row, int column, string strNewValue) {
			if (ValueChanged == null) return;
			var args = new ValueChangedEventArgs(row, column, strNewValue);
			ValueChanged(this, args);
		}

		/*------------------------------------------------------------------------------------------------
		** AxisLabelChanged event
		**----------------------------------------------------------------------------------------------*/
		public event EventHandler<AxisLabelChangedEventArgs> AxisLabelChanged;
		protected virtual void OnAxisLabelChanged(int index, string strNewLabel) {
			if (AxisLabelChanged == null) return;
			var args = new AxisLabelChangedEventArgs(index, strNewLabel);
			AxisLabelChanged(this, args);
		}

		/*------------------------------------------------------------------------------------------------
		** SeriesNameChanged event
		**----------------------------------------------------------------------------------------------*/
		public event EventHandler<SeriesNameChangedEventArgs> SeriesNameChanged;
		protected virtual void OnSeriesNameChanged(SeriesNameChangedEventArgs e) {
			if (SeriesNameChanged == null) return;
			SeriesNameChanged(this, e);
		}

		/*------------------------------------------------------------------------------------------------
		** H E L P E R    M E T H O D S
		**----------------------------------------------------------------------------------------------*/

		/*------------------------------------------------------------------------------------------------
		** UpdateSeriesNames method
		** Disables the event processing on updating the datagrid's cellvalue for denying circulation.
		**----------------------------------------------------------------------------------------------*/
		private void UpdateSeriesNames(string[] seriesNames) {
			_bDisableEvents = true;

			for (int i = 1; i < (_dataAreaSize.Height + 1); ++i) {
				_dataGridView.Rows[i].Cells[0].Value = seriesNames[i - 1];
			}

			_bDisableEvents = false;
		}

		/*------------------------------------------------------------------------------------------------
		** InitGrid method
		** Initialize the datagrid by setting the style for the header row and column header.
		** The header row is the first row which is initialized with ascending alphabetically characters.
		** (Start: A). The column row is the first column which is initialized with ascending numerical 
		** values (Start: 1). The event handling for cell's value changed is disabled during this process.
		**----------------------------------------------------------------------------------------------*/
		private void InitGrid() {
			var headerCellFont = new Font(HeaderCellFontFamilyName, HeaderCellFontSize, FontStyle.Bold);

			_bDisableEvents = true;

			// Create columns
			_dataGridView.Columns.Add(new DataGridViewTextBoxColumn { SortMode = DataGridViewColumnSortMode.NotSortable });

			for (int i = 1; i < NumberOfColumns; ++i) {
				var colNew = new DataGridViewTextBoxColumn { SortMode = DataGridViewColumnSortMode.NotSortable };
				colNew.HeaderText = IntToColumnName(i);
				colNew.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
				colNew.HeaderCell.Style.Font = headerCellFont;
				_dataGridView.Columns.Add(colNew);
			}

			// Create rows
			_dataGridView.Rows.Add(NumberOfRows + 1);

			// Set axis label font style to bold
			foreach (DataGridViewCell cell in _dataGridView.Rows[0].Cells) {
				cell.Style.Font = headerCellFont;
			}

			for (int i = 1; i <= NumberOfRows; ++i) {
				_dataGridView.Rows[i].HeaderCell.Style.Font = headerCellFont;
				_dataGridView.Rows[i].HeaderCell.Value = i.ToString();

				// Set series name cell font style to bold
				_dataGridView.Rows[i].Cells[0].Style.Font = headerCellFont;
			}

			_dataGridView.Rows[0].Cells[0].ReadOnly = true;
			_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			_bDisableEvents = false;
		}// InitGrid method


		/*------------------------------------------------------------------------------------------------
		** IntToColumnName method
		** Converts a number into its 1-based Excel column name equivalent.
		** (A = 1, B = 2 etc.)
		**----------------------------------------------------------------------------------------------*/
		private static string IntToColumnName(int i) {
			string result = string.Empty;
			int nCol = i, nCur;

			do {
				nCur = (nCol - 1) % 26;
				result = ToChar(nCur) + result;
				nCol = (nCol - nCur) / 26;
			}
			while (nCol > 0);

			return result;
		}

		/*------------------------------------------------------------------------------------------------
		** ToChar method
		**----------------------------------------------------------------------------------------------*/
		private static char ToChar(int nCur) {
			return (char)('A' + nCur);
		}

		/*------------------------------------------------------------------------------------------------
		** ClearCurrentCellColoring method
		** Sets the background color of the currently colorized cells to white.
		**----------------------------------------------------------------------------------------------*/
		private void ClearCurrentCellColoring() {
			SetCellColors(Color.White, Color.White, Color.White);
		}

		/*------------------------------------------------------------------------------------------------
		** UpdateCellColoring method
		** Clears the current cell coloring and sets the colors for the different kinds of cells
		** to default colors.
		**----------------------------------------------------------------------------------------------*/
		private void UpdateCellColoring(int nWidth, int nHeight) {
			ClearCurrentCellColoring();
			SetCellColors(AxisLabelCellColor, SeriesNameCellColor, ValueCellColor);
		}

		/*------------------------------------------------------------------------------------------------
		** SetCellColors method
		** Sets the cell's backgroundcolor for the different kinds of cells to the passed values.
		**----------------------------------------------------------------------------------------------*/
		private void SetCellColors(Color colAxisLabelCell, Color colSeriesNameCell, Color colValueCell) {
			// Axis label cells
			for (int i = 1; i < (_dataAreaSize.Width + 1); ++i) {
				_dataGridView.Rows[0].Cells[i].Style.BackColor = colAxisLabelCell;
			}

			for (int i = 1; i < (_dataAreaSize.Height + 1); ++i) {
				DataGridViewRow row = _dataGridView.Rows[i];
				row.Cells[0].Style.BackColor = colSeriesNameCell;  // Series name cell in current row

				// Data cells
				for (int j = 1; j < (_dataAreaSize.Width + 1); ++j) {
					row.Cells[j].Style.BackColor = colValueCell;
				}
			}
		}

		/*------------------------------------------------------------------------------------------------
		** I N T E R N A L    M E T H O D S
		**----------------------------------------------------------------------------------------------*/

		/*------------------------------------------------------------------------------------------------
		** DisplayChartData method
		** Transfers values and column headers from chart to datagridview and resets the style.
		**----------------------------------------------------------------------------------------------*/
		internal void DisplayChartData(Chart chart) {
			_bDisableEvents = true;

			int row = 0, col = 0;

			// Display column names:
			foreach (var dp in chart.Series[0].Points) {
				var cell = AxisLabelCells[col++];
				cell.Value = dp.AxisLabel;
				cell.Style.BackColor = AxisLabelCellColor;
			}

			// Get values:
			foreach (var series in chart.Series) {
				col = 0;

				var seriesNameCell = SeriesNameCells[row];
				seriesNameCell.Value = series.Name;
				seriesNameCell.Style.BackColor = SeriesNameCellColor;

				foreach (var dp in series.Points) {
					var valueCell = ValueCells[row, col++];
					valueCell.Value = dp.YValues.GetValue(0).ToString();
					valueCell.Style.BackColor = ValueCellColor;
				}
				++row;
			}

			// Clear previous content:

			// Columns
			for (int j = (col + 1); j <= _dataAreaSize.Width; ++j) {
				for (int i = 0; i <= _dataAreaSize.Height; ++i) {
					var cell = _dataGridView.Rows[i].Cells[j];
					cell.Value = "";
					cell.Style.BackColor = Color.White;
				}
			}

			// Rows
			for (int i = (row + 1); i <= _dataAreaSize.Height; ++i) {
				for (int j = 0; j <= _dataAreaSize.Width; ++j) {
					var cell = _dataGridView.Rows[i].Cells[j];
					cell.Value = "";
					cell.Style.BackColor = Color.White;
				}
			}

			// Update data area rectangle
			_dataAreaSize.Width = col;
			_dataAreaSize.Height = row;

			_bDisableEvents = false;
		}// DisplayChartData method

		/*------------------------------------------------------------------------------------------------
		** SelectionRectangle method
		** Returns the bounding rectanlge containing all selected cells. (0-based)
		**----------------------------------------------------------------------------------------------*/
		internal Rectangle SelectionRectangle {
			get {
				if (_dataGridView.SelectedCells.Count == 0) return new Rectangle();

				int nLeft = int.MaxValue;
				int nTop = int.MaxValue;
				int nRight = int.MinValue;
				int nBottom = int.MinValue;

				foreach (DataGridViewCell cell in _dataGridView.SelectedCells) {
					nLeft = Math.Min(nLeft, cell.ColumnIndex);
					nTop = Math.Min(nTop, cell.RowIndex);
					nRight = Math.Max(nRight, cell.ColumnIndex);
					nBottom = Math.Max(nBottom, cell.RowIndex);
				}

				return new Rectangle(nLeft, nTop, (nRight - nLeft) + 1, (nBottom - nTop) + 1);
			}
		}

		/*------------------------------------------------------------------------------------------------
		** I N T E R N A L    C L A S S E S
		**----------------------------------------------------------------------------------------------*/

		/*------------------------------------------------------------------------------------------------
		** Class AxisLabelCellCollection
		** Implements an adapter for managing DataGridView's cells which displaying the axis label.
		**----------------------------------------------------------------------------------------------*/
		internal class AxisLabelCellCollection {
			private DataGridView _dataGridView;

			public AxisLabelCellCollection(DataGridView dataGridView) {
				_dataGridView = dataGridView;
			}

			public DataGridViewCell this[int index] {
				get { return _dataGridView.Rows[0].Cells[index + 1]; }
			}
		}

		/*------------------------------------------------------------------------------------------------
		** Class SeriesNameCellCollection
		** Implements an adapter for managing DataGridView's cells which displaying the series name.
		**----------------------------------------------------------------------------------------------*/
		internal class SeriesNameCellCollection {
			private DataGridView _dataGridView;

			public SeriesNameCellCollection(DataGridView dataGridView) {
				_dataGridView = dataGridView;
			}

			public DataGridViewCell this[int index] {
				get { return _dataGridView.Rows[index + 1].Cells[0]; }
			}
		}

		/*------------------------------------------------------------------------------------------------
		** Class AxisLabelCellCollection
		** Implements an adapter for managing DataGridView's cells which displays the axis label.
		**----------------------------------------------------------------------------------------------*/
		internal class ValueCellCollection {
			private DataGridView _dataGridView;

			public ValueCellCollection(DataGridView dataGridView) {
				_dataGridView = dataGridView;
			}

			public DataGridViewCell this[int row, int col] {
				get { return _dataGridView.Rows[row + 1].Cells[col + 1]; }
			}
		}

		/*------------------------------------------------------------------------------------------------
		** I N T E R N A L    P R O P E R T I E S
		**----------------------------------------------------------------------------------------------*/

		/*------------------------------------------------------------------------------------------------
		** AxisLabelCells
		** Cells of the datagridview which containing an axis label.
		**----------------------------------------------------------------------------------------------*/
		internal AxisLabelCellCollection AxisLabelCells {
			get { return new AxisLabelCellCollection(_dataGridView); }
		}

		/*------------------------------------------------------------------------------------------------
		** SeriesNameCells
		** Cells of the datagridview which containing a series name.
		**----------------------------------------------------------------------------------------------*/
		internal SeriesNameCellCollection SeriesNameCells {
			get { return new SeriesNameCellCollection(_dataGridView); }
		}

		/*------------------------------------------------------------------------------------------------
		** ValueCells
		** Cells of the datagridview which containing values.
		**----------------------------------------------------------------------------------------------*/
		internal ValueCellCollection ValueCells {
			get { return new ValueCellCollection(_dataGridView); }
		}
	}
}
