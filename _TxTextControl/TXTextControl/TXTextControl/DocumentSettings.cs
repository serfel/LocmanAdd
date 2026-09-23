using System;

namespace TXTextControl
{
	/// <summary>The DocumentSettings class provides properties which inform about general document settings, such as author and title, contained in the document the user is currently working on (see TXTextControl.documentSettings).</summary>
	public class DocumentSettings
	{
		private string string_0 = string.Empty;

		private DateTime dateTime_0 = new DateTime(0L);

		private string string_1 = string.Empty;

		private string string_2 = string.Empty;

		private string[] string_3;

		private string string_4 = string.Empty;

		private string string_5 = string.Empty;

		private EmbeddedFile[] embeddedFile_0;

		private UserDefinedPropertyDictionary userDefinedPropertyDictionary_0;

		/// <summary>Gets or sets the author of the current document.</summary>
		public string Author
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}

		/// <summary>Gets or sets the document's creation date.</summary>
		public DateTime CreationDate
		{
			get
			{
				return this.dateTime_0;
			}
			set
			{
				this.dateTime_0 = value;
			}
		}

		/// <summary>Gets or sets the application, which has created the current document.</summary>
		public string CreatorApplication
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}

		/// <summary>Gets or sets a file path that is used to search for resources like images or hypertext links.</summary>
		public string DocumentBasePath
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
			}
		}

		/// <summary>Gets or sets the current document's keywords.</summary>
		public string[] DocumentKeywords
		{
			get
			{
				return this.string_3;
			}
			set
			{
				this.string_3 = value;
			}
		}

		/// <summary>Gets or sets the subject string of the current document.</summary>
		public string DocumentSubject
		{
			get
			{
				return this.string_4;
			}
			set
			{
				this.string_4 = value;
			}
		}

		/// <summary>Gets or sets the current document's title.</summary>
		public string DocumentTitle
		{
			get
			{
				return this.string_5;
			}
			set
			{
				this.string_5 = value;
			}
		}

		/// <summary>Gets or sets an array of EmbeddedFile objects providing the name, data and additional optional properties of files, which are embedded in the current document.</summary>
		public EmbeddedFile[] EmbeddedFiles
		{
			get
			{
				return this.embeddedFile_0;
			}
			set
			{
				this.embeddedFile_0 = value;
			}
		}

		/// <summary>Gets or sets a dictionary with all user-defined document properties contained in the current document.</summary>
		public UserDefinedPropertyDictionary UserDefinedDocumentProperties
		{
			get
			{
				return this.userDefinedPropertyDictionary_0;
			}
			set
			{
				this.userDefinedPropertyDictionary_0 = value;
			}
		}

		internal void method_0(LoadSettings loadSettings_0)
		{
			this.string_0 = loadSettings_0.Author;
			this.dateTime_0 = loadSettings_0.CreationDate;
			this.string_1 = loadSettings_0.CreatorApplication;
			this.string_2 = loadSettings_0.DocumentBasePath;
			this.string_3 = loadSettings_0.DocumentKeywords;
			this.string_4 = loadSettings_0.DocumentSubject;
			this.string_5 = loadSettings_0.DocumentTitle;
			this.embeddedFile_0 = loadSettings_0.EmbeddedFiles;
			this.userDefinedPropertyDictionary_0 = loadSettings_0.UserDefinedDocumentProperties;
		}

		internal void method_1(SaveSettings saveSettings_0)
		{
			if (string.IsNullOrEmpty(saveSettings_0.Author))
			{
				saveSettings_0.Author = this.string_0;
			}
			if (string.IsNullOrEmpty(saveSettings_0.CreatorApplication))
			{
				saveSettings_0.CreatorApplication = this.string_1;
			}
			if (string.IsNullOrEmpty(saveSettings_0.DocumentBasePath))
			{
				saveSettings_0.DocumentBasePath = this.string_2;
			}
			if (saveSettings_0.DocumentKeywords == null)
			{
				saveSettings_0.DocumentKeywords = this.string_3;
			}
			if (string.IsNullOrEmpty(saveSettings_0.DocumentSubject))
			{
				saveSettings_0.DocumentSubject = this.string_4;
			}
			if (string.IsNullOrEmpty(saveSettings_0.DocumentTitle))
			{
				saveSettings_0.DocumentTitle = this.string_5;
			}
			if (saveSettings_0.EmbeddedFiles == null)
			{
				saveSettings_0.EmbeddedFiles = this.embeddedFile_0;
			}
			if (saveSettings_0.UserDefinedDocumentProperties == null)
			{
				saveSettings_0.UserDefinedDocumentProperties = this.userDefinedPropertyDictionary_0;
			}
			if (saveSettings_0.CreationDate.Ticks == 0L)
			{
				saveSettings_0.CreationDate = this.dateTime_0;
			}
		}

		internal void method_2()
		{
			this.string_0 = string.Empty;
			this.dateTime_0 = new DateTime(0L);
			this.string_1 = string.Empty;
			this.string_2 = string.Empty;
			this.string_3 = null;
			this.string_4 = string.Empty;
			this.string_5 = string.Empty;
			this.embeddedFile_0 = null;
			this.userDefinedPropertyDictionary_0 = null;
		}
	}
}
