namespace DungeonsAndDragonsClub.Repositories
{
	public interface DungeonsAndDragonsClubSystem
	{
		UserAccountRepository UserAccountRepository { get; }
		UserGroupRepository UserGroupRepository { get; }
	}
}