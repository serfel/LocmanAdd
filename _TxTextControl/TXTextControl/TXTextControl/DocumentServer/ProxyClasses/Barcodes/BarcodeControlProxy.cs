using System;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using ns9;
using TXTextControl.DataVisualization;

namespace DocumentServer.ProxyClasses.Barcodes
{
	internal abstract class BarcodeControlProxy : ControlProxy
	{
		protected class Class128
		{
			public PropertyInfo propertyInfo_0;

			public PropertyInfo propertyInfo_1;

			public PropertyInfo propertyInfo_2;

			public PropertyInfo propertyInfo_3;

			public PropertyInfo propertyInfo_4;

			public PropertyInfo propertyInfo_5;

			public PropertyInfo propertyInfo_6;

			public PropertyInfo propertyInfo_7;

			public PropertyInfo propertyInfo_8;

			public MethodInfo methodInfo_0;

			public MethodInfo methodInfo_1;

			public MethodInfo methodInfo_2;

			public MethodInfo methodInfo_3;
		}

		protected BarcodeFrame m_barcodeFrame;

		protected static Class128 s_memberInfos;

		private const string AlignTypeName = "TXTextControl.Barcode.Alignment";

		private const string TypeTypeName = "TXTextControl.Barcode.BarcodeType";

		private static readonly AssemblyName CoreAsmName;

		internal BarcodeFrame TXBarcodeFrame
		{
			get
			{
				return this.m_barcodeFrame;
			}
			set
			{
				this.m_barcodeFrame = value;
				base.Control = this.m_barcodeFrame.Barcode;
			}
		}

		internal static Assembly CoreAssembly { get; private set; }

		protected Class128 MemberInfos => this.GetMemberInfos();

		internal BlockMergingEventArgs Alignment
		{
			get
			{
				if (base.Control == null)
				{
					return BlockMergingEventArgs.const_0;
				}
				return BarcodeControlProxy.GetAlignment(this.MemberInfos.propertyInfo_0.GetValue(base.Control, null));
			}
			set
			{
				if (base.Control != null)
				{
					this.MemberInfos.propertyInfo_0.SetValue(base.Control, BarcodeControlProxy.GetAlignment(value), null);
				}
			}
		}

		internal int Angle
		{
			get
			{
				if (base.Control == null)
				{
					return 0;
				}
				return (int)this.MemberInfos.propertyInfo_1.GetValue(base.Control, null);
			}
			set
			{
				if (base.Control != null)
				{
					this.MemberInfos.propertyInfo_1.SetValue(base.Control, value, null);
				}
			}
		}

		internal override Color BackColor
		{
			get
			{
				return this.GetBackColor();
			}
			set
			{
				this.SetBackColor(value);
			}
		}

		internal FieldMergedEventArgs BarcodeType
		{
			get
			{
				if (base.Control == null)
				{
					return FieldMergedEventArgs.const_1;
				}
				return BarcodeControlProxy.GetBarcodeType(this.MemberInfos.propertyInfo_3.GetValue(base.Control, null));
			}
			set
			{
				if (base.Control != null)
				{
					this.MemberInfos.propertyInfo_3.SetValue(base.Control, BarcodeControlProxy.GetBarcodeType(value), null);
				}
			}
		}

		internal override Color ForeColor
		{
			get
			{
				return this.GetForeColor();
			}
			set
			{
				this.SetForeColor(value);
			}
		}

		internal string Text
		{
			get
			{
				if (base.Control == null)
				{
					return string.Empty;
				}
				return (string)this.MemberInfos.propertyInfo_7.GetValue(base.Control, null);
			}
			set
			{
				if (base.Control != null)
				{
					this.MemberInfos.propertyInfo_7.SetValue(base.Control, value, null);
				}
			}
		}

		internal int UpperTextLength
		{
			get
			{
				if (base.Control == null)
				{
					return 0;
				}
				return (int)this.MemberInfos.propertyInfo_8.GetValue(base.Control, null);
			}
			set
			{
				if (base.Control != null)
				{
					this.MemberInfos.propertyInfo_8.SetValue(base.Control, value, null);
				}
			}
		}

		internal override double Width
		{
			get
			{
				if (base.Control == null)
				{
					return 0.0;
				}
				return (int)this.MemberInfos.propertyInfo_5.GetValue(base.Control, null);
			}
			set
			{
				if (base.Control != null)
				{
					this.MemberInfos.propertyInfo_5.SetValue(base.Control, (int)value, null);
				}
			}
		}

		internal override double Height
		{
			get
			{
				if (base.Control == null)
				{
					return 0.0;
				}
				return (int)this.MemberInfos.propertyInfo_6.GetValue(base.Control, null);
			}
			set
			{
				if (base.Control != null)
				{
					this.MemberInfos.propertyInfo_6.SetValue(base.Control, (int)value, null);
				}
			}
		}

		static BarcodeControlProxy()
		{
			BarcodeControlProxy.CoreAsmName = new AssemblyName
			{
				Name = "TXBarcode",
				Version = new Version(29, 0, 500, 500),
				CultureInfo = new CultureInfo("")
			};
			BarcodeControlProxy.CoreAsmName.SetPublicKeyToken(ControlProxy.TXPubKeyToken);
			BarcodeControlProxy.LoadCoreAssembly();
		}

		protected BarcodeControlProxy(double width, double height)
			: base(width, height)
		{
		}

		protected BarcodeControlProxy(BarcodeFrame frame)
			: base(frame.Barcode)
		{
			this.m_barcodeFrame = frame;
		}

		internal bool IsTextValid(FieldMergedEventArgs barcodeType, string text, out string errorMessage)
		{
			object[] array = new object[3]
			{
				BarcodeControlProxy.GetBarcodeType(barcodeType),
				text,
				null
			};
			bool result = (bool)this.MemberInfos.methodInfo_0.Invoke(null, array);
			errorMessage = (string)array[2];
			return result;
		}

		internal string GetDefaultText(FieldMergedEventArgs barcodeType)
		{
			return (string)this.MemberInfos.methodInfo_1.Invoke(null, new object[1] { BarcodeControlProxy.GetBarcodeType(barcodeType) });
		}

		internal int GetMaximumTextLength(FieldMergedEventArgs barcodeType)
		{
			return (int)this.MemberInfos.methodInfo_2.Invoke(null, new object[1] { BarcodeControlProxy.GetBarcodeType(barcodeType) });
		}

		internal int GetMinimumTextLength(FieldMergedEventArgs barcodeType)
		{
			return (int)this.MemberInfos.methodInfo_3.Invoke(null, new object[1] { BarcodeControlProxy.GetBarcodeType(barcodeType) });
		}

		protected Class128 GetMemberInfos()
		{
			if (BarcodeControlProxy.s_memberInfos == null)
			{
				this.LoadMemberInfos();
			}
			return BarcodeControlProxy.s_memberInfos;
		}

		protected abstract Color GetBackColor();

		protected abstract void SetBackColor(Color color);

		protected abstract Color GetForeColor();

		protected abstract void SetForeColor(Color color);

		private static void LoadCoreAssembly()
		{
			if (!(BarcodeControlProxy.CoreAssembly != null))
			{
				try
				{
					BarcodeControlProxy.CoreAssembly = Assembly.Load(BarcodeControlProxy.CoreAsmName);
				}
				catch
				{
				}
			}
		}

		private void LoadMemberInfos()
		{
			if (!(ControlProxy.s_controlType == null))
			{
				BarcodeControlProxy.s_memberInfos = new Class128();
				BarcodeControlProxy.s_memberInfos.propertyInfo_0 = ControlProxy.s_controlType.GetProperty("Alignment");
				BarcodeControlProxy.s_memberInfos.propertyInfo_1 = ControlProxy.s_controlType.GetProperty("Angle");
				BarcodeControlProxy.s_memberInfos.propertyInfo_2 = ControlProxy.s_controlType.GetProperty("BackColor");
				BarcodeControlProxy.s_memberInfos.propertyInfo_3 = ControlProxy.s_controlType.GetProperty("BarcodeType");
				BarcodeControlProxy.s_memberInfos.propertyInfo_4 = ControlProxy.s_controlType.GetProperty("ForeColor");
				BarcodeControlProxy.s_memberInfos.propertyInfo_5 = ControlProxy.s_controlType.GetProperty("Width");
				BarcodeControlProxy.s_memberInfos.propertyInfo_6 = ControlProxy.s_controlType.GetProperty("Height");
				BarcodeControlProxy.s_memberInfos.propertyInfo_7 = ControlProxy.s_controlType.GetProperty("Text");
				BarcodeControlProxy.s_memberInfos.propertyInfo_8 = ControlProxy.s_controlType.GetProperty("UpperTextLength");
				BarcodeControlProxy.s_memberInfos.methodInfo_0 = ControlProxy.s_controlType.GetMethod("IsTextValid");
				BarcodeControlProxy.s_memberInfos.methodInfo_1 = ControlProxy.s_controlType.GetMethod("GetDefaultText");
				BarcodeControlProxy.s_memberInfos.methodInfo_2 = ControlProxy.s_controlType.GetMethod("GetMaximumTextLength");
				BarcodeControlProxy.s_memberInfos.methodInfo_3 = ControlProxy.s_controlType.GetMethod("GetMinimumTextLength");
			}
		}

		private static object GetBarcodeType(FieldMergedEventArgs value)
		{
			return BarcodeControlProxy.CoreAssembly.GetType("TXTextControl.Barcode.BarcodeType").GetField(value.ToString()).GetRawConstantValue();
		}

		private static FieldMergedEventArgs GetBarcodeType(object barcodeType)
		{
			string text = (string)barcodeType.GetType().GetMethod("ToString", Type.EmptyTypes).Invoke(barcodeType, null);
			foreach (FieldMergedEventArgs value in Enum.GetValues(typeof(FieldMergedEventArgs)))
			{
				if (value.ToString() == text)
				{
					return value;
				}
			}
			return FieldMergedEventArgs.const_0;
		}

		private static object GetAlignment(BlockMergingEventArgs value)
		{
			return BarcodeControlProxy.CoreAssembly.GetType("TXTextControl.Barcode.Alignment").GetField(value.ToString()).GetRawConstantValue();
		}

		private static BlockMergingEventArgs GetAlignment(object alignment)
		{
			string text = (string)alignment.GetType().GetMethod("ToString", Type.EmptyTypes).Invoke(alignment, null);
			foreach (BlockMergingEventArgs value in Enum.GetValues(typeof(BlockMergingEventArgs)))
			{
				if (value.ToString() == text)
				{
					return value;
				}
			}
			return BlockMergingEventArgs.const_0;
		}
	}
}
