using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using ns23;
using TXTextControl;
using TXTextControl.Proofing;

namespace ns29
{
	internal class Class591
	{
		internal SpellCheckDialogForm spellCheckDialogForm_0;

		internal ResourceManager resourceManager_0;

		internal Class415 class415_0;

		internal Class596 class596_0 = new Class596();

		internal Class596 class596_1 = new Class596();

		internal Class596 class596_2 = new Class596();

		internal List<Class595> list_0 = new List<Class595>();

		internal List<Class595> list_1 = new List<Class595>();

		internal Class595 class595_0;

		internal bool[] bool_0 = new bool[9] { true, true, true, true, true, true, true, false, true };

		private bool bool_1;

		internal Class594 class594_0;

		internal object object_0;

		private List<object> list_2 = new List<object>();

		internal List<object> list_3 = new List<object>();

		private List<object> list_4 = new List<object>();

		private List<object> list_5 = new List<object>();

		private List<object> list_6 = new List<object>();

		internal bool bool_2;

		private bool bool_3 = true;

		internal bool bool_4;

		internal bool bool_5;

		internal string string_0 = "";

		internal string string_1 = "";

		internal int int_0;

		private int int_1;

		internal int int_2;

		internal int int_3;

		private Regex regex_0 = new Regex("\\w+");

		internal string string_2;

		private List<Class593> list_7 = new List<Class593>();

		private TextControl textControl_0;

		internal TextPartCollection textPartCollection_0;

		internal IFormattedText iformattedText_0;

		internal MisspelledWord misspelledWord_0;

		internal IFormattedText iformattedText_1;

		internal int int_4;

		private int int_5;

		private int int_6;

		private bool bool_6;

		private bool bool_7;

		private Selection selection_0;

		private Regex regex_1 = new Regex("\\s");

		internal Class591(object object_1)
		{
			this.class415_0 = new Class415(object_1);
			this.resourceManager_0 = new ResourceManager(typeof(TextControlCore));
			this.class596_0.method_0(this.method_12());
			this.class596_1.method_0(this.method_13());
			this.class596_2.method_0(this.method_14());
		}

		private object method_0()
		{
			if (this.object_0 == null)
			{
				object obj = this.class415_0.method_36();
				this.object_0 = ((obj == null || !this.class415_0.method_22(obj)) ? this.method_36() : obj);
			}
			return this.object_0;
		}

		private void method_1(object object_1)
		{
			this.method_32(object_1);
			try
			{
				this.object_0 = (this.class415_0.method_22(this.object_0) ? object_1 : null);
			}
			catch
			{
			}
		}

		private void method_2()
		{
			foreach (Class595 item in this.list_0)
			{
				if (item.enum143_0 == Enum143.const_3)
				{
					item.button_0.Text = item.string_0;
					this.bool_0[4] = true;
					item.enum143_0 = item.enum143_1;
					item.button_0.Refresh();
				}
			}
		}

		private void method_3(object object_1)
		{
			if (object_1 != null)
			{
				this.method_1(object_1);
			}
			if (this.method_5(object_1))
			{
				this.method_35();
				this.method_23();
				if (this.method_4())
				{
					this.spellCheckDialogForm_0.ShowDialog(this.textControl_0);
				}
				else
				{
					this.method_29();
				}
				this.method_6();
			}
		}

		private bool method_4()
		{
			this.class596_0.bool_0 = true;
			this.class596_1.bool_0 = true;
			this.class596_2.bool_0 = true;
			return this.misspelledWord_0 != null;
		}

		private bool method_5(object object_1)
		{
			if (!this.method_17())
			{
				return false;
			}
			this.method_32(object_1);
			this.method_7(object_1);
			this.spellCheckDialogForm_0 = new SpellCheckDialogForm(this, this.class415_0);
			return true;
		}

		private void method_6()
		{
			this.method_33();
			this.method_2();
			this.spellCheckDialogForm_0.method_4(this.class596_0);
			this.spellCheckDialogForm_0.method_4(this.class596_1);
			this.spellCheckDialogForm_0.method_4(this.class596_2);
			foreach (object item in this.list_2)
			{
				this.class415_0.method_19(item, bool_1: true);
			}
			this.method_41();
			this.spellCheckDialogForm_0 = null;
			this.textControl_0.HideSelection = this.bool_6;
			this.textControl_0.TextParts.Activate(this.iformattedText_0);
			this.textControl_0.Selection.Start = 0;
			this.textControl_0.Selection.Length = 0;
			this.class596_0.bool_0 = false;
			this.class596_1.bool_0 = false;
			this.class596_2.bool_0 = false;
		}

		private void method_7(object object_1)
		{
			this.list_2.Clear();
			this.list_5.Clear();
			foreach (object item in this.class415_0.CollectionBase_0)
			{
				if (this.class415_0.method_18(item))
				{
					this.list_2.Add(item);
					this.list_5.Add(item);
				}
			}
		}

		private void method_8()
		{
			if (!(this.string_0 != ""))
			{
				return;
			}
			this.spellCheckDialogForm_0.m_cbxSuggestionDictionaries.Items.Clear();
			bool flag = this.misspelledWord_0 != null && this.misspelledWord_0.IsDuplicate;
			this.bool_0[0] = this.class415_0.Boolean_1 && !flag;
			if (this.class415_0.method_38() >= 4 && this.misspelledWord_0.Culture != null)
			{
				if (this.misspelledWord_0.Culture.IetfLanguageTag.Length == 0)
				{
					foreach (object item in this.list_3)
					{
						if (this.class415_0.method_23(item))
						{
							this.spellCheckDialogForm_0.m_cbxSuggestionDictionaries.Items.Add(item);
							break;
						}
					}
				}
				else
				{
					List<object> list = new List<object>();
					List<object> list2 = new List<object>();
					foreach (object item2 in this.list_3)
					{
						CultureInfo cultureInfo = this.class415_0.method_39(item2);
						if (cultureInfo != null)
						{
							if (cultureInfo.IetfLanguageTag == this.misspelledWord_0.Culture.IetfLanguageTag)
							{
								list.Add(item2);
							}
							else if (list.Count == 0 && cultureInfo.IetfLanguageTag.Substring(0, 2) == this.misspelledWord_0.Culture.IetfLanguageTag.Substring(0, 2))
							{
								list2.Add(item2);
							}
						}
					}
					if (list.Count == 0)
					{
						foreach (object item3 in list2)
						{
							this.spellCheckDialogForm_0.m_cbxSuggestionDictionaries.Items.Add(item3);
						}
					}
					else
					{
						foreach (object item4 in list)
						{
							this.spellCheckDialogForm_0.m_cbxSuggestionDictionaries.Items.Add(item4);
						}
					}
				}
				if (this.spellCheckDialogForm_0.m_cbxSuggestionDictionaries.Items.Count > 0)
				{
					this.object_0 = ((this.object_0 == null || !this.list_3.Contains(this.object_0) || !this.spellCheckDialogForm_0.m_cbxSuggestionDictionaries.Items.Contains(this.object_0)) ? this.spellCheckDialogForm_0.m_cbxSuggestionDictionaries.Items[0] : this.object_0);
					int num = this.spellCheckDialogForm_0.m_cbxSuggestionDictionaries.Items.IndexOf(this.object_0);
					num = ((num != -1) ? num : 0);
					this.bool_1 = true;
					this.spellCheckDialogForm_0.m_cbxSuggestionDictionaries.SelectedIndex = num;
				}
				else
				{
					this.object_0 = null;
					this.spellCheckDialogForm_0.m_lbxSuggestions.Items.Clear();
				}
			}
			else
			{
				foreach (object item5 in this.list_3)
				{
					this.spellCheckDialogForm_0.m_cbxSuggestionDictionaries.Items.Add(item5);
				}
				if (this.spellCheckDialogForm_0.m_cbxSuggestionDictionaries.Items.Count > 0)
				{
					this.object_0 = ((this.object_0 == null || !this.list_3.Contains(this.object_0) || !this.spellCheckDialogForm_0.m_cbxSuggestionDictionaries.Items.Contains(this.object_0)) ? this.method_36() : this.object_0);
					int num2 = this.spellCheckDialogForm_0.m_cbxSuggestionDictionaries.Items.IndexOf(this.object_0);
					num2 = ((num2 != -1) ? num2 : 0);
					this.bool_1 = true;
					this.spellCheckDialogForm_0.m_cbxSuggestionDictionaries.SelectedIndex = num2;
				}
				else
				{
					this.object_0 = null;
					this.spellCheckDialogForm_0.m_lbxSuggestions.Items.Clear();
				}
			}
			foreach (object item6 in this.class415_0.CollectionBase_0)
			{
				this.class415_0.method_21(item6, bool_1: false);
			}
			if (this.object_0 != null)
			{
				this.class415_0.method_21(this.object_0, bool_1: true);
			}
		}

		private void method_9(Enum143 enum143_0, bool bool_8)
		{
			foreach (Class595 item in this.class596_0)
			{
				if (item.enum143_0 == enum143_0)
				{
					if (item.bool_3)
					{
						item.bool_3 = false;
					}
					else
					{
						item.button_0.Enabled = bool_8;
					}
				}
			}
			foreach (Class595 item2 in this.class596_1)
			{
				if (item2.enum143_0 == enum143_0)
				{
					if (item2.bool_3)
					{
						item2.bool_3 = false;
					}
					else
					{
						item2.button_0.Enabled = bool_8;
					}
				}
			}
			foreach (Class595 item3 in this.class596_2)
			{
				if (item3.enum143_0 == enum143_0)
				{
					if (item3.bool_3)
					{
						item3.bool_3 = false;
					}
					else
					{
						item3.button_0.Enabled = bool_8;
					}
				}
			}
		}

		private void method_10()
		{
			this.spellCheckDialogForm_0.m_lbxSuggestions.Items.Clear();
			this.bool_2 = false;
			if ((!(this.string_0 != "") && this.misspelledWord_0 == null) || this.bool_4)
			{
				return;
			}
			this.class415_0.method_6(this.string_0, 10);
			foreach (object item in this.class415_0.CollectionBase_3)
			{
				this.spellCheckDialogForm_0.m_lbxSuggestions.Items.Add(item);
				this.bool_2 = true;
			}
			if (!this.bool_2)
			{
				this.spellCheckDialogForm_0.m_lbxSuggestions.Items.Add(this.resourceManager_0.GetString("ITM_NO_SUGGESTIONS"));
			}
		}

		private bool method_11(object object_1)
		{
			foreach (object item in this.class415_0.CollectionBase_0)
			{
				if (item == object_1)
				{
					return true;
				}
			}
			return false;
		}

		private Class595[] method_12()
		{
			Class595 @class = new Class595(Enum143.const_4);
			@class.Boolean_1 = true;
			@class.button_0.Text = this.resourceManager_0.GetString("ID_SPELL_BTN_IGNORE_ONCE");
			this.class595_0 = @class;
			Class595 class2 = new Class595(Enum143.const_5);
			class2.button_0.Text = this.resourceManager_0.GetString("ID_SPELL_BTN_IGNORE_ALL");
			Class595 class3 = new Class595(Enum143.const_0);
			class3.button_0.Text = this.resourceManager_0.GetString("ID_SPELL_BTN_ADD_TO_DICTIONARY");
			return new Class595[3] { @class, class2, class3 };
		}

		private Class595[] method_13()
		{
			Class595 @class = new Class595(Enum143.const_1);
			@class.Boolean_0 = true;
			@class.button_0.Text = this.resourceManager_0.GetString("ID_SPELL_BTN_CHANGE");
			Class595 class2 = new Class595(Enum143.const_2);
			class2.button_0.Text = this.resourceManager_0.GetString("ID_SPELL_BTN_CHANGE_ALL");
			return new Class595[2] { @class, class2 };
		}

		private Class595[] method_14()
		{
			Class595 @class = new Class595(Enum143.const_6);
			@class.button_0.Text = this.resourceManager_0.GetString("ID_SPELL_BTN_OPTIONS");
			return new Class595[1] { @class };
		}

		private void method_15()
		{
			this.list_6.Clear();
			foreach (object item in this.class415_0.CollectionBase_0)
			{
				this.list_6.Add(item);
				this.class415_0.method_19(item, bool_1: false);
				this.class415_0.method_20(this.object_0, bool_1: false);
				this.class415_0.method_21(item, bool_1: false);
			}
			foreach (object item2 in this.list_3)
			{
				this.class415_0.method_20(this.object_0, bool_1: true);
				this.class415_0.method_21(item2, bool_1: true);
			}
			foreach (object item3 in this.list_2)
			{
				this.class415_0.method_19(item3, bool_1: true);
			}
		}

		private DialogResult method_16(string string_3)
		{
			DialogResult result = DialogResult.OK;
			if (this.class415_0.method_38() >= 4 && this.misspelledWord_0.Culture != null)
			{
				this.class415_0.method_3(this.string_2, this.misspelledWord_0.Culture);
			}
			else
			{
				this.class415_0.method_2(this.string_2);
			}
			if (this.class415_0.CollectionBase_1.Count > 0)
			{
				result = DialogResult.Ignore;
				if (this.class415_0.method_38() >= 4 && this.misspelledWord_0.Culture != null)
				{
					this.class415_0.method_8(string_3, 1, this.misspelledWord_0.Culture);
				}
				else
				{
					this.class415_0.method_6(string_3, 1);
				}
				bool flag;
				if (!(flag = this.class415_0.CollectionBase_3.Count == 0))
				{
					foreach (object item in this.class415_0.CollectionBase_3)
					{
						flag = item.ToString().ToLower() != string_3.ToLower();
					}
				}
				if (flag && MessageBox.Show(this.resourceManager_0.GetString("MSG_USE_EDITED_WORD"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
				{
					return DialogResult.Abort;
				}
			}
			return result;
		}

		private bool method_17()
		{
			bool flag = false;
			foreach (IFormattedText item in this.textPartCollection_0)
			{
				MisspelledWordCollection misspelledWords = item.MisspelledWords;
				if (misspelledWords.Count > misspelledWords.GetCount(MisspelledWordKind.Ignored))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				MessageBox.Show(this.resourceManager_0.GetString("ERR_NOMISSPELLEDWORDS"), "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			return flag;
		}

		private string method_18()
		{
			if (this.misspelledWord_0 != null)
			{
				this.int_2 = this.misspelledWord_0.Start;
				this.int_3 = this.misspelledWord_0.Length;
				this.string_0 = this.misspelledWord_0.Text;
				ParagraphCollection paragraphs = this.iformattedText_1.Paragraphs;
				Paragraph item = paragraphs.GetItem(this.int_2 - 1);
				string text = item.Text;
				Regex regex = new Regex("(.*?[.!?](?=(\\s+[^\\d\\s\\p{P}]+))(\\s+))|(.*?[.!?](?=(\\s*$))(\\s*))|(.*$)");
				string text2 = "[^AEIOUYaeiouyÀ-ÆÈ-ÏÒ-ÖØ-Ýà-æè-ïò-öø-ýÿ-ąĒ-ěĨ-ĳŌ-œŨ-ųŶ-ŸƆƎ-ƐƖƗƟ-ƣƯ-ƱƳƴǍ-ǣǪ-ǭǺ-ȏȔ-ȗȢȣȦ-ȳȺɁɄɆɇɎɏ\\s]";
				Regex regex2 = new Regex("((?<=^)" + text2 + "{2,}\\.(?=(\\s\\w)))");
				Regex regex3 = new Regex("((?<=\\s)" + text2 + "{2,}\\.(?=(\\s\\w)))");
				Regex regex4 = new Regex("((?<=^)" + text2 + "{2,}\\.(?=(\\s$)))");
				Regex regex5 = new Regex("((?<=\\s)" + text2 + "{2,}\\.(?=(\\s$)))");
				Regex regex6 = new Regex("(?<=^)[^\\d\\s\\p{P}]\\.(?=(\\s$))");
				Regex regex7 = new Regex("(?<=^)[^\\d\\s\\p{P}]\\.(?=(\\s\\w))");
				Regex regex8 = new Regex("(?<=\\s)[^\\d\\s\\p{P}]\\.(?=(\\s$))");
				Regex regex9 = new Regex("(?<=\\s)[^\\d\\s\\p{P}]\\.(?=(\\s\\w))");
				Regex regex10 = new Regex("(?<=^)\\d+\\.(?=(\\s$))");
				Regex regex11 = new Regex("(?<=^)\\d+\\.(?=(\\s\\w))");
				Regex regex12 = new Regex("(?<=\\s)\\d+\\.(?=(\\s$))");
				Regex regex13 = new Regex("(?<=\\s)\\d+\\.(?=(\\s\\w))");
				MatchCollection matchCollection = regex.Matches(text.Replace("\r\n", " "));
				this.int_5 = item.Start;
				this.int_6 = item.Length;
				this.int_0 = this.int_5;
				for (int i = 0; i < matchCollection.Count; i++)
				{
					Match match = matchCollection[i];
					this.int_0 = match.Index + this.int_5;
					this.int_1 = this.int_0 + match.Length - 1;
					string value = match.Value;
					string text3 = match.Value;
					_ = value.Length;
					while (regex2.IsMatch(value) || regex3.IsMatch(value) || regex4.IsMatch(value) || regex5.IsMatch(value) || regex6.IsMatch(value) || regex7.IsMatch(value) || regex8.IsMatch(value) || regex9.IsMatch(value) || regex10.IsMatch(value) || regex11.IsMatch(value) || regex12.IsMatch(value) || regex13.IsMatch(value))
					{
						i++;
						if (i >= matchCollection.Count)
						{
							break;
						}
						this.int_1 += matchCollection[i].Length;
						value = matchCollection[i].Value;
						text3 += matchCollection[i].Value;
					}
					if (this.int_2 >= this.int_0 && this.int_2 < this.int_1)
					{
						return text3;
					}
				}
			}
			return "";
		}

		private void method_19(IFormattedText iformattedText_2, string string_3)
		{
			MisspelledWordCollection misspelledWords = iformattedText_2.MisspelledWords;
			foreach (MisspelledWord item in misspelledWords)
			{
				string text = item.Text;
				if (string_3 == text && !this.method_28(item, string_3))
				{
					item.IsIgnored = true;
					item.IsDuplicate = false;
				}
			}
		}

		private bool method_20(IFormattedText iformattedText_2, MisspelledWord misspelledWord_1)
		{
			int start = misspelledWord_1.Start;
			ParagraphCollection paragraphs = iformattedText_2.Paragraphs;
			Paragraph item = paragraphs.GetItem(start - 1);
			int start2 = item.Start;
			string text = item.Text;
			MatchCollection matchCollection = this.regex_0.Matches(text);
			int num = 1;
			while (true)
			{
				if (num < matchCollection.Count)
				{
					Match match = matchCollection[num];
					if (match.Index == start - start2 && matchCollection[num - 1].Value == matchCollection[num].Value)
					{
						break;
					}
					num++;
					continue;
				}
				return false;
			}
			return true;
		}

		private void method_21(TextControl textControl_1)
		{
			this.textControl_0 = textControl_1;
			this.int_4 = 0;
			this.textPartCollection_0 = this.textControl_0.TextParts;
			this.iformattedText_0 = (this.iformattedText_1 = this.textPartCollection_0.GetMainText());
			this.bool_6 = this.textControl_0.HideSelection;
			this.textControl_0.HideSelection = this.bool_7;
			this.selection_0 = this.iformattedText_0.Selection;
			this.selection_0.Start = 0;
			this.selection_0.Length = 0;
		}

		private void method_22()
		{
			this.list_7.Sort();
			if (this.list_7.Count <= 0)
			{
				return;
			}
			int num = 0;
			int num2 = 0;
			foreach (IFormattedText item2 in this.textPartCollection_0)
			{
				MisspelledWordCollection misspelledWords = item2.MisspelledWords;
				if (misspelledWords.Count > 0)
				{
					for (int i = num2; i < this.list_7.Count; i++)
					{
						Class593 @class = this.list_7[i];
						if (@class.int_0 == num)
						{
							MisspelledWord item = misspelledWords.GetItem(@class.int_1);
							if (item != null && item.Start == @class.int_1 && item.Text == @class.string_0)
							{
								item.IsIgnored = @class.bool_0;
							}
							continue;
						}
						num2 = i;
						break;
					}
				}
				num++;
			}
		}

		private void method_23()
		{
			if (this.iformattedText_1 != null)
			{
				MisspelledWordCollection misspelledWords = this.iformattedText_1.MisspelledWords;
				if (misspelledWords.Count > misspelledWords.GetCount(MisspelledWordKind.Ignored))
				{
					this.misspelledWord_0 = misspelledWords.GetItem(MisspelledWordKind.Normal | MisspelledWordKind.Duplicate);
					while (this.misspelledWord_0.IsIgnored)
					{
						this.misspelledWord_0 = misspelledWords.GetItem(this.misspelledWord_0.Start + this.misspelledWord_0.Length, MisspelledWordKind.Normal | MisspelledWordKind.Duplicate);
					}
				}
				else
				{
					Selection selection = this.iformattedText_1.Selection;
					selection.Length = 0;
					this.iformattedText_1 = null;
					this.misspelledWord_0 = null;
					this.method_23();
				}
				return;
			}
			int num = 1;
			foreach (IFormattedText item in this.textPartCollection_0)
			{
				num++;
				if (num <= this.int_4 && (!this.bool_5 || this.int_4 != this.textPartCollection_0.Count))
				{
					continue;
				}
				if (this.int_4 == this.textPartCollection_0.Count)
				{
					this.bool_5 = false;
				}
				MisspelledWordCollection misspelledWords2 = item.MisspelledWords;
				if (misspelledWords2.Count > misspelledWords2.GetCount(MisspelledWordKind.Ignored))
				{
					Selection selection2 = item.Selection;
					selection2.Start = 0;
					selection2.Length = 0;
					this.misspelledWord_0 = misspelledWords2.GetItem(MisspelledWordKind.Normal | MisspelledWordKind.Duplicate);
					while (this.misspelledWord_0.IsIgnored)
					{
						this.misspelledWord_0 = misspelledWords2.GetItem(this.misspelledWord_0.Start + this.misspelledWord_0.Length, MisspelledWordKind.Normal | MisspelledWordKind.Duplicate);
					}
					this.iformattedText_1 = item;
					this.textPartCollection_0.Activate(this.iformattedText_1);
					this.int_4 = num;
					break;
				}
			}
		}

		private void method_24()
		{
			int num = 0;
			this.list_7.Clear();
			foreach (IFormattedText item2 in this.textPartCollection_0)
			{
				MisspelledWordCollection misspelledWords = item2.MisspelledWords;
				int count;
				if ((count = misspelledWords.GetCount(MisspelledWordKind.Ignored)) > 0)
				{
					int textPosition = 0;
					for (int i = 0; i < count; i++)
					{
						MisspelledWord item = misspelledWords.GetItem(textPosition, MisspelledWordKind.Ignored);
						int start = item.Start;
						int length = item.Length;
						string text = item.Text;
						Class593 @class = new Class593(num, start, text);
						@class.bool_0 = item.IsIgnored;
						this.list_7.Add(@class);
						textPosition = start + length;
					}
				}
				num++;
			}
		}

		private void method_25(IFormattedText iformattedText_2, string string_3, bool bool_8)
		{
			bool flag = bool_8;
			MisspelledWordCollection misspelledWords = iformattedText_2.MisspelledWords;
			int num = misspelledWords.Count;
			for (int i = 1; i <= num; i++)
			{
				MisspelledWord misspelledWord = misspelledWords[i];
				string text = misspelledWord.Text;
				if (!(string_3 == text) || misspelledWord.IsIgnored)
				{
					continue;
				}
				if (this.class415_0.method_38() >= 4 && misspelledWord.Culture != null)
				{
					this.class415_0.method_3(this.string_2, misspelledWord.Culture);
				}
				else
				{
					this.class415_0.method_2(this.string_2);
				}
				flag = ((this.class415_0.CollectionBase_1.Count > 0) ? true : false);
				if (!this.method_28(misspelledWord, this.string_2))
				{
					if (!flag)
					{
						i--;
						num--;
					}
					this.method_26(misspelledWords, misspelledWord, this.string_2, flag);
				}
				else
				{
					misspelledWords.Ignore(misspelledWord, this.string_2);
					misspelledWord.IsIgnored = false;
				}
			}
		}

		private void method_26(MisspelledWordCollection misspelledWordCollection_0, MisspelledWord misspelledWord_1, string string_3, bool bool_8)
		{
			if (bool_8)
			{
				misspelledWordCollection_0.Ignore(misspelledWord_1, string_3);
				misspelledWord_1.IsDuplicate = false;
			}
			else
			{
				misspelledWordCollection_0.Remove(misspelledWord_1, string_3);
			}
		}

		private void method_27()
		{
			if (this.misspelledWord_0 != null && this.misspelledWord_0.IsDuplicate)
			{
				this.bool_4 = true;
				_ = this.misspelledWord_0.Text;
				this.bool_0[4] = true;
				this.bool_0[5] = false;
				this.bool_0[0] = false;
				this.bool_0[2] = false;
				foreach (Class595 item in this.list_0)
				{
					if (item.enum143_0 != Enum143.const_3 && item.Boolean_0)
					{
						item.bool_2 = item.button_0.Enabled;
						item.string_0 = item.button_0.Text;
						item.enum143_1 = item.enum143_0;
						this.bool_0[3] = true;
						item.button_0.Text = this.resourceManager_0.GetString("ID_SPELL_BTN_DELETE");
						item.enum143_0 = Enum143.const_3;
					}
					if (item.enum143_1 == Enum143.const_3 && item.Boolean_0)
					{
						item.button_0.Text = this.resourceManager_0.GetString("ID_SPELL_BTN_DELETE");
					}
				}
				this.spellCheckDialogForm_0.m_cbxSuggestionDictionaries.Enabled = false;
			}
			else
			{
				this.method_2();
				this.bool_4 = false;
				this.bool_0[4] = true;
				this.bool_0[5] = true;
				this.bool_0[0] = this.class415_0.Boolean_1;
				this.bool_0[1] = true;
				this.bool_0[2] = true;
				this.spellCheckDialogForm_0.m_cbxSuggestionDictionaries.Enabled = true;
			}
		}

		private bool method_28(MisspelledWord misspelledWord_1, string string_3)
		{
			if (this.class415_0.Boolean_2)
			{
				misspelledWord_1.IsDuplicate = false;
				ParagraphCollection paragraphs = this.iformattedText_1.Paragraphs;
				int start = misspelledWord_1.Start;
				_ = misspelledWord_1.Text;
				Paragraph item = paragraphs.GetItem(start - 1);
				int start2 = item.Start;
				string text = item.Text;
				MatchCollection matchCollection = this.regex_0.Matches(text);
				for (int i = 1; i < matchCollection.Count; i++)
				{
					Match match = matchCollection[i];
					if (match.Index == start - start2 && matchCollection[i - 1].Value.ToLower() == string_3.ToLower())
					{
						misspelledWord_1.IsDuplicate = true;
						return true;
					}
				}
			}
			return false;
		}

		internal void method_29()
		{
			bool flag = this.misspelledWord_0 == null;
			this.method_15();
			if (flag)
			{
				MessageBox.Show(this.resourceManager_0.GetString("MSG_SPELL_CHECKING_COMPLETE"), "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			this.textPartCollection_0.Activate(this.iformattedText_0);
		}

		internal void method_30()
		{
			if (!this.bool_1)
			{
				for (int i = 0; i < this.bool_0.Length; i++)
				{
					switch (i)
					{
					case 0:
						this.method_9(Enum143.const_0, this.bool_0[i]);
						break;
					case 1:
						this.method_9(Enum143.const_1, this.bool_0[i]);
						break;
					case 2:
						this.method_9(Enum143.const_2, this.bool_0[i]);
						break;
					case 3:
						this.method_9(Enum143.const_3, this.bool_0[i]);
						break;
					case 4:
						this.method_9(Enum143.const_4, this.bool_0[i]);
						break;
					case 5:
						this.method_9(Enum143.const_5, this.bool_0[i]);
						break;
					case 6:
						this.method_9(Enum143.const_6, this.bool_0[i]);
						break;
					case 7:
						this.method_9(Enum143.const_7, this.bool_0[i]);
						break;
					}
				}
				this.bool_0 = new bool[9] { true, true, true, true, true, true, true, false, true };
			}
			this.bool_1 = false;
		}

		internal void method_31()
		{
			foreach (Class595 item in this.list_1)
			{
				item.button_0.Enabled = true;
				if (item.enum143_0 != Enum143.const_7 && item.Boolean_1)
				{
					item.bool_2 = item.button_0.Enabled;
					item.string_0 = item.button_0.Text;
					item.enum143_1 = item.enum143_0;
					item.button_0.Text = this.resourceManager_0.GetString("ID_SPELL_BTN_UNDO_EDIT");
					item.enum143_0 = Enum143.const_7;
				}
				if (item.enum143_1 == Enum143.const_7)
				{
					item.bool_2 = item.button_0.Enabled;
					if (item.Boolean_1)
					{
						item.button_0.Text = this.resourceManager_0.GetString("ID_SPELL_BTN_UNDO_EDIT");
					}
				}
			}
			foreach (Class595 item2 in this.list_0)
			{
				if (item2.enum143_0 == Enum143.const_3)
				{
					item2.button_0.Text = item2.string_0;
					item2.button_0.Enabled = item2.bool_2;
					item2.enum143_0 = item2.enum143_1;
				}
			}
			this.spellCheckDialogForm_0.m_lbxSuggestions.SelectionMode = SelectionMode.None;
			this.spellCheckDialogForm_0.m_lbxSuggestions.Enabled = false;
			this.method_9(Enum143.const_5, bool_8: false);
			this.method_9(Enum143.const_1, bool_8: true);
			this.method_9(Enum143.const_2, bool_8: true);
			this.method_9(Enum143.const_0, bool_8: false);
		}

		internal void method_32(object object_1)
		{
			if (object_1 != null)
			{
				if (!this.method_11(object_1))
				{
					throw new ArgumentException(this.resourceManager_0.GetString("ERR_INVALID_SUGGESTIONS"));
				}
				if (!this.class415_0.method_22(object_1) && this.list_3.Contains(object_1))
				{
				}
			}
		}

		internal void method_33()
		{
			foreach (Class595 item in this.list_1)
			{
				if (item.enum143_0 == Enum143.const_7)
				{
					item.button_0.Text = item.string_0;
					this.bool_0[7] = false;
					item.enum143_0 = item.enum143_1;
					item.button_0.Refresh();
				}
			}
		}

		internal void method_34()
		{
			this.int_2 = 0;
			this.int_3 = 0;
			this.string_0 = "";
			this.spellCheckDialogForm_0.m_rtbPreview.ResetText();
			this.spellCheckDialogForm_0.m_rtbPreview.Text = this.method_18();
			this.class594_0.method_0(this.misspelledWord_0, this.int_0);
		}

		internal void method_35()
		{
			this.list_2.Clear();
			this.list_3.Clear();
			foreach (object item in this.class415_0.CollectionBase_0)
			{
				if (this.class415_0.method_18(item))
				{
					if (!this.list_6.Contains(item) && this.class415_0.method_18(item))
					{
						this.list_5.Add(item);
						this.list_6.Remove(item);
					}
					this.list_2.Add(item);
					this.class415_0.method_19(item, bool_1: false);
				}
				if (this.class415_0.method_22(item))
				{
					this.list_3.Add(item);
				}
			}
			foreach (object item2 in this.list_5)
			{
				this.class415_0.method_19(item2, bool_1: true);
			}
		}

		internal object method_36()
		{
			foreach (object item in this.class415_0.CollectionBase_0)
			{
				if (this.class415_0.method_22(item))
				{
					return item;
				}
			}
			return null;
		}

		internal void method_37()
		{
			this.method_34();
			this.bool_3 = false;
			this.method_8();
			this.bool_3 = true;
			if (this.class595_0 != null)
			{
				this.spellCheckDialogForm_0.AcceptButton = this.class595_0.button_0;
			}
			this.method_27();
			this.method_10();
			this.method_39();
			if (this.class595_0 != null)
			{
				this.class595_0.button_0.Focus();
			}
			this.method_30();
			if (this.misspelledWord_0 != null)
			{
				this.textControl_0.HideSelection = this.bool_7;
				this.misspelledWord_0.Select();
				this.spellCheckDialogForm_0.m_lblLanguge.Text = this.resourceManager_0.GetString("ID_SPELL_LBL_LANGUAGE");
				this.spellCheckDialogForm_0.m_lblLanguge.Text += ((this.misspelledWord_0.Culture == null || this.misspelledWord_0.Culture.IetfLanguageTag.Length == 0) ? this.resourceManager_0.GetString("ID_SPELL_LBL_NEUTRAL_LANGUAGE") : new Class592(this.misspelledWord_0.Culture).ToString());
			}
		}

		internal void method_38()
		{
			this.spellCheckDialogForm_0.m_rtbPreview.ResetText();
			this.spellCheckDialogForm_0.m_rtbPreview.ReadOnly = true;
			this.bool_0[0] = false;
			this.bool_0[1] = false;
			this.bool_0[2] = false;
			this.bool_0[3] = false;
			this.bool_0[4] = false;
			this.bool_0[5] = false;
			this.bool_0[6] = false;
			this.bool_0[7] = false;
			this.bool_0[8] = false;
			this.method_30();
			this.spellCheckDialogForm_0.m_lbxSuggestions.Items.Clear();
			this.spellCheckDialogForm_0.m_cbxSuggestionDictionaries.Items.Clear();
		}

		internal void method_39()
		{
			if (this.class415_0.method_38() >= 4 && this.misspelledWord_0 != null)
			{
				this.bool_0[0] = this.class415_0.method_46(this.class415_0.CollectionBase_0, this.misspelledWord_0.Culture).Count > 0;
			}
			else
			{
				this.bool_0[0] = this.class415_0.Boolean_1;
			}
			if (this.bool_2)
			{
				this.spellCheckDialogForm_0.m_lbxSuggestions.Enabled = true;
				this.spellCheckDialogForm_0.m_lbxSuggestions.SelectionMode = SelectionMode.One;
				this.bool_0[1] = true;
				this.bool_0[2] = true;
				this.spellCheckDialogForm_0.m_lbxSuggestions.SelectedIndex = 0;
				return;
			}
			this.spellCheckDialogForm_0.m_lbxSuggestions.Enabled = false;
			this.spellCheckDialogForm_0.m_lbxSuggestions.SelectionMode = SelectionMode.None;
			this.bool_0[1] = false;
			this.bool_0[2] = false;
			if (this.misspelledWord_0 == null)
			{
				this.bool_0[5] = false;
				this.bool_0[0] = false;
				this.bool_0[4] = false;
				this.bool_0[3] = false;
			}
		}

		internal void method_40()
		{
			if (!this.bool_3)
			{
				return;
			}
			foreach (object item in this.class415_0.CollectionBase_0)
			{
				this.class415_0.method_21(item, bool_1: false);
			}
			this.object_0 = (this.class415_0.method_34(this.spellCheckDialogForm_0.m_cbxSuggestionDictionaries.SelectedItem) ? this.spellCheckDialogForm_0.m_cbxSuggestionDictionaries.SelectedItem : null);
			if (this.object_0 != null)
			{
				this.class415_0.method_20(this.object_0, bool_1: true);
				this.class415_0.method_21(this.object_0, bool_1: true);
			}
			this.method_10();
			this.method_39();
		}

		internal void method_41()
		{
			this.misspelledWord_0 = null;
			this.iformattedText_1 = null;
			this.int_2 = -1;
			this.int_3 = -1;
			this.string_0 = "";
			this.int_4 = 0;
			this.list_7.Clear();
		}

		internal void method_42(TextControl textControl_1)
		{
			object object_;
			if ((object_ = this.method_0()) == null)
			{
				this.method_21(textControl_1);
				this.method_3(null);
			}
			else
			{
				this.method_43(textControl_1, object_);
			}
		}

		internal void method_43(TextControl textControl_1, object object_1)
		{
			this.method_21(textControl_1);
			if (object_1 == null)
			{
				throw new NullReferenceException(this.resourceManager_0.GetString("ERR_DICTIONARY_IS_NULL"));
			}
			this.method_3(object_1);
		}

		internal void method_44()
		{
			bool flag = false;
			if (this.class415_0.method_38() >= 4)
			{
				List<object> list = this.class415_0.method_46(this.class415_0.CollectionBase_0, this.misspelledWord_0.Culture);
				foreach (object item in list)
				{
					this.class415_0.method_16(item, this.string_0);
					flag = this.list_2.Contains(item) || flag;
				}
			}
			else
			{
				foreach (object item2 in this.class415_0.CollectionBase_0)
				{
					if (this.class415_0.method_35(item2) && this.class415_0.method_17(item2))
					{
						this.class415_0.method_16(item2, this.string_0);
						flag = this.list_2.Contains(item2) || flag;
					}
				}
			}
			if (flag)
			{
				this.method_49();
			}
			else
			{
				this.method_48();
			}
		}

		internal void method_45(string string_3)
		{
			MisspelledWordCollection misspelledWords = this.iformattedText_1.MisspelledWords;
			this.string_2 = string_3;
			DialogResult dialogResult = this.method_16(this.string_2);
			if (dialogResult != DialogResult.Abort)
			{
				if (this.class415_0.method_38() >= 4 && this.misspelledWord_0.Culture != null)
				{
					this.class415_0.method_3(this.string_2, this.misspelledWord_0.Culture);
				}
				else
				{
					this.class415_0.method_2(this.string_2);
				}
				dialogResult = ((this.class415_0.CollectionBase_1.Count <= 0) ? DialogResult.OK : DialogResult.Ignore);
				bool bool_ = ((dialogResult == DialogResult.Ignore) ? true : false);
				if (!this.method_28(this.misspelledWord_0, this.string_2))
				{
					this.method_26(misspelledWords, this.misspelledWord_0, this.string_2, bool_);
				}
				else
				{
					misspelledWords.Ignore(this.misspelledWord_0, this.string_2);
					this.misspelledWord_0.IsIgnored = false;
				}
				this.method_23();
			}
		}

		internal void method_46(string string_3)
		{
			string text = this.misspelledWord_0.Text;
			this.string_2 = string_3;
			int num;
			switch (this.method_16(this.string_2))
			{
			default:
				num = 0;
				break;
			case DialogResult.Ignore:
				num = 1;
				break;
			case DialogResult.Abort:
				return;
			}
			bool bool_ = (byte)num != 0;
			foreach (IFormattedText item in this.textPartCollection_0)
			{
				this.method_25(item, text, bool_);
			}
			Selection selection = this.iformattedText_1.Selection;
			selection.Start = 0;
			selection.Length = 0;
			this.method_23();
		}

		internal void method_47()
		{
			Paragraph item = this.iformattedText_1.Paragraphs.GetItem(this.int_2);
			string text = item.Text;
			Selection selection = this.iformattedText_1.Selection;
			this.method_18();
			int num;
			int num2;
			if (this.int_2 == this.int_5)
			{
				num = 1;
				if (this.int_6 == this.int_3)
				{
					num2 = 0;
				}
				else
				{
					string input = text.Substring(this.int_3, 1);
					num2 = (this.regex_1.IsMatch(input) ? 1 : 0);
				}
			}
			else
			{
				string input2 = text.Substring(this.int_2 - this.int_5 - 1, 1);
				if (!this.misspelledWord_0.IsDuplicate && !this.regex_1.IsMatch(input2))
				{
					num = 1;
					num2 = 0;
				}
				else
				{
					num = 2;
					num2 = 1;
				}
			}
			this.method_24();
			selection.Start = this.int_2 - num;
			selection.Length = this.int_3 + num2;
			selection.Text = "";
			selection.Length = 0;
			this.method_22();
			this.method_23();
			if (this.misspelledWord_0 != null)
			{
				this.method_28(this.misspelledWord_0, this.misspelledWord_0.Text);
			}
		}

		internal void method_48()
		{
			this.string_2 = "";
			this.misspelledWord_0.IsIgnored = true;
			this.misspelledWord_0.IsDuplicate = false;
			this.method_23();
		}

		internal void method_49()
		{
			string text = this.misspelledWord_0.Text;
			this.string_2 = "";
			foreach (IFormattedText item in this.textPartCollection_0)
			{
				this.method_19(item, text);
			}
			Selection selection = this.iformattedText_1.Selection;
			selection.Start = 0;
			selection.Length = 0;
			this.method_23();
		}

		internal void method_50()
		{
			this.method_15();
			this.method_24();
			if (this.class415_0.method_38() >= 4)
			{
				this.class415_0.method_33(new int[2] { 0, 1 });
			}
			else
			{
				this.class415_0.method_32();
			}
			this.method_33();
			this.method_35();
			this.textControl_0.IsSpellCheckingEnabled = false;
			this.textControl_0.IsSpellCheckingEnabled = true;
			this.iformattedText_0.Selection.Start = 0;
			this.method_22();
			this.method_23();
		}
	}
}
