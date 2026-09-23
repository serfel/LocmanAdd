using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Resources;
using System.Windows.Forms;
using Microsoft.Win32;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl
{
	public class TextControlActionList : DesignerActionList
	{
		private DesignerActionUIService designerActionUISvc;

		private TextControl m_textControl;

		private ResourceManager m_rm;

		public string Text
		{
			get
			{
				return this.m_textControl.Text;
			}
			set
			{
				this.SetPropertyByName("Text", this.m_textControl, value);
			}
		}

		public ViewMode ViewMode
		{
			get
			{
				return this.m_textControl.ViewMode;
			}
			set
			{
				this.SetPropertyByName("ViewMode", this.m_textControl, value);
			}
		}

		public DockStyle Dock
		{
			get
			{
				return this.m_textControl.Dock;
			}
			set
			{
				this.m_textControl.BringToFront();
				this.SetPropertyByName("Dock", this.m_textControl, value);
			}
		}

		public TextControlActionList(IComponent component)
			: base(component)
		{
			this.m_textControl = component as TextControl;
			this.m_rm = new ResourceManager(typeof(TextControlDesigner));
			this.designerActionUISvc = base.GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
		}

		public override DesignerActionItemCollection GetSortedActionItems()
		{
			if (this.m_textControl == null)
			{
				return null;
			}
			DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Appearance"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Information"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Wizards"));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("ViewMode", "ViewMode", "Appearance", this.m_rm.GetString("PROP_VIEWMODE")));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Dock", "Dock", "Appearance", this.m_rm.GetString("PROP_DOCK")));
			designerActionItemCollection.Add(new DesignerActionPropertyItem("Text", "Text", "Appearance", this.m_rm.GetString("PROP_TEXT")));
			designerActionItemCollection.Add(new DesignerActionMethodItem(this, "AddRibbon", this.m_rm.GetString("METH_ADDRIBBON_DISPLAY"), "Wizards", this.m_rm.GetString("METH_ADDRIBBON"), includeAsDesignerVerb: true));
			designerActionItemCollection.Add(new DesignerActionMethodItem(this, "AddButtonBar", this.m_rm.GetString("METH_ADDBUTTONBAR_DISPLAY"), "Wizards", this.m_rm.GetString("METH_ADDBUTTONBAR"), includeAsDesignerVerb: true));
			designerActionItemCollection.Add(new DesignerActionMethodItem(this, "AddStatusBar", this.m_rm.GetString("METH_ADDSTATUSBAR_DISPLAY"), "Wizards", this.m_rm.GetString("METH_ADDSTATUSBAR"), includeAsDesignerVerb: true));
			designerActionItemCollection.Add(new DesignerActionMethodItem(this, "AddRulerBar", this.m_rm.GetString("METH_ADDRULERBAR_DISPLAY"), "Wizards", this.m_rm.GetString("METH_ADDRULERBAR"), includeAsDesignerVerb: true));
			designerActionItemCollection.Add(new DesignerActionMethodItem(this, "AddVerticalRulerBar", this.m_rm.GetString("METH_ADDVERTRULERBAR_DISPLAY"), "Wizards", this.m_rm.GetString("METH_ADDVERTRULERBAR"), includeAsDesignerVerb: true));
			designerActionItemCollection.Add(new DesignerActionMethodItem(this, "ArrangeControls", this.m_rm.GetString("METH_ARRANGECONTROLS_DISPLAY"), "Wizards", this.m_rm.GetString("METH_ARRANGECONTROLS"), includeAsDesignerVerb: true));
			designerActionItemCollection.Add(new DesignerActionMethodItem(this, "StartTXTextControlWords", this.m_rm.GetString("METH_STARTTXWORDS_DISPLAY"), "Information", this.m_rm.GetString("METH_STARTTXWORDS"), includeAsDesignerVerb: true));
			designerActionItemCollection.Add(new DesignerActionMethodItem(this, "OpenTXHelpCenter", this.m_rm.GetString("METH_OPENTXHELPCENTER_DISPLAY"), "Information", this.m_rm.GetString("METH_OPENTXHELPCENTER"), includeAsDesignerVerb: true));
			designerActionItemCollection.Add(new DesignerActionTextItem("Version: " + this.m_textControl.GetVersionString(), "Information"));
			return designerActionItemCollection;
		}

		private void SetPropertyByName(string propName, Control cntl, object val)
		{
			PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(cntl)[propName];
			if (propertyDescriptor == null)
			{
				throw new ArgumentException(this.m_rm.GetString("ERR_MATCH_PROPERTY_NOTFOUND"), propName);
			}
			propertyDescriptor.SetValue(cntl, val);
		}

		public void AddRibbon()
		{
			try
			{
				IDesignerHost designerHost = (IDesignerHost)base.Component.Site.GetService(typeof(IDesignerHost));
				if (designerHost == null)
				{
					return;
				}
				using DesignerTransaction designerTransaction = designerHost.CreateTransaction();
				Ribbon ribbon = this.AddControl(typeof(Ribbon), DockStyle.Top, designerHost) as Ribbon;
				if (ribbon != null)
				{
					this.SetPropertyByName("Ribbon", this.m_textControl, ribbon);
					ribbon.SendToBack();
				}
				designerTransaction.Commit();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "TX Text Control .NET", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		public void AddButtonBar()
		{
			try
			{
				IDesignerHost designerHost = (IDesignerHost)base.Component.Site.GetService(typeof(IDesignerHost));
				if (designerHost == null)
				{
					return;
				}
				using DesignerTransaction designerTransaction = designerHost.CreateTransaction();
				ButtonBar buttonBar = this.AddControl(typeof(ButtonBar), DockStyle.Top, designerHost) as ButtonBar;
				if (buttonBar != null)
				{
					this.SetPropertyByName("ButtonBar", this.m_textControl, buttonBar);
					buttonBar.SendToBack();
				}
				designerTransaction.Commit();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "TX Text Control .NET", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		public void AddStatusBar()
		{
			try
			{
				IDesignerHost designerHost = (IDesignerHost)base.Component.Site.GetService(typeof(IDesignerHost));
				if (designerHost == null)
				{
					return;
				}
				using DesignerTransaction designerTransaction = designerHost.CreateTransaction();
				StatusBar statusBar = this.AddControl(typeof(StatusBar), DockStyle.Bottom, designerHost) as StatusBar;
				if (statusBar != null)
				{
					this.SetPropertyByName("StatusBar", this.m_textControl, statusBar);
					this.SwitchStatusBarToStatusMode(statusBar);
					statusBar.SendToBack();
				}
				designerTransaction.Commit();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "TX Text Control .NET", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		public void AddRulerBar()
		{
			try
			{
				IDesignerHost designerHost = (IDesignerHost)base.Component.Site.GetService(typeof(IDesignerHost));
				if (designerHost == null)
				{
					return;
				}
				using DesignerTransaction designerTransaction = designerHost.CreateTransaction();
				RulerBar rulerBar = this.AddControl(typeof(RulerBar), DockStyle.Top, designerHost) as RulerBar;
				if (rulerBar != null)
				{
					this.SetPropertyByName("RulerBar", this.m_textControl, rulerBar);
					rulerBar.BringToFront();
				}
				designerTransaction.Commit();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "TX Text Control .NET", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		public void AddVerticalRulerBar()
		{
			try
			{
				IDesignerHost designerHost = (IDesignerHost)base.Component.Site.GetService(typeof(IDesignerHost));
				if (designerHost == null)
				{
					return;
				}
				using DesignerTransaction designerTransaction = designerHost.CreateTransaction();
				RulerBar rulerBar = this.AddControl(typeof(RulerBar), DockStyle.Left, designerHost) as RulerBar;
				if (rulerBar != null)
				{
					this.SetPropertyByName("Alignment", rulerBar, RulerBarAlignment.Left);
					this.SetPropertyByName("VerticalRulerBar", this.m_textControl, rulerBar);
					rulerBar.BringToFront();
				}
				designerTransaction.Commit();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "TX Text Control .NET", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		public void ArrangeControls()
		{
			try
			{
				IDesignerHost designerHost = (IDesignerHost)base.Component.Site.GetService(typeof(IDesignerHost));
				if (designerHost != null)
				{
					ArrayList alExistingControls = new ArrayList();
					using DesignerTransaction designerTransaction = designerHost.CreateTransaction();
					this.DockTXControls(alExistingControls);
					this.ConnectTXControls(alExistingControls);
					this.m_textControl.BringToFront();
					this.SetPropertyByName("Dock", this.m_textControl, DockStyle.Fill);
					this.SetPropertyByName("ViewMode", this.m_textControl, ViewMode.PageView);
					designerTransaction.Commit();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "TX Text Control .NET", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		public void StartTXTextControlWords()
		{
			string samplesPath = this.GetSamplesPath();
			Version version = Environment.OSVersion.Version;
			string path = ((version.Major >= 6) ? "TXTextControlWords_Ribbon.exe" : "TXTextControlWords.exe");
			string path2 = Path.Combine(samplesPath, "demo\\x64");
			string text = Path.Combine(samplesPath, "demo\\demo_windowsforms.rtf");
			text = "\"" + text + "\"";
			path2 = Path.Combine(path2, path);
			if (File.Exists(path2))
			{
				Process.Start(path2, text);
				return;
			}
			path2 = Path.Combine(samplesPath, "demo\\x86");
			path2 = Path.Combine(path2, path);
			if (File.Exists(path2))
			{
				Process.Start(path2, text);
			}
			else
			{
				MessageBox.Show(this.m_rm.GetString("ERR_TXWORDS_NOTFOUND"), "TX Text Control .NET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		public void OpenTXHelpCenter()
		{
			string samplesPath = this.GetSamplesPath();
			string text = Path.Combine(samplesPath, "txhelpcenter.exe");
			if (File.Exists(text))
			{
				Process.Start(text);
			}
			else
			{
				MessageBox.Show(this.m_rm.GetString("ERR_TXHELPCENTER_NOTFOUND"), "TX Text Control .NET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		private Control AddControl(Type typeControl, DockStyle dockStyle, IDesignerHost designer)
		{
			IComponent component = designer.CreateComponent(typeControl);
			Control control = component as Control;
			if (control != null)
			{
				this.SetPropertyByName("Parent", control, this.m_textControl.Parent);
				this.SetPropertyByName("Dock", control, dockStyle);
				this.SetPropertyByName("Text", control, control.Name);
			}
			return control;
		}

		private void SwitchStatusBarToStatusMode(StatusBar statusBar)
		{
			statusBar.ColumnText = " ";
			statusBar.ColumnText = "";
		}

		private string GetSamplesPath()
		{
			string result = string.Empty;
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\.NETFramework\\v4.0.30319\\AssemblyFoldersEx\\TX Text Control 29.0.NET for Windows Forms");
			if (registryKey != null)
			{
				string text = (string)registryKey.GetValue(null);
				if (text != null)
				{
					result = text.Substring(0, text.Length - 8);
					result = Path.Combine(result, "samples");
				}
			}
			return result;
		}

		private void DockTXControls(ArrayList alExistingControls)
		{
			bool flag = false;
			foreach (Control control in this.m_textControl.Parent.Controls)
			{
				switch (control.GetType().Name)
				{
				case "MenuStrip":
					if (control.Dock == DockStyle.Top)
					{
						alExistingControls.Add(control);
					}
					break;
				case "StatusBar":
					this.SetPropertyByName("Dock", control, DockStyle.Bottom);
					this.SwitchStatusBarToStatusMode((StatusBar)control);
					alExistingControls.Add(control);
					break;
				case "ButtonBar":
					this.SetPropertyByName("Dock", control, DockStyle.Top);
					alExistingControls.Add(control);
					break;
				case "Ribbon":
					if (control.Dock == DockStyle.Top)
					{
						alExistingControls.Add(control);
					}
					break;
				case "RulerBar":
					if (!flag)
					{
						this.SetPropertyByName("Dock", control, DockStyle.Top);
						flag = true;
					}
					else
					{
						this.SetPropertyByName("Dock", control, DockStyle.Left);
						flag = false;
					}
					alExistingControls.Add(control);
					break;
				}
			}
		}

		private void ConnectTXControls(ArrayList alExistingControls)
		{
			for (int i = 0; i <= 5; i++)
			{
				foreach (Control alExistingControl in alExistingControls)
				{
					switch (i)
					{
					case 0:
						if (alExistingControl.GetType() == typeof(RulerBar) && alExistingControl.Dock == DockStyle.Top)
						{
							alExistingControl.SendToBack();
							this.SetPropertyByName("RulerBar", this.m_textControl, alExistingControl);
						}
						break;
					case 1:
						if (alExistingControl.GetType() == typeof(ButtonBar))
						{
							alExistingControl.SendToBack();
							this.SetPropertyByName("ButtonBar", this.m_textControl, alExistingControl);
						}
						break;
					case 2:
						if (alExistingControl.GetType() == typeof(StatusBar))
						{
							alExistingControl.SendToBack();
							this.SetPropertyByName("StatusBar", this.m_textControl, alExistingControl);
						}
						break;
					case 3:
						if (alExistingControl.GetType() == typeof(RulerBar) && alExistingControl.Dock == DockStyle.Left)
						{
							this.SetPropertyByName("VerticalRulerBar", this.m_textControl, alExistingControl);
						}
						break;
					case 4:
						if (alExistingControl.GetType() == typeof(MenuStrip) && alExistingControl.Dock == DockStyle.Top)
						{
							alExistingControl.SendToBack();
						}
						break;
					case 5:
						if (alExistingControl.GetType() == typeof(Ribbon) && alExistingControl.Dock == DockStyle.Top)
						{
							alExistingControl.SendToBack();
						}
						break;
					}
				}
			}
		}
	}
}
