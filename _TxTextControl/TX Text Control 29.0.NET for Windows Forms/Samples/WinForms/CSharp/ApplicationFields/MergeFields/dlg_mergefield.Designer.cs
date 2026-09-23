namespace MergeFieldSample
{
    partial class dlg_mergefield
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_fieldText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_textFormat = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_preserveFormatting = new System.Windows.Forms.CheckBox();
            this.cb_mappedField = new System.Windows.Forms.CheckBox();
            this.tb_textAfter = new System.Windows.Forms.TextBox();
            this.cb_textAfter = new System.Windows.Forms.CheckBox();
            this.tb_textBefore = new System.Windows.Forms.TextBox();
            this.cb_textBefore = new System.Windows.Forms.CheckBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.btn_apply = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_fieldText);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lb_textFormat);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(186, 238);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Field properties";
            // 
            // tb_fieldText
            // 
            this.tb_fieldText.Location = new System.Drawing.Point(7, 72);
            this.tb_fieldText.Name = "tb_fieldText";
            this.tb_fieldText.Size = new System.Drawing.Size(173, 20);
            this.tb_fieldText.TabIndex = 1;
            this.tb_fieldText.Click += new System.EventHandler(this.tb_fieldText_Click);
            this.tb_fieldText.TextChanged += new System.EventHandler(this.tb_fieldText_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "&Field text:";
            // 
            // lb_textFormat
            // 
            this.lb_textFormat.FormattingEnabled = true;
            this.lb_textFormat.Items.AddRange(new object[] {
            "(none)",
            "UPPERCASE",
            "lowercase",
            "First capital",
            "Title Case"});
            this.lb_textFormat.Location = new System.Drawing.Point(6, 137);
            this.lb_textFormat.Name = "lb_textFormat";
            this.lb_textFormat.Size = new System.Drawing.Size(173, 95);
            this.lb_textFormat.TabIndex = 3;
            this.lb_textFormat.SelectedIndexChanged += new System.EventHandler(this.lb_textFormat_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Format:";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(7, 33);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(173, 20);
            this.tb_name.TabIndex = 0;
            this.tb_name.Click += new System.EventHandler(this.tb_name_Click);
            this.tb_name.TextChanged += new System.EventHandler(this.tb_name_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Field name&:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cb_preserveFormatting);
            this.groupBox2.Controls.Add(this.cb_mappedField);
            this.groupBox2.Controls.Add(this.tb_textAfter);
            this.groupBox2.Controls.Add(this.cb_textAfter);
            this.groupBox2.Controls.Add(this.tb_textBefore);
            this.groupBox2.Controls.Add(this.cb_textBefore);
            this.groupBox2.Location = new System.Drawing.Point(204, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(204, 238);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Field options";
            // 
            // cb_preserveFormatting
            // 
            this.cb_preserveFormatting.AutoSize = true;
            this.cb_preserveFormatting.Location = new System.Drawing.Point(6, 215);
            this.cb_preserveFormatting.Name = "cb_preserveFormatting";
            this.cb_preserveFormatting.Size = new System.Drawing.Size(190, 17);
            this.cb_preserveFormatting.TabIndex = 7;
            this.cb_preserveFormatting.Text = "&Preserve formatting during updates";
            this.cb_preserveFormatting.UseVisualStyleBackColor = true;
            this.cb_preserveFormatting.CheckedChanged += new System.EventHandler(this.cb_preserveFormatting_CheckedChanged);
            // 
            // cb_mappedField
            // 
            this.cb_mappedField.AutoSize = true;
            this.cb_mappedField.Location = new System.Drawing.Point(7, 105);
            this.cb_mappedField.Name = "cb_mappedField";
            this.cb_mappedField.Size = new System.Drawing.Size(87, 17);
            this.cb_mappedField.TabIndex = 6;
            this.cb_mappedField.Text = "&Mapped field";
            this.cb_mappedField.UseVisualStyleBackColor = true;
            this.cb_mappedField.CheckedChanged += new System.EventHandler(this.cb_mappedField_CheckedChanged);
            // 
            // tb_textAfter
            // 
            this.tb_textAfter.Enabled = false;
            this.tb_textAfter.Location = new System.Drawing.Point(128, 65);
            this.tb_textAfter.Name = "tb_textAfter";
            this.tb_textAfter.Size = new System.Drawing.Size(70, 20);
            this.tb_textAfter.TabIndex = 12;
            this.tb_textAfter.Click += new System.EventHandler(this.tb_textAfter_Click);
            this.tb_textAfter.TextChanged += new System.EventHandler(this.tb_textAfter_TextChanged);
            // 
            // cb_textAfter
            // 
            this.cb_textAfter.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cb_textAfter.Location = new System.Drawing.Point(6, 65);
            this.cb_textAfter.Name = "cb_textAfter";
            this.cb_textAfter.Size = new System.Drawing.Size(116, 33);
            this.cb_textAfter.TabIndex = 5;
            this.cb_textAfter.Text = "Text to be inserted &after:";
            this.cb_textAfter.UseVisualStyleBackColor = true;
            this.cb_textAfter.CheckedChanged += new System.EventHandler(this.cb_textAfter_CheckedChanged);
            // 
            // tb_textBefore
            // 
            this.tb_textBefore.Enabled = false;
            this.tb_textBefore.Location = new System.Drawing.Point(128, 33);
            this.tb_textBefore.Name = "tb_textBefore";
            this.tb_textBefore.Size = new System.Drawing.Size(70, 20);
            this.tb_textBefore.TabIndex = 11;
            this.tb_textBefore.Click += new System.EventHandler(this.tb_textBefore_Click);
            this.tb_textBefore.TextChanged += new System.EventHandler(this.tb_textBefore_TextChanged);
            // 
            // cb_textBefore
            // 
            this.cb_textBefore.CheckAlign = System.Drawing.ContentAlignment.TopLeft;
            this.cb_textBefore.Location = new System.Drawing.Point(6, 33);
            this.cb_textBefore.Name = "cb_textBefore";
            this.cb_textBefore.Size = new System.Drawing.Size(116, 33);
            this.cb_textBefore.TabIndex = 4;
            this.cb_textBefore.Text = "Text to be inserted &before:";
            this.cb_textBefore.UseVisualStyleBackColor = true;
            this.cb_textBefore.CheckedChanged += new System.EventHandler(this.cb_textBefore_CheckedChanged);
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(333, 256);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.TabIndex = 10;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            // 
            // btn_ok
            // 
            this.btn_ok.Location = new System.Drawing.Point(171, 256);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(75, 23);
            this.btn_ok.TabIndex = 8;
            this.btn_ok.Text = "OK";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // btn_apply
            // 
            this.btn_apply.Enabled = false;
            this.btn_apply.Location = new System.Drawing.Point(252, 256);
            this.btn_apply.Name = "btn_apply";
            this.btn_apply.Size = new System.Drawing.Size(75, 23);
            this.btn_apply.TabIndex = 9;
            this.btn_apply.Text = "Appl&y";
            this.btn_apply.UseVisualStyleBackColor = true;
            this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click);
            // 
            // dlg_mergefield
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(420, 291);
            this.Controls.Add(this.btn_apply);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "dlg_mergefield";
            this.ShowInTaskbar = false;
            this.Text = "MergeField";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lb_textFormat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_textAfter;
        private System.Windows.Forms.CheckBox cb_textAfter;
        private System.Windows.Forms.TextBox tb_textBefore;
        private System.Windows.Forms.CheckBox cb_textBefore;
        private System.Windows.Forms.CheckBox cb_mappedField;
        private System.Windows.Forms.CheckBox cb_preserveFormatting;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_fieldText;
        private System.Windows.Forms.Button btn_apply;
    }
}