using System.ComponentModel;

namespace TXTextControl
{
	/// <summary>The CannotTrackChangeEventArgs class provides data for the CannotTrackChange event.</summary>
	public class CannotTrackChangeEventArgs : CancelEventArgs
	{
		private bool bool_0;

		private string string_0 = "";

		/// <summary>A subscriber can set this property to true to indicate that he has handled the event.</summary>
		public bool Handled
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}

		/// <summary>Gets the default message for the user.</summary>
		public string DefaultMessage
		{
			get
			{
				return this.string_0;
			}
			internal set
			{
				this.string_0 = value;
			}
		}

		internal CannotTrackChangeEventArgs()
			: base(cancel: true)
		{
		}
	}
}
