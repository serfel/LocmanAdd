using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using TXTextControl.DocumentServer;
using DocumentServer.Fields;
using DocumentServer.Web;

namespace ns2
{
	internal class Control1 : CompositeControl
	{
		private bool bool_0;

		private Panel panel_0 = new Panel();

		protected override HtmlTextWriterTag TagKey => HtmlTextWriterTag.Div;

		protected override void CreateChildControls()
		{
			this.Controls.Clear();
			Panel panel = new Panel();
			panel.ID = "pagemargins";
			this.panel_0 = new Panel();
			this.panel_0.ID = "document";
			panel.Controls.Add(this.panel_0);
			this.Controls.Add(panel);
			base.ChildControlsCreated = true;
		}

		~Control1()
		{
			this.Dispose(disposing: false);
		}

		public override void Dispose()
		{
			this.Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (this.bool_0)
			{
				return;
			}
			if (disposing && this.Controls != null)
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

		private string method_0()
		{
			DocumentViewer documentViewer = this.Parent as DocumentViewer;
			StringBuilder stringBuilder = new StringBuilder();
			if (!base.DesignMode && documentViewer != null)
			{
				stringBuilder.Append(this.Page.Request.Url.PathAndQuery);
				stringBuilder.Append((this.Page.Request.QueryString.Count > 0) ? "&" : "?");
				stringBuilder.Append("viewerId=" + documentViewer.ClientID);
				stringBuilder.Append("&pageId=" + documentViewer.String_0);
			}
			return stringBuilder.ToString();
		}

		internal void method_1(FormFieldAdapter formFieldAdapter_0, int int_0, double double_0)
		{
			DocumentViewer documentViewer = this.Parent as DocumentViewer;
			if (formFieldAdapter_0 == null || double_0 == 0.0)
			{
				return;
			}
			WebControl webControl = null;
			if (formFieldAdapter_0 is FormCheckBox)
			{
				FormCheckBox formCheckBox = formFieldAdapter_0 as FormCheckBox;
				CheckBox obj = new CheckBox
				{
					ID = $"{formCheckBox.Name}_{int_0:d3}",
					CssClass = "formcheckbox",
					Checked = formCheckBox.Checked
				};
				HiddenField child = new HiddenField
				{
					ID = $"{formCheckBox.Name}_{int_0:d3}",
					Value = "off"
				};
				this.EnsureChildControls();
				this.panel_0.Controls.Add(child);
				int num = DocumentController.Twips2Pixels((int)Math.Round((double)(formCheckBox.Font.Size - 2) * double_0), DocumentController.DpiY);
				obj.Style.Add("width", $"{num}px");
				obj.Style.Add("height", $"{num}px");
				int num2 = DocumentController.Twips2Pixels((int)Math.Round((double)(formCheckBox.Bounds.X - 1) * double_0), DocumentController.DpiX);
				int num3 = DocumentController.Twips2Pixels((int)Math.Round((double)(formCheckBox.Bounds.Y - 1) * double_0), DocumentController.DpiY);
				obj.Style.Add("left", $"{num2}px");
				obj.Style.Add("top", $"{num3}px");
				StringBuilder stringBuilder = new StringBuilder();
				if (formCheckBox.Font.Bold)
				{
					stringBuilder.Append(" bold");
				}
				if (formCheckBox.Font.Italic)
				{
					stringBuilder.Append(" italic");
				}
				stringBuilder.Append(" " + num + "px");
				stringBuilder.Append(" " + formCheckBox.Font.Name);
				obj.Style.Add("font", stringBuilder.ToString().Trim());
				obj.ToolTip = formCheckBox.HelpText;
				webControl = obj;
			}
			else if (formFieldAdapter_0 is FormDropDown)
			{
				FormDropDown formDropDown = formFieldAdapter_0 as FormDropDown;
				DropDownList dropDownList = new DropDownList();
				dropDownList.ID = $"{formDropDown.Name}_{int_0:d3}";
				dropDownList.CssClass = "formdropdown";
				foreach (string listEntry in formDropDown.ListEntries)
				{
					dropDownList.Items.Add(new ListItem(listEntry));
				}
				if (documentViewer != null && documentViewer.method_2(dropDownList.ID) != null)
				{
					dropDownList.SelectedValue = documentViewer.method_2(dropDownList.ID);
				}
				int num4 = DocumentController.Twips2Pixels((int)Math.Round((double)(formDropDown.Bounds.Width - 2) * double_0), DocumentController.DpiX);
				int num5 = DocumentController.Twips2Pixels((int)Math.Round((double)(formDropDown.Bounds.Height - 2) * double_0), DocumentController.DpiY);
				int num6 = DocumentController.Twips2Pixels((int)Math.Round((double)formDropDown.Bounds.X * double_0), DocumentController.DpiX);
				int num7 = DocumentController.Twips2Pixels((int)Math.Round((double)formDropDown.Bounds.Y * double_0), DocumentController.DpiY);
				dropDownList.Style.Add("width", num4 + "px");
				dropDownList.Style.Add("height", num5 + "px");
				dropDownList.Style.Add("left", num6 + "px");
				dropDownList.Style.Add("top", num7 + "px");
				StringBuilder stringBuilder2 = new StringBuilder();
				if (formDropDown.Font.Bold)
				{
					stringBuilder2.Append(" bold");
				}
				if (formDropDown.Font.Italic)
				{
					stringBuilder2.Append(" italic");
				}
				stringBuilder2.Append(" " + (num5 - 4) + "px");
				stringBuilder2.Append(" " + formDropDown.Font.Name);
				dropDownList.Style.Add("font", stringBuilder2.ToString().Trim());
				dropDownList.ToolTip = formDropDown.HelpText;
				webControl = dropDownList;
			}
			else if (formFieldAdapter_0 is FormText)
			{
				FormText formText = formFieldAdapter_0 as FormText;
				TextBox textBox = new TextBox();
				textBox.ID = $"{formText.Name}_{int_0:d3}";
				textBox.CssClass = "formtext";
				textBox.Text = formText.Text;
				int num8 = DocumentController.Twips2Pixels((int)Math.Round((double)(formText.Bounds.Width - 2) * double_0), DocumentController.DpiX);
				int num9 = DocumentController.Twips2Pixels((int)Math.Round((double)(formText.Bounds.Height - 2) * double_0), DocumentController.DpiY);
				int num10 = DocumentController.Twips2Pixels((int)Math.Round((double)formText.Bounds.X * double_0), DocumentController.DpiX);
				int num11 = DocumentController.Twips2Pixels((int)Math.Round((double)formText.Bounds.Y * double_0), DocumentController.DpiY);
				textBox.Style.Add("width", num8 + "px");
				textBox.Style.Add("height", num9 + "px");
				textBox.Style.Add("left", num10 + "px");
				textBox.Style.Add("top", num11 + "px");
				StringBuilder stringBuilder3 = new StringBuilder();
				if (formText.Font.Bold)
				{
					stringBuilder3.Append(" bold");
				}
				if (formText.Font.Italic)
				{
					stringBuilder3.Append(" italic");
				}
				int num12 = DocumentController.Twips2Pixels((int)Math.Round((double)formText.Font.Size * double_0), DocumentController.DpiY);
				int num13 = num9 - 2;
				stringBuilder3.Append(" " + ((num12 >= num9) ? num13 : num12) + "px");
				stringBuilder3.Append(" " + formText.Font.Name);
				textBox.Style.Add("font", stringBuilder3.ToString().Trim());
				if (formText.Font.Strikeout)
				{
					textBox.Style.Add("text-decoration", "line-through");
				}
				else if (formText.Font.Underline)
				{
					textBox.Style.Add("text-decoration", "underline");
				}
				textBox.MaxLength = formText.MaxLength;
				textBox.ToolTip = formText.HelpText;
				webControl = textBox;
			}
			if (webControl != null)
			{
				this.EnsureChildControls();
				this.panel_0.Controls.Add(webControl);
			}
		}

		protected virtual void vmethod_1(HtmlTextWriter htmlTextWriter_0)
		{
			WebColorConverter webColorConverter = new WebColorConverter();
			DocumentViewer documentViewer = this.Parent as DocumentViewer;
			string text = "#" + this.ClientID;
			htmlTextWriter_0.WriteLine("<style type=\"text/css\">");
			htmlTextWriter_0.WriteLine(text + " { width: auto; height: " + (int)(documentViewer.Height.Value - (documentViewer.ToolBar ? 39.0 : 0.0)) + "px; position: relative; text-align: center; overflow: auto; background-color: #393939; background: -webkit-radial-gradient(#a6a6a6, #393939); background: -o-radial-gradient(#a6a6a6, #393939); background: -moz-radial-gradient(#a6a6a6, #393939); background: radial-gradient(#a6a6a6, #393939); }");
			htmlTextWriter_0.WriteLine(text + "_pagemargins { width: " + documentViewer.Size_0.Width + "px; height: " + documentViewer.Size_0.Height + "px; margin: 0 auto; padding: 36px; text-align: center; background: transparent; }");
			htmlTextWriter_0.WriteLine(text + "_document { position: relative; background: url(" + this.method_0() + ") no-repeat #fff; box-shadow: 0px 0px 20px 2px rgba(0, 0, 0, 0.5); width: " + documentViewer.Size_0.Width + "px; height: " + documentViewer.Size_0.Height + "px; margin: 0; padding: 0; border: none; text-align: left; }");
			if (documentViewer.RoundedPageCorners)
			{
				htmlTextWriter_0.WriteLine(text + "_document { border-radius: 10px; }");
			}
			if (documentViewer.PageAnimations)
			{
				htmlTextWriter_0.WriteLine(text + "_document { animation-name: stretch; animation-duration: " + documentViewer.PageAnimationDuration + "s; animation-delay: 0s; animation-iteration-count: 1; animation-play-state: running; }");
			}
			if (documentViewer.PageNumber < 1)
			{
				htmlTextWriter_0.WriteLine(text + "_document { display: none; }");
				htmlTextWriter_0.WriteLine(text + "_pagepanel { display: none; }");
			}
			htmlTextWriter_0.WriteLine(text + " input.formtext { position: absolute; margin: 0; padding: 0; border: " + ((documentViewer.FieldBorderStyle == FieldBorderStyle.None) ? "none" : ("1px " + documentViewer.FieldBorderStyle.ToString().ToLower() + " " + webColorConverter.ConvertToString(documentViewer.FieldBorderColor))) + "; }");
			htmlTextWriter_0.WriteLine(text + " span.formcheckbox { display: block; position: absolute; margin: 0; padding: 0; }");
			htmlTextWriter_0.WriteLine(text + " select.formdropdown { position: absolute; margin: 0; }");
			htmlTextWriter_0.WriteLine(text + " input[type=\"checkbox\"] {  margin: 0pt; }");
			htmlTextWriter_0.WriteLine("</style>");
		}
	}
}
