using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using ns21;
using TXTextControl;

namespace ns27
{
	internal class Class590
	{
		private TextControlCore textControlCore_0;

		private int int_0;

		private int int_1 = 1;

		private int int_2 = 1;

		private int int_3;

		private short short_0 = 1;

		private int int_4 = 1;

		private bool bool_0;

		private bool bool_1;

		private bool bool_2;

		private Struct49 struct49_0 = default(Struct49);

		private bool bool_3;

		internal Class590()
		{
		}

		internal Class590(TextControlCore textControlCore_1)
		{
			if (textControlCore_1 == null || !textControlCore_1.isHandleCreated)
			{
				throw new InvalidOperationException();
			}
			this.method_0(textControlCore_1);
		}

		internal void method_0(TextControlCore textControlCore_1)
		{
			this.textControlCore_0 = textControlCore_1;
			this.int_0 = ((textControlCore_1.GetTextControl().GetViewMode() == ViewMode.SimpleControl) ? 1 : textControlCore_1.method_30(Enum83.const_56, 0, 0));
			this.int_3 = this.int_0;
		}

		internal void method_1(string string_0)
		{
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
			{
				PrintDocument printDocument = new PrintDocument();
				printDocument.DocumentName = string_0;
				printDocument.PrintController = new StandardPrintController();
				PrintDialog printDialog = new PrintDialog();
				printDialog.Document = printDocument;
				printDialog.AllowSomePages = true;
				printDialog.PrinterSettings.MinimumPage = 1;
				printDialog.PrinterSettings.MaximumPage = this.int_0;
				printDialog.PrinterSettings.FromPage = 1;
				printDialog.PrinterSettings.ToPage = this.int_0;
				if (IntPtr.Size == 8)
				{
					printDialog.UseEXDialog = true;
				}
				if (printDialog.ShowDialog() == DialogResult.OK)
				{
					this.method_2(printDocument);
				}
				return;
			}
			throw new InvalidOperationException();
		}

		internal void method_2(PrintDocument printDocument_0)
		{
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
			{
				switch (printDocument_0.PrinterSettings.PrintRange)
				{
				case PrintRange.AllPages:
					this.int_2 = 1;
					this.int_3 = this.int_0;
					this.int_1 = 1;
					break;
				case PrintRange.SomePages:
					this.int_2 = printDocument_0.PrinterSettings.FromPage;
					if (this.int_2 > this.int_0)
					{
						throw new ArgumentOutOfRangeException("PrinterSettings.FromPage", this.textControlCore_0.method_1().GetString("ERR_FROMPAGE"));
					}
					this.int_3 = Math.Min(printDocument_0.PrinterSettings.ToPage, this.int_0);
					this.int_1 = this.int_2;
					break;
				}
				printDocument_0.PrintPage += method_5;
				printDocument_0.QueryPageSettings += method_6;
				printDocument_0.BeginPrint += method_7;
				printDocument_0.EndPrint += method_8;
				this.short_0 = printDocument_0.PrinterSettings.Copies;
				this.bool_0 = printDocument_0.PrinterSettings.Collate;
				if (this.bool_0 && this.short_0 > 1 && (1 + this.int_3 - this.int_2) % 2 > 0 && printDocument_0.PrinterSettings.CanDuplex && (printDocument_0.PrinterSettings.Duplex == Duplex.Horizontal || printDocument_0.PrinterSettings.Duplex == Duplex.Vertical))
				{
					this.bool_2 = true;
				}
				printDocument_0.PrinterSettings.Copies = 1;
				printDocument_0.Print();
				printDocument_0.PrinterSettings.Copies = this.short_0;
				return;
			}
			throw new InvalidOperationException();
		}

		internal void method_3(string string_0)
		{
			if (this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated)
			{
				throw new InvalidOperationException();
			}
			PrintDocument printDocument = new PrintDocument();
			printDocument.DocumentName = string_0;
			this.method_4(printDocument);
		}

		internal void method_4(PrintDocument printDocument_0)
		{
			switch (printDocument_0.PrinterSettings.PrintRange)
			{
			case PrintRange.AllPages:
				this.int_2 = 1;
				this.int_3 = this.int_0;
				this.int_1 = 1;
				break;
			case PrintRange.SomePages:
				this.int_2 = printDocument_0.PrinterSettings.FromPage;
				if (this.int_2 > this.int_0)
				{
					throw new ArgumentOutOfRangeException("PrinterSettings.FromPage", this.textControlCore_0.method_1().GetString("ERR_FROMPAGE"));
				}
				this.int_3 = Math.Min(printDocument_0.PrinterSettings.ToPage, this.int_0);
				this.int_1 = this.int_2;
				break;
			}
			printDocument_0.PrintPage += method_5;
			printDocument_0.QueryPageSettings += method_6;
			printDocument_0.BeginPrint += method_7;
			printDocument_0.EndPrint += method_8;
			PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
			printPreviewDialog.AutoScale = true;
			printPreviewDialog.Document = printDocument_0;
			printPreviewDialog.PrintPreviewControl.AutoZoom = false;
			printPreviewDialog.PrintPreviewControl.Zoom = 1.0;
			printPreviewDialog.ShowIcon = false;
			printPreviewDialog.ShowDialog();
			printDocument_0.PrintPage -= method_5;
			printDocument_0.QueryPageSettings -= method_6;
			printDocument_0.BeginPrint -= method_7;
			printDocument_0.EndPrint -= method_8;
		}

		private void method_5(object sender, PrintPageEventArgs e)
		{
			if (this.bool_1)
			{
				this.bool_1 = false;
				e.HasMorePages = true;
				return;
			}
			this.method_9(this.int_1, e);
			if (this.bool_0)
			{
				if (this.int_1 == this.int_3)
				{
					this.int_4++;
				}
				this.int_1 = ((this.int_1 < this.int_3) ? (this.int_1 + 1) : this.int_2);
				e.HasMorePages = this.int_4 <= this.short_0;
				if (this.int_1 == this.int_2 && e.HasMorePages && this.bool_2)
				{
					this.bool_1 = true;
				}
			}
			else
			{
				if (this.int_4 == this.short_0)
				{
					this.int_1++;
				}
				this.int_4 = ((this.int_4 >= this.short_0) ? 1 : (this.int_4 + 1));
				e.HasMorePages = this.int_1 <= this.int_3;
			}
			if (!e.HasMorePages)
			{
				this.int_1 = 1;
				this.int_4 = 1;
			}
		}

		private void method_6(object sender, QueryPageSettingsEventArgs e)
		{
			int num = this.textControlCore_0.method_30(Enum83.const_228, this.int_1, 0);
			e.PageSettings.Landscape = ((((uint)num & 0x40000000u) != 0) ? true : false);
		}

		private void method_7(object sender, PrintEventArgs e)
		{
			this.struct49_0.method_0();
			this.bool_3 = this.textControlCore_0.method_51(Enum83.const_229, 0, ref this.struct49_0) != 0;
		}

		private void method_8(object sender, PrintEventArgs e)
		{
			if (this.bool_3)
			{
				this.textControlCore_0.method_51(Enum83.const_230, 0, ref this.struct49_0);
			}
		}

		internal void method_9(int int_5, PrintPageEventArgs printPageEventArgs_0)
		{
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
			{
				if (this.textControlCore_0.GetTextControl().GetViewMode() == ViewMode.SimpleControl)
				{
					Graphics graphics = printPageEventArgs_0.Graphics;
					IntPtr intPtr = default(IntPtr);
					intPtr = graphics.GetHdc();
					try
					{
						this.textControlCore_0.method_30(Enum83.const_352, (int)intPtr, 0);
					}
					catch (Exception ex)
					{
						throw ex;
					}
					finally
					{
						graphics.ReleaseHdc(intPtr);
					}
					return;
				}
				Struct48 struct48_ = default(Struct48);
				struct48_.method_0();
				struct48_.ushort_1 = (ushort)int_5;
				struct48_.ushort_3 = (ushort)(printPageEventArgs_0.PageSettings.Color ? 2 : 0);
				Graphics graphics2 = printPageEventArgs_0.Graphics;
				IntPtr hdc = graphics2.GetHdc();
				try
				{
					this.textControlCore_0.method_48(Enum83.const_55, (int)hdc, ref struct48_);
				}
				catch (Exception ex2)
				{
					throw ex2;
				}
				finally
				{
					graphics2.ReleaseHdc(hdc);
				}
				return;
			}
			throw new InvalidOperationException();
		}
	}
}
