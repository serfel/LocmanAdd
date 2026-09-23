using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns10;
using ns13;
using DocumentServer.DataSources;
using DocumentServer.Properties;

namespace DocumentServer.Windows.Forms
{
	/// <summary>The DataSourceExtractionDialog class allows the user to save an excerpt from the currently loaded data source.</summary>
	public class DataSourceExtractionDialog : HighDpiForm
	{
		private DataSourceManager dataSourceManager_0;

		[CompilerGenerated]
		private int int_0;

		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private DataTableInfo dataTableInfo_0;

		private IContainer icontainer_0;

		private TextBox m_txtFileName;

		private System.Windows.Forms.Button m_btnCancel;

		private System.Windows.Forms.Button m_btnOK;

		private Label m_lblRowCount;

		private NumericUpDown m_numMaxRows;

		private Label m_lblFileName;

		private System.Windows.Forms.Button m_btnFileDlg;

		private Label m_lblTable;

		private Class143 m_clbTable;

		private TableLayoutPanel tableLayoutPanel1;

		private TableLayoutPanel tableLayoutPanel2;

		private TableLayoutPanel tableLayoutPanel3;

		/// <summary>Returns the maximum number of data rows from the selected table which were saved into the excerpt file.</summary>
		public int MaxRows
		{
			[CompilerGenerated]
			get
			{
				return this.int_0;
			}
			[CompilerGenerated]
			private set
			{
				this.int_0 = value;
			}
		}

		/// <summary>Returns the file name of the file into which the data source excerpt has been saved.</summary>
		public string FileName
		{
			[CompilerGenerated]
			get
			{
				return this.string_0;
			}
			[CompilerGenerated]
			private set
			{
				this.string_0 = value;
			}
		}

		/// <summary>Returns a description of the table which was selected by the user to be exported.</summary>
		public DataTableInfo SelectedTable
		{
			[CompilerGenerated]
			get
			{
				return this.dataTableInfo_0;
			}
			[CompilerGenerated]
			private set
			{
				this.dataTableInfo_0 = value;
			}
		}

		public DataSourceExtractionDialog(DataSourceManager dataSourceManager)
		{
			this.dataSourceManager_0 = dataSourceManager;
			this.InitializeComponent();
			this.method_2();
			this.SelectedTable = null;
			this.m_clbTable.DisplayMember = "TableName";
		}

		private void method_2()
		{
			this.Text = Resources.SAVE_DB_EXCERPT_DLG_TITLE;
			this.m_lblTable.Text = Resources.SAVE_DB_EXCERPT_DLG_LABEL_ROOT_TBL;
			this.m_lblRowCount.Text = Resources.SAVE_DB_EXCERPT_DLG_LABEL_MAX_ROWS;
			this.m_lblFileName.Text = Resources.SAVE_DB_EXCERPT_DLG_LABEL_EXP_FILE_NAME;
			this.m_btnOK.Text = Resources.SAVE_DB_EXCERPT_DLG_BTN_OK;
			this.m_btnCancel.Text = Resources.SAVE_DB_EXCERPT_DLG_BTN_CANCEL;
		}

		private void DataSourceExtractionDialog_Load(object sender, EventArgs e)
		{
			this.MaxRows = (int)Math.Round(this.m_numMaxRows.Value);
			this.method_3();
			this.m_numMaxRows.Value = 10m;
		}

		private void method_3()
		{
			foreach (DataTableInfo dataTable in this.dataSourceManager_0.DataTables)
			{
				this.m_clbTable.Items.Add(dataTable);
			}
			if (this.m_clbTable.Items.Count > 0)
			{
				this.m_clbTable.SetItemChecked(0, value: true);
				this.SelectedTable = (DataTableInfo)this.m_clbTable.Items[0];
			}
		}

		public new void Show(IWin32Window owner)
		{
			throw new NotSupportedException();
		}

		public new void Show()
		{
			this.Show(null);
		}

		public new DialogResult ShowDialog()
		{
			return this.ShowDialog(null);
		}

		public new DialogResult ShowDialog(IWin32Window owner)
		{
			if (this.dataSourceManager_0.Enum28_0 == Enum28.const_0)
			{
				throw new Exception(Resources.EXC_DATASOURCEMGR_NO_DATA_SOURCE_LOADED);
			}
			if (this.dataSourceManager_0.Enum28_0 != Enum28.const_5)
			{
				throw new Exception(Resources.EXC_DATASOURCEMGR_SAVE_EXCERPT_NOT_POSSIBLE);
			}
			DialogResult num = base.ShowDialog(owner);
			if (num == DialogResult.OK)
			{
				this.dataSourceManager_0.method_34(this.FileName, this.SelectedTable.TableName, this.MaxRows);
			}
			return num;
		}

		private void m_numMaxRows_ValueChanged(object sender, EventArgs e)
		{
			this.MaxRows = (int)Math.Round(this.m_numMaxRows.Value);
		}

		private void m_btnFileDlg_Click(object sender, EventArgs e)
		{
			string initialDirectory = "";
			try
			{
				initialDirectory = Path.GetDirectoryName(this.m_txtFileName.Text);
			}
			catch
			{
			}
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				AddExtension = true,
				Filter = "Extensible Markup Language (*.xml)|*.xml",
				OverwritePrompt = true,
				InitialDirectory = initialDirectory
			};
			if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
			{
				string text2 = (this.FileName = (this.m_txtFileName.Text = saveFileDialog.FileName));
			}
		}

		private void m_txtFileName_TextChanged(object sender, EventArgs e)
		{
			this.FileName = this.m_txtFileName.Text;
			this.m_btnOK.Enabled = !string.IsNullOrEmpty(this.FileName);
		}

		private void m_clbTable_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.SelectedTable = (DataTableInfo)this.m_clbTable.SelectedItem;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.m_txtFileName = new System.Windows.Forms.TextBox();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_lblRowCount = new System.Windows.Forms.Label();
			this.m_numMaxRows = new System.Windows.Forms.NumericUpDown();
			this.m_lblFileName = new System.Windows.Forms.Label();
			this.m_btnFileDlg = new System.Windows.Forms.Button();
			this.m_lblTable = new System.Windows.Forms.Label();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.m_clbTable = new ns13.Class143();
			((System.ComponentModel.ISupportInitialize)this.m_numMaxRows).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.tableLayoutPanel3.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			base.SuspendLayout();
			this.m_txtFileName.Location = new System.Drawing.Point(3, 3);
			this.m_txtFileName.MinimumSize = new System.Drawing.Size(287, 20);
			this.m_txtFileName.Name = "m_txtFileName";
			this.m_txtFileName.Size = new System.Drawing.Size(287, 20);
			this.m_txtFileName.TabIndex = 3;
			this.m_txtFileName.TextChanged += new System.EventHandler(m_txtFileName_TextChanged);
			this.m_btnCancel.AutoSize = true;
			this.m_btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnCancel.Location = new System.Drawing.Point(178, 383);
			this.m_btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
			this.m_btnCancel.MinimumSize = new System.Drawing.Size(72, 23);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(72, 23);
			this.m_btnCancel.TabIndex = 6;
			this.m_btnCancel.Text = "Cancel";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			this.m_btnOK.AutoSize = true;
			this.m_btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.m_btnOK.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnOK.Enabled = false;
			this.m_btnOK.Location = new System.Drawing.Point(100, 383);
			this.m_btnOK.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.m_btnOK.MinimumSize = new System.Drawing.Size(72, 23);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(72, 23);
			this.m_btnOK.TabIndex = 5;
			this.m_btnOK.Text = "OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_lblRowCount.AutoSize = true;
			this.m_lblRowCount.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblRowCount.Location = new System.Drawing.Point(3, 3);
			this.m_lblRowCount.Margin = new System.Windows.Forms.Padding(3);
			this.m_lblRowCount.MaximumSize = new System.Drawing.Size(259, 26);
			this.m_lblRowCount.Name = "m_lblRowCount";
			this.m_lblRowCount.Size = new System.Drawing.Size(259, 13);
			this.m_lblRowCount.TabIndex = 0;
			this.m_lblRowCount.Text = "Set maximum number of exported rows (0 = unlimited):";
			this.m_numMaxRows.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_numMaxRows.Location = new System.Drawing.Point(268, 3);
			this.m_numMaxRows.Maximum = new decimal(new int[4] { 1000000, 0, 0, 0 });
			this.m_numMaxRows.Name = "m_numMaxRows";
			this.m_numMaxRows.Size = new System.Drawing.Size(58, 20);
			this.m_numMaxRows.TabIndex = 1;
			this.m_numMaxRows.ValueChanged += new System.EventHandler(m_numMaxRows_ValueChanged);
			this.m_lblFileName.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.m_lblFileName, 3);
			this.m_lblFileName.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblFileName.Location = new System.Drawing.Point(3, 341);
			this.m_lblFileName.Name = "m_lblFileName";
			this.m_lblFileName.Size = new System.Drawing.Size(244, 13);
			this.m_lblFileName.TabIndex = 2;
			this.m_lblFileName.Text = "Select export file name:";
			this.m_btnFileDlg.Location = new System.Drawing.Point(296, 3);
			this.m_btnFileDlg.Name = "m_btnFileDlg";
			this.m_btnFileDlg.Size = new System.Drawing.Size(29, 20);
			this.m_btnFileDlg.TabIndex = 4;
			this.m_btnFileDlg.Text = "…";
			this.m_btnFileDlg.UseVisualStyleBackColor = true;
			this.m_btnFileDlg.Click += new System.EventHandler(m_btnFileDlg_Click);
			this.m_lblTable.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.m_lblTable, 3);
			this.m_lblTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lblTable.Location = new System.Drawing.Point(3, 0);
			this.m_lblTable.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
			this.m_lblTable.Name = "m_lblTable";
			this.m_lblTable.Size = new System.Drawing.Size(244, 39);
			this.m_lblTable.TabIndex = 7;
			this.m_lblTable.Text = "Select root table (rows of other tables are included as needed according to the existing data relations):";
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.m_lblTable, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.m_clbTable, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 4);
			this.tableLayoutPanel1.Controls.Add(this.m_lblFileName, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.m_btnOK, 1, 5);
			this.tableLayoutPanel1.Controls.Add(this.m_btnCancel, 2, 5);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 7);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 6;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(250, 391);
			this.tableLayoutPanel1.TabIndex = 9;
			this.tableLayoutPanel3.AutoSize = true;
			this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel3.ColumnCount = 2;
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel3, 3);
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20f));
			this.tableLayoutPanel3.Controls.Add(this.m_lblRowCount, 0, 0);
			this.tableLayoutPanel3.Controls.Add(this.m_numMaxRows, 1, 0);
			this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 315);
			this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel3.Name = "tableLayoutPanel3";
			this.tableLayoutPanel3.RowCount = 1;
			this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel3.Size = new System.Drawing.Size(250, 26);
			this.tableLayoutPanel3.TabIndex = 10;
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 2;
			this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 3);
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.m_txtFileName, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.m_btnFileDlg, 1, 0);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 354);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 1;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.Size = new System.Drawing.Size(250, 26);
			this.tableLayoutPanel2.TabIndex = 10;
			this.m_clbTable.CheckOnClick = true;
			this.tableLayoutPanel1.SetColumnSpan(this.m_clbTable, 3);
			this.m_clbTable.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_clbTable.FormattingEnabled = true;
			this.m_clbTable.IntegralHeight = false;
			this.m_clbTable.Location = new System.Drawing.Point(3, 45);
			this.m_clbTable.MinimumSize = new System.Drawing.Size(320, 266);
			this.m_clbTable.Name = "m_clbTable";
			this.m_clbTable.Size = new System.Drawing.Size(320, 267);
			this.m_clbTable.TabIndex = 8;
			this.m_clbTable.SelectedIndexChanged += new System.EventHandler(m_clbTable_SelectedIndexChanged);
			base.AcceptButton = this.m_btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.m_btnCancel;
			base.ClientSize = new System.Drawing.Size(264, 405);
			base.Controls.Add(this.tableLayoutPanel1);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "DataSourceExtractionDialog";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			this.Text = "Save Data Base Excerpt";
			base.Load += new System.EventHandler(DataSourceExtractionDialog_Load);
			((System.ComponentModel.ISupportInitialize)this.m_numMaxRows).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.tableLayoutPanel3.ResumeLayout(false);
			this.tableLayoutPanel3.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
