namespace TX_Text_Control_Words
{
   partial class MergeWaitDialog
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



      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
			this._progBar = new System.Windows.Forms.ProgressBar();
			this.m_lblMerging = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// _progBar
			// 
			this._progBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this._progBar.Location = new System.Drawing.Point(12, 34);
			this._progBar.MarqueeAnimationSpeed = 50;
			this._progBar.Name = "_progBar";
			this._progBar.Size = new System.Drawing.Size(226, 23);
			this._progBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
			this._progBar.TabIndex = 0;
			this._progBar.Value = 100;
			// 
			// m_lblMerging
			// 
			this.m_lblMerging.AutoSize = true;
			this.m_lblMerging.Location = new System.Drawing.Point(12, 9);
			this.m_lblMerging.Name = "m_lblMerging";
			this.m_lblMerging.Size = new System.Drawing.Size(51, 13);
			this.m_lblMerging.TabIndex = 1;
			this.m_lblMerging.Text = "Merging…";
			// 
			// MergeWaitDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.ClientSize = new System.Drawing.Size(250, 82);
			this.Controls.Add(this.m_lblMerging);
			this.Controls.Add(this._progBar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "MergeWaitDialog";
			this.RightToLeftLayout = true;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Please wait";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MergeWaitDialog_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

      }



      private System.Windows.Forms.ProgressBar _progBar;
      private System.Windows.Forms.Label m_lblMerging;
   }
}