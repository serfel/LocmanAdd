using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Interop.UIAutomationCore;
using TXTextControl;

namespace ns27
{
	[ComVisible(true)]
	internal class Class603 : RawFragmentRootProvider
	{
		private TextControl textControl_0;

		private Class607 class607_0;

		internal List<Class604> list_0 = new List<Class604>();

		private IRawElementProviderSimple irawElementProviderSimple_0;

		public override ProviderOptions ProviderOptions => (ProviderOptions)34;

		internal Class603(TextControl textControl_1)
		{
			this.textControl_0 = textControl_1;
			this.class607_0 = new Class607(textControl_1, TextPart.MainText, this);
			this.method_1();
			this.irawElementProviderSimple_0 = this;
			base.AddStaticProperty(30005, "");
			base.AddStaticProperty(30012, "TXTextControl.TextControl");
			base.AddStaticProperty(30003, 50030);
			base.AddStaticProperty(30107, "TXTextControl Document");
			base.AddStaticProperty(30011, this.textControl_0.Name);
			base.AddStaticProperty(30009, true);
			base.AddStaticProperty(30016, true);
			base.AddStaticProperty(30017, true);
			this.textControl_0.FocusChanged += method_0;
			this.textControl_0.TextFrameActivated += textControl_0_TextFrameActivated;
			this.textControl_0.HeaderFooterActivated += textControl_0_HeaderFooterActivated;
			this.textControl_0.InputPositionChanged += textControl_0_InputPositionChanged;
			this.textControl_0.Changed += textControl_0_Changed;
			this.textControl_0.TextFrameCreated += textControl_0_TextFrameDeleted;
			this.textControl_0.TextFrameDeleted += textControl_0_TextFrameDeleted;
			this.textControl_0.HeaderFooterCreated += textControl_0_TextFrameDeleted;
			this.textControl_0.HeaderFooterDeleted += textControl_0_TextFrameDeleted;
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
			return this.textControl_0.Handle;
		}

		protected override IRawElementProviderFragment GetFirstChild()
		{
			if (this.list_0.Count > 0)
			{
				return this.list_0[0];
			}
			return null;
		}

		protected override IRawElementProviderFragment GetLastChild()
		{
			int count = this.list_0.Count;
			if (count > 0)
			{
				return this.list_0[count - 1];
			}
			return null;
		}

		private void textControl_0_Changed(object sender, EventArgs e)
		{
			Class605.UiaRaiseAutomationEvent(this.irawElementProviderSimple_0, 20015);
		}

		private void textControl_0_InputPositionChanged(object sender, EventArgs e)
		{
			Class605.UiaRaiseAutomationEvent(this.irawElementProviderSimple_0, 20014);
		}

		private void method_0(object sender, EventArgs e)
		{
			this.method_2(TextPart.MainText);
		}

		private void textControl_0_HeaderFooterActivated(object sender, HeaderFooterEventArgs e)
		{
			this.method_2(e.HeaderFooter.method_0());
		}

		private void textControl_0_TextFrameActivated(object sender, TextFrameEventArgs e)
		{
			this.method_2(e.TextFrame.method_6());
		}

		private void textControl_0_TextFrameDeleted(object sender, EventArgs e)
		{
			this.method_1();
		}

		private void method_1()
		{
			this.list_0.Clear();
			TextPartCollection textParts = this.textControl_0.TextParts;
			if (textParts != null)
			{
				int num = 0;
				foreach (object textPart in this.textControl_0.TextParts)
				{
					if (textPart is HeaderFooter)
					{
						this.list_0.Add(new Class604(this.textControl_0, ((HeaderFooter)textPart).method_0(), this, ((HeaderFooter)textPart).IntPtr_0, num++));
					}
					else if (textPart is TextFrame)
					{
						this.list_0.Add(new Class604(this.textControl_0, ((TextFrame)textPart).method_6(), this, ((TextFrame)textPart).IntPtr_0, num++));
					}
				}
			}
			Class605.UiaRaiseAutomationEvent(this, 20002);
		}

		private void method_2(TextPart textPart_0)
		{
			this.irawElementProviderSimple_0 = this.method_3(textPart_0);
			Class605.UiaRaiseAutomationEvent(this.irawElementProviderSimple_0, 20005);
		}

		internal IRawElementProviderSimple method_3(TextPart textPart_0)
		{
			IRawElementProviderSimple result = null;
			if (textPart_0 == TextPart.MainText)
			{
				result = this;
			}
			foreach (Class604 item in this.list_0)
			{
				if (item.textPart_0 == textPart_0)
				{
					result = item;
				}
			}
			return result;
		}
	}
}
