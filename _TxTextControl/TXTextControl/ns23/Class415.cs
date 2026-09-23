using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;

namespace ns23
{
	internal class Class415
	{
		private class Class416 : IComparer<CultureInfo>
		{
			public int Compare(CultureInfo x, CultureInfo y)
			{
				return x.IetfLanguageTag.CompareTo(y.IetfLanguageTag);
			}
		}

		private object object_0;

		private int int_0;

		private Type type_0;

		private Type type_1;

		private Type type_2;

		private Type type_3;

		private Type type_4;

		private Type type_5;

		private Type type_6;

		private Type type_7;

		private Type type_8;

		private Type type_9;

		private Type type_10;

		private Type type_11;

		private Type type_12;

		private MethodInfo methodInfo_0;

		private MethodInfo methodInfo_1;

		private MethodInfo methodInfo_2;

		private MethodInfo methodInfo_3;

		private MethodInfo methodInfo_4;

		private MethodInfo methodInfo_5;

		private MethodInfo methodInfo_6;

		private MethodInfo methodInfo_7;

		private MethodInfo methodInfo_8;

		private MethodInfo methodInfo_9;

		private MethodInfo methodInfo_10;

		private MethodInfo methodInfo_11;

		private MethodInfo methodInfo_12;

		private MethodInfo methodInfo_13;

		private MethodInfo methodInfo_14;

		private MethodInfo methodInfo_15;

		private PropertyInfo propertyInfo_0;

		private PropertyInfo propertyInfo_1;

		private PropertyInfo propertyInfo_2;

		private PropertyInfo propertyInfo_3;

		private PropertyInfo propertyInfo_4;

		private PropertyInfo propertyInfo_5;

		private PropertyInfo propertyInfo_6;

		private PropertyInfo propertyInfo_7;

		private PropertyInfo propertyInfo_8;

		private PropertyInfo propertyInfo_9;

		private PropertyInfo propertyInfo_10;

		private PropertyInfo propertyInfo_11;

		private PropertyInfo propertyInfo_12;

		private PropertyInfo propertyInfo_13;

		private PropertyInfo propertyInfo_14;

		private PropertyInfo propertyInfo_15;

		private PropertyInfo propertyInfo_16;

		private PropertyInfo propertyInfo_17;

		private PropertyInfo propertyInfo_18;

		private PropertyInfo propertyInfo_19;

		private PropertyInfo propertyInfo_20;

		private PropertyInfo propertyInfo_21;

		private PropertyInfo propertyInfo_22;

		private PropertyInfo propertyInfo_23;

		private PropertyInfo propertyInfo_24;

		private PropertyInfo propertyInfo_25;

		private PropertyInfo propertyInfo_26;

		private PropertyInfo propertyInfo_27;

		private PropertyInfo propertyInfo_28;

		private PropertyInfo propertyInfo_29;

		private PropertyInfo propertyInfo_30;

		private PropertyInfo propertyInfo_31;

		private FieldInfo fieldInfo_0;

		private bool bool_0;

		internal bool Boolean_0 => this.bool_0;

		internal object Object_0 => this.object_0;

		internal bool Boolean_1
		{
			get
			{
				CollectionBase collectionBase = (CollectionBase)this.propertyInfo_0.GetValue(this.object_0, null);
				if (this.int_0 >= 3)
				{
					return (bool)this.propertyInfo_10.GetValue(collectionBase, null);
				}
				foreach (object item in collectionBase)
				{
					if (item.GetType() == this.type_1 && this.method_17(item))
					{
						return true;
					}
				}
				return false;
			}
		}

		internal CollectionBase CollectionBase_0 => (CollectionBase)this.propertyInfo_0.GetValue(this.object_0, null);

		internal CollectionBase CollectionBase_1 => (CollectionBase)this.propertyInfo_1.GetValue(this.object_0, null);

		internal CollectionBase CollectionBase_2
		{
			get
			{
				if (!(this.propertyInfo_17 != null))
				{
					return null;
				}
				return (CollectionBase)this.propertyInfo_17.GetValue(this.object_0, null);
			}
		}

		internal CollectionBase CollectionBase_3 => (CollectionBase)this.propertyInfo_2.GetValue(this.object_0, null);

		internal string String_0
		{
			get
			{
				return (string)this.propertyInfo_31.GetValue(this.object_0, null);
			}
			set
			{
				this.propertyInfo_31.SetValue(this.object_0, value, null);
			}
		}

		internal CollectionBase CollectionBase_4 => (CollectionBase)this.propertyInfo_21.GetValue(this.object_0, null);

		internal bool Boolean_2 => ((int)this.propertyInfo_16.GetValue(this.object_0, null) & 0x10) != 16;

		internal CollectionBase CollectionBase_5 => (CollectionBase)this.propertyInfo_14.GetValue(this.object_0, null);

		public Class415(object object_1, bool bool_1)
		{
			if (object_1 == null)
			{
				if ((object_1 = this.method_1(bool_1)) == null)
				{
					return;
				}
				this.bool_0 = true;
			}
			this.method_0(object_1);
		}

		public Class415(object object_1)
		{
			this.method_0(object_1);
		}

		private void method_0(object object_1)
		{
			this.object_0 = object_1;
			this.type_0 = this.object_0.GetType();
			object obj = this.type_0.InvokeMember("IgnoreWord", BindingFlags.GetProperty, null, this.object_0, null);
			Assembly assembly = Assembly.GetAssembly(obj.GetType());
			this.int_0 = assembly.GetName().Version.Major;
			this.type_1 = assembly.GetType("TXTextControl.Proofing.UserDictionary");
			this.type_3 = assembly.GetType("TXTextControl.Proofing.OpenOfficeDictionary");
			this.type_2 = assembly.GetType("TXTextControl.Proofing.Dictionary");
			this.type_4 = assembly.GetType("TXTextControl.Proofing.IncorrectWord");
			this.type_5 = assembly.GetType("TXTextControl.Proofing.DictionaryCollection");
			this.type_12 = obj.GetType();
			this.methodInfo_0 = this.type_0.GetMethod("Check", new Type[1] { typeof(string) });
			this.methodInfo_2 = this.type_0.GetMethod("Create", new Type[0]);
			this.methodInfo_3 = this.type_0.GetMethod("CreateSuggestions", new Type[1] { typeof(string) });
			this.methodInfo_4 = this.type_0.GetMethod("CreateSuggestions", new Type[2]
			{
				typeof(string),
				typeof(int)
			});
			this.methodInfo_11 = this.type_1.GetMethod("AddWord", new Type[1] { typeof(string) });
			this.methodInfo_12 = this.type_0.GetMethod("OptionsDialog", new Type[0]);
			this.methodInfo_10 = this.type_5.GetMethod("Add", new Type[1] { this.type_2 });
			this.propertyInfo_0 = this.type_0.GetProperty("Dictionaries");
			this.propertyInfo_16 = this.type_0.GetProperty("IgnoreWord");
			this.propertyInfo_1 = this.type_0.GetProperty("IncorrectWords");
			this.propertyInfo_2 = this.type_0.GetProperty("Suggestions");
			this.propertyInfo_4 = this.type_2.GetProperty("IsSpellCheckingEnabled");
			this.propertyInfo_5 = this.type_2.GetProperty("IsGetSuggestionsEnabled");
			this.propertyInfo_3 = this.type_1.GetProperty("IsEditable");
			this.propertyInfo_6 = this.type_2.GetProperty("IsSelectedAsDefault");
			this.propertyInfo_7 = this.type_4.GetProperty("Start");
			this.propertyInfo_8 = this.type_4.GetProperty("Length");
			this.propertyInfo_9 = this.type_4.GetProperty("IsDuplicate");
			this.fieldInfo_0 = this.type_2.GetField("m_bIsInternalGetSuggestionsEnabled", BindingFlags.Instance | BindingFlags.NonPublic);
			if (this.int_0 >= 3)
			{
				this.propertyInfo_10 = this.type_5.GetProperty("HasEditableUserDictionaries");
				this.propertyInfo_11 = this.type_2.GetProperty("Language");
				this.propertyInfo_12 = this.type_0.GetProperty("AvailableDictionaries");
			}
			if (this.int_0 >= 4)
			{
				if (this.bool_0)
				{
					PropertyInfo property = this.type_0.GetProperty("Language");
					property.SetValue(object_1, "(none)", null);
					PropertyInfo property2 = this.type_0.GetProperty("HyphenationLanguage");
					property2.SetValue(object_1, "(none)", null);
				}
				this.propertyInfo_14 = this.type_0.GetProperty("HyphenationLists");
				this.type_6 = assembly.GetType("TXTextControl.Proofing.HyphenationList");
				this.propertyInfo_15 = this.type_6.GetProperty("Language");
				this.propertyInfo_13 = this.type_0.GetProperty("AvailableHyphenationLists");
				this.methodInfo_1 = this.type_0.GetMethod("Check", new Type[2]
				{
					typeof(string),
					typeof(CultureInfo)
				});
				this.methodInfo_5 = this.type_0.GetMethod("CreateSuggestions", new Type[2]
				{
					typeof(string),
					typeof(CultureInfo)
				});
				this.methodInfo_6 = this.type_0.GetMethod("CreateSuggestions", new Type[3]
				{
					typeof(string),
					typeof(int),
					typeof(CultureInfo)
				});
				this.methodInfo_13 = this.type_0.GetMethod("OptionsDialog", new Type[1] { typeof(int[]) });
			}
			if (this.int_0 >= 5)
			{
				this.type_7 = assembly.GetType("TXTextControl.Proofing.LanguageScope");
				this.methodInfo_14 = this.type_0.GetMethod("DetectLanguageScopes", new Type[1] { typeof(string) });
				this.propertyInfo_17 = this.type_0.GetProperty("LanguageScopes");
				this.propertyInfo_18 = this.type_7.GetProperty("Start");
				this.propertyInfo_19 = this.type_7.GetProperty("Length");
				this.propertyInfo_20 = this.type_7.GetProperty("Language");
			}
			if (this.int_0 >= 7)
			{
				if (this.bool_0)
				{
					this.propertyInfo_31 = this.type_0.GetProperty("SynonymLanguage");
					this.propertyInfo_31.SetValue(object_1, "(none)", null);
				}
				this.propertyInfo_21 = this.type_0.GetProperty("SynonymLists");
				this.methodInfo_7 = this.type_0.GetMethod("CreateSynonyms", new Type[1] { typeof(string) });
				this.methodInfo_8 = this.type_0.GetMethod("CreateSynonyms", new Type[2]
				{
					typeof(string),
					typeof(CultureInfo)
				});
				this.type_8 = assembly.GetType("TXTextControl.Proofing.SynonymGroup");
				this.propertyInfo_22 = this.type_8.GetProperty("Language");
				this.propertyInfo_23 = this.type_8.GetProperty("PartOfSpeech");
				this.propertyInfo_24 = this.type_8.GetProperty("Synonyms");
				this.type_9 = assembly.GetType("TXTextControl.Proofing.Synonym");
				this.propertyInfo_25 = this.type_9.GetProperty("Name");
				this.propertyInfo_26 = this.type_9.GetProperty("Text");
				this.type_10 = assembly.GetType("TXTextControl.Proofing.SynonymList");
				this.propertyInfo_27 = this.type_10.GetProperty("IsCreateSynonymsEnabled");
				this.propertyInfo_28 = this.type_10.GetProperty("IsSelectedAsDefault");
				this.propertyInfo_29 = this.type_10.GetProperty("Language");
				this.propertyInfo_30 = this.type_10.GetProperty("Name");
				this.methodInfo_9 = this.type_0.GetMethod("CreateSynonyms", new Type[2]
				{
					typeof(string),
					this.type_10
				});
				this.type_11 = assembly.GetType("TXTextControl.Proofing.SynonymListCollection");
				this.methodInfo_15 = this.type_11.GetMethod("Add", new Type[1] { this.type_10 });
			}
		}

		private object method_1(bool bool_1)
		{
			Type type = null;
			Assembly assembly = null;
			AssemblyName assemblyName = new AssemblyName();
			assemblyName.Name = (bool_1 ? "TXSpell.WPF" : "TXSpell.Windows.Forms");
			assemblyName.CultureInfo = new CultureInfo("");
			byte[] publicKeyToken = new byte[8] { 23, 255, 248, 167, 116, 0, 76, 102 }; //{ 107, 131, 254, 154, 117, 207, 182, 56 };
			assemblyName.SetPublicKeyToken(publicKeyToken);
			assemblyName.Version = new Version(8, 0, 700, 500);
			try
			{
				assembly = Assembly.Load(assemblyName);
			}
			catch
			{
			}
			if (assembly == null)
			{
				assemblyName.Version = new Version(7, 0, 600, 500);
				try
				{
					assembly = Assembly.Load(assemblyName);
				}
				catch
				{
				}
			}
			if (assembly == null)
			{
				assemblyName.Version = new Version(6, 0, 500, 500);
				try
				{
					assembly = Assembly.Load(assemblyName);
				}
				catch
				{
				}
			}
			if (assembly == null)
			{
				assemblyName.Version = new Version(5, 0, 400, 500);
				try
				{
					assembly = Assembly.Load(assemblyName);
				}
				catch
				{
				}
			}
			if (assembly == null)
			{
				assemblyName.Version = new Version(4, 0, 300, 500);
				try
				{
					assembly = Assembly.Load(assemblyName);
				}
				catch
				{
				}
			}
			if (assembly == null)
			{
				assemblyName.Version = new Version(3, 0, 200, 500);
				try
				{
					assembly = Assembly.Load(assemblyName);
				}
				catch
				{
				}
			}
			if (assembly == null)
			{
				assemblyName.Version = new Version(2, 0, 100, 500);
				try
				{
					assembly = Assembly.Load(assemblyName);
				}
				catch
				{
				}
			}
			if (assembly == null)
			{
				return null;
			}
			type = (bool_1 ? assembly.GetType("TXTextControl.WPF.Proofing.TXSpellChecker") : assembly.GetType("TXTextControl.Proofing.TXSpellChecker"));
			try
			{
				return Activator.CreateInstance(type);
			}
			catch
			{
				return null;
			}
		}

		internal void method_2(string string_0)
		{
			this.methodInfo_0.Invoke(this.object_0, new object[1] { string_0 });
		}

		internal void method_3(string string_0, CultureInfo cultureInfo_0)
		{
			if (cultureInfo_0 != null && !(this.methodInfo_1 == null))
			{
				this.methodInfo_1.Invoke(this.object_0, new object[2] { string_0, cultureInfo_0 });
			}
			else
			{
				this.method_2(string_0);
			}
		}

		internal void method_4()
		{
			this.methodInfo_2.Invoke(this.object_0, new object[0]);
		}

		internal void method_5(string string_0)
		{
			this.methodInfo_3.Invoke(this.object_0, new object[1] { string_0 });
		}

		internal void method_6(string string_0, int int_1)
		{
			this.methodInfo_4.Invoke(this.object_0, new object[2] { string_0, int_1 });
		}

		internal void method_7(string string_0, CultureInfo cultureInfo_0)
		{
			this.methodInfo_5.Invoke(this.object_0, new object[2] { string_0, cultureInfo_0 });
		}

		internal void method_8(string string_0, int int_1, CultureInfo cultureInfo_0)
		{
			this.methodInfo_6.Invoke(this.object_0, new object[3] { string_0, int_1, cultureInfo_0 });
		}

		internal object[] method_9(string string_0)
		{
			return this.methodInfo_7.Invoke(this.object_0, new object[1] { string_0 }) as object[];
		}

		internal object[] method_10(string string_0, CultureInfo cultureInfo_0)
		{
			return this.methodInfo_8.Invoke(this.object_0, new object[2] { string_0, cultureInfo_0 }) as object[];
		}

		internal object[] method_11(string string_0, object object_1)
		{
			return this.methodInfo_9.Invoke(this.object_0, new object[2] { string_0, object_1 }) as object[];
		}

		internal void method_12(string string_0)
		{
			if (this.methodInfo_14 != null)
			{
				this.methodInfo_14.Invoke(this.object_0, new object[1] { string_0 });
			}
		}

		internal void method_13(object object_1, string string_0)
		{
			object obj = null;
			if (string_0.EndsWith(".dic"))
			{
				obj = Activator.CreateInstance(this.type_3, string_0);
			}
			else if (string_0.EndsWith(".txd"))
			{
				obj = Activator.CreateInstance(this.type_1, string_0);
			}
			if (obj != null)
			{
				this.methodInfo_10.Invoke(object_1, new object[1] { obj });
			}
		}

		internal void method_14(object object_1, string string_0)
		{
			object obj = null;
			if (string_0.EndsWith(".dat"))
			{
				obj = Activator.CreateInstance(this.type_10, string_0);
			}
			else if (string_0.EndsWith(".idx"))
			{
				obj = Activator.CreateInstance(this.type_10, string_0);
			}
			if (obj != null)
			{
				this.methodInfo_15.Invoke(object_1, new object[1] { obj });
			}
		}

		internal int method_15(string string_0, int int_1, CultureInfo cultureInfo_0)
		{
			int result = 0;
			if (this.int_0 >= 4)
			{
				Type[] types = ((cultureInfo_0 == null) ? new Type[2]
				{
					typeof(string),
					typeof(int)
				} : new Type[3]
				{
					typeof(string),
					typeof(int),
					typeof(CultureInfo)
				});
				object[] parameters = ((cultureInfo_0 == null) ? new object[2] { string_0, int_1 } : new object[3] { string_0, int_1, cultureInfo_0 });
				result = (int)this.type_0.GetMethod("GetHyphenationPoint", types).Invoke(this.object_0, parameters);
			}
			return result;
		}

		internal bool method_16(object object_1, string string_0)
		{
			return (bool)this.methodInfo_11.Invoke(object_1, new object[1] { string_0 });
		}

		internal bool method_17(object object_1)
		{
			return (bool)this.propertyInfo_3.GetValue(object_1, null);
		}

		internal bool method_18(object object_1)
		{
			return (bool)this.propertyInfo_4.GetValue(object_1, null);
		}

		internal void method_19(object object_1, bool bool_1)
		{
			this.propertyInfo_4.SetValue(object_1, bool_1, null);
		}

		internal void method_20(object object_1, bool bool_1)
		{
			if (this.fieldInfo_0 != null)
			{
				this.fieldInfo_0.SetValue(object_1, bool_1);
			}
		}

		internal void method_21(object object_1, bool bool_1)
		{
			this.propertyInfo_5.SetValue(object_1, bool_1, null);
		}

		internal bool method_22(object object_1)
		{
			return (bool)this.propertyInfo_5.GetValue(object_1, null);
		}

		internal bool method_23(object object_1)
		{
			return (bool)this.propertyInfo_6.GetValue(object_1, null);
		}

		internal int method_24(object object_1)
		{
			return (int)this.propertyInfo_7.GetValue(object_1, null);
		}

		internal int method_25(object object_1)
		{
			return (int)this.propertyInfo_8.GetValue(object_1, null);
		}

		internal bool method_26(object object_1)
		{
			return (bool)this.propertyInfo_9.GetValue(object_1, null);
		}

		internal int method_27(object object_1)
		{
			return (int)this.propertyInfo_18.GetValue(object_1, null);
		}

		internal int method_28(object object_1)
		{
			return (int)this.propertyInfo_19.GetValue(object_1, null);
		}

		internal CultureInfo method_29(object object_1)
		{
			return (CultureInfo)this.propertyInfo_20.GetValue(object_1, null);
		}

		internal int method_30(CollectionBase collectionBase_0)
		{
			int num = 0;
			foreach (object item in collectionBase_0)
			{
				if (this.method_18(item))
				{
					num++;
				}
			}
			return num;
		}

		internal bool method_31(CollectionBase collectionBase_0, object object_1)
		{
			foreach (object item in collectionBase_0)
			{
				if (item == object_1)
				{
					return true;
				}
			}
			return false;
		}

		internal void method_32()
		{
			this.methodInfo_12.Invoke(this.object_0, new object[0]);
		}

		internal void method_33(int[] int_1)
		{
			this.methodInfo_13.Invoke(this.object_0, new object[1] { int_1 });
		}

		internal bool method_34(object object_1)
		{
			Type type = object_1.GetType();
			if (!(type == this.type_3))
			{
				return type == this.type_1;
			}
			return true;
		}

		internal bool method_35(object object_1)
		{
			return object_1.GetType() == this.type_1;
		}

		internal object method_36()
		{
			CollectionBase collectionBase = (CollectionBase)this.propertyInfo_0.GetValue(this.object_0, null);
			foreach (object item in collectionBase)
			{
				if ((bool)this.propertyInfo_6.GetValue(item, null))
				{
					return item;
				}
			}
			return null;
		}

		internal int method_37()
		{
			int num = 0;
			CollectionBase collectionBase = (CollectionBase)this.propertyInfo_0.GetValue(this.object_0, null);
			foreach (object item in collectionBase)
			{
				if ((bool)this.propertyInfo_5.GetValue(item, null))
				{
					num++;
				}
			}
			return num;
		}

		internal int method_38()
		{
			return this.int_0;
		}

		internal CultureInfo method_39(object object_1)
		{
			return (CultureInfo)this.propertyInfo_11.GetValue(object_1, null);
		}

		internal CultureInfo method_40(object object_1)
		{
			return (CultureInfo)this.propertyInfo_15.GetValue(object_1, null);
		}

		internal string[] method_41()
		{
			return (string[])this.propertyInfo_12.GetValue(this.object_0, null);
		}

		internal string[] method_42()
		{
			return (string[])this.propertyInfo_13.GetValue(this.object_0, null);
		}

		internal CultureInfo[] method_43()
		{
			string[] array = this.method_42();
			List<CultureInfo> list = new List<CultureInfo>();
			foreach (object item2 in this.CollectionBase_5)
			{
				CultureInfo cultureInfo = this.method_40(item2);
				if (cultureInfo != null && !list.Contains(cultureInfo))
				{
					list.Add(cultureInfo);
				}
			}
			string[] array2 = array;
			foreach (string text in array2)
			{
				string text2 = text.Substring(5, text.LastIndexOf('.') - 5);
				if (text2.Length < 2 || (text2.Length != 2 && text2[2] != '_' && text2[2] != '-'))
				{
					continue;
				}
				string text3 = text2.Substring(0, 2).ToLower();
				string text4 = "";
				if (text2.Length >= 5 && ((text2.Length > 5 && (text2[5] == '_' || text2[5] == ' ' || text2[5] == '(' || text2[5] == '-')) || text2.Length == 5))
				{
					text4 = "-" + text2.Substring(3, 2).ToUpper();
				}
				try
				{
					CultureInfo item = new CultureInfo(text3 + text4);
					if (!list.Contains(item))
					{
						list.Add(item);
					}
				}
				catch
				{
				}
			}
			list.Sort(new Class416());
			return list.ToArray();
		}

		internal CultureInfo[] method_44()
		{
			string[] array = this.method_41();
			List<CultureInfo> list = new List<CultureInfo>();
			foreach (object item2 in this.CollectionBase_0)
			{
				CultureInfo cultureInfo = this.method_39(item2);
				if (cultureInfo != null && !list.Contains(cultureInfo))
				{
					list.Add(cultureInfo);
				}
			}
			string[] array2 = array;
			foreach (string text in array2)
			{
				string text2 = text.Substring(0, text.LastIndexOf('.'));
				if (text2.Length < 2 || (text2.Length != 2 && text2[2] != '_' && text2[2] != '-'))
				{
					continue;
				}
				string text3 = text2.Substring(0, 2).ToLower();
				string text4 = "";
				if (text2.Length >= 5 && ((text2.Length > 5 && (text2[5] == '_' || text2[5] == ' ' || text2[5] == '(' || text2[5] == '-')) || text2.Length == 5))
				{
					text4 = "-" + text2.Substring(3, 2).ToUpper();
				}
				try
				{
					CultureInfo item = new CultureInfo(text3 + text4);
					if (!list.Contains(item))
					{
						list.Add(item);
					}
				}
				catch
				{
				}
			}
			list.Sort(new Class416());
			return list.ToArray();
		}

		internal IntPtr method_45(CultureInfo[] cultureInfo_0)
		{
			IntPtr intPtr = IntPtr.Zero;
			try
			{
				intPtr = Marshal.AllocHGlobal((cultureInfo_0.Length + 1) * 4);
				int i;
				for (i = 0; i < cultureInfo_0.Length; i++)
				{
					Marshal.WriteInt32(intPtr, i * 4, cultureInfo_0[i].LCID);
				}
				Marshal.WriteInt32(intPtr, i * 4, 0);
				return intPtr;
			}
			catch
			{
				Marshal.FreeHGlobal(intPtr);
				return IntPtr.Zero;
			}
		}

		internal List<object> method_46(CollectionBase collectionBase_0, CultureInfo cultureInfo_0)
		{
			List<object> list = new List<object>();
			List<object> list2 = new List<object>();
			if (cultureInfo_0 != null)
			{
				if (cultureInfo_0.IetfLanguageTag.Length == 0)
				{
					object obj = this.method_36();
					if (obj != null)
					{
						CultureInfo cultureInfo = this.method_39(obj);
						{
							foreach (object item in collectionBase_0)
							{
								CultureInfo cultureInfo2;
								if (item.GetType() == this.type_1 && (cultureInfo2 = this.method_39(item)) != null && this.method_17(item) && cultureInfo2.IetfLanguageTag == cultureInfo.IetfLanguageTag)
								{
									list.Add(item);
								}
							}
							return list;
						}
					}
				}
				else
				{
					foreach (object item2 in collectionBase_0)
					{
						CultureInfo cultureInfo3;
						if (item2.GetType() == this.type_1 && (cultureInfo3 = this.method_39(item2)) != null && this.method_17(item2))
						{
							if (cultureInfo3.IetfLanguageTag == cultureInfo_0.IetfLanguageTag)
							{
								list.Add(item2);
							}
							else if (list.Count == 0 && cultureInfo3.IetfLanguageTag.Substring(0, 2) == cultureInfo_0.IetfLanguageTag.Substring(0, 2))
							{
								list2.Add(item2);
							}
						}
					}
					if (list.Count == 0)
					{
						return list2;
					}
				}
				return list;
			}
			foreach (object item3 in collectionBase_0)
			{
				if (item3.GetType() == this.type_1 && this.method_39(item3) == null && this.method_17(item3))
				{
					list.Add(item3);
				}
			}
			return list;
		}

		internal CultureInfo method_47(object object_1)
		{
			return this.propertyInfo_22.GetValue(object_1, null) as CultureInfo;
		}

		internal string method_48(object object_1)
		{
			return this.propertyInfo_23.GetValue(object_1, null) as string;
		}

		internal object[] method_49(object object_1)
		{
			return this.propertyInfo_24.GetValue(object_1, null) as object[];
		}

		internal string method_50(object object_1)
		{
			return this.propertyInfo_25.GetValue(object_1, null) as string;
		}

		internal string method_51(object object_1)
		{
			return this.propertyInfo_26.GetValue(object_1, null) as string;
		}

		internal bool method_52(object object_1)
		{
			return (bool)this.propertyInfo_27.GetValue(object_1, null);
		}

		internal bool method_53(object object_1)
		{
			return (bool)this.propertyInfo_28.GetValue(object_1, null);
		}

		internal CultureInfo method_54(object object_1)
		{
			return this.propertyInfo_29.GetValue(object_1, null) as CultureInfo;
		}

		internal string method_55(object object_1)
		{
			return this.propertyInfo_30.GetValue(object_1, null) as string;
		}
	}
}
