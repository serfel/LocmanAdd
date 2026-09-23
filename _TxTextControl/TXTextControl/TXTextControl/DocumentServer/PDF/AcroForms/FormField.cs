using System.Drawing;
using System.Runtime.CompilerServices;

namespace DocumentServer.PDF.AcroForms
{
	/// <summary>The FormField class implements the base class for the Adobe PDF AcroForms form fields.</summary>
	public class FormField
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		[CompilerGenerated]
		private FieldType fieldType_0;

		[CompilerGenerated]
		private Rectangle rectangle_0;

		/// <summary>Gets or sets the name of the field.</summary>
		public string FieldName
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

		/// <summary>Gets or sets the alternate field name of the field.</summary>
		public string AlternateFieldName
		{
			[CompilerGenerated]
			get
			{
				return this.string_1;
			}
			[CompilerGenerated]
			set
			{
				this.string_1 = value;
			}
		}

		/// <summary>Gets or sets the type of the field.</summary>
		public FieldType FieldType
		{
			[CompilerGenerated]
			get
			{
				return this.fieldType_0;
			}
			[CompilerGenerated]
			set
			{
				this.fieldType_0 = value;
			}
		}

		/// <summary>Gets or sets the rectangle bounds of the form field in the document.</summary>
		public Rectangle Bounds
		{
			[CompilerGenerated]
			get
			{
				return this.rectangle_0;
			}
			[CompilerGenerated]
			set
			{
				this.rectangle_0 = value;
			}
		}

		/// <summary>Initializes a complete new instance of the FormField class.</summary>
		public FormField()
		{
		}

		public FormField(FormField parent)
		{
			this.AlternateFieldName = parent.AlternateFieldName;
			this.FieldName = parent.FieldName;
			this.Bounds = parent.Bounds;
			this.FieldType = parent.FieldType;
		}
	}
}
