using System;
using System.Collections;
using TXTextControl;

namespace ns21
{
	internal class Class430 : IEnumerator
	{
		private XmlElementCollection xmlElementCollection_0;

		private int int_0;

		private object object_0;

		public virtual object Current
		{
			get
			{
				if (this.object_0 == null)
				{
					throw new ArgumentNullException("Current");
				}
				return this.object_0;
			}
		}

		public Class430(XmlElementCollection xmlElementCollection_1)
		{
			this.xmlElementCollection_0 = xmlElementCollection_1;
		}

		public virtual bool MoveNext()
		{
			if (this.int_0 < 0)
			{
				this.object_0 = this.xmlElementCollection_0.xmlElement_0;
				return false;
			}
			this.object_0 = this.xmlElementCollection_0.method_2(this.int_0 + 1);
			this.int_0++;
			if (this.int_0 == this.xmlElementCollection_0.int_0)
			{
				this.int_0 = -1;
			}
			return true;
		}

		public virtual void Reset()
		{
			this.int_0 = 0;
		}
	}
}
