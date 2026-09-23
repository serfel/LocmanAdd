using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;
using TXTextControl;
using TXTextControl.DocumentServer;
using DocumentServer.DataSources;
using DocumentServer.Fields;
using TXTextControl.Windows.Forms;

namespace ns26
{
	internal class TXITEM_MainPanel : ContentPanel
	{
		internal class Class579
		{
			private List<MergeField> list_0;

			private List<Class579> list_1;

			private Class579 class579_0;

			private SubTextPart subTextPart_0;

			private TextControl textControl_0;

			private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

			public string String_0
			{
				get
				{
					if (this.subTextPart_0 == null)
					{
						return string.Empty;
					}
					return this.subTextPart_0.Name.Substring(MailMerge.MergeBlockNamePrefix.Length);
				}
				set
				{
					if (this.subTextPart_0 != null)
					{
						if (string.IsNullOrEmpty(value))
						{
							throw new Exception(this.resourceManager_0.GetString("ERR_FIELDNAVIGATOR_EMPTY_BLOCK_NAME"));
						}
						this.subTextPart_0.Name = MailMerge.MergeBlockNamePrefix + value;
					}
				}
			}

			public IList<Class579> IList_0 => new ReadOnlyCollection<Class579>(this.list_1);

			public IList<MergeField> IList_1 => new ReadOnlyCollection<MergeField>(this.list_0);

			public SubTextPart SubTextPart_0 => this.subTextPart_0;

			public static IComparer<Class579> IComparer_0 => new Class581();

			public static IComparer<Class579> IComparer_1 => new Class580();

			public int Int32_0
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

			public int Int32_1
			{
				get
				{
					if (this.subTextPart_0 == null)
					{
						return 0;
					}
					return this.subTextPart_0.Start + this.subTextPart_0.Length;
				}
			}

			public int Int32_2
			{
				get
				{
					if (this.subTextPart_0 == null)
					{
						return 0;
					}
					return this.subTextPart_0.Length;
				}
			}

			public Class579(IList<SubTextPart> ilist_0, ref int int_0, TextControl textControl_1, Class579 class579_1)
			{
				this.subTextPart_0 = ilist_0[int_0++];
				this.textControl_0 = textControl_1;
				this.list_0 = new List<MergeField>();
				this.list_1 = new List<Class579>();
				this.class579_0 = class579_1;
				while (int_0 < ilist_0.Count && ilist_0[int_0].Start < this.Int32_1)
				{
					this.list_1.Add(new Class579(ilist_0, ref int_0, textControl_1, this));
				}
				this.method_3(textControl_1);
			}

			public Class579(SubTextPart subTextPart_1, TextControl textControl_1)
			{
				this.subTextPart_0 = subTextPart_1;
				this.textControl_0 = textControl_1;
				this.list_0 = new List<MergeField>();
				this.list_1 = new List<Class579>();
			}

			internal static IList<Class579> smethod_0(TextControl textControl_1)
			{
				List<Class579> list = new List<Class579>();
				if (textControl_1.SubTextParts.Count == 0)
				{
					return list;
				}
				List<SubTextPart> list2 = new List<SubTextPart>();
				foreach (SubTextPart subTextPart in textControl_1.SubTextParts)
				{
					if (!string.IsNullOrEmpty(subTextPart.Name) && subTextPart.Name.StartsWith(MailMerge.MergeBlockNamePrefix, StringComparison.OrdinalIgnoreCase))
					{
						list2.Add(subTextPart);
					}
				}
				int int_ = 0;
				while (int_ < list2.Count)
				{
					list.Add(new Class579(list2, ref int_, textControl_1, null));
				}
				return list;
			}

			internal bool method_0(TextControl textControl_1)
			{
				string string_ = this.String_0;
				bool result = false;
				UserPromptDialog userPromptDialog = new UserPromptDialog(this.resourceManager_0.GetString("ID_FIELDNAVIGATOR_MERGE_BLOCK_NAME_TITLE"), this.resourceManager_0.GetString("ID_FIELDNAVIGATOR_MERGE_BLOCK_NAME_LABEL"), string_);
				if (userPromptDialog.ShowDialog(textControl_1) == System.Windows.Forms.DialogResult.OK)
				{
					this.String_0 = userPromptDialog.Value;
					result = true;
				}
				return result;
			}

			internal void method_1(TreeNode treeNode_0)
			{
				foreach (MergeField item in this.list_0)
				{
					TreeNode treeNode = new TreeNode(item.Name, 0, 0);
					treeNode.Tag = item;
					treeNode_0.Nodes.Add(treeNode);
				}
				foreach (Class579 item2 in this.list_1)
				{
					TreeNode treeNode2 = new TreeNode(item2.String_0, 1, 1);
					treeNode2.Tag = item2;
					item2.method_1(treeNode2);
					treeNode_0.Nodes.Add(treeNode2);
				}
			}

			internal void method_2()
			{
				if (this.subTextPart_0 != null)
				{
					this.subTextPart_0.ScrollTo();
				}
			}

			private void method_3(TextControl textControl_1)
			{
				List<MergeField> list = new List<MergeField>();
				foreach (ApplicationField applicationField in textControl_1.ApplicationFields)
				{
					int num = applicationField.Start + applicationField.Length;
					if (applicationField.Start >= this.Int32_0 && num <= this.Int32_1)
					{
						MergeField mergeField = applicationField.ToFieldAdapter();
						if (mergeField != null)
						{
							list.Add(mergeField);
						}
					}
				}
				foreach (MergeField item in list)
				{
					if (!item.ApplicationField.IsInside(this.list_1))
					{
						this.list_0.Add(item);
					}
				}
			}
		}

		private TableLayoutPanel tableLayoutPanel_0;

		private TextBox textBox_0;

		private System.Windows.Forms.Button button_0;

		private TabControl tabControl_0;

		private TableLayoutPanel tableLayoutPanel_1;

		private System.Windows.Forms.Button button_1;

		private System.Windows.Forms.Button button_2;

		private TabPage tabPage_0;

		private TreeView treeView_0;

		private TabPage tabPage_1;

		private TreeView treeView_1;

		private string string_0 = "";

		private Color color_0;

		private ContextMenu contextMenu_0;

		private IEnumerator<TreeNode> ienumerator_0;

		private IEnumerator<TreeNode> ienumerator_1;

		private bool bool_0 = true;

		private bool bool_1;

		private EventHandler<EventArgs6> eventHandler_0;

		internal event EventHandler<EventArgs6> FieldChanged
		{
			add
			{
				EventHandler<EventArgs6> eventHandler = this.eventHandler_0;
				EventHandler<EventArgs6> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<EventArgs6> value2 = (EventHandler<EventArgs6>)Delegate.Combine(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
			remove
			{
				EventHandler<EventArgs6> eventHandler = this.eventHandler_0;
				EventHandler<EventArgs6> eventHandler2;
				do
				{
					eventHandler2 = eventHandler;
					EventHandler<EventArgs6> value2 = (EventHandler<EventArgs6>)Delegate.Remove(eventHandler2, value);
					eventHandler = Interlocked.CompareExchange(ref this.eventHandler_0, value2, eventHandler2);
				}
				while ((object)eventHandler != eventHandler2);
			}
		}

		internal TXITEM_MainPanel(Enum140 enum140_0, TextControl textControl_0, bool bool_2, Sidebar.SidebarContentLayout sidebarContentLayout_0, PointF pointF_0)
			: base(enum140_0, textControl_0, bool_2, sidebarContentLayout_0, pointF_0)
		{
			this.textBox_0.Text = base.m_rm.GetString("ID_FIELDNAVIGATOR_SEARCH");
			this.tabControl_0.SelectedIndexChanged += tabControl_0_SelectedIndexChanged;
			this.tabPage_0.Text = base.m_rm.GetString("ID_FIELDNAVIGATOR_MERGEBLOCKS");
			this.tabPage_1.Text = base.m_rm.GetString("ID_FIELDNAVIGATOR_MERGEFIELDS");
			this.button_1.Text = base.m_rm.GetString("ID_FIELDNAVIGATOR_REMOVE");
			this.button_2.Text = base.m_rm.GetString("ID_FIELDNAVIGATOR_PROPERTIES");
			this.method_12();
			this.treeView_0.ContextMenu = this.contextMenu_0;
			this.treeView_1.ContextMenu = this.contextMenu_0;
		}

		internal override void DoLayout()
		{
			this.tableLayoutPanel_0.ResumeLayout(performLayout: false);
			this.tableLayoutPanel_0.PerformLayout();
			this.tableLayoutPanel_1.ResumeLayout(performLayout: false);
			this.tableLayoutPanel_1.PerformLayout();
			this.tabControl_0.ResumeLayout(performLayout: false);
			this.tabControl_0.PerformLayout();
			base.ResumeLayout(performLayout: false);
			base.PerformLayout();
		}

		internal override void DoSuspendLayout()
		{
			base.SuspendLayout();
			this.tableLayoutPanel_0.SuspendLayout();
			this.tableLayoutPanel_1.SuspendLayout();
			this.tabControl_0.SuspendLayout();
		}

		internal override void InitializeItems()
		{
			this.tableLayoutPanel_0 = new TableLayoutPanel();
			this.textBox_0 = new TextBox();
			this.button_0 = new System.Windows.Forms.Button();
			this.tableLayoutPanel_1 = new TableLayoutPanel();
			this.button_1 = new System.Windows.Forms.Button();
			this.button_2 = new System.Windows.Forms.Button();
			this.tabControl_0 = new TabControl();
			this.tabPage_0 = new TabPage();
			this.tabPage_1 = new TabPage();
			this.treeView_0 = new TreeView();
			this.treeView_1 = new TreeView();
			base.SuspendLayout();
			this.tableLayoutPanel_0.SuspendLayout();
			this.tableLayoutPanel_1.SuspendLayout();
			this.tabControl_0.SuspendLayout();
			this.AutoSize = true;
			this.AutoSizeMode = AutoSizeMode.GrowOnly;
			base.ColumnCount = 1;
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			base.Controls.Add(this.tableLayoutPanel_0, 0, 0);
			base.Controls.Add(this.tabControl_0, 0, 1);
			base.Controls.Add(this.tableLayoutPanel_1, 0, 2);
			base.Name = "TXITEM_MainPanel";
			base.RowCount = 3;
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			base.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel_0.AutoSize = true;
			this.tableLayoutPanel_0.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel_0.BackColor = this.textBox_0.BackColor;
			this.tableLayoutPanel_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tableLayoutPanel_0.ColumnCount = 2;
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_0.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_0.Controls.Add(this.textBox_0, 0, 0);
			this.tableLayoutPanel_0.Controls.Add(this.button_0, 1, 0);
			this.tableLayoutPanel_0.Dock = DockStyle.Top;
			this.tableLayoutPanel_0.Name = "TXITEM_TextBoxPanel";
			this.tableLayoutPanel_0.RowCount = 2;
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel_0.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.textBox_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox_0.Dock = DockStyle.Top;
			this.textBox_0.ForeColor = Color.DarkGray;
			this.textBox_0.Name = Sidebar.FieldNavigatorItem.TXITEM_SearchTextBox.ToString();
			this.textBox_0.TabIndex = 0;
			this.textBox_0.Text = "Search Template";
			this.textBox_0.KeyUp += textBox_0_KeyUp;
			this.button_0.Dock = DockStyle.Right;
			this.button_0.Name = Sidebar.FieldNavigatorItem.TXITEM_SearchButton.ToString();
			this.button_0.ImageAlign = ContentAlignment.MiddleCenter;
			this.button_0.TabIndex = 1;
			this.button_0.Click += button_0_Click;
			this.tabControl_0.Controls.Add(this.tabPage_0);
			this.tabControl_0.Controls.Add(this.tabPage_1);
			this.tabControl_0.Dock = DockStyle.Fill;
			this.tabControl_0.Name = Sidebar.FieldNavigatorItem.TXITEM_MergeItems.ToString();
			this.tabControl_0.RightToLeftLayout = true;
			this.tabControl_0.SelectedIndex = 0;
			this.tabControl_0.TabIndex = 2;
			this.tabPage_0.Controls.Add(this.treeView_0);
			this.tabPage_0.Name = "TXITEM_TabPageBlocks";
			this.tabPage_0.Padding = new Padding(3);
			this.tabPage_0.TabIndex = 3;
			this.tabPage_0.Text = "MERGE BLOCKS";
			this.tabPage_0.UseVisualStyleBackColor = true;
			this.treeView_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.treeView_0.Dock = DockStyle.Fill;
			this.treeView_0.DrawMode = TreeViewDrawMode.OwnerDrawText;
			this.treeView_0.HideSelection = false;
			this.treeView_0.HotTracking = true;
			this.treeView_0.ImageIndex = 1;
			this.treeView_0.LabelEdit = true;
			this.treeView_0.Name = "TXITEM_TreeViewBlocks";
			this.treeView_0.SelectedImageIndex = 0;
			this.treeView_0.TabIndex = 4;
			this.treeView_0.AfterLabelEdit += treeView_1_AfterLabelEdit;
			this.treeView_0.DrawNode += treeView_1_DrawNode;
			this.treeView_0.NodeMouseClick += treeView_1_NodeMouseClick;
			this.treeView_0.NodeMouseDoubleClick += treeView_1_NodeMouseDoubleClick;
			this.treeView_0.KeyDown += treeView_1_KeyDown;
			this.treeView_0.KeyUp += treeView_1_KeyUp;
			this.treeView_0.MouseLeave += treeView_1_MouseLeave;
			this.treeView_0.MouseMove += treeView_1_MouseMove;
			if (base.DesignMode)
			{
				TreeNode treeNode = new TreeNode("company", 0, 0);
				TreeNode treeNode2 = new TreeNode("name", 0, 0);
				TreeNode treeNode3 = new TreeNode("Sales_SalesOrderHeader", 1, 1, new TreeNode[2] { treeNode, treeNode2 });
				TreeNode treeNode4 = new TreeNode("Sales_SalesOrderDetails");
				treeNode.ImageIndex = 0;
				treeNode.Name = "Node5";
				treeNode.SelectedImageIndex = 0;
				treeNode.Text = "company";
				treeNode2.ImageIndex = 0;
				treeNode2.Name = "Node6";
				treeNode2.SelectedImageIndex = 0;
				treeNode2.Text = "name";
				treeNode3.ImageIndex = 1;
				treeNode3.Name = "Node0";
				treeNode3.SelectedImageIndex = 1;
				treeNode3.Text = "Sales_SalesOrderHeader";
				treeNode4.Name = "Node1";
				treeNode4.SelectedImageIndex = 1;
				treeNode4.Text = "Sales_SalesOrderDetails";
				this.treeView_0.Nodes.AddRange(new TreeNode[2] { treeNode3, treeNode4 });
			}
			this.tabPage_1.Controls.Add(this.treeView_1);
			this.tabPage_1.Name = "TXITEM_TabPageFields";
			this.tabPage_1.Padding = new Padding(3);
			this.tabPage_1.TabIndex = 5;
			this.tabPage_1.Text = "MERGE FIELDS";
			this.tabPage_1.UseVisualStyleBackColor = true;
			this.treeView_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.treeView_1.Dock = DockStyle.Fill;
			this.treeView_1.DrawMode = TreeViewDrawMode.OwnerDrawText;
			this.treeView_1.HideSelection = false;
			this.treeView_1.HotTracking = true;
			this.treeView_1.ImageIndex = 0;
			this.treeView_1.LabelEdit = true;
			this.treeView_1.Name = "TXITEM_TreeViewFields";
			this.treeView_1.SelectedImageIndex = 0;
			this.treeView_1.TabIndex = 6;
			this.treeView_1.AfterLabelEdit += treeView_1_AfterLabelEdit;
			this.treeView_1.DrawNode += treeView_1_DrawNode;
			this.treeView_1.KeyDown += treeView_1_KeyDown;
			this.treeView_1.KeyUp += treeView_1_KeyUp;
			this.treeView_1.MouseLeave += treeView_1_MouseLeave;
			this.treeView_1.MouseMove += treeView_1_MouseMove;
			this.treeView_1.NodeMouseClick += treeView_1_NodeMouseClick;
			this.treeView_1.NodeMouseDoubleClick += treeView_1_NodeMouseDoubleClick;
			this.tableLayoutPanel_1.AutoSize = true;
			this.tableLayoutPanel_1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel_1.ColumnCount = 3;
			this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_1.ColumnStyles.Add(new ColumnStyle());
			this.tableLayoutPanel_1.Controls.Add(this.button_2, 2, 0);
			this.tableLayoutPanel_1.Controls.Add(this.button_1, 1, 0);
			this.tableLayoutPanel_1.Dock = DockStyle.Top;
			this.tableLayoutPanel_1.Name = "TXITEM_BottomPanel";
			this.tableLayoutPanel_1.RowCount = 2;
			this.tableLayoutPanel_1.RowStyles.Add(new RowStyle());
			this.tableLayoutPanel_1.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			this.button_1.AutoSize = true;
			this.button_1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.button_1.Dock = DockStyle.Top;
			this.button_1.Enabled = false;
			this.button_1.Name = Sidebar.FieldNavigatorItem.TXITEM_Remove.ToString();
			this.button_1.TabIndex = 7;
			this.button_1.Text = "Remove";
			this.button_1.UseVisualStyleBackColor = true;
			this.button_1.Click += button_1_Click;
			this.button_2.AutoSize = true;
			this.button_2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.button_2.Dock = DockStyle.Top;
			this.button_2.Enabled = false;
			this.button_2.Name = Sidebar.FieldNavigatorItem.TXITEM_Properties.ToString();
			this.button_2.TabIndex = 8;
			this.button_2.Text = "Properties…";
			this.button_2.UseVisualStyleBackColor = true;
			this.button_2.Click += button_2_Click;
			this.tableLayoutPanel_0.ResumeLayout(performLayout: false);
			this.tableLayoutPanel_0.PerformLayout();
			this.tableLayoutPanel_1.ResumeLayout(performLayout: false);
			this.tableLayoutPanel_1.PerformLayout();
			this.tabControl_0.ResumeLayout(performLayout: false);
			this.tabControl_0.PerformLayout();
			base.ResumeLayout(performLayout: false);
			base.PerformLayout();
			base.m_dicItems.Add(this.textBox_0.Name, this.textBox_0);
			base.m_dicItems.Add(this.button_0.Name, this.button_0);
			base.m_dicItems.Add(this.tabControl_0.Name, this.tabControl_0);
			base.m_dicItems.Add(this.button_1.Name, this.button_1);
			base.m_dicItems.Add(this.button_2.Name, this.button_2);
		}

		internal override void AwareOfDPI_Intialize()
		{
			if (!base.m_pntDpi.IsEmpty)
			{
				bool flag = this.treeView_0.ImageList != null;
				ImageList imageList = new ImageList();
				imageList.ImageSize = Class517.smethod_48(Class519.Class521.Size_1, base.m_pntDpi);
				imageList.Images.Add(Class517.Bitmap_12);
				imageList.Images.Add(Class517.Bitmap_13);
				imageList.Images.SetKeyName(0, "FieldNavigatorNodeField");
				imageList.Images.SetKeyName(1, "FieldNavigatorNodeBlock");
				imageList.TransparentColor = Color.Transparent;
				this.treeView_0.ImageList = imageList;
				this.treeView_1.ImageList = imageList;
				if (flag)
				{
					this.treeView_1.CheckBoxes = true;
					this.treeView_1.CheckBoxes = false;
					this.treeView_0.CheckBoxes = true;
					this.treeView_0.CheckBoxes = false;
				}
				this.tabControl_0.Dock = DockStyle.None;
				this.tabControl_0.Size = Size.Empty;
				this.tabControl_0.Dock = DockStyle.Fill;
				this.textBox_0.Margin = Class517.smethod_51(Class519.Class542.Class549.Padding_3, base.m_pntDpi);
				this.button_0.Image = Class517.smethod_55(this.button_0.Name, ImageProvider.ImageKind.Small_16x16, Class517.smethod_48(Class519.Class542.Class549.Size_3, base.m_pntDpi), base.m_pntDpi);
				this.button_0.Margin = Class517.smethod_51(Class519.Class542.Class549.Padding_2, base.m_pntDpi);
				Size size3 = (this.button_0.MinimumSize = (this.button_0.MaximumSize = Class517.smethod_48(Class519.Class542.Class549.Size_2, base.m_pntDpi)));
				this.button_1.Margin = Class517.smethod_51(Class519.Class542.Class549.Padding_0, base.m_pntDpi);
				this.button_1.MinimumSize = Class517.smethod_48(Class519.Class542.Class549.Size_0, base.m_pntDpi);
				this.button_2.Margin = Class517.smethod_51(Class519.Class542.Class549.Padding_1, base.m_pntDpi);
				this.button_2.MinimumSize = Class517.smethod_48(Class519.Class542.Class549.Size_1, base.m_pntDpi);
				this.tabControl_0.Margin = Class517.smethod_51(Class519.Class542.Class549.Padding_6, base.m_pntDpi);
			}
		}

		internal override void AwareOfDPI_Horizontal()
		{
			Size size = Class517.smethod_48(Class519.Class542.Class549.Size_5, base.m_pntDpi);
			this.tabControl_0.MinimumSize = size;
			this.tabControl_0.MaximumSize = size;
			this.tabControl_0.MaximumSize = new Size(int.MaxValue, int.MaxValue);
			base.AwareOfDPI_Horizontal();
		}

		internal override void AwareOfDPI_Vertical()
		{
			Size size = Class517.smethod_48(Class519.Class542.Class549.Size_6, base.m_pntDpi);
			this.tabControl_0.MinimumSize = size;
			this.tabControl_0.MaximumSize = size;
			this.tabControl_0.MaximumSize = new Size(int.MaxValue, int.MaxValue);
			base.AwareOfDPI_Horizontal();
		}

		internal override void AwareOfDPI_Dialog()
		{
			Size size = Class517.smethod_48(Class519.Class542.Class549.Size_4, base.m_pntDpi);
			this.tabControl_0.MinimumSize = size;
			this.tabControl_0.MaximumSize = size;
			this.tabControl_0.MaximumSize = new Size(int.MaxValue, int.MaxValue);
			base.AwareOfDPI_Dialog();
		}

		internal override void SetDialogAlignment()
		{
			this.method_11();
			base.SetDialogAlignment();
		}

		internal override void SetHorizontalAlignment()
		{
			this.method_11();
			base.SetHorizontalAlignment();
		}

		internal override void SetVerticalAlignment()
		{
			this.method_11();
			base.SetVerticalAlignment();
		}

		internal override void UpdateTextControlBindings(TextControl oldTextcontrol, TextControl newTextControl)
		{
			if (oldTextcontrol != null)
			{
				oldTextcontrol.DocumentLoaded -= method_0;
				oldTextcontrol.ContentsReset -= method_0;
				oldTextcontrol.TextFieldDeleted -= method_3;
				oldTextcontrol.TextFieldCreated -= method_2;
				oldTextcontrol.SubTextPartDeleted -= method_1;
				oldTextcontrol.SubTextPartCreated -= method_1;
				oldTextcontrol.TextFieldEntered -= method_4;
				oldTextcontrol.TextFieldLeft -= method_5;
				oldTextcontrol.SubTextPartEntered -= method_6;
				oldTextcontrol.SubTextPartLeft -= method_7;
			}
			if (newTextControl != null)
			{
				newTextControl.DocumentLoaded += method_0;
				newTextControl.ContentsReset += method_0;
				newTextControl.TextFieldDeleted += method_3;
				newTextControl.TextFieldCreated += method_2;
				newTextControl.SubTextPartDeleted += method_1;
				newTextControl.SubTextPartCreated += method_1;
				newTextControl.TextFieldEntered += method_4;
				newTextControl.TextFieldLeft += method_5;
				newTextControl.SubTextPartEntered += method_6;
				newTextControl.SubTextPartLeft += method_7;
			}
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			base.OnHandleCreated(eventArgs_0);
			this.string_0 = this.textBox_0.Text;
			this.color_0 = this.textBox_0.ForeColor;
			if (base.IsSidebarShown)
			{
				this.method_13();
			}
		}

		internal override void UpdateContent()
		{
			this.method_13();
		}

		protected override void OnContentPanelGotFocus()
		{
			if (base.TextControl != null)
			{
				this.bool_1 = true;
				this.bool_0 = base.TextControl.HideSelection;
				base.TextControl.HideSelection = false;
			}
			base.OnContentPanelGotFocus();
		}

		protected override void OnContentPanelLostFocus()
		{
			if (base.TextControl != null)
			{
				this.bool_1 = false;
				base.TextControl.HideSelection = this.bool_0;
			}
			base.OnContentPanelLostFocus();
		}

		protected override void OnControlActivated(EventArgs4 eventArgs4_0)
		{
			if (eventArgs4_0.Control_0 == this.textBox_0)
			{
				string text = this.textBox_0.Text;
				if (text.ToLower() == this.string_0.ToLower())
				{
					this.textBox_0.Text = "";
					this.textBox_0.ForeColor = Color.Black;
				}
			}
			base.OnControlActivated(eventArgs4_0);
		}

		protected override void OnControlDeactivated(EventArgs5 eventArgs5_0)
		{
			if (eventArgs5_0.Control_0 == this.textBox_0)
			{
				string text = this.textBox_0.Text;
				if (text.Trim() == "")
				{
					this.textBox_0.ForeColor = this.color_0;
					this.textBox_0.Text = this.string_0;
				}
			}
			base.OnControlDeactivated(eventArgs5_0);
		}

		private void tabControl_0_SelectedIndexChanged(object sender, EventArgs e)
		{
			System.Windows.Forms.Button button = this.button_1;
			bool enabled = (this.button_2.Enabled = ((this.tabControl_0.SelectedIndex == 0) ? (this.treeView_0.SelectedNode != null) : (this.treeView_1.SelectedNode != null)));
			button.Enabled = enabled;
		}

		private void method_0(object sender, EventArgs e)
		{
			if (base.IsSidebarShown)
			{
				this.method_13();
			}
		}

		private void method_1(object sender, EventArgs e)
		{
			if (base.IsSidebarShown && !this.bool_1)
			{
				this.method_13();
			}
		}

		private void method_2(object sender, TextFieldEventArgs e)
		{
			if (base.IsSidebarShown)
			{
				ApplicationField applicationField = e.TextField as ApplicationField;
				if (applicationField != null && applicationField.ToFieldAdapter() != null && !this.bool_1)
				{
					this.method_13();
				}
			}
		}

		private void method_3(object sender, TextFieldEventArgs e)
		{
			if (base.IsSidebarShown)
			{
				ApplicationField applicationField = e.TextField as ApplicationField;
				if (applicationField != null && !this.bool_1)
				{
					this.method_13();
				}
			}
		}

		private void method_4(object sender, TextFieldEventArgs e)
		{
			if (base.IsSidebarShown && !this.bool_1)
			{
				this.method_31(e.TextField as ApplicationField);
			}
		}

		private void method_5(object sender, TextFieldEventArgs e)
		{
			if (base.IsSidebarShown && !this.bool_1)
			{
				this.method_38(null, bool_2: false);
			}
		}

		private void method_6(object sender, SubTextPartEventArgs e)
		{
			if (base.IsSidebarShown && !this.bool_1)
			{
				this.method_38(e.SubTextPart, bool_2: false);
			}
		}

		private void method_7(object sender, SubTextPartEventArgs e)
		{
			if (base.IsSidebarShown && !this.bool_1)
			{
				this.treeView_0.SelectedNode = null;
				System.Windows.Forms.Button button = this.button_2;
				this.button_1.Enabled = false;
				button.Enabled = false;
			}
		}

		private void method_8(object sender, EventArgs e)
		{
			this.method_21();
		}

		private void method_9(object sender, EventArgs e)
		{
			this.method_17();
		}

		private void button_2_Click(object sender, EventArgs e)
		{
			this.method_21();
		}

		private void button_1_Click(object sender, EventArgs e)
		{
			this.method_17();
			this.bool_1 = false;
		}

		private void button_0_Click(object sender, EventArgs e)
		{
			this.method_29();
		}

		private void textBox_0_KeyUp(object sender, KeyEventArgs e)
		{
			Keys keyCode = e.KeyCode;
			if (keyCode == Keys.Return)
			{
				this.method_29();
			}
			else
			{
				this.ienumerator_0 = (this.ienumerator_1 = null);
			}
		}

		private void treeView_1_DrawNode(object sender, DrawTreeNodeEventArgs e)
		{
			if (e.Node != null)
			{
				if ((e.State & TreeNodeStates.Selected) == TreeNodeStates.Selected)
				{
					e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds);
					TextRenderer.DrawText(e.Graphics, e.Node.Text, e.Node.TreeView.Font, e.Bounds, SystemColors.HighlightText, TextFormatFlags.Default);
				}
				else if ((e.State & TreeNodeStates.Hot) == TreeNodeStates.Hot)
				{
					TextRenderer.DrawText(e.Graphics, e.Node.Text, new System.Drawing.Font(e.Node.TreeView.Font, FontStyle.Underline), e.Bounds, SystemColors.Highlight, TextFormatFlags.Default);
				}
				else
				{
					e.DrawDefault = true;
				}
			}
		}

		private void treeView_1_KeyDown(object sender, KeyEventArgs e)
		{
			TreeView treeView = sender as TreeView;
			if (treeView.SelectedNode != null && treeView.SelectedNode != null)
			{
				switch (e.KeyCode)
				{
				case Keys.F2:
					treeView.SelectedNode.BeginEdit();
					break;
				case Keys.Delete:
					this.method_18(treeView.SelectedNode);
					break;
				case Keys.Return:
					this.method_22(treeView.SelectedNode);
					break;
				}
			}
		}

		private void treeView_1_KeyUp(object sender, KeyEventArgs e)
		{
			TreeView treeView = sender as TreeView;
			if (treeView.SelectedNode != null && treeView.SelectedNode != null)
			{
				switch (e.KeyCode)
				{
				case Keys.Up:
				case Keys.Down:
					this.method_25(treeView.SelectedNode);
					break;
				case Keys.Right:
					break;
				}
			}
		}

		private void treeView_1_MouseLeave(object sender, EventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		private void treeView_1_MouseMove(object sender, MouseEventArgs e)
		{
			TreeView treeView = sender as TreeView;
			TreeViewHitTestInfo treeViewHitTestInfo = treeView.HitTest(e.X, e.Y);
			TreeViewHitTestLocations location = treeViewHitTestInfo.Location;
			if (location == TreeViewHitTestLocations.Label)
			{
				this.Cursor = ((base.TextControl == null || !base.TextControl.textControlCore_0.isHandleCreated) ? Cursors.Hand : base.TextControl.cursor_5);
			}
			else
			{
				this.Cursor = Cursors.Default;
			}
		}

		private void treeView_1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			this.method_25(e.Node);
		}

		private void treeView_1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Node.Tag is MergeField)
			{
				this.method_22(e.Node);
			}
		}

		private void treeView_1_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
		{
			if (string.IsNullOrEmpty(e.Label))
			{
				e.CancelEdit = true;
				return;
			}
			Class579 @class = e.Node.Tag as Class579;
			if (@class != null)
			{
				@class.String_0 = e.Label;
				return;
			}
			MergeField mergeField = e.Node.Tag as MergeField;
			if (mergeField != null)
			{
				mergeField.Name = e.Label;
				this.method_10(new EventArgs6(mergeField));
			}
		}

		private void method_10(EventArgs6 eventArgs6_0)
		{
			if (this.eventHandler_0 != null)
			{
				this.eventHandler_0(this, eventArgs6_0);
			}
		}

		private void method_11()
		{
			base.Controls.Clear();
			base.ColumnStyles.Clear();
			base.RowStyles.Clear();
			this.AutoSize = true;
			this.AutoSizeMode = AutoSizeMode.GrowOnly;
			base.ColumnCount = 1;
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			base.Controls.Add(this.tableLayoutPanel_0, 0, 0);
			base.Controls.Add(this.tabControl_0, 0, 1);
			base.Controls.Add(this.tableLayoutPanel_1, 0, 2);
			base.Name = "TXITEM_MainPanel";
			base.RowCount = 3;
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			base.RowStyles.Add(new RowStyle());
			base.TabIndex = 0;
		}

		private void method_12()
		{
			MenuItem[] menuItems = new MenuItem[2]
			{
				new MenuItem(base.m_rm.GetString("ID_FIELDNAVIGATOR_PROPERTIES"), method_8),
				new MenuItem(base.m_rm.GetString("ID_FIELDNAVIGATOR_REMOVE"), method_9)
			};
			this.contextMenu_0 = new ContextMenu(menuItems);
		}

		internal void method_13()
		{
			if (base.IsSidebarShown && base.TextControl != null && base.TextControl.textControlCore_0.isHandleCreated && !base.m_bIsDesignMode)
			{
				List<Class579> list = new List<Class579>();
				list.AddRange(Class579.smethod_0(base.TextControl));
				List<MergeField> list_ = TXITEM_MainPanel.smethod_0(base.TextControl, list);
				this.method_14(list, list_);
			}
		}

		private void method_14(List<Class579> list_0, List<MergeField> list_1)
		{
			int count = this.treeView_0.Nodes.Count;
			int count2 = this.treeView_1.Nodes.Count;
			this.treeView_0.Nodes.Clear();
			this.treeView_1.Nodes.Clear();
			this.method_16(list_0);
			this.method_15(list_1);
			this.treeView_0.ExpandAll();
			this.treeView_1.ExpandAll();
			if (count != this.treeView_0.Nodes.Count)
			{
				this.tabControl_0.SelectedIndex = 0;
			}
			else if (count2 != this.treeView_1.Nodes.Count)
			{
				this.tabControl_0.SelectedIndex = 1;
			}
			else if (this.treeView_0.Nodes.Count == 0)
			{
				this.tabControl_0.SelectedIndex = 1;
			}
			this.method_38(null, bool_2: true);
		}

		private void method_15(List<MergeField> list_0)
		{
			foreach (MergeField item in list_0)
			{
				TreeNode treeNode = new TreeNode(item.Name, 0, 0);
				treeNode.Tag = item;
				this.treeView_1.Nodes.Add(treeNode);
			}
		}

		private void method_16(List<Class579> list_0)
		{
			foreach (Class579 item in list_0)
			{
				TreeNode treeNode = new TreeNode(item.String_0, 1, 1);
				treeNode.Tag = item;
				item.method_1(treeNode);
				this.treeView_0.Nodes.Add(treeNode);
			}
		}

		private void method_17()
		{
			TreeNode treeNode = null;
			switch (this.tabControl_0.SelectedIndex)
			{
			case 0:
				treeNode = this.treeView_0.SelectedNode;
				break;
			case 1:
				treeNode = this.treeView_1.SelectedNode;
				break;
			}
			if (treeNode != null)
			{
				this.method_18(treeNode);
			}
		}

		private void method_18(TreeNode treeNode_0)
		{
			MergeField mergeField = treeNode_0.Tag as MergeField;
			if (mergeField != null)
			{
				this.method_19(mergeField);
				return;
			}
			Class579 @class = treeNode_0.Tag as Class579;
			if (@class != null)
			{
				this.method_20(@class, bool_2: true);
			}
		}

		private void method_19(MergeField mergeField_0)
		{
			base.TextControl.ApplicationFields.Remove(mergeField_0.ApplicationField, keepText: false);
			this.method_13();
		}

		private void method_20(Class579 class579_0, bool bool_2)
		{
			if (class579_0.IList_0.Count > 0 || class579_0.IList_1.Count > 0)
			{
				if (bool_2 && MessageBox.Show(base.m_rm.GetString("MSG_FIELDNAVIGATOR_MERGE_BLOCK_NOT_EMPTY"), base.m_rm.GetString("MSG_FIELDNAVIGATOR_MERGE_BLOCK_NOT_EMPTY_CAPTION"), MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != System.Windows.Forms.DialogResult.OK)
				{
					return;
				}
				foreach (MergeField item in class579_0.IList_1)
				{
					base.TextControl.ApplicationFields.Remove(item.ApplicationField);
				}
				foreach (Class579 item2 in class579_0.IList_0)
				{
					this.method_20(item2, bool_2: false);
				}
			}
			base.TextControl.SubTextParts.Remove(class579_0.SubTextPart_0, keepText: true, keepNested: false);
			if (bool_2)
			{
				this.method_13();
			}
		}

		private void method_21()
		{
			TreeNode treeNode = null;
			switch (this.tabControl_0.SelectedIndex)
			{
			case 0:
				treeNode = this.treeView_0.SelectedNode;
				break;
			case 1:
				treeNode = this.treeView_1.SelectedNode;
				break;
			}
			if (treeNode != null)
			{
				this.method_22(treeNode);
			}
		}

		private void method_22(TreeNode treeNode_0)
		{
			MergeField mergeField = treeNode_0.Tag as MergeField;
			if (mergeField != null)
			{
				this.method_23(treeNode_0, mergeField);
				return;
			}
			Class579 @class = treeNode_0.Tag as Class579;
			if (@class != null)
			{
				this.method_24(treeNode_0, @class);
			}
		}

		private void method_23(TreeNode treeNode_0, MergeField mergeField_0)
		{
			if (mergeField_0.ShowDialog(base.TextControl) == DocumentServer.Fields.DialogResult.OK)
			{
				treeNode_0.Text = mergeField_0.Name;
				this.method_10(new EventArgs6(mergeField_0));
			}
		}

		private void method_24(TreeNode treeNode_0, Class579 class579_0)
		{
			if (class579_0.method_0(base.TextControl))
			{
				treeNode_0.Text = class579_0.String_0;
			}
		}

		private void method_25(TreeNode treeNode_0)
		{
			MergeField mergeField = treeNode_0.Tag as MergeField;
			if (mergeField != null)
			{
				this.method_27(mergeField);
			}
			else
			{
				Class579 @class = treeNode_0.Tag as Class579;
				if (@class != null)
				{
					this.method_26(@class);
				}
			}
			System.Windows.Forms.Button button = this.button_2;
			this.button_1.Enabled = true;
			button.Enabled = true;
		}

		private void method_26(Class579 class579_0)
		{
			this.treeView_1.SelectedNode = null;
			class579_0.method_2();
			base.TextControl.InputPosition = new InputPosition(class579_0.SubTextPart_0.Start - 1);
		}

		private void method_27(MergeField mergeField_0)
		{
			if (this.tabControl_0.SelectedIndex == 0)
			{
				this.treeView_1.SelectedNode = null;
			}
			else
			{
				this.treeView_0.SelectedNode = null;
			}
			mergeField_0.ApplicationField.ScrollTo();
			base.TextControl.Select(mergeField_0.Start - 1, mergeField_0.Length);
		}

		private void method_28(object object_0)
		{
			Class579 @class = object_0 as Class579;
			if (@class != null)
			{
				this.method_26(@class);
				return;
			}
			MergeField mergeField = object_0 as MergeField;
			if (mergeField != null)
			{
				this.method_27(mergeField);
			}
		}

		private void method_29()
		{
			string text = this.textBox_0.Text;
			if (text.ToLower() != this.string_0.ToLower())
			{
				this.method_30(text);
			}
		}

		private void method_30(string string_1)
		{
			if (!string.IsNullOrEmpty(string_1))
			{
				switch (this.tabControl_0.SelectedIndex)
				{
				case 0:
					this.method_36(string_1);
					break;
				case 1:
					this.method_35(string_1);
					break;
				}
			}
		}

		private void method_31(ApplicationField applicationField_0)
		{
			if (applicationField_0 != null && applicationField_0.TypeName.ToUpper() == "MERGEFIELD")
			{
				MergeField mergeField = new MergeField(applicationField_0);
				if (mergeField != null)
				{
					bool flag = base.TextControl != null && base.TextControl.Focused;
					TreeNode treeNode = this.method_33(this.treeView_0.Nodes, mergeField);
					if (treeNode != null)
					{
						this.tabControl_0.SelectedIndex = 0;
						this.treeView_0.SelectedNode = treeNode;
						this.treeView_1.SelectedNode = null;
						System.Windows.Forms.Button button = this.button_2;
						this.button_1.Enabled = true;
						button.Enabled = true;
						if (flag && !base.TextControl.Focused)
						{
							base.TextControl.Focus();
						}
						return;
					}
					treeNode = this.method_33(this.treeView_1.Nodes, mergeField);
					if (treeNode != null)
					{
						this.tabControl_0.SelectedIndex = 1;
						this.treeView_1.SelectedNode = treeNode;
						this.treeView_0.SelectedNode = null;
						System.Windows.Forms.Button button2 = this.button_2;
						this.button_1.Enabled = true;
						button2.Enabled = true;
						if (flag && !base.TextControl.Focused)
						{
							base.TextControl.Focus();
						}
						return;
					}
				}
			}
			TreeNode treeNode4 = (this.treeView_0.SelectedNode = (this.treeView_1.SelectedNode = null));
			System.Windows.Forms.Button button3 = this.button_2;
			this.button_1.Enabled = false;
			button3.Enabled = false;
		}

		private void method_32(SubTextPart subTextPart_0)
		{
			if (subTextPart_0 != null && DataSourceManager.IsMergeBlock(subTextPart_0))
			{
				TreeNode treeNode = this.method_34(this.treeView_0.Nodes, subTextPart_0);
				if (treeNode != null)
				{
					bool flag = base.TextControl != null && base.TextControl.Focused;
					this.treeView_0.SelectedNode = treeNode;
					this.treeView_1.SelectedNode = null;
					this.tabControl_0.SelectedIndex = 0;
					System.Windows.Forms.Button button = this.button_2;
					this.button_1.Enabled = true;
					button.Enabled = true;
					if (flag && !base.TextControl.Focused)
					{
						base.TextControl.Focus();
					}
					return;
				}
			}
			TreeNode treeNode4 = (this.treeView_0.SelectedNode = (this.treeView_1.SelectedNode = null));
			System.Windows.Forms.Button button2 = this.button_2;
			this.button_1.Enabled = false;
			button2.Enabled = false;
		}

		private TreeNode method_33(TreeNodeCollection treeNodeCollection_0, MergeField mergeField_0)
		{
			foreach (TreeNode item in treeNodeCollection_0)
			{
				if (item.Tag is MergeField)
				{
					ApplicationField applicationField = (item.Tag as MergeField).ApplicationField;
					if (applicationField.int_0 == mergeField_0.ApplicationField.int_0)
					{
						return item;
					}
				}
				else
				{
					TreeNode treeNode2 = this.method_33(item.Nodes, mergeField_0);
					if (treeNode2 != null)
					{
						return treeNode2;
					}
				}
			}
			return null;
		}

		private TreeNode method_34(TreeNodeCollection treeNodeCollection_0, SubTextPart subTextPart_0)
		{
			foreach (TreeNode item in treeNodeCollection_0)
			{
				if (!(item.Tag is Class579))
				{
					continue;
				}
				Class579 @class = item.Tag as Class579;
				SubTextPart subTextPart_ = @class.SubTextPart_0;
				if (!(subTextPart_.Name == subTextPart_0.Name) || subTextPart_.Start != subTextPart_0.Start)
				{
					foreach (Class579 item2 in @class.IList_0)
					{
						TreeNode treeNode2 = this.method_34(item.Nodes, item2.SubTextPart_0);
						if (treeNode2 != null)
						{
							return treeNode2;
						}
					}
					continue;
				}
				return item;
			}
			return null;
		}

		private void method_35(string string_1)
		{
			if (this.ienumerator_1 == null || !this.ienumerator_1.MoveNext())
			{
				try
				{
					IEnumerable<TreeNode> enumerable = this.method_37(string_1, this.treeView_1.Nodes);
					this.ienumerator_1 = enumerable.GetEnumerator();
					this.ienumerator_1.MoveNext();
				}
				catch
				{
					return;
				}
			}
			TreeNode current = this.ienumerator_1.Current;
			if (current != null)
			{
				if (current.Parent != null)
				{
					current.Expand();
				}
				this.treeView_0.SelectedNode = null;
				this.treeView_1.SelectedNode = current;
				this.method_28(current.Tag);
			}
		}

		private void method_36(string string_1)
		{
			if (this.ienumerator_0 == null || !this.ienumerator_0.MoveNext())
			{
				try
				{
					IEnumerable<TreeNode> enumerable = this.method_37(string_1, this.treeView_0.Nodes);
					this.ienumerator_0 = enumerable.GetEnumerator();
					this.ienumerator_0.MoveNext();
				}
				catch
				{
					return;
				}
			}
			TreeNode current = this.ienumerator_0.Current;
			if (current != null)
			{
				if (current.Parent != null)
				{
					current.Expand();
				}
				this.treeView_0.SelectedNode = current;
				this.treeView_1.SelectedNode = null;
				this.method_28(current.Tag);
			}
		}

		private IEnumerable<TreeNode> method_37(string string_1, IEnumerable ienumerable_0)
		{
			foreach (TreeNode node in ienumerable_0)
			{
				if (node.Text.StartsWith(string_1, StringComparison.OrdinalIgnoreCase))
				{
					yield return node;
				}
				foreach (TreeNode item in this.method_37(string_1, node.Nodes))
				{
					yield return item;
				}
			}
		}

		private static List<MergeField> smethod_0(TextControl textControl_0, List<Class579> list_0)
		{
			List<MergeField> list = new List<MergeField>();
			foreach (ApplicationField applicationField in textControl_0.ApplicationFields)
			{
				if (!applicationField.IsInside(list_0))
				{
					MergeField mergeField = applicationField.ToFieldAdapter();
					if (mergeField != null)
					{
						list.Add(mergeField);
					}
				}
			}
			return list;
		}

		private void method_38(SubTextPart subTextPart_0, bool bool_2)
		{
			ApplicationField item;
			if ((item = base.TextControl.ApplicationFields.GetItem()) != null && item.TypeName.ToUpper() == "MERGEFIELD")
			{
				if (bool_2)
				{
					this.method_31(item);
				}
				return;
			}
			if (subTextPart_0 == null)
			{
				subTextPart_0 = base.TextControl.SubTextParts.GetItem();
			}
			this.method_32(subTextPart_0);
		}
	}
}
