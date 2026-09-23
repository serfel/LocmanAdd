using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using TXTextControl;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class475 : BindingAdapter
	{
		private Class504 class504_0;

		internal Class487 class487_0;

		private Color color_0 = Color.Empty;

		private RulerBarFormulaMode rulerBarFormulaMode_0;

		private RulerBarFormulaMode rulerBarFormulaMode_1;

		private bool bool_0;

		internal override Class500 RibbonGroupManager
		{
			get
			{
				return this.class504_0;
			}
			set
			{
				this.class504_0 = value as Class504;
			}
		}

		internal override void AwareOfDPI(PointF dpi)
		{
			base.AwareOfDPI(dpi);
			RibbonComboBox ribbonComboBox = this.class504_0.TXITEM_FormulaGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_SupportedFunctions.ToString()] as RibbonComboBox;
			ribbonComboBox.Size = new Size(Class517.smethod_45(Class519.Class535.Int32_1, base.m_pntDPI.X), ribbonComboBox.Height);
			RibbonComboBox ribbonComboBox2 = this.class504_0.TXITEM_NumberFormatGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_TableCellNumberFormatComboBox.ToString()] as RibbonComboBox;
			ribbonComboBox2.Size = new Size(Class517.smethod_45(Class519.Class535.Int32_2, base.m_pntDPI.X), ribbonComboBox2.Height);
		}

		internal override void SetRibbonItemAppearance(Dictionary<string, object> groupItemsDictionary, Control ribbonItem, string eventName, bool hasImage)
		{
			base.SetBasicRibbonItemAppearance(groupItemsDictionary, ribbonItem, hasImage);
			switch (ribbonItem.Name)
			{
			case "TXITEM_FormulaTextBox":
			{
				RibbonTextBox ribbonTextBox = ribbonItem as RibbonTextBox;
				ribbonTextBox.KeyDown += method_29;
				base.SetBasicRibbonTextBoxAppearance(ribbonTextBox, hasImage, showDropDownButtons: false, RibbonTextBox.InputValidationMode.All);
				break;
			}
			case "TXITEM_SupportedFunctions":
			{
				RibbonComboBox ribbonComboBox2 = ribbonItem as RibbonComboBox;
				ribbonComboBox2.DrawMode = DrawMode.OwnerDrawFixed;
				ribbonComboBox2.DrawItem += method_30;
				break;
			}
			case "TXITEM_TableCellNumberFormatComboBox":
			{
				RibbonComboBox ribbonComboBox = ribbonItem as RibbonComboBox;
				ribbonComboBox.KeyDown += method_32;
				ribbonComboBox.Leave += method_33;
				break;
			}
			case "TXITEM_TableCellTextTypeText":
			case "TXITEM_TableCellTextTypeNumber":
				(ribbonItem as RibbonToggleButton).CheckedChanged += method_31;
				break;
			case "TXITEM_Functions":
			case "TXITEM_Formula":
			case "TXITEM_TableCellTextType":
			case "TXITEM_TableCellNumberFormat":
			{
				RibbonLabel ribbonLabel = ribbonItem as RibbonLabel;
				base.SetBasicRibbonLabelAppearance(ribbonLabel, hasImage);
				break;
			}
			}
			if (eventName != null)
			{
				Class517.smethod_23(ribbonItem, eventName, ribbonItem.Name + "_Handler", this);
			}
		}

		internal override void OnDisconnectingTextControl()
		{
			(this.class504_0.Control_0.Parent as Ribbon).SelectedIndexChanged -= method_28;
			base.m_txTextControl.InputPositionChanged -= method_34;
			base.m_txTextControl.InputFormat.NumberFormatChanged -= method_35;
			base.m_txTextControl.InputFormat.StandardTextTypeChanged -= method_36;
			base.m_txTextControl.InputFormat.NumberTextTypeChanged -= method_37;
		}

		internal override void OnTextControlConnected()
		{
			(this.class504_0.Control_0.Parent as Ribbon).SelectedIndexChanged += method_28;
			base.m_txTextControl.InputPositionChanged += method_34;
			base.m_txTextControl.InputFormat.NumberFormatChanged += method_35;
			base.m_txTextControl.InputFormat.StandardTextTypeChanged += method_36;
			base.m_txTextControl.InputFormat.NumberTextTypeChanged += method_37;
			RibbonComboBox ribbonComboBox = this.class504_0.TXITEM_FormulaGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_SupportedFunctions.ToString()] as RibbonComboBox;
			ribbonComboBox.Items.Clear();
			ribbonComboBox.Items.AddRange(base.m_txTextControl.Tables.SupportedFormulaFunctions);
			ribbonComboBox.SelectedItem = "SUM";
			RibbonComboBox ribbonComboBox2 = this.class504_0.TXITEM_NumberFormatGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_TableCellNumberFormatComboBox.ToString()] as RibbonComboBox;
			ribbonComboBox2.Items.Clear();
			ribbonComboBox2.Items.AddRange(base.m_txTextControl.Tables.SupportedNumberFormats);
		}

		private void method_0(TabPage tabPage_0)
		{
			if (!this.bool_0 || this.class504_0.Control_0 == tabPage_0)
			{
				return;
			}
			this.bool_0 = false;
			if (base.m_txTextControl != null)
			{
				if (base.m_txTextControl.RulerBar != null)
				{
					base.m_txTextControl.RulerBar.FormulaMode = this.rulerBarFormulaMode_0;
				}
				if (base.m_txTextControl.VerticalRulerBar != null)
				{
					base.m_txTextControl.VerticalRulerBar.FormulaMode = this.rulerBarFormulaMode_1;
				}
			}
		}

		private void method_1(string string_0)
		{
			RibbonButton ribbonButton = this.class504_0.TXITEM_FormulaGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_AcceptFormula.ToString()] as RibbonButton;
			RibbonButton ribbonButton2 = this.class504_0.TXITEM_FormulaGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_CancelFormulaEditing.ToString()] as RibbonButton;
			Table item;
			TableCell item2;
			if (!this.class487_0.Boolean_0 && base.m_txTextControl != null && (item = base.m_txTextControl.Tables.GetItem()) != null && (item2 = item.Cells.GetItem()) != null)
			{
				bool enabled = (ribbonButton2.Enabled = string_0 != item2.Formula);
				ribbonButton.Enabled = enabled;
			}
			else if (this.class487_0.Boolean_0)
			{
				bool enabled2 = (ribbonButton2.Enabled = string_0 != this.class487_0.String_0);
				ribbonButton.Enabled = enabled2;
			}
		}

		private void method_2(Keys keys_0)
		{
			switch (keys_0)
			{
			case Keys.Return:
				this.method_3();
				break;
			case Keys.Escape:
				this.method_4();
				break;
			}
		}

		private void method_3()
		{
			RibbonToggleButton ribbonToggleButton = this.class504_0.TXITEM_FormulaGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_SelectCellReferences.ToString()] as RibbonToggleButton;
			if (ribbonToggleButton.Checked)
			{
				ribbonToggleButton.Checked = false;
				this.class487_0.method_1();
			}
			try
			{
				Table item;
				TableCell item2;
				if (base.m_txTextControl != null && (item = base.m_txTextControl.Tables.GetItem()) != null && (item2 = item.Cells.GetItem()) != null)
				{
					item2.Formula = (this.class504_0.TXITEM_FormulaGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_FormulaTextBox.ToString()] as RibbonTextBox).Text;
					(this.class504_0.TXITEM_FormulaGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_AcceptFormula.ToString()] as RibbonButton).Enabled = false;
					(this.class504_0.TXITEM_FormulaGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_CancelFormulaEditing.ToString()] as RibbonButton).Enabled = false;
					base.m_txTextControl.Focus();
				}
			}
			catch (FormulaException ex)
			{
				MessageBox.Show(ex.Message, this.class504_0.Control_0.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				RibbonTextBox ribbonTextBox = this.class504_0.TXITEM_FormulaGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_FormulaTextBox.ToString()] as RibbonTextBox;
				int num2 = (ribbonTextBox.SelectionStart = Math.Max(ex.CharacterIndex - 1, 0));
				if (num2 < ribbonTextBox.Text.Length)
				{
					ribbonTextBox.SelectionLength = 1;
				}
				else
				{
					ribbonTextBox.SelectionLength = 0;
				}
			}
			catch (Exception ex2)
			{
				throw ex2;
			}
		}

		private void method_4()
		{
			if (this.class487_0.Boolean_0)
			{
				this.class487_0.method_1();
			}
			Table item;
			TableCell item2;
			if (base.m_txTextControl != null && (item = base.m_txTextControl.Tables.GetItem()) != null && (item2 = item.Cells.GetItem()) != null)
			{
				(this.class504_0.TXITEM_FormulaGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_FormulaTextBox.ToString()] as RibbonTextBox).Text = item2.Formula;
				(this.class504_0.TXITEM_FormulaGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_AcceptFormula.ToString()] as RibbonButton).Enabled = false;
				(this.class504_0.TXITEM_FormulaGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_CancelFormulaEditing.ToString()] as RibbonButton).Enabled = false;
			}
		}

		private void method_5(RibbonComboBox ribbonComboBox_0, DrawItemEventArgs drawItemEventArgs_0)
		{
			if (drawItemEventArgs_0.Index != -1)
			{
				drawItemEventArgs_0.DrawBackground();
				TextRenderer.DrawText(drawItemEventArgs_0.Graphics, ribbonComboBox_0.Items[drawItemEventArgs_0.Index].ToString(), drawItemEventArgs_0.Font, drawItemEventArgs_0.Bounds, drawItemEventArgs_0.ForeColor, TextFormatFlags.VerticalCenter);
			}
		}

		private void method_6()
		{
			RibbonComboBox ribbonComboBox = this.class504_0.TXITEM_FormulaGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_SupportedFunctions.ToString()] as RibbonComboBox;
			if (ribbonComboBox.SelectedItem != null)
			{
				RibbonTextBox ribbonTextBox = this.class504_0.TXITEM_FormulaGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_FormulaTextBox.ToString()] as RibbonTextBox;
				string text = ribbonComboBox.SelectedItem.ToString() + "()";
				int selectionStart = ribbonTextBox.SelectionStart;
				ribbonTextBox.SelectedText = text;
				ribbonTextBox.SelectionStart = selectionStart + text.Length - 1;
				ribbonTextBox.method_7();
			}
		}

		private void method_7(RibbonToggleButton ribbonToggleButton_0)
		{
			RibbonTextBox ribbonTextBox = this.class504_0.TXITEM_FormulaGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_FormulaTextBox.ToString()] as RibbonTextBox;
			if (ribbonToggleButton_0.Checked)
			{
				Table item;
				TableCell item2;
				if (base.m_txTextControl != null && (item = base.m_txTextControl.Tables.GetItem()) != null && (item2 = item.Cells.GetItem()) != null)
				{
					ribbonTextBox.method_7();
					this.class487_0.method_0(base.m_txTextControl, item, item2);
				}
				else
				{
					ribbonToggleButton_0.Checked = false;
				}
			}
			else
			{
				this.class487_0.method_1();
			}
		}

		private void method_8()
		{
			if (base.m_txTextControl == null || base.m_txTextControl.TableFormatDialog(2) != DialogResult.OK)
			{
				return;
			}
			Table item = base.m_txTextControl.Tables.GetItem();
			if (item != null)
			{
				TableCell item2 = item.Cells.GetItem();
				if (item2 != null)
				{
					RibbonTextBox ribbonTextBox = this.class504_0.TXITEM_FormulaGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_FormulaTextBox.ToString()] as RibbonTextBox;
					ribbonTextBox.Text = item2.Formula;
				}
			}
		}

		private void method_9(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null && base.m_txTextControl.Tables.GetItem() != null)
			{
				RibbonToggleButton ribbonToggleButton = this.class504_0.TXITEM_NumberFormatGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_TableCellTextTypeText.ToString()] as RibbonToggleButton;
				RibbonToggleButton ribbonToggleButton2 = this.class504_0.TXITEM_NumberFormatGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_TableCellTextTypeNumber.ToString()] as RibbonToggleButton;
				ribbonToggleButton_0.Checked = true;
				if (ribbonToggleButton_0 == ribbonToggleButton)
				{
					ribbonToggleButton2.Checked = false;
					base.m_txTextControl.InputFormat.StandardTextType = true;
				}
				else
				{
					ribbonToggleButton.Checked = false;
					base.m_txTextControl.InputFormat.NumberTextType = true;
				}
			}
		}

		private void method_10(string string_0)
		{
			if (base.m_txTextControl != null && base.m_txTextControl.Tables.GetItem() != null)
			{
				RibbonButton ribbonButton = this.class504_0.TXITEM_NumberFormatGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_TableCellAcceptNumberFormat.ToString()] as RibbonButton;
				ribbonButton.Enabled = string_0 != base.m_txTextControl.InputFormat.NumberFormat;
			}
		}

		private void method_11(Keys keys_0)
		{
			if (keys_0 == Keys.Return)
			{
				this.method_13();
			}
		}

		private void method_12(RibbonComboBox ribbonComboBox_0)
		{
			if (base.m_txTextControl != null)
			{
				string text = ((base.m_txTextControl.InputFormat.NumberFormat != null) ? base.m_txTextControl.InputFormat.NumberFormat : string.Empty);
				if (text != ribbonComboBox_0.Text)
				{
					ribbonComboBox_0.Text = text;
				}
			}
		}

		private void method_13()
		{
			try
			{
				if (base.m_txTextControl != null && base.m_txTextControl.Tables.GetItem() != null)
				{
					base.m_txTextControl.InputFormat.NumberFormat = (this.class504_0.TXITEM_NumberFormatGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_TableCellNumberFormatComboBox.ToString()] as RibbonComboBox).Text;
					RibbonButton ribbonButton = this.class504_0.TXITEM_NumberFormatGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_TableCellAcceptNumberFormat.ToString()] as RibbonButton;
					ribbonButton.Enabled = false;
				}
			}
			catch (NumberFormatException ex)
			{
				MessageBox.Show(ex.Message, this.class504_0.Control_0.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				RibbonComboBox ribbonComboBox = this.class504_0.TXITEM_NumberFormatGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_TableCellNumberFormatComboBox.ToString()] as RibbonComboBox;
				int start;
				ribbonComboBox.Select(length: ((start = Math.Max(ex.CharacterIndex - 1, 0)) < ribbonComboBox.Text.Length) ? 1 : 0, start: start);
			}
			catch (Exception ex2)
			{
				throw ex2;
			}
		}

		private void method_14(bool bool_1)
		{
			if (base.m_txTextControl != null)
			{
				base.m_txTextControl.IsFormulaCalculationEnabled = bool_1;
			}
		}

		private void method_15(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			base.m_txTextControl.FormulaReferenceStyle = FormulaReferenceStyle.R1C1;
			RibbonTextBox ribbonTextBox = this.class504_0.TXITEM_FormulaGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_FormulaTextBox.ToString()] as RibbonTextBox;
			Table item = base.m_txTextControl.Tables.GetItem();
			if (item != null)
			{
				TableCell item2 = item.Cells.GetItem();
				if (item2 != null)
				{
					ribbonTextBox.Text = item2.Formula;
				}
			}
			ribbonToggleButton_0.Checked = true;
			(this.class504_0.TXITEM_FormulaSettingsGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_EnableA1Style.ToString()] as RibbonToggleButton).Checked = false;
		}

		private void method_16(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			base.m_txTextControl.FormulaReferenceStyle = FormulaReferenceStyle.A1;
			RibbonTextBox ribbonTextBox = this.class504_0.TXITEM_FormulaGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_FormulaTextBox.ToString()] as RibbonTextBox;
			Table item = base.m_txTextControl.Tables.GetItem();
			if (item != null)
			{
				TableCell item2 = item.Cells.GetItem();
				if (item2 != null)
				{
					ribbonTextBox.Text = item2.Formula;
				}
			}
			ribbonToggleButton_0.Checked = true;
			(this.class504_0.TXITEM_FormulaSettingsGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_EnableR1C1Style.ToString()] as RibbonToggleButton).Checked = false;
		}

		private void method_17(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				if (base.m_txTextControl.RulerBar != null)
				{
					base.m_txTextControl.RulerBar.FormulaMode = RulerBarFormulaMode.Auto;
				}
				if (base.m_txTextControl.VerticalRulerBar != null)
				{
					base.m_txTextControl.VerticalRulerBar.FormulaMode = RulerBarFormulaMode.Auto;
				}
				ribbonToggleButton_0.Checked = true;
				(this.class504_0.TXITEM_FormulaSettingsGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_ShowAllReferences.ToString()] as RibbonToggleButton).Checked = false;
			}
		}

		private void method_18(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl != null)
			{
				if (base.m_txTextControl.RulerBar != null)
				{
					base.m_txTextControl.RulerBar.FormulaMode = RulerBarFormulaMode.Always;
				}
				if (base.m_txTextControl.VerticalRulerBar != null)
				{
					base.m_txTextControl.VerticalRulerBar.FormulaMode = RulerBarFormulaMode.Always;
				}
				ribbonToggleButton_0.Checked = true;
				(this.class504_0.TXITEM_FormulaSettingsGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_ShowFormulaReferences.ToString()] as RibbonToggleButton).Checked = false;
			}
		}

		private void method_19()
		{
			this.method_24(bool_1: true);
		}

		private void method_20()
		{
			RibbonGroup object_ = this.class504_0.TXITEM_NumberFormatGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_NumberFormatGroup.ToString()] as RibbonGroup;
			RibbonButton ribbonButton = this.class504_0.TXITEM_NumberFormatGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_TableCellAcceptNumberFormat.ToString()] as RibbonButton;
			if (this.class504_0.method_2(object_) || this.class504_0.method_2(ribbonButton))
			{
				RibbonComboBox ribbonComboBox = this.class504_0.TXITEM_NumberFormatGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_TableCellNumberFormatComboBox.ToString()] as RibbonComboBox;
				string numberFormat = base.m_txTextControl.InputFormat.NumberFormat;
				ribbonComboBox.Text = ((numberFormat == null) ? "" : numberFormat);
				ribbonButton.Enabled = ribbonComboBox.Text != numberFormat;
			}
		}

		private void method_21()
		{
			RibbonToggleButton ribbonToggleButton = this.class504_0.TXITEM_NumberFormatGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_TableCellTextTypeText.ToString()] as RibbonToggleButton;
			if (this.class504_0.method_2(ribbonToggleButton))
			{
				bool? standardTextType = base.m_txTextControl.InputFormat.StandardTextType;
				ribbonToggleButton.Checked = standardTextType.HasValue && standardTextType.Value;
			}
		}

		private void method_22()
		{
			RibbonToggleButton ribbonToggleButton = this.class504_0.TXITEM_NumberFormatGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_TableCellTextTypeNumber.ToString()] as RibbonToggleButton;
			if (this.class504_0.method_2(ribbonToggleButton))
			{
				bool? numberTextType = base.m_txTextControl.InputFormat.NumberTextType;
				ribbonToggleButton.Checked = numberTextType.HasValue && numberTextType.Value;
			}
		}

		internal void method_23()
		{
			this.method_24(bool_1: true);
		}

		internal override void UpdateRibbonTab(params object[] args)
		{
			this.bool_0 = true;
			this.method_26();
			this.method_27();
			this.method_24(bool_1: true);
		}

		internal void method_24(bool bool_1)
		{
			RibbonGroup ribbonGroup = this.class504_0.TXITEM_FormulaGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_FormulaGroup.ToString()] as RibbonGroup;
			RibbonGroup ribbonGroup_ = this.class504_0.TXITEM_NumberFormatGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_NumberFormatGroup.ToString()] as RibbonGroup;
			RibbonGroup ribbonGroup_2 = this.class504_0.TXITEM_FormulaSettingsGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_FormulaSettingsGroup.ToString()] as RibbonGroup;
			if (!this.class504_0.method_0(ribbonGroup) && !this.class504_0.method_0(ribbonGroup_) && !this.class504_0.method_0(ribbonGroup_2))
			{
				return;
			}
			Table table = null;
			bool flag = false;
			if (base.m_txTextControl != null)
			{
				flag = base.m_txTextControl.CanEdit;
				table = base.m_txTextControl.Tables.GetItem();
				table = (base.m_txTextControl.CanTableFormat ? table : null);
				flag = flag && table != null;
				if (table == null && this.class487_0.Boolean_0)
				{
					this.class487_0.method_1();
					return;
				}
			}
			if (!this.class487_0.Boolean_0 && flag)
			{
				Control obj = this.class504_0.TXITEM_NumberFormatGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_NumberFormatGroup.ToString()] as Control;
				DialogBoxLauncher dialogBoxLauncher = ribbonGroup.DialogBoxLauncher;
				bool flag3 = ((this.class504_0.TXITEM_FormulaSettingsGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_FormulaSettingsGroup.ToString()] as Control).Enabled = base.m_txTextControl == null || base.m_txTextControl.CanTableFormat);
				bool enabled = (dialogBoxLauncher.Enabled = flag3);
				obj.Enabled = enabled;
				if (bool_1)
				{
					this.method_25(table);
				}
				else
				{
					ribbonGroup.Enabled = base.m_txTextControl == null || base.m_txTextControl.CanTableFormat;
				}
			}
			else
			{
				(this.class504_0.TXITEM_NumberFormatGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_NumberFormatGroup.ToString()] as Control).Enabled = false;
				(this.class504_0.TXITEM_FormulaSettingsGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_FormulaSettingsGroup.ToString()] as IEnabledItem).Enabled = !this.class487_0.Boolean_0 && flag;
				if (!this.class487_0.Boolean_0)
				{
					bool enabled2 = (ribbonGroup.DialogBoxLauncher.Enabled = flag);
					ribbonGroup.Enabled = enabled2;
				}
				else
				{
					ribbonGroup.Enabled = true;
					ribbonGroup.DialogBoxLauncher.Enabled = false;
				}
			}
		}

		private void method_25(Table table_0)
		{
			RibbonGroup ribbonGroup = this.class504_0.TXITEM_FormulaGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_FormulaGroup.ToString()] as RibbonGroup;
			if (table_0 == null && base.m_txTextControl != null)
			{
				return;
			}
			if (table_0 != null)
			{
				RibbonTextBox ribbonTextBox = this.class504_0.TXITEM_FormulaGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_FormulaTextBox.ToString()] as RibbonTextBox;
				TableCell tableCell = null;
				if (ribbonGroup.Enabled = (tableCell = table_0.Cells.GetItem()) != null)
				{
					if (ribbonTextBox.Text != tableCell.Formula)
					{
						ribbonTextBox.Text = tableCell.Formula;
					}
				}
				else
				{
					ribbonTextBox.Text = "";
				}
			}
			else
			{
				ribbonGroup.Enabled = true;
			}
		}

		private void method_26()
		{
			RibbonComboBox ribbonComboBox = this.class504_0.TXITEM_NumberFormatGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_TableCellNumberFormatComboBox.ToString()] as RibbonComboBox;
			string numberFormat = base.m_txTextControl.InputFormat.NumberFormat;
			ribbonComboBox.Text = ((numberFormat != null) ? numberFormat : "");
			RibbonToggleButton ribbonToggleButton = this.class504_0.TXITEM_NumberFormatGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_TableCellTextTypeText.ToString()] as RibbonToggleButton;
			bool? standardTextType = base.m_txTextControl.InputFormat.StandardTextType;
			ribbonToggleButton.Checked = standardTextType.HasValue && standardTextType.Value;
			RibbonToggleButton ribbonToggleButton2 = this.class504_0.TXITEM_NumberFormatGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_TableCellTextTypeNumber.ToString()] as RibbonToggleButton;
			bool? numberTextType = base.m_txTextControl.InputFormat.NumberTextType;
			ribbonToggleButton2.Checked = numberTextType.HasValue && numberTextType.Value;
		}

		private void method_27()
		{
			RibbonGroup ribbonGroup_ = this.class504_0.TXITEM_FormulaSettingsGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_FormulaSettingsGroup.ToString()] as RibbonGroup;
			if (!this.class504_0.method_0(ribbonGroup_))
			{
				return;
			}
			RibbonToggleButton ribbonToggleButton = this.class504_0.TXITEM_FormulaSettingsGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_EnableFormulaCalculation.ToString()] as RibbonToggleButton;
			if (this.class504_0.method_2(ribbonToggleButton))
			{
				ribbonToggleButton.Checked = base.m_txTextControl.IsFormulaCalculationEnabled;
			}
			RibbonToggleButton ribbonToggleButton2 = this.class504_0.TXITEM_FormulaSettingsGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_EnableR1C1Style.ToString()] as RibbonToggleButton;
			if (this.class504_0.method_2(ribbonToggleButton2))
			{
				ribbonToggleButton2.Checked = base.m_txTextControl.FormulaReferenceStyle == FormulaReferenceStyle.R1C1;
			}
			RibbonToggleButton ribbonToggleButton3 = this.class504_0.TXITEM_FormulaSettingsGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_EnableA1Style.ToString()] as RibbonToggleButton;
			if (this.class504_0.method_2(ribbonToggleButton3))
			{
				ribbonToggleButton3.Checked = base.m_txTextControl.FormulaReferenceStyle == FormulaReferenceStyle.A1;
			}
			RibbonToggleButton ribbonToggleButton4 = this.class504_0.TXITEM_FormulaSettingsGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_ShowFormulaReferences.ToString()] as RibbonToggleButton;
			RibbonToggleButton ribbonToggleButton5 = this.class504_0.TXITEM_FormulaSettingsGroup_Items[RibbonFormulaTab.InternalRibbonItem.TXITEM_ShowAllReferences.ToString()] as RibbonToggleButton;
			if (!this.class504_0.method_2(ribbonToggleButton4) && !this.class504_0.method_2(ribbonToggleButton5))
			{
				return;
			}
			bool enabled = (ribbonToggleButton5.Enabled = (base.m_txTextControl.RulerBar != null && base.m_txTextControl.RulerBar.Visible) || (base.m_txTextControl.VerticalRulerBar != null && base.m_txTextControl.VerticalRulerBar.Visible));
			ribbonToggleButton4.Enabled = enabled;
			if (!ribbonToggleButton4.Enabled)
			{
				ribbonToggleButton5.Enabled = false;
				ribbonToggleButton4.Checked = false;
				return;
			}
			RulerBarFormulaMode formulaMode = (ribbonToggleButton4.Checked ? RulerBarFormulaMode.Auto : RulerBarFormulaMode.Always);
			if (base.m_txTextControl.RulerBar != null)
			{
				this.rulerBarFormulaMode_0 = base.m_txTextControl.RulerBar.FormulaMode;
				base.m_txTextControl.RulerBar.FormulaMode = formulaMode;
			}
			if (base.m_txTextControl.VerticalRulerBar != null)
			{
				this.rulerBarFormulaMode_1 = base.m_txTextControl.VerticalRulerBar.FormulaMode;
				base.m_txTextControl.VerticalRulerBar.FormulaMode = formulaMode;
			}
		}

		internal void method_28(object sender, EventArgs e)
		{
			this.method_0((sender as Ribbon).SelectedTab);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_FormulaTextBox_Handler(object sender, EventArgs e)
		{
			this.method_1((sender as RibbonTextBox).Text);
		}

		private void method_29(object sender, KeyEventArgs e)
		{
			this.method_2(e.KeyCode);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_AcceptFormula_Handler(object sender, EventArgs e)
		{
			this.method_3();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_CancelFormulaEditing_Handler(object sender, EventArgs e)
		{
			this.method_4();
		}

		private void method_30(object sender, DrawItemEventArgs e)
		{
			this.method_5(sender as RibbonComboBox, e);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_AddFunction_Handler(object sender, EventArgs e)
		{
			this.method_6();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_SelectCellReferences_Handler(object sender, EventArgs e)
		{
			this.method_7(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_FormulaGroup_Handler(object sender, EventArgs e)
		{
			this.method_8();
		}

		private void method_31(object sender, EventArgs e)
		{
			this.method_9(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_TableCellNumberFormatComboBox_Handler(object sender, EventArgs e)
		{
			this.method_10((sender as RibbonComboBox).Text);
		}

		private void method_32(object sender, KeyEventArgs e)
		{
			this.method_11(e.KeyCode);
		}

		private void method_33(object sender, EventArgs e)
		{
			this.method_12(sender as RibbonComboBox);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_TableCellAcceptNumberFormat_Handler(object sender, EventArgs e)
		{
			this.method_13();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_EnableFormulaCalculation_Handler(object sender, EventArgs e)
		{
			this.method_14((sender as RibbonToggleButton).Checked);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_EnableR1C1Style_Handler(object sender, EventArgs e)
		{
			this.method_15(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_EnableA1Style_Handler(object sender, EventArgs e)
		{
			this.method_16(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_ShowFormulaReferences_Handler(object sender, EventArgs e)
		{
			this.method_17(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_ShowAllReferences_Handler(object sender, EventArgs e)
		{
			this.method_18(sender as RibbonToggleButton);
		}

		internal void method_34(object sender, EventArgs e)
		{
			this.method_19();
		}

		internal void method_35(object sender, EventArgs e)
		{
			this.method_20();
		}

		internal void method_36(object sender, EventArgs e)
		{
			this.method_21();
		}

		internal void method_37(object sender, EventArgs e)
		{
			this.method_22();
		}
	}
}
