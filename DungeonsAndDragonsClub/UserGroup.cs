namespace DungeonsAndDragonsClub
{
    using System;
	using System.Collections.Generic;
    /// <summary>
    /// User Group to assign roles and permissions
    /// </summary>
	public interface UserGroup
    {
        Int32 Id { get; set; }
        String Name { get; set; }
        IList<UserAccount> Users { get; set; }
    }
}
