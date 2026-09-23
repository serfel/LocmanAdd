using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TXTextControl.Windows.Forms
{
	public class FormFieldItem
	{
		private FormField formField_0;

		private int int_0;

		[CompilerGenerated]
		private string string_0;

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
		private bool bool_5;

		[CompilerGenerated]
		private string[] string_1;

		internal bool Boolean_0
		{
			get
			{
				if ((this.Boolean_1 || this.Boolean_2) && this.Boolean_3 && (this.Boolean_4 || this.Boolean_5))
				{
					if (this.FormField_0 is SelectionFormField)
					{
						return this.Boolean_6;
					}
					return true;
				}
				return false;
			}
			set
			{
				bool flag2 = (this.Boolean_6 = value);
				bool flag4 = (this.Boolean_5 = flag2);
				bool flag6 = (this.Boolean_4 = flag4);
				bool flag8 = (this.Boolean_3 = flag6);
				bool boolean_ = (this.Boolean_2 = flag8);
				this.Boolean_1 = boolean_;
			}
		}

		internal string String_0
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

		internal FormField FormField_0 => this.formField_0;

		internal int Int32_0 => this.int_0;

		internal bool Boolean_1
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

		internal bool Boolean_2
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

		internal bool Boolean_3
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

		internal bool Boolean_4
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

		internal bool Boolean_5
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

		internal bool Boolean_6
		{
			[CompilerGenerated]
			get
			{
				return this.bool_5;
			}
			[CompilerGenerated]
			set
			{
				this.bool_5 = value;
			}
		}

		internal string[] String_1
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

		internal FormFieldItem(FormField formField, string defaultFormFieldName)
		{
			this.formField_0 = formField;
			this.int_0 = this.FormField_0.GetHashCode();
			this.String_0 = (string.IsNullOrEmpty(this.FormField_0.Name) ? (defaultFormFieldName + this.int_0) : this.FormField_0.Name);
			this.method_0();
		}

		internal void method_0()
		{
			if (!(this.FormField_0 is SelectionFormField))
			{
				return;
			}
			SelectionFormField selectionFormField = this.FormField_0 as SelectionFormField;
			string[] items = selectionFormField.Items;
			List<string> list = new List<string>();
			foreach (string text in items)
			{
				if (!string.IsNullOrEmpty(text))
				{
					list.Add(text);
				}
			}
			this.String_1 = list.ToArray();
		}

		public override string ToString()
		{
			return this.String_0;
		}
	}
}
