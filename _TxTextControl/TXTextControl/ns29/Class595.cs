using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using TXTextControl;
using TXTextControl.Proofing;

namespace ns29
{
	internal sealed class Class595
	{
		internal Enum143 enum143_0;

		private bool bool_0;

		private bool bool_1;

		internal Class591 class591_0;

		internal string string_0 = "Button";

		internal bool bool_2;

		internal Enum143 enum143_1;

		internal bool bool_3;

		internal System.Windows.Forms.Button button_0;

		internal SpellCheckDialogForm spellCheckDialogForm_0;

		private ResourceManager resourceManager_0;

		internal bool Boolean_0
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				if (this.class591_0 != null)
				{
					bool flag = this.class591_0.list_0.Contains(this);
					if (value)
					{
						if (!flag)
						{
							this.class591_0.list_0.Add(this);
						}
					}
					else if (flag)
					{
						this.class591_0.list_0.Remove(this);
						this.button_0.Text = this.string_0;
						this.button_0.Enabled = true;
						this.enum143_0 = this.enum143_1;
						this.button_0.Refresh();
					}
				}
				this.bool_1 = value;
			}
		}

		internal bool Boolean_1
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				if (this.class591_0 != null)
				{
					bool flag = this.class591_0.list_1.Contains(this);
					if (value)
					{
						if (!flag)
						{
							this.class591_0.list_1.Add(this);
						}
					}
					else if (flag)
					{
						this.class591_0.list_1.Remove(this);
					}
				}
				this.bool_0 = value;
			}
		}

		internal Class595(Enum143 enum143_2)
		{
			this.enum143_0 = enum143_2;
			this.enum143_1 = enum143_2;
			this.button_0 = new System.Windows.Forms.Button();
			this.button_0.Text = this.string_0;
			this.button_0.MinimumSize = new Size(75, 23);
			this.button_0.AutoSize = true;
			this.button_0.AutoSizeMode = AutoSizeMode.GrowAndShrink;
			this.resourceManager_0 = new ResourceManager(typeof(TextControlCore));
		}

		internal void method_0(object sender, EventArgs e)
		{
			this.method_7();
		}

		internal void method_1(object sender, EventArgs e)
		{
			this.method_8();
		}

		internal void method_2(object sender, EventArgs e)
		{
			this.method_9();
		}

		internal void method_3(object sender, EventArgs e)
		{
			this.method_10();
		}

		internal void method_4(object sender, EventArgs e)
		{
			this.method_11();
		}

		internal void method_5(object sender, EventArgs e)
		{
			this.method_12();
		}

		internal void method_6(object sender, EventArgs e)
		{
			this.class591_0.method_37();
			if (!this.spellCheckDialogForm_0.bool_0 && this.class591_0.misspelledWord_0 == null)
			{
				this.spellCheckDialogForm_0.Close();
			}
			this.spellCheckDialogForm_0.bool_0 = false;
		}

		private void method_7()
		{
			if (this.enum143_0 == Enum143.const_3)
			{
				this.class591_0.method_47();
				return;
			}
			if (this.enum143_0 != Enum143.const_7)
			{
				this.class591_0.method_48();
				return;
			}
			this.spellCheckDialogForm_0.method_5();
			this.class591_0.class594_0.bool_0 = false;
		}

		private void method_8()
		{
			if (this.enum143_0 == Enum143.const_3)
			{
				this.class591_0.method_47();
				return;
			}
			if (this.enum143_0 != Enum143.const_7)
			{
				this.class591_0.method_49();
				return;
			}
			this.spellCheckDialogForm_0.method_5();
			this.class591_0.class594_0.bool_0 = false;
		}

		private void method_9()
		{
			if (this.enum143_0 == Enum143.const_3)
			{
				this.class591_0.method_47();
			}
			else if (this.enum143_0 != Enum143.const_7)
			{
				this.class591_0.method_44();
				this.spellCheckDialogForm_0.method_5();
				this.class591_0.class594_0.bool_0 = false;
			}
			else
			{
				this.spellCheckDialogForm_0.method_5();
				this.class591_0.class594_0.bool_0 = false;
			}
		}

		private void method_10()
		{
			if (this.enum143_0 == Enum143.const_3)
			{
				this.class591_0.method_47();
			}
			else if (this.enum143_0 != Enum143.const_7)
			{
				if (this.class591_0.class594_0.bool_0)
				{
					this.class591_0.method_45(this.class591_0.string_2);
					this.spellCheckDialogForm_0.method_5();
					this.class591_0.class594_0.bool_0 = false;
					return;
				}
				if (this.spellCheckDialogForm_0.m_lbxSuggestions.SelectedItem == null)
				{
					throw new ArgumentException(this.resourceManager_0.GetString("ERR_NO_SUGGESTION"));
				}
				this.class591_0.method_45(this.spellCheckDialogForm_0.m_lbxSuggestions.SelectedItem.ToString());
			}
			else
			{
				this.spellCheckDialogForm_0.method_5();
				this.class591_0.class594_0.bool_0 = false;
			}
		}

		private void method_11()
		{
			if (this.enum143_0 == Enum143.const_3)
			{
				this.class591_0.method_47();
			}
			else if (this.enum143_0 != Enum143.const_7)
			{
				if (this.class591_0.class594_0.bool_0)
				{
					this.class591_0.method_46(this.class591_0.string_2);
					this.class591_0.method_33();
					this.class591_0.method_39();
					this.class591_0.class594_0.bool_0 = false;
				}
				else
				{
					if (this.spellCheckDialogForm_0.m_lbxSuggestions.SelectedItem == null)
					{
						throw new ArgumentException(this.resourceManager_0.GetString("ERR_NO_SUGGESTION"));
					}
					this.class591_0.method_46(this.spellCheckDialogForm_0.m_lbxSuggestions.SelectedItem.ToString());
				}
			}
			else
			{
				this.spellCheckDialogForm_0.method_5();
				this.class591_0.class594_0.bool_0 = false;
			}
		}

		private void method_12()
		{
			if (this.enum143_0 == Enum143.const_3)
			{
				this.class591_0.method_47();
			}
			else if (this.enum143_0 != Enum143.const_7)
			{
				this.class591_0.method_50();
				this.class591_0.class594_0.bool_0 = false;
			}
		}
	}
}
