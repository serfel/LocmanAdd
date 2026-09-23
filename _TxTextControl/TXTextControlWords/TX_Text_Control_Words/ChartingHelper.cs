using System.Windows.Forms.DataVisualization.Charting;

namespace TX_Text_Control_Words
{
	public static class ChartingHelper
	{
		private static readonly string[] DummyAxisLabels = new string[4] { "1st Qtr", "2nd Qtr", "3rd Qtr", "4th Qtr" };

		private static readonly string[] DummySeriesNames = new string[3] { "East", "West", "North" };

		private static readonly double[,] DummyData = new double[3, 4]
		{
			{ 20.4, 27.4, 90.0, 20.4 },
			{ 30.6, 38.6, 34.6, 31.6 },
			{ 45.9, 46.9, 45.0, 43.9 }
		};

		internal static void FillChartWithDummyData(Chart chart, SeriesChartType chartType)
		{
			ChartArea chartArea = new ChartArea();
			chartArea.Area3DStyle.Perspective = 2;
			chartArea.Area3DStyle.Enable3D = chart.GetIs3D().GetValueOrDefault();
			chart.ChartAreas.Add(chartArea);
			Legend item = new Legend("Legend1");
			chart.Legends.Add(item);
			if (chartType == SeriesChartType.Pie)
			{
				ChartingHelper.AddDummySeries(chart, chartType, 0, ChartingHelper.DummyAxisLabels, ChartingHelper.DummySeriesNames, ChartingHelper.DummyData);
				return;
			}
			for (int i = 0; i < ChartingHelper.DummySeriesNames.Length; i++)
			{
				ChartingHelper.AddDummySeries(chart, chartType, i, ChartingHelper.DummyAxisLabels, ChartingHelper.DummySeriesNames, ChartingHelper.DummyData);
			}
		}

		private static void AddDummySeries(Chart chart, SeriesChartType chartType, int row, string[] axisLabels, string[] seriesNames, double[,] dummyData)
		{
			Series series = new Series
			{
				ChartType = chartType
			};
			for (int i = 0; i < dummyData.GetLength(1); i++)
			{
				DataPoint dataPoint = new DataPoint(0.0, dummyData[row, i]);
				dataPoint.AxisLabel = axisLabels[i];
				series.Points.Add(dataPoint);
			}
			series.Name = seriesNames[row];
			chart.Series.Add(series);
		}
	}
}
