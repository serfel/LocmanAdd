using System.Runtime.CompilerServices;

namespace DocumentServer.PDF.AcroForms
{
	/// <summary>The FormChoiceField class implements the base class for Adobe PDF AcroForms form choice fields.</summary>
	public class FormChoiceField : FormField
	{
		[CompilerGenerated]
		private string[] string_2;

		[CompilerGenerated]
		private bool bool_0;

		[CompilerGenerated]
		private bool bool_1;

		[CompilerGenerated]
		private bool bool_2;

		[CompilerGenerated]
		private bool bool_3;

		[CompilerGenerated]
		private bool bool_4;

		[CompilerGenerated]
		private string string_3;

		/// <summary>Gets or sets the option elements of a choice field.</summary>
		public string[] Options
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

		/// <summary>Specifies whether a field can be edited.</summary>
		public bool CanEdit
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

		/// <summary>Specifies whether the list can be sorted.</summary>
		public bool Sort
		{
			[CompilerGenerated]
			get
			{
				return this.bool_1;
			}
			[CompilerGenerated]
			set
			{
				this.bool_1 = value;
			}
		}

		/// <summary>Specifies whether multiple options can be selected.</summary>
		public bool MultiSelect
		{
			[CompilerGenerated]
			get
			{
				return this.bool_2;
			}
			[CompilerGenerated]
			set
			{
				this.bool_2 = value;
			}
		}

		/// <summary>Specifies whether spell checking is enabled or not.</summary>
		public bool DoNotSpellCheck
		{
			[CompilerGenerated]
			get
			{
				return this.bool_3;
			}
			[CompilerGenerated]
			set
			{
				this.bool_3 = value;
			}
		}

		/// <summary>Specifies whether the form is submitted when the selected is changed.</summary>
		public bool CommitOnSelChange
		{
			[CompilerGenerated]
			get
			{
				return this.bool_4;
			}
			[CompilerGenerated]
			set
			{
				this.bool_4 = value;
			}
		}

		/// <summary>Gets or sets the selected value of a choice list.</summary>
		public string Value
		{
			[CompilerGenerated]
			get
			{
				return this.string_3;
			}
			[CompilerGenerated]
			set
			{
				this.string_3 = value;
			}
		}

		public FormChoiceField(FormField parent)
			: base(parent)
		{
		}
	}
}
