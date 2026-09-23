using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ns21;
using ns25;
using TXTextControl;
using TXTextControl.DataVisualization;

namespace ns27
{
	internal class ChartDataGridDialog : Form
	{
		public enum DialogItem
		{
			TXITEM_DataGrid,
			TXITEM_DataGridContextMenu,
			TXITEM_CopyMenuItem,
			TXITEM_PasteMenuItem,
			TXITEM_DeleteRowsMenuItem,
			TXITEM_DeleteColumnsMenuItem,
			TXITEM_ToolStripSeparator
		}

		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private ChartFrame chartFrame_0;

		private Class440 class440_0;

		private Class490 class490_0;

		private uint uint_0;

		private IContainer icontainer_0;

		private DataGridView TXITEM_DataGrid;

		private ContextMenuStrip TXITEM_DataGridContextMenu;

		private ToolStripMenuItem TXITEM_CopyMenuItem;

		private ToolStripMenuItem TXITEM_PasteMenuItem;

		private ToolStripSeparator TXITEM_ToolStripSeparator;

		private ToolStripMenuItem TXITEM_DeleteRowsMenuItem;

		private ToolStripMenuItem TXITEM_DeleteColumnsMenuItem;

		public ChartDataGridDialog(TextControl textControl_0, ChartFrame chartFrame_1)
		{
			this.InitializeComponent();
			this.method_10(textControl_0);
			this.Text = this.resourceManager_0.GetString("ID_CHARTDATAGRID_CAPTION");
			this.TXITEM_CopyMenuItem.Text = this.resourceManager_0.GetString("ID_CHARTDATAGRID_COPY");
			this.TXITEM_PasteMenuItem.Text = this.resourceManager_0.GetString("ID_CHARTDATAGRID_PASTE");
			this.TXITEM_DeleteColumnsMenuItem.Text = this.resourceManager_0.GetString("ID_CHARTDATAGRID_DELETE_COLUMNS");
			this.TXITEM_DeleteRowsMenuItem.Text = this.resourceManager_0.GetString("ID_CHARTDATAGRID_DELETE_ROWS");
			this.RightToLeft = textControl_0.RightToLeft;
			this.chartFrame_0 = chartFrame_1;
			this.class440_0 = new Class440(chartFrame_1);
		}

		private void ChartDataGridDialog_Load(object sender, EventArgs e)
		{
			this.class490_0 = new Class490(this.TXITEM_DataGrid);
			this.class490_0.method_9(this.class440_0);
			this.class490_0.ValueChanged += method_2;
			this.class490_0.AxisLabelChanged += method_1;
			this.class490_0.SeriesNameChanged += method_0;
		}

		private void method_0(object sender, Class490.EventArgs3 e)
		{
			bool flag = false;
			if (e.Int32_0 >= this.class440_0.Class452_0.Count)
			{
				this.method_7(e.Int32_0 + 1);
				flag = true;
			}
			try
			{
				this.class440_0.Class452_0[e.Int32_0].String_0 = e.String_0;
				this.chartFrame_0.Refresh();
			}
			catch (TargetInvocationException ex)
			{
				MessageBox.Show(ex.InnerException.Message);
				e.Cancel = true;
				e.string_0 = this.class440_0.Class452_0[e.Int32_0].String_0;
			}
			if (flag)
			{
				this.class490_0.method_9(this.class440_0);
			}
		}

		private void method_1(object sender, Class490.EventArgs2 e)
		{
			bool flag = false;
			if (e.Int32_0 >= this.class440_0.Class452_0[0].Class444_0.Count)
			{
				this.method_8(e.Int32_0 + 1);
				flag = true;
			}
			foreach (Class454 item in (IEnumerable<Class454>)this.class440_0.Class452_0)
			{
				item.Class444_0[e.Int32_0].String_0 = e.String_0;
			}
			this.chartFrame_0.Refresh();
			if (flag)
			{
				this.class490_0.method_9(this.class440_0);
			}
		}

		private void method_2(object sender, Class490.EventArgs1 e)
		{
			bool flag = false;
			double.TryParse(e.String_0, out var result);
			if (e.Int32_0 >= this.class440_0.Class452_0.Count)
			{
				this.method_7(e.Int32_0 + 1);
				flag = true;
			}
			if (e.Int32_1 >= this.class440_0.Class452_0[0].Class444_0.Count)
			{
				this.method_8(e.Int32_1 + 1);
				flag = true;
			}
			try
			{
				Class446 @class = this.class440_0.Class452_0[e.Int32_0].Class444_0[e.Int32_1];
				@class.Double_0 = result;
				this.chartFrame_0.Refresh();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, base.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			if (flag)
			{
				this.class490_0.method_9(this.class440_0);
			}
		}

		private void TXITEM_DataGridContextMenu_Opening(object sender, CancelEventArgs e)
		{
			this.TXITEM_CopyMenuItem.Enabled = this.TXITEM_DataGrid.SelectedCells.Count > 0;
			this.TXITEM_DeleteRowsMenuItem.Enabled = this.class490_0.Rectangle_0.Top > 0;
			this.TXITEM_DeleteColumnsMenuItem.Enabled = this.class490_0.Rectangle_0.Left > 0;
			this.TXITEM_PasteMenuItem.Enabled = Clipboard.ContainsText() && this.TXITEM_DataGrid.SelectedCells.Count == 1 && (this.TXITEM_DataGrid.SelectedCells[0].RowIndex > 0 || this.TXITEM_DataGrid.SelectedCells[0].ColumnIndex > 0);
		}

		private void TXITEM_DataGrid_KeyDown(object sender, KeyEventArgs e)
		{
			if (((e.Shift && e.KeyCode == Keys.Insert) || (e.Control && e.KeyCode == Keys.V)) && this.TXITEM_DataGrid.SelectedCells.Count != 0 && (this.TXITEM_DataGrid.SelectedCells[0].RowIndex != 0 || this.TXITEM_DataGrid.SelectedCells[0].ColumnIndex != 0))
			{
				this.method_3();
			}
		}

		private void TXITEM_PasteMenuItem_Click(object sender, EventArgs e)
		{
			this.method_3();
		}

		private void TXITEM_DeleteRowsMenuItem_Click(object sender, EventArgs e)
		{
			int top = this.class490_0.Rectangle_0.Top;
			int bottom = this.class490_0.Rectangle_0.Bottom;
			if (top <= this.class440_0.Class452_0.Count)
			{
				for (int num = Math.Min(this.class440_0.Class452_0.Count - 1, bottom - 2); num >= top - 1; num--)
				{
					this.class440_0.Class452_0.RemoveAt(num);
				}
				this.chartFrame_0.Refresh();
				this.class490_0.method_9(this.class440_0);
			}
		}

		private void TXITEM_DeleteColumnsMenuItem_Click(object sender, EventArgs e)
		{
			if (this.class440_0.Class452_0.Count == 0)
			{
				return;
			}
			int left = this.class490_0.Rectangle_0.Left;
			int right = this.class490_0.Rectangle_0.Right;
			foreach (Class454 item in (IEnumerable<Class454>)this.class440_0.Class452_0)
			{
				if (left <= item.Class444_0.Count)
				{
					for (int num = Math.Min(item.Class444_0.Count - 1, right - 2); num >= left - 1; num--)
					{
						item.Class444_0.RemoveAt(num);
					}
				}
			}
			this.chartFrame_0.Refresh();
			this.class490_0.method_9(this.class440_0);
		}

		private void method_3()
		{
			char charDelim = ',';
			IDataObject dataObject = Clipboard.GetDataObject();
			if (!dataObject.GetDataPresent(DataFormats.CommaSeparatedValue))
			{
				this.method_6();
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
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (!(text == "\0"))
				{
					list.Add(CSVLineParser.ParseLine(text, charDelim, '"'));
				}
			}
			this.method_4(list);
		}

		private void method_4(List<List<string>> list_0)
		{
			if (!this.method_5(list_0))
			{
				return;
			}
			DataGridViewCell dataGridViewCell = this.TXITEM_DataGrid.SelectedCells[0];
			int columnIndex = dataGridViewCell.ColumnIndex;
			int rowIndex = dataGridViewCell.RowIndex;
			int num = list_0.Count - 1;
			while (num >= 0 && rowIndex + num <= this.TXITEM_DataGrid.RowCount - 1)
			{
				List<string> list = list_0[num];
				int num2 = list.Count - 1;
				while (num2 >= 0 && columnIndex + num2 <= this.TXITEM_DataGrid.ColumnCount - 1)
				{
					this.TXITEM_DataGrid.Rows[rowIndex + num].Cells[columnIndex + num2].Value = list[num2];
					num2--;
				}
				num--;
			}
		}

		private bool method_5(List<List<string>> list_0)
		{
			if (list_0.Count == 0)
			{
				return false;
			}
			int count = list_0[0].Count;
			if (count == 0)
			{
				return false;
			}
			int num = 1;
			while (true)
			{
				if (num < list_0.Count)
				{
					if (count != list_0[num].Count)
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}

		private void method_6()
		{
			if (Clipboard.ContainsText())
			{
				this.TXITEM_DataGrid.SelectedCells[0].Value = Clipboard.GetText();
			}
		}

		private void TXITEM_CopyMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Clipboard.SetDataObject(this.TXITEM_DataGrid.GetClipboardContent());
			}
			catch
			{
			}
		}

		private static void smethod_0(Class454 class454_0, int int_0, double double_0)
		{
			for (int i = 0; i < int_0; i++)
			{
				Class446 item = new Class446(double_0);
				class454_0.Class444_0.Add(item);
			}
		}

		private void method_7(int int_0)
		{
			Class454.SeriesChartType seriesChartType_ = Class454.SeriesChartType.Column;
			int int_ = 0;
			int num = int_0 - this.class440_0.Class452_0.Count;
			if (num > 0)
			{
				if (this.class440_0.Class452_0.Count != 0)
				{
					Class454 @class = this.class440_0.Class452_0[0];
					seriesChartType_ = @class.SeriesChartType_0;
					int_ = @class.Class444_0.Count;
				}
				for (int i = 0; i < num; i++)
				{
					Class454 class2 = new Class454();
					class2.SeriesChartType_0 = seriesChartType_;
					ChartDataGridDialog.smethod_0(class2, int_, 0.0);
					this.class440_0.Class452_0.Add(class2);
				}
			}
		}

		private void method_8(int int_0)
		{
			if (this.class440_0.Class452_0.Count == 0)
			{
				return;
			}
			int num = int_0 - this.class440_0.Class452_0[0].Class444_0.Count;
			if (num <= 0)
			{
				return;
			}
			foreach (Class454 item2 in (IEnumerable<Class454>)this.class440_0.Class452_0)
			{
				for (int i = 0; i < num; i++)
				{
					Class446 item = new Class446(0.0);
					item2.Class444_0.Add(item);
				}
			}
		}

		private Control method_9(DialogItem dialogItem_0, Control control_0)
		{
			if (control_0.Name == dialogItem_0.ToString())
			{
				return control_0;
			}
			foreach (Control control2 in control_0.Controls)
			{
				Control control = this.method_9(dialogItem_0, control2);
				if (control != null)
				{
					return control;
				}
			}
			return null;
		}

		private void method_10(TextControl textControl_0)
		{
			int num = textControl_0.Width / 2 - base.Width / 2;
			int num2 = textControl_0.Height / 2 - base.Height / 2;
			base.Location = textControl_0.PointToScreen(new Point(num, num2));
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			this.uint_0 = Class468.smethod_0(null, this);
			Class429.Struct83 struct83_ = default(Class429.Struct83);
			Class429.GetWindowRect(base.Handle, ref struct83_);
			Class468.smethod_1(this.uint_0, struct83_, this);
			base.OnHandleCreated(eventArgs_0);
		}

		protected override void WndProc(ref Message message)
		{
			int msg = message.Msg;
			if (msg == 736)
			{
				uint num = Class429.smethod_5(message.WParam.ToInt32());
				if (num != this.uint_0)
				{
					Class429.Struct83 @struct = (Class429.Struct83)Marshal.PtrToStructure(message.LParam, typeof(Class429.Struct83));
					this.Font = new Font(this.Font.Name, this.Font.Size * (float)num / (float)this.uint_0, this.Font.Style, this.Font.Unit);
					this.uint_0 = num;
					Class429.SetWindowPos(base.Handle, IntPtr.Zero, @struct.int_0, @struct.int_1, @struct.int_2 - @struct.int_0, @struct.int_3 - @struct.int_1, 20u);
				}
			}
			else
			{
				base.WndProc(ref message);
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
			this.icontainer_0 = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
			this.TXITEM_DataGrid = new System.Windows.Forms.DataGridView();
			this.TXITEM_DataGridContextMenu = new System.Windows.Forms.ContextMenuStrip(this.icontainer_0);
			this.TXITEM_CopyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TXITEM_PasteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TXITEM_ToolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.TXITEM_DeleteRowsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TXITEM_DeleteColumnsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)this.TXITEM_DataGrid).BeginInit();
			this.TXITEM_DataGridContextMenu.SuspendLayout();
			base.SuspendLayout();
			this.TXITEM_DataGrid.AllowUserToAddRows = false;
			this.TXITEM_DataGrid.AllowUserToDeleteRows = false;
			this.TXITEM_DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this.TXITEM_DataGrid.ContextMenuStrip = this.TXITEM_DataGridContextMenu;
			this.TXITEM_DataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TXITEM_DataGrid.Location = new System.Drawing.Point(0, 0);
			this.TXITEM_DataGrid.Name = "TXITEM_DataGrid";
			dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.TXITEM_DataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle;
			this.TXITEM_DataGrid.RowHeadersWidth = 70;
			this.TXITEM_DataGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.TXITEM_DataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this.TXITEM_DataGrid.Size = new System.Drawing.Size(601, 219);
			this.TXITEM_DataGrid.TabIndex = 0;
			this.TXITEM_DataGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(TXITEM_DataGrid_KeyDown);
			this.TXITEM_DataGridContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[5] { this.TXITEM_CopyMenuItem, this.TXITEM_PasteMenuItem, this.TXITEM_ToolStripSeparator, this.TXITEM_DeleteRowsMenuItem, this.TXITEM_DeleteColumnsMenuItem });
			this.TXITEM_DataGridContextMenu.Name = "TXITEM_DataGridContextMenu";
			this.TXITEM_DataGridContextMenu.Size = new System.Drawing.Size(159, 98);
			this.TXITEM_DataGridContextMenu.Opening += new System.ComponentModel.CancelEventHandler(TXITEM_DataGridContextMenu_Opening);
			this.TXITEM_CopyMenuItem.Name = "TXITEM_CopyMenuItem";
			this.TXITEM_CopyMenuItem.Size = new System.Drawing.Size(158, 22);
			this.TXITEM_CopyMenuItem.Text = "Copy";
			this.TXITEM_CopyMenuItem.Click += new System.EventHandler(TXITEM_CopyMenuItem_Click);
			this.TXITEM_PasteMenuItem.Name = "TXITEM_PasteMenuItem";
			this.TXITEM_PasteMenuItem.Size = new System.Drawing.Size(158, 22);
			this.TXITEM_PasteMenuItem.Text = "Paste";
			this.TXITEM_PasteMenuItem.Click += new System.EventHandler(TXITEM_PasteMenuItem_Click);
			this.TXITEM_ToolStripSeparator.Name = "TXITEM_ToolStripSeparator";
			this.TXITEM_ToolStripSeparator.Size = new System.Drawing.Size(155, 6);
			this.TXITEM_DeleteRowsMenuItem.Name = "TXITEM_DeleteRowsMenuItem";
			this.TXITEM_DeleteRowsMenuItem.Size = new System.Drawing.Size(158, 22);
			this.TXITEM_DeleteRowsMenuItem.Text = "Delete Rows";
			this.TXITEM_DeleteRowsMenuItem.Click += new System.EventHandler(TXITEM_DeleteRowsMenuItem_Click);
			this.TXITEM_DeleteColumnsMenuItem.Name = "TXITEM_DeleteColumnsMenuItem";
			this.TXITEM_DeleteColumnsMenuItem.Size = new System.Drawing.Size(158, 22);
			this.TXITEM_DeleteColumnsMenuItem.Text = "Delete Columns";
			this.TXITEM_DeleteColumnsMenuItem.Click += new System.EventHandler(TXITEM_DeleteColumnsMenuItem_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(601, 219);
			base.Controls.Add(this.TXITEM_DataGrid);
			base.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(400, 250);
			base.Name = "ChartDataGridDialog";
			this.RightToLeftLayout = true;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Datasheet";
			base.Load += new System.EventHandler(ChartDataGridDialog_Load);
			((System.ComponentModel.ISupportInitialize)this.TXITEM_DataGrid).EndInit();
			this.TXITEM_DataGridContextMenu.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
