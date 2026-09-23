namespace TX_Text_Control_Words.FormFields {
	partial class EmptyWidthControl {
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmptyWidthControl));
			this.numWidth = new System.Windows.Forms.NumericUpDown();
			this.lblWidthMeasurementUnit = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lblWidth = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// numWidth
			// 
			resources.ApplyResources(this.numWidth, "numWidth");
			this.numWidth.Name = "numWidth";
			this.numWidth.Tag = "";
			this.numWidth.Value = new decimal(new int[] {
            18,
            0,
            0,
            65536});
			// 
			// lblWidthMeasurementUnit
			// 
			resources.ApplyResources(this.lblWidthMeasurementUnit, "lblWidthMeasurementUnit");
			this.lblWidthMeasurementUnit.Name = "lblWidthMeasurementUnit";
			// 
			// tableLayoutPanel1
			// 
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.numWidth, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.lblWidth, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.lblWidthMeasurementUnit, 2, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			// 
			// lblWidth
			// 
			resources.ApplyResources(this.lblWidth, "lblWidth");
			this.lblWidth.Name = "lblWidth";
			// 
			// EmptyWidthControl
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Name = "EmptyWidthControl";
			((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.NumericUpDown numWidth;
		private System.Windows.Forms.Label lblWidthMeasurementUnit;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label lblWidth;
	}
}
