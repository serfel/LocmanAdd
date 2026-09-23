namespace TX_Text_Control_Words.FormFields {
	partial class SelectionFormFieldDialog {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectionFormFieldDialog));
			this.grpBoxItems = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.itemsControl = new System.Windows.Forms.DataGridView();
			this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.m_btnDeleteDropDownItem = new System.Windows.Forms.Button();
			this.m_btnNewDropDownListItem = new System.Windows.Forms.Button();
			this.m_btnComboBoxListItemMoveUp = new System.Windows.Forms.Button();
			this.m_btnComboBoxListItemMoveDown = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.emptyWidthControl = new TX_Text_Control_Words.FormFields.EmptyWidthControl();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.grpBoxItems.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.itemsControl)).BeginInit();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpBoxItems
			// 
			resources.ApplyResources(this.grpBoxItems, "grpBoxItems");
			this.grpBoxItems.Controls.Add(this.tableLayoutPanel1);
			this.grpBoxItems.Name = "grpBoxItems";
			this.grpBoxItems.TabStop = false;
			// 
			// tableLayoutPanel1
			// 
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.itemsControl, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.m_btnDeleteDropDownItem, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.m_btnNewDropDownListItem, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.m_btnComboBoxListItemMoveUp, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.m_btnComboBoxListItemMoveDown, 1, 1);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			// 
			// itemsControl
			// 
			this.itemsControl.AllowUserToAddRows = false;
			this.itemsControl.AllowUserToResizeColumns = false;
			this.itemsControl.AllowUserToResizeRows = false;
			this.itemsControl.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.itemsControl.BackgroundColor = System.Drawing.SystemColors.Window;
			this.itemsControl.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
			this.itemsControl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.itemsControl.ColumnHeadersVisible = false;
			this.itemsControl.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colData});
			resources.ApplyResources(this.itemsControl, "itemsControl");
			this.itemsControl.MultiSelect = false;
			this.itemsControl.Name = "itemsControl";
			this.itemsControl.RowHeadersVisible = false;
			this.tableLayoutPanel1.SetRowSpan(this.itemsControl, 4);
			this.itemsControl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.itemsControl.StandardTab = true;
			this.itemsControl.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.itemsControl_CellBeginEdit);
			this.itemsControl.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.itemsControl_CellEndEdit);
			this.itemsControl.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.itemsControl_CellValidating);
			// 
			// colData
			// 
			resources.ApplyResources(this.colData, "colData");
			this.colData.Name = "colData";
			// 
			// m_btnDeleteDropDownItem
			// 
			resources.ApplyResources(this.m_btnDeleteDropDownItem, "m_btnDeleteDropDownItem");
			this.m_btnDeleteDropDownItem.Name = "m_btnDeleteDropDownItem";
			this.m_btnDeleteDropDownItem.Tag = "";
			this.m_btnDeleteDropDownItem.UseVisualStyleBackColor = true;
			this.m_btnDeleteDropDownItem.Click += new System.EventHandler(this.m_btnDeleteDropDownItem_Click);
			// 
			// m_btnNewDropDownListItem
			// 
			resources.ApplyResources(this.m_btnNewDropDownListItem, "m_btnNewDropDownListItem");
			this.m_btnNewDropDownListItem.Name = "m_btnNewDropDownListItem";
			this.m_btnNewDropDownListItem.Tag = "";
			this.m_btnNewDropDownListItem.UseVisualStyleBackColor = true;
			this.m_btnNewDropDownListItem.Click += new System.EventHandler(this.m_btnNewDropDownListItem_Click);
			// 
			// m_btnComboBoxListItemMoveUp
			// 
			resources.ApplyResources(this.m_btnComboBoxListItemMoveUp, "m_btnComboBoxListItemMoveUp");
			this.m_btnComboBoxListItemMoveUp.Name = "m_btnComboBoxListItemMoveUp";
			this.m_btnComboBoxListItemMoveUp.Tag = "";
			this.m_btnComboBoxListItemMoveUp.UseVisualStyleBackColor = true;
			this.m_btnComboBoxListItemMoveUp.Click += new System.EventHandler(this.btnUp_Click);
			// 
			// m_btnComboBoxListItemMoveDown
			// 
			resources.ApplyResources(this.m_btnComboBoxListItemMoveDown, "m_btnComboBoxListItemMoveDown");
			this.m_btnComboBoxListItemMoveDown.Name = "m_btnComboBoxListItemMoveDown";
			this.m_btnComboBoxListItemMoveDown.Tag = "";
			this.m_btnComboBoxListItemMoveDown.UseVisualStyleBackColor = true;
			this.m_btnComboBoxListItemMoveDown.Click += new System.EventHandler(this.btnDown_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			resources.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Tag = "Abort the action.";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// m_btnOK
			// 
			this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			resources.ApplyResources(this.m_btnOK, "m_btnOK");
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Tag = "Confirm the action.";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnOK.Click += new System.EventHandler(this.m_btnOK_Click);
			// 
			// tableLayoutPanel2
			// 
			resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
			this.tableLayoutPanel2.Controls.Add(this.emptyWidthControl, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.grpBoxItems, 0, 1);
			this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			// 
			// emptyWidthControl
			// 
			resources.ApplyResources(this.emptyWidthControl, "emptyWidthControl");
			this.emptyWidthControl.Name = "emptyWidthControl";
			this.emptyWidthControl.Value = 0;
			// 
			// tableLayoutPanel3
			// 
			resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
			this.tableLayoutPanel3.Controls.Add(this.m_btnOK, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.btnCancel, 1, 0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			// 
			// SelectionFormFieldDialog
			// 
			this.AcceptButton = this.m_btnOK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			resources.ApplyResources(this, "$this");
			this.CancelButton = this.btnCancel;
			this.Controls.Add(this.tableLayoutPanel2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SelectionFormFieldDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.grpBoxItems.ResumeLayout(false);
			this.grpBoxItems.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.itemsControl)).EndInit();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.GroupBox grpBoxItems;
		private System.Windows.Forms.Button m_btnComboBoxListItemMoveUp;
		private System.Windows.Forms.DataGridView itemsControl;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button m_btnOK;
		private System.Windows.Forms.DataGridViewTextBoxColumn colData;
		private EmptyWidthControl emptyWidthControl;
		private System.Windows.Forms.Button m_btnNewDropDownListItem;
		private System.Windows.Forms.Button m_btnDeleteDropDownItem;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
		private System.Windows.Forms.Button m_btnComboBoxListItemMoveDown;
	}
}