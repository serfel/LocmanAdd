using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TX_Text_Control_Words.FileHandling;
using TX_Text_Control_Words.FormFields;
using TX_Text_Control_Words.Properties;
using TX_Text_Control_Words.User_Access_Control;
using TX_Text_Control_Words.Utils;
using TXTextControl;
using TXTextControl.DataVisualization;
using DocumentServer.Fields;
using TXTextControl.Drawing;
using TXTextControl.Windows.Forms;

namespace TX_Text_Control_Words
{
	public class MainWindow : Form
	{
		private enum FieldDisplayMode
		{
			ShowFieldText,
			ShowFieldCodes
		}

		private FieldDisplayMode m_fldDispModeCur;

		private HighlightMode m_bHighlightFields = HighlightMode.Activated;

		private FileHandler m_fileHandler;

		private FileDragDropHandler m_fileDragDropHandler;

		private UserAccessControl m_UAC;

		private const int DEFAULT_FORMFIELD_EMPTYWIDTH = 1701;

		private IContainer components;

		private ToolStripContainer toolStripContainer1;

		private MenuStrip menuStrip;

		private ToolStripMenuItem mnuFile;

		private ToolStripMenuItem mnuFile_Save;

		private ToolStripMenuItem mnuFile_SaveAs;

		private ToolStripSeparator menuItem6;

		private ToolStripMenuItem mnuFile_PageSetup;

		private ToolStripMenuItem mnuFile_PrintPreview;

		private ToolStripMenuItem mnuFile_Print;

		private ToolStripSeparator menuItem10;

		private ToolStripMenuItem mnuEdit;

		private ToolStripMenuItem mnuEdit_Undo;

		private ToolStripMenuItem mnuEdit_Redo;

		private ToolStripSeparator menuItem4;

		private ToolStripMenuItem mnuEdit_Cut;

		private ToolStripMenuItem mnuEdit_Copy;

		private ToolStripMenuItem mnuEdit_Paste;

		private ToolStripSeparator menuItem9;

		private ToolStripMenuItem mnuEdit_SelectAll;

		private ToolStripSeparator menuItem13;

		private ToolStripMenuItem mnuEdit_Find;

		private ToolStripMenuItem mnuEdit_Replace;

		private ToolStripSeparator mnuSeparatorEdit_Reviewing;

		private ToolStripMenuItem mnuEdit_Reviewing;

		private ToolStripMenuItem mnuEdit_Reviewing_TrackChanges;

		private ToolStripMenuItem mnuEdit_Reviewing_ReviewChanges;

		private ToolStripMenuItem mnuView;

		private ToolStripMenuItem mnuView_Draft;

		private ToolStripMenuItem mnuView_PageLayout;

		private ToolStripSeparator menuItem8;

		private ToolStripMenuItem mnuView_Toolbar;

		private ToolStripMenuItem mnuView_ButtonBar;

		private ToolStripMenuItem mnuView_StatusBar;

		private ToolStripMenuItem mnuView_HorizontalRuler;

		private ToolStripMenuItem mnuView_VerticalRuler;

		private ToolStripSeparator menuItem19;

		private ToolStripMenuItem mnuView_Zoom;

		private ToolStripMenuItem mnuView_Zoom_25;

		private ToolStripMenuItem mnuView_Zoom_50;

		private ToolStripMenuItem mnuView_Zoom_75;

		private ToolStripMenuItem mnuView_Zoom_100;

		private ToolStripMenuItem mnuView_Zoom_150;

		private ToolStripMenuItem mnuView_Zoom_200;

		private ToolStripMenuItem mnuView_Zoom_300;

		private ToolStripMenuItem mnuInsert;

		private ToolStripMenuItem mnuInsert_File;

		private ToolStripSeparator menuItem3;

		private ToolStripMenuItem mnuInsert_Image;

		private ToolStripSeparator toolStripSep_mnuInsert3;

		private ToolStripMenuItem mnuFormat;

		private ToolStripMenuItem mnuFormat_Character;

		private ToolStripMenuItem mnuFormat_Paragraph;

		private ToolStripMenuItem mnuFormat_Tabs;

		private ToolStripMenuItem mnuFormat_List;

		private ToolStripMenuItem mnuFormat_List_Attributes;

		private ToolStripMenuItem mnuFormat_List_IncreaseLevel;

		private ToolStripMenuItem mnuFormat_List_DecreaseLevel;

		private ToolStripMenuItem mnuFormat_List_ArabicNumbers;

		private ToolStripMenuItem mnuFormat_List_CapitalLetters;

		private ToolStripMenuItem mnuFormat_List_Letters;

		private ToolStripMenuItem mnuFormat_List_RomanNumbers;

		private ToolStripMenuItem mnuFormat_List_SmallRomanNumbers;

		private ToolStripMenuItem mnuFormat_List_Bullets;

		private ToolStripMenuItem mnuFormat_Styles;

		private ToolStripMenuItem mnuFormat_Image;

		private ToolStripMenuItem mnuTable;

		private ToolStripMenuItem mnuTable_Insert;

		private ToolStripMenuItem mnuTable_Insert_Table;

		private ToolStripMenuItem mnuTable_Insert_ColumnToTheLeft;

		private ToolStripMenuItem mnuTable_Insert_ColumnToTheRight;

		private ToolStripMenuItem mnuTable_Insert_RowAbove;

		private ToolStripMenuItem mnuTable_Insert_RowBelow;

		private ToolStripMenuItem mnuTable_Delete;

		private ToolStripMenuItem mnuTable_Delete_Table;

		private ToolStripMenuItem mnuTable_Delete_Column;

		private ToolStripMenuItem mnuTable_Delete_Rows;

		private ToolStripMenuItem mnuTable_Split;

		private ToolStripMenuItem mnuTable_Split_Above;

		private ToolStripMenuItem mnuTable_Split_Below;

		private ToolStripMenuItem mnuTable_Select;

		private ToolStripMenuItem mnuTable_Select_Table;

		private ToolStripMenuItem mnuTable_Select_Row;

		private ToolStripMenuItem mnuTable_Select_Cell;

		private ToolStripMenuItem mnuTable_GridLines;

		private ToolStripMenuItem mnuTable_Properties;

		private ToolStripMenuItem mnuHelp;

		private ToolStripMenuItem mnuHelp_AboutTXTextControlWords;

		private ToolStripMenuItem mnuFile_New;

		private ToolStripMenuItem mnuFile_Open;

		private ToolStripSeparator toolStripMenuItem1;

		private ToolStripMenuItem mnuFile_Exit;

		private ToolStrip toolStrip;

		private ToolStripButton mnuBtnNewFile;

		private ToolStripButton mnuBtnOpenFile;

		private ToolStripButton mnuBtnSave;

		private ToolStripSeparator toolStripSeparator1;

		private TXTextControl.StatusBar m_statusBar;

		private RulerBar m_verticalRulerBar;

		private RulerBar m_horizontalRulerBar;

		private TextControl textControl;

		private ButtonBar m_buttonBar;

		private ToolStripButton mnuBtnPrint;

		private ToolStripButton mnuBtnPrintPreview;

		private ToolStripSeparator toolStripSeparator2;

		private ToolStripButton mnuBtnCut;

		private ToolStripButton mnuBtnCopy;

		private ToolStripButton mnuBtnPaste;

		private ToolStripSeparator toolStripSeparator3;

		private ToolStripButton mnuBtnUndo;

		private ToolStripButton mnuBtnRedo;

		private ToolStripButton mnuBtnFind;

		private ToolStripSeparator menuItem28;

		private ToolStripSeparator menuItem21;

		private ToolStripSeparator menuItem24;

		private ToolStripMenuItem mnuFile_RecentFiles;

		private ToolStripMenuItem mnuTable_Select_Column;

		private ToolStripMenuItem mnuTable_Merge_Cells;

		private ToolStripMenuItem mnuTable_Split_Cells;

		private ToolStripMenuItem mnuTable_Delete_Cells;

		private ToolStripMenuItem mnuTable_Delete_Cells_shiftLeft;

		private ToolStripMenuItem mnuTable_Delete_Cells_entireRow;

		private ToolStripMenuItem mnuTable_Delete_Cells_entireColumn;

		private ToolStripSeparator toolStripSep_mnuTable1;

		private ToolStripMenuItem mnuFile_Export;

		private ToolStripSeparator menuItem16;

		private ToolStripMenuItem mnuEdit_Hyperlink;

		private ToolStripMenuItem mnuEdit_Target;

		private ToolStripMenuItem mnuView_HeadersAndFooters;

		private ToolStripSeparator menuItem12;

		private ToolStripMenuItem mnuInsert_TextFrame;

		private ToolStripSeparator toolStripSep_mnuInsert2;

		private ToolStripMenuItem mnuInsert_Hyperlink;

		private ToolStripMenuItem mnuInsert_Target;

		private ToolStripMenuItem mnuFormat_TextFrame;

		private ToolStripMenuItem mnuFormat_Shape;

		private ToolStripSeparator toolStripSeparator444;

		private ToolStripSeparator toolStripSeparator445;

		private ToolStripMenuItem mnuInsert_Break;

		private ToolStripMenuItem mnuFormat_HeadersAndFooters;

		private ToolStripButton mnuBtnColumns;

		private ToolStripMenuItem mnuFormat_Columns;

		private ToolStripMenuItem mnuFormat_PageBorders;

		private ToolStripSeparator toolStripSep_mnuInsert1;

		private ToolStripMenuItem mnuInsert_Fields;

		private ToolStripMenuItem mnuInsert_Fields_insertMergeField;

		private ToolStripMenuItem mnuInsert_Fields_insertSpecialField;

		private ToolStripMenuItem mnuInsert_Fields_insertSpecialField_IF;

		private ToolStripMenuItem mnuInsert_Fields_insertSpecialField_inclText;

		private ToolStripMenuItem mnuInsert_Fields_insertSpecialField_date;

		private ToolStripMenuItem mnuInsert_Fields_highlightMergeFields;

		private ToolStripSeparator toolStripSeparator14;

		private ToolStripMenuItem mnuInsert_Fields_showFieldCodes;

		private ToolStripMenuItem mnuInsert_Fields_showFieldText;

		private ToolStripMenuItem mnuInsert_Symbol;

		private ToolStripMenuItem mnuInsert_pageNum;

		private ToolStripMenuItem mnuInsert_PageNum_Insert;

		private ToolStripMenuItem mnuInsert_Fields_deleteField;

		private ToolStripMenuItem mnuInsert_PageNum_Delete;

		private ToolStripSeparator sep_pageNum01;

		private ToolStripSeparator sep_field01;

		private ToolStripMenuItem mnuInsert_Chart;

		private ToolStripMenuItem mnuInsert_chart_area;

		private ToolStripMenuItem mnuInsert_chart_bar;

		private ToolStripMenuItem mnuInsert_chart_column;

		private ToolStripMenuItem mnuInsert_chart_clusteredBar;

		private ToolStripMenuItem mnuInsert_chart_pie;

		private ToolStripSeparator menuItem20;

		private ToolStripMenuItem mnuView_TextFrameMarkerLines;

		private ToolStripMenuItem mnuView_DrawingMarkerLines;

		private ToolStripMenuItem mnuView_DocumentTargetMarkers;

		private ToolStripSeparator toolStripMenuItem2;

		private ToolStripSeparator toolStripSeparator5;

		private ToolStripSeparator toolStripSeparator6;

		private ToolStripMenuItem mnuView_FormLayout;

		private ToolStripButton mnuBtnMarginsAndPaper;

		private ToolStripButton mnuBtnHeadersAndFooters;

		private ToolStripButton mnuBtnPageBorders;

		private ToolStripMenuItem mnuInsert_Fields_insertSpecialField_next;

		private ToolStripMenuItem mnuInsert_Fields_insertSpecialField_nextif;

		private ToolStripMenuItem mnuInsert_Shapes;

		private ToolStripMenuItem mnuInsert_Shapes_Lines;

		private ToolStripMenuItem mnuInsert_Shapes_Rectangles;

		private ToolStripMenuItem mnuInsert_Shapes_Basic;

		private ToolStripMenuItem mnuInsert_Shapes_BlockArrows;

		private ToolStripMenuItem mnuInsert_Shapes_Equation;

		private ToolStripMenuItem mnuInsert_Shapes_FlowChart;

		private ToolStripMenuItem mnuInsert_Shapes_StarsBanners;

		private ToolStripMenuItem mnuInsert_Shapes_Callouts;

		private ToolStripSeparator sepShapeCat;

		private ToolStripMenuItem mnuInsert_Shapes_DrawingCanvas;

		private ToolStripButton mnuBtnSelectObjects;

		private ToolStripSeparator toolStripMenuItem3;

		private ToolStripMenuItem mnuEdit_Permissions;

		private ToolStripMenuItem mnuEdit_Permissions_ReadOnly;

		private ToolStripMenuItem mnuEdit_Permissions_AllowCopy;

		private ToolStripMenuItem mnuEdit_Permissions_AllowFormatting;

		private ToolStripMenuItem mnuEdit_Permissions_AllowFormattingStyles;

		private ToolStripMenuItem mnuEdit_Permissions_AllowPrinting;

		private ToolStripMenuItem mnuEdit_ProtectDocument;

		private ToolStripSeparator toolStripMenuItem4;

		private ToolStripMenuItem mnuInsert_EditableRegion;

		private ToolStripMenuItem mnuInsert_EditableRegion_Add;

		private ToolStripMenuItem mnuInsert_EditableRegion_Add_User;

		private ToolStripMenuItem mnuInsert_EditableRegion_Add_Everyone;

		private ToolStripMenuItem mnuInsert_EditableRegion_Remove;

		private ToolStripMenuItem mnuInsert_EditableRegion_Remove_User;

		private ToolStripMenuItem mnuInsert_EditableRegion_Remove_Everyone;

		private ToolStripMenuItem mnuFile_UserAccess;

		private ToolStripMenuItem mnuFormat_Language;

		private ToolStripSeparator toolStripSeparator4;

		private ToolStripMenuItem mnuFile_Options;

		private ToolStripMenuItem mnuFile_UserManagement;

		private ToolStripMenuItem mnuFormat_ChartLayout;

		private ToolStripMenuItem mnuFormat_ChartLayout_ChartTitle;

		private ToolStripMenuItem mnuFormat_ChartLayout_ChartTitle_None;

		private ToolStripMenuItem mnuFormat_ChartLayout_ChartTitle_CenteredOverlay;

		private ToolStripMenuItem mnuFormat_ChartLayout_ChartTitle_AboveChart;

		private ToolStripMenuItem mnuFormat_ChartLayout_AxisTitles;

		private ToolStripMenuItem mnuFormat_ChartLayout_AxisTitles_None;

		private ToolStripMenuItem mnuFormat_ChartLayout_AxisTitles_BelowChart;

		private ToolStripMenuItem mnuFormat_ChartLayout_AxisTitles_Vertical;

		private ToolStripMenuItem mnuFormat_ChartLayout_Legend;

		private ToolStripMenuItem mnuFormat_ChartLayout_Legend_None;

		private ToolStripMenuItem mnuFormat_ChartLayout_Legend_Top;

		private ToolStripMenuItem mnuFormat_ChartLayout_Legend_Right;

		private ToolStripMenuItem mnuFormat_ChartLayout_Legend_Bottom;

		private ToolStripMenuItem mnuFormat_ChartLayout_Legend_Left;

		private ToolStripMenuItem mnuFormat_ChartLayout_DataLabels;

		private ToolStripMenuItem mnuFormat_ChartLayout_DataLabels_None;

		private ToolStripMenuItem mnuFormat_ChartLayout_DataLabels_OutsideEnd;

		private ToolStripSeparator toolStripSep_menu_chartLayout;

		private ToolStripMenuItem mnuFormat_ChartLayout_Axes;

		private ToolStripMenuItem mnuFormat_ChartLayout_Axes_leftToRight;

		private ToolStripMenuItem mnuFormat_ChartLayout_Axes_withoutLabeling;

		private ToolStripMenuItem mnuFormat_ChartLayout_HorGridLines;

		private ToolStripMenuItem mnuFormat_ChartLayout_HorizGridlines_None;

		private ToolStripMenuItem mnuFormat_ChartLayout_HorizGridlines_Major;

		private ToolStripMenuItem mnuFormat_ChartLayout_HorizGridlines_Minor;

		private ToolStripMenuItem mnuFormat_ChartLayout_HorizGridlines_MajAndMin;

		private ToolStripMenuItem mnuFormat_ChartLayout_VertGridLines;

		private ToolStripMenuItem mnuFormat_ChartLayout_VertGridlines_None;

		private ToolStripMenuItem mnuFormat_ChartLayout_VertGridlines_Major;

		private ToolStripMenuItem mnuFormat_ChartLayout_VertGridlines_Minor;

		private ToolStripMenuItem mnuFormat_ChartLayout_VertGridlines_MajAndMin;

		private ToolStripMenuItem mnuView_Zoom_400;

		private ToolStripSeparator toolStripSeparator7;

		private ToolStripSeparator toolStripSeparator8;

		private ToolStripSeparator toolStripSeparator9;

		private ToolStripMenuItem mnuTable_Formulas;

		private ToolStripMenuItem mnuTable_Formulas_A1Style;

		private ToolStripMenuItem mnuTable_Formulas_R1C1Style;

		private ToolStripSeparator toolStripSeparator11;

		private ToolStripMenuItem mnuTable_Formulas_EditFormula;

		private ToolStripSeparator toolStripSeparator10;

		private ToolStripMenuItem mnuTable_Formulas_AutomaticCalculation;

		private ToolStripSeparator toolStripSeparator12;

		private ToolStripMenuItem mnuInsert_FormFields;

		private ToolStripMenuItem mnuInsert_FormFields_TextFormField;

		private ToolStripMenuItem mnuInsert_FormFields_CheckFormField;

		private ToolStripMenuItem mnuInsert_FormFields_ComboBoxFormField;

		private ToolStripMenuItem mnuInsert_FormFields_DropDownListFormField;

		private ToolStripMenuItem mnuFormat_FormFields;

		private ToolStripMenuItem mnuFormat_FormFields_Properties;

		private ToolStripSeparator toolStripSeparator16;

		private ToolStripMenuItem mnuFormat_FormFields_Delete;

		private ToolStripSeparator toolStripSeparator13;

		private ToolStripMenuItem mnuEdit_Permissions_AllowEditingFormFields;

		private ToolStripMenuItem mnuInsert_FormFields_DatePicker;

		private ToolStripSeparator toolStripMenuItem5;

		private ToolStripMenuItem mnuFormat_FormFields_ConditionalInstructions;

		private ToolStripMenuItem mnuFormat_FormFields_IsFormFieldValidationEnabled;

		private ToolStripMenuItem mnuEdit_TableOfContents;

		private ToolStripMenuItem mnuEdit_TableOfContents_Edit;

		private ToolStripMenuItem mnuEdit_TableOfContents_Update;

		private ToolStripMenuItem mnuEdit_TableOfContents_Delete;

		private ToolStripMenuItem mnuInsert_TableOfContents;

		private void SetAxisTitle(Axis axis)
		{
			InputBoxDialog inputBoxDialog = new InputBoxDialog(Resources.INPUTBOXDLG_SETAXISTITLE_TITLE, axis.Title)
			{
				SelectedFont = axis.TitleFont,
				HasFontButton = true,
				RightToLeft = this.RightToLeft
			};
			if (inputBoxDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				axis.Title = inputBoxDialog.TextInput;
				axis.TitleFont = inputBoxDialog.SelectedFont;
			}
		}

		private void SetChartTitleAboveChart()
		{
			ChartFrame item = this.textControl.Frames.GetItem<ChartFrame>();
			if (item != null)
			{
				this.SetFirstChartTitle();
				Chart chart = (Chart)item.Chart;
				if (chart.Titles.Count != 0)
				{
					chart.Titles[0].DockedToChartArea = string.Empty;
					item.Refresh();
				}
			}
		}

		private void SetChartTitleCenteredOverlay()
		{
			ChartFrame item = this.textControl.Frames.GetItem<ChartFrame>();
			if (item != null)
			{
				this.SetFirstChartTitle();
				Chart chart = (Chart)item.Chart;
				if (chart.Titles.Count != 0)
				{
					chart.Titles[0].DockedToChartArea = chart.ChartAreas[0].Name;
					item.Refresh();
				}
			}
		}

		private void SetFirstChartTitle()
		{
			ChartFrame item = this.textControl.Frames.GetItem<ChartFrame>();
			if (item == null)
			{
				return;
			}
			Chart chart = (Chart)item.Chart;
			Title title = ((chart.Titles.Count == 0) ? new Title() : chart.Titles[0]);
			InputBoxDialog inputBoxDialog = new InputBoxDialog(Resources.INPUTBOXDLG_SETCHARTTITLE_TITLE, title.Text)
			{
				SelectedFont = title.Font,
				HasFontButton = true
			};
			if (inputBoxDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK && !(inputBoxDialog.TextInput == string.Empty))
			{
				title.Text = inputBoxDialog.TextInput;
				title.Font = inputBoxDialog.SelectedFont;
				if (chart.Titles.Count == 0)
				{
					chart.Titles.Add(title);
				}
			}
		}

		private void ClearChartAxisTitles()
		{
			ChartFrame item = this.textControl.Frames.GetItem<ChartFrame>();
			if (item != null)
			{
				Chart chart = (Chart)item.Chart;
				chart.ChartAreas[0].AxisX.Title = string.Empty;
				chart.ChartAreas[0].AxisY.Title = string.Empty;
				item.Refresh();
			}
		}

		private void ClearChartTitles()
		{
			ChartFrame item = this.textControl.Frames.GetItem<ChartFrame>();
			if (item != null)
			{
				Chart chart = (Chart)item.Chart;
				chart.Titles.Clear();
				item.Refresh();
			}
		}

		private void EditChartData()
		{
			ChartFrame item = this.textControl.Charts.GetItem();
			if (item != null)
			{
				ChartDataGridDialog.ShowDialog(item, this);
			}
		}

		private void InsertMSChart(SeriesChartType chartType, bool is3D)
		{
			try
			{
				this.textControl.Charts.GetItem();
				Chart chart = new Chart();
				chart.TextAntiAliasingQuality = TextAntiAliasingQuality.Normal;
				chart.Size = new Size(500, 400);
				ChartingHelper.FillChartWithDummyData(chart, chartType);
				chart.SetIs3D(is3D);
				ChartFrame chartFrame = new ChartFrame(chart);
				this.textControl.Charts.Add(chartFrame, TXTextControl.HorizontalAlignment.Left, -1, FrameInsertionMode.DisplaceCompleteLines);
				Application.DoEvents();
				ChartDataGridDialog.ShowDialog(chartFrame, this);
			}
			catch (Exception ex)
			{
				TX_Text_Control_Words.Utils.MessageBox.Show(this, ex.Message, base.ProductName, MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
			}
		}

		private void InsertMSChart(string chartType, bool is3D)
		{
			switch (chartType)
			{
			case "Pie":
				this.InsertMSChart(SeriesChartType.Pie, is3D);
				break;
			case "Bar":
				this.InsertMSChart(SeriesChartType.Bar, is3D);
				break;
			case "Column":
				this.InsertMSChart(SeriesChartType.Column, is3D);
				break;
			case "Line":
				this.InsertMSChart(SeriesChartType.Line, is3D);
				break;
			case "Area":
				this.InsertMSChart(SeriesChartType.Area, is3D);
				break;
			}
		}

		private void InsertPageNumber()
		{
			try
			{
				object item = this.textControl.TextParts.GetItem();
				if (item is HeaderFooter)
				{
					HeaderFooter headerFooter = (HeaderFooter)item;
					PageNumberField pageNumberField = new PageNumberField
					{
						StartNumber = 1,
						Editable = false,
						DoubledInputPosition = true,
						HighlightMode = HighlightMode.Activated
					};
					headerFooter.PageNumberFields.Add(pageNumberField);
				}
			}
			catch (Exception ex)
			{
				TX_Text_Control_Words.Utils.MessageBox.Show(this, ex.Message, base.ProductName, MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
			}
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
					throw new Exception("Only absolute file paths / links are supported.");
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

		private void RemovePageNumbers()
		{
			Section section = null;
			try
			{
				section = this.textControl.Sections.GetItem();
				if (section == null)
				{
					return;
				}
				foreach (HeaderFooter headersAndFooter in section.HeadersAndFooters)
				{
					headersAndFooter.PageNumberFields.Clear(keepText: false);
				}
			}
			catch (Exception ex)
			{
				TX_Text_Control_Words.Utils.MessageBox.Show(this, ex.Message, base.ProductName, MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
			}
		}

		private void SetAxisTitlesBelowChart()
		{
			ChartFrame item = this.textControl.Frames.GetItem<ChartFrame>();
			if (item != null)
			{
				Chart chart = (Chart)item.Chart;
				this.SetAxisTitle(chart.ChartAreas[0].AxisX);
				item.Refresh();
			}
		}

		private void SetVerticalAxisTitle()
		{
			ChartFrame item = this.textControl.Frames.GetItem<ChartFrame>();
			if (item != null)
			{
				Chart chart = (Chart)item.Chart;
				this.SetAxisTitle(chart.ChartAreas[0].AxisY);
				item.Refresh();
			}
		}

		private void DisableChartLegend()
		{
			ChartFrame item = this.textControl.Frames.GetItem<ChartFrame>();
			if (item != null)
			{
				Chart chart = (Chart)item.Chart;
				chart.Legends[0].Enabled = false;
				item.Refresh();
			}
		}

		private void SetChartLegendTop()
		{
			ChartFrame item = this.textControl.Frames.GetItem<ChartFrame>();
			if (item != null)
			{
				Chart chart = (Chart)item.Chart;
				Legend legend = chart.Legends[0];
				legend.Enabled = true;
				legend.Docking = Docking.Top;
				item.Refresh();
			}
		}

		private void SetChartLegendRight()
		{
			ChartFrame item = this.textControl.Frames.GetItem<ChartFrame>();
			if (item != null)
			{
				Chart chart = (Chart)item.Chart;
				Legend legend = chart.Legends[0];
				legend.Enabled = true;
				legend.Docking = Docking.Right;
				item.Refresh();
			}
		}

		private void SetChartLegendBottom()
		{
			ChartFrame item = this.textControl.Frames.GetItem<ChartFrame>();
			if (item != null)
			{
				Chart chart = (Chart)item.Chart;
				Legend legend = chart.Legends[0];
				legend.Enabled = true;
				legend.Docking = Docking.Bottom;
				item.Refresh();
			}
		}

		private void SetChartLegendLeft()
		{
			ChartFrame item = this.textControl.Frames.GetItem<ChartFrame>();
			if (item != null)
			{
				Chart chart = (Chart)item.Chart;
				Legend legend = chart.Legends[0];
				legend.Enabled = true;
				legend.Docking = Docking.Left;
				item.Refresh();
			}
		}

		private void RemoveChartDataLabels()
		{
			ChartFrame item = this.textControl.Frames.GetItem<ChartFrame>();
			if (item == null)
			{
				return;
			}
			Chart chart = (Chart)item.Chart;
			foreach (Series item2 in chart.Series)
			{
				item2.IsValueShownAsLabel = false;
			}
			item.Refresh();
		}

		private void SetChartDataLabelsOutsideEnd()
		{
			ChartFrame item = this.textControl.Frames.GetItem<ChartFrame>();
			if (item == null)
			{
				return;
			}
			Chart chart = (Chart)item.Chart;
			foreach (Series item2 in chart.Series)
			{
				item2.IsValueShownAsLabel = true;
			}
			item.Refresh();
		}

		private void SetChartAxesLeftToRight()
		{
			ChartFrame item = this.textControl.Frames.GetItem<ChartFrame>();
			if (item != null)
			{
				Chart chart = (Chart)item.Chart;
				ChartArea chartArea = chart.ChartAreas[0];
				chartArea.AxisX.Enabled = AxisEnabled.True;
				item.Refresh();
			}
		}

		private void RemoveLabelsFromAxes()
		{
			ChartFrame item = this.textControl.Frames.GetItem<ChartFrame>();
			if (item != null)
			{
				Chart chart = (Chart)item.Chart;
				ChartArea chartArea = chart.ChartAreas[0];
				chartArea.AxisX.Enabled = AxisEnabled.False;
				item.Refresh();
			}
		}

		private void RemoveHorizChartGridLines()
		{
			ChartFrame item = this.textControl.Frames.GetItem<ChartFrame>();
			if (item != null)
			{
				Chart chart = (Chart)item.Chart;
				Axis axisY = chart.ChartAreas[0].AxisY;
				axisY.MajorGrid.Enabled = false;
				axisY.MinorGrid.Enabled = false;
				item.Refresh();
			}
		}

		private void SetMajorHorizChartGridLines()
		{
			ChartFrame item = this.textControl.Frames.GetItem<ChartFrame>();
			if (item != null)
			{
				Chart chart = (Chart)item.Chart;
				Axis axisY = chart.ChartAreas[0].AxisY;
				axisY.MajorGrid.Enabled = true;
				item.Refresh();
			}
		}

		private void SetMinorHorizChartGridLines()
		{
			ChartFrame item = this.textControl.Frames.GetItem<ChartFrame>();
			if (item != null)
			{
				Chart chart = (Chart)item.Chart;
				Axis axisY = chart.ChartAreas[0].AxisY;
				axisY.MinorGrid.Enabled = true;
				item.Refresh();
			}
		}

		private void SetMajAndMinHorizChartGridLines()
		{
			ChartFrame item = this.textControl.Frames.GetItem<ChartFrame>();
			if (item != null)
			{
				Chart chart = (Chart)item.Chart;
				Axis axisY = chart.ChartAreas[0].AxisY;
				axisY.MajorGrid.Enabled = true;
				axisY.MinorGrid.Enabled = true;
				item.Refresh();
			}
		}

		private void RemoveChartGridLines()
		{
			ChartFrame item = this.textControl.Frames.GetItem<ChartFrame>();
			if (item != null)
			{
				Chart chart = (Chart)item.Chart;
				Axis axisX = chart.ChartAreas[0].AxisX;
				axisX.MajorGrid.Enabled = false;
				axisX.MinorGrid.Enabled = false;
				item.Refresh();
			}
		}

		private void SetMajorVertChartGridLines()
		{
			ChartFrame item = this.textControl.Frames.GetItem<ChartFrame>();
			if (item != null)
			{
				Chart chart = (Chart)item.Chart;
				Axis axisX = chart.ChartAreas[0].AxisX;
				axisX.MajorGrid.Enabled = true;
				item.Refresh();
			}
		}

		private void SetMinorVertChartGridLines()
		{
			ChartFrame item = this.textControl.Frames.GetItem<ChartFrame>();
			if (item != null)
			{
				Chart chart = (Chart)item.Chart;
				Axis axisX = chart.ChartAreas[0].AxisX;
				axisX.MinorGrid.Enabled = true;
				item.Refresh();
			}
		}

		private void SetMajAndMinVertChartGridLines()
		{
			ChartFrame item = this.textControl.Frames.GetItem<ChartFrame>();
			if (item != null)
			{
				Chart chart = (Chart)item.Chart;
				Axis axisX = chart.ChartAreas[0].AxisX;
				axisX.MajorGrid.Enabled = true;
				axisX.MinorGrid.Enabled = true;
				item.Refresh();
			}
		}

		private bool TryInsertMSChart(string chartType, bool is3D)
		{
			try
			{
				this.InsertMSChart(chartType, is3D);
				return true;
			}
			catch
			{
				MSChartLinkDialog.Show(this);
			}
			return false;
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

		private void FileHandler_PropertyChanged_CanSave(object sender, PropertyChangedEventArgs e)
		{
			string propertyName = e.PropertyName;
			if (propertyName == "CanSave")
			{
				this.mnuFile_Save.Enabled = this.m_fileHandler.CanSave;
				this.mnuBtnSave.Enabled = this.m_fileHandler.CanSave;
			}
		}

		private void FileHandler_DocumentFileNameChanged(object sender, DocumentFileNameChangedEventArgs e)
		{
			this.SetWindowTitle(this.m_fileHandler.DocumentTitle, this.m_fileHandler.IsDocumentDirty);
		}

		private void FileHandler_RecentFileListChanged(object sender, EventArgs e)
		{
			this.UpdateToolbar_SetRecentItemsList(this.m_fileHandler.RecentFiles);
		}

		private void FileHandler_UserInputRequested(object sender, UserInputRequestedEventArgs e)
		{
			UserPromptDialog userPromptDialog = new UserPromptDialog(e.Caption, e.Label, e.Value)
			{
				ShowIcon = false,
				RightToLeft = this.RightToLeft,
				IsPassword = e.IsPasswordRequest
			};
			if (userPromptDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				e.DialogResult = TX_Text_Control_Words.FileHandling.DialogResult.OK;
				e.Value = userPromptDialog.Value;
			}
		}

		private void SetDefaultFieldAndBlockProperties()
		{
			try
			{
				foreach (IFormattedText textPart in this.textControl.TextParts)
				{
					foreach (ApplicationField applicationField in textPart.ApplicationFields)
					{
						if (applicationField.TypeName == "IF" && applicationField.Length == 0)
						{
							applicationField.Text = "{IF}";
						}
						applicationField.Editable = false;
						applicationField.DoubledInputPosition = true;
						applicationField.HighlightMode = this.m_bHighlightFields;
					}
				}
			}
			catch
			{
			}
		}

		private MergeField InsertMergeField(string strName)
		{
			MergeField mergeField = this.CreateMergeField(strName);
			this.textControl.ApplicationFields.Add(mergeField.ApplicationField);
			return mergeField;
		}

		private MergeField CreateMergeField(string strName)
		{
			MergeField mergeField = new MergeField();
			mergeField.ApplicationField.DoubledInputPosition = true;
			mergeField.ApplicationField.Editable = false;
			mergeField.ApplicationField.HighlightMode = this.m_bHighlightFields;
			if (strName != string.Empty)
			{
				mergeField.Name = strName;
				switch (this.m_fldDispModeCur)
				{
				case FieldDisplayMode.ShowFieldCodes:
				{
					string text = ((mergeField.ApplicationField.Parameters != null) ? string.Join(" ", mergeField.ApplicationField.Parameters) : "");
					mergeField.Text = "{" + mergeField.TypeName + text + " }";
					break;
				}
				case FieldDisplayMode.ShowFieldText:
					mergeField.Text = "«" + strName + "»";
					break;
				}
			}
			return mergeField;
		}

		private void InsertMergeField()
		{
			bool rightToLeft = this.RightToLeft == RightToLeft.Yes;
			MergeField mergeField = this.CreateMergeField("");
			if (mergeField.ShowDialog(this, rightToLeft) == DocumentServer.Fields.DialogResult.OK)
			{
				mergeField.Text = "«" + mergeField.Name + "»";
				this.textControl.ApplicationFields.Add(mergeField.ApplicationField);
			}
		}

		private void InsertIfField()
		{
			bool rightToLeft = this.RightToLeft == RightToLeft.Yes;
			IfField ifField = new IfField();
			ifField.ApplicationField.DoubledInputPosition = true;
			ifField.ApplicationField.Editable = false;
			ifField.ApplicationField.HighlightMode = this.m_bHighlightFields;
			if (ifField.ShowDialog(this, rightToLeft) == DocumentServer.Fields.DialogResult.OK)
			{
				this.textControl.ApplicationFields.Add(ifField.ApplicationField);
			}
		}

		private void InsertNextField()
		{
			NextField nextField = new NextField();
			nextField.ApplicationField.DoubledInputPosition = true;
			nextField.ApplicationField.Editable = false;
			nextField.ApplicationField.HighlightMode = this.m_bHighlightFields;
			this.textControl.ApplicationFields.Add(nextField.ApplicationField);
		}

		private void InsertNextIfField()
		{
			bool rightToLeft = this.RightToLeft == RightToLeft.Yes;
			NextIfField nextIfField = new NextIfField();
			nextIfField.ApplicationField.DoubledInputPosition = true;
			nextIfField.ApplicationField.Editable = false;
			nextIfField.ApplicationField.HighlightMode = this.m_bHighlightFields;
			if (nextIfField.ShowDialog(this, rightToLeft) == DocumentServer.Fields.DialogResult.OK)
			{
				this.textControl.ApplicationFields.Add(nextIfField.ApplicationField);
			}
		}

		private void InsertDateField()
		{
			bool rightToLeft = this.RightToLeft == RightToLeft.Yes;
			DateField dateField = new DateField
			{
				Format = "dd.MM.yyyy"
			};
			dateField.ApplicationField.DoubledInputPosition = true;
			dateField.ApplicationField.Editable = false;
			dateField.ApplicationField.HighlightMode = this.m_bHighlightFields;
			if (dateField.ShowDialog(this, rightToLeft) == DocumentServer.Fields.DialogResult.OK)
			{
				this.textControl.ApplicationFields.Add(dateField.ApplicationField);
			}
		}

		private void InsertIncludeTextField()
		{
			bool rightToLeft = this.RightToLeft == RightToLeft.Yes;
			IncludeText includeText = new IncludeText();
			includeText.ApplicationField.DoubledInputPosition = true;
			includeText.ApplicationField.Editable = false;
			includeText.ApplicationField.HighlightMode = this.m_bHighlightFields;
			if (includeText.ShowDialog(this, rightToLeft) == DocumentServer.Fields.DialogResult.OK)
			{
				this.textControl.ApplicationFields.Add(includeText.ApplicationField);
			}
		}

		private void DeleteField()
		{
			try
			{
				ApplicationField item = this.textControl.ApplicationFields.GetItem();
				if (item != null)
				{
					this.textControl.ApplicationFields.Remove(item);
				}
			}
			catch (Exception ex)
			{
				TX_Text_Control_Words.Utils.MessageBox.Show(this, ex.Message, base.ProductName, MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
			}
		}

		private bool FieldAtCurrentPos()
		{
			try
			{
				ApplicationField item = this.textControl.ApplicationFields.GetItem();
				return item != null;
			}
			catch
			{
				return false;
			}
		}

		private void FieldSettings()
		{
			bool rightToLeft = this.RightToLeft == RightToLeft.Yes;
			try
			{
				ApplicationField item = this.textControl.ApplicationFields.GetItem();
				if (item == null)
				{
					TX_Text_Control_Words.Utils.MessageBox.Show(this, Resources.MSG_FIELDNOTAVAILABLE, base.ProductName, MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
					return;
				}
				switch (item.TypeName)
				{
				case "MERGEFIELD":
				{
					MergeField mergeField = new MergeField(item);
					mergeField.ShowDialog(this, rightToLeft);
					break;
				}
				case "DATE":
				{
					DateField dateField = new DateField(item);
					dateField.ShowDialog(this, rightToLeft);
					break;
				}
				case "INCLUDETEXT":
				{
					IncludeText includeText = new IncludeText(item);
					includeText.ShowDialog(this, rightToLeft);
					break;
				}
				case "IF":
				{
					IfField ifField = new IfField(item);
					ifField.ShowDialog(this, rightToLeft);
					break;
				}
				case "NEXTIF":
				{
					NextIfField nextIfField = new NextIfField(item);
					nextIfField.ShowDialog(this, rightToLeft);
					break;
				}
				}
			}
			catch
			{
			}
		}

		private void UpdateFieldValues()
		{
			if (this.textControl == null)
			{
				return;
			}
			foreach (IFormattedText textPart in this.textControl.TextParts)
			{
				foreach (ApplicationField applicationField in textPart.ApplicationFields)
				{
					this.UpdateFieldValues(applicationField);
				}
			}
		}

		private void UpdateFieldValues(ApplicationField appField)
		{
			try
			{
				switch (this.m_fldDispModeCur)
				{
				case FieldDisplayMode.ShowFieldCodes:
					MainWindow.ShowFieldCodes(appField);
					break;
				case FieldDisplayMode.ShowFieldText:
					MainWindow.ShowFieldText(appField);
					break;
				}
			}
			catch
			{
			}
		}

		private static void ShowFieldCodes(ApplicationField appField)
		{
			string text = ((appField.Parameters != null) ? string.Join(" ", appField.Parameters) : "");
			appField.Text = "{ " + appField.TypeName + " " + text + " }";
		}

		private static void ShowFieldText(ApplicationField appField)
		{
			switch (appField.TypeName)
			{
			case "MERGEFIELD":
			{
				MergeField mergeField = new MergeField(appField);
				mergeField.Text = "«" + mergeField.Name + "»";
				break;
			}
			case "IF":
			{
				IfField ifField = new IfField(appField);
				ifField.Text = "{" + ifField.TypeName + "}";
				break;
			}
			case "DATE":
			{
				DateField dateField = new DateField(appField);
				dateField.Text = "{" + dateField.TypeName + "}";
				break;
			}
			case "INCLUDETEXT":
			{
				IncludeText includeText = new IncludeText(appField);
				includeText.ApplicationField.Text = "{" + includeText.TypeName + "}";
				break;
			}
			case "NEXT":
			{
				NextField nextField = new NextField(appField);
				nextField.ApplicationField.Text = "{" + nextField.TypeName + "}";
				break;
			}
			case "NEXTIF":
			{
				NextIfField nextIfField = new NextIfField(appField);
				nextIfField.ApplicationField.Text = "{" + nextIfField.TypeName + "}";
				break;
			}
			}
		}

		private bool DocumentContainsFields()
		{
			foreach (IFormattedText textPart in this.textControl.TextParts)
			{
				if (textPart.ApplicationFields != null && textPart.ApplicationFields.Count > 0)
				{
					return true;
				}
			}
			return false;
		}

		private bool DocumentContainsNamedObjects()
		{
			foreach (IFormattedText textPart in this.textControl.TextParts)
			{
				foreach (TXTextControl.Image image in textPart.Images)
				{
					if (!string.IsNullOrEmpty(image.Name))
					{
						return true;
					}
				}
			}
			foreach (ChartFrame chart in this.textControl.Charts)
			{
				if (!string.IsNullOrEmpty(chart.Name))
				{
					return true;
				}
			}
			foreach (BarcodeFrame barcode in this.textControl.Barcodes)
			{
				if (!string.IsNullOrEmpty(barcode.Name))
				{
					return true;
				}
			}
			return false;
		}

		private string StreamTypeToFileExt(StreamType streamType)
		{
			switch (streamType)
			{
			case StreamType.AdobePDF:
			case StreamType.AdobePDFA:
				return "pdf";
			case StreamType.CascadingStylesheet:
				return "css";
			case StreamType.HTMLFormat:
				return "html";
			case StreamType.InternalFormat:
			case StreamType.InternalUnicodeFormat:
				return "tx";
			case StreamType.MSWord:
				return "doc";
			case StreamType.PlainAnsiText:
			case StreamType.PlainText:
				return "txt";
			case StreamType.RichTextFormat:
				return "rtf";
			case StreamType.WordprocessingML:
				return "docx";
			case StreamType.XMLFormat:
				return "xml";
			default:
				return string.Empty;
			}
		}

		private static StreamType FileExtToStreamType(string fileExt)
		{
			StreamType result = StreamType.RichTextFormat;
			switch (fileExt.ToLower())
			{
			case "pdf":
				result = StreamType.AdobePDF;
				break;
			case "rtf":
				result = StreamType.RichTextFormat;
				break;
			case "docx":
				result = StreamType.WordprocessingML;
				break;
			case "doc":
				result = StreamType.MSWord;
				break;
			case "html":
				result = StreamType.HTMLFormat;
				break;
			case "txt":
				result = StreamType.PlainText;
				break;
			case "tx":
				result = StreamType.InternalUnicodeFormat;
				break;
			case "xml":
				result = StreamType.XMLFormat;
				break;
			}
			return result;
		}

		private void TextControl_GotFocus(object sender, EventArgs e)
		{
			this.UpdateToolstripState();
		}

		private void TextControl_Changed(object sender, EventArgs e)
		{
			this.m_fileHandler.IsDocumentDirty = true;
			this.UpdateToolstripState();
		}

		private void TextControl_InputPositionChanged(object sender, EventArgs e)
		{
			this.UpdateToolstripState();
		}

		private void TextControl_DocumentLoaded(object sender, EventArgs e)
		{
			this.UpdateToolstripState();
		}

		private void TextControl_ContentsReset(object sender, EventArgs e)
		{
			this.UpdateToolstripState();
		}

		private void TextControl_KeyDown(object sender, KeyEventArgs e)
		{
			this.HandleKeyDownEvent(e);
		}

		private void TextControl_TextContextMenuOpening(object sender, TextContextMenuEventArgs e)
		{
			if (!this.textControl.CanEdit)
			{
				return;
			}
			if ((e.ContextMenuLocation & ContextMenuLocation.TextField) != 0)
			{
				FormField item = this.textControl.FormFields.GetItem();
				if (item != null)
				{
					this.AddFormFieldContextMenuItems(e.TextContextMenu, item);
				}
				ApplicationField item2 = this.textControl.ApplicationFields.GetItem();
				if (item2 != null)
				{
					e.TextContextMenu.Items.Add(new ToolStripSeparator());
					e.TextContextMenu.Items.Add(ResourceProvider.GetText("TXITEM_FieldProperties") + "...", ResourceProvider.GetSmallIcon("TXITEM_FieldProperties", base.DeviceDpi), delegate
					{
						this.FieldSettings();
					});
					e.TextContextMenu.Items.Add(ResourceProvider.GetText("TXITEM_DeleteField") + "...", ResourceProvider.GetSmallIcon("TXITEM_DeleteField", base.DeviceDpi), delegate
					{
						this.DeleteField();
					});
				}
			}
			if ((e.ContextMenuLocation & ContextMenuLocation.SelectedFrame) == 0)
			{
				return;
			}
			FrameBase item3 = this.textControl.Frames.GetItem();
			if (item3 != null)
			{
				this.AddNameContextMenuItems(e.TextContextMenu);
				if (item3 is ChartFrame)
				{
					this.AddChartContextMenuItems(e.TextContextMenu);
				}
			}
		}

		private void TextControl_HypertextLinkClicked(object sender, HypertextLinkEventArgs e)
		{
			this.OpenHyperlink(e.HypertextLink.Target);
		}

		private void TextControl_DragDrop(object sender, DragEventArgs e)
		{
			if (this.m_fileDragDropHandler.CanDrop)
			{
				switch (this.m_fileDragDropHandler.FileType)
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
			this.m_fileDragDropHandler.Reset();
			this.m_fileDragDropHandler.CheckDraggedFiles((string[])e.Data.GetData(DataFormats.FileDrop));
		}

		private void TextControl_DragOver(object sender, DragEventArgs e)
		{
			if (this.m_fileDragDropHandler.CanDrop)
			{
				e.Effect = this.m_fileDragDropHandler.GetDragDropEffect(e.AllowedEffect);
			}
		}

		private void HandleKeyDownEvent(KeyEventArgs e)
		{
			Keys keyCode = e.KeyCode;
			if (keyCode == Keys.Insert && !e.Control && !e.Alt && !e.Shift)
			{
				this.textControl.InsertionMode = ((this.textControl.InsertionMode != InsertionMode.Insert) ? InsertionMode.Insert : InsertionMode.Overwrite);
			}
		}

		private void OpenDroppedDocument()
		{
			this.m_fileHandler.Open(this.m_fileDragDropHandler.FileName);
		}

		private void InsertDroppedImage(DragEventArgs e)
		{
			Point location = this.textControl.PointToClient(System.Windows.Forms.Cursor.Position);
			Paragraph item = this.textControl.Paragraphs.GetItem(location);
			Rectangle rectangle = this.textControl.TextChars[item.Start]?.Bounds ?? default(Rectangle);
			Rectangle rectangle2 = this.textControl.TextChars.GetItem(location, getNearest: true)?.Bounds ?? default(Rectangle);
			Point location2 = new Point(rectangle2.Left - rectangle.Left + rectangle2.Width, rectangle2.Top - rectangle.Top);
			TXTextControl.Image image = new TXTextControl.Image
			{
				FileName = this.m_fileDragDropHandler.FileName
			};
			this.textControl.Images.Add(image, location2, item.Start, ImageInsertionMode.DisplaceText);
		}

		private void AddFormFieldContextMenuItems(ContextMenuStrip contextMenuStrip, FormField field)
		{
			contextMenuStrip.Items.Add(new ToolStripSeparator());
			contextMenuStrip.Items.Add(Resources.CONTEXTMENU_FORMFIELDS_TEXT, ResourceProvider.GetSmallIcon("TXITEM_InsertFormFieldsGroup", base.DeviceDpi), delegate
			{
				Form form = null;
				if (field is SelectionFormField)
				{
					form = new SelectionFormFieldDialog((SelectionFormField)field)
					{
						Text = (field.Editable ? Resources.SELECTIONFORMFIELD_DLG_COMBOBOX_TITLE : Resources.SELECTIONFORMFIELD_DLG_DROPDOWN_TITLE)
					};
				}
				else if (field is CheckFormField)
				{
					form = new CheckFormFieldDialog((CheckFormField)field);
				}
				else if (field is TextFormField)
				{
					form = new TextFormFieldDialog((TextFormField)field);
				}
				else if (field is DateFormField)
				{
					form = new DateFormFieldDialog((DateFormField)field);
				}
				if (form != null)
				{
					form.RightToLeft = this.RightToLeft;
					form.ShowDialog(this);
				}
			});
		}

		private void AddNameContextMenuItems(ContextMenuStrip contextMenuStrip)
		{
			contextMenuStrip.Items.Add(new ToolStripSeparator());
			contextMenuStrip.Items.Add(Resources.strObjectName, ResourceProvider.GetSmallIcon("TXITEM_ObjectName", base.DeviceDpi), SetObjectName);
		}

		private void SetObjectName(object sender, EventArgs e)
		{
			this.ShowObjectNameDialog(this.textControl.Frames.GetItem());
		}

		private void ShowObjectNameDialog(FrameBase obj)
		{
			if (obj != null)
			{
				string strInput = obj.Name;
				if (InputBoxDialog.ShowInputBox(Resources.INPUTBOXDLG_SETOBJECTNAME_TITLE, ref strInput, this, allowEmptyString: true))
				{
					obj.Name = strInput;
				}
			}
		}

		private void AddChartContextMenuItems(ContextMenuStrip contextMenuStrip)
		{
			contextMenuStrip.Items.Add(new ToolStripSeparator());
			contextMenuStrip.Items.Add(Resources.strChartEditDataMenuItemName, ResourceProvider.GetSmallIcon("TXITEM_InsertShape", base.DeviceDpi), EditChartData);
		}

		private void EditChartData(object sender, EventArgs e)
		{
			this.EditChartData();
		}

		private void MnuInsert_Shapes_DropDownOpening(object sender, EventArgs e)
		{
			if (this.mnuInsert_Shapes_Lines.DropDownItems.Count <= 0)
			{
				this.AddShapeMenuItems();
			}
		}

		private void AddShapeMenuItems()
		{
			ToolStripItemCollection dropDownItems = this.mnuInsert_Shapes_Lines.DropDownItems;
			this.AddShapeItem(dropDownItems, ShapeType.Line);
			this.AddShapeItem(dropDownItems, ShapeType.BentConnector3);
			this.AddShapeItem(dropDownItems, ShapeType.CurvedConnector3);
			dropDownItems = this.mnuInsert_Shapes_Rectangles.DropDownItems;
			this.AddShapeItem(dropDownItems, ShapeType.Rectangle);
			this.AddShapeItem(dropDownItems, ShapeType.RoundRectangle);
			this.AddShapeItem(dropDownItems, ShapeType.Snip1Rectangle);
			this.AddShapeItem(dropDownItems, ShapeType.Snip2SameRectangle);
			this.AddShapeItem(dropDownItems, ShapeType.Snip2DiagonalRectangle);
			this.AddShapeItem(dropDownItems, ShapeType.SnipRoundRectangle);
			this.AddShapeItem(dropDownItems, ShapeType.Round1Rectangle);
			this.AddShapeItem(dropDownItems, ShapeType.Round2SameRectangle);
			this.AddShapeItem(dropDownItems, ShapeType.Round2DiagonalRectangle);
			dropDownItems = this.mnuInsert_Shapes_Basic.DropDownItems;
			this.AddShapeItem(dropDownItems, ShapeType.Ellipse);
			this.AddShapeItem(dropDownItems, ShapeType.Triangle);
			this.AddShapeItem(dropDownItems, ShapeType.RightTriangle);
			this.AddShapeItem(dropDownItems, ShapeType.Parallelogram);
			this.AddShapeItem(dropDownItems, ShapeType.NonIsoscelesTrapezoid);
			this.AddShapeItem(dropDownItems, ShapeType.Diamond);
			this.AddShapeItem(dropDownItems, ShapeType.Pentagon);
			this.AddShapeItem(dropDownItems, ShapeType.Hexagon);
			this.AddShapeItem(dropDownItems, ShapeType.Heptagon);
			this.AddShapeItem(dropDownItems, ShapeType.Octagon);
			this.AddShapeItem(dropDownItems, ShapeType.Decagon);
			this.AddShapeItem(dropDownItems, ShapeType.Dodecagon);
			this.AddShapeItem(dropDownItems, ShapeType.Pie);
			this.AddShapeItem(dropDownItems, ShapeType.Chord);
			this.AddShapeItem(dropDownItems, ShapeType.Teardrop);
			this.AddShapeItem(dropDownItems, ShapeType.Frame);
			this.AddShapeItem(dropDownItems, ShapeType.HalfFrame);
			this.AddShapeItem(dropDownItems, ShapeType.Corner);
			this.AddShapeItem(dropDownItems, ShapeType.DiagonalStripe);
			this.AddShapeItem(dropDownItems, ShapeType.Plus);
			this.AddShapeItem(dropDownItems, ShapeType.Plaque);
			this.AddShapeItem(dropDownItems, ShapeType.Can);
			this.AddShapeItem(dropDownItems, ShapeType.Cube);
			this.AddShapeItem(dropDownItems, ShapeType.Bevel);
			this.AddShapeItem(dropDownItems, ShapeType.Donut);
			this.AddShapeItem(dropDownItems, ShapeType.NoSmoking);
			this.AddShapeItem(dropDownItems, ShapeType.BlockArc);
			this.AddShapeItem(dropDownItems, ShapeType.FoldedCorner);
			this.AddShapeItem(dropDownItems, ShapeType.SmileyFace);
			this.AddShapeItem(dropDownItems, ShapeType.Heart);
			this.AddShapeItem(dropDownItems, ShapeType.LightningBolt);
			this.AddShapeItem(dropDownItems, ShapeType.Sun);
			this.AddShapeItem(dropDownItems, ShapeType.Moon);
			this.AddShapeItem(dropDownItems, ShapeType.Cloud);
			this.AddShapeItem(dropDownItems, ShapeType.Arc);
			this.AddShapeItem(dropDownItems, ShapeType.BracketPair);
			this.AddShapeItem(dropDownItems, ShapeType.BracePair);
			this.AddShapeItem(dropDownItems, ShapeType.LeftBracket);
			this.AddShapeItem(dropDownItems, ShapeType.RightBracket);
			this.AddShapeItem(dropDownItems, ShapeType.LeftBrace);
			this.AddShapeItem(dropDownItems, ShapeType.RightBrace);
			dropDownItems = this.mnuInsert_Shapes_BlockArrows.DropDownItems;
			this.AddShapeItem(dropDownItems, ShapeType.RightArrow);
			this.AddShapeItem(dropDownItems, ShapeType.LeftArrow);
			this.AddShapeItem(dropDownItems, ShapeType.UpArrow);
			this.AddShapeItem(dropDownItems, ShapeType.DownArrow);
			this.AddShapeItem(dropDownItems, ShapeType.LeftRightArrow);
			this.AddShapeItem(dropDownItems, ShapeType.UpDownArrow);
			this.AddShapeItem(dropDownItems, ShapeType.QuadArrow);
			this.AddShapeItem(dropDownItems, ShapeType.LeftRightUpArrow);
			this.AddShapeItem(dropDownItems, ShapeType.BentArrow);
			this.AddShapeItem(dropDownItems, ShapeType.UTurnArrow);
			this.AddShapeItem(dropDownItems, ShapeType.LeftUpArrow);
			this.AddShapeItem(dropDownItems, ShapeType.BentUpArrow);
			this.AddShapeItem(dropDownItems, ShapeType.CurvedRightArrow);
			this.AddShapeItem(dropDownItems, ShapeType.CurvedLeftArrow);
			this.AddShapeItem(dropDownItems, ShapeType.CurvedUpArrow);
			this.AddShapeItem(dropDownItems, ShapeType.CurvedDownArrow);
			this.AddShapeItem(dropDownItems, ShapeType.StripedRightArrow);
			this.AddShapeItem(dropDownItems, ShapeType.NotchedRightArrow);
			this.AddShapeItem(dropDownItems, ShapeType.HomePlate);
			this.AddShapeItem(dropDownItems, ShapeType.Chevron);
			this.AddShapeItem(dropDownItems, ShapeType.RightArrowCallout);
			this.AddShapeItem(dropDownItems, ShapeType.DownArrowCallout);
			this.AddShapeItem(dropDownItems, ShapeType.LeftArrowCallout);
			this.AddShapeItem(dropDownItems, ShapeType.UpArrowCallout);
			this.AddShapeItem(dropDownItems, ShapeType.LeftRightArrowCallout);
			this.AddShapeItem(dropDownItems, ShapeType.QuadArrowCallout);
			this.AddShapeItem(dropDownItems, ShapeType.CircularArrow);
			dropDownItems = this.mnuInsert_Shapes_Equation.DropDownItems;
			this.AddShapeItem(dropDownItems, ShapeType.MathPlus);
			this.AddShapeItem(dropDownItems, ShapeType.MathMinus);
			this.AddShapeItem(dropDownItems, ShapeType.MathMultiply);
			this.AddShapeItem(dropDownItems, ShapeType.MathDivide);
			this.AddShapeItem(dropDownItems, ShapeType.MathEqual);
			this.AddShapeItem(dropDownItems, ShapeType.MathNotEqual);
			dropDownItems = this.mnuInsert_Shapes_FlowChart.DropDownItems;
			this.AddShapeItem(dropDownItems, ShapeType.FlowChartProcess);
			this.AddShapeItem(dropDownItems, ShapeType.FlowChartAlternateProcess);
			this.AddShapeItem(dropDownItems, ShapeType.FlowChartDecision);
			this.AddShapeItem(dropDownItems, ShapeType.FlowChartInputOutput);
			this.AddShapeItem(dropDownItems, ShapeType.FlowChartPredefinedProcess);
			this.AddShapeItem(dropDownItems, ShapeType.FlowChartInternalStorage);
			this.AddShapeItem(dropDownItems, ShapeType.FlowChartDocument);
			this.AddShapeItem(dropDownItems, ShapeType.FlowChartMultidocument);
			this.AddShapeItem(dropDownItems, ShapeType.FlowChartTerminator);
			this.AddShapeItem(dropDownItems, ShapeType.FlowChartPreparation);
			this.AddShapeItem(dropDownItems, ShapeType.FlowChartManualInput);
			this.AddShapeItem(dropDownItems, ShapeType.FlowChartManualOperation);
			this.AddShapeItem(dropDownItems, ShapeType.FlowChartConnector);
			this.AddShapeItem(dropDownItems, ShapeType.FlowChartOffpageConnector);
			this.AddShapeItem(dropDownItems, ShapeType.FlowChartPunchedCard);
			this.AddShapeItem(dropDownItems, ShapeType.FlowChartPunchedTape);
			this.AddShapeItem(dropDownItems, ShapeType.FlowChartSummingJunction);
			this.AddShapeItem(dropDownItems, ShapeType.FlowChartOr);
			this.AddShapeItem(dropDownItems, ShapeType.FlowChartCollate);
			this.AddShapeItem(dropDownItems, ShapeType.FlowChartSort);
			this.AddShapeItem(dropDownItems, ShapeType.FlowChartExtract);
			this.AddShapeItem(dropDownItems, ShapeType.FlowChartMerge);
			this.AddShapeItem(dropDownItems, ShapeType.FlowChartOnlineStorage);
			this.AddShapeItem(dropDownItems, ShapeType.FlowChartDelay);
			this.AddShapeItem(dropDownItems, ShapeType.FlowChartMagneticTape);
			this.AddShapeItem(dropDownItems, ShapeType.FlowChartMagneticDisk);
			this.AddShapeItem(dropDownItems, ShapeType.FlowChartMagneticDrum);
			this.AddShapeItem(dropDownItems, ShapeType.FlowChartDisplay);
			dropDownItems = this.mnuInsert_Shapes_StarsBanners.DropDownItems;
			this.AddShapeItem(dropDownItems, ShapeType.IrregularSeal1);
			this.AddShapeItem(dropDownItems, ShapeType.IrregularSeal2);
			this.AddShapeItem(dropDownItems, ShapeType.Star4);
			this.AddShapeItem(dropDownItems, ShapeType.Star5);
			this.AddShapeItem(dropDownItems, ShapeType.Star6);
			this.AddShapeItem(dropDownItems, ShapeType.Star7);
			this.AddShapeItem(dropDownItems, ShapeType.Star8);
			this.AddShapeItem(dropDownItems, ShapeType.Star10);
			this.AddShapeItem(dropDownItems, ShapeType.Star12);
			this.AddShapeItem(dropDownItems, ShapeType.Star16);
			this.AddShapeItem(dropDownItems, ShapeType.Star24);
			this.AddShapeItem(dropDownItems, ShapeType.Star32);
			this.AddShapeItem(dropDownItems, ShapeType.Ribbon2);
			this.AddShapeItem(dropDownItems, ShapeType.Ribbon);
			this.AddShapeItem(dropDownItems, ShapeType.EllipseRibbon2);
			this.AddShapeItem(dropDownItems, ShapeType.EllipseRibbon);
			this.AddShapeItem(dropDownItems, ShapeType.VerticalScroll);
			this.AddShapeItem(dropDownItems, ShapeType.HorizontalScroll);
			this.AddShapeItem(dropDownItems, ShapeType.Wave);
			this.AddShapeItem(dropDownItems, ShapeType.DoubleWave);
			dropDownItems = this.mnuInsert_Shapes_Callouts.DropDownItems;
			this.AddShapeItem(dropDownItems, ShapeType.WedgeRectangleCallout);
			this.AddShapeItem(dropDownItems, ShapeType.WedgeRoundRectangleCallout);
			this.AddShapeItem(dropDownItems, ShapeType.WedgeEllipseCallout);
			this.AddShapeItem(dropDownItems, ShapeType.CloudCallout);
			this.AddShapeItem(dropDownItems, ShapeType.BorderCallout1);
			this.AddShapeItem(dropDownItems, ShapeType.BorderCallout2);
			this.AddShapeItem(dropDownItems, ShapeType.BorderCallout3);
			this.AddShapeItem(dropDownItems, ShapeType.AccentCallout1);
			this.AddShapeItem(dropDownItems, ShapeType.AccentCallout2);
			this.AddShapeItem(dropDownItems, ShapeType.AccentCallout3);
			this.AddShapeItem(dropDownItems, ShapeType.Callout1);
			this.AddShapeItem(dropDownItems, ShapeType.Callout2);
			this.AddShapeItem(dropDownItems, ShapeType.Callout3);
			this.AddShapeItem(dropDownItems, ShapeType.AccentBorderCallout1);
			this.AddShapeItem(dropDownItems, ShapeType.AccentBorderCallout2);
			this.AddShapeItem(dropDownItems, ShapeType.AccentBorderCallout3);
		}

		private void AddShapeItem(ToolStripItemCollection items, ShapeType shapeType)
		{
			string @string = Resources.ResourceManager.GetString("TOOLTIP_SHAPE_" + shapeType);
			Bitmap image = ResourceProvider.GetSmallIcon("TXITEM_SHAPE_" + shapeType, base.DeviceDpi);
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(@string, image);
			toolStripMenuItem.Tag = shapeType;
			toolStripMenuItem.Click += ShapeMenuItem_Click;
			items.Add(toolStripMenuItem);
		}

		private void ShapeMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
			if (toolStripMenuItem != null)
			{
				ShapeType shapeType;
				try
				{
					shapeType = (ShapeType)toolStripMenuItem.Tag;
				}
				catch (InvalidCastException)
				{
					return;
				}
				this.InsertShape(shapeType);
			}
		}

		private void InsertDrawingCanvas()
		{
			try
			{
				TXDrawingControl drawing = new TXDrawingControl(7000, 4000);
				DrawingFrame drawingFrame = new DrawingFrame(drawing);
				this.textControl.Drawings.Add(drawingFrame, TXTextControl.HorizontalAlignment.Left, -1, FrameInsertionMode.DisplaceText | FrameInsertionMode.MoveWithText);
				drawingFrame.Activate();
			}
			catch (LicenseLevelException ex)
			{
				string product = ((AssemblyProductAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyProductAttribute))).Product;
				System.Windows.Forms.MessageBox.Show(ex.Message, product, MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
			}
		}

		private void InsertShape(ShapeType shapeType)
		{
			try
			{
				DrawingFrame drawingFrame = this.textControl.Drawings.GetActivatedItem();
				if (drawingFrame != null)
				{
					TXDrawingControl tXDrawingControl = drawingFrame.Drawing as TXDrawingControl;
					if (tXDrawingControl != null && tXDrawingControl.IsCanvasVisible)
					{
						tXDrawingControl.Shapes.Add(new Shape(shapeType), ShapeCollection.AddStyle.MouseCreation);
					}
				}
				else
				{
					TXDrawingControl tXDrawingControl2 = new TXDrawingControl(7000, 4000);
					Shape shape = new Shape(shapeType)
					{
						AutoSize = true,
						Movable = false,
						Sizable = false
					};
					tXDrawingControl2.Shapes.Add(shape, ShapeCollection.AddStyle.Fill);
					drawingFrame = new DrawingFrame(tXDrawingControl2);
					this.textControl.Drawings.Add(drawingFrame, FrameInsertionMode.AboveTheText | FrameInsertionMode.MoveWithText);
				}
				drawingFrame.Activate();
			}
			catch (LicenseLevelException ex)
			{
				string product = ((AssemblyProductAttribute)Attribute.GetCustomAttribute(Assembly.GetExecutingAssembly(), typeof(AssemblyProductAttribute))).Product;
				System.Windows.Forms.MessageBox.Show(ex.Message, product, MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
			}
		}

		public MainWindow()
		{
			this.InitializeComponent();
			this.m_fileHandler = new FileHandler(this.textControl);
			this.m_fileHandler.ShowMessageBox += FileHandler_ShowMessageBox;
			this.m_fileHandler.DocumentDirtyChanged += FileHandler_DocumentDirtyChanged;
			this.m_fileHandler.DocumentFileNameChanged += FileHandler_DocumentFileNameChanged;
			this.m_fileHandler.RecentFileListChanged += FileHandler_RecentFileListChanged;
			this.m_fileHandler.UserInputRequested += FileHandler_UserInputRequested;
			this.m_fileHandler.PropertyChanged += FileHandler_PropertyChanged_CanSave;
			this.m_fileDragDropHandler = new FileDragDropHandler();
			this.SetWindowTitle(this.m_fileHandler.DocumentTitle);
			this.m_UAC = new UserAccessControl(ref this.textControl);
			base.Icon = new Icon(Assembly.GetExecutingAssembly().GetManifestResourceStream("TX_Text_Control_Words.Icons.tx.ico"));
			this.LoadAppSettings();
		}

		protected override void OnLoad(EventArgs e)
		{
			this.textControl.ShowMiniToolbar = (this.IsStandardVersion() ? MiniToolbarButton.None : (MiniToolbarButton.LeftButton | MiniToolbarButton.RightButton));
			string[] commandLineArgs = Environment.GetCommandLineArgs();
			if (commandLineArgs.Length > 1)
			{
				this.m_fileHandler.Open(commandLineArgs[1]);
			}
			this.LocalizeToolbar();
			this.LocalizeToolstrip();
			this.UpdateToolbarImages();
			this.UpdateToolstripImages();
			base.OnLoad(e);
		}

		protected override void OnDpiChanged(DpiChangedEventArgs e)
		{
			this.UpdateToolbarImages();
			this.UpdateToolstripImages();
			base.OnDpiChanged(e);
		}

		protected override void OnFormClosing(FormClosingEventArgs e)
		{
			this.m_fileHandler.ExitApplication();
			this.SaveAppSettings();
			base.OnFormClosing(e);
		}

		private void LoadAppSettings()
		{
			base.StartPosition = FormStartPosition.Manual;
			this.RightToLeft = Settings.Default.RightToLeft;
			switch (this.RightToLeft)
			{
			case RightToLeft.No:
				this.RightToLeftLayout = false;
				this.m_verticalRulerBar.Dock = DockStyle.Left;
				break;
			case RightToLeft.Yes:
				this.RightToLeftLayout = true;
				this.m_verticalRulerBar.Dock = DockStyle.Right;
				break;
			}
			if (Settings.Default.KnownUsers != null)
			{
				this.m_UAC.KnownUsers.Set(Settings.Default.KnownUsers);
			}
			this.m_fileHandler.RecentFiles = Settings.Default.RecentFiles;
			this.m_fileHandler.MaxRecentFiles = Settings.Default.RecentFilesMaxItemCount;
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

		private void FileNew()
		{
			this.m_fileHandler.New();
			this.SetWindowTitle(this.m_fileHandler.DocumentTitle);
		}

		private void FileOpen()
		{
			this.m_fileHandler.Open();
		}

		private void FileSave()
		{
			try
			{
				this.m_fileHandler.Save();
			}
			catch (Exception ex)
			{
				TX_Text_Control_Words.Utils.MessageBox.Show(this, ex.Message, Resources.MSG_SAVINGDOCUMENT_TITLE);
			}
		}

		private void Print()
		{
			this.textControl.Print(base.ProductName + " - " + this.m_fileHandler.DocumentTitle);
		}

		private void PrintPreview()
		{
			this.textControl.PrintPreview(base.ProductName + " - " + this.m_fileHandler.DocumentTitle);
		}

		private void SetWindowTitle(string documentTitle, bool isDocumentDirty = false)
		{
			string arg = (isDocumentDirty ? "*" : "");
			this.Text = $"{documentTitle}{arg} - {base.ProductName}";
		}

		private bool IsStandardVersion()
		{
			try
			{
				this.textControl.ApplicationFields.GetItem();
			}
			catch (Exception)
			{
				return true;
			}
			return false;
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.textControl = new TXTextControl.TextControl();
            this.m_buttonBar = new TXTextControl.ButtonBar();
            this.m_horizontalRulerBar = new TXTextControl.RulerBar();
            this.m_statusBar = new TXTextControl.StatusBar();
            this.m_verticalRulerBar = new TXTextControl.RulerBar();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.mnuBtnNewFile = new System.Windows.Forms.ToolStripButton();
            this.mnuBtnOpenFile = new System.Windows.Forms.ToolStripButton();
            this.mnuBtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuBtnPrint = new System.Windows.Forms.ToolStripButton();
            this.mnuBtnPrintPreview = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuBtnCut = new System.Windows.Forms.ToolStripButton();
            this.mnuBtnCopy = new System.Windows.Forms.ToolStripButton();
            this.mnuBtnPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuBtnUndo = new System.Windows.Forms.ToolStripButton();
            this.mnuBtnRedo = new System.Windows.Forms.ToolStripButton();
            this.mnuBtnFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator444 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuBtnMarginsAndPaper = new System.Windows.Forms.ToolStripButton();
            this.mnuBtnHeadersAndFooters = new System.Windows.Forms.ToolStripButton();
            this.mnuBtnColumns = new System.Windows.Forms.ToolStripButton();
            this.mnuBtnPageBorders = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator445 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuBtnSelectObjects = new System.Windows.Forms.ToolStripButton();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile_New = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile_Open = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile_RecentFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFile_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile_Export = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFile_PageSetup = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile_PrintPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile_Print = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFile_UserManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile_UserAccess = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile_Options = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit_Undo = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit_Redo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEdit_Cut = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit_Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEdit_SelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem13 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEdit_Find = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit_Replace = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem16 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEdit_Hyperlink = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit_Target = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit_TableOfContents = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit_TableOfContents_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit_TableOfContents_Update = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit_TableOfContents_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEdit_Permissions = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit_Permissions_ReadOnly = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit_Permissions_AllowCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit_Permissions_AllowFormatting = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit_Permissions_AllowFormattingStyles = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit_Permissions_AllowEditingFormFields = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit_Permissions_AllowPrinting = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit_ProtectDocument = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEdit_Reviewing = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit_Reviewing_TrackChanges = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEdit_Reviewing_ReviewChanges = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView_PageLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView_Draft = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuView_HeadersAndFooters = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem12 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuView_Toolbar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView_ButtonBar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView_StatusBar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView_HorizontalRuler = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView_VerticalRuler = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem20 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuView_TextFrameMarkerLines = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView_DrawingMarkerLines = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView_DocumentTargetMarkers = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem19 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuView_Zoom = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView_Zoom_25 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView_Zoom_50 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView_Zoom_75 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView_Zoom_100 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView_Zoom_150 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView_Zoom_200 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView_Zoom_300 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuView_Zoom_400 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuView_FormLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_File = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuInsert_Image = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_Shapes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_Shapes_Lines = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_Shapes_Rectangles = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_Shapes_Basic = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_Shapes_BlockArrows = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_Shapes_Equation = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_Shapes_FlowChart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_Shapes_StarsBanners = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_Shapes_Callouts = new System.Windows.Forms.ToolStripMenuItem();
            this.sepShapeCat = new System.Windows.Forms.ToolStripSeparator();
            this.mnuInsert_Shapes_DrawingCanvas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_TextFrame = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_Chart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_chart_area = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_chart_bar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_chart_column = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_chart_clusteredBar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_chart_pie = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_pageNum = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_PageNum_Insert = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_PageNum_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_TableOfContents = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSep_mnuInsert1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuInsert_Fields = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_Fields_insertMergeField = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_Fields_insertSpecialField = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_Fields_insertSpecialField_IF = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_Fields_insertSpecialField_inclText = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_Fields_insertSpecialField_date = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_Fields_insertSpecialField_next = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_Fields_insertSpecialField_nextif = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_Fields_highlightMergeFields = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuInsert_Fields_showFieldCodes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_Fields_showFieldText = new System.Windows.Forms.ToolStripMenuItem();
            this.sep_field01 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuInsert_Fields_deleteField = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_FormFields = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_FormFields_TextFormField = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_FormFields_CheckFormField = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_FormFields_ComboBoxFormField = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_FormFields_DropDownListFormField = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_FormFields_DatePicker = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_Symbol = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSep_mnuInsert2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuInsert_Hyperlink = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_Target = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSep_mnuInsert3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuInsert_Break = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuInsert_EditableRegion = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_EditableRegion_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_EditableRegion_Add_User = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_EditableRegion_Add_Everyone = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_EditableRegion_Remove = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_EditableRegion_Remove_User = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInsert_EditableRegion_Remove_Everyone = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_Character = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_Paragraph = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_List = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_List_Attributes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_List_IncreaseLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_List_DecreaseLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem28 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFormat_List_ArabicNumbers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_List_CapitalLetters = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_List_Letters = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_List_RomanNumbers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_List_SmallRomanNumbers = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_List_Bullets = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_Styles = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFormat_HeadersAndFooters = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_Columns = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_PageBorders = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_Tabs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFormat_Image = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_TextFrame = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout_ChartTitle = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout_ChartTitle_None = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout_ChartTitle_CenteredOverlay = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout_ChartTitle_AboveChart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout_AxisTitles = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout_AxisTitles_None = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout_AxisTitles_BelowChart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout_AxisTitles_Vertical = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout_Legend = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout_Legend_None = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout_Legend_Top = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout_Legend_Right = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout_Legend_Bottom = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout_Legend_Left = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout_DataLabels = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout_DataLabels_None = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout_DataLabels_OutsideEnd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSep_menu_chartLayout = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFormat_ChartLayout_Axes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout_Axes_leftToRight = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout_Axes_withoutLabeling = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout_HorGridLines = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout_HorizGridlines_None = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout_HorizGridlines_Major = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout_HorizGridlines_Minor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout_HorizGridlines_MajAndMin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout_VertGridLines = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout_VertGridlines_None = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout_VertGridlines_Major = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout_VertGridlines_Minor = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_ChartLayout_VertGridlines_MajAndMin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_Shape = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFormat_FormFields = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_FormFields_Properties = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFormat_FormFields_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFormat_FormFields_IsFormFieldValidationEnabled = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFormat_FormFields_ConditionalInstructions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFormat_Language = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Insert = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Insert_Table = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem21 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTable_Insert_ColumnToTheLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Insert_ColumnToTheRight = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem24 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTable_Insert_RowAbove = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Insert_RowBelow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Delete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Delete_Table = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Delete_Column = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Delete_Rows = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Delete_Cells = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Delete_Cells_shiftLeft = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Delete_Cells_entireRow = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Delete_Cells_entireColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Select = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Select_Table = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Select_Row = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Select_Column = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Select_Cell = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTable_Merge_Cells = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Split_Cells = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Split = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Split_Above = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Split_Below = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTable_Formulas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Formulas_A1Style = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTable_Formulas_R1C1Style = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTable_Formulas_EditFormula = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTable_Formulas_AutomaticCalculation = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSep_mnuTable1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTable_GridLines = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuTable_Properties = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelp_AboutTXTextControlWords = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSeparatorEdit_Reviewing = new System.Windows.Forms.ToolStripSeparator();
            this.sep_pageNum01 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.AutoScroll = true;
            this.toolStripContainer1.ContentPanel.Controls.Add(this.textControl);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.m_verticalRulerBar);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.m_horizontalRulerBar);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.m_buttonBar);
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(6);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(962, 588);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 27);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(6);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(962, 613);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip);
            // 
            // textControl
            // 
            this.textControl.AllowDrag = true;
            this.textControl.AllowDrop = true;
            this.textControl.ButtonBar = this.m_buttonBar;
            this.textControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textControl.DocumentTargetMarkers = true;
            this.textControl.Font = new System.Drawing.Font("Arial", 10F);
            this.textControl.Location = new System.Drawing.Point(25, 54);
            this.textControl.Margin = new System.Windows.Forms.Padding(6);
            this.textControl.Name = "textControl";
            this.textControl.PageMargins.Bottom = 79.03D;
            this.textControl.PageMargins.Left = 79.03D;
            this.textControl.PageMargins.Right = 79.03D;
            this.textControl.PageMargins.Top = 79.03D;
            this.textControl.RulerBar = this.m_horizontalRulerBar;
            this.textControl.Size = new System.Drawing.Size(937, 534);
            this.textControl.StatusBar = this.m_statusBar;
            this.textControl.TabIndex = 0;
            this.textControl.UserNames = null;
            this.textControl.VerticalRulerBar = this.m_verticalRulerBar;
            this.textControl.Changed += new System.EventHandler(this.TextControl_Changed);
            this.textControl.InputPositionChanged += new System.EventHandler(this.TextControl_InputPositionChanged);
            this.textControl.DocumentLoaded += new System.EventHandler(this.TextControl_DocumentLoaded);
            this.textControl.ContentsReset += new System.EventHandler(this.TextControl_ContentsReset);
            this.textControl.TextContextMenuOpening += new TXTextControl.TextContextMenuEventHandler(this.TextControl_TextContextMenuOpening);
            this.textControl.HypertextLinkClicked += new TXTextControl.HypertextLinkEventHandler(this.TextControl_HypertextLinkClicked);
            this.textControl.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextControl_DragDrop);
            this.textControl.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextControl_DragEnter);
            this.textControl.DragOver += new System.Windows.Forms.DragEventHandler(this.TextControl_DragOver);
            this.textControl.GotFocus += new System.EventHandler(this.TextControl_GotFocus);
            this.textControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextControl_KeyDown);
            // 
            // m_buttonBar
            // 
            this.m_buttonBar.BackColor = System.Drawing.SystemColors.Control;
            this.m_buttonBar.ButtonOffsets = new int[] {
        10,
        0,
        0,
        10,
        0,
        0,
        10,
        0,
        0,
        0,
        10,
        0,
        0,
        10,
        0,
        10,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0,
        0};
            this.m_buttonBar.ButtonPositions = new TXTextControl.Button[] {
        TXTextControl.Button.StyleComboBox,
        TXTextControl.Button.FontNameComboBox,
        TXTextControl.Button.FontSizeComboBox,
        TXTextControl.Button.FontBoldButton,
        TXTextControl.Button.FontItalicButton,
        TXTextControl.Button.FontUnderlineButton,
        TXTextControl.Button.AlignmentLeftButton,
        TXTextControl.Button.AlignmentRightButton,
        TXTextControl.Button.AlignmentCenteredButton,
        TXTextControl.Button.AlignmentJustifiedButton,
        TXTextControl.Button.ListBulletedButton,
        TXTextControl.Button.ListNumberedButton,
        TXTextControl.Button.ListStructuredButton,
        TXTextControl.Button.LeftToRightButton,
        TXTextControl.Button.RightToLeftButton,
        TXTextControl.Button.ZoomComboBox,
        TXTextControl.Button.ControlCharsButton,
        TXTextControl.Button.TabSelectionButton,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None,
        TXTextControl.Button.None};
            this.m_buttonBar.ButtonSeparators = new bool[] {
        false,
        false,
        false,
        true,
        false,
        false,
        true,
        false,
        false,
        false,
        true,
        false,
        false,
        true,
        false,
        true,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false,
        false};
            this.m_buttonBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_buttonBar.Location = new System.Drawing.Point(0, 0);
            this.m_buttonBar.Margin = new System.Windows.Forms.Padding(6);
            this.m_buttonBar.Name = "m_buttonBar";
            this.m_buttonBar.Size = new System.Drawing.Size(962, 29);
            this.m_buttonBar.TabIndex = 0;
            this.m_buttonBar.Text = "buttonBar1";
            // 
            // m_horizontalRulerBar
            // 
            this.m_horizontalRulerBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_horizontalRulerBar.Location = new System.Drawing.Point(0, 29);
            this.m_horizontalRulerBar.Margin = new System.Windows.Forms.Padding(6);
            this.m_horizontalRulerBar.Name = "m_horizontalRulerBar";
            this.m_horizontalRulerBar.Size = new System.Drawing.Size(962, 25);
            this.m_horizontalRulerBar.TabIndex = 2;
            this.m_horizontalRulerBar.Text = "rulerBar1";
            // 
            // m_statusBar
            // 
            this.m_statusBar.BackColor = System.Drawing.SystemColors.Control;
            this.m_statusBar.ColumnText = "Column ";
            this.m_statusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_statusBar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.m_statusBar.LineText = "Line ";
            this.m_statusBar.Location = new System.Drawing.Point(0, 618);
            this.m_statusBar.Margin = new System.Windows.Forms.Padding(6);
            this.m_statusBar.Name = "m_statusBar";
            this.m_statusBar.PageText = "Page ";
            this.m_statusBar.SectionText = "Section ";
            this.m_statusBar.Size = new System.Drawing.Size(962, 22);
            this.m_statusBar.TabIndex = 4;
            // 
            // m_verticalRulerBar
            // 
            this.m_verticalRulerBar.Alignment = TXTextControl.RulerBarAlignment.Left;
            this.m_verticalRulerBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_verticalRulerBar.Location = new System.Drawing.Point(0, 54);
            this.m_verticalRulerBar.Margin = new System.Windows.Forms.Padding(6);
            this.m_verticalRulerBar.Name = "m_verticalRulerBar";
            this.m_verticalRulerBar.Size = new System.Drawing.Size(25, 534);
            this.m_verticalRulerBar.TabIndex = 3;
            this.m_verticalRulerBar.Text = "rulerBar2";
            // 
            // toolStrip
            // 
            this.toolStrip.AllowItemReorder = true;
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBtnNewFile,
            this.mnuBtnOpenFile,
            this.mnuBtnSave,
            this.toolStripSeparator1,
            this.mnuBtnPrint,
            this.mnuBtnPrintPreview,
            this.toolStripSeparator2,
            this.mnuBtnCut,
            this.mnuBtnCopy,
            this.mnuBtnPaste,
            this.toolStripSeparator3,
            this.mnuBtnUndo,
            this.mnuBtnRedo,
            this.mnuBtnFind,
            this.toolStripSeparator444,
            this.mnuBtnMarginsAndPaper,
            this.mnuBtnHeadersAndFooters,
            this.mnuBtnColumns,
            this.mnuBtnPageBorders,
            this.toolStripSeparator445,
            this.mnuBtnSelectObjects});
            this.toolStrip.Location = new System.Drawing.Point(3, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(410, 25);
            this.toolStrip.TabIndex = 0;
            // 
            // mnuBtnNewFile
            // 
            this.mnuBtnNewFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuBtnNewFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnNewFile.Name = "mnuBtnNewFile";
            this.mnuBtnNewFile.Size = new System.Drawing.Size(23, 22);
            this.mnuBtnNewFile.Tag = "TXITEM_New";
            this.mnuBtnNewFile.Text = "New document";
            this.mnuBtnNewFile.ToolTipText = "New document";
            this.mnuBtnNewFile.Click += new System.EventHandler(this.mnuBtnNewFile_Click);
            // 
            // mnuBtnOpenFile
            // 
            this.mnuBtnOpenFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuBtnOpenFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnOpenFile.Name = "mnuBtnOpenFile";
            this.mnuBtnOpenFile.Size = new System.Drawing.Size(23, 22);
            this.mnuBtnOpenFile.Tag = "TXITEM_Open";
            this.mnuBtnOpenFile.Text = "Open document";
            this.mnuBtnOpenFile.ToolTipText = "Open document";
            this.mnuBtnOpenFile.Click += new System.EventHandler(this.mnuBtnOpenFile_Click);
            // 
            // mnuBtnSave
            // 
            this.mnuBtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuBtnSave.Enabled = false;
            this.mnuBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnSave.Name = "mnuBtnSave";
            this.mnuBtnSave.Size = new System.Drawing.Size(23, 22);
            this.mnuBtnSave.Tag = "TXITEM_Save";
            this.mnuBtnSave.Text = "Save document";
            this.mnuBtnSave.ToolTipText = "Save document";
            this.mnuBtnSave.Click += new System.EventHandler(this.mnuBtnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // mnuBtnPrint
            // 
            this.mnuBtnPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuBtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnPrint.Name = "mnuBtnPrint";
            this.mnuBtnPrint.Size = new System.Drawing.Size(23, 22);
            this.mnuBtnPrint.Tag = "TXITEM_Print";
            this.mnuBtnPrint.Text = "Print document";
            this.mnuBtnPrint.ToolTipText = "Print document";
            this.mnuBtnPrint.Click += new System.EventHandler(this.mnuBtnPrint_Click);
            // 
            // mnuBtnPrintPreview
            // 
            this.mnuBtnPrintPreview.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuBtnPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnPrintPreview.Name = "mnuBtnPrintPreview";
            this.mnuBtnPrintPreview.Size = new System.Drawing.Size(23, 22);
            this.mnuBtnPrintPreview.Tag = "TXITEM_PrintPreview";
            this.mnuBtnPrintPreview.Text = "Print preview";
            this.mnuBtnPrintPreview.ToolTipText = "Print preview";
            this.mnuBtnPrintPreview.Click += new System.EventHandler(this.mnuBtnPrintPreview_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // mnuBtnCut
            // 
            this.mnuBtnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuBtnCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnCut.Name = "mnuBtnCut";
            this.mnuBtnCut.Size = new System.Drawing.Size(23, 22);
            this.mnuBtnCut.Tag = "TXITEM_Cut";
            this.mnuBtnCut.Text = "Cut";
            this.mnuBtnCut.ToolTipText = "Cut";
            this.mnuBtnCut.Click += new System.EventHandler(this.mnuBtnCut_Click);
            // 
            // mnuBtnCopy
            // 
            this.mnuBtnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuBtnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnCopy.Name = "mnuBtnCopy";
            this.mnuBtnCopy.Size = new System.Drawing.Size(23, 22);
            this.mnuBtnCopy.Tag = "TXITEM_Copy";
            this.mnuBtnCopy.Text = "Copy";
            this.mnuBtnCopy.ToolTipText = "Copy";
            this.mnuBtnCopy.Click += new System.EventHandler(this.mnuBtnCopy_Click);
            // 
            // mnuBtnPaste
            // 
            this.mnuBtnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuBtnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnPaste.Name = "mnuBtnPaste";
            this.mnuBtnPaste.Size = new System.Drawing.Size(23, 22);
            this.mnuBtnPaste.Tag = "TXITEM_Paste";
            this.mnuBtnPaste.Text = "Paste";
            this.mnuBtnPaste.ToolTipText = "Paste";
            this.mnuBtnPaste.Click += new System.EventHandler(this.mnuBtnPaste_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // mnuBtnUndo
            // 
            this.mnuBtnUndo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuBtnUndo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnUndo.Name = "mnuBtnUndo";
            this.mnuBtnUndo.Size = new System.Drawing.Size(23, 22);
            this.mnuBtnUndo.Tag = "TXITEM_Undo";
            this.mnuBtnUndo.Text = "Undo";
            this.mnuBtnUndo.ToolTipText = "Undo";
            this.mnuBtnUndo.Click += new System.EventHandler(this.mnuBtnUndo_Click);
            // 
            // mnuBtnRedo
            // 
            this.mnuBtnRedo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuBtnRedo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnRedo.Name = "mnuBtnRedo";
            this.mnuBtnRedo.Size = new System.Drawing.Size(23, 22);
            this.mnuBtnRedo.Tag = "TXITEM_Redo";
            this.mnuBtnRedo.Text = "Redo";
            this.mnuBtnRedo.ToolTipText = "Redo";
            this.mnuBtnRedo.Click += new System.EventHandler(this.mnuBtnRedo_Click);
            // 
            // mnuBtnFind
            // 
            this.mnuBtnFind.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuBtnFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnFind.Name = "mnuBtnFind";
            this.mnuBtnFind.Size = new System.Drawing.Size(23, 22);
            this.mnuBtnFind.Tag = "TXITEM_Find";
            this.mnuBtnFind.Text = "Find";
            this.mnuBtnFind.ToolTipText = "Find";
            this.mnuBtnFind.Click += new System.EventHandler(this.mnuBtnFind_Click);
            // 
            // toolStripSeparator444
            // 
            this.toolStripSeparator444.Name = "toolStripSeparator444";
            this.toolStripSeparator444.Size = new System.Drawing.Size(6, 25);
            // 
            // mnuBtnMarginsAndPaper
            // 
            this.mnuBtnMarginsAndPaper.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuBtnMarginsAndPaper.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnMarginsAndPaper.Name = "mnuBtnMarginsAndPaper";
            this.mnuBtnMarginsAndPaper.Size = new System.Drawing.Size(23, 22);
            this.mnuBtnMarginsAndPaper.Tag = "TXITEM_PageMargins";
            this.mnuBtnMarginsAndPaper.Text = "Margins and Paper";
            this.mnuBtnMarginsAndPaper.Click += new System.EventHandler(this.mnuBtnMarginsAndPaper_Click);
            // 
            // mnuBtnHeadersAndFooters
            // 
            this.mnuBtnHeadersAndFooters.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuBtnHeadersAndFooters.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnHeadersAndFooters.Name = "mnuBtnHeadersAndFooters";
            this.mnuBtnHeadersAndFooters.Size = new System.Drawing.Size(23, 22);
            this.mnuBtnHeadersAndFooters.Tag = "TXITEM_HeaderFooterGroup";
            this.mnuBtnHeadersAndFooters.Text = "Headers and Footers";
            this.mnuBtnHeadersAndFooters.Click += new System.EventHandler(this.mnuBtnHeadersAndFooters_Click);
            // 
            // mnuBtnColumns
            // 
            this.mnuBtnColumns.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuBtnColumns.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnColumns.Name = "mnuBtnColumns";
            this.mnuBtnColumns.Size = new System.Drawing.Size(23, 22);
            this.mnuBtnColumns.Tag = "TXITEM_Columns";
            this.mnuBtnColumns.Text = "Columns";
            this.mnuBtnColumns.ToolTipText = "Columns";
            this.mnuBtnColumns.Click += new System.EventHandler(this.mnuBtnColumns_Click);
            // 
            // mnuBtnPageBorders
            // 
            this.mnuBtnPageBorders.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuBtnPageBorders.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnPageBorders.Name = "mnuBtnPageBorders";
            this.mnuBtnPageBorders.Size = new System.Drawing.Size(23, 22);
            this.mnuBtnPageBorders.Tag = "TXITEM_PageBorders";
            this.mnuBtnPageBorders.Text = "Page Borders";
            this.mnuBtnPageBorders.Click += new System.EventHandler(this.mnuBtnPageBorders_Click);
            // 
            // toolStripSeparator445
            // 
            this.toolStripSeparator445.Name = "toolStripSeparator445";
            this.toolStripSeparator445.Size = new System.Drawing.Size(6, 25);
            // 
            // mnuBtnSelectObjects
            // 
            this.mnuBtnSelectObjects.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.mnuBtnSelectObjects.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mnuBtnSelectObjects.Name = "mnuBtnSelectObjects";
            this.mnuBtnSelectObjects.Size = new System.Drawing.Size(23, 22);
            this.mnuBtnSelectObjects.Tag = "TXITEM_SelectObjects";
            this.mnuBtnSelectObjects.Text = "Select Objects";
            this.mnuBtnSelectObjects.Click += new System.EventHandler(this.mnuBtnSelectObjects_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.mnuEdit,
            this.mnuView,
            this.mnuInsert,
            this.mnuFormat,
            this.mnuTable,
            this.mnuHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(11, 4, 0, 4);
            this.menuStrip.Size = new System.Drawing.Size(962, 27);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile_New,
            this.mnuFile_Open,
            this.mnuFile_RecentFiles,
            this.toolStripMenuItem1,
            this.mnuFile_Save,
            this.mnuFile_SaveAs,
            this.mnuFile_Export,
            this.menuItem6,
            this.mnuFile_PageSetup,
            this.mnuFile_PrintPreview,
            this.mnuFile_Print,
            this.menuItem10,
            this.mnuFile_UserManagement,
            this.mnuFile_UserAccess,
            this.mnuFile_Options,
            this.mnuFile_Exit});
            this.mnuFile.MergeIndex = 0;
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(48, 19);
            this.mnuFile.Text = "&Файл";
            this.mnuFile.DropDownOpening += new System.EventHandler(this.mnuFile_DropDownOpening);
            // 
            // mnuFile_New
            // 
            this.mnuFile_New.Name = "mnuFile_New";
            this.mnuFile_New.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.mnuFile_New.Size = new System.Drawing.Size(180, 22);
            this.mnuFile_New.Tag = "TXITEM_New";
            this.mnuFile_New.Text = "&Новый";
            this.mnuFile_New.Click += new System.EventHandler(this.mnuFile_New_Click);
            // 
            // mnuFile_Open
            // 
            this.mnuFile_Open.Name = "mnuFile_Open";
            this.mnuFile_Open.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuFile_Open.Size = new System.Drawing.Size(180, 22);
            this.mnuFile_Open.Tag = "TXITEM_Open";
            this.mnuFile_Open.Text = "&Open…";
            this.mnuFile_Open.Click += new System.EventHandler(this.mnuFile_Open_Click);
            // 
            // mnuFile_RecentFiles
            // 
            this.mnuFile_RecentFiles.Enabled = false;
            this.mnuFile_RecentFiles.Name = "mnuFile_RecentFiles";
            this.mnuFile_RecentFiles.Size = new System.Drawing.Size(180, 22);
            this.mnuFile_RecentFiles.Text = "&Recent Files";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuFile_Save
            // 
            this.mnuFile_Save.Enabled = false;
            this.mnuFile_Save.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mnuFile_Save.MergeIndex = 1;
            this.mnuFile_Save.Name = "mnuFile_Save";
            this.mnuFile_Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFile_Save.Size = new System.Drawing.Size(180, 22);
            this.mnuFile_Save.Tag = "TXITEM_Save";
            this.mnuFile_Save.Text = "&Save";
            this.mnuFile_Save.Click += new System.EventHandler(this.mnuFile_Save_Click);
            // 
            // mnuFile_SaveAs
            // 
            this.mnuFile_SaveAs.MergeIndex = 2;
            this.mnuFile_SaveAs.Name = "mnuFile_SaveAs";
            this.mnuFile_SaveAs.Size = new System.Drawing.Size(180, 22);
            this.mnuFile_SaveAs.Tag = "TXITEM_SaveAs";
            this.mnuFile_SaveAs.Text = "Save &As…";
            this.mnuFile_SaveAs.Click += new System.EventHandler(this.mnuFile_SaveAs_Click);
            // 
            // mnuFile_Export
            // 
            this.mnuFile_Export.MergeIndex = 3;
            this.mnuFile_Export.Name = "mnuFile_Export";
            this.mnuFile_Export.Size = new System.Drawing.Size(180, 22);
            this.mnuFile_Export.Text = "&Export…";
            this.mnuFile_Export.Click += new System.EventHandler(this.mnuFile_Export_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.MergeIndex = 4;
            this.menuItem6.Name = "menuItem6";
            this.menuItem6.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuFile_PageSetup
            // 
            this.mnuFile_PageSetup.MergeIndex = 5;
            this.mnuFile_PageSetup.Name = "mnuFile_PageSetup";
            this.mnuFile_PageSetup.Size = new System.Drawing.Size(180, 22);
            this.mnuFile_PageSetup.Tag = "TXITEM_PageMargins";
            this.mnuFile_PageSetup.Text = "Page Se&tup…";
            this.mnuFile_PageSetup.Click += new System.EventHandler(this.mnuFile_PageSetup_Click);
            // 
            // mnuFile_PrintPreview
            // 
            this.mnuFile_PrintPreview.MergeIndex = 6;
            this.mnuFile_PrintPreview.Name = "mnuFile_PrintPreview";
            this.mnuFile_PrintPreview.Size = new System.Drawing.Size(180, 22);
            this.mnuFile_PrintPreview.Tag = "TXITEM_PrintPreview";
            this.mnuFile_PrintPreview.Text = "Print Pre&view…";
            this.mnuFile_PrintPreview.Click += new System.EventHandler(this.mnuFile_PrintPreview_Click);
            // 
            // mnuFile_Print
            // 
            this.mnuFile_Print.MergeIndex = 7;
            this.mnuFile_Print.Name = "mnuFile_Print";
            this.mnuFile_Print.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.mnuFile_Print.Size = new System.Drawing.Size(180, 22);
            this.mnuFile_Print.Tag = "TXITEM_Print";
            this.mnuFile_Print.Text = "&Print…";
            this.mnuFile_Print.Click += new System.EventHandler(this.mnuFile_Print_Click);
            // 
            // menuItem10
            // 
            this.menuItem10.MergeIndex = 8;
            this.menuItem10.Name = "menuItem10";
            this.menuItem10.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuFile_UserManagement
            // 
            this.mnuFile_UserManagement.Name = "mnuFile_UserManagement";
            this.mnuFile_UserManagement.Size = new System.Drawing.Size(180, 22);
            this.mnuFile_UserManagement.Tag = "TXITEM_UserAdministration";
            this.mnuFile_UserManagement.Text = "&User Management...";
            this.mnuFile_UserManagement.Click += new System.EventHandler(this.mnuFile_UserManagement_Click);
            // 
            // mnuFile_UserAccess
            // 
            this.mnuFile_UserAccess.Name = "mnuFile_UserAccess";
            this.mnuFile_UserAccess.Size = new System.Drawing.Size(180, 22);
            this.mnuFile_UserAccess.Tag = "TXITEM_GrantUserAccess";
            this.mnuFile_UserAccess.Text = "User A&ccess...";
            this.mnuFile_UserAccess.Click += new System.EventHandler(this.mnuFile_UserAccess_Click);
            // 
            // mnuFile_Options
            // 
            this.mnuFile_Options.Name = "mnuFile_Options";
            this.mnuFile_Options.Size = new System.Drawing.Size(180, 22);
            this.mnuFile_Options.Tag = "TXITEM_Options";
            this.mnuFile_Options.Text = "&Options…";
            this.mnuFile_Options.Click += new System.EventHandler(this.mnuFile_Options_Click);
            // 
            // mnuFile_Exit
            // 
            this.mnuFile_Exit.Name = "mnuFile_Exit";
            this.mnuFile_Exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.mnuFile_Exit.Size = new System.Drawing.Size(180, 22);
            this.mnuFile_Exit.Tag = "TXITEM_Exit";
            this.mnuFile_Exit.Text = "E&xit";
            this.mnuFile_Exit.Click += new System.EventHandler(this.mnuFile_Exit_Click);
            // 
            // mnuEdit
            // 
            this.mnuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEdit_Undo,
            this.mnuEdit_Redo,
            this.menuItem4,
            this.mnuEdit_Cut,
            this.mnuEdit_Copy,
            this.mnuEdit_Paste,
            this.menuItem9,
            this.mnuEdit_SelectAll,
            this.menuItem13,
            this.mnuEdit_Find,
            this.mnuEdit_Replace,
            this.menuItem16,
            this.mnuEdit_Hyperlink,
            this.mnuEdit_Target,
            this.mnuEdit_TableOfContents,
            this.toolStripSeparator7,
            this.mnuEdit_Permissions,
            this.mnuEdit_ProtectDocument,
            this.toolStripMenuItem3,
            this.mnuEdit_Reviewing});
            this.mnuEdit.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mnuEdit.MergeIndex = 1;
            this.mnuEdit.Name = "mnuEdit";
            this.mnuEdit.ShortcutKeyDisplayString = "";
            this.mnuEdit.Size = new System.Drawing.Size(39, 19);
            this.mnuEdit.Text = "&Edit";
            this.mnuEdit.DropDownOpening += new System.EventHandler(this.mnuEdit_DropDownOpening);
            // 
            // mnuEdit_Undo
            // 
            this.mnuEdit_Undo.MergeIndex = 0;
            this.mnuEdit_Undo.Name = "mnuEdit_Undo";
            this.mnuEdit_Undo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.mnuEdit_Undo.Size = new System.Drawing.Size(174, 22);
            this.mnuEdit_Undo.Tag = "TXITEM_Undo";
            this.mnuEdit_Undo.Text = "&Undo";
            this.mnuEdit_Undo.Click += new System.EventHandler(this.mnuEdit_Undo_Click);
            // 
            // mnuEdit_Redo
            // 
            this.mnuEdit_Redo.MergeIndex = 1;
            this.mnuEdit_Redo.Name = "mnuEdit_Redo";
            this.mnuEdit_Redo.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this.mnuEdit_Redo.Size = new System.Drawing.Size(174, 22);
            this.mnuEdit_Redo.Tag = "TXITEM_Redo";
            this.mnuEdit_Redo.Text = "&Redo";
            this.mnuEdit_Redo.Click += new System.EventHandler(this.mnuEdit_Redo_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.MergeIndex = 2;
            this.menuItem4.Name = "menuItem4";
            this.menuItem4.Size = new System.Drawing.Size(171, 6);
            // 
            // mnuEdit_Cut
            // 
            this.mnuEdit_Cut.MergeIndex = 3;
            this.mnuEdit_Cut.Name = "mnuEdit_Cut";
            this.mnuEdit_Cut.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.mnuEdit_Cut.Size = new System.Drawing.Size(174, 22);
            this.mnuEdit_Cut.Tag = "TXITEM_Cut";
            this.mnuEdit_Cut.Text = "Cu&t";
            this.mnuEdit_Cut.Click += new System.EventHandler(this.mnuEdit_Cut_Click);
            // 
            // mnuEdit_Copy
            // 
            this.mnuEdit_Copy.MergeIndex = 4;
            this.mnuEdit_Copy.Name = "mnuEdit_Copy";
            this.mnuEdit_Copy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuEdit_Copy.Size = new System.Drawing.Size(174, 22);
            this.mnuEdit_Copy.Tag = "TXITEM_Copy";
            this.mnuEdit_Copy.Text = "&Copy";
            this.mnuEdit_Copy.Click += new System.EventHandler(this.mnuEdit_Copy_Click);
            // 
            // mnuEdit_Paste
            // 
            this.mnuEdit_Paste.MergeIndex = 5;
            this.mnuEdit_Paste.Name = "mnuEdit_Paste";
            this.mnuEdit_Paste.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.mnuEdit_Paste.Size = new System.Drawing.Size(174, 22);
            this.mnuEdit_Paste.Tag = "TXITEM_Paste";
            this.mnuEdit_Paste.Text = "&Paste";
            this.mnuEdit_Paste.Click += new System.EventHandler(this.mnuEdit_Paste_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.MergeIndex = 6;
            this.menuItem9.Name = "menuItem9";
            this.menuItem9.Size = new System.Drawing.Size(171, 6);
            // 
            // mnuEdit_SelectAll
            // 
            this.mnuEdit_SelectAll.MergeIndex = 8;
            this.mnuEdit_SelectAll.Name = "mnuEdit_SelectAll";
            this.mnuEdit_SelectAll.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mnuEdit_SelectAll.Size = new System.Drawing.Size(174, 22);
            this.mnuEdit_SelectAll.Tag = "TXITEM_SelectAll";
            this.mnuEdit_SelectAll.Text = "Select &All";
            this.mnuEdit_SelectAll.Click += new System.EventHandler(this.mnuEdit_SelectAll_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.MergeIndex = 9;
            this.menuItem13.Name = "menuItem13";
            this.menuItem13.Size = new System.Drawing.Size(171, 6);
            // 
            // mnuEdit_Find
            // 
            this.mnuEdit_Find.MergeIndex = 10;
            this.mnuEdit_Find.Name = "mnuEdit_Find";
            this.mnuEdit_Find.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.mnuEdit_Find.Size = new System.Drawing.Size(174, 22);
            this.mnuEdit_Find.Tag = "TXITEM_Find";
            this.mnuEdit_Find.Text = "&Find";
            this.mnuEdit_Find.Click += new System.EventHandler(this.mnuEdit_Find_Click);
            // 
            // mnuEdit_Replace
            // 
            this.mnuEdit_Replace.MergeIndex = 11;
            this.mnuEdit_Replace.Name = "mnuEdit_Replace";
            this.mnuEdit_Replace.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mnuEdit_Replace.Size = new System.Drawing.Size(174, 22);
            this.mnuEdit_Replace.Tag = "TXITEM_Replace";
            this.mnuEdit_Replace.Text = "R&eplace";
            this.mnuEdit_Replace.Click += new System.EventHandler(this.mnuEdit_Replace_Click);
            // 
            // menuItem16
            // 
            this.menuItem16.MergeIndex = 12;
            this.menuItem16.Name = "menuItem16";
            this.menuItem16.Size = new System.Drawing.Size(171, 6);
            // 
            // mnuEdit_Hyperlink
            // 
            this.mnuEdit_Hyperlink.MergeIndex = 13;
            this.mnuEdit_Hyperlink.Name = "mnuEdit_Hyperlink";
            this.mnuEdit_Hyperlink.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.mnuEdit_Hyperlink.Size = new System.Drawing.Size(174, 22);
            this.mnuEdit_Hyperlink.Tag = "TXITEM_EditHyperlink";
            this.mnuEdit_Hyperlink.Text = "&Hyperlink…";
            this.mnuEdit_Hyperlink.Click += new System.EventHandler(this.mnuEdit_Hyperlink_Click);
            // 
            // mnuEdit_Target
            // 
            this.mnuEdit_Target.MergeIndex = 14;
            this.mnuEdit_Target.Name = "mnuEdit_Target";
            this.mnuEdit_Target.Size = new System.Drawing.Size(174, 22);
            this.mnuEdit_Target.Tag = "TXITEM_EditBookmark";
            this.mnuEdit_Target.Text = "&Bookmark…";
            this.mnuEdit_Target.Click += new System.EventHandler(this.mnuEdit_Target_Click);
            // 
            // mnuEdit_TableOfContents
            // 
            this.mnuEdit_TableOfContents.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEdit_TableOfContents_Edit,
            this.mnuEdit_TableOfContents_Update,
            this.mnuEdit_TableOfContents_Delete});
            this.mnuEdit_TableOfContents.Name = "mnuEdit_TableOfContents";
            this.mnuEdit_TableOfContents.Size = new System.Drawing.Size(174, 22);
            this.mnuEdit_TableOfContents.Tag = "TXITEM_TableOfContentsGroup";
            this.mnuEdit_TableOfContents.Text = "Table of Contents";
            // 
            // mnuEdit_TableOfContents_Edit
            // 
            this.mnuEdit_TableOfContents_Edit.Name = "mnuEdit_TableOfContents_Edit";
            this.mnuEdit_TableOfContents_Edit.Size = new System.Drawing.Size(112, 22);
            this.mnuEdit_TableOfContents_Edit.Tag = "TXITEM_ModifyTableOfContents";
            this.mnuEdit_TableOfContents_Edit.Text = "Edit...";
            this.mnuEdit_TableOfContents_Edit.Click += new System.EventHandler(this.mnuEdit_TableOfContents_Edit_Click);
            // 
            // mnuEdit_TableOfContents_Update
            // 
            this.mnuEdit_TableOfContents_Update.Name = "mnuEdit_TableOfContents_Update";
            this.mnuEdit_TableOfContents_Update.Size = new System.Drawing.Size(112, 22);
            this.mnuEdit_TableOfContents_Update.Tag = "TXITEM_UpdateTableOfContents";
            this.mnuEdit_TableOfContents_Update.Text = "Update";
            this.mnuEdit_TableOfContents_Update.Click += new System.EventHandler(this.mnuEdit_TableOfContents_Update_Click);
            // 
            // mnuEdit_TableOfContents_Delete
            // 
            this.mnuEdit_TableOfContents_Delete.Name = "mnuEdit_TableOfContents_Delete";
            this.mnuEdit_TableOfContents_Delete.Size = new System.Drawing.Size(112, 22);
            this.mnuEdit_TableOfContents_Delete.Tag = "TXITEM_DeleteTableOfContents";
            this.mnuEdit_TableOfContents_Delete.Text = "Delete";
            this.mnuEdit_TableOfContents_Delete.Click += new System.EventHandler(this.mnuEdit_TableOfContents_Delete_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(171, 6);
            // 
            // mnuEdit_Permissions
            // 
            this.mnuEdit_Permissions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEdit_Permissions_ReadOnly,
            this.mnuEdit_Permissions_AllowCopy,
            this.mnuEdit_Permissions_AllowFormatting,
            this.mnuEdit_Permissions_AllowFormattingStyles,
            this.mnuEdit_Permissions_AllowEditingFormFields,
            this.mnuEdit_Permissions_AllowPrinting});
            this.mnuEdit_Permissions.Name = "mnuEdit_Permissions";
            this.mnuEdit_Permissions.Size = new System.Drawing.Size(174, 22);
            this.mnuEdit_Permissions.Text = "&Permissions";
            this.mnuEdit_Permissions.DropDownOpening += new System.EventHandler(this.mnuEdit_Permissions_DropDownOpening);
            // 
            // mnuEdit_Permissions_ReadOnly
            // 
            this.mnuEdit_Permissions_ReadOnly.Name = "mnuEdit_Permissions_ReadOnly";
            this.mnuEdit_Permissions_ReadOnly.Size = new System.Drawing.Size(203, 22);
            this.mnuEdit_Permissions_ReadOnly.Tag = "TXITEM_ReadOnly";
            this.mnuEdit_Permissions_ReadOnly.Text = "Read Only";
            this.mnuEdit_Permissions_ReadOnly.Click += new System.EventHandler(this.mnuEdit_Permissions_ReadOnly_Click);
            // 
            // mnuEdit_Permissions_AllowCopy
            // 
            this.mnuEdit_Permissions_AllowCopy.Name = "mnuEdit_Permissions_AllowCopy";
            this.mnuEdit_Permissions_AllowCopy.Size = new System.Drawing.Size(203, 22);
            this.mnuEdit_Permissions_AllowCopy.Tag = "TXITEM_AllowCopy";
            this.mnuEdit_Permissions_AllowCopy.Text = "Allow Copy";
            this.mnuEdit_Permissions_AllowCopy.Click += new System.EventHandler(this.mnuEdit_Permissions_AllowCopy_Click);
            // 
            // mnuEdit_Permissions_AllowFormatting
            // 
            this.mnuEdit_Permissions_AllowFormatting.Name = "mnuEdit_Permissions_AllowFormatting";
            this.mnuEdit_Permissions_AllowFormatting.Size = new System.Drawing.Size(203, 22);
            this.mnuEdit_Permissions_AllowFormatting.Tag = "TXITEM_AllowFormatting";
            this.mnuEdit_Permissions_AllowFormatting.Text = "Allow Formatting";
            this.mnuEdit_Permissions_AllowFormatting.Click += new System.EventHandler(this.mnuEdit_Permissions_AllowFormatting_Click);
            // 
            // mnuEdit_Permissions_AllowFormattingStyles
            // 
            this.mnuEdit_Permissions_AllowFormattingStyles.Name = "mnuEdit_Permissions_AllowFormattingStyles";
            this.mnuEdit_Permissions_AllowFormattingStyles.Size = new System.Drawing.Size(203, 22);
            this.mnuEdit_Permissions_AllowFormattingStyles.Tag = "TXITEM_AllowFormattingStyles";
            this.mnuEdit_Permissions_AllowFormattingStyles.Text = "Allow Formatting Styles";
            this.mnuEdit_Permissions_AllowFormattingStyles.Click += new System.EventHandler(this.mnuEdit_Permissions_AllowFormattingStyles_Click);
            // 
            // mnuEdit_Permissions_AllowEditingFormFields
            // 
            this.mnuEdit_Permissions_AllowEditingFormFields.Name = "mnuEdit_Permissions_AllowEditingFormFields";
            this.mnuEdit_Permissions_AllowEditingFormFields.Size = new System.Drawing.Size(203, 22);
            this.mnuEdit_Permissions_AllowEditingFormFields.Tag = "TXITEM_FillInFormFields";
            this.mnuEdit_Permissions_AllowEditingFormFields.Text = "Allow Editing Formfields";
            this.mnuEdit_Permissions_AllowEditingFormFields.Click += new System.EventHandler(this.mnuEdit_Permissions_AllowEditingFormFields_Click);
            // 
            // mnuEdit_Permissions_AllowPrinting
            // 
            this.mnuEdit_Permissions_AllowPrinting.Name = "mnuEdit_Permissions_AllowPrinting";
            this.mnuEdit_Permissions_AllowPrinting.Size = new System.Drawing.Size(203, 22);
            this.mnuEdit_Permissions_AllowPrinting.Tag = "TXITEM_AllowPrinting";
            this.mnuEdit_Permissions_AllowPrinting.Text = "Allow Printing";
            this.mnuEdit_Permissions_AllowPrinting.Click += new System.EventHandler(this.mnuEdit_Permissions_AllowPrinting_Click);
            // 
            // mnuEdit_ProtectDocument
            // 
            this.mnuEdit_ProtectDocument.Name = "mnuEdit_ProtectDocument";
            this.mnuEdit_ProtectDocument.ShortcutKeyDisplayString = "";
            this.mnuEdit_ProtectDocument.Size = new System.Drawing.Size(174, 22);
            this.mnuEdit_ProtectDocument.Tag = "TXITEM_EnforceProtection";
            this.mnuEdit_ProtectDocument.Text = "Pr&otect Document";
            this.mnuEdit_ProtectDocument.Click += new System.EventHandler(this.mnuEdit_ProtectDocument_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(171, 6);
            // 
            // mnuEdit_Reviewing
            // 
            this.mnuEdit_Reviewing.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEdit_Reviewing_TrackChanges,
            this.mnuEdit_Reviewing_ReviewChanges});
            this.mnuEdit_Reviewing.Name = "mnuEdit_Reviewing";
            this.mnuEdit_Reviewing.ShortcutKeyDisplayString = "";
            this.mnuEdit_Reviewing.Size = new System.Drawing.Size(174, 22);
            this.mnuEdit_Reviewing.Tag = "TXITEM_TrackChanges";
            this.mnuEdit_Reviewing.Text = "Reviewing";
            this.mnuEdit_Reviewing.DropDownOpening += new System.EventHandler(this.mnuEdit_Reviewing_DropDownOpening);
            // 
            // mnuEdit_Reviewing_TrackChanges
            // 
            this.mnuEdit_Reviewing_TrackChanges.CheckOnClick = true;
            this.mnuEdit_Reviewing_TrackChanges.Name = "mnuEdit_Reviewing_TrackChanges";
            this.mnuEdit_Reviewing_TrackChanges.Size = new System.Drawing.Size(169, 22);
            this.mnuEdit_Reviewing_TrackChanges.Tag = "TXITEM_TrackChanges";
            this.mnuEdit_Reviewing_TrackChanges.Text = "Track Changes";
            this.mnuEdit_Reviewing_TrackChanges.CheckedChanged += new System.EventHandler(this.mnuEdit_Reviewing_TrackChanges_CheckedChanged);
            // 
            // mnuEdit_Reviewing_ReviewChanges
            // 
            this.mnuEdit_Reviewing_ReviewChanges.Name = "mnuEdit_Reviewing_ReviewChanges";
            this.mnuEdit_Reviewing_ReviewChanges.Size = new System.Drawing.Size(169, 22);
            this.mnuEdit_Reviewing_ReviewChanges.Tag = "TXITEM_TrackedChanges_Dialog";
            this.mnuEdit_Reviewing_ReviewChanges.Text = "Review Changes...";
            this.mnuEdit_Reviewing_ReviewChanges.Click += new System.EventHandler(this.mnuEdit_Reviewing_ReviewChanges_Click);
            // 
            // mnuView
            // 
            this.mnuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuView_PageLayout,
            this.mnuView_Draft,
            this.menuItem8,
            this.mnuView_HeadersAndFooters,
            this.menuItem12,
            this.mnuView_Toolbar,
            this.mnuView_ButtonBar,
            this.mnuView_StatusBar,
            this.mnuView_HorizontalRuler,
            this.mnuView_VerticalRuler,
            this.menuItem20,
            this.mnuView_TextFrameMarkerLines,
            this.mnuView_DrawingMarkerLines,
            this.mnuView_DocumentTargetMarkers,
            this.menuItem19,
            this.mnuView_Zoom,
            this.toolStripSeparator6,
            this.mnuView_FormLayout});
            this.mnuView.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mnuView.MergeIndex = 2;
            this.mnuView.Name = "mnuView";
            this.mnuView.Size = new System.Drawing.Size(44, 19);
            this.mnuView.Text = "&View";
            this.mnuView.DropDownOpening += new System.EventHandler(this.mnuView_DropDownOpening);
            // 
            // mnuView_PageLayout
            // 
            this.mnuView_PageLayout.MergeIndex = 1;
            this.mnuView_PageLayout.Name = "mnuView_PageLayout";
            this.mnuView_PageLayout.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D1)));
            this.mnuView_PageLayout.Size = new System.Drawing.Size(202, 22);
            this.mnuView_PageLayout.Tag = "TXITEM_PrintLayout";
            this.mnuView_PageLayout.Text = "&Page Layout";
            this.mnuView_PageLayout.Click += new System.EventHandler(this.mnuView_PageLayout_Click);
            // 
            // mnuView_Draft
            // 
            this.mnuView_Draft.MergeIndex = 0;
            this.mnuView_Draft.Name = "mnuView_Draft";
            this.mnuView_Draft.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.mnuView_Draft.Size = new System.Drawing.Size(202, 22);
            this.mnuView_Draft.Tag = "TXITEM_Draft";
            this.mnuView_Draft.Text = "&Draft";
            this.mnuView_Draft.Click += new System.EventHandler(this.mnuView_Draft_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.MergeIndex = 2;
            this.menuItem8.Name = "menuItem8";
            this.menuItem8.Size = new System.Drawing.Size(199, 6);
            // 
            // mnuView_HeadersAndFooters
            // 
            this.mnuView_HeadersAndFooters.MergeIndex = 3;
            this.mnuView_HeadersAndFooters.Name = "mnuView_HeadersAndFooters";
            this.mnuView_HeadersAndFooters.Size = new System.Drawing.Size(202, 22);
            this.mnuView_HeadersAndFooters.Tag = "TXITEM_HeaderFooterGroup";
            this.mnuView_HeadersAndFooters.Text = "&Headers and Footers";
            this.mnuView_HeadersAndFooters.Click += new System.EventHandler(this.mnuView_HeadersAndFooters_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.MergeIndex = 4;
            this.menuItem12.Name = "menuItem12";
            this.menuItem12.Size = new System.Drawing.Size(199, 6);
            // 
            // mnuView_Toolbar
            // 
            this.mnuView_Toolbar.MergeIndex = 5;
            this.mnuView_Toolbar.Name = "mnuView_Toolbar";
            this.mnuView_Toolbar.Size = new System.Drawing.Size(202, 22);
            this.mnuView_Toolbar.Text = "&Toolbar";
            this.mnuView_Toolbar.Click += new System.EventHandler(this.mnuView_Toolbar_Click);
            // 
            // mnuView_ButtonBar
            // 
            this.mnuView_ButtonBar.MergeIndex = 6;
            this.mnuView_ButtonBar.Name = "mnuView_ButtonBar";
            this.mnuView_ButtonBar.Size = new System.Drawing.Size(202, 22);
            this.mnuView_ButtonBar.Text = "&Button Bar";
            this.mnuView_ButtonBar.Click += new System.EventHandler(this.mnuView_ButtonBar_Click);
            // 
            // mnuView_StatusBar
            // 
            this.mnuView_StatusBar.MergeIndex = 7;
            this.mnuView_StatusBar.Name = "mnuView_StatusBar";
            this.mnuView_StatusBar.Size = new System.Drawing.Size(202, 22);
            this.mnuView_StatusBar.Text = "&Status Bar";
            this.mnuView_StatusBar.Click += new System.EventHandler(this.mnuView_StatusBar_Click);
            // 
            // mnuView_HorizontalRuler
            // 
            this.mnuView_HorizontalRuler.MergeIndex = 8;
            this.mnuView_HorizontalRuler.Name = "mnuView_HorizontalRuler";
            this.mnuView_HorizontalRuler.Size = new System.Drawing.Size(202, 22);
            this.mnuView_HorizontalRuler.Text = "H&orizontal Ruler";
            this.mnuView_HorizontalRuler.Click += new System.EventHandler(this.mnuView_HorizontalRuler_Click);
            // 
            // mnuView_VerticalRuler
            // 
            this.mnuView_VerticalRuler.MergeIndex = 9;
            this.mnuView_VerticalRuler.Name = "mnuView_VerticalRuler";
            this.mnuView_VerticalRuler.Size = new System.Drawing.Size(202, 22);
            this.mnuView_VerticalRuler.Text = "&Vertical Ruler";
            this.mnuView_VerticalRuler.Click += new System.EventHandler(this.mnuView_VerticalRuler_Click);
            // 
            // menuItem20
            // 
            this.menuItem20.MergeIndex = 9;
            this.menuItem20.Name = "menuItem20";
            this.menuItem20.Size = new System.Drawing.Size(199, 6);
            // 
            // mnuView_TextFrameMarkerLines
            // 
            this.mnuView_TextFrameMarkerLines.Checked = true;
            this.mnuView_TextFrameMarkerLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuView_TextFrameMarkerLines.MergeIndex = 8;
            this.mnuView_TextFrameMarkerLines.Name = "mnuView_TextFrameMarkerLines";
            this.mnuView_TextFrameMarkerLines.Size = new System.Drawing.Size(202, 22);
            this.mnuView_TextFrameMarkerLines.Tag = "TXITEM_ShowTextFrameMarkersLines";
            this.mnuView_TextFrameMarkerLines.Text = "Text &Frame Marker Lines";
            this.mnuView_TextFrameMarkerLines.Click += new System.EventHandler(this.mnuView_TextFrameMarkerLines_Click);
            // 
            // mnuView_DrawingMarkerLines
            // 
            this.mnuView_DrawingMarkerLines.Checked = true;
            this.mnuView_DrawingMarkerLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuView_DrawingMarkerLines.Name = "mnuView_DrawingMarkerLines";
            this.mnuView_DrawingMarkerLines.Size = new System.Drawing.Size(202, 22);
            this.mnuView_DrawingMarkerLines.Tag = "TXITEM_DrawingMarkerLines";
            this.mnuView_DrawingMarkerLines.Text = "&Drawing Marker Lines";
            this.mnuView_DrawingMarkerLines.Click += new System.EventHandler(this.mnuView_DrawingMarkerLines_Click);
            // 
            // mnuView_DocumentTargetMarkers
            // 
            this.mnuView_DocumentTargetMarkers.Name = "mnuView_DocumentTargetMarkers";
            this.mnuView_DocumentTargetMarkers.Size = new System.Drawing.Size(202, 22);
            this.mnuView_DocumentTargetMarkers.Tag = "TXITEM_ShowBookmarkMarkers";
            this.mnuView_DocumentTargetMarkers.Text = "Bookmark &Markers";
            this.mnuView_DocumentTargetMarkers.Click += new System.EventHandler(this.mnuView_DocumentTargetMarkers_Click);
            // 
            // menuItem19
            // 
            this.menuItem19.MergeIndex = 10;
            this.menuItem19.Name = "menuItem19";
            this.menuItem19.Size = new System.Drawing.Size(199, 6);
            // 
            // mnuView_Zoom
            // 
            this.mnuView_Zoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuView_Zoom_25,
            this.mnuView_Zoom_50,
            this.mnuView_Zoom_75,
            this.mnuView_Zoom_100,
            this.mnuView_Zoom_150,
            this.mnuView_Zoom_200,
            this.mnuView_Zoom_300,
            this.mnuView_Zoom_400});
            this.mnuView_Zoom.MergeIndex = 11;
            this.mnuView_Zoom.Name = "mnuView_Zoom";
            this.mnuView_Zoom.Size = new System.Drawing.Size(202, 22);
            this.mnuView_Zoom.Tag = "TXITEM_ZoomFactor";
            this.mnuView_Zoom.Text = "&Zoom";
            this.mnuView_Zoom.DropDownOpening += new System.EventHandler(this.mnuView_Zoom_DropDownOpening);
            // 
            // mnuView_Zoom_25
            // 
            this.mnuView_Zoom_25.MergeIndex = 0;
            this.mnuView_Zoom_25.Name = "mnuView_Zoom_25";
            this.mnuView_Zoom_25.Size = new System.Drawing.Size(114, 22);
            this.mnuView_Zoom_25.Text = "&1  25%";
            this.mnuView_Zoom_25.Click += new System.EventHandler(this.mnuView_Zoom_25_Click);
            // 
            // mnuView_Zoom_50
            // 
            this.mnuView_Zoom_50.MergeIndex = 1;
            this.mnuView_Zoom_50.Name = "mnuView_Zoom_50";
            this.mnuView_Zoom_50.Size = new System.Drawing.Size(114, 22);
            this.mnuView_Zoom_50.Text = "&2  50%";
            this.mnuView_Zoom_50.Click += new System.EventHandler(this.mnuView_Zoom_50_Click);
            // 
            // mnuView_Zoom_75
            // 
            this.mnuView_Zoom_75.MergeIndex = 2;
            this.mnuView_Zoom_75.Name = "mnuView_Zoom_75";
            this.mnuView_Zoom_75.Size = new System.Drawing.Size(114, 22);
            this.mnuView_Zoom_75.Text = "&3  75%";
            this.mnuView_Zoom_75.Click += new System.EventHandler(this.mnuView_Zoom_75_Click);
            // 
            // mnuView_Zoom_100
            // 
            this.mnuView_Zoom_100.MergeIndex = 3;
            this.mnuView_Zoom_100.Name = "mnuView_Zoom_100";
            this.mnuView_Zoom_100.Size = new System.Drawing.Size(114, 22);
            this.mnuView_Zoom_100.Text = "&4  100%";
            this.mnuView_Zoom_100.Click += new System.EventHandler(this.mnuView_Zoom_100_Click);
            // 
            // mnuView_Zoom_150
            // 
            this.mnuView_Zoom_150.MergeIndex = 4;
            this.mnuView_Zoom_150.Name = "mnuView_Zoom_150";
            this.mnuView_Zoom_150.Size = new System.Drawing.Size(114, 22);
            this.mnuView_Zoom_150.Text = "&5  150%";
            this.mnuView_Zoom_150.Click += new System.EventHandler(this.mnuView_Zoom_150_Click);
            // 
            // mnuView_Zoom_200
            // 
            this.mnuView_Zoom_200.MergeIndex = 5;
            this.mnuView_Zoom_200.Name = "mnuView_Zoom_200";
            this.mnuView_Zoom_200.Size = new System.Drawing.Size(114, 22);
            this.mnuView_Zoom_200.Text = "&6  200%";
            this.mnuView_Zoom_200.Click += new System.EventHandler(this.mnuView_Zoom_200_Click);
            // 
            // mnuView_Zoom_300
            // 
            this.mnuView_Zoom_300.MergeIndex = 6;
            this.mnuView_Zoom_300.Name = "mnuView_Zoom_300";
            this.mnuView_Zoom_300.Size = new System.Drawing.Size(114, 22);
            this.mnuView_Zoom_300.Text = "&7  300%";
            this.mnuView_Zoom_300.Click += new System.EventHandler(this.mnuView_Zoom_300_Click);
            // 
            // mnuView_Zoom_400
            // 
            this.mnuView_Zoom_400.Name = "mnuView_Zoom_400";
            this.mnuView_Zoom_400.Size = new System.Drawing.Size(114, 22);
            this.mnuView_Zoom_400.Text = "&8  400%";
            this.mnuView_Zoom_400.Click += new System.EventHandler(this.mnuView_Zoom_400_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.MergeIndex = 12;
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(199, 6);
            // 
            // mnuView_FormLayout
            // 
            this.mnuView_FormLayout.MergeIndex = 13;
            this.mnuView_FormLayout.Name = "mnuView_FormLayout";
            this.mnuView_FormLayout.Size = new System.Drawing.Size(202, 22);
            this.mnuView_FormLayout.Tag = "TXIMAGE_FormLayoutRTL";
            this.mnuView_FormLayout.Text = "&Right to Left Layout";
            this.mnuView_FormLayout.Click += new System.EventHandler(this.mnuView_FormLayout_Click);
            // 
            // mnuInsert
            // 
            this.mnuInsert.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInsert_File,
            this.menuItem3,
            this.mnuInsert_Image,
            this.mnuInsert_Shapes,
            this.mnuInsert_TextFrame,
            this.mnuInsert_Chart,
            this.mnuInsert_pageNum,
            this.mnuInsert_TableOfContents,
            this.toolStripSep_mnuInsert1,
            this.mnuInsert_Fields,
            this.mnuInsert_FormFields,
            this.mnuInsert_Symbol,
            this.toolStripSep_mnuInsert2,
            this.mnuInsert_Hyperlink,
            this.mnuInsert_Target,
            this.toolStripSep_mnuInsert3,
            this.mnuInsert_Break,
            this.toolStripMenuItem4,
            this.mnuInsert_EditableRegion});
            this.mnuInsert.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mnuInsert.MergeIndex = 3;
            this.mnuInsert.Name = "mnuInsert";
            this.mnuInsert.Size = new System.Drawing.Size(48, 19);
            this.mnuInsert.Text = "&Insert";
            this.mnuInsert.DropDownOpening += new System.EventHandler(this.mnuInsert_DropDownOpening);
            // 
            // mnuInsert_File
            // 
            this.mnuInsert_File.MergeIndex = 0;
            this.mnuInsert_File.Name = "mnuInsert_File";
            this.mnuInsert_File.Size = new System.Drawing.Size(177, 22);
            this.mnuInsert_File.Tag = "TXITEM_InsertFile";
            this.mnuInsert_File.Text = "&File…";
            this.mnuInsert_File.Click += new System.EventHandler(this.mnuInsert_File_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.MergeIndex = 1;
            this.menuItem3.Name = "menuItem3";
            this.menuItem3.Size = new System.Drawing.Size(174, 6);
            // 
            // mnuInsert_Image
            // 
            this.mnuInsert_Image.MergeIndex = 2;
            this.mnuInsert_Image.Name = "mnuInsert_Image";
            this.mnuInsert_Image.Size = new System.Drawing.Size(177, 22);
            this.mnuInsert_Image.Tag = "TXITEM_InsertImage";
            this.mnuInsert_Image.Text = "&Image…";
            this.mnuInsert_Image.Click += new System.EventHandler(this.mnuInsert_Image_Click);
            // 
            // mnuInsert_Shapes
            // 
            this.mnuInsert_Shapes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInsert_Shapes_Lines,
            this.mnuInsert_Shapes_Rectangles,
            this.mnuInsert_Shapes_Basic,
            this.mnuInsert_Shapes_BlockArrows,
            this.mnuInsert_Shapes_Equation,
            this.mnuInsert_Shapes_FlowChart,
            this.mnuInsert_Shapes_StarsBanners,
            this.mnuInsert_Shapes_Callouts,
            this.sepShapeCat,
            this.mnuInsert_Shapes_DrawingCanvas});
            this.mnuInsert_Shapes.Name = "mnuInsert_Shapes";
            this.mnuInsert_Shapes.Size = new System.Drawing.Size(177, 22);
            this.mnuInsert_Shapes.Tag = "TXITEM_InsertShape";
            this.mnuInsert_Shapes.Text = "&Shape";
            this.mnuInsert_Shapes.DropDownOpening += new System.EventHandler(this.MnuInsert_Shapes_DropDownOpening);
            // 
            // mnuInsert_Shapes_Lines
            // 
            this.mnuInsert_Shapes_Lines.Name = "mnuInsert_Shapes_Lines";
            this.mnuInsert_Shapes_Lines.Size = new System.Drawing.Size(167, 22);
            this.mnuInsert_Shapes_Lines.Tag = "TXITEM_SHAPE_Line";
            this.mnuInsert_Shapes_Lines.Text = "&Lines";
            // 
            // mnuInsert_Shapes_Rectangles
            // 
            this.mnuInsert_Shapes_Rectangles.Name = "mnuInsert_Shapes_Rectangles";
            this.mnuInsert_Shapes_Rectangles.Size = new System.Drawing.Size(167, 22);
            this.mnuInsert_Shapes_Rectangles.Tag = "TXITEM_SHAPE_Rectangle";
            this.mnuInsert_Shapes_Rectangles.Text = "&Rectangles";
            // 
            // mnuInsert_Shapes_Basic
            // 
            this.mnuInsert_Shapes_Basic.Name = "mnuInsert_Shapes_Basic";
            this.mnuInsert_Shapes_Basic.Size = new System.Drawing.Size(167, 22);
            this.mnuInsert_Shapes_Basic.Tag = "TXITEM_SHAPE_Ellipse";
            this.mnuInsert_Shapes_Basic.Text = "&Basic Shapes";
            // 
            // mnuInsert_Shapes_BlockArrows
            // 
            this.mnuInsert_Shapes_BlockArrows.Name = "mnuInsert_Shapes_BlockArrows";
            this.mnuInsert_Shapes_BlockArrows.Size = new System.Drawing.Size(167, 22);
            this.mnuInsert_Shapes_BlockArrows.Tag = "TXITEM_SHAPE_RightArrow";
            this.mnuInsert_Shapes_BlockArrows.Text = "Block &Arrows";
            // 
            // mnuInsert_Shapes_Equation
            // 
            this.mnuInsert_Shapes_Equation.Name = "mnuInsert_Shapes_Equation";
            this.mnuInsert_Shapes_Equation.Size = new System.Drawing.Size(167, 22);
            this.mnuInsert_Shapes_Equation.Tag = "TXITEM_SHAPE_MathEqual";
            this.mnuInsert_Shapes_Equation.Text = "&Equation Shapes";
            // 
            // mnuInsert_Shapes_FlowChart
            // 
            this.mnuInsert_Shapes_FlowChart.Name = "mnuInsert_Shapes_FlowChart";
            this.mnuInsert_Shapes_FlowChart.Size = new System.Drawing.Size(167, 22);
            this.mnuInsert_Shapes_FlowChart.Tag = "TXITEM_SHAPE_FlowChartMultidocument";
            this.mnuInsert_Shapes_FlowChart.Text = "&Flowchart";
            // 
            // mnuInsert_Shapes_StarsBanners
            // 
            this.mnuInsert_Shapes_StarsBanners.Name = "mnuInsert_Shapes_StarsBanners";
            this.mnuInsert_Shapes_StarsBanners.Size = new System.Drawing.Size(167, 22);
            this.mnuInsert_Shapes_StarsBanners.Tag = "TXITEM_SHAPE_Star7";
            this.mnuInsert_Shapes_StarsBanners.Text = "&Stars and Banners";
            // 
            // mnuInsert_Shapes_Callouts
            // 
            this.mnuInsert_Shapes_Callouts.Name = "mnuInsert_Shapes_Callouts";
            this.mnuInsert_Shapes_Callouts.Size = new System.Drawing.Size(167, 22);
            this.mnuInsert_Shapes_Callouts.Tag = "TXITEM_SHAPE_WedgeRectangleCallout";
            this.mnuInsert_Shapes_Callouts.Text = "&Callouts";
            // 
            // sepShapeCat
            // 
            this.sepShapeCat.Name = "sepShapeCat";
            this.sepShapeCat.Size = new System.Drawing.Size(164, 6);
            // 
            // mnuInsert_Shapes_DrawingCanvas
            // 
            this.mnuInsert_Shapes_DrawingCanvas.Name = "mnuInsert_Shapes_DrawingCanvas";
            this.mnuInsert_Shapes_DrawingCanvas.Size = new System.Drawing.Size(167, 22);
            this.mnuInsert_Shapes_DrawingCanvas.Tag = "TXITEM_InsertDrawingCanvas";
            this.mnuInsert_Shapes_DrawingCanvas.Text = "&Drawing Canvas";
            this.mnuInsert_Shapes_DrawingCanvas.Click += new System.EventHandler(this.mnuInsert_Shapes_DrawingCanvas_Click);
            // 
            // mnuInsert_TextFrame
            // 
            this.mnuInsert_TextFrame.MergeIndex = 3;
            this.mnuInsert_TextFrame.Name = "mnuInsert_TextFrame";
            this.mnuInsert_TextFrame.Size = new System.Drawing.Size(177, 22);
            this.mnuInsert_TextFrame.Tag = "TXITEM_InsertTextFrame";
            this.mnuInsert_TextFrame.Text = "Te&xt Frame";
            this.mnuInsert_TextFrame.Click += new System.EventHandler(this.mnuInsert_TextFrame_Click);
            // 
            // mnuInsert_Chart
            // 
            this.mnuInsert_Chart.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInsert_chart_area,
            this.mnuInsert_chart_bar,
            this.mnuInsert_chart_column,
            this.mnuInsert_chart_clusteredBar,
            this.mnuInsert_chart_pie});
            this.mnuInsert_Chart.Name = "mnuInsert_Chart";
            this.mnuInsert_Chart.Size = new System.Drawing.Size(177, 22);
            this.mnuInsert_Chart.Tag = "TXITEM_InsertChart";
            this.mnuInsert_Chart.Text = "&Chart";
            // 
            // mnuInsert_chart_area
            // 
            this.mnuInsert_chart_area.Name = "mnuInsert_chart_area";
            this.mnuInsert_chart_area.Size = new System.Drawing.Size(117, 22);
            this.mnuInsert_chart_area.Tag = "TXIMAGE_Charts.StackedArea100Percent";
            this.mnuInsert_chart_area.Text = "&Area";
            this.mnuInsert_chart_area.Click += new System.EventHandler(this.mnuInsert_chart_area_Click);
            // 
            // mnuInsert_chart_bar
            // 
            this.mnuInsert_chart_bar.Name = "mnuInsert_chart_bar";
            this.mnuInsert_chart_bar.Size = new System.Drawing.Size(117, 22);
            this.mnuInsert_chart_bar.Tag = "TXIMAGE_Charts.StackedBar";
            this.mnuInsert_chart_bar.Text = "&Bar";
            this.mnuInsert_chart_bar.Click += new System.EventHandler(this.mnuInsert_chart_bar_Click);
            // 
            // mnuInsert_chart_column
            // 
            this.mnuInsert_chart_column.Name = "mnuInsert_chart_column";
            this.mnuInsert_chart_column.Size = new System.Drawing.Size(117, 22);
            this.mnuInsert_chart_column.Tag = "TXIMAGE_Charts.StackedColumn100Percent";
            this.mnuInsert_chart_column.Text = "&Column";
            this.mnuInsert_chart_column.Click += new System.EventHandler(this.mnuInsert_chart_column_Click);
            // 
            // mnuInsert_chart_clusteredBar
            // 
            this.mnuInsert_chart_clusteredBar.Name = "mnuInsert_chart_clusteredBar";
            this.mnuInsert_chart_clusteredBar.Size = new System.Drawing.Size(117, 22);
            this.mnuInsert_chart_clusteredBar.Tag = "TXIMAGE_Charts.ClusteredBar";
            this.mnuInsert_chart_clusteredBar.Text = "&Line";
            this.mnuInsert_chart_clusteredBar.Click += new System.EventHandler(this.mnuInsert_chart_clusteredBar_Click);
            // 
            // mnuInsert_chart_pie
            // 
            this.mnuInsert_chart_pie.Name = "mnuInsert_chart_pie";
            this.mnuInsert_chart_pie.Size = new System.Drawing.Size(117, 22);
            this.mnuInsert_chart_pie.Tag = "TXIMAGE_Charts.Pie";
            this.mnuInsert_chart_pie.Text = "&Pie";
            this.mnuInsert_chart_pie.Click += new System.EventHandler(this.mnuInsert_chart_pie_Click);
            // 
            // mnuInsert_pageNum
            // 
            this.mnuInsert_pageNum.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInsert_PageNum_Insert,
            this.mnuInsert_PageNum_Delete});
            this.mnuInsert_pageNum.Name = "mnuInsert_pageNum";
            this.mnuInsert_pageNum.Size = new System.Drawing.Size(177, 22);
            this.mnuInsert_pageNum.Tag = "TXITEM_InsertPageNumber";
            this.mnuInsert_pageNum.Text = "&Page Number";
            // 
            // mnuInsert_PageNum_Insert
            // 
            this.mnuInsert_PageNum_Insert.Name = "mnuInsert_PageNum_Insert";
            this.mnuInsert_PageNum_Insert.Size = new System.Drawing.Size(188, 22);
            this.mnuInsert_PageNum_Insert.Tag = "TXITEM_InsertStandardPageNumber";
            this.mnuInsert_PageNum_Insert.Text = "&Insert Page Number";
            this.mnuInsert_PageNum_Insert.Click += new System.EventHandler(this.mnuInsert_PageNum_Click);
            // 
            // mnuInsert_PageNum_Delete
            // 
            this.mnuInsert_PageNum_Delete.Name = "mnuInsert_PageNum_Delete";
            this.mnuInsert_PageNum_Delete.Size = new System.Drawing.Size(188, 22);
            this.mnuInsert_PageNum_Delete.Tag = "TXITEM_RemovePageNumber";
            this.mnuInsert_PageNum_Delete.Text = "&Delete Page Numbers";
            this.mnuInsert_PageNum_Delete.Click += new System.EventHandler(this.mnuInsert_PageNum_Delete_Click);
            // 
            // mnuInsert_TableOfContents
            // 
            this.mnuInsert_TableOfContents.Name = "mnuInsert_TableOfContents";
            this.mnuInsert_TableOfContents.Size = new System.Drawing.Size(177, 22);
            this.mnuInsert_TableOfContents.Tag = "TXITEM_InsertTableOfContents";
            this.mnuInsert_TableOfContents.Text = "Table of Contents...";
            this.mnuInsert_TableOfContents.Click += new System.EventHandler(this.mnuInsert_TableOfContents_Click);
            // 
            // toolStripSep_mnuInsert1
            // 
            this.toolStripSep_mnuInsert1.Name = "toolStripSep_mnuInsert1";
            this.toolStripSep_mnuInsert1.Size = new System.Drawing.Size(174, 6);
            // 
            // mnuInsert_Fields
            // 
            this.mnuInsert_Fields.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInsert_Fields_insertMergeField,
            this.mnuInsert_Fields_insertSpecialField,
            this.mnuInsert_Fields_highlightMergeFields,
            this.toolStripSeparator14,
            this.mnuInsert_Fields_showFieldCodes,
            this.mnuInsert_Fields_showFieldText,
            this.sep_field01,
            this.mnuInsert_Fields_deleteField});
            this.mnuInsert_Fields.Name = "mnuInsert_Fields";
            this.mnuInsert_Fields.Size = new System.Drawing.Size(177, 22);
            this.mnuInsert_Fields.Tag = "TXITEM_InsertMergeField";
            this.mnuInsert_Fields.Text = "M&erge Fields";
            this.mnuInsert_Fields.DropDownOpening += new System.EventHandler(this.mnuInsert_Fields_DropDownOpening);
            // 
            // mnuInsert_Fields_insertMergeField
            // 
            this.mnuInsert_Fields_insertMergeField.Name = "mnuInsert_Fields_insertMergeField";
            this.mnuInsert_Fields_insertMergeField.Size = new System.Drawing.Size(194, 22);
            this.mnuInsert_Fields_insertMergeField.Tag = "TXITEM_InsertMergeField";
            this.mnuInsert_Fields_insertMergeField.Text = "&Insert Merge Field...";
            this.mnuInsert_Fields_insertMergeField.Click += new System.EventHandler(this.mnuInsert_Fields_insertMergeField_Click);
            // 
            // mnuInsert_Fields_insertSpecialField
            // 
            this.mnuInsert_Fields_insertSpecialField.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInsert_Fields_insertSpecialField_IF,
            this.mnuInsert_Fields_insertSpecialField_inclText,
            this.mnuInsert_Fields_insertSpecialField_date,
            this.mnuInsert_Fields_insertSpecialField_next,
            this.mnuInsert_Fields_insertSpecialField_nextif});
            this.mnuInsert_Fields_insertSpecialField.Name = "mnuInsert_Fields_insertSpecialField";
            this.mnuInsert_Fields_insertSpecialField.Size = new System.Drawing.Size(194, 22);
            this.mnuInsert_Fields_insertSpecialField.Tag = "TXITEM_InsertSpecialField";
            this.mnuInsert_Fields_insertSpecialField.Text = "Insert &Special Field";
            // 
            // mnuInsert_Fields_insertSpecialField_IF
            // 
            this.mnuInsert_Fields_insertSpecialField_IF.Name = "mnuInsert_Fields_insertSpecialField_IF";
            this.mnuInsert_Fields_insertSpecialField_IF.Size = new System.Drawing.Size(144, 22);
            this.mnuInsert_Fields_insertSpecialField_IF.Tag = "TXITEM_InsertSpecialField_IF";
            this.mnuInsert_Fields_insertSpecialField_IF.Text = "&IF...";
            this.mnuInsert_Fields_insertSpecialField_IF.Click += new System.EventHandler(this.mnuInsert_Fields_insertSpecialField_IF_Click);
            // 
            // mnuInsert_Fields_insertSpecialField_inclText
            // 
            this.mnuInsert_Fields_insertSpecialField_inclText.Name = "mnuInsert_Fields_insertSpecialField_inclText";
            this.mnuInsert_Fields_insertSpecialField_inclText.Size = new System.Drawing.Size(144, 22);
            this.mnuInsert_Fields_insertSpecialField_inclText.Tag = "TXITEM_InsertSpecialField_IncludeText";
            this.mnuInsert_Fields_insertSpecialField_inclText.Text = "I&ncludeText...";
            this.mnuInsert_Fields_insertSpecialField_inclText.Click += new System.EventHandler(this.mnuInsert_Fields_insertSpecialField_inclText_Click);
            // 
            // mnuInsert_Fields_insertSpecialField_date
            // 
            this.mnuInsert_Fields_insertSpecialField_date.Name = "mnuInsert_Fields_insertSpecialField_date";
            this.mnuInsert_Fields_insertSpecialField_date.Size = new System.Drawing.Size(144, 22);
            this.mnuInsert_Fields_insertSpecialField_date.Tag = "TXITEM_InsertSpecialField_Date";
            this.mnuInsert_Fields_insertSpecialField_date.Text = "&Date...";
            this.mnuInsert_Fields_insertSpecialField_date.Click += new System.EventHandler(this.mnuInsert_Fields_insertSpecialField_date_Click);
            // 
            // mnuInsert_Fields_insertSpecialField_next
            // 
            this.mnuInsert_Fields_insertSpecialField_next.Name = "mnuInsert_Fields_insertSpecialField_next";
            this.mnuInsert_Fields_insertSpecialField_next.Size = new System.Drawing.Size(144, 22);
            this.mnuInsert_Fields_insertSpecialField_next.Tag = "TXITEM_InsertSpecialField_Next";
            this.mnuInsert_Fields_insertSpecialField_next.Text = "N&ext";
            this.mnuInsert_Fields_insertSpecialField_next.Click += new System.EventHandler(this.mnuInsert_Fields_insertSpecialField_next_Click);
            // 
            // mnuInsert_Fields_insertSpecialField_nextif
            // 
            this.mnuInsert_Fields_insertSpecialField_nextif.Name = "mnuInsert_Fields_insertSpecialField_nextif";
            this.mnuInsert_Fields_insertSpecialField_nextif.Size = new System.Drawing.Size(144, 22);
            this.mnuInsert_Fields_insertSpecialField_nextif.Tag = "TXITEM_InsertSpecialField_NextIf";
            this.mnuInsert_Fields_insertSpecialField_nextif.Text = "Nex&tIf...";
            this.mnuInsert_Fields_insertSpecialField_nextif.Click += new System.EventHandler(this.mnuInsert_Fields_insertSpecialField_nextif_Click);
            // 
            // mnuInsert_Fields_highlightMergeFields
            // 
            this.mnuInsert_Fields_highlightMergeFields.Checked = true;
            this.mnuInsert_Fields_highlightMergeFields.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuInsert_Fields_highlightMergeFields.Name = "mnuInsert_Fields_highlightMergeFields";
            this.mnuInsert_Fields_highlightMergeFields.Size = new System.Drawing.Size(194, 22);
            this.mnuInsert_Fields_highlightMergeFields.Tag = "TXITEM_InsertMergeField_HighlightMergeFields";
            this.mnuInsert_Fields_highlightMergeFields.Text = "&Highlight Merge Fields";
            this.mnuInsert_Fields_highlightMergeFields.Click += new System.EventHandler(this.mnuInsert_Fields_highlightMergeFields_Click);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            this.toolStripSeparator14.Size = new System.Drawing.Size(191, 6);
            // 
            // mnuInsert_Fields_showFieldCodes
            // 
            this.mnuInsert_Fields_showFieldCodes.Name = "mnuInsert_Fields_showFieldCodes";
            this.mnuInsert_Fields_showFieldCodes.Size = new System.Drawing.Size(194, 22);
            this.mnuInsert_Fields_showFieldCodes.Tag = "TXITEM_ShowFieldCodes";
            this.mnuInsert_Fields_showFieldCodes.Text = "Show Field &Codes";
            this.mnuInsert_Fields_showFieldCodes.Click += new System.EventHandler(this.mnuInsert_Fields_showFieldCodes_Click);
            // 
            // mnuInsert_Fields_showFieldText
            // 
            this.mnuInsert_Fields_showFieldText.Checked = true;
            this.mnuInsert_Fields_showFieldText.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuInsert_Fields_showFieldText.Name = "mnuInsert_Fields_showFieldText";
            this.mnuInsert_Fields_showFieldText.Size = new System.Drawing.Size(194, 22);
            this.mnuInsert_Fields_showFieldText.Tag = "TXITEM_ShowFieldText";
            this.mnuInsert_Fields_showFieldText.Text = "Show Field &Text";
            this.mnuInsert_Fields_showFieldText.Click += new System.EventHandler(this.mnuInsert_Fields_showFieldText_Click);
            // 
            // sep_field01
            // 
            this.sep_field01.Name = "sep_field01";
            this.sep_field01.Size = new System.Drawing.Size(191, 6);
            // 
            // mnuInsert_Fields_deleteField
            // 
            this.mnuInsert_Fields_deleteField.Name = "mnuInsert_Fields_deleteField";
            this.mnuInsert_Fields_deleteField.Size = new System.Drawing.Size(194, 22);
            this.mnuInsert_Fields_deleteField.Tag = "TXITEM_DeleteField";
            this.mnuInsert_Fields_deleteField.Text = "&Delete Field";
            this.mnuInsert_Fields_deleteField.Click += new System.EventHandler(this.mnuInsert_Fields_deleteField_Click);
            // 
            // mnuInsert_FormFields
            // 
            this.mnuInsert_FormFields.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInsert_FormFields_TextFormField,
            this.mnuInsert_FormFields_CheckFormField,
            this.mnuInsert_FormFields_ComboBoxFormField,
            this.mnuInsert_FormFields_DropDownListFormField,
            this.mnuInsert_FormFields_DatePicker});
            this.mnuInsert_FormFields.Name = "mnuInsert_FormFields";
            this.mnuInsert_FormFields.Size = new System.Drawing.Size(177, 22);
            this.mnuInsert_FormFields.Tag = "TXITEM_InsertFormFieldsGroup";
            this.mnuInsert_FormFields.Text = "F&orm Fields";
            this.mnuInsert_FormFields.DropDownOpening += new System.EventHandler(this.mnuInsert_FormFields_DropDownOpening);
            // 
            // mnuInsert_FormFields_TextFormField
            // 
            this.mnuInsert_FormFields_TextFormField.Name = "mnuInsert_FormFields_TextFormField";
            this.mnuInsert_FormFields_TextFormField.Size = new System.Drawing.Size(166, 22);
            this.mnuInsert_FormFields_TextFormField.Tag = "TXITEM_InsertTextFormField";
            this.mnuInsert_FormFields_TextFormField.Text = "&Textform";
            this.mnuInsert_FormFields_TextFormField.Click += new System.EventHandler(this.mnuInsert_FormFields_TextFormField_Click);
            // 
            // mnuInsert_FormFields_CheckFormField
            // 
            this.mnuInsert_FormFields_CheckFormField.Name = "mnuInsert_FormFields_CheckFormField";
            this.mnuInsert_FormFields_CheckFormField.Size = new System.Drawing.Size(166, 22);
            this.mnuInsert_FormFields_CheckFormField.Tag = "TXITEM_InsertCheckBoxField";
            this.mnuInsert_FormFields_CheckFormField.Text = "&Checkform";
            this.mnuInsert_FormFields_CheckFormField.Click += new System.EventHandler(this.mnuInsert_FormFields_CheckFormField_Click);
            // 
            // mnuInsert_FormFields_ComboBoxFormField
            // 
            this.mnuInsert_FormFields_ComboBoxFormField.Name = "mnuInsert_FormFields_ComboBoxFormField";
            this.mnuInsert_FormFields_ComboBoxFormField.Size = new System.Drawing.Size(166, 22);
            this.mnuInsert_FormFields_ComboBoxFormField.Tag = "TXITEM_InsertComboBoxField";
            this.mnuInsert_FormFields_ComboBoxFormField.Text = "Combo &Box...";
            this.mnuInsert_FormFields_ComboBoxFormField.Click += new System.EventHandler(this.mnuInsert_FormFields_ComboBoxFormField_Click);
            // 
            // mnuInsert_FormFields_DropDownListFormField
            // 
            this.mnuInsert_FormFields_DropDownListFormField.Name = "mnuInsert_FormFields_DropDownListFormField";
            this.mnuInsert_FormFields_DropDownListFormField.Size = new System.Drawing.Size(166, 22);
            this.mnuInsert_FormFields_DropDownListFormField.Tag = "TXITEM_InsertDropDownListField";
            this.mnuInsert_FormFields_DropDownListFormField.Text = "&Drop-Down List...";
            this.mnuInsert_FormFields_DropDownListFormField.Click += new System.EventHandler(this.mnuInsert_FormFields_DropDownListFormField_Click);
            // 
            // mnuInsert_FormFields_DatePicker
            // 
            this.mnuInsert_FormFields_DatePicker.Name = "mnuInsert_FormFields_DatePicker";
            this.mnuInsert_FormFields_DatePicker.Size = new System.Drawing.Size(166, 22);
            this.mnuInsert_FormFields_DatePicker.Tag = "TXITEM_InsertDateFormField";
            this.mnuInsert_FormFields_DatePicker.Text = "Date Picker";
            this.mnuInsert_FormFields_DatePicker.Click += new System.EventHandler(this.mnuInsert_FormFields_DatePicker_Click);
            // 
            // mnuInsert_Symbol
            // 
            this.mnuInsert_Symbol.Name = "mnuInsert_Symbol";
            this.mnuInsert_Symbol.Size = new System.Drawing.Size(177, 22);
            this.mnuInsert_Symbol.Tag = "TXITEM_InsertSymbol";
            this.mnuInsert_Symbol.Text = "&Symbol…";
            this.mnuInsert_Symbol.Click += new System.EventHandler(this.mnuInsert_Symbol_Click);
            // 
            // toolStripSep_mnuInsert2
            // 
            this.toolStripSep_mnuInsert2.MergeIndex = 4;
            this.toolStripSep_mnuInsert2.Name = "toolStripSep_mnuInsert2";
            this.toolStripSep_mnuInsert2.Size = new System.Drawing.Size(174, 6);
            // 
            // mnuInsert_Hyperlink
            // 
            this.mnuInsert_Hyperlink.MergeIndex = 5;
            this.mnuInsert_Hyperlink.Name = "mnuInsert_Hyperlink";
            this.mnuInsert_Hyperlink.Size = new System.Drawing.Size(177, 22);
            this.mnuInsert_Hyperlink.Tag = "TXITEM_InsertHyperlink";
            this.mnuInsert_Hyperlink.Text = "&Hyperlink…";
            this.mnuInsert_Hyperlink.Click += new System.EventHandler(this.mnuInsert_Hyperlink_Click);
            // 
            // mnuInsert_Target
            // 
            this.mnuInsert_Target.MergeIndex = 6;
            this.mnuInsert_Target.Name = "mnuInsert_Target";
            this.mnuInsert_Target.Size = new System.Drawing.Size(177, 22);
            this.mnuInsert_Target.Tag = "TXITEM_InsertBookmark";
            this.mnuInsert_Target.Text = "&Bookmark…";
            this.mnuInsert_Target.Click += new System.EventHandler(this.mnuInsert_Target_Click);
            // 
            // toolStripSep_mnuInsert3
            // 
            this.toolStripSep_mnuInsert3.MergeIndex = 7;
            this.toolStripSep_mnuInsert3.Name = "toolStripSep_mnuInsert3";
            this.toolStripSep_mnuInsert3.Size = new System.Drawing.Size(174, 6);
            // 
            // mnuInsert_Break
            // 
            this.mnuInsert_Break.Name = "mnuInsert_Break";
            this.mnuInsert_Break.Size = new System.Drawing.Size(177, 22);
            this.mnuInsert_Break.Tag = "TXITEM_Breaks";
            this.mnuInsert_Break.Text = "Brea&k…";
            this.mnuInsert_Break.Click += new System.EventHandler(this.mnuBtnInserBreak_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(174, 6);
            // 
            // mnuInsert_EditableRegion
            // 
            this.mnuInsert_EditableRegion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInsert_EditableRegion_Add,
            this.mnuInsert_EditableRegion_Remove});
            this.mnuInsert_EditableRegion.Name = "mnuInsert_EditableRegion";
            this.mnuInsert_EditableRegion.Size = new System.Drawing.Size(177, 22);
            this.mnuInsert_EditableRegion.Text = "E&ditable Region";
            // 
            // mnuInsert_EditableRegion_Add
            // 
            this.mnuInsert_EditableRegion_Add.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInsert_EditableRegion_Add_User,
            this.mnuInsert_EditableRegion_Add_Everyone});
            this.mnuInsert_EditableRegion_Add.Name = "mnuInsert_EditableRegion_Add";
            this.mnuInsert_EditableRegion_Add.Size = new System.Drawing.Size(202, 22);
            this.mnuInsert_EditableRegion_Add.Text = "Add editable Region";
            // 
            // mnuInsert_EditableRegion_Add_User
            // 
            this.mnuInsert_EditableRegion_Add_User.Name = "mnuInsert_EditableRegion_Add_User";
            this.mnuInsert_EditableRegion_Add_User.Size = new System.Drawing.Size(174, 22);
            this.mnuInsert_EditableRegion_Add_User.Text = "For a certain User…";
            this.mnuInsert_EditableRegion_Add_User.Click += new System.EventHandler(this.mnuInsert_EditableRegion_Add_User_Click);
            // 
            // mnuInsert_EditableRegion_Add_Everyone
            // 
            this.mnuInsert_EditableRegion_Add_Everyone.Name = "mnuInsert_EditableRegion_Add_Everyone";
            this.mnuInsert_EditableRegion_Add_Everyone.Size = new System.Drawing.Size(174, 22);
            this.mnuInsert_EditableRegion_Add_Everyone.Text = "For Everyone";
            this.mnuInsert_EditableRegion_Add_Everyone.Click += new System.EventHandler(this.mnuInsert_EditableRegion_Add_Everyone_Click);
            // 
            // mnuInsert_EditableRegion_Remove
            // 
            this.mnuInsert_EditableRegion_Remove.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInsert_EditableRegion_Remove_User,
            this.mnuInsert_EditableRegion_Remove_Everyone});
            this.mnuInsert_EditableRegion_Remove.Name = "mnuInsert_EditableRegion_Remove";
            this.mnuInsert_EditableRegion_Remove.Size = new System.Drawing.Size(202, 22);
            this.mnuInsert_EditableRegion_Remove.Text = "Remove editable Region";
            // 
            // mnuInsert_EditableRegion_Remove_User
            // 
            this.mnuInsert_EditableRegion_Remove_User.Name = "mnuInsert_EditableRegion_Remove_User";
            this.mnuInsert_EditableRegion_Remove_User.Size = new System.Drawing.Size(174, 22);
            this.mnuInsert_EditableRegion_Remove_User.Text = "For a certain User…";
            this.mnuInsert_EditableRegion_Remove_User.Click += new System.EventHandler(this.mnuInsert_EditableRegion_Remove_User_Click);
            // 
            // mnuInsert_EditableRegion_Remove_Everyone
            // 
            this.mnuInsert_EditableRegion_Remove_Everyone.Name = "mnuInsert_EditableRegion_Remove_Everyone";
            this.mnuInsert_EditableRegion_Remove_Everyone.Size = new System.Drawing.Size(174, 22);
            this.mnuInsert_EditableRegion_Remove_Everyone.Text = "For Everyone";
            this.mnuInsert_EditableRegion_Remove_Everyone.Click += new System.EventHandler(this.mnuInsert_EditableRegion_Remove_Everyone_Click);
            // 
            // mnuFormat
            // 
            this.mnuFormat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFormat_Character,
            this.mnuFormat_Paragraph,
            this.mnuFormat_List,
            this.mnuFormat_Styles,
            this.toolStripMenuItem2,
            this.mnuFormat_HeadersAndFooters,
            this.mnuFormat_Columns,
            this.mnuFormat_PageBorders,
            this.mnuFormat_Tabs,
            this.toolStripSeparator5,
            this.mnuFormat_Image,
            this.mnuFormat_TextFrame,
            this.mnuFormat_ChartLayout,
            this.mnuFormat_Shape,
            this.toolStripSeparator13,
            this.mnuFormat_FormFields,
            this.toolStripSeparator4,
            this.mnuFormat_Language});
            this.mnuFormat.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mnuFormat.MergeIndex = 4;
            this.mnuFormat.Name = "mnuFormat";
            this.mnuFormat.Size = new System.Drawing.Size(57, 19);
            this.mnuFormat.Text = "For&mat";
            this.mnuFormat.DropDownOpening += new System.EventHandler(this.mnuFormat_DropDownOpening);
            // 
            // mnuFormat_Character
            // 
            this.mnuFormat_Character.MergeIndex = 0;
            this.mnuFormat_Character.Name = "mnuFormat_Character";
            this.mnuFormat_Character.Size = new System.Drawing.Size(196, 22);
            this.mnuFormat_Character.Tag = "TXITEM_CharacterFormatting";
            this.mnuFormat_Character.Text = "&Character…";
            this.mnuFormat_Character.Click += new System.EventHandler(this.mnuFormat_Character_Click);
            // 
            // mnuFormat_Paragraph
            // 
            this.mnuFormat_Paragraph.MergeIndex = 1;
            this.mnuFormat_Paragraph.Name = "mnuFormat_Paragraph";
            this.mnuFormat_Paragraph.Size = new System.Drawing.Size(196, 22);
            this.mnuFormat_Paragraph.Tag = "TXITEM_ParagraphFormatting";
            this.mnuFormat_Paragraph.Text = "&Paragraph…";
            this.mnuFormat_Paragraph.Click += new System.EventHandler(this.mnuFormat_Paragraph_Click);
            // 
            // mnuFormat_List
            // 
            this.mnuFormat_List.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFormat_List_Attributes,
            this.mnuFormat_List_IncreaseLevel,
            this.mnuFormat_List_DecreaseLevel,
            this.menuItem28,
            this.mnuFormat_List_ArabicNumbers,
            this.mnuFormat_List_CapitalLetters,
            this.mnuFormat_List_Letters,
            this.mnuFormat_List_RomanNumbers,
            this.mnuFormat_List_SmallRomanNumbers,
            this.mnuFormat_List_Bullets});
            this.mnuFormat_List.MergeIndex = 3;
            this.mnuFormat_List.Name = "mnuFormat_List";
            this.mnuFormat_List.Size = new System.Drawing.Size(196, 22);
            this.mnuFormat_List.Tag = "TXITEM_NumberedList";
            this.mnuFormat_List.Text = "Bullets and &Numbering";
            this.mnuFormat_List.DropDownOpening += new System.EventHandler(this.mnuFormat_List_DropDownOpening);
            // 
            // mnuFormat_List_Attributes
            // 
            this.mnuFormat_List_Attributes.MergeIndex = 0;
            this.mnuFormat_List_Attributes.Name = "mnuFormat_List_Attributes";
            this.mnuFormat_List_Attributes.Size = new System.Drawing.Size(151, 22);
            this.mnuFormat_List_Attributes.Tag = "TXITEM_NumberedList_Format ";
            this.mnuFormat_List_Attributes.Text = "&Properties…";
            this.mnuFormat_List_Attributes.Click += new System.EventHandler(this.mnuFormat_List_Attributes_Click);
            // 
            // mnuFormat_List_IncreaseLevel
            // 
            this.mnuFormat_List_IncreaseLevel.MergeIndex = 1;
            this.mnuFormat_List_IncreaseLevel.Name = "mnuFormat_List_IncreaseLevel";
            this.mnuFormat_List_IncreaseLevel.Size = new System.Drawing.Size(151, 22);
            this.mnuFormat_List_IncreaseLevel.Tag = "TXITEM_IncreaseIndent";
            this.mnuFormat_List_IncreaseLevel.Text = "&Increase Level";
            this.mnuFormat_List_IncreaseLevel.Click += new System.EventHandler(this.mnuFormat_List_IncreaseLevel_Click);
            // 
            // mnuFormat_List_DecreaseLevel
            // 
            this.mnuFormat_List_DecreaseLevel.MergeIndex = 2;
            this.mnuFormat_List_DecreaseLevel.Name = "mnuFormat_List_DecreaseLevel";
            this.mnuFormat_List_DecreaseLevel.Size = new System.Drawing.Size(151, 22);
            this.mnuFormat_List_DecreaseLevel.Tag = "TXITEM_DecreaseIndent";
            this.mnuFormat_List_DecreaseLevel.Text = "&Decrease Level";
            this.mnuFormat_List_DecreaseLevel.Click += new System.EventHandler(this.mnuFormat_List_DecreaseLevel_Click);
            // 
            // menuItem28
            // 
            this.menuItem28.MergeIndex = 3;
            this.menuItem28.Name = "menuItem28";
            this.menuItem28.Size = new System.Drawing.Size(148, 6);
            // 
            // mnuFormat_List_ArabicNumbers
            // 
            this.mnuFormat_List_ArabicNumbers.MergeIndex = 4;
            this.mnuFormat_List_ArabicNumbers.Name = "mnuFormat_List_ArabicNumbers";
            this.mnuFormat_List_ArabicNumbers.Size = new System.Drawing.Size(151, 22);
            this.mnuFormat_List_ArabicNumbers.Text = "&1, 2, 3";
            this.mnuFormat_List_ArabicNumbers.Click += new System.EventHandler(this.mnuFormat_List_ArabicNumbers_Click);
            // 
            // mnuFormat_List_CapitalLetters
            // 
            this.mnuFormat_List_CapitalLetters.MergeIndex = 5;
            this.mnuFormat_List_CapitalLetters.Name = "mnuFormat_List_CapitalLetters";
            this.mnuFormat_List_CapitalLetters.Size = new System.Drawing.Size(151, 22);
            this.mnuFormat_List_CapitalLetters.Text = "A, &B, C";
            this.mnuFormat_List_CapitalLetters.Click += new System.EventHandler(this.mnuFormat_List_CapitalLetters_Click);
            // 
            // mnuFormat_List_Letters
            // 
            this.mnuFormat_List_Letters.MergeIndex = 6;
            this.mnuFormat_List_Letters.Name = "mnuFormat_List_Letters";
            this.mnuFormat_List_Letters.Size = new System.Drawing.Size(151, 22);
            this.mnuFormat_List_Letters.Text = "a, b, &c";
            this.mnuFormat_List_Letters.Click += new System.EventHandler(this.mnuFormat_List_Letters_Click);
            // 
            // mnuFormat_List_RomanNumbers
            // 
            this.mnuFormat_List_RomanNumbers.MergeIndex = 7;
            this.mnuFormat_List_RomanNumbers.Name = "mnuFormat_List_RomanNumbers";
            this.mnuFormat_List_RomanNumbers.Size = new System.Drawing.Size(151, 22);
            this.mnuFormat_List_RomanNumbers.Text = "&I, II, III, IV";
            this.mnuFormat_List_RomanNumbers.Click += new System.EventHandler(this.mnuFormat_List_RomanNumbers_Click);
            // 
            // mnuFormat_List_SmallRomanNumbers
            // 
            this.mnuFormat_List_SmallRomanNumbers.MergeIndex = 8;
            this.mnuFormat_List_SmallRomanNumbers.Name = "mnuFormat_List_SmallRomanNumbers";
            this.mnuFormat_List_SmallRomanNumbers.Size = new System.Drawing.Size(151, 22);
            this.mnuFormat_List_SmallRomanNumbers.Text = "i, ii, iii, i&v";
            this.mnuFormat_List_SmallRomanNumbers.Click += new System.EventHandler(this.mnuFormat_List_SmallRomanNumbers_Click);
            // 
            // mnuFormat_List_Bullets
            // 
            this.mnuFormat_List_Bullets.MergeIndex = 9;
            this.mnuFormat_List_Bullets.Name = "mnuFormat_List_Bullets";
            this.mnuFormat_List_Bullets.Size = new System.Drawing.Size(151, 22);
            this.mnuFormat_List_Bullets.Tag = "TXITEM_BulletedList";
            this.mnuFormat_List_Bullets.Text = "B&ullets";
            this.mnuFormat_List_Bullets.Click += new System.EventHandler(this.mnuFormat_List_Bullets_Click);
            // 
            // mnuFormat_Styles
            // 
            this.mnuFormat_Styles.MergeIndex = 4;
            this.mnuFormat_Styles.Name = "mnuFormat_Styles";
            this.mnuFormat_Styles.Size = new System.Drawing.Size(196, 22);
            this.mnuFormat_Styles.Tag = "TXITEM_StyleName";
            this.mnuFormat_Styles.Text = "&Styles…";
            this.mnuFormat_Styles.Click += new System.EventHandler(this.mnuFormat_Styles_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(193, 6);
            // 
            // mnuFormat_HeadersAndFooters
            // 
            this.mnuFormat_HeadersAndFooters.Name = "mnuFormat_HeadersAndFooters";
            this.mnuFormat_HeadersAndFooters.Size = new System.Drawing.Size(196, 22);
            this.mnuFormat_HeadersAndFooters.Tag = "TXITEM_EditHeader";
            this.mnuFormat_HeadersAndFooters.Text = "&Headers and Footers…";
            this.mnuFormat_HeadersAndFooters.Click += new System.EventHandler(this.mnuFormat_HeadersFooters_Click);
            // 
            // mnuFormat_Columns
            // 
            this.mnuFormat_Columns.Name = "mnuFormat_Columns";
            this.mnuFormat_Columns.Size = new System.Drawing.Size(196, 22);
            this.mnuFormat_Columns.Tag = "TXITEM_Columns";
            this.mnuFormat_Columns.Text = "C&olumns…";
            this.mnuFormat_Columns.Click += new System.EventHandler(this.mnuFormat_Columns_Click);
            // 
            // mnuFormat_PageBorders
            // 
            this.mnuFormat_PageBorders.Name = "mnuFormat_PageBorders";
            this.mnuFormat_PageBorders.Size = new System.Drawing.Size(196, 22);
            this.mnuFormat_PageBorders.Tag = "TXITEM_PageBorders";
            this.mnuFormat_PageBorders.Text = "Page &Borders…";
            this.mnuFormat_PageBorders.Click += new System.EventHandler(this.mnuFormat_borders_Click);
            // 
            // mnuFormat_Tabs
            // 
            this.mnuFormat_Tabs.MergeIndex = 2;
            this.mnuFormat_Tabs.Name = "mnuFormat_Tabs";
            this.mnuFormat_Tabs.Size = new System.Drawing.Size(196, 22);
            this.mnuFormat_Tabs.Tag = "TXITEM_EditTabs";
            this.mnuFormat_Tabs.Text = "&Tabs…";
            this.mnuFormat_Tabs.Click += new System.EventHandler(this.mnuFormat_Tabs_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(193, 6);
            // 
            // mnuFormat_Image
            // 
            this.mnuFormat_Image.MergeIndex = 6;
            this.mnuFormat_Image.Name = "mnuFormat_Image";
            this.mnuFormat_Image.Size = new System.Drawing.Size(196, 22);
            this.mnuFormat_Image.Tag = "TXITEM_InsertImage";
            this.mnuFormat_Image.Text = "&Image…";
            this.mnuFormat_Image.Click += new System.EventHandler(this.mnuFormat_Image_Click);
            // 
            // mnuFormat_TextFrame
            // 
            this.mnuFormat_TextFrame.MergeIndex = 7;
            this.mnuFormat_TextFrame.Name = "mnuFormat_TextFrame";
            this.mnuFormat_TextFrame.Size = new System.Drawing.Size(196, 22);
            this.mnuFormat_TextFrame.Tag = "TXITEM_InsertTextFrame";
            this.mnuFormat_TextFrame.Text = "Te&xt Frame…";
            this.mnuFormat_TextFrame.Click += new System.EventHandler(this.mnuFormat_TextFrame_Click);
            // 
            // mnuFormat_ChartLayout
            // 
            this.mnuFormat_ChartLayout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFormat_ChartLayout_ChartTitle,
            this.mnuFormat_ChartLayout_AxisTitles,
            this.mnuFormat_ChartLayout_Legend,
            this.mnuFormat_ChartLayout_DataLabels,
            this.toolStripSep_menu_chartLayout,
            this.mnuFormat_ChartLayout_Axes,
            this.mnuFormat_ChartLayout_HorGridLines,
            this.mnuFormat_ChartLayout_VertGridLines});
            this.mnuFormat_ChartLayout.Enabled = false;
            this.mnuFormat_ChartLayout.Name = "mnuFormat_ChartLayout";
            this.mnuFormat_ChartLayout.Size = new System.Drawing.Size(196, 22);
            this.mnuFormat_ChartLayout.Tag = "TXITEM_InsertChart";
            this.mnuFormat_ChartLayout.Text = "Ch&art";
            // 
            // mnuFormat_ChartLayout_ChartTitle
            // 
            this.mnuFormat_ChartLayout_ChartTitle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFormat_ChartLayout_ChartTitle_None,
            this.mnuFormat_ChartLayout_ChartTitle_CenteredOverlay,
            this.mnuFormat_ChartLayout_ChartTitle_AboveChart});
            this.mnuFormat_ChartLayout_ChartTitle.Name = "mnuFormat_ChartLayout_ChartTitle";
            this.mnuFormat_ChartLayout_ChartTitle.Size = new System.Drawing.Size(178, 22);
            this.mnuFormat_ChartLayout_ChartTitle.Text = "Chart &Title";
            // 
            // mnuFormat_ChartLayout_ChartTitle_None
            // 
            this.mnuFormat_ChartLayout_ChartTitle_None.Name = "mnuFormat_ChartLayout_ChartTitle_None";
            this.mnuFormat_ChartLayout_ChartTitle_None.Size = new System.Drawing.Size(191, 22);
            this.mnuFormat_ChartLayout_ChartTitle_None.Text = "&None";
            this.mnuFormat_ChartLayout_ChartTitle_None.Click += new System.EventHandler(this.mnuFormat_Chart_ChartTitle_None_Click);
            // 
            // mnuFormat_ChartLayout_ChartTitle_CenteredOverlay
            // 
            this.mnuFormat_ChartLayout_ChartTitle_CenteredOverlay.Name = "mnuFormat_ChartLayout_ChartTitle_CenteredOverlay";
            this.mnuFormat_ChartLayout_ChartTitle_CenteredOverlay.Size = new System.Drawing.Size(191, 22);
            this.mnuFormat_ChartLayout_ChartTitle_CenteredOverlay.Text = "&Centered Overlay Title";
            this.mnuFormat_ChartLayout_ChartTitle_CenteredOverlay.Click += new System.EventHandler(this.mnuFormat_Chart_ChartTitle_CenteredOverlay_Click);
            // 
            // mnuFormat_ChartLayout_ChartTitle_AboveChart
            // 
            this.mnuFormat_ChartLayout_ChartTitle_AboveChart.Name = "mnuFormat_ChartLayout_ChartTitle_AboveChart";
            this.mnuFormat_ChartLayout_ChartTitle_AboveChart.Size = new System.Drawing.Size(191, 22);
            this.mnuFormat_ChartLayout_ChartTitle_AboveChart.Text = "&Above Chart";
            this.mnuFormat_ChartLayout_ChartTitle_AboveChart.Click += new System.EventHandler(this.mnuFormat_Chart_ChartTitle_AboveChart_Click);
            // 
            // mnuFormat_ChartLayout_AxisTitles
            // 
            this.mnuFormat_ChartLayout_AxisTitles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFormat_ChartLayout_AxisTitles_None,
            this.mnuFormat_ChartLayout_AxisTitles_BelowChart,
            this.mnuFormat_ChartLayout_AxisTitles_Vertical});
            this.mnuFormat_ChartLayout_AxisTitles.Name = "mnuFormat_ChartLayout_AxisTitles";
            this.mnuFormat_ChartLayout_AxisTitles.Size = new System.Drawing.Size(178, 22);
            this.mnuFormat_ChartLayout_AxisTitles.Text = "&Axis Titles";
            // 
            // mnuFormat_ChartLayout_AxisTitles_None
            // 
            this.mnuFormat_ChartLayout_AxisTitles_None.Name = "mnuFormat_ChartLayout_AxisTitles_None";
            this.mnuFormat_ChartLayout_AxisTitles_None.Size = new System.Drawing.Size(164, 22);
            this.mnuFormat_ChartLayout_AxisTitles_None.Text = "&None";
            this.mnuFormat_ChartLayout_AxisTitles_None.Click += new System.EventHandler(this.mnuFormat_Chart_AxisTitles_None_Click);
            // 
            // mnuFormat_ChartLayout_AxisTitles_BelowChart
            // 
            this.mnuFormat_ChartLayout_AxisTitles_BelowChart.Name = "mnuFormat_ChartLayout_AxisTitles_BelowChart";
            this.mnuFormat_ChartLayout_AxisTitles_BelowChart.Size = new System.Drawing.Size(164, 22);
            this.mnuFormat_ChartLayout_AxisTitles_BelowChart.Text = "Title &below Chart";
            this.mnuFormat_ChartLayout_AxisTitles_BelowChart.Click += new System.EventHandler(this.mnuFormat_Chart_AxisTitles_BelowChart_Click);
            // 
            // mnuFormat_ChartLayout_AxisTitles_Vertical
            // 
            this.mnuFormat_ChartLayout_AxisTitles_Vertical.Name = "mnuFormat_ChartLayout_AxisTitles_Vertical";
            this.mnuFormat_ChartLayout_AxisTitles_Vertical.Size = new System.Drawing.Size(164, 22);
            this.mnuFormat_ChartLayout_AxisTitles_Vertical.Text = "&Vertical Title";
            this.mnuFormat_ChartLayout_AxisTitles_Vertical.Click += new System.EventHandler(this.mnuFormat_Chart_AxisTitles_Vertical_Click);
            // 
            // mnuFormat_ChartLayout_Legend
            // 
            this.mnuFormat_ChartLayout_Legend.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFormat_ChartLayout_Legend_None,
            this.mnuFormat_ChartLayout_Legend_Top,
            this.mnuFormat_ChartLayout_Legend_Right,
            this.mnuFormat_ChartLayout_Legend_Bottom,
            this.mnuFormat_ChartLayout_Legend_Left});
            this.mnuFormat_ChartLayout_Legend.Name = "mnuFormat_ChartLayout_Legend";
            this.mnuFormat_ChartLayout_Legend.Size = new System.Drawing.Size(178, 22);
            this.mnuFormat_ChartLayout_Legend.Text = "&Legend";
            // 
            // mnuFormat_ChartLayout_Legend_None
            // 
            this.mnuFormat_ChartLayout_Legend_None.Name = "mnuFormat_ChartLayout_Legend_None";
            this.mnuFormat_ChartLayout_Legend_None.Size = new System.Drawing.Size(201, 22);
            this.mnuFormat_ChartLayout_Legend_None.Text = "&None";
            this.mnuFormat_ChartLayout_Legend_None.Click += new System.EventHandler(this.mnuFormat_Chart_Legend_None_Click);
            // 
            // mnuFormat_ChartLayout_Legend_Top
            // 
            this.mnuFormat_ChartLayout_Legend_Top.Name = "mnuFormat_ChartLayout_Legend_Top";
            this.mnuFormat_ChartLayout_Legend_Top.Size = new System.Drawing.Size(201, 22);
            this.mnuFormat_ChartLayout_Legend_Top.Text = "Show Legend at &Top";
            this.mnuFormat_ChartLayout_Legend_Top.Click += new System.EventHandler(this.mnuFormat_Chart_Legend_Top_Click);
            // 
            // mnuFormat_ChartLayout_Legend_Right
            // 
            this.mnuFormat_ChartLayout_Legend_Right.Name = "mnuFormat_ChartLayout_Legend_Right";
            this.mnuFormat_ChartLayout_Legend_Right.Size = new System.Drawing.Size(201, 22);
            this.mnuFormat_ChartLayout_Legend_Right.Text = "Show Legend at &Right";
            this.mnuFormat_ChartLayout_Legend_Right.Click += new System.EventHandler(this.mnuFormat_Chart_Legend_Right_Click);
            // 
            // mnuFormat_ChartLayout_Legend_Bottom
            // 
            this.mnuFormat_ChartLayout_Legend_Bottom.Name = "mnuFormat_ChartLayout_Legend_Bottom";
            this.mnuFormat_ChartLayout_Legend_Bottom.Size = new System.Drawing.Size(201, 22);
            this.mnuFormat_ChartLayout_Legend_Bottom.Text = "Show Legend at &Bottom";
            this.mnuFormat_ChartLayout_Legend_Bottom.Click += new System.EventHandler(this.mnuFormat_Chart_Legend_Bottom_Click);
            // 
            // mnuFormat_ChartLayout_Legend_Left
            // 
            this.mnuFormat_ChartLayout_Legend_Left.Name = "mnuFormat_ChartLayout_Legend_Left";
            this.mnuFormat_ChartLayout_Legend_Left.Size = new System.Drawing.Size(201, 22);
            this.mnuFormat_ChartLayout_Legend_Left.Text = "Show Legend at &Left";
            this.mnuFormat_ChartLayout_Legend_Left.Click += new System.EventHandler(this.mnuFormat_Chart_Legend_Left_Click);
            // 
            // mnuFormat_ChartLayout_DataLabels
            // 
            this.mnuFormat_ChartLayout_DataLabels.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFormat_ChartLayout_DataLabels_None,
            this.mnuFormat_ChartLayout_DataLabels_OutsideEnd});
            this.mnuFormat_ChartLayout_DataLabels.Name = "mnuFormat_ChartLayout_DataLabels";
            this.mnuFormat_ChartLayout_DataLabels.Size = new System.Drawing.Size(178, 22);
            this.mnuFormat_ChartLayout_DataLabels.Text = "&Data Labels";
            // 
            // mnuFormat_ChartLayout_DataLabels_None
            // 
            this.mnuFormat_ChartLayout_DataLabels_None.Name = "mnuFormat_ChartLayout_DataLabels_None";
            this.mnuFormat_ChartLayout_DataLabels_None.Size = new System.Drawing.Size(138, 22);
            this.mnuFormat_ChartLayout_DataLabels_None.Text = "&None";
            this.mnuFormat_ChartLayout_DataLabels_None.Click += new System.EventHandler(this.mnuFormat_Chart_DataLabels_None_Click);
            // 
            // mnuFormat_ChartLayout_DataLabels_OutsideEnd
            // 
            this.mnuFormat_ChartLayout_DataLabels_OutsideEnd.Name = "mnuFormat_ChartLayout_DataLabels_OutsideEnd";
            this.mnuFormat_ChartLayout_DataLabels_OutsideEnd.Size = new System.Drawing.Size(138, 22);
            this.mnuFormat_ChartLayout_DataLabels_OutsideEnd.Text = "&Outside End";
            this.mnuFormat_ChartLayout_DataLabels_OutsideEnd.Click += new System.EventHandler(this.mnuFormat_Chart_DataLabels_OutsideEnd_Click);
            // 
            // toolStripSep_menu_chartLayout
            // 
            this.toolStripSep_menu_chartLayout.Name = "toolStripSep_menu_chartLayout";
            this.toolStripSep_menu_chartLayout.Size = new System.Drawing.Size(175, 6);
            // 
            // mnuFormat_ChartLayout_Axes
            // 
            this.mnuFormat_ChartLayout_Axes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFormat_ChartLayout_Axes_leftToRight,
            this.mnuFormat_ChartLayout_Axes_withoutLabeling});
            this.mnuFormat_ChartLayout_Axes.Name = "mnuFormat_ChartLayout_Axes";
            this.mnuFormat_ChartLayout_Axes.Size = new System.Drawing.Size(178, 22);
            this.mnuFormat_ChartLayout_Axes.Text = "A&xes";
            // 
            // mnuFormat_ChartLayout_Axes_leftToRight
            // 
            this.mnuFormat_ChartLayout_Axes_leftToRight.Name = "mnuFormat_ChartLayout_Axes_leftToRight";
            this.mnuFormat_ChartLayout_Axes_leftToRight.Size = new System.Drawing.Size(219, 22);
            this.mnuFormat_ChartLayout_Axes_leftToRight.Text = "&Show left to right Axis";
            this.mnuFormat_ChartLayout_Axes_leftToRight.Click += new System.EventHandler(this.mnuFormat_Chart_Axes_leftToRight_Click);
            // 
            // mnuFormat_ChartLayout_Axes_withoutLabeling
            // 
            this.mnuFormat_ChartLayout_Axes_withoutLabeling.Name = "mnuFormat_ChartLayout_Axes_withoutLabeling";
            this.mnuFormat_ChartLayout_Axes_withoutLabeling.Size = new System.Drawing.Size(219, 22);
            this.mnuFormat_ChartLayout_Axes_withoutLabeling.Text = "Show Axis &without Labeling";
            this.mnuFormat_ChartLayout_Axes_withoutLabeling.Click += new System.EventHandler(this.mnuFormat_Chart_Axes_withoutLabeling_Click);
            // 
            // mnuFormat_ChartLayout_HorGridLines
            // 
            this.mnuFormat_ChartLayout_HorGridLines.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFormat_ChartLayout_HorizGridlines_None,
            this.mnuFormat_ChartLayout_HorizGridlines_Major,
            this.mnuFormat_ChartLayout_HorizGridlines_Minor,
            this.mnuFormat_ChartLayout_HorizGridlines_MajAndMin});
            this.mnuFormat_ChartLayout_HorGridLines.Name = "mnuFormat_ChartLayout_HorGridLines";
            this.mnuFormat_ChartLayout_HorGridLines.Size = new System.Drawing.Size(178, 22);
            this.mnuFormat_ChartLayout_HorGridLines.Text = "&Horizontal Gridlines";
            // 
            // mnuFormat_ChartLayout_HorizGridlines_None
            // 
            this.mnuFormat_ChartLayout_HorizGridlines_None.Name = "mnuFormat_ChartLayout_HorizGridlines_None";
            this.mnuFormat_ChartLayout_HorizGridlines_None.Size = new System.Drawing.Size(202, 22);
            this.mnuFormat_ChartLayout_HorizGridlines_None.Text = "&None";
            this.mnuFormat_ChartLayout_HorizGridlines_None.Click += new System.EventHandler(this.mnuFormat_Chart_HorizGridlines_None_Click);
            // 
            // mnuFormat_ChartLayout_HorizGridlines_Major
            // 
            this.mnuFormat_ChartLayout_HorizGridlines_Major.Name = "mnuFormat_ChartLayout_HorizGridlines_Major";
            this.mnuFormat_ChartLayout_HorizGridlines_Major.Size = new System.Drawing.Size(202, 22);
            this.mnuFormat_ChartLayout_HorizGridlines_Major.Text = "&Major Gridlines";
            this.mnuFormat_ChartLayout_HorizGridlines_Major.Click += new System.EventHandler(this.mnuFormat_Chart_HorizGridlines_Major_Click);
            // 
            // mnuFormat_ChartLayout_HorizGridlines_Minor
            // 
            this.mnuFormat_ChartLayout_HorizGridlines_Minor.Name = "mnuFormat_ChartLayout_HorizGridlines_Minor";
            this.mnuFormat_ChartLayout_HorizGridlines_Minor.Size = new System.Drawing.Size(202, 22);
            this.mnuFormat_ChartLayout_HorizGridlines_Minor.Text = "Min&or Gridlines";
            this.mnuFormat_ChartLayout_HorizGridlines_Minor.Click += new System.EventHandler(this.mnuFormat_Chart_HorizGridlines_Minor_Click);
            // 
            // mnuFormat_ChartLayout_HorizGridlines_MajAndMin
            // 
            this.mnuFormat_ChartLayout_HorizGridlines_MajAndMin.Name = "mnuFormat_ChartLayout_HorizGridlines_MajAndMin";
            this.mnuFormat_ChartLayout_HorizGridlines_MajAndMin.Size = new System.Drawing.Size(202, 22);
            this.mnuFormat_ChartLayout_HorizGridlines_MajAndMin.Text = "Major && minor &Gridlines";
            this.mnuFormat_ChartLayout_HorizGridlines_MajAndMin.Click += new System.EventHandler(this.mnuFormat_Chart_HorizGridlines_MajAndMin_Click);
            // 
            // mnuFormat_ChartLayout_VertGridLines
            // 
            this.mnuFormat_ChartLayout_VertGridLines.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFormat_ChartLayout_VertGridlines_None,
            this.mnuFormat_ChartLayout_VertGridlines_Major,
            this.mnuFormat_ChartLayout_VertGridlines_Minor,
            this.mnuFormat_ChartLayout_VertGridlines_MajAndMin});
            this.mnuFormat_ChartLayout_VertGridLines.Name = "mnuFormat_ChartLayout_VertGridLines";
            this.mnuFormat_ChartLayout_VertGridLines.Size = new System.Drawing.Size(178, 22);
            this.mnuFormat_ChartLayout_VertGridLines.Text = "&Vertical Gridlines";
            // 
            // mnuFormat_ChartLayout_VertGridlines_None
            // 
            this.mnuFormat_ChartLayout_VertGridlines_None.Name = "mnuFormat_ChartLayout_VertGridlines_None";
            this.mnuFormat_ChartLayout_VertGridlines_None.Size = new System.Drawing.Size(202, 22);
            this.mnuFormat_ChartLayout_VertGridlines_None.Text = "&None";
            this.mnuFormat_ChartLayout_VertGridlines_None.Click += new System.EventHandler(this.mnuFormat_Chart_VertGridlines_None_Click);
            // 
            // mnuFormat_ChartLayout_VertGridlines_Major
            // 
            this.mnuFormat_ChartLayout_VertGridlines_Major.Name = "mnuFormat_ChartLayout_VertGridlines_Major";
            this.mnuFormat_ChartLayout_VertGridlines_Major.Size = new System.Drawing.Size(202, 22);
            this.mnuFormat_ChartLayout_VertGridlines_Major.Text = "&Major Gridlines";
            this.mnuFormat_ChartLayout_VertGridlines_Major.Click += new System.EventHandler(this.mnuFormat_Chart_VertGridlines_Major_Click);
            // 
            // mnuFormat_ChartLayout_VertGridlines_Minor
            // 
            this.mnuFormat_ChartLayout_VertGridlines_Minor.Name = "mnuFormat_ChartLayout_VertGridlines_Minor";
            this.mnuFormat_ChartLayout_VertGridlines_Minor.Size = new System.Drawing.Size(202, 22);
            this.mnuFormat_ChartLayout_VertGridlines_Minor.Text = "Min&or Gridlines";
            this.mnuFormat_ChartLayout_VertGridlines_Minor.Click += new System.EventHandler(this.mnuFormat_Chart_VertGridlines_Minor_Click);
            // 
            // mnuFormat_ChartLayout_VertGridlines_MajAndMin
            // 
            this.mnuFormat_ChartLayout_VertGridlines_MajAndMin.Name = "mnuFormat_ChartLayout_VertGridlines_MajAndMin";
            this.mnuFormat_ChartLayout_VertGridlines_MajAndMin.Size = new System.Drawing.Size(202, 22);
            this.mnuFormat_ChartLayout_VertGridlines_MajAndMin.Text = "Major && minor &Gridlines";
            this.mnuFormat_ChartLayout_VertGridlines_MajAndMin.Click += new System.EventHandler(this.mnuFormat_Chart_VertGridlines_MajAndMin_Click);
            // 
            // mnuFormat_Shape
            // 
            this.mnuFormat_Shape.Name = "mnuFormat_Shape";
            this.mnuFormat_Shape.Size = new System.Drawing.Size(196, 22);
            this.mnuFormat_Shape.Tag = "TXITEM_InsertShape";
            this.mnuFormat_Shape.Text = "Sha&pe…";
            this.mnuFormat_Shape.Click += new System.EventHandler(this.mnuFormat_Shape_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            this.toolStripSeparator13.Size = new System.Drawing.Size(193, 6);
            // 
            // mnuFormat_FormFields
            // 
            this.mnuFormat_FormFields.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFormat_FormFields_Properties,
            this.toolStripSeparator16,
            this.mnuFormat_FormFields_Delete,
            this.toolStripMenuItem5,
            this.mnuFormat_FormFields_IsFormFieldValidationEnabled,
            this.mnuFormat_FormFields_ConditionalInstructions});
            this.mnuFormat_FormFields.Name = "mnuFormat_FormFields";
            this.mnuFormat_FormFields.Size = new System.Drawing.Size(196, 22);
            this.mnuFormat_FormFields.Tag = "TXITEM_InsertFormFieldsGroup";
            this.mnuFormat_FormFields.Text = "F&orm Fields";
            this.mnuFormat_FormFields.DropDownOpening += new System.EventHandler(this.mnuFormat_FormFields_DropDownOpening);
            // 
            // mnuFormat_FormFields_Properties
            // 
            this.mnuFormat_FormFields_Properties.Name = "mnuFormat_FormFields_Properties";
            this.mnuFormat_FormFields_Properties.Size = new System.Drawing.Size(210, 22);
            this.mnuFormat_FormFields_Properties.Tag = "TXITEM_InsertFormFieldsGroup";
            this.mnuFormat_FormFields_Properties.Text = "&Properties...";
            this.mnuFormat_FormFields_Properties.Click += new System.EventHandler(this.mnuFormat_FormFields_Properties_Click);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            this.toolStripSeparator16.Size = new System.Drawing.Size(207, 6);
            // 
            // mnuFormat_FormFields_Delete
            // 
            this.mnuFormat_FormFields_Delete.Name = "mnuFormat_FormFields_Delete";
            this.mnuFormat_FormFields_Delete.Size = new System.Drawing.Size(210, 22);
            this.mnuFormat_FormFields_Delete.Tag = "TXITEM_DeleteFormField";
            this.mnuFormat_FormFields_Delete.Text = "Delete &Field";
            this.mnuFormat_FormFields_Delete.Click += new System.EventHandler(this.mnuFormat_FormFields_Delete_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(207, 6);
            // 
            // mnuFormat_FormFields_IsFormFieldValidationEnabled
            // 
            this.mnuFormat_FormFields_IsFormFieldValidationEnabled.Name = "mnuFormat_FormFields_IsFormFieldValidationEnabled";
            this.mnuFormat_FormFields_IsFormFieldValidationEnabled.Size = new System.Drawing.Size(210, 22);
            this.mnuFormat_FormFields_IsFormFieldValidationEnabled.Tag = "TXITEM_EnableFormValidation";
            this.mnuFormat_FormFields_IsFormFieldValidationEnabled.Text = "&Enable Form Validation";
            this.mnuFormat_FormFields_IsFormFieldValidationEnabled.Click += new System.EventHandler(this.mnuFormat_FormFields_IsFormFieldValidationEnabled_Click);
            // 
            // mnuFormat_FormFields_ConditionalInstructions
            // 
            this.mnuFormat_FormFields_ConditionalInstructions.Name = "mnuFormat_FormFields_ConditionalInstructions";
            this.mnuFormat_FormFields_ConditionalInstructions.Size = new System.Drawing.Size(210, 22);
            this.mnuFormat_FormFields_ConditionalInstructions.Tag = "TXITEM_ManageConditionalInstructions";
            this.mnuFormat_FormFields_ConditionalInstructions.Text = "&Conditional Instructions...";
            this.mnuFormat_FormFields_ConditionalInstructions.Click += new System.EventHandler(this.mnuFormat_FormFields_ConditionalInstructions_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(193, 6);
            // 
            // mnuFormat_Language
            // 
            this.mnuFormat_Language.Name = "mnuFormat_Language";
            this.mnuFormat_Language.Size = new System.Drawing.Size(196, 22);
            this.mnuFormat_Language.Tag = "TXITEM_SetLanguage";
            this.mnuFormat_Language.Text = "&Language…";
            this.mnuFormat_Language.Click += new System.EventHandler(this.mnuFormat_Language_Click);
            // 
            // mnuTable
            // 
            this.mnuTable.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTable_Insert,
            this.mnuTable_Delete,
            this.mnuTable_Select,
            this.toolStripSeparator12,
            this.mnuTable_Merge_Cells,
            this.mnuTable_Split_Cells,
            this.mnuTable_Split,
            this.toolStripSeparator8,
            this.mnuTable_Formulas,
            this.toolStripSep_mnuTable1,
            this.mnuTable_GridLines,
            this.toolStripSeparator9,
            this.mnuTable_Properties});
            this.mnuTable.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mnuTable.MergeIndex = 5;
            this.mnuTable.Name = "mnuTable";
            this.mnuTable.Size = new System.Drawing.Size(48, 19);
            this.mnuTable.Text = "T&able";
            this.mnuTable.DropDownOpening += new System.EventHandler(this.mnuTable_DropDownOpening);
            // 
            // mnuTable_Insert
            // 
            this.mnuTable_Insert.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTable_Insert_Table,
            this.menuItem21,
            this.mnuTable_Insert_ColumnToTheLeft,
            this.mnuTable_Insert_ColumnToTheRight,
            this.menuItem24,
            this.mnuTable_Insert_RowAbove,
            this.mnuTable_Insert_RowBelow});
            this.mnuTable_Insert.MergeIndex = 0;
            this.mnuTable_Insert.Name = "mnuTable_Insert";
            this.mnuTable_Insert.Size = new System.Drawing.Size(136, 22);
            this.mnuTable_Insert.Tag = "TXITEM_InsertTable";
            this.mnuTable_Insert.Text = "&Insert";
            this.mnuTable_Insert.DropDownOpening += new System.EventHandler(this.mnuTable_Insert_DropDownOpening);
            // 
            // mnuTable_Insert_Table
            // 
            this.mnuTable_Insert_Table.MergeIndex = 0;
            this.mnuTable_Insert_Table.Name = "mnuTable_Insert_Table";
            this.mnuTable_Insert_Table.Size = new System.Drawing.Size(188, 22);
            this.mnuTable_Insert_Table.Tag = "TXITEM_InsertTable";
            this.mnuTable_Insert_Table.Text = "&Table...";
            this.mnuTable_Insert_Table.Click += new System.EventHandler(this.mnuTable_Insert_Table_Click);
            // 
            // menuItem21
            // 
            this.menuItem21.MergeIndex = 1;
            this.menuItem21.Name = "menuItem21";
            this.menuItem21.Size = new System.Drawing.Size(185, 6);
            // 
            // mnuTable_Insert_ColumnToTheLeft
            // 
            this.mnuTable_Insert_ColumnToTheLeft.MergeIndex = 2;
            this.mnuTable_Insert_ColumnToTheLeft.Name = "mnuTable_Insert_ColumnToTheLeft";
            this.mnuTable_Insert_ColumnToTheLeft.Size = new System.Drawing.Size(188, 22);
            this.mnuTable_Insert_ColumnToTheLeft.Tag = "TXITEM_InsertTableColLeft";
            this.mnuTable_Insert_ColumnToTheLeft.Text = "Column To The &Left";
            this.mnuTable_Insert_ColumnToTheLeft.Click += new System.EventHandler(this.mnuTable_Insert_ColumnToTheLeft_Click);
            // 
            // mnuTable_Insert_ColumnToTheRight
            // 
            this.mnuTable_Insert_ColumnToTheRight.MergeIndex = 3;
            this.mnuTable_Insert_ColumnToTheRight.Name = "mnuTable_Insert_ColumnToTheRight";
            this.mnuTable_Insert_ColumnToTheRight.Size = new System.Drawing.Size(188, 22);
            this.mnuTable_Insert_ColumnToTheRight.Tag = "TXITEM_InsertTableColRight";
            this.mnuTable_Insert_ColumnToTheRight.Text = "Column To The &Right";
            this.mnuTable_Insert_ColumnToTheRight.Click += new System.EventHandler(this.mnuTable_Insert_ColumnToTheRight_Click);
            // 
            // menuItem24
            // 
            this.menuItem24.MergeIndex = 4;
            this.menuItem24.Name = "menuItem24";
            this.menuItem24.Size = new System.Drawing.Size(185, 6);
            // 
            // mnuTable_Insert_RowAbove
            // 
            this.mnuTable_Insert_RowAbove.MergeIndex = 5;
            this.mnuTable_Insert_RowAbove.Name = "mnuTable_Insert_RowAbove";
            this.mnuTable_Insert_RowAbove.Size = new System.Drawing.Size(188, 22);
            this.mnuTable_Insert_RowAbove.Tag = "TXITEM_InsertTableRowAbove";
            this.mnuTable_Insert_RowAbove.Text = "Row &Above";
            this.mnuTable_Insert_RowAbove.Click += new System.EventHandler(this.mnuTable_Insert_RowAbove_Click);
            // 
            // mnuTable_Insert_RowBelow
            // 
            this.mnuTable_Insert_RowBelow.MergeIndex = 6;
            this.mnuTable_Insert_RowBelow.Name = "mnuTable_Insert_RowBelow";
            this.mnuTable_Insert_RowBelow.Size = new System.Drawing.Size(188, 22);
            this.mnuTable_Insert_RowBelow.Tag = "TXITEM_InsertTableRowBelow";
            this.mnuTable_Insert_RowBelow.Text = "Row &Below";
            this.mnuTable_Insert_RowBelow.Click += new System.EventHandler(this.mnuTable_Insert_RowBelow_Click);
            // 
            // mnuTable_Delete
            // 
            this.mnuTable_Delete.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTable_Delete_Table,
            this.mnuTable_Delete_Column,
            this.mnuTable_Delete_Rows,
            this.mnuTable_Delete_Cells});
            this.mnuTable_Delete.MergeIndex = 1;
            this.mnuTable_Delete.Name = "mnuTable_Delete";
            this.mnuTable_Delete.Size = new System.Drawing.Size(136, 22);
            this.mnuTable_Delete.Tag = "TXITEM_DeleteTable";
            this.mnuTable_Delete.Text = "&Delete";
            this.mnuTable_Delete.DropDownOpening += new System.EventHandler(this.mnuTable_Delete_DropDownOpening);
            // 
            // mnuTable_Delete_Table
            // 
            this.mnuTable_Delete_Table.MergeIndex = 0;
            this.mnuTable_Delete_Table.Name = "mnuTable_Delete_Table";
            this.mnuTable_Delete_Table.Size = new System.Drawing.Size(117, 22);
            this.mnuTable_Delete_Table.Tag = "TXITEM_DeleteTable";
            this.mnuTable_Delete_Table.Text = "&Table";
            this.mnuTable_Delete_Table.Click += new System.EventHandler(this.mnuTable_Delete_Table_Click);
            // 
            // mnuTable_Delete_Column
            // 
            this.mnuTable_Delete_Column.MergeIndex = 1;
            this.mnuTable_Delete_Column.Name = "mnuTable_Delete_Column";
            this.mnuTable_Delete_Column.Size = new System.Drawing.Size(117, 22);
            this.mnuTable_Delete_Column.Tag = "TXITEM_DeleteTableCol";
            this.mnuTable_Delete_Column.Text = "&Column";
            this.mnuTable_Delete_Column.Click += new System.EventHandler(this.mnuTable_Delete_Column_Click);
            // 
            // mnuTable_Delete_Rows
            // 
            this.mnuTable_Delete_Rows.MergeIndex = 2;
            this.mnuTable_Delete_Rows.Name = "mnuTable_Delete_Rows";
            this.mnuTable_Delete_Rows.Size = new System.Drawing.Size(117, 22);
            this.mnuTable_Delete_Rows.Tag = "TXITEM_DeleteTableRow";
            this.mnuTable_Delete_Rows.Text = "&Rows";
            this.mnuTable_Delete_Rows.Click += new System.EventHandler(this.mnuTable_Delete_Rows_Click);
            // 
            // mnuTable_Delete_Cells
            // 
            this.mnuTable_Delete_Cells.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTable_Delete_Cells_shiftLeft,
            this.mnuTable_Delete_Cells_entireRow,
            this.mnuTable_Delete_Cells_entireColumn});
            this.mnuTable_Delete_Cells.Name = "mnuTable_Delete_Cells";
            this.mnuTable_Delete_Cells.Size = new System.Drawing.Size(117, 22);
            this.mnuTable_Delete_Cells.Tag = "TXITEM_DeleteTableCell";
            this.mnuTable_Delete_Cells.Text = "C&ells";
            // 
            // mnuTable_Delete_Cells_shiftLeft
            // 
            this.mnuTable_Delete_Cells_shiftLeft.Name = "mnuTable_Delete_Cells_shiftLeft";
            this.mnuTable_Delete_Cells_shiftLeft.Size = new System.Drawing.Size(186, 22);
            this.mnuTable_Delete_Cells_shiftLeft.Text = "Shift Cells &Left";
            this.mnuTable_Delete_Cells_shiftLeft.Click += new System.EventHandler(this.mnuTable_Delete_Cells_shiftLeft_Click);
            // 
            // mnuTable_Delete_Cells_entireRow
            // 
            this.mnuTable_Delete_Cells_entireRow.Name = "mnuTable_Delete_Cells_entireRow";
            this.mnuTable_Delete_Cells_entireRow.Size = new System.Drawing.Size(186, 22);
            this.mnuTable_Delete_Cells_entireRow.Text = "Delete Entire &Row";
            this.mnuTable_Delete_Cells_entireRow.Click += new System.EventHandler(this.mnuTable_Delete_Cells_entireRow_Click);
            // 
            // mnuTable_Delete_Cells_entireColumn
            // 
            this.mnuTable_Delete_Cells_entireColumn.Name = "mnuTable_Delete_Cells_entireColumn";
            this.mnuTable_Delete_Cells_entireColumn.Size = new System.Drawing.Size(186, 22);
            this.mnuTable_Delete_Cells_entireColumn.Text = "Delete Entire &Column";
            this.mnuTable_Delete_Cells_entireColumn.Click += new System.EventHandler(this.mnuTable_Delete_Cells_entireColumn_Click);
            // 
            // mnuTable_Select
            // 
            this.mnuTable_Select.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTable_Select_Table,
            this.mnuTable_Select_Row,
            this.mnuTable_Select_Column,
            this.mnuTable_Select_Cell});
            this.mnuTable_Select.MergeIndex = 3;
            this.mnuTable_Select.Name = "mnuTable_Select";
            this.mnuTable_Select.Size = new System.Drawing.Size(136, 22);
            this.mnuTable_Select.Tag = "TXITEM_SelectTableRow";
            this.mnuTable_Select.Text = "S&elect";
            this.mnuTable_Select.DropDownOpening += new System.EventHandler(this.mnuTable_Select_DropDownOpening);
            // 
            // mnuTable_Select_Table
            // 
            this.mnuTable_Select_Table.MergeIndex = 0;
            this.mnuTable_Select_Table.Name = "mnuTable_Select_Table";
            this.mnuTable_Select_Table.Size = new System.Drawing.Size(117, 22);
            this.mnuTable_Select_Table.Tag = "TXITEM_SelectTable";
            this.mnuTable_Select_Table.Text = "&Table";
            this.mnuTable_Select_Table.Click += new System.EventHandler(this.mnuTable_Select_Table_Click);
            // 
            // mnuTable_Select_Row
            // 
            this.mnuTable_Select_Row.MergeIndex = 1;
            this.mnuTable_Select_Row.Name = "mnuTable_Select_Row";
            this.mnuTable_Select_Row.Size = new System.Drawing.Size(117, 22);
            this.mnuTable_Select_Row.Tag = "TXITEM_SelectTableRow";
            this.mnuTable_Select_Row.Text = "&Row";
            this.mnuTable_Select_Row.Click += new System.EventHandler(this.mnuTable_Select_Row_Click);
            // 
            // mnuTable_Select_Column
            // 
            this.mnuTable_Select_Column.MergeIndex = 2;
            this.mnuTable_Select_Column.Name = "mnuTable_Select_Column";
            this.mnuTable_Select_Column.Size = new System.Drawing.Size(117, 22);
            this.mnuTable_Select_Column.Tag = "TXITEM_SelectTableCol";
            this.mnuTable_Select_Column.Text = "&Column";
            this.mnuTable_Select_Column.Click += new System.EventHandler(this.mnuTable_Select_Column_Click);
            // 
            // mnuTable_Select_Cell
            // 
            this.mnuTable_Select_Cell.MergeIndex = 3;
            this.mnuTable_Select_Cell.Name = "mnuTable_Select_Cell";
            this.mnuTable_Select_Cell.Size = new System.Drawing.Size(117, 22);
            this.mnuTable_Select_Cell.Tag = "TXITEM_SelectTableCell";
            this.mnuTable_Select_Cell.Text = "C&ell";
            this.mnuTable_Select_Cell.Click += new System.EventHandler(this.mnuTable_Select_Cell_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            this.toolStripSeparator12.Size = new System.Drawing.Size(133, 6);
            // 
            // mnuTable_Merge_Cells
            // 
            this.mnuTable_Merge_Cells.Name = "mnuTable_Merge_Cells";
            this.mnuTable_Merge_Cells.Size = new System.Drawing.Size(136, 22);
            this.mnuTable_Merge_Cells.Tag = "TXITEM_MergeTableCells";
            this.mnuTable_Merge_Cells.Text = "&Merge Cells";
            this.mnuTable_Merge_Cells.Click += new System.EventHandler(this.mnuTable_Merge_Cells_Click);
            // 
            // mnuTable_Split_Cells
            // 
            this.mnuTable_Split_Cells.Name = "mnuTable_Split_Cells";
            this.mnuTable_Split_Cells.Size = new System.Drawing.Size(136, 22);
            this.mnuTable_Split_Cells.Tag = "TXITEM_SplitTableCells";
            this.mnuTable_Split_Cells.Text = "&Split Cells";
            this.mnuTable_Split_Cells.Click += new System.EventHandler(this.mnuTable_Split_Cells_Click);
            // 
            // mnuTable_Split
            // 
            this.mnuTable_Split.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTable_Split_Above,
            this.mnuTable_Split_Below});
            this.mnuTable_Split.MergeIndex = 2;
            this.mnuTable_Split.Name = "mnuTable_Split";
            this.mnuTable_Split.Size = new System.Drawing.Size(136, 22);
            this.mnuTable_Split.Tag = "TXITEM_SplitTable";
            this.mnuTable_Split.Text = "S&plit Table";
            this.mnuTable_Split.DropDownOpening += new System.EventHandler(this.mnuTable_Split_DropDownOpening);
            // 
            // mnuTable_Split_Above
            // 
            this.mnuTable_Split_Above.MergeIndex = 0;
            this.mnuTable_Split_Above.Name = "mnuTable_Split_Above";
            this.mnuTable_Split_Above.Size = new System.Drawing.Size(108, 22);
            this.mnuTable_Split_Above.Tag = "TXITEM_SplitTableAbove";
            this.mnuTable_Split_Above.Text = "&Above";
            this.mnuTable_Split_Above.Click += new System.EventHandler(this.mnuTable_Split_Above_Click);
            // 
            // mnuTable_Split_Below
            // 
            this.mnuTable_Split_Below.MergeIndex = 1;
            this.mnuTable_Split_Below.Name = "mnuTable_Split_Below";
            this.mnuTable_Split_Below.Size = new System.Drawing.Size(108, 22);
            this.mnuTable_Split_Below.Tag = "TXITEM_SplitTableBelow";
            this.mnuTable_Split_Below.Text = "&Below";
            this.mnuTable_Split_Below.Click += new System.EventHandler(this.mnuTable_Split_Below_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(133, 6);
            // 
            // mnuTable_Formulas
            // 
            this.mnuTable_Formulas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTable_Formulas_A1Style,
            this.mnuTable_Formulas_R1C1Style,
            this.toolStripSeparator11,
            this.mnuTable_Formulas_EditFormula,
            this.toolStripSeparator10,
            this.mnuTable_Formulas_AutomaticCalculation});
            this.mnuTable_Formulas.Name = "mnuTable_Formulas";
            this.mnuTable_Formulas.Size = new System.Drawing.Size(136, 22);
            this.mnuTable_Formulas.Tag = "TXITEM_FormulaGroup";
            this.mnuTable_Formulas.Text = "Formulas";
            this.mnuTable_Formulas.DropDownOpening += new System.EventHandler(this.mnuTable_Formulas_DropDownOpening);
            // 
            // mnuTable_Formulas_A1Style
            // 
            this.mnuTable_Formulas_A1Style.Name = "mnuTable_Formulas_A1Style";
            this.mnuTable_Formulas_A1Style.Size = new System.Drawing.Size(193, 22);
            this.mnuTable_Formulas_A1Style.Tag = "TXITEM_EnableA1Style";
            this.mnuTable_Formulas_A1Style.Text = "A1 Reference Style";
            this.mnuTable_Formulas_A1Style.Click += new System.EventHandler(this.mnuTable_Formulas_A1Style_Click);
            // 
            // mnuTable_Formulas_R1C1Style
            // 
            this.mnuTable_Formulas_R1C1Style.Name = "mnuTable_Formulas_R1C1Style";
            this.mnuTable_Formulas_R1C1Style.Size = new System.Drawing.Size(193, 22);
            this.mnuTable_Formulas_R1C1Style.Tag = "TXITEM_EnableR1C1Style";
            this.mnuTable_Formulas_R1C1Style.Text = "R1C1 ReferenceStyle";
            this.mnuTable_Formulas_R1C1Style.Click += new System.EventHandler(this.mnuTable_Formulas_R1C1Style_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(190, 6);
            // 
            // mnuTable_Formulas_EditFormula
            // 
            this.mnuTable_Formulas_EditFormula.Enabled = false;
            this.mnuTable_Formulas_EditFormula.Name = "mnuTable_Formulas_EditFormula";
            this.mnuTable_Formulas_EditFormula.Size = new System.Drawing.Size(193, 22);
            this.mnuTable_Formulas_EditFormula.Tag = "TXITEM_FormulaEditing";
            this.mnuTable_Formulas_EditFormula.Text = "Edit Formula...";
            this.mnuTable_Formulas_EditFormula.Click += new System.EventHandler(this.mnuTable_Formulas_EditFormula_Click);
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(190, 6);
            // 
            // mnuTable_Formulas_AutomaticCalculation
            // 
            this.mnuTable_Formulas_AutomaticCalculation.CheckOnClick = true;
            this.mnuTable_Formulas_AutomaticCalculation.Name = "mnuTable_Formulas_AutomaticCalculation";
            this.mnuTable_Formulas_AutomaticCalculation.Size = new System.Drawing.Size(193, 22);
            this.mnuTable_Formulas_AutomaticCalculation.Tag = "TXITEM_EnableFormulaCalculation";
            this.mnuTable_Formulas_AutomaticCalculation.Text = "Automatic Calculation";
            this.mnuTable_Formulas_AutomaticCalculation.Click += new System.EventHandler(this.mnuTable_Formulas_AutomaticCalculation_Click);
            // 
            // toolStripSep_mnuTable1
            // 
            this.toolStripSep_mnuTable1.Name = "toolStripSep_mnuTable1";
            this.toolStripSep_mnuTable1.Size = new System.Drawing.Size(133, 6);
            // 
            // mnuTable_GridLines
            // 
            this.mnuTable_GridLines.MergeIndex = 4;
            this.mnuTable_GridLines.Name = "mnuTable_GridLines";
            this.mnuTable_GridLines.Size = new System.Drawing.Size(136, 22);
            this.mnuTable_GridLines.Tag = "TXITEM_TableGridLines";
            this.mnuTable_GridLines.Text = "&Grid Lines";
            this.mnuTable_GridLines.Click += new System.EventHandler(this.mnuTable_GridLines_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(133, 6);
            // 
            // mnuTable_Properties
            // 
            this.mnuTable_Properties.MergeIndex = 5;
            this.mnuTable_Properties.Name = "mnuTable_Properties";
            this.mnuTable_Properties.Size = new System.Drawing.Size(136, 22);
            this.mnuTable_Properties.Tag = "TXITEM_TableProperties";
            this.mnuTable_Properties.Text = "&Properties…";
            this.mnuTable_Properties.Click += new System.EventHandler(this.mnuTable_Properties_Click);
            // 
            // mnuHelp
            // 
            this.mnuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelp_AboutTXTextControlWords});
            this.mnuHelp.MergeAction = System.Windows.Forms.MergeAction.Insert;
            this.mnuHelp.MergeIndex = 8;
            this.mnuHelp.Name = "mnuHelp";
            this.mnuHelp.Size = new System.Drawing.Size(44, 19);
            this.mnuHelp.Text = "&Help";
            // 
            // mnuHelp_AboutTXTextControlWords
            // 
            this.mnuHelp_AboutTXTextControlWords.MergeIndex = 0;
            this.mnuHelp_AboutTXTextControlWords.Name = "mnuHelp_AboutTXTextControlWords";
            this.mnuHelp_AboutTXTextControlWords.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.mnuHelp_AboutTXTextControlWords.Size = new System.Drawing.Size(257, 22);
            this.mnuHelp_AboutTXTextControlWords.Tag = "TXITEM_About";
            this.mnuHelp_AboutTXTextControlWords.Text = "&About TX Text Control Words…";
            this.mnuHelp_AboutTXTextControlWords.Click += new System.EventHandler(this.mnuHelp_AboutTXTextControlWords_Click);
            // 
            // mnuSeparatorEdit_Reviewing
            // 
            this.mnuSeparatorEdit_Reviewing.Name = "mnuSeparatorEdit_Reviewing";
            this.mnuSeparatorEdit_Reviewing.Size = new System.Drawing.Size(6, 6);
            // 
            // sep_pageNum01
            // 
            this.sep_pageNum01.Name = "sep_pageNum01";
            this.sep_pageNum01.Size = new System.Drawing.Size(185, 6);
            // 
            // MainWindow
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(962, 640);
            this.Controls.Add(this.m_statusBar);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(50, 50);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "TX Text Control Words .NET - [untitled]";
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private void LocalizeToolbar()
		{
			foreach (ToolStripMenuItem item in this.menuStrip.Items)
			{
				this.ActionOnBottomUp(item, delegate(ToolStripMenuItem x)
				{
					if (x.Name != "")
					{
						string name = x.Name.ToUpper() + "_TEXT";
						try
						{
							string @string = Resources.ResourceManager.GetString(name);
							if (@string != null)
							{
								x.Text = @string;
							}
						}
						catch
						{
						}
					}
				});
			}
		}

		private void UpdateToolbarImages()
		{
			foreach (ToolStripMenuItem item in this.menuStrip.Items)
			{
				this.ActionOnBottomUp(item, delegate(ToolStripMenuItem x)
				{
					x.UpdateImage(this.menuStrip.DeviceDpi);
				});
			}
		}

		private void ActionOnBottomUp(ToolStripMenuItem item, Action<ToolStripMenuItem> onSubItemAction)
		{
			foreach (object dropDownItem in item.DropDownItems)
			{
				if (dropDownItem.GetType() == typeof(ToolStripMenuItem))
				{
					ToolStripMenuItem item2 = (ToolStripMenuItem)dropDownItem;
					this.ActionOnBottomUp(item2, onSubItemAction);
				}
			}
			onSubItemAction(item);
		}

		private void UpdateToolbar_Format_List()
		{
			foreach (object dropDownItem in this.mnuFormat_List.DropDownItems)
			{
				ToolStripMenuItem toolStripMenuItem = dropDownItem as ToolStripMenuItem;
				if (toolStripMenuItem != null)
				{
					toolStripMenuItem.Checked = false;
				}
			}
			switch (this.textControl.Selection.ListFormat.Type)
			{
			case ListType.Bulleted:
				this.mnuFormat_List_Bullets.Checked = true;
				return;
			case ListType.None:
				return;
			}
			switch (this.textControl.Selection.ListFormat.NumberFormat)
			{
			case NumFormat.ArabicNumbers:
				this.mnuFormat_List_ArabicNumbers.Checked = true;
				break;
			case NumFormat.CapitalLetters:
				this.mnuFormat_List_CapitalLetters.Checked = true;
				break;
			case NumFormat.Letters:
				this.mnuFormat_List_Letters.Checked = true;
				break;
			case NumFormat.RomanNumbers:
				this.mnuFormat_List_RomanNumbers.Checked = true;
				break;
			case NumFormat.SmallRomanNumbers:
				this.mnuFormat_List_SmallRomanNumbers.Checked = true;
				break;
			}
		}

		private void UpdateToolbar_SetRecentItemsList(StringCollection recentItems)
		{
			this.mnuFile_RecentFiles.DropDownItems.Clear();
			StringEnumerator enumerator = this.m_fileHandler.RecentFiles.GetEnumerator();
			try
			{
				while (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					if (!File.Exists(current))
					{
						this.m_fileHandler.RecentFiles.Remove(current);
					}
				}
			}
			finally
			{
				(enumerator as IDisposable)?.Dispose();
			}
			StringEnumerator enumerator2 = recentItems.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					string current2 = enumerator2.Current;
					ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
					toolStripMenuItem.Text = Path.GetFileName(current2);
					toolStripMenuItem.Tag = current2;
					toolStripMenuItem.Click += delegate(object sender, EventArgs e)
					{
						ToolStripMenuItem toolStripMenuItem3 = sender as ToolStripMenuItem;
						this.m_fileHandler.OpenRecentFile((string)toolStripMenuItem3.Tag);
					};
					this.mnuFile_RecentFiles.DropDownItems.Add(toolStripMenuItem);
				}
			}
			finally
			{
				(enumerator2 as IDisposable)?.Dispose();
			}
			if (this.mnuFile_RecentFiles.DropDownItems.Count > 0)
			{
				this.mnuFile_RecentFiles.Enabled = true;
				this.mnuFile_RecentFiles.DropDownItems.Add(new ToolStripSeparator());
				ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
				toolStripMenuItem2.Text = Resources.MNUFILE_RECENTFILES_CLEAR_TEXT;
				toolStripMenuItem2.Click += delegate
				{
					while (this.m_fileHandler.RecentFiles.Count > 0)
					{
						this.m_fileHandler.RemoveRecentFile(this.m_fileHandler.RecentFiles[0]);
					}
				};
				this.mnuFile_RecentFiles.DropDownItems.Add(toolStripMenuItem2);
			}
			else
			{
				this.mnuFile_RecentFiles.Enabled = false;
			}
		}

		private void mnuFile_DropDownOpening(object sender, EventArgs e)
		{
			this.mnuFile_PageSetup.Enabled = this.textControl.CanEdit;
			this.mnuFile_Print.Enabled = this.textControl.CanPrint;
			this.mnuFile_PrintPreview.Enabled = this.textControl.CanPrint;
		}

		private void mnuFile_Open_Click(object sender, EventArgs e)
		{
			this.FileOpen();
		}

		private void mnuFile_New_Click(object sender, EventArgs e)
		{
			this.m_fileHandler.New();
		}

		private void mnuFile_Save_Click(object sender, EventArgs e)
		{
			this.m_fileHandler.Save();
		}

		private void mnuFile_SaveAs_Click(object sender, EventArgs e)
		{
			this.m_fileHandler.SaveAs();
		}

		private void mnuFile_PrintPreview_Click(object sender, EventArgs e)
		{
			this.PrintPreview();
		}

		private void mnuFile_Print_Click(object sender, EventArgs e)
		{
			this.Print();
		}

		private void mnuFile_Exit_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		private void mnuFile_Export_Click(object sender, EventArgs e)
		{
			try
			{
				this.textControl.Sections.GetItem();
				SaveSettings saveSettings = new SaveSettings
				{
					CssFileName = this.m_fileHandler.CssFileName,
					CssSaveMode = this.m_fileHandler.CssSaveMode,
					UserPassword = this.m_fileHandler.PDFUserPassword
				};
				if (this.m_fileHandler.PDFSignature != null)
				{
					saveSettings.DigitalSignature = this.m_fileHandler.PDFSignature;
				}
				SaveFileDialog saveFileDialog = new SaveFileDialog
				{
					Title = Resources.EXPORTDLG_TITLE,
					Filter = "Adobe PDF (*.pdf)|*.pdf|Adobe PDF/A (*.pdf)|*.pdf"
				};
				if (saveFileDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
				{
					switch (saveFileDialog.FilterIndex)
					{
					case 1:
						this.textControl.Save(saveFileDialog.FileName, StreamType.AdobePDF);
						break;
					case 2:
						this.textControl.Save(saveFileDialog.FileName, StreamType.AdobePDFA);
						break;
					}
				}
			}
			catch (Exception ex)
			{
				TX_Text_Control_Words.Utils.MessageBox.Show(this, ex.Message, Resources.MSG_EXPORTDOCUMENT_TITLE);
			}
		}

		private void mnuFile_PageSetup_Click(object sender, EventArgs e)
		{
			PageSetup.ShowDialog(this.textControl, this.m_fileHandler);
		}

		private void mnuFile_UserAccess_Click(object sender, EventArgs e)
		{
			this.m_UAC.ShowUserAccessDialog(this);
		}

		private void mnuFile_UserManagement_Click(object sender, EventArgs e)
		{
			this.m_UAC.ShowUserAdminDialog(this);
		}

		private void mnuFile_Options_Click(object sender, EventArgs e)
		{
			OptionsDialog optionsDialog = new OptionsDialog(this.textControl, this.m_fileHandler)
			{
				RightToLeft = this.textControl.RightToLeft
			};
			optionsDialog.ShowDialog(this);
		}

		private void mnuEdit_DropDownOpening(object sender, EventArgs e)
		{
			this.mnuEdit_Undo.Enabled = this.textControl.CanUndo;
			this.mnuEdit_Redo.Enabled = this.textControl.CanRedo;
			this.mnuEdit_Cut.Enabled = this.textControl.CanCopy && this.textControl.CanEdit;
			this.mnuEdit_Copy.Enabled = this.textControl.CanCopy;
			this.mnuEdit_Paste.Enabled = this.textControl.CanPaste;
			this.mnuEdit_Replace.Enabled = this.textControl.CanEdit;
			this.mnuEdit_Undo.Text = Resources.MNUEDIT_UNDO_TEXT + " " + this.textControl.UndoActionName;
			this.mnuEdit_Redo.Text = Resources.MNUEDIT_REDO_TEXT + " " + this.textControl.RedoActionName;
			this.mnuEdit_Permissions.Enabled = this.textControl.CanEdit;
			this.mnuEdit_ProtectDocument.Checked = this.textControl.EditMode == EditMode.ReadAndSelect;
			if (this.textControl.CanEdit)
			{
				try
				{
					this.mnuEdit_Hyperlink.Enabled = this.textControl.HypertextLinks.GetItem() != null || this.textControl.DocumentLinks.GetItem() != null;
					this.mnuEdit_Target.Enabled = this.textControl.DocumentTargets.GetItem() != null;
					this.mnuEdit_TableOfContents.Enabled = this.textControl.TablesOfContents.GetItem() != null;
				}
				catch
				{
				}
			}
			else
			{
				this.mnuEdit_Hyperlink.Enabled = false;
				this.mnuEdit_Target.Enabled = false;
				this.mnuEdit_TableOfContents.Enabled = false;
			}
			this.mnuEdit_Reviewing.Enabled = this.textControl.CanEdit;
		}

		private void mnuEdit_Undo_Click(object sender, EventArgs e)
		{
			this.textControl.Undo();
		}

		private void mnuEdit_Redo_Click(object sender, EventArgs e)
		{
			this.textControl.Redo();
		}

		private void mnuEdit_Cut_Click(object sender, EventArgs e)
		{
			this.textControl.Cut();
		}

		private void mnuEdit_Copy_Click(object sender, EventArgs e)
		{
			this.textControl.Copy();
		}

		private void mnuEdit_Paste_Click(object sender, EventArgs e)
		{
			this.textControl.Paste();
		}

		private void mnuEdit_SelectAll_Click(object sender, EventArgs e)
		{
			this.textControl.SelectAll();
		}

		private void mnuEdit_Find_Click(object sender, EventArgs e)
		{
			this.textControl.Find();
		}

		private void mnuEdit_Replace_Click(object sender, EventArgs e)
		{
			this.textControl.Replace();
		}

		private void mnuEdit_Hyperlink_Click(object sender, EventArgs e)
		{
			HyperlinkDialog hyperlinkDialog = new HyperlinkDialog(this.textControl);
			if (hyperlinkDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				this.m_fileHandler.IsDocumentDirty = true;
			}
		}

		private void mnuEdit_Target_Click(object sender, EventArgs e)
		{
			BookmarkDialog bookmarkDialog = new BookmarkDialog(this.textControl)
			{
				Owner = this,
				StartPosition = FormStartPosition.CenterParent
			};
			if (bookmarkDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.m_fileHandler.IsDocumentDirty = true;
			}
		}

		private void mnuEdit_TableOfContents_Edit_Click(object sender, EventArgs e)
		{
			this.textControl.TableOfContentsDialog();
		}

		private void mnuEdit_TableOfContents_Delete_Click(object sender, EventArgs e)
		{
			TableOfContents item = this.textControl.TablesOfContents.GetItem();
			if (item != null)
			{
				this.textControl.TablesOfContents.Remove(item);
			}
		}

		private void mnuEdit_TableOfContents_Update_Click(object sender, EventArgs e)
		{
			this.textControl.TablesOfContents.GetItem()?.Update();
		}

		private void mnuEdit_ProtectDocument_Click(object sender, EventArgs e)
		{
			if (this.mnuEdit_ProtectDocument.Checked)
			{
				this.textControl.EditMode = EditMode.Edit;
			}
			else
			{
				this.textControl.EditMode = (EditMode)2050;
			}
		}

		private void mnuEdit_Permissions_DropDownOpening(object sender, EventArgs e)
		{
			this.mnuEdit_Permissions_AllowCopy.Checked = this.textControl.DocumentPermissions.AllowCopy;
			this.mnuEdit_Permissions_AllowFormatting.Checked = this.textControl.DocumentPermissions.AllowFormatting;
			this.mnuEdit_Permissions_AllowFormattingStyles.Checked = this.textControl.DocumentPermissions.AllowFormattingStyles;
			this.mnuEdit_Permissions_AllowPrinting.Checked = this.textControl.DocumentPermissions.AllowPrinting;
			this.mnuEdit_Permissions_ReadOnly.Checked = this.textControl.DocumentPermissions.ReadOnly;
			this.mnuEdit_Permissions_AllowEditingFormFields.Checked = this.textControl.DocumentPermissions.AllowEditingFormFields;
		}

		private void mnuEdit_Permissions_ReadOnly_Click(object sender, EventArgs e)
		{
			this.textControl.DocumentPermissions.ReadOnly = !this.mnuEdit_Permissions_ReadOnly.Checked;
		}

		private void mnuEdit_Permissions_AllowCopy_Click(object sender, EventArgs e)
		{
			this.textControl.DocumentPermissions.AllowCopy = !this.mnuEdit_Permissions_AllowCopy.Checked;
		}

		private void mnuEdit_Permissions_AllowFormatting_Click(object sender, EventArgs e)
		{
			this.textControl.DocumentPermissions.AllowFormatting = !this.mnuEdit_Permissions_AllowFormatting.Checked;
		}

		private void mnuEdit_Permissions_AllowFormattingStyles_Click(object sender, EventArgs e)
		{
			this.textControl.DocumentPermissions.AllowFormattingStyles = !this.mnuEdit_Permissions_AllowFormattingStyles.Checked;
		}

		private void mnuEdit_Permissions_AllowPrinting_Click(object sender, EventArgs e)
		{
			this.textControl.DocumentPermissions.AllowPrinting = !this.mnuEdit_Permissions_AllowPrinting.Checked;
		}

		private void mnuEdit_Permissions_AllowEditingFormFields_Click(object sender, EventArgs e)
		{
			this.textControl.DocumentPermissions.AllowEditingFormFields = !this.textControl.DocumentPermissions.AllowEditingFormFields;
		}

		private void mnuEdit_Reviewing_DropDownOpening(object sender, EventArgs e)
		{
			try
			{
				this.mnuEdit_Reviewing_ReviewChanges.Enabled = this.textControl.TrackedChanges.Count > 0;
				this.mnuEdit_Reviewing_TrackChanges.Checked = this.textControl.IsTrackChangesEnabled;
			}
			catch (LicenseLevelException)
			{
			}
		}

		private void mnuEdit_Reviewing_TrackChanges_CheckedChanged(object sender, EventArgs e)
		{
			this.textControl.IsTrackChangesEnabled = ((ToolStripMenuItem)sender).Checked;
		}

		private void mnuEdit_Reviewing_ReviewChanges_Click(object sender, EventArgs e)
		{
			TrackedChangesDialog trackedChangesDialog = new TrackedChangesDialog(this.textControl.TrackedChanges, this.textControl.UserNames);
			trackedChangesDialog.RightToLeft = this.RightToLeft;
			trackedChangesDialog.ShowDialog(this);
		}

		private void mnuView_DropDownOpening(object sender, EventArgs e)
		{
			this.mnuView_Draft.Checked = this.textControl.ViewMode == ViewMode.Normal;
			this.mnuView_PageLayout.Checked = this.textControl.ViewMode == ViewMode.PageView;
			this.mnuView_Toolbar.Checked = this.toolStrip.Visible;
			this.mnuView_ButtonBar.Checked = this.m_buttonBar.Visible;
			this.mnuView_StatusBar.Checked = this.m_statusBar.Visible;
			this.mnuView_HorizontalRuler.Checked = this.m_horizontalRulerBar.Visible;
			this.mnuView_VerticalRuler.Checked = this.m_verticalRulerBar.Visible;
			this.mnuView_HeadersAndFooters.Enabled = this.textControl.ViewMode == ViewMode.PageView;
			this.mnuView_TextFrameMarkerLines.Checked = this.textControl.TextFrameMarkerLines;
			this.mnuView_DocumentTargetMarkers.Checked = this.textControl.DocumentTargetMarkers;
			this.mnuView_DrawingMarkerLines.Checked = this.textControl.DrawingMarkerLines;
			this.mnuView_FormLayout.Checked = this.IsFormLayoutRightToLeft();
		}

		private void mnuView_Draft_Click(object sender, EventArgs e)
		{
			this.textControl.ViewMode = ViewMode.Normal;
		}

		private void mnuView_PageLayout_Click(object sender, EventArgs e)
		{
			this.textControl.ViewMode = ViewMode.PageView;
		}

		private void mnuView_Toolbar_Click(object sender, EventArgs e)
		{
			this.toolStrip.Visible = !this.toolStrip.Visible;
		}

		private void mnuView_ButtonBar_Click(object sender, EventArgs e)
		{
			this.m_buttonBar.Visible = !this.m_buttonBar.Visible;
		}

		private void mnuView_StatusBar_Click(object sender, EventArgs e)
		{
			this.m_statusBar.Visible = !this.m_statusBar.Visible;
		}

		private void mnuView_HorizontalRuler_Click(object sender, EventArgs e)
		{
			this.m_horizontalRulerBar.Visible = !this.m_horizontalRulerBar.Visible;
		}

		private void mnuView_VerticalRuler_Click(object sender, EventArgs e)
		{
			this.m_verticalRulerBar.Visible = !this.m_verticalRulerBar.Visible;
		}

		private void mnuView_Zoom_DropDownOpening(object sender, EventArgs e)
		{
			this.mnuView_Zoom_25.Checked = this.textControl.ZoomFactor == 25;
			this.mnuView_Zoom_50.Checked = this.textControl.ZoomFactor == 50;
			this.mnuView_Zoom_75.Checked = this.textControl.ZoomFactor == 75;
			this.mnuView_Zoom_100.Checked = this.textControl.ZoomFactor == 100;
			this.mnuView_Zoom_150.Checked = this.textControl.ZoomFactor == 150;
			this.mnuView_Zoom_200.Checked = this.textControl.ZoomFactor == 200;
			this.mnuView_Zoom_300.Checked = this.textControl.ZoomFactor == 300;
		}

		private void mnuView_Zoom_25_Click(object sender, EventArgs e)
		{
			this.textControl.ZoomFactor = 25;
		}

		private void mnuView_Zoom_50_Click(object sender, EventArgs e)
		{
			this.textControl.ZoomFactor = 50;
		}

		private void mnuView_Zoom_75_Click(object sender, EventArgs e)
		{
			this.textControl.ZoomFactor = 75;
		}

		private void mnuView_Zoom_100_Click(object sender, EventArgs e)
		{
			this.textControl.ZoomFactor = 100;
		}

		private void mnuView_Zoom_150_Click(object sender, EventArgs e)
		{
			this.textControl.ZoomFactor = 150;
		}

		private void mnuView_Zoom_200_Click(object sender, EventArgs e)
		{
			this.textControl.ZoomFactor = 200;
		}

		private void mnuView_Zoom_300_Click(object sender, EventArgs e)
		{
			this.textControl.ZoomFactor = 300;
		}

		private void mnuView_Zoom_400_Click(object sender, EventArgs e)
		{
			this.textControl.ZoomFactor = 400;
		}

		private void mnuView_FormLayout_Click(object sender, EventArgs e)
		{
			if (!(sender as ToolStripMenuItem).Checked)
			{
				Settings.Default.RightToLeft = RightToLeft.Yes;
			}
			else
			{
				Settings.Default.RightToLeft = RightToLeft.No;
			}
			Settings.Default.Save();
			System.Windows.Forms.DialogResult dialogResult = TX_Text_Control_Words.Utils.MessageBox.Show(this, Resources.MSG_FORMLAYOUTCHANGED_TEXT, Resources.MSG_FORMLAYOUTCHANGED_TITLE, MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Asterisk);
			if (dialogResult == System.Windows.Forms.DialogResult.Yes)
			{
				Application.Restart();
			}
		}

		private void mnuView_HeadersAndFooters_Click(object sender, EventArgs e)
		{
			try
			{
				Section item = this.textControl.Sections.GetItem();
				HeaderFooter headerFooter = null;
				if (item.HeadersAndFooters.GetItem(HeaderFooterType.FirstPageHeader) != null)
				{
					headerFooter = item.HeadersAndFooters.GetItem(HeaderFooterType.FirstPageHeader);
				}
				else if (item.HeadersAndFooters.GetItem(HeaderFooterType.Header) != null)
				{
					headerFooter = item.HeadersAndFooters.GetItem(HeaderFooterType.Header);
				}
				else
				{
					item.HeadersAndFooters.Add(HeaderFooterType.Header);
					this.textControl.HeaderFooterActivationStyle = HeaderFooterActivationStyle.ActivateClick;
					headerFooter = item.HeadersAndFooters.GetItem(HeaderFooterType.Header);
				}
				headerFooter.Activate();
			}
			catch (Exception ex)
			{
				TX_Text_Control_Words.Utils.MessageBox.Show(this, ex.Message, base.ProductName);
			}
		}

		private void mnuView_TextFrameMarkerLines_Click(object sender, EventArgs e)
		{
			this.textControl.TextFrameMarkerLines = !this.textControl.TextFrameMarkerLines;
		}

		private void mnuView_DrawingMarkerLines_Click(object sender, EventArgs e)
		{
			this.textControl.DrawingMarkerLines = !this.textControl.DrawingMarkerLines;
		}

		private void mnuView_DocumentTargetMarkers_Click(object sender, EventArgs e)
		{
			this.textControl.DocumentTargetMarkers = !this.textControl.DocumentTargetMarkers;
		}

		private void mnuInsert_DropDownOpening(object sender, EventArgs e)
		{
			try
			{
				bool flag = this.textControl.TextParts.GetItem() is HeaderFooter;
				this.mnuInsert_pageNum.Enabled = this.textControl.CanEdit && flag;
				this.mnuInsert_PageNum_Insert.Enabled = flag;
			}
			catch (LicenseLevelException)
			{
			}
			ToolStripMenuItem toolStripMenuItem = this.mnuInsert_File;
			ToolStripMenuItem toolStripMenuItem2 = this.mnuInsert_Shapes;
			ToolStripMenuItem toolStripMenuItem3 = this.mnuInsert_Image;
			ToolStripMenuItem toolStripMenuItem4 = this.mnuInsert_TextFrame;
			ToolStripMenuItem toolStripMenuItem5 = this.mnuInsert_Chart;
			ToolStripMenuItem toolStripMenuItem6 = this.mnuInsert_Fields;
			ToolStripMenuItem toolStripMenuItem7 = this.mnuInsert_Symbol;
			bool flag2 = (this.mnuInsert_EditableRegion.Enabled = this.textControl.CanEdit);
			bool flag4 = (toolStripMenuItem7.Enabled = flag2);
			bool flag6 = (toolStripMenuItem6.Enabled = flag4);
			bool flag8 = (toolStripMenuItem5.Enabled = flag6);
			bool flag10 = (toolStripMenuItem4.Enabled = flag8);
			bool flag12 = (toolStripMenuItem3.Enabled = flag10);
			bool enabled = (toolStripMenuItem2.Enabled = flag12);
			toolStripMenuItem.Enabled = enabled;
			this.mnuInsert_Break.Enabled = this.textControl.CanEdit || this.textControl.CanDocumentFormat;
			this.mnuInsert_FormFields.Enabled = this.textControl.CanEdit;
			if (this.textControl.CanEdit)
			{
				try
				{
					this.mnuInsert_Hyperlink.Enabled = this.textControl.HypertextLinks.CanAdd;
					this.mnuInsert_Target.Enabled = this.textControl.DocumentTargets.CanAdd;
					this.mnuInsert_TableOfContents.Enabled = this.textControl.TablesOfContents.GetItem() == null;
					EditableRegion[] items = this.textControl.EditableRegions.GetItems();
					this.mnuInsert_EditableRegion_Remove.Enabled = items != null && items.Length != 0;
					if (this.mnuInsert_EditableRegion_Remove.Enabled)
					{
						this.mnuInsert_EditableRegion_Remove_Everyone.Enabled = items.Any((EditableRegion r) => string.IsNullOrEmpty(r.UserName));
					}
				}
				catch
				{
				}
			}
			else
			{
				this.mnuInsert_Hyperlink.Enabled = false;
				this.mnuInsert_Target.Enabled = false;
				this.mnuInsert_TableOfContents.Enabled = false;
			}
		}

		private void mnuInsert_File_Click(object sender, EventArgs e)
		{
			try
			{
				this.m_fileHandler.Insert();
			}
			catch (Exception ex)
			{
				TX_Text_Control_Words.Utils.MessageBox.Show(this, ex.Message, base.ProductName);
			}
		}

		private void mnuInsert_Image_Click(object sender, EventArgs e)
		{
			TXTextControl.Image image = new TXTextControl.Image();
			try
			{
				this.textControl.Images.Add(image, TXTextControl.HorizontalAlignment.Left, -1, ImageInsertionMode.DisplaceText);
			}
			catch (Exception ex)
			{
				TX_Text_Control_Words.Utils.MessageBox.Show(this, ex.Message, base.ProductName);
			}
		}

		private void mnuInsert_TableOfContents_Click(object sender, EventArgs e)
		{
			this.textControl.TableOfContentsDialog();
		}

		private void mnuInsert_PageNum_Delete_Click(object sender, EventArgs e)
		{
			this.RemovePageNumbers();
		}

		private void mnuInsert_Fields_deleteField_Click(object sender, EventArgs e)
		{
			this.DeleteField();
		}

		private void mnuInsert_Shapes_DrawingCanvas_Click(object sender, EventArgs e)
		{
			this.InsertDrawingCanvas();
		}

		private void mnuInsert_TextFrame_Click(object sender, EventArgs e)
		{
			try
			{
				this.textControl.TextFrames.GetItem();
				Size size = new Size(2268, 2268);
				TextFrame textFrame = new TextFrame(size);
				this.textControl.TextFrames.Add(textFrame, (TextFrameInsertionMode)65544);
			}
			catch (Exception ex)
			{
				TX_Text_Control_Words.Utils.MessageBox.Show(this, ex.Message, base.ProductName);
			}
		}

		private void mnuInsert_Symbol_Click(object sender, EventArgs e)
		{
			this.textControl.AddSymbolDialog();
		}

		private void mnuInsert_Hyperlink_Click(object sender, EventArgs e)
		{
			HyperlinkDialog hyperlinkDialog = new HyperlinkDialog(this.textControl);
			if (hyperlinkDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				this.m_fileHandler.IsDocumentDirty = true;
			}
		}

		private void mnuInsert_Target_Click(object sender, EventArgs e)
		{
			BookmarkDialog bookmarkDialog = new BookmarkDialog(this.textControl)
			{
				Owner = this,
				RightToLeftLayout = true
			};
			if (bookmarkDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.m_fileHandler.IsDocumentDirty = true;
			}
		}

		private void mnuInsert_Fields_DropDownOpening(object sender, EventArgs e)
		{
			switch (this.m_fldDispModeCur)
			{
			case FieldDisplayMode.ShowFieldText:
				this.mnuInsert_Fields_showFieldCodes.Checked = false;
				this.mnuInsert_Fields_showFieldText.Checked = true;
				break;
			case FieldDisplayMode.ShowFieldCodes:
				this.mnuInsert_Fields_showFieldCodes.Checked = true;
				this.mnuInsert_Fields_showFieldText.Checked = false;
				break;
			}
			this.mnuInsert_Fields_highlightMergeFields.Checked = this.m_bHighlightFields == HighlightMode.Activated;
			this.mnuInsert_Fields_deleteField.Enabled = this.FieldAtCurrentPos();
		}

		private void mnuInsert_Fields_insertMergeField_Click(object sender, EventArgs e)
		{
			this.InsertMergeField();
		}

		private void mnuInsert_Fields_insertSpecialField_IF_Click(object sender, EventArgs e)
		{
			this.InsertIfField();
		}

		private void mnuInsert_Fields_insertSpecialField_inclText_Click(object sender, EventArgs e)
		{
			this.InsertIncludeTextField();
		}

		private void mnuInsert_Fields_insertSpecialField_date_Click(object sender, EventArgs e)
		{
			this.InsertDateField();
		}

		private void mnuInsert_Fields_insertSpecialField_next_Click(object sender, EventArgs e)
		{
			this.InsertNextField();
		}

		private void mnuInsert_Fields_insertSpecialField_nextif_Click(object sender, EventArgs e)
		{
			this.InsertNextIfField();
		}

		private void mnuInsert_Fields_highlightMergeFields_Click(object sender, EventArgs e)
		{
			this.m_bHighlightFields = ((this.m_bHighlightFields == HighlightMode.Activated) ? HighlightMode.Never : HighlightMode.Activated);
			this.mnuInsert_Fields_highlightMergeFields.Checked = this.m_bHighlightFields == HighlightMode.Activated;
			this.SetDefaultFieldAndBlockProperties();
		}

		private void mnuInsert_Fields_showFieldCodes_Click(object sender, EventArgs e)
		{
			if (!this.mnuInsert_Fields_showFieldCodes.Checked)
			{
				this.m_fldDispModeCur = FieldDisplayMode.ShowFieldCodes;
				this.UpdateFieldValues();
			}
		}

		private void mnuInsert_Fields_showFieldText_Click(object sender, EventArgs e)
		{
			if (!this.mnuInsert_Fields_showFieldText.Checked)
			{
				this.m_fldDispModeCur = FieldDisplayMode.ShowFieldText;
				this.UpdateFieldValues();
			}
		}

		private void mnuInsert_FormFields_DropDownOpening(object sender, EventArgs e)
		{
			try
			{
				foreach (ToolStripMenuItem dropDownItem in this.mnuInsert_FormFields.DropDownItems)
				{
					dropDownItem.Enabled = this.textControl.FormFields.CanAdd;
				}
			}
			catch (LicenseLevelException)
			{
			}
		}

		private void mnuInsert_FormFields_TextFormField_Click(object sender, EventArgs e)
		{
			TextFormField formField = new TextFormField(this.GetFormFieldWidth());
			this.textControl.FormFields.Add(formField);
		}

		private void mnuInsert_FormFields_CheckFormField_Click(object sender, EventArgs e)
		{
			CheckFormField formField = new CheckFormField(isChecked: false);
			this.textControl.FormFields.Add(formField);
		}

		private void mnuInsert_FormFields_ComboBoxFormField_Click(object sender, EventArgs e)
		{
			SelectionFormField selectionFormField = new SelectionFormField(this.GetFormFieldWidth())
			{
				Editable = true,
				IsDropDownArrowVisible = true
			};
			SelectionFormFieldDialog selectionFormFieldDialog = new SelectionFormFieldDialog(selectionFormField)
			{
				Text = Resources.SELECTIONFORMFIELD_DLG_COMBOBOX_TITLE,
				RightToLeft = this.RightToLeft
			};
			if (selectionFormFieldDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				this.textControl.FormFields.Add(selectionFormField);
			}
		}

		private void mnuInsert_FormFields_DropDownListFormField_Click(object sender, EventArgs e)
		{
			SelectionFormField selectionFormField = new SelectionFormField(this.GetFormFieldWidth())
			{
				Editable = false,
				IsDropDownArrowVisible = true
			};
			SelectionFormFieldDialog selectionFormFieldDialog = new SelectionFormFieldDialog(selectionFormField)
			{
				Text = Resources.SELECTIONFORMFIELD_DLG_DROPDOWN_TITLE,
				RightToLeft = this.RightToLeft
			};
			if (selectionFormFieldDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				this.textControl.FormFields.Add(selectionFormField);
			}
		}

		private void mnuInsert_FormFields_DatePicker_Click(object sender, EventArgs e)
		{
			DateFormField formField = new DateFormField(this.GetFormFieldWidth())
			{
				IsDateControlVisible = true
			};
			this.textControl.FormFields.Add(formField);
		}

		private int GetFormFieldWidth()
		{
			int result = 1701;
			Table item = this.textControl.Tables.GetItem();
			if (this.textControl.Tables.GetItem() != null)
			{
				TableCell item2 = item.Cells.GetItem();
				if (item2 != null)
				{
					result = item2.Width;
				}
			}
			return result;
		}

		private void mnuInsert_PageNum_Click(object sender, EventArgs e)
		{
			this.InsertPageNumber();
		}

		private void mnuInsert_chart_pie3D_Click(object sender, EventArgs e)
		{
			this.TryInsertMSChart("Pie", is3D: true);
		}

		private void mnuInsert_chart_area_Click(object sender, EventArgs e)
		{
			this.TryInsertMSChart("Area", is3D: false);
		}

		private void mnuInsert_chart_bar_Click(object sender, EventArgs e)
		{
			this.TryInsertMSChart("Bar", is3D: false);
		}

		private void mnuInsert_chart_column_Click(object sender, EventArgs e)
		{
			this.TryInsertMSChart("Column", is3D: false);
		}

		private void mnuInsert_chart_pie_Click(object sender, EventArgs e)
		{
			this.TryInsertMSChart("Pie", is3D: false);
		}

		private void mnuInsert_chart_clusteredBar_Click(object sender, EventArgs e)
		{
			this.TryInsertMSChart("Bar", is3D: false);
		}

		private void mnuInsert_EditableRegion_Add_User_Click(object sender, EventArgs e)
		{
			if (this.textControl.Selection.Length == 0)
			{
				TX_Text_Control_Words.Utils.MessageBox.Show(this, Resources.MSG_SELECT_DOCUMENTPART, base.ProductName, MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
				return;
			}
			AddEditableRegionDialog addEditableRegionDialog = new AddEditableRegionDialog(this.m_UAC)
			{
				Owner = this,
				RightToLeft = this.RightToLeft
			};
			addEditableRegionDialog.ShowDialog(this);
		}

		private void mnuInsert_EditableRegion_Add_Everyone_Click(object sender, EventArgs e)
		{
			if (this.textControl.Selection.Length == 0)
			{
				TX_Text_Control_Words.Utils.MessageBox.Show(this, Resources.MSG_SELECT_DOCUMENTPART, base.ProductName, MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
			}
			else
			{
				this.textControl.EditableRegions.Add(new EditableRegion("", 0));
			}
		}

		private void mnuInsert_EditableRegion_Remove_User_Click(object sender, EventArgs e)
		{
			string strInput = "";
			if (!InputBoxDialog.ShowInputBox(Resources.INPUTBOXDLG_REMOVE_EDITABLEREGION_TITLE, ref strInput, this) || string.IsNullOrEmpty(strInput))
			{
				return;
			}
			try
			{
				EditableRegion editableRegion = this.textControl.EditableRegions.Remove(this.textControl.Selection.Length > 0, strInput);
				if (editableRegion == null)
				{
					TX_Text_Control_Words.Utils.MessageBox.Show(this, Resources.MSG_EDITABLEREGION_NA_FOR_USER, base.ProductName, MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation);
				}
			}
			catch (LicenseLevelException)
			{
				throw;
			}
		}

		private void mnuInsert_EditableRegion_Remove_Everyone_Click(object sender, EventArgs e)
		{
			this.textControl.EditableRegions.Remove(this.textControl.Selection.Length > 0);
		}

		private void mnuFormat_DropDownOpening(object sender, EventArgs e)
		{
			this.mnuFormat_Character.Enabled = this.textControl.CanCharacterFormat;
			this.mnuFormat_Paragraph.Enabled = this.textControl.CanParagraphFormat;
			this.mnuFormat_List.Enabled = this.textControl.CanParagraphFormat;
			this.mnuFormat_Styles.Enabled = this.textControl.CanStyleFormat;
			ToolStripMenuItem toolStripMenuItem = this.mnuFormat_HeadersAndFooters;
			ToolStripMenuItem toolStripMenuItem2 = this.mnuFormat_Columns;
			ToolStripMenuItem toolStripMenuItem3 = this.mnuFormat_PageBorders;
			bool flag = (this.mnuFormat_Tabs.Enabled = this.textControl.CanDocumentFormat);
			bool flag3 = (toolStripMenuItem3.Enabled = flag);
			bool enabled = (toolStripMenuItem2.Enabled = flag3);
			toolStripMenuItem.Enabled = enabled;
			this.mnuFormat_FormFields.Enabled = this.textControl.CanEdit;
			if (this.textControl.CanEdit)
			{
				this.mnuFormat_Image.Enabled = this.textControl.Images.GetItem() != null;
				this.mnuFormat_Language.Enabled = true;
				try
				{
					this.mnuFormat_TextFrame.Enabled = this.textControl.TextFrames.GetItem() != null;
				}
				catch
				{
					this.mnuFormat_TextFrame.Enabled = false;
				}
				try
				{
					this.mnuFormat_Shape.Enabled = this.textControl.Drawings.GetItem() != null;
				}
				catch
				{
					this.mnuFormat_Shape.Enabled = false;
				}
				try
				{
					this.mnuFormat_ChartLayout.Enabled = this.textControl.Charts.GetItem() != null;
				}
				catch
				{
					this.mnuFormat_ChartLayout.Enabled = false;
				}
			}
			else
			{
				this.mnuFormat_TextFrame.Enabled = false;
				this.mnuFormat_Shape.Enabled = false;
				this.mnuFormat_ChartLayout.Enabled = false;
				this.mnuFormat_Image.Enabled = false;
				this.mnuFormat_Language.Enabled = false;
			}
		}

		private void mnuFormat_Character_Click(object sender, EventArgs e)
		{
			if (this.textControl.FontDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.m_fileHandler.IsDocumentDirty = true;
			}
		}

		private void mnuFormat_Paragraph_Click(object sender, EventArgs e)
		{
			if (this.textControl.ParagraphFormatDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.m_fileHandler.IsDocumentDirty = true;
			}
		}

		private void mnuFormat_Tabs_Click(object sender, EventArgs e)
		{
			if (this.textControl.TabDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.m_fileHandler.IsDocumentDirty = true;
			}
		}

		private void mnuFormat_Styles_Click(object sender, EventArgs e)
		{
			if (this.textControl.FormattingStylesDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.m_fileHandler.IsDocumentDirty = true;
			}
		}

		private void mnuFormat_HeadersFooters_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.textControl.SectionFormatDialog(1) == System.Windows.Forms.DialogResult.OK)
				{
					this.m_fileHandler.IsDocumentDirty = true;
				}
			}
			catch (Exception ex)
			{
				TX_Text_Control_Words.Utils.MessageBox.Show(this, ex.Message, base.ProductName);
			}
		}

		private void mnuFormat_Image_Click(object sender, EventArgs e)
		{
			if (this.textControl.ImageAttributesDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.m_fileHandler.IsDocumentDirty = true;
			}
		}

		private void mnuFormat_List_DropDownOpening(object sender, EventArgs e)
		{
			this.mnuFormat_List_IncreaseLevel.Enabled = this.textControl.Selection.ListFormat.Type != ListType.None && this.textControl.Selection.ListFormat.Level < 10;
			this.mnuFormat_List_DecreaseLevel.Enabled = this.textControl.Selection.ListFormat.Type != ListType.None && this.textControl.Selection.ListFormat.Level > 1;
			this.UpdateToolbar_Format_List();
		}

		private void mnuFormat_List_Attributes_Click(object sender, EventArgs e)
		{
			if (this.textControl.ListFormatDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.m_fileHandler.IsDocumentDirty = true;
			}
		}

		private void mnuFormat_List_IncreaseLevel_Click(object sender, EventArgs e)
		{
			this.textControl.Selection.ListFormat.Level++;
			this.textControl.Selection.IncreaseIndent();
		}

		private void mnuFormat_List_DecreaseLevel_Click(object sender, EventArgs e)
		{
			if (this.textControl.Selection.ListFormat.Level >= 2)
			{
				this.textControl.Selection.ListFormat.Level--;
				this.textControl.Selection.DecreaseIndent();
			}
		}

		private void mnuFormat_List_ArabicNumbers_Click(object sender, EventArgs e)
		{
			if (this.mnuFormat_List_ArabicNumbers.Checked)
			{
				this.textControl.Selection.ListFormat.Type = ListType.None;
				this.textControl.Selection.ListFormat.NumberFormat = NumFormat.None;
			}
			else
			{
				this.textControl.Selection.ListFormat.Type = ListType.Numbered;
				this.textControl.Selection.ListFormat.NumberFormat = NumFormat.ArabicNumbers;
			}
		}

		private void mnuFormat_List_CapitalLetters_Click(object sender, EventArgs e)
		{
			if (this.mnuFormat_List_CapitalLetters.Checked)
			{
				this.textControl.Selection.ListFormat.Type = ListType.None;
				this.textControl.Selection.ListFormat.NumberFormat = NumFormat.None;
			}
			else
			{
				this.textControl.Selection.ListFormat.Type = ListType.Numbered;
				this.textControl.Selection.ListFormat.NumberFormat = NumFormat.CapitalLetters;
			}
		}

		private void mnuFormat_List_Letters_Click(object sender, EventArgs e)
		{
			if (this.mnuFormat_List_Letters.Checked)
			{
				this.textControl.Selection.ListFormat.Type = ListType.None;
				this.textControl.Selection.ListFormat.NumberFormat = NumFormat.None;
			}
			else
			{
				this.textControl.Selection.ListFormat.Type = ListType.Numbered;
				this.textControl.Selection.ListFormat.NumberFormat = NumFormat.Letters;
			}
		}

		private void mnuFormat_List_RomanNumbers_Click(object sender, EventArgs e)
		{
			if (this.mnuFormat_List_RomanNumbers.Checked)
			{
				this.textControl.Selection.ListFormat.Type = ListType.None;
				this.textControl.Selection.ListFormat.NumberFormat = NumFormat.None;
			}
			else
			{
				this.textControl.Selection.ListFormat.Type = ListType.Numbered;
				this.textControl.Selection.ListFormat.NumberFormat = NumFormat.RomanNumbers;
			}
		}

		private void mnuFormat_List_SmallRomanNumbers_Click(object sender, EventArgs e)
		{
			if (this.mnuFormat_List_SmallRomanNumbers.Checked)
			{
				this.textControl.Selection.ListFormat.Type = ListType.None;
				this.textControl.Selection.ListFormat.NumberFormat = NumFormat.None;
			}
			else
			{
				this.textControl.Selection.ListFormat.Type = ListType.Numbered;
				this.textControl.Selection.ListFormat.NumberFormat = NumFormat.SmallRomanNumbers;
			}
		}

		private void mnuFormat_List_Bullets_Click(object sender, EventArgs e)
		{
			if (this.mnuFormat_List_Bullets.Checked)
			{
				this.textControl.Selection.ListFormat.Type = ListType.None;
				this.textControl.Selection.ListFormat.NumberFormat = NumFormat.None;
			}
			else
			{
				this.textControl.Selection.ListFormat.Type = ListType.Bulleted;
			}
		}

		private void mnuFormat_borders_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.textControl.SectionFormatDialog(3) == System.Windows.Forms.DialogResult.OK)
				{
					this.m_fileHandler.IsDocumentDirty = true;
				}
			}
			catch (Exception ex)
			{
				TX_Text_Control_Words.Utils.MessageBox.Show(this, ex.Message, base.ProductName);
			}
		}

		private void mnuFormat_Columns_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.textControl.SectionFormatDialog(2) == System.Windows.Forms.DialogResult.OK)
				{
					this.m_fileHandler.IsDocumentDirty = true;
				}
			}
			catch (Exception ex)
			{
				TX_Text_Control_Words.Utils.MessageBox.Show(this, ex.Message, base.ProductName);
			}
		}

		private void mnuFormat_TextFrame_Click(object sender, EventArgs e)
		{
			try
			{
				if (this.textControl.TextFrameAttributesDialog() == System.Windows.Forms.DialogResult.OK)
				{
					this.m_fileHandler.IsDocumentDirty = true;
				}
			}
			catch
			{
			}
		}

		private void mnuFormat_Shape_Click(object sender, EventArgs e)
		{
			this.textControl.DrawingLayoutDialog();
		}

		private void mnuFormat_Language_Click(object sender, EventArgs e)
		{
			this.textControl.LanguageDialog();
		}

		private void mnuFormat_ChartLayout_DropDownOpening(object sender, EventArgs e)
		{
			this.mnuFormat_ChartLayout_Axes.Enabled = this.textControl.CanEdit;
			this.mnuFormat_ChartLayout_AxisTitles.Enabled = this.textControl.CanEdit;
			this.mnuFormat_ChartLayout_DataLabels.Enabled = this.textControl.CanEdit;
			this.mnuFormat_ChartLayout_HorGridLines.Enabled = this.textControl.CanEdit;
			this.mnuFormat_ChartLayout_Legend.Enabled = this.textControl.CanEdit;
			this.mnuFormat_ChartLayout_ChartTitle.Enabled = this.textControl.CanEdit;
			this.mnuFormat_ChartLayout_VertGridLines.Enabled = this.textControl.CanEdit;
		}

		private void mnuFormat_Chart_ChartTitle_None_Click(object sender, EventArgs e)
		{
			try
			{
				this.ClearChartTitles();
			}
			catch
			{
			}
		}

		private void mnuFormat_Chart_ChartTitle_CenteredOverlay_Click(object sender, EventArgs e)
		{
			try
			{
				this.SetChartTitleCenteredOverlay();
			}
			catch
			{
			}
		}

		private void mnuFormat_Chart_ChartTitle_AboveChart_Click(object sender, EventArgs e)
		{
			try
			{
				this.SetChartTitleAboveChart();
			}
			catch
			{
			}
		}

		private void mnuFormat_Chart_AxisTitles_None_Click(object sender, EventArgs e)
		{
			try
			{
				this.ClearChartAxisTitles();
			}
			catch
			{
			}
		}

		private void mnuFormat_Chart_AxisTitles_BelowChart_Click(object sender, EventArgs e)
		{
			try
			{
				this.SetAxisTitlesBelowChart();
			}
			catch
			{
			}
		}

		private void mnuFormat_Chart_AxisTitles_Vertical_Click(object sender, EventArgs e)
		{
			try
			{
				this.SetVerticalAxisTitle();
			}
			catch
			{
			}
		}

		private void mnuFormat_Chart_Legend_None_Click(object sender, EventArgs e)
		{
			try
			{
				this.DisableChartLegend();
			}
			catch
			{
			}
		}

		private void mnuFormat_Chart_Legend_Top_Click(object sender, EventArgs e)
		{
			try
			{
				this.SetChartLegendTop();
			}
			catch
			{
			}
		}

		private void mnuFormat_Chart_Legend_Right_Click(object sender, EventArgs e)
		{
			try
			{
				this.SetChartLegendRight();
			}
			catch
			{
			}
		}

		private void mnuFormat_Chart_Legend_Bottom_Click(object sender, EventArgs e)
		{
			try
			{
				this.SetChartLegendBottom();
			}
			catch
			{
			}
		}

		private void mnuFormat_Chart_Legend_Left_Click(object sender, EventArgs e)
		{
			try
			{
				this.SetChartLegendLeft();
			}
			catch
			{
			}
		}

		private void mnuFormat_Chart_DataLabels_None_Click(object sender, EventArgs e)
		{
			try
			{
				this.RemoveChartDataLabels();
			}
			catch
			{
			}
		}

		private void mnuFormat_Chart_DataLabels_OutsideEnd_Click(object sender, EventArgs e)
		{
			try
			{
				this.SetChartDataLabelsOutsideEnd();
			}
			catch
			{
			}
		}

		private void mnuFormat_Chart_Axes_leftToRight_Click(object sender, EventArgs e)
		{
			try
			{
				this.SetChartAxesLeftToRight();
			}
			catch
			{
			}
		}

		private void mnuFormat_Chart_Axes_withoutLabeling_Click(object sender, EventArgs e)
		{
			try
			{
				this.RemoveLabelsFromAxes();
			}
			catch
			{
			}
		}

		private void mnuFormat_Chart_HorizGridlines_None_Click(object sender, EventArgs e)
		{
			try
			{
				this.RemoveHorizChartGridLines();
			}
			catch
			{
			}
		}

		private void mnuFormat_Chart_HorizGridlines_Major_Click(object sender, EventArgs e)
		{
			try
			{
				this.SetMajorHorizChartGridLines();
			}
			catch
			{
			}
		}

		private void mnuFormat_Chart_HorizGridlines_Minor_Click(object sender, EventArgs e)
		{
			try
			{
				this.SetMinorHorizChartGridLines();
			}
			catch
			{
			}
		}

		private void mnuFormat_Chart_HorizGridlines_MajAndMin_Click(object sender, EventArgs e)
		{
			try
			{
				this.SetMajAndMinHorizChartGridLines();
			}
			catch
			{
			}
		}

		private void mnuFormat_Chart_VertGridlines_None_Click(object sender, EventArgs e)
		{
			try
			{
				this.RemoveChartGridLines();
			}
			catch
			{
			}
		}

		private void mnuFormat_Chart_VertGridlines_Major_Click(object sender, EventArgs e)
		{
			try
			{
				this.SetMajorVertChartGridLines();
			}
			catch
			{
			}
		}

		private void mnuFormat_Chart_VertGridlines_Minor_Click(object sender, EventArgs e)
		{
			try
			{
				this.SetMinorVertChartGridLines();
			}
			catch
			{
			}
		}

		private void mnuFormat_Chart_VertGridlines_MajAndMin_Click(object sender, EventArgs e)
		{
			try
			{
				this.SetMajAndMinVertChartGridLines();
			}
			catch
			{
			}
		}

		private void mnuFormat_FormFields_DropDownOpening(object sender, EventArgs e)
		{
			try
			{
				ToolStripMenuItem toolStripMenuItem = this.mnuFormat_FormFields_Delete;
				bool enabled = (this.mnuFormat_FormFields_Properties.Enabled = this.textControl.FormFields.GetItem() != null);
				toolStripMenuItem.Enabled = enabled;
				this.mnuFormat_FormFields_ConditionalInstructions.Enabled = this.textControl.IsFormFieldValidationEnabled;
				this.mnuFormat_FormFields_IsFormFieldValidationEnabled.Checked = this.textControl.IsFormFieldValidationEnabled;
			}
			catch (LicenseLevelException)
			{
			}
		}

		private void mnuFormat_FormFields_Properties_Click(object sender, EventArgs e)
		{
			FormField item = this.textControl.FormFields.GetItem();
			if (item != null)
			{
				Form form = null;
				if (item is SelectionFormField)
				{
					form = new SelectionFormFieldDialog((SelectionFormField)item);
				}
				else if (item is TextFormField)
				{
					form = new TextFormFieldDialog((TextFormField)item);
				}
				else if (item is CheckFormField)
				{
					form = new CheckFormFieldDialog((CheckFormField)item);
				}
				else if (item is DateFormField)
				{
					form = new DateFormFieldDialog((DateFormField)item);
				}
				if (form != null)
				{
					form.RightToLeft = this.RightToLeft;
					form.ShowDialog(this);
				}
			}
		}

		private void mnuFormat_FormFields_Delete_Click(object sender, EventArgs e)
		{
			FormField item = this.textControl.FormFields.GetItem();
			if (item != null)
			{
				this.textControl.FormFields.Remove(item);
			}
		}

		private void mnuFormat_FormFields_IsFormFieldValidationEnabled_Click(object sender, EventArgs e)
		{
			this.textControl.IsFormFieldValidationEnabled = !this.textControl.IsFormFieldValidationEnabled;
		}

		private void mnuFormat_FormFields_ConditionalInstructions_Click(object sender, EventArgs e)
		{
			this.textControl.ManageConditionalInstructionsDialog();
		}

		private void mnuTable_DropDownOpening(object sender, EventArgs e)
		{
			Table item = this.textControl.Tables.GetItem();
			this.mnuTable_GridLines.Checked = this.textControl.Tables.GridLines;
			this.mnuTable_Select.Enabled = item != null;
			this.mnuTable_Insert.Enabled = this.textControl.CanEdit;
			if (this.textControl.CanTableFormat)
			{
				if (item != null)
				{
					this.mnuTable_Properties.Enabled = true;
					this.mnuTable_Delete.Enabled = true;
					this.mnuTable_Split.Enabled = item.CanSplit;
					this.mnuTable_Merge_Cells.Enabled = item.CanMergeCells;
					this.mnuTable_Split_Cells.Enabled = item.CanSplitCells;
				}
				else
				{
					this.mnuTable_Properties.Enabled = false;
					this.mnuTable_Delete.Enabled = false;
					this.mnuTable_Split.Enabled = false;
					this.mnuTable_Merge_Cells.Enabled = false;
					this.mnuTable_Split_Cells.Enabled = false;
				}
			}
			else
			{
				this.mnuTable_Insert.Enabled = false;
				this.mnuTable_Delete.Enabled = false;
				this.mnuTable_Split.Enabled = false;
				this.mnuTable_Split_Cells.Enabled = false;
				this.mnuTable_Merge_Cells.Enabled = false;
				this.mnuTable_Properties.Enabled = false;
			}
		}

		private void mnuTable_Insert_DropDownOpening(object sender, EventArgs e)
		{
			this.mnuTable_Insert_Table.Enabled = this.textControl.Tables.CanAdd;
			Table item = this.textControl.Tables.GetItem();
			if (item == null)
			{
				this.mnuTable_Insert_ColumnToTheLeft.Enabled = false;
				this.mnuTable_Insert_ColumnToTheRight.Enabled = false;
				this.mnuTable_Insert_RowAbove.Enabled = false;
				this.mnuTable_Insert_RowBelow.Enabled = false;
			}
			else
			{
				this.mnuTable_Insert_ColumnToTheLeft.Enabled = item.Columns.CanAdd;
				this.mnuTable_Insert_ColumnToTheRight.Enabled = item.Columns.CanAdd;
				this.mnuTable_Insert_RowAbove.Enabled = item.Rows.CanAdd;
				this.mnuTable_Insert_RowBelow.Enabled = item.Rows.CanAdd;
			}
		}

		private void mnuTable_Insert_Table_Click(object sender, EventArgs e)
		{
			if (this.textControl.Tables.Add())
			{
				this.m_fileHandler.IsDocumentDirty = true;
			}
		}

		private void mnuTable_Insert_ColumnToTheLeft_Click(object sender, EventArgs e)
		{
			this.textControl.Tables.GetItem().Columns.Add(TableAddPosition.Before);
		}

		private void mnuTable_Insert_ColumnToTheRight_Click(object sender, EventArgs e)
		{
			this.textControl.Tables.GetItem().Columns.Add(TableAddPosition.After);
		}

		private void mnuTable_Insert_RowAbove_Click(object sender, EventArgs e)
		{
			this.textControl.Tables.GetItem().Rows.Add(TableAddPosition.Before, 1);
		}

		private void mnuTable_Insert_RowBelow_Click(object sender, EventArgs e)
		{
			this.textControl.Tables.GetItem().Rows.Add(TableAddPosition.After, 1);
		}

		private void mnuTable_Delete_DropDownOpening(object sender, EventArgs e)
		{
			Table item = this.textControl.Tables.GetItem();
			if (item == null)
			{
				this.mnuTable_Delete_Table.Enabled = false;
				this.mnuTable_Delete_Column.Enabled = false;
				this.mnuTable_Delete_Rows.Enabled = false;
				this.mnuTable_Delete_Cells.Enabled = false;
			}
			else
			{
				this.mnuTable_Delete_Table.Enabled = item.Columns.CanRemove;
				this.mnuTable_Delete_Column.Enabled = item.Columns.CanRemove;
				this.mnuTable_Delete_Rows.Enabled = item.Rows.CanRemove;
				this.mnuTable_Delete_Cells.Enabled = item.Cells.CanRemove;
				this.mnuTable_Delete_Cells_entireColumn.Enabled = item.Columns.CanRemove;
				this.mnuTable_Delete_Cells_entireRow.Enabled = item.Rows.CanRemove;
			}
		}

		private void mnuTable_Delete_Table_Click(object sender, EventArgs e)
		{
			this.textControl.Tables.Remove();
		}

		private void mnuTable_Delete_Column_Click(object sender, EventArgs e)
		{
			this.textControl.Tables.GetItem().Columns.Remove();
		}

		private void mnuTable_Delete_Rows_Click(object sender, EventArgs e)
		{
			this.textControl.Tables.GetItem().Rows.Remove();
		}

		private void mnuTable_Delete_Cells_shiftLeft_Click(object sender, EventArgs e)
		{
			this.textControl.Tables.GetItem().Cells.Remove();
		}

		private void mnuTable_Delete_Cells_entireRow_Click(object sender, EventArgs e)
		{
			this.textControl.Tables.GetItem().Rows.Remove();
		}

		private void mnuTable_Delete_Cells_entireColumn_Click(object sender, EventArgs e)
		{
			this.textControl.Tables.GetItem().Columns.Remove();
		}

		private void mnuTable_Merge_Cells_Click(object sender, EventArgs e)
		{
			this.textControl.Tables.GetItem().MergeCells();
		}

		private void mnuTable_Split_Cells_Click(object sender, EventArgs e)
		{
			this.textControl.Tables.GetItem().SplitCells();
		}

		private void mnuTable_Split_DropDownOpening(object sender, EventArgs e)
		{
			Table item = this.textControl.Tables.GetItem();
			if (item == null)
			{
				this.mnuTable_Split_Above.Enabled = false;
				this.mnuTable_Split_Below.Enabled = false;
			}
			else
			{
				this.mnuTable_Split_Above.Enabled = true;
				this.mnuTable_Split_Below.Enabled = true;
			}
		}

		private void mnuTable_Split_Above_Click(object sender, EventArgs e)
		{
			this.textControl.Tables.GetItem().Split(TableAddPosition.Before);
		}

		private void mnuTable_Split_Below_Click(object sender, EventArgs e)
		{
			this.textControl.Tables.GetItem().Split(TableAddPosition.After);
		}

		private void mnuTable_Select_DropDownOpening(object sender, EventArgs e)
		{
			Table table = null;
			TableRow tableRow = null;
			TableCell tableCell = null;
			TableColumn tableColumn = null;
			table = this.textControl.Tables.GetItem();
			if (table != null)
			{
				tableRow = table.Rows.GetItem();
				tableCell = table.Cells.GetItem();
				tableColumn = table.Columns.GetItem();
			}
			this.mnuTable_Select_Table.Enabled = table != null;
			this.mnuTable_Select_Row.Enabled = tableRow != null;
			this.mnuTable_Select_Cell.Enabled = tableCell != null;
			this.mnuTable_Select_Column.Enabled = tableColumn != null;
		}

		private void mnuTable_Select_Table_Click(object sender, EventArgs e)
		{
			this.textControl.Tables.GetItem().Select();
		}

		private void mnuTable_Select_Row_Click(object sender, EventArgs e)
		{
			this.textControl.Tables.GetItem().Rows.GetItem().Select();
		}

		private void mnuTable_Select_Column_Click(object sender, EventArgs e)
		{
			this.textControl.Tables.GetItem().Columns.GetItem().Select();
		}

		private void mnuTable_Select_Cell_Click(object sender, EventArgs e)
		{
			this.textControl.Tables.GetItem().Cells.GetItem().Select();
		}

		private void mnuTable_GridLines_Click(object sender, EventArgs e)
		{
			this.textControl.Tables.GridLines = !this.textControl.Tables.GridLines;
		}

		private void mnuTable_Properties_Click(object sender, EventArgs e)
		{
			this.textControl.TableFormatDialog();
		}

		private void mnuTable_Formulas_DropDownOpening(object sender, EventArgs e)
		{
			try
			{
				this.mnuTable_Formulas_A1Style.Checked = this.textControl.FormulaReferenceStyle == FormulaReferenceStyle.A1;
				this.mnuTable_Formulas_R1C1Style.Checked = this.textControl.FormulaReferenceStyle == FormulaReferenceStyle.R1C1;
				this.mnuTable_Formulas_EditFormula.Enabled = this.textControl.Tables.GetItem() != null;
				this.mnuTable_Formulas_AutomaticCalculation.Checked = this.textControl.IsFormulaCalculationEnabled;
			}
			catch (LicenseLevelException)
			{
			}
		}

		private void mnuTable_Formulas_A1Style_Click(object sender, EventArgs e)
		{
			this.textControl.FormulaReferenceStyle = FormulaReferenceStyle.A1;
		}

		private void mnuTable_Formulas_R1C1Style_Click(object sender, EventArgs e)
		{
			this.textControl.FormulaReferenceStyle = FormulaReferenceStyle.R1C1;
		}

		private void mnuTable_Formulas_EditFormula_Click(object sender, EventArgs e)
		{
			int activeTab = 2;
			this.textControl.TableFormatDialog(activeTab);
		}

		private void mnuTable_Formulas_AutomaticCalculation_Click(object sender, EventArgs e)
		{
			this.textControl.IsFormulaCalculationEnabled = this.mnuTable_Formulas_AutomaticCalculation.Checked;
		}

		private void mnuHelp_AboutTXTextControlWords_Click(object sender, EventArgs e)
		{
			AboutBox.Show(this, this.textControl.GetVersionInfo());
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

		private void UpdateToolstripState()
		{
			this.mnuBtnCopy.Enabled = this.textControl.CanCopy;
			this.mnuBtnCut.Enabled = this.textControl.CanCopy && this.textControl.CanEdit;
			this.mnuBtnPaste.Enabled = this.textControl.CanPaste;
			this.mnuBtnUndo.Enabled = this.textControl.CanUndo;
			this.mnuBtnRedo.Enabled = this.textControl.CanRedo;
			this.mnuBtnColumns.Enabled = this.textControl.CanEdit;
			this.mnuBtnMarginsAndPaper.Enabled = this.textControl.CanEdit;
			this.mnuBtnHeadersAndFooters.Enabled = this.textControl.CanEdit;
			this.mnuBtnPageBorders.Enabled = this.textControl.CanEdit;
			this.mnuBtnSelectObjects.Checked = this.textControl.SelectObjects;
		}

		private void LocalizeToolstrip()
		{
			foreach (object item in this.toolStrip.Items)
			{
				if (item.GetType() == typeof(ToolStripButton))
				{
					ToolStripButton toolStripButton = (ToolStripButton)item;
					toolStripButton.ImageScaling = ToolStripItemImageScaling.None;
					string name = toolStripButton.Name.ToUpper() + "_TEXT";
					try
					{
						toolStripButton.ToolTipText = Resources.ResourceManager.GetString(name);
					}
					catch
					{
					}
				}
			}
		}

		private void UpdateToolstripImages()
		{
			foreach (ToolStripButton item in this.toolStrip.Items.OfType<ToolStripButton>())
			{
				string text = item.Tag as string;
				if (text != null && text.StartsWith("TXITEM_"))
				{
					item.ImageScaling = ToolStripItemImageScaling.None;
					item.Apply(text, this.toolStrip.DeviceDpi);
				}
			}
		}

		private void mnuBtnNewFile_Click(object sender, EventArgs e)
		{
			this.FileNew();
		}

		private void mnuBtnOpenFile_Click(object sender, EventArgs e)
		{
			this.FileOpen();
		}

		private void mnuBtnSave_Click(object sender, EventArgs e)
		{
			this.FileSave();
		}

		private void mnuBtnPrint_Click(object sender, EventArgs e)
		{
			this.Print();
		}

		private void mnuBtnPrintPreview_Click(object sender, EventArgs e)
		{
			this.PrintPreview();
		}

		private void mnuBtnCut_Click(object sender, EventArgs e)
		{
			this.textControl.Cut();
		}

		private void mnuBtnCopy_Click(object sender, EventArgs e)
		{
			this.textControl.Copy();
		}

		private void mnuBtnPaste_Click(object sender, EventArgs e)
		{
			this.textControl.Paste();
		}

		private void mnuBtnUndo_Click(object sender, EventArgs e)
		{
			this.textControl.Undo();
		}

		private void mnuBtnRedo_Click(object sender, EventArgs e)
		{
			this.textControl.Redo();
		}

		private void mnuBtnFind_Click(object sender, EventArgs e)
		{
			this.textControl.Find();
		}

		private void mnuBtnMarginsAndPaper_Click(object sender, EventArgs e)
		{
			try
			{
				this.textControl.SectionFormatDialog(0);
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message, base.ProductName);
			}
		}

		private void mnuBtnHeadersAndFooters_Click(object sender, EventArgs e)
		{
			try
			{
				this.textControl.SectionFormatDialog(1);
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message, base.ProductName);
			}
		}

		private void mnuBtnColumns_Click(object sender, EventArgs e)
		{
			try
			{
				this.textControl.SectionFormatDialog(2);
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message, base.ProductName);
			}
		}

		private void mnuBtnPageBorders_Click(object sender, EventArgs e)
		{
			try
			{
				this.textControl.SectionFormatDialog(3);
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message, base.ProductName);
			}
		}

		private void mnuBtnSelectObjects_Click(object sender, EventArgs e)
		{
			if (this.mnuBtnSelectObjects.Checked)
			{
				this.textControl.SelectObjects = false;
			}
			else
			{
				this.textControl.SelectObjects = true;
			}
			this.mnuBtnSelectObjects.Checked = !this.mnuBtnSelectObjects.Checked;
		}

		private void mnuBtnInserBreak_Click(object sender, EventArgs e)
		{
			InsertBreakDialog insertBreakDialog = new InsertBreakDialog(this.textControl)
			{
				RightToLeft = this.RightToLeft
			};
			if (insertBreakDialog.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				this.m_fileHandler.IsDocumentDirty = true;
			}
		}

		private void mnuBtnDeleteField_Click(object sender, EventArgs e)
		{
			this.DeleteField();
		}

		private void mnuBtnFieldSettings_Click(object sender, EventArgs e)
		{
			this.FieldSettings();
		}
	}
}
