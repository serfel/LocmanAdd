namespace TX_Text_Control_Words
{
	partial class UserAdminDialog
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
			this.m_lbUsers = new System.Windows.Forms.ListBox();
			this.m_lblUsers = new System.Windows.Forms.Label();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.m_btnNew = new System.Windows.Forms.Button();
			this.m_btnEdit = new System.Windows.Forms.Button();
			this.m_btnDelete = new System.Windows.Forms.Button();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
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
			this.tableLayoutPanel1.Controls.Add(this.m_lbUsers, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.m_lblUsers, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 2);
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
			this.tableLayoutPanel1.SetColumnSpan(this.m_lbUsers, 2);
			this.m_lbUsers.DisplayMember = "Name";
			this.m_lbUsers.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lbUsers.FormattingEnabled = true;
			this.m_lbUsers.IntegralHeight = false;
			this.m_lbUsers.ItemHeight = 15;
			this.m_lbUsers.Location = new System.Drawing.Point(0, 21);
			this.m_lbUsers.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
			this.m_lbUsers.Name = "m_lbUsers";
			this.m_lbUsers.Size = new System.Drawing.Size(269, 240);
			this.m_lbUsers.TabIndex = 1;
			this.m_lbUsers.SelectedValueChanged += new System.EventHandler(this.LbUsers_SelectedValueChanged);
			// 
			// m_lblUsers
			// 
			this.m_lblUsers.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.m_lblUsers, 3);
			this.m_lblUsers.Location = new System.Drawing.Point(0, 0);
			this.m_lblUsers.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
			this.m_lblUsers.Name = "m_lblUsers";
			this.m_lblUsers.Size = new System.Drawing.Size(38, 15);
			this.m_lblUsers.TabIndex = 0;
			this.m_lblUsers.Text = "Users:";
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.m_btnNew, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.m_btnEdit, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.m_btnDelete, 0, 2);
			this.tableLayoutPanel2.Location = new System.Drawing.Point(274, 20);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 3;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.Size = new System.Drawing.Size(78, 93);
			this.tableLayoutPanel2.TabIndex = 2;
			// 
			// m_btnNew
			// 
			this.m_btnNew.AutoSize = true;
			this.m_btnNew.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnNew.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnNew.Location = new System.Drawing.Point(3, 3);
			this.m_btnNew.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.m_btnNew.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnNew.Name = "m_btnNew";
			this.m_btnNew.Size = new System.Drawing.Size(75, 25);
			this.m_btnNew.TabIndex = 2;
			this.m_btnNew.Text = "New…";
			this.m_btnNew.UseVisualStyleBackColor = true;
			this.m_btnNew.Click += new System.EventHandler(this.BtnNew_Click);
			// 
			// m_btnEdit
			// 
			this.m_btnEdit.AutoSize = true;
			this.m_btnEdit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnEdit.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnEdit.Enabled = false;
			this.m_btnEdit.Location = new System.Drawing.Point(3, 34);
			this.m_btnEdit.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.m_btnEdit.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnEdit.Name = "m_btnEdit";
			this.m_btnEdit.Size = new System.Drawing.Size(75, 25);
			this.m_btnEdit.TabIndex = 3;
			this.m_btnEdit.Text = "Edit…";
			this.m_btnEdit.UseVisualStyleBackColor = true;
			this.m_btnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
			// 
			// m_btnDelete
			// 
			this.m_btnDelete.AutoSize = true;
			this.m_btnDelete.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnDelete.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnDelete.Enabled = false;
			this.m_btnDelete.Location = new System.Drawing.Point(3, 65);
			this.m_btnDelete.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
			this.m_btnDelete.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnDelete.Name = "m_btnDelete";
			this.m_btnDelete.Size = new System.Drawing.Size(75, 25);
			this.m_btnDelete.TabIndex = 4;
			this.m_btnDelete.Text = "Delete";
			this.m_btnDelete.UseVisualStyleBackColor = true;
			this.m_btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
			// 
			// tableLayoutPanel3
			// 
			this.tableLayoutPanel3.AutoSize = true;
			this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 2);
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.Controls.Add(this.m_btnCancel, 1, 0);
			this.tableLayoutPanel3.Controls.Add(this.m_btnOK, 0, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(195, 264);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel3.Size = new System.Drawing.Size(159, 28);
			this.tableLayoutPanel3.TabIndex = 3;
			// 
			// m_btnCancel
			// 
			this.m_btnCancel.AutoSize = true;
			this.m_btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnCancel.Location = new System.Drawing.Point(84, 3);
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
			this.m_btnOK.Location = new System.Drawing.Point(3, 3);
			this.m_btnOK.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.m_btnOK.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(75, 25);
			this.m_btnOK.TabIndex = 5;
			this.m_btnOK.Text = "OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(this.BtnOK_Click);
			// 
			// UserAdminDialog
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
			this.Name = "UserAdminDialog";
			this.Padding = new System.Windows.Forms.Padding(7);
			this.RightToLeftLayout = true;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "UserAdminDialog";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}



		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ListBox m_lbUsers;
		private System.Windows.Forms.Label m_lblUsers;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button m_btnNew;
		private System.Windows.Forms.Button m_btnEdit;
		private System.Windows.Forms.Button m_btnDelete;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Button m_btnCancel;
		private System.Windows.Forms.Button m_btnOK;
	}
}