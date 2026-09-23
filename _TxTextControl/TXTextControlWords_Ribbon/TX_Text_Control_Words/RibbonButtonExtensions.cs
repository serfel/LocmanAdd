using System;
using System.Drawing;
using TXTextControl.Windows.Forms;
using TXTextControl.Windows.Forms.Ribbon;

namespace TX_Text_Control_Words
{
	public static class RibbonButtonExtensions
	{
		[Flags]
		public enum RibbonButtonResource
		{
			LargeImageSource = 0x2,
			ToolTipTitle = 0x4,
			ToolTipDescription = 0x8,
			Label = 0x10,
			KeyTip = 0x20,
			SmallImageSource = 0x40,
			ToolTip = 0xC,
			ImageSources = 0x42,
			All = 0x7E
		}

		public static void Apply(this RibbonButton btn, string txitem, float dpi, RibbonButtonResource option = RibbonButtonResource.All)
		{
			if (option.HasFlag(RibbonButtonResource.SmallImageSource))
			{
				Bitmap smallIcon = ResourceProvider.GetSmallIcon(txitem, dpi);
				if (smallIcon != null)
				{
					btn.SmallIcon = smallIcon;
				}
				else
				{
					btn.SmallIcon = ResourceProvider.GetSmallIcon("dummy", dpi);
				}
			}
			if (option.HasFlag(RibbonButtonResource.LargeImageSource))
			{
				Bitmap largeIcon = ResourceProvider.GetLargeIcon(txitem, dpi);
				if (largeIcon != null)
				{
					btn.LargeIcon = largeIcon;
				}
				else
				{
					btn.LargeIcon = ResourceProvider.GetLargeIcon("dummy", dpi);
				}
			}
			if (option.HasFlag(RibbonButtonResource.ToolTipTitle))
			{
				string toolTipDescription = ResourceProvider.GetToolTipDescription(txitem);
				if (toolTipDescription != "")
				{
					btn.ToolTip.Description = toolTipDescription;
				}
			}
			if (option.HasFlag(RibbonButtonResource.ToolTipDescription))
			{
				string toolTipTitle = ResourceProvider.GetToolTipTitle(txitem);
				if (toolTipTitle != "")
				{
					btn.ToolTip.Title = toolTipTitle;
				}
			}
			if (option.HasFlag(RibbonButtonResource.Label))
			{
				string text = ResourceProvider.GetText(txitem);
				if (text != "")
				{
					btn.Text = text;
				}
			}
			if (option.HasFlag(RibbonButtonResource.KeyTip))
			{
				string keyTip = ResourceProvider.GetKeyTip(txitem);
				if (keyTip != "")
				{
					btn.KeyTip = keyTip;
				}
			}
		}
	}
}
