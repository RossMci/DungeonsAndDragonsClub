namespace DungeonsAndDragonsClub.Repositories.InMemory
{
	using System;
	using DungeonsAndDragonsClub.Repositories;
	public partial class DungeonsAndDragonsClubComponent : DungeonsAndDragonsClubSystem
	{
		public DungeonsAndDragonsClubComponent(String name)
		{
			Name = name;
			//
			//	repositories
			//
			this.UserAccountRepository = new UserAccountRepositoryComponent();
			this.UserGroupRepository = new UserGroupRepositoryComponent();
		}
		#region Public Properties
		#endregion
		public String Name { get; }
		#region Public Properties - Repositories
		#endregion
		public UserAccountRepositoryComponent UserAccountRepository { get; }
		public UserGroupRepositoryComponent UserGroupRepository { get; }
		#region DungeonsAndDragonsClubSystem - Members
		#endregion
		UserAccountRepository DungeonsAndDragonsClubSystem.UserAccountRepository { get { return UserAccountRepository; } }
		UserGroupRepository DungeonsAndDragonsClubSystem.UserGroupRepository { get { return UserGroupRepository; } }
	}
}