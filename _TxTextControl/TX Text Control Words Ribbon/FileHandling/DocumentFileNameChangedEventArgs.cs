/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;

namespace TX_Text_Control_Words.FileHandling {

	public class DocumentFileNameChangedEventArgs : EventArgs {

		/*-------------------------------------------------------------------------------------------------------
		** Constructor
		**-----------------------------------------------------------------------------------------------------*/
		public DocumentFileNameChangedEventArgs(string newName) {
			NewName = newName;
		}

		/*-------------------------------------------------------------------------------------------------------
		** NewName
		** New value of document's filename.
		**-----------------------------------------------------------------------------------------------------*/
		public string NewName { get; private set; }
	}
}
