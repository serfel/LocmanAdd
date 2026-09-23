namespace TXTextControl.DocumentServer
{
	internal abstract class Mergeable
	{
		public TableCell TableCell { get; protected set; }

		public abstract int TextPosition { get; }

		public abstract string Name { get; }
	}
	internal abstract class Mergeable<T> : Mergeable
	{
		protected T m_entity;

		public Mergeable(T entity)
			: this(entity, (TableCell)null)
		{
		}

		public Mergeable(T entity, TableCell tableCell)
		{
			this.m_entity = entity;
			base.TableCell = tableCell;
		}
	}
}
