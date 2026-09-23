namespace ns0
{
	internal class Class22
	{
		internal static Class33 smethod_0(Class34 class34_0, float float_0, float float_1)
		{
			return new Class33((float)class34_0.int_0 * 1440f / float_0, (float)class34_0.int_1 * 1440f / float_1);
		}

		internal static Class40 smethod_1(Class40 class40_0, float float_0, float float_1)
		{
			return new Class40((int)(class40_0.float_0 * 1440f / float_0), (int)(class40_0.float_1 * 1440f / float_1), (int)(class40_0.float_2 * 1440f / float_0), (int)(class40_0.float_3 * 1440f / float_1));
		}

		internal static float smethod_2(float float_0, float float_1)
		{
			return float_0 * 1440f / float_1;
		}

		internal static Class23 smethod_3(Class25 class25_0, float float_0, float float_1)
		{
			return new Class23((float)(int)class25_0.double_0 * 1440f / float_0, (float)(int)class25_0.double_1 * 1440f / float_1);
		}

		internal static Class23 smethod_4(Class23 class23_0, float float_0, float float_1)
		{
			return new Class23(class23_0.float_0 * 1440f / float_0, class23_0.float_1 * 1440f / float_1);
		}

		internal static Class23 smethod_5(Class24 class24_0, float float_0, float float_1)
		{
			return new Class23((float)class24_0.double_0 * 1440f / float_0, (float)class24_0.double_1 * 1440f / float_1);
		}

		internal static float smethod_6(float float_0, float float_1)
		{
			return float_1 * float_0 / 1440f;
		}

		internal static Class25 smethod_7(Class23 class23_0, float float_0, float float_1)
		{
			return new Class25((int)(float_0 * class23_0.float_0 / 1440f), (int)(float_1 * class23_0.float_1 / 1440f));
		}

		internal static Class34 smethod_8(Class33 class33_0, float float_0, float float_1)
		{
			return new Class34((int)(float_0 * class33_0.float_0 / 1440f), (int)(float_1 * class33_0.float_1 / 1440f));
		}
	}
}
