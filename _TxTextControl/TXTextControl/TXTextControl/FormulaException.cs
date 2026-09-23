using System;
using System.Resources;

namespace TXTextControl
{
	/// <summary>The FormulaException class informs about an invalid syntax or missing parameters of formulas used in tables.</summary>
	public class FormulaException : Exception
	{
		private int int_0;

		private FilterException.FilterError filterError_0;

		public override string Message
		{
			get
			{
				ResourceManager resourceManager = new ResourceManager(typeof(TextControlCore));
				return this.filterError_0 switch
				{
					FilterException.FilterError.InvalidReference => resourceManager.GetString("ERR_FORMULA_INVALIDREFERENCE"), 
					FilterException.FilterError.FormulaCalculation => resourceManager.GetString("ERR_FORMULA_CALCULATION"), 
					FilterException.FilterError.FormulaFunctionParameter => resourceManager.GetString("ERR_FORMULA_PARAMETER"), 
					FilterException.FilterError.NotWellFormed => resourceManager.GetString("ERR_FORMULA_SYNTAX"), 
					FilterException.FilterError.Unsupported => resourceManager.GetString("ERR_FORMULA_UNSUPPORTED"), 
					_ => base.Message, 
				};
			}
		}

		/// <summary>Gets the one-based character index of the first invalid character in the formula string.</summary>
		public int CharacterIndex => this.int_0;

		internal FormulaException(FilterException.FilterError error, int iCharacterIndex)
		{
			this.filterError_0 = error;
			this.int_0 = iCharacterIndex;
		}
	}
}
