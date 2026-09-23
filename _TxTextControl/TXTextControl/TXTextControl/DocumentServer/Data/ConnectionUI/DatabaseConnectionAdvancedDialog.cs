using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.ComponentModel.Com2Interop;
using ns16;
using DocumentServer.Properties;
using DocumentServer.Windows.Forms;

namespace DocumentServer.Data.ConnectionUI
{
	[Obfuscation(Exclude = true)]
	internal class DatabaseConnectionAdvancedDialog : HighDpiForm
	{
		internal class Class152 : PropertyGrid
		{
			private ContextMenuStrip contextMenuStrip_0;

			public Class152()
			{
				this.contextMenuStrip_0 = new ContextMenuStrip();
				this.contextMenuStrip_0.Items.AddRange(new ToolStripItem[6]
				{
					new ToolStripMenuItem(),
					new ToolStripSeparator(),
					new ToolStripMenuItem(),
					new ToolStripMenuItem(),
					new ToolStripSeparator(),
					new ToolStripMenuItem()
				});
				this.contextMenuStrip_0.Items[0].Text = Resources.DATACONNECTIONADVANCED_DIALOG_RESET;
				this.contextMenuStrip_0.Items[0].Click += method_0;
				this.contextMenuStrip_0.Items[2].Text = Resources.DATACONNECTIONADVANCED_DIALOG_ADD;
				this.contextMenuStrip_0.Items[2].Click += method_1;
				this.contextMenuStrip_0.Items[3].Text = Resources.DATACONNECTIONADVANCED_DIALOG_REMOVE;
				this.contextMenuStrip_0.Items[3].Click += method_2;
				this.contextMenuStrip_0.Items[5].Text = Resources.DATACONNECTIONADVANCED_DIALOG_DESCRIPTION;
				this.contextMenuStrip_0.Items[5].Click += method_3;
				(this.contextMenuStrip_0.Items[5] as ToolStripMenuItem).Checked = this.HelpVisible;
				this.contextMenuStrip_0.Opened += contextMenuStrip_0_Opened;
				this.ContextMenuStrip = this.contextMenuStrip_0;
				base.DrawFlatToolbar = true;
				base.Size = new Size(270, 250);
				this.MinimumSize = base.Size;
			}

			protected override void OnHandleCreated(EventArgs eventArgs_0)
			{
				ProfessionalColorTable professionalColorTable = ((base.ParentForm == null || base.ParentForm.Site == null) ? null : (base.ParentForm.Site.GetService(typeof(ProfessionalColorTable)) as ProfessionalColorTable));
				if (professionalColorTable != null)
				{
					base.ToolStripRenderer = new ToolStripProfessionalRenderer(professionalColorTable);
				}
				base.OnHandleCreated(eventArgs_0);
			}

			protected override void OnFontChanged(EventArgs eventArgs_0)
			{
				base.OnFontChanged(eventArgs_0);
				base.LargeButtons = (double)this.Font.SizeInPoints >= 15.0;
			}

			protected override void WndProc(ref Message message)
			{
				if (message.Msg == 7)
				{
					base.Focus();
					((IComPropertyBrowser)this).HandleF4();
				}
				base.WndProc(ref message);
			}

			private void contextMenuStrip_0_Opened(object sender, EventArgs e)
			{
				this.contextMenuStrip_0.Items[0].Enabled = base.SelectedGridItem.GridItemType == GridItemType.Property;
				bool enabled;
				if (this.contextMenuStrip_0.Items[0].Enabled && base.SelectedGridItem.PropertyDescriptor != null)
				{
					object component = base.SelectedObject;
					if (base.SelectedObject is ICustomTypeDescriptor)
					{
						component = (base.SelectedObject as ICustomTypeDescriptor).GetPropertyOwner(base.SelectedGridItem.PropertyDescriptor);
					}
					ToolStripItem toolStripItem = this.contextMenuStrip_0.Items[0];
					enabled = (this.contextMenuStrip_0.Items[3].Enabled = base.SelectedGridItem.PropertyDescriptor.CanResetValue(component));
					toolStripItem.Enabled = enabled;
				}
				ToolStripItem toolStripItem2 = this.contextMenuStrip_0.Items[2];
				enabled = (this.contextMenuStrip_0.Items[3].Visible = (base.SelectedObject as IDataConnectionProperties).IsExtensible);
				toolStripItem2.Visible = enabled;
				if (this.contextMenuStrip_0.Items[3].Visible)
				{
					this.contextMenuStrip_0.Items[3].Enabled = base.SelectedGridItem.GridItemType == GridItemType.Property;
					if (this.contextMenuStrip_0.Items[3].Enabled && base.SelectedGridItem.PropertyDescriptor != null)
					{
						this.contextMenuStrip_0.Items[3].Enabled = !base.SelectedGridItem.PropertyDescriptor.IsReadOnly;
					}
				}
				this.contextMenuStrip_0.Items[1].Visible = this.contextMenuStrip_0.Items[2].Visible || this.contextMenuStrip_0.Items[3].Visible;
			}

			private void method_0(object sender, EventArgs e)
			{
				object value = base.SelectedGridItem.Value;
				object component = base.SelectedObject;
				if (base.SelectedObject is ICustomTypeDescriptor)
				{
					component = (base.SelectedObject as ICustomTypeDescriptor).GetPropertyOwner(base.SelectedGridItem.PropertyDescriptor);
				}
				base.SelectedGridItem.PropertyDescriptor.ResetValue(component);
				this.Refresh();
				this.OnPropertyValueChanged(new PropertyValueChangedEventArgs(base.SelectedGridItem, value));
			}

			private void method_1(object sender, EventArgs e)
			{
				DatabaseConnectionDialog databaseConnectionDialog = base.ParentForm as DatabaseConnectionDialog;
				if (databaseConnectionDialog == null)
				{
					databaseConnectionDialog = (base.ParentForm as DatabaseConnectionAdvancedDialog).databaseConnectionDialog_0;
				}
				AddPropertyDialog addPropertyDialog = new AddPropertyDialog(databaseConnectionDialog);
				try
				{
					if (base.ParentForm.Container != null)
					{
						base.ParentForm.Container.Add(addPropertyDialog);
					}
					if (addPropertyDialog.ShowDialog(base.ParentForm) == DialogResult.OK)
					{
						(base.SelectedObject as IDataConnectionProperties).Add(addPropertyDialog.PropertyName);
						this.Refresh();
						GridItem selectedGridItem = base.SelectedGridItem;
						while (selectedGridItem.Parent != null)
						{
							selectedGridItem = selectedGridItem.Parent;
						}
						GridItem gridItem = this.method_4(selectedGridItem, addPropertyDialog.PropertyName);
						if (gridItem != null)
						{
							base.SelectedGridItem = gridItem;
						}
					}
				}
				finally
				{
					if (base.ParentForm.Container != null)
					{
						base.ParentForm.Container.Remove(addPropertyDialog);
					}
					addPropertyDialog.Dispose();
				}
			}

			private void method_2(object sender, EventArgs e)
			{
				(base.SelectedObject as IDataConnectionProperties).Remove(base.SelectedGridItem.Label);
				this.Refresh();
				this.OnPropertyValueChanged(new PropertyValueChangedEventArgs(null, null));
			}

			private void method_3(object sender, EventArgs e)
			{
				this.HelpVisible = !this.HelpVisible;
				(this.contextMenuStrip_0.Items[5] as ToolStripMenuItem).Checked = !(this.contextMenuStrip_0.Items[5] as ToolStripMenuItem).Checked;
			}

			private GridItem method_4(GridItem gridItem_0, string string_0)
			{
				if (gridItem_0.GridItemType == GridItemType.Property && gridItem_0.Label.Equals(string_0, StringComparison.CurrentCulture))
				{
					return gridItem_0;
				}
				GridItem gridItem = null;
				foreach (GridItem gridItem2 in gridItem_0.GridItems)
				{
					gridItem = this.method_4(gridItem2, string_0);
					if (gridItem != null)
					{
						return gridItem;
					}
				}
				return gridItem;
			}
		}

		private string string_0;

		private DatabaseConnectionDialog databaseConnectionDialog_0;

		private IContainer icontainer_0;

		private TextBox textBox;

		private System.Windows.Forms.Button okButton;

		private System.Windows.Forms.Button cancelButton;

		private Class152 propertyGrid;

		private TableLayoutPanel tableLayoutPanel1;

		public DatabaseConnectionAdvancedDialog()
		{
			this.InitializeComponent();
			if (this.icontainer_0 == null)
			{
				this.icontainer_0 = new Container();
			}
			this.icontainer_0.Add(new Class166(this));
			this.Text = Resources.DATACONNECTIONADVANCED_DIALOG_TITLE;
			this.textBox.AccessibleName = Resources.DATACONNECTIONADVANCED_DIALOG_TEXTBOX_ACCNAME;
			this.propertyGrid.AccessibleName = Resources.DATACONNECTIONADVANCED_DIALOG_PROPGRID_ACCNAME;
			this.cancelButton.Text = Resources.DATACONNECTIONADVANCED_DIALOG_BUTTON_CANCEL;
			this.okButton.Text = Resources.DATACONNECTIONADVANCED_DIALOG_BUTTON_OK;
		}

		public DatabaseConnectionAdvancedDialog(IDataConnectionProperties connectionProperties, DatabaseConnectionDialog mainDialog)
			: this()
		{
			this.string_0 = connectionProperties.ToFullString();
			this.propertyGrid.SelectedObject = connectionProperties;
			this.databaseConnectionDialog_0 = mainDialog;
		}

		protected override void OnLoad(EventArgs eventArgs_0)
		{
			base.OnLoad(eventArgs_0);
			this.method_2();
		}

		protected override void OnShown(EventArgs eventArgs_0)
		{
			base.OnShown(eventArgs_0);
			this.propertyGrid.Focus();
		}

		protected override void OnFontChanged(EventArgs eventArgs_0)
		{
			base.OnFontChanged(eventArgs_0);
			this.textBox.Width = this.propertyGrid.Width;
		}

		protected override void OnHelpRequested(HelpEventArgs hevent)
		{
			Control control = this;
			ContainerControl containerControl = null;
			while ((containerControl = control as ContainerControl) != null && containerControl != this.propertyGrid && containerControl.ActiveControl != null)
			{
				control = containerControl.ActiveControl;
			}
			Enum29 enum29_ = Enum29.const_20;
			if (control == this.propertyGrid)
			{
				enum29_ = Enum29.const_21;
			}
			if (control == this.textBox)
			{
				enum29_ = Enum29.const_22;
			}
			if (control == this.okButton)
			{
				enum29_ = Enum29.const_23;
			}
			if (control == this.cancelButton)
			{
				enum29_ = Enum29.const_24;
			}
			EventArgs0 eventArgs = new EventArgs0(enum29_, hevent.MousePos);
			this.databaseConnectionDialog_0.method_7(eventArgs);
			hevent.Handled = eventArgs.Handled;
			if (!eventArgs.Handled)
			{
				base.OnHelpRequested(hevent);
			}
		}

		protected override void WndProc(ref Message message)
		{
			if (this.databaseConnectionDialog_0.Boolean_0 && Class157.smethod_0(ref message))
			{
				Class157.smethod_3(this, ref message);
			}
			base.WndProc(ref message);
		}

		private void propertyGrid_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
		{
			this.method_2();
		}

		private void method_2()
		{
			if (this.propertyGrid.SelectedObject is IDataConnectionProperties)
			{
				try
				{
					this.textBox.Text = (this.propertyGrid.SelectedObject as IDataConnectionProperties).ToDisplayString();
				}
				catch
				{
					this.textBox.Text = null;
				}
			}
			else
			{
				this.textBox.Text = null;
			}
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			try
			{
				(this.propertyGrid.SelectedObject as IDataConnectionProperties).Parse(this.string_0);
			}
			catch
			{
			}
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
			this.icontainer_0 = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(DocumentServer.Data.ConnectionUI.DatabaseConnectionAdvancedDialog));
			this.propertyGrid = new DocumentServer.Data.ConnectionUI.DatabaseConnectionAdvancedDialog.Class152();
			this.textBox = new System.Windows.Forms.TextBox();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel1.SuspendLayout();
			base.SuspendLayout();
			componentResourceManager.ApplyResources(this.propertyGrid, "propertyGrid");
			this.tableLayoutPanel1.SetColumnSpan(this.propertyGrid, 3);
			this.propertyGrid.CommandsActiveLinkColor = System.Drawing.SystemColors.ActiveCaption;
			this.propertyGrid.CommandsDisabledLinkColor = System.Drawing.SystemColors.ControlDark;
			this.propertyGrid.CommandsLinkColor = System.Drawing.SystemColors.ActiveCaption;
			this.propertyGrid.Name = "propertyGrid";
			this.propertyGrid.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(propertyGrid_PropertyValueChanged);
			componentResourceManager.ApplyResources(this.textBox, "textBox");
			this.tableLayoutPanel1.SetColumnSpan(this.textBox, 13);
			this.textBox.Name = "textBox";
			this.textBox.ReadOnly = true;
			componentResourceManager.ApplyResources(this.okButton, "okButton");
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Name = "okButton";
			componentResourceManager.ApplyResources(this.cancelButton, "cancelButton");
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Click += new System.EventHandler(cancelButton_Click);
			componentResourceManager.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
			this.tableLayoutPanel1.Controls.Add(this.cancelButton, 2, 2);
			this.tableLayoutPanel1.Controls.Add(this.propertyGrid, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.okButton, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.textBox, 0, 1);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			base.AcceptButton = this.okButton;
			componentResourceManager.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.cancelButton;
			base.Controls.Add(this.tableLayoutPanel1);
			base.HelpButton = true;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "DatabaseConnectionAdvancedDialog";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
