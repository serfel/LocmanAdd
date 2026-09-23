using System.ComponentModel;
using ns21;

namespace TXTextControl
{
	/// <summary>The type of the documentPermissions property.</summary>
	[TypeConverter(typeof(Class417))]
	public class DocumentPermissions
	{
		internal enum Enum50
		{
			const_0 = 1,
			const_1 = 2,
			const_2 = 4,
			const_3 = 8,
			const_4 = 0x10,
			const_5 = 0x100,
			const_6 = 0x200,
			const_7 = 0x400,
			const_8 = 0x800,
			const_9 = 0x4000,
			const_10 = 0x2000
		}

		private TextControlCore textControlCore_0;

		private bool bool_0;

		private bool bool_1 = true;

		private bool bool_2 = true;

		private bool bool_3 = true;

		private bool bool_4 = true;

		private bool bool_5 = true;

		private bool bool_6 = true;

		private bool bool_7 = true;

		private bool bool_8 = true;

		private bool bool_9 = true;

		/// <summary>Specifies whether document content can be copied to the clipboard.</summary>
		[Attribute3("PROP_DP_ALLOWCOPY")]
		[DefaultValue(true)]
		[Category("Behavior")]
		public bool AllowCopy
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				if (this.bool_1 != value)
				{
					this.bool_1 = value;
					this.method_3();
				}
			}
		}

		/// <summary>Specifies whether form fields can be edited.</summary>
		[Category("Behavior")]
		[DefaultValue(true)]
		[Attribute3("PROP_DP_ALLOWEDITFORMFIELDS")]
		public bool AllowEditingFormFields
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				if (this.bool_2 != value)
				{
					this.bool_2 = value;
					this.method_3();
				}
			}
		}

		/// <summary>Gets or sets a value specifying whether the document can be formatted.</summary>
		[DefaultValue(true)]
		[Category("Behavior")]
		[Attribute3("PROP_DP_ALLOWFORMATTING")]
		public bool AllowFormatting
		{
			get
			{
				return this.bool_3;
			}
			set
			{
				if (this.bool_3 != value)
				{
					this.bool_3 = value;
					this.method_3();
				}
			}
		}

		/// <summary>Gets or sets a value specifying whether formatting styles can be used to format the document.</summary>
		[Attribute3("PROP_DP_ALLOWFORMATINGSTYLES")]
		[DefaultValue(true)]
		[Category("Behavior")]
		public bool AllowFormattingStyles
		{
			get
			{
				return this.bool_4;
			}
			set
			{
				if (this.bool_4 != value)
				{
					this.bool_4 = value;
					this.method_3();
				}
			}
		}

		/// <summary>Gets or sets a value specifying whether the document can be printed.</summary>
		[Attribute3("PROP_DP_ALLOWPRINTING")]
		[DefaultValue(true)]
		[Category("Behavior")]
		public bool AllowPrinting
		{
			get
			{
				return this.bool_5;
			}
			set
			{
				if (this.bool_5 != value)
				{
					this.bool_5 = value;
					this.method_3();
				}
			}
		}

		/// <summary>Gets or sets a value specifying whether the document is read only.</summary>
		[DefaultValue(true)]
		[Category("Behavior")]
		[Attribute3("PROP_DP_READONLY")]
		public bool ReadOnly
		{
			get
			{
				return this.bool_6;
			}
			set
			{
				if (this.bool_6 != value)
				{
					this.bool_6 = value;
					this.method_3();
				}
			}
		}

		internal bool Boolean_0 => this.bool_7;

		internal bool Boolean_1 => this.bool_8;

		internal bool Boolean_2 => this.bool_9;

		public DocumentPermissions()
		{
		}

		internal DocumentPermissions(TextControlCore textControlCore_1, bool bActual)
		{
			this.textControlCore_0 = textControlCore_1;
			this.bool_0 = bActual;
		}

		internal void method_0(TextControlCore textControlCore_1)
		{
			this.textControlCore_0 = textControlCore_1;
			this.method_3();
		}

		internal void method_1()
		{
			if (!this.method_2())
			{
				this.bool_1 = true;
				this.bool_3 = true;
				this.bool_4 = true;
				this.bool_5 = true;
				this.bool_6 = true;
				this.method_3();
			}
		}

		internal bool method_2()
		{
			if (this.bool_1 && this.bool_3 && this.bool_4 && this.bool_5)
			{
				return !this.bool_6;
			}
			return false;
		}

		internal void method_3()
		{
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
			{
				this.textControlCore_0.method_30(Enum83.const_322, (this.bool_1 ? 4 : 0) | (this.bool_3 ? 1 : 0) | (this.bool_4 ? 2 : 0) | (this.bool_5 ? 8 : 0) | (this.bool_6 ? 16 : 0) | (this.bool_2 ? 2048 : 0), 0);
			}
		}

		internal void method_4()
		{
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
			{
				Enum50 @enum = (Enum50)this.textControlCore_0.method_30(Enum83.const_321, this.bool_0 ? 1 : 0, 0);
				this.bool_1 = (@enum & Enum50.const_2) != 0;
				this.bool_3 = (@enum & Enum50.const_0) != 0;
				this.bool_4 = (@enum & Enum50.const_1) != 0;
				this.bool_5 = (@enum & Enum50.const_3) != 0;
				this.bool_6 = (@enum & Enum50.const_4) != 0;
				this.bool_2 = (@enum & Enum50.const_8) != 0;
				if (this.bool_0)
				{
					this.bool_7 = (@enum & Enum50.const_5) != 0;
					this.bool_8 = (@enum & Enum50.const_6) != 0;
					this.bool_9 = (@enum & Enum50.const_7) != 0;
				}
			}
		}
	}
}
