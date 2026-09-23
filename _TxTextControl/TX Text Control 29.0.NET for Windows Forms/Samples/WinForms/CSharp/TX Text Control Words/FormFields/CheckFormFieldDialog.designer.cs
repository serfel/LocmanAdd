namespace TX_Text_Control_Words.FormFields {
	partial class CheckFormFieldDialog {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckFormFieldDialog));
			this.cbUncheckSymbol = new System.Windows.Forms.ComboBox();
			this.lblUncheckSymbol = new System.Windows.Forms.Label();
			this.lblCheckSymbol = new System.Windows.Forms.Label();
			this.cbCheckSymbol = new System.Windows.Forms.ComboBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbUncheckSymbol
			// 
			resources.ApplyResources(this.cbUncheckSymbol, "cbUncheckSymbol");
			this.cbUncheckSymbol.FormattingEnabled = true;
			this.cbUncheckSymbol.Name = "cbUncheckSymbol";
			this.cbUncheckSymbol.TextChanged += new System.EventHandler(this.checkbox_TextChanged);
			// 
			// lblUncheckSymbol
			// 
			resources.ApplyResources(this.lblUncheckSymbol, "lblUncheckSymbol");
			this.lblUncheckSymbol.Name = "lblUncheckSymbol";
			// 
			// lblCheckSymbol
			// 
			resources.ApplyResources(this.lblCheckSymbol, "lblCheckSymbol");
			this.lblCheckSymbol.Name = "lblCheckSymbol";
			// 
			// cbCheckSymbol
			// 
			resources.ApplyResources(this.cbCheckSymbol, "cbCheckSymbol");
			this.cbCheckSymbol.FormattingEnabled = true;
			this.cbCheckSymbol.Name = "cbCheckSymbol";
			this.cbCheckSymbol.TextChanged += new System.EventHandler(this.checkbox_TextChanged);
			// 
			// btnCancel
			// 
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Tag = "Abort the action.";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			resources.ApplyResources(this.btnOK, "btnOK");
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Name = "btnOK";
			this.btnOK.Tag = "Confirm the action.";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// tableLayoutPanel1
			// 
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.lblCheckSymbol, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.lblUncheckSymbol, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.cbUncheckSymbol, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.cbCheckSymbol, 1, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			// 
			// tableLayoutPanel2
			// 
			resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
			this.tableLayoutPanel2.Controls.Add(this.btnOK, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.btnCancel, 1, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			// 
			// CheckFormFieldDialog
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.CancelButton = this.btnCancel;
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.tableLayoutPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CheckFormFieldDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cbUncheckSymbol;
		private System.Windows.Forms.Label lblUncheckSymbol;
		private System.Windows.Forms.Label lblCheckSymbol;
		private System.Windows.Forms.ComboBox cbCheckSymbol;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
	}
}