using System;
using System.IO;
using System.Resources;
using System.Xml;
using ns0;

namespace TXTextControl.Barcode
{
	public class TXBarcodeCore
	{
		internal static ResourceManager resourceManager_0;

		internal BarcodeType barcodeType_0 = BarcodeType.QRCode;

		internal BarcodeInfo barcodeInfo_0 = TXBarcodeCore.barcodeInfo_1[8];

		internal static BarcodeInfo[] barcodeInfo_1;

		internal static CodeGeneratorBase[] codeGeneratorBase_0;

		internal Class37 class37_0;

		internal CodeGeneratorBase codeGeneratorBase_1 = TXBarcodeCore.codeGeneratorBase_0[8];

		internal Class21 class21_0;

		internal Class37 class37_1;

		internal Class38 class38_0 = new Class38();

		static TXBarcodeCore()
		{
			TXBarcodeCore.resourceManager_0 = new ResourceManager(typeof(TXBarcodeCore));
			TXBarcodeCore.barcodeInfo_1 = new BarcodeInfo[20]
			{
				new Class16(),
				new Class18(),
				new Class19(),
				new AztecCode(),
				new EAN13(),
				new Class6(),
				new IntelligentMail(),
				new Class12(),
				new QRCode(),
				new Class15(),
				new Class4(),
				new PDF417(),
				new MicroPDF(),
				new FourState(),
				new Codabar(),
				new Code11(),
				new Class3(),
				new PLANET(),
				new Class14(),
				new Maxicode()
			};
			TXBarcodeCore.codeGeneratorBase_0 = new CodeGeneratorBase[20]
			{
				new Class51(),
				new Class52(),
				new Class54(),
				new Class56(),
				new Class44(),
				new Class45(),
				new Class46(),
				new Class48(),
				new Class61(3, Class61.Enum6.const_1),
				new Class50(),
				new Class57(),
				new Class60(),
				new Class59(),
				new Class55(),
				new Class41(),
				new Class42(),
				new Class43(),
				new Class47(),
				new Class49(),
				new Class58()
			};
		}

		internal static string smethod_0(BarcodeType barcodeType_1)
		{
			string result = "";
			switch (barcodeType_1)
			{
			case BarcodeType.QRCode:
				result = TXBarcodeCore.barcodeInfo_1[8].m_strDefaultText;
				break;
			case BarcodeType.Code128:
				result = TXBarcodeCore.barcodeInfo_1[0].m_strDefaultText;
				break;
			case BarcodeType.EAN13:
				result = TXBarcodeCore.barcodeInfo_1[4].m_strDefaultText;
				break;
			case BarcodeType.UPCA:
				result = TXBarcodeCore.barcodeInfo_1[9].m_strDefaultText;
				break;
			case BarcodeType.EAN8:
				result = TXBarcodeCore.barcodeInfo_1[5].m_strDefaultText;
				break;
			case BarcodeType.Interleaved2of5:
				result = TXBarcodeCore.barcodeInfo_1[1].m_strDefaultText;
				break;
			case BarcodeType.Postnet:
				result = TXBarcodeCore.barcodeInfo_1[7].m_strDefaultText;
				break;
			case BarcodeType.Code39:
				result = TXBarcodeCore.barcodeInfo_1[2].m_strDefaultText;
				break;
			case BarcodeType.AztecCode:
				result = TXBarcodeCore.barcodeInfo_1[3].m_strDefaultText;
				break;
			case BarcodeType.IntelligentMail:
				result = TXBarcodeCore.barcodeInfo_1[6].m_strDefaultText;
				break;
			case BarcodeType.Datamatrix:
				result = TXBarcodeCore.barcodeInfo_1[10].m_strDefaultText;
				break;
			case BarcodeType.PDF417:
				result = TXBarcodeCore.barcodeInfo_1[11].m_strDefaultText;
				break;
			case BarcodeType.MicroPDF:
				result = TXBarcodeCore.barcodeInfo_1[12].m_strDefaultText;
				break;
			case BarcodeType.Codabar:
				result = TXBarcodeCore.barcodeInfo_1[14].m_strDefaultText;
				break;
			case BarcodeType.FourState:
				result = TXBarcodeCore.barcodeInfo_1[13].m_strDefaultText;
				break;
			case BarcodeType.Code11:
				result = TXBarcodeCore.barcodeInfo_1[15].m_strDefaultText;
				break;
			case BarcodeType.Code93:
				result = TXBarcodeCore.barcodeInfo_1[16].m_strDefaultText;
				break;
			case BarcodeType.PLANET:
				result = TXBarcodeCore.barcodeInfo_1[17].m_strDefaultText;
				break;
			case BarcodeType.RoyalMail:
				result = TXBarcodeCore.barcodeInfo_1[18].m_strDefaultText;
				break;
			case BarcodeType.Maxicode:
				result = TXBarcodeCore.barcodeInfo_1[19].m_strDefaultText;
				break;
			}
			return result;
		}

		private static string smethod_1(BarcodeType barcodeType_1)
		{
			string result = "";
			switch (barcodeType_1)
			{
			case BarcodeType.QRCode:
				result = TXBarcodeCore.resourceManager_0.GetString("ERR_QRCODE");
				break;
			case BarcodeType.Code128:
				result = TXBarcodeCore.resourceManager_0.GetString("ERR_128");
				break;
			case BarcodeType.EAN13:
				result = TXBarcodeCore.resourceManager_0.GetString("ERR_EAN13");
				break;
			case BarcodeType.UPCA:
				result = TXBarcodeCore.resourceManager_0.GetString("ERR_UPCA");
				break;
			case BarcodeType.EAN8:
				result = TXBarcodeCore.resourceManager_0.GetString("ERR_EAN8");
				break;
			case BarcodeType.Interleaved2of5:
				result = TXBarcodeCore.resourceManager_0.GetString("ERR_2OF5");
				break;
			case BarcodeType.Postnet:
				result = TXBarcodeCore.resourceManager_0.GetString("ERR_POSTNET");
				break;
			case BarcodeType.Code39:
				result = TXBarcodeCore.resourceManager_0.GetString("ERR_3OF9");
				break;
			case BarcodeType.AztecCode:
				result = TXBarcodeCore.resourceManager_0.GetString("ERR_AZTEC");
				break;
			case BarcodeType.IntelligentMail:
				result = TXBarcodeCore.resourceManager_0.GetString("ERR_INTELLIGENTMAIL");
				break;
			case BarcodeType.Datamatrix:
				result = TXBarcodeCore.resourceManager_0.GetString("ERR_DATAMATRIX");
				break;
			case BarcodeType.PDF417:
				result = TXBarcodeCore.resourceManager_0.GetString("ERR_PDF417");
				break;
			case BarcodeType.MicroPDF:
				result = TXBarcodeCore.resourceManager_0.GetString("ERR_MICROPDF");
				break;
			case BarcodeType.Codabar:
				result = TXBarcodeCore.resourceManager_0.GetString("ERR_CODABAR");
				break;
			case BarcodeType.FourState:
				result = TXBarcodeCore.resourceManager_0.GetString("ERR_4STATE");
				break;
			case BarcodeType.Code11:
				result = TXBarcodeCore.resourceManager_0.GetString("ERR_CODE_11");
				break;
			case BarcodeType.Code93:
				result = TXBarcodeCore.resourceManager_0.GetString("ERR_CODE_93");
				break;
			case BarcodeType.PLANET:
				result = TXBarcodeCore.resourceManager_0.GetString("ERR_PLANET");
				break;
			case BarcodeType.RoyalMail:
				result = TXBarcodeCore.resourceManager_0.GetString("ERR_ROYAL_MAIL");
				break;
			case BarcodeType.Maxicode:
				result = TXBarcodeCore.resourceManager_0.GetString("ERR_MAXICODE");
				break;
			}
			return result;
		}

		internal static int smethod_2(BarcodeType barcodeType_1)
		{
			int result = -1;
			switch (barcodeType_1)
			{
			case BarcodeType.QRCode:
				result = TXBarcodeCore.barcodeInfo_1[8].m_iMaximumTextLength;
				break;
			case BarcodeType.Code128:
				result = TXBarcodeCore.barcodeInfo_1[0].m_iMaximumTextLength;
				break;
			case BarcodeType.EAN13:
				result = TXBarcodeCore.barcodeInfo_1[4].m_iMaximumTextLength;
				break;
			case BarcodeType.UPCA:
				result = TXBarcodeCore.barcodeInfo_1[9].m_iMaximumTextLength;
				break;
			case BarcodeType.EAN8:
				result = TXBarcodeCore.barcodeInfo_1[5].m_iMaximumTextLength;
				break;
			case BarcodeType.Interleaved2of5:
				result = TXBarcodeCore.barcodeInfo_1[1].m_iMaximumTextLength;
				break;
			case BarcodeType.Postnet:
				result = TXBarcodeCore.barcodeInfo_1[7].m_iMaximumTextLength;
				break;
			case BarcodeType.Code39:
				result = TXBarcodeCore.barcodeInfo_1[2].m_iMaximumTextLength;
				break;
			case BarcodeType.AztecCode:
				result = TXBarcodeCore.barcodeInfo_1[3].m_iMaximumTextLength;
				break;
			case BarcodeType.IntelligentMail:
				result = TXBarcodeCore.barcodeInfo_1[6].m_iMaximumTextLength;
				break;
			case BarcodeType.Datamatrix:
				result = TXBarcodeCore.barcodeInfo_1[10].m_iMaximumTextLength;
				break;
			case BarcodeType.PDF417:
				result = TXBarcodeCore.barcodeInfo_1[11].m_iMaximumTextLength;
				break;
			case BarcodeType.MicroPDF:
				result = TXBarcodeCore.barcodeInfo_1[12].m_iMaximumTextLength;
				break;
			case BarcodeType.Codabar:
				result = TXBarcodeCore.barcodeInfo_1[14].m_iMaximumTextLength;
				break;
			case BarcodeType.FourState:
				result = TXBarcodeCore.barcodeInfo_1[13].m_iMaximumTextLength;
				break;
			case BarcodeType.Code11:
				result = TXBarcodeCore.barcodeInfo_1[15].m_iMaximumTextLength;
				break;
			case BarcodeType.Code93:
				result = TXBarcodeCore.barcodeInfo_1[16].m_iMaximumTextLength;
				break;
			case BarcodeType.PLANET:
				result = TXBarcodeCore.barcodeInfo_1[17].m_iMaximumTextLength;
				break;
			case BarcodeType.RoyalMail:
				result = TXBarcodeCore.barcodeInfo_1[18].m_iMaximumTextLength;
				break;
			case BarcodeType.Maxicode:
				result = TXBarcodeCore.barcodeInfo_1[19].m_iMaximumTextLength;
				break;
			}
			return result;
		}

		internal static int smethod_3(BarcodeType barcodeType_1)
		{
			int result = -1;
			switch (barcodeType_1)
			{
			case BarcodeType.QRCode:
				result = TXBarcodeCore.barcodeInfo_1[8].m_iMinimumTextLength;
				break;
			case BarcodeType.Code128:
				result = TXBarcodeCore.barcodeInfo_1[0].m_iMinimumTextLength;
				break;
			case BarcodeType.EAN13:
				result = TXBarcodeCore.barcodeInfo_1[4].m_iMinimumTextLength;
				break;
			case BarcodeType.UPCA:
				result = TXBarcodeCore.barcodeInfo_1[9].m_iMinimumTextLength;
				break;
			case BarcodeType.EAN8:
				result = TXBarcodeCore.barcodeInfo_1[5].m_iMinimumTextLength;
				break;
			case BarcodeType.Interleaved2of5:
				result = TXBarcodeCore.barcodeInfo_1[1].m_iMinimumTextLength;
				break;
			case BarcodeType.Postnet:
				result = TXBarcodeCore.barcodeInfo_1[7].m_iMinimumTextLength;
				break;
			case BarcodeType.Code39:
				result = TXBarcodeCore.barcodeInfo_1[2].m_iMinimumTextLength;
				break;
			case BarcodeType.AztecCode:
				result = TXBarcodeCore.barcodeInfo_1[3].m_iMinimumTextLength;
				break;
			case BarcodeType.IntelligentMail:
				result = TXBarcodeCore.barcodeInfo_1[6].m_iMinimumTextLength;
				break;
			case BarcodeType.Datamatrix:
				result = TXBarcodeCore.barcodeInfo_1[10].m_iMinimumTextLength;
				break;
			case BarcodeType.PDF417:
				result = TXBarcodeCore.barcodeInfo_1[11].m_iMinimumTextLength;
				break;
			case BarcodeType.MicroPDF:
				result = TXBarcodeCore.barcodeInfo_1[12].m_iMinimumTextLength;
				break;
			case BarcodeType.Codabar:
				result = TXBarcodeCore.barcodeInfo_1[14].m_iMinimumTextLength;
				break;
			case BarcodeType.FourState:
				result = TXBarcodeCore.barcodeInfo_1[13].m_iMinimumTextLength;
				break;
			case BarcodeType.Code11:
				result = TXBarcodeCore.barcodeInfo_1[15].m_iMinimumTextLength;
				break;
			case BarcodeType.Code93:
				result = TXBarcodeCore.barcodeInfo_1[16].m_iMinimumTextLength;
				break;
			case BarcodeType.PLANET:
				result = TXBarcodeCore.barcodeInfo_1[17].m_iMinimumTextLength;
				break;
			case BarcodeType.RoyalMail:
				result = TXBarcodeCore.barcodeInfo_1[18].m_iMinimumTextLength;
				break;
			case BarcodeType.Maxicode:
				result = TXBarcodeCore.barcodeInfo_1[19].m_iMinimumTextLength;
				break;
			}
			return result;
		}

		internal Class40 method_0(Class23 class23_0, Class23 class23_1, Alignment alignment_0)
		{
			float num = 0f;
			float float_;
			float float_2 = (float_ = (class23_0.float_0 - class23_1.float_0) / 2f);
			float float_3 = (num = (class23_0.float_1 - class23_1.float_1) / 2f);
			switch (alignment_0)
			{
			case Alignment.TopLeft:
				float_2 = 0f;
				float_3 = 0f;
				float_ = class23_0.float_0 - class23_1.float_0;
				num = class23_0.float_1 - class23_1.float_1;
				break;
			case Alignment.TopCenter:
				float_3 = 0f;
				num = class23_0.float_1 - class23_1.float_1;
				break;
			case Alignment.TopRight:
				float_2 = class23_0.float_0 - class23_1.float_0;
				float_3 = 0f;
				float_ = 0f;
				num = class23_0.float_1 - class23_1.float_1;
				break;
			case Alignment.MiddleLeft:
				float_2 = 0f;
				float_ = class23_0.float_0 - class23_1.float_0;
				break;
			case Alignment.MiddleRight:
				float_2 = class23_0.float_0 - class23_1.float_0;
				float_ = 0f;
				break;
			case Alignment.BottomCenter:
				float_3 = class23_0.float_1 - class23_1.float_1;
				num = 0f;
				break;
			case Alignment.BottomLeft:
				float_2 = 0f;
				float_3 = class23_0.float_1 - class23_1.float_1;
				float_ = class23_0.float_0 - class23_1.float_0;
				num = 0f;
				break;
			case Alignment.BottomRight:
				float_2 = class23_0.float_0 - class23_1.float_0;
				float_3 = class23_0.float_1 - class23_1.float_1;
				float_ = 0f;
				num = 0f;
				break;
			}
			return new Class40(float_2, float_3, float_, num);
		}

		internal static bool smethod_4(BarcodeType barcodeType_1, string string_0, out string string_1)
		{
			string_1 = "";
			bool result = false;
			CodeGeneratorBase codeGeneratorBase = null;
			BarcodeInfo barcodeInfo = null;
			switch (barcodeType_1)
			{
			case BarcodeType.QRCode:
				codeGeneratorBase = TXBarcodeCore.codeGeneratorBase_0[8];
				barcodeInfo = TXBarcodeCore.barcodeInfo_1[8];
				break;
			case BarcodeType.Code128:
				codeGeneratorBase = TXBarcodeCore.codeGeneratorBase_0[0];
				barcodeInfo = TXBarcodeCore.barcodeInfo_1[0];
				break;
			case BarcodeType.EAN13:
				codeGeneratorBase = TXBarcodeCore.codeGeneratorBase_0[4];
				barcodeInfo = TXBarcodeCore.barcodeInfo_1[4];
				break;
			case BarcodeType.UPCA:
				codeGeneratorBase = TXBarcodeCore.codeGeneratorBase_0[9];
				barcodeInfo = TXBarcodeCore.barcodeInfo_1[9];
				break;
			case BarcodeType.EAN8:
				codeGeneratorBase = TXBarcodeCore.codeGeneratorBase_0[5];
				barcodeInfo = TXBarcodeCore.barcodeInfo_1[5];
				break;
			case BarcodeType.Interleaved2of5:
				codeGeneratorBase = TXBarcodeCore.codeGeneratorBase_0[1];
				barcodeInfo = TXBarcodeCore.barcodeInfo_1[1];
				break;
			case BarcodeType.Postnet:
				codeGeneratorBase = TXBarcodeCore.codeGeneratorBase_0[7];
				barcodeInfo = TXBarcodeCore.barcodeInfo_1[7];
				break;
			case BarcodeType.Code39:
				codeGeneratorBase = TXBarcodeCore.codeGeneratorBase_0[2];
				barcodeInfo = TXBarcodeCore.barcodeInfo_1[2];
				break;
			case BarcodeType.AztecCode:
				codeGeneratorBase = TXBarcodeCore.codeGeneratorBase_0[3];
				barcodeInfo = TXBarcodeCore.barcodeInfo_1[3];
				break;
			case BarcodeType.IntelligentMail:
				codeGeneratorBase = TXBarcodeCore.codeGeneratorBase_0[6];
				barcodeInfo = TXBarcodeCore.barcodeInfo_1[6];
				break;
			case BarcodeType.Datamatrix:
				codeGeneratorBase = TXBarcodeCore.codeGeneratorBase_0[10];
				barcodeInfo = TXBarcodeCore.barcodeInfo_1[10];
				break;
			case BarcodeType.PDF417:
				codeGeneratorBase = TXBarcodeCore.codeGeneratorBase_0[11];
				barcodeInfo = TXBarcodeCore.barcodeInfo_1[11];
				break;
			case BarcodeType.MicroPDF:
				codeGeneratorBase = TXBarcodeCore.codeGeneratorBase_0[12];
				barcodeInfo = TXBarcodeCore.barcodeInfo_1[12];
				break;
			case BarcodeType.Codabar:
				codeGeneratorBase = TXBarcodeCore.codeGeneratorBase_0[14];
				barcodeInfo = TXBarcodeCore.barcodeInfo_1[14];
				break;
			case BarcodeType.FourState:
				codeGeneratorBase = TXBarcodeCore.codeGeneratorBase_0[13];
				barcodeInfo = TXBarcodeCore.barcodeInfo_1[13];
				break;
			case BarcodeType.Code11:
				codeGeneratorBase = TXBarcodeCore.codeGeneratorBase_0[15];
				barcodeInfo = TXBarcodeCore.barcodeInfo_1[15];
				break;
			case BarcodeType.Code93:
				codeGeneratorBase = TXBarcodeCore.codeGeneratorBase_0[16];
				barcodeInfo = TXBarcodeCore.barcodeInfo_1[16];
				break;
			case BarcodeType.PLANET:
				codeGeneratorBase = TXBarcodeCore.codeGeneratorBase_0[17];
				barcodeInfo = TXBarcodeCore.barcodeInfo_1[17];
				break;
			case BarcodeType.RoyalMail:
				codeGeneratorBase = TXBarcodeCore.codeGeneratorBase_0[18];
				barcodeInfo = TXBarcodeCore.barcodeInfo_1[18];
				break;
			case BarcodeType.Maxicode:
				codeGeneratorBase = TXBarcodeCore.codeGeneratorBase_0[19];
				barcodeInfo = TXBarcodeCore.barcodeInfo_1[19];
				break;
			}
			if (barcodeInfo.m_ctType == BarcodeType.Postnet && string_0.Length != 5 && string_0.Length != 9 && string_0.Length != 11)
			{
				result = false;
				string_1 = TXBarcodeCore.resourceManager_0.GetString("ERR_TEXT_LENGTH_POSTNET_2");
			}
			else if (barcodeInfo.m_ctType == BarcodeType.IntelligentMail && string_0.Length != 20 && string_0.Length != 25 && string_0.Length != 29 && string_0.Length != 31)
			{
				string_1 = TXBarcodeCore.resourceManager_0.GetString("ERR_TEXT_LENGTH_INTELLIGENTMAIL_2");
			}
			else if (string_0.Length >= barcodeInfo.m_iMinimumTextLength && string_0.Length <= barcodeInfo.m_iMaximumTextLength)
			{
				if (!(result = codeGeneratorBase.IsTextValid(string_0, barcodeInfo.m_iMaximumTextLength)))
				{
					string_1 = TXBarcodeCore.smethod_1(barcodeInfo.m_ctType);
				}
			}
			else
			{
				result = false;
				if (barcodeInfo.m_bIsUpperTextLengthVariable)
				{
					string_1 = TXBarcodeCore.resourceManager_0.GetString("ERR_TEXT_LENGTH_1") + barcodeInfo.m_iMinimumTextLength + TXBarcodeCore.resourceManager_0.GetString("ERR_TEXT_LENGTH_3") + barcodeInfo.m_iMaximumTextLength + TXBarcodeCore.resourceManager_0.GetString("ERR_TEXT_LENGTH_5");
				}
				else
				{
					string_1 = TXBarcodeCore.resourceManager_0.GetString("ERR_TEXT_LENGTH_NOT_VARIABLE_1") + barcodeInfo.m_iMinimumTextLength + TXBarcodeCore.resourceManager_0.GetString("ERR_TEXT_LENGTH_NOT_VARIABLE_2");
				}
			}
			return result;
		}

		internal void method_1(Stream stream_0, SerializationFormat serializationFormat_0)
		{
			this.class21_0.method_0(stream_0, serializationFormat_0);
		}

		internal void method_2(string string_0, SerializationFormat serializationFormat_0)
		{
			this.class21_0.method_1(string_0, serializationFormat_0);
		}

		internal void method_3(TextReader textReader_0)
		{
			this.class21_0.method_2(textReader_0);
		}

		internal void method_4(XmlReader xmlReader_0)
		{
			this.class21_0.method_3(xmlReader_0);
		}

		internal void method_5(Stream stream_0, SerializationFormat serializationFormat_0)
		{
			this.class21_0.method_4(stream_0, serializationFormat_0);
		}

		internal void method_6(string string_0, SerializationFormat serializationFormat_0)
		{
			this.class21_0.method_5(string_0, serializationFormat_0);
		}

		internal void method_7(TextWriter textWriter_0)
		{
			this.class21_0.method_6(textWriter_0);
		}

		internal void method_8(XmlWriter xmlWriter_0)
		{
			this.class21_0.method_7(xmlWriter_0);
		}

		internal void method_9(Class26 class26_0)
		{
			this.class38_0.Class26_0 = class26_0;
		}

		internal void method_10(string string_0)
		{
			this.class38_0.Text = string_0;
			if (this.barcodeType_0 == BarcodeType.PDF417 || this.barcodeType_0 == BarcodeType.MicroPDF || this.barcodeType_0 == BarcodeType.Maxicode)
			{
				this.codeGeneratorBase_1.UpdateBarcodeSettings(this.class38_0);
			}
			this.class37_0 = this.codeGeneratorBase_1.GetBarcodeImage(this.class38_0, this.class38_0.Text);
		}

		internal void method_11(Class26 class26_0)
		{
			this.class38_0.Class26_1 = class26_0;
		}

		internal void method_12(BarcodeType barcodeType_1)
		{
			this.method_18(barcodeType_1);
			this.class38_0.Text = this.method_17(this.barcodeInfo_0, this.class38_0.Text);
			this.class38_0.Boolean_0 = this.barcodeInfo_0.m_bDefaultHasCheckValue;
			this.class38_0.Boolean_1 = this.barcodeInfo_0.m_bDefaultShowCheckValue;
			this.codeGeneratorBase_1.UpdateBarcodeSettings(this.class38_0);
			this.class37_0 = this.codeGeneratorBase_1.GetBarcodeImage(this.class38_0, this.class38_0.Text);
		}

		internal void method_13(int int_0)
		{
			this.method_16(int_0);
			if (this.barcodeInfo_0.m_bIsUpperTextLengthVariable)
			{
				this.codeGeneratorBase_1.UpdateBarcodeSettings(this.class38_0);
			}
		}

		internal void method_14()
		{
			this.class37_0 = this.codeGeneratorBase_1.GetBarcodeImage(this.class38_0, this.class38_0.Text);
		}

		internal bool method_15(string string_0, out string string_1)
		{
			string_1 = string_0;
			bool result = true;
			if (this.barcodeInfo_0.m_ctType == BarcodeType.Postnet && string_0.Length != 5 && string_0.Length != 9 && string_0.Length != 11)
			{
				string_1 = TXBarcodeCore.resourceManager_0.GetString("ERR_TEXT_LENGTH_POSTNET_1") + TXBarcodeCore.resourceManager_0.GetString("ERR_TEXT_LENGTH_CURRENT_LENGTH_1") + string_0.Length + TXBarcodeCore.resourceManager_0.GetString("ERR_TEXT_LENGTH_CURRENT_LENGTH_2");
				result = false;
			}
			else if (this.barcodeInfo_0.m_ctType == BarcodeType.IntelligentMail && string_0.Length != 20 && string_0.Length != 25 && string_0.Length != 29 && string_0.Length != 31)
			{
				string_1 = TXBarcodeCore.resourceManager_0.GetString("ERR_TEXT_LENGTH_INTELLIGENTMAIL_1") + TXBarcodeCore.resourceManager_0.GetString("ERR_TEXT_LENGTH_CURRENT_LENGTH_1") + string_0.Length + TXBarcodeCore.resourceManager_0.GetString("ERR_TEXT_LENGTH_CURRENT_LENGTH_2");
				result = false;
			}
			else if (string_0.Length != this.class38_0.UpperTextLength && !this.barcodeInfo_0.m_bIsUpperTextLengthVariable)
			{
				string_1 = TXBarcodeCore.resourceManager_0.GetString("ERR_TEXT_LENGTH_NOT_VARIABLE_1") + this.class38_0.UpperTextLength + TXBarcodeCore.resourceManager_0.GetString("ERR_TEXT_LENGTH_NOT_VARIABLE_3") + TXBarcodeCore.resourceManager_0.GetString("ERR_TEXT_LENGTH_CURRENT_LENGTH_1") + string_0.Length + TXBarcodeCore.resourceManager_0.GetString("ERR_TEXT_LENGTH_CURRENT_LENGTH_2");
				result = false;
			}
			else if (string_0.Length <= this.class38_0.UpperTextLength && string_0.Length >= this.barcodeInfo_0.m_iMinimumTextLength)
			{
				if (!this.codeGeneratorBase_1.IsTextValid(string_0, this.class38_0.UpperTextLength))
				{
					string_1 = TXBarcodeCore.smethod_1(this.barcodeInfo_0.m_ctType);
					result = false;
				}
			}
			else
			{
				string_1 = TXBarcodeCore.resourceManager_0.GetString("ERR_TEXT_LENGTH_1") + this.barcodeInfo_0.m_iMinimumTextLength + TXBarcodeCore.resourceManager_0.GetString("ERR_TEXT_LENGTH_2") + this.class38_0.UpperTextLength + TXBarcodeCore.resourceManager_0.GetString("ERR_TEXT_LENGTH_4") + TXBarcodeCore.resourceManager_0.GetString("ERR_TEXT_LENGTH_CURRENT_LENGTH_1") + string_0.Length + TXBarcodeCore.resourceManager_0.GetString("ERR_TEXT_LENGTH_CURRENT_LENGTH_2");
				result = false;
			}
			return result;
		}

		private void method_16(int int_0)
		{
			if (int_0 != this.barcodeInfo_0.m_iMaximumTextLength && !this.barcodeInfo_0.m_bIsUpperTextLengthVariable)
			{
				throw new ArgumentException(TXBarcodeCore.resourceManager_0.GetString("ERR_UPPER_TEXT_LENGTH_STATIC_1") + this.barcodeInfo_0.m_iMaximumTextLength + TXBarcodeCore.resourceManager_0.GetString("ERR_UPPER_TEXT_LENGTH_STATIC_2"));
			}
			if (this.barcodeInfo_0.m_ctType == BarcodeType.Postnet && int_0 != 5 && int_0 != 9 && int_0 != 11)
			{
				throw new ArgumentException(TXBarcodeCore.resourceManager_0.GetString("ERR_UPPER_TEXT_LENGTH_POSTNET"));
			}
			if (this.barcodeInfo_0.m_ctType == BarcodeType.IntelligentMail && int_0 != 20 && int_0 != 25 && int_0 != 29 && int_0 != 31)
			{
				throw new ArgumentException(TXBarcodeCore.resourceManager_0.GetString("ERR_UPPER_TEXT_LENGTH_INTELLIGENTMAIL"));
			}
			if (int_0 <= this.barcodeInfo_0.m_iMaximumTextLength && int_0 >= this.barcodeInfo_0.m_iMinimumTextLength)
			{
				if (this.class38_0.Text.Length > int_0)
				{
					throw new ArgumentException(TXBarcodeCore.resourceManager_0.GetString("ERR_UPPER_TEXT_LENGTH_4"));
				}
				return;
			}
			throw new ArgumentException(TXBarcodeCore.resourceManager_0.GetString("ERR_UPPER_TEXT_LENGTH_1") + this.barcodeInfo_0.m_iMinimumTextLength + TXBarcodeCore.resourceManager_0.GetString("ERR_UPPER_TEXT_LENGTH_2") + this.barcodeInfo_0.m_iMaximumTextLength + TXBarcodeCore.resourceManager_0.GetString("ERR_UPPER_TEXT_LENGTH_3"));
		}

		private string method_17(BarcodeInfo barcodeInfo_2, string string_0)
		{
			if (this.codeGeneratorBase_1.IsTextValid(string_0, this.class38_0.UpperTextLength))
			{
				if (string_0.Length > barcodeInfo_2.m_iMaximumTextLength)
				{
					this.class38_0.UpperTextLength = barcodeInfo_2.m_strDefaultText.Length;
					return barcodeInfo_2.m_strDefaultText;
				}
				return string_0;
			}
			this.class38_0.UpperTextLength = barcodeInfo_2.m_strDefaultText.Length;
			return barcodeInfo_2.m_strDefaultText;
		}

		private void method_18(BarcodeType barcodeType_1)
		{
			this.barcodeType_0 = barcodeType_1;
			switch (barcodeType_1)
			{
			case BarcodeType.QRCode:
				this.barcodeInfo_0 = TXBarcodeCore.barcodeInfo_1[8];
				this.codeGeneratorBase_1 = TXBarcodeCore.codeGeneratorBase_0[8];
				break;
			case BarcodeType.Code128:
				this.barcodeInfo_0 = TXBarcodeCore.barcodeInfo_1[0];
				this.codeGeneratorBase_1 = TXBarcodeCore.codeGeneratorBase_0[0];
				break;
			case BarcodeType.EAN13:
				this.barcodeInfo_0 = TXBarcodeCore.barcodeInfo_1[4];
				this.codeGeneratorBase_1 = TXBarcodeCore.codeGeneratorBase_0[4];
				break;
			case BarcodeType.UPCA:
				this.barcodeInfo_0 = TXBarcodeCore.barcodeInfo_1[9];
				this.codeGeneratorBase_1 = TXBarcodeCore.codeGeneratorBase_0[9];
				break;
			case BarcodeType.EAN8:
				this.barcodeInfo_0 = TXBarcodeCore.barcodeInfo_1[5];
				this.codeGeneratorBase_1 = TXBarcodeCore.codeGeneratorBase_0[5];
				break;
			case BarcodeType.Interleaved2of5:
				this.barcodeInfo_0 = TXBarcodeCore.barcodeInfo_1[1];
				this.codeGeneratorBase_1 = TXBarcodeCore.codeGeneratorBase_0[1];
				break;
			case BarcodeType.Postnet:
				this.barcodeInfo_0 = TXBarcodeCore.barcodeInfo_1[7];
				this.codeGeneratorBase_1 = TXBarcodeCore.codeGeneratorBase_0[7];
				break;
			case BarcodeType.Code39:
				this.barcodeInfo_0 = TXBarcodeCore.barcodeInfo_1[2];
				this.codeGeneratorBase_1 = TXBarcodeCore.codeGeneratorBase_0[2];
				break;
			case BarcodeType.AztecCode:
				this.barcodeInfo_0 = TXBarcodeCore.barcodeInfo_1[3];
				this.codeGeneratorBase_1 = TXBarcodeCore.codeGeneratorBase_0[3];
				break;
			case BarcodeType.IntelligentMail:
				this.barcodeInfo_0 = TXBarcodeCore.barcodeInfo_1[6];
				this.codeGeneratorBase_1 = TXBarcodeCore.codeGeneratorBase_0[6];
				break;
			case BarcodeType.Datamatrix:
				this.barcodeInfo_0 = TXBarcodeCore.barcodeInfo_1[10];
				this.codeGeneratorBase_1 = TXBarcodeCore.codeGeneratorBase_0[10];
				break;
			case BarcodeType.PDF417:
				this.barcodeInfo_0 = TXBarcodeCore.barcodeInfo_1[11];
				this.codeGeneratorBase_1 = TXBarcodeCore.codeGeneratorBase_0[11];
				break;
			case BarcodeType.MicroPDF:
				this.barcodeInfo_0 = TXBarcodeCore.barcodeInfo_1[12];
				this.codeGeneratorBase_1 = TXBarcodeCore.codeGeneratorBase_0[12];
				break;
			case BarcodeType.Codabar:
				this.barcodeInfo_0 = TXBarcodeCore.barcodeInfo_1[14];
				this.codeGeneratorBase_1 = TXBarcodeCore.codeGeneratorBase_0[14];
				break;
			case BarcodeType.FourState:
				this.barcodeInfo_0 = TXBarcodeCore.barcodeInfo_1[13];
				this.codeGeneratorBase_1 = TXBarcodeCore.codeGeneratorBase_0[13];
				break;
			case BarcodeType.Code11:
				this.barcodeInfo_0 = TXBarcodeCore.barcodeInfo_1[15];
				this.codeGeneratorBase_1 = TXBarcodeCore.codeGeneratorBase_0[15];
				break;
			case BarcodeType.Code93:
				this.barcodeInfo_0 = TXBarcodeCore.barcodeInfo_1[16];
				this.codeGeneratorBase_1 = TXBarcodeCore.codeGeneratorBase_0[16];
				break;
			case BarcodeType.PLANET:
				this.barcodeInfo_0 = TXBarcodeCore.barcodeInfo_1[17];
				this.codeGeneratorBase_1 = TXBarcodeCore.codeGeneratorBase_0[17];
				break;
			case BarcodeType.RoyalMail:
				this.barcodeInfo_0 = TXBarcodeCore.barcodeInfo_1[18];
				this.codeGeneratorBase_1 = TXBarcodeCore.codeGeneratorBase_0[18];
				break;
			case BarcodeType.Maxicode:
				this.barcodeInfo_0 = TXBarcodeCore.barcodeInfo_1[19];
				this.codeGeneratorBase_1 = TXBarcodeCore.codeGeneratorBase_0[19];
				break;
			}
		}
	}
}
