using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading;
using ns21;

namespace TXTextControl.ServerVisualisation
{
	[Serializable]
	public class View : MarshalByRefObject
	{
		internal const int int_0 = 1000;

		private Type type_0;

		private IntPtr intptr_0 = IntPtr.Zero;

		private bool bool_0 = true;

		private Size size_0 = new Size(1000, 1000);

		private int int_1 = 100;

		private EventHandler eventHandler_0;

		private EventHandler eventHandler_1;

		private ViewChangedEventHandler viewChangedEventHandler_0;

		private EventHandler eventHandler_2;

		public Point Location
		{
			get
			{
				Point result = new Point(0, 0);
				if (this.intptr_0 != IntPtr.Zero)
				{
					result.X = Class429.SendMessage_1(this.intptr_0, 1192, 1, 0);
					result.Y = Class429.SendMessage_1(this.intptr_0, 1192, 2, 0);
				}
				return result;
			}
			set
			{
				if (this.intptr_0 != IntPtr.Zero)
				{
					this.bool_0 = false;
					Class429.SendMessage_1(this.intptr_0, 1173, 1, value.X);
					Class429.SendMessage_1(this.intptr_0, 1173, 2, value.Y);
					this.bool_0 = true;
				}
			}
		}

		public int ScrollPadding
		{
			get
			{
				if (this.intptr_0 != IntPtr.Zero)
				{
					Class429.Struct83 struct83_ = default(Class429.Struct83);
					Class429.SendMessage_3(this.intptr_0, 1192, 1, ref struct83_);
					return -struct83_.int_0;
				}
				return 0;
			}
		}

		public Size Size
		{
			get
			{
				return this.size_0;
			}
			set
			{
				this.size_0 = value;
				if (this.intptr_0 != IntPtr.Zero)
				{
					Class429.SetWindowPos(this.intptr_0, IntPtr.Zero, 0, 0, this.size_0.Width + 2, this.size_0.Height + 2, 30u);
				}
			}
		}

		[DefaultValue(100)]
		public int ZoomFactor
		{
			get
			{
				if (this.intptr_0 != IntPtr.Zero)
				{
					this.int_1 = Class429.SendMessage_1(this.intptr_0, 2038, 0, 0);
				}
				return this.int_1;
			}
			set
			{
				if (this.int_1 != value)
				{
					if (value < 10 || value > 65535)
					{
						throw new ArgumentOutOfRangeException();
					}
					this.int_1 = value;
					if (this.intptr_0 != IntPtr.Zero)
					{
						Class429.SendMessage_1(this.intptr_0, 2030, value, 0);
					}
				}
			}
		}

		public event EventHandler AutoHScroll
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event EventHandler AutoVScroll
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_1;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_1, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_1;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_1, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		public event ViewChangedEventHandler Changed
		{
			add
			{
				ViewChangedEventHandler viewChangedEventHandler = this.viewChangedEventHandler_0;
				ViewChangedEventHandler viewChangedEventHandler2;
				do
				{
					viewChangedEventHandler2 = viewChangedEventHandler;
					ViewChangedEventHandler value2 = (ViewChangedEventHandler)Delegate.Combine(viewChangedEventHandler2, value);
					viewChangedEventHandler = Interlocked.CompareExchange(ref this.viewChangedEventHandler_0, value2, viewChangedEventHandler2);
				}
				while ((object)viewChangedEventHandler != viewChangedEventHandler2);
			}
			remove
			{
				ViewChangedEventHandler viewChangedEventHandler = this.viewChangedEventHandler_0;
				ViewChangedEventHandler viewChangedEventHandler2;
				do
				{
					viewChangedEventHandler2 = viewChangedEventHandler;
					ViewChangedEventHandler value2 = (ViewChangedEventHandler)Delegate.Remove(viewChangedEventHandler2, value);
					viewChangedEventHandler = Interlocked.CompareExchange(ref this.viewChangedEventHandler_0, value2, viewChangedEventHandler2);
				}
				while ((object)viewChangedEventHandler != viewChangedEventHandler2);
			}
		}

		public event EventHandler Zoomed
		{
			add
			{
				EventHandler eventHandler = this.eventHandler_2;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_2, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler eventHandler = this.eventHandler_2;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_2, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		internal View(Type generatorType)
		{
			this.type_0 = generatorType;
		}

		internal void method_0(IntPtr intptr_1)
		{
			this.intptr_0 = intptr_1;
		}

		public CursorKind GetCursorKind(Point viewLocation)
		{
			if (this.intptr_0 != IntPtr.Zero)
			{
				return (CursorKind)Class429.SendMessage_1(this.intptr_0, 2064, 1, Class429.smethod_3(viewLocation.X, viewLocation.Y));
			}
			return CursorKind.IBeam;
		}

		public Bitmap GetImage()
		{
			Bitmap bitmap = null;
			if (this.intptr_0 != IntPtr.Zero)
			{
				Class429.Struct83 struct83_ = default(Class429.Struct83);
				Class429.GetClientRect(this.intptr_0, ref struct83_);
				bitmap = new Bitmap(struct83_.int_2 - struct83_.int_0, struct83_.int_3 - struct83_.int_1);
				Graphics graphics = Graphics.FromImage(bitmap);
				IntPtr hdc = graphics.GetHdc();
				if (this.type_0 == typeof(DialogViewGenerator))
				{
					Class429.SendMessage_1(this.intptr_0, 791, hdc.ToInt32(), 62);
				}
				else
				{
					Class429.SendMessage_1(this.intptr_0, 2033, hdc.ToInt32(), 0);
				}
				graphics.ReleaseHdc(hdc);
			}
			return bitmap;
		}

		public Bitmap GetImage(Rectangle clipRectangle)
		{
			Bitmap bitmap = null;
			if (this.intptr_0 != IntPtr.Zero)
			{
				if (this.type_0 == typeof(DialogViewGenerator))
				{
					Bitmap image = this.GetImage();
					bitmap = image.Clone(clipRectangle, image.PixelFormat);
					image.Dispose();
				}
				else
				{
					Class429.Struct83 struct83_ = new Class429.Struct83(clipRectangle);
					bitmap = new Bitmap(struct83_.int_2 - struct83_.int_0, struct83_.int_3 - struct83_.int_1);
					Graphics graphics = Graphics.FromImage(bitmap);
					IntPtr hdc = graphics.GetHdc();
					Class429.SendMessage_3(this.intptr_0, 2033, hdc.ToInt32(), ref struct83_);
					graphics.ReleaseHdc(hdc);
				}
			}
			return bitmap;
		}

		public bool GetImage(out byte[] arImage)
		{
			Bitmap image = this.GetImage();
			using (MemoryStream memoryStream = new MemoryStream())
			{
				image.Save(memoryStream, ImageFormat.Png);
				arImage = memoryStream.ToArray();
			}
			image.Dispose();
			return true;
		}

		public bool GetImage(out byte[] arImage, Rectangle clipRectangle)
		{
			Bitmap image = this.GetImage(clipRectangle);
			using (MemoryStream memoryStream = new MemoryStream())
			{
				image.Save(memoryStream, ImageFormat.Png);
				arImage = memoryStream.ToArray();
			}
			image.Dispose();
			return true;
		}

		public Rectangle GetUpdateRectangle(bool bValidate)
		{
			Rectangle result = default(Rectangle);
			if (this.intptr_0 != IntPtr.Zero)
			{
				Class429.Struct83 struct83_ = default(Class429.Struct83);
				if (this.type_0 == typeof(DialogViewGenerator))
				{
					Class429.GetClientRect(this.intptr_0, ref struct83_);
				}
				else
				{
					Class429.SendMessage_3(this.intptr_0, 2137, bValidate ? 1 : 0, ref struct83_);
				}
				return struct83_.method_0();
			}
			return result;
		}

		protected virtual void OnAutoHScroll(EventArgs eventArgs_0)
		{
			if (this.eventHandler_0 != null)
			{
				this.eventHandler_0(this, eventArgs_0);
			}
		}

		protected virtual void OnAutoVScroll(EventArgs eventArgs_0)
		{
			if (this.eventHandler_1 != null)
			{
				this.eventHandler_1(this, eventArgs_0);
			}
		}

		protected virtual void OnChanged(ViewChangedEventArgs viewChangedEventArgs_0)
		{
			if (this.viewChangedEventHandler_0 != null)
			{
				this.viewChangedEventHandler_0(this, viewChangedEventArgs_0);
			}
		}

		protected virtual void OnZoomed(EventArgs eventArgs_0)
		{
			if (this.eventHandler_2 != null)
			{
				this.eventHandler_2(this, eventArgs_0);
			}
		}

		internal void method_1(Enum84 enum84_0, uint uint_0)
		{
			switch (enum84_0)
			{
			case Enum84.const_25:
				if (this.bool_0)
				{
					this.OnAutoHScroll(EventArgs.Empty);
				}
				break;
			case Enum84.const_26:
				if (this.bool_0)
				{
					this.OnAutoVScroll(EventArgs.Empty);
				}
				break;
			case Enum84.const_15:
				this.OnZoomed(EventArgs.Empty);
				break;
			case Enum84.const_87:
				this.OnChanged(new ViewChangedEventArgs(this.intptr_0, bUpdateAll: false, ScrollOrientation.HorizontalScroll, (short)uint_0));
				break;
			case Enum84.const_88:
				this.OnChanged(new ViewChangedEventArgs(this.intptr_0, bUpdateAll: false, ScrollOrientation.VerticalScroll, (short)uint_0));
				break;
			case Enum84.const_78:
				this.OnChanged(new ViewChangedEventArgs(this.intptr_0, (this.type_0 == typeof(DialogViewGenerator)) ? true : false, ScrollOrientation.None, 0));
				break;
			}
		}
	}
}
