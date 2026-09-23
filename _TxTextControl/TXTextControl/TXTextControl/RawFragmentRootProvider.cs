using System.Runtime.InteropServices;
using Interop.UIAutomationCore;

namespace TXTextControl
{
	[ComVisible(true)]
	internal abstract class RawFragmentRootProvider : RawFragmentProvider, IRawElementProviderFragmentRoot
	{
		public override UiaRect BoundingRectangle => default(UiaRect);

		internal RawFragmentRootProvider()
			: base(null, null)
		{
			base.m_FragmentRoot = this;
		}

		public virtual IRawElementProviderFragment ElementProviderFromPoint(double x, double y)
		{
			return null;
		}

		public virtual IRawElementProviderFragment GetFocus()
		{
			return null;
		}

		public override int[] GetRuntimeId()
		{
			return null;
		}
	}
}
