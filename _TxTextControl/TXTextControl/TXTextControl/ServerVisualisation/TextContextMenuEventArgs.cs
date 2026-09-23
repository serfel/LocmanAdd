using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using ns21;
using ns23;
using TXTextControl.DataVisualization;

namespace TXTextControl.ServerVisualisation
{
	public class TextContextMenuEventArgs : EventArgs
	{
		private ResourceManager resourceManager_0;

		private TextViewGenerator textViewGenerator_0;

		private Class408 class408_0;

		private ContextMenuLocation contextMenuLocation_0;

		private TextPart textPart_0;

		private Struct77 struct77_0 = default(Struct77);

		private MenuItem[] menuItem_0;

		private Class415 class415_0;

		public ContextMenuLocation ContextMenuLocation => this.contextMenuLocation_0;

		public Point Location => new Point(this.struct77_0.struct82_0.int_0, this.struct77_0.struct82_0.int_1);

		public bool RightToLeft => this.textViewGenerator_0.textControlCore_0.Boolean_2;

		public MenuItem[] Items
		{
			get
			{
				if (this.menuItem_0 == null)
				{
					this.menuItem_0 = this.method_0(this.contextMenuLocation_0).ToArray();
				}
				return this.menuItem_0;
			}
		}

		internal TextContextMenuEventArgs(ContextMenuLocation iLocation, TextViewGenerator viewgenerator, TextPart iTextPart, Class408 helperLibraries, ResourceManager resourceManager_1, Class415 ptxSpellChecker)
		{
			this.contextMenuLocation_0 = iLocation;
			this.textViewGenerator_0 = viewgenerator;
			this.textPart_0 = iTextPart;
			this.class408_0 = helperLibraries;
			this.resourceManager_0 = resourceManager_1;
			this.class415_0 = ptxSpellChecker;
			this.struct77_0.method_0();
			viewgenerator.textControlCore_0.method_60(iTextPart, Enum83.const_297, 0, ref this.struct77_0);
		}

		private List<MenuItem> method_0(ContextMenuLocation contextMenuLocation_1)
		{
			if ((contextMenuLocation_1 & (ContextMenuLocation.Header | ContextMenuLocation.Footer | ContextMenuLocation.PageMargin | ContextMenuLocation.PageNumberField)) != 0)
			{
				return null;
			}
			return ((contextMenuLocation_1 & ContextMenuLocation.SelectedFrame) != 0) ? this.method_1() : (((contextMenuLocation_1 & ContextMenuLocation.MisspelledWord) != 0 && this.class415_0 != null) ? this.method_5(this.textViewGenerator_0.textControlCore_0, this.textPart_0, (int)this.struct77_0.uint_1) : (((contextMenuLocation_1 & ContextMenuLocation.PageNumberField) != 0) ? this.method_4(this.textPart_0, this.struct77_0.ushort_1) : (((contextMenuLocation_1 & (ContextMenuLocation.TextSelection | ContextMenuLocation.TextInputPosition)) != 0) ? this.method_2(contextMenuLocation_1) : (((contextMenuLocation_1 & (ContextMenuLocation.Header | ContextMenuLocation.Footer | ContextMenuLocation.PageMargin)) != 0) ? this.method_3(contextMenuLocation_1) : null))));
		}

		private List<MenuItem> method_1()
		{
			IntPtr intptr_ = this.class408_0.method_4();
			List<MenuItem> list = new List<MenuItem>();
			bool canCopy = this.textViewGenerator_0.CanCopy;
			bool canEdit = this.textViewGenerator_0.CanEdit;
			this.method_6(list, intptr_, Enum114.const_0, canEdit && canCopy);
			this.method_6(list, intptr_, Enum114.const_2, canCopy);
			this.method_9(list);
			FrameBase item = this.textViewGenerator_0.Frames.GetItem();
			if (item is DrawingFrame)
			{
				this.method_6(list, intptr_, Enum114.const_61, canEdit);
			}
			FrameInsertionMode insertionMode = item.InsertionMode;
			MenuItem menuItem;
			if ((insertionMode & FrameInsertionMode.AsCharacter) == 0)
			{
				menuItem = this.method_6(list, intptr_, Enum114.const_37, canEdit);
				if (canEdit)
				{
					menuItem.list_0 = new List<MenuItem>();
					this.method_6(menuItem.list_0, intptr_, Enum114.const_37, bool_0: true);
					this.method_6(menuItem.list_0, intptr_, Enum114.const_38, bool_0: true);
					this.method_6(menuItem.list_0, intptr_, Enum114.const_39, bool_0: true);
				}
				menuItem = this.method_6(list, intptr_, Enum114.const_40, canEdit);
				if (canEdit)
				{
					menuItem.list_0 = new List<MenuItem>();
					this.method_6(menuItem.list_0, intptr_, Enum114.const_40, bool_0: true);
					this.method_6(menuItem.list_0, intptr_, Enum114.const_41, bool_0: true);
					this.method_6(menuItem.list_0, intptr_, Enum114.const_42, bool_0: true);
				}
				this.method_9(list);
			}
			menuItem = this.method_6(list, intptr_, Enum114.const_12, canEdit);
			if (canEdit)
			{
				menuItem.list_0 = new List<MenuItem>();
				MenuItem menuItem2 = this.method_6(menuItem.list_0, intptr_, Enum114.const_13, bool_0: true);
				if ((insertionMode & FrameInsertionMode.AsCharacter) != 0)
				{
					menuItem2.Checked = true;
				}
				menuItem2 = this.method_6(menuItem.list_0, intptr_, Enum114.const_14, bool_0: true);
				if ((insertionMode & FrameInsertionMode.DisplaceCompleteLines) == FrameInsertionMode.DisplaceCompleteLines)
				{
					menuItem2.Checked = true;
				}
				menuItem2 = this.method_6(menuItem.list_0, intptr_, Enum114.const_15, bool_0: true);
				if ((insertionMode & FrameInsertionMode.DisplaceText) == FrameInsertionMode.DisplaceText)
				{
					menuItem2.Checked = true;
				}
				menuItem2 = this.method_6(menuItem.list_0, intptr_, Enum114.const_16, bool_0: true);
				if ((insertionMode & FrameInsertionMode.BelowTheText) == FrameInsertionMode.BelowTheText)
				{
					menuItem2.Checked = true;
				}
				menuItem2 = this.method_6(menuItem.list_0, intptr_, Enum114.const_17, bool_0: true);
				if ((insertionMode & FrameInsertionMode.AboveTheText) == FrameInsertionMode.AboveTheText)
				{
					menuItem2.Checked = true;
				}
			}
			this.method_6(list, intptr_, Enum114.const_18, canEdit);
			return list;
		}

		private List<MenuItem> method_2(ContextMenuLocation contextMenuLocation_1)
		{
			IntPtr intptr_ = this.class408_0.method_4();
			List<MenuItem> list = new List<MenuItem>();
			IList clipboardFormats = this.textViewGenerator_0.GetClipboardFormats();
			bool canCopy = this.textViewGenerator_0.CanCopy;
			bool canEdit = this.textViewGenerator_0.CanEdit;
			bool canCharacterFormat = this.textViewGenerator_0.CanCharacterFormat;
			bool canParagraphFormat = this.textViewGenerator_0.CanParagraphFormat;
			bool canTableFormat = this.textViewGenerator_0.CanTableFormat;
			bool canStyleFormat = this.textViewGenerator_0.CanStyleFormat;
			this.method_6(list, intptr_, Enum114.const_0, (canEdit && canCopy && (contextMenuLocation_1 & ContextMenuLocation.TextSelection) != 0) ? true : false);
			this.method_6(list, intptr_, Enum114.const_2, (canCopy && (contextMenuLocation_1 & ContextMenuLocation.TextSelection) != 0) ? true : false);
			MenuItem menuItem = this.method_6(list, intptr_, Enum114.const_3, (canEdit && clipboardFormats != null && clipboardFormats.Count > 0) ? true : false);
			if (canEdit && clipboardFormats != null && clipboardFormats.Count > 0)
			{
				menuItem.list_0 = new List<MenuItem>();
				this.method_6(menuItem.list_0, intptr_, Enum114.const_20, (clipboardFormats.Contains(ClipboardFormat.TXTextControlFormat) || clipboardFormats.Contains(ClipboardFormat.RichTextFormat) || clipboardFormats.Contains(ClipboardFormat.HTMLFormat)) ? true : false);
				this.method_6(menuItem.list_0, intptr_, Enum114.const_21, clipboardFormats.Contains(ClipboardFormat.PlainText) ? true : false);
				this.method_6(menuItem.list_0, intptr_, Enum114.const_22, (clipboardFormats.Contains(ClipboardFormat.Image) || clipboardFormats.Contains(ClipboardFormat.TXTextControlImage)) ? true : false);
				this.method_6(menuItem.list_0, intptr_, Enum114.const_23, clipboardFormats.Contains(ClipboardFormat.TXTextControlTextframe) ? true : false);
				this.method_6(menuItem.list_0, intptr_, Enum114.const_24, clipboardFormats.Contains(ClipboardFormat.Chart) ? true : false);
				this.method_6(menuItem.list_0, intptr_, Enum114.const_59, clipboardFormats.Contains(ClipboardFormat.Barcode) ? true : false);
				this.method_6(menuItem.list_0, intptr_, Enum114.const_60, clipboardFormats.Contains(ClipboardFormat.Drawing) ? true : false);
			}
			this.method_9(list);
			this.method_6(list, intptr_, Enum114.const_4, canCharacterFormat);
			this.method_6(list, intptr_, Enum114.const_5, canParagraphFormat);
			this.method_6(list, intptr_, Enum114.const_6, canParagraphFormat);
			this.method_6(list, intptr_, Enum114.const_7, canStyleFormat);
			if ((contextMenuLocation_1 & ContextMenuLocation.Table) != 0)
			{
				this.method_9(list);
				if ((contextMenuLocation_1 & ContextMenuLocation.TextInputPosition) != 0)
				{
					menuItem = this.method_6(list, intptr_, Enum114.const_47, bool_0: true);
					menuItem.list_0 = new List<MenuItem>();
					this.method_6(menuItem.list_0, intptr_, Enum114.const_48, bool_0: true);
					this.method_6(menuItem.list_0, intptr_, Enum114.const_49, bool_0: true);
					this.method_6(menuItem.list_0, intptr_, Enum114.const_50, bool_0: true);
					this.method_6(menuItem.list_0, intptr_, Enum114.const_51, bool_0: true);
				}
				else
				{
					this.method_6(list, intptr_, Enum114.const_52, canEdit && canTableFormat);
				}
				menuItem = this.method_6(list, intptr_, Enum114.const_54, canEdit);
				if (canEdit)
				{
					menuItem.list_0 = new List<MenuItem>();
					this.method_6(menuItem.list_0, intptr_, Enum114.const_55, canTableFormat);
					this.method_6(menuItem.list_0, intptr_, Enum114.const_56, canTableFormat);
					this.method_6(menuItem.list_0, intptr_, Enum114.const_57, canTableFormat);
					this.method_6(menuItem.list_0, intptr_, Enum114.const_58, canTableFormat);
				}
				this.method_6(list, intptr_, Enum114.const_19, canTableFormat);
			}
			if ((contextMenuLocation_1 & ContextMenuLocation.TableOfContents) != 0 && canEdit)
			{
				this.method_9(list);
				this.method_6(list, intptr_, Enum114.const_62, bool_0: true);
				this.method_6(list, intptr_, Enum114.const_63, bool_0: true);
				this.method_6(list, intptr_, Enum114.const_64, bool_0: true);
			}
			if ((contextMenuLocation_1 & ContextMenuLocation.TextInputPosition) != 0)
			{
				this.method_9(list);
				menuItem = this.method_6(list, intptr_, Enum114.const_8, canEdit);
				if (canEdit)
				{
					menuItem.list_0 = new List<MenuItem>();
					if (this.textViewGenerator_0.TextParts.GetItem() is HeaderFooter)
					{
						this.method_6(menuItem.list_0, intptr_, Enum114.const_32, bool_0: true);
						this.method_9(menuItem.list_0);
					}
					this.method_6(menuItem.list_0, intptr_, Enum114.const_9, bool_0: true);
					if ((contextMenuLocation_1 & ContextMenuLocation.Table) != 0)
					{
						this.method_6(menuItem.list_0, intptr_, Enum114.const_43, canTableFormat);
						this.method_6(menuItem.list_0, intptr_, Enum114.const_44, canTableFormat);
						this.method_6(menuItem.list_0, intptr_, Enum114.const_45, canTableFormat);
						this.method_6(menuItem.list_0, intptr_, Enum114.const_46, canTableFormat);
						this.method_9(menuItem.list_0);
					}
					this.method_6(menuItem.list_0, intptr_, Enum114.const_11, bool_0: true);
					if ((contextMenuLocation_1 & ContextMenuLocation.TableOfContents) == 0)
					{
						this.method_6(menuItem.list_0, intptr_, Enum114.const_65, bool_0: true);
					}
				}
			}
			return list;
		}

		private List<MenuItem> method_3(ContextMenuLocation contextMenuLocation_1)
		{
			IntPtr intptr_ = this.class408_0.method_4();
			List<MenuItem> list = new List<MenuItem>();
			bool canEdit = this.textViewGenerator_0.CanEdit;
			if ((contextMenuLocation_1 & ContextMenuLocation.Header) != 0)
			{
				this.method_6(list, intptr_, Enum114.const_26, bool_0: true);
			}
			if ((contextMenuLocation_1 & ContextMenuLocation.NoHeader) != 0)
			{
				this.method_6(list, intptr_, Enum114.const_28, canEdit);
			}
			if ((contextMenuLocation_1 & ContextMenuLocation.Footer) != 0)
			{
				this.method_6(list, intptr_, Enum114.const_27, bool_0: true);
			}
			if ((contextMenuLocation_1 & ContextMenuLocation.NoFooter) != 0)
			{
				this.method_6(list, intptr_, Enum114.const_29, canEdit);
			}
			this.method_6(list, intptr_, Enum114.const_34, canEdit);
			if ((contextMenuLocation_1 & ContextMenuLocation.Header) != 0)
			{
				this.method_6(list, intptr_, Enum114.const_35, canEdit);
			}
			if ((contextMenuLocation_1 & ContextMenuLocation.Footer) != 0)
			{
				this.method_6(list, intptr_, Enum114.const_36, canEdit);
			}
			this.method_9(list);
			this.method_6(list, intptr_, Enum114.const_25, canEdit);
			this.method_6(list, intptr_, Enum114.const_33, canEdit);
			return list;
		}

		private List<MenuItem> method_4(TextPart textPart_1, int int_0)
		{
			IntPtr intptr_ = this.class408_0.method_4();
			List<MenuItem> list = new List<MenuItem>();
			bool canEdit = this.textViewGenerator_0.CanEdit;
			this.method_7(list, intptr_, Enum114.const_30, canEdit, textPart_1, int_0);
			this.method_7(list, intptr_, Enum114.const_31, canEdit, textPart_1, int_0);
			return list;
		}

		private List<MenuItem> method_5(TextControlCore textControlCore_0, TextPart textPart_1, int int_0)
		{
			List<MenuItem> list = new List<MenuItem>();
			MisspelledWordCollection misspelledWordCollection = new MisspelledWordCollection(textControlCore_0, textPart_1);
			MisspelledWord misspelledWord = misspelledWordCollection[int_0];
			if (misspelledWord != null)
			{
				bool isDuplicate;
				if (isDuplicate = misspelledWord.IsDuplicate)
				{
					this.method_8(list, this.resourceManager_0.GetString("MENU_SPELLDELETE"), Enum114.const_66, bool_0: true, textPart_1, int_0);
				}
				else
				{
					if (this.class415_0.method_38() >= 4 && misspelledWord.Culture != null)
					{
						this.class415_0.method_8(misspelledWord.Text, 5, misspelledWord.Culture);
					}
					else
					{
						this.class415_0.method_6(misspelledWord.Text, 5);
					}
					CollectionBase collectionBase_ = this.class415_0.CollectionBase_3;
					if (collectionBase_.Count > 0)
					{
						foreach (object item in collectionBase_)
						{
							this.method_8(list, item.ToString(), Enum114.const_67, bool_0: true, textPart_1, int_0);
						}
					}
					else
					{
						this.method_8(list, this.resourceManager_0.GetString("MENU_NOSUGGESTIONS"), Enum114.const_66, bool_0: false, textPart_1, int_0);
					}
				}
				this.method_9(list);
				this.method_8(list, this.resourceManager_0.GetString("MENU_SPELLIGNORE"), Enum114.const_66, bool_0: true, textPart_1, int_0);
				if (!isDuplicate)
				{
					this.method_8(list, this.resourceManager_0.GetString("MENU_SPELLIGNOREALL"), Enum114.const_66, bool_0: true, textPart_1, int_0);
					bool bool_ = false;
					CollectionBase collectionBase_2 = this.class415_0.CollectionBase_0;
					if (this.class415_0.method_38() >= 4)
					{
						bool_ = this.class415_0.method_46(collectionBase_2, misspelledWord.Culture).Count > 0;
					}
					else
					{
						foreach (object item2 in collectionBase_2)
						{
							if (item2.GetType().Name == "UserDictionary" && this.class415_0.method_17(item2))
							{
								bool_ = true;
								break;
							}
						}
					}
					this.method_8(list, this.resourceManager_0.GetString("MENU_SPELLADDTODICTIONARY"), Enum114.const_66, bool_, textPart_1, int_0);
				}
			}
			return list;
		}

		private MenuItem method_6(List<MenuItem> list_0, IntPtr intptr_0, Enum114 enum114_0, bool bool_0)
		{
			return this.method_7(list_0, intptr_0, enum114_0, bool_0, TextPart.Auto, 0);
		}

		private MenuItem method_7(List<MenuItem> list_0, IntPtr intptr_0, Enum114 enum114_0, bool bool_0, TextPart textPart_1, int int_0)
		{
			Bitmap image = null;
			IntPtr intPtr = Class429.LoadBitmap(intptr_0, new IntPtr((int)enum114_0));
			if (intPtr != IntPtr.Zero)
			{
				image = System.Drawing.Image.FromHbitmap(intPtr);
				Class429.DeleteObject(intPtr);
			}
			int num = (int)(enum114_0 + 300);
			TxString txString = (TxString)num;
			string @string = this.resourceManager_0.GetString(txString.ToString());
			MenuItem menuItem = new MenuItem(@string, image, enum114_0, this.textViewGenerator_0, textPart_1, int_0);
			menuItem.Enabled = bool_0;
			list_0.Add(menuItem);
			return menuItem;
		}

		private MenuItem method_8(List<MenuItem> list_0, string string_0, Enum114 enum114_0, bool bool_0, TextPart textPart_1, int int_0)
		{
			MenuItem menuItem = new MenuItem(string_0, enum114_0, this.textViewGenerator_0, textPart_1, int_0);
			menuItem.Enabled = bool_0;
			list_0.Add(menuItem);
			return menuItem;
		}

		private MenuItem method_9(List<MenuItem> list_0)
		{
			MenuItem menuItem = new MenuItem(null, null, (Enum114)0, this.textViewGenerator_0, TextPart.Auto, 0);
			list_0.Add(menuItem);
			return menuItem;
		}
	}
}
