using System;
using ns21;

namespace TXTextControl
{
	/// <summary>The HypertextLinkCollection object contains all hypertext links in a Text Control document.</summary>
	public sealed class HypertextLinkCollection : TextFieldCollectionBase
	{
		public HypertextLink this[int number]
		{
			get
			{
				int num = base.m_tx.method_29(base.m_iTextPart, 2006, number, 512);
				if (num == 0)
				{
					return null;
				}
				return new HypertextLink(base.m_tx, base.m_iTextPart, num);
			}
		}

		internal HypertextLinkCollection(TextControlCore textControlCore_0, TextPart iTextPart)
			: base(textControlCore_0, Enum106.const_5, iTextPart)
		{
		}

		/// <summary>Copies the elements of the collection to an array, starting at a particular index.</summary>
		/// <param name="array">Specifies the array to copy to.</param>
		/// <param name="index">Specifies the index of the destination array at which to begin copying.</param>
		public override void CopyTo(Array array, int index)
		{
			HypertextLinkCollection hypertextLinkCollection = new HypertextLinkCollection(base.m_tx, base.m_iTextPart);
			foreach (HypertextLink item in hypertextLinkCollection)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Inserts a new hypertext link at the current input position.</summary>
		/// <param name="hypertextLink">Specifies the hypertext link to add.</param>
		public bool Add(HypertextLink hypertextLink)
		{
			return hypertextLink.method_1(base.m_tx, base.m_iTextPart);
		}

		/// <summary>Removes all hypertext links from a Text Control document.</summary>
		/// <param name="keepText">If this parameter is set to true, all hypertext links are removed without deleting their texts.</param>
		public void Clear(bool keepText)
		{
			base.DeleteAllFields(keepText);
		}

		/// <summary>Removes a hypertext link including its visible text from a Text Control document.</summary>
		/// <param name="hypertextLink">Specifies the hypertext link to remove.</param>
		public bool Remove(HypertextLink hypertextLink)
		{
			return hypertextLink.method_2(bool_9: false);
		}

		/// <summary>Removes a hypertext link from a Text Control document. The visible text is deleted depending on the keepText parameter.</summary>
		/// <param name="hypertextLink">Specifies the hypertext link to remove.</param>
		/// <param name="keepText">If this parameter is set to true, the hypertext link is removed without deleting its text.</param>
		public bool Remove(HypertextLink hypertextLink, bool keepText)
		{
			return hypertextLink.method_2(keepText);
		}

		/// <summary>Gets the hypertext link at the current input position or null if there is no hypertext link at the current input position.</summary>
		public HypertextLink GetItem()
		{
			int num = base.m_tx.method_29(base.m_iTextPart, 1218, 0, 512);
			if (num == 0)
			{
				return null;
			}
			return new HypertextLink(base.m_tx, base.m_iTextPart, num);
		}

		/// <summary>Gets the hypertext link with the specified id. An id can be set with the HypertextLink.ID property.</summary>
		/// <param name="id">Specifies the hypertext link's identifier.</param>
		public HypertextLink GetItem(int int_0)
		{
			foreach (HypertextLink item in this)
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
