namespace DungeonsAndDragonsClub
{
	using System;
	using System.Collections.Generic;
	/// <summary>
	/// User Account
	/// </summary>
	public interface UserAccount
	{
		#region	Properties
		#endregion
		Int32 Id { get; set; }
		String Email { get; set; }
		Boolean IsActive { get; set; }
		String Name { get; set; }
		String Password { get; set; }
		IList<UserAccount> UserGroups { get; set; }
		String Username { get; set; }
		#region	Properties User Tracking
		#endregion
		UserAccount CreatedBy { get; set; }
		DateTime DateCreated { get; set; }
		DateTime DateLastModified { get; set; }
		UserAccount ModifiedBy { get; set; }
	}
}