namespace TX_Text_Control_Words
{
	partial class UserAccessDialog
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.m_lbUsers = new TX_Text_Control_Words.UserInfoListBox();
			this.m_lblRegUsers = new System.Windows.Forms.Label();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.m_btnManage = new System.Windows.Forms.Button();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.m_btnCurrentAuthor = new System.Windows.Forms.Button();
			this.m_btnGrantAccess = new System.Windows.Forms.Button();
			this.m_btnRevokeAccess = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.m_lbUsers, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.m_lblRegUsers, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 7);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(309, 292);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 3;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(354, 292);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// m_lbUsers
			// 
			this.m_lbUsers.Author = null;
			this.m_lbUsers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lbUsers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.m_lbUsers.FormattingEnabled = true;
			this.m_lbUsers.IntegralHeight = false;
			this.m_lbUsers.ItemHeight = 16;
			this.m_lbUsers.Location = new System.Drawing.Point(0, 21);
			this.m_lbUsers.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
			this.m_lbUsers.Name = "m_lbUsers";
			this.m_lbUsers.Size = new System.Drawing.Size(247, 240);
			this.m_lbUsers.TabIndex = 1;
			this.m_lbUsers.SelectedValueChanged += new System.EventHandler(this.LbUsers_SelectedValueChanged);
			// 
			// m_lblRegUsers
			// 
			this.m_lblRegUsers.AutoSize = true;
			this.m_lblRegUsers.Location = new System.Drawing.Point(0, 0);
			this.m_lblRegUsers.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
			this.m_lblRegUsers.Name = "m_lblRegUsers";
			this.m_lblRegUsers.Size = new System.Drawing.Size(38, 15);
			this.m_lblRegUsers.TabIndex = 0;
			this.m_lblRegUsers.Text = "&Users:";
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.AutoSize = true;
			this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel3.ColumnCount = 4;
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 2);
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.Controls.Add(this.m_btnManage, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.m_btnCancel, 3, 0);
			this.tableLayoutPanel3.Controls.Add(this.m_btnOK, 2, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 264);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(354, 28);
			this.tableLayoutPanel3.TabIndex = 3;
			// 
			// m_btnManage
			// 
			this.m_btnManage.AutoSize = true;
			this.m_btnManage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnManage.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnManage.Location = new System.Drawing.Point(0, 3);
			this.m_btnManage.Margin = new System.Windows.Forms.Padding(0, 3, 3, 0);
			this.m_btnManage.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnManage.Name = "m_btnManage";
			this.m_btnManage.Size = new System.Drawing.Size(100, 25);
			this.m_btnManage.TabIndex = 4;
			this.m_btnManage.Text = "Manage Users...";
			this.m_btnManage.UseVisualStyleBackColor = true;
			this.m_btnManage.Click += new System.EventHandler(this.BtnManage_Click);
			// 
			// m_btnCancel
			// 
			this.m_btnCancel.AutoSize = true;
			this.m_btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnCancel.Location = new System.Drawing.Point(279, 3);
			this.m_btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
			this.m_btnCancel.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(75, 25);
			this.m_btnCancel.TabIndex = 6;
			this.m_btnCancel.Text = "Cancel";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			// 
			// m_btnOK
			// 
			this.m_btnOK.AutoSize = true;
			this.m_btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnOK.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnOK.Location = new System.Drawing.Point(198, 3);
			this.m_btnOK.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.m_btnOK.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(75, 25);
			this.m_btnOK.TabIndex = 5;
			this.m_btnOK.Text = "OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(this.BtnOK_Click);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.m_btnCurrentAuthor, 0, 2);
			this.tableLayoutPanel2.Controls.Add(this.m_btnGrantAccess, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.m_btnRevokeAccess, 0, 1);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(252, 20);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 3;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.Size = new System.Drawing.Size(100, 93);
			this.tableLayoutPanel2.TabIndex = 2;
			// 
			// m_btnCurrentAuthor
			// 
			this.m_btnCurrentAuthor.AutoSize = true;
			this.m_btnCurrentAuthor.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnCurrentAuthor.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnCurrentAuthor.Location = new System.Drawing.Point(3, 65);
			this.m_btnCurrentAuthor.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.m_btnCurrentAuthor.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnCurrentAuthor.Name = "m_btnCurrentAuthor";
			this.m_btnCurrentAuthor.Size = new System.Drawing.Size(97, 25);
			this.m_btnCurrentAuthor.TabIndex = 4;
			this.m_btnCurrentAuthor.Text = "Current Author";
			this.m_btnCurrentAuthor.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
			this.m_btnCurrentAuthor.UseVisualStyleBackColor = true;
			this.m_btnCurrentAuthor.Click += new System.EventHandler(this.BtnCurrentAuthor_Click);
			// 
			// m_btnGrantAccess
			// 
			this.m_btnGrantAccess.AutoSize = true;
			this.m_btnGrantAccess.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnGrantAccess.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnGrantAccess.Enabled = false;
			this.m_btnGrantAccess.Location = new System.Drawing.Point(3, 3);
			this.m_btnGrantAccess.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.m_btnGrantAccess.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnGrantAccess.Name = "m_btnGrantAccess";
			this.m_btnGrantAccess.Size = new System.Drawing.Size(97, 25);
			this.m_btnGrantAccess.TabIndex = 2;
			this.m_btnGrantAccess.Text = "Grant Access";
			this.m_btnGrantAccess.UseVisualStyleBackColor = true;
			this.m_btnGrantAccess.Click += new System.EventHandler(this.BtnGrantAccess_Click);
			// 
			// m_btnRevokeAccess
			// 
			this.m_btnRevokeAccess.AutoSize = true;
			this.m_btnRevokeAccess.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnRevokeAccess.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnRevokeAccess.Enabled = false;
			this.m_btnRevokeAccess.Location = new System.Drawing.Point(3, 34);
			this.m_btnRevokeAccess.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.m_btnRevokeAccess.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnRevokeAccess.Name = "m_btnRevokeAccess";
			this.m_btnRevokeAccess.Size = new System.Drawing.Size(97, 25);
			this.m_btnRevokeAccess.TabIndex = 3;
			this.m_btnRevokeAccess.Text = "Revoke Access";
			this.m_btnRevokeAccess.UseVisualStyleBackColor = true;
			this.m_btnRevokeAccess.Click += new System.EventHandler(this.BtnRevokeAccess_Click);
			// 
			// UserAccessDialog
			// 
			this.AcceptButton = this.m_btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.CancelButton = this.m_btnCancel;
			this.ClientSize = new System.Drawing.Size(368, 305);
			this.Controls.Add(this.tableLayoutPanel1);
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(2);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "UserAccessDialog";
			this.Padding = new System.Windows.Forms.Padding(7);
			this.RightToLeftLayout = true;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "UserAccessDialog";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}



		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private TX_Text_Control_Words.UserInfoListBox m_lbUsers;
		private System.Windows.Forms.Label m_lblRegUsers;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button m_btnGrantAccess;
		private System.Windows.Forms.Button m_btnRevokeAccess;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Button m_btnCancel;
		private System.Windows.Forms.Button m_btnOK;
		private System.Windows.Forms.Button m_btnManage;
		private System.Windows.Forms.Button m_btnCurrentAuthor;
	}
}