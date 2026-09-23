using System;

namespace TXTextControl
{
	/// <summary>The TableEventArgs class provides data for the TextControl.TableCreated, TextControl.TableDeleted and TextControl.TableFormatChanged events.</summary>
	public class TableEventArgs : EventArgs
	{
		private TextControlCore textControlCore_0;

		private TextPart textPart_0;

		private int int_0;

		private int int_1;

		private Table table_0;

		/// <summary>Gets an object that represents the table which causes the event.</summary>
		public Table Table
		{
			get
			{
				if (this.table_0 == null)
				{
					this.table_0 = new Table(this.textControlCore_0, this.textPart_0, this.int_0, this.int_1);
				}
				return this.table_0;
			}
		}

		internal TableEventArgs(TextControlCore textControlCore_1, TextPart iTextPart, int iTableID, int iUserID)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
			this.int_0 = iTableID;
			this.int_1 = iUserID;
		}
	}
}
