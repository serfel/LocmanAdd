using System;
using System.Collections;
using ns17;

namespace TXTextControl.Drawing
{
	/// <summary>An instance of the ShapeCollection class contains all displayed shapes represented through objects of type Shape.</summary>
	public class ShapeCollection : CollectionBase, IEnumerable, IEnumerator
	{
		/// <summary>Determines the location and size in which a shape is added to the TX Drawing Control.</summary>
		public enum AddStyle
		{
			/// <summary>The shape fills the complete control, no matter which location and size was defined before.</summary>
			Fill,
			/// <summary>No specific style is set. The shape is located at its defined location with its defined size.</summary>
			None,
			/// <summary>The shape is added on the next mouse up handling and gets the bounds which are defined by the previous mouse down click and the following mouse movement. If a considering side value is less than 150 twips, the side gets a length of 1134 twips.</summary>
			MouseCreation
		}

		private bool bool_0;

		private bool bool_1;

		private int int_0 = -1;

		private Class178 class178_0;

		private Shape shape_0;

		private TXDrawing txdrawing_0;

		public object Current
		{
			get
			{
				try
				{
					return base.List[this.int_0];
				}
				catch (IndexOutOfRangeException)
				{
					throw new InvalidOperationException();
				}
			}
		}

		public Shape this[int number] => (Shape)base.List[number];

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

		internal bool Boolean_1 => this.bool_1;

		internal Shape Shape_0
		{
			get
			{
				return this.shape_0;
			}
			set
			{
				this.shape_0 = value;
				this.bool_1 = this.shape_0 != null;
			}
		}

		protected override void OnClear()
		{
			this.txdrawing_0.method_1();
			base.OnClear();
		}

		public int Add(Shape shape)
		{
			return this.method_6(shape, AddStyle.None);
		}

		public int Add(Shape shape, AddStyle addStyle)
		{
			return this.method_6(shape, addStyle);
		}

		public void Insert(int index, Shape shape)
		{
			if (shape == null)
			{
				throw new ArgumentNullException();
			}
			shape.method_0();
			this.txdrawing_0.Selection_0.method_32();
			base.InnerList.Insert(index, shape);
			this.method_10();
			this.method_9();
			this.txdrawing_0.method_18(bool_5: true, bool_6: true, bool_7: true, bool_8: true);
		}

		public bool MoveNext()
		{
			this.int_0++;
			return this.int_0 < base.List.Count;
		}

		public void Remove(Shape shape)
		{
			if (shape == null)
			{
				throw new ArgumentNullException();
			}
			base.InnerList.Remove(shape);
			this.method_10();
			this.method_9();
			this.method_12(shape);
			this.txdrawing_0.method_18(bool_5: false, bool_6: true, bool_7: true, bool_8: true);
		}

		public new void RemoveAt(int index)
		{
			this.txdrawing_0.Selection_0.method_32();
			Shape shape = this[index];
			base.InnerList.Remove(shape);
			this.method_10();
			this.method_9();
			this.method_12(shape);
			this.txdrawing_0.method_18(bool_5: false, bool_6: true, bool_7: true, bool_8: true);
		}

		public void Reset()
		{
			this.int_0 = -1;
		}

		private bool method_0(Shape shape_1)
		{
			foreach (Shape inner in base.InnerList)
			{
				if (inner == shape_1)
				{
					return true;
				}
			}
			return false;
		}

		internal void method_1(Class177 class177_0)
		{
			Flip flip = Flip.None;
			Class178 @class = ((this.txdrawing_0.Selection_0.Class178_0 != null) ? Helper.ConvertToValidBounds(this.txdrawing_0.Selection_0.Class178_0, out flip) : new Class178(class177_0, new Class179(1134.0, 1134.0, bool_1: false)));
			if (@class.Double_3 < 150.0 || @class.Double_2 < 150.0)
			{
				double double_ = ((@class.Double_3 < 150.0) ? 1134.0 : @class.Double_3);
				double double_2 = ((@class.Double_2 < 150.0) ? 1134.0 : @class.Double_2);
				@class = new Class178(@class.Class177_0, new Class179(double_, double_2, bool_1: false));
			}
			this.shape_0.Boolean_9 = false;
			this.shape_0.Class174_0.Class178_1 = @class;
			this.shape_0.Flip_1 = flip;
			this.method_5(this.shape_0, AddStyle.None);
			this.txdrawing_0.Selection_0.method_22(new Shape[1] { this.shape_0 });
			this.Shape_0 = null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return base.GetEnumerator();
		}

		internal int method_2(Shape shape_1, AddStyle addStyle_0)
		{
			shape_1.Class183_0.ShapeObject_0 = this.txdrawing_0.method_75(shape_1, shape_1.Type);
			if (addStyle_0 != AddStyle.MouseCreation)
			{
				return this.method_5(shape_1, addStyle_0);
			}
			return this.method_4(shape_1);
		}

		internal void method_3(int int_1, Shape shape_1)
		{
			base.InnerList.Remove(shape_1);
			this.txdrawing_0.Selection_0.method_32();
			base.InnerList.Insert(int_1, shape_1);
			this.method_10();
		}

		private int method_4(Shape shape_1)
		{
			this.txdrawing_0.Selection_0.method_22(new Shape[0]);
			this.Shape_0 = shape_1;
			return -1;
		}

		private int method_5(Shape shape_1, AddStyle addStyle_0)
		{
			if (shape_1 == null)
			{
				return -1;
			}
			bool bool_;
			if ((bool_ = addStyle_0 == AddStyle.Fill) || shape_1.Boolean_9)
			{
				double num = Math.Min(this.txdrawing_0.Class178_1.Double_3 - (double)this.txdrawing_0.BorderWidth, this.txdrawing_0.Class178_1.Double_2 - (double)this.txdrawing_0.BorderWidth);
				Class178 class178_ = new Class178((double)this.txdrawing_0.BorderWidth / 2.0 + num / 4.0, (double)this.txdrawing_0.BorderWidth / 2.0 + num / 4.0, num / 2.0, num / 2.0, bool_1: false);
				shape_1.Class174_0.Class178_1 = class178_;
			}
			shape_1.Boolean_9 = false;
			shape_1.Int32_5 = base.InnerList.Add(shape_1);
			shape_1.method_3(this.txdrawing_0, bool_);
			this.txdrawing_0.method_5(shape_1);
			if (!this.bool_0)
			{
				this.method_9();
			}
			this.bool_0 = false;
			return shape_1.Index;
		}

		internal int method_6(Shape shape_1, AddStyle addStyle_0)
		{
			if (this.method_0(shape_1))
			{
				return -1;
			}
			shape_1.method_0();
			this.txdrawing_0.Selection_0.method_32();
			int result = this.method_2(shape_1, addStyle_0);
			if (addStyle_0 != AddStyle.MouseCreation)
			{
				this.txdrawing_0.Selection_0.method_22(new Shape[1] { shape_1 });
			}
			this.method_8(shape_1);
			this.txdrawing_0.method_18(bool_5: false, bool_6: true, bool_7: true, bool_8: true);
			return result;
		}

		internal bool method_7()
		{
			int num;
			if ((num = this.txdrawing_0.Selection_0.Shapes.Length) > 0)
			{
				this.txdrawing_0.Selection_0.method_32();
				Shape[] array = new Shape[num];
				Shape[] shapes = this.txdrawing_0.Selection_0.Shapes;
				foreach (Shape shape in shapes)
				{
					base.InnerList.Remove(shape);
					num--;
					array[num] = shape;
				}
				this.method_10();
				this.txdrawing_0.Selection_0.method_22(new Shape[0]);
				this.method_9();
				Shape[] array2 = array;
				foreach (Shape shape_ in array2)
				{
					this.txdrawing_0.method_7(shape_);
					this.txdrawing_0.method_6(shape_);
				}
				return true;
			}
			return false;
		}

		internal void method_8(Shape shape_1)
		{
			for (int i = 0; i < base.Count; i++)
			{
				this[i].Class183_0.Boolean_0 = false;
			}
			if (shape_1 != null)
			{
				shape_1.Class183_0.Boolean_0 = true;
			}
		}

		internal void method_9()
		{
			if (base.Count == 1)
			{
				Shape shape = this[0];
				if (this.txdrawing_0.IsCanvasVisible && shape.AutoSize && !shape.CanFitToCanvas && this.txdrawing_0.BorderWidth == 0)
				{
					this.txdrawing_0.IsCanvasVisible = false;
				}
			}
			else if (!this.txdrawing_0.IsCanvasVisible)
			{
				this.txdrawing_0.IsCanvasVisible = true;
			}
		}

		internal void method_10()
		{
			for (int i = 0; i < base.Count; i++)
			{
				this[i].Int32_5 = i;
			}
		}

		internal void method_11()
		{
			this.class178_0 = Helper.GetBounds(this.method_13(), this.txdrawing_0.ZoomFactor);
		}

		private void method_12(Shape shape_1)
		{
			if (!shape_1.IsSelected)
			{
				return;
			}
			Shape[] array = new Shape[this.txdrawing_0.Selection_0.Shapes.Length - 1];
			if (array.Length > 0)
			{
				int num = 0;
				foreach (Shape inner in base.InnerList)
				{
					if (inner != shape_1)
					{
						array[num] = inner;
						num++;
					}
				}
			}
			this.txdrawing_0.Selection_0.method_22(array);
			this.txdrawing_0.method_7(shape_1);
			this.txdrawing_0.method_6(shape_1);
		}

		internal Shape[] method_13()
		{
			Shape[] array = new Shape[base.Count];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = this[i];
			}
			return array;
		}

		internal ShapeCollection(TXDrawing kernel)
		{
			this.txdrawing_0 = kernel;
		}
	}
}
