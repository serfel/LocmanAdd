using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Interop.UIAutomationCore;
using ns27;

namespace TXTextControl
{
	[ComVisible(true)]
	internal abstract class RawSimpleProvider : IRawElementProviderSimple
	{
		private Dictionary<int, object> m_staticProps = new Dictionary<int, object>();

		public virtual ProviderOptions ProviderOptions => ProviderOptions.ProviderOptions_ServerSideProvider;

		public IRawElementProviderSimple HostRawElementProvider
		{
			get
			{
				IntPtr windowHandle = this.GetWindowHandle();
				if (windowHandle != IntPtr.Zero)
				{
					IRawElementProviderSimple irawElementProviderSimple_ = null;
					Class605.UiaHostProviderFromHwnd(windowHandle, out irawElementProviderSimple_);
					return irawElementProviderSimple_;
				}
				return null;
			}
		}

		public virtual object GetPatternProvider(int patternId)
		{
			return null;
		}

		public virtual object GetPropertyValue(int propertyId)
		{
			if (this.m_staticProps.ContainsKey(propertyId))
			{
				return this.m_staticProps[propertyId];
			}
			return null;
		}

		protected virtual IntPtr GetWindowHandle()
		{
			return IntPtr.Zero;
		}

		protected void AddStaticProperty(int propertyId, object value)
		{
			this.m_staticProps.Add(propertyId, value);
		}

		dynamic IRawElementProviderSimple.GetPatternProvider(int patternId)
		{
			return this.GetPatternProvider(patternId);
		}

		dynamic IRawElementProviderSimple.GetPropertyValue(int propertyId)
		{
			return this.GetPropertyValue(propertyId);
		}
	}
}
