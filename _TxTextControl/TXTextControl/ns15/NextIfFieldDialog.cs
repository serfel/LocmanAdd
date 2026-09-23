using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using ns12;
using DocumentServer.Fields;
using DocumentServer.Properties;
using DocumentServer.Windows.Forms;

namespace ns15
{
	internal class NextIfFieldDialog : HighDpiForm
	{
		private Dialog4 dialog4_0;

		private Class139 class139_0;

		private IContainer icontainer_0;

		private Button btnCancel;

		private Button btnOK;

		private GroupBox grpIF;

		private ComboBox cbComparison;

		private TextBox tbCompareTo;

		private Label lblCompTo;

		private Label lblComp;

		private Label lblName;

		private TextBox tbFieldName;

		private TableLayoutPanel tableLayoutPanel1;

		private TableLayoutPanel tableLayoutPanel2;

		public NextIfFieldDialog(NextIfField nextIfField_0)
		{
			this.InitializeComponent();
			this.dialog4_0 = new Dialog4(nextIfField_0);
			this.class139_0 = new Class139(this.dialog4_0);
			this.Text = Resources.NEXTIF_FIELD_DIALOG_TITLE;
			this.grpIF.Text = Resources.IF_FIELD_GROUP_BOX;
			this.lblName.Text = Resources.IF_FIELD_LABEL_NAME;
			this.lblComp.Text = Resources.IF_FIELD_LABEL_COMPARISON;
			this.cbComparison.Items.AddRange(new object[6]
			{
				Resources.IF_FIELD_COMBO_BOX_COMPARISON_EQUALS,
				Resources.IF_FIELD_COMBO_BOX_COMPARISON_NOT_EQUAL,
				Resources.IF_FIELD_COMBO_BOX_COMPARISON_LESS,
				Resources.IF_FIELD_COMBO_BOX_COMPARISON_GREATER,
				Resources.IF_FIELD_COMBO_BOX_COMPARISON_GREATER_OR_EQUAL,
				Resources.IF_FIELD_COMBO_BOX_COMPARISON_LESS_OR_EQUAL
			});
			this.lblCompTo.Text = Resources.IF_FIELD_LABEL_COMPARE_TO;
			this.btnOK.Text = Resources.IF_FIELD_BUTTON_OK;
			this.btnCancel.Text = Resources.IF_FIELD_BUTTON_CANCEL;
			this.method_2();
		}

		[Obfuscation(Exclude = true)]
		public DocumentServer.Fields.DialogResult ShowFieldDialog(IWin32Window owner)
		{
			return base.ShowDialog(owner) switch
			{
				System.Windows.Forms.DialogResult.Cancel => DocumentServer.Fields.DialogResult.Cancel, 
				System.Windows.Forms.DialogResult.OK => DocumentServer.Fields.DialogResult.OK, 
				_ => DocumentServer.Fields.DialogResult.None, 
			};
		}

		private void method_2()
		{
			this.tbFieldName.Text = this.class139_0.String_0;
			this.tbCompareTo.Text = this.class139_0.String_1;
			this.cbComparison.SelectedIndex = this.class139_0.Int32_0;
		}

		private void method_3()
		{
			if (this.class139_0.String_0 != this.tbFieldName.Text)
			{
				this.dialog4_0.String_0 = this.tbFieldName.Text;
			}
			if (this.class139_0.String_1 != this.tbCompareTo.Text)
			{
				this.dialog4_0.String_1 = this.tbCompareTo.Text;
			}
			if (this.class139_0.Int32_0 != this.cbComparison.SelectedIndex)
			{
				this.dialog4_0.Int32_0 = this.cbComparison.SelectedIndex;
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			this.method_3();
			base.Close();
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.grpIF = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.lblCompTo = new System.Windows.Forms.Label();
			this.tbCompareTo = new System.Windows.Forms.TextBox();
			this.lblComp = new System.Windows.Forms.Label();
			this.cbComparison = new System.Windows.Forms.ComboBox();
			this.lblName = new System.Windows.Forms.Label();
			this.tbFieldName = new System.Windows.Forms.TextBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.grpIF.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			base.SuspendLayout();
			this.btnCancel.AutoSize = true;
			this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(264, 65);
			this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
			this.btnCancel.MinimumSize = new System.Drawing.Size(72, 23);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(72, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnOK.AutoSize = true;
			this.btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(186, 65);
			this.btnOK.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.btnOK.MinimumSize = new System.Drawing.Size(72, 23);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(72, 23);
			this.btnOK.TabIndex = 1;
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(btnOK_Click);
			this.grpIF.AutoSize = true;
			this.grpIF.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.SetColumnSpan(this.grpIF, 3);
			this.grpIF.Controls.Add(this.tableLayoutPanel2);
			this.grpIF.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpIF.Location = new System.Drawing.Point(0, 0);
			this.grpIF.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
			this.grpIF.Name = "grpIF";
			this.grpIF.Size = new System.Drawing.Size(336, 59);
			this.grpIF.TabIndex = 0;
			this.grpIF.TabStop = false;
			this.grpIF.Text = "x";
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 3;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.lblCompTo, 2, 0);
			this.tableLayoutPanel2.Controls.Add(this.tbCompareTo, 2, 1);
			this.tableLayoutPanel2.Controls.Add(this.lblComp, 1, 0);
			this.tableLayoutPanel2.Controls.Add(this.cbComparison, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.lblName, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.tbFieldName, 0, 1);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.Size = new System.Drawing.Size(330, 40);
			this.tableLayoutPanel2.TabIndex = 4;
			this.lblCompTo.AutoSize = true;
			this.lblCompTo.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblCompTo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lblCompTo.Location = new System.Drawing.Point(258, 0);
			this.lblCompTo.Name = "lblCompTo";
			this.lblCompTo.Size = new System.Drawing.Size(121, 13);
			this.lblCompTo.TabIndex = 4;
			this.lblCompTo.Text = "x";
			this.tbCompareTo.Dock = System.Windows.Forms.DockStyle.Left;
			this.tbCompareTo.Location = new System.Drawing.Point(258, 16);
			this.tbCompareTo.MinimumSize = new System.Drawing.Size(121, 20);
			this.tbCompareTo.Name = "tbCompareTo";
			this.tbCompareTo.Size = new System.Drawing.Size(121, 20);
			this.tbCompareTo.TabIndex = 5;
			this.lblComp.AutoSize = true;
			this.lblComp.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblComp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.lblComp.Location = new System.Drawing.Point(130, 0);
			this.lblComp.Name = "lblComp";
			this.lblComp.Size = new System.Drawing.Size(122, 13);
			this.lblComp.TabIndex = 2;
			this.lblComp.Text = "x";
			this.cbComparison.Dock = System.Windows.Forms.DockStyle.Left;
			this.cbComparison.FormattingEnabled = true;
			this.cbComparison.Location = new System.Drawing.Point(130, 16);
			this.cbComparison.MinimumSize = new System.Drawing.Size(121, 0);
			this.cbComparison.Name = "cbComparison";
			this.cbComparison.Size = new System.Drawing.Size(122, 21);
			this.cbComparison.TabIndex = 3;
			this.lblName.AutoSize = true;
			this.lblName.Dock = System.Windows.Forms.DockStyle.Top;
			this.lblName.Location = new System.Drawing.Point(3, 0);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(121, 13);
			this.lblName.TabIndex = 0;
			this.lblName.Text = "x";
			this.tbFieldName.Dock = System.Windows.Forms.DockStyle.Left;
			this.tbFieldName.Location = new System.Drawing.Point(3, 16);
			this.tbFieldName.MinimumSize = new System.Drawing.Size(121, 20);
			this.tbFieldName.Name = "tbFieldName";
			this.tbFieldName.Size = new System.Drawing.Size(121, 20);
			this.tbFieldName.TabIndex = 1;
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 3;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.btnOK, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.grpIF, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.btnCancel, 2, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 7);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(336, 55);
			this.tableLayoutPanel1.TabIndex = 3;
			base.AcceptButton = this.btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.btnCancel;
			base.ClientSize = new System.Drawing.Size(350, 69);
			base.Controls.Add(this.tableLayoutPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "NextIfFieldDialog";
			base.Padding = new System.Windows.Forms.Padding(7);
			this.RightToLeftLayout = true;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.grpIF.ResumeLayout(false);
			this.grpIF.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.tableLayoutPanel2.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
