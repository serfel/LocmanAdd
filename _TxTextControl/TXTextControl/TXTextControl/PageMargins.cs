using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Security.Permissions;
using ns21;

namespace TXTextControl
{
	/// <summary>Represents the page margins of a document or document section.</summary>
	[Serializable]
	[TypeConverter(typeof(Class419))]
	public class PageMargins : ISerializable
	{
		/// <summary>Determines a certain attribute.</summary>
		public enum Attribute
		{
			/// <summary>Specifies the attribute set through the Left property.</summary>
			Left = 1,
			/// <summary>Specifies the attribute set through the Top property.</summary>
			Top = 2,
			/// <summary>Specifies the attribute set through the Right property.</summary>
			Right = 4,
			/// <summary>Specifies the attribute set through the Bottom property.</summary>
			Bottom = 8,
			/// <summary>Specifies all attributes of the PageMargins.</summary>
			All = 0xF
		}

		private const int int_0 = 1440;

		private Attribute attribute_0;

		private Attribute attribute_1;

		private Attribute attribute_2;

		private TextControlCore textControlCore_0;

		private int int_1;

		private double left = double.NaN;

		private double double_1 = double.NaN;

		private double double_2 = double.NaN;

		private double double_3 = double.NaN;

		/// <summary>Specifies the left margin of a TX Text Control document or document section.</summary>
		[RefreshProperties(RefreshProperties.Repaint)]
		public double Left
		{
			get
			{
				this.method_7(Attribute.Left);
				if (!double.IsNaN(this.left))
				{
					return this.left;
				}
				if (this.textControlCore_0 != null)
				{
					return TwipsConverter.Tw2DotNet(1440, this.textControlCore_0.MeasuringUnit_0);
				}
				return 1440.0;
			}
			set
			{
				this.left = value;
				this.attribute_0 |= Attribute.Left;
				this.method_6();
			}
		}

		/// <summary>Specifies the top margin of a TX Text Control document or document section.</summary>
		[RefreshProperties(RefreshProperties.Repaint)]
		public double Top
		{
			get
			{
				this.method_7(Attribute.Top);
				if (!double.IsNaN(this.double_1))
				{
					return this.double_1;
				}
				if (this.textControlCore_0 != null)
				{
					return TwipsConverter.Tw2DotNet(1440, this.textControlCore_0.MeasuringUnit_0);
				}
				return 1440.0;
			}
			set
			{
				this.double_1 = value;
				this.attribute_0 |= Attribute.Top;
				this.method_6();
			}
		}

		/// <summary>Specifies the right margin of a TX Text Control document or document section.</summary>
		[RefreshProperties(RefreshProperties.Repaint)]
		public double Right
		{
			get
			{
				this.method_7(Attribute.Right);
				if (!double.IsNaN(this.double_2))
				{
					return this.double_2;
				}
				if (this.textControlCore_0 != null)
				{
					return TwipsConverter.Tw2DotNet(1440, this.textControlCore_0.MeasuringUnit_0);
				}
				return 1440.0;
			}
			set
			{
				this.double_2 = value;
				this.attribute_0 |= Attribute.Right;
				this.method_6();
			}
		}

		/// <summary>Specifies the bottom margin of a TX Text Control document or document section.</summary>
		[RefreshProperties(RefreshProperties.Repaint)]
		public double Bottom
		{
			get
			{
				this.method_7(Attribute.Bottom);
				if (!double.IsNaN(this.double_3))
				{
					return this.double_3;
				}
				if (this.textControlCore_0 != null)
				{
					return TwipsConverter.Tw2DotNet(1440, this.textControlCore_0.MeasuringUnit_0);
				}
				return 1440.0;
			}
			set
			{
				this.double_3 = value;
				this.attribute_0 |= Attribute.Bottom;
				this.method_6();
			}
		}

		internal int Int32_0
		{
			get
			{
				int num = 0;
				for (int i = 0; i < 32; i++)
				{
					if (((uint)this.attribute_0 & (uint)(1 << i)) != 0)
					{
						num++;
					}
				}
				return num;
			}
		}

		/// <summary>Creates a new instance of the PageMargins class with a left, top, right and bottom margin of 1 inch.</summary>
		public PageMargins()
		{
			this.method_4();
		}

		/// <summary>Creates a new instance of the PageMargins class with the specified margins.</summary>
		/// <param name="left">Specifies the left page margin.</param>
		/// <param name="top">Specifies the top page margin.</param>
		/// <param name="right">Specifies the right page margin.</param>
		/// <param name="bottom">Specifies the bottom page margin.</param>
		public PageMargins(double left, double top, double right, double bottom)
		{
			this.left = left;
			this.double_1 = top;
			this.double_2 = right;
			this.double_3 = bottom;
			this.attribute_0 |= Attribute.All;
		}

		protected PageMargins(SerializationInfo info, StreamingContext context)
		{
			this.left = info.GetDouble("left");
			this.double_1 = info.GetDouble("top");
			this.double_2 = info.GetDouble("right");
			this.double_3 = info.GetDouble("bottom");
			this.attribute_0 |= Attribute.All;
		}

		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("left", this.left);
			info.AddValue("top", this.double_1);
			info.AddValue("right", this.double_2);
			info.AddValue("bottom", this.double_3);
		}

		internal bool method_0(Attribute attribute_3)
		{
			this.method_7(attribute_3);
			return (this.attribute_2 & attribute_3) == 0;
		}

		internal void method_1(TextControlCore textControlCore_1, int int_2)
		{
			this.textControlCore_0 = textControlCore_1;
			this.int_1 = int_2;
		}

		internal void method_2()
		{
			this.attribute_0 = Attribute.All;
		}

		internal void method_3(PageMargins pageMargins_0)
		{
			pageMargins_0.left = this.left;
			pageMargins_0.double_1 = this.double_1;
			pageMargins_0.double_2 = this.double_2;
			pageMargins_0.double_3 = this.double_3;
			pageMargins_0.attribute_0 = this.attribute_0;
		}

		internal void method_4()
		{
			this.left = double.NaN;
			this.double_1 = double.NaN;
			this.double_2 = double.NaN;
			this.double_3 = double.NaN;
			this.attribute_0 |= Attribute.All;
			this.method_6();
		}

		internal bool method_5()
		{
			double num = ((this.textControlCore_0 != null) ? TwipsConverter.Tw2DotNet(1440, this.textControlCore_0.MeasuringUnit_0) : 1440.0);
			if (this.Left == num && this.Top == num && this.Right == num)
			{
				return this.Bottom == num;
			}
			return false;
		}

		internal void method_6()
		{
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated && this.attribute_0 != 0)
			{
				Class429.Struct83 struct83_ = new Class429.Struct83(-1, -1, -1, -1);
				if ((this.attribute_0 & Attribute.Left) != 0)
				{
					struct83_.int_0 = (double.IsNaN(this.left) ? 1440 : TwipsConverter.DotNet2Tw(this.left, this.textControlCore_0.MeasuringUnit_0));
				}
				if ((this.attribute_0 & Attribute.Top) != 0)
				{
					struct83_.int_1 = (double.IsNaN(this.double_1) ? 1440 : TwipsConverter.DotNet2Tw(this.double_1, this.textControlCore_0.MeasuringUnit_0));
				}
				if ((this.attribute_0 & Attribute.Right) != 0)
				{
					struct83_.int_2 = (double.IsNaN(this.double_2) ? 1440 : TwipsConverter.DotNet2Tw(this.double_2, this.textControlCore_0.MeasuringUnit_0));
				}
				if ((this.attribute_0 & Attribute.Bottom) != 0)
				{
					struct83_.int_3 = (double.IsNaN(this.double_3) ? 1440 : TwipsConverter.DotNet2Tw(this.double_3, this.textControlCore_0.MeasuringUnit_0));
				}
				this.textControlCore_0.method_32(Enum83.const_60, Class429.smethod_3(2, this.int_1), ref struct83_);
			}
			this.attribute_0 = (Attribute)0;
		}

		private void method_7(Attribute attribute_3)
		{
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated && (attribute_3 & Attribute.All) != 0 && (this.attribute_1 & Attribute.All) == 0)
			{
				Class429.Struct83 struct83_ = default(Class429.Struct83);
				this.textControlCore_0.method_32(Enum83.const_59, this.int_1, ref struct83_);
				if (struct83_.int_0 == -1)
				{
					this.attribute_2 |= Attribute.Left;
					this.left = TwipsConverter.Tw2DotNet(1440, this.textControlCore_0.MeasuringUnit_0);
				}
				else
				{
					this.left = TwipsConverter.Tw2DotNet(struct83_.int_0, this.textControlCore_0.MeasuringUnit_0);
				}
				if (struct83_.int_1 == -1)
				{
					this.attribute_2 |= Attribute.Top;
					this.double_1 = TwipsConverter.Tw2DotNet(1440, this.textControlCore_0.MeasuringUnit_0);
				}
				else
				{
					this.double_1 = TwipsConverter.Tw2DotNet(struct83_.int_1, this.textControlCore_0.MeasuringUnit_0);
				}
				if (struct83_.int_2 == -1)
				{
					this.attribute_2 |= Attribute.Right;
					this.double_2 = TwipsConverter.Tw2DotNet(1440, this.textControlCore_0.MeasuringUnit_0);
				}
				else
				{
					this.double_2 = TwipsConverter.Tw2DotNet(struct83_.int_2, this.textControlCore_0.MeasuringUnit_0);
				}
				if (struct83_.int_3 == -1)
				{
					this.attribute_2 |= Attribute.Bottom;
					this.double_3 = TwipsConverter.Tw2DotNet(1440, this.textControlCore_0.MeasuringUnit_0);
				}
				else
				{
					this.double_3 = TwipsConverter.Tw2DotNet(struct83_.int_3, this.textControlCore_0.MeasuringUnit_0);
				}
				this.attribute_1 |= Attribute.All;
			}
		}

		internal Attribute method_8(Attribute attribute_3, Attribute attribute_4)
		{
			Attribute attribute = (Attribute)0;
			Attribute attribute2 = this.attribute_2;
			this.attribute_1 &= ~attribute_3;
			if ((attribute_4 & Attribute.All) != 0)
			{
				double num = this.left;
				double num2 = this.double_1;
				double num3 = this.double_2;
				double num4 = this.double_3;
				this.method_7(attribute_4);
				if (num != this.left || (attribute2 & Attribute.Left) != (this.attribute_2 & Attribute.Left))
				{
					attribute |= Attribute.Left;
				}
				if (num2 != this.double_1 || (attribute2 & Attribute.Top) != (this.attribute_2 & Attribute.Top))
				{
					attribute |= Attribute.Top;
				}
				if (num3 != this.double_2 || (attribute2 & Attribute.Right) != (this.attribute_2 & Attribute.Right))
				{
					attribute |= Attribute.Right;
				}
				if (num4 != this.double_3 || (attribute2 & Attribute.Bottom) != (this.attribute_2 & Attribute.Bottom))
				{
					attribute |= Attribute.Bottom;
				}
			}
			return attribute;
		}
	}
}
