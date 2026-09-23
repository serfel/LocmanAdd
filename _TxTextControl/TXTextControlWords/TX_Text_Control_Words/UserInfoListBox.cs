using System;
using System.Drawing;
using System.Windows.Forms;

namespace TX_Text_Control_Words
{
	public class UserInfoListBox : ListBox
	{
		private UserInfo m_Author;

		public UserInfo Author
		{
			get
			{
				return this.m_Author;
			}
			set
			{
				this.m_Author = value;
				base.Invalidate();
			}
		}

		public UserInfoListBox()
		{
			this.DrawMode = DrawMode.OwnerDrawVariable;
			base.SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
		}

		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			this.ItemHeight = e.Font.Height;
			UserInfo userInfo = ((base.Items.Count > 0 && e.Index > -1) ? (base.Items[e.Index] as UserInfo) : null);
			if (userInfo != null)
			{
				e.DrawBackground();
				double num = (double)e.Graphics.DpiX / 96.0;
				Rectangle bounds = e.Bounds;
				bounds.Width -= (int)(num * 40.0);
				string text = (base.DesignMode ? base.Name : userInfo.Name);
				TextRenderer.DrawText(e.Graphics, text, e.Font, bounds, e.ForeColor, TextFormatFlags.VerticalCenter);
				Font font = new Font("Wingdings", e.Font.Size + 2f);
				bounds.X += bounds.Width;
				bounds.Width = (int)(num * 20.0);
				if (this.Author != null && this.Author == userInfo)
				{
					Color blue = Color.Blue;
					int value = 171;
					string text2 = Convert.ToChar(value).ToString();
					TextRenderer.DrawText(e.Graphics, text2, font, bounds, blue, TextFormatFlags.VerticalCenter);
				}
				bounds.X += bounds.Width;
				bounds.Width = (int)(num * 20.0);
				string text3 = (userInfo.AccessGranted ? "\uf0fc" : "\uf0fb");
				Color foreColor = (userInfo.AccessGranted ? Color.Lime : Color.Red);
				TextRenderer.DrawText(e.Graphics, text3, font, bounds, foreColor, TextFormatFlags.VerticalCenter);
				e.DrawFocusRectangle();
			}
			else if (base.DesignMode)
			{
				TextRenderer.DrawText(e.Graphics, base.Name, e.Font, e.Bounds, e.ForeColor, TextFormatFlags.Default);
			}
			else
			{
				base.OnDrawItem(e);
			}
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			base.Invalidate();
		}
	}
}
