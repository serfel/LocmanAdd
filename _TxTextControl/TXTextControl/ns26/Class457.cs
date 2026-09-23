using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;
using TXTextControl;
using TXTextControl.Windows.Forms;

namespace ns26
{
	internal class Class457 : TableLayoutPanel
	{
		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private List<Row> list_0 = new List<Row>();

		private List<FormFieldItem> list_1 = new List<FormFieldItem>();

		private PointF pointF_0 = PointF.Empty;

		private int int_0 = 1;

		private int int_1;

		private static readonly object object_0 = new object();

		[CompilerGenerated]
		private bool bool_0;

		internal bool Boolean_0
		{
			[CompilerGenerated]
			get
			{
				return this.bool_0;
			}
			[CompilerGenerated]
			set
			{
				this.bool_0 = value;
			}
		}

		internal List<FormFieldItem> List_0 => this.list_1;

		internal List<Row> List_1 => this.list_0;

		public int Int32_0
		{
			get
			{
				return this.int_0;
			}
			set
			{
				if (value >= 1 && this.int_0 != (this.int_0 = value) && base.IsHandleCreated)
				{
					this.GetPreferredSize(Size.Empty);
				}
			}
		}

		internal int Int32_1 => this.int_1;

		public event EventHandler AllRowsAreValidChanged
		{
			add
			{
				base.Events.AddHandler(Class457.object_0, value);
			}
			remove
			{
				base.Events.RemoveHandler(Class457.object_0, value);
			}
		}

		public Class457()
		{
			this.AutoSize = true;
			this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.Dock = DockStyle.Top;
			base.ColumnCount = 2;
			base.ColumnStyles.Add(new ColumnStyle());
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, SystemInformation.VerticalScrollBarWidth));
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			base.OnHandleCreated(eventArgs_0);
		}

		internal void method_0(PointF pointF_1)
		{
			this.pointF_0 = pointF_1;
			base.SuspendLayout();
			this.method_6(0);
			foreach (Row item in this.List_1)
			{
				item.AwareOfDpi(pointF_1);
			}
			base.Parent.MinimumSize = new Size(base.PreferredSize.Width, this.Int32_1 + 2);
			base.Parent.MaximumSize = new Size(int.MaxValue, this.Int32_1 + 2);
			base.Parent.Width = base.Parent.MinimumSize.Width;
			this.vmethod_2();
			base.ResumeLayout();
		}

		public override Size GetPreferredSize(Size proposedSize)
		{
			int num = 0;
			int num2 = 0;
			Padding padding = Padding.Empty;
			Padding padding2 = Padding.Empty;
			float num3 = 0f;
			this.int_1 = 0;
			if (this.list_0.Count > 0)
			{
				Row row = this.list_0[0];
				padding = row.Margin;
				padding2 = row.Padding;
				for (int i = 0; i < row.ColumnCount; i++)
				{
					Control controlFromPosition = row.GetControlFromPosition(i, 0);
					if (controlFromPosition != null)
					{
						num = Math.Max(num, controlFromPosition.Height + controlFromPosition.Margin.Vertical);
					}
					controlFromPosition = row.GetControlFromPosition(i, 1);
					if (controlFromPosition != null)
					{
						num2 = Math.Max(num2, ((controlFromPosition.Dock == DockStyle.Top) ? controlFromPosition.Height : controlFromPosition.PreferredSize.Height) + controlFromPosition.Margin.Vertical);
					}
					num3 += ((row.ColumnStyles[i].SizeType == SizeType.Absolute) ? row.ColumnStyles[i].Width : ((float)((row.ColumnStyles[i].SizeType == SizeType.AutoSize) ? (controlFromPosition.PreferredSize.Width + controlFromPosition.Margin.Horizontal) : 0)));
				}
				num3 += (float)Class517.smethod_45(SystemInformation.VerticalScrollBarWidth, this.pointF_0.X);
				this.int_1 = num + this.int_0 * (num2 + padding2.Vertical + padding.Vertical);
			}
			this.int_1 += base.Padding.Vertical + base.Margin.Vertical;
			num3 += (float)(padding2.Horizontal + padding.Horizontal + base.Padding.Horizontal + base.Margin.Horizontal);
			return new Size((int)num3, base.GetPreferredSize(proposedSize).Height);
		}

		internal virtual Row vmethod_0(IConditionalInstructionElement iconditionalInstructionElement_0)
		{
			throw new NotImplementedException();
		}

		protected virtual void vmethod_1(object sender, PropertyChangedEventArgs e)
		{
		}

		protected virtual void vmethod_2()
		{
			this.method_9(null);
		}

		internal virtual void vmethod_3(Row row_0)
		{
		}

		private void method_1(object sender, EventArgs e)
		{
			Row row_ = sender as Row;
			int val = this.method_5(row_);
			this.method_6(Math.Max(0, val));
			this.vmethod_3(row_);
			this.vmethod_2();
		}

		private void method_2(object sender, EventArgs e)
		{
			Row row = sender as Row;
			int i;
			for (i = 0; i < this.list_0.Count; i++)
			{
				Row row2 = this.list_0[i];
				if (row2 == row)
				{
					i++;
					break;
				}
			}
			this.method_4(i, null);
			this.method_6(i);
			this.vmethod_2();
		}

		private void method_3(object sender, PropertyChangedEventArgs e)
		{
			this.vmethod_1(sender, e);
		}

		internal void method_4(int int_2, IConditionalInstructionElement iconditionalInstructionElement_0)
		{
			Row row = this.vmethod_0(iconditionalInstructionElement_0);
			this.list_0.Insert(int_2, row);
			row.AddRow += method_2;
			row.DeleteRow += method_1;
			row.PropertyChanged += method_3;
		}

		private int method_5(Row row_0)
		{
			if (this.list_0.Contains(row_0))
			{
				int result = this.list_0.IndexOf(row_0) - 1;
				this.list_0.Remove(row_0);
				row_0.AddRow -= method_2;
				row_0.DeleteRow -= method_1;
				row_0.PropertyChanged -= method_3;
				return result;
			}
			return -2;
		}

		protected void method_6(int int_2)
		{
			base.SuspendLayout();
			base.Controls.Clear();
			base.RowStyles.Clear();
			base.ColumnStyles.Clear();
			base.RowCount = this.list_0.Count;
			base.ColumnCount = 2;
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			int num = ((this.list_0.Count <= this.int_0) ? Class517.smethod_45(SystemInformation.VerticalScrollBarWidth, this.pointF_0.X) : 0);
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, num));
			if (this.list_0.Count > 0)
			{
				for (int i = 0; i < this.list_0.Count; i++)
				{
					base.RowStyles.Add(new RowStyle(SizeType.AutoSize));
					Row row = this.list_0[i];
					row.IsFirstRow = false;
					base.Controls.Add(row, 0, i);
				}
				(base.GetControlFromPosition(0, 0) as Row).IsFirstRow = true;
				this.method_8();
			}
			base.ResumeLayout(performLayout: true);
			if (base.Parent is Panel && this.list_0.Count > 0)
			{
				(base.Parent as Panel).ScrollControlIntoView(this.list_0[int_2]);
			}
		}

		internal void method_7(Dictionary<int, FormField> dictionary_0, IConditionalInstructionElement[] iconditionalInstructionElement_0)
		{
			string @string = this.resourceManager_0.GetString("LABEL_DefaultFormFieldName");
			foreach (FormField value in dictionary_0.Values)
			{
				this.list_1.Add(new FormFieldItem(value, @string));
			}
			if (iconditionalInstructionElement_0.Length > 0)
			{
				for (int i = 0; i < iconditionalInstructionElement_0.Length; i++)
				{
					this.method_4(i, iconditionalInstructionElement_0[i]);
				}
			}
			else
			{
				this.method_4(0, null);
			}
			if (base.IsHandleCreated)
			{
				this.method_6(0);
				this.vmethod_2();
			}
		}

		private void method_8()
		{
			if (base.RowCount == 1)
			{
				(base.Controls[0] as Row).IsRemoveRowEnabled = false;
				return;
			}
			foreach (Control control in base.Controls)
			{
				if (control is Row)
				{
					(control as Row).IsRemoveRowEnabled = true;
				}
			}
		}

		internal void method_9(Row row_0)
		{
			bool num = row_0?.IsValidRow ?? true;
			bool flag = num;
			if (num)
			{
				foreach (Row control in base.Controls)
				{
					if (!control.IsValidRow)
					{
						flag = false;
						break;
					}
				}
			}
			foreach (Row item in this.list_0)
			{
				item.IsAddNewRowEnabled = flag;
			}
			bool boolean_ = this.Boolean_0;
			bool flag3 = (this.Boolean_0 = flag);
			if (boolean_ != flag3)
			{
				this.method_10();
			}
		}

		protected void method_10()
		{
			((EventHandler)base.Events[Class457.object_0])?.Invoke(this, new EventArgs());
		}
	}
}
