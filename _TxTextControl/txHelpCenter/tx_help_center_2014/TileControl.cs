using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace tx_help_center_2014
{
	public class TileControl : UserControl
	{
		public enum TileSize
		{
			Small,
			Normal,
			Large
		}

		public class TileAction
		{
			public enum ActionValue
			{
				WebLink,
				Documentation,
				Application,
				Path
			}

			private ActionValue aAction;

			private string sActionString;

			public ActionValue Action
			{
				get
				{
					return this.aAction;
				}
				set
				{
					this.aAction = value;
				}
			}

			public string ActionString
			{
				get
				{
					return this.sActionString;
				}
				set
				{
					this.sActionString = value;
				}
			}

			public TileAction(ActionValue Action, string ActionString)
			{
				this.Action = Action;
				this.ActionString = ActionString;
			}
		}

		private string sTitle;

		private string sSubTitle;

		private string sImageName;

		private string sScreenshotName;

		public TileController TileController;

		public int NextIndex;

		private Color cTileBackground;

		private TileSize tsTileControlSize;

		private TileAction taTileAction;

		private bool bActive;

		private bool bMouseOver;

		private IContainer components;

		public TileAction Action
		{
			get
			{
				return this.taTileAction;
			}
			set
			{
				this.taTileAction = value;
			}
		}

		public bool Active
		{
			get
			{
				return this.bActive;
			}
			set
			{
				this.bActive = value;
			}
		}

		public string Title
		{
			get
			{
				return this.sTitle;
			}
			set
			{
				this.sTitle = value;
			}
		}

		public TileSize TileControlSize
		{
			get
			{
				return this.tsTileControlSize;
			}
			set
			{
				this.tsTileControlSize = value;
				if (this.TileControlSize == TileSize.Small)
				{
					base.Size = new Size(base.Width / 2 - 4, base.Height);
				}
				if (this.TileControlSize == TileSize.Normal)
				{
					base.Size = new Size(280, 109);
				}
				else if (this.TileControlSize == TileSize.Large)
				{
					base.Size = new Size(base.Width + (base.Width / 2 - base.Margin.Right) + base.Margin.Right * 2, base.Height);
				}
			}
		}

		public Color TileBackground
		{
			get
			{
				return this.cTileBackground;
			}
			set
			{
				this.cTileBackground = value;
				this.BackColor = this.cTileBackground;
			}
		}

		public string ImageName
		{
			get
			{
				return this.sImageName;
			}
			set
			{
				this.sImageName = value;
			}
		}

		public string ScreenshotName
		{
			get
			{
				return this.sScreenshotName;
			}
			set
			{
				this.sScreenshotName = value;
			}
		}

		public string SubTitle
		{
			get
			{
				return this.sSubTitle;
			}
			set
			{
				this.sSubTitle = value;
			}
		}

		public TileControl(string Title, string SubTitle, string ImageName, TileController TileController, int NextIndex, string ScreenshotName, TileSize TileSize, TileAction TileAction, bool Active)
		{
			this.InitializeComponent();
			this.Action = TileAction;
			this.Active = Active;
			base.Margin = new Padding(4, 4, 4, 4);
			base.Size = new Size(280, 109);
			this.TileControlSize = TileSize;
			this.Title = Title;
			this.SubTitle = SubTitle;
			this.ImageName = ImageName;
			this.AutoSize = false;
			switch (Title)
			{
			case "Up":
				this.TileBackground = Color.FromArgb(189, 189, 189);
				break;
			case "Getting Started":
			case "Getting Started Tutorials":
				this.TileBackground = Color.FromArgb(0, 128, 0);
				break;
			default:
				this.TileBackground = Color.FromArgb(105, 132, 158);
				break;
			}
			this.NextIndex = NextIndex;
			this.ScreenshotName = ScreenshotName;
			this.TileController = TileController;
		}

		public TileControl()
		{
			this.InitializeComponent();
		}

		private void TileControl_MouseEnter(object sender, EventArgs e)
		{
			if (this.Active)
			{
				this.bMouseOver = true;
				this.BackColor = Color.FromArgb(13, 57, 100);
				if (this.ScreenshotName != "")
				{
					Bitmap image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(this.ScreenshotName));
					this.TileController.ScreenshotBox.Image = image;
					Effects.Animate(this.TileController.ScreenshotBox, Effects.Effect.Slide, 120, 0);
				}
			}
		}

		private void TileControl_MouseLeave(object sender, EventArgs e)
		{
			if (!this.Active)
			{
				return;
			}
			this.bMouseOver = false;
			this.BackColor = this.TileBackground;
			if (this.TileController.ScreenshotBox.Visible)
			{
				Effects.Animate(this.TileController.ScreenshotBox, Effects.Effect.Slide, 120, 0);
				try
				{
					Form.ActiveForm.Invalidate(invalidateChildren: true);
				}
				catch
				{
				}
			}
		}

		private void TileControl_Click(object sender, EventArgs e)
		{
			try
			{
				if (!this.Active)
				{
					return;
				}
				if (this.Action == null)
				{
					this.TileController.SwitchTileGroup(this.NextIndex);
					return;
				}
				switch (this.Action.Action)
				{
				case TileAction.ActionValue.WebLink:
					Process.Start(this.Action.ActionString);
					break;
				case TileAction.ActionValue.Documentation:
					Process.Start(new ProcessStartInfo(this.Action.ActionString)
					{
						WindowStyle = ProcessWindowStyle.Normal
					});
					break;
				case TileAction.ActionValue.Path:
					Process.Start(new ProcessStartInfo(this.Action.ActionString)
					{
						WindowStyle = ProcessWindowStyle.Normal
					});
					break;
				case TileAction.ActionValue.Application:
					break;
				}
			}
			catch
			{
			}
		}

		private void TileControl_Paint(object sender, PaintEventArgs e)
		{
			try
			{
				float num = 0f;
				if (!this.Active)
				{
					this.BackColor = Color.FromArgb(173, 186, 198);
				}
				num = ((!(this.ImageName == "")) ? ((float)(base.Size.Width - 80)) : ((float)(base.Size.Width - 20)));
				if (this.bMouseOver)
				{
					Rectangle rect = new Rectangle(0, 0, base.ClientSize.Width, base.ClientSize.Height);
					using LinearGradientBrush brush = new LinearGradientBrush(rect, Color.FromArgb(255, 40, 46), Color.FromArgb(136, 33, 94), 45f);
					e.Graphics.FillRectangle(brush, rect);
				}
				e.Graphics.DrawString(this.Title, new Font("Segoe UI Light", 16f), Brushes.White, new RectangleF(new PointF(12f, 10f), new SizeF(num, 30f)));
				e.Graphics.DrawString(this.SubTitle, new Font("Segoe UI Light", 12f), Brushes.White, new RectangleF(new PointF(13f, 40f), new SizeF(num, 45f)));
				if (this.ImageName != "")
				{
					Bitmap bitmap = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(this.ImageName));
					if (bitmap != null)
					{
						e.Graphics.DrawImage(bitmap, new Point(base.Width - bitmap.Width - 10, 10));
					}
				}
			}
			catch
			{
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			base.SuspendLayout();
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Cursor = System.Windows.Forms.Cursors.Hand;
			base.Name = "TileControl";
			base.Padding = new System.Windows.Forms.Padding(10);
			base.Size = new System.Drawing.Size(274, 153);
			base.Click += new System.EventHandler(TileControl_Click);
			base.Paint += new System.Windows.Forms.PaintEventHandler(TileControl_Paint);
			base.MouseEnter += new System.EventHandler(TileControl_MouseEnter);
			base.MouseLeave += new System.EventHandler(TileControl_MouseLeave);
			base.ResumeLayout(false);
		}
	}
}
