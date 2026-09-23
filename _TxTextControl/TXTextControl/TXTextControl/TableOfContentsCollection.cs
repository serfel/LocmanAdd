using System;
using System.Collections;

namespace TXTextControl
{
	/// <summary>Contains all tables of contents in a certain part of the document.</summary>
	public sealed class TableOfContentsCollection : ICollection, IEnumerable
	{
		/// <summary>Specifies the result when an existing table of contents has been updated or a new table of contents has been added to the document.</summary>
		public enum AddResult
		{
			/// <summary>An unexpected error has occurred or the current text input position is a position where a table of contents cannot be inserted. Tables of content cannot be inserted in a TextField or a HypertextLink. Furthermore, tables of contents cannot be nested.</summary>
			Error,
			/// <summary>The table of contents could not be inserted or updated because it has no content. A paragraph with a structure level as specified through the TableOfContents.MinimumStructureLevel and TableOfContents.MaximumStructureLevel properties could not be found.</summary>
			ContentNotFound,
			/// <summary>The table of contents has successfully been inserted or updated.</summary>
			Successful
		}

		public class TableOfContentEnumerator : IEnumerator
		{
			private TableOfContentsCollection tableOfContentsCollection_0;

			private int int_0;

			public object Current
			{
				get
				{
					if (this.int_0 <= 0 || this.int_0 > this.tableOfContentsCollection_0.Count)
					{
						throw new InvalidOperationException();
					}
					return new TableOfContents(this.tableOfContentsCollection_0.textControlCore_0, this.tableOfContentsCollection_0.textPart_0, this.int_0, 0);
				}
			}

			public TableOfContentEnumerator(TableOfContentsCollection tocc)
			{
				this.tableOfContentsCollection_0 = tocc;
				this.int_0 = 0;
			}

			public bool MoveNext()
			{
				if (this.int_0 < this.tableOfContentsCollection_0.Count)
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
		public int Count => this.textControlCore_0.method_29(this.textPart_0, 1979, 4, 0);

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => this;

		public TableOfContents this[int number]
		{
			get
			{
				if (number > 0 && number <= this.Count)
				{
					return new TableOfContents(this.textControlCore_0, this.textPart_0, number, 0);
				}
				return null;
			}
		}

		internal TableOfContentsCollection(TextControlCore textControlCore_1, TextPart iTextPart)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = iTextPart;
		}

		/// <summary>Adds a new table of contents to the document at the current text input position.</summary>
		/// <param name="tableOfContent">Specifies the table of contents to add.</param>
		public AddResult Add(TableOfContents tableOfContent)
		{
			if (tableOfContent.textControlCore_0 != null)
			{
				throw new InvalidOperationException();
			}
			return (AddResult)tableOfContent.method_0(this.textControlCore_0, this.textPart_0);
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
			foreach (TableOfContents item in this)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Returns an enumerator that can be used to iterate through the collection.</summary>
		public TableOfContentEnumerator GetEnumerator()
		{
			return new TableOfContentEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new TableOfContentEnumerator(this);
		}

		/// <summary>Gets the table of contents at the current text input position. If there is no table of contents, null is returned.</summary>
		public TableOfContents GetItem()
		{
			int num = this.textControlCore_0.method_29(this.textPart_0, 1982, 4, 0);
			if (num != 0)
			{
				return new TableOfContents(this.textControlCore_0, this.textPart_0, 0, num);
			}
			return null;
		}

		/// <summary>Gets the table of contents with the specified id. The method returns null, if such a table of contents does not exist. If more than one table of contents with this id exists, the first found table of contents is returned.</summary>
		/// <param name="id">Specifies the identifier of the table of contents.</param>
		public TableOfContents GetItem(int int_0)
		{
			TableOfContents tableOfContents = new TableOfContents(string.Empty, int_0);
			if (tableOfContents.method_2(this.textControlCore_0, this.textPart_0, 0, bool_3: true))
			{
				return tableOfContents;
			}
			return null;
		}

		/// <summary>Gets the table of contents with the specified name. The method returns null, if such a table of contents does not exist. If more than one table of contents with this name exists, the first found table of contents is returned.</summary>
		/// <param name="name">Specifies the name set with the Name property.</param>
		public TableOfContents GetItem(string name)
		{
			TableOfContents tableOfContents = new TableOfContents(name, 0);
			if (tableOfContents.method_2(this.textControlCore_0, this.textPart_0, 0, bool_3: true))
			{
				return tableOfContents;
			}
			return null;
		}

		/// <summary>Removes a table of contents from the collection including all its text and including all DocumentTargets to where the table's links point.</summary>
		/// <param name="tableOfContent">Specifies the table of contents to remove.</param>
		public bool Remove(TableOfContents tableOfContent)
		{
			return tableOfContent.method_1();
		}
	}
}
