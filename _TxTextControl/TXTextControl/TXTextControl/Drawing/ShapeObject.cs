using System;
using ns17;

namespace TXTextControl.Drawing
{
	internal abstract class ShapeObject
	{
		protected double _3cd4;

		protected double _3cd8;

		protected double _5cd8;

		protected double _7cd8;

		protected double double_0;

		protected double cd2;

		protected double cd4;

		protected double cd8;

		protected double double_1;

		protected double double_2;

		protected double hd2;

		protected double hd3;

		protected double hd4;

		protected double hd5;

		protected double hd6;

		protected double hd8;

		protected double hd10;

		protected double hd12;

		protected double hd32;

		protected double double_3;

		protected double double_4;

		protected double double_5;

		protected double double_6;

		protected double ssd2;

		protected double ssd4;

		protected double ssd6;

		protected double ssd8;

		protected double ssd16;

		protected double ssd32;

		protected double t;

		protected double double_7;

		protected double double_8;

		protected double wd2;

		protected double wd3;

		protected double wd4;

		protected double wd5;

		protected double wd6;

		protected double wd8;

		protected double wd10;

		protected double wd12;

		protected double wd32;

		protected double adj;

		protected double adj1;

		protected double adj2;

		protected double adj3;

		protected double adj4;

		protected double adj5;

		protected double adj6;

		protected double adj7;

		protected double adj8;

		protected double double_9;

		protected double double_10;

		private bool saveHF;

		private bool saveVF;

		protected Class177 ipt2;

		protected Class177 ipt3;

		protected Class177 ipt4;

		protected Shape shape;

		internal double Adj
		{
			get
			{
				return this.adj;
			}
			set
			{
				this.adj = value;
			}
		}

		internal double Adj1
		{
			get
			{
				return this.adj1;
			}
			set
			{
				this.adj1 = value;
			}
		}

		internal double Adj2
		{
			get
			{
				return this.adj2;
			}
			set
			{
				this.adj2 = value;
			}
		}

		internal double Adj3
		{
			get
			{
				return this.adj3;
			}
			set
			{
				this.adj3 = value;
			}
		}

		internal double Adj4
		{
			get
			{
				return this.adj4;
			}
			set
			{
				this.adj4 = value;
			}
		}

		internal double Adj5
		{
			get
			{
				return this.adj5;
			}
			set
			{
				this.adj5 = value;
			}
		}

		internal double Adj6
		{
			get
			{
				return this.adj6;
			}
			set
			{
				this.adj6 = value;
			}
		}

		internal double Adj7
		{
			get
			{
				return this.adj7;
			}
			set
			{
				this.adj7 = value;
			}
		}

		internal double Adj8
		{
			get
			{
				return this.adj8;
			}
			set
			{
				this.adj8 = value;
			}
		}

		internal double Double_0
		{
			get
			{
				return this.double_9;
			}
			set
			{
				this.double_9 = value;
			}
		}

		internal double Double_1
		{
			get
			{
				return this.double_10;
			}
			set
			{
				this.double_10 = value;
			}
		}

		internal bool SaveHF
		{
			get
			{
				return this.saveHF;
			}
			set
			{
				this.saveHF = value;
			}
		}

		internal bool SaveVF
		{
			get
			{
				return this.saveVF;
			}
			set
			{
				this.saveVF = value;
			}
		}

		internal Shape Shape => this.shape;

		protected void CreateBaseVariables(Shape shape)
		{
			this._3cd4 = Helper.GetDrawingMLEnumValue("3cd4", shape);
			this._3cd8 = Helper.GetDrawingMLEnumValue("3cd8", shape);
			this._5cd8 = Helper.GetDrawingMLEnumValue("5cd8", shape);
			this._7cd8 = Helper.GetDrawingMLEnumValue("7cd8", shape);
			this.double_0 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("b", shape));
			this.cd2 = Helper.GetDrawingMLEnumValue("cd2", shape);
			this.cd4 = Helper.GetDrawingMLEnumValue("cd4", shape);
			this.cd8 = Helper.GetDrawingMLEnumValue("cd8", shape);
			this.double_1 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("h", shape));
			this.double_2 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("hc", shape));
			this.hd2 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("hd2", shape));
			this.hd3 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("hd3", shape));
			this.hd4 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("hd4", shape));
			this.hd5 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("hd5", shape));
			this.hd6 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("hd6", shape));
			this.hd8 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("hd8", shape));
			this.hd10 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("hd10", shape));
			this.hd12 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("hd12", shape));
			this.hd32 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("hd32", shape));
			this.double_3 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("l", shape));
			this.double_4 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("ls", shape));
			this.double_5 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("r", shape));
			this.double_6 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("ss", shape));
			this.ssd2 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("ssd2", shape));
			this.ssd4 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("ssd4", shape));
			this.ssd6 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("ssd6", shape));
			this.ssd8 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("ssd8", shape));
			this.ssd16 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("ssd16", shape));
			this.ssd32 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("ssd32", shape));
			this.t = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("t", shape));
			this.double_7 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("vc", shape));
			this.double_8 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("w", shape));
			this.wd2 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("wd2", shape));
			this.wd3 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("wd3", shape));
			this.wd4 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("wd4", shape));
			this.wd5 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("wd5", shape));
			this.wd6 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("wd6", shape));
			this.wd8 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("wd8", shape));
			this.wd10 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("wd10", shape));
			this.wd12 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("wd12", shape));
			this.wd32 = MeasuringHelper.Twips2EMU(Helper.GetDrawingMLEnumValue("wd32", shape));
		}

		protected void SetLoadedAvLstValues(Shape shape)
		{
			if (shape.Class174_0.Dictionary_0 == null)
			{
				return;
			}
			foreach (string key in shape.Class174_0.Dictionary_0.Keys)
			{
				switch (key)
				{
				case "adj":
					this.adj = Convert.ToInt32(shape.Class174_0.Dictionary_0[key]);
					break;
				case "adj1":
					this.adj1 = Convert.ToInt32(shape.Class174_0.Dictionary_0[key]);
					break;
				case "adj2":
					this.adj2 = Convert.ToInt32(shape.Class174_0.Dictionary_0[key]);
					break;
				case "adj3":
					this.adj3 = Convert.ToInt32(shape.Class174_0.Dictionary_0[key]);
					break;
				case "adj4":
					this.adj4 = Convert.ToInt32(shape.Class174_0.Dictionary_0[key]);
					break;
				case "adj5":
					this.adj5 = Convert.ToInt32(shape.Class174_0.Dictionary_0[key]);
					break;
				case "adj6":
					this.adj6 = Convert.ToInt32(shape.Class174_0.Dictionary_0[key]);
					break;
				case "adj7":
					this.adj7 = Convert.ToInt32(shape.Class174_0.Dictionary_0[key]);
					break;
				case "adj8":
					this.adj8 = Convert.ToInt32(shape.Class174_0.Dictionary_0[key]);
					break;
				case "hf":
					this.double_9 = Convert.ToInt32(shape.Class174_0.Dictionary_0[key]);
					break;
				case "vf":
					this.double_10 = Convert.ToInt32(shape.Class174_0.Dictionary_0[key]);
					break;
				}
			}
		}

		internal abstract void CreateGraphicsPaths();
	}
}
