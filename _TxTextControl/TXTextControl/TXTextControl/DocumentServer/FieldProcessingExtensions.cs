using System.Collections.Generic;
using ns1;

namespace TXTextControl.DocumentServer
{
	internal static class FieldProcessingExtensions
	{
		public static void RemoveAppFields(this IFormattedText textPart, List<Class78> fieldsToRemove, bool removeEmptyLines)
		{
			fieldsToRemove.Reverse();
			foreach (Class78 item2 in fieldsToRemove)
			{
				int textPosition = item2.ApplicationField_0.Start - 1;
				textPart.ApplicationFields.Remove(item2.ApplicationField_0, item2.Boolean_0);
				if (removeEmptyLines)
				{
					Line item = textPart.Lines.GetItem(textPosition);
					if (item != null && string.IsNullOrWhiteSpace(item.Text))
					{
						textPart.Selection = new Selection(item.Start - 1, item.Length);
						textPart.Selection.Text = "";
					}
				}
			}
		}
	}
}
