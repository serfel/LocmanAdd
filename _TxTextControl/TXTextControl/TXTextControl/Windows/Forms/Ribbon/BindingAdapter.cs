using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Threading;
using System.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TXTextControl.Windows.Forms.Ribbon
{
	internal abstract class BindingAdapter
	{
		internal enum Enum133
		{
			const_0,
			const_1,
			const_2,
			const_3
		}

		protected bool m_bTextControlChanged;

		protected TextControl m_txTextControl;

		internal ResourceManager m_rmResourceManager = new ResourceManager(typeof(TextControlCore));

		protected PointF m_pntDPI = PointF.Empty;

		protected int m_iDialogUnit = -1;

		private Color[] m_rcolColors = new Color[17]
		{
			ColorTranslator.FromHtml("#FFFFFF"),
			ColorTranslator.FromHtml("#C0C0C0"),
			ColorTranslator.FromHtml("#808080"),
			ColorTranslator.FromHtml("#404040"),
			ColorTranslator.FromHtml("#000000"),
			ColorTranslator.FromHtml("#0000FF"),
			ColorTranslator.FromHtml("#00FFFF"),
			ColorTranslator.FromHtml("#00FF00"),
			ColorTranslator.FromHtml("#FF00FF"),
			ColorTranslator.FromHtml("#FF0000"),
			ColorTranslator.FromHtml("#FFFF00"),
			ColorTranslator.FromHtml("#000080"),
			ColorTranslator.FromHtml("#008080"),
			ColorTranslator.FromHtml("#008000"),
			ColorTranslator.FromHtml("#800080"),
			ColorTranslator.FromHtml("#800000"),
			ColorTranslator.FromHtml("#808000")
		};

		internal abstract Class500 RibbonGroupManager { get; set; }

		internal TextControl TextControl
		{
			get
			{
				return this.m_txTextControl;
			}
			set
			{
				this.m_txTextControl = value;
			}
		}

		internal void SetRibbonGroupAppearance(Dictionary<string, object> groupItemsDictionary, RibbonGroup ribbonGroup, string fieldName, string eventName, string handler)
		{
			ribbonGroup.Name = fieldName;
			if (eventName != null && handler != null)
			{
				Class517.smethod_23(ribbonGroup.DialogBoxLauncher, eventName, handler, this);
			}
			else
			{
				ribbonGroup.DialogBoxLauncher.Visible = false;
			}
			ribbonGroup.Text = this.m_rmResourceManager.GetString(fieldName.Replace("TXITEM", "HEADER"));
			ribbonGroup.ToolTip.Title = ribbonGroup.Text;
			groupItemsDictionary.Add(ribbonGroup.Name, ribbonGroup);
		}

		protected void SetBasicRibbonItemAppearance(Dictionary<string, object> groupItemsDictionary, Control ribbonItem, bool hasImage)
		{
			groupItemsDictionary.Add(ribbonItem.Name, ribbonItem);
			IRibbonItem ribbonItem2 = ribbonItem as IRibbonItem;
			ribbonItem2.IsDefaultRibbonTabItem = true;
			if (!(ribbonItem is RibbonButton))
			{
				return;
			}
			((RibbonButton)ribbonItem).Text = this.m_rmResourceManager.GetString(ribbonItem.Name.Replace("TXITEM", "LABEL"));
			if (!hasImage)
			{
				return;
			}
			if (this.RibbonGroupManager.Control_0 is MiniToolbar)
			{
				if (((RibbonButton)ribbonItem).DisplayMode == IconTextRelation.LargeIconLabeled)
				{
					ribbonItem2.HasLargeIcon = true;
				}
				else if (((RibbonButton)ribbonItem).DisplayMode != IconTextRelation.NoIconLabeled)
				{
					ribbonItem2.HasSmallIcon = true;
				}
			}
			else
			{
				if (((RibbonButton)ribbonItem).DisplayMode == IconTextRelation.LargeIconLabeled)
				{
					ribbonItem2.HasLargeIcon = true;
				}
				ribbonItem2.HasSmallIcon = true;
			}
		}

		internal void SetBasicRibbonTextBoxAppearance(RibbonTextBox ribbonTextBox, bool hasImage, bool showDropDownButtons, RibbonTextBox.InputValidationMode validationMode)
		{
			string text = ribbonTextBox.Name.Replace("TXITEM", "");
			string @string = this.m_rmResourceManager.GetString("LABEL" + text);
			string textBoxLabel = "";
			switch (this.m_iDialogUnit)
			{
			case 0:
			{
				bool flag = true;
				try
				{
					RegionInfo regionInfo = new RegionInfo(Thread.CurrentThread.CurrentCulture.LCID);
					flag = regionInfo.IsMetric;
				}
				catch
				{
				}
				textBoxLabel = (flag ? this.m_rmResourceManager.GetString("LABEL" + text + "Metric") : this.m_rmResourceManager.GetString("LABEL" + text + "NonMetric"));
				break;
			}
			case 1:
				textBoxLabel = this.m_rmResourceManager.GetString("LABEL" + text + "Metric");
				break;
			case 2:
				textBoxLabel = this.m_rmResourceManager.GetString("LABEL" + text + "NonMetric");
				break;
			case 3:
				textBoxLabel = this.m_rmResourceManager.GetString("LABEL" + text + "MetricCentimeter");
				break;
			}
			ribbonTextBox.Label = @string;
			ribbonTextBox.TextBoxLabel = textBoxLabel;
			ribbonTextBox.ShowUpDownButtons = showDropDownButtons;
			ribbonTextBox.ValidationMode = validationMode;
			((IRibbonItem)ribbonTextBox).IsDefaultRibbonTabItem = true;
			if (hasImage)
			{
				if (ribbonTextBox.DisplayMode == IconTextRelation.LargeIconLabeled)
				{
					((IRibbonItem)ribbonTextBox).HasLargeIcon = true;
				}
				((IRibbonItem)ribbonTextBox).HasSmallIcon = true;
			}
		}

		protected void SetBasicRibbonLabelAppearance(RibbonLabel ribbonLabel, bool hasImage)
		{
			string name = ribbonLabel.Name.Replace("TXITEM", "LABEL");
			string text = (ribbonLabel.Text = this.m_rmResourceManager.GetString(name));
			((IRibbonItem)ribbonLabel).IsDefaultRibbonTabItem = true;
			((IRibbonItem)ribbonLabel).HasSmallIcon = hasImage;
		}

		protected void SetGalleryItemsImagesByID(RibbonListView gallery, PointF dpi, ImageProvider.ImageKind imagekind)
		{
			foreach (RibbonListView.RibbonListViewItem ribbonListViewItem in gallery.RibbonListViewItems)
			{
				ribbonListViewItem.Icon = Class517.smethod_55(size_0: imagekind switch
				{
					ImageProvider.ImageKind.Large_76x76 => Class517.smethod_48(new Size(76, 76), dpi), 
					ImageProvider.ImageKind.Large_32x32 => Class517.smethod_48(new Size(32, 32), dpi), 
					_ => Class517.smethod_48(new Size(16, 16), dpi), 
				}, string_2: ribbonListViewItem.String_0, imageKind_0: imagekind, pointF_1: dpi);
			}
		}

		protected void AddChartCategory(Dictionary<string, object> groupItemsDictionary, RibbonItemCollection dropDownItems, string label, string seperator, string gallery, RibbonInsertTab.ChartTemplate[] chartTypes)
		{
			if (seperator != null)
			{
				RibbonSeperator ribbonSeperator = new RibbonSeperator();
				ribbonSeperator.Name = seperator;
				RibbonSeperator ribbonSeperator2 = ribbonSeperator;
				((IRibbonItem)ribbonSeperator2).IsDefaultRibbonTabItem = true;
				dropDownItems.Add(ribbonSeperator2);
				groupItemsDictionary.Add(ribbonSeperator2.Name, ribbonSeperator2);
			}
			string oldValue = (label.StartsWith("TXITEM_InsertChart") ? "TXITEM_InsertChart" : "TXITEM_ChartType");
			RibbonLabel ribbonLabel = new RibbonLabel();
			ribbonLabel.Text = this.m_rmResourceManager.GetString(label.Replace(oldValue, "HEADER"));
			ribbonLabel.Name = label.ToString();
			RibbonLabel ribbonLabel2 = ribbonLabel;
			((IRibbonItem)ribbonLabel2).IsDefaultRibbonTabItem = true;
			dropDownItems.Add(ribbonLabel2);
			groupItemsDictionary.Add(ribbonLabel2.Name, ribbonLabel2);
			RibbonListView ribbonListView = new RibbonListView();
			ribbonListView.MinColumnCount = 7;
			ribbonListView.Name = gallery;
			RibbonListView ribbonListView2 = ribbonListView;
			((IRibbonItem)ribbonListView2).IsDefaultRibbonTabItem = true;
			foreach (RibbonInsertTab.ChartTemplate chartType in chartTypes)
			{
				ribbonListView2.RibbonListViewItems.Add(this.CreateChartGalleryItem(chartType));
			}
			groupItemsDictionary.Add(ribbonListView2.Name, ribbonListView2);
			ribbonListView2.ItemClick += ChartGallery_ItemClick;
			dropDownItems.Add(ribbonListView2);
		}

		private RibbonListView.RibbonListViewItem CreateChartGalleryItem(RibbonInsertTab.ChartTemplate chartType)
		{
			RibbonListView.RibbonListViewItem ribbonListViewItem = new RibbonListView.RibbonListViewItem();
			ribbonListViewItem.Tag = chartType;
			ribbonListViewItem.String_0 = "TXITEM_CHART_" + chartType;
			RibbonListView.RibbonListViewItem ribbonListViewItem2 = ribbonListViewItem;
			ribbonListViewItem2.ToolTip.Title = this.m_rmResourceManager.GetString("TOOLTIPTITLE_CHART_" + chartType);
			return ribbonListViewItem2;
		}

		protected virtual void ChartGallery_ItemClick(object sender, RibbonListView.RibbonListViewItemEventArgs e)
		{
		}

		internal virtual void UpdateRibbonTab(params object[] args)
		{
		}

		internal virtual void AwareOfDPI(PointF dpi)
		{
			if (this.m_pntDPI.X != dpi.X || this.m_pntDPI.Y != dpi.Y)
			{
				this.m_pntDPI = dpi;
				Class517.smethod_0(this.m_pntDPI);
				Class517.smethod_52(this.RibbonGroupManager.Control_0, this.m_pntDPI);
			}
		}

		internal virtual void AwareOfDPI_MiniToolbar(PointF dpi)
		{
			if (this.m_pntDPI.X != dpi.X || this.m_pntDPI.Y != dpi.Y)
			{
				this.m_pntDPI = dpi;
				Class517.smethod_0(this.m_pntDPI);
				Class517.smethod_52(this.RibbonGroupManager.Control_0, this.m_pntDPI);
			}
		}

		internal virtual bool SetDialogUnit()
		{
			int iDialogUnit = (int)((this.m_txTextControl != null) ? this.m_txTextControl.DialogUnit : DialogUnit.Auto);
			return this.m_iDialogUnit != (this.m_iDialogUnit = iDialogUnit);
		}

		internal virtual void SetRibbonItemAppearance(Dictionary<string, object> groupItemsDictionary, Control ribbonItem, string eventName, bool hasImage)
		{
		}

		internal virtual void OnDisconnectingTextControl()
		{
		}

		internal virtual void OnTextControlConnected()
		{
		}

		protected void Set_TXITEM_Color_DropDown(Dictionary<string, object> groupItemsDictionary, Control control, string firstItemName, string seperator1Name, string galleryName, string seperator2Name, string moreColorsName)
		{
			if (control is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control;
				ribbonMenuButton.DropDownOpening += ColorButton_DropDownOpening;
				RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(groupItemsDictionary, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: true, firstItemName, null, this);
				ribbonToggleButton.Checked = true;
				ribbonToggleButton.Click += DefaultColorButton_Click;
				RibbonSeperator ribbonSeperator = new RibbonSeperator();
				ribbonSeperator.Name = seperator1Name;
				RibbonSeperator ribbonSeperator2 = ribbonSeperator;
				((IRibbonItem)ribbonSeperator2).IsDefaultRibbonTabItem = true;
				groupItemsDictionary.Add(ribbonSeperator2.Name, ribbonSeperator2);
				RibbonListView ribbonListView = this.CreateColorGallery(groupItemsDictionary, galleryName);
				RibbonSeperator ribbonSeperator3 = new RibbonSeperator();
				ribbonSeperator3.Name = seperator2Name;
				RibbonSeperator ribbonSeperator4 = ribbonSeperator3;
				((IRibbonItem)ribbonSeperator4).IsDefaultRibbonTabItem = true;
				groupItemsDictionary.Add(ribbonSeperator4.Name, ribbonSeperator4);
				RibbonButton ribbonButton = Class517.smethod_26(groupItemsDictionary, Enum133.const_0, IconTextRelation.SmallIconLabeled, bool_0: true, moreColorsName, null, this);
				ribbonButton.Click += MoreColorsButton_Click;
				ribbonMenuButton.DropDownItems.AddRange(new Control[5] { ribbonToggleButton, ribbonSeperator2, ribbonListView, ribbonSeperator4, ribbonButton });
			}
		}

		private RibbonListView CreateColorGallery(Dictionary<string, object> groupItemsDictionary, string name)
		{
			RibbonListView ribbonListView = new RibbonListView();
			((IRibbonItem)ribbonListView).IsDefaultRibbonTabItem = true;
			ribbonListView.Name = name;
			ribbonListView.Deselectable = false;
			ribbonListView.MinColumnCount = 5;
			ribbonListView.CellPadding = new Padding(5);
			ribbonListView.ItemClick += ColorListView_ItemClick;
			groupItemsDictionary.Add(ribbonListView.Name, ribbonListView);
			return ribbonListView;
		}

		internal void SetColorGalleryItems(RibbonListView colorGallery, PointF dpi)
		{
			Size size = Class517.smethod_48(Class519.Class540.Size_0, dpi);
			int[] array = new int[15]
			{
				10, 7, 6, 8, 5, 9, 11, 12, 13, 14,
				15, 16, 2, 1, 4
			};
			colorGallery.RibbonListViewItems.Clear();
			int[] array2 = array;
			foreach (int num in array2)
			{
				Bitmap bitmap = new Bitmap(size.Width, size.Height);
				Graphics graphics = Graphics.FromImage(bitmap);
				Color color = this.m_rcolColors[num];
				graphics.Clear(color);
				graphics.Dispose();
				RibbonListView.RibbonListViewItem ribbonListViewItem = new RibbonListView.RibbonListViewItem();
				ribbonListViewItem.Icon = bitmap;
				ribbonListViewItem.Tag = color;
				RibbonListView.RibbonListViewItem ribbonListViewItem2 = ribbonListViewItem;
				ribbonListViewItem2.ToolTip.Title = this.GetColorName("TOOLTIPTITLE_", color);
				colorGallery.RibbonListViewItems.Add(ribbonListViewItem2);
			}
		}

		private void ColorButton_DropDownOpening(object sender, EventArgs e)
		{
			RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)sender;
			Color? currentColor = this.GetCurrentColor(ribbonMenuButton.Name);
			int num = ((!currentColor.HasValue || currentColor.Value.IsNamedColor) ? (-1) : Color.FromArgb(255, currentColor.Value).ToArgb());
			IEnumerator enumerator = ribbonMenuButton.DropDownItems.GetEnumerator();
			try
			{
				if (!enumerator.MoveNext())
				{
					return;
				}
				Control control = (Control)enumerator.Current;
				RibbonListView ribbonListView = control as RibbonListView;
				if (ribbonListView == null)
				{
					return;
				}
				if (num != -1)
				{
					foreach (RibbonListView.RibbonListViewItem ribbonListViewItem in ribbonListView.RibbonListViewItems)
					{
						if (((Color)ribbonListViewItem.Tag).ToArgb() == num)
						{
							ribbonListView.SelectedItems = new RibbonListView.RibbonListViewItem[1] { ribbonListViewItem };
							return;
						}
					}
				}
				ribbonListView.SelectedItems = new RibbonListView.RibbonListViewItem[0];
			}
			finally
			{
				IDisposable disposable = enumerator as IDisposable;
				if (disposable != null)
				{
					disposable.Dispose();
				}
			}
		}

		protected virtual void DefaultColorButton_Click(object sender, EventArgs e)
		{
		}

		protected virtual void ColorListView_ItemClick(object sender, RibbonListView.RibbonListViewItemEventArgs e)
		{
		}

		protected virtual void MoreColorsButton_Click(object sender, EventArgs e)
		{
		}

		protected virtual Color? GetCurrentColor(string colorButtonName)
		{
			return null;
		}

		private string GetColorName(string prefix, Color color)
		{
			return color.Name.ToUpper() switch
			{
				"FFFFFFFF" => this.m_rmResourceManager.GetString(prefix + "WHITE"), 
				"FFC0C0C0" => this.m_rmResourceManager.GetString(prefix + "LIGHTGRAY"), 
				"FF808080" => this.m_rmResourceManager.GetString(prefix + "GRAY"), 
				"FF404040" => this.m_rmResourceManager.GetString(prefix + "DARKGRAY"), 
				"FF000000" => this.m_rmResourceManager.GetString(prefix + "BLACK"), 
				"FF0000FF" => this.m_rmResourceManager.GetString(prefix + "BLUE"), 
				"FF00FFFF" => this.m_rmResourceManager.GetString(prefix + "AQUA"), 
				"FF00FF00" => this.m_rmResourceManager.GetString(prefix + "LIME"), 
				"FFFF00FF" => this.m_rmResourceManager.GetString(prefix + "FUCHSIA"), 
				"FFFF0000" => this.m_rmResourceManager.GetString(prefix + "RED"), 
				"FFFFFF00" => this.m_rmResourceManager.GetString(prefix + "YELLOW"), 
				"FF000080" => this.m_rmResourceManager.GetString(prefix + "NAVY"), 
				"FF008080" => this.m_rmResourceManager.GetString(prefix + "TEAL"), 
				"FF008000" => this.m_rmResourceManager.GetString(prefix + "GREEN"), 
				"FF800080" => this.m_rmResourceManager.GetString(prefix + "PURPLE"), 
				"FF800000" => this.m_rmResourceManager.GetString(prefix + "MAROON"), 
				"FF808000" => this.m_rmResourceManager.GetString(prefix + "OLIVE"), 
				_ => "", 
			};
		}

		protected void Set_TXITEM_LineWidth_DropDown(Dictionary<string, object> groupItemsDictionary, Control control)
		{
			if (control is RibbonMenuButton)
			{
				RibbonMenuButton ribbonMenuButton = (RibbonMenuButton)control;
				if (ribbonMenuButton.Name == RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_TextFrameLineWidth.ToString() || ribbonMenuButton.Name == RibbonFrameLayoutTab.InternalRibbonItem.TXITEM_DrawingLineWidth.ToString() || ribbonMenuButton.Name == RibbonPageLayoutTab.InternalRibbonItem.TXITEM_PageLineWidth.ToString())
				{
					RibbonToggleButton ribbonToggleButton = (RibbonToggleButton)Class517.smethod_26(groupItemsDictionary, Enum133.const_3, IconTextRelation.SmallIconLabeled, bool_0: false, ribbonMenuButton.Name + "_NoLine", null, this);
					ribbonToggleButton.Tag = new object[2] { 0, ribbonMenuButton.Name };
					ribbonToggleButton.Click += LineWidthItem_Click;
					RibbonSeperator ribbonSeperator = new RibbonSeperator();
					ribbonSeperator.Name = ribbonMenuButton.Name + "Seperator1";
					RibbonSeperator ribbonSeperator2 = ribbonSeperator;
					((IRibbonItem)ribbonSeperator2).IsDefaultRibbonTabItem = true;
					groupItemsDictionary.Add(ribbonSeperator2.Name, ribbonSeperator2);
					ribbonMenuButton.DropDownItems.AddRange(new Control[2] { ribbonToggleButton, ribbonSeperator2 });
				}
				this.AddLineWidthItem(groupItemsDictionary, ribbonMenuButton.DropDownItems, ribbonMenuButton.Name + "_25", ribbonMenuButton.Name);
				this.AddLineWidthItem(groupItemsDictionary, ribbonMenuButton.DropDownItems, ribbonMenuButton.Name + "_50", ribbonMenuButton.Name);
				this.AddLineWidthItem(groupItemsDictionary, ribbonMenuButton.DropDownItems, ribbonMenuButton.Name + "_75", ribbonMenuButton.Name);
				this.AddLineWidthItem(groupItemsDictionary, ribbonMenuButton.DropDownItems, ribbonMenuButton.Name + "_100", ribbonMenuButton.Name);
				this.AddLineWidthItem(groupItemsDictionary, ribbonMenuButton.DropDownItems, ribbonMenuButton.Name + "_150", ribbonMenuButton.Name);
				this.AddLineWidthItem(groupItemsDictionary, ribbonMenuButton.DropDownItems, ribbonMenuButton.Name + "_225", ribbonMenuButton.Name);
				this.AddLineWidthItem(groupItemsDictionary, ribbonMenuButton.DropDownItems, ribbonMenuButton.Name + "_300", ribbonMenuButton.Name);
				this.AddLineWidthItem(groupItemsDictionary, ribbonMenuButton.DropDownItems, ribbonMenuButton.Name + "_450", ribbonMenuButton.Name);
				this.AddLineWidthItem(groupItemsDictionary, ribbonMenuButton.DropDownItems, ribbonMenuButton.Name + "_600", ribbonMenuButton.Name);
			}
		}

		private void AddLineWidthItem(Dictionary<string, object> groupItemsDictionary, RibbonItemCollection dropDownItems, string buttonName, string parentName)
		{
			RibbonToggleButton ribbonToggleButton = new RibbonToggleButton();
			ribbonToggleButton.DisplayMode = IconTextRelation.SmallIconLabeled;
			RibbonToggleButton ribbonToggleButton2 = ribbonToggleButton;
			double num = Convert.ToDouble(buttonName.Substring(buttonName.LastIndexOf('_') + 1));
			int num2 = Convert.ToInt32(num / 100.0 * 20.0);
			ribbonToggleButton2.Tag = new object[2] { num2, parentName };
			ribbonToggleButton2.Text = ((double)num2 / 20.0).ToString((num2 % 10 == 0) ? "F1" : "F2");
			ribbonToggleButton2.Name = buttonName;
			((IRibbonItem)ribbonToggleButton2).IsDefaultRibbonTabItem = true;
			dropDownItems.Add(ribbonToggleButton2);
			groupItemsDictionary.Add(ribbonToggleButton2.Name, ribbonToggleButton2);
			ribbonToggleButton2.Click += LineWidthItem_Click;
		}

		protected void SetLineWidthItemsImages(RibbonMenuButton lineWidthItemMenuButton, PointF dpi)
		{
			foreach (Control dropDownItem in lineWidthItemMenuButton.DropDownItems)
			{
				if (dropDownItem is RibbonToggleButton && dropDownItem.Tag is object[])
				{
					object[] array = dropDownItem.Tag as object[];
					if (array.Length > 0 && array[0] is int && (int)array[0] != 0)
					{
						this.SetLineWidthItemImage(dropDownItem as RibbonToggleButton, dpi);
					}
				}
			}
		}

		protected virtual void LineWidthItem_Click(object sender, EventArgs e)
		{
		}

		private void SetLineWidthItemImage(RibbonToggleButton rtbtnLineSpaceItem, PointF dpi)
		{
			Size size = Class517.smethod_48(Class519.Class521.Size_1, dpi);
			Bitmap bitmap = new Bitmap(size.Width, size.Height);
			Graphics graphics = Graphics.FromImage(bitmap);
			int num = (int)(rtbtnLineSpaceItem.Tag as object[])[0];
			float width = (float)num / 20f * graphics.DpiX / 72f;
			graphics.DrawLine(new Pen(new SolidBrush(Color.Black), width), new Point(0, bitmap.Height / 2), new Point(bitmap.Width, bitmap.Height / 2));
			graphics.Dispose();
			rtbtnLineSpaceItem.SmallIcon = bitmap;
		}
	}
}
