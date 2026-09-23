using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using TXTextControl;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class487
	{
		internal class Class488
		{
			private Class489[] class489_0 = new Class489[0];

			private int int_0 = -1;

			internal bool method_0(Class489 class489_1)
			{
				if (this.int_0 >= 0)
				{
					Class489 @class = this.class489_0[this.int_0];
					if (@class.String_0 == class489_1.String_0)
					{
						return false;
					}
				}
				this.method_3(++this.int_0, class489_1);
				return true;
			}

			internal Class489 method_1()
			{
				this.int_0++;
				Class489 result = null;
				if (this.int_0 >= this.class489_0.Length || (result = this.class489_0[this.int_0]) == null)
				{
					this.int_0--;
				}
				return result;
			}

			internal Class489 method_2()
			{
				if (this.int_0 > 0)
				{
					this.int_0--;
					return this.class489_0[this.int_0];
				}
				this.int_0 = 0;
				return null;
			}

			private void method_3(int int_1, Class489 class489_1)
			{
				if (int_1 >= this.class489_0.Length)
				{
					Class489[] array = new Class489[this.class489_0.Length + 1];
					for (int i = 0; i < this.class489_0.Length; i++)
					{
						array[i] = this.class489_0[i];
					}
					this.class489_0 = array;
				}
				else
				{
					for (int j = int_1; j < this.class489_0.Length; j++)
					{
						this.class489_0[j] = null;
					}
				}
				this.class489_0[int_1] = class489_1;
			}
		}

		internal class Class489
		{
			private string string_0;

			private int int_0;

			internal string String_0 => this.string_0;

			internal int Int32_0 => this.int_0;

			internal Class489(string string_1, int int_1)
			{
				this.string_0 = string_1;
				this.int_0 = int_1;
			}
		}

		private RibbonTextBox ribbonTextBox_0;

		private RibbonToggleButton ribbonToggleButton_0;

		private Class475 class475_0;

		private TextControl textControl_0;

		private Table table_0;

		private int int_0;

		private int int_1;

		private TableCell tableCell_0;

		private string string_0;

		private int int_2 = -1;

		private int int_3 = -1;

		private int[] int_4;

		private int[] int_5;

		private int int_6 = -1;

		private int int_7 = -1;

		private int int_8;

		private bool bool_0;

		private bool bool_1;

		private bool bool_2;

		private MiniToolbarButton miniToolbarButton_0 = MiniToolbarButton.None;

		private RulerBarFormulaMode rulerBarFormulaMode_0;

		private RulerBarFormulaMode rulerBarFormulaMode_1;

		private Class488 class488_0;

		[CompilerGenerated]
		private bool bool_3;

		internal bool Boolean_0
		{
			[CompilerGenerated]
			get
			{
				return this.bool_3;
			}
			[CompilerGenerated]
			set
			{
				this.bool_3 = value;
			}
		}

		internal string String_0 => this.tableCell_0.Formula;

		internal Class487(RibbonTextBox ribbonTextBox_1, RibbonToggleButton ribbonToggleButton_1, Class475 class475_1)
		{
			this.ribbonTextBox_0 = ribbonTextBox_1;
			this.ribbonToggleButton_0 = ribbonToggleButton_1;
			this.class475_0 = class475_1;
		}

		internal void method_0(TextControl textControl_1, Table table_1, TableCell tableCell_1)
		{
			this.class488_0 = new Class488();
			this.Boolean_0 = true;
			this.textControl_0 = textControl_1;
			this.int_8 = textControl_1.InputPosition.TextPosition;
			this.table_0 = table_1;
			this.tableCell_0 = tableCell_1;
			this.int_0 = tableCell_1.Row;
			this.int_1 = tableCell_1.Column;
			this.string_0 = this.ribbonTextBox_0.Text;
			this.int_2 = (this.int_3 = this.ribbonTextBox_0.SelectionStart);
			this.ribbonTextBox_0.LostFocus += ribbonTextBox_0_LostFocus;
			this.ribbonTextBox_0.KeyDown += ribbonTextBox_0_KeyDown;
			this.class488_0.method_0(new Class489(this.ribbonTextBox_0.Text, this.ribbonTextBox_0.SelectionStart));
			this.textControl_0.InputPositionChanged += textControl_0_InputPositionChanged;
			this.textControl_0.MouseDown += textControl_0_MouseDown;
			this.textControl_0.MouseUp += textControl_0_MouseUp;
			this.textControl_0.Changed += textControl_0_Changed;
			this.bool_0 = this.textControl_0.AllowDrag;
			this.bool_1 = this.textControl_0.AllowDrop;
			this.bool_2 = this.textControl_0.HideSelection;
			this.miniToolbarButton_0 = this.textControl_0.ShowMiniToolbar;
			if (this.textControl_0.RulerBar != null)
			{
				this.rulerBarFormulaMode_0 = this.textControl_0.RulerBar.FormulaMode;
			}
			if (this.textControl_0.VerticalRulerBar != null)
			{
				this.rulerBarFormulaMode_1 = this.textControl_0.VerticalRulerBar.FormulaMode;
			}
			this.textControl_0.AllowDrag = false;
			this.textControl_0.AllowDrop = false;
			this.textControl_0.HideSelection = false;
			this.textControl_0.ShowMiniToolbar = MiniToolbarButton.None;
			if (this.textControl_0.RulerBar != null)
			{
				this.textControl_0.RulerBar.FormulaMode = RulerBarFormulaMode.Fixed;
			}
			if (this.textControl_0.VerticalRulerBar != null)
			{
				this.textControl_0.VerticalRulerBar.FormulaMode = RulerBarFormulaMode.Fixed;
			}
			this.class475_0.method_24(bool_1: false);
			this.textControl_0.Cursor = this.textControl_0.cursor_4;
		}

		internal void method_1()
		{
			this.textControl_0.InputPositionChanged -= textControl_0_InputPositionChanged;
			this.textControl_0.MouseDown -= textControl_0_MouseDown;
			this.textControl_0.MouseUp -= textControl_0_MouseUp;
			this.textControl_0.Changed -= textControl_0_Changed;
			this.textControl_0.AllowDrag = this.bool_0;
			this.textControl_0.AllowDrop = this.bool_1;
			this.textControl_0.HideSelection = this.bool_2;
			this.textControl_0.ShowMiniToolbar = this.miniToolbarButton_0;
			if (this.textControl_0.RulerBar != null)
			{
				this.textControl_0.RulerBar.FormulaMode = this.rulerBarFormulaMode_0;
			}
			if (this.textControl_0.VerticalRulerBar != null)
			{
				this.textControl_0.VerticalRulerBar.FormulaMode = this.rulerBarFormulaMode_1;
			}
			this.textControl_0.InputPosition = new InputPosition(this.int_8);
			this.textControl_0.Selection.Length = 0;
			this.ribbonTextBox_0.method_7();
			this.ribbonTextBox_0.SelectionLength = 0;
			this.ribbonTextBox_0.LostFocus -= ribbonTextBox_0_LostFocus;
			this.ribbonTextBox_0.KeyDown -= ribbonTextBox_0_KeyDown;
			this.ribbonToggleButton_0.Checked = false;
			this.Boolean_0 = false;
			this.class475_0.method_24(bool_1: false);
			this.textControl_0.ResetCursor();
		}

		private void ribbonTextBox_0_LostFocus(object sender, EventArgs e)
		{
			this.string_0 = this.ribbonTextBox_0.Text;
			this.int_2 = this.ribbonTextBox_0.SelectionStart;
			this.class488_0.method_0(new Class489(this.string_0, this.int_2));
		}

		private void ribbonTextBox_0_KeyDown(object sender, KeyEventArgs e)
		{
			if ((e.KeyCode == Keys.Z || e.KeyCode == Keys.Y) && e.Control)
			{
				this.ribbonTextBox_0.method_6();
				Class489 @class = null;
				if (this.ribbonTextBox_0.Text != this.string_0)
				{
					this.class488_0.method_0(new Class489(this.ribbonTextBox_0.Text, this.ribbonTextBox_0.SelectionStart));
				}
				switch (e.KeyCode)
				{
				default:
					return;
				case Keys.Y:
					@class = this.class488_0.method_1();
					break;
				case Keys.Z:
					@class = this.class488_0.method_2();
					break;
				}
				if (@class != null)
				{
					this.ribbonTextBox_0.Text = @class.String_0;
					this.ribbonTextBox_0.SelectionStart = @class.Int32_0;
				}
			}
		}

		private void textControl_0_InputPositionChanged(object sender, EventArgs e)
		{
			string text = this.method_2();
			this.ribbonTextBox_0.Text = this.string_0.Substring(0, this.int_2) + text + this.string_0.Substring(this.int_2, this.string_0.Length - this.int_2);
			this.ribbonTextBox_0.SelectionStart = this.int_2 + text.Length;
		}

		private void textControl_0_MouseDown(object sender, MouseEventArgs e)
		{
			Table item = this.textControl_0.Tables.GetItem();
			if (item == null || item.Cells.GetItem(1, 1).Start != this.table_0.Cells.GetItem(1, 1).Start)
			{
				this.method_1();
			}
		}

		private void textControl_0_Changed(object sender, EventArgs e)
		{
			this.method_1();
		}

		private void textControl_0_MouseUp(object sender, MouseEventArgs e)
		{
			this.string_0 = this.ribbonTextBox_0.Text;
			this.int_2 = this.ribbonTextBox_0.SelectionStart;
			this.ribbonTextBox_0.method_7();
			this.class488_0.method_0(new Class489(this.string_0, this.int_2));
		}

		private string method_2()
		{
			int num = this.textControl_0.Selection.Start + 1;
			if (this.int_6 != num)
			{
				this.int_6 = num;
				this.int_4 = this.method_3(num);
			}
			if (this.textControl_0.Selection.Length == 0)
			{
				this.int_7 = this.int_6;
				this.int_5 = this.int_4;
			}
			else
			{
				int num2 = num + this.textControl_0.Selection.Length - 1;
				if (this.int_7 != num2)
				{
					this.int_7 = num2;
					this.int_5 = this.method_3(num2);
				}
			}
			if (this.int_4 != null && this.int_5 != null)
			{
				if (this.int_4[0] == this.int_5[0] && this.int_4[1] == this.int_5[1])
				{
					return this.method_7(this.int_4[0], this.int_4[1]);
				}
				return this.method_6(this.int_4[0], this.int_4[1], this.int_5[0], this.int_5[1]);
			}
			return string.Empty;
		}

		private int[] method_3(int int_9)
		{
			int num = 0;
			int count = this.table_0.Rows.Count;
			if (count > 0)
			{
				int num2 = count;
				bool bool_ = false;
				int num3 = (num2 - num) / 2 + 1;
				int[] array;
				for (array = this.method_4(int_9, num3, this.table_0.Columns.Count, out bool_); array == null; array = this.method_4(int_9, num3, this.table_0.Columns.Count, out bool_))
				{
					if (bool_)
					{
						num2 = num3 - 1;
						if (num2 == 0)
						{
							break;
						}
						num3 = (num2 - num) / 2 + 1;
					}
					else
					{
						num = num3;
						num3 = (num2 - num) / 2 + num + 1;
						if (num3 > count)
						{
							break;
						}
					}
				}
				if (array != null)
				{
					return array;
				}
			}
			return null;
		}

		private int[] method_4(int int_9, int int_10, int int_11, out bool bool_4)
		{
			TableCell item = this.table_0.Cells.GetItem(int_10, 1);
			TableCell item2 = this.table_0.Cells.GetItem(int_10, int_11);
			int num = item2.Start + item2.Length;
			bool_4 = false;
			if (item.Start <= int_9 && int_9 <= num)
			{
				TableCell tableCell = ((int_11 == 1) ? item : null);
				for (int i = 1; i < int_11; i++)
				{
					item = this.table_0.Cells.GetItem(int_10, i);
					tableCell = this.table_0.Cells.GetItem(int_10, i + 1);
					if (item.Start <= int_9 && int_9 < tableCell.Start)
					{
						return new int[2]
						{
							int_10 - this.int_0,
							i - this.int_1
						};
					}
				}
				if (tableCell.Start <= int_9 && int_9 <= num)
				{
					return new int[2]
					{
						int_10 - this.int_0,
						int_11 - this.int_1
					};
				}
			}
			bool_4 = int_9 < item.Start;
			return null;
		}

		private string method_5(int int_9)
		{
			int_9--;
			string text = "";
			do
			{
				text += (char)(65 + int_9 % 26);
				int_9 /= 26;
				int_9--;
			}
			while (int_9 > 0);
			return text;
		}

		private string method_6(int int_9, int int_10, int int_11, int int_12)
		{
			return this.method_7(int_9, int_10) + ":" + this.method_7(int_11, int_12);
		}

		private string method_7(int int_9, int int_10)
		{
			if (this.textControl_0.FormulaReferenceStyle == FormulaReferenceStyle.A1)
			{
				return this.method_5(this.int_1 + int_10) + (this.int_0 + int_9);
			}
			return "R[" + int_9 + "]C[" + int_10 + "]";
		}
	}
}
