using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace ns16
{
	internal class Class156 : PropertyDescriptor
	{
		private string string_0;

		private string string_1;

		private string string_2;

		private Type type_0;

		private string string_3;

		private TypeConverter typeConverter_0;

		private List<Attribute> list_0;

		private Delegate1 delegate1_0;

		private Delegate2 delegate2_0;

		private Delegate3 delegate3_0;

		private Delegate4 delegate4_0;

		private Delegate5 delegate5_0;

		private Delegate6 delegate6_0;

		private Type type_1;

		private PropertyDescriptor propertyDescriptor_0;

		public override string Name
		{
			get
			{
				if (this.string_0 != null)
				{
					return this.string_0;
				}
				return base.Name;
			}
		}

		public override string Category
		{
			get
			{
				if (this.string_1 != null)
				{
					return this.string_1;
				}
				return base.Category;
			}
		}

		public override string Description
		{
			get
			{
				if (this.string_2 != null)
				{
					return this.string_2;
				}
				return base.Description;
			}
		}

		public override Type PropertyType
		{
			get
			{
				if (this.type_0 != null)
				{
					return this.type_0;
				}
				if (this.propertyDescriptor_0 != null)
				{
					return this.propertyDescriptor_0.PropertyType;
				}
				return null;
			}
		}

		public override bool IsReadOnly => ReadOnlyAttribute.Yes.Equals(this.Attributes[typeof(ReadOnlyAttribute)]);

		public override TypeConverter Converter
		{
			get
			{
				if (this.string_3 != null)
				{
					if (this.typeConverter_0 == null)
					{
						Type typeFromName = base.GetTypeFromName(this.string_3);
						if (typeof(TypeConverter).IsAssignableFrom(typeFromName))
						{
							this.typeConverter_0 = (TypeConverter)base.CreateInstance(typeFromName);
						}
					}
					if (this.typeConverter_0 != null)
					{
						return this.typeConverter_0;
					}
				}
				return base.Converter;
			}
		}

		public override AttributeCollection Attributes
		{
			get
			{
				if (this.list_0 != null)
				{
					Dictionary<object, Attribute> dictionary = new Dictionary<object, Attribute>();
					Attribute[] attributeArray = this.AttributeArray;
					foreach (Attribute attribute in attributeArray)
					{
						dictionary[attribute.TypeId] = attribute;
					}
					foreach (Attribute item in this.list_0)
					{
						if (!item.IsDefaultAttribute())
						{
							dictionary[item.TypeId] = item;
						}
						else if (dictionary.ContainsKey(item.TypeId))
						{
							dictionary.Remove(item.TypeId);
						}
						CategoryAttribute categoryAttribute = item as CategoryAttribute;
						if (categoryAttribute != null)
						{
							this.string_1 = categoryAttribute.Category;
						}
						DescriptionAttribute descriptionAttribute = item as DescriptionAttribute;
						if (descriptionAttribute != null)
						{
							this.string_2 = descriptionAttribute.Description;
						}
						TypeConverterAttribute typeConverterAttribute = item as TypeConverterAttribute;
						if (typeConverterAttribute != null)
						{
							this.string_3 = typeConverterAttribute.ConverterTypeName;
							this.typeConverter_0 = null;
						}
					}
					Attribute[] array = new Attribute[dictionary.Values.Count];
					dictionary.Values.CopyTo(array, 0);
					this.AttributeArray = array;
					this.list_0 = null;
				}
				return base.Attributes;
			}
		}

		public Delegate1 Delegate1_0
		{
			get
			{
				return this.delegate1_0;
			}
			set
			{
				this.delegate1_0 = value;
			}
		}

		public Delegate2 Delegate2_0
		{
			get
			{
				return this.delegate2_0;
			}
			set
			{
				this.delegate2_0 = value;
			}
		}

		public Delegate3 Delegate3_0
		{
			get
			{
				return this.delegate3_0;
			}
			set
			{
				this.delegate3_0 = value;
			}
		}

		public Delegate4 Delegate4_0
		{
			get
			{
				return this.delegate4_0;
			}
			set
			{
				this.delegate4_0 = value;
			}
		}

		public Delegate5 Delegate5_0
		{
			get
			{
				return this.delegate5_0;
			}
			set
			{
				this.delegate5_0 = value;
			}
		}

		public Delegate6 Delegate6_0
		{
			get
			{
				return this.delegate6_0;
			}
			set
			{
				this.delegate6_0 = value;
			}
		}

		public override Type ComponentType
		{
			get
			{
				if (this.type_1 != null)
				{
					return this.type_1;
				}
				if (this.propertyDescriptor_0 != null)
				{
					return this.propertyDescriptor_0.ComponentType;
				}
				return null;
			}
		}

		protected override int NameHashCode
		{
			get
			{
				if (this.string_0 != null)
				{
					return this.string_0.GetHashCode();
				}
				return base.NameHashCode;
			}
		}

		public Class156(string string_4)
			: base(string_4, null)
		{
		}

		public Class156(string string_4, params Attribute[] attribute_0)
			: base(string_4, Class156.smethod_0(attribute_0))
		{
		}

		public Class156(PropertyDescriptor propertyDescriptor_1)
			: this(propertyDescriptor_1, (Attribute[])null)
		{
		}

		public Class156(PropertyDescriptor propertyDescriptor_1, params Attribute[] attribute_0)
			: base(propertyDescriptor_1, attribute_0)
		{
			this.AttributeArray = Class156.smethod_0(this.AttributeArray);
			this.propertyDescriptor_0 = propertyDescriptor_1;
		}

		public void method_0(string string_4)
		{
			if (string_4 == null)
			{
				string_4 = string.Empty;
			}
			this.string_0 = string_4;
		}

		public void method_1(string string_4)
		{
			if (string_4 == null)
			{
				string_4 = DisplayNameAttribute.Default.DisplayName;
			}
			this.method_10(new DisplayNameAttribute(string_4));
		}

		public void method_2(string string_4)
		{
			if (string_4 == null)
			{
				string_4 = CategoryAttribute.Default.Category;
			}
			this.string_1 = string_4;
			this.method_10(new CategoryAttribute(string_4));
		}

		public void method_3(string string_4)
		{
			if (string_4 == null)
			{
				string_4 = DescriptionAttribute.Default.Description;
			}
			this.string_2 = string_4;
			this.method_10(new DescriptionAttribute(string_4));
		}

		public void method_4(Type type_2)
		{
			if (type_2 == null)
			{
				throw new ArgumentNullException("value");
			}
			this.type_0 = type_2;
		}

		public void method_5(bool bool_0)
		{
			this.method_10(new DesignOnlyAttribute(bool_0));
		}

		public void method_6(bool bool_0)
		{
			this.method_10(new BrowsableAttribute(bool_0));
		}

		public void method_7(bool bool_0)
		{
			this.method_10(new LocalizableAttribute(bool_0));
		}

		public void method_8(bool bool_0)
		{
			this.method_10(new ReadOnlyAttribute(bool_0));
		}

		public void method_9(Type type_2)
		{
			this.string_3 = ((type_2 != null) ? type_2.AssemblyQualifiedName : null);
			if (this.string_3 != null)
			{
				this.method_10(new TypeConverterAttribute(type_2));
			}
			else
			{
				this.method_10(TypeConverterAttribute.Default);
			}
			this.typeConverter_0 = null;
		}

		public void method_10(Attribute attribute_0)
		{
			if (attribute_0 == null)
			{
				throw new ArgumentNullException("value");
			}
			if (this.list_0 == null)
			{
				this.list_0 = new List<Attribute>();
			}
			this.list_0.Add(attribute_0);
		}

		public void method_11(params Attribute[] attribute_0)
		{
			foreach (Attribute attribute_ in attribute_0)
			{
				this.method_10(attribute_);
			}
		}

		public void method_12(Type type_2)
		{
			this.type_1 = type_2;
		}

		public override object GetValue(object component)
		{
			if (this.Delegate1_0 != null)
			{
				return this.Delegate1_0(component);
			}
			if (this.propertyDescriptor_0 != null)
			{
				return this.propertyDescriptor_0.GetValue(component);
			}
			return null;
		}

		public override void SetValue(object component, object value)
		{
			if (this.Delegate2_0 != null)
			{
				this.Delegate2_0(component, value);
				this.OnValueChanged(component, EventArgs.Empty);
			}
			else if (this.propertyDescriptor_0 != null)
			{
				this.propertyDescriptor_0.SetValue(component, value);
				this.OnValueChanged(component, EventArgs.Empty);
			}
		}

		public override bool CanResetValue(object component)
		{
			if (this.Delegate3_0 != null)
			{
				return this.Delegate3_0(component);
			}
			if (this.propertyDescriptor_0 != null)
			{
				return this.propertyDescriptor_0.CanResetValue(component);
			}
			return this.Attributes[typeof(DefaultValueAttribute)] != null;
		}

		public override void ResetValue(object component)
		{
			if (this.Delegate4_0 != null)
			{
				this.Delegate4_0(component);
				return;
			}
			if (this.propertyDescriptor_0 != null)
			{
				this.propertyDescriptor_0.ResetValue(component);
				return;
			}
			DefaultValueAttribute defaultValueAttribute = this.Attributes[typeof(DefaultValueAttribute)] as DefaultValueAttribute;
			if (defaultValueAttribute != null)
			{
				this.SetValue(component, defaultValueAttribute.Value);
			}
		}

		public override bool ShouldSerializeValue(object component)
		{
			if (this.Delegate5_0 != null)
			{
				return this.Delegate5_0(component);
			}
			if (this.propertyDescriptor_0 != null)
			{
				return this.propertyDescriptor_0.ShouldSerializeValue(component);
			}
			DefaultValueAttribute defaultValueAttribute = this.Attributes[typeof(DefaultValueAttribute)] as DefaultValueAttribute;
			if (defaultValueAttribute != null)
			{
				return !object.Equals(this.GetValue(component), defaultValueAttribute.Value);
			}
			return false;
		}

		public override PropertyDescriptorCollection GetChildProperties(object instance, Attribute[] filter)
		{
			if (this.Delegate6_0 != null)
			{
				return this.Delegate6_0(instance, filter);
			}
			if (this.propertyDescriptor_0 != null)
			{
				return this.propertyDescriptor_0.GetChildProperties(instance, filter);
			}
			return base.GetChildProperties(instance, filter);
		}

		private static Attribute[] smethod_0(Attribute[] attribute_0)
		{
			Dictionary<object, Attribute> dictionary = new Dictionary<object, Attribute>();
			foreach (Attribute attribute in attribute_0)
			{
				if (!attribute.IsDefaultAttribute())
				{
					dictionary.Add(attribute.TypeId, attribute);
				}
			}
			Attribute[] array = new Attribute[dictionary.Values.Count];
			dictionary.Values.CopyTo(array, 0);
			return array;
		}
	}
}
