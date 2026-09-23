/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System.Windows.Forms.DataVisualization.Charting;

namespace TX_Text_Control_Words {

	/*------------------------------------------------------------------------------------------------
	** Class ChartExtensions
	** Implements methods for extending the Charting class.
	** Provides functionalities for setting a chart's style to 3D and initialize a Series with
	** a set of data.
	**----------------------------------------------------------------------------------------------*/
	static class ChartExtensions {

		/*------------------------------------------------------------------------------------------------
		** GetIs3D method
		** Checks whether the chart is 3D. 
		** The chart is 3D if each chartarea's style is 3D. => return true
		** The chart is not 3D if each chartarea's style is not 3D.  => return false
		** The chart is "partial" 3D if minimum one chartarea's style is 3D and another one is not 3D. => return null.
		**----------------------------------------------------------------------------------------------*/
		public static bool? GetIs3D(this Chart chart) {
			bool? result = null;
			if (chart.ChartAreas.Count != 0) {
				bool? bPrevWas3D = null;
				foreach (ChartArea ca in chart.ChartAreas) {
					if (bPrevWas3D == null) bPrevWas3D = ca.Area3DStyle.Enable3D;
					else if (bPrevWas3D != ca.Area3DStyle.Enable3D) {
						bPrevWas3D = null;
						break;
					}
				}
				result = bPrevWas3D;
			}
			return result;
		}

		/*------------------------------------------------------------------------------------------------
		** SetIs3D method
		** Set each ChartArea's style to 3D.
		**----------------------------------------------------------------------------------------------*/
		public static void SetIs3D(this Chart chart, bool value) {
			foreach (ChartArea ca in chart.ChartAreas) {
				ca.Area3DStyle.Enable3D = value;
			}
		}

		/*------------------------------------------------------------------------------------------------
		** Init<T> method
		** Set each array's item to value.
		**----------------------------------------------------------------------------------------------*/
		public static void Init<T>(this T[] array, T value) {
			int nLen = array.Length;
			for (int i = 0; i < nLen; ++i) array[i] = value;
		}

		/*------------------------------------------------------------------------------------------------
		** Init method
		** Add a count of points to the series and sets the point's Y-value to the passed value.
		**----------------------------------------------------------------------------------------------*/
		public static void Init(this Series series, int count, double value) {
			for (int i = 0; i < count; ++i) {
				var point = new DataPoint(0D, value);
				series.Points.Add(point);
			}
		}

		/*------------------------------------------------------------------------------------------------
		** GetItem<FrameBaseSubClass:FrameBase> method
		** Returns a specific type of object of base class FrameBase otherwise null.
		**----------------------------------------------------------------------------------------------*/
		public static FrameBaseSubClass GetItem<FrameBaseSubClass>(this TXTextControl.FrameCollection frameCollection) where FrameBaseSubClass : TXTextControl.FrameBase {
			var frameBase = frameCollection.GetItem();

			return frameBase as FrameBaseSubClass;
		}
	}

	/*------------------------------------------------------------------------------------------------
	** Class ChartingHelper
	** Capsulates dummy data for a chart and implements a method for filling a chart with this
	** dummy data.
	**----------------------------------------------------------------------------------------------*/
	public static class ChartingHelper {

		/*------------------------------------------------------------------------------------------------
		** DUMMY DATA
		**----------------------------------------------------------------------------------------------*/
		private static readonly string[] DummyAxisLabels = new string[] { "1st Qtr", "2nd Qtr", "3rd Qtr", "4th Qtr" };
		private static readonly string[] DummySeriesNames = new string[] { "East", "West", "North" };
		private static readonly double[,] DummyData = new double[,] { { 20.4, 27.4, 90, 20.4 }, { 30.6, 38.6, 34.6, 31.6 }, { 45.9, 46.9, 45, 43.9 } };

		/*------------------------------------------------------------------------------------------------
		** P U B L I C   M E T H O D S
		**----------------------------------------------------------------------------------------------*/

		/*------------------------------------------------------------------------------------------------
		** FillChartWithDummyData method
		** Fills the chart with the dummy data.
		**----------------------------------------------------------------------------------------------*/
		internal static void FillChartWithDummyData(Chart chart, SeriesChartType chartType) {
			// Create chart area
			var ca = new ChartArea();
			ca.Area3DStyle.Perspective = 2;
			ca.Area3DStyle.Enable3D = chart.GetIs3D() ?? false;
			chart.ChartAreas.Add(ca);

			// Add a legend
			var legend = new Legend("Legend1");
			chart.Legends.Add(legend);

			// Add sample series
			switch (chartType) {
				case SeriesChartType.Pie:
					AddDummySeries(chart, chartType, 0, DummyAxisLabels, DummySeriesNames, DummyData);
					break;

				default:
					for (int j = 0; j < DummySeriesNames.Length; ++j) {
						AddDummySeries(chart, chartType, j, DummyAxisLabels, DummySeriesNames, DummyData);
					}
					break;
			}
		}

		/*------------------------------------------------------------------------------------------------
		** H E L P E R S
		**----------------------------------------------------------------------------------------------*/

		/*------------------------------------------------------------------------------------------------
		** AddDummySeries method
		** Adds the series to the chart with help of the passed dummy data.
		**----------------------------------------------------------------------------------------------*/
		private static void AddDummySeries(Chart chart, SeriesChartType chartType, int row, string[] axisLabels, string[] seriesNames, double[,] dummyData) {
			var series = new Series { ChartType = chartType };
			for (int i = 0; i < dummyData.GetLength(1); ++i) {
				var point = new DataPoint(0D, dummyData[row, i]);
				point.AxisLabel = axisLabels[i];
				series.Points.Add(point);
			}
			series.Name = seriesNames[row];
			chart.Series.Add(series);
		}
	}
}