namespace DungeonsAndDragonsClub.Repositories.SQLite
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Data.SQLite;
	using System.Linq;
	/// <summary>
	/// UserGroup Repository Component
	/// </summary>
	public partial class UserGroupRepositoryComponent : UserGroupRepository
	{
		public UserGroupRepositoryComponent(DatabaseAgent databaseAgent, DungeonsAndDragonsClubSqlStatements sqlStatements)
		{
			this.DatabaseAgent = databaseAgent;
			this.SqlStatements = sqlStatements;
		}
		#region Public Methods
		#endregion
		public void DeleteUserGroup(UserGroupDTO course)
		{
			using var connection = new SQLiteConnection(DatabaseAgent.ConnectionString);
			{
				connection.Open();
				using var command = new SQLiteCommand(SqlStatements.DeleteUserGroup, connection);
				{
					command.Parameters.AddWithValue("$Id", course.Id);
					command.Prepare();
					command.ExecuteNonQuery();
				}
			}
		}
		public UserGroupDTO GetUserGroupById(Int32 courseId)
		{
			using var connection = new SQLiteConnection(DatabaseAgent.ConnectionString);
			{
				connection.Open();
				using var command = new SQLiteCommand(SqlStatements.GetUserGroupById, connection);
				{
					command.Parameters.AddWithValue("$Id", courseId);
					command.Prepare();
					using var dataReader = command.ExecuteReader();
					{
						return this.TransformToList(dataReader).FirstOrDefault();
					}
				}
			}
		}
		public IEnumerable<UserGroupDTO> GetUserGroups()
		{
			using var connection = new SQLiteConnection(DatabaseAgent.ConnectionString);
			{
				connection.Open();
				using var command = new SQLiteCommand(SqlStatements.GetUserGroups, connection);
				{
					using var dataReader = command.ExecuteReader();
					{
						return this.TransformToList(dataReader);
					}
				}
			}
		}
		public void InsertUserGroup(UserGroupDTO course)
		{
			using var connection = new SQLiteConnection(DatabaseAgent.ConnectionString);
			{
				connection.Open();
				using var command = new SQLiteCommand(SqlStatements.InsertUserGroup, connection);
				{
					command.Parameters.AddWithValue("$Name", course.Name);
					command.Prepare();
					command.ExecuteNonQuery();
					course.Id = GetLastInsertRowId(connection);
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
		public void UpdateUserGroup(UserGroupDTO course)
		{
			using var connection = new SQLiteConnection(DatabaseAgent.ConnectionString);
			{
				connection.Open();
				using var command = new SQLiteCommand(SqlStatements.UpdateUserGroup, connection);
				{
					command.Parameters.AddWithValue("$Id", course.Id);
					command.Parameters.AddWithValue("$Name", course.Name);
					command.Prepare();
					command.ExecuteNonQuery();
				}
			}
		}
		#region Private Methods
		#endregion
		private IEnumerable<UserGroupDTO> TransformToList(SQLiteDataReader dataReader)
		{
			var courses = new List<UserGroupDTO>();
			while (dataReader.Read())
			{
				courses.Add(this.TransformDataReaderToUserGroup(dataReader));
			}
			return courses;
		}
		private UserGroupDTO TransformDataReaderToUserGroup(SQLiteDataReader dataReader)
		{
			return new UserGroupDTOComponent
			{
				Id = Convert.ToInt32(dataReader["Id"]),
				Name = Convert.ToString(dataReader["Name"]),
			};
		}
		#region Private Properties
		#endregion
		private DatabaseAgent DatabaseAgent { get; set; }
		private DungeonsAndDragonsClubSqlStatements SqlStatements { get; set; }
	}
}