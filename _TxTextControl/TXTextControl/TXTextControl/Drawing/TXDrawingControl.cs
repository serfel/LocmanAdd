using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
using ns17;
using ns18;

namespace TXTextControl.Drawing
{
	/// <summary>The TXDrawingControl class implements a Windows Forms control with features to draw custom or predefined shapes.</summary>
	[ToolboxItem(false)]
	public class TXDrawingControl : Control, INotifyPropertyChanged
	{
		private enum Enum42
		{
			const_0 = 1,
			const_1,
			const_2,
			const_3,
			const_4,
			const_5,
			const_6,
			const_7,
			const_8,
			const_9,
			const_10,
			const_11
		}

		private enum Enum43
		{
			const_0 = 513,
			const_1 = 0x400,
			const_2 = 2062,
			const_3 = 2063,
			const_4 = 2064,
			const_5 = 2072
		}

		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TXDrawing));

		private Color color_0 = Color.DarkBlue;

		private Color color_1 = Color.LightBlue;

		private TXDrawing txdrawing_0;

		private bool bool_0;

		private bool bool_1;

		private ContextMenuStrip contextMenuStrip_0 = new ShapesContextMenuStrip();

		private ShapeCollection shapeCollection_0;

		private Selection selection_0;

		private Cursor cursor_0 = Cursors.Default;

		[Obfuscation(Exclude = true)]
		private static readonly object ShapeAdjustedEvent = new object();

		[Obfuscation(Exclude = true)]
		private static readonly object ShapeClickedEvent = new object();

		[Obfuscation(Exclude = true)]
		private static readonly object ShapeCreatedEvent = new object();

		[Obfuscation(Exclude = true)]
		private static readonly object ShapeDeletedEvent = new object();

		[Obfuscation(Exclude = true)]
		private static readonly object ShapeDeselectedEvent = new object();

		[Obfuscation(Exclude = true)]
		private static readonly object ShapeFlippedEvent = new object();

		[Obfuscation(Exclude = true)]
		private static readonly object ShapeFormatChangedEvent = new object();

		[Obfuscation(Exclude = true)]
		private static readonly object ShapeMovedEvent = new object();

		[Obfuscation(Exclude = true)]
		private static readonly object ShapeSelectedEvent = new object();

		[Obfuscation(Exclude = true)]
		private static readonly object ShapeSizedEvent = new object();

		private EventHandler eventHandler_0;

		[Obfuscation(Exclude = true)]
		private static readonly object ChangedEvent = new object();

		[Obfuscation(Exclude = true)]
		private static readonly object ViewChangedEvent = new object();

		[Obfuscation(Exclude = true)]
		private static readonly object PropertyChangedEvent = new object();

		[Obfuscation(Exclude = true)]
		private static readonly object AdaptBoundsEvent = new object();

		private Class177 class177_0 = new Class177(-1.0, -1.0, bool_1: false);

		/// <summary>Gets or sets the TX Drawing Control's back color.</summary>
		[DefaultValue(typeof(Color), "Transparent")]
		public override Color BackColor
		{
			get
			{
				return Converter.InternalToColor(this.txdrawing_0.BackColor);
			}
			set
			{
				this.txdrawing_0.BackColor = Converter.ColorToInternal(value);
				if (this.IsCanvasVisible)
				{
					this.txdrawing_0.method_77();
				}
			}
		}

		/// <summary>Gets or sets the TX Drawing Control's border line color.</summary>
		[DefaultValue(typeof(Color), "WindowText")]
		public Color BorderColor
		{
			get
			{
				return Converter.InternalToColor(this.txdrawing_0.BorderColor);
			}
			set
			{
				this.txdrawing_0.BorderColor = Converter.ColorToInternal(value);
				if (this.IsCanvasVisible && this.BorderWidth > 0)
				{
					this.txdrawing_0.method_77();
				}
			}
		}

		/// <summary>Gets or sets the TX Drawing Control's border line width.</summary>
		[DefaultValue(0)]
		public int BorderWidth
		{
			get
			{
				return this.txdrawing_0.BorderWidth;
			}
			set
			{
				int int32_ = this.txdrawing_0.BorderWidth;
				int num2 = (this.txdrawing_0.BorderWidth = value);
				if (int32_ != num2)
				{
					this.txdrawing_0.method_18(bool_5: true, bool_6: true, bool_7: true, bool_8: true);
				}
			}
		}

		/// <summary>Informs whether shapes are selected which can be copied to the internal clipboard.</summary>
		public bool CanCopy => this.txdrawing_0.CanCopy;

		/// <summary>Informs whether the internal clipboard contains shapes that can be pasted into the TX Drawing Control.</summary>
		public bool CanPaste => this.txdrawing_0.Boolean_1;

		/// <summary>Informs whether an operation can be re-done using the Redo method.</summary>
		public bool CanRedo => this.txdrawing_0.Boolean_2;

		/// <summary>Gets a value indicating whether the user can undo the previous operation in the TX Drawing Control.</summary>
		public bool CanUndo => this.txdrawing_0.Boolean_3;

		public override ContextMenuStrip ContextMenuStrip
		{
			get
			{
				return this.contextMenuStrip_0;
			}
			set
			{
				base.ContextMenuStrip = (this.contextMenuStrip_0 = value);
			}
		}

		public new Cursor Cursor
		{
			get
			{
				if (base.Visible)
				{
					return base.Cursor;
				}
				return this.cursor_0;
			}
			set
			{
				if (base.Visible)
				{
					base.Cursor = value;
				}
				else
				{
					this.cursor_0 = value;
				}
			}
		}

		/// <summary>Gets a value whether the TX Drawing Control is interpreted as canvas or not.</summary>
		public bool IsCanvasVisible => this.txdrawing_0.IsCanvasVisible;

		/// <summary>Gets an object of type Drawing.Selection that represents the current selected shapes inside the TX Drawing Control.</summary>
		public Selection Selection => this.selection_0;

		/// <summary>Gets an object of type ShapeCollection that represents those shapes which are displayed inside the TX Drawing Control.</summary>
		public ShapeCollection Shapes => this.shapeCollection_0;

		/// <summary>Gets or sets the zoom factor, in percent, for the TX Drawing Control.</summary>
		[DefaultValue(100)]
		public int ZoomFactor
		{
			get
			{
				return this.TXDrawing_0.ZoomFactor;
			}
			set
			{
				if (value == this.TXDrawing_0.ZoomFactor)
				{
					return;
				}
				if (this.Dock != 0)
				{
					throw new ArgumentException(this.resourceManager_0.GetString("ERR_INVALID_DOCKSTYLE"));
				}
				this.TXDrawing_0.ZoomFactor = value;
				foreach (Shape shape in this.Shapes)
				{
					shape.Class174_0.method_1(Class174.Enum30.const_1);
					shape.Class183_0.method_1();
				}
				this.txdrawing_0.Class179_0 = new Class179((int)MeasuringHelper.ZoomValue(this.txdrawing_0.Class178_1.Double_3, this.ZoomFactor, viseVersa: false), (int)MeasuringHelper.ZoomValue(this.txdrawing_0.Class178_1.Double_2, this.ZoomFactor, viseVersa: false), bool_1: false);
				this.bool_0 = true;
				base.Size = new Size((int)MeasuringHelper.Twips2Pixels(this.txdrawing_0.Class179_0.Double_1, 100), (int)MeasuringHelper.Twips2Pixels(this.txdrawing_0.Class179_0.Double_0, 100));
				this.bool_0 = false;
				this.txdrawing_0.method_77();
			}
		}

		internal TXDrawing TXDrawing_0 => this.txdrawing_0;

		/// <summary>Occurs when a shape has been adjusted by using its yellow adjust rectangle.</summary>
		public event ShapeEventHandler ShapeAdjusted
		{
			add
			{
				base.Events.AddHandler(TXDrawingControl.ShapeAdjustedEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(TXDrawingControl.ShapeAdjustedEvent, value);
			}
		}

		/// <summary>Occurs when a shape has been clicked on.</summary>
		public event ShapeEventHandler ShapeClicked
		{
			add
			{
				base.Events.AddHandler(TXDrawingControl.ShapeClickedEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(TXDrawingControl.ShapeClickedEvent, value);
			}
		}

		/// <summary>Occurs when a new shape has been created.</summary>
		public event ShapeEventHandler ShapeCreated
		{
			add
			{
				base.Events.AddHandler(TXDrawingControl.ShapeCreatedEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(TXDrawingControl.ShapeCreatedEvent, value);
			}
		}

		/// <summary>Occurs when a shape has been deleted from the TX Drawing Control's shapes collection.</summary>
		public event ShapeEventHandler ShapeDeleted
		{
			add
			{
				base.Events.AddHandler(TXDrawingControl.ShapeDeletedEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(TXDrawingControl.ShapeDeletedEvent, value);
			}
		}

		/// <summary>Occurs when a shape has been deselected.</summary>
		public event ShapeEventHandler ShapeDeselected
		{
			add
			{
				base.Events.AddHandler(TXDrawingControl.ShapeDeselectedEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(TXDrawingControl.ShapeDeselectedEvent, value);
			}
		}

		/// <summary>Occurs when a shape has been flipped.</summary>
		public event ShapeEventHandler ShapeFlipped
		{
			add
			{
				base.Events.AddHandler(TXDrawingControl.ShapeFlippedEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(TXDrawingControl.ShapeFlippedEvent, value);
			}
		}

		/// <summary>Occurs when shape formatting attributes which cannot be handled with the built-in mouse interface have been changed.</summary>
		public event ShapeEventHandler ShapeFormatChanged
		{
			add
			{
				base.Events.AddHandler(TXDrawingControl.ShapeFormatChangedEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(TXDrawingControl.ShapeFormatChangedEvent, value);
			}
		}

		/// <summary>Occurs when a shape has been moved with the built-in mouse interface.</summary>
		public event ShapeEventHandler ShapeMoved
		{
			add
			{
				base.Events.AddHandler(TXDrawingControl.ShapeMovedEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(TXDrawingControl.ShapeMovedEvent, value);
			}
		}

		/// <summary>Occurs when a shape has been selected.</summary>
		public event ShapeEventHandler ShapeSelected
		{
			add
			{
				base.Events.AddHandler(TXDrawingControl.ShapeSelectedEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(TXDrawingControl.ShapeSelectedEvent, value);
			}
		}

		/// <summary>Occurs when a shape has been sized with the built-in mouse interface.</summary>
		public event ShapeEventHandler ShapeSized
		{
			add
			{
				base.Events.AddHandler(TXDrawingControl.ShapeSizedEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(TXDrawingControl.ShapeSizedEvent, value);
			}
		}

		internal event EventHandler ChangedInternal
		{
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

		/// <summary>Indicates that the number or formatting of the displayed shapes has been changed.</summary>
		public event EventHandler Changed
		{
			add
			{
				base.Events.AddHandler(TXDrawingControl.ChangedEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(TXDrawingControl.ChangedEvent, value);
			}
		}

		/// <summary>Occurs when UI manipulations such as shape moving or selection changing have caused the view to change.</summary>
		public event ViewChangedEventHandler ViewChanged
		{
			add
			{
				base.Events.AddHandler(TXDrawingControl.ViewChangedEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(TXDrawingControl.ViewChangedEvent, value);
			}
		}

		public event PropertyChangedEventHandler PropertyChanged
		{
			add
			{
				base.Events.AddHandler(TXDrawingControl.PropertyChangedEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(TXDrawingControl.PropertyChangedEvent, value);
			}
		}

		/// <summary>Indicates that the visible bounds of the displayed shapes have been changed (by changing the shape's angle, outline width, yellow adjust rectangles or the control's border width) in so far that the control requires an update of its bounds.</summary>
		public event EventHandler AdaptBounds
		{
			add
			{
				base.Events.AddHandler(TXDrawingControl.AdaptBoundsEvent, value);
			}
			remove
			{
				base.Events.RemoveHandler(TXDrawingControl.AdaptBoundsEvent, value);
			}
		}

		/// <summary>Initializes a new instance of the TXDrawingControl class.</summary>
		public TXDrawingControl()
		{
			this.method_0(1134, 1134);
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			base.OnHandleCreated(eventArgs_0);
		}

		public TXDrawingControl(int width, int height)
		{
			this.method_0(width, height);
		}

		private void method_0(int int_0, int int_1)
		{
			if (int_0 < 0 || int_1 < 0)
			{
				throw new ArgumentException(this.resourceManager_0.GetString("ERR_NEGATIVE_SHAPE_SIZE"));
			}
			this.txdrawing_0 = new TXDrawing(this);
			this.selection_0 = this.txdrawing_0.Selection_0;
			this.shapeCollection_0 = this.txdrawing_0.ShapeCollection_0;
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			Helper.DPI = (int)base.CreateGraphics().DpiX;
			((ShapesContextMenuStrip)this.contextMenuStrip_0).method_1(this);
			this.txdrawing_0.Class178_1 = new Class178(0.0, 0.0, int_0, int_1, bool_1: false);
			this.txdrawing_0.Class179_0 = new Class179((int)MeasuringHelper.ZoomValue(this.txdrawing_0.Class178_1.Double_3, this.ZoomFactor, viseVersa: false), (int)MeasuringHelper.ZoomValue(this.txdrawing_0.Class178_1.Double_2, this.ZoomFactor, viseVersa: false), bool_1: false);
			base.Size = new Size((int)MeasuringHelper.Twips2Pixels(int_0, this.ZoomFactor), (int)MeasuringHelper.Twips2Pixels(int_1, this.ZoomFactor));
		}

		protected override void OnPaint(PaintEventArgs pea)
		{
			pea.Graphics.PixelOffsetMode = PixelOffsetMode.None;
			pea.Graphics.FillRectangle(new SolidBrush(Color.White), pea.ClipRectangle);
			if (this.IsCanvasVisible)
			{
				pea.Graphics.FillRectangle(new SolidBrush(this.BackColor), pea.ClipRectangle);
			}
			RectangleF rectangleF = new RectangleF((float)MeasuringHelper.Twips2Pixels(this.txdrawing_0.Class178_0.Double_0, this.ZoomFactor), (float)MeasuringHelper.Twips2Pixels(this.txdrawing_0.Class178_0.Double_1, this.ZoomFactor), (float)MeasuringHelper.Twips2Pixels(this.txdrawing_0.Class178_0.Double_3, this.ZoomFactor), (float)MeasuringHelper.Twips2Pixels(this.txdrawing_0.Class178_0.Double_2, this.ZoomFactor));
			if (this.IsCanvasVisible && this.BorderWidth > 0)
			{
				pea.Graphics.DrawRectangle(new Pen(new SolidBrush(this.BorderColor), (float)MeasuringHelper.Twips2Pixels(this.BorderWidth, this.ZoomFactor)), rectangleF.X, rectangleF.Y, rectangleF.Width - 1f, rectangleF.Height - 1f);
			}
			pea.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
			pea.Graphics.SmoothingMode = SmoothingMode.HighQuality;
			this.method_7(pea.Graphics, bool_2: true, 1.0);
			Pen pen = new Pen(new SolidBrush(Color.FromArgb(127, 127, 127)), 1f);
			pen.DashStyle = DashStyle.Dash;
			pen.DashPattern = new float[2] { 9f, 3f };
			pea.Graphics.PixelOffsetMode = PixelOffsetMode.None;
			pea.Graphics.DrawRectangle(pen, 0, 0, base.Width - 1, base.Height - 1);
			if (this.txdrawing_0.Selection_0.Class178_0 != null)
			{
				Flip flip;
				Class178 @class = Helper.ConvertToValidBounds(this.txdrawing_0.Selection_0.Class178_0, out flip);
				pea.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black), 2f), (float)MeasuringHelper.Twips2Pixels(@class.Double_0, this.ZoomFactor), (float)MeasuringHelper.Twips2Pixels(@class.Double_1, this.ZoomFactor), (float)MeasuringHelper.Twips2Pixels(@class.Double_3, this.ZoomFactor), (float)MeasuringHelper.Twips2Pixels(@class.Double_2, this.ZoomFactor));
			}
			base.OnPaint(pea);
		}

		protected override void OnResize(EventArgs eventArgs_0)
		{
			if (base.Width <= 0)
			{
				base.Width = 1;
			}
			if (base.Height <= 0)
			{
				base.Height = 1;
			}
			base.OnResize(eventArgs_0);
		}

		[Obfuscation(Exclude = true)]
		internal double[] CalculateGraphicsPathsOffset(Shape shape, Class179 shapeSize, Class177 rotationCenter)
		{
			try
			{
				float scaleX = (float)(shapeSize.Double_1 / shape.Class183_0.Class179_0.Double_3);
				float scaleY = (float)(shapeSize.Double_0 / shape.Class183_0.Class179_0.Double_2);
				bool flag = (shape.Flip & Flip.Horizontal) == Flip.Horizontal;
				bool flag2 = (shape.Flip & Flip.Vertical) == Flip.Vertical;
				float m = ((!flag) ? 1 : (-1));
				float m2 = ((!flag2) ? 1 : (-1));
				float offsetX = (flag ? ((float)shapeSize.Double_1) : 0f);
				float offsetY = (flag2 ? ((float)shapeSize.Double_0) : 0f);
				Matrix matrix = new Matrix(m, 0f, 0f, m2, 0f, 0f);
				matrix.Scale(scaleX, scaleY);
				matrix.Translate(offsetX, offsetY, MatrixOrder.Append);
				matrix.RotateAt(shape.Angle, new PointF((float)rotationCenter.Double_0, (float)rotationCenter.Double_1), MatrixOrder.Append);
				double[] array = new double[4] { 2147483647.0, 2147483647.0, -2147483648.0, -2147483648.0 };
				Pen pen = new Pen(Color.FromArgb(shape.ShapeOutline.Color.A, shape.ShapeOutline.Color.R, shape.ShapeOutline.Color.G, shape.ShapeOutline.Color.B), shape.ShapeOutline.Width);
				pen.Color = Color.Blue;
				Class175[] class175_ = shape.Class183_0.Class175_0;
				foreach (Class175 @class in class175_)
				{
					if (!@class.Boolean_0)
					{
						continue;
					}
					foreach (GraphicsPath item in @class.List_0)
					{
						GraphicsPath graphicsPath2 = (GraphicsPath)item.Clone();
						graphicsPath2.Transform(matrix);
						graphicsPath2.Widen(pen);
						RectangleF bounds = graphicsPath2.GetBounds();
						this.method_1(array, bounds);
					}
				}
				return new double[4]
				{
					array[0],
					array[1],
					array[2] - shapeSize.Double_1,
					array[3] - shapeSize.Double_0
				};
			}
			catch
			{
				return new double[4];
			}
		}

		private void method_1(double[] double_0, RectangleF rectangleF_0)
		{
			if ((double)rectangleF_0.Left < double_0[0])
			{
				double_0[0] = rectangleF_0.Left;
			}
			if ((double)rectangleF_0.Top < double_0[1])
			{
				double_0[1] = rectangleF_0.Top;
			}
			if ((double)rectangleF_0.Right > double_0[2])
			{
				double_0[2] = rectangleF_0.Right;
			}
			if ((double)rectangleF_0.Bottom > double_0[3])
			{
				double_0[3] = rectangleF_0.Bottom;
			}
		}

		[Obfuscation(Exclude = true)]
		internal bool Contains(Shape shape, Class177 ipntCurrentPosition)
		{
			try
			{
				Pen pen = new Pen(new SolidBrush(Color.FromArgb(shape.ShapeOutline.Color.A, shape.ShapeOutline.Color.R, shape.ShapeOutline.Color.G, shape.ShapeOutline.Color.B)), (float)MeasuringHelper.Twips2Pixels(shape.ShapeOutline.Width + 200, 100));
				Class175[] class175_ = shape.Class183_0.Class175_0;
				foreach (Class175 @class in class175_)
				{
					foreach (GraphicsPath item in @class.List_0)
					{
						GraphicsPath graphicsPath2 = (GraphicsPath)item.Clone();
						graphicsPath2.Transform((Matrix)shape.Class183_0.Object_0);
						if (!graphicsPath2.IsVisible((int)ipntCurrentPosition.Double_0, (int)ipntCurrentPosition.Double_1))
						{
							graphicsPath2.Widen(pen);
							if (graphicsPath2.IsVisible((int)ipntCurrentPosition.Double_0, (int)ipntCurrentPosition.Double_1))
							{
								return true;
							}
							continue;
						}
						return true;
					}
				}
			}
			catch
			{
			}
			return false;
		}

		[Obfuscation(Exclude = true)]
		internal ShapeObject CreateShapeObjectByType(Shape shape, ShapeType type)
		{
			return this.method_2(shape, type);
		}

		[Obfuscation(Exclude = true)]
		internal void UpdateMatrix(Shape shape, double widthFactor, double heightFactor)
		{
			float num = (float)MeasuringHelper.Twips2Pixels(shape.Class174_0.Class178_1.Double_3, this.txdrawing_0.ZoomFactor) / (float)shape.Class183_0.Class179_0.Double_3;
			float num2 = (float)MeasuringHelper.Twips2Pixels(shape.Class174_0.Class178_1.Double_2, this.txdrawing_0.ZoomFactor) / (float)shape.Class183_0.Class179_0.Double_2;
			bool flag = (shape.Flip & Flip.Horizontal) == Flip.Horizontal;
			bool flag2 = (shape.Flip & Flip.Vertical) == Flip.Vertical;
			float m = ((!flag) ? 1 : (-1));
			float m2 = ((!flag2) ? 1 : (-1));
			float offsetX = (flag ? ((float)MeasuringHelper.Twips2Pixels(shape.Class174_0.Class178_1.Double_3 * widthFactor, this.txdrawing_0.ZoomFactor)) : 0f);
			float offsetY = (flag2 ? ((float)MeasuringHelper.Twips2Pixels(shape.Class174_0.Class178_1.Double_2 * heightFactor, this.txdrawing_0.ZoomFactor)) : 0f);
			Matrix matrix = new Matrix(m, 0f, 0f, m2, 0f, 0f);
			matrix.Scale(num * (float)widthFactor, num2 * (float)heightFactor);
			matrix.Translate(offsetX, offsetY, MatrixOrder.Append);
			matrix.RotateAt(shape.Angle, new PointF((float)(MeasuringHelper.Twips2Pixels(shape.Class174_0.Class177_5.Double_0 - shape.Class174_0.Class178_1.Double_0, this.txdrawing_0.ZoomFactor) * (double)(float)widthFactor), (float)MeasuringHelper.Twips2Pixels(shape.Class174_0.Class177_5.Double_1 - shape.Class174_0.Class178_1.Double_1, this.txdrawing_0.ZoomFactor) * (float)heightFactor), MatrixOrder.Append);
			float offsetX2 = (float)MeasuringHelper.Twips2Pixels(shape.Class174_0.Class178_1.Double_0 * widthFactor, this.txdrawing_0.ZoomFactor);
			float offsetY2 = (float)MeasuringHelper.Twips2Pixels(shape.Class174_0.Class178_1.Double_1 * heightFactor, this.txdrawing_0.ZoomFactor);
			matrix.Translate(offsetX2, offsetY2, MatrixOrder.Append);
			shape.Class183_0.Object_0 = matrix;
		}

		private ShapeObject method_2(Shape shape_0, ShapeType shapeType_0)
		{
			return shapeType_0 switch
			{
				ShapeType.Line => new Class304(shape_0), 
				ShapeType.LineInverse => new Class305(shape_0), 
				ShapeType.Triangle => new Class360(shape_0), 
				ShapeType.RightTriangle => new Class337(shape_0), 
				ShapeType.Rectangle => new Class326(shape_0), 
				ShapeType.Diamond => new Class241(shape_0), 
				ShapeType.Parallelogram => new Class317(shape_0), 
				ShapeType.Trapezoid => new Class359(shape_0), 
				ShapeType.NonIsoscelesTrapezoid => new Class313(shape_0), 
				ShapeType.Pentagon => new Class318(shape_0), 
				ShapeType.Hexagon => new Class287(shape_0), 
				ShapeType.Heptagon => new Class286(shape_0), 
				ShapeType.Octagon => new Class316(shape_0), 
				ShapeType.Decagon => new Class239(shape_0), 
				ShapeType.Dodecagon => new Class242(shape_0), 
				ShapeType.Star4 => new Class349(shape_0), 
				ShapeType.Star5 => new Class350(shape_0), 
				ShapeType.Star6 => new Class351(shape_0), 
				ShapeType.Star7 => new Class352(shape_0), 
				ShapeType.Star8 => new Class353(shape_0), 
				ShapeType.Star10 => new Class344(shape_0), 
				ShapeType.Star12 => new Class345(shape_0), 
				ShapeType.Star16 => new Class346(shape_0), 
				ShapeType.Star24 => new Class347(shape_0), 
				ShapeType.Star32 => new Class348(shape_0), 
				ShapeType.RoundRectangle => new Class336(shape_0), 
				ShapeType.Round1Rectangle => new Class333(shape_0), 
				ShapeType.Round2SameRectangle => new Class335(shape_0), 
				ShapeType.Round2DiagonalRectangle => new Class334(shape_0), 
				ShapeType.SnipRoundRectangle => new Class342(shape_0), 
				ShapeType.Snip1Rectangle => new Class339(shape_0), 
				ShapeType.Snip2SameRectangle => new Class341(shape_0), 
				ShapeType.Snip2DiagonalRectangle => new Class340(shape_0), 
				ShapeType.Plaque => new Class321(shape_0), 
				ShapeType.Ellipse => new Class247(shape_0), 
				ShapeType.Teardrop => new Class358(shape_0), 
				ShapeType.HomePlate => new Class288(shape_0), 
				ShapeType.Chevron => new Class223(shape_0), 
				ShapeType.PieWedge => new Class320(shape_0), 
				ShapeType.Pie => new Class319(shape_0), 
				ShapeType.BlockArc => new Class210(shape_0), 
				ShapeType.Donut => new Class243(shape_0), 
				ShapeType.NoSmoking => new Class314(shape_0), 
				ShapeType.RightArrow => new Class329(shape_0), 
				ShapeType.LeftArrow => new Class292(shape_0), 
				ShapeType.UpArrow => new Class361(shape_0), 
				ShapeType.DownArrow => new Class245(shape_0), 
				ShapeType.StripedRightArrow => new Class355(shape_0), 
				ShapeType.NotchedRightArrow => new Class315(shape_0), 
				ShapeType.BentUpArrow => new Class208(shape_0), 
				ShapeType.LeftRightArrow => new Class297(shape_0), 
				ShapeType.UpDownArrow => new Class363(shape_0), 
				ShapeType.LeftUpArrow => new Class302(shape_0), 
				ShapeType.LeftRightUpArrow => new Class301(shape_0), 
				ShapeType.QuadArrow => new Class324(shape_0), 
				ShapeType.LeftArrowCallout => new Class293(shape_0), 
				ShapeType.RightArrowCallout => new Class330(shape_0), 
				ShapeType.UpArrowCallout => new Class362(shape_0), 
				ShapeType.DownArrowCallout => new Class246(shape_0), 
				ShapeType.LeftRightArrowCallout => new Class298(shape_0), 
				ShapeType.UpDownArrowCallout => new Class364(shape_0), 
				ShapeType.QuadArrowCallout => new Class325(shape_0), 
				ShapeType.BentArrow => new Class203(shape_0), 
				ShapeType.UTurnArrow => new Class365(shape_0), 
				ShapeType.CircularArrow => new Class225(shape_0), 
				ShapeType.LeftCircularArrow => new Class296(shape_0), 
				ShapeType.LeftRightCircularArrow => new Class299(shape_0), 
				ShapeType.CurvedRightArrow => new Class237(shape_0), 
				ShapeType.CurvedLeftArrow => new Class236(shape_0), 
				ShapeType.CurvedUpArrow => new Class238(shape_0), 
				ShapeType.CurvedDownArrow => new Class235(shape_0), 
				ShapeType.SwooshArrow => new Class357(shape_0), 
				ShapeType.Cube => new Class230(shape_0), 
				ShapeType.Can => new Class219(shape_0), 
				ShapeType.LightningBolt => new Class303(shape_0), 
				ShapeType.Heart => new Class285(shape_0), 
				ShapeType.Sun => new Class356(shape_0), 
				ShapeType.Moon => new Class312(shape_0), 
				ShapeType.SmileyFace => new Class338(shape_0), 
				ShapeType.IrregularSeal1 => new Class290(shape_0), 
				ShapeType.IrregularSeal2 => new Class291(shape_0), 
				ShapeType.FoldedCorner => new Class279(shape_0), 
				ShapeType.Bevel => new Class209(shape_0), 
				ShapeType.Frame => new Class280(shape_0), 
				ShapeType.HalfFrame => new Class284(shape_0), 
				ShapeType.Corner => new Class228(shape_0), 
				ShapeType.DiagonalStripe => new Class240(shape_0), 
				ShapeType.Chord => new Class224(shape_0), 
				ShapeType.Arc => new Class202(shape_0), 
				ShapeType.LeftBracket => new Class295(shape_0), 
				ShapeType.RightBracket => new Class332(shape_0), 
				ShapeType.LeftBrace => new Class294(shape_0), 
				ShapeType.RightBrace => new Class331(shape_0), 
				ShapeType.BracketPair => new Class215(shape_0), 
				ShapeType.BracePair => new Class214(shape_0), 
				ShapeType.StraightConnector1 => new Class354(shape_0), 
				ShapeType.BentConnector2 => new Class204(shape_0), 
				ShapeType.BentConnector3 => new Class205(shape_0), 
				ShapeType.BentConnector4 => new Class206(shape_0), 
				ShapeType.BentConnector5 => new Class207(shape_0), 
				ShapeType.CurvedConnector2 => new Class231(shape_0), 
				ShapeType.CurvedConnector3 => new Class232(shape_0), 
				ShapeType.CurvedConnector4 => new Class233(shape_0), 
				ShapeType.CurvedConnector5 => new Class234(shape_0), 
				ShapeType.Callout1 => new Class216(shape_0), 
				ShapeType.Callout2 => new Class217(shape_0), 
				ShapeType.Callout3 => new Class218(shape_0), 
				ShapeType.AccentCallout1 => new Class187(shape_0), 
				ShapeType.AccentCallout2 => new Class188(shape_0), 
				ShapeType.AccentCallout3 => new Class189(shape_0), 
				ShapeType.BorderCallout1 => new Class211(shape_0), 
				ShapeType.BorderCallout2 => new Class212(shape_0), 
				ShapeType.BorderCallout3 => new Class213(shape_0), 
				ShapeType.AccentBorderCallout1 => new Class184(shape_0), 
				ShapeType.AccentBorderCallout2 => new Class185(shape_0), 
				ShapeType.AccentBorderCallout3 => new Class186(shape_0), 
				ShapeType.WedgeRectangleCallout => new Class369(shape_0), 
				ShapeType.WedgeRoundRectangleCallout => new Class370(shape_0), 
				ShapeType.WedgeEllipseCallout => new Class368(shape_0), 
				ShapeType.CloudCallout => new Class227(shape_0), 
				ShapeType.Cloud => new Class226(shape_0), 
				ShapeType.Ribbon => new Class327(shape_0), 
				ShapeType.Ribbon2 => new Class328(shape_0), 
				ShapeType.EllipseRibbon => new Class248(shape_0), 
				ShapeType.EllipseRibbon2 => new Class249(shape_0), 
				ShapeType.LeftRightRibbon => new Class300(shape_0), 
				ShapeType.VerticalScroll => new Class366(shape_0), 
				ShapeType.HorizontalScroll => new Class289(shape_0), 
				ShapeType.Wave => new Class367(shape_0), 
				ShapeType.DoubleWave => new Class244(shape_0), 
				ShapeType.Plus => new Class323(shape_0), 
				ShapeType.FlowChartProcess => new Class273(shape_0), 
				ShapeType.FlowChartDecision => new Class253(shape_0), 
				ShapeType.FlowChartInputOutput => new Class258(shape_0), 
				ShapeType.FlowChartPredefinedProcess => new Class271(shape_0), 
				ShapeType.FlowChartInternalStorage => new Class259(shape_0), 
				ShapeType.FlowChartDocument => new Class256(shape_0), 
				ShapeType.FlowChartMultidocument => new Class266(shape_0), 
				ShapeType.FlowChartTerminator => new Class278(shape_0), 
				ShapeType.FlowChartPreparation => new Class272(shape_0), 
				ShapeType.FlowChartManualInput => new Class263(shape_0), 
				ShapeType.FlowChartManualOperation => new Class264(shape_0), 
				ShapeType.FlowChartConnector => new Class252(shape_0), 
				ShapeType.FlowChartPunchedCard => new Class274(shape_0), 
				ShapeType.FlowChartPunchedTape => new Class275(shape_0), 
				ShapeType.FlowChartSummingJunction => new Class277(shape_0), 
				ShapeType.FlowChartOr => new Class270(shape_0), 
				ShapeType.FlowChartCollate => new Class251(shape_0), 
				ShapeType.FlowChartSort => new Class276(shape_0), 
				ShapeType.FlowChartExtract => new Class257(shape_0), 
				ShapeType.FlowChartMerge => new Class265(shape_0), 
				ShapeType.FlowChartOfflineStorage => new Class267(shape_0), 
				ShapeType.FlowChartOnlineStorage => new Class269(shape_0), 
				ShapeType.FlowChartMagneticTape => new Class262(shape_0), 
				ShapeType.FlowChartMagneticDisk => new Class260(shape_0), 
				ShapeType.FlowChartMagneticDrum => new Class261(shape_0), 
				ShapeType.FlowChartDisplay => new Class255(shape_0), 
				ShapeType.FlowChartDelay => new Class254(shape_0), 
				ShapeType.FlowChartAlternateProcess => new Class250(shape_0), 
				ShapeType.FlowChartOffpageConnector => new Class268(shape_0), 
				ShapeType.ActionButtonBlank => new Class192(shape_0), 
				ShapeType.ActionButtonHome => new Class197(shape_0), 
				ShapeType.ActionButtonHelp => new Class196(shape_0), 
				ShapeType.ActionButtonInformation => new Class198(shape_0), 
				ShapeType.ActionButtonForwardNext => new Class195(shape_0), 
				ShapeType.ActionButtonBackPrevious => new Class190(shape_0), 
				ShapeType.ActionButtonEnd => new Class194(shape_0), 
				ShapeType.ActionButtonBeginning => new Class191(shape_0), 
				ShapeType.ActionButtonReturn => new Class200(shape_0), 
				ShapeType.ActionButtonDocument => new Class193(shape_0), 
				ShapeType.ActionButtonSound => new Class201(shape_0), 
				ShapeType.ActionButtonMovie => new Class199(shape_0), 
				ShapeType.Gear6 => new Class282(shape_0), 
				ShapeType.Gear9 => new Class283(shape_0), 
				ShapeType.Funnel => new Class281(shape_0), 
				ShapeType.MathPlus => new Class311(shape_0), 
				ShapeType.MathMinus => new Class308(shape_0), 
				ShapeType.MathMultiply => new Class309(shape_0), 
				ShapeType.MathDivide => new Class306(shape_0), 
				ShapeType.MathEqual => new Class307(shape_0), 
				ShapeType.MathNotEqual => new Class310(shape_0), 
				ShapeType.CornerTabs => new Class229(shape_0), 
				ShapeType.SquareTabs => new Class343(shape_0), 
				ShapeType.PlaqueTabs => new Class322(shape_0), 
				ShapeType.ChartX => new Class222(shape_0), 
				ShapeType.ChartStar => new Class221(shape_0), 
				ShapeType.ChartPlus => new Class220(shape_0), 
				_ => null, 
			};
		}

		[Obfuscation(Exclude = true)]
		internal bool OnAdaptBounds()
		{
			EventHandler eventHandler = (EventHandler)base.Events[TXDrawingControl.AdaptBoundsEvent];
			if (eventHandler != null && this.method_14())
			{
				EventArgs e = new EventArgs();
				eventHandler(this, e);
				return true;
			}
			return false;
		}

		[Obfuscation(Exclude = true)]
		internal bool OnChanged()
		{
			if (this.eventHandler_0 != null)
			{
				EventArgs e = new EventArgs();
				this.eventHandler_0(this, e);
			}
			EventHandler eventHandler = (EventHandler)base.Events[TXDrawingControl.ChangedEvent];
			if (eventHandler != null)
			{
				EventArgs e2 = new EventArgs();
				eventHandler(this, e2);
				return true;
			}
			return false;
		}

		[Obfuscation(Exclude = true)]
		internal bool OnViewChanged(Class178 clipRectangle)
		{
			ViewChangedEventHandler viewChangedEventHandler = (ViewChangedEventHandler)base.Events[TXDrawingControl.ViewChangedEvent];
			if (viewChangedEventHandler != null)
			{
				ViewChangedEventArgs e = new ViewChangedEventArgs(clipRectangle, this.ZoomFactor, isWPF: false);
				viewChangedEventHandler(this, e);
				return true;
			}
			return false;
		}

		[Obfuscation(Exclude = true)]
		internal bool OnShapeAdjusted(Shape shape)
		{
			if (!MeasuringHelper.AreEqual(shape.Class174_0.Class172_0.Double_0, shape.Double_0))
			{
				shape.Double_0 = shape.Class174_0.Class172_0.Double_0;
				shape.Class174_0.method_1((Class174.Enum30)76);
				ShapeEventHandler shapeEventHandler = (ShapeEventHandler)base.Events[TXDrawingControl.ShapeAdjustedEvent];
				if (shapeEventHandler != null)
				{
					ShapeEventArgs e = new ShapeEventArgs(shape);
					shapeEventHandler(this, e);
				}
				return true;
			}
			return false;
		}

		[Obfuscation(Exclude = true)]
		internal bool OnShapeClicked(Shape shape)
		{
			ShapeEventHandler shapeEventHandler = (ShapeEventHandler)base.Events[TXDrawingControl.ShapeClickedEvent];
			if (shapeEventHandler != null)
			{
				ShapeEventArgs e = new ShapeEventArgs(shape);
				shapeEventHandler(this, e);
				return true;
			}
			return false;
		}

		[Obfuscation(Exclude = true)]
		internal bool OnShapeCreated(Shape shape)
		{
			EventHandler eventHandler = (EventHandler)base.Events[TXDrawingControl.ChangedEvent];
			ShapeEventHandler shapeEventHandler = (ShapeEventHandler)base.Events[TXDrawingControl.ShapeCreatedEvent];
			if (shapeEventHandler == null && eventHandler == null)
			{
				return false;
			}
			if (shapeEventHandler != null)
			{
				ShapeEventArgs e = new ShapeEventArgs(shape);
				shapeEventHandler(this, e);
			}
			return true;
		}

		[Obfuscation(Exclude = true)]
		internal bool OnShapeDeleted(Shape shape)
		{
			EventHandler eventHandler = (EventHandler)base.Events[TXDrawingControl.ChangedEvent];
			ShapeEventHandler shapeEventHandler = (ShapeEventHandler)base.Events[TXDrawingControl.ShapeDeletedEvent];
			if (shapeEventHandler == null && eventHandler == null)
			{
				return false;
			}
			if (shapeEventHandler != null)
			{
				ShapeEventArgs e = new ShapeEventArgs(shape);
				shapeEventHandler(this, e);
			}
			return true;
		}

		[Obfuscation(Exclude = true)]
		internal bool OnShapeDeselected(Shape shape)
		{
			ShapeEventHandler shapeEventHandler = (ShapeEventHandler)base.Events[TXDrawingControl.ShapeDeselectedEvent];
			if (shapeEventHandler != null)
			{
				ShapeEventArgs e = new ShapeEventArgs(shape);
				shapeEventHandler(this, e);
				return true;
			}
			return false;
		}

		[Obfuscation(Exclude = true)]
		internal bool OnShapeFlipped(Shape shape)
		{
			if (shape.Flip != shape.Flip_0)
			{
				shape.Flip_0 = shape.Flip;
				ShapeEventHandler shapeEventHandler = (ShapeEventHandler)base.Events[TXDrawingControl.ShapeFlippedEvent];
				if (shapeEventHandler != null)
				{
					ShapeEventArgs e = new ShapeEventArgs(shape);
					shapeEventHandler(this, e);
				}
				return true;
			}
			return false;
		}

		[Obfuscation(Exclude = true)]
		internal bool OnShapeFormatChanged(Shape shape)
		{
			ShapeEventHandler shapeEventHandler = (ShapeEventHandler)base.Events[TXDrawingControl.ShapeFormatChangedEvent];
			if (shapeEventHandler != null)
			{
				ShapeEventArgs e = new ShapeEventArgs(shape);
				shapeEventHandler(this, e);
				return true;
			}
			return false;
		}

		[Obfuscation(Exclude = true)]
		internal bool OnShapeMoved(Shape shape)
		{
			ShapeEventHandler shapeEventHandler = (ShapeEventHandler)base.Events[TXDrawingControl.ShapeMovedEvent];
			if (shapeEventHandler != null)
			{
				ShapeEventArgs e = new ShapeEventArgs(shape);
				shapeEventHandler(this, e);
				return true;
			}
			return false;
		}

		[Obfuscation(Exclude = true)]
		internal bool OnShapeSelected(Shape shape)
		{
			ShapeEventHandler shapeEventHandler = (ShapeEventHandler)base.Events[TXDrawingControl.ShapeSelectedEvent];
			if (shapeEventHandler != null)
			{
				ShapeEventArgs e = new ShapeEventArgs(shape);
				shapeEventHandler(this, e);
				return true;
			}
			return false;
		}

		[Obfuscation(Exclude = true)]
		internal bool OnShapeSized(Shape shape)
		{
			ShapeEventHandler shapeEventHandler = (ShapeEventHandler)base.Events[TXDrawingControl.ShapeSizedEvent];
			if (shapeEventHandler != null)
			{
				ShapeEventArgs e = new ShapeEventArgs(shape);
				shapeEventHandler(this, e);
				return true;
			}
			return false;
		}

		protected override void OnKeyDown(KeyEventArgs keyEventArgs_0)
		{
			if (keyEventArgs_0.Control)
			{
				switch (keyEventArgs_0.KeyCode)
				{
				case Keys.V:
					if (this.CanPaste)
					{
						this.txdrawing_0.method_16(this.txdrawing_0.MemoryStream_0);
						this.txdrawing_0.method_18(bool_5: true, bool_6: true, bool_7: true, bool_8: true);
					}
					break;
				case Keys.X:
					if (this.txdrawing_0.method_15())
					{
						this.txdrawing_0.method_18(bool_5: false, bool_6: true, bool_7: true, bool_8: true);
					}
					break;
				case Keys.Y:
					if (this.txdrawing_0.method_82(bool_5: true))
					{
						this.txdrawing_0.method_77();
					}
					break;
				case Keys.Z:
					if (this.txdrawing_0.method_83(bool_5: true))
					{
						this.txdrawing_0.method_77();
					}
					break;
				case Keys.A:
					if (this.Shapes.Count > 0 && this.Shapes.Count != this.Selection.Shapes.Length && this.txdrawing_0.method_17())
					{
						this.txdrawing_0.method_18(bool_5: false, bool_6: true, bool_7: true, bool_8: true);
					}
					break;
				case Keys.C:
					this.Copy();
					break;
				}
			}
			else
			{
				switch (keyEventArgs_0.KeyCode)
				{
				case Keys.Delete:
					if (this.TXDrawing_0.ShapeCollection_0.method_7())
					{
						this.txdrawing_0.method_18(bool_5: false, bool_6: true, bool_7: true, bool_8: true);
					}
					break;
				case Keys.Escape:
					this.txdrawing_0.ShapeCollection_0.Shape_0 = null;
					break;
				}
			}
			base.OnKeyDown(keyEventArgs_0);
		}

		private Enum42 method_3(Cursor cursor_1)
		{
			if (cursor_1 == Cursors.Cross)
			{
				return Enum42.const_11;
			}
			if (cursor_1 == Cursors.SizeAll)
			{
				return Enum42.const_10;
			}
			if (cursor_1 == Cursors.SizeNESW)
			{
				return Enum42.const_9;
			}
			if (cursor_1 == Cursors.SizeNESW)
			{
				return Enum42.const_9;
			}
			if (cursor_1 == Cursors.SizeNS)
			{
				return Enum42.const_7;
			}
			if (cursor_1 == Cursors.SizeNWSE)
			{
				return Enum42.const_8;
			}
			if (cursor_1 == Cursors.SizeWE)
			{
				return Enum42.const_6;
			}
			return Enum42.const_4;
		}

		protected override void WndProc(ref Message message)
		{
			switch (message.Msg)
			{
			case 2062:
				this.OnKeyDown(new KeyEventArgs((Keys)(message.WParam.ToInt32() | (int)((((uint)message.LParam.ToInt32() & 4u) != 0) ? Keys.Shift : Keys.None) | (int)((((uint)message.LParam.ToInt32() & 8u) != 0) ? Keys.Control : Keys.None) | (int)((((uint)message.LParam.ToInt32() & 0x800u) != 0) ? Keys.Alt : Keys.None))));
				break;
			default:
				base.WndProc(ref message);
				break;
			case 2064:
				message.Result = new IntPtr((int)this.method_3(this.Cursor));
				break;
			case 513:
				if (base.Visible)
				{
					base.WndProc(ref message);
					break;
				}
				this.DefWndProc(ref message);
				if (base.Enabled)
				{
					this.OnMouseDown(new MouseEventArgs(MouseButtons.Left, 1, (int)(long)message.LParam & 0xFFFF, ((int)(long)message.LParam >> 16) & 0xFFFF, 0));
				}
				break;
			}
		}

		protected override void OnMouseMove(MouseEventArgs mevent)
		{
			Class177 @class = new Class177(mevent.X, mevent.Y, bool_1: false);
			if (this.txdrawing_0.method_37(@class, this.class177_0, 4))
			{
				Class177 class177_ = new Class177(MeasuringHelper.Pixel2Twips(@class.Double_0, 100), MeasuringHelper.Pixel2Twips(@class.Double_1, 100), bool_1: false);
				this.class177_0 = new Class177(-1.0, -1.0, bool_1: false);
				Enum34 enum34_ = this.txdrawing_0.method_38(class177_, @class);
				this.Cursor = this.method_17(enum34_);
			}
			base.OnMouseMove(mevent);
		}

		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			this.contextMenuStrip_0.Close();
			Class177 class177_ = (this.class177_0 = new Class177(mevent.X, mevent.Y, bool_1: false));
			this.txdrawing_0.method_24(class177_, mevent);
			base.OnMouseDown(mevent);
		}

		[Obfuscation(Exclude = true)]
		internal void SetStates(MouseEventArgs mouseEventArgs_0)
		{
			this.txdrawing_0.Enum37_0 = Enum37.const_0;
			switch (mouseEventArgs_0.Button)
			{
			default:
				this.txdrawing_0.Enum36_0 = Enum36.const_4;
				break;
			case MouseButtons.Right:
				this.txdrawing_0.Enum36_0 = Enum36.const_1;
				break;
			case MouseButtons.Left:
				this.txdrawing_0.Enum36_0 = Enum36.const_0;
				break;
			}
			switch (Control.ModifierKeys)
			{
			case Keys.Control:
				this.txdrawing_0.Enum36_0 = this.txdrawing_0.Enum36_0 | Enum36.const_2;
				break;
			default:
				this.txdrawing_0.Enum36_0 = this.txdrawing_0.Enum36_0 | Enum36.const_3;
				break;
			case Keys.Shift:
				this.txdrawing_0.Enum36_0 = this.txdrawing_0.Enum36_0 | Enum36.const_5;
				break;
			}
		}

		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			Class177 class177_ = new Class177(MeasuringHelper.Pixel2Twips(mevent.X, 100), MeasuringHelper.Pixel2Twips(mevent.Y, 100), bool_1: false);
			this.txdrawing_0.method_69(class177_);
			base.OnMouseUp(mevent);
			if (this.txdrawing_0.Selection_0.Class178_0 != null)
			{
				double num = MeasuringHelper.Pixel2Twips(1.0, 100);
				Class178 clipRectangle = new Class178(this.txdrawing_0.Selection_0.Class178_0.Double_0, this.txdrawing_0.Selection_0.Class178_0.Double_1, this.txdrawing_0.Selection_0.Class178_0.Double_3 + num, this.txdrawing_0.Selection_0.Class178_0.Double_2 + num, bool_1: false);
				this.txdrawing_0.Selection_0.Class178_0 = null;
				this.txdrawing_0.method_77();
				this.OnViewChanged(clipRectangle);
			}
		}

		/// <summary>Clears the undo buffer of the TX Drawing Control.</summary>
		public void ClearUndo()
		{
			this.TXDrawing_0.method_81();
		}

		/// <summary>Copies the current selected shapes of the TX Drawing Control to the Clipboard.</summary>
		public void Copy()
		{
			if (this.CanCopy)
			{
				this.txdrawing_0.MemoryStream_0 = new MemoryStream();
				this.txdrawing_0.method_14(this.txdrawing_0.MemoryStream_0);
			}
		}

		/// <summary>Moves the current selected shapes of the TX Drawing Control to the Clipboard.</summary>
		public void Cut()
		{
			if (this.txdrawing_0.method_15())
			{
				this.txdrawing_0.method_18(bool_5: false, bool_6: true, bool_7: true, bool_8: true);
			}
		}

		/// <summary>Opens a dialog to format selected shapes.</summary>
		public DialogResult FormatShapesDialog()
		{
			return this.method_4(bool_2: true, 0);
		}

		public DialogResult FormatShapesDialog(int activeTab)
		{
			if (activeTab != 0 && activeTab != 1)
			{
				throw new ArgumentException(this.resourceManager_0.GetString("ERR_INCORRECT_ACTIVE_TAB"));
			}
			return this.method_4(bool_2: true, activeTab);
		}

		internal DialogResult method_4(bool bool_2, int int_0)
		{
			if (this.Selection.Shapes.Length > 0)
			{
				this.Selection.method_32();
				DialogResult dialogResult = new FormatShapesDialog(this.txdrawing_0, int_0).ShowDialog();
				if (dialogResult == DialogResult.OK)
				{
					this.txdrawing_0.method_18(bool_5: true, bool_6: true, bool_7: true, bool_2);
				}
				base.Focus();
				return dialogResult;
			}
			return DialogResult.None;
		}

		/// <summary>Loads shapes data into the TX Drawing Control from a specified object of type System.IO.Stream.</summary>
		/// <param name="stream">Specifies an object of type System.IO.Stream the data is loaded from.</param>
		public void Load(Stream stream)
		{
			Serializer.Load(stream, SerializationFormat.Xml, out var shapes, this.TXDrawing_0, addShapeOffset: true);
			this.Shapes.Clear();
			this.Selection.method_22(new Shape[0]);
			Shape[] array = shapes;
			foreach (Shape shape in array)
			{
				this.Shapes.Add(shape);
			}
			this.txdrawing_0.method_1();
			this.txdrawing_0.method_77();
		}

		/// <summary>Pastes the content of the clipboard into the TX Drawing Control</summary>
		public void Paste()
		{
			if (this.CanPaste)
			{
				this.txdrawing_0.method_16(this.txdrawing_0.MemoryStream_0);
				this.txdrawing_0.method_18(bool_5: true, bool_6: true, bool_7: true, bool_8: true);
			}
		}

		/// <summary>Renders only the displayed shapes on the specified System.Drawing.Graphics object. No activated UI elements are rendered.</summary>
		/// <param name="graphics">Specifies the object of type System.Drawing.Graphics the displayed shapes are rendered to.</param>
		/// <param name="position">Specifies the position to draw on the specified System.Drawing.Graphics object.</param>
		public void PrintPaint(Graphics graphics, Rectangle position)
		{
			this.PrintPaint(graphics, position, showUIElements: false);
		}

		/// <summary>Renders the displayed shapes on the specified System.Drawing.Graphics object with or without activated UI elements.</summary>
		/// <param name="graphics">Specifies the object of type System.Drawing.Graphics the displayed shapes are rendered to.</param>
		/// <param name="position">Specifies the position to draw on the specified System.Drawing.Graphics object.</param>
		/// <param name="showUIElements">Specifies whether the activated UI elements are rendered on the specified System.Drawing.Graphics object or not.</param>
		public void PrintPaint(Graphics graphics, Rectangle position, bool showUIElements)
		{
			PixelOffsetMode pixelOffsetMode = graphics.PixelOffsetMode;
			SmoothingMode smoothingMode = graphics.SmoothingMode;
			graphics.PixelOffsetMode = PixelOffsetMode.Half;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			this.method_6(graphics, position, this.ZoomFactor, showUIElements);
			graphics.PixelOffsetMode = pixelOffsetMode;
			graphics.SmoothingMode = smoothingMode;
		}

		/// <summary>Redoes the last TX Drawing Control operation.</summary>
		public void Redo()
		{
			if (this.TXDrawing_0.method_82(bool_5: false))
			{
				this.txdrawing_0.method_77();
			}
		}

		/// <summary>Saves the shapes data to the given object of type System.IO.Stream.</summary>
		/// <param name="stream">Specifies an object of type System.IO.Stream the data is saved to.</param>
		public void Save(Stream stream)
		{
			Serializer.Save(this.txdrawing_0, stream, SerializationFormat.Xml, this.Shapes.method_13(), this.IsCanvasVisible, this.txdrawing_0.BorderWidth / 2);
		}

		/// <summary>Saves the displayed shapes as an image to the specified file using the specified format.</summary>
		/// <param name="imageFileName">Specifies a file the image is saved to.</param>
		/// <param name="format">Specifies the format used to save the image.</param>
		public void SaveImage(string imageFileName, ImageFormat format)
		{
			FileStream fileStream = new FileStream(imageFileName, FileMode.Create);
			this.SaveImage(fileStream, format);
			fileStream.Close();
		}

		/// <summary>Saves the displayed shapes as an image to the specified object of type System.IO.Stream.</summary>
		/// <param name="imageStream">Specifies an object of type System.IO.Stream the image is saved to.</param>
		/// <param name="format">Specifies the format used to save the image.</param>
		public void SaveImage(Stream imageStream, ImageFormat format)
		{
			Metafile metafile = this.method_5(100);
			if (format.Guid == ImageFormat.Emf.Guid)
			{
				Graphics graphics = Graphics.FromHwndInternal(IntPtr.Zero);
				IntPtr hdc = graphics.GetHdc();
				Metafile image = new Metafile(imageStream, hdc);
				graphics.ReleaseHdc();
				graphics.Dispose();
				graphics = Graphics.FromImage(image);
				graphics.DrawImage(metafile, new Point(0, 0));
				graphics.Dispose();
			}
			else if (format.Guid == ImageFormat.Wmf.Guid)
			{
				new NotSupportedException();
			}
			else
			{
				metafile.Save(imageStream, format);
			}
		}

		/// <summary>Selects all shapes in the TX Drawing Control.</summary>
		public void SelectAll()
		{
			if (this.Shapes.Count > 0 && this.Shapes.Count != this.Selection.Shapes.Length && this.txdrawing_0.method_17())
			{
				this.txdrawing_0.method_18(bool_5: false, bool_6: true, bool_7: true, bool_8: true);
			}
		}

		/// <summary>If any changes of the the displayed shapes' visible bounds require an adaption of the TX Drawing Control bounds, the size and/or location of the control is expanded respectively decreased by the considering value of the considering shape's side(s). The method returns an array of doubles which represent the effected alteration for each control's side (left, top, right, bottom) in Twips.</summary>
		public int[] SizeToContent()
		{
			if (this.TXDrawing_0.ShapeCollection_0.Count > 0)
			{
				bool flag = !this.TXDrawing_0.IsCanvasVisible;
				this.TXDrawing_0.ShapeCollection_0.method_11();
				Class178 class178_ = this.TXDrawing_0.ShapeCollection_0.Class178_0;
				double num = Math.Round(MeasuringHelper.ZoomValue(class178_.Double_9, this.ZoomFactor, viseVersa: true), MidpointRounding.ToEven);
				double num2 = Math.Round(this.TXDrawing_0.Class178_1.Double_9, MidpointRounding.ToEven);
				bool flag2;
				double num3 = ((!(flag2 = num < num2 || flag)) ? 0.0 : (num3 = num - num2));
				flag2 = num3 != 0.0;
				double num4 = Math.Round(MeasuringHelper.ZoomValue(class178_.Double_11, this.ZoomFactor, viseVersa: true), MidpointRounding.ToEven);
				double num5 = Math.Round(this.TXDrawing_0.Class178_1.Double_11, MidpointRounding.ToEven);
				bool flag3;
				double num6 = ((flag3 = num4 < num5 || flag) ? (num4 - num5) : 0.0);
				flag3 = num6 != 0.0;
				double num7 = Math.Round(MeasuringHelper.ZoomValue(class178_.Double_10, this.ZoomFactor, viseVersa: true), MidpointRounding.ToEven);
				double num8 = Math.Round(this.TXDrawing_0.Class178_1.Double_10, MidpointRounding.ToEven);
				bool flag4;
				double num9 = ((flag4 = num7 > num8 || flag || this.txdrawing_0.Int32_3 > 0) ? (num7 - num8) : 0.0);
				num9 = (flag ? num9 : Math.Max(this.txdrawing_0.Int32_3, num9));
				flag4 = num9 != 0.0;
				double num10 = Math.Round(MeasuringHelper.ZoomValue(class178_.Double_8, this.ZoomFactor, viseVersa: true), MidpointRounding.ToEven);
				double num11 = Math.Round(this.TXDrawing_0.Class178_1.Double_8, MidpointRounding.ToEven);
				bool flag5;
				double num12 = ((flag5 = num10 > num11 || flag || this.txdrawing_0.Int32_3 > 0) ? (num10 - num11) : 0.0);
				num12 = (flag ? num12 : Math.Max(this.txdrawing_0.Int32_3, num12));
				flag5 = num12 != 0.0;
				this.txdrawing_0.Int32_3 = 0;
				if (flag2 || flag3 || flag4 || flag5)
				{
					this.txdrawing_0.Selection_0.method_32();
					double num13 = MeasuringHelper.ZoomValue(0.0 - num3 + num9, this.ZoomFactor, viseVersa: false);
					double num14 = MeasuringHelper.ZoomValue(0.0 - num6 + num12, this.ZoomFactor, viseVersa: false);
					this.method_16(this.txdrawing_0.Class179_0.Double_1 + num13, this.txdrawing_0.Class179_0.Double_0 + num14);
					this.bool_0 = true;
					base.Size = new Size((int)Math.Round(MeasuringHelper.Twips2Pixels(this.txdrawing_0.Class179_0.Double_1, 100), MidpointRounding.ToEven), (int)Math.Round(MeasuringHelper.Twips2Pixels(this.txdrawing_0.Class179_0.Double_0, 100), MidpointRounding.ToEven));
					this.bool_0 = false;
					if (!flag2 && !flag3)
					{
						foreach (Shape shape3 in this.Shapes)
						{
							shape3.Class174_0.method_1((Class174.Enum30)479);
						}
					}
					else
					{
						foreach (Shape shape4 in this.Shapes)
						{
							double double_ = shape4.Class174_0.Class178_1.Double_0;
							double_ -= num3;
							double double_2 = shape4.Class174_0.Class178_1.Double_1;
							double_2 -= num6;
							shape4.Class174_0.method_19(new Class177(double_, double_2, bool_1: false), bool_2: false, (Class174.Enum30)479, bool_3: false);
							shape4.Class183_0.method_1();
							this.txdrawing_0.method_77();
						}
					}
					this.txdrawing_0.method_18(bool_5: false, bool_6: false, bool_7: true, bool_8: true);
				}
				return new int[4]
				{
					(int)Math.Round(num3, MidpointRounding.ToEven),
					(int)Math.Round(num6, MidpointRounding.ToEven),
					(int)Math.Round(num9, MidpointRounding.ToEven),
					(int)Math.Round(num12, MidpointRounding.ToEven)
				};
			}
			if (this.txdrawing_0.Int32_3 > 0)
			{
				double num15 = MeasuringHelper.ZoomValue(this.txdrawing_0.Int32_3, this.ZoomFactor, viseVersa: false);
				double num16 = MeasuringHelper.ZoomValue(this.txdrawing_0.Int32_3, this.ZoomFactor, viseVersa: false);
				int num17 = this.txdrawing_0.Int32_3 / 2;
				this.txdrawing_0.Int32_3 = 0;
				this.method_16(this.txdrawing_0.Class179_0.Double_1 + num15, this.txdrawing_0.Class179_0.Double_0 + num16);
				this.bool_0 = true;
				base.Size = new Size((int)Math.Round(MeasuringHelper.Twips2Pixels(this.txdrawing_0.Class179_0.Double_1, 100), MidpointRounding.ToEven), (int)Math.Round(MeasuringHelper.Twips2Pixels(this.txdrawing_0.Class179_0.Double_0, 100), MidpointRounding.ToEven));
				this.bool_0 = false;
				return new int[4]
				{
					-num17,
					-num17,
					num17,
					num17
				};
			}
			return new int[4];
		}

		/// <summary>Undoes the last edit operation in the TX Drawing Control.</summary>
		public void Undo()
		{
			if (this.TXDrawing_0.method_83(bool_5: false))
			{
				this.txdrawing_0.method_77();
			}
		}

		private Metafile method_5(int int_0)
		{
			Graphics graphics = Graphics.FromHwndInternal(IntPtr.Zero);
			IntPtr hdc = graphics.GetHdc();
			Rectangle rectangle = new Rectangle(0, 0, Math.Max(base.Width, 1), Math.Max(base.Height, 1));
			Metafile metafile = new Metafile(new MemoryStream(), hdc, rectangle, MetafileFrameUnit.Pixel);
			graphics.ReleaseHdc();
			graphics.Dispose();
			graphics = Graphics.FromImage(metafile);
			graphics.PixelOffsetMode = PixelOffsetMode.Half;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			if (this.IsCanvasVisible)
			{
				graphics.FillRectangle(new SolidBrush(this.BackColor), rectangle);
			}
			this.method_7(graphics, bool_2: false, 1.0);
			graphics.Dispose();
			return metafile;
		}

		private void method_6(Graphics graphics_0, Rectangle rectangle_0, int int_0, bool bool_2)
		{
			if (this.IsCanvasVisible)
			{
				graphics_0.FillRectangle(new SolidBrush(this.BackColor), rectangle_0);
			}
			graphics_0.TranslateTransform(rectangle_0.X, rectangle_0.Y);
			Class178 @class = new Class178(MeasuringHelper.Pixel2Twips(rectangle_0.X, int_0), MeasuringHelper.Pixel2Twips(rectangle_0.Y, int_0), MeasuringHelper.Pixel2Twips(rectangle_0.Width, int_0), MeasuringHelper.Pixel2Twips(rectangle_0.Height, int_0), bool_1: false);
			double num = @class.Class179_0.Double_1 / this.txdrawing_0.Class178_1.Double_3;
			double num2 = @class.Class179_0.Double_0 / this.txdrawing_0.Class178_1.Double_2;
			double num3 = Math.Min(num, num2);
			RectangleF rectangleF = new RectangleF((float)MeasuringHelper.Twips2Pixels(this.txdrawing_0.Class178_0.Double_0 * num, int_0) + (float)rectangle_0.X, (float)MeasuringHelper.Twips2Pixels(this.txdrawing_0.Class178_0.Double_1 * num2, int_0) + (float)rectangle_0.Y, (float)(MeasuringHelper.Twips2Pixels(this.txdrawing_0.Class178_0.Double_3, int_0) * num), (float)(MeasuringHelper.Twips2Pixels(this.txdrawing_0.Class178_0.Double_2, int_0) * num2));
			if (this.IsCanvasVisible && this.BorderWidth != 0)
			{
				graphics_0.DrawRectangle(new Pen(new SolidBrush(this.BorderColor), (float)(MeasuringHelper.Twips2Pixels(this.BorderWidth, int_0) * num3)), rectangleF.X, rectangleF.Y, rectangleF.Width - 1f, rectangleF.Height - 1f);
			}
			foreach (Shape shape3 in this.Shapes)
			{
				this.UpdateMatrix(shape3, num, num2);
			}
			this.method_7(graphics_0, bool_2, num3);
			foreach (Shape shape4 in this.Shapes)
			{
				this.UpdateMatrix(shape4, 1.0, 1.0);
			}
			graphics_0.TranslateTransform(-rectangle_0.X, -rectangle_0.Y);
			if (bool_2)
			{
				graphics_0.SmoothingMode = SmoothingMode.None;
				graphics_0.PixelOffsetMode = PixelOffsetMode.None;
				Pen pen = new Pen(new SolidBrush(Color.FromArgb(127, 127, 127)), 1f);
				pen.DashStyle = DashStyle.Dash;
				pen.DashPattern = new float[2]
				{
					(int)(9.0 * num3),
					(int)(3.0 * num3)
				};
				if (this.IsCanvasVisible)
				{
					double num4 = MeasuringHelper.Pixel2Twips(1.0, 100);
					graphics_0.DrawRectangle(pen, (int)rectangleF.X, (int)rectangleF.Y, (int)((double)rectangleF.Width - num4), (int)((double)rectangleF.Height - num4));
				}
				else
				{
					graphics_0.DrawRectangle(pen, 0, 0, (int)((double)(base.Width - 1) * num), (int)((double)(base.Height - 1) * num2));
				}
				if (this.txdrawing_0.Selection_0.Class178_0 != null)
				{
					Flip flip;
					Class178 class2 = Helper.ConvertToValidBounds(this.txdrawing_0.Selection_0.Class178_0, out flip);
					graphics_0.DrawRectangle(new Pen(new SolidBrush(Color.Black), 2f), (float)MeasuringHelper.Twips2Pixels(class2.Double_0 * num3, this.ZoomFactor), (float)MeasuringHelper.Twips2Pixels(class2.Double_1 * num3, this.ZoomFactor), (float)MeasuringHelper.Twips2Pixels(class2.Double_3 * num3, this.ZoomFactor), (float)MeasuringHelper.Twips2Pixels(class2.Double_2 * num3, this.ZoomFactor));
				}
			}
		}

		private void method_7(Graphics graphics_0, bool bool_2, double double_0)
		{
			foreach (Shape shape in this.Shapes)
			{
				this.method_8(shape, graphics_0, bool_2, double_0);
			}
		}

		private void method_8(Shape shape_0, Graphics graphics_0, bool bool_2, double double_0)
		{
			graphics_0.SmoothingMode = SmoothingMode.HighQuality;
			Matrix translateMatrix = (Matrix)shape_0.Class183_0.Object_0;
			Class175[] class175_ = shape_0.Class183_0.Class175_0;
			foreach (Class175 pathHelper in class175_)
			{
				DrawHelper.FillPathes(graphics_0, shape_0, pathHelper, translateMatrix);
			}
			if (shape_0.ShapeOutline.Width > 0)
			{
				Pen penToUse = new Pen(new SolidBrush(shape_0.ShapeOutline.Color), (float)MeasuringHelper.Twips2Pixels((double)shape_0.ShapeOutline.Width * double_0, this.ZoomFactor));
				Class175[] class175_2 = shape_0.Class183_0.Class175_0;
				foreach (Class175 pathHelper2 in class175_2)
				{
					DrawHelper.DrawPathes(graphics_0, shape_0, pathHelper2, translateMatrix, penToUse);
				}
			}
			if (bool_2 && shape_0.IsSelected)
			{
				graphics_0.SmoothingMode = SmoothingMode.None;
				double num = MeasuringHelper.Twips2Pixels(shape_0.Class174_0.Class177_3[0].Double_0, this.ZoomFactor);
				double num2 = MeasuringHelper.Twips2Pixels(shape_0.Class174_0.Class177_3[0].Double_1, this.ZoomFactor);
				graphics_0.TranslateTransform((float)(num * double_0), (float)(num2 * double_0));
				graphics_0.RotateTransform(shape_0.Angle);
				float num3 = (float)(0.0 - MeasuringHelper.Twips2Pixels(shape_0.Class174_0.Class178_1.Double_0, this.ZoomFactor));
				float num4 = (float)(0.0 - MeasuringHelper.Twips2Pixels(shape_0.Class174_0.Class178_1.Double_1, this.ZoomFactor));
				if (shape_0.Sizable)
				{
					this.method_10(shape_0.Class174_0, graphics_0, num3, num4, double_0);
				}
				if (shape_0.Class183_0.Boolean_0)
				{
					bool flag = (shape_0.Flip & Flip.Horizontal) == Flip.Horizontal;
					bool flag2 = (shape_0.Flip & Flip.Vertical) == Flip.Vertical;
					float sx = ((!flag) ? 1 : (-1));
					float sy = ((!flag2) ? 1 : (-1));
					float num5 = (flag ? ((float)(0.0 - MeasuringHelper.Twips2Pixels(shape_0.Class174_0.Class178_1.Double_3, this.ZoomFactor))) : 0f);
					float num6 = (flag2 ? ((float)(0.0 - MeasuringHelper.Twips2Pixels(shape_0.Class174_0.Class178_1.Double_2, this.ZoomFactor))) : 0f);
					graphics_0.ScaleTransform(sx, sy);
					graphics_0.TranslateTransform((float)((double)num5 * double_0), (float)((double)num6 * double_0));
					this.method_11(shape_0, graphics_0, num3, num4, double_0);
					graphics_0.TranslateTransform(0f - (float)((double)num5 * double_0), 0f - (float)((double)num6 * double_0));
					graphics_0.ScaleTransform(sx, sy);
				}
				graphics_0.RotateTransform(-shape_0.Angle);
				graphics_0.TranslateTransform(0f - (float)(num * double_0), 0f - (float)(num2 * double_0));
			}
		}

		private Point method_9(Class177 class177_1, double double_0)
		{
			Point point = new Point(0, 0);
			double num = MeasuringHelper.Twips2Pixels(class177_1.Double_0, this.ZoomFactor);
			double num2 = MeasuringHelper.Twips2Pixels(class177_1.Double_1, this.ZoomFactor);
			double num3 = double_0 * (Math.PI / 180.0);
			double num4 = Math.Cos(num3);
			double num5 = Math.Sin(num3);
			Point result = default(Point);
			result.X = (int)(num4 * (num - (double)point.X) - num5 * (num2 - (double)point.Y) + (double)point.X);
			result.Y = (int)(num5 * (num - (double)point.X) + num4 * (num2 - (double)point.Y) + (double)point.Y);
			return result;
		}

		private void method_10(Class174 class174_0, Graphics graphics_0, float float_0, float float_1, double double_0)
		{
			Class178[] class178_ = class174_0.Class178_4;
			foreach (Class178 rectangle in class178_)
			{
				RectangleF rectangleF = DrawHelper.TwipsRectToPixel(rectangle);
				rectangleF.Offset(float_0, float_1);
				graphics_0.FillEllipse(new SolidBrush(this.color_1), (int)((double)rectangleF.X * double_0), (int)((double)rectangleF.Y * double_0), (int)((double)rectangleF.Width * double_0), (int)((double)rectangleF.Height * double_0));
				graphics_0.DrawEllipse(new Pen(new SolidBrush(this.color_0)), (int)((double)rectangleF.X * double_0), (int)((double)rectangleF.Y * double_0), (int)((double)rectangleF.Width * double_0), (int)((double)rectangleF.Height * double_0));
			}
			Class178[] class178_2 = class174_0.Class178_5;
			foreach (Class178 rectangle2 in class178_2)
			{
				RectangleF rectangleF2 = DrawHelper.TwipsRectToPixel(rectangle2);
				rectangleF2.Offset(float_0, float_1);
				graphics_0.FillRectangle(new SolidBrush(this.color_0), (int)((double)(rectangleF2.X - 1f) * double_0), (int)((double)(rectangleF2.Y - 1f) * double_0), (int)((double)(rectangleF2.Width + 2f) * double_0), (int)((double)(rectangleF2.Height + 2f) * double_0));
				graphics_0.FillRectangle(new SolidBrush(this.color_1), (int)((double)rectangleF2.X * double_0), (int)((double)rectangleF2.Y * double_0), (int)((double)rectangleF2.Width * double_0), (int)((double)rectangleF2.Height * double_0));
			}
		}

		private void method_11(Shape shape_0, Graphics graphics_0, float float_0, float float_1, double double_0)
		{
			RectangleF[] array = new RectangleF[shape_0.Class174_0.Class172_0.List_0.Count];
			for (int i = 0; i < array.Length; i++)
			{
				Class173 @class = shape_0.Class174_0.Class172_0.List_0[i];
				@class.method_1(this.ZoomFactor, shape_0);
				ref RectangleF reference = ref array[i];
				reference = DrawHelper.TwipsRectToPixel(@class);
			}
			RectangleF[] array2 = array;
			for (int j = 0; j < array2.Length; j++)
			{
				RectangleF rectangleF = array2[j];
				rectangleF.Offset(float_0, float_1);
				graphics_0.FillRectangle(new SolidBrush(Color.Black), (int)((double)(rectangleF.X - 1f) * double_0), (int)((double)(rectangleF.Y - 1f) * double_0), (int)((double)(rectangleF.Width + 2f) * double_0), (int)((double)(rectangleF.Height + 2f) * double_0));
				graphics_0.FillRectangle(new SolidBrush(Color.Yellow), (int)((double)rectangleF.X * double_0), (int)((double)rectangleF.Y * double_0), (int)((double)rectangleF.Width * double_0), (int)((double)rectangleF.Height * double_0));
			}
		}

		private void method_12(Shape shape_0, double double_0, double double_1)
		{
			double double_2 = shape_0.Class174_0.Class178_2.Double_0 * double_0 / 100.0;
			double double_3 = shape_0.Class174_0.Class178_2.Double_1 * double_1 / 100.0;
			double double_4 = shape_0.Class174_0.Class178_2.Double_3 * double_0 / 100.0;
			double double_5 = shape_0.Class174_0.Class178_2.Double_2 * double_1 / 100.0;
			Class178 @class = new Class178(double_2, double_3, double_4, double_5, bool_1: false);
			Class178 class178_ = shape_0.Class174_0.method_13(@class, @class, 100);
			shape_0.Class174_0.method_18(class178_, bool_2: true, (Class174.Enum30)255, bool_3: false);
		}

		internal Shape method_13()
		{
			Point point = base.PointToClient(Control.MousePosition);
			foreach (Shape shape in this.Shapes)
			{
				if (this.Contains(shape, new Class177(point.X, point.Y, bool_1: false)))
				{
					return shape;
				}
			}
			return null;
		}

		private bool method_14()
		{
			bool flag = !this.TXDrawing_0.IsCanvasVisible;
			this.TXDrawing_0.ShapeCollection_0.method_11();
			Class178 class178_ = this.TXDrawing_0.ShapeCollection_0.Class178_0;
			if (class178_ != null)
			{
				double num = Math.Round(MeasuringHelper.ZoomValue(class178_.Double_9, this.ZoomFactor, viseVersa: true), MidpointRounding.ToEven);
				double num2 = Math.Round(this.TXDrawing_0.Class178_1.Double_9, MidpointRounding.ToEven);
				bool flag2;
				double num3 = ((!(flag2 = num < num2 || flag)) ? 0.0 : (num3 = num - num2));
				flag2 = num3 != 0.0;
				double num4 = Math.Round(MeasuringHelper.ZoomValue(class178_.Double_11, this.ZoomFactor, viseVersa: true), MidpointRounding.ToEven);
				double num5 = Math.Round(this.TXDrawing_0.Class178_1.Double_11, MidpointRounding.ToEven);
				bool flag3;
				double num6 = ((flag3 = num4 < num5 || flag) ? (num4 - num5) : 0.0);
				flag3 = num6 != 0.0;
				double num7 = Math.Round(MeasuringHelper.ZoomValue(class178_.Double_10, this.ZoomFactor, viseVersa: true), MidpointRounding.ToEven);
				double num8 = Math.Round(this.TXDrawing_0.Class178_1.Double_10, MidpointRounding.ToEven);
				bool flag4;
				double num9 = ((flag4 = num7 > num8 || flag) ? (num7 - num8) : 0.0);
				flag4 = num9 != 0.0;
				double num10 = Math.Round(MeasuringHelper.ZoomValue(class178_.Double_8, this.ZoomFactor, viseVersa: true), MidpointRounding.ToEven);
				double num11 = Math.Round(this.TXDrawing_0.Class178_1.Double_8, MidpointRounding.ToEven);
				bool flag5;
				double num12 = ((flag5 = num10 > num11 || flag) ? (num10 - num11) : 0.0);
				flag5 = num12 != 0.0;
				if (!flag2 && !flag3 && !flag4)
				{
					return flag5;
				}
				return true;
			}
			return false;
		}

		private bool method_15(double double_0, double double_1)
		{
			if (!this.bool_0 && (double_0 != 5.0 || double_1 != 5.0))
			{
				double num = ((double.IsInfinity(double_0) || double.IsNaN(double_0)) ? this.txdrawing_0.Class179_0.Double_1 : MeasuringHelper.Pixel2Twips(double_0, 100));
				double num2 = ((double.IsInfinity(double_1) || double.IsNaN(double_1)) ? this.txdrawing_0.Class179_0.Double_0 : MeasuringHelper.Pixel2Twips(double_1, 100));
				if ((num >= 0.0 && num2 >= 0.0 && num != this.txdrawing_0.Class179_0.Double_1) || num2 != this.txdrawing_0.Class179_0.Double_0)
				{
					Class179 class179_ = this.txdrawing_0.Class178_1.Class179_0;
					if (num != class179_.Double_1 || num2 != class179_.Double_0)
					{
						this.method_16(num, num2);
						if (class179_ != null && !this.bool_1)
						{
							double num3 = this.txdrawing_0.Class178_1.Double_3 - class179_.Double_1;
							double num4 = this.txdrawing_0.Class178_1.Double_2 - class179_.Double_0;
							double double_2 = 100.0 + num3 / class179_.Double_1 * 100.0;
							double double_3 = 100.0 + num4 / class179_.Double_0 * 100.0;
							foreach (Shape shape in this.Shapes)
							{
								if (shape.AutoSize)
								{
									this.method_12(shape, double_2, double_3);
								}
							}
						}
						return true;
					}
				}
			}
			return false;
		}

		private void method_16(double double_0, double double_1)
		{
			this.txdrawing_0.Class178_1 = new Class178(0.0, 0.0, MeasuringHelper.ZoomValue(double_0, this.ZoomFactor, viseVersa: true), MeasuringHelper.ZoomValue(double_1, this.ZoomFactor, viseVersa: true), bool_1: false);
			this.txdrawing_0.Class179_0 = new Class179((int)MeasuringHelper.ZoomValue(this.txdrawing_0.Class178_1.Double_3, this.ZoomFactor, viseVersa: false), (int)MeasuringHelper.ZoomValue(this.txdrawing_0.Class178_1.Double_2, this.ZoomFactor, viseVersa: false), bool_1: false);
		}

		private Cursor method_17(Enum34 enum34_0)
		{
			return enum34_0 switch
			{
				Enum34.const_1 => Cursors.Cross, 
				Enum34.const_2 => Cursors.SizeAll, 
				Enum34.const_3 => Cursors.SizeWE, 
				Enum34.const_4 => Cursors.SizeNWSE, 
				Enum34.const_5 => Cursors.SizeNS, 
				Enum34.const_6 => Cursors.SizeNESW, 
				_ => Cursors.Default, 
			};
		}

		[Obfuscation(Exclude = true)]
		internal virtual void OnPropertyChanged(string propertyName)
		{
			((PropertyChangedEventHandler)base.Events[TXDrawingControl.PropertyChangedEvent])?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		protected override void OnSizeChanged(EventArgs eventArgs_0)
		{
			if (this.method_15(base.Width, base.Height))
			{
				this.txdrawing_0.method_77();
				base.OnSizeChanged(eventArgs_0);
				this.OnPropertyChanged("Size");
			}
		}

		protected override void OnVisibleChanged(EventArgs eventArgs_0)
		{
			if (base.Visible)
			{
				base.ContextMenuStrip = this.contextMenuStrip_0;
			}
			else
			{
				base.ContextMenuStrip = null;
				this.txdrawing_0.ShapeCollection_0.Shape_0 = null;
			}
			base.OnVisibleChanged(eventArgs_0);
		}
	}
}
