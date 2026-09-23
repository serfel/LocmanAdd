namespace TX_Text_Control_Words
{
   partial class ChartDataGridDialog
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
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this._dataGridView = new System.Windows.Forms.DataGridView();
			this._cntxtMnuDataGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.deleteRowsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.deleteColumnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this._dataGridView)).BeginInit();
			this._cntxtMnuDataGrid.SuspendLayout();
			this.SuspendLayout();
			// 
			// _dataGridView
			// 
			this._dataGridView.AllowUserToAddRows = false;
			this._dataGridView.AllowUserToDeleteRows = false;
			this._dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			this._dataGridView.ContextMenuStrip = this._cntxtMnuDataGrid;
			this._dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
			this._dataGridView.Location = new System.Drawing.Point(0, 0);
			this._dataGridView.Name = "_dataGridView";
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this._dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this._dataGridView.RowHeadersWidth = 70;
			this._dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this._dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
			this._dataGridView.Size = new System.Drawing.Size(601, 219);
			this._dataGridView.TabIndex = 0;
			this._dataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridView_KeyDown);
			// 
			// _cntxtMnuDataGrid
			// 
			this._cntxtMnuDataGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteRowsToolStripMenuItem,
            this.deleteColumnsToolStripMenuItem});
			this._cntxtMnuDataGrid.Name = "_cntxtMnuDataGrid";
			this._cntxtMnuDataGrid.Size = new System.Drawing.Size(159, 98);
			this._cntxtMnuDataGrid.Opening += new System.ComponentModel.CancelEventHandler(this.CntxtMnuDataGrid_Opening);
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.copyToolStripMenuItem.Text = "Copy";
			this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItem_Click);
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.pasteToolStripMenuItem.Text = "Paste";
			this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
			// 
			// deleteRowsToolStripMenuItem
			// 
			this.deleteRowsToolStripMenuItem.Name = "deleteRowsToolStripMenuItem";
			this.deleteRowsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.deleteRowsToolStripMenuItem.Text = "Delete Rows";
			this.deleteRowsToolStripMenuItem.Click += new System.EventHandler(this.DeleteRowsToolStripMenuItem_Click);
			// 
			// deleteColumnsToolStripMenuItem
			// 
			this.deleteColumnsToolStripMenuItem.Name = "deleteColumnsToolStripMenuItem";
			this.deleteColumnsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.deleteColumnsToolStripMenuItem.Text = "Delete Columns";
			this.deleteColumnsToolStripMenuItem.Click += new System.EventHandler(this.DeleteColumnsToolStripMenuItem_Click);
			// 
			// ChartDataGridDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.ClientSize = new System.Drawing.Size(601, 219);
			this.Controls.Add(this._dataGridView);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(100, 50);
			this.Name = "ChartDataGridDialog";
			this.RightToLeftLayout = true;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Datasheet";
			this.Load += new System.EventHandler(this.frmEditChartData_Load);
			((System.ComponentModel.ISupportInitialize)(this._dataGridView)).EndInit();
			this._cntxtMnuDataGrid.ResumeLayout(false);
			this.ResumeLayout(false);

      }



      private System.Windows.Forms.DataGridView _dataGridView;
      private System.Windows.Forms.ContextMenuStrip _cntxtMnuDataGrid;
      private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripMenuItem deleteRowsToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem deleteColumnsToolStripMenuItem;

   }
}