using TXTextControl.DataVisualization;

namespace TXTextControl
{
	/// <summary>The IFormattedText interface contains properties and methods common to all text parts in a TX Text Control document.</summary>
	public interface IFormattedText
	{
		/// <summary>Gets a collection of all Microsoft Word or Heiler HighEdit fields that have been created or imported from a Microsoft Word or RTF document.</summary>
		ApplicationFieldCollection ApplicationFields { get; }

		/// <summary>Gets a collection of all images.</summary>
		ImageCollection Images { get; }

		/// <summary>Gets a collection of all hypertext links.</summary>
		HypertextLinkCollection HypertextLinks { get; }

		/// <summary>Gets a collection of all lines the text consists of.</summary>
		LineCollection Lines { get; }

		/// <summary>Gets a collection of all misspelled words.</summary>
		MisspelledWordCollection MisspelledWords { get; }

		/// <summary>Gets a collection of all paragraphs the text consists of.</summary>
		ParagraphCollection Paragraphs { get; }

		/// <summary>Gets or sets the current selection.</summary>
		Selection Selection { get; set; }

		/// <summary>Gets a collection of all tables.</summary>
		TableCollection Tables { get; }

		/// <summary>Gets a collection of all subtextparts.</summary>
		SubTextPartCollection SubTextParts { get; }

		/// <summary>Gets a collection of all characters the text consists of.</summary>
		TextCharCollection TextChars { get; }

		/// <summary>Gets a collection of all standard text fields.</summary>
		TextFieldCollection TextFields { get; }

		/// <summary>Gets a collection of all images, textframes, charts, barcodes and drawings.</summary>
		FrameCollection Frames { get; }

		/// <summary>Gets a collection of all barcodes.</summary>
		BarcodeCollection Barcodes { get; }

		/// <summary>Gets a collection of all drawings.</summary>
		DrawingCollection Drawings { get; }

		/// <summary>Gets a collection of all links which point to targets in the same document.</summary>
		DocumentLinkCollection DocumentLinks { get; }

		/// <summary>Gets a collection of all targets.</summary>
		DocumentTargetCollection DocumentTargets { get; }

		/// <summary>Gets a collection of all editable regions.</summary>
		EditableRegionCollection EditableRegions { get; }

		/// <summary>Gets a collection of all tracked changes.</summary>
		TrackedChangeCollection TrackedChanges { get; }

		/// <summary>Gets a collection of all form fields.</summary>
		FormFieldCollection FormFields { get; }

		/// <summary>Gets a collection of all tables of contents.</summary>
		TableOfContentsCollection TablesOfContents { get; }

		/// <summary>Finds a text string.</summary>
		/// <param name="text">Specifies the text to search for.</param>
		/// <param name="start">Specifies the text position where the search starts, beginning with 0.</param>
		/// <param name="options">Specifies search options.</param>
		int Find(string text, int start, FindOptions options);

		/// <summary>Returns a collection containing text fields of the specified types.</summary>
		/// <param name="fieldType">Specifies types of text fields.</param>
		TextFieldCollection GetTextFields(TextFieldType fieldType);
	}
}
