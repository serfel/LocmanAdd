using System;
using System.Collections;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	/// <summary>Contains all subtextparts in the main text or another main part of a document.</summary>
	public sealed class SubTextPartCollection : ICollection, IEnumerable
	{
		/// <summary>Specifies the result when a subtextpart has been added to the document.</summary>
		public enum AddResult
		{
			/// <summary>An unexpected error has occurred.</summary>
			Error = 0,
			/// <summary>The subtextpart has successfully been inserted.</summary>
			Successful = 1,
			/// <summary>The subtextpart wasn't inserted because there is no selection.</summary>
			NoSelection = 2,
			/// <summary>The subtextpart wasn't inserted because the selection is too complex. It is not a continuous sequence of characters.</summary>
			SelectionTooComplex = 3,
			/// <summary>The subtextpart wasn't inserted because the specified position values are invalid. Invalid start and/or length values have been specified.</summary>
			PositionInvalid = 4,
			/// <summary>The subtextpart wasn't inserted because it already exists.</summary>
			AlreadyExists = 5,
			/// <summary>The subtextpart wasn't inserted because it overlaps with an existing textpart.</summary>
			Overlapping = 7,
			/// <summary>The subtextpart was inserted and combined with an existing one. A subtextpart is combined with an existing one, when it immediately follows it and has the same name and id.</summary>
			Combined = 8
		}

		public class SubTextPartEnumerator : IEnumerator
		{
			private SubTextPartCollection subTextPartCollection_0;

			private int int_0;

			public object Current
			{
				get
				{
					if (this.int_0 <= 0 || this.int_0 > this.subTextPartCollection_0.Count)
					{
						throw new InvalidOperationException();
					}
					return new SubTextPart(this.subTextPartCollection_0.textControlCore_0, this.subTextPartCollection_0.textPart_0, this.int_0, 0);
				}
			}

			public SubTextPartEnumerator(SubTextPartCollection stpc)
			{
				this.subTextPartCollection_0 = stpc;
				this.int_0 = 0;
			}

			public bool MoveNext()
			{
				if (this.int_0 < this.subTextPartCollection_0.Count)
				{
					this.int_0++;
					return true;
				}
				return false;
			}

			public void Reset()
			{
				this.int_0 = 0;
			}
		}

		private TextControlCore textControlCore_0;

		private TextPart textPart_0;

		int ICollection.Count => this.Count;

		/// <summary>Gets the number of elements contained in the collection.</summary>
		public int Count => this.textControlCore_0.method_29(this.textPart_0, 1979, 0, 0);

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => this;

		public SubTextPart this[int number]
		{
			get
			{
				if (number > 0 && number <= this.Count)
				{
					return new SubTextPart(this.textControlCore_0, this.textPart_0, number, 0);
				}
				return null;
			}
		}

		internal SubTextPartCollection(TextControlCore textControlCore_1, TextPart iTextPart)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
		}

		/// <summary>Adds a new subtextpart to the document. Its position is defined through the SubTextPart.Start and SubTextPart.Length properties. If the subtextpart's length is zero, the current text selection is used to define the position.</summary>
		/// <param name="subTextPart">Specifies the subtextpart to add.</param>
		public AddResult Add(SubTextPart subTextPart)
		{
			if (subTextPart.textControlCore_0 != null)
			{
				throw new InvalidOperationException();
			}
			AddResult addResult = AddResult.Error;
			Struct46 struct46_ = new Struct46(0, 0, subTextPart.Int32_0, subTextPart.Name, Enum52.const_0);
			HighlightMode highlightMode = subTextPart.HighlightMode;
			string data = subTextPart.Data;
			struct46_.uint_0 = (uint)(subTextPart.Start - 1);
			struct46_.uint_1 = (uint)subTextPart.Length;
			struct46_.uint_2 = (uint)Class429.smethod_0(subTextPart.HighlightColor);
			struct46_.byte_0 = subTextPart.HighlightColor.A;
			struct46_.ushort_1 = (ushort)(highlightMode switch
			{
				HighlightMode.Always => 2u, 
				HighlightMode.Activated => 1u, 
				_ => 4u, 
			});
			struct46_.intptr_1 = ((data == null || data == string.Empty) ? IntPtr.Zero : Marshal.StringToBSTR(data));
			try
			{
				int int_ = this.textControlCore_0.method_58(this.textPart_0, Enum83.const_306, 0, ref struct46_).ToInt32();
				addResult = (AddResult)Class429.smethod_6(int_);
				if (addResult == AddResult.Successful || addResult == AddResult.Combined)
				{
					subTextPart.method_1(this.textControlCore_0, this.textPart_0, struct46_.ushort_4);
					return addResult;
				}
				return addResult;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				Marshal.FreeBSTR(struct46_.intptr_0);
				Marshal.FreeBSTR(struct46_.intptr_1);
			}
		}

		void ICollection.CopyTo(Array array, int index)
		{
			this.CopyTo(array, index);
		}

		/// <summary>Copies the elements of the collection to an array, starting at a particular index.</summary>
		/// <param name="array">Specifies the array to copy to.</param>
		/// <param name="index">Specifies the index of the destination array at which to begin copying.</param>
		public void CopyTo(Array array, int index)
		{
			foreach (SubTextPart item in this)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Returns an enumerator that can be used to iterate through the collection.</summary>
		public SubTextPartEnumerator GetEnumerator()
		{
			return new SubTextPartEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new SubTextPartEnumerator(this);
		}

		/// <summary>Gets the subtextpart at the current text input position. If there is more than one textpart at the current input position the textpart with the highest level is returned.</summary>
		public SubTextPart GetItem()
		{
			int num = this.textControlCore_0.method_29(this.textPart_0, 1982, 0, 0);
			if (num != 0)
			{
				return new SubTextPart(this.textControlCore_0, this.textPart_0, 0, num);
			}
			return null;
		}

		/// <summary>Gets the subtextpart with the specified name. The method returns null, if such a textpart does not exist. If more than one textpart with this name exists, the first found textpart is returned.</summary>
		/// <param name="name">Specifies the textpart's name set with the Name property.</param>
		public SubTextPart GetItem(string name)
		{
			SubTextPart subTextPart = new SubTextPart(name, 0);
			if (subTextPart.method_1(this.textControlCore_0, this.textPart_0, 0))
			{
				return subTextPart;
			}
			return null;
		}

		/// <summary>Gets the subtextpart with the specified id. The method returns null, if such a textpart does not exist. If more than one textpart with this id exists, the first found textpart is returned.</summary>
		/// <param name="id">Specifies the textpart's identifier.</param>
		public SubTextPart GetItem(int int_0)
		{
			SubTextPart subTextPart = new SubTextPart(string.Empty, int_0);
			if (subTextPart.method_1(this.textControlCore_0, this.textPart_0, 0))
			{
				return subTextPart;
			}
			return null;
		}

		/// <summary>Removes a subtextpart from the collection including all its nested subtextparts.</summary>
		/// <param name="subTextPart">Specifies the subtextpart to remove.</param>
		/// <param name="keepText">If this parameter is set to true, the subtextpart is removed without deleting its visible text.</param>
		/// <param name="keepNested">If this parameter is set to true, nested subtextparts are preserved.</param>
		public bool Remove(SubTextPart subTextPart, bool keepText, bool keepNested)
		{
			return subTextPart.method_0(keepText, keepNested);
		}
	}
}
