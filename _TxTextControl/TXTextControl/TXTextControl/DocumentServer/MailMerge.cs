#define TRACE
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;
using ns1;
using ns10;
using ns4;
using ns6;
using ns8;
using ns9;
using TXTextControl.DataVisualization;
using DocumentServer.DataShaping;
using DocumentServer.DataSources;
using DocumentServer.Fields;
using DocumentServer.Json;
using DocumentServer.Properties;
using DocumentServer.ProxyClasses.Barcodes;

namespace TXTextControl.DocumentServer
{
	/// <summary>The MailMerge class is a .NET component that can be used to effortlessly merge template documents with database content in .NET projects, such as ASP.NET web applications, web services or Windows services.</summary>
	[ToolboxBitmap(typeof(MailMerge))]
	[Designer("DocumentServer.MailMergeDesigner, TXTextControl.Design.dll, Version=29.0.109.500, Culture=neutral, PublicKeyToken=17fff8a774004c66")]
	public class MailMerge : Component
	{
		public abstract class MergedEventArgs : CancelEventArgs
		{
			internal bool Replaced;
		}

		public abstract class DataMergedEventArgs : MergedEventArgs
		{
			protected byte[] m_mergedData;
		}

		public delegate void DataRowMergedHandler(object sender, DataRowMergedEventArgs e);

		/// <summary>The DataRowMergedEventArgs class provides data for the DataRowMerged event.</summary>
		public class DataRowMergedEventArgs : DataMergedEventArgs
		{
			public readonly int DataRowNumber;

			[CompilerGenerated]
			private IDataRowAdapter idataRowAdapter_0;

			/// <summary>Gets or sets a byte array that contains the complete data of the merged data row.</summary>
			public byte[] MergedRow
			{
				get
				{
					return base.m_mergedData;
				}
				set
				{
					base.m_mergedData = value;
					base.Replaced = true;
				}
			}

			/// <summary>Gets the current data row's content.</summary>
			public IDataRowAdapter DataRow
			{
				[CompilerGenerated]
				get
				{
					return this.idataRowAdapter_0;
				}
				[CompilerGenerated]
				private set
				{
					this.idataRowAdapter_0 = value;
				}
			}

			public DataRowMergedEventArgs(int rowNumber, byte[] rowData)
				: this(rowNumber, rowData, null)
			{
			}

			internal DataRowMergedEventArgs(int rowNumber, byte[] rowData, IDataRowAdapter dataRow)
			{
				this.DataRowNumber = rowNumber;
				base.m_mergedData = rowData;
				this.DataRow = dataRow;
			}
		}

		public delegate void BlockMergingHandler(object sender, BlockMergingEventArgs e);

		/// <summary>The BlockMergingEventArgs class provides data for the BlockMerging event.</summary>
		public class BlockMergingEventArgs : CancelEventArgs
		{
			[CompilerGenerated]
			private string string_0;

			[CompilerGenerated]
			private IDataRowAdapter[] idataRowAdapter_0;

			/// <summary>Gets the name of the merge block the event was fired for.</summary>
			public string BlockName
			{
				[CompilerGenerated]
				get
				{
					return this.string_0;
				}
				[CompilerGenerated]
				private set
				{
					this.string_0 = value;
				}
			}

			/// <summary>Gets the block data as an array of data rows.</summary>
			public IDataRowAdapter[] BlockData
			{
				[CompilerGenerated]
				get
				{
					return this.idataRowAdapter_0;
				}
				[CompilerGenerated]
				private set
				{
					this.idataRowAdapter_0 = value;
				}
			}

			/// <summary>Gets the column names of the table supplying the data for the block.</summary>
			public string[] ColumnNames
			{
				get
				{
					if (this.BlockData.Length == 0)
					{
						return new string[0];
					}
					IDataTableAdapter table = this.BlockData[0].Table;
					if (table == null)
					{
						return new string[0];
					}
					return table.ColumnNames;
				}
			}

			public BlockMergingEventArgs(string blockName, IDataRowAdapter[] data)
			{
				this.BlockData = data;
				this.BlockName = blockName;
			}
		}

		public delegate void BlockRowMergedHandler(object sender, BlockRowMergedEventArgs e);

		/// <summary>The BlockRowMergedEventArgs class provides data for the BlockRowMerged event.</summary>
		public class BlockRowMergedEventArgs : DataMergedEventArgs
		{
			public readonly int DataRowNumber;

			public readonly int DataRowCount;

			public readonly string MergeBlockName;

			/// <summary>Gets or sets a byte[] array that contains the complete data of the merged block row.</summary>
			public byte[] MergedBlockRow
			{
				get
				{
					return base.m_mergedData;
				}
				set
				{
					base.m_mergedData = value;
					base.Replaced = true;
				}
			}

			public BlockRowMergedEventArgs(int num, int count, string blockName, byte[] document)
			{
				this.DataRowNumber = num;
				this.DataRowCount = count;
				this.MergeBlockName = blockName;
				base.m_mergedData = document;
			}
		}

		public delegate void FieldMergedHandler(object sender, FieldMergedEventArgs e);

		/// <summary>The FieldMergedEventArgs class provides data for the FieldMerged event.</summary>
		public class FieldMergedEventArgs : DataMergedEventArgs
		{
			public readonly bool Merged;

			private MailMergeFieldAdapter mailMergeFieldAdapter_0;

			[CompilerGenerated]
			private IDataRowAdapter idataRowAdapter_0;

			[CompilerGenerated]
			private string string_0;

			[CompilerGenerated]
			private int int_0;

			[CompilerGenerated]
			private TableCell tableCell_0;

			[CompilerGenerated]
			private bool bool_0;

			/// <summary>Gets or sets a MailMergeFieldAdapter that contains the already merged field.</summary>
			public MailMergeFieldAdapter MailMergeFieldAdapter
			{
				get
				{
					return this.mailMergeFieldAdapter_0;
				}
				set
				{
					this.mailMergeFieldAdapter_0 = value;
					this.Boolean_0 = true;
				}
			}

			/// <summary>Gets or sets a byte array that contains the complete data of the merged field.</summary>
			public byte[] MergedField
			{
				get
				{
					return base.m_mergedData;
				}
				set
				{
					base.m_mergedData = value;
					base.Replaced = true;
				}
			}

			/// <summary>Gets the data row which is used to supply the current field with merge content.</summary>
			public IDataRowAdapter DataRow
			{
				[CompilerGenerated]
				get
				{
					return this.idataRowAdapter_0;
				}
				[CompilerGenerated]
				private set
				{
					this.idataRowAdapter_0 = value;
				}
			}

			/// <summary>If the merge field is part of a merge block, this property returns the name of the block.</summary>
			public string MergeBlockName
			{
				[CompilerGenerated]
				get
				{
					return this.string_0;
				}
				[CompilerGenerated]
				private set
				{
					this.string_0 = value;
				}
			}

			/// <summary>If the merge field is part of a merge block, this property returns the one-based nesting depth of the block.</summary>
			public int NestingDepth
			{
				[CompilerGenerated]
				get
				{
					return this.int_0;
				}
				[CompilerGenerated]
				private set
				{
					this.int_0 = value;
				}
			}

			/// <summary>If the merge field is inside of a table, this property returns the containing table cell as a TXTextControl.TableCell instance or null otherwise.</summary>
			public TableCell TableCell
			{
				[CompilerGenerated]
				get
				{
					return this.tableCell_0;
				}
				[CompilerGenerated]
				private set
				{
					this.tableCell_0 = value;
				}
			}

			internal bool Boolean_0
			{
				[CompilerGenerated]
				get
				{
					return this.bool_0;
				}
				[CompilerGenerated]
				private set
				{
					this.bool_0 = value;
				}
			}

			public FieldMergedEventArgs(MailMergeFieldAdapter mergeField, byte[] fieldData, bool merged)
				: this(mergeField, fieldData, merged, null, null, null)
			{
			}

			internal FieldMergedEventArgs(MailMergeFieldAdapter mergeField, byte[] fieldData, bool merged, IDataRowAdapter dataRow, TableCell tableCell, Class86 mergeBlock)
			{
				this.mailMergeFieldAdapter_0 = mergeField;
				base.m_mergedData = fieldData;
				this.DataRow = dataRow;
				this.Merged = merged;
				this.TableCell = tableCell;
				if (mergeBlock != null)
				{
					this.NestingDepth = mergeBlock.Int32_3;
					this.MergeBlockName = mergeBlock.String_0;
				}
				else
				{
					this.NestingDepth = 0;
					this.MergeBlockName = "";
				}
			}
		}

		public delegate void ImageFieldMergedHandler(object sender, ImageFieldMergedEventArgs e);

		/// <summary>The ImageFieldMergedEventArgs class provides data for the ImageFieldMerged event.</summary>
		public class ImageFieldMergedEventArgs : MergedEventArgs
		{
			public readonly bool Merged;

			public readonly string FieldName;

			public readonly string Filename;

			private Image image_0;

			[CompilerGenerated]
			private TableCell tableCell_0;

			[CompilerGenerated]
			private string string_0;

			[CompilerGenerated]
			private int int_0;

			/// <summary>If the image field is inside of a table, this property returns the containing table cell as a TXTextControl.TableCell instance or null otherwise.</summary>
			public TableCell TableCell
			{
				[CompilerGenerated]
				get
				{
					return this.tableCell_0;
				}
				[CompilerGenerated]
				private set
				{
					this.tableCell_0 = value;
				}
			}

			/// <summary>If the image field is part of a merge block, this property returns the name of the block.</summary>
			public string MergeBlockName
			{
				[CompilerGenerated]
				get
				{
					return this.string_0;
				}
				[CompilerGenerated]
				private set
				{
					this.string_0 = value;
				}
			}

			/// <summary>If the image field is part of a merge block, this property returns the one-based nesting depth of the block.</summary>
			public int NestingDepth
			{
				[CompilerGenerated]
				get
				{
					return this.int_0;
				}
				[CompilerGenerated]
				private set
				{
					this.int_0 = value;
				}
			}

			/// <summary>Gets or sets the image that has been merged into the field.</summary>
			public Image Image
			{
				get
				{
					return this.image_0;
				}
				set
				{
					this.image_0 = value;
					base.Replaced = true;
				}
			}

			public ImageFieldMergedEventArgs(string fieldName, string filename, Image image, bool merged)
				: this(fieldName, filename, image, merged, null, null)
			{
			}

			internal ImageFieldMergedEventArgs(string fieldName, string filename, Image image, bool merged, TableCell tableCell, Class86 mergeBlock)
			{
				this.FieldName = fieldName;
				this.Filename = filename;
				this.image_0 = image;
				this.Merged = merged;
				this.TableCell = tableCell;
				if (mergeBlock != null)
				{
					this.NestingDepth = mergeBlock.Int32_3;
					this.MergeBlockName = mergeBlock.String_0;
				}
				else
				{
					this.NestingDepth = 0;
					this.MergeBlockName = "";
				}
			}
		}

		public delegate void IncludeTextMergingHandler(object sender, IncludeTextMergingEventArgs e);

		/// <summary>The IncludeTextMergingEventArgs class provides data for the IncludeTextMerging event.</summary>
		public class IncludeTextMergingEventArgs : DataMergedEventArgs
		{
			public readonly string Filename;

			[CompilerGenerated]
			private IncludeText includeText_0;

			/// <summary>Represents the currently merged INCLUDETEXT field.</summary>
			public IncludeText IncludeTextField
			{
				[CompilerGenerated]
				get
				{
					return this.includeText_0;
				}
				[CompilerGenerated]
				private set
				{
					this.includeText_0 = value;
				}
			}

			/// <summary>Sets a byte[] array that contains the complete data of the IncludeText document.</summary>
			public byte[] IncludeTextDocument
			{
				get
				{
					return base.m_mergedData;
				}
				set
				{
					base.m_mergedData = value;
				}
			}

			public IncludeTextMergingEventArgs(string filename, IncludeText includeTextField)
			{
				this.Filename = filename;
				this.IncludeTextField = includeTextField;
			}
		}

		public delegate void ChartMergedHandler(object sender, ChartMergedEventArgs e);

		/// <summary>The ChartMergedEventArgs class provides data for the ChartMerged event.</summary>
		public class ChartMergedEventArgs : EventArgs
		{
			[CompilerGenerated]
			private ChartFrame chartFrame_0;

			/// <summary>Gets a ChartFrame object representing the merged chart in the document.</summary>
			public ChartFrame ChartFrame
			{
				[CompilerGenerated]
				get
				{
					return this.chartFrame_0;
				}
				[CompilerGenerated]
				private set
				{
					this.chartFrame_0 = value;
				}
			}

			public ChartMergedEventArgs(ChartFrame chartFrame)
			{
				this.ChartFrame = chartFrame;
			}
		}

		public delegate void BarcodeMergedHandler(object sender, BarcodeMergedEventArgs e);

		/// <summary>The BarcodeMergedEventArgs class provides data for the BarcodeMerged event.</summary>
		public class BarcodeMergedEventArgs : EventArgs
		{
			[CompilerGenerated]
			private BarcodeFrame barcodeFrame_0;

			/// <summary>Gets a BarcodeFrame object representing the merged barcode in the document.</summary>
			public BarcodeFrame BarcodeFrame
			{
				[CompilerGenerated]
				get
				{
					return this.barcodeFrame_0;
				}
				[CompilerGenerated]
				private set
				{
					this.barcodeFrame_0 = value;
				}
			}

			public BarcodeMergedEventArgs(BarcodeFrame barcodeFrame)
			{
				this.BarcodeFrame = barcodeFrame;
			}
		}

		public delegate void ImageMergedHandler(object sender, ImageMergedEventArgs e);

		/// <summary>The ImageMergedEventArgs class provides data for the ImageMerged event.</summary>
		public class ImageMergedEventArgs : EventArgs
		{
			private System.Drawing.Image image_0;

			internal bool bool_0;

			[CompilerGenerated]
			private string string_0;

			[CompilerGenerated]
			private int int_0;

			[CompilerGenerated]
			private bool bool_1;

			[CompilerGenerated]
			private IDataRowAdapter idataRowAdapter_0;

			[CompilerGenerated]
			private string string_1;

			[CompilerGenerated]
			private int int_1;

			/// <summary>Gets or sets the merged image.</summary>
			public System.Drawing.Image Image
			{
				get
				{
					return this.image_0;
				}
				set
				{
					this.image_0 = value;
					this.bool_0 = true;
				}
			}

			/// <summary>Gets the name of the merged image.</summary>
			public string Name
			{
				[CompilerGenerated]
				get
				{
					return this.string_0;
				}
				[CompilerGenerated]
				private set
				{
					this.string_0 = value;
				}
			}

			public int Int32_0
			{
				[CompilerGenerated]
				get
				{
					return this.int_0;
				}
				[CompilerGenerated]
				private set
				{
					this.int_0 = value;
				}
			}

			/// <summary>Gets a boolean value that indicates whether the current image has been merged successfully or not.</summary>
			public bool Merged
			{
				[CompilerGenerated]
				get
				{
					return this.bool_1;
				}
				[CompilerGenerated]
				private set
				{
					this.bool_1 = value;
				}
			}

			/// <summary>Gets the data row which is used to supply the current image with merge content.</summary>
			public IDataRowAdapter DataRow
			{
				[CompilerGenerated]
				get
				{
					return this.idataRowAdapter_0;
				}
				[CompilerGenerated]
				private set
				{
					this.idataRowAdapter_0 = value;
				}
			}

			/// <summary>If the image is part of a merge block, this property returns the name of the block.</summary>
			public string MergeBlockName
			{
				[CompilerGenerated]
				get
				{
					return this.string_1;
				}
				[CompilerGenerated]
				private set
				{
					this.string_1 = value;
				}
			}

			/// <summary>If the image is part of a merge block, this property returns the one-based nesting depth of the block.</summary>
			public int NestingDepth
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

			public ImageMergedEventArgs(System.Drawing.Image image, string name, int int_2)
				: this(image, name, int_2, null, null)
			{
			}

			internal ImageMergedEventArgs(System.Drawing.Image image, string name, int int_2, IDataRowAdapter row, Class86 mergeBlock)
			{
				this.image_0 = image;
				this.Name = name;
				this.Merged = image != null;
				this.Int32_0 = int_2;
				this.DataRow = row;
				if (mergeBlock != null)
				{
					this.NestingDepth = mergeBlock.Int32_3;
					this.MergeBlockName = mergeBlock.String_0;
				}
				else
				{
					this.NestingDepth = 0;
					this.MergeBlockName = "";
				}
			}
		}

		[Flags]
		internal enum Enum7
		{
			flag_0 = 0x1,
			flag_1 = 0x2,
			flag_2 = 0x4,
			flag_3 = 0x8
		}

		private static readonly string[] string_0 = new string[5] { "BM", "ÿØÿ", "\u0089PNG\r\n\u001a\n", "GIF8", "II*\0" };

		private bool bool_0;

		private bool bool_1;

		private bool bool_2;

		private byte[] byte_0;

		private byte[] byte_1;

		private string string_1 = "";

		private string string_2 = "";

		private XmlDocument xmlDocument_0;

		private Class103 class103_0;

		private Struct24? nullable_0;

		internal static Enum8? nullable_1 = null;

		private int int_0;

		private string string_3 = "";

		internal AttributeCollection attributeCollection_0;

		internal AttributeCollection attributeCollection_1;

		internal int int_1;

		internal int int_2;

		internal int int_3;

		internal const string string_4 = "image:";

		internal const string string_5 = "TXDocumentServer.Windows.Forms, Version=29.0.1200.500, Culture=neutral, PublicKeyToken=17fff8a774004c66";

		internal const string string_6 = "TXDocumentServer.WPF, Version=29.0.1200.500, Culture=neutral, PublicKeyToken=17fff8a774004c66";

		private static Assembly assembly_0;

		private static Assembly assembly_1;

		private TraceSource traceSource_0 = new TraceSource("DocumentServer.MailMerge");

		[CompilerGenerated]
		private bool bool_3;

		[CompilerGenerated]
		private bool bool_4;

		[CompilerGenerated]
		private bool bool_5;

		[CompilerGenerated]
		private bool bool_6;

		[CompilerGenerated]
		private bool bool_7;

		[CompilerGenerated]
		private bool bool_8;

		internal const Enum8 enum8_0 = Enum8.const_1;

		private IContainer icontainer_0;

		/// <summary>Gets or sets the TextComponent object which is associated with the MailMerge component.</summary>
		[Attribute1("PROP_MAILMERGE_TEXTCOMPONENT")]
		[DefaultValue(null)]
		[TypeConverter(typeof(Class92))]
		public object TextComponent
		{
			get
			{
				if (this.class103_0 == null)
				{
					return null;
				}
				return this.class103_0.Object_0;
			}
			set
			{
				if (Class103.smethod_0(value))
				{
					this.class103_0 = new Class103(value, base.DesignMode);
					this.nullable_0 = this.class103_0.Struct24_0;
					this.byte_1 = null;
					this.byte_0 = null;
					return;
				}
				if (value != null)
				{
					throw new ArgumentException(Resources.EXC_MAILMERGE_INVALID_TEXT_COMPONENT);
				}
				this.class103_0 = null;
				this.nullable_0 = null;
				this.byte_1 = null;
				this.byte_0 = null;
			}
		}

		/// <summary>Specifies whether the content of empty merge blocks should be removed from the template or not.</summary>
		[Attribute1("PROP_MAILMERGE_REMOVEEMPTYBLOCKS")]
		[DefaultValue(true)]
		public bool RemoveEmptyBlocks
		{
			[CompilerGenerated]
			get
			{
				return this.bool_3;
			}
			[CompilerGenerated]
			set
			{
				this.bool_3 = value;
			}
		}

		/// <summary>Specifies whether empty fields should be removed from the template or not.</summary>
		[Attribute1("PROP_MAILMERGE_REMOVEEMPTYFIELDS")]
		[DefaultValue(true)]
		public bool RemoveEmptyFields
		{
			[CompilerGenerated]
			get
			{
				return this.bool_4;
			}
			[CompilerGenerated]
			set
			{
				this.bool_4 = value;
			}
		}

		/// <summary>Specifies whether images which don't have merge data should be removed from the template or not.</summary>
		[Attribute1("PROP_MAILMERGE_REMOVEEMPTYIMAGES")]
		[DefaultValue(false)]
		public bool RemoveEmptyImages
		{
			[CompilerGenerated]
			get
			{
				return this.bool_5;
			}
			[CompilerGenerated]
			set
			{
				this.bool_5 = value;
			}
		}

		/// <summary>Specifies whether trailing whitespace should be removed before saving a document.</summary>
		[Attribute1("PROP_MAILMERGE_REMOVETRAILINGWHITESPACE")]
		[DefaultValue(true)]
		public bool RemoveTrailingWhitespace
		{
			[CompilerGenerated]
			get
			{
				return this.bool_6;
			}
			[CompilerGenerated]
			set
			{
				this.bool_6 = value;
			}
		}

		/// <summary>Specifies whether the template page size and margins should be used or not.</summary>
		[Attribute1("PROP_MAILMERGE_USETEMPLATEFORMAT")]
		[DefaultValue(true)]
		public bool UseTemplateFormat
		{
			[CompilerGenerated]
			get
			{
				return this.bool_7;
			}
			[CompilerGenerated]
			set
			{
				this.bool_7 = value;
			}
		}

		/// <summary>Specifies a directory name where sub-templates and images (for image merging) should be searched.</summary>
		[Attribute1("PROP_MAILMERGE_SEARCHPATH")]
		[Editor(typeof(Class79), typeof(UITypeEditor))]
		[DefaultValue("")]
		public string SearchPath
		{
			get
			{
				return this.string_1;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					this.string_1 = "";
					return;
				}
				if (base.DesignMode)
				{
					this.string_1 = value;
					return;
				}
				if (!Directory.Exists(value))
				{
					throw new ArgumentException(Resources.EXC_MAILMERGE_INVALID_SEARCH_PATH);
				}
				this.string_1 = value;
			}
		}

		/// <summary>Gets or sets the file path of a Report Data Source Configuration file (*.rdsc) which has been created with TX Text Control Words.</summary>
		[Category("Data")]
		[Attribute1("PROP_MAILMERGE_REPORTDATASOURCECONFIGFILE")]
		[Editor(typeof(Class88), typeof(UITypeEditor))]
		[DefaultValue("")]
		public string ReportDataSourceConfigFile
		{
			get
			{
				return this.string_2;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					this.string_2 = "";
				}
				else
				{
					this.string_2 = value;
				}
			}
		}

		/// <summary>Specifies the Report Data Source Configuration as an XML string.</summary>
		[Browsable(false)]
		[DefaultValue("")]
		public string ReportDataSourceConfig
		{
			get
			{
				if (this.xmlDocument_0 == null)
				{
					return "";
				}
				return this.xmlDocument_0.OuterXml;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					this.xmlDocument_0 = null;
				}
				else if (!this.method_52(value))
				{
					throw new ArgumentException(Resources.EXC_MAILMERGE_INVALID_REPORT_DATA_SOURCE_CONFIG_DATA);
				}
			}
		}

		/// <summary>Specifies the template file path.</summary>
		[Category("Data")]
		[Attribute1("PROP_MAILMERGE_TEMPLATEFILE")]
		[Editor(typeof(Class89), typeof(UITypeEditor))]
		[DefaultValue("")]
		public string TemplateFile
		{
			get
			{
				return this.string_3;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					this.string_3 = "";
				}
				else
				{
					this.string_3 = value;
				}
			}
		}

		/// <summary>A static property returning the internal merge block name prefix “txmb_”.</summary>
		[Browsable(false)]
		public static string MergeBlockNamePrefix => "txmb_";

		internal static Enum8 Enum8_0
		{
			get
			{
				if (!MailMerge.nullable_1.HasValue)
				{
					MailMerge.nullable_1 = MailMerge.smethod_11();
				}
				return MailMerge.nullable_1.GetValueOrDefault();
			}
		}

		/// <summary>Specifies whether text lines which are empty after merging should be removed from the template or not.</summary>
		[Attribute1("PROP_MAILMERGE_REMOVEEMPTYLINES")]
		[DefaultValue(false)]
		public bool RemoveEmptyLines
		{
			[CompilerGenerated]
			get
			{
				return this.bool_8;
			}
			[CompilerGenerated]
			set
			{
				this.bool_8 = value;
			}
		}

		internal static Assembly Assembly_0
		{
			get
			{
				if (MailMerge.assembly_0 == null)
				{
					MailMerge.assembly_0 = Assembly.Load(new AssemblyName("TXDocumentServer.Windows.Forms, Version=29.0.1200.500, Culture=neutral, PublicKeyToken=17fff8a774004c66"));
				}
				return MailMerge.assembly_0;
			}
		}

		internal static Assembly Assembly_1
		{
			get
			{
				if (MailMerge.assembly_1 == null)
				{
					MailMerge.assembly_1 = Assembly.Load(new AssemblyName("TXDocumentServer.WPF, Version=29.0.1200.500, Culture=neutral, PublicKeyToken=17fff8a774004c66"));
				}
				return MailMerge.assembly_1;
			}
		}

		/// <summary>Occurs when a data row has been merged successfully.</summary>
		[Attribute1("EVT_MAILMERGE_DATAROWMERGED")]
		public event DataRowMergedHandler DataRowMerged;

		/// <summary>Occurs when a merge block is about to be merged.</summary>
		[Attribute1("EVT_MAILMERGE_BLOCKMERGING")]
		public event BlockMergingHandler BlockMerging;

		/// <summary>Occurs when a merge block row has been merged successfully.</summary>
		[Attribute1("EVT_MAILMERGE_BLOCKROWMERGED")]
		public event BlockRowMergedHandler BlockRowMerged;

		/// <summary>Occurs when a field has been merged.</summary>
		[Attribute1("EVT_MAILMERGE_FIELDMERGED")]
		public event FieldMergedHandler FieldMerged;

		/// <summary>Occurs when an image field, i.e., a merge field whose name is prefixed with "image:" has been merged.</summary>
		[Obsolete]
		[Attribute1("EVT_MAILMERGE_IMAGEFIELDMERGED")]
		public event ImageFieldMergedHandler ImageFieldMerged;

		/// <summary>Occurs when an IncludeText field has been merged.</summary>
		[Attribute1("EVT_MAILMERGE_INCLUDETEXTMERGING")]
		public event IncludeTextMergingHandler IncludeTextMerging;

		/// <summary>Occurs when a chart has been merged successfully.</summary>
		[Attribute1("EVT_MAILMERGE_CHARTMERGED")]
		public event ChartMergedHandler ChartMerged;

		/// <summary>Occurs when a barcode has been merged successfully.</summary>
		[Attribute1("EVT_MAILMERGE_BARCODEMERGED")]
		public event BarcodeMergedHandler BarcodeMerged;

		/// <summary>Occurs when an image has been merged successfully.</summary>
		[Attribute1("EVT_MAILMERGE_IMAGEMERGED")]
		public event ImageMergedHandler ImageMerged;

		private void method_0(BarcodeFrame barcodeFrame_0, IDataRowAdapter idataRowAdapter_0)
		{
			if (idataRowAdapter_0 != null)
			{
				if (idataRowAdapter_0.Table.ColumnNames.Contains(barcodeFrame_0.Name.ToLower()))
				{
					this.method_1(barcodeFrame_0, idataRowAdapter_0[barcodeFrame_0.Name]);
				}
				else if (barcodeFrame_0.Name.IsChildColumnName())
				{
					string[] childTableNames = barcodeFrame_0.Name.ToChildTableNames();
					string childColumnName = barcodeFrame_0.Name.ToChildColumnName();
					object nestedChildColumnContent = idataRowAdapter_0.GetNestedChildColumnContent(childTableNames, childColumnName);
					this.method_1(barcodeFrame_0, nestedChildColumnContent);
				}
			}
		}

		private void method_1(BarcodeFrame barcodeFrame_0, object object_0)
		{
			if (object_0 == null)
			{
				return;
			}
			string text = object_0 as string;
			if (text == null)
			{
				try
				{
					text = ((int)object_0).ToString();
				}
				catch
				{
					this.traceSource_0.TraceEvent(TraceEventType.Information, 3, "Data not suitable for barcode display. (" + object_0.ToString() + ")");
					return;
				}
			}
			BarcodeControlProxy barcodeControlProxy = BarcodeControlProxyFactory.MakeControlProxy(barcodeFrame_0);
			if (barcodeControlProxy.ControlAssembly == null)
			{
				this.traceSource_0.TraceEvent(TraceEventType.Information, 3, "Barcode control assembly for this UI framework not installed.");
				return;
			}
			ns9.FieldMergedEventArgs barcodeType = barcodeControlProxy.BarcodeType;
			int maximumTextLength = barcodeControlProxy.GetMaximumTextLength(barcodeType);
			int minimumTextLength = barcodeControlProxy.GetMinimumTextLength(barcodeType);
			if (maximumTextLength >= text.Length && minimumTextLength <= text.Length)
			{
				try
				{
					if (barcodeControlProxy.UpperTextLength < text.Length)
					{
						barcodeControlProxy.UpperTextLength = text.Length;
					}
					barcodeControlProxy.Text = text;
					this.OnBarcodeMerged(this, new BarcodeMergedEventArgs(barcodeFrame_0));
					barcodeFrame_0.Name = string.Empty;
				}
				catch (Exception ex)
				{
					string text2 = "Problem setting barcode data: " + ex.Message;
					if (ex.InnerException != null)
					{
						text2 = text2 + "\r\nInner Exception: " + ex.InnerException.Message;
					}
					text2 = text2 + "\r\n(Barcode type: " + barcodeType.ToString() + ", data: " + text + ")";
					this.traceSource_0.TraceEvent(TraceEventType.Warning, 3, text2);
				}
			}
			else
			{
				this.traceSource_0.TraceEvent(TraceEventType.Information, 3, "Data length not suitable for barcode type " + barcodeType.ToString() + ". Data length: " + text.Length + ", must be between " + minimumTextLength + " and " + maximumTextLength + ".");
			}
		}

		/// <summary>Merges all repeating blocks that are contained in the loaded template with the System.Data.DataTable instances contained in the given System.Data.DataSet. The name of the System.Data.DataTable must match the name of the block in the template. The supported format of the repeating blocks can be found in the ASP.NET User's Guide.</summary>
		/// <param name="mergeData">Specifies a System.Data.DataSet that contains the merge data.</param>
		[Obsolete]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public int MergeBlocks(DataSet mergeData)
		{
			if (this.byte_1 == null)
			{
				this.method_53(this.string_3);
			}
			if (this.byte_1 == null)
			{
				this.method_44();
			}
			this.method_43(Enum7.flag_0 | Enum7.flag_1);
			if (mergeData == null)
			{
				return 0;
			}
			this.int_0 = 0;
			List<Class86> list_ = Class86.smethod_0(this.byte_1, this.traceSource_0, bool_0: false, this.TextComponent);
			using (ServerTextControl serverTextControl = this.method_46(this.byte_1))
			{
				serverTextControl.IsFormulaCalculationEnabled = false;
				this.method_32(serverTextControl, ref list_, bool_9: false);
				if (list_.Count == 0)
				{
					return 0;
				}
				list_.Reverse();
				foreach (Class86 item in list_)
				{
					if (mergeData.Tables.Contains(item.String_0))
					{
						Class130 @class = new Class130(mergeData.Tables[item.String_0]);
						this.method_3(item, @class.Rows, serverTextControl);
					}
				}
				serverTextControl.IsFormulaCalculationEnabled = true;
				serverTextControl.Save(out this.byte_1, BinaryStreamType.InternalUnicodeFormat);
			}
			return this.int_0;
		}

		private void method_2(ServerTextControl serverTextControl_0, List<Class86> list_0, IDataRowAdapter idataRowAdapter_0)
		{
			if (list_0 == null || list_0.Count == 0 || idataRowAdapter_0 == null)
			{
				return;
			}
			List<Class86> list = new List<Class86>(list_0);
			list.Reverse();
			foreach (Class86 item in list)
			{
				if (item.DataShapingInfo_0 != null && item.DataShapingInfo_0.BlockMergingCondition != null && item.DataShapingInfo_0.BlockMergingCondition.Length != 0 && !item.DataShapingInfo_0.BlockMergingCondition.Match(idataRowAdapter_0))
				{
					if (this.RemoveEmptyBlocks)
					{
						serverTextControl_0.RemoveSubTextPartAtPos(item.Int32_0);
					}
					continue;
				}
				IDataRowAdapter[] idataRowAdapter_ = idataRowAdapter_0.GetChildRows(item.String_0);
				if (idataRowAdapter_.Length == 0)
				{
					this.method_5(serverTextControl_0, item);
					continue;
				}
				if (item.DataShapingInfo_0 != null)
				{
					this.method_11(ref idataRowAdapter_, item.DataShapingInfo_0.Filters);
					this.method_12(ref idataRowAdapter_, item.DataShapingInfo_0.SortingInstructions);
				}
				this.method_3(item, idataRowAdapter_, serverTextControl_0);
			}
		}

		private void method_3(Class86 class86_0, IDataRowAdapter[] idataRowAdapter_0, ServerTextControl serverTextControl_0)
		{
			List<byte[]> list = new List<byte[]>();
			serverTextControl_0.RemoveSubTextPartAtPos(class86_0.Int32_0);
			BlockMergingEventArgs blockMergingEventArgs = new BlockMergingEventArgs(class86_0.String_0, idataRowAdapter_0);
			this.OnBlockMerging(blockMergingEventArgs);
			if (blockMergingEventArgs.Cancel)
			{
				return;
			}
			using (ServerTextControl serverTextControl = this.method_47())
			{
				serverTextControl.IsFormulaCalculationEnabled = false;
				byte[] byte_ = (byte[])class86_0.Byte_0.Clone();
				for (int i = 0; i < idataRowAdapter_0.Length; i++)
				{
					if (i == 1)
					{
						this.method_6(ref byte_);
					}
					serverTextControl.Load(byte_, BinaryStreamType.InternalUnicodeFormat, new LoadSettings
					{
						ApplicationFieldFormat = ApplicationFieldFormat.MSWordTXFormFields
					});
					this.method_10(serverTextControl);
					byte[] array = this.method_19(serverTextControl, idataRowAdapter_0, class86_0, class86_0.List_0, ref i);
					BlockRowMergedEventArgs blockRowMergedEventArgs = new BlockRowMergedEventArgs(i, idataRowAdapter_0.Length, class86_0.String_0, array);
					this.OnBlockMerged(blockRowMergedEventArgs);
					if (blockRowMergedEventArgs.Replaced && blockRowMergedEventArgs.MergedBlockRow != null)
					{
						array = blockRowMergedEventArgs.MergedBlockRow;
					}
					list.Add(array);
					this.int_0++;
				}
			}
			byte[] binaryData = this.method_4(list, AppendSettings.None, bool_9: true);
			serverTextControl_0.InputPosition = new InputPosition(class86_0.Int32_0 - 1, TextFieldPosition.OutsideTextField);
			serverTextControl_0.Selection.Text = " ";
			serverTextControl_0.Selection.Start--;
			serverTextControl_0.Selection.Length = 1;
			serverTextControl_0.Selection.Load(binaryData, BinaryStreamType.InternalUnicodeFormat, new LoadSettings
			{
				ApplicationFieldFormat = ApplicationFieldFormat.MSWordTXFormFields
			});
		}

		private byte[] method_4(List<byte[]> list_0, AppendSettings appendSettings_0, bool bool_9)
		{
			byte[] binaryData = null;
			using ServerTextControl serverTextControl = this.method_47();
			for (int i = 0; i < list_0.Count; i++)
			{
				byte[] binaryData2 = list_0[i];
				if (i == 0)
				{
					serverTextControl.Load(binaryData2, BinaryStreamType.InternalUnicodeFormat, new LoadSettings
					{
						ApplicationFieldFormat = ApplicationFieldFormat.MSWordTXFormFields
					});
				}
				else
				{
					serverTextControl.Append(binaryData2, BinaryStreamType.InternalUnicodeFormat, new LoadSettings
					{
						ApplicationFieldFormat = ApplicationFieldFormat.MSWordTXFormFields
					}, appendSettings_0);
				}
			}
			if (bool_9)
			{
				MailMerge.smethod_15(serverTextControl);
			}
			serverTextControl.Save(out binaryData, BinaryStreamType.InternalUnicodeFormat);
			return binaryData;
		}

		/// <summary>Lists the names of all merge blocks contained in the currently loaded template.</summary>
		public string[] GetBlockNames()
		{
			List<Class86> list = this.method_7();
			List<string> list2 = new List<string>();
			foreach (Class86 item in list)
			{
				list2.Add(item.String_0);
			}
			return list2.ToArray();
		}

		/// <summary>Returns the names of all merge fields inside the merge block with the specified name.</summary>
		/// <param name="blockName">Specifies the name of the block for which the field names are returned.</param>
		public string[] GetBlockFieldNames(string blockName)
		{
			Class86 @class = this.method_7().Find((Class86 class86_0) => class86_0.String_0 == blockName);
			if (@class == null)
			{
				return new string[0];
			}
			return @class.List_1.ToArray();
		}

		private void method_5(ServerTextControl serverTextControl_0, Class86 class86_0)
		{
			BlockRowMergedEventArgs blockRowMergedEventArgs = new BlockRowMergedEventArgs(0, 0, class86_0.String_0, (byte[])class86_0.Byte_0.Clone());
			this.OnBlockMerged(blockRowMergedEventArgs);
			if (blockRowMergedEventArgs.Replaced && blockRowMergedEventArgs.MergedBlockRow != null)
			{
				serverTextControl_0.RemoveSubTextPartAtPos(class86_0.Int32_0);
				serverTextControl_0.InputPosition = new InputPosition(class86_0.Int32_0 - 1, TextFieldPosition.OutsideTextField);
				serverTextControl_0.Selection.Load(blockRowMergedEventArgs.MergedBlockRow, BinaryStreamType.InternalUnicodeFormat, new LoadSettings
				{
					ApplicationFieldFormat = ApplicationFieldFormat.MSWordTXFormFields
				});
			}
			else if (this.RemoveEmptyBlocks)
			{
				serverTextControl_0.RemoveSubTextPartAtPos(class86_0.Int32_0);
			}
		}

		private void method_6(ref byte[] byte_2)
		{
			if (byte_2 == null || byte_2.Length == 0)
			{
				return;
			}
			using ServerTextControl serverTextControl = this.method_46(byte_2);
			List<Paragraph> list = new List<Paragraph>();
			foreach (Paragraph paragraph in serverTextControl.Paragraphs)
			{
				list.Add(paragraph);
			}
			if (list.Count == 2 && list[1].Text == string.Empty)
			{
				list[0].ListFormat.RestartNumbering = false;
				serverTextControl.Save(out byte_2, BinaryStreamType.InternalUnicodeFormat);
			}
		}

		private List<Class86> method_7()
		{
			if (this.byte_1 == null)
			{
				this.method_53(this.string_3);
			}
			if (this.byte_1 == null)
			{
				this.method_44();
			}
			this.method_43(Enum7.flag_1);
			List<Class86> list_ = Class86.smethod_0(this.byte_1, this.traceSource_0, bool_0: false, this.TextComponent);
			return this.method_8(list_);
		}

		private List<Class86> method_8(List<Class86> list_0)
		{
			List<Class86> list = new List<Class86>();
			foreach (Class86 item in list_0)
			{
				list.AddRange(this.method_9(item));
			}
			return list;
		}

		private IEnumerable<Class86> method_9(Class86 class86_0)
		{
			List<Class86> list = new List<Class86>();
			list.Add(class86_0);
			foreach (Class86 item in class86_0.List_0)
			{
				list.AddRange(this.method_9(item));
			}
			return list;
		}

		private void method_10(ServerTextControl serverTextControl_0)
		{
			serverTextControl_0.HeadersAndFooters.Remove(HeaderFooterType.All);
			foreach (Section section in serverTextControl_0.Sections)
			{
				section.HeadersAndFooters.Remove(HeaderFooterType.All);
			}
		}

		private void method_11(ref IDataRowAdapter[] idataRowAdapter_0, FilterInstruction[] filterInstruction_0)
		{
			if (filterInstruction_0 != null && filterInstruction_0.Length != 0)
			{
				idataRowAdapter_0 = idataRowAdapter_0.Where((IDataRowAdapter row) => filterInstruction_0.Match(row)).ToArray();
			}
		}

		private void method_12(ref IDataRowAdapter[] idataRowAdapter_0, SortingInstruction[] sortingInstruction_0)
		{
			if (sortingInstruction_0 != null && sortingInstruction_0.Length != 0)
			{
				List<IDataRowAdapter[]> list_ = new List<IDataRowAdapter[]>(new IDataRowAdapter[1][] { idataRowAdapter_0 });
				foreach (SortingInstruction sortingInstruction_ in sortingInstruction_0)
				{
					this.method_13(ref list_, sortingInstruction_);
				}
				idataRowAdapter_0 = list_.SelectMany((IDataRowAdapter[] x) => x).ToArray();
			}
		}

		private void method_13(ref List<IDataRowAdapter[]> list_0, SortingInstruction sortingInstruction_0)
		{
			List<IDataRowAdapter[]> list = new List<IDataRowAdapter[]>();
			foreach (IDataRowAdapter[] item in list_0)
			{
				List<IDataRowAdapter[]> collection = this.method_14(item, sortingInstruction_0);
				list.AddRange(collection);
			}
			list_0 = list;
		}

		private List<IDataRowAdapter[]> method_14(IDataRowAdapter[] idataRowAdapter_0, SortingInstruction sortingInstruction_0)
		{
			if (idataRowAdapter_0 != null && idataRowAdapter_0.Length != 0)
			{
				if (idataRowAdapter_0.Length == 1)
				{
					return new List<IDataRowAdapter[]>(new IDataRowAdapter[1][] { idataRowAdapter_0 });
				}
				return (from igrouping_0 in idataRowAdapter_0.Select((IDataRowAdapter idataRowAdapter_0) => new KeyValuePair<IDataRowAdapter, object>(idataRowAdapter_0, sortingInstruction_0.method_0(idataRowAdapter_0))).ToArray().OrderBy((KeyValuePair<IDataRowAdapter, object> keyValuePair_0) => keyValuePair_0.Value, sortingInstruction_0.IComparer_0)
						.ToArray()
						.GroupBy((KeyValuePair<IDataRowAdapter, object> keyValuePair_0) => keyValuePair_0.Value, SortingInstruction.IEqualityComparer_0)
					select igrouping_0.Select((KeyValuePair<IDataRowAdapter, object> keyValuePair_0) => keyValuePair_0.Key).ToArray()).ToList();
			}
			return new List<IDataRowAdapter[]>();
		}

		private void method_15(ChartFrame chartFrame_0, IDataRowAdapter idataRowAdapter_0)
		{
			if (!(Class123.Assembly_0 == null) && idataRowAdapter_0 != null)
			{
				IDataRowAdapter[] childRows = idataRowAdapter_0.GetChildRows(chartFrame_0.Name);
				if (childRows.Length != 0)
				{
					this.method_16(chartFrame_0, childRows);
					ChartMergedEventArgs chartMergedEventArgs_ = new ChartMergedEventArgs(chartFrame_0);
					this.OnChartMerged(chartMergedEventArgs_);
					chartFrame_0.Name = string.Empty;
				}
			}
		}

		private void method_16(ChartFrame chartFrame_0, IDataRowAdapter[] idataRowAdapter_0)
		{
			if (idataRowAdapter_0.Length == 0)
			{
				return;
			}
			Class123 @class = new Class123(chartFrame_0);
			IDataTableAdapter table = idataRowAdapter_0[0].Table;
			if (table == null)
			{
				return;
			}
			foreach (Class109 item in (IEnumerable<Class109>)@class.Class107_0)
			{
				if (!table.ColumnNames.Contains(item.String_0.ToLower()))
				{
					continue;
				}
				foreach (Class126 item2 in (IEnumerable<Class126>)@class.Class124_0)
				{
					if (!(item2.String_1 != item.String_0) && table.ColumnNames.Contains(item2.String_0.ToLower()))
					{
						item2.Class115_0.Clear();
						foreach (IDataRowAdapter obj in idataRowAdapter_0)
						{
							object object_ = obj[item.String_0];
							object object_2 = obj[item2.String_0];
							MailMerge.smethod_0(item2, object_, object_2);
						}
					}
				}
			}
		}

		private static void smethod_0(Class126 class126_0, object object_0, object object_1)
		{
			string text = MailMerge.smethod_1(object_0);
			if (object_1 is string)
			{
				double result = 0.0;
				double.TryParse((string)object_1, out result);
				class126_0.Class115_0.Add(new Class117(result, text));
			}
			else if (object_1 is float)
			{
				class126_0.Class115_0.Add(new Class117((float)object_1, text));
			}
			else if (object_1 is double)
			{
				class126_0.Class115_0.Add(new Class117((double)object_1, text));
			}
			else if (object_1 is decimal)
			{
				class126_0.Class115_0.Add(new Class117((double)(decimal)object_1, text));
			}
			else if (object_1 is int)
			{
				class126_0.Class115_0.Add(new Class117((int)object_1, text));
			}
			else if (object_1 is long)
			{
				class126_0.Class115_0.Add(new Class117((long)object_1, text));
			}
			else
			{
				class126_0.Class115_0.Add(new Class117(0.0, text));
			}
		}

		private static string smethod_1(object object_0)
		{
			string text = "";
			if (object_0 is string)
			{
				DateTime result = DateTime.MaxValue;
				if (DateTime.TryParse((string)object_0, out result))
				{
					text = result.ToString();
				}
				if (text.Length == 0)
				{
					text = object_0.ToString();
				}
			}
			else
			{
				text = object_0.ToString();
			}
			return text;
		}

		protected virtual void OnDataRowMerged(DataRowMergedEventArgs dataRowMergedEventArgs_0)
		{
			if (this.DataRowMerged != null)
			{
				this.DataRowMerged(this, dataRowMergedEventArgs_0);
			}
		}

		protected virtual void OnBlockMerging(BlockMergingEventArgs blockMergingEventArgs_0)
		{
			if (this.BlockMerging != null)
			{
				this.BlockMerging(this, blockMergingEventArgs_0);
			}
		}

		protected virtual void OnBlockMerged(BlockRowMergedEventArgs blockRowMergedEventArgs_0)
		{
			if (this.BlockRowMerged != null)
			{
				this.BlockRowMerged(this, blockRowMergedEventArgs_0);
			}
		}

		protected virtual void OnFieldMerged(FieldMergedEventArgs fieldMergedEventArgs_0)
		{
			if (this.FieldMerged != null)
			{
				this.FieldMerged(this, fieldMergedEventArgs_0);
			}
		}

		protected virtual void OnImageFieldMerged(ImageFieldMergedEventArgs imageFieldMergedEventArgs_0)
		{
			if (this.ImageFieldMerged != null)
			{
				this.ImageFieldMerged(this, imageFieldMergedEventArgs_0);
			}
		}

		protected virtual void OnIncludeTextMerging(IncludeTextMergingEventArgs includeTextMergingEventArgs_0)
		{
			if (this.IncludeTextMerging != null)
			{
				this.IncludeTextMerging(this, includeTextMergingEventArgs_0);
			}
		}

		protected virtual void OnChartMerged(ChartMergedEventArgs chartMergedEventArgs_0)
		{
			if (this.ChartMerged != null)
			{
				this.ChartMerged(this, chartMergedEventArgs_0);
			}
		}

		protected virtual void OnBarcodeMerged(object sender, BarcodeMergedEventArgs e)
		{
			if (this.BarcodeMerged != null)
			{
				this.BarcodeMerged(this, e);
			}
		}

		protected virtual void OnImageMerged(object sender, ImageMergedEventArgs e)
		{
			if (this.ImageMerged != null)
			{
				this.ImageMerged(this, e);
			}
		}

		/// <summary>Interprets all public properties of the objects or the key names of the dictionaries in the collection as possible table columns and / or child tables. The type of the first object (or the key names and types of the first dictionary) in the collection is analyzed via .NET reflection and used as the basis of the assumed table structure. (In case of the collection containing objects of different types, the merge process is successful nevertheless, but some fields will be empty.) Properties of simple data types (e. g. string, int, enum) are converted to text using the ToString method. The textual representation of enum values can be specified using the System.ComponentModel.DescriptionAttribute. (For example: enum FoodCategory { [Description("Grains / Cereals")] Grains_Cereals, ... }.) The name by which Properties are mapped to field names can be adjusted using the System.ComponentModel.DisplayNameAttribute. (For example: [DisplayName("Name")] public string ProductName { get; set; }.) Complex properties which are themselves of type System.Collections.IEnumerable are interpreted as child Tables and used for merging merge blocks and nested merge blocks. This way data relations can be represented. Properties of a type itself having public properties are either interpreted as a simple table column (the merged text then is determined using the ToString() method) or they are treated as if they were a child table containing only one data row with the properties being the table columns. The second parameter specifies whether the single documents should be merged into one document or split into separate documents. The supported format of the merge fields can be found in the ASP.NET User's Guide.</summary>
		/// <param name="mergeData">Specifies a System.Collections.IEnumerable that contains the merge data.</param>
		/// <param name="append">Specifies whether the single documents should be merged into one document or split into separate documents.</param>
		public void MergeObjects(IEnumerable mergeData, bool append)
		{
			this.method_17(new Class131(mergeData), append);
		}

		/// <summary>Does the same as MergeObjects with the parameter “append” set to true.</summary>
		/// <param name="mergeData">Specifies a System.Collections.IEnumerable that contains the merge data.</param>
		public void MergeObjects(IEnumerable mergeData)
		{
			this.MergeObjects(mergeData, append: true);
		}

		/// <summary>Merges a single instance of an arbitrary type into the loaded document template. For more information about .NET reflection based object merging read the documentation of the MergeObjects method.</summary>
		/// <param name="mergeData">Specifies the object to merge into the template.</param>
		public void MergeObject(object mergeData)
		{
			object[] mergeData2 = new object[1] { mergeData };
			this.MergeObjects(mergeData2);
		}

		/// <summary>Merges the loaded template with the data of a specific System.Data.DataTable. The second parameter specifies whether the single documents should be merged into one document or splitted into separate documents.</summary>
		/// <param name="mergeData">Specifies a System.Data.DataTable that contains the merge data.</param>
		/// <param name="append">Specifies whether the single documents should be merged into one document or split into separate documents.</param>
		public void Merge(DataTable mergeData, bool append)
		{
			this.method_17(new Class130(mergeData), append);
		}

		/// <summary>Does the same as Merge(System.Data.DataTable mergeData, bool append) with parameter “append” set to true.</summary>
		/// <param name="mergeData">Specifies a System.Data.DataTable that contains the merge data.</param>
		public void Merge(DataTable mergeData)
		{
			this.Merge(mergeData, append: true);
		}

		/// <summary>Merges data into the template using a data base connection given through a data source configuration file or data source configuration XML data. (See also ReportDataSourceConfigFile property and ReportDataSourceConfig property)</summary>
		/// <param name="append">Specifies whether the single documents should be merged into one document or split into separate documents.</param>
		public void Merge(bool append)
		{
			this.method_43(Enum7.flag_3);
			Class102 class102_;
			if (this.xmlDocument_0 != null)
			{
				class102_ = new Class102(this.xmlDocument_0);
			}
			else
			{
				string text = this.string_2;
				if (!Path.IsPathRooted(text) && !string.IsNullOrEmpty(this.SearchPath))
				{
					text = Path.Combine(this.SearchPath, text);
				}
				class102_ = new Class102(text);
			}
			Class99 @class = new Class99(class102_, this.traceSource_0);
			this.method_17(new Class130(@class.SelectedTable.DataTable_0), append);
		}

		/// <summary>Does the same as method Merge(bool append) with parameter “append” set to true.</summary>
		public void Merge()
		{
			this.Merge(append: true);
		}

		/// <summary>Merges data given as a JSON string into a document template. The JSON string has to contain either a single object or an array of equally structured objects.</summary>
		/// <param name="json">The JSON string containing the merge data.</param>
		/// <param name="append">Specifies whether the merge result should be merged into one document or split into separate documents.</param>
		public void MergeJsonData(string json, bool append)
		{
			object obj = JsonConvert.DeserializeObject(json);
			if (obj is IEnumerable && !(obj is string))
			{
				this.MergeObjects((IEnumerable)obj, append);
			}
			else if (obj is IDictionary)
			{
				this.MergeObject(obj);
			}
		}

		/// <summary>Does the same as MergeJsonData with the parameter “append” set to true.</summary>
		/// <param name="json">The JSON string containing the merge data.</param>
		public void MergeJsonData(string json)
		{
			this.MergeJsonData(json, append: true);
		}

		private void method_17(IDataTableAdapter idataTableAdapter_0, bool bool_9)
		{
			bool bool_10 = false;
			List<byte[]> list = new List<byte[]>();
			byte[] array = null;
			if (this.byte_1 == null)
			{
				this.method_53(this.string_3);
				this.bool_2 = this.byte_1 != null;
			}
			if (this.byte_1 == null)
			{
				this.method_44();
			}
			this.method_43(Enum7.flag_0 | Enum7.flag_1);
			this.method_35();
			this.int_0 = 0;
			int num = ((idataTableAdapter_0 != null) ? idataTableAdapter_0.Rows.Length : 0);
			using (ServerTextControl serverTextControl = this.method_47())
			{
				if (num == 0)
				{
					serverTextControl.Load(this.byte_1, BinaryStreamType.InternalUnicodeFormat, new LoadSettings
					{
						ApplicationFieldFormat = ApplicationFieldFormat.MSWordTXFormFields
					});
					this.byte_0 = this.method_20(serverTextControl, ref bool_10);
					bool_9 = false;
				}
				else
				{
					for (int i = 0; i < num; i++)
					{
						if (bool_10)
						{
							break;
						}
						serverTextControl.Load(this.byte_1, BinaryStreamType.InternalUnicodeFormat, new LoadSettings
						{
							ApplicationFieldFormat = ApplicationFieldFormat.MSWordTXFormFields
						});
						List<Class86> mergeBlocks = serverTextControl.GetMergeBlocks(this.traceSource_0, justGetPositions: false, this.TextComponent);
						array = this.method_18(serverTextControl, idataTableAdapter_0.Rows, null, mergeBlocks, ref i, ref bool_10);
						if (bool_9)
						{
							list.Add(array);
						}
					}
				}
			}
			if (bool_9)
			{
				this.byte_0 = this.method_4(list, AppendSettings.StartWithNewSection, bool_9: false);
			}
			else if (array != null)
			{
				this.byte_0 = array;
			}
			if (this.bool_1 || this.bool_2)
			{
				this.method_45();
			}
			if (bool_10)
			{
				throw new MergeCanceledException();
			}
		}

		private byte[] method_18(ServerTextControl serverTextControl_0, IDataRowAdapter[] idataRowAdapter_0, Class86 class86_0, List<Class86> list_0, ref int int_4, ref bool bool_9)
		{
			bool flag = class86_0 != null;
			serverTextControl_0.IsFormulaCalculationEnabled = false;
			this.method_32(serverTextControl_0, ref list_0, flag);
			int num = ((idataRowAdapter_0 != null) ? idataRowAdapter_0.Length : 0);
			IDataRowAdapter dataRowAdapter = ((int_4 < num) ? idataRowAdapter_0[int_4] : null);
			this.method_2(serverTextControl_0, list_0, dataRowAdapter);
			foreach (IFormattedText textPart in serverTextControl_0.TextParts)
			{
				if (!flag || !(textPart is HeaderFooter))
				{
					this.method_21(textPart, idataRowAdapter_0, class86_0, ref int_4);
				}
			}
			serverTextControl_0.IsFormulaCalculationEnabled = true;
			serverTextControl_0.Save(out var binaryData, BinaryStreamType.InternalUnicodeFormat);
			if (!flag && idataRowAdapter_0 != null)
			{
				DataRowMergedEventArgs dataRowMergedEventArgs = new DataRowMergedEventArgs(int_4, binaryData, dataRowAdapter);
				this.OnDataRowMerged(dataRowMergedEventArgs);
				if (dataRowMergedEventArgs.Replaced && dataRowMergedEventArgs.MergedRow != null)
				{
					binaryData = dataRowMergedEventArgs.MergedRow;
				}
				bool_9 = dataRowMergedEventArgs.Cancel;
			}
			return binaryData;
		}

		private byte[] method_19(ServerTextControl serverTextControl_0, IDataRowAdapter[] idataRowAdapter_0, Class86 class86_0, List<Class86> list_0, ref int int_4)
		{
			bool bool_ = false;
			return this.method_18(serverTextControl_0, idataRowAdapter_0, class86_0, list_0, ref int_4, ref bool_);
		}

		private byte[] method_20(ServerTextControl serverTextControl_0, ref bool bool_9)
		{
			int int_ = 0;
			return this.method_18(serverTextControl_0, null, null, null, ref int_, ref bool_9);
		}

		private void method_21(IFormattedText iformattedText_0, IDataRowAdapter[] idataRowAdapter_0, Class86 class86_0, ref int int_4)
		{
			int num = -1;
			IDataRowAdapter idataRowAdapter_ = null;
			if (iformattedText_0.ApplicationFields == null)
			{
				return;
			}
			List<Class78> list = new List<Class78>();
			int num2 = ((idataRowAdapter_0 != null) ? idataRowAdapter_0.Length : 0);
			if (iformattedText_0 is HeaderFooter)
			{
				foreach (TextFrame textFrame in ((HeaderFooter)iformattedText_0).TextFrames)
				{
					this.method_21(textFrame, idataRowAdapter_0, class86_0, ref int_4);
				}
			}
			Mergeable[] array = this.method_34(iformattedText_0);
			foreach (Mergeable mergeable in array)
			{
				Class82 @class = mergeable as Class82;
				if (@class != null)
				{
					if (this.method_22(iformattedText_0, @class.ApplicationField_0, idataRowAdapter_0, class86_0, ref int_4, mergeable.TableCell, list))
					{
						list.Add(new Class78(@class.ApplicationField_0, bool_1: true));
					}
					continue;
				}
				if (int_4 > num)
				{
					idataRowAdapter_ = ((int_4 < num2) ? idataRowAdapter_0[int_4] : null);
					num = int_4;
				}
				if (mergeable is Class85)
				{
					Class85 class2 = mergeable as Class85;
					this.method_0(class2.Frame, idataRowAdapter_);
				}
				else if (mergeable is Class83)
				{
					Class83 class3 = mergeable as Class83;
					this.method_37(class3.Frame, iformattedText_0, idataRowAdapter_, class86_0);
				}
				else if (mergeable is Class84)
				{
					Class84 class4 = mergeable as Class84;
					this.method_15(class4.Frame, idataRowAdapter_);
				}
			}
			iformattedText_0.RemoveAppFields(list, this.RemoveEmptyLines);
		}

		internal bool method_22(IFormattedText iformattedText_0, ApplicationField applicationField_0, IDataRowAdapter[] idataRowAdapter_0, Class86 class86_0, ref int int_4, TableCell tableCell_0, List<Class78> list_0)
		{
			int int_5 = -1;
			bool bool_ = false;
			string string_ = null;
			string string_2 = null;
			MailMergeFieldAdapter mailMergeFieldAdapter = null;
			Image image_ = null;
			byte[] binaryData = null;
			int num = ((idataRowAdapter_0 != null) ? idataRowAdapter_0.Length : 0);
			IDataRowAdapter dataRowAdapter = ((int_4 < num) ? idataRowAdapter_0[int_4] : null);
			try
			{
				switch (applicationField_0.TypeName)
				{
				default:
					return false;
				case "NEXTIF":
					this.method_25(iformattedText_0, applicationField_0, dataRowAdapter, ref int_4, ref bool_);
					break;
				case "NEXT":
					this.method_24(iformattedText_0, applicationField_0, ref int_4);
					break;
				case "DATE":
					mailMergeFieldAdapter = new DateField(applicationField_0);
					((DateField)mailMergeFieldAdapter).Date = DateTime.Now;
					bool_ = true;
					break;
				case "IF":
					mailMergeFieldAdapter = this.method_23(iformattedText_0, applicationField_0, dataRowAdapter, ref bool_, list_0);
					break;
				case "MERGEFIELD":
					mailMergeFieldAdapter = this.method_26(iformattedText_0, applicationField_0, dataRowAdapter, ref int_5, ref bool_, ref string_, ref string_2, ref image_, list_0);
					break;
				}
				if (bool_ && string_ == null && mailMergeFieldAdapter != null)
				{
					iformattedText_0.Selection.Length = 0;
					iformattedText_0.Selection.Start = mailMergeFieldAdapter.Start - 1;
					iformattedText_0.Selection.Length = mailMergeFieldAdapter.Length;
					iformattedText_0.Selection.Save(out binaryData, BinaryStreamType.InternalUnicodeFormat);
				}
			}
			catch (Exception ex)
			{
				if (ex is TextEditorException)
				{
					string message = $"{ex.GetType().Name} in internal method MailMerge.MergeAppField while merging a {applicationField_0.TypeName} field (field name: \"{applicationField_0.Name}\"): {ex.Message}";
					if (this.traceSource_0 != null)
					{
						this.traceSource_0.TraceEvent(TraceEventType.Error, 2, message);
					}
				}
				if (this.RemoveEmptyFields && mailMergeFieldAdapter != null)
				{
					list_0.Add(new Class78(mailMergeFieldAdapter.ApplicationField));
				}
				return bool_;
			}
			if (string_ != null)
			{
				ImageFieldMergedEventArgs imageFieldMergedEventArgs = new ImageFieldMergedEventArgs(string_, string_2, image_, bool_, tableCell_0, class86_0);
				this.OnImageFieldMerged(imageFieldMergedEventArgs);
				if (imageFieldMergedEventArgs.Replaced && imageFieldMergedEventArgs.Image != null)
				{
					if (image_ != null)
					{
						iformattedText_0.Images.Remove(image_);
					}
					iformattedText_0.Images.Add(imageFieldMergedEventArgs.Image, int_5);
				}
			}
			else if (mailMergeFieldAdapter != null)
			{
				FieldMergedEventArgs fieldMergedEventArgs = new FieldMergedEventArgs(mailMergeFieldAdapter, binaryData, bool_, dataRowAdapter, tableCell_0, class86_0);
				this.OnFieldMerged(fieldMergedEventArgs);
				if (fieldMergedEventArgs.Replaced && fieldMergedEventArgs.MergedField != null)
				{
					int start = mailMergeFieldAdapter.Start - 1;
					if (iformattedText_0.ApplicationFields.Remove(mailMergeFieldAdapter.ApplicationField))
					{
						iformattedText_0.Selection.Length = 0;
						iformattedText_0.Selection.Start = start;
						iformattedText_0.Selection.Load(fieldMergedEventArgs.MergedField, BinaryStreamType.InternalUnicodeFormat);
					}
				}
				else if (fieldMergedEventArgs.MailMergeFieldAdapter != null && fieldMergedEventArgs.Boolean_0)
				{
					switch (mailMergeFieldAdapter.TypeName)
					{
					case "DATE":
						new DateField((DateField)fieldMergedEventArgs.MailMergeFieldAdapter);
						break;
					case "IF":
						new IfField((IfField)fieldMergedEventArgs.MailMergeFieldAdapter);
						break;
					case "MERGEFIELD":
						new MergeField((MergeField)fieldMergedEventArgs.MailMergeFieldAdapter);
						break;
					}
				}
			}
			return bool_;
		}

		private MailMergeFieldAdapter method_23(IFormattedText iformattedText_0, ApplicationField applicationField_0, IDataRowAdapter idataRowAdapter_0, ref bool bool_9, List<Class78> list_0)
		{
			IfField ifField = new IfField(applicationField_0);
			if (idataRowAdapter_0 != null)
			{
				if (idataRowAdapter_0.Table.ColumnNames.Contains(ifField.Expression1.ToLower()))
				{
					ifField.FieldValue = idataRowAdapter_0[ifField.Expression1].ToString();
					bool_9 = true;
				}
				else if (ifField.Expression1.IsChildColumnName())
				{
					bool_9 = this.method_27(idataRowAdapter_0, ifField);
				}
			}
			if (!bool_9 && this.RemoveEmptyFields)
			{
				list_0.Add(new Class78(ifField.ApplicationField));
			}
			return ifField;
		}

		private void method_24(IFormattedText iformattedText_0, ApplicationField applicationField_0, ref int int_4)
		{
			int_4++;
			iformattedText_0.ApplicationFields.Remove(applicationField_0);
		}

		private void method_25(IFormattedText iformattedText_0, ApplicationField applicationField_0, IDataRowAdapter idataRowAdapter_0, ref int int_4, ref bool bool_9)
		{
			NextIfField nextIfField = new NextIfField(applicationField_0);
			if (idataRowAdapter_0 != null)
			{
				if (idataRowAdapter_0.Table.ColumnNames.Contains(nextIfField.Expression1.ToLower()))
				{
					nextIfField.FieldValue = idataRowAdapter_0[nextIfField.Expression1].ToString();
					if (nextIfField.Result)
					{
						int_4++;
					}
				}
				else if (nextIfField.Expression1.IsChildColumnName())
				{
					this.method_28(idataRowAdapter_0, nextIfField);
					if (nextIfField.Result)
					{
						int_4++;
					}
				}
			}
			iformattedText_0.ApplicationFields.Remove(applicationField_0);
		}

		private MailMergeFieldAdapter method_26(IFormattedText iformattedText_0, ApplicationField applicationField_0, IDataRowAdapter idataRowAdapter_0, ref int int_4, ref bool bool_9, ref string string_7, ref string string_8, ref Image image_0, List<Class78> list_0)
		{
			string string_9 = null;
			MergeField mergeField = new MergeField(applicationField_0);
			MailMerge.smethod_14(idataRowAdapter_0, out string_7, out string_9, mergeField);
			if (string_7 != null)
			{
				bool_9 = this.method_31(iformattedText_0, idataRowAdapter_0, out int_4, out string_8, out image_0, string_9, mergeField);
			}
			else if (idataRowAdapter_0 != null)
			{
				if (idataRowAdapter_0.Table.ColumnNames.Contains(mergeField.Name.ToLower()) && idataRowAdapter_0[mergeField.Name].ToString() != "")
				{
					mergeField.Text = idataRowAdapter_0[mergeField.Name].ToString();
					bool_9 = true;
				}
				else if (mergeField.Boolean_0)
				{
					bool_9 = this.method_29(idataRowAdapter_0, mergeField);
				}
			}
			if (!bool_9 && this.RemoveEmptyFields)
			{
				list_0.Add(new Class78(mergeField.ApplicationField));
			}
			return mergeField;
		}

		private bool method_27(IDataRowAdapter idataRowAdapter_0, IfField ifField_0)
		{
			string[] string_ = ifField_0.Expression1.ToChildTableNames();
			string string_2 = ifField_0.Expression1.ToChildColumnName();
			string string_3;
			bool num = this.method_30(idataRowAdapter_0, string_, string_2, out string_3);
			if (num)
			{
				ifField_0.FieldValue = string_3;
			}
			return num;
		}

		private bool method_28(IDataRowAdapter idataRowAdapter_0, NextIfField nextIfField_0)
		{
			string[] string_ = nextIfField_0.Expression1.ToChildTableNames();
			string string_2 = nextIfField_0.Expression1.ToChildColumnName();
			string string_3;
			bool num = this.method_30(idataRowAdapter_0, string_, string_2, out string_3);
			if (num)
			{
				nextIfField_0.FieldValue = string_3;
			}
			return num;
		}

		private bool method_29(IDataRowAdapter idataRowAdapter_0, MergeField mergeField_0)
		{
			string string_;
			bool num = this.method_30(idataRowAdapter_0, mergeField_0.String_0, mergeField_0.String_1, out string_);
			if (num)
			{
				mergeField_0.Text = string_;
			}
			return num;
		}

		private bool method_30(IDataRowAdapter idataRowAdapter_0, string[] string_7, string string_8, out string string_9)
		{
			string_9 = null;
			object nestedChildColumnContent = idataRowAdapter_0.GetNestedChildColumnContent(string_7, string_8);
			if (nestedChildColumnContent == null)
			{
				return false;
			}
			string_9 = nestedChildColumnContent.ToString();
			return true;
		}

		private bool method_31(IFormattedText iformattedText_0, IDataRowAdapter idataRowAdapter_0, out int int_4, out string string_7, out Image image_0, string string_8, MergeField mergeField_0)
		{
			image_0 = null;
			int_4 = mergeField_0.Start - 1;
			System.Drawing.Image image = this.method_38(idataRowAdapter_0, string_8);
			if (image != null)
			{
				string_7 = "";
				iformattedText_0.ApplicationFields.Remove(mergeField_0.ApplicationField);
				image_0 = new Image(image);
				image_0.SaveMode = ImageSaveMode.SaveAsData;
				iformattedText_0.Images.Add(image_0, int_4);
				return true;
			}
			string text = (string_7 = (idataRowAdapter_0[string_8] as string) ?? "");
			if (text == "")
			{
				return false;
			}
			if (!Path.IsPathRooted(text))
			{
				text = Path.Combine(this.SearchPath, text);
			}
			if (File.Exists(text))
			{
				iformattedText_0.ApplicationFields.Remove(mergeField_0.ApplicationField);
				image_0 = new Image();
				image_0.FileName = text;
				image_0.SaveMode = ImageSaveMode.SaveAsData;
				iformattedText_0.Images.Add(image_0, int_4);
				return true;
			}
			return false;
		}

		internal void method_32(ServerTextControl serverTextControl_0, ref List<Class86> list_0, bool bool_9)
		{
			List<IFormattedText> list = new List<IFormattedText>();
			foreach (IFormattedText textPart in serverTextControl_0.TextParts)
			{
				if (!bool_9 || !(textPart is HeaderFooter))
				{
					list.Add(textPart);
				}
			}
			foreach (IFormattedText item in list)
			{
				List<Class78> list2 = new List<Class78>();
				if (item.ApplicationFields == null || item.ApplicationFields.Count == 0)
				{
					continue;
				}
				List<ApplicationField> list3 = new List<ApplicationField>();
				foreach (ApplicationField applicationField in item.ApplicationFields)
				{
					if ((!(item is MainText) || !list_0.Contain(applicationField)) && string.Compare(applicationField.TypeName, "INCLUDETEXT") == 0)
					{
						list3.Add(applicationField);
					}
				}
				foreach (ApplicationField item2 in list3)
				{
					this.method_33(item, new IncludeText(item2), list2);
				}
				item.RemoveAppFields(list2, this.RemoveEmptyLines);
				if (item is MainText && list3.Count > 0)
				{
					list_0 = serverTextControl_0.GetMergeBlocks(this.traceSource_0, bool_9, this.TextComponent);
				}
			}
		}

		internal void method_33(IFormattedText iformattedText_0, IncludeText includeText_0, List<Class78> list_0)
		{
			int start = includeText_0.Start - 1;
			LoadSettings loadSettings = new LoadSettings
			{
				ApplicationFieldFormat = ApplicationFieldFormat.MSWordTXFormFields,
				LoadSubTextParts = true,
				ReportingMergeBlockFormat = ReportingMergeBlockFormat.SubTextParts
			};
			string text = Path.Combine((this.SearchPath == null) ? "" : this.SearchPath, includeText_0.Filename).ToLower();
			IncludeTextMergingEventArgs includeTextMergingEventArgs = new IncludeTextMergingEventArgs(text, includeText_0);
			this.OnIncludeTextMerging(includeTextMergingEventArgs);
			if (includeTextMergingEventArgs.IncludeTextDocument == null && !File.Exists(text))
			{
				if (this.RemoveEmptyFields)
				{
					list_0.Add(new Class78(includeText_0.ApplicationField));
				}
				return;
			}
			iformattedText_0.ApplicationFields.Remove(includeText_0.ApplicationField);
			StreamType streamType = StreamType.InternalUnicodeFormat;
			byte[] binaryData;
			using (ServerTextControl serverTextControl = this.method_47())
			{
				serverTextControl.IsFormulaCalculationEnabled = false;
				if (includeTextMergingEventArgs.IncludeTextDocument == null)
				{
					switch (Path.GetExtension(text))
					{
					case ".xlsx":
						streamType = StreamType.SpreadsheetML;
						break;
					case ".rtf":
						streamType = StreamType.RichTextFormat;
						break;
					case ".doc":
						streamType = StreamType.MSWord;
						break;
					case ".docx":
						streamType = StreamType.WordprocessingML;
						break;
					}
					try
					{
						serverTextControl.Load(text, streamType, loadSettings);
					}
					catch (MergeBlockConversionException)
					{
					}
					List<Class86> list_ = serverTextControl.GetMergeBlocks(this.traceSource_0, justGetPositions: true, this.TextComponent);
					this.method_32(serverTextControl, ref list_, bool_9: true);
				}
				else
				{
					if (includeTextMergingEventArgs.IncludeTextDocument.Length == 0)
					{
						return;
					}
					try
					{
						serverTextControl.Load(includeTextMergingEventArgs.IncludeTextDocument, BinaryStreamType.InternalUnicodeFormat, loadSettings);
					}
					catch (MergeBlockConversionException)
					{
					}
					List<Class86> list_2 = serverTextControl.GetMergeBlocks(this.traceSource_0, justGetPositions: true, this.TextComponent);
					this.method_32(serverTextControl, ref list_2, bool_9: true);
				}
				switch (includeText_0.TextFormat)
				{
				case TextFormatOptions.Uppercase:
					serverTextControl.Text = serverTextControl.Text.ToUpper();
					break;
				case TextFormatOptions.Lowercase:
					serverTextControl.Text = serverTextControl.Text.ToLower();
					break;
				case TextFormatOptions.FirstCapital:
					serverTextControl.Text = serverTextControl.Text.Substring(0, 1).ToUpper() + serverTextControl.Text.Substring(1, Math.Max(0, serverTextControl.Text.Length - 1));
					break;
				case TextFormatOptions.TitleCase:
				{
					TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
					serverTextControl.Text = textInfo.ToTitleCase(serverTextControl.Text);
					break;
				}
				}
				serverTextControl.Save(out binaryData, BinaryStreamType.InternalUnicodeFormat);
			}
			iformattedText_0.Selection = new Selection(start, 0);
			iformattedText_0.Selection.Load(binaryData, BinaryStreamType.InternalUnicodeFormat, new LoadSettings
			{
				ApplicationFieldFormat = ApplicationFieldFormat.MSWordTXFormFields
			});
		}

		private static void smethod_2(ServerTextControl serverTextControl_0, out byte[] byte_2)
		{
			int pages = serverTextControl_0.Pages;
			foreach (Section section in serverTextControl_0.Sections)
			{
				foreach (HeaderFooter headersAndFooter in section.HeadersAndFooters)
				{
					foreach (TextFrame textFrame in headersAndFooter.TextFrames)
					{
						MailMerge.smethod_3(textFrame.ApplicationFields, pages);
					}
					MailMerge.smethod_3(headersAndFooter.ApplicationFields, pages);
				}
			}
			foreach (TextFrame textFrame2 in serverTextControl_0.TextFrames)
			{
				MailMerge.smethod_3(textFrame2.ApplicationFields, pages);
			}
			MailMerge.smethod_3(serverTextControl_0.ApplicationFields, pages);
			serverTextControl_0.Save(out byte_2, BinaryStreamType.InternalUnicodeFormat);
		}

		private static void smethod_3(ApplicationFieldCollection applicationFieldCollection_0, int int_4)
		{
			foreach (ApplicationField item in applicationFieldCollection_0)
			{
				try
				{
					if (string.Compare(item.TypeName, "NUMPAGES") == 0)
					{
						item.Text = int_4.ToString();
					}
				}
				catch
				{
				}
			}
		}

		private Mergeable[] method_34(IFormattedText iformattedText_0)
		{
			List<Mergeable> list = new List<Mergeable>();
			foreach (ApplicationField applicationField in iformattedText_0.ApplicationFields)
			{
				if (this.method_55(applicationField))
				{
					TableCell tableCell_ = null;
					iformattedText_0.Selection.Length = 0;
					iformattedText_0.Selection.Start = applicationField.Start;
					Table item = iformattedText_0.Tables.GetItem();
					if (item != null)
					{
						tableCell_ = item.Cells.GetItem();
					}
					list.Add(new Class82(applicationField, tableCell_));
				}
			}
			foreach (FrameBase frame in iformattedText_0.Frames)
			{
				BarcodeFrame barcodeFrame = frame as BarcodeFrame;
				if (barcodeFrame != null)
				{
					if (!string.IsNullOrEmpty(barcodeFrame.Name))
					{
						list.Add(new Class85(barcodeFrame));
					}
					continue;
				}
				ChartFrame chartFrame = frame as ChartFrame;
				if (chartFrame != null)
				{
					if (!string.IsNullOrEmpty(chartFrame.Name))
					{
						list.Add(new Class84(chartFrame));
					}
					continue;
				}
				Image image = frame as Image;
				if (image != null && !string.IsNullOrEmpty(image.Name))
				{
					list.Add(new Class83(image));
				}
			}
			return list.OrderBy((Mergeable mergeable_0) => mergeable_0.TextPosition).ToArray();
		}

		private void method_35()
		{
			this.method_43(Enum7.flag_1);
			using ServerTextControl serverTextControl = this.method_46(this.byte_1);
			serverTextControl.IsFormulaCalculationEnabled = false;
			if (this.method_36(serverTextControl))
			{
				serverTextControl.Save(out this.byte_1, BinaryStreamType.InternalUnicodeFormat);
			}
		}

		private bool method_36(ServerTextControl serverTextControl_0)
		{
			bool result = false;
			foreach (IFormattedText textPart in serverTextControl_0.TextParts)
			{
				foreach (ApplicationField applicationField in textPart.ApplicationFields)
				{
					if (applicationField.Text.Length == 0 && applicationField.TypeName == "IF")
					{
						applicationField.Text = "{IF}";
						result = true;
					}
				}
			}
			return result;
		}

		private void method_37(Image image_0, IFormattedText iformattedText_0, IDataRowAdapter idataRowAdapter_0, Class86 class86_0)
		{
			if (idataRowAdapter_0 != null)
			{
				string name = image_0.Name;
				System.Drawing.Image image_ = this.method_38(idataRowAdapter_0, name);
				if (!this.method_39(image_0, image_, iformattedText_0, idataRowAdapter_0, class86_0) && this.RemoveEmptyImages)
				{
					iformattedText_0.Images.Remove(image_0);
				}
			}
		}

		private System.Drawing.Image method_38(IDataRowAdapter idataRowAdapter_0, string string_7)
		{
			System.Drawing.Image result = null;
			if (idataRowAdapter_0.Table.ColumnNames.Contains(string_7.ToLower()))
			{
				result = this.method_41(idataRowAdapter_0[string_7]);
			}
			else if (string_7.IsChildColumnName())
			{
				string[] childTableNames = string_7.ToChildTableNames();
				string childColumnName = string_7.ToChildColumnName();
				object nestedChildColumnContent = idataRowAdapter_0.GetNestedChildColumnContent(childTableNames, childColumnName);
				result = this.method_41(nestedChildColumnContent);
			}
			return result;
		}

		private bool method_39(Image image_0, System.Drawing.Image image_1, IFormattedText iformattedText_0, IDataRowAdapter idataRowAdapter_0, Class86 class86_0)
		{
			Image image = null;
			ImageInsertionMode imageInsertionMode = image_0.InsertionMode & (ImageInsertionMode)786447;
			switch (imageInsertionMode)
			{
			case ImageInsertionMode.AsCharacter:
			{
				int textPosition = image_0.TextPosition;
				_ = image_0.Size.Width;
				if (this.method_40(image_0, ref image_1, idataRowAdapter_0, class86_0))
				{
					try
					{
						image = new Image(image_1)
						{
							TextDistances = image_0.TextDistances
						};
					}
					catch
					{
						break;
					}
					iformattedText_0.Images.Remove(image_0);
					iformattedText_0.Images.Add(image, textPosition - 1);
					MailMerge.smethod_4(image_0, image);
					return true;
				}
				break;
			}
			case ImageInsertionMode.DisplaceCompleteLines:
			case ImageInsertionMode.DisplaceText:
			case ImageInsertionMode.BelowTheText:
			case ImageInsertionMode.AboveTheText:
			{
				Point location = image_0.Location;
				int textPosition = image_0.TextPosition;
				_ = image_0.Size.Width;
				if (this.method_40(image_0, ref image_1, idataRowAdapter_0, class86_0))
				{
					try
					{
						image = new Image(image_1)
						{
							TextDistances = image_0.TextDistances
						};
					}
					catch
					{
						break;
					}
					iformattedText_0.Images.Remove(image_0);
					iformattedText_0.Images.Add(image, location, textPosition, imageInsertionMode);
					MailMerge.smethod_4(image_0, image);
					return true;
				}
				break;
			}
			}
			return false;
		}

		private bool method_40(Image image_0, ref System.Drawing.Image image_1, IDataRowAdapter idataRowAdapter_0, Class86 class86_0)
		{
			ImageMergedEventArgs imageMergedEventArgs = new ImageMergedEventArgs(image_1, image_0.Name, image_0.Int32_0, idataRowAdapter_0, class86_0);
			this.OnImageMerged(this, imageMergedEventArgs);
			if (imageMergedEventArgs.bool_0)
			{
				image_1 = imageMergedEventArgs.Image;
			}
			if (image_1 == null)
			{
				return false;
			}
			return true;
		}

		private static void smethod_4(Image image_0, Image image_1)
		{
			int num3 = (image_1.VerticalScaling = (image_1.HorizontalScaling = (int)Math.Round((double)image_0.Size.Width * (double)image_0.HorizontalScaling / 100.0 / (double)image_1.Size.Width * 100.0)));
		}

		private System.Drawing.Image method_41(object object_0)
		{
			if (object_0 == null)
			{
				return null;
			}
			System.Drawing.Image image = object_0 as System.Drawing.Image;
			if (image != null)
			{
				return image;
			}
			byte[] array = object_0 as byte[];
			if (array != null)
			{
				return MailMerge.smethod_7(array);
			}
			string text = object_0 as string;
			if (text != null)
			{
				return this.method_42(text);
			}
			return null;
		}

		internal System.Drawing.Image method_42(string string_7)
		{
			string empty = string.Empty;
			if (string_7.StartsWith("X'", StringComparison.OrdinalIgnoreCase))
			{
				return MailMerge.smethod_5(string_7);
			}
			try
			{
				return MailMerge.smethod_7(Convert.FromBase64String(string_7));
			}
			catch (FormatException)
			{
			}
			empty = string_7;
			if (!Path.IsPathRooted(empty))
			{
				empty = Path.Combine(this.SearchPath, empty);
			}
			if (File.Exists(empty))
			{
				try
				{
					return System.Drawing.Image.FromFile(empty);
				}
				catch
				{
				}
			}
			return null;
		}

		internal static System.Drawing.Image smethod_5(string string_7)
		{
			byte[] array = MailMerge.smethod_6(string_7, 2);
			if (array.Length == 0)
			{
				return null;
			}
			return MailMerge.smethod_7(array);
		}

		internal static byte[] smethod_6(string string_7, int int_4)
		{
			int num = string_7.Length;
			if (string_7.EndsWith("'"))
			{
				num--;
			}
			if (int_4 >= num)
			{
				return new byte[0];
			}
			int num2 = (num - int_4) / 2;
			byte[] array = new byte[num2];
			StringReader stringReader = new StringReader(string_7);
			while (int_4-- > 0)
			{
				stringReader.Read();
			}
			try
			{
				for (int i = 0; i < num2; i++)
				{
					string value = new string(new char[2]
					{
						(char)stringReader.Read(),
						(char)stringReader.Read()
					});
					array[i] = Convert.ToByte(value, 16);
				}
				return array;
			}
			catch
			{
				return new byte[0];
			}
		}

		internal static System.Drawing.Image smethod_7(byte[] byte_2)
		{
			try
			{
				return System.Drawing.Image.FromStream(new MemoryStream(byte_2));
			}
			catch
			{
				byte[] buffer = MailMerge.smethod_8(byte_2);
				try
				{
					return System.Drawing.Image.FromStream(new MemoryStream(buffer));
				}
				catch
				{
				}
			}
			return null;
		}

		private static byte[] smethod_8(byte[] byte_2)
		{
			string empty = string.Empty;
			if (byte_2.Length >= 200)
			{
				try
				{
					empty = Encoding.ASCII.GetString(byte_2, 0, 200);
				}
				catch
				{
					return new byte[0];
				}
				int num = -1;
				string[] array = MailMerge.string_0;
				foreach (string value in array)
				{
					num = empty.IndexOf(value);
					if (num != -1)
					{
						break;
					}
				}
				if (num == -1)
				{
					return new byte[0];
				}
				byte[] array2 = new byte[byte_2.Length - num];
				Array.Copy(byte_2, num, array2, 0, array2.Length);
				return array2;
			}
			return new byte[0];
		}

		/// <summary>Initializes a new instance of the MailMerge class.</summary>
		public MailMerge()
			: this(null)
		{
		}

		public MailMerge(IContainer container)
		{
			this.traceSource_0.TraceEvent(TraceEventType.Verbose, 1, "Component initializing");
			this.bool_0 = false;
			TypeDescriptor.AddProvider(new Class80(TypeDescriptor.GetProvider(typeof(MailMerge))), typeof(MailMerge));
			this.method_56();
			this.RemoveEmptyFields = true;
			this.RemoveTrailingWhitespace = true;
			this.UseTemplateFormat = true;
			this.RemoveEmptyLines = false;
			this.RemoveEmptyBlocks = true;
			this.RemoveEmptyImages = false;
			container?.Add(this);
			this.traceSource_0.TraceInformation("Component initialized");
		}

		~MailMerge()
		{
			this.Dispose(disposing: false);
		}

		protected override void Dispose(bool disposing)
		{
			if (!this.bool_0 && disposing)
			{
				lock (this)
				{
					this.byte_0 = null;
					this.byte_1 = null;
					this.nullable_0 = null;
					this.traceSource_0 = null;
					base.Dispose(disposing);
					this.bool_0 = true;
				}
			}
		}

		public bool LoadTemplate(string filename, FileFormat documentFormat)
		{
			this.method_43(Enum7.flag_0);
			this.method_50();
			StreamType streamType = this.method_51(documentFormat);
			using (ServerTextControl serverTextControl = this.method_47())
			{
				try
				{
					serverTextControl.Load(filename, streamType, new LoadSettings
					{
						ApplicationFieldFormat = ApplicationFieldFormat.MSWordTXFormFields,
						LoadSubTextParts = true,
						ReportingMergeBlockFormat = ReportingMergeBlockFormat.SubTextParts
					});
					if (!this.UseTemplateFormat && this.nullable_0.HasValue)
					{
						MailMerge.smethod_9(serverTextControl, this.nullable_0.Value);
					}
					serverTextControl.Save(out this.byte_1, BinaryStreamType.InternalUnicodeFormat);
					this.byte_0 = new byte[this.byte_1.Length];
					Buffer.BlockCopy(this.byte_1, 0, this.byte_0, 0, this.byte_1.Length);
				}
				catch (MergeBlockConversionException ex)
				{
					this.traceSource_0.TraceEvent(TraceEventType.Warning, 2, ex.ToString());
				}
				catch (Exception ex2)
				{
					this.traceSource_0.TraceEvent(TraceEventType.Warning, 2, ex2.ToString());
					throw;
				}
			}
			if (this.byte_1 != null)
			{
				this.bool_2 = false;
				this.bool_1 = false;
			}
			if (this.byte_1 != null)
			{
				return this.byte_0 != null;
			}
			return false;
		}

		public bool LoadTemplateFromMemory(object template, FileFormat documentFormat)
		{
			this.method_43(Enum7.flag_0);
			this.method_50();
			object obj = null;
			switch (documentFormat)
			{
			case FileFormat.MSWord:
				obj = BinaryStreamType.MSWord;
				break;
			case FileFormat.RichTextFormat:
				obj = StringStreamType.RichTextFormat;
				break;
			case FileFormat.WordprocessingML:
				obj = BinaryStreamType.WordprocessingML;
				break;
			case FileFormat.InternalUnicodeFormat:
				obj = BinaryStreamType.InternalUnicodeFormat;
				break;
			}
			using (ServerTextControl serverTextControl = this.method_47())
			{
				LoadSettings loadSettings = new LoadSettings
				{
					ApplicationFieldFormat = ApplicationFieldFormat.MSWordTXFormFields,
					LoadSubTextParts = true,
					ReportingMergeBlockFormat = ReportingMergeBlockFormat.SubTextParts
				};
				try
				{
					if (obj is StringStreamType)
					{
						serverTextControl.Load((string)template, (StringStreamType)obj, loadSettings);
					}
					else
					{
						serverTextControl.Load((byte[])template, (BinaryStreamType)obj, loadSettings);
					}
				}
				catch (MergeBlockConversionException ex)
				{
					this.traceSource_0.TraceEvent(TraceEventType.Warning, 2, ex.ToString());
				}
				catch (Exception ex2)
				{
					this.traceSource_0.TraceEvent(TraceEventType.Warning, 2, ex2.ToString());
					throw;
				}
				try
				{
					if (!this.UseTemplateFormat && this.nullable_0.HasValue)
					{
						MailMerge.smethod_9(serverTextControl, this.nullable_0.Value);
					}
					serverTextControl.Save(out this.byte_1, BinaryStreamType.InternalUnicodeFormat);
					this.byte_0 = new byte[this.byte_1.Length];
					Buffer.BlockCopy(this.byte_1, 0, this.byte_0, 0, this.byte_1.Length);
				}
				catch (Exception ex3)
				{
					this.traceSource_0.TraceEvent(TraceEventType.Warning, 2, ex3.ToString());
					throw;
				}
			}
			if (this.byte_1 != null)
			{
				this.bool_2 = false;
				this.bool_1 = false;
			}
			if (this.byte_1 != null)
			{
				return this.byte_0 != null;
			}
			return false;
		}

		/// <summary>Saves the merged document to a file.</summary>
		/// <param name="filename">Specifies a file into which the data is saved.</param>
		/// <param name="fileFormat">Specifies one of the StreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void SaveDocument(string fileName, StreamType fileFormat, SaveSettings saveSettings)
		{
			this.method_43(Enum7.flag_0 | Enum7.flag_2);
			using ServerTextControl serverTextControl = this.method_46(this.byte_0);
			if (this.RemoveTrailingWhitespace)
			{
				this.method_48(serverTextControl);
			}
			MailMerge.smethod_2(serverTextControl, out this.byte_0);
			try
			{
				if (saveSettings != null)
				{
					serverTextControl.Save(fileName, fileFormat, saveSettings);
				}
				else
				{
					serverTextControl.Save(fileName, fileFormat);
				}
			}
			catch (Exception ex)
			{
				this.traceSource_0.TraceEvent(TraceEventType.Warning, 2, ex.ToString());
				throw;
			}
		}

		/// <summary>Saves the merged document to a byte array.</summary>
		/// <param name="data">Specifies a byte array or a string into which the data is saved.</param>
		/// <param name="fileFormat">Specifies one of the BinaryStreamType or the StringStreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void SaveDocumentToMemory(out byte[] data, BinaryStreamType fileFormat, SaveSettings saveSettings)
		{
			this.method_43(Enum7.flag_0 | Enum7.flag_2);
			data = null;
			using ServerTextControl serverTextControl = this.method_46(this.byte_0);
			if (this.RemoveTrailingWhitespace)
			{
				this.method_48(serverTextControl);
			}
			MailMerge.smethod_2(serverTextControl, out this.byte_0);
			try
			{
				if (saveSettings != null)
				{
					serverTextControl.Save(out data, fileFormat, saveSettings);
				}
				else
				{
					serverTextControl.Save(out data, fileFormat);
				}
			}
			catch (Exception ex)
			{
				this.traceSource_0.TraceEvent(TraceEventType.Warning, 2, ex.ToString());
				throw;
			}
		}

		/// <summary>Saves the merged document to a string.</summary>
		/// <param name="data">Specifies a byte array or a string into which the data is saved.</param>
		/// <param name="fileFormat">Specifies one of the BinaryStreamType or the StringStreamType values.</param>
		/// <param name="saveSettings">Specifies a SaveSettings object with additional information and settings for the save operation.</param>
		public void SaveDocumentToMemory(out string data, StringStreamType fileFormat, SaveSettings saveSettings)
		{
			this.method_43(Enum7.flag_0 | Enum7.flag_2);
			data = null;
			using ServerTextControl serverTextControl = this.method_46(this.byte_0);
			if (this.RemoveTrailingWhitespace)
			{
				this.method_48(serverTextControl);
			}
			MailMerge.smethod_2(serverTextControl, out this.byte_0);
			try
			{
				if (saveSettings != null)
				{
					serverTextControl.Save(out data, fileFormat, saveSettings);
				}
				else
				{
					serverTextControl.Save(out data, fileFormat);
				}
			}
			catch (Exception ex)
			{
				this.traceSource_0.TraceEvent(TraceEventType.Warning, 2, ex.ToString());
				throw;
			}
		}

		/// <summary>Prints the merged document. It uses the settings of the specified PrintDocument.</summary>
		/// <param name="printDocument">Specifies an instance of the PrintDocument class.</param>
		public void Print(PrintDocument printDocument)
		{
			this.method_43(Enum7.flag_0 | Enum7.flag_2);
			using ServerTextControl serverTextControl = this.method_46(this.byte_0);
			try
			{
				serverTextControl.Print(printDocument);
			}
			catch (Exception ex)
			{
				this.traceSource_0.TraceEvent(TraceEventType.Warning, 2, ex.ToString());
				throw;
			}
		}

		public void Print(string docName, string printerName, short copyCount, bool collate)
		{
			this.method_43(Enum7.flag_0 | Enum7.flag_2);
			PrintDocument printDocument = new PrintDocument
			{
				DocumentName = docName,
				PrinterSettings = new PrinterSettings
				{
					PrinterName = printerName,
					Copies = copyCount,
					Collate = collate
				}
			};
			using ServerTextControl serverTextControl = this.method_46(this.byte_0);
			try
			{
				serverTextControl.Print(printDocument);
			}
			catch (Exception ex)
			{
				this.traceSource_0.TraceEvent(TraceEventType.Warning, 2, ex.ToString());
				throw;
			}
		}

		private void method_43(Enum7 enum7_0)
		{
			if ((enum7_0 & Enum7.flag_0) != 0 && this.TextComponent == null)
			{
				throw new Exception(Resources.EXC_MAILMERGE_INVALID_TEXT_COMPONENT);
			}
			if ((enum7_0 & Enum7.flag_1) != 0 && this.byte_1 == null)
			{
				throw new Exception(Resources.EXC_NO_TEMPLATE);
			}
			if ((enum7_0 & Enum7.flag_2) != 0 && this.byte_0 == null)
			{
				throw new Exception(Resources.EXC_NO_DOCUMENT);
			}
			if ((enum7_0 & Enum7.flag_3) != 0 && string.IsNullOrEmpty(this.string_2) && this.xmlDocument_0 == null)
			{
				if (string.IsNullOrEmpty(this.string_2))
				{
					throw new Exception(Resources.EXC_NO_REPORT_DATA_SOURCE_CONFIG_FILE);
				}
				if (this.xmlDocument_0 == null)
				{
					throw new Exception(Resources.EXC_NO_REPORT_DATA_SOURCE_CONFIG);
				}
			}
		}

		private void method_44()
		{
			if (this.class103_0 != null)
			{
				this.class103_0.method_2(out var template, BinaryStreamType.InternalUnicodeFormat);
				this.LoadTemplateFromMemory(template, FileFormat.InternalUnicodeFormat);
				this.bool_1 = true;
			}
		}

		private void method_45()
		{
			if (this.class103_0 != null)
			{
				this.SaveDocumentToMemory(out var data, BinaryStreamType.InternalUnicodeFormat, new SaveSettings());
				this.class103_0.method_1(data, BinaryStreamType.InternalUnicodeFormat, new LoadSettings
				{
					ApplicationFieldFormat = ApplicationFieldFormat.MSWordTXFormFields
				});
				this.byte_0 = null;
				this.byte_1 = null;
			}
		}

		internal ServerTextControl method_46(byte[] byte_2)
		{
			ServerTextControl serverTextControl = new ServerTextControl(this.TextComponent.GetType());
			serverTextControl.Create();
			if (byte_2 != null)
			{
				serverTextControl.Load(byte_2, BinaryStreamType.InternalUnicodeFormat, new LoadSettings
				{
					ApplicationFieldFormat = ApplicationFieldFormat.MSWordTXFormFields
				});
				if (!this.UseTemplateFormat && this.nullable_0.HasValue)
				{
					MailMerge.smethod_9(serverTextControl, this.nullable_0.Value);
				}
			}
			return serverTextControl;
		}

		internal ServerTextControl method_47()
		{
			return this.method_46(null);
		}

		internal static void smethod_9(ServerTextControl serverTextControl_0, Struct24 struct24_0)
		{
			serverTextControl_0.PageSize = struct24_0.PageSize_0;
			serverTextControl_0.Landscape = struct24_0.Boolean_0;
			serverTextControl_0.PageMargins = struct24_0.PageMargins_0;
			serverTextControl_0.FormattingPrinter = struct24_0.String_0;
		}

		internal void method_48(ServerTextControl serverTextControl_0)
		{
			serverTextControl_0.Selection.Start = -1;
			while (MailMerge.smethod_10(serverTextControl_0))
			{
				serverTextControl_0.Selection.Length = 0;
				serverTextControl_0.Selection.Start--;
				if (!this.method_49(serverTextControl_0))
				{
					string text = serverTextControl_0.Text.Substring(Math.Max(0, serverTextControl_0.Text.Length - 3));
					if (text.Length != 3 || !text.EndsWith("\r\n") || char.IsWhiteSpace(text[0]))
					{
						serverTextControl_0.Selection.Length = 1;
						serverTextControl_0.Selection.Text = "";
						continue;
					}
					break;
				}
				break;
			}
		}

		internal static bool smethod_10(ServerTextControl serverTextControl_0)
		{
			string text = serverTextControl_0.Text.Substring(Math.Max(0, serverTextControl_0.Text.Length - 1));
			if (text.Length > 0)
			{
				return char.IsWhiteSpace(text[0]);
			}
			return false;
		}

		private bool method_49(ServerTextControl serverTextControl_0)
		{
			List<int> list = new List<int>();
			foreach (ApplicationField applicationField in serverTextControl_0.ApplicationFields)
			{
				list.Add(applicationField.Start - 1);
			}
			foreach (DocumentLink documentLink in serverTextControl_0.DocumentLinks)
			{
				list.Add(documentLink.Start - 1);
			}
			foreach (DocumentTarget documentTarget in serverTextControl_0.DocumentTargets)
			{
				list.Add(documentTarget.Start - 1);
			}
			foreach (Image image in serverTextControl_0.Images)
			{
				list.Add(image.TextPosition - 1);
			}
			foreach (Table table in serverTextControl_0.Tables)
			{
				list.Add(table.Cells.GetItem(1, 1).Start - 1);
			}
			foreach (TextField textField in serverTextControl_0.TextFields)
			{
				list.Add(textField.Start - 1);
			}
			foreach (TextFrame textFrame in serverTextControl_0.TextFrames)
			{
				list.Add(textFrame.TextPosition - 1);
			}
			foreach (BarcodeFrame barcode in serverTextControl_0.Barcodes)
			{
				list.Add(barcode.TextPosition - 1);
			}
			foreach (ChartFrame chart in serverTextControl_0.Charts)
			{
				list.Add(chart.TextPosition - 1);
			}
			if (!list.Contains(serverTextControl_0.Selection.Start) && serverTextControl_0.Tables.GetItem() == null && serverTextControl_0.TextFields.GetItem() == null)
			{
				return serverTextControl_0.ApplicationFields.GetItem() != null;
			}
			return true;
		}

		private void method_50()
		{
			this.byte_0 = null;
			this.byte_1 = null;
			this.nullable_0 = null;
		}

		internal static Enum8 smethod_11()
		{
			Assembly entryAssembly = Assembly.GetEntryAssembly();
			if (entryAssembly == null)
			{
				return Enum8.const_1;
			}
			MethodInfo entryPoint = entryAssembly.EntryPoint;
			if (entryPoint == null)
			{
				return Enum8.const_1;
			}
			Type declaringType = entryPoint.DeclaringType;
			if (MailMerge.smethod_13("System.Windows.Forms.Form"))
			{
				return Enum8.const_1;
			}
			if (!MailMerge.smethod_12(declaringType, "System.Windows.Application") && !MailMerge.smethod_13("System.Windows.Controls.Control"))
			{
				return Enum8.const_1;
			}
			return Enum8.const_2;
		}

		internal static bool smethod_12(Type type_0, string string_7)
		{
			if (type_0 == null)
			{
				return false;
			}
			if (!(type_0.BaseType == null) && !(type_0.BaseType.FullName == "System.Object"))
			{
				if (type_0.BaseType.FullName == string_7)
				{
					return true;
				}
				return MailMerge.smethod_12(type_0.BaseType, string_7);
			}
			return false;
		}

		private static bool smethod_13(string string_7)
		{
			StackFrame[] frames = new StackTrace().GetFrames();
			for (int i = 0; i < frames.Length; i++)
			{
				MethodBase method = frames[i].GetMethod();
				if (method.DeclaringType == null)
				{
					break;
				}
				Type baseType = method.DeclaringType.BaseType;
				while (baseType != null)
				{
					if (!(baseType.FullName == string_7))
					{
						baseType = baseType.BaseType;
						continue;
					}
					return true;
				}
			}
			return false;
		}

		private StreamType method_51(FileFormat fileFormat_0)
		{
			StreamType result = StreamType.MSWord;
			switch (fileFormat_0)
			{
			case FileFormat.MSWord:
				result = StreamType.MSWord;
				break;
			case FileFormat.RichTextFormat:
				result = StreamType.RichTextFormat;
				break;
			case FileFormat.WordprocessingML:
				result = StreamType.WordprocessingML;
				break;
			case FileFormat.InternalUnicodeFormat:
				result = StreamType.InternalUnicodeFormat;
				break;
			}
			return result;
		}

		private static void smethod_14(IDataRowAdapter idataRowAdapter_0, out string string_7, out string string_8, MergeField mergeField_0)
		{
			string_7 = null;
			string_8 = null;
			if (idataRowAdapter_0 == null || !mergeField_0.Name.StartsWith("image:", StringComparison.OrdinalIgnoreCase))
			{
				return;
			}
			if (idataRowAdapter_0.Table.ColumnNames.Contains(mergeField_0.Name.ToLower()))
			{
				string_7 = (string_8 = mergeField_0.Name);
			}
			else if (mergeField_0.Name.Length > "image:".Length)
			{
				string text = mergeField_0.Name.Substring("image:".Length);
				if (idataRowAdapter_0.Table.ColumnNames.Contains(text.ToLower()))
				{
					string_7 = mergeField_0.Name;
					string_8 = text;
				}
			}
		}

		private static void smethod_15(ServerTextControl serverTextControl_0)
		{
			serverTextControl_0.Selection.Start = -1;
			serverTextControl_0.Selection.Length = 0;
			serverTextControl_0.Selection.Start--;
			if (serverTextControl_0.Tables.GetItem() == null)
			{
				serverTextControl_0.Selection.Length = 1;
				if (serverTextControl_0.Selection.Text == "\r\n")
				{
					serverTextControl_0.Selection.Text = string.Empty;
				}
			}
		}

		private bool method_52(string string_7)
		{
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(string_7);
				this.xmlDocument_0 = xmlDocument;
			}
			catch (XmlException)
			{
				return false;
			}
			return true;
		}

		private void method_53(string string_7)
		{
			if (!string.IsNullOrEmpty(string_7))
			{
				if (!Path.IsPathRooted(string_7) && string.IsNullOrEmpty(this.SearchPath))
				{
					string_7 = Path.Combine(this.SearchPath, string_7);
				}
				if (!File.Exists(string_7))
				{
					throw new Exception(Resources.EXC_MAILMERGE_INVALID_TEMPLATE_FILE_PATH);
				}
				FileFormat fileFormat = this.method_54(Path.GetExtension(string_7));
				if (fileFormat == (FileFormat)(-1))
				{
					throw new Exception(Resources.EXC_MAILMERGE_INVALID_TEMPLATE_FILE_PATH);
				}
				this.LoadTemplate(string_7, fileFormat);
			}
		}

		private FileFormat method_54(string string_7)
		{
			return string_7 switch
			{
				".rtf" => FileFormat.RichTextFormat, 
				".tx" => FileFormat.InternalUnicodeFormat, 
				".docx" => FileFormat.WordprocessingML, 
				".doc" => FileFormat.MSWord, 
				_ => (FileFormat)(-1), 
			};
		}

		private bool method_55(ApplicationField applicationField_0)
		{
			if (applicationField_0 != null && !string.IsNullOrEmpty(applicationField_0.TypeName))
			{
				switch (applicationField_0.TypeName)
				{
				default:
					return applicationField_0.Parameters != null;
				case "NEXT":
					return true;
				case "DATE":
				case "MERGEFIELD":
				case "IF":
				case "NEXTIF":
					return applicationField_0.Parameters != null;
				}
			}
			return false;
		}

		internal static object smethod_16(string string_7)
		{
			try
			{
				return Type.GetType("System.Windows.Forms.RightToLeft, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089").GetField(string_7).GetRawConstantValue();
			}
			catch
			{
			}
			return null;
		}

		internal static object smethod_17(string string_7)
		{
			try
			{
				return Type.GetType("System.Windows.FlowDirection, PresentationCore, Version=3.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35").GetField(string_7).GetRawConstantValue();
			}
			catch
			{
			}
			return null;
		}

		private void method_56()
		{
			this.icontainer_0 = new Container();
		}
	}
}
