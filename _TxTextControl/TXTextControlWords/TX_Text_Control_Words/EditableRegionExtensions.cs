using System.Linq;
using TXTextControl;

namespace TX_Text_Control_Words
{
	internal static class EditableRegionExtensions
	{
		public static bool _Equals(this EditableRegion region, EditableRegion other)
		{
			if (region.Start == other.Start && region.Length == other.Length)
			{
				if (!(region.UserName == other.UserName))
				{
					if (string.IsNullOrEmpty(region.UserName))
					{
						return string.IsNullOrEmpty(other.UserName);
					}
					return false;
				}
				return true;
			}
			return false;
		}

		public static EditableRegion Remove(this EditableRegionCollection editableRegionCollection, bool selectedPart, string username = "")
		{
			EditableRegion item = editableRegionCollection.GetItem(username);
			if (item != null)
			{
				editableRegionCollection.Remove(item, selectedPart);
			}
			return item;
		}

		public static EditableRegion GetItem(this EditableRegionCollection editableRegionCollection, string username = "")
		{
			EditableRegion[] items = editableRegionCollection.GetItems();
			if (string.IsNullOrEmpty(username))
			{
				return items.FirstOrDefault((EditableRegion r) => string.IsNullOrEmpty(r.UserName));
			}
			return items.FirstOrDefault((EditableRegion r) => r.UserName == username);
		}
	}
}
