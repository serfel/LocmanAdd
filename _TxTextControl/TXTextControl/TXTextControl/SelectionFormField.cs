using System;
using System.ComponentModel;
using ns21;

namespace TXTextControl
{
	/// <summary>An object of the SelectionFormField class represents a combobox or a drop-down list on a form.</summary>
	public class SelectionFormField : FormField
	{
		/// <summary>Gets or sets the horizontal extension, in twips, of the SelectionFormField, when there is no selected item.</summary>
		[Browsable(false)]
		public int EmptyWidth
		{
			get
			{
				return base.Int32_1;
			}
			set
			{
				base.Int32_1 = value;
			}
		}

		/// <summary>Gets or sets a value indicating wheather a dropdown arrow is shown so that the user can select an item.</summary>
		[Browsable(false)]
		public bool IsDropDownArrowVisible
		{
			get
			{
				return base.Boolean_1;
			}
			set
			{
				base.Boolean_1 = value;
			}
		}

		/// <summary>Gets or sets a list of items for the SelectionFormField.</summary>
		[Browsable(false)]
		public string[] Items
		{
			get
			{
				string[] array = base.String_1;
				if (array.Length == 1 && array[0] == "")
				{
					return null;
				}
				return array;
			}
			set
			{
				base.String_1 = ((value == null || value.Length == 0) ? new string[1] { "" } : value);
			}
		}

		/// <summary>Gets or sets the index of the selected item of the SelectionFormField.</summary>
		[Browsable(false)]
		public int SelectedIndex
		{
			get
			{
				string[] array = base.String_1;
				return Array.IndexOf(array, base.Text);
			}
			set
			{
				string[] array = base.String_1;
				this.IsDropDownArrowVisible = false;
				base.Text = ((value >= array.Length || value < 0) ? "" : array[value]);
			}
		}

		/// <summary>Initializes a new instance of an empty SelectionFormField. It has no items and no text.</summary>
		/// <param name="emptyWidth">Specifies the horizontal extension, in twips, of the SelectionFormField, when there is no selected item.</param>
		public SelectionFormField(int emptyWidth)
		{
			base.String_1 = new string[1] { "" };
			this.EmptyWidth = emptyWidth;
			base.enum105_0 = Enum105.const_9;
		}

		/// <summary>Initializes a new instance of a SelectionFormField with the specified items and the index of the selected item.</summary>
		/// <param name="items">Specifies a list of items for the SelectionFormField.</param>
		/// <param name="selectedIndex">Specifies the zero-based index of the selected item.</param>
		public SelectionFormField(string[] items, int selectedIndex)
		{
			if (items == null)
			{
				throw new ArgumentOutOfRangeException("items");
			}
			if (selectedIndex >= items.Length)
			{
				throw new ArgumentOutOfRangeException("selectedIndex");
			}
			base.String_1 = items;
			if (selectedIndex >= 0 && selectedIndex < items.Length)
			{
				base.Text = items[selectedIndex];
			}
			base.enum105_0 = Enum105.const_9;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal SelectionFormField(TextControlCore textControlCore_1, TextPart iTextPart, int iFieldID)
			: base(textControlCore_1, iTextPart, iFieldID)
		{
			base.enum105_0 = Enum105.const_9;
		}
	}
}
