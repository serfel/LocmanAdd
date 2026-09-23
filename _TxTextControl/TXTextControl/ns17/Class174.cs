using System;
using System.Collections.Generic;
using TXTextControl.Drawing;

namespace ns17
{
	internal class Class174
	{
		internal enum Enum30
		{
			const_0 = 1,
			const_1 = 2,
			const_2 = 4,
			const_3 = 8,
			const_4 = 0x10,
			const_5 = 0x20,
			const_6 = 0x40,
			const_7 = 0x80,
			const_8 = 0x100
		}

		internal enum Enum31
		{
			const_0,
			const_1,
			const_2,
			const_3,
			const_4,
			const_5,
			const_6,
			const_7,
			const_8,
			const_9
		}

		internal int int_0 = 120;

		private bool bool_0;

		internal Shape shape_0;

		private Class178 class178_0;

		private Class178 class178_1;

		private double[] double_0 = new double[4];

		private double[] double_1 = new double[4];

		private Class178 class178_2 = new Class178(0.0, 0.0, 0.0, 0.0, bool_1: false);

		private Class178 class178_3 = new Class178(0.0, 0.0, 0.0, 0.0, bool_1: false);

		private Class178 class178_4 = new Class178(0.0, 0.0, 0.0, 0.0, bool_1: false);

		private Class177 class177_0;

		private Class177[] class177_1;

		private Enum31 enum31_0 = Enum31.const_9;

		private TXDrawing txdrawing_0;

		private Class177 class177_2;

		private Class172 class172_0;

		private Dictionary<string, string> dictionary_0;

		private bool bool_1 = true;

		private Class177 class177_3 = new Class177(0.0, 0.0, bool_1: false);

		private Class177 class177_4 = new Class177(0.0, 0.0, bool_1: false);

		private Class179 class179_0 = new Class179(0.0, 0.0, bool_1: false);

		private Class179 class179_1 = new Class179(0.0, 0.0, bool_1: false);

		private Class177 class177_5 = new Class177(0.0, 0.0, bool_1: false);

		private Class179 class179_2 = new Class179(0.0, 0.0, bool_1: false);

		private Class178[] class178_5;

		private Class178[] class178_6;

		private Class178[] class178_7;

		private Class178[] class178_8;

		internal Class172 Class172_0
		{
			get
			{
				return this.class172_0;
			}
			set
			{
				this.class172_0 = value;
			}
		}

		internal Dictionary<string, string> Dictionary_0
		{
			get
			{
				return this.dictionary_0;
			}
			set
			{
				this.dictionary_0 = value;
			}
		}

		internal bool Boolean_0 => this.bool_1;

		internal Class178 Class178_0 => this.class178_0;

		internal Class178 Class178_1
		{
			get
			{
				return this.class178_2;
			}
			set
			{
				this.class178_2 = value;
			}
		}

		internal Class177 Class177_0 => this.class177_3;

		internal Class177 Class177_1 => this.class177_4;

		internal Class179 Class179_0 => this.class179_0;

		internal Class179 Class179_1 => this.class179_1;

		internal Class177 Class177_2
		{
			get
			{
				return this.class177_5;
			}
			set
			{
				this.class177_5 = value;
			}
		}

		internal Class179 Class179_2
		{
			get
			{
				return this.class179_2;
			}
			set
			{
				this.class179_2 = value;
			}
		}

		internal Class178 Class178_2 => this.class178_3;

		internal Class178 Class178_3 => this.class178_4;

		internal Class177[] Class177_3 => this.class177_1;

		internal Class177 Class177_4
		{
			get
			{
				return this.class177_0;
			}
			set
			{
				this.class177_0 = value;
			}
		}

		internal Class177 Class177_5
		{
			get
			{
				if (this.class177_2 == null)
				{
					this.class177_2 = this.method_2(this.class178_2);
				}
				return this.class177_2;
			}
		}

		internal Enum31 Enum31_0
		{
			get
			{
				return this.enum31_0;
			}
			set
			{
				this.enum31_0 = value;
			}
		}

		internal Class178[] Class178_4 => this.class178_7;

		internal Class178[] Class178_5 => this.class178_8;

		internal void method_0(Class178 class178_9, Enum30 enum30_0)
		{
			this.class178_2 = class178_9;
			if (this.shape_0.TXDrawing_0 != null)
			{
				this.method_1(enum30_0);
			}
		}

		internal void method_1(Enum30 enum30_0)
		{
			if ((enum30_0 & Enum30.const_0) == Enum30.const_0)
			{
				this.class177_2 = this.method_2(this.class178_2);
			}
			if ((enum30_0 & Enum30.const_1) == Enum30.const_1)
			{
				this.method_3();
			}
			if ((enum30_0 & Enum30.const_2) == Enum30.const_2)
			{
				this.double_0 = this.method_4(this.Class178_1.Class179_0, new Class177(this.shape_0.Class174_0.Class177_5.Double_0 - this.class178_2.Double_0, this.shape_0.Class174_0.Class177_5.Double_1 - this.class178_2.Double_1, bool_1: false));
			}
			if ((enum30_0 & Enum30.const_3) == Enum30.const_3)
			{
				this.class178_1 = this.method_5(this.shape_0.Class174_0.Class178_1, this.double_0);
			}
			if ((enum30_0 & Enum30.const_4) == Enum30.const_4)
			{
				this.class178_0 = this.method_6();
			}
			if ((enum30_0 & Enum30.const_5) == Enum30.const_5)
			{
				this.class177_2 = this.method_2(this.class178_2);
			}
			if ((enum30_0 & Enum30.const_6) == Enum30.const_6)
			{
				this.method_7();
			}
			if ((enum30_0 & Enum30.const_7) == Enum30.const_7)
			{
				this.method_8();
			}
			if ((enum30_0 & Enum30.const_8) == Enum30.const_8)
			{
				this.method_10();
			}
		}

		private Class177 method_2(Class178 class178_9)
		{
			return new Class177(class178_9.Double_0 + class178_9.Double_3 / 2.0, class178_9.Double_1 + class178_9.Double_2 / 2.0, bool_1: false);
		}

		private void method_3()
		{
			int num;
			int num2;
			int num4;
			int num3;
			if (this.shape_0.AutoSize)
			{
				num = 0;
				num2 = 0;
				num4 = (num3 = this.int_0);
			}
			else
			{
				num2 = (num4 = (num = (num3 = this.int_0 / 2)));
			}
			int num5;
			int num6 = (num5 = this.int_0 / 2);
			double double_ = this.Class178_1.Double_0 * (double)this.txdrawing_0.ZoomFactor / 100.0 - (double)num2;
			double double_2 = this.Class178_1.Double_1 * (double)this.txdrawing_0.ZoomFactor / 100.0 - (double)num;
			double double_3 = (this.Class178_1.Double_0 + this.Class178_1.Double_3) * (double)this.txdrawing_0.ZoomFactor / 100.0 - (double)num4;
			double double_4 = (this.Class178_1.Double_1 + this.Class178_1.Double_2) * (double)this.txdrawing_0.ZoomFactor / 100.0 - (double)num3;
			double double_5 = (this.Class178_1.Double_0 + this.Class178_1.Double_3 / 2.0) * (double)this.txdrawing_0.ZoomFactor / 100.0 - (double)num6;
			double double_6 = (this.Class178_1.Double_1 + this.Class178_1.Double_2 / 2.0) * (double)this.txdrawing_0.ZoomFactor / 100.0 - (double)num5;
			Class178 @class = new Class178(double_, double_2, this.int_0, this.int_0, bool_1: false);
			Class178 class2 = new Class178(double_3, double_2, this.int_0, this.int_0, bool_1: false);
			Class178 class3 = new Class178(double_, double_4, this.int_0, this.int_0, bool_1: false);
			Class178 class4 = new Class178(double_3, double_4, this.int_0, this.int_0, bool_1: false);
			Class178 class5 = new Class178(double_5, double_2, this.int_0, this.int_0, bool_1: false);
			Class178 class6 = new Class178(double_5, double_4, this.int_0, this.int_0, bool_1: false);
			Class178 class7 = new Class178(double_, double_6, this.int_0, this.int_0, bool_1: false);
			Class178 class8 = new Class178(double_3, double_6, this.int_0, this.int_0, bool_1: false);
			this.class178_7 = new Class178[4] { @class, class2, class3, class4 };
			this.class178_8 = new Class178[4] { class5, class6, class7, class8 };
			if (this.shape_0.AutoSize)
			{
				int num7 = this.int_0 / 2;
				this.class178_6 = new Class178[4];
				this.class178_6[0] = new Class178(@class.Double_0, @class.Double_1, @class.Double_3 + (double)num7, @class.Double_2 + (double)num7, bool_1: false);
				this.class178_6[1] = new Class178(class2.Double_0 - (double)num7, class2.Double_1, class2.Double_3 + (double)this.int_0, class2.Double_2 + (double)num7, bool_1: false);
				this.class178_6[2] = new Class178(class3.Double_0, class3.Double_1 - (double)num7, class3.Double_3 + (double)num7, class3.Double_2 + (double)this.int_0, bool_1: false);
				this.class178_6[3] = new Class178(class4.Double_0 - (double)num7, class4.Double_1 - (double)num7, class4.Double_3 + (double)this.int_0, class4.Double_2 + (double)this.int_0, bool_1: false);
				this.class178_5 = new Class178[4];
				this.class178_5[0] = new Class178(class5.Double_0 - (double)num7, class5.Double_1, class5.Double_3 + (double)this.int_0, class5.Double_2 + (double)num7, bool_1: false);
				this.class178_5[1] = new Class178(class6.Double_0 - (double)num7, class6.Double_1 - (double)num7, class6.Double_3 + (double)this.int_0, class6.Double_2 + (double)num7, bool_1: false);
				this.class178_5[2] = new Class178(class7.Double_0, class7.Double_1 - (double)num7, class7.Double_3 + (double)num7, class7.Double_2 + (double)this.int_0, bool_1: false);
				this.class178_5[3] = new Class178(class8.Double_0 - (double)num7, class8.Double_1 - (double)num7, class8.Double_3 + (double)this.int_0, class8.Double_2 + (double)this.int_0, bool_1: false);
			}
			else
			{
				this.class178_6 = this.class178_7;
				this.class178_5 = this.class178_8;
			}
		}

		private double[] method_4(Class179 class179_3, Class177 class177_6)
		{
			return this.shape_0.TXDrawing_0.method_73(this.shape_0, class179_3, class177_6);
		}

		private Class178 method_5(Class178 class178_9, double[] double_2)
		{
			double double_3 = Helper.GetX(class178_9.Class177_0.Double_0, class178_9.Class179_0.Double_1) + double_2[0];
			double double_4 = Helper.GetY(class178_9.Class177_0.Double_1, class178_9.Class179_0.Double_0) + double_2[1];
			double double_5 = Helper.GetWidth(class178_9.Class179_0.Double_1) + (0.0 - double_2[0] + double_2[2]);
			double double_6 = Helper.GetHeight(class178_9.Class179_0.Double_0) + (0.0 - double_2[1] + double_2[3]);
			return new Class178(double_3, double_4, double_5, double_6, bool_1: false);
		}

		private Class178 method_6()
		{
			return this.method_13(this.txdrawing_0.Class178_1, this.txdrawing_0.Class178_1, 100);
		}

		internal void method_7()
		{
			this.class178_4 = Helper.GetRealBounds(this.class178_2, this.class177_2, this.shape_0.Angle, out this.class177_1);
			double num = ((this.class178_4.Double_9 < this.class178_1.Double_9) ? this.class178_4.Double_9 : this.class178_1.Double_9);
			double num2 = ((this.class178_4.Double_11 < this.class178_1.Double_11) ? this.class178_4.Double_11 : this.class178_1.Double_11);
			double num3 = ((this.class178_4.Double_10 > this.class178_1.Double_10) ? this.class178_4.Double_10 : this.class178_1.Double_10);
			double num4 = ((this.class178_4.Double_8 > this.class178_1.Double_8) ? this.class178_4.Double_8 : this.class178_1.Double_8);
			double double_ = num3 - num;
			double double_2 = num4 - num2;
			this.class178_3 = new Class178(num, num2, double_, double_2, bool_1: false);
			this.double_1 = MeasuringHelper.GetMaxBoundsOffset(this.class177_1, this.shape_0.TXDrawing_0.Class178_1, this.shape_0.Angle);
			this.class179_0 = new Class179(this.class178_2.Double_3 + this.double_1[0] + this.double_1[2], this.class178_2.Double_2, bool_1: false);
			this.class179_1 = new Class179(this.class178_2.Double_3, this.class178_2.Double_2 + this.double_1[1] + this.double_1[3], bool_1: false);
			this.class177_3 = new Class177(this.class178_2.Double_0 - this.double_1[0], this.class178_2.Double_1, bool_1: false);
			this.class177_4 = new Class177(this.class178_2.Double_0, this.class178_2.Double_1 - this.double_1[1], bool_1: false);
		}

		private bool method_8()
		{
			if (this.bool_1 != (this.bool_1 = !this.method_9()))
			{
				return true;
			}
			return false;
		}

		private bool method_9()
		{
			bool? flag = this.txdrawing_0.Class178_1.method_0(this.class178_3, 3.0);
			if (flag.HasValue && !flag.Value)
			{
				return false;
			}
			_ = flag.HasValue;
			return true;
		}

		internal void method_10()
		{
			if (!this.bool_1)
			{
				if (this.txdrawing_0.IsCanvasVisible && this.txdrawing_0.ShapeCollection_0.Count == 1 && this.shape_0.AutoSize && this.txdrawing_0.BorderWidth == 0)
				{
					this.txdrawing_0.IsCanvasVisible = false;
				}
			}
			else if (!this.txdrawing_0.IsCanvasVisible)
			{
				this.txdrawing_0.IsCanvasVisible = true;
			}
		}

		internal Class174(ShapeType shapeType_0, Shape shape_1)
		{
			this.shape_0 = shape_1;
		}

		internal void method_11(TXDrawing txdrawing_1)
		{
			this.txdrawing_0 = txdrawing_1;
			this.bool_0 = true;
		}

		internal void method_12()
		{
			this.Class172_0.List_0.Clear();
			this.Class172_0.Clear();
		}

		internal Class178 method_13(Class178 class178_9, Class178 class178_10, int int_1)
		{
			Class178 @class = this.method_14(class178_9.Double_0, class178_9.Double_1, class178_9.Double_3, class178_9.Double_2);
			Class177 class2 = new Class177(@class.Double_0 + @class.Double_3 / 2.0, @class.Double_1 + @class.Double_2 / 2.0, bool_1: false);
			Class177[] ripRealBounds;
			Class178 realBounds = Helper.GetRealBounds(@class, class2, this.shape_0.Angle, out ripRealBounds);
			class2 = new Class177(class2.Double_0 - @class.Double_0, class2.Double_1 - @class.Double_1, bool_1: false);
			double[] double_ = this.method_4(@class.Class179_0, class2);
			Class178 class3 = this.method_5(@class, double_);
			double num = Math.Min(realBounds.Double_9, class3.Double_9);
			double num2 = Math.Min(realBounds.Double_11, class3.Double_11);
			double num3 = Math.Max(realBounds.Double_10, class3.Double_10);
			double num4 = Math.Max(realBounds.Double_8, class3.Double_8);
			double double_2 = num3 - num;
			double double_3 = num4 - num2;
			Class178 class4 = new Class178(num, num2, double_2, double_3, bool_1: false);
			bool? flag = class4.method_0(class178_10, 3.0);
			if (flag.HasValue && !flag.Value && int_1 > 0)
			{
				double num5 = class4.Double_9 - class178_10.Double_9;
				double num6 = class4.Double_11 - class178_10.Double_11;
				double num7 = class4.Double_10 - class178_10.Double_10;
				double num8 = class4.Double_8 - class178_10.Double_8;
				Class178 class178_11 = new Class178(class178_9.Double_0 - num5, class178_9.Double_1 - num6, class178_9.Double_3 + num5 - num7, class178_9.Double_2 + num6 - num8, bool_1: false);
				return this.method_13(class178_11, class178_10, int_1 - 1);
			}
			return @class;
		}

		internal Class178 method_14(double double_2, double double_3, double double_4, double double_5)
		{
			if (this.shape_0.Angle % 45 == 0 && this.shape_0.Angle % 2 != 0)
			{
				return this.method_17(this.shape_0.Angle);
			}
			bool flag;
			if (flag = (this.shape_0.Angle % 360 >= 90 && this.shape_0.Angle % 360 < 180) || (this.shape_0.Angle % 360 >= 270 && this.shape_0.Angle % 360 <= 360))
			{
				_ = this.shape_0.Angle % 360;
			}
			if (flag)
			{
				_ = this.shape_0.Angle % 360;
			}
			double num = (flag ? double_5 : double_4);
			double num2 = (flag ? double_4 : double_5);
			double num3 = this.shape_0.Angle % 180;
			double num4 = Math.Sqrt(Math.Pow(double_5 / Math.Sin(num3 * Math.PI / 180.0), 2.0) - Math.Pow(double_5, 2.0));
			if (!(num3 < 45.0) && (!(num3 > 135.0) || num3 >= 180.0))
			{
				if (num4 > double_4)
				{
					if (flag)
					{
						num = Math.Sqrt(Math.Pow(double_4 / Math.Sin((num3 - 90.0) * Math.PI / 180.0), 2.0) - Math.Pow(double_4, 2.0));
					}
					else
					{
						num2 = Math.Sqrt(Math.Pow(double_4 / Math.Cos(num3 * Math.PI / 180.0), 2.0) - Math.Pow(double_4, 2.0));
					}
				}
				else
				{
					double num5 = Math.Sqrt(Math.Pow(double_4 / Math.Sin(num3 * Math.PI / 180.0), 2.0) - Math.Pow(double_4, 2.0));
					if (num5 > double_5)
					{
						if (flag)
						{
							num2 = Math.Sqrt(Math.Pow(double_5 / Math.Sin((num3 - 90.0) * Math.PI / 180.0), 2.0) - Math.Pow(double_5, 2.0));
						}
						else
						{
							num = Math.Sqrt(Math.Pow(double_5 / Math.Cos(num3 * Math.PI / 180.0), 2.0) - Math.Pow(double_5, 2.0));
						}
					}
				}
			}
			else if (num4 < double_4)
			{
				if (!flag)
				{
					num = num4;
				}
				else
				{
					num2 = num4;
				}
			}
			else
			{
				double num6 = Math.Sqrt(Math.Pow(double_4 / Math.Sin(num3 * Math.PI / 180.0), 2.0) - Math.Pow(double_4, 2.0));
				if (num6 < double_5)
				{
					if (!flag)
					{
						num2 = num6;
					}
					else
					{
						num = num6;
					}
				}
			}
			double num7 = num / 2.0;
			double num8 = num2 / 2.0;
			double num9 = this.shape_0.Angle % 90;
			double num10 = num9 * Math.PI / 180.0;
			double num11 = num8 / Math.Cos(num10);
			double num12 = Math.Sqrt(Math.Pow(num11, 2.0) - Math.Pow(num8, 2.0)) + num7;
			double num13 = num - num12;
			double a = (90.0 - (180.0 - (90.0 - num9) * 2.0)) * Math.PI / 180.0;
			double num14 = num13 / Math.Sin(a);
			Math.Sin(num10);
			double num15 = (num11 - Math.Sin(num10) * num14) * 2.0;
			double num16 = Math.Cos(num10) * num14 * 2.0;
			double double_6 = double_2 + double_4 / 2.0 - num16 / 2.0;
			double double_7 = double_3 + double_5 / 2.0 - num15 / 2.0;
			return new Class178(double_6, double_7, num16, num15, bool_1: false);
		}

		private Class179 method_15(double double_2, double double_3, double double_4)
		{
			double num = Math.Atan(double_3 / double_2) * 180.0 / Math.PI;
			double num2 = 90.0 - (double_4 + num);
			double num3 = double_3 / Math.Cos(num2 * Math.PI / 180.0);
			double num4 = Math.Cos((double_4 - num) * Math.PI / 180.0) * num3;
			double num5 = Math.Sin(num * Math.PI / 180.0) * num3;
			double num6 = Math.Cos(num * Math.PI / 180.0) * num3;
			if (num4 > double_2)
			{
				double num7 = double_2 / num4;
				num5 *= num7;
				num6 *= num7;
			}
			return new Class179(num6, num5, bool_1: false);
		}

		internal bool method_16(Class179 class179_3, Class179 class179_4)
		{
			if (!class179_3.method_1(class179_4))
			{
				return true;
			}
			return false;
		}

		private Class178 method_17(double double_2)
		{
			double double_3 = Math.Min(this.txdrawing_0.Class178_1.Double_3, this.txdrawing_0.Class178_1.Double_2);
			double double_4 = Math.Max(this.txdrawing_0.Class178_1.Double_3, this.txdrawing_0.Class178_1.Double_2);
			double num = double_2;
			num = ((num >= 270.0) ? (90.0 - (num - 270.0)) : ((num >= 180.0) ? (num - 180.0) : ((num >= 90.0) ? (90.0 - (num - 90.0)) : num)));
			Class179 @class = this.method_15(double_4, double_3, num);
			double double_5 = this.txdrawing_0.Class178_1.Double_0 + this.txdrawing_0.Class178_1.Double_3 / 2.0 - @class.Double_1 / 2.0;
			double double_6 = this.txdrawing_0.Class178_1.Double_1 + this.txdrawing_0.Class178_1.Double_2 / 2.0 - @class.Double_0 / 2.0;
			return new Class178(double_5, double_6, @class.Double_1, @class.Double_0, bool_1: false);
		}

		internal bool method_18(Class178 class178_9, bool bool_2, Enum30 enum30_0, bool bool_3)
		{
			this.method_0(new Class178(class178_9.Double_0, class178_9.Double_1, class178_9.Double_3, class178_9.Double_2, bool_1: false), enum30_0);
			if (bool_2 && this.bool_0)
			{
				bool flag = this.method_20(this.Class177_2, class178_9.Class177_0);
				bool flag2 = this.method_16(this.Class179_2, class178_9.Class179_0);
				if (flag || flag2)
				{
					if (bool_3)
					{
						if (flag)
						{
							this.shape_0.vmethod_0("Location");
						}
						if (flag2)
						{
							this.shape_0.vmethod_0("Size");
						}
						this.shape_0.vmethod_0("Bounds");
					}
					this.Class177_2 = class178_9.Class177_0;
					this.Class179_2 = class178_9.Class179_0;
					this.shape_0.Class183_0.method_1();
					return true;
				}
			}
			return false;
		}

		internal bool method_19(Class177 class177_6, bool bool_2, Enum30 enum30_0, bool bool_3)
		{
			this.method_0(new Class178(class177_6.Double_0, class177_6.Double_1, this.class178_2.Double_3, this.class178_2.Double_2, bool_1: false), enum30_0);
			bool flag;
			if (this.bool_0 && (flag = this.method_20(this.Class177_2, class177_6)))
			{
				if (flag && bool_3)
				{
					this.shape_0.vmethod_0("Location");
					this.shape_0.vmethod_0("Bounds");
				}
				if (bool_2)
				{
					this.Class177_2 = class177_6;
					this.shape_0.Class183_0.method_1();
				}
				return true;
			}
			return false;
		}

		private bool method_20(Class177 class177_6, Class177 class177_7)
		{
			if (!class177_6.method_3(class177_7))
			{
				return true;
			}
			return false;
		}

		internal bool method_21(Class179 class179_3, Enum30 enum30_0)
		{
			this.method_0(new Class178(this.class178_2.Double_0, this.class178_2.Double_1, class179_3.Double_1, class179_3.Double_0, bool_1: false), enum30_0);
			if (this.bool_0 && this.method_16(this.Class179_2, class179_3))
			{
				this.Class179_2 = class179_3;
				this.shape_0.Class183_0.method_1();
				return true;
			}
			return false;
		}

		internal Enum31 method_22(Class177 class177_6)
		{
			if (this.class178_6[0].method_1(class177_6))
			{
				return Enum31.const_0;
			}
			if (this.class178_6[1].method_1(class177_6))
			{
				return Enum31.const_1;
			}
			if (this.class178_6[2].method_1(class177_6))
			{
				return Enum31.const_2;
			}
			if (this.class178_6[3].method_1(class177_6))
			{
				return Enum31.const_3;
			}
			if (this.class178_5[0].method_1(class177_6))
			{
				return Enum31.const_4;
			}
			if (this.class178_5[1].method_1(class177_6))
			{
				return Enum31.const_5;
			}
			if (this.class178_5[2].method_1(class177_6))
			{
				return Enum31.const_6;
			}
			if (this.class178_5[3].method_1(class177_6))
			{
				return Enum31.const_7;
			}
			return Enum31.const_9;
		}
	}
}
