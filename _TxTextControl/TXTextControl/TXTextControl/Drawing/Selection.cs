using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Resources;
using System.Threading;
using ns17;

namespace TXTextControl.Drawing
{
	/// <summary>The Drawing.Selection class represents all selected shapes.</summary>
	public class Selection : INotifyPropertyChanged
	{
		/// <summary>Determines a certain shape class attribute.</summary>
		public enum Attribute
		{
			/// <summary>Specifies the attribute set through the Shape.Angle property.</summary>
			Angle,
			/// <summary>Specifies the attribute set through the Shape.AutoSize property.</summary>
			AutoSize,
			/// <summary>Specifies the attribute set through the Shape.CanFitToCanvas property.</summary>
			CanFitToCanvas,
			/// <summary>Specifies the attribute set through the Shape.ShapeFill.Color property.</summary>
			FillColor,
			/// <summary>Specifies the horizontal attribute set through the Shape.Flip property.</summary>
			FlipHorizontal,
			/// <summary>Specifies the vertical attribute set through the Shape.Flip property.</summary>
			FlipVertical,
			/// <summary>Specifies the attribute set through the Shape.Movable property.</summary>
			Movable,
			/// <summary>Specifies the attribute set through the Shape.ShapeOutline.Color property.</summary>
			LineColor,
			/// <summary>Specifies the attribute set through the Shape.ShapeOutline.Width property.</summary>
			LineWidth,
			/// <summary>Specifies the x attribute set through the Shape.Location.X property.</summary>
			LocationX,
			/// <summary>Specifies the y attribute set through the Shape.Location.Y property.</summary>
			LocationY,
			/// <summary>Specifies the attribute set through the Shape.Sizable property.</summary>
			Sizable,
			/// <summary>Specifies the height attribute set through the Shape.Size.Height property.</summary>
			SizeHeight,
			/// <summary>Specifies the width attribute set through the Shape.Size.Width property.</summary>
			SizeWidth
		}

		internal class Class180 : IComparer<Shape>
		{
			public int Compare(Shape x, Shape y)
			{
				return x.Index.CompareTo(y.Index);
			}
		}

		internal class Class181 : IComparer<Shape>
		{
			public int Compare(Shape x, Shape y)
			{
				return y.Index.CompareTo(x.Index);
			}
		}

		private bool bool_0;

		private bool bool_1;

		private bool bool_2;

		private bool bool_3;

		private bool bool_4 = true;

		private bool bool_5 = true;

		private Class178 class178_0;

		private Class178 class178_1;

		private Class178 class178_2;

		private Class178 class178_3;

		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TXDrawing));

		private Shape[] shape_0 = new Shape[0];

		private Shape[] shape_1 = new Shape[0];

		private TXDrawing txdrawing_0;

		private PropertyChangedEventHandler propertyChangedEventHandler_0;

		/// <summary>Gets value that indicates whether the selected shapes' levels can be increased by one.</summary>
		public bool CanBringForward => this.bool_0;

		/// <summary>Gets value that indicates whether the selected shape can be displayed as the uppermost shape of all shapes.</summary>
		public bool CanBringToFront => this.bool_1;

		/// <summary>Gets value that indicates whether the selected shapes' levels can be decreased by one.</summary>
		public bool CanSendBackward => this.bool_2;

		/// <summary>Gets value that indicates whether the selected shape can be displayed as the lowest shape of all shapes.</summary>
		public bool CanSendToBack => this.bool_3;

		/// <summary>Gets or set the selected shapes .</summary>
		public Shape[] Shapes
		{
			get
			{
				return this.shape_0;
			}
			set
			{
				this.method_32();
				if (this.method_22(value))
				{
					this.txdrawing_0.method_18(bool_5: false, bool_6: true, bool_7: true, bool_8: true);
				}
			}
		}

		internal Class178 Class178_0
		{
			get
			{
				return this.class178_0;
			}
			set
			{
				this.class178_0 = value;
			}
		}

		internal bool Boolean_0 => this.bool_4;

		internal Class178 Class178_1 => this.class178_2;

		internal Shape[] Shape_0
		{
			get
			{
				return this.shape_0;
			}
			set
			{
				this.shape_0 = value;
			}
		}

		internal bool Boolean_1 => this.bool_5;

		internal Class178 Class178_2
		{
			get
			{
				return this.class178_3;
			}
			set
			{
				this.class178_3 = value;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged
		{
			add
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChangedEventHandler_0;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange(ref this.propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
				}
				while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
			}
			remove
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChangedEventHandler_0;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange(ref this.propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
				}
				while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
			}
		}

		internal Selection(TXDrawing kernel)
		{
			this.txdrawing_0 = kernel;
		}

		internal void method_0(bool bool_6)
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			flag3 = (flag = (flag2 = this.shape_1.Length != this.shape_0.Length));
			int num = 0;
			while (!flag3 && num < this.shape_1.Length)
			{
				flag3 = (flag = (flag2 = this.shape_0[num] != this.shape_1[num]));
				num++;
			}
			for (int i = 0; i < this.txdrawing_0.ShapeCollection_0.Count; i++)
			{
				bool flag4 = false;
				bool flag5 = false;
				Shape shape = this.txdrawing_0.ShapeCollection_0[i];
				if (shape.Class177_0 == null)
				{
					break;
				}
				bool flag6 = this.method_1(shape);
				bool flag7 = shape.ShapeType_0 != shape.Type;
				int num2 = 0;
				while (!flag7 && num2 < shape.Double_0.Length)
				{
					if (shape.Double_0[num2] == shape.Class174_0.Class172_0[num2].Value)
					{
						num2++;
						continue;
					}
					if (flag6)
					{
						flag3 = true;
					}
					flag = true;
					if (bool_6)
					{
						flag2 = true;
						this.txdrawing_0.method_3(shape);
					}
					break;
				}
				if (shape.Int32_0 != shape.Angle)
				{
					if (flag6)
					{
						flag3 = true;
					}
					flag = true;
					flag4 = true;
					flag2 = true;
					shape.vmethod_0("Angle");
				}
				if (shape.Boolean_0 != shape.AutoSize)
				{
					if (flag6)
					{
						flag3 = true;
					}
					flag = true;
					flag4 = true;
					flag2 = true;
					shape.vmethod_0("AutoSize");
				}
				if (shape.Boolean_1 != shape.CanFitToCanvas)
				{
					if (flag6)
					{
						flag3 = true;
					}
					flag = true;
					flag4 = true;
					shape.vmethod_0("CanFitToCanvas");
				}
				if (shape.Int32_1 != shape.Index)
				{
					if (flag6)
					{
						flag3 = true;
					}
					flag = true;
					flag4 = true;
					shape.vmethod_0("Index");
				}
				if (shape.Int32_2 != shape.ShapeFill.Color.ToArgb())
				{
					if (flag6)
					{
						flag3 = true;
					}
					flag = true;
					flag4 = true;
					flag2 = true;
					shape.ShapeFill.vmethod_0("Color");
				}
				if (shape.Flip_0 != shape.Flip)
				{
					if (flag6)
					{
						flag3 = true;
					}
					flag = true;
					shape.vmethod_0("Flip");
					if (bool_6)
					{
						flag2 = true;
						this.txdrawing_0.method_8(shape);
					}
				}
				if (shape.Boolean_2 != shape.IsSelected)
				{
					if (flag6)
					{
						flag3 = true;
					}
					if (bool_6)
					{
						if (shape.Boolean_2)
						{
							this.txdrawing_0.method_7(shape);
						}
						else
						{
							this.txdrawing_0.method_11(shape);
						}
					}
					flag = true;
					flag2 = true;
					shape.vmethod_0("IsSelected");
				}
				if (Math.Round(shape.Class177_0.Double_0, MidpointRounding.ToEven) != Math.Round(shape.Class174_0.Class178_1.Double_0, MidpointRounding.ToEven) || Math.Round(shape.Class177_0.Double_1, MidpointRounding.ToEven) != Math.Round(shape.Class174_0.Class178_1.Double_1, MidpointRounding.ToEven))
				{
					if (flag6)
					{
						flag3 = true;
					}
					flag = true;
					shape.vmethod_0("Location");
					flag5 = true;
					if (bool_6)
					{
						flag2 = true;
						this.txdrawing_0.method_10(shape);
					}
				}
				if (shape.Boolean_3 != shape.Movable)
				{
					if (flag6)
					{
						flag3 = true;
					}
					flag = true;
					flag4 = true;
					shape.vmethod_0("Movable");
				}
				if (shape.Int32_3 != shape.ShapeOutline.Color.ToArgb())
				{
					if (flag6)
					{
						flag3 = true;
					}
					flag = true;
					flag4 = true;
					flag2 = true;
					shape.ShapeOutline.vmethod_0("Color");
				}
				if (shape.Double_1 != (double)shape.ShapeOutline.Width)
				{
					if (flag6)
					{
						flag3 = true;
					}
					flag = true;
					flag4 = true;
					flag2 = true;
					shape.ShapeOutline.vmethod_0("Width");
				}
				if (shape.Boolean_4 != shape.Sizable)
				{
					if (flag6)
					{
						flag3 = true;
					}
					flag = true;
					flag4 = true;
					flag2 = true;
					shape.vmethod_0("Sizable");
				}
				if (Math.Round(shape.Class179_0.Double_1, MidpointRounding.ToEven) != Math.Round(shape.Class174_0.Class178_1.Double_3, MidpointRounding.ToEven) || Math.Round(shape.Class179_0.Double_0, MidpointRounding.ToEven) != Math.Round(shape.Class174_0.Class178_1.Double_2, MidpointRounding.ToEven))
				{
					if (flag6)
					{
						flag3 = true;
					}
					flag = true;
					shape.vmethod_0("Size");
					flag5 = true;
					if (bool_6)
					{
						flag2 = true;
						this.txdrawing_0.method_12(shape);
					}
				}
				if (flag7)
				{
					if (flag6)
					{
						flag3 = true;
					}
					flag = true;
					flag4 = true;
					flag2 = true;
					shape.vmethod_0("Type");
				}
				if (flag5)
				{
					shape.vmethod_0("Bounds");
				}
				if (flag4 && bool_6)
				{
					this.txdrawing_0.method_9(shape);
				}
			}
			if (this.txdrawing_0.method_22())
			{
				this.txdrawing_0.method_2("CanPaste");
			}
			if (this.txdrawing_0.method_21())
			{
				this.txdrawing_0.method_2("CanCopy");
			}
			this.method_27();
			this.method_29();
			if (flag3)
			{
				this.vmethod_0("Shapes");
			}
			if (flag)
			{
				this.txdrawing_0.method_1();
			}
			if (flag2)
			{
				this.txdrawing_0.method_13(Helper.GetBounds(this.shape_0, 100));
			}
		}

		internal virtual void vmethod_0(string string_0)
		{
			PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChangedEventHandler_0;
			if (propertyChangedEventHandler != null)
			{
				PropertyChangedEventArgs e = new PropertyChangedEventArgs(string_0);
				propertyChangedEventHandler(this, e);
			}
		}

		/// <summary>Increases the selected shapes' levels by one. The method has no effect if the CanBringForward property returns false.</summary>
		public void BringForward()
		{
			if (this.method_3())
			{
				this.txdrawing_0.method_18(bool_5: false, bool_6: true, bool_7: true, bool_8: true);
			}
		}

		/// <summary>Displays the selected shape as the uppermost shape of all shapes. The method has no effect if the CanBringToFront property returns false.</summary>
		public void BringToFront()
		{
			if (this.method_4())
			{
				this.txdrawing_0.method_18(bool_5: false, bool_6: true, bool_7: true, bool_8: true);
			}
		}

		public bool IsCommonValueSelected(Attribute attribute)
		{
			return attribute switch
			{
				Attribute.Angle => this.method_7(), 
				Attribute.AutoSize => this.method_8(), 
				Attribute.CanFitToCanvas => this.method_9(), 
				Attribute.FillColor => this.method_15(), 
				Attribute.FlipHorizontal => this.method_10(), 
				Attribute.FlipVertical => this.method_11(), 
				Attribute.Movable => this.method_14(), 
				Attribute.LineColor => this.method_16(), 
				Attribute.LineWidth => this.method_17(), 
				Attribute.LocationX => this.method_12(), 
				Attribute.LocationY => this.method_13(), 
				Attribute.Sizable => this.method_18(), 
				Attribute.SizeHeight => this.method_19(), 
				Attribute.SizeWidth => this.method_20(), 
				_ => false, 
			};
		}

		/// <summary>Decreases the selected shapes' levels by one. The method has no effect if the CanSendBackward property returns false.</summary>
		public void SendBackward()
		{
			if (this.method_5())
			{
				this.txdrawing_0.method_18(bool_5: false, bool_6: true, bool_7: true, bool_8: true);
			}
		}

		/// <summary>Displays the selected shape as the lowest shape of all shapes. The method has no effect if the CanSendToBack property returns false.</summary>
		public void SendToBack()
		{
			if (this.method_6())
			{
				this.txdrawing_0.method_18(bool_5: false, bool_6: true, bool_7: true, bool_8: true);
			}
		}

		internal bool method_1(Shape shape_2)
		{
			Shape[] array = this.shape_0;
			int num = 0;
			while (true)
			{
				if (num < array.Length)
				{
					Shape shape = array[num];
					if (shape == shape_2)
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}

		private void method_2()
		{
			if (this.method_23())
			{
				this.vmethod_0("CanBringForward");
			}
			if (this.method_24())
			{
				this.vmethod_0("CanBringToFront");
			}
			if (this.method_25())
			{
				this.vmethod_0("CanSendBackward");
			}
			if (this.method_26())
			{
				this.vmethod_0("CanSendToBack");
			}
		}

		internal bool method_3()
		{
			if (this.bool_0)
			{
				this.method_32();
				List<Shape> list = new List<Shape>(this.shape_0);
				list.Sort(new Class180());
				for (int num = list.Count - 1; num >= 0; num--)
				{
					int index = list[num].Index;
					this.txdrawing_0.ShapeCollection_0.method_3(index + 1, list[num]);
				}
				this.txdrawing_0.ShapeCollection_0.method_10();
				this.method_2();
				return true;
			}
			return false;
		}

		internal bool method_4()
		{
			if (this.bool_1)
			{
				this.method_32();
				this.txdrawing_0.ShapeCollection_0.method_3(this.txdrawing_0.ShapeCollection_0.Count - 1, this.shape_0[0]);
				this.txdrawing_0.ShapeCollection_0.method_8(this.shape_0[0]);
				this.method_2();
				return true;
			}
			return false;
		}

		internal bool method_5()
		{
			if (this.bool_2)
			{
				this.method_32();
				List<Shape> list = new List<Shape>(this.shape_0);
				list.Sort(new Class181());
				for (int num = list.Count - 1; num >= 0; num--)
				{
					int index = list[num].Index;
					this.txdrawing_0.ShapeCollection_0.method_3(index - 1, list[num]);
				}
				this.txdrawing_0.ShapeCollection_0.method_10();
				this.method_2();
				return true;
			}
			return false;
		}

		internal bool method_6()
		{
			if (this.bool_3)
			{
				this.method_32();
				this.txdrawing_0.ShapeCollection_0.method_3(0, this.shape_0[0]);
				this.txdrawing_0.ShapeCollection_0.method_8(this.shape_0[0]);
				this.method_2();
				return true;
			}
			return false;
		}

		private bool method_7()
		{
			if (this.shape_0.Length == 0)
			{
				throw new InvalidOperationException(this.resourceManager_0.GetString("ERR_NO_SHAPES_SELECTED"));
			}
			int angle = this.shape_0[0].Angle;
			int num = 1;
			while (true)
			{
				if (num < this.shape_0.Length)
				{
					if (angle != this.shape_0[num].Angle)
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}

		private bool method_8()
		{
			if (this.shape_0.Length == 0)
			{
				throw new InvalidOperationException(this.resourceManager_0.GetString("ERR_NO_SHAPES_SELECTED"));
			}
			bool autoSize = this.shape_0[0].AutoSize;
			int num = 1;
			while (true)
			{
				if (num < this.shape_0.Length)
				{
					if (autoSize != this.shape_0[num].AutoSize)
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}

		private bool method_9()
		{
			if (this.shape_0.Length == 0)
			{
				throw new InvalidOperationException(this.resourceManager_0.GetString("ERR_NO_SHAPES_SELECTED"));
			}
			bool canFitToCanvas = this.shape_0[0].CanFitToCanvas;
			int num = 1;
			while (true)
			{
				if (num < this.shape_0.Length)
				{
					if (canFitToCanvas != this.shape_0[num].CanFitToCanvas)
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}

		private bool method_10()
		{
			if (this.shape_0.Length == 0)
			{
				throw new InvalidOperationException(this.resourceManager_0.GetString("ERR_NO_SHAPES_SELECTED"));
			}
			bool flag = (this.shape_0[0].Flip & Flip.Horizontal) == Flip.Horizontal;
			int num = 1;
			while (true)
			{
				if (num < this.shape_0.Length)
				{
					bool flag2 = (this.shape_0[num].Flip & Flip.Horizontal) == Flip.Horizontal;
					if (flag != flag2)
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}

		private bool method_11()
		{
			if (this.shape_0.Length == 0)
			{
				throw new InvalidOperationException(this.resourceManager_0.GetString("ERR_NO_SHAPES_SELECTED"));
			}
			bool flag = (this.shape_0[0].Flip & Flip.Vertical) == Flip.Vertical;
			int num = 1;
			while (true)
			{
				if (num < this.shape_0.Length)
				{
					bool flag2 = (this.shape_0[num].Flip & Flip.Vertical) == Flip.Vertical;
					if (flag != flag2)
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}

		private bool method_12()
		{
			if (this.shape_0.Length == 0)
			{
				throw new InvalidOperationException(this.resourceManager_0.GetString("ERR_NO_SHAPES_SELECTED"));
			}
			double num = this.shape_0[0].Location.X;
			int num2 = 1;
			while (true)
			{
				if (num2 < this.shape_0.Length)
				{
					if (num != (double)this.shape_0[num2].Location.X)
					{
						break;
					}
					num2++;
					continue;
				}
				return true;
			}
			return false;
		}

		private bool method_13()
		{
			if (this.shape_0.Length == 0)
			{
				throw new InvalidOperationException(this.resourceManager_0.GetString("ERR_NO_SHAPES_SELECTED"));
			}
			double num = this.shape_0[0].Location.Y;
			int num2 = 1;
			while (true)
			{
				if (num2 < this.shape_0.Length)
				{
					if (num != (double)this.shape_0[num2].Location.Y)
					{
						break;
					}
					num2++;
					continue;
				}
				return true;
			}
			return false;
		}

		private bool method_14()
		{
			if (this.shape_0.Length == 0)
			{
				throw new InvalidOperationException(this.resourceManager_0.GetString("ERR_NO_SHAPES_SELECTED"));
			}
			bool movable = this.shape_0[0].Movable;
			int num = 1;
			while (true)
			{
				if (num < this.shape_0.Length)
				{
					if (movable != this.shape_0[num].Movable)
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}

		private bool method_15()
		{
			if (this.shape_0.Length == 0)
			{
				throw new InvalidOperationException(this.resourceManager_0.GetString("ERR_NO_SHAPES_SELECTED"));
			}
			int? num = null;
			_ = this.shape_0[0].ShapeFill.Color;
			num = this.shape_0[0].ShapeFill.Color.ToArgb();
			int num2 = 1;
			while (true)
			{
				if (num2 < this.shape_0.Length)
				{
					int? num3 = null;
					_ = this.shape_0[num2].ShapeFill.Color;
					num3 = this.shape_0[num2].ShapeFill.Color.ToArgb();
					if (num != num3)
					{
						break;
					}
					num2++;
					continue;
				}
				return true;
			}
			return false;
		}

		private bool method_16()
		{
			if (this.shape_0.Length == 0)
			{
				throw new InvalidOperationException(this.resourceManager_0.GetString("ERR_NO_SHAPES_SELECTED"));
			}
			int? num = null;
			_ = this.shape_0[0].ShapeOutline.Color;
			num = this.shape_0[0].ShapeOutline.Color.ToArgb();
			int num2 = 1;
			while (true)
			{
				if (num2 < this.shape_0.Length)
				{
					int? num3 = null;
					_ = this.shape_0[num2].ShapeOutline.Color;
					num3 = this.shape_0[num2].ShapeOutline.Color.ToArgb();
					if (num != num3)
					{
						break;
					}
					num2++;
					continue;
				}
				return true;
			}
			return false;
		}

		private bool method_17()
		{
			if (this.shape_0.Length == 0)
			{
				throw new InvalidOperationException(this.resourceManager_0.GetString("ERR_NO_SHAPES_SELECTED"));
			}
			double num = this.shape_0[0].ShapeOutline.Width;
			int num2 = 1;
			while (true)
			{
				if (num2 < this.shape_0.Length)
				{
					if (num != (double)this.shape_0[num2].ShapeOutline.Width)
					{
						break;
					}
					num2++;
					continue;
				}
				return true;
			}
			return false;
		}

		private bool method_18()
		{
			if (this.shape_0.Length == 0)
			{
				throw new InvalidOperationException(this.resourceManager_0.GetString("ERR_NO_SHAPES_SELECTED"));
			}
			bool sizable = this.shape_0[0].Sizable;
			int num = 1;
			while (true)
			{
				if (num < this.shape_0.Length)
				{
					if (sizable != this.shape_0[num].Sizable)
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}

		private bool method_19()
		{
			if (this.shape_0.Length == 0)
			{
				throw new InvalidOperationException(this.resourceManager_0.GetString("ERR_NO_SHAPES_SELECTED"));
			}
			double num = this.shape_0[0].Size.Height;
			int num2 = 1;
			while (true)
			{
				if (num2 < this.shape_0.Length)
				{
					if (num != (double)this.shape_0[num2].Size.Height)
					{
						break;
					}
					num2++;
					continue;
				}
				return true;
			}
			return false;
		}

		private bool method_20()
		{
			if (this.shape_0.Length == 0)
			{
				throw new InvalidOperationException(this.resourceManager_0.GetString("ERR_NO_SHAPES_SELECTED"));
			}
			double num = this.shape_0[0].Size.Width;
			int num2 = 1;
			while (true)
			{
				if (num2 < this.shape_0.Length)
				{
					if (num != (double)this.shape_0[num2].Size.Width)
					{
						break;
					}
					num2++;
					continue;
				}
				return true;
			}
			return false;
		}

		internal void method_21()
		{
			if (this.class178_0 != null)
			{
				List<Shape> list = new List<Shape>();
				Flip flip;
				Class178 @class = Helper.ConvertToValidBounds(this.class178_0, out flip);
				double double_ = @class.Double_9;
				double double_2 = @class.Double_11;
				double double_3 = @class.Double_10;
				double double_4 = @class.Double_8;
				foreach (Shape item in this.txdrawing_0.ShapeCollection_0)
				{
					if (item.Class174_0.Class178_1.Double_9 >= double_ && item.Class174_0.Class178_1.Double_11 >= double_2 && item.Class174_0.Class178_1.Double_10 <= double_3 && item.Class174_0.Class178_1.Double_8 <= double_4)
					{
						list.Add(item);
					}
				}
				this.method_22(list.ToArray());
			}
			else
			{
				this.method_22(new Shape[0]);
			}
		}

		internal bool method_22(Shape[] shape_2)
		{
			bool flag = false;
			if (shape_2 == null)
			{
				throw new ArgumentNullException();
			}
			if (flag = this.method_31(shape_2))
			{
				this.txdrawing_0.method_20();
			}
			this.method_2();
			return flag;
		}

		private bool method_23()
		{
			bool flag = true;
			if (this.shape_0.Length == 0)
			{
				flag = false;
			}
			else
			{
				Shape[] array = this.shape_0;
				foreach (Shape shape in array)
				{
					if (shape.Index == this.txdrawing_0.ShapeCollection_0.Count - 1)
					{
						flag = false;
						break;
					}
				}
			}
			return this.bool_0 != (this.bool_0 = flag);
		}

		private bool method_24()
		{
			bool flag = true;
			flag = this.shape_0.Length == 1 && this.shape_0[0].Index < this.txdrawing_0.ShapeCollection_0.Count - 1;
			return this.bool_1 != (this.bool_1 = flag);
		}

		private bool method_25()
		{
			bool flag = true;
			if (this.shape_0.Length == 0)
			{
				flag = false;
			}
			else
			{
				Shape[] array = this.shape_0;
				foreach (Shape shape in array)
				{
					if (shape.Index == 0)
					{
						flag = false;
					}
				}
			}
			return this.bool_2 != (this.bool_2 = flag);
		}

		private bool method_26()
		{
			bool flag = true;
			flag = this.shape_0.Length == 1 && this.shape_0[0].Index > 0;
			return this.bool_3 != (this.bool_3 = flag);
		}

		internal bool method_27()
		{
			Shape[] array = this.shape_0;
			int num = 0;
			while (true)
			{
				if (num < array.Length)
				{
					Shape shape = array[num];
					if (!shape.Movable)
					{
						break;
					}
					num++;
					continue;
				}
				this.bool_4 = true;
				return this.bool_4;
			}
			this.bool_4 = false;
			return this.bool_4;
		}

		internal void method_28()
		{
			this.class178_2 = Helper.GetBounds(this.shape_0, 100);
		}

		internal bool method_29()
		{
			Shape[] array = this.shape_0;
			int num = 0;
			while (true)
			{
				if (num < array.Length)
				{
					Shape shape = array[num];
					if (!shape.Sizable)
					{
						break;
					}
					num++;
					continue;
				}
				this.bool_5 = true;
				return this.bool_5;
			}
			this.bool_5 = false;
			return this.bool_5;
		}

		internal void method_30(Class178 class178_4)
		{
			if (this.class178_1 != null && class178_4 != null)
			{
				double num = Math.Min(class178_4.Double_9, this.class178_1.Double_9) - 225.0;
				double num2 = Math.Min(class178_4.Double_11, this.class178_1.Double_11) - 225.0;
				double num3 = Math.Max(class178_4.Double_10, this.class178_1.Double_10) + 225.0;
				double num4 = Math.Max(class178_4.Double_8, this.class178_1.Double_8) + 225.0;
				this.class178_3 = new Class178(num, num2, num3 - num, num4 - num2, bool_1: false);
				this.class178_1 = class178_4;
			}
			else if (class178_4 != null)
			{
				this.class178_3 = (this.class178_1 = class178_4);
			}
		}

		private bool method_31(Shape[] shape_2)
		{
			foreach (Shape item in this.txdrawing_0.ShapeCollection_0)
			{
				item.Boolean_2 = item.IsSelected;
				item.Boolean_6 = false;
			}
			foreach (Shape shape2 in shape_2)
			{
				shape2.Boolean_6 = true;
			}
			bool result = this.shape_0.Length != shape_2.Length;
			this.shape_0 = shape_2;
			foreach (Shape item2 in this.txdrawing_0.ShapeCollection_0)
			{
				if (item2.IsSelected != item2.Boolean_2)
				{
					result = true;
				}
			}
			return result;
		}

		internal void method_32()
		{
			this.shape_1 = this.shape_0;
			foreach (Shape item in this.txdrawing_0.ShapeCollection_0)
			{
				item.method_0();
			}
		}
	}
}
