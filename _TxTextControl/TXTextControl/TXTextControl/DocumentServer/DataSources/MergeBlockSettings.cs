using System.Drawing;
using System.Runtime.CompilerServices;
using TXTextControl;

namespace DocumentServer.DataSources
{
	/// <summary>The MergeBlockSettings class is used to insert a table or paragraph based repeating merge block into a TextControl instance using the DataSourceManager.InsertMergeBlock method.</summary>
	public class MergeBlockSettings
	{
		internal static readonly Color color_0;

		[CompilerGenerated]
		private BlockTemplateType blockTemplateType_0;

		[CompilerGenerated]
		private bool bool_0;

		[CompilerGenerated]
		private Color color_1;

		[CompilerGenerated]
		private FieldDisplayMode fieldDisplayMode_0;

		[CompilerGenerated]
		private short short_0;

		[CompilerGenerated]
		private Table table_0;

		/// <summary>Gets or sets a value of type BlockTemplateType which specifies the type of the inserted repeating block.</summary>
		public BlockTemplateType BlockTemplateType
		{
			[CompilerGenerated]
			get
			{
				return this.blockTemplateType_0;
			}
			[CompilerGenerated]
			set
			{
				this.blockTemplateType_0 = value;
			}
		}

		/// <summary>If this property is true and property BlockTemplateType is set to BlockTemplateType.TableRow, a table header row is automatically generated.</summary>
		public bool CreateHeaderRow
		{
			[CompilerGenerated]
			get
			{
				return this.bool_0;
			}
			[CompilerGenerated]
			set
			{
				this.bool_0 = value;
			}
		}

		/// <summary>Specifies the color the inserted merge block is highlighted with if the input position is inside the block.</summary>
		public Color HighlightColor
		{
			[CompilerGenerated]
			get
			{
				return this.color_1;
			}
			[CompilerGenerated]
			set
			{
				this.color_1 = value;
			}
		}

		/// <summary>Gets or sets a value of type FieldDisplayMode which specifies the content display mode of the inserted fields.</summary>
		public FieldDisplayMode FieldDisplayMode
		{
			[CompilerGenerated]
			get
			{
				return this.fieldDisplayMode_0;
			}
			[CompilerGenerated]
			set
			{
				this.fieldDisplayMode_0 = value;
			}
		}

		/// <summary>Gets or sets the ID of the table created by DataSourceManager.InsertMergeBlock.</summary>
		public short TableID
		{
			[CompilerGenerated]
			get
			{
				return this.short_0;
			}
			[CompilerGenerated]
			set
			{
				this.short_0 = value;
			}
		}

		/// <summary>Returns the table created by DataSourceManager.InsertMergeBlock if property BlockTemplateType was set to BlockTemplateType.TableRow.</summary>
		public Table CreatedTable
		{
			[CompilerGenerated]
			get
			{
				return this.table_0;
			}
			[CompilerGenerated]
			internal set
			{
				this.table_0 = value;
			}
		}

		static MergeBlockSettings()
		{
			MergeBlockSettings.color_0 = new SubTextPart("", 0).HighlightColor;
		}

		/// <summary>Initializes a new instance of the MergeBlockSettings class.</summary>
		public MergeBlockSettings()
			: this(BlockTemplateType.TableRow)
		{
		}

		public MergeBlockSettings(BlockTemplateType blockTemplateType)
			: this(blockTemplateType, createHeaderRow: true)
		{
		}

		public MergeBlockSettings(BlockTemplateType blockTemplateType, bool createHeaderRow)
			: this(blockTemplateType, createHeaderRow, MergeBlockSettings.color_0, FieldDisplayMode.ShowFieldText)
		{
		}

		public MergeBlockSettings(BlockTemplateType blockTemplateType, bool createHeaderRow, short tableID)
			: this(blockTemplateType, createHeaderRow, MergeBlockSettings.color_0, FieldDisplayMode.ShowFieldText)
		{
			this.TableID = tableID;
		}

		public MergeBlockSettings(BlockTemplateType blockTemplateType, bool createHeaderRow, Color highlightColor, FieldDisplayMode fieldDisplayMode)
		{
			this.HighlightColor = highlightColor;
			this.BlockTemplateType = blockTemplateType;
			this.FieldDisplayMode = fieldDisplayMode;
			this.CreateHeaderRow = createHeaderRow;
			this.TableID = 0;
			this.CreatedTable = null;
		}
	}
}
