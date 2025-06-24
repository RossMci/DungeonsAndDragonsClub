namespace DungeonsAndDragonsClub.Repositories
{
	using System;
	public interface UserAccountGroupLinkDTO
	{
		Int32 Id { get; set; }
		Int32 UserAccount { get; set; }
		Int32 UserGroup { get; set; }
	}
}