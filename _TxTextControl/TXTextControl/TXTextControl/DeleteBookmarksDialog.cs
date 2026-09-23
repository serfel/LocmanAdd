using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ns21;
using ns27;

namespace TXTextControl
{
	/// <summary>The DeleteBookmarksDialog class implements a Windows Forms dialog box which shows all targets in the current document.</summary>
	public class DeleteBookmarksDialog : Form
	{
		/// <summary>Each DialogItem represents an item in a DeleteBookmarksDialog dialog box.</summary>
		public enum DialogItem
		{
			/// <summary>Identifies the bookmark list label.</summary>
			TXITEM_BookmarkListLabel,
			/// <summary>Identifies the bookmark listbox.</summary>
			TXITEM_BookmarkList,
			/// <summary>Identifies the Delete button.</summary>
			TXITEM_DeleteBookmark,
			/// <summary>Identifies the Goto button.</summary>
			TXITEM_GotoBookmark,
			/// <summary>Identifies the Automatically Generated Bookmarks check box.</summary>
			TXITEM_AutoGenerationBookmarks,
			/// <summary>Identifies the Cancel button.</summary>
			TXITEM_Cancel
		}

		internal class Class465
		{
			private DocumentTarget documentTarget_0;

			private bool bool_0;

			internal DocumentTarget DocumentTarget_0 => this.documentTarget_0;

			internal bool Boolean_0 => this.bool_0;

			internal Class465(DocumentTarget documentTarget_1)
			{
				this.documentTarget_0 = documentTarget_1;
				this.bool_0 = documentTarget_1.AutoGenerationType == AutoGenerationType.TableOfContents;
			}

			public override string ToString()
			{
				return this.documentTarget_0.TargetName;
			}
		}

		private const string string_0 = "blockstart_";

		private const string string_1 = "blockend_";

		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private TextControl textControl_0;

		private bool bool_0;

		private uint uint_0;

		private List<Class465> list_0 = new List<Class465>();

		private IContainer icontainer_0;

		public TableLayoutPanel TXITEM_MainPanel;

		public Label TXITEM_BookmarkListLabel;

		public ListBox TXITEM_BookmarkList;

		public System.Windows.Forms.Button TXITEM_DeleteBookmark;

		public System.Windows.Forms.Button TXITEM_GotoBookmark;

		public System.Windows.Forms.Button TXITEM_Cancel;

		public CheckBox TXITEM_AutoGenerationBookmarks;

		private List<DocumentTarget> List_0
		{
			get
			{
				try
				{
					List<DocumentTarget> list = new List<DocumentTarget>();
					foreach (DocumentTarget documentTarget in this.textControl_0.DocumentTargets)
					{
						list.Add(documentTarget);
					}
					return list;
				}
				catch
				{
				}
				return null;
			}
		}

		/// <summary>Creates a DeleteBookmarksDialog object for the specified Windows Forms TextControl.</summary>
		/// <param name="textControl">Specifies the TextControl for which the dialog box is opened.</param>
		public DeleteBookmarksDialog(TextControl textControl)
		{
			this.InitializeComponent();
			this.textControl_0 = textControl;
			this.RightToLeft = this.textControl_0.RightToLeft;
			this.bool_0 = this.textControl_0.InputPosition.InactiveMarker;
			List<DocumentTarget> list = this.List_0;
			if (list == null)
			{
				return;
			}
			this.Text = this.resourceManager_0.GetString("ID_DELETEBOOKMARKS_CAPTION");
			this.TXITEM_BookmarkListLabel.Text = this.resourceManager_0.GetString("ID_DELETEBOOKMARKS_LABEL");
			this.TXITEM_DeleteBookmark.Text = this.resourceManager_0.GetString("ID_DELETEBOOKMARKS_DELETE");
			this.TXITEM_GotoBookmark.Text = this.resourceManager_0.GetString("ID_DELETEBOOKMARKS_GOTO");
			this.TXITEM_AutoGenerationBookmarks.Text = this.resourceManager_0.GetString("ID_DELETEBOOKMARKS_AUTOMATICALLY_GENERATED");
			this.TXITEM_Cancel.Text = this.resourceManager_0.GetString("ID_DELETEBOOKMARKS_CANCEL");
			DocumentTarget item = this.textControl_0.DocumentTargets.GetItem();
			string text = null;
			if (item != null)
			{
				this.TXITEM_AutoGenerationBookmarks.Checked = item.AutoGenerationType == AutoGenerationType.TableOfContents;
				text = item.TargetName;
			}
			int num = -1;
			int selectedIndex = -1;
			bool flag = false;
			for (int i = 0; i < list.Count; i++)
			{
				Class465 @class = new Class465(list[i]);
				this.list_0.Add(@class);
				flag |= @class.Boolean_0;
				if (!@class.Boolean_0 || this.TXITEM_AutoGenerationBookmarks.Checked)
				{
					num++;
					this.TXITEM_BookmarkList.Items.Add(@class);
					if (text == @class.ToString())
					{
						selectedIndex = num;
					}
				}
			}
			this.TXITEM_AutoGenerationBookmarks.Enabled = flag;
			this.TXITEM_AutoGenerationBookmarks.CheckedChanged += TXITEM_AutoGenerationBookmarks_CheckedChanged;
			this.TXITEM_BookmarkList.SelectedIndex = selectedIndex;
		}

		public Control FindItem(DialogItem dialogItem)
		{
			foreach (Control control in base.Controls["TXITEM_MainPanel"].Controls)
			{
				if (control.Name == dialogItem.ToString())
				{
					return control;
				}
			}
			return null;
		}

		private void method_0()
		{
			int num = -1;
			int selectedIndex = -1;
			string text = ((this.TXITEM_BookmarkList.SelectedItem != null) ? this.TXITEM_BookmarkList.SelectedItem.ToString() : null);
			this.TXITEM_BookmarkList.Items.Clear();
			for (int i = 0; i < this.list_0.Count; i++)
			{
				Class465 @class = this.list_0[i];
				if (!@class.Boolean_0 || this.TXITEM_AutoGenerationBookmarks.Checked)
				{
					num++;
					this.TXITEM_BookmarkList.Items.Add(@class);
					if (text == @class.ToString())
					{
						selectedIndex = num;
					}
				}
				this.TXITEM_BookmarkList.SelectedIndex = selectedIndex;
			}
		}

		protected override void OnClosing(CancelEventArgs cancelEventArgs_0)
		{
			this.textControl_0.InputPosition.InactiveMarker = this.bool_0;
			base.OnClosing(cancelEventArgs_0);
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			this.uint_0 = Class468.smethod_0(null, this);
			Class429.Struct83 struct83_ = default(Class429.Struct83);
			Class429.GetWindowRect(base.Handle, ref struct83_);
			Class468.smethod_1(this.uint_0, struct83_, this);
			base.OnHandleCreated(eventArgs_0);
		}

		protected override void WndProc(ref Message message)
		{
			int msg = message.Msg;
			if (msg == 736)
			{
				uint num = Class429.smethod_5(message.WParam.ToInt32());
				if (num != this.uint_0)
				{
					Class429.Struct83 struct83_ = (Class429.Struct83)Marshal.PtrToStructure(message.LParam, typeof(Class429.Struct83));
					this.Font = new Font(this.Font.Name, this.Font.Size * (float)num / (float)this.uint_0, this.Font.Style, this.Font.Unit);
					this.uint_0 = num;
					Class468.smethod_1(this.uint_0, struct83_, this);
				}
			}
			else
			{
				base.WndProc(ref message);
			}
		}

		private void TXITEM_BookmarkList_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.TXITEM_GotoBookmark.Enabled = this.TXITEM_BookmarkList.SelectedIndex > -1;
			this.TXITEM_DeleteBookmark.Enabled = this.TXITEM_GotoBookmark.Enabled && this.TXITEM_BookmarkList.SelectedItem is Class465;
		}

		private void TXITEM_GotoBookmark_Click(object sender, EventArgs e)
		{
			Class465 @class = this.TXITEM_BookmarkList.SelectedItem as Class465;
			if (@class != null)
			{
				this.textControl_0.InputPosition.InactiveMarker = true;
				@class.DocumentTarget_0.ScrollTo();
			}
		}

		private void TXITEM_DeleteBookmark_Click(object sender, EventArgs e)
		{
			DialogResult dialogResult = DialogResult.Yes;
			Class465 @class = (Class465)this.TXITEM_BookmarkList.SelectedItem;
			if (@class != null)
			{
				if (@class.DocumentTarget_0.TargetName.StartsWith("blockstart_", StringComparison.OrdinalIgnoreCase) || @class.DocumentTarget_0.TargetName.StartsWith("blockend_", StringComparison.OrdinalIgnoreCase))
				{
					dialogResult = MessageBox.Show(this.resourceManager_0.GetString("ID_DELETEBOOKMARKS_MSG1"), this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				}
				if (dialogResult == DialogResult.Yes)
				{
					this.textControl_0.DocumentTargets.Remove(@class.DocumentTarget_0);
					this.TXITEM_BookmarkList.Items.Remove(@class);
				}
			}
		}

		private void TXITEM_AutoGenerationBookmarks_CheckedChanged(object sender, EventArgs e)
		{
			this.method_0();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.TXITEM_MainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.TXITEM_AutoGenerationBookmarks = new System.Windows.Forms.CheckBox();
			this.TXITEM_BookmarkListLabel = new System.Windows.Forms.Label();
			this.TXITEM_BookmarkList = new System.Windows.Forms.ListBox();
			this.TXITEM_DeleteBookmark = new System.Windows.Forms.Button();
			this.TXITEM_GotoBookmark = new System.Windows.Forms.Button();
			this.TXITEM_Cancel = new System.Windows.Forms.Button();
			this.TXITEM_MainPanel.SuspendLayout();
			base.SuspendLayout();
			this.TXITEM_MainPanel.AutoSize = true;
			this.TXITEM_MainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TXITEM_MainPanel.ColumnCount = 2;
			this.TXITEM_MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.TXITEM_MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_AutoGenerationBookmarks, 0, 4);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_BookmarkListLabel, 0, 0);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_BookmarkList, 0, 1);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_DeleteBookmark, 1, 1);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_GotoBookmark, 1, 2);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_Cancel, 1, 5);
			this.TXITEM_MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TXITEM_MainPanel.Location = new System.Drawing.Point(7, 7);
			this.TXITEM_MainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.TXITEM_MainPanel.Name = "TXITEM_MainPanel";
			this.TXITEM_MainPanel.RowCount = 6;
			this.TXITEM_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_MainPanel.Size = new System.Drawing.Size(320, 229);
			this.TXITEM_MainPanel.TabIndex = 2;
			this.TXITEM_AutoGenerationBookmarks.AutoSize = true;
			this.TXITEM_AutoGenerationBookmarks.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_AutoGenerationBookmarks.Location = new System.Drawing.Point(0, 172);
			this.TXITEM_AutoGenerationBookmarks.Margin = new System.Windows.Forms.Padding(0, 0, 0, 13);
			this.TXITEM_AutoGenerationBookmarks.Name = "TXITEM_AutoGenerationBookmarks";
			this.TXITEM_AutoGenerationBookmarks.Size = new System.Drawing.Size(242, 17);
			this.TXITEM_AutoGenerationBookmarks.TabIndex = 11;
			this.TXITEM_AutoGenerationBookmarks.Text = "Automatically generated bookmarks";
			this.TXITEM_AutoGenerationBookmarks.UseVisualStyleBackColor = true;
			this.TXITEM_BookmarkListLabel.AutoSize = true;
			this.TXITEM_BookmarkListLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_BookmarkListLabel.Location = new System.Drawing.Point(0, 0);
			this.TXITEM_BookmarkListLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.TXITEM_BookmarkListLabel.Name = "TXITEM_BookmarkListLabel";
			this.TXITEM_BookmarkListLabel.Size = new System.Drawing.Size(242, 13);
			this.TXITEM_BookmarkListLabel.TabIndex = 0;
			this.TXITEM_BookmarkListLabel.Text = "Bookmarks:";
			this.TXITEM_BookmarkList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TXITEM_BookmarkList.FormattingEnabled = true;
			this.TXITEM_BookmarkList.IntegralHeight = false;
			this.TXITEM_BookmarkList.Location = new System.Drawing.Point(0, 19);
			this.TXITEM_BookmarkList.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
			this.TXITEM_BookmarkList.MinimumSize = new System.Drawing.Size(170, 150);
			this.TXITEM_BookmarkList.Name = "TXITEM_BookmarkList";
			this.TXITEM_MainPanel.SetRowSpan(this.TXITEM_BookmarkList, 3);
			this.TXITEM_BookmarkList.Size = new System.Drawing.Size(239, 150);
			this.TXITEM_BookmarkList.TabIndex = 1;
			this.TXITEM_BookmarkList.SelectedIndexChanged += new System.EventHandler(TXITEM_BookmarkList_SelectedIndexChanged);
			this.TXITEM_DeleteBookmark.AutoSize = true;
			this.TXITEM_DeleteBookmark.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TXITEM_DeleteBookmark.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_DeleteBookmark.Enabled = false;
			this.TXITEM_DeleteBookmark.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.TXITEM_DeleteBookmark.Location = new System.Drawing.Point(245, 19);
			this.TXITEM_DeleteBookmark.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.TXITEM_DeleteBookmark.MinimumSize = new System.Drawing.Size(75, 23);
			this.TXITEM_DeleteBookmark.Name = "TXITEM_DeleteBookmark";
			this.TXITEM_DeleteBookmark.Size = new System.Drawing.Size(75, 23);
			this.TXITEM_DeleteBookmark.TabIndex = 2;
			this.TXITEM_DeleteBookmark.Text = "Delete";
			this.TXITEM_DeleteBookmark.UseVisualStyleBackColor = true;
			this.TXITEM_DeleteBookmark.Click += new System.EventHandler(TXITEM_DeleteBookmark_Click);
			this.TXITEM_GotoBookmark.AutoSize = true;
			this.TXITEM_GotoBookmark.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TXITEM_GotoBookmark.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_GotoBookmark.Enabled = false;
			this.TXITEM_GotoBookmark.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.TXITEM_GotoBookmark.Location = new System.Drawing.Point(245, 48);
			this.TXITEM_GotoBookmark.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.TXITEM_GotoBookmark.MinimumSize = new System.Drawing.Size(75, 23);
			this.TXITEM_GotoBookmark.Name = "TXITEM_GotoBookmark";
			this.TXITEM_GotoBookmark.Size = new System.Drawing.Size(75, 23);
			this.TXITEM_GotoBookmark.TabIndex = 3;
			this.TXITEM_GotoBookmark.Text = "GoTo";
			this.TXITEM_GotoBookmark.UseVisualStyleBackColor = true;
			this.TXITEM_GotoBookmark.Click += new System.EventHandler(TXITEM_GotoBookmark_Click);
			this.TXITEM_Cancel.AutoSize = true;
			this.TXITEM_Cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TXITEM_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.TXITEM_Cancel.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_Cancel.Location = new System.Drawing.Point(245, 205);
			this.TXITEM_Cancel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
			this.TXITEM_Cancel.MinimumSize = new System.Drawing.Size(75, 23);
			this.TXITEM_Cancel.Name = "TXITEM_Cancel";
			this.TXITEM_Cancel.Size = new System.Drawing.Size(75, 23);
			this.TXITEM_Cancel.TabIndex = 4;
			this.TXITEM_Cancel.Text = "&Cancel";
			this.TXITEM_Cancel.UseVisualStyleBackColor = true;
			base.AcceptButton = this.TXITEM_DeleteBookmark;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.TXITEM_Cancel;
			base.ClientSize = new System.Drawing.Size(334, 243);
			base.Controls.Add(this.TXITEM_MainPanel);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "DeleteBookmarksDialog";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Delete Bookmark";
			this.TXITEM_MainPanel.ResumeLayout(false);
			this.TXITEM_MainPanel.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
