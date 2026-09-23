/*------------------------------------------------------------------------------------------------
** program:			TX Text Control Charts Sample
** description:	    Describes how to add charting functionality to TX Text Control.
**
** copyright:		© Text Control GmbH
**----------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Windows.Forms;
using TXTextControl.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;

namespace charts_step2 {

    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
            textControl1.RulerBar = rulerBar2;
            textControl1.ButtonBar = buttonBar1;
            textControl1.StatusBar = statusBar1;
            textControl1.VerticalRulerBar = rulerBar1;
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e) {
            // load a template
            textControl1.Load(TXTextControl.StreamType.InternalUnicodeFormat);
        }

        private void mergeToolStripMenuItem_Click(object sender, EventArgs e) {
            // create a new DataSet and load the XML data
            DataSet ds = new DataSet();
            ds.ReadXml("data.xml");

            foreach (ChartFrame chartFrame in textControl1.Charts) {
                // check whether the DataSet contains data
                // related to the chart name
                if (ds.Tables.Contains(chartFrame.Name) == false)
                    continue;

                Chart chart = chartFrame.Chart as Chart;

                // set the x and y values to the first 2 columns of the DataTable
                chart.Series[0].XValueMember = ds.Tables[chartFrame.Name].Columns[0].ColumnName;
                chart.Series[0].YValueMembers = ds.Tables[chartFrame.Name].Columns[1].ColumnName;

                // set the data to the chart
                chart.DataSource = ds.Tables[chartFrame.Name];

                // data bind to the selected data source
                chart.DataBind();

                //update the chartFrame to reflect the changes
                chartFrame.Refresh();
            }
        }
    }
}
