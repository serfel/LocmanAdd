using System;
using System.Windows.Forms;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal interface IEventHandlerService
	{
		Control FocusWindow { get; }

		event EventHandler EventHandlerChanged;

		object GetHandler(Type handlerType);

		void PopHandler(object handler);

		void PushHandler(object handler);
	}
}
