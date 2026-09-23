using System;
using System.Runtime.InteropServices;
using ns21;

namespace TXTextControl
{
	/// <summary>An instance of the TableCollection class contains all tables of a Text Control document or part of the document represented through objects of the type Table.</summary>
	public sealed class TableCollection : TableBaseCollection
	{
		/// <summary>Gets a value indicating whether a new table can be inserted at the current input position.</summary>
		public bool CanAdd => 0 != base.textControlCore_0.method_29(base.textPart_0, 1259, 1, 0);

		/// <summary>Gets or sets a value indicating wether table grid lines are shown or not.</summary>
		public bool GridLines
		{
			get
			{
				Enum91 @enum = (Enum91)base.textControlCore_0.method_29(base.textPart_0, 1151, 0, 0);
				return (@enum & Enum91.const_19) != 0;
			}
			set
			{
				base.textControlCore_0.method_30(Enum83.const_40, value ? 2048 : 32, 0);
			}
		}

		/// <summary>Gets a list of all formula functions currently supported.</summary>
		public string[] SupportedFormulaFunctions
		{
			get
			{
				string[] result = null;
				IntPtr intPtr = base.textControlCore_0.method_64(TextPart.Auto, Enum83.const_327, 0u, 0);
				try
				{
					if (intPtr != IntPtr.Zero)
					{
						return KernelHelper.Ptr2StringArray(intPtr);
					}
					return result;
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					if (intPtr != IntPtr.Zero)
					{
						Marshal.FreeHGlobal(intPtr);
					}
				}
			}
		}

		/// <summary>Gets a list of often used number formats for formula results.</summary>
		public string[] SupportedNumberFormats
		{
			get
			{
				string[] result = null;
				IntPtr intPtr = base.textControlCore_0.method_64(TextPart.Auto, Enum83.const_328, 0u, 0);
				try
				{
					if (intPtr != IntPtr.Zero)
					{
						return KernelHelper.Ptr2StringArray(intPtr);
					}
					return result;
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					if (intPtr != IntPtr.Zero)
					{
						Marshal.FreeHGlobal(intPtr);
					}
				}
			}
		}

		internal TableCollection(TextControlCore textControlCore_1, TextPart iTextPart)
			: base(textControlCore_1, 0, iTextPart)
		{
		}

		/// <summary>Opens a dialog box and, when left with Ok, adds a new table with the specified attributes.</summary>
		public bool Add()
		{
			int int_ = (((base.textControlCore_0.enum56_0 & Enum56.const_0) != 0) ? 256 : 0);
			return 0 != base.textControlCore_0.method_29(base.textPart_0, 1965, int_, 0);
		}

		/// <summary>Adds a new table at the current text input position. The new table has the specified number of rows and columns.</summary>
		/// <param name="rows">Specifies the number of rows the table consists of.</param>
		/// <param name="columns">Specifies the number of columns the table consists of.</param>
		public bool Add(int rows, int columns)
		{
			int int_ = (((base.textControlCore_0.enum56_0 & Enum56.const_0) != 0) ? 256 : 0);
			return 0 != base.textControlCore_0.method_29(base.textPart_0, 1254, int_, Class429.smethod_3(rows, columns));
		}

		/// <summary>Adds a new table at the current text input position. The new table has the specified number of rows and columns. The specified identifier can be used to get the table from the collection.</summary>
		/// <param name="rows">Specifies the number of rows the table consists of.</param>
		/// <param name="columns">Specifies the number of columns the table consists of.</param>
		/// <param name="id">Specifies the table's id.</param>
		public bool Add(int rows, int columns, int int_1)
		{
			bool flag = false;
			if (int_1 >= 10 && int_1 <= 32767)
			{
				try
				{
					base.textControlCore_0.method_19(base.textPart_0, null);
					base.textControlCore_0.method_23(bool_1: true);
					int int_2 = (((base.textControlCore_0.enum56_0 & Enum56.const_0) != 0) ? 256 : 0);
					int num = base.textControlCore_0.method_29(base.textPart_0, 1254, int_2, Class429.smethod_3(rows, columns));
					return num switch
					{
						0 => flag, 
						1 => flag, 
						_ => 0 != base.textControlCore_0.method_29(base.textPart_0, 1263, num, int_1), 
					};
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					base.textControlCore_0.method_23(bool_1: false);
					base.textControlCore_0.method_20(base.textPart_0);
				}
			}
			throw new ArgumentOutOfRangeException();
		}

		/// <summary>Gets the table at the current input position. To get a particular table with a certain identifier use the base class's implementation TableBaseCollection.GetItem.</summary>
		public Table GetItem()
		{
			int num = base.textControlCore_0.method_29(base.textPart_0, 1275, 3, 0);
			if (num != 0)
			{
				return new Table(base.textControlCore_0, base.textPart_0, Class429.smethod_5(num), Class429.smethod_6(num));
			}
			return null;
		}

		/// <summary>Removes the table at the current text input position. To remove a particular table with a certain identifier use the base class's implementation TableBaseCollection.Remove.</summary>
		public bool Remove()
		{
			return this.GetItem()?.method_1() ?? false;
		}
	}
}
