namespace DungeonsAndDragonsClub.Repositories.SQLite
{
	using System;
	public partial class DungeonsAndDragonsClubDatabase : DungeonsAndDragonsClubSystem, DatabaseAgent
	{
		public DungeonsAndDragonsClubDatabase(String connectionString)
		{
			this.ConnectionString = connectionString;
			var sqlStatements = new DungeonsAndDragonsClubSqlStatements();
			//
			//	repositories
			//
			this.UserAccountRepository = new UserAccountRepositoryComponent(this, sqlStatements);
			this.UserGroupRepository = new UserGroupRepositoryComponent(this, sqlStatements);
		}
		#region Public Properties
		#endregion
		public UserAccountRepository UserAccountRepository { get; }
		public UserGroupRepository UserGroupRepository { get; }
		public String ConnectionString { get; }
	}
}