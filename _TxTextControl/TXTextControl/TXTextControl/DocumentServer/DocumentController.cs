using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using DocumentServer.Properties;
using DocumentServer.Fields;
using ns1;
using Font = DocumentServer.Fields.Font;

namespace TXTextControl.DocumentServer
{
	/// <summary>The DocumentController class is a .NET component that can be used to perform the necessary document handling on the server, when using a control such as the DocumentServer.Web.DocumentViewer.</summary>
	[ToolboxBitmap(typeof(DocumentController))]
	public class DocumentController : Component
	{
		/// <summary>An instance of the FieldAdapterCollection class contains adapters for all application fields of the page it belongs to.</summary>
		public sealed class FieldAdapterCollection : IEnumerable, ICollection
		{
			private ICollection icollection_0;

			private ServerTextControl serverTextControl_0;

			public FieldAdapter this[int index]
			{
				get
				{
					if (index >= 0 && index <= this.icollection_0.Count - 1)
					{
						ApplicationField[] array = new ApplicationField[this.icollection_0.Count];
						this.icollection_0.CopyTo(array, 0);
						ApplicationField applicationField = array[index];
						if (applicationField.Int32_0 == 0)
						{
							applicationField.Int32_0 = applicationField.GetHashCode();
						}
						FieldAdapter fieldAdapter = null;
						if (applicationField.TypeName != null)
						{
							switch (applicationField.TypeName)
							{
							case "MERGEFIELD":
								fieldAdapter = new MergeField(applicationField);
								break;
							case "FORMTEXT":
								fieldAdapter = new FormText(applicationField);
								break;
							case "FORMDROPDOWN":
								fieldAdapter = new FormDropDown(applicationField);
								break;
							case "FORMCHECKBOX":
								fieldAdapter = new FormCheckBox(applicationField);
								break;
							}
						}
						if (fieldAdapter is FormFieldAdapter)
						{
							((FormFieldAdapter)fieldAdapter).Font = this.method_4(fieldAdapter);
							((FormFieldAdapter)fieldAdapter).Bounds = this.method_0(fieldAdapter);
						}
						return fieldAdapter;
					}
					throw new IndexOutOfRangeException();
				}
			}

			/// <summary>Gets the number of elements contained in the collection.</summary>
			public int Count => this.icollection_0.Count;

			public bool IsSynchronized => this.icollection_0.IsSynchronized;

			public object SyncRoot => this.icollection_0.SyncRoot;

			public FieldAdapterCollection(ICollection appFields, ServerTextControl txServer)
			{
				if (appFields == null || txServer == null)
				{
					throw new ArgumentNullException();
				}
				this.serverTextControl_0 = txServer;
				this.icollection_0 = appFields;
			}

			/// <summary>Copies the elements of the collection to an array, starting at the specified index.</summary>
			/// <param name="array">Specifies the array to copy to.</param>
			/// <param name="index">Specifies the index of the destination array at which to begin copying.</param>
			public void CopyTo(Array array, int index)
			{
				this.icollection_0.CopyTo(array, index);
			}

			/// <summary>Returns an enumerator that can be used to iterate over the collection's items.</summary>
			public IEnumerator GetEnumerator()
			{
				for (int i = 0; i < this.Count; i++)
				{
					yield return this[i];
				}
			}

			public int IndexOf(FieldAdapter fieldAdapter)
			{
				int result = -1;
				if (fieldAdapter != null)
				{
					for (int i = 0; i < this.icollection_0.Count; i++)
					{
						if (this[i].Int32_0 == fieldAdapter.Int32_0)
						{
							result = i;
							break;
						}
					}
				}
				return result;
			}

			private Rectangle method_0(FieldAdapter fieldAdapter_0)
			{
				int num = this.method_2();
				int num2 = this.method_3();
				this.serverTextControl_0.Select(fieldAdapter_0.Start - 1, 0);
				Rectangle bounds = this.serverTextControl_0.GetPages()[this.serverTextControl_0.InputPosition.Page].Bounds;
				int num3 = fieldAdapter_0.ApplicationField.Bounds.Left + num - bounds.X;
				int y = fieldAdapter_0.ApplicationField.Bounds.Top + num2 - bounds.Y;
				int width = fieldAdapter_0.ApplicationField.FormattingBounds.Right - num3;
				int height = this.serverTextControl_0.Lines.GetItem(this.serverTextControl_0.InputPosition.TextPosition).TextBounds.Height;
				return new Rectangle(num3, y, width, height);
			}

			private TextCharCollection method_1(FieldAdapter fieldAdapter_0)
			{
				this.serverTextControl_0.Selection.Length = 0;
				this.serverTextControl_0.Selection.Start = fieldAdapter_0.Start - 1;
				if (this.serverTextControl_0.TextFrames.GetItem() != null)
				{
					return this.serverTextControl_0.TextFrames.GetItem().TextChars;
				}
				return this.serverTextControl_0.TextChars;
			}

			private int method_2()
			{
				if (this.serverTextControl_0.TextFrames.GetItem() != null)
				{
					return this.serverTextControl_0.TextFrames.GetItem().Location.X;
				}
				return 0;
			}

			private int method_3()
			{
				if (this.serverTextControl_0.TextFrames.GetItem() != null)
				{
					return this.serverTextControl_0.TextFrames.GetItem().Location.Y;
				}
				return 0;
			}

			private Font method_4(FieldAdapter fieldAdapter_0)
			{
				this.serverTextControl_0.Select(fieldAdapter_0.Start - 1, 0);
				string fontName = this.serverTextControl_0.Selection.FontName;
				string family = this.method_5(fontName);
				int fontSize = this.serverTextControl_0.Selection.FontSize;
				bool bold = this.serverTextControl_0.Selection.Bold;
				bool italic = this.serverTextControl_0.Selection.Italic;
				bool strikeout = this.serverTextControl_0.Selection.Strikeout;
				bool underline = this.serverTextControl_0.Selection.Underline != FontUnderlineStyle.None;
				return new Font(fontName, family, fontSize, bold, italic, strikeout, underline);
			}

			private string method_5(string string_0)
			{
				string result = "";
				FontFamily[] families = FontFamily.Families;
				foreach (FontFamily fontFamily in families)
				{
					if (string_0.StartsWith(fontFamily.Name, StringComparison.CurrentCultureIgnoreCase))
					{
						result = fontFamily.Name;
						break;
					}
				}
				return result;
			}
		}

		protected class MergeBlock
		{
			[CompilerGenerated]
			private string string_0;

			[CompilerGenerated]
			private int int_0;

			[CompilerGenerated]
			private int int_1;

			public string Name
			{
				[CompilerGenerated]
				get
				{
					return this.string_0;
				}
				[CompilerGenerated]
				set
				{
					this.string_0 = value;
				}
			}

			public int Start
			{
				[CompilerGenerated]
				get
				{
					return this.int_0;
				}
				[CompilerGenerated]
				private set
				{
					this.int_0 = value;
				}
			}

			public int End
			{
				[CompilerGenerated]
				get
				{
					return this.int_1;
				}
				[CompilerGenerated]
				private set
				{
					this.int_1 = value;
				}
			}

			public MergeBlock(string name, int start, int end)
			{
				this.Start = start;
				this.End = end;
				this.Name = name;
			}

			public bool Contains(ApplicationField appField)
			{
				int start = appField.Start;
				if (this.Start <= start)
				{
					return start <= this.End;
				}
				return false;
			}
		}

		protected ServerTextControl m_txServer;

		protected bool m_bDisposed;

		protected bool m_bDisposeTextComponent;

		protected byte[] m_documentData;

		protected LoadSettings m_ls;

		protected List<MergeBlock> m_lstMergeBlocks;

		protected int m_nCharCodeChecked = -1;

		protected int m_nCharCodeUnchecked = -1;

		protected System.Drawing.Font m_fontCheckBox;

		protected const int CharCodeCheckedDefault = 254;

		protected const int CharCodeUncheckedDefault = 168;

		protected const string DefaultCheckBoxFontName = "Wingdings";

		protected const string DefaultCheckBoxFontSize = "12";

		[CompilerGenerated]
		private static float float_0;

		[CompilerGenerated]
		private static float float_1;

		private IContainer icontainer_0;

		/// <summary>Gets or sets the object of type ServerTextControl that is associated with the DocumentController component.</summary>
		[Attribute1("PROP_DOCCNTRL_TEXTCOMPONENT")]
		[DefaultValue(null)]
		[TypeConverter(typeof(Class91))]
		public Component TextComponent
		{
			get
			{
				return this.m_txServer;
			}
			set
			{
				if (value != null && value is ServerTextControl)
				{
					this.m_txServer = value as ServerTextControl;
					if (!this.m_txServer.IsCreated)
					{
						this.m_txServer.Create();
						this.m_bDisposeTextComponent = true;
					}
					else
					{
						this.m_bDisposeTextComponent = false;
					}
				}
				else
				{
					if (value != null)
					{
						throw new ArgumentException(Resources.EXC_DOCCNTRL_INVALID_TEXT_COMPONENT);
					}
					this.m_txServer = null;
					this.m_bDisposeTextComponent = false;
				}
			}
		}

		/// <summary>Gets or sets the horizontal DPI value used for display-related calculations.</summary>
		public static float DpiX
		{
			[CompilerGenerated]
			get
			{
				return DocumentController.float_0;
			}
			[CompilerGenerated]
			set
			{
				DocumentController.float_0 = value;
			}
		}

		/// <summary>Gets or sets the vertical DPI value used for display-related calculations.</summary>
		public static float DpiY
		{
			[CompilerGenerated]
			get
			{
				return DocumentController.float_1;
			}
			[CompilerGenerated]
			set
			{
				DocumentController.float_1 = value;
			}
		}

		/// <summary>Gets a collection of all pages contained in the currently loaded document.</summary>
		[Browsable(false)]
		public PageCollection Pages
		{
			get
			{
				if (this.TextComponent == null)
				{
					throw new Exception(Resources.EXC_DOCCNTRL_INVALID_TEXT_COMPONENT);
				}
				return ((ServerTextControl)this.TextComponent).GetPages();
			}
		}

		/// <summary>Gets or sets the font used for rendering check boxes.</summary>
		[Category("Appearance")]
		[DefaultValue(typeof(System.Drawing.Font), "Wingdings, 12pt")]
		public System.Drawing.Font CheckBoxFont
		{
			get
			{
				if (this.m_fontCheckBox == null)
				{
					return new System.Drawing.Font("Wingdings", int.Parse("12"));
				}
				return this.m_fontCheckBox;
			}
			set
			{
				this.m_fontCheckBox = value;
			}
		}

		/// <summary>Gets or sets the character's code that is used to render checked check boxes.</summary>
		[Category("Appearance")]
		[DefaultValue(254)]
		public int CharCodeChecked
		{
			get
			{
				if (this.m_nCharCodeChecked >= 0)
				{
					return this.m_nCharCodeChecked;
				}
				return 254;
			}
			set
			{
				this.m_nCharCodeChecked = value;
			}
		}

		/// <summary>Gets or sets the character's code that is used to render unchecked check boxes.</summary>
		[Category("Appearance")]
		[DefaultValue(168)]
		public int CharCodeUnchecked
		{
			get
			{
				if (this.m_nCharCodeUnchecked >= 0)
				{
					return this.m_nCharCodeUnchecked;
				}
				return 168;
			}
			set
			{
				this.m_nCharCodeUnchecked = value;
			}
		}

		static DocumentController()
		{
			DocumentController.DpiY = 96f;
			DocumentController.DpiX = 96f;
		}

		/// <summary>Initializes a new instance of the DocumentController class.</summary>
		public DocumentController()
			: this(null)
		{
		}

		public DocumentController(IContainer container)
		{
			this.method_2();
			this.m_ls = new LoadSettings
			{
				ApplicationFieldFormat = ApplicationFieldFormat.MSWordTXFormFields,
				LoadSubTextParts = true
			};
			this.m_lstMergeBlocks = new List<MergeBlock>();
			if (container != null)
			{
				container?.Add(this);
			}
		}

		~DocumentController()
		{
			this.Dispose(disposing: false);
		}

		/// <summary>Frees all resources used by the DocumentController instance.</summary>
		public new virtual void Dispose()
		{
			this.Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected override void Dispose(bool disposing)
		{
			if (this.m_bDisposed)
			{
				return;
			}
			if (disposing)
			{
				this.m_documentData = null;
				this.m_ls = null;
				this.m_lstMergeBlocks = null;
				if (this.icontainer_0 != null)
				{
					this.icontainer_0.Dispose();
				}
				if (this.m_bDisposeTextComponent && this.m_txServer != null)
				{
					this.m_txServer.Dispose();
				}
			}
			base.Dispose(disposing);
			this.m_bDisposed = true;
		}

		public void Load(string filename, FileFormat documentFormat)
		{
			if (this.TextComponent == null)
			{
				throw new Exception(Resources.EXC_DOCCNTRL_INVALID_TEXT_COMPONENT);
			}
			StreamType streamType = (StreamType)0;
			switch (documentFormat)
			{
			case FileFormat.MSWord:
				streamType = StreamType.MSWord;
				break;
			case FileFormat.RichTextFormat:
				streamType = StreamType.RichTextFormat;
				break;
			case FileFormat.WordprocessingML:
				streamType = StreamType.WordprocessingML;
				break;
			case FileFormat.InternalUnicodeFormat:
				streamType = StreamType.InternalUnicodeFormat;
				break;
			}
			ServerTextControl obj = (ServerTextControl)this.TextComponent;
			obj.Load(filename, streamType, this.m_ls);
			obj.Save(out this.m_documentData, BinaryStreamType.InternalUnicodeFormat);
		}

		public void LoadFromMemory(object template, FileFormat documentFormat)
		{
			if (this.TextComponent == null)
			{
				throw new Exception(Resources.EXC_DOCCNTRL_INVALID_TEXT_COMPONENT);
			}
			object obj = null;
			switch (documentFormat)
			{
			case FileFormat.MSWord:
				obj = BinaryStreamType.MSWord;
				break;
			case FileFormat.RichTextFormat:
				obj = StringStreamType.RichTextFormat;
				break;
			case FileFormat.WordprocessingML:
				obj = BinaryStreamType.WordprocessingML;
				break;
			case FileFormat.InternalUnicodeFormat:
				obj = BinaryStreamType.InternalUnicodeFormat;
				break;
			}
			ServerTextControl serverTextControl = (ServerTextControl)this.TextComponent;
			if ((BinaryStreamType)obj != BinaryStreamType.InternalUnicodeFormat && (BinaryStreamType)obj != BinaryStreamType.MSWord && (BinaryStreamType)obj != BinaryStreamType.WordprocessingML)
			{
				serverTextControl.Load((string)template, (StringStreamType)obj, this.m_ls);
			}
			else
			{
				serverTextControl.Load((byte[])template, (BinaryStreamType)obj, this.m_ls);
			}
			serverTextControl.Save(out this.m_documentData, BinaryStreamType.InternalUnicodeFormat);
		}

		/// <summary>Saves the document that is currently loaded in the DocumentController to a file.</summary>
		/// <param name="filename">Specifies a file into which the data is saved.</param>
		/// <param name="fileFormat">Specifies one of the StreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void Save(string filename, StreamType fileFormat, SaveSettings saveSettings)
		{
			if (this.TextComponent == null)
			{
				throw new Exception(Resources.EXC_DOCCNTRL_INVALID_TEXT_COMPONENT);
			}
			if (this.m_documentData == null)
			{
				throw new Exception(Resources.EXC_NO_TEMPLATE);
			}
			((ServerTextControl)this.TextComponent).Save(filename, fileFormat, saveSettings);
		}

		/// <summary>Saves the document that is currently loaded in the DocumentController to a byte array.</summary>
		/// <param name="data">Specifies a byte array or a string into which the data is saved.</param>
		/// <param name="fileFormat">Specifies one of the BinaryStreamType or the StringStreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void SaveToMemory(out byte[] data, BinaryStreamType fileFormat, SaveSettings saveSettings)
		{
			if (this.TextComponent == null)
			{
				throw new Exception(Resources.EXC_DOCCNTRL_INVALID_TEXT_COMPONENT);
			}
			if (this.m_documentData == null)
			{
				throw new Exception(Resources.EXC_NO_TEMPLATE);
			}
			((ServerTextControl)this.TextComponent).Save(out data, fileFormat, saveSettings);
		}

		/// <summary>Saves the document that is currently loaded in the DocumentController to a string.</summary>
		/// <param name="data">Specifies a byte array or a string into which the data is saved.</param>
		/// <param name="fileFormat">Specifies one of the BinaryStreamType or the StringStreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void SaveToMemory(out string data, StringStreamType fileFormat, SaveSettings saveSettings)
		{
			if (this.TextComponent == null)
			{
				throw new Exception(Resources.EXC_DOCCNTRL_INVALID_TEXT_COMPONENT);
			}
			if (this.m_documentData == null)
			{
				throw new Exception(Resources.EXC_NO_TEMPLATE);
			}
			((ServerTextControl)this.TextComponent).Save(out data, fileFormat, saveSettings);
		}

		/// <summary>Gets all adapters for all application fields.</summary>
		public FieldAdapterCollection GetFieldAdapters()
		{
			if (this.m_txServer == null)
			{
				throw new Exception(Resources.EXC_DOCCNTRL_INVALID_TEXT_COMPONENT);
			}
			return new FieldAdapterCollection(this.m_txServer.ApplicationFields, this.m_txServer);
		}

		/// <summary>Gets a collection of adapters for all application fields in the specified scope. Returns a collection of adapters for the fields located on the given page.</summary>
		/// <param name="page">Specifies the page for whose fields a collection of adapters is to be returned.</param>
		public FieldAdapterCollection GetFieldAdapters(Page page)
		{
			if (this.m_txServer == null)
			{
				throw new Exception(Resources.EXC_DOCCNTRL_INVALID_TEXT_COMPONENT);
			}
			List<ApplicationField> list = new List<ApplicationField>();
			if (page != null)
			{
				int start = page.Start;
				int num = start + page.Length - 1;
				foreach (ApplicationField applicationField in this.m_txServer.ApplicationFields)
				{
					if (applicationField.Start >= start && applicationField.Start <= num)
					{
						list.Add(applicationField);
					}
				}
			}
			return new FieldAdapterCollection(list, this.m_txServer);
		}

		/// <summary>Gets a list of the names of all the application fields which are contained inside the specified merge block.</summary>
		/// <param name="block">Specifies the name of the merge block whose field names are to be returned.</param>
		public string[] GetBlockFieldNames(string block)
		{
			List<string> list = new List<string>();
			if (this.TextComponent == null)
			{
				return list.ToArray();
			}
			ServerTextControl serverTextControl = (ServerTextControl)this.TextComponent;
			if (serverTextControl.ApplicationFields != null)
			{
				foreach (ApplicationField applicationField in serverTextControl.ApplicationFields)
				{
					if (applicationField.Parameters != null && this.method_0(applicationField))
					{
						string item = applicationField.Parameters[0];
						if (!list.Contains(item))
						{
							list.Add(item);
						}
					}
				}
			}
			return list.ToArray();
		}

		private bool method_0(ApplicationField applicationField_0)
		{
			return this.m_lstMergeBlocks.Find((MergeBlock block) => block.Contains(applicationField_0)) != null;
		}

		/// <summary>Gets a list of the names of all the merge blocks contained in the document.</summary>
		public string[] GetBlockNames()
		{
			List<string> lstBlockNames = new List<string>();
			this.m_lstMergeBlocks.ForEach(delegate(MergeBlock block)
			{
				lstBlockNames.Add(block.Name);
			});
			return lstBlockNames.ToArray();
		}

		/// <summary>Get field names.</summary>
		public string[] GetFieldNames()
		{
			List<string> list = new List<string>();
			if (this.TextComponent == null)
			{
				return list.ToArray();
			}
			ServerTextControl serverTextControl = (ServerTextControl)this.TextComponent;
			if (serverTextControl.HeadersAndFooters != null)
			{
				foreach (HeaderFooter headersAndFooter in serverTextControl.HeadersAndFooters)
				{
					if (headersAndFooter.ApplicationFields != null)
					{
						foreach (ApplicationField applicationField3 in headersAndFooter.ApplicationFields)
						{
							if (applicationField3.Parameters != null)
							{
								string item = applicationField3.Parameters[0];
								if (!list.Contains(item))
								{
									list.Add(item);
								}
							}
						}
					}
					if (headersAndFooter.TextFrames == null)
					{
						continue;
					}
					foreach (TextFrame textFrame in headersAndFooter.TextFrames)
					{
						this.method_1(textFrame, list);
					}
				}
			}
			if (serverTextControl.ApplicationFields != null)
			{
				foreach (ApplicationField applicationField4 in serverTextControl.ApplicationFields)
				{
					if (applicationField4.Parameters != null)
					{
						string item2 = applicationField4.Parameters[0];
						if (!list.Contains(item2))
						{
							list.Add(item2);
						}
					}
				}
			}
			if (serverTextControl.TextFrames != null)
			{
				foreach (TextFrame textFrame2 in serverTextControl.TextFrames)
				{
					this.method_1(textFrame2, list);
				}
			}
			return list.ToArray();
		}

		private void method_1(TextFrame textFrame_0, List<string> list_0)
		{
			if (textFrame_0.ApplicationFields == null)
			{
				return;
			}
			foreach (ApplicationField applicationField in textFrame_0.ApplicationFields)
			{
				if (applicationField.Parameters != null)
				{
					string item = applicationField.Parameters[0];
					if (!list_0.Contains(item))
					{
						list_0.Add(item);
					}
				}
			}
		}

		public void MergeField(FormFieldAdapter fieldAdapter, string value)
		{
			if (fieldAdapter == null || value == null)
			{
				return;
			}
			if (fieldAdapter is FormCheckBox)
			{
				if (this.m_txServer == null)
				{
					throw new Exception(Resources.EXC_DOCCNTRL_INVALID_TEXT_COMPONENT);
				}
				FormCheckBox formCheckBox = fieldAdapter as FormCheckBox;
				formCheckBox.Checked = value == true.ToString();
				formCheckBox.Text = (formCheckBox.Checked ? ((char)this.CharCodeChecked).ToString() : ((char)this.CharCodeUnchecked).ToString());
				this.m_txServer.Select(formCheckBox.Start - 1, formCheckBox.Length);
				this.m_txServer.Selection.FontName = this.CheckBoxFont.Name;
			}
			else
			{
				fieldAdapter.Text = value;
			}
		}

		/// <summary>Converts a value in twips to a value in pixels according to a specified resolution. This is a helper method that is useful when implementing pixel-based document viewers.</summary>
		/// <param name="twips">The value in twips to be converted.</param>
		/// <param name="dpi">The resolution the conversion is based on.</param>
		public static int Twips2Pixels(int twips, float dpi)
		{
			return (int)Math.Round(dpi * (float)twips / 1440f);
		}

		private void method_2()
		{
			this.icontainer_0 = new Container();
		}
	}
}
