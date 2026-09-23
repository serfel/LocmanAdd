/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;

namespace TX_Text_Control_Words.FileHandling {

	public class DocumentDirtyChangedEventArgs : EventArgs {

		/*-------------------------------------------------------------------------------------------------------
		** Constructor
		**-----------------------------------------------------------------------------------------------------*/
		public DocumentDirtyChangedEventArgs(bool newValue) {
			NewValue = newValue;
		}

		/*-------------------------------------------------------------------------------------------------------
		** NewValue
		** New state of the document dirty flag
		**-----------------------------------------------------------------------------------------------------*/
		public bool NewValue { get; private set; }
	}
}
