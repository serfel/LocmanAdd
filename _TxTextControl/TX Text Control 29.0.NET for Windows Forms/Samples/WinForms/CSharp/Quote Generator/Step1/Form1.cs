/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Quote Generator Sample
** description:	This sample program shows how to use Text Control in office applications.  						
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace QuoteGenerator {

    public class Form1 : System.Windows.Forms.Form {

        internal System.Windows.Forms.DataGrid gridAddress;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newQuoteToolStripMenuItem;
        private IContainer components = null;

        public Form1() {
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

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.gridAddress = new System.Windows.Forms.DataGrid();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newQuoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.gridAddress)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridAddress
            // 
            this.gridAddress.CaptionVisible = false;
            this.gridAddress.DataMember = "";
            this.gridAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridAddress.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridAddress.Location = new System.Drawing.Point(0, 33);
            this.gridAddress.Name = "gridAddress";
            this.gridAddress.ReadOnly = true;
            this.gridAddress.Size = new System.Drawing.Size(934, 428);
            this.gridAddress.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(934, 33);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newQuoteToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newQuoteToolStripMenuItem
            // 
            this.newQuoteToolStripMenuItem.Name = "newQuoteToolStripMenuItem";
            this.newQuoteToolStripMenuItem.Size = new System.Drawing.Size(204, 34);
            this.newQuoteToolStripMenuItem.Text = "&New Quote";
            this.newQuoteToolStripMenuItem.Click += new System.EventHandler(this.newQuoteToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
            this.ClientSize = new System.Drawing.Size(934, 461);
            this.Controls.Add(this.gridAddress);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "TX Text Control - Quote Generator Step 1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridAddress)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }


        DataSet dsAddress = new DataSet("address");

        // Load the 2 databases. As this is only a sample program, the 'databases' are
        // just two simple XML files which are in the program's source code folder. 															  '
        private void Form1_Load(object sender, System.EventArgs e) {
            // Open Address database and display it in a data grid
            dsAddress.ReadXml("address.xml");
            gridAddress.DataSource = dsAddress;
            gridAddress.DataMember = "address_record";
        }

        // Create a postal address field by combining various database fields, e.g.
        // Name, Street, ...
        private string CreateAddressField(int CurrentRow) {
            string sAddress = "";
            string sCompany = dsAddress.Tables[0].Rows[CurrentRow]["company"].ToString();
            string sName = dsAddress.Tables[0].Rows[CurrentRow]["name"].ToString();
            string sFirstName = dsAddress.Tables[0].Rows[CurrentRow]["first_name"].ToString();
            string sGender = dsAddress.Tables[0].Rows[CurrentRow]["gender"].ToString();
            string sStreet = dsAddress.Tables[0].Rows[CurrentRow]["street"].ToString();
            string sCity = dsAddress.Tables[0].Rows[CurrentRow]["city"].ToString();
            string sCountry = dsAddress.Tables[0].Rows[CurrentRow]["country"].ToString();

            // <company>
            if (sCompany != "")
                sAddress += sCompany + '\n';

            // Mr/Ms <first_name> <name>
            if (sName != "") {
                if (sGender != "")
                    if (sGender == "m")
                        sAddress += "Mr ";
                    else if (sGender == "f")
                        sAddress += "Ms ";

                if (sFirstName != "")
                    sAddress += sFirstName + " ";
                sAddress += sName;
            }
            sAddress += '\n';

            // <street>
            if (sStreet != "")
                sAddress += sStreet + '\n';

            // <city> and <country>
            if (sCity != "")
                sAddress += sCity + '\n';
            if (sCountry != "")
                sAddress += sCountry + '\n';

            return sAddress;
        }

        // Create a new forms editor and pass it the selected customer's address
        private void newQuoteToolStripMenuItem_Click(object sender, EventArgs e) {
            int CurrentRow = gridAddress.CurrentRowIndex;
            frmEditor Editor = new frmEditor();

            Editor.AddressField = CreateAddressField(CurrentRow);
            Editor.CustomerIDField = dsAddress.Tables[0].Rows[CurrentRow]["customer_id"].ToString();
            Editor.DateField = DateTime.Now.Date.ToLongDateString();
            Editor.DearXXField = dsAddress.Tables[0].Rows[CurrentRow]["dear_xx"].ToString();
            Editor.Show();
        }
    }
}
