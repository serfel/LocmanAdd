using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;

namespace tx_help_center_2014
{
	public static class RssManager
	{
		public static List<RssFeedItem> ReadFeed(string url)
		{
			List<RssFeedItem> list = new List<RssFeedItem>();
			XmlReader xmlReader = XmlReader.Create(url);
			SyndicationFeed syndicationFeed = SyndicationFeed.Load(xmlReader);
			xmlReader.Close();
			foreach (SyndicationItem item in syndicationFeed.Items)
			{
				list.Add(new RssFeedItem
				{
					Title = item.Title.Text,
					Description = item.Summary.Text,
					PublishDate = item.PublishDate.UtcDateTime,
					Link = item.Links[0].Uri.ToString()
				});
				if (list.Count == 6)
				{
					return list;
				}
			}
			return list;
		}
	}
}
