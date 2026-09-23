using System.Reflection;
using System.Runtime.CompilerServices;

namespace ns8
{
	internal class Class106
	{
		private PropertyInfo propertyInfo_0;

		private PropertyInfo propertyInfo_1;

		private PropertyInfo propertyInfo_2;

		private PropertyInfo propertyInfo_3;

		private PropertyInfo propertyInfo_4;

		private PropertyInfo propertyInfo_5;

		public const int int_0 = 2;

		[CompilerGenerated]
		private object object_0;

		public object Object_0
		{
			[CompilerGenerated]
			get
			{
				return this.object_0;
			}
			[CompilerGenerated]
			private set
			{
				this.object_0 = value;
			}
		}

		public bool Boolean_0
		{
			get
			{
				return (bool)this.propertyInfo_0.GetValue(this.Object_0, null);
			}
			set
			{
				this.propertyInfo_0.SetValue(this.Object_0, value, null);
			}
		}

		public bool Boolean_1
		{
			get
			{
				return (bool)this.propertyInfo_1.GetValue(this.Object_0, null);
			}
			set
			{
				this.propertyInfo_1.SetValue(this.Object_0, value, null);
			}
		}

		public int Int32_0
		{
			get
			{
				return (int)this.propertyInfo_2.GetValue(this.Object_0, null);
			}
			set
			{
				this.propertyInfo_2.SetValue(this.Object_0, value, null);
			}
		}

		public int Int32_1
		{
			get
			{
				return (int)this.propertyInfo_3.GetValue(this.Object_0, null);
			}
			set
			{
				this.propertyInfo_3.SetValue(this.Object_0, value, null);
			}
		}

		public int Int32_2
		{
			get
			{
				return (int)this.propertyInfo_4.GetValue(this.Object_0, null);
			}
			set
			{
				this.propertyInfo_4.SetValue(this.Object_0, value, null);
			}
		}

		public bool Boolean_2
		{
			get
			{
				return (bool)this.propertyInfo_5.GetValue(this.Object_0, null);
			}
			set
			{
				this.propertyInfo_5.SetValue(this.Object_0, value, null);
			}
		}

		public Class106(object object_1)
		{
			this.Object_0 = object_1;
			this.propertyInfo_0 = this.Object_0.GetType().GetProperty("Enable3D");
			this.propertyInfo_1 = this.Object_0.GetType().GetProperty("IsClustered");
			this.propertyInfo_2 = this.Object_0.GetType().GetProperty("Perspective");
			this.propertyInfo_3 = this.Object_0.GetType().GetProperty("Inclination");
			this.propertyInfo_4 = this.Object_0.GetType().GetProperty("Rotation");
			this.propertyInfo_5 = this.Object_0.GetType().GetProperty("IsRightAngleAxes");
		}
	}
}
