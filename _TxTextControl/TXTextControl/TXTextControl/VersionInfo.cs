using ns21;

namespace TXTextControl
{
	/// <summary>The VersionInfo class provides information about the running TX Text Control version, such as the version number, the installed service pack number and the product level.</summary>
	public class VersionInfo
	{
		public enum ProductLevel
		{
			Standard = 1,
			Professional,
			Enterprise,
			Server,
			Trial
		}

		private int int_0;

		private int int_1;

		private int int_2;

		private ProductLevel productLevel_0;

		/// <summary>Gets the major version number.</summary>
		public int Major => this.int_0;

		/// <summary>Gets the minor version number.</summary>
		public int Minor => this.int_1;

		/// <summary>Gets the number of the installed service pack.</summary>
		public int ServicePack => this.int_2;

		public ProductLevel Level => this.productLevel_0;

		internal VersionInfo(Class408 helperLibraries, Enum115 iLicenseLevel)
		{
			int num = helperLibraries.method_6();
			this.int_0 = num / 100;
			this.int_1 = num % 100 / 10;
			this.int_2 = num % 100 % 10;
			switch (iLicenseLevel)
			{
			case Enum115.const_1:
				this.productLevel_0 = ProductLevel.Trial;
				break;
			case Enum115.const_0:
				this.productLevel_0 = ProductLevel.Professional;
				break;
			case Enum115.const_4:
				this.productLevel_0 = ProductLevel.Server;
				break;
			case Enum115.Enterprise:
				this.productLevel_0 = ProductLevel.Enterprise;
				break;
			case Enum115.Standard:
				this.productLevel_0 = ProductLevel.Standard;
				break;
			}
		}
	}
}
