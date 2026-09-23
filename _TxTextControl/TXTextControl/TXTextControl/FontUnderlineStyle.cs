using System.ComponentModel;
using ns21;

namespace TXTextControl
{
	[TypeConverter(typeof(Class421))]
	public enum FontUnderlineStyle
	{
		None = 20992,
		Single = 16912,
		Doubled = 4672,
		SingleWordsOnly = 16528,
		DoubledWordsOnly = 4288
	}
}
