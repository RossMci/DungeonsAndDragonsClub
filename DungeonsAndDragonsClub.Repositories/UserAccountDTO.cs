namespace DungeonsAndDragonsClub.Repositories
{
	using System;
	/// <summary>
	/// User Account
	/// </summary>
	public interface UserAccountDTO
	{
		#region	Properties
		#endregion
		Int32 Id { get; set; }
		String Email { get; set; }
		Boolean IsActive { get; set; }
		String Name { get; set; }
		String Password { get; set; }
		String Username { get; set; }
		#region	Properties User Tracking
		#endregion
		Int32 CreatedBy { get; set; }
		DateTime DateCreated { get; set; }
		DateTime DateLastModified { get; set; }
		Int32 ModifiedBy { get; set; }
	}
}