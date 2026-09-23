using System;

namespace DocumentServer.Data.ConnectionUI
{
	internal interface IDataConnectionProperties
	{
		bool IsComplete { get; }

		bool IsExtensible { get; }

		object this[string propertyName] { get; set; }

		event EventHandler PropertyChanged;

		void Add(string propertyName);

		bool Contains(string propertyName);

		void Parse(string string_0);

		void Remove(string propertyName);

		void Reset();

		void Reset(string propertyName);

		void Test();

		string ToDisplayString();

		string ToFullString();
	}
}
