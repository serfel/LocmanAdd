using System;
using System.Collections.Generic;
using DocumentServer.Fields;

namespace ns12
{
	internal class Dialog0 : MailMergeFieldDialogCommon
	{
		private DateField dateField_0;

		private static readonly string[] string_0 = new string[16]
		{
			"dd.MM.yyyy", "dddd, d. MMMM yyyy", "d. MMMM yyyy", "dd.MM.yy", "yyyy-MM-dd", "yy-MM-dd", "dd. MMM. yyyy", "dd/MM/yy", "MMMM yy", "MMM-yy",
			"dd.MM.yyyy HH:mm", "dd.MM.yyyy HH:mm:ss", "h:mm tt", "h:mm:ss tt", "HH:mm", "HH:mm:ss"
		};

		public const string string_1 = "Value";

		public const string string_2 = "Key";

		public List<KeyValuePair<string, string>> List_0
		{
			get
			{
				List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
				DateTime now = DateTime.Now;
				string[] array = Dialog0.string_0;
				foreach (string text in array)
				{
					list.Add(new KeyValuePair<string, string>(text, now.ToString(text)));
				}
				return list;
			}
		}

		public string String_0
		{
			get
			{
				return this.dateField_0.Format;
			}
			set
			{
				this.dateField_0.Format = value;
			}
		}

		public Dialog0(DateField dateField_1)
			: base(dateField_1)
		{
			this.dateField_0 = dateField_1;
		}
	}
}
