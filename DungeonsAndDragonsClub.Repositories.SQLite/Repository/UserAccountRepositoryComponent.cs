namespace DungeonsAndDragonsClub.Repositories.SQLite
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SQLite;
	using System.Linq;
	/// <summary>
	/// UserAccount Repository Component
	/// </summary>
	public partial class UserAccountRepositoryComponent : UserAccountRepository
	{
		public UserAccountRepositoryComponent(DatabaseAgent databaseAgent, DungeonsAndDragonsClubSqlStatements sqlStatements)
		{
			this.DatabaseAgent = databaseAgent;
			this.SqlStatements = sqlStatements;
		}
		#region Public Methods
		#endregion
		public void DeleteUserAccount(UserAccountDTO userAccount)
		{
			using var connection = new SQLiteConnection(DatabaseAgent.ConnectionString);
			{
				connection.Open();
				using var command = new SQLiteCommand(SqlStatements.DeleteUserAccount, connection);
				{
					command.Parameters.AddWithValue("$Id", userAccount.Id);
					command.Prepare();
					command.ExecuteNonQuery();
				}
			}
		}
		public UserAccountDTO GetUserAccountById(Int32 userAccountId)
		{
			using var connection = new SQLiteConnection(DatabaseAgent.ConnectionString);
			{
				connection.Open();
				using var command = new SQLiteCommand(SqlStatements.GetUserAccountById, connection);
				{
					command.Parameters.AddWithValue("$Id", userAccountId);
					command.Prepare();
					using var dataReader = command.ExecuteReader();
					{
						return this.TransformToList(dataReader).FirstOrDefault();
					}
				}
			}
		}
		public IEnumerable<UserAccountDTO> GetUserAccounts()
		{
			using var connection = new SQLiteConnection(DatabaseAgent.ConnectionString);
			{
				connection.Open();
				using var command = new SQLiteCommand(SqlStatements.GetUserAccounts, connection);
				{
					using var dataReader = command.ExecuteReader();
					{
						return this.TransformToList(dataReader);
					}
				}
			}
		}
		public Int32 InsertUserAccount(UserAccountDTO userAccount)
		{
			userAccount.DateCreated = userAccount.DateLastModified = DateTime.Now;
			using var connection = new SQLiteConnection(DatabaseAgent.ConnectionString);
			{
				connection.Open();
				using var command = new SQLiteCommand(SqlStatements.InsertUserAccount, connection);
				{
					command.Parameters.AddWithValue("$DateCreated", userAccount.DateCreated);
					command.Parameters.AddWithValue("$DateLastModified", userAccount.DateLastModified);
					command.Parameters.AddWithValue("$Email", userAccount.Email);
					command.Parameters.AddWithValue("$IsActive", userAccount.IsActive);
					command.Parameters.AddWithValue("$Name", userAccount.Name);
					command.Parameters.AddWithValue("$Password", userAccount.Password);
					command.Parameters.AddWithValue("$Username", userAccount.Username);
					command.Prepare();
					command.ExecuteNonQuery();

					return userAccount.Id = GetLastInsertRowId(connection);
				}
			}
		}
		private Int32 GetLastInsertRowId(SQLiteConnection connection)
		{
			String sql = SqlStatements.GetLastInsertRowId;
			using var command = new SQLiteCommand(sql, connection);
			{
				return Convert.ToInt32(command.ExecuteScalar());
			}
		}
		public void UpdateUserAccount(UserAccountDTO userAccount)
		{
			userAccount.DateLastModified = DateTime.Now;
			using var connection = new SQLiteConnection(DatabaseAgent.ConnectionString);
			{
				connection.Open();
				using var command = new SQLiteCommand(SqlStatements.UpdateUserAccount, connection);
				{
					command.Parameters.AddWithValue("$Id", userAccount.Id);
					command.Parameters.AddWithValue("$DateCreated", userAccount.DateCreated);
					command.Parameters.AddWithValue("$DateLastModified", userAccount.DateLastModified);
					command.Parameters.AddWithValue("$DateLastModified", userAccount.DateLastModified);
					command.Parameters.AddWithValue("$Email", userAccount.Email);
					command.Parameters.AddWithValue("$IsActive", userAccount.IsActive);
					command.Parameters.AddWithValue("$Name", userAccount.Name);
					command.Parameters.AddWithValue("$Password", userAccount.Password);
					command.Parameters.AddWithValue("$Username", userAccount.Username);
					command.Prepare();
					command.ExecuteNonQuery();
				}
			}
		}
		#region Private Methods
		#endregion
		private IEnumerable<UserAccountDTO> TransformToList(SQLiteDataReader dataReader)
		{
			var userAccounts = new List<UserAccountDTO>();
			while (dataReader.Read())
			{
				userAccounts.Add(this.TransformDataReaderToUserAccount(dataReader));
			}
			return userAccounts;
		}
		private UserAccountDTO TransformDataReaderToUserAccount(SQLiteDataReader dataReader)
		{
			return new UserAccountDTOComponent
			{
				CreatedBy = Convert.ToInt32(dataReader["CreatedBy"]),
				DateCreated = Convert.ToDateTime(dataReader["DateCreated"]),
				DateLastModified = Convert.ToDateTime(dataReader["DateLastModified"]),
				Email = Convert.ToString(dataReader["Email"]),
				Id = Convert.ToInt32(dataReader["Id"]),
				IsActive = Convert.ToBoolean(dataReader["IsActive"]),
				ModifiedBy = Convert.ToInt32(dataReader["ModifiedBy"]),
				Name = Convert.ToString(dataReader["Name"]),
				Password = Convert.ToString(dataReader["Password"]),
				Username = Convert.ToString(dataReader["Username"]),
			};
		}
		#region Private Properties
		#endregion
		private DatabaseAgent DatabaseAgent { get; set; }
		private DungeonsAndDragonsClubSqlStatements SqlStatements { get; set; }
	}
}