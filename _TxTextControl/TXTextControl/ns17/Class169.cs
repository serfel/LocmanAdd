using TXTextControl.Drawing;

namespace ns17
{
	internal class Class169 : AdjustObject
	{
		internal Class169(Class177 class177_0, string string_0, double double_0, double double_1, double double_2, Shape shape_0, bool bool_0)
		{
			base.m_arAdjustRectangle = new Class173(new Class178(class177_0, new Class179(120.0, 120.0, bool_1: false)));
			base.m_strAdjustPropertyName = string_0;
			base.m_dMin = double_0;
			base.m_dMax = double_1;
			base.m_dDefaultValue = (base.m_dValue = double_2);
			base.m_isShape = shape_0;
			base.m_tShapeObject = base.m_isShape.Class183_0.ShapeObject_0.GetType();
			base.m_bPosInOpositeDirection = bool_0;
		}
	}
}
