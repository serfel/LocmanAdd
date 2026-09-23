using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using ns23;
using TXTextControl;

namespace ns27
{
	internal class Class589
	{
		private TextControl textControl_0;

		private ResourceManager resourceManager_0;

		private ContextMenuStrip contextMenuStrip_0 = new ContextMenuStrip();

		private Class415 class415_0;

		private MisspelledWord misspelledWord_0;

		private MisspelledWordCollection misspelledWordCollection_0;

		private string string_0 = "(Default)";

		internal string String_0
		{
			get
			{
				return this.string_0;
			}
			set
			{
				this.string_0 = value;
			}
		}

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

		internal Class415 Class415_0
		{
			set
			{
				this.class415_0 = value;
			}
		}

		internal Class589()
		{
			this.contextMenuStrip_0.ItemClicked += contextMenuStrip_0_ItemClicked;
			this.resourceManager_0 = new ResourceManager(typeof(TextControlCore));
		}

		internal ContextMenuStrip method_0(TextControlCore textControlCore_0, int int_0)
		{
			ContextMenuStrip result = null;
			if (this.textControl_0 == null)
			{
				return null;
			}
			if (this.textControl_0.SpellChecker == null)
			{
				return null;
			}
			if (this.string_0 == "(none)")
			{
				return null;
			}
			if (this.class415_0 == null)
			{
				return null;
			}
			this.misspelledWordCollection_0 = new MisspelledWordCollection(textControlCore_0, TextPart.Auto);
			this.misspelledWord_0 = this.misspelledWordCollection_0[int_0];
			if (this.misspelledWord_0 != null)
			{
				if (this.string_0 == "(Default)")
				{
					this.method_1();
					result = this.contextMenuStrip_0;
				}
				else
				{
					result = this.method_2(this.textControl_0, this.string_0);
				}
			}
			return result;
		}

		private void method_1()
		{
			this.contextMenuStrip_0.Items.Clear();
			bool isDuplicate;
			if (isDuplicate = this.misspelledWord_0.IsDuplicate)
			{
				this.contextMenuStrip_0.Items.Add(new ToolStripMenuItem(this.resourceManager_0.GetString("MENU_SPELLDELETE")));
			}
			else
			{
				if (this.class415_0.method_38() >= 4 && this.misspelledWord_0.Culture != null)
				{
					this.class415_0.method_8(this.misspelledWord_0.Text, 5, this.misspelledWord_0.Culture);
				}
				else
				{
					this.class415_0.method_6(this.misspelledWord_0.Text, 5);
				}
				CollectionBase collectionBase_ = this.class415_0.CollectionBase_3;
				if (collectionBase_.Count > 0)
				{
					foreach (object item in collectionBase_)
					{
						ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem(item.ToString());
						toolStripMenuItem.Font = new Font(toolStripMenuItem.Font, FontStyle.Bold);
						toolStripMenuItem.Tag = "TXSPELL";
						this.contextMenuStrip_0.Items.Add(toolStripMenuItem);
					}
				}
				else
				{
					ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem(this.resourceManager_0.GetString("MENU_NOSUGGESTIONS"));
					toolStripMenuItem2.Enabled = false;
					this.contextMenuStrip_0.Items.Add(toolStripMenuItem2);
				}
			}
			this.contextMenuStrip_0.Items.Add(new ToolStripSeparator());
			this.contextMenuStrip_0.Items.Add(new ToolStripMenuItem(this.resourceManager_0.GetString("MENU_SPELLIGNORE")));
			if (!isDuplicate)
			{
				this.contextMenuStrip_0.Items.Add(new ToolStripMenuItem(this.resourceManager_0.GetString("MENU_SPELLIGNOREALL")));
				ToolStripMenuItem toolStripMenuItem3 = new ToolStripMenuItem(this.resourceManager_0.GetString("MENU_SPELLADDTODICTIONARY"));
				toolStripMenuItem3.Enabled = false;
				CollectionBase collectionBase_2 = this.class415_0.CollectionBase_0;
				if (this.class415_0.method_38() >= 4)
				{
					toolStripMenuItem3.Enabled = this.class415_0.method_46(collectionBase_2, this.misspelledWord_0.Culture).Count > 0;
				}
				else
				{
					foreach (object item2 in collectionBase_2)
					{
						if (item2.GetType().Name == "UserDictionary" && this.class415_0.method_17(item2))
						{
							toolStripMenuItem3.Enabled = true;
							break;
						}
					}
				}
				this.contextMenuStrip_0.Items.Add(toolStripMenuItem3);
			}
			this.contextMenuStrip_0.Items.Add(new ToolStripSeparator());
			this.contextMenuStrip_0.Items.Add(new ToolStripMenuItem(this.resourceManager_0.GetString("MENU_SPELLCHECKDIALOG")));
			this.contextMenuStrip_0.Items.Add(new ToolStripMenuItem(this.resourceManager_0.GetString("MENU_SPELLCHECKOPTIONS")));
		}

		private ContextMenuStrip method_2(Control control_0, string string_1)
		{
			if (control_0 != null)
			{
				if (control_0 is Form)
				{
					return this.method_4((Form)control_0, string_1);
				}
				return this.method_2(control_0.Parent, string_1);
			}
			return null;
		}

		private void method_3(string string_1, bool bool_0)
		{
			if (bool_0)
			{
				this.misspelledWordCollection_0.Remove(this.misspelledWord_0, string_1);
			}
			else if (string_1 == this.resourceManager_0.GetString("MENU_SPELLDELETE"))
			{
				int start = this.misspelledWord_0.Start;
				int length = this.misspelledWord_0.Length;
				this.misspelledWordCollection_0.Remove(this.misspelledWord_0);
				this.textControl_0.Focus();
				IFormattedText formattedText = (IFormattedText)this.textControl_0.TextParts.GetItem();
				if (formattedText != null)
				{
					formattedText.Selection = new Selection(start - 2, length + 1);
					formattedText.Selection.Text = "";
				}
			}
			else if (string_1 == this.resourceManager_0.GetString("MENU_SPELLIGNORE"))
			{
				this.misspelledWord_0.IsIgnored = true;
			}
			else if (string_1 == this.resourceManager_0.GetString("MENU_SPELLIGNOREALL"))
			{
				string text = this.misspelledWord_0.Text;
				foreach (IFormattedText textPart in this.textControl_0.TextParts)
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
			else if (string_1 == this.resourceManager_0.GetString("MENU_SPELLADDTODICTIONARY"))
			{
				CollectionBase collectionBase_ = this.class415_0.CollectionBase_0;
				if (this.class415_0.method_38() >= 4)
				{
					List<object> list = this.class415_0.method_46(collectionBase_, this.misspelledWord_0.Culture);
					foreach (object item in list)
					{
						this.class415_0.method_16(item, this.misspelledWord_0.Text);
					}
				}
				else
				{
					foreach (object item2 in collectionBase_)
					{
						if (item2.GetType().Name == "UserDictionary" && this.class415_0.method_17(item2))
						{
							this.class415_0.method_16(item2, this.misspelledWord_0.Text);
						}
					}
				}
				foreach (IFormattedText textPart2 in this.textControl_0.TextParts)
				{
					MisspelledWordCollection.MisspelledWordEnumerator enumerator3 = textPart2.MisspelledWords.GetEnumerator();
					int count = textPart2.MisspelledWords.Count;
					enumerator3.MoveNext();
					string text2 = this.misspelledWord_0.Text;
					for (int i = 0; i < count; i++)
					{
						MisspelledWord misspelledWord2 = (MisspelledWord)enumerator3.Current;
						if (misspelledWord2.Text == text2)
						{
							this.misspelledWordCollection_0.Remove(misspelledWord2);
						}
						else
						{
							enumerator3.MoveNext();
						}
					}
				}
			}
			else if (string_1 == this.resourceManager_0.GetString("MENU_SPELLCHECKDIALOG"))
			{
				this.textControl_0.SpellCheckDialog();
			}
			else if (string_1 == this.resourceManager_0.GetString("MENU_SPELLCHECKOPTIONS"))
			{
				this.class415_0.method_32();
				this.textControl_0.IsSpellCheckingEnabled = !this.textControl_0.IsSpellCheckingEnabled;
				this.textControl_0.IsSpellCheckingEnabled = !this.textControl_0.IsSpellCheckingEnabled;
			}
		}

		private ContextMenuStrip method_4(Form form_0, string string_1)
		{
			FieldInfo field = form_0.GetType().GetField("components", BindingFlags.Instance | BindingFlags.NonPublic);
			if (field != null)
			{
				IContainer container = field.GetValue(form_0) as IContainer;
				if (container != null)
				{
					for (int i = 0; i < container.Components.Count; i++)
					{
						if (container.Components[i] is ContextMenuStrip && ((ContextMenuStrip)container.Components[i]).Name == string_1)
						{
							return (ContextMenuStrip)container.Components[i];
						}
					}
				}
			}
			return null;
		}

		private void contextMenuStrip_0_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			if (e.ClickedItem.Tag != null)
			{
				this.method_3(e.ClickedItem.Text, bool_0: true);
			}
			else
			{
				this.method_3(e.ClickedItem.Text, bool_0: false);
			}
		}
	}
}
