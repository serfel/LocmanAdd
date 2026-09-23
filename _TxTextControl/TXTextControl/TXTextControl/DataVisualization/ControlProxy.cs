using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using ns21;

namespace TXTextControl.DataVisualization
{
	internal abstract class ControlProxy
	{
		internal object m_Control;
		internal Type m_typeControl;
		private IntPtr m_hWnd = IntPtr.Zero;
		internal TextControlCore m_tx;
		internal object Component => this.m_Control;

		internal IntPtr Handle
		{
			get
			{
				PropertyInfo property = this.m_typeControl.GetProperty("Handle");
				if (property == null)
				{
					if (this.m_hWnd == IntPtr.Zero)
					{
						this.m_hWnd = Class429.CreateWindowEx(0u, "STATIC", "", 1073741824u, 0, 0, this.Width, this.Height, this.m_tx.IntPtr_0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero);
					}
					return this.m_hWnd;
				}
				return (IntPtr)property.GetValue(this.m_Control, null);				
			}
		}

		internal virtual int Height => (int)this.m_typeControl.GetProperty("Height").GetValue(this.m_Control, null);

		internal virtual int Width => (int)this.m_typeControl.GetProperty("Width").GetValue(this.m_Control, null);

		internal virtual Color ForeColor
		{
			get
			{
				return (Color)this.m_typeControl.GetProperty("ForeColor").GetValue(this.m_Control, null);
			}
			set
			{
				this.m_typeControl.GetProperty("ForeColor").SetValue(this.m_Control, value, null);
			}
		}

		internal string Text
		{
			get
			{
				return (string)this.m_typeControl.GetProperty("Text").GetValue(this.m_Control, null);
			}
			set
			{
				this.m_typeControl.GetProperty("Text").SetValue(this.m_Control, value, null);
			}
		}

		internal bool Visible
		{
			get
			{
				PropertyInfo property = this.m_typeControl.GetProperty("Visible");
				return (bool)property.GetValue(this.m_Control, null);
			}
			set
			{
				PropertyInfo property = this.m_typeControl.GetProperty("Visible");
				if (property != null)
				{
					property.SetValue(this.m_Control, value, null);
				}
			}
		}

		internal abstract void Load(Stream stream);

		internal abstract void Save(Stream stream);

		internal abstract void SaveImage(Stream stream, ImageFormat format);

		internal abstract void PrintPaint(Graphics graphics, Rectangle position);

		internal void CreateControl()
		{
			MethodInfo method = this.m_typeControl.GetMethod("CreateControl", Type.EmptyTypes);
			if (method != null)
			{
				method.Invoke(this.m_Control, null);				
			}
		}

		internal void Dispose()
		{
			if (this.m_hWnd != IntPtr.Zero)
			{
				Class429.DestroyWindow(this.m_hWnd);
				this.m_hWnd = IntPtr.Zero;
			}
			if (this.m_Control != null)
			{
				(this.m_Control as Component)?.Dispose();
			}
		}
	}
}
