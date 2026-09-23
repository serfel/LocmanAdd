using System.ComponentModel;

namespace TXTextControl
{
	/// <summary>An object of the Section class represents a section of a document.</summary>
	public class Section
	{
		private TextControlCore textControlCore_0;

		private int int_0;

		private SectionFormat sectionFormat_0 = new SectionFormat();

		/// <summary>Gets or sets the section's formatting attributes.</summary>
		[Browsable(false)]
		public SectionFormat Format
		{
			get
			{
				return this.sectionFormat_0;
			}
			set
			{
				value.method_2(this.sectionFormat_0);
				this.sectionFormat_0.method_4();
			}
		}

		/// <summary>Gets a collection of all headers and footers of the section.</summary>
		[Browsable(false)]
		public HeaderFooterCollection HeadersAndFooters
		{
			get
			{
				if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
				{
					return new HeaderFooterCollection(this.textControlCore_0, this.int_0);
				}
				return null;
			}
		}

		/// <summary>Gets the section's number.</summary>
		[Browsable(false)]
		public int Number => this.int_0;

		/// <summary>Gets the number of characters in the section.</summary>
		[Browsable(false)]
		public int Length
		{
			get
			{
				int[] array = new int[2];
				int[] array2 = array;
				this.textControlCore_0.method_40(TextPart.Auto, 1903, this.int_0, array2);
				return 1 + array2[1] - array2[0];
			}
		}

		/// <summary>Gets the number (one-based) of the first character in the section.</summary>
		[Browsable(false)]
		public int Start
		{
			get
			{
				int[] array = new int[2];
				int[] array2 = array;
				this.textControlCore_0.method_40(TextPart.Auto, 1903, this.int_0, array2);
				return array2[0];
			}
		}

		internal Section(TextControlCore textControlCore_1, int iNumber)
		{
			this.textControlCore_0 = textControlCore_1;
			this.int_0 = iNumber;
			this.sectionFormat_0.method_1(textControlCore_1, iNumber);
		}

		/// <summary>Selects the section. The section break characters bounding the section are not selected.</summary>
		public void Select()
		{
			int[] array = new int[2];
			int[] array2 = array;
			this.textControlCore_0.method_40(TextPart.Auto, 1903, this.int_0, array2);
			this.textControlCore_0.method_5(TextPart.Auto, array2[0] - 1, 1 + array2[1] - array2[0]);
		}
	}
}
