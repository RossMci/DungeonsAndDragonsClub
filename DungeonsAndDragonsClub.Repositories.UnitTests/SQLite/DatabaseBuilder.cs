namespace DungeonsAndDragonsClub.Repositories.UnitTests.SQLite
{
	using DungeonsAndDragonsClub.Repositories.SQLite;
	public class DatabaseBuilder : DatabaseBuilderBase
	{
		// Use Manager User Secrets and add: "SQLiteTestDatabaseConnectionString": "DataSource=DungeonsAndDragonsClub-v1.sqlite3"
		public DatabaseBuilder() : base(connectionStringKey: "SQLiteTestDatabaseConnectionString")
		{
		}
		public DungeonsAndDragonsClubDatabase Build()
		{
			return new DungeonsAndDragonsClubDatabase(GetConnectionString());
		}
	}
}