using System;
using System.Drawing;
using ns21;

namespace TXTextControl.ServerVisualisation
{
	public class ViewChangedEventArgs : EventArgs
	{
		private IntPtr intptr_0 = IntPtr.Zero;

		private bool bool_0 = true;

		private ScrollOrientation scrollOrientation_0;

		private short short_0;

		private Rectangle rectangle_0 = default(Rectangle);

		public ScrollOrientation ScrollOrientation => this.scrollOrientation_0;

		public int ScrollDistance => this.short_0;

		public Rectangle ClipRectangle
		{
			get
			{
				if (this.rectangle_0.IsEmpty && this.intptr_0 != IntPtr.Zero)
				{
					Class429.Struct83 struct83_ = default(Class429.Struct83);
					if (this.scrollOrientation_0 == ScrollOrientation.None)
					{
						if (this.bool_0)
						{
							Class429.GetClientRect(this.intptr_0, ref struct83_);
						}
						else
						{
							Class429.SendMessage_3(this.intptr_0, 2137, 0, ref struct83_);
						}
					}
					else
					{
						Class429.GetClientRect(this.intptr_0, ref struct83_);
						switch (this.scrollOrientation_0)
						{
						case ScrollOrientation.HorizontalScroll:
							if (this.short_0 < 0)
							{
								struct83_.int_0 = struct83_.int_2 + this.short_0;
							}
							if (this.short_0 > 0)
							{
								struct83_.int_2 = this.short_0;
							}
							break;
						case ScrollOrientation.VerticalScroll:
							if (this.short_0 < 0)
							{
								struct83_.int_1 = struct83_.int_3 + this.short_0;
							}
							if (this.short_0 > 0)
							{
								struct83_.int_3 = this.short_0;
							}
							break;
						}
					}
					this.rectangle_0 = struct83_.method_0();
				}
				return this.rectangle_0;
			}
		}

		internal ViewChangedEventArgs(IntPtr handle, bool bUpdateAll, ScrollOrientation iScrollDir, short iAmount)
		{
			this.intptr_0 = handle;
			this.bool_0 = bUpdateAll;
			this.scrollOrientation_0 = iScrollDir;
			this.short_0 = iAmount;
		}
	}
}
