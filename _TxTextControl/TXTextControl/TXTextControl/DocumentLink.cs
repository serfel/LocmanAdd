using System;
using System.ComponentModel;
using ns21;

namespace TXTextControl
{
	/// <summary>The DocumentLink class represents a link in a Text Control document that points to a target in the same document.</summary>
	public class DocumentLink : TextField
	{
		/// <summary>Gets or sets an object of the type DocumentTarget specifying to where the link points.</summary>
		[Browsable(false)]
		public DocumentTarget DocumentTarget
		{
			get
			{
				if (base.textControlCore_0 != null)
				{
					DocumentTargetCollection documentTargetCollection = new DocumentTargetCollection(base.textControlCore_0, base.textPart_0);
					return documentTargetCollection.GetItem(base.String_0);
				}
				return new DocumentTarget(base.String_0);
			}
			set
			{
				base.String_0 = value.TargetName;
			}
		}

		/// <summary>Gets the type of auto-generation.</summary>
		[Browsable(false)]
		public AutoGenerationType AutoGenerationType => base.AutoGenerationType_0;

		/// <summary>Initializes a new instance of the DocumentLink class.</summary>
		/// <param name="text">Specifies the visible text of the link.</param>
		/// <param name="documentTarget">Specifies an object of the type DocumentTarget specifying to where the link points.</param>
		public DocumentLink(string text, DocumentTarget documentTarget)
			: base(text)
		{
			if (documentTarget.TargetName.Length == 0)
			{
				throw new ArgumentOutOfRangeException("documentTarget.TargetName");
			}
			base.String_0 = documentTarget.TargetName;
			base.enum105_0 = Enum105.const_2;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal DocumentLink(TextControlCore textControlCore_1, TextPart iTextPart, int iFieldID)
			: base(textControlCore_1, iTextPart, iFieldID)
		{
			base.enum105_0 = Enum105.const_2;
		}
	}
}
