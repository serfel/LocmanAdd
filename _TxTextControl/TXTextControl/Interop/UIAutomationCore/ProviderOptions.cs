using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Interop.UIAutomationCore
{
	[CompilerGenerated]
	[TypeIdentifier("930299CE-9965-4DEC-B0F4-A54848D4B667", "Interop.UIAutomationCore.ProviderOptions")]
	public enum ProviderOptions
	{
		ProviderOptions_ClientSideProvider = 1,
		ProviderOptions_ServerSideProvider = 2,
		ProviderOptions_NonClientAreaProvider = 4,
		ProviderOptions_OverrideProvider = 8,
		ProviderOptions_ProviderOwnsSetFocus = 0x10,
		ProviderOptions_UseComThreading = 0x20,
		ProviderOptions_RefuseNonClientSupport = 0x40,
		ProviderOptions_HasNativeIAccessible = 0x80,
		ProviderOptions_UseClientCoordinates = 0x100
	}
}
