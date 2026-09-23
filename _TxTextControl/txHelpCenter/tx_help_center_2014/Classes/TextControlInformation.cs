using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;

namespace tx_help_center_2014.Classes
{
	public class TextControlInformation
	{
		public class TextControlProduct
		{
			public string ProductName;

			public float VersionNumber;

			public string Technology;

			public string VersionDisplayName;

			public string Path;

			public string ProductString;

			public string HelpFileName;

			public TextControlProduct()
			{
			}

			public TextControlProduct(string ProductString, string ProductName, string Technology, float VersionNumber, string VersionDisplayName, string HelpFileName)
			{
				this.ProductName = ProductName;
				this.Technology = Technology;
				this.VersionNumber = VersionNumber;
				this.VersionDisplayName = VersionDisplayName;
				this.ProductString = ProductString;
				this.HelpFileName = HelpFileName;
			}
		}

		public List<TextControlProduct> Products = new List<TextControlProduct>();

		private List<TextControlProduct> ExistingProducts = new List<TextControlProduct>
		{
			new TextControlProduct("TX Text Control 29.0.NET for Windows Forms", "TX Text Control .NET", "Windows Forms", 29f, "X19", "TXTextControl.chm"),
			new TextControlProduct("TX Text Control 29.0.NET for WPF", "TX Text Control .NET", "WPF", 29f, "X19", "TXTextControl.chm"),
			new TextControlProduct("TX Text Control 29.0.NET Server for ASP.NET", "TX Text Control .NET Server", "ASP.NET", 29f, "X19", "TXTextControl.chm"),
			new TextControlProduct("TX Spell 8.0 .NET for Windows Forms", "TX Spell .NET", "Windows Forms", 8f, "8.0", "TXSpell.chm"),
			new TextControlProduct("TX Spell 8.0 .NET for WPF", "TX Spell .NET", "WPF", 8f, "8.0", "TXSpell.chm"),
			new TextControlProduct("TX Barcode 5.0 .NET for Windows Forms", "TX Barcode .NET", "Windows Forms", 5f, "5.0", "TXBarcode.chm"),
			new TextControlProduct("TX Barcode 5.0 .NET for WPF", "TX Barcode .NET", "WPF", 5f, "5.0", "TXBarcode.chm")
		};

		public bool IsBarcodeWindowsFormsAvailable
		{
			get
			{
				foreach (TextControlProduct product in this.Products)
				{
					if (product.ProductName == "TX Barcode .NET" && product.Technology == "Windows Forms")
					{
						return true;
					}
				}
				return false;
			}
		}

		public bool IsBarcodeWPFAvailable
		{
			get
			{
				foreach (TextControlProduct product in this.Products)
				{
					if (product.ProductName == "TX Barcode .NET" && product.Technology == "WPF")
					{
						return true;
					}
				}
				return false;
			}
		}

		public bool IsSpellCheckingWindowsFormsAvailable
		{
			get
			{
				foreach (TextControlProduct product in this.Products)
				{
					if (product.ProductName == "TX Spell .NET" && product.Technology == "Windows Forms")
					{
						return true;
					}
				}
				return false;
			}
		}

		public bool IsSpellCheckingWPFAvailable
		{
			get
			{
				foreach (TextControlProduct product in this.Products)
				{
					if (product.ProductName == "TX Spell .NET" && product.Technology == "WPF")
					{
						return true;
					}
				}
				return false;
			}
		}

		public bool IsTextControlWPFAvailable
		{
			get
			{
				foreach (TextControlProduct product in this.Products)
				{
					if (product.ProductName == "TX Text Control .NET" && product.Technology == "WPF")
					{
						return true;
					}
				}
				return false;
			}
		}

		public bool IsTextControlWindowsFormsAvailable
		{
			get
			{
				foreach (TextControlProduct product in this.Products)
				{
					if (product.ProductName == "TX Text Control .NET" && product.Technology == "Windows Forms")
					{
						return true;
					}
				}
				return false;
			}
		}

		public bool IsTextControlServerAvailable
		{
			get
			{
				foreach (TextControlProduct product in this.Products)
				{
					if (product.ProductName == "TX Text Control .NET Server" && product.Technology == "ASP.NET")
					{
						return true;
					}
				}
				return false;
			}
		}

		public bool IsTextControlAvailable
		{
			get
			{
				foreach (TextControlProduct product in this.Products)
				{
					if (product.ProductName.Contains("TX Text Control"))
					{
						return true;
					}
				}
				return false;
			}
		}

		public bool IsSpellAvailable
		{
			get
			{
				foreach (TextControlProduct product in this.Products)
				{
					if (product.ProductName.Contains("Spell"))
					{
						return true;
					}
				}
				return false;
			}
		}

		public bool IsBarcodeAvailable
		{
			get
			{
				foreach (TextControlProduct product in this.Products)
				{
					if (product.ProductName.Contains("Barcode"))
					{
						return true;
					}
				}
				return false;
			}
		}

		public TextControlInformation()
		{
			string[] array = new string[10] { "Software\\Microsoft\\.NETFramework\\v2.0.50727\\AssemblyFoldersEx", "Software\\Microsoft\\.NETFramework\\v3.0\\AssemblyFoldersEx", "Software\\Microsoft\\.NETFramework\\v3.5\\AssemblyFoldersEx", "Software\\Microsoft\\.NETFramework\\v4.0.30319\\AssemblyFoldersEx", "Software\\Microsoft\\.NETFramework\\v4.5\\AssemblyFoldersEx", "Software\\WOW6432Node\\Microsoft\\.NETFramework\\v2.0.50727\\AssemblyFoldersEx", "Software\\WOW6432Node\\Microsoft\\.NETFramework\\v3.0\\AssemblyFoldersEx", "Software\\WOW6432Node\\Microsoft\\.NETFramework\\v3.5\\AssemblyFoldersEx", "Software\\WOW6432Node\\Microsoft\\.NETFramework\\v4.0.30319\\AssemblyFoldersEx", "Software\\WOW6432Node\\Microsoft\\.NETFramework\\v4.5\\AssemblyFoldersEx" };
			foreach (TextControlProduct existingProduct in this.ExistingProducts)
			{
				string[] array2 = array;
				foreach (string subKey in array2)
				{
					string pathInRegistry = this.GetPathInRegistry(existingProduct.ProductString, subKey);
					if (pathInRegistry != null)
					{
						existingProduct.Path = pathInRegistry;
						this.Products.Add(existingProduct);
						break;
					}
				}
			}
		}

		private string GetPathInRegistry(string ProductString, string SubKey)
		{
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(SubKey);
			if (registryKey == null || registryKey.GetSubKeyNames().Length == 0)
			{
				return null;
			}
			string[] subKeyNames = registryKey.GetSubKeyNames();
			foreach (string text in subKeyNames)
			{
				if (ProductString == text)
				{
					return (string)Registry.GetValue(registryKey?.ToString() + "\\" + text, "", null);
				}
			}
			return null;
		}

		public string GetProductDocumentationPath(string ProductString)
		{
			foreach (TextControlProduct product in this.Products)
			{
				if (product.ProductString == ProductString)
				{
					return Directory.GetParent(product.Path).FullName + "\\Help\\" + product.HelpFileName;
				}
			}
			return string.Empty;
		}

		public string GetProductDemoPath(string ProductString)
		{
			foreach (TextControlProduct product in this.Products)
			{
				if (product.ProductString == ProductString)
				{
					string text = "TXTextControlWords.exe";
					if (product.Technology == "WPF")
					{
						text = ((!File.Exists(Directory.GetParent(product.Path).FullName + "\\Samples\\Demo\\x86\\TXTextControlWords_WPF_Ribbon.exe")) ? "TXTextControlWords_WPF.exe" : "TXTextControlWords_WPF_Ribbon.exe");
					}
					else if (File.Exists(Directory.GetParent(product.Path).FullName + "\\Samples\\Demo\\x86\\TXTextControlWords_Ribbon.exe"))
					{
						text = "TXTextControlWords_Ribbon.exe";
					}
					return Directory.GetParent(product.Path).FullName + "\\Samples\\Demo\\x86\\" + text;
				}
			}
			return string.Empty;
		}

		public string GetProductSamplesPath(string ProductString)
		{
			foreach (TextControlProduct product in this.Products)
			{
				if (product.ProductString == ProductString)
				{
					return Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\" + product.ProductString + "\\Samples\\";
				}
			}
			return string.Empty;
		}
	}
}
