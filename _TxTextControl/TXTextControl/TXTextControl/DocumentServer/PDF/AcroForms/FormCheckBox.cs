using System.Runtime.CompilerServices;

namespace DocumentServer.PDF.AcroForms
{
	/// <summary>The FormCheckBox class implements the Adobe PDF AcroForms check box field.</summary>
	public class FormCheckBox : FormField
	{
		[CompilerGenerated]
		private bool bool_0;

		/// <summary>Specifies whether the check box is checked or not.</summary>
		public bool IsChecked
		{
			[CompilerGenerated]
			get
			{
				return this.bool_0;
			}
			[CompilerGenerated]
			set
			{
				this.bool_0 = value;
			}
		}

		public FormCheckBox(FormField parent)
			: base(parent)
		{
		}
	}
}
