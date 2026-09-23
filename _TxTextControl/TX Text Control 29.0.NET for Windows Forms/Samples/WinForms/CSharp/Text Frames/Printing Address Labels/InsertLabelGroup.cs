/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Printing Address Labels Sample
** description:	Describes how you can control and manipulate text using text frames.						
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;

namespace Printing_Address_Labels {

    public class InsertLabelGroup : System.Windows.Forms.Form {

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLabelWidth;
        private System.Windows.Forms.TextBox txtLabelHeight;
        private System.Windows.Forms.TextBox txtPageMarginLeft;
        private System.Windows.Forms.TextBox txtSpaceHorizontal;
        private System.Windows.Forms.TextBox txtSpaceVertical;
        private System.Windows.Forms.NumericUpDown updownNoOfRows;
        private System.Windows.Forms.NumericUpDown updownNoOfColumns;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.TextBox txtPageMarginTop;
        private System.ComponentModel.Container components = null;

        public InsertLabelGroup() {
            
            // Required for Windows Form Designer support
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
        private void InitializeComponent() {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.updownNoOfColumns = new System.Windows.Forms.NumericUpDown();
            this.updownNoOfRows = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLabelHeight = new System.Windows.Forms.TextBox();
            this.txtLabelWidth = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPageMarginTop = new System.Windows.Forms.TextBox();
            this.txtPageMarginLeft = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtSpaceVertical = new System.Windows.Forms.TextBox();
            this.txtSpaceHorizontal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.updownNoOfColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownNoOfRows)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.updownNoOfColumns);
            this.groupBox1.Controls.Add(this.updownNoOfRows);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(208, 80);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Number of labels";
            // 
            // updownNoOfColumns
            // 
            this.updownNoOfColumns.Location = new System.Drawing.Point(144, 46);
            this.updownNoOfColumns.Name = "updownNoOfColumns";
            this.updownNoOfColumns.Size = new System.Drawing.Size(40, 20);
            this.updownNoOfColumns.TabIndex = 3;
            this.updownNoOfColumns.Value = new System.Decimal(new int[] {
																			3,
																			0,
																			0,
																			0});
            this.updownNoOfColumns.ValueChanged += new System.EventHandler(this.updownNoOfColumns_ValueChanged);
            // 
            // updownNoOfRows
            // 
            this.updownNoOfRows.Location = new System.Drawing.Point(144, 24);
            this.updownNoOfRows.Name = "updownNoOfRows";
            this.updownNoOfRows.Size = new System.Drawing.Size(40, 20);
            this.updownNoOfRows.TabIndex = 2;
            this.updownNoOfRows.Value = new System.Decimal(new int[] {
																		 5,
																		 0,
																		 0,
																		 0});
            this.updownNoOfRows.ValueChanged += new System.EventHandler(this.updownNoOfRows_ValueChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Number of columns:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of rows:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtLabelHeight);
            this.groupBox2.Controls.Add(this.txtLabelWidth);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(8, 96);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(208, 80);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Label size";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(152, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 16);
            this.label10.TabIndex = 7;
            this.label10.Text = "mm";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(152, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(24, 16);
            this.label9.TabIndex = 6;
            this.label9.Text = "mm";
            // 
            // txtLabelHeight
            // 
            this.txtLabelHeight.Location = new System.Drawing.Point(96, 46);
            this.txtLabelHeight.Name = "txtLabelHeight";
            this.txtLabelHeight.Size = new System.Drawing.Size(40, 20);
            this.txtLabelHeight.TabIndex = 5;
            this.txtLabelHeight.Text = "40";
            this.txtLabelHeight.TextChanged += new System.EventHandler(this.txtLabelHeight_TextChanged);
            // 
            // txtLabelWidth
            // 
            this.txtLabelWidth.Location = new System.Drawing.Point(96, 24);
            this.txtLabelWidth.Name = "txtLabelWidth";
            this.txtLabelWidth.Size = new System.Drawing.Size(40, 20);
            this.txtLabelWidth.TabIndex = 4;
            this.txtLabelWidth.Text = "50";
            this.txtLabelWidth.TextChanged += new System.EventHandler(this.txtLabelWidth_TextChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Height:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Width:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txtPageMarginTop);
            this.groupBox3.Controls.Add(this.txtPageMarginLeft);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(8, 184);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(208, 80);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Page margins";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(152, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 16);
            this.label12.TabIndex = 9;
            this.label12.Text = "mm";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(152, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(24, 16);
            this.label11.TabIndex = 8;
            this.label11.Text = "mm";
            // 
            // txtPageMarginTop
            // 
            this.txtPageMarginTop.Location = new System.Drawing.Point(96, 40);
            this.txtPageMarginTop.Name = "txtPageMarginTop";
            this.txtPageMarginTop.Size = new System.Drawing.Size(40, 20);
            this.txtPageMarginTop.TabIndex = 7;
            this.txtPageMarginTop.Text = "20";
            // 
            // txtPageMarginLeft
            // 
            this.txtPageMarginLeft.Location = new System.Drawing.Point(96, 16);
            this.txtPageMarginLeft.Name = "txtPageMarginLeft";
            this.txtPageMarginLeft.Size = new System.Drawing.Size(40, 20);
            this.txtPageMarginLeft.TabIndex = 6;
            this.txtPageMarginLeft.Text = "20";
            this.txtPageMarginLeft.TextChanged += new System.EventHandler(this.txtPageMarginLeft_TextChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Top:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(16, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "Left:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.txtSpaceVertical);
            this.groupBox4.Controls.Add(this.txtSpaceHorizontal);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Location = new System.Drawing.Point(8, 272);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(208, 80);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Space between labels";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(152, 40);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(24, 16);
            this.label14.TabIndex = 9;
            this.label14.Text = "mm";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(152, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(24, 16);
            this.label13.TabIndex = 8;
            this.label13.Text = "mm";
            // 
            // txtSpaceVertical
            // 
            this.txtSpaceVertical.Location = new System.Drawing.Point(96, 40);
            this.txtSpaceVertical.Name = "txtSpaceVertical";
            this.txtSpaceVertical.Size = new System.Drawing.Size(40, 20);
            this.txtSpaceVertical.TabIndex = 7;
            this.txtSpaceVertical.Text = "5";
            this.txtSpaceVertical.TextChanged += new System.EventHandler(this.txtSpaceVertical_TextChanged);
            // 
            // txtSpaceHorizontal
            // 
            this.txtSpaceHorizontal.Location = new System.Drawing.Point(96, 16);
            this.txtSpaceHorizontal.Name = "txtSpaceHorizontal";
            this.txtSpaceHorizontal.Size = new System.Drawing.Size(40, 20);
            this.txtSpaceHorizontal.TabIndex = 6;
            this.txtSpaceHorizontal.Text = "5";
            this.txtSpaceHorizontal.TextChanged += new System.EventHandler(this.txtSpaceHorizontal_TextChanged);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 48);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Vertical";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(16, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "Horizontal";
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(240, 16);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(88, 24);
            this.cmdOK.TabIndex = 2;
            this.cmdOK.Text = "OK";
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.Location = new System.Drawing.Point(240, 48);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(88, 24);
            this.cmdCancel.TabIndex = 3;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // InsertLabelGroup
            // 
            this.AcceptButton = this.cmdOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cmdCancel;
            this.ClientSize = new System.Drawing.Size(336, 358);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "InsertLabelGroup";
            this.Text = "Insert Label Group";
            this.Load += new System.EventHandler(this.InsertLabelGroup_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.updownNoOfColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownNoOfRows)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private int m_NoOfColumns;
        private int m_NoOfRows;
        private int m_LabelHeight;
        private int m_LabelWidth;
        private int m_PageMarginLeft;
        private int m_PageMarginTop;
        private int m_SpaceHorizontal;
        private int m_SpaceVertical;
        private int m_PageWidth;
        private int m_PageHeight;

        public int NoOfColumns {
            get {
                return m_NoOfColumns;
            }
        }

        public int NoOfRows {
            get {
                return m_NoOfRows;
            }
        }

        public int LabelHeight {
            get {
                return m_LabelHeight;
            }
        }

        public int LabelWidth {
            get {
                return m_LabelWidth;
            }
        }

        public int PageMarginLeft {
            get {
                return m_PageMarginLeft;
            }
        }

        public int PageMarginTop {
            get {
                return m_PageMarginTop;
            }
        }

        public int SpaceHorizontal {
            get {
                return m_SpaceHorizontal;
            }
        }

        public int SpaceVertical {
            get {
                return m_SpaceVertical;
            }
        }

        public int PageWidth {
            set {
                m_PageWidth = value;
            }
        }

        public int PageHeight {
            set {
                m_PageHeight = value;
            }
        }

        private void cmdCancel_Click(object sender, System.EventArgs e) {
            m_NoOfColumns = 0;
            m_NoOfRows = 0;
            Close();
        }

        private void cmdOK_Click(object sender, System.EventArgs e) {
            m_NoOfColumns = Convert.ToInt32(updownNoOfColumns.Text);
            m_NoOfRows = Convert.ToInt32(updownNoOfRows.Text);
            m_LabelHeight = Convert.ToInt32(txtLabelHeight.Text);
            m_LabelWidth = Convert.ToInt32(txtLabelWidth.Text);
            m_PageMarginLeft = Convert.ToInt32(txtPageMarginLeft.Text);
            m_PageMarginTop = Convert.ToInt32(txtPageMarginTop.Text);
            m_SpaceHorizontal = Convert.ToInt32(txtSpaceHorizontal.Text);
            m_SpaceVertical = Convert.ToInt32(txtSpaceVertical.Text);
            Close();
        }

        private bool CheckValues() {
            double ExtX, ExtY;

            try {
                // limit labels to one page
                ExtX = (Convert.ToDouble(txtPageMarginLeft.Text)
                    + Convert.ToDouble(updownNoOfColumns.Text) * Convert.ToDouble(txtLabelWidth.Text)
                    + (Convert.ToDouble(updownNoOfColumns.Text) - 1) * Convert.ToDouble(txtSpaceHorizontal.Text));

                ExtY = (Convert.ToInt32(txtPageMarginTop.Text)
                    + Convert.ToInt32(updownNoOfRows.Text) * Convert.ToInt32(txtLabelHeight.Text)
                    + (Convert.ToInt32(updownNoOfRows.Text) - 1) * Convert.ToInt32(txtSpaceVertical.Text));

            } catch {
                return false;
            }

            return (ExtX > 0) && (ExtX < m_PageWidth * 0.254) && (ExtY > 0) && (ExtY < m_PageHeight * 0.254);
        }

        private void txtLabelWidth_TextChanged(object sender, System.EventArgs e) {
            cmdOK.Enabled = CheckValues();
        }

        private void txtLabelHeight_TextChanged(object sender, System.EventArgs e) {
            cmdOK.Enabled = CheckValues();
        }

        private void txtPageMarginLeft_TextChanged(object sender, System.EventArgs e) {
            cmdOK.Enabled = CheckValues();
        }

        private void txtSpaceHorizontal_TextChanged(object sender, System.EventArgs e) {
            cmdOK.Enabled = CheckValues();
        }

        private void txtSpaceVertical_TextChanged(object sender, System.EventArgs e) {
            cmdOK.Enabled = CheckValues();
        }

        private void updownNoOfRows_ValueChanged(object sender, System.EventArgs e) {
            cmdOK.Enabled = CheckValues();
        }

        private void updownNoOfColumns_ValueChanged(object sender, System.EventArgs e) {
            cmdOK.Enabled = CheckValues();
        }

        private void InsertLabelGroup_Load(object sender, System.EventArgs e) {

        }
    }
}
