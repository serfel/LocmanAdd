using System;
using ns21;

namespace TXTextControl
{
	/// <summary>The DocumentLinkCollection contains a collection of document links .</summary>
	public sealed class DocumentLinkCollection : TextFieldCollectionBase
	{
		public DocumentLink this[int number]
		{
			get
			{
				int num = base.m_tx.method_29(base.m_iTextPart, 2006, number, 1024);
				if (num == 0)
				{
					return null;
				}
				return new DocumentLink(base.m_tx, base.m_iTextPart, num);
			}
		}

		internal DocumentLinkCollection(TextControlCore textControlCore_0, TextPart iTextPart)
			: base(textControlCore_0, Enum106.const_6, iTextPart)
		{
		}

		/// <summary>Copies the elements of the collection to an array, starting at a particular index.</summary>
		/// <param name="array">Specifies the array to copy to.</param>
		/// <param name="index">Specifies the index of the destination array at which to begin copying.</param>
		public override void CopyTo(Array array, int index)
		{
			DocumentLinkCollection documentLinkCollection = new DocumentLinkCollection(base.m_tx, base.m_iTextPart);
			foreach (DocumentLink item in documentLinkCollection)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Inserts a new document link at the current input position.</summary>
		/// <param name="documentLink">Specifies the document link to add.</param>
		public bool Add(DocumentLink documentLink)
		{
			return documentLink.method_1(base.m_tx, base.m_iTextPart);
		}

		/// <summary>Removes all document links from a Text Control document.</summary>
		/// <param name="keepText">If this parameter is set to true, all document links are removed without deleting their texts.</param>
		public void Clear(bool keepText)
		{
			base.DeleteAllFields(keepText);
		}

		/// <summary>Removes a document link including its visible text from a Text Control document.</summary>
		/// <param name="documentLink">Specifies the document link to remove.</param>
		public bool Remove(DocumentLink documentLink)
		{
			return documentLink.method_2(bool_9: false);
		}

		/// <summary>Removes a document link from a Text Control document. The visible text is deleted depending on the keepText parameter.</summary>
		/// <param name="documentLink">Specifies the document link to remove.</param>
		/// <param name="keepText">If this parameter is set to true, the document link is removed without deleting its text.</param>
		public bool Remove(DocumentLink documentLink, bool keepText)
		{
			return documentLink.method_2(keepText);
		}

		/// <summary>Gets the document link at the current input position or null if there is no document link at the current input position.</summary>
		public DocumentLink GetItem()
		{
			int num = base.m_tx.method_29(base.m_iTextPart, 1218, 0, 1024);
			if (num == 0)
			{
				return null;
			}
			return new DocumentLink(base.m_tx, base.m_iTextPart, num);
		}

		/// <summary>Gets the document link with the specified id, previously set with the DocumentLink.ID property.</summary>
		/// <param name="id">Specifies the document link's identifier.</param>
		public DocumentLink GetItem(int int_0)
		{
			foreach (DocumentLink item in this)
			{
				if (item.Int32_0 == int_0)
				{
					return item;
				}
			}
			return null;
		}
	}
}
