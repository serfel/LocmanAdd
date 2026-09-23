using System.ComponentModel;
using ns21;

namespace TXTextControl
{
	/// <summary>The FontSettings class provides settings determining which fonts can be used in a document.</summary>
	[TypeConverter(typeof(Class417))]
	public class FontSettings
	{
		private TextControlCore textControlCore_0;

		private TextControlCore.Delegate9 delegate9_0;

		private bool bool_0;

		private bool bool_1;

		private bool bool_2;

		private bool bool_3;

		/// <summary>Specifies whether a TextControl.AdaptFont event is raised, if a font must be adapted.</summary>
		[Category("Behavior")]
		[Attribute3("PROP_FS_ADAPTFONTEVENT")]
		[DefaultValue(false)]
		public bool AdaptFontEvent
		{
			get
			{
				return this.bool_0;
			}
			set
			{
				if (this.bool_0 != value)
				{
					this.bool_0 = value;
					this.method_3();
				}
			}
		}

		/// <summary>Gets or sets a value specifying that only embeddable fonts can be used in a document.</summary>
		[Attribute3("PROP_FS_EMBEDDABLEFONTSONLY")]
		[Category("Behavior")]
		[DefaultValue(false)]
		public bool EmbeddableFontsOnly
		{
			get
			{
				return this.bool_1;
			}
			set
			{
				if (this.bool_1 != value)
				{
					this.bool_1 = value;
					this.method_3();
				}
			}
		}

		/// <summary>Gets or sets a value specifying that only free scalable fonts can be used in a document.</summary>
		[Attribute3("PROP_FS_TRUETYPEONLY")]
		[Category("Behavior")]
		[DefaultValue(false)]
		public bool ScalableFontsOnly
		{
			get
			{
				return this.bool_2;
			}
			set
			{
				if (this.bool_2 != value)
				{
					this.bool_2 = value;
					this.method_3();
				}
			}
		}

		/// <summary>Gets or sets a value specifying that only TrueType and OpenType fonts can be used in a document.</summary>
		[Category("Behavior")]
		[DefaultValue(false)]
		[Attribute3("PROP_FS_SCALABLEFONTSONLY")]
		public bool TrueTypeFontsOnly
		{
			get
			{
				return this.bool_3;
			}
			set
			{
				if (this.bool_3 != value)
				{
					this.bool_3 = value;
					this.method_3();
				}
			}
		}

		internal void method_0(TextControlCore textControlCore_1, TextControlCore.Delegate9 delegate9_1)
		{
			this.textControlCore_0 = textControlCore_1;
			this.delegate9_0 = delegate9_1;
			this.method_3();
		}

		internal void method_1()
		{
			if (!this.method_2())
			{
				this.bool_1 = false;
				this.bool_2 = false;
				this.bool_0 = false;
				this.bool_3 = false;
			}
			this.method_3();
		}

		internal bool method_2()
		{
			if (!this.bool_1 && !this.bool_0 && !this.bool_3)
			{
				return !this.bool_2;
			}
			return false;
		}

		internal void method_3()
		{
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated)
			{
				this.textControlCore_0.method_75(Enum83.const_255, (this.bool_2 ? 1 : 0) | (this.bool_1 ? 2 : 0) | (this.bool_3 ? 4 : 0), this.bool_0 ? this.delegate9_0 : null);
			}
		}
	}
}
