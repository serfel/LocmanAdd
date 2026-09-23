using System;
using System.Collections;
using ns21;
using TXTextControl.DataVisualization;

namespace TXTextControl
{
	/// <summary>Base of all collections containing frame objects.</summary>
	public abstract class FrameBaseCollection : ICollection, IEnumerable
	{
		public class FrameBaseEnumerator : IEnumerator
		{
			private int int_0;

			private FrameBaseCollection frameBaseCollection_0;

			public object Current
			{
				get
				{
					if (this.int_0 == 0)
					{
						throw new InvalidOperationException();
					}
					return this.frameBaseCollection_0.m_iEnumType switch
					{
						Enum108.const_7 => new ChartFrame(this.frameBaseCollection_0.m_tx, this.frameBaseCollection_0.m_iTextPart, this.int_0, this.frameBaseCollection_0.m_tx.control5_0[this.int_0].Component), 
						Enum108.const_5 => new TextFrame(this.frameBaseCollection_0.m_tx, this.frameBaseCollection_0.m_iTextPart, this.int_0), 
						Enum108.const_2 => new Image(this.frameBaseCollection_0.m_tx, this.frameBaseCollection_0.m_iTextPart, this.int_0), 
						Enum108.const_10 => this.frameBaseCollection_0.GetFrame(this.int_0), 
						Enum108.const_9 => new DrawingFrame(this.frameBaseCollection_0.m_tx, this.frameBaseCollection_0.m_iTextPart, this.int_0, this.frameBaseCollection_0.m_tx.control6_0[this.int_0].Component), 
						Enum108.const_8 => new BarcodeFrame(this.frameBaseCollection_0.m_tx, this.frameBaseCollection_0.m_iTextPart, this.int_0, this.frameBaseCollection_0.m_tx.control4_0[this.int_0].Component), 
						_ => throw new InvalidOperationException(), 
					};
				}
			}

			public FrameBaseEnumerator(FrameBaseCollection fbc)
			{
				this.frameBaseCollection_0 = fbc;
			}

			public bool MoveNext()
			{
				this.int_0 = this.frameBaseCollection_0.m_tx.method_29(this.frameBaseCollection_0.m_iTextPart, 1239, this.int_0, (int)this.frameBaseCollection_0.m_iEnumType);
				if (this.int_0 != 0)
				{
					return true;
				}
				return false;
			}

			public void Reset()
			{
				this.int_0 = 0;
			}
		}

		internal TextControlCore m_tx;

		internal TextPart m_iTextPart;

		private Enum108 m_iEnumType;

		int ICollection.Count => this.Count;

		/// <summary>Gets the number of elements contained in the collection.</summary>
		public int Count
		{
			get
			{
				int num = -1;
				int num2 = 0;
				do
				{
					num++;
					num2 = this.m_tx.method_29(this.m_iTextPart, 1239, num2, (int)this.m_iEnumType);
				}
				while (num2 != 0);
				return num;
			}
		}

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => this;

		internal FrameBaseCollection(TextControlCore textControlCore_0, Enum108 iType, TextPart iTextPart)
		{
			this.m_tx = textControlCore_0;
			this.m_iEnumType = iType;
			this.m_iTextPart = iTextPart;
		}

		/// <summary>Removes all objects from the collection and from the document.</summary>
		public void Clear()
		{
			int num = 0;
			this.m_tx.method_19(this.m_iTextPart, null);
			do
			{
				num = this.m_tx.method_29(this.m_iTextPart, 1239, 0, (int)this.m_iEnumType);
				if (num != 0)
				{
					this.m_tx.method_29(this.m_iTextPart, 1237, num, 0);
				}
			}
			while (num != 0);
			this.m_tx.method_20(this.m_iTextPart);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			this.CopyTo(array, index);
		}

		public abstract void CopyTo(Array array, int index);

		/// <summary>Returns an enumerator that can be used to iterate through the collection.</summary>
		public FrameBaseEnumerator GetEnumerator()
		{
			return new FrameBaseEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new FrameBaseEnumerator(this);
		}

		internal FrameBase GetFrame(int iObjectID)
		{
			switch (this.m_tx.method_29(this.m_iTextPart, 1887, iObjectID, 0))
			{
			case 5:
				return new TextFrame(this.m_tx, this.m_iTextPart, iObjectID);
			default:
				throw new InvalidOperationException();
			case 7:
			{
				object component2 = this.m_tx.control5_0[iObjectID].Component;
				if (component2 == null)
				{
					throw new InvalidOperationException();
				}
				return new ChartFrame(this.m_tx, this.m_iTextPart, iObjectID, component2);
			}
			case 8:
			{
				object component3 = this.m_tx.control4_0[iObjectID].Component;
				if (component3 == null)
				{
					throw new InvalidOperationException();
				}
				return new BarcodeFrame(this.m_tx, this.m_iTextPart, iObjectID, component3);
			}
			case 9:
			{
				object component = this.m_tx.control6_0[iObjectID].Component;
				if (component == null)
				{
					throw new InvalidOperationException();
				}
				return new DrawingFrame(this.m_tx, this.m_iTextPart, iObjectID, component);
			}
			case 0:
				return new Image(this.m_tx, this.m_iTextPart, iObjectID);
			}
		}
	}
}
