using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ns21;
using ns26;
using ns27;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms
{
	/// <summary>The Sidebar class represents a container that gives quick access to a control which is either user-defined or a predefined TextControl feature interface.</summary>
	[Designer("TXTextControl.SidebarDesigner, TXTextControl.Design.dll, Version=29.0.113.500, Culture=neutral, PublicKeyToken=17fff8a774004c66")]
	public class Sidebar : TableLayoutPanel, INotifyPropertyChanged
	{
		/// <summary>Specifies the requested layout that has to be intialized and rendered as sidebar content.</summary>
		public enum SidebarContentLayout
		{
			/// <summary>No content is diplayed or can be set.</summary>
			None,
			/// <summary>A custom control can be used as content.</summary>
			Custom,
			/// <summary>The content represents a go to interface.</summary>
			Goto,
			/// <summary>The content represents a panel to navigate through the merge fields of a document.</summary>
			FieldNavigator,
			/// <summary>The content represents a panel that shows all tracked changes of a document.</summary>
			TrackedChanges,
			/// <summary>The content represents an overview of all available styles of the document.</summary>
			Styles,
			/// <summary>The content represents a find in text interface.</summary>
			Find,
			/// <summary>The content represents a find and replace in text interface.</summary>
			Replace,
			/// <summary>The content represents a panel to manage the conditional instructions of a document.</summary>
			ConditionalInstructions,
			/// <summary>The content represents a panel to manage the settings of a document.</summary>
			DocumentSettings
		}

		/// <summary>Specifies the requested border and title bar layout of the sidebar dialog.</summary>
		public enum SidebarDialogStyle
		{
			/// <summary>The dialog's border and title bar equal to the style of a System.Windows.Forms.Form where the FormBorderStyle is set to System.Windows.Forms.FormBorderStyle.FixedDialog.</summary>
			Standard,
			/// <summary>The dialog's border and title bar equal to the style of a System.Windows.Forms.Form where the FormBorderStyle is set to System.Windows.Forms.FormBorderStyle.Sizable.</summary>
			StandardSizable,
			/// <summary>The dialog only displays the sidebar. The dialog is not sizable and neither a specific dialog border nor a title bar are set (equivalent to System.Windows.Forms.FormBorderStyle.FixedSingle).</summary>
			Sidebar,
			/// <summary>The dialog only displays the sidebar. The dialog is sizable (equivalent to System.Windows.Forms.FormBorderStyle.Sizable), but neither a specific dialog border nor a title bar are set.</summary>
			SidebarSizable
		}

		/// <summary>Each ConditionalInstructionsItem represents an item in a predefined ConditionalInstructions control.</summary>
		public enum ConditionalInstructionsItem
		{
			/// <summary>Identifies the Conditional Instructions overview label.</summary>
			TXITEM_OverviewLabel,
			/// <summary>Identifies the Conditional Instructions overview.</summary>
			TXITEM_Overview,
			/// <summary>Identifies the Conditions overview label.</summary>
			TXITEM_ConditionsLabel,
			/// <summary>Identifies the Conditions overview.</summary>
			TXITEM_Conditions,
			/// <summary>Identifies the Instructions overview label.</summary>
			TXITEM_InstructionsLabel,
			/// <summary>Identifies the Instructions overview.</summary>
			TXITEM_Instructions,
			/// <summary>Identifies the Conditional Instructions New button.</summary>
			TXITEM_New,
			/// <summary>Identifies the Conditional Instructions Edit button.</summary>
			TXITEM_Edit,
			/// <summary>Identifies the Conditional Instructions Edit button.</summary>
			TXITEM_Delete
		}

		/// <summary>Each FieldNavigatorItem represents an item in a predefined FieldNavigator control.</summary>
		public enum FieldNavigatorItem
		{
			/// <summary>Identifies the Field Navigator search text box.</summary>
			TXITEM_SearchTextBox,
			/// <summary>Identifies the Field Navigator search button.</summary>
			TXITEM_SearchButton,
			/// <summary>Identifies the tab control that contains the merge field and merge block tree views.</summary>
			TXITEM_MergeItems,
			/// <summary>Identifies the Delete button.</summary>
			TXITEM_Remove,
			/// <summary>Identifies the Properties button.</summary>
			TXITEM_Properties
		}

		/// <summary>Each FieldNavigatorItem represents an item in a predefined Find or Replace control.</summary>
		public enum FindAndReplaceItem
		{
			/// <summary>Identifies the Find What label.</summary>
			TXITEM_FindWhatLabel,
			/// <summary>Identifies the Find What text box.</summary>
			TXITEM_FindWhatTextBox,
			/// <summary>Identifies the Replace With label (only with Replace content layout).</summary>
			TXITEM_ReplaceWithLabel,
			/// <summary>Identifies the Replace With text box (only with Replace content layout).</summary>
			TXITEM_ReplaceWithTextBox,
			/// <summary>Identifies the Find Options toggle item.</summary>
			TXITEM_FindOptionsToggleItem,
			/// <summary>Identifies the Find Options label.</summary>
			TXITEM_FindOptionsLabel,
			/// <summary>Identifies the Find Options separator.</summary>
			TXITEM_FindOptionsSeparator,
			/// <summary>Identifies the Match Case check box.</summary>
			TXITEM_MatchCase,
			/// <summary>Identifies the Match Whole Word check box.</summary>
			TXITEM_MatchWholeWord,
			/// <summary>Identifies the Search Up control.</summary>
			TXITEM_SearchUp,
			/// <summary>Identifies the Search In Main Text check box.</summary>
			TXITEM_SearchInMainText,
			/// <summary>Identifies the Search In Text Frames check box.</summary>
			TXITEM_SearchInTextFrames,
			/// <summary>Identifies the Search In Header Footers check box.</summary>
			TXITEM_SearchInHeaderFooters,
			/// <summary>Identifies the Find Next button.</summary>
			TXITEM_FindNext,
			/// <summary>Identifies the Replace button (only with Replace content layout).</summary>
			TXITEM_Replace,
			/// <summary>Identifies the Replace All button (only with Replace content layout).</summary>
			TXITEM_ReplaceAll,
			/// <summary>Identifies the Cancel button.</summary>
			TXITEM_Cancel
		}

		/// <summary>Each GotoItem represents an item in a predefined Goto control.</summary>
		public enum GotoItem
		{
			/// <summary>Identifies the label of the Go to list box.</summary>
			TXITEM_GotoLabel,
			/// <summary>Identifies the Go to list box.</summary>
			TXITEM_GotoList,
			/// <summary>Identifies the label of the Number text box.</summary>
			TXITEM_NumberLabel,
			/// <summary>Identifies the Number respectively Bookmark combo box.</summary>
			TXITEM_Number,
			/// <summary>Identifies the Previous button.</summary>
			TXITEM_GotoPrevious,
			/// <summary>Identifies the Next button.</summary>
			TXITEM_GotoNext,
			/// <summary>Identifies the Close button.</summary>
			TXITEM_Close
		}

		/// <summary>Each DocumentSettingsItem represents an item in a predefined Document Settings control.</summary>
		public enum DocumentSettingsItem
		{
			/// <summary>Identifies the Titel label.</summary>
			TXITEM_TitleLabel,
			/// <summary>Identifies the Titel text box.</summary>
			TXITEM_TitleTextBox,
			/// <summary>Identifies the Author label.</summary>
			TXITEM_AuthorLabel,
			/// <summary>Identifies the Author text box.</summary>
			TXITEM_AuthorTextBox,
			/// <summary>Identifies the Created label.</summary>
			TXITEM_CreatedLabel,
			/// <summary>Identifies the Created Date label.</summary>
			TXITEM_DateLabel,
			/// <summary>Identifies the Subject label.</summary>
			TXITEM_SubjectLabel,
			/// <summary>Identifies the Subject text box.</summary>
			TXITEM_SubjectTextBox,
			/// <summary>Identifies the Tags label.</summary>
			TXITEM_TagsLabel,
			/// <summary>Identifies the Tags text box.</summary>
			TXITEM_TagsTextBox,
			/// <summary>Identifies the first vertical separator that is displayed when applying the horizontal sidebar layout.</summary>
			TXITEM_FirstVerticalSeparator,
			/// <summary>Identifies the panel that includes all Custom Properies related controls.</summary>
			TXITEM_CustomPropertiesPanel,
			/// <summary>Identifies the Custom Properties +/- toggle item.</summary>
			TXITEM_CustomPropertiesToggleItem,
			/// <summary>Identifies the Custom Properties label.</summary>
			TXITEM_CustomPropertiesLabel,
			/// <summary>Identifies the Custom Properties separator.</summary>
			TXITEM_CustomPropertiesSeparator,
			/// <summary>Identifies panel that includes the controls TXITEM_CustomPropertiesListView, TXITEM_AddCustomProperty and TXITEM_DeleteCustomProperty.</summary>
			TXITEM_CustomPropertiesSubpanel,
			TXITEM_CustomPropertiesListView,
			/// <summary>Identifies the Add Custom Property button.</summary>
			TXITEM_AddCustomProperty,
			/// <summary>Identifies the Delete Custom Property button.</summary>
			TXITEM_DeleteCustomProperty,
			/// <summary>Identifies the second vertical separator that is displayed when applying the horizontal sidebar layout.</summary>
			TXITEM_SecondVerticalSeparator,
			/// <summary>Identifies the panel that includes all Embedded Files related controls.</summary>
			TXITEM_EmbeddedFilesPanel,
			/// <summary>Identifies the Embedded Files +/- toggle item.</summary>
			TXITEM_EmbeddedFilesToggleItem,
			/// <summary>Identifies the Embedded Files label.</summary>
			TXITEM_EmbeddedFilesLabel,
			/// <summary>Identifies the Embedded Files separator.</summary>
			TXITEM_EmbeddedFilesSeparator,
			/// <summary>Identifies panel that includes the controls TXITEM_EmbeddedFilesListView, TXITEM_AddEmbeddedFile, TXITEM_SaveEmbeddedFile, TXITEM_RemoveEmbeddedFile and TXITEM_EditEmbeddedFile.</summary>
			TXITEM_EmbeddedFilesSubpanel,
			TXITEM_EmbeddedFilesListView,
			/// <summary>Identifies the Add Embedded File button.</summary>
			TXITEM_AddEmbeddedFile,
			/// <summary>Identifies the Save Embedded File button.</summary>
			TXITEM_SaveEmbeddedFile,
			/// <summary>Identifies the Remove Embedded File button.</summary>
			TXITEM_RemoveEmbeddedFile,
			/// <summary>Identifies the Edit Embedded File button.</summary>
			TXITEM_EditEmbeddedFile,
			/// <summary>Identifies the tab control that is displayed when applying the dialog sidebar layout.</summary>
			TXITEM_DialogTabControl,
			/// <summary>Identifies the Document Info tab page that is displayed when applying the dialog sidebar layout.</summary>
			TXITEM_DocumentInfoTabPage,
			/// <summary>Identifies the Custom Properties tab page that is displayed when applying the dialog sidebar layout.</summary>
			TXITEM_CustomPropertiesTabPage,
			/// <summary>Identifies the Embedded Files tab page that is displayed when applying the dialog sidebar layout.</summary>
			TXITEM_EmbeddedFilesTabPage
		}

		/// <summary>Each StylesItem represents an item in a predefined Styles control.</summary>
		public enum StylesItem
		{
			/// <summary>Identifies the Styles overview.</summary>
			TXITEM_Styles,
			/// <summary>Identifies the Show Preview check box.</summary>
			TXITEM_ShowPreview,
			/// <summary>Identifies the Manage Styles button.</summary>
			TXITEM_ManageStyles
		}

		/// <summary>Each TrackedChangesItem represents an item in a predefined TrackedChanges control.</summary>
		public enum TrackedChangesItem
		{
			/// <summary>Identifies the Tracked Changes Count label.</summary>
			TXITEM_TrackedChangesCount,
			/// <summary>Identifies the Tracked Changes Refresh button.</summary>
			TXITEM_TrackedChangesRefresh,
			/// <summary>Identifies the Tracked Changes overview.</summary>
			TXITEM_TrackedChangesViewer
		}

		private enum Enum141
		{
			const_0,
			const_1,
			const_2,
			const_3,
			const_4
		}

		internal class SidebarTitleLabel : Label
		{
			private Sidebar sidebar_0;

			internal SidebarTitleLabel(Sidebar sidebar_1)
			{
				base.Name = "SidebarTitleLabel";
				this.sidebar_0 = sidebar_1;
				base.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
				this.BackColor = Color.Transparent;
				this.Font = new Font("Calibri Light", 18f);
				this.ForeColor = Color.FromArgb(43, 87, 154);
				this.Dock = DockStyle.Top;
				this.TextAlign = System.Drawing.ContentAlignment.TopLeft;
				this.AutoSize = true;
				base.SetAutoSizeMode(AutoSizeMode.GrowAndShrink);
			}

			protected override void OnFontChanged(EventArgs eventArgs_0)
			{
				base.OnFontChanged(eventArgs_0);
			}

			protected override void OnMouseEnter(EventArgs eventargs)
			{
				base.OnMouseEnter(eventargs);
				this.sidebar_0.OnMouseEnter(eventargs);
			}

			protected override void OnMouseDown(MouseEventArgs mevent)
			{
				base.OnMouseDown(mevent);
				this.sidebar_0.OnMouseDown(new MouseEventArgs(mevent.Button, mevent.Clicks, mevent.X + base.Location.X, mevent.Y + base.Location.Y, mevent.Delta));
			}

			protected override void OnMouseMove(MouseEventArgs mevent)
			{
				base.OnMouseMove(mevent);
				this.sidebar_0.OnMouseMove(new MouseEventArgs(mevent.Button, mevent.Clicks, mevent.X + base.Location.X, mevent.Y + base.Location.Y, mevent.Delta));
			}

			protected override void OnMouseUp(MouseEventArgs mevent)
			{
				base.OnMouseUp(mevent);
				this.sidebar_0.OnMouseUp(mevent);
			}

			protected override void OnMouseLeave(EventArgs eventargs)
			{
				base.OnMouseLeave(eventargs);
				this.sidebar_0.OnMouseLeave(eventargs);
			}
		}

		internal class SidebarPinButton : Control
		{
			private VisualStyleRenderer visualStyleRenderer_0;

			private System.Drawing.Image image_0;

			private Sidebar sidebar_0;

			private ToolTip toolTip_0 = new ToolTip();

			private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

			private ImageAttributes imageAttributes_0;

			private Rectangle rectangle_0;

			internal Rectangle Rectangle_0
			{
				get
				{
					return this.rectangle_0;
				}
				set
				{
					this.rectangle_0 = value;
				}
			}

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

			internal string String_0
			{
				get
				{
					return null;
				}
				set
				{
					this.toolTip_0.SetToolTip(this, value);
				}
			}

			internal SidebarPinButton(Sidebar sidebar_1)
			{
				base.Name = "SidebarPinButton";
				this.toolTip_0.SetToolTip(this, this.resourceManager_0.GetString("TOOLTIP_UnpinSidebar"));
				this.sidebar_0 = sidebar_1;
				base.Visible = true;
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
				this.image_0 = Class517.Bitmap_10;
				this.imageAttributes_0 = Class517.smethod_20((!base.Enabled) ? 65 : 0);
			}

			protected override void OnEnabledChanged(EventArgs eventArgs_0)
			{
				this.imageAttributes_0 = Class517.smethod_20((!base.Enabled) ? 65 : 0);
				base.OnEnabledChanged(eventArgs_0);
			}

			protected override void OnClick(EventArgs eventArgs_0)
			{
				if (this.sidebar_0.Boolean_0)
				{
					(this.sidebar_0.Parent as Form0).method_2();
				}
				else
				{
					this.sidebar_0.IsPinned = false;
				}
				base.OnClick(eventArgs_0);
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
				Rectangle bounds = new Rectangle(0, 0, base.Width, base.Height);
				if (this.visualStyleRenderer_0 != null)
				{
					this.visualStyleRenderer_0.DrawBackground(pea.Graphics, bounds);
				}
				pea.Graphics.DrawImage(this.image_0, this.rectangle_0, 0, 0, this.image_0.Width, this.image_0.Height, GraphicsUnit.Pixel, this.imageAttributes_0);
				base.OnPaint(pea);
			}
		}

		internal class SidebarCloseButton : Control
		{
			private VisualStyleRenderer visualStyleRenderer_0;

			private Sidebar sidebar_0;

			private ToolTip toolTip_0 = new ToolTip();

			private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

			private ImageAttributes imageAttributes_0;

			private Rectangle rectangle_0;

			[CompilerGenerated]
			private System.Drawing.Image image_0;

			internal Rectangle Rectangle_0
			{
				get
				{
					return this.rectangle_0;
				}
				set
				{
					this.rectangle_0 = value;
				}
			}

			internal System.Drawing.Image Image_0
			{
				[CompilerGenerated]
				get
				{
					return this.image_0;
				}
				[CompilerGenerated]
				set
				{
					this.image_0 = value;
				}
			}

			internal SidebarCloseButton(Sidebar sidebar_1)
			{
				base.Name = "SidebarCloseButton";
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
				this.sidebar_0 = sidebar_1;
				this.toolTip_0.SetToolTip(this, this.resourceManager_0.GetString("TOOLTIP_CloseSidebar"));
				this.imageAttributes_0 = Class517.smethod_20((!base.Enabled) ? 65 : 0);
			}

			protected override void OnEnabledChanged(EventArgs eventArgs_0)
			{
				this.imageAttributes_0 = Class517.smethod_20((!base.Enabled) ? 65 : 0);
				base.OnEnabledChanged(eventArgs_0);
			}

			protected override void OnClick(EventArgs eventArgs_0)
			{
				if (this.sidebar_0.Boolean_0)
				{
					(this.sidebar_0.Parent as Form0).method_0();
				}
				else
				{
					this.sidebar_0.IsShown = false;
				}
				base.OnClick(eventArgs_0);
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
				Rectangle bounds = new Rectangle(0, 0, base.Width, base.Height);
				if (this.visualStyleRenderer_0 != null)
				{
					this.visualStyleRenderer_0.DrawBackground(pea.Graphics, bounds);
				}
				pea.Graphics.DrawImage(this.Image_0, this.rectangle_0, 0, 0, this.Image_0.Width, this.Image_0.Height, GraphicsUnit.Pixel, this.imageAttributes_0);
				base.OnPaint(pea);
			}
		}

		internal class Form0 : Form
		{
			private Sidebar sidebar_0;

			private Sidebar sidebar_1;

			private bool bool_0;

			private int int_0;

			private int int_1;

			private bool bool_1;

			private PointF pointF_0 = PointF.Empty;

			private uint uint_0;

			internal Sidebar Sidebar_0 => this.sidebar_0;

			internal Form0(Sidebar sidebar_2)
			{
				this.sidebar_1 = sidebar_2;
				base.StartPosition = FormStartPosition.Manual;
				base.ShowInTaskbar = false;
				base.Size = Size.Empty;
				base.KeyPreview = true;
				if (this.bool_1 = sidebar_2.DialogStyle == SidebarDialogStyle.Sidebar || sidebar_2.DialogStyle == SidebarDialogStyle.SidebarSizable)
				{
					base.FormBorderStyle = ((sidebar_2.DialogStyle == SidebarDialogStyle.Sidebar) ? FormBorderStyle.FixedSingle : FormBorderStyle.Sizable);
					base.ControlBox = false;
				}
				else
				{
					base.FormBorderStyle = ((sidebar_2.DialogStyle == SidebarDialogStyle.Standard) ? FormBorderStyle.FixedDialog : FormBorderStyle.Sizable);
					base.ControlBox = sidebar_2.ShowCloseButton;
					this.Text = sidebar_2.Text;
					base.MinimizeBox = false;
					base.MaximizeBox = false;
					base.ShowIcon = false;
				}
				this.sidebar_0 = new Sidebar();
				this.sidebar_0.Dock = DockStyle.Fill;
				this.sidebar_0.Boolean_0 = true;
				this.sidebar_0.ContentLayout = SidebarContentLayout.Custom;
				this.sidebar_0.AutoSize = true;
				this.sidebar_0.AutoSizeMode = AutoSizeMode.GrowAndShrink;
				if (this.bool_1)
				{
					this.sidebar_0.IsPinned = false;
					this.sidebar_0.ShowCloseButton = this.sidebar_1.ShowCloseButton;
					this.sidebar_0.ShowPinButton = this.sidebar_1.ShowPinButton;
					this.sidebar_0.ShowTitle = this.sidebar_1.ShowTitle;
					this.sidebar_0.TitleFont = this.sidebar_1.TitleFont;
					this.sidebar_0.TitleForeColor = this.sidebar_1.TitleForeColor;
					this.sidebar_0.Image_0 = Class517.Bitmap_11;
					this.sidebar_0.MouseEnter += sidebar_0_MouseEnter;
					this.sidebar_0.MouseDown += sidebar_0_MouseDown;
					this.sidebar_0.MouseUp += sidebar_0_MouseUp;
					this.sidebar_0.MouseMove += sidebar_0_MouseMove;
					this.sidebar_0.MouseLeave += sidebar_0_MouseLeave;
				}
				else
				{
					this.sidebar_0.Padding = new Padding(0);
				}
				base.Controls.Add(this.sidebar_0);
			}

			protected override void OnVisibleChanged(EventArgs eventArgs_0)
			{
				if (base.Visible && !this.bool_1 && this.sidebar_0.Boolean_2)
				{
					this.sidebar_0.Boolean_2 = false;
				}
				base.OnVisibleChanged(eventArgs_0);
			}

			protected override void OnShown(EventArgs eventArgs_0)
			{
				base.OnShown(eventArgs_0);
				if (this.sidebar_0.Content != null)
				{
					this.sidebar_0.Content.Controls[0].Focus();
				}
			}

			protected override void OnClosed(EventArgs eventArgs_0)
			{
				base.OnClosed(eventArgs_0);
				if (this.sidebar_1.DialogStyle == SidebarDialogStyle.Standard || this.sidebar_1.DialogStyle == SidebarDialogStyle.StandardSizable)
				{
					this.sidebar_1.method_5();
				}
				if (this.sidebar_1.ContentLayout == SidebarContentLayout.Custom)
				{
					this.sidebar_1.Text = ((this.sidebar_1.DialogStyle == SidebarDialogStyle.Standard || this.sidebar_1.DialogStyle == SidebarDialogStyle.StandardSizable) ? this.Text : this.Sidebar_0.Text);
					this.sidebar_1.Content = this.Sidebar_0.Content;
				}
				this.sidebar_1.OnDialogClosed(new EventArgs());
			}

			protected override void OnClosing(CancelEventArgs cancelEventArgs_0)
			{
				this.sidebar_0.Boolean_1 = true;
				base.OnClosing(cancelEventArgs_0);
			}

			protected override void OnHandleCreated(EventArgs eventArgs_0)
			{
				this.uint_0 = Class468.smethod_0(null, this);
				Class429.Struct83 struct83_ = default(Class429.Struct83);
				Class429.GetWindowRect(base.Handle, ref struct83_);
				Class468.smethod_1(this.uint_0, struct83_, this);
				base.OnHandleCreated(eventArgs_0);
			}

			protected override void WndProc(ref Message message)
			{
				Class429.Enum121 msg = (Class429.Enum121)message.Msg;
				if (msg == Class429.Enum121.const_55)
				{
					if (!this.sidebar_0.Boolean_1)
					{
						uint num = Class429.smethod_5(message.WParam.ToInt32());
						if (num != this.uint_0)
						{
							this.MinimumSize = new Size(0, 0);
							Class429.Struct83 struct83_ = (Class429.Struct83)Marshal.PtrToStructure(message.LParam, typeof(Class429.Struct83));
							this.Font = new Font(this.Font.Name, this.Font.Size * (float)num / (float)this.uint_0, this.Font.Style, this.Font.Unit);
							this.uint_0 = num;
							Class468.smethod_1(this.uint_0, struct83_, this);
							this.MinimumSize = base.Size;
						}
					}
				}
				else
				{
					base.WndProc(ref message);
				}
			}

			internal void method_0()
			{
				this.sidebar_1.IsShown = false;
				base.Close();
			}

			private Point method_1(Control control_0)
			{
				Control topLevelControl = control_0.TopLevelControl;
				if (topLevelControl != null)
				{
					return new Point(topLevelControl.Location.X + topLevelControl.Width / 2, topLevelControl.Location.Y + topLevelControl.Height / 2);
				}
				return Point.Empty;
			}

			internal void method_2()
			{
				this.sidebar_1.IsPinned = true;
				base.Close();
			}

			internal void method_3(Point point_0, Control control_0)
			{
				if (point_0.IsEmpty)
				{
					int num = base.Width;
					if (this.sidebar_1.TextControl != null)
					{
						point_0 = this.sidebar_1.TextControl.PointToScreen(new Point(this.sidebar_1.TextControl.Width - num - Class517.smethod_45(Class519.Class542.Point_0.X, this.pointF_0.X), Class517.smethod_45(Class519.Class542.Point_0.Y, this.pointF_0.Y)));
					}
					else
					{
						point_0 = this.method_1(control_0);
						if (!point_0.IsEmpty)
						{
							int num2 = ((this.sidebar_1.Content == null) ? this.sidebar_1.Height : this.sidebar_1.Content.Height);
							point_0 = new Point(point_0.X - num / 2, point_0.Y - num2 / 2);
						}
					}
				}
				base.Location = point_0;
			}

			internal void method_4(Size size_0)
			{
				if (size_0.IsEmpty)
				{
					Size size2 = (base.Size = (this.MinimumSize = this.GetPreferredSize(Size.Empty)));
				}
				else
				{
					base.Size = size_0;
				}
			}

			internal void method_5(Control control_0, Point point_0, Size size_0)
			{
				this.sidebar_0.method_0(this.sidebar_1.Content);
				if (this.sidebar_1.Content is ContentPanel)
				{
					ContentPanel contentPanel = this.sidebar_1.Content as ContentPanel;
					if (this.sidebar_1.Content is Class570)
					{
						(this.sidebar_1.Content as Class570).button_2.Visible = true;
						if (this.sidebar_1.ContentLayout == SidebarContentLayout.Replace && this.sidebar_1.enum140_0 == ContentPanel.Enum140.const_0)
						{
							contentPanel.SetAlignment(ContentPanel.Enum140.const_0, this.sidebar_0.pointF_0);
						}
						else
						{
							this.sidebar_0.method_6(DockStyle.Fill, contentPanel, bool_17: false);
						}
					}
					else
					{
						this.sidebar_0.method_6(DockStyle.Fill, contentPanel, bool_17: false);
						if (this.sidebar_1.Content is Class571)
						{
							(this.sidebar_1.Content as Class571).button_2.Visible = true;
						}
					}
				}
				this.sidebar_0.Text = this.sidebar_1.Text;
				base.Show(control_0);
				this.method_4(size_0);
				this.method_3(point_0, control_0);
			}

			private void sidebar_0_MouseEnter(object sender, EventArgs e)
			{
				if (this.sidebar_0.Content == null || base.PointToClient(Control.MousePosition).Y < this.sidebar_0.Content.Location.Y)
				{
					this.Cursor = Cursors.SizeAll;
				}
			}

			private void sidebar_0_MouseDown(object sender, MouseEventArgs e)
			{
				if (e.Button == MouseButtons.Left && (this.sidebar_0.Content == null || e.Y < this.sidebar_0.Content.Location.Y))
				{
					int num = 0;
					int num2 = 0;
					Point point = this.sidebar_0.PointToScreen(this.sidebar_0.Location);
					num = base.Location.X - point.X;
					num2 = base.Location.Y - point.Y;
					this.int_0 = e.X - num;
					this.int_1 = e.Y - num2;
					this.bool_0 = true;
				}
			}

			private void sidebar_0_MouseMove(object sender, MouseEventArgs e)
			{
				if (this.bool_0)
				{
					base.SetDesktopLocation(Control.MousePosition.X - this.int_0, Control.MousePosition.Y - this.int_1);
				}
				else if (this.Cursor == Cursors.SizeAll)
				{
					if (this.sidebar_0.Content != null && base.PointToClient(Control.MousePosition).Y >= this.sidebar_0.Content.Location.Y)
					{
						this.Cursor = Cursors.Default;
					}
				}
				else if (this.sidebar_0.Content == null || base.PointToClient(Control.MousePosition).Y < this.sidebar_0.Content.Location.Y)
				{
					this.Cursor = Cursors.SizeAll;
				}
			}

			private void sidebar_0_MouseUp(object sender, MouseEventArgs e)
			{
				this.bool_0 = false;
			}

			private void sidebar_0_MouseLeave(object sender, EventArgs e)
			{
				this.Cursor = Cursors.Default;
			}
		}

		internal class Class584 : CheckBox
		{
			internal Class584()
			{
				base.FlatStyle = FlatStyle.System;
				base.TabStop = true;
			}

			protected override void WndProc(ref Message message)
			{
				switch (message.Msg)
				{
				default:
					base.WndProc(ref message);
					break;
				case 738:
				case 739:
					this.DefWndProc(ref message);
					break;
				}
			}
		}

		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private SidebarTitleLabel sidebarTitleLabel_0;

		private SidebarPinButton sidebarPinButton_0;

		private SidebarCloseButton sidebarCloseButton_0;

		private Control control_0;

		private SidebarContentLayout sidebarContentLayout_0;

		internal VisualStyleRenderer visualStyleRenderer_0;

		private TextControl textControl_0;

		private bool bool_0 = true;

		private bool bool_1 = true;

		private bool bool_2 = true;

		private bool bool_3 = true;

		private bool bool_4;

		private Form0 form0_0;

		private bool bool_5;

		private bool bool_6;

		private bool bool_7 = true;

		private bool bool_8;

		private bool bool_9;

		private bool bool_10 = true;

		private bool bool_11 = true;

		private Point point_0 = Point.Empty;

		private Size size_0 = Size.Empty;

		private SidebarDialogStyle sidebarDialogStyle_0;

		private Size size_1 = Size.Empty;

		private bool bool_12;

		private bool bool_13;

		private bool bool_14;

		private bool bool_15;

		private Enum141 enum141_0 = Enum141.const_4;

		private Enum141 enum141_1 = Enum141.const_4;

		private Padding padding_0;

		private Rectangle rectangle_0 = Rectangle.Empty;

		private SidebarContentLayout sidebarContentLayout_1 = SidebarContentLayout.Custom;

		private ContentPanel.Enum140 enum140_0;

		private bool bool_16;

		private PointF pointF_0 = PointF.Empty;

		private uint uint_0;

		private int int_0;

		private int int_1;

		private float float_0 = 18f;

		private EventHandler eventHandler_0;

		private EventHandler eventHandler_1;

		private PropertyChangedEventHandler propertyChangedEventHandler_0;

		protected override Size DefaultSize
		{
			get
			{
				if (this.sidebarContentLayout_0 == SidebarContentLayout.Custom && this.control_0 == null)
				{
					return Class519.Class542.Size_2;
				}
				Size result = base.PreferredSize;
				if (this.control_0 is ContentPanel)
				{
					ContentPanel contentPanel = this.control_0 as ContentPanel;
					switch (contentPanel.m_cpaPanelAlignment)
					{
					case ContentPanel.Enum140.const_1:
						result = new Size(base.Width, result.Height);
						break;
					case ContentPanel.Enum140.const_2:
						result = new Size(result.Width, base.Height);
						break;
					}
				}
				return result;
			}
		}

		protected override Padding DefaultPadding => Class519.Class542.Padding_3;

		/// <summary>Overridden. Gets or sets the text that is displayed in the title bar of the Sidebar.</summary>
		[Category("Appearance")]
		[Attribute3("PROP_SIDEBAR_TEXT")]
		[Browsable(true)]
		public override string Text
		{
			get
			{
				if (this.sidebarTitleLabel_0.Text == string.Empty)
				{
					switch (this.ContentLayout)
					{
					case SidebarContentLayout.Goto:
						return this.resourceManager_0.GetString("ID_GOTO_CAPTION");
					case SidebarContentLayout.FieldNavigator:
						return this.resourceManager_0.GetString("ID_FIELDNAVIGATOR_CAPTION");
					case SidebarContentLayout.TrackedChanges:
						return this.resourceManager_0.GetString("ID_TRACKEDCHANGES_CAPTION");
					case SidebarContentLayout.Styles:
						return this.resourceManager_0.GetString("ID_STYLES_CAPTION");
					case SidebarContentLayout.Find:
						return this.resourceManager_0.GetString("ID_FIND_CAPTION");
					case SidebarContentLayout.Replace:
						return this.resourceManager_0.GetString("ID_REPLACE_CAPTION");
					case SidebarContentLayout.ConditionalInstructions:
						return this.resourceManager_0.GetString("ID_CONDITIONALINSTRUCTIONS_CAPTION");
					case SidebarContentLayout.DocumentSettings:
						return this.resourceManager_0.GetString("ID_DOCUMENTSETTINGS_CAPTION");
					}
				}
				return this.sidebarTitleLabel_0.Text;
			}
			set
			{
				string obj = this.sidebarTitleLabel_0.Text;
				string text2 = (this.sidebarTitleLabel_0.Text = value);
				if (obj != text2)
				{
					base.Size = base.PreferredSize;
					this.method_10("Text");
				}
			}
		}

		[Obsolete]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public new int ColumnCount
		{
			get
			{
				return base.ColumnCount;
			}
			set
			{
			}
		}

		[Browsable(false)]
		[Obsolete]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public new TableLayoutColumnStyleCollection ColumnStyles => null;

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[Obsolete]
		public new int RowCount
		{
			get
			{
				return base.RowCount;
			}
			set
			{
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		[Obsolete]
		public new TableLayoutRowStyleCollection RowStyles => null;

		[Obsolete]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		[Browsable(false)]
		public new TableLayoutControlCollection Controls => null;

		protected override bool ScaleChildren => false;

		/// <summary>Gets or sets an object of type System.Windows.Forms.Control that represents the content of the Sidebar.</summary>
		[DefaultValue(null)]
		[Browsable(false)]
		public Control Content
		{
			get
			{
				if (this.bool_8)
				{
					return this.form0_0.Sidebar_0.Content;
				}
				return this.control_0;
			}
			set
			{
				if (this.sidebarContentLayout_0 != SidebarContentLayout.Custom)
				{
					return;
				}
				Control value2 = this.control_0;
				if (this.control_0 != (this.control_0 = value))
				{
					base.Controls.Remove(value2);
					if (this.control_0 != null)
					{
						this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
						base.Controls.Add(this.control_0, 0, 1);
						base.SetColumnSpan(this.control_0, (this.bool_2 || this.enum140_0 != ContentPanel.Enum140.const_1) ? 3 : ((this.bool_0 || this.bool_1) ? 1 : 3));
					}
					this.method_10("Content");
				}
			}
		}

		/// <summary>Determines the content layout that has to be intialized and rendered for the Sidebar.</summary>
		[Attribute3("PROP_CONTENTLAYOUT")]
		[DefaultValue(SidebarContentLayout.None)]
		[Category("Layout")]
		public SidebarContentLayout ContentLayout
		{
			get
			{
				return this.sidebarContentLayout_0;
			}
			set
			{
				if (this.sidebarContentLayout_0 != value)
				{
					this.sidebarContentLayout_1 = this.sidebarContentLayout_0;
					this.sidebarContentLayout_0 = value;
					this.method_6(this.Dock, null, bool_17: true);
					this.method_10("ContentLayout");
				}
			}
		}

		/// <summary>Gets or sets the location of the dialog where the Sidebar is placed, if the Sidebar.IsPinned property is set to false.</summary>
		[Attribute3("PROP_DIALOGLOCATION")]
		[Category("Layout")]
		[DefaultValue(typeof(Point), "0,0")]
		public Point DialogLocation
		{
			get
			{
				if (this.form0_0 != null)
				{
					this.point_0 = this.form0_0.Location;
				}
				return this.point_0;
			}
			set
			{
				if (this.DialogLocation != (this.point_0 = value))
				{
					if (this.form0_0 != null)
					{
						this.form0_0.method_3(this.point_0, this);
					}
					this.method_10("DialogLocation");
				}
			}
		}

		/// <summary>Gets or sets the size of the dialog where the Sidebar is placed, if the Sidebar.IsPinned property is set to false.</summary>
		[Attribute3("PROP_DIALOGSIZE")]
		[Category("Layout")]
		[DefaultValue(typeof(Size), "0,0")]
		public Size DialogSize
		{
			get
			{
				if (this.form0_0 != null)
				{
					this.size_0 = this.form0_0.Size;
				}
				return this.size_0;
			}
			set
			{
				if (this.DialogSize != (this.size_0 = value))
				{
					if (this.form0_0 != null)
					{
						this.form0_0.method_4(this.size_0);
					}
					this.method_10("DialogSize");
				}
			}
		}

		/// <summary>Gets or sets the requested border and title bar layout of the sidebar dialog.</summary>
		[Category("Layout")]
		[DefaultValue(SidebarDialogStyle.Standard)]
		[Attribute3("PROP_ISPINNED")]
		public SidebarDialogStyle DialogStyle
		{
			get
			{
				return this.sidebarDialogStyle_0;
			}
			set
			{
				if (this.sidebarDialogStyle_0 != (this.sidebarDialogStyle_0 = value))
				{
					this.method_10("DialogStyle");
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether the Sidebar is rendered inside another control (property value is set to true) or displayed as dialog.</summary>
		[Category("Layout")]
		[Attribute3("PROP_ISPINNED")]
		[DefaultValue(true)]
		public bool IsPinned
		{
			get
			{
				return this.bool_3;
			}
			set
			{
				if (this.bool_3 != (this.bool_3 = value))
				{
					if (!this.Boolean_0 && this.bool_7 && !base.DesignMode)
					{
						this.bool_4 = true;
						bool visible = (this.Boolean_4 = this.bool_3);
						base.Visible = visible;
						this.bool_4 = false;
						this.Boolean_3 = !this.bool_3;
						this.method_3();
					}
					this.method_10("IsPinned");
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether the Sidebar is shown.</summary>
		[DefaultValue(true)]
		[Category("Appearance")]
		[Attribute3("PROP_ISSHOWN")]
		public bool IsShown
		{
			get
			{
				return this.bool_7;
			}
			set
			{
				if (this.bool_7 == (this.bool_7 = value) || base.DesignMode)
				{
					return;
				}
				if (this.textControl_0 != null)
				{
					if (this.control_0 is Class570)
					{
						if (this.bool_7 && (this.control_0 as Class570).textBox_0.Text.Length == 0 && this.textControl_0.Selection.Length > 0)
						{
							(this.control_0 as Class570).textBox_0.Text = this.textControl_0.Selection.Text;
						}
						else
						{
							(this.control_0 as Class570).textBox_0.Text = "";
						}
					}
					else if (this.control_0 is Class573)
					{
						(this.control_0 as Class573).class586_0.Boolean_0 = this.bool_7;
					}
				}
				if (this.bool_7 && this.control_0 is ContentPanel)
				{
					(this.control_0 as ContentPanel).UpdateContent();
				}
				if (this.bool_3)
				{
					bool visible = (this.Boolean_4 = this.bool_7);
					base.Visible = visible;
				}
				else
				{
					this.Boolean_3 = this.bool_7;
				}
				this.method_10("IsShown");
			}
		}

		/// <summary>Gets or sets a value indicating whether the Sidebar can be sized with the mouse.</summary>
		[DefaultValue(true)]
		[Attribute3("PROP_ISSIZABLE")]
		[Category("Behavior")]
		public bool IsSizable
		{
			get
			{
				return this.bool_10;
			}
			set
			{
				if (this.bool_10 != (this.bool_10 = value))
				{
					this.method_10("IsSizable");
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether the Sidebar's close button is shown.</summary>
		[DefaultValue(true)]
		[Category("Appearance")]
		[Attribute3("PROP_SHOWCLOSEBUTTON")]
		public bool ShowCloseButton
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				if (this.bool_0 == (this.bool_0 = value))
				{
					return;
				}
				if (this.sidebarCloseButton_0.Visible = this.bool_0)
				{
					if (!this.pointF_0.IsEmpty)
					{
						base.ColumnStyles[2].Width = Class517.smethod_45(Class519.Class542.Size_1.Width + Class519.Class542.Padding_2.Horizontal, this.pointF_0.X);
					}
				}
				else
				{
					base.ColumnStyles[2].Width = 0f;
				}
				if (this.control_0 != null && !this.bool_2 && this.enum140_0 == ContentPanel.Enum140.const_1)
				{
					base.SetColumnSpan(this.control_0, (this.bool_0 || this.bool_1) ? 1 : 3);
				}
				this.method_10("ShowCloseButton");
			}
		}

		/// <summary>Gets or sets a value indicating whether the Sidebar's pin button is shown.</summary>
		[Attribute3("PROP_SHOWPINBUTTON")]
		[Category("Appearance")]
		[DefaultValue(true)]
		public bool ShowPinButton
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				if (this.bool_1 == (this.bool_1 = value))
				{
					return;
				}
				if (this.sidebarPinButton_0.Visible = this.bool_1)
				{
					if (!this.pointF_0.IsEmpty)
					{
						base.ColumnStyles[1].Width = Class517.smethod_45(Class519.Class542.Size_0.Width + Class519.Class542.Padding_1.Horizontal, this.pointF_0.X);
					}
				}
				else
				{
					base.ColumnStyles[1].Width = 0f;
				}
				if (this.control_0 != null && !this.bool_2 && this.enum140_0 == ContentPanel.Enum140.const_1)
				{
					base.SetColumnSpan(this.control_0, (this.bool_0 || this.bool_1) ? 1 : 3);
				}
				this.method_10("ShowPinButton");
			}
		}

		/// <summary>Gets or sets a value indicating whether the Sidebar's title is shown.</summary>
		[Category("Appearance")]
		[DefaultValue(true)]
		[Attribute3("PROP_SHOWTITLE")]
		public bool ShowTitle
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				if (this.bool_2 == (this.bool_2 = value))
				{
					return;
				}
				this.sidebarTitleLabel_0.Visible = this.bool_2;
				if (!this.bool_2 && this.enum140_0 == ContentPanel.Enum140.const_1)
				{
					base.SetRow(this.sidebarPinButton_0, 1);
					base.SetRow(this.sidebarCloseButton_0, 1);
					if (this.control_0 != null)
					{
						base.SetColumnSpan(this.control_0, (this.bool_0 || this.bool_1) ? 1 : 3);
					}
				}
				else
				{
					base.SetRow(this.sidebarPinButton_0, 0);
					base.SetRow(this.sidebarCloseButton_0, 0);
					if (this.control_0 != null)
					{
						base.SetColumnSpan(this.control_0, 3);
					}
				}
				base.Size = base.PreferredSize;
				this.method_10("ShowTitleBar");
			}
		}

		/// <summary>Gets or sets the TextControl that is used for the predefined TextControl feature layouts.</summary>
		[Category("Behavior")]
		[Attribute3("PROP_TEXTCONTROL")]
		[DefaultValue(null)]
		public TextControl TextControl
		{
			get
			{
				return this.textControl_0;
			}
			set
			{
				if (this.textControl_0 != (this.textControl_0 = value))
				{
					if (this.control_0 is ContentPanel)
					{
						(this.control_0 as ContentPanel).TextControl = this.textControl_0;
					}
					this.method_10("TextControl");
				}
			}
		}

		/// <summary>Gets or sets the font of the title bar's text.</summary>
		[DefaultValue(typeof(Font), "Calibri Light, 18")]
		[Attribute3("PROP_TITLEFONT")]
		[Category("Appearance")]
		public Font TitleFont
		{
			get
			{
				return this.sidebarTitleLabel_0.Font;
			}
			set
			{
				if (this.sidebarTitleLabel_0.Font.ToString() != value.ToString())
				{
					this.sidebarTitleLabel_0.Font = value;
					if (base.IsHandleCreated)
					{
						Graphics graphics = base.CreateGraphics();
						this.float_0 = this.sidebarTitleLabel_0.Font.Size * 96f / graphics.DpiX;
						graphics.Dispose();
					}
					base.Size = base.PreferredSize;
					this.method_10("TitleFont");
				}
			}
		}

		/// <summary>Gets or sets the color of the title bar's text.</summary>
		[Attribute3("PROP_TITLEFORECOLOR")]
		[DefaultValue(typeof(Color), "255, 43, 87, 154")]
		[Category("Appearance")]
		public Color TitleForeColor
		{
			get
			{
				return this.sidebarTitleLabel_0.ForeColor;
			}
			set
			{
				int num = this.sidebarTitleLabel_0.ForeColor.ToArgb();
				Color color2 = (this.sidebarTitleLabel_0.ForeColor = value);
				Color color3 = color2;
				if (num != color3.ToArgb())
				{
					this.method_10("TitleForeColor");
				}
			}
		}

		internal bool Boolean_0
		{
			get
			{
				return this.bool_5;
			}
			set
			{
				if (this.bool_5 = value)
				{
					this.sidebarPinButton_0.String_0 = this.resourceManager_0.GetString("TOOLTIP_PinSidebar");
				}
				else
				{
					this.sidebarPinButton_0.String_0 = this.resourceManager_0.GetString("TOOLTIP_UnpinSidebar");
				}
			}
		}

		internal bool Boolean_1
		{
			get
			{
				return this.bool_6;
			}
			set
			{
				this.bool_6 = value;
			}
		}

		internal System.Drawing.Image Image_0
		{
			get
			{
				return this.sidebarPinButton_0.Image_0;
			}
			set
			{
				this.sidebarPinButton_0.Image_0 = value;
			}
		}

		internal SidebarContentLayout SidebarContentLayout_0 => this.sidebarContentLayout_1;

		internal bool Boolean_2
		{
			get
			{
				return this.bool_11;
			}
			set
			{
				if (this.bool_11 != (this.bool_11 = value))
				{
					this.sidebarCloseButton_0.Visible = this.bool_11 && this.bool_0;
					this.sidebarPinButton_0.Visible = this.bool_11 && this.bool_1;
					this.sidebarTitleLabel_0.Visible = this.bool_11;
				}
			}
		}

		internal bool Boolean_3
		{
			get
			{
				return this.bool_8;
			}
			set
			{
				if (value)
				{
					if (this.bool_7)
					{
						this.OnDialogOpening(new EventArgs());
						this.form0_0 = new Form0(this);
						this.form0_0.method_5(this, this.point_0, this.size_0);
					}
				}
				else
				{
					if (this.DialogStyle == SidebarDialogStyle.Sidebar || this.DialogStyle == SidebarDialogStyle.SidebarSizable)
					{
						this.point_0 = this.form0_0.Location;
						this.size_0 = this.form0_0.Size;
						this.method_0(this.control_0);
						if (this.Content is Class571)
						{
							(this.Content as Class571).button_2.Visible = false;
						}
						else if (this.Content is Class570)
						{
							(this.Content as Class570).button_2.Visible = false;
							if (this.sidebarContentLayout_0 == SidebarContentLayout.Replace && this.enum140_0 == ContentPanel.Enum140.const_0)
							{
								(this.Content as ContentPanel).SetAlignment(ContentPanel.Enum140.const_0, this.pointF_0);
							}
						}
						this.method_6(this.Dock, this.Content as ContentPanel, this.bool_16);
					}
					if (this.form0_0 != null)
					{
						this.form0_0.Close();
						this.form0_0 = null;
					}
				}
				this.bool_8 = value;
			}
		}

		internal bool Boolean_4
		{
			get
			{
				return this.bool_9;
			}
			set
			{
				if (this.bool_9 != (this.bool_9 = value) && this.bool_9)
				{
					this.method_2(bool_17: false);
					this.method_0(this.control_0);
				}
			}
		}

		internal event EventHandler DialogOpening
		{
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

		internal event EventHandler DialogClosed
		{
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

		public event PropertyChangedEventHandler PropertyChanged
		{
			add
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChangedEventHandler_0;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange(ref this.propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
				}
				while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
			}
			remove
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChangedEventHandler_0;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange(ref this.propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
				}
				while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
			}
		}

		/// <summary>Initializes a new instance of the Sidebar class.</summary>
		public Sidebar()
		{
			base.SetStyle(ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, value: true);
			try
			{
				this.visualStyleRenderer_0 = new VisualStyleRenderer(VisualStyleElement.Tab.Pane.Normal);
			}
			catch
			{
			}
			this.Font = SystemFonts.MenuFont;
			base.Size = this.DefaultSize;
			this.sidebarTitleLabel_0 = new SidebarTitleLabel(this);
			this.sidebarPinButton_0 = new SidebarPinButton(this);
			this.sidebarCloseButton_0 = new SidebarCloseButton(this);
			base.SuspendLayout();
			base.RowCount = 2;
			base.RowStyles.Add(new RowStyle());
			base.RowStyles.Add(new RowStyle(SizeType.Percent, 100f));
			base.ColumnCount = 3;
			base.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
			base.ColumnStyles.Add(new ColumnStyle());
			base.ColumnStyles.Add(new ColumnStyle());
			base.Controls.Add(this.sidebarTitleLabel_0, 0, 0);
			base.Controls.Add(this.sidebarPinButton_0, 1, 0);
			base.Controls.Add(this.sidebarCloseButton_0, 2, 0);
			base.ResumeLayout(performLayout: false);
		}

		public bool ShouldSerializeText()
		{
			return this.ContentLayout switch
			{
				SidebarContentLayout.Goto => this.sidebarTitleLabel_0.Text != this.resourceManager_0.GetString("ID_GOTO_CAPTION"), 
				SidebarContentLayout.FieldNavigator => this.sidebarTitleLabel_0.Text != this.resourceManager_0.GetString("ID_FIELDNAVIGATOR_CAPTION"), 
				SidebarContentLayout.TrackedChanges => this.sidebarTitleLabel_0.Text != this.resourceManager_0.GetString("ID_TRACKEDCHANGES_CAPTION"), 
				SidebarContentLayout.Styles => this.sidebarTitleLabel_0.Text != this.resourceManager_0.GetString("ID_STYLES_CAPTION"), 
				SidebarContentLayout.Find => this.sidebarTitleLabel_0.Text != this.resourceManager_0.GetString("ID_FIND_CAPTION"), 
				SidebarContentLayout.Replace => this.sidebarTitleLabel_0.Text != this.resourceManager_0.GetString("ID_REPLACE_CAPTION"), 
				SidebarContentLayout.ConditionalInstructions => this.sidebarTitleLabel_0.Text != this.resourceManager_0.GetString("ID_CONDITIONALINSTRUCTIONS_CAPTION"), 
				SidebarContentLayout.DocumentSettings => this.sidebarTitleLabel_0.Text != this.resourceManager_0.GetString("ID_DOCUMENTSETTINGS_CAPTION"), 
				_ => true, 
			};
		}

		public Control FindItem(FieldNavigatorItem item)
		{
			if (this.control_0 is TXITEM_MainPanel)
			{
				return (this.control_0 as ContentPanel).FindItem(item.ToString());
			}
			return null;
		}

		public Control FindItem(FindAndReplaceItem item)
		{
			if (this.control_0 is Class570)
			{
				return (this.control_0 as ContentPanel).FindItem(item.ToString());
			}
			return null;
		}

		public Control FindItem(GotoItem item)
		{
			if (this.control_0 is Class571)
			{
				return (this.control_0 as ContentPanel).FindItem(item.ToString());
			}
			return null;
		}

		public Control FindItem(StylesItem item)
		{
			if (this.control_0 is Class572)
			{
				return (this.control_0 as ContentPanel).FindItem(item.ToString());
			}
			return null;
		}

		public Control FindItem(TrackedChangesItem item)
		{
			if (this.control_0 is Class573)
			{
				return (this.control_0 as ContentPanel).FindItem(item.ToString());
			}
			return null;
		}

		public Control FindItem(ConditionalInstructionsItem item)
		{
			if (this.control_0 is Class568)
			{
				return (this.control_0 as ContentPanel).FindItem(item.ToString());
			}
			return null;
		}

		public Control FindItem(DocumentSettingsItem item)
		{
			if (this.control_0 is Class569)
			{
				return (this.control_0 as ContentPanel).FindItem(item.ToString());
			}
			return null;
		}

		protected virtual void OnDialogOpening(EventArgs eventArgs_0)
		{
			this.eventHandler_0?.Invoke(this, eventArgs_0);
		}

		protected virtual void OnDialogClosed(EventArgs eventArgs_0)
		{
			this.eventHandler_1?.Invoke(this, eventArgs_0);
		}

		protected override void OnDockChanged(EventArgs eventArgs_0)
		{
			if (this.control_0 != null && this.bool_3)
			{
				this.method_6(this.Dock, this.control_0 as ContentPanel, bool_17: true);
			}
			this.bool_16 = this.bool_8;
			base.OnDockChanged(eventArgs_0);
		}

		public override Size GetPreferredSize(Size proposedSize)
		{
			Size preferredSize = base.GetPreferredSize(proposedSize);
			int val = ((this.sidebarTitleLabel_0 != null && this.sidebarPinButton_0 != null && this.sidebarCloseButton_0 != null) ? (this.sidebarTitleLabel_0.PreferredSize.Width + this.sidebarTitleLabel_0.Margin.Horizontal + this.sidebarPinButton_0.PreferredSize.Width + this.sidebarPinButton_0.Margin.Horizontal + this.sidebarCloseButton_0.PreferredSize.Width + this.sidebarCloseButton_0.Margin.Horizontal + base.Padding.Horizontal + base.Margin.Horizontal) : 0);
			return new Size(Math.Max(preferredSize.Width, val), preferredSize.Height);
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			Graphics graphics = base.CreateGraphics();
			if (this.uint_0 == 0)
			{
				this.pointF_0 = new PointF(graphics.DpiX, graphics.DpiY);
			}
			if (!this.bool_5)
			{
				this.float_0 = this.sidebarTitleLabel_0.Font.Size * 96f / graphics.DpiX;
			}
			bool bool_ = false;
			if (this.uint_0 != 0 && (float)this.uint_0 != graphics.DpiX && this.Font.IsSystemFont)
			{
				this.sidebarTitleLabel_0.Font = new Font(this.sidebarTitleLabel_0.Font.FontFamily, this.float_0 * (float)this.uint_0 / graphics.DpiX);
				this.Font = Class467.smethod_1(this.uint_0);
				bool_ = true;
			}
			graphics.Dispose();
			this.method_1();
			this.method_2(bool_);
			this.method_3();
			base.OnHandleCreated(eventArgs_0);
		}

		protected override void OnMouseEnter(EventArgs eventargs)
		{
			base.OnMouseEnter(eventargs);
			this.method_4();
		}

		protected override void OnMouseLeave(EventArgs eventargs)
		{
			base.OnMouseLeave(eventargs);
			if (!this.bool_5 && this.bool_10 && !this.AutoSize)
			{
				this.bool_12 = false;
				this.Cursor = Cursors.Default;
			}
		}

		protected override void OnMouseMove(MouseEventArgs mevent)
		{
			base.OnMouseMove(mevent);
			this.method_4();
		}

		protected override void OnMouseDown(MouseEventArgs mevent)
		{
			base.OnMouseDown(mevent);
			if (!this.bool_5 && this.bool_10 && this.bool_13 && !this.AutoSize)
			{
				Point point = base.PointToScreen(mevent.Location);
				this.rectangle_0 = new Rectangle(point.X, point.Y, base.Width, base.Height);
				this.size_1 = base.PreferredSize;
				this.bool_12 = true;
			}
			else
			{
				this.bool_12 = false;
			}
		}

		protected override void OnMouseUp(MouseEventArgs mevent)
		{
			base.OnMouseUp(mevent);
			if (!this.bool_5 && this.bool_10 && !this.AutoSize)
			{
				this.bool_12 = false;
				this.method_4();
			}
		}

		protected override void OnPaint(PaintEventArgs pea)
		{
			if (this.visualStyleRenderer_0 != null && (!this.bool_5 || this.sidebarDialogStyle_0 == SidebarDialogStyle.Sidebar || this.sidebarDialogStyle_0 == SidebarDialogStyle.SidebarSizable))
			{
				this.visualStyleRenderer_0.DrawBackground(pea.Graphics, new Rectangle(0, 0, base.Width, base.Height));
			}
			base.OnPaint(pea);
		}

		protected override void OnRightToLeftChanged(EventArgs eventArgs_0)
		{
			this.method_8();
			base.OnRightToLeftChanged(eventArgs_0);
		}

		protected override void OnSizeChanged(EventArgs eventArgs_0)
		{
			if (!this.bool_4)
			{
				this.int_1 = Class517.smethod_60(base.Height, this.pointF_0);
				this.int_0 = Class517.smethod_60(base.Width, this.pointF_0);
			}
			base.OnSizeChanged(eventArgs_0);
		}

		protected override void WndProc(ref Message message)
		{
			bool flag = false;
			switch (message.Msg)
			{
			case 738:
			{
				uint num = Class429.smethod_15(message.HWnd);
				if (num != 0 && num != this.uint_0)
				{
					this.pointF_0 = new PointF(num, num);
					this.Font = new Font(this.Font.FontFamily, this.Font.SizeInPoints * (float)num / (float)this.uint_0, this.Font.Style, GraphicsUnit.Point, this.Font.GdiCharSet, this.Font.GdiVerticalFont);
					this.uint_0 = num;
					this.method_1();
					if (!this.bool_6 && (this.bool_3 || this.bool_5))
					{
						this.method_2(bool_17: false);
						this.method_3();
					}
				}
				flag = true;
				break;
			}
			case 1:
				this.uint_0 = Class429.smethod_15(message.HWnd);
				if (this.uint_0 != 0)
				{
					this.pointF_0 = new PointF(this.uint_0, this.uint_0);
				}
				break;
			}
			if (!flag)
			{
				base.WndProc(ref message);
			}
		}

		private void method_0(Control control_1)
		{
			if (!base.Controls.Contains(control_1))
			{
				Control value = this.control_0;
				this.control_0 = control_1;
				base.Controls.Remove(value);
				if (this.control_0 != null)
				{
					base.Controls.Add(this.control_0, 0, 1);
					base.SetColumnSpan(this.control_0, (this.bool_2 || this.enum140_0 != ContentPanel.Enum140.const_1) ? 3 : ((this.bool_0 || this.bool_1) ? 1 : 3));
				}
			}
		}

		private void method_1()
		{
			this.sidebarTitleLabel_0.Font = new Font(this.sidebarTitleLabel_0.Font.FontFamily, this.float_0 * this.pointF_0.X / 96f);
			Class517.smethod_0(this.pointF_0);
			this.padding_0 = Class517.smethod_51(Class519.Class542.Padding_0, this.pointF_0);
			this.sidebarTitleLabel_0.Margin = Class517.smethod_51(Class519.Class542.Padding_4, this.pointF_0);
			this.sidebarPinButton_0.Margin = Class517.smethod_51(Class519.Class542.Padding_1, this.pointF_0);
			Size size3 = (this.sidebarPinButton_0.MaximumSize = (this.sidebarPinButton_0.MinimumSize = Class517.smethod_48(Class519.Class542.Size_0, this.pointF_0)));
			this.sidebarPinButton_0.Rectangle_0 = new Rectangle(new Point(0, 0), Class517.smethod_48(Class519.Class542.Size_0, this.pointF_0));
			this.sidebarPinButton_0.Image_0 = Class517.Bitmap_10;
			if (this.ShowPinButton)
			{
				base.ColumnStyles[1].Width = Class517.smethod_45(Class519.Class542.Size_0.Width + Class519.Class542.Padding_1.Horizontal, this.pointF_0.X);
			}
			this.sidebarCloseButton_0.Margin = Class517.smethod_51(Class519.Class542.Padding_2, this.pointF_0);
			Size size6 = (this.sidebarCloseButton_0.MaximumSize = (this.sidebarCloseButton_0.MinimumSize = Class517.smethod_48(Class519.Class542.Size_1, this.pointF_0)));
			this.sidebarCloseButton_0.Rectangle_0 = new Rectangle(new Point(0, 0), Class517.smethod_48(Class519.Class542.Size_1, this.pointF_0));
			this.sidebarCloseButton_0.Image_0 = Class517.Bitmap_9;
			if (this.ShowCloseButton)
			{
				base.ColumnStyles[2].Width = Class517.smethod_45(Class519.Class542.Size_1.Width + Class519.Class542.Padding_2.Horizontal, this.pointF_0.X);
			}
		}

		private void method_2(bool bool_17)
		{
			if (this.control_0 is ContentPanel)
			{
				(this.control_0 as ContentPanel).AwareOfDPI(this.pointF_0);
				if (bool_17)
				{
					(this.control_0 as ContentPanel).HandleFontUpdated();
				}
			}
		}

		private void method_3()
		{
			if (!this.bool_5 && !base.DesignMode)
			{
				this.MinimumSize = Size.Empty;
				Size preferredSize = base.PreferredSize;
				Size size2 = (base.Size = new Size(Math.Max(preferredSize.Width, Class517.smethod_61(this.int_0, this.pointF_0)), Math.Max(preferredSize.Height, Class517.smethod_61(this.int_1, this.pointF_0))));
				this.MinimumSize = new Size(Math.Min(base.Width, preferredSize.Width), Math.Min(base.Height, preferredSize.Height));
			}
		}

		private void method_4()
		{
			if (!this.bool_5 && this.bool_10 && !this.AutoSize)
			{
				if (!this.bool_12)
				{
					this.method_9(base.PointToClient(Control.MousePosition));
				}
				else
				{
					this.method_7();
				}
			}
		}

		internal void method_5()
		{
			this.point_0 = this.form0_0.Location;
			this.size_0 = this.form0_0.Size;
			this.form0_0 = null;
			this.bool_8 = false;
			this.method_0(this.control_0);
			if (this.control_0 is Class571)
			{
				(this.Content as Class571).button_2.Visible = false;
			}
			else if (this.Content is Class570)
			{
				(this.Content as Class570).button_2.Visible = false;
				if (this.sidebarContentLayout_0 == SidebarContentLayout.Replace && this.enum140_0 == ContentPanel.Enum140.const_0)
				{
					(this.Content as ContentPanel).SetAlignment(ContentPanel.Enum140.const_0, this.pointF_0);
				}
			}
			this.method_6(this.Dock, this.control_0 as ContentPanel, this.bool_16);
			if (this.bool_7 != (this.bool_7 = this.bool_3 && this.bool_7))
			{
				if (this.bool_7 && this.control_0 is ContentPanel)
				{
					(this.control_0 as ContentPanel).UpdateContent();
				}
				this.method_10("IsShown");
			}
		}

		internal void method_6(DockStyle dockStyle_0, ContentPanel contentPanel_0, bool bool_17)
		{
			int num;
			switch (dockStyle_0)
			{
			default:
				num = 0;
				break;
			case DockStyle.Top:
			case DockStyle.Bottom:
				num = 1;
				break;
			case DockStyle.Left:
			case DockStyle.Right:
				num = 2;
				break;
			}
			this.enum140_0 = (ContentPanel.Enum140)num;
			if (contentPanel_0 != null)
			{
				ContentPanel.Enum140 panelAlignment = contentPanel_0.PanelAlignment;
				ContentPanel.Enum140 enum2 = (contentPanel_0.PanelAlignment = this.enum140_0);
				if (panelAlignment != enum2 && bool_17)
				{
					base.Size = base.PreferredSize;
				}
				return;
			}
			if (this.control_0 != null)
			{
				if (this.control_0 is ContentPanel)
				{
					(this.control_0 as ContentPanel).TextControl = null;
				}
				base.Controls.Remove(this.control_0);
			}
			switch (this.sidebarContentLayout_0)
			{
			case SidebarContentLayout.None:
			case SidebarContentLayout.Custom:
				this.Text = base.Name;
				base.Size = this.DefaultSize;
				this.control_0 = null;
				return;
			case SidebarContentLayout.Goto:
			{
				this.Text = this.resourceManager_0.GetString("ID_GOTO_CAPTION");
				this.control_0 = new Class571(this.enum140_0, this.textControl_0, base.DesignMode, this.sidebarContentLayout_0, this.pointF_0)
				{
					Sidebar = this
				};
				Control control = (this.control_0 as ContentPanel).FindItem(GotoItem.TXITEM_Close.ToString());
				if (control != null)
				{
					control.Visible = false;
				}
				break;
			}
			case SidebarContentLayout.FieldNavigator:
				this.Text = this.resourceManager_0.GetString("ID_FIELDNAVIGATOR_CAPTION");
				this.control_0 = new TXITEM_MainPanel(this.enum140_0, this.textControl_0, base.DesignMode, this.sidebarContentLayout_0, this.pointF_0)
				{
					BackColor = Color.Transparent,
					Sidebar = this
				};
				break;
			case SidebarContentLayout.TrackedChanges:
				this.Text = this.resourceManager_0.GetString("ID_TRACKEDCHANGES_CAPTION");
				this.control_0 = new Class573(this.enum140_0, this.textControl_0, base.DesignMode, this.sidebarContentLayout_0, this.pointF_0)
				{
					Sidebar = this
				};
				if (!base.DesignMode)
				{
					(this.control_0 as Class573).class586_0.Boolean_0 = this.bool_7;
				}
				break;
			case SidebarContentLayout.Styles:
				this.Text = this.resourceManager_0.GetString("ID_STYLES_CAPTION");
				this.control_0 = new Class572(this.enum140_0, this.textControl_0, base.DesignMode, this.sidebarContentLayout_0, this.pointF_0)
				{
					Sidebar = this
				};
				break;
			case SidebarContentLayout.Find:
				this.Text = this.resourceManager_0.GetString("ID_FIND_CAPTION");
				this.control_0 = new Class570(this.enum140_0, this.textControl_0, base.DesignMode, this.sidebarContentLayout_0, this.pointF_0)
				{
					Sidebar = this
				};
				break;
			case SidebarContentLayout.Replace:
				this.Text = this.resourceManager_0.GetString("ID_REPLACE_CAPTION");
				this.control_0 = new Class570(this.enum140_0, this.textControl_0, base.DesignMode, this.sidebarContentLayout_0, this.pointF_0)
				{
					Sidebar = this
				};
				break;
			case SidebarContentLayout.ConditionalInstructions:
				this.Text = this.resourceManager_0.GetString("ID_CONDITIONALINSTRUCTIONS_CAPTION");
				this.control_0 = new Class568(this.enum140_0, this.textControl_0, base.DesignMode, this.sidebarContentLayout_0, this.pointF_0)
				{
					Sidebar = this
				};
				break;
			case SidebarContentLayout.DocumentSettings:
				this.Text = this.resourceManager_0.GetString("ID_DOCUMENTSETTINGS_CAPTION");
				this.control_0 = new Class569(this.enum140_0, this.textControl_0, base.DesignMode, this.sidebarContentLayout_0, this.pointF_0)
				{
					Sidebar = this
				};
				break;
			}
			this.control_0.Dock = DockStyle.Fill;
			this.method_8();
			base.Controls.Add(this.control_0, 0, 1);
			base.SetColumnSpan(this.control_0, (this.bool_2 || this.enum140_0 != ContentPanel.Enum140.const_1) ? 3 : ((this.bool_0 || this.bool_1) ? 1 : 3));
			if (bool_17)
			{
				base.Size = base.PreferredSize;
			}
			this.method_10("Content");
		}

		private void method_7()
		{
			if (this.bool_14 && this.bool_15)
			{
				int num = ((this.enum141_0 == Enum141.const_1) ? (this.rectangle_0.Y - Control.MousePosition.Y) : (Control.MousePosition.Y - this.rectangle_0.Y));
				int num2 = ((this.enum141_1 == Enum141.const_0) ? (this.rectangle_0.X - Control.MousePosition.X) : (Control.MousePosition.X - this.rectangle_0.X));
				if (this.Dock == DockStyle.None && (this.enum141_0 == Enum141.const_1 || this.enum141_1 == Enum141.const_0))
				{
					Size size = (this.MaximumSize.IsEmpty ? new Size(int.MaxValue, int.MaxValue) : this.MaximumSize);
					int num3;
					int num4;
					if (this.enum141_1 == Enum141.const_0)
					{
						num3 = Math.Max(this.size_1.Width, Math.Min(this.rectangle_0.Width + num2 * 2, size.Width));
						num2 = (num3 - this.rectangle_0.Width) / 2;
						num4 = base.Location.X - num2;
						this.rectangle_0.X -= num2;
						this.rectangle_0.Width += num2;
					}
					else
					{
						num4 = base.Location.X;
						num3 = Math.Max(this.size_1.Width, this.rectangle_0.Width + num2);
					}
					int num5;
					int num6;
					if (this.enum141_0 == Enum141.const_1)
					{
						num5 = Math.Max(this.size_1.Height, Math.Min(this.rectangle_0.Height + num * 2, size.Height));
						num = (num5 - this.rectangle_0.Height) / 2;
						num6 = base.Location.Y - num;
						this.rectangle_0.Y -= num;
						this.rectangle_0.Height += num;
					}
					else
					{
						num6 = base.Location.Y;
						num5 = Math.Max(this.size_1.Height, this.rectangle_0.Height + num);
					}
					base.Bounds = new Rectangle(num4, num6, num3, num5);
				}
				else
				{
					base.Size = new Size(Math.Max(this.size_1.Width, this.rectangle_0.Width + num2), Math.Max(this.size_1.Height, this.rectangle_0.Height + num));
				}
				return;
			}
			Size size2 = (this.MaximumSize.IsEmpty ? new Size(int.MaxValue, int.MaxValue) : this.MaximumSize);
			if (this.bool_15)
			{
				int num7 = ((this.enum141_0 == Enum141.const_1) ? (this.rectangle_0.Y - Control.MousePosition.Y) : (Control.MousePosition.Y - this.rectangle_0.Y));
				if (this.Dock == DockStyle.None && this.enum141_0 == Enum141.const_1)
				{
					int num8 = Math.Max(this.size_1.Height, Math.Min(this.rectangle_0.Height + num7 * 2, size2.Height));
					num7 = (num8 - this.rectangle_0.Height) / 2;
					base.Bounds = new Rectangle(base.Location.X, base.Location.Y - num7, base.Width, num8);
					this.rectangle_0.Y -= num7;
					this.rectangle_0.Height += num7;
				}
				else
				{
					base.Height = Math.Max(this.size_1.Height, this.rectangle_0.Height + num7);
				}
			}
			else if (this.bool_14)
			{
				int num9 = ((this.enum141_1 == Enum141.const_0) ? (this.rectangle_0.X - Control.MousePosition.X) : (Control.MousePosition.X - this.rectangle_0.X));
				if (this.Dock == DockStyle.None && this.enum141_1 == Enum141.const_0)
				{
					int num10 = Math.Max(this.size_1.Width, Math.Min(this.rectangle_0.Width + num9 * 2, size2.Width));
					num9 = (num10 - this.rectangle_0.Width) / 2;
					base.Bounds = new Rectangle(base.Location.X - num9, base.Location.Y, num10, base.Height);
					this.rectangle_0.X -= num9;
					this.rectangle_0.Width += num9;
				}
				else
				{
					base.Width = Math.Max(this.size_1.Width, this.rectangle_0.Width + num9);
				}
			}
		}

		private void method_8()
		{
			if (this.control_0 != null && this.RightToLeft != this.control_0.RightToLeft)
			{
				this.control_0.RightToLeft = this.RightToLeft;
			}
		}

		private void method_9(Point point_1)
		{
			this.enum141_1 = ((point_1.X >= this.padding_0.Left) ? ((point_1.X > base.Width - this.padding_0.Right) ? Enum141.const_2 : Enum141.const_4) : Enum141.const_0);
			this.enum141_0 = ((point_1.Y < this.padding_0.Top) ? Enum141.const_1 : ((point_1.Y > base.Height - this.padding_0.Bottom) ? Enum141.const_3 : Enum141.const_4));
			if (this.Dock != DockStyle.Fill && (this.enum141_1 != Enum141.const_4 || this.enum141_0 != Enum141.const_4))
			{
				switch (this.Dock)
				{
				case DockStyle.None:
					this.bool_13 = true;
					this.bool_15 = true;
					this.bool_14 = true;
					if ((this.enum141_0 == Enum141.const_1 && this.enum141_1 == Enum141.const_0) || (this.enum141_0 == Enum141.const_3 && this.enum141_1 == Enum141.const_2))
					{
						this.Cursor = Cursors.SizeNWSE;
					}
					else if ((this.enum141_0 == Enum141.const_1 && this.enum141_1 == Enum141.const_2) || (this.enum141_0 == Enum141.const_3 && this.enum141_1 == Enum141.const_0))
					{
						this.Cursor = Cursors.SizeNESW;
					}
					else if (this.enum141_0 != Enum141.const_4)
					{
						this.bool_14 = false;
						this.bool_13 = true;
						this.bool_15 = true;
						this.Cursor = Cursors.SizeNS;
					}
					else
					{
						this.bool_15 = false;
						this.bool_13 = true;
						this.bool_14 = true;
						this.Cursor = Cursors.SizeWE;
					}
					break;
				case DockStyle.Top:
					this.Cursor = ((this.bool_15 = (this.bool_13 = this.enum141_0 == Enum141.const_3)) ? Cursors.SizeNS : Cursors.Default);
					break;
				case DockStyle.Bottom:
					this.Cursor = ((this.bool_15 = (this.bool_13 = this.enum141_0 == Enum141.const_1)) ? Cursors.SizeNS : Cursors.Default);
					break;
				case DockStyle.Left:
					this.Cursor = ((this.bool_14 = (this.bool_13 = ((this.RightToLeft == RightToLeft.Yes) ? (this.enum141_1 == Enum141.const_0) : (this.enum141_1 == Enum141.const_2)))) ? Cursors.SizeWE : Cursors.Default);
					break;
				case DockStyle.Right:
					this.Cursor = ((this.bool_14 = (this.bool_13 = ((this.RightToLeft == RightToLeft.Yes) ? (this.enum141_1 == Enum141.const_2) : (this.enum141_1 == Enum141.const_0)))) ? Cursors.SizeWE : Cursors.Default);
					break;
				}
			}
			else
			{
				this.bool_13 = false;
				this.bool_15 = false;
				this.bool_14 = false;
				this.Cursor = Cursors.Default;
			}
		}

		private void method_10(string string_0)
		{
			if (!this.Boolean_0)
			{
				this.propertyChangedEventHandler_0?.Invoke(this, new PropertyChangedEventArgs(string_0));
			}
		}
	}
}
