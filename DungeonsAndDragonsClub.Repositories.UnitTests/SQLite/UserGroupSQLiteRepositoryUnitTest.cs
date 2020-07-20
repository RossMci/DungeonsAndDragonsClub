namespace DungeonsAndDragonsClub.Repositories.UnitTests.SQLite
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	[TestClass]
	public class UserGroupSQLiteRepositoryUnitTest : UserGroupRepositoryUnitTest
	{
		[TestInitialize]
		public void Initialize()
		{
			sut = new DatabaseBuilder().Build().UserGroupRepository;
		}
	}
}