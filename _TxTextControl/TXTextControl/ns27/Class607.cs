using System;
using System.Drawing;
using Interop.UIAutomationCore;
using ns21;
using TXTextControl;

namespace ns27
{
	internal class Class607 : ITextProvider, IValueProvider
	{
		private IRawElementProviderSimple irawElementProviderSimple_0;

		private TextControl textControl_0;

		private TextPart textPart_0;

		ITextRangeProvider ITextProvider.DocumentRange
		{
			get
			{
				if (!this.textControl_0.textControlCore_0.isHandleCreated)
				{
					return null;
				}
				int int_ = this.textControl_0.textControlCore_0.method_29(this.textPart_0, 1136, 0, 0);
				return new Class608(this.textControl_0, 0, int_, this.textPart_0, this.irawElementProviderSimple_0);
			}
		}

		SupportedTextSelection ITextProvider.SupportedTextSelection => SupportedTextSelection.SupportedTextSelection_Single;

		int IValueProvider.IsReadOnly
		{
			get
			{
				if (this.textControl_0.EditMode != EditMode.Edit)
				{
					return 1;
				}
				return 0;
			}
		}

		string IValueProvider.Value
		{
			get
			{
				string string_ = "";
				SaveSettings saveSettings = new SaveSettings();
				saveSettings.TextPart = this.textPart_0;
				SaveSettings saveSettings2 = saveSettings;
				saveSettings2.method_4(out string_, StringStreamType.PlainText, this.textControl_0.textControlCore_0, Enum104.const_0);
				return string_;
			}
		}

		internal Class607(TextControl textControl_1, TextPart textPart_1, IRawElementProviderSimple irawElementProviderSimple_1)
		{
			this.textControl_0 = textControl_1;
			this.textPart_0 = textPart_1;
			this.irawElementProviderSimple_0 = irawElementProviderSimple_1;
		}

		ITextRangeProvider[] ITextProvider.GetSelection()
		{
			if (!this.textControl_0.textControlCore_0.isHandleCreated)
			{
				return null;
			}
			this.textControl_0.textControlCore_0.method_7(this.textPart_0, out var int_, out var int_2);
			return new ITextRangeProvider[1]
			{
				new Class608(this.textControl_0, int_, int_ + int_2, this.textPart_0, this.irawElementProviderSimple_0)
			};
		}

		ITextRangeProvider[] ITextProvider.GetVisibleRanges()
		{
			ITextRangeProvider[] array = null;
			if (this.textControl_0.textControlCore_0.isHandleCreated)
			{
				Class429.Struct83 struct83_ = default(Class429.Struct83);
				Class429.GetClientRect(this.textControl_0.textControlCore_0.IntPtr_0, ref struct83_);
				int num = this.method_0(default(Class429.Struct82));
				int num2 = this.method_0(new Class429.Struct82(struct83_.int_2, struct83_.int_3));
				if (num != -1 && num2 != -1)
				{
					array = new ITextRangeProvider[1]
					{
						new Class608(this.textControl_0, num, num2, this.textPart_0, this.irawElementProviderSimple_0)
					};
				}
			}
			if (array != null)
			{
				return array;
			}
			return new ITextRangeProvider[0];
		}

		ITextRangeProvider ITextProvider.RangeFromPoint(UiaPoint point)
		{
			if (!this.textControl_0.textControlCore_0.isHandleCreated)
			{
				throw new InvalidOperationException();
			}
			Point p = new Point((int)point.x, (int)point.y);
			p = this.textControl_0.PointToClient(p);
			Class429.Struct82 struct82_ = new Class429.Struct82(p.X, p.Y);
			Class429.Struct83 struct83_ = default(Class429.Struct83);
			Class429.GetClientRect(this.textControl_0.textControlCore_0.IntPtr_0, ref struct83_);
			if (!struct83_.method_0().Contains(p))
			{
				throw new InvalidOperationException();
			}
			int num = this.method_0(struct82_);
			if (num == -1)
			{
				throw new InvalidOperationException();
			}
			return new Class608(this.textControl_0, num, num, this.textPart_0, this.irawElementProviderSimple_0);
		}

		ITextRangeProvider ITextProvider.RangeFromChild(IRawElementProviderSimple childElement)
		{
			throw new InvalidOperationException();
		}

		void IValueProvider.SetValue(string val)
		{
			if (this.textControl_0.EditMode != EditMode.Edit)
			{
				throw new InvalidOperationException();
			}
			if (val == null)
			{
				throw new ArgumentNullException("value");
			}
			LoadSettings loadSettings = new LoadSettings();
			loadSettings.TextPart = this.textPart_0;
			LoadSettings loadSettings2 = loadSettings;
			loadSettings2.method_5(val, StringStreamType.PlainText, this.textControl_0.textControlCore_0, Enum104.const_0, null);
		}

		private int method_0(Class429.Struct82 struct82_0)
		{
			return this.textControl_0.textControlCore_0.method_35(this.textPart_0, Enum83.const_70, Class429.smethod_3(0, 1), ref struct82_0);
		}
	}
}
