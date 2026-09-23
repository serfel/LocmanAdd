using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ns21;
using ns23;
using ns27;
using TXTextControl.Windows.Forms.Ribbon;
using ns29;

namespace TXTextControl.Proofing
{
	[Obfuscation(Exclude = true)]
	internal class SpellCheckDialogForm : Form
	{
		private Class591 class591_0;

		internal Class415 class415_0;

		private ResourceManager resourceManager_0;

		internal bool bool_0;

		private List<object> list_0 = new List<object>();

		private bool bool_1;

		private PointF pointF_0 = PointF.Empty;

		private uint uint_0;

		private IContainer icontainer_0;

		private TableLayoutPanel PanelMain;

		private TableLayoutPanel PanelPreview;

		private TableLayoutPanel PanelSuggestions;

		private TableLayoutPanel PanelButtonsPreview;

		private TableLayoutPanel PanelButtonsSuggestions;

		internal ListBox m_lbxSuggestions;

		internal TableLayoutPanel PanelComboBox;

		internal Label m_lblDictionary;

		internal ComboBox m_cbxSuggestionDictionaries;

		private FlowLayoutPanel PanelButtonsOptions;

		internal RichTextBox m_rtbPreview;

		internal System.Windows.Forms.Button m_btnClose;

		private Panel panel1;

		private Panel panel2;

		internal Label m_lblSuggestions;

		private TableLayoutPanel tableLayoutPanel1;

		internal Label m_lblMissoelledWord;

		internal Label m_lblLanguge;

		internal SpellCheckDialogForm(Class591 dialog, Class415 spellChecker)
		{
			this.class415_0 = spellChecker;
			this.class591_0 = dialog;
			if (this.class591_0.class595_0 != null)
			{
				base.AcceptButton = this.class591_0.class595_0.button_0;
			}
			this.InitializeComponent();
		}

		protected override bool ProcessDialogChar(char charCode)
		{
			if ((Control.ModifierKeys & Keys.Alt) == 0)
			{
				return false;
			}
			return base.ProcessDialogChar(charCode);
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			Graphics graphics = base.CreateGraphics();
			this.uint_0 = Class468.smethod_0(graphics, this);
			this.pointF_0 = ((this.uint_0 != 0) ? new PointF(this.uint_0, this.uint_0) : new PointF(graphics.DpiX, graphics.DpiY));
			graphics.Dispose();
			this.m_btnClose.MinimumSize = Class517.smethod_48(new Size(75, 23), this.pointF_0);
			this.method_0(this.class591_0.class596_0, this.PanelButtonsPreview);
			this.method_0(this.class591_0.class596_1, this.PanelButtonsSuggestions);
			this.method_1();
			this.class591_0.list_0 = this.method_2();
			this.class591_0.list_1 = this.method_3();
			this.class591_0.class594_0 = new Class594(this.m_rtbPreview, this.class591_0, this);
			this.method_6();
			this.resourceManager_0 = new ResourceManager(typeof(TextControlCore));
			this.Text = this.resourceManager_0.GetString("ID_SPELL_CHECK_DIALOG");
			this.m_btnClose.Text = this.resourceManager_0.GetString("ID_SPELL_BTN_CANCEL");
			this.m_lblMissoelledWord.Text = this.resourceManager_0.GetString("ID_SPELL_LBL_NOT_IN_DICTIONARIES");
			this.m_lblSuggestions.Text = this.resourceManager_0.GetString("ID_SPELL_LBL_SUGGESTIONS");
			this.m_lblDictionary.Text = this.resourceManager_0.GetString("ID_SPELL_LBL_SUGGESTIONS_DICTIONARY");
			Class429.Struct83 struct83_ = default(Class429.Struct83);
			Class429.GetWindowRect(base.Handle, ref struct83_);
			this.m_rtbPreview.Font = new Font(this.m_rtbPreview.Font.FontFamily, (float)(10 * this.uint_0) / 72f, this.m_rtbPreview.Font.Style, GraphicsUnit.Pixel);
			this.class591_0.method_34();
			Class468.smethod_1(this.uint_0, struct83_, this);
			base.OnHandleCreated(eventArgs_0);
		}

		private void method_0(Class596 class596_0, TableLayoutPanel tableLayoutPanel_0)
		{
			tableLayoutPanel_0.RowStyles.Clear();
			tableLayoutPanel_0.RowCount = class596_0.Count;
			for (int i = 0; i < class596_0.Count; i++)
			{
				tableLayoutPanel_0.RowStyles.Add(new RowStyle());
			}
			for (int j = 0; j < class596_0.Count; j++)
			{
				Class595 @class = class596_0[j];
				@class.button_0.MinimumSize = Class517.smethod_48(new Size(75, 23), this.pointF_0);
				if (j == 0)
				{
					@class.button_0.Margin = Class517.smethod_51(new Padding(3, 0, 3, 3), this.pointF_0);
				}
				else
				{
					@class.button_0.Margin = Class517.smethod_51(new Padding(3, 3, 3, 3), this.pointF_0);
				}
				@class.button_0.AutoSize = true;
				@class.button_0.AutoSizeMode = AutoSizeMode.GrowAndShrink;
				tableLayoutPanel_0.Controls.Add(@class.button_0, 0, j);
				@class.button_0.Dock = DockStyle.Top;
				this.method_7(@class);
				@class.class591_0 = this.class591_0;
				@class.spellCheckDialogForm_0 = this;
			}
		}

		private void method_1()
		{
			for (int i = 0; i < this.class591_0.class596_2.Count; i++)
			{
				Class595 @class = this.class591_0.class596_2[i];
				this.PanelButtonsOptions.Controls.Add(@class.button_0);
				@class.button_0.Margin = Class517.smethod_51(new Padding(3, 0, 0, 3), this.pointF_0);
				@class.button_0.MinimumSize = Class517.smethod_48(new Size(75, 23), this.pointF_0);
				@class.button_0.Dock = DockStyle.Left;
				@class.button_0.AutoSize = true;
				this.method_7(@class);
				@class.class591_0 = this.class591_0;
				@class.spellCheckDialogForm_0 = this;
			}
		}

		private List<Class595> method_2()
		{
			List<Class595> list = new List<Class595>();
			foreach (Class595 item in this.class591_0.class596_0)
			{
				if (item.Boolean_0 || item.enum143_0 == Enum143.const_3)
				{
					list.Add(item);
				}
			}
			foreach (Class595 item2 in this.class591_0.class596_1)
			{
				if (item2.Boolean_0 || item2.enum143_0 == Enum143.const_3)
				{
					list.Add(item2);
				}
			}
			foreach (Class595 item3 in this.class591_0.class596_2)
			{
				if (item3.Boolean_0 || item3.enum143_0 == Enum143.const_3)
				{
					list.Add(item3);
				}
			}
			return list;
		}

		private List<Class595> method_3()
		{
			List<Class595> list = new List<Class595>();
			foreach (Class595 item in this.class591_0.class596_0)
			{
				if (item.Boolean_1 || item.enum143_0 == Enum143.const_7)
				{
					list.Add(item);
				}
			}
			foreach (Class595 item2 in this.class591_0.class596_1)
			{
				if (item2.Boolean_1 || item2.enum143_0 == Enum143.const_7)
				{
					list.Add(item2);
				}
			}
			foreach (Class595 item3 in this.class591_0.class596_2)
			{
				if (item3.Boolean_1 || item3.enum143_0 == Enum143.const_7)
				{
					list.Add(item3);
				}
			}
			return list;
		}

		internal void method_4(Class596 class596_0)
		{
			for (int i = 0; i < class596_0.Count; i++)
			{
				Class595 @class = class596_0[i];
				switch (@class.enum143_0)
				{
				case Enum143.const_0:
					@class.button_0.Click -= @class.method_2;
					break;
				case Enum143.const_1:
					@class.button_0.Click -= @class.method_3;
					break;
				case Enum143.const_2:
					@class.button_0.Click -= @class.method_4;
					break;
				case Enum143.const_4:
					@class.button_0.Click -= @class.method_0;
					break;
				case Enum143.const_5:
					@class.button_0.Click -= @class.method_1;
					break;
				case Enum143.const_6:
					@class.button_0.Click -= @class.method_5;
					break;
				}
				@class.button_0.Click -= @class.method_6;
			}
		}

		internal void method_5()
		{
			this.class591_0.method_33();
			this.class591_0.method_39();
		}

		private void method_6()
		{
			this.m_lblMissoelledWord.TabIndex = 0;
			this.m_rtbPreview.TabIndex = 1;
			this.m_lblSuggestions.TabIndex = 2;
			this.m_lbxSuggestions.TabIndex = 3;
			this.m_lblDictionary.TabIndex = 4;
			this.m_cbxSuggestionDictionaries.TabIndex = 5;
			int num = 6;
			foreach (Class595 item in this.class591_0.class596_0)
			{
				item.button_0.TabIndex = num;
				num++;
			}
			foreach (Class595 item2 in this.class591_0.class596_1)
			{
				item2.button_0.TabIndex = num;
				num++;
			}
			foreach (Class595 item3 in this.class591_0.class596_2)
			{
				item3.button_0.TabIndex = num;
				num++;
			}
			this.m_btnClose.TabIndex = num;
		}

		private void method_7(Class595 class595_0)
		{
			switch (class595_0.enum143_0)
			{
			case Enum143.const_0:
				class595_0.button_0.Click += class595_0.method_2;
				break;
			case Enum143.const_1:
				class595_0.button_0.Click += class595_0.method_3;
				break;
			case Enum143.const_2:
				class595_0.button_0.Click += class595_0.method_4;
				break;
			case Enum143.const_4:
				class595_0.button_0.Click += class595_0.method_0;
				break;
			case Enum143.const_5:
				class595_0.button_0.Click += class595_0.method_1;
				break;
			case Enum143.const_6:
				class595_0.button_0.Click += class595_0.method_5;
				break;
			}
			class595_0.button_0.Click += class595_0.method_6;
		}

		protected override void WndProc(ref Message message)
		{
			int msg = message.Msg;
			if (msg == 736)
			{
				uint num = Class429.smethod_5(message.WParam.ToInt32());
				if (num != this.uint_0)
				{
					Class429.Struct83 struct83_ = (Class429.Struct83)Marshal.PtrToStructure(message.LParam, typeof(Class429.Struct83));
					this.Font = new Font(this.Font.Name, this.Font.Size * (float)num / (float)this.uint_0, this.Font.Style, this.Font.Unit);
					this.uint_0 = num;
					this.m_rtbPreview.Font = new Font(this.m_rtbPreview.Font.FontFamily, (float)(10 * this.uint_0) / 72f, this.m_rtbPreview.Font.Style, GraphicsUnit.Pixel);
					this.class591_0.method_34();
					Class468.smethod_1(this.uint_0, struct83_, this);
				}
			}
			else
			{
				base.WndProc(ref message);
			}
		}

		private void m_btnClose_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void SpellCheckDialogForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.class591_0.method_38();
			this.bool_0 = true;
			this.class591_0.method_29();
		}

		private void SpellCheckDialogForm_Load(object sender, EventArgs e)
		{
			this.class591_0.method_37();
			this.m_cbxSuggestionDictionaries.Width = this.PanelComboBox.Width - this.m_lblDictionary.Width - this.m_lblDictionary.Margin.Left - this.m_cbxSuggestionDictionaries.Margin.Left - this.m_cbxSuggestionDictionaries.Margin.Right + 3;
			this.m_cbxSuggestionDictionaries.Height = this.PanelComboBox.Height - 8;
			this.m_cbxSuggestionDictionaries.DropDownWidth = this.m_cbxSuggestionDictionaries.Width;
		}

		private void m_cbxSuggestionDictionaries_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.class591_0.method_40();
			if (this.class591_0.class594_0.bool_0)
			{
				this.method_5();
				this.class591_0.method_34();
				this.class591_0.class594_0.bool_0 = false;
			}
			this.class591_0.method_30();
		}

		private void SpellCheckDialogForm_Shown(object sender, EventArgs e)
		{
			if (base.AcceptButton != null)
			{
				((System.Windows.Forms.Button)base.AcceptButton).Focus();
			}
			else
			{
				this.m_lbxSuggestions.Focus();
			}
		}

		private void m_lbxSuggestions_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!this.bool_1)
			{
				return;
			}
			foreach (Class595 item in this.class591_0.class596_1)
			{
				if (item.enum143_0 == Enum143.const_1)
				{
					base.AcceptButton = item.button_0;
					return;
				}
			}
			foreach (Class595 item2 in this.class591_0.class596_0)
			{
				if (item2.enum143_0 == Enum143.const_1)
				{
					base.AcceptButton = item2.button_0;
					return;
				}
			}
			foreach (Class595 item3 in this.class591_0.class596_2)
			{
				if (item3.enum143_0 == Enum143.const_1)
				{
					base.AcceptButton = item3.button_0;
					break;
				}
			}
		}

		private void m_lbxSuggestions_Enter(object sender, EventArgs e)
		{
			this.bool_1 = true;
		}

		private void m_lbxSuggestions_Leave(object sender, EventArgs e)
		{
			this.bool_1 = false;
		}

		private void m_cbxSuggestionDictionaries_KeyDown(object sender, KeyEventArgs e)
		{
			if (!this.m_cbxSuggestionDictionaries.DroppedDown && (e.KeyCode == Keys.Up || e.KeyCode == Keys.Space || e.KeyCode == Keys.Down))
			{
				this.m_cbxSuggestionDictionaries.DroppedDown = true;
				e.Handled = true;
			}
			if (this.m_cbxSuggestionDictionaries.DroppedDown && (e.KeyCode == Keys.Return || e.KeyCode == Keys.Return))
			{
				this.m_cbxSuggestionDictionaries.DroppedDown = false;
				e.Handled = true;
			}
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Proofing.SpellCheckDialogForm));
			this.PanelMain = new System.Windows.Forms.TableLayoutPanel();
			this.PanelPreview = new System.Windows.Forms.TableLayoutPanel();
			this.m_rtbPreview = new System.Windows.Forms.RichTextBox();
			this.PanelSuggestions = new System.Windows.Forms.TableLayoutPanel();
			this.m_lbxSuggestions = new System.Windows.Forms.ListBox();
			this.PanelComboBox = new System.Windows.Forms.TableLayoutPanel();
			this.m_cbxSuggestionDictionaries = new System.Windows.Forms.ComboBox();
			this.m_lblDictionary = new System.Windows.Forms.Label();
			this.PanelButtonsPreview = new System.Windows.Forms.TableLayoutPanel();
			this.PanelButtonsSuggestions = new System.Windows.Forms.TableLayoutPanel();
			this.m_btnClose = new System.Windows.Forms.Button();
			this.PanelButtonsOptions = new System.Windows.Forms.FlowLayoutPanel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.m_lblSuggestions = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.m_lblMissoelledWord = new System.Windows.Forms.Label();
			this.m_lblLanguge = new System.Windows.Forms.Label();
			this.PanelMain.SuspendLayout();
			this.PanelPreview.SuspendLayout();
			this.PanelSuggestions.SuspendLayout();
			this.PanelComboBox.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			base.SuspendLayout();
			resources.ApplyResources(this.PanelMain, "PanelMain");
			this.PanelMain.Controls.Add(this.PanelPreview, 0, 1);
			this.PanelMain.Controls.Add(this.PanelSuggestions, 0, 3);
			this.PanelMain.Controls.Add(this.PanelComboBox, 0, 4);
			this.PanelMain.Controls.Add(this.PanelButtonsPreview, 1, 1);
			this.PanelMain.Controls.Add(this.PanelButtonsSuggestions, 1, 3);
			this.PanelMain.Controls.Add(this.m_btnClose, 1, 5);
			this.PanelMain.Controls.Add(this.PanelButtonsOptions, 0, 5);
			this.PanelMain.Controls.Add(this.panel2, 0, 2);
			this.PanelMain.Controls.Add(this.panel1, 1, 0);
			this.PanelMain.Controls.Add(this.tableLayoutPanel1, 0, 0);
			this.PanelMain.Name = "PanelMain";
			resources.ApplyResources(this.PanelPreview, "PanelPreview");
			this.PanelPreview.Controls.Add(this.m_rtbPreview, 0, 0);
			this.PanelPreview.Name = "PanelPreview";
			resources.ApplyResources(this.m_rtbPreview, "m_rtbPreview");
			this.m_rtbPreview.Name = "m_rtbPreview";
			resources.ApplyResources(this.PanelSuggestions, "PanelSuggestions");
			this.PanelSuggestions.Controls.Add(this.m_lbxSuggestions, 0, 0);
			this.PanelSuggestions.Name = "PanelSuggestions";
			resources.ApplyResources(this.m_lbxSuggestions, "m_lbxSuggestions");
			this.m_lbxSuggestions.FormattingEnabled = true;
			this.m_lbxSuggestions.Name = "m_lbxSuggestions";
			this.m_lbxSuggestions.SelectedIndexChanged += new System.EventHandler(m_lbxSuggestions_SelectedIndexChanged);
			this.m_lbxSuggestions.Enter += new System.EventHandler(m_lbxSuggestions_Enter);
			this.m_lbxSuggestions.Leave += new System.EventHandler(m_lbxSuggestions_Leave);
			resources.ApplyResources(this.PanelComboBox, "PanelComboBox");
			this.PanelComboBox.Controls.Add(this.m_cbxSuggestionDictionaries, 1, 0);
			this.PanelComboBox.Controls.Add(this.m_lblDictionary, 0, 0);
			this.PanelComboBox.Name = "PanelComboBox";
			resources.ApplyResources(this.m_cbxSuggestionDictionaries, "m_cbxSuggestionDictionaries");
			this.m_cbxSuggestionDictionaries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cbxSuggestionDictionaries.DropDownWidth = 356;
			this.m_cbxSuggestionDictionaries.FormattingEnabled = true;
			this.m_cbxSuggestionDictionaries.Items.AddRange(new object[1] { resources.GetString("m_cbxSuggestionDictionaries.Items") });
			this.m_cbxSuggestionDictionaries.Name = "m_cbxSuggestionDictionaries";
			this.m_cbxSuggestionDictionaries.SelectedIndexChanged += new System.EventHandler(m_cbxSuggestionDictionaries_SelectedIndexChanged);
			this.m_cbxSuggestionDictionaries.KeyDown += new System.Windows.Forms.KeyEventHandler(m_cbxSuggestionDictionaries_KeyDown);
			resources.ApplyResources(this.m_lblDictionary, "m_lblDictionary");
			this.m_lblDictionary.Name = "m_lblDictionary";
			resources.ApplyResources(this.PanelButtonsPreview, "PanelButtonsPreview");
			this.PanelButtonsPreview.Name = "PanelButtonsPreview";
			resources.ApplyResources(this.PanelButtonsSuggestions, "PanelButtonsSuggestions");
			this.PanelButtonsSuggestions.Name = "PanelButtonsSuggestions";
			resources.ApplyResources(this.m_btnClose, "m_btnClose");
			this.m_btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnClose.Name = "m_btnClose";
			this.m_btnClose.UseVisualStyleBackColor = true;
			this.m_btnClose.Click += new System.EventHandler(m_btnClose_Click);
			resources.ApplyResources(this.PanelButtonsOptions, "PanelButtonsOptions");
			this.PanelButtonsOptions.Name = "PanelButtonsOptions";
			resources.ApplyResources(this.panel2, "panel2");
			this.panel2.Controls.Add(this.m_lblSuggestions);
			this.panel2.Name = "panel2";
			resources.ApplyResources(this.m_lblSuggestions, "m_lblSuggestions");
			this.m_lblSuggestions.Name = "m_lblSuggestions";
			resources.ApplyResources(this.panel1, "panel1");
			this.panel1.Name = "panel1";
			resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.m_lblMissoelledWord, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.m_lblLanguge, 1, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			resources.ApplyResources(this.m_lblMissoelledWord, "m_lblMissoelledWord");
			this.m_lblMissoelledWord.Name = "m_lblMissoelledWord";
			resources.ApplyResources(this.m_lblLanguge, "m_lblLanguge");
			this.m_lblLanguge.Name = "m_lblLanguge";
			resources.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.m_btnClose;
			base.Controls.Add(this.PanelMain);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "SpellCheckDialogForm";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(SpellCheckDialogForm_FormClosing);
			base.Load += new System.EventHandler(SpellCheckDialogForm_Load);
			base.Shown += new System.EventHandler(SpellCheckDialogForm_Shown);
			this.PanelMain.ResumeLayout(false);
			this.PanelMain.PerformLayout();
			this.PanelPreview.ResumeLayout(false);
			this.PanelSuggestions.ResumeLayout(false);
			this.PanelComboBox.ResumeLayout(false);
			this.PanelComboBox.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
