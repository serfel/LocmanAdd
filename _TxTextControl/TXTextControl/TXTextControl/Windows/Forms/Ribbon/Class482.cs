using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using TXTextControl;
using TXTextControl.DocumentServer;
using DocumentServer.DataSources;
using DocumentServer.Fields;
using DocumentServer.Windows.Forms;
using TXTextControl.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;
using DialogResult = DocumentServer.Fields.DialogResult;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class Class482 : BindingAdapter
	{
		private Class511 class511_0;

		private DataSourceManager dataSourceManager_0 = new DataSourceManager();

		private OpenFileDialog openFileDialog_0 = new OpenFileDialog
		{
			Multiselect = false,
			Filter = "XML Data Source File (*.xml)|*.xml"
		};

		private OpenFileDialog openFileDialog_1 = new OpenFileDialog
		{
			Multiselect = false,
			Filter = ".NET Assemblies (*.dll;*.exe)|*.dll;*.exe*"
		};

		private OpenFileDialog openFileDialog_2 = new OpenFileDialog
		{
			Multiselect = false,
			Filter = "JSON Files (*.json)|*.json"
		};

		private bool bool_0 = true;

		private HighlightMode highlightMode_0 = HighlightMode.Activated;

		private bool bool_1;

		private bool bool_2;

		private bool bool_3;

		private Point point_0 = Point.Empty;

		private Size size_0 = Size.Empty;

		private bool bool_4;

		internal override Class500 RibbonGroupManager
		{
			get
			{
				return this.class511_0;
			}
			set
			{
				this.class511_0 = value as Class511;
			}
		}

		internal DataSourceManager DataSourceManager_0 => this.dataSourceManager_0;

		private void method_0(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonSplitButton)
			{
				RibbonSplitButton ribbonSplitButton = (RibbonSplitButton)control_0;
				ribbonSplitButton.ButtonClick += TXITEM_DataSource_DataSource_Handler;
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonReportingTab.InternalRibbonItem.TXITEM_DataSource_DataSource.ToString(), "Click", this);
				RibbonButton ribbonButton2 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonReportingTab.InternalRibbonItem.TXITEM_DataSource_LoadXMLFile.ToString(), "Click", this);
				RibbonButton ribbonButton3 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonReportingTab.InternalRibbonItem.TXITEM_DataSource_LoadAssembly.ToString(), "Click", this);
				RibbonButton ribbonButton4 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonReportingTab.InternalRibbonItem.TXITEM_DataSource_LoadJSON.ToString(), "Click", this);
				RibbonSeperator ribbonSeperator = new RibbonSeperator();
				ribbonSeperator.Name = RibbonReportingTab.InternalRibbonItem.TXITEM_DataSource_Seperator1.ToString();
				RibbonSeperator ribbonSeperator2 = ribbonSeperator;
				((IRibbonItem)ribbonSeperator2).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonSeperator2.Name, ribbonSeperator2);
				RibbonButton ribbonButton5 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonReportingTab.InternalRibbonItem.TXITEM_DataSource_SaveExcerpt.ToString(), "Click", this);
				ribbonButton5.Enabled = false;
				ribbonSplitButton.DropDownItems.AddRange(new Control[6] { ribbonButton, ribbonButton2, ribbonButton3, ribbonButton4, ribbonSeperator2, ribbonButton5 });
			}
		}

		private void method_1(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				RibbonLabel ribbonLabel = new RibbonLabel();
				ribbonLabel.Text = base.m_rmResourceManager.GetString(RibbonReportingTab.InternalRibbonItem.TXITEM_SelectMasterTable_TablesHeader.ToString().Replace("TXITEM", "HEADER"));
				ribbonLabel.Name = RibbonReportingTab.InternalRibbonItem.TXITEM_SelectMasterTable_TablesHeader.ToString();
				RibbonLabel ribbonLabel2 = ribbonLabel;
				((IRibbonItem)ribbonLabel2).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonLabel2.Name, ribbonLabel2);
				RibbonSeperator ribbonSeperator = new RibbonSeperator();
				ribbonSeperator.Name = RibbonReportingTab.InternalRibbonItem.TXITEM_SelectMasterTable_Seperator1.ToString();
				RibbonSeperator ribbonSeperator2 = ribbonSeperator;
				((IRibbonItem)ribbonSeperator2).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonSeperator2.Name, ribbonSeperator2);
				ribbonMenuButton.DropDownItems.AddRange(new Control[2] { ribbonLabel2, ribbonSeperator2 });
				ribbonMenuButton.Enabled = false;
				this.dataSourceManager_0.MasterDataTableInfoChanged += dataSourceManager_0_MasterDataTableInfoChanged;
				this.dataSourceManager_0.DataTablesChanged += dataSourceManager_0_DataTablesChanged;
			}
		}

		private void method_2(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonReportingTab.InternalRibbonItem.TXITEM_ConfigFile_LoadConfiguration.ToString(), "Click", this);
				RibbonButton ribbonButton2 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonReportingTab.InternalRibbonItem.TXITEM_ConfigFile_SaveConfiguration.ToString(), "Click", this);
				ribbonButton2.Enabled = false;
				ribbonMenuButton.DropDownItems.AddRange(new Control[2] { ribbonButton, ribbonButton2 });
			}
		}

		private void method_3(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				RibbonLabel ribbonLabel = new RibbonLabel();
				ribbonLabel.Text = base.m_rmResourceManager.GetString(RibbonReportingTab.InternalRibbonItem.TXITEM_InsertMergeField_TablesHeader.ToString().Replace("TXITEM", "HEADER"));
				ribbonLabel.Name = RibbonReportingTab.InternalRibbonItem.TXITEM_InsertMergeField_TablesHeader.ToString();
				RibbonLabel ribbonLabel2 = ribbonLabel;
				((IRibbonItem)ribbonLabel2).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonLabel2.Name, ribbonLabel2);
				ribbonLabel2.Visible = false;
				RibbonSeperator ribbonSeperator = new RibbonSeperator();
				ribbonSeperator.Name = RibbonReportingTab.InternalRibbonItem.TXITEM_InsertMergeField_Seperator1.ToString();
				RibbonSeperator ribbonSeperator2 = ribbonSeperator;
				((IRibbonItem)ribbonSeperator2).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonSeperator2.Name, ribbonSeperator2);
				ribbonSeperator2.Visible = false;
				RibbonSeperator ribbonSeperator3 = new RibbonSeperator();
				ribbonSeperator3.Name = RibbonReportingTab.InternalRibbonItem.TXITEM_InsertMergeField_Seperator2.ToString();
				RibbonSeperator ribbonSeperator4 = ribbonSeperator3;
				((IRibbonItem)ribbonSeperator4).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonSeperator4.Name, ribbonSeperator4);
				ribbonSeperator4.Visible = false;
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonReportingTab.InternalRibbonItem.TXITEM_InsertMergeField_InsertCustomMergeField.ToString(), "Click", this);
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonReportingTab.InternalRibbonItem.TXITEM_InsertMergeField_HighlightMergeFields.ToString(), "CheckedChanged", this);
				ribbonToggleButton.Checked = this.bool_0;
				ribbonMenuButton.DropDownItems.AddRange(new Control[5] { ribbonLabel2, ribbonSeperator2, ribbonSeperator4, ribbonButton, ribbonToggleButton });
				this.dataSourceManager_0.PossibleMergeFieldColumnsChanged += dataSourceManager_0_PossibleMergeFieldColumnsChanged;
			}
		}

		private void method_4(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonReportingTab.InternalRibbonItem.TXITEM_InsertSpecialField_IF.ToString(), "Click", this);
				RibbonButton ribbonButton2 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonReportingTab.InternalRibbonItem.TXITEM_InsertSpecialField_IncludeText.ToString(), "Click", this);
				RibbonButton ribbonButton3 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonReportingTab.InternalRibbonItem.TXITEM_InsertSpecialField_Date.ToString(), "Click", this);
				RibbonButton ribbonButton4 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonReportingTab.InternalRibbonItem.TXITEM_InsertSpecialField_Next.ToString(), "Click", this);
				RibbonButton ribbonButton5 = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonReportingTab.InternalRibbonItem.TXITEM_InsertSpecialField_NextIf.ToString(), "Click", this);
				ribbonMenuButton.DropDownItems.AddRange(new Control[5] { ribbonButton, ribbonButton2, ribbonButton3, ribbonButton4, ribbonButton5 });
			}
		}

		private void method_5(Dictionary<string, object> dictionary_0, Control control_0)
		{
			if (control_0 is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control_0;
				RibbonLabel ribbonLabel = new RibbonLabel();
				ribbonLabel.Text = base.m_rmResourceManager.GetString(RibbonReportingTab.InternalRibbonItem.TXITEM_InsertMergeBlock_TablesHeader.ToString().Replace("TXITEM", "HEADER"));
				ribbonLabel.Name = RibbonReportingTab.InternalRibbonItem.TXITEM_InsertMergeBlock_TablesHeader.ToString();
				RibbonLabel ribbonLabel2 = ribbonLabel;
				((IRibbonItem)ribbonLabel2).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonLabel2.Name, ribbonLabel2);
				ribbonLabel2.Visible = false;
				RibbonSeperator ribbonSeperator = new RibbonSeperator();
				ribbonSeperator.Name = RibbonReportingTab.InternalRibbonItem.TXITEM_InsertMergeBlock_Seperator1.ToString();
				RibbonSeperator ribbonSeperator2 = ribbonSeperator;
				((IRibbonItem)ribbonSeperator2).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonSeperator2.Name, ribbonSeperator2);
				ribbonSeperator2.Visible = false;
				RibbonSeperator ribbonSeperator3 = new RibbonSeperator();
				ribbonSeperator3.Name = RibbonReportingTab.InternalRibbonItem.TXITEM_InsertMergeBlock_Seperator2.ToString();
				RibbonSeperator ribbonSeperator4 = ribbonSeperator3;
				((IRibbonItem)ribbonSeperator4).IsDefaultRibbonTabItem = true;
				dictionary_0.Add(ribbonSeperator4.Name, ribbonSeperator4);
				ribbonSeperator4.Visible = false;
				RibbonButton ribbonButton = Class517.smethod_26(dictionary_0, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonReportingTab.InternalRibbonItem.TXITEM_InsertMergeBlock_InsertCustomMergeBlock.ToString(), "Click", this);
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(dictionary_0, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, RibbonReportingTab.InternalRibbonItem.TXITEM_InsertMergeBlock_HighlightMergeBlocks.ToString(), "CheckedChanged", this);
				ribbonMenuButton.DropDownItems.AddRange(new Control[5] { ribbonLabel2, ribbonSeperator2, ribbonSeperator4, ribbonButton, ribbonToggleButton });
				this.dataSourceManager_0.PossibleMergeBlockTablesChanged += dataSourceManager_0_PossibleMergeBlockTablesChanged;
			}
		}

		internal override void SetRibbonItemAppearance(Dictionary<string, object> groupItemsDictionary, Control ribbonItem, string eventName, bool hasImage)
		{
			base.SetBasicRibbonItemAppearance(groupItemsDictionary, ribbonItem, hasImage);
			switch (ribbonItem.Name)
			{
			case "TXITEM_DataSource":
				this.method_0(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_SelectMasterTable":
				this.method_1(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_EditDataRelations":
				(ribbonItem as RibbonButton).Click += method_57;
				break;
			case "TXITEM_ConfigFile":
				this.method_2(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_InsertMergeField":
				this.method_3(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_InsertSpecialField":
				this.method_4(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_InsertMergeBlock":
				this.method_5(groupItemsDictionary, ribbonItem);
				break;
			case "TXITEM_ShowFieldCodes":
				(ribbonItem as RibbonToggleButton).CheckedChanged += method_60;
				break;
			case "TXITEM_ShowFieldText":
				(ribbonItem as RibbonToggleButton).CheckedChanged += method_60;
				break;
			}
			if (eventName != null)
			{
				Class517.smethod_23(ribbonItem, eventName, ribbonItem.Name + "_Handler", this);
			}
		}

		internal override void OnDisconnectingTextControl()
		{
			base.m_txTextControl.TextFieldEntered -= method_68;
			base.m_txTextControl.TextFieldLeft -= method_67;
			base.m_txTextControl.TextFieldDeleted -= method_67;
			base.m_txTextControl.InputPositionChanged -= method_66;
			base.m_txTextControl.SubTextPartEntered -= method_65;
			base.m_txTextControl.SubTextPartLeft -= method_64;
		}

		internal override void OnTextControlConnected()
		{
			base.m_txTextControl.TextFieldEntered += method_68;
			base.m_txTextControl.TextFieldLeft += method_67;
			base.m_txTextControl.TextFieldDeleted += method_67;
			base.m_txTextControl.InputPositionChanged += method_66;
			base.m_txTextControl.SubTextPartEntered += method_65;
			base.m_txTextControl.SubTextPartLeft += method_64;
		}

		private void method_6()
		{
			DatabaseConnectionDialog databaseConnectionDialog = new DatabaseConnectionDialog(this.dataSourceManager_0);
			databaseConnectionDialog.RightToLeft = this.class511_0.Control_0.RightToLeft;
			DatabaseConnectionDialog databaseConnectionDialog2 = databaseConnectionDialog;
			if (databaseConnectionDialog2.ShowDialog(this.class511_0.Control_0.FindForm()) == System.Windows.Forms.DialogResult.OK)
			{
				RibbonButton ribbonButton = this.class511_0.TXITEM_DataSourceGroup_Items[RibbonReportingTab.InternalRibbonItem.TXITEM_EditDataRelations.ToString()] as RibbonButton;
				if (ribbonButton != null)
				{
					ribbonButton.Enabled = true;
				}
				this.bool_2 = true;
				RibbonButton ribbonButton2 = this.class511_0.TXITEM_DataSourceGroup_Items[RibbonReportingTab.InternalRibbonItem.TXITEM_ConfigFile_LoadConfiguration.ToString()] as RibbonButton;
				if (ribbonButton2 != null)
				{
					ribbonButton2.Enabled = this.bool_2;
				}
			}
		}

		private void method_7()
		{
			if (this.openFileDialog_0.ShowDialog(this.class511_0.Control_0.FindForm()) == System.Windows.Forms.DialogResult.OK)
			{
				RibbonButton ribbonButton = this.class511_0.TXITEM_DataSourceGroup_Items[RibbonReportingTab.InternalRibbonItem.TXITEM_EditDataRelations.ToString()] as RibbonButton;
				if (ribbonButton != null)
				{
					ribbonButton.Enabled = true;
				}
				this.dataSourceManager_0.LoadXmlFile(this.openFileDialog_0.FileName);
				this.bool_2 = false;
				RibbonButton ribbonButton2 = this.class511_0.TXITEM_DataSourceGroup_Items[RibbonReportingTab.InternalRibbonItem.TXITEM_ConfigFile_LoadConfiguration.ToString()] as RibbonButton;
				if (ribbonButton2 != null)
				{
					ribbonButton2.Enabled = this.bool_2;
				}
			}
		}

		private void method_8()
		{
			if (this.openFileDialog_1.ShowDialog(this.class511_0.Control_0.FindForm()) == System.Windows.Forms.DialogResult.OK)
			{
				RibbonButton ribbonButton = this.class511_0.TXITEM_DataSourceGroup_Items[RibbonReportingTab.InternalRibbonItem.TXITEM_EditDataRelations.ToString()] as RibbonButton;
				if (ribbonButton != null)
				{
					ribbonButton.Enabled = false;
				}
				this.dataSourceManager_0.LoadAssembly(this.openFileDialog_1.FileName);
				this.bool_2 = false;
				RibbonButton ribbonButton2 = this.class511_0.TXITEM_DataSourceGroup_Items[RibbonReportingTab.InternalRibbonItem.TXITEM_ConfigFile_LoadConfiguration.ToString()] as RibbonButton;
				if (ribbonButton2 != null)
				{
					ribbonButton2.Enabled = this.bool_2;
				}
			}
		}

		private void method_9()
		{
			if (this.openFileDialog_2.ShowDialog(this.class511_0.Control_0.FindForm()) == System.Windows.Forms.DialogResult.OK)
			{
				RibbonButton ribbonButton = this.class511_0.TXITEM_DataSourceGroup_Items[RibbonReportingTab.InternalRibbonItem.TXITEM_EditDataRelations.ToString()] as RibbonButton;
				if (ribbonButton != null)
				{
					ribbonButton.Enabled = false;
				}
				this.dataSourceManager_0.LoadJson(File.ReadAllText(this.openFileDialog_2.FileName, Encoding.UTF8));
				this.bool_2 = false;
				RibbonButton ribbonButton2 = this.class511_0.TXITEM_DataSourceGroup_Items[RibbonReportingTab.InternalRibbonItem.TXITEM_ConfigFile_LoadConfiguration.ToString()] as RibbonButton;
				if (ribbonButton2 != null)
				{
					ribbonButton2.Enabled = this.bool_2;
				}
			}
		}

		private void method_10()
		{
			DataSourceExtractionDialog dataSourceExtractionDialog = new DataSourceExtractionDialog(this.dataSourceManager_0);
			dataSourceExtractionDialog.RightToLeft = this.class511_0.Control_0.RightToLeft;
			DataSourceExtractionDialog dataSourceExtractionDialog2 = dataSourceExtractionDialog;
			dataSourceExtractionDialog2.ShowDialog(this.class511_0.Control_0.FindForm());
		}

		private void method_11(RibbonToggleButton ribbonToggleButton_0)
		{
			this.dataSourceManager_0.MasterDataTableInfo = ribbonToggleButton_0.Tag as DataTableInfo;
		}

		private void method_12()
		{
			EditDataRelationsDialog editDataRelationsDialog = new EditDataRelationsDialog(this.dataSourceManager_0);
			editDataRelationsDialog.RightToLeft = this.class511_0.Control_0.RightToLeft;
			editDataRelationsDialog.ShowDialog(this.class511_0.Control_0.FindForm());
		}

		private void method_13()
		{
			this.dataSourceManager_0.LoadDataSourceConfig(this.class511_0.Control_0.FindForm());
		}

		private void method_14()
		{
			if (this.bool_2)
			{
				this.dataSourceManager_0.SaveDataSourceConfig(this.class511_0.Control_0.FindForm());
			}
		}

		private void method_15(RibbonButton ribbonButton_0)
		{
			RibbonButton ribbonButton;
			if (base.m_txTextControl != null && (ribbonButton = ribbonButton_0) != null)
			{
				string text = ribbonButton.Tag as string;
				if (text != null)
				{
					this.method_47(new MergeField(), text);
				}
			}
		}

		private void method_16()
		{
			if (base.m_txTextControl != null)
			{
				MergeField mergeField = new MergeField();
				if (mergeField.ShowDialog(this.class511_0.Control_0.FindForm()) == DialogResult.OK)
				{
					this.method_47(mergeField, mergeField.Name);
				}
			}
		}

		private void method_17(RibbonToggleButton ribbonToggleButton_0)
		{
			RibbonToggleButton ribbonToggleButton;
			if (base.m_txTextControl == null || (ribbonToggleButton = ribbonToggleButton_0) == null || this.bool_0 == (this.bool_0 = ribbonToggleButton.Checked))
			{
				return;
			}
			foreach (ApplicationField applicationField in base.m_txTextControl.ApplicationFields)
			{
				switch (applicationField.TypeName)
				{
				case "MERGEFIELD":
				case "IF":
				case "INCLUDETEXT":
				case "DATE":
				case "NEXT":
				case "NEXTIF":
					applicationField.HighlightMode = ((!this.bool_0) ? HighlightMode.Never : HighlightMode.Activated);
					break;
				}
			}
		}

		private void method_18()
		{
			this.method_49("IF");
		}

		private void method_19()
		{
			this.method_49("INCLUDETEXT");
		}

		private void method_20()
		{
			this.method_49("DATE");
		}

		private void method_21()
		{
			this.method_49("NEXT");
		}

		private void method_22()
		{
			this.method_49("NEXTIF");
		}

		private void method_23()
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			ApplicationField item = base.m_txTextControl.ApplicationFields.GetItem();
			if (item != null)
			{
				MailMergeFieldAdapter mailMergeFieldAdapter = null;
				switch (item.TypeName)
				{
				case "NEXTIF":
					mailMergeFieldAdapter = new NextIfField(item);
					break;
				case "IF":
					mailMergeFieldAdapter = new IfField(item);
					break;
				case "INCLUDETEXT":
					mailMergeFieldAdapter = new IncludeText(item);
					break;
				case "DATE":
					mailMergeFieldAdapter = new DateField(item);
					break;
				case "MERGEFIELD":
					mailMergeFieldAdapter = new MergeField(item);
					break;
				}
				mailMergeFieldAdapter?.ShowDialog(this.class511_0.Control_0, this.class511_0.Control_0.RightToLeft == RightToLeft.Yes);
			}
		}

		private void method_24()
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			ApplicationField item = base.m_txTextControl.ApplicationFields.GetItem();
			if (item != null)
			{
				switch (item.TypeName)
				{
				case "MERGEFIELD":
				case "DATE":
				case "INCLUDETEXT":
				case "IF":
				case "NEXT":
				case "NEXTIF":
					base.m_txTextControl.ApplicationFields.Remove(item);
					this.method_44(true, false, null);
					break;
				}
			}
		}

		private void method_25(RibbonButton ribbonButton_0)
		{
			DataTableInfo tableInfo;
			if (base.m_txTextControl != null && (tableInfo = ribbonButton_0.Tag as DataTableInfo) != null)
			{
				InsertMergeBlockDialog insertMergeBlockDialog = new InsertMergeBlockDialog(this.dataSourceManager_0, base.m_txTextControl, tableInfo);
				insertMergeBlockDialog.RightToLeft = this.class511_0.Control_0.RightToLeft;
				if (insertMergeBlockDialog.ShowDialog(this.class511_0.Control_0.FindForm()) == System.Windows.Forms.DialogResult.OK)
				{
					this.method_51(null);
				}
			}
		}

		private void method_26()
		{
			if (base.m_txTextControl != null && base.m_txTextControl.Selection.Length > 0)
			{
				InsertCustomMergeBlockDialog insertCustomMergeBlockDialog = new InsertCustomMergeBlockDialog(base.m_txTextControl);
				if (insertCustomMergeBlockDialog.ShowDialog(this.class511_0.Control_0.FindForm()) == System.Windows.Forms.DialogResult.OK && !string.IsNullOrEmpty(insertCustomMergeBlockDialog.String_0))
				{
					this.method_52(insertCustomMergeBlockDialog.String_0, Color.FromArgb(60, 255, 0, 0));
				}
			}
		}

		private void method_27(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl == null || !((IRibbonItem)ribbonToggleButton_0).IsDefaultRibbonTabItem)
			{
				return;
			}
			this.highlightMode_0 = (ribbonToggleButton_0.Checked ? HighlightMode.Always : HighlightMode.Activated);
			foreach (SubTextPart subTextPart in base.m_txTextControl.SubTextParts)
			{
				if (DataSourceManager.IsMergeBlock(subTextPart))
				{
					subTextPart.HighlightMode = this.highlightMode_0;
				}
			}
		}

		private void method_28()
		{
			EditMergeBlocksDialog editMergeBlocksDialog = new EditMergeBlocksDialog(this.dataSourceManager_0, base.m_txTextControl);
			editMergeBlocksDialog.RightToLeft = this.class511_0.Control_0.RightToLeft;
			editMergeBlocksDialog.ShowDialog(this.class511_0.Control_0.FindForm());
		}

		private void method_29(RibbonToggleButton ribbonToggleButton_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			RibbonToggleButton ribbonToggleButton = this.class511_0.TXITEM_ViewGroup_Items[RibbonReportingTab.InternalRibbonItem.TXITEM_ShowFieldCodes.ToString()] as RibbonToggleButton;
			RibbonToggleButton ribbonToggleButton2 = this.class511_0.TXITEM_ViewGroup_Items[RibbonReportingTab.InternalRibbonItem.TXITEM_ShowFieldText.ToString()] as RibbonToggleButton;
			if (ribbonToggleButton_0 == ribbonToggleButton)
			{
				ribbonToggleButton2.Checked = !ribbonToggleButton.Checked;
			}
			else
			{
				ribbonToggleButton.Checked = !ribbonToggleButton2.Checked;
			}
			this.bool_1 = ribbonToggleButton.Checked;
			foreach (IFormattedText textPart in base.m_txTextControl.TextParts)
			{
				foreach (ApplicationField applicationField in textPart.ApplicationFields)
				{
					this.method_54(applicationField);
				}
			}
		}

		private void method_30(RibbonToggleButton ribbonToggleButton_0)
		{
			Sidebar fieldNavigatorSidebar = (this.class511_0.Control_0 as RibbonReportingTab).FieldNavigatorSidebar;
			if (fieldNavigatorSidebar == null)
			{
				return;
			}
			if (ribbonToggleButton_0.Checked)
			{
				if (fieldNavigatorSidebar.ContentLayout != Sidebar.SidebarContentLayout.FieldNavigator)
				{
					if (fieldNavigatorSidebar.IsShown && !fieldNavigatorSidebar.IsPinned)
					{
						fieldNavigatorSidebar.IsShown = false;
					}
					fieldNavigatorSidebar.ContentLayout = Sidebar.SidebarContentLayout.FieldNavigator;
				}
				fieldNavigatorSidebar.IsPinned = this.bool_4;
				fieldNavigatorSidebar.IsShown = true;
			}
			else if (fieldNavigatorSidebar.ContentLayout == Sidebar.SidebarContentLayout.FieldNavigator)
			{
				fieldNavigatorSidebar.IsShown = false;
			}
		}

		private void method_31(Sidebar sidebar_0, string string_0)
		{
			if (string_0 == "IsShown" || string_0 == "ContentLayout")
			{
				RibbonToggleButton ribbonToggleButton = this.class511_0.TXITEM_ViewGroup_Items[RibbonReportingTab.InternalRibbonItem.TXITEM_FieldNavigation.ToString()] as RibbonToggleButton;
				ribbonToggleButton.Checked = sidebar_0.IsShown && sidebar_0.ContentLayout == Sidebar.SidebarContentLayout.FieldNavigator;
			}
			if (string_0 == "IsPinned" && sidebar_0.ContentLayout == Sidebar.SidebarContentLayout.FieldNavigator)
			{
				this.bool_4 = sidebar_0.IsPinned;
			}
		}

		private void method_32(Sidebar sidebar_0)
		{
			if (sidebar_0.ContentLayout == Sidebar.SidebarContentLayout.FieldNavigator)
			{
				Class517.smethod_39(sidebar_0, this.point_0, this.size_0, bool_0: true);
			}
		}

		private void method_33(Sidebar sidebar_0)
		{
			if (sidebar_0.ContentLayout == Sidebar.SidebarContentLayout.FieldNavigator)
			{
				this.point_0 = sidebar_0.DialogLocation;
				this.size_0 = sidebar_0.DialogSize;
			}
		}

		private void method_34()
		{
			RibbonMenuButton ribbonMenuButton = this.class511_0.TXITEM_DataSourceGroup_Items[RibbonReportingTab.InternalRibbonItem.TXITEM_SelectMasterTable.ToString()] as RibbonMenuButton;
			if (!this.class511_0.method_2(ribbonMenuButton))
			{
				return;
			}
			foreach (Control dropDownItem in ribbonMenuButton.DropDownItems)
			{
				RibbonToggleButton ribbonToggleButton = dropDownItem as RibbonToggleButton;
				if (ribbonToggleButton != null && ((IRibbonItem)ribbonToggleButton).IsDefaultRibbonTabItem && ribbonToggleButton.Checked)
				{
					this.dataSourceManager_0.MasterDataTableInfo = ribbonToggleButton.Tag as DataTableInfo;
					break;
				}
			}
		}

		private void method_35(SubTextPart subTextPart_0)
		{
			if (DataSourceManager.IsMergeBlock(subTextPart_0))
			{
				string text = subTextPart_0.Name.Remove(0, MailMerge.MergeBlockNamePrefix.Length);
				if (this.dataSourceManager_0.DataTables.Contains(text))
				{
					this.dataSourceManager_0.MasterDataTableInfo = this.dataSourceManager_0.DataTables[text];
				}
			}
		}

		private void method_36()
		{
			this.method_51(null);
		}

		private void method_37()
		{
			this.method_44(null, false, null);
			this.method_50(null);
		}

		private void method_38(ApplicationField applicationField_0)
		{
			this.method_44(null, true, applicationField_0);
			this.method_50(false);
		}

		internal void method_39()
		{
			bool? flag = null;
			bool? flag2 = null;
			RibbonMenuButton ribbonMenuButton = this.class511_0.TXITEM_MergeFieldsGroup_Items[RibbonReportingTab.InternalRibbonItem.TXITEM_InsertMergeField.ToString()] as RibbonMenuButton;
			if (this.class511_0.method_2(ribbonMenuButton))
			{
				flag = base.m_txTextControl.TextFields.GetItem() != null;
				flag2 = base.m_txTextControl.CanEdit;
				foreach (Control dropDownItem in ribbonMenuButton.DropDownItems)
				{
					this.method_46(flag2.Value, flag.Value, dropDownItem);
				}
			}
			RibbonMenuButton ribbonMenuButton2 = this.class511_0.TXITEM_MergeBlocksGroup_Items[RibbonReportingTab.InternalRibbonItem.TXITEM_InsertMergeBlock.ToString()] as RibbonMenuButton;
			if (!this.class511_0.method_2(ribbonMenuButton2))
			{
				return;
			}
			if (!flag.HasValue)
			{
				flag = base.m_txTextControl.TextFields.GetItem() != null;
				flag2 = base.m_txTextControl.CanEdit;
			}
			foreach (Control dropDownItem2 in ribbonMenuButton2.DropDownItems)
			{
				if ((dropDownItem2 as IRibbonItem).IsDefaultRibbonTabItem && dropDownItem2 is IEnabledItem && !(dropDownItem2 is RibbonToggleButton))
				{
					dropDownItem2.Enabled = flag2.Value && !flag.Value;
				}
			}
		}

		private void method_40()
		{
			string text = this.method_45();
			RibbonLabel ribbonLabel = this.class511_0.TXITEM_MergeFieldsGroup_Items[RibbonReportingTab.InternalRibbonItem.TXITEM_InsertMergeField_TablesHeader.ToString()] as RibbonLabel;
			if (ribbonLabel != null)
			{
				ribbonLabel.Text = base.m_rmResourceManager.GetString(RibbonReportingTab.InternalRibbonItem.TXITEM_InsertMergeField_TablesHeader.ToString().Replace("TXITEM", "HEADER")) + text;
			}
		}

		private void method_41()
		{
			RibbonMenuButton ribbonMenuButton = this.class511_0.TXITEM_DataSourceGroup_Items[RibbonReportingTab.InternalRibbonItem.TXITEM_SelectMasterTable.ToString()] as RibbonMenuButton;
			if (ribbonMenuButton == null)
			{
				return;
			}
			for (int num = ribbonMenuButton.DropDownItems.Count - 1; num >= 0; num--)
			{
				Control control = ribbonMenuButton.DropDownItems[num];
				if (control.Tag is DataTableInfo)
				{
					ribbonMenuButton.DropDownItems.Remove(control);
				}
			}
			if (!(ribbonMenuButton.Enabled = this.dataSourceManager_0.DataTables.Count > 0))
			{
				return;
			}
			List<RibbonButton> list = new List<RibbonButton>();
			foreach (DataTableInfo dataTable in this.dataSourceManager_0.DataTables)
			{
				RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
				ribbonToggleButton.DisplayMode = IconTextRelation.SmallIconLabeled;
				RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
				ribbonToggleButton2.IsAddToQuickAccessToolbarEnabled = false;
				ribbonToggleButton2.Text = dataTable.TableName;
				ribbonToggleButton2.Tag = dataTable;
				ribbonToggleButton2.SmallIcon = Class517.Bitmap_6;
				((IRibbonItem)ribbonToggleButton2).IsDefaultRibbonTabItem = true;
				ribbonToggleButton2.Click += method_56;
				list.Add(ribbonToggleButton2);
			}
			RibbonButton ribbonButton = this.class511_0.TXITEM_DataSourceGroup_Items[RibbonReportingTab.InternalRibbonItem.TXITEM_DataSource_SaveExcerpt.ToString()] as RibbonButton;
			if (ribbonButton != null)
			{
				ribbonButton.Enabled = true;
			}
			ribbonMenuButton.DropDownItems.AddRange(list.ToArray());
		}

		private void method_42()
		{
			RibbonMenuButton ribbonMenuButton = this.class511_0.TXITEM_MergeFieldsGroup_Items[RibbonReportingTab.InternalRibbonItem.TXITEM_InsertMergeField.ToString()] as RibbonMenuButton;
			if (ribbonMenuButton == null)
			{
				return;
			}
			int num = 0;
			bool flag = this.dataSourceManager_0.PossibleMergeFieldColumns.Count > 0;
			for (int num2 = ribbonMenuButton.DropDownItems.Count - 1; num2 >= 0; num2--)
			{
				Control control = ribbonMenuButton.DropDownItems[num2];
				if ((control as IRibbonItem).IsDefaultRibbonTabItem)
				{
					if (!(control.Tag is string) && !(control is RibbonMenuButton))
					{
						if (control.Name == RibbonReportingTab.InternalRibbonItem.TXITEM_InsertMergeField_Seperator1.ToString())
						{
							num = num2;
						}
						control.Visible = flag || control is RibbonButton;
					}
					else
					{
						ribbonMenuButton.DropDownItems.Remove(control);
					}
				}
			}
			if (flag)
			{
				List<RibbonButton> list = new List<RibbonButton>();
				bool bool_ = ((base.m_txTextControl == null || (base.m_txTextControl.TextFields.GetItem() == null && base.m_txTextControl.CanEdit)) ? true : false);
				this.method_48(list, this.dataSourceManager_0.PossibleMergeFieldColumns, this.dataSourceManager_0.MasterDataTableInfo.ChildTables, "", null, bool_);
				ribbonMenuButton.DropDownItems.InsertRange(num + 1, list.ToArray());
			}
		}

		private void method_43()
		{
			RibbonMenuButton ribbonMenuButton = this.class511_0.TXITEM_MergeBlocksGroup_Items[RibbonReportingTab.InternalRibbonItem.TXITEM_InsertMergeBlock.ToString()] as RibbonMenuButton;
			if (ribbonMenuButton == null)
			{
				return;
			}
			int num = 0;
			bool flag = this.dataSourceManager_0.PossibleMergeBlockTables.Count > 0;
			for (int num2 = ribbonMenuButton.DropDownItems.Count - 1; num2 >= 0; num2--)
			{
				Control control = ribbonMenuButton.DropDownItems[num2];
				if (control.Tag is DataTableInfo)
				{
					ribbonMenuButton.DropDownItems.Remove(control);
				}
				else if ((control as IRibbonItem).IsDefaultRibbonTabItem)
				{
					if (control.Name == "TXITEM_InsertMergeBlock_Seperator1")
					{
						num = num2;
					}
					control.Visible = flag || control is RibbonButton;
				}
			}
			if (!flag)
			{
				return;
			}
			bool enabled = base.m_txTextControl == null || base.m_txTextControl.CanEdit;
			List<RibbonButton> list = new List<RibbonButton>();
			foreach (DataTableInfo possibleMergeBlockTable in this.dataSourceManager_0.PossibleMergeBlockTables)
			{
				RibbonButton ribbonButton = new RibbonButton();
				ribbonButton.DisplayMode = IconTextRelation.SmallIconLabeled;
				RibbonButton ribbonButton2 = ribbonButton;
				ribbonButton2.Enabled = enabled;
				ribbonButton2.IsAddToQuickAccessToolbarEnabled = false;
				ribbonButton2.Text = possibleMergeBlockTable.TableName;
				ribbonButton2.Tag = possibleMergeBlockTable;
				ribbonButton2.SmallIcon = Class517.Bitmap_6;
				((IRibbonItem)ribbonButton2).IsDefaultRibbonTabItem = true;
				ribbonButton2.Click += method_59;
				list.Add(ribbonButton2);
			}
			ribbonMenuButton.DropDownItems.InsertRange(num + 1, list.ToArray());
		}

		internal override void UpdateRibbonTab(params object[] args)
		{
			bool canEdit = base.m_txTextControl.CanEdit;
			ApplicationField item = base.m_txTextControl.ApplicationFields.GetItem();
			this.method_44(base.m_txTextControl.CanEdit, item != null, item);
			this.method_50(canEdit);
		}

		internal void method_44(bool? nullable_0, bool? nullable_1, ApplicationField applicationField_0)
		{
			RibbonGroup ribbonGroup_ = this.class511_0.TXITEM_MergeFieldsGroup_Items[RibbonReportingTab.InternalRibbonItem.TXITEM_MergeFieldsGroup.ToString()] as RibbonGroup;
			if (!this.class511_0.method_0(ribbonGroup_))
			{
				return;
			}
			RibbonMenuButton ribbonMenuButton = this.class511_0.TXITEM_MergeFieldsGroup_Items[RibbonReportingTab.InternalRibbonItem.TXITEM_InsertMergeField.ToString()] as RibbonMenuButton;
			if (this.class511_0.method_2(ribbonMenuButton))
			{
				if (!nullable_0.HasValue)
				{
					nullable_0 = base.m_txTextControl.CanEdit;
				}
				if (!nullable_1.HasValue)
				{
					nullable_1 = base.m_txTextControl.TextFields.GetItem() != null;
				}
				foreach (Control dropDownItem in ribbonMenuButton.DropDownItems)
				{
					this.method_46(nullable_0.Value, nullable_1.Value, dropDownItem);
				}
			}
			RibbonMenuButton ribbonMenuButton2 = this.class511_0.TXITEM_MergeFieldsGroup_Items[RibbonReportingTab.InternalRibbonItem.TXITEM_InsertSpecialField.ToString()] as RibbonMenuButton;
			if (this.class511_0.method_2(ribbonMenuButton2))
			{
				if (!nullable_0.HasValue)
				{
					nullable_0 = base.m_txTextControl.CanEdit;
				}
				if (!nullable_1.HasValue)
				{
					nullable_1 = base.m_txTextControl.TextFields.GetItem() != null;
				}
				foreach (Control dropDownItem2 in ribbonMenuButton2.DropDownItems)
				{
					if ((dropDownItem2 as IRibbonItem).IsDefaultRibbonTabItem)
					{
						dropDownItem2.Enabled = nullable_0.Value && !nullable_1.Value;
					}
				}
			}
			RibbonButton ribbonButton = this.class511_0.TXITEM_MergeFieldsGroup_Items[RibbonReportingTab.InternalRibbonItem.TXITEM_FieldProperties.ToString()] as RibbonButton;
			if (this.class511_0.method_2(ribbonButton))
			{
				if (!nullable_0.HasValue)
				{
					nullable_0 = base.m_txTextControl.CanEdit;
				}
				if (!nullable_1.HasValue)
				{
					nullable_1 = base.m_txTextControl.TextFields.GetItem() != null;
				}
				ribbonButton.Enabled = nullable_0.Value && nullable_1.Value && applicationField_0 != null && applicationField_0.TypeName != "NEXT";
			}
			RibbonButton ribbonButton2 = this.class511_0.TXITEM_MergeFieldsGroup_Items[RibbonReportingTab.InternalRibbonItem.TXITEM_DeleteField.ToString()] as RibbonButton;
			if (this.class511_0.method_2(ribbonButton2))
			{
				if (!nullable_0.HasValue)
				{
					nullable_0 = base.m_txTextControl.CanEdit;
				}
				ribbonButton2.Enabled = nullable_0.Value && nullable_1.Value;
			}
		}

		private string method_45()
		{
			RibbonMenuButton ribbonMenuButton = this.class511_0.TXITEM_DataSourceGroup_Items[RibbonReportingTab.InternalRibbonItem.TXITEM_SelectMasterTable.ToString()] as RibbonMenuButton;
			string text = ((this.dataSourceManager_0.MasterDataTableInfo != null) ? this.dataSourceManager_0.MasterDataTableInfo.TableName : "");
			if (base.m_txTextControl != null)
			{
				SubTextPart item;
				bool flag = (item = base.m_txTextControl.SubTextParts.GetItem()) != null && DataSourceManager.IsMergeBlock(item);
				{
					foreach (Control dropDownItem in ribbonMenuButton.DropDownItems)
					{
						RibbonToggleButton ribbonToggleButton = dropDownItem as RibbonToggleButton;
						if (ribbonToggleButton != null && ((IRibbonItem)ribbonToggleButton).IsDefaultRibbonTabItem && (ribbonToggleButton.Enabled = !flag))
						{
							ribbonToggleButton.Checked = ribbonToggleButton.Text == text;
						}
					}
					return text;
				}
			}
			return text;
		}

		internal void method_46(bool bool_5, bool bool_6, Control control_0)
		{
			if (!(control_0 as IRibbonItem).IsDefaultRibbonTabItem || control_0 is RibbonToggleButton)
			{
				return;
			}
			if (control_0 is RibbonMenuButton)
			{
				foreach (Control dropDownItem in (control_0 as RibbonMenuButton).DropDownItems)
				{
					this.method_46(bool_5, bool_6, dropDownItem);
				}
			}
			else
			{
				control_0.Enabled = ((!(control_0 is RibbonButton)) ? bool_5 : (bool_5 && !bool_6));
			}
		}

		private void method_47(MergeField mergeField_0, string string_0)
		{
			mergeField_0.Name = string_0;
			mergeField_0.ApplicationField.Editable = false;
			this.method_54(mergeField_0.ApplicationField);
			mergeField_0.ApplicationField.HighlightMode = ((!this.bool_0) ? HighlightMode.Never : HighlightMode.Activated);
			mergeField_0.ApplicationField.DoubledInputPosition = true;
			base.m_txTextControl.ApplicationFields.Add(mergeField_0.ApplicationField);
		}

		private void method_48(List<RibbonButton> list_0, DataColumnInfoCollection dataColumnInfoCollection_0, DataTableInfoCollection dataTableInfoCollection_0, string string_0, RibbonItemCollection ribbonItemCollection_0, bool bool_5)
		{
			foreach (DataColumnInfo item in dataColumnInfoCollection_0)
			{
				RibbonButton ribbonButton = new RibbonButton();
				ribbonButton.DisplayMode = IconTextRelation.SmallIconLabeled;
				RibbonButton ribbonButton2 = ribbonButton;
				ribbonButton2.Enabled = bool_5;
				ribbonButton2.IsAddToQuickAccessToolbarEnabled = false;
				ribbonButton2.Text = item.Caption;
				ribbonButton2.Tag = string_0 + item.Caption;
				ribbonButton2.SmallIcon = Class517.Bitmap_12;
				((IRibbonItem)ribbonButton2).IsDefaultRibbonTabItem = true;
				ribbonButton2.Click += method_58;
				if (ribbonItemCollection_0 == null)
				{
					list_0.Add(ribbonButton2);
				}
				else
				{
					ribbonItemCollection_0.Add(ribbonButton2);
				}
			}
			foreach (DataTableInfo item2 in dataTableInfoCollection_0)
			{
				RibbonMenuButton ribbonMenuButton = new RibbonMenuButton();
				ribbonMenuButton.DisplayMode = IconTextRelation.SmallIconLabeled;
				RibbonMenuButton ribbonMenuButton2 = ribbonMenuButton;
				((IRibbonItem)ribbonMenuButton2).IsDefaultRibbonTabItem = true;
				ribbonMenuButton2.IsAddToQuickAccessToolbarEnabled = false;
				ribbonMenuButton2.Text = item2.TableName;
				ribbonMenuButton2.SmallIcon = Class517.Bitmap_6;
				this.method_48(list_0, item2.Columns, item2.ChildTables, string_0 + item2.TableName + ".", ribbonMenuButton2.DropDownItems, bool_5);
				if (ribbonItemCollection_0 == null)
				{
					list_0.Add(ribbonMenuButton2);
				}
				else
				{
					ribbonItemCollection_0.Add(ribbonMenuButton2);
				}
			}
		}

		private void method_49(string string_0)
		{
			if (base.m_txTextControl == null)
			{
				return;
			}
			FieldAdapter fieldAdapter = null;
			switch (string_0)
			{
			case "NEXTIF":
				fieldAdapter = new NextIfField();
				break;
			case "NEXT":
				fieldAdapter = new NextField();
				break;
			case "DATE":
			{
				DateField dateField = new DateField();
				dateField.Format = "dd.MM.yyyy";
				fieldAdapter = dateField;
				break;
			}
			case "INCLUDETEXT":
				fieldAdapter = new IncludeText();
				break;
			case "IF":
				fieldAdapter = new IfField();
				break;
			}
			if (fieldAdapter != null)
			{
				fieldAdapter.ApplicationField.DoubledInputPosition = true;
				fieldAdapter.ApplicationField.Editable = false;
				fieldAdapter.ApplicationField.HighlightMode = ((!this.bool_0) ? HighlightMode.Never : HighlightMode.Activated);
				Control control = this.class511_0.Control_0.FindForm();
				if (fieldAdapter is NextField || fieldAdapter.ShowDialog(control, control.RightToLeft == RightToLeft.Yes) == DialogResult.OK)
				{
					base.m_txTextControl.ApplicationFields.Add(fieldAdapter.ApplicationField);
				}
			}
		}

		private void method_50(bool? nullable_0)
		{
			RibbonMenuButton ribbonMenuButton = this.class511_0.TXITEM_MergeBlocksGroup_Items[RibbonReportingTab.InternalRibbonItem.TXITEM_InsertMergeBlock.ToString()] as RibbonMenuButton;
			if (!this.class511_0.method_2(ribbonMenuButton))
			{
				return;
			}
			if (!nullable_0.HasValue)
			{
				nullable_0 = base.m_txTextControl.CanEdit;
			}
			foreach (Control dropDownItem in ribbonMenuButton.DropDownItems)
			{
				if ((dropDownItem as IRibbonItem).IsDefaultRibbonTabItem && dropDownItem is RibbonButton && !(dropDownItem is RibbonToggleButton))
				{
					dropDownItem.Enabled = nullable_0.Value;
				}
			}
		}

		internal void method_51(bool? nullable_0)
		{
			RibbonButton ribbonButton = this.class511_0.TXITEM_MergeBlocksGroup_Items[RibbonReportingTab.InternalRibbonItem.TXITEM_InsertMergeBlock_InsertCustomMergeBlock.ToString()] as RibbonButton;
			if (this.class511_0.method_2(ribbonButton))
			{
				if (!nullable_0.HasValue)
				{
					nullable_0 = base.m_txTextControl.CanEdit;
				}
				if (!nullable_0.Value || this.bool_3 != (this.bool_3 = base.m_txTextControl == null || base.m_txTextControl.Selection.Length > 0))
				{
					ribbonButton.Enabled = nullable_0.Value && this.bool_3;
				}
			}
		}

		private void method_52(string string_0, Color color_0)
		{
			SubTextPart subTextPart = new SubTextPart("txmb_" + string_0, 0);
			subTextPart.HighlightMode = this.highlightMode_0;
			subTextPart.HighlightColor = color_0;
			SubTextPartCollection.AddResult addResult_ = base.m_txTextControl.SubTextParts.Add(subTextPart);
			this.method_53(addResult_);
		}

		private void method_53(SubTextPartCollection.AddResult addResult_0)
		{
			if (addResult_0 != SubTextPartCollection.AddResult.Successful)
			{
				string text = null;
				switch (addResult_0)
				{
				case SubTextPartCollection.AddResult.Error:
					text = base.m_rmResourceManager.GetString("ERR_BLOCK_UNKNOWN_ERROR");
					break;
				case SubTextPartCollection.AddResult.NoSelection:
					text = base.m_rmResourceManager.GetString("ERR_BLOCK_NO_SELECTION");
					break;
				case SubTextPartCollection.AddResult.SelectionTooComplex:
					text = base.m_rmResourceManager.GetString("ERR_BLOCK_SELECTION_TOO_COMPLEX");
					break;
				case SubTextPartCollection.AddResult.PositionInvalid:
					text = base.m_rmResourceManager.GetString("ERR_BLOCK_POSITION_INVALID");
					break;
				case SubTextPartCollection.AddResult.AlreadyExists:
					text = base.m_rmResourceManager.GetString("ERR_BLOCK_ALREADY_EXISTS");
					break;
				case SubTextPartCollection.AddResult.Overlapping:
					text = base.m_rmResourceManager.GetString("ERR_BLOCK_OVERLAPPING");
					break;
				}
				if (text != null)
				{
					MessageBox.Show(this.class511_0.Control_0.FindForm(), text, null, MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
			}
		}

		private void method_54(ApplicationField applicationField_0)
		{
			if (this.bool_1)
			{
				Class482.smethod_0(applicationField_0);
			}
			else
			{
				Class482.smethod_1(applicationField_0);
			}
		}

		private static void smethod_0(ApplicationField applicationField_0)
		{
			switch (applicationField_0.TypeName)
			{
			case "MERGEFIELD":
			case "IF":
			case "INCLUDETEXT":
			case "DATE":
			case "NEXT":
			case "NEXTIF":
			{
				string text = ((applicationField_0.Parameters != null) ? string.Join(" ", applicationField_0.Parameters) : "");
				applicationField_0.Text = "{ " + applicationField_0.TypeName + " " + text + " }";
				break;
			}
			}
		}

		private static void smethod_1(ApplicationField applicationField_0)
		{
			switch (applicationField_0.TypeName)
			{
			case "NEXTIF":
			{
				NextIfField nextIfField = new NextIfField(applicationField_0);
				nextIfField.ApplicationField.Text = "{" + nextIfField.TypeName + "}";
				break;
			}
			case "NEXT":
			{
				NextField nextField = new NextField(applicationField_0);
				nextField.ApplicationField.Text = "{" + nextField.TypeName + "}";
				break;
			}
			case "INCLUDETEXT":
			{
				IncludeText includeText = new IncludeText(applicationField_0);
				includeText.ApplicationField.Text = "{" + includeText.TypeName + "}";
				break;
			}
			case "DATE":
			{
				DateField dateField = new DateField(applicationField_0);
				dateField.Text = "{" + dateField.TypeName + "}";
				break;
			}
			case "IF":
			{
				IfField ifField = new IfField(applicationField_0);
				ifField.Text = "{" + ifField.TypeName + "}";
				break;
			}
			case "MERGEFIELD":
			{
				MergeField mergeField = new MergeField(applicationField_0);
				mergeField.Text = "«" + mergeField.Name + "»";
				break;
			}
			}
		}

		internal void method_55(Sidebar sidebar_0)
		{
			if (sidebar_0 != null)
			{
				sidebar_0.PropertyChanged -= method_61;
			}
			RibbonReportingTab ribbonReportingTab = this.class511_0.Control_0 as RibbonReportingTab;
			if (ribbonReportingTab != null)
			{
				RibbonToggleButton ribbonToggleButton = this.class511_0.TXITEM_ViewGroup_Items[RibbonReportingTab.InternalRibbonItem.TXITEM_FieldNavigation.ToString()] as RibbonToggleButton;
				if (ribbonToggleButton.Visible = ribbonReportingTab.FieldNavigatorSidebar != null)
				{
					ribbonToggleButton.Checked = ribbonReportingTab.FieldNavigatorSidebar.IsShown && ribbonReportingTab.FieldNavigatorSidebar.ContentLayout == Sidebar.SidebarContentLayout.FieldNavigator;
					this.point_0 = ribbonReportingTab.FieldNavigatorSidebar.DialogLocation;
					this.size_0 = ribbonReportingTab.FieldNavigatorSidebar.DialogSize;
					ribbonReportingTab.FieldNavigatorSidebar.PropertyChanged -= method_61;
					ribbonReportingTab.FieldNavigatorSidebar.PropertyChanged += method_61;
					ribbonReportingTab.FieldNavigatorSidebar.DialogOpening -= method_62;
					ribbonReportingTab.FieldNavigatorSidebar.DialogOpening += method_62;
					ribbonReportingTab.FieldNavigatorSidebar.DialogClosed -= method_63;
					ribbonReportingTab.FieldNavigatorSidebar.DialogClosed += method_63;
					this.bool_4 = ribbonReportingTab.FieldNavigatorSidebar.IsPinned;
				}
			}
		}

		private void dataSourceManager_0_MasterDataTableInfoChanged(object sender, EventArgs e)
		{
			this.method_40();
		}

		private void dataSourceManager_0_DataTablesChanged(object sender, EventArgs e)
		{
			this.method_41();
		}

		internal void dataSourceManager_0_PossibleMergeFieldColumnsChanged(object sender, EventArgs e)
		{
			this.method_42();
		}

		private void dataSourceManager_0_PossibleMergeBlockTablesChanged(object sender, EventArgs e)
		{
			this.method_43();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_DataSource_DataSource_Handler(object sender, EventArgs e)
		{
			this.method_6();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_DataSource_LoadXMLFile_Handler(object sender, EventArgs e)
		{
			this.method_7();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_DataSource_LoadAssembly_Handler(object sender, EventArgs e)
		{
			this.method_8();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_DataSource_LoadJSON_Handler(object sender, EventArgs e)
		{
			this.method_9();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_DataSource_SaveExcerpt_Handler(object sender, EventArgs e)
		{
			this.method_10();
		}

		private void method_56(object sender, EventArgs e)
		{
			this.method_11(sender as RibbonToggleButton);
		}

		private void method_57(object sender, EventArgs e)
		{
			this.method_12();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_ConfigFile_LoadConfiguration_Handler(object sender, EventArgs e)
		{
			this.method_13();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_ConfigFile_SaveConfiguration_Handler(object sender, EventArgs e)
		{
			this.method_14();
		}

		private void method_58(object sender, EventArgs e)
		{
			this.method_15(sender as RibbonButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertMergeField_InsertCustomMergeField_Handler(object sender, EventArgs e)
		{
			this.method_16();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertMergeField_HighlightMergeFields_Handler(object sender, EventArgs e)
		{
			this.method_17(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertSpecialField_IF_Handler(object sender, EventArgs e)
		{
			this.method_18();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertSpecialField_IncludeText_Handler(object sender, EventArgs e)
		{
			this.method_19();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertSpecialField_Date_Handler(object sender, EventArgs e)
		{
			this.method_20();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertSpecialField_Next_Handler(object sender, EventArgs e)
		{
			this.method_21();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertSpecialField_NextIf_Handler(object sender, EventArgs e)
		{
			this.method_22();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_FieldProperties_Handler(object sender, EventArgs e)
		{
			this.method_23();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_DeleteField_Handler(object sender, EventArgs e)
		{
			this.method_24();
		}

		private void method_59(object sender, EventArgs e)
		{
			this.method_25(sender as RibbonButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertMergeBlock_InsertCustomMergeBlock_Handler(object sender, EventArgs e)
		{
			this.method_26();
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_InsertMergeBlock_HighlightMergeBlocks_Handler(object sender, EventArgs e)
		{
			this.method_27(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_EditMergeBlocks_Handler(object sender, EventArgs e)
		{
			this.method_28();
		}

		private void method_60(object sender, EventArgs e)
		{
			this.method_29(sender as RibbonToggleButton);
		}

		[Obfuscation(Exclude = true)]
		private void TXITEM_FieldNavigation_Handler(object sender, EventArgs e)
		{
			this.method_30(sender as RibbonToggleButton);
		}

		private void method_61(object sender, PropertyChangedEventArgs e)
		{
			this.method_31(sender as Sidebar, e.PropertyName);
		}

		private void method_62(object sender, EventArgs e)
		{
			this.method_32(sender as Sidebar);
		}

		private void method_63(object sender, EventArgs e)
		{
			this.method_33(sender as Sidebar);
		}

		internal void method_64(object sender, SubTextPartEventArgs e)
		{
			this.method_34();
		}

		internal void method_65(object sender, SubTextPartEventArgs e)
		{
			this.method_35(e.SubTextPart);
		}

		internal void method_66(object sender, EventArgs e)
		{
			this.method_36();
		}

		internal void method_67(object sender, TextFieldEventArgs e)
		{
			this.method_37();
		}

		internal void method_68(object sender, TextFieldEventArgs e)
		{
			this.method_38(e.TextField as ApplicationField);
		}
	}
}
