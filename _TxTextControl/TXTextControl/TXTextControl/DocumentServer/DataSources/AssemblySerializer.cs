using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using DocumentServer.Json;

namespace DocumentServer.DataSources
{
	internal static class AssemblySerializer
	{
		private const string RelColPrefix = "TXID_";

		private static string AssemblyFileName;

		private static Stack<Type> m_typeChain;

		static AssemblySerializer()
		{
			AssemblySerializer.AssemblyFileName = "";
			AssemblySerializer.m_typeChain = new Stack<Type>();
			AppDomain.CurrentDomain.ReflectionOnlyAssemblyResolve += CurrentDomain_ReflectionOnlyAssemblyResolve;
		}

		public static DataTableInfo[] Serialize(string assemblyPath)
		{
			DataTableInfoCollection dataTableInfoCollection = new DataTableInfoCollection();
			AssemblySerializer.AssemblyFileName = assemblyPath;
			Assembly assembly = Assembly.ReflectionOnlyLoadFrom(assemblyPath);
			_ = assembly.FullName.Split(',')[0];
			Type[] exportedTypes = assembly.GetExportedTypes();
			foreach (Type type in exportedTypes)
			{
				AssemblySerializer.AddType(dataTableInfoCollection, type, type.Name);
			}
			return dataTableInfoCollection.method_2();
		}

		private static void AddType(DataTableInfoCollection tables, Type type, string tableName)
		{
			if (AssemblySerializer.m_typeChain.Contains(type) || AssemblySerializer.IsInIgnoredNamespace(type) || type.GetInterface("IDictionary") != null)
			{
				return;
			}
			if (!type.IsSimpleType() && type.IsGenericEnumerableType())
			{
				AssemblySerializer.AddGenericEnumerableType(tables, type, tableName);
			}
			else if (!type.IsSimpleType() && !type.Name.ContainsSpecialCharacters())
			{
				DataTableInfo dataTableInfo = new DataTableInfo(tableName, type);
				PropertyInfo[] publicGettableProps = type.GetPublicGettableProps();
				AssemblySerializer.m_typeChain.Push(type);
				PropertyInfo[] array = publicGettableProps;
				foreach (PropertyInfo propertyInfo in array)
				{
					Type underlyingType = propertyInfo.PropertyType.GetUnderlyingType();
					Type dataType = (underlyingType.IsSimpleType() ? underlyingType : typeof(string));
					DataColumnInfo dataColumnInfo_ = new DataColumnInfo(propertyInfo.Name, dataType, dataTableInfo);
					dataTableInfo.Columns.method_0(dataColumnInfo_);
					AssemblySerializer.AddType(dataTableInfo.ChildTables, propertyInfo.PropertyType, propertyInfo.Name);
				}
				AssemblySerializer.m_typeChain.Pop();
				if (dataTableInfo.Columns.Count > 0)
				{
					tables.method_0(dataTableInfo);
				}
			}
		}

		private static void AddGenericEnumerableType(DataTableInfoCollection tables, Type type, string tableName)
		{
			Type type2 = ((!type.IsGenericType || !(type.GetGenericTypeDefinition() == typeof(IEnumerable<>))) ? type.GetInterfaces().FirstOrDefault((Type t) => t.IsGenericType && t.GetGenericTypeDefinition() == typeof(IEnumerable<>)) : type);
			if (!(type2 == null))
			{
				try
				{
					type = type2.GetGenericArguments()[0];
				}
				catch
				{
					return;
				}
				AssemblySerializer.AddType(tables, type, tableName);
			}
		}

		private static Assembly CurrentDomain_ReflectionOnlyAssemblyResolve(object sender, ResolveEventArgs args)
		{
			try
			{
				return Assembly.ReflectionOnlyLoad(args.Name);
			}
			catch (FileNotFoundException)
			{
				try
				{
					return Assembly.ReflectionOnlyLoadFrom(args.Name.Substring(0, args.Name.IndexOf(',')) + ".dll");
				}
				catch (FileNotFoundException)
				{
					return Assembly.ReflectionOnlyLoadFrom(Path.GetDirectoryName(AssemblySerializer.AssemblyFileName) + "/" + args.Name.Substring(0, args.Name.IndexOf(',')) + ".dll");
				}
			}
		}

		internal static bool IsInIgnoredNamespace(Type type)
		{
			if (type.Namespace != null)
			{
				return type.Namespace.StartsWith("System.Reflection");
			}
			return false;
		}
	}
}
