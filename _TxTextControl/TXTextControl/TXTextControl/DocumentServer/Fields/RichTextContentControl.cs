using System.ComponentModel;
using ns1;
using TXTextControl;

namespace DocumentServer.Fields
{
	/// <summary>The RichTextContentControl implements the MS Word specific plain text content control field.</summary>
	public class RichTextContentControl : ContentControlFieldAdapter
	{
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

		/// <summary>Initializes a new instance of the RichTextContentControl class with a connection to an existing ApplicationField.</summary>
		/// <param name="appField">Specifies the ApplicationField to be adapted.</param>
		public RichTextContentControl(ApplicationField appField)
			: base(appField)
		{
		}

		/// <summary>Initializes complete new instance of the RichTextContentControl class without a connection to an existing ApplicationField.</summary>
		public RichTextContentControl()
		{
		}

		protected override void SetParameters()
		{
			base.ApplicationField.Parameters = new string[1] { base.XmlBaseStructure.OuterXml };
		}
	}
}
