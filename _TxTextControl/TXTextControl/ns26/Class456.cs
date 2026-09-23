using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ns21;
using TXTextControl;
using TXTextControl.Windows.Forms;

namespace ns26
{
	internal class Class456 : Component, IConditionalInstructionsManager
	{
		private Class394 class394_0;

		private bool bool_0 = true;

		internal TextPart textPart_0 = TextPart.MainText;

		private static readonly object object_0 = new object();

		private static readonly object object_1 = new object();

		private static readonly object object_2 = new object();

		[CompilerGenerated]
		private TextControl textControl_0;

		internal Class394 Class394_0 => this.class394_0;

		internal TextControl TextControl_0
		{
			[CompilerGenerated]
			get
			{
				return this.textControl_0;
			}
			[CompilerGenerated]
			set
			{
				this.textControl_0 = value;
			}
		}

		internal bool Boolean_0
		{
			get
			{
				return this.class394_0.Boolean_1;
			}
			set
			{
				this.bool_0 = false;
				this.class394_0.Boolean_1 = value;
				this.bool_0 = true;
			}
		}

		public Class394 Core => this.class394_0;

		bool IConditionalInstructionsManager.IsFormFieldValidationEnabled => this.TextControl_0.IsFormFieldValidationEnabled;

		internal event EventHandler ConditionalInstructionsChanged
		{
			add
			{
				base.Events.AddHandler(Class456.object_0, value);
			}
			remove
			{
				base.Events.RemoveHandler(Class456.object_0, value);
			}
		}

		internal event EventHandler FormFieldNameChanged
		{
			add
			{
				base.Events.AddHandler(Class456.object_1, value);
			}
			remove
			{
				base.Events.RemoveHandler(Class456.object_1, value);
			}
		}

		internal event EventHandler SelectionFormFieldItemsChanged
		{
			add
			{
				base.Events.AddHandler(Class456.object_2, value);
			}
			remove
			{
				base.Events.RemoveHandler(Class456.object_2, value);
			}
		}

		internal Class456(TextControl textControl_1)
		{
			this.TextControl_0 = textControl_1;
			this.class394_0 = new Class394(textControl_1.textControlCore_0);
		}

		internal void method_0()
		{
			((EventHandler)base.Events[Class456.object_0])?.Invoke(this, new EventArgs());
		}

		internal void method_1(FormField formField_0)
		{
			if (this.method_14(formField_0))
			{
				this.method_2();
			}
		}

		private void method_2()
		{
			((EventHandler)base.Events[Class456.object_1])?.Invoke(this, new EventArgs());
		}

		internal void method_3(FormField formField_0)
		{
			if (this.method_14(formField_0))
			{
				this.method_4();
			}
		}

		private void method_4()
		{
			((EventHandler)base.Events[Class456.object_2])?.Invoke(this, new EventArgs());
		}

		internal void method_5()
		{
			if (this.TextControl_0.IsFormFieldValidationEnabled)
			{
				this.bool_0 = false;
				this.class394_0.method_1();
				this.bool_0 = true;
			}
		}

		internal void method_6(TextPart textPart_1)
		{
			this.textPart_0 = ((textPart_1 == TextPart.Auto) ? TextPart.MainText : textPart_1);
			this.Class394_0.method_12(this.textPart_0);
			this.method_0();
		}

		internal void method_7(TextPart textPart_1)
		{
			this.textPart_0 = ((textPart_1 == TextPart.Auto) ? TextPart.MainText : textPart_1);
			this.Class394_0.method_13(this.TextControl_0.FormFields, this.textPart_0);
			this.method_0();
		}

		internal void method_8()
		{
			this.Class394_0.method_18(this.textPart_0, this.TextControl_0.FormFields);
			this.Class394_0.method_5();
			this.Class394_0.method_1();
		}

		internal void method_9(FormField formField_0, TextPart textPart_1)
		{
			if (this.Class394_0.method_9(textPart_1))
			{
				this.Class394_0.method_15(formField_0);
			}
			else if (this.textPart_0 == ((textPart_1 == TextPart.Auto) ? TextPart.MainText : textPart_1))
			{
				this.Class394_0.method_18(this.textPart_0, this.TextControl_0.FormFields);
			}
		}

		internal void method_10(int int_0, TextPart textPart_1)
		{
			if (this.Class394_0.method_9(textPart_1))
			{
				this.Class394_0.method_16(int_0);
			}
			else if (this.textPart_0 == ((textPart_1 == TextPart.Auto) ? TextPart.MainText : textPart_1))
			{
				this.Class394_0.method_18(this.textPart_0, this.TextControl_0.FormFields);
			}
		}

		internal void method_11(Struct62 struct62_0, TextPart textPart_1)
		{
			if (this.Class394_0.method_9(textPart_1))
			{
				this.method_13(struct62_0);
			}
			else if (this.textPart_0 == ((textPart_1 == TextPart.Auto) ? TextPart.MainText : textPart_1) && this.Class394_0.Boolean_1 && this.bool_0)
			{
				this.Class394_0.method_18(this.textPart_0, this.TextControl_0.FormFields);
				this.method_13(struct62_0);
			}
		}

		internal void method_12(TextPart textPart_1)
		{
			this.textPart_0 = textPart_1;
			this.Class394_0.method_17(this.TextControl_0.FormFields, this.textPart_0);
			this.method_0();
			this.class394_0.method_1();
		}

		internal void method_13(Struct62 struct62_0)
		{
			if (this.Class394_0.Boolean_1 && this.bool_0)
			{
				this.bool_0 = false;
				this.class394_0.method_14((int)struct62_0.uint_0);
				this.bool_0 = true;
			}
		}

		internal bool method_14(FormField formField_0)
		{
			if (this.Class394_0.method_9(this.textPart_0))
			{
				return this.Class394_0.method_21(formField_0);
			}
			this.Class394_0.method_18(this.textPart_0, this.TextControl_0.FormFields);
			return true;
		}

		internal DialogResult method_15()
		{
			this.class394_0.method_18(this.textPart_0, this.TextControl_0.FormFields);
			ManageConditionalInstructionsDialog manageConditionalInstructionsDialog = new ManageConditionalInstructionsDialog(this);
			manageConditionalInstructionsDialog.Owner = this.TextControl_0.FindForm();
			manageConditionalInstructionsDialog.RightToLeft = this.TextControl_0.RightToLeft;
			DialogResult dialogResult = manageConditionalInstructionsDialog.ShowDialog(this.TextControl_0);
			if (dialogResult == DialogResult.OK && manageConditionalInstructionsDialog.Boolean_0)
			{
				this.class394_0.method_20(manageConditionalInstructionsDialog.ConditionalInstruction_0, this.TextControl_0.FormFields);
			}
			return dialogResult;
		}

		internal DialogResult method_16(ref string string_0)
		{
			this.class394_0.method_18(this.textPart_0, this.TextControl_0.FormFields);
			ConditionalInstruction conditionalInstruction_ = null;
			DialogResult dialogResult;
			if (string_0 == null)
			{
				dialogResult = this.method_18(ref conditionalInstruction_);
			}
			else
			{
				conditionalInstruction_ = this.class394_0.method_4(string_0);
				dialogResult = this.method_18(ref conditionalInstruction_);
			}
			if (dialogResult == DialogResult.OK)
			{
				string_0 = conditionalInstruction_.Name;
				this.method_0();
			}
			return dialogResult;
		}

		internal void method_17(bool bool_1)
		{
			if (bool_1)
			{
				this.Boolean_0 = this.TextControl_0.EditMode == EditMode.ReadAndSelect;
				this.class394_0.method_19(this.TextControl_0.FormFields);
				this.method_5();
			}
			else
			{
				this.class394_0.method_23();
			}
			this.class394_0.Boolean_0 = bool_1;
		}

		private DialogResult method_18(ref ConditionalInstruction conditionalInstruction_0)
		{
			ConditionalInstructionDialog conditionalInstructionDialog = new ConditionalInstructionDialog(this, conditionalInstruction_0, this.class394_0.List_1);
			conditionalInstructionDialog.Owner = this.TextControl_0.FindForm();
			conditionalInstructionDialog.RightToLeft = this.TextControl_0.RightToLeft;
			if (conditionalInstructionDialog.ShowDialog(this.TextControl_0) == DialogResult.OK)
			{
				if (conditionalInstruction_0 == null)
				{
					conditionalInstruction_0 = new ConditionalInstruction
					{
						Name = conditionalInstructionDialog.String_0
					};
				}
				this.method_19(conditionalInstruction_0.Name, conditionalInstructionDialog.List_0);
				this.method_20(conditionalInstruction_0.Name, conditionalInstructionDialog.List_1);
				conditionalInstruction_0.Name = conditionalInstructionDialog.String_0;
				this.class394_0.method_19(this.TextControl_0.FormFields);
				return DialogResult.OK;
			}
			return DialogResult.Cancel;
		}

		private void method_19(string string_0, List<Row> list_0)
		{
			Dictionary<int, List<string>> dictionary = new Dictionary<int, List<string>>();
			for (int i = 0; i < list_0.Count; i++)
			{
				Class460 @class = list_0[i] as Class460;
				IConditionalInstructionElement condition_ = @class.Condition_0;
				if (!dictionary.TryGetValue(condition_.RelatedFormField.Int32_0, out var value))
				{
					value = new List<string>();
					dictionary.Add(condition_.RelatedFormField.Int32_0, value);
				}
				@class.Condition_0.Int32_0 = i;
				value.Add(condition_.ToJson());
			}
			this.class394_0.method_26(string_0, dictionary);
		}

		private void method_20(string string_0, List<Row> list_0)
		{
			Dictionary<int, List<string>> dictionary = new Dictionary<int, List<string>>();
			for (int i = 0; i < list_0.Count; i++)
			{
				Class461 @class = list_0[i] as Class461;
				IConditionalInstructionElement instruction_ = @class.Instruction_0;
				if (!dictionary.TryGetValue(instruction_.RelatedFormField.Int32_0, out var value))
				{
					value = new List<string>();
					dictionary.Add(instruction_.RelatedFormField.Int32_0, value);
				}
				value.Add(instruction_.ToJson());
			}
			this.class394_0.method_27(string_0, dictionary);
		}

		void IConditionalInstructionsManager.OnConditionalInstructionsChanged(TextPart textPart)
		{
			if (this.textPart_0 == ((textPart == TextPart.Auto) ? TextPart.MainText : textPart))
			{
				this.method_0();
			}
		}
	}
}
