using System;
using System.Collections;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	/// <summary>Contains all editable regions in the main text or another part of a document.</summary>
	public sealed class EditableRegionCollection : ICollection, IEnumerable
	{
		/// <summary>Specifies the result when an editable region has been added to the document.</summary>
		public enum AddResult
		{
			/// <summary>An unexpected error has occurred.</summary>
			Error = 0,
			/// <summary>The editable region has successfully been inserted.</summary>
			Successful = 1,
			/// <summary>The editable region wasn't inserted because there is no selection.</summary>
			NoSelection = 2,
			/// <summary>The editable region wasn't inserted because the selection is too complex. It is not a continuous sequence of characters.</summary>
			SelectionTooComplex = 3,
			/// <summary>The editable region wasn't inserted because the specified position values are invalid. Invalid start and/or length values have been specified.</summary>
			PositionInvalid = 4,
			/// <summary>The editable region was inserted and combined with an existing one. An editable region is combined with an existing one, when it overlaps or immediately follows it and has the same user name and id.</summary>
			Combined = 8
		}

		public class EditableRegionEnumerator : IEnumerator
		{
			private EditableRegionCollection editableRegionCollection_0;

			private int int_0;

			public object Current
			{
				get
				{
					if (this.int_0 <= 0 || this.int_0 > this.editableRegionCollection_0.Count)
					{
						throw new InvalidOperationException();
					}
					return new EditableRegion(this.editableRegionCollection_0.textControlCore_0, this.editableRegionCollection_0.textPart_0, this.int_0, 0);
				}
			}

			public EditableRegionEnumerator(EditableRegionCollection stpc)
			{
				this.editableRegionCollection_0 = stpc;
				this.int_0 = 0;
			}

			public bool MoveNext()
			{
				if (this.int_0 < this.editableRegionCollection_0.Count)
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
		public int Count => this.textControlCore_0.method_29(this.textPart_0, 1979, 1, 0);

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => this;

		public EditableRegion this[int number]
		{
			get
			{
				if (number > 0 && number <= this.Count)
				{
					return new EditableRegion(this.textControlCore_0, this.textPart_0, number, 0);
				}
				return null;
			}
		}

		internal EditableRegionCollection(TextControlCore textControlCore_1, TextPart iTextPart)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
		}

		/// <summary>Adds a new editable region to the document. Its position is defined through the EditableRegion.Start and EditableRegion.Length properties. If the editable region's length is zero, the current text selection is used to define the position.</summary>
		/// <param name="editableRegion">Specifies the editable region to add.</param>
		public AddResult Add(EditableRegion editableRegion)
		{
			if (editableRegion.textControlCore_0 != null)
			{
				throw new InvalidOperationException();
			}
			AddResult addResult = AddResult.Error;
			Struct46 struct46_ = new Struct46(0, 0, editableRegion.Int32_0, editableRegion.UserName, Enum52.const_1);
			HighlightMode highlightMode = editableRegion.HighlightMode;
			struct46_.uint_0 = (uint)(editableRegion.Start - 1);
			struct46_.uint_1 = (uint)editableRegion.Length;
			struct46_.uint_2 = (uint)Class429.smethod_0(editableRegion.HighlightColor);
			struct46_.byte_0 = editableRegion.HighlightColor.A;
			struct46_.ushort_1 = (ushort)(highlightMode switch
			{
				HighlightMode.Always => 2u, 
				HighlightMode.Activated => 1u, 
				_ => 4u, 
			});
			try
			{
				int int_ = this.textControlCore_0.method_58(this.textPart_0, Enum83.const_306, 0, ref struct46_).ToInt32();
				addResult = (AddResult)Class429.smethod_6(int_);
				if (addResult == AddResult.Successful || addResult == AddResult.Combined)
				{
					editableRegion.method_1(this.textControlCore_0, this.textPart_0, struct46_.ushort_4);
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
			foreach (EditableRegion item in this)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Returns an enumerator that can be used to iterate through the collection.</summary>
		public EditableRegionEnumerator GetEnumerator()
		{
			return new EditableRegionEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new EditableRegionEnumerator(this);
		}

		/// <summary>Gets the editable region with the specified id. The method returns null, if such a region does not exist. If more than one region with this id exists, the first found region is returned.</summary>
		/// <param name="id">Specifies the editable region's identifier.</param>
		public EditableRegion GetItem(int int_0)
		{
			EditableRegion editableRegion = new EditableRegion(string.Empty, int_0);
			if (editableRegion.method_1(this.textControlCore_0, this.textPart_0, 0))
			{
				return editableRegion;
			}
			return null;
		}

		/// <summary>Gets all editable regions at the current text input position. The method returns null, if there is no region at the current input position.</summary>
		public EditableRegion[] GetItems()
		{
			EditableRegion[] result = null;
			IntPtr intPtr = this.textControlCore_0.method_64(this.textPart_0, Enum83.const_312, 1u, 0);
			if (intPtr != IntPtr.Zero)
			{
				try
				{
					int[] array = KernelHelper.PtrInt16ToIntArray(intPtr);
					result = new EditableRegion[array.Length];
					for (int i = 0; i < array.Length; i++)
					{
						result[i] = new EditableRegion(this.textControlCore_0, this.textPart_0, 0, array[i]);
					}
					return result;
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					Class429.GlobalFree(intPtr);
				}
			}
			return result;
		}

		/// <summary>Removes an editable region from the collection. The region's text is not removed.</summary>
		/// <param name="editableRegion">Specifies the editable region to remove.</param>
		/// <param name="selectedPart">When this parameter is true, only the selected part of the editable region is removed.</param>
		public bool Remove(EditableRegion editableRegion, bool selectedPart)
		{
			return editableRegion.method_0(selectedPart);
		}
	}
}
