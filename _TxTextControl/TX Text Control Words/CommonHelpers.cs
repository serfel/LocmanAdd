/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TX_Text_Control_Words.Properties;
using TXTextControl;

namespace TX_Text_Control_Words
{

	/*-------------------------------------------------------------------------------------------------------
	** Partial Class MainWindow
	** Provides some common helper methods.
	**-----------------------------------------------------------------------------------------------------*/
	public partial class MainWindow : Form {

		/*-------------------------------------------------------------------------------------------------------
		** M E T H O D S    C H A R T I N G
		**-----------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------
		** SetAxisTitle
		** Sets the names of the shape menu items
		**-----------------------------------------------------------------------------------------------------*/
		private void SetAxisTitle(Axis axis) {
			var frmInput = new InputBoxDialog(Resources.INPUTBOXDLG_SETAXISTITLE_TITLE, axis.Title)
			{
				SelectedFont = axis.TitleFont,
				HasFontButton = true,
				RightToLeft = this.RightToLeft
			};

			if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
				axis.Title = frmInput.TextInput;
				axis.TitleFont = frmInput.SelectedFont;
			}
		}


		/*-------------------------------------------------------------------------------------------------------
		** SetChartTitleCenteredOverlay
		** Sets the chart title above the chart.
		**-----------------------------------------------------------------------------------------------------*/
		private void SetChartTitleAboveChart() {
			var selectedChartFrame = textControl.Frames.GetItem<TXTextControl.DataVisualization.ChartFrame>();
			if (selectedChartFrame == null) return;

			SetFirstChartTitle();
			var chart = (Chart)selectedChartFrame.Chart;
			if (chart.Titles.Count == 0) return;

			chart.Titles[0].DockedToChartArea = string.Empty;
			selectedChartFrame.Refresh();
		}

		/*-------------------------------------------------------------------------------------------------------
		** SetChartTitleCenteredOverlay
		** Sets the chart title centered overlay.
		**-----------------------------------------------------------------------------------------------------*/
		private void SetChartTitleCenteredOverlay() {
			var selectedChartFrame = textControl.Frames.GetItem<TXTextControl.DataVisualization.ChartFrame>();
			if (selectedChartFrame == null) return;

			SetFirstChartTitle();
			var chart = (Chart)selectedChartFrame.Chart;
			if (chart.Titles.Count == 0) return;

			chart.Titles[0].DockedToChartArea = chart.ChartAreas[0].Name;
			selectedChartFrame.Refresh();
		}

		/*-------------------------------------------------------------------------------------------------------
		** SetFirstChartTitle
		** Sets the first title of the current chart.
		**-----------------------------------------------------------------------------------------------------*/
		private void SetFirstChartTitle() {
			var selectedChartFrame = textControl.Frames.GetItem<TXTextControl.DataVisualization.ChartFrame>();
			if (selectedChartFrame == null) return;

			var chart = (Chart)selectedChartFrame.Chart;
			var title = (chart.Titles.Count == 0) ? new Title() : chart.Titles[0];

			var frmInput = new InputBoxDialog(Resources.INPUTBOXDLG_SETCHARTTITLE_TITLE, title.Text)
			{
				SelectedFont = title.Font,
				HasFontButton = true
			};

			if (frmInput.ShowDialog(this) == System.Windows.Forms.DialogResult.OK) {
				if (frmInput.TextInput == string.Empty) return;

				title.Text = frmInput.TextInput;
				title.Font = frmInput.SelectedFont;

				if (chart.Titles.Count == 0) chart.Titles.Add(title);
			}
		}

		/*-------------------------------------------------------------------------------------------------------
		** ClearChartAxisTitles
		** Clear the chart axis titles of the current chart.
		**-----------------------------------------------------------------------------------------------------*/
		private void ClearChartAxisTitles() {
			var selectedChartFrame = textControl.Frames.GetItem<TXTextControl.DataVisualization.ChartFrame>();
			if (selectedChartFrame == null) return;

			var chart = (Chart)selectedChartFrame.Chart;
			chart.ChartAreas[0].AxisX.Title = string.Empty;
			chart.ChartAreas[0].AxisY.Title = string.Empty;

			selectedChartFrame.Refresh();
		}

		/*-------------------------------------------------------------------------------------------------------
		** ClearChartTitles
		** Clears the title of the current chart frame.
		**-----------------------------------------------------------------------------------------------------*/
		private void ClearChartTitles() {
			var selectedChartFrame = textControl.Frames.GetItem<TXTextControl.DataVisualization.ChartFrame>();
			if (selectedChartFrame == null) return;

			var chart = (Chart)selectedChartFrame.Chart;
			chart.Titles.Clear();
			selectedChartFrame.Refresh();
		}

		/*-------------------------------------------------------------------------------------------------------
		** EditChartData
		** Shows a dialog for editing the selected chart.
		**-----------------------------------------------------------------------------------------------------*/
		private void EditChartData() {
			var chartFrame = textControl.Charts.GetItem();
			if (chartFrame == null) return;

			ChartDataGridDialog.ShowDialog(chartFrame, this);
		}

		/*-------------------------------------------------------------------------------------------------------
		** InsertMSChart
		** Creates and inserts a specific chart frame into the TextControl.
		**-----------------------------------------------------------------------------------------------------*/
		private void InsertMSChart(SeriesChartType chartType, bool is3D) {
			try {
				// Force exception if standard version
				textControl.Charts.GetItem();

				var chart = new Chart();
				chart.TextAntiAliasingQuality = TextAntiAliasingQuality.Normal;
				chart.Size = new Size(500, 400);

				ChartingHelper.FillChartWithDummyData(chart, chartType);
				chart.SetIs3D(is3D);
				var cf = new TXTextControl.DataVisualization.ChartFrame(chart);
				textControl.Charts.Add(cf, TXTextControl.HorizontalAlignment.Left, -1, TXTextControl.FrameInsertionMode.DisplaceCompleteLines);

				Application.DoEvents();    // Allow chart to paint itself

				ChartDataGridDialog.ShowDialog(cf, this);
			}
			catch (Exception exc) {
				Utils.MessageBox.Show(this, exc.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		/*-------------------------------------------------------------------------------------------------------
		** InsertMSChart
		** Creates and inserts a specific chart frame into the TextControl.
		**-----------------------------------------------------------------------------------------------------*/
		private void InsertMSChart(string chartType, bool is3D) {
			switch (chartType) {
				case "Pie":
					InsertMSChart(SeriesChartType.Pie, is3D);
					break;

				case "Bar":
					InsertMSChart(SeriesChartType.Bar, is3D);
					break;

				case "Column":
					InsertMSChart(SeriesChartType.Column, is3D);
					break;

				case "Line":
					InsertMSChart(SeriesChartType.Line, is3D);
					break;

				case "Area":
					InsertMSChart(SeriesChartType.Area, is3D);
					break;
			}
		}


		/*-------------------------------------------------------------------------------------------------------
		** M E T H O D S    T E X T C O N T R O L
		**-----------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------
		** InsertPageNumber
		** Inserts a page number into the current header or footer (if the header or footer is activated)
		**-----------------------------------------------------------------------------------------------------*/
		private void InsertPageNumber() {
			try {
				object textPart = textControl.TextParts.GetItem();
				if (!(textPart is HeaderFooter)) return;

				var hdrFtr = (HeaderFooter)textPart;

				var pgNumFld = new PageNumberField
				{
					StartNumber = 1,
					Editable = false,
					DoubledInputPosition = true,
					HighlightMode = HighlightMode.Activated,
				};
				hdrFtr.PageNumberFields.Add(pgNumFld);
			}
			catch (Exception ex) {
				// Display information if feature not enabled in current version
				Utils.MessageBox.Show(this, ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}
		}


		/*-------------------------------------------------------------------------------------------------------
		** IsMyFile
		** Returns a value indication whether the file ends with .rtf, .doc, .docx or .tx
		**-----------------------------------------------------------------------------------------------------*/
		private bool IsMyFile(string strTarget) {
			string strExt = Path.GetExtension(strTarget).ToLower();

			switch (strExt) {
				case ".rtf":
				case ".doc":
				case ".docx":
				case ".tx":
					return true;
			}

			return false;
		}

		/*-------------------------------------------------------------------------------------------------------
		** OpenFileInNewInstance
		** Opens a file in a new instance
		**-----------------------------------------------------------------------------------------------------*/
		private void OpenFileInNewInstance(string strTarget) {
			// Check if file exists and show message box if not
			if (!File.Exists(strTarget)) {
				Utils.MessageBox.Show(this, String.Format(Properties.Resources.MSG_FILE_DOES_NOT_EXIST, strTarget), "Hyperlink", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Get running demo's exe path
			string exePath = Assembly.GetEntryAssembly().Location;

			// Start new demo instance
			var process = new Process();
			process.StartInfo.FileName = exePath;
			process.StartInfo.Arguments = "\"" + strTarget + "\"";
			process.Start();
		}

		/*-------------------------------------------------------------------------------------------------------
		** OpenHyperlink
		** Process the passed string as a hyperlink's target. A hyperlink can target a file or a HTTP address.
		** If the hyperlink targets a file then try open this file as document in a new TX Text Control Words
		** instance else if the hyperlink represents a HTTP address then create a new process for handling
		** this.
		**-----------------------------------------------------------------------------------------------------*/
		private void OpenHyperlink(string strTarget) {
			if (strTarget == "") return;

			try {
				Uri uriTarget = new Uri(strTarget, UriKind.RelativeOrAbsolute);
				if (!uriTarget.IsAbsoluteUri) {
					throw new Exception("Only absolute file paths / links are supported.");
				}

				if (uriTarget.IsFile) {
					// Remove any fragment.
					// uriTarget.GetLeftPart(UriPartial.Path) has no effect because the .NET Uri class
					// does not work correct with file URIs containing any query or fragment part.

					strTarget = uriTarget.LocalPath;
					int nPos = strTarget.IndexOf("#");
					if (nPos != -1) {
						strTarget = strTarget.Substring(0, nPos);
					}
				}
				else if (uriTarget.Scheme != Uri.UriSchemeHttp && uriTarget.Scheme != Uri.UriSchemeHttps) {
					strTarget = uriTarget.GetLeftPart(UriPartial.Path);
				}

				if (uriTarget.IsFile && IsMyFile(strTarget)) {
					OpenFileInNewInstance(strTarget);
				}
				else {
					System.Diagnostics.Process.Start(strTarget);
				}
			}
			catch (Exception ex) {
				string msg = ex.Message;
				if (!msg.EndsWith(".")) msg += ".";
				Utils.MessageBox.Show(this, Resources.MSG_COULD_NOT_OPEN_LINK + " " + msg, "Hyperlink", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/*-------------------------------------------------------------------------------------------------------
		** RemovePageNumbers
		** Removes all page numbers of the current section.
		**-----------------------------------------------------------------------------------------------------*/
		private void RemovePageNumbers() {
			Section sectCur = null;

			try {
				sectCur = textControl.Sections.GetItem();
				if (sectCur == null) return;

				foreach (HeaderFooter hdrFtr in sectCur.HeadersAndFooters) {
					hdrFtr.PageNumberFields.Clear(false);
				}
			}
			catch (Exception ex) {
				// Display information if feature not enabled in current version
				Utils.MessageBox.Show(this, ex.Message, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		/*-------------------------------------------------------------------------------------------------------
		** SetAxisTitlesBelowChart
		**-----------------------------------------------------------------------------------------------------*/
		private void SetAxisTitlesBelowChart() {
			var selectedChartFrame = textControl.Frames.GetItem<TXTextControl.DataVisualization.ChartFrame>();
			if (selectedChartFrame == null) return;

			var chart = (Chart)selectedChartFrame.Chart;
			SetAxisTitle(chart.ChartAreas[0].AxisX);
			selectedChartFrame.Refresh();
		}

		/*-------------------------------------------------------------------------------------------------------
		** SetVerticalAxisTitle
		**-----------------------------------------------------------------------------------------------------*/
		private void SetVerticalAxisTitle() {
			var selectedChartFrame = textControl.Frames.GetItem<TXTextControl.DataVisualization.ChartFrame>();
			if (selectedChartFrame == null) return;

			var chart = (Chart)selectedChartFrame.Chart;
			SetAxisTitle(chart.ChartAreas[0].AxisY);
			selectedChartFrame.Refresh();
		}

		/*-------------------------------------------------------------------------------------------------------
		** DisableChartLegend
		**-----------------------------------------------------------------------------------------------------*/
		private void DisableChartLegend() {
			var selectedChartFrame = textControl.Frames.GetItem<TXTextControl.DataVisualization.ChartFrame>();
			if (selectedChartFrame == null) return;

			var chart = (Chart)selectedChartFrame.Chart;
			chart.Legends[0].Enabled = false;
			selectedChartFrame.Refresh();
		}

		/*-------------------------------------------------------------------------------------------------------
		** SetChartLegendRight
		**-----------------------------------------------------------------------------------------------------*/
		private void SetChartLegendTop() {
			var selectedChartFrame = textControl.Frames.GetItem<TXTextControl.DataVisualization.ChartFrame>();
			if (selectedChartFrame == null) return;

			var chart = (Chart)selectedChartFrame.Chart;
			Legend legend = chart.Legends[0];
			legend.Enabled = true;
			legend.Docking = Docking.Top;

			selectedChartFrame.Refresh();
		}

		/*-------------------------------------------------------------------------------------------------------
		** SetChartLegendRight
		**-----------------------------------------------------------------------------------------------------*/
		private void SetChartLegendRight() {
			var selectedChartFrame = textControl.Frames.GetItem<TXTextControl.DataVisualization.ChartFrame>();
			if (selectedChartFrame == null) return;

			var chart = (Chart)selectedChartFrame.Chart;
			Legend legend = chart.Legends[0];
			legend.Enabled = true;
			legend.Docking = Docking.Right;

			selectedChartFrame.Refresh();
		}

		/*-------------------------------------------------------------------------------------------------------
		** SetChartLegendBottom
		**-----------------------------------------------------------------------------------------------------*/
		private void SetChartLegendBottom() {
			var selectedChartFrame = textControl.Frames.GetItem<TXTextControl.DataVisualization.ChartFrame>();
			if (selectedChartFrame == null) return;

			var chart = (Chart)selectedChartFrame.Chart;
			Legend legend = chart.Legends[0];
			legend.Enabled = true;
			legend.Docking = Docking.Bottom;

			selectedChartFrame.Refresh();
		}

		/*-------------------------------------------------------------------------------------------------------
		** SetChartLegendLeft
		**-----------------------------------------------------------------------------------------------------*/
		private void SetChartLegendLeft() {
			var selectedChartFrame = textControl.Frames.GetItem<TXTextControl.DataVisualization.ChartFrame>();
			if (selectedChartFrame == null) return;

			var chart = (Chart)selectedChartFrame.Chart;
			Legend legend = chart.Legends[0];
			legend.Enabled = true;
			legend.Docking = Docking.Left;

			selectedChartFrame.Refresh();
		}

		/*-------------------------------------------------------------------------------------------------------
		** RemoveChartDataLabels
		**-----------------------------------------------------------------------------------------------------*/
		private void RemoveChartDataLabels() {
			var selectedChartFrame = textControl.Frames.GetItem<TXTextControl.DataVisualization.ChartFrame>();
			if (selectedChartFrame == null) return;

			var chart = (Chart)selectedChartFrame.Chart;
			foreach (Series s in chart.Series) {
				s.IsValueShownAsLabel = false;
			}

			selectedChartFrame.Refresh();
		}

		/*-------------------------------------------------------------------------------------------------------
		** SetChartDataLabelsOutsideEnd
		**-----------------------------------------------------------------------------------------------------*/
		private void SetChartDataLabelsOutsideEnd() {
			var selectedChartFrame = textControl.Frames.GetItem<TXTextControl.DataVisualization.ChartFrame>();
			if (selectedChartFrame == null) return;

			var chart = (Chart)selectedChartFrame.Chart;
			foreach (Series s in chart.Series) {
				s.IsValueShownAsLabel = true;
			}

			selectedChartFrame.Refresh();
		}

		/*-------------------------------------------------------------------------------------------------------
		** SetChartAxesLeftToRight
		**-----------------------------------------------------------------------------------------------------*/
		private void SetChartAxesLeftToRight() {
			var selectedChartFrame = textControl.Frames.GetItem<TXTextControl.DataVisualization.ChartFrame>();
			if (selectedChartFrame == null) return;

			var chart = (Chart)selectedChartFrame.Chart;
			ChartArea area = chart.ChartAreas[0];
			area.AxisX.Enabled = AxisEnabled.True;

			selectedChartFrame.Refresh();
		}

		/*-------------------------------------------------------------------------------------------------------
		** RemoveLabelsFromAxes
		**-----------------------------------------------------------------------------------------------------*/
		private void RemoveLabelsFromAxes() {
			var selectedChartFrame = textControl.Frames.GetItem<TXTextControl.DataVisualization.ChartFrame>();
			if (selectedChartFrame == null) return;

			var chart = (Chart)selectedChartFrame.Chart;
			var area = chart.ChartAreas[0];
			area.AxisX.Enabled = AxisEnabled.False;
			selectedChartFrame.Refresh();
		}

		/*-------------------------------------------------------------------------------------------------------
		** RemoveHorizChartGridLines
		**-----------------------------------------------------------------------------------------------------*/
		private void RemoveHorizChartGridLines() {
			var selectedChartFrame = textControl.Frames.GetItem<TXTextControl.DataVisualization.ChartFrame>();
			if (selectedChartFrame == null) return;

			var chart = (Chart)selectedChartFrame.Chart;
			Axis axisVert = chart.ChartAreas[0].AxisY;
			axisVert.MajorGrid.Enabled = false;
			axisVert.MinorGrid.Enabled = false;

			selectedChartFrame.Refresh();
		}

		/*-------------------------------------------------------------------------------------------------------
		** SetMajorHorizChartGridLines
		**-----------------------------------------------------------------------------------------------------*/
		private void SetMajorHorizChartGridLines() {
			var selectedChartFrame = textControl.Frames.GetItem<TXTextControl.DataVisualization.ChartFrame>();
			if (selectedChartFrame == null) return;

			var chart = (Chart)selectedChartFrame.Chart;
			Axis axisVert = chart.ChartAreas[0].AxisY;
			axisVert.MajorGrid.Enabled = true;

			selectedChartFrame.Refresh();
		}

		/*-------------------------------------------------------------------------------------------------------
		** SetMinorHorizChartGridLines
		**-----------------------------------------------------------------------------------------------------*/
		private void SetMinorHorizChartGridLines() {
			var selectedChartFrame = textControl.Frames.GetItem<TXTextControl.DataVisualization.ChartFrame>();
			if (selectedChartFrame == null) return;

			var chart = (Chart)selectedChartFrame.Chart;
			Axis axisVert = chart.ChartAreas[0].AxisY;
			axisVert.MinorGrid.Enabled = true;

			selectedChartFrame.Refresh();
		}

		/*-------------------------------------------------------------------------------------------------------
		** SetMajAndMinHorizChartGridLines
		**-----------------------------------------------------------------------------------------------------*/
		private void SetMajAndMinHorizChartGridLines() {
			var selectedChartFrame = textControl.Frames.GetItem<TXTextControl.DataVisualization.ChartFrame>();
			if (selectedChartFrame == null) return;

			var chart = (Chart)selectedChartFrame.Chart;
			Axis axisVert = chart.ChartAreas[0].AxisY;
			axisVert.MajorGrid.Enabled = true;
			axisVert.MinorGrid.Enabled = true;

			selectedChartFrame.Refresh();
		}

		/*-------------------------------------------------------------------------------------------------------
		** RemoveChartGridLines
		**-----------------------------------------------------------------------------------------------------*/
		private void RemoveChartGridLines() {
			var selectedChartFrame = textControl.Frames.GetItem<TXTextControl.DataVisualization.ChartFrame>();
			if (selectedChartFrame == null) return;

			var chart = (Chart)selectedChartFrame.Chart;
			Axis axisHor = chart.ChartAreas[0].AxisX;
			axisHor.MajorGrid.Enabled = false;
			axisHor.MinorGrid.Enabled = false;

			selectedChartFrame.Refresh();
		}

		/*-------------------------------------------------------------------------------------------------------
		** SetMajorVertChartGridLines
		**-----------------------------------------------------------------------------------------------------*/
		private void SetMajorVertChartGridLines() {
			var selectedChartFrame = textControl.Frames.GetItem<TXTextControl.DataVisualization.ChartFrame>();
			if (selectedChartFrame == null) return;

			var chart = (Chart)selectedChartFrame.Chart;
			Axis axisHor = chart.ChartAreas[0].AxisX;
			axisHor.MajorGrid.Enabled = true;

			selectedChartFrame.Refresh();
		}

		/*-------------------------------------------------------------------------------------------------------
		** SetMinorVertChartGridLines
		**-----------------------------------------------------------------------------------------------------*/
		private void SetMinorVertChartGridLines() {
			var selectedChartFrame = textControl.Frames.GetItem<TXTextControl.DataVisualization.ChartFrame>();
			if (selectedChartFrame == null) return;

			var chart = (Chart)selectedChartFrame.Chart;
			Axis axisHor = chart.ChartAreas[0].AxisX;
			axisHor.MinorGrid.Enabled = true;

			selectedChartFrame.Refresh();
		}

		/*-------------------------------------------------------------------------------------------------------
		** SetMajAndMinVertChartGridLines
		**-----------------------------------------------------------------------------------------------------*/
		private void SetMajAndMinVertChartGridLines() {
			var selectedChartFrame = textControl.Frames.GetItem<TXTextControl.DataVisualization.ChartFrame>();
			if (selectedChartFrame == null) return;

			var chart = (Chart)selectedChartFrame.Chart;
			Axis axisHor = chart.ChartAreas[0].AxisX;
			axisHor.MajorGrid.Enabled = true;
			axisHor.MinorGrid.Enabled = true;

			selectedChartFrame.Refresh();
		}

		/*-------------------------------------------------------------------------------------------------------
		** TryInsertMSChart
		** Tries to create and insert a specific chart frame into the TextControl. If it fails the corresponding 
		** exception is catched and the method returns false. Otherwise true.
		**-----------------------------------------------------------------------------------------------------*/
		private bool TryInsertMSChart(string chartType, bool is3D) {
			try {
				InsertMSChart(chartType, is3D);
				return true;
			}
			catch {
				MSChartLinkDialog.Show(this);
			}
			return false;
		}
	}
}
