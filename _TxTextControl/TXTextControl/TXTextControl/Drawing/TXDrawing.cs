using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Resources;
using ns17;

namespace TXTextControl.Drawing
{
	[Obfuscation(Exclude = true)]
	internal class TXDrawing
	{
		private Class173 class173_0;

		private bool bool_0 = true;

		private bool canCopy;

		private bool bool_2;

		private bool bool_3 = true;

		private Color[] color_0 = new Color[17]
		{
			ColorTranslator.FromHtml("#FFFFFF"),
			ColorTranslator.FromHtml("#C0C0C0"),
			ColorTranslator.FromHtml("#808080"),
			ColorTranslator.FromHtml("#404040"),
			ColorTranslator.FromHtml("#000000"),
			ColorTranslator.FromHtml("#0000FF"),
			ColorTranslator.FromHtml("#00FFFF"),
			ColorTranslator.FromHtml("#00FF00"),
			ColorTranslator.FromHtml("#FF00FF"),
			ColorTranslator.FromHtml("#FF0000"),
			ColorTranslator.FromHtml("#FFFF00"),
			ColorTranslator.FromHtml("#000080"),
			ColorTranslator.FromHtml("#008080"),
			ColorTranslator.FromHtml("#008000"),
			ColorTranslator.FromHtml("#800080"),
			ColorTranslator.FromHtml("#800000"),
			ColorTranslator.FromHtml("#808000")
		};

		private int int_0;

		private int int_1;

		private int int_2 = 100;

		private Class176 class176_0;

		private Class176 class176_1;

		private Class177 class177_0 = new Class177(-1.0, -1.0, bool_1: false);

		private Class178 class178_0 = new Class178(0.0, 0.0, 1134.0, 1134.0, bool_1: false);

		private Class178 class178_1 = new Class178(0.0, 0.0, 1134.0, 1134.0, bool_1: false);

		private Class179 class179_0 = new Class179(1134.0, 1134.0, bool_1: false);

		private bool bool_4;

		private object object_0;

		private MethodInfo methodInfo_0;

		private MethodInfo methodInfo_1;

		private MethodInfo methodInfo_2;

		private MethodInfo methodInfo_3;

		private MethodInfo methodInfo_4;

		private MethodInfo methodInfo_5;

		private MethodInfo methodInfo_6;

		private MethodInfo methodInfo_7;

		private MethodInfo methodInfo_8;

		private MethodInfo methodInfo_9;

		private MethodInfo methodInfo_10;

		private MethodInfo methodInfo_11;

		private MethodInfo methodInfo_12;

		private MethodInfo methodInfo_13;

		private MethodInfo methodInfo_14;

		private MethodInfo methodInfo_15;

		private MethodInfo methodInfo_16;

		private MethodInfo methodInfo_17;

		private MethodInfo methodInfo_18;

		private MethodInfo methodInfo_19;

		private MethodInfo methodInfo_20;

		private MemoryStream memoryStream_0;

		private Enum36 enum36_0 = Enum36.const_4;

		private PropertyInfo propertyInfo_0;

		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TXDrawing));

		private Enum37 enum37_0 = Enum37.const_0;

		private Selection selection_0;

		private Shape shape_0;

		private ShapeCollection shapeCollection_0;

		private Class371 class371_0;

		internal Class176 BackColor
		{
			get
			{
				return this.class176_0;
			}
			set
			{
				bool flag = false;
				if (this.class176_0 != null && value != null)
				{
					if (flag = this.class176_0.method_0() != (this.class176_0 = value).method_0())
					{
						this.method_2("BackColor");
					}
				}
				else if (flag = this.class176_0 != (this.class176_0 = value))
				{
					this.method_2("BackColor");
				}
				if (flag)
				{
					this.method_1();
				}
			}
		}

		internal Class176 BorderColor
		{
			get
			{
				return this.class176_1;
			}
			set
			{
				bool flag = false;
				if (this.class176_1 != null && value != null)
				{
					if (flag = this.class176_1.method_0() != (this.class176_1 = value).method_0())
					{
						this.method_2("BorderColor");
					}
				}
				else if (flag = this.class176_1 != (this.class176_1 = value))
				{
					this.method_2("BorderColor");
				}
				if (flag)
				{
					this.method_1();
				}
			}
		}

		internal int BorderWidth
		{
			get
			{
				return this.int_1;
			}
			set
			{
				bool flag = false;
				if (flag = this.int_1 != (this.int_1 = value))
				{
					this.method_2("BorderWidth");
				}
				if (this.class178_1 != null)
				{
					this.method_23();
					int enum30_ = 476;
					foreach (Shape item in this.shapeCollection_0)
					{
						item.Class174_0.method_1((Class174.Enum30)enum30_);
					}
				}
				if (flag)
				{
					this.method_1();
				}
			}
		}

		internal bool CanCopy => this.canCopy;

		internal bool Boolean_1 => this.memoryStream_0 != null;

		internal bool Boolean_2 => this.class371_0.Boolean_0;

		internal bool Boolean_3 => this.class371_0.Boolean_1;

		internal bool IsCanvasVisible
		{
			get
			{
				return this.bool_3;
			}
			set
			{
				if (this.bool_3 != (this.bool_3 = value))
				{
					this.method_2("IsCanvasVisible");
				}
			}
		}

		internal Selection Selection_0 => this.selection_0;

		internal ShapeCollection ShapeCollection_0 => this.shapeCollection_0;

		internal int ZoomFactor
		{
			get
			{
				return this.int_2;
			}
			set
			{
				bool flag = false;
				if (value < 10)
				{
					flag = 10 != this.int_2;
					this.int_2 = 10;
				}
				else if (value > 65535)
				{
					flag = 65535 != this.int_2;
					this.int_2 = 65535;
				}
				else
				{
					flag = value != this.int_2;
					this.int_2 = value;
				}
				if (flag)
				{
					this.method_2("ZoomFactor");
				}
			}
		}

		internal bool Boolean_5
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

		internal Class176 Class176_2
		{
			get
			{
				return this.class176_0;
			}
			set
			{
				this.class176_0 = value;
			}
		}

		internal Class176 Class176_3
		{
			get
			{
				return this.class176_1;
			}
			set
			{
				this.class176_1 = value;
			}
		}

		internal int Int32_2
		{
			get
			{
				return this.int_1;
			}
			set
			{
				this.int_1 = value;
			}
		}

		internal Class178 Class178_0 => this.class178_0;

		internal int Int32_3
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}

		internal Class178 Class178_1
		{
			get
			{
				return this.class178_1;
			}
			set
			{
				this.class178_1 = value;
				this.method_23();
			}
		}

		internal Class179 Class179_0
		{
			get
			{
				return this.class179_0;
			}
			set
			{
				this.class179_0 = value;
			}
		}

		internal MemoryStream MemoryStream_0
		{
			get
			{
				return this.memoryStream_0;
			}
			set
			{
				this.memoryStream_0 = value;
			}
		}

		internal Enum36 Enum36_0
		{
			get
			{
				return this.enum36_0;
			}
			set
			{
				this.enum36_0 = value;
			}
		}

		internal Color[] Color_0 => this.color_0;

		internal Enum37 Enum37_0
		{
			get
			{
				return this.enum37_0;
			}
			set
			{
				this.enum37_0 = value;
			}
		}

		internal bool Boolean_6 => (bool)this.propertyInfo_0.GetValue(this.object_0, null);

		internal TXDrawing(object control)
		{
			this.method_76(control);
			this.shapeCollection_0 = new ShapeCollection(this);
			this.selection_0 = new Selection(this);
			this.class176_0 = (this.bool_4 ? Class176.smethod_3("Transparent") : Converter.ColorToInternal(Color.Transparent));
			this.class176_1 = (this.bool_4 ? Class176.smethod_3("WindowTextColor") : Converter.ColorToInternal(SystemColors.WindowText));
			this.class371_0 = new Class371(this);
		}

		internal bool method_0()
		{
			return (bool)this.methodInfo_2.Invoke(this.object_0, null);
		}

		internal void method_1()
		{
			if (this.bool_0)
			{
				this.method_84();
			}
			this.method_78();
			this.methodInfo_3.Invoke(this.object_0, null);
		}

		internal void method_2(string string_0)
		{
			this.methodInfo_5.Invoke(this.object_0, new object[1] { string_0 });
		}

		internal void method_3(Shape shape_1)
		{
			this.methodInfo_6.Invoke(this.object_0, new object[1] { shape_1 });
		}

		internal void method_4(Shape shape_1)
		{
			this.methodInfo_7.Invoke(this.object_0, new object[1] { shape_1 });
		}

		internal void method_5(Shape shape_1)
		{
			this.methodInfo_8.Invoke(this.object_0, new object[1] { shape_1 });
		}

		internal void method_6(Shape shape_1)
		{
			this.methodInfo_9.Invoke(this.object_0, new object[1] { shape_1 });
		}

		internal void method_7(Shape shape_1)
		{
			this.methodInfo_10.Invoke(this.object_0, new object[1] { shape_1 });
		}

		internal void method_8(Shape shape_1)
		{
			this.methodInfo_11.Invoke(this.object_0, new object[1] { shape_1 });
		}

		internal void method_9(Shape shape_1)
		{
			this.methodInfo_12.Invoke(this.object_0, new object[1] { shape_1 });
		}

		internal void method_10(Shape shape_1)
		{
			this.methodInfo_13.Invoke(this.object_0, new object[1] { shape_1 });
		}

		internal void method_11(Shape shape_1)
		{
			this.methodInfo_14.Invoke(this.object_0, new object[1] { shape_1 });
		}

		internal void method_12(Shape shape_1)
		{
			this.methodInfo_15.Invoke(this.object_0, new object[1] { shape_1 });
		}

		internal void method_13(Class178 class178_2)
		{
			this.selection_0.method_30(class178_2);
			this.methodInfo_4.Invoke(this.object_0, new object[1] { this.selection_0.Class178_2 });
		}

		internal void method_14(MemoryStream memoryStream_1)
		{
			Shape[] array = new Shape[this.selection_0.Shapes.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = this.selection_0.Shapes[i];
			}
			Serializer.Save(this, memoryStream_1, SerializationFormat.Xml, array, isWPC: true, 0);
		}

		internal bool method_15()
		{
			if (this.canCopy)
			{
				this.memoryStream_0 = new MemoryStream();
				this.method_14(this.memoryStream_0);
				this.shapeCollection_0.method_7();
				return true;
			}
			return false;
		}

		internal void method_16(MemoryStream memoryStream_1)
		{
			this.selection_0.method_32();
			memoryStream_1.Position = 0L;
			Serializer.Load(memoryStream_1, SerializationFormat.Xml, out var shapes, this, addShapeOffset: false);
			Shape[] array = new Shape[shapes.Length];
			for (int i = 0; i < shapes.Length; i++)
			{
				Shape shape = shapes[i];
				shape.Double_0 = shape.Class174_0.Class172_0.Double_0;
				array[i] = shape;
				shape.Boolean_9 = false;
				this.shapeCollection_0.method_2(shape, ShapeCollection.AddStyle.None);
				shape.method_0();
				shape.Boolean_6 = false;
			}
			this.shapeCollection_0.method_10();
			this.selection_0.method_22(array);
		}

		internal bool method_17()
		{
			this.Selection_0.method_32();
			Shape[] array = new Shape[this.ShapeCollection_0.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = this.ShapeCollection_0[i];
			}
			return this.Selection_0.method_22(array);
		}

		internal void method_18(bool bool_5, bool bool_6, bool bool_7, bool bool_8)
		{
			if (bool_5)
			{
				this.method_0();
			}
			if (bool_6)
			{
				this.method_78();
				this.method_77();
			}
			if (bool_7)
			{
				this.selection_0.method_0(bool_8);
			}
		}

		internal string method_19(string string_0, Color color_1)
		{
			return color_1.Name.ToUpper() switch
			{
				"FFFFFFFF" => this.resourceManager_0.GetString(string_0 + "WHITE"), 
				"FFC0C0C0" => this.resourceManager_0.GetString(string_0 + "LIGHTGRAY"), 
				"FF808080" => this.resourceManager_0.GetString(string_0 + "GRAY"), 
				"FF404040" => this.resourceManager_0.GetString(string_0 + "DARKGRAY"), 
				"FF000000" => this.resourceManager_0.GetString(string_0 + "BLACK"), 
				"FF0000FF" => this.resourceManager_0.GetString(string_0 + "BLUE"), 
				"FF00FFFF" => this.resourceManager_0.GetString(string_0 + "AQUA"), 
				"FF00FF00" => this.resourceManager_0.GetString(string_0 + "LIME"), 
				"FFFF00FF" => this.resourceManager_0.GetString(string_0 + "FUCHSIA"), 
				"FFFF0000" => this.resourceManager_0.GetString(string_0 + "RED"), 
				"FFFFFF00" => this.resourceManager_0.GetString(string_0 + "YELLOW"), 
				"FF000080" => this.resourceManager_0.GetString(string_0 + "NAVY"), 
				"FF008080" => this.resourceManager_0.GetString(string_0 + "TEAL"), 
				"FF008000" => this.resourceManager_0.GetString(string_0 + "GREEN"), 
				"FF800080" => this.resourceManager_0.GetString(string_0 + "PURPLE"), 
				"FF800000" => this.resourceManager_0.GetString(string_0 + "MAROON"), 
				"FF808000" => this.resourceManager_0.GetString(string_0 + "OLIVE"), 
				_ => this.resourceManager_0.GetString(string_0 + "OTHER"), 
			};
		}

		internal void method_20()
		{
			if (this.selection_0.Shapes.Length == 1)
			{
				this.shapeCollection_0.method_8(this.selection_0.Shapes[0]);
			}
			else
			{
				this.shapeCollection_0.method_8(null);
			}
		}

		internal bool method_21()
		{
			bool flag = this.selection_0.Shapes.Length > 0;
			return this.canCopy != (this.canCopy = flag);
		}

		internal bool method_22()
		{
			bool flag = this.memoryStream_0 != null;
			return this.bool_2 != (this.bool_2 = flag);
		}

		private void method_23()
		{
			double double_ = (double)this.int_1 / 2.0;
			double double_2 = (double)this.int_1 / 2.0;
			double double_3 = this.class178_1.Double_3 - (double)this.int_1;
			double double_4 = this.class178_1.Double_2 - (double)this.int_1;
			this.class178_0 = new Class178(double_, double_2, double_3, double_4, bool_1: false);
		}

		internal void method_24(Class177 class177_1, object object_1)
		{
			this.class177_0 = class177_1;
			this.method_79(object_1);
			if (!this.shapeCollection_0.Boolean_1)
			{
				Class177 class177_2 = (this.bool_4 ? new Class177(class177_1.Double_0 * 15.0, class177_1.Double_1 * 15.0, bool_1: false) : new Class177(MeasuringHelper.Pixel2Twips(class177_1.Double_0, 100), MeasuringHelper.Pixel2Twips(class177_1.Double_1, 100), bool_1: false));
				this.method_32(class177_2, class177_1);
				this.selection_0.method_32();
				if ((this.enum36_0 & Enum36.const_0) == Enum36.const_0)
				{
					this.method_25(class177_2);
				}
				else if ((this.enum36_0 & Enum36.const_1) == Enum36.const_1)
				{
					this.method_30();
				}
			}
			else
			{
				this.selection_0.method_32();
			}
		}

		private void method_25(Class177 class177_1)
		{
			if (!this.method_31())
			{
				if (this.shape_0 == null)
				{
					this.enum37_0 = Enum37.const_0;
					this.selection_0.method_22(new Shape[0]);
				}
				else if ((this.enum36_0 & Enum36.const_2) != Enum36.const_2 && (this.enum36_0 & Enum36.const_5) != Enum36.const_5)
				{
					this.method_28();
				}
				else
				{
					this.method_26();
				}
				if ((this.enum37_0 & Enum37.const_0) != Enum37.const_0)
				{
					this.method_29(class177_1);
				}
			}
		}

		private void method_26()
		{
			if (!this.selection_0.method_1(this.shape_0))
			{
				this.method_27();
				if ((this.enum36_0 & Enum36.const_2) == Enum36.const_2)
				{
					this.enum37_0 = (Enum37)66;
				}
				else
				{
					this.enum37_0 = Enum37.const_1;
				}
			}
			else
			{
				this.enum37_0 = (Enum37)98;
			}
		}

		private void method_27()
		{
			Shape[] array = new Shape[this.selection_0.Shapes.Length + 1];
			for (int i = 0; i < this.selection_0.Shapes.Length; i++)
			{
				array[i] = this.selection_0.Shapes[i];
			}
			array[this.selection_0.Shapes.Length] = this.shape_0;
			this.selection_0.method_22(array);
		}

		private void method_28()
		{
			if (this.selection_0.method_1(this.shape_0))
			{
				this.enum37_0 = (Enum37)18;
				return;
			}
			if (this.selection_0.method_22(new Shape[1] { this.shape_0 }))
			{
				this.method_18(bool_5: false, bool_6: true, bool_7: true, bool_8: true);
			}
			this.enum37_0 = Enum37.const_1;
		}

		private void method_29(Class177 class177_1)
		{
			Class177 @class = new Class177(MeasuringHelper.ZoomValue(class177_1.Double_0, this.ZoomFactor, viseVersa: true), MeasuringHelper.ZoomValue(class177_1.Double_1, this.ZoomFactor, viseVersa: true), bool_1: false);
			Shape[] shapes = this.selection_0.Shapes;
			foreach (Shape shape in shapes)
			{
				shape.Class174_0.Class177_4 = new Class177((double)shape.Location.X - @class.Double_0, (double)shape.Location.Y - @class.Double_1, bool_1: false);
			}
		}

		private void method_30()
		{
			if (!this.method_31())
			{
				if (this.shape_0 == null)
				{
					this.enum37_0 = Enum37.const_0;
					this.selection_0.method_22(new Shape[0]);
				}
				else if (!this.selection_0.method_1(this.shape_0))
				{
					this.selection_0.method_22(new Shape[1] { this.shape_0 });
				}
			}
		}

		private bool method_31()
		{
			if (this.class173_0 != null)
			{
				this.enum37_0 = Enum37.const_3;
				return true;
			}
			if (this.shape_0 != null && this.shape_0.Class174_0.Enum31_0 != Class174.Enum31.const_9 && this.shape_0.Class174_0.Enum31_0 != Class174.Enum31.const_8)
			{
				this.enum37_0 = Enum37.const_2;
				return true;
			}
			return false;
		}

		internal Enum34 method_32(Class177 class177_1, Class177 class177_2)
		{
			this.shape_0 = null;
			this.class173_0 = null;
			this.method_33();
			if (this.selection_0.Shapes.Length == 1 && this.method_34(class177_1))
			{
				return Enum34.const_0;
			}
			Enum34 result;
			if ((result = this.method_35(class177_1)) != 0)
			{
				return result;
			}
			return this.method_36(class177_2);
		}

		private void method_33()
		{
			foreach (Shape item in this.ShapeCollection_0)
			{
				item.Class174_0.Enum31_0 = Class174.Enum31.const_9;
			}
		}

		private bool method_34(Class177 class177_1)
		{
			Class177 rotationCenter = new Class177(MeasuringHelper.ZoomValue(this.selection_0.Shapes[0].Class174_0.Class177_5.Double_0, this.ZoomFactor, viseVersa: false), MeasuringHelper.ZoomValue(this.selection_0.Shapes[0].Class174_0.Class177_5.Double_1, this.ZoomFactor, viseVersa: false), bool_1: false);
			Class177 @class = MeasuringHelper.ConsiderAngle(class177_1, rotationCenter, -this.selection_0.Shapes[0].Angle);
			bool flag = (this.selection_0.Shapes[0].Flip & Flip.Horizontal) == Flip.Horizontal;
			bool flag2 = (this.selection_0.Shapes[0].Flip & Flip.Vertical) == Flip.Vertical;
			double num = MeasuringHelper.ZoomValue(this.selection_0.Shapes[0].Class174_0.Class178_1.Double_0, this.ZoomFactor, viseVersa: false);
			double num2 = MeasuringHelper.ZoomValue(this.selection_0.Shapes[0].Class174_0.Class178_1.Double_1, this.ZoomFactor, viseVersa: false);
			double num3 = MeasuringHelper.ZoomValue(this.selection_0.Shapes[0].Class174_0.Class178_1.Double_3, this.ZoomFactor, viseVersa: false);
			double num4 = MeasuringHelper.ZoomValue(this.selection_0.Shapes[0].Class174_0.Class178_1.Double_2, this.ZoomFactor, viseVersa: false);
			double double_ = (flag ? (num + (num3 - (@class.Double_0 - num))) : @class.Double_0);
			double double_2 = (flag2 ? (num2 + (num4 - (@class.Double_1 - num2))) : @class.Double_1);
			if ((this.class173_0 = this.selection_0.Shapes[0].Class174_0.Class172_0.method_1(new Class177(double_, double_2, bool_1: false))) != null)
			{
				this.shape_0 = this.selection_0.Shapes[0];
				return true;
			}
			return false;
		}

		private Enum34 method_35(Class177 class177_1)
		{
			Shape[] shapes = this.selection_0.Shapes;
			int num = 0;
			Shape shape;
			while (true)
			{
				if (num < shapes.Length)
				{
					shape = shapes[num];
					Class177 rotationCenter = new Class177(MeasuringHelper.ZoomValue(shape.Class174_0.Class177_5.Double_0, this.ZoomFactor, viseVersa: false), MeasuringHelper.ZoomValue(shape.Class174_0.Class177_5.Double_1, this.ZoomFactor, viseVersa: false), bool_1: false);
					Class177 class177_2 = MeasuringHelper.ConsiderAngle(class177_1, rotationCenter, -shape.Angle);
					if (shape.Sizable)
					{
						Class174.Enum31 enum2 = (shape.Class174_0.Enum31_0 = shape.Class174_0.method_22(class177_2));
						if (enum2 != Class174.Enum31.const_9)
						{
							break;
						}
					}
					num++;
					continue;
				}
				return Enum34.const_0;
			}
			this.shape_0 = shape;
			return this.method_51(shape.Class174_0.Enum31_0, shape.Angle);
		}

		private Enum34 method_36(Class177 class177_1)
		{
			int num = this.shapeCollection_0.Count - 1;
			Shape shape_;
			while (true)
			{
				if (num >= 0)
				{
					shape_ = this.shapeCollection_0[num];
					if (this.method_74(shape_, class177_1))
					{
						break;
					}
					num--;
					continue;
				}
				return Enum34.const_0;
			}
			this.shape_0 = shape_;
			if (!this.shape_0.Movable)
			{
				return Enum34.const_0;
			}
			return Enum34.const_2;
		}

		internal bool method_37(Class177 class177_1, Class177 class177_2, int int_3)
		{
			if (!(Math.Abs(class177_1.Double_0 - class177_2.Double_0) > (double)int_3) && !(Math.Abs(class177_1.Double_1 - class177_2.Double_1) > (double)int_3))
			{
				return class177_2.Double_0 == -1.0;
			}
			return true;
		}

		internal Enum34 method_38(Class177 class177_1, Class177 class177_2)
		{
			Enum34 @enum = Enum34.const_0;
			if (this.enum37_0 != Enum37.const_0 && (this.enum36_0 & Enum36.const_0) == Enum36.const_0)
			{
				@enum = (((this.enum36_0 & Enum36.const_2) != Enum36.const_2) ? this.method_40(class177_1, class177_2) : this.method_39(class177_1, class177_2));
			}
			else
			{
				@enum = (this.shapeCollection_0.Boolean_1 ? Enum34.const_1 : this.method_32(class177_1, class177_2));
				if (this.enum37_0 == Enum37.const_0 && ((this.enum36_0 & Enum36.const_0) == Enum36.const_0 || (this.enum36_0 & Enum36.const_1) == Enum36.const_1))
				{
					double num = class177_2.Double_0 - this.class177_0.Double_0;
					double num2 = class177_2.Double_1 - this.class177_0.Double_1;
					this.selection_0.Class178_0 = (this.bool_4 ? new Class178(MeasuringHelper.ZoomValue(this.class177_0.Double_0 * 15.0, this.ZoomFactor, viseVersa: true), MeasuringHelper.ZoomValue(this.class177_0.Double_1 * 15.0, this.ZoomFactor, viseVersa: true), MeasuringHelper.ZoomValue(num * 15.0, this.ZoomFactor, viseVersa: true), MeasuringHelper.ZoomValue(num2 * 15.0, this.ZoomFactor, viseVersa: true), bool_1: false) : new Class178(MeasuringHelper.Pixel2Twips(this.class177_0.Double_0, this.ZoomFactor), MeasuringHelper.Pixel2Twips(this.class177_0.Double_1, this.ZoomFactor), MeasuringHelper.Pixel2Twips(num, this.ZoomFactor), MeasuringHelper.Pixel2Twips(num2, this.ZoomFactor), bool_1: false));
					this.method_13(this.selection_0.Class178_0);
				}
				else
				{
					this.selection_0.Class178_0 = null;
				}
			}
			this.method_77();
			return @enum;
		}

		internal Enum34 method_39(Class177 class177_1, Class177 class177_2)
		{
			if ((this.enum37_0 & Enum37.const_6) == Enum37.const_6)
			{
				MemoryStream memoryStream_ = new MemoryStream();
				this.method_14(memoryStream_);
				List<Class177> list = new List<Class177>();
				Shape[] shapes = this.selection_0.Shapes;
				foreach (Shape shape in shapes)
				{
					list.Add(shape.Class174_0.Class177_4);
				}
				this.method_16(memoryStream_);
				for (int j = 0; j < this.selection_0.Shapes.Length; j++)
				{
					this.selection_0.Shapes[j].Class174_0.Class177_4 = list[j];
				}
				this.enum37_0 = Enum37.const_1;
				this.method_18(bool_5: false, bool_6: false, bool_7: true, bool_8: true);
				this.selection_0.method_32();
			}
			return this.method_40(class177_1, class177_2);
		}

		internal Enum34 method_40(Class177 class177_1, Class177 class177_2)
		{
			Enum34 result = Enum34.const_0;
			if ((this.enum37_0 & Enum37.const_1) == Enum37.const_1)
			{
				if (this.shape_0.CanFitToCanvas)
				{
					double double_ = MeasuringHelper.ZoomValue(class177_1.Double_0, this.ZoomFactor, viseVersa: true);
					double double_2 = MeasuringHelper.ZoomValue(class177_1.Double_1, this.ZoomFactor, viseVersa: true);
					Class177 class177_3 = new Class177(double_, double_2, bool_1: false);
					result = this.method_41(class177_3);
				}
				else
				{
					result = Enum34.const_2;
				}
			}
			else if ((this.enum37_0 & Enum37.const_2) == Enum37.const_2)
			{
				result = this.method_48(class177_1);
			}
			else if ((this.enum37_0 & Enum37.const_3) == Enum37.const_3)
			{
				this.method_61(class177_2);
			}
			return result;
		}

		internal Enum34 method_41(Class177 class177_1)
		{
			Enum34 result = Enum34.const_0;
			if (this.selection_0.Boolean_0)
			{
				result = Enum34.const_2;
				Shape[] shapes = this.selection_0.Shapes;
				foreach (Shape shape in shapes)
				{
					if (shape.Movable)
					{
						this.method_42(shape, class177_1);
					}
				}
				this.selection_0.method_28();
				this.method_43(this.selection_0.Class178_1);
				this.enum37_0 = Enum37.const_1;
			}
			return result;
		}

		private void method_42(Shape shape_1, Class177 class177_1)
		{
			Class177 @class = new Class177(class177_1.Double_0, class177_1.Double_1, bool_1: false);
			@class.method_0(shape_1.Class174_0.Class177_4.Double_0, shape_1.Class174_0.Class177_4.Double_1);
			shape_1.Class174_0.Class177_2 = shape_1.Class174_0.Class178_1.Class177_0;
			shape_1.Class174_0.method_19(@class, bool_2: false, (Class174.Enum30)127, bool_3: false);
		}

		private void method_43(Class178 class178_2)
		{
			bool flag = false;
			double[] array = this.method_44(class178_2, new double[4]
			{
				Math.Round(this.class178_1.Double_9, MidpointRounding.ToEven),
				Math.Round(this.class178_1.Double_11, MidpointRounding.ToEven),
				Math.Round(this.class178_1.Double_10, MidpointRounding.ToEven),
				Math.Round(this.class178_1.Double_8, MidpointRounding.ToEven)
			});
			if (this.method_45(array))
			{
				double double_ = array[0] + array[2];
				double num = array[1] + array[3];
				Shape[] shapes = this.selection_0.Shapes;
				foreach (Shape shape in shapes)
				{
					double double_2 = this.method_46(shape, double_);
					this.method_47(shape, num);
					if (shape.Class174_0.method_19(new Class177(double_2, shape.Class174_0.Class178_1.Double_1 + num, bool_1: false), bool_2: false, (Class174.Enum30)127, bool_3: true))
					{
						flag = true;
					}
					shape.Class183_0.method_1();
				}
				if (flag)
				{
					this.method_13(Helper.GetBounds(this.selection_0.Shapes, 100));
				}
			}
			else
			{
				Shape[] shapes2 = this.selection_0.Shapes;
				foreach (Shape shape2 in shapes2)
				{
					shape2.vmethod_0("Location");
					shape2.vmethod_0("Bounds");
					shape2.Class183_0.method_1();
				}
				this.method_13(this.selection_0.Class178_1);
			}
		}

		private double[] method_44(Class178 class178_2, double[] double_0)
		{
			return new double[4]
			{
				(class178_2.Double_9 < double_0[0]) ? (double_0[0] - class178_2.Double_9) : 0.0,
				(class178_2.Double_11 < double_0[1]) ? (double_0[1] - class178_2.Double_11) : 0.0,
				(class178_2.Double_10 > double_0[2]) ? (double_0[2] - class178_2.Double_10) : 0.0,
				(class178_2.Double_8 > double_0[3]) ? (double_0[3] - class178_2.Double_8) : 0.0
			};
		}

		private bool method_45(double[] double_0)
		{
			bool flag = (double_0[0] != 0.0) ^ (double_0[2] != 0.0);
			bool result = (double_0[1] != 0.0) ^ (double_0[3] != 0.0);
			if (!flag)
			{
				return result;
			}
			return true;
		}

		private double method_46(Shape shape_1, double double_0)
		{
			return shape_1.Class174_0.Class178_1.Double_0 + double_0;
		}

		private double method_47(Shape shape_1, double double_0)
		{
			return shape_1.Class174_0.Class178_1.Double_1 + double_0;
		}

		private Enum34 method_48(Class177 class177_1)
		{
			Enum34 enum34_ = Enum34.const_0;
			if (this.selection_0.Boolean_1)
			{
				Class177 class177_2 = this.method_49(class177_1);
				double[] double_ = this.method_50(class177_2, this.shape_0, out enum34_, this.shape_0.Class174_0.Enum31_0);
				bool flag = false;
				Shape[] shapes = this.selection_0.Shapes;
				foreach (Shape shape_ in shapes)
				{
					if (this.method_53(shape_, double_, class177_2))
					{
						flag = true;
					}
				}
				if (flag)
				{
					this.method_13(Helper.GetBounds(this.selection_0.Shapes, 100));
				}
			}
			return enum34_;
		}

		private Class177 method_49(Class177 class177_1)
		{
			Class177 rotationCenter = new Class177(MeasuringHelper.ZoomValue(this.shape_0.Class174_0.Class177_5.Double_0, this.int_2, viseVersa: false), MeasuringHelper.ZoomValue(this.shape_0.Class174_0.Class177_5.Double_1, this.int_2, viseVersa: false), bool_1: false);
			return MeasuringHelper.ConsiderAngle(new Class177(class177_1.Double_0, class177_1.Double_1, bool_1: false), rotationCenter, -this.shape_0.Angle);
		}

		private double[] method_50(Class177 class177_1, Shape shape_1, out Enum34 enum34_0, Class174.Enum31 enum31_0)
		{
			double num = 0.0;
			double num2 = 0.0;
			double num3 = 0.0;
			double num4 = 0.0;
			switch (enum31_0)
			{
			case Class174.Enum31.const_0:
			{
				Class177 class8 = shape_1.Class174_0.Class178_4[0].Class177_0;
				num = class177_1.Double_0 - class8.Double_0;
				num3 = 0.0 - num;
				num2 = class177_1.Double_1 - class8.Double_1;
				num4 = 0.0 - num2;
				break;
			}
			case Class174.Enum31.const_1:
			{
				Class177 class7 = shape_1.Class174_0.Class178_4[1].Class177_0;
				num3 = class177_1.Double_0 - class7.Double_0;
				num2 = class177_1.Double_1 - class7.Double_1;
				num4 = 0.0 - num2;
				break;
			}
			case Class174.Enum31.const_2:
			{
				Class177 class6 = shape_1.Class174_0.Class178_4[2].Class177_0;
				num = class177_1.Double_0 - class6.Double_0;
				num3 = 0.0 - num;
				num4 = class177_1.Double_1 - class6.Double_1;
				break;
			}
			case Class174.Enum31.const_3:
			{
				Class177 class5 = shape_1.Class174_0.Class178_4[3].Class177_0;
				num3 = class177_1.Double_0 - class5.Double_0;
				num4 = class177_1.Double_1 - class5.Double_1;
				break;
			}
			case Class174.Enum31.const_4:
			{
				Class177 class4 = shape_1.Class174_0.Class178_5[0].Class177_0;
				num2 = class177_1.Double_1 - class4.Double_1;
				num4 = 0.0 - num2;
				break;
			}
			case Class174.Enum31.const_5:
			{
				Class177 class3 = shape_1.Class174_0.Class178_5[1].Class177_0;
				num4 = class177_1.Double_1 - class3.Double_1;
				break;
			}
			case Class174.Enum31.const_6:
			{
				Class177 class2 = shape_1.Class174_0.Class178_5[2].Class177_0;
				num = class177_1.Double_0 - class2.Double_0;
				num3 = 0.0 - num;
				break;
			}
			case Class174.Enum31.const_7:
			{
				Class177 @class = shape_1.Class174_0.Class178_5[3].Class177_0;
				num3 = class177_1.Double_0 - @class.Double_0;
				break;
			}
			}
			enum34_0 = this.method_51(enum31_0, shape_1.Angle);
			return new double[4] { num, num2, num3, num4 };
		}

		private Enum34 method_51(Class174.Enum31 enum31_0, double double_0)
		{
			int int_ = (int)(double_0 + 22.0) / 45;
			return enum31_0 switch
			{
				Class174.Enum31.const_0 => this.method_52(2, int_), 
				Class174.Enum31.const_1 => this.method_52(4, int_), 
				Class174.Enum31.const_2 => this.method_52(4, int_), 
				Class174.Enum31.const_3 => this.method_52(2, int_), 
				Class174.Enum31.const_4 => this.method_52(3, int_), 
				Class174.Enum31.const_5 => this.method_52(3, int_), 
				Class174.Enum31.const_6 => this.method_52(1, int_), 
				Class174.Enum31.const_7 => this.method_52(1, int_), 
				Class174.Enum31.const_8 => Enum34.const_2, 
				_ => Enum34.const_0, 
			};
		}

		private Enum34 method_52(int int_3, int int_4)
		{
			switch (int_3)
			{
			case 1:
				switch (int_4)
				{
				case 0:
					return Enum34.const_3;
				case 1:
					return Enum34.const_4;
				case 2:
					return Enum34.const_5;
				case 3:
					return Enum34.const_6;
				case 4:
					return Enum34.const_3;
				case 5:
					return Enum34.const_4;
				case 6:
					return Enum34.const_5;
				case 7:
					return Enum34.const_6;
				case 8:
					return Enum34.const_3;
				}
				break;
			case 2:
				switch (int_4)
				{
				case 0:
					return Enum34.const_4;
				case 1:
					return Enum34.const_5;
				case 2:
					return Enum34.const_6;
				case 3:
					return Enum34.const_3;
				case 4:
					return Enum34.const_4;
				case 5:
					return Enum34.const_5;
				case 6:
					return Enum34.const_6;
				case 7:
					return Enum34.const_3;
				case 8:
					return Enum34.const_4;
				}
				break;
			case 3:
				switch (int_4)
				{
				case 0:
					return Enum34.const_5;
				case 1:
					return Enum34.const_6;
				case 2:
					return Enum34.const_3;
				case 3:
					return Enum34.const_4;
				case 4:
					return Enum34.const_5;
				case 5:
					return Enum34.const_6;
				case 6:
					return Enum34.const_3;
				case 7:
					return Enum34.const_4;
				case 8:
					return Enum34.const_5;
				}
				break;
			case 4:
				switch (int_4)
				{
				case 0:
					return Enum34.const_6;
				case 1:
					return Enum34.const_3;
				case 2:
					return Enum34.const_4;
				case 3:
					return Enum34.const_5;
				case 4:
					return Enum34.const_6;
				case 5:
					return Enum34.const_3;
				case 6:
					return Enum34.const_4;
				case 7:
					return Enum34.const_5;
				case 8:
					return Enum34.const_6;
				}
				break;
			}
			return Enum34.const_0;
		}

		private bool method_53(Shape shape_1, double[] double_0, Class177 class177_1)
		{
			bool flag = false;
			bool flag2 = false;
			double num;
			double double_;
			while (true)
			{
				Class179 @class = this.method_54(shape_1, double_0);
				num = @class.Double_1;
				double_ = @class.Double_0;
				bool flag3 = num < 0.0;
				bool flag4 = double_ < 0.0;
				if (!flag3 && !flag4)
				{
					break;
				}
				flag = true;
				Flip flip_ = this.method_55(shape_1.Flip, flag3, flag4);
				shape_1.Class174_0.Enum31_0 = this.method_56(shape_1.Class174_0.Enum31_0, shape_1.Flip, flip_);
				shape_1.Flip_1 = flip_;
				double_0 = this.method_50(class177_1, this.shape_0, out var _, shape_1.Class174_0.Enum31_0);
			}
			bool flag5 = double_0[0] != 0.0 || double_0[2] != 0.0;
			bool flag6 = double_0[1] != 0.0 || double_0[3] != 0.0;
			Class177 class2 = this.method_58(shape_1, double_0);
			double num2 = class2.Double_0;
			double double_2 = class2.Double_1;
			if (flag5)
			{
				double[] array = this.method_59(shape_1, num2, num);
				num2 = array[0];
				num = array[1];
				bool flag7 = true;
				Class174.Enum30 enum30_ = (Class174.Enum30)222;
				if (flag6)
				{
					enum30_ = (Class174.Enum30)76;
					flag7 = false;
				}
				flag2 = shape_1.Class174_0.method_18(new Class178(num2, shape_1.Class174_0.Class178_1.Double_1, num, shape_1.Class174_0.Class178_1.Double_2, bool_1: false), flag7, enum30_, bool_3: true);
			}
			if (flag6)
			{
				double[] array2 = this.method_60(shape_1, double_2, double_);
				double_2 = array2[0];
				double_ = array2[1];
				flag2 |= shape_1.Class174_0.method_18(new Class178(num2, double_2, num, double_, bool_1: false), bool_2: true, (Class174.Enum30)222, bool_3: true);
			}
			if (flag)
			{
				shape_1.vmethod_0("Flip");
			}
			return flag2;
		}

		private Class179 method_54(Shape shape_1, double[] double_0)
		{
			double double_ = shape_1.Class174_0.Class178_1.Double_3 + double_0[2];
			double double_2 = shape_1.Class174_0.Class178_1.Double_2 + double_0[3];
			return new Class179(double_, double_2, bool_1: false);
		}

		private Flip method_55(Flip flip_0, bool bool_5, bool bool_6)
		{
			bool flag;
			Flip flip = ((flag = (flip_0 & Flip.Horizontal) == Flip.Horizontal) ? Flip.Horizontal : Flip.None);
			Flip flip2 = ((!flag) ? Flip.Horizontal : Flip.None);
			Flip flip3 = (bool_5 ? flip2 : flip);
			bool flag2;
			Flip flip4 = ((flag2 = (flip_0 & Flip.Vertical) == Flip.Vertical) ? Flip.Vertical : Flip.None);
			Flip flip5 = ((!flag2) ? Flip.Vertical : Flip.None);
			Flip flip6 = (bool_6 ? flip5 : flip4);
			return flip3 | flip6;
		}

		private Class174.Enum31 method_56(Class174.Enum31 enum31_0, Flip flip_0, Flip flip_1)
		{
			bool flag = (flip_0 & Flip.Horizontal) != (flip_1 & Flip.Horizontal);
			bool flag2 = (flip_0 & Flip.Vertical) != (flip_1 & Flip.Vertical);
			Class174.Enum31 @enum = enum31_0;
			if (flag)
			{
				@enum = this.method_57(@enum, bool_5: true);
			}
			if (flag2)
			{
				@enum = this.method_57(@enum, bool_5: false);
			}
			return @enum;
		}

		private Class174.Enum31 method_57(Class174.Enum31 enum31_0, bool bool_5)
		{
			switch (enum31_0)
			{
			default:
				return enum31_0;
			case Class174.Enum31.const_0:
				if (bool_5)
				{
					return Class174.Enum31.const_1;
				}
				return Class174.Enum31.const_2;
			case Class174.Enum31.const_1:
				if (bool_5)
				{
					return Class174.Enum31.const_0;
				}
				return Class174.Enum31.const_3;
			case Class174.Enum31.const_2:
				if (bool_5)
				{
					return Class174.Enum31.const_3;
				}
				return Class174.Enum31.const_0;
			case Class174.Enum31.const_3:
				if (bool_5)
				{
					return Class174.Enum31.const_2;
				}
				return Class174.Enum31.const_1;
			case Class174.Enum31.const_4:
				if (bool_5)
				{
					return enum31_0;
				}
				return Class174.Enum31.const_5;
			case Class174.Enum31.const_5:
				if (bool_5)
				{
					return enum31_0;
				}
				return Class174.Enum31.const_4;
			case Class174.Enum31.const_6:
				if (bool_5)
				{
					return Class174.Enum31.const_7;
				}
				return enum31_0;
			case Class174.Enum31.const_7:
				if (bool_5)
				{
					return Class174.Enum31.const_6;
				}
				return enum31_0;
			}
		}

		private Class177 method_58(Shape shape_1, double[] double_0)
		{
			double double_ = shape_1.Class174_0.Class178_1.Double_0 + double_0[0];
			double double_2 = shape_1.Class174_0.Class178_1.Double_1 + double_0[1];
			return new Class177(double_, double_2, bool_1: false);
		}

		private double[] method_59(Shape shape_1, double double_0, double double_1)
		{
			double num = double_0;
			double num2 = double_1;
			if (double_0 < shape_1.Class174_0.Class177_0.Double_0)
			{
				double num3 = shape_1.Class174_0.Class177_0.Double_0 - double_0;
				num2 -= num3;
				num = shape_1.Class174_0.Class177_0.Double_0;
			}
			double num4 = shape_1.Class174_0.Class179_0.Double_1 + shape_1.Class174_0.Class177_0.Double_0 - double_0;
			if (num2 > num4)
			{
				num2 = num4;
			}
			return new double[2] { num, num2 };
		}

		private double[] method_60(Shape shape_1, double double_0, double double_1)
		{
			double num = double_0;
			double num2 = double_1;
			if (double_0 < shape_1.Class174_0.Class177_1.Double_1)
			{
				double num3 = shape_1.Class174_0.Class177_1.Double_1 - double_0;
				num2 -= num3;
				num = shape_1.Class174_0.Class177_1.Double_1;
			}
			double num4 = shape_1.Class174_0.Class179_1.Double_0 + shape_1.Class174_0.Class177_1.Double_1 - double_0;
			if (num2 > num4)
			{
				num2 = num4;
			}
			return new double[2] { num, num2 };
		}

		internal void method_61(Class177 class177_1)
		{
			Class177 @class = this.method_62(class177_1);
			Class177 class2 = this.method_63();
			bool flag = false;
			foreach (AdjustObject item in this.class173_0.List_0)
			{
				if (item is Class168)
				{
					double double_ = (this.bool_4 ? Math.Max(this.Class179_0.Double_1 / 15.0, this.Class179_0.Double_0 / 15.0) : Math.Max(MeasuringHelper.Twips2Pixels(this.Class179_0.Double_1, 100), MeasuringHelper.Twips2Pixels(this.Class179_0.Double_0, 100)));
					flag |= this.method_64(item, double_, class2, @class);
					continue;
				}
				double num = this.shape_0.Class174_0.Class178_1.Double_7 / 12700.0;
				if (item is Class170)
				{
					double double_2 = @class.Double_0 - class2.Double_0;
					flag |= this.method_66(item, double_2, num);
					continue;
				}
				double double_3 = this.shape_0.Class174_0.Class178_1.Double_6 / 12700.0;
				if (item is Class171)
				{
					double double_4 = @class.Double_1 - class2.Double_1;
					flag |= this.method_67(item, double_4, double_3);
				}
				else
				{
					flag |= this.method_68(item, num, double_3, class2, @class);
				}
			}
			this.selection_0.Shapes[0].Class183_0.ShapeObject_0.CreateGraphicsPaths();
			if (flag)
			{
				this.selection_0.Shapes[0].Class174_0.method_1((Class174.Enum30)127);
				this.method_13(Helper.GetBounds(this.selection_0.Shapes, 100));
			}
		}

		private Class177 method_62(Class177 class177_1)
		{
			Class177 @class = (this.bool_4 ? MeasuringHelper.ConsiderAngle(new Class177(class177_1.Double_0 * 15.0, class177_1.Double_1 * 15.0, bool_1: false), new Class177(MeasuringHelper.ZoomValue(this.selection_0.Shapes[0].Class174_0.Class177_5.Double_0, this.ZoomFactor, viseVersa: false), MeasuringHelper.ZoomValue(this.selection_0.Shapes[0].Class174_0.Class177_5.Double_1, this.ZoomFactor, viseVersa: false), bool_1: false), -this.selection_0.Shapes[0].Angle) : MeasuringHelper.ConsiderAngle(new Class177(MeasuringHelper.Pixel2Twips(class177_1.Double_0, 100), MeasuringHelper.Pixel2Twips(class177_1.Double_1, 100), bool_1: false), new Class177(MeasuringHelper.ZoomValue(this.selection_0.Shapes[0].Class174_0.Class177_5.Double_0, this.ZoomFactor, viseVersa: false), MeasuringHelper.ZoomValue(this.selection_0.Shapes[0].Class174_0.Class177_5.Double_1, this.ZoomFactor, viseVersa: false), bool_1: false), -this.selection_0.Shapes[0].Angle));
			double num = (this.bool_4 ? (@class.Double_0 / 15.0) : MeasuringHelper.Twips2Pixels(@class.Double_0, 100));
			double num2 = (this.bool_4 ? (@class.Double_1 / 15.0) : MeasuringHelper.Twips2Pixels(@class.Double_1, 100));
			bool flag = (this.selection_0.Shapes[0].Flip & Flip.Horizontal) == Flip.Horizontal;
			bool flag2 = (this.selection_0.Shapes[0].Flip & Flip.Vertical) == Flip.Vertical;
			double num3 = (this.bool_4 ? MeasuringHelper.ZoomValue(this.selection_0.Shapes[0].Class174_0.Class178_1.Double_0 / 15.0, this.ZoomFactor, viseVersa: false) : MeasuringHelper.Twips2Pixels(this.selection_0.Shapes[0].Class174_0.Class178_1.Double_0, this.ZoomFactor));
			double num4 = (this.bool_4 ? MeasuringHelper.ZoomValue(this.selection_0.Shapes[0].Class174_0.Class178_1.Double_1 / 15.0, this.ZoomFactor, viseVersa: false) : MeasuringHelper.Twips2Pixels(this.selection_0.Shapes[0].Class174_0.Class178_1.Double_1, this.ZoomFactor));
			double num5 = (this.bool_4 ? MeasuringHelper.ZoomValue(this.selection_0.Shapes[0].Class174_0.Class178_1.Double_3 / 15.0, this.ZoomFactor, viseVersa: false) : MeasuringHelper.Twips2Pixels(this.selection_0.Shapes[0].Class174_0.Class178_1.Double_3, this.ZoomFactor));
			double num6 = (this.bool_4 ? MeasuringHelper.ZoomValue(this.selection_0.Shapes[0].Class174_0.Class178_1.Double_2 / 15.0, this.ZoomFactor, viseVersa: false) : MeasuringHelper.Twips2Pixels(this.selection_0.Shapes[0].Class174_0.Class178_1.Double_2, this.ZoomFactor));
			double value = (flag ? (num3 + (num5 - (num - num3))) : num);
			double value2 = (flag2 ? (num4 + (num6 - (num2 - num4))) : num2);
			return new Class177(Math.Round(value, MidpointRounding.ToEven), Math.Round(value2, MidpointRounding.ToEven), bool_1: false);
		}

		private Class177 method_63()
		{
			double double_ = (this.bool_4 ? (this.class173_0.Double_2 / 15.0 + this.class173_0.Double_1 / 2.0 / 15.0) : (MeasuringHelper.Twips2Pixels(this.class173_0.Double_2, 100) + MeasuringHelper.Twips2Pixels(this.class173_0.Double_1 / 2.0, 100)));
			double double_2 = (this.bool_4 ? (this.class173_0.Double_3 / 15.0 + this.class173_0.Double_0 / 2.0 / 15.0) : (MeasuringHelper.Twips2Pixels(this.class173_0.Double_3, 100) + MeasuringHelper.Twips2Pixels(this.class173_0.Double_0 / 2.0, 100)));
			return new Class177(double_, double_2, bool_1: false);
		}

		private bool method_64(AdjustObject adjustObject_0, double double_0, Class177 class177_1, Class177 class177_2)
		{
			double num = adjustObject_0.Value / 60000.0;
			Class177 pointOnElipse = MeasuringHelper.GetPointOnElipse(num - 180.0, double_0);
			pointOnElipse.Double_0 += class177_1.Double_0;
			pointOnElipse.Double_1 += class177_1.Double_1;
			double num2 = Math.Sqrt(Math.Pow(class177_2.Double_0 - pointOnElipse.Double_0, 2.0) + Math.Pow(class177_2.Double_1 - pointOnElipse.Double_1, 2.0));
			num = this.method_65(pointOnElipse, class177_2) * 60000.0;
			if (num < 0.0)
			{
				num = 21600000.0 + num;
			}
			double num3 = adjustObject_0.Value;
			if (Math.Abs(num3 - num) >= 10800000.0)
			{
				num3 = ((!(num3 > num)) ? (num3 + 21600000.0) : (num3 - 21600000.0));
			}
			if (num2 <= double_0)
			{
				double num4 = double_0 - num2;
				num3 = num3 * num4 / double_0;
				num = num * num2 / double_0;
				num += num3;
			}
			if (num < 0.0)
			{
				num = 21600000.0 + num;
			}
			if (adjustObject_0.PosInOpositeDirection)
			{
				double num5 = num - adjustObject_0.Value;
				num = adjustObject_0.Value - num5;
			}
			if (num >= adjustObject_0.Min && num <= adjustObject_0.Max)
			{
				double value = adjustObject_0.Value;
				double num7 = (adjustObject_0.Value = num);
				return value != num7;
			}
			return false;
		}

		private double method_65(Class177 class177_1, Class177 class177_2)
		{
			double x = class177_2.Double_0 - class177_1.Double_0;
			double y = class177_2.Double_1 - class177_1.Double_1;
			return Math.Atan2(y, x) * 180.0 / Math.PI;
		}

		private bool method_66(AdjustObject adjustObject_0, double double_0, double double_1)
		{
			double num = double_0 / double_1 * 60000.0 * (100.0 / (double)this.int_2);
			num = (adjustObject_0.PosInOpositeDirection ? (num * -1.0) : num);
			double num2 = adjustObject_0.Value + num;
			num2 = ((num2 < adjustObject_0.Min) ? adjustObject_0.Min : num2);
			num2 = ((num2 > adjustObject_0.Max) ? adjustObject_0.Max : num2);
			double value = adjustObject_0.Value;
			double num4 = (adjustObject_0.Value = num2);
			return value != num4;
		}

		private bool method_67(AdjustObject adjustObject_0, double double_0, double double_1)
		{
			double num = double_0 / double_1 * 60000.0 * (100.0 / (double)this.int_2);
			num = (adjustObject_0.PosInOpositeDirection ? (num * -1.0) : num);
			double num2 = adjustObject_0.Value + num;
			num2 = ((num2 < adjustObject_0.Min) ? adjustObject_0.Min : num2);
			num2 = ((num2 > adjustObject_0.Max) ? adjustObject_0.Max : num2);
			double value = adjustObject_0.Value;
			double num4 = (adjustObject_0.Value = (int)num2);
			return value != num4;
		}

		private bool method_68(AdjustObject adjustObject_0, double double_0, double double_1, Class177 class177_1, Class177 class177_2)
		{
			double num = (class177_2.Double_0 - class177_1.Double_0) / double_0 * 12700.0;
			double num2 = (class177_2.Double_1 - class177_1.Double_1) / double_1 * 12700.0;
			double num3 = num - num2;
			double num4 = (adjustObject_0.PosInOpositeDirection ? (adjustObject_0.Value - num3) : (adjustObject_0.Value + num3));
			num4 = ((num4 < adjustObject_0.Min) ? adjustObject_0.Min : num4);
			num4 = ((num4 > adjustObject_0.Max) ? adjustObject_0.Max : num4);
			double value = adjustObject_0.Value;
			double num6 = (adjustObject_0.Value = num4);
			return value != num6;
		}

		internal void method_69(Class177 class177_1)
		{
			this.enum36_0 = (Enum36)24;
			if (this.shape_0 != null && (this.enum37_0 & Enum37.const_4) == Enum37.const_4)
			{
				this.selection_0.method_22(new Shape[1] { this.shape_0 });
			}
			else if ((this.enum37_0 & Enum37.const_5) == Enum37.const_5)
			{
				this.method_70();
			}
			else if ((this.enum37_0 & Enum37.const_0) == Enum37.const_0)
			{
				if (this.shapeCollection_0.Boolean_1)
				{
					this.shapeCollection_0.method_1(class177_1);
				}
				else if (this.selection_0.Class178_0 != null)
				{
					this.selection_0.method_21();
				}
			}
			this.method_71();
			if (this.shape_0 != null)
			{
				this.method_4(this.shape_0);
			}
			this.method_18(bool_5: true, bool_6: true, bool_7: true, bool_8: true);
		}

		private void method_70()
		{
			Shape[] array = new Shape[this.selection_0.Shapes.Length - 1];
			int num = 0;
			for (int i = 0; i < this.selection_0.Shapes.Length; i++)
			{
				if (num >= array.Length)
				{
					break;
				}
				if (this.selection_0.Shapes[i] != this.shape_0)
				{
					array[num] = this.selection_0.Shapes[i];
					num++;
				}
			}
			this.selection_0.method_22(array);
		}

		private void method_71()
		{
			Shape[] shapes = this.selection_0.Shapes;
			foreach (Shape shape in shapes)
			{
				Class177 @class = new Class177(shape.Class174_0.Class178_3.Double_0 + shape.Class174_0.Class178_3.Double_3 / 2.0, shape.Class174_0.Class178_3.Double_1 + shape.Class174_0.Class178_3.Double_2 / 2.0, bool_1: false);
				if (@class.Double_0 != shape.Class174_0.Class177_5.Double_0 || @class.Double_1 != shape.Class174_0.Class177_5.Double_1)
				{
					Class177 class177_ = new Class177(@class.Double_0 - (double)(shape.Size.Width / 2), @class.Double_1 - (double)(shape.Size.Height / 2), bool_1: false);
					shape.Class174_0.method_19(class177_, bool_2: false, (Class174.Enum30)223, bool_3: false);
				}
				shape.Class174_0.Class177_2 = shape.Class174_0.Class178_1.Class177_0;
				shape.Class174_0.Class179_2 = shape.Class174_0.Class178_1.Class179_0;
				shape.Boolean_1 = shape.CanFitToCanvas;
			}
		}

		private void method_72()
		{
			this.method_18(bool_5: true, bool_6: true, bool_7: true, bool_8: true);
			if (this.shape_0 != null)
			{
				this.method_4(this.shape_0);
			}
		}

		internal double[] method_73(Shape shape_1, Class179 class179_1, Class177 class177_1)
		{
			return (double[])this.methodInfo_0.Invoke(this.object_0, new object[3] { shape_1, class179_1, class177_1 });
		}

		private bool method_74(Shape shape_1, Class177 class177_1)
		{
			return (bool)this.methodInfo_19.Invoke(this.object_0, new object[2] { shape_1, class177_1 });
		}

		internal ShapeObject method_75(object object_1, ShapeType shapeType_0)
		{
			return (ShapeObject)this.methodInfo_1.Invoke(this.object_0, new object[2] { object_1, shapeType_0 });
		}

		private void method_76(object object_1)
		{
			this.object_0 = object_1;
			Type type = this.object_0.GetType();
			this.methodInfo_0 = type.GetMethod("CalculateGraphicsPathsOffset", BindingFlags.Instance | BindingFlags.NonPublic);
			this.methodInfo_19 = type.GetMethod("Contains", BindingFlags.Instance | BindingFlags.NonPublic);
			this.methodInfo_1 = type.GetMethod("CreateShapeObjectByType", BindingFlags.Instance | BindingFlags.NonPublic);
			this.methodInfo_2 = type.GetMethod("OnAdaptBounds", BindingFlags.Instance | BindingFlags.NonPublic);
			this.methodInfo_3 = type.GetMethod("OnChanged", BindingFlags.Instance | BindingFlags.NonPublic);
			this.methodInfo_6 = type.GetMethod("OnShapeAdjusted", BindingFlags.Instance | BindingFlags.NonPublic);
			this.methodInfo_7 = type.GetMethod("OnShapeClicked", BindingFlags.Instance | BindingFlags.NonPublic);
			this.methodInfo_8 = type.GetMethod("OnShapeCreated", BindingFlags.Instance | BindingFlags.NonPublic);
			this.methodInfo_9 = type.GetMethod("OnShapeDeleted", BindingFlags.Instance | BindingFlags.NonPublic);
			this.methodInfo_10 = type.GetMethod("OnShapeDeselected", BindingFlags.Instance | BindingFlags.NonPublic);
			this.methodInfo_11 = type.GetMethod("OnShapeFlipped", BindingFlags.Instance | BindingFlags.NonPublic);
			this.methodInfo_12 = type.GetMethod("OnShapeFormatChanged", BindingFlags.Instance | BindingFlags.NonPublic);
			this.methodInfo_13 = type.GetMethod("OnShapeMoved", BindingFlags.Instance | BindingFlags.NonPublic);
			this.methodInfo_14 = type.GetMethod("OnShapeSelected", BindingFlags.Instance | BindingFlags.NonPublic);
			this.methodInfo_15 = type.GetMethod("OnShapeSized", BindingFlags.Instance | BindingFlags.NonPublic);
			this.methodInfo_4 = type.GetMethod("OnViewChanged", BindingFlags.Instance | BindingFlags.NonPublic);
			this.methodInfo_20 = type.GetMethod("SetStates", BindingFlags.Instance | BindingFlags.NonPublic);
			this.methodInfo_18 = type.GetMethod("UpdateMatrix", BindingFlags.Instance | BindingFlags.NonPublic);
			if (this.bool_4 = type.FullName == "TXTextControl.WPF.Drawing.TXDrawingControl")
			{
				this.methodInfo_5 = type.GetMethod("OnInternalPropertyChanged", BindingFlags.Instance | BindingFlags.NonPublic);
				this.methodInfo_17 = type.GetMethod("Refresh", BindingFlags.Instance | BindingFlags.NonPublic);
				this.methodInfo_16 = type.GetMethod("ResetGdiImage", BindingFlags.Instance | BindingFlags.NonPublic);
				this.propertyInfo_0 = type.GetProperty("Visible", BindingFlags.Instance | BindingFlags.NonPublic);
			}
			else
			{
				this.methodInfo_5 = type.GetMethod("OnPropertyChanged", BindingFlags.Instance | BindingFlags.NonPublic);
				this.methodInfo_17 = type.GetMethod("Refresh");
				this.propertyInfo_0 = type.GetProperty("Visible");
			}
		}

		internal void method_77()
		{
			if (this.Boolean_6)
			{
				this.methodInfo_17.Invoke(this.object_0, null);
			}
		}

		internal void method_78()
		{
			if (this.methodInfo_16 != null)
			{
				this.methodInfo_16.Invoke(this.object_0, null);
			}
		}

		private void method_79(object object_1)
		{
			this.methodInfo_20.Invoke(this.object_0, new object[1] { object_1 });
		}

		internal void method_80(Shape shape_1)
		{
			this.methodInfo_18.Invoke(this.object_0, new object[3] { shape_1, 1, 1 });
		}

		internal void method_81()
		{
			this.class371_0.method_2();
		}

		internal bool method_82(bool bool_5)
		{
			this.selection_0.method_32();
			this.bool_0 = false;
			if (this.class371_0.method_4(bool_5))
			{
				this.bool_0 = true;
				return true;
			}
			this.bool_0 = true;
			return false;
		}

		internal bool method_83(bool bool_5)
		{
			this.selection_0.method_32();
			this.bool_0 = false;
			if (this.class371_0.method_6(bool_5))
			{
				this.bool_0 = true;
				return true;
			}
			this.bool_0 = true;
			return false;
		}

		internal void method_84()
		{
			this.class371_0.method_0();
		}
	}
}
