namespace DataSourceManagerSample
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
            this.btnLoadDataSource = new System.Windows.Forms.Button();
            this.cbMasterTable = new System.Windows.Forms.ComboBox();
            this.textControl1 = new TXTextControl.TextControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbMergeFields = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbMergeBlocks = new System.Windows.Forms.ComboBox();
            this.btn_InsertMergeBlock = new System.Windows.Forms.Button();
            this.btn_InsertMergeField = new System.Windows.Forms.Button();
            this.gbMergeElements = new System.Windows.Forms.GroupBox();
            this.cbPreview = new System.Windows.Forms.CheckBox();
            this.gbMergeElements.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadDataSource
            // 
            this.btnLoadDataSource.Location = new System.Drawing.Point(16, 13);
            this.btnLoadDataSource.Name = "btnLoadDataSource";
            this.btnLoadDataSource.Size = new System.Drawing.Size(139, 34);
            this.btnLoadDataSource.TabIndex = 0;
            this.btnLoadDataSource.Text = "Load Data Source";
            this.btnLoadDataSource.UseVisualStyleBackColor = true;
            this.btnLoadDataSource.Click += new System.EventHandler(this.btnDataSource_Click);
            // 
            // cbMasterTable
            // 
            this.cbMasterTable.FormattingEnabled = true;
            this.cbMasterTable.Location = new System.Drawing.Point(16, 77);
            this.cbMasterTable.Name = "cbMasterTable";
            this.cbMasterTable.Size = new System.Drawing.Size(290, 21);
            this.cbMasterTable.TabIndex = 1;
            this.cbMasterTable.SelectedIndexChanged += new System.EventHandler(this.cbMasterTable_SelectedIndexChanged);
            // 
            // textControl1
            // 
            this.textControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textControl1.Font = new System.Drawing.Font("Arial", 10F);
            this.textControl1.Location = new System.Drawing.Point(16, 288);
            this.textControl1.Name = "textControl1";
            this.textControl1.Size = new System.Drawing.Size(640, 317);
            this.textControl1.TabIndex = 2;
            this.textControl1.SubTextPartEntered += new TXTextControl.SubTextPartEventHandler(this.textControl1_SubTextPartEntered);
            this.textControl1.SubTextPartLeft += new TXTextControl.SubTextPartEventHandler(this.textControl1_SubTextPartLeft);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Master Table:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Available Merge Fields:";
            // 
            // cbMergeFields
            // 
            this.cbMergeFields.FormattingEnabled = true;
            this.cbMergeFields.Location = new System.Drawing.Point(333, 40);
            this.cbMergeFields.Name = "cbMergeFields";
            this.cbMergeFields.Size = new System.Drawing.Size(290, 21);
            this.cbMergeFields.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Available Merge Blocks:";
            // 
            // cbMergeBlocks
            // 
            this.cbMergeBlocks.FormattingEnabled = true;
            this.cbMergeBlocks.Location = new System.Drawing.Point(9, 40);
            this.cbMergeBlocks.Name = "cbMergeBlocks";
            this.cbMergeBlocks.Size = new System.Drawing.Size(290, 21);
            this.cbMergeBlocks.TabIndex = 6;
            // 
            // btn_InsertMergeBlock
            // 
            this.btn_InsertMergeBlock.Location = new System.Drawing.Point(9, 67);
            this.btn_InsertMergeBlock.Name = "btn_InsertMergeBlock";
            this.btn_InsertMergeBlock.Size = new System.Drawing.Size(118, 23);
            this.btn_InsertMergeBlock.TabIndex = 8;
            this.btn_InsertMergeBlock.Text = "Insert Merge Block";
            this.btn_InsertMergeBlock.UseVisualStyleBackColor = true;
            this.btn_InsertMergeBlock.Click += new System.EventHandler(this.btnInsertMergeBlock_Click);
            // 
            // btn_InsertMergeField
            // 
            this.btn_InsertMergeField.Location = new System.Drawing.Point(333, 67);
            this.btn_InsertMergeField.Name = "btn_InsertMergeField";
            this.btn_InsertMergeField.Size = new System.Drawing.Size(118, 23);
            this.btn_InsertMergeField.TabIndex = 9;
            this.btn_InsertMergeField.Text = "Insert Merge Field";
            this.btn_InsertMergeField.UseVisualStyleBackColor = true;
            this.btn_InsertMergeField.Click += new System.EventHandler(this.btnInsertMergeField_Click);
            // 
            // gbMergeElements
            // 
            this.gbMergeElements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMergeElements.Controls.Add(this.label3);
            this.gbMergeElements.Controls.Add(this.btn_InsertMergeField);
            this.gbMergeElements.Controls.Add(this.cbMergeFields);
            this.gbMergeElements.Controls.Add(this.btn_InsertMergeBlock);
            this.gbMergeElements.Controls.Add(this.label2);
            this.gbMergeElements.Controls.Add(this.cbMergeBlocks);
            this.gbMergeElements.Enabled = false;
            this.gbMergeElements.Location = new System.Drawing.Point(16, 131);
            this.gbMergeElements.Name = "gbMergeElements";
            this.gbMergeElements.Size = new System.Drawing.Size(640, 99);
            this.gbMergeElements.TabIndex = 10;
            this.gbMergeElements.TabStop = false;
            this.gbMergeElements.Text = "Mail Merge Elements";
            // 
            // cbPreview
            // 
            this.cbPreview.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbPreview.Enabled = false;
            this.cbPreview.Location = new System.Drawing.Point(16, 248);
            this.cbPreview.Name = "cbPreview";
            this.cbPreview.Size = new System.Drawing.Size(139, 34);
            this.cbPreview.TabIndex = 11;
            this.cbPreview.Text = "Preview";
            this.cbPreview.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbPreview.UseVisualStyleBackColor = true;
            this.cbPreview.CheckedChanged += new System.EventHandler(this.cbPreview_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 617);
            this.Controls.Add(this.cbPreview);
            this.Controls.Add(this.gbMergeElements);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textControl1);
            this.Controls.Add(this.cbMasterTable);
            this.Controls.Add(this.btnLoadDataSource);
            this.MinimumSize = new System.Drawing.Size(686, 656);
            this.Name = "Form1";
            this.Text = "Text Control Data Source Manager";
            this.gbMergeElements.ResumeLayout(false);
            this.gbMergeElements.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadDataSource;
        private System.Windows.Forms.ComboBox cbMasterTable;
        private TXTextControl.TextControl textControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbMergeFields;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbMergeBlocks;
        private System.Windows.Forms.Button btn_InsertMergeBlock;
        private System.Windows.Forms.Button btn_InsertMergeField;
        private System.Windows.Forms.GroupBox gbMergeElements;
        private System.Windows.Forms.CheckBox cbPreview;
    }
}

