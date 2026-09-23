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
	/// <summary>The BookmarkDialog class implements a Windows Forms dialog box to insert a DocumentTarget at the current input position.</summary>
	public class BookmarkDialog : Form
	{
		/// <summary>Each DialogItem represents an item in a BookmarkDialog dialog box.</summary>
		public enum DialogItem
		{
			/// <summary>Identifies the Bookmark Name label.</summary>
			TXITEM_BookmarkNameLabel,
			/// <summary>Identifies the Bookmark Name text box.</summary>
			TXITEM_BookmarkName,
			/// <summary>Identifies the Bookmark Names label.</summary>
			TXITEM_BookmarkNamesLabel,
			/// <summary>Identifies the Bookmark Names list box.</summary>
			TXITEM_BookmarkNames,
			/// <summary>Identifies the Deletable check box.</summary>
			TXITEM_Deletable,
			/// <summary>Identifies the Automatically Generated Bookmarks check box.</summary>
			TXITEM_AutoGenerationBookmarks,
			/// <summary>Identifies the OK button.</summary>
			TXITEM_OK,
			/// <summary>Identifies the Cancel button.</summary>
			TXITEM_Cancel
		}

		internal class Class433
		{
			private DocumentTarget documentTarget_0;

			private bool bool_0;

			internal DocumentTarget DocumentTarget_0 => this.documentTarget_0;

			internal bool Boolean_0 => this.bool_0;

			internal Class433(DocumentTarget documentTarget_1)
			{
				this.documentTarget_0 = documentTarget_1;
				this.bool_0 = documentTarget_1.AutoGenerationType == AutoGenerationType.TableOfContents;
			}

			public override string ToString()
			{
				return this.documentTarget_0.TargetName;
			}
		}

		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private TextControl textControl_0;

		private DocumentTarget documentTarget_0;

		private uint uint_0;

		private List<Class433> list_0 = new List<Class433>();

		private IContainer icontainer_0;

		public Label TXITEM_BookmarkNameLabel;

		public CheckBox TXITEM_Deletable;

		public TextBox TXITEM_BookmarkName;

		private TableLayoutPanel TXITEM_MainPanel;

		private ListBox TXITEM_BookmarkNames;

		public System.Windows.Forms.Button TXITEM_OK;

		public System.Windows.Forms.Button TXITEM_Cancel;

		private Label TXITEM_BookmarkNamesLabel;

		public CheckBox TXITEM_AutoGenerationBookmarks;

		/// <summary>Creates a BookmarkDialog object for the specified Windows Forms TextControl. If there is a target at the current input position, the name of the target is shown and can be edited. Otherwise a new DocumentTarget can be inserted at the current input position.</summary>
		/// <param name="textControl">Specifies the TextControl for which the dialog box is opened.</param>
		public BookmarkDialog(TextControl textControl)
		{
			this.method_0(textControl, textControl.DocumentTargets.GetItem());
		}

		/// <summary>Creates a BookmarkDialog object for the specified Windows Forms TextControl. If the specified DocumentTarget is not null, the name of the target is shown and can be edited. Otherwise a new DocumentTarget can be inserted at the current input position.</summary>
		/// <param name="textControl">Specifies the TextControl for which the dialog box is opened.</param>
		/// <param name="bookmarkToEdit">Specifies the DocumentTarget to edit.</param>
		public BookmarkDialog(TextControl textControl, DocumentTarget bookmarkToEdit)
		{
			this.method_0(textControl, bookmarkToEdit);
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

		private void method_0(TextControl textControl_1, DocumentTarget documentTarget_1)
		{
			this.method_3();
			this.TXITEM_BookmarkNameLabel.Text = this.resourceManager_0.GetString("ID_INSERTBOOKMARK_NAME");
			this.TXITEM_Deletable.Text = this.resourceManager_0.GetString("ID_INSERTBOOKMARK_DELETABLE");
			this.TXITEM_AutoGenerationBookmarks.Text = this.resourceManager_0.GetString("ID_INSERTBOOKMARK_AUTOMATICALLY_GENERATED");
			this.TXITEM_OK.Text = this.resourceManager_0.GetString("ID_INSERTBOOKMARK_OK");
			this.TXITEM_Cancel.Text = this.resourceManager_0.GetString("ID_INSERTBOOKMARK_CANCEL");
			this.textControl_0 = textControl_1;
			this.RightToLeft = this.textControl_0.RightToLeft;
			string text = "";
			this.documentTarget_0 = documentTarget_1;
			DocumentTarget[] array = null;
			if (this.documentTarget_0 == null)
			{
				this.TXITEM_BookmarkNamesLabel.Text = this.resourceManager_0.GetString("ID_INSERTBOOKMARK_NAMES_INSERT");
				array = new DocumentTarget[this.textControl_0.DocumentTargets.Count];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = this.textControl_0.DocumentTargets[i + 1];
				}
				this.Text = this.resourceManager_0.GetString("ID_INSERTBOOKMARK_CAPTION");
			}
			else
			{
				this.TXITEM_BookmarkNamesLabel.Text = this.resourceManager_0.GetString("ID_INSERTBOOKMARK_NAMES_EDIT");
				array = this.textControl_0.DocumentTargets.GetItems();
				this.Text = this.resourceManager_0.GetString("ID_EDITBOOKMARK_CAPTION");
				if (!this.method_2(this.documentTarget_0, array))
				{
					throw new InvalidOperationException(this.resourceManager_0.GetString("ERR_BOOKMARKDIALOG_NOT_EDITABLE"));
				}
				this.TXITEM_AutoGenerationBookmarks.Checked = this.documentTarget_0.AutoGenerationType == AutoGenerationType.TableOfContents;
				text = (this.TXITEM_BookmarkName.Text = this.documentTarget_0.TargetName);
				this.TXITEM_BookmarkName.SelectAll();
				this.TXITEM_Deletable.Checked = this.documentTarget_0.Deleteable;
			}
			if (array == null)
			{
				return;
			}
			int num = -1;
			int selectedIndex = -1;
			bool flag = false;
			for (int j = 0; j < array.Length; j++)
			{
				Class433 @class = new Class433(array[j]);
				this.list_0.Add(@class);
				flag |= @class.Boolean_0;
				if (!@class.Boolean_0 || this.TXITEM_AutoGenerationBookmarks.Checked)
				{
					num++;
					this.TXITEM_BookmarkNames.Items.Add(@class);
					if (text == @class.ToString())
					{
						selectedIndex = num;
					}
				}
			}
			this.TXITEM_AutoGenerationBookmarks.Enabled = flag;
			this.TXITEM_BookmarkNames.SelectedIndex = selectedIndex;
			this.TXITEM_BookmarkNames.SelectedIndexChanged += TXITEM_BookmarkNames_SelectedIndexChanged;
		}

		private void method_1()
		{
			int selectedIndex = -1;
			this.TXITEM_BookmarkNames.Items.Clear();
			this.TXITEM_BookmarkName.Text = "";
			for (int i = 0; i < this.list_0.Count; i++)
			{
				Class433 @class = this.list_0[i];
				if (!@class.Boolean_0 || this.TXITEM_AutoGenerationBookmarks.Checked)
				{
					this.TXITEM_BookmarkNames.Items.Add(@class);
					if (this.TXITEM_BookmarkName.Text == @class.ToString())
					{
						selectedIndex = i;
					}
				}
				this.TXITEM_BookmarkNames.SelectedIndex = selectedIndex;
			}
		}

		private bool method_2(DocumentTarget documentTarget_1, DocumentTarget[] documentTarget_2)
		{
			int hashCode = documentTarget_1.GetHashCode();
			int num = 0;
			while (true)
			{
				if (num < documentTarget_2.Length)
				{
					DocumentTarget documentTarget = documentTarget_2[num];
					if (hashCode == documentTarget.GetHashCode())
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}

		private void TXITEM_BookmarkNames_SelectedIndexChanged(object sender, EventArgs e)
		{
			Class433 @class = this.TXITEM_BookmarkNames.SelectedItem as Class433;
			if (@class != null)
			{
				if (this.documentTarget_0 != null)
				{
					this.documentTarget_0 = @class.DocumentTarget_0;
					this.TXITEM_Deletable.Checked = this.documentTarget_0.Deleteable;
				}
				this.TXITEM_BookmarkName.Text = @class.ToString();
			}
		}

		private void TXITEM_OK_Click(object sender, EventArgs e)
		{
			if (this.documentTarget_0 != null)
			{
				this.documentTarget_0.TargetName = this.TXITEM_BookmarkName.Text;
				this.documentTarget_0.Deleteable = this.TXITEM_Deletable.Checked;
			}
			else
			{
				this.documentTarget_0 = new DocumentTarget(this.TXITEM_BookmarkName.Text)
				{
					Deleteable = this.TXITEM_Deletable.Checked
				};
				this.textControl_0.DocumentTargets.Add(this.documentTarget_0);
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		private void TXITEM_BookmarkName_TextChanged(object sender, EventArgs e)
		{
			this.TXITEM_OK.Enabled = this.TXITEM_BookmarkName.Text.Length > 0;
		}

		private void TXITEM_AutoGenerationBookmarks_CheckedChanged(object sender, EventArgs e)
		{
			this.method_1();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void method_3()
		{
			this.TXITEM_MainPanel = new TableLayoutPanel();
			this.TXITEM_BookmarkName = new TextBox();
			this.TXITEM_BookmarkNameLabel = new Label();
			this.TXITEM_Deletable = new CheckBox();
			this.TXITEM_OK = new System.Windows.Forms.Button();
			this.TXITEM_Cancel = new System.Windows.Forms.Button();
			this.TXITEM_BookmarkNames = new ListBox();
			this.TXITEM_BookmarkNamesLabel = new Label();
			this.TXITEM_AutoGenerationBookmarks = new CheckBox();
			this.TXITEM_MainPanel.SuspendLayout();
			base.SuspendLayout();
			this.TXITEM_MainPanel.AutoSize = true;
			this.TXITEM_MainPanel.ColumnCount = 3;
			this.TXITEM_MainPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.TXITEM_MainPanel.ColumnStyles.Add(new ColumnStyle());
			this.TXITEM_MainPanel.ColumnStyles.Add(new ColumnStyle());
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_AutoGenerationBookmarks, 0, 5);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_BookmarkName, 0, 1);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_BookmarkNameLabel, 0, 0);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_Deletable, 0, 4);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_OK, 1, 6);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_Cancel, 2, 6);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_BookmarkNames, 0, 3);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_BookmarkNamesLabel, 0, 2);
			this.TXITEM_MainPanel.Dock = DockStyle.Fill;
			this.TXITEM_MainPanel.Location = new Point(7, 7);
			this.TXITEM_MainPanel.Margin = new Padding(0);
			this.TXITEM_MainPanel.Name = "TXITEM_MainPanel";
			this.TXITEM_MainPanel.RowCount = 7;
			this.TXITEM_MainPanel.RowStyles.Add(new RowStyle());
			this.TXITEM_MainPanel.RowStyles.Add(new RowStyle());
			this.TXITEM_MainPanel.RowStyles.Add(new RowStyle());
			this.TXITEM_MainPanel.RowStyles.Add(new RowStyle());
			this.TXITEM_MainPanel.RowStyles.Add(new RowStyle());
			this.TXITEM_MainPanel.RowStyles.Add(new RowStyle());
			this.TXITEM_MainPanel.RowStyles.Add(new RowStyle());
			this.TXITEM_MainPanel.Size = new Size(411, 217);
			this.TXITEM_MainPanel.TabIndex = 1;
			this.TXITEM_MainPanel.SetColumnSpan(this.TXITEM_BookmarkName, 3);
			this.TXITEM_BookmarkName.Dock = DockStyle.Top;
			this.TXITEM_BookmarkName.Location = new Point(0, 18);
			this.TXITEM_BookmarkName.Margin = new Padding(0, 0, 0, 6);
			this.TXITEM_BookmarkName.MinimumSize = new Size(365, 4);
			this.TXITEM_BookmarkName.Name = "TXITEM_BookmarkName";
			this.TXITEM_BookmarkName.Size = new Size(411, 20);
			this.TXITEM_BookmarkName.TabIndex = 1;
			this.TXITEM_BookmarkName.TextChanged += TXITEM_BookmarkName_TextChanged;
			this.TXITEM_BookmarkNameLabel.AutoSize = true;
			this.TXITEM_MainPanel.SetColumnSpan(this.TXITEM_BookmarkNameLabel, 3);
			this.TXITEM_BookmarkNameLabel.Dock = DockStyle.Top;
			this.TXITEM_BookmarkNameLabel.Location = new Point(0, 0);
			this.TXITEM_BookmarkNameLabel.Margin = new Padding(0, 0, 0, 5);
			this.TXITEM_BookmarkNameLabel.Name = "TXITEM_BookmarkNameLabel";
			this.TXITEM_BookmarkNameLabel.Size = new Size(411, 13);
			this.TXITEM_BookmarkNameLabel.TabIndex = 0;
			this.TXITEM_BookmarkNameLabel.Text = "Bookmark name:";
			this.TXITEM_Deletable.AutoSize = true;
			this.TXITEM_Deletable.Checked = true;
			this.TXITEM_Deletable.CheckState = CheckState.Checked;
			this.TXITEM_MainPanel.SetColumnSpan(this.TXITEM_Deletable, 3);
			this.TXITEM_Deletable.Dock = DockStyle.Top;
			this.TXITEM_Deletable.Location = new Point(0, 139);
			this.TXITEM_Deletable.Margin = new Padding(0, 0, 0, 5);
			this.TXITEM_Deletable.Name = "TXITEM_Deletable";
			this.TXITEM_Deletable.Size = new Size(411, 17);
			this.TXITEM_Deletable.TabIndex = 4;
			this.TXITEM_Deletable.Text = "Can be deleted";
			this.TXITEM_Deletable.UseVisualStyleBackColor = true;
			this.TXITEM_OK.AutoSize = true;
			this.TXITEM_OK.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.TXITEM_OK.Dock = DockStyle.Top;
			this.TXITEM_OK.Enabled = false;
			this.TXITEM_OK.Location = new Point(255, 194);
			this.TXITEM_OK.Margin = new Padding(3, 3, 3, 0);
			this.TXITEM_OK.MinimumSize = new Size(75, 23);
			this.TXITEM_OK.Name = "TXITEM_OK";
			this.TXITEM_OK.Size = new Size(75, 23);
			this.TXITEM_OK.TabIndex = 5;
			this.TXITEM_OK.Text = "&OK";
			this.TXITEM_OK.UseVisualStyleBackColor = true;
			this.TXITEM_OK.Click += TXITEM_OK_Click;
			this.TXITEM_Cancel.AutoSize = true;
			this.TXITEM_Cancel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.TXITEM_Cancel.DialogResult = DialogResult.Cancel;
			this.TXITEM_Cancel.Dock = DockStyle.Top;
			this.TXITEM_Cancel.Location = new Point(336, 194);
			this.TXITEM_Cancel.Margin = new Padding(3, 3, 0, 0);
			this.TXITEM_Cancel.MinimumSize = new Size(75, 23);
			this.TXITEM_Cancel.Name = "TXITEM_Cancel";
			this.TXITEM_Cancel.Size = new Size(75, 23);
			this.TXITEM_Cancel.TabIndex = 6;
			this.TXITEM_Cancel.Text = "&Cancel";
			this.TXITEM_Cancel.UseVisualStyleBackColor = true;
			this.TXITEM_MainPanel.SetColumnSpan(this.TXITEM_BookmarkNames, 3);
			this.TXITEM_BookmarkNames.Dock = DockStyle.Fill;
			this.TXITEM_BookmarkNames.FormattingEnabled = true;
			this.TXITEM_BookmarkNames.Location = new Point(0, 62);
			this.TXITEM_BookmarkNames.Margin = new Padding(0, 0, 0, 13);
			this.TXITEM_BookmarkNames.Name = "TXITEM_BookmarkNames";
			this.TXITEM_BookmarkNames.Size = new Size(411, 64);
			this.TXITEM_BookmarkNames.TabIndex = 3;
			this.TXITEM_BookmarkNamesLabel.AutoSize = true;
			this.TXITEM_MainPanel.SetColumnSpan(this.TXITEM_BookmarkNamesLabel, 3);
			this.TXITEM_BookmarkNamesLabel.Dock = DockStyle.Top;
			this.TXITEM_BookmarkNamesLabel.Location = new Point(0, 44);
			this.TXITEM_BookmarkNamesLabel.Margin = new Padding(0, 0, 0, 5);
			this.TXITEM_BookmarkNamesLabel.Name = "TXITEM_BookmarkNamesLabel";
			this.TXITEM_BookmarkNamesLabel.Size = new Size(411, 13);
			this.TXITEM_BookmarkNamesLabel.TabIndex = 2;
			this.TXITEM_BookmarkNamesLabel.Text = "Bookmarks in document:";
			this.TXITEM_AutoGenerationBookmarks.AutoSize = true;
			this.TXITEM_MainPanel.SetColumnSpan(this.TXITEM_AutoGenerationBookmarks, 3);
			this.TXITEM_AutoGenerationBookmarks.Dock = DockStyle.Top;
			this.TXITEM_AutoGenerationBookmarks.Location = new Point(0, 161);
			this.TXITEM_AutoGenerationBookmarks.Margin = new Padding(0, 0, 0, 13);
			this.TXITEM_AutoGenerationBookmarks.Name = "TXITEM_AutoGenerationBookmarks";
			this.TXITEM_AutoGenerationBookmarks.Size = new Size(411, 17);
			this.TXITEM_AutoGenerationBookmarks.TabIndex = 7;
			this.TXITEM_AutoGenerationBookmarks.Text = "Automatically generated bookmarks";
			this.TXITEM_AutoGenerationBookmarks.UseVisualStyleBackColor = true;
			this.TXITEM_AutoGenerationBookmarks.CheckedChanged += TXITEM_AutoGenerationBookmarks_CheckedChanged;
			base.AcceptButton = this.TXITEM_OK;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			base.CancelButton = this.TXITEM_Cancel;
			base.ClientSize = new Size(425, 231);
			base.Controls.Add(this.TXITEM_MainPanel);
			base.FormBorderStyle = FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "BookmarkDialog";
			base.Padding = new Padding(7, 7, 7, 7);
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = FormStartPosition.CenterScreen;
			this.Text = "Insert Bookmark";
			this.TXITEM_MainPanel.ResumeLayout(performLayout: false);
			this.TXITEM_MainPanel.PerformLayout();
			base.ResumeLayout(performLayout: false);
			base.PerformLayout();
		}
	}
}
