using System;
using System.Drawing;
using System.Windows.Forms;
using TXTextControl;
using TXTextControl.Proofing;

namespace ns29
{
	internal class Class594
	{
		private int int_0;

		private int int_1;

		internal bool bool_0;

		private SpellCheckDialogForm spellCheckDialogForm_0;

		private int int_2;

		private RichTextBox richTextBox_0;

		private Class591 class591_0;

		internal Class594(RichTextBox richTextBox_1, Class591 class591_1, SpellCheckDialogForm spellCheckDialogForm_1)
		{
			this.richTextBox_0 = richTextBox_1;
			this.class591_0 = class591_1;
			this.spellCheckDialogForm_0 = spellCheckDialogForm_1;
			this.richTextBox_0.TextChanged += richTextBox_0_TextChanged;
			this.richTextBox_0.MouseUp += richTextBox_0_MouseUp;
			this.richTextBox_0.Enter += richTextBox_0_Enter;
			this.richTextBox_0.KeyDown += richTextBox_0_KeyDown;
			this.richTextBox_0.KeyUp += richTextBox_0_KeyUp;
			this.richTextBox_0.Leave += richTextBox_0_Leave;
		}

		internal void richTextBox_0_TextChanged(object sender, EventArgs e)
		{
			int num = this.richTextBox_0.Text.Length - this.int_2;
			this.int_2 = this.richTextBox_0.Text.Length;
			this.int_1 += num;
		}

		internal void richTextBox_0_MouseUp(object sender, MouseEventArgs e)
		{
			this.int_2 = this.richTextBox_0.Text.Length;
			if (this.richTextBox_0.SelectionStart > this.int_0 + this.int_1)
			{
				this.richTextBox_0.SelectionStart = this.int_0 + this.int_1;
			}
			if (this.richTextBox_0.SelectionStart < this.int_0)
			{
				this.richTextBox_0.SelectionStart = this.int_0;
			}
		}

		internal void richTextBox_0_Enter(object sender, EventArgs e)
		{
			this.richTextBox_0.SelectionStart = this.int_0;
		}

		internal void richTextBox_0_KeyDown(object sender, KeyEventArgs e)
		{
			if ((this.int_1 != 0 || e.KeyData != Keys.Back) && this.richTextBox_0.SelectionLength <= 0 && (this.richTextBox_0.SelectionStart != this.int_0 || e.KeyData != Keys.Back) && e.KeyData != Keys.Delete && e.KeyData != (Keys.V | Keys.Control) && e.KeyData != (Keys.Z | Keys.Control) && e.KeyData != (Keys.Z | Keys.Shift | Keys.Control) && e.KeyData != (Keys.X | Keys.Control))
			{
				if (this.richTextBox_0.SelectionColor != Color.Red)
				{
					this.richTextBox_0.SelectionFont = new Font(this.richTextBox_0.Font, FontStyle.Bold);
					this.richTextBox_0.SelectionColor = Color.Red;
				}
				if (!this.bool_0)
				{
					this.class591_0.method_31();
					this.bool_0 = true;
				}
				e.SuppressKeyPress = false;
			}
			else
			{
				e.SuppressKeyPress = true;
			}
			if (this.richTextBox_0.SelectionStart > this.int_0 + this.int_1)
			{
				this.richTextBox_0.SelectionStart = this.int_0 + this.int_1;
			}
			if (this.richTextBox_0.SelectionStart < this.int_0)
			{
				this.richTextBox_0.SelectionStart = this.int_0;
			}
		}

		internal void richTextBox_0_KeyUp(object sender, KeyEventArgs e)
		{
			if (this.richTextBox_0.SelectionStart > this.int_0 + this.int_1)
			{
				this.richTextBox_0.SelectionStart = this.int_0 + this.int_1;
			}
			else if (this.richTextBox_0.SelectionStart < this.int_0)
			{
				this.richTextBox_0.SelectionStart = this.int_0;
			}
			else
			{
				this.class591_0.string_2 = this.richTextBox_0.Text.Substring(this.int_0, this.int_1);
			}
		}

		internal void richTextBox_0_Leave(object sender, EventArgs e)
		{
			this.spellCheckDialogForm_0.m_lbxSuggestions.SelectionMode = SelectionMode.One;
		}

		internal void method_0(MisspelledWord misspelledWord_0, int int_3)
		{
			if (misspelledWord_0 != null)
			{
				this.richTextBox_0.Enabled = true;
				this.int_0 = misspelledWord_0.Start - int_3;
				this.int_1 = misspelledWord_0.Length;
				this.richTextBox_0.Select(this.int_0, this.int_1);
			}
			else
			{
				this.richTextBox_0.Enabled = false;
			}
			this.richTextBox_0.SelectionFont = new Font(this.richTextBox_0.Font, FontStyle.Bold);
			this.richTextBox_0.SelectionColor = Color.Red;
			this.richTextBox_0.SelectionLength = 0;
			this.richTextBox_0.SelectionStart = this.int_0;
			this.richTextBox_0.ScrollToCaret();
		}

		internal void method_1(object object_0, int int_3)
		{
			if (object_0 != null)
			{
				this.richTextBox_0.Enabled = true;
				this.int_0 = this.class591_0.class415_0.method_24(object_0) - int_3;
				this.int_1 = this.class591_0.class415_0.method_25(object_0);
				this.richTextBox_0.Select(this.int_0, this.int_1);
			}
			else
			{
				this.richTextBox_0.Enabled = false;
			}
			this.richTextBox_0.SelectionFont = new Font(this.richTextBox_0.Font, FontStyle.Bold);
			this.richTextBox_0.SelectionColor = Color.Red;
			this.richTextBox_0.SelectionLength = 0;
			this.richTextBox_0.SelectionStart = this.int_0;
			this.richTextBox_0.ScrollToCaret();
		}
	}
}
