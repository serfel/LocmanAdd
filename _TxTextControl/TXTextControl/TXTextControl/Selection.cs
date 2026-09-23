using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	/// <summary>The Selection class describes and handles the attributes of a text selection.</summary>
	public class Selection
	{
		/// <summary>Determines a certain selection attribute.</summary>
		public enum Attribute
		{
			/// <summary>Specifies the attribute set through the Baseline property.</summary>
			Baseline = 1,
			/// <summary>Specifies the attribute set through the Bold property.</summary>
			Bold = 2,
			/// <summary>Specifies the attribute set through the Italic property.</summary>
			Italic = 4,
			/// <summary>Specifies the attribute set through the FontName property.</summary>
			FontName = 8,
			/// <summary>Specifies the attribute set through the FontSize property.</summary>
			FontSize = 0x10,
			/// <summary>Specifies the attribute set through the Strikeout property.</summary>
			Strikeout = 0x20,
			/// <summary>Specifies the attribute set through the Underline property.</summary>
			Underline = 0x40,
			/// <summary>Specifies the attribute set through the ForeColor property.</summary>
			ForeColor = 0x100,
			/// <summary>Specifies the attribute set through the TextBackColor property.</summary>
			TextBackColor = 0x200,
			/// <summary>Specifies the attribute set through the Start property.</summary>
			Start = 0x400,
			/// <summary>Specifies the attribute set through the Length property.</summary>
			Length = 0x800,
			/// <summary>Specifies the attribute set through the Text property.</summary>
			Text = 0x1000,
			/// <summary>Specifies the attribute set through the FormattingStyle property.</summary>
			FormattingStyle = 0x2000,
			/// <summary>Specifies the attribute set through the Culture property.</summary>
			Culture = 0x4000,
			/// <summary>Specifies all attributes of the Selection.</summary>
			All = 0x7FFF
		}

		/// <summary>Specifies identifiers to indicate the return value of a dialog box.</summary>
		public enum DialogResult
		{
			/// <summary>Specifies that the dialog box has been left with the Escape key.</summary>
			None,
			/// <summary>Specifies that the dialog box has been canceled.</summary>
			Cancel,
			const_2
		}

		internal const string string_0 = "Arial";

		private const int int_0 = 200;

		private Attribute attribute_0;

		private Attribute attribute_1;

		private Attribute attribute_2;

		private TextControlCore textControlCore_0;

		private TextPart textPart_0;

		private int int_1;

		private int int_2;

		private string string_1 = string.Empty;

		private int int_3;

		private string string_2 = "Arial";

		private int int_4 = 200;

		private bool bool_0;

		private bool bool_1;

		private FontUnderlineStyle fontUnderlineStyle_0 = FontUnderlineStyle.None;

		private bool bool_2;

		private Color color_0 = SystemColors.WindowText;

		private Color color_1 = SystemColors.Window;

		private ParagraphFormat paragraphFormat_0 = new ParagraphFormat(-1);

		private ListFormat listFormat_0 = new ListFormat(-1);

		private SectionFormat sectionFormat_0 = new SectionFormat();

		private string string_3 = string.Empty;

		private CultureInfo cultureInfo_0;

		/// <summary>Gets or sets the baseline alignment, in twips, of the selected text.</summary>
		[DefaultValue(0)]
		[Browsable(false)]
		public int Baseline
		{
			get
			{
				this.method_3(Attribute.Baseline);
				return this.int_3;
			}
			set
			{
				if (value < -960 || value > 960)
				{
					throw new ArgumentOutOfRangeException();
				}
				this.int_3 = value;
				this.attribute_0 |= Attribute.Baseline;
				this.method_4();
			}
		}

		/// <summary>Gets or sets the bold attribute of the selected text.</summary>
		[Browsable(false)]
		[DefaultValue(false)]
		public bool Bold
		{
			get
			{
				this.method_3(Attribute.Bold);
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
				this.attribute_0 |= Attribute.Bold;
				this.method_4();
			}
		}

		/// <summary>Gets or sets the culture of the selected text.</summary>
		public CultureInfo Culture
		{
			get
			{
				this.method_3(Attribute.Culture);
				return this.cultureInfo_0;
			}
			set
			{
				this.cultureInfo_0 = value;
				this.attribute_0 |= Attribute.Culture;
				this.method_4();
			}
		}

		/// <summary>Gets or sets the font of the selected text.</summary>
		[Browsable(false)]
		public string FontName
		{
			get
			{
				this.method_3(Attribute.FontName);
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
				this.attribute_0 |= Attribute.FontName;
				this.method_4();
			}
		}

		/// <summary>Gets or sets the font's size, in twips, of the selected text.</summary>
		[DefaultValue(200)]
		[Browsable(false)]
		public int FontSize
		{
			get
			{
				this.method_3(Attribute.FontSize);
				return this.int_4;
			}
			set
			{
				this.int_4 = value;
				this.attribute_0 |= Attribute.FontSize;
				this.method_4();
			}
		}

		/// <summary>Returns or sets the color used to display the selected text.</summary>
		[Browsable(false)]
		public Color ForeColor
		{
			get
			{
				this.method_3(Attribute.ForeColor);
				return this.color_0;
			}
			set
			{
				this.color_0 = value;
				this.attribute_0 |= Attribute.ForeColor;
				this.method_4();
			}
		}

		/// <summary>Gets or sets the formatting style of the selected text.</summary>
		[Browsable(false)]
		public string FormattingStyle
		{
			get
			{
				this.method_3(Attribute.FormattingStyle);
				return this.string_3;
			}
			set
			{
				this.string_3 = value;
				this.attribute_0 |= Attribute.FormattingStyle;
				this.method_4();
			}
		}

		/// <summary>Gets or sets the italic attribute of the selected text.</summary>
		[DefaultValue(false)]
		[Browsable(false)]
		public bool Italic
		{
			get
			{
				this.method_3(Attribute.Italic);
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
				this.attribute_0 |= Attribute.Italic;
				this.method_4();
			}
		}

		/// <summary>Returns or sets the number of characters selected.</summary>
		[Browsable(false)]
		[DefaultValue(0)]
		public int Length
		{
			get
			{
				this.method_3(Attribute.Length);
				return this.int_2;
			}
			set
			{
				this.int_2 = value;
				this.attribute_0 |= Attribute.Length;
				this.method_4();
			}
		}

		/// <summary>Gets or sets a bulleted or numbered list and/or its formatting attributes for the selected text.</summary>
		[Browsable(false)]
		public ListFormat ListFormat
		{
			get
			{
				return this.listFormat_0;
			}
			set
			{
				value.method_3(this.listFormat_0);
				this.listFormat_0.method_12();
			}
		}

		/// <summary>Gets or sets the formatting attributes of the selected paragraphs.</summary>
		[Browsable(false)]
		public ParagraphFormat ParagraphFormat
		{
			get
			{
				return this.paragraphFormat_0;
			}
			set
			{
				value.method_3(this.paragraphFormat_0);
				this.paragraphFormat_0.method_11();
			}
		}

		/// <summary>Gets or sets page settings such as margins, size and orientation for the selected text.</summary>
		[Browsable(false)]
		public SectionFormat SectionFormat
		{
			get
			{
				if (this.textPart_0 != 0)
				{
					throw new NotSupportedException();
				}
				return this.sectionFormat_0;
			}
			set
			{
				if (this.textPart_0 != 0)
				{
					throw new NotSupportedException();
				}
				value.method_2(this.sectionFormat_0);
				this.sectionFormat_0.method_4();
			}
		}

		/// <summary>Gets or sets the starting point of selected text.</summary>
		[DefaultValue(0)]
		[Browsable(false)]
		public int Start
		{
			get
			{
				this.method_3(Attribute.Start);
				return this.int_1;
			}
			set
			{
				this.int_1 = value;
				this.attribute_0 |= Attribute.Start;
				this.method_4();
			}
		}

		/// <summary>Gets or sets the strikeout attribute of the selected text.</summary>
		[Browsable(false)]
		[DefaultValue(false)]
		public bool Strikeout
		{
			get
			{
				this.method_3(Attribute.Strikeout);
				return this.bool_2;
			}
			set
			{
				this.bool_2 = value;
				this.attribute_0 |= Attribute.Strikeout;
				this.method_4();
			}
		}

		/// <summary>Gets or sets a string containing the currently selected text.</summary>
		[Browsable(false)]
		public string Text
		{
			get
			{
				this.method_3(Attribute.Text);
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
				this.attribute_0 |= Attribute.Text;
				this.method_4();
			}
		}

		/// <summary>Gets or sets the background color for selected text.</summary>
		[Browsable(false)]
		public Color TextBackColor
		{
			get
			{
				this.method_3(Attribute.TextBackColor);
				return this.color_1;
			}
			set
			{
				this.color_1 = value;
				this.attribute_0 |= Attribute.TextBackColor;
				this.method_4();
			}
		}

		/// <summary>Gets or sets underlining styles for the selected text.</summary>
		[Browsable(false)]
		[DefaultValue(FontUnderlineStyle.None)]
		public FontUnderlineStyle Underline
		{
			get
			{
				this.method_3(Attribute.Underline);
				return this.fontUnderlineStyle_0;
			}
			set
			{
				this.fontUnderlineStyle_0 = value;
				this.attribute_0 |= Attribute.Underline;
				this.method_4();
			}
		}

		internal int Int32_0
		{
			get
			{
				int num = 0;
				for (int i = 0; i < 32; i++)
				{
					if (((uint)this.attribute_0 & (uint)(1 << i)) != 0)
					{
						num++;
					}
				}
				return num + this.paragraphFormat_0.Int32_0 + this.listFormat_0.Int32_0 + this.sectionFormat_0.Int32_0;
			}
		}

		/// <summary>Creates an empty Selection object with all properties set to their default values.</summary>
		public Selection()
		{
			this.method_2();
		}

		/// <summary>Creates an instance of the Selection class with the specified start value and length. All other properties are set to their default values.</summary>
		/// <param name="start">Specifies the selection's start position.</param>
		/// <param name="length">Specifies the number of selected characters.</param>
		public Selection(int start, int length)
		{
			this.method_2();
			this.int_1 = start;
			this.attribute_0 |= Attribute.Start;
			this.int_2 = length;
			this.attribute_0 |= Attribute.Length;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal Selection(TextControlCore textControlCore_1, TextPart iTextPart)
		{
			this.method_2();
			this.method_0(textControlCore_1, iTextPart);
			this.int_1 = this.Start;
			this.int_2 = this.Length;
		}

		/// <summary>Changes the writing direction of all selected paragraphs. When the direction of a paragraph is changed, this paragraph's alignment is toggled from left to right or from right to left. The alignment of centered and justified paragraphs is not changed. Left and right tabulators are also toggled.</summary>
		/// <param name="direction">Specifies the writing direction.</param>
		public bool ChangeDirection(Direction direction)
		{
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
			{
				this.paragraphFormat_0.method_12((ParagraphFormat.Attribute)262401, (ParagraphFormat.Attribute)0);
				int num = this.textControlCore_0.method_29(this.textPart_0, 1968, (direction == Direction.RightToLeft) ? 256 : 16777216, 0);
				if (num != 2)
				{
					return false;
				}
				return true;
			}
			return false;
		}

		/// <summary>Increases the font size of each font contained in the current text selection. If no text is selected, this method increases the font size at the text input position. The font sizes used with this method are the same as shown through the ButtonBar or the built-in font dialog.</summary>
		public bool GrowFont()
		{
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
			{
				int num = this.textControlCore_0.method_29(this.textPart_0, 1177, 1, 0);
				if (num != 2)
				{
					return false;
				}
				return true;
			}
			return false;
		}

		/// <summary>Decreases the font size of each font contained in the current text selection. If no text is selected, this method decreases the font size at the text input position. The font sizes used with this method are the same as shown through the ButtonBar or the built-in font dialog.</summary>
		public bool ShrinkFont()
		{
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
			{
				int num = this.textControlCore_0.method_29(this.textPart_0, 1177, 0, 0);
				if (num != 2)
				{
					return false;
				}
				return true;
			}
			return false;
		}

		/// <summary>Increases the left indent of all paragraphs contained in the current text selection. If no text is selected, this method increases the left indent at the text input position. left indent positions are defined through the paragraphs' tab positions and the indents of the paragraphs in front and behind the paragraph with the text input position.</summary>
		public bool IncreaseIndent()
		{
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
			{
				int num = this.textControlCore_0.method_29(this.textPart_0, 1952, 0, 0);
				if (num != 2)
				{
					return false;
				}
				return true;
			}
			return false;
		}

		/// <summary>Decreases the left indent of all paragraphs contained in the current text selection. If no text is selected, this method decreases the left indent at the text input position. Left indent positions are defined through the paragraphs' tab positions and the indents of the paragraphs in front and behind the paragraph with the text input position.</summary>
		public bool DecreaseIndent()
		{
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
			{
				int num = this.textControlCore_0.method_29(this.textPart_0, 1952, 1, 0);
				if (num != 2)
				{
					return false;
				}
				return true;
			}
			return false;
		}

		public bool IsCommonValueSelected(Attribute attribute)
		{
			this.method_3(attribute);
			return (this.attribute_2 & attribute) == 0;
		}

		public bool IsCommonValueSelected(ParagraphFormat.Attribute attribute)
		{
			return this.paragraphFormat_0.method_6(attribute);
		}

		public bool IsCommonValueSelected(ListFormat.Attribute attribute)
		{
			return this.listFormat_0.method_6(attribute);
		}

		public bool IsCommonValueSelected(SectionFormat.Attribute attribute)
		{
			if (this.textPart_0 != 0)
			{
				throw new NotSupportedException();
			}
			return this.sectionFormat_0.method_0(attribute);
		}

		public bool IsCommonValueSelected(PageMargins.Attribute attribute)
		{
			if (this.textPart_0 != 0)
			{
				throw new NotSupportedException();
			}
			return this.sectionFormat_0.pageMargins_0.method_0(attribute);
		}

		public bool IsCommonValueSelected(PageSize.Attribute attribute)
		{
			if (this.textPart_0 != 0)
			{
				throw new NotSupportedException();
			}
			return this.sectionFormat_0.pageSize_0.method_0(attribute);
		}

		public bool IsCommonValueSelected(PageBorder.Attribute attribute)
		{
			if (this.textPart_0 != 0)
			{
				throw new NotSupportedException();
			}
			return this.sectionFormat_0.pageBorder_0.method_0(attribute);
		}

		/// <summary>Opens a dialog box to select a file and exchanges the currently selected text with the text from that file.</summary>
		public DialogResult Load()
		{
			return this.Load(StreamType.All);
		}

		/// <summary>Opens a dialog box to select a file in the specified format and exchanges the currently selected text with the text from that file.</summary>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		public DialogResult Load(StreamType streamType)
		{
			return this.Load(streamType, new LoadSettings());
		}

		/// <summary>Exchanges the currently selected text with text in the specified format. The new text is read from the specified file.</summary>
		/// <param name="path">Specifies a file from which the data is loaded.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		public void Load(string path, StreamType streamType)
		{
			this.Load(path, streamType, new LoadSettings());
		}

		/// <summary>Exchanges the currently selected text with text in the specified format. The new text is read from the specified file stream.</summary>
		/// <param name="fileStream">Specifies a file from which the data is loaded.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		public void Load(FileStream fileStream, StreamType streamType)
		{
			this.Load(fileStream, streamType, new LoadSettings());
		}

		/// <summary>Exchanges the currently selected text with text in the specified format. The new text is read from the specified byte array.</summary>
		/// <param name="binaryData">Specifies a byte array from which the data is loaded.</param>
		/// <param name="binaryStreamType">Specifies one of the BinaryStreamType values.</param>
		public void Load(byte[] binaryData, BinaryStreamType binaryStreamType)
		{
			this.Load(binaryData, binaryStreamType, new LoadSettings());
		}

		/// <summary>Exchanges the currently selected text with text in the specified format. The new text is read from the specified string.</summary>
		/// <param name="stringData">Specifies a string from which the data is loaded.</param>
		/// <param name="stringStreamType">Specifies one of the StringStreamType values.</param>
		public void Load(string stringData, StringStreamType stringStreamType)
		{
			this.Load(stringData, stringStreamType, new LoadSettings());
		}

		/// <summary>Opens a dialog box to select a file in the specified format and exchanges the currently selected text with the text from that file using the specified special settings.</summary>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		/// <param name="loadSettings">Specifies a LoadSettings object with additional information and settings for the load operation.</param>
		public DialogResult Load(StreamType streamType, LoadSettings loadSettings)
		{
			loadSettings.TextPart = this.textPart_0;
			if (!loadSettings.method_0(streamType, this.textControlCore_0, Enum104.const_1, null))
			{
				return DialogResult.Cancel;
			}
			return DialogResult.const_2;
		}

		/// <summary>Exchanges the currently selected text with text in the specified format. The new text is read from the specified file and loaded using the given special settings.</summary>
		/// <param name="path">Specifies a file from which the data is loaded.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		/// <param name="loadSettings">Specifies a LoadSettings object with additional information and settings for the load operation.</param>
		public void Load(string path, StreamType streamType, LoadSettings loadSettings)
		{
			loadSettings.TextPart = this.textPart_0;
			loadSettings.method_1(path, streamType, this.textControlCore_0, Enum104.const_1, null);
		}

		/// <summary>Exchanges the currently selected text with text in the specified format. The new text is read from the specified file stream and loaded using the given special settings.</summary>
		/// <param name="fileStream">Specifies a file from which the data is loaded.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		/// <param name="loadSettings">Specifies a LoadSettings object with additional information and settings for the load operation.</param>
		public void Load(FileStream fileStream, StreamType streamType, LoadSettings loadSettings)
		{
			loadSettings.TextPart = this.textPart_0;
			loadSettings.method_2(fileStream, streamType, this.textControlCore_0, Enum104.const_1, null);
		}

		/// <summary>Exchanges the currently selected text with text in the specified format. The new text is read from the specified byte array and loaded using the given special settings.</summary>
		/// <param name="binaryData">Specifies a byte array from which the data is loaded.</param>
		/// <param name="binaryStreamType">Specifies one of the BinaryStreamType values.</param>
		/// <param name="loadSettings">Specifies a LoadSettings object with additional information and settings for the load operation.</param>
		public void Load(byte[] binaryData, BinaryStreamType binaryStreamType, LoadSettings loadSettings)
		{
			loadSettings.TextPart = this.textPart_0;
			loadSettings.method_3(binaryData, binaryStreamType, this.textControlCore_0, Enum104.const_1, null);
		}

		/// <summary>Exchanges the currently selected text with text in the specified format. The new text is read from the specified string and loaded using the given special settings.</summary>
		/// <param name="stringData">Specifies a string from which the data is loaded.</param>
		/// <param name="stringStreamType">Specifies one of the StringStreamType values.</param>
		/// <param name="loadSettings">Specifies a LoadSettings object with additional information and settings for the load operation.</param>
		public void Load(string stringData, StringStreamType stringStreamType, LoadSettings loadSettings)
		{
			loadSettings.TextPart = this.textPart_0;
			loadSettings.method_5(stringData, stringStreamType, this.textControlCore_0, Enum104.const_1, null);
		}

		/// <summary>Opens a file save dialogbox and saves the selected text of a document in a file.</summary>
		public DialogResult Save()
		{
			return this.Save(StreamType.All);
		}

		/// <summary>Opens a file save dialogbox and saves the selected text of a document in a file with the specified format.</summary>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		public DialogResult Save(StreamType streamType)
		{
			return this.Save(streamType, new SaveSettings());
		}

		/// <summary>Saves the selected text of a document in the specified file with the specified format.</summary>
		/// <param name="path">Specifies a file into which the selection is saved.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		public void Save(string path, StreamType streamType)
		{
			this.Save(path, streamType, new SaveSettings());
		}

		/// <summary>Saves the selected text of a document in the specified file stream with the specified format.</summary>
		/// <param name="fileStream">Specifies a file into which the selection is saved.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		public void Save(FileStream fileStream, StreamType streamType)
		{
			this.Save(fileStream, streamType, new SaveSettings());
		}

		/// <summary>Saves the selected text of a document in the specified byte array with the specified format.</summary>
		/// <param name="binaryData">Specifies a byte array into which the selection is saved.</param>
		/// <param name="binaryStreamType">Specifies one of the BinaryStreamType values.</param>
		public void Save(out byte[] binaryData, BinaryStreamType binaryStreamType)
		{
			this.Save(out binaryData, binaryStreamType, new SaveSettings());
		}

		/// <summary>Saves the selected text of a document as a string with the specified format.</summary>
		/// <param name="stringData">Specifies a string into which the selection is saved.</param>
		/// <param name="stringStreamType">Specifies one of the StringStreamType values.</param>
		public void Save(out string stringData, StringStreamType stringStreamType)
		{
			this.Save(out stringData, stringStreamType, new SaveSettings());
		}

		/// <summary>Opens a file save dialogbox and saves the selected text of a document in a file with the specified format and special settings.</summary>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public DialogResult Save(StreamType streamType, SaveSettings saveSettings)
		{
			saveSettings.TextPart = this.textPart_0;
			if (!saveSettings.method_0(streamType, this.textControlCore_0, Enum104.const_1))
			{
				return DialogResult.Cancel;
			}
			return DialogResult.const_2;
		}

		/// <summary>Saves the selected text of a document in the specified file using the specified format and special settings.</summary>
		/// <param name="path">Specifies a file into which the selection is saved.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void Save(string path, StreamType streamType, SaveSettings saveSettings)
		{
			saveSettings.TextPart = this.textPart_0;
			saveSettings.method_1(path, streamType, this.textControlCore_0, Enum104.const_1);
		}

		/// <summary>Saves the selected text of a document in the specified file stream using the specified format and special settings.</summary>
		/// <param name="fileStream">Specifies a file into which the selection is saved.</param>
		/// <param name="streamType">Specifies one of the StreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void Save(FileStream fileStream, StreamType streamType, SaveSettings saveSettings)
		{
			saveSettings.TextPart = this.textPart_0;
			saveSettings.method_2(fileStream, streamType, this.textControlCore_0, Enum104.const_1);
		}

		/// <summary>Saves the selected text of a document in the specified byte array using the specified format and special settings.</summary>
		/// <param name="binaryData">Specifies a byte array into which the selection is saved.</param>
		/// <param name="binaryStreamType">Specifies one of the BinaryStreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void Save(out byte[] binaryData, BinaryStreamType binaryStreamType, SaveSettings saveSettings)
		{
			saveSettings.TextPart = this.textPart_0;
			saveSettings.method_3(out binaryData, binaryStreamType, this.textControlCore_0, Enum104.const_1);
		}

		/// <summary>Saves the selected text of a document as a string using the specified format and special settings.</summary>
		/// <param name="stringData">Specifies a string into which the selection is saved.</param>
		/// <param name="stringStreamType">Specifies one of the StringStreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void Save(out string stringData, StringStreamType stringStreamType, SaveSettings saveSettings)
		{
			saveSettings.TextPart = this.textPart_0;
			saveSettings.method_4(out stringData, stringStreamType, this.textControlCore_0, Enum104.const_1);
		}

		/// <summary>Removes all character based styles of the selected text so that all attributes are reset to the attributes of the paragraph style.</summary>
		public bool RemoveInlineStyles()
		{
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
			{
				this.textControlCore_0.method_29(this.textPart_0, 1660, 2, 0);
				return true;
			}
			return false;
		}

		internal void method_0(TextControlCore textControlCore_1, TextPart textPart_1)
		{
			this.textControlCore_0 = textControlCore_1;
			this.textPart_0 = textPart_1;
			this.paragraphFormat_0.method_1(textControlCore_1, textPart_1);
			this.listFormat_0.method_1(textControlCore_1, textPart_1);
			this.sectionFormat_0.method_1(textControlCore_1, 65535);
		}

		internal void method_1(Selection selection_0)
		{
			selection_0.int_1 = this.int_1;
			selection_0.int_2 = this.int_2;
			selection_0.int_3 = this.int_3;
			selection_0.cultureInfo_0 = this.cultureInfo_0;
			selection_0.string_2 = this.string_2;
			selection_0.int_4 = this.int_4;
			selection_0.bool_0 = this.bool_0;
			selection_0.bool_1 = this.bool_1;
			selection_0.fontUnderlineStyle_0 = this.fontUnderlineStyle_0;
			selection_0.bool_2 = this.bool_2;
			selection_0.color_0 = this.color_0;
			selection_0.color_1 = this.color_1;
			this.paragraphFormat_0.method_3(selection_0.paragraphFormat_0);
			this.listFormat_0.method_3(selection_0.listFormat_0);
			this.sectionFormat_0.method_2(selection_0.sectionFormat_0);
			selection_0.attribute_0 = this.attribute_0;
		}

		private void method_2()
		{
			this.int_1 = 0;
			this.int_2 = 0;
			this.int_3 = 0;
			this.cultureInfo_0 = null;
			this.string_2 = "Arial";
			this.int_4 = 200;
			this.bool_0 = false;
			this.bool_1 = false;
			this.bool_2 = false;
			this.fontUnderlineStyle_0 = FontUnderlineStyle.None;
			this.color_0 = SystemColors.WindowText;
			this.color_1 = SystemColors.Window;
			this.paragraphFormat_0.method_5();
			this.listFormat_0.method_5();
		}

		private void method_3(Attribute attribute_3)
		{
			if (this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated)
			{
				return;
			}
			if (((attribute_3 & Attribute.Start) != 0 && (this.attribute_1 & Attribute.Start) == 0) || ((attribute_3 & Attribute.Length) != 0 && (this.attribute_1 & Attribute.Length) == 0))
			{
				int[] array = new int[2];
				int[] array2 = array;
				if (this.textControlCore_0.method_40(this.textPart_0, 1132, 0, array2) != 0)
				{
					this.int_1 = Math.Min(array2[0], array2[1]);
					this.int_2 = Math.Max(array2[0], array2[1]) - this.int_1;
					this.attribute_1 |= (Attribute)3072;
				}
			}
			if ((attribute_3 & Attribute.Text) != 0 && (this.attribute_1 & Attribute.Text) == 0)
			{
				this.Save(out this.string_1, StringStreamType.PlainText);
				this.attribute_1 |= Attribute.Text;
			}
			if ((attribute_3 & Attribute.Baseline) != 0 && (this.attribute_1 & Attribute.Baseline) == 0)
			{
				int num = this.textControlCore_0.method_29(this.textPart_0, 1137, 0, 0);
				Enum96 @enum = (Enum96)Class429.smethod_5(num);
				int num2 = Class429.smethod_6(num);
				this.attribute_2 &= (Attribute)(-2);
				switch (@enum)
				{
				case Enum96.const_3:
					this.int_3 = -num2;
					break;
				case Enum96.const_1:
					this.int_3 = 0;
					break;
				default:
					this.int_3 = 0;
					this.attribute_2 |= Attribute.Baseline;
					break;
				case Enum96.const_2:
					this.int_3 = num2;
					break;
				}
				this.attribute_1 |= Attribute.Baseline;
			}
			if ((attribute_3 & Attribute.Culture) != 0 && (this.attribute_1 & Attribute.Culture) == 0)
			{
				int num3 = this.textControlCore_0.method_29(this.textPart_0, 1969, 0, 0);
				this.attribute_2 &= (Attribute)(-16385);
				if (num3 == 65535)
				{
					this.attribute_2 |= Attribute.Culture;
					this.cultureInfo_0 = null;
				}
				else
				{
					this.cultureInfo_0 = ((num3 == 0) ? null : new CultureInfo(num3));
				}
				this.attribute_1 |= Attribute.Culture;
			}
			if (((attribute_3 & Attribute.ForeColor) != 0 && (this.attribute_1 & Attribute.ForeColor) == 0) || ((attribute_3 & Attribute.TextBackColor) != 0 && (this.attribute_1 & Attribute.TextBackColor) == 0))
			{
				int[] array3 = new int[2];
				int[] array4 = array3;
				int num4 = this.textControlCore_0.method_40(this.textPart_0, 1150, 1, array4);
				this.attribute_2 &= (Attribute)(-769);
				switch (Class429.smethod_5(num4))
				{
				case 0:
					this.color_0 = SystemColors.WindowText;
					this.attribute_2 |= Attribute.ForeColor;
					break;
				case 1:
					this.color_0 = SystemColors.WindowText;
					break;
				case 2:
					this.color_0 = Class429.smethod_2(array4[0]);
					break;
				}
				switch (Class429.smethod_6(num4))
				{
				case 4:
					this.color_1 = SystemColors.Window;
					break;
				case 0:
					this.color_1 = SystemColors.Window;
					this.attribute_2 |= Attribute.TextBackColor;
					break;
				case 16:
					this.color_1 = Color.Transparent;
					break;
				case 8:
					this.color_1 = Class429.smethod_2(array4[1]);
					break;
				}
				this.attribute_1 |= (Attribute)768;
			}
			if (((attribute_3 & Attribute.FontName) != 0 && (this.attribute_1 & Attribute.FontName) == 0) || ((attribute_3 & Attribute.FontSize) != 0 && (this.attribute_1 & Attribute.FontSize) == 0))
			{
				IntPtr intPtr = Marshal.AllocHGlobal(64);
				this.int_4 = this.textControlCore_0.method_38(this.textPart_0, 1632, 32768, intPtr);
				string text = Marshal.PtrToStringUni(intPtr, 32);
				Marshal.FreeHGlobal(intPtr);
				this.attribute_2 &= (Attribute)(-25);
				if (this.int_4 == 0)
				{
					this.int_4 = 200;
					this.attribute_2 |= Attribute.FontSize;
				}
				if (text[0] == '\0')
				{
					this.string_2 = string.Empty;
					this.attribute_2 |= Attribute.FontName;
				}
				else
				{
					this.string_2 = KernelHelper.GetString(text);
				}
				this.attribute_1 |= (Attribute)24;
			}
			if (((attribute_3 & Attribute.Bold) != 0 && (this.attribute_1 & Attribute.Bold) == 0) || ((attribute_3 & Attribute.Italic) != 0 && (this.attribute_1 & Attribute.Italic) == 0) || ((attribute_3 & Attribute.Strikeout) != 0 && (this.attribute_1 & Attribute.Strikeout) == 0) || ((attribute_3 & Attribute.Underline) != 0 && (this.attribute_1 & Attribute.Underline) == 0))
			{
				Enum96 enum2 = (Enum96)this.textControlCore_0.method_29(this.textPart_0, 1126, 0, 0);
				this.attribute_2 &= (Attribute)(-103);
				this.bool_0 = (enum2 & Enum96.const_2) != 0;
				if ((enum2 & Enum96.const_10) != 0)
				{
					this.attribute_2 |= Attribute.Bold;
				}
				this.bool_1 = (enum2 & Enum96.const_3) != 0;
				if ((enum2 & Enum96.const_11) != 0)
				{
					this.attribute_2 |= Attribute.Italic;
				}
				this.bool_2 = (enum2 & Enum96.const_5) != 0;
				if ((enum2 & Enum96.const_13) != 0)
				{
					this.attribute_2 |= Attribute.Strikeout;
				}
				this.fontUnderlineStyle_0 = FontUnderlineStyle.None;
				if ((enum2 & Enum96.const_12) != 0 || (enum2 & Enum96.const_14) != 0 || (enum2 & Enum96.const_15) != 0)
				{
					this.attribute_2 |= Attribute.Underline;
				}
				if ((enum2 & Enum96.const_4) != 0)
				{
					this.fontUnderlineStyle_0 = (((enum2 & Enum96.const_7) != 0) ? FontUnderlineStyle.SingleWordsOnly : FontUnderlineStyle.Single);
				}
				else if ((enum2 & Enum96.const_6) != 0)
				{
					this.fontUnderlineStyle_0 = (((enum2 & Enum96.const_7) != 0) ? FontUnderlineStyle.DoubledWordsOnly : FontUnderlineStyle.Doubled);
				}
				this.attribute_1 |= (Attribute)102;
			}
			if ((attribute_3 & Attribute.FormattingStyle) != 0 && (this.attribute_1 & Attribute.FormattingStyle) == 0)
			{
				IntPtr intPtr2 = Marshal.AllocHGlobal(510);
				this.textControlCore_0.method_38(this.textPart_0, 1659, 255, intPtr2);
				this.string_3 = Marshal.PtrToStringUni(intPtr2);
				Marshal.FreeHGlobal(intPtr2);
				this.attribute_2 &= (Attribute)(-8193);
				if (this.string_3.Length == 0)
				{
					this.attribute_2 |= Attribute.FormattingStyle;
				}
				this.attribute_1 |= Attribute.FormattingStyle;
			}
		}

		internal void method_4()
		{
			int int32_ = this.Int32_0;
			if (this.textControlCore_0 == null || !this.textControlCore_0.isHandleCreated || int32_ == 0)
			{
				return;
			}
			if (int32_ > 1)
			{
				this.textControlCore_0.method_10(bool_1: true);
				this.textControlCore_0.method_19(this.textPart_0, null);
			}
			this.attribute_2 &= ~this.attribute_0;
			if ((this.attribute_0 & Attribute.Start) != 0 || (this.attribute_0 & Attribute.Length) != 0)
			{
				int[] array = new int[2]
				{
					this.int_1 + this.int_2,
					this.int_1
				};
				this.textControlCore_0.method_40(this.textPart_0, 1158, 1, array);
			}
			if ((this.attribute_0 & Attribute.Baseline) != 0)
			{
				this.textControlCore_0.method_29(this.textPart_0, 1160, (this.int_3 == 0) ? 2 : ((this.int_3 < 0) ? 8 : 4), Math.Abs(this.int_3));
			}
			if ((this.attribute_0 & Attribute.Culture) != 0)
			{
				int num = ((this.cultureInfo_0 != null) ? Class429.smethod_5(this.cultureInfo_0.LCID) : 0);
				this.textControlCore_0.method_29(this.textPart_0, 1970, num, 0);
			}
			if ((this.attribute_0 & Attribute.ForeColor) != 0 || (this.attribute_0 & Attribute.TextBackColor) != 0)
			{
				int[] array2 = new int[2]
				{
					Class429.smethod_0(this.color_0),
					Class429.smethod_0(this.color_1)
				};
				int num2 = 0;
				if ((this.attribute_0 & Attribute.ForeColor) != 0)
				{
					num2 |= ((this.color_0 == SystemColors.WindowText) ? 1 : 2);
				}
				if ((this.attribute_0 & Attribute.TextBackColor) != 0)
				{
					num2 |= ((Class429.smethod_0(this.color_1) == this.textControlCore_0.GetTextControl().GetBackColor() || this.color_1 == Color.Transparent) ? 16 : ((this.color_1 == SystemColors.Window) ? 4 : 8));
				}
				this.textControlCore_0.method_40(this.textPart_0, 1168, num2, array2);
			}
			if ((this.attribute_0 & Attribute.FontName) != 0 || (this.attribute_0 & Attribute.FontSize) != 0)
			{
				this.textControlCore_0.method_37(this.textPart_0, 1644, ((this.attribute_0 & Attribute.FontSize) != 0) ? (this.int_4 | 0x8000) : 0, ((this.attribute_0 & Attribute.FontName) != 0) ? this.string_2 : null);
			}
			if ((this.attribute_0 & Attribute.Bold) != 0 || (this.attribute_0 & Attribute.Italic) != 0 || (this.attribute_0 & Attribute.Strikeout) != 0 || (this.attribute_0 & Attribute.Underline) != 0)
			{
				int num3 = 0;
				if ((this.attribute_0 & Attribute.Bold) != 0)
				{
					num3 |= (this.bool_0 ? 4 : 1024);
				}
				if ((this.attribute_0 & Attribute.Italic) != 0)
				{
					num3 |= (this.bool_1 ? 8 : 2048);
				}
				if ((this.attribute_0 & Attribute.Strikeout) != 0)
				{
					num3 |= (this.bool_2 ? 32 : 8192);
				}
				if ((this.attribute_0 & Attribute.Underline) != 0)
				{
					num3 |= (int)this.fontUnderlineStyle_0;
				}
				this.textControlCore_0.method_29(this.textPart_0, 1154, num3, 0);
			}
			this.paragraphFormat_0.method_11();
			this.listFormat_0.method_12();
			if (this.textPart_0 == TextPart.Auto)
			{
				this.sectionFormat_0.method_4();
			}
			if ((this.attribute_0 & Attribute.Text) != 0)
			{
				this.Load(this.string_1, StringStreamType.PlainText);
			}
			if ((this.attribute_0 & Attribute.FormattingStyle) != 0)
			{
				this.textControlCore_0.method_37(this.textPart_0, 1660, 0, this.string_3);
			}
			if (int32_ > 1)
			{
				this.textControlCore_0.method_20(this.textPart_0);
				this.textControlCore_0.method_10(bool_1: false);
			}
			this.attribute_0 = (Attribute)0;
		}

		internal Attribute method_5(Attribute attribute_3, Attribute attribute_4)
		{
			Attribute attribute = (Attribute)0;
			Attribute attribute2 = this.attribute_2;
			this.attribute_1 &= ~attribute_3;
			if ((attribute_4 & Attribute.FontName) != 0 || (attribute_4 & Attribute.FontSize) != 0)
			{
				string text = this.string_2;
				int num = this.int_4;
				this.method_3((Attribute)24);
				if (text != this.string_2)
				{
					attribute |= Attribute.FontName;
				}
				if (num != this.int_4 || (attribute2 & Attribute.FontSize) != (this.attribute_2 & Attribute.FontSize))
				{
					attribute |= Attribute.FontSize;
				}
			}
			if ((attribute_4 & Attribute.Bold) != 0 || (attribute_4 & Attribute.Italic) != 0 || (attribute_4 & Attribute.Strikeout) != 0 || (attribute_4 & Attribute.Underline) != 0)
			{
				bool flag = this.bool_0;
				bool flag2 = this.bool_1;
				bool flag3 = this.bool_2;
				FontUnderlineStyle fontUnderlineStyle = this.fontUnderlineStyle_0;
				this.method_3((Attribute)102);
				if (flag != this.bool_0 || (attribute2 & Attribute.Bold) != (this.attribute_2 & Attribute.Bold))
				{
					attribute |= Attribute.Bold;
				}
				if (flag2 != this.bool_1 || (attribute2 & Attribute.Italic) != (this.attribute_2 & Attribute.Italic))
				{
					attribute |= Attribute.Italic;
				}
				if (flag3 != this.bool_2 || (attribute2 & Attribute.Strikeout) != (this.attribute_2 & Attribute.Strikeout))
				{
					attribute |= Attribute.Strikeout;
				}
				if (fontUnderlineStyle != this.fontUnderlineStyle_0 || (attribute2 & Attribute.Underline) != (this.attribute_2 & Attribute.Underline))
				{
					attribute |= Attribute.Underline;
				}
			}
			if ((attribute_4 & Attribute.ForeColor) != 0 || (attribute_4 & Attribute.TextBackColor) != 0)
			{
				Color color = this.color_0;
				Color color2 = this.color_1;
				this.method_3((Attribute)768);
				if (color != this.color_0 || (attribute2 & Attribute.ForeColor) != (this.attribute_2 & Attribute.ForeColor))
				{
					attribute |= Attribute.ForeColor;
				}
				if (color2 != this.color_1 || (attribute2 & Attribute.TextBackColor) != (this.attribute_2 & Attribute.TextBackColor))
				{
					attribute |= Attribute.TextBackColor;
				}
			}
			if ((attribute_4 & Attribute.Baseline) != 0)
			{
				int num2 = this.int_3;
				this.method_3(Attribute.Baseline);
				if (num2 != this.int_3 || (attribute2 & Attribute.Baseline) != (this.attribute_2 & Attribute.Baseline))
				{
					attribute |= Attribute.Baseline;
				}
			}
			if ((attribute_4 & Attribute.FormattingStyle) != 0)
			{
				string text2 = this.string_3;
				this.method_3(Attribute.FormattingStyle);
				if (text2 != this.string_3 || (attribute2 & Attribute.FormattingStyle) != (this.attribute_2 & Attribute.FormattingStyle))
				{
					attribute |= Attribute.FormattingStyle;
				}
			}
			return attribute;
		}

		internal void method_6()
		{
			this.attribute_1 = (Attribute)0;
			this.paragraphFormat_0.method_13();
			this.listFormat_0.method_14();
		}
	}
}
