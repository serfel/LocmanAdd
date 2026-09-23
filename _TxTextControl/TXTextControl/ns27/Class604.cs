using System;
using System.Runtime.InteropServices;
using Interop.UIAutomationCore;
using ns21;
using TXTextControl;

namespace ns27
{
	[ComVisible(true)]
	internal class Class604 : RawFragmentProvider
	{
		private int int_0;

		private TextControl textControl_0;

		private Class607 class607_0;

		internal TextPart textPart_0;

		private IntPtr intptr_0 = IntPtr.Zero;

		public override ProviderOptions ProviderOptions => (ProviderOptions)34;

		public override UiaRect BoundingRectangle
		{
			get
			{
				UiaRect result = default(UiaRect);
				_ = this.intptr_0 == IntPtr.Zero;
				return result;
			}
		}

		internal Class604(TextControl textControl_1, TextPart textPart_1, IRawElementProviderFragmentRoot irawElementProviderFragmentRoot_0, IntPtr intptr_1, int int_1)
			: base((IRawElementProviderFragment)irawElementProviderFragmentRoot_0, irawElementProviderFragmentRoot_0)
		{
			this.textControl_0 = textControl_1;
			this.int_0 = int_1;
			this.textPart_0 = textPart_1;
			this.intptr_0 = intptr_1;
			this.class607_0 = new Class607(textControl_1, this.textPart_0, this);
			if (Class429.smethod_5((int)this.textPart_0) == 0)
			{
				base.AddStaticProperty(30005, "");
				base.AddStaticProperty(30107, "TXTextControl Text Frame");
				base.AddStaticProperty(30012, "TXTextControl.TextFrame");
				base.AddStaticProperty(30011, this.textControl_0.Name + " TextFrame " + Class429.smethod_6((int)this.textPart_0));
			}
			else
			{
				base.AddStaticProperty(30005, "");
				base.AddStaticProperty(30107, "TXTextControl Header or Footer");
				base.AddStaticProperty(30012, "TXTextControl.HeaderFooter");
				base.AddStaticProperty(30011, this.textControl_0.Name + " HeaderFooter");
			}
			base.AddStaticProperty(30003, 50004);
			base.AddStaticProperty(30009, true);
			base.AddStaticProperty(30016, true);
			base.AddStaticProperty(30017, false);
		}

		public override object GetPatternProvider(int patternId)
		{
			if (patternId != 10002 && patternId != 10014)
			{
				return base.GetPatternProvider(patternId);
			}
			return this.class607_0;
		}

		protected override IntPtr GetWindowHandle()
		{
			return this.intptr_0;
		}

		public override int[] GetRuntimeId()
		{
			if (this.intptr_0 == IntPtr.Zero)
			{
				return new int[2] { 3, this.int_0 };
			}
			return null;
		}

		protected override IRawElementProviderFragment GetNextSibling()
		{
			Class603 @class = base.m_FragmentRoot as Class603;
			if (@class != null)
			{
				int count = @class.list_0.Count;
				if (this.int_0 < count - 1)
				{
					return @class.list_0[this.int_0 + 1];
				}
			}
			return null;
		}

		protected override IRawElementProviderFragment GetPreviousSibling()
		{
			if (this.int_0 > 0)
			{
				Class603 @class = base.m_FragmentRoot as Class603;
				return @class.list_0[this.int_0 - 1];
			}
			return null;
		}
	}
}
