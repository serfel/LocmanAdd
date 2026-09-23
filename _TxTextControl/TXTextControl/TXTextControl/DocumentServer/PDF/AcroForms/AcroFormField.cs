using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace DocumentServer.PDF.AcroForms
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	[XmlRoot("AcroForm")]
	public class AcroFormField
	{
		[CompilerGenerated]
		private string string_0;

		[CompilerGenerated]
		private string string_1;

		[CompilerGenerated]
		private FieldType fieldType_0;

		[CompilerGenerated]
		private string string_2;

		[CompilerGenerated]
		private AcroRectangle DataRowMergedEventArgs;

		[CompilerGenerated]
		private AcroChoiceFieldOptions acroChoiceFieldOptions_0;

		[CompilerGenerated]
		private AcroChoiceFieldFlags acroChoiceFieldFlags_0;

		[CompilerGenerated]
		private AcroButtonFieldFlags acroButtonFieldFlags_0;

		[XmlElement(ElementName = "FieldName")]
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

		[XmlElement(DataType = "string", ElementName = "AlternateFieldName")]
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

		[XmlElement("FieldType", typeof(FieldType))]
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

		[XmlElement(DataType = "string", ElementName = "FieldValue")]
		public string FieldValue
		{
			[CompilerGenerated]
			get
			{
				return this.string_2;
			}
			[CompilerGenerated]
			set
			{
				this.string_2 = value;
			}
		}

		[XmlElement("FieldRect")]
		public AcroRectangle FieldRect
		{
			[CompilerGenerated]
			get
			{
				return this.DataRowMergedEventArgs;
			}
			[CompilerGenerated]
			set
			{
				this.DataRowMergedEventArgs = value;
			}
		}

		[XmlElement("ChoiceFieldOptions", typeof(AcroChoiceFieldOptions))]
		public AcroChoiceFieldOptions ChoiceFieldOptions
		{
			[CompilerGenerated]
			get
			{
				return this.acroChoiceFieldOptions_0;
			}
			[CompilerGenerated]
			set
			{
				this.acroChoiceFieldOptions_0 = value;
			}
		}

		[XmlElement("ChoiceFieldFlags", typeof(AcroChoiceFieldFlags))]
		public AcroChoiceFieldFlags ChoiceFieldFlags
		{
			[CompilerGenerated]
			get
			{
				return this.acroChoiceFieldFlags_0;
			}
			[CompilerGenerated]
			set
			{
				this.acroChoiceFieldFlags_0 = value;
			}
		}

		[XmlElement("ButtonFieldFlags", typeof(AcroButtonFieldFlags))]
		public AcroButtonFieldFlags ButtonFieldFlags
		{
			[CompilerGenerated]
			get
			{
				return this.acroButtonFieldFlags_0;
			}
			[CompilerGenerated]
			set
			{
				this.acroButtonFieldFlags_0 = value;
			}
		}
	}
}
