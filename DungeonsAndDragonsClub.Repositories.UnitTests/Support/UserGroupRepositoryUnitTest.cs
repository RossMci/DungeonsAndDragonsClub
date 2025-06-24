namespace DungeonsAndDragonsClub.Repositories.UnitTests
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	public abstract class UserGroupRepositoryUnitTest
	{
		/// <summary>
		/// System Under Test (SUT)
		/// </summary>
		protected UserGroupRepository sut;
		#region Tests
		#endregion
		[TestMethod]
		public void TestGetUserGroupById()
		{
			int usergroupId = 1;
			var usergroup = sut.GetUserGroupById(usergroupId);
			Assert.AreEqual(expected: usergroupId, actual: usergroup.Id);
		}
		[TestMethod]
		public void TestGetUserGroupByNonexistingId()
		{
			int usergroupId = 2666;
			var usergroup = sut.GetUserGroupById(usergroupId);
			Assert.IsNull(usergroup);
		}
		[TestMethod]
		public void TestGetUserGroups()
		{
			var userAccounts = sut.GetUserGroups();
			Assert.IsNotNull(userAccounts);
		}
		[TestMethod]
		public void TestInsertAndDelete()
		{
			String timeStamp = DateTime.Now.ToString("yyyyMMddhhmmss");
			var usergroup = new UserGroupDTOComponent
			{
				Name = "New User",
			};

			sut.InsertUserGroup(usergroup);
			var usergroupId = usergroup.Id;
			var insertedUserGroup = sut.GetUserGroupById(usergroupId);

			sut.DeleteUserGroup(usergroup);
			var deletedUserAccount = sut.GetUserGroupById(usergroupId);

			Assert.AreEqual(expected: usergroup.Id, actual: insertedUserGroup.Id);
			Assert.AreEqual(expected: usergroup.Name, actual: insertedUserGroup.Name);

			Assert.IsNull(deletedUserAccount);
		}
		[TestMethod]
		public void TestUpdateUserAccount()
		{
			var usergroupId = 3;
			var usergroup = sut.GetUserGroupById(usergroupId);

			String timeStamp = DateTime.Now.ToString("yyyyMMddhhmmss");
			usergroup.Name = $"UserGroup{timeStamp}";

			sut.UpdateUserGroup(usergroup);

			var updatedUserGroup = sut.GetUserGroupById(usergroup.Id);

			Assert.AreEqual(expected: usergroup.Id, actual: updatedUserGroup.Id);
			Assert.AreEqual(expected: usergroup.Name, actual: updatedUserGroup.Name);
		}
	}
}