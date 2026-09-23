using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using Microsoft.Win32;

namespace TXTextControl.DocumentServer
{
	public class MailMergeActionList : DesignerActionList
	{
		internal enum TextControlType
		{
			None,
			Server,
			WinForms
		}

		private DesignerActionUIService m_designerActionUISvc;

		private MailMerge m_mailMerge;

		private ResourceManager m_rm;

		private const string MessageBoxCaption = "TX Document Server";

		public string TemplateFile
		{
			get
			{
				return this.m_mailMerge.TemplateFile;
			}
			set
			{
				this.SetPropertyByName("TemplateFile", this.m_mailMerge, value);
			}
		}

		public string ReportDataSourceConfigFile
		{
			get
			{
				return this.m_mailMerge.ReportDataSourceConfigFile;
			}
			set
			{
				this.SetPropertyByName("ReportDataSourceConfigFile", this.m_mailMerge, value);
			}
		}

		public MailMergeActionList(IComponent component)
			: base(component)
		{
			this.m_mailMerge = component as MailMerge;
			this.m_rm = new ResourceManager(typeof(MailMergeDesigner));
			this.m_designerActionUISvc = base.GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
		}

		public override DesignerActionItemCollection GetSortedActionItems()
		{
			if (this.m_mailMerge == null)
			{
				return null;
			}
			DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
			AssemblyName name = Assembly.GetAssembly(typeof(MailMerge)).GetName();
			string text = $"{name.Version.Major.ToString()}.{name.Version.Minor.ToString()}";
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Data"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Information"));
			designerActionItemCollection.Add(new DesignerActionHeaderItem("Wizards"));
			designerActionItemCollection.Add(new DesignerActionMethodItem(this, "SelectTemplateFile", this.m_rm.GetString("METH_SELECTTEMPLATEFILE_DISPLAY"), "Data", this.m_rm.GetString("METH_SELECTTEMPLATEFILE_INFO"), includeAsDesignerVerb: true));
			designerActionItemCollection.Add(new DesignerActionMethodItem(this, "SelectConfigFile", this.m_rm.GetString("METH_SELECTCONFIGFILE_DISPLAY"), "Data", this.m_rm.GetString("METH_SELECTCONFIGFILE_INFO"), includeAsDesignerVerb: true));
			designerActionItemCollection.Add(new DesignerActionMethodItem(this, "StartTemplateDesigner", this.m_rm.GetString("METH_STARTTEMPLDES_DISPLAY"), "Information", this.m_rm.GetString("METH_STARTTEMPLDES_INFO"), includeAsDesignerVerb: true));
			designerActionItemCollection.Add(new DesignerActionMethodItem(this, "OpenTXHelpCenter", this.m_rm.GetString("METH_OPENTXHELPCENTER_DISPLAY"), "Information", this.m_rm.GetString("METH_OPENTXHELPCENTER"), includeAsDesignerVerb: true));
			designerActionItemCollection.Add(new DesignerActionTextItem("Version: " + text, "Information"));
			designerActionItemCollection.Add(new DesignerActionMethodItem(this, "AddTextComponent", this.m_rm.GetString("METH_ADDTEXTCOMPONENT_DISPLAY"), "Wizards", this.m_rm.GetString("METH_ADDTEXTCOMPONENT"), includeAsDesignerVerb: true));
			designerActionItemCollection.Add(new DesignerActionMethodItem(this, "ConnectToTextComponent", this.m_rm.GetString("METH_CONNECTTOTEXTCOMPONENT_DISPLAY"), "Wizards", this.m_rm.GetString("METH_CONNECTTOTEXTCOMPONENT"), includeAsDesignerVerb: true));
			return designerActionItemCollection;
		}

		public void StartTemplateDesigner()
		{
			this.m_designerActionUISvc.HideUI(this.m_mailMerge);
			Version version = Environment.OSVersion.Version;
			if (version.Major >= 6 && (version.Major != 6 || version.Minor != 0 || version.Build >= 6002))
			{
				string samplesPath = this.GetSamplesPath();
				string path = Path.Combine(samplesPath, "demo\\x64");
				string text = Path.Combine(samplesPath, "demo\\reporting_quickstart.tx");
				text = "\"" + text + "\"";
				path = Path.Combine(path, "TXTextControlWords_Ribbon.exe");
				if (File.Exists(path))
				{
					Process.Start(path, text);
					return;
				}
				path = Path.Combine(samplesPath, "demo\\x86");
				path = Path.Combine(path, "TXTextControlWords_Ribbon.exe");
				if (File.Exists(path))
				{
					Process.Start(path, text);
				}
				else
				{
					MessageBox.Show(this.m_rm.GetString("ERR_TEMPLDES_NOTFOUND"), "TX Document Server", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			else
			{
				MessageBox.Show(this.m_rm.GetString("ERR_WRONG_WINDOWS_VERSION"), "TX Document Server", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		public void SelectConfigFile()
		{
			this.m_designerActionUISvc.HideUI(this.m_mailMerge);
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = "Report Data Source Configuration (*.rdsc)|*.rdsc",
				CheckFileExists = false,
				Multiselect = false
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.ReportDataSourceConfigFile = openFileDialog.FileName;
			}
		}

		public void SelectTemplateFile()
		{
			this.m_designerActionUISvc.HideUI(this.m_mailMerge);
			OpenFileDialog openFileDialog = new OpenFileDialog
			{
				Filter = "Microsoft Word (*.docx)|*.docx|Internal TX Text Control Unicode Format (*.tx)|*.tx|Microsoft Word 97-2003 (*.doc)|*.doc|Rich Text Format (*.rtf)|*.rtf",
				CheckFileExists = false,
				Multiselect = false
			};
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.TemplateFile = openFileDialog.FileName;
			}
		}

		public void OpenTXHelpCenter()
		{
			this.m_designerActionUISvc.HideUI(this.m_mailMerge);
			string text = Path.Combine(this.GetSamplesPath(), "txhelpcenter.exe");
			if (File.Exists(text))
			{
				Process.Start(text);
			}
			else
			{
				MessageBox.Show(this.m_rm.GetString("ERR_TXHELPCENTER_NOTFOUND"), "TX Document Server", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}

		public void AddTextComponent()
		{
			this.m_designerActionUISvc.HideUI(this.m_mailMerge);
			if (this.m_mailMerge.TextComponent != null)
			{
				MessageBox.Show(this.m_rm.GetString("ERR_ALREADY_CONNECTED"), "TX Document Server", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			try
			{
				IDesignerHost designerHost = (IDesignerHost)base.Component.Site.GetService(typeof(IDesignerHost));
				if (designerHost == null)
				{
					return;
				}
				using DesignerTransaction designerTransaction = designerHost.CreateTransaction();
				if (this.FindSuitableTextComponent(designerHost) != null)
				{
					MessageBox.Show(this.m_rm.GetString("ERR_TEXT_CMP_EXISTS"), "TX Document Server", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				TextControl textControl = this.AddControl(typeof(TextControl), DockStyle.Fill, designerHost) as TextControl;
				if (textControl != null)
				{
					this.SetPropertyByName("TextComponent", this.m_mailMerge, textControl);
				}
				designerTransaction.Commit();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "TX Document Server", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		public void ConnectToTextComponent()
		{
			this.m_designerActionUISvc.HideUI(this.m_mailMerge);
			if (this.m_mailMerge.TextComponent != null)
			{
				MessageBox.Show(this.m_rm.GetString("ERR_ALREADY_CONNECTED"), "TX Document Server", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
			try
			{
				IDesignerHost designerHost = (IDesignerHost)base.Component.Site.GetService(typeof(IDesignerHost));
				if (designerHost == null)
				{
					return;
				}
				using DesignerTransaction designerTransaction = designerHost.CreateTransaction();
				object obj = this.FindSuitableTextComponent(designerHost);
				if (obj != null)
				{
					this.SetPropertyByName("TextComponent", this.m_mailMerge, obj);
				}
				else
				{
					MessageBox.Show(this.m_rm.GetString("ERR_NO_TEXT_CMP_FOUND"), "TX Document Server", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				designerTransaction.Commit();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "TX Document Server", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private string GetSamplesPath()
		{
			string result = string.Empty;
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software\\Microsoft\\.NETFramework\\AssemblyFolders\\TX Text Control 29.0.NET for Windows Forms");
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

		private void SetPropertyByName(string propName, Component cmpnt, object val)
		{
			PropertyDescriptor propertyDescriptor = TypeDescriptor.GetProperties(cmpnt)[propName];
			if (propertyDescriptor == null)
			{
				throw new ArgumentException(this.m_rm.GetString("ERR_MATCH_PROPERTY_NOTFOUND"), propName);
			}
			propertyDescriptor.SetValue(cmpnt, val);
		}

		private Control AddControl(Type typeControl, DockStyle dockStyle, IDesignerHost host)
		{
			Control control = host.CreateComponent(typeControl) as Control;
			if (control != null)
			{
				ContainerControl containerControl = host.RootComponent as ContainerControl;
				if (containerControl != null)
				{
					this.SetPropertyByName("Parent", control, containerControl);
					this.SetPropertyByName("Dock", control, dockStyle);
					this.SetPropertyByName("Text", control, control.Name);
				}
			}
			return control;
		}

		private static TextControlType GetTextControlType(object obj)
		{
			if (obj == null)
			{
				return TextControlType.None;
			}
			if (obj is ServerTextControl)
			{
				return TextControlType.Server;
			}
			if (obj.GetType().FullName == "TXTextControl.TextControl")
			{
				return TextControlType.WinForms;
			}
			return TextControlType.None;
		}

		private static bool IsSuitableTextComponent(object obj)
		{
			return MailMergeActionList.GetTextControlType(obj) != TextControlType.None;
		}

		private object FindSuitableTextComponent(IDesignerHost host)
		{
			foreach (object component in host.Container.Components)
			{
				if (MailMergeActionList.IsSuitableTextComponent(component))
				{
					return component;
				}
			}
			return null;
		}
	}
}
