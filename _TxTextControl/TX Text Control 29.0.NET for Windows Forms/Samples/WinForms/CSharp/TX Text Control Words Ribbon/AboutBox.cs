/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.Windows.Forms;
using TX_Text_Control_Words.Properties;
using TXTextControl;

namespace TX_Text_Control_Words {

	/*---------------------------------------------------------------------------------------------------------
	** Partial Class AboutBox
	** Implements a dialog for displaying details about the current TX Text Control Words version.
	**-------------------------------------------------------------------------------------------------------*/
	partial class AboutBox : Form {

		/*------------------------------------------------------------------------------------------------------
		** C O N S T R U C T O R S
		**----------------------------------------------------------------------------------------------------*/

		/*------------------------------------------------------------------------------------------------------
		** AboutBox
		** Initializes a new instance of the AboutBox class and sets the corresponding content.
		**----------------------------------------------------------------------------------------------------*/
		private AboutBox(VersionInfo versionInfo) {
			InitializeComponent();

			// TextControl Version Infos
			Text = String.Format(Resources.ABOUTBOX_FORMAT_TITLE, AssemblyAttributes.AssemblyProduct);
			_lblSubTitle.Text = (AssemblyAttributes.Is64BitAssembly ? "64-bit" : "32-bit") + " Windows Forms Edition";
			_lblProductName.Text = ProductName;
			_lblVersion.Text
				= String.Format(
					"Version {0}.{1}",
					AssemblyAttributes.AssemblyVersion.Major.ToString(),
					AssemblyAttributes.AssemblyVersion.Minor.ToString());

			// Copyright Label
			if (versionInfo.ServicePack > 0) _lblVersion.Text += " Service Pack " + versionInfo.ServicePack;
			_lblCopyright.Text = AssemblyAttributes.AssemblyCopyright;

			// Images
			this.BackgroundImage = new Bitmap(typeof(MainWindow), "Images.txwords_info.png");

			var assemblyTitle = AssemblyAttributes.AssemblyTitle.ToLower();
			_lblApplicationType.Text = assemblyTitle.Contains("ribbon") ? "" : Resources.ABOUTBOX_LBL_APPLICATIONTYPE;

			_linkLabel.Text = Resources.ABOUTBOX_LINKLABEL_TEXT;
			_btnClose.Text = Resources.ABOUTBOX_CLOSE_TEXT;
		}


		/*-------------------------------------------------------------------------------------------------------
		** M E T H O D S
		**-----------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------
		** Show
		** Opens the AboutBox dialog
		**-----------------------------------------------------------------------------------------------------*/
		public static DialogResult Show(IWin32Window owner, VersionInfo versionInfo) {
			return (new AboutBox(versionInfo)).ShowDialog(owner);
		}


		/*-------------------------------------------------------------------------------------------------------
		** H A N D L E R
		**-----------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------
		** LinkLabel_LinkClicked
		** Opens the specified Uri.
		**-----------------------------------------------------------------------------------------------------*/
		private void LinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
			System.Diagnostics.Process.Start("http://www.textcontrol.com/txtextcontrolwords/");
		}

	}
}
