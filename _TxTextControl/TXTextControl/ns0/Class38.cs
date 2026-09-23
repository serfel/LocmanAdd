using System.Collections.Generic;
using TXTextControl.Barcode;

namespace ns0
{
	internal class Class38
	{
		private Alignment alignment_0 = Alignment.MiddleCenter;

		private string string_0 = "";

		private int int_0;

		private BarcodeType barcodeType_0 = BarcodeType.QRCode;

		private Class26 class26_0;

		private Class26 class26_1;

		private bool bool_0;

		private bool bool_1;

		private float? nullable_0 = null;

		private float float_0;

		private string string_1;

		private bool bool_2 = true;

		private string string_2;

		private TextAlignment textAlignment_0 = TextAlignment.Bottom;

		private int int_1;

		private TXBarcodeCore txbarcodeCore_0;

		internal Alignment Alignment_0
		{
			get
			{
				return this.alignment_0;
			}
			set
			{
				this.alignment_0 = value;
			}
		}

		internal string String_0
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}

		internal int Int32_0
		{
			get
			{
				return this.int_0;
			}
			set
			{
				this.int_0 = value;
			}
		}

		internal BarcodeType BarcodeType_0
		{
			get
			{
				return this.barcodeType_0;
			}
			set
			{
				this.barcodeType_0 = value;
			}
		}

		internal Class26 Class26_0
		{
			get
			{
				return this.class26_0;
			}
			set
			{
				this.class26_0 = value;
			}
		}

		internal Class26 Class26_1
		{
			get
			{
				return this.class26_1;
			}
			set
			{
				this.class26_1 = value;
			}
		}

		internal bool Boolean_0
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

		internal bool Boolean_1
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
			}
		}

		internal float? Nullable_0
		{
			get
			{
				return this.nullable_0;
			}
			set
			{
				this.nullable_0 = value;
			}
		}

		internal float Single_0
		{
			get
			{
				return this.float_0;
			}
			set
			{
				this.float_0 = value;
			}
		}

		internal string String_1
		{
			get
			{
				return this.string_1;
			}
			set
			{
				this.string_1 = value;
			}
		}

		internal bool Boolean_2
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				this.bool_2 = value;
			}
		}

		internal string Text
		{
			get
			{
				return this.string_2;
			}
			set
			{
				this.string_2 = value;
			}
		}

		internal TextAlignment TextAlignment_0
		{
			get
			{
				return this.textAlignment_0;
			}
			set
			{
				this.textAlignment_0 = value;
			}
		}

		internal int UpperTextLength
		{
			get
			{
				return this.int_1;
			}
			set
			{
				this.int_1 = value;
			}
		}

		internal Class38()
		{
		}

		internal Class38(TXBarcodeCore txbarcodeCore_1)
		{
			this.txbarcodeCore_0 = txbarcodeCore_1;
			this.alignment_0 = this.txbarcodeCore_0.class38_0.Alignment_0;
			this.string_0 = this.txbarcodeCore_0.class38_0.String_0;
			this.int_0 = this.txbarcodeCore_0.class38_0.Int32_0;
			this.barcodeType_0 = this.txbarcodeCore_0.barcodeType_0;
			this.class26_0 = this.txbarcodeCore_0.class38_0.Class26_0;
			this.class26_1 = this.txbarcodeCore_0.class38_0.Class26_1;
			this.bool_0 = this.txbarcodeCore_0.class38_0.Boolean_0;
			this.bool_1 = this.txbarcodeCore_0.class38_0.Boolean_1;
			this.nullable_0 = this.txbarcodeCore_0.class38_0.nullable_0;
			this.float_0 = this.txbarcodeCore_0.class38_0.float_0;
			this.string_1 = this.txbarcodeCore_0.class38_0.String_1;
			this.bool_2 = this.txbarcodeCore_0.class38_0.Boolean_2;
			this.string_2 = this.txbarcodeCore_0.class38_0.Text;
			this.textAlignment_0 = this.txbarcodeCore_0.class38_0.TextAlignment_0;
			this.int_1 = this.txbarcodeCore_0.class38_0.UpperTextLength;
		}

		internal string[] method_0(out string[] string_3)
		{
			List<string> list = new List<string>();
			if (this.BarcodeType_0 != this.txbarcodeCore_0.barcodeType_0)
			{
				list.Add("BarcodeType");
			}
			if (this.alignment_0 != this.txbarcodeCore_0.class38_0.Alignment_0)
			{
				list.Add("Alignment");
			}
			if (this.string_0 != this.txbarcodeCore_0.class38_0.String_0)
			{
				list.Add("AdditionalText");
			}
			if (this.int_0 != this.txbarcodeCore_0.class38_0.Int32_0)
			{
				list.Add("Angle");
			}
			if (this.bool_0 == this.txbarcodeCore_0.class38_0.Boolean_0 && this.bool_1 == this.txbarcodeCore_0.class38_0.Boolean_1)
			{
				string_3 = new string[0];
			}
			else
			{
				list.Add("BarcodeTypeSettings");
				List<string> list2 = new List<string>();
				if (this.bool_0 != this.txbarcodeCore_0.class38_0.Boolean_0)
				{
					list2.Add("HasCheckValue");
				}
				if (this.bool_1 != this.txbarcodeCore_0.class38_0.Boolean_1)
				{
					list2.Add("ShowCheckValue");
				}
				string_3 = list2.ToArray();
			}
			if (this.bool_2 != this.txbarcodeCore_0.class38_0.Boolean_2)
			{
				list.Add("ShowText");
			}
			if (this.string_2 != this.txbarcodeCore_0.class38_0.Text)
			{
				list.Add("Text");
			}
			if (this.textAlignment_0 != this.txbarcodeCore_0.class38_0.TextAlignment_0)
			{
				list.Add("TextAlignment");
			}
			if (this.int_1 != this.txbarcodeCore_0.class38_0.UpperTextLength)
			{
				list.Add("UpperTextLength");
			}
			return list.ToArray();
		}
	}
}
