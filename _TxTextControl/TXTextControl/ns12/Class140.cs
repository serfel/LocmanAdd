using DocumentServer.Fields;

namespace ns12
{
	internal class Class140
	{
		private FormText formText_0;

		public string String_0
		{
			get
			{
				return this.formText_0.HelpText;
			}
			set
			{
				this.formText_0.HelpText = value;
			}
		}

		public string String_1
		{
			get
			{
				return this.formText_0.StatusText;
			}
			set
			{
				this.formText_0.StatusText = value;
			}
		}

		public string String_2
		{
			get
			{
				return this.formText_0.Name;
			}
			set
			{
				this.formText_0.Name = value;
			}
		}

		public string String_3
		{
			get
			{
				return this.formText_0.Text;
			}
			set
			{
				this.formText_0.Text = value;
			}
		}

		public int Int32_0
		{
			get
			{
				return (int)this.formText_0.Type;
			}
			set
			{
				if (0 <= value && value <= 5)
				{
					this.formText_0.Type = (FormText.FormTextBoxType)value;
				}
			}
		}

		public int Int32_1
		{
			get
			{
				return (int)this.formText_0.Format;
			}
			set
			{
				this.formText_0.Format = ((0 > value || value > 4) ? this.formText_0.Format : ((TextFormatOptions)value));
			}
		}

		public int Int32_2
		{
			get
			{
				return this.formText_0.MaxLength;
			}
			set
			{
				this.formText_0.MaxLength = value;
			}
		}

		public bool Boolean_0
		{
			get
			{
				return this.formText_0.CalcOnExit;
			}
			set
			{
				this.formText_0.CalcOnExit = value;
			}
		}

		public bool Boolean_1
		{
			get
			{
				return this.formText_0.Enabled;
			}
			set
			{
				this.formText_0.Enabled = value;
			}
		}

		public Class140(FormText formText_1)
		{
			this.formText_0 = formText_1;
		}
	}
}
