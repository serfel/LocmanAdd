using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using ns21;
using ns27;
using TXTextControl.DataVisualization;

namespace TXTextControl
{
	/// <summary>The TextContextMenuEventArgs class provides data for the TextControl.TextContextMenuOpening event of a Windows Forms TextControl.</summary>
	public class TextContextMenuEventArgs : CancelEventArgs
	{
		private ResourceManager resourceManager_0;

		private TextControlCore textControlCore_0;

		private TextControl textControl_0;

		private Class408 class408_0;

		private ContextMenuStrip contextMenuStrip_0;

		private ContextMenuLocation contextMenuLocation_0;

		private bool bool_0;

		private Struct77 struct77_0 = default(Struct77);

		private uint uint_0;

		/// <summary>Gets the location in the document for which the context menu will be opened.</summary>
		public ContextMenuLocation ContextMenuLocation => this.contextMenuLocation_0;

		/// <summary>Gets the location, in pixels, where the context menu is displayed.</summary>
		public Point Location => new Point(this.struct77_0.struct82_0.int_0, this.struct77_0.struct82_0.int_1);

		/// <summary>Gets or sets the context menu, which will be shown.</summary>
		public ContextMenuStrip TextContextMenu
		{
			get
			{
				if (this.contextMenuStrip_0 == null && !this.bool_0)
				{
					this.contextMenuStrip_0 = this.method_0(this.contextMenuLocation_0);
					if (this.uint_0 != 0)
					{
						this.contextMenuStrip_0.Font = Class467.smethod_1(this.uint_0);
					}
				}
				return this.contextMenuStrip_0;
			}
			set
			{
				this.contextMenuStrip_0 = value;
				this.bool_0 = true;
			}
		}

		internal TextContextMenuEventArgs(ContextMenuLocation iLocation, TextControl textcontrol, TextControlCore textControlCore_1, Class408 helperLibraries, ResourceManager resourceManager_1)
		{
			this.contextMenuLocation_0 = iLocation;
			this.textControl_0 = textcontrol;
			this.textControlCore_0 = textControlCore_1;
			this.class408_0 = helperLibraries;
			this.resourceManager_0 = resourceManager_1;
			this.uint_0 = Class429.smethod_15(textControlCore_1.IntPtr_0);
			this.struct77_0.method_0();
			this.textControlCore_0.method_60(TextPart.Auto, Enum83.const_297, 0, ref this.struct77_0);
		}

		private ContextMenuStrip method_0(ContextMenuLocation contextMenuLocation_1)
		{
			if ((contextMenuLocation_1 & (ContextMenuLocation.Header | ContextMenuLocation.Footer | ContextMenuLocation.PageMargin | ContextMenuLocation.PageNumberField)) != 0)
			{
				base.Cancel = true;
				return null;
			}
			ContextMenuStrip contextMenuStrip = (((contextMenuLocation_1 & ContextMenuLocation.SelectedFrame) != 0) ? this.method_2() : (((contextMenuLocation_1 & ContextMenuLocation.MisspelledWord) != 0 && this.textControl_0.SpellCheckContextMenuStrip != "(none)" && this.textControl_0.SpellChecker != null) ? this.textControl_0.class589_0.method_0(this.textControlCore_0, (int)this.struct77_0.uint_1) : (((contextMenuLocation_1 & ContextMenuLocation.PageNumberField) != 0) ? this.method_5() : (((contextMenuLocation_1 & (ContextMenuLocation.TextSelection | ContextMenuLocation.TextInputPosition)) != 0) ? this.method_3(contextMenuLocation_1) : (((contextMenuLocation_1 & (ContextMenuLocation.Header | ContextMenuLocation.Footer | ContextMenuLocation.PageMargin)) != 0) ? this.method_4(contextMenuLocation_1) : null)))));
			if (contextMenuStrip != null && this.textControlCore_0.Boolean_2)
			{
				contextMenuStrip.RightToLeft = RightToLeft.Yes;
			}
			return contextMenuStrip;
		}

		private void method_1(object sender, EventArgs e)
		{
			ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
			if (toolStripMenuItem == null)
			{
				return;
			}
			int num = ((toolStripMenuItem.Tag != null && toolStripMenuItem.Tag.GetType() == typeof(int)) ? ((int)toolStripMenuItem.Tag) : 0);
			ToolStrip toolStrip = ((toolStripMenuItem.OwnerItem != null) ? toolStripMenuItem.OwnerItem.Owner : toolStripMenuItem.Owner);
			if (toolStrip is ContextMenuStrip && toolStripMenuItem.DropDownItems.Count == 0)
			{
				((ContextMenuStrip)toolStrip).Close(ToolStripDropDownCloseReason.ItemClicked);
				if (this.textControl_0.miniToolbar_0 != null)
				{
					this.textControl_0.miniToolbar_0.Close();
				}
			}
			if (num != 0)
			{
				this.textControlCore_0.method_30((Enum83)2042, Class429.smethod_3(num, 0), 0);
			}
		}

		private ContextMenuStrip method_2()
		{
			IntPtr intptr_ = this.class408_0.method_4();
			ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
			bool canCopy = this.textControl_0.CanCopy;
			bool canEdit = this.textControl_0.CanEdit;
			this.method_6(contextMenuStrip, null, intptr_, Enum114.const_0, canEdit && canCopy);
			this.method_6(contextMenuStrip, null, intptr_, Enum114.const_2, canCopy);
			contextMenuStrip.Items.Add(new ToolStripSeparator());
			FrameBase item = this.textControl_0.Frames.GetItem();
			if (item is Image)
			{
				this.method_6(contextMenuStrip, null, intptr_, Enum114.const_53, canEdit);
			}
			else if (item is DrawingFrame)
			{
				this.method_6(contextMenuStrip, null, intptr_, Enum114.const_61, canEdit);
			}
			FrameInsertionMode insertionMode = item.InsertionMode;
			ToolStripMenuItem toolStripMenuItem_;
			if ((insertionMode & FrameInsertionMode.AsCharacter) == 0)
			{
				toolStripMenuItem_ = this.method_6(contextMenuStrip, null, intptr_, Enum114.const_37, canEdit);
				if (canEdit)
				{
					this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_37, bool_1: true);
					this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_38, bool_1: true);
					this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_39, bool_1: true);
				}
				toolStripMenuItem_ = this.method_6(contextMenuStrip, null, intptr_, Enum114.const_40, canEdit);
				if (canEdit)
				{
					this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_40, bool_1: true);
					this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_41, bool_1: true);
					this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_42, bool_1: true);
				}
				contextMenuStrip.Items.Add(new ToolStripSeparator());
			}
			toolStripMenuItem_ = this.method_6(contextMenuStrip, null, intptr_, Enum114.const_12, canEdit);
			if (canEdit)
			{
				ToolStripMenuItem toolStripMenuItem = this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_13, bool_1: true);
				if ((insertionMode & FrameInsertionMode.AsCharacter) != 0)
				{
					toolStripMenuItem.Checked = true;
				}
				toolStripMenuItem = this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_14, bool_1: true);
				if ((insertionMode & FrameInsertionMode.DisplaceCompleteLines) == FrameInsertionMode.DisplaceCompleteLines)
				{
					toolStripMenuItem.Checked = true;
				}
				toolStripMenuItem = this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_15, bool_1: true);
				if ((insertionMode & FrameInsertionMode.DisplaceText) == FrameInsertionMode.DisplaceText)
				{
					toolStripMenuItem.Checked = true;
				}
				toolStripMenuItem = this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_16, bool_1: true);
				if ((insertionMode & FrameInsertionMode.BelowTheText) == FrameInsertionMode.BelowTheText)
				{
					toolStripMenuItem.Checked = true;
				}
				toolStripMenuItem = this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_17, bool_1: true);
				if ((insertionMode & FrameInsertionMode.AboveTheText) == FrameInsertionMode.AboveTheText)
				{
					toolStripMenuItem.Checked = true;
				}
			}
			this.method_6(contextMenuStrip, null, intptr_, Enum114.const_18, canEdit);
			return contextMenuStrip;
		}

		private ContextMenuStrip method_3(ContextMenuLocation contextMenuLocation_1)
		{
			IntPtr intptr_ = this.class408_0.method_4();
			ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
			IList clipboardFormats = this.textControl_0.GetClipboardFormats();
			bool canCopy = this.textControl_0.CanCopy;
			bool canEdit = this.textControl_0.CanEdit;
			bool canCharacterFormat = this.textControl_0.CanCharacterFormat;
			bool canParagraphFormat = this.textControl_0.CanParagraphFormat;
			bool canTableFormat = this.textControl_0.CanTableFormat;
			bool canStyleFormat = this.textControl_0.CanStyleFormat;
			this.method_6(contextMenuStrip, null, intptr_, Enum114.const_0, canEdit && canCopy && (contextMenuLocation_1 & ContextMenuLocation.TextSelection) != 0);
			this.method_6(contextMenuStrip, null, intptr_, Enum114.const_2, canCopy && (contextMenuLocation_1 & ContextMenuLocation.TextSelection) != 0);
			ToolStripMenuItem toolStripMenuItem_ = this.method_6(contextMenuStrip, null, intptr_, Enum114.const_3, canEdit && clipboardFormats != null && clipboardFormats.Count > 0);
			if (canEdit && clipboardFormats != null && clipboardFormats.Count > 0)
			{
				this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_20, (clipboardFormats.Contains(ClipboardFormat.TXTextControlFormat) || clipboardFormats.Contains(ClipboardFormat.RichTextFormat) || clipboardFormats.Contains(ClipboardFormat.HTMLFormat)) ? true : false);
				this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_21, clipboardFormats.Contains(ClipboardFormat.PlainText));
				this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_22, clipboardFormats.Contains(ClipboardFormat.Image) || clipboardFormats.Contains(ClipboardFormat.TXTextControlImage));
				this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_23, clipboardFormats.Contains(ClipboardFormat.TXTextControlTextframe));
				this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_24, clipboardFormats.Contains(ClipboardFormat.Chart));
				this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_59, clipboardFormats.Contains(ClipboardFormat.Barcode));
				this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_60, clipboardFormats.Contains(ClipboardFormat.Drawing));
			}
			contextMenuStrip.Items.Add(new ToolStripSeparator());
			this.method_6(contextMenuStrip, null, intptr_, Enum114.const_4, canCharacterFormat);
			this.method_6(contextMenuStrip, null, intptr_, Enum114.const_5, canParagraphFormat);
			this.method_6(contextMenuStrip, null, intptr_, Enum114.const_6, canParagraphFormat);
			this.method_6(contextMenuStrip, null, intptr_, Enum114.const_7, canStyleFormat);
			if ((contextMenuLocation_1 & ContextMenuLocation.Table) != 0)
			{
				contextMenuStrip.Items.Add(new ToolStripSeparator());
				if ((contextMenuLocation_1 & ContextMenuLocation.TextInputPosition) != 0)
				{
					toolStripMenuItem_ = this.method_6(contextMenuStrip, null, intptr_, Enum114.const_47, bool_1: true);
					this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_48, bool_1: true);
					this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_49, bool_1: true);
					this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_50, bool_1: true);
					this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_51, bool_1: true);
				}
				else
				{
					this.method_6(contextMenuStrip, null, intptr_, Enum114.const_52, canEdit && canTableFormat);
				}
				toolStripMenuItem_ = this.method_6(contextMenuStrip, null, intptr_, Enum114.const_54, canEdit);
				if (canEdit)
				{
					this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_55, canTableFormat);
					this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_56, canTableFormat);
					this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_57, canTableFormat);
					this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_58, canTableFormat);
				}
				this.method_6(contextMenuStrip, null, intptr_, Enum114.const_19, canTableFormat);
			}
			if ((contextMenuLocation_1 & ContextMenuLocation.TableOfContents) != 0 && canEdit)
			{
				contextMenuStrip.Items.Add(new ToolStripSeparator());
				this.method_6(contextMenuStrip, null, intptr_, Enum114.const_62, bool_1: true);
				this.method_6(contextMenuStrip, null, intptr_, Enum114.const_63, bool_1: true);
				this.method_6(contextMenuStrip, null, intptr_, Enum114.const_64, bool_1: true);
			}
			if ((contextMenuLocation_1 & ContextMenuLocation.TextInputPosition) != 0)
			{
				contextMenuStrip.Items.Add(new ToolStripSeparator());
				toolStripMenuItem_ = this.method_6(contextMenuStrip, null, intptr_, Enum114.const_8, canEdit);
				if (canEdit)
				{
					if (this.textControl_0.TextParts.GetItem() is HeaderFooter)
					{
						this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_32, bool_1: true);
						toolStripMenuItem_.DropDownItems.Add(new ToolStripSeparator());
					}
					this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_9, bool_1: true);
					if ((contextMenuLocation_1 & ContextMenuLocation.Table) != 0)
					{
						this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_43, canTableFormat);
						this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_44, canTableFormat);
						this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_45, canTableFormat);
						this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_46, canTableFormat);
						toolStripMenuItem_.DropDownItems.Add(new ToolStripSeparator());
					}
					this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_10, bool_1: true);
					this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_11, bool_1: true);
					if ((contextMenuLocation_1 & ContextMenuLocation.TableOfContents) == 0)
					{
						this.method_6(null, toolStripMenuItem_, intptr_, Enum114.const_65, bool_1: true);
					}
				}
			}
			return contextMenuStrip;
		}

		private ContextMenuStrip method_4(ContextMenuLocation contextMenuLocation_1)
		{
			IntPtr intptr_ = this.class408_0.method_4();
			ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
			bool canEdit = this.textControl_0.CanEdit;
			if ((contextMenuLocation_1 & ContextMenuLocation.Header) != 0)
			{
				this.method_6(contextMenuStrip, null, intptr_, Enum114.const_26, bool_1: true);
			}
			if ((contextMenuLocation_1 & ContextMenuLocation.NoHeader) != 0)
			{
				this.method_6(contextMenuStrip, null, intptr_, Enum114.const_28, canEdit);
			}
			if ((contextMenuLocation_1 & ContextMenuLocation.Footer) != 0)
			{
				this.method_6(contextMenuStrip, null, intptr_, Enum114.const_27, bool_1: true);
			}
			if ((contextMenuLocation_1 & ContextMenuLocation.NoFooter) != 0)
			{
				this.method_6(contextMenuStrip, null, intptr_, Enum114.const_29, canEdit);
			}
			this.method_6(contextMenuStrip, null, intptr_, Enum114.const_34, canEdit);
			if ((contextMenuLocation_1 & ContextMenuLocation.Header) != 0)
			{
				this.method_6(contextMenuStrip, null, intptr_, Enum114.const_35, canEdit);
			}
			if ((contextMenuLocation_1 & ContextMenuLocation.Footer) != 0)
			{
				this.method_6(contextMenuStrip, null, intptr_, Enum114.const_36, canEdit);
			}
			contextMenuStrip.Items.Add(new ToolStripSeparator());
			this.method_6(contextMenuStrip, null, intptr_, Enum114.const_25, canEdit);
			this.method_6(contextMenuStrip, null, intptr_, Enum114.const_33, canEdit);
			return contextMenuStrip;
		}

		private ContextMenuStrip method_5()
		{
			IntPtr intptr_ = this.class408_0.method_4();
			ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
			bool canEdit = this.textControl_0.CanEdit;
			this.method_6(contextMenuStrip, null, intptr_, Enum114.const_30, canEdit);
			this.method_6(contextMenuStrip, null, intptr_, Enum114.const_31, canEdit);
			return contextMenuStrip;
		}

		private ToolStripMenuItem method_6(ContextMenuStrip contextMenuStrip_1, ToolStripMenuItem toolStripMenuItem_0, IntPtr intptr_0, Enum114 enum114_0, bool bool_1)
		{
			int num = (int)(enum114_0 + 300);
			TxString txString = (TxString)num;
			string @string = this.resourceManager_0.GetString(txString.ToString());
			ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(@string);
			toolStripMenuItem.Tag = (int)enum114_0;
			toolStripMenuItem.Enabled = bool_1;
			toolStripMenuItem.ImageTransparentColor = Color.White;
			toolStripMenuItem.Click += method_1;
			toolStripMenuItem.ImageScaling = ToolStripItemImageScaling.None;
			int height = Class466.smethod_0(this.uint_0).Height;
			IntPtr intPtr = Class429.LoadBitmap(intptr_0, new IntPtr((int)(enum114_0 + ((height >= 24) ? ((height < 32) ? 1000 : 2000) : 0))));
			if (intPtr != IntPtr.Zero)
			{
				toolStripMenuItem.Image = System.Drawing.Image.FromHbitmap(intPtr);
				Class429.DeleteObject(intPtr);
			}
			if (contextMenuStrip_1 != null)
			{
				contextMenuStrip_1.Items.Add(toolStripMenuItem);
			}
			else
			{
				toolStripMenuItem_0?.DropDownItems.Add(toolStripMenuItem);
			}
			return toolStripMenuItem;
		}
	}
}
