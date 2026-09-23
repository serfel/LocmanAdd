using System;
using System.ComponentModel;
using System.Reflection;
using ns1;
using DocumentServer.Properties;
using TXTextControl;
using TXTextControl.DocumentServer;

namespace DocumentServer.Fields
{
	/// <summary>The abstract FieldAdapter class is the base class of all special DocumentServer field adapters.</summary>
	public abstract class FieldAdapter
	{
		public const string TYPE_NAME = "FIELD_ADAPTER";

		private const string IWin32WindowTypeName = "System.Windows.Forms.IWin32Window, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";

		/// <summary>Gets the adapted ApplicationField of the field.</summary>
		public ApplicationField ApplicationField { get; protected set; }

		[Category("Properties")]
		[Attribute1("PROP_FLDADAP_ID")]
		public int Int32_0
		{
			get
			{
				return this.ApplicationField.Int32_0;
			}
			set
			{
				this.ApplicationField.Int32_0 = value;
			}
		}

		/// <summary>Gets the field's type name of the specific field through its adapter.</summary>
		public abstract string TypeName { get; }

		/// <summary>Gets the first character position (one-based) of the field through its adapter.</summary>
		public int Start => this.ApplicationField.Start;

		/// <summary>Gets the number of characters in a text field through its adapter.</summary>
		public int Length => this.ApplicationField.Length;

		/// <summary>Initializes a complete new instance of the FieldAdapter class without a connection to an existing ApplicationField.</summary>
		public FieldAdapter()
		{
			this.GenerateAppField();
		}

		/// <summary>Initializes a new instance of the FieldAdapter class with a connection to an existing ApplicationField.</summary>
		/// <param name="appField">Specifies the ApplicationField to be adapted.</param>
		public FieldAdapter(ApplicationField appField)
		{
			this.ApplicationField = appField;
		}

		/// <summary>Opens the specific field options dialog box with LTR flow direction.</summary>
		[Category("Methods")]
		[Attribute1("METH_FLDADAP_SHOWDIALOG")]
		public DialogResult ShowDialog()
		{
			return this.ShowDialog(rightToLeft: false);
		}

		/// <summary>Opens the specific field options dialog box with a specified owner window.</summary>
		/// <param name="owner">Sets the dialog's owner window.</param>
		[Category("Methods")]
		[Attribute1("METH_FLDADAP_SHOWDIALOG")]
		public DialogResult ShowDialog(object owner)
		{
			return this.ShowDialog(owner, rightToLeft: false);
		}

		/// <summary>Opens the specific field options dialog box with the flow direction (RTL or LTR) set according to the boolean parameter value.</summary>
		/// <param name="rightToLeft">Sets the dialog layout flow direction.</param>
		[Category("Methods")]
		[Attribute1("METH_FLDADAP_SHOWDIALOG")]
		public DialogResult ShowDialog(bool rightToLeft)
		{
			return this.ShowDialog(null, rightToLeft);
		}

		/// <summary>Opens the specific field options dialog box with an owner window and a flow direction.</summary>
		/// <param name="owner">Sets the dialog's owner window.</param>
		/// <param name="rightToLeft">Sets the dialog layout flow direction.</param>
		[Category("Methods")]
		[Attribute1("METH_FLDADAP_SHOWDIALOG")]
		public DialogResult ShowDialog(object owner, bool rightToLeft)
		{
			DialogResult result = DialogResult.None;
			switch (MailMerge.Enum8_0)
			{
			case Enum8.const_2:
				result = this.ShowWPFDialog(owner, rightToLeft);
				break;
			case Enum8.const_1:
				result = this.ShowWinFormsDialog(owner, rightToLeft);
				break;
			}
			this.SetParameters();
			return result;
		}

		protected DialogResult ShowWinFormsDialog(object owner, bool rightToLeft)
		{
			DialogResult result = DialogResult.None;
			try
			{
				Type type = Type.GetType("System.Windows.Forms.IWin32Window, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089");
				Type[] types = MailMerge.Assembly_0.GetTypes();
				foreach (Type type2 in types)
				{
					MethodInfo method = type2.GetMethod("ShowFieldDialog", new Type[1] { type });
					if (method == null)
					{
						continue;
					}
					ConstructorInfo constructor = type2.GetConstructor(new Type[1] { base.GetType() });
					if (constructor == null)
					{
						continue;
					}
					PropertyInfo property = type2.GetProperty("RightToLeft");
					object obj = constructor.Invoke(new object[1] { this });
					if (rightToLeft)
					{
						object obj2 = MailMerge.smethod_16("Yes");
						if (obj2 != null)
						{
							property.SetValue(obj, obj2, null);
						}
					}
					return (DialogResult)method.Invoke(obj, new object[1] { owner });
				}
				return result;
			}
			catch (Exception ex)
			{
				throw new Exception(string.Format(Resources.EXC_SHOWDLG_FAILED, ex.ToString()));
			}
		}

		protected DialogResult ShowWPFDialog(object owner, bool rightToLeft)
		{
			DialogResult result = DialogResult.None;
			try
			{
				Type[] types = MailMerge.Assembly_1.GetTypes();
				foreach (Type type in types)
				{
					MethodInfo method = type.GetMethod("ShowFieldDialog", Type.EmptyTypes);
					if (method == null)
					{
						continue;
					}
					ConstructorInfo constructor = type.GetConstructor(new Type[1] { base.GetType() });
					if (constructor == null)
					{
						continue;
					}
					PropertyInfo property = type.GetProperty("FlowDirection");
					PropertyInfo property2 = type.GetProperty("Owner");
					object obj = constructor.Invoke(new object[1] { this });
					property2.SetValue(obj, owner, null);
					if (rightToLeft)
					{
						object obj2 = MailMerge.smethod_17("RightToLeft");
						if (obj2 != null)
						{
							property.SetValue(obj, obj2, null);
						}
					}
					return (DialogResult)method.Invoke(obj, null);
				}
				return result;
			}
			catch (Exception ex)
			{
				throw new Exception(string.Format(Resources.EXC_SHOWDLG_FAILED, ex.ToString()));
			}
		}

		protected bool Equals(FieldAdapter field)
		{
			if (field == null)
			{
				return false;
			}
			if (this.ApplicationField == null)
			{
				return field.ApplicationField == null;
			}
			if (this.ApplicationField != field.ApplicationField)
			{
				if (field.Int32_0 == this.Int32_0 && field.Start == this.Start)
				{
					return field.Length == this.Length;
				}
				return false;
			}
			return true;
		}

		protected abstract void GenerateAppField();

		protected abstract void SetParameters();

		protected abstract void GetParameters();
	}
}
