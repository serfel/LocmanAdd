using System;
using System.Drawing;
using ns17;

namespace TXTextControl.Drawing
{
	/// <summary>The ViewChangedEventArgs class provides data for the TXDrawingControl.ViewChanged event.</summary>
	public class ViewChangedEventArgs : EventArgs
	{
		private Rectangle rectangle_0;

		/// <summary>Gets an object of type System.Drawing.Rectangle that represents the region where the control view is changed by UI editing.</summary>
		public Rectangle ClipRectangle => this.rectangle_0;

		internal ViewChangedEventArgs(Class178 clipRectangle, int zoomFactor, bool isWPF)
		{
			this.rectangle_0 = (isWPF ? new Rectangle((int)MeasuringHelper.ZoomValue(clipRectangle.Double_0, zoomFactor, viseVersa: false) / 15, (int)MeasuringHelper.ZoomValue(clipRectangle.Double_1, zoomFactor, viseVersa: false) / 15, (int)MeasuringHelper.ZoomValue(clipRectangle.Double_3, zoomFactor, viseVersa: false) / 15, (int)MeasuringHelper.ZoomValue(clipRectangle.Double_2, zoomFactor, viseVersa: false) / 15) : new Rectangle((int)MeasuringHelper.Twips2Pixels(clipRectangle.Double_0, zoomFactor), (int)MeasuringHelper.Twips2Pixels(clipRectangle.Double_1, zoomFactor), (int)MeasuringHelper.Twips2Pixels(clipRectangle.Double_3, zoomFactor), (int)MeasuringHelper.Twips2Pixels(clipRectangle.Double_2, zoomFactor)));
		}
	}
}
