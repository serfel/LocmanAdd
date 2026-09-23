using System;
using System.ComponentModel;
using System.Drawing;
using System.Resources;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ns21;
using ns27;
using TXTextControl;

namespace ns26
{
	internal class EditEmbeddedFileDialog : Form
	{
		internal class Class578
		{
			private string[] string_0;

			internal string String_0 => this.string_0[0];

			internal string String_1 => this.string_0[1];

			internal Class578(string[] string_1)
			{
				this.string_0 = string_1;
			}

			public override string ToString()
			{
				return this.String_0 + " (" + this.String_1 + ")";
			}
		}

		private uint uint_0;

		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		private IContainer icontainer_0;

		private TableLayoutPanel tableLayoutPanel1;

		private Label m_lblFileName;

		private Label m_lblFile;

		private Label m_lblDescription;

		private TextBox m_tbxDescription;

		private Label m_lblRelationship;

		private ComboBox m_cmbxRelationship;

		private Label m_lblMimeType;

		private ComboBox m_cmbxMimeType;

		private System.Windows.Forms.Button m_btnOK;

		private System.Windows.Forms.Button m_btnCancel;

		internal string String_0 => this.m_tbxDescription.Text;

		internal string String_1 => this.m_cmbxRelationship.Text;

		internal string String_2
		{
			get
			{
				if (this.m_cmbxMimeType.SelectedIndex != -1)
				{
					return (this.m_cmbxMimeType.SelectedItem as Class578).String_1;
				}
				return this.m_cmbxMimeType.Text;
			}
		}

		public EditEmbeddedFileDialog(EmbeddedFile embeddedFile_0)
		{
			this.InitializeComponent();
			this.Text = this.resourceManager_0.GetString("ID_EDITEMBEDDEDFILE_CAPTION");
			this.m_lblFileName.Text = this.resourceManager_0.GetString("ID_EDITEMBEDDEDFILE_FILE_NAME");
			this.m_lblDescription.Text = this.resourceManager_0.GetString("ID_EDITEMBEDDEDFILE_DESCRIPTION");
			this.m_lblRelationship.Text = this.resourceManager_0.GetString("ID_EDITEMBEDDEDFILE_RELATIONSHIP");
			this.m_lblMimeType.Text = this.resourceManager_0.GetString("ID_EDITEMBEDDEDFILE_MIME_TYPE");
			this.m_btnOK.Text = this.resourceManager_0.GetString("ID_EDITEMBEDDEDFILE_OK");
			this.m_btnCancel.Text = this.resourceManager_0.GetString("ID_EDITEMBEDDEDFILE_CANCEL");
			this.method_1();
			this.m_lblFile.Text = embeddedFile_0.FileName;
			this.m_tbxDescription.Text = embeddedFile_0.Description;
			this.m_cmbxRelationship.Text = embeddedFile_0.Relationship;
			this.method_2(embeddedFile_0);
		}

		private void method_0(string string_0, string string_1)
		{
			this.m_cmbxMimeType.Items.Add(new Class578(new string[2] { string_0, string_1 }));
		}

		private void method_1()
		{
			this.method_0(this.resourceManager_0.GetString("ID_EDITEMBEDDEDFILE_DEFAULT_ITEM"), "application/octet-stream");
			this.method_0(".323", "text/h323");
			this.method_0(".aaf", "application/octet-stream");
			this.method_0(".aca", "application/octet-stream");
			this.method_0(".accdb", "application/msaccess");
			this.method_0(".accde", "application/msaccess");
			this.method_0(".accdt", "application/msaccess");
			this.method_0(".acx", "application/internet-property-stream");
			this.method_0(".afm", "application/octet-stream");
			this.method_0(".ai", "application/postscript");
			this.method_0(".aif", "audio/x-aiff");
			this.method_0(".aifc", "audio/aiff");
			this.method_0(".aiff", "audio/aiff");
			this.method_0(".application", "application/x-ms-application");
			this.method_0(".art", "image/x-jg");
			this.method_0(".asd", "application/octet-stream");
			this.method_0(".asf", "video/x-ms-asf");
			this.method_0(".asi", "application/octet-stream");
			this.method_0(".asm", "text/plain");
			this.method_0(".asr", "video/x-ms-asf");
			this.method_0(".asx", "video/x-ms-asf");
			this.method_0(".atom", "application/atom+xml");
			this.method_0(".au", "audio/basic");
			this.method_0(".avi", "video/x-msvideo");
			this.method_0(".axs", "application/olescript");
			this.method_0(".bas", "text/plain");
			this.method_0(".bcpio", "application/x-bcpio");
			this.method_0(".bin", "application/octet-stream");
			this.method_0(".bmp", "image/bmp");
			this.method_0(".c", "text/plain");
			this.method_0(".cab", "application/octet-stream");
			this.method_0(".calx", "application/vnd.ms-office.calx");
			this.method_0(".cat", "application/vnd.ms-pki.seccat");
			this.method_0(".cdf", "application/x-cdf");
			this.method_0(".chm", "application/octet-stream");
			this.method_0(".class", "application/x-java-applet");
			this.method_0(".clp", "application/x-msclip");
			this.method_0(".cmx", "image/x-cmx");
			this.method_0(".cnf", "text/plain");
			this.method_0(".cod", "image/cis-cod");
			this.method_0(".cpio", "application/x-cpio");
			this.method_0(".cpp", "text/plain");
			this.method_0(".crd", "application/x-mscardfile");
			this.method_0(".crl", "application/pkix-crl");
			this.method_0(".crt", "application/x-x509-ca-cert");
			this.method_0(".csh", "application/x-csh");
			this.method_0(".css", "text/css");
			this.method_0(".csv", "application/octet-stream");
			this.method_0(".cur", "application/octet-stream");
			this.method_0(".dcr", "application/x-director");
			this.method_0(".deploy", "application/octet-stream");
			this.method_0(".der", "application/x-x509-ca-cert");
			this.method_0(".dib", "image/bmp");
			this.method_0(".dir", "application/x-director");
			this.method_0(".disco", "text/xml");
			this.method_0(".dll", "application/x-msdownload");
			this.method_0(".dll.config", "text/xml");
			this.method_0(".dlm", "text/dlm");
			this.method_0(".doc", "application/msword");
			this.method_0(".docm", "application/vnd.ms-word.document.macroEnabled.12");
			this.method_0(".docx", "application/vnd.openxmlformats-officedocument.wordprocessingml.document");
			this.method_0(".dot", "application/msword");
			this.method_0(".dotm", "application/vnd.ms-word.template.macroEnabled.12");
			this.method_0(".dotx", "application/vnd.openxmlformats-officedocument.wordprocessingml.template");
			this.method_0(".dsp", "application/octet-stream");
			this.method_0(".dtd", "text/xml");
			this.method_0(".dvi", "application/x-dvi");
			this.method_0(".dwf", "drawing/x-dwf");
			this.method_0(".dwp", "application/octet-stream");
			this.method_0(".dxr", "application/x-director");
			this.method_0(".eml", "message/rfc822");
			this.method_0(".emz", "application/octet-stream");
			this.method_0(".eot", "application/octet-stream");
			this.method_0(".eps", "application/postscript");
			this.method_0(".etx", "text/x-setext");
			this.method_0(".evy", "application/envoy");
			this.method_0(".exe", "application/octet-stream");
			this.method_0(".exe.config", "text/xml");
			this.method_0(".fdf", "application/vnd.fdf");
			this.method_0(".fif", "application/fractals");
			this.method_0(".fla", "application/octet-stream");
			this.method_0(".flr", "x-world/x-vrml");
			this.method_0(".flv", "video/x-flv");
			this.method_0(".gif", "image/gif");
			this.method_0(".gtar", "application/x-gtar");
			this.method_0(".gz", "application/x-gzip");
			this.method_0(".h", "text/plain");
			this.method_0(".hdf", "application/x-hdf");
			this.method_0(".hdml", "text/x-hdml");
			this.method_0(".hhc", "application/x-oleobject");
			this.method_0(".hhk", "application/octet-stream");
			this.method_0(".hhp", "application/octet-stream");
			this.method_0(".hlp", "application/winhlp");
			this.method_0(".hqx", "application/mac-binhex40");
			this.method_0(".hta", "application/hta");
			this.method_0(".htc", "text/x-component");
			this.method_0(".htm", "text/html");
			this.method_0(".html", "text/html");
			this.method_0(".htt", "text/webviewhtml");
			this.method_0(".hxt", "text/html");
			this.method_0(".ico", "image/x-icon");
			this.method_0(".ics", "application/octet-stream");
			this.method_0(".ief", "image/ief");
			this.method_0(".iii", "application/x-iphone");
			this.method_0(".inf", "application/octet-stream");
			this.method_0(".ins", "application/x-internet-signup");
			this.method_0(".isp", "application/x-internet-signup");
			this.method_0(".IVF", "video/x-ivf");
			this.method_0(".jar", "application/java-archive");
			this.method_0(".java", "application/octet-stream");
			this.method_0(".jck", "application/liquidmotion");
			this.method_0(".jcz", "application/liquidmotion");
			this.method_0(".jfif", "image/pjpeg");
			this.method_0(".jpb", "application/octet-stream");
			this.method_0(".jpe", "image/jpeg");
			this.method_0(".jpeg", "image/jpeg");
			this.method_0(".jpg", "image/jpeg");
			this.method_0(".js", "application/x-javascript");
			this.method_0(".jsx", "text/jscript");
			this.method_0(".latex", "application/x-latex");
			this.method_0(".lit", "application/x-ms-reader");
			this.method_0(".lpk", "application/octet-stream");
			this.method_0(".lsf", "video/x-la-asf");
			this.method_0(".lsx", "video/x-la-asf");
			this.method_0(".lzh", "application/octet-stream");
			this.method_0(".m13", "application/x-msmediaview");
			this.method_0(".m14", "application/x-msmediaview");
			this.method_0(".m1v", "video/mpeg");
			this.method_0(".m3u", "audio/x-mpegurl");
			this.method_0(".man", "application/x-troff-man");
			this.method_0(".manifest", "application/x-ms-manifest");
			this.method_0(".map", "text/plain");
			this.method_0(".mdb", "application/x-msaccess");
			this.method_0(".mdp", "application/octet-stream");
			this.method_0(".me", "application/x-troff-me");
			this.method_0(".mht", "message/rfc822");
			this.method_0(".mhtml", "message/rfc822");
			this.method_0(".mid", "audio/mid");
			this.method_0(".midi", "audio/mid");
			this.method_0(".mix", "application/octet-stream");
			this.method_0(".mmf", "application/x-smaf");
			this.method_0(".mno", "text/xml");
			this.method_0(".mny", "application/x-msmoney");
			this.method_0(".mov", "video/quicktime");
			this.method_0(".movie", "video/x-sgi-movie");
			this.method_0(".mp2", "video/mpeg");
			this.method_0(".mp3", "audio/mpeg");
			this.method_0(".mpa", "video/mpeg");
			this.method_0(".mpe", "video/mpeg");
			this.method_0(".mpeg", "video/mpeg");
			this.method_0(".mpg", "video/mpeg");
			this.method_0(".mpp", "application/vnd.ms-project");
			this.method_0(".mpv2", "video/mpeg");
			this.method_0(".ms", "application/x-troff-ms");
			this.method_0(".msi", "application/octet-stream");
			this.method_0(".mso", "application/octet-stream");
			this.method_0(".mvb", "application/x-msmediaview");
			this.method_0(".mvc", "application/x-miva-compiled");
			this.method_0(".nc", "application/x-netcdf");
			this.method_0(".nsc", "video/x-ms-asf");
			this.method_0(".nws", "message/rfc822");
			this.method_0(".ocx", "application/octet-stream");
			this.method_0(".oda", "application/oda");
			this.method_0(".odc", "text/x-ms-odc");
			this.method_0(".ods", "application/oleobject");
			this.method_0(".one", "application/onenote");
			this.method_0(".onea", "application/onenote");
			this.method_0(".onetoc", "application/onenote");
			this.method_0(".onetoc2", "application/onenote");
			this.method_0(".onetmp", "application/onenote");
			this.method_0(".onepkg", "application/onenote");
			this.method_0(".osdx", "application/opensearchdescription+xml");
			this.method_0(".p10", "application/pkcs10");
			this.method_0(".p12", "application/x-pkcs12");
			this.method_0(".p7b", "application/x-pkcs7-certificates");
			this.method_0(".p7c", "application/pkcs7-mime");
			this.method_0(".p7m", "application/pkcs7-mime");
			this.method_0(".p7r", "application/x-pkcs7-certreqresp");
			this.method_0(".p7s", "application/pkcs7-signature");
			this.method_0(".pbm", "image/x-portable-bitmap");
			this.method_0(".pcx", "application/octet-stream");
			this.method_0(".pcz", "application/octet-stream");
			this.method_0(".pdf", "application/pdf");
			this.method_0(".pfb", "application/octet-stream");
			this.method_0(".pfm", "application/octet-stream");
			this.method_0(".pfx", "application/x-pkcs12");
			this.method_0(".pgm", "image/x-portable-graymap");
			this.method_0(".pko", "application/vnd.ms-pki.pko");
			this.method_0(".pma", "application/x-perfmon");
			this.method_0(".pmc", "application/x-perfmon");
			this.method_0(".pml", "application/x-perfmon");
			this.method_0(".pmr", "application/x-perfmon");
			this.method_0(".pmw", "application/x-perfmon");
			this.method_0(".png", "image/png");
			this.method_0(".pnm", "image/x-portable-anymap");
			this.method_0(".pnz", "image/png");
			this.method_0(".pot", "application/vnd.ms-powerpoint");
			this.method_0(".potm", "application/vnd.ms-powerpoint.template.macroEnabled.12");
			this.method_0(".potx", "application/vnd.openxmlformats-officedocument.presentationml.template");
			this.method_0(".ppam", "application/vnd.ms-powerpoint.addin.macroEnabled.12");
			this.method_0(".ppm", "image/x-portable-pixmap");
			this.method_0(".pps", "application/vnd.ms-powerpoint");
			this.method_0(".ppsm", "application/vnd.ms-powerpoint.slideshow.macroEnabled.12");
			this.method_0(".ppsx", "application/vnd.openxmlformats-officedocument.presentationml.slideshow");
			this.method_0(".ppt", "application/vnd.ms-powerpoint");
			this.method_0(".pptm", "application/vnd.ms-powerpoint.presentation.macroEnabled.12");
			this.method_0(".pptx", "application/vnd.openxmlformats-officedocument.presentationml.presentation");
			this.method_0(".prf", "application/pics-rules");
			this.method_0(".prm", "application/octet-stream");
			this.method_0(".prx", "application/octet-stream");
			this.method_0(".ps", "application/postscript");
			this.method_0(".psd", "application/octet-stream");
			this.method_0(".psm", "application/octet-stream");
			this.method_0(".psp", "application/octet-stream");
			this.method_0(".pub", "application/x-mspublisher");
			this.method_0(".qt", "video/quicktime");
			this.method_0(".qtl", "application/x-quicktimeplayer");
			this.method_0(".qxd", "application/octet-stream");
			this.method_0(".ra", "audio/x-pn-realaudio");
			this.method_0(".ram", "audio/x-pn-realaudio");
			this.method_0(".rar", "application/octet-stream");
			this.method_0(".ras", "image/x-cmu-raster");
			this.method_0(".rf", "image/vnd.rn-realflash");
			this.method_0(".rgb", "image/x-rgb");
			this.method_0(".rm", "application/vnd.rn-realmedia");
			this.method_0(".rmi", "audio/mid");
			this.method_0(".roff", "application/x-troff");
			this.method_0(".rpm", "audio/x-pn-realaudio-plugin");
			this.method_0(".rtf", "application/rtf");
			this.method_0(".rtx", "text/richtext");
			this.method_0(".scd", "application/x-msschedule");
			this.method_0(".sct", "text/scriptlet");
			this.method_0(".sea", "application/octet-stream");
			this.method_0(".setpay", "application/set-payment-initiation");
			this.method_0(".setreg", "application/set-registration-initiation");
			this.method_0(".sgml", "text/sgml");
			this.method_0(".sh", "application/x-sh");
			this.method_0(".shar", "application/x-shar");
			this.method_0(".sit", "application/x-stuffit");
			this.method_0(".sldm", "application/vnd.ms-powerpoint.slide.macroEnabled.12");
			this.method_0(".sldx", "application/vnd.openxmlformats-officedocument.presentationml.slide");
			this.method_0(".smd", "audio/x-smd");
			this.method_0(".smi", "application/octet-stream");
			this.method_0(".smx", "audio/x-smd");
			this.method_0(".smz", "audio/x-smd");
			this.method_0(".snd", "audio/basic");
			this.method_0(".snp", "application/octet-stream");
			this.method_0(".spc", "application/x-pkcs7-certificates");
			this.method_0(".spl", "application/futuresplash");
			this.method_0(".src", "application/x-wais-source");
			this.method_0(".ssm", "application/streamingmedia");
			this.method_0(".sst", "application/vnd.ms-pki.certstore");
			this.method_0(".stl", "application/vnd.ms-pki.stl");
			this.method_0(".sv4cpio", "application/x-sv4cpio");
			this.method_0(".sv4crc", "application/x-sv4crc");
			this.method_0(".swf", "application/x-shockwave-flash");
			this.method_0(".t", "application/x-troff");
			this.method_0(".tar", "application/x-tar");
			this.method_0(".tcl", "application/x-tcl");
			this.method_0(".tex", "application/x-tex");
			this.method_0(".texi", "application/x-texinfo");
			this.method_0(".texinfo", "application/x-texinfo");
			this.method_0(".tgz", "application/x-compressed");
			this.method_0(".thmx", "application/vnd.ms-officetheme");
			this.method_0(".thn", "application/octet-stream");
			this.method_0(".tif", "image/tiff");
			this.method_0(".tiff", "image/tiff");
			this.method_0(".toc", "application/octet-stream");
			this.method_0(".tr", "application/x-troff");
			this.method_0(".trm", "application/x-msterminal");
			this.method_0(".tsv", "text/tab-separated-values");
			this.method_0(".ttf", "application/octet-stream");
			this.method_0(".txt", "text/plain");
			this.method_0(".u32", "application/octet-stream");
			this.method_0(".uls", "text/iuls");
			this.method_0(".ustar", "application/x-ustar");
			this.method_0(".vbs", "text/vbscript");
			this.method_0(".vcf", "text/x-vcard");
			this.method_0(".vcs", "text/plain");
			this.method_0(".vdx", "application/vnd.ms-visio.viewer");
			this.method_0(".vml", "text/xml");
			this.method_0(".vsd", "application/vnd.visio");
			this.method_0(".vss", "application/vnd.visio");
			this.method_0(".vst", "application/vnd.visio");
			this.method_0(".vsto", "application/x-ms-vsto");
			this.method_0(".vsw", "application/vnd.visio");
			this.method_0(".vsx", "application/vnd.visio");
			this.method_0(".vtx", "application/vnd.visio");
			this.method_0(".wav", "audio/wav");
			this.method_0(".wax", "audio/x-ms-wax");
			this.method_0(".wbmp", "image/vnd.wap.wbmp");
			this.method_0(".wcm", "application/vnd.ms-works");
			this.method_0(".wdb", "application/vnd.ms-works");
			this.method_0(".wks", "application/vnd.ms-works");
			this.method_0(".wm", "video/x-ms-wm");
			this.method_0(".wma", "audio/x-ms-wma");
			this.method_0(".wmd", "application/x-ms-wmd");
			this.method_0(".wmf", "application/x-msmetafile");
			this.method_0(".wml", "text/vnd.wap.wml");
			this.method_0(".wmlc", "application/vnd.wap.wmlc");
			this.method_0(".wmls", "text/vnd.wap.wmlscript");
			this.method_0(".wmlsc", "application/vnd.wap.wmlscriptc");
			this.method_0(".wmp", "video/x-ms-wmp");
			this.method_0(".wmv", "video/x-ms-wmv");
			this.method_0(".wmx", "video/x-ms-wmx");
			this.method_0(".wmz", "application/x-ms-wmz");
			this.method_0(".wps", "application/vnd.ms-works");
			this.method_0(".wri", "application/x-mswrite");
			this.method_0(".wrl", "x-world/x-vrml");
			this.method_0(".wrz", "x-world/x-vrml");
			this.method_0(".wsdl", "text/xml");
			this.method_0(".wvx", "video/x-ms-wvx");
			this.method_0(".x", "application/directx");
			this.method_0(".xaf", "x-world/x-vrml");
			this.method_0(".xaml", "application/xaml+xml");
			this.method_0(".xap", "application/x-silverlight-app");
			this.method_0(".xbap", "application/x-ms-xbap");
			this.method_0(".xbm", "image/x-xbitmap");
			this.method_0(".xdr", "text/plain");
			this.method_0(".xla", "application/vnd.ms-excel");
			this.method_0(".xlam", "application/vnd.ms-excel.addin.macroEnabled.12");
			this.method_0(".xlc", "application/vnd.ms-excel");
			this.method_0(".xlm", "application/vnd.ms-excel");
			this.method_0(".xls", "application/vnd.ms-excel");
			this.method_0(".xlsb", "application/vnd.ms-excel.sheet.binary.macroEnabled.12");
			this.method_0(".xlsm", "application/vnd.ms-excel.sheet.macroEnabled.12");
			this.method_0(".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
			this.method_0(".xlt", "application/vnd.ms-excel");
			this.method_0(".xltm", "application/vnd.ms-excel.template.macroEnabled.12");
			this.method_0(".xltx", "application/vnd.openxmlformats-officedocument.spreadsheetml.template");
			this.method_0(".xlw", "application/vnd.ms-excel");
			this.method_0(".xml", "text/xml");
			this.method_0(".xof", "x-world/x-vrml");
			this.method_0(".xpm", "image/x-xpixmap");
			this.method_0(".xps", "application/vnd.ms-xpsdocument");
			this.method_0(".xsd", "text/xml");
			this.method_0(".xsf", "text/xml");
			this.method_0(".xsl", "text/xml");
			this.method_0(".xslt", "text/xml");
			this.method_0(".xsn", "application/octet-stream");
			this.method_0(".xtp", "application/octet-stream");
			this.method_0(".xwd", "image/x-xwindowdump");
			this.method_0(".z", "application/x-compress");
			this.method_0(".zip", "application/x-zip-compressed");
			this.m_cmbxMimeType.DropDownWidth = TextRenderer.MeasureText(".pptx (application/vnd.openxmlformats-officedocument.presentationml.presentation)    " + Class466.smethod_4(this.uint_0), this.m_cmbxMimeType.Font, default(Size), TextFormatFlags.NoPrefix).Width;
		}

		private void method_2(EmbeddedFile embeddedFile_0)
		{
			if (string.IsNullOrEmpty(embeddedFile_0.MIMEType))
			{
				this.m_cmbxMimeType.SelectedIndex = 0;
				return;
			}
			string[] array = embeddedFile_0.FileName.Split('.');
			if (array.Length < 2)
			{
				return;
			}
			string text = "." + array[array.Length - 1];
			for (int i = 0; i < this.m_cmbxMimeType.Items.Count; i++)
			{
				Class578 @class = this.m_cmbxMimeType.Items[i] as Class578;
				if (@class.String_0 == text)
				{
					if (!(@class.String_1 == embeddedFile_0.MIMEType))
					{
						break;
					}
					this.m_cmbxMimeType.SelectedIndex = i;
					return;
				}
			}
			this.m_cmbxMimeType.Text = embeddedFile_0.MIMEType;
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			this.uint_0 = Class468.smethod_0(null, this);
			Class429.Struct83 struct83_ = default(Class429.Struct83);
			Class429.GetWindowRect(base.Handle, ref struct83_);
			Class468.smethod_1(this.uint_0, struct83_, this);
			base.OnHandleCreated(eventArgs_0);
		}

		protected override void WndProc(ref Message message)
		{
			int msg = message.Msg;
			if (msg == 736)
			{
				uint num = Class429.smethod_5(message.WParam.ToInt32());
				if (num != this.uint_0)
				{
					Class429.Struct83 struct83_ = (Class429.Struct83)Marshal.PtrToStructure(message.LParam, typeof(Class429.Struct83));
					this.Font = new Font(this.Font.Name, this.Font.Size * (float)num / (float)this.uint_0, this.Font.Style, this.Font.Unit);
					this.uint_0 = num;
					Class468.smethod_1(this.uint_0, struct83_, this);
				}
			}
			else
			{
				base.WndProc(ref message);
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
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.m_lblFileName = new System.Windows.Forms.Label();
			this.m_lblFile = new System.Windows.Forms.Label();
			this.m_lblDescription = new System.Windows.Forms.Label();
			this.m_tbxDescription = new System.Windows.Forms.TextBox();
			this.m_lblRelationship = new System.Windows.Forms.Label();
			this.m_cmbxRelationship = new System.Windows.Forms.ComboBox();
			this.m_lblMimeType = new System.Windows.Forms.Label();
			this.m_cmbxMimeType = new System.Windows.Forms.ComboBox();
			this.m_btnOK = new System.Windows.Forms.Button();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.tableLayoutPanel1.SuspendLayout();
			base.SuspendLayout();
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 4;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.m_lblFileName, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.m_lblFile, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.m_lblDescription, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.m_tbxDescription, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.m_lblRelationship, 0, 2);
			this.tableLayoutPanel1.Controls.Add(this.m_cmbxRelationship, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.m_lblMimeType, 0, 3);
			this.tableLayoutPanel1.Controls.Add(this.m_cmbxMimeType, 1, 3);
			this.tableLayoutPanel1.Controls.Add(this.m_btnOK, 2, 4);
			this.tableLayoutPanel1.Controls.Add(this.m_btnCancel, 3, 4);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 7);
			this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 5;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(228, 113);
			this.tableLayoutPanel1.TabIndex = 0;
			this.m_lblFileName.AutoSize = true;
			this.m_lblFileName.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblFileName.Location = new System.Drawing.Point(0, 0);
			this.m_lblFileName.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
			this.m_lblFileName.Name = "m_lblFileName";
			this.m_lblFileName.Size = new System.Drawing.Size(68, 13);
			this.m_lblFileName.TabIndex = 0;
			this.m_lblFileName.Text = "File Name:";
			this.m_lblFile.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.m_lblFile, 3);
			this.m_lblFile.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblFile.Location = new System.Drawing.Point(74, 0);
			this.m_lblFile.Margin = new System.Windows.Forms.Padding(3, 0, 0, 3);
			this.m_lblFile.Name = "m_lblFile";
			this.m_lblFile.Size = new System.Drawing.Size(154, 13);
			this.m_lblFile.TabIndex = 1;
			this.m_lblFile.Text = "File.f";
			this.m_lblDescription.AutoSize = true;
			this.m_lblDescription.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblDescription.Location = new System.Drawing.Point(0, 22);
			this.m_lblDescription.Margin = new System.Windows.Forms.Padding(0, 6, 3, 3);
			this.m_lblDescription.Name = "m_lblDescription";
			this.m_lblDescription.Size = new System.Drawing.Size(68, 13);
			this.m_lblDescription.TabIndex = 2;
			this.m_lblDescription.Text = "Description:";
			this.tableLayoutPanel1.SetColumnSpan(this.m_tbxDescription, 3);
			this.m_tbxDescription.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_tbxDescription.Location = new System.Drawing.Point(74, 19);
			this.m_tbxDescription.MinimumSize = new System.Drawing.Size(200, 4);
			this.m_tbxDescription.Name = "m_tbxDescription";
			this.m_tbxDescription.Size = new System.Drawing.Size(200, 20);
			this.m_tbxDescription.TabIndex = 3;
			this.m_lblRelationship.AutoSize = true;
			this.m_lblRelationship.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblRelationship.Location = new System.Drawing.Point(0, 48);
			this.m_lblRelationship.Margin = new System.Windows.Forms.Padding(0, 6, 3, 3);
			this.m_lblRelationship.Name = "m_lblRelationship";
			this.m_lblRelationship.Size = new System.Drawing.Size(68, 13);
			this.m_lblRelationship.TabIndex = 4;
			this.m_lblRelationship.Text = "Relationship:";
			this.tableLayoutPanel1.SetColumnSpan(this.m_cmbxRelationship, 3);
			this.m_cmbxRelationship.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_cmbxRelationship.Items.AddRange(new object[5] { "Source", "Alternative", "Data", "Supplement", "Unspecified" });
			this.m_cmbxRelationship.Location = new System.Drawing.Point(74, 45);
			this.m_cmbxRelationship.MinimumSize = new System.Drawing.Size(200, 0);
			this.m_cmbxRelationship.Name = "m_cmbxRelationship";
			this.m_cmbxRelationship.Size = new System.Drawing.Size(200, 21);
			this.m_cmbxRelationship.TabIndex = 5;
			this.m_lblMimeType.AutoSize = true;
			this.m_lblMimeType.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblMimeType.Location = new System.Drawing.Point(0, 75);
			this.m_lblMimeType.Margin = new System.Windows.Forms.Padding(0, 6, 3, 15);
			this.m_lblMimeType.Name = "m_lblMimeType";
			this.m_lblMimeType.Size = new System.Drawing.Size(68, 13);
			this.m_lblMimeType.TabIndex = 6;
			this.m_lblMimeType.Text = "MIME Type:";
			this.tableLayoutPanel1.SetColumnSpan(this.m_cmbxMimeType, 3);
			this.m_cmbxMimeType.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_cmbxMimeType.FormattingEnabled = true;
			this.m_cmbxMimeType.Location = new System.Drawing.Point(74, 72);
			this.m_cmbxMimeType.Margin = new System.Windows.Forms.Padding(3, 3, 3, 15);
			this.m_cmbxMimeType.MinimumSize = new System.Drawing.Size(200, 0);
			this.m_cmbxMimeType.Name = "m_cmbxMimeType";
			this.m_cmbxMimeType.Size = new System.Drawing.Size(200, 21);
			this.m_cmbxMimeType.TabIndex = 7;
			this.m_btnOK.AutoSize = true;
			this.m_btnOK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.m_btnOK.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnOK.Location = new System.Drawing.Point(72, 111);
			this.m_btnOK.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
			this.m_btnOK.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(75, 23);
			this.m_btnOK.TabIndex = 8;
			this.m_btnOK.Text = "OK";
			this.m_btnOK.UseVisualStyleBackColor = true;
			this.m_btnCancel.AutoSize = true;
			this.m_btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_btnCancel.Location = new System.Drawing.Point(153, 111);
			this.m_btnCancel.Margin = new System.Windows.Forms.Padding(3, 3, 0, 0);
			this.m_btnCancel.MinimumSize = new System.Drawing.Size(75, 23);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
			this.m_btnCancel.TabIndex = 9;
			this.m_btnCancel.Text = "Cancel";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			base.AcceptButton = this.m_btnOK;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.CancelButton = this.m_btnCancel;
			base.ClientSize = new System.Drawing.Size(242, 127);
			base.Controls.Add(this.tableLayoutPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "EditEmbeddedFileDialog";
			base.Padding = new System.Windows.Forms.Padding(7);
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Edit PDF Attachment";
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
