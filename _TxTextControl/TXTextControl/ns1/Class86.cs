using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TXTextControl;
using TXTextControl.DocumentServer;
using DocumentServer.Fields;

namespace ns1
{
	[DebuggerDisplay("Name: {Name}, Start: {Start}, End: {End}")]
	internal class Class86
	{
		internal const string string_0 = "txmb_";

		internal const string string_1 = "blockstart_";

		internal const string string_2 = "blockend_";

		private int int_0;

		private byte[] byte_0;

		private List<string> list_0;

		private object object_0;

		[CompilerGenerated]
		private string string_3;

		[CompilerGenerated]
		private int int_1;

		[CompilerGenerated]
		private int int_2;

		[CompilerGenerated]
		private Class86 class86_0;

		[CompilerGenerated]
		private List<Class86> list_1;

		[CompilerGenerated]
		private DataShapingInfo dataShapingInfo_0;

		internal string String_0
		{
			[CompilerGenerated]
			get
			{
				return this.string_3;
			}
			[CompilerGenerated]
			private set
			{
				this.string_3 = value;
			}
		}

		internal int Int32_0
		{
			[CompilerGenerated]
			get
			{
				return this.int_1;
			}
			[CompilerGenerated]
			private set
			{
				this.int_1 = value;
			}
		}

		internal int Int32_1
		{
			[CompilerGenerated]
			get
			{
				return this.int_2;
			}
			[CompilerGenerated]
			private set
			{
				this.int_2 = value;
			}
		}

		internal int Int32_2
		{
			get
			{
				return this.Int32_0 + this.Int32_1;
			}
			private set
			{
				this.int_0 = value;
			}
		}

		internal byte[] Byte_0 => this.byte_0;

		internal Class86 Class86_0
		{
			[CompilerGenerated]
			get
			{
				return this.class86_0;
			}
			[CompilerGenerated]
			private set
			{
				this.class86_0 = value;
			}
		}

		internal List<Class86> List_0
		{
			[CompilerGenerated]
			get
			{
				return this.list_1;
			}
			[CompilerGenerated]
			private set
			{
				this.list_1 = value;
			}
		}

		internal int Int32_3
		{
			get
			{
				if (this.Class86_0 == null)
				{
					return 1;
				}
				return this.Class86_0.Int32_3 + 1;
			}
		}

		internal List<string> List_1
		{
			get
			{
				if (this.list_0 == null)
				{
					this.list_0 = new List<string>();
					if (this.byte_0 == null)
					{
						return this.list_0;
					}
					foreach (ApplicationField item in this.IEnumerable_0)
					{
						string fieldName = item.GetFieldName();
						if (!string.IsNullOrEmpty(fieldName))
						{
							this.list_0.Add(fieldName);
						}
					}
				}
				return this.list_0;
			}
		}

		internal IEnumerable<ApplicationField> IEnumerable_0
		{
			get
			{
				if (this.byte_0 == null)
				{
					yield break;
				}
				using ServerTextControl tx = new ServerTextControl(this.object_0.GetType());
				tx.Create();
				LoadSettings loadSettings = new LoadSettings
				{
					ApplicationFieldFormat = ApplicationFieldFormat.MSWordTXFormFields
				};
				tx.Load(this.byte_0, BinaryStreamType.InternalUnicodeFormat, loadSettings);
				foreach (IFormattedText textPart in tx.TextParts)
				{
					if (textPart is HeaderFooter)
					{
						continue;
					}
					foreach (ApplicationField applicationField in textPart.ApplicationFields)
					{
						if (this.method_1(applicationField))
						{
							yield return applicationField;
						}
					}
				}
			}
		}

		public DataShapingInfo DataShapingInfo_0
		{
			[CompilerGenerated]
			get
			{
				return this.dataShapingInfo_0;
			}
			[CompilerGenerated]
			private set
			{
				this.dataShapingInfo_0 = value;
			}
		}

		internal static List<Class86> smethod_0(byte[] byte_1, TraceSource traceSource_0, bool bool_0, object object_1)
		{
			LoadSettings loadSettings = new LoadSettings
			{
				ApplicationFieldFormat = ApplicationFieldFormat.MSWordTXFormFields
			};
			if (byte_1 == null)
			{
				throw new ArgumentNullException("template");
			}
			if (object_1 == null)
			{
				throw new ArgumentNullException("textComponent");
			}
			using ServerTextControl serverTextControl = new ServerTextControl(object_1.GetType());
			serverTextControl.Create();
			serverTextControl.Load(byte_1, BinaryStreamType.InternalUnicodeFormat, loadSettings);
			List<Class86> mergeBlocks = serverTextControl.GetMergeBlocks(traceSource_0, bool_0, object_1);
			serverTextControl.Save(out byte_1, BinaryStreamType.InternalUnicodeFormat);
			return mergeBlocks;
		}

		internal Class86(SubTextPart subTextPart_0, byte[] byte_1, object object_1)
		{
			MergeBlockMetaData mergeBlockMetaData = subTextPart_0.GetMergeBlockMetaData();
			if (mergeBlockMetaData != null)
			{
				this.String_0 = mergeBlockMetaData.Name;
				this.DataShapingInfo_0 = mergeBlockMetaData.DataShapingInfo;
			}
			this.Int32_0 = subTextPart_0.Start;
			this.Int32_1 = subTextPart_0.Length;
			this.object_0 = object_1;
			this.byte_0 = byte_1;
			this.List_0 = new List<Class86>();
			if (this.byte_0 != null)
			{
				Class86.smethod_0(this.byte_0, null, bool_0: false, this.object_0).ForEach(delegate(Class86 class86_1)
				{
					this.method_0(class86_1);
				});
			}
		}

		internal void method_0(Class86 class86_1)
		{
			class86_1.Class86_0 = this;
			this.List_0.Add(class86_1);
		}

		internal bool method_1(ApplicationField applicationField_0)
		{
			return this.method_2(applicationField_0, bool_0: true);
		}

		internal bool method_2(ApplicationField applicationField_0, bool bool_0)
		{
			if (applicationField_0 == null)
			{
				return false;
			}
			bool flag = false;
			int int32_ = this.Int32_0;
			int int32_2 = this.Int32_2;
			this.Int32_0 = 1;
			this.Int32_2 = this.Int32_1;
			int start = applicationField_0.Start;
			int int_ = applicationField_0.Start - 1 + applicationField_0.Length;
			flag = this.method_3(start, int_);
			if (bool_0)
			{
				flag = flag && !this.method_4(start, int_);
			}
			this.Int32_0 = int32_;
			this.Int32_2 = int32_2;
			return flag;
		}

		internal bool method_3(int int_3, int int_4)
		{
			if (int_3 >= this.Int32_0)
			{
				return int_4 <= this.Int32_2;
			}
			return false;
		}

		internal bool method_4(int int_3, int int_4)
		{
			return this.List_0.Find((Class86 block) => block.method_3(int_3, int_4)) != null;
		}
	}
}
