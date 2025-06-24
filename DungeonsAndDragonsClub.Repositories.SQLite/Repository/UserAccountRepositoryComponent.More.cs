namespace DungeonsAndDragonsClub.Repositories.SQLite
{
	using System;
	using System.Collections.Generic;
	using System.Data.SQLite;
	using System.Linq;
	partial class UserAccountRepositoryComponent
	{
		public IEnumerable<UserAccountDTO> GetActiveUserAccounts()
		{
			using var connection = new SQLiteConnection(DatabaseAgent.ConnectionString);
			{
				connection.Open();
				using var command = new SQLiteCommand(SqlStatements.GetActiveUserAccounts, connection);
				{
					command.Prepare();
					using var dataReader = command.ExecuteReader();
					{
						return this.TransformToList(dataReader);
					}
				}
			}
		}
		public UserAccountDTO GetUserAccountByCredentials(String username, String password)
		{
			using var connection = new SQLiteConnection(DatabaseAgent.ConnectionString);
			{
				connection.Open();
				using var command = new SQLiteCommand(SqlStatements.GetUserAccountByCredentials, connection);
				{
					command.Parameters.AddWithValue("$Password", password);
					command.Parameters.AddWithValue("$Username", username);
					command.Prepare();
					using var dataReader = command.ExecuteReader();
					{
						return this.TransformToList(dataReader).FirstOrDefault();
					}
				}
			}
		}
	}
}