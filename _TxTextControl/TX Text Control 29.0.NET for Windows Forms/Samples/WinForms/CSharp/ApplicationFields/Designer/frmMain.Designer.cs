namespace MailMerge_Designer
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.textControl1 = new TXTextControl.TextControl();
            this.rulerBar1 = new TXTextControl.RulerBar();
            this.statusBar1 = new TXTextControl.StatusBar();
            this.buttonBar1 = new TXTextControl.ButtonBar();
            this.rulerBar2 = new TXTextControl.RulerBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mailMergeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectRecipientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.insertMergeFieldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertSpecialFieldsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iFFieldToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.includeTextToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.dateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.showAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllFieldResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteFieldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fieldSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.nextRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.previousRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSelectRecipients = new System.Windows.Forms.ToolStripButton();
            this.tslDatabaseName = new System.Windows.Forms.ToolStripLabel();
            this.tscbDataTables = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbInsertField = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbSpecialFields = new System.Windows.Forms.ToolStripDropDownButton();
            this.iFFieldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.includeTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbShowFieldCodes = new System.Windows.Forms.ToolStripButton();
            this.tsbShowFieldText = new System.Windows.Forms.ToolStripButton();
            this.tsbPreview = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbFieldDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbFieldSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExport = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.cmField = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.cmField.SuspendLayout();
            this.SuspendLayout();
            // 
            // textControl1
            // 
            this.textControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textControl1.Font = new System.Drawing.Font("Arial", 10F);
            this.textControl1.Location = new System.Drawing.Point(25, 127);
            this.textControl1.Name = "textControl1";
            this.textControl1.PageMargins.Bottom = 79.03D;
            this.textControl1.PageMargins.Left = 79.03D;
            this.textControl1.PageMargins.Right = 79.03D;
            this.textControl1.PageMargins.Top = 79.03D;
            this.textControl1.Size = new System.Drawing.Size(914, 312);
            this.textControl1.TabIndex = 0;
            this.textControl1.UserNames = null;
            this.textControl1.Changed += new System.EventHandler(this.textControl1_Changed);
            this.textControl1.TextFieldEntered += new TXTextControl.TextFieldEventHandler(this.textControl1_TextFieldEntered);
            this.textControl1.TextFieldLeft += new TXTextControl.TextFieldEventHandler(this.textControl1_TextFieldLeft);
            this.textControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.textControl1_MouseUp);
            // 
            // rulerBar1
            // 
            this.rulerBar1.Alignment = TXTextControl.RulerBarAlignment.Left;
            this.rulerBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.rulerBar1.Location = new System.Drawing.Point(0, 127);
            this.rulerBar1.Name = "rulerBar1";
            this.rulerBar1.Size = new System.Drawing.Size(25, 312);
            this.rulerBar1.TabIndex = 1;
            this.rulerBar1.Text = "rulerBar1";
            // 
            // statusBar1
            // 
            this.statusBar1.BackColor = System.Drawing.SystemColors.Control;
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar1.Location = new System.Drawing.Point(0, 439);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(939, 22);
            this.statusBar1.TabIndex = 2;
            // 
            // buttonBar1
            // 
            this.buttonBar1.BackColor = System.Drawing.SystemColors.Control;
            this.buttonBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonBar1.Location = new System.Drawing.Point(0, 74);
            this.buttonBar1.Name = "buttonBar1";
            this.buttonBar1.Size = new System.Drawing.Size(939, 28);
            this.buttonBar1.TabIndex = 3;
            this.buttonBar1.Text = "buttonBar1";
            // 
            // rulerBar2
            // 
            this.rulerBar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.rulerBar2.Location = new System.Drawing.Point(0, 102);
            this.rulerBar2.Name = "rulerBar2";
            this.rulerBar2.Size = new System.Drawing.Size(939, 25);
            this.rulerBar2.TabIndex = 4;
            this.rulerBar2.Text = "rulerBar2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mailMergeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(939, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.loadToolStripMenuItem,
            this.toolStripMenuItem5,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            this.fileToolStripMenuItem.DropDownOpening += new System.EventHandler(this.fileToolStripMenuItem_DropDownOpening);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loadToolStripMenuItem.Text = "&Load...";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(149, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveAsToolStripMenuItem.Text = "Save &As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // mailMergeToolStripMenuItem
            // 
            this.mailMergeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectRecipientToolStripMenuItem,
            this.toolStripMenuItem2,
            this.insertMergeFieldToolStripMenuItem,
            this.insertSpecialFieldsToolStripMenuItem,
            this.toolStripMenuItem7,
            this.showAllToolStripMenuItem,
            this.showAllFieldResultsToolStripMenuItem,
            this.showPreviewToolStripMenuItem,
            this.toolStripMenuItem3,
            this.deleteFieldToolStripMenuItem,
            this.fieldSettingsToolStripMenuItem,
            this.toolStripMenuItem6,
            this.nextRecordToolStripMenuItem,
            this.previousRecordToolStripMenuItem,
            this.toolStripMenuItem4,
            this.exportToolStripMenuItem});
            this.mailMergeToolStripMenuItem.Name = "mailMergeToolStripMenuItem";
            this.mailMergeToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.mailMergeToolStripMenuItem.Text = "&Mail Merge";
            this.mailMergeToolStripMenuItem.DropDownOpening += new System.EventHandler(this.mailMergeToolStripMenuItem_DropDownOpening);
            // 
            // selectRecipientToolStripMenuItem
            // 
            this.selectRecipientToolStripMenuItem.Image = global::MailMerge_Designer.Properties.Resources.select_recipients;
            this.selectRecipientToolStripMenuItem.Name = "selectRecipientToolStripMenuItem";
            this.selectRecipientToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.selectRecipientToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.selectRecipientToolStripMenuItem.Text = "Select &Recipients...";
            this.selectRecipientToolStripMenuItem.Click += new System.EventHandler(this.selectRecipientToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(232, 6);
            // 
            // insertMergeFieldToolStripMenuItem
            // 
            this.insertMergeFieldToolStripMenuItem.Enabled = false;
            this.insertMergeFieldToolStripMenuItem.Image = global::MailMerge_Designer.Properties.Resources.insert_field;
            this.insertMergeFieldToolStripMenuItem.Name = "insertMergeFieldToolStripMenuItem";
            this.insertMergeFieldToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.insertMergeFieldToolStripMenuItem.Text = "Insert Merge &Field";
            // 
            // insertSpecialFieldsToolStripMenuItem
            // 
            this.insertSpecialFieldsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iFFieldToolStripMenuItem1,
            this.includeTextToolStripMenuItem1,
            this.dateToolStripMenuItem1});
            this.insertSpecialFieldsToolStripMenuItem.Enabled = false;
            this.insertSpecialFieldsToolStripMenuItem.Image = global::MailMerge_Designer.Properties.Resources.special;
            this.insertSpecialFieldsToolStripMenuItem.Name = "insertSpecialFieldsToolStripMenuItem";
            this.insertSpecialFieldsToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.insertSpecialFieldsToolStripMenuItem.Text = "Insert &Special Fields";
            // 
            // iFFieldToolStripMenuItem1
            // 
            this.iFFieldToolStripMenuItem1.Name = "iFFieldToolStripMenuItem1";
            this.iFFieldToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.iFFieldToolStripMenuItem1.Text = "IF Field";
            this.iFFieldToolStripMenuItem1.Click += new System.EventHandler(this.iFFieldToolStripMenuItem1_Click);
            // 
            // includeTextToolStripMenuItem1
            // 
            this.includeTextToolStripMenuItem1.Name = "includeTextToolStripMenuItem1";
            this.includeTextToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.includeTextToolStripMenuItem1.Text = "IncludeText";
            this.includeTextToolStripMenuItem1.Click += new System.EventHandler(this.includeTextToolStripMenuItem1_Click);
            // 
            // dateToolStripMenuItem1
            // 
            this.dateToolStripMenuItem1.Name = "dateToolStripMenuItem1";
            this.dateToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.dateToolStripMenuItem1.Text = "Date";
            this.dateToolStripMenuItem1.Click += new System.EventHandler(this.dateToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(232, 6);
            // 
            // showAllToolStripMenuItem
            // 
            this.showAllToolStripMenuItem.Image = global::MailMerge_Designer.Properties.Resources.show_field_codes;
            this.showAllToolStripMenuItem.Name = "showAllToolStripMenuItem";
            this.showAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.F9)));
            this.showAllToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.showAllToolStripMenuItem.Text = "Show All Field &Codes";
            this.showAllToolStripMenuItem.Click += new System.EventHandler(this.showAllToolStripMenuItem_Click);
            // 
            // showAllFieldResultsToolStripMenuItem
            // 
            this.showAllFieldResultsToolStripMenuItem.Image = global::MailMerge_Designer.Properties.Resources.show_field_text;
            this.showAllFieldResultsToolStripMenuItem.Name = "showAllFieldResultsToolStripMenuItem";
            this.showAllFieldResultsToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.showAllFieldResultsToolStripMenuItem.Text = "Show All Field &Results";
            this.showAllFieldResultsToolStripMenuItem.Click += new System.EventHandler(this.showAllFieldResultsToolStripMenuItem_Click);
            // 
            // showPreviewToolStripMenuItem
            // 
            this.showPreviewToolStripMenuItem.Image = global::MailMerge_Designer.Properties.Resources.preview;
            this.showPreviewToolStripMenuItem.Name = "showPreviewToolStripMenuItem";
            this.showPreviewToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.showPreviewToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.showPreviewToolStripMenuItem.Text = "Show Preview";
            this.showPreviewToolStripMenuItem.Click += new System.EventHandler(this.showPreviewToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(232, 6);
            // 
            // deleteFieldToolStripMenuItem
            // 
            this.deleteFieldToolStripMenuItem.Image = global::MailMerge_Designer.Properties.Resources.delete_field;
            this.deleteFieldToolStripMenuItem.Name = "deleteFieldToolStripMenuItem";
            this.deleteFieldToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.deleteFieldToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.deleteFieldToolStripMenuItem.Text = "Delete Field";
            this.deleteFieldToolStripMenuItem.Click += new System.EventHandler(this.deleteFieldToolStripMenuItem_Click);
            // 
            // fieldSettingsToolStripMenuItem
            // 
            this.fieldSettingsToolStripMenuItem.Image = global::MailMerge_Designer.Properties.Resources.field_settings;
            this.fieldSettingsToolStripMenuItem.Name = "fieldSettingsToolStripMenuItem";
            this.fieldSettingsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F2)));
            this.fieldSettingsToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.fieldSettingsToolStripMenuItem.Text = "Field Settings";
            this.fieldSettingsToolStripMenuItem.Click += new System.EventHandler(this.fieldSettingsToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(232, 6);
            // 
            // nextRecordToolStripMenuItem
            // 
            this.nextRecordToolStripMenuItem.Name = "nextRecordToolStripMenuItem";
            this.nextRecordToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.nextRecordToolStripMenuItem.Text = "&Next Record";
            this.nextRecordToolStripMenuItem.Click += new System.EventHandler(this.nextRecordToolStripMenuItem_Click);
            // 
            // previousRecordToolStripMenuItem
            // 
            this.previousRecordToolStripMenuItem.Name = "previousRecordToolStripMenuItem";
            this.previousRecordToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.previousRecordToolStripMenuItem.Text = "&Previous Record";
            this.previousRecordToolStripMenuItem.Click += new System.EventHandler(this.previousRecordToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(232, 6);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Enabled = false;
            this.exportToolStripMenuItem.Image = global::MailMerge_Designer.Properties.Resources.export;
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(235, 22);
            this.exportToolStripMenuItem.Text = "&Export";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSelectRecipients,
            this.tslDatabaseName,
            this.tscbDataTables,
            this.toolStripSeparator2,
            this.tsbInsertField,
            this.tsbSpecialFields,
            this.toolStripSeparator1,
            this.tsbShowFieldCodes,
            this.tsbShowFieldText,
            this.tsbPreview,
            this.toolStripSeparator3,
            this.tsbFieldDelete,
            this.tsbFieldSettings,
            this.toolStripSeparator4,
            this.tsbExport});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(939, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSelectRecipients
            // 
            this.tsbSelectRecipients.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSelectRecipients.Image = global::MailMerge_Designer.Properties.Resources.select_recipients;
            this.tsbSelectRecipients.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSelectRecipients.Name = "tsbSelectRecipients";
            this.tsbSelectRecipients.Size = new System.Drawing.Size(23, 22);
            this.tsbSelectRecipients.Text = "toolStripSplitButton1";
            this.tsbSelectRecipients.ToolTipText = "Select recipients";
            this.tsbSelectRecipients.Click += new System.EventHandler(this.tsbSelectRecipients_Click);
            // 
            // tslDatabaseName
            // 
            this.tslDatabaseName.Name = "tslDatabaseName";
            this.tslDatabaseName.Size = new System.Drawing.Size(0, 22);
            // 
            // tscbDataTables
            // 
            this.tscbDataTables.Name = "tscbDataTables";
            this.tscbDataTables.Size = new System.Drawing.Size(121, 25);
            this.tscbDataTables.ToolTipText = "Select DataTable";
            this.tscbDataTables.SelectedIndexChanged += new System.EventHandler(this.tscbDataTables_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbInsertField
            // 
            this.tsbInsertField.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbInsertField.Enabled = false;
            this.tsbInsertField.Image = global::MailMerge_Designer.Properties.Resources.insert_field;
            this.tsbInsertField.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInsertField.Name = "tsbInsertField";
            this.tsbInsertField.Size = new System.Drawing.Size(29, 22);
            this.tsbInsertField.Text = "toolStripButton1";
            this.tsbInsertField.ToolTipText = "Insert fields";
            // 
            // tsbSpecialFields
            // 
            this.tsbSpecialFields.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSpecialFields.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iFFieldToolStripMenuItem,
            this.includeTextToolStripMenuItem,
            this.dateToolStripMenuItem});
            this.tsbSpecialFields.Enabled = false;
            this.tsbSpecialFields.Image = global::MailMerge_Designer.Properties.Resources.special;
            this.tsbSpecialFields.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSpecialFields.Name = "tsbSpecialFields";
            this.tsbSpecialFields.Size = new System.Drawing.Size(29, 22);
            this.tsbSpecialFields.Text = "toolStripDropDownButton1";
            this.tsbSpecialFields.ToolTipText = "Insert special fields";
            // 
            // iFFieldToolStripMenuItem
            // 
            this.iFFieldToolStripMenuItem.Name = "iFFieldToolStripMenuItem";
            this.iFFieldToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.iFFieldToolStripMenuItem.Text = "IF Field";
            this.iFFieldToolStripMenuItem.Click += new System.EventHandler(this.iFFieldToolStripMenuItem_Click);
            // 
            // includeTextToolStripMenuItem
            // 
            this.includeTextToolStripMenuItem.Name = "includeTextToolStripMenuItem";
            this.includeTextToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.includeTextToolStripMenuItem.Text = "IncludeText";
            this.includeTextToolStripMenuItem.Click += new System.EventHandler(this.includeTextToolStripMenuItem_Click);
            // 
            // dateToolStripMenuItem
            // 
            this.dateToolStripMenuItem.Name = "dateToolStripMenuItem";
            this.dateToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.dateToolStripMenuItem.Text = "Date";
            this.dateToolStripMenuItem.Click += new System.EventHandler(this.dateToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbShowFieldCodes
            // 
            this.tsbShowFieldCodes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbShowFieldCodes.Image = global::MailMerge_Designer.Properties.Resources.show_field_codes;
            this.tsbShowFieldCodes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowFieldCodes.Name = "tsbShowFieldCodes";
            this.tsbShowFieldCodes.Size = new System.Drawing.Size(23, 22);
            this.tsbShowFieldCodes.Text = "toolStripButton2";
            this.tsbShowFieldCodes.ToolTipText = "Show field codes";
            this.tsbShowFieldCodes.Click += new System.EventHandler(this.tsbShowFieldCodes_Click);
            // 
            // tsbShowFieldText
            // 
            this.tsbShowFieldText.Checked = true;
            this.tsbShowFieldText.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsbShowFieldText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbShowFieldText.Image = global::MailMerge_Designer.Properties.Resources.show_field_text;
            this.tsbShowFieldText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbShowFieldText.Name = "tsbShowFieldText";
            this.tsbShowFieldText.Size = new System.Drawing.Size(23, 22);
            this.tsbShowFieldText.Text = "toolStripButton3";
            this.tsbShowFieldText.ToolTipText = "Show field text";
            this.tsbShowFieldText.Click += new System.EventHandler(this.tsbShowFieldText_Click);
            // 
            // tsbPreview
            // 
            this.tsbPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPreview.Image = global::MailMerge_Designer.Properties.Resources.preview;
            this.tsbPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPreview.Name = "tsbPreview";
            this.tsbPreview.Size = new System.Drawing.Size(23, 22);
            this.tsbPreview.Text = "toolStripButton1";
            this.tsbPreview.ToolTipText = "Preview merge fields";
            this.tsbPreview.CheckStateChanged += new System.EventHandler(this.tsbPreview_CheckStateChanged);
            this.tsbPreview.Click += new System.EventHandler(this.tsbPreview_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbFieldDelete
            // 
            this.tsbFieldDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFieldDelete.Enabled = false;
            this.tsbFieldDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbFieldDelete.Image")));
            this.tsbFieldDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFieldDelete.Name = "tsbFieldDelete";
            this.tsbFieldDelete.Size = new System.Drawing.Size(23, 22);
            this.tsbFieldDelete.Text = "toolStripButton1";
            this.tsbFieldDelete.ToolTipText = "Delete field";
            this.tsbFieldDelete.Click += new System.EventHandler(this.tsbFieldDelete_Click);
            // 
            // tsbFieldSettings
            // 
            this.tsbFieldSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbFieldSettings.Enabled = false;
            this.tsbFieldSettings.Image = global::MailMerge_Designer.Properties.Resources.field_settings;
            this.tsbFieldSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFieldSettings.Name = "tsbFieldSettings";
            this.tsbFieldSettings.Size = new System.Drawing.Size(23, 22);
            this.tsbFieldSettings.Text = "toolStripButton2";
            this.tsbFieldSettings.ToolTipText = "Field settings";
            this.tsbFieldSettings.Click += new System.EventHandler(this.tsbFieldSettings_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbExport
            // 
            this.tsbExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExport.Enabled = false;
            this.tsbExport.Image = global::MailMerge_Designer.Properties.Resources.export;
            this.tsbExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExport.Name = "tsbExport";
            this.tsbExport.Size = new System.Drawing.Size(23, 22);
            this.tsbExport.Text = "toolStripButton3";
            this.tsbExport.ToolTipText = "Export documents";
            this.tsbExport.Click += new System.EventHandler(this.tsbExport_Click);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bindingSource1;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Enabled = false;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 49);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(939, 25);
            this.bindingNavigator1.TabIndex = 7;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // bindingSource1
            // 
            this.bindingSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // cmField
            // 
            this.cmField.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem8,
            this.toolStripMenuItem9});
            this.cmField.Name = "contextMenuStrip1";
            this.cmField.Size = new System.Drawing.Size(145, 48);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Image = global::MailMerge_Designer.Properties.Resources.delete_field;
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItem8.Text = "Delete Field";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.toolStripMenuItem8_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Image = global::MailMerge_Designer.Properties.Resources.field_settings;
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItem9.Text = "Field Settings";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItem9_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 461);
            this.Controls.Add(this.textControl1);
            this.Controls.Add(this.rulerBar1);
            this.Controls.Add(this.rulerBar2);
            this.Controls.Add(this.buttonBar1);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "TX Text Control Mail Merge Designer: [New Template]";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.cmField.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TXTextControl.TextControl textControl1;
        private TXTextControl.RulerBar rulerBar1;
        private TXTextControl.StatusBar statusBar1;
        private TXTextControl.ButtonBar buttonBar1;
        private TXTextControl.RulerBar rulerBar2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem mailMergeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectRecipientToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem insertMergeFieldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllFieldResultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem nextRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem previousRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton tsbShowFieldCodes;
        private System.Windows.Forms.ToolStripButton tsbShowFieldText;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripDropDownButton tsbInsertField;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripButton tsbSelectRecipients;
        private System.Windows.Forms.ToolStripComboBox tscbDataTables;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel tslDatabaseName;
        private System.Windows.Forms.ToolStripButton tsbFieldDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbFieldSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripButton tsbExport;
        private System.Windows.Forms.ToolStripMenuItem showPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteFieldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fieldSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ContextMenuStrip cmField;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripDropDownButton tsbSpecialFields;
        private System.Windows.Forms.ToolStripMenuItem iFFieldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem includeTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertSpecialFieldsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iFFieldToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem includeTextToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem dateToolStripMenuItem1;
    }
}

