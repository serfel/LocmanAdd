namespace TXTextControl.DocumentServer
{
	internal abstract class MergeableFrame<T> : Mergeable<FrameBase> where T : FrameBase
	{
		public override int TextPosition => base.m_entity.TextPosition;

		public override string Name
		{
			get
			{
				if (base.m_entity == null)
				{
					return "";
				}
				return base.m_entity.Name ?? "";
			}
		}

		public T Frame => base.m_entity as T;

		public MergeableFrame(T frame)
			: base((FrameBase)frame)
		{
		}
	}
}
