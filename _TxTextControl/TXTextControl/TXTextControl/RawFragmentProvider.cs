using System.Runtime.InteropServices;
using Interop.UIAutomationCore;

namespace TXTextControl
{
	[ComVisible(true)]
	internal abstract class RawFragmentProvider : RawSimpleProvider, IRawElementProviderFragment
	{
		protected IRawElementProviderFragment m_Parent;

		protected IRawElementProviderFragmentRoot m_FragmentRoot;

		public IRawElementProviderFragmentRoot FragmentRoot => this.m_FragmentRoot;

		public abstract UiaRect BoundingRectangle { get; }

		internal RawFragmentProvider(IRawElementProviderFragment parent, IRawElementProviderFragmentRoot fragmentRoot)
		{
			this.m_Parent = parent;
			this.m_FragmentRoot = fragmentRoot;
		}

		public abstract int[] GetRuntimeId();

		public virtual IRawElementProviderFragmentRoot[] GetEmbeddedFragmentRoots()
		{
			return null;
		}

		public virtual void SetFocus()
		{
		}

		public IRawElementProviderFragment Navigate(NavigateDirection direction)
		{
			return direction switch
			{
				NavigateDirection.NavigateDirection_Parent => this.m_Parent, 
				NavigateDirection.NavigateDirection_NextSibling => this.GetNextSibling(), 
				NavigateDirection.NavigateDirection_PreviousSibling => this.GetPreviousSibling(), 
				NavigateDirection.NavigateDirection_FirstChild => this.GetFirstChild(), 
				NavigateDirection.NavigateDirection_LastChild => this.GetLastChild(), 
				_ => null, 
			};
		}

		protected virtual IRawElementProviderFragment GetFirstChild()
		{
			return null;
		}

		protected virtual IRawElementProviderFragment GetLastChild()
		{
			return null;
		}

		protected virtual IRawElementProviderFragment GetNextSibling()
		{
			return null;
		}

		protected virtual IRawElementProviderFragment GetPreviousSibling()
		{
			return null;
		}
	}
}
