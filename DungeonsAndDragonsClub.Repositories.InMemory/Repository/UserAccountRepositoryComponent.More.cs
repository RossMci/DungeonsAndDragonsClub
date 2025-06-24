namespace DungeonsAndDragonsClub.Repositories.InMemory
{
	using System;
	using System.Collections.Generic;
	/// <summary>
	/// UserAccount Repository Component
	/// </summary>
	partial class UserAccountRepositoryComponent
	{
		public IEnumerable<UserAccountDTO> GetActiveUserAccounts()
		{
			List<UserAccountDTO> userAccounts = new List<UserAccountDTO>();
			foreach (var userAccount in UserAccounts)
			{
				if (userAccount.IsActive == true)
					userAccounts.Add(userAccount);
			}
			return userAccounts;
		}
		public UserAccountDTO GetUserAccountByCredentials(String username, String password)
		{
			foreach (var userAccount in UserAccounts)
			{
				if (userAccount.Username == username && userAccount.Password == password)
					return userAccount;
			}
			return default;
		}
	}
}