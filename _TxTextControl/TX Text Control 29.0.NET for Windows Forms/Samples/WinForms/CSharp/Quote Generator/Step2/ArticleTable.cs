/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Quote Generator Sample
** description:	This sample program shows how to use Text Control in office applications.  						
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Data;

namespace QuoteGenerator
{
	public class ArticleTable
	{
		// Insert product code, article description, and price for a selected article
		// from the article database
		public void InsertArticle(TXTextControl.TextControl tx, DataSet ArticleData)
		{
			frmSelectArticle ArticleSelector = new frmSelectArticle();

			// Open a dialog box to let the user select an article
			ArticleSelector.ArticleData = ArticleData;
			ArticleSelector.ShowDialog();

			if (ArticleSelector.SelectedProductRowIndex != -1)
			{
				string ProductCode; 
				string Price;
				string Description;

				// Get article data
				ProductCode = ArticleData.Tables[0].Rows[ArticleSelector.SelectedProductRowIndex]["product_code"].ToString();
				Price = ArticleData.Tables[0].Rows[ArticleSelector.SelectedProductRowIndex]["price"].ToString();
				Description = ArticleData.Tables[0].Rows[ArticleSelector.SelectedProductRowIndex]["description"].ToString();

				// Insert item in the selected table row. Insert in second row (below
				// the caption if caret is outside of the table.
				TXTextControl.Table ArticleTable = tx.Tables.GetItem();
				int CurrentRowNumber;

				if (ArticleTable == null)
				{
					ArticleTable = tx.Tables.GetItem(10);
					CurrentRowNumber = 2;
				}
				else
				{
					CurrentRowNumber = tx.Tables.GetItem().Rows.GetItem().Row;
				}

				ArticleTable.Cells.GetItem(CurrentRowNumber, 1).Text = ProductCode;
				ArticleTable.Cells.GetItem(CurrentRowNumber, 3).Text = Description;
				ArticleTable.Cells.GetItem(CurrentRowNumber, 4).Text = (Convert.ToDouble(Price)).ToString("c");
			}
		}

		// Process Change events which occur while the input position is inside a table:
		// recalculate the total price if the Quantity column is changed
		public void TableChangeEvent(TXTextControl.TextControl tx)
		{
			TXTextControl.Table ArticleTable = tx.Tables.GetItem();
			int CurrentRowNumber;

			if (ArticleTable != null)
			{
				CurrentRowNumber = tx.Tables.GetItem().Rows.GetItem().Row;
				try 
				{
					double value;

					value = Convert.ToDouble(ArticleTable.Cells.GetItem(CurrentRowNumber, 2).Text) * 
						Convert.ToDouble(StripNonNumeric(ArticleTable.Cells.GetItem(CurrentRowNumber, 4).Text));
					ArticleTable.Cells.GetItem(CurrentRowNumber, 5).Text = value.ToString("c");
				}
				catch {}
			}
		}

		// Remove all non-numeric characters from a string
		private string StripNonNumeric(string NonNumeric)
		{
			string Numeric = "";
			int n;

			for (n=0; n<NonNumeric.Length-1; n++) 
			{
				if (Char.IsDigit(NonNumeric[n]) || NonNumeric[n] == ',' || NonNumeric[n] == '.')
				{
					 Numeric += NonNumeric[n];
				}
			}
			return Numeric;
		}
	}
}