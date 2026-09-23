namespace FormField_DeployNValidate {
	partial class Form1 {
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
			this.ribbon = new TXTextControl.Windows.Forms.Ribbon.Ribbon();
			this.ribbonFormFieldsTab = new TXTextControl.Windows.Forms.Ribbon.RibbonFormFieldsTab();
			this.textControl1 = new TXTextControl.TextControl();
			this.statusBar1 = new TXTextControl.StatusBar();
			this.ribbon.SuspendLayout();
			this.SuspendLayout();
			// 
			// ribbon
			// 
			this.ribbon.Controls.Add(this.ribbonFormFieldsTab);
			this.ribbon.Dock = System.Windows.Forms.DockStyle.Top;
			this.ribbon.Font = new System.Drawing.Font("Segoe UI", 9F);
			this.ribbon.HasApplicationMenu = false;
			this.ribbon.HotTrack = true;
			this.ribbon.Location = new System.Drawing.Point(0, 0);
			this.ribbon.Name = "ribbon";
			this.ribbon.SelectedIndex = 0;
			this.ribbon.TabIndex = 0;
			// 
			// ribbonFormFieldsTab
			// 
			this.ribbonFormFieldsTab.Location = new System.Drawing.Point(4, 39);
			this.ribbonFormFieldsTab.Name = "ribbonFormFieldsTab";
			this.ribbonFormFieldsTab.TabIndex = 1;
			// 
			// textControl1
			// 
			this.textControl1.DisplayColors.FormFieldColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
			this.textControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textControl1.Font = new System.Drawing.Font("Arial", 10F);
			this.textControl1.IsFormFieldValidationEnabled = true;
			this.textControl1.Margin = new System.Windows.Forms.Padding(2);
			this.textControl1.Name = "textControl1";
			this.textControl1.Ribbon = this.ribbon;
			this.textControl1.StatusBar = this.statusBar1;
			this.textControl1.TabIndex = 1;
			this.textControl1.Text = "textControl1";
			this.textControl1.UserNames = null;
			// 
			// statusBar1
			// 
			this.statusBar1.BackColor = System.Drawing.SystemColors.Control;
			this.statusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.statusBar1.Margin = new System.Windows.Forms.Padding(2);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.TabIndex = 4;
			// 
			// Form1
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1855, 1789);
			this.Controls.Add(this.textControl1);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.ribbon);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "Form1";
			this.Text = "Sample: Deploy And Validate Documents";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ribbon.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private TXTextControl.Windows.Forms.Ribbon.Ribbon ribbon;
		private TXTextControl.TextControl textControl1;
		private TXTextControl.Windows.Forms.Ribbon.RibbonFormFieldsTab ribbonFormFieldsTab;
		private TXTextControl.StatusBar statusBar1;
	}
}

