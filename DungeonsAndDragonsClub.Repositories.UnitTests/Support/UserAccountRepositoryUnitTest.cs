namespace DungeonsAndDragonsClub.Repositories.UnitTests
{
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using System;
	public abstract class UserAccountRepositoryUnitTest
	{
		/// <summary>
		/// System Under Test (SUT)
		/// </summary>
		protected UserAccountRepository sut;
		#region Tests
		#endregion
		[TestMethod]
		public void TestGetUserAccountByCredentials1()
		{
			String username = "Admin", password = "letmein";
			var userAccount = sut.GetUserAccountByCredentials(username, password);
			Assert.AreEqual(expected: username, actual: userAccount.Username);
		}
		[TestMethod]
		public void TestGetUserAccountByCredentials2()
		{
			String username = "Test", password = "letmein";
			var userAccount = sut.GetUserAccountByCredentials(username, password);
			Assert.AreEqual(expected: username, actual: userAccount.Username);
		}
		[TestMethod]
		public void TestGetUserAccountByCredentialsWithInCorrectValues()
		{
			String username = "blah", password = "letmein";
			var userAccount = sut.GetUserAccountByCredentials(username, password);
			Assert.IsNull(userAccount);
		}
		[TestMethod]
		public void TestGetUserAccountById()
		{
			int userAccountId = 2;
			var userAccount = sut.GetUserAccountById(userAccountId);
			Assert.AreEqual(expected: userAccountId, actual: userAccount.Id);
		}
		[TestMethod]
		public void TestGetUserAccountByNonexistingId()
		{
			int userAccountId = 2666;
			var userAccount = sut.GetUserAccountById(userAccountId);
			Assert.IsNull(userAccount);
		}
		[TestMethod]
		public void TestGetUserAccounts()
		{
			var userAccounts = sut.GetUserAccounts();
			Assert.IsNotNull(userAccounts);
		}
		[TestMethod]
		public void TestInsertAndDelete()
		{
			String timeStamp = DateTime.Now.ToString("yyyyMMddhhmmss");
			var userAccount = new UserAccountDTOComponent
			{
				Email = $"user{timeStamp}@noreply.com",
				IsActive = true,
				Name = "New User",
				Password = "letmien",
				Username = $"user{timeStamp}",
			};

			sut.InsertUserAccount(userAccount);
			var userAccountId = userAccount.Id;
			var insertedUserAccount = sut.GetUserAccountById(userAccountId);

			sut.DeleteUserAccount(userAccount);
			var deletedUserAccount = sut.GetUserAccountById(userAccountId);

			Assert.AreEqual(expected: userAccount.DateCreated.ToString("yyyyMMddhhmmss"), actual: insertedUserAccount.DateCreated.ToString("yyyyMMddhhmmss"));
			Assert.AreEqual(expected: userAccount.DateLastModified.ToString("yyyyMMddhhmmss"), actual: insertedUserAccount.DateLastModified.ToString("yyyyMMddhhmmss"));
			Assert.AreEqual(expected: userAccount.Email, actual: insertedUserAccount.Email);
			Assert.AreEqual(expected: userAccount.Id, actual: insertedUserAccount.Id);
			Assert.AreEqual(expected: userAccount.IsActive, actual: insertedUserAccount.IsActive);
			Assert.AreEqual(expected: userAccount.Name, actual: insertedUserAccount.Name);
			Assert.AreEqual(expected: userAccount.Password, actual: insertedUserAccount.Password);
			Assert.AreEqual(expected: userAccount.Username, actual: insertedUserAccount.Username);

			Assert.IsNull(deletedUserAccount);
		}
		[TestMethod]
		public void TestUpdateUserAccount()
		{
			var userAccountId = 3;
			var userAccount = sut.GetUserAccountById(userAccountId);

			String timeStamp = DateTime.Now.ToString("yyyyMMddhhmmss");
			userAccount.Email = $"user{timeStamp}@noreply.com";
			userAccount.IsActive = !userAccount.IsActive;
			userAccount.Name = $"User{timeStamp}";
			userAccount.Password = timeStamp;
			userAccount.Username = $"User{timeStamp}";

			sut.UpdateUserAccount(userAccount);

			var updatedUserAccount = sut.GetUserAccountById(userAccount.Id);

			Assert.AreEqual(expected: userAccount.DateCreated.ToString("yyyyMMddhhmmss"), actual: updatedUserAccount.DateCreated.ToString("yyyyMMddhhmmss"));
			Assert.AreEqual(expected: userAccount.DateLastModified.ToString("yyyyMMddhhmmss"), actual: updatedUserAccount.DateLastModified.ToString("yyyyMMddhhmmss"));
			Assert.AreEqual(expected: userAccount.Email, actual: updatedUserAccount.Email);
			Assert.AreEqual(expected: userAccount.Id, actual: updatedUserAccount.Id);
			Assert.AreEqual(expected: userAccount.IsActive, actual: updatedUserAccount.IsActive);
			Assert.AreEqual(expected: userAccount.Name, actual: updatedUserAccount.Name);
			Assert.AreEqual(expected: userAccount.Password, actual: updatedUserAccount.Password);
			Assert.AreEqual(expected: userAccount.Username, actual: updatedUserAccount.Username);
		}
	}
}