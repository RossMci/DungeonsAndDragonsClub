namespace DungeonsAndDragonsClub.Repositories.UnitTests.SQLite
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	[TestClass]
	public class UserAccountSQLiteRepositoryUnitTest : UserAccountRepositoryUnitTest
	{
		[TestInitialize]
		public void Initialize()
		{
			sut = new DatabaseBuilder().Build().UserAccountRepository;
		}
	}
}