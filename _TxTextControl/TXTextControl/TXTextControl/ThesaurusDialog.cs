using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ns21;
using ns23;
using ns27;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl
{
	/// <summary>The ThesaurusDialog class implements a Windows Forms dialog box that shows synonyms for selected text or a word at the current input position which will be selected on opening the dialog.Each item of the dialog box has a name, available through its Name property, which corresponds with a member of the ThesaurusDialog.DialogItem enumeration.To use this dialog the TextControl must be connected with an object of type TXSpellChecker (version 7.0 or higher).</summary>
	public class ThesaurusDialog : Form
	{
		/// <summary>Each DialogItem represents an item in a ThesaurusDialog dialog box.</summary>
		public enum DialogItem
		{
			/// <summary>Identifies the Find Synonyms label.</summary>
			TXITEM_FindSynonymsLabel,
			/// <summary>Identifies the Language label.</summary>
			TXITEM_LanguageLabel,
			/// <summary>Identifies the Back button.</summary>
			TXITEM_BackButton,
			/// <summary>Identifies the Find Synonyms text box.</summary>
			TXITEM_FindSynonymsTextBox,
			/// <summary>Identifies the Language combo box.</summary>
			TXITEM_LanguageComboBox,
			/// <summary>Identifies the Synonyms label.</summary>
			TXITEM_SynonymsLabel,
			/// <summary>Identifies the Synonyms tree view.</summary>
			TXITEM_SynonymsTree,
			/// <summary>Identifies the Replace button.</summary>
			TXITEM_Replace,
			/// <summary>Identifies the Cancel button.</summary>
			TXITEM_Cancel
		}

		private class Class597 : IEquatable<Class597>
		{
			private object object_0;

			private CultureInfo cultureInfo_0;

			private string string_0;

			private bool bool_0;

			internal CultureInfo CultureInfo_0 => this.cultureInfo_0;

			internal bool Boolean_0 => this.bool_0;

			internal string String_0 => this.string_0;

			internal object Object_0 => this.object_0;

			internal Class597(object object_1, Class415 class415_0)
			{
				this.object_0 = object_1;
				this.cultureInfo_0 = class415_0.method_54(object_1);
				this.string_0 = ((this.cultureInfo_0 != null) ? this.cultureInfo_0.DisplayName : class415_0.method_55(object_1));
				this.bool_0 = class415_0.method_53(object_1);
			}

			public override string ToString()
			{
				return this.string_0;
			}

			public override bool Equals(object obj)
			{
				return obj.ToString().Equals(this.string_0);
			}

			public override int GetHashCode()
			{
				return base.GetHashCode();
			}

			public bool Equals(Class597 other)
			{
				return other.string_0 == this.string_0;
			}
		}

		private class Class598
		{
			private string string_0;

			private Class597 class597_0;

			internal string String_0 => this.string_0;

			internal Class597 Class597_0 => this.class597_0;

			internal Class598(string string_1, Class597 class597_1)
			{
				this.string_0 = string_1;
				this.class597_0 = class597_1;
			}
		}

		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private TextControl textControl_0;

		private Class415 class415_0;

		private List<Class598> list_0 = new List<Class598>();

		private Class598 class598_0;

		private Regex regex_0 = new Regex("(\\S|((?<=\\S)\\s+\\S))+");

		private Match match_0;

		private Bitmap bitmap_0;

		private Bitmap bitmap_1;

		private ImageAttributes imageAttributes_0;

		private uint uint_0;

		private IContainer icontainer_0;

		private TableLayoutPanel TXITEM_MainPanel;

		private TableLayoutPanel TXITEM_TopPanel;

		public ComboBox TXITEM_LanguageComboBox;

		public Label TXITEM_LanguageLabel;

		public Label TXITEM_FindSynonymsLabel;

		public TextBox TXITEM_FindSynonymsTextBox;

		public System.Windows.Forms.Button TXITEM_Replace;

		public System.Windows.Forms.Button TXITEM_Cancel;

		public Label TXITEM_SynonymsLabel;

		public TreeView TXITEM_SynonymsTree;

		public System.Windows.Forms.Button TXITEM_BackButton;

		[CompilerGenerated]
		private bool bool_0;

		internal bool Boolean_0
		{
			[CompilerGenerated]
			get
			{
				return this.bool_0;
			}
			[CompilerGenerated]
			set
			{
				this.bool_0 = value;
			}
		}

		/// <summary>Creates a ThesaurusDialog object for the specified Windows Forms TextControl.</summary>
		/// <param name="textControl">Specifies the TextControl for which the dialog box is opened.</param>
		public ThesaurusDialog(TextControl textControl)
		{
			if (textControl == null)
			{
				throw new NullReferenceException();
			}
			this.textControl_0 = textControl;
			this.InitializeComponent();
			this.Text = this.resourceManager_0.GetString("ID_THESAURUSDIALOG_CAPTION");
			this.TXITEM_FindSynonymsLabel.Text = this.resourceManager_0.GetString("ID_THESAURUSDIALOG_FIND_SYNONYMS");
			this.TXITEM_LanguageLabel.Text = this.resourceManager_0.GetString("ID_THESAURUSDIALOG_LANGUAGE");
			this.TXITEM_SynonymsLabel.Text = this.resourceManager_0.GetString("ID_THESAURUSDIALOG_SYNONYMS");
			this.TXITEM_Cancel.Text = this.resourceManager_0.GetString("ID_THESAURUSDIALOG_CANCEL");
			this.imageAttributes_0 = Class517.smethod_20(65);
			this.TXITEM_BackButton.BackgroundImage = this.bitmap_1;
		}

		public Control FindItem(DialogItem dialogItem)
		{
			return this.method_0(dialogItem, this);
		}

		protected override void OnClosed(EventArgs eventArgs_0)
		{
			this.match_0 = null;
			this.TXITEM_FindSynonymsTextBox.Text = "";
			this.TXITEM_LanguageComboBox.Items.Clear();
			this.TXITEM_SynonymsTree.Nodes.Clear();
			this.list_0.Clear();
			base.OnClosed(eventArgs_0);
		}

		public new void Show()
		{
			if (!this.method_2())
			{
				base.DialogResult = DialogResult.Abort;
				base.Close();
			}
			else
			{
				base.ShowDialog();
			}
		}

		public new void Show(IWin32Window owner)
		{
			if (!this.method_2())
			{
				base.DialogResult = DialogResult.Abort;
				base.Close();
			}
			else
			{
				base.Show(owner);
			}
		}

		public new DialogResult ShowDialog()
		{
			if (!this.method_2())
			{
				base.DialogResult = DialogResult.Abort;
				base.Close();
				return base.DialogResult;
			}
			return base.ShowDialog();
		}

		public new DialogResult ShowDialog(IWin32Window owner)
		{
			if (!this.method_2())
			{
				base.DialogResult = DialogResult.Abort;
				base.Close();
				return base.DialogResult;
			}
			return base.ShowDialog(owner);
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			Graphics graphics = base.CreateGraphics();
			this.uint_0 = Class468.smethod_0(graphics, this);
			PointF pointF_ = ((this.uint_0 == 0) ? new PointF(graphics.DpiX, graphics.DpiY) : new PointF(this.uint_0, this.uint_0));
			this.method_4(pointF_);
			graphics.Dispose();
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
					this.method_4(new PointF(this.uint_0, this.uint_0));
					Class468.smethod_1(this.uint_0, struct83_, this);
				}
			}
			else
			{
				base.WndProc(ref message);
			}
		}

		private void TXITEM_BackButton_Click(object sender, EventArgs e)
		{
			if (this.list_0.Count > 0)
			{
				int index = this.list_0.Count - 1;
				this.TXITEM_FindSynonymsTextBox.Text = this.list_0[index].String_0;
				this.TXITEM_LanguageComboBox.SelectedItem = this.list_0[index].Class597_0;
				this.list_0.RemoveAt(index);
			}
			this.TXITEM_BackButton.Enabled = this.list_0.Count > 0;
		}

		private void TXITEM_BackButton_EnabledChanged(object sender, EventArgs e)
		{
			this.TXITEM_BackButton.BackgroundImage = (this.TXITEM_BackButton.Enabled ? this.bitmap_0 : this.bitmap_1);
		}

		private void TXITEM_FindSynonymsTextBox_TextChanged(object sender, EventArgs e)
		{
			this.method_5();
		}

		private void TXITEM_LanguageComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.method_5();
		}

		private void TXITEM_SynonymsTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			this.method_7(e.Node);
			this.TXITEM_FindSynonymsTextBox.Focus();
			this.TXITEM_FindSynonymsTextBox.Select(this.TXITEM_FindSynonymsTextBox.TextLength, 0);
		}

		private void TXITEM_SynonymsTree_KeyDown(object sender, KeyEventArgs e)
		{
			if (this.TXITEM_SynonymsTree.SelectedNode != null)
			{
				switch (e.KeyData)
				{
				case Keys.Space:
					this.method_7(this.TXITEM_SynonymsTree.SelectedNode);
					break;
				case Keys.Return:
					this.textControl_0.Selection.Text = this.TXITEM_SynonymsTree.SelectedNode.Tag as string;
					base.Close();
					break;
				}
			}
		}

		private void TXITEM_SynonymsTree_BeforeSelect(object sender, TreeViewCancelEventArgs e)
		{
			if (this.TXITEM_SynonymsTree.SelectedNode != null && this.TXITEM_SynonymsTree.SelectedNode.Tag != null)
			{
				this.TXITEM_SynonymsTree.SelectedNode.BackColor = this.TXITEM_SynonymsTree.BackColor;
				this.TXITEM_SynonymsTree.SelectedNode.ForeColor = this.TXITEM_SynonymsTree.ForeColor;
			}
		}

		private void TXITEM_SynonymsTree_AfterSelect(object sender, TreeViewEventArgs e)
		{
			if (this.TXITEM_SynonymsTree.SelectedNode != null && this.TXITEM_SynonymsTree.SelectedNode.Tag != null)
			{
				this.TXITEM_SynonymsTree.SelectedNode.BackColor = SystemColors.Highlight;
				this.TXITEM_SynonymsTree.SelectedNode.ForeColor = Color.White;
			}
		}

		private void TXITEM_Replace_Click(object sender, EventArgs e)
		{
			if (this.match_0 != null)
			{
				int start = this.textControl_0.Selection.Start + this.match_0.Index;
				int length = this.match_0.Length;
				this.textControl_0.Selection = new Selection(start, length);
			}
			this.textControl_0.Selection.Text = this.TXITEM_SynonymsTree.SelectedNode.Tag as string;
			base.Close();
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

		private Bitmap method_1(Bitmap bitmap_2)
		{
			Bitmap bitmap = new Bitmap(bitmap_2.Width, bitmap_2.Height);
			Graphics.FromImage(bitmap).DrawImage(bitmap_2, new Rectangle(0, 0, bitmap.Width, bitmap.Height), 0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, this.imageAttributes_0);
			return bitmap;
		}

		private bool method_2()
		{
			this.method_3(this.textControl_0);
			this.RightToLeft = this.textControl_0.RightToLeft;
			if (this.textControl_0.Selection.Length == 0)
			{
				this.textControl_0.SelectWord();
			}
			if (this.Boolean_0 && !this.textControl_0.CanEdit)
			{
				return false;
			}
			if (this.textControl_0.Selection.Length > 0)
			{
				this.match_0 = this.regex_0.Match(this.textControl_0.Selection.Text);
				this.TXITEM_FindSynonymsTextBox.Text = this.match_0.Value;
			}
			Rectangle rectangle_;
			if (this.textControl_0.TextChars.Count != 0 && this.textControl_0.TextChars.Count >= this.textControl_0.Selection.Start + 1)
			{
				rectangle_ = this.textControl_0.TextChars[this.textControl_0.Selection.Start + 1].Bounds;
			}
			else
			{
				Line item = this.textControl_0.Lines.GetItem(this.textControl_0.InputPosition.TextPosition);
				rectangle_ = new Rectangle(item.TextBounds.Right, item.TextBounds.Top, 0, item.TextBounds.Height);
			}
			base.Location = Class517.smethod_36(base.Size, rectangle_, this.textControl_0);
			if (this.textControl_0.Selection.Culture != null)
			{
				this.class415_0.method_10(this.TXITEM_FindSynonymsTextBox.Text, this.textControl_0.Selection.Culture);
			}
			this.method_6();
			this.TXITEM_Replace.Text = ((this.TXITEM_FindSynonymsTextBox.Text.Length == 0) ? this.resourceManager_0.GetString("ID_THESAURUSDIALOG_INSERT") : this.resourceManager_0.GetString("ID_THESAURUSDIALOG_REPLACE"));
			this.TXITEM_FindSynonymsTextBox.Select(this.TXITEM_FindSynonymsTextBox.TextLength, 0);
			return true;
		}

		private void method_3(TextControl textControl_1)
		{
			if (textControl_1.SpellChecker == null)
			{
				throw new ArgumentException(this.resourceManager_0.GetString("ERR_NOTXSPELLCHECKER"));
			}
			this.class415_0 = new Class415(textControl_1.SpellChecker);
			if (this.class415_0.method_38() < 7)
			{
				throw new ArgumentException(string.Format(this.resourceManager_0.GetString("ERR_INVALIDTXSPELLCHECKERVERSION"), 7.0));
			}
			if (this.class415_0.Boolean_0 && this.class415_0.CollectionBase_4.Count == 0)
			{
				this.class415_0.String_0 = "(Auto)";
			}
		}

		private void method_4(PointF pointF_0)
		{
			this.bitmap_0 = Class517.smethod_53(this.TXITEM_BackButton.Name, ImageProvider.ImageKind.Small_16x16, pointF_0);
			this.bitmap_1 = this.method_1(this.bitmap_0);
			this.TXITEM_BackButton.BackgroundImage = (this.TXITEM_BackButton.Enabled ? this.bitmap_0 : this.bitmap_1);
		}

		private void method_5()
		{
			this.TXITEM_SynonymsTree.Nodes.Clear();
			if (this.TXITEM_LanguageComboBox.SelectedItem == null)
			{
				return;
			}
			CultureInfo cultureInfo_ = (this.TXITEM_LanguageComboBox.SelectedItem as Class597).CultureInfo_0;
			object[] array = ((cultureInfo_ == null) ? this.class415_0.method_11(this.TXITEM_FindSynonymsTextBox.Text, (this.TXITEM_LanguageComboBox.SelectedItem as Class597).Object_0) : this.class415_0.method_10(this.TXITEM_FindSynonymsTextBox.Text, cultureInfo_));
			if (array.Length > 0)
			{
				for (int i = 0; i < array.Length; i++)
				{
					object object_ = array[i];
					string text = this.class415_0.method_48(object_);
					text = ((text != null) ? text : "-");
					object[] array2 = this.class415_0.method_49(object_);
					TreeNode treeNode = new TreeNode(i + 1 + ". " + text + " " + this.class415_0.method_51(array2[0]));
					treeNode.Tag = this.class415_0.method_50(array2[0]);
					object[] array3 = array2;
					foreach (object object_2 in array3)
					{
						TreeNode treeNode2 = new TreeNode(this.class415_0.method_51(object_2));
						treeNode2.Tag = this.class415_0.method_50(object_2);
						treeNode.Nodes.Add(treeNode2);
					}
					this.TXITEM_SynonymsTree.Nodes.Add(treeNode);
					treeNode.Expand();
				}
			}
			else
			{
				this.TXITEM_SynonymsTree.Nodes.Add(this.resourceManager_0.GetString("ID_THESAURUSDIALOG_NO_ALTERNATIVES_MSG1"));
			}
			this.TXITEM_SynonymsTree.SelectedNode = this.TXITEM_SynonymsTree.Nodes[0];
			this.TXITEM_Replace.Enabled = this.TXITEM_SynonymsTree.SelectedNode.Tag != null;
		}

		private void method_6()
		{
			Class597 selectedItem = null;
			foreach (object item in this.class415_0.CollectionBase_4)
			{
				if (!this.class415_0.method_52(item))
				{
					continue;
				}
				Class597 @class = new Class597(item, this.class415_0);
				if (@class.CultureInfo_0 != null)
				{
					if (!this.TXITEM_LanguageComboBox.Items.Contains(@class.String_0))
					{
						this.TXITEM_LanguageComboBox.Items.Add(@class);
						if (this.textControl_0.Selection.Culture != null && this.textControl_0.Selection.Culture.LCID == @class.CultureInfo_0.LCID)
						{
							this.TXITEM_LanguageComboBox.SelectedItem = @class;
						}
					}
				}
				else
				{
					this.TXITEM_LanguageComboBox.Items.Add(@class);
				}
				if (@class.Boolean_0)
				{
					selectedItem = @class;
				}
			}
			if (this.TXITEM_LanguageComboBox.SelectedItem == null)
			{
				this.TXITEM_LanguageComboBox.SelectedItem = selectedItem;
			}
			if (this.TXITEM_LanguageComboBox.SelectedItem == null && this.TXITEM_LanguageComboBox.Items.Count > 0)
			{
				this.TXITEM_LanguageComboBox.SelectedItem = this.TXITEM_LanguageComboBox.Items[0];
			}
		}

		private void method_7(TreeNode treeNode_0)
		{
			if (treeNode_0.Tag != null)
			{
				this.class598_0 = new Class598(this.TXITEM_FindSynonymsTextBox.Text, this.TXITEM_LanguageComboBox.SelectedItem as Class597);
				this.TXITEM_FindSynonymsTextBox.Text = treeNode_0.Tag as string;
				this.list_0.Add(this.class598_0);
				this.TXITEM_BackButton.Enabled = true;
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
			this.TXITEM_MainPanel = new System.Windows.Forms.TableLayoutPanel();
			this.TXITEM_BackButton = new System.Windows.Forms.Button();
			this.TXITEM_Replace = new System.Windows.Forms.Button();
			this.TXITEM_TopPanel = new System.Windows.Forms.TableLayoutPanel();
			this.TXITEM_LanguageComboBox = new System.Windows.Forms.ComboBox();
			this.TXITEM_LanguageLabel = new System.Windows.Forms.Label();
			this.TXITEM_FindSynonymsLabel = new System.Windows.Forms.Label();
			this.TXITEM_FindSynonymsTextBox = new System.Windows.Forms.TextBox();
			this.TXITEM_Cancel = new System.Windows.Forms.Button();
			this.TXITEM_SynonymsLabel = new System.Windows.Forms.Label();
			this.TXITEM_SynonymsTree = new System.Windows.Forms.TreeView();
			this.TXITEM_MainPanel.SuspendLayout();
			this.TXITEM_TopPanel.SuspendLayout();
			base.SuspendLayout();
			this.TXITEM_MainPanel.AutoSize = true;
			this.TXITEM_MainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TXITEM_MainPanel.ColumnCount = 4;
			this.TXITEM_MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TXITEM_MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.TXITEM_MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TXITEM_MainPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_BackButton, 0, 1);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_Replace, 2, 4);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_TopPanel, 1, 0);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_Cancel, 3, 4);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_SynonymsLabel, 0, 2);
			this.TXITEM_MainPanel.Controls.Add(this.TXITEM_SynonymsTree, 0, 3);
			this.TXITEM_MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TXITEM_MainPanel.Location = new System.Drawing.Point(14, 13);
			this.TXITEM_MainPanel.Margin = new System.Windows.Forms.Padding(0);
			this.TXITEM_MainPanel.Name = "TXITEM_MainPanel";
			this.TXITEM_MainPanel.RowCount = 5;
			this.TXITEM_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.TXITEM_MainPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_MainPanel.Size = new System.Drawing.Size(522, 562);
			this.TXITEM_MainPanel.TabIndex = 1;
			this.TXITEM_MainPanel.TabStop = true;
			this.TXITEM_BackButton.AutoSize = true;
			this.TXITEM_BackButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.TXITEM_BackButton.Dock = System.Windows.Forms.DockStyle.Left;
			this.TXITEM_BackButton.Enabled = false;
			this.TXITEM_BackButton.Location = new System.Drawing.Point(0, 49);
			this.TXITEM_BackButton.Margin = new System.Windows.Forms.Padding(0, 0, 6, 6);
			this.TXITEM_BackButton.Name = "TXITEM_BackButton";
			this.TXITEM_BackButton.Size = new System.Drawing.Size(42, 40);
			this.TXITEM_BackButton.TabIndex = 5;
			this.TXITEM_BackButton.UseVisualStyleBackColor = true;
			this.TXITEM_BackButton.EnabledChanged += new System.EventHandler(TXITEM_BackButton_EnabledChanged);
			this.TXITEM_BackButton.Click += new System.EventHandler(TXITEM_BackButton_Click);
			this.TXITEM_Replace.AutoSize = true;
			this.TXITEM_Replace.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TXITEM_Replace.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_Replace.Enabled = false;
			this.TXITEM_Replace.Location = new System.Drawing.Point(210, 518);
			this.TXITEM_Replace.Margin = new System.Windows.Forms.Padding(6, 6, 6, 0);
			this.TXITEM_Replace.MinimumSize = new System.Drawing.Size(150, 44);
			this.TXITEM_Replace.Name = "TXITEM_Replace";
			this.TXITEM_Replace.Size = new System.Drawing.Size(150, 44);
			this.TXITEM_Replace.TabIndex = 2;
			this.TXITEM_Replace.Text = "Replace";
			this.TXITEM_Replace.UseVisualStyleBackColor = true;
			this.TXITEM_Replace.Click += new System.EventHandler(TXITEM_Replace_Click);
			this.TXITEM_TopPanel.AutoSize = true;
			this.TXITEM_TopPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TXITEM_TopPanel.ColumnCount = 3;
			this.TXITEM_MainPanel.SetColumnSpan(this.TXITEM_TopPanel, 3);
			this.TXITEM_TopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TXITEM_TopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.TXITEM_TopPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.TXITEM_TopPanel.Controls.Add(this.TXITEM_LanguageComboBox, 2, 1);
			this.TXITEM_TopPanel.Controls.Add(this.TXITEM_LanguageLabel, 2, 0);
			this.TXITEM_TopPanel.Controls.Add(this.TXITEM_FindSynonymsLabel, 1, 0);
			this.TXITEM_TopPanel.Controls.Add(this.TXITEM_FindSynonymsTextBox, 1, 1);
			this.TXITEM_TopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TXITEM_TopPanel.Location = new System.Drawing.Point(48, 0);
			this.TXITEM_TopPanel.Margin = new System.Windows.Forms.Padding(0);
			this.TXITEM_TopPanel.Name = "TXITEM_TopPanel";
			this.TXITEM_TopPanel.RowCount = 2;
			this.TXITEM_MainPanel.SetRowSpan(this.TXITEM_TopPanel, 2);
			this.TXITEM_TopPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_TopPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.TXITEM_TopPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38f));
			this.TXITEM_TopPanel.Size = new System.Drawing.Size(474, 95);
			this.TXITEM_TopPanel.TabIndex = 0;
			this.TXITEM_TopPanel.TabStop = true;
			this.TXITEM_LanguageComboBox.Dock = System.Windows.Forms.DockStyle.Right;
			this.TXITEM_LanguageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.TXITEM_LanguageComboBox.FormattingEnabled = true;
			this.TXITEM_LanguageComboBox.Location = new System.Drawing.Point(188, 56);
			this.TXITEM_LanguageComboBox.Margin = new System.Windows.Forms.Padding(6, 0, 0, 6);
			this.TXITEM_LanguageComboBox.MinimumSize = new System.Drawing.Size(286, 0);
			this.TXITEM_LanguageComboBox.Name = "TXITEM_LanguageComboBox";
			this.TXITEM_LanguageComboBox.Size = new System.Drawing.Size(286, 33);
			this.TXITEM_LanguageComboBox.TabIndex = 3;
			this.TXITEM_LanguageComboBox.SelectedIndexChanged += new System.EventHandler(TXITEM_LanguageComboBox_SelectedIndexChanged);
			this.TXITEM_LanguageLabel.AutoSize = true;
			this.TXITEM_LanguageLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_LanguageLabel.Location = new System.Drawing.Point(188, 0);
			this.TXITEM_LanguageLabel.Margin = new System.Windows.Forms.Padding(6, 0, 0, 6);
			this.TXITEM_LanguageLabel.Name = "TXITEM_LanguageLabel";
			this.TXITEM_LanguageLabel.Size = new System.Drawing.Size(286, 25);
			this.TXITEM_LanguageLabel.TabIndex = 2;
			this.TXITEM_LanguageLabel.Text = "Language:";
			this.TXITEM_FindSynonymsLabel.AutoSize = true;
			this.TXITEM_FindSynonymsLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_FindSynonymsLabel.Location = new System.Drawing.Point(0, 0);
			this.TXITEM_FindSynonymsLabel.Margin = new System.Windows.Forms.Padding(0, 0, 6, 6);
			this.TXITEM_FindSynonymsLabel.Name = "TXITEM_FindSynonymsLabel";
			this.TXITEM_FindSynonymsLabel.Size = new System.Drawing.Size(176, 50);
			this.TXITEM_FindSynonymsLabel.TabIndex = 0;
			this.TXITEM_FindSynonymsLabel.Text = "Find Synonyms for:";
			this.TXITEM_FindSynonymsTextBox.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_FindSynonymsTextBox.Location = new System.Drawing.Point(0, 56);
			this.TXITEM_FindSynonymsTextBox.Margin = new System.Windows.Forms.Padding(0, 0, 6, 6);
			this.TXITEM_FindSynonymsTextBox.Name = "TXITEM_FindSynonymsTextBox";
			this.TXITEM_FindSynonymsTextBox.Size = new System.Drawing.Size(176, 31);
			this.TXITEM_FindSynonymsTextBox.TabIndex = 1;
			this.TXITEM_FindSynonymsTextBox.TextChanged += new System.EventHandler(TXITEM_FindSynonymsTextBox_TextChanged);
			this.TXITEM_Cancel.AutoSize = true;
			this.TXITEM_Cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.TXITEM_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.TXITEM_Cancel.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_Cancel.Location = new System.Drawing.Point(372, 518);
			this.TXITEM_Cancel.Margin = new System.Windows.Forms.Padding(6, 6, 0, 0);
			this.TXITEM_Cancel.MinimumSize = new System.Drawing.Size(150, 44);
			this.TXITEM_Cancel.Name = "TXITEM_Cancel";
			this.TXITEM_Cancel.Size = new System.Drawing.Size(150, 44);
			this.TXITEM_Cancel.TabIndex = 4;
			this.TXITEM_Cancel.Text = "Cancel";
			this.TXITEM_Cancel.UseVisualStyleBackColor = true;
			this.TXITEM_SynonymsLabel.AutoSize = true;
			this.TXITEM_MainPanel.SetColumnSpan(this.TXITEM_SynonymsLabel, 4);
			this.TXITEM_SynonymsLabel.Dock = System.Windows.Forms.DockStyle.Top;
			this.TXITEM_SynonymsLabel.Location = new System.Drawing.Point(0, 101);
			this.TXITEM_SynonymsLabel.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
			this.TXITEM_SynonymsLabel.Name = "TXITEM_SynonymsLabel";
			this.TXITEM_SynonymsLabel.Size = new System.Drawing.Size(522, 25);
			this.TXITEM_SynonymsLabel.TabIndex = 0;
			this.TXITEM_SynonymsLabel.Text = "Synonyms:";
			this.TXITEM_MainPanel.SetColumnSpan(this.TXITEM_SynonymsTree, 4);
			this.TXITEM_SynonymsTree.Dock = System.Windows.Forms.DockStyle.Fill;
			this.TXITEM_SynonymsTree.Location = new System.Drawing.Point(0, 138);
			this.TXITEM_SynonymsTree.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
			this.TXITEM_SynonymsTree.MinimumSize = new System.Drawing.Size(566, 477);
			this.TXITEM_SynonymsTree.Name = "TXITEM_SynonymsTree";
			this.TXITEM_SynonymsTree.ShowLines = false;
			this.TXITEM_SynonymsTree.ShowPlusMinus = false;
			this.TXITEM_SynonymsTree.ShowRootLines = false;
			this.TXITEM_SynonymsTree.Size = new System.Drawing.Size(566, 477);
			this.TXITEM_SynonymsTree.TabIndex = 1;
			this.TXITEM_SynonymsTree.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(TXITEM_SynonymsTree_BeforeSelect);
			this.TXITEM_SynonymsTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(TXITEM_SynonymsTree_AfterSelect);
			this.TXITEM_SynonymsTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(TXITEM_SynonymsTree_NodeMouseDoubleClick);
			this.TXITEM_SynonymsTree.KeyDown += new System.Windows.Forms.KeyEventHandler(TXITEM_SynonymsTree_KeyDown);
			base.AcceptButton = this.TXITEM_Replace;
			base.AutoScaleDimensions = new System.Drawing.SizeF(12f, 25f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.TXITEM_Cancel;
			base.ClientSize = new System.Drawing.Size(550, 588);
			base.Controls.Add(this.TXITEM_MainPanel);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ThesaurusDialog";
			base.Padding = new System.Windows.Forms.Padding(14, 13, 14, 13);
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Thesaurus Dialog";
			this.TXITEM_MainPanel.ResumeLayout(false);
			this.TXITEM_MainPanel.PerformLayout();
			this.TXITEM_TopPanel.ResumeLayout(false);
			this.TXITEM_TopPanel.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
