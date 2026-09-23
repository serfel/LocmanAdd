using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ns22
{
	internal class Class395
	{
		private struct Struct42
		{
			internal char char_0;

			internal char char_1;

			internal int int_0;

			internal int int_1;

			internal Struct42(char char_2, char char_3, int int_2, int int_3)
			{
				this.char_0 = char_2;
				this.char_1 = char_3;
				this.int_0 = int_2;
				this.int_1 = int_3;
			}
		}

		private sealed class Class396 : IComparer<Class397>
		{
			public int Compare(Class397 x, Class397 y)
			{
				if (x.char_0 >= y.char_0)
				{
					if (x.char_0 <= y.char_0)
					{
						return 0;
					}
					return 1;
				}
				return -1;
			}
		}

		private sealed class Class397
		{
			internal char char_0;

			internal char char_1;

			internal Class397(char char_2, char char_3)
			{
				this.char_0 = char_2;
				this.char_1 = char_3;
			}
		}

		private const int int_0 = 0;

		private const int int_1 = 1;

		private const int int_2 = 2;

		private const int int_3 = 3;

		private const char char_0 = '\0';

		private const char char_1 = '\uffff';

		private const char char_2 = '\0';

		private const short short_0 = 100;

		private const short short_1 = -100;

		private const char char_3 = '\u200d';

		private const char char_4 = '\u200c';

		private const string string_0 = "\t\u000e !";

		private const string string_1 = "\0\t\u000e !";

		private const string string_2 = "0:A[_`a{İı";

		private const string string_3 = "\00:A[_`a{İı";

		private const string string_4 = "0:";

		private const string string_5 = "\00:";

		internal const string string_6 = "\0\u0004\0\t\u000e !";

		internal const string string_7 = "\u0001\u0004\0\t\u000e !";

		internal const string string_8 = "\0\n\00:A[_`a{İı";

		internal const string string_9 = "\u0001\n\00:A[_`a{İı";

		internal const string string_10 = "\0\u0002\00:";

		internal const string string_11 = "\u0001\u0002\00:";

		internal const string string_12 = "\0\u0001\0\0";

		internal const string string_13 = "\0\0\0";

		private const int int_4 = 0;

		private const int int_5 = 1;

		private const int int_6 = 2;

		private const int int_7 = 3;

		private List<Class397> list_0;

		private StringBuilder stringBuilder_0;

		private bool bool_0;

		internal bool bool_1;

		internal Class395 class395_0;

		private static readonly string string_14;

		private static readonly string string_15;

		private static readonly string string_16;

		private static readonly string string_17;

		private static readonly string string_18;

		internal static readonly string string_19;

		internal static readonly string string_20;

		internal static readonly string string_21;

		internal static readonly string string_22;

		internal static readonly string string_23;

		internal static readonly string string_24;

		private static Dictionary<string, string> dictionary_0;

		private static readonly string[,] string_25;

		private static readonly Struct42[] struct42_0;

		static Class395()
		{
			Class395.string_14 = "__InternalRegexIgnoreCase__";
			Class395.string_15 = "d";
			Class395.string_16 = Class395.smethod_15(Class395.string_15);
			Class395.string_25 = new string[112, 2]
			{
				{ "IsAlphabeticPresentationForms", "ﬀﭐ" },
				{ "IsArabic", "\u0600܀" },
				{ "IsArabicPresentationForms-A", "ﭐ\ufe00" },
				{ "IsArabicPresentationForms-B", "ﹰ\uff00" },
				{ "IsArmenian", "\u0530\u0590" },
				{ "IsArrows", "←∀" },
				{ "IsBasicLatin", "\0\u0080" },
				{ "IsBengali", "ঀ\u0a00" },
				{ "IsBlockElements", "▀■" },
				{ "IsBopomofo", "\u3100\u3130" },
				{ "IsBopomofoExtended", "ㆠ㇀" },
				{ "IsBoxDrawing", "─▀" },
				{ "IsBraillePatterns", "⠀⤀" },
				{ "IsBuhid", "ᝀᝠ" },
				{ "IsCJKCompatibility", "㌀㐀" },
				{ "IsCJKCompatibilityForms", "︰﹐" },
				{ "IsCJKCompatibilityIdeographs", "豈ﬀ" },
				{ "IsCJKRadicalsSupplement", "⺀⼀" },
				{ "IsCJKSymbolsandPunctuation", "\u3000\u3040" },
				{ "IsCJKUnifiedIdeographs", "一ꀀ" },
				{ "IsCJKUnifiedIdeographsExtensionA", "㐀䷀" },
				{ "IsCherokee", "Ꭰ᐀" },
				{ "IsCombiningDiacriticalMarks", "\u0300Ͱ" },
				{ "IsCombiningDiacriticalMarksforSymbols", "\u20d0℀" },
				{ "IsCombiningHalfMarks", "\ufe20︰" },
				{ "IsCombiningMarksforSymbols", "\u20d0℀" },
				{ "IsControlPictures", "␀⑀" },
				{ "IsCurrencySymbols", "₠\u20d0" },
				{ "IsCyrillic", "ЀԀ" },
				{ "IsCyrillicSupplement", "Ԁ\u0530" },
				{ "IsDevanagari", "\u0900ঀ" },
				{ "IsDingbats", "✀⟀" },
				{ "IsEnclosedAlphanumerics", "①─" },
				{ "IsEnclosedCJKLettersandMonths", "㈀㌀" },
				{ "IsEthiopic", "ሀᎀ" },
				{ "IsGeneralPunctuation", "\u2000⁰" },
				{ "IsGeometricShapes", "■☀" },
				{ "IsGeorgian", "Ⴀᄀ" },
				{ "IsGreek", "ͰЀ" },
				{ "IsGreekExtended", "ἀ\u2000" },
				{ "IsGreekandCoptic", "ͰЀ" },
				{ "IsGujarati", "\u0a80\u0b00" },
				{ "IsGurmukhi", "\u0a00\u0a80" },
				{ "IsHalfwidthandFullwidthForms", "\uff00\ufff0" },
				{ "IsHangulCompatibilityJamo", "\u3130㆐" },
				{ "IsHangulJamo", "ᄀሀ" },
				{ "IsHangulSyllables", "가ힰ" },
				{ "IsHanunoo", "ᜠᝀ" },
				{ "IsHebrew", "\u0590\u0600" },
				{ "IsHighPrivateUseSurrogates", "\udb80\udc00" },
				{ "IsHighSurrogates", "\ud800\udb80" },
				{ "IsHiragana", "\u3040゠" },
				{ "IsIPAExtensions", "ɐʰ" },
				{ "IsIdeographicDescriptionCharacters", "⿰\u3000" },
				{ "IsKanbun", "㆐ㆠ" },
				{ "IsKangxiRadicals", "⼀\u2fe0" },
				{ "IsKannada", "\u0c80\u0d00" },
				{ "IsKatakana", "゠\u3100" },
				{ "IsKatakanaPhoneticExtensions", "ㇰ㈀" },
				{ "IsKhmer", "ក᠀" },
				{ "IsKhmerSymbols", "᧠ᨀ" },
				{ "IsLao", "\u0e80ༀ" },
				{ "IsLatin-1Supplement", "\u0080Ā" },
				{ "IsLatinExtended-A", "Āƀ" },
				{ "IsLatinExtended-B", "ƀɐ" },
				{ "IsLatinExtendedAdditional", "Ḁἀ" },
				{ "IsLetterlikeSymbols", "℀⅐" },
				{ "IsLimbu", "ᤀᥐ" },
				{ "IsLowSurrogates", "\udc00\ue000" },
				{ "IsMalayalam", "\u0d00\u0d80" },
				{ "IsMathematicalOperators", "∀⌀" },
				{ "IsMiscellaneousMathematicalSymbols-A", "⟀⟰" },
				{ "IsMiscellaneousMathematicalSymbols-B", "⦀⨀" },
				{ "IsMiscellaneousSymbols", "☀✀" },
				{ "IsMiscellaneousSymbolsandArrows", "⬀Ⰰ" },
				{ "IsMiscellaneousTechnical", "⌀␀" },
				{ "IsMongolian", "᠀ᢰ" },
				{ "IsMyanmar", "ကႠ" },
				{ "IsNumberForms", "⅐←" },
				{ "IsOgham", "\u1680ᚠ" },
				{ "IsOpticalCharacterRecognition", "⑀①" },
				{ "IsOriya", "\u0b00\u0b80" },
				{ "IsPhoneticExtensions", "ᴀᶀ" },
				{ "IsPrivateUse", "\ue000豈" },
				{ "IsPrivateUseArea", "\ue000豈" },
				{ "IsRunic", "ᚠᜀ" },
				{ "IsSinhala", "\u0d80\u0e00" },
				{ "IsSmallFormVariants", "﹐ﹰ" },
				{ "IsSpacingModifierLetters", "ʰ\u0300" },
				{ "IsSpecials", "\ufff0" },
				{ "IsSuperscriptsandSubscripts", "⁰₠" },
				{ "IsSupplementalArrows-A", "⟰⠀" },
				{ "IsSupplementalArrows-B", "⤀⦀" },
				{ "IsSupplementalMathematicalOperators", "⨀⬀" },
				{ "IsSyriac", "܀ݐ" },
				{ "IsTagalog", "ᜀᜠ" },
				{ "IsTagbanwa", "ᝠក" },
				{ "IsTaiLe", "ᥐᦀ" },
				{ "IsTamil", "\u0b80\u0c00" },
				{ "IsTelugu", "\u0c00\u0c80" },
				{ "IsThaana", "ހ߀" },
				{ "IsThai", "\u0e00\u0e80" },
				{ "IsTibetan", "ༀက" },
				{ "IsUnifiedCanadianAboriginalSyllabics", "᐀\u1680" },
				{ "IsVariationSelectors", "\ufe00︐" },
				{ "IsYiRadicals", "꒐ꓐ" },
				{ "IsYiSyllables", "ꀀ꒐" },
				{ "IsYijingHexagramSymbols", "䷀一" },
				{ "_xmlC", "-/0;A[_`a{·\u00b8À×Ø÷øĲĴĿŁŉŊſƀǄǍǱǴǶǺȘɐʩʻ\u02c2ː\u02d2\u0300\u0346\u0360\u0362Ά\u038bΌ\u038dΎ\u03a2ΣϏϐϗϚϛϜϝϞϟϠϡϢϴЁЍЎѐёѝў҂\u0483\u0487ҐӅӇӉӋӍӐӬӮӶӸӺԱ\u0557ՙ՚աև\u0591\u05a2\u05a3\u05ba\u05bb־\u05bf׀\u05c1׃\u05c4\u05c5א\u05ebװ׳ءػـ\u0653٠٪\u0670ڸںڿۀۏې۔ە۩\u06eaۮ۰ۺ\u0901ऄअ\u093a\u093c\u094e\u0951\u0955क़।०॰\u0981\u0984অ\u098dএ\u0991ও\u09a9প\u09b1ল\u09b3শ\u09ba\u09bcঽ\u09be\u09c5\u09c7\u09c9\u09cbৎ\u09d7\u09d8ড়\u09deয়\u09e4০৲\u0a02\u0a03ਅ\u0a0bਏ\u0a11ਓ\u0a29ਪ\u0a31ਲ\u0a34ਵ\u0a37ਸ\u0a3a\u0a3c\u0a3d\u0a3e\u0a43\u0a47\u0a49\u0a4b\u0a4eਖ਼\u0a5dਫ਼\u0a5f੦\u0a75\u0a81\u0a84અઌઍ\u0a8eએ\u0a92ઓ\u0aa9પ\u0ab1લ\u0ab4વ\u0aba\u0abc\u0ac6\u0ac7\u0aca\u0acb\u0aceૠૡ૦૰\u0b01\u0b04ଅ\u0b0dଏ\u0b11ଓ\u0b29ପ\u0b31ଲ\u0b34ଶ\u0b3a\u0b3c\u0b44\u0b47\u0b49\u0b4b\u0b4e\u0b56\u0b58ଡ଼\u0b5eୟ\u0b62୦୰\u0b82\u0b84அ\u0b8bஎ\u0b91ஒ\u0b96ங\u0b9bஜ\u0b9dஞ\u0ba0ண\u0ba5ந\u0babமஶஷ\u0bba\u0bbe\u0bc3\u0bc6\u0bc9\u0bca\u0bce\u0bd7\u0bd8௧௰\u0c01\u0c04అ\u0c0dఎ\u0c11ఒ\u0c29పఴవ\u0c3a\u0c3e\u0c45\u0c46\u0c49\u0c4a\u0c4e\u0c55\u0c57ౠ\u0c62౦\u0c70\u0c82\u0c84ಅ\u0c8dಎ\u0c91ಒ\u0ca9ಪ\u0cb4ವ\u0cba\u0cbe\u0cc5\u0cc6\u0cc9\u0cca\u0cce\u0cd5\u0cd7ೞ\u0cdfೠ\u0ce2೦\u0cf0\u0d02\u0d04അ\u0d0dഎ\u0d11ഒഩപഺ\u0d3e\u0d44\u0d46\u0d49\u0d4aൎ\u0d57\u0d58ൠ\u0d62൦൰กฯะ\u0e3bเ๏๐๚ກ\u0e83ຄ\u0e85ງ\u0e89ຊ\u0e8bຍ\u0e8eດ\u0e98ນ\u0ea0ມ\u0ea4ລ\u0ea6ວ\u0ea8ສ\u0eacອຯະ\u0eba\u0ebb\u0ebeເ\u0ec5ໆ\u0ec7\u0ec8\u0ece໐\u0eda\u0f18༚༠༪\u0f35༶\u0f37༸\u0f39༺\u0f3e\u0f48ཉཪ\u0f71྅\u0f86ྌ\u0f90\u0f96\u0f97\u0f98\u0f99\u0fae\u0fb1\u0fb8\u0fb9\u0fbaႠ\u10c6აჷᄀᄁᄂᄄᄅᄈᄉᄊᄋᄍᄎᄓᄼᄽᄾᄿᅀᅁᅌᅍᅎᅏᅐᅑᅔᅖᅙᅚᅟᅢᅣᅤᅥᅦᅧᅨᅩᅪᅭᅯᅲᅴᅵᅶᆞᆟᆨᆩᆫᆬᆮᆰᆷᆹᆺᆻᆼᇃᇫᇬᇰᇱᇹᇺḀẜẠỺἀ\u1f16Ἐ\u1f1eἠ\u1f46Ὀ\u1f4eὐ\u1f58Ὑ\u1f5aὛ\u1f5cὝ\u1f5eὟ\u1f7eᾀ\u1fb5ᾶ\u1fbdι\u1fbfῂ\u1fc5ῆ\u1fcdῐ\u1fd4ῖ\u1fdcῠ\u1fedῲ\u1ff5ῶ\u1ffd\u20d0\u20dd\u20e1\u20e2Ω℧Kℬ℮ℯↀↃ々〆〇〈〡〰〱〶ぁゕ\u3099\u309bゝゟァ・ーヿㄅㄭ一龦가\ud7a4" },
				{ "_xmlD", "0:٠٪۰ۺ०॰০ৰ੦\u0a70૦૰୦୰௧௰౦\u0c70೦\u0cf0൦൰๐๚໐\u0eda༠༪၀၊፩፲០\u17ea᠐\u181a０：" },
				{ "_xmlI", ":;A[_`a{À×Ø÷øĲĴĿŁŉŊſƀǄǍǱǴǶǺȘɐʩʻ\u02c2Ά·Έ\u038bΌ\u038dΎ\u03a2ΣϏϐϗϚϛϜϝϞϟϠϡϢϴЁЍЎѐёѝў҂ҐӅӇӉӋӍӐӬӮӶӸӺԱ\u0557ՙ՚աևא\u05ebװ׳ءػف\u064bٱڸںڿۀۏې۔ە\u06d6ۥ\u06e7अ\u093aऽ\u093eक़\u0962অ\u098dএ\u0991ও\u09a9প\u09b1ল\u09b3শ\u09baড়\u09deয়\u09e2ৰ৲ਅ\u0a0bਏ\u0a11ਓ\u0a29ਪ\u0a31ਲ\u0a34ਵ\u0a37ਸ\u0a3aਖ਼\u0a5dਫ਼\u0a5fੲ\u0a75અઌઍ\u0a8eએ\u0a92ઓ\u0aa9પ\u0ab1લ\u0ab4વ\u0abaઽ\u0abeૠૡଅ\u0b0dଏ\u0b11ଓ\u0b29ପ\u0b31ଲ\u0b34ଶ\u0b3aଽ\u0b3eଡ଼\u0b5eୟ\u0b62அ\u0b8bஎ\u0b91ஒ\u0b96ங\u0b9bஜ\u0b9dஞ\u0ba0ண\u0ba5ந\u0babமஶஷ\u0bbaఅ\u0c0dఎ\u0c11ఒ\u0c29పఴవ\u0c3aౠ\u0c62ಅ\u0c8dಎ\u0c91ಒ\u0ca9ಪ\u0cb4ವ\u0cbaೞ\u0cdfೠ\u0ce2അ\u0d0dഎ\u0d11ഒഩപഺൠ\u0d62กฯะ\u0e31า\u0e34เๆກ\u0e83ຄ\u0e85ງ\u0e89ຊ\u0e8bຍ\u0e8eດ\u0e98ນ\u0ea0ມ\u0ea4ລ\u0ea6ວ\u0ea8ສ\u0eacອຯະ\u0eb1າ\u0eb4ຽ\u0ebeເ\u0ec5ཀ\u0f48ཉཪႠ\u10c6აჷᄀᄁᄂᄄᄅᄈᄉᄊᄋᄍᄎᄓᄼᄽᄾᄿᅀᅁᅌᅍᅎᅏᅐᅑᅔᅖᅙᅚᅟᅢᅣᅤᅥᅦᅧᅨᅩᅪᅭᅯᅲᅴᅵᅶᆞᆟᆨᆩᆫᆬᆮᆰᆷᆹᆺᆻᆼᇃᇫᇬᇰᇱᇹᇺḀẜẠỺἀ\u1f16Ἐ\u1f1eἠ\u1f46Ὀ\u1f4eὐ\u1f58Ὑ\u1f5aὛ\u1f5cὝ\u1f5eὟ\u1f7eᾀ\u1fb5ᾶ\u1fbdι\u1fbfῂ\u1fc5ῆ\u1fcdῐ\u1fd4ῖ\u1fdcῠ\u1fedῲ\u1ff5ῶ\u1ffdΩ℧Kℬ℮ℯↀↃ〇〈〡\u302aぁゕァ・ㄅㄭ一龦가\ud7a4" },
				{ "_xmlW", "$%+,0:<?A[^_`{|}~\u007f¢«¬­®·\u00b8»¼¿ÀȡȢȴɐʮʰ\u02ef\u0300\u0350\u0360ͰʹͶͺͻ\u0384·Έ\u038bΌ\u038dΎ\u03a2ΣϏϐϷЀ\u0487\u0488ӏӐӶӸӺԀԐԱ\u0557ՙ՚ա\u0588\u0591\u05a2\u05a3\u05ba\u05bb־\u05bf׀\u05c1׃\u05c4\u05c5א\u05ebװ׳ءػـ\u0656٠٪ٮ۔ە\u06dd۞ۮ۰ۿܐܭ\u0730\u074bހ\u07b2\u0901ऄअ\u093a\u093c\u094eॐ\u0955क़।०॰\u0981\u0984অ\u098dএ\u0991ও\u09a9প\u09b1ল\u09b3শ\u09ba\u09bcঽ\u09be\u09c5\u09c7\u09c9\u09cbৎ\u09d7\u09d8ড়\u09deয়\u09e4০৻\u0a02\u0a03ਅ\u0a0bਏ\u0a11ਓ\u0a29ਪ\u0a31ਲ\u0a34ਵ\u0a37ਸ\u0a3a\u0a3c\u0a3d\u0a3e\u0a43\u0a47\u0a49\u0a4b\u0a4eਖ਼\u0a5dਫ਼\u0a5f੦\u0a75\u0a81\u0a84અઌઍ\u0a8eએ\u0a92ઓ\u0aa9પ\u0ab1લ\u0ab4વ\u0aba\u0abc\u0ac6\u0ac7\u0aca\u0acb\u0aceૐ\u0ad1ૠૡ૦૰\u0b01\u0b04ଅ\u0b0dଏ\u0b11ଓ\u0b29ପ\u0b31ଲ\u0b34ଶ\u0b3a\u0b3c\u0b44\u0b47\u0b49\u0b4b\u0b4e\u0b56\u0b58ଡ଼\u0b5eୟ\u0b62୦ୱ\u0b82\u0b84அ\u0b8bஎ\u0b91ஒ\u0b96ங\u0b9bஜ\u0b9dஞ\u0ba0ண\u0ba5ந\u0babமஶஷ\u0bba\u0bbe\u0bc3\u0bc6\u0bc9\u0bca\u0bce\u0bd7\u0bd8௧௳\u0c01\u0c04అ\u0c0dఎ\u0c11ఒ\u0c29పఴవ\u0c3a\u0c3e\u0c45\u0c46\u0c49\u0c4a\u0c4e\u0c55\u0c57ౠ\u0c62౦\u0c70\u0c82\u0c84ಅ\u0c8dಎ\u0c91ಒ\u0ca9ಪ\u0cb4ವ\u0cba\u0cbe\u0cc5\u0cc6\u0cc9\u0cca\u0cce\u0cd5\u0cd7ೞ\u0cdfೠ\u0ce2೦\u0cf0\u0d02\u0d04അ\u0d0dഎ\u0d11ഒഩപഺ\u0d3e\u0d44\u0d46\u0d49\u0d4aൎ\u0d57\u0d58ൠ\u0d62൦൰\u0d82\u0d84අ\u0d97ක\u0db2ඳ\u0dbcල\u0dbeව\u0dc7\u0dca\u0dcb\u0dcf\u0dd5\u0dd6\u0dd7\u0dd8\u0de0\u0df2෴ก\u0e3b฿๏๐๚ກ\u0e83ຄ\u0e85ງ\u0e89ຊ\u0e8bຍ\u0e8eດ\u0e98ນ\u0ea0ມ\u0ea4ລ\u0ea6ວ\u0ea8ສ\u0eacອ\u0eba\u0ebb\u0ebeເ\u0ec5ໆ\u0ec7\u0ec8\u0ece໐\u0edaໜໞༀ༄༓༺\u0f3e\u0f48ཉཫ\u0f71྅\u0f86ྌ\u0f90\u0f98\u0f99\u0fbd྾\u0fcd࿏࿐ကဢဣဨဩ\u102b\u102c\u1033\u1036\u103a၀၊ၐၚႠ\u10c6აჹᄀᅚᅟᆣᆨᇺሀሇለቇቈ\u1249ቊ\u124eቐ\u1257ቘ\u1259ቚ\u125eበኇኈ\u1289ኊ\u128eነኯኰ\u12b1ኲ\u12b6ኸ\u12bfዀ\u12c1ዂ\u12c6ወዏዐ\u12d7ዘዯደጏጐ\u1311ጒ\u1316ጘጟጠፇፈ\u135b፩\u137dᎠᏵᐁ᙭ᙯᙷᚁ᚛ᚠ᛫ᛮᛱᜀ\u170dᜎ\u1715ᜠ᜵ᝀ\u1754ᝠ\u176dᝮ\u1771\u1772\u1774ក។ៗ៘៛\u17dd០\u17ea\u180b\u180e᠐\u181aᠠ\u1878ᢀᢪḀẜẠỺἀ\u1f16Ἐ\u1f1eἠ\u1f46Ὀ\u1f4eὐ\u1f58Ὑ\u1f5aὛ\u1f5cὝ\u1f5eὟ\u1f7eᾀ\u1fb5ᾶ\u1fc5ῆ\u1fd4ῖ\u1fdc\u1fdd\u1ff0ῲ\u1ff5ῶ\u1fff⁄⁅⁒⁓⁰\u2072⁴⁽ⁿ₍₠₲\u20d0\u20eb℀℻ℽ⅌⅓ↄ←〈⌫⎴⎷⏏␀\u2427⑀\u244b①⓿─☔☖☘☙♾⚀⚊✁✅✆✊✌✨✩❌❍❎❏❓❖❗❘❟❡❨❶➕➘➰➱➿⟐⟦⟰⦃⦙⧘⧜⧼⧾⬀⺀\u2e9a⺛\u2ef4⼀\u2fd6⿰\u2ffc〄〈〒〔〠〰〱〽〾\u3040ぁ\u3097\u3099゠ァ・ー\u3100ㄅㄭㄱ\u318f㆐ㆸㇰ㈝㈠㉄㉑㉼㉿㋌㋐\u32ff㌀㍷㍻㏞㏠㏿㐀\u4db6一龦ꀀ\ua48d꒐\ua4c7가\ud7a4豈郞侮恵ﬀ\ufb07ﬓ\ufb18יִ\ufb37טּ\ufb3dמּ\ufb3fנּ\ufb42ףּ\ufb45צּ\ufbb2ﯓ﴾ﵐ\ufd90ﶒ\ufdc8ﷰ﷽\ufe00︐\ufe20\ufe24﹢﹣﹤\ufe67﹩﹪ﹰ\ufe75ﹶ\ufefd＄％＋，０：＜？Ａ［\uff3e\uff3f\uff40｛｜｝～｟ｦ\uffbfￂ\uffc8ￊ\uffd0ￒ\uffd8ￚ\uffdd￠\uffe7￨\uffef￼\ufffe" }
			};
			Class395.struct42_0 = new Struct42[94]
			{
				new Struct42('A', 'Z', 1, 32),
				new Struct42('À', 'Þ', 1, 32),
				new Struct42('Ā', 'Į', 2, 0),
				new Struct42('İ', 'İ', 0, 105),
				new Struct42('Ĳ', 'Ķ', 2, 0),
				new Struct42('Ĺ', 'Ň', 3, 0),
				new Struct42('Ŋ', 'Ŷ', 2, 0),
				new Struct42('Ÿ', 'Ÿ', 0, 255),
				new Struct42('Ź', 'Ž', 3, 0),
				new Struct42('Ɓ', 'Ɓ', 0, 595),
				new Struct42('Ƃ', 'Ƅ', 2, 0),
				new Struct42('Ɔ', 'Ɔ', 0, 596),
				new Struct42('Ƈ', 'Ƈ', 0, 392),
				new Struct42('Ɖ', 'Ɗ', 1, 205),
				new Struct42('Ƌ', 'Ƌ', 0, 396),
				new Struct42('Ǝ', 'Ǝ', 0, 477),
				new Struct42('Ə', 'Ə', 0, 601),
				new Struct42('Ɛ', 'Ɛ', 0, 603),
				new Struct42('Ƒ', 'Ƒ', 0, 402),
				new Struct42('Ɠ', 'Ɠ', 0, 608),
				new Struct42('Ɣ', 'Ɣ', 0, 611),
				new Struct42('Ɩ', 'Ɩ', 0, 617),
				new Struct42('Ɨ', 'Ɨ', 0, 616),
				new Struct42('Ƙ', 'Ƙ', 0, 409),
				new Struct42('Ɯ', 'Ɯ', 0, 623),
				new Struct42('Ɲ', 'Ɲ', 0, 626),
				new Struct42('Ɵ', 'Ɵ', 0, 629),
				new Struct42('Ơ', 'Ƥ', 2, 0),
				new Struct42('Ƨ', 'Ƨ', 0, 424),
				new Struct42('Ʃ', 'Ʃ', 0, 643),
				new Struct42('Ƭ', 'Ƭ', 0, 429),
				new Struct42('Ʈ', 'Ʈ', 0, 648),
				new Struct42('Ư', 'Ư', 0, 432),
				new Struct42('Ʊ', 'Ʋ', 1, 217),
				new Struct42('Ƴ', 'Ƶ', 3, 0),
				new Struct42('Ʒ', 'Ʒ', 0, 658),
				new Struct42('Ƹ', 'Ƹ', 0, 441),
				new Struct42('Ƽ', 'Ƽ', 0, 445),
				new Struct42('Ǆ', 'ǅ', 0, 454),
				new Struct42('Ǉ', 'ǈ', 0, 457),
				new Struct42('Ǌ', 'ǋ', 0, 460),
				new Struct42('Ǎ', 'Ǜ', 3, 0),
				new Struct42('Ǟ', 'Ǯ', 2, 0),
				new Struct42('Ǳ', 'ǲ', 0, 499),
				new Struct42('Ǵ', 'Ǵ', 0, 501),
				new Struct42('Ǻ', 'Ȗ', 2, 0),
				new Struct42('Ά', 'Ά', 0, 940),
				new Struct42('Έ', 'Ί', 1, 37),
				new Struct42('Ό', 'Ό', 0, 972),
				new Struct42('Ύ', 'Ώ', 1, 63),
				new Struct42('Α', 'Ϋ', 1, 32),
				new Struct42('Ϣ', 'Ϯ', 2, 0),
				new Struct42('Ё', 'Џ', 1, 80),
				new Struct42('А', 'Я', 1, 32),
				new Struct42('Ѡ', 'Ҁ', 2, 0),
				new Struct42('Ґ', 'Ҿ', 2, 0),
				new Struct42('Ӂ', 'Ӄ', 3, 0),
				new Struct42('Ӈ', 'Ӈ', 0, 1224),
				new Struct42('Ӌ', 'Ӌ', 0, 1228),
				new Struct42('Ӑ', 'Ӫ', 2, 0),
				new Struct42('Ӯ', 'Ӵ', 2, 0),
				new Struct42('Ӹ', 'Ӹ', 0, 1273),
				new Struct42('Ա', 'Ֆ', 1, 48),
				new Struct42('Ⴀ', 'Ⴥ', 1, 48),
				new Struct42('Ḁ', 'Ỹ', 2, 0),
				new Struct42('Ἀ', 'Ἇ', 1, -8),
				new Struct42('Ἐ', '\u1f1f', 1, -8),
				new Struct42('Ἠ', 'Ἧ', 1, -8),
				new Struct42('Ἰ', 'Ἷ', 1, -8),
				new Struct42('Ὀ', 'Ὅ', 1, -8),
				new Struct42('Ὑ', 'Ὑ', 0, 8017),
				new Struct42('Ὓ', 'Ὓ', 0, 8019),
				new Struct42('Ὕ', 'Ὕ', 0, 8021),
				new Struct42('Ὗ', 'Ὗ', 0, 8023),
				new Struct42('Ὠ', 'Ὧ', 1, -8),
				new Struct42('ᾈ', 'ᾏ', 1, -8),
				new Struct42('ᾘ', 'ᾟ', 1, -8),
				new Struct42('ᾨ', 'ᾯ', 1, -8),
				new Struct42('Ᾰ', 'Ᾱ', 1, -8),
				new Struct42('Ὰ', 'Ά', 1, -74),
				new Struct42('ᾼ', 'ᾼ', 0, 8115),
				new Struct42('Ὲ', 'Ή', 1, -86),
				new Struct42('ῌ', 'ῌ', 0, 8131),
				new Struct42('Ῐ', 'Ῑ', 1, -8),
				new Struct42('Ὶ', 'Ί', 1, -100),
				new Struct42('Ῠ', 'Ῡ', 1, -8),
				new Struct42('Ὺ', 'Ύ', 1, -112),
				new Struct42('Ῥ', 'Ῥ', 0, 8165),
				new Struct42('Ὸ', 'Ό', 1, -128),
				new Struct42('Ὼ', 'Ώ', 1, -126),
				new Struct42('ῼ', 'ῼ', 0, 8179),
				new Struct42('Ⅰ', 'Ⅿ', 1, 16),
				new Struct42('Ⓐ', 'ⓐ', 1, 26),
				new Struct42('Ａ', 'Ｚ', 1, 32)
			};
			Dictionary<string, string> dictionary = new Dictionary<string, string>(32);
			char[] array = new char[9];
			StringBuilder stringBuilder = new StringBuilder(11);
			stringBuilder.Append('\0');
			array[0] = '\0';
			array[1] = '\u000f';
			dictionary["Cc"] = array[1].ToString();
			array[2] = '\u0010';
			dictionary["Cf"] = array[2].ToString();
			array[3] = '\u001e';
			dictionary["Cn"] = array[3].ToString();
			array[4] = '\u0012';
			dictionary["Co"] = array[4].ToString();
			array[5] = '\u0011';
			dictionary["Cs"] = array[5].ToString();
			array[6] = '\0';
			dictionary["C"] = new string(array, 0, 7);
			array[1] = '\u0002';
			dictionary["Ll"] = array[1].ToString();
			array[2] = '\u0004';
			dictionary["Lm"] = array[2].ToString();
			array[3] = '\u0005';
			dictionary["Lo"] = array[3].ToString();
			array[4] = '\u0003';
			dictionary["Lt"] = array[4].ToString();
			array[5] = '\u0001';
			dictionary["Lu"] = array[5].ToString();
			dictionary["L"] = new string(array, 0, 7);
			stringBuilder.Append(new string(array, 1, 5));
			dictionary[Class395.string_14] = string.Format(CultureInfo.InvariantCulture, "{0}{1}{2}{3}{4}", '\0', array[1], array[4], array[5], array[6]);
			array[1] = '\a';
			dictionary["Mc"] = array[1].ToString();
			array[2] = '\b';
			dictionary["Me"] = array[2].ToString();
			array[3] = '\u0006';
			dictionary["Mn"] = array[3].ToString();
			array[4] = '\0';
			dictionary["M"] = new string(array, 0, 5);
			stringBuilder.Append(array[3]);
			array[1] = '\t';
			dictionary["Nd"] = array[1].ToString();
			array[2] = '\n';
			dictionary["Nl"] = array[2].ToString();
			array[3] = '\v';
			dictionary["No"] = array[3].ToString();
			dictionary["N"] = new string(array, 0, 5);
			stringBuilder.Append(array[1]);
			array[1] = '\u0013';
			dictionary["Pc"] = array[1].ToString();
			array[2] = '\u0014';
			dictionary["Pd"] = array[2].ToString();
			array[3] = '\u0016';
			dictionary["Pe"] = array[3].ToString();
			array[4] = '\u0019';
			dictionary["Po"] = array[4].ToString();
			array[5] = '\u0015';
			dictionary["Ps"] = array[5].ToString();
			array[6] = '\u0018';
			dictionary["Pf"] = array[6].ToString();
			array[7] = '\u0017';
			dictionary["Pi"] = array[7].ToString();
			array[8] = '\0';
			dictionary["P"] = new string(array, 0, 9);
			stringBuilder.Append(array[1]);
			array[1] = '\u001b';
			dictionary["Sc"] = array[1].ToString();
			array[2] = '\u001c';
			dictionary["Sk"] = array[2].ToString();
			array[3] = '\u001a';
			dictionary["Sm"] = array[3].ToString();
			array[4] = '\u001d';
			dictionary["So"] = array[4].ToString();
			array[5] = '\0';
			dictionary["S"] = new string(array, 0, 6);
			array[1] = '\r';
			dictionary["Zl"] = array[1].ToString();
			array[2] = '\u000e';
			dictionary["Zp"] = array[2].ToString();
			array[3] = '\f';
			dictionary["Zs"] = array[3].ToString();
			array[4] = '\0';
			dictionary["Z"] = new string(array, 0, 5);
			stringBuilder.Append('\0');
			Class395.string_17 = stringBuilder.ToString();
			Class395.string_18 = Class395.smethod_15(Class395.string_17);
			Class395.string_19 = "\0\0\u0001" + Class395.string_15;
			Class395.string_20 = "\u0001\0\u0001" + Class395.string_15;
			Class395.string_21 = "\0\0" + (char)Class395.string_17.Length + Class395.string_17;
			Class395.string_22 = "\u0001\0" + (char)Class395.string_17.Length + Class395.string_17;
			Class395.string_23 = "\0\0\u0001" + '\t';
			Class395.string_24 = "\0\0\u0001" + '\ufff7';
			Class395.dictionary_0 = dictionary;
		}

		internal Class395()
		{
			this.list_0 = new List<Class397>(6);
			this.bool_0 = true;
			this.stringBuilder_0 = new StringBuilder();
		}

		private Class395(bool bool_2, List<Class397> list_1, StringBuilder stringBuilder_1, Class395 class395_1)
		{
			this.list_0 = list_1;
			this.stringBuilder_0 = stringBuilder_1;
			this.bool_0 = true;
			this.bool_1 = bool_2;
			this.class395_0 = class395_1;
		}

		internal void method_0(Class395 class395_1)
		{
			if (!class395_1.bool_0)
			{
				this.bool_0 = false;
			}
			else if (this.bool_0 && this.method_10() > 0 && class395_1.method_10() > 0 && class395_1.method_11(0).char_0 <= this.method_11(this.method_10() - 1).char_1)
			{
				this.bool_0 = false;
			}
			for (int i = 0; i < class395_1.method_10(); i++)
			{
				this.list_0.Add(class395_1.method_11(i));
			}
			this.stringBuilder_0.Append(class395_1.stringBuilder_0.ToString());
		}

		internal void method_1(char char_5, char char_6)
		{
			this.list_0.Add(new Class397(char_5, char_6));
			if (this.bool_0 && this.list_0.Count > 0 && char_5 <= this.list_0[this.list_0.Count - 1].char_1)
			{
				this.bool_0 = false;
			}
		}

		internal void method_2(string string_26, bool bool_2, bool bool_3, string string_27, Class398 class398_0)
		{
			Class395.dictionary_0.TryGetValue(string_26, out var value);
			if (value != null && !string_26.Equals(Class395.string_14))
			{
				string text = value;
				if (bool_3 && (string_26.Equals("Ll") || string_26.Equals("Lu") || string_26.Equals("Lt")))
				{
					text = Class395.dictionary_0[Class395.string_14];
				}
				if (bool_2)
				{
					text = Class395.smethod_15(text);
				}
				this.stringBuilder_0.Append(text);
			}
			else
			{
				this.method_8(Class395.smethod_17(string_26, bool_2, string_27, class398_0));
			}
		}

		internal void method_3(CultureInfo cultureInfo_0)
		{
			this.bool_0 = false;
			int i = 0;
			for (int count = this.list_0.Count; i < count; i++)
			{
				Class397 @class = this.list_0[i];
				if (@class.char_0 == @class.char_1)
				{
					@class.char_0 = (@class.char_1 = char.ToLower(@class.char_0, cultureInfo_0));
				}
				else
				{
					this.method_9(@class.char_0, @class.char_1, cultureInfo_0);
				}
			}
		}

		internal void method_4(bool bool_2, bool bool_3)
		{
			if (bool_3)
			{
				if (bool_2)
				{
					this.method_8("\00:A[_`a{İı");
				}
				else
				{
					this.stringBuilder_0.Append(Class395.string_18);
				}
			}
			else if (bool_2)
			{
				this.method_8("0:A[_`a{İı");
			}
			else
			{
				this.stringBuilder_0.Append(Class395.string_17);
			}
		}

		internal void method_5(bool bool_2, bool bool_3)
		{
			if (bool_3)
			{
				if (bool_2)
				{
					this.method_8("\0\t\u000e !");
				}
				else
				{
					this.stringBuilder_0.Append(Class395.string_16);
				}
			}
			else if (bool_2)
			{
				this.method_8("\t\u000e !");
			}
			else
			{
				this.stringBuilder_0.Append(Class395.string_15);
			}
		}

		internal void method_6(bool bool_2, bool bool_3, string string_26, Class398 class398_0)
		{
			if (bool_2)
			{
				if (bool_3)
				{
					this.method_8("\00:");
				}
				else
				{
					this.method_8("0:");
				}
			}
			else
			{
				this.method_2("Nd", bool_3, bool_3: false, string_26, class398_0);
			}
		}

		internal static char smethod_0(string string_26)
		{
			return string_26[3];
		}

		internal static bool smethod_1(string string_26)
		{
			if (!Class395.smethod_9(string_26))
			{
				return !Class395.smethod_8(string_26);
			}
			return false;
		}

		internal static bool smethod_2(string string_26)
		{
			if (string_26[2] == '\0' && string_26[0] == '\0' && string_26[1] == '\0' && !Class395.smethod_8(string_26))
			{
				return true;
			}
			return false;
		}

		internal static bool smethod_3(string string_26)
		{
			if (string_26[0] == '\0' && string_26[2] == '\0' && string_26[1] == '\u0002' && !Class395.smethod_8(string_26) && (string_26[3] == '\uffff' || string_26[3] + 1 == string_26[4]))
			{
				return true;
			}
			return false;
		}

		internal static bool smethod_4(string string_26)
		{
			if (string_26[0] == '\u0001' && string_26[2] == '\0' && string_26[1] == '\u0002' && !Class395.smethod_8(string_26) && (string_26[3] == '\uffff' || string_26[3] + 1 == string_26[4]))
			{
				return true;
			}
			return false;
		}

		internal static bool smethod_5(char char_5)
		{
			return Class395.smethod_10(char_5, "\0\n\00:A[_`a{İı");
		}

		internal static bool smethod_6(char char_5)
		{
			if (!Class395.smethod_10(char_5, Class395.string_21) && char_5 != '\u200d')
			{
				return char_5 == '\u200c';
			}
			return true;
		}

		internal static Class395 smethod_7(string string_26)
		{
			return Class395.smethod_16(string_26, 0);
		}

		internal string method_7()
		{
			if (!this.bool_0)
			{
				this.method_12();
			}
			int num = this.list_0.Count * 2;
			StringBuilder stringBuilder = new StringBuilder(num + this.stringBuilder_0.Length + 3);
			int num2 = (this.bool_1 ? 1 : 0);
			stringBuilder.Append((char)num2);
			stringBuilder.Append((char)num);
			stringBuilder.Append((char)this.stringBuilder_0.Length);
			for (int i = 0; i < this.list_0.Count; i++)
			{
				Class397 @class = this.list_0[i];
				stringBuilder.Append(@class.char_0);
				if (@class.char_1 != '\uffff')
				{
					stringBuilder.Append((char)(@class.char_1 + 1));
				}
			}
			stringBuilder[1] = (char)(stringBuilder.Length - 3);
			stringBuilder.Append(this.stringBuilder_0);
			if (this.class395_0 != null)
			{
				stringBuilder.Append(this.class395_0.method_7());
			}
			return stringBuilder.ToString();
		}

		private void method_8(string string_26)
		{
			if (this.bool_0 && this.method_10() > 0 && string_26.Length > 0 && string_26[0] <= this.method_11(this.method_10() - 1).char_1)
			{
				this.bool_0 = false;
			}
			int i;
			for (i = 0; i < string_26.Length - 1; i += 2)
			{
				this.list_0.Add(new Class397(string_26[i], (char)(string_26[i + 1] - 1)));
			}
			if (i < string_26.Length)
			{
				this.list_0.Add(new Class397(string_26[i], '\uffff'));
			}
		}

		private void method_9(char char_5, char char_6, CultureInfo cultureInfo_0)
		{
			int i = 0;
			int num = Class395.struct42_0.Length;
			while (i < num)
			{
				int num2 = (i + num) / 2;
				if (Class395.struct42_0[num2].char_1 < char_5)
				{
					i = num2 + 1;
				}
				else
				{
					num = num2;
				}
			}
			if (i >= Class395.struct42_0.Length)
			{
				return;
			}
			for (; i < Class395.struct42_0.Length; i++)
			{
				Struct42 @struct;
				Struct42 struct2 = (@struct = Class395.struct42_0[i]);
				if (struct2.char_0 <= char_6)
				{
					char c;
					if ((c = @struct.char_0) < char_5)
					{
						c = char_5;
					}
					char c2;
					if ((c2 = @struct.char_1) > char_6)
					{
						c2 = char_6;
					}
					switch (@struct.int_0)
					{
					case 0:
						c = (char)@struct.int_1;
						c2 = (char)@struct.int_1;
						break;
					case 1:
						c = (char)(c + (ushort)@struct.int_1);
						c2 = (char)(c2 + (ushort)@struct.int_1);
						break;
					case 2:
						c = (char)(c | 1u);
						c2 = (char)(c2 | 1u);
						break;
					case 3:
						c = (char)(c + (ushort)(c & 1));
						c2 = (char)(c2 + (ushort)(c2 & 1));
						break;
					}
					if (c < char_5 || c2 > char_6)
					{
						this.method_1(c, c2);
					}
					continue;
				}
				break;
			}
		}

		private static bool smethod_8(string string_26)
		{
			return string_26.Length > 3 + string_26[1] + string_26[2];
		}

		private static bool smethod_9(string string_26)
		{
			if (string_26 != null)
			{
				return string_26[0] == '\u0001';
			}
			return false;
		}

		private static bool smethod_10(char char_5, string string_26)
		{
			return Class395.smethod_11(char_5, string_26, 0);
		}

		private static bool smethod_11(char char_5, string string_26, int int_8)
		{
			int num = string_26[int_8 + 1];
			int num2 = string_26[int_8 + 2];
			int num3 = int_8 + 3 + num + num2;
			bool flag = false;
			if (string_26.Length > num3)
			{
				flag = Class395.smethod_11(char_5, string_26, num3);
			}
			bool flag2 = Class395.smethod_12(char_5, string_26, int_8, num, num2);
			if (string_26[int_8] == '\u0001')
			{
				flag2 = !flag2;
			}
			if (flag2)
			{
				return !flag;
			}
			return false;
		}

		private static bool smethod_12(char char_5, string string_26, int int_8, int int_9, int int_10)
		{
			int num = int_8 + 3;
			int num2 = num + int_9;
			while (num != num2)
			{
				int num3 = (num + num2) / 2;
				if (char_5 < string_26[num3])
				{
					num2 = num3;
				}
				else
				{
					num = num3 + 1;
				}
			}
			if ((num & 1) == (int_8 & 1))
			{
				return true;
			}
			if (int_10 == 0)
			{
				return false;
			}
			return Class395.smethod_13(char_5, string_26, int_8, int_9, int_10);
		}

		private static bool smethod_13(char char_5, string string_26, int int_8, int int_9, int int_10)
		{
			UnicodeCategory unicodeCategory = char.GetUnicodeCategory(char_5);
			int int_11 = int_8 + 3 + int_9;
			int num = int_11 + int_10;
			while (true)
			{
				if (int_11 < num)
				{
					int num2 = (short)string_26[int_11];
					if (num2 == 0)
					{
						if (Class395.smethod_14(char_5, unicodeCategory, string_26, ref int_11))
						{
							return true;
						}
					}
					else if (num2 > 0)
					{
						if (num2 == 100)
						{
							if (!char.IsWhiteSpace(char_5))
							{
								int_11++;
								continue;
							}
							return true;
						}
						num2--;
						if (unicodeCategory == (UnicodeCategory)num2)
						{
							return true;
						}
					}
					else
					{
						if (num2 == -100)
						{
							if (char.IsWhiteSpace(char_5))
							{
								int_11++;
								continue;
							}
							return true;
						}
						num2 = -1 - num2;
						if (unicodeCategory != (UnicodeCategory)num2)
						{
							break;
						}
					}
					int_11++;
					continue;
				}
				return false;
			}
			return true;
		}

		private static bool smethod_14(char char_5, UnicodeCategory unicodeCategory_0, string string_26, ref int int_8)
		{
			int_8++;
			int num = (short)string_26[int_8];
			if (num > 0)
			{
				bool flag = false;
				while (num != 0)
				{
					if (!flag)
					{
						num--;
						if (unicodeCategory_0 == (UnicodeCategory)num)
						{
							flag = true;
						}
					}
					int_8++;
					num = (short)string_26[int_8];
				}
				return flag;
			}
			bool flag2 = true;
			while (num != 0)
			{
				if (flag2)
				{
					num = -1 - num;
					if (unicodeCategory_0 == (UnicodeCategory)num)
					{
						flag2 = false;
					}
				}
				int_8++;
				num = (short)string_26[int_8];
			}
			return flag2;
		}

		private static string smethod_15(string string_26)
		{
			if (string_26 == null)
			{
				return null;
			}
			StringBuilder stringBuilder = new StringBuilder(string_26.Length);
			for (int i = 0; i < string_26.Length; i++)
			{
				short num = (short)string_26[i];
				stringBuilder.Append((char)(-num));
			}
			return stringBuilder.ToString();
		}

		private static Class395 smethod_16(string string_26, int int_8)
		{
			int num = string_26[int_8 + 1];
			int num2 = string_26[int_8 + 2];
			int num3 = int_8 + 3 + num + num2;
			List<Class397> list = new List<Class397>(num);
			int num4 = int_8 + 3;
			int num5 = num4 + num;
			while (num4 < num5)
			{
				char c = string_26[num4];
				num4++;
				char c2 = ((num4 >= num5) ? '\uffff' : ((char)(string_26[num4] - 1)));
				num4++;
				list.Add(new Class397(c, c2));
			}
			Class395 class395_ = null;
			if (string_26.Length > num3)
			{
				class395_ = Class395.smethod_16(string_26, num3);
			}
			return new Class395(string_26[int_8] == '\u0001', list, new StringBuilder(string_26.Substring(num5, num2)), class395_);
		}

		private int method_10()
		{
			return this.list_0.Count;
		}

		private Class397 method_11(int int_8)
		{
			return this.list_0[int_8];
		}

		private void method_12()
		{
			this.bool_0 = true;
			this.list_0.Sort(0, this.list_0.Count, new Class396());
			if (this.list_0.Count <= 1)
			{
				return;
			}
			bool flag = false;
			int num = 1;
			int num2 = 0;
			while (true)
			{
				char c = this.list_0[num2].char_1;
				while (true)
				{
					if (num != this.list_0.Count && c != '\uffff')
					{
						Class397 @class;
						if ((@class = this.list_0[num]).char_0 > c + 1)
						{
							break;
						}
						if (c < @class.char_1)
						{
							c = @class.char_1;
						}
						num++;
						continue;
					}
					flag = true;
					break;
				}
				this.list_0[num2].char_1 = c;
				num2++;
				if (flag)
				{
					break;
				}
				if (num2 < num)
				{
					this.list_0[num2] = this.list_0[num];
				}
				num++;
			}
			this.list_0.RemoveRange(num2, this.list_0.Count - num2);
		}

		private static string smethod_17(string string_26, bool bool_2, string string_27, Class398 class398_0)
		{
			int num = 0;
			int num2 = Class395.string_25.GetLength(0);
			int num3;
			while (true)
			{
				if (num != num2)
				{
					num3 = (num + num2) / 2;
					int num4 = string.Compare(string_26, Class395.string_25[num3, 0], StringComparison.Ordinal);
					if (num4 < 0)
					{
						num2 = num3;
						continue;
					}
					if (num4 <= 0)
					{
						break;
					}
					num = num3 + 1;
					continue;
				}
				class398_0.Boolean_0 = false;
				class398_0.String_0 = "SR.GetString(SR.MakeException, pattern, SR.GetString(SR.UnknownProperty, capname))";
				return "";
			}
			string text = Class395.string_25[num3, 1];
			if (bool_2)
			{
				if (text[0] == '\0')
				{
					return text.Substring(1);
				}
				return '\0' + text;
			}
			return text;
		}
	}
}
