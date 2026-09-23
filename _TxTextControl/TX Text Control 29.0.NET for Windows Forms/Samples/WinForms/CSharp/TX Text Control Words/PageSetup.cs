/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using System.Drawing.Printing;
using TX_Text_Control_Words.FileHandling;

namespace TX_Text_Control_Words {
	/*-------------------------------------------------------------------------------------------------------------
	** static class PageSetup
	** Implements a method for showing a dialog for the page's setup. Shows TextControl's build-in dialog by 
	** default except in the Standard Edition of TX TextControl because this dialog is not available instead
	** a System.Windows.Forms.PageSetupDialog is shown with TextControl's pagesettings.
	**-----------------------------------------------------------------------------------------------------------*/
	internal static class PageSetup {

		/*-------------------------------------------------------------------------------------------------------------
		** M E T H O D S
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** ShowDialog method
		** Shows a dialog for the page's setup. Shows TextControl's build-in dialog by 
		** default except in the Standard Edition of TX TextControl because this dialog is not available instead
		** a System.Windows.Forms.PageSetupDialog is shown with TextControl's pagesettings.
		**-----------------------------------------------------------------------------------------------------------*/
		internal static void ShowDialog(TXTextControl.TextControl tc,
			FileHandler fh) {
			if (tc.GetVersionInfo().Level == TXTextControl.VersionInfo.ProductLevel.Standard) {
				// TextControl's PageSetup Dialog is not available in the Standard Edition
				// show instead the build-in Windows Dialog
				ShowWindowsPageSetupDialog(tc, fh);
			}
			else {
				ShowTXPageSetupDialog(tc, fh);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** H E L P E R   M E T H O D S
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** ShowTXPageSetupDialog method
		** Shows the SectionFormatDialog and updates the dirty state of filehandler if the section's format is adjusted.
		**-----------------------------------------------------------------------------------------------------------*/
		private static void ShowTXPageSetupDialog(TXTextControl.TextControl tc, FileHandler fh) {
			try {
				if (tc.SectionFormatDialog(0) == System.Windows.Forms.DialogResult.OK) fh.IsDocumentDirty = true;
			}
			catch (Exception ex) {
				Utils.MessageBox.Show(tc, ex.Message, AssemblyAttributes.AssemblyProduct);
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** ShowTXPageSetupDialog method
		** Show a System.Windows.Forms.PageSetupDialog with current section's format. Force the TextControl to use
		** the page unit in centi inch.
		**-----------------------------------------------------------------------------------------------------------*/
		private static void ShowWindowsPageSetupDialog(
			TXTextControl.TextControl tc,
			FileHandler fh) {

			PageSetupDialog psd = new PageSetupDialog();
			psd.Document = new PrintDocument();

			tc.PageUnit = TXTextControl.MeasuringUnit.CentiInch;

			psd.EnableMetric = true;
			psd.PageSettings.PaperSize
				= GetTxPaperSize(
						tc.Selection.SectionFormat.PageSize,
						tc.Selection.SectionFormat.Landscape
				  );

			Margins mrgDlg = psd.PageSettings.Margins;
			TXTextControl.PageMargins mrgTX = tc.Selection.SectionFormat.PageMargins;
			mrgDlg.Top = (int)mrgTX.Top; mrgDlg.Right = (int)mrgTX.Right;
			mrgDlg.Bottom = (int)mrgTX.Bottom; mrgDlg.Left = (int)mrgTX.Left;

			psd.PageSettings.Landscape = tc.Selection.SectionFormat.Landscape;

			if (psd.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
				mrgDlg = psd.PageSettings.Margins;

				mrgTX.Top = mrgDlg.Top; mrgTX.Right = mrgDlg.Right;
				mrgTX.Bottom = mrgDlg.Bottom; mrgTX.Left = mrgDlg.Left;

				// Temporarily set page orientation to portrait so the 
				// page size is set correctly
				tc.Selection.SectionFormat.Landscape = false;

				tc.Selection.SectionFormat.PageSize.Height = psd.PageSettings.PaperSize.Height;
				tc.Selection.SectionFormat.PageSize.Width = psd.PageSettings.PaperSize.Width;
				tc.Selection.SectionFormat.Landscape = psd.PageSettings.Landscape;

				fh.IsDocumentDirty = true;
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** GetTxPaperSize method
		** Get a matching page size in the printer's paper size collection.
		**-----------------------------------------------------------------------------------------------------------*/
		private static System.Drawing.Printing.PaperSize GetTxPaperSize(TXTextControl.PageSize pgSize, bool bLandscape) {
			const int nTolerance = 1;

			PrintDocument pdoc = new PrintDocument();

			// Swap values if Landscape.
			if (bLandscape) pgSize = new TXTextControl.PageSize(pgSize.Height, pgSize.Width); // swap

			// Find a matching page size in the printer's paper size collection
			foreach (System.Drawing.Printing.PaperSize ps in pdoc.PrinterSettings.PaperSizes) {
				if ((Math.Abs(ps.Height - Math.Round(pgSize.Height)) <= nTolerance)
					&& (Math.Abs(ps.Width - Math.Round(pgSize.Width)) <= nTolerance)) return ps;
			}

			return null;
		}

	}
}
