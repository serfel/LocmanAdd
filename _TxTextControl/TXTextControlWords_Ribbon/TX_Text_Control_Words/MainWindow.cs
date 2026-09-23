using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using TX_Text_Control_Words.FileHandling;
using TX_Text_Control_Words.Properties;
using TX_Text_Control_Words.Utils;
using TXTextControl;
using TXTextControl.DataVisualization;
using DocumentServer.DataSources;
using DocumentServer.Fields;
using TXTextControl.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TX_Text_Control_Words
{
	public class MainWindow : RibbonForm
	{
		private sealed class MergeIntoSeparateFilesInfo
		{
			public StreamType StreamType { get; private set; }

			public string DirectoryName { get; private set; }

			public MergeIntoSeparateFilesInfo(StreamType streamType, string dirName)
			{
				this.StreamType = streamType;
				this.DirectoryName = dirName;
			}
		}

		private sealed class MergeIntoSingleFileInfo
		{
			public StreamType StreamType { get; private set; }

			public string FileName { get; private set; }

			public MergeIntoSingleFileInfo(StreamType streamType, string fileName)
			{
				this.StreamType = streamType;
				this.FileName = fileName;
			}
		}

		private bool m_bIsInPrintHandler;

		private readonly FileHandler m_fileHandler;

		private readonly FileDragDropHandler m_dragDropHandler;

		private RibbonButton m_btnAppMenu_OpenSample_Invoice;

		private RibbonButton m_btnAppMenu_OpenSample_PackingList;

		private RibbonButton m_btnAppMenu_OpenSample_ShipLabel;

		private RibbonButton m_btnAppMenu_Print_TXITEM_Print;

		private RibbonButton m_btnAppMenu_Print_TXITEM_Print_Quick;

		private RibbonButton m_btnAppMenu_Print_TXITEM_Print_Preview;

		private RibbonButton m_btnUndo;

		private RibbonButton m_btnRedo;

		private readonly UserAccessControl m_UAC;

		private IContainer components;

		private Ribbon m_ribbon;

		private RibbonFormattingTab m_formattingTab;

		private RibbonInsertTab m_insertTab;

		private RibbonTableLayoutTab m_tableLayoutTab;

		private RibbonFormulaTab m_formulaTab;

		private RibbonChartLayoutTab m_chartLayoutTab;

		private TextControl m_textControl;

		private RulerBar m_rulerBarHor;

		private TXTextControl.StatusBar m_statusBar;

		private RulerBar m_rulerBarVert;

		private ContextualTabGroup m_tableToolsGroup;

		private RibbonButton m_btnAppMenu_TXITEM_Open;

		private RibbonMenuButton m_btnAppMenu_OpenSample;

		private RibbonButton m_btnAppMenu_TXITEM_New;

		private RibbonButton m_btnAppMenu_TXITEM_Save;

		private RibbonButton m_btnAppMenu_TXITEM_SaveAs;

		private RibbonSplitButton m_btnAppMenu_TXITEM_Print;

		private RibbonToggleButton m_btnAppMenu_TXITEM_DocumentSettings;

		private RibbonSeperator m_ribbonSeperator1;

		private RibbonButton m_btnAppMenu_TXITEM_Options;

		private RibbonButton m_btnAppMenu_TXITEM_UserAdministration;

		private RibbonButton m_btnAppMenu_TXITEM_GrantUserAccess;

		private RibbonButton m_btnAppMenu_TXITEM_Exit;

		private RibbonLabel m_lblRecentFilesHeader;

		private RibbonSeperator m_ribbonSeperator2;

		private RibbonPageLayoutTab m_pageLayoutTab;

		private RibbonViewTab m_viewTab;

		private RibbonProofingTab m_proofingTab;

		private RibbonPermissionsTab m_permissionsTab;

		private ContextualTabGroup m_frameToolsGroup;

		private RibbonFrameLayoutTab m_frameLayoutTab;

		private RibbonReportingTab m_reportingTab;

		private RibbonFormFieldsTab m_formFieldsTab;

		private RibbonReferencesTab m_referencesTab;

		private ContextualTabGroup m_reportingPreviewGroup;

		private RibbonTab m_previewTab;

		private RibbonButton m_btnAppMenu_TXITEM_About;

		private Sidebar m_horizontalSidebar;

		private Sidebar m_verticalLeftSidebar;

		private Sidebar m_verticalRightSidebar;

		private RibbonGroup TXITEM_FinishGroup;

		private RibbonButton TXITEM_Preview;

		private MergeWaitDialog m_dlgMergeWait;

		private byte[] m_textControlContent;

		private EditMode m_editMode = EditMode.Edit;

		private RibbonGroup m_grpPreview;

		private RibbonButton TXITEM_ClosePreview;

		private RibbonGroup m_grpNavigate;

		private RibbonButton TXITEM_FirstRecord;

		private RibbonButton TXITEM_PreviousRecord;

		private RibbonButton TXITEM_NextRecord;

		private RibbonButton TXITEM_LastRecord;

		private IList<byte[]> m_lstMergedFiles;

		private int m_iPreviewIndex;

		private int m_nPreviewCount;

		private List<Sidebar> m_memorizedShownSidebars = new List<Sidebar>();

		private RibbonButton m_mnuBtnOpenSampleDb;

		private void InitializeAppMenu()
		{
			this.m_btnAppMenu_TXITEM_New.Click += BtnAppMenu_New_Click;
			this.m_btnAppMenu_TXITEM_Open.Click += BtnAppMenu_Open_Click;
			this.m_btnAppMenu_TXITEM_Save.Click += BtnAppMenu_Save_Click;
			this.m_btnAppMenu_TXITEM_SaveAs.Click += BtnAppMenu_SaveAs_Click;
			this.m_btnAppMenu_TXITEM_Print.ButtonClick += BtnAppMenu_Print_ButtonClick;
			this.m_btnAppMenu_TXITEM_DocumentSettings.Click += BtnAppMenu_TXITEM_DocumentSettings_Click;
			this.m_btnAppMenu_TXITEM_Options.Click += BtnAppMenu_Options_Click;
			this.m_btnAppMenu_TXITEM_UserAdministration.Click += BtnAppMenu_UserAdmin_Click;
			this.m_btnAppMenu_TXITEM_GrantUserAccess.Click += BtnAppMenu_UserAccess_Click;
			this.m_btnAppMenu_TXITEM_About.Click += BtnAppMenu_About_Click;
			this.m_btnAppMenu_TXITEM_Exit.Click += BtnAppMenu_Exit_Click;
			this.LocalizeAppMenu();
			this.AddOpenSampleTemplateButtons();
			this.AddPrintButtons();
		}

		private void SetRecentItemsList(StringCollection fileList)
		{
			while (this.m_ribbon.ApplicationMenuHelpPaneItems.Count > 2)
			{
				this.m_ribbon.ApplicationMenuHelpPaneItems.RemoveAt(this.m_ribbon.ApplicationMenuHelpPaneItems.Count - 1);
			}
			int num = 1;
			StringEnumerator enumerator = fileList.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					RibbonButton ribbonButton = new RibbonButton
					{
						Text = num + " " + Path.GetFileName(current),
						Tag = current,
						DisplayMode = IconTextRelation.NoIconLabeled,
						KeyTip = num.ToString()
					};
					ribbonButton.ToolTip.Description = current;
					ribbonButton.Click += BtnRecentItem_Click;
					this.m_ribbon.ApplicationMenuHelpPaneItems.Add(ribbonButton);
					num++;
				}
			}
			finally
			{
				(enumerator as IDisposable)?.Dispose();
			}
		}

		private void AddOpenSampleTemplateButtons()
		{
			this.m_btnAppMenu_OpenSample_Invoice = new RibbonButton
			{
				DisplayMode = IconTextRelation.NoIconLabeled,
				Text = Resources.APP_MENU_OPEN_SAMPLE_INVOICE,
				Tag = SampleTemplateType.Invoice,
				KeyTip = "1"
			};
			this.m_btnAppMenu_OpenSample_Invoice.Click += BtnOpenSampleTemplate_Click;
			this.m_btnAppMenu_OpenSample_PackingList = new RibbonButton
			{
				DisplayMode = IconTextRelation.NoIconLabeled,
				Text = Resources.APP_MENU_OPEN_SAMPLE_PACK_LST,
				Tag = SampleTemplateType.PackingList,
				KeyTip = "2"
			};
			this.m_btnAppMenu_OpenSample_PackingList.Click += BtnOpenSampleTemplate_Click;
			this.m_btnAppMenu_OpenSample_ShipLabel = new RibbonButton
			{
				DisplayMode = IconTextRelation.NoIconLabeled,
				Text = Resources.APP_MENU_OPEN_SAMPLE_SHIP_LBL,
				Tag = SampleTemplateType.ShippingLabel,
				KeyTip = "3"
			};
			this.m_btnAppMenu_OpenSample_ShipLabel.Click += BtnOpenSampleTemplate_Click;
			RibbonItemCollection dropDownItems = this.m_btnAppMenu_OpenSample.DropDownItems;
			Control[] items = new RibbonButton[3] { this.m_btnAppMenu_OpenSample_Invoice, this.m_btnAppMenu_OpenSample_PackingList, this.m_btnAppMenu_OpenSample_ShipLabel };
			dropDownItems.AddRange(items);
		}

		private void AddPrintButtons()
		{
			this.m_btnAppMenu_Print_TXITEM_Print = new RibbonButton
			{
				Name = "m_appMenu_TXITEM_Print"
			};
			this.m_btnAppMenu_Print_TXITEM_Print.Click += BtnAppMenu_Print_ButtonClick;
			this.m_btnAppMenu_Print_TXITEM_Print.Apply(ResourceProvider.FileMenuItem.TXITEM_Print.ToString(), base.DeviceDpi);
			this.m_btnAppMenu_Print_TXITEM_Print_Quick = new RibbonButton
			{
				Name = "m_appMenu_TXITEM_Print_Quick"
			};
			this.m_btnAppMenu_Print_TXITEM_Print_Quick.Click += BtnPrintQuick_Click;
			this.m_btnAppMenu_Print_TXITEM_Print_Quick.Apply(ResourceProvider.FileMenuItem.TXITEM_PrintQuick.ToString(), base.DeviceDpi);
			this.m_btnAppMenu_Print_TXITEM_Print_Preview = new RibbonButton
			{
				Name = "m_appMenu_TXITEM_Print_Preview"
			};
			this.m_btnAppMenu_Print_TXITEM_Print_Preview.Click += BtnPrintPreview_Click;
			this.m_btnAppMenu_Print_TXITEM_Print_Preview.Apply(ResourceProvider.FileMenuItem.TXITEM_PrintPreview.ToString(), base.DeviceDpi);
			RibbonItemCollection dropDownItems = this.m_btnAppMenu_TXITEM_Print.DropDownItems;
			Control[] items = new RibbonButton[3] { this.m_btnAppMenu_Print_TXITEM_Print, this.m_btnAppMenu_Print_TXITEM_Print_Quick, this.m_btnAppMenu_Print_TXITEM_Print_Preview };
			dropDownItems.AddRange(items);
		}

		private void LocalizeAppMenu()
		{
			this.m_btnAppMenu_TXITEM_New.Apply(ResourceProvider.FileMenuItem.TXITEM_New.ToString(), base.DeviceDpi);
			this.m_btnAppMenu_TXITEM_Open.Apply(ResourceProvider.FileMenuItem.TXITEM_Open.ToString(), base.DeviceDpi);
			this.m_btnAppMenu_TXITEM_Save.Apply(ResourceProvider.FileMenuItem.TXITEM_Save.ToString(), base.DeviceDpi);
			this.m_btnAppMenu_TXITEM_SaveAs.Apply(ResourceProvider.FileMenuItem.TXITEM_SaveAs.ToString(), base.DeviceDpi);
			this.m_btnAppMenu_TXITEM_Print.Apply(ResourceProvider.FileMenuItem.TXITEM_Print.ToString(), base.DeviceDpi);
			this.m_btnAppMenu_TXITEM_DocumentSettings.Apply(ResourceProvider.FileMenuItem.TXITEM_DocumentSettings.ToString(), base.DeviceDpi);
			this.m_btnAppMenu_TXITEM_Options.Apply(ResourceProvider.FileMenuItem.TXITEM_Options.ToString(), base.DeviceDpi);
			this.m_btnAppMenu_TXITEM_UserAdministration.Apply(ResourceProvider.FileMenuItem.TXITEM_UserAdministration.ToString(), base.DeviceDpi);
			this.m_btnAppMenu_TXITEM_GrantUserAccess.Apply(ResourceProvider.FileMenuItem.TXITEM_GrantUserAccess.ToString(), base.DeviceDpi);
			this.m_btnAppMenu_TXITEM_About.Apply(ResourceProvider.FileMenuItem.TXITEM_About.ToString(), base.DeviceDpi);
			this.m_btnAppMenu_TXITEM_Exit.Apply(ResourceProvider.FileMenuItem.TXITEM_Exit.ToString(), base.DeviceDpi);
			this.m_lblRecentFilesHeader.Text = Resources.APP_MENU_RECENT_ITEMS_HEADER;
			this.m_btnAppMenu_OpenSample.Text = Resources.APP_MENU_OPEN_SAMPLE;
			this.m_btnAppMenu_OpenSample.SmallIcon = Images.GetSmallIcon("OpenDemo");
			this.m_btnAppMenu_OpenSample.LargeIcon = Images.GetLargeIcon("OpenDemo");
		}

		private void BtnAppMenu_New_Click(object sender, EventArgs e)
		{
			this.m_fileHandler.New();
		}

		private void BtnAppMenu_Exit_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void BtnAppMenu_About_Click(object sender, EventArgs e)
		{
			AboutBox.Show(this, this.m_textControl.GetVersionInfo());
		}

		private void BtnAppMenu_Options_Click(object sender, EventArgs e)
		{
			OptionsDialog optionsDialog = new OptionsDialog(this.m_textControl, this.m_fileHandler);
			optionsDialog.RightToLeft = this.RightToLeft;
			optionsDialog.ShowDialog(this);
		}

		private void BtnAppMenu_UserAdmin_Click(object sender, EventArgs e)
		{
			this.m_UAC.ShowUserAdminDialog(this);
		}

		private void BtnAppMenu_UserAccess_Click(object sender, EventArgs e)
		{
			this.m_UAC.ShowUserAccessDialog(this);
		}

		private void BtnAppMenu_SaveAs_Click(object sender, EventArgs e)
		{
			this.m_fileHandler.SaveAs();
		}

		private void BtnAppMenu_Save_Click(object sender, EventArgs e)
		{
			this.m_fileHandler.Save();
		}

		private void BtnAppMenu_Open_Click(object sender, EventArgs e)
		{
			this.m_fileHandler.Open();
		}

		private void BtnOpenSampleTemplate_Click(object sender, EventArgs e)
		{
			string text = "";
			string directoryName = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
			RibbonButton ribbonButton = sender as RibbonButton;
			if (ribbonButton != null)
			{
				switch ((SampleTemplateType)ribbonButton.Tag)
				{
				case SampleTemplateType.Invoice:
					text = directoryName + "\\..\\invoice.docx";
					break;
				case SampleTemplateType.PackingList:
					text = directoryName + "\\..\\shippinglabel.docx";
					break;
				case SampleTemplateType.ShippingLabel:
					text = directoryName + "\\..\\packinglist.docx";
					break;
				}
				if (!string.IsNullOrEmpty(text))
				{
					this.m_fileHandler.Open(text);
				}
			}
		}

		private void BtnRecentItem_Click(object sender, EventArgs e)
		{
			RibbonButton ribbonButton = sender as RibbonButton;
			if (ribbonButton != null)
			{
				string fileName = (string)ribbonButton.Tag;
				this.m_fileHandler.OpenRecentFile(fileName);
			}
		}

		private void BtnAppMenu_TXITEM_DocumentSettings_Click(object sender, EventArgs e)
		{
			if (this.m_btnAppMenu_TXITEM_DocumentSettings.Checked)
			{
				this.m_verticalLeftSidebar.IsShown = true;
				this.m_verticalLeftSidebar.ContentLayout = Sidebar.SidebarContentLayout.DocumentSettings;
			}
			else
			{
				this.m_verticalLeftSidebar.IsShown = false;
			}
		}

		private void BtnAppMenu_Print_ButtonClick(object sender, EventArgs e)
		{
			this.Print();
		}

		private void BtnPrintPreview_Click(object sender, EventArgs e)
		{
			this.PrintPreview();
		}

		private void BtnPrintQuick_Click(object sender, EventArgs e)
		{
			this.PrintQuick();
		}

		private void Print()
		{
			if (!this.m_bIsInPrintHandler)
			{
				this.m_bIsInPrintHandler = true;
				this.m_textControl.Print(this.m_fileHandler.DocumentTitle + " - " + base.ProductName);
				this.m_bIsInPrintHandler = false;
			}
		}

		private void PrintPreview()
		{
			this.m_textControl.PrintPreview(this.m_fileHandler.DocumentTitle + " - " + base.ProductName);
		}

		private void PrintQuick()
		{
			this.m_textControl.Print(new PrintDocument
			{
				PrinterSettings = new PrinterSettings
				{
					FromPage = 1,
					ToPage = this.m_textControl.Pages,
					Copies = 1,
					Collate = true,
					PrintFileName = this.m_fileHandler.DocumentTitle + " - " + base.ProductName
				}
			});
		}

		private void AddFieldContextMenuItems(ContextMenuStrip contextMenuStrip)
		{
			if (this.m_textControl.ApplicationFields.GetItem() != null)
			{
				contextMenuStrip.Items.Add(new ToolStripSeparator());
				string identifier = RibbonReportingTab.RibbonItem.TXITEM_FieldProperties.ToString();
				ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(ResourceProvider.GetText(identifier), ResourceProvider.GetSmallIcon(identifier, base.DeviceDpi))
				{
					Enabled = this.m_textControl.CanEdit
				};
				toolStripMenuItem.Click += MnuItm_Properties_Click;
				contextMenuStrip.Items.Add(toolStripMenuItem);
				string identifier2 = RibbonReportingTab.RibbonItem.TXITEM_DeleteField.ToString();
				ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem(ResourceProvider.GetText(identifier2), ResourceProvider.GetSmallIcon(identifier2, base.DeviceDpi))
				{
					Enabled = this.m_textControl.CanEdit
				};
				toolStripMenuItem2.Click += MnuItm_Delete_Click;
				contextMenuStrip.Items.Add(toolStripMenuItem2);
			}
		}

		private void MnuItm_Properties_Click(object sender, EventArgs e)
		{
			this.FieldSettings();
		}

		private void MnuItm_Delete_Click(object sender, EventArgs e)
		{
			this.DeleteField();
		}

		private void DeleteField()
		{
			ApplicationField item = this.m_textControl.ApplicationFields.GetItem();
			if (item != null)
			{
				this.m_textControl.ApplicationFields.Remove(item);
			}
		}

		private void FieldSettings()
		{
			bool rightToLeft = this.RightToLeft == RightToLeft.Yes;
			try
			{
				ApplicationField item = this.m_textControl.ApplicationFields.GetItem();
				switch (item.TypeName)
				{
				case "MERGEFIELD":
					new MergeField(item).ShowDialog(this, rightToLeft);
					break;
				case "DATE":
					new DateField(item).ShowDialog(this, rightToLeft);
					break;
				case "INCLUDETEXT":
					new IncludeText(item).ShowDialog(this, rightToLeft);
					break;
				case "IF":
					new IfField(item).ShowDialog(this, rightToLeft);
					break;
				case "NEXTIF":
					new NextIfField(item).ShowDialog(this, rightToLeft);
					break;
				}
			}
			catch
			{
			}
		}

		private void FileHandler_ShowMessageBox(object sender, ShowMessageBoxEventArgs e)
		{
			string caption = e.Caption ?? base.ProductName;
			System.Windows.Forms.DialogResult res = TX_Text_Control_Words.Utils.MessageBox.Show(this, e.Text, caption, e.Button.ToWinFormsButton(), e.Icon.ToWinFormsIcon());
			e.DialogResult = res.ToFileHandlerDialogResult();
		}

		private void FileHandler_DocumentDirtyChanged(object sender, DocumentDirtyChangedEventArgs e)
		{
			this.SetWindowTitle(this.m_fileHandler.DocumentTitle, e.NewValue);
		}

		private void FileHandler_PropertyChanged_SetButtonStates(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "CanSave")
			{
				this.m_btnAppMenu_TXITEM_Save.Enabled = !this.m_fileHandler.CanSave;
				this.m_btnAppMenu_TXITEM_Save.Enabled = this.m_fileHandler.CanSave;
			}
		}

		private void FileHandler_DocumentFileNameChanged(object sender, DocumentFileNameChangedEventArgs e)
		{
			this.SetWindowTitle(this.m_fileHandler.DocumentTitle, this.m_fileHandler.IsDocumentDirty);
		}

		private void FileHandler_RecentFileListChanged(object sender, EventArgs e)
		{
			this.SetRecentItemsList(this.m_fileHandler.RecentFiles);
		}

		private void FileHandler_UserInputRequested(object sender, UserInputRequestedEventArgs e)
		{
			UserPromptDialog userPromptDialog = new UserPromptDialog(e.Caption, e.Label, e.Value);
			userPromptDialog.RightToLeft = this.RightToLeft;
			userPromptDialog.IsPassword = e.IsPasswordRequest;
			if (userPromptDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				e.DialogResult = TX_Text_Control_Words.FileHandling.DialogResult.OK;
				e.Value = userPromptDialog.Value;
			}
		}

		public MainWindow()
		{
			this.InitializeComponent();
			base.Icon = new Icon(typeof(MainWindow), "Icons.tx.ico");
			this.m_fileHandler = new FileHandler(this.m_textControl)
			{
				MaxRecentFiles = Settings.Default.RecentFilesMaxItemCount
			};
			this.m_fileHandler.ShowMessageBox += FileHandler_ShowMessageBox;
			this.m_fileHandler.DocumentDirtyChanged += FileHandler_DocumentDirtyChanged;
			this.m_fileHandler.DocumentFileNameChanged += FileHandler_DocumentFileNameChanged;
			this.m_fileHandler.RecentFileListChanged += FileHandler_RecentFileListChanged;
			this.m_fileHandler.UserInputRequested += FileHandler_UserInputRequested;
			this.m_fileHandler.PropertyChanged += FileHandler_PropertyChanged_SetButtonStates;
			this.m_dragDropHandler = new FileDragDropHandler();
			Color color = Color.FromArgb(255, 245, 246, 247);
			this.m_rulerBarHor.DisplayColors.GradientBackColor = color;
			this.m_rulerBarHor.DisplayColors.BackColor = color;
			this.m_rulerBarVert.DisplayColors.GradientBackColor = color;
			this.m_rulerBarVert.DisplayColors.BackColor = color;
			this.SetStatusBarColor(Color.FromArgb(255, 43, 86, 154));
			this.m_UAC = new UserAccessControl(this.m_textControl);
			this.m_UAC.KnownUsers.CollectionChanged += KnownUsers_CollectionChanged;
			this.LocalizeWindow();
			this.SetWindowTitle(this.m_fileHandler.DocumentTitle);
			this.LoadAppSettings();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.ActiveControl = this.m_textControl;
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			if (commandLineArgs.Length > 1)
			{
				this.m_fileHandler.Open(commandLineArgs[1]);
			}
			this.InitializeRibbon();
			base.OnLoad(e);
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			e.Cancel = !this.m_fileHandler.ExitApplication();
			if (!e.Cancel)
			{
				this.SaveAppSettings();
			}
			base.OnFormClosing(e);
		}

		protected override void OnDpiChanged(DpiChangedEventArgs e)
		{
			this.m_btnAppMenu_TXITEM_New.Apply(ResourceProvider.FileMenuItem.TXITEM_New.ToString(), e.DeviceDpiNew, RibbonButtonExtensions.RibbonButtonResource.ImageSources);
			this.m_btnAppMenu_TXITEM_Open.Apply(ResourceProvider.FileMenuItem.TXITEM_Open.ToString(), e.DeviceDpiNew, RibbonButtonExtensions.RibbonButtonResource.ImageSources);
			this.m_btnAppMenu_TXITEM_Save.Apply(ResourceProvider.FileMenuItem.TXITEM_Save.ToString(), e.DeviceDpiNew, RibbonButtonExtensions.RibbonButtonResource.ImageSources);
			this.m_btnAppMenu_TXITEM_SaveAs.Apply(ResourceProvider.FileMenuItem.TXITEM_SaveAs.ToString(), e.DeviceDpiNew, RibbonButtonExtensions.RibbonButtonResource.ImageSources);
			this.m_btnAppMenu_TXITEM_Print.Apply(ResourceProvider.FileMenuItem.TXITEM_Print.ToString(), e.DeviceDpiNew, RibbonButtonExtensions.RibbonButtonResource.ImageSources);
			this.m_btnAppMenu_Print_TXITEM_Print.Apply(ResourceProvider.FileMenuItem.TXITEM_Print.ToString(), e.DeviceDpiNew, RibbonButtonExtensions.RibbonButtonResource.ImageSources);
			this.m_btnAppMenu_Print_TXITEM_Print_Quick.Apply(ResourceProvider.FileMenuItem.TXITEM_PrintQuick.ToString(), e.DeviceDpiNew, RibbonButtonExtensions.RibbonButtonResource.ImageSources);
			this.m_btnAppMenu_Print_TXITEM_Print_Preview.Apply(ResourceProvider.FileMenuItem.TXITEM_PrintPreview.ToString(), e.DeviceDpiNew, RibbonButtonExtensions.RibbonButtonResource.ImageSources);
			this.m_btnAppMenu_TXITEM_DocumentSettings.Apply(ResourceProvider.FileMenuItem.TXITEM_DocumentSettings.ToString(), e.DeviceDpiNew, RibbonButtonExtensions.RibbonButtonResource.ImageSources);
			this.m_btnAppMenu_TXITEM_Options.Apply(ResourceProvider.FileMenuItem.TXITEM_Options.ToString(), e.DeviceDpiNew, RibbonButtonExtensions.RibbonButtonResource.ImageSources);
			this.m_btnAppMenu_TXITEM_UserAdministration.Apply(ResourceProvider.FileMenuItem.TXITEM_UserAdministration.ToString(), e.DeviceDpiNew, RibbonButtonExtensions.RibbonButtonResource.ImageSources);
			this.m_btnAppMenu_TXITEM_GrantUserAccess.Apply(ResourceProvider.FileMenuItem.TXITEM_GrantUserAccess.ToString(), e.DeviceDpiNew, RibbonButtonExtensions.RibbonButtonResource.ImageSources);
			this.m_btnAppMenu_TXITEM_About.Apply(ResourceProvider.FileMenuItem.TXITEM_About.ToString(), e.DeviceDpiNew, RibbonButtonExtensions.RibbonButtonResource.ImageSources);
			this.m_btnAppMenu_TXITEM_Exit.Apply(ResourceProvider.FileMenuItem.TXITEM_Exit.ToString(), e.DeviceDpiNew, RibbonButtonExtensions.RibbonButtonResource.ImageSources);
			this.m_grpPreview.LargeIcon = ResourceProvider.GetSmallIcon(ResourceProvider.FileMenuItem.TXITEM_Exit.ToString(), base.DeviceDpi);
			this.m_grpPreview.SmallIcon = ResourceProvider.GetSmallIcon(ResourceProvider.FileMenuItem.TXITEM_Exit.ToString(), base.DeviceDpi);
			this.TXITEM_ClosePreview.Apply(ResourceProvider.FileMenuItem.TXITEM_Exit.ToString(), base.DeviceDpi, RibbonButtonExtensions.RibbonButtonResource.ImageSources);
			this.TXITEM_FirstRecord.Apply(ResourceProvider.GeneralItem.TXITEM_NavigateToFirst.ToString(), base.DeviceDpi, RibbonButtonExtensions.RibbonButtonResource.ImageSources);
			this.TXITEM_PreviousRecord.Apply(ResourceProvider.GeneralItem.TXITEM_NavigateToPrevious.ToString(), base.DeviceDpi, RibbonButtonExtensions.RibbonButtonResource.ImageSources);
			this.TXITEM_NextRecord.Apply(ResourceProvider.GeneralItem.TXITEM_NavigateToNext.ToString(), base.DeviceDpi, RibbonButtonExtensions.RibbonButtonResource.ImageSources);
			this.TXITEM_LastRecord.Apply(ResourceProvider.GeneralItem.TXITEM_NavigateToLast.ToString(), base.DeviceDpi, RibbonButtonExtensions.RibbonButtonResource.ImageSources);
			this.m_btnRedo.Apply(ResourceProvider.GeneralItem.TXITEM_Redo.ToString(), base.DeviceDpi, RibbonButtonExtensions.RibbonButtonResource.SmallImageSource);
			this.m_btnUndo.Apply(ResourceProvider.GeneralItem.TXITEM_Undo.ToString(), base.DeviceDpi, RibbonButtonExtensions.RibbonButtonResource.SmallImageSource);
			base.OnDpiChanged(e);
		}

		private void KnownUsers_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			this.m_permissionsTab.RegisteredUserNames = this.m_UAC.KnownUsers.Select((UserInfo ui) => ui.Name).ToArray();
		}

		private void LocalizeWindow()
		{
			this.m_statusBar.LineText = Resources.STATUSBAR_LINE;
			this.m_statusBar.PageText = Resources.STATUSBAR_PAGE;
			this.m_statusBar.ColumnText = Resources.STATUSBAR_COLUMN;
			this.m_statusBar.SectionText = Resources.STATUSBAR_SECTION;
			this.m_tableToolsGroup.Header = Resources.CONT_TAB_GRP_TBL_TOOLS;
			this.m_frameToolsGroup.Header = Resources.CONT_TAB_GRP_FRAME_TOOLS;
			this.m_frameLayoutTab.Text = Resources.RIBBON_TAB_FRAME_FORMAT_HEADER;
			this.m_tableLayoutTab.Text = Resources.RIBBON_TAB_TABLE_FORMAT_HEADER;
			this.m_chartLayoutTab.Text = Resources.RIBBON_TAB_CHART_FORMAT_HEADER;
		}

		private void LoadAppSettings()
		{
			if (Settings.Default.KnownUsers != null)
			{
				this.m_UAC.KnownUsers.Set(Settings.Default.KnownUsers);
			}
			this.m_fileHandler.RecentFiles = Settings.Default.RecentFiles;
			this.RightToLeft = Settings.Default.RightToLeft;
			switch (this.RightToLeft)
			{
			case RightToLeft.No:
				this.RightToLeftLayout = false;
				this.m_ribbon.RightToLeftLayout = false;
				this.m_rulerBarVert.Dock = DockStyle.Left;
				break;
			case RightToLeft.Yes:
				this.RightToLeftLayout = true;
				this.m_ribbon.RightToLeftLayout = true;
				this.m_rulerBarVert.Dock = DockStyle.Right;
				break;
			}
		}

		private void SaveAppSettings()
		{
			Settings.Default.RecentFiles = this.m_fileHandler.RecentFiles;
			Settings.Default.KnownUsers = this.m_UAC.KnownUsers.ToList().ConvertAll((UserInfo ui) => new UserInfo(ui)
			{
				AccessGranted = false
			});
			Settings.Default.Save();
		}

		private void SetWindowTitle(string documentTitle, bool isDocumentDirty = false)
		{
			string arg = (isDocumentDirty ? "*" : "");
			string text2 = (this.Text = $"{documentTitle}{arg} - {base.ProductName}");
			this.Refresh();
		}

		private void SetStatusBarColor(Color col)
		{
			this.m_statusBar.DisplayColors.BackColorBottom = col;
			this.m_statusBar.DisplayColors.BackColorMiddle = col;
			this.m_statusBar.DisplayColors.BackColorTop = col;
			this.m_statusBar.DisplayColors.FrameColor = col;
			this.m_statusBar.DisplayColors.SeparatorColorLight = col;
			this.m_statusBar.DisplayColors.ForeColor = Color.White;
			this.m_statusBar.DisplayColors.SeparatorColorDark = Color.White;
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.m_ribbon = new TXTextControl.Windows.Forms.Ribbon.Ribbon();
            this.m_lblRecentFilesHeader = new TXTextControl.Windows.Forms.Ribbon.RibbonLabel();
            this.m_ribbonSeperator2 = new TXTextControl.Windows.Forms.Ribbon.RibbonSeperator();
            this.m_btnAppMenu_TXITEM_New = new TXTextControl.Windows.Forms.Ribbon.RibbonButton();
            this.m_btnAppMenu_TXITEM_Open = new TXTextControl.Windows.Forms.Ribbon.RibbonButton();
            this.m_btnAppMenu_OpenSample = new TXTextControl.Windows.Forms.Ribbon.RibbonMenuButton();
            this.m_btnAppMenu_TXITEM_Save = new TXTextControl.Windows.Forms.Ribbon.RibbonButton();
            this.m_btnAppMenu_TXITEM_SaveAs = new TXTextControl.Windows.Forms.Ribbon.RibbonButton();
            this.m_btnAppMenu_TXITEM_Print = new TXTextControl.Windows.Forms.Ribbon.RibbonSplitButton();
            this.m_btnAppMenu_TXITEM_DocumentSettings = new TXTextControl.Windows.Forms.Ribbon.RibbonToggleButton();
            this.m_ribbonSeperator1 = new TXTextControl.Windows.Forms.Ribbon.RibbonSeperator();
            this.m_btnAppMenu_TXITEM_Options = new TXTextControl.Windows.Forms.Ribbon.RibbonButton();
            this.m_btnAppMenu_TXITEM_UserAdministration = new TXTextControl.Windows.Forms.Ribbon.RibbonButton();
            this.m_btnAppMenu_TXITEM_GrantUserAccess = new TXTextControl.Windows.Forms.Ribbon.RibbonButton();
            this.m_btnAppMenu_TXITEM_About = new TXTextControl.Windows.Forms.Ribbon.RibbonButton();
            this.m_btnAppMenu_TXITEM_Exit = new TXTextControl.Windows.Forms.Ribbon.RibbonButton();
            this.m_tableToolsGroup = new TXTextControl.Windows.Forms.Ribbon.ContextualTabGroup();
            this.m_tableLayoutTab = new TXTextControl.Windows.Forms.Ribbon.RibbonTableLayoutTab();
            this.m_formulaTab = new TXTextControl.Windows.Forms.Ribbon.RibbonFormulaTab();
            this.m_frameToolsGroup = new TXTextControl.Windows.Forms.Ribbon.ContextualTabGroup();
            this.m_frameLayoutTab = new TXTextControl.Windows.Forms.Ribbon.RibbonFrameLayoutTab();
            this.m_reportingPreviewGroup = new TXTextControl.Windows.Forms.Ribbon.ContextualTabGroup();
            this.m_previewTab = new TXTextControl.Windows.Forms.Ribbon.RibbonTab();
            this.m_formattingTab = new TXTextControl.Windows.Forms.Ribbon.RibbonFormattingTab();
            this.m_horizontalSidebar = new TXTextControl.Windows.Forms.Sidebar();
            this.m_textControl = new TXTextControl.TextControl();
            this.m_rulerBarHor = new TXTextControl.RulerBar();
            this.m_statusBar = new TXTextControl.StatusBar();
            this.m_rulerBarVert = new TXTextControl.RulerBar();
            this.m_verticalRightSidebar = new TXTextControl.Windows.Forms.Sidebar();
            this.m_insertTab = new TXTextControl.Windows.Forms.Ribbon.RibbonInsertTab();
            this.m_pageLayoutTab = new TXTextControl.Windows.Forms.Ribbon.RibbonPageLayoutTab();
            this.m_viewTab = new TXTextControl.Windows.Forms.Ribbon.RibbonViewTab();
            this.m_referencesTab = new TXTextControl.Windows.Forms.Ribbon.RibbonReferencesTab();
            this.m_proofingTab = new TXTextControl.Windows.Forms.Ribbon.RibbonProofingTab();
            this.m_verticalLeftSidebar = new TXTextControl.Windows.Forms.Sidebar();
            this.m_permissionsTab = new TXTextControl.Windows.Forms.Ribbon.RibbonPermissionsTab();
            this.m_formFieldsTab = new TXTextControl.Windows.Forms.Ribbon.RibbonFormFieldsTab();
            this.m_reportingTab = new TXTextControl.Windows.Forms.Ribbon.RibbonReportingTab();
            this.m_chartLayoutTab = new TXTextControl.Windows.Forms.Ribbon.RibbonChartLayoutTab();
            this.m_ribbon.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_ribbon
            // 
            this.m_ribbon.Appearance = System.Windows.Forms.TabAppearance.Buttons;
            this.m_ribbon.ApplicationMenuHelpPaneItems.AddRange(new System.Windows.Forms.Control[] {
            this.m_lblRecentFilesHeader,
            this.m_ribbonSeperator2});
            this.m_ribbon.ApplicationMenuItems.AddRange(new System.Windows.Forms.Control[] {
            this.m_btnAppMenu_TXITEM_New,
            this.m_btnAppMenu_TXITEM_Open,
            this.m_btnAppMenu_OpenSample,
            this.m_btnAppMenu_TXITEM_Save,
            this.m_btnAppMenu_TXITEM_SaveAs,
            this.m_btnAppMenu_TXITEM_Print,
            this.m_btnAppMenu_TXITEM_DocumentSettings,
            this.m_ribbonSeperator1,
            this.m_btnAppMenu_TXITEM_Options,
            this.m_btnAppMenu_TXITEM_UserAdministration,
            this.m_btnAppMenu_TXITEM_GrantUserAccess,
            this.m_btnAppMenu_TXITEM_About,
            this.m_btnAppMenu_TXITEM_Exit});
            this.m_ribbon.ContextualTabGroups.Add(this.m_tableToolsGroup);
            this.m_ribbon.ContextualTabGroups.Add(this.m_frameToolsGroup);
            this.m_ribbon.ContextualTabGroups.Add(this.m_reportingPreviewGroup);
            this.m_ribbon.Controls.Add(this.m_formattingTab);
            this.m_ribbon.Controls.Add(this.m_insertTab);
            this.m_ribbon.Controls.Add(this.m_pageLayoutTab);
            this.m_ribbon.Controls.Add(this.m_viewTab);
            this.m_ribbon.Controls.Add(this.m_referencesTab);
            this.m_ribbon.Controls.Add(this.m_proofingTab);
            this.m_ribbon.Controls.Add(this.m_permissionsTab);
            this.m_ribbon.Controls.Add(this.m_formFieldsTab);
            this.m_ribbon.Controls.Add(this.m_reportingTab);
            this.m_ribbon.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_ribbon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.m_ribbon.HotTrack = true;
            this.m_ribbon.Location = new System.Drawing.Point(0, 30);
            this.m_ribbon.Name = "m_ribbon";
            this.m_ribbon.SelectedIndex = 1;
            this.m_ribbon.Size = new System.Drawing.Size(1000, 121);
            this.m_ribbon.TabIndex = 1;
            this.m_ribbon.TextControl_0 = this.m_textControl;
            this.m_ribbon.SelectedIndexChanged += new System.EventHandler(this.Ribbon_TabIndexChanged);
            // 
            // m_lblRecentFilesHeader
            // 
            this.m_lblRecentFilesHeader.BackColor = System.Drawing.Color.Transparent;
            this.m_lblRecentFilesHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lblRecentFilesHeader.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.m_lblRecentFilesHeader.Location = new System.Drawing.Point(0, 0);
            this.m_lblRecentFilesHeader.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.m_lblRecentFilesHeader.Name = "m_lblRecentFilesHeader";
            this.m_lblRecentFilesHeader.Size = new System.Drawing.Size(191, 24);
            this.m_lblRecentFilesHeader.TabIndex = 0;
            this.m_lblRecentFilesHeader.TabStop = false;
            this.m_lblRecentFilesHeader.Text = "Recent Files";
            // 
            // m_ribbonSeperator2
            // 
            this.m_ribbonSeperator2.BackColor = System.Drawing.Color.Transparent;
            this.m_ribbonSeperator2.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_ribbonSeperator2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.m_ribbonSeperator2.Location = new System.Drawing.Point(0, 24);
            this.m_ribbonSeperator2.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.m_ribbonSeperator2.MinimumSize = new System.Drawing.Size(0, 5);
            this.m_ribbonSeperator2.Name = "m_ribbonSeperator2";
            this.m_ribbonSeperator2.Size = new System.Drawing.Size(191, 5);
            this.m_ribbonSeperator2.TabIndex = 0;
            this.m_ribbonSeperator2.TabStop = false;
            this.m_ribbonSeperator2.Text = "ribbonSeperator2";
            // 
            // m_btnAppMenu_TXITEM_New
            // 
            this.m_btnAppMenu_TXITEM_New.BackColor = System.Drawing.Color.Transparent;
            this.m_btnAppMenu_TXITEM_New.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_btnAppMenu_TXITEM_New.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.m_btnAppMenu_TXITEM_New.KeyTip = "N";
            this.m_btnAppMenu_TXITEM_New.Location = new System.Drawing.Point(0, 0);
            this.m_btnAppMenu_TXITEM_New.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.m_btnAppMenu_TXITEM_New.Name = "m_btnAppMenu_TXITEM_New";
            this.m_btnAppMenu_TXITEM_New.Size = new System.Drawing.Size(197, 38);
            this.m_btnAppMenu_TXITEM_New.TabIndex = 0;
            this.m_btnAppMenu_TXITEM_New.Text = "New";
            // 
            // m_btnAppMenu_TXITEM_Open
            // 
            this.m_btnAppMenu_TXITEM_Open.BackColor = System.Drawing.Color.Transparent;
            this.m_btnAppMenu_TXITEM_Open.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_btnAppMenu_TXITEM_Open.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.m_btnAppMenu_TXITEM_Open.KeyTip = "E";
            this.m_btnAppMenu_TXITEM_Open.Location = new System.Drawing.Point(0, 38);
            this.m_btnAppMenu_TXITEM_Open.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.m_btnAppMenu_TXITEM_Open.Name = "m_btnAppMenu_TXITEM_Open";
            this.m_btnAppMenu_TXITEM_Open.Size = new System.Drawing.Size(197, 38);
            this.m_btnAppMenu_TXITEM_Open.TabIndex = 0;
            this.m_btnAppMenu_TXITEM_Open.Text = "Open…";
            // 
            // m_btnAppMenu_OpenSample
            // 
            this.m_btnAppMenu_OpenSample.BackColor = System.Drawing.Color.Transparent;
            this.m_btnAppMenu_OpenSample.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_btnAppMenu_OpenSample.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.m_btnAppMenu_OpenSample.KeyTip = "T";
            this.m_btnAppMenu_OpenSample.Location = new System.Drawing.Point(0, 76);
            this.m_btnAppMenu_OpenSample.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.m_btnAppMenu_OpenSample.Name = "m_btnAppMenu_OpenSample";
            this.m_btnAppMenu_OpenSample.Size = new System.Drawing.Size(197, 38);
            this.m_btnAppMenu_OpenSample.TabIndex = 0;
            this.m_btnAppMenu_OpenSample.Text = "Open Sample Template";
            // 
            // m_btnAppMenu_TXITEM_Save
            // 
            this.m_btnAppMenu_TXITEM_Save.BackColor = System.Drawing.Color.Transparent;
            this.m_btnAppMenu_TXITEM_Save.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_btnAppMenu_TXITEM_Save.Enabled = false;
            this.m_btnAppMenu_TXITEM_Save.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.m_btnAppMenu_TXITEM_Save.KeyTip = "S";
            this.m_btnAppMenu_TXITEM_Save.Location = new System.Drawing.Point(0, 114);
            this.m_btnAppMenu_TXITEM_Save.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.m_btnAppMenu_TXITEM_Save.Name = "m_btnAppMenu_TXITEM_Save";
            this.m_btnAppMenu_TXITEM_Save.Size = new System.Drawing.Size(197, 38);
            this.m_btnAppMenu_TXITEM_Save.TabIndex = 0;
            this.m_btnAppMenu_TXITEM_Save.Text = "Save…";
            // 
            // m_btnAppMenu_TXITEM_SaveAs
            // 
            this.m_btnAppMenu_TXITEM_SaveAs.BackColor = System.Drawing.Color.Transparent;
            this.m_btnAppMenu_TXITEM_SaveAs.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_btnAppMenu_TXITEM_SaveAs.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.m_btnAppMenu_TXITEM_SaveAs.KeyTip = "A";
            this.m_btnAppMenu_TXITEM_SaveAs.Location = new System.Drawing.Point(0, 152);
            this.m_btnAppMenu_TXITEM_SaveAs.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.m_btnAppMenu_TXITEM_SaveAs.Name = "m_btnAppMenu_TXITEM_SaveAs";
            this.m_btnAppMenu_TXITEM_SaveAs.Size = new System.Drawing.Size(197, 38);
            this.m_btnAppMenu_TXITEM_SaveAs.TabIndex = 0;
            this.m_btnAppMenu_TXITEM_SaveAs.Text = "Save As…";
            // 
            // m_btnAppMenu_TXITEM_Print
            // 
            this.m_btnAppMenu_TXITEM_Print.BackColor = System.Drawing.Color.Transparent;
            this.m_btnAppMenu_TXITEM_Print.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_btnAppMenu_TXITEM_Print.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.m_btnAppMenu_TXITEM_Print.KeyTip = "P";
            this.m_btnAppMenu_TXITEM_Print.Location = new System.Drawing.Point(0, 190);
            this.m_btnAppMenu_TXITEM_Print.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.m_btnAppMenu_TXITEM_Print.Name = "m_btnAppMenu_TXITEM_Print";
            this.m_btnAppMenu_TXITEM_Print.Size = new System.Drawing.Size(197, 38);
            this.m_btnAppMenu_TXITEM_Print.TabIndex = 0;
            this.m_btnAppMenu_TXITEM_Print.Text = "Print…";
            // 
            // m_btnAppMenu_TXITEM_DocumentSettings
            // 
            this.m_btnAppMenu_TXITEM_DocumentSettings.BackColor = System.Drawing.Color.Transparent;
            this.m_btnAppMenu_TXITEM_DocumentSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_btnAppMenu_TXITEM_DocumentSettings.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.m_btnAppMenu_TXITEM_DocumentSettings.KeyTip = "D";
            this.m_btnAppMenu_TXITEM_DocumentSettings.Location = new System.Drawing.Point(0, 228);
            this.m_btnAppMenu_TXITEM_DocumentSettings.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.m_btnAppMenu_TXITEM_DocumentSettings.Name = "m_btnAppMenu_TXITEM_DocumentSettings";
            this.m_btnAppMenu_TXITEM_DocumentSettings.Size = new System.Drawing.Size(197, 38);
            this.m_btnAppMenu_TXITEM_DocumentSettings.TabIndex = 0;
            this.m_btnAppMenu_TXITEM_DocumentSettings.Text = "Document Settings";
            // 
            // m_ribbonSeperator1
            // 
            this.m_ribbonSeperator1.BackColor = System.Drawing.Color.Transparent;
            this.m_ribbonSeperator1.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_ribbonSeperator1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.m_ribbonSeperator1.Location = new System.Drawing.Point(0, 266);
            this.m_ribbonSeperator1.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.m_ribbonSeperator1.MinimumSize = new System.Drawing.Size(0, 5);
            this.m_ribbonSeperator1.Name = "m_ribbonSeperator1";
            this.m_ribbonSeperator1.Size = new System.Drawing.Size(197, 5);
            this.m_ribbonSeperator1.TabIndex = 0;
            this.m_ribbonSeperator1.TabStop = false;
            this.m_ribbonSeperator1.Text = "ribbonSeperator1";
            // 
            // m_btnAppMenu_TXITEM_Options
            // 
            this.m_btnAppMenu_TXITEM_Options.BackColor = System.Drawing.Color.Transparent;
            this.m_btnAppMenu_TXITEM_Options.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_btnAppMenu_TXITEM_Options.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.m_btnAppMenu_TXITEM_Options.KeyTip = "O";
            this.m_btnAppMenu_TXITEM_Options.Location = new System.Drawing.Point(0, 271);
            this.m_btnAppMenu_TXITEM_Options.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.m_btnAppMenu_TXITEM_Options.Name = "m_btnAppMenu_TXITEM_Options";
            this.m_btnAppMenu_TXITEM_Options.Size = new System.Drawing.Size(197, 38);
            this.m_btnAppMenu_TXITEM_Options.TabIndex = 0;
            this.m_btnAppMenu_TXITEM_Options.Text = "Options…";
            // 
            // m_btnAppMenu_TXITEM_UserAdministration
            // 
            this.m_btnAppMenu_TXITEM_UserAdministration.BackColor = System.Drawing.Color.Transparent;
            this.m_btnAppMenu_TXITEM_UserAdministration.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_btnAppMenu_TXITEM_UserAdministration.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.m_btnAppMenu_TXITEM_UserAdministration.KeyTip = "U";
            this.m_btnAppMenu_TXITEM_UserAdministration.Location = new System.Drawing.Point(0, 309);
            this.m_btnAppMenu_TXITEM_UserAdministration.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.m_btnAppMenu_TXITEM_UserAdministration.Name = "m_btnAppMenu_TXITEM_UserAdministration";
            this.m_btnAppMenu_TXITEM_UserAdministration.Size = new System.Drawing.Size(197, 38);
            this.m_btnAppMenu_TXITEM_UserAdministration.TabIndex = 0;
            this.m_btnAppMenu_TXITEM_UserAdministration.Text = "User Administration…";
            // 
            // m_btnAppMenu_TXITEM_GrantUserAccess
            // 
            this.m_btnAppMenu_TXITEM_GrantUserAccess.BackColor = System.Drawing.Color.Transparent;
            this.m_btnAppMenu_TXITEM_GrantUserAccess.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_btnAppMenu_TXITEM_GrantUserAccess.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.m_btnAppMenu_TXITEM_GrantUserAccess.KeyTip = "G";
            this.m_btnAppMenu_TXITEM_GrantUserAccess.Location = new System.Drawing.Point(0, 347);
            this.m_btnAppMenu_TXITEM_GrantUserAccess.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.m_btnAppMenu_TXITEM_GrantUserAccess.Name = "m_btnAppMenu_TXITEM_GrantUserAccess";
            this.m_btnAppMenu_TXITEM_GrantUserAccess.Size = new System.Drawing.Size(197, 38);
            this.m_btnAppMenu_TXITEM_GrantUserAccess.TabIndex = 0;
            this.m_btnAppMenu_TXITEM_GrantUserAccess.Text = "Grant User Access…";
            // 
            // m_btnAppMenu_TXITEM_About
            // 
            this.m_btnAppMenu_TXITEM_About.BackColor = System.Drawing.Color.Transparent;
            this.m_btnAppMenu_TXITEM_About.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_btnAppMenu_TXITEM_About.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.m_btnAppMenu_TXITEM_About.KeyTip = "B";
            this.m_btnAppMenu_TXITEM_About.Location = new System.Drawing.Point(0, 385);
            this.m_btnAppMenu_TXITEM_About.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.m_btnAppMenu_TXITEM_About.Name = "m_btnAppMenu_TXITEM_About";
            this.m_btnAppMenu_TXITEM_About.Size = new System.Drawing.Size(197, 38);
            this.m_btnAppMenu_TXITEM_About.TabIndex = 0;
            this.m_btnAppMenu_TXITEM_About.Text = "About…";
            // 
            // m_btnAppMenu_TXITEM_Exit
            // 
            this.m_btnAppMenu_TXITEM_Exit.BackColor = System.Drawing.Color.Transparent;
            this.m_btnAppMenu_TXITEM_Exit.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_btnAppMenu_TXITEM_Exit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.m_btnAppMenu_TXITEM_Exit.KeyTip = "X";
            this.m_btnAppMenu_TXITEM_Exit.Location = new System.Drawing.Point(0, 423);
            this.m_btnAppMenu_TXITEM_Exit.Margin = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.m_btnAppMenu_TXITEM_Exit.Name = "m_btnAppMenu_TXITEM_Exit";
            this.m_btnAppMenu_TXITEM_Exit.Size = new System.Drawing.Size(197, 38);
            this.m_btnAppMenu_TXITEM_Exit.TabIndex = 0;
            this.m_btnAppMenu_TXITEM_Exit.Text = "Exit";
            // 
            // m_tableToolsGroup
            // 
            this.m_tableToolsGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.m_tableToolsGroup.ContextualTabs.Add(this.m_tableLayoutTab);
            this.m_tableToolsGroup.ContextualTabs.Add(this.m_formulaTab);
            this.m_tableToolsGroup.Name = "m_ctgTableTools";
            // 
            // m_tableLayoutTab
            // 
            this.m_tableLayoutTab.Location = new System.Drawing.Point(0, 0);
            this.m_tableLayoutTab.Name = "m_tableLayoutTab";
            this.m_tableLayoutTab.Size = new System.Drawing.Size(200, 40);
            this.m_tableLayoutTab.TabIndex = 0;
            // 
            // m_formulaTab
            // 
            this.m_formulaTab.Location = new System.Drawing.Point(0, 0);
            this.m_formulaTab.Name = "m_formulaTab";
            this.m_formulaTab.Size = new System.Drawing.Size(200, 40);
            this.m_formulaTab.TabIndex = 1;
            // 
            // m_frameToolsGroup
            // 
            this.m_frameToolsGroup.BackColor = System.Drawing.Color.LightGray;
            this.m_frameToolsGroup.ContextualTabs.Add(this.m_frameLayoutTab);
            this.m_frameToolsGroup.Name = "m_ctgFrameTools";
            // 
            // m_frameLayoutTab
            // 
            this.m_frameLayoutTab.Location = new System.Drawing.Point(0, 0);
            this.m_frameLayoutTab.Name = "m_frameLayoutTab";
            this.m_frameLayoutTab.Size = new System.Drawing.Size(200, 40);
            this.m_frameLayoutTab.TabIndex = 0;
            // 
            // m_reportingPreviewGroup
            // 
            this.m_reportingPreviewGroup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.m_reportingPreviewGroup.ContextualTabs.Add(this.m_previewTab);
            this.m_reportingPreviewGroup.Name = "m_ctgReportingPreview";
            // 
            // m_previewTab
            // 
            this.m_previewTab.KeyTip = "W";
            this.m_previewTab.Location = new System.Drawing.Point(0, 0);
            this.m_previewTab.Name = "m_previewTab";
            this.m_previewTab.Size = new System.Drawing.Size(200, 40);
            this.m_previewTab.TabIndex = 0;
            // 
            // m_formattingTab
            // 
            this.m_formattingTab.FindHorizontalSidebar = this.m_horizontalSidebar;
            this.m_formattingTab.FindSidebar = this.m_verticalRightSidebar;
            this.m_formattingTab.GotoHorizontalSidebar = this.m_horizontalSidebar;
            this.m_formattingTab.Location = new System.Drawing.Point(4, 27);
            this.m_formattingTab.Name = "m_formattingTab";
            this.m_formattingTab.ReplaceHorizontalSidebar = this.m_horizontalSidebar;
            this.m_formattingTab.ReplaceSidebar = this.m_verticalRightSidebar;
            this.m_formattingTab.Size = new System.Drawing.Size(992, 90);
            this.m_formattingTab.StylesSidebar = this.m_verticalRightSidebar;
            this.m_formattingTab.TabIndex = 1;
            // 
            // m_horizontalSidebar
            // 
            this.m_horizontalSidebar.ContentLayout = TXTextControl.Windows.Forms.Sidebar.SidebarContentLayout.Goto;
            this.m_horizontalSidebar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_horizontalSidebar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.m_horizontalSidebar.IsShown = false;
            this.m_horizontalSidebar.Location = new System.Drawing.Point(222, 1000);
            this.m_horizontalSidebar.Margin = new System.Windows.Forms.Padding(6);
            this.m_horizontalSidebar.Name = "m_horizontalSidebar";
            this.m_horizontalSidebar.Padding = new System.Windows.Forms.Padding(9);
            this.m_horizontalSidebar.ShowTitle = false;
            this.m_horizontalSidebar.Size = new System.Drawing.Size(562, 70);
            this.m_horizontalSidebar.TabIndex = 8;
            this.m_horizontalSidebar.TextControl = this.m_textControl;
            this.m_horizontalSidebar.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.m_horizontalSidebar_PropertyChanged);
            // 
            // m_textControl
            // 
            this.m_textControl.AllowDrag = true;
            this.m_textControl.AllowDrop = true;
            this.m_textControl.DisplayColors.DarkShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.m_textControl.DisplayColors.DesktopColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.m_textControl.DisplayColors.FormFieldColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_textControl.DisplayColors.LightShadowColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(246)))), ((int)(((byte)(247)))));
            this.m_textControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_textControl.DocumentTargetMarkers = true;
            this.m_textControl.Font = new System.Drawing.Font("Arial", 10F);
            this.m_textControl.HideSelection = false;
            this.m_textControl.Location = new System.Drawing.Point(247, 176);
            this.m_textControl.Margin = new System.Windows.Forms.Padding(6);
            this.m_textControl.Name = "m_textControl";
            this.m_textControl.Ribbon = this.m_ribbon;
            this.m_textControl.RulerBar = this.m_rulerBarHor;
            this.m_textControl.ShowMiniToolbar = ((TXTextControl.MiniToolbarButton)((TXTextControl.MiniToolbarButton.LeftButton | TXTextControl.MiniToolbarButton.RightButton)));
            this.m_textControl.Size = new System.Drawing.Size(537, 824);
            this.m_textControl.StatusBar = this.m_statusBar;
            this.m_textControl.TabIndex = 2;
            this.m_textControl.UserNames = null;
            this.m_textControl.VerticalRulerBar = this.m_rulerBarVert;
            this.m_textControl.Changed += new System.EventHandler(this.TextControl_Changed);
            this.m_textControl.InputPositionChanged += new System.EventHandler(this.TextControl_InputPositionChanged);
            this.m_textControl.TextContextMenuOpening += new TXTextControl.TextContextMenuEventHandler(this.TextControl_TextContextMenuOpening);
            this.m_textControl.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.TextControl_PropertyChanged);
            this.m_textControl.HypertextLinkClicked += new TXTextControl.HypertextLinkEventHandler(this.TextControl_HypertextLinkClicked);
            this.m_textControl.FrameSelected += new TXTextControl.FrameEventHandler(this.TextControl_FrameSelected);
            this.m_textControl.FrameDeselected += new TXTextControl.FrameEventHandler(this.TextControl_FrameDeselected);
            this.m_textControl.DrawingActivated += new TXTextControl.DataVisualization.DrawingEventHandler(this.TextControl_DrawingActivated);
            this.m_textControl.DrawingDeactivated += new TXTextControl.DataVisualization.DrawingEventHandler(this.TextControl_DrawingDeactivated);
            this.m_textControl.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextControl_DragDrop);
            this.m_textControl.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextControl_DragEnter);
            this.m_textControl.DragOver += new System.Windows.Forms.DragEventHandler(this.TextControl_DragOver);
            this.m_textControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextControl_KeyDown);
            // 
            // m_rulerBarHor
            // 
            this.m_rulerBarHor.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_rulerBarHor.Location = new System.Drawing.Point(222, 151);
            this.m_rulerBarHor.Margin = new System.Windows.Forms.Padding(6);
            this.m_rulerBarHor.Name = "m_rulerBarHor";
            this.m_rulerBarHor.Size = new System.Drawing.Size(562, 25);
            this.m_rulerBarHor.TabIndex = 5;
            // 
            // m_statusBar
            // 
            this.m_statusBar.BackColor = System.Drawing.SystemColors.Control;
            this.m_statusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_statusBar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.m_statusBar.LineText = "Line: ";
            this.m_statusBar.Location = new System.Drawing.Point(0, 1070);
            this.m_statusBar.Margin = new System.Windows.Forms.Padding(6);
            this.m_statusBar.Name = "m_statusBar";
            this.m_statusBar.PageText = "Page: ";
            this.m_statusBar.SectionText = "Section: ";
            this.m_statusBar.Size = new System.Drawing.Size(1000, 22);
            this.m_statusBar.TabIndex = 3;
            // 
            // m_rulerBarVert
            // 
            this.m_rulerBarVert.Alignment = TXTextControl.RulerBarAlignment.Left;
            this.m_rulerBarVert.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_rulerBarVert.Location = new System.Drawing.Point(222, 176);
            this.m_rulerBarVert.Margin = new System.Windows.Forms.Padding(6);
            this.m_rulerBarVert.Name = "m_rulerBarVert";
            this.m_rulerBarVert.Size = new System.Drawing.Size(25, 824);
            this.m_rulerBarVert.TabIndex = 4;
            // 
            // m_verticalRightSidebar
            // 
            this.m_verticalRightSidebar.ContentLayout = TXTextControl.Windows.Forms.Sidebar.SidebarContentLayout.FieldNavigator;
            this.m_verticalRightSidebar.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_verticalRightSidebar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.m_verticalRightSidebar.IsShown = false;
            this.m_verticalRightSidebar.Location = new System.Drawing.Point(784, 151);
            this.m_verticalRightSidebar.Margin = new System.Windows.Forms.Padding(6);
            this.m_verticalRightSidebar.Name = "m_verticalRightSidebar";
            this.m_verticalRightSidebar.Padding = new System.Windows.Forms.Padding(9);
            this.m_verticalRightSidebar.ShowPinButton = false;
            this.m_verticalRightSidebar.Size = new System.Drawing.Size(216, 919);
            this.m_verticalRightSidebar.TabIndex = 9;
            this.m_verticalRightSidebar.TextControl = this.m_textControl;
            this.m_verticalRightSidebar.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.m_verticalRightSidebar_PropertyChanged);
            // 
            // m_insertTab
            // 
            this.m_insertTab.Location = new System.Drawing.Point(4, 27);
            this.m_insertTab.Name = "m_insertTab";
            this.m_insertTab.Size = new System.Drawing.Size(992, 90);
            this.m_insertTab.TabIndex = 2;
            // 
            // m_pageLayoutTab
            // 
            this.m_pageLayoutTab.Location = new System.Drawing.Point(4, 27);
            this.m_pageLayoutTab.Name = "m_pageLayoutTab";
            this.m_pageLayoutTab.Size = new System.Drawing.Size(992, 90);
            this.m_pageLayoutTab.TabIndex = 3;
            // 
            // m_viewTab
            // 
            this.m_viewTab.Location = new System.Drawing.Point(4, 27);
            this.m_viewTab.Name = "m_viewTab";
            this.m_viewTab.Size = new System.Drawing.Size(992, 90);
            this.m_viewTab.TabIndex = 4;
            // 
            // m_referencesTab
            // 
            this.m_referencesTab.Location = new System.Drawing.Point(4, 27);
            this.m_referencesTab.Name = "m_referencesTab";
            this.m_referencesTab.Size = new System.Drawing.Size(992, 90);
            this.m_referencesTab.TabIndex = 7;
            // 
            // m_proofingTab
            // 
            this.m_proofingTab.Location = new System.Drawing.Point(4, 27);
            this.m_proofingTab.Name = "m_proofingTab";
            this.m_proofingTab.Size = new System.Drawing.Size(992, 90);
            this.m_proofingTab.TabIndex = 5;
            this.m_proofingTab.TrackedChangesHorizontalSidebar = this.m_horizontalSidebar;
            this.m_proofingTab.TrackedChangesSidebar = this.m_verticalLeftSidebar;
            // 
            // m_verticalLeftSidebar
            // 
            this.m_verticalLeftSidebar.ContentLayout = TXTextControl.Windows.Forms.Sidebar.SidebarContentLayout.TrackedChanges;
            this.m_verticalLeftSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_verticalLeftSidebar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.m_verticalLeftSidebar.IsShown = false;
            this.m_verticalLeftSidebar.Location = new System.Drawing.Point(0, 151);
            this.m_verticalLeftSidebar.Margin = new System.Windows.Forms.Padding(6);
            this.m_verticalLeftSidebar.Name = "m_verticalLeftSidebar";
            this.m_verticalLeftSidebar.Padding = new System.Windows.Forms.Padding(9);
            this.m_verticalLeftSidebar.Size = new System.Drawing.Size(222, 919);
            this.m_verticalLeftSidebar.TabIndex = 6;
            this.m_verticalLeftSidebar.TextControl = this.m_textControl;
            this.m_verticalLeftSidebar.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(this.m_verticalLeftSidebar_PropertyChanged);
            // 
            // m_permissionsTab
            // 
            this.m_permissionsTab.AllowAddingUserNames = true;
            this.m_permissionsTab.Location = new System.Drawing.Point(4, 27);
            this.m_permissionsTab.Name = "m_permissionsTab";
            this.m_permissionsTab.RegisteredUserNames = new string[0];
            this.m_permissionsTab.Size = new System.Drawing.Size(992, 90);
            this.m_permissionsTab.TabIndex = 6;
            // 
            // m_formFieldsTab
            // 
            this.m_formFieldsTab.ConditionalInstructionsSidebar = this.m_verticalRightSidebar;
            this.m_formFieldsTab.Location = new System.Drawing.Point(4, 27);
            this.m_formFieldsTab.Name = "m_formFieldsTab";
            this.m_formFieldsTab.Size = new System.Drawing.Size(992, 90);
            this.m_formFieldsTab.TabIndex = 7;
            // 
            // m_reportingTab
            // 
            this.m_reportingTab.FieldNavigatorSidebar = this.m_verticalRightSidebar;
            this.m_reportingTab.Location = new System.Drawing.Point(4, 27);
            this.m_reportingTab.Name = "m_reportingTab";
            this.m_reportingTab.Size = new System.Drawing.Size(992, 90);
            this.m_reportingTab.TabIndex = 6;
            // 
            // m_chartLayoutTab
            // 
            this.m_chartLayoutTab.Location = new System.Drawing.Point(0, 0);
            this.m_chartLayoutTab.Name = "m_chartLayoutTab";
            this.m_chartLayoutTab.Size = new System.Drawing.Size(200, 40);
            this.m_chartLayoutTab.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1000, 1092);
            this.Controls.Add(this.m_textControl);
            this.Controls.Add(this.m_rulerBarVert);
            this.Controls.Add(this.m_rulerBarHor);
            this.Controls.Add(this.m_horizontalSidebar);
            this.Controls.Add(this.m_verticalLeftSidebar);
            this.Controls.Add(this.m_verticalRightSidebar);
            this.Controls.Add(this.m_statusBar);
            this.Controls.Add(this.m_ribbon);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "MainWindow";
            this.m_ribbon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private void AddFinishGroup()
		{
			this.TXITEM_FinishGroup = new RibbonGroup
			{
				Text = Resources.HEADER_FinishGroup,
				SmallIcon = Images.GetSmallIcon("FinishGroup"),
				LargeIcon = Images.GetSmallIcon("FinishAndMerge"),
				HorizontalContentAlignment = TXTextControl.HorizontalAlignment.Center,
				Enabled = false
			};
			this.TXITEM_FinishGroup.DialogBoxLauncher.Visible = false;
			this.m_reportingTab.RibbonGroups.Add(this.TXITEM_FinishGroup);
			this.AddPreviewButton();
			this.AddFinishAndMergeButton();
		}

		private void AddPreviewButton()
		{
			this.TXITEM_Preview = new RibbonButton
			{
				Text = Resources.LABEL_Preview,
				KeyTip = Resources.KEYTIP_Preview,
				SmallIcon = Images.GetSmallIcon("Preview"),
				LargeIcon = Images.GetLargeIcon("Preview"),
				DisplayMode = IconTextRelation.LargeIconLabeled
			};
			this.TXITEM_Preview.ToolTip.Title = Resources.TOOLTIPTITLE_Preview;
			this.TXITEM_Preview.ToolTip.Description = Resources.TOOLTIP_Preview;
			this.TXITEM_Preview.Click += BtnPreview_Click;
			this.TXITEM_FinishGroup.RibbonItems.Add(this.TXITEM_Preview);
		}

		private void BtnPreview_Click(object sender, EventArgs e)
		{
			LimitPreviewDataDialog limitPreviewDataDialog = new LimitPreviewDataDialog();
			if (limitPreviewDataDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.MergePreviewAsync(limitPreviewDataDialog.MaxPreviews);
			}
		}

		private void MergePreviewAsync(int nMaxPreviews)
		{
			ThreadPool.QueueUserWorkItem(MergePreviewCallback, nMaxPreviews);
		}

		private void MergePreviewCallback(object state)
		{
			int nMaxPreviews = (int)state;
			base.BeginInvoke(new Action(ShowMergeWaitDialog));
			this.MergePreview(nMaxPreviews);
			base.BeginInvoke(new Action(CloseMergeWaitDialog));
		}

		private void MergePreview(int nMaxPreviews)
		{
			this.m_textControl.Save(out this.m_textControlContent, BinaryStreamType.InternalUnicodeFormat);
			base.Invoke((Action)delegate
			{
				this.SetLastSelectedMasterTable();
			});
			this.m_lstMergedFiles = this.m_reportingTab.DataSourceManager.Merge(this.m_textControlContent, nMaxPreviews, this.m_textControl);
			if (this.m_lstMergedFiles.Count > 0)
			{
				base.Invoke((Action)delegate
				{
					this.m_iPreviewIndex = 0;
					this.m_nPreviewCount = Math.Min(nMaxPreviews, this.m_lstMergedFiles.Count);
					this.m_textControl.Load(this.m_lstMergedFiles[0], BinaryStreamType.InternalUnicodeFormat);
					this.m_reportingPreviewGroup.Visible = true;
					this.m_ribbon.SelectedTab = this.m_previewTab;
					this.m_editMode = this.m_textControl.EditMode;
					this.m_textControl.EditMode = EditMode.ReadAndSelect;
					this.TXITEM_Preview.Enabled = false;
					this.UpdateNavigateButtons();
				});
			}
			else
			{
				this.m_lstMergedFiles = null;
			}
		}

		private void AddFinishAndMergeButton()
		{
			RibbonSplitButton ribbonSplitButton = new RibbonSplitButton
			{
				Text = Resources.LABEL_FinishAndMerge,
				KeyTip = Resources.KEYTIP_FinishAndMerge,
				SmallIcon = Images.GetSmallIcon("FinishAndMerge"),
				LargeIcon = Images.GetLargeIcon("FinishAndMerge")
			};
			ribbonSplitButton.ToolTip.Title = Resources.TOOLTIPTITLE_FinishAndMerge;
			ribbonSplitButton.ToolTip.Description = Resources.TOOLTIP_FinishAndMerge;
			ribbonSplitButton.ButtonClick += BtnFinishMerge_Click;
			this.AddFinishAndMergeMenu(ribbonSplitButton);
			this.TXITEM_FinishGroup.RibbonItems.Add(ribbonSplitButton);
			this.m_reportingTab.DataSourceManager.IsMergingPossibleChanged += DataSourceManager_IsMergingPossibleChanged;
		}

		private void BtnFinishMerge_Click(object sender, EventArgs e)
		{
			this.MergeIntoCurrentDocAsync();
		}

		private void DataSourceManager_IsMergingPossibleChanged(object sender, EventArgs e)
		{
			this.TXITEM_FinishGroup.Enabled = this.m_reportingTab.DataSourceManager.IsMergingPossible;
		}

		private void AddFinishAndMergeMenu(RibbonSplitButton splitButton)
		{
			RibbonButton ribbonButton = new RibbonButton
			{
				Text = Resources.HEADER_FinishAndMerge_IntoCurrentDocument,
				SmallIcon = Images.GetSmallIcon("FinishAndMerge_IntoCurrentDocument"),
				DisplayMode = IconTextRelation.SmallIconLabeled
			};
			ribbonButton.ToolTip.Title = Resources.TOOLTIPTITLE_FinishAndMerge_IntoCurrentDocument;
			ribbonButton.ToolTip.Description = Resources.TOOLTIP_FinishAndMerge_IntoCurrentDocument;
			ribbonButton.Click += BtnMergeIntoCur_Click;
			RibbonButton ribbonButton2 = new RibbonButton
			{
				Text = Resources.HEADER_FinishAndMerge_IntoSingleFile,
				SmallIcon = Images.GetSmallIcon("FinishAndMerge_IntoSingleFile"),
				DisplayMode = IconTextRelation.SmallIconLabeled
			};
			ribbonButton2.ToolTip.Title = Resources.TOOLTIPTITLE_FinishAndMerge_IntoSingleFile;
			ribbonButton2.ToolTip.Description = Resources.TOOLTIP_FinishAndMerge_IntoSingleFile;
			ribbonButton2.Click += BtnMergeIntoSingleFile_Click;
			RibbonMenuButton ribbonMenuButton = new RibbonMenuButton
			{
				Text = Resources.HEADER_FinishAndMerge_IntoIndividualDocument,
				SmallIcon = Images.GetSmallIcon("FinishAndMerge_IntoIndividualDocument"),
				DisplayMode = IconTextRelation.SmallIconLabeled
			};
			ribbonMenuButton.ToolTip.Title = Resources.TOOLTIPTITLE_FinishAndMerge_IntoIndividualDocument;
			ribbonMenuButton.ToolTip.Description = Resources.TOOLTIP_FinishAndMerge_IntoIndividualDocument;
			this.AddMergeIntoSeparateFilesMenu(ribbonMenuButton);
			RibbonButton ribbonButton3 = new RibbonButton
			{
				Text = Resources.HEADER_FinishAndMerge_PrintDocument,
				SmallIcon = Images.GetSmallIcon("FinishAndMerge_PrintDocument"),
				DisplayMode = IconTextRelation.SmallIconLabeled
			};
			ribbonButton3.ToolTip.Title = Resources.TOOLTIPTITLE_FinishAndMerge_PrintDocument;
			ribbonButton3.ToolTip.Description = Resources.TOOLTIP_FinishAndMerge_PrintDocument;
			ribbonButton3.Click += BtnMergePrint_Click;
			splitButton.DropDownItems.AddRange(new Control[4] { ribbonButton, ribbonButton2, ribbonMenuButton, ribbonButton3 });
		}

		private void BtnMergeIntoCur_Click(object sender, EventArgs e)
		{
			this.MergeIntoCurrentDocAsync();
		}

		private void BtnMergeIntoSingleFile_Click(object sender, EventArgs e)
		{
			List<StreamType> list = new List<StreamType>
			{
				StreamType.AdobePDF,
				StreamType.RichTextFormat,
				StreamType.MSWord,
				StreamType.WordprocessingML,
				StreamType.PlainText,
				StreamType.InternalUnicodeFormat,
				StreamType.HTMLFormat
			};
			string filter = string.Join("|", list.ConvertAll((StreamType x) => x.ToFilterString()));
			SaveFileDialog saveFileDialog = new SaveFileDialog
			{
				Filter = filter
			};
			if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				MergeIntoSingleFileInfo mergeIntoSingleFileInfo = new MergeIntoSingleFileInfo(Path.GetExtension(saveFileDialog.FileName).ToTxStreamType(), saveFileDialog.FileName);
				ThreadPool.QueueUserWorkItem(MergeIntoSingleFileCallback, mergeIntoSingleFileInfo);
			}
		}

		private void AddMergeIntoSeparateFilesMenu(RibbonMenuButton menuButton)
		{
			this.AddMergeIntoMenuButtons(menuButton, Resources.BTN_MERGE_INTO_INDIV_X_FILES_TOOLTIP, BtnMergeIntoSeparateFiles_Click);
		}

		private void BtnMergeIntoSeparateFiles_Click(object sender, EventArgs e)
		{
			RibbonButton ribbonButton = sender as RibbonButton;
			if (ribbonButton != null)
			{
				this.MergeIntoSeparateFilesAsync(ribbonButton.Text.ToTxStreamType());
			}
		}

		private void AddMergeIntoMenuButtons(RibbonMenuButton menuButton, string toolTipTextTemplate, EventHandler clickHandler)
		{
			RibbonButton ribbonButton = new RibbonButton
			{
				Text = "PDF",
				DisplayMode = IconTextRelation.NoIconLabeled
			};
			ribbonButton.ToolTip.Description = string.Format(toolTipTextTemplate, ribbonButton.Text);
			ribbonButton.Click += clickHandler;
			RibbonButton ribbonButton2 = new RibbonButton
			{
				Text = "RTF",
				DisplayMode = IconTextRelation.NoIconLabeled
			};
			ribbonButton2.ToolTip.Description = string.Format(toolTipTextTemplate, ribbonButton2.Text);
			ribbonButton2.Click += clickHandler;
			RibbonButton ribbonButton3 = new RibbonButton
			{
				Text = "DOCX",
				DisplayMode = IconTextRelation.NoIconLabeled
			};
			ribbonButton3.ToolTip.Description = string.Format(toolTipTextTemplate, ribbonButton3.Text);
			ribbonButton3.Click += clickHandler;
			RibbonButton ribbonButton4 = new RibbonButton
			{
				Text = "DOC",
				DisplayMode = IconTextRelation.NoIconLabeled
			};
			ribbonButton4.ToolTip.Description = string.Format(toolTipTextTemplate, ribbonButton4.Text);
			ribbonButton4.Click += clickHandler;
			RibbonButton ribbonButton5 = new RibbonButton
			{
				Text = "HTML",
				DisplayMode = IconTextRelation.NoIconLabeled
			};
			ribbonButton5.ToolTip.Description = string.Format(toolTipTextTemplate, ribbonButton5.Text);
			ribbonButton5.Click += clickHandler;
			RibbonButton ribbonButton6 = new RibbonButton
			{
				Text = "TXT",
				DisplayMode = IconTextRelation.NoIconLabeled
			};
			ribbonButton6.ToolTip.Description = string.Format(toolTipTextTemplate, ribbonButton6.Text);
			ribbonButton6.Click += clickHandler;
			menuButton.DropDownItems.AddRange(new Control[6] { ribbonButton, ribbonButton2, ribbonButton3, ribbonButton4, ribbonButton5, ribbonButton6 });
		}

		private void BtnMergePrint_Click(object sender, EventArgs e)
		{
			this.MergePrintAsync();
		}

		private void MergeIntoCurrentDocAsync()
		{
			if (this.m_fileHandler.HandleUnsavedChanges())
			{
				ThreadPool.QueueUserWorkItem(MergeIntoCurrentDocCallback);
			}
		}

		private void MergeIntoCurrentDocCallback(object state)
		{
			base.BeginInvoke(new Action(ShowMergeWaitDialog));
			this.MergeIntoCurrentDocument();
			base.BeginInvoke(new Action(CloseMergeWaitDialog));
		}

		private void MergeIntoCurrentDocument()
		{
			DataSourceManager dataSourceManager = this.m_reportingTab.DataSourceManager;
			this.m_textControl.Save(out var binaryData, BinaryStreamType.InternalUnicodeFormat);
			IList<byte[]> list = dataSourceManager.Merge(binaryData, this.m_textControl);
			if (list.Count == 0)
			{
				TX_Text_Control_Words.Utils.MessageBox.Show(this, Resources.MERGE_NO_MERGE_RESULTS, base.ProductName, MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
				return;
			}
			base.Invoke(new Action(this.m_textControl.ResetContents));
			foreach (byte[] item in list)
			{
				this.m_textControl.Append(item, BinaryStreamType.InternalUnicodeFormat, AppendSettings.StartWithNewSection);
			}
		}

		private void MergeIntoSeparateFilesAsync(StreamType streamType)
		{
			FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog
			{
				ShowNewFolderButton = true
			};
			if (folderBrowserDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				MergeIntoSeparateFilesInfo mergeIntoSeparateFilesInfo = new MergeIntoSeparateFilesInfo(streamType, folderBrowserDialog.SelectedPath);
				ThreadPool.QueueUserWorkItem(MergeIntoSeparateFilesCallback, mergeIntoSeparateFilesInfo);
			}
		}

		private void MergeIntoSeparateFilesCallback(object state)
		{
			MergeIntoSeparateFilesInfo mergeIntoSeparateFilesInfo = state as MergeIntoSeparateFilesInfo;
			if (mergeIntoSeparateFilesInfo != null)
			{
				base.BeginInvoke(new Action(ShowMergeWaitDialog));
				this.MergeIntoSeparateFiles(mergeIntoSeparateFilesInfo.StreamType, mergeIntoSeparateFilesInfo.DirectoryName);
				base.BeginInvoke(new Action(CloseMergeWaitDialog));
			}
		}

		private void MergeIntoSeparateFiles(StreamType streamType, string dirName)
		{
			DataSourceManager dataSourceManager = this.m_reportingTab.DataSourceManager;
			this.m_textControl.Save(out var binaryData, BinaryStreamType.InternalUnicodeFormat);
			IEnumerable<byte[]> enumerable = dataSourceManager.Merge(binaryData, this.m_textControl);
			using ServerTextControl serverTextControl = new ServerTextControl();
			serverTextControl.Create();
			int num = 0;
			string text = string.Format("\\MergedDocument_{0:yy-MM-dd}_{0:HH-mm-ss}_", DateTime.Now);
			string text2 = streamType.ToFileExt();
			foreach (byte[] item in enumerable)
			{
				serverTextControl.Load(item, BinaryStreamType.InternalUnicodeFormat);
				string path = $"{dirName}{text}{$"{num++:00000}"}{text2}";
				serverTextControl.Save(path, streamType);
			}
		}

		private void MergeIntoSingleFileCallback(object state)
		{
			MergeIntoSingleFileInfo mergeIntoSingleFileInfo = state as MergeIntoSingleFileInfo;
			if (mergeIntoSingleFileInfo != null)
			{
				base.BeginInvoke(new Action(ShowMergeWaitDialog));
				this.MergeIntoSingleFile(mergeIntoSingleFileInfo.StreamType, mergeIntoSingleFileInfo.FileName);
				base.BeginInvoke(new Action(CloseMergeWaitDialog));
			}
		}

		private void MergeIntoSingleFile(StreamType streamType, string fileName)
		{
			DataSourceManager dataSourceManager = this.m_reportingTab.DataSourceManager;
			this.m_textControl.Save(out var binaryData, BinaryStreamType.InternalUnicodeFormat);
			IList<byte[]> list = dataSourceManager.Merge(binaryData, this.m_textControl);
			using ServerTextControl serverTextControl = new ServerTextControl();
			serverTextControl.Create();
			for (int i = 0; i < list.Count; i++)
			{
				byte[] binaryData2 = list[i];
				if (i == 0)
				{
					serverTextControl.Load(binaryData2, BinaryStreamType.InternalUnicodeFormat);
				}
				else
				{
					serverTextControl.Append(binaryData2, BinaryStreamType.InternalUnicodeFormat, AppendSettings.StartWithNewSection);
				}
			}
			serverTextControl.Save(fileName, streamType);
		}

		private void MergePrintAsync()
		{
			PrintDocument document = new PrintDocument();
			PrintDialog printDialog = new PrintDialog
			{
				UseEXDialog = true,
				AllowCurrentPage = false,
				AllowSelection = false,
				AllowSomePages = false,
				Document = document
			};
			if (printDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				ThreadPool.QueueUserWorkItem(MergePrintCallback, printDialog.Document);
			}
		}

		private void MergePrintCallback(object state)
		{
			PrintDocument printDocument = state as PrintDocument;
			if (printDocument != null)
			{
				base.BeginInvoke(new Action(ShowMergeWaitDialog));
				this.MergePrint(printDocument);
				base.BeginInvoke(new Action(CloseMergeWaitDialog));
			}
		}

		private void MergePrint(PrintDocument printDoc)
		{
			DataSourceManager dataSourceManager = this.m_reportingTab.DataSourceManager;
			this.m_textControl.Save(out var binaryData, BinaryStreamType.InternalUnicodeFormat);
			IEnumerable<byte[]> enumerable = dataSourceManager.Merge(binaryData, this.m_textControl);
			using ServerTextControl serverTextControl = new ServerTextControl();
			serverTextControl.Create();
			foreach (byte[] item in enumerable)
			{
				serverTextControl.Append(item, BinaryStreamType.InternalUnicodeFormat, AppendSettings.StartWithNewSection);
			}
			serverTextControl.Print(printDoc);
		}

		private void ShowMergeWaitDialog()
		{
			if (this.m_dlgMergeWait != null)
			{
				try
				{
					this.m_dlgMergeWait.CloseDialog();
				}
				catch
				{
				}
				this.m_dlgMergeWait = null;
			}
			this.m_dlgMergeWait = new MergeWaitDialog();
			this.m_dlgMergeWait.Owner = this;
			this.m_dlgMergeWait.ShowDialog();
		}

		private void CloseMergeWaitDialog()
		{
			if (this.m_dlgMergeWait != null)
			{
				try
				{
					this.m_dlgMergeWait.CloseDialog();
					this.m_dlgMergeWait = null;
				}
				catch
				{
				}
			}
		}

		private void SetLastSelectedMasterTable()
		{
			foreach (Control dropDownItem in (this.m_reportingTab.FindItem(RibbonReportingTab.RibbonItem.TXITEM_SelectMasterTable) as RibbonMenuButton).DropDownItems)
			{
				RibbonToggleButton ribbonToggleButton = dropDownItem as RibbonToggleButton;
				if (ribbonToggleButton != null && ribbonToggleButton.Checked)
				{
					this.m_reportingTab.DataSourceManager.MasterDataTableInfo = ribbonToggleButton.Tag as DataTableInfo;
					break;
				}
			}
		}

		private void AddFrameContextMenuItems(ContextMenuStrip contextMenuStrip)
		{
			FrameBase item = this.m_textControl.Frames.GetItem();
			if (item != null && !(item is ChartFrame))
			{
				contextMenuStrip.Items.Add(new ToolStripSeparator());
				if (!(item is DrawingFrame) && !(item is TextFrame))
				{
					this.AddSelectFrameDataSourceMenuItem(contextMenuStrip);
				}
				this.AddFrameNameContextMenuItem(contextMenuStrip);
			}
		}

		private void AddSelectFrameDataSourceMenuItem(ContextMenuStrip contextMenuStrip)
		{
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(Resources.CONTEXTMENU_FRAME_SEL_DATA_SOURCE, ResourceProvider.GetSmallIcon(RibbonReportingTab.RibbonItem.TXITEM_DataSource.ToString(), base.DeviceDpi));
			toolStripMenuItem.DropDownOpening += SelectFrameDataSourceMenuItem_DropDownOpening;
			toolStripMenuItem.DropDownItems.Add("-");
			toolStripMenuItem.Enabled = this.m_textControl.CanEdit && this.m_reportingTab.DataSourceManager.MasterDataTableInfo != null;
			contextMenuStrip.Items.Add(toolStripMenuItem);
		}

		private void SelectFrameDataSourceMenuItem_DropDownOpening(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				this.AddSelectFrameDataSourceMenuItems(toolStripMenuItem, this.m_reportingTab.DataSourceManager.MasterDataTableInfo);
			}
		}

		private void AddSelectFrameDataSourceMenuItems(ToolStripMenuItem mnuItm, DataTableInfo table)
		{
			mnuItm.DropDownItems.Clear();
			foreach (DataColumnInfo column in table.Columns)
			{
				ToolStripMenuItem value = new ToolStripMenuItem(column.ColumnName, ResourceProvider.GetSmallIcon("TXITEM_SelectTableCol", base.DeviceDpi), FrameDataSourceColItem_Click);
				mnuItm.DropDownItems.Add(value);
			}
			foreach (DataTableInfo childTable in table.ChildTables)
			{
				ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(childTable.TableName, ResourceProvider.GetSmallIcon("TXITEM_Table", base.DeviceDpi));
				toolStripMenuItem.Tag = childTable;
				toolStripMenuItem.DropDownOpening += FrameDataSourceTblItem_DropDownOpening;
				toolStripMenuItem.DropDownItems.Add("-");
				mnuItm.DropDownItems.Add(toolStripMenuItem);
			}
		}

		private void FrameDataSourceTblItem_DropDownOpening(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				DataTableInfo dataTableInfo = toolStripMenuItem.Tag as DataTableInfo;
				if (dataTableInfo != null)
				{
					this.AddSelectFrameDataSourceMenuItems(toolStripMenuItem, dataTableInfo);
				}
			}
		}

		private void FrameDataSourceColItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				FrameBase item = this.m_textControl.Frames.GetItem();
				if (item != null)
				{
					item.Name = this.GenerateFieldName(toolStripMenuItem);
				}
			}
		}

		private string GenerateFieldName(ToolStripMenuItem mnuItm)
		{
			List<string> list = new List<string>();
			while (mnuItm != null && !(mnuItm.GetCurrentParent() is ContextMenuStrip))
			{
				list.Add(mnuItm.Text);
				mnuItm = mnuItm.OwnerItem as ToolStripMenuItem;
			}
			list.Reverse();
			return string.Join(".", list.ToArray());
		}

		private void AddFrameNameContextMenuItem(ContextMenuStrip contextMenuStrip)
		{
			if (this.m_textControl.CanEdit)
			{
				contextMenuStrip.Items.Add(Resources.CONTEXTMENU_FRAME_NAME, ResourceProvider.GetSmallIcon(RibbonFrameLayoutTab.RibbonItem.TXITEM_ObjectName.ToString(), base.DeviceDpi), SetFrameName_Click);
			}
		}

		private void SetFrameName_Click(object sender, EventArgs e)
		{
			FrameBase item = this.m_textControl.Frames.GetItem();
			if (item != null)
			{
				string name = item.Name;
				UserPromptDialog userPromptDialog = new UserPromptDialog(Resources.USR_INP_FRAME_NAME_TITLE, Resources.USR_INP_FRAME_NAME_LABEL, name)
				{
					Owner = this,
					RightToLeft = this.RightToLeft
				};
				if (userPromptDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
				{
					item.Name = userPromptDialog.Value;
				}
			}
		}

		private void AddPreviewGroup()
		{
			this.m_grpPreview = new RibbonGroup
			{
				Text = Resources.RIBBON_GROUP_PREVIEW,
				LargeIcon = ResourceProvider.GetSmallIcon(ResourceProvider.FileMenuItem.TXITEM_Exit.ToString(), base.DeviceDpi),
				SmallIcon = ResourceProvider.GetSmallIcon(ResourceProvider.FileMenuItem.TXITEM_Exit.ToString(), base.DeviceDpi),
				IsAddToQuickAccessToolbarEnabled = false,
				HorizontalContentAlignment = TXTextControl.HorizontalAlignment.Center
			};
			this.m_grpPreview.DialogBoxLauncher.Visible = false;
			this.m_previewTab.RibbonGroups.Add(this.m_grpPreview);
			this.AddClosePreviewButton();
		}

		private void AddClosePreviewButton()
		{
			this.TXITEM_ClosePreview = new RibbonButton
			{
				DisplayMode = IconTextRelation.LargeIconLabeled,
				IsAddToQuickAccessToolbarEnabled = false
			};
			this.TXITEM_ClosePreview.Click += ClosePreview_Click;
			this.TXITEM_ClosePreview.Apply(ResourceProvider.FileMenuItem.TXITEM_Exit.ToString(), base.DeviceDpi);
			this.m_grpPreview.RibbonItems.Add(this.TXITEM_ClosePreview);
		}

		private void ClosePreview_Click(object sender, EventArgs e)
		{
			this.HandleClosePreview();
			this.m_ribbon.SelectedTab = this.m_reportingTab;
		}

		private void AddNavigateGroup()
		{
			this.m_grpNavigate = new RibbonGroup
			{
				Text = Resources.RIBBON_GROUP_NAVIGATE,
				LargeIcon = ResourceProvider.GetSmallIcon(ResourceProvider.GeneralItem.TXITEM_NavigateToLast.ToString(), base.DeviceDpi),
				SmallIcon = ResourceProvider.GetSmallIcon(ResourceProvider.GeneralItem.TXITEM_NavigateToLast.ToString(), base.DeviceDpi),
				IsAddToQuickAccessToolbarEnabled = false
			};
			this.m_grpNavigate.DialogBoxLauncher.Visible = false;
			this.m_previewTab.RibbonGroups.Add(this.m_grpNavigate);
			this.AddFirstRecordButton();
			this.AddPreviousRecordButton();
			this.AddNextRecordButton();
			this.AddLastRecordButton();
		}

		private void AddFirstRecordButton()
		{
			this.TXITEM_FirstRecord = new RibbonButton
			{
				DisplayMode = IconTextRelation.LargeIconLabeled,
				IsAddToQuickAccessToolbarEnabled = false,
				Text = Resources.PREVIEWTAB_NAVIGATEGRP_FIRST_RECORD
			};
			this.TXITEM_FirstRecord.Click += BtnFirstRecord_Click;
			this.TXITEM_FirstRecord.ToolTip.Opening += RecordButton_ToolTip_Opening;
			this.TXITEM_FirstRecord.Apply(ResourceProvider.GeneralItem.TXITEM_NavigateToFirst.ToString(), base.DeviceDpi, RibbonButtonExtensions.RibbonButtonResource.ToolTip | RibbonButtonExtensions.RibbonButtonResource.ImageSources | RibbonButtonExtensions.RibbonButtonResource.KeyTip);
			this.m_grpNavigate.RibbonItems.Add(this.TXITEM_FirstRecord);
		}

		private void BtnFirstRecord_Click(object sender, EventArgs e)
		{
			this.m_iPreviewIndex = 0;
			this.m_textControl.Load(this.m_lstMergedFiles[this.m_iPreviewIndex], BinaryStreamType.InternalUnicodeFormat);
			this.UpdateNavigateButtons();
		}

		private void AddPreviousRecordButton()
		{
			this.TXITEM_PreviousRecord = new RibbonButton
			{
				DisplayMode = IconTextRelation.LargeIconLabeled,
				IsAddToQuickAccessToolbarEnabled = false,
				Text = Resources.PREVIEWTAB_NAVIGATEGRP_PREVIOUS_RECORD
			};
			this.TXITEM_PreviousRecord.Click += BtnPreviousRecord_Click;
			this.TXITEM_PreviousRecord.ToolTip.Opening += RecordButton_ToolTip_Opening;
			this.TXITEM_PreviousRecord.Apply(ResourceProvider.GeneralItem.TXITEM_NavigateToPrevious.ToString(), base.DeviceDpi, RibbonButtonExtensions.RibbonButtonResource.ToolTip | RibbonButtonExtensions.RibbonButtonResource.ImageSources | RibbonButtonExtensions.RibbonButtonResource.KeyTip);
			this.m_grpNavigate.RibbonItems.Add(this.TXITEM_PreviousRecord);
		}

		private void BtnPreviousRecord_Click(object sender, EventArgs e)
		{
			this.m_iPreviewIndex--;
			this.m_textControl.Load(this.m_lstMergedFiles[this.m_iPreviewIndex], BinaryStreamType.InternalUnicodeFormat);
			this.UpdateNavigateButtons();
		}

		private void AddNextRecordButton()
		{
			this.TXITEM_NextRecord = new RibbonButton
			{
				DisplayMode = IconTextRelation.LargeIconLabeled,
				IsAddToQuickAccessToolbarEnabled = false,
				Text = Resources.PREVIEWTAB_NAVIGATEGRP_NEXT_RECORD
			};
			this.TXITEM_NextRecord.Click += BtnNextRecord_Click;
			this.TXITEM_NextRecord.ToolTip.Opening += RecordButton_ToolTip_Opening;
			this.TXITEM_NextRecord.Apply(ResourceProvider.GeneralItem.TXITEM_NavigateToNext.ToString(), base.DeviceDpi, RibbonButtonExtensions.RibbonButtonResource.ToolTip | RibbonButtonExtensions.RibbonButtonResource.ImageSources | RibbonButtonExtensions.RibbonButtonResource.KeyTip);
			this.m_grpNavigate.RibbonItems.Add(this.TXITEM_NextRecord);
		}

		private void BtnNextRecord_Click(object sender, EventArgs e)
		{
			this.m_iPreviewIndex++;
			this.m_textControl.Load(this.m_lstMergedFiles[this.m_iPreviewIndex], BinaryStreamType.InternalUnicodeFormat);
			this.UpdateNavigateButtons();
		}

		private void RecordButton_ToolTip_Opening(object sender, EventArgs e)
		{
			this.SetToolTipDescription((RibbonButton)sender);
		}

		private void AddLastRecordButton()
		{
			this.TXITEM_LastRecord = new RibbonButton
			{
				DisplayMode = IconTextRelation.LargeIconLabeled,
				IsAddToQuickAccessToolbarEnabled = false,
				Text = Resources.PREVIEWTAB_NAVIGATEGRP_LAST_RECORD
			};
			this.TXITEM_LastRecord.Click += BtnLastRecord_Click;
			this.TXITEM_LastRecord.ToolTip.Opening += RecordButton_ToolTip_Opening;
			this.TXITEM_LastRecord.Apply(ResourceProvider.GeneralItem.TXITEM_NavigateToLast.ToString(), base.DeviceDpi, RibbonButtonExtensions.RibbonButtonResource.ToolTip | RibbonButtonExtensions.RibbonButtonResource.ImageSources | RibbonButtonExtensions.RibbonButtonResource.KeyTip);
			this.m_grpNavigate.RibbonItems.Add(this.TXITEM_LastRecord);
		}

		private void BtnLastRecord_Click(object sender, EventArgs e)
		{
			this.m_iPreviewIndex = this.m_nPreviewCount - 1;
			this.m_textControl.Load(this.m_lstMergedFiles[this.m_iPreviewIndex], BinaryStreamType.InternalUnicodeFormat);
			this.UpdateNavigateButtons();
		}

		private void SetToolTipDescription(RibbonButton navigateButton)
		{
			int num = 0;
			if (navigateButton == this.TXITEM_FirstRecord)
			{
				num = 0;
			}
			else if (navigateButton == this.TXITEM_PreviousRecord)
			{
				num = this.m_iPreviewIndex - 1;
			}
			else if (navigateButton == this.TXITEM_NextRecord)
			{
				num = this.m_iPreviewIndex + 1;
			}
			else if (navigateButton == this.TXITEM_LastRecord)
			{
				num = this.m_nPreviewCount - 1;
			}
			navigateButton.ToolTip.Title = navigateButton.Text;
			navigateButton.ToolTip.Description = string.Format(Resources.GO_TO_RECORD_TOOLTIP, num + 1);
		}

		private void UpdateNavigateButtons()
		{
			this.m_tableToolsGroup.Visible = false;
			this.TXITEM_FirstRecord.Enabled = this.m_iPreviewIndex > 0;
			this.TXITEM_PreviousRecord.Enabled = this.m_iPreviewIndex > 0;
			this.TXITEM_NextRecord.Enabled = this.m_iPreviewIndex < this.m_nPreviewCount - 1;
			this.TXITEM_LastRecord.Enabled = this.m_iPreviewIndex < this.m_nPreviewCount - 1;
		}

		private void Ribbon_TabIndexChanged(object sender, EventArgs e)
		{
			if (this.m_reportingPreviewGroup.Visible && this.m_ribbon.SelectedTab != this.m_previewTab)
			{
				this.HandleClosePreview();
			}
			else if (this.m_ribbon.SelectedTab == this.m_previewTab)
			{
				this.MemorizeShownSidebars();
			}
		}

		private void MemorizeShownSidebars()
		{
			List<Sidebar> source = new List<Sidebar>(base.Controls.OfType<Sidebar>());
			this.m_memorizedShownSidebars = new List<Sidebar>(source.Where((Sidebar x) => x.IsShown));
			foreach (Sidebar memorizedShownSidebar in this.m_memorizedShownSidebars)
			{
				memorizedShownSidebar.IsShown = false;
			}
		}

		private void ShowMemorizedShownSidebars()
		{
			if (this.m_memorizedShownSidebars == null || this.m_memorizedShownSidebars.Count <= 0)
			{
				return;
			}
			foreach (Sidebar memorizedShownSidebar in this.m_memorizedShownSidebars)
			{
				memorizedShownSidebar.IsShown = true;
			}
			this.m_memorizedShownSidebars.Clear();
		}

		private void HandleClosePreview()
		{
			this.m_textControl.EditMode = this.m_editMode;
			if (this.m_textControlContent != null)
			{
				this.m_textControl.Load(this.m_textControlContent, BinaryStreamType.InternalUnicodeFormat);
			}
			this.m_reportingPreviewGroup.Visible = false;
			this.TXITEM_Preview.Enabled = true;
			this.ShowMemorizedShownSidebars();
		}

		private void AddOpenSampleDbMenuButton()
		{
			this.m_mnuBtnOpenSampleDb = new RibbonButton
			{
				DisplayMode = IconTextRelation.SmallIconLabeled,
				Text = Resources.OPEN_SAMPLE_DB_MENU_BTN_TEXT,
				SmallIcon = Images.GetSmallIcon("DataSource_LoadSample")
			};
			this.m_mnuBtnOpenSampleDb.ToolTip.Description = Resources.OPEN_SAMPLE_DB_MENU_BTN_TOOLTIP;
			this.m_mnuBtnOpenSampleDb.Click += delegate
			{
				this.LoadSampleDB();
			};
			((RibbonSplitButton)this.m_reportingTab.FindItem(RibbonReportingTab.RibbonItem.TXITEM_DataSource)).DropDownItems.Insert(4, this.m_mnuBtnOpenSampleDb);
		}

		private void LoadSampleDB()
		{
			string fileName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\..\\sample_db.xml";
			try
			{
				this.m_reportingTab.DataSourceManager.LoadXmlFile(fileName);
				this.m_reportingTab.FindItem(RibbonReportingTab.RibbonItem.TXITEM_EditDataRelations).Enabled = true;
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message, base.ProductName, MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
			}
		}

		private void InitializeRibbon()
		{
			this.m_ribbon.SelectedIndex = 1;
			this.CustomizeReportingTab();
			this.CustomizePreviewTab();
			this.CustomizeViewTab();
			this.InitializeAppMenu();
			this.InitializeQuickAccessToolbar();
		}

		private void CustomizeViewTab()
		{
			this.AddAppViewGroup(this.m_viewTab);
		}

		private void CustomizeReportingTab()
		{
			this.AddOpenSampleDbMenuButton();
			this.AddFinishGroup();
		}

		private void CustomizePreviewTab()
		{
			this.m_reportingPreviewGroup.Header = Resources.CONTEXTUAL_TAB_GROUP_REPORTING;
			this.m_previewTab.Text = Resources.RIBBON_TAB_PREVIEW_HEADER;
			this.AddPreviewGroup();
			this.AddNavigateGroup();
		}

		private void InitializeQuickAccessToolbar()
		{
			this.m_btnUndo = new RibbonButton
			{
				Enabled = false
			};
			this.m_btnUndo.Click += delegate
			{
				this.m_textControl.Undo();
			};
			this.m_textControl.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
			{
				if (e.PropertyName == "CanUndo")
				{
					this.m_btnUndo.Enabled = this.m_textControl.CanUndo;
				}
			};
			this.m_btnUndo.Apply(ResourceProvider.GeneralItem.TXITEM_Undo.ToString(), base.DeviceDpi, RibbonButtonExtensions.RibbonButtonResource.ToolTip | RibbonButtonExtensions.RibbonButtonResource.Label | RibbonButtonExtensions.RibbonButtonResource.SmallImageSource);
			this.m_btnRedo = new RibbonButton
			{
				Enabled = false
			};
			this.m_btnRedo.Click += delegate
			{
				this.m_textControl.Redo();
			};
			this.m_textControl.PropertyChanged += delegate(object sender, PropertyChangedEventArgs e)
			{
				if (e.PropertyName == "CanRedo")
				{
					this.m_btnRedo.Enabled = this.m_textControl.CanRedo;
				}
			};
			this.m_btnRedo.Apply(ResourceProvider.GeneralItem.TXITEM_Redo.ToString(), base.DeviceDpi, RibbonButtonExtensions.RibbonButtonResource.ToolTip | RibbonButtonExtensions.RibbonButtonResource.Label | RibbonButtonExtensions.RibbonButtonResource.SmallImageSource);
			base.SetQuickAccessToolbarStandardItems(new RibbonButton[6] { this.m_btnAppMenu_TXITEM_Save, this.m_btnAppMenu_TXITEM_Open, this.m_btnAppMenu_TXITEM_New, this.m_btnUndo, this.m_btnRedo, this.m_btnAppMenu_TXITEM_Print });
		}

		private void m_horizontalSidebar_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			Sidebar sidebar = (Sidebar)sender;
			if (e.PropertyName == "ContentLayout")
			{
				if (sidebar.ContentLayout == Sidebar.SidebarContentLayout.TrackedChanges)
				{
					sidebar.ShowTitle = true;
				}
				else
				{
					sidebar.ShowTitle = false;
				}
			}
		}

		private void m_verticalRightSidebar_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			Sidebar sidebar = (Sidebar)sender;
			if (e.PropertyName == "ContentLayout")
			{
				switch (sidebar.ContentLayout)
				{
				case Sidebar.SidebarContentLayout.ConditionalInstructions:
					sidebar.ShowPinButton = true;
					break;
				case Sidebar.SidebarContentLayout.FieldNavigator:
				case Sidebar.SidebarContentLayout.Styles:
					sidebar.ShowPinButton = false;
					sidebar.IsPinned = true;
					break;
				default:
					sidebar.ShowPinButton = true;
					break;
				}
			}
		}

		private void m_verticalLeftSidebar_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			Sidebar sidebar = (Sidebar)sender;
			if (e.PropertyName == "ContentLayout")
			{
				switch (sidebar.ContentLayout)
				{
				case Sidebar.SidebarContentLayout.TrackedChanges:
					sidebar.ShowPinButton = true;
					break;
				case Sidebar.SidebarContentLayout.DocumentSettings:
					sidebar.IsPinned = true;
					sidebar.ShowPinButton = false;
					break;
				}
			}
			if (e.PropertyName == "IsShown" || e.PropertyName == "ContentLayout")
			{
				this.m_btnAppMenu_TXITEM_DocumentSettings.Checked = sidebar.IsShown && sidebar.ContentLayout == Sidebar.SidebarContentLayout.DocumentSettings;
			}
		}

		private void TextControl_InputPositionChanged(object sender, EventArgs e)
		{
			this.m_tableToolsGroup.Visible = this.m_textControl.Tables.GetItem() != null && !this.m_reportingPreviewGroup.Visible;
		}

		private void TextControl_Changed(object sender, EventArgs e)
		{
			this.m_fileHandler.IsDocumentDirty = true;
		}

		private void TextControl_TextContextMenuOpening(object sender, TextContextMenuEventArgs e)
		{
			if ((e.ContextMenuLocation & ContextMenuLocation.SelectedFrame) != 0)
			{
				this.AddFrameContextMenuItems(e.TextContextMenu);
			}
			if ((e.ContextMenuLocation & ContextMenuLocation.TextField) != 0)
			{
				this.AddFieldContextMenuItems(e.TextContextMenu);
			}
		}

		private void TextControl_PropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "CanPrint")
			{
				this.m_btnAppMenu_Print_TXITEM_Print.Enabled = this.m_textControl.CanPrint;
				this.m_btnAppMenu_TXITEM_Print.Enabled = this.m_textControl.CanPrint;
				this.m_btnAppMenu_Print_TXITEM_Print_Quick.Enabled = this.m_textControl.CanPrint;
				this.m_btnAppMenu_Print_TXITEM_Print_Preview.Enabled = this.m_textControl.CanPrint;
			}
		}

		private void TextControl_FrameSelected(object sender, FrameEventArgs e)
		{
			if (e.Frame is ChartFrame)
			{
				this.m_frameToolsGroup.Header = Resources.CONT_TAB_GRP_CHART_TOOLS;
				if (!this.m_frameToolsGroup.ContextualTabs.Contains(this.m_chartLayoutTab))
				{
					this.m_frameToolsGroup.ContextualTabs.Add(this.m_chartLayoutTab);
				}
			}
			this.m_frameToolsGroup.Visible = true;
		}

		private void TextControl_DrawingActivated(object sender, DrawingEventArgs e)
		{
			this.m_frameToolsGroup.Visible = true;
		}

		private void TextControl_FrameDeselected(object sender, FrameEventArgs e)
		{
			FrameBase item = this.m_textControl.Frames.GetItem();
			if (e.Frame is ChartFrame && !(item is ChartFrame))
			{
				this.m_frameToolsGroup.Header = Resources.CONT_TAB_GRP_FRAME_TOOLS;
				this.m_frameToolsGroup.ContextualTabs.Remove(this.m_chartLayoutTab);
			}
			if (item == null && this.m_textControl.Drawings.GetActivatedItem() == null)
			{
				this.m_frameToolsGroup.Visible = false;
			}
		}

		private void TextControl_DrawingDeactivated(object sender, DrawingEventArgs e)
		{
			if (this.m_textControl.Frames.GetItem() == null && this.m_textControl.Drawings.GetActivatedItem() == null)
			{
				this.m_frameToolsGroup.Visible = false;
			}
		}

		private void TextControl_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
			case Keys.Insert:
				if (!e.Control && !e.Alt && !e.Shift)
				{
					this.ToggleInsertionMode();
				}
				break;
			case Keys.A:
				if (e.Control && !e.Alt && !e.Shift)
				{
					this.m_textControl.SelectAll();
				}
				break;
			case Keys.S:
				if (e.Control && !e.Alt && !e.Shift)
				{
					this.m_fileHandler.Save();
				}
				break;
			case Keys.O:
				if (e.Control && !e.Alt && !e.Shift)
				{
					this.m_fileHandler.Open();
				}
				break;
			case Keys.F:
				if (e.Control && !e.Alt && !e.Shift)
				{
					this.m_textControl.Find();
				}
				break;
			case Keys.P:
				if (e.Control && !e.Alt && !e.Shift)
				{
					if (this.m_textControl.CanPrint)
					{
						this.m_textControl.Print(this.m_fileHandler.DocumentTitle + " - " + base.ProductName);
					}
					else
					{
						e.Handled = true;
					}
				}
				break;
			}
		}

		private void TextControl_DragDrop(object sender, DragEventArgs e)
		{
			if (this.m_dragDropHandler.CanDrop)
			{
				switch (this.m_dragDropHandler.FileType)
				{
				case FileDragDropHandler.DraggedFileType.Document:
					this.OpenDroppedDocument();
					break;
				case FileDragDropHandler.DraggedFileType.Image:
					this.InsertDroppedImage(e);
					break;
				}
			}
		}

		private void TextControl_DragEnter(object sender, DragEventArgs e)
		{
			this.m_dragDropHandler.Reset();
			this.m_dragDropHandler.CheckDraggedFiles((string[])e.Data.GetData(DataFormats.FileDrop));
		}

		private void TextControl_DragOver(object sender, DragEventArgs e)
		{
			if (this.m_dragDropHandler.CanDrop)
			{
				e.Effect = this.m_dragDropHandler.GetDragDropEffect(e.AllowedEffect);
			}
		}

		private void TextControl_HypertextLinkClicked(object sender, HypertextLinkEventArgs e)
		{
			this.OpenHyperlink(e.HypertextLink.Target);
		}

		private void ToggleInsertionMode()
		{
			this.m_textControl.InsertionMode = ((this.m_textControl.InsertionMode != InsertionMode.Insert) ? InsertionMode.Insert : InsertionMode.Overwrite);
		}

		private void OpenHyperlink(string strTarget)
		{
			if (strTarget == "")
			{
				return;
			}
			try
			{
				Uri uri = new Uri(strTarget, UriKind.RelativeOrAbsolute);
				if (!uri.IsAbsoluteUri)
				{
					throw new Exception(Resources.EXC_ONLY_ABS_PATH_SUPORTED);
				}
				if (uri.IsFile)
				{
					strTarget = uri.LocalPath;
					int num = strTarget.IndexOf("#");
					if (num != -1)
					{
						strTarget = strTarget.Substring(0, num);
					}
				}
				else if (uri.Scheme != Uri.UriSchemeHttp && uri.Scheme != Uri.UriSchemeHttps)
				{
					strTarget = uri.GetLeftPart(UriPartial.Path);
				}
				if (uri.IsFile && this.IsMyFile(strTarget))
				{
					this.OpenFileInNewInstance(strTarget);
				}
				else
				{
					Process.Start(strTarget);
				}
			}
			catch (Exception ex)
			{
				string text = ex.Message;
				if (!text.EndsWith("."))
				{
					text += ".";
				}
				TX_Text_Control_Words.Utils.MessageBox.Show(this, Resources.MSG_COULD_NOT_OPEN_LINK + " " + text, "Hyperlink");
			}
		}

		private void OpenFileInNewInstance(string strTarget)
		{
			if (!File.Exists(strTarget))
			{
				TX_Text_Control_Words.Utils.MessageBox.Show(this, string.Format(Resources.MSG_FILE_DOES_NOT_EXIST, strTarget), "Hyperlink");
				return;
			}
			string location = Assembly.GetEntryAssembly().Location;
			Process process = new Process();
			process.StartInfo.FileName = location;
			process.StartInfo.Arguments = "\"" + strTarget + "\"";
			process.Start();
		}

		private bool IsMyFile(string strTarget)
		{
			switch (Path.GetExtension(strTarget).ToLower())
			{
			case ".rtf":
			case ".doc":
			case ".docx":
			case ".tx":
				return true;
			default:
				return false;
			}
		}

		private void OpenDroppedDocument()
		{
			this.m_fileHandler.Open(this.m_dragDropHandler.FileName);
		}

		private void InsertDroppedImage(DragEventArgs e)
		{
			try
			{
				Point location = this.m_textControl.PointToClient(Cursor.Position);
				Paragraph item = this.m_textControl.Paragraphs.GetItem(location);
				Rectangle rectangle = this.m_textControl.TextChars[item.Start]?.Bounds ?? default(Rectangle);
				Rectangle rectangle2 = this.m_textControl.TextChars.GetItem(location, getNearest: true)?.Bounds ?? default(Rectangle);
				Point location2 = new Point(rectangle2.Left - rectangle.Left + rectangle2.Width, rectangle2.Top - rectangle.Top);
				TXTextControl.Image image = new TXTextControl.Image
				{
					FileName = this.m_dragDropHandler.FileName
				};
				this.m_textControl.Images.Add(image, location2, item.Start, ImageInsertionMode.DisplaceText);
			}
			catch (Exception ex)
			{
				TX_Text_Control_Words.Utils.MessageBox.Show(this, ex.Message, base.ProductName);
			}
		}

		private RibbonGroup AddAppViewGroup(RibbonTab tab)
		{
			RibbonGroup ribbonGroup = new RibbonGroup
			{
				Text = Resources.VIEWTAB_APPVIEWGROUP_HEADER,
				SmallIcon = Images.GetSmallIcon("AppViewGroup"),
				LargeIcon = Images.GetSmallIcon("AppViewGroup"),
				HorizontalContentAlignment = TXTextControl.HorizontalAlignment.Center
			};
			ribbonGroup.DialogBoxLauncher.Visible = false;
			this.AddRightToLeftFormLayoutButton(ribbonGroup);
			tab.RibbonGroups.Add(ribbonGroup);
			return ribbonGroup;
		}

		private void AddRightToLeftFormLayoutButton(RibbonGroup grp)
		{
			RibbonToggleButton rightToLeftFormLayoutBtn = new RibbonToggleButton
			{
				Text = Resources.VIEWTAB_APPVIEWGROUP_FLOWDIRECTION_LABEL,
				SmallIcon = Images.GetSmallIcon("FormLayoutRTL"),
				LargeIcon = Images.GetLargeIcon("FormLayoutRTL"),
				Checked = this.IsFormLayoutRightToLeft()
			};
			rightToLeftFormLayoutBtn.Click += delegate
			{
				this.SetFormLayoutToRightToLeft(rightToLeftFormLayoutBtn.Checked);
			};
			base.RightToLeftChanged += delegate
			{
				rightToLeftFormLayoutBtn.Checked = this.IsFormLayoutRightToLeft();
			};
			grp.RibbonItems.Add(rightToLeftFormLayoutBtn);
		}

		private bool IsFormLayoutRightToLeft()
		{
			return this.RightToLeft switch
			{
				RightToLeft.Yes => true, 
				RightToLeft.No => false, 
				_ => CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft, 
			};
		}

		private System.Windows.Forms.DialogResult SetFormLayoutToRightToLeft(bool booleanValue)
		{
			System.Windows.Forms.DialogResult num = TX_Text_Control_Words.Utils.MessageBox.Show(this, Resources.MSG_FLOWDIRECTIONCHANGED_TEXT, Resources.MSG_FLOWDIRECTIONCHANGED_TITLE, MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Asterisk);
			if (booleanValue)
			{
				Settings.Default.RightToLeft = RightToLeft.Yes;
			}
			else
			{
				Settings.Default.RightToLeft = RightToLeft.No;
			}
			Settings.Default.Save();
			if (num == System.Windows.Forms.DialogResult.Yes)
			{
				Application.Restart();
			}
			return num;
		}
	}
}
