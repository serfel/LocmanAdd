using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using ns25;
using TXTextControl;

namespace ns27
{
	internal class Class490
	{
		public class EventArgs1 : EventArgs
		{
			[CompilerGenerated]
			private string string_0;

			[CompilerGenerated]
			private int int_0;

			[CompilerGenerated]
			private int int_1;

			public string String_0
			{
				[CompilerGenerated]
				get
				{
					return this.string_0;
				}
				[CompilerGenerated]
				private set
				{
					this.string_0 = value;
				}
			}

			public int Int32_0
			{
				[CompilerGenerated]
				get
				{
					return this.int_0;
				}
				[CompilerGenerated]
				private set
				{
					this.int_0 = value;
				}
			}

			public int Int32_1
			{
				[CompilerGenerated]
				get
				{
					return this.int_1;
				}
				[CompilerGenerated]
				private set
				{
					this.int_1 = value;
				}
			}

			public EventArgs1(int int_2, int int_3, string string_1)
			{
				this.Int32_0 = int_2;
				this.Int32_1 = int_3;
				this.String_0 = string_1;
			}
		}

		public class EventArgs2 : EventArgs
		{
			[CompilerGenerated]
			private string string_0;

			[CompilerGenerated]
			private int int_0;

			public string String_0
			{
				[CompilerGenerated]
				get
				{
					return this.string_0;
				}
				[CompilerGenerated]
				private set
				{
					this.string_0 = value;
				}
			}

			public int Int32_0
			{
				[CompilerGenerated]
				get
				{
					return this.int_0;
				}
				[CompilerGenerated]
				private set
				{
					this.int_0 = value;
				}
			}

			public EventArgs2(int int_1, string string_1)
			{
				this.Int32_0 = int_1;
				this.String_0 = string_1;
			}
		}

		public class EventArgs3 : CancelEventArgs
		{
			public string string_0;

			[CompilerGenerated]
			private string string_1;

			[CompilerGenerated]
			private int int_0;

			public string String_0
			{
				[CompilerGenerated]
				get
				{
					return this.string_1;
				}
				[CompilerGenerated]
				private set
				{
					this.string_1 = value;
				}
			}

			public int Int32_0
			{
				[CompilerGenerated]
				get
				{
					return this.int_0;
				}
				[CompilerGenerated]
				private set
				{
					this.int_0 = value;
				}
			}

			public EventArgs3(int int_1, string string_2)
			{
				this.Int32_0 = int_1;
				this.String_0 = string_2;
				this.string_0 = string.Empty;
			}
		}

		internal class Class491
		{
			private DataGridView dataGridView_0;

			public DataGridViewCell this[int index] => this.dataGridView_0.Rows[0].Cells[index + 1];

			public Class491(DataGridView dataGridView_1)
			{
				this.dataGridView_0 = dataGridView_1;
			}
		}

		internal class Class492
		{
			private DataGridView dataGridView_0;

			public DataGridViewCell this[int index] => this.dataGridView_0.Rows[index + 1].Cells[0];

			public Class492(DataGridView dataGridView_1)
			{
				this.dataGridView_0 = dataGridView_1;
			}
		}

		internal class Class493
		{
			private DataGridView dataGridView_0;

			public DataGridViewCell this[int row, int col] => this.dataGridView_0.Rows[row + 1].Cells[col + 1];

			public Class493(DataGridView dataGridView_1)
			{
				this.dataGridView_0 = dataGridView_1;
			}
		}

		private const int int_0 = 1024;

		private const int int_1 = 128;

		private const string string_0 = "Arial";

		private const float float_0 = 9f;

		private DataGridView dataGridView_0;

		private bool bool_0;

		private Size size_0;

		public static readonly Color color_0 = Color.FromArgb(253, 219, 219);

		public static readonly Color color_1 = Color.FromArgb(223, 219, 249);

		public static readonly Color color_2 = Color.FromArgb(239, 223, 253);

		private EventHandler<EventArgs1> eventHandler_0;

		private EventHandler<EventArgs2> eventHandler_1;

		private EventHandler<EventArgs3> eventHandler_2;

		[CompilerGenerated]
		private TableCell tableCell_0;

		public TableCell TableCell_0
		{
			[CompilerGenerated]
			get
			{
				return this.tableCell_0;
			}
			[CompilerGenerated]
			private set
			{
				this.tableCell_0 = value;
			}
		}

		public Rectangle Rectangle_0
		{
			get
			{
				if (this.dataGridView_0.SelectedCells.Count == 0)
				{
					return default(Rectangle);
				}
				int num = int.MaxValue;
				int num2 = int.MaxValue;
				int num3 = int.MinValue;
				int num4 = int.MinValue;
				foreach (DataGridViewCell selectedCell in this.dataGridView_0.SelectedCells)
				{
					num = Math.Min(num, selectedCell.ColumnIndex);
					num2 = Math.Min(num2, selectedCell.RowIndex);
					num3 = Math.Max(num3, selectedCell.ColumnIndex);
					num4 = Math.Max(num4, selectedCell.RowIndex);
				}
				return new Rectangle(num, num2, num3 - num + 1, num4 - num2 + 1);
			}
		}

		public Class491 Class491_0 => new Class491(this.dataGridView_0);

		public Class492 Class492_0 => new Class492(this.dataGridView_0);

		public Class493 Class493_0 => new Class493(this.dataGridView_0);

		public event EventHandler<EventArgs1> ValueChanged
		{
			add
			{
				EventHandler<EventArgs1> eventHandler = this.eventHandler_0;
				EventHandler<EventArgs1> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<EventArgs1> value2 = (EventHandler<EventArgs1>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler<EventArgs1> eventHandler = this.eventHandler_0;
				EventHandler<EventArgs1> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<EventArgs1> value2 = (EventHandler<EventArgs1>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler<EventArgs2> AxisLabelChanged
		{
			add
			{
				EventHandler<EventArgs2> eventHandler = this.eventHandler_1;
				EventHandler<EventArgs2> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<EventArgs2> value2 = (EventHandler<EventArgs2>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_1, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler<EventArgs2> eventHandler = this.eventHandler_1;
				EventHandler<EventArgs2> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<EventArgs2> value2 = (EventHandler<EventArgs2>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_1, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler<EventArgs3> SeriesNameChanged
		{
			add
			{
				EventHandler<EventArgs3> eventHandler = this.eventHandler_2;
				EventHandler<EventArgs3> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<EventArgs3> value2 = (EventHandler<EventArgs3>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_2, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler<EventArgs3> eventHandler = this.eventHandler_2;
				EventHandler<EventArgs3> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<EventArgs3> value2 = (EventHandler<EventArgs3>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_2, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public Class490(DataGridView dataGridView_1)
		{
			this.dataGridView_0 = dataGridView_1;
			this.dataGridView_0.CellValueChanged += dataGridView_0_CellValueChanged;
			this.method_5();
		}

		private void dataGridView_0_CellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (!this.bool_0)
			{
				if (e.ColumnIndex == 0 && e.RowIndex >= 1)
				{
					this.method_3(e);
				}
				else if (e.RowIndex == 0 && e.ColumnIndex >= 1)
				{
					this.method_2(e);
				}
				else if (e.ColumnIndex >= 1 && e.RowIndex >= 1)
				{
					this.method_0(e);
				}
			}
		}

		protected virtual void vmethod_0(int int_2, int int_3, string string_1)
		{
			if (this.eventHandler_0 != null)
			{
				EventArgs1 e = new EventArgs1(int_2, int_3, string_1);
				this.eventHandler_0(this, e);
			}
		}

		protected virtual void vmethod_1(int int_2, string string_1)
		{
			if (this.eventHandler_1 != null)
			{
				EventArgs2 e = new EventArgs2(int_2, string_1);
				this.eventHandler_1(this, e);
			}
		}

		protected virtual void vmethod_2(EventArgs3 eventArgs3_0)
		{
			if (this.eventHandler_2 != null)
			{
				this.eventHandler_2(this, eventArgs3_0);
			}
		}

		private void method_0(DataGridViewCellEventArgs dataGridViewCellEventArgs_0)
		{
			string string_ = this.method_1(dataGridViewCellEventArgs_0.RowIndex, dataGridViewCellEventArgs_0.ColumnIndex);
			this.vmethod_0(dataGridViewCellEventArgs_0.RowIndex - 1, dataGridViewCellEventArgs_0.ColumnIndex - 1, string_);
		}

		private string method_1(int int_2, int int_3)
		{
			object value = this.dataGridView_0.Rows[int_2].Cells[int_3].Value;
			return (value != null) ? value.ToString() : string.Empty;
		}

		private void method_2(DataGridViewCellEventArgs dataGridViewCellEventArgs_0)
		{
			object value = this.dataGridView_0.Rows[0].Cells[dataGridViewCellEventArgs_0.ColumnIndex].Value;
			string string_ = ((value != null) ? value.ToString() : string.Empty);
			this.vmethod_1(dataGridViewCellEventArgs_0.ColumnIndex - 1, string_);
		}

		private void method_3(DataGridViewCellEventArgs dataGridViewCellEventArgs_0)
		{
			DataGridViewCell dataGridViewCell = this.dataGridView_0.Rows[dataGridViewCellEventArgs_0.RowIndex].Cells[0];
			object value = dataGridViewCell.Value;
			string string_ = ((value != null) ? value.ToString() : string.Empty);
			EventArgs3 eventArgs = new EventArgs3(dataGridViewCellEventArgs_0.RowIndex - 1, string_);
			this.vmethod_2(eventArgs);
			if (eventArgs.Cancel)
			{
				dataGridViewCell.Value = eventArgs.string_0;
			}
		}

		private void method_4(string[] string_1)
		{
			this.bool_0 = true;
			for (int i = 1; i < this.size_0.Height + 1; i++)
			{
				this.dataGridView_0.Rows[i].Cells[0].Value = string_1[i - 1];
			}
			this.bool_0 = false;
		}

		private void method_5()
		{
			Font font = new Font("Arial", 9f, FontStyle.Bold);
			this.bool_0 = true;
			this.dataGridView_0.Columns.Add(new DataGridViewTextBoxColumn
			{
				SortMode = DataGridViewColumnSortMode.NotSortable
			});
			for (int i = 1; i < 128; i++)
			{
				DataGridViewTextBoxColumn dataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
				dataGridViewTextBoxColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
				DataGridViewTextBoxColumn dataGridViewTextBoxColumn2 = dataGridViewTextBoxColumn;
				dataGridViewTextBoxColumn2.HeaderText = Class490.smethod_0(i);
				dataGridViewTextBoxColumn2.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
				dataGridViewTextBoxColumn2.HeaderCell.Style.Font = font;
				this.dataGridView_0.Columns.Add(dataGridViewTextBoxColumn2);
			}
			this.dataGridView_0.Rows.Add(1025);
			foreach (DataGridViewCell cell in this.dataGridView_0.Rows[0].Cells)
			{
				cell.Style.Font = font;
			}
			for (int j = 1; j <= 1024; j++)
			{
				this.dataGridView_0.Rows[j].HeaderCell.Style.Font = font;
				this.dataGridView_0.Rows[j].HeaderCell.Value = j.ToString();
				this.dataGridView_0.Rows[j].Cells[0].Style.Font = font;
			}
			this.dataGridView_0.Rows[0].Cells[0].ReadOnly = true;
			this.dataGridView_0.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.bool_0 = false;
		}

		private static string smethod_0(int int_2)
		{
			string text = string.Empty;
			int num = int_2;
			do
			{
				int num2 = (num - 1) % 26;
				text = Class490.smethod_1(num2) + text;
				num = (num - num2) / 26;
			}
			while (num > 0);
			return text;
		}

		private static char smethod_1(int int_2)
		{
			return (char)(65 + int_2);
		}

		private void method_6()
		{
			this.method_8(Color.White, Color.White, Color.White);
		}

		private void method_7(int int_2, int int_3)
		{
			this.method_6();
			this.method_8(Class490.color_0, Class490.color_1, Class490.color_2);
		}

		private void method_8(Color color_3, Color color_4, Color color_5)
		{
			for (int i = 1; i < this.size_0.Width + 1; i++)
			{
				this.dataGridView_0.Rows[0].Cells[i].Style.BackColor = color_3;
			}
			for (int j = 1; j < this.size_0.Height + 1; j++)
			{
				DataGridViewRow dataGridViewRow = this.dataGridView_0.Rows[j];
				dataGridViewRow.Cells[0].Style.BackColor = color_4;
				for (int k = 1; k < this.size_0.Width + 1; k++)
				{
					dataGridViewRow.Cells[k].Style.BackColor = color_5;
				}
			}
		}

		internal void method_9(Class440 class440_0)
		{
			this.bool_0 = true;
			int num = 0;
			int num2 = 0;
			foreach (Class446 item in (IEnumerable<Class446>)class440_0.Class452_0[0].Class444_0)
			{
				DataGridViewCell dataGridViewCell = this.Class491_0[num2++];
				dataGridViewCell.Value = item.String_0;
				dataGridViewCell.Style.BackColor = Class490.color_0;
			}
			foreach (Class454 item2 in (IEnumerable<Class454>)class440_0.Class452_0)
			{
				num2 = 0;
				DataGridViewCell dataGridViewCell2 = this.Class492_0[num];
				dataGridViewCell2.Value = item2.String_0;
				dataGridViewCell2.Style.BackColor = Class490.color_1;
				foreach (Class446 item3 in (IEnumerable<Class446>)item2.Class444_0)
				{
					DataGridViewCell dataGridViewCell3 = this.Class493_0[num, num2++];
					dataGridViewCell3.Value = item3.Double_0.ToString();
					dataGridViewCell3.Style.BackColor = Class490.color_2;
				}
				num++;
			}
			for (int i = num2 + 1; i <= this.size_0.Width; i++)
			{
				for (int j = 0; j <= this.size_0.Height; j++)
				{
					DataGridViewCell dataGridViewCell4 = this.dataGridView_0.Rows[j].Cells[i];
					dataGridViewCell4.Value = "";
					dataGridViewCell4.Style.BackColor = Color.White;
				}
			}
			for (int k = num + 1; k <= this.size_0.Height; k++)
			{
				for (int l = 0; l <= this.size_0.Width; l++)
				{
					DataGridViewCell dataGridViewCell5 = this.dataGridView_0.Rows[k].Cells[l];
					dataGridViewCell5.Value = "";
					dataGridViewCell5.Style.BackColor = Color.White;
				}
			}
			this.size_0.Width = num2;
			this.size_0.Height = num;
			this.bool_0 = false;
		}
	}
}
