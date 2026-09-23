using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ns10;
using DocumentServer.DataShaping;
using DocumentServer.Fields;
using DocumentServer.Json;
using DocumentServer.Properties;
using TXTextControl;
using TXTextControl.DocumentServer;

namespace DocumentServer.DataSources
{
	/// <summary>The MergeBlockInfo class is used to insert a table or paragraph based repeating merge block into a TextControl instance using the DataSourceManager.InsertMergeBlock method.</summary>
	public class MergeBlockInfo
	{
		private string string_0;

		private SubTextPart subTextPart_0;

		private MergeField[] mergeField_0;

		[CompilerGenerated]
		private List<string> list_0;

		[CompilerGenerated]
		private List<MergeBlockInfo> list_1;

		[CompilerGenerated]
		private List<FilterInstruction> list_2;

		[CompilerGenerated]
		private List<SortingInstruction> list_3;

		[CompilerGenerated]
		private List<FilterInstruction> list_4;

		/// <summary>Gets the table name of this merge block.</summary>
		public string TableName
		{
			get
			{
				return this.string_0;
			}
			internal set
			{
				if (string.IsNullOrEmpty(value))
				{
					throw new Exception(Resources.EXC_EDIT_MERGE_BLOCKS_EMPTY_BLOCK_NAME);
				}
				this.string_0 = value;
				if (this.subTextPart_0 != null)
				{
					this.subTextPart_0.Name = this.String_0;
					this.method_2();
				}
			}
		}

		/// <summary>Returns the merge fields inside this merge block excluding fields in possible nested merge blocks.</summary>
		public MergeField[] MergeFields
		{
			get
			{
				if (this.subTextPart_0 == null)
				{
					throw new Exception(Resources.EXC_INSTANCE_NOT_SUBTEXTPART_BASED);
				}
				return this.mergeField_0;
			}
		}

		/// <summary>Gets or sets the list of data column names which represent the merge fields this merge block consists of.</summary>
		public List<string> ColumnNames
		{
			[CompilerGenerated]
			get
			{
				return this.list_0;
			}
			[CompilerGenerated]
			set
			{
				this.list_0 = value;
			}
		}

		/// <summary>Gets or sets the list of merge blocks nested inside this merge block.</summary>
		public List<MergeBlockInfo> ChildBlocks
		{
			[CompilerGenerated]
			get
			{
				return this.list_1;
			}
			[CompilerGenerated]
			set
			{
				this.list_1 = value;
			}
		}

		/// <summary>Gets or sets a list of filter instructions which are used to filter the data rows before merging.</summary>
		public List<FilterInstruction> Filters
		{
			[CompilerGenerated]
			get
			{
				return this.list_2;
			}
			[CompilerGenerated]
			set
			{
				this.list_2 = value;
			}
		}

		/// <summary>Gets or sets a list of sorting instructions which are used to sort the data rows before merging.</summary>
		public List<SortingInstruction> SortingInstructions
		{
			[CompilerGenerated]
			get
			{
				return this.list_3;
			}
			[CompilerGenerated]
			set
			{
				this.list_3 = value;
			}
		}

		/// <summary>Gets or sets a condition the parent data row of this merge block has to satisfy so that this merge block is merged at all.</summary>
		public List<FilterInstruction> BlockMergingCondition
		{
			[CompilerGenerated]
			get
			{
				return this.list_4;
			}
			[CompilerGenerated]
			set
			{
				this.list_4 = value;
			}
		}

		internal bool Boolean_0
		{
			get
			{
				if ((this.Filters != null && this.Filters.Count > 0) || (this.SortingInstructions != null && this.SortingInstructions.Count > 0))
				{
					return true;
				}
				if (this.BlockMergingCondition != null)
				{
					return this.BlockMergingCondition.Count > 0;
				}
				return false;
			}
		}

		internal string String_0
		{
			get
			{
				if (string.IsNullOrEmpty(this.string_0))
				{
					return "";
				}
				return "txmb_" + this.string_0;
			}
		}

		internal int Int32_0
		{
			get
			{
				if (this.subTextPart_0 == null)
				{
					return 0;
				}
				return this.subTextPart_0.Start;
			}
		}

		internal SubTextPart SubTextPart_0 => this.subTextPart_0;

		internal static IComparer<MergeBlockInfo> IComparer_0 => new Class133();

		/// <summary>Initializes a new instance of the MergeBlockInfo class and sets the table name.</summary>
		/// <param name="tableName">The name of the table which is the data source for this merge block.</param>
		public MergeBlockInfo(string tableName)
		{
			this.string_0 = tableName;
			this.ColumnNames = new List<string>();
			this.ChildBlocks = new List<MergeBlockInfo>();
			this.Filters = new List<FilterInstruction>();
			this.SortingInstructions = new List<SortingInstruction>();
			this.BlockMergingCondition = new List<FilterInstruction>();
		}

		/// <summary>Initializes a new instance of the MergeBlockInfo class from an existing SubTextPart already containing merge block meta data (i. e. filter and sorting instructions and a possible block merging condition).</summary>
		/// <param name="subTextPart">A SubTextPart instance containing merge block meta data (i.</param>
		public MergeBlockInfo(SubTextPart subTextPart)
		{
			MergeBlockMetaData mergeBlockMetaData = subTextPart.GetMergeBlockMetaData();
			if (mergeBlockMetaData == null)
			{
				throw new Exception(Resources.EXC_SUBTEXTPART_IS_NO_MERGEBLOCK);
			}
			this.subTextPart_0 = subTextPart;
			this.string_0 = mergeBlockMetaData.Name;
			DataShapingInfo dataShapingInfo = mergeBlockMetaData.DataShapingInfo;
			this.Filters = new List<FilterInstruction>();
			this.SortingInstructions = new List<SortingInstruction>();
			this.BlockMergingCondition = new List<FilterInstruction>();
			this.ColumnNames = new List<string>();
			if (dataShapingInfo != null)
			{
				if (dataShapingInfo.Filters != null)
				{
					this.Filters = dataShapingInfo.Filters.ToList();
				}
				if (dataShapingInfo.SortingInstructions != null)
				{
					this.SortingInstructions = dataShapingInfo.SortingInstructions.ToList();
				}
				if (dataShapingInfo.BlockMergingCondition != null)
				{
					this.BlockMergingCondition = dataShapingInfo.BlockMergingCondition.ToList();
				}
			}
			SubTextPart[] children = subTextPart.GetFirstGenChildren();
			try
			{
				this.mergeField_0 = (from ApplicationField field in subTextPart.GetTextFields(TextFieldType.ApplicationField)
					where field.TypeName == "MERGEFIELD" && !children.Contain(field)
					select new MergeField(field)).ToArray();
				this.ColumnNames = this.mergeField_0.Select((MergeField mergeField_0) => mergeField_0.Name).ToList();
			}
			catch
			{
			}
			this.ChildBlocks = (from blockInf in children.Select(delegate(SubTextPart part)
				{
					try
					{
						return new MergeBlockInfo(part);
					}
					catch
					{
						return null;
					}
				})
				where blockInf != null
				select blockInf).ToList();
		}

		/// <summary>Stores the meta data (filters, sorting instructions and the block merging condition) in the SubTextPart which represents the block. Manipulating any of the aforementioned collections does not update the block automatically, so this method must be called to actually store changes. If a MergeBlockInfo instance is not based on an existing SubTextPart, this method throws an exception.</summary>
		public void Apply()
		{
			if (this.subTextPart_0 == null)
			{
				throw new Exception(Resources.EXC_INSTANCE_NOT_SUBTEXTPART_BASED);
			}
			this.subTextPart_0.Data = this.method_0();
		}

		internal string method_0()
		{
			FilterInstruction[] filterInstruction_ = ((this.Filters != null) ? this.Filters.ToArray() : null);
			FilterInstruction[] filterInstruction_2 = ((this.BlockMergingCondition != null) ? this.BlockMergingCondition.ToArray() : null);
			SortingInstruction[] sortingInstruction_ = ((this.SortingInstructions != null) ? this.SortingInstructions.ToArray() : null);
			return MergeBlockInfo.smethod_0(filterInstruction_, sortingInstruction_, filterInstruction_2, this.string_0);
		}

		internal static string smethod_0(FilterInstruction[] filterInstruction_0, SortingInstruction[] sortingInstruction_0, FilterInstruction[] filterInstruction_1, string string_1)
		{
			DataShapingInfo dataShapingInfo = new DataShapingInfo
			{
				Filters = (filterInstruction_0 ?? new FilterInstruction[0]),
				SortingInstructions = (sortingInstruction_0 ?? new SortingInstruction[0]),
				BlockMergingCondition = (filterInstruction_1 ?? new FilterInstruction[0])
			};
			return JsonConvert.Serialize(new MergeBlockMetaData(string_1)
			{
				DataShapingInfo = dataShapingInfo
			});
		}

		internal void method_1()
		{
			if (this.subTextPart_0 != null)
			{
				this.subTextPart_0.ScrollTo();
			}
		}

		private void method_2()
		{
			if (!string.IsNullOrEmpty(this.subTextPart_0.Data))
			{
				MergeBlockMetaData mergeBlockMetaData = this.subTextPart_0.GetMergeBlockMetaData();
				if (mergeBlockMetaData != null)
				{
					mergeBlockMetaData.Name = this.string_0;
					this.subTextPart_0.Data = JsonConvert.Serialize(mergeBlockMetaData);
				}
			}
		}
	}
}
