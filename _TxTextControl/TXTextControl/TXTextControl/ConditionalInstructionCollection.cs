using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using ns21;

namespace TXTextControl
{
	/// <summary>An instance of the ConditionalInstructionCollection class contains all conditional instructions in a Text Control document or part of the document represented through objects of type ConditionalInstruction.</summary>
	public class ConditionalInstructionCollection : ICollection, IEnumerable
	{
		public class ConditionalInstructionEnumerator : IEnumerator
		{
			private int int_0 = -1;

			private ConditionalInstructionCollection conditionalInstructionCollection_0;

			public object Current
			{
				get
				{
					if (this.conditionalInstructionCollection_0.iconditionalInstructionsManager_0 == null)
					{
						return null;
					}
					string[] conditionalInstructionNames = this.conditionalInstructionCollection_0.ConditionalInstructionNames;
					if (conditionalInstructionNames == null)
					{
						return null;
					}
					string name = conditionalInstructionNames[this.int_0];
					return this.conditionalInstructionCollection_0.GetItem(name);
				}
			}

			public ConditionalInstructionEnumerator(ConditionalInstructionCollection conditionalInstructions)
			{
				this.conditionalInstructionCollection_0 = conditionalInstructions;
			}

			public bool MoveNext()
			{
				if (this.conditionalInstructionCollection_0.iconditionalInstructionsManager_0 == null)
				{
					return false;
				}
				this.int_0++;
				string[] conditionalInstructionNames = this.conditionalInstructionCollection_0.ConditionalInstructionNames;
				if (conditionalInstructionNames != null)
				{
					return conditionalInstructionNames.Length > this.int_0;
				}
				return false;
			}

			public void Reset()
			{
				if (this.conditionalInstructionCollection_0.iconditionalInstructionsManager_0 != null)
				{
					this.int_0 = -1;
				}
			}
		}

		private IConditionalInstructionsManager iconditionalInstructionsManager_0;

		internal TextPart textPart_0;

		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private FormFieldCollection formFieldCollection_0;

		internal FormFieldCollection FormFieldCollection_0 => this.formFieldCollection_0;

		internal IConditionalInstructionsManager IConditionalInstructionsManager_0 => this.iconditionalInstructionsManager_0;

		/// <summary>Gets the names of all ConditionalInstruction elements that are listed inside the collection.</summary>
		public string[] ConditionalInstructionNames
		{
			get
			{
				if (!this.Boolean_0)
				{
					return null;
				}
				this.iconditionalInstructionsManager_0.Core.method_18(this.textPart_0, this.formFieldCollection_0);
				return this.iconditionalInstructionsManager_0.Core.List_1.ToArray();
			}
		}

		private bool Boolean_0
		{
			get
			{
				if (this.iconditionalInstructionsManager_0 != null)
				{
					return this.iconditionalInstructionsManager_0.Core.textControlCore_0.isHandleCreated;
				}
				return false;
			}
		}

		int ICollection.Count => this.Count;

		/// <summary>Gets the number of elements contained in the collection.</summary>
		public int Count
		{
			get
			{
				if (this.iconditionalInstructionsManager_0 != null && this.iconditionalInstructionsManager_0.Core.textControlCore_0.isHandleCreated)
				{
					return this.iconditionalInstructionsManager_0.Core.List_1.Count;
				}
				return -1;
			}
		}

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => this;

		internal ConditionalInstructionCollection(IConditionalInstructionsManager conditionalInstructionManager, TextPart textPart, FormFieldCollection formFields)
		{
			this.iconditionalInstructionsManager_0 = conditionalInstructionManager;
			this.textPart_0 = textPart;
			this.formFieldCollection_0 = formFields;
		}

		/// <summary>Inserts an instance of the class ConditionalInstruction to the collection and the document.</summary>
		/// <param name="conditionalInstruction">Specifies ConditionalInstruction element to add.</param>
		public bool Add(ConditionalInstruction conditionalInstruction)
		{
			if (conditionalInstruction == null)
			{
				throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITIONALINSTRUCTION_NULL"));
			}
			if (string.IsNullOrEmpty(conditionalInstruction.Name))
			{
				throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITIONALINSTRUCTION_NAME"));
			}
			if (conditionalInstruction.Conditions.Length == 0)
			{
				throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITIONALINSTRUCTION_CONDITIONS"));
			}
			if (conditionalInstruction.Instructions.Length == 0)
			{
				throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITIONALINSTRUCTION_INSTRUCTIONS"));
			}
			if (this.Boolean_0 && !this.iconditionalInstructionsManager_0.Core.Boolean_1)
			{
				this.iconditionalInstructionsManager_0.Core.method_18(this.textPart_0, this.formFieldCollection_0);
				if (this.iconditionalInstructionsManager_0.Core.List_1.Contains(conditionalInstruction.Name))
				{
					throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITIONALINSTRUCTION_NAME_UNIQUENESS"));
				}
				Condition[] conditions = conditionalInstruction.Conditions;
				int num = 0;
				while (true)
				{
					if (num < conditions.Length)
					{
						Condition condition = conditions[num];
						if (!this.iconditionalInstructionsManager_0.Core.Dictionary_1.ContainsKey(condition.FormField.GetHashCode()))
						{
							break;
						}
						num++;
						continue;
					}
					Instruction[] instructions = conditionalInstruction.Instructions;
					int num2 = 0;
					while (true)
					{
						if (num2 < instructions.Length)
						{
							Instruction instruction = instructions[num2];
							if (!this.iconditionalInstructionsManager_0.Core.Dictionary_1.ContainsKey(instruction.FormField.GetHashCode()))
							{
								break;
							}
							num2++;
							continue;
						}
						if (conditionalInstruction.Conditions.Length == 0)
						{
							throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITIONALINSTRUCTION_CONDITIONS"));
						}
						this.iconditionalInstructionsManager_0.Core.method_0(conditionalInstruction);
						this.iconditionalInstructionsManager_0.Core.Dictionary_1.Clear();
						this.iconditionalInstructionsManager_0.Core.method_28(this.formFieldCollection_0);
						conditionalInstruction.ConditionalInstructionCollection_0 = this;
						this.iconditionalInstructionsManager_0.OnConditionalInstructionsChanged(this.textPart_0);
						return true;
					}
					throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITIONALINSTRUCTION_INSTRUCTIONS_FORMFIELD"));
				}
				throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITIONALINSTRUCTION_CONDITIONS_FORMFIELD"));
			}
			return false;
		}

		/// <summary>Removes all conditional instructions from the collection and the document.</summary>
		public bool Clear()
		{
			if (this.Boolean_0 && !this.iconditionalInstructionsManager_0.Core.Boolean_1)
			{
				if (this.iconditionalInstructionsManager_0.Core.method_9(this.textPart_0))
				{
					this.iconditionalInstructionsManager_0.Core.method_2();
				}
				else
				{
					this.iconditionalInstructionsManager_0.Core.method_3(this.textPart_0, this.formFieldCollection_0);
				}
				this.iconditionalInstructionsManager_0.OnConditionalInstructionsChanged(this.textPart_0);
				return true;
			}
			return false;
		}

		/// <summary>Gets that ConditionalInstruction element from the collection, where the Name property value equals the specified name.</summary>
		/// <param name="name">Specifies the name of the requested ConditionalInstruction element.</param>
		public ConditionalInstruction GetItem(string name)
		{
			if (!this.Boolean_0)
			{
				return null;
			}
			this.iconditionalInstructionsManager_0.Core.method_18(this.textPart_0, this.formFieldCollection_0);
			if (!this.iconditionalInstructionsManager_0.Core.List_1.Contains(name))
			{
				return null;
			}
			ConditionalInstruction conditionalInstruction = this.iconditionalInstructionsManager_0.Core.method_4(name);
			conditionalInstruction.ConditionalInstructionCollection_0 = this;
			return conditionalInstruction;
		}

		/// <summary>Gets those ConditionalInstruction elements from the collection, where at least one Condition or Instruction element references the specified FormField.</summary>
		/// <param name="formField">Specifies the FormField that is referenced inside the requested ConditionalInstruction elements.</param>
		public ConditionalInstruction[] GetItems(FormField formField)
		{
			if (!this.Boolean_0)
			{
				return null;
			}
			this.iconditionalInstructionsManager_0.Core.method_18(this.textPart_0, this.formFieldCollection_0);
			if (!this.iconditionalInstructionsManager_0.Core.Dictionary_1.ContainsKey(formField.int_0))
			{
				return new ConditionalInstruction[0];
			}
			List<string> list = this.iconditionalInstructionsManager_0.Core.method_8(formField, (Class394.Enum47)3);
			List<ConditionalInstruction> list2 = new List<ConditionalInstruction>();
			foreach (string item in list)
			{
				ConditionalInstruction conditionalInstruction = this.iconditionalInstructionsManager_0.Core.method_4(item);
				conditionalInstruction.ConditionalInstructionCollection_0 = this;
				list2.Add(conditionalInstruction);
			}
			return list2.ToArray();
		}

		public bool HasValidValue(FormField formField)
		{
			if (formField == null)
			{
				throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITIONALINSTRUCTION_FORMFIELD_NULL"));
			}
			if (this.Boolean_0 && this.iconditionalInstructionsManager_0.Core.Boolean_1)
			{
				if (!this.iconditionalInstructionsManager_0.Core.Dictionary_1.ContainsKey(formField.int_0))
				{
					throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITIONALINSTRUCTION_FORMFIELD"));
				}
				return !this.iconditionalInstructionsManager_0.Core.List_5.Contains(formField);
			}
			if (this.iconditionalInstructionsManager_0 != null && this.iconditionalInstructionsManager_0.Core != null && !this.iconditionalInstructionsManager_0.Core.Dictionary_1.ContainsKey(formField.int_0))
			{
				throw new ArgumentException(this.resourceManager_0.GetString("ERR_CONDITIONALINSTRUCTION_FORMFIELD"));
			}
			return true;
		}

		/// <summary>Removes that ConditionalInstruction element from the collection and the document, where the Name property value equals the specified name.</summary>
		/// <param name="name">Specifies the name of the ConditionalInstruction element to remove.</param>
		public bool Remove(string name)
		{
			if (this.Boolean_0 && !this.iconditionalInstructionsManager_0.Core.Boolean_1)
			{
				this.iconditionalInstructionsManager_0.Core.method_18(this.textPart_0, this.formFieldCollection_0);
				if (!this.iconditionalInstructionsManager_0.Core.List_1.Contains(name))
				{
					return false;
				}
				this.iconditionalInstructionsManager_0.Core.method_6(name);
				this.iconditionalInstructionsManager_0.OnConditionalInstructionsChanged(this.textPart_0);
				return true;
			}
			return false;
		}

		void ICollection.CopyTo(Array array, int index)
		{
			this.CopyTo(array, index);
		}

		/// <summary>Copies the elements of the collection to an array, starting at a particular index.</summary>
		/// <param name="array">Specifies the array to copy to.</param>
		/// <param name="index">Specifies the index of the destination array at which to begin copying.</param>
		public void CopyTo(Array array, int index)
		{
			if (this.iconditionalInstructionsManager_0 == null)
			{
				return;
			}
			string[] conditionalInstructionNames = this.ConditionalInstructionNames;
			if (conditionalInstructionNames != null)
			{
				string[] array2 = conditionalInstructionNames;
				foreach (string name in array2)
				{
					array.SetValue(this.GetItem(name), index++);
				}
			}
		}

		/// <summary>Returns an enumerator that can be used to iterate through the collection.</summary>
		public ConditionalInstructionEnumerator GetEnumerator()
		{
			return new ConditionalInstructionEnumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new ConditionalInstructionEnumerator(this);
		}
	}
}
