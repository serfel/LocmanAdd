using System;
using ns21;

namespace TXTextControl
{
	/// <summary>An instance of the InlineStyleCollection class contains all inline formatting styles in the current document represented through objects of the type InlineStyle.</summary>
	public sealed class InlineStyleCollection : FormattingStyleCollection
	{
		internal InlineStyleCollection(TextControlCore textControlCore_0)
			: base(textControlCore_0, Enum58.const_1)
		{
		}

		/// <summary>Adds to new formatting style to the current document.</summary>
		/// <param name="inlineStyle">Specifies the style to add.</param>
		public bool Add(InlineStyle inlineStyle)
		{
			return inlineStyle.method_0(base.m_tx);
		}

		/// <summary>Copies the elements of the collection to an array, starting at a particular index.</summary>
		/// <param name="array">Specifies the array to copy to.</param>
		/// <param name="index">Specifies the index of the destination array at which to begin copying.</param>
		public override void CopyTo(Array array, int index)
		{
			InlineStyleCollection inlineStyleCollection = new InlineStyleCollection(base.m_tx);
			foreach (InlineStyle item in inlineStyleCollection)
			{
				array.SetValue(item, index++);
			}
		}

		/// <summary>Gets a particular style from the collection.</summary>
		/// <param name="styleName">Specifies the name of the style.</param>
		public InlineStyle GetItem(string styleName)
		{
			if (base.m_strStyleNames != null)
			{
				string[] strStyleNames = base.m_strStyleNames;
				foreach (string text in strStyleNames)
				{
					if (text == styleName)
					{
						return new InlineStyle(base.m_tx, styleName);
					}
				}
			}
			return null;
		}
	}
}
