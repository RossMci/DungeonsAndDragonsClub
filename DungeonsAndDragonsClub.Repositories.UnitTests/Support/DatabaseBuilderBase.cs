namespace DungeonsAndDragonsClub.Repositories.UnitTests
{
	using Microsoft.Extensions.Configuration;
	using System;
	public abstract class DatabaseBuilderBase
	{
		protected DatabaseBuilderBase(String connectionStringKey)
		{
			this.Configuration = this.BuildConfiguration();
			this.ConnectionStringKey = connectionStringKey;
		}
		#region Private Properties
		#endregion
		private IConfiguration Configuration { get; }
		private String ConnectionStringKey { get; }
		#region Protected Methods
		#endregion
		protected String GetConnectionString()
		{
			return Configuration[ConnectionStringKey];
		}
		#region Private Methods
		#endregion
		private IConfigurationRoot BuildConfiguration()
		{
			IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
			configurationBuilder = configurationBuilder.AddUserSecrets<UserAccountRepositoryUnitTest>();
			return configurationBuilder.Build();
		}
	}
}