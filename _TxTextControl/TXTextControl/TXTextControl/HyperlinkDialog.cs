using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ns21;
using ns27;

namespace TXTextControl
{
	/// <summary>The HyperlinkDialog class implements a Windows Forms dialog box for inserting and editing a hyperlink at the current text input position.</summary>
	public class HyperlinkDialog : Form
	{
		/// <summary>Each DialogItem represents an item in a HyperlinkDialog dialog box.</summary>
		public enum DialogItem
		{
			/// <summary>Identifies the Hyperlink text label.</summary>
			TXITEM_HyperlinkTextLabel,
			/// <summary>Identifies the Hyperlink text edit control.</summary>
			TXITEM_HyperlinkText,
			/// <summary>Identifies the Hyperlink label.</summary>
			TXITEM_HyperlinkLabel,
			/// <summary>Identifies the Hyperlink edit control.</summary>
			TXITEM_Hyperlink,
			/// <summary>Identifies the Select File button.</summary>
			TXITEM_SelectFile,
			/// <summary>Identifies the bookmark list label.</summary>
			TXITEM_BookmarkListLabel,
			/// <summary>Identifies the bookmark listbox.</summary>
			TXITEM_BookmarkList,
			/// <summary>Identifies the Show Bookmarks label.</summary>
			TXITEM_ShowBookmarks,
			/// <summary>Identifies the Current Document radio button.</summary>
			TXITEM_CurrentDocument,
			/// <summary>Identifies the Selected File radio button.</summary>
			TXITEM_SelectedFile,
			/// <summary>Identifies the Automatically Generated Bookmarks check box.</summary>
			TXITEM_AutoGenerationBookmarks,
			/// <summary>Identifies the Delete Hyperlink button.</summary>
			TXITEM_DeleteHyperlink,
			/// <summary>Identifies the OK button.</summary>
			TXITEM_OK,
			/// <summary>Identifies the Cancel button.</summary>
			TXITEM_Cancel
		}

		internal class Class469
		{
			private DocumentTarget documentTarget_0;

			private bool bool_0;

			internal DocumentTarget DocumentTarget_0 => this.documentTarget_0;

			internal bool Boolean_0 => this.bool_0;

			internal Class469(DocumentTarget documentTarget_1)
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

		private TextControl textControl_1;

		private string string_0 = string.Empty;

		private int int_0;

		private uint uint_0;

		private List<Class469> list_0 = new List<Class469>();

		private IContainer icontainer_0;

		public System.Windows.Forms.Button TXITEM_DeleteHyperlink;

		public Label TXITEM_HyperlinkTextLabel;

		public TextBox TXITEM_HyperlinkText;

		public Label TXITEM_HyperlinkLabel;

		public TextBox TXITEM_Hyperlink;

		public System.Windows.Forms.Button TXITEM_SelectFile;

		public Label TXITEM_BookmarkListLabel;

		private Label TXITEM_ShowBookmarks;

		public ListBox TXITEM_BookmarkList;

		public RadioButton TXITEM_CurrentDocument;

		public RadioButton TXITEM_SelectedFile;

		public System.Windows.Forms.Button TXITEM_Cancel;

		public System.Windows.Forms.Button TXITEM_OK;

		private TableLayoutPanel TXITEM_MainPanel;

		private TableLayoutPanel TXITEM_AddressPanel;

		private TableLayoutPanel TXITEM_BookmarksPanel;

		public CheckBox TXITEM_AutoGenerationBookmarks;

		/// <summary>Creates a HyperlinkDialog object for the specified Windows Forms TextControl.</summary>
		/// <param name="textControl">Specifies the TextControl for which the dialog box is opened.</param>
		public HyperlinkDialog(TextControl textControl)
		{
			DocumentLink documentLink = null;
			if (!textControl.HypertextLinks.CanAdd && (documentLink = textControl.DocumentLinks.GetItem()) == null && textControl.HypertextLinks.GetItem() == null)
			{
				throw new InvalidOperationException(this.resourceManager_0.GetString("ERR_HYPERLINKDIALOG"));
			}
			this.InitializeComponent();
			this.TXITEM_HyperlinkTextLabel.Text = this.resourceManager_0.GetString("ID_INSERTHYPERLINK_TEXT");
			this.TXITEM_HyperlinkLabel.Text = this.resourceManager_0.GetString("ID_INSERTHYPERLINK_ADDRESS");
			this.TXITEM_SelectFile.Text = this.resourceManager_0.GetString("ID_INSERTHYPERLINK_SELECTFILE");
			this.TXITEM_BookmarkListLabel.Text = this.resourceManager_0.GetString("ID_INSERTHYPERLINK_BOOKMARKS");
			this.TXITEM_ShowBookmarks.Text = this.resourceManager_0.GetString("ID_INSERTHYPERLINK_SHOWBOOKMARKS");
			this.TXITEM_CurrentDocument.Text = this.resourceManager_0.GetString("ID_INSERTHYPERLINK_SHOWDOCUMENT");
			this.TXITEM_SelectedFile.Text = this.resourceManager_0.GetString("ID_INSERTHYPERLINK_SHOWFILE");
			this.TXITEM_AutoGenerationBookmarks.Text = this.resourceManager_0.GetString("ID_INSERTHYPERLINK_AUTOMATICALLY_GENERATED");
			this.TXITEM_DeleteHyperlink.Text = this.resourceManager_0.GetString("ID_INSERTHYPERLINK_DELETEHYPERLINK");
			this.TXITEM_OK.Text = this.resourceManager_0.GetString("ID_INSERTHYPERLINK_OK");
			this.TXITEM_Cancel.Text = this.resourceManager_0.GetString("ID_INSERTHYPERLINK_CANCEL");
			this.textControl_0 = textControl;
			this.RightToLeft = this.textControl_0.RightToLeft;
			this.method_6(documentLink?.DocumentTarget, this.method_7(this.textControl_0), bool_0: false);
			this.textControl_1 = new TextControl();
			this.textControl_1.Width = 100;
			this.textControl_1.Height = 100;
			this.textControl_1.Location = new Point(25, 25);
			this.textControl_1.TabStop = false;
			this.textControl_1.CreateControl();
			this.method_1();
		}

		public Control FindItem(DialogItem dialogItem)
		{
			return this.method_0(dialogItem, this);
		}

		private Control method_0(DialogItem dialogItem_0, Control control_0)
		{
			if (control_0.Name == dialogItem_0.ToString())
			{
				return control_0;
			}
			foreach (Control control2 in control_0.Controls)
			{
				Control control = this.method_0(dialogItem_0, control2);
				if (control != null)
				{
					return control;
				}
			}
			return null;
		}

		private void method_1()
		{
			this.int_0 = this.method_2();
			if (this.int_0 > 0)
			{
				this.TXITEM_OK.Enabled = true;
				this.TXITEM_HyperlinkText.SelectAll();
				this.Text = this.resourceManager_0.GetString("ID_EDITHYPERLINK_CAPTION");
			}
			else
			{
				this.Text = this.resourceManager_0.GetString("ID_INSERTHYPERLINK_CAPTION");
				this.TXITEM_DeleteHyperlink.Enabled = false;
			}
			this.TXITEM_CurrentDocument.CheckedChanged += TXITEM_CurrentDocument_CheckedChanged;
			this.TXITEM_SelectedFile.CheckedChanged += TXITEM_SelectedFile_CheckedChanged;
		}

		private int method_2()
		{
			int result = 0;
			HypertextLink item = this.textControl_0.HypertextLinks.GetItem();
			DocumentLink documentLink = null;
			if (item != null)
			{
				string[] array = item.Target.Split('#');
				result = 2;
				this.TXITEM_HyperlinkText.Text = item.Text;
				this.TXITEM_Hyperlink.Text = item.Target;
				if (array.Length >= 1 && File.Exists(array[0]))
				{
					this.method_3(array[0]);
					if (this.string_0.Length > 0 && array.Length > 1)
					{
						foreach (Class469 item2 in this.TXITEM_BookmarkList.Items)
						{
							if (item2.ToString() == array[1])
							{
								this.TXITEM_BookmarkList.SelectedItem = item2;
								return result;
							}
						}
						return result;
					}
				}
			}
			else
			{
				documentLink = this.textControl_0.DocumentLinks.GetItem();
				if (documentLink != null)
				{
					DocumentTarget documentTarget = documentLink.DocumentTarget;
					result = 1;
					this.TXITEM_HyperlinkText.Text = documentLink.Text;
					if (documentTarget != null)
					{
						this.TXITEM_Hyperlink.Text = "#" + documentLink.DocumentTarget.TargetName;
					}
					this.TXITEM_Hyperlink.ReadOnly = true;
					this.TXITEM_SelectFile.Enabled = false;
					if (documentTarget != null)
					{
						foreach (Class469 item3 in this.TXITEM_BookmarkList.Items)
						{
							if (item3.DocumentTarget_0.Equals(documentLink.DocumentTarget))
							{
								this.TXITEM_BookmarkList.SelectedItem = item3;
								return result;
							}
						}
						return result;
					}
				}
			}
			return result;
		}

		private void method_3(string string_1)
		{
			LoadSettings loadSettings = new LoadSettings();
			loadSettings.ApplicationFieldFormat = ApplicationFieldFormat.MSWord;
			LoadSettings loadSettings2 = loadSettings;
			if (string_1 == null)
			{
				OpenFileDialog openFileDialog = new OpenFileDialog();
				openFileDialog.Filter = loadSettings2.GetFilterString(StreamType.All) + "|" + this.resourceManager_0.GetString("FILEFORMAT_ALL");
				if (openFileDialog.ShowDialog() == DialogResult.Cancel)
				{
					return;
				}
				string_1 = openFileDialog.FileName;
			}
			StreamType streamType = this.method_4(string_1);
			this.textControl_1.ResetContents();
			if (streamType != 0)
			{
				try
				{
					this.textControl_1.Load(string_1, streamType, loadSettings2);
				}
				catch
				{
				}
			}
			this.string_0 = string_1;
			this.TXITEM_SelectedFile.Enabled = true;
			if (!this.TXITEM_SelectedFile.Checked)
			{
				this.TXITEM_SelectedFile.Checked = true;
			}
			List<DocumentTarget> list_ = this.method_7(this.textControl_1);
			this.method_6(this.method_10(this.TXITEM_Hyperlink.Text, list_), list_, this.TXITEM_AutoGenerationBookmarks.Checked);
		}

		private StreamType method_4(string string_1)
		{
			switch (Path.GetExtension(string_1).ToLower())
			{
			case ".html":
			case ".htm":
				return StreamType.HTMLFormat;
			case ".tx":
				return StreamType.InternalUnicodeFormat;
			case ".docx":
				return StreamType.WordprocessingML;
			case ".doc":
				return StreamType.MSWord;
			case ".rtf":
				return StreamType.RichTextFormat;
			default:
				return (StreamType)0;
			}
		}

		private void method_5(int int_1, int int_2)
		{
			Selection selection = new Selection(int_1 - int_2, int_2);
			selection.Underline = FontUnderlineStyle.Single;
			selection.ForeColor = Color.Blue;
			this.textControl_0.Selection = selection;
			this.textControl_0.InputPosition = new InputPosition(int_1, TextFieldPosition.InsideTextField);
			this.textControl_0.InputPosition = new InputPosition(int_1, TextFieldPosition.OutsideTextField);
		}

		private void method_6(DocumentTarget documentTarget_0, List<DocumentTarget> list_1, bool bool_0)
		{
			bool flag = false;
			this.TXITEM_AutoGenerationBookmarks.Checked = bool_0 || (documentTarget_0 != null && documentTarget_0.AutoGenerationType == AutoGenerationType.TableOfContents);
			this.TXITEM_BookmarkList.Items.Clear();
			this.list_0.Clear();
			foreach (DocumentTarget item in list_1)
			{
				Class469 @class = new Class469(item);
				this.list_0.Add(@class);
				flag |= @class.Boolean_0;
				if (!@class.Boolean_0 || this.TXITEM_AutoGenerationBookmarks.Checked)
				{
					this.TXITEM_BookmarkList.Items.Add(@class);
				}
			}
			this.TXITEM_AutoGenerationBookmarks.Checked &= flag;
			this.TXITEM_AutoGenerationBookmarks.Enabled = flag;
		}

		private List<DocumentTarget> method_7(TextControl textControl_2)
		{
			try
			{
				List<DocumentTarget> list = new List<DocumentTarget>();
				foreach (DocumentTarget documentTarget in textControl_2.DocumentTargets)
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

		private void method_8()
		{
			if (!this.TXITEM_AutoGenerationBookmarks.Checked)
			{
				Class469 @class = this.TXITEM_BookmarkList.SelectedItem as Class469;
				if (@class != null && @class.Boolean_0 && this.TXITEM_Hyperlink.Text.EndsWith(@class.ToString()))
				{
					int num = this.TXITEM_Hyperlink.Text.LastIndexOf("#");
					if (num != -1)
					{
						this.TXITEM_Hyperlink.Text = this.TXITEM_Hyperlink.Text.Substring(0, num);
					}
				}
			}
			this.TXITEM_BookmarkList.Items.Clear();
			for (int i = 0; i < this.list_0.Count; i++)
			{
				Class469 class2 = this.list_0[i];
				if (!class2.Boolean_0 || this.TXITEM_AutoGenerationBookmarks.Checked)
				{
					this.TXITEM_BookmarkList.Items.Add(class2);
				}
			}
			this.TXITEM_BookmarkList.SelectedItem = this.method_9(this.TXITEM_Hyperlink.Text);
		}

		private Class469 method_9(string string_1)
		{
			int num = string_1.LastIndexOf("#");
			if (num != -1)
			{
				string text = string_1.Substring(num + 1);
				foreach (Class469 item in this.TXITEM_BookmarkList.Items)
				{
					if (item.ToString() == text)
					{
						return item;
					}
				}
			}
			return null;
		}

		private DocumentTarget method_10(string string_1, List<DocumentTarget> list_1)
		{
			int num = string_1.LastIndexOf("#");
			if (num != -1)
			{
				string text = string_1.Substring(num + 1);
				foreach (DocumentTarget item in list_1)
				{
					if (item.TargetName == text)
					{
						return item;
					}
				}
			}
			return null;
		}

		private void TXITEM_OK_Click(object sender, EventArgs e)
		{
			switch (this.int_0)
			{
			case 0:
			{
				string text = this.TXITEM_Hyperlink.Text;
				string text2 = this.TXITEM_HyperlinkText.Text;
				if (text.StartsWith("#"))
				{
					text = text.Remove(0, 1);
					Class469 @class;
					if ((@class = (Class469)this.TXITEM_BookmarkList.SelectedItem) == null)
					{
						break;
					}
					DocumentLink documentLink = new DocumentLink(text2, @class.DocumentTarget_0);
					documentLink.DoubledInputPosition = true;
					this.textControl_0.DocumentLinks.Add(documentLink);
				}
				else
				{
					HypertextLink item = new HypertextLink(text2, text);
					item.DoubledInputPosition = true;
					this.textControl_0.HypertextLinks.Add(item);
				}
				this.method_5(this.textControl_0.Selection.Start, text2.Length);
				break;
			}
			case 1:
			{
				DocumentLink documentLink;
				Class469 @class;
				if ((documentLink = this.textControl_0.DocumentLinks.GetItem()) != null && (@class = (Class469)this.TXITEM_BookmarkList.SelectedItem) != null)
				{
					documentLink.Text = this.TXITEM_HyperlinkText.Text;
					documentLink.DocumentTarget = @class.DocumentTarget_0;
				}
				break;
			}
			case 2:
			{
				HypertextLink item;
				if ((item = this.textControl_0.HypertextLinks.GetItem()) != null)
				{
					item.Text = this.TXITEM_HyperlinkText.Text;
					item.Target = this.TXITEM_Hyperlink.Text;
				}
				break;
			}
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		private void TXITEM_BookmarkList_SelectedIndexChanged(object sender, EventArgs e)
		{
			string text = (this.TXITEM_SelectedFile.Checked ? this.string_0 : string.Empty);
			if (this.TXITEM_BookmarkList.SelectedIndex >= 0)
			{
				text = text + "#" + ((Class469)this.TXITEM_BookmarkList.SelectedItem).DocumentTarget_0.TargetName;
			}
			this.TXITEM_Hyperlink.Text = text;
		}

		private void TXITEM_Hyperlink_TextChanged(object sender, EventArgs e)
		{
			this.TXITEM_OK.Enabled = this.TXITEM_Hyperlink.Text != string.Empty && this.TXITEM_HyperlinkText.Text != string.Empty;
			if (sender.Equals(this.TXITEM_Hyperlink) && this.TXITEM_Hyperlink.Text.ToLower() == "www.")
			{
				this.TXITEM_Hyperlink.Text = "http://www.";
				this.TXITEM_Hyperlink.SelectionStart = 11;
			}
		}

		private void TXITEM_CurrentDocument_CheckedChanged(object sender, EventArgs e)
		{
			if (this.textControl_0 != null && (sender as RadioButton).Checked)
			{
				this.method_6(this.textControl_0.DocumentLinks.GetItem()?.DocumentTarget, this.method_7(this.textControl_0), this.TXITEM_AutoGenerationBookmarks.Checked);
				this.TXITEM_Hyperlink.Text = string.Empty;
			}
		}

		private void TXITEM_SelectedFile_CheckedChanged(object sender, EventArgs e)
		{
			if (this.textControl_1 != null && (sender as RadioButton).Checked)
			{
				this.method_6(this.textControl_1.DocumentLinks.GetItem()?.DocumentTarget, this.method_7(this.textControl_1), this.TXITEM_AutoGenerationBookmarks.Checked);
				this.TXITEM_Hyperlink.Text = this.string_0;
			}
		}

		private void TXITEM_SelectFile_Click(object sender, EventArgs e)
		{
			this.method_3(null);
			this.TXITEM_Hyperlink.Text = this.string_0;
		}

		private void TXITEM_DeleteHyperlink_Click(object sender, EventArgs e)
		{
			switch (this.int_0)
			{
			case 1:
			{
				DocumentLink item2;
				if ((item2 = this.textControl_0.DocumentLinks.GetItem()) != null)
				{
					this.textControl_0.DocumentLinks.Remove(item2);
				}
				break;
			}
			case 2:
			{
				HypertextLink item;
				if ((item = this.textControl_0.HypertextLinks.GetItem()) != null)
				{
					this.textControl_0.HypertextLinks.Remove(item);
				}
				break;
			}
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		private void TXITEM_AutoGenerationBookmarks_CheckedChanged(object sender, EventArgs e)
		{
			this.method_8();
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
			this.TXITEM_DeleteHyperlink = new System.Windows.Forms.Button();
			this.TXITEM_HyperlinkTextLabel = new System.Windows.Forms.Label();
			this.TXITEM_HyperlinkText = new System.Windows.Forms.TextBox();
			this.TXITEM_HyperlinkLabel = new System.Windows.Forms.Label();
			this.TXITEM_AddressPanel = new System.Windows.Forms.TableLayoutPanel();
			this.TXITEM_Hyperlink = new System.Windows.Forms.TextBox();
			this.TXITEM_SelectFile = new System.Windows.Forms.Button();
			this.TXITEM_Cancel = new System.Windows.Forms.Button();
			this.TXITEM_SelectedFile = new System.Windows.Forms.RadioButton();
			this.TXITEM_BookmarkListLabel = new System.Windows.Forms.Label();
			this.TXITEM_CurrentDocument = new System.Windows.Forms.RadioButton();
			this.TXITEM_ShowBookmarks = new System.Windows.Forms.Label();
			this.TXITEM_OK = new System.Windows.Forms.Button();
			this.TXITEM_BookmarkList = new System.Windows.Forms.ListBox();
			this.TXITEM_MainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.TXITEM_BookmarksPanel = new System.Windows.Forms.TableLayoutPanel();
			this.TXITEM_AutoGenerationBookmarks = new System.Windows.Forms.CheckBox();
			this.TXITEM_AddressPanel.SuspendLayout();
			this.TXITEM_MainPanel.SuspendLayout();
			this.TXITEM_BookmarksPanel.SuspendLayout();
			base.SuspendLayout();
			this.TXITEM_DeleteHyperlink.AutoSize = true;
			this.TXITEM_DeleteHyperlink.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TXITEM_DeleteHyperlink.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_DeleteHyperlink.Location = new System.Drawing.Point(0, 241);
			this.TXITEM_DeleteHyperlink.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
			this.TXITEM_DeleteHyperlink.MinimumSize = new System.Drawing.Size(75, 23);
			this.TXITEM_DeleteHyperlink.Name = "TXITEM_DeleteHyperlink";
			this.TXITEM_DeleteHyperlink.Size = new System.Drawing.Size(95, 23);
			this.TXITEM_DeleteHyperlink.TabIndex = 10;
			this.TXITEM_DeleteHyperlink.Text = "Delete Hyperlink";
			this.TXITEM_DeleteHyperlink.UseVisualStyleBackColor = true;
			this.TXITEM_DeleteHyperlink.Click += new System.EventHandler(TXITEM_DeleteHyperlink_Click);
			this.TXITEM_HyperlinkTextLabel.AutoSize = true;
			this.TXITEM_MainPanel.SetColumnSpan(this.TXITEM_HyperlinkTextLabel, 4);
			this.TXITEM_HyperlinkTextLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_HyperlinkTextLabel.Location = new System.Drawing.Point(0, 0);
			this.TXITEM_HyperlinkTextLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.TXITEM_HyperlinkTextLabel.Name = "TXITEM_HyperlinkTextLabel";
			this.TXITEM_HyperlinkTextLabel.Size = new System.Drawing.Size(516, 13);
			this.TXITEM_HyperlinkTextLabel.TabIndex = 0;
			this.TXITEM_HyperlinkTextLabel.Text = "Text to display:";
			this.TXITEM_MainPanel.SetColumnSpan(this.TXITEM_HyperlinkText, 4);
			this.TXITEM_HyperlinkText.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TXITEM_HyperlinkText.Location = new System.Drawing.Point(0, 19);
			this.TXITEM_HyperlinkText.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.TXITEM_HyperlinkText.Name = "TXITEM_HyperlinkText";
			this.TXITEM_HyperlinkText.Size = new System.Drawing.Size(516, 20);
			this.TXITEM_HyperlinkText.TabIndex = 1;
			this.TXITEM_HyperlinkText.TextChanged += new System.EventHandler(TXITEM_Hyperlink_TextChanged);
			this.TXITEM_HyperlinkLabel.AutoSize = true;
			this.TXITEM_AddressPanel.SetColumnSpan(this.TXITEM_HyperlinkLabel, 2);
			this.TXITEM_HyperlinkLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_HyperlinkLabel.Location = new System.Drawing.Point(0, 0);
			this.TXITEM_HyperlinkLabel.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
			this.TXITEM_HyperlinkLabel.Name = "TXITEM_HyperlinkLabel";
			this.TXITEM_HyperlinkLabel.Size = new System.Drawing.Size(516, 13);
			this.TXITEM_HyperlinkLabel.TabIndex = 2;
			this.TXITEM_HyperlinkLabel.Text = "Address:";
			this.TXITEM_AddressPanel.AutoSize = true;
			this.TXITEM_AddressPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TXITEM_AddressPanel.ColumnCount = 2;
			this.TXITEM_MainPanel.SetColumnSpan(this.TXITEM_AddressPanel, 4);
			this.TXITEM_AddressPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.TXITEM_AddressPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TXITEM_AddressPanel.Controls.Add(this.TXITEM_Hyperlink, 0, 1);
			this.TXITEM_AddressPanel.Controls.Add(this.TXITEM_SelectFile, 1, 1);
			this.TXITEM_AddressPanel.Controls.Add(this.TXITEM_HyperlinkLabel, 0, 0);
			this.TXITEM_AddressPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TXITEM_AddressPanel.Location = new System.Drawing.Point(0, 42);
			this.TXITEM_AddressPanel.Margin = new System.Windows.Forms.Padding(0);
			this.TXITEM_AddressPanel.Name = "TXITEM_AddressPanel";
			this.TXITEM_AddressPanel.RowCount = 2;
			this.TXITEM_AddressPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_AddressPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_AddressPanel.Size = new System.Drawing.Size(516, 48);
			this.TXITEM_AddressPanel.TabIndex = 3;
			this.TXITEM_Hyperlink.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TXITEM_Hyperlink.Location = new System.Drawing.Point(0, 21);
			this.TXITEM_Hyperlink.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
			this.TXITEM_Hyperlink.Name = "TXITEM_Hyperlink";
			this.TXITEM_Hyperlink.Size = new System.Drawing.Size(434, 20);
			this.TXITEM_Hyperlink.TabIndex = 3;
			this.TXITEM_Hyperlink.TextChanged += new System.EventHandler(TXITEM_Hyperlink_TextChanged);
			this.TXITEM_SelectFile.AutoSize = true;
			this.TXITEM_SelectFile.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TXITEM_SelectFile.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_SelectFile.Location = new System.Drawing.Point(441, 18);
			this.TXITEM_SelectFile.Margin = new System.Windows.Forms.Padding(7, 0, 0, 7);
			this.TXITEM_SelectFile.MinimumSize = new System.Drawing.Size(75, 23);
			this.TXITEM_SelectFile.Name = "TXITEM_SelectFile";
			this.TXITEM_SelectFile.Size = new System.Drawing.Size(75, 23);
			this.TXITEM_SelectFile.TabIndex = 4;
			this.TXITEM_SelectFile.Text = "Select &file…";
			this.TXITEM_SelectFile.UseVisualStyleBackColor = true;
			this.TXITEM_SelectFile.Click += new System.EventHandler(TXITEM_SelectFile_Click);
			this.TXITEM_Cancel.AutoSize = true;
			this.TXITEM_Cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TXITEM_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.TXITEM_Cancel.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_Cancel.Location = new System.Drawing.Point(441, 241);
			this.TXITEM_Cancel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
			this.TXITEM_Cancel.MinimumSize = new System.Drawing.Size(75, 23);
			this.TXITEM_Cancel.Name = "TXITEM_Cancel";
			this.TXITEM_Cancel.Size = new System.Drawing.Size(75, 23);
			this.TXITEM_Cancel.TabIndex = 12;
			this.TXITEM_Cancel.Text = "&Cancel";
			this.TXITEM_Cancel.UseVisualStyleBackColor = true;
			this.TXITEM_SelectedFile.AutoSize = true;
			this.TXITEM_SelectedFile.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_SelectedFile.Enabled = false;
			this.TXITEM_SelectedFile.Location = new System.Drawing.Point(259, 45);
			this.TXITEM_SelectedFile.Margin = new System.Windows.Forms.Padding(6, 3, 0, 3);
			this.TXITEM_SelectedFile.Name = "TXITEM_SelectedFile";
			this.TXITEM_SelectedFile.Size = new System.Drawing.Size(257, 17);
			this.TXITEM_SelectedFile.TabIndex = 9;
			this.TXITEM_SelectedFile.Text = "S&elected file";
			this.TXITEM_SelectedFile.UseVisualStyleBackColor = true;
			this.TXITEM_BookmarkListLabel.AutoSize = true;
			this.TXITEM_BookmarkListLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_BookmarkListLabel.Location = new System.Drawing.Point(0, 3);
			this.TXITEM_BookmarkListLabel.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
			this.TXITEM_BookmarkListLabel.Name = "TXITEM_BookmarkListLabel";
			this.TXITEM_BookmarkListLabel.Size = new System.Drawing.Size(250, 13);
			this.TXITEM_BookmarkListLabel.TabIndex = 5;
			this.TXITEM_BookmarkListLabel.Text = "Bookmarks:";
			this.TXITEM_CurrentDocument.AutoSize = true;
			this.TXITEM_CurrentDocument.Checked = true;
			this.TXITEM_CurrentDocument.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_CurrentDocument.Location = new System.Drawing.Point(259, 22);
			this.TXITEM_CurrentDocument.Margin = new System.Windows.Forms.Padding(6, 3, 0, 3);
			this.TXITEM_CurrentDocument.Name = "TXITEM_CurrentDocument";
			this.TXITEM_CurrentDocument.Size = new System.Drawing.Size(257, 17);
			this.TXITEM_CurrentDocument.TabIndex = 8;
			this.TXITEM_CurrentDocument.TabStop = true;
			this.TXITEM_CurrentDocument.Text = "C&urrent document";
			this.TXITEM_CurrentDocument.UseVisualStyleBackColor = true;
			this.TXITEM_ShowBookmarks.AutoSize = true;
			this.TXITEM_ShowBookmarks.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_ShowBookmarks.Location = new System.Drawing.Point(259, 3);
			this.TXITEM_ShowBookmarks.Margin = new System.Windows.Forms.Padding(6, 3, 0, 3);
			this.TXITEM_ShowBookmarks.Name = "TXITEM_ShowBookmarks";
			this.TXITEM_ShowBookmarks.Size = new System.Drawing.Size(257, 13);
			this.TXITEM_ShowBookmarks.TabIndex = 7;
			this.TXITEM_ShowBookmarks.Text = "Show bookmarks in:";
			this.TXITEM_OK.AutoSize = true;
			this.TXITEM_OK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TXITEM_OK.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_OK.Enabled = false;
			this.TXITEM_OK.Location = new System.Drawing.Point(363, 241);
			this.TXITEM_OK.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
			this.TXITEM_OK.MinimumSize = new System.Drawing.Size(75, 23);
			this.TXITEM_OK.Name = "TXITEM_OK";
			this.TXITEM_OK.Size = new System.Drawing.Size(75, 23);
			this.TXITEM_OK.TabIndex = 11;
			this.TXITEM_OK.Text = "&OK";
			this.TXITEM_OK.UseVisualStyleBackColor = true;
			this.TXITEM_OK.Click += new System.EventHandler(TXITEM_OK_Click);
			this.TXITEM_BookmarkList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TXITEM_BookmarkList.FormattingEnabled = true;
			this.TXITEM_BookmarkList.Location = new System.Drawing.Point(0, 19);
			this.TXITEM_BookmarkList.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
			this.TXITEM_BookmarkList.MinimumSize = new System.Drawing.Size(250, 95);
			this.TXITEM_BookmarkList.Name = "TXITEM_BookmarkList";
			this.TXITEM_BookmarksPanel.SetRowSpan(this.TXITEM_BookmarkList, 3);
			this.TXITEM_BookmarkList.Size = new System.Drawing.Size(250, 96);
			this.TXITEM_BookmarkList.TabIndex = 6;
			this.TXITEM_BookmarkList.SelectedIndexChanged += new System.EventHandler(TXITEM_BookmarkList_SelectedIndexChanged);
			this.TXITEM_MainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TXITEM_MainPanel.ColumnCount = 4;
			this.TXITEM_MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TXITEM_MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.TXITEM_MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TXITEM_MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_DeleteHyperlink, 0, 4);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_OK, 2, 4);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_Cancel, 3, 4);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_HyperlinkTextLabel, 0, 0);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_HyperlinkText, 0, 1);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_AddressPanel, 0, 2);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_BookmarksPanel, 0, 3);
			this.TXITEM_MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TXITEM_MainPanel.Location = new System.Drawing.Point(7, 7);
			this.TXITEM_MainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.TXITEM_MainPanel.Name = "TXITEM_MainPanel";
			this.TXITEM_MainPanel.RowCount = 5;
			this.TXITEM_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_MainPanel.Size = new System.Drawing.Size(516, 312);
			this.TXITEM_MainPanel.TabIndex = 1;
			this.TXITEM_BookmarksPanel.AutoSize = true;
			this.TXITEM_BookmarksPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TXITEM_BookmarksPanel.ColumnCount = 2;
			this.TXITEM_MainPanel.SetColumnSpan(this.TXITEM_BookmarksPanel, 4);
			this.TXITEM_BookmarksPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TXITEM_BookmarksPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TXITEM_BookmarksPanel.Controls.Add(this.TXITEM_AutoGenerationBookmarks, 0, 4);
			this.TXITEM_BookmarksPanel.Controls.Add(this.TXITEM_SelectedFile, 1, 2);
			this.TXITEM_BookmarksPanel.Controls.Add(this.TXITEM_CurrentDocument, 1, 1);
			this.TXITEM_BookmarksPanel.Controls.Add(this.TXITEM_ShowBookmarks, 1, 0);
			this.TXITEM_BookmarksPanel.Controls.Add(this.TXITEM_BookmarkListLabel, 0, 0);
			this.TXITEM_BookmarksPanel.Controls.Add(this.TXITEM_BookmarkList, 0, 1);
			this.TXITEM_BookmarksPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TXITEM_BookmarksPanel.Location = new System.Drawing.Point(0, 90);
			this.TXITEM_BookmarksPanel.Margin = new System.Windows.Forms.Padding(0);
			this.TXITEM_BookmarksPanel.Name = "TXITEM_BookmarksPanel";
			this.TXITEM_BookmarksPanel.RowCount = 5;
			this.TXITEM_BookmarksPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_BookmarksPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_BookmarksPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_BookmarksPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.TXITEM_BookmarksPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_BookmarksPanel.Size = new System.Drawing.Size(516, 148);
			this.TXITEM_BookmarksPanel.TabIndex = 13;
			this.TXITEM_AutoGenerationBookmarks.AutoSize = true;
			this.TXITEM_AutoGenerationBookmarks.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_AutoGenerationBookmarks.Location = new System.Drawing.Point(0, 118);
			this.TXITEM_AutoGenerationBookmarks.Margin = new System.Windows.Forms.Padding(0, 0, 0, 13);
			this.TXITEM_AutoGenerationBookmarks.Name = "TXITEM_AutoGenerationBookmarks";
			this.TXITEM_AutoGenerationBookmarks.Size = new System.Drawing.Size(253, 17);
			this.TXITEM_AutoGenerationBookmarks.TabIndex = 10;
			this.TXITEM_AutoGenerationBookmarks.Text = "Automatically generated bookmarks";
			this.TXITEM_AutoGenerationBookmarks.UseVisualStyleBackColor = true;
			this.TXITEM_AutoGenerationBookmarks.CheckedChanged += new System.EventHandler(TXITEM_AutoGenerationBookmarks_CheckedChanged);
			base.AcceptButton = this.TXITEM_OK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			base.CancelButton = this.TXITEM_Cancel;
			base.ClientSize = new System.Drawing.Size(530, 326);
			base.Controls.Add(this.TXITEM_MainPanel);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "HyperlinkDialog";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Insert Hyperlink";
			this.TXITEM_AddressPanel.ResumeLayout(false);
			this.TXITEM_AddressPanel.PerformLayout();
			this.TXITEM_MainPanel.ResumeLayout(false);
			this.TXITEM_MainPanel.PerformLayout();
			this.TXITEM_BookmarksPanel.ResumeLayout(false);
			this.TXITEM_BookmarksPanel.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
