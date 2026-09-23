using System;
using System.IO;
using System.Reflection;

namespace TX_Text_Control_Words
{
	internal static class AssemblyAttributes
	{
		public static string AssemblyCopyright
		{
			get
			{
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), inherit: false);
				if (customAttributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyCopyrightAttribute)customAttributes[0]).Copyright;
			}
		}

		public static string AssemblyDescription
		{
			get
			{
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), inherit: false);
				if (customAttributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyDescriptionAttribute)customAttributes[0]).Description;
			}
		}

		public static string AssemblyProduct
		{
			get
			{
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), inherit: false);
				if (customAttributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyProductAttribute)customAttributes[0]).Product;
			}
		}

		public static string AssemblyTitle
		{
			get
			{
				object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), inherit: false);
				if (customAttributes.Length != 0)
				{
					AssemblyTitleAttribute assemblyTitleAttribute = (AssemblyTitleAttribute)customAttributes[0];
					if (assemblyTitleAttribute.Title != "")
					{
						return assemblyTitleAttribute.Title;
					}
				}
				return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
			}
		}

		public static Version AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version;

		public static bool Is64BitAssembly
		{
			get
			{
				PortableExecutableKinds peKind = PortableExecutableKinds.NotAPortableExecutableImage;
				try
				{
					Assembly.GetExecutingAssembly().ManifestModule.GetPEKind(out peKind, out var _);
				}
				catch
				{
				}
				return (peKind & PortableExecutableKinds.PE32Plus) != 0;
			}
		}
	}
}
