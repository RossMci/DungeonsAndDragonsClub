namespace DungeonsAndDragonsClub.Repositories.SQLite
{
	using System;
	public partial class DungeonsAndDragonsClubSqlStatements
	{
		public String DeleteUserAccount => "DELETE FROM UserAccount WHERE Id = $Id;";
		public String GetUserAccountById => "SELECT * FROM UserAccount WHERE Id = $Id;";
		public String GetUserAccounts => "SELECT * FROM UserAccount;";
		public String InsertUserAccount => @"INSERT INTO UserAccount (DateCreated, DateLastModified, Email, IsActive, Name, Password, Username) VALUES ($DateCreated, $DateLastModified, $Email, $IsActive, $Name, $Password, $Username);";
		public String UpdateUserAccount => "UPDATE UserAccount SET DateLastModified = $DateLastModified, Email = $Email, IsActive = $IsActive, Name = $Name, Password = $Password, Username = $Username WHERE Id = $Id;";
		public String DeleteUserGroup => "DELETE FROM UserGroup WHERE Id = $Id;";
		public String GetUserGroupById => "SELECT * FROM UserGroup WHERE Id = $Id;";
		public String GetUserGroups => "SELECT * FROM UserGroup;";
		public String InsertUserGroup => "INSERT INTO UserGroup (Name) VALUES ($Name);";
		public String UpdateUserGroup => "UPDATE UserGroup SET Name = $Name WHERE Id = $Id;";
	}
}