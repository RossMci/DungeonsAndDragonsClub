namespace DungeonsAndDragonsClub.Repositories
{
	using System;
	public class UserAccountGroupLinkDTOComponent : UserAccountGroupLinkDTO
	{
		public Int32 Id { get; set; }
		public Int32 UserAccount { get; set; }
		public Int32 UserGroup { get; set; }
	}
}