using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TX_Text_Control_Words
{
	internal class TXChartDataSheet
	{
		public class ValueChangedEventArgs : EventArgs
		{
			public string NewValue { get; private set; }

			public int Row { get; private set; }

			public int Column { get; private set; }

			public ValueChangedEventArgs(int row, int column, string newValue)
			{
				this.Row = row;
				this.Column = column;
				this.NewValue = newValue;
			}
		}

		public class AxisLabelChangedEventArgs : EventArgs
		{
			public string NewLabel { get; private set; }

			public int Index { get; private set; }

			public AxisLabelChangedEventArgs(int index, string newLabel)
			{
				this.Index = index;
				this.NewLabel = newLabel;
			}
		}

		public class SeriesNameChangedEventArgs : CancelEventArgs
		{
			public string OldName;

			public string NewName { get; private set; }

			public int Index { get; private set; }

			public SeriesNameChangedEventArgs(int index, string newName)
			{
				this.Index = index;
				this.NewName = newName;
				this.OldName = string.Empty;
			}
		}

		internal class AxisLabelCellCollection
		{
			private DataGridView _dataGridView;

			public DataGridViewCell this[int index] => this._dataGridView.Rows[0].Cells[index + 1];

			public AxisLabelCellCollection(DataGridView dataGridView)
			{
				this._dataGridView = dataGridView;
			}
		}

		internal class SeriesNameCellCollection
		{
			private DataGridView _dataGridView;

			public DataGridViewCell this[int index] => this._dataGridView.Rows[index + 1].Cells[0];

			public SeriesNameCellCollection(DataGridView dataGridView)
			{
				this._dataGridView = dataGridView;
			}
		}

		internal class ValueCellCollection
		{
			private DataGridView _dataGridView;

			public DataGridViewCell this[int row, int col] => this._dataGridView.Rows[row + 1].Cells[col + 1];

			public ValueCellCollection(DataGridView dataGridView)
			{
				this._dataGridView = dataGridView;
			}
		}

		private bool _bDisableEvents;

		private Size _dataAreaSize;

		private DataGridView _dataGridView;

		private const int NumberOfRows = 1024;

		private const int NumberOfColumns = 128;

		private const string HeaderCellFontFamilyName = "Arial";

		private const float HeaderCellFontSize = 9f;

		private static readonly Color AxisLabelCellColor = Color.FromArgb(253, 219, 219);

		private static readonly Color SeriesNameCellColor = Color.FromArgb(223, 219, 249);

		private static readonly Color ValueCellColor = Color.FromArgb(239, 223, 253);

		internal Rectangle SelectionRectangle
		{
			get
			{
				if (this._dataGridView.SelectedCells.Count == 0)
				{
					return default(Rectangle);
				}
				int num = int.MaxValue;
				int num2 = int.MaxValue;
				int num3 = int.MinValue;
				int num4 = int.MinValue;
				foreach (DataGridViewCell selectedCell in this._dataGridView.SelectedCells)
				{
					num = Math.Min(num, selectedCell.ColumnIndex);
					num2 = Math.Min(num2, selectedCell.RowIndex);
					num3 = Math.Max(num3, selectedCell.ColumnIndex);
					num4 = Math.Max(num4, selectedCell.RowIndex);
				}
				return new Rectangle(num, num2, num3 - num + 1, num4 - num2 + 1);
			}
		}

		internal AxisLabelCellCollection AxisLabelCells => new AxisLabelCellCollection(this._dataGridView);

		internal SeriesNameCellCollection SeriesNameCells => new SeriesNameCellCollection(this._dataGridView);

		internal ValueCellCollection ValueCells => new ValueCellCollection(this._dataGridView);

		public event EventHandler<ValueChangedEventArgs> ValueChanged;

		public event EventHandler<AxisLabelChangedEventArgs> AxisLabelChanged;

		public event EventHandler<SeriesNameChangedEventArgs> SeriesNameChanged;

		public TXChartDataSheet(DataGridView dataGridView)
		{
			this._dataGridView = dataGridView;
			this._dataGridView.CellValueChanged += DataGridView_CellValueChanged;
			this.InitGrid();
		}

		private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (!this._bDisableEvents)
			{
				if (e.ColumnIndex == 0 && e.RowIndex >= 1)
				{
					this.ChangeSeriesName(e);
				}
				else if (e.RowIndex == 0 && e.ColumnIndex >= 1)
				{
					this.ChangeAxisLabel(e);
				}
				else if (e.ColumnIndex >= 1 && e.RowIndex >= 1)
				{
					this.ChangeValue(e);
				}
			}
		}

		private void ChangeValue(DataGridViewCellEventArgs e)
		{
			string strValAtCoord = this.GetStrValAtCoord(e.RowIndex, e.ColumnIndex);
			this.OnValueChanged(e.RowIndex - 1, e.ColumnIndex - 1, strValAtCoord);
		}

		private string GetStrValAtCoord(int row, int col)
		{
			object value = this._dataGridView.Rows[row].Cells[col].Value;
			return (value != null) ? value.ToString() : string.Empty;
		}

		private void ChangeAxisLabel(DataGridViewCellEventArgs e)
		{
			object value = this._dataGridView.Rows[0].Cells[e.ColumnIndex].Value;
			string strNewLabel = ((value != null) ? value.ToString() : string.Empty);
			this.OnAxisLabelChanged(e.ColumnIndex - 1, strNewLabel);
		}

		private void ChangeSeriesName(DataGridViewCellEventArgs e)
		{
			DataGridViewCell dataGridViewCell = this._dataGridView.Rows[e.RowIndex].Cells[0];
			object value = dataGridViewCell.Value;
			string newName = ((value != null) ? value.ToString() : string.Empty);
			SeriesNameChangedEventArgs seriesNameChangedEventArgs = new SeriesNameChangedEventArgs(e.RowIndex - 1, newName);
			this.OnSeriesNameChanged(seriesNameChangedEventArgs);
			if (seriesNameChangedEventArgs.Cancel)
			{
				dataGridViewCell.Value = seriesNameChangedEventArgs.OldName;
			}
		}

		protected virtual void OnValueChanged(int row, int column, string strNewValue)
		{
			if (this.ValueChanged != null)
			{
				ValueChangedEventArgs e = new ValueChangedEventArgs(row, column, strNewValue);
				this.ValueChanged(this, e);
			}
		}

		protected virtual void OnAxisLabelChanged(int index, string strNewLabel)
		{
			if (this.AxisLabelChanged != null)
			{
				AxisLabelChangedEventArgs e = new AxisLabelChangedEventArgs(index, strNewLabel);
				this.AxisLabelChanged(this, e);
			}
		}

		protected virtual void OnSeriesNameChanged(SeriesNameChangedEventArgs e)
		{
			if (this.SeriesNameChanged != null)
			{
				this.SeriesNameChanged(this, e);
			}
		}

		private void UpdateSeriesNames(string[] seriesNames)
		{
			this._bDisableEvents = true;
			for (int i = 1; i < this._dataAreaSize.Height + 1; i++)
			{
				this._dataGridView.Rows[i].Cells[0].Value = seriesNames[i - 1];
			}
			this._bDisableEvents = false;
		}

		private void InitGrid()
		{
			Font font = new Font("Arial", 9f, FontStyle.Bold);
			this._bDisableEvents = true;
			this._dataGridView.Columns.Add(new DataGridViewTextBoxColumn
			{
				SortMode = DataGridViewColumnSortMode.NotSortable
			});
			for (int i = 1; i < 128; i++)
			{
				DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn
				{
					SortMode = DataGridViewColumnSortMode.NotSortable
				};
				dataGridViewTextBoxColumn.HeaderText = TXChartDataSheet.IntToColumnName(i);
				dataGridViewTextBoxColumn.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
				dataGridViewTextBoxColumn.HeaderCell.Style.Font = font;
				this._dataGridView.Columns.Add(dataGridViewTextBoxColumn);
			}
			this._dataGridView.Rows.Add(1025);
			foreach (DataGridViewCell cell in this._dataGridView.Rows[0].Cells)
			{
				cell.Style.Font = font;
			}
			for (int j = 1; j <= 1024; j++)
			{
				this._dataGridView.Rows[j].HeaderCell.Style.Font = font;
				this._dataGridView.Rows[j].HeaderCell.Value = j.ToString();
				this._dataGridView.Rows[j].Cells[0].Style.Font = font;
			}
			this._dataGridView.Rows[0].Cells[0].ReadOnly = true;
			this._dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this._bDisableEvents = false;
		}

		private static string IntToColumnName(int i)
		{
			string text = string.Empty;
			int num = i;
			do
			{
				int num2 = (num - 1) % 26;
				text = TXChartDataSheet.ToChar(num2) + text;
				num = (num - num2) / 26;
			}
			while (num > 0);
			return text;
		}

		private static char ToChar(int nCur)
		{
			return (char)(65 + nCur);
		}

		private void ClearCurrentCellColoring()
		{
			this.SetCellColors(Color.White, Color.White, Color.White);
		}

		private void UpdateCellColoring(int nWidth, int nHeight)
		{
			this.ClearCurrentCellColoring();
			this.SetCellColors(TXChartDataSheet.AxisLabelCellColor, TXChartDataSheet.SeriesNameCellColor, TXChartDataSheet.ValueCellColor);
		}

		private void SetCellColors(Color colAxisLabelCell, Color colSeriesNameCell, Color colValueCell)
		{
			for (int i = 1; i < this._dataAreaSize.Width + 1; i++)
			{
				this._dataGridView.Rows[0].Cells[i].Style.BackColor = colAxisLabelCell;
			}
			for (int j = 1; j < this._dataAreaSize.Height + 1; j++)
			{
				DataGridViewRow dataGridViewRow = this._dataGridView.Rows[j];
				dataGridViewRow.Cells[0].Style.BackColor = colSeriesNameCell;
				for (int k = 1; k < this._dataAreaSize.Width + 1; k++)
				{
					dataGridViewRow.Cells[k].Style.BackColor = colValueCell;
				}
			}
		}

		internal void DisplayChartData(Chart chart)
		{
			this._bDisableEvents = true;
			int num = 0;
			int num2 = 0;
			foreach (DataPoint point in chart.Series[0].Points)
			{
				DataGridViewCell dataGridViewCell = this.AxisLabelCells[num2++];
				dataGridViewCell.Value = point.AxisLabel;
				dataGridViewCell.Style.BackColor = TXChartDataSheet.AxisLabelCellColor;
			}
			foreach (Series item in chart.Series)
			{
				num2 = 0;
				DataGridViewCell dataGridViewCell2 = this.SeriesNameCells[num];
				dataGridViewCell2.Value = item.Name;
				dataGridViewCell2.Style.BackColor = TXChartDataSheet.SeriesNameCellColor;
				foreach (DataPoint point2 in item.Points)
				{
					DataGridViewCell dataGridViewCell3 = this.ValueCells[num, num2++];
					dataGridViewCell3.Value = point2.YValues.GetValue(0).ToString();
					dataGridViewCell3.Style.BackColor = TXChartDataSheet.ValueCellColor;
				}
				num++;
			}
			for (int i = num2 + 1; i <= this._dataAreaSize.Width; i++)
			{
				for (int j = 0; j <= this._dataAreaSize.Height; j++)
				{
					DataGridViewCell dataGridViewCell4 = this._dataGridView.Rows[j].Cells[i];
					dataGridViewCell4.Value = "";
					dataGridViewCell4.Style.BackColor = Color.White;
				}
			}
			for (int k = num + 1; k <= this._dataAreaSize.Height; k++)
			{
				for (int l = 0; l <= this._dataAreaSize.Width; l++)
				{
					DataGridViewCell dataGridViewCell5 = this._dataGridView.Rows[k].Cells[l];
					dataGridViewCell5.Value = "";
					dataGridViewCell5.Style.BackColor = Color.White;
				}
			}
			this._dataAreaSize.Width = num2;
			this._dataAreaSize.Height = num;
			this._bDisableEvents = false;
		}
	}
}
