using System;
using System.Collections.Generic;
using System.Text;

namespace DungeonsAndDragonsClub
{
	public interface Campaign
	{
		Int32 Id { get; set; }
		String Title { get; set; }
		UserAccount CreatedBy { get; set; }
		UserAccount ModifiedBy { get; set; }
		DateTime DateCreated { get; set; }
		DateTime DateLastModified { get; set; }
		DateTime CampaignDate{ get; set; }
		DateTime StartTime { get; set; }
		DateTime EndTime { get; set; }
		String CampaignDescription { get; set; }
		IList<UserAccount> UserAccounts { get; set; }
		// image Type ?
	}
}
