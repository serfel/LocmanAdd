namespace TX_Text_Control_Words.FormFields {
	partial class DateFormFieldDialog {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DateFormFieldDialog));
			this.m_tbCurrentDateFormat = new System.Windows.Forms.TextBox();
			this.m_listBoxDateFormat = new System.Windows.Forms.ListBox();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.m_emptyWidthControl = new TX_Text_Control_Words.FormFields.EmptyWidthControl();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_tbCurrentDateFormat
			// 
			resources.ApplyResources(this.m_tbCurrentDateFormat, "m_tbCurrentDateFormat");
			this.m_tbCurrentDateFormat.Name = "m_tbCurrentDateFormat";
			this.m_tbCurrentDateFormat.ReadOnly = true;
			// 
			// m_listBoxDateFormat
			// 
			resources.ApplyResources(this.m_listBoxDateFormat, "m_listBoxDateFormat");
			this.m_listBoxDateFormat.FormatString = "t";
			this.m_listBoxDateFormat.FormattingEnabled = true;
			this.m_listBoxDateFormat.Name = "m_listBoxDateFormat";
			this.m_listBoxDateFormat.SelectedValueChanged += new System.EventHandler(this.m_listBoxDateFormat_SelectedValueChanged);
			// 
			// m_btnCancel
			// 
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(this.m_btnCancel, "m_btnCancel");
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			// 
			// m_btnOK
			// 
			this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			resources.ApplyResources(this.m_btnOK, "m_btnOK");
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(this.m_btnOK_Click);
			// 
			// tableLayoutPanel1
			// 
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.m_emptyWidthControl, 0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			// 
			// tableLayoutPanel2
			// 
			resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
			this.tableLayoutPanel2.Controls.Add(this.m_btnOK, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.m_btnCancel, 2, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			// 
			// groupBox1
			// 
			resources.ApplyResources(this.groupBox1, "groupBox1");
			this.groupBox1.Controls.Add(this.tableLayoutPanel3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.TabStop = false;
			// 
			// tableLayoutPanel3
			// 
			resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
			this.tableLayoutPanel3.Controls.Add(this.m_listBoxDateFormat, 0, 1);
			this.tableLayoutPanel3.Controls.Add(this.m_tbCurrentDateFormat, 0, 0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			// 
			// m_emptyWidthControl
			// 
			resources.ApplyResources(this.m_emptyWidthControl, "m_emptyWidthControl");
			this.m_emptyWidthControl.Name = "m_emptyWidthControl";
			this.m_emptyWidthControl.Value = 102;
			// 
			// DateFormFieldDialog
			// 
			this.AcceptButton = this.m_btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			resources.ApplyResources(this, "$this");
			this.CancelButton = this.m_btnCancel;
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DateFormFieldDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox m_tbCurrentDateFormat;
		private System.Windows.Forms.ListBox m_listBoxDateFormat;
		private System.Windows.Forms.Button m_btnCancel;
		private System.Windows.Forms.Button m_btnOK;
		private EmptyWidthControl m_emptyWidthControl;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
	}
}