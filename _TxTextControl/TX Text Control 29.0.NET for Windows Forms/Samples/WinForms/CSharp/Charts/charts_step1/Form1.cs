/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Charts Sample
** description:	    Describes how to add charting functionality to TX Text Control.
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using TXTextControl.DataVisualization;
using TXTextControl;

namespace charts_step1 {
    public partial class Form1 : Form {

        DataTable dt = new DataTable();
        ChartFrame currentFrame;
        int chartNameID = 1;

        public Form1() {
            InitializeComponent();
            textControl1.RulerBar = rulerBar2;
            textControl1.ButtonBar = buttonBar1;
            textControl1.StatusBar = statusBar1;
            textControl1.VerticalRulerBar = rulerBar1;

            // add default data points for demo purposes
            dt.Columns.Add("Country");
            dt.Columns.Add("Value");

            dt.Rows.Add(new object[] { "United States", 700 });
            dt.Rows.Add(new object[] { "Europe", 600 });
            dt.Rows.Add(new object[] { "Asia", 800 });
            dt.Rows.Add(new object[] { "Africa", 400 });
        }

        private void chartToolStripMenuItem_Click(object sender, EventArgs e) {
            Chart chart = new Chart();
            chart.Series.Add("series1");
            chart.ChartAreas.Add("area1");

            chart.DataSource = dt;

            // set series members names for the X and Y values
            chart.Series[0].XValueMember = "Country";
            chart.Series[0].YValueMembers = "Value";

            // data bind to the selected data source
            chart.DataBind();

            // create new ChartFrame and add it to TX Text Control
            ChartFrame chartFrame = new ChartFrame(chart);
            chartFrame.Name = "points";
            chartNameID++;

            textControl1.Charts.Add(chartFrame, -1);
        }

        private void textControl1_ChartClicked(object sender, ChartEventArgs e) {
            currentFrame = e.ChartFrame;
            tbChartName.Text = e.ChartFrame.Name;
            propertyGrid1.SelectedObject = e.ChartFrame.Chart;
        }

        private void textControl1_Click(object sender, EventArgs e) {
            tbChartName.Text = "";
            propertyGrid1.SelectedObject = null;
        }

        private void SetChartName() {
            if (tbChartName.Text == "")
                return;

            currentFrame.Name = tbChartName.Text;
            textControl1.Focus();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e) {
            textControl1.Load(StreamType.InternalUnicodeFormat);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            textControl1.Save(StreamType.InternalUnicodeFormat);
        }

        private void btnApply_Click(object sender, EventArgs e) {
            SetChartName();
        }

        private void tbChartName_KeyUp(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
                SetChartName();
        }

        private void propertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e) {
            currentFrame.Refresh();
        }

    }
}
