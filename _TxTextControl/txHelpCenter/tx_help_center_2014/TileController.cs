using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using tx_help_center_2014.Classes;

namespace tx_help_center_2014
{
	public class TileController
	{
		public FlowLayoutPanel FlowPanel;

		public TileGroup Tiles;

		private List<TileControl> TilesStart;

		private List<TileControl> TilesTutorial;

		private List<TileControl> TilesStarted;

		private List<TileControl> TilesLicenses;

		private List<TileControl> TilesAdditionalProducts;

		private List<TileControl> TilesDocumentation;

		private List<TileControl> TilesInstalledProducts;

		private List<TileControl> TilesSamples;

		private List<TileControl> TilesBlog;

		public int iCurrentIndex;

		public PictureBox BackButton;

		public PictureBox ScreenshotBox;

		public PictureBox ShadowBox;

		public Label MainTitle;

		public Label TileTitle;

		public ComboBox cbxSearch;

		public TextControlInformation txinfo = new TextControlInformation();

		public TileController(FlowLayoutPanel FlowPanel, PictureBox BackButton, PictureBox ScreenshotBox, PictureBox ShadowBox, Label MainTitle, Label TileTitle)
		{
			this.FlowPanel = FlowPanel;
			this.BackButton = BackButton;
			this.ScreenshotBox = ScreenshotBox;
			this.ShadowBox = ShadowBox;
			this.MainTitle = MainTitle;
			this.TileTitle = TileTitle;
			this.MainTitle.Text = "";
			if (this.txinfo.IsTextControlAvailable)
			{
				this.MainTitle.Text = "TX Text Control .NET, ";
			}
			if (this.txinfo.IsSpellAvailable)
			{
				this.MainTitle.Text += "TX Spell .NET, ";
			}
			if (this.txinfo.IsBarcodeAvailable)
			{
				this.MainTitle.Text += "TX Barcode .NET, ";
			}
			this.MainTitle.Text = this.MainTitle.Text.Trim().TrimEnd(',');
			if (!this.txinfo.IsTextControlAvailable & !this.txinfo.IsSpellAvailable & !this.txinfo.IsBarcodeAvailable)
			{
				this.MainTitle.Text = "No Text Control products found";
			}
			this.TilesStart = new List<TileControl>
			{
				new TileControl("Getting Started", "Learn how to create your first applications", "tx_help_center_2014.ImgResources.icon_gettingstarted.png", this, 1, "tx_help_center_2014.ImgResources.screenshot_main.png", TileControl.TileSize.Normal, null, Active: true),
				new TileControl("Known Issues", "See known issues and download service packs", "tx_help_center_2014.ImgResources.icon_updates.png", this, 0, "tx_help_center_2014.ImgResources.screenshot_sps.png", TileControl.TileSize.Normal, new TileControl.TileAction(TileControl.TileAction.ActionValue.WebLink, "https://www.textcontrol.com/support/issues/"), Active: true),
				new TileControl("Support Center", "Find solutions or create a support ticket", "tx_help_center_2014.ImgResources.icon_support.png", this, 0, "tx_help_center_2014.ImgResources.screenshot_support.png", TileControl.TileSize.Normal, new TileControl.TileAction(TileControl.TileAction.ActionValue.WebLink, "http://support.textcontrol.com/"), Active: true),
				new TileControl("Read the Blog", "Insider news and tips and tricks", "tx_help_center_2014.ImgResources.icon_blog.png", this, 8, "tx_help_center_2014.ImgResources.screenshot_blog.png", TileControl.TileSize.Normal, new TileControl.TileAction(TileControl.TileAction.ActionValue.WebLink, "https://www.textcontrol.com/blog/"), Active: true),
				new TileControl("Installed Products", "Information about your products", "tx_help_center_2014.ImgResources.icon_key.png", this, 3, "", TileControl.TileSize.Normal, null, Active: true),
				new TileControl("Reference", "Open the documentation", "tx_help_center_2014.ImgResources.icon_documentation.png", this, 5, "tx_help_center_2014.ImgResources.screenshot_documentation.png", TileControl.TileSize.Normal, null, Active: true)
			};
			this.TilesStarted = new List<TileControl>
			{
				new TileControl("Up", "", "tx_help_center_2014.ImgResources.icon_up.png", this, 0, "", TileControl.TileSize.Small, null, Active: true),
				new TileControl("Getting Started Tutorials", "Create your first Text Control applications", "tx_help_center_2014.ImgResources.icon_gettingstarted.png", this, 2, "tx_help_center_2014.ImgResources.screenshot_main.png", TileControl.TileSize.Large, null, Active: true),
				new TileControl("Sample Projects", "Open the location of the shipped samples", "tx_help_center_2014.ImgResources.icon_folder.png", this, 7, "tx_help_center_2014.ImgResources.screenshot_samples.png", TileControl.TileSize.Normal, null, Active: true),
				new TileControl("GitHub", "Get sample projects from our GitHub repository", "tx_help_center_2014.ImgResources.github.png", this, 1, "tx_help_center_2014.ImgResources.screenshot_github.png", TileControl.TileSize.Normal, new TileControl.TileAction(TileControl.TileAction.ActionValue.WebLink, "http://www.github.com/textcontrol"), Active: true)
			};
			if (this.txinfo.IsTextControlAvailable)
			{
				this.TilesStarted.Add(new TileControl("What's New", "Read what's new in TX Text Control", "tx_help_center_2014.ImgResources.icon_check.png", this, 1, "tx_help_center_2014.ImgResources.screenshot_whatsnew.png", TileControl.TileSize.Normal, new TileControl.TileAction(TileControl.TileAction.ActionValue.WebLink, "https://www.textcontrol.com/products/asp-dotnet/tx-text-control-dotnet-server/whats-new/"), Active: true));
			}
			if (this.txinfo.IsTextControlServerAvailable)
			{
				this.TilesStarted.Add(new TileControl("Pre-compiled Demo", "Start the Windows Forms demo application", "tx_help_center_2014.ImgResources.icon_window.png", this, 1, "tx_help_center_2014.ImgResources.screenshot_txwords.png", TileControl.TileSize.Normal, new TileControl.TileAction(TileControl.TileAction.ActionValue.Path, this.txinfo.GetProductDemoPath("TX Text Control 29.0.NET Server for ASP.NET")), Active: true));
			}
			else if (this.txinfo.IsTextControlWindowsFormsAvailable)
			{
				this.TilesStarted.Add(new TileControl("Pre-compiled Demo", "Start the Windows Forms demo application", "tx_help_center_2014.ImgResources.icon_window.png", this, 1, "tx_help_center_2014.ImgResources.screenshot_txwords.png", TileControl.TileSize.Normal, new TileControl.TileAction(TileControl.TileAction.ActionValue.Path, this.txinfo.GetProductDemoPath("TX Text Control 29.0.NET for Windows Forms")), Active: true));
			}
			if (this.txinfo.IsTextControlWPFAvailable)
			{
				this.TilesStarted.Add(new TileControl("Pre-compiled Demo", "Start the WPF demo application", "tx_help_center_2014.ImgResources.icon_window.png", this, 1, "tx_help_center_2014.ImgResources.screenshot_txwords.png", TileControl.TileSize.Normal, new TileControl.TileAction(TileControl.TileAction.ActionValue.Path, this.txinfo.GetProductDemoPath("TX Text Control 29.0.NET for WPF")), Active: true));
			}
			this.TilesTutorial = new List<TileControl>();
			this.TilesTutorial.Add(new TileControl("Up", "", "tx_help_center_2014.ImgResources.icon_up.png", this, 1, "", TileControl.TileSize.Small, null, Active: true));
			if (this.txinfo.IsTextControlAvailable)
			{
				this.TilesTutorial.Add(new TileControl("Reporting Tutorial", "Create your first reporting application", "tx_help_center_2014.ImgResources.icon_reporting.png", this, 2, "tx_help_center_2014.ImgResources.screenshot_reporting.png", TileControl.TileSize.Normal, new TileControl.TileAction(TileControl.TileAction.ActionValue.WebLink, "http://www.textcontrol.com/gettingstarted_reporting"), Active: true));
				this.TilesTutorial.Add(new TileControl("HTML5 Tutorial", "Create an ASP.NET Web template designer", "tx_help_center_2014.ImgResources.icon_html5.png", this, 2, "tx_help_center_2014.ImgResources.screenshot_html5.png", TileControl.TileSize.Normal, new TileControl.TileAction(TileControl.TileAction.ActionValue.WebLink, "http://www.textcontrol.com/gettingstarted_html5"), Active: true));
			}
			if (this.txinfo.IsTextControlWPFAvailable)
			{
				this.TilesTutorial.Add(new TileControl("Rich Text Editor", "Create your first WPF application", "tx_help_center_2014.ImgResources.icon_vs.png", this, 2, "tx_help_center_2014.ImgResources.screenshot_richtext.png", TileControl.TileSize.Normal, new TileControl.TileAction(TileControl.TileAction.ActionValue.WebLink, "http://www.textcontrol.com/gettingstarted_richtextwpf"), Active: true));
				if (this.txinfo.IsSpellCheckingWPFAvailable)
				{
					this.TilesTutorial.Add(new TileControl("Spell", "checking in WPF", "", this, 2, "tx_help_center_2014.ImgResources.screenshot_spell.png", TileControl.TileSize.Small, new TileControl.TileAction(TileControl.TileAction.ActionValue.WebLink, "http://www.textcontrol.com/gettingstarted_spellwpf"), Active: true));
				}
			}
			if (this.txinfo.IsTextControlWindowsFormsAvailable)
			{
				this.TilesTutorial.Add(new TileControl("Rich Text Editor", "Create your first Windows Forms application", "tx_help_center_2014.ImgResources.icon_vs.png", this, 2, "tx_help_center_2014.ImgResources.screenshot_richtext.png", TileControl.TileSize.Normal, new TileControl.TileAction(TileControl.TileAction.ActionValue.WebLink, "http://www.textcontrol.com/gettingstarted_richtextwf"), Active: true));
				if (this.txinfo.IsSpellCheckingWindowsFormsAvailable)
				{
					this.TilesTutorial.Add(new TileControl("Spell", "checking in Windows Forms", "", this, 2, "tx_help_center_2014.ImgResources.screenshot_spell.png", TileControl.TileSize.Small, new TileControl.TileAction(TileControl.TileAction.ActionValue.WebLink, "http://www.textcontrol.com/gettingstarted_spellwf"), Active: true));
				}
			}
			if (this.TilesTutorial.Count > 1)
			{
				this.TilesTutorial[1].TileControlSize = TileControl.TileSize.Large;
			}
			this.TilesLicenses = new List<TileControl>
			{
				new TileControl("Up", "", "tx_help_center_2014.ImgResources.icon_up.png", this, 0, "", TileControl.TileSize.Small, null, Active: true),
				new TileControl("Installed Products", "Display product information about installed products", "tx_help_center_2014.ImgResources.icon_key.png", this, 6, "", TileControl.TileSize.Normal, null, Active: true),
				new TileControl("Additional Products", "Get information about additional products", "tx_help_center_2014.ImgResources.icon_shopping.png", this, 4, "", TileControl.TileSize.Normal, null, Active: true)
			};
			if (this.TilesLicenses[1] != null)
			{
				this.TilesLicenses[1].TileControlSize = TileControl.TileSize.Large;
			}
			this.TilesAdditionalProducts = new List<TileControl>();
			this.TilesAdditionalProducts.Add(new TileControl("Up", "", "tx_help_center_2014.ImgResources.icon_up.png", this, 3, "", TileControl.TileSize.Small, null, Active: true));
			if (!this.txinfo.IsSpellCheckingWindowsFormsAvailable && this.txinfo.IsTextControlWindowsFormsAvailable)
			{
				this.TilesAdditionalProducts.Add(new TileControl("TX Spell .NET", "Add spell checking to your Windows Forms applications", "tx_help_center_2014.ImgResources.icon_shopping.png", this, 4, "", TileControl.TileSize.Normal, new TileControl.TileAction(TileControl.TileAction.ActionValue.WebLink, "https://www.textcontrol.com/products/windows-forms/tx-spell-dotnet/overview/"), Active: true));
			}
			if (!this.txinfo.IsSpellCheckingWPFAvailable && this.txinfo.IsTextControlWPFAvailable)
			{
				this.TilesAdditionalProducts.Add(new TileControl("TX Spell .NET", "Add spell checking to your WPF applications", "tx_help_center_2014.ImgResources.icon_shopping.png", this, 4, "", TileControl.TileSize.Normal, new TileControl.TileAction(TileControl.TileAction.ActionValue.WebLink, "https://www.textcontrol.com/products/wpf/tx-spell-dotnet/overview/"), Active: true));
			}
			if (!this.txinfo.IsBarcodeWindowsFormsAvailable && this.txinfo.IsTextControlWindowsFormsAvailable)
			{
				this.TilesAdditionalProducts.Add(new TileControl("TX Barcode .NET", "Add 1D and 2D barcodes to your Windows Forms applications", "tx_help_center_2014.ImgResources.icon_shopping.png", this, 4, "", TileControl.TileSize.Normal, new TileControl.TileAction(TileControl.TileAction.ActionValue.WebLink, "https://www.textcontrol.com/products/windows-forms/tx-barcode-dotnet/overview/"), Active: true));
			}
			if (!this.txinfo.IsBarcodeWPFAvailable && this.txinfo.IsTextControlWPFAvailable)
			{
				this.TilesAdditionalProducts.Add(new TileControl("TX Barcode .NET", "Add 1D and 2D barcodes to your WPF applications", "tx_help_center_2014.ImgResources.icon_shopping.png", this, 4, "", TileControl.TileSize.Normal, new TileControl.TileAction(TileControl.TileAction.ActionValue.WebLink, "https://www.textcontrol.com/products/wpf/tx-barcode-dotnet/overview/"), Active: true));
			}
			if (this.TilesAdditionalProducts.Count > 1)
			{
				this.TilesAdditionalProducts[1].TileControlSize = TileControl.TileSize.Large;
			}
			this.TilesDocumentation = new List<TileControl>();
			this.TilesDocumentation.Add(new TileControl("Up", "", "tx_help_center_2014.ImgResources.icon_up.png", this, 0, "", TileControl.TileSize.Small, null, Active: true));
			this.TilesDocumentation.Add(new TileControl("TX Text Control Help", "Open the online documentation", "tx_help_center_2014.ImgResources.icon_documentation.png", this, 5, "", TileControl.TileSize.Normal, new TileControl.TileAction(TileControl.TileAction.ActionValue.WebLink, "https://www.textcontrol.com/documentation"), Active: true));
			if (this.txinfo.IsBarcodeWindowsFormsAvailable)
			{
				this.TilesDocumentation.Add(new TileControl("TX Barcode Help", "Open the online documentation", "tx_help_center_2014.ImgResources.icon_documentation.png", this, 5, "", TileControl.TileSize.Normal, new TileControl.TileAction(TileControl.TileAction.ActionValue.WebLink, "https://www.textcontrol.com/documentation/?param=index.htm&product=bc#"), Active: true));
			}
			if (this.txinfo.IsBarcodeWPFAvailable && !this.txinfo.IsBarcodeWindowsFormsAvailable)
			{
				this.TilesDocumentation.Add(new TileControl("TX Barcode Help", "Open the online documentation", "tx_help_center_2014.ImgResources.icon_documentation.png", this, 5, "", TileControl.TileSize.Normal, new TileControl.TileAction(TileControl.TileAction.ActionValue.WebLink, "https://www.textcontrol.com/documentation/?param=index.htm&product=bc#"), Active: true));
			}
			if (this.txinfo.IsSpellCheckingWindowsFormsAvailable)
			{
				this.TilesDocumentation.Add(new TileControl("TX Spell Help", "Open the online documentation", "tx_help_center_2014.ImgResources.icon_documentation.png", this, 5, "", TileControl.TileSize.Normal, new TileControl.TileAction(TileControl.TileAction.ActionValue.WebLink, "https://www.textcontrol.com/documentation/?param=index.htm&product=sp#"), Active: true));
			}
			if (this.txinfo.IsSpellCheckingWPFAvailable)
			{
				this.TilesDocumentation.Add(new TileControl("TX Spell Help", "Open the online documentation", "tx_help_center_2014.ImgResources.icon_documentation.png", this, 5, "", TileControl.TileSize.Normal, new TileControl.TileAction(TileControl.TileAction.ActionValue.WebLink, "https://www.textcontrol.com/documentation/?param=index.htm&product=sp#"), Active: true));
			}
			if (this.TilesDocumentation.Count > 2 && this.TilesDocumentation[1] != null)
			{
				this.TilesDocumentation[1].TileControlSize = TileControl.TileSize.Large;
			}
			this.TilesInstalledProducts = new List<TileControl>();
			this.TilesInstalledProducts.Add(new TileControl("Up", "", "tx_help_center_2014.ImgResources.icon_up.png", this, 3, "", TileControl.TileSize.Small, null, Active: true));
			foreach (TextControlInformation.TextControlProduct product in this.txinfo.Products)
			{
				this.TilesInstalledProducts.Add(new TileControl(product.ProductName, "for " + product.Technology + " " + product.VersionDisplayName, "tx_help_center_2014.ImgResources.icon_check.png", this, 6, "", TileControl.TileSize.Normal, null, Active: false));
			}
			if (this.TilesDocumentation.Count > 2 && this.TilesInstalledProducts[1] != null)
			{
				this.TilesInstalledProducts[1].TileControlSize = TileControl.TileSize.Large;
			}
			this.TilesSamples = new List<TileControl>();
			this.TilesSamples.Add(new TileControl("Up", "", "tx_help_center_2014.ImgResources.icon_up.png", this, 1, "", TileControl.TileSize.Small, null, Active: true));
			foreach (TextControlInformation.TextControlProduct product2 in this.txinfo.Products)
			{
				this.TilesSamples.Add(new TileControl(product2.ProductName, "for " + product2.Technology + " " + product2.VersionDisplayName, "tx_help_center_2014.ImgResources.icon_vs.png", this, 7, "", TileControl.TileSize.Normal, new TileControl.TileAction(TileControl.TileAction.ActionValue.Path, this.txinfo.GetProductSamplesPath(product2.ProductString)), Active: true));
			}
			if (this.TilesDocumentation.Count > 2 && this.TilesSamples[1] != null)
			{
				this.TilesSamples[1].TileControlSize = TileControl.TileSize.Large;
			}
			this.TilesBlog = new List<TileControl>();
			this.Tiles = new TileGroup();
			this.Tiles.Tiles.Add(this.TilesStart);
			this.Tiles.Tiles.Add(this.TilesStarted);
			this.Tiles.Tiles.Add(this.TilesTutorial);
			this.Tiles.Tiles.Add(this.TilesLicenses);
			this.Tiles.Tiles.Add(this.TilesAdditionalProducts);
			this.Tiles.Tiles.Add(this.TilesDocumentation);
			this.Tiles.Tiles.Add(this.TilesInstalledProducts);
			this.Tiles.Tiles.Add(this.TilesSamples);
			this.Tiles.Tiles.Add(this.TilesBlog);
			Control.ControlCollection controls = this.FlowPanel.Controls;
			Control[] controls2 = this.Tiles.Tiles[0].ToArray();
			controls.AddRange(controls2);
		}

		public void SwitchTileGroup(int Index)
		{
			this.FlowPanel.Width = 580;
			if (this.iCurrentIndex == Index)
			{
				return;
			}
			Effects.Animate(this.FlowPanel, Effects.Effect.Slide, 150, 30);
			this.FlowPanel.Controls.Clear();
			switch (Index)
			{
			case 1:
				this.TileTitle.Text = "Getting Started";
				break;
			case 2:
				this.TileTitle.Text = "Text Control Tutorials";
				break;
			case 3:
				this.TileTitle.Text = "Installed and Additional Products";
				break;
			case 4:
				this.TileTitle.Text = "Additional Products from Text Control";
				this.FlowPanel.Width = 1013;
				break;
			case 5:
				this.TileTitle.Text = "Open Product Documentation";
				this.FlowPanel.Width = 1013;
				break;
			case 6:
				this.TileTitle.Text = "Installed Text Control Products";
				this.FlowPanel.Width = 1013;
				break;
			case 7:
				this.TileTitle.Text = "Open Sample Application Locations";
				break;
			case 8:
				if (this.TilesBlog.Count == 0)
				{
					this.TilesBlog.Clear();
					this.TilesBlog.Add(new TileControl("Up", "", "tx_help_center_2014.ImgResources.icon_up.png", this, 0, "", TileControl.TileSize.Small, null, Active: true));
					try
					{
						foreach (RssFeedItem item in RssManager.ReadFeed("https://www.textcontrol.com/feeds/blog/"))
						{
							this.TilesBlog.Add(new TileControl(item.Title, item.PublishDate.ToString("MMMM dd") + " - " + item.Description, "tx_help_center_2014.ImgResources.icon_blog.png", this, 8, "", TileControl.TileSize.Large, new TileControl.TileAction(TileControl.TileAction.ActionValue.WebLink, item.Link), Active: true));
						}
						if (this.TilesBlog[2] != null)
						{
							this.TilesBlog[2].TileControlSize = TileControl.TileSize.Normal;
						}
					}
					catch (Exception)
					{
					}
				}
				this.FlowPanel.Width = 1013;
				this.TileTitle.Text = "Text Control Blog";
				break;
			default:
				this.TileTitle.Text = "What do you want to do next?";
				break;
			}
			Control.ControlCollection controls = this.FlowPanel.Controls;
			Control[] controls2 = this.Tiles.Tiles[Index].ToArray();
			controls.AddRange(controls2);
			Effects.Animate(this.FlowPanel, Effects.Effect.Slide, 150, 30);
			this.iCurrentIndex = Index;
			if (this.iCurrentIndex == 0)
			{
				Bitmap image = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("tx_help_center_2014.ImgResources.back_gray.png"));
				this.BackButton.Image = image;
				this.BackButton.Enabled = false;
			}
			else
			{
				Bitmap image2 = new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream("tx_help_center_2014.ImgResources.back.png"));
				this.BackButton.Image = image2;
				this.BackButton.Enabled = true;
			}
		}

		public void SwitchTileGroup()
		{
			this.SwitchTileGroup(0);
		}
	}
}
