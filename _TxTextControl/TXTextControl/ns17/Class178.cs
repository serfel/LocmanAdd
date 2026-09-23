using System;
using TXTextControl.Drawing;

namespace ns17
{
	internal class Class178
	{
		private double double_0;

		private double double_1;

		private double double_2;

		private double double_3;

		private double double_4;

		private double double_5;

		private double double_6;

		private double double_7;

		private bool bool_0;

		internal double Double_0
		{
			get
			{
				return this.double_0;
			}
			set
			{
				this.double_0 = value;
				this.double_4 = MeasuringHelper.Twips2EMU(this.double_0);
			}
		}

		internal double Double_1
		{
			get
			{
				return this.double_1;
			}
			set
			{
				this.double_1 = value;
				this.double_5 = MeasuringHelper.Twips2EMU(this.double_1);
			}
		}

		internal double Double_2
		{
			get
			{
				return this.double_3;
			}
			set
			{
				this.double_3 = value;
				this.double_7 = MeasuringHelper.Twips2EMU(this.double_3);
			}
		}

		internal double Double_3
		{
			get
			{
				return this.double_2;
			}
			set
			{
				this.double_2 = value;
				this.double_6 = MeasuringHelper.Twips2EMU(this.double_2);
			}
		}

		internal double Double_4
		{
			get
			{
				return this.double_4;
			}
			set
			{
				this.double_4 = value;
				this.double_0 = MeasuringHelper.EMU2Twips(this.double_4);
			}
		}

		internal double Double_5
		{
			get
			{
				return this.double_5;
			}
			set
			{
				this.double_5 = value;
				this.double_1 = MeasuringHelper.EMU2Twips(this.double_5);
			}
		}

		internal double Double_6
		{
			get
			{
				return this.double_7;
			}
			set
			{
				this.double_7 = value;
				this.double_3 = MeasuringHelper.EMU2Twips(this.double_7);
			}
		}

		internal double Double_7
		{
			get
			{
				return this.double_6;
			}
			set
			{
				this.double_6 = value;
				this.double_2 = MeasuringHelper.EMU2Twips(this.double_6);
			}
		}

		internal Class177 Class177_0
		{
			get
			{
				return new Class177(this.double_0, this.double_1, bool_1: false);
			}
			set
			{
				this.double_0 = value.Double_0;
				this.double_4 = MeasuringHelper.Twips2EMU(this.double_0);
				this.double_1 = value.Double_1;
				this.double_5 = MeasuringHelper.Twips2EMU(this.double_1);
			}
		}

		internal Class179 Class179_0
		{
			get
			{
				return new Class179(this.double_2, this.double_3, bool_1: false);
			}
			set
			{
				this.double_2 = value.Double_1;
				this.double_3 = value.Double_0;
				this.double_6 = MeasuringHelper.Twips2EMU(this.double_2);
				this.double_7 = MeasuringHelper.Twips2EMU(this.double_3);
			}
		}

		internal Class177 Class177_1
		{
			get
			{
				return new Class177(this.double_4, this.double_5, bool_1: true);
			}
			set
			{
				this.double_4 = value.Double_2;
				this.double_0 = MeasuringHelper.EMU2Twips(this.double_4);
				this.double_5 = value.Double_3;
				this.double_1 = MeasuringHelper.EMU2Twips(this.double_5);
			}
		}

		internal Class179 Class179_1
		{
			get
			{
				return new Class179(this.double_6, this.double_7, bool_1: true);
			}
			set
			{
				this.double_6 = value.Double_3;
				this.double_7 = value.Double_2;
				this.double_2 = MeasuringHelper.EMU2Twips(this.double_6);
				this.double_3 = MeasuringHelper.EMU2Twips(this.double_7);
			}
		}

		internal double Double_8 => this.double_1 + this.double_3;

		internal double Double_9 => this.double_0;

		internal double Double_10 => this.double_0 + this.double_2;

		internal double Double_11 => this.double_1;

		internal double Double_12 => this.double_5 + this.double_7;

		internal double Double_13 => this.double_4;

		internal double Double_14 => this.double_4 + this.double_6;

		internal double Double_15 => this.double_5;

		internal Class177 Class177_2 => new Class177(this.Double_9, this.Double_8, bool_1: false);

		internal Class177 Class177_3 => new Class177(this.Double_9 + this.Double_3 / 2.0, this.Double_8, bool_1: false);

		internal Class177 Class177_4 => new Class177(this.Double_10, this.Double_8, bool_1: false);

		internal Class177 Class177_5 => new Class177(this.Double_9, this.Double_11 + this.Double_2 / 2.0, bool_1: false);

		internal Class177 Class177_6 => new Class177(this.Double_10, this.Double_11 + this.Double_2 / 2.0, bool_1: false);

		internal Class177 Class177_7 => new Class177(this.Double_9, this.Double_11, bool_1: false);

		internal Class177 Class177_8 => new Class177(this.Double_9 + this.Double_3 / 2.0, this.Double_11, bool_1: false);

		internal Class177 Class177_9 => new Class177(this.Double_10, this.Double_11, bool_1: false);

		internal Class177 Class177_10 => new Class177(this.Double_13, this.Double_12, bool_1: true);

		internal Class177 Class177_11 => new Class177(this.Double_14 / 2.0, this.Double_12, bool_1: true);

		internal Class177 Class177_12 => new Class177(this.Double_14, this.Double_12, bool_1: true);

		internal Class177 Class177_13 => new Class177(this.Double_13, this.Double_12 / 2.0, bool_1: true);

		internal Class177 Class177_14 => new Class177(this.Double_14, this.Double_12 / 2.0, bool_1: true);

		internal Class177 Class177_15 => new Class177(this.Double_13, this.Double_15, bool_1: true);

		internal Class177 Class177_16 => new Class177(this.Double_14 / 2.0, this.Double_15, bool_1: true);

		internal Class177 Class177_17 => new Class177(this.Double_14, this.Double_15, bool_1: true);

		internal Class178(double double_8, double double_9, double double_10, double double_11, bool bool_1)
		{
			if (this.bool_0 = bool_1)
			{
				this.double_4 = double_8;
				this.double_5 = double_9;
				this.double_6 = double_10;
				this.double_7 = double_11;
				this.double_0 = MeasuringHelper.EMU2Twips(this.double_4);
				this.double_1 = MeasuringHelper.EMU2Twips(this.double_5);
				this.double_2 = MeasuringHelper.EMU2Twips(this.double_6);
				this.double_3 = MeasuringHelper.EMU2Twips(this.double_7);
			}
			else
			{
				this.double_0 = double_8;
				this.double_1 = double_9;
				this.double_2 = double_10;
				this.double_3 = double_11;
				this.double_4 = MeasuringHelper.Twips2EMU(double_8);
				this.double_5 = MeasuringHelper.Twips2EMU(double_9);
				this.double_6 = MeasuringHelper.Twips2EMU(double_10);
				this.double_7 = MeasuringHelper.Twips2EMU(double_11);
			}
		}

		internal Class178(Class177 class177_0, Class179 class179_0)
		{
			this.double_0 = class177_0.Double_0;
			this.double_1 = class177_0.Double_1;
			this.double_2 = class179_0.Double_1;
			this.double_3 = class179_0.Double_0;
			this.double_4 = MeasuringHelper.Twips2EMU(this.double_0);
			this.double_5 = MeasuringHelper.Twips2EMU(this.double_1);
			this.double_6 = MeasuringHelper.Twips2EMU(this.double_2);
			this.double_7 = MeasuringHelper.Twips2EMU(this.double_3);
			this.bool_0 = false;
		}

		internal bool? method_0(Class178 class178_0, double double_8)
		{
			bool flag = true;
			bool? result = true;
			double num = 0.0;
			if (flag = (((num = Math.Abs(Math.Round(this.Double_9, MidpointRounding.ToEven) - Math.Round(class178_0.Double_9, MidpointRounding.ToEven))) <= double_8) ? true : false))
			{
				if (result.HasValue && num > 0.0)
				{
					result = null;
				}
			}
			else
			{
				result = false;
			}
			if (flag = ((flag && !((num = Math.Abs(Math.Round(this.Double_11, MidpointRounding.ToEven) - Math.Round(class178_0.Double_11, MidpointRounding.ToEven))) > double_8)) ? true : false))
			{
				if (result.HasValue && num > 0.0)
				{
					result = null;
				}
			}
			else
			{
				result = false;
			}
			if (flag = ((flag && !((num = Math.Abs(Math.Round(this.Double_10, MidpointRounding.ToEven) - Math.Round(class178_0.Double_10, MidpointRounding.ToEven))) > double_8)) ? true : false))
			{
				if (result.HasValue && num > 0.0)
				{
					result = null;
				}
			}
			else
			{
				result = false;
			}
			if (flag = ((flag && !((num = Math.Abs(Math.Round(this.Double_8, MidpointRounding.ToEven) - Math.Round(class178_0.Double_8, MidpointRounding.ToEven))) > double_8)) ? true : false))
			{
				if (result.HasValue && num > 0.0)
				{
					result = null;
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		internal bool method_1(Class177 class177_0)
		{
			if (class177_0.Boolean_0)
			{
				if (!(class177_0.Double_2 < this.Double_13) && !(class177_0.Double_2 > this.Double_14) && !(class177_0.Double_3 < this.Double_15) && class177_0.Double_3 <= this.Double_12)
				{
					return true;
				}
				return false;
			}
			if (!(class177_0.Double_0 < this.Double_9) && !(class177_0.Double_0 > this.Double_10) && !(class177_0.Double_1 < this.Double_11) && class177_0.Double_1 <= this.Double_8)
			{
				return true;
			}
			return false;
		}

		internal bool method_2(Class178 class178_0)
		{
			if (this.Double_0 <= class178_0.Double_0 && this.Double_1 <= class178_0.Double_1 && this.Double_3 >= class178_0.Double_3)
			{
				return this.Double_2 >= class178_0.Double_2;
			}
			return false;
		}
	}
}
