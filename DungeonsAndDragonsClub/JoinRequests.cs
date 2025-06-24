namespace DungeonsAndDragonsClub
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	public interface JoinRequests
	{
		Int32 Id { get; set; }
		Campaign Title { get; set; }
		UserAccount Username { get; set; }
		Boolean RequestResult { get; set; }
		IList<UserAccount> UserAccounts { get; set;}

	}
}
