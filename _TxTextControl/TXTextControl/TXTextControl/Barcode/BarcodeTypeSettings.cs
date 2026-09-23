using System;
using System.ComponentModel;
using System.Reflection;
using System.Threading;

namespace TXTextControl.Barcode
{
	/// <summary>The BarcodeTypeSettings class provides properties to apply barcode type specific settings.</summary>
	public class BarcodeTypeSettings : INotifyPropertyChanged
	{
		private TXBarcodeCore txbarcodeCore_0;

		private object object_0;

		private MethodInfo methodInfo_0;

		private PropertyChangedEventHandler propertyChangedEventHandler_0;

		/// <summary>Gets or sets a value indicating whether the current used barcode type includes a check value.</summary>
		public bool HasCheckValue
		{
			get
			{
				return this.txbarcodeCore_0.class38_0.Boolean_0;
			}
			set
			{
				if (this.txbarcodeCore_0.barcodeInfo_0.m_bHasCheckValueIsOptional)
				{
					bool boolean_ = this.txbarcodeCore_0.class38_0.Boolean_0;
					bool flag2 = (this.txbarcodeCore_0.class38_0.Boolean_0 = value);
					if (boolean_ != flag2)
					{
						this.txbarcodeCore_0.method_14();
						this.methodInfo_0.Invoke(this.object_0, null);
						this.method_0("HasCheckValue");
					}
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether the check value of the current used barcode type is shown with the encrypted barcode text value.</summary>
		public bool ShowCheckValue
		{
			get
			{
				return this.txbarcodeCore_0.class38_0.Boolean_1;
			}
			set
			{
				if (this.txbarcodeCore_0.barcodeInfo_0.m_bShowCheckValueIsOptional)
				{
					bool boolean_ = this.txbarcodeCore_0.class38_0.Boolean_1;
					bool flag2 = (this.txbarcodeCore_0.class38_0.Boolean_1 = value);
					if (boolean_ != flag2)
					{
						this.txbarcodeCore_0.method_14();
						this.methodInfo_0.Invoke(this.object_0, null);
						this.method_0("ShowCheckValue");
					}
				}
			}
		}

		public event PropertyChangedEventHandler PropertyChanged
		{
			add
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChangedEventHandler_0;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange(ref this.propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
				}
				while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
			}
			remove
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChangedEventHandler_0;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange(ref this.propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
				}
				while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
			}
		}

		internal BarcodeTypeSettings(TXBarcodeCore kernel, object barcodeControl)
		{
			this.txbarcodeCore_0 = kernel;
			this.object_0 = barcodeControl;
			this.methodInfo_0 = barcodeControl.GetType().GetMethod("UpdateImage", BindingFlags.Instance | BindingFlags.NonPublic);
		}

		internal void method_0(string string_0)
		{
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs(string_0));
			}
		}
	}
}
