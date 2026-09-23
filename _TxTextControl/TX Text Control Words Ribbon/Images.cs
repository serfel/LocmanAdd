/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TX_Text_Control_Words.Properties;
using System.Windows.Forms;

namespace TX_Text_Control_Words {

	/*----------------------------------------------------------------------------------------------------------
	** Provides functionalities for managing icons.
	**--------------------------------------------------------------------------------------------------------*/
	public static class Images {

		/*----------------------------------------------------------------------------------------------------------
		** P U B L I C   M E T H O D S
		**--------------------------------------------------------------------------------------------------------*/

		/*----------------------------------------------------------------------------------------------------------
		** GetSmallIcon method
		** Extracts an small image from the embedded resources by image's name and the system's default size for icons.
		** The images are stored by the image's size in measurement pixels in the "Small"- projectfolder.
		** Supported sizes: 16px, 24px, 32px, 64px
		**--------------------------------------------------------------------------------------------------------*/
		public static Bitmap GetSmallIcon(string imageName) {
			return GetIcon("Small." + imageName, SystemInformation.SmallIconSize);
		}

		/*----------------------------------------------------------------------------------------------------------
		** GetLargeIcon method
		** Extracts an large image from the embedded resources by image's name and the system's default size for icons.
		** The images are stored by the image's size in measurement pixels in the "Large"- projectfolder.
		** Supported sizes: 16px, 24px, 32px, 64px
		**--------------------------------------------------------------------------------------------------------*/
		public static Bitmap GetLargeIcon(string imageName) {
			return GetIcon("Large." + imageName, SystemInformation.IconSize);
		}

		/*----------------------------------------------------------------------------------------------------------
		** H E L P E R   M E T H O D S
		**--------------------------------------------------------------------------------------------------------*/

		/*----------------------------------------------------------------------------------------------------------
		** GetIcon method
		** Extracts an image from the embedded resources by image's name.
		** The images are stored by the image's size in measurement pixels.
		** Supported sizes: 16px, 24px, 32px, 64px
		**--------------------------------------------------------------------------------------------------------*/
		private static Bitmap GetIcon(string imageName, Size defaultIconSize) {

			Bitmap result = null;
			var defaultIconWidth = defaultIconSize.Width;
			var iconSizes = new[] { 16, 24, 32, 64 };  // Supported sizes of icons

			// Get image - Prefer the image with the next larger size.
			foreach (var iconSize in iconSizes.OrderByDescending(x => x)) { // Order ascending

				var resName = String.Format("TX_Text_Control_Words.Images._{0}.{1}.png", iconSize, imageName);

				if (HasEmbeddedImage(resName)) {

					if (defaultIconWidth <= iconSize) {
						// A larger image is found which is nearer as the previous found image.
						result = GetEmbeddedImage(resName);
					}
					else if(result == null) {
						// No larger image found. Get the next smaller image.
						result = GetEmbeddedImage(resName);
						break;
					}
				}
			}

			return result;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** GetEmbeddedImage method
		** Extracts the icon from the embedded resources.
		** Returns null if no icon is available.
		**-----------------------------------------------------------------------------------------------------------*/
		private static Bitmap GetEmbeddedImage(string path) {

			Assembly myAssembly = Assembly.GetExecutingAssembly();
			Bitmap embeddedImage = null;

			if (myAssembly.GetManifestResourceNames().Contains(path)) {
				Stream myStream = myAssembly.GetManifestResourceStream(path);
				embeddedImage = new Bitmap(myStream);
			}

			return embeddedImage;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** HasEmbeddedImage method
		** Checks whether an resource exist with the name.
		**-----------------------------------------------------------------------------------------------------------*/
		private static bool HasEmbeddedImage(string path) {
			return Assembly.GetExecutingAssembly().GetManifestResourceNames().Contains(path);
		}

	}
}
