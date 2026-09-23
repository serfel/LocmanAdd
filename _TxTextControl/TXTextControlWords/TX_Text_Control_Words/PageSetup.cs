using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using TX_Text_Control_Words.FileHandling;
using TX_Text_Control_Words.Utils;
using TXTextControl;

namespace TX_Text_Control_Words
{
	internal static class PageSetup
	{
		internal static void ShowDialog(TextControl tc, FileHandler fh)
		{
			if (tc.GetVersionInfo().Level == VersionInfo.ProductLevel.Standard)
			{
				PageSetup.ShowWindowsPageSetupDialog(tc, fh);
			}
			else
			{
				PageSetup.ShowTXPageSetupDialog(tc, fh);
			}
		}

		private static void ShowTXPageSetupDialog(TextControl tc, FileHandler fh)
		{
			try
			{
				if (tc.SectionFormatDialog(0) == System.Windows.Forms.DialogResult.OK)
				{
					fh.IsDocumentDirty = true;
				}
			}
			catch (Exception ex)
			{
				TX_Text_Control_Words.Utils.MessageBox.Show(tc, ex.Message, AssemblyAttributes.AssemblyProduct);
			}
		}

		private static void ShowWindowsPageSetupDialog(TextControl tc, FileHandler fh)
		{
			PageSetupDialog pageSetupDialog = new PageSetupDialog();
			pageSetupDialog.Document = new PrintDocument();
			tc.PageUnit = MeasuringUnit.CentiInch;
			pageSetupDialog.EnableMetric = true;
			pageSetupDialog.PageSettings.PaperSize = PageSetup.GetTxPaperSize(tc.Selection.SectionFormat.PageSize, tc.Selection.SectionFormat.Landscape);
			Margins margins = pageSetupDialog.PageSettings.Margins;
			PageMargins pageMargins = tc.Selection.SectionFormat.PageMargins;
			margins.Top = (int)pageMargins.Top;
			margins.Right = (int)pageMargins.Right;
			margins.Bottom = (int)pageMargins.Bottom;
			margins.Left = (int)pageMargins.Left;
			pageSetupDialog.PageSettings.Landscape = tc.Selection.SectionFormat.Landscape;
			if (pageSetupDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				margins = pageSetupDialog.PageSettings.Margins;
				pageMargins.Top = margins.Top;
				pageMargins.Right = margins.Right;
				pageMargins.Bottom = margins.Bottom;
				pageMargins.Left = margins.Left;
				tc.Selection.SectionFormat.Landscape = false;
				tc.Selection.SectionFormat.PageSize.Height = pageSetupDialog.PageSettings.PaperSize.Height;
				tc.Selection.SectionFormat.PageSize.Width = pageSetupDialog.PageSettings.PaperSize.Width;
				tc.Selection.SectionFormat.Landscape = pageSetupDialog.PageSettings.Landscape;
				fh.IsDocumentDirty = true;
			}
		}

		private static System.Drawing.Printing.PaperSize GetTxPaperSize(PageSize pgSize, bool bLandscape)
		{
			PrintDocument printDocument = new PrintDocument();
			if (bLandscape)
			{
				pgSize = new PageSize(pgSize.Height, pgSize.Width);
			}
			foreach (System.Drawing.Printing.PaperSize paperSize in printDocument.PrinterSettings.PaperSizes)
			{
				if (Math.Abs((double)paperSize.Height - Math.Round(pgSize.Height)) <= 1.0 && Math.Abs((double)paperSize.Width - Math.Round(pgSize.Width)) <= 1.0)
				{
					return paperSize;
				}
			}
			return null;
		}
	}
}
