/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TX_Text_Control_Words {

	/*-------------------------------------------------------------------------------------------------------------
	** Class UserInfoListBox
	** ListBox for displaying UserInfos. 
	** The ListBox displays the user's name and image for the access granted state and whether the user is the
	** current author.
	**-----------------------------------------------------------------------------------------------------------*/
	public partial class UserInfoListBox : ListBox {

		/*-------------------------------------------------------------------------------------------------------------
		** M E M B E R S
		**-----------------------------------------------------------------------------------------------------------*/

		UserInfo m_Author;

		/*-------------------------------------------------------------------------------------------------------------
		** C O N S T R U C T O R
		**-----------------------------------------------------------------------------------------------------------*/

		public UserInfoListBox() {

			DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
		}


		/*-------------------------------------------------------------------------------------------------------------
		** P R O P E R T I E S
		**-----------------------------------------------------------------------------------------------------------*/

		public UserInfo Author {
			get { return m_Author; }
			set {
				m_Author = value;
				Invalidate();
			}
		}

		/*-------------------------------------------------------------------------------------------------------------
		** O V E R R I D E
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** OnDrawItem method
		** Adjust the look of the items. Adds images aligned on the right side. 
		** 1. If user is author display a blue PentaStar
		** 2. If user has not granted access display a red cross
		**		Else display a green check mark.
		**-----------------------------------------------------------------------------------------------------------*/
		protected override void OnDrawItem(DrawItemEventArgs e) {
			this.ItemHeight = e.Font.Height;

			UserInfo userInfo = ((Items.Count > 0) && (e.Index > -1)) ? Items[e.Index] as UserInfo : null;
			if (userInfo != null) {
				e.DrawBackground();

				// DPI scaling factor for drawing the items dependly on the dpi.
				var dpiScalingFactor = e.Graphics.DpiX / 96.0;

				// Text
				Rectangle textRect = e.Bounds;
				textRect.Width -= (int)(dpiScalingFactor * 40);
				string itemText = DesignMode ? Name : userInfo.Name;
				TextRenderer.DrawText(e.Graphics, itemText, e.Font, textRect, e.ForeColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

				Font symbolFont = new System.Drawing.Font("Wingdings", e.Font.Size + 2);
				textRect.X += textRect.Width;
				textRect.Width = (int)(dpiScalingFactor * 20);
				// PentaStar mark for main user
				if (Author != null && Author == userInfo) {
					Color symbolPentaStarColor = Color.Blue;
					int iWindDingsPentaStar = 171;
					string strWindDingsPentaStar = Convert.ToChar(iWindDingsPentaStar).ToString();
					TextRenderer.DrawText(e.Graphics,
												strWindDingsPentaStar,
												symbolFont,
												textRect,
												symbolPentaStarColor,
												TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
				}

				// Red cross / green check mark
				textRect.X += textRect.Width;
				textRect.Width = (int)(dpiScalingFactor * 20);
				string symbol = userInfo.AccessGranted ? "" : "";
				Color symbolColor = userInfo.AccessGranted ? Color.Lime : Color.Red;
				TextRenderer.DrawText(e.Graphics, symbol, symbolFont, textRect, symbolColor, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

				e.DrawFocusRectangle();
			}
			else if (DesignMode) TextRenderer.DrawText(e.Graphics, Name, e.Font, e.Bounds, e.ForeColor, TextFormatFlags.Left);
			else base.OnDrawItem(e);
		}

		protected override void OnResize(EventArgs e) {
			base.OnResize(e);
			Invalidate();	// Fixes refresh problem
		}
	}
}
