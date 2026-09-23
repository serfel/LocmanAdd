using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using ns21;
using ns23;

namespace TXTextControl.ServerVisualisation
{
	public class MenuItem
	{
		private Enum114 enum114_0;

		private TextViewGenerator textViewGenerator_0;

		private int int_0;

		private int int_1;

		private TextPart textPart_0;

		internal List<MenuItem> list_0;

		private Bitmap bitmap_0;

		private string string_0;

		private bool bool_0 = true;

		private bool bool_1;

		public Bitmap Image => this.bitmap_0;

		public string Text => this.string_0;

		public bool Enabled
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				this.bool_0 = value;
			}
		}

		public bool Checked
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				this.bool_1 = value;
			}
		}

		public MenuItem[] Items
		{
			get
			{
				if (this.list_0 != null)
				{
					return this.list_0.ToArray();
				}
				return null;
			}
		}

		internal MenuItem(string text, Bitmap image, Enum114 enum114_1, TextViewGenerator viewgenerator, TextPart iTextPart, int iFieldID)
		{
			this.string_0 = text;
			this.bitmap_0 = image;
			this.enum114_0 = enum114_1;
			this.int_1 = iFieldID;
			this.textPart_0 = iTextPart;
			this.textViewGenerator_0 = viewgenerator;
		}

		internal MenuItem(string text, Enum114 enum114_1, TextViewGenerator viewgenerator, TextPart iTextPart, int iMisspelledWord)
		{
			this.string_0 = text;
			this.enum114_0 = enum114_1;
			this.textViewGenerator_0 = viewgenerator;
			this.textPart_0 = iTextPart;
			this.int_0 = iMisspelledWord;
		}

		public DialogViewGenerator Execute()
		{
			switch (this.enum114_0)
			{
			case Enum114.const_18:
				return this.textViewGenerator_0.DialogViewGenerator_0;
			case Enum114.const_19:
				return this.textViewGenerator_0.GetDialogBox(TextViewGenerator.DialogBoxKind.TableFormatDialog);
			case Enum114.const_4:
				return this.textViewGenerator_0.GetDialogBox(TextViewGenerator.DialogBoxKind.FontDialog);
			case Enum114.const_5:
				return this.textViewGenerator_0.GetDialogBox(TextViewGenerator.DialogBoxKind.ParagraphFormatDialog);
			case Enum114.const_6:
				return this.textViewGenerator_0.GetDialogBox(TextViewGenerator.DialogBoxKind.ListFormatDialog);
			case Enum114.const_7:
				return this.textViewGenerator_0.GetDialogBox(TextViewGenerator.DialogBoxKind.FormattingStylesDialog);
			case Enum114.const_9:
				return this.textViewGenerator_0.GetDialogBox(TextViewGenerator.DialogBoxKind.InsertTableDialog);
			case Enum114.const_10:
				return null;
			case Enum114.const_30:
				return this.textViewGenerator_0.GetDialogBox(new PageNumberField(this.textViewGenerator_0.textControlCore_0, this.textPart_0, this.int_1));
			case Enum114.const_33:
				return this.textViewGenerator_0.GetDialogBox(TextViewGenerator.DialogBoxKind.SectionFormatDialog, 3);
			case Enum114.const_34:
				return this.textViewGenerator_0.GetDialogBox(TextViewGenerator.DialogBoxKind.SectionFormatDialog, 1);
			case Enum114.const_25:
				return this.textViewGenerator_0.GetDialogBox(TextViewGenerator.DialogBoxKind.SectionFormatDialog, 0);
			case Enum114.const_53:
				return null;
			default:
				this.textViewGenerator_0.textControlCore_0.method_30((Enum83)2042, Class429.smethod_3((int)this.enum114_0, 0), 0);
				goto IL_01cc;
			case Enum114.const_66:
			case Enum114.const_67:
				if (this.int_0 != 0)
				{
					MisspelledWordCollection misspelledWordCollection = new MisspelledWordCollection(this.textViewGenerator_0.textControlCore_0, this.textPart_0);
					MisspelledWord misspelledWord = misspelledWordCollection[this.int_0];
					if (misspelledWord != null)
					{
						if (this.enum114_0 == Enum114.const_67)
						{
							misspelledWordCollection.Remove(misspelledWord, this.string_0);
						}
						else
						{
							this.method_0(misspelledWordCollection, misspelledWord);
						}
					}
				}
				goto IL_01cc;
			case Enum114.const_62:
			case Enum114.const_65:
				{
					return this.textViewGenerator_0.GetDialogBox(TextViewGenerator.DialogBoxKind.TableOfContentsDialog);
				}
				IL_01cc:
				return null;
			}
		}

		private void method_0(MisspelledWordCollection misspelledWordCollection_0, MisspelledWord misspelledWord_0)
		{
			Class415 class415_ = this.textViewGenerator_0.class415_0;
			if (this.string_0 == this.textViewGenerator_0.resourceManager_0.GetString("MENU_SPELLDELETE"))
			{
				int start = misspelledWord_0.Start;
				int length = misspelledWord_0.Length;
				misspelledWordCollection_0.Remove(misspelledWord_0);
				Selection selection = new Selection(this.textViewGenerator_0.textControlCore_0, this.textPart_0);
				selection.Start = start - 2;
				selection.Length = length + 1;
				selection.Text = "";
			}
			else if (this.string_0 == this.textViewGenerator_0.resourceManager_0.GetString("MENU_SPELLIGNORE"))
			{
				misspelledWord_0.IsIgnored = true;
			}
			else if (this.string_0 == this.textViewGenerator_0.resourceManager_0.GetString("MENU_SPELLIGNOREALL"))
			{
				string text = misspelledWord_0.Text;
				foreach (IFormattedText textPart in this.textViewGenerator_0.TextParts)
				{
					foreach (MisspelledWord misspelledWord3 in textPart.MisspelledWords)
					{
						if (misspelledWord3.Text == text)
						{
							misspelledWord3.IsIgnored = true;
						}
					}
				}
			}
			else
			{
				if (!(this.string_0 == this.textViewGenerator_0.resourceManager_0.GetString("MENU_SPELLADDTODICTIONARY")))
				{
					return;
				}
				CollectionBase collectionBase_ = class415_.CollectionBase_0;
				if (class415_.method_38() >= 4)
				{
					List<object> list = class415_.method_46(collectionBase_, misspelledWord_0.Culture);
					foreach (object item in list)
					{
						class415_.method_16(item, misspelledWord_0.Text);
					}
				}
				else
				{
					foreach (object item2 in collectionBase_)
					{
						if (item2.GetType().Name == "UserDictionary" && class415_.method_17(item2))
						{
							class415_.method_16(item2, misspelledWord_0.Text);
						}
					}
				}
				foreach (IFormattedText textPart2 in this.textViewGenerator_0.TextParts)
				{
					MisspelledWordCollection.MisspelledWordEnumerator enumerator3 = textPart2.MisspelledWords.GetEnumerator();
					int count = textPart2.MisspelledWords.Count;
					enumerator3.MoveNext();
					string text2 = misspelledWord_0.Text;
					for (int i = 0; i < count; i++)
					{
						MisspelledWord misspelledWord2 = (MisspelledWord)enumerator3.Current;
						if (misspelledWord2.Text == text2)
						{
							misspelledWordCollection_0.Remove(misspelledWord2);
						}
						else
						{
							enumerator3.MoveNext();
						}
					}
				}
			}
		}
	}
}
