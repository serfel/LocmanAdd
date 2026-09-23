using System;
using System.Collections.Generic;
using System.Resources;
using System.Runtime.CompilerServices;
using ns21;
using ns22;

namespace TXTextControl
{
	/// <summary>An object of the ConditionalInstruction class represents a list of form field related instructions that are executed when specific requirements, represented by an array of conditions, are fulfilled.</summary>
	public class ConditionalInstruction
	{
		private List<Condition> list_0 = new List<Condition>();

		private List<Instruction> list_1 = new List<Instruction>();

		private string string_0;

		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private bool bool_0 = true;

		[CompilerGenerated]
		private int int_0;

		[CompilerGenerated]
		private ConditionalInstructionCollection conditionalInstructionCollection_0;

		public bool AreElseInstructionsHandled
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}

		/// <summary>Gets or sets an array of conditions, that represent the requirements that has to be fulfilled to execute the specified instructions.</summary>
		public Condition[] Conditions
		{
			get
			{
				return this.list_0.ToArray();
			}
			set
			{
				if (value != null && value.Length != 0)
				{
					this.list_0.Clear();
					int num = 0;
					while (true)
					{
						if (num < value.Length)
						{
							Condition condition = value[num];
							if (condition != null)
							{
								((IConditionalInstructionElement)condition).ConditionalInstructionName = this.Name;
								condition.Int32_0 = num;
								this.list_0.Add(condition);
								num++;
								continue;
							}
							throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITIONALINSTRUCTION_CONDITIONS"));
						}
						this.list_0.Sort();
						if (this.ConditionalInstructionCollection_0 == null)
						{
							break;
						}
						foreach (Condition item in this.list_0)
						{
							if (!this.IConditionalInstructionsManager_0.Core.Dictionary_1.ContainsKey(item.FormField.int_0))
							{
								throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITIONALINSTRUCTION_CONDITIONS_FORMFIELD"));
							}
						}
						this.IConditionalInstructionsManager_0.Core.method_6(this.Name);
						this.IConditionalInstructionsManager_0.Core.method_0(this);
						this.IConditionalInstructionsManager_0.Core.Dictionary_1.Clear();
						this.IConditionalInstructionsManager_0.Core.method_28(this.ConditionalInstructionCollection_0.FormFieldCollection_0);
						this.IConditionalInstructionsManager_0.OnConditionalInstructionsChanged(this.ConditionalInstructionCollection_0.textPart_0);
						break;
					}
					return;
				}
				throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITIONALINSTRUCTION_CONDITIONS"));
			}
		}

		/// <summary>Gets or sets an array of instructions that are executed when the specified conditions are fulfilled.</summary>
		public Instruction[] Instructions
		{
			get
			{
				return this.list_1.ToArray();
			}
			set
			{
				if (value != null && value.Length != 0)
				{
					this.list_1.Clear();
					Dictionary<int, bool[]> dictionary_ = new Dictionary<int, bool[]>();
					int num = 0;
					while (true)
					{
						if (num < value.Length)
						{
							Instruction instruction = value[num];
							if (instruction != null)
							{
								if (this.method_4(dictionary_, instruction))
								{
									((IConditionalInstructionElement)instruction).ConditionalInstructionName = this.Name;
									this.list_1.Add(instruction);
									num++;
									continue;
								}
								throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITIONALINSTRUCTION_INSTRUCTIONS_INSTRUCTIONTYPE"));
							}
							throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITIONALINSTRUCTION_INSTRUCTIONS"));
						}
						this.list_1.Sort();
						if (this.ConditionalInstructionCollection_0 == null)
						{
							break;
						}
						foreach (Instruction item in this.list_1)
						{
							if (!this.IConditionalInstructionsManager_0.Core.Dictionary_1.ContainsKey(item.FormField.GetHashCode()))
							{
								throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITIONALINSTRUCTION_INSTRUCTIONS_FORMFIELD"));
							}
						}
						this.IConditionalInstructionsManager_0.Core.method_6(this.Name);
						this.IConditionalInstructionsManager_0.Core.method_0(this);
						this.IConditionalInstructionsManager_0.Core.Dictionary_1.Clear();
						this.IConditionalInstructionsManager_0.Core.method_28(this.ConditionalInstructionCollection_0.FormFieldCollection_0);
						this.IConditionalInstructionsManager_0.OnConditionalInstructionsChanged(this.ConditionalInstructionCollection_0.textPart_0);
						break;
					}
					return;
				}
				throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITIONALINSTRUCTION_INSTRUCTIONS"));
			}
		}

		/// <summary>Gets or sets a name of the conditional instruction.</summary>
		public string Name
		{
			get
			{
				return this.string_0;
			}
			set
			{
				if (value != null && value.Length != 0)
				{
					string text = this.string_0;
					if (text != (this.string_0 = value) && this.IConditionalInstructionsManager_0 != null)
					{
						if (this.IConditionalInstructionsManager_0.Core.List_1.Contains(this.string_0))
						{
							throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITIONALINSTRUCTION_NAME_UNIQUENESS"));
						}
						this.IConditionalInstructionsManager_0.Core.method_22(text, this.string_0, this.ConditionalInstructionCollection_0.FormFieldCollection_0);
						this.IConditionalInstructionsManager_0.OnConditionalInstructionsChanged(this.ConditionalInstructionCollection_0.textPart_0);
					}
					return;
				}
				throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITIONALINSTRUCTION_NAME"));
			}
		}

		internal bool Boolean_0
		{
			get
			{
				bool flag = this.List_0[0].Boolean_0;
				for (int i = 1; i < this.List_0.Count; i++)
				{
					Condition condition = this.List_0[i];
					if (condition.LogicalConnective == Condition.LogicalConnectives.And)
					{
						flag &= condition.Boolean_0;
						continue;
					}
					if (flag)
					{
						break;
					}
					flag |= condition.Boolean_0;
				}
				return flag;
			}
		}

		internal List<Condition> List_0 => this.list_0;

		internal IConditionalInstructionsManager IConditionalInstructionsManager_0
		{
			get
			{
				if (this.ConditionalInstructionCollection_0 == null)
				{
					return null;
				}
				return this.ConditionalInstructionCollection_0.IConditionalInstructionsManager_0;
			}
		}

		internal int Int32_0
		{
			[CompilerGenerated]
			get
			{
				return this.int_0;
			}
			[CompilerGenerated]
			set
			{
				this.int_0 = value;
			}
		}

		internal ConditionalInstructionCollection ConditionalInstructionCollection_0
		{
			[CompilerGenerated]
			get
			{
				return this.conditionalInstructionCollection_0;
			}
			[CompilerGenerated]
			set
			{
				this.conditionalInstructionCollection_0 = value;
			}
		}

		internal List<Instruction> List_1 => this.list_1;

		/// <summary>Initializes a new instance of the ConditionalInstruction class without any of the required values.</summary>
		public ConditionalInstruction()
		{
		}

		/// <summary>Initializes a new instance of the ConditionalInstruction class with all values that are necessary to provide a valid conditional instruction.</summary>
		/// <param name="name">Specifies the name of the conditional instruction.</param>
		/// <param name="conditions">Specifies the conditions of the conditional instruction.</param>
		/// <param name="instructions">Specifies the instructions of the conditional instruction.</param>
		public ConditionalInstruction(string name, Condition[] conditions, Instruction[] instructions)
		{
			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITIONALINSTRUCTION_NAME"));
			}
			if (conditions != null && conditions.Length != 0)
			{
				if (instructions == null || instructions.Length == 0)
				{
					throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITIONALINSTRUCTION_INSTRUCTIONS"));
				}
				this.Name = name;
				this.method_2(conditions, name);
				this.method_3(instructions, name);
				this.list_0.AddRange(conditions);
				this.list_0.Sort();
				this.list_1.AddRange(instructions);
				this.list_1.Sort();
				return;
			}
			throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITIONALINSTRUCTION_CONDITIONS"));
		}

		/// <summary>Returns a copy of this ConditionalInstruction object.</summary>
		public ConditionalInstruction Copy()
		{
			ConditionalInstruction conditionalInstruction = new ConditionalInstruction();
			conditionalInstruction.Name = this.Name;
			ConditionalInstruction conditionalInstruction2 = conditionalInstruction;
			Condition[] conditions = this.Conditions;
			foreach (Condition condition in conditions)
			{
				conditionalInstruction2.List_0.Add(condition.method_8());
			}
			Instruction[] instructions = this.Instructions;
			foreach (Instruction instruction in instructions)
			{
				conditionalInstruction2.List_1.Add(instruction.method_2());
			}
			return conditionalInstruction2;
		}

		internal void method_0(Class394 class394_0)
		{
			foreach (Instruction item in this.list_1)
			{
				if (!class394_0.method_10(item) || !item.Boolean_0)
				{
					continue;
				}
				switch (item.Commands_0)
				{
				case Commands.AllowFillIn:
					if (!class394_0.List_0.Contains(((IConditionalInstructionElement)item).RelatedFormField.FormField_0))
					{
						class394_0.List_0.Add(((IConditionalInstructionElement)item).RelatedFormField.FormField_0);
					}
					break;
				case Commands.DenyFillIn:
					if (!class394_0.List_2.Contains(((IConditionalInstructionElement)item).RelatedFormField.FormField_0))
					{
						class394_0.List_2.Add(((IConditionalInstructionElement)item).RelatedFormField.FormField_0);
					}
					break;
				default:
					class394_0.method_11();
					item.method_0();
					break;
				case Commands.SetValueAsValid:
					if (!class394_0.List_3.Contains(((IConditionalInstructionElement)item).RelatedFormField.FormField_0))
					{
						class394_0.List_3.Add(((IConditionalInstructionElement)item).RelatedFormField.FormField_0);
					}
					break;
				case Commands.SetValueAsInvalid:
					if (!class394_0.List_4.Contains(((IConditionalInstructionElement)item).RelatedFormField.FormField_0))
					{
						class394_0.List_4.Add(((IConditionalInstructionElement)item).RelatedFormField.FormField_0);
					}
					break;
				}
			}
		}

		internal void method_1(Class394 class394_0)
		{
			foreach (Instruction item in this.list_1)
			{
				Instruction instruction = item as Instruction;
				if (!class394_0.method_10(instruction) || !instruction.IsElseInstructionEnabled)
				{
					continue;
				}
				switch (instruction.Commands_0)
				{
				case Commands.SetNewValue:
					instruction.method_1();
					break;
				case Commands.SetNewItems:
				{
					SelectionFormField selectionFormField = instruction.FormField as SelectionFormField;
					string[] items = selectionFormField.Items;
					string[] array = (string[])instruction.ElseInstructionValue;
					bool flag2;
					if (flag2 = items.Length == array.Length)
					{
						for (int i = 0; i < array.Length; i++)
						{
							if (!(flag2 = items[i] == array[i]))
							{
								break;
							}
						}
					}
					if (!flag2)
					{
						selectionFormField.Items = array;
					}
					break;
				}
				case Commands.AllowFillIn:
				case Commands.DenyFillIn:
				case Commands.SetValueAsValid:
				case Commands.SetValueAsInvalid:
				{
					bool flag = (bool)instruction.ElseInstructionValue;
					switch (instruction.Commands_0)
					{
					case Commands.AllowFillIn:
					case Commands.DenyFillIn:
						if (((IConditionalInstructionElement)item).RelatedFormField.FormField_0.Enabled)
						{
							if (!flag && !class394_0.List_2.Contains(((IConditionalInstructionElement)item).RelatedFormField.FormField_0))
							{
								class394_0.List_2.Add(((IConditionalInstructionElement)item).RelatedFormField.FormField_0);
							}
						}
						else if (flag && !class394_0.List_0.Contains(((IConditionalInstructionElement)item).RelatedFormField.FormField_0))
						{
							class394_0.List_0.Add(((IConditionalInstructionElement)item).RelatedFormField.FormField_0);
						}
						break;
					case Commands.SetValueAsValid:
					case Commands.SetValueAsInvalid:
						if (!flag && !class394_0.List_4.Contains(((IConditionalInstructionElement)item).RelatedFormField.FormField_0))
						{
							class394_0.List_4.Add(((IConditionalInstructionElement)item).RelatedFormField.FormField_0);
						}
						else if (flag && !class394_0.List_3.Contains(((IConditionalInstructionElement)item).RelatedFormField.FormField_0))
						{
							class394_0.List_3.Add(((IConditionalInstructionElement)item).RelatedFormField.FormField_0);
						}
						break;
					}
					break;
				}
				}
			}
		}

		internal static bool smethod_0(string string_1)
		{
			try
			{
				string string_2;
				return Class399.smethod_0(string_1, Class399.Enum48.const_0, out string_2);
			}
			catch
			{
				return false;
			}
		}

		public override string ToString()
		{
			return this.Name;
		}

		private void method_2(Condition[] condition_0, string string_1)
		{
			int num = 0;
			while (true)
			{
				if (num < condition_0.Length)
				{
					Condition condition = condition_0[num];
					if (condition == null)
					{
						break;
					}
					((IConditionalInstructionElement)condition).ConditionalInstructionName = string_1;
					num++;
					continue;
				}
				return;
			}
			throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITIONALINSTRUCTION_CONDITIONS"));
		}

		private void method_3(Instruction[] instruction_0, string string_1)
		{
			Dictionary<int, bool[]> dictionary_ = new Dictionary<int, bool[]>();
			int num = 0;
			while (true)
			{
				if (num < instruction_0.Length)
				{
					Instruction instruction = instruction_0[num];
					if (instruction != null)
					{
						if (!this.method_4(dictionary_, instruction))
						{
							break;
						}
						((IConditionalInstructionElement)instruction).ConditionalInstructionName = string_1;
						num++;
						continue;
					}
					throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITIONALINSTRUCTION_INSTRUCTIONS"));
				}
				return;
			}
			throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITIONALINSTRUCTION_INSTRUCTIONS_INSTRUCTIONTYPE"));
		}

		private bool method_4(Dictionary<int, bool[]> dictionary_0, Instruction instruction_0)
		{
			if (!dictionary_0.TryGetValue(instruction_0.FormField.int_0, out var value))
			{
				value = new bool[4];
				dictionary_0.Add(instruction_0.FormField.int_0, value);
			}
			int num = (int)(instruction_0.InstructionType - 1);
			bool num2 = value[num];
			value[num] = true;
			return !num2;
		}
	}
}
