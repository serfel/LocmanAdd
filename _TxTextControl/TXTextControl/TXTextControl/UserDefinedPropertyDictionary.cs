using System;
using System.Collections;
using System.Globalization;
using System.Resources;
using System.Runtime.InteropServices;

namespace TXTextControl
{
	/// <summary>An instance of the UserDefinedPropertyDictionary class contains all user-defined document properties contained in a loaded document or which will be saved in a document.</summary>
	public class UserDefinedPropertyDictionary : DictionaryBase
	{
		private ResourceManager resourceManager_0 = new ResourceManager(typeof(TextControlCore));

		public object this[string name]
		{
			get
			{
				return base.Dictionary[name];
			}
			set
			{
				base.Dictionary[name] = value;
			}
		}

		/// <summary>Gets a collection of all property names the dictionary contains.</summary>
		public ICollection Names => base.Dictionary.Keys;

		/// <summary>Gets a collection of all property values the dictionary contains.</summary>
		public ICollection Values => base.Dictionary.Values;

		/// <summary>Initializes a new instance of the UserDefinedPropertyDictionary class.</summary>
		public UserDefinedPropertyDictionary()
		{
		}

		internal UserDefinedPropertyDictionary(IntPtr hBuffer)
		{
			string[] array = KernelHelper.Ptr2StringArray(hBuffer);
			string[] array2 = array;
			foreach (string text in array2)
			{
				string[] array3 = text.Split('\u0001');
				if (array3.Length == 4)
				{
					switch (array3[1])
					{
					case "Boolean":
						this.Add(array3[0], bool.Parse(array3[3]));
						break;
					case "Double":
						this.Add(array3[0], double.Parse(array3[3], CultureInfo.InvariantCulture));
						break;
					case "Int32":
						this.Add(array3[0], int.Parse(array3[3]));
						break;
					case "String":
						this.Add(array3[0], array3[3]);
						break;
					}
				}
			}
		}

		/// <summary>Adds a new property to the dictionary.</summary>
		/// <param name="name">Specifies the document property's name.</param>
		/// <param name="value">Specifies the document property's value.</param>
		public void Add(string name, object value)
		{
			base.Dictionary.Add(name, value);
		}

		/// <summary>Determines whether the dictionary contains a property with the specified name.</summary>
		/// <param name="name">Specifies a document property's name.</param>
		public bool Contains(string name)
		{
			return base.Dictionary.Contains(name);
		}

		/// <summary>Removes a document property from the dictionary.</summary>
		/// <param name="name">Specifies the name of the document property to remove.</param>
		public void Remove(string name)
		{
			base.Dictionary.Remove(name);
		}

		protected override void OnInsert(object name, object value)
		{
			this.method_0(name, value);
		}

		protected override void OnRemove(object name, object value)
		{
			this.method_0(name, value);
		}

		protected override void OnSet(object name, object oldValue, object newValue)
		{
			this.method_0(name, newValue);
		}

		protected override void OnValidate(object name, object value)
		{
			this.method_0(name, value);
		}

		private void method_0(object object_0, object object_1)
		{
			if (object_0.GetType() != typeof(string))
			{
				throw new ArgumentException(this.resourceManager_0.GetString("ERR_DOCPROPERTIES_1"), "name");
			}
			string text = (string)object_0;
			if (text.Length > 255)
			{
				throw new ArgumentException(this.resourceManager_0.GetString("ERR_DOCPROPERTIES_2"), "name");
			}
			if (object_1.GetType() != typeof(string) && object_1.GetType() != typeof(bool) && object_1.GetType() != typeof(double) && object_1.GetType() != typeof(int))
			{
				throw new ArgumentException(this.resourceManager_0.GetString("ERR_DOCPROPERTIES_3"), "value");
			}
		}

		internal IntPtr method_1()
		{
			IntPtr zero = IntPtr.Zero;
			int num = 0;
			string[] array = new string[base.Count];
			foreach (DictionaryEntry item in this)
			{
				string text = string.Empty;
				switch (item.Value.GetType().Name)
				{
				case "Boolean":
					text = item.Value.ToString();
					break;
				case "Double":
					text = ((double)item.Value).ToString(CultureInfo.InvariantCulture);
					break;
				case "Int32":
					text = item.Value.ToString();
					break;
				case "String":
					text = (string)item.Value;
					break;
				}
				string[] value = new string[4]
				{
					(string)item.Key,
					item.Value.GetType().Name,
					string.Empty,
					text
				};
				array[num++] = string.Join("\u0001", value);
			}
			char[] array2 = KernelHelper.StringArray2CharArray(array);
			zero = Marshal.AllocHGlobal(array2.Length * 2);
			Marshal.Copy(array2, 0, zero, array2.Length);
			return zero;
		}
	}
}
