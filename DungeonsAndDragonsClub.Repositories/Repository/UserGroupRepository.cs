﻿namespace DungeonsAndDragonsClub.Repositories
{
    using System;
	using System.Collections.Generic;
	public partial interface UserGroupRepository
	{
		void DeleteUserGroup(UserGroupDTO tutor);
		IEnumerable<UserGroupDTO> GetUserGroups();
		UserGroupDTO GetUserGroupById(Int32 tutorId);
		void InsertUserGroup(UserGroupDTO tutor);
		void UpdateUserGroup(UserGroupDTO tutor);
	}
}