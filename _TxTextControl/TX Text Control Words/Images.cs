/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of 
**						TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace TX_Text_Control_Words
{

	/*----------------------------------------------------------------------------------------------------------
	** Provides functionalities for managing icons.
	**--------------------------------------------------------------------------------------------------------*/
	static class Images {

		/*-------------------------------------------------------------------------------------------------------------
		**  P U B L I C   M E T H O D S
		**-----------------------------------------------------------------------------------------------------------*/

		/*----------------------------------------------------------------------------------------------------------
		** GetIcon method
		** Extracts an image from the embedded resources by image's name.
		** The images are stored by the image's size in measurement pixels.
		** Supported sizes: 16px, 24px, 32px, 64px
		**--------------------------------------------------------------------------------------------------------*/
		public static Bitmap GetIcon(string imageName) {

			Bitmap result = null;
			var defaultIconWidth = SystemInformation.SmallIconSize.Width;
			var iconSizes = new[] { 16, 24, 32, 64 }; // Supported sizes of icons

			// Get image - Prefer the image with the next smaller or equal size.
			foreach (var iconSize in iconSizes.OrderBy(x => x)) {

				var resName = String.Format("TX_Text_Control_Words.Images._{0}.{1}.png", iconSize, imageName);

				if (HasEmbeddedImage(resName)) {

					if (iconSize <= defaultIconWidth) {
						// A smaller image is found which is nearer as the previous found image.
						result = GetEmbeddedImage(resName);
					}
					else if (result == null) {
						// No smaller image found. Get the next larger image.
						result = GetEmbeddedImage(resName);
						break;
					}
				}

			}

			return result;
		}

		/*-------------------------------------------------------------------------------------------------------------
		** H E L P E R   M E T H O D S
		**-----------------------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------------
		** GetEmbeddedImage method
		** Extracts the icon from the embedded resources.
		** Returns null if no icon is available.
		**-----------------------------------------------------------------------------------------------------------*/
		private static Bitmap GetEmbeddedImage(string resName) {

			Assembly myAssembly = Assembly.GetExecutingAssembly();
			Bitmap embeddedImage = null;

			if (myAssembly.GetManifestResourceNames().Contains(resName)) {
				Stream myStream = myAssembly.GetManifestResourceStream(resName);
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
