using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace TXTextControl.Windows.Forms.Ribbon
{
	public class RibbonActionList : DesignerActionList
	{
		public enum CodeModelLanguage
		{
			const_0,
			CSharp,
			const_2,
			Other
		}

		private DesignerActionUIService designerActionUISvc;

		private Ribbon m_Ribbon;

		private ResourceManager m_rm;

		public RibbonActionList(IComponent component)
			: base(component)
		{
			this.m_Ribbon = component as Ribbon;
			this.m_rm = new ResourceManager(typeof(TextControlDesigner));
			this.designerActionUISvc = base.GetService(typeof(DesignerActionUIService)) as DesignerActionUIService;
		}

		public override DesignerActionItemCollection GetSortedActionItems()
		{
			if (this.m_Ribbon == null)
			{
				return null;
			}
			DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
			designerActionItemCollection.Add(new DesignerActionMethodItem(this, "ConvertToRibbonForm", this.m_rm.GetString("METH_CONVERTTORIBBONFORM_DISPLAY"), "", this.m_rm.GetString("METH_CONVERTTORIBBONFORM"), includeAsDesignerVerb: true));
			designerActionItemCollection.Add(new DesignerActionMethodItem(this, "AddFormattingTab", this.m_rm.GetString("METH_ADDRIBBONFORMATTINGTAB_DISPLAY"), "", this.m_rm.GetString("METH_ADDRIBBONFORMATTINGTAB"), includeAsDesignerVerb: true));
			designerActionItemCollection.Add(new DesignerActionMethodItem(this, "AddInsertTab", this.m_rm.GetString("METH_ADDRIBBONINSERTTAB_DISPLAY"), "", this.m_rm.GetString("METH_ADDRIBBONINSERTTAB"), includeAsDesignerVerb: true));
			designerActionItemCollection.Add(new DesignerActionMethodItem(this, "AddPageLayoutTab", this.m_rm.GetString("METH_ADDRIBBONPAGELAYOUTTAB_DISPLAY"), "", this.m_rm.GetString("METH_ADDRIBBONPAGELAYOUTTAB"), includeAsDesignerVerb: true));
			designerActionItemCollection.Add(new DesignerActionMethodItem(this, "AddViewTab", this.m_rm.GetString("METH_ADDRIBBONVIEWTAB_DISPLAY"), "", this.m_rm.GetString("METH_ADDRIBBONVIEWTAB"), includeAsDesignerVerb: true));
			designerActionItemCollection.Add(new DesignerActionMethodItem(this, "AddProofingTab", this.m_rm.GetString("METH_ADDRIBBONPROOFINGTAB_DISPLAY"), "", this.m_rm.GetString("METH_ADDRIBBONPROOFINGTAB"), includeAsDesignerVerb: true));
			designerActionItemCollection.Add(new DesignerActionMethodItem(this, "AddPermissionsTab", this.m_rm.GetString("METH_ADDRIBBONPERMISSIONSTAB_DISPLAY"), "", this.m_rm.GetString("METH_ADDRIBBONPERMISSIONSTAB"), includeAsDesignerVerb: true));
			designerActionItemCollection.Add(new DesignerActionMethodItem(this, "AddReportingTab", this.m_rm.GetString("METH_ADDRIBBONREPORTINGTAB_DISPLAY"), "", this.m_rm.GetString("METH_ADDRIBBONREPORTINGTAB"), includeAsDesignerVerb: true));
			designerActionItemCollection.Add(new DesignerActionMethodItem(this, "AddFormFieldsTab", this.m_rm.GetString("METH_ADDRIBBONFORMFIELDSTAB_DISPLAY"), "", this.m_rm.GetString("METH_ADDRIBBONFORMFIELDSTAB"), includeAsDesignerVerb: true));
			designerActionItemCollection.Add(new DesignerActionMethodItem(this, "AddReferencesTab", this.m_rm.GetString("METH_ADDRIBBONREFERENCESTAB_DISPLAY"), "", this.m_rm.GetString("METH_ADDRIBBONREFERENCESTAB"), includeAsDesignerVerb: true));
			designerActionItemCollection.Add(new DesignerActionMethodItem(this, "AddNewTab", this.m_rm.GetString("METH_ADDRIBBONTAB_DISPLAY"), "", this.m_rm.GetString("METH_ADDRIBBONTAB"), includeAsDesignerVerb: true));
			designerActionItemCollection.Add(new DesignerActionMethodItem(this, "RemoveTab", this.m_rm.GetString("METH_REMOVERIBBONTAB_DISPLAY"), "", this.m_rm.GetString("METH_REMOVERIBBONTAB"), includeAsDesignerVerb: true));
			designerActionItemCollection.Add(new DesignerActionMethodItem(this, "AddTextControl", this.m_rm.GetString("METH_ADDTEXTCONTROL_DISPLAY"), "", this.m_rm.GetString("METH_ADDTEXTCONTROL"), includeAsDesignerVerb: true));
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

		public void AddFormattingTab()
		{
			this.AddTab(typeof(RibbonFormattingTab));
		}

		public void AddInsertTab()
		{
			this.AddTab(typeof(RibbonInsertTab));
		}

		public void AddPageLayoutTab()
		{
			this.AddTab(typeof(RibbonPageLayoutTab));
		}

		public void AddViewTab()
		{
			this.AddTab(typeof(RibbonViewTab));
		}

		public void AddProofingTab()
		{
			this.AddTab(typeof(RibbonProofingTab));
		}

		public void AddPermissionsTab()
		{
			this.AddTab(typeof(RibbonPermissionsTab));
		}

		public void AddReportingTab()
		{
			this.AddTab(typeof(RibbonReportingTab));
		}

		public void AddFormFieldsTab()
		{
			this.AddTab(typeof(RibbonFormFieldsTab));
		}

		public void AddReferencesTab()
		{
			this.AddTab(typeof(RibbonReferencesTab));
		}

		public void AddNewTab()
		{
			this.AddTab(typeof(RibbonTab));
		}

		public void AddTab(Type tabType)
		{
			try
			{
				IDesignerHost designerHost = (IDesignerHost)base.Component.Site.GetService(typeof(IDesignerHost));
				if (designerHost == null)
				{
					return;
				}
				using DesignerTransaction designerTransaction = designerHost.CreateTransaction();
				IComponent component = designerHost.CreateComponent(tabType);
				Control control = component as Control;
				if (control != null && control is RibbonTab)
				{
					if (control.GetType() == typeof(RibbonTab))
					{
						control.Text = control.Name;
					}
					this.m_Ribbon.Controls.Add(control);
					this.m_Ribbon.SelectedTab = (RibbonTab)control;
				}
				designerTransaction.Commit();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "TX Text Control .NET", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		public void RemoveTab()
		{
			try
			{
				IDesignerHost designerHost = (IDesignerHost)base.Component.Site.GetService(typeof(IDesignerHost));
				if (designerHost == null)
				{
					return;
				}
				using DesignerTransaction designerTransaction = designerHost.CreateTransaction();
				int num = this.m_Ribbon.SelectedIndex;
				_ = this.m_Ribbon.Controls.Count;
				if (num == 0 && this.m_Ribbon.HasApplicationMenu)
				{
					num = -1;
				}
				if (num >= 0)
				{
					designerHost.DestroyComponent(this.m_Ribbon.Controls[num]);
				}
				designerTransaction.Commit();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "TX Text Control .NET", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		public void AddTextControl()
		{
			try
			{
				IDesignerHost designerHost = (IDesignerHost)base.Component.Site.GetService(typeof(IDesignerHost));
				if (designerHost == null)
				{
					return;
				}
				using DesignerTransaction designerTransaction = designerHost.CreateTransaction();
				TextControl textControl = this.AddControl(typeof(TextControl), DockStyle.Fill, designerHost) as TextControl;
				if (textControl != null)
				{
					this.SetPropertyByName("Ribbon", textControl, this.m_Ribbon);
					textControl.BringToFront();
				}
				designerTransaction.Commit();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "TX Text Control .NET", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private Control AddControl(Type typeControl, DockStyle dockStyle, IDesignerHost designer)
		{
			IComponent component = designer.CreateComponent(typeControl);
			Control control = component as Control;
			if (control != null)
			{
				this.SetPropertyByName("Parent", control, this.m_Ribbon.Parent);
				this.SetPropertyByName("Dock", control, dockStyle);
				this.SetPropertyByName("Text", control, control.Name);
			}
			return control;
		}

		public void ConvertToRibbonForm()
		{
			if (this.m_Ribbon.Parent is RibbonForm)
			{
				return;
			}
			try
			{
				Assembly assembly = Assembly.Load("EnvDTE, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");
				object service = base.GetService(assembly.GetType("EnvDTE.DTE"));
				proxyDTE proxyDTE = new proxyDTE(assembly, service);
				CodeModelLanguage projectItemLanguage = this.GetProjectItemLanguage(assembly, proxyDTE);
				if (projectItemLanguage != CodeModelLanguage.CSharp && projectItemLanguage != 0)
				{
					ResourceManager resourceManager = new ResourceManager(typeof(TextControlDesigner));
					MessageBox.Show(resourceManager.GetString("ERR_PROJECT_TYPE_NOT_SUPPORTED"), "TX Text Control .NET", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				string strText = "";
				string strReplace = "";
				string value = "";
				switch (projectItemLanguage)
				{
				case CodeModelLanguage.const_0:
					strText = "Inherits System.Windows.Forms.Form";
					strReplace = "Inherits TXTextControl.Windows.Forms.Ribbon.RibbonForm";
					value = ".vb";
					break;
				case CodeModelLanguage.CSharp:
					strText = " : Form";
					strReplace = " : TXTextControl.Windows.Forms.Ribbon.RibbonForm";
					value = ".cs";
					break;
				}
				proxyDocuments proxyDocuments = new proxyDocuments(assembly, proxyDTE.Documents);
				int num = 1;
				proxyDocument proxyDocument;
				while (true)
				{
					if (num > proxyDocuments.Count)
					{
						return;
					}
					proxyDocument = new proxyDocument(assembly, proxyDocuments.Item(num));
					if (proxyDocument.Name.EndsWith(value))
					{
						proxyProjectItem proxyProjectItem = new proxyProjectItem(assembly, proxyDocument.ProjectItem);
						proxyProjectItem.Open();
						if (proxyDocument.MarkText(strText, 0))
						{
							break;
						}
					}
					num++;
				}
				proxyDocument.ReplaceText(strText, strReplace, 0);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "TX Text Control .NET", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private CodeModelLanguage GetProjectItemLanguage(Assembly assemblyDTE, proxyDTE globalDTE)
		{
			proxyDocument proxyDocument = new proxyDocument(assemblyDTE, globalDTE.ActiveDocument);
			proxyProjectItem proxyProjectItem = new proxyProjectItem(assemblyDTE, proxyDocument.ProjectItem);
			proxyFileCodeModel proxyFileCodeModel = new proxyFileCodeModel(assemblyDTE, proxyProjectItem.FileCodeModel);
			return proxyFileCodeModel.Language switch
			{
				"{B5E9BD36-6D3E-4B5D-925E-8A43B79820B4}" => CodeModelLanguage.Other, 
				"{B5E9BD32-6D3E-4B5D-925E-8A43B79820B4}" => CodeModelLanguage.Other, 
				"{B5E9BD34-6D3E-4B5D-925E-8A43B79820B4}" => CodeModelLanguage.CSharp, 
				"{B5E9BD33-6D3E-4B5D-925E-8A43B79820B4}" => CodeModelLanguage.const_0, 
				_ => CodeModelLanguage.Other, 
			};
		}
	}
}
