using System.ComponentModel;
using System.Drawing;
using ns1;
using TXTextControl;

namespace DocumentServer.Fields
{
	/// <summary>The abstract FormFieldAdapter class is the base class of all special DocumentServer form field adapters.</summary>
	public abstract class FormFieldAdapter : FieldAdapter
	{
		public new const string TYPE_NAME = "FORM_FIELD_ADAPTER";

		protected Font m_font;

		protected Rectangle m_rectBounds;

		/// <summary>Gets and sets the name of the form field.</summary>
		[Category("Properties")]
		[Attribute1("PROP_FIELD_NAME")]
		public string Name
		{
			get
			{
				return base.ApplicationField.Name ?? string.Empty;
			}
			set
			{
				base.ApplicationField.Name = value ?? string.Empty;
				this.SetParameters();
			}
		}

		/// <summary>Gets and sets the text of the form field.</summary>
		[Category("Properties")]
		[Attribute1("PROP_FRMFLDADAPT_TEXT")]
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

		/// <summary>Gets and sets the font of the form field.</summary>
		[Category("Properties")]
		[Attribute1("PROP_FRMFLDADAPT_FONT")]
		public Font Font
		{
			get
			{
				return this.m_font;
			}
			set
			{
				this.m_font = value;
			}
		}

		/// <summary>Gets and sets the bounds of the form field.</summary>
		[Category("Properties")]
		[Attribute1("PROP_FRMFLDADAPT_BOUNDS")]
		public Rectangle Bounds
		{
			get
			{
				return this.m_rectBounds;
			}
			set
			{
				this.m_rectBounds = value;
			}
		}

		/// <summary>Gets or sets the CalcOnExit property of the field.</summary>
		public abstract bool CalcOnExit { get; set; }

		/// <summary>Specifies whether the field is enabled or not.</summary>
		public abstract bool Enabled { get; set; }

		/// <summary>Gets and sets the help text of the field.</summary>
		public abstract string HelpText { get; set; }

		/// <summary>Gets and sets the status text of the field.</summary>
		public abstract string StatusText { get; set; }

		/// <summary>Initializes a new instance of the FormFieldAdapter class with a connection to an existing ApplicationField.</summary>
		/// <param name="appField">Specifies the to-be-adapted ApplicationField.</param>
		public FormFieldAdapter(ApplicationField appField)
			: base(appField)
		{
		}

		/// <summary>Initializes a complete new instance of the FormFieldAdapter class without a connection to an existing ApplicationField.</summary>
		public FormFieldAdapter()
		{
		}
	}
}
