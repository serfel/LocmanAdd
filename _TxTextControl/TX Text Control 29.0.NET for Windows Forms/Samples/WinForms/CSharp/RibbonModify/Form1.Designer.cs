namespace RibbonModify
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnRemoveTab = new System.Windows.Forms.Button();
            this.btnRemoveGroup = new System.Windows.Forms.Button();
            this.btnNewTab = new System.Windows.Forms.Button();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.btnChangeText = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.textControl1 = new TXTextControl.TextControl();
            this.ribbon1 = new TXTextControl.Windows.Forms.Ribbon.Ribbon();
            this.ribbonFormattingTab1 = new TXTextControl.Windows.Forms.Ribbon.RibbonFormattingTab();
            this.ribbonInsertTab1 = new TXTextControl.Windows.Forms.Ribbon.RibbonInsertTab();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ribbon1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnRemoveTab);
            this.splitContainer1.Panel1.Controls.Add(this.btnRemoveGroup);
            this.splitContainer1.Panel1.Controls.Add(this.btnNewTab);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddEvent);
            this.splitContainer1.Panel1.Controls.Add(this.btnChangeText);
            this.splitContainer1.Panel1.Controls.Add(this.btnRemove);
            this.splitContainer1.Panel1MinSize = 100;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.textControl1);
            this.splitContainer1.Panel2.Controls.Add(this.ribbon1);
            this.splitContainer1.Size = new System.Drawing.Size(1234, 801);
            this.splitContainer1.SplitterDistance = 110;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnRemoveTab
            // 
            this.btnRemoveTab.Location = new System.Drawing.Point(526, 12);
            this.btnRemoveTab.Name = "btnRemoveTab";
            this.btnRemoveTab.Size = new System.Drawing.Size(251, 23);
            this.btnRemoveTab.TabIndex = 5;
            this.btnRemoveTab.Text = "Remove RibbonTab (Insert)";
            this.btnRemoveTab.UseVisualStyleBackColor = true;
            this.btnRemoveTab.Click += new System.EventHandler(this.btnRemoveTab_Click);
            // 
            // btnRemoveGroup
            // 
            this.btnRemoveGroup.Location = new System.Drawing.Point(269, 12);
            this.btnRemoveGroup.Name = "btnRemoveGroup";
            this.btnRemoveGroup.Size = new System.Drawing.Size(251, 23);
            this.btnRemoveGroup.TabIndex = 4;
            this.btnRemoveGroup.Text = "Remove RibbonGroup (Font)";
            this.btnRemoveGroup.UseVisualStyleBackColor = true;
            this.btnRemoveGroup.Click += new System.EventHandler(this.btnRemoveGroup_Click);
            // 
            // btnNewTab
            // 
            this.btnNewTab.Location = new System.Drawing.Point(526, 41);
            this.btnNewTab.Name = "btnNewTab";
            this.btnNewTab.Size = new System.Drawing.Size(251, 23);
            this.btnNewTab.TabIndex = 3;
            this.btnNewTab.Text = "Create new RibbonTab";
            this.btnNewTab.UseVisualStyleBackColor = true;
            this.btnNewTab.Click += new System.EventHandler(this.btnNewTab_Click);
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.Location = new System.Drawing.Point(12, 41);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(251, 23);
            this.btnAddEvent.TabIndex = 2;
            this.btnAddEvent.Text = "Change RibbonItem Functionality (Paste button)";
            this.btnAddEvent.UseVisualStyleBackColor = true;
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // btnChangeText
            // 
            this.btnChangeText.Location = new System.Drawing.Point(12, 12);
            this.btnChangeText.Name = "btnChangeText";
            this.btnChangeText.Size = new System.Drawing.Size(251, 23);
            this.btnChangeText.TabIndex = 1;
            this.btnChangeText.Text = "Change RibbonItem Text (Paste button)";
            this.btnChangeText.UseVisualStyleBackColor = true;
            this.btnChangeText.Click += new System.EventHandler(this.btnChangeText_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(12, 70);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(251, 23);
            this.btnRemove.TabIndex = 0;
            this.btnRemove.Text = "Remove RibbonItem (Paste button)";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // textControl1
            // 
            this.textControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textControl1.DocumentTargetMarkers = true;
            this.textControl1.Font = new System.Drawing.Font("Arial", 10F);
            this.textControl1.Location = new System.Drawing.Point(0, 120);
            this.textControl1.Name = "textControl1";
            this.textControl1.Ribbon = this.ribbon1;
            this.textControl1.Size = new System.Drawing.Size(1234, 567);
            this.textControl1.TabIndex = 0;
            this.textControl1.Text = "textControl1";
            this.textControl1.UserNames = null;
            // 
            // ribbon1
            // 
            this.ribbon1.Controls.Add(this.ribbonFormattingTab1);
            this.ribbon1.Controls.Add(this.ribbonInsertTab1);
            this.ribbon1.Dock = System.Windows.Forms.DockStyle.Top;
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.HotTrack = true;
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Name = "ribbon1";
            this.ribbon1.ReadOnly = false;
            this.ribbon1.SelectedIndex = 1;
            this.ribbon1.Size = new System.Drawing.Size(1234, 120);
            this.ribbon1.TabIndex = 1;
            this.ribbon1.Text = "ribbon1";
            // 
            // ribbonFormattingTab1
            // 
            this.ribbonFormattingTab1.Location = new System.Drawing.Point(4, 24);
            this.ribbonFormattingTab1.Name = "ribbonFormattingTab1";
            this.ribbonFormattingTab1.Size = new System.Drawing.Size(1226, 92);
            this.ribbonFormattingTab1.TabIndex = 1;
            // 
            // ribbonInsertTab1
            // 
            this.ribbonInsertTab1.Location = new System.Drawing.Point(4, 24);
            this.ribbonInsertTab1.Name = "ribbonInsertTab1";
            this.ribbonInsertTab1.Size = new System.Drawing.Size(1201, 92);
            this.ribbonInsertTab1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 801);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Text Control Ribbon Programming";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ribbon1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnRemove;
        private TXTextControl.TextControl textControl1;
        private TXTextControl.Windows.Forms.Ribbon.Ribbon ribbon1;
        private System.Windows.Forms.Button btnAddEvent;
        private System.Windows.Forms.Button btnChangeText;
        private System.Windows.Forms.Button btnNewTab;
        private System.Windows.Forms.Button btnRemoveGroup;
        private System.Windows.Forms.Button btnRemoveTab;
        private TXTextControl.Windows.Forms.Ribbon.RibbonFormattingTab ribbonFormattingTab1;
        private TXTextControl.Windows.Forms.Ribbon.RibbonInsertTab ribbonInsertTab1;
    }
}

