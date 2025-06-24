namespace DungeonsAndDragonsClub.Repositories
{
	using System;
	/// <summary>
	/// User Account DTO
	/// </summary>
	public class UserAccountDTOComponent : UserAccountDTO
	{
		#region	Properties
		#endregion
		public Int32 Id
		{
			get;
			set;
		}
		public String Email
		{
			get;
			set;
		}
		public Boolean IsActive
		{
			get;
			set;
		}
		public String Name
		{
			get;
			set;
		}
		public String Password
		{
			get;
			set;
		}
		public String Username
		{
			get;
			set;
		}
		#region	Properties User Tracking
		#endregion
		public Int32 CreatedBy { get; set; }
		public DateTime DateCreated { get; set; }
		public DateTime DateLastModified { get; set; }
		public Int32 ModifiedBy { get; set; }
	}
}