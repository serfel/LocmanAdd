namespace Workflow
{
    partial class frmEditor
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
            this.ribbon1 = new TXTextControl.Windows.Forms.Ribbon.Ribbon();
            this.ribbonFormattingTab1 = new TXTextControl.Windows.Forms.Ribbon.RibbonFormattingTab();
            this.ribbonPermissionsTab1 = new TXTextControl.Windows.Forms.Ribbon.RibbonPermissionsTab();
            this.textControl1 = new TXTextControl.TextControl();
            this.statusBar1 = new TXTextControl.StatusBar();
            this.rulerBar1 = new TXTextControl.RulerBar();
            this.rulerBar2 = new TXTextControl.RulerBar();
            this.ribbon1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.Controls.Add(this.ribbonFormattingTab1);
            this.ribbon1.Controls.Add(this.ribbonPermissionsTab1);
            this.ribbon1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.HotTrack = true;
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Name = "ribbon1";
            this.ribbon1.ReadOnly = false;
            this.ribbon1.SelectedIndex = 2;
            this.ribbon1.Size = new System.Drawing.Size(940, 116);
            this.ribbon1.TabIndex = 1;
            // 
            // ribbonFormattingTab1
            // 
            this.ribbonFormattingTab1.Location = new System.Drawing.Point(4, 24);
            this.ribbonFormattingTab1.Name = "ribbonFormattingTab1";
            this.ribbonFormattingTab1.Size = new System.Drawing.Size(932, 88);
            this.ribbonFormattingTab1.TabIndex = 1;
            // 
            // ribbonPermissionsTab1
            // 
            this.ribbonPermissionsTab1.AllowAddingUserNames = true;
            this.ribbonPermissionsTab1.Location = new System.Drawing.Point(4, 24);
            this.ribbonPermissionsTab1.Name = "ribbonPermissionsTab1";
            this.ribbonPermissionsTab1.RegisteredUserNames = new string[0];
            this.ribbonPermissionsTab1.Size = new System.Drawing.Size(932, 88);
            this.ribbonPermissionsTab1.TabIndex = 2;
            // 
            // textControl1
            // 
            this.textControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textControl1.Font = new System.Drawing.Font("Arial", 10F);
            this.textControl1.Location = new System.Drawing.Point(25, 141);
            this.textControl1.Name = "textControl1";
            this.textControl1.PageMargins.Bottom = 78.75D;
            this.textControl1.PageMargins.Left = 78.75D;
            this.textControl1.PageMargins.Right = 78.75D;
            this.textControl1.PageMargins.Top = 78.75D;
            this.textControl1.PageSize.Height = 1169.31D;
            this.textControl1.PageSize.Width = 826.81D;
            this.textControl1.Ribbon = this.ribbon1;
            this.textControl1.RulerBar = this.rulerBar2;
            this.textControl1.Size = new System.Drawing.Size(915, 385);
            this.textControl1.StatusBar = this.statusBar1;
            this.textControl1.TabIndex = 1;
            this.textControl1.Text = "textControl1";
            this.textControl1.UserNames = null;
            this.textControl1.VerticalRulerBar = this.rulerBar1;
            // 
            // statusBar1
            // 
            this.statusBar1.BackColor = System.Drawing.SystemColors.Control;
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar1.Location = new System.Drawing.Point(0, 526);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(940, 22);
            this.statusBar1.TabIndex = 2;
            // 
            // rulerBar1
            // 
            this.rulerBar1.Alignment = TXTextControl.RulerBarAlignment.Left;
            this.rulerBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.rulerBar1.Location = new System.Drawing.Point(0, 141);
            this.rulerBar1.Name = "rulerBar1";
            this.rulerBar1.Size = new System.Drawing.Size(25, 385);
            this.rulerBar1.TabIndex = 3;
            this.rulerBar1.Text = "rulerBar1";
            // 
            // rulerBar2
            // 
            this.rulerBar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.rulerBar2.Location = new System.Drawing.Point(0, 116);
            this.rulerBar2.Name = "rulerBar2";
            this.rulerBar2.Size = new System.Drawing.Size(940, 25);
            this.rulerBar2.TabIndex = 4;
            this.rulerBar2.Text = "rulerBar2";
            // 
            // frmEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 548);
            this.Controls.Add(this.textControl1);
            this.Controls.Add(this.rulerBar1);
            this.Controls.Add(this.rulerBar2);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.ribbon1);
            this.Name = "frmEditor";
            this.Text = "Text Control Document Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEditor_FormClosing);
            this.Load += new System.EventHandler(this.frmEditor_Load);
            this.ribbon1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TXTextControl.Windows.Forms.Ribbon.Ribbon ribbon1;
        private TXTextControl.Windows.Forms.Ribbon.RibbonFormattingTab ribbonFormattingTab1;
        private TXTextControl.Windows.Forms.Ribbon.RibbonPermissionsTab ribbonPermissionsTab1;
        private TXTextControl.TextControl textControl1;
        private TXTextControl.RulerBar rulerBar2;
        private TXTextControl.StatusBar statusBar1;
        private TXTextControl.RulerBar rulerBar1;
    }
}