using System.Runtime.CompilerServices;

namespace DocumentServer.PDF.AcroForms
{
	/// <summary>The FormTextField class implements the Adobe PDF AcroForms form text field.</summary>
	public class FormTextField : FormField
	{
		[CompilerGenerated]
		private string string_2;

		/// <summary>Gets or sets the value of the form text field.</summary>
		public string Value
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

		public FormTextField(FormField parent)
			: base(parent)
		{
		}
	}
}
