using TXTextControl;
using TXTextControl.DocumentServer;

namespace ns1
{
	internal class Class82 : Mergeable<ApplicationField>
	{
		public ApplicationField ApplicationField_0 => base.m_entity;

		public override int TextPosition => base.m_entity.Start;

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

		public Class82(ApplicationField applicationField_0, TableCell tableCell_0)
			: base(applicationField_0, tableCell_0)
		{
		}
	}
}
