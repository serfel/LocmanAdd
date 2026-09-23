namespace TX_Text_Control_Words {
	partial class EditUserDialog {
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



		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.m_txtPasswordConfirm = new System.Windows.Forms.TextBox();
            this.m_lblPasswordConfirm = new System.Windows.Forms.Label();
            this.m_txtNewPassword = new System.Windows.Forms.TextBox();
            this.m_lblNewPassword = new System.Windows.Forms.Label();
            this.m_txtCurrentPassword = new System.Windows.Forms.TextBox();
            this.m_lblCurrentPassword = new System.Windows.Forms.Label();
            this.m_lblName = new System.Windows.Forms.Label();
            this.m_txtName = new System.Windows.Forms.TextBox();
            this.m_btnOK = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.m_txtPasswordConfirm, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.m_lblPasswordConfirm, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.m_txtNewPassword, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.m_lblNewPassword, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.m_txtCurrentPassword, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.m_lblCurrentPassword, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.m_lblName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.m_txtName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.m_btnOK, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.m_btnCancel, 2, 9);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 7);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(380, 210);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // m_txtPasswordConfirm
            // 
            this.m_txtPasswordConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.m_txtPasswordConfirm, 3);
            this.m_txtPasswordConfirm.Location = new System.Drawing.Point(0, 155);
            this.m_txtPasswordConfirm.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.m_txtPasswordConfirm.Name = "m_txtPasswordConfirm";
            this.m_txtPasswordConfirm.Size = new System.Drawing.Size(380, 23);
            this.m_txtPasswordConfirm.TabIndex = 7;
            this.m_txtPasswordConfirm.UseSystemPasswordChar = true;
            this.m_txtPasswordConfirm.TextChanged += new System.EventHandler(this.TxtPasswordConfirm_TextChanged);
            // 
            // m_lblPasswordConfirm
            // 
            this.m_lblPasswordConfirm.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.m_lblPasswordConfirm, 3);
            this.m_lblPasswordConfirm.Location = new System.Drawing.Point(0, 135);
            this.m_lblPasswordConfirm.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.m_lblPasswordConfirm.Name = "m_lblPasswordConfirm";
            this.m_lblPasswordConfirm.Size = new System.Drawing.Size(107, 15);
            this.m_lblPasswordConfirm.TabIndex = 6;
            this.m_lblPasswordConfirm.Text = "&Confirm Password:";
            // 
            // m_txtNewPassword
            // 
            this.m_txtNewPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.m_txtNewPassword, 3);
            this.m_txtNewPassword.Location = new System.Drawing.Point(0, 110);
            this.m_txtNewPassword.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.m_txtNewPassword.Name = "m_txtNewPassword";
            this.m_txtNewPassword.Size = new System.Drawing.Size(380, 23);
            this.m_txtNewPassword.TabIndex = 5;
            this.m_txtNewPassword.UseSystemPasswordChar = true;
            this.m_txtNewPassword.TextChanged += new System.EventHandler(this.TxtNewPassword_TextChanged);
            // 
            // m_lblNewPassword
            // 
            this.m_lblNewPassword.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.m_lblNewPassword, 3);
            this.m_lblNewPassword.Location = new System.Drawing.Point(0, 90);
            this.m_lblNewPassword.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.m_lblNewPassword.Name = "m_lblNewPassword";
            this.m_lblNewPassword.Size = new System.Drawing.Size(87, 15);
            this.m_lblNewPassword.TabIndex = 4;
            this.m_lblNewPassword.Text = "&New Password:";
            // 
            // m_txtCurrentPassword
            // 
            this.m_txtCurrentPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.m_txtCurrentPassword, 3);
            this.m_txtCurrentPassword.Location = new System.Drawing.Point(0, 65);
            this.m_txtCurrentPassword.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.m_txtCurrentPassword.Name = "m_txtCurrentPassword";
            this.m_txtCurrentPassword.Size = new System.Drawing.Size(380, 23);
            this.m_txtCurrentPassword.TabIndex = 3;
            this.m_txtCurrentPassword.UseSystemPasswordChar = true;
            this.m_txtCurrentPassword.Visible = false;
            this.m_txtCurrentPassword.TextChanged += new System.EventHandler(this.TxtCurrentPassword_TextChanged);
            // 
            // m_lblCurrentPassword
            // 
            this.m_lblCurrentPassword.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.m_lblCurrentPassword, 3);
            this.m_lblCurrentPassword.Location = new System.Drawing.Point(0, 45);
            this.m_lblCurrentPassword.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.m_lblCurrentPassword.Name = "m_lblCurrentPassword";
            this.m_lblCurrentPassword.Size = new System.Drawing.Size(60, 15);
            this.m_lblCurrentPassword.TabIndex = 2;
            this.m_lblCurrentPassword.Text = "&Password:";
            this.m_lblCurrentPassword.Visible = false;
            // 
            // m_lblName
            // 
            this.m_lblName.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.m_lblName, 3);
            this.m_lblName.Location = new System.Drawing.Point(0, 0);
            this.m_lblName.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.m_lblName.Name = "m_lblName";
            this.m_lblName.Size = new System.Drawing.Size(63, 15);
            this.m_lblName.TabIndex = 0;
            this.m_lblName.Text = "&Username:";
            // 
            // m_txtName
            // 
            this.m_txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.SetColumnSpan(this.m_txtName, 3);
            this.m_txtName.Location = new System.Drawing.Point(0, 20);
            this.m_txtName.Margin = new System.Windows.Forms.Padding(0, 2, 0, 2);
            this.m_txtName.Name = "m_txtName";
            this.m_txtName.Size = new System.Drawing.Size(380, 23);
            this.m_txtName.TabIndex = 1;
            this.m_txtName.TextChanged += new System.EventHandler(this.TxtName_TextChanged);
            this.m_txtName.Leave += new System.EventHandler(this.TxtName_Leave);
            // 
            // m_btnOK
            // 
            this.m_btnOK.AutoSize = true;
            this.m_btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_btnOK.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_btnOK.Location = new System.Drawing.Point(224, 185);
            this.m_btnOK.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.m_btnOK.MinimumSize = new System.Drawing.Size(75, 23);
            this.m_btnOK.Name = "m_btnOK";
            this.m_btnOK.Size = new System.Drawing.Size(75, 25);
            this.m_btnOK.TabIndex = 8;
            this.m_btnOK.Text = "&OK";
            this.m_btnOK.UseVisualStyleBackColor = true;
            this.m_btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.AutoSize = true;
            this.m_btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnCancel.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_btnCancel.Location = new System.Drawing.Point(305, 185);
            this.m_btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
            this.m_btnCancel.MinimumSize = new System.Drawing.Size(75, 23);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 25);
            this.m_btnCancel.TabIndex = 9;
            this.m_btnCancel.Text = "&Cancel";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            // 
            // EditUserDialog
            // 
            this.AcceptButton = this.m_btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.m_btnCancel;
            this.ClientSize = new System.Drawing.Size(394, 224);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditUserDialog";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EditUserDialog";
            this.Load += new System.EventHandler(this.Window_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}



		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Button m_btnOK;
		private System.Windows.Forms.Button m_btnCancel;
		private System.Windows.Forms.Label m_lblName;
		private System.Windows.Forms.TextBox m_txtName;
		private System.Windows.Forms.TextBox m_txtPasswordConfirm;
		private System.Windows.Forms.Label m_lblPasswordConfirm;
		private System.Windows.Forms.TextBox m_txtNewPassword;
		private System.Windows.Forms.Label m_lblNewPassword;
		private System.Windows.Forms.TextBox m_txtCurrentPassword;
		private System.Windows.Forms.Label m_lblCurrentPassword;
	}
}