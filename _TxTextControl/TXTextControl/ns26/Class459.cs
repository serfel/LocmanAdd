using System.ComponentModel;
using System.Runtime.CompilerServices;
using TXTextControl;
using TXTextControl.Windows.Forms;

namespace ns26
{
	internal class Class459 : Class457
	{
		[CompilerGenerated]
		private TextControl textControl_0;

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

		internal override Row vmethod_0(IConditionalInstructionElement iconditionalInstructionElement_0)
		{
			return new Class461(this, iconditionalInstructionElement_0 as Instruction);
		}

		internal override void vmethod_3(Row row_0)
		{
			this.method_11();
			bool flag;
			if (flag = (row_0 as Class461).Instruction_0.Commands_0 == Commands.SetNewItems)
			{
				row_0.CurrentFormField.method_0();
			}
			foreach (Class461 item in base.List_1)
			{
				if (item.CurrentFormField == row_0.CurrentFormField)
				{
					item.method_3();
					item.ComboBox_0.Enabled = true;
					if (flag && item.Instruction_0.Commands_0 == Commands.SetNewValue)
					{
						item.method_6(row_0.CurrentFormField.String_1);
						item.method_7();
						flag = false;
					}
				}
			}
		}

		protected override void vmethod_1(object sender, PropertyChangedEventArgs e)
		{
			base.vmethod_1(sender, e);
			switch (e.PropertyName)
			{
			case "IsValidCondition":
				base.method_9(sender as Class461);
				break;
			case "CurrentFormField":
				foreach (Class461 item in base.List_1)
				{
					if (!item.ComboBox_0.Enabled && !item.CurrentFormField.Boolean_0)
					{
						item.ComboBox_0.Enabled = true;
					}
				}
				break;
			case "InstructionType":
				break;
			}
		}

		internal void method_11()
		{
			foreach (FormFieldItem item in base.List_0)
			{
				item.Boolean_0 = false;
			}
			foreach (Class461 item2 in base.List_1)
			{
				switch (item2.Instruction_0.Commands_0)
				{
				case Commands.AllowFillIn:
					item2.CurrentFormField.Boolean_1 = true;
					break;
				case Commands.DenyFillIn:
					item2.CurrentFormField.Boolean_2 = true;
					break;
				case Commands.SetNewValue:
					item2.CurrentFormField.Boolean_3 = true;
					break;
				case Commands.SetNewItems:
					item2.CurrentFormField.Boolean_6 = true;
					break;
				case Commands.SetValueAsValid:
					item2.CurrentFormField.Boolean_4 = true;
					break;
				case Commands.SetValueAsInvalid:
					item2.CurrentFormField.Boolean_5 = true;
					break;
				}
			}
		}
	}
}
