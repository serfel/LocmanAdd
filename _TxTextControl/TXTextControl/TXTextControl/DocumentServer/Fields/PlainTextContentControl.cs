using System.ComponentModel;
using ns1;
using TXTextControl;

namespace DocumentServer.Fields
{
	/// <summary>The PlainTextContentControl implements the MS Word specific plain text content control field.</summary>
	public class PlainTextContentControl : ContentControlFieldAdapter
	{
		internal const string string_0 = "text";

		/// <summary>Gets or sets the text of the content control field.</summary>
		[Category("Properties")]
		[Attribute1("PROP_FIELD_TEXT")]
		public string Text
		{
			get
			{
				return base.ApplicationField.Text ?? string.Empty;
			}
			set
			{
				base.ApplicationField.Text = value ?? string.Empty;
				this.SetParameters();
			}
		}

		/// <summary>Initializes a new instance of the PlainTextContentControl class with a connection to an existing ApplicationField.</summary>
		/// <param name="appField">Specifies the ApplicationField to be adapted.</param>
		public PlainTextContentControl(ApplicationField appField)
			: base(appField)
		{
		}

		/// <summary>Initializes complete new instance of the PlainTextContentControl class without a connection to an existing ApplicationField.</summary>
		public PlainTextContentControl()
		{
		}

		protected override void SetParameters()
		{
			base.ApplicationField.Parameters = new string[1] { base.XmlBaseStructure.OuterXml };
		}
	}
}
