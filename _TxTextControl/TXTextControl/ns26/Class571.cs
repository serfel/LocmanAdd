using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;
using TXTextControl;
using TXTextControl.Windows.Forms;

namespace ns26
{
	internal class Class571 : ContentPanel
	{
		internal class Class582
		{
			internal DocumentTarget documentTarget_0;

			internal Class582(DocumentTarget documentTarget_1)
			{
				this.documentTarget_0 = documentTarget_1;
			}

			public override string ToString()
			{
				return this.documentTarget_0.TargetName;
			}
		}

		internal class Class583
		{
			internal int int_0;

			private string string_0;

			internal Class583(int int_1, string string_1)
			{
				this.int_0 = int_1;
				this.string_0 = string_1;
			}

			public override string ToString()
			{
				return this.string_0;
			}
		}

		private Label label_0;

		private ListControl TXITEM_GotoList;

		private Label label_1;

		private ComboBox comboBox_0;

		private TableLayoutPanel tableLayoutPanel_0;

		private System.Windows.Forms.Button button_0;

		internal System.Windows.Forms.Button button_1;

		internal System.Windows.Forms.Button button_2;

		private int int_0;

		private int int_1;

		internal Class571(Enum140 enum140_0, TextControl textControl_0, bool bool_0, Sidebar.SidebarContentLayout sidebarContentLayout_0, PointF pointF_0)
			: base(enum140_0, textControl_0, bool_0, sidebarContentLayout_0, pointF_0)
		{
			this.label_0.Text = base.m_rm.GetString("ID_GOTO_ELEMENT");
			this.label_1.Text = base.m_rm.GetString("ID_GOTO_PAGENUMBER");
			this.method_3();
			this.button_0.Text = base.m_rm.GetString("ID_GOTO_PREVIOUS");
			this.button_1.Text = base.m_rm.GetString("ID_GOTO_NEXT");
			this.button_2.Text = base.m_rm.GetString("ID_GOTO_CLOSE");
			this.TXITEM_GotoList.SelectedIndex = 0;
		}

		public override Size GetPreferredSize(Size proposedSize)
		{
			Size preferredSize = base.GetPreferredSize(Size.Empty);
			if (base.m_cpaPanelAlignment == Enum140.const_2)
			{
				int num = Math.Max(preferredSize.Width, Math.Max(this.tableLayoutPanel_0.GetPreferredSize(Size.Empty).Width, Class517.smethod_45(200, base.m_pntDpi.X))) + base.Padding.Horizontal;
				return new Size(num, preferredSize.Height);
			}
			return preferredSize;
		}

		internal override void DoLayout()
		{
			base.ResumeLayout(performLayout: false);
			base.PerformLayout();
			this.tableLayoutPanel_0.ResumeLayout(performLayout: false);
			this.tableLayoutPanel_0.PerformLayout();
		}

		internal override void DoSuspendLayout()
		{
			base.SuspendLayout();
			this.tableLayoutPanel_0.SuspendLayout();
		}

		internal override void InitializeItems()
		{
			base.Name = "TXITEM_MainPanel";
			this.AutoSize = true;
			this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.comboBox_0 = new ComboBox();
			this.label_0 = new Label();
			this.label_1 = new Label();
			if (base.m_cpaPanelAlignment == Enum140.const_1)
			{
				this.TXITEM_GotoList = new ComboBox();
			}
			else
			{
				this.TXITEM_GotoList = new ListBox();
				(this.TXITEM_GotoList as ListBox).IntegralHeight = false;
			}
			this.tableLayoutPanel_0 = new TableLayoutPanel
			{
				AutoSize = true,
				AutoSizeMode = AutoSizeMode.GrowAndShrink
			};
			this.button_0 = new System.Windows.Forms.Button();
			this.button_1 = new System.Windows.Forms.Button();
			this.button_2 = new System.Windows.Forms.Button();
			this.comboBox_0.Dock = DockStyle.Top;
			this.comboBox_0.DropDownStyle = ComboBoxStyle.Simple;
			this.comboBox_0.Name = Sidebar.GotoItem.TXITEM_Number.ToString();
			this.comboBox_0.TabIndex = 3;
			this.comboBox_0.DropDown += comboBox_0_DropDown;
			this.comboBox_0.TextChanged += comboBox_0_TextChanged;
			this.comboBox_0.GotFocus += comboBox_0_GotFocus;
			this.comboBox_0.KeyDown += comboBox_0_KeyDown;
			this.label_0.AutoSize = true;
			this.label_0.Dock = DockStyle.Top;
			this.label_0.Name = Sidebar.GotoItem.TXITEM_GotoLabel.ToString();
			this.label_0.TabIndex = 0;
			this.label_0.Text = "Go to what:";
			this.label_1.AutoSize = true;
			this.label_1.Dock = DockStyle.Top;
			this.label_1.Name = "TXITEM_NumberLabel";
			this.label_1.TabIndex = 2;
			this.label_1.Text = "Page number:";
			this.method_5();
			this.button_0.AutoSize = true;
			this.button_0.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.button_0.Dock = DockStyle.Top;
			this.button_0.Name = "TXITEM_GotoPrevious";
			this.button_0.TabIndex = 4;
			this.button_0.Text = "Previous";
			this.button_0.UseVisualStyleBackColor = true;
			this.button_0.Click += button_0_Click;
			this.button_1.AutoSize = true;
			this.button_1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.button_1.Dock = DockStyle.Top;
			this.button_1.Name = "TXITEM_GotoNext";
			this.button_1.TabIndex = 5;
			this.button_1.Text = "Next";
			this.button_1.UseVisualStyleBackColor = true;
			this.button_1.Click += button_1_Click;
			this.button_2.AutoSize = true;
			this.button_2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.button_2.DialogResult = DialogResult.Cancel;
			this.button_2.Dock = DockStyle.Top;
			this.button_2.Name = "TXITEM_Close";
			this.button_2.TabIndex = 7;
			this.button_2.Text = "Close";
			this.button_2.UseVisualStyleBackColor = true;
			this.button_2.Click += button_2_Click;
			base.m_dicItems.Add(this.label_0.Name, this.label_0);
			base.m_dicItems.Add(this.TXITEM_GotoList.Name, this.TXITEM_GotoList);
			base.m_dicItems.Add(this.label_1.Name, this.label_1);
			base.m_dicItems.Add(this.comboBox_0.Name, this.comboBox_0);
			base.m_dicItems.Add(this.button_0.Name, this.button_0);
			base.m_dicItems.Add(this.button_1.Name, this.button_1);
			base.m_dicItems.Add(this.button_2.Name, this.button_2);
		}

		internal override void AwareOfDPI_Intialize()
		{
			if (!base.m_pntDpi.IsEmpty)
			{
				base.Margin = Class517.smethod_51(Class519.Class542.Class544.Padding_1, base.m_pntDpi);
				Size size3 = (this.comboBox_0.MinimumSize = (this.comboBox_0.Size = Class517.smethod_48(Class519.Class542.Class544.Size_0, base.m_pntDpi)));
				this.label_0.MinimumSize = Class517.smethod_48(Class519.Class542.Class544.Size_1, base.m_pntDpi);
				Size size6 = (this.button_0.MinimumSize = (this.button_0.Size = Class517.smethod_48(Class519.Class542.Class544.Size_3, base.m_pntDpi)));
				Size size9 = (this.button_1.MinimumSize = (this.button_1.Size = Class517.smethod_48(Class519.Class542.Class544.Size_4, base.m_pntDpi)));
				Size size12 = (this.button_2.MinimumSize = (this.button_2.Size = Class517.smethod_48(Class519.Class542.Class544.Size_5, base.m_pntDpi)));
				this.tableLayoutPanel_0.Margin = Class517.smethod_51(Class519.Class542.Class544.Padding_1, base.m_pntDpi);
				this.method_3();
			}
		}

		internal override void SetDialogAlignment()
		{
			base.Controls.Clear();
			base.ColumnStyles.Clear();
			base.RowStyles.Clear();
			this.tableLayoutPanel_0.Controls.Clear();
			this.tableLayoutPanel_0.ColumnStyles.Clear();
			this.tableLayoutPanel_0.RowStyles.Clear();
			base.ColumnCount = 2;
			base.ColumnStyles.Add(new ColumnStyle());
			base.ColumnStyles.Add(new ColumnStyle());
			base.Controls.Add(this.comboBox_0, 1, 1);
			base.Controls.Add(this.label_0, 0, 0);
			base.Controls.Add(this.label_1, 1, 0);
			if (this.TXITEM_GotoList is ComboBox)
			{
				this.int_1 = this.TXITEM_GotoList.SelectedIndex;
				this.TXITEM_GotoList.Parent?.Controls.Remove(this.TXITEM_GotoList);
				this.TXITEM_GotoList = new ListBox();
				(this.TXITEM_GotoList as ListBox).IntegralHeight = false;
				this.method_5();
			}
			base.Controls.Add(this.TXITEM_GotoList, 0, 1);
			base.Controls.Add(this.tableLayoutPanel_0, 0, 3);
			base.RowCount = 4;
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			base.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel_0.AutoSize = true;
			this.tableLayoutPanel_0.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel_0.ColumnCount = 4;
			base.SetColumnSpan(this.tableLayoutPanel_0, 2);
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_0.Controls.Add(this.button_0, 1, 0);
			this.tableLayoutPanel_0.Controls.Add(this.button_1, 2, 0);
			this.tableLayoutPanel_0.Controls.Add(this.button_2, 3, 0);
			this.tableLayoutPanel_0.Dock = DockStyle.Fill;
			this.tableLayoutPanel_0.Name = "TXITEM_BottomPanel";
			this.tableLayoutPanel_0.RowCount = 1;
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_0.TabIndex = 99999;
			this.label_1.TextAlign = ContentAlignment.TopLeft;
			base.SetDialogAlignment();
		}

		internal override void AwareOfDPI_Dialog()
		{
			base.Margin = new Padding(0);
			base.Padding = Class517.smethod_51(Class519.Class542.Class544.Padding_2, base.m_pntDpi);
			this.button_0.Margin = Class517.smethod_51(Class519.Class542.Class544.Padding_18, base.m_pntDpi);
			this.button_1.Margin = Class517.smethod_51(Class519.Class542.Class544.Padding_19, base.m_pntDpi);
			this.button_2.Margin = Class517.smethod_51(Class519.Class542.Class544.Padding_20, base.m_pntDpi);
			this.label_0.Margin = Class517.smethod_51(Class519.Class542.Class544.Padding_14, base.m_pntDpi);
			this.TXITEM_GotoList.Margin = Class517.smethod_51(Class519.Class542.Class544.Padding_15, base.m_pntDpi);
			this.label_1.Margin = Class517.smethod_51(Class519.Class542.Class544.Padding_16, base.m_pntDpi);
			this.comboBox_0.Margin = Class517.smethod_51(Class519.Class542.Class544.Padding_17, base.m_pntDpi);
			this.comboBox_0.Height = this.comboBox_0.PreferredHeight;
			if (this.TXITEM_GotoList is ListBox)
			{
				ListControl tXITEM_GotoList = this.TXITEM_GotoList;
				ListControl tXITEM_GotoList2 = this.TXITEM_GotoList;
				Size size2 = (this.TXITEM_GotoList.MaximumSize = Class517.smethod_48(Class519.Class542.Class544.Size_6, base.m_pntDpi));
				Size size5 = (tXITEM_GotoList.Size = (tXITEM_GotoList2.MinimumSize = size2));
			}
		}

		internal override void SetHorizontalAlignment()
		{
			base.Controls.Clear();
			base.ColumnStyles.Clear();
			base.RowStyles.Clear();
			this.tableLayoutPanel_0.Controls.Clear();
			this.tableLayoutPanel_0.ColumnStyles.Clear();
			this.tableLayoutPanel_0.RowStyles.Clear();
			base.ColumnCount = 8;
			base.ColumnStyles.Add(new ColumnStyle());
			base.ColumnStyles.Add(new ColumnStyle());
			base.ColumnStyles.Add(new ColumnStyle());
			base.ColumnStyles.Add(new ColumnStyle());
			base.ColumnStyles.Add(new ColumnStyle());
			base.ColumnStyles.Add(new ColumnStyle());
			base.ColumnStyles.Add(new ColumnStyle());
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			base.Controls.Add(this.label_0, 0, 0);
			if (this.TXITEM_GotoList is ListBox)
			{
				this.int_1 = this.TXITEM_GotoList.SelectedIndex;
				this.TXITEM_GotoList.Parent?.Controls.Remove(this.TXITEM_GotoList);
				this.TXITEM_GotoList = new ComboBox();
				this.method_5();
			}
			base.Controls.Add(this.TXITEM_GotoList, 1, 0);
			base.Controls.Add(this.label_1, 2, 0);
			base.Controls.Add(this.comboBox_0, 3, 0);
			base.Controls.Add(this.button_0, 4, 0);
			base.Controls.Add(this.button_1, 5, 0);
			base.Controls.Add(this.button_2, 6, 0);
			base.RowCount = 1;
			base.RowStyles.Add(new RowStyle());
			this.label_1.TextAlign = ContentAlignment.TopRight;
			base.SetHorizontalAlignment();
		}

		internal override void AwareOfDPI_Horizontal()
		{
			base.Margin = Class517.smethod_51(Class519.Class542.Class544.Padding_0, base.m_pntDpi);
			this.label_0.Margin = Class517.smethod_51(Class519.Class542.Class544.Padding_3, base.m_pntDpi);
			this.TXITEM_GotoList.Margin = Class517.smethod_51(Class519.Class542.Class544.Padding_4, base.m_pntDpi);
			this.label_1.Margin = Class517.smethod_51(Class519.Class542.Class544.Padding_5, base.m_pntDpi);
			this.comboBox_0.Margin = Class517.smethod_51(Class519.Class542.Class544.Padding_6, base.m_pntDpi);
			this.button_0.Margin = Class517.smethod_51(Class519.Class542.Class544.Padding_7, base.m_pntDpi);
			this.button_1.Margin = Class517.smethod_51(Class519.Class542.Class544.Padding_8, base.m_pntDpi);
			this.button_2.Margin = Class517.smethod_51(Class519.Class542.Class544.Padding_9, base.m_pntDpi);
			this.comboBox_0.Height = this.comboBox_0.PreferredHeight;
			if (this.TXITEM_GotoList is ComboBox)
			{
				Size size3 = (this.TXITEM_GotoList.Size = (this.TXITEM_GotoList.MinimumSize = new Size(Class517.smethod_48(Class519.Class542.Class544.Size_6, base.m_pntDpi).Width, 0)));
			}
		}

		internal override void SetVerticalAlignment()
		{
			base.Controls.Clear();
			base.ColumnStyles.Clear();
			base.RowStyles.Clear();
			this.tableLayoutPanel_0.Controls.Clear();
			this.tableLayoutPanel_0.ColumnStyles.Clear();
			this.tableLayoutPanel_0.RowStyles.Clear();
			base.ColumnCount = 1;
			base.ColumnStyles.Add(new ColumnStyle());
			base.RowCount = 5;
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle());
			base.Controls.Add(this.label_0, 0, 0);
			if (this.TXITEM_GotoList is ComboBox)
			{
				this.int_1 = this.TXITEM_GotoList.SelectedIndex;
				this.TXITEM_GotoList.Parent?.Controls.Remove(this.TXITEM_GotoList);
				this.TXITEM_GotoList = new ListBox();
				(this.TXITEM_GotoList as ListBox).IntegralHeight = false;
				this.method_5();
			}
			base.Controls.Add(this.TXITEM_GotoList, 0, 1);
			base.Controls.Add(this.label_1, 0, 2);
			base.Controls.Add(this.comboBox_0, 0, 3);
			base.Controls.Add(this.tableLayoutPanel_0, 0, 4);
			this.tableLayoutPanel_0.AutoSize = true;
			this.tableLayoutPanel_0.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel_0.ColumnCount = 4;
			base.SetColumnSpan(this.tableLayoutPanel_0, 2);
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_0.Controls.Add(this.button_0, 1, 0);
			this.tableLayoutPanel_0.Controls.Add(this.button_1, 2, 0);
			this.tableLayoutPanel_0.Controls.Add(this.button_2, 3, 0);
			this.tableLayoutPanel_0.Dock = DockStyle.Fill;
			this.tableLayoutPanel_0.Name = "TXITEM_BottomPanel";
			this.tableLayoutPanel_0.RowCount = 1;
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_0.TabIndex = 99999;
			this.label_1.TextAlign = ContentAlignment.TopLeft;
			base.SetVerticalAlignment();
		}

		internal override void AwareOfDPI_Vertical()
		{
			base.Margin = Class517.smethod_51(Class519.Class542.Class544.Padding_1, base.m_pntDpi);
			this.button_0.Margin = Class517.smethod_51(Class519.Class542.Class544.Padding_18, base.m_pntDpi);
			this.button_1.Margin = Class517.smethod_51(Class519.Class542.Class544.Padding_19, base.m_pntDpi);
			this.button_2.Margin = Class517.smethod_51(Class519.Class542.Class544.Padding_20, base.m_pntDpi);
			this.label_0.Margin = Class517.smethod_51(Class519.Class542.Class544.Padding_10, base.m_pntDpi);
			this.TXITEM_GotoList.Margin = Class517.smethod_51(Class519.Class542.Class544.Padding_11, base.m_pntDpi);
			this.label_1.Margin = Class517.smethod_51(Class519.Class542.Class544.Padding_12, base.m_pntDpi);
			this.comboBox_0.Margin = Class517.smethod_51(Class519.Class542.Class544.Padding_13, base.m_pntDpi);
			this.comboBox_0.Height = this.comboBox_0.PreferredHeight;
			if (this.TXITEM_GotoList is ListBox)
			{
				ListControl tXITEM_GotoList = this.TXITEM_GotoList;
				ListControl tXITEM_GotoList2 = this.TXITEM_GotoList;
				Size size2 = (this.TXITEM_GotoList.MaximumSize = Class517.smethod_48(Class519.Class542.Class544.Size_6, base.m_pntDpi));
				Size size5 = (tXITEM_GotoList.Size = (tXITEM_GotoList2.MinimumSize = size2));
			}
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			base.OnHandleCreated(eventArgs_0);
			this.comboBox_0.Height = this.comboBox_0.PreferredHeight;
		}

		protected override void OnFontChanged(EventArgs eventArgs_0)
		{
			if (!base.m_pntDpi.IsEmpty)
			{
				this.method_3();
				this.comboBox_0.Height = this.comboBox_0.PreferredHeight;
			}
			base.OnFontChanged(eventArgs_0);
		}

		protected override void OnContentPanelGotFocus()
		{
			if (base.TextControl != null)
			{
				base.TextControl.InputPosition.InactiveMarker = true;
			}
			base.OnContentPanelGotFocus();
		}

		protected override void OnContentPanelLostFocus()
		{
			if (base.TextControl != null)
			{
				base.TextControl.InputPosition.InactiveMarker = false;
			}
			base.OnContentPanelLostFocus();
		}

		private void comboBox_0_GotFocus(object sender, EventArgs e)
		{
			this.comboBox_0.Select();
		}

		private void comboBox_0_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData == Keys.Return)
			{
				this.button_1_Click(sender, EventArgs.Empty);
			}
		}

		private void button_2_Click(object sender, EventArgs e)
		{
			if (base.Parent is Sidebar)
			{
				Sidebar sidebar = base.Parent as Sidebar;
				if (sidebar.Boolean_0 && sidebar.Parent is Form)
				{
					(sidebar.Parent as Form).Close();
				}
			}
		}

		private void method_0(object sender, EventArgs e)
		{
			Class583 @class = ((this.TXITEM_GotoList is ListBox) ? ((Class583)(this.TXITEM_GotoList as ListBox).SelectedItem) : ((Class583)(this.TXITEM_GotoList as ComboBox).SelectedItem));
			if (@class == null)
			{
				return;
			}
			int num = @class.int_0;
			switch (num)
			{
			case 0:
			case 1:
			case 2:
			case 3:
				if (this.comboBox_0.DropDownStyle == ComboBoxStyle.DropDown)
				{
					this.comboBox_0.Text = "";
					this.comboBox_0.Items.Clear();
					this.comboBox_0.DropDownStyle = ComboBoxStyle.Simple;
				}
				switch (num)
				{
				case 0:
					this.label_1.Text = base.m_rm.GetString("ID_GOTO_PAGENUMBER");
					break;
				case 1:
					this.label_1.Text = base.m_rm.GetString("ID_GOTO_SECTIONNUMBER");
					break;
				case 2:
					this.label_1.Text = base.m_rm.GetString("ID_GOTO_LINENUMBER");
					break;
				case 3:
					this.label_1.Text = base.m_rm.GetString("ID_GOTO_TABLENUMBER");
					break;
				}
				this.method_4(this.int_0);
				this.comboBox_0.DroppedDown = false;
				break;
			case 4:
				if (this.comboBox_0.DropDownStyle == ComboBoxStyle.Simple)
				{
					this.comboBox_0.Text = "";
					this.comboBox_0.DropDownStyle = ComboBoxStyle.DropDown;
				}
				this.label_1.Text = base.m_rm.GetString("ID_GOTO_BOOKMARK");
				this.method_4(1);
				break;
			}
		}

		private void comboBox_0_TextChanged(object sender, EventArgs e)
		{
			ComboBox comboBox = sender as ComboBox;
			if (comboBox.DropDownStyle != 0)
			{
				return;
			}
			this.int_0 = 0;
			if (comboBox != null && comboBox.Text != string.Empty)
			{
				try
				{
					this.int_0 = Convert.ToInt32(comboBox.Text);
				}
				catch
				{
					this.int_0 = -1;
				}
				if (this.int_0 == 0)
				{
					this.int_0 = -1;
				}
			}
			this.method_4(this.int_0);
		}

		private void comboBox_0_DropDown(object sender, EventArgs e)
		{
			this.method_1(base.TextControl);
		}

		private void button_1_Click(object sender, EventArgs e)
		{
			if (base.TextControl == null)
			{
				return;
			}
			Class583 @class = ((this.TXITEM_GotoList is ListBox) ? ((Class583)(this.TXITEM_GotoList as ListBox).SelectedItem) : ((Class583)(this.TXITEM_GotoList as ComboBox).SelectedItem));
			if (@class == null)
			{
				return;
			}
			switch (@class.int_0)
			{
			case 0:
			{
				int page = base.TextControl.InputPosition.Page;
				int val = ((this.int_0 == 0) ? (page + 1) : this.int_0);
				int count = base.TextControl.GetPages().Count;
				val = Math.Min(val, count);
				if (val != page)
				{
					base.TextControl.InputPosition = new InputPosition(val, 1, 0);
					base.TextControl.InputPosition.ScrollTo();
				}
				break;
			}
			case 1:
			{
				int section = base.TextControl.InputPosition.Section;
				int val3 = ((this.int_0 == 0) ? (section + 1) : this.int_0);
				int count4 = base.TextControl.Sections.Count;
				val3 = Math.Min(val3, count4);
				if (val3 != section)
				{
					base.TextControl.InputPosition = new InputPosition(base.TextControl.Sections[val3].Start - 1);
					base.TextControl.InputPosition.ScrollTo();
				}
				break;
			}
			case 2:
			{
				int textPosition2 = base.TextControl.InputPosition.TextPosition;
				int number2 = base.TextControl.Lines.GetItem(textPosition2).Number;
				int val2 = ((this.int_0 == 0) ? (number2 + 1) : this.int_0);
				int count3 = base.TextControl.Lines.Count;
				val2 = Math.Min(val2, count3);
				if (val2 != number2)
				{
					base.TextControl.InputPosition = new InputPosition(base.TextControl.Lines[val2].Start - 1);
					base.TextControl.InputPosition.ScrollTo();
				}
				break;
			}
			case 3:
			{
				if (this.int_0 > 0)
				{
					int count2 = base.TextControl.Tables.Count;
					int number = Math.Min(this.int_0, count2);
					Table table = base.TextControl.Tables[number];
					if (table != null)
					{
						base.TextControl.InputPosition = new InputPosition(table.Cells.GetItem(1, 1).Start - 1);
						base.TextControl.InputPosition.ScrollTo();
					}
					break;
				}
				int textPosition = base.TextControl.InputPosition.TextPosition;
				foreach (Table table2 in base.TextControl.Tables)
				{
					int num = table2.Cells.GetItem(1, 1).Start - 1;
					if (num > textPosition)
					{
						base.TextControl.InputPosition = new InputPosition(num);
						base.TextControl.InputPosition.ScrollTo();
						break;
					}
				}
				break;
			}
			case 4:
			{
				Class582 class2 = this.comboBox_0.SelectedItem as Class582;
				if (class2 != null)
				{
					base.TextControl.InputPosition = new InputPosition(class2.documentTarget_0.Start - 1);
					base.TextControl.InputPosition.ScrollTo();
				}
				break;
			}
			}
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			if (base.TextControl == null)
			{
				return;
			}
			Class583 @class = ((this.TXITEM_GotoList is ListBox) ? ((Class583)(this.TXITEM_GotoList as ListBox).SelectedItem) : ((Class583)(this.TXITEM_GotoList as ComboBox).SelectedItem));
			if (@class == null)
			{
				return;
			}
			switch (@class.int_0)
			{
			case 0:
			{
				int page = base.TextControl.InputPosition.Page;
				if (page > 1)
				{
					base.TextControl.InputPosition = new InputPosition(page - 1, 1, 0);
					base.TextControl.InputPosition.ScrollTo();
				}
				break;
			}
			case 1:
			{
				int section = base.TextControl.InputPosition.Section;
				if (section > 1)
				{
					base.TextControl.InputPosition = new InputPosition(base.TextControl.Sections[section - 1].Start - 1);
					base.TextControl.InputPosition.ScrollTo();
				}
				break;
			}
			case 2:
			{
				int textPosition2 = base.TextControl.InputPosition.TextPosition;
				int number = base.TextControl.Lines.GetItem(textPosition2).Number;
				if (number > 1)
				{
					base.TextControl.InputPosition = new InputPosition(base.TextControl.Lines[number - 1].Start - 1);
					base.TextControl.InputPosition.ScrollTo();
				}
				break;
			}
			case 3:
			{
				int textPosition = base.TextControl.InputPosition.TextPosition;
				int num = -1;
				foreach (Table table in base.TextControl.Tables)
				{
					int num2 = table.Cells.GetItem(1, 1).Start - 1;
					if (num2 < textPosition)
					{
						num = num2;
					}
				}
				if (num >= 0)
				{
					base.TextControl.InputPosition = new InputPosition(num);
					base.TextControl.InputPosition.ScrollTo();
				}
				break;
			}
			}
		}

		private void method_1(TextControl textControl_0)
		{
			if (textControl_0 == null)
			{
				return;
			}
			this.comboBox_0.Items.Clear();
			List<DocumentTarget> list = this.method_2(textControl_0);
			foreach (DocumentTarget item in list)
			{
				this.comboBox_0.Items.Add(new Class582(item));
			}
		}

		private List<DocumentTarget> method_2(TextControl textControl_0)
		{
			try
			{
				List<DocumentTarget> list = new List<DocumentTarget>();
				foreach (DocumentTarget documentTarget in textControl_0.DocumentTargets)
				{
					list.Add(documentTarget);
				}
				return list;
			}
			catch
			{
			}
			return null;
		}

		private void method_3()
		{
			int val = TextRenderer.MeasureText(base.m_rm.GetString("ID_GOTO_PAGENUMBER"), this.label_1.Font).Width;
			int val2 = TextRenderer.MeasureText(base.m_rm.GetString("ID_GOTO_BOOKMARK"), this.label_1.Font).Width;
			this.label_1.MinimumSize = new Size(Math.Max(val, val2) + this.label_1.Padding.Horizontal, 0);
		}

		private void method_4(int int_2)
		{
			switch (int_2)
			{
			default:
				this.button_0.Enabled = false;
				this.button_1.Enabled = true;
				this.button_1.Text = base.m_rm.GetString("ID_GOTO_GOTO");
				break;
			case -1:
				this.button_0.Enabled = false;
				this.button_1.Enabled = false;
				break;
			case 0:
				this.button_0.Enabled = true;
				this.button_1.Enabled = true;
				this.button_1.Text = base.m_rm.GetString("ID_GOTO_NEXT");
				break;
			}
		}

		private void method_5()
		{
			this.TXITEM_GotoList.Dock = DockStyle.Fill;
			this.TXITEM_GotoList.FormattingEnabled = true;
			this.TXITEM_GotoList.ImeMode = ImeMode.Disable;
			this.TXITEM_GotoList.Name = "TXITEM_GotoList";
			this.button_0.TabIndex = 5;
			this.TXITEM_GotoList.TabIndex = 1;
			if (this.TXITEM_GotoList is ListBox)
			{
				ListBox listBox = this.TXITEM_GotoList as ListBox;
				for (int i = 0; i <= 4; i++)
				{
					listBox.Items.Add(new Class583(i, base.m_rm.GetString("ID_GOTO_" + i)));
				}
				listBox.SelectedIndex = this.int_1;
				listBox.SelectedIndexChanged += method_0;
				return;
			}
			ComboBox comboBox = this.TXITEM_GotoList as ComboBox;
			comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
			for (int j = 0; j <= 4; j++)
			{
				comboBox.Items.Add(new Class583(j, base.m_rm.GetString("ID_GOTO_" + j)));
			}
			comboBox.SelectedIndex = this.int_1;
			comboBox.SelectedIndexChanged += method_0;
		}
	}
}
