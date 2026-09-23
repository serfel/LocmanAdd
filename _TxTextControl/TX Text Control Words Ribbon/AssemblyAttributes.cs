/*-------------------------------------------------------------------------------------------------------------
** program:			TX Text Control Words
** description:	Implements a typical word processing application build up on the main features of TextControl's Components. 
**
** copyright:		© Text Control GmbH
**-----------------------------------------------------------------------------------------------------------*/
using System;
using System.Reflection;

namespace TX_Text_Control_Words {

	/*-------------------------------------------------------------------------------------------------------
	** Class AssemblyAttributes
	** Provides the assembly attributes for the AboutBox.xaml.cs
	**-----------------------------------------------------------------------------------------------------*/
	static class AssemblyAttributes {

		/*------------------------------------------------------------------------------------------------
		** P R O P E R T I E S
		**----------------------------------------------------------------------------------------------*/

		/*-------------------------------------------------------------------------------------------------------
		** AssemblyCopyright
		** Returns the assembly copyright.
		**-----------------------------------------------------------------------------------------------------*/
		public static string AssemblyCopyright {
			get {
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
				if (attributes.Length == 0) {
					return "";
				}
				return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
			}
		}

		/*-------------------------------------------------------------------------------------------------------
		** AssemblyDescription
		** Returns the assembly description.
		**-----------------------------------------------------------------------------------------------------*/
		public static string AssemblyDescription {
			get {
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
				if (attributes.Length == 0) {
					return "";
				}
				return ((AssemblyDescriptionAttribute)attributes[0]).Description;
			}
		}

		/*-------------------------------------------------------------------------------------------------------
		** AssemblyProduct
		** Returns the assembly product.
		**-----------------------------------------------------------------------------------------------------*/
		public static string AssemblyProduct {
			get {
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
				if (attributes.Length == 0) {
					return "";
				}
				return ((AssemblyProductAttribute)attributes[0]).Product;
			}
		}

		/*-------------------------------------------------------------------------------------------------------
		** AssemblyTitle
		** Returns the assembly title.
		**-----------------------------------------------------------------------------------------------------*/
		public static string AssemblyTitle {
			get {
				object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				if (attributes.Length > 0) {
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
					if (titleAttribute.Title != "") {
						return titleAttribute.Title;
					}
				}
				return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		/*-------------------------------------------------------------------------------------------------------
		** AssemblyVersion
		** Returns the assembly version.
		**-----------------------------------------------------------------------------------------------------*/
		public static Version AssemblyVersion {
			get {
				return Assembly.GetExecutingAssembly().GetName().Version;
			}
		}

		/*-------------------------------------------------------------------------------------------------------
		** Is64BitAssembly
		** Returns a value indication whether the assembly is a 64 bit assembly
		**-----------------------------------------------------------------------------------------------------*/
		public static bool Is64BitAssembly {
			get {
				ImageFileMachine machine;
				PortableExecutableKinds peKind = 0;

				try {
					Assembly.GetExecutingAssembly().ManifestModule.GetPEKind(out peKind, out machine);
				}
				catch { }

				return ((peKind & System.Reflection.PortableExecutableKinds.PE32Plus) != 0);
			}
		}
	}
}
