using System;
using TXTextControl;

namespace ns21
{
	internal class Class403
	{
		private static int int_0;

		private static int int_1;

		private static int int_2;

		private static int int_3;

		internal static char char_0;

		private static char char_1;

		static Class403()
		{
			Class403.char_0 = '\u001f';
			Class403.char_1 = '\u001d';
			Class403.int_0 = Enum.GetNames(typeof(ValueTypes)).Length;
			Class403.int_1 = Enum.GetNames(typeof(Condition.LogicalConnectives)).Length;
			Class403.int_2 = Enum.GetNames(typeof(LogicalOperators)).Length;
			Class403.int_3 = Enum.GetNames(typeof(Commands)).Length;
		}

		internal static string smethod_0(IConditionalInstructionElement iconditionalInstructionElement_0)
		{
			string text = "{\"A\":" + Class403.char_0 + "\"" + iconditionalInstructionElement_0.ConditionalInstructionName + "\"" + Class403.char_0 + ",";
			object obj = text;
			text = string.Concat(obj, "\"B\":", Class403.char_0, (int)iconditionalInstructionElement_0.RelatedFormField.FormFieldType_0, Class403.char_0, ",");
			if (iconditionalInstructionElement_0 is Condition)
			{
				text += Class403.smethod_1(iconditionalInstructionElement_0 as Condition);
			}
			else if (iconditionalInstructionElement_0 is Instruction)
			{
				text += Class403.smethod_2(iconditionalInstructionElement_0 as Instruction);
			}
			return text + "}";
		}

		private static string smethod_1(Condition condition_0)
		{
			string text = "\"1\":" + Class403.char_0;
			text += ((condition_0.String_0 == null) ? ("null" + Class403.char_0 + ",") : ("\"" + condition_0.String_0 + "\"" + Class403.char_0 + ","));
			object obj = text;
			text = string.Concat(obj, "\"2\":", Class403.char_0, (int)condition_0.ValueTypes_0, Class403.char_0, ",");
			object obj2 = text;
			text = string.Concat(obj2, "\"3\":", Class403.char_0, condition_0.Int32_0, Class403.char_0, ",");
			object obj3 = text;
			text = string.Concat(obj3, "\"4\":", Class403.char_0, (int)condition_0.LogicalConnective, Class403.char_0, ",");
			object obj4 = text;
			return string.Concat(obj4, "\"5\":", Class403.char_0, (int)condition_0.LogicalOperators_0, Class403.char_0, ",");
		}

		private static string smethod_2(Instruction instruction_0)
		{
			string text = "\"1\":" + Class403.char_0;
			if (instruction_0.String_0 == null)
			{
				object obj = text;
				text = string.Concat(obj, "null", Class403.char_0, ",");
			}
			else
			{
				object obj2 = text;
				text = string.Concat(obj2, Class403.smethod_3(instruction_0.String_0, instruction_0), Class403.char_0, ",");
			}
			object obj3 = text;
			text = string.Concat(obj3, "\"2\":", Class403.char_0, (int)instruction_0.Commands_0, Class403.char_0, ",");
			object obj4 = text;
			text = string.Concat(obj4, "\"3\":", Class403.char_0, (int)instruction_0.ValueTypes_0, Class403.char_0, ",");
			object obj5 = text;
			text = string.Concat(obj5, "\"4\":", Class403.char_0, instruction_0.IsElseInstructionEnabled, Class403.char_0, ",");
			object obj6 = text;
			text = string.Concat(obj6, "\"5\":", Class403.char_0, Class403.smethod_3(instruction_0.ElseInstructionValue, instruction_0), Class403.char_0, ",");
			object obj7 = text;
			text = string.Concat(obj7, "\"6\":", Class403.char_0, instruction_0.IsInitialInstruction, Class403.char_0, ",");
			object obj8 = text;
			return string.Concat(obj8, "\"7\":", Class403.char_0, instruction_0.IsFormFieldChangeInstruction, Class403.char_0, ",");
		}

		private static string smethod_3(object object_0, Instruction instruction_0)
		{
			if (object_0 == null)
			{
				return "null";
			}
			Type type = object_0.GetType();
			switch (type.Name)
			{
			case "DateTime":
				return ((DateTime)object_0).Ticks.ToString();
			case "Boolean":
				return object_0.ToString();
			case "String[]":
			{
				string[] array = (string[])object_0;
				string text = "[";
				for (int i = 0; i < array.Length - 1; i++)
				{
					object obj = text;
					text = string.Concat(obj, "\"", array[i], "\"", Class403.char_1);
				}
				if (array.Length > 0)
				{
					text = text + "\"" + array[array.Length - 1] + "\"";
				}
				return text + "]";
			}
			default:
				return "\"" + object_0.ToString() + "\"";
			}
		}

		internal static IConditionalInstructionElement smethod_4<T>(string string_0)
		{
			IConditionalInstructionElement conditionalInstructionElement = null;
			int int_ = 0;
			switch (typeof(T).Name)
			{
			case "Instruction":
				conditionalInstructionElement = new Instruction();
				Class403.smethod_5(string_0, ref int_, "", conditionalInstructionElement);
				break;
			case "Condition":
				conditionalInstructionElement = new Condition();
				Class403.smethod_5(string_0, ref int_, "", conditionalInstructionElement);
				break;
			}
			return conditionalInstructionElement;
		}

		private static void smethod_5(string string_0, ref int int_4, string string_1, IConditionalInstructionElement iconditionalInstructionElement_0)
		{
			if (int_4 >= string_0.Length)
			{
				return;
			}
			char c = string_0[int_4];
			switch (c)
			{
			case '{':
				int_4++;
				string_1 = "";
				Class403.smethod_5(string_0, ref int_4, string_1, iconditionalInstructionElement_0);
				break;
			default:
				int_4++;
				string_1 += c;
				Class403.smethod_5(string_0, ref int_4, string_1, iconditionalInstructionElement_0);
				break;
			case '}':
				int_4++;
				string_1 = "";
				Class403.smethod_5(string_0, ref int_4, string_1, iconditionalInstructionElement_0);
				break;
			case ':':
				if (iconditionalInstructionElement_0 is Condition)
				{
					Class403.smethod_6(string_0, ref int_4, string_1, iconditionalInstructionElement_0 as Condition);
				}
				else if (iconditionalInstructionElement_0 is Instruction)
				{
					Class403.smethod_7(string_0, ref int_4, string_1, iconditionalInstructionElement_0 as Instruction);
				}
				Class403.smethod_5(string_0, ref int_4, "", iconditionalInstructionElement_0);
				break;
			}
		}

		private static void smethod_6(string string_0, ref int int_4, string string_1, Condition condition_0)
		{
			string text = ((string_1[0] == Class403.char_0) ? string_1.Substring(3, 1) : string_1.Substring(1, string_1.Length - 2));
			int_4++;
			string text2;
			if (string_0[int_4] == Class403.char_0)
			{
				int_4++;
				text2 = Class403.smethod_9(string_0, ref int_4, "");
			}
			else
			{
				text2 = Class403.smethod_10(string_0, ref int_4, "", bool_0: false);
			}
			switch (text)
			{
			case "A":
				if (text2.StartsWith("\"") && text2.EndsWith("\""))
				{
					((IConditionalInstructionElement)condition_0).ConditionalInstructionName = text2.Substring(1, text2.Length - 2);
					break;
				}
				throw new InvalidCastException("Condition.ConditionalInstructionName is invalid.");
			case "B":
			{
				if (int.TryParse(text2, out var result5))
				{
					((IConditionalInstructionElement)condition_0).RelatedFormField.FormFieldType_0 = (FormFieldType)result5;
					break;
				}
				throw new InvalidCastException("IConditionalInstructionElement.RelatedFormField.Type is invalid.");
			}
			case "1":
				if (text2 == "null")
				{
					condition_0.String_0 = null;
					break;
				}
				if (text2.StartsWith("\"") && text2.EndsWith("\""))
				{
					condition_0.String_0 = text2.Substring(1, text2.Length - 2);
					break;
				}
				throw new InvalidCastException("Condition.ComparisonValue is invalid.");
			case "2":
			{
				if (int.TryParse(text2, out var result4) && result4 < Class403.int_0)
				{
					condition_0.ValueTypes_0 = (ValueTypes)result4;
					break;
				}
				throw new InvalidCastException("Condition.ComparisonValueType is invalid.");
			}
			case "3":
			{
				if (int.TryParse(text2, out var result2))
				{
					condition_0.Int32_0 = result2;
					break;
				}
				throw new InvalidCastException("Condition.Index is invalid.");
			}
			case "4":
			{
				if (int.TryParse(text2, out var result3) && result3 < Class403.int_1)
				{
					condition_0.LogicalConnective = (Condition.LogicalConnectives)result3;
					break;
				}
				throw new InvalidCastException("Condition.ComparisonValue is invalid.");
			}
			case "5":
			{
				if (int.TryParse(text2, out var result) && result < Class403.int_2)
				{
					condition_0.LogicalOperators_0 = (LogicalOperators)result;
					break;
				}
				throw new InvalidCastException("Condition.ComparisonValue is invalid.");
			}
			}
		}

		private static void smethod_7(string string_0, ref int int_4, string string_1, Instruction instruction_0)
		{
			string text = ((string_1[0] == Class403.char_0) ? string_1.Substring(3, 1) : string_1.Substring(1, string_1.Length - 2));
			int_4++;
			string text2;
			if (string_0[int_4] == Class403.char_0)
			{
				int_4++;
				text2 = Class403.smethod_9(string_0, ref int_4, "");
			}
			else
			{
				text2 = Class403.smethod_10(string_0, ref int_4, "", bool_0: false);
			}
			switch (text)
			{
			case "A":
				if (text2.StartsWith("\"") && text2.EndsWith("\""))
				{
					((IConditionalInstructionElement)instruction_0).ConditionalInstructionName = text2.Substring(1, text2.Length - 2);
					break;
				}
				throw new InvalidCastException("Instruction.ConditionalInstructionName is invalid.");
			case "B":
			{
				if (int.TryParse(text2, out var result3))
				{
					((IConditionalInstructionElement)instruction_0).RelatedFormField.FormFieldType_0 = (FormFieldType)result3;
					break;
				}
				throw new InvalidCastException("IConditionalInstructionElement.RelatedFormField.Type is invalid.");
			}
			case "1":
				if (text2 == "null")
				{
					instruction_0.String_0 = null;
					break;
				}
				if (text2.StartsWith("[") && text2.EndsWith("]"))
				{
					instruction_0.String_0 = Class403.smethod_8(text2);
					break;
				}
				throw new InvalidCastException("Instruction.InstructionParameters is invalid.");
			case "2":
			{
				if (int.TryParse(text2, out var result5) && result5 < Class403.int_3)
				{
					instruction_0.Commands_0 = (Commands)result5;
					break;
				}
				throw new InvalidCastException("Instruction.Command is invalid.");
			}
			case "3":
			{
				if (int.TryParse(text2, out var result6) && result6 < Class403.int_0)
				{
					instruction_0.ValueTypes_0 = (ValueTypes)result6;
					break;
				}
				throw new InvalidCastException("Instruction.ValueType is invalid.");
			}
			case "4":
			{
				if (bool.TryParse(text2, out var result2))
				{
					instruction_0.IsElseInstructionEnabled = result2;
					break;
				}
				throw new InvalidCastException("Instruction.IsElseInstructionEnabled is invalid.");
			}
			case "5":
				if (text2 == "null")
				{
					instruction_0.ElseInstructionValue = null;
					break;
				}
				switch (instruction_0.Commands_0)
				{
				case Commands.SetNewValue:
					switch (((IConditionalInstructionElement)instruction_0).RelatedFormField.FormFieldType_0)
					{
					default:
						instruction_0.ElseInstructionValue = text2.Substring(1, text2.Length - 2);
						break;
					case FormFieldType.DateFormField:
					{
						if (long.TryParse(text2, out var result9))
						{
							instruction_0.ElseInstructionValue = new DateTime(result9);
							break;
						}
						throw new InvalidCastException("Instruction.ElseInstructionValue is invalid.");
					}
					case FormFieldType.CheckBoxFormField:
					{
						if (bool.TryParse(text2, out var result8))
						{
							instruction_0.ElseInstructionValue = result8;
							break;
						}
						throw new InvalidCastException("Instruction.ElseInstructionValue is invalid.");
					}
					}
					break;
				case Commands.SetNewItems:
					if (text2.StartsWith("[") && text2.EndsWith("]"))
					{
						instruction_0.ElseInstructionValue = Class403.smethod_8(text2);
						break;
					}
					throw new InvalidCastException("Instruction.ElseInstructionValue is invalid.");
				case Commands.AllowFillIn:
				case Commands.DenyFillIn:
				case Commands.SetValueAsValid:
				case Commands.SetValueAsInvalid:
				{
					if (bool.TryParse(text2, out var result7))
					{
						instruction_0.ElseInstructionValue = result7;
						break;
					}
					throw new InvalidCastException("Instruction.ElseInstructionValue is invalid.");
				}
				}
				break;
			case "6":
			{
				if (bool.TryParse(text2, out var result4))
				{
					instruction_0.IsInitialInstruction = result4;
					break;
				}
				throw new InvalidCastException("Instruction.IsInitialInstruction is invalid.");
			}
			case "7":
			{
				if (bool.TryParse(text2, out var result))
				{
					instruction_0.IsFormFieldChangeInstruction = result;
					break;
				}
				throw new InvalidCastException("Instruction.IsFormFieldChangeInstruction is invalid.");
			}
			}
		}

		private static string[] smethod_8(string string_0)
		{
			string[] array = string_0.Substring(1, string_0.Length - 2).Split(new char[1] { Class403.char_1 }, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = array[i].Substring(1, array[i].Length - 2);
			}
			return array;
		}

		private static string smethod_9(string string_0, ref int int_4, string string_1)
		{
			if (int_4 < string_0.Length)
			{
				char c = string_0[int_4];
				if (c == Class403.char_0)
				{
					return string_1;
				}
				string_1 += c;
				int_4++;
				return Class403.smethod_9(string_0, ref int_4, string_1);
			}
			return null;
		}

		private static string smethod_10(string string_0, ref int int_4, string string_1, bool bool_0)
		{
			if (int_4 < string_0.Length)
			{
				char c = string_0[int_4];
				switch (c)
				{
				case '\u001d':
					int_4++;
					string_1 += c;
					return Class403.smethod_10(string_0, ref int_4, string_1, bool_0);
				case ',':
				case '}':
					int_4++;
					return string_1;
				case '[':
					bool_0 = true;
					string_1 += c;
					int_4++;
					return Class403.smethod_10(string_0, ref int_4, string_1, bool_0: true);
				default:
					string_1 += c;
					int_4++;
					return Class403.smethod_10(string_0, ref int_4, string_1, bool_0);
				case ']':
					bool_0 = false;
					string_1 += c;
					int_4++;
					return Class403.smethod_10(string_0, ref int_4, string_1, bool_0: false);
				}
			}
			return null;
		}
	}
}
