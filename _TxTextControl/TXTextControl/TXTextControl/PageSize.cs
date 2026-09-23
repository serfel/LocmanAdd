using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Security.Permissions;
using ns21;

namespace TXTextControl
{
	/// <summary>Represents the page's size of a TX Text Control document or document section.</summary>
	[Serializable]
	[TypeConverter(typeof(Class420))]
	public class PageSize : ISerializable
	{
		/// <summary>Determines a certain page size attribute.</summary>
		public enum Attribute
		{
			/// <summary>Specifies the attribute set through the Width property.</summary>
			Width = 1,
			/// <summary>Specifies the attribute set through the Height property.</summary>
			Height,
			/// <summary>Specifies all attributes of the PageSize.</summary>
			All
		}

		private const int int_0 = 12240;

		private const int int_1 = 15840;

		private Attribute attribute_0;

		private Attribute attribute_1;

		private Attribute attribute_2;

		private TextControlCore textControlCore_0;

		private int int_2;

		private double double_0 = double.NaN;

		private double double_1 = double.NaN;

		private bool bool_0;

		/// <summary>Specifies the page width of a document or document section.</summary>
		[RefreshProperties(RefreshProperties.Repaint)]
		public double Width
		{
			get
			{
				this.method_7(Attribute.Width);
				if (!double.IsNaN(this.double_0))
				{
					return this.double_0;
				}
				if (this.textControlCore_0 != null)
				{
					return TwipsConverter.Tw2DotNet(12240, this.textControlCore_0.MeasuringUnit_0);
				}
				return 12240.0;
			}
			set
			{
				this.double_0 = value;
				this.attribute_0 |= Attribute.Width;
				this.method_6();
			}
		}

		/// <summary>Specifies the page height of a document or document section.</summary>
		[RefreshProperties(RefreshProperties.Repaint)]
		public double Height
		{
			get
			{
				this.method_7(Attribute.Height);
				if (!double.IsNaN(this.double_1))
				{
					return this.double_1;
				}
				if (this.textControlCore_0 != null)
				{
					return TwipsConverter.Tw2DotNet(15840, this.textControlCore_0.MeasuringUnit_0);
				}
				return 15840.0;
			}
			set
			{
				this.double_1 = value;
				this.attribute_0 |= Attribute.Height;
				this.method_6();
			}
		}

		internal bool Boolean_0
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

		/// <summary>Creates a new PageSize object representing an US Letter page size (8.5 x 11 inch).</summary>
		public PageSize()
		{
			this.method_4();
		}

		/// <summary>Creates a new PageSize object representing a page size with the specified width and height. The measure for the width and height parameters depends on the TextControl.PageUnit, WPF.TextControl.PageUnit or ServerTextControl.PageUnit property.</summary>
		/// <param name="width">Specifies the width of the page.</param>
		/// <param name="height">Specifies the height of the page.</param>
		public PageSize(double width, double height)
		{
			this.double_0 = width;
			this.double_1 = height;
			this.attribute_0 |= Attribute.All;
		}

		protected PageSize(SerializationInfo info, StreamingContext context)
		{
			this.double_0 = info.GetDouble("Width");
			this.double_1 = info.GetDouble("Height");
			this.attribute_0 |= Attribute.All;
		}

		[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Width", this.double_0);
			info.AddValue("Height", this.double_1);
		}

		internal bool method_0(Attribute attribute_3)
		{
			this.method_7(attribute_3);
			return (this.attribute_2 & attribute_3) == 0;
		}

		internal void method_1(TextControlCore textControlCore_1, int int_3)
		{
			this.textControlCore_0 = textControlCore_1;
			this.int_2 = int_3;
		}

		internal void method_2()
		{
			this.attribute_0 = Attribute.All;
		}

		internal void method_3(PageSize pageSize_0)
		{
			pageSize_0.double_0 = this.double_0;
			pageSize_0.double_1 = this.double_1;
			pageSize_0.attribute_0 = this.attribute_0;
		}

		internal void method_4()
		{
			this.double_0 = double.NaN;
			this.double_1 = double.NaN;
			this.attribute_0 |= Attribute.All;
			this.method_6();
		}

		internal bool method_5()
		{
			double num = ((this.textControlCore_0 != null) ? TwipsConverter.Tw2DotNet(12240, this.textControlCore_0.MeasuringUnit_0) : 12240.0);
			double num2 = ((this.textControlCore_0 != null) ? TwipsConverter.Tw2DotNet(15840, this.textControlCore_0.MeasuringUnit_0) : 15840.0);
			if (this.Width == num)
			{
				return this.Height == num2;
			}
			return false;
		}

		internal void method_6()
		{
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated && this.attribute_0 != 0)
			{
				Class429.Struct82 struct82_ = new Class429.Struct82(0, 0);
				if ((this.attribute_0 & Attribute.Width) != 0)
				{
					struct82_.int_0 = (double.IsNaN(this.double_0) ? 12240 : TwipsConverter.DotNet2Tw(this.double_0, this.textControlCore_0.MeasuringUnit_0));
				}
				if ((this.attribute_0 & Attribute.Height) != 0)
				{
					struct82_.int_1 = (double.IsNaN(this.double_1) ? 15840 : TwipsConverter.DotNet2Tw(this.double_1, this.textControlCore_0.MeasuringUnit_0));
				}
				if (this.bool_0)
				{
					int num = struct82_.int_0;
					struct82_.int_0 = struct82_.int_1;
					struct82_.int_1 = num;
				}
				this.textControlCore_0.method_36(Enum83.const_223, this.int_2, ref struct82_);
			}
			this.attribute_0 = (Attribute)0;
		}

		private void method_7(Attribute attribute_3)
		{
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated && (attribute_3 & Attribute.All) != 0 && (this.attribute_1 & Attribute.All) == 0)
			{
				Class429.Struct82 struct82_ = new Class429.Struct82(0, 0);
				this.textControlCore_0.method_36(Enum83.const_222, this.int_2, ref struct82_);
				if (this.bool_0)
				{
					int num = struct82_.int_0;
					struct82_.int_0 = struct82_.int_1;
					struct82_.int_1 = num;
				}
				if (struct82_.int_0 == -1)
				{
					this.attribute_2 |= Attribute.Width;
					this.double_0 = TwipsConverter.Tw2DotNet(12240, this.textControlCore_0.MeasuringUnit_0);
				}
				else
				{
					this.double_0 = TwipsConverter.Tw2DotNet(struct82_.int_0, this.textControlCore_0.MeasuringUnit_0);
				}
				if (struct82_.int_1 == -1)
				{
					this.attribute_2 |= Attribute.Height;
					this.double_1 = TwipsConverter.Tw2DotNet(15840, this.textControlCore_0.MeasuringUnit_0);
				}
				else
				{
					this.double_1 = TwipsConverter.Tw2DotNet(struct82_.int_1, this.textControlCore_0.MeasuringUnit_0);
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
				double num = this.double_0;
				double num2 = this.double_1;
				this.method_7(attribute_4);
				if (num != this.double_0 || (attribute2 & Attribute.Width) != (this.attribute_2 & Attribute.Width))
				{
					attribute |= Attribute.Width;
				}
				if (num2 != this.double_1 || (attribute2 & Attribute.Height) != (this.attribute_2 & Attribute.Height))
				{
					attribute |= Attribute.Height;
				}
			}
			return attribute;
		}
	}
}
