using System;
using System.Globalization;
using System.Reflection;

namespace ns21
{
	internal class Class407
	{
		internal Type method_0(string string_0, string string_1, string string_2, out Assembly assembly_0)
		{
			Type type = null;
			AssemblyName assemblyName = new AssemblyName();
			assemblyName.Name = string_0;
			assemblyName.Version = new Version(string_1);
			assemblyName.CultureInfo = new CultureInfo("");
			byte[] publicKeyToken = new byte[8] //{ 23, 255, 248, 167, 116, 0, 76, 102 }; //
												{ 107, 131, 254, 154, 117, 207, 182, 56 }; //Должен быть оригинальным
			assemblyName.SetPublicKeyToken(publicKeyToken);
			assembly_0 = this.method_1(assemblyName);
			type = assembly_0.GetType(string_2);
			type.GetMethod("Initialize").Invoke(null, null);
			return type;
		}

		private Assembly method_1(AssemblyName assemblyName_0)
		{
			return Assembly.Load(assemblyName_0);
		}

		internal Assembly method_2(string string_0, string string_1)
		{
			AssemblyName assemblyName = new AssemblyName();
			assemblyName.Name = string_0;
			assemblyName.Version = new Version(string_1);
			assemblyName.CultureInfo = new CultureInfo("");
			byte[] publicKeyToken = new byte[8] //{ 23, 255, 248, 167, 116, 0, 76, 102 };
												{ 107, 131, 254, 154, 117, 207, 182, 56 };
			assemblyName.SetPublicKeyToken(publicKeyToken);
			return Assembly.Load(assemblyName);
		}
	}
}
