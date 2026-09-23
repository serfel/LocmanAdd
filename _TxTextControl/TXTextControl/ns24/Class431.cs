using System.Runtime.CompilerServices;
using ns21;
using TXTextControl;
using TXTextControl.ServerVisualisation;

namespace ns24
{
	internal class Class431 : IConditionalInstructionsManager
	{
		private Class394 class394_0;

		private bool bool_0 = true;

		internal TextPart textPart_0 = TextPart.MainText;

		[CompilerGenerated]
		private ServerTextControl serverTextControl_0;

		internal Class394 Class394_0 => this.class394_0;

		internal ServerTextControl ServerTextControl_0
		{
			[CompilerGenerated]
			get
			{
				return this.serverTextControl_0;
			}
			[CompilerGenerated]
			set
			{
				this.serverTextControl_0 = value;
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

		bool IConditionalInstructionsManager.IsFormFieldValidationEnabled => (this.ServerTextControl_0 as TextViewGenerator)?.IsFormFieldValidationEnabled ?? false;

		internal Class431(ServerTextControl serverTextControl_1)
		{
			this.ServerTextControl_0 = serverTextControl_1;
			this.class394_0 = new Class394(serverTextControl_1.textControlCore_0);
		}

		internal void method_0()
		{
			TextViewGenerator textViewGenerator = this.ServerTextControl_0 as TextViewGenerator;
			if (textViewGenerator != null && textViewGenerator.IsFormFieldValidationEnabled)
			{
				this.bool_0 = false;
				this.class394_0.method_1();
				this.bool_0 = true;
			}
		}

		internal void method_1(TextPart textPart_1)
		{
			this.textPart_0 = ((textPart_1 == TextPart.Auto) ? TextPart.MainText : textPart_1);
			this.Class394_0.method_12(this.textPart_0);
		}

		internal void method_2(TextPart textPart_1)
		{
			this.textPart_0 = ((textPart_1 == TextPart.Auto) ? TextPart.MainText : textPart_1);
			this.Class394_0.method_13(this.ServerTextControl_0.FormFields, this.textPart_0);
		}

		internal void method_3()
		{
			this.Class394_0.method_24(this.textPart_0);
			this.Class394_0.method_19(this.ServerTextControl_0.FormFields);
			if (this.Boolean_0)
			{
				this.Class394_0.method_1();
			}
		}

		internal void method_4(FormField formField_0, TextPart textPart_1)
		{
			if (this.Class394_0.method_9(textPart_1))
			{
				this.Class394_0.method_15(formField_0);
			}
			else if (this.textPart_0 == ((textPart_1 == TextPart.Auto) ? TextPart.MainText : textPart_1))
			{
				this.Class394_0.method_18(this.textPart_0, this.ServerTextControl_0.FormFields);
			}
		}

		internal void method_5(int int_0, TextPart textPart_1)
		{
			if (this.Class394_0.method_9(textPart_1))
			{
				this.Class394_0.method_16(int_0);
			}
			else if (this.textPart_0 == ((textPart_1 == TextPart.Auto) ? TextPart.MainText : textPart_1))
			{
				this.Class394_0.method_18(this.textPart_0, this.ServerTextControl_0.FormFields);
			}
		}

		internal void method_6(Struct62 struct62_0, TextPart textPart_1)
		{
			if (this.Class394_0.method_9(textPart_1))
			{
				this.method_8(struct62_0);
			}
			else if (this.textPart_0 == ((textPart_1 == TextPart.Auto) ? TextPart.MainText : textPart_1) && this.Class394_0.Boolean_1 && this.bool_0)
			{
				this.Class394_0.method_18(this.textPart_0, this.ServerTextControl_0.FormFields);
				this.method_8(struct62_0);
			}
		}

		internal void method_7(TextPart textPart_1)
		{
			this.textPart_0 = textPart_1;
			this.Class394_0.method_17(this.ServerTextControl_0.FormFields, this.textPart_0);
			this.class394_0.method_1();
		}

		internal void method_8(Struct62 struct62_0)
		{
			if (this.Class394_0.Boolean_1 && this.bool_0)
			{
				this.bool_0 = false;
				this.class394_0.method_14((int)struct62_0.uint_0);
				this.bool_0 = true;
			}
		}

		internal bool method_9(FormField formField_0)
		{
			if (this.Class394_0.method_9(this.textPart_0))
			{
				return this.Class394_0.method_21(formField_0);
			}
			this.Class394_0.method_18(this.textPart_0, this.ServerTextControl_0.FormFields);
			return true;
		}

		internal void method_10(bool bool_1)
		{
			if (bool_1)
			{
				this.Boolean_0 = this.ServerTextControl_0.Boolean_0;
				this.class394_0.method_19(this.ServerTextControl_0.FormFields);
				this.method_0();
			}
			else
			{
				this.class394_0.method_23();
			}
			this.class394_0.Boolean_0 = bool_1;
		}

		void IConditionalInstructionsManager.OnConditionalInstructionsChanged(TextPart textPart)
		{
		}
	}
}
