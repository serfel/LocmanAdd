using System.Collections.Generic;
using System.IO;
using TXTextControl.Drawing;

namespace ns17
{
	internal class Class371
	{
		private bool bool_0;

		private bool bool_1;

		private int int_0 = 10;

		private int int_1 = -1;

		private MemoryStream[] memoryStream_0;

		private TXDrawing txdrawing_0;

		internal bool Boolean_0 => this.bool_0;

		internal bool Boolean_1 => this.bool_1;

		internal Class371(TXDrawing txdrawing_1)
		{
			this.txdrawing_0 = txdrawing_1;
			this.memoryStream_0 = new MemoryStream[this.int_0];
			this.method_0();
		}

		internal void method_0()
		{
			MemoryStream memoryStream = new MemoryStream();
			Serializer.Save(this.txdrawing_0, memoryStream, SerializationFormat.Xml, this.txdrawing_0.ShapeCollection_0.method_13(), this.txdrawing_0.IsCanvasVisible, 0);
			this.int_1++;
			if (this.int_1 == this.memoryStream_0.Length)
			{
				this.method_3();
			}
			this.memoryStream_0[this.int_1] = memoryStream;
			this.method_1(this.int_1 + 1);
			this.method_8();
			this.method_7();
		}

		private void method_1(int int_2)
		{
			while (int_2 < this.memoryStream_0.Length && this.memoryStream_0[int_2] != null)
			{
				this.memoryStream_0[int_2] = null;
				int_2++;
			}
		}

		internal void method_2()
		{
			MemoryStream[] array = new MemoryStream[this.memoryStream_0.Length];
			int num = 0;
			for (int i = this.int_1; i < this.memoryStream_0.Length && this.memoryStream_0[i] != null; i++)
			{
				array[num] = this.memoryStream_0[i];
				num++;
			}
			this.memoryStream_0 = array;
			this.int_1 = 0;
			this.method_8();
			this.method_7();
		}

		private void method_3()
		{
			MemoryStream[] array = new MemoryStream[this.memoryStream_0.Length + this.int_0];
			for (int i = 0; i < this.memoryStream_0.Length; i++)
			{
				array[i] = this.memoryStream_0[i];
			}
			this.memoryStream_0 = array;
		}

		internal bool method_4(bool bool_2)
		{
			if (this.bool_0)
			{
				this.int_1++;
				this.method_5(this.memoryStream_0[this.int_1], bool_2);
				this.method_8();
				this.method_7();
				return true;
			}
			return false;
		}

		private void method_5(MemoryStream memoryStream_1, bool bool_2)
		{
			memoryStream_1.Position = 0L;
			Serializer.Load(memoryStream_1, SerializationFormat.Xml, out var shapes, this.txdrawing_0, addShapeOffset: false);
			this.txdrawing_0.Boolean_5 = false;
			this.txdrawing_0.ShapeCollection_0.Clear();
			List<Shape> list = new List<Shape>();
			for (int i = 0; i < shapes.Length; i++)
			{
				Shape shape = shapes[i];
				shape.Boolean_9 = false;
				shapes[i].Double_0 = shapes[i].Class174_0.Class172_0.Double_0;
				this.txdrawing_0.ShapeCollection_0.method_2(shapes[i], ShapeCollection.AddStyle.None);
				if (shapes[i].Boolean_8)
				{
					list.Add(shape);
				}
				if (shapes[i].Boolean_7)
				{
					shapes[i].method_2();
				}
			}
			this.txdrawing_0.ShapeCollection_0.method_10();
			this.txdrawing_0.Selection_0.method_22(list.ToArray());
			this.txdrawing_0.Boolean_5 = true;
			this.txdrawing_0.method_77();
		}

		internal bool method_6(bool bool_2)
		{
			if (this.bool_1)
			{
				this.int_1--;
				this.method_5(this.memoryStream_0[this.int_1], bool_2);
				this.method_8();
				this.method_7();
				return true;
			}
			return false;
		}

		private void method_7()
		{
			if (this.bool_0 != (this.bool_0 = this.int_1 + 1 < this.memoryStream_0.Length && this.memoryStream_0[this.int_1 + 1] != null))
			{
				this.txdrawing_0.method_2("CanRedo");
			}
		}

		private void method_8()
		{
			if (this.bool_1 != (this.bool_1 = this.int_1 > 0))
			{
				this.txdrawing_0.method_2("CanUndo");
			}
		}
	}
}
