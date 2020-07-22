﻿namespace DungeonsAndDragonsClub.Repositories
{
	using System;
	using System.Collections.Generic;
	public partial interface UserAccountRepository
	{
		void DeleteUserAccount(UserAccountDTO userAccount);
		IEnumerable<UserAccountDTO> GetUserAccounts();
		UserAccountDTO GetUserAccountById(Int32 userAccountId);
		Int32 InsertUserAccount(UserAccountDTO userAccount);
		void UpdateUserAccount(UserAccountDTO userAccount);
	}
}