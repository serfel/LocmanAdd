using System;
using System.Drawing;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ns21;
using ns26;
using ns27;
using TXTextControl;
using TXTextControl.Windows.Forms;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal class TrackedChangesDialog : Form
	{
		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private Class573 class573_0;

		private TextControl textControl_0;

		private uint uint_0;

		internal TrackedChangesDialog(TextControl textControl_1)
		{
			this.class573_0 = new Class573(ContentPanel.Enum140.const_0, textControl_1, base.DesignMode, Sidebar.SidebarContentLayout.TrackedChanges, PointF.Empty);
			this.textControl_0 = textControl_1;
			base.Controls.Add(this.class573_0);
			this.InitializeComponent();
			this.class573_0.Dock = DockStyle.Fill;
			this.class573_0.TextControl = textControl_1;
			this.Text = this.resourceManager_0.GetString("ID_TRACKEDCHANGES_CAPTION");
			this.method_1(textControl_1);
		}

		private void InitializeComponent()
		{
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(300, 450);
			base.Name = "TrackedChangesDialog";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.Activated += new System.EventHandler(TrackedChangesDialog_Activated);
			base.Deactivate += new System.EventHandler(TrackedChangesDialog_Deactivate);
		}

		private void TrackedChangesDialog_Activated(object sender, EventArgs e)
		{
			if (this.textControl_0 != null)
			{
				this.textControl_0.InputPosition.InactiveMarker = true;
			}
		}

		private void TrackedChangesDialog_Deactivate(object sender, EventArgs e)
		{
			if (this.textControl_0 != null)
			{
				this.textControl_0.InputPosition.InactiveMarker = false;
			}
		}

		private void method_0(object sender, EventArgs e)
		{
			base.Close();
		}

		private void method_1(TextControl textControl_1)
		{
			int num = textControl_1.Width - base.Width;
			base.Location = textControl_1.PointToScreen(new Point(num, 0));
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			Graphics graphics = base.CreateGraphics();
			this.uint_0 = Class468.smethod_0(graphics, this);
			PointF dpi = ((this.uint_0 != 0) ? new PointF(this.uint_0, this.uint_0) : new PointF(graphics.DpiX, graphics.DpiY));
			this.class573_0.AwareOfDPI(dpi);
			Class429.Struct83 struct83_ = default(Class429.Struct83);
			Class429.GetWindowRect(base.Handle, ref struct83_);
			Class468.smethod_1(this.uint_0, struct83_, this);
			base.OnHandleCreated(eventArgs_0);
		}

		protected override void WndProc(ref Message message)
		{
			int msg = message.Msg;
			if (msg == 736)
			{
				uint num = Class429.smethod_5(message.WParam.ToInt32());
				if (num != this.uint_0)
				{
					Class429.Struct83 struct83_ = (Class429.Struct83)Marshal.PtrToStructure(message.LParam, typeof(Class429.Struct83));
					this.Font = new Font(this.Font.Name, this.Font.Size * (float)num / (float)this.uint_0, this.Font.Style, this.Font.Unit);
					this.uint_0 = num;
					this.class573_0.AwareOfDPI(new PointF(this.uint_0, this.uint_0));
					Class468.smethod_1(this.uint_0, struct83_, this);
				}
			}
			else
			{
				base.WndProc(ref message);
			}
		}
	}
}
