using System;
using System.Collections;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using TXTextControl.Windows.Forms.Ribbon;
using TXTextControl;
using TXTextControl.Windows.Forms;

namespace ns26
{
	internal class Class573 : ContentPanel
	{
		internal class Class586
		{
			private TextControl textControl_0;

			private TextControl textControl_1;

			private Class588 class588_0;

			internal Class573 class573_0;

			private int int_0 = -1;

			private bool bool_0;

			private bool bool_1 = true;

			internal TextControl TextControl_0
			{
				get
				{
					return this.textControl_0;
				}
				set
				{
					if (this.textControl_0 != value)
					{
						if (this.textControl_0 != null)
						{
							this.method_1();
							this.textControl_0.TrackedChangeCreated -= textControl_0_TrackedChangeCreated;
							this.textControl_0.TrackedChangeChanged -= textControl_0_TrackedChangeChanged;
							this.textControl_0.TrackedChangeDeleted -= textControl_0_TrackedChangeDeleted;
							this.textControl_0.TrackedChangeStateChanged -= textControl_0_TrackedChangeStateChanged;
							this.textControl_0.InputPositionChanged -= textControl_0_InputPositionChanged;
							this.textControl_0.ContentsReset -= textControl_0_DocumentLoaded;
							this.textControl_0.DocumentLoaded -= textControl_0_DocumentLoaded;
							this.textControl_0.HeaderFooterActivated -= textControl_0_MainTextActivated;
							this.textControl_0.TextFrameActivated -= textControl_0_MainTextActivated;
							this.textControl_0.MainTextActivated -= textControl_0_MainTextActivated;
						}
						this.class588_0.TextControl_0 = (this.textControl_0 = value);
						if (this.textControl_0 != null)
						{
							this.method_0();
							this.textControl_0.TrackedChangeCreated += textControl_0_TrackedChangeCreated;
							this.textControl_0.TrackedChangeChanged += textControl_0_TrackedChangeChanged;
							this.textControl_0.TrackedChangeDeleted += textControl_0_TrackedChangeDeleted;
							this.textControl_0.TrackedChangeStateChanged += textControl_0_TrackedChangeStateChanged;
							this.textControl_0.InputPositionChanged += textControl_0_InputPositionChanged;
							this.textControl_0.ContentsReset += textControl_0_DocumentLoaded;
							this.textControl_0.DocumentLoaded += textControl_0_DocumentLoaded;
							this.textControl_0.HeaderFooterActivated += textControl_0_MainTextActivated;
							this.textControl_0.TextFrameActivated += textControl_0_MainTextActivated;
							this.textControl_0.MainTextActivated += textControl_0_MainTextActivated;
						}
					}
				}
			}

			internal bool Boolean_0
			{
				get
				{
					return this.bool_1;
				}
				set
				{
					if (this.bool_1 != (this.bool_1 = value) && this.bool_1)
					{
						this.method_0();
					}
				}
			}

			internal Class586(TextControl textControl_2)
			{
				this.textControl_1 = textControl_2;
				this.textControl_1.MouseDown += textControl_1_MouseDown;
				this.class588_0 = new Class588(this.textControl_1);
				this.method_1();
			}

			private void textControl_1_MouseDown(object sender, MouseEventArgs e)
			{
				if (this.textControl_0 == null)
				{
					return;
				}
				TextChar item = this.textControl_1.TextChars.GetItem(e.Location, getNearest: true);
				if (item == null)
				{
					return;
				}
				int num = item.Number - 1;
				int num2 = 0;
				while (true)
				{
					if (num2 < this.class588_0.Count)
					{
						Class587 @class = this.class588_0[num2];
						if (@class.Int32_1 <= num && num <= @class.Int32_1 + @class.Int32_2)
						{
							break;
						}
						num2++;
						continue;
					}
					return;
				}
				this.textControl_0.TrackedChanges[num2 + 1].ScrollTo(InputPosition.ScrollPosition.Top);
			}

			private void textControl_0_MainTextActivated(object sender, EventArgs e)
			{
				this.method_0();
			}

			private void textControl_0_TrackedChangeCreated(object sender, TrackedChangeEventArgs e)
			{
				if (this.class573_0.IsSidebarShown && this.textControl_1 != null && this.textControl_1.IsHandleCreated && this.bool_1)
				{
					this.bool_0 = true;
					this.class588_0.method_0(e.TrackedChange, bool_0: true);
					this.method_4(e.TrackedChange.GetHashCode());
					this.class573_0.label_0.Text = this.class573_0.m_rm.GetString("ID_TRACKEDCHANGES_COUNT") + this.class588_0.Int32_0;
				}
			}

			private void textControl_0_TrackedChangeChanged(object sender, TrackedChangeEventArgs e)
			{
				if (this.class573_0.IsSidebarShown && this.textControl_1 != null && this.textControl_1.IsHandleCreated && this.bool_1)
				{
					this.bool_0 = true;
					this.textControl_1.InputPosition.InactiveMarker = false;
					this.class588_0.method_4(e.TrackedChange);
					this.method_4(e.TrackedChange.GetHashCode());
				}
			}

			private void textControl_0_TrackedChangeDeleted(object sender, TrackedChangeEventArgs e)
			{
				if (this.class573_0.IsSidebarShown && this.textControl_1 != null && this.textControl_1.IsHandleCreated && this.bool_1)
				{
					this.bool_0 = true;
					this.class588_0.method_1(e.TrackedChange);
					this.method_4(e.TrackedChange.GetHashCode());
					this.class573_0.label_0.Text = this.class573_0.m_rm.GetString("ID_TRACKEDCHANGES_COUNT") + this.class588_0.Int32_0;
				}
			}

			private void textControl_0_TrackedChangeStateChanged(object sender, TrackedChangeEventArgs e)
			{
				if (this.class573_0.IsSidebarShown && this.bool_1)
				{
					this.class588_0.method_2(e.TrackedChange);
					this.class573_0.label_0.Text = this.class573_0.m_rm.GetString("ID_TRACKEDCHANGES_COUNT") + this.class588_0.Int32_0;
				}
			}

			private void textControl_0_InputPositionChanged(object sender, EventArgs e)
			{
				if (this.class573_0.IsSidebarShown && !this.bool_0)
				{
					this.method_3();
				}
				this.bool_0 = false;
			}

			private void textControl_0_DocumentLoaded(object sender, EventArgs e)
			{
				if (this.class573_0.IsSidebarShown)
				{
					this.int_0 = -1;
					this.textControl_1.InputPosition.InactiveMarker = false;
					this.method_3();
				}
			}

			internal void method_0()
			{
				if (!this.class573_0.IsSidebarShown || this.textControl_0 == null || this.textControl_1 == null || !this.textControl_1.IsHandleCreated)
				{
					return;
				}
				this.method_1();
				foreach (TrackedChange trackedChange in this.textControl_0.TrackedChanges)
				{
					this.class588_0.method_0(trackedChange, bool_0: false);
				}
				this.method_3();
				this.class573_0.label_0.Text = this.class573_0.m_rm.GetString("ID_TRACKEDCHANGES_COUNT") + this.class588_0.Int32_0;
			}

			internal void method_1()
			{
				if (this.textControl_1 != null && this.textControl_1.IsHandleCreated)
				{
					this.int_0 = -1;
					this.textControl_1.ResetContents();
					this.class588_0.Clear();
					this.method_2();
				}
			}

			private void method_2()
			{
				if (this.textControl_1 != null && this.textControl_1.IsHandleCreated)
				{
					ParagraphStyle paragraphStyle = new ParagraphStyle("HeaderStyle");
					paragraphStyle.FontSize = 180;
					paragraphStyle.ParagraphFormat.LeftIndent = 0;
					paragraphStyle.ForeColor = ControlPaint.Dark(Color.LightGray);
					ParagraphStyleCollection paragraphStyleCollection = new ParagraphStyleCollection(this.textControl_1.textControlCore_0);
					paragraphStyleCollection.Add(paragraphStyle);
				}
			}

			private void method_3()
			{
				if (this.textControl_1 == null || !this.textControl_1.IsHandleCreated)
				{
					return;
				}
				TrackedChange item = this.textControl_0.TrackedChanges.GetItem();
				if (item == null)
				{
					item = this.textControl_0.TrackedChanges.GetItem(next: true);
				}
				if (item != null)
				{
					int hashCode = item.GetHashCode();
					if (hashCode != this.int_0)
					{
						this.method_4(hashCode);
						this.textControl_1.InputPosition.ScrollTo(InputPosition.ScrollPosition.Top);
					}
				}
				else if (this.int_0 != -1)
				{
					this.int_0 = -1;
					this.textControl_1.InputPosition = new InputPosition(int.MaxValue);
					this.textControl_1.InputPosition.ScrollTo(InputPosition.ScrollPosition.Top);
				}
			}

			private void method_4(int int_1)
			{
				this.int_0 = int_1;
				this.class588_0.method_3(int_1, out var class587_);
				if (class587_ != null)
				{
					this.textControl_1.InputPosition = new InputPosition(class587_.Int32_1);
				}
				this.textControl_1.InputPosition.InactiveMarker = true;
			}
		}

		internal class Class587
		{
			private string string_0;

			private ChangeKind changeKind_0;

			private int int_0;

			private byte[] byte_0;

			private int int_1 = -1;

			private int int_2;

			private DateTime dateTime_0;

			private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

			private TextControl textControl_0;

			private int int_3 = -1;

			private bool bool_0 = true;

			internal int Int32_0 => this.int_0;

			internal bool Boolean_0
			{
				get
				{
					return this.bool_0;
				}
				set
				{
					if (!(this.bool_0 = value))
					{
						this.int_1 = -1;
						this.int_2 = -1;
					}
				}
			}

			internal int Int32_1
			{
				get
				{
					return this.int_1;
				}
				set
				{
					this.int_1 = value;
				}
			}

			internal int Int32_2 => this.int_2;

			internal Class587(TrackedChange trackedChange_0, TextControl textControl_1)
			{
				this.string_0 = trackedChange_0.UserName;
				this.changeKind_0 = trackedChange_0.ChangeKind;
				this.int_0 = trackedChange_0.GetHashCode();
				this.dateTime_0 = trackedChange_0.ChangeTime;
				trackedChange_0.Save(out this.byte_0, BinaryStreamType.InternalUnicodeFormat, new SaveSettings
				{
					OmittedContent = (OmittedContent)2031616
				});
				this.textControl_0 = textControl_1;
				this.bool_0 = trackedChange_0.Active;
			}

			internal int method_0(int int_4)
			{
				this.textControl_0.textControlCore_0.method_10(bool_1: true);
				this.textControl_0.EditMode = EditMode.Edit;
				this.textControl_0.InputPosition = new InputPosition(int_4);
				this.int_1 = this.textControl_0.InputPosition.TextPosition;
				this.int_3 = this.textControl_0.Selection.Start;
				Selection selection = new Selection(this.textControl_0.InputPosition.TextPosition, 0);
				selection.Text = " " + this.method_4(this.string_0) + " " + this.method_3(this.changeKind_0);
				selection.FormattingStyle = "HeaderStyle";
				this.textControl_0.Selection = selection;
				this.textControl_0.Selection.Text = "\r\n (" + this.dateTime_0.ToLocalTime().ToString() + ")";
				int start = this.textControl_0.Selection.Start;
				this.int_3 = start - this.int_3;
				this.textControl_0.Selection.Text = "\r\n\r\n";
				this.textControl_0.Selection.Start = start;
				this.textControl_0.Selection.Load(this.byte_0, BinaryStreamType.InternalUnicodeFormat, new LoadSettings
				{
					AddParagraph = true,
					LoadHypertextLinks = false
				});
				this.textControl_0.Selection.Start = this.textControl_0.Selection.Start + 2;
				this.int_2 = this.textControl_0.Selection.Start - this.int_1;
				this.textControl_0.EditMode = EditMode.ReadOnly;
				this.textControl_0.textControlCore_0.method_10(bool_1: false);
				return this.int_2;
			}

			internal int method_1()
			{
				if (this.textControl_0 != null)
				{
					SubTextPart subTextPart;
					this.textControl_0.SubTextParts.Add(subTextPart = new SubTextPart("TrackeChanged_SubTextPart_" + this.int_0, this.int_0, this.Int32_1 + 1, this.Int32_2));
					subTextPart.HighlightMode = HighlightMode.Always;
					if (this.textControl_0.SubTextParts.Remove(subTextPart, keepText: false, keepNested: false))
					{
						return -this.Int32_2;
					}
				}
				return 0;
			}

			internal int method_2(byte[] byte_1)
			{
				if (this.textControl_0 != null && byte_1 != null)
				{
					this.byte_0 = byte_1;
					this.textControl_0.textControlCore_0.method_10(bool_1: true);
					this.textControl_0.EditMode = EditMode.Edit;
					int num = this.int_1 + this.int_3;
					int num2 = this.int_1 + this.int_2 - num - 1;
					this.textControl_0.Selection = new Selection(num, num2);
					this.textControl_0.Selection.Load(this.byte_0, BinaryStreamType.InternalUnicodeFormat, new LoadSettings
					{
						AddParagraph = true
					});
					int num3 = this.textControl_0.Selection.Start - num - num2;
					this.textControl_0.Selection.Text = "\r\n";
					this.int_2 += num3 + 1;
					this.textControl_0.Selection.RemoveInlineStyles();
					this.textControl_0.Selection.FormattingStyle = "HeaderStyle";
					this.textControl_0.EditMode = EditMode.ReadOnly;
					this.textControl_0.textControlCore_0.method_10(bool_1: false);
					return num3 + 1;
				}
				return 0;
			}

			private string method_3(ChangeKind changeKind_1)
			{
				return changeKind_1 switch
				{
					ChangeKind.DeletedText => this.resourceManager_0.GetString("ID_TRACKEDCHANGES_DELETED"), 
					ChangeKind.InsertedText => this.resourceManager_0.GetString("ID_TRACKEDCHANGES_INSERTED"), 
					_ => "", 
				};
			}

			private string method_4(string string_1)
			{
				if (string.IsNullOrEmpty(string_1))
				{
					return this.resourceManager_0.GetString("ID_TRACKEDCHANGES_UNKNOWNUSER");
				}
				return string_1;
			}
		}

		internal class Class588 : CollectionBase
		{
			private TextControl textControl_0;

			private TextControl textControl_1;

			private int int_0;

			public Class587 this[int number] => (Class587)base.List[number];

			internal TextControl TextControl_0
			{
				get
				{
					return this.textControl_0;
				}
				set
				{
					this.textControl_0 = value;
				}
			}

			internal int Int32_0 => this.int_0;

			internal Class588(TextControl textControl_2)
			{
				this.textControl_1 = textControl_2;
			}

			internal void method_0(TrackedChange trackedChange_0, bool bool_0)
			{
				int num = trackedChange_0.Number - 1;
				if (num < 0)
				{
					return;
				}
				this.textControl_1.Selection.Start = int.MaxValue;
				int num2 = Math.Max(0, this.textControl_1.Selection.Start);
				if (num < base.List.Count)
				{
					for (int i = num; i < base.List.Count; i++)
					{
						if ((base.List[num] as Class587).Boolean_0)
						{
							num2 = (base.List[num] as Class587).Int32_1;
							break;
						}
					}
				}
				if (num2 < 0)
				{
					return;
				}
				Class587 @class = new Class587(trackedChange_0, this.textControl_1);
				base.List.Insert(Math.Min(base.List.Count, num), @class);
				if (@class.Boolean_0)
				{
					int int_ = @class.method_0(num2);
					if (bool_0)
					{
						this.method_5(num + 1, int_);
					}
					this.int_0++;
				}
			}

			internal void method_1(TrackedChange trackedChange_0)
			{
				int hashCode = trackedChange_0.GetHashCode();
				int int_;
				if ((int_ = this.method_3(hashCode, out var class587_)) >= 0)
				{
					int int_2 = class587_.method_1();
					base.List.Remove(class587_);
					this.method_5(int_, int_2);
					if (class587_.Boolean_0)
					{
						this.int_0--;
					}
				}
			}

			internal void method_2(TrackedChange trackedChange_0)
			{
				int hashCode = trackedChange_0.GetHashCode();
				int int_;
				if ((int_ = this.method_3(hashCode, out var class587_)) < 0)
				{
					return;
				}
				if (trackedChange_0.Active)
				{
					if (class587_.Boolean_0)
					{
						return;
					}
					int num = trackedChange_0.Number - 1;
					this.textControl_1.Selection.Start = int.MaxValue;
					int num2 = Math.Max(0, this.textControl_1.Selection.Start);
					if (num < base.List.Count)
					{
						for (int i = num; i < base.List.Count; i++)
						{
							if ((base.List[i] as Class587).Boolean_0)
							{
								num2 = (base.List[i] as Class587).Int32_1;
								break;
							}
						}
					}
					if (num2 >= 0)
					{
						int int_2 = class587_.method_0(num2);
						this.method_5(num + 1, int_2);
					}
					class587_.Boolean_0 = true;
					this.int_0++;
				}
				else if (class587_.Boolean_0)
				{
					int int_3 = class587_.method_1();
					this.method_5(int_, int_3);
					class587_.Boolean_0 = false;
					this.int_0--;
				}
			}

			internal int method_3(int int_1, out Class587 class587_0)
			{
				int num = 0;
				while (true)
				{
					if (num < base.List.Count)
					{
						class587_0 = base.List[num] as Class587;
						if (class587_0.Int32_0 == int_1)
						{
							break;
						}
						num++;
						continue;
					}
					class587_0 = null;
					return -1;
				}
				return num;
			}

			internal void method_4(TrackedChange trackedChange_0)
			{
				int hashCode = trackedChange_0.GetHashCode();
				int num;
				if ((num = this.method_3(hashCode, out var class587_)) >= 0)
				{
					_ = trackedChange_0.Number;
					trackedChange_0.Save(out var binaryData, BinaryStreamType.InternalUnicodeFormat, new SaveSettings
					{
						OmittedContent = (OmittedContent)2031616
					});
					int int_ = class587_.method_2(binaryData);
					this.method_5(num + 1, int_);
				}
			}

			private void method_5(int int_1, int int_2)
			{
				for (int i = int_1; i < base.List.Count; i++)
				{
					(base.List[i] as Class587).Int32_1 += int_2;
				}
			}

			protected override void OnClear()
			{
				base.OnClear();
				this.int_0 = 0;
			}
		}

		internal class Control17 : Control
		{
			private VisualStyleRenderer visualStyleRenderer_0;

			private System.Drawing.Image image_0;

			private ToolTip toolTip_0 = new ToolTip();

			private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

			internal System.Drawing.Image Image_0
			{
				get
				{
					return this.image_0;
				}
				set
				{
					this.image_0 = value;
				}
			}

			internal Control17()
			{
				base.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
				try
				{
					this.visualStyleRenderer_0 = new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal);
				}
				catch
				{
				}
				this.BackColor = Color.Transparent;
				this.Dock = DockStyle.Right;
				this.toolTip_0.SetToolTip(this, this.resourceManager_0.GetString("TOOLTIP_RefreshTrackedChanges"));
			}

			protected override void OnMouseEnter(EventArgs eventargs)
			{
				if (this.visualStyleRenderer_0 != null)
				{
					this.visualStyleRenderer_0 = new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Hot);
					base.Invalidate();
				}
				base.OnMouseEnter(eventargs);
			}

			protected override void OnMouseLeave(EventArgs eventargs)
			{
				if (this.visualStyleRenderer_0 != null)
				{
					this.visualStyleRenderer_0 = new VisualStyleRenderer(VisualStyleElement.ToolBar.Button.Normal);
					base.Invalidate();
				}
				base.OnMouseLeave(eventargs);
			}

			protected override void OnPaint(PaintEventArgs pea)
			{
				Rectangle rectangle = new Rectangle(0, 0, base.Width, base.Height);
				if (this.visualStyleRenderer_0 != null)
				{
					this.visualStyleRenderer_0.DrawBackground(pea.Graphics, rectangle);
				}
				pea.Graphics.DrawImage(this.image_0, rectangle);
				base.OnPaint(pea);
			}
		}

		internal Label label_0;

		private Control17 control17_0;

		private TableLayoutPanel tableLayoutPanel_0;

		private TextControl textControl_0;

		private Control control_0;

		internal Class586 class586_0;

		internal Class573(Enum140 enum140_0, TextControl textControl_1, bool bool_0, Sidebar.SidebarContentLayout sidebarContentLayout_0, PointF pointF_0)
			: base(enum140_0, textControl_1, bool_0, sidebarContentLayout_0, pointF_0)
		{
			this.label_0.Text = base.m_rm.GetString("ID_TRACKEDCHANGES_COUNT") + "0";
			if (!bool_0)
			{
				this.class586_0 = new Class586(this.textControl_0);
				this.class586_0.class573_0 = this;
				this.class586_0.TextControl_0 = textControl_1;
			}
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			base.OnHandleCreated(eventArgs_0);
			if (this.textControl_0 != null && !this.textControl_0.IsHandleCreated)
			{
				this.textControl_0.CreateControl();
			}
			if (this.class586_0 != null && base.TextControl != null)
			{
				this.class586_0.method_0();
			}
		}

		internal override void UpdateContent()
		{
			if (base.IsSidebarShown && this.class586_0 != null && base.TextControl != null)
			{
				this.class586_0.method_0();
			}
		}

		public override Size GetPreferredSize(Size proposedSize)
		{
			Size result = base.GetPreferredSize(Size.Empty);
			if (!base.m_pntDpi.IsEmpty)
			{
				switch (base.m_cpaPanelAlignment)
				{
				case Enum140.const_0:
					result = Class517.smethod_48(Class519.Class542.Class546.Size_1, base.m_pntDpi);
					break;
				case Enum140.const_1:
					result = new Size(result.Width, Class517.smethod_45(Class519.Class542.Class546.Size_0.Height, base.m_pntDpi.Y));
					break;
				case Enum140.const_2:
					result = new Size(Class517.smethod_45(Class519.Class542.Class546.Size_0.Width, base.m_pntDpi.X), result.Height);
					break;
				}
			}
			return result;
		}

		internal override void InitializeItems()
		{
			this.label_0 = new Label();
			this.label_0.Name = Sidebar.TrackedChangesItem.TXITEM_TrackedChangesCount.ToString();
			this.label_0.Dock = DockStyle.Left;
			this.label_0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label_0.AutoSize = true;
			this.control17_0 = new Control17();
			this.control17_0.Name = Sidebar.TrackedChangesItem.TXITEM_TrackedChangesRefresh.ToString();
			this.control17_0.Click += control17_0_Click;
			this.tableLayoutPanel_0 = new TableLayoutPanel();
			this.tableLayoutPanel_0.Dock = DockStyle.Fill;
			this.tableLayoutPanel_0.BackColor = SystemColors.ActiveBorder;
			if (!base.m_bIsDesignMode)
			{
				this.textControl_0 = new TextControl();
				this.textControl_0.Name = Sidebar.TrackedChangesItem.TXITEM_TrackedChangesViewer.ToString();
				this.textControl_0.Dock = DockStyle.Fill;
				this.textControl_0.ViewMode = ViewMode.Normal;
				this.textControl_0.ScrollBars = ScrollBars.Both;
				this.textControl_0.AllowDrag = false;
				this.textControl_0.AllowDrop = false;
				this.textControl_0.AllowUndo = false;
				this.textControl_0.EditMode = EditMode.ReadOnly;
				this.textControl_0.DocumentTargetMarkers = false;
				this.textControl_0.ControlChars = false;
				this.textControl_0.HideSelection = true;
				this.textControl_0.FieldCursor = Cursors.Default;
				base.m_dicItems.Add(this.label_0.Name, this.label_0);
				base.m_dicItems.Add(this.control17_0.Name, this.control17_0);
				base.m_dicItems.Add(this.textControl_0.Name, this.textControl_0);
			}
			else
			{
				this.control_0 = new Control();
				this.control_0.Name = Sidebar.TrackedChangesItem.TXITEM_TrackedChangesViewer.ToString();
				this.control_0.Dock = DockStyle.Fill;
				this.control_0.BackColor = Color.White;
			}
			base.Name = "TXITEM_MainPanel";
			base.TabIndex = 99999;
		}

		internal override void AwareOfDPI_Intialize()
		{
			if (!base.m_pntDpi.IsEmpty)
			{
				this.tableLayoutPanel_0.Margin = Class517.smethod_51(Class519.Class542.Class546.Padding_1, base.m_pntDpi);
				this.control17_0.Margin = Class517.smethod_51(Class519.Class542.Class546.Padding_0, base.m_pntDpi);
				this.control17_0.Image_0 = Class517.smethod_55(Sidebar.TrackedChangesItem.TXITEM_TrackedChangesRefresh.ToString(), ImageProvider.ImageKind.Small_16x16, Class517.smethod_48(Class519.Class542.Class546.Size_2, base.m_pntDpi), base.m_pntDpi);
				this.control17_0.MinimumSize = Class517.smethod_48(Class519.Class542.Class546.Size_2, base.m_pntDpi);
				this.control17_0.MaximumSize = Class517.smethod_48(Class519.Class542.Class546.Size_2, base.m_pntDpi);
				if (!base.m_bIsDesignMode)
				{
					this.textControl_0.Margin = Class517.smethod_51(Class519.Class542.Class546.Padding_2, base.m_pntDpi);
					return;
				}
				this.control_0.Width = Class517.smethod_45(Class519.Class542.Class546.Size_0.Width, base.m_pntDpi.X);
				this.control_0.Margin = Class517.smethod_51(Class519.Class542.Class546.Padding_2, base.m_pntDpi);
			}
		}

		internal override void SetDialogAlignment()
		{
			this.method_0();
		}

		internal override void SetHorizontalAlignment()
		{
			this.method_0();
		}

		internal override void SetVerticalAlignment()
		{
			this.method_0();
		}

		internal override void UpdateTextControlBindings(TextControl oldTextcontrol, TextControl newTextControl)
		{
			if (this.class586_0 != null)
			{
				this.class586_0.TextControl_0 = newTextControl;
			}
		}

		private void control17_0_Click(object sender, EventArgs e)
		{
			this.class586_0.method_0();
		}

		private void method_0()
		{
			base.Controls.Clear();
			this.tableLayoutPanel_0.Controls.Clear();
			base.ColumnStyles.Clear();
			base.RowStyles.Clear();
			Control control = (base.m_bIsDesignMode ? this.control_0 : this.textControl_0);
			switch (base.m_cpaPanelAlignment)
			{
			case Enum140.const_0:
				control.Height = 1;
				control.Width = 1;
				break;
			case Enum140.const_1:
				control.Height = 110;
				control.Width = 1;
				break;
			case Enum140.const_2:
				control.Height = 1;
				control.Width = 200;
				break;
			}
			this.AutoSize = true;
			this.AutoSizeMode = AutoSizeMode.GrowOnly;
			base.ColumnCount = 2;
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			base.ColumnStyles.Add(new ColumnStyle());
			base.RowCount = 2;
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			base.Controls.Add(this.label_0, 0, 0);
			base.Controls.Add(this.control17_0, 1, 0);
			base.Controls.Add(this.tableLayoutPanel_0, 0, 1);
			base.SetColumnSpan(this.tableLayoutPanel_0, 2);
			if (!base.m_bIsDesignMode)
			{
				this.tableLayoutPanel_0.Controls.Add(this.textControl_0, 0, 0);
			}
			else
			{
				this.tableLayoutPanel_0.Controls.Add(this.control_0, 0, 0);
			}
			base.SetVerticalAlignment();
		}
	}
}
