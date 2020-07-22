namespace DungeonsAndDragonsClub.Repositories.InMemory
{
	using System;
	using System.Collections.Generic;
	using DungeonsAndDragonsClub.Repositories;
	public partial class UserAccountRepositoryComponent : UserAccountRepository
	{
		public UserAccountRepositoryComponent()
		{
		}
		public UserAccountRepositoryComponent(IEnumerable<UserAccountDTO> userAccounts)
		{
			foreach (var userAccount in userAccounts)
			{
				UserAccounts.Add(userAccount);
			}
		}
		#region Public Methods
		#endregion
		public void DeleteUserAccount(UserAccountDTO userAccount)
		{
			UserAccounts.Remove(userAccount);
		}
		public void DeleteUserAccountById(int userAccountId)
		{
			var userAccount = GetUserAccountById(userAccountId);
			DeleteUserAccount(userAccount);
		}
		public IEnumerable<UserAccountDTO> GetUserAccounts()
		{
			return new List<UserAccountDTO>(UserAccounts);
		}
		public UserAccountDTO GetUserAccountById(Int32 userAccountId)
		{
			foreach (var userAccount in UserAccounts)
			{
				if (userAccount.Id == userAccountId)
					return userAccount;
			}
			return default;
		}
		public void InitializeUserAccounts(IEnumerable<UserAccountDTO> userAccounts)
		{
			UserAccounts.Clear();
			foreach (var userAccount in userAccounts)
			{
				UserAccounts.Add(userAccount);
			}
		}
		public Int32 InsertUserAccount(UserAccountDTO userAccount)
		{
			Int32 id = userAccount.Id = GetNewId();
			UserAccounts.Add(userAccount);
			return id;
		}
		public void InsertUserAccounts(IEnumerable<UserAccountDTO> userAccounts)
		{
			foreach (var userAccount in userAccounts)
			{
				InsertUserAccount(userAccount);
			}
		}
		public void UpdateUserAccount(UserAccountDTO userAccount)
		{
			Console.WriteLine($"Update {userAccount.Id}");
		}
		#region Private Methods
		#endregion
		private Int32 GetNewId()
		{
			return UserAccounts.Count + 1;
		}
		#region Private Fields
		#endregion
		private List<UserAccountDTO> UserAccounts { get; } = new List<UserAccountDTO>();
	}
}