using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TX_Text_Control_Words.Properties;
using TXTextControl;

namespace TX_Text_Control_Words {

	/*-------------------------------------------------------------------------------------------------------------
	** class TrackedChangesDialog
	** Implements a dialog for reviewing the tracked changes.
	**-----------------------------------------------------------------------------------------------------------*/
	public partial class TrackedChangesDialog : Form {

		/*-------------------------------------------------------------------------------------------------------------
		** M E M B E R S
		**-----------------------------------------------------------------------------------------------------------*/

		TrackedChangeCollection m_tcc;

		/*-------------------------------------------------------------------------------------------------------------
		** C O N S T R U C T O R S
		**-----------------------------------------------------------------------------------------------------------*/

		public TrackedChangesDialog() {
			InitializeComponent();
			LocalizeDialog();
		}

		public TrackedChangesDialog(TrackedChangeCollection trackedChanges)
			: this() {
			m_tcc = trackedChanges;
		}

		public TrackedChangesDialog(TrackedChangeCollection trackedChanges, string[] usernames)
			: this(trackedChanges) {
			// Add the usernames to TextControl.Usernames for enable the textcontrol to hightlight them
			// in the equal color like in the source TextControl is used.
			m_textControl.UserNames = usernames;
		}


		/*-------------------------------------------------------------------------------------------------------------
		** E V E N T H A N D L E R S
		**-----------------------------------------------------------------------------------------------------------*/


		/*-------------------------------------------------------------------------------------------------------------
		** btnNext_Click method
		** Review next tracked change.
		**-----------------------------------------------------------------------------------------------------------*/
		private void btnNext_Click(object sender, EventArgs e) {
			Next();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** Refresh method
		** Refresh the shown data of tracked change.
		**-----------------------------------------------------------------------------------------------------------*/
		new
		private void Refresh() {
			// Update information about the tracked change in the view
			UpdateTrackedChangeInfo();

			// Enable/Disable buttons
			UpdateEnableStates();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** btnReject_Click method
		** Reject tracked change and load next tracked change.
		**-----------------------------------------------------------------------------------------------------------*/
		private void btnReject_Click(object sender, EventArgs e) {
			TrackedChange tc = m_tcc.GetItem();
			if (tc != null) m_tcc.Remove(tc, false);

			// Move to next tracked change
			Next();
		}


		/*-------------------------------------------------------------------------------------------------------------
		** btnReject_Click method
		** Accept all tracked changes refresh the dialog.
		**-----------------------------------------------------------------------------------------------------------*/
		private void btnAcceptAll_Click(object sender, EventArgs e) {
			TrackedChangeCollection.TrackedChangeEnumerator tccEnumerator = m_tcc.GetEnumerator();
			while (tccEnumerator.MoveNext()) {
				m_tcc.Remove(tccEnumerator.Current as TrackedChange, true);
				tccEnumerator.Reset();
			}

			// Move to next tracked change
			Next();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** btnRejectAll_Click method
		** Reject all tracked changes and refresh dialog.
		**-----------------------------------------------------------------------------------------------------------*/
		private void btnRejectAll_Click(object sender, EventArgs e) {
			TrackedChangeCollection.TrackedChangeEnumerator tccEnumerator = m_tcc.GetEnumerator();
			while (tccEnumerator.MoveNext()) {
				m_tcc.Remove(tccEnumerator.Current as TrackedChange, false);
				tccEnumerator.Reset();
			}

			// Move to next tracked change
			Next();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** btnAccept_Click method
		** Accept tracked change.
		**-----------------------------------------------------------------------------------------------------------*/
		private void btnAccept_Click(object sender, EventArgs e) {
			TrackedChange tc = m_tcc.GetItem();
			if (tc != null) m_tcc.Remove(tc, true);

			// Move to next tracked change
			Next();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** btnClose_Click method
		** Close this dialog.
		**-----------------------------------------------------------------------------------------------------------*/
		private void btnClose_Click(object sender, EventArgs e) {
			this.Close();
		}

		/*-------------------------------------------------------------------------------------------------------------
		** TrackedChangesDialog_Shown method
		** Select first tracked change on start.
		**-----------------------------------------------------------------------------------------------------------*/
		private void TrackedChangesDialog_Shown(object sender, EventArgs e) {

			if (m_tcc != null && m_tcc.Count > 0) {
				// Go to first one
				m_tcc[1].Select();
				Refresh();
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** H E L P E R    M E T H O D S
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** LocalizeDialog method
		** Set localized texts to UI elements. 
		**-----------------------------------------------------------------------------------------------------------*/
		private void LocalizeDialog() {
			this.Text = Resources.TRACKED_CHANGES_DLG_TITLE;
			// Buttons
			btnAccept.Text = Resources.TRACKED_CHANGES_DLG_BTN_ACCEPT;
			btnAcceptAll.Text = Resources.TRACKED_CHANGES_DLG_BTN_ACCEPTALL;
			btnReject.Text = Resources.TRACKED_CHANGES_DLG_BTN_REJECT;
			btnRejectAll.Text = Resources.TRACKED_CHANGES_DLG_BTN_REJECTALL;
			btnNext.Text = Resources.TRACKED_CHANGES_DLG_BTN_NEXT;
			btnClose.Text = Resources.TRACKED_CHANGES_DLG_BTN_CLOSE;
		}


		/*-------------------------------------------------------------------------------------------------------------
		** UpdateEnableStates method
		** Update the enable states of the UI Elements.
		**-----------------------------------------------------------------------------------------------------------*/
		private void UpdateEnableStates() {
			bool hasItems = m_tcc.Count > 0;
			bool nextIsAvailable = m_tcc.GetItem(true) != null;
			bool tcAvailableAtInputPosition = m_tcc.GetItem() != null; // TrackChange is available at current input position

			// Navigation Buttons
			btnNext.Enabled = nextIsAvailable && hasItems; // NEXT tracked change is available

			// Accept Buttons
			btnAccept.Enabled =
			btnReject.Enabled =
			btnRejectAll.Enabled =
			btnAcceptAll.Enabled = hasItems && tcAvailableAtInputPosition;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** UpdateTrackedChangeInfo method
		** Show the user's name, when the tracked change is changed and which kind of change the user has done.
		**-----------------------------------------------------------------------------------------------------------*/
		private void UpdateTrackedChangeInfo() {
			TrackedChange tc = m_tcc.GetItem();
			if (tc != null) {
				// Update change time label
				string labelChangeTimeTextFormat = "({0})";
				labelChangeTime.Text = String.Format(labelChangeTimeTextFormat, tc.ChangeTime.ToLocalTime());

				// Update label which displays the name and the change kind
				string strChangeKind = tc.ChangeKind == ChangeKind.InsertedText ?
					Properties.Resources.TRACKED_CHANGES_DLG_CHANGEKIND_INSERTEDTEXT :
					Properties.Resources.TRACKED_CHANGES_DLG_CHANGEKIND_DELETEDTEXT;
				string strUsername = tc.UserName != "" ? tc.UserName :
					new System.Resources.ResourceManager("TXTextControl.TextControlCore", typeof(TXTextControl.ApplicationField).Assembly).GetString("ID_TRACKEDCHANGES_UNKNOWNUSER");
				labelReviewerAction.Text = string.Join(" ", strUsername, strChangeKind);

				// Load tracked change's data in TextControl
				byte[] tcData;
				BinaryStreamType tcDataFormat = BinaryStreamType.InternalUnicodeFormat;
				tc.Save(out tcData, tcDataFormat);
				m_textControl.Load(tcData, tcDataFormat);
			}
			else {
				// Clear Content
				labelChangeTime.Text = "";
				labelReviewerAction.Text = "";
				m_textControl.ResetContents();
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** Next method
		** Select next tracked change in TextControl and show this in this dialog.
		**-----------------------------------------------------------------------------------------------------------*/
		private void Next() {
			// Try to get the next tracked change
			var tc = m_tcc.GetItem(true);

			if (tc != null) {

				// Select current
				tc.Select();
			}

			Refresh();
		}
	}
}
