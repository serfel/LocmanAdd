using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Xml;
using ns1;
using ns10;
using ns4;
using ns6;
using ns7;
using DocumentServer.Fields;
using DocumentServer.Json;
using DocumentServer.Properties;
using TXTextControl;
using TXTextControl.DocumentServer;

namespace DocumentServer.DataSources
{
	/// <summary>The DataSourceManager class is designed for handling all existing kinds of data sources which can be used together with the MailMerge class.</summary>
	public class DataSourceManager
	{
		[CompilerGenerated]
		private EventHandler eventHandler_0;

		[CompilerGenerated]
		private EventHandler eventHandler_1;

		[CompilerGenerated]
		private EventHandler eventHandler_2;

		[CompilerGenerated]
		private EventHandler eventHandler_3;

		[CompilerGenerated]
		private EventHandler eventHandler_4;

		[CompilerGenerated]
		private EventHandler eventHandler_5;

		[CompilerGenerated]
		private EventHandler eventHandler_6;

		[CompilerGenerated]
		private EventHandler eventHandler_7;

		private Stack<Type> stack_0 = new Stack<Type>();

		private List<byte[]> list_0 = new List<byte[]>();

		private int int_0 = int.MaxValue;

		private int int_1;

		private Dictionary<string, List<DataRow>> dictionary_0;

		[CompilerGenerated]
		private DataTableInfoCollection dataTableInfoCollection_0;

		[CompilerGenerated]
		private DataRelationInfoCollection dataRelationInfoCollection_0;

		[CompilerGenerated]
		private DataTableInfoCollection dataTableInfoCollection_1;

		[CompilerGenerated]
		private DataColumnInfoCollection dataColumnInfoCollection_0;

		private static readonly Color color_0;

		private static readonly Color color_1;

		private DataTableInfo dataTableInfo_0;

		private string string_0;

		private string string_1;

		private bool bool_0;

		private Enum28 enum28_0;

		private Class99 class99_0;

		private IEnumerable ienumerable_0;

		private DataSet dataSet_0;

		private DataTable dataTable_0;

		/// <summary>Gets a DataTableInfoCollection of DataTableInfo objects which represent the data tables in the data source.</summary>
		public DataTableInfoCollection DataTables
		{
			[CompilerGenerated]
			get
			{
				return this.dataTableInfoCollection_0;
			}
			[CompilerGenerated]
			private set
			{
				this.dataTableInfoCollection_0 = value;
			}
		}

		/// <summary>Gets a DataRelationInfoCollection of DataRelationInfo objects which represent the data relations in the data source.</summary>
		public DataRelationInfoCollection DataRelations
		{
			[CompilerGenerated]
			get
			{
				return this.dataRelationInfoCollection_0;
			}
			[CompilerGenerated]
			private set
			{
				this.dataRelationInfoCollection_0 = value;
			}
		}

		/// <summary>Gets a DataTableInfoCollection of DataTableInfo objects representing the tables which can be used as merge blocks using the currently selected master table.</summary>
		public DataTableInfoCollection PossibleMergeBlockTables
		{
			[CompilerGenerated]
			get
			{
				return this.dataTableInfoCollection_1;
			}
			[CompilerGenerated]
			private set
			{
				this.dataTableInfoCollection_1 = value;
			}
		}

		/// <summary>Gets a DataColumnInfoCollection of DataColumnInfo objects representing the table columns which can be used as merge fields using the currently selected master table.</summary>
		public DataColumnInfoCollection PossibleMergeFieldColumns
		{
			[CompilerGenerated]
			get
			{
				return this.dataColumnInfoCollection_0;
			}
			[CompilerGenerated]
			private set
			{
				this.dataColumnInfoCollection_0 = value;
			}
		}

		/// <summary>Gets or sets a DataTableInfo object representing the table which is used as a master table when merging data into the document.</summary>
		public DataTableInfo MasterDataTableInfo
		{
			get
			{
				return this.dataTableInfo_0;
			}
			set
			{
				this.method_16(value);
			}
		}

		/// <summary>Gets the name of the data provider selected with the DatabaseConnectionDialog.</summary>
		public string DataProviderName
		{
			get
			{
				return this.string_0;
			}
			private set
			{
				string text = this.string_0;
				this.string_0 = value;
				if (text != value)
				{
					this.OnDataProviderNameChanged(this);
				}
			}
		}

		/// <summary>Gets the connection string of the connection selected with the DatabaseConnectionDialog.</summary>
		public string ConnectionString
		{
			get
			{
				return this.string_1;
			}
			private set
			{
				string text = this.string_1;
				this.string_1 = value;
				if (value != text)
				{
					this.OnConnectionStringChanged(this);
				}
			}
		}

		/// <summary>Gets a value indicating whether all requirements are met and the method Merge can be called.</summary>
		public bool IsMergingPossible
		{
			get
			{
				return this.bool_0;
			}
			private set
			{
				bool flag = this.bool_0;
				this.bool_0 = value;
				if (value != flag)
				{
					this.OnIsMergingPossibleChanged(this);
				}
			}
		}

		internal Enum28 Enum28_0 => this.enum28_0;

		/// <summary>Is fired when the contents of the DataTables property change.</summary>
		public event EventHandler DataTablesChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.eventHandler_0;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Is fired when the contents of the DataRelations property change.</summary>
		public event EventHandler DataRelationsChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.eventHandler_1;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_1, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.eventHandler_1;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_1, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Is fired when the contents of the PossibleMergeBlockTables property change.</summary>
		public event EventHandler PossibleMergeBlockTablesChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.eventHandler_2;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_2, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.eventHandler_2;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_2, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Is fired when the contents of the PossibleMergeFieldColumns property change.</summary>
		public event EventHandler PossibleMergeFieldColumnsChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.eventHandler_3;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_3, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.eventHandler_3;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_3, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Is fired when the contents of the MasterDataTableInfo property change.</summary>
		public event EventHandler MasterDataTableInfoChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.eventHandler_4;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_4, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.eventHandler_4;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_4, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Is fired when the contents of the DataProviderName property change.</summary>
		public event EventHandler DataProviderNameChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.eventHandler_5;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_5, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.eventHandler_5;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_5, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Is fired when the contents of the ConnectionString property change.</summary>
		public event EventHandler ConnectionStringChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.eventHandler_6;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_6, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.eventHandler_6;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_6, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		/// <summary>Is fired when the value of the IsMergingPossible property changes.</summary>
		public event EventHandler IsMergingPossibleChanged
		{
			[CompilerGenerated]
			add
			{
				EventHandler eventHandler = this.eventHandler_7;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_7, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			[CompilerGenerated]
			remove
			{
				EventHandler eventHandler = this.eventHandler_7;
				EventHandler eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_7, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		protected virtual void OnDataTablesChanged(object sender)
		{
			if (this.eventHandler_0 != null)
			{
				this.eventHandler_0(sender, EventArgs.Empty);
			}
		}

		protected virtual void OnDataRelationsChanged(object sender)
		{
			if (this.eventHandler_1 != null)
			{
				this.eventHandler_1(sender, EventArgs.Empty);
			}
		}

		protected virtual void OnPossibleMergeBlockTablesChanged(object sender)
		{
			if (this.eventHandler_2 != null)
			{
				this.eventHandler_2(sender, EventArgs.Empty);
			}
		}

		protected virtual void OnPossibleMergeFieldColumnsChanged(object sender)
		{
			if (this.eventHandler_3 != null)
			{
				this.eventHandler_3(sender, EventArgs.Empty);
			}
		}

		protected virtual void OnMasterDataTableInfoChanged(object sender)
		{
			if (this.eventHandler_4 != null)
			{
				this.eventHandler_4(sender, EventArgs.Empty);
			}
		}

		protected virtual void OnDataProviderNameChanged(object sender)
		{
			if (this.eventHandler_5 != null)
			{
				this.eventHandler_5(sender, EventArgs.Empty);
			}
		}

		protected virtual void OnConnectionStringChanged(object sender)
		{
			if (this.eventHandler_6 != null)
			{
				this.eventHandler_6(sender, EventArgs.Empty);
			}
		}

		protected virtual void OnIsMergingPossibleChanged(object sender)
		{
			if (this.eventHandler_7 != null)
			{
				this.eventHandler_7(sender, EventArgs.Empty);
			}
		}

		/// <summary>Loads an assembly file as a data source. Automatically deduces table and column names as well as data relations from the public properties of all public classes found in the assembly.</summary>
		/// <param name="fileName">The assembly file name.</param>
		public void LoadAssembly(string fileName)
		{
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentException(Resources.EXC_FILENAME_ARG_EMPTY, "fileName");
			}
			this.DataTables = new DataTableInfoCollection(AssemblySerializer.Serialize(fileName));
			foreach (DataTableInfo item in new List<DataTableInfo>(this.DataTables))
			{
				this.method_32(item, this.DataTables);
			}
			this.OnDataTablesChanged(this);
			this.method_17();
			this.IsMergingPossible = false;
			this.enum28_0 = Enum28.const_3;
		}

		/// <summary>Loads a System.Data.DataSet object as a data source.</summary>
		/// <param name="dataSet">The System.Data.DataSet object to use as a data source.</param>
		public void LoadDataSet(DataSet dataSet)
		{
			this.method_2();
			this.method_14(dataSet);
			this.enum28_0 = Enum28.const_1;
		}

		/// <summary>Loads a System.Data.DataTable object as a data source.</summary>
		/// <param name="dataTable">The DataTable object to use as a data source.</param>
		public void LoadDataTable(DataTable dataTable)
		{
			this.method_2();
			this.method_22(dataTable);
			this.method_17();
			this.IsMergingPossible = this.DataTables.Count > 0;
			this.enum28_0 = Enum28.const_2;
		}

		/// <summary>Loads the contents of an XML file as a data source.</summary>
		/// <param name="fileName">The file name.</param>
		public void LoadXmlFile(string fileName)
		{
			if (string.IsNullOrEmpty(fileName))
			{
				throw new ArgumentException(Resources.EXC_FILENAME_ARG_EMPTY, "fileName");
			}
			this.method_2();
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(fileName);
			this.method_14(dataSet);
			this.enum28_0 = Enum28.const_1;
		}

		/// <summary>Loads XML data, given as a string, as a data source.</summary>
		/// <param name="xml">A string containing XML data.</param>
		public void LoadXmlString(string xmlSchema)
		{
			using (StringReader textReader_ = new StringReader(xmlSchema))
			{
				this.method_15(textReader_);
			}
			this.enum28_0 = Enum28.const_1;
		}

		/// <summary>Loads a collection implementing the interface IEnumerable as a data source and deduces the data tables, column names and data relations from the public properties and used classes of the first contained object using .NET reflection or, in case of the first contained object being a Dictionary with string keys, from the key names and value types.</summary>
		/// <param name="objects">A collection implementing interface System.Collections.IEnumerable containing objects of any type.</param>
		public void LoadObjects(IEnumerable objects)
		{
			IEnumerator enumerator = objects.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					object current = enumerator.Current;
					this.method_0(current, bool_1: false);
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			this.ienumerable_0 = objects;
		}

		/// <summary>Loads a single object which is either a Dictionary with string keys or an object of an arbitrary type as a data source. The data tables, column names are deduced either from the key names or the public property names and types using .NET reflection.</summary>
		/// <param name="obj">A single object which is either a Dictionary with string keys or an object of an arbitrary type as a data source.</param>
		public void LoadSingleObject(object obj)
		{
			this.method_0(obj, bool_1: true);
		}

		private void method_0(object object_0, bool bool_1)
		{
			this.method_2();
			if (object_0 != null)
			{
				this.stack_0.Clear();
				this.method_18(object_0, "RootTable", this.DataTables);
				DataTableInfo dataTableInfo_ = this.DataTables["RootTable"];
				this.method_32(dataTableInfo_, this.DataTables);
				this.OnDataTablesChanged(this);
				this.method_16(dataTableInfo_);
				this.IsMergingPossible = this.DataTables.Count > 0;
				this.enum28_0 = Enum28.const_4;
				if (bool_1)
				{
					this.ienumerable_0 = new List<object>(new object[1] { object_0 });
				}
			}
		}

		/// <summary>Loads a JSON string containing an array of objects or a single object as a data source. Automatically deduces table and column names as well as data relations from property names and nested objects in the given single object or, in case of an array, the first object.</summary>
		/// <param name="json">A JSON string containing a single object or an array of objects.</param>
		public void LoadJson(string json)
		{
			this.method_2();
			object obj = JsonConvert.DeserializeObject(json);
			if (obj != null)
			{
				Type type = obj.GetType();
				if (!type.IsSimpleType() && type.IsEnumerableType())
				{
					this.LoadObjects((IEnumerable)obj);
				}
				else
				{
					this.LoadSingleObject(obj);
				}
			}
		}

		public void InsertMergeBlock(object textControl, MergeBlockInfo mergeBlockInfo, MergeBlockSettings settings)
		{
			Table table_ = null;
			if (mergeBlockInfo == null)
			{
				throw new ArgumentNullException("mergeBlockInfo");
			}
			if (mergeBlockInfo.ColumnNames != null && mergeBlockInfo.ColumnNames.Count != 0)
			{
				Class103 class103_ = new Class103(textControl);
				switch (settings.BlockTemplateType)
				{
				case BlockTemplateType.PlainParagraph:
					this.method_25(class103_, mergeBlockInfo, settings.HighlightColor, settings.FieldDisplayMode, bool_1: true);
					break;
				case BlockTemplateType.TableRow:
					this.method_26(class103_, mergeBlockInfo, settings.HighlightColor, settings.FieldDisplayMode, out table_, settings.TableID, bool_1: true, settings.CreateHeaderRow, bool_3: false);
					settings.CreatedTable = table_;
					break;
				}
				return;
			}
			throw new Exception(Resources.EXC_DATASOURCEMGR_NO_BLOCK_COL_NAMES);
		}

		public IList<byte[]> Merge(byte[] template, object textControl)
		{
			return this.Merge(template, int.MaxValue, textControl);
		}

		/// <summary>Merges a binary TX internal unicode format document with the currently loaded data source.</summary>
		/// <param name="template">A binary TX internal unicode format document into which the data is merged.</param>
		/// <param name="maxDocuments">Specifies the maximum number of merged documents.</param>
		/// <param name="textControl">A TextControl instance needed for licensing purposes.</param>
		public IList<byte[]> Merge(byte[] template, int maxDocuments, object textControl)
		{
			List<byte[]> list = new List<byte[]>();
			if (maxDocuments <= 0)
			{
				throw new ArgumentOutOfRangeException("maxDocuments", Resources.EXC_DATASOURCEMGR_MERGE_MAX_DOCS_TOO_SMALL);
			}
			if (template == null)
			{
				throw new ArgumentNullException("document");
			}
			if (template.Length == 0)
			{
				throw new ArgumentException(Resources.EXC_DATASOURCEMGR_MERGE_NO_DOCUMENT_DATA, "document");
			}
			this.method_4();
			switch (this.enum28_0)
			{
			case Enum28.const_1:
				list.AddRange(this.method_8(template, maxDocuments, textControl));
				break;
			case Enum28.const_2:
				list.AddRange(this.method_7(template, maxDocuments, textControl));
				break;
			case Enum28.const_4:
				list.AddRange(this.method_6(template, maxDocuments, textControl));
				break;
			case Enum28.const_5:
				list.AddRange(this.method_5(template, maxDocuments, textControl));
				break;
			}
			return list;
		}

		/// <summary>Checks if a given SubTextPart is a merge block.</summary>
		/// <param name="subTextPart">The SubTextPart object to be checked.</param>
		public static bool IsMergeBlock(SubTextPart subTextPart)
		{
			return subTextPart.Name.StartsWith("txmb_", StringComparison.OrdinalIgnoreCase);
		}

		/// <summary>Shows the system's default save file dialog where a file name and location can be selected.</summary>
		public void SaveDataSourceConfig()
		{
			this.SaveDataSourceConfig(null);
		}

		/// <summary>Shows the system's default save file dialog where a file name and location can be selected.</summary>
		/// <param name="owner">An object that represents the top-level window that will own the modal dialog box.</param>
		public void SaveDataSourceConfig(object owner)
		{
			if (this.class99_0 == null)
			{
				throw new Exception(Resources.EXC_SAVE_REP_DATA_SRC_CONF_WRONG_DATA_SOURCE_TYPE);
			}
			try
			{
				Class102 @class = new Class102(this.class99_0);
				if (MailMerge.Enum8_0 == Enum8.const_1)
				{
					if (this.method_35(out var string_, owner) == true)
					{
						@class.method_0(string_);
					}
					return;
				}
				throw new Exception(Resources.EXC_DATA_SRC_CONF_ONLY_WIN_FORMS);
			}
			catch (Exception ex)
			{
				throw new Exception(string.Format(Resources.EXC_COULD_NOT_SAVE_CONFIG, ex.Message));
			}
		}

		/// <summary>Saves the configuration data into a given string.</summary>
		/// <param name="configData">A string into which the config file content will be written when the method is called.</param>
		public void SaveDataSourceConfig(out string configData)
		{
			if (this.class99_0 == null)
			{
				throw new Exception(Resources.EXC_SAVE_REP_DATA_SRC_CONF_WRONG_DATA_SOURCE_TYPE);
			}
			try
			{
				configData = "";
				Class102 @class = new Class102(this.class99_0);
				configData = @class.method_1();
			}
			catch (Exception ex)
			{
				throw new Exception(string.Format(Resources.EXC_COULD_NOT_SAVE_CONFIG, ex.Message));
			}
		}

		/// <summary>Shows the system's default open file dialog where a configuration file can be selected.</summary>
		public void LoadDataSourceConfig()
		{
			this.LoadDataSourceConfig(null);
		}

		/// <summary>Shows the system's default open file dialog where a configuration file can be selected.</summary>
		/// <param name="owner">An object that represents the top-level window that will own the modal dialog box.</param>
		public void LoadDataSourceConfig(object owner)
		{
			try
			{
				if (MailMerge.Enum8_0 == Enum8.const_1)
				{
					if (this.method_36(out var string_, owner) == true)
					{
						Class99 class99_ = new Class99(new Class102(string_));
						this.method_24(class99_);
					}
					return;
				}
				throw new Exception(Resources.EXC_DATA_SRC_CONF_ONLY_WIN_FORMS);
			}
			catch (Exception ex)
			{
				throw new Exception(string.Format(Resources.EXC_COULD_NOT_LOAD_CONFIG, ex.Message));
			}
		}

		/// <summary>Loads XML configuration data given as a string.</summary>
		/// <param name="configData">A string containing XML configuration data.</param>
		public void LoadDataSourceConfig(string configData)
		{
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadXml(configData);
				Class99 class99_ = new Class99(new Class102(xmlDocument));
				this.method_24(class99_);
			}
			catch (Exception ex)
			{
				throw new Exception(string.Format(Resources.EXC_COULD_NOT_LOAD_CONFIG, ex.Message));
			}
		}

		private void method_1()
		{
			this.method_2();
		}

		private void method_2()
		{
			this.method_3();
			this.dataTableInfo_0 = null;
			this.ienumerable_0 = null;
			this.class99_0 = null;
			this.dataSet_0 = null;
			this.dataTable_0 = null;
			this.enum28_0 = Enum28.const_0;
		}

		internal void method_3()
		{
			this.DataProviderName = "";
			this.ConnectionString = "";
			this.DataTables = new DataTableInfoCollection();
			this.DataRelations = new DataRelationInfoCollection();
			this.PossibleMergeBlockTables = new DataTableInfoCollection();
			this.PossibleMergeFieldColumns = new DataColumnInfoCollection();
			this.IsMergingPossible = false;
		}

		private void method_4()
		{
			if (!this.IsMergingPossible)
			{
				if (this.enum28_0 == Enum28.const_3)
				{
					throw new Exception(Resources.EXC_DATASOURCEMGR_CANNOT_MERGE_ASSEMBLY);
				}
				throw new Exception(Resources.EXC_DATASOURCEMGR_MERGE_NOT_POSSIBLE);
			}
			switch (this.enum28_0)
			{
			default:
				throw new Exception(Resources.EXC_DATASOURCEMGR_MERGE_NOT_POSSIBLE);
			case Enum28.const_0:
				throw new Exception(Resources.EXC_DATASOURCEMGR_MERGE_NOT_POSSIBLE);
			case Enum28.const_1:
				if (this.dataSet_0 == null)
				{
					throw new Exception(Resources.EXC_DATASOURCEMGR_MERGE_NOT_POSSIBLE);
				}
				break;
			case Enum28.const_2:
				if (this.dataTable_0 == null)
				{
					throw new Exception(Resources.EXC_DATASOURCEMGR_MERGE_NOT_POSSIBLE);
				}
				break;
			case Enum28.const_3:
				throw new Exception(Resources.EXC_DATASOURCEMGR_CANNOT_MERGE_ASSEMBLY);
			case Enum28.const_4:
				if (this.ienumerable_0 == null)
				{
					throw new Exception(Resources.EXC_DATASOURCEMGR_MERGE_NOT_POSSIBLE);
				}
				break;
			case Enum28.const_5:
				if (this.class99_0 == null || string.IsNullOrEmpty(this.ConnectionString) || string.IsNullOrEmpty(this.DataProviderName))
				{
					throw new Exception(Resources.EXC_DATASOURCEMGR_MERGE_NOT_POSSIBLE);
				}
				break;
			}
		}

		private IEnumerable<byte[]> method_5(byte[] byte_0, int int_2, object object_0)
		{
			this.class99_0.SelectTable(this.MasterDataTableInfo.TableName);
			this.int_0 = int_2;
			MailMerge mailMerge = this.method_33(byte_0, object_0);
			try
			{
				mailMerge.Merge(this.class99_0.SelectedTable.DataTable_0, append: false);
			}
			catch (MergeCanceledException)
			{
			}
			List<byte[]> result = this.list_0;
			this.list_0 = new List<byte[]>();
			return result;
		}

		private IList<byte[]> method_6(byte[] byte_0, int int_2, object object_0)
		{
			this.int_0 = int_2;
			MailMerge mailMerge = this.method_33(byte_0, object_0);
			try
			{
				mailMerge.MergeObjects(this.ienumerable_0, append: false);
			}
			catch (MergeCanceledException)
			{
			}
			List<byte[]> result = this.list_0;
			this.list_0 = new List<byte[]>();
			return result;
		}

		private IList<byte[]> method_7(byte[] byte_0, int int_2, object object_0)
		{
			this.int_0 = int_2;
			MailMerge mailMerge = this.method_33(byte_0, object_0);
			try
			{
				mailMerge.Merge(this.dataTable_0, append: false);
			}
			catch (MergeCanceledException)
			{
			}
			List<byte[]> result = this.list_0;
			this.list_0 = new List<byte[]>();
			return result;
		}

		private IList<byte[]> method_8(byte[] byte_0, int int_2, object object_0)
		{
			DataTable dataTable = null;
			foreach (DataTable table in this.dataSet_0.Tables)
			{
				if (table.TableName.ToLower() == this.MasterDataTableInfo.TableName.ToLower())
				{
					dataTable = table;
					break;
				}
			}
			if (dataTable == null)
			{
				return this.list_0;
			}
			this.int_0 = int_2;
			MailMerge mailMerge = this.method_33(byte_0, object_0);
			try
			{
				mailMerge.Merge(dataTable, append: false);
			}
			catch (MergeCanceledException)
			{
			}
			List<byte[]> result = this.list_0;
			this.list_0 = new List<byte[]>();
			return result;
		}

		private void method_9(object sender, MailMerge.DataRowMergedEventArgs e)
		{
			this.list_0.Add(e.MergedRow);
			if (++this.int_1 >= this.int_0)
			{
				e.Cancel = true;
			}
		}

		private void method_10(Class99 class99_1)
		{
			this.method_2();
			this.method_11(class99_1);
		}

		private void method_11(Class99 class99_1)
		{
			List<string> list = new List<string>(class99_1.TableNames);
			list.AddRange(class99_1.ViewNames);
			foreach (string item in list)
			{
				DataTable table = class99_1.GetTable(item);
				this.DataTables.method_0(new DataTableInfo(table));
			}
			this.class99_0 = class99_1;
			this.OnDataTablesChanged(this);
			this.method_17();
		}

		internal void method_12()
		{
			if (this.dataSet_0 != null)
			{
				this.method_14(this.dataSet_0);
			}
			else if (this.class99_0 != null)
			{
				this.method_11(this.class99_0);
			}
		}

		internal DataSet method_13()
		{
			DataSet dataSet = null;
			if (this.enum28_0 == Enum28.const_0)
			{
				throw new Exception(Resources.EXC_DATASOURCEMGR_NO_DATA_SOURCE_LOADED);
			}
			if (this.class99_0 == null && this.dataSet_0 == null && this.dataTable_0 == null)
			{
				throw new Exception(Resources.EXC_EDIT_DATA_RELS_DLG_WRONG_DB_TYPE);
			}
			switch (this.enum28_0)
			{
			case Enum28.const_1:
				dataSet = this.dataSet_0;
				break;
			case Enum28.const_2:
				if (this.dataTable_0.DataSet != null)
				{
					dataSet = this.dataTable_0.DataSet;
					break;
				}
				dataSet = new DataSet();
				dataSet.Tables.Add(this.dataTable_0);
				break;
			case Enum28.const_5:
				dataSet = this.class99_0.DataSet_0;
				break;
			}
			return dataSet;
		}

		private void method_14(DataSet dataSet_1)
		{
			this.DataTables.method_1();
			foreach (DataTable table in dataSet_1.Tables)
			{
				this.DataTables.method_0(new DataTableInfo(table));
			}
			this.DataRelations.method_1();
			foreach (DataRelation relation in dataSet_1.Relations)
			{
				this.DataRelations.method_0(new DataRelationInfo(relation));
			}
			this.dataSet_0 = dataSet_1;
			this.OnDataTablesChanged(this);
			this.OnDataRelationsChanged(this);
			this.method_17();
			this.IsMergingPossible = this.DataTables.Count > 0;
		}

		private void method_15(TextReader textReader_0)
		{
			this.method_2();
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(textReader_0);
			this.method_14(dataSet);
		}

		private void method_16(DataTableInfo dataTableInfo_1)
		{
			if (dataTableInfo_1 == null)
			{
				throw new ArgumentNullException("table");
			}
			if (!Array.Exists(this.DataTables.method_2(), (DataTableInfo t) => t == dataTableInfo_1))
			{
				throw new ArgumentException(Resources.EXC_TABLE_NOT_PART_OF_DATA_SOURCE, "table");
			}
			this.dataTableInfo_0 = dataTableInfo_1;
			this.PossibleMergeBlockTables.method_1();
			this.PossibleMergeFieldColumns.method_1();
			foreach (DataColumnInfo column in dataTableInfo_1.Columns)
			{
				this.PossibleMergeFieldColumns.method_0(column);
			}
			if (dataTableInfo_1.ChildRelations.Count > 0)
			{
				foreach (DataRelationInfo childRelation in dataTableInfo_1.ChildRelations)
				{
					DataTableInfo dataTableInfo = this.DataTables[childRelation.ChildTableName];
					this.PossibleMergeBlockTables.method_0(dataTableInfo);
				}
			}
			else
			{
				foreach (DataTableInfo childTable in dataTableInfo_1.ChildTables)
				{
					this.PossibleMergeBlockTables.method_0(childTable);
				}
			}
			if (this.class99_0 != null)
			{
				this.class99_0.SelectTable(dataTableInfo_1.TableName);
			}
			this.OnMasterDataTableInfoChanged(this);
			this.OnPossibleMergeFieldColumnsChanged(this);
			this.OnPossibleMergeBlockTablesChanged(this);
		}

		private void method_17()
		{
			DataTableInfo dataTableInfo = ((this.DataTables.Count > 0) ? this.DataTables[0] : null);
			foreach (DataTableInfo dataTable in this.DataTables)
			{
				if (dataTable.ChildTables.Count > 0 && !this.method_28(dataTable))
				{
					dataTableInfo = dataTable;
					break;
				}
			}
			if (dataTableInfo != null)
			{
				this.method_16(dataTableInfo);
			}
		}

		private void method_18(object object_0, string string_2, DataTableInfoCollection dataTableInfoCollection_2)
		{
			if (object_0 == null)
			{
				return;
			}
			Type type = object_0.GetType();
			if (AssemblySerializer.IsInIgnoredNamespace(type))
			{
				return;
			}
			if (object_0 is IDictionary)
			{
				if (type.IsCorrectDictType())
				{
					this.method_19((IDictionary)object_0, string_2, dataTableInfoCollection_2);
				}
			}
			else if (type.IsEnumerableType())
			{
				this.method_20((IEnumerable)object_0, string_2, dataTableInfoCollection_2);
			}
			else if (!this.stack_0.Contains(type))
			{
				this.stack_0.Push(type);
				this.method_21(object_0, string_2, dataTableInfoCollection_2);
				this.stack_0.Pop();
			}
		}

		private void method_19(IDictionary idictionary_0, string string_2, DataTableInfoCollection dataTableInfoCollection_2)
		{
			DataTableInfo dataTableInfo = new DataTableInfo(string_2);
			foreach (string key in idictionary_0.Keys)
			{
				object obj = idictionary_0[key];
				Type type = ((obj != null) ? obj.GetType().GetUnderlyingType() : typeof(string));
				Type dataType = (type.IsSimpleType() ? type : typeof(string));
				DataColumnInfo dataColumnInfo_ = new DataColumnInfo(key, dataType, dataTableInfo);
				dataTableInfo.Columns.method_0(dataColumnInfo_);
				if (obj != null && !type.IsSimpleType())
				{
					this.method_18(obj, key, dataTableInfo.ChildTables);
				}
			}
			if (dataTableInfo.Columns.Count > 0)
			{
				dataTableInfoCollection_2.method_0(dataTableInfo);
			}
		}

		private void method_20(IEnumerable ienumerable_1, string string_2, DataTableInfoCollection dataTableInfoCollection_2)
		{
			object obj = null;
			IEnumerator enumerator = ienumerable_1.GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					obj = enumerator.Current;
				}
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
			if (obj != null)
			{
				this.method_18(obj, string_2, dataTableInfoCollection_2);
			}
		}

		private void method_21(object object_0, string string_2, DataTableInfoCollection dataTableInfoCollection_2)
		{
			if (object_0 == null)
			{
				return;
			}
			PropertyInfo[] publicGettableProps = object_0.GetType().GetPublicGettableProps();
			DataTableInfo dataTableInfo = new DataTableInfo(string_2);
			PropertyInfo[] array = publicGettableProps;
			foreach (PropertyInfo propertyInfo in array)
			{
				object obj = null;
				try
				{
					obj = propertyInfo.GetValue(object_0, null);
				}
				catch
				{
				}
				if (obj != null)
				{
					Type underlyingType = propertyInfo.PropertyType.GetUnderlyingType();
					Type dataType = (underlyingType.IsSimpleType() ? underlyingType : typeof(string));
					DataColumnInfo dataColumnInfo_ = new DataColumnInfo(propertyInfo.Name, dataType, dataTableInfo);
					dataTableInfo.Columns.method_0(dataColumnInfo_);
					if (!underlyingType.IsSimpleType())
					{
						this.method_18(obj, propertyInfo.Name, dataTableInfo.ChildTables);
					}
				}
			}
			if (dataTableInfo.Columns.Count > 0)
			{
				dataTableInfoCollection_2.method_0(dataTableInfo);
			}
		}

		private bool method_22(DataTable dataTable_1, bool bool_1 = false)
		{
			if (this.DataTables.Contains(dataTable_1.TableName))
			{
				return false;
			}
			this.DataTables.method_0(new DataTableInfo(dataTable_1));
			foreach (DataRelation childRelation in dataTable_1.ChildRelations)
			{
				this.DataRelations.method_0(new DataRelationInfo(childRelation));
				this.method_22(childRelation.ChildTable, bool_1: true);
			}
			if (!bool_1)
			{
				this.dataTable_0 = dataTable_1;
				this.OnDataTablesChanged(this);
				this.OnDataRelationsChanged(this);
			}
			return true;
		}

		internal void method_23(string string_2, string string_3)
		{
			Class99 class99_ = new Class99(string_2, string_3, null);
			this.method_24(class99_);
		}

		private void method_24(Class99 class99_1)
		{
			this.method_10(class99_1);
			this.DataProviderName = class99_1.String_0;
			this.ConnectionString = class99_1.String_1;
			this.IsMergingPossible = this.DataTables.Count > 0;
			this.enum28_0 = Enum28.const_5;
		}

		private void method_25(Class103 class103_0, MergeBlockInfo mergeBlockInfo_0, Color color_2, FieldDisplayMode fieldDisplayMode_0, bool bool_1, bool bool_2 = false)
		{
			if (class103_0.InputPosition_0.Column != 0)
			{
				class103_0.Selection_0.Text = Environment.NewLine;
			}
			int textPosition = class103_0.InputPosition_0.TextPosition;
			if (!bool_2)
			{
				class103_0.method_3("Insert Merge Block");
			}
			for (int i = 0; i < mergeBlockInfo_0.ColumnNames.Count; i++)
			{
				MergeField mergeField = this.method_29(class103_0, mergeBlockInfo_0.ColumnNames[i], fieldDisplayMode_0, bool_1);
				class103_0.InputPosition_0 = new InputPosition(mergeField.Start + mergeField.Length - 1, TextFieldPosition.OutsideTextField);
				if (i == mergeBlockInfo_0.ColumnNames.Count - 1)
				{
					break;
				}
				class103_0.Selection_0.Text = " ";
			}
			class103_0.Selection_0.Text = ((mergeBlockInfo_0.ChildBlocks.Count > 0) ? "\r\n\r\n" : "\r\n");
			int textPosition2 = class103_0.InputPosition_0.TextPosition;
			SubTextPart subTextPart = new SubTextPart(mergeBlockInfo_0.String_0, 0, textPosition + 1, textPosition2 - textPosition);
			if (mergeBlockInfo_0.Boolean_0)
			{
				subTextPart.Data = mergeBlockInfo_0.method_0();
			}
			subTextPart.HighlightColor = color_2;
			SubTextPartCollection.AddResult addResult = class103_0.SubTextPartCollection_0.Add(subTextPart);
			if (mergeBlockInfo_0.ChildBlocks.Count > 0)
			{
				class103_0.InputPosition_0 = new InputPosition(class103_0.InputPosition_0.TextPosition - 1);
				foreach (MergeBlockInfo childBlock in mergeBlockInfo_0.ChildBlocks)
				{
					this.method_25(class103_0, childBlock, color_2, fieldDisplayMode_0, bool_1: true);
				}
			}
			if (addResult != SubTextPartCollection.AddResult.Successful)
			{
				if (!bool_2)
				{
					class103_0.method_4();
					class103_0.method_5();
				}
			}
			else if (!bool_2)
			{
				class103_0.method_4();
			}
		}

		private SubTextPartCollection.AddResult method_26(Class103 class103_0, MergeBlockInfo mergeBlockInfo_0, Color color_2, FieldDisplayMode fieldDisplayMode_0, out Table table_0, short short_0, bool bool_1, bool bool_2, bool bool_3)
		{
			if (!bool_3)
			{
				class103_0.method_3("Insert Merge Block");
			}
			SubTextPartCollection.AddResult num = this.method_27(class103_0, mergeBlockInfo_0, color_2, fieldDisplayMode_0, out table_0, short_0, bool_1, bool_2);
			if (num != SubTextPartCollection.AddResult.Successful)
			{
				if (!bool_3)
				{
					class103_0.method_4();
					class103_0.method_5();
					return num;
				}
			}
			else if (!bool_3)
			{
				class103_0.method_4();
			}
			return num;
		}

		private SubTextPartCollection.AddResult method_27(Class103 class103_0, MergeBlockInfo mergeBlockInfo_0, Color color_2, FieldDisplayMode fieldDisplayMode_0, out Table table_0, short short_0, bool bool_1, bool bool_2)
		{
			int num = DataSourceManager.smethod_0(class103_0);
			int num2 = ((!bool_2) ? 1 : 2);
			int row = num2;
			SubTextPartCollection.AddResult result = SubTextPartCollection.AddResult.Error;
			table_0 = null;
			if (mergeBlockInfo_0.ChildBlocks.Count > 0)
			{
				num2++;
			}
			class103_0.TableCollection_0.Add(num2, mergeBlockInfo_0.ColumnNames.Count, num);
			Table item = class103_0.TableCollection_0.GetItem(num);
			if (item == null)
			{
				return result;
			}
			table_0 = item;
			if (short_0 != 0)
			{
				item.Int32_0 = short_0;
			}
			if (bool_2)
			{
				item.Rows.GetItem(1).IsHeader = true;
			}
			for (int i = 0; i < item.Columns.Count; i++)
			{
				TableCell item2;
				if (bool_2)
				{
					item2 = item.Cells.GetItem(1, i + 1);
					this.method_31(item2, DataSourceManager.color_0, 200);
					item2.Select();
					class103_0.Selection_0.Length = 0;
					class103_0.Selection_0.Bold = true;
					class103_0.Selection_0.ForeColor = Color.White;
					class103_0.Selection_0.Text = mergeBlockInfo_0.ColumnNames[i];
				}
				item2 = item.Cells.GetItem(row, i + 1);
				this.method_31(item2, DataSourceManager.color_1, 100);
				item2.Select();
				class103_0.Selection_0.Length = 0;
				this.method_29(class103_0, mergeBlockInfo_0.ColumnNames[i], fieldDisplayMode_0, bool_1);
			}
			int startRow = ((!bool_2) ? 1 : 2);
			item.Select(startRow, 1, num2, item.Columns.Count);
			SubTextPart subTextPart = new SubTextPart(mergeBlockInfo_0.String_0, 0);
			if (mergeBlockInfo_0.Boolean_0)
			{
				subTextPart.Data = mergeBlockInfo_0.method_0();
			}
			subTextPart.HighlightColor = color_2;
			result = class103_0.SubTextPartCollection_0.Add(subTextPart);
			if (result != SubTextPartCollection.AddResult.Successful)
			{
				return result;
			}
			if (mergeBlockInfo_0.ChildBlocks.Count > 0)
			{
				item.Select(num2, 1, num2, item.Columns.Count);
				item.MergeCells();
				TableRow item3 = item.Rows.GetItem(num2);
				TableCellFormat cellFormat = item3.CellFormat;
				item3.CellFormat.RightTextDistance = 0;
				cellFormat.LeftTextDistance = 0;
				item.Select(num2, 1, num2, 1);
				class103_0.Selection_0.Length = 0;
				foreach (MergeBlockInfo childBlock in mergeBlockInfo_0.ChildBlocks)
				{
					result = this.method_26(class103_0, childBlock, color_2, fieldDisplayMode_0, out var _, 0, bool_1, bool_2, bool_3: true);
					if (result != SubTextPartCollection.AddResult.Successful)
					{
						return result;
					}
				}
			}
			item.Select(num2, item.Columns.Count, num2, item.Columns.Count);
			class103_0.Selection_0 = new Selection(class103_0.Selection_0.Start + class103_0.Selection_0.Length, 0);
			return result;
		}

		private bool method_28(DataTableInfo dataTableInfo_1)
		{
			bool flag = false;
			foreach (DataTableInfo dataTable in this.DataTables)
			{
				using (IEnumerator<DataTableInfo> enumerator2 = dataTable.ChildTables.GetEnumerator())
				{
					if (enumerator2.MoveNext())
					{
						DataTableInfo current = enumerator2.Current;
						if (string.Equals(dataTableInfo_1.TableName, current.TableName, StringComparison.OrdinalIgnoreCase))
						{
							flag = true;
						}
					}
				}
				if (flag)
				{
					return flag;
				}
			}
			return flag;
		}

		private MergeField method_29(Class103 class103_0, string string_2, FieldDisplayMode fieldDisplayMode_0, bool bool_1)
		{
			MergeField mergeField = this.method_30(string_2, fieldDisplayMode_0, bool_1);
			class103_0.ApplicationFieldCollection_0.Add(mergeField.ApplicationField);
			return mergeField;
		}

		private MergeField method_30(string string_2, FieldDisplayMode fieldDisplayMode_0, bool bool_1)
		{
			MergeField mergeField = new MergeField();
			mergeField.ApplicationField.DoubledInputPosition = true;
			mergeField.ApplicationField.Editable = false;
			mergeField.ApplicationField.HighlightMode = ((!bool_1) ? HighlightMode.Never : HighlightMode.Always);
			if (string_2 != string.Empty)
			{
				mergeField.Name = string_2;
				switch (fieldDisplayMode_0)
				{
				case FieldDisplayMode.ShowFieldCodes:
				{
					string text = ((mergeField.ApplicationField.Parameters != null) ? string.Join(" ", mergeField.ApplicationField.Parameters) : "");
					mergeField.Text = "{" + mergeField.TypeName + text + " }";
					break;
				}
				case FieldDisplayMode.ShowFieldText:
					mergeField.Text = "«" + string_2 + "»";
					break;
				}
			}
			return mergeField;
		}

		private void method_31(TableCell tableCell_0, Color color_2, int int_2)
		{
			TableCellFormat tableCellFormat2 = (tableCell_0.CellFormat = new TableCellFormat
			{
				BackColor = color_2,
				LeftTextDistance = 100,
				RightTextDistance = 100,
				TopTextDistance = int_2,
				BottomTextDistance = int_2,
				LeftBorderWidth = 30,
				TopBorderWidth = 30,
				RightBorderWidth = 30,
				BottomBorderWidth = 30,
				LeftBorderColor = Color.White,
				TopBorderColor = Color.White,
				RightBorderColor = Color.White,
				BottomBorderColor = Color.White
			});
		}

		private static int smethod_0(Class103 class103_0)
		{
			new Random();
			List<int> list = new List<int>();
			foreach (Table item in class103_0.TableCollection_0)
			{
				if (item.Int32_0 != 0)
				{
					list.Add(item.Int32_0);
				}
			}
			int num = DataSourceManager.smethod_1();
			if (list.Count > 0)
			{
				while (list.Contains(num))
				{
					num = DataSourceManager.smethod_1();
				}
			}
			return num;
		}

		private static int smethod_1()
		{
			return new Random().Next(10, 32767);
		}

		private void method_32(DataTableInfo dataTableInfo_1, DataTableInfoCollection dataTableInfoCollection_2)
		{
			foreach (DataTableInfo childTable in dataTableInfo_1.ChildTables)
			{
				if (!dataTableInfoCollection_2.method_3(childTable))
				{
					dataTableInfoCollection_2.method_0(childTable);
					this.method_32(childTable, dataTableInfoCollection_2);
				}
			}
		}

		private MailMerge method_33(byte[] byte_0, object object_0)
		{
			this.int_1 = 0;
			MailMerge mailMerge = new MailMerge();
			mailMerge.TextComponent = object_0;
			mailMerge.LoadTemplateFromMemory(byte_0, FileFormat.InternalUnicodeFormat);
			mailMerge.RemoveEmptyImages = true;
			mailMerge.RemoveEmptyLines = true;
			mailMerge.DataRowMerged += method_9;
			return mailMerge;
		}

		internal void method_34(string string_2, string string_3, int int_2)
		{
			if (this.enum28_0 != Enum28.const_5)
			{
				throw new Exception(Resources.EXC_DATASOURCEMGR_SAVE_EXCERPT_NOT_POSSIBLE);
			}
			DataSet dataSet = this.class99_0.GetDataSet().Clone();
			this.dictionary_0 = new Dictionary<string, List<DataRow>>();
			this.method_37(dataSet);
			DataTable table = this.class99_0.GetTable(string_3);
			DataTable dataTable = dataSet.Tables[table.TableName];
			foreach (DataRow row in table.Rows)
			{
				dataTable.ImportRow(row);
				this.method_38(row, dataSet);
				int_2--;
				if (int_2 == 0)
				{
					break;
				}
			}
			this.dictionary_0.Clear();
			this.dictionary_0 = null;
			dataSet.WriteXml(string_2, XmlWriteMode.WriteSchema);
		}

		private bool? method_35(out string string_2, object object_0)
		{
			string_2 = "";
			Class105 @class = new Class105
			{
				String_0 = "Report Data Source Configuration (*.rdsc)|*.rdsc",
				Boolean_0 = true,
				Boolean_1 = true
			};
			if (@class.method_0(object_0))
			{
				string_2 = @class.String_1;
				return true;
			}
			return false;
		}

		private bool? method_36(out string string_2, object object_0)
		{
			string_2 = "";
			Class104 @class = new Class104
			{
				String_0 = "Report Data Source Configuration (*.rdsc)|*.rdsc",
				Boolean_0 = false,
				Boolean_1 = true
			};
			if (@class.method_0(object_0))
			{
				string_2 = @class.String_1;
				return true;
			}
			return false;
		}

		private void method_37(DataSet dataSet_1)
		{
			foreach (DataRelation dataRelation in this.class99_0.DataRelations)
			{
				DataTable dataTable = dataSet_1.Tables[dataRelation.ParentTable.TableName];
				DataTable dataTable2 = dataSet_1.Tables[dataRelation.ChildTable.TableName];
				List<DataColumn> list = new List<DataColumn>();
				List<DataColumn> list2 = new List<DataColumn>();
				DataColumn[] parentColumns = dataRelation.ParentColumns;
				foreach (DataColumn dataColumn in parentColumns)
				{
					list.Add(dataTable.Columns[dataColumn.ColumnName]);
				}
				parentColumns = dataRelation.ChildColumns;
				foreach (DataColumn dataColumn2 in parentColumns)
				{
					list2.Add(dataTable2.Columns[dataColumn2.ColumnName]);
				}
				try
				{
					dataSet_1.Relations.Add(new DataRelation(dataRelation.RelationName, list.ToArray(), list2.ToArray(), createConstraints: false));
				}
				catch
				{
				}
			}
		}

		private void method_38(DataRow dataRow_0, DataSet dataSet_1)
		{
			foreach (DataRelation childRelation in dataRow_0.Table.ChildRelations)
			{
				DataTable dataTable = dataSet_1.Tables[childRelation.ChildTable.TableName];
				if (!this.dictionary_0.ContainsKey(dataTable.TableName))
				{
					this.dictionary_0[dataTable.TableName] = new List<DataRow>();
				}
				List<DataRow> list = this.dictionary_0[dataTable.TableName];
				DataRow[] childRows = dataRow_0.GetChildRows(childRelation);
				foreach (DataRow dataRow in childRows)
				{
					if (!list.Contains(dataRow))
					{
						try
						{
							dataTable.ImportRow(dataRow);
							list.Add(dataRow);
							this.method_38(dataRow, dataSet_1);
						}
						catch
						{
						}
					}
				}
			}
		}

		private void method_39(SubTextPartCollection.AddResult addResult_0)
		{
			switch (addResult_0)
			{
			case SubTextPartCollection.AddResult.Error:
				throw new Exception(Resources.EXC_BLOCK_UNKNOWN_ERROR);
			case SubTextPartCollection.AddResult.NoSelection:
				throw new Exception(Resources.EXC_BLOCK_NO_SELECTION);
			case SubTextPartCollection.AddResult.SelectionTooComplex:
				throw new Exception(Resources.EXC_BLOCK_SELECTION_TOO_COMPLEX);
			case SubTextPartCollection.AddResult.PositionInvalid:
				throw new Exception(Resources.EXC_BLOCK_POSITION_INVALID);
			case SubTextPartCollection.AddResult.AlreadyExists:
				throw new Exception(Resources.EXC_BLOCK_ALREADY_EXISTS);
			case SubTextPartCollection.AddResult.Overlapping:
				throw new Exception(Resources.EXC_BLOCK_OVERLAPPING);
			}
		}

		static DataSourceManager()
		{
			DataSourceManager.color_0 = Color.FromArgb(255, 57, 131, 197);
			DataSourceManager.color_1 = Color.FromArgb(255, 230, 230, 230);
		}

		/// <summary>Initializes a new instance of the DataSourceManager class.</summary>
		public DataSourceManager()
		{
			this.method_1();
		}
	}
}
