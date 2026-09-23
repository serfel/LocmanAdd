using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace TX_Text_Control_Words
{
	public class ExtendedObservableCollection<T> : ObservableCollection<T>
	{
		public void Set(ICollection<T> newItems)
		{
			base.Items.Clear();
			foreach (T newItem in newItems)
			{
				base.Items.Add(newItem);
			}
			this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
		}
	}
}
