using System;
using System.ComponentModel;
using ns21;

namespace TXTextControl
{
	/// <summary>The ApplicationField object supports text field formats of applications such as Microsoft Word.</summary>
	public class ApplicationField : TextField
	{
		/// <summary>Gets or sets the field's format.</summary>
		[Browsable(false)]
		public ApplicationFieldFormat Format
		{
			get
			{
				return (ApplicationFieldFormat)base.enum105_0;
			}
			set
			{
				if (value == ApplicationFieldFormat.None || value == ApplicationFieldFormat.MSWordTXFormFields)
				{
					throw new ArgumentException(value.ToString());
				}
				base.enum105_0 = (Enum105)value;
			}
		}

		/// <summary>Gets or sets the field's type name.</summary>
		[Browsable(false)]
		public string TypeName
		{
			get
			{
				return base.String_1[0];
			}
			set
			{
				string[] array = base.String_1;
				array[0] = value;
				base.String_1 = array;
			}
		}

		/// <summary>Gets or sets the field's parameters.</summary>
		[Browsable(false)]
		public string[] Parameters
		{
			get
			{
				string[] array = base.String_1;
				if (array.Length > 1)
				{
					string[] array2 = new string[array.Length - 1];
					Array.Copy(array, 1, array2, 0, array.Length - 1);
					return array2;
				}
				return null;
			}
			set
			{
				string[] array = new string[value.Length + 1];
				array[0] = this.TypeName;
				value.CopyTo(array, 1);
				base.String_1 = array;
			}
		}

		/// <summary>Initializes a new instance of the ApplicationField class. The format of the parameters depends on the application that supports the field. The field is initialized without syntax check.</summary>
		/// <param name="format">Specifies the format of the field.</param>
		/// <param name="typeName">Specifies the type name of the field.</param>
		/// <param name="text">Specifies the visible text of the field.</param>
		/// <param name="parameters">Specifies an array of strings which are the field's parameters.</param>
		public ApplicationField(ApplicationFieldFormat format, string typeName, string text, string[] parameters)
			: base(text)
		{
			if (format != 0 && format != ApplicationFieldFormat.MSWordTXFormFields)
			{
				string[] array = new string[1 + ((parameters != null) ? parameters.Length : 0)];
				array[0] = typeName;
				parameters?.CopyTo(array, 1);
				base.String_1 = array;
				base.enum105_0 = (Enum105)format;
				return;
			}
			throw new ArgumentException(format.ToString());
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal ApplicationField(TextControlCore textControlCore_1, TextPart iTextPart, int iFieldID, Enum105 type)
			: base(textControlCore_1, iTextPart, iFieldID)
		{
			base.enum105_0 = type;
		}
	}
}
