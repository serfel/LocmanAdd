/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System.Globalization;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TX_Text_Control_Words
{

	/*-----------------------------------------------------------------------------------------------------------
	** Capsulates the instanciation and functionalities of ribbon's group for changing the 
	** mainwindow's orientation. 
	**---------------------------------------------------------------------------------------------------------*/
	partial class MainWindow {

		/*-------------------------------------------------------------------------------------------------------
		** AddAppViewGroup method
		** Adds the group for setting application's viewsettings to the tab which will be rendered by the passed
		** DPI resolution.
		**-----------------------------------------------------------------------------------------------------*/
		private RibbonGroup AddAppViewGroup(RibbonTab tab) {

			// Create Group
			var grp = new RibbonGroup()
			{
				Text = Лоцман_добавка.Properties.Resources.VIEWTAB_APPVIEWGROUP_HEADER,
				SmallIcon = Images.GetSmallIcon("AppViewGroup"),
				LargeIcon = Images.GetSmallIcon("AppViewGroup"),
				HorizontalContentAlignment = TXTextControl.HorizontalAlignment.Center
			};
			grp.DialogBoxLauncher.Visible = false;

			// Add buttons to group
			AddRightToLeftFormLayoutButton(grp);

			// Add Group to tab
			tab.RibbonGroups.Add(grp);

			return grp;
		}

		/*-------------------------------------------------------------------------------------------------------
		** AddLeftToRightFormLayoutButton method
		** Adds a button to the group for setting the mainwindow's orientation. The button will be rendered 
		** by the passed DPI resolution.
		**-----------------------------------------------------------------------------------------------------*/
		private void AddRightToLeftFormLayoutButton(RibbonGroup grp) {

			// Create Right to Left Button
			var rightToLeftFormLayoutBtn = new RibbonToggleButton()
			{
				Text = Лоцман_добавка.Properties.Resources.VIEWTAB_APPVIEWGROUP_FLOWDIRECTION_LABEL,
				SmallIcon = Images.GetSmallIcon("FormLayoutRTL"),
				LargeIcon = Images.GetLargeIcon("FormLayoutRTL"),
				Checked = IsFormLayoutRightToLeft()
			};

			// Setting Form Layout
			rightToLeftFormLayoutBtn.Click += (sender, e) => {
				SetFormLayoutToRightToLeft(rightToLeftFormLayoutBtn.Checked);
			};

			// Updating the toggle state
			this.RightToLeftChanged += (sender, e) => {
				rightToLeftFormLayoutBtn.Checked = IsFormLayoutRightToLeft();
			};

			// Add
			grp.RibbonItems.Add(rightToLeftFormLayoutBtn);
		}

		/*-------------------------------------------------------------------------------------------------------
		** IsFormLayoutRigthToLeft method
		** Calculates whether the form's orientation is set to 'right to left'.
		**-----------------------------------------------------------------------------------------------------*/
		private bool IsFormLayoutRightToLeft() {

			switch (this.RightToLeft) {
				case System.Windows.Forms.RightToLeft.Yes:
					return true;
				case System.Windows.Forms.RightToLeft.No:
					return false;
				default:
					// Check system's settings
					return CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft;
			}
		}


		/*-------------------------------------------------------------------------------------------------------
		** SetFormLayoutToRightToLeft method
		** Shows a message box for notifying the user about the change of the application's orientation 
		** saves the new orientation in the application's settings.
		**-----------------------------------------------------------------------------------------------------*/
		private System.Windows.Forms.DialogResult SetFormLayoutToRightToLeft(bool booleanValue) {

			var result = Utils.MessageBox.Show(
				this,
				Лоцман_добавка.Properties.Resources.MSG_FLOWDIRECTIONCHANGED_TEXT,
				Лоцман_добавка.Properties.Resources.MSG_FLOWDIRECTIONCHANGED_TITLE,
				MessageBoxButtons.YesNo,
				MessageBoxIcon.Information);

			Лоцман_добавка.Properties.Settings.Default.Save();

			if (result == System.Windows.Forms.DialogResult.Yes) {
				Application.Restart();
			}

			return result;
		}
	}
}
