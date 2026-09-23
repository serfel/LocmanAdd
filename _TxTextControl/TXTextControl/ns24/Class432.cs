using System;
using System.Drawing;
using System.Drawing.Printing;
using ns21;
using TXTextControl;

namespace ns24
{
	internal class Class432
	{
		private TextControlCore textControlCore_0;

		private int int_0;

		private int int_1 = 1;

		private int int_2 = 1;

		private int int_3;

		private short short_0 = 1;

		private int int_4 = 1;

		private bool bool_0;

		private Struct49 struct49_0 = default(Struct49);

		private bool bool_1;

		internal Class432(TextControlCore textControlCore_1)
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

		internal void method_1(PrintDocument printDocument_0)
		{
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
			{
				printDocument_0.PrintPage += method_2;
				printDocument_0.QueryPageSettings += method_3;
				printDocument_0.BeginPrint += method_4;
				printDocument_0.EndPrint += method_5;
				switch (printDocument_0.PrinterSettings.PrintRange)
				{
				case PrintRange.AllPages:
					this.int_2 = 1;
					this.int_3 = this.int_0;
					this.int_1 = 1;
					break;
				case PrintRange.SomePages:
					this.int_2 = printDocument_0.PrinterSettings.FromPage;
					this.int_3 = printDocument_0.PrinterSettings.ToPage;
					this.int_1 = printDocument_0.PrinterSettings.FromPage;
					break;
				}
				this.short_0 = printDocument_0.PrinterSettings.Copies;
				this.bool_0 = printDocument_0.PrinterSettings.Collate;
				printDocument_0.PrinterSettings.Copies = 1;
				printDocument_0.Print();
				printDocument_0.PrinterSettings.Copies = this.short_0;
				return;
			}
			throw new InvalidOperationException();
		}

		private void method_2(object sender, PrintPageEventArgs e)
		{
			this.method_6(this.int_1, e);
			if (this.bool_0)
			{
				if (this.int_1 == this.int_3)
				{
					this.int_4++;
				}
				this.int_1 = ((this.int_1 < this.int_3) ? (this.int_1 + 1) : this.int_2);
				e.HasMorePages = this.int_4 <= this.short_0;
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

		private void method_3(object sender, QueryPageSettingsEventArgs e)
		{
			int num = this.textControlCore_0.method_30(Enum83.const_228, this.int_1, 0);
			e.PageSettings.Landscape = ((((uint)num & 0x40000000u) != 0) ? true : false);
		}

		private void method_4(object sender, PrintEventArgs e)
		{
			this.struct49_0.method_0();
			this.bool_1 = this.textControlCore_0.method_51(Enum83.const_229, 0, ref this.struct49_0) != 0;
		}

		private void method_5(object sender, PrintEventArgs e)
		{
			if (this.bool_1)
			{
				this.textControlCore_0.method_51(Enum83.const_230, 0, ref this.struct49_0);
			}
		}

		internal void method_6(int int_5, PrintPageEventArgs printPageEventArgs_0)
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
