using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	/// <summary>An instance of this class represents an element in a XML document.</summary>
	public class XmlElement
	{
		private enum Enum130
		{
			const_0 = 1,
			const_1
		}

		public enum InsertPosition
		{
			XML_INSERTBEFORE = 1,
			XML_INSERTAFTER
		}

		private TextControlCore textControlCore_0;

		private Enum130 enum130_0;

		private string string_0;

		private int int_0;

		private string string_1;

		private int int_1;

		private string string_2;

		/// <summary>Specifies the text of the XML element.</summary>
		[DefaultValue("")]
		[Browsable(false)]
		public string Text
		{
			get
			{
				if (this.textControlCore_0 != null)
				{
					IntPtr zero = IntPtr.Zero;
					string empty = string.Empty;
					Struct72 struct72_ = new Struct72(this.string_0, this.int_0, (this.string_1 == "") ? null : this.string_1, this.int_1, 0u);
					zero = this.textControlCore_0.method_67(Enum83.const_195, 0, ref struct72_);
					empty = Marshal.PtrToStringUni(zero);
					Marshal.FreeBSTR(zero);
					return empty;
				}
				return this.string_2;
			}
			set
			{
				if (this.textControlCore_0 != null)
				{
					Struct72 struct72_ = new Struct72(this.string_0, this.int_0, (this.string_1 == "") ? null : this.string_1, this.int_1, (uint)this.enum130_0);
					this.textControlCore_0.method_68(Enum83.const_196, value, ref struct72_);
				}
				else
				{
					this.string_2 = value;
				}
			}
		}

		/// <summary>Gets the name of an XML element.</summary>
		[Browsable(false)]
		[DefaultValue("")]
		public string ElementName => this.string_0;

		/// <summary>Determines whether text is automatically created for a newly added XML element that has no text contents.</summary>
		[DefaultValue(false)]
		[Browsable(false)]
		public bool AutoText
		{
			get
			{
				return (this.enum130_0 & Enum130.const_0) == 0;
			}
			set
			{
				if (!value)
				{
					this.enum130_0 |= Enum130.const_0;
				}
				else
				{
					this.enum130_0 &= (Enum130)(-2);
				}
			}
		}

		/// <summary>Determines whether the text of a newly added XML element is automatically selected.</summary>
		[DefaultValue(false)]
		[Browsable(false)]
		public bool AutoSelect
		{
			get
			{
				return (this.enum130_0 & Enum130.const_1) == 0;
			}
			set
			{
				if (!value)
				{
					this.enum130_0 |= Enum130.const_1;
				}
				else
				{
					this.enum130_0 &= (Enum130)(-3);
				}
			}
		}

		/// <summary>Creates an XmlElement object with the specified name.</summary>
		/// <param name="name">Specifies the element's name.</param>
		public XmlElement(string name)
		{
			this.string_0 = name;
			this.string_2 = string.Empty;
			this.string_1 = string.Empty;
		}

		/// <summary>Creates an XmlElement object with the specified name and text.</summary>
		/// <param name="name">Specifies the element's name.</param>
		/// <param name="text">Specifies the element's text.</param>
		public XmlElement(string name, string text)
		{
			this.string_0 = name;
			this.string_2 = text;
			this.string_1 = string.Empty;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal XmlElement(TextControlCore textControlCore_1, string name, string text)
		{
			this.string_0 = name;
			this.string_2 = text;
			this.string_1 = string.Empty;
			this.textControlCore_0 = textControlCore_1;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		internal XmlElement(TextControlCore textControlCore_1, string name, int occurrenceNum, string parent, int parentOccNum)
		{
			this.string_0 = name;
			this.textControlCore_0 = textControlCore_1;
			this.int_0 = occurrenceNum;
			this.string_2 = string.Empty;
			this.string_1 = parent;
			this.int_1 = parentOccNum;
		}

		/// <summary>Selects the text of the XML element. The text can only be selected, if the element belongs to the document.</summary>
		public bool Select()
		{
			bool result = false;
			if (this.textControlCore_0 != null)
			{
				Struct72 struct72_ = new Struct72(this.string_0, this.int_0, ("" == this.string_1) ? null : this.string_1, this.int_1, (uint)this.enum130_0);
				result = (int)this.textControlCore_0.method_67(Enum83.const_198, 0, ref struct72_) != 0;
			}
			return result;
		}

		/// <summary>Adds the specified XML element as a sub-element of this element. The new element is placed at the position specified through the document's DTD. If this element can have more than one child of the specified type, the before or after parameters can be used to specify a position.</summary>
		/// <param name="element">Specifies the XML element to add.</param>
		/// <param name="before">Specifies a relative position in the list of child elements of the specified type beginning with 1.</param>
		/// <param name="after">Specifies a relative position in the list of child elements of the specified type beginning with 1.</param>
		public bool AddChild(XmlElement element, int before, int after)
		{
			return this.method_0(element, before, after);
		}

		/// <summary>Adds the specified XML element as a sub-element of this element. The new element is placed at the position specified through the document's DTD.</summary>
		/// <param name="element">Specifies the XML element to add.</param>
		public bool AddChild(XmlElement element)
		{
			return this.method_0(element, -1, -1);
		}

		/// <summary>Returns the XML child element with the specified name and index.</summary>
		/// <param name="name">Specifies the name of the sub-element.</param>
		/// <param name="index">Specifies the number of the sub-element beginning with 1.</param>
		public XmlElement GetChildItem(string name, int index)
		{
			return this.method_1(name, index);
		}

		/// <summary>Returns the first XML child element with the specified name.</summary>
		/// <param name="name">Specifies the name of the sub-element.</param>
		public XmlElement GetChildItem(string name)
		{
			return this.method_1(name, 1);
		}

		/// <summary>Removes the XML child element with the specified name and index.</summary>
		/// <param name="name">Specifies the name of the sub-element to remove.</param>
		/// <param name="index">Specifies the number of the sub-element beginning with 1.</param>
		public bool RemoveChild(string name, int index)
		{
			return this.method_2(name, index);
		}

		/// <summary>Removes the first XML child element with the specified name.</summary>
		/// <param name="name">Specifies the name of the sub-element to remove.</param>
		public bool RemoveChild(string name)
		{
			return this.method_2(name, 1);
		}

		internal bool method_0(XmlElement xmlElement_0, int int_2, int int_3)
		{
			short num = 0;
			int num2 = 0;
			short num3 = 2;
			if (xmlElement_0 != null && this.textControlCore_0 != null)
			{
				if (int_2 > 0)
				{
					num3 = 1;
					num2 = int_2;
				}
				else if (int_3 > 0)
				{
					num2 = int_3;
				}
				Struct72 struct72_ = new Struct72(xmlElement_0.ElementName, num2, this.string_0, this.int_0, (uint)xmlElement_0.enum130_0, (ushort)num3);
				num = (short)this.textControlCore_0.method_68(Enum83.const_193, xmlElement_0.Text, ref struct72_);
				if (num == 2)
				{
					xmlElement_0.int_0 = ((num3 == 1) ? num2 : (num2 + 1));
					xmlElement_0.string_1 = this.string_0;
					xmlElement_0.int_1 = this.int_0;
					xmlElement_0.textControlCore_0 = this.textControlCore_0;
				}
			}
			return num == 2;
		}

		internal XmlElement method_1(string string_3, int int_2)
		{
			XmlElement result = null;
			int num = 0;
			int num2 = 1;
			if (this.string_1 != "")
			{
				Struct72 struct72_ = new Struct72(this.string_0, this.int_0, this.string_1, this.int_1, 0u);
				num = (short)(int)this.textControlCore_0.method_67(Enum83.const_200, 0, ref struct72_);
				if (num == 0)
				{
					goto IL_00ab;
				}
			}
			else
			{
				num = this.int_0;
			}
			Struct72 struct72_2 = new Struct72(string_3, 0, this.string_0, num, 0u);
			num2 = (int)this.textControlCore_0.method_67(Enum83.const_199, 0, ref struct72_2);
			if (int_2 <= num2)
			{
				result = new XmlElement(this.textControlCore_0, string_3, int_2, this.string_0, num);
			}
			goto IL_00ab;
			IL_00ab:
			return result;
		}

		internal bool method_2(string string_3, int int_2)
		{
			short num = 0;
			if (this.textControlCore_0 != null)
			{
				Struct72 struct72_ = new Struct72(string_3, int_2, this.string_0, this.int_0, 0u);
				num = (short)(int)this.textControlCore_0.method_67(Enum83.const_194, 0, ref struct72_);
			}
			return num == 2;
		}
	}
}
