/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;

namespace TX_Text_Control_Words {

	/*-------------------------------------------------------------------------------------------------------------
	** class MainWindow
	** Capsulates the handling of MainWindow's events.
	**-----------------------------------------------------------------------------------------------------------*/
	public partial class MainWindow {

		/*-------------------------------------------------------------------------------------------------------------
		** MainWindow_Load
		** Update the window title, loading the application's settings, open the document passed by commandparameters
		** on application's start.
		**-----------------------------------------------------------------------------------------------------------*/
		private void MainWindow_Load(object sender, EventArgs e) {
			ActiveControl = m_textControl;

			// Load file provided as a command line argument
			string[] args = Environment.GetCommandLineArgs();
			if (args.Length > 1) {
				m_fileHandler.Open(args[1]);
			}

			// Calculate the DPI
			// before using the ResourceProvider for getting the images.
			m_DPI = CreateGraphics().DpiX;

			// Init and localize the ribbon by setting images dependly on the DPI and 
			// by setting the texts dependly on the culture.
			InitializeRibbon();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** MainWindow_FormClosing
		** Notify the filehandler and about closing and save the application's settings.
		**-----------------------------------------------------------------------------------------------------------*/
		private void MainWindow_FormClosing(object sender, FormClosingEventArgs e) {
			e.Cancel = !m_fileHandler.ExitApplication();
			if (!e.Cancel) SaveAppSettings();
		}
	}
}
