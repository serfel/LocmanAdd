using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using ns0;

namespace TXTextControl.Barcode
{
	/// <summary>The TXBarcodeControl class provides properties to specify type and format of barcodes rendered in Windows Forms.</summary>
	[ToolboxBitmap(typeof(TXBarcodeControl))]
	public class TXBarcodeControl : Control, INotifyPropertyChanged
	{
		internal TXBarcodeCore txbarcodeCore_0;

		internal Metafile metafile_0;

		private Metafile metafile_1;

		private Metafile metafile_2;

		internal int int_0;

		internal float float_0;

		private bool bool_0 = true;

		private bool bool_1 = true;

		private bool bool_2;

		private RectangleF rectangleF_0;

		private Class30 class30_0;

		private BarcodeTypeSettings barcodeTypeSettings_0;

		private PropertyChangedEventHandler propertyChangedEventHandler_0;

		/// <summary>Gets or sets an additional text that is displayed below or above the barcode image.</summary>
		[Attribute0("PROP_ADDITIONALTEXT")]
		[Category("Appearance")]
		public string AdditionalText
		{
			get
			{
				return this.txbarcodeCore_0.class38_0.String_0;
			}
			set
			{
				Class38 class38_ = new Class38(this.txbarcodeCore_0);
				string string_ = this.txbarcodeCore_0.class38_0.String_0;
				string text2 = (this.txbarcodeCore_0.class38_0.String_0 = value);
				if (string_ != text2)
				{
					if (this.bool_2)
					{
						this.UpdateImage();
					}
					this.method_10(class38_);
				}
			}
		}

		/// <summary>Gets or sets the alignment of the barcode image inside the control.</summary>
		[DefaultValue(Alignment.MiddleCenter)]
		[Attribute0("PROP_ALIGNMENT")]
		[Category("Layout")]
		public Alignment Alignment
		{
			get
			{
				return this.txbarcodeCore_0.class38_0.Alignment_0;
			}
			set
			{
				Class38 class38_ = new Class38(this.txbarcodeCore_0);
				Alignment alignment_ = this.txbarcodeCore_0.class38_0.Alignment_0;
				Alignment alignment2 = (this.txbarcodeCore_0.class38_0.Alignment_0 = value);
				if (alignment_ != alignment2)
				{
					if (this.bool_2)
					{
						this.UpdateImage();
					}
					this.method_10(class38_);
				}
			}
		}

		/// <summary>Gets or sets the angle of the barcode image inside the control.</summary>
		[Attribute0("PROP_ANGLE")]
		[DefaultValue(typeof(int), "0")]
		[Category("Layout")]
		public int Angle
		{
			get
			{
				return this.int_0;
			}
			set
			{
				Class38 class38_ = new Class38(this.txbarcodeCore_0);
				if (this.int_0 != (this.int_0 = value))
				{
					if (this.bool_2)
					{
						this.UpdateImage();
					}
					this.method_10(class38_);
				}
			}
		}

		/// <summary>Gets or sets the background color for the barcode control.</summary>
		[DefaultValue(typeof(Color), "Window")]
		[Attribute0("PROP_BACKCOLOR")]
		public override Color BackColor
		{
			get
			{
				return base.BackColor;
			}
			set
			{
				base.BackColor = value;
				if (this.bool_2)
				{
					this.OnBackColorChanged(new EventArgs());
					this.bool_0 = true;
					this.bool_1 = true;
					this.Refresh();
				}
			}
		}

		/// <summary>Gets or sets the type of barcode that is rendered.</summary>
		[DefaultValue(BarcodeType.QRCode)]
		[Attribute0("PROP_BARCODETYPE")]
		[Category("Data")]
		public BarcodeType BarcodeType
		{
			get
			{
				return this.txbarcodeCore_0.barcodeType_0;
			}
			set
			{
				Class38 class38_ = new Class38(this.txbarcodeCore_0);
				if (this.txbarcodeCore_0.barcodeType_0 != (this.txbarcodeCore_0.barcodeType_0 = value))
				{
					if (this.bool_2)
					{
						this.txbarcodeCore_0.method_12(value);
						this.UpdateImage();
					}
					this.method_10(class38_);
				}
			}
		}

		/// <summary>Gets an object of type BarcodeTypeSettings to determine type specific settings for the current used barcode.</summary>
		[Browsable(false)]
		public BarcodeTypeSettings BarcodeTypeSettings => this.barcodeTypeSettings_0;

		/// <summary>Gets or sets the foreground color for the barcode.</summary>
		[Attribute0("PROP_FORECOLOR")]
		[DefaultValue(typeof(Color), "WindowText")]
		public override Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				base.ForeColor = value;
				if (this.bool_2)
				{
					this.OnForeColorChanged(new EventArgs());
					this.UpdateImage();
				}
			}
		}

		/// <summary>Gets or sets a value indicating whether the encrypted barcode text value is displayed below or above the barcode image or not.</summary>
		[DefaultValue(true)]
		[Category("Behavior")]
		[Attribute0("PROP_SHOWTEXT")]
		public bool ShowText
		{
			get
			{
				return this.txbarcodeCore_0.class38_0.Boolean_2;
			}
			set
			{
				Class38 class38_ = new Class38(this.txbarcodeCore_0);
				bool boolean_ = this.txbarcodeCore_0.class38_0.Boolean_2;
				bool flag2 = (this.txbarcodeCore_0.class38_0.Boolean_2 = value);
				if (boolean_ != flag2)
				{
					if (this.bool_2)
					{
						this.UpdateImage();
					}
					this.method_10(class38_);
				}
			}
		}

		/// <summary>Gets or sets the text the barcode should encrypt.</summary>
		[Attribute0("PROP_TEXT")]
		public override string Text
		{
			get
			{
				return this.txbarcodeCore_0.class38_0.Text;
			}
			set
			{
				Class38 class38_ = new Class38(this.txbarcodeCore_0);
				string string_ = this.txbarcodeCore_0.class38_0.Text;
				string text2 = (this.txbarcodeCore_0.class38_0.Text = value);
				if (!(string_ != text2))
				{
					return;
				}
				if (this.bool_2)
				{
					string string_2;
					
					//------------------------------------------------------------------------------------------
					this.txbarcodeCore_0.class38_0.UpperTextLength = this.txbarcodeCore_0.class38_0.Text.Length;
					//------------------------------------------------------------------------------------------

					bool flag = this.txbarcodeCore_0.method_15(this.txbarcodeCore_0.class38_0.Text, out string_2);
					TextValidatedEventArgs textValidatedEventArgs = new TextValidatedEventArgs(this.txbarcodeCore_0.barcodeType_0, this.txbarcodeCore_0.class38_0.Text, !flag, string_2);
					if (textValidatedEventArgs.IsInvalidText)
					{
						throw new ArgumentException(textValidatedEventArgs.ErrorMessage);
					}
					this.txbarcodeCore_0.method_10(value);
					this.OnTextChanged(new EventArgs());
					this.UpdateImage();
				}
				this.method_10(class38_);
			}
		}

		/// <summary>Gets or sets a value indicating whether the barcode text and additional text is displayed below or above the barcode image.</summary>
		[Attribute0("PROP_TEXTALIGNMENT")]
		[Category("Layout")]
		[DefaultValue(TextAlignment.Bottom)]
		public TextAlignment TextAlignment
		{
			get
			{
				return this.txbarcodeCore_0.class38_0.TextAlignment_0;
			}
			set
			{
				Class38 class38_ = new Class38(this.txbarcodeCore_0);
				TextAlignment textAlignment_ = this.txbarcodeCore_0.class38_0.TextAlignment_0;
				TextAlignment textAlignment2 = (this.txbarcodeCore_0.class38_0.TextAlignment_0 = value);
				if (textAlignment_ != textAlignment2)
				{
					if (this.bool_2)
					{
						this.UpdateImage();
					}
					this.method_10(class38_);
				}
			}
		}

		/// <summary>Gets or sets the maximum number of characters the Text property can get.</summary>
		[Category("Behavior")]
		[Attribute0("PROP_UPPERTEXTLENGTH")]
		public int UpperTextLength
		{
			get
			{
				return this.txbarcodeCore_0.class38_0.UpperTextLength;
			}
			set
			{
				Class38 class38_ = new Class38(this.txbarcodeCore_0);
				int int32_ = this.txbarcodeCore_0.class38_0.UpperTextLength;
				int num2 = (this.txbarcodeCore_0.class38_0.UpperTextLength = value);
				if (int32_ != num2)
				{
					if (this.bool_2)
					{
						this.txbarcodeCore_0.method_13(value);
						this.UpdateImage();
					}
					this.method_10(class38_);
				}
			}
		}

		[Obfuscation(Exclude = true)]
		internal Class26 BackColorAsInternalColor => this.method_7(this.BackColor);

		[Obfuscation(Exclude = true)]
		internal Class26 ForeColorAsInternalColor => this.method_7(this.ForeColor);

		[Obfuscation(Exclude = true)]
		internal Class25 ControlSize => new Class25(base.Width, base.Height);

		public event PropertyChangedEventHandler PropertyChanged
		{
			add
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChangedEventHandler_0;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange(ref this.propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
				}
				while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
			}
			remove
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChangedEventHandler_0;
				PropertyChangedEventHandler propertyChangedEventHandler2;
				do
				{
					propertyChangedEventHandler2 = propertyChangedEventHandler;
					PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
					propertyChangedEventHandler = Interlocked.CompareExchange(ref this.propertyChangedEventHandler_0, value2, propertyChangedEventHandler2);
				}
				while ((object)propertyChangedEventHandler != propertyChangedEventHandler2);
			}
		}

		/// <summary>Initializes a new instance of the TXBarcodeControl class.</summary>
		public TXBarcodeControl()
		{
			base.SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, value: true);
			base.Size = new Size(150, 150);
			this.txbarcodeCore_0 = new TXBarcodeCore();
			this.txbarcodeCore_0.class21_0 = new Class21(this);
			this.barcodeTypeSettings_0 = new BarcodeTypeSettings(this.txbarcodeCore_0, this);
			this.BackColor = SystemColors.Window;
			this.ForeColor = SystemColors.WindowText;
			this.DoubleBuffered = true;
		}

		private Class30 method_0(float float_1)
		{
			int num = Math.Min(base.Width, base.Height);
			Math.Max(base.Width, base.Height);
			Class23 @class = (this.txbarcodeCore_0.barcodeInfo_0.m_bIs2DBarcode ? new Class23(num, num) : new Class23(base.Width, base.Height));
			float num2 = ((@class.float_0 >= @class.float_1) ? @class.float_0 : @class.float_1);
			float num3 = ((@class.float_0 >= @class.float_1) ? @class.float_1 : @class.float_0);
			float num4 = float_1 % 360f;
			num4 = ((num4 < 0f) ? (360f - Math.Abs(num4)) : num4);
			num4 = ((num4 >= 270f) ? (90f - (num4 - 270f)) : ((num4 >= 180f) ? (num4 - 180f) : ((num4 >= 90f) ? (90f - (num4 - 90f)) : num4)));
			if (this.txbarcodeCore_0.barcodeInfo_0.m_ctType != BarcodeType.PDF417 && this.txbarcodeCore_0.barcodeInfo_0.m_ctType != BarcodeType.MicroPDF && this.txbarcodeCore_0.barcodeInfo_0.m_ctType != BarcodeType.Maxicode)
			{
				double num5 = Math.Atan((double)num3 / (double)num2) * 180.0 / Math.PI;
				double num6 = 90.0 - ((double)num4 + num5);
				double num7 = (double)num3 / Math.Cos(num6 * Math.PI / 180.0);
				double num8 = Math.Sin(num5 * Math.PI / 180.0) * num7;
				double num9 = Math.Cos(num5 * Math.PI / 180.0) * num7;
				Class30 result = ((@class.float_0 >= @class.float_1) ? new Class30(0f, 0f, (float)num9, (float)num8) : new Class30(0f, 0f, (float)num8, (float)num9));
				num4 = float_1;
				return result;
			}
			@class = this.method_1(base.Width, base.Height, num4);
			num4 = float_1;
			return new Class30(0f, 0f, @class.float_0, @class.float_1);
		}

		private Class23 method_1(float float_1, float float_2, float float_3)
		{
			double num = Math.Atan((double)(this.txbarcodeCore_0.class38_0.Nullable_0.Value + (float)this.txbarcodeCore_0.barcodeInfo_0.m_qzQuietZone.int_1 + (float)this.txbarcodeCore_0.barcodeInfo_0.m_qzQuietZone.int_3) / (double)(this.txbarcodeCore_0.class38_0.Single_0 + (float)this.txbarcodeCore_0.barcodeInfo_0.m_qzQuietZone.int_0 + (float)this.txbarcodeCore_0.barcodeInfo_0.m_qzQuietZone.int_2)) * 180.0 / Math.PI;
			double num2 = 90.0 - ((double)float_3 + num);
			double num3 = (double)float_2 / Math.Cos(num2 * Math.PI / 180.0);
			double num4 = Math.Cos(((double)float_3 - num) * Math.PI / 180.0) * num3;
			double num5 = Math.Sin(num * Math.PI / 180.0) * num3;
			double num6 = Math.Cos(num * Math.PI / 180.0) * num3;
			if (num4 > (double)float_1)
			{
				double num7 = (double)float_1 / num4;
				num5 *= num7;
				num6 *= num7;
			}
			return new Class23((float)num6, (float)num5);
		}

		private Metafile method_2(RectangleF rectangleF_1)
		{
			Class23 @class = new Class23(rectangleF_1.Width + 2f * rectangleF_1.X, rectangleF_1.Height + 2f * rectangleF_1.Y);
			Graphics graphics = Graphics.FromHwndInternal(IntPtr.Zero);
			IntPtr hdc = graphics.GetHdc();
			Metafile metafile = new Metafile(new MemoryStream(), hdc, new Rectangle(0, 0, (int)this.class30_0.float_2, (int)this.class30_0.float_3), MetafileFrameUnit.Pixel);
			graphics.ReleaseHdc();
			graphics.Dispose();
			graphics = Graphics.FromImage(metafile);
			graphics.PixelOffsetMode = PixelOffsetMode.None;
			if (!this.txbarcodeCore_0.barcodeInfo_0.m_bIs2DBarcode)
			{
				graphics.SmoothingMode = SmoothingMode.AntiAlias;
			}
			Class40 class2 = this.txbarcodeCore_0.method_0(Class22.smethod_4(this.class30_0.Class23_0, graphics.DpiX, graphics.DpiY), Class22.smethod_4(@class, graphics.DpiX, graphics.DpiY), this.txbarcodeCore_0.class38_0.Alignment_0);
			float num = Class22.smethod_6(class2.float_0, graphics.DpiX);
			float num2 = Class22.smethod_6(class2.float_1, graphics.DpiY);
			this.rectangleF_0 = new RectangleF(num, num2, @class.float_0, @class.float_1);
			SolidBrush brush = new SolidBrush(this.ForeColor);
			bool flag = this.txbarcodeCore_0.class38_0.Boolean_2 && !this.txbarcodeCore_0.barcodeInfo_0.m_bIs2DBarcode && this.txbarcodeCore_0.barcodeInfo_0.m_ctType != BarcodeType.UPCA;
			bool flag2 = this.txbarcodeCore_0.class38_0.String_0.Length > 0 && !this.txbarcodeCore_0.barcodeInfo_0.m_bIs2DBarcode && this.txbarcodeCore_0.barcodeInfo_0.m_ctType != BarcodeType.UPCA;
			if (this.txbarcodeCore_0.barcodeInfo_0.m_ctType != BarcodeType.UPCA)
			{
				RectangleF rectangleF = new RectangleF(num + rectangleF_1.X, num2 + rectangleF_1.Y, rectangleF_1.Width, rectangleF_1.Height);
				float num3 = ((this.txbarcodeCore_0.barcodeInfo_0.m_ctType == BarcodeType.IntelligentMail) ? (this.float_0 * 1.5f * 8.3f * 72f / graphics.DpiX) : (this.float_0 * 8.3f * 72f / graphics.DpiX));
				Font font = new Font(this.Font.Name, num3);
				string text = "";
				if (flag)
				{
					text = this.txbarcodeCore_0.class38_0.String_1;
				}
				if (flag2)
				{
					if (text.Length > 0 && this.txbarcodeCore_0.class38_0.String_0.Length > 0)
					{
						text += " ";
					}
					text += this.txbarcodeCore_0.class38_0.String_0;
				}
				SizeF sizeF = graphics.MeasureString(text, font);
				if (flag || flag2)
				{
					while ((sizeF.Width > @class.float_0 || (double)sizeF.Height > (double)Math.Min(this.class30_0.float_3, this.class30_0.float_2) / 2.5) && !((double)num3 <= 0.1))
					{
						num3 -= 1f;
						if (num3 < 0f)
						{
							break;
						}
						font = new Font(this.Font.Name, num3);
						sizeF = graphics.MeasureString(text, font);
					}
				}
				float num4 = ((flag || flag2) ? sizeF.Height : 0f);
				float num5 = (this.txbarcodeCore_0.barcodeInfo_0.m_bIs2DBarcode ? this.float_0 : ((this.class30_0.float_3 - num4) / this.txbarcodeCore_0.class37_0.float_1));
				float num6 = (this.txbarcodeCore_0.barcodeInfo_0.m_bIs2DBarcode ? this.float_0 : num5);
				float num7 = 0f;
				float num8 = ((this.txbarcodeCore_0.class38_0.TextAlignment_0 != TextAlignment.Top || (!flag && !flag2)) ? 0f : sizeF.Height);
				if (this.txbarcodeCore_0.barcodeInfo_0.m_ctType != BarcodeType.Maxicode)
				{
					foreach (Class30 item in this.txbarcodeCore_0.class37_0.list_0)
					{
						num7 = rectangleF.X + item.float_0 * this.float_0;
						graphics.FillRectangle(brush, new RectangleF(num7, num8 + rectangleF.Y + item.float_1 * num6, item.float_2 * this.float_0, item.float_3 * num5));
						num7 += item.float_2 * this.float_0;
					}
					if (flag || flag2)
					{
						StringFormat stringFormat = new StringFormat();
						stringFormat.Alignment = StringAlignment.Center;
						float num9 = ((this.txbarcodeCore_0.class38_0.TextAlignment_0 == TextAlignment.Bottom) ? (this.txbarcodeCore_0.class37_0.float_1 * num5) : 0f);
						graphics.DrawString(text, font, brush, new PointF(rectangleF.X + (num7 - rectangleF.X) / 2f, num9), stringFormat);
					}
				}
				else
				{
					foreach (Class29 item2 in this.txbarcodeCore_0.class37_0.list_2)
					{
						graphics.DrawEllipse(new Pen(brush, this.float_0 * item2.float_0), new RectangleF(rectangleF.X + item2.class30_0.float_0 * this.float_0, rectangleF.Y + item2.class30_0.float_1 * num6, item2.class30_0.float_2 * this.float_0, item2.class30_0.float_3 * num5));
					}
					foreach (Class28 item3 in this.txbarcodeCore_0.class37_0.list_1)
					{
						PointF[] array = new PointF[item3.class33_0.Length];
						for (int i = 0; i < array.Length; i++)
						{
							ref PointF reference = ref array[i];
							reference = new PointF(rectangleF.X + item3.class33_0[i].float_0 * this.float_0, rectangleF.Y + item3.class33_0[i].float_1 * num6);
						}
						graphics.FillPolygon(brush, array, FillMode.Alternate);
					}
				}
			}
			else
			{
				RectangleF rectangleF2 = new RectangleF(num + rectangleF_1.X, num2 + rectangleF_1.Y, rectangleF_1.Width, rectangleF_1.Height);
				float num10 = this.float_0 * 9f;
				float num11 = this.class30_0.float_3 / this.txbarcodeCore_0.class37_0.float_1;
				float num12 = num11;
				float num13 = 0f;
				float emSize = this.float_0 * 8.3f * 72f / graphics.DpiX;
				float num14 = 0f;
				foreach (Class30 item4 in this.txbarcodeCore_0.class37_0.list_0)
				{
					if (item4.float_3 != this.txbarcodeCore_0.class37_0.float_1)
					{
						num13 = (num14 = this.txbarcodeCore_0.class37_0.float_1 * num11 - num10);
					}
					else
					{
						num14 = this.txbarcodeCore_0.class37_0.float_1 * num11;
					}
					graphics.FillRectangle(brush, new RectangleF(rectangleF2.X + item4.float_0 * this.float_0, rectangleF2.Y + item4.float_1 * num12, item4.float_2 * this.float_0, num14));
				}
				if (this.txbarcodeCore_0.class38_0.Boolean_2)
				{
					StringFormat stringFormat2 = new StringFormat();
					stringFormat2.Alignment = StringAlignment.Center;
					foreach (Class36 item5 in this.txbarcodeCore_0.class37_0.list_3)
					{
						graphics.DrawString(item5.string_0, new Font(this.Font.Name, emSize), brush, new PointF(rectangleF2.X + item5.class33_0.float_0 * this.float_0, num13), stringFormat2);
					}
				}
			}
			graphics.Dispose();
			return metafile;
		}

		private RectangleF method_3()
		{
			float num = (float)this.txbarcodeCore_0.barcodeInfo_0.m_qzQuietZone.int_0 * this.float_0;
			float num2 = (float)this.txbarcodeCore_0.barcodeInfo_0.m_qzQuietZone.int_1 * this.float_0;
			float num3 = this.txbarcodeCore_0.class37_0.float_0 * this.float_0;
			float num4 = ((this.txbarcodeCore_0.barcodeInfo_0.m_ctType == BarcodeType.PDF417 || this.txbarcodeCore_0.barcodeInfo_0.m_ctType == BarcodeType.MicroPDF || this.txbarcodeCore_0.barcodeInfo_0.m_ctType == BarcodeType.Maxicode) ? (this.txbarcodeCore_0.class37_0.float_1 * this.float_0) : (this.txbarcodeCore_0.barcodeInfo_0.m_bIs2DBarcode ? num3 : this.class30_0.float_3));
			float num5 = num;
			float num6 = num2;
			return new RectangleF(num5, num6, num3, num4);
		}

		private float method_4()
		{
			Graphics graphics = Graphics.FromHwnd(IntPtr.Zero);
			float num = Class22.smethod_2(this.txbarcodeCore_0.barcodeInfo_0.m_qzQuietZone.int_0 + this.txbarcodeCore_0.barcodeInfo_0.m_qzQuietZone.int_2, graphics.DpiX);
			_ = this.txbarcodeCore_0.class38_0.Single_0;
			Class22.smethod_6(num, graphics.DpiX);
			return (Class22.smethod_2(this.class30_0.Class23_0.float_0, graphics.DpiX) - Class22.smethod_2(base.Padding.Horizontal, graphics.DpiX)) / (Class22.smethod_2(this.txbarcodeCore_0.class38_0.Single_0, graphics.DpiX) + num);
		}

		private float method_5()
		{
			Graphics graphics = Graphics.FromHwnd(IntPtr.Zero);
			float num = Class22.smethod_2(this.txbarcodeCore_0.barcodeInfo_0.m_qzQuietZone.int_0 + this.txbarcodeCore_0.barcodeInfo_0.m_qzQuietZone.int_2, graphics.DpiX);
			float num2 = Class22.smethod_2(this.txbarcodeCore_0.barcodeInfo_0.m_qzQuietZone.int_1 + this.txbarcodeCore_0.barcodeInfo_0.m_qzQuietZone.int_3, graphics.DpiY);
			if (this.txbarcodeCore_0.barcodeInfo_0.m_ctType != BarcodeType.PDF417 && this.txbarcodeCore_0.barcodeInfo_0.m_ctType != BarcodeType.MicroPDF && this.txbarcodeCore_0.barcodeInfo_0.m_ctType != BarcodeType.Maxicode)
			{
				float val = Class22.smethod_2(this.class30_0.float_2, graphics.DpiX) / (Class22.smethod_2(this.txbarcodeCore_0.class38_0.Single_0, graphics.DpiX) + num);
				float val2 = Class22.smethod_2(this.class30_0.float_3, graphics.DpiY) / (Class22.smethod_2(this.txbarcodeCore_0.class38_0.Single_0, graphics.DpiX) + num2);
				return Math.Min(val, val2);
			}
			return Class22.smethod_2(this.class30_0.float_2, graphics.DpiX) / (Class22.smethod_2(this.txbarcodeCore_0.class38_0.Single_0, graphics.DpiX) + num);
		}

		[Obfuscation(Exclude = true)]
		internal void UpdateImage()
		{
			this.class30_0 = ((this.txbarcodeCore_0.barcodeInfo_0.m_ctType == BarcodeType.PDF417 || this.txbarcodeCore_0.barcodeInfo_0.m_ctType == BarcodeType.MicroPDF || this.txbarcodeCore_0.barcodeInfo_0.m_ctType == BarcodeType.Maxicode) ? this.method_0(this.int_0) : ((this.int_0 % 180 == 0) ? new Class30(0f, 0f, base.Width, base.Height) : ((this.int_0 % 90 != 0 || this.int_0 % 180 == 0) ? this.method_0(this.int_0) : new Class30(0f, 0f, base.Height, base.Width))));
			this.class30_0 = ((this.class30_0.float_3 < 1f || this.class30_0.float_2 < 1f) ? new Class30(0f, 0f, Math.Max(this.class30_0.float_2, 1f), Math.Max(this.class30_0.float_3, 1f)) : this.class30_0);
			if (this.txbarcodeCore_0.barcodeInfo_0.m_bIs2DBarcode)
			{
				this.float_0 = this.method_5();
			}
			else
			{
				this.float_0 = this.method_4();
			}
			RectangleF rectangleF_ = this.method_3();
			this.metafile_0 = this.method_2(rectangleF_);
			this.bool_0 = true;
			this.bool_1 = true;
			this.Refresh();
		}

		private Color method_6(Class26 class26_0)
		{
			if (class26_0.bool_0)
			{
				Color result = Color.FromName(class26_0.string_0);
				if (!result.IsKnownColor)
				{
					result = Color.FromArgb(class26_0.int_0, class26_0.int_1, class26_0.int_2, class26_0.int_3);
				}
				return result;
			}
			return Color.FromArgb(class26_0.int_0, class26_0.int_1, class26_0.int_2, class26_0.int_3);
		}

		private Class26 method_7(Color color_0)
		{
			Class26 @class = new Class26();
			if (color_0.IsKnownColor)
			{
				@class = new Class26(color_0.Name);
			}
			@class.int_0 = color_0.A;
			@class.int_1 = color_0.R;
			@class.int_2 = color_0.G;
			@class.int_3 = color_0.B;
			return @class;
		}

		private Class32 method_8(double double_0)
		{
			double num = (double)this.rectangleF_0.Height / 2.0;
			double num2 = (double)this.rectangleF_0.Width / 2.0;
			double_0 = ((!(double_0 >= 90.0) || double_0 >= 270.0) ? double_0 : (90.0 - (double_0 - 90.0)));
			double num3 = Math.Cos(double_0 * Math.PI / 180.0) * num2;
			double num4 = Math.Cos(double_0 * Math.PI / 180.0) * num;
			double num5 = Math.Sqrt(num2 * num2 - num3 * num3);
			double num6 = Math.Sqrt(num * num - num4 * num4);
			double num7 = num5 + num4;
			double num8 = num6 + num3;
			double num9 = num8 - num2;
			double num10 = num7 - num;
			switch (this.txbarcodeCore_0.class38_0.Alignment_0)
			{
			case Alignment.TopCenter:
				num9 = (float)base.Width / 2f - (float)this.metafile_0.Width / 2f + this.rectangleF_0.X;
				break;
			case Alignment.TopRight:
				num9 = (double)(base.Width - this.metafile_0.Width) - num9 + (double)this.rectangleF_0.X;
				break;
			case Alignment.MiddleLeft:
				num10 = (float)base.Height / 2f - (float)this.metafile_0.Height / 2f + this.rectangleF_0.Y;
				break;
			case Alignment.MiddleCenter:
				num9 = (float)base.Width / 2f - (float)this.metafile_0.Width / 2f + this.rectangleF_0.X;
				num10 = (float)base.Height / 2f - (float)this.metafile_0.Height / 2f + this.rectangleF_0.Y;
				break;
			case Alignment.MiddleRight:
				num9 = (double)(base.Width - this.metafile_0.Width) - num9 + (double)this.rectangleF_0.X;
				num10 = (float)base.Height / 2f - (float)this.metafile_0.Height / 2f + this.rectangleF_0.Y;
				break;
			case Alignment.BottomCenter:
				num9 = (float)base.Width / 2f - (float)this.metafile_0.Width / 2f + this.rectangleF_0.X;
				num10 = (double)(base.Height - this.metafile_0.Height) - num10 + (double)this.rectangleF_0.Y;
				break;
			case Alignment.BottomLeft:
				num10 = (double)(base.Height - this.metafile_0.Height) - num10 + (double)this.rectangleF_0.Y;
				break;
			case Alignment.BottomRight:
				num9 = (double)(base.Width - this.metafile_0.Width) - num9 + (double)this.rectangleF_0.X;
				num10 = (double)(base.Height - this.metafile_0.Height) - num10 + (double)this.rectangleF_0.Y;
				break;
			}
			return new Class32(num9, num10);
		}

		private Metafile method_9(Metafile metafile_3)
		{
			using Matrix matrix = new Matrix();
			Class32 @class = this.method_8(this.int_0 % 360);
			double double_ = @class.double_0;
			double double_2 = @class.double_1;
			matrix.RotateAt(point: new PointF((float)double_ + this.rectangleF_0.Width / 2f, (float)double_2 + this.rectangleF_0.Height / 2f), angle: this.int_0);
			Graphics graphics = Graphics.FromHwndInternal(IntPtr.Zero);
			IntPtr hdc = graphics.GetHdc();
			Metafile metafile = new Metafile(new MemoryStream(), hdc, new Rectangle(0, 0, base.Width, base.Height), MetafileFrameUnit.Pixel);
			graphics.ReleaseHdc();
			graphics.Dispose();
			graphics = Graphics.FromImage(metafile);
			graphics.PixelOffsetMode = PixelOffsetMode.None;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.FillRectangle(new SolidBrush(this.BackColor), new Rectangle(0, 0, base.Width, base.Height));
			graphics.Transform = matrix;
			graphics.DrawImage(metafile_3, new RectangleF((float)double_, (float)double_2, this.rectangleF_0.Width, this.rectangleF_0.Height), this.rectangleF_0, GraphicsUnit.Pixel);
			graphics.Dispose();
			return metafile;
		}

		[Obfuscation(Exclude = true)]
		internal void LoadSerializedData(Class62 p_bdData)
		{
			this.bool_2 = false;
			this.txbarcodeCore_0.class38_0.Alignment_0 = p_bdData.alignment_0;
			this.int_0 = p_bdData.int_1;
			this.txbarcodeCore_0.class38_0.Text = p_bdData.string_1;
			this.txbarcodeCore_0.barcodeType_0 = p_bdData.barcodeType_0;
			this.txbarcodeCore_0.class38_0.UpperTextLength = p_bdData.int_0;
			base.Size = new Size((int)p_bdData.class25_0.double_0, (int)p_bdData.class25_0.double_1);
			this.BackColor = this.method_6(p_bdData.class26_0);
			this.ForeColor = this.method_6(p_bdData.class26_1);
			this.txbarcodeCore_0.class38_0.Boolean_2 = p_bdData.bool_0;
			this.txbarcodeCore_0.method_12(this.txbarcodeCore_0.barcodeType_0);
			this.UpdateImage();
			this.bool_2 = true;
		}

		protected override void OnHandleCreated(EventArgs eventArgs_0)
		{
			base.OnHandleCreated(eventArgs_0);
			if (this.txbarcodeCore_0.class38_0.Text == null || (this.txbarcodeCore_0.class38_0.Text == base.Name && this.txbarcodeCore_0.class38_0.UpperTextLength == 0))
			{
				this.txbarcodeCore_0.class38_0.Text = base.Name;
				this.txbarcodeCore_0.class38_0.UpperTextLength = this.txbarcodeCore_0.class38_0.Text.Length;
			}
			this.txbarcodeCore_0.method_12(this.txbarcodeCore_0.barcodeType_0);
			this.UpdateImage();
			this.bool_2 = true;
		}

		protected override void OnPaddingChanged(EventArgs eventArgs_0)
		{
			base.Padding = new Padding(0);
		}

		protected override void OnPaint(PaintEventArgs pea)
		{
			base.OnPaint(pea);
			try
			{
				if (this.bool_0 || this.metafile_2 == null)
				{
					this.metafile_2 = this.method_9(this.metafile_0);
					this.bool_0 = false;
				}
				pea.Graphics.PixelOffsetMode = PixelOffsetMode.None;
				pea.Graphics.DrawImage(this.metafile_2, new Point(0, 0));
			}
			catch
			{
				this.UpdateImage();
			}
		}

		protected override void OnResize(EventArgs eventArgs_0)
		{
			if (base.Width <= 0)
			{
				base.Width = 1;
			}
			if (base.Height <= 0)
			{
				base.Height = 1;
			}
			if (this.bool_2)
			{
				this.UpdateImage();
			}
			else
			{
				this.class30_0 = new Class30(0f, 0f, base.Width, base.Height);
			}
		}

		private void method_10(Class38 class38_0)
		{
			string[] string_;
			string[] array = class38_0.method_0(out string_);
			string[] array2 = array;
			foreach (string text in array2)
			{
				this.method_11(text);
				if (text == "BarcodeTypeSettings")
				{
					string[] array3 = string_;
					foreach (string string_2 in array3)
					{
						this.barcodeTypeSettings_0.method_0(string_2);
					}
				}
			}
		}

		private void method_11(string string_0)
		{
			if (this.propertyChangedEventHandler_0 != null)
			{
				this.propertyChangedEventHandler_0(this, new PropertyChangedEventArgs(string_0));
			}
		}

		/// <summary>Returns the default text for the specified barcode type.</summary>
		/// <param name="barcodeType">Specifies the barcode type whose default text is returned.</param>
		public static string GetDefaultText(BarcodeType barcodeType)
		{
			return TXBarcodeCore.smethod_0(barcodeType);
		}

		/// <summary>Returns the maximum text length of the specified barcode type.</summary>
		/// <param name="barcodeType">Specifies the barcode type whose maximum text length is returned.</param>
		public static int GetMaximumTextLength(BarcodeType barcodeType)
		{
			return TXBarcodeCore.smethod_2(barcodeType);
		}

		/// <summary>Returns the minimum text length of the specified barcode type.</summary>
		/// <param name="barcodeType">Specifies the barcode type whose minimum text length is returned.</param>
		public static int GetMinimumTextLength(BarcodeType barcodeType)
		{
			return TXBarcodeCore.smethod_3(barcodeType);
		}

		/// <summary>Returns a value indicating whether the specified text is valid for a specific barcode type. In case of an invalid text, an exception message is saved into the specified string.</summary>
		/// <param name="barcodeType">Specifies the barcode type whose text is checked.</param>
		/// <param name="text">Specifies the text to check.</param>
		/// <param name="errorMessage">Specifies the string, an appropriate exception message is saved to, if the checked text is not valid for a specific barcode type.</param>
		public static bool IsTextValid(BarcodeType barcodeType, string text, out string errorMessage)
		{
			return TXBarcodeCore.smethod_4(barcodeType, text, out errorMessage);
		}

		[Obfuscation(Exclude = true)]
		internal bool ValidateText(BarcodeType barcodeType, string text, out string errorMessage)
		{
			bool flag = TXBarcodeCore.smethod_4(barcodeType, text, out errorMessage);
			TextValidatedEventArgs textValidatedEventArgs = new TextValidatedEventArgs(barcodeType, text, !flag, errorMessage);
			errorMessage = textValidatedEventArgs.ErrorMessage;
			return !textValidatedEventArgs.IsInvalidText;
		}

		/// <summary>Loads barcode data into the control from a specified object of type System.IO.Stream. The data format must be XML.</summary>
		/// <param name="stream">Specifies an object of type System.IO.Stream the data is loaded from.</param>
		public void Load(Stream stream)
		{
			Class38 class38_ = new Class38(this.txbarcodeCore_0);
			this.txbarcodeCore_0.method_1(stream, SerializationFormat.Xml);
			this.method_10(class38_);
		}

		/// <summary>Loads barcode data into the control with the specified format. The new barcode is read from the specified object of type System.IO.Stream.</summary>
		/// <param name="stream">Specifies an object of type System.IO.Stream the data is loaded from.</param>
		/// <param name="format">Specifies the format used to deserialize the barcode.</param>
		public void Load(Stream stream, SerializationFormat format)
		{
			Class38 class38_ = new Class38(this.txbarcodeCore_0);
			this.txbarcodeCore_0.method_1(stream, format);
			this.method_10(class38_);
		}

		/// <summary>Loads barcode data into the control from a specified file. The data format must be XML.</summary>
		/// <param name="fileName">Specifies a file the data is loaded from.</param>
		public void Load(string fileName)
		{
			Class38 class38_ = new Class38(this.txbarcodeCore_0);
			this.Load(fileName, SerializationFormat.Xml);
			this.method_10(class38_);
		}

		/// <summary>Loads barcode data into the control with the specified format. The new barcode is read from the specified file.</summary>
		/// <param name="fileName">Specifies a file the data is loaded from.</param>
		/// <param name="format">Specifies the format used to deserialize the barcode.</param>
		public void Load(string fileName, SerializationFormat format)
		{
			Class38 class38_ = new Class38(this.txbarcodeCore_0);
			this.txbarcodeCore_0.method_2(fileName, format);
			this.method_10(class38_);
		}

		/// <summary>Loads barcode data into the control from a specified object of type System.IO.TextReader. The data format must be XML.</summary>
		/// <param name="textReader">Specifies an object of type System.IO.TextReader the data is loaded from.</param>
		public void Load(TextReader textReader)
		{
			Class38 class38_ = new Class38(this.txbarcodeCore_0);
			this.txbarcodeCore_0.method_3(textReader);
			this.method_10(class38_);
		}

		/// <summary>Loads barcode data into the control from a specified object of type System.Xml.XmlReader. The data format must be XML.</summary>
		/// <param name="xmlReader">Specifies an object of type System.IO.XmlReader the data is loaded from.</param>
		public void Load(XmlReader xmlReader)
		{
			Class38 class38_ = new Class38(this.txbarcodeCore_0);
			this.txbarcodeCore_0.method_4(xmlReader);
			this.method_10(class38_);
		}

		/// <summary>Draws the barcode on the specified System.Drawing.Graphics object.</summary>
		/// <param name="graphics">Specifies the object of type System.Drawing.Graphics the barcode is printed to.</param>
		/// <param name="position">Specifies the position to draw on the specified System.Drawing.Graphics object.</param>
		public void PrintPaint(Graphics graphics, Rectangle position)
		{
			if (this.bool_1 || this.metafile_1 == null)
			{
				this.metafile_1 = this.method_9(this.metafile_0);
				this.bool_1 = false;
			}
			graphics.DrawImage(this.metafile_1, position);
		}

		/// <summary>Saves the barcode data to the given object of type System.IO.Stream. The data format of the stream is XML.</summary>
		/// <param name="stream">Specifies an object of type System.IO.Stream the data is saved to.</param>
		public void Save(Stream stream)
		{
			this.txbarcodeCore_0.method_5(stream, SerializationFormat.Xml);
		}

		/// <summary>Saves the barcode data to the specified object of type System.IO.Stream using the specified format.</summary>
		/// <param name="stream">Specifies an object of type System.IO.Stream the data is saved to.</param>
		/// <param name="format">Specifies the format used to serialize the barcode.</param>
		public void Save(Stream stream, SerializationFormat format)
		{
			this.txbarcodeCore_0.method_5(stream, format);
		}

		/// <summary>Saves the barcode data to the given file. The data format of the file is XML.</summary>
		/// <param name="fileName">Specifies a file the is saved to.</param>
		public void Save(string fileName)
		{
			this.txbarcodeCore_0.method_6(fileName, SerializationFormat.Xml);
		}

		/// <summary>Saves the barcode data to the specified file using the specified format.</summary>
		/// <param name="fileName">Specifies a file the is saved to.</param>
		/// <param name="format">Specifies the format used to serialize the barcode.</param>
		public void Save(string fileName, SerializationFormat format)
		{
			this.txbarcodeCore_0.method_6(fileName, format);
		}

		/// <summary>Saves the barcode data to the given object of type System.IO.TextWriter. The data format of the stream is XML.</summary>
		/// <param name="textWriter">Specifies an object of type System.IO.TextWriter the data is saved to.</param>
		public void Save(TextWriter textWriter)
		{
			this.txbarcodeCore_0.method_7(textWriter);
		}

		/// <summary>Saves the barcode data to the given object of type System.IO.XmlWriter. The data format of the stream is XML.</summary>
		/// <param name="xmlWriter">Specifies an object of type System.IO.XmlWriter the data is saved to.</param>
		public void Save(XmlWriter xmlWriter)
		{
			this.txbarcodeCore_0.method_8(xmlWriter);
		}

		/// <summary>Saves the barcode image to the specified file using the specified format.</summary>
		/// <param name="imageFileName">Specifies a file the image is saved to.</param>
		/// <param name="format">Specifies the format used to save the image.</param>
		public void SaveImage(string imageFileName, ImageFormat format)
		{
			FileStream fileStream = new FileStream(imageFileName, FileMode.Create);
			Metafile metafile = this.method_9(this.metafile_0);
			if (format.Guid == ImageFormat.Emf.Guid)
			{
				Graphics graphics = Graphics.FromHwndInternal(IntPtr.Zero);
				IntPtr hdc = graphics.GetHdc();
				Metafile image = new Metafile(fileStream, hdc);
				graphics.ReleaseHdc();
				graphics.Dispose();
				graphics = Graphics.FromImage(image);
				graphics.DrawImage(metafile, new Point(0, 0));
				graphics.Dispose();
			}
			else if (format.Guid == ImageFormat.Wmf.Guid)
			{
				new NotSupportedException();
			}
			else
			{
				metafile.Save(fileStream, format);
			}
			fileStream.Close();
		}

		/// <summary>Saves the barcode image to the specified object of type System.IO.Stream.</summary>
		/// <param name="imageStream">Specifies an object of type System.IO.Stream the image is saved to.</param>
		/// <param name="format">Specifies the format used to save the image.</param>
		public void SaveImage(Stream imageStream, ImageFormat format)
		{
			Metafile metafile = this.method_9(this.metafile_0);
			if (format.Guid == ImageFormat.Emf.Guid)
			{
				Graphics graphics = Graphics.FromHwndInternal(IntPtr.Zero);
				IntPtr hdc = graphics.GetHdc();
				Metafile image = new Metafile(imageStream, hdc);
				graphics.ReleaseHdc();
				graphics.Dispose();
				graphics = Graphics.FromImage(image);
				graphics.DrawImage(metafile, new Point(0, 0));
				graphics.Dispose();
			}
			else if (format.Guid == ImageFormat.Wmf.Guid)
			{
				new NotSupportedException();
			}
			else
			{
				metafile.Save(imageStream, format);
			}
		}
	}
}
