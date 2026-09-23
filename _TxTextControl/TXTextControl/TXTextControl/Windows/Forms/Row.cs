using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using ns21;
using ns26;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms
{
	internal abstract class Row : TableLayoutPanel, INotifyPropertyChanged
	{
		protected ResourceManager m_rm = new ResourceManager(typeof(TextControlCore));

		internal Class457 m_gvParent;

		private FormFieldItem m_ffCurrentFormField;

		protected PointF m_pntDpi = PointF.Empty;

		protected bool m_bIsFirstRow = true;

		protected System.Windows.Forms.Button m_btnAddNewRow;

		protected System.Windows.Forms.Button m_btnRemoveRow;

		protected bool m_bIsValidRow;

		private static readonly object EventAddRow = new object();

		private static readonly object EventDeleteRow = new object();

		internal FormFieldItem CurrentFormField
		{
			get
			{
				return this.m_ffCurrentFormField;
			}
			set
			{
				this.m_ffCurrentFormField = value;
			}
		}

		internal virtual bool IsFirstRow { get; set; }

		internal bool IsAddNewRowEnabled
		{
			get
			{
				return this.m_btnAddNewRow.Enabled;
			}
			set
			{
				this.m_btnAddNewRow.Enabled = value;
			}
		}

		internal bool IsRemoveRowEnabled
		{
			get
			{
				return this.m_btnRemoveRow.Enabled;
			}
			set
			{
				this.m_btnRemoveRow.Enabled = value;
			}
		}

		internal bool IsValidRow => this.m_bIsValidRow;

		public event PropertyChangedEventHandler PropertyChanged;

		public event EventHandler AddRow
		{
			add
			{
				base.Events.AddHandler(Row.EventAddRow, value);
			}
			remove
			{
				base.Events.RemoveHandler(Row.EventAddRow, value);
			}
		}

		public event EventHandler DeleteRow
		{
			add
			{
				base.Events.AddHandler(Row.EventDeleteRow, value);
			}
			remove
			{
				base.Events.RemoveHandler(Row.EventDeleteRow, value);
			}
		}

		internal Row(Class457 gridView)
		{
			this.m_gvParent = gridView;
			this.AutoSize = true;
			this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.Dock = DockStyle.Top;
			this.InitializeComponents();
			this.m_btnAddNewRow.Click += AddNewRow_Click;
			this.m_btnRemoveRow.Click += RemoveRow_Click;
		}

		private void AddNewRow_Click(object sender, EventArgs e)
		{
			this.OnAddNewRowButtonClick();
		}

		private void RemoveRow_Click(object sender, EventArgs e)
		{
			this.OnRemoveRowButtonClick();
		}

		protected virtual void InitializeComponents()
		{
		}

		internal virtual void AwareOfDpi(PointF newDpi)
		{
			if (this.m_pntDpi.X != newDpi.X || this.m_pntDpi.Y != newDpi.Y)
			{
				this.m_pntDpi = newDpi;
				base.Margin = Class517.smethod_51(new Padding(3), this.m_pntDpi);
			}
		}

		protected void UpdateFormFieldNames(ComboBox comboBox, float columnWidth)
		{
			foreach (FormFieldItem item in comboBox.Items)
			{
				int num = TextRenderer.MeasureText(item.String_0, comboBox.Font, default(Size), TextFormatFlags.NoPrefix).Width;
				if ((float)num > columnWidth)
				{
					string text = item.String_0;
					while (!this.Truncate(text, comboBox.Font, columnWidth))
					{
						text = text.Substring(0, text.Length - 1);
					}
					item.String_0 = text + "...";
				}
			}
		}

		private bool Truncate(string value, Font font, float maxWidth)
		{
			int num = TextRenderer.MeasureText(value + "...", font, default(Size), TextFormatFlags.NoPrefix).Width;
			return (float)num <= maxWidth;
		}

		protected float GetMaxWidth(int minWidth, int marginsHorizontal, object columnHeader, Font font, params string[] itemIds)
		{
			Control control = columnHeader as Control;
			float num = ((columnHeader != null) ? ((control != null) ? (TextRenderer.MeasureText(control.Text, font, default(Size), TextFormatFlags.NoPrefix).Width + control.Margin.Horizontal) : TextRenderer.MeasureText(columnHeader.ToString(), font, default(Size), TextFormatFlags.NoPrefix).Width) : 0);
			foreach (string name in itemIds)
			{
				num = Math.Max(num, TextRenderer.MeasureText(this.m_rm.GetString(name), font, default(Size), TextFormatFlags.NoPrefix).Width);
			}
			float num2 = (float)(SystemInformation.VerticalScrollBarWidth + marginsHorizontal) + 4f * this.m_pntDpi.X / 96f;
			return Math.Max(minWidth, num) + num2;
		}

		internal static float GetPreferredComboBoxColumnWidth(ComboBox comboBox, object columnHeader, PointF dpi, int? maxWidth)
		{
			Control control = columnHeader as Control;
			float val = ((columnHeader != null) ? ((control != null) ? (TextRenderer.MeasureText(control.Text, comboBox.Font, default(Size), TextFormatFlags.NoPrefix).Width + control.Margin.Horizontal) : ((int)columnHeader)) : 0);
			foreach (object item in comboBox.Items)
			{
				val = Math.Max(val, TextRenderer.MeasureText(item.ToString(), comboBox.Font, default(Size), TextFormatFlags.NoPrefix).Width);
			}
			float num = (float)(SystemInformation.VerticalScrollBarWidth + comboBox.Margin.Horizontal) + 4f * dpi.X / 96f;
			return num + Math.Min(val, maxWidth.HasValue ? ((int)((float)maxWidth.Value * dpi.X / 96f)) : int.MaxValue);
		}

		internal void OnPropertyChanged(string name)
		{
			this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		protected void OnAddNewRowButtonClick()
		{
			((EventHandler)base.Events[Row.EventAddRow])?.Invoke(this, new EventArgs());
		}

		internal void OnRemoveRowButtonClick()
		{
			((EventHandler)base.Events[Row.EventDeleteRow])?.Invoke(this, new EventArgs());
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			base.OnHandleCreated(eventArgs_0);
			Graphics graphics = base.CreateGraphics();
			uint dpiForWindow = Class429.GetDpiForWindow(base.Handle);
			dpiForWindow = ((dpiForWindow != 0) ? dpiForWindow : ((uint)graphics.DpiX));
			graphics.Dispose();
			this.AwareOfDpi(new PointF(dpiForWindow, dpiForWindow));
		}
	}
}
