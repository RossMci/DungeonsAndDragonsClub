namespace DungeonsAndDragonsClub.Repositories.InMemory
{
	using System;
	using System.Collections.Generic;
	using DungeonsAndDragonsClub.Repositories;
	public class UserGroupRepositoryComponent : UserGroupRepository
	{
		public UserGroupRepositoryComponent()
		{
		}
		public UserGroupRepositoryComponent(IEnumerable<UserGroupDTO> userGroups)
		{
			foreach (var userGroup in userGroups)
			{
				UserGroups.Add(userGroup);
			}
		}
		#region Public Methods
		#endregion
		public void DeleteUserGroup(UserGroupDTO userGroup)
		{
			UserGroups.Remove(userGroup);
		}
		public void DeleteUserGroupById(int userGroupId)
		{
			var userGroup = GetUserGroupById(userGroupId);
			DeleteUserGroup(userGroup);
		}
		public IEnumerable<UserGroupDTO> GetUserGroups()
		{
			return new List<UserGroupDTO>(UserGroups);
		}
		public UserGroupDTO GetUserGroupById(Int32 userGroupId)
		{
			foreach (var userGroup in UserGroups)
			{
				if (userGroup.Id == userGroupId)
					return userGroup;
			}
			return default;
		}
		public void InitializeUserGroups(IEnumerable<UserGroupDTO> userGroups)
		{
			UserGroups.Clear();
			foreach (var userGroup in userGroups)
			{
				UserGroups.Add(userGroup);
			}
		}
		public Int32 InsertUserGroup(UserGroupDTO userGroup)
		{
			Int32 id = userGroup.Id = GetNewId();
			UserGroups.Add(userGroup);
			return id;
		}
		public void InsertUserGroups(IEnumerable<UserGroupDTO> userGroups)
		{
			foreach (var userGroup in userGroups)
			{
				InsertUserGroup(userGroup);
			}
		}
		public void UpdateUserGroup(UserGroupDTO userGroup)
		{
			Console.WriteLine($"Update {userGroup.Id}");
		}
		#region Private Methods
		#endregion
		private Int32 GetNewId()
		{
			return UserGroups.Count + 1;
		}
		#region Private Fields
		#endregion
		private List<UserGroupDTO> UserGroups { get; } = new List<UserGroupDTO>();
	}
}