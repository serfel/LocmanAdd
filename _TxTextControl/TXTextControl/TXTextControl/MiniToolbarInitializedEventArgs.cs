using System;

namespace TXTextControl
{
	/// <summary>The MiniToolbarInitializedEventArgs class provides data for the TextControl.TextMiniToolbarInitialized or TextControl.ObjectMiniToolbarInitialized event of a Windows Forms TextControl just after the pre-defined TextMiniToolbar or ObjectMiniToolbar was created.</summary>
	public class MiniToolbarInitializedEventArgs : EventArgs
	{
		private TextControl textControl_0;

		private bool bool_0;

		/// <summary>Considering which event (TextControl.TextMiniToolbarInitialized or TextControl.ObjectMiniToolbarInitialized) is raised the property provides an object of type TextMiniToolbar or ObjectMiniToolbar that can be altered, extended or completely replaced.</summary>
		public MiniToolbar MiniToolbar
		{
			get
			{
				if (this.bool_0)
				{
					return this.textControl_0.MiniToolbar_0;
				}
				return this.textControl_0.MiniToolbar_1;
			}
			set
			{
				if (this.bool_0)
				{
					this.textControl_0.MiniToolbar_0 = value;
				}
				else
				{
					this.textControl_0.MiniToolbar_1 = value;
				}
			}
		}

		internal MiniToolbarInitializedEventArgs(TextControl textControl, bool isTextMiniToolbar)
		{
			this.textControl_0 = textControl;
			this.bool_0 = isTextMiniToolbar;
		}
	}
}
