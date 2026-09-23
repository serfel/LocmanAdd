using System.Runtime.CompilerServices;
using TXTextControl.Drawing;

namespace ns17
{
	internal class Class183
	{
		internal Shape shape_0;

		internal Class179 class179_0;

		[CompilerGenerated]
		private Class175[] class175_0;

		[CompilerGenerated]
		private object object_0;

		[CompilerGenerated]
		private ShapeObject shapeObject_0;

		[CompilerGenerated]
		private bool bool_0;

		internal Class179 Class179_0 => this.class179_0;

		internal Class175[] Class175_0
		{
			[CompilerGenerated]
			get
			{
				return this.class175_0;
			}
			[CompilerGenerated]
			set
			{
				this.class175_0 = value;
			}
		}

		internal object Object_0
		{
			[CompilerGenerated]
			get
			{
				return this.object_0;
			}
			[CompilerGenerated]
			set
			{
				this.object_0 = value;
			}
		}

		internal ShapeObject ShapeObject_0
		{
			[CompilerGenerated]
			get
			{
				return this.shapeObject_0;
			}
			[CompilerGenerated]
			set
			{
				this.shapeObject_0 = value;
			}
		}

		internal bool Boolean_0
		{
			[CompilerGenerated]
			get
			{
				return this.bool_0;
			}
			[CompilerGenerated]
			set
			{
				this.bool_0 = value;
			}
		}

		internal Class183(ShapeType shapeType_0, Shape shape_1)
		{
			this.shape_0 = shape_1;
			this.class179_0 = Helper.GetPathSize(shapeType_0);
		}

		internal void method_0(ShapeType shapeType_0)
		{
			this.class179_0 = Helper.GetPathSize(shapeType_0);
		}

		internal void method_1()
		{
			this.shape_0.TXDrawing_0.method_80(this.shape_0);
		}
	}
}
