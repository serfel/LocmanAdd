using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ns21;
using ns26;
using ns27;
using TXTextControl.Windows.Forms;

namespace TXTextControl
{
	/// <summary>The GotoDialog class implements a Windows Forms dialog box which can be used to move the current input position to a certain page, section, line, table or bookmark.</summary>
	public class GotoDialog : Form
	{
		/// <summary>Each DialogItem represents an item in a GotoDialog dialog box.</summary>
		public enum DialogItem
		{
			/// <summary>Identifies the label of the Go to listbox.</summary>
			TXITEM_GotoLabel,
			/// <summary>Identifies the Go to listbox.</summary>
			TXITEM_GotoList,
			/// <summary>Identifies the label of the Number textbox.</summary>
			TXITEM_NumberLabel,
			/// <summary>Identifies the Number respectively Bookmark combobox.</summary>
			TXITEM_Number,
			/// <summary>Identifies the Previous button.</summary>
			TXITEM_GotoPrevious,
			/// <summary>Identifies the Next button.</summary>
			TXITEM_GotoNext,
			/// <summary>Identifies the Close button.</summary>
			TXITEM_Close
		}

		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private Class571 class571_0;

		private TextControl textControl_0;

		private uint uint_0;

		private PointF pointF_0 = PointF.Empty;

		private IContainer icontainer_0;

		protected override bool ScaleChildren => false;

		/// <summary>Creates a GotoDialog object for the specified Windows Forms TextControl.</summary>
		/// <param name="textControl">Specifies the TextControl for which the dialog box is opened.</param>
		public GotoDialog(TextControl textControl)
		{
			this.class571_0 = new Class571(ContentPanel.Enum140.const_0, textControl, base.DesignMode, Sidebar.SidebarContentLayout.Goto, PointF.Empty);
			this.class571_0.Margin = new Padding(0);
			this.textControl_0 = textControl;
			base.Controls.Add(this.class571_0);
			base.AcceptButton = this.class571_0.button_1;
			base.CancelButton = this.class571_0.button_2;
			this.InitializeComponent();
			this.class571_0.TextControl = textControl;
			this.class571_0.button_2.Click += method_0;
			this.Text = this.resourceManager_0.GetString("ID_GOTO_CAPTION");
			this.method_2(textControl);
		}

		private void GotoDialog_Activated(object sender, EventArgs e)
		{
			if (this.textControl_0 != null)
			{
				this.textControl_0.InputPosition.InactiveMarker = true;
			}
		}

		private void GotoDialog_Deactivate(object sender, EventArgs e)
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

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			Graphics graphics = base.CreateGraphics();
			this.uint_0 = Class468.smethod_0(graphics, this);
			this.pointF_0 = ((this.uint_0 != 0) ? new PointF(this.uint_0, this.uint_0) : new PointF(graphics.DpiX, graphics.DpiY));
			graphics.Dispose();
			this.class571_0.AwareOfDPI(this.pointF_0);
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
					this.pointF_0 = new PointF(num, num);
					float num2 = (float)num / (float)this.uint_0;
					this.Font = new Font(this.Font.FontFamily, this.Font.Size * num2, this.Font.Style, this.Font.Unit);
					this.uint_0 = num;
					this.class571_0.AwareOfDPI(this.pointF_0);
					this.class571_0.HandleFontUpdated();
					Class429.Struct83 struct83_ = (Class429.Struct83)Marshal.PtrToStructure(message.LParam, typeof(Class429.Struct83));
					Class468.smethod_1(this.uint_0, struct83_, this);
				}
			}
			else
			{
				base.WndProc(ref message);
			}
		}

		public Control FindItem(DialogItem dialogItem)
		{
			return this.class571_0.FindItem(dialogItem.ToString());
		}

		private Control method_1(DialogItem dialogItem_0, Control control_0)
		{
			if (control_0.Name == dialogItem_0.ToString())
			{
				return control_0;
			}
			foreach (Control control2 in control_0.Controls)
			{
				Control control = this.method_1(dialogItem_0, control2);
				if (control != null)
				{
					return control;
				}
			}
			return null;
		}

		private void method_2(TextControl textControl_1)
		{
			int num = textControl_1.Width - base.Width;
			base.Location = textControl_1.PointToScreen(new Point(num, 0));
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.icontainer_0 != null)
			{
				this.icontainer_0.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			base.SuspendLayout();
			this.AutoSize = false;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "GotoDialog";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			base.Activated += new System.EventHandler(GotoDialog_Activated);
			base.Deactivate += new System.EventHandler(GotoDialog_Deactivate);
			base.ResumeLayout(false);
		}
	}
}
