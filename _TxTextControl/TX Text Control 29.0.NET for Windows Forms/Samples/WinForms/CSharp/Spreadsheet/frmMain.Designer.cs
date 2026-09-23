namespace Spreadsheet
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
            this.rulerBar2 = new TXTextControl.RulerBar();
            this.statusBar1 = new TXTextControl.StatusBar();
            this.rulerBar1 = new TXTextControl.RulerBar();
            this.tsFormula = new System.Windows.Forms.ToolStrip();
            this.tscbFunctions = new System.Windows.Forms.ToolStripComboBox();
            this.tsBtnAddFunction = new System.Windows.Forms.ToolStripButton();
            this.tstbFormula = new System.Windows.Forms.ToolStripTextBox();
            this.tsBtnAccept = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsBtnTextFormat = new System.Windows.Forms.ToolStripButton();
            this.tsBtnNumberFormat = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tscbFormats = new System.Windows.Forms.ToolStripComboBox();
            this.tsBtnApplyNumberFormat = new System.Windows.Forms.ToolStripButton();
            this.tsFormulaSettings = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tsBtnR1C1 = new System.Windows.Forms.ToolStripButton();
            this.tsBtnA1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnCalculation = new System.Windows.Forms.ToolStripButton();
            this.ttInfo = new System.Windows.Forms.ToolTip(this.components);
            this.tsFormula.SuspendLayout();
            this.tsFormulaSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // textControl1
            // 
            this.textControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textControl1.Font = new System.Drawing.Font("Arial", 10F);
            this.textControl1.Location = new System.Drawing.Point(25, 75);
            this.textControl1.Name = "textControl1";
            this.textControl1.RulerBar = this.rulerBar2;
            this.textControl1.Size = new System.Drawing.Size(1296, 639);
            this.textControl1.StatusBar = this.statusBar1;
            this.textControl1.TabIndex = 0;
            this.textControl1.UserNames = null;
            this.textControl1.VerticalRulerBar = this.rulerBar1;
            this.textControl1.InputPositionChanged += new System.EventHandler(this.textControl1_InputPositionChanged);
            // 
            // rulerBar2
            // 
            this.rulerBar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.rulerBar2.Location = new System.Drawing.Point(0, 50);
            this.rulerBar2.Name = "rulerBar2";
            this.rulerBar2.Size = new System.Drawing.Size(1321, 25);
            this.rulerBar2.TabIndex = 2;
            this.rulerBar2.Text = "rulerBar2";
            // 
            // statusBar1
            // 
            this.statusBar1.BackColor = System.Drawing.SystemColors.Control;
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar1.Location = new System.Drawing.Point(0, 714);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(1321, 22);
            this.statusBar1.TabIndex = 3;
            // 
            // rulerBar1
            // 
            this.rulerBar1.Alignment = TXTextControl.RulerBarAlignment.Left;
            this.rulerBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.rulerBar1.Location = new System.Drawing.Point(0, 75);
            this.rulerBar1.Name = "rulerBar1";
            this.rulerBar1.Size = new System.Drawing.Size(25, 639);
            this.rulerBar1.TabIndex = 1;
            this.rulerBar1.Text = "rulerBar1";
            // 
            // tsFormula
            // 
            this.tsFormula.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbFunctions,
            this.tsBtnAddFunction,
            this.tstbFormula,
            this.tsBtnAccept,
            this.tsBtnRemove,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.tsBtnTextFormat,
            this.tsBtnNumberFormat,
            this.toolStripLabel2,
            this.tscbFormats,
            this.tsBtnApplyNumberFormat});
            this.tsFormula.Location = new System.Drawing.Point(0, 25);
            this.tsFormula.Name = "tsFormula";
            this.tsFormula.Size = new System.Drawing.Size(1321, 25);
            this.tsFormula.TabIndex = 4;
            this.tsFormula.Text = "toolStrip1";
            // 
            // tscbFunctions
            // 
            this.tscbFunctions.Name = "tscbFunctions";
            this.tscbFunctions.Size = new System.Drawing.Size(121, 25);
            // 
            // tsBtnAddFunction
            // 
            this.tsBtnAddFunction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnAddFunction.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnAddFunction.Image")));
            this.tsBtnAddFunction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAddFunction.Name = "tsBtnAddFunction";
            this.tsBtnAddFunction.Size = new System.Drawing.Size(23, 22);
            this.tsBtnAddFunction.Text = "toolStripButton1";
            this.tsBtnAddFunction.ToolTipText = "Add function";
            this.tsBtnAddFunction.Click += new System.EventHandler(this.tsBtnAddFunction_Click);
            // 
            // tstbFormula
            // 
            this.tstbFormula.Name = "tstbFormula";
            this.tstbFormula.Size = new System.Drawing.Size(300, 25);
            this.tstbFormula.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tstbFormula_KeyPress);
            this.tstbFormula.TextChanged += new System.EventHandler(this.tstbFormula_TextChanged);
            // 
            // tsBtnAccept
            // 
            this.tsBtnAccept.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnAccept.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnAccept.Image")));
            this.tsBtnAccept.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAccept.Name = "tsBtnAccept";
            this.tsBtnAccept.Size = new System.Drawing.Size(23, 22);
            this.tsBtnAccept.Text = "toolStripButton2";
            this.tsBtnAccept.ToolTipText = "Accept formula";
            this.tsBtnAccept.Click += new System.EventHandler(this.tsBtnAccept_Click);
            // 
            // tsBtnRemove
            // 
            this.tsBtnRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnRemove.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnRemove.Image")));
            this.tsBtnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRemove.Name = "tsBtnRemove";
            this.tsBtnRemove.Size = new System.Drawing.Size(23, 22);
            this.tsBtnRemove.Text = "toolStripButton3";
            this.tsBtnRemove.ToolTipText = "Remove formula";
            this.tsBtnRemove.Click += new System.EventHandler(this.tsBtnRemove_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(82, 22);
            this.toolStripLabel1.Text = "Cell Text Type:";
            // 
            // tsBtnTextFormat
            // 
            this.tsBtnTextFormat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnTextFormat.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnTextFormat.Image")));
            this.tsBtnTextFormat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnTextFormat.Name = "tsBtnTextFormat";
            this.tsBtnTextFormat.Size = new System.Drawing.Size(23, 22);
            this.tsBtnTextFormat.Text = "toolStripButton4";
            this.tsBtnTextFormat.ToolTipText = "Text Format";
            this.tsBtnTextFormat.Click += new System.EventHandler(this.tsBtnTextFormat_Click);
            // 
            // tsBtnNumberFormat
            // 
            this.tsBtnNumberFormat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnNumberFormat.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnNumberFormat.Image")));
            this.tsBtnNumberFormat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnNumberFormat.Name = "tsBtnNumberFormat";
            this.tsBtnNumberFormat.Size = new System.Drawing.Size(23, 22);
            this.tsBtnNumberFormat.Text = "toolStripButton5";
            this.tsBtnNumberFormat.ToolTipText = "Number Format";
            this.tsBtnNumberFormat.Click += new System.EventHandler(this.tsBtnNumberFormat_Click);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(95, 22);
            this.toolStripLabel2.Text = "Number Format:";
            // 
            // tscbFormats
            // 
            this.tscbFormats.Name = "tscbFormats";
            this.tscbFormats.Size = new System.Drawing.Size(121, 25);
            // 
            // tsBtnApplyNumberFormat
            // 
            this.tsBtnApplyNumberFormat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnApplyNumberFormat.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnApplyNumberFormat.Image")));
            this.tsBtnApplyNumberFormat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnApplyNumberFormat.Name = "tsBtnApplyNumberFormat";
            this.tsBtnApplyNumberFormat.Size = new System.Drawing.Size(23, 22);
            this.tsBtnApplyNumberFormat.Text = "toolStripButton1";
            this.tsBtnApplyNumberFormat.Click += new System.EventHandler(this.tsBtnApplyNumberFormat_Click);
            // 
            // tsFormulaSettings
            // 
            this.tsFormulaSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.tsBtnR1C1,
            this.tsBtnA1,
            this.toolStripSeparator2,
            this.tsBtnCalculation});
            this.tsFormulaSettings.Location = new System.Drawing.Point(0, 0);
            this.tsFormulaSettings.Name = "tsFormulaSettings";
            this.tsFormulaSettings.Size = new System.Drawing.Size(1321, 25);
            this.tsFormulaSettings.TabIndex = 6;
            this.tsFormulaSettings.Text = "toolStrip1";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(90, 22);
            this.toolStripLabel3.Text = "Reference Style:";
            // 
            // tsBtnR1C1
            // 
            this.tsBtnR1C1.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnR1C1.Image")));
            this.tsBtnR1C1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnR1C1.Name = "tsBtnR1C1";
            this.tsBtnR1C1.Size = new System.Drawing.Size(54, 22);
            this.tsBtnR1C1.Text = "R1C1";
            this.tsBtnR1C1.Click += new System.EventHandler(this.tsBtnR1C1_Click);
            // 
            // tsBtnA1
            // 
            this.tsBtnA1.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnA1.Image")));
            this.tsBtnA1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnA1.Name = "tsBtnA1";
            this.tsBtnA1.Size = new System.Drawing.Size(41, 22);
            this.tsBtnA1.Text = "A1";
            this.tsBtnA1.Click += new System.EventHandler(this.tsBtnA1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtnCalculation
            // 
            this.tsBtnCalculation.CheckOnClick = true;
            this.tsBtnCalculation.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCalculation.Image")));
            this.tsBtnCalculation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCalculation.Name = "tsBtnCalculation";
            this.tsBtnCalculation.Size = new System.Drawing.Size(125, 22);
            this.tsBtnCalculation.Text = "Enable Calculation";
            this.tsBtnCalculation.Click += new System.EventHandler(this.tsBtnCalculation_Click);
            // 
            // ttInfo
            // 
            this.ttInfo.IsBalloon = true;
            this.ttInfo.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttInfo.ToolTipTitle = "Next Step";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 736);
            this.Controls.Add(this.textControl1);
            this.Controls.Add(this.rulerBar1);
            this.Controls.Add(this.rulerBar2);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.tsFormula);
            this.Controls.Add(this.tsFormulaSettings);
            this.Name = "frmMain";
            this.Text = "Spreadsheet Sample";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResizeBegin += new System.EventHandler(this.tstbFormula_TextChanged);
            this.Move += new System.EventHandler(this.tstbFormula_TextChanged);
            this.tsFormula.ResumeLayout(false);
            this.tsFormula.PerformLayout();
            this.tsFormulaSettings.ResumeLayout(false);
            this.tsFormulaSettings.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TXTextControl.TextControl textControl1;
        private TXTextControl.RulerBar rulerBar2;
        private TXTextControl.StatusBar statusBar1;
        private TXTextControl.RulerBar rulerBar1;
        private System.Windows.Forms.ToolStrip tsFormula;
        private System.Windows.Forms.ToolStripComboBox tscbFunctions;
        private System.Windows.Forms.ToolStripButton tsBtnAddFunction;
        private System.Windows.Forms.ToolStripButton tsBtnAccept;
        private System.Windows.Forms.ToolStripButton tsBtnRemove;
        private System.Windows.Forms.ToolStripTextBox tstbFormula;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tsBtnTextFormat;
        private System.Windows.Forms.ToolStripButton tsBtnNumberFormat;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox tscbFormats;
        private System.Windows.Forms.ToolStripButton tsBtnApplyNumberFormat;
        private System.Windows.Forms.ToolStrip tsFormulaSettings;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripButton tsBtnR1C1;
        private System.Windows.Forms.ToolStripButton tsBtnA1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsBtnCalculation;
        private System.Windows.Forms.ToolTip ttInfo;
    }
}

