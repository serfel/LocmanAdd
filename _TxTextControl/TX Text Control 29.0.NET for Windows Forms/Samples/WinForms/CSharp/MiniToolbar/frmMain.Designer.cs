namespace MiniToolbar {
	partial class frmMain {
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
            this.textControl1 = new TXTextControl.TextControl();
            this.SuspendLayout();
            // 
            // textControl1
            // 
            this.textControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textControl1.Font = new System.Drawing.Font("Arial", 10F);
            this.textControl1.Location = new System.Drawing.Point(0, 0);
            this.textControl1.Name = "textControl1";
            this.textControl1.ShowMiniToolbar = ((TXTextControl.MiniToolbarButton)((TXTextControl.MiniToolbarButton.LeftButton | TXTextControl.MiniToolbarButton.RightButton)));
            this.textControl1.Size = new System.Drawing.Size(979, 431);
            this.textControl1.TabIndex = 0;
            this.textControl1.Text = "textControl1";
            this.textControl1.UserNames = null;
            this.textControl1.TextMiniToolbarInitialized += new TXTextControl.MiniToolbarInitializedEventHandler(this.textControl1_TextMiniToolbarInitialized);
            this.textControl1.MiniToolbarOpening += new TXTextControl.MiniToolbarOpeningEventHandler(this.textControl1_MiniToolbarOpening);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 431);
            this.Controls.Add(this.textControl1);
            this.Name = "Form1";
            this.Text = "MiniToolbar Sample";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

		}

		#endregion

		private TXTextControl.TextControl textControl1;
	}
}

