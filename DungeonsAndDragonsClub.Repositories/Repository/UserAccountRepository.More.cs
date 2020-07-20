namespace DungeonsAndDragonsClub.Repositories
{
	using System;
	partial interface UserAccountRepository
	{
		UserAccountDTO GetUserAccountByCredentials(String username, String password);
	}
}