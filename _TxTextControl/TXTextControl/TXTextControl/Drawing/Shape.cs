using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Threading;
using ns17;

namespace TXTextControl.Drawing
{
	/// <summary>The Drawing.Shape class represents a shape which can be displayed inside the TX Drawing Control.</summary>
	public class Shape : INotifyPropertyChanged
	{
		/// <summary>The Drawing.Shape.Fill class determines the fill properties of a shape.</summary>
		public class Fill
		{
			private Color color_0;

			private Enum35 enum35_0 = Enum35.const_1;

			private Shape shape_0;

			private PropertyChangedEventHandler propertyChangedEventHandler_0;

			/// <summary>Gets or sets the shape's fill color.</summary>
			public Color Color
			{
				get
				{
					return this.color_0;
				}
				set
				{
					if (this.shape_0.TXDrawing_0 != null)
					{
						this.shape_0.TXDrawing_0.Selection_0.method_32();
					}
					if (this.method_0(value))
					{
						this.shape_0.TXDrawing_0.method_18(bool_5: false, bool_6: true, bool_7: true, bool_8: true);
					}
				}
			}

			internal Color Color_0
			{
				get
				{
					return this.color_0;
				}
				set
				{
					this.color_0 = value;
				}
			}

			internal Enum35 Enum35_0
			{
				get
				{
					return this.enum35_0;
				}
				set
				{
					this.enum35_0 = value;
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

			internal Fill(Color fillColor, Shape shape)
			{
				this.color_0 = fillColor;
				this.shape_0 = shape;
			}

			private bool method_0(Color color_1)
			{
				if (this.color_0 != (this.color_0 = color_1))
				{
					return this.shape_0.TXDrawing_0 != null;
				}
				return false;
			}

			internal virtual void vmethod_0(string string_0)
			{
				this.propertyChangedEventHandler_0?.Invoke(this, new PropertyChangedEventArgs(string_0));
			}
		}

		/// <summary>The Drawing.Shape.Outline class determines the line properties of a shape.</summary>
		public class Outline : INotifyPropertyChanged
		{
			private Color color_0;

			private int int_0;

			private Shape shape_0;

			private PropertyChangedEventHandler propertyChangedEventHandler_0;

			/// <summary>Gets or sets the shape's line color.</summary>
			public Color Color
			{
				get
				{
					return this.color_0;
				}
				set
				{
					if (this.shape_0.TXDrawing_0 != null)
					{
						this.shape_0.TXDrawing_0.Selection_0.method_32();
					}
					if (this.method_0(value))
					{
						this.shape_0.TXDrawing_0.method_18(bool_5: false, bool_6: true, bool_7: true, bool_8: true);
					}
				}
			}

			/// <summary>Gets or sets the shape's line width.</summary>
			public int Width
			{
				get
				{
					return this.int_0;
				}
				set
				{
					if (this.shape_0.TXDrawing_0 != null)
					{
						this.shape_0.TXDrawing_0.Selection_0.method_32();
					}
					if (this.method_1(value))
					{
						this.shape_0.TXDrawing_0.method_18(bool_5: true, bool_6: true, bool_7: true, bool_8: true);
					}
				}
			}

			internal Color Color_0
			{
				get
				{
					return this.color_0;
				}
				set
				{
					this.color_0 = value;
				}
			}

			internal int Int32_0
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

			internal Outline(Color outlineColor, int width, Shape shape)
			{
				this.color_0 = outlineColor;
				this.int_0 = width;
				this.shape_0 = shape;
			}

			private bool method_0(Color color_1)
			{
				if (this.color_0 != (this.color_0 = color_1))
				{
					return this.shape_0.TXDrawing_0 != null;
				}
				return false;
			}

			private bool method_1(int int_1)
			{
				if (this.int_0 != (this.int_0 = int_1) && this.shape_0.TXDrawing_0 != null)
				{
					this.shape_0.Class174_0.method_1((Class174.Enum30)220);
					return true;
				}
				return false;
			}

			internal virtual void vmethod_0(string string_0)
			{
				this.propertyChangedEventHandler_0?.Invoke(this, new PropertyChangedEventArgs(string_0));
			}
		}

		private PropertyChangedEventHandler propertyChangedEventHandler_0;

		private bool bool_0;

		private bool bool_1;

		private bool bool_2;

		private bool bool_3;

		private bool bool_4;

		private bool bool_5 = true;

		private bool bool_6 = true;

		private bool bool_7 = true;

		private double[] double_0 = new double[0];

		private int int_0;

		private int int_1 = -1;

		private Flip flip_0;

		private Fill fill_0;

		private Outline outline_0;

		private Class174 class174_0;

		private Class183 class183_0;

		private ShapeType shapeType_0 = ShapeType.Rectangle;

		private TXDrawing txdrawing_0;

		[CompilerGenerated]
		private int int_2;

		[CompilerGenerated]
		private bool bool_8;

		[CompilerGenerated]
		private bool bool_9;

		[CompilerGenerated]
		private Flip flip_1;

		[CompilerGenerated]
		private int int_3;

		[CompilerGenerated]
		private bool bool_10;

		[CompilerGenerated]
		private Class177 class177_0;

		[CompilerGenerated]
		private int int_4;

		[CompilerGenerated]
		private bool bool_11;

		[CompilerGenerated]
		private int int_5;

		[CompilerGenerated]
		private double double_1;

		[CompilerGenerated]
		private bool bool_12;

		[CompilerGenerated]
		private Class179 class179_0;

		[CompilerGenerated]
		private ShapeType shapeType_1;

		internal double[] Double_0
		{
			get
			{
				return this.double_0;
			}
			set
			{
				this.double_0 = value;
			}
		}

		internal int Int32_0
		{
			[CompilerGenerated]
			get
			{
				return this.int_2;
			}
			[CompilerGenerated]
			set
			{
				this.int_2 = value;
			}
		}

		internal bool Boolean_0
		{
			[CompilerGenerated]
			get
			{
				return this.bool_8;
			}
			[CompilerGenerated]
			set
			{
				this.bool_8 = value;
			}
		}

		internal bool Boolean_1
		{
			[CompilerGenerated]
			get
			{
				return this.bool_9;
			}
			[CompilerGenerated]
			set
			{
				this.bool_9 = value;
			}
		}

		internal Flip Flip_0
		{
			[CompilerGenerated]
			get
			{
				return this.flip_1;
			}
			[CompilerGenerated]
			set
			{
				this.flip_1 = value;
			}
		}

		internal int Int32_1
		{
			[CompilerGenerated]
			get
			{
				return this.int_3;
			}
			[CompilerGenerated]
			set
			{
				this.int_3 = value;
			}
		}

		internal bool Boolean_2
		{
			[CompilerGenerated]
			get
			{
				return this.bool_10;
			}
			[CompilerGenerated]
			set
			{
				this.bool_10 = value;
			}
		}

		internal Class177 Class177_0
		{
			[CompilerGenerated]
			get
			{
				return this.class177_0;
			}
			[CompilerGenerated]
			set
			{
				this.class177_0 = value;
			}
		}

		internal int Int32_2
		{
			[CompilerGenerated]
			get
			{
				return this.int_4;
			}
			[CompilerGenerated]
			set
			{
				this.int_4 = value;
			}
		}

		internal bool Boolean_3
		{
			[CompilerGenerated]
			get
			{
				return this.bool_11;
			}
			[CompilerGenerated]
			set
			{
				this.bool_11 = value;
			}
		}

		internal int Int32_3
		{
			[CompilerGenerated]
			get
			{
				return this.int_5;
			}
			[CompilerGenerated]
			set
			{
				this.int_5 = value;
			}
		}

		internal double Double_1
		{
			[CompilerGenerated]
			get
			{
				return this.double_1;
			}
			[CompilerGenerated]
			set
			{
				this.double_1 = value;
			}
		}

		internal bool Boolean_4
		{
			[CompilerGenerated]
			get
			{
				return this.bool_12;
			}
			[CompilerGenerated]
			set
			{
				this.bool_12 = value;
			}
		}

		internal Class179 Class179_0
		{
			[CompilerGenerated]
			get
			{
				return this.class179_0;
			}
			[CompilerGenerated]
			set
			{
				this.class179_0 = value;
			}
		}

		internal ShapeType ShapeType_0
		{
			[CompilerGenerated]
			get
			{
				return this.shapeType_1;
			}
			[CompilerGenerated]
			set
			{
				this.shapeType_1 = value;
			}
		}

		/// <summary>Gets or sets the angle of the shape inside the TX Drawing Control.</summary>
		public int Angle
		{
			get
			{
				return this.int_0;
			}
			set
			{
				if (this.bool_3)
				{
					this.txdrawing_0.Selection_0.method_32();
				}
				int int_ = ((value >= 0) ? (value % 360) : (360 - Math.Abs(value % 360)));
				if (this.method_4(int_))
				{
					this.txdrawing_0.method_18(bool_5: true, bool_6: true, bool_7: true, bool_8: true);
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether the shape is automatically resized with the TX Drawing Control.</summary>
		public bool AutoSize
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				if (this.bool_3)
				{
					this.txdrawing_0.Selection_0.method_32();
				}
				if (this.method_5(value))
				{
					this.txdrawing_0.method_18(bool_5: false, this.bool_4, bool_7: true, bool_8: true);
				}
			}
		}

		/// <summary>Gets or sets the bounding rectangle of the shape.</summary>
		public Rectangle Bounds
		{
			get
			{
				return new Rectangle(this.Location, this.Size);
			}
			set
			{
				this.Boolean_9 = false;
				if (this.bool_3)
				{
					this.txdrawing_0.Selection_0.method_32();
					if (this.Class174_0.method_18(new Class178(value.X, value.Y, value.Width, value.Height, bool_1: false), bool_2: true, (Class174.Enum30)479, bool_3: false))
					{
						this.txdrawing_0.method_18(bool_5: true, bool_6: true, bool_7: true, bool_8: true);
					}
				}
				else
				{
					this.class174_0.Class178_1 = new Class178(value.X, value.Y, value.Width, value.Height, bool_1: false);
				}
			}
		}

		/// <summary>Gets a value which indicates whether the FitToCanvas method can be used or not.</summary>
		public bool CanFitToCanvas => this.class174_0.Boolean_0;

		/// <summary>Gets or sets whether and in what form the shape is flipped.</summary>
		public Flip Flip
		{
			get
			{
				return this.flip_0;
			}
			set
			{
				if (this.bool_3)
				{
					this.txdrawing_0.Selection_0.method_32();
				}
				if (this.method_6(value))
				{
					this.txdrawing_0.method_18(bool_5: true, bool_6: true, bool_7: true, bool_8: true);
				}
			}
		}

		/// <summary>Represents the index of the shape inside control's shape collection.</summary>
		public int Index => this.int_1;

		/// <summary>Gets a value which indicates whether the shape is selected or not.</summary>
		public bool IsSelected => this.bool_4;

		/// <summary>Gets or sets shape's current location.</summary>
		public Point Location
		{
			get
			{
				int x = (int)Math.Round(this.Class174_0.Class178_1.Class177_0.Double_0, MidpointRounding.ToEven);
				int y = (int)Math.Round(this.Class174_0.Class178_1.Class177_0.Double_1, MidpointRounding.ToEven);
				return new Point(x, y);
			}
			set
			{
				this.Boolean_9 = false;
				if (this.bool_3)
				{
					this.txdrawing_0.Selection_0.method_32();
					if (this.Class174_0.method_19(new Class177(value.X, value.Y, bool_1: false), bool_2: true, (Class174.Enum30)479, bool_3: false))
					{
						this.txdrawing_0.method_18(bool_5: true, bool_6: true, bool_7: true, bool_8: true);
					}
				}
				else
				{
					this.class174_0.Class178_1 = new Class178(value.X, value.Y, this.Class174_0.Class178_1.Double_3, this.Class174_0.Class178_1.Double_3, bool_1: false);
				}
			}
		}

		/// <summary>Gets or sets a value which indicates whether the shape is movable or not.</summary>
		[DefaultValue(true)]
		public bool Movable
		{
			get
			{
				return this.bool_5;
			}
			set
			{
				if (this.bool_3)
				{
					this.txdrawing_0.Selection_0.method_32();
				}
				if (this.method_7(value))
				{
					this.txdrawing_0.Selection_0.method_27();
					this.txdrawing_0.method_18(bool_5: false, bool_6: false, bool_7: true, bool_8: true);
				}
			}
		}

		/// <summary>Gets the shape's fill properties.</summary>
		public Fill ShapeFill => this.fill_0;

		/// <summary>Gets the shape's outline properties.</summary>
		public Outline ShapeOutline => this.outline_0;

		/// <summary>Gets or sets a value which indicates whether the shape is sizable or not.</summary>
		[DefaultValue(true)]
		public bool Sizable
		{
			get
			{
				return this.bool_6;
			}
			set
			{
				if (this.bool_3)
				{
					this.txdrawing_0.Selection_0.method_32();
				}
				if (this.method_8(value))
				{
					this.txdrawing_0.Selection_0.method_29();
					this.txdrawing_0.method_18(bool_5: false, this.bool_4, bool_7: true, bool_8: true);
				}
			}
		}

		/// <summary>Gets or sets the shape's current size.</summary>
		public Size Size
		{
			get
			{
				int width = (int)Math.Round(this.Class174_0.Class178_1.Double_3, MidpointRounding.ToEven);
				int height = (int)Math.Round(this.Class174_0.Class178_1.Double_2, MidpointRounding.ToEven);
				return new Size(width, height);
			}
			set
			{
				this.Boolean_9 = false;
				if (this.bool_3)
				{
					this.txdrawing_0.Selection_0.method_32();
					if (this.Class174_0.method_21(new Class179(value.Width, value.Height, bool_1: false), (Class174.Enum30)479))
					{
						this.txdrawing_0.method_18(bool_5: true, bool_6: true, bool_7: true, bool_8: true);
					}
				}
				else
				{
					this.class174_0.Class178_1 = new Class178(this.Class174_0.Class178_1.Double_0, this.Class174_0.Class178_1.Double_1, value.Width, value.Width, bool_1: false);
				}
			}
		}

		/// <summary>Gets or sets the shape's type.</summary>
		public ShapeType Type
		{
			get
			{
				return this.shapeType_0;
			}
			set
			{
				if (this.bool_3)
				{
					this.txdrawing_0.Selection_0.method_32();
				}
				bool flag;
				if (!(flag = this.shapeType_0 != value || this.Class183_0.ShapeObject_0 == null))
				{
					return;
				}
				this.Class174_0.method_12();
				this.shapeType_0 = value;
				this.class183_0.method_0(this.shapeType_0);
				if (this.bool_3)
				{
					this.Class183_0.ShapeObject_0 = this.txdrawing_0.method_75(this, this.shapeType_0);
					if (flag)
					{
						this.Class183_0.ShapeObject_0.CreateGraphicsPaths();
						this.Class174_0.method_1((Class174.Enum30)476);
						this.Class183_0.method_1();
						this.txdrawing_0.method_18(bool_5: true, bool_6: true, bool_7: true, bool_8: true);
					}
				}
			}
		}

		internal int Int32_4
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = ((value >= 0) ? (value % 360) : (360 - Math.Abs(value % 360)));
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

		internal Flip Flip_1
		{
			get
			{
				return this.flip_0;
			}
			set
			{
				this.flip_0 = value;
			}
		}

		internal int Int32_5
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

		internal bool Boolean_6
		{
			get
			{
				return this.bool_4;
			}
			set
			{
				this.bool_4 = value;
			}
		}

		internal bool Boolean_7
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
			}
		}

		internal bool Boolean_8
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				this.bool_2 = value;
			}
		}

		internal TXDrawing TXDrawing_0 => this.txdrawing_0;

		internal Class174 Class174_0 => this.class174_0;

		internal Class183 Class183_0 => this.class183_0;

		internal Fill Fill_0
		{
			get
			{
				return this.fill_0;
			}
			set
			{
				this.fill_0 = value;
			}
		}

		internal Outline Outline_0
		{
			get
			{
				return this.outline_0;
			}
			set
			{
				this.outline_0 = value;
			}
		}

		internal bool Boolean_9
		{
			get
			{
				return this.bool_7;
			}
			set
			{
				this.bool_7 = value;
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

		internal virtual void vmethod_0(string string_0)
		{
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs(string_0));
			}
		}

		internal void method_0()
		{
			this.Double_0 = new double[this.class174_0.Class172_0.Count];
			for (int i = 0; i < this.Double_0.Length; i++)
			{
				this.Double_0[i] = this.class174_0.Class172_0[i].Value;
			}
			this.Int32_0 = this.int_0;
			this.Boolean_0 = this.bool_0;
			this.Boolean_1 = this.class174_0.Boolean_0;
			this.Int32_1 = this.int_1;
			this.Int32_2 = this.fill_0.Color.ToArgb();
			this.Flip_0 = this.flip_0;
			this.Boolean_2 = this.bool_4;
			this.Class177_0 = this.class174_0.Class178_1.Class177_0;
			this.Boolean_3 = this.bool_5;
			this.Int32_3 = this.outline_0.Color.ToArgb();
			this.Double_1 = this.outline_0.Width;
			this.Boolean_4 = this.bool_6;
			this.Class179_0 = this.class174_0.Class178_1.Class179_0;
			this.ShapeType_0 = this.shapeType_0;
		}

		/// <summary>Creates a new instance of the Shape class by the ShapeType type ShapeType.Custom.</summary>
		public Shape()
		{
			this.method_1();
		}

		public Shape(ShapeType type)
		{
			this.shapeType_0 = type;
			this.method_1();
		}

		/// <summary>Expands the shape to the control's canvas size. The method has no effect if the CanFitToCanvas property returns false.</summary>
		public void FitToCanvas()
		{
			if (this.bool_3 && this.Class174_0.Boolean_0)
			{
				this.txdrawing_0.Selection_0.method_32();
				if (this.method_2())
				{
					this.txdrawing_0.method_18(bool_5: false, bool_6: true, bool_7: true, bool_8: true);
				}
			}
		}

		private void method_1()
		{
			this.fill_0 = new Fill(Color.FromArgb(255, 91, 155, 213), this);
			this.outline_0 = new Outline(Color.Black, 20, this);
			this.class174_0 = new Class174(this.shapeType_0, this);
			this.class183_0 = new Class183(this.shapeType_0, this);
			this.class174_0.Class172_0 = new Class172(this);
			this.Class183_0.Object_0 = new Matrix();
		}

		internal bool method_2()
		{
			if (this.Class174_0.Boolean_0)
			{
				if (this.bool_3)
				{
					this.Class174_0.method_18(this.Class174_0.Class178_0, bool_2: true, (Class174.Enum30)207, bool_3: false);
					return true;
				}
				this.bool_1 = true;
			}
			return false;
		}

		internal void method_3(TXDrawing txdrawing_1, bool bool_13)
		{
			this.bool_3 = true;
			this.txdrawing_0 = txdrawing_1;
			this.Class174_0.method_11(this.txdrawing_0);
			this.Class183_0.ShapeObject_0.CreateGraphicsPaths();
			if (bool_13)
			{
				this.Class174_0.method_1((Class174.Enum30)28);
				this.method_2();
			}
			else
			{
				this.Class174_0.method_18(this.Class174_0.Class178_1, bool_2: true, (Class174.Enum30)254, bool_3: false);
			}
		}

		internal bool method_4(int int_6)
		{
			if (this.int_0 != (this.int_0 = int_6) && this.bool_3)
			{
				this.Boolean_1 = this.txdrawing_0.IsCanvasVisible;
				this.Class174_0.method_1((Class174.Enum30)493);
				this.txdrawing_0.IsCanvasVisible = this.Boolean_1;
				this.Class183_0.method_1();
				return true;
			}
			return false;
		}

		internal bool method_5(bool bool_13)
		{
			if (this.bool_0 != (this.bool_0 = bool_13) && this.bool_3)
			{
				this.Class174_0.method_1((Class174.Enum30)386);
				this.method_9();
				return true;
			}
			return false;
		}

		internal bool method_6(Flip flip_2)
		{
			if (this.flip_0 != (this.flip_0 = flip_2) && this.bool_3)
			{
				this.Class174_0.method_1((Class174.Enum30)92);
				this.Class183_0.method_1();
				return true;
			}
			return false;
		}

		internal bool method_7(bool bool_13)
		{
			if (this.bool_5 != (this.bool_5 = bool_13))
			{
				return this.bool_3;
			}
			return false;
		}

		internal bool method_8(bool bool_13)
		{
			if (this.bool_6 != (this.bool_6 = bool_13))
			{
				return this.bool_3;
			}
			return false;
		}

		private void method_9()
		{
			if (this.bool_0)
			{
				if (this.txdrawing_0.IsCanvasVisible && this.txdrawing_0.ShapeCollection_0.Count == 1 && !this.Class174_0.Boolean_0 && this.txdrawing_0.BorderWidth == 0)
				{
					this.txdrawing_0.IsCanvasVisible = false;
				}
			}
			else if (!this.txdrawing_0.IsCanvasVisible)
			{
				this.txdrawing_0.IsCanvasVisible = true;
			}
		}
	}
}
