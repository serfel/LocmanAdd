/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Quote Generator Sample
** description:	This sample program shows how to use Text Control in office applications.  						
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace QuoteGenerator {

    public class frmEditor : System.Windows.Forms.Form {

        #region Windows Form Designer generated code


        private TXTextControl.ButtonBar buttonBar1;
        private TXTextControl.RulerBar rulerBar1;
        private TXTextControl.StatusBar statusBar1;
        private TXTextControl.TextControl textControl1;
        private TXTextControl.RulerBar rulerBar2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem printToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem deleteTableLinesToolStripMenuItem;
        private ToolStripMenuItem formatToolStripMenuItem;
        private ToolStripMenuItem tableToolStripMenuItem;
        private ToolStripMenuItem insertToolStripMenuItem;
        private ToolStripMenuItem articleToolStripMenuItem;
        private ToolStripMenuItem advancedToolStripMenuItem;
        private ToolStripMenuItem stylesheetToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem insertToolStripMenuItem1;
        private ToolStripMenuItem fieldToolStripMenuItem;
        private ToolStripMenuItem tableToolStripMenuItem1;
        private ToolStripMenuItem addressToolStripMenuItem;
        private ToolStripMenuItem dateToolStripMenuItem;
        private ToolStripMenuItem customerNoToolStripMenuItem;
        private ToolStripMenuItem customerNameToolStripMenuItem;
        private ToolStripMenuItem articleListToolStripMenuItem;
        private IContainer components = null;

        public frmEditor() {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }


        private void InitializeComponent() {
            this.buttonBar1 = new TXTextControl.ButtonBar();
            this.rulerBar1 = new TXTextControl.RulerBar();
            this.statusBar1 = new TXTextControl.StatusBar();
            this.textControl1 = new TXTextControl.TextControl();
            this.rulerBar2 = new TXTextControl.RulerBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTableLinesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.articleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.advancedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stylesheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fieldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerNoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.articleListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonBar1
            // 
            this.buttonBar1.BackColor = System.Drawing.SystemColors.Control;
            this.buttonBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonBar1.Location = new System.Drawing.Point(0, 24);
            this.buttonBar1.Name = "buttonBar1";
            this.buttonBar1.Size = new System.Drawing.Size(934, 28);
            this.buttonBar1.TabIndex = 0;
            this.buttonBar1.TabStop = false;
            this.buttonBar1.Text = "buttonBar1";
            // 
            // rulerBar1
            // 
            this.rulerBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.rulerBar1.Location = new System.Drawing.Point(0, 52);
            this.rulerBar1.Name = "rulerBar1";
            this.rulerBar1.Size = new System.Drawing.Size(934, 25);
            this.rulerBar1.TabIndex = 1;
            this.rulerBar1.TabStop = false;
            this.rulerBar1.Text = "rulerBar1";
            // 
            // statusBar1
            // 
            this.statusBar1.BackColor = System.Drawing.SystemColors.Control;
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar1.Location = new System.Drawing.Point(0, 439);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(934, 22);
            this.statusBar1.TabIndex = 2;
            this.statusBar1.TabStop = false;
            // 
            // textControl1
            // 
            this.textControl1.AllowDrag = true;
            this.textControl1.AllowDrop = true;
            this.textControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textControl1.Font = new System.Drawing.Font("Arial", 10F);
            this.textControl1.Location = new System.Drawing.Point(25, 77);
            this.textControl1.Name = "textControl1";
            this.textControl1.PageMargins.Bottom = 79.03;
            this.textControl1.PageMargins.Left = 79.03;
            this.textControl1.PageMargins.Right = 79.03;
            this.textControl1.PageMargins.Top = 79.03;
            this.textControl1.Size = new System.Drawing.Size(909, 362);
            this.textControl1.TabIndex = 3;
            this.textControl1.Changed += new System.EventHandler(this.textControl1_Changed);
            this.textControl1.TextFieldClicked += new TXTextControl.TextFieldEventHandler(this.textControl1_TextFieldClicked);
            // 
            // rulerBar2
            // 
            this.rulerBar2.Alignment = TXTextControl.RulerBarAlignment.Left;
            this.rulerBar2.Dock = System.Windows.Forms.DockStyle.Left;
            this.rulerBar2.Location = new System.Drawing.Point(0, 77);
            this.rulerBar2.Name = "rulerBar2";
            this.rulerBar2.Size = new System.Drawing.Size(25, 362);
            this.rulerBar2.TabIndex = 4;
            this.rulerBar2.Text = "rulerBar2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.formatToolStripMenuItem,
            this.insertToolStripMenuItem,
            this.advancedToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(934, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.printToolStripMenuItem.Text = "&Print...";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(105, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteTableLinesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            this.editToolStripMenuItem.DropDownOpening += new System.EventHandler(this.editToolStripMenuItem_DropDownOpening);
            // 
            // deleteTableLinesToolStripMenuItem
            // 
            this.deleteTableLinesToolStripMenuItem.Name = "deleteTableLinesToolStripMenuItem";
            this.deleteTableLinesToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.deleteTableLinesToolStripMenuItem.Text = "&Delete Table Lines";
            this.deleteTableLinesToolStripMenuItem.Click += new System.EventHandler(this.deleteTableLinesToolStripMenuItem_Click);
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tableToolStripMenuItem});
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.formatToolStripMenuItem.Text = "&Format";
            // 
            // tableToolStripMenuItem
            // 
            this.tableToolStripMenuItem.Name = "tableToolStripMenuItem";
            this.tableToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.tableToolStripMenuItem.Text = "&Table";
            this.tableToolStripMenuItem.Click += new System.EventHandler(this.tableToolStripMenuItem_Click);
            // 
            // insertToolStripMenuItem
            // 
            this.insertToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.articleToolStripMenuItem});
            this.insertToolStripMenuItem.Name = "insertToolStripMenuItem";
            this.insertToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.insertToolStripMenuItem.Text = "&Insert";
            // 
            // articleToolStripMenuItem
            // 
            this.articleToolStripMenuItem.Name = "articleToolStripMenuItem";
            this.articleToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.articleToolStripMenuItem.Text = "&Article";
            this.articleToolStripMenuItem.Click += new System.EventHandler(this.articleToolStripMenuItem_Click);
            // 
            // advancedToolStripMenuItem
            // 
            this.advancedToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stylesheetToolStripMenuItem});
            this.advancedToolStripMenuItem.Name = "advancedToolStripMenuItem";
            this.advancedToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.advancedToolStripMenuItem.Text = "&Advanced";
            // 
            // stylesheetToolStripMenuItem
            // 
            this.stylesheetToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.insertToolStripMenuItem1});
            this.stylesheetToolStripMenuItem.Name = "stylesheetToolStripMenuItem";
            this.stylesheetToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.stylesheetToolStripMenuItem.Text = "&Stylesheet";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.loadToolStripMenuItem.Text = "&Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // insertToolStripMenuItem1
            // 
            this.insertToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fieldToolStripMenuItem,
            this.tableToolStripMenuItem1});
            this.insertToolStripMenuItem1.Name = "insertToolStripMenuItem1";
            this.insertToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.insertToolStripMenuItem1.Text = "&Insert";
            // 
            // fieldToolStripMenuItem
            // 
            this.fieldToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addressToolStripMenuItem,
            this.dateToolStripMenuItem,
            this.customerNoToolStripMenuItem,
            this.customerNameToolStripMenuItem});
            this.fieldToolStripMenuItem.Name = "fieldToolStripMenuItem";
            this.fieldToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.fieldToolStripMenuItem.Text = "&Field";
            // 
            // addressToolStripMenuItem
            // 
            this.addressToolStripMenuItem.Name = "addressToolStripMenuItem";
            this.addressToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.addressToolStripMenuItem.Text = "&Address";
            this.addressToolStripMenuItem.Click += new System.EventHandler(this.addressToolStripMenuItem_Click);
            // 
            // dateToolStripMenuItem
            // 
            this.dateToolStripMenuItem.Name = "dateToolStripMenuItem";
            this.dateToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.dateToolStripMenuItem.Text = "&Date";
            this.dateToolStripMenuItem.Click += new System.EventHandler(this.dateToolStripMenuItem_Click);
            // 
            // customerNoToolStripMenuItem
            // 
            this.customerNoToolStripMenuItem.Name = "customerNoToolStripMenuItem";
            this.customerNoToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.customerNoToolStripMenuItem.Text = "Customer &No";
            this.customerNoToolStripMenuItem.Click += new System.EventHandler(this.customerNoToolStripMenuItem_Click);
            // 
            // customerNameToolStripMenuItem
            // 
            this.customerNameToolStripMenuItem.Name = "customerNameToolStripMenuItem";
            this.customerNameToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.customerNameToolStripMenuItem.Text = "&Customer Name";
            this.customerNameToolStripMenuItem.Click += new System.EventHandler(this.customerNameToolStripMenuItem_Click);
            // 
            // tableToolStripMenuItem1
            // 
            this.tableToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.articleListToolStripMenuItem});
            this.tableToolStripMenuItem1.Name = "tableToolStripMenuItem1";
            this.tableToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.tableToolStripMenuItem1.Text = "&Table";
            // 
            // articleListToolStripMenuItem
            // 
            this.articleListToolStripMenuItem.Name = "articleListToolStripMenuItem";
            this.articleListToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.articleListToolStripMenuItem.Text = "&Article List";
            this.articleListToolStripMenuItem.Click += new System.EventHandler(this.articleListToolStripMenuItem_Click);
            // 
            // frmEditor
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(934, 461);
            this.Controls.Add(this.textControl1);
            this.Controls.Add(this.rulerBar2);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.rulerBar1);
            this.Controls.Add(this.buttonBar1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmEditor";
            this.Text = "TX Text Control Quote Generator - Step 2";
            this.Load += new System.EventHandler(this.frmEditor_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        public string AddressField;
        public string CustomerIDField;
        public string DateField;
        public string DearXXField;
        public System.Data.DataSet ArticleData;
        private ArticleTable Table = new ArticleTable();

      
        //Events

        private void frmEditor_Load(object sender, System.EventArgs e) {

            // Load document template
            textControl1.Load("DocumentTemplate.tx", TXTextControl.StreamType.InternalFormat);

            // Fill template with data
            MacroField Field = new MacroField();
            Field.SelectByID(textControl1, MacroField.ID.FieldAddress).Text = AddressField;
            Field.SelectByID(textControl1, MacroField.ID.FieldCustomerID).Text = CustomerIDField;
            Field.SelectByID(textControl1, MacroField.ID.FieldDearXX).Text = DearXXField;
            Field.SelectByID(textControl1, MacroField.ID.FieldDate).Text = DateField;

            // Connect toolbars
            textControl1.StatusBar = statusBar1;
            textControl1.ButtonBar = buttonBar1;
            textControl1.RulerBar = rulerBar1;
            textControl1.VerticalRulerBar = rulerBar2;

        }

        private void textControl1_TextFieldClicked(object sender, TXTextControl.TextFieldEventArgs e) {
            MacroField Field = new MacroField();
        }

        private void textControl1_Changed(object sender, System.EventArgs e) {
            Table.TableChangeEvent(textControl1);
        }

       
        // File Menu 
        private void printToolStripMenuItem_Click(object sender, EventArgs e) {
            textControl1.Print(this.Text);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }
       

        // Edit Menu 
        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e) {
            deleteTableLinesToolStripMenuItem.Enabled = (textControl1.Tables.GetItem() != null);
        }

        private void deleteTableLinesToolStripMenuItem_Click(object sender, EventArgs e) {
            textControl1.Tables.GetItem().Rows.Remove();
        }
        

        // Format Menu 
        private void tableToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                textControl1.TableFormatDialog();
            } catch {
            }
        }

       

        // Insert Menu 

        private void articleToolStripMenuItem_Click(object sender, EventArgs e) {
            Table.InsertArticle(textControl1, ArticleData);
        }
        

        // Advanced Menu 
        private void loadToolStripMenuItem_Click(object sender, EventArgs e) {
            textControl1.Load("DocumentTemplate.tx", TXTextControl.StreamType.InternalFormat);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            textControl1.Save("DocumentTemplate.tx", TXTextControl.StreamType.InternalFormat);
        }

        private void addressToolStripMenuItem_Click(object sender, EventArgs e) {
            MacroField Field = new MacroField();
            Field.Create(textControl1, MacroField.ID.FieldAddress);
        }

        private void dateToolStripMenuItem_Click(object sender, EventArgs e) {
            MacroField Field = new MacroField();
            Field.Create(textControl1, MacroField.ID.FieldDate);
        }

        private void customerNoToolStripMenuItem_Click(object sender, EventArgs e) {
            MacroField Field = new MacroField();
            Field.Create(textControl1, MacroField.ID.FieldCustomerID);
        }

        private void customerNameToolStripMenuItem_Click(object sender, EventArgs e) {
            MacroField Field = new MacroField();
            Field.Create(textControl1, MacroField.ID.FieldDearXX);
        }

        private void articleListToolStripMenuItem_Click(object sender, EventArgs e) {
            textControl1.Tables.Add(5, 5, 10);
        }

        
























    }
}
