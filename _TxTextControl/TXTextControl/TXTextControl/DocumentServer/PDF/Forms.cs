using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using DocumentServer.PDF.AcroForms;
using TXTextControl;

namespace DocumentServer.PDF
{
	/// <summary>The Forms class implements PDF specific methods.</summary>
	public static class Forms
	{
		private static DocumentServer.PDF.AcroForms.FormField[] ProcessForm(string sAcroFormsXml)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(sAcroFormsXml);
			List<DocumentServer.PDF.AcroForms.FormField> list = new List<DocumentServer.PDF.AcroForms.FormField>();
			foreach (System.Xml.XmlElement item in xmlDocument.DocumentElement.SelectNodes("AcroForms/AcroForm"))
			{
				XmlReader xmlReader = XmlReader.Create(new StringReader(item.OuterXml));
				AcroFormField acroFormField = (AcroFormField)new XmlSerializer(typeof(AcroFormField), new XmlRootAttribute("AcroForm")).Deserialize(xmlReader);
				DocumentServer.PDF.AcroForms.FormField parent = new DocumentServer.PDF.AcroForms.FormField
				{
					AlternateFieldName = acroFormField.AlternateFieldName,
					FieldName = acroFormField.FieldName,
					Bounds = acroFormField.FieldRect,
					FieldType = acroFormField.FieldType
				};
				switch (acroFormField.FieldType)
				{
				case FieldType.Btn:
				{
					bool isChecked = false;
					if (!string.IsNullOrEmpty(acroFormField.FieldValue))
					{
						isChecked = acroFormField.FieldValue != "Off";
					}
					if (!acroFormField.ButtonFieldFlags.IsPushbutton && !acroFormField.ButtonFieldFlags.IsRadio)
					{
						list.Add(new FormCheckBox(parent)
						{
							IsChecked = isChecked
						});
					}
					else if (acroFormField.ButtonFieldFlags.IsPushbutton)
					{
						list.Add(new FormButton(parent));
					}
					else if (acroFormField.ButtonFieldFlags.IsRadio)
					{
						list.Add(new FormRadioButton(parent)
						{
							IsChecked = isChecked
						});
					}
					break;
				}
				case FieldType.const_1:
					list.Add(new FormTextField(parent)
					{
						Value = acroFormField.FieldValue
					});
					break;
				case FieldType.const_3:
				{
					FormChoiceField parent2 = new FormChoiceField(parent)
					{
						Options = acroFormField.ChoiceFieldOptions.ChoiceFieldElements,
						Sort = acroFormField.ChoiceFieldFlags.Sort,
						DoNotSpellCheck = acroFormField.ChoiceFieldFlags.DoNotSpellCheck,
						CanEdit = acroFormField.ChoiceFieldFlags.CanEdit,
						CommitOnSelChange = acroFormField.ChoiceFieldFlags.CommitOnSelChange,
						MultiSelect = acroFormField.ChoiceFieldFlags.MultiSelect,
						Value = acroFormField.FieldValue
					};
					if (acroFormField.ChoiceFieldFlags.IsComboBox)
					{
						list.Add(new FormComboBox(parent2));
					}
					else
					{
						list.Add(new FormListBox(parent2));
					}
					break;
				}
				}
			}
			return list.ToArray();
		}

		/// <summary>Return the imported AcroFormField objects from a file.</summary>
		/// <param name="filename">Specifies the complete file path of the PDF document.</param>
		public static DocumentServer.PDF.AcroForms.FormField[] GetAcroFormFields(string filename)
		{
			if (!File.Exists(filename))
			{
				throw new FileNotFoundException();
			}
			return Forms.ProcessForm(Forms.LoadFormsXml(filename));
		}

		/// <summary>Return the imported AcroFormField objects from a byte array.</summary>
		/// <param name="data">Specifies the byte array of the PDF document.</param>
		public static DocumentServer.PDF.AcroForms.FormField[] GetAcroFormFields(byte[] data)
		{
			if (data == null)
			{
				throw new NullReferenceException();
			}
			return Forms.ProcessForm(Forms.LoadFormsXml(null, data));
		}

		private static string LoadFormsXml(string fileName, byte[] data = null)
		{
			using ServerTextControl serverTextControl = new ServerTextControl();
			serverTextControl.Create();
			LoadSettings loadSettings = new LoadSettings
			{
				PDFImportSettings = PDFImportSettings.LoadEmbeddedData
			};
			if (data == null)
			{
				serverTextControl.Load(fileName, StreamType.AdobePDF, loadSettings);
			}
			else
			{
				serverTextControl.Load(data, BinaryStreamType.AdobePDF, loadSettings);
			}
			return (string)loadSettings.EmbeddedData[EmbeddedDataFormat.FormFields];
		}
	}
}
