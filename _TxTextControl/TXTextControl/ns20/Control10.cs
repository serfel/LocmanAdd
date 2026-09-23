using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Reflection;
using TXTextControl.DataVisualization;

namespace ns20
{
	internal class Control10 : ControlProxy
	{
		internal Type type_0;

		internal Type type_1;

		internal Type type_2;

		internal virtual Color BackColor
		{
			get
			{
				return (Color)base.m_typeControl.GetProperty("BackColor").GetValue(base.m_Control, null);
			}
			set
			{
				base.m_typeControl.GetProperty("BackColor").SetValue(base.m_Control, value, null);
			}
		}

		internal virtual Color BorderColor
		{
			get
			{
				return (Color)base.m_typeControl.GetProperty("BorderColor").GetValue(base.m_Control, null);
			}
			set
			{
				base.m_typeControl.GetProperty("BorderColor").SetValue(base.m_Control, value, null);
			}
		}

		internal int BorderWidth
		{
			get
			{
				return (int)base.m_typeControl.GetProperty("BorderWidth").GetValue(base.m_Control, null);
			}
			set
			{
				base.m_typeControl.GetProperty("BorderWidth").SetValue(base.m_Control, value, null);
			}
		}

		internal bool IsCanvasVisible => (bool)base.m_typeControl.GetProperty("IsCanvasVisible").GetValue(base.m_Control, null);

		internal int ZoomFactor
		{
			get
			{
				return (int)base.m_typeControl.GetProperty("ZoomFactor").GetValue(base.m_Control, null);
			}
			set
			{
				base.m_typeControl.GetProperty("ZoomFactor").SetValue(base.m_Control, value, null);
			}
		}

		internal Control10()
		{
		}

		internal Control10(object object_0)
		{
			this.method_0();
			base.m_Control = ((object_0 == null) ? Activator.CreateInstance(base.m_typeControl) : object_0);
		}

		private void method_0()
		{   
			base.m_typeControl = typeof(TXTextControl.Drawing.TXDrawingControl);
			this.type_0 = typeof(TXTextControl.Drawing.ShapeCollection);
			this.type_1 = typeof(TXTextControl.Drawing.Shape);
			this.type_2 = typeof(TXTextControl.Drawing.ViewChangedEventArgs);
		}

		internal override void Load(Stream stream)
		{
			object[] parameters = new object[1] { stream };
			Type[] types = new Type[1] { stream.GetType() };
			base.m_typeControl.GetMethod("Load", types).Invoke(base.m_Control, parameters);
		}

		internal override void Save(Stream stream)
		{
			object[] parameters = new object[1] { stream };
			Type[] types = new Type[1] { stream.GetType() };
			base.m_typeControl.GetMethod("Save", types).Invoke(base.m_Control, parameters);
		}

		internal override void SaveImage(Stream stream, ImageFormat format)
		{
			object[] parameters = new object[2] { stream, format };
			Type[] types = new Type[2]
			{
				stream.GetType(),
				format.GetType()
			};
			base.m_typeControl.GetMethod("SaveImage", types).Invoke(base.m_Control, parameters);
		}

		internal override void PrintPaint(Graphics graphics, Rectangle position)
		{
			object[] parameters = new object[2] { graphics, position };
			Type[] types = new Type[2]
			{
				graphics.GetType(),
				position.GetType()
			};
			base.m_typeControl.GetMethod("PrintPaint", types).Invoke(base.m_Control, parameters);
		}

		internal void PrintPaint(Graphics graphics_0, Rectangle rectangle_0, bool bool_0)
		{
			object[] parameters = new object[3] { graphics_0, rectangle_0, bool_0 };
			Type[] types = new Type[3]
			{
				graphics_0.GetType(),
				rectangle_0.GetType(),
				bool_0.GetType()
			};
			base.m_typeControl.GetMethod("PrintPaint", types).Invoke(base.m_Control, parameters);
		}

		internal void ClearUndo()
		{
			base.m_typeControl.GetMethod("ClearUndo").Invoke(base.m_Control, null);
		}

		internal int[] SizeToContent()
		{
			return (int[])base.m_typeControl.GetMethod("SizeToContent").Invoke(base.m_Control, null);
		}

		internal void SetCanvasSize(double double_0, double double_1)
		{
			object[] parameters = new object[2] { double_0, double_1 };
			base.m_typeControl.GetMethod("SetCanvasSize").Invoke(base.m_Control, parameters);
		}

		internal virtual Color vmethod_0()
		{
			object[] index = new object[1] { 0 };
			object value = base.m_typeControl.GetProperty("Shapes").GetValue(base.m_Control, null);
			object value2 = this.type_0.GetProperty("Item").GetValue(value, index);
			object value3 = this.type_1.GetProperty("ShapeFill").GetValue(value2, null);
			return (Color)value3.GetType().GetProperty("Color").GetValue(value3, null);
		}

		internal virtual bool vmethod_1(Color color_0)
		{
			bool result = false;
			object[] index = new object[1] { 0 };
			object value = base.m_typeControl.GetProperty("Shapes").GetValue(base.m_Control, null);
			object value2 = this.type_0.GetProperty("Item").GetValue(value, index);
			object value3 = this.type_1.GetProperty("ShapeFill").GetValue(value2, null);
			PropertyInfo property = value3.GetType().GetProperty("Color");
			if ((Color)property.GetValue(value3, null) != color_0)
			{
				property.SetValue(value3, color_0, null);
				result = true;
			}
			return result;
		}

		internal virtual Color vmethod_2()
		{
			object[] index = new object[1] { 0 };
			object value = base.m_typeControl.GetProperty("Shapes").GetValue(base.m_Control, null);
			object value2 = this.type_0.GetProperty("Item").GetValue(value, index);
			object value3 = this.type_1.GetProperty("ShapeOutline").GetValue(value2, null);
			return (Color)value3.GetType().GetProperty("Color").GetValue(value3, null);
		}

		internal virtual bool vmethod_3(Color color_0)
		{
			bool result = false;
			object[] index = new object[1] { 0 };
			object value = base.m_typeControl.GetProperty("Shapes").GetValue(base.m_Control, null);
			object value2 = this.type_0.GetProperty("Item").GetValue(value, index);
			object value3 = this.type_1.GetProperty("ShapeOutline").GetValue(value2, null);
			PropertyInfo property = value3.GetType().GetProperty("Color");
			if ((Color)property.GetValue(value3, null) != color_0)
			{
				property.SetValue(value3, color_0, null);
				result = true;
			}
			return result;
		}

		internal int method_5()
		{
			object[] index = new object[1] { 0 };
			object value = base.m_typeControl.GetProperty("Shapes").GetValue(base.m_Control, null);
			object value2 = this.type_0.GetProperty("Item").GetValue(value, index);
			object value3 = this.type_1.GetProperty("ShapeOutline").GetValue(value2, null);
			return (int)value3.GetType().GetProperty("Width").GetValue(value3, null);
		}

		internal bool method_6(int int_0)
		{
			bool result = false;
			object[] index = new object[1] { 0 };
			object value = base.m_typeControl.GetProperty("Shapes").GetValue(base.m_Control, null);
			object value2 = this.type_0.GetProperty("Item").GetValue(value, index);
			object value3 = this.type_1.GetProperty("ShapeOutline").GetValue(value2, null);
			PropertyInfo property = value3.GetType().GetProperty("Width");
			if ((int)property.GetValue(value3, null) != int_0)
			{
				property.SetValue(value3, int_0, null);
				result = true;
			}
			return result;
		}

		internal int method_7()
		{
			object[] index = new object[1] { 0 };
			object value = base.m_typeControl.GetProperty("Shapes").GetValue(base.m_Control, null);
			object value2 = this.type_0.GetProperty("Item").GetValue(value, index);
			return (int)this.type_1.GetProperty("Angle").GetValue(value2, null);
		}

		internal bool method_8(int int_0)
		{
			bool result = false;
			object[] index = new object[1] { 0 };
			object value = base.m_typeControl.GetProperty("Shapes").GetValue(base.m_Control, null);
			object value2 = this.type_0.GetProperty("Item").GetValue(value, index);
			PropertyInfo property = this.type_1.GetProperty("Angle");
			if ((int)property.GetValue(value2, null) != int_0)
			{
				property.SetValue(value2, int_0, null);
				result = true;
			}
			return result;
		}

		internal int method_9()
		{
			object[] index = new object[1] { 0 };
			object value = base.m_typeControl.GetProperty("Shapes").GetValue(base.m_Control, null);
			object value2 = this.type_0.GetProperty("Item").GetValue(value, index);
			return (int)this.type_1.GetProperty("Flip").GetValue(value2, null);
		}

		internal bool method_10(int int_0)
		{
			bool result = false;
			object[] index = new object[1] { 0 };
			object value = base.m_typeControl.GetProperty("Shapes").GetValue(base.m_Control, null);
			object value2 = this.type_0.GetProperty("Item").GetValue(value, index);
			PropertyInfo property = this.type_1.GetProperty("Flip");
			if (int_0 == 0)
			{
				int_0 = 4;
			}
			if ((int)property.GetValue(value2, null) != int_0)
			{
				property.SetValue(value2, int_0, null);
				result = true;
			}
			return result;
		}

		internal Rectangle ClipRectangle(EventArgs eventArgs_0)
		{
			if (eventArgs_0.GetType() == this.type_2)
			{
				return (Rectangle)this.type_2.GetProperty("ClipRectangle").GetValue(eventArgs_0, null);
			}
			return Rectangle.Empty;
		}

		internal void method_12(EventHandler eventHandler_0)
		{
			base.m_typeControl.GetEvent("Changed").AddEventHandler(base.m_Control, eventHandler_0);
		}

		internal void method_13(EventHandler eventHandler_0)
		{
			base.m_typeControl.GetEvent("Changed").RemoveEventHandler(base.m_Control, eventHandler_0);
		}

		internal void method_14(EventHandler eventHandler_0)
		{
			base.m_typeControl.GetEvent("AdaptBounds").AddEventHandler(base.m_Control, eventHandler_0);
		}

		internal void method_15(EventHandler eventHandler_0)
		{
			base.m_typeControl.GetEvent("AdaptBounds").RemoveEventHandler(base.m_Control, eventHandler_0);
		}

		internal void method_16(object object_0, MethodInfo methodInfo_0)
		{
			EventInfo @event = base.m_typeControl.GetEvent("ViewChanged");
			Delegate handler = Delegate.CreateDelegate(@event.EventHandlerType, object_0, methodInfo_0);
			@event.AddEventHandler(base.m_Control, handler);
		}

		internal void method_17(object object_0, MethodInfo methodInfo_0)
		{
			EventInfo @event = base.m_typeControl.GetEvent("ViewChanged");
			Delegate handler = Delegate.CreateDelegate(@event.EventHandlerType, object_0, methodInfo_0);
			@event.RemoveEventHandler(base.m_Control, handler);
		}
	}
}
