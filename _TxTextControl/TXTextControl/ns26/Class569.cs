using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;
using TXTextControl;
using TXTextControl.Windows.Forms;

namespace ns26
{
	internal class Class569 : ContentPanel
	{
		internal class Class576 : TextBox
		{
			private string string_0;

			private bool bool_0 = true;

			internal bool Boolean_0 => this.bool_0;

			internal Class576(string string_1)
			{
				this.Text = (this.string_0 = string_1);
				this.bool_0 = true;
				this.ForeColor = SystemColors.GrayText;
			}

			protected override void OnGotFocus(EventArgs eventArgs_0)
			{
				if (this.bool_0)
				{
					this.Text = "";
				}
				base.OnGotFocus(eventArgs_0);
			}

			protected override void OnLostFocus(EventArgs eventArgs_0)
			{
				if (string.IsNullOrEmpty(this.Text))
				{
					this.Text = this.string_0;
					this.bool_0 = true;
				}
				this.ForeColor = (this.bool_0 ? SystemColors.GrayText : SystemColors.WindowText);
				base.OnLostFocus(eventArgs_0);
			}

			protected override void OnTextChanged(EventArgs eventArgs_0)
			{
				if (!this.Focused && string.IsNullOrEmpty(this.Text))
				{
					this.Text = this.string_0;
					this.bool_0 = true;
				}
				else
				{
					this.bool_0 = false;
				}
				this.ForeColor = (this.bool_0 ? SystemColors.GrayText : SystemColors.WindowText);
				base.OnTextChanged(eventArgs_0);
			}
		}

		internal class Class577
		{
			[CompilerGenerated]
			private string string_0;

			[CompilerGenerated]
			private object object_0;

			internal string String_0
			{
				[CompilerGenerated]
				get
				{
					return this.string_0;
				}
				[CompilerGenerated]
				set
				{
					this.string_0 = value;
				}
			}

			internal object Object_0
			{
				[CompilerGenerated]
				get
				{
					return this.object_0;
				}
				[CompilerGenerated]
				set
				{
					this.object_0 = value;
				}
			}

			internal Class577(string string_1, object object_1)
			{
				this.String_0 = string_1;
				this.Object_0 = object_1;
			}
		}

		private TabControl tabControl_0;

		private TabPage tabPage_0;

		private TabPage tabPage_1;

		private TabPage tabPage_2;

		private TableLayoutPanel tableLayoutPanel_0;

		private Label label_0;

		private Class576 class576_0;

		private Label label_1;

		private Class576 class576_1;

		private Label label_2;

		private Label label_3;

		private Label label_4;

		private Class576 class576_2;

		private Label label_5;

		private Class576 class576_3;

		private Label label_6;

		private TableLayoutPanel tableLayoutPanel_1;

		private Sidebar.Class584 class584_0;

		private Label label_7;

		private Label label_8;

		private TableLayoutPanel tableLayoutPanel_2;

		private ListView listView_0;

		private ColumnHeader columnHeader_0;

		private ColumnHeader columnHeader_1;

		private ColumnHeader columnHeader_2;

		private System.Windows.Forms.Button button_0;

		private System.Windows.Forms.Button button_1;

		private Label label_9;

		private TableLayoutPanel tableLayoutPanel_3;

		private Sidebar.Class584 class584_1;

		private Label label_10;

		private Label label_11;

		private TableLayoutPanel tableLayoutPanel_4;

		private ListView listView_1;

		private ColumnHeader columnHeader_3;

		private ColumnHeader columnHeader_4;

		private ColumnHeader columnHeader_5;

		private ColumnHeader columnHeader_6;

		private System.Windows.Forms.Button button_2;

		private System.Windows.Forms.Button button_3;

		private System.Windows.Forms.Button button_4;

		private System.Windows.Forms.Button button_5;

		private DateTime dateTime_0 = DateTime.Now;

		private bool bool_0;

		private Dictionary<string, string> dictionary_0 = new Dictionary<string, string>();

		internal Class569(Enum140 enum140_0, TextControl textControl_0, bool bool_1, Sidebar.SidebarContentLayout sidebarContentLayout_0, PointF pointF_0)
			: base(enum140_0, textControl_0, bool_1, sidebarContentLayout_0, pointF_0)
		{
			this.tabPage_0.Text = base.m_rm.GetString("ID_DOCUMENTSETTINGS_DOCUMENT_INFO_TAB");
			this.tabPage_1.Text = base.m_rm.GetString("ID_DOCUMENTSETTINGS_CUSTOM_PROPERTIES_TAB");
			this.tabPage_2.Text = base.m_rm.GetString("ID_DOCUMENTSETTINGS_EMBEDDED_FILES_TAB");
			this.label_0.Text = base.m_rm.GetString("ID_DOCUMENTSETTINGS_TITLE");
			this.label_1.Text = base.m_rm.GetString("ID_DOCUMENTSETTINGS_AUTHOR");
			this.label_2.Text = base.m_rm.GetString("ID_DOCUMENTSETTINGS_CREATED");
			this.label_4.Text = base.m_rm.GetString("ID_DOCUMENTSETTINGS_SUBJECT");
			this.label_5.Text = base.m_rm.GetString("ID_DOCUMENTSETTINGS_TAGS");
			this.label_7.Text = base.m_rm.GetString("ID_DOCUMENTSETTINGS_CUSTOM_PROPERTIES");
			this.columnHeader_0.Text = base.m_rm.GetString("ID_DOCUMENTSETTINGS_PROPERTY_NAME");
			this.columnHeader_1.Text = base.m_rm.GetString("ID_DOCUMENTSETTINGS_PROPERTY_VALUE");
			this.columnHeader_2.Text = base.m_rm.GetString("ID_DOCUMENTSETTINGS_PROPERTY_TYPE");
			this.button_0.Text = base.m_rm.GetString("ID_DOCUMENTSETTINGS_ADD_PROPERTY");
			this.button_1.Text = base.m_rm.GetString("ID_DOCUMENTSETTINGS_DELETE_PROPERTY");
			this.label_10.Text = base.m_rm.GetString("ID_DOCUMENTSETTINGS_EMBEDDED_FILES");
			this.columnHeader_3.Text = base.m_rm.GetString("ID_DOCUMENTSETTINGS_EMBEDDED_FILE_NAME");
			this.columnHeader_4.Text = base.m_rm.GetString("ID_DOCUMENTSETTINGS_EMBEDDED_FILE_DESCRIPTION");
			this.columnHeader_6.Text = base.m_rm.GetString("ID_DOCUMENTSETTINGS_EMBEDDED_FILE_RELATIONSHIP");
			this.columnHeader_5.Text = base.m_rm.GetString("ID_DOCUMENTSETTINGS_EMBEDDED_FILE_MIMETYPE");
			this.button_2.Text = base.m_rm.GetString("ID_DOCUMENTSETTINGS_ADD_EMBEDDED_FILE");
			this.button_3.Text = base.m_rm.GetString("ID_DOCUMENTSETTINGS_SAVE_EMBEDDED_FILE");
			this.button_4.Text = base.m_rm.GetString("ID_DOCUMENTSETTINGS_REMOVE_EMBEDDED_FILE");
			this.button_5.Text = base.m_rm.GetString("ID_DOCUMENTSETTINGS_EDIT_EMBEDDED_FILE");
			this.method_3();
		}

		internal override void DoLayout()
		{
			this.tableLayoutPanel_2.ResumeLayout(performLayout: false);
			this.tableLayoutPanel_2.PerformLayout();
			this.tableLayoutPanel_4.ResumeLayout(performLayout: false);
			this.tableLayoutPanel_4.PerformLayout();
			this.tableLayoutPanel_1.ResumeLayout(performLayout: false);
			this.tableLayoutPanel_1.PerformLayout();
			this.tableLayoutPanel_3.ResumeLayout(performLayout: false);
			this.tableLayoutPanel_3.PerformLayout();
			base.ResumeLayout(performLayout: false);
			base.PerformLayout();
		}

		internal override void DoSuspendLayout()
		{
			base.SuspendLayout();
			this.tableLayoutPanel_1.SuspendLayout();
			this.tableLayoutPanel_3.SuspendLayout();
			this.tableLayoutPanel_2.SuspendLayout();
			this.tableLayoutPanel_4.SuspendLayout();
		}

		internal override void InitializeItems()
		{
			base.Name = "TXITEM_MainPanel";
			this.tabControl_0 = new TabControl();
			this.tabPage_0 = new TabPage();
			this.tabPage_1 = new TabPage();
			this.tabPage_2 = new TabPage();
			this.tableLayoutPanel_0 = new TableLayoutPanel();
			this.AutoSize = true;
			this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.label_0 = new Label();
			this.class576_0 = new Class576(base.m_rm.GetString("ID_DOCUMENTSETTINGS_NO_TITLE"));
			this.class576_0.LostFocus += class576_3_LostFocus;
			this.label_1 = new Label();
			this.class576_1 = new Class576(base.m_rm.GetString("ID_DOCUMENTSETTINGS_NO_AUTHOR"));
			this.class576_1.LostFocus += class576_3_LostFocus;
			this.label_2 = new Label();
			this.label_3 = new Label();
			this.label_4 = new Label();
			this.class576_2 = new Class576(base.m_rm.GetString("ID_DOCUMENTSETTINGS_NO_SUBJECT"));
			this.class576_2.LostFocus += class576_3_LostFocus;
			this.label_5 = new Label();
			this.class576_3 = new Class576(base.m_rm.GetString("ID_DOCUMENTSETTINGS_NO_TAG"));
			this.class576_3.LostFocus += class576_3_LostFocus;
			this.label_6 = new Label();
			this.tableLayoutPanel_1 = new TableLayoutPanel();
			this.class584_0 = new Sidebar.Class584();
			this.class584_0.CheckedChanged += class584_0_CheckedChanged;
			this.label_7 = new Label();
			this.label_8 = new Label();
			this.tableLayoutPanel_2 = new TableLayoutPanel();
			this.listView_0 = new ListView();
			this.listView_0.SelectedIndexChanged += listView_0_SelectedIndexChanged;
			this.columnHeader_0 = new ColumnHeader();
			this.columnHeader_1 = new ColumnHeader();
			this.columnHeader_2 = new ColumnHeader();
			this.button_0 = new System.Windows.Forms.Button();
			this.button_0.Click += button_0_Click;
			this.button_1 = new System.Windows.Forms.Button();
			this.button_1.Click += button_1_Click;
			this.label_9 = new Label();
			this.tableLayoutPanel_3 = new TableLayoutPanel();
			this.class584_1 = new Sidebar.Class584();
			this.class584_1.CheckedChanged += class584_1_CheckedChanged;
			this.label_10 = new Label();
			this.label_11 = new Label();
			this.tableLayoutPanel_4 = new TableLayoutPanel();
			this.listView_1 = new ListView();
			this.listView_1.SelectedIndexChanged += listView_1_SelectedIndexChanged;
			this.columnHeader_3 = new ColumnHeader();
			this.columnHeader_4 = new ColumnHeader();
			this.columnHeader_5 = new ColumnHeader();
			this.columnHeader_6 = new ColumnHeader();
			this.button_2 = new System.Windows.Forms.Button();
			this.button_2.Click += button_2_Click;
			this.button_3 = new System.Windows.Forms.Button();
			this.button_3.Click += button_3_Click;
			this.button_4 = new System.Windows.Forms.Button();
			this.button_4.Click += button_4_Click;
			this.button_5 = new System.Windows.Forms.Button();
			this.button_5.Click += button_5_Click;
			this.tabControl_0.Dock = DockStyle.Fill;
			this.tabControl_0.Name = Sidebar.DocumentSettingsItem.TXITEM_DialogTabControl.ToString();
			this.tabControl_0.TabStop = true;
			this.tabControl_0.TabIndex = 0;
			this.tabControl_0.TabPages.Add(this.tabPage_0);
			this.tabControl_0.TabPages.Add(this.tabPage_1);
			this.tabControl_0.TabPages.Add(this.tabPage_2);
			this.tabPage_0.Controls.Add(this.tableLayoutPanel_0);
			this.tabPage_0.Name = Sidebar.DocumentSettingsItem.TXITEM_DocumentInfoTabPage.ToString();
			this.tabPage_1.Name = Sidebar.DocumentSettingsItem.TXITEM_CustomPropertiesTabPage.ToString();
			this.tabPage_2.Name = Sidebar.DocumentSettingsItem.TXITEM_EmbeddedFilesTabPage.ToString();
			this.tableLayoutPanel_0.AutoSize = true;
			this.tableLayoutPanel_0.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel_0.ColumnCount = 3;
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_0.Dock = DockStyle.Fill;
			this.tableLayoutPanel_0.Margin = new Padding(0);
			this.tableLayoutPanel_0.RowCount = 6;
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.label_0.AutoSize = true;
			this.label_0.Dock = DockStyle.Top;
			this.label_0.Name = Sidebar.DocumentSettingsItem.TXITEM_TitleLabel.ToString();
			this.label_0.TabIndex = 1;
			this.class576_0.Dock = DockStyle.Top;
			this.class576_0.Name = Sidebar.DocumentSettingsItem.TXITEM_TitleTextBox.ToString();
			this.class576_0.TabIndex = 2;
			this.label_1.AutoSize = true;
			this.label_1.Dock = DockStyle.Top;
			this.label_1.Name = Sidebar.DocumentSettingsItem.TXITEM_AuthorLabel.ToString();
			this.label_1.TabIndex = 3;
			this.class576_1.Dock = DockStyle.Top;
			this.class576_1.Name = Sidebar.DocumentSettingsItem.TXITEM_AuthorTextBox.ToString();
			this.class576_1.TabIndex = 4;
			this.label_2.AutoSize = true;
			this.label_2.Dock = DockStyle.Top;
			this.label_2.Name = Sidebar.DocumentSettingsItem.TXITEM_CreatedLabel.ToString();
			this.label_2.TabIndex = 5;
			this.label_3.AutoSize = true;
			this.label_3.Dock = DockStyle.Top;
			this.label_3.Name = Sidebar.DocumentSettingsItem.TXITEM_DateLabel.ToString();
			this.label_3.TabIndex = 6;
			this.label_4.AutoSize = true;
			this.label_4.Dock = DockStyle.Top;
			this.label_4.Name = Sidebar.DocumentSettingsItem.TXITEM_SubjectLabel.ToString();
			this.label_4.TabIndex = 7;
			this.class576_2.Dock = DockStyle.Top;
			this.class576_2.Name = Sidebar.DocumentSettingsItem.TXITEM_SubjectTextBox.ToString();
			this.class576_2.TabIndex = 8;
			this.label_5.AutoSize = true;
			this.label_5.Dock = DockStyle.Top;
			this.label_5.Name = Sidebar.DocumentSettingsItem.TXITEM_TagsLabel.ToString();
			this.label_5.TabIndex = 9;
			this.class576_3.Dock = DockStyle.Top;
			this.class576_3.Name = Sidebar.DocumentSettingsItem.TXITEM_TagsTextBox.ToString();
			this.class576_3.TabIndex = 10;
			this.label_6.AutoSize = true;
			this.label_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label_6.Dock = DockStyle.Left;
			this.label_6.Name = Sidebar.DocumentSettingsItem.TXITEM_FirstVerticalSeparator.ToString();
			this.tableLayoutPanel_1.AutoSize = true;
			this.tableLayoutPanel_1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel_1.ColumnCount = 3;
			this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_1.Controls.Add(this.class584_0, 0, 0);
			this.tableLayoutPanel_1.Controls.Add(this.label_7, 1, 0);
			this.tableLayoutPanel_1.Controls.Add(this.label_8, 2, 0);
			this.tableLayoutPanel_1.Controls.Add(this.tableLayoutPanel_2, 0, 1);
			this.tableLayoutPanel_1.Dock = DockStyle.Fill;
			this.tableLayoutPanel_1.Margin = new Padding(0);
			this.tableLayoutPanel_1.Name = Sidebar.DocumentSettingsItem.TXITEM_CustomPropertiesPanel.ToString();
			this.tableLayoutPanel_1.RowCount = 2;
			this.tableLayoutPanel_1.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel_1.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel_1.SetColumnSpan(this.tableLayoutPanel_2, 3);
			this.tableLayoutPanel_1.TabIndex = 11;
			this.class584_0.Appearance = Appearance.Button;
			this.class584_0.AutoSize = true;
			this.class584_0.Dock = DockStyle.Top;
			this.class584_0.FlatStyle = FlatStyle.Flat;
			this.class584_0.Image = (this.class584_0.Checked ? Class517.Bitmap_7 : Class517.Bitmap_8);
			this.class584_0.ImageAlign = ContentAlignment.MiddleCenter;
			this.class584_0.Name = Sidebar.DocumentSettingsItem.TXITEM_CustomPropertiesToggleItem.ToString();
			this.class584_0.TabIndex = 12;
			this.class584_0.Text = "";
			this.class584_0.TextImageRelation = TextImageRelation.ImageBeforeText;
			this.label_7.AutoSize = true;
			this.label_7.Dock = DockStyle.Top;
			this.label_7.Name = Sidebar.DocumentSettingsItem.TXITEM_CustomPropertiesLabel.ToString();
			this.label_7.TabIndex = 13;
			this.label_8.AutoSize = true;
			this.label_8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label_8.Dock = DockStyle.Top;
			this.label_8.Name = Sidebar.DocumentSettingsItem.TXITEM_CustomPropertiesSeparator.ToString();
			this.label_8.TabIndex = 14;
			this.label_9.AutoSize = true;
			this.label_9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label_9.Dock = DockStyle.Left;
			this.label_9.Name = Sidebar.DocumentSettingsItem.TXITEM_SecondVerticalSeparator.ToString();
			this.tableLayoutPanel_2.AutoSize = true;
			this.tableLayoutPanel_2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel_2.ColumnCount = 2;
			this.tableLayoutPanel_2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_2.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_2.Controls.Add(this.button_0, 1, 0);
			this.tableLayoutPanel_2.Controls.Add(this.button_1, 1, 1);
			this.tableLayoutPanel_2.Controls.Add(this.listView_0, 0, 0);
			this.tableLayoutPanel_2.Dock = DockStyle.Fill;
			this.tableLayoutPanel_2.Margin = new Padding(0);
			this.tableLayoutPanel_2.Name = Sidebar.DocumentSettingsItem.TXITEM_CustomPropertiesSubpanel.ToString();
			this.tableLayoutPanel_2.RowCount = 3;
			this.tableLayoutPanel_2.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel_2.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel_2.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_2.TabIndex = 15;
			this.tableLayoutPanel_2.Visible = this.class584_0.Checked;
			this.listView_0.Columns.AddRange(new ColumnHeader[3] { this.columnHeader_0, this.columnHeader_1, this.columnHeader_2 });
			this.listView_0.Dock = DockStyle.Fill;
			this.listView_0.FullRowSelect = true;
			this.listView_0.GridLines = true;
			this.listView_0.HideSelection = false;
			this.listView_0.MultiSelect = false;
			this.listView_0.Name = Sidebar.DocumentSettingsItem.TXITEM_CustomPropertiesListView.ToString();
			this.tableLayoutPanel_2.SetRowSpan(this.listView_0, 3);
			this.listView_0.ShowGroups = false;
			this.listView_0.TabIndex = 16;
			this.listView_0.UseCompatibleStateImageBehavior = false;
			this.listView_0.View = View.Details;
			this.button_0.AutoSize = true;
			this.button_0.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.button_0.Dock = DockStyle.Top;
			this.button_0.Name = Sidebar.DocumentSettingsItem.TXITEM_AddCustomProperty.ToString();
			this.button_0.TabIndex = 17;
			this.button_0.UseVisualStyleBackColor = true;
			this.button_1.AutoSize = true;
			this.button_1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.button_1.Dock = DockStyle.Top;
			this.button_1.Enabled = false;
			this.button_1.Name = Sidebar.DocumentSettingsItem.TXITEM_DeleteCustomProperty.ToString();
			this.button_1.TabIndex = 18;
			this.button_1.UseVisualStyleBackColor = true;
			this.tableLayoutPanel_3.AutoSize = true;
			this.tableLayoutPanel_3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel_3.ColumnCount = 3;
			this.tableLayoutPanel_3.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_3.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_3.Controls.Add(this.class584_1, 0, 0);
			this.tableLayoutPanel_3.Controls.Add(this.label_10, 1, 0);
			this.tableLayoutPanel_3.Controls.Add(this.label_11, 2, 0);
			this.tableLayoutPanel_3.Controls.Add(this.tableLayoutPanel_4, 0, 1);
			this.tableLayoutPanel_3.Dock = DockStyle.Fill;
			this.tableLayoutPanel_3.Margin = new Padding(0);
			this.tableLayoutPanel_3.Name = Sidebar.DocumentSettingsItem.TXITEM_EmbeddedFilesPanel.ToString();
			this.tableLayoutPanel_3.RowCount = 2;
			this.tableLayoutPanel_3.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel_3.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel_3.SetColumnSpan(this.tableLayoutPanel_4, 3);
			this.tableLayoutPanel_3.TabIndex = 19;
			this.class584_1.Appearance = Appearance.Button;
			this.class584_1.AutoSize = true;
			this.class584_1.Dock = DockStyle.Top;
			this.class584_1.FlatStyle = FlatStyle.Flat;
			this.class584_1.Name = Sidebar.DocumentSettingsItem.TXITEM_EmbeddedFilesToggleItem.ToString();
			this.class584_1.TabIndex = 20;
			this.label_10.AutoSize = true;
			this.label_10.Dock = DockStyle.Top;
			this.label_10.Name = Sidebar.DocumentSettingsItem.TXITEM_EmbeddedFilesLabel.ToString();
			this.label_10.TabIndex = 21;
			this.label_11.AutoSize = true;
			this.label_11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.label_11.Dock = DockStyle.Top;
			this.label_11.Name = Sidebar.DocumentSettingsItem.TXITEM_EmbeddedFilesSeparator.ToString();
			this.label_11.TabIndex = 22;
			this.tableLayoutPanel_4.AutoSize = true;
			this.tableLayoutPanel_4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel_4.ColumnCount = 3;
			this.tableLayoutPanel_4.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_4.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_4.Controls.Add(this.listView_1, 0, 0);
			this.tableLayoutPanel_4.Controls.Add(this.button_2, 2, 0);
			this.tableLayoutPanel_4.Controls.Add(this.button_3, 2, 1);
			this.tableLayoutPanel_4.Controls.Add(this.button_4, 2, 2);
			this.tableLayoutPanel_4.Controls.Add(this.button_5, 2, 3);
			this.tableLayoutPanel_4.Dock = DockStyle.Fill;
			this.tableLayoutPanel_4.Margin = new Padding(0);
			this.tableLayoutPanel_4.Name = Sidebar.DocumentSettingsItem.TXITEM_EmbeddedFilesSubpanel.ToString();
			this.tableLayoutPanel_4.RowCount = 6;
			this.tableLayoutPanel_4.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel_4.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel_4.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel_4.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel_4.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_4.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel_4.TabIndex = 23;
			this.tableLayoutPanel_4.Visible = this.class584_1.Checked;
			this.listView_1.Columns.AddRange(new ColumnHeader[4] { this.columnHeader_3, this.columnHeader_4, this.columnHeader_6, this.columnHeader_5 });
			this.listView_1.Dock = DockStyle.Fill;
			this.listView_1.FullRowSelect = true;
			this.listView_1.GridLines = true;
			this.listView_1.HideSelection = false;
			this.listView_1.MultiSelect = false;
			this.listView_1.Name = Sidebar.DocumentSettingsItem.TXITEM_EmbeddedFilesListView.ToString();
			this.tableLayoutPanel_4.SetColumnSpan(this.listView_1, 2);
			this.tableLayoutPanel_4.SetRowSpan(this.listView_1, 6);
			this.listView_1.ShowGroups = false;
			this.listView_1.TabIndex = 24;
			this.listView_1.UseCompatibleStateImageBehavior = false;
			this.listView_1.View = View.Details;
			this.button_2.AutoSize = true;
			this.button_2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.button_2.Dock = DockStyle.Top;
			this.button_2.Name = Sidebar.DocumentSettingsItem.TXITEM_AddEmbeddedFile.ToString();
			this.button_2.TabIndex = 25;
			this.button_2.UseVisualStyleBackColor = true;
			this.button_3.AutoSize = true;
			this.button_3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.button_3.Dock = DockStyle.Top;
			this.button_3.Enabled = false;
			this.button_3.Name = Sidebar.DocumentSettingsItem.TXITEM_SaveEmbeddedFile.ToString();
			this.button_3.TabIndex = 26;
			this.button_3.UseVisualStyleBackColor = true;
			this.button_4.AutoSize = true;
			this.button_4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.button_4.Dock = DockStyle.Top;
			this.button_4.Enabled = false;
			this.button_4.Name = Sidebar.DocumentSettingsItem.TXITEM_RemoveEmbeddedFile.ToString();
			this.button_4.TabIndex = 27;
			this.button_4.UseVisualStyleBackColor = true;
			this.button_5.AutoSize = true;
			this.button_5.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.button_5.Dock = DockStyle.Top;
			this.button_5.Enabled = false;
			this.button_5.Name = Sidebar.DocumentSettingsItem.TXITEM_EditEmbeddedFile.ToString();
			this.button_5.TabIndex = 28;
			this.button_5.UseVisualStyleBackColor = true;
			base.m_dicItems.Add(this.label_0.Name, this.label_0);
			base.m_dicItems.Add(this.class576_0.Name, this.class576_0);
			base.m_dicItems.Add(this.label_1.Name, this.label_1);
			base.m_dicItems.Add(this.class576_1.Name, this.class576_1);
			base.m_dicItems.Add(this.label_2.Name, this.label_2);
			base.m_dicItems.Add(this.label_3.Name, this.label_3);
			base.m_dicItems.Add(this.label_4.Name, this.label_4);
			base.m_dicItems.Add(this.class576_2.Name, this.class576_2);
			base.m_dicItems.Add(this.label_5.Name, this.label_5);
			base.m_dicItems.Add(this.class576_3.Name, this.class576_3);
			base.m_dicItems.Add(this.label_6.Name, this.label_6);
			base.m_dicItems.Add(this.tableLayoutPanel_1.Name, this.tableLayoutPanel_1);
			base.m_dicItems.Add(this.class584_0.Name, this.class584_0);
			base.m_dicItems.Add(this.label_7.Name, this.label_7);
			base.m_dicItems.Add(this.label_8.Name, this.label_8);
			base.m_dicItems.Add(this.tableLayoutPanel_2.Name, this.tableLayoutPanel_2);
			base.m_dicItems.Add(this.listView_0.Name, this.listView_0);
			base.m_dicItems.Add(this.button_0.Name, this.button_0);
			base.m_dicItems.Add(this.button_1.Name, this.button_1);
			base.m_dicItems.Add(this.label_9.Name, this.label_9);
			base.m_dicItems.Add(this.tableLayoutPanel_3.Name, this.tableLayoutPanel_3);
			base.m_dicItems.Add(this.class584_1.Name, this.class584_1);
			base.m_dicItems.Add(this.label_10.Name, this.label_10);
			base.m_dicItems.Add(this.label_11.Name, this.label_11);
			base.m_dicItems.Add(this.tableLayoutPanel_4.Name, this.tableLayoutPanel_4);
			base.m_dicItems.Add(this.listView_1.Name, this.listView_1);
			base.m_dicItems.Add(this.button_2.Name, this.button_2);
			base.m_dicItems.Add(this.button_3.Name, this.button_3);
			base.m_dicItems.Add(this.button_4.Name, this.button_4);
			base.m_dicItems.Add(this.button_5.Name, this.button_5);
			base.m_dicItems.Add(this.tabControl_0.Name, this.tabControl_0);
			base.m_dicItems.Add(this.tabPage_0.Name, this.tabPage_0);
			base.m_dicItems.Add(this.tabPage_1.Name, this.tabPage_1);
			base.m_dicItems.Add(this.tabPage_2.Name, this.tabPage_2);
		}

		internal override void AwareOfDPI_Intialize()
		{
			if (!base.m_pntDpi.IsEmpty)
			{
				Padding padding3 = (this.listView_0.Margin = (this.listView_1.Margin = Class517.smethod_51(Class519.Class542.Class550.Padding_5, base.m_pntDpi)));
				System.Windows.Forms.Button button = this.button_0;
				System.Windows.Forms.Button button2 = this.button_1;
				System.Windows.Forms.Button button3 = this.button_2;
				System.Windows.Forms.Button button4 = this.button_3;
				System.Windows.Forms.Button button5 = this.button_4;
				Padding padding5 = (this.button_5.Margin = Class517.smethod_51(Class519.Class542.Class550.Padding_4, base.m_pntDpi));
				Padding padding7 = (button5.Margin = padding5);
				Padding padding9 = (button4.Margin = padding7);
				Padding padding11 = (button3.Margin = padding9);
				Padding padding14 = (button.Margin = (button2.Margin = padding11));
				System.Windows.Forms.Button button6 = this.button_0;
				System.Windows.Forms.Button button7 = this.button_1;
				System.Windows.Forms.Button button8 = this.button_2;
				System.Windows.Forms.Button button9 = this.button_3;
				System.Windows.Forms.Button button10 = this.button_4;
				Size size2 = (this.button_5.MinimumSize = Class517.smethod_48(Class519.Class542.Class550.Size_2, base.m_pntDpi));
				Size size4 = (button10.MinimumSize = size2);
				Size size6 = (button9.MinimumSize = size4);
				Size size8 = (button8.MinimumSize = size6);
				Size size11 = (button6.MinimumSize = (button7.MinimumSize = size8));
				Class576 @class = this.class576_0;
				Class576 class2 = this.class576_1;
				Class576 class3 = this.class576_2;
				Class576 class4 = this.class576_0;
				Size size13 = (this.class576_3.MinimumSize = Class517.smethod_48(Class519.Class542.Class550.Size_0, base.m_pntDpi));
				Size size15 = (class4.MinimumSize = size13);
				Size size17 = (class3.MinimumSize = size15);
				Size size20 = (@class.MinimumSize = (class2.MinimumSize = size17));
				Class576 class5 = this.class576_0;
				Class576 class6 = this.class576_1;
				Class576 class7 = this.class576_2;
				Class576 class8 = this.class576_0;
				Size size22 = (this.class576_3.MaximumSize = Class517.smethod_48(Class519.Class542.Class550.Size_1, base.m_pntDpi));
				Size size24 = (class8.MaximumSize = size22);
				Size size26 = (class7.MaximumSize = size24);
				Size size29 = (class5.MaximumSize = (class6.MaximumSize = size26));
				Sidebar.Class584 class9 = this.class584_0;
				Sidebar.Class584 class10 = this.class584_0;
				Sidebar.Class584 class11 = this.class584_1;
				Size size31 = (this.class584_1.MinimumSize = Class517.smethod_48(Class519.Class542.Size_4, base.m_pntDpi));
				Size size33 = (class11.MaximumSize = size31);
				Size size36 = (class9.MaximumSize = (class10.MinimumSize = size33));
				TableLayoutPanel tableLayoutPanel = this.tableLayoutPanel_1;
				TableLayoutPanel tableLayoutPanel2 = this.tableLayoutPanel_3;
				TableLayoutPanel tableLayoutPanel3 = this.tableLayoutPanel_2;
				TableLayoutPanel tableLayoutPanel4 = this.tableLayoutPanel_4;
				System.Windows.Forms.Button button11 = this.button_0;
				System.Windows.Forms.Button button12 = this.button_1;
				System.Windows.Forms.Button button13 = this.button_2;
				System.Windows.Forms.Button button14 = this.button_3;
				System.Windows.Forms.Button button15 = this.button_4;
				System.Windows.Forms.Button button16 = this.button_5;
				ListView listView = this.listView_0;
				Class576 class12 = this.class576_0;
				Class576 class13 = this.class576_1;
				Class576 class14 = this.class576_2;
				Size size37 = (this.class576_3.Size = Size.Empty);
				Size size39 = (class14.Size = size37);
				Size size41 = (class13.Size = size39);
				Size size43 = (class12.Size = size41);
				Size size45 = (listView.Size = size43);
				Size size47 = (button16.Size = size45);
				Size size49 = (button15.Size = size47);
				Size size51 = (button14.Size = size49);
				Size size53 = (button13.Size = size51);
				Size size55 = (button12.Size = size53);
				Size size57 = (button11.Size = size55);
				Size size59 = (tableLayoutPanel4.Size = size57);
				Size size61 = (tableLayoutPanel3.Size = size59);
				Size size64 = (tableLayoutPanel.Size = (tableLayoutPanel2.Size = size61));
				this.columnHeader_0.Width = this.method_9(Class519.Class542.Class550.Int32_0, this.columnHeader_0.Text, Class519.Class542.Class550.Int32_1);
				this.columnHeader_1.Width = this.method_9(Class519.Class542.Class550.Int32_0, this.columnHeader_1.Text, Class519.Class542.Class550.Int32_1);
				this.columnHeader_2.Width = this.method_9(Class519.Class542.Class550.Int32_0, this.columnHeader_2.Text, Class519.Class542.Class550.Int32_1);
				this.columnHeader_3.Width = this.method_9(Class519.Class542.Class550.Int32_0, this.columnHeader_3.Text, Class519.Class542.Class550.Int32_1);
				this.columnHeader_4.Width = this.method_9(Class519.Class542.Class550.Int32_0, this.columnHeader_4.Text, Class519.Class542.Class550.Int32_1);
				this.columnHeader_6.Width = this.method_9(Class519.Class542.Class550.Int32_0, this.columnHeader_6.Text, Class519.Class542.Class550.Int32_1);
				this.columnHeader_5.Width = this.method_9(Class519.Class542.Class550.Int32_0, this.columnHeader_5.Text, Class519.Class542.Class550.Int32_1);
				TabPage tabPage = this.tabPage_0;
				TabPage tabPage2 = this.tabPage_2;
				TabPage tabPage3 = this.tabPage_1;
				TabControl tabControl = this.tabControl_0;
				TableLayoutPanel tableLayoutPanel5 = this.tableLayoutPanel_2;
				TableLayoutPanel tableLayoutPanel6 = this.tableLayoutPanel_4;
				ListView listView2 = this.listView_1;
				Size size65 = (this.listView_0.Size = Size.Empty);
				Size size67 = (listView2.Size = size65);
				Size size69 = (tableLayoutPanel6.Size = size67);
				Size size71 = (tableLayoutPanel5.Size = size69);
				Size size73 = (tabControl.Size = size71);
				Size size75 = (tabPage3.Size = size73);
				Size size77 = (tabPage2.Size = size75);
				Size size80 = (base.Size = (tabPage.Size = size77));
			}
		}

		internal override void SetDialogAlignment()
		{
			base.Controls.Clear();
			this.tableLayoutPanel_0.Controls.Clear();
			base.ColumnStyles.Clear();
			base.RowStyles.Clear();
			base.ColumnCount = 1;
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			base.RowCount = 2;
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_0.Controls.Add(this.label_0, 0, 0);
			this.tableLayoutPanel_0.Controls.Add(this.class576_0, 1, 0);
			this.tableLayoutPanel_0.SetColumnSpan(this.class576_0, 2);
			this.tableLayoutPanel_0.Controls.Add(this.label_1, 0, 1);
			this.tableLayoutPanel_0.Controls.Add(this.class576_1, 1, 1);
			this.tableLayoutPanel_0.SetColumnSpan(this.class576_1, 2);
			this.tableLayoutPanel_0.Controls.Add(this.label_2, 0, 2);
			this.tableLayoutPanel_0.Controls.Add(this.label_3, 1, 2);
			this.tableLayoutPanel_0.SetColumnSpan(this.label_3, 2);
			this.tableLayoutPanel_0.Controls.Add(this.label_4, 0, 3);
			this.tableLayoutPanel_0.Controls.Add(this.class576_2, 1, 3);
			this.tableLayoutPanel_0.SetColumnSpan(this.class576_2, 2);
			this.tableLayoutPanel_0.Controls.Add(this.label_5, 0, 4);
			this.tableLayoutPanel_0.Controls.Add(this.class576_3, 1, 4);
			this.tableLayoutPanel_0.SetColumnSpan(this.class576_3, 2);
			this.tableLayoutPanel_2.Visible = true;
			this.tabPage_1.Controls.Add(this.tableLayoutPanel_2);
			this.tableLayoutPanel_4.Visible = true;
			this.tabPage_2.Controls.Add(this.tableLayoutPanel_4);
			base.Controls.Add(this.tabControl_0, 0, 1);
			base.SetDialogAlignment();
		}

		internal override void AwareOfDPI_Dialog()
		{
			base.Margin = Class517.smethod_51(Class519.Class542.Class550.Padding_8, base.m_pntDpi);
			Label label = this.label_0;
			Label label2 = this.label_1;
			Label label3 = this.label_2;
			Label label4 = this.label_3;
			Label label5 = this.label_4;
			Padding padding2 = (this.label_5.Margin = Class517.smethod_51(Class519.Class542.Class550.Padding_0, base.m_pntDpi));
			Padding padding4 = (label5.Margin = padding2);
			Padding padding6 = (label4.Margin = padding4);
			Padding padding8 = (label3.Margin = padding6);
			Padding padding11 = (label.Margin = (label2.Margin = padding8));
			this.class584_0.Image = (this.class584_0.Checked ? Class517.Bitmap_7 : Class517.Bitmap_8);
			this.class584_1.Image = (this.class584_1.Checked ? Class517.Bitmap_7 : Class517.Bitmap_8);
			Padding padding14 = (this.class584_0.Margin = (this.class584_1.Margin = Class517.smethod_51(Class519.Class542.Class550.Padding_2, base.m_pntDpi)));
			Padding padding17 = (this.label_7.Margin = (this.label_10.Margin = Class517.smethod_51(Class519.Class542.Class550.Padding_1, base.m_pntDpi)));
			Padding padding20 = (this.label_8.Margin = (this.label_11.Margin = Class517.smethod_51(Class519.Class542.Class550.Padding_9, base.m_pntDpi)));
			Size size3 = (this.label_8.MinimumSize = (this.label_11.MinimumSize = Class517.smethod_48(Class519.Class542.Class550.Size_5, base.m_pntDpi)));
			Size size6 = (this.label_8.MaximumSize = (this.label_11.MaximumSize = Class517.smethod_48(Class519.Class542.Class550.Size_6, base.m_pntDpi)));
			Padding padding23 = (this.tableLayoutPanel_1.Margin = (this.tableLayoutPanel_3.Margin = Class517.smethod_51(Class519.Class542.Class550.Padding_6, base.m_pntDpi)));
			Padding padding26 = (this.tableLayoutPanel_3.Margin = (this.tableLayoutPanel_3.Margin = Class517.smethod_51(Class519.Class542.Class550.Padding_6, base.m_pntDpi)));
			Size size9 = (this.tableLayoutPanel_2.MinimumSize = (this.tableLayoutPanel_4.MinimumSize = Class517.smethod_48(Class519.Class542.Class550.Size_3, base.m_pntDpi)));
			base.AwareOfDPI_Dialog();
		}

		internal override void SetHorizontalAlignment()
		{
			base.Controls.Clear();
			this.tableLayoutPanel_0.Controls.Clear();
			base.ColumnStyles.Clear();
			base.RowStyles.Clear();
			this.tableLayoutPanel_2.Visible = this.class584_0.Checked;
			this.tableLayoutPanel_4.Visible = this.class584_1.Checked;
			if (!this.tableLayoutPanel_1.Contains(this.tableLayoutPanel_2))
			{
				this.tableLayoutPanel_1.Controls.Add(this.tableLayoutPanel_2, 0, 1);
			}
			if (!this.tableLayoutPanel_3.Contains(this.tableLayoutPanel_4))
			{
				this.tableLayoutPanel_3.Controls.Add(this.tableLayoutPanel_4, 0, 1);
			}
			base.ColumnCount = 7;
			base.ColumnStyles.Add(new ColumnStyle());
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 0f));
			base.ColumnStyles.Add(new ColumnStyle());
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 0f));
			base.ColumnStyles.Add(new ColumnStyle());
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 0f));
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			base.RowCount = 6;
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			base.Controls.Add(this.label_0, 0, 0);
			base.Controls.Add(this.label_1, 0, 1);
			base.Controls.Add(this.label_2, 0, 2);
			base.Controls.Add(this.label_4, 0, 3);
			base.Controls.Add(this.label_5, 0, 4);
			base.Controls.Add(this.class576_0, 1, 0);
			base.Controls.Add(this.class576_1, 1, 1);
			base.Controls.Add(this.label_3, 1, 2);
			base.Controls.Add(this.class576_2, 1, 3);
			base.Controls.Add(this.class576_3, 1, 4);
			base.SetColumnSpan(this.class576_0, 1);
			base.SetColumnSpan(this.class576_1, 1);
			base.SetColumnSpan(this.label_3, 1);
			base.SetColumnSpan(this.class576_2, 1);
			base.SetColumnSpan(this.class576_3, 1);
			base.Controls.Add(this.label_6, 2, 0);
			base.SetRowSpan(this.label_6, 6);
			base.Controls.Add(this.tableLayoutPanel_1, 3, 0);
			base.SetColumnSpan(this.tableLayoutPanel_1, 1);
			base.SetRowSpan(this.tableLayoutPanel_1, 6);
			base.Controls.Add(this.label_9, 4, 0);
			base.SetRowSpan(this.label_9, 6);
			base.Controls.Add(this.tableLayoutPanel_3, 5, 0);
			base.SetColumnSpan(this.tableLayoutPanel_3, 1);
			base.SetRowSpan(this.tableLayoutPanel_3, 6);
			base.SetHorizontalAlignment();
		}

		internal override void AwareOfDPI_Horizontal()
		{
			base.ColumnStyles[1].Width = Class517.smethod_48(Class519.Class542.Class550.Size_0, base.m_pntDpi).Width + Class517.smethod_45(Class519.Class542.Class550.Padding_3.Horizontal, base.m_pntDpi.X);
			Label label = this.label_6;
			Label label2 = this.label_6;
			Label label3 = this.label_9;
			Padding padding2 = (this.label_9.Margin = Class517.smethod_51(Class519.Class542.Class550.Padding_10, base.m_pntDpi));
			Padding padding4 = (label3.Margin = padding2);
			Padding padding7 = (label.Margin = (label2.Margin = padding4));
			Label label4 = this.label_6;
			Label label5 = this.label_6;
			Label label6 = this.label_9;
			Size size2 = (this.label_9.MinimumSize = Class517.smethod_48(Class519.Class542.Class550.Size_5, base.m_pntDpi));
			Size size4 = (label6.MinimumSize = size2);
			Size size7 = (label4.MinimumSize = (label5.MinimumSize = size4));
			Label label7 = this.label_6;
			Label label8 = this.label_6;
			Label label9 = this.label_9;
			Size size9 = (this.label_9.MaximumSize = Class517.smethod_48(new Size(1, 0), base.m_pntDpi));
			Size size11 = (label9.MaximumSize = size9);
			Size size14 = (label7.MaximumSize = (label8.MaximumSize = size11));
			base.Margin = Class517.smethod_51(Class519.Class542.Class550.Padding_8, base.m_pntDpi);
			Label label10 = this.label_0;
			Label label11 = this.label_1;
			Label label12 = this.label_2;
			Label label13 = this.label_3;
			Label label14 = this.label_4;
			Padding padding9 = (this.label_5.Margin = Class517.smethod_51(Class519.Class542.Class550.Padding_0, base.m_pntDpi));
			Padding padding11 = (label14.Margin = padding9);
			Padding padding13 = (label13.Margin = padding11);
			Padding padding15 = (label12.Margin = padding13);
			Padding padding18 = (label10.Margin = (label11.Margin = padding15));
			this.class584_0.Image = (this.class584_0.Checked ? Class517.Bitmap_7 : Class517.Bitmap_8);
			this.class584_1.Image = (this.class584_1.Checked ? Class517.Bitmap_7 : Class517.Bitmap_8);
			Padding padding21 = (this.class584_0.Margin = (this.class584_1.Margin = Class517.smethod_51(Class519.Class542.Class550.Padding_2, base.m_pntDpi)));
			Padding padding24 = (this.label_7.Margin = (this.label_10.Margin = Class517.smethod_51(Class519.Class542.Class550.Padding_1, base.m_pntDpi)));
			Padding padding27 = (this.label_8.Margin = (this.label_11.Margin = Class517.smethod_51(Class519.Class542.Class550.Padding_9, base.m_pntDpi)));
			Size size17 = (this.label_8.MinimumSize = (this.label_11.MinimumSize = Class517.smethod_48(Class519.Class542.Class550.Size_5, base.m_pntDpi)));
			Size size20 = (this.label_8.MaximumSize = (this.label_11.MaximumSize = Class517.smethod_48(Class519.Class542.Class550.Size_6, base.m_pntDpi)));
			Padding padding30 = (this.tableLayoutPanel_1.Margin = (this.tableLayoutPanel_3.Margin = Class517.smethod_51(Class519.Class542.Class550.Padding_7, base.m_pntDpi)));
			Padding padding33 = (this.tableLayoutPanel_3.Margin = (this.tableLayoutPanel_3.Margin = Class517.smethod_51(Class519.Class542.Class550.Padding_7, base.m_pntDpi)));
			Size size23 = (this.tableLayoutPanel_4.MinimumSize = (this.tableLayoutPanel_2.MinimumSize = Class517.smethod_48(Class519.Class542.Class550.Size_4, base.m_pntDpi)));
			base.ColumnStyles[3].Width = this.tableLayoutPanel_2.PreferredSize.Width + this.tableLayoutPanel_1.Margin.Horizontal;
			base.ColumnStyles[5].Width = this.tableLayoutPanel_4.PreferredSize.Width + this.tableLayoutPanel_3.Margin.Horizontal;
		}

		internal override void SetVerticalAlignment()
		{
			base.Controls.Clear();
			this.tableLayoutPanel_0.Controls.Clear();
			base.ColumnStyles.Clear();
			base.RowStyles.Clear();
			this.tableLayoutPanel_2.Visible = this.class584_0.Checked;
			this.tableLayoutPanel_4.Visible = this.class584_1.Checked;
			if (!this.tableLayoutPanel_1.Contains(this.tableLayoutPanel_2))
			{
				this.tableLayoutPanel_1.Controls.Add(this.tableLayoutPanel_2, 0, 1);
			}
			if (!this.tableLayoutPanel_3.Contains(this.tableLayoutPanel_4))
			{
				this.tableLayoutPanel_3.Controls.Add(this.tableLayoutPanel_4, 0, 1);
			}
			base.ColumnCount = 3;
			base.ColumnStyles.Add(new ColumnStyle());
			base.ColumnStyles.Add(new ColumnStyle());
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			base.RowCount = 8;
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			base.Controls.Add(this.label_0, 0, 0);
			base.Controls.Add(this.class576_0, 1, 0);
			base.SetColumnSpan(this.class576_0, 2);
			base.Controls.Add(this.label_1, 0, 1);
			base.Controls.Add(this.class576_1, 1, 1);
			base.SetColumnSpan(this.class576_1, 2);
			base.Controls.Add(this.label_2, 0, 2);
			base.Controls.Add(this.label_3, 1, 2);
			base.SetColumnSpan(this.label_3, 2);
			base.Controls.Add(this.label_4, 0, 3);
			base.Controls.Add(this.class576_2, 1, 3);
			base.SetColumnSpan(this.class576_2, 2);
			base.Controls.Add(this.label_5, 0, 4);
			base.Controls.Add(this.class576_3, 1, 4);
			base.SetColumnSpan(this.class576_3, 2);
			base.Controls.Add(this.tableLayoutPanel_1, 0, 5);
			base.SetColumnSpan(this.tableLayoutPanel_1, 3);
			base.SetRowSpan(this.tableLayoutPanel_1, 1);
			base.Controls.Add(this.tableLayoutPanel_3, 0, 6);
			base.SetColumnSpan(this.tableLayoutPanel_3, 3);
			base.SetRowSpan(this.tableLayoutPanel_3, 1);
			this.tableLayoutPanel_4.SetColumnSpan(this.tableLayoutPanel_4, 4);
			base.SetVerticalAlignment();
		}

		internal override void AwareOfDPI_Vertical()
		{
			base.Margin = Class517.smethod_51(Class519.Class542.Class550.Padding_8, base.m_pntDpi);
			Label label = this.label_0;
			Label label2 = this.label_1;
			Label label3 = this.label_2;
			Label label4 = this.label_3;
			Label label5 = this.label_4;
			Padding padding2 = (this.label_5.Margin = Class517.smethod_51(Class519.Class542.Class550.Padding_0, base.m_pntDpi));
			Padding padding4 = (label5.Margin = padding2);
			Padding padding6 = (label4.Margin = padding4);
			Padding padding8 = (label3.Margin = padding6);
			Padding padding11 = (label.Margin = (label2.Margin = padding8));
			this.class584_0.Image = (this.class584_0.Checked ? Class517.Bitmap_7 : Class517.Bitmap_8);
			this.class584_1.Image = (this.class584_1.Checked ? Class517.Bitmap_7 : Class517.Bitmap_8);
			Padding padding14 = (this.class584_0.Margin = (this.class584_1.Margin = Class517.smethod_51(Class519.Class542.Class550.Padding_2, base.m_pntDpi)));
			Padding padding17 = (this.label_7.Margin = (this.label_10.Margin = Class517.smethod_51(Class519.Class542.Class550.Padding_1, base.m_pntDpi)));
			Padding padding20 = (this.label_8.Margin = (this.label_11.Margin = Class517.smethod_51(Class519.Class542.Class550.Padding_9, base.m_pntDpi)));
			Size size3 = (this.label_8.MinimumSize = (this.label_11.MinimumSize = Class517.smethod_48(Class519.Class542.Class550.Size_5, base.m_pntDpi)));
			Size size6 = (this.label_8.MaximumSize = (this.label_11.MaximumSize = Class517.smethod_48(Class519.Class542.Class550.Size_6, base.m_pntDpi)));
			Padding padding23 = (this.tableLayoutPanel_1.Margin = (this.tableLayoutPanel_3.Margin = Class517.smethod_51(Class519.Class542.Class550.Padding_6, base.m_pntDpi)));
			Padding padding26 = (this.tableLayoutPanel_3.Margin = (this.tableLayoutPanel_3.Margin = Class517.smethod_51(Class519.Class542.Class550.Padding_6, base.m_pntDpi)));
			this.tableLayoutPanel_2.MinimumSize = Class517.smethod_48(Class519.Class542.Class550.Size_3, base.m_pntDpi);
			this.tableLayoutPanel_4.MinimumSize = Class517.smethod_48(Class519.Class542.Class550.Size_3, base.m_pntDpi);
		}

		internal override void UpdateTextControlBindings(TextControl oldTextcontrol, TextControl newTextControl)
		{
			if (oldTextcontrol != null)
			{
				oldTextcontrol.DocumentLoaded -= method_1;
				oldTextcontrol.ContentsReset -= method_0;
			}
			if (newTextControl != null)
			{
				newTextControl.DocumentLoaded += method_1;
				newTextControl.ContentsReset += method_0;
			}
			this.UpdateContent();
		}

		internal override void UpdateContent()
		{
			if (base.TextControl != null)
			{
				DocumentSettings documentSettings = base.TextControl.DocumentSettings;
				this.class576_0.Text = documentSettings.DocumentTitle;
				this.class576_1.Text = documentSettings.Author;
				this.method_4(documentSettings, this.label_3);
				this.class576_2.Text = documentSettings.DocumentSubject;
				this.method_5(documentSettings, this.class576_3);
				this.method_6(documentSettings, this.listView_0);
				this.method_7(documentSettings, this.listView_1);
				this.method_8();
			}
		}

		public override Size GetPreferredSize(Size proposedSize)
		{
			Size preferredSize = base.GetPreferredSize(proposedSize);
			int num;
			int val;
			switch (base.m_cpaPanelAlignment)
			{
			default:
				val = preferredSize.Width;
				num = preferredSize.Height;
				break;
			case Enum140.const_0:
			{
				Class517.smethod_45(15, base.m_pntDpi.X);
				val = Math.Max(this.tableLayoutPanel_2.MinimumSize.Width + this.tableLayoutPanel_1.Margin.Horizontal, this.tableLayoutPanel_4.MinimumSize.Width + this.tableLayoutPanel_3.Margin.Horizontal);
				int num2 = 0;
				for (int i = 0; i < this.tabControl_0.TabCount; i++)
				{
					num2 += TextRenderer.MeasureText(this.tabControl_0.TabPages[i].Text, this.tabControl_0.Font, default(Size), TextFormatFlags.NoPrefix).Width;
				}
				val = Math.Max(this.tabControl_0.PreferredSize.Width, Math.Max(num2, Math.Max(val, this.tableLayoutPanel_0.PreferredSize.Width))) + Class517.smethod_45(75, base.m_pntDpi.X);
				num = Math.Max(this.class584_0.PreferredSize.Height + this.class584_0.Margin.Vertical + this.tableLayoutPanel_2.PreferredSize.Height + this.tableLayoutPanel_1.Margin.Vertical, this.class584_1.PreferredSize.Height + this.class584_1.Margin.Vertical + this.tableLayoutPanel_4.PreferredSize.Height + this.tableLayoutPanel_3.Margin.Vertical);
				num = Math.Max(this.tabControl_0.PreferredSize.Height, num);
				break;
			}
			case Enum140.const_1:
				val = preferredSize.Width;
				num = Math.Max(this.class584_0.PreferredSize.Height + this.class584_0.Margin.Vertical + this.tableLayoutPanel_2.PreferredSize.Height + this.tableLayoutPanel_1.Margin.Vertical, this.class584_1.PreferredSize.Height + this.class584_1.Margin.Vertical + this.tableLayoutPanel_4.PreferredSize.Height + this.tableLayoutPanel_3.Margin.Vertical);
				num = Math.Max(preferredSize.Height, num);
				break;
			case Enum140.const_2:
				val = Math.Max(this.tableLayoutPanel_2.MinimumSize.Width + this.tableLayoutPanel_1.Margin.Horizontal, this.tableLayoutPanel_4.MinimumSize.Width + this.tableLayoutPanel_3.Margin.Horizontal);
				val = Math.Max(preferredSize.Width, val);
				num = preferredSize.Height;
				break;
			}
			return new Size(val, num);
		}

		private void method_0(object sender, EventArgs e)
		{
			this.bool_0 = false;
			this.UpdateContent();
		}

		private void method_1(object sender, EventArgs e)
		{
			this.bool_0 = true;
			this.UpdateContent();
		}

		private void class576_3_LostFocus(object sender, EventArgs e)
		{
			if (base.TextControl == null)
			{
				return;
			}
			Class576 @class = sender as Class576;
			if (@class == null)
			{
				return;
			}
			switch ((sender as Class576).Name)
			{
			case "TXITEM_TagsTextBox":
			{
				if (@class.Boolean_0)
				{
					base.TextControl.DocumentSettings.DocumentKeywords = null;
					break;
				}
				string[] array = @class.Text.Split(new char[1] { ';' }, StringSplitOptions.RemoveEmptyEntries);
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = array[i].Trim();
				}
				base.TextControl.DocumentSettings.DocumentKeywords = array;
				break;
			}
			case "TXITEM_SubjectTextBox":
				base.TextControl.DocumentSettings.DocumentSubject = (@class.Boolean_0 ? "" : @class.Text);
				break;
			case "TXITEM_AuthorTextBox":
				base.TextControl.DocumentSettings.Author = (@class.Boolean_0 ? "" : @class.Text);
				break;
			case "TXITEM_TitleTextBox":
				base.TextControl.DocumentSettings.DocumentTitle = (@class.Boolean_0 ? "" : @class.Text);
				break;
			}
		}

		private void class584_0_CheckedChanged(object sender, EventArgs e)
		{
			if (base.m_cpaPanelAlignment != 0)
			{
				if (this.tableLayoutPanel_2.Visible = this.class584_0.Checked)
				{
					this.class584_0.Image = Class517.Bitmap_7;
				}
				else
				{
					this.class584_0.Image = Class517.Bitmap_8;
				}
			}
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			if (base.TextControl == null)
			{
				return;
			}
			AddCustomPropertyDialogcs addCustomPropertyDialogcs = new AddCustomPropertyDialogcs(base.TextControl.DocumentSettings);
			if (addCustomPropertyDialogcs.ShowDialog() == DialogResult.OK)
			{
				Class577 class577_ = addCustomPropertyDialogcs.Class577_0;
				ListViewItem listViewItem = this.method_10(class577_);
				this.listView_0.Items.Add(listViewItem);
				listViewItem.Selected = true;
				if (base.TextControl.DocumentSettings.UserDefinedDocumentProperties == null)
				{
					base.TextControl.DocumentSettings.UserDefinedDocumentProperties = new UserDefinedPropertyDictionary();
				}
				base.TextControl.DocumentSettings.UserDefinedDocumentProperties.Add(class577_.String_0, class577_.Object_0);
			}
		}

		private void listView_0_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.button_1.Enabled = this.listView_0.SelectedItems.Count != 0;
		}

		private void button_1_Click(object sender, EventArgs e)
		{
			if (this.listView_0.SelectedItems.Count > 0)
			{
				string name = this.listView_0.SelectedItems[0].SubItems[0].Text;
				if (base.TextControl != null && base.TextControl.DocumentSettings.UserDefinedDocumentProperties != null && base.TextControl.DocumentSettings.UserDefinedDocumentProperties.Contains(name))
				{
					base.TextControl.DocumentSettings.UserDefinedDocumentProperties.Remove(name);
					this.listView_0.Items.Remove(this.listView_0.SelectedItems[0]);
				}
			}
		}

		private void class584_1_CheckedChanged(object sender, EventArgs e)
		{
			if (base.m_cpaPanelAlignment != 0)
			{
				if (this.tableLayoutPanel_4.Visible = this.class584_1.Checked)
				{
					this.class584_1.Image = Class517.Bitmap_7;
				}
				else
				{
					this.class584_1.Image = Class517.Bitmap_8;
				}
			}
		}

		private void button_2_Click(object sender, EventArgs e)
		{
			if (base.TextControl == null)
			{
				return;
			}
			OpenFileDialog openFileDialog = new OpenFileDialog();
			if (openFileDialog.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			List<EmbeddedFile> list = ((base.TextControl.DocumentSettings.EmbeddedFiles != null) ? new List<EmbeddedFile>(base.TextControl.DocumentSettings.EmbeddedFiles) : new List<EmbeddedFile>());
			string[] fileNames = openFileDialog.FileNames;
			foreach (string text in fileNames)
			{
				byte[] data = File.ReadAllBytes(text);
				EmbeddedFile embeddedFile = new EmbeddedFile(Path.GetFileName(text), data, null);
				string[] array = text.Split('.');
				if (array.Length > 1)
				{
					string value = null;
					if (this.dictionary_0.TryGetValue("." + array[array.Length - 1].ToLower(), out value))
					{
						embeddedFile.MIMEType = value;
					}
				}
				list.Add(embeddedFile);
				ListViewItem value2 = this.method_11(embeddedFile);
				this.listView_1.Items.Add(value2);
			}
			base.TextControl.DocumentSettings.EmbeddedFiles = list.ToArray();
			this.listView_1.Items[this.listView_1.Items.Count - 1].Selected = true;
		}

		private void button_3_Click(object sender, EventArgs e)
		{
			EmbeddedFile embeddedFile = (EmbeddedFile)this.listView_1.SelectedItems[0].Tag;
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.FileName = embeddedFile.FileName;
			if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				byte[] array = embeddedFile.Data as byte[];
				if (array != null)
				{
					File.WriteAllBytes(saveFileDialog.FileName, array);
				}
			}
		}

		private void button_4_Click(object sender, EventArgs e)
		{
			if (this.listView_1.SelectedItems.Count <= 0 || base.TextControl == null || base.TextControl.DocumentSettings.EmbeddedFiles == null)
			{
				return;
			}
			EmbeddedFile embeddedFile = this.listView_1.SelectedItems[0].Tag as EmbeddedFile;
			EmbeddedFile[] array = new EmbeddedFile[base.TextControl.DocumentSettings.EmbeddedFiles.Length - 1];
			int num = 0;
			EmbeddedFile[] embeddedFiles = base.TextControl.DocumentSettings.EmbeddedFiles;
			foreach (EmbeddedFile embeddedFile2 in embeddedFiles)
			{
				if (embeddedFile != embeddedFile2)
				{
					array[num] = embeddedFile2;
					num++;
				}
			}
			base.TextControl.DocumentSettings.EmbeddedFiles = array;
			this.listView_1.Items.Remove(this.listView_1.SelectedItems[0]);
		}

		private void button_5_Click(object sender, EventArgs e)
		{
			if (base.TextControl == null || this.listView_1.SelectedItems.Count <= 0)
			{
				return;
			}
			EmbeddedFile embeddedFile = this.listView_1.SelectedItems[0].Tag as EmbeddedFile;
			EditEmbeddedFileDialog editEmbeddedFileDialog = new EditEmbeddedFileDialog(embeddedFile);
			if (editEmbeddedFileDialog.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			EmbeddedFile[] embeddedFiles = base.TextControl.DocumentSettings.EmbeddedFiles;
			int num = 0;
			while (true)
			{
				if (num < embeddedFiles.Length)
				{
					if (embeddedFiles[num] == embeddedFile)
					{
						break;
					}
					num++;
					continue;
				}
				return;
			}
			embeddedFiles[num].Description = editEmbeddedFileDialog.String_0;
			embeddedFiles[num].Relationship = editEmbeddedFileDialog.String_1;
			embeddedFiles[num].MIMEType = editEmbeddedFileDialog.String_2;
			base.TextControl.DocumentSettings.EmbeddedFiles = embeddedFiles;
			this.method_7(base.TextControl.DocumentSettings, this.listView_1);
			this.method_8();
		}

		private void listView_1_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.method_8();
		}

		private void method_2(string string_0, string string_1)
		{
			if (!this.dictionary_0.ContainsKey(string_0))
			{
				this.dictionary_0.Add(string_0, string_1);
			}
		}

		private void method_3()
		{
			this.dictionary_0.Clear();
			this.method_2(".323", "text/h323");
			this.method_2(".aaf", "application/octet-stream");
			this.method_2(".aca", "application/octet-stream");
			this.method_2(".accdb", "application/msaccess");
			this.method_2(".accde", "application/msaccess");
			this.method_2(".accdt", "application/msaccess");
			this.method_2(".acx", "application/internet-property-stream");
			this.method_2(".afm", "application/octet-stream");
			this.method_2(".ai", "application/postscript");
			this.method_2(".aif", "audio/x-aiff");
			this.method_2(".aifc", "audio/aiff");
			this.method_2(".aiff", "audio/aiff");
			this.method_2(".application", "application/x-ms-application");
			this.method_2(".art", "image/x-jg");
			this.method_2(".asd", "application/octet-stream");
			this.method_2(".asf", "video/x-ms-asf");
			this.method_2(".asi", "application/octet-stream");
			this.method_2(".asm", "text/plain");
			this.method_2(".asr", "video/x-ms-asf");
			this.method_2(".asx", "video/x-ms-asf");
			this.method_2(".atom", "application/atom+xml");
			this.method_2(".au", "audio/basic");
			this.method_2(".avi", "video/x-msvideo");
			this.method_2(".axs", "application/olescript");
			this.method_2(".bas", "text/plain");
			this.method_2(".bcpio", "application/x-bcpio");
			this.method_2(".bin", "application/octet-stream");
			this.method_2(".bmp", "image/bmp");
			this.method_2(".c", "text/plain");
			this.method_2(".cab", "application/octet-stream");
			this.method_2(".calx", "application/vnd.ms-office.calx");
			this.method_2(".cat", "application/vnd.ms-pki.seccat");
			this.method_2(".cdf", "application/x-cdf");
			this.method_2(".chm", "application/octet-stream");
			this.method_2(".class", "application/x-java-applet");
			this.method_2(".clp", "application/x-msclip");
			this.method_2(".cmx", "image/x-cmx");
			this.method_2(".cnf", "text/plain");
			this.method_2(".cod", "image/cis-cod");
			this.method_2(".cpio", "application/x-cpio");
			this.method_2(".cpp", "text/plain");
			this.method_2(".crd", "application/x-mscardfile");
			this.method_2(".crl", "application/pkix-crl");
			this.method_2(".crt", "application/x-x509-ca-cert");
			this.method_2(".csh", "application/x-csh");
			this.method_2(".css", "text/css");
			this.method_2(".csv", "application/octet-stream");
			this.method_2(".cur", "application/octet-stream");
			this.method_2(".dcr", "application/x-director");
			this.method_2(".deploy", "application/octet-stream");
			this.method_2(".der", "application/x-x509-ca-cert");
			this.method_2(".dib", "image/bmp");
			this.method_2(".dir", "application/x-director");
			this.method_2(".disco", "text/xml");
			this.method_2(".dll", "application/x-msdownload");
			this.method_2(".dll.config", "text/xml");
			this.method_2(".dlm", "text/dlm");
			this.method_2(".doc", "application/msword");
			this.method_2(".docm", "application/vnd.ms-word.document.macroEnabled.12");
			this.method_2(".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
			this.method_2(".dot", "application/msword");
			this.method_2(".dotm", "application/vnd.ms-word.template.macroEnabled.12");
			this.method_2(".dotx", "application/vnd.openxmlformats-officedocument.wordprocessingml.template");
			this.method_2(".dsp", "application/octet-stream");
			this.method_2(".dtd", "text/xml");
			this.method_2(".dvi", "application/x-dvi");
			this.method_2(".dwf", "drawing/x-dwf");
			this.method_2(".dwp", "application/octet-stream");
			this.method_2(".dxr", "application/x-director");
			this.method_2(".eml", "message/rfc822");
			this.method_2(".emz", "application/octet-stream");
			this.method_2(".eot", "application/octet-stream");
			this.method_2(".eps", "application/postscript");
			this.method_2(".etx", "text/x-setext");
			this.method_2(".evy", "application/envoy");
			this.method_2(".exe", "application/octet-stream");
			this.method_2(".exe.config", "text/xml");
			this.method_2(".fdf", "application/vnd.fdf");
			this.method_2(".fif", "application/fractals");
			this.method_2(".fla", "application/octet-stream");
			this.method_2(".flr", "x-world/x-vrml");
			this.method_2(".flv", "video/x-flv");
			this.method_2(".gif", "image/gif");
			this.method_2(".gtar", "application/x-gtar");
			this.method_2(".gz", "application/x-gzip");
			this.method_2(".h", "text/plain");
			this.method_2(".hdf", "application/x-hdf");
			this.method_2(".hdml", "text/x-hdml");
			this.method_2(".hhc", "application/x-oleobject");
			this.method_2(".hhk", "application/octet-stream");
			this.method_2(".hhp", "application/octet-stream");
			this.method_2(".hlp", "application/winhlp");
			this.method_2(".hqx", "application/mac-binhex40");
			this.method_2(".hta", "application/hta");
			this.method_2(".htc", "text/x-component");
			this.method_2(".htm", "text/html");
			this.method_2(".html", "text/html");
			this.method_2(".htt", "text/webviewhtml");
			this.method_2(".hxt", "text/html");
			this.method_2(".ico", "image/x-icon");
			this.method_2(".ics", "application/octet-stream");
			this.method_2(".ief", "image/ief");
			this.method_2(".iii", "application/x-iphone");
			this.method_2(".inf", "application/octet-stream");
			this.method_2(".ins", "application/x-internet-signup");
			this.method_2(".isp", "application/x-internet-signup");
			this.method_2(".IVF", "video/x-ivf");
			this.method_2(".jar", "application/java-archive");
			this.method_2(".java", "application/octet-stream");
			this.method_2(".jck", "application/liquidmotion");
			this.method_2(".jcz", "application/liquidmotion");
			this.method_2(".jfif", "image/pjpeg");
			this.method_2(".jpb", "application/octet-stream");
			this.method_2(".jpe", "image/jpeg");
			this.method_2(".jpeg", "image/jpeg");
			this.method_2(".jpg", "image/jpeg");
			this.method_2(".js", "application/x-javascript");
			this.method_2(".jsx", "text/jscript");
			this.method_2(".latex", "application/x-latex");
			this.method_2(".lit", "application/x-ms-reader");
			this.method_2(".lpk", "application/octet-stream");
			this.method_2(".lsf", "video/x-la-asf");
			this.method_2(".lsx", "video/x-la-asf");
			this.method_2(".lzh", "application/octet-stream");
			this.method_2(".m13", "application/x-msmediaview");
			this.method_2(".m14", "application/x-msmediaview");
			this.method_2(".m1v", "video/mpeg");
			this.method_2(".m3u", "audio/x-mpegurl");
			this.method_2(".man", "application/x-troff-man");
			this.method_2(".manifest", "application/x-ms-manifest");
			this.method_2(".map", "text/plain");
			this.method_2(".mdb", "application/x-msaccess");
			this.method_2(".mdp", "application/octet-stream");
			this.method_2(".me", "application/x-troff-me");
			this.method_2(".mht", "message/rfc822");
			this.method_2(".mhtml", "message/rfc822");
			this.method_2(".mid", "audio/mid");
			this.method_2(".midi", "audio/mid");
			this.method_2(".mix", "application/octet-stream");
			this.method_2(".mmf", "application/x-smaf");
			this.method_2(".mno", "text/xml");
			this.method_2(".mny", "application/x-msmoney");
			this.method_2(".mov", "video/quicktime");
			this.method_2(".movie", "video/x-sgi-movie");
			this.method_2(".mp2", "video/mpeg");
			this.method_2(".mp3", "audio/mpeg");
			this.method_2(".mpa", "video/mpeg");
			this.method_2(".mpe", "video/mpeg");
			this.method_2(".mpeg", "video/mpeg");
			this.method_2(".mpg", "video/mpeg");
			this.method_2(".mpp", "application/vnd.ms-project");
			this.method_2(".mpv2", "video/mpeg");
			this.method_2(".ms", "application/x-troff-ms");
			this.method_2(".msi", "application/octet-stream");
			this.method_2(".mso", "application/octet-stream");
			this.method_2(".mvb", "application/x-msmediaview");
			this.method_2(".mvc", "application/x-miva-compiled");
			this.method_2(".nc", "application/x-netcdf");
			this.method_2(".nsc", "video/x-ms-asf");
			this.method_2(".nws", "message/rfc822");
			this.method_2(".ocx", "application/octet-stream");
			this.method_2(".oda", "application/oda");
			this.method_2(".odc", "text/x-ms-odc");
			this.method_2(".ods", "application/oleobject");
			this.method_2(".one", "application/onenote");
			this.method_2(".onea", "application/onenote");
			this.method_2(".onetoc", "application/onenote");
			this.method_2(".onetoc2", "application/onenote");
			this.method_2(".onetmp", "application/onenote");
			this.method_2(".onepkg", "application/onenote");
			this.method_2(".osdx", "application/opensearchdescription+xml");
			this.method_2(".p10", "application/pkcs10");
			this.method_2(".p12", "application/x-pkcs12");
			this.method_2(".p7b", "application/x-pkcs7-certificates");
			this.method_2(".p7c", "application/pkcs7-mime");
			this.method_2(".p7m", "application/pkcs7-mime");
			this.method_2(".p7r", "application/x-pkcs7-certreqresp");
			this.method_2(".p7s", "application/pkcs7-signature");
			this.method_2(".pbm", "image/x-portable-bitmap");
			this.method_2(".pcx", "application/octet-stream");
			this.method_2(".pcz", "application/octet-stream");
			this.method_2(".pdf", "application/pdf");
			this.method_2(".pfb", "application/octet-stream");
			this.method_2(".pfm", "application/octet-stream");
			this.method_2(".pfx", "application/x-pkcs12");
			this.method_2(".pgm", "image/x-portable-graymap");
			this.method_2(".pko", "application/vnd.ms-pki.pko");
			this.method_2(".pma", "application/x-perfmon");
			this.method_2(".pmc", "application/x-perfmon");
			this.method_2(".pml", "application/x-perfmon");
			this.method_2(".pmr", "application/x-perfmon");
			this.method_2(".pmw", "application/x-perfmon");
			this.method_2(".png", "image/png");
			this.method_2(".pnm", "image/x-portable-anymap");
			this.method_2(".pnz", "image/png");
			this.method_2(".pot", "application/vnd.ms-powerpoint");
			this.method_2(".potm", "application/vnd.ms-powerpoint.template.macroEnabled.12");
			this.method_2(".potx", "application/vnd.openxmlformats-officedocument.presentationml.template");
			this.method_2(".ppam", "application/vnd.ms-powerpoint.addin.macroEnabled.12");
			this.method_2(".ppm", "image/x-portable-pixmap");
			this.method_2(".pps", "application/vnd.ms-powerpoint");
			this.method_2(".ppsm", "application/vnd.ms-powerpoint.slideshow.macroEnabled.12");
			this.method_2(".ppsx", "application/vnd.openxmlformats-officedocument.presentationml.slideshow");
			this.method_2(".ppt", "application/vnd.ms-powerpoint");
			this.method_2(".pptm", "application/vnd.ms-powerpoint.presentation.macroEnabled.12");
			this.method_2(".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation");
			this.method_2(".prf", "application/pics-rules");
			this.method_2(".prm", "application/octet-stream");
			this.method_2(".prx", "application/octet-stream");
			this.method_2(".ps", "application/postscript");
			this.method_2(".psd", "application/octet-stream");
			this.method_2(".psm", "application/octet-stream");
			this.method_2(".psp", "application/octet-stream");
			this.method_2(".pub", "application/x-mspublisher");
			this.method_2(".qt", "video/quicktime");
			this.method_2(".qtl", "application/x-quicktimeplayer");
			this.method_2(".qxd", "application/octet-stream");
			this.method_2(".ra", "audio/x-pn-realaudio");
			this.method_2(".ram", "audio/x-pn-realaudio");
			this.method_2(".rar", "application/octet-stream");
			this.method_2(".ras", "image/x-cmu-raster");
			this.method_2(".rf", "image/vnd.rn-realflash");
			this.method_2(".rgb", "image/x-rgb");
			this.method_2(".rm", "application/vnd.rn-realmedia");
			this.method_2(".rmi", "audio/mid");
			this.method_2(".roff", "application/x-troff");
			this.method_2(".rpm", "audio/x-pn-realaudio-plugin");
			this.method_2(".rtf", "application/rtf");
			this.method_2(".rtx", "text/richtext");
			this.method_2(".scd", "application/x-msschedule");
			this.method_2(".sct", "text/scriptlet");
			this.method_2(".sea", "application/octet-stream");
			this.method_2(".setpay", "application/set-payment-initiation");
			this.method_2(".setreg", "application/set-registration-initiation");
			this.method_2(".sgml", "text/sgml");
			this.method_2(".sh", "application/x-sh");
			this.method_2(".shar", "application/x-shar");
			this.method_2(".sit", "application/x-stuffit");
			this.method_2(".sldm", "application/vnd.ms-powerpoint.slide.macroEnabled.12");
			this.method_2(".sldx", "application/vnd.openxmlformats-officedocument.presentationml.slide");
			this.method_2(".smd", "audio/x-smd");
			this.method_2(".smi", "application/octet-stream");
			this.method_2(".smx", "audio/x-smd");
			this.method_2(".smz", "audio/x-smd");
			this.method_2(".snd", "audio/basic");
			this.method_2(".snp", "application/octet-stream");
			this.method_2(".spc", "application/x-pkcs7-certificates");
			this.method_2(".spl", "application/futuresplash");
			this.method_2(".src", "application/x-wais-source");
			this.method_2(".ssm", "application/streamingmedia");
			this.method_2(".sst", "application/vnd.ms-pki.certstore");
			this.method_2(".stl", "application/vnd.ms-pki.stl");
			this.method_2(".sv4cpio", "application/x-sv4cpio");
			this.method_2(".sv4crc", "application/x-sv4crc");
			this.method_2(".swf", "application/x-shockwave-flash");
			this.method_2(".t", "application/x-troff");
			this.method_2(".tar", "application/x-tar");
			this.method_2(".tcl", "application/x-tcl");
			this.method_2(".tex", "application/x-tex");
			this.method_2(".texi", "application/x-texinfo");
			this.method_2(".texinfo", "application/x-texinfo");
			this.method_2(".tgz", "application/x-compressed");
			this.method_2(".thmx", "application/vnd.ms-officetheme");
			this.method_2(".thn", "application/octet-stream");
			this.method_2(".tif", "image/tiff");
			this.method_2(".tiff", "image/tiff");
			this.method_2(".toc", "application/octet-stream");
			this.method_2(".tr", "application/x-troff");
			this.method_2(".trm", "application/x-msterminal");
			this.method_2(".tsv", "text/tab-separated-values");
			this.method_2(".ttf", "application/octet-stream");
			this.method_2(".txt", "text/plain");
			this.method_2(".u32", "application/octet-stream");
			this.method_2(".uls", "text/iuls");
			this.method_2(".ustar", "application/x-ustar");
			this.method_2(".vbs", "text/vbscript");
			this.method_2(".vcf", "text/x-vcard");
			this.method_2(".vcs", "text/plain");
			this.method_2(".vdx", "application/vnd.ms-visio.viewer");
			this.method_2(".vml", "text/xml");
			this.method_2(".vsd", "application/vnd.visio");
			this.method_2(".vss", "application/vnd.visio");
			this.method_2(".vst", "application/vnd.visio");
			this.method_2(".vsto", "application/x-ms-vsto");
			this.method_2(".vsw", "application/vnd.visio");
			this.method_2(".vsx", "application/vnd.visio");
			this.method_2(".vtx", "application/vnd.visio");
			this.method_2(".wav", "audio/wav");
			this.method_2(".wax", "audio/x-ms-wax");
			this.method_2(".wbmp", "image/vnd.wap.wbmp");
			this.method_2(".wcm", "application/vnd.ms-works");
			this.method_2(".wdb", "application/vnd.ms-works");
			this.method_2(".wks", "application/vnd.ms-works");
			this.method_2(".wm", "video/x-ms-wm");
			this.method_2(".wma", "audio/x-ms-wma");
			this.method_2(".wmd", "application/x-ms-wmd");
			this.method_2(".wmf", "application/x-msmetafile");
			this.method_2(".wml", "text/vnd.wap.wml");
			this.method_2(".wmlc", "application/vnd.wap.wmlc");
			this.method_2(".wmls", "text/vnd.wap.wmlscript");
			this.method_2(".wmlsc", "application/vnd.wap.wmlscriptc");
			this.method_2(".wmp", "video/x-ms-wmp");
			this.method_2(".wmv", "video/x-ms-wmv");
			this.method_2(".wmx", "video/x-ms-wmx");
			this.method_2(".wmz", "application/x-ms-wmz");
			this.method_2(".wps", "application/vnd.ms-works");
			this.method_2(".wri", "application/x-mswrite");
			this.method_2(".wrl", "x-world/x-vrml");
			this.method_2(".wrz", "x-world/x-vrml");
			this.method_2(".wsdl", "text/xml");
			this.method_2(".wvx", "video/x-ms-wvx");
			this.method_2(".x", "application/directx");
			this.method_2(".xaf", "x-world/x-vrml");
			this.method_2(".xaml", "application/xaml+xml");
			this.method_2(".xap", "application/x-silverlight-app");
			this.method_2(".xbap", "application/x-ms-xbap");
			this.method_2(".xbm", "image/x-xbitmap");
			this.method_2(".xdr", "text/plain");
			this.method_2(".xla", "application/vnd.ms-excel");
			this.method_2(".xlam", "application/vnd.ms-excel.addin.macroEnabled.12");
			this.method_2(".xlc", "application/vnd.ms-excel");
			this.method_2(".xlm", "application/vnd.ms-excel");
			this.method_2(".xls", "application/vnd.ms-excel");
			this.method_2(".xlsb", "application/vnd.ms-excel.sheet.binary.macroEnabled.12");
			this.method_2(".xlsm", "application/vnd.ms-excel.sheet.macroEnabled.12");
			this.method_2(".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
			this.method_2(".xlt", "application/vnd.ms-excel");
			this.method_2(".xltm", "application/vnd.ms-excel.template.macroEnabled.12");
			this.method_2(".xltx", "application/vnd.openxmlformats-officedocument.spreadsheetml.template");
			this.method_2(".xlw", "application/vnd.ms-excel");
			this.method_2(".xml", "text/xml");
			this.method_2(".xof", "x-world/x-vrml");
			this.method_2(".xpm", "image/x-xpixmap");
			this.method_2(".xps", "application/vnd.ms-xpsdocument");
			this.method_2(".xsd", "text/xml");
			this.method_2(".xsf", "text/xml");
			this.method_2(".xsl", "text/xml");
			this.method_2(".xslt", "text/xml");
			this.method_2(".xsn", "application/octet-stream");
			this.method_2(".xtp", "application/octet-stream");
			this.method_2(".xwd", "image/x-xwindowdump");
			this.method_2(".z", "application/x-compress");
			this.method_2(".zip", "application/x-zip-compressed");
		}

		private void method_4(DocumentSettings documentSettings_0, Label label_12)
		{
			DateTime creationDate = (this.bool_0 ? documentSettings_0.CreationDate : DateTime.Now);
			if (creationDate.Ticks == 0L)
			{
				label_12.Text = base.m_rm.GetString("ID_DOCUMENTSETTINGS_NO_CREATION_DATE");
				return;
			}
			if (!this.bool_0)
			{
				documentSettings_0.CreationDate = creationDate;
			}
			label_12.Text = creationDate.ToString("g", Thread.CurrentThread.CurrentUICulture.DateTimeFormat);
		}

		private void method_5(DocumentSettings documentSettings_0, Class576 class576_4)
		{
			string text = "";
			if (documentSettings_0.DocumentKeywords != null)
			{
				string[] documentKeywords = documentSettings_0.DocumentKeywords;
				for (int i = 0; i < documentKeywords.Length - 1; i++)
				{
					string value = documentKeywords[i].Trim();
					if (!string.IsNullOrWhiteSpace(value))
					{
						text = text + documentKeywords[i] + "; ";
					}
				}
				text += documentKeywords[documentKeywords.Length - 1];
			}
			class576_4.Text = text;
		}

		private void method_6(DocumentSettings documentSettings_0, ListView listView_2)
		{
			listView_2.Items.Clear();
			if (documentSettings_0.UserDefinedDocumentProperties != null)
			{
				UserDefinedPropertyDictionary userDefinedDocumentProperties = documentSettings_0.UserDefinedDocumentProperties;
				IEnumerator enumerator = userDefinedDocumentProperties.Names.GetEnumerator();
				while (enumerator.MoveNext())
				{
					string text = enumerator.Current.ToString();
					object object_ = userDefinedDocumentProperties[text];
					Class577 class577_ = new Class577(text, object_);
					ListViewItem value = this.method_10(class577_);
					listView_2.Items.Add(value);
				}
				if (listView_2.Items.Count > 0)
				{
					listView_2.Items[0].Selected = true;
				}
			}
			this.button_1.Enabled = listView_2.SelectedItems.Count > 0;
		}

		private void method_7(DocumentSettings documentSettings_0, ListView listView_2)
		{
			listView_2.Items.Clear();
			if (documentSettings_0.EmbeddedFiles != null)
			{
				EmbeddedFile[] embeddedFiles = documentSettings_0.EmbeddedFiles;
				foreach (EmbeddedFile embeddedFile_ in embeddedFiles)
				{
					ListViewItem value = this.method_11(embeddedFile_);
					listView_2.Items.Add(value);
				}
				if (listView_2.Items.Count > 0)
				{
					listView_2.Items[0].Selected = true;
				}
			}
		}

		private void method_8()
		{
			System.Windows.Forms.Button button = this.button_3;
			System.Windows.Forms.Button button2 = this.button_4;
			bool flag2 = (this.button_5.Enabled = this.listView_1.SelectedItems.Count > 0);
			bool enabled = (button2.Enabled = flag2);
			button.Enabled = enabled;
		}

		private int method_9(int int_0, string string_0, int int_1)
		{
			int num = TextRenderer.MeasureText(string_0, this.Font, default(Size), TextFormatFlags.NoPrefix).Width;
			return Math.Max(num + Class517.smethod_45(int_1, base.m_pntDpi.X), Class517.smethod_45(int_0, base.m_pntDpi.X));
		}

		private ListViewItem method_10(Class577 class577_0)
		{
			ListViewItem listViewItem = new ListViewItem(class577_0.String_0);
			string s = class577_0.Object_0.ToString();
			string text = class577_0.Object_0.GetType().ToString();
			switch (text)
			{
			case "System.Boolean":
				text = base.m_rm.GetString("ID_DOCUMENTSETTINGS_PROPERTY_TYPE_BOOLEAN");
				s = (((bool)class577_0.Object_0) ? base.m_rm.GetString("ID_DOCUMENTSETTINGS_PROPERTY_VALUE_TRUE") : base.m_rm.GetString("ID_DOCUMENTSETTINGS_PROPERTY_VALUE_FALSE"));
				break;
			case "System.String":
				text = base.m_rm.GetString("ID_DOCUMENTSETTINGS_PROPERTY_TYPE_STRING");
				break;
			case "System.Int32":
			{
				text = base.m_rm.GetString("ID_DOCUMENTSETTINGS_PROPERTY_TYPE_INT32");
				if (int.TryParse(s, out var result2))
				{
					s = result2.ToString(Thread.CurrentThread.CurrentUICulture.NumberFormat);
				}
				break;
			}
			case "System.Double":
			{
				text = base.m_rm.GetString("ID_DOCUMENTSETTINGS_PROPERTY_TYPE_DOUBLE");
				if (double.TryParse(s, out var result))
				{
					s = result.ToString(Thread.CurrentThread.CurrentUICulture.NumberFormat);
				}
				break;
			}
			}
			listViewItem.SubItems.Add(s);
			listViewItem.SubItems.Add(text);
			return listViewItem;
		}

		private ListViewItem method_11(EmbeddedFile embeddedFile_0)
		{
			ListViewItem listViewItem = new ListViewItem(embeddedFile_0.FileName);
			listViewItem.SubItems.Add(embeddedFile_0.Description);
			listViewItem.SubItems.Add(embeddedFile_0.Relationship);
			listViewItem.SubItems.Add(embeddedFile_0.MIMEType);
			listViewItem.Tag = embeddedFile_0;
			return listViewItem;
		}
	}
}
