using System;
using System.Collections;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	/// <summary>The DocumentTargetCollection contains a collection of targets.</summary>
	public sealed class DocumentTargetCollection : ICollection, IEnumerable
	{
		public class DocumentTargetEnumerator : IEnumerator
		{
			private DocumentTargetCollection documentTargetCollection_0;

			private int int_0;

			public object Current
			{
				get
				{
					if (this.int_0 <= 0 || this.int_0 > this.documentTargetCollection_0.Count)
					{
						throw new InvalidOperationException();
					}
					return new DocumentTarget(this.documentTargetCollection_0.textControlCore_0, this.documentTargetCollection_0.textPart_0, this.int_0, 0);
				}
			}

			public DocumentTargetEnumerator(DocumentTargetCollection dtc)
			{
				this.documentTargetCollection_0 = dtc;
				this.int_0 = 0;
			}

			public bool MoveNext()
			{
				if (this.int_0 < this.documentTargetCollection_0.Count)
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

		/// <summary>Gets a value indicating whether a new document target can be inserted at the current text input position.</summary>
		public bool CanAdd => true;

		int ICollection.Count => this.Count;

		/// <summary>Gets the number of elements contained in the collection.</summary>
		public int Count => this.textControlCore_0.method_29(this.textPart_0, 1979, 3, 0);

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => this;

		public DocumentTarget this[int number]
		{
			get
			{
				if (number > 0 && number <= this.Count)
				{
					return new DocumentTarget(this.textControlCore_0, this.textPart_0, number, 0);
				}
				return null;
			}
		}

		internal DocumentTargetCollection(TextControlCore textControlCore_1, TextPart iTextPart)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
		}

		/// <summary>Inserts the specified target at the current text input position.</summary>
		/// <param name="documentTarget">Specifies the document target to add.</param>
		public bool Add(DocumentTarget documentTarget)
		{
			if (documentTarget.textControlCore_0 != null)
			{
				throw new InvalidOperationException();
			}
			int num = 0;
			Struct46 struct46_ = new Struct46(0, 0, documentTarget.Int32_0, documentTarget.Name, Enum52.const_3);
			string targetName = documentTarget.TargetName;
			struct46_.uint_0 = (uint)(documentTarget.Start - 1);
			struct46_.uint_1 = 0u;
			struct46_.intptr_1 = ((targetName == null || targetName == string.Empty) ? IntPtr.Zero : Marshal.StringToBSTR(targetName));
			struct46_.ushort_1 = (ushort)((!documentTarget.Deleteable) ? 64u : 0u);
			try
			{
				int int_ = this.textControlCore_0.method_58(this.textPart_0, Enum83.const_306, 0, ref struct46_).ToInt32();
				num = Class429.smethod_6(int_);
				if (num == 1)
				{
					documentTarget.method_1(this.textControlCore_0, this.textPart_0, struct46_.ushort_4);
				}
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
			return num == 1;
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
			foreach (DocumentTarget item in this)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Returns an enumerator that can be used to iterate through the collection.</summary>
		public DocumentTargetEnumerator GetEnumerator()
		{
			return new DocumentTargetEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new DocumentTargetEnumerator(this);
		}

		/// <summary>Gets the first document target at the current text input position or null if there is no document target. This method is for compatibility only with prior versions. Use GetItems to get all targets at the current text input position.</summary>
		public DocumentTarget GetItem()
		{
			DocumentTarget[] items = this.GetItems();
			if (items == null)
			{
				return null;
			}
			return items[0];
		}

		/// <summary>Gets the document target with the specified target name, previously set with the DocumentTarget.TargetName property.</summary>
		/// <param name="targetName">Specifies the document target's target name.</param>
		public DocumentTarget GetItem(string targetName)
		{
			DocumentTarget documentTarget = new DocumentTarget(targetName);
			if (documentTarget.method_1(this.textControlCore_0, this.textPart_0, 0))
			{
				return documentTarget;
			}
			return null;
		}

		/// <summary>Gets the document target with the specified id, previously set with the DocumentTarget.ID property.</summary>
		/// <param name="id">Specifies the document target's identifier.</param>
		public DocumentTarget GetItem(int int_0)
		{
			DocumentTarget documentTarget = new DocumentTarget(string.Empty);
			documentTarget.Int32_0 = int_0;
			if (documentTarget.method_1(this.textControlCore_0, this.textPart_0, 0))
			{
				return documentTarget;
			}
			return null;
		}

		/// <summary>Gets all document targets at the current text input position. The method returns null, if there is no target at the current input position.</summary>
		public DocumentTarget[] GetItems()
		{
			DocumentTarget[] result = null;
			IntPtr intPtr = this.textControlCore_0.method_64(this.textPart_0, Enum83.const_312, 3u, 0);
			if (intPtr != IntPtr.Zero)
			{
				try
				{
					int[] array = KernelHelper.PtrInt16ToIntArray(intPtr);
					result = new DocumentTarget[array.Length];
					for (int i = 0; i < array.Length; i++)
					{
						result[i] = new DocumentTarget(this.textControlCore_0, this.textPart_0, 0, array[i]);
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

		/// <summary>Removes the specified target from a Text Control document.</summary>
		/// <param name="documentTarget">Specifies the document target to remove.</param>
		public bool Remove(DocumentTarget documentTarget)
		{
			return documentTarget.method_0();
		}

		/// <summary>Removes all document targets from a Text Control document.</summary>
		public void Clear()
		{
			this.textControlCore_0.method_19(this.textPart_0, null);
			try
			{
				foreach (DocumentTarget item in this)
				{
					this.Remove(item);
				}
			}
			catch
			{
			}
			this.textControlCore_0.method_20(this.textPart_0);
		}
	}
}
