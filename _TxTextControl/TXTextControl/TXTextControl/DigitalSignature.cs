using System.Security.Cryptography.X509Certificates;

namespace TXTextControl
{
	/// <summary>An instance of the DigitalSignature class represents an X.509 certificate which can be used to digitally sign a PDF or PDF/A document.</summary>
	public class DigitalSignature
	{
		internal X509Certificate2 x509Certificate2_0;

		internal string string_0;

		/// <summary>Initializes a new instance of the DigitalSignature class.</summary>
		/// <param name="x509">Specifies an X509Certificate2 object which represents an X.509 certificate.</param>
		/// <param name="timeServerURL">Specifies the URL of a time server which is used to get a time stamp for the certification.</param>
		public DigitalSignature(X509Certificate2 x509, string timeServerURL)
		{
			this.x509Certificate2_0 = x509;
			this.string_0 = timeServerURL;
		}
	}
}
