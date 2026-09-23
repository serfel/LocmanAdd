using System;
using ns21;

namespace TXTextControl
{
	/// <summary>An instance of the ParagraphStyleCollection class contains all paragraph formatting styles in the current document represented through objects of the type ParagraphStyle.</summary>
	public sealed class ParagraphStyleCollection : FormattingStyleCollection
	{
		internal ParagraphStyleCollection(TextControlCore textControlCore_0)
			: base(textControlCore_0, Enum58.const_0)
		{
		}

		/// <summary>Adds to new formatting style to the current document.</summary>
		/// <param name="paragraphStyle">Specifies the style to add.</param>
		public bool Add(ParagraphStyle paragraphStyle)
		{
			return paragraphStyle.method_0(base.m_tx);
		}

		/// <summary>Copies the elements of the collection to an array, starting at a particular index.</summary>
		/// <param name="array">Specifies the array to copy to.</param>
		/// <param name="index">Specifies the index of the destination array at which to begin copying.</param>
		public override void CopyTo(Array array, int index)
		{
			ParagraphStyleCollection paragraphStyleCollection = new ParagraphStyleCollection(base.m_tx);
			foreach (ParagraphStyle item in paragraphStyleCollection)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Gets a particular style from the collection.</summary>
		/// <param name="styleName">Specifies the name of the style.</param>
		public ParagraphStyle GetItem(string styleName)
		{
			if (base.m_strStyleNames != null)
			{
				string[] strStyleNames = base.m_strStyleNames;
				foreach (string text in strStyleNames)
				{
					if (text == styleName)
					{
						return new ParagraphStyle(base.m_tx, styleName);
					}
				}
			}
			return null;
		}
	}
}
