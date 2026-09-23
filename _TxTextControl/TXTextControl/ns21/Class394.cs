using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using TXTextControl;

namespace ns21
{
	internal class Class394
	{
		internal enum Enum47
		{
			const_0 = 1,
			const_1
		}

		internal TextControlCore textControlCore_0;

		private Dictionary<int, FormField> dictionary_0 = new Dictionary<int, FormField>();

		private Dictionary<string, List<object[]>> dictionary_1 = new Dictionary<string, List<object[]>>();

		private Dictionary<string, List<object[]>> dictionary_2 = new Dictionary<string, List<object[]>>();

		private Dictionary<int, List<string>> dictionary_3 = new Dictionary<int, List<string>>();

		private Dictionary<int, List<string>> dictionary_4 = new Dictionary<int, List<string>>();

		private List<string> list_0 = new List<string>();

		private Dictionary<string, ConditionalInstruction> dictionary_5 = new Dictionary<string, ConditionalInstruction>();

		private Regex regex_0 = new Regex("((?<=\"A\":" + Class403.char_0 + "\").+(?=\"" + Class403.char_0 + ",\"[B1]))");

		private bool bool_0;

		private bool bool_1;

		internal bool bool_2;

		internal TextPart textPart_0 = TextPart.MainText;

		private List<FormField> list_1 = new List<FormField>();

		private List<FormField> list_2 = new List<FormField>();

		private List<FormField> list_3 = new List<FormField>();

		private List<FormField> list_4 = new List<FormField>();

		private List<FormField> list_5 = new List<FormField>();

		[CompilerGenerated]
		private bool bool_3;

		internal List<FormField> List_0 => this.list_2;

		internal Dictionary<string, ConditionalInstruction> Dictionary_0 => this.dictionary_5;

		internal List<string> List_1 => this.list_0;

		internal List<FormField> List_2 => this.list_1;

		internal Dictionary<int, FormField> Dictionary_1 => this.dictionary_0;

		internal bool Boolean_0
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

		internal bool Boolean_1
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				if (this.bool_0 == (this.bool_0 = value) || this.bool_0)
				{
					return;
				}
				foreach (FormField value2 in this.dictionary_0.Values)
				{
					this.method_11();
					if (!value2.Enabled)
					{
						value2.Enabled = true;
					}
				}
				this.method_25();
			}
		}

		internal List<FormField> List_3 => this.list_3;

		internal List<FormField> List_4 => this.list_4;

		internal List<FormField> List_5 => this.list_5;

		internal Class394(TextControlCore textControlCore_1)
		{
			this.textControlCore_0 = textControlCore_1;
		}

		internal void method_0(ConditionalInstruction conditionalInstruction_0)
		{
			string name = conditionalInstruction_0.Name;
			foreach (Condition item in conditionalInstruction_0.List_0)
			{
				this.method_48(item, this.dictionary_1, this.dictionary_3);
			}
			foreach (Instruction item2 in conditionalInstruction_0.List_1)
			{
				this.method_48(item2, this.dictionary_2, this.dictionary_4);
			}
			this.list_0.Add(name);
			if (this.Boolean_1)
			{
				this.dictionary_5.Add(name, conditionalInstruction_0);
			}
		}

		internal void method_1()
		{
			if (!this.Boolean_1)
			{
				return;
			}
			this.method_37();
			this.bool_2 = true;
			foreach (FormField value in this.dictionary_0.Values)
			{
				this.method_32(value.int_0);
			}
			this.method_33();
			this.bool_2 = false;
		}

		internal void method_2()
		{
			this.list_0.Clear();
			this.dictionary_3.Clear();
			this.dictionary_4.Clear();
			this.dictionary_5.Clear();
			this.dictionary_1.Clear();
			this.dictionary_2.Clear();
			foreach (FormField value in this.dictionary_0.Values)
			{
				value.String_2 = new string[0];
				value.String_3 = new string[0];
			}
		}

		internal void method_3(TextPart textPart_1, FormFieldCollection formFieldCollection_0)
		{
			this.textPart_0 = ((textPart_1 == TextPart.Auto) ? TextPart.MainText : textPart_1);
			this.dictionary_0.Clear();
			this.list_0.Clear();
			this.dictionary_3.Clear();
			this.dictionary_4.Clear();
			this.dictionary_5.Clear();
			this.dictionary_1.Clear();
			this.dictionary_2.Clear();
			foreach (FormField item in formFieldCollection_0)
			{
				this.dictionary_0.Add(item.int_0, item);
				item.String_2 = new string[0];
				item.String_3 = new string[0];
			}
		}

		internal ConditionalInstruction method_4(string string_0)
		{
			ConditionalInstruction conditionalInstruction = new ConditionalInstruction();
			conditionalInstruction.Name = string_0;
			ConditionalInstruction conditionalInstruction2 = conditionalInstruction;
			this.method_43(conditionalInstruction2);
			this.method_45(conditionalInstruction2);
			return conditionalInstruction2;
		}

		internal void method_5()
		{
			this.dictionary_5.Clear();
			foreach (FormField value in this.dictionary_0.Values)
			{
				this.method_30(value);
			}
			foreach (ConditionalInstruction value2 in this.dictionary_5.Values)
			{
				this.method_46(value2);
			}
		}

		internal void method_6(string string_0)
		{
			if (this.list_0.Contains(string_0))
			{
				this.method_38(string_0, this.dictionary_1, this.dictionary_3, Enum47.const_0);
				this.method_38(string_0, this.dictionary_2, this.dictionary_4, Enum47.const_1);
				this.list_0.Remove(string_0);
				if (this.Boolean_1)
				{
					this.dictionary_5.Remove(string_0);
				}
			}
		}

		internal List<object[]> method_7(string string_0, Enum47 enum47_0)
		{
			List<object[]> value = null;
			switch (enum47_0)
			{
			default:
			{
				if (!this.dictionary_1.TryGetValue(string_0, out value))
				{
					value = new List<object[]>();
				}
				List<object[]> value2 = null;
				if (this.dictionary_2.TryGetValue(string_0, out value2))
				{
					value.AddRange(value2);
				}
				break;
			}
			case Enum47.const_0:
				if (!this.dictionary_1.TryGetValue(string_0, out value))
				{
					value = new List<object[]>();
				}
				break;
			case Enum47.const_1:
				if (!this.dictionary_2.TryGetValue(string_0, out value))
				{
					value = new List<object[]>();
				}
				break;
			}
			return value;
		}

		internal List<string> method_8(FormField formField_0, Enum47 enum47_0)
		{
			List<string> value = new List<string>();
			if (formField_0 == null)
			{
				return value;
			}
			switch (enum47_0)
			{
			default:
			{
				List<string> list = new List<string>();
				if (this.dictionary_3.TryGetValue(formField_0.int_0, out value))
				{
					list.AddRange(value);
				}
				if (this.dictionary_4.TryGetValue(formField_0.int_0, out value))
				{
					for (int i = 0; i < value.Count; i++)
					{
						string item = value[i];
						if (!list.Contains(item))
						{
							list.Add(item);
						}
					}
				}
				return list;
			}
			case Enum47.const_0:
				if (!this.dictionary_3.TryGetValue(formField_0.int_0, out value))
				{
					return new List<string>();
				}
				break;
			case Enum47.const_1:
				if (!this.dictionary_4.TryGetValue(formField_0.int_0, out value))
				{
					return new List<string>();
				}
				break;
			}
			return value;
		}

		internal bool method_9(TextPart textPart_1)
		{
			return this.textPart_0 == ((textPart_1 == TextPart.Auto) ? TextPart.MainText : textPart_1);
		}

		internal bool method_10(Instruction instruction_0)
		{
			if ((!instruction_0.IsInitialInstruction && this.bool_2) || (!instruction_0.IsFormFieldChangeInstruction && !this.bool_2))
			{
				return false;
			}
			return true;
		}

		internal static bool smethod_0(string string_0)
		{
			if (string.IsNullOrEmpty(string_0))
			{
				return false;
			}
			try
			{
				new Regex(string_0);
			}
			catch (ArgumentException ex)
			{
				_ = ex.Message;
				return false;
			}
			return true;
		}

		internal void method_11()
		{
			if (!this.bool_1)
			{
				this.bool_1 = true;
				this.textControlCore_0.method_21(TextPart.Auto);
			}
		}

		internal void method_12(TextPart textPart_1)
		{
			this.method_24(textPart_1);
			this.method_23();
		}

		internal void method_13(FormFieldCollection formFieldCollection_0, TextPart textPart_1)
		{
			this.method_24(textPart_1);
			this.method_19(formFieldCollection_0);
			this.method_1();
		}

		internal bool method_14(int int_0)
		{
			this.method_37();
			this.method_32(int_0);
			return this.method_33();
		}

		internal void method_15(FormField formField_0)
		{
			if (formField_0 == null || this.dictionary_0.ContainsKey(formField_0.GetHashCode()))
			{
				return;
			}
			this.dictionary_0.Add(formField_0.int_0, formField_0);
			this.method_44(formField_0.int_0, this.dictionary_3, this.dictionary_1, (formField_0.String_2 == null) ? new string[0] : formField_0.String_2);
			this.method_44(formField_0.int_0, this.dictionary_4, this.dictionary_2, (formField_0.String_3 == null) ? new string[0] : formField_0.String_3);
			if (!this.Boolean_1)
			{
				return;
			}
			List<ConditionalInstruction> list = this.method_30(formField_0);
			foreach (ConditionalInstruction item in list)
			{
				this.method_46(item);
			}
		}

		internal void method_16(int int_0)
		{
			this.dictionary_0.Remove(int_0);
			if (this.Boolean_1)
			{
				List<ConditionalInstruction> list = new List<ConditionalInstruction>();
				List<string> value = null;
				if (this.dictionary_3.TryGetValue(int_0, out value))
				{
					for (int i = 0; i < value.Count; i++)
					{
						string text = value[i];
						ConditionalInstruction conditionalInstruction = this.dictionary_5[text];
						for (int num = conditionalInstruction.List_0.Count - 1; num >= 0; num--)
						{
							if (((IConditionalInstructionElement)conditionalInstruction.List_0[num]).ConditionalInstructionName == text)
							{
								conditionalInstruction.List_0.RemoveAt(num);
							}
						}
						list.Add(conditionalInstruction);
					}
				}
				if (this.dictionary_4.TryGetValue(int_0, out value))
				{
					for (int j = 0; j < value.Count; j++)
					{
						string text2 = value[j];
						ConditionalInstruction conditionalInstruction2 = this.dictionary_5[text2];
						for (int num2 = conditionalInstruction2.List_1.Count - 1; num2 >= 0; num2--)
						{
							if (((IConditionalInstructionElement)conditionalInstruction2.List_1[num2]).ConditionalInstructionName == text2)
							{
								conditionalInstruction2.List_1.RemoveAt(num2);
							}
						}
						list.Add(conditionalInstruction2);
					}
				}
				foreach (ConditionalInstruction item in list)
				{
					if (item.List_1.Count == 0 && item.List_0.Count == 0)
					{
						this.dictionary_5.Remove(item.Name);
					}
				}
			}
			this.method_40(int_0, ref this.dictionary_1);
			this.method_40(int_0, ref this.dictionary_2);
			this.dictionary_3.Remove(int_0);
			this.dictionary_4.Remove(int_0);
			this.method_47();
		}

		internal void method_17(FormFieldCollection formFieldCollection_0, TextPart textPart_1)
		{
			this.method_24(textPart_1);
			this.method_19(formFieldCollection_0);
			this.method_1();
		}

		internal void method_18(TextPart textPart_1, FormFieldCollection formFieldCollection_0)
		{
			if (!this.method_9(textPart_1))
			{
				this.method_24(textPart_1);
				this.method_19(formFieldCollection_0);
				this.method_1();
			}
		}

		internal void method_19(FormFieldCollection formFieldCollection_0)
		{
			this.method_23();
			foreach (FormField item in formFieldCollection_0)
			{
				this.dictionary_0.Add(item.int_0, item);
				this.method_44(item.int_0, this.dictionary_3, this.dictionary_1, (item.String_2 == null) ? new string[0] : item.String_2);
				this.method_44(item.int_0, this.dictionary_4, this.dictionary_2, (item.String_3 == null) ? new string[0] : item.String_3);
			}
			if (this.Boolean_1)
			{
				this.method_5();
			}
		}

		internal void method_20(ConditionalInstruction[] conditionalInstruction_0, FormFieldCollection formFieldCollection_0)
		{
			this.method_23();
			foreach (ConditionalInstruction conditionalInstruction_ in conditionalInstruction_0)
			{
				this.method_0(conditionalInstruction_);
			}
			this.method_28(formFieldCollection_0);
		}

		internal bool method_21(FormField formField_0)
		{
			if (this.dictionary_0.ContainsKey(formField_0.int_0))
			{
				this.dictionary_0[formField_0.int_0] = formField_0;
				return true;
			}
			return false;
		}

		internal void method_22(string string_0, string string_1, FormFieldCollection formFieldCollection_0)
		{
			if (!this.list_0.Contains(string_0))
			{
				return;
			}
			List<int> list = new List<int>();
			if (this.dictionary_1.TryGetValue(string_0, out var value))
			{
				foreach (object[] item in value)
				{
					int num = (int)item[0];
					if (!list.Contains(num))
					{
						list.Add(num);
						this.method_41(this.dictionary_0[num], string_0, string_1);
					}
				}
			}
			if (this.dictionary_2.TryGetValue(string_0, out var value2))
			{
				foreach (object[] item2 in value2)
				{
					int num2 = (int)item2[0];
					if (!list.Contains(num2))
					{
						list.Add(num2);
						this.method_41(this.dictionary_0[num2], string_0, string_1);
					}
				}
			}
			this.method_19(formFieldCollection_0);
		}

		internal void method_23()
		{
			this.dictionary_0.Clear();
			this.list_0.Clear();
			this.dictionary_3.Clear();
			this.dictionary_4.Clear();
			this.dictionary_5.Clear();
			this.dictionary_1.Clear();
			this.dictionary_2.Clear();
			this.list_5.Clear();
		}

		internal void method_24(TextPart textPart_1)
		{
			this.textPart_0 = ((textPart_1 == TextPart.Auto) ? TextPart.MainText : textPart_1);
		}

		internal bool method_25()
		{
			if (this.bool_1)
			{
				this.bool_1 = false;
				this.textControlCore_0.method_22(TextPart.Auto);
				return true;
			}
			return false;
		}

		internal void method_26(string string_0, Dictionary<int, List<string>> dictionary_6)
		{
			foreach (FormField value2 in this.dictionary_0.Values)
			{
				List<string> list = new List<string>();
				string[] array = ((value2.String_2 == null) ? new string[0] : value2.String_2);
				bool flag = false;
				string[] array2 = array;
				foreach (string text in array2)
				{
					if (this.method_34(text) != string_0)
					{
						list.Add(text);
					}
					else
					{
						flag = true;
					}
				}
				if (!dictionary_6.TryGetValue(value2.int_0, out var value))
				{
					value = new List<string>();
				}
				if (value.Count > 0 || flag)
				{
					value.AddRange(list);
					value2.String_2 = value.ToArray();
				}
			}
		}

		internal void method_27(string string_0, Dictionary<int, List<string>> dictionary_6)
		{
			foreach (FormField value2 in this.dictionary_0.Values)
			{
				List<string> list = new List<string>();
				string[] array = ((value2.String_3 == null) ? new string[0] : value2.String_3);
				bool flag = false;
				string[] array2 = array;
				foreach (string text in array2)
				{
					if (this.method_34(text) != string_0)
					{
						list.Add(text);
					}
					else
					{
						flag = true;
					}
				}
				if (!dictionary_6.TryGetValue(value2.int_0, out var value))
				{
					value = new List<string>();
				}
				if (value.Count > 0 || flag)
				{
					value.AddRange(list);
					value2.String_3 = value.ToArray();
				}
			}
		}

		internal void method_28(FormFieldCollection formFieldCollection_0)
		{
			foreach (FormField item in formFieldCollection_0)
			{
				int int_ = item.int_0;
				this.dictionary_0.Add(int_, item);
				item.String_2 = this.method_36(int_, this.dictionary_3, this.dictionary_1);
				item.String_3 = this.method_36(int_, this.dictionary_4, this.dictionary_2);
			}
		}

		private ConditionalInstruction method_29(FormField formField_0, string string_0)
		{
			IConditionalInstructionElement conditionalInstructionElement = Class403.smethod_4<Condition>(string_0);
			conditionalInstructionElement.RelatedFormField.FormField_0 = formField_0;
			string conditionalInstructionName = conditionalInstructionElement.ConditionalInstructionName;
			ConditionalInstruction value = null;
			if (!this.dictionary_5.TryGetValue(conditionalInstructionName, out value))
			{
				value = new ConditionalInstruction();
				value.Name = conditionalInstructionName;
				this.dictionary_5.Add(conditionalInstructionName, value);
			}
			value.List_0.Add(conditionalInstructionElement as Condition);
			return value;
		}

		private List<ConditionalInstruction> method_30(FormField formField_0)
		{
			List<ConditionalInstruction> list = new List<ConditionalInstruction>();
			ConditionalInstruction conditionalInstruction = null;
			string[] array = ((formField_0.String_2 == null) ? new string[0] : formField_0.String_2);
			if (array != null && array.Length > 0)
			{
				foreach (string string_ in array)
				{
					if (!list.Contains(conditionalInstruction = this.method_29(formField_0, string_)))
					{
						list.Add(conditionalInstruction);
					}
				}
			}
			string[] array2 = ((formField_0.String_3 == null) ? new string[0] : formField_0.String_3);
			if (array2 != null && array2.Length > 0)
			{
				foreach (string string_2 in array2)
				{
					if (!list.Contains(conditionalInstruction = this.method_31(formField_0, string_2)))
					{
						list.Add(conditionalInstruction);
					}
				}
			}
			return list;
		}

		private ConditionalInstruction method_31(FormField formField_0, string string_0)
		{
			IConditionalInstructionElement conditionalInstructionElement = Class403.smethod_4<Instruction>(string_0);
			conditionalInstructionElement.RelatedFormField.FormField_0 = formField_0;
			string conditionalInstructionName = conditionalInstructionElement.ConditionalInstructionName;
			ConditionalInstruction value = null;
			if (!this.dictionary_5.TryGetValue(conditionalInstructionName, out value))
			{
				value = new ConditionalInstruction();
				value.Name = conditionalInstructionName;
				this.dictionary_5.Add(conditionalInstructionName, value);
			}
			value.List_1.Add(conditionalInstructionElement as Instruction);
			return value;
		}

		private void method_32(int int_0)
		{
			if (!this.dictionary_3.TryGetValue(int_0, out var value))
			{
				return;
			}
			List<ConditionalInstruction> list = new List<ConditionalInstruction>();
			foreach (string item in value)
			{
				if (this.dictionary_5.TryGetValue(item, out var value2))
				{
					list.Add(value2);
				}
			}
			list.Sort(new Class393(int_0));
			foreach (ConditionalInstruction item2 in list)
			{
				if (item2.Boolean_0)
				{
					item2.method_0(this);
				}
				else
				{
					item2.method_1(this);
				}
			}
		}

		private bool method_33()
		{
			foreach (FormField item in this.list_1)
			{
				this.list_2.Remove(item);
				if (item.Enabled)
				{
					this.method_11();
					item.Enabled = false;
				}
			}
			foreach (FormField item2 in this.list_2)
			{
				if (!item2.Enabled)
				{
					this.method_11();
					item2.Enabled = true;
				}
			}
			this.list_1.Clear();
			this.list_2.Clear();
			foreach (FormField item3 in this.list_3)
			{
				if (this.list_5.Contains(item3))
				{
					this.list_5.Remove(item3);
				}
			}
			foreach (FormField item4 in this.list_4)
			{
				if (!this.list_5.Contains(item4))
				{
					this.list_5.Add(item4);
				}
			}
			this.list_3.Clear();
			this.list_4.Clear();
			return this.method_25();
		}

		private string method_34(string string_0)
		{
			return this.regex_0.Match(string_0).Value;
		}

		private string[] method_35(int int_0, string[] string_0, Dictionary<string, List<object[]>> dictionary_6)
		{
			List<string> list = new List<string>();
			for (int i = 0; i < string_0.Length; i++)
			{
				string text = this.method_34(string_0[i]);
				if (!list.Contains(text))
				{
					list.Add(text);
				}
				object[] item = new object[2]
				{
					int_0,
					string_0[i]
				};
				if (!dictionary_6.TryGetValue(text, out var value))
				{
					value = new List<object[]>();
					dictionary_6.Add(text, value);
				}
				value.Add(item);
			}
			return list.ToArray();
		}

		private string[] method_36(int int_0, Dictionary<int, List<string>> dictionary_6, Dictionary<string, List<object[]>> dictionary_7)
		{
			List<string> list = new List<string>();
			if (dictionary_6.TryGetValue(int_0, out var value))
			{
				foreach (string item in value)
				{
					if (!dictionary_7.TryGetValue(item, out var value2))
					{
						value2 = new List<object[]>();
					}
					foreach (object[] item2 in value2)
					{
						if ((int)item2[0] == int_0)
						{
							list.Add(item2[1].ToString());
						}
					}
				}
			}
			return list.ToArray();
		}

		private void method_37()
		{
			this.list_2.Clear();
			this.list_1.Clear();
			this.list_3.Clear();
			this.list_4.Clear();
		}

		private void method_38(string string_0, Dictionary<string, List<object[]>> dictionary_6, Dictionary<int, List<string>> dictionary_7, Enum47 enum47_0)
		{
			if (!dictionary_6.TryGetValue(string_0, out var value))
			{
				return;
			}
			dictionary_6.Remove(string_0);
			List<int> list = new List<int>();
			foreach (object[] item2 in value)
			{
				int item;
				if (!list.Contains(item = (int)item2[0]))
				{
					list.Add(item);
				}
			}
			foreach (int item3 in list)
			{
				dictionary_7[item3].Remove(string_0);
				FormField formField = this.dictionary_0[item3];
				if (enum47_0 == Enum47.const_0)
				{
					formField.String_2 = this.method_39(string_0, (formField.String_2 == null) ? new string[0] : formField.String_2);
					continue;
				}
				formField.String_3 = this.method_39(string_0, (formField.String_3 == null) ? new string[0] : formField.String_3);
				this.method_11();
				if (!formField.Enabled)
				{
					formField.Enabled = true;
				}
			}
			this.method_25();
		}

		private string[] method_39(string string_0, string[] string_1)
		{
			List<string> list = new List<string>();
			foreach (string text in string_1)
			{
				string text2 = this.method_34(text);
				if (text2 != string_0)
				{
					list.Add(text);
				}
			}
			return list.ToArray();
		}

		private void method_40(int int_0, ref Dictionary<string, List<object[]>> dictionary_6)
		{
			Dictionary<string, List<object[]>> dictionary = new Dictionary<string, List<object[]>>();
			foreach (KeyValuePair<string, List<object[]>> item in dictionary_6)
			{
				List<object[]> list = new List<object[]>();
				foreach (object[] item2 in item.Value)
				{
					if ((int)item2[0] != int_0)
					{
						list.Add(item2);
					}
				}
				if (list.Count > 0)
				{
					dictionary.Add(item.Key, list);
				}
			}
			dictionary_6 = dictionary;
		}

		private void method_41(FormField formField_0, string string_0, string string_1)
		{
			if (formField_0.String_2 != null)
			{
				List<string> list = new List<string>();
				string[] string_2 = formField_0.String_2;
				foreach (string string_3 in string_2)
				{
					list.Add(this.method_42(string_3, string_0, string_1));
				}
				formField_0.String_2 = list.ToArray();
			}
			if (formField_0.String_3 != null)
			{
				List<string> list2 = new List<string>();
				string[] string_4 = formField_0.String_3;
				foreach (string string_5 in string_4)
				{
					list2.Add(this.method_42(string_5, string_0, string_1));
				}
				formField_0.String_3 = list2.ToArray();
			}
		}

		private string method_42(string string_0, string string_1, string string_2)
		{
			Match match = this.regex_0.Match(string_0);
			if (match.Value == string_1)
			{
				return string_0.Substring(0, match.Index) + string_2 + string_0.Substring(match.Index + match.Length);
			}
			return string_0;
		}

		private void method_43(ConditionalInstruction conditionalInstruction_0)
		{
			if (!this.dictionary_1.TryGetValue(conditionalInstruction_0.Name, out var value))
			{
				value = new List<object[]>();
			}
			foreach (object[] item in value)
			{
				IConditionalInstructionElement conditionalInstructionElement = Class403.smethod_4<Condition>(item[1].ToString());
				if (this.dictionary_0.TryGetValue((int)item[0], out var _))
				{
					conditionalInstructionElement.RelatedFormField.FormField_0 = this.dictionary_0[(int)item[0]];
					conditionalInstruction_0.List_0.Add(conditionalInstructionElement as Condition);
					continue;
				}
				string text = "";
				foreach (int key in this.dictionary_0.Keys)
				{
					text = text + key + ", ";
				}
				throw new ArgumentException("Key: " + (int)item[0] + ", Keys.Count: " + this.dictionary_0.Keys.Count + ", Keys: " + text);
			}
			conditionalInstruction_0.List_0.Sort();
			for (int i = 0; i < conditionalInstruction_0.List_0.Count; i++)
			{
				conditionalInstruction_0.List_0[i].Int32_0 = i;
			}
		}

		private void method_44(int int_0, Dictionary<int, List<string>> dictionary_6, Dictionary<string, List<object[]>> dictionary_7, string[] string_0)
		{
			string[] array = this.method_35(int_0, string_0, dictionary_7);
			if (array.Length <= 0)
			{
				return;
			}
			List<string> list = new List<string>();
			list.AddRange(array);
			dictionary_6.Add(int_0, list);
			string[] array2 = array;
			foreach (string item in array2)
			{
				if (!this.list_0.Contains(item))
				{
					this.list_0.Add(item);
				}
			}
		}

		private void method_45(ConditionalInstruction conditionalInstruction_0)
		{
			if (!this.dictionary_2.TryGetValue(conditionalInstruction_0.Name, out var value))
			{
				value = new List<object[]>();
			}
			foreach (object[] item in value)
			{
				IConditionalInstructionElement conditionalInstructionElement = Class403.smethod_4<Instruction>(item[1].ToString());
				conditionalInstructionElement.RelatedFormField.FormField_0 = this.dictionary_0[(int)item[0]];
				conditionalInstruction_0.List_1.Add(conditionalInstructionElement as Instruction);
			}
			conditionalInstruction_0.List_1.Sort();
		}

		private void method_46(ConditionalInstruction conditionalInstruction_0)
		{
			conditionalInstruction_0.List_0.Sort();
			for (int i = 0; i < conditionalInstruction_0.List_0.Count; i++)
			{
				conditionalInstruction_0.List_0[i].Int32_0 = i;
			}
			conditionalInstruction_0.List_1.Sort();
		}

		private void method_47()
		{
			this.list_0.Clear();
			foreach (List<string> value in this.dictionary_3.Values)
			{
				for (int i = 0; i < value.Count; i++)
				{
					string item = value[i];
					if (!this.list_0.Contains(item))
					{
						this.list_0.Add(item);
					}
				}
			}
			foreach (List<string> value2 in this.dictionary_4.Values)
			{
				for (int j = 0; j < value2.Count; j++)
				{
					string item2 = value2[j];
					if (!this.list_0.Contains(item2))
					{
						this.list_0.Add(item2);
					}
				}
			}
		}

		private void method_48(IConditionalInstructionElement iconditionalInstructionElement_0, Dictionary<string, List<object[]>> dictionary_6, Dictionary<int, List<string>> dictionary_7)
		{
			object[] item = new object[2]
			{
				iconditionalInstructionElement_0.RelatedFormField.Int32_0,
				iconditionalInstructionElement_0.ToJson()
			};
			if (!dictionary_6.TryGetValue(iconditionalInstructionElement_0.ConditionalInstructionName, out var value))
			{
				value = new List<object[]>();
				dictionary_6.Add(iconditionalInstructionElement_0.ConditionalInstructionName, value);
			}
			value.Add(item);
			if (!dictionary_7.TryGetValue(iconditionalInstructionElement_0.RelatedFormField.Int32_0, out var value2))
			{
				value2 = new List<string>();
				dictionary_7.Add(iconditionalInstructionElement_0.RelatedFormField.Int32_0, value2);
			}
			if (!value2.Contains(iconditionalInstructionElement_0.ConditionalInstructionName))
			{
				value2.Add(iconditionalInstructionElement_0.ConditionalInstructionName);
			}
		}
	}
}
