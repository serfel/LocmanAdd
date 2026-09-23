using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Web.UI;
using System.Web.UI.WebControls;
using TXTextControl.DocumentServer;
using DocumentServer.Properties;
using DocumentServer.Web;

namespace ns2
{
	internal class Control0 : CompositeControl
	{
		protected enum Enum9
		{
			const_0,
			const_1,
			DataRowMergedEventArgs,
			BlockMergingEventArgs,
			FieldMergedEventArgs,
			const_5,
			const_6,
			const_7,
			const_8,
			ImageFieldMergedEventArgs,
			IncludeTextMergingEventArgs
		}

		private bool bool_0;

		private TextBox textBox_0;

		private List<Class93> list_0;

		private static readonly object object_0 = new object();

		private static readonly object object_1 = new object();

		private static readonly object object_2 = new object();

		private static readonly object object_3 = new object();

		private static readonly object object_4 = new object();

		private static readonly object object_5 = new object();

		private static readonly object object_6 = new object();

		private static readonly object object_7 = new object();

		private static readonly object object_8 = new object();

		public List<Class93> List_0 => this.list_0;

		public int Int32_0 { get; set; }

		public int TotalPages => (this.Parent as DocumentViewer)?.TotalPages ?? 0;

		protected override HtmlTextWriterTag TagKey => HtmlTextWriterTag.Div;

		public event EventHandler EditMode
		{
			add
			{
				base.Events.AddHandler(Control0.object_0, value);
			}
			remove
			{
				base.Events.RemoveHandler(Control0.object_0, value);
			}
		}

		public event EventHandler FirstPage
		{
			add
			{
				base.Events.AddHandler(Control0.object_1, value);
			}
			remove
			{
				base.Events.RemoveHandler(Control0.object_1, value);
			}
		}

		public event EventHandler HalfSize
		{
			add
			{
				base.Events.AddHandler(Control0.object_2, value);
			}
			remove
			{
				base.Events.RemoveHandler(Control0.object_2, value);
			}
		}

		public event EventHandler FullSize
		{
			add
			{
				base.Events.AddHandler(Control0.object_3, value);
			}
			remove
			{
				base.Events.RemoveHandler(Control0.object_3, value);
			}
		}

		public event EventHandler PreviousPage
		{
			add
			{
				base.Events.AddHandler(Control0.object_4, value);
			}
			remove
			{
				base.Events.RemoveHandler(Control0.object_4, value);
			}
		}

		public event EventHandler NextPage
		{
			add
			{
				base.Events.AddHandler(Control0.object_5, value);
			}
			remove
			{
				base.Events.RemoveHandler(Control0.object_5, value);
			}
		}

		public event EventHandler LastPage
		{
			add
			{
				base.Events.AddHandler(Control0.object_6, value);
			}
			remove
			{
				base.Events.RemoveHandler(Control0.object_6, value);
			}
		}

		public event EventHandler FillWidth
		{
			add
			{
				base.Events.AddHandler(Control0.object_7, value);
			}
			remove
			{
				base.Events.RemoveHandler(Control0.object_7, value);
			}
		}

		public event EventHandler WholePage
		{
			add
			{
				base.Events.AddHandler(Control0.object_8, value);
			}
			remove
			{
				base.Events.RemoveHandler(Control0.object_8, value);
			}
		}

		protected override void CreateChildControls()
		{
			this.Controls.Clear();
			this.list_0 = new List<Class93>();
			Button button = new Button();
			button.ID = "StandardSubmit";
			button.Width = Unit.Pixel(1);
			button.Height = Unit.Pixel(1);
			button.Style.Add("border", "0");
			button.Style.Add("background", "transparent");
			if (this.Parent != null)
			{
				button.Attributes.Add("name", this.Parent.UniqueID);
			}
			this.Controls.Add(button);
			foreach (Enum9 value in Enum.GetValues(typeof(Enum9)))
			{
				this.method_0(value);
			}
			base.ChildControlsCreated = true;
		}

		private void method_0(Enum9 enum9_0)
		{
			string[] array = enum9_0.ToString().Split(new string[1] { "_" }, StringSplitOptions.None);
			string text = array[0];
			string commandName = array[1];
			string text2 = "";
			switch (text)
			{
			case "pnl":
			{
				Panel panel = new Panel();
				panel.ID = enum9_0.ToString();
				panel.Controls.Add(new LiteralControl("&nbsp;"));
				this.Controls.Add(panel);
				break;
			}
			case "tbx":
				this.textBox_0 = new TextBox();
				this.textBox_0.ReadOnly = true;
				this.textBox_0.ID = enum9_0.ToString();
				text2 = Resources.ResourceManager.GetString("DOCVIEW_" + enum9_0.ToString().ToUpper());
				if (!string.IsNullOrEmpty(text2))
				{
					this.textBox_0.ToolTip = text2;
				}
				if (this.Parent != null)
				{
					this.textBox_0.Attributes.Add("name", this.Parent.UniqueID);
				}
				this.Controls.Add(this.textBox_0);
				break;
			case "btn":
			{
				Button button = new Button();
				button.ID = enum9_0.ToString();
				button.CommandName = commandName;
				button.CssClass = "button";
				text2 = Resources.ResourceManager.GetString("DOCVIEW_" + enum9_0.ToString().ToUpper());
				if (!string.IsNullOrEmpty(text2))
				{
					button.ToolTip = text2;
				}
				if (this.Parent != null)
				{
					button.Attributes.Add("name", this.Parent.UniqueID);
				}
				this.Controls.Add(button);
				Class93 item = new Class93(button);
				this.list_0.Add(item);
				break;
			}
			}
		}

		~Control0()
		{
			this.vmethod_0(bool_1: false);
		}

		public override void Dispose()
		{
			this.vmethod_0(bool_1: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void vmethod_0(bool bool_1)
		{
			if (this.bool_0)
			{
				return;
			}
			if (bool_1 && this.Controls != null)
			{
				foreach (Control control in this.Controls)
				{
					control.Dispose();
				}
			}
			base.Dispose();
			this.bool_0 = true;
		}

		protected override void OnPreRender(EventArgs eventArgs_0)
		{
			base.OnPreRender(eventArgs_0);
		}

		protected override void RenderContents(HtmlTextWriter output)
		{
			this.vmethod_1(output);
			base.RenderContents(output);
		}

		protected virtual void vmethod_1(HtmlTextWriter htmlTextWriter_0)
		{
			DocumentViewer documentViewer = this.Parent as DocumentViewer;
			string text = "#" + this.ClientID;
			htmlTextWriter_0.WriteLine("&nbsp;<style type=\"text/css\">");
			htmlTextWriter_0.WriteLine(text + " div { margin: 0; padding: 0; border: 0; }");
			htmlTextWriter_0.WriteLine(text + " { position: relative; font-size: 1px; height: 38px; text-align: center; z-index: 100; background: none; background-color: white; border: 1px solid #c2c2c2; -webkit-touch-callout: none; -webkit-user-select: none;  -khtml-user-select: none;  -moz-user-select: none;  -ms-user-select: none;  user-select: none; width: auto !important; background: none; }");
			htmlTextWriter_0.WriteLine(text + " input.button { margin: 0; margin-top: 4px; margin-right: 2px; margin-left: 5px; background-color: transparent; border: 1px solid #c2c2c2; border-radius: 2px; cursor: pointer; background-repeat: no-repeat; background-position: center; width: 30px !important; height: 30px !important; }");
			htmlTextWriter_0.WriteLine(text + " input.button:hover { background-color: #d5e1f2 !important; border: 1px solid #c2c2c2 !important; }");
			htmlTextWriter_0.WriteLine("@keyframes stretch {0% {transform: scale(.9);  opacity: 0;}100% { transform: scale(1.0);  opacity: 1;}}");
			htmlTextWriter_0.WriteLine(text + "_btn_edit { position: absolute; top: 0px; left: 0px; background: url(" + DocumentViewer.smethod_0(this.Page, "btn_edit") + "); }");
			if (!documentViewer.ShowEditButton)
			{
				htmlTextWriter_0.WriteLine(text + "_btn_edit { display: none; }");
			}
			if (documentViewer.EditMode != TXTextControl.DocumentServer.EditMode.ReadOnly)
			{
				htmlTextWriter_0.WriteLine(text + "_btn_edit { background-color: #c2c2c2 !important; }");
			}
			htmlTextWriter_0.WriteLine(text + "_btn_first { background: url(" + DocumentViewer.smethod_0(this.Page, "btn_first") + "); }");
			htmlTextWriter_0.WriteLine(text + "_btn_prev { background: url(" + DocumentViewer.smethod_0(this.Page, "btn_prev") + "); }");
			htmlTextWriter_0.WriteLine(text + "_btn_next { background: url(" + DocumentViewer.smethod_0(this.Page, "btn_next") + "); }");
			htmlTextWriter_0.WriteLine(text + "_btn_last { background: url(" + DocumentViewer.smethod_0(this.Page, "btn_last") + "); }");
			if (this.Int32_0 > 1)
			{
				if (this.Int32_0 == this.TotalPages)
				{
					htmlTextWriter_0.WriteLine(text + "_btn_next { opacity: 0.4 !important; background-color: transparent !important; }");
					htmlTextWriter_0.WriteLine(text + "_btn_last { opacity: 0.4 !important; background-color: transparent !important; }");
				}
			}
			else
			{
				foreach (Control control7 in this.Controls)
				{
					Button button = control7 as Button;
					if (button != null && (control7.ID.EndsWith("btn_first") || control7.ID.EndsWith("btn_prev")))
					{
						button.Enabled = false;
					}
				}
			}
			if (this.Int32_0 < this.TotalPages)
			{
				if (this.Int32_0 == 1)
				{
					htmlTextWriter_0.WriteLine(text + "_btn_prev { opacity: 0.4 !important; background-color: transparent !important; }");
					htmlTextWriter_0.WriteLine(text + "_btn_first { opacity: 0.4 !important; background-color: transparent !important; }");
				}
			}
			else
			{
				foreach (Control control8 in this.Controls)
				{
					Button button2 = control8 as Button;
					if (button2 != null && (control8.ID.EndsWith("btn_next") || control8.ID.EndsWith("btn_last")))
					{
						button2.Enabled = false;
					}
				}
			}
			this.textBox_0.Text = this.Int32_0 + " / " + this.TotalPages;
			htmlTextWriter_0.WriteLine(text + "_tbx_page { border: 0; width: 107px; height: 30px; color: #000; margin-top: 3px; font: 18px Lucida,Helvetica,Arial,sans-serif; text-align: center; -webkit-touch-callout: none; -webkit-user-select: none;  -khtml-user-select: none;  -moz-user-select: none;  -ms-user-select: none;  user-select: none; vertical-align: top; background: none; }");
			htmlTextWriter_0.WriteLine(text + "_btn_half { position: absolute; top: 0px; right: 105px; background: url(" + DocumentViewer.smethod_0(this.Page, "btn_half") + "); }");
			if (documentViewer.ZoomTo == DocumentViewer.ZoomLevel.HalfSize || this.TotalPages <= 0)
			{
				foreach (Control control9 in this.Controls)
				{
					Button button3 = control9 as Button;
					if (button3 != null && control9.ID.EndsWith("btn_half"))
					{
						button3.Enabled = false;
						htmlTextWriter_0.WriteLine(text + "_btn_half { opacity: 0.4 !important; background-color: transparent !important; }");
						break;
					}
				}
			}
			htmlTextWriter_0.WriteLine(text + "_btn_full { position: absolute; top: 0px; right: 71px; background: url(" + DocumentViewer.smethod_0(this.Page, "btn_full") + "); }");
			if (documentViewer.ZoomTo == DocumentViewer.ZoomLevel.FullSize || this.TotalPages <= 0)
			{
				foreach (Control control10 in this.Controls)
				{
					Button button4 = control10 as Button;
					if (button4 != null && control10.ID.EndsWith("btn_full"))
					{
						button4.Enabled = false;
						htmlTextWriter_0.WriteLine(text + "_btn_full { opacity: 0.4 !important; background-color: transparent !important; }");
						break;
					}
				}
			}
			htmlTextWriter_0.WriteLine(text + "_btn_width { position: absolute; top: 0px; right: 37px; background: url(" + DocumentViewer.smethod_0(this.Page, "btn_width") + "); }");
			if (documentViewer.ZoomTo == DocumentViewer.ZoomLevel.ControlWidth || this.TotalPages <= 0)
			{
				foreach (Control control11 in this.Controls)
				{
					Button button5 = control11 as Button;
					if (button5 != null && control11.ID.EndsWith("btn_width"))
					{
						button5.Enabled = false;
						htmlTextWriter_0.WriteLine(text + "_btn_width { opacity: 0.4 !important; background-color: transparent !important; }");
						break;
					}
				}
			}
			htmlTextWriter_0.WriteLine(text + "_btn_whole { position: absolute; top: 0px; right: 3px; background: url(" + DocumentViewer.smethod_0(this.Page, "btn_whole") + "); }");
			if (documentViewer.ZoomTo == DocumentViewer.ZoomLevel.WholePage || this.TotalPages <= 0)
			{
				foreach (Control control12 in this.Controls)
				{
					Button button6 = control12 as Button;
					if (button6 != null && control12.ID.EndsWith("btn_whole"))
					{
						button6.Enabled = false;
						htmlTextWriter_0.WriteLine(text + "_btn_whole { opacity: 0.4 !important; background-color: transparent !important; }");
						break;
					}
				}
			}
			htmlTextWriter_0.WriteLine(text + "_pnl_shadow {visibility: hidden; }");
			htmlTextWriter_0.WriteLine("</style>");
		}

		protected override bool OnBubbleEvent(object source, EventArgs args)
		{
			bool result = false;
			CommandEventArgs commandEventArgs = args as CommandEventArgs;
			if (commandEventArgs != null)
			{
				result = true;
				switch (commandEventArgs.CommandName)
				{
				case "edit":
					this.vmethod_2(commandEventArgs);
					break;
				case "first":
					this.vmethod_3(commandEventArgs);
					break;
				case "last":
					this.vmethod_8(commandEventArgs);
					break;
				case "next":
					this.vmethod_7(commandEventArgs);
					break;
				case "prev":
					this.vmethod_6(commandEventArgs);
					break;
				case "width":
					this.vmethod_9(commandEventArgs);
					break;
				case "full":
					this.vmethod_5(commandEventArgs);
					break;
				case "whole":
					this.vmethod_10(commandEventArgs);
					break;
				default:
					result = false;
					break;
				case "half":
					this.vmethod_4(commandEventArgs);
					break;
				}
			}
			return result;
		}

		protected virtual void vmethod_2(EventArgs eventArgs_0)
		{
			(base.Events[Control0.object_0] as EventHandler)?.Invoke(this, eventArgs_0);
		}

		protected virtual void vmethod_3(EventArgs eventArgs_0)
		{
			(base.Events[Control0.object_1] as EventHandler)?.Invoke(this, eventArgs_0);
		}

		protected virtual void vmethod_4(EventArgs eventArgs_0)
		{
			(base.Events[Control0.object_2] as EventHandler)?.Invoke(this, eventArgs_0);
		}

		protected virtual void vmethod_5(EventArgs eventArgs_0)
		{
			(base.Events[Control0.object_3] as EventHandler)?.Invoke(this, eventArgs_0);
		}

		protected virtual void vmethod_6(EventArgs eventArgs_0)
		{
			(base.Events[Control0.object_4] as EventHandler)?.Invoke(this, eventArgs_0);
		}

		protected virtual void vmethod_7(EventArgs eventArgs_0)
		{
			(base.Events[Control0.object_5] as EventHandler)?.Invoke(this, eventArgs_0);
		}

		protected virtual void vmethod_8(EventArgs eventArgs_0)
		{
			(base.Events[Control0.object_6] as EventHandler)?.Invoke(this, eventArgs_0);
		}

		protected virtual void vmethod_9(EventArgs eventArgs_0)
		{
			(base.Events[Control0.object_7] as EventHandler)?.Invoke(this, eventArgs_0);
		}

		protected virtual void vmethod_10(EventArgs eventArgs_0)
		{
			(base.Events[Control0.object_8] as EventHandler)?.Invoke(this, eventArgs_0);
		}
	}
}
