using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using Microsoft.Win32;

namespace ns16
{
	internal sealed class Class166 : IDisposable, IComponent
	{
		[CompilerGenerated]
		private EventHandler eventHandler_0;

		private Form form_0;

		public ISite Site
		{
			get
			{
				return this.form_0.Site;
			}
			set
			{
			}
		}

		public event EventHandler Disposed
		{
			[CompilerGenerated]
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
			[CompilerGenerated]
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

		public Class166(Form form_1)
		{
			SystemEvents.UserPreferenceChanged += method_0;
			this.form_0 = form_1;
		}

		~Class166()
		{
			this.method_1(bool_0: false);
		}

		public void Dispose()
		{
			this.method_1(bool_0: true);
			GC.SuppressFinalize(this);
		}

		private void method_0(object sender, UserPreferenceChangedEventArgs e)
		{
			IUIService iUIService = ((this.form_0.Site != null) ? (this.form_0.Site.GetService(typeof(IUIService)) as IUIService) : null);
			if (iUIService != null)
			{
				Font font = iUIService.Styles["DialogFont"] as Font;
				if (font != null)
				{
					this.form_0.Font = font;
				}
			}
		}

		private void method_1(bool bool_0)
		{
			if (bool_0)
			{
				SystemEvents.UserPreferenceChanged -= method_0;
				if (this.eventHandler_0 != null)
				{
					this.eventHandler_0(this, EventArgs.Empty);
				}
			}
		}
	}
}
