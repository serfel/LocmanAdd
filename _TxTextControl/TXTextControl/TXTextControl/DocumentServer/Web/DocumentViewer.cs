using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using ns2;
using DocumentServer.Fields;
using DocumentServer.Properties;
using TXTextControl.DocumentServer;
using TXTextControl;

namespace DocumentServer.Web
{
	/// <summary>The DocumentViewer class is a .NET component that can be used to display documents in the web browser in ASP.NET projects.</summary>
	[ToolboxBitmap(typeof(DocumentViewer))]
	public class DocumentViewer : CompositeControl
	{
		public enum ZoomLevel
		{
			ControlWidth,
			HalfSize,
			FullSize,
			WholePage
		}

		/// <summary>The SaveDocumentEventArgs class provides data for the DocumentViewer.SaveDocument event.</summary>
		public class SaveDocumentEventArgs : EventArgs
		{
			private readonly byte[] byte_0;

			private readonly FileFormat fileFormat_0;

			/// <summary>Gets a snapshot of the currently loaded document for further processing.</summary>
			public byte[] Document => this.byte_0;

			/// <summary>Specifies the format of DocumentViewer.SaveDocumentEventArgs.Document.</summary>
			public FileFormat FileFormat => this.fileFormat_0;

			public SaveDocumentEventArgs(byte[] document, FileFormat format)
			{
				this.byte_0 = document;
				this.fileFormat_0 = format;
			}
		}

		/// <summary>The SaveDocumentEventArgs class provides data for the DocumentViewer.SaveFormData event.</summary>
		public class SaveFormDataEventArgs : EventArgs
		{
			private readonly DataTable dataTable_0;

			public DataTable FormData => this.dataTable_0;

			public SaveFormDataEventArgs(DataTable formData)
			{
				this.dataTable_0 = formData;
			}
		}

		public delegate void SaveDocumentEventHandler(object sender, SaveDocumentEventArgs e);

		public delegate void SaveFormDataEventHandler(object sender, SaveFormDataEventArgs e);

		private const bool bool_0 = false;

		private bool bool_1;

		private Control0 control0_0;

		private Control1 control1_0;

		private DocumentController documentController_0;

		private int int_0 = 100;

		private bool bool_2 = true;

		private double double_0 = 1.0;

		private TXTextControl.DocumentServer.EditMode editMode_0 = TXTextControl.DocumentServer.EditMode.ReadOnly;

		private FieldBorderStyle fieldBorderStyle_0 = FieldBorderStyle.Solid;

		private Color color_0 = Color.FromKnownColor(KnownColor.ActiveBorder);

		private ZoomLevel zoomLevel_0 = ZoomLevel.FullSize;

		private Interpolation interpolation_0 = Interpolation.None;

		private InterpolationMode interpolationMode_0;

		private bool bool_3 = true;

		private bool bool_4 = true;

		private double double_1 = 0.5;

		private bool bool_5 = true;

		[CompilerGenerated]
		private bool bool_6;

		/// <summary>Specifies whether the edit button is shown or not.</summary>
		[Category("Appearance")]
		public bool ShowEditButton
		{
			get
			{
				if (!base.DesignMode && this.Page.Session[this.UniqueID + ":ShowEditButton"] != null)
				{
					return (bool)this.Page.Session[this.UniqueID + ":ShowEditButton"];
				}
				return this.bool_5;
			}
			set
			{
				this.bool_5 = value;
				if (!base.DesignMode && this.Page != null)
				{
					this.Page.Session[this.UniqueID + ":ShowEditButton"] = this.bool_5;
				}
			}
		}

		/// <summary>Specifies whether rounded document page corners should be used or not.</summary>
		[Category("Appearance")]
		public bool RoundedPageCorners
		{
			get
			{
				if (!base.DesignMode && this.Page.Session[this.UniqueID + ":RoundedPageCorners"] != null)
				{
					return (bool)this.Page.Session[this.UniqueID + ":RoundedPageCorners"];
				}
				return this.bool_3;
			}
			set
			{
				this.bool_3 = value;
				if (!base.DesignMode && this.Page != null)
				{
					this.Page.Session[this.UniqueID + ":RoundedPageCorners"] = this.bool_3;
				}
			}
		}

		/// <summary>Specifies whether CSS transition animations should be used or not when navigating through pages.</summary>
		[Category("Appearance")]
		public bool PageAnimations
		{
			get
			{
				if (!base.DesignMode && this.Page.Session[this.UniqueID + ":PageAnimations"] != null)
				{
					return (bool)this.Page.Session[this.UniqueID + ":PageAnimations"];
				}
				return this.bool_4;
			}
			set
			{
				this.bool_4 = value;
				if (!base.DesignMode && this.Page != null)
				{
					this.Page.Session[this.UniqueID + ":PageAnimations"] = this.bool_4;
				}
			}
		}

		/// <summary>Gets or sets the duration of the page animations in seconds.</summary>
		[Category("Appearance")]
		public double PageAnimationDuration
		{
			get
			{
				if (!base.DesignMode && this.Page.Session[this.UniqueID + ":PageAnimationDuration"] != null)
				{
					return (double)this.Page.Session[this.UniqueID + ":PageAnimationDuration"];
				}
				return this.double_1;
			}
			set
			{
				this.double_1 = value;
				if (!base.DesignMode && this.Page != null)
				{
					this.Page.Session[this.UniqueID + ":PageAnimationDuration"] = this.double_1;
				}
			}
		}

		/// <summary>Specifies whether the document viewer's tool bar is displayed or not.</summary>
		[Category("Appearance")]
		public bool ToolBar
		{
			get
			{
				if (!base.DesignMode && this.Page.Session[this.UniqueID + ":ToolBar"] != null)
				{
					return (bool)this.Page.Session[this.UniqueID + ":ToolBar"];
				}
				return this.bool_2;
			}
			set
			{
				this.bool_2 = value;
				if (!base.DesignMode && this.Page != null)
				{
					this.Page.Session[this.UniqueID + ":ToolBar"] = this.bool_2;
				}
			}
		}

		/// <summary>Gets or sets whether the document viewer renders forms editable, i.e.</summary>
		[Category("Behavior")]
		public TXTextControl.DocumentServer.EditMode EditMode
		{
			get
			{
				if (!base.DesignMode && this.Page.Session[this.UniqueID + ":EditMode"] != null)
				{
					return (TXTextControl.DocumentServer.EditMode)this.Page.Session[this.UniqueID + ":EditMode"];
				}
				return this.editMode_0;
			}
			set
			{
				this.editMode_0 = value;
				if (!base.DesignMode && this.Page != null)
				{
					this.Page.Session[this.UniqueID + ":EditMode"] = this.editMode_0;
				}
			}
		}

		protected bool FormFieldValuesLoading
		{
			[CompilerGenerated]
			get
			{
				return this.bool_6;
			}
			[CompilerGenerated]
			set
			{
				this.bool_6 = value;
			}
		}

		protected DataTable FormFieldValues
		{
			get
			{
				string name = this.UniqueID + ":FormFieldValues";
				DataTable dataTable = ((this.Page.Session[name] != null) ? ((DataTable)this.Page.Session[name]) : new DataTable("Form Field Values"));
				if (dataTable.Columns.Count == 0)
				{
					dataTable.Columns.Add("Name", typeof(string));
					dataTable.Columns.Add("Value", typeof(string));
					dataTable.PrimaryKey = new DataColumn[1] { dataTable.Columns["Name"] };
					this.FormFieldValues = dataTable;
				}
				return dataTable;
			}
			set
			{
				this.Page.Session[this.UniqueID + ":FormFieldValues"] = value;
			}
		}

		protected byte[] LoadedDocument
		{
			get
			{
				if (this.Page.Session[this.UniqueID + ":LoadedDocument"] == null)
				{
					return null;
				}
				return Convert.FromBase64String((string)this.Page.Session[this.UniqueID + ":LoadedDocument"]);
			}
			set
			{
				this.Page.Session[this.UniqueID + ":LoadedDocument"] = ((value != null) ? Convert.ToBase64String(value) : null);
			}
		}

		protected string DocumentLoadPath
		{
			get
			{
				if (!base.DesignMode && this.Page.Session[this.UniqueID + ":DocumentLoadPath"] != null)
				{
					return (string)this.Page.Session[this.UniqueID + ":DocumentLoadPath"];
				}
				return "";
			}
			set
			{
				if (!base.DesignMode && File.Exists(value))
				{
					string text = null;
					if (this.Page.Session[this.UniqueID + ":DocumentLoadPath"] != null)
					{
						text = this.Page.Session[this.UniqueID + ":DocumentLoadPath"] as string;
					}
					if (string.IsNullOrEmpty(text) || !text.Equals(value))
					{
						this.ResetFormFieldValues();
						this.Page.Session.Remove(this.UniqueID + ":LoadedDocument");
						this.Page.Session.Remove(this.UniqueID + ":PageNumber");
						this.Page.Session.Remove(this.UniqueID + ":TotalPages");
					}
					this.Page.Session.Remove(this.UniqueID + ":DocumentLoadData");
					this.Page.Session[this.UniqueID + ":DocumentLoadPath"] = value;
				}
			}
		}

		protected object DocumentLoadData
		{
			get
			{
				if (!base.DesignMode)
				{
					string text = null;
					if (this.Page.Session[this.UniqueID + ":DocumentLoadData"] != null)
					{
						text = this.Page.Session[this.UniqueID + ":DocumentLoadData"] as string;
					}
					if (text != null && this.FileLoadFormat != FileFormat.RichTextFormat)
					{
						return Convert.FromBase64String(text);
					}
					return text;
				}
				return null;
			}
			set
			{
				if (!base.DesignMode && (value is string || value is byte[]))
				{
					string text = ((this.FileLoadFormat == FileFormat.RichTextFormat) ? (value as string) : Convert.ToBase64String(value as byte[]));
					if (this.Page.Session[this.UniqueID + ":DocumentLoadData"] == null || !this.Page.Session[this.UniqueID + ":DocumentLoadData"].Equals(text))
					{
						this.ResetFormFieldValues();
						this.Page.Session.Remove(this.UniqueID + ":LoadedDocument");
						this.Page.Session.Remove(this.UniqueID + ":PageNumber");
						this.Page.Session.Remove(this.UniqueID + ":TotalPages");
					}
					this.Page.Session.Remove(this.UniqueID + ":DocumentLoadPath");
					this.Page.Session[this.UniqueID + ":DocumentLoadData"] = text;
				}
			}
		}

		protected bool SaveFormDataRequested
		{
			get
			{
				string name = this.UniqueID + ":SaveFormDataRequested";
				if (this.Page.Session[name] == null)
				{
					return false;
				}
				return (bool)this.Page.Session[name];
			}
			set
			{
				this.Page.Session[this.UniqueID + ":SaveFormDataRequested"] = value;
			}
		}

		protected bool SaveDocumentRequested
		{
			get
			{
				string name = this.UniqueID + ":SaveDocumentRequested";
				if (this.Page.Session[name] == null)
				{
					return false;
				}
				return (bool)this.Page.Session[name];
			}
			set
			{
				this.Page.Session[this.UniqueID + ":SaveDocumentRequested"] = value;
			}
		}

		protected string DocumentSavePath
		{
			get
			{
				string name = this.UniqueID + ":DocumentSavePath";
				if (!base.DesignMode && this.Page.Session[name] != null)
				{
					return (string)this.Page.Session[name];
				}
				return "";
			}
			set
			{
				if (!base.DesignMode)
				{
					this.Page.Session.Remove(this.UniqueID + ":DocumentSaveData");
					this.Page.Session[this.UniqueID + ":DocumentSavePath"] = value;
				}
			}
		}

		protected FileFormat FileLoadFormat
		{
			get
			{
				if (!base.DesignMode && this.Page.Session[this.UniqueID + ":FileLoadFormat"] != null)
				{
					foreach (FileFormat value in Enum.GetValues(typeof(FileFormat)))
					{
						if (this.Page.Session[this.UniqueID + ":FileLoadFormat"] as string== value.ToString())
						{
							return value;
						}
					}
				}
				return FileFormat.InternalUnicodeFormat;
			}
			set
			{
				if (!base.DesignMode)
				{
					this.Page.Session[this.UniqueID + ":FileLoadFormat"] = value.ToString();
				}
			}
		}

		protected FileFormat FileSaveFormat
		{
			get
			{
				string name = this.UniqueID + ":FileSaveFormat";
				if (!base.DesignMode && this.Page.Session[name] != null)
				{
					foreach (FileFormat value in Enum.GetValues(typeof(FileFormat)))
					{
						if (this.Page.Session[name] as string== value.ToString())
						{
							return value;
						}
					}
				}
				return FileFormat.InternalUnicodeFormat;
			}
			set
			{
				if (!base.DesignMode)
				{
					this.Page.Session[this.UniqueID + ":FileSaveFormat"] = value.ToString();
				}
			}
		}

		/// <summary>Gets or sets the page number that the DocumentServer.Web.DocumentViewer is displaying or should display respectively.</summary>
		[Browsable(false)]
		public int PageNumber
		{
			get
			{
				if (!base.DesignMode && this.TotalPages >= 1)
				{
					if (this.Page.Session[this.UniqueID + ":PageNumber"] == null)
					{
						return 1;
					}
					return int.Parse(this.Page.Session[this.UniqueID + ":PageNumber"] as string);
				}
				return 0;
			}
			set
			{
				if (!base.DesignMode)
				{
					if (this.TotalPages > 0 && value >= 1 && value <= this.TotalPages)
					{
						this.Page.Session[this.UniqueID + ":PageNumber"] = value.ToString();
					}
					else if (this.Page.Session[this.UniqueID + ":PageNumber"] != null)
					{
						this.Page.Session.Remove(this.UniqueID + ":PageNumber");
					}
				}
				this.EnsureChildControls();
				this.control0_0.Int32_0 = this.PageNumber;
			}
		}

		protected bool IsPageNumberValid
		{
			get
			{
				if (1 <= this.PageNumber)
				{
					return this.PageNumber <= this.TotalPages;
				}
				return false;
			}
		}

		/// <summary>Gets the total number of pages the loaded document contains.</summary>
		[Browsable(false)]
		public int TotalPages
		{
			get
			{
				if (!base.DesignMode && this.Page.Session[this.UniqueID + ":TotalPages"] != null)
				{
					return int.Parse(this.Page.Session[this.UniqueID + ":TotalPages"] as string);
				}
				return 0;
			}
			set
			{
				if (!base.DesignMode && this.DocumentController != null && this.Page != null)
				{
					this.Page.Session[this.UniqueID + ":TotalPages"] = this.DocumentController.Pages.Count.ToString();
				}
			}
		}

		/// <summary>Gets or sets whether the rendered document is interpolated during the process.</summary>
		public Interpolation Interpolation
		{
			get
			{
				if (!base.DesignMode && this.Page.Session[this.UniqueID + ":Interpolation"] != null)
				{
					return (Interpolation)this.Page.Session[this.UniqueID + ":Interpolation"];
				}
				return this.interpolation_0;
			}
			set
			{
				this.interpolation_0 = value;
				if (!base.DesignMode && this.Page != null)
				{
					this.Page.Session[this.UniqueID + ":Interpolation"] = this.interpolation_0;
				}
			}
		}

		/// <summary>Gets or sets the interpolation mode which is used for rendering the document.</summary>
		public InterpolationMode InterpolationMode
		{
			get
			{
				if (!base.DesignMode && this.Page.Session[this.UniqueID + ":InterpolationMode"] != null)
				{
					return (InterpolationMode)this.Page.Session[this.UniqueID + ":InterpolationMode"];
				}
				return this.interpolationMode_0;
			}
			set
			{
				this.interpolationMode_0 = value;
				if (!base.DesignMode && this.Page != null)
				{
					this.Page.Session[this.UniqueID + ":InterpolationMode"] = this.interpolationMode_0;
				}
			}
		}

		internal string String_0
		{
			get
			{
				if (this.DocumentController == null)
				{
					return "";
				}
				if (this.DocumentController.TextComponent == null)
				{
					throw new Exception(Resources.EXC_DOCVIEWER_INVALID_TEXT_COMPONENT);
				}
				StringBuilder stringBuilder = new StringBuilder();
				string text = null;
				if (this.IsPageNumberValid)
				{
					try
					{
						stringBuilder.Append(this.PageNumber);
						stringBuilder.Append(this.Size_0.Width);
						stringBuilder.Append(this.Size_0.Height);
						this.DocumentController.Pages[this.PageNumber].Select();
						stringBuilder.Append(((ServerTextControl)this.DocumentController.TextComponent).Selection.Text);
						byte[] array = MD5.Create().ComputeHash(Encoding.Default.GetBytes(stringBuilder.ToString()));
						stringBuilder = new StringBuilder();
						for (int i = 0; i < array.Length; i++)
						{
							stringBuilder.Append(array[i].ToString("x2"));
						}
						text = stringBuilder.ToString();
					}
					catch
					{
					}
				}
				if (text != null)
				{
					return text;
				}
				return Guid.NewGuid().ToString();
			}
		}

		internal Size Size_0
		{
			get
			{
				return new Size((base.DesignMode || this.Page.Session[this.UniqueID + ":PageWidth"] == null) ? 1 : int.Parse(this.Page.Session[this.UniqueID + ":PageWidth"] as string), (base.DesignMode || this.Page.Session[this.UniqueID + ":PageHeight"] == null) ? 1 : int.Parse(this.Page.Session[this.UniqueID + ":PageHeight"] as string));
			}
			set
			{
				if (!base.DesignMode && this.Page != null)
				{
					this.Page.Session[this.UniqueID + ":PageWidth"] = value.Width.ToString();
					this.Page.Session[this.UniqueID + ":PageHeight"] = value.Height.ToString();
				}
			}
		}

		/// <summary>Gets or sets whether and if so how the field borders are rendered, when EditMode is set to Edit.</summary>
		[Category("Appearance")]
		[Browsable(false)]
		public FieldBorderStyle FieldBorderStyle
		{
			get
			{
				string name = this.UniqueID + ":FieldBorderStyle";
				if (!base.DesignMode && this.Page.Session[name] != null)
				{
					return (FieldBorderStyle)this.Page.Session[name];
				}
				return this.fieldBorderStyle_0;
			}
			set
			{
				this.fieldBorderStyle_0 = value;
				if (!base.DesignMode && this.Page != null)
				{
					this.Page.Session[this.UniqueID + ":FieldBorderStyle"] = this.fieldBorderStyle_0;
				}
			}
		}

		/// <summary>Gets or sets the color of the field borders, that is used when FieldBorderStyle is not None.</summary>
		[Category("Appearance")]
		[Browsable(false)]
		public Color FieldBorderColor
		{
			get
			{
				string name = this.UniqueID + ":FieldBorderColor";
				if (!base.DesignMode && this.Page.Session[name] != null)
				{
					return (Color)this.Page.Session[name];
				}
				return this.color_0;
			}
			set
			{
				this.color_0 = value;
				if (!base.DesignMode && this.Page != null)
				{
					this.Page.Session[this.UniqueID + ":FieldBorderColor"] = this.color_0;
				}
			}
		}

		/// <summary>Gets or sets the zoom behavior of the DocumentServer.Web.DocumentViewer.</summary>
		[Category("Appearance")]
		public ZoomLevel ZoomTo
		{
			get
			{
				if (!base.DesignMode && this.Page.Session[this.UniqueID + ":ZoomTo"] != null)
				{
					return (ZoomLevel)this.Page.Session[this.UniqueID + ":ZoomTo"];
				}
				return this.zoomLevel_0;
			}
			set
			{
				this.zoomLevel_0 = value;
				if (!base.DesignMode && this.Page != null)
				{
					this.Page.Session[this.UniqueID + ":ZoomTo"] = this.zoomLevel_0;
				}
			}
		}

		/// <summary>Gets or sets the zoom factor in percent.</summary>
		[Category("Appearance")]
		public int ZoomFactor
		{
			get
			{
				if (!base.DesignMode && this.Page.Session[this.UniqueID + ":ZoomFactor"] != null)
				{
					return (int)this.Page.Session[this.UniqueID + ":ZoomFactor"];
				}
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
				if (!base.DesignMode && this.Page != null)
				{
					this.Page.Session[this.UniqueID + ":ZoomFactor"] = this.int_0;
				}
			}
		}

		protected double ScaleFactor
		{
			get
			{
				return this.double_0;
			}
			set
			{
				this.double_0 = Math.Round(value, 2);
			}
		}

		/// <summary>Gets or sets the DocumentServer.DocumentController object that is associated with the DocumentServer.Web.DocumentViewer component.</summary>
		[Browsable(false)]
		public DocumentController DocumentController
		{
			get
			{
				return this.documentController_0;
			}
			set
			{
				this.documentController_0 = value;
			}
		}

		protected override HtmlTextWriterTag TagKey => HtmlTextWriterTag.Div;

		/// <summary>Occurs when DocumentServer.Web.DocumentViewer.Save has been called, while specifying the format parameter only.</summary>
		public event SaveDocumentEventHandler SaveDocument;

		/// <summary>Occurs when DocumentServer.Web.DocumentViewer.SaveUserInput has been called.</summary>
		public event SaveFormDataEventHandler SaveFormData;

		protected override void OnLoad(EventArgs eventArgs_0)
		{
			base.OnLoad(eventArgs_0);
			if (this.Width.IsEmpty)
			{
				this.Width = Unit.Pixel(400);
			}
			if (this.Height.IsEmpty)
			{
				this.Height = Unit.Pixel(200);
			}
		}

		protected override void CreateChildControls()
		{
			this.Controls.Clear();
			this.control0_0 = new Control0();
			this.control0_0.ID = "toolbar";
			this.control0_0.EditMode += method_3;
			this.control0_0.FirstPage += method_4;
			this.control0_0.PreviousPage += method_5;
			this.control0_0.NextPage += method_6;
			this.control0_0.LastPage += method_7;
			this.control0_0.HalfSize += method_8;
			this.control0_0.FullSize += method_9;
			this.control0_0.FillWidth += method_10;
			this.control0_0.WholePage += method_11;
			if (!this.ToolBar)
			{
				this.control0_0.Style.Add("display", "none");
			}
			this.Controls.Add(this.control0_0);
			this.control1_0 = new Control1();
			this.control1_0.ID = "view";
			this.Controls.Add(this.control1_0);
			base.ChildControlsCreated = true;
		}

		~DocumentViewer()
		{
			this.Dispose(disposing: false);
		}

		/// <summary>Frees all resources used by the DocumentViewer instance.</summary>
		public override void Dispose()
		{
			this.Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (this.bool_1)
			{
				return;
			}
			if (disposing)
			{
				if (this.Controls != null)
				{
					foreach (Control control in this.Controls)
					{
						control.Dispose();
					}
				}
				if (this.documentController_0 != null)
				{
					this.documentController_0.Dispose();
				}
			}
			base.Dispose();
			this.bool_1 = true;
		}

		protected override void OnPreRender(EventArgs eventArgs_0)
		{
			base.OnPreRender(eventArgs_0);
			base.Style.Add("overflow", "hidden");
			if (this.DocumentController == null)
			{
				return;
			}
			bool flag = false;
			if (this.LoadedDocument != null)
			{
				try
				{
					this.DocumentController.LoadFromMemory(this.LoadedDocument, FileFormat.InternalUnicodeFormat);
					flag = true;
				}
				catch
				{
				}
			}
			else if (!string.IsNullOrEmpty(this.DocumentLoadPath))
			{
				try
				{
					this.DocumentController.Load(this.DocumentLoadPath, this.FileLoadFormat);
					flag = true;
				}
				catch
				{
				}
			}
			else if (this.DocumentLoadData != null)
			{
				try
				{
					this.DocumentController.LoadFromMemory(this.DocumentLoadData, this.FileLoadFormat);
					flag = true;
				}
				catch
				{
				}
			}
			if (!flag)
			{
				this.DocumentLoadPath = "";
				this.DocumentLoadData = null;
				return;
			}
			if (this.LoadedDocument == null)
			{
				this.SaveDocumentToSession();
			}
			this.TotalPages = this.DocumentController.Pages.Count;
			this.PageNumber = this.PageNumber;
			this.method_0();
			if (!this.FormFieldValuesLoading)
			{
				this.StoreFormFieldValues();
			}
			if (this.SaveDocumentRequested)
			{
				this.SaveDocumentRequested = false;
				SaveDocumentEventArgs saveDocumentEventArgs = null;
				if (!string.IsNullOrEmpty(this.DocumentSavePath))
				{
					StreamType fileFormat = (StreamType)0;
					switch (this.FileSaveFormat)
					{
					case FileFormat.MSWord:
						fileFormat = StreamType.MSWord;
						break;
					case FileFormat.RichTextFormat:
						fileFormat = StreamType.RichTextFormat;
						break;
					case FileFormat.WordprocessingML:
						fileFormat = StreamType.WordprocessingML;
						break;
					case FileFormat.InternalUnicodeFormat:
						fileFormat = StreamType.InternalUnicodeFormat;
						break;
					}
					this.DocumentController.Save(this.DocumentSavePath, fileFormat, new SaveSettings());
				}
				else if (this.FileSaveFormat == FileFormat.RichTextFormat)
				{
					this.DocumentController.SaveToMemory(out var data, StringStreamType.RichTextFormat, new SaveSettings());
					saveDocumentEventArgs = new SaveDocumentEventArgs(Encoding.UTF8.GetBytes(data), this.FileSaveFormat);
				}
				else
				{
					BinaryStreamType fileFormat2 = (BinaryStreamType)0;
					switch (this.FileSaveFormat)
					{
					case FileFormat.MSWord:
						fileFormat2 = BinaryStreamType.MSWord;
						break;
					case FileFormat.WordprocessingML:
						fileFormat2 = BinaryStreamType.WordprocessingML;
						break;
					case FileFormat.InternalUnicodeFormat:
						fileFormat2 = BinaryStreamType.InternalUnicodeFormat;
						break;
					}
					this.DocumentController.SaveToMemory(out var data2, fileFormat2, new SaveSettings());
					saveDocumentEventArgs = new SaveDocumentEventArgs(data2, this.FileSaveFormat);
				}
				if (saveDocumentEventArgs != null)
				{
					this.OnSaveDocument(saveDocumentEventArgs);
				}
			}
			if (this.SaveFormDataRequested)
			{
				this.SaveFormDataRequested = false;
				SaveFormDataEventArgs saveFormDataEventArgs_ = new SaveFormDataEventArgs(this.FormFieldValues);
				this.OnSaveFormData(saveFormDataEventArgs_);
			}
			if (!base.DesignMode && this.Page.Request.Params["viewerId"] != null && this.Page.Request.Params["viewerId"] == this.ClientID)
			{
				this.method_1();
			}
			this.MergeAndRenderFields();
		}

		protected void MergeAndRenderFields()
		{
			if (this.DocumentController == null)
			{
				return;
			}
			if (this.DocumentController.TextComponent == null)
			{
				throw new Exception(Resources.EXC_DOCVIEWER_INVALID_TEXT_COMPONENT);
			}
            TXTextControl.Page page = this.DocumentController.Pages[this.PageNumber];
			DocumentController.FieldAdapterCollection fieldAdapters = this.DocumentController.GetFieldAdapters(page);
			if (fieldAdapters.Count < 1)
			{
				return;
			}
			FieldAdapter fieldAdapter = fieldAdapters[0];
			int num = this.DocumentController.GetFieldAdapters().IndexOf(fieldAdapter) - 1;
			foreach (FieldAdapter item in fieldAdapters)
			{
				try
				{
					FormFieldAdapter formFieldAdapter = item as FormFieldAdapter;
					if (formFieldAdapter == null)
					{
						continue;
					}
					string string_ = $"{formFieldAdapter.Name}_{++num:d3}";
					string text = this.method_2(string_);
					if (text != null)
					{
						this.DocumentController.MergeField(formFieldAdapter, text);
						if (this.EditMode == TXTextControl.DocumentServer.EditMode.Edit)
						{
							this.control1_0.method_1(formFieldAdapter, num, this.ScaleFactor);
						}
					}
				}
				catch
				{
				}
			}
			this.SaveDocumentToSession();
		}

		private void method_0()
		{
			if (!this.IsPageNumberValid)
			{
				this.Size_0 = new Size(1, 1);
				return;
			}
			double num = DocumentController.Twips2Pixels(this.DocumentController.Pages[this.PageNumber].Bounds.Size.Width, DocumentController.DpiX);
			double num2 = DocumentController.Twips2Pixels(this.DocumentController.Pages[this.PageNumber].Bounds.Size.Height, DocumentController.DpiY);
			double num3 = this.Width.Value - 90.0;
			double num4 = this.Height.Value - 108.0;
			if (this.ZoomTo == ZoomLevel.HalfSize)
			{
				this.ScaleFactor = 0.5;
			}
			else if (this.ZoomTo == ZoomLevel.FullSize)
			{
				this.ScaleFactor = (double)this.ZoomFactor / 100.0;
			}
			else if (this.ZoomTo == ZoomLevel.ControlWidth)
			{
				this.ScaleFactor = num3 / num;
			}
			else if (this.ZoomTo == ZoomLevel.WholePage)
			{
				this.ScaleFactor = Math.Min(num3 / num, num4 / num2);
			}
			this.Size_0 = new Size((int)(num * this.ScaleFactor), (int)(num2 * this.ScaleFactor));
		}

		private void method_1()
		{
			Bitmap bitmap = null;
			if (this.Interpolation == Interpolation.None)
			{
                TXTextControl.Page page = this.DocumentController.Pages[this.PageNumber];
				bitmap = ((!this.IsPageNumberValid) ? null : page.GetImage((int)(this.ScaleFactor * 100.0), TXTextControl.Page.PageContent.All));
			}
			else
			{
				Metafile image = ((!this.IsPageNumberValid) ? null : this.DocumentController.Pages[this.PageNumber].GetImage(TXTextControl.Page.PageContent.All));
				bitmap = this.InterpolateImage(image);
			}
			if (bitmap == null)
			{
				bitmap = new Bitmap(1, 1);
			}
			MemoryStream memoryStream = new MemoryStream();
			bitmap.Save(memoryStream, ImageFormat.Png);
			bitmap.Dispose();
			this.Page.Response.Clear();
			this.Page.Response.ContentType = "image/png";
			memoryStream.WriteTo(this.Parent.Page.Response.OutputStream);
			memoryStream.Close();
			this.Page.Response.End();
		}

		protected Bitmap InterpolateImage(Metafile image)
		{
			if (image == null)
			{
				return null;
			}
			int interpolation = (int)this.Interpolation;
			Bitmap bitmap = new Bitmap(interpolation * this.Size_0.Width, interpolation * this.Size_0.Height, PixelFormat.Format32bppArgb);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.CompositingMode = CompositingMode.SourceOver;
			graphics.CompositingQuality = CompositingQuality.HighQuality;
			graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
			graphics.DrawImage(image, 0, 0, bitmap.Width, bitmap.Height);
			graphics.Dispose();
			Bitmap bitmap2 = new Bitmap(this.Size_0.Width, this.Size_0.Height, PixelFormat.Format32bppArgb);
			Graphics graphics2 = Graphics.FromImage(bitmap2);
			graphics2.InterpolationMode = this.InterpolationMode;
			graphics2.PixelOffsetMode = PixelOffsetMode.HighQuality;
			graphics2.SmoothingMode = SmoothingMode.HighQuality;
			graphics2.DrawImage(bitmap, 0, 0, this.Size_0.Width, this.Size_0.Height);
			graphics2.Dispose();
			bitmap.Dispose();
			return bitmap2;
		}

		/// <summary>Loads a document from a specific path.</summary>
		/// <param name="path">Specifies the document file to be loaded.</param>
		public void LoadDocument(string path)
		{
			if (File.Exists(path))
			{
				switch (Path.GetExtension(path))
				{
				default:
					this.FileLoadFormat = FileFormat.InternalUnicodeFormat;
					break;
				case ".rtf":
					this.FileLoadFormat = FileFormat.RichTextFormat;
					break;
				case ".docx":
					this.FileLoadFormat = FileFormat.WordprocessingML;
					break;
				case ".doc":
					this.FileLoadFormat = FileFormat.MSWord;
					break;
				}
				this.DocumentLoadPath = path;
			}
		}

		public void LoadDocument(string path, FileFormat format)
		{
			if (File.Exists(path))
			{
				this.FileLoadFormat = format;
				this.DocumentLoadPath = path;
			}
		}

		public void LoadDocumentFromMemory(object data, FileFormat format)
		{
			if (data != null)
			{
				this.FileLoadFormat = format;
				this.DocumentLoadData = data;
			}
		}

		/// <summary>Saves the document to a specific path.</summary>
		/// <param name="path">Specifies where the document should be saved.</param>
		public void Save(string path)
		{
			switch (Path.GetExtension(path))
			{
			default:
				this.FileSaveFormat = FileFormat.InternalUnicodeFormat;
				break;
			case ".rtf":
				this.FileSaveFormat = FileFormat.RichTextFormat;
				break;
			case ".docx":
				this.FileSaveFormat = FileFormat.WordprocessingML;
				break;
			case ".doc":
				this.FileSaveFormat = FileFormat.MSWord;
				break;
			}
			this.DocumentSavePath = path;
			this.SaveDocumentRequested = true;
		}

		public void Save(string path, FileFormat format)
		{
			this.FileSaveFormat = format;
			this.DocumentSavePath = path;
			this.SaveDocumentRequested = true;
		}

		public void Save(FileFormat format)
		{
			this.FileSaveFormat = format;
			this.SaveDocumentRequested = true;
		}

		protected void SaveDocumentToSession()
		{
			byte[] data = null;
			try
			{
				this.DocumentController.SaveToMemory(out data, BinaryStreamType.InternalUnicodeFormat, new SaveSettings());
			}
			catch
			{
			}
			finally
			{
				this.LoadedDocument = data;
			}
		}

		internal static string smethod_0(System.Web.UI.Page page_0, string string_0)
		{
			string text = ".png";
			return page_0.ClientScript.GetWebResourceUrl(typeof(DocumentViewer), "DocumentServer.Web.images." + string_0 + text);
		}

		protected void StoreFormFieldValues()
		{
			int num = -1;
			foreach (FieldAdapter fieldAdapter in this.DocumentController.GetFieldAdapters())
			{
				try
				{
					FormFieldAdapter formFieldAdapter = fieldAdapter as FormFieldAdapter;
					if (formFieldAdapter == null)
					{
						continue;
					}
					string text = $"{formFieldAdapter.Name}_{++num:d3}";
					string key = $"{this.control1_0.ClientID.Replace('_', '$')}${text}";
					string text2 = this.method_2(text);
					if (this.Page.Request[key] != null)
					{
						text2 = this.Page.Request[key];
						if (formFieldAdapter is FormCheckBox)
						{
							text2 = (text2.Contains("on") ? true.ToString() : false.ToString());
						}
					}
					else if (text2 == null)
					{
						if (fieldAdapter is FormCheckBox)
						{
							text2 = ((FormCheckBox)fieldAdapter).Checked.ToString();
						}
						else if (fieldAdapter is FormDropDown)
						{
							IEnumerator<string> enumerator2 = ((FormDropDown)fieldAdapter).ListEntries.GetEnumerator();
							enumerator2.Reset();
							if (enumerator2.MoveNext())
							{
								text2 = enumerator2.Current;
							}
						}
						else if (fieldAdapter is FormText)
						{
							text2 = ((FormText)fieldAdapter).Text;
						}
					}
					this.StoreFormFieldValue(text, text2);
				}
				catch
				{
				}
			}
		}

		protected void StoreFormFieldValue(string name, string value)
		{
			DataTable formFieldValues = this.FormFieldValues;
			if (formFieldValues.Rows.Contains(name))
			{
				formFieldValues.Rows.Find(name).ItemArray = new object[2] { name, value };
			}
			else
			{
				formFieldValues.Rows.Add(name, value);
			}
			this.FormFieldValues = formFieldValues;
		}

		internal string method_2(string string_0)
		{
			DataTable formFieldValues = this.FormFieldValues;
			if (!formFieldValues.Rows.Contains(string_0))
			{
				return null;
			}
			return (string)formFieldValues.Rows.Find(string_0)["Value"];
		}

		public void LoadFormData(DataTable formData)
		{
			this.FormFieldValuesLoading = true;
			this.FormFieldValues = formData;
		}

		/// <summary>Initiates saving the currently loaded form's user input. The actual saving is performed by a method which has to be bound to the DocumentServer.Web.DocumentViewer.SaveFormData event.</summary>
		public void SaveUserInput()
		{
			this.SaveFormDataRequested = true;
		}

		protected void ResetFormFieldValues()
		{
			this.Page.Session.Remove(this.UniqueID + ":FormFieldValues");
		}

		protected virtual void OnSaveDocument(SaveDocumentEventArgs saveDocumentEventArgs_0)
		{
			this.SaveDocument?.Invoke(this, saveDocumentEventArgs_0);
		}

		protected virtual void OnSaveFormData(SaveFormDataEventArgs saveFormDataEventArgs_0)
		{
			this.SaveFormData?.Invoke(this, saveFormDataEventArgs_0);
		}

		private void method_3(object sender, EventArgs e)
		{
			this.EditMode = ((this.EditMode == TXTextControl.DocumentServer.EditMode.Edit) ? TXTextControl.DocumentServer.EditMode.ReadOnly : TXTextControl.DocumentServer.EditMode.Edit);
		}

		private void method_4(object sender, EventArgs e)
		{
			if (this.PageNumber != 1)
			{
				this.PageNumber = 1;
			}
		}

		private void method_5(object sender, EventArgs e)
		{
			if (this.PageNumber > 1)
			{
				this.PageNumber--;
			}
		}

		private void method_6(object sender, EventArgs e)
		{
			if (this.PageNumber < this.TotalPages)
			{
				this.PageNumber++;
			}
		}

		private void method_7(object sender, EventArgs e)
		{
			if (this.PageNumber != this.TotalPages)
			{
				this.PageNumber = this.TotalPages;
			}
		}

		private void method_8(object sender, EventArgs e)
		{
			this.ZoomTo = ZoomLevel.HalfSize;
		}

		private void method_9(object sender, EventArgs e)
		{
			this.ZoomTo = ZoomLevel.FullSize;
		}

		private void method_10(object sender, EventArgs e)
		{
			this.ZoomTo = ZoomLevel.ControlWidth;
		}

		private void method_11(object sender, EventArgs e)
		{
			this.ZoomTo = ZoomLevel.WholePage;
		}

		/// <summary>Initializes a new instance of the DocumentViewer class.</summary>
		public DocumentViewer()
		{
		}
	}
}
