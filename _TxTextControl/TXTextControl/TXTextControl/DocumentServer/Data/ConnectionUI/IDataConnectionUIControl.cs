namespace DocumentServer.Data.ConnectionUI
{
	internal interface IDataConnectionUIControl
	{
		void Initialize(IDataConnectionProperties connectionProperties);

		void LoadProperties();
	}
}
