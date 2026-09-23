using System.ComponentModel;
using ns21;

namespace TXTextControl.DataVisualization
{
	/// <summary>An instance of the ChartFrame class represents a chart and its layout in a Text Control document.</summary>
	public class ChartFrame : FrameBase
	{
		private object object_0;

		/// <summary>Gets the chart control associated with the chart frame.</summary>
		[Browsable(false)]
		public Component Chart => (Component)this.object_0;

		/// <summary>Sets a value between 1 and 100, which is the quality of a lossy data compression used, if the chart's image is exported.</summary>
		[Browsable(false)]
		public int ExportCompressionQuality
		{
			get
			{
				return base.Int32_1;
			}
			set
			{
				base.Int32_1 = value;
			}
		}

		/// <summary>Gets or sets the file name, when the chart's image is exported.</summary>
		[Browsable(false)]
		public string ExportFileName
		{
			get
			{
				return base.String_0;
			}
			set
			{
				base.String_0 = value;
			}
		}

		/// <summary>Gets or sets the format used, if a chart's image is exported.</summary>
		[Browsable(false)]
		public int ExportFilterIndex
		{
			get
			{
				return base.Int32_2;
			}
			set
			{
				base.Int32_2 = value;
			}
		}

		/// <summary>Gets or sets the maximum resolution in dots per inch in which the chart's image is saved.</summary>
		[Browsable(false)]
		public int ExportResolution
		{
			get
			{
				return base.Int32_3;
			}
			set
			{
				base.Int32_3 = value;
			}
		}

		/// <summary>Determines whether the chart's image is stored through its binary data or through a file reference.</summary>
		[Browsable(false)]
		public ImageSaveMode SaveMode
		{
			get
			{
				return base.ImageSaveMode_0;
			}
			set
			{
				base.ImageSaveMode_0 = value;
			}
		}

		/// <summary>Initializes a new instance of the ChartFrame class.</summary>
		/// <param name="chart">Specifies the chart control associated with the chart frame.</param>
		public ChartFrame(Component chart)
			: base(Enum107.const_7)
		{
			this.object_0 = chart;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal ChartFrame(TextControlCore textControlCore_1, TextPart iTextPart, int iObjectID, object chart)
			: base(textControlCore_1, iTextPart, iObjectID, Enum107.const_7)
		{
			this.object_0 = chart;
		}

		/// <summary>Add the current state of the chart which is connected with this ChartFrame to the undo stack. Programmatic changes performed with the chart's properties and methods are not automatically added to a TextControl's undo stack. Calling this method is not necessary, when the chart frame's layout in the text is changed.</summary>
		public void AddUndoUnit()
		{
			if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
			{
				base.textControlCore_0.method_30((Enum83)2077, base.int_1, 0);
			}
		}

		/// <summary>Refreshes the chart. Programmatic changes performed with the chart's properties and methods are not automatically refreshed. Calling this method is not necessary, when the chart frame's layout in the text is changed.</summary>
		public void Refresh()
		{
			if (base.textControlCore_0 != null && base.textControlCore_0.isHandleCreated)
			{
				base.textControlCore_0.method_30(Enum83.const_291, base.int_1, 0);
			}
		}
	}
}
