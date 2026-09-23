using System.Windows.Forms.DataVisualization.Charting;
using TXTextControl;

namespace TX_Text_Control_Words
{
	internal static class ChartExtensions
	{
		public static bool? GetIs3D(this Chart chart)
		{
			bool? result = null;
			if (chart.ChartAreas.Count != 0)
			{
				bool? flag = null;
				foreach (ChartArea chartArea in chart.ChartAreas)
				{
					if (!flag.HasValue)
					{
						flag = chartArea.Area3DStyle.Enable3D;
					}
					else if (flag != chartArea.Area3DStyle.Enable3D)
					{
						flag = null;
						break;
					}
				}
				return flag;
			}
			return result;
		}

		public static void SetIs3D(this Chart chart, bool value)
		{
			foreach (ChartArea chartArea in chart.ChartAreas)
			{
				chartArea.Area3DStyle.Enable3D = value;
			}
		}

		public static void Init<T>(this T[] array, T value)
		{
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				array[i] = value;
			}
		}

		public static void Init(this Series series, int count, double value)
		{
			for (int i = 0; i < count; i++)
			{
				DataPoint item = new DataPoint(0.0, value);
				series.Points.Add(item);
			}
		}

		public static FrameBaseSubClass GetItem<FrameBaseSubClass>(this FrameCollection frameCollection) where FrameBaseSubClass : FrameBase
		{
			FrameBase item = frameCollection.GetItem();
			return item as FrameBaseSubClass;
		}
	}
}
