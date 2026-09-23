namespace DocumentServer.PDF.AcroForms
{
	/// <summary>The FormComboBox class implements the Adobe PDF AcroForms combo box field.</summary>
	public class FormComboBox : FormChoiceField
	{
		public FormComboBox(FormChoiceField parent)
			: base(parent)
		{
			base.Options = parent.Options;
			base.MultiSelect = parent.MultiSelect;
			base.CanEdit = parent.CanEdit;
			base.CommitOnSelChange = parent.CommitOnSelChange;
			base.DoNotSpellCheck = parent.DoNotSpellCheck;
			base.Sort = parent.Sort;
			base.Value = parent.Value;
		}
	}
}
