using System;
using System.Drawing;
using ns21;

namespace TXTextControl.ServerVisualisation
{
	public class ColorBase
	{
		protected Color[] m_aiDefColors;

		protected Color[] m_aiColors;

		private IntPtr intptr_0 = IntPtr.Zero;

		private int int_0;

		private int int_1;

		private int int_2;

		internal ColorBase(int iColors, int iGetMessage, int iSetMessage)
		{
			this.int_0 = iColors;
			this.int_1 = iGetMessage;
			this.int_2 = iSetMessage;
			this.m_aiDefColors = new Color[this.int_0];
			this.m_aiColors = new Color[this.int_0];
			for (int i = 0; i < this.int_0; i++)
			{
				ref Color reference = ref this.m_aiColors[i];
				reference = Color.Empty;
			}
			for (int j = 0; j < this.int_0; j++)
			{
				ref Color reference2 = ref this.m_aiDefColors[j];
				reference2 = Color.Empty;
			}
		}

		internal void method_0()
		{
			if (!(this.intptr_0 == IntPtr.Zero))
			{
				int[] array = new int[this.int_0];
				for (int i = 0; i < this.int_0; i++)
				{
					array[i] = ((this.m_aiColors[i] == Color.Empty) ? 1073741824 : Class429.smethod_0(this.m_aiColors[i]));
				}
				Class429.SendMessage_7(this.intptr_0, this.int_2, this.int_0, array);
			}
		}

		internal void method_1()
		{
			if (!(this.intptr_0 == IntPtr.Zero))
			{
				int[] array = new int[2 * this.int_0];
				Class429.SendMessage_7(this.intptr_0, this.int_1, 2 * this.int_0, array);
				int num = 0;
				int num2 = this.m_aiColors.Length;
				while (num < this.int_0)
				{
					ref Color reference = ref this.m_aiDefColors[num];
					reference = ((array[num2] == int.MinValue) ? Color.Transparent : Class429.smethod_2(array[num2]));
					num++;
					num2++;
				}
			}
		}

		internal void method_2(ColorBase colorBase_0)
		{
			for (int i = 0; i < this.m_aiColors.Length; i++)
			{
				ref Color reference = ref colorBase_0.m_aiColors[i];
				reference = this.m_aiColors[i];
			}
		}

		internal void method_3()
		{
			for (int i = 0; i < this.m_aiColors.Length; i++)
			{
				ref Color reference = ref this.m_aiColors[i];
				reference = Color.Empty;
			}
			this.method_0();
		}

		internal bool method_4()
		{
			int num = 0;
			while (true)
			{
				if (num < this.m_aiColors.Length)
				{
					if (this.m_aiColors[num] != Color.Empty)
					{
						break;
					}
					num++;
					continue;
				}
				return true;
			}
			return false;
		}

		internal void method_5(IntPtr intptr_1)
		{
			this.intptr_0 = intptr_1;
			this.method_0();
		}

		protected Color GetColor(int index)
		{
			this.method_1();
			if (!(this.m_aiColors[index] == Color.Empty))
			{
				return this.m_aiColors[index];
			}
			return this.m_aiDefColors[index];
		}

		protected void SetColor(Color color, int index)
		{
			this.m_aiColors[index] = color;
			this.method_0();
		}
	}
}
