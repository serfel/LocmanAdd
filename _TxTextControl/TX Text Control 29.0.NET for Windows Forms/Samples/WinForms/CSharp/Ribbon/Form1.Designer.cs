namespace Tutorial
{
    partial class Form1
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
            this.textControl1 = new TXTextControl.TextControl();
            this.ribbon1 = new TXTextControl.Windows.Forms.Ribbon.Ribbon();
            this.m_rbtnLoad = new TXTextControl.Windows.Forms.Ribbon.RibbonButton();
            this.m_rbtnSave = new TXTextControl.Windows.Forms.Ribbon.RibbonButton();
            this.m_grpTableTools = new TXTextControl.Windows.Forms.Ribbon.ContextualTabGroup();
            this.ribbonTableLayoutTab1 = new TXTextControl.Windows.Forms.Ribbon.RibbonTableLayoutTab();
            this.m_grpFrameTools = new TXTextControl.Windows.Forms.Ribbon.ContextualTabGroup();
            this.ribbonFrameLayoutTab1 = new TXTextControl.Windows.Forms.Ribbon.RibbonFrameLayoutTab();
            this.ribbonFormattingTab1 = new TXTextControl.Windows.Forms.Ribbon.RibbonFormattingTab();
            this.ribbonInsertTab1 = new TXTextControl.Windows.Forms.Ribbon.RibbonInsertTab();
            this.ribbonPageLayoutTab1 = new TXTextControl.Windows.Forms.Ribbon.RibbonPageLayoutTab();
            this.ribbonViewTab1 = new TXTextControl.Windows.Forms.Ribbon.RibbonViewTab();
            this.ribbonProofingTab1 = new TXTextControl.Windows.Forms.Ribbon.RibbonProofingTab();
            this.ribbonPermissionsTab1 = new TXTextControl.Windows.Forms.Ribbon.RibbonPermissionsTab();
            this.ribbonReportingTab1 = new TXTextControl.Windows.Forms.Ribbon.RibbonReportingTab();
            this.rulerBar2 = new TXTextControl.RulerBar();
            this.statusBar1 = new TXTextControl.StatusBar();
            this.rulerBar1 = new TXTextControl.RulerBar();
            this.ribbon1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textControl1
            // 
            this.textControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textControl1.DocumentTargetMarkers = true;
            this.textControl1.Font = new System.Drawing.Font("Arial", 10F);
            this.textControl1.Location = new System.Drawing.Point(25, 178);
            this.textControl1.Name = "textControl1";
            this.textControl1.Ribbon = this.ribbon1;
            this.textControl1.RulerBar = this.rulerBar2;
            this.textControl1.Size = new System.Drawing.Size(1209, 694);
            this.textControl1.StatusBar = this.statusBar1;
            this.textControl1.TabIndex = 0;
            this.textControl1.Text = "textControl1";
            this.textControl1.UserNames = null;
            this.textControl1.VerticalRulerBar = this.rulerBar1;
            // 
            // ribbon1
            // 
            this.ribbon1.ApplicationMenuItems.AddRange(new System.Windows.Forms.Control[] {
            this.m_rbtnLoad,
            this.m_rbtnSave});
            this.ribbon1.ContextualTabGroups.Add(this.m_grpTableTools);
            this.ribbon1.ContextualTabGroups.Add(this.m_grpFrameTools);
            this.ribbon1.Controls.Add(this.ribbonFormattingTab1);
            this.ribbon1.Controls.Add(this.ribbonInsertTab1);
            this.ribbon1.Controls.Add(this.ribbonPageLayoutTab1);
            this.ribbon1.Controls.Add(this.ribbonViewTab1);
            this.ribbon1.Controls.Add(this.ribbonProofingTab1);
            this.ribbon1.Controls.Add(this.ribbonPermissionsTab1);
            this.ribbon1.Controls.Add(this.ribbonReportingTab1);
            this.ribbon1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.HotTrack = true;
            this.ribbon1.Location = new System.Drawing.Point(0, 31);
            this.ribbon1.Name = "ribbon1";
            this.ribbon1.ReadOnly = false;
            this.ribbon1.SelectedIndex = 7;
            this.ribbon1.Size = new System.Drawing.Size(1234, 122);
            this.ribbon1.TabIndex = 1;
            this.ribbon1.Text = "ribbon1";
            // 
            // m_rbtnLoad
            // 
            this.m_rbtnLoad.BackColor = System.Drawing.Color.Transparent;
            this.m_rbtnLoad.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_rbtnLoad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.m_rbtnLoad.KeyTip = "";
            this.m_rbtnLoad.Location = new System.Drawing.Point(0, 0);
            this.m_rbtnLoad.Name = "m_rbtnLoad";
            this.m_rbtnLoad.Size = new System.Drawing.Size(86, 38);
            this.m_rbtnLoad.TabIndex = 0;
            this.m_rbtnLoad.Text = "Load...";
            // 
            // m_rbtnSave
            // 
            this.m_rbtnSave.BackColor = System.Drawing.Color.Transparent;
            this.m_rbtnSave.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_rbtnSave.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.m_rbtnSave.KeyTip = "";
            this.m_rbtnSave.Location = new System.Drawing.Point(0, 0);
            this.m_rbtnSave.Name = "m_rbtnSave";
            this.m_rbtnSave.Size = new System.Drawing.Size(75, 38);
            this.m_rbtnSave.TabIndex = 0;
            this.m_rbtnSave.Text = "Save";
            // 
            // m_grpTableTools
            // 
            this.m_grpTableTools.BackColor = System.Drawing.Color.LawnGreen;
            this.m_grpTableTools.ContextualTabs.Add(this.ribbonTableLayoutTab1);
            this.m_grpTableTools.Header = "Table Tools";
            this.m_grpTableTools.Name = "m_grpTableTools";
            // 
            // ribbonTableLayoutTab1
            // 
            this.ribbonTableLayoutTab1.KeyTip = "T";
            this.ribbonTableLayoutTab1.Location = new System.Drawing.Point(0, 0);
            this.ribbonTableLayoutTab1.Name = "ribbonTableLayoutTab1";
            this.ribbonTableLayoutTab1.Size = new System.Drawing.Size(200, 40);
            this.ribbonTableLayoutTab1.TabIndex = 0;
            // 
            // m_grpFrameTools
            // 
            this.m_grpFrameTools.BackColor = System.Drawing.Color.LightGray;
            this.m_grpFrameTools.ContextualTabs.Add(this.ribbonFrameLayoutTab1);
            this.m_grpFrameTools.Header = "Frame Tools";
            this.m_grpFrameTools.Name = "m_grpFrameTools";
            // 
            // ribbonFrameLayoutTab1
            // 
            this.ribbonFrameLayoutTab1.Location = new System.Drawing.Point(0, 0);
            this.ribbonFrameLayoutTab1.Name = "ribbonFrameLayoutTab1";
            this.ribbonFrameLayoutTab1.Size = new System.Drawing.Size(200, 40);
            this.ribbonFrameLayoutTab1.TabIndex = 0;
            // 
            // ribbonFormattingTab1
            // 
            this.ribbonFormattingTab1.Location = new System.Drawing.Point(4, 25);
            this.ribbonFormattingTab1.Name = "ribbonFormattingTab1";
            this.ribbonFormattingTab1.Size = new System.Drawing.Size(1226, 93);
            this.ribbonFormattingTab1.TabIndex = 1;
            // 
            // ribbonInsertTab1
            // 
            this.ribbonInsertTab1.Location = new System.Drawing.Point(4, 25);
            this.ribbonInsertTab1.Name = "ribbonInsertTab1";
            this.ribbonInsertTab1.Size = new System.Drawing.Size(1226, 93);
            this.ribbonInsertTab1.TabIndex = 2;
            // 
            // ribbonPageLayoutTab1
            // 
            this.ribbonPageLayoutTab1.Location = new System.Drawing.Point(4, 25);
            this.ribbonPageLayoutTab1.Name = "ribbonPageLayoutTab1";
            this.ribbonPageLayoutTab1.Size = new System.Drawing.Size(1226, 93);
            this.ribbonPageLayoutTab1.TabIndex = 3;
            // 
            // ribbonViewTab1
            // 
            this.ribbonViewTab1.Location = new System.Drawing.Point(4, 25);
            this.ribbonViewTab1.Name = "ribbonViewTab1";
            this.ribbonViewTab1.Size = new System.Drawing.Size(1226, 93);
            this.ribbonViewTab1.TabIndex = 4;
            // 
            // ribbonProofingTab1
            // 
            this.ribbonProofingTab1.Location = new System.Drawing.Point(4, 25);
            this.ribbonProofingTab1.Name = "ribbonProofingTab1";
            this.ribbonProofingTab1.Size = new System.Drawing.Size(1226, 93);
            this.ribbonProofingTab1.TabIndex = 5;
            // 
            // ribbonPermissionsTab1
            // 
            this.ribbonPermissionsTab1.AllowAddingUserNames = true;
            this.ribbonPermissionsTab1.Location = new System.Drawing.Point(4, 25);
            this.ribbonPermissionsTab1.Name = "ribbonPermissionsTab1";
            this.ribbonPermissionsTab1.RegisteredUserNames = new string[0];
            this.ribbonPermissionsTab1.Size = new System.Drawing.Size(1226, 93);
            this.ribbonPermissionsTab1.TabIndex = 7;
            // 
            // ribbonReportingTab1
            // 
            this.ribbonReportingTab1.KeyTip = "R";
            this.ribbonReportingTab1.Location = new System.Drawing.Point(4, 24);
            this.ribbonReportingTab1.Name = "ribbonReportingTab1";
            this.ribbonReportingTab1.Size = new System.Drawing.Size(1226, 94);
            this.ribbonReportingTab1.TabIndex = 6;
            // 
            // rulerBar2
            // 
            this.rulerBar2.Dock = System.Windows.Forms.DockStyle.Top;
            this.rulerBar2.Location = new System.Drawing.Point(0, 153);
            this.rulerBar2.Name = "rulerBar2";
            this.rulerBar2.Size = new System.Drawing.Size(1234, 25);
            this.rulerBar2.TabIndex = 4;
            this.rulerBar2.Text = "rulerBar2";
            // 
            // statusBar1
            // 
            this.statusBar1.BackColor = System.Drawing.SystemColors.Control;
            this.statusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar1.Location = new System.Drawing.Point(0, 872);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(1234, 22);
            this.statusBar1.TabIndex = 2;
            // 
            // rulerBar1
            // 
            this.rulerBar1.Alignment = TXTextControl.RulerBarAlignment.Left;
            this.rulerBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.rulerBar1.Location = new System.Drawing.Point(0, 178);
            this.rulerBar1.Name = "rulerBar1";
            this.rulerBar1.Size = new System.Drawing.Size(25, 694);
            this.rulerBar1.TabIndex = 3;
            this.rulerBar1.Text = "rulerBar1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 894);
            this.Controls.Add(this.textControl1);
            this.Controls.Add(this.rulerBar1);
            this.Controls.Add(this.rulerBar2);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.ribbon1);
            this.Name = "Form1";
            this.Text = "TX Text Control Tutorial";
            this.ribbon1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TXTextControl.TextControl textControl1;
        private TXTextControl.Windows.Forms.Ribbon.Ribbon ribbon1;
        private TXTextControl.Windows.Forms.Ribbon.RibbonFormattingTab ribbonFormattingTab1;
        private TXTextControl.Windows.Forms.Ribbon.RibbonInsertTab ribbonInsertTab1;
        private TXTextControl.Windows.Forms.Ribbon.RibbonPageLayoutTab ribbonPageLayoutTab1;
        private TXTextControl.Windows.Forms.Ribbon.RibbonViewTab ribbonViewTab1;
        private TXTextControl.Windows.Forms.Ribbon.RibbonProofingTab ribbonProofingTab1;
        private TXTextControl.Windows.Forms.Ribbon.RibbonReportingTab ribbonReportingTab1;
        private TXTextControl.RulerBar rulerBar2;
        private TXTextControl.StatusBar statusBar1;
        private TXTextControl.RulerBar rulerBar1;
        private TXTextControl.Windows.Forms.Ribbon.ContextualTabGroup m_grpTableTools;
        private TXTextControl.Windows.Forms.Ribbon.ContextualTabGroup m_grpFrameTools;
        private TXTextControl.Windows.Forms.Ribbon.RibbonFrameLayoutTab ribbonFrameLayoutTab1;
        private TXTextControl.Windows.Forms.Ribbon.RibbonTableLayoutTab ribbonTableLayoutTab1;
        private TXTextControl.Windows.Forms.Ribbon.RibbonButton m_rbtnLoad;
        private TXTextControl.Windows.Forms.Ribbon.RibbonButton m_rbtnSave;
        private TXTextControl.Windows.Forms.Ribbon.RibbonPermissionsTab ribbonPermissionsTab1;
    }
}

