using System;
using ns17;

namespace TXTextControl.Drawing
{
	internal abstract class AdjustObject
	{
		protected Class173 m_arAdjustRectangle;

		protected double m_dMin;

		protected double m_dMax;

		protected double m_dValue;

		protected double m_dDefaultValue;

		protected string m_strAdjustPropertyName;

		protected bool m_bPosInOpositeDirection;

		protected Type m_tShapeObject;

		protected Shape m_isShape;

		internal string AdjustPropertyName => this.m_strAdjustPropertyName;

		internal Class173 AdjustRectangle
		{
			get
			{
				return this.m_arAdjustRectangle;
			}
			set
			{
				this.m_arAdjustRectangle = value;
			}
		}

		internal double DefaultValue
		{
			get
			{
				return this.m_dDefaultValue;
			}
			set
			{
				this.m_dDefaultValue = value;
			}
		}

		internal double Max => this.m_dMax;

		internal double Min => this.m_dMin;

		internal bool PosInOpositeDirection => this.m_bPosInOpositeDirection;

		internal double Value
		{
			get
			{
				return this.m_dValue;
			}
			set
			{
				this.m_dValue = value;
				switch (this.m_strAdjustPropertyName)
				{
				case "Adj":
					this.m_isShape.Class183_0.ShapeObject_0.Adj = this.m_dValue;
					break;
				case "Adj1":
					this.m_isShape.Class183_0.ShapeObject_0.Adj1 = this.m_dValue;
					break;
				case "Adj2":
					this.m_isShape.Class183_0.ShapeObject_0.Adj2 = this.m_dValue;
					break;
				case "Adj3":
					this.m_isShape.Class183_0.ShapeObject_0.Adj3 = this.m_dValue;
					break;
				case "Adj4":
					this.m_isShape.Class183_0.ShapeObject_0.Adj4 = this.m_dValue;
					break;
				case "Adj5":
					this.m_isShape.Class183_0.ShapeObject_0.Adj5 = this.m_dValue;
					break;
				case "Adj6":
					this.m_isShape.Class183_0.ShapeObject_0.Adj6 = this.m_dValue;
					break;
				case "Adj7":
					this.m_isShape.Class183_0.ShapeObject_0.Adj7 = this.m_dValue;
					break;
				case "Adj8":
					this.m_isShape.Class183_0.ShapeObject_0.Adj8 = this.m_dValue;
					break;
				case "HF":
					this.m_isShape.Class183_0.ShapeObject_0.Double_0 = this.m_dValue;
					break;
				case "VF":
					this.m_isShape.Class183_0.ShapeObject_0.Double_1 = this.m_dValue;
					break;
				}
				this.m_isShape.TXDrawing_0.method_77();
			}
		}
	}
}
