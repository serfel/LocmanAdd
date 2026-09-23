using System;
using System.ComponentModel;
using System.Drawing;
using ns21;

namespace TXTextControl
{
	/// <summary>The AutoSize class is used with the TextControl.AutoControlSize property, to enable automatic expansion or shrinking of a Text Control's width or height.</summary>
	[TypeConverter(typeof(Class417))]
	public class AutoSize
	{
		private enum Enum46
		{
			const_0 = 1,
			const_1 = 2,
			const_2 = 4,
			const_3 = 8,
			const_4 = 0x10,
			const_5 = 0x20
		}

		private AutoSizeDirection autoSizeDirection_0 = AutoSizeDirection.None;

		private AutoSizeDirection autoSizeDirection_1 = AutoSizeDirection.None;

		private Size size_0 = new Size(0, 0);

		private Size size_1 = new Size(0, 0);

		private TextControlCore textControlCore_0;

		/// <summary>Gets or sets possible directions for expanding the control.</summary>
		[DefaultValue(AutoSizeDirection.None)]
		[Attribute3("PROP_AUTOSIZE_EXPAND")]
		public AutoSizeDirection AutoExpand
		{
			get
			{
				return this.autoSizeDirection_0;
			}
			set
			{
				if (value != this.autoSizeDirection_0)
				{
					this.method_4(this.size_0, this.size_1);
					this.autoSizeDirection_0 = value;
					this.method_5();
				}
			}
		}

		/// <summary>Gets or sets possible directions for shrinking the control.</summary>
		[DefaultValue(AutoSizeDirection.None)]
		[Attribute3("PROP_AUTOSIZE_SHRINK")]
		public AutoSizeDirection AutoShrink
		{
			get
			{
				return this.autoSizeDirection_1;
			}
			set
			{
				if (value != this.autoSizeDirection_1)
				{
					this.method_4(this.size_0, this.size_1);
					this.autoSizeDirection_1 = value;
					this.method_5();
				}
			}
		}

		/// <summary>Gets or sets the maximum size, in pixels, for expanding the control.</summary>
		[Attribute3("PROP_AUTOSIZE_MAXSIZE")]
		public Size MaxSize
		{
			get
			{
				return this.size_0;
			}
			set
			{
				this.method_4(value, this.size_1);
				this.size_0 = value;
				this.method_5();
			}
		}

		/// <summary>Gets or sets the minimum size, in pixels, for shrinking the control.</summary>
		[Attribute3("PROP_AUTOSIZE_MINSIZE")]
		public Size MinSize
		{
			get
			{
				return this.size_1;
			}
			set
			{
				this.method_4(this.size_0, value);
				this.size_1 = value;
				this.method_5();
			}
		}

		public AutoSize()
		{
			this.method_1();
		}

		/// <summary>Initializes a new instance of the AutoSize class. The constructor offers the individual setting of all features.</summary>
		/// <param name="expand">Specifies possible directions for expanding the control.</param>
		/// <param name="shrink">Specifies possible directions for shrinking the control.</param>
		/// <param name="maxSize">Specifies the maximum size, in twips, for expanding the control.</param>
		/// <param name="minSize">Specifies the minimum size, in twips, for shrinking the control.</param>
		public AutoSize(AutoSizeDirection expand, AutoSizeDirection shrink, Size maxSize, Size minSize)
		{
			this.autoSizeDirection_0 = expand;
			this.autoSizeDirection_1 = shrink;
			this.size_0 = maxSize;
			this.size_1 = minSize;
		}

		public bool ShouldSerializeMaxSize()
		{
			return !this.size_0.IsEmpty;
		}

		public void ResetMaxSize()
		{
			this.MaxSize = new Size(0, 0);
		}

		public bool ShouldSerializeMinSize()
		{
			return !this.size_1.IsEmpty;
		}

		public void ResetMinSize()
		{
			this.MinSize = new Size(0, 0);
		}

		internal void method_0(TextControlCore textControlCore_1)
		{
			this.textControlCore_0 = textControlCore_1;
		}

		internal void method_1()
		{
			this.autoSizeDirection_0 = AutoSizeDirection.None;
			this.autoSizeDirection_1 = AutoSizeDirection.None;
			this.size_0 = new Size(0, 0);
			this.size_1 = new Size(0, 0);
			this.method_5();
		}

		internal void method_2(AutoSize autoSize_0)
		{
			autoSize_0.autoSizeDirection_0 = this.autoSizeDirection_0;
			autoSize_0.autoSizeDirection_1 = this.autoSizeDirection_1;
			autoSize_0.size_0 = this.size_0;
			autoSize_0.size_1 = this.size_1;
		}

		internal bool method_3()
		{
			if (this.autoSizeDirection_0 == AutoSizeDirection.None && this.autoSizeDirection_1 == AutoSizeDirection.None && this.size_0.IsEmpty)
			{
				return this.size_1.IsEmpty;
			}
			return false;
		}

		internal void method_4(Size size_2, Size size_3)
		{
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated && this.textControlCore_0.GetTextControl().GetViewMode() != ViewMode.SimpleControl)
			{
				throw new ArgumentException(this.textControlCore_0.method_83("ERR_AUTOSIZE"), "ViewMode");
			}
			if (size_2.Width > 32767)
			{
				throw new ArgumentOutOfRangeException("MaxSize.Width");
			}
			if (size_2.Height > 32767)
			{
				throw new ArgumentOutOfRangeException("MaxSize.Height");
			}
			if (size_3.Width > 32767)
			{
				throw new ArgumentOutOfRangeException("MinSize.Width");
			}
			if (size_3.Height > 32767)
			{
				throw new ArgumentOutOfRangeException("MinSize.Height");
			}
		}

		internal void method_5()
		{
			if (this.textControlCore_0 != null && this.textControlCore_0.isHandleCreated && this.textControlCore_0.GetTextControl().GetViewMode() == ViewMode.SimpleControl)
			{
				Enum46 @enum = (Enum46)0;
				switch (this.autoSizeDirection_0)
				{
				case AutoSizeDirection.Vertical:
					@enum |= Enum46.const_2;
					break;
				case AutoSizeDirection.Horizontal:
					@enum |= Enum46.const_1;
					break;
				case AutoSizeDirection.Both:
					@enum |= (Enum46)6;
					break;
				}
				switch (this.autoSizeDirection_1)
				{
				case AutoSizeDirection.Vertical:
					@enum |= Enum46.const_4;
					break;
				case AutoSizeDirection.Horizontal:
					@enum |= Enum46.const_3;
					break;
				case AutoSizeDirection.Both:
					@enum |= (Enum46)24;
					break;
				}
				if (@enum != 0)
				{
					@enum |= Enum46.const_5;
				}
				this.textControlCore_0.method_30(Enum83.const_30, ((@enum & Enum46.const_1) != 0) ? 65536 : int.MinValue, 0);
				int[] int_ = new int[4]
				{
					this.size_0.Width,
					this.size_0.Height,
					this.size_1.Width,
					this.size_1.Height
				};
				this.textControlCore_0.method_41(Enum83.const_140, (int)@enum, int_);
			}
		}
	}
}
