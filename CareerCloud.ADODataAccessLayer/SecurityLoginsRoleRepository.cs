﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
	public class SecurityLoginsRoleRepository : BaseADO, IDataRepository<SecurityLoginsRolePoco>
	{
		public void Add(params SecurityLoginsRolePoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (SecurityLoginsRolePoco poco in items)
				{
					cmd.CommandText = @"INSERT INTO dbo.Security_Logins_Roles
										(Id, Login, Role)
										VALUES
										(@Id, @Login, @Role)";

					cmd.Parameters.AddWithValue("@Id", poco.Id);
					cmd.Parameters.AddWithValue("@Login", poco.Login);
					cmd.Parameters.AddWithValue("@Role", poco.Role);

					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}

		public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
		{
			throw new NotImplementedException();
		}

		public IList<SecurityLoginsRolePoco> GetAll(params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
		{
			SecurityLoginsRolePoco[] pocos = new SecurityLoginsRolePoco[100];
			int position = 0;
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandText = @"Select * from dbo.Security_Logins_Roles";
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					SecurityLoginsRolePoco poco = new SecurityLoginsRolePoco();
					poco.Id = reader.GetGuid(0);
					poco.Login = reader.GetGuid(1);
					poco.Role = reader.GetGuid(2);
					if (!reader.IsDBNull(3))
					{
						poco.TimeStamp = (byte[])reader[3];
					}
					else
					{
						poco.TimeStamp = null;
					}

					pocos[position] = poco;
					position++;
				}
				conn.Close();
			}
			return pocos.Where(a => a != null).ToList();
		}

		public IList<SecurityLoginsRolePoco> GetList(Expression<Func<SecurityLoginsRolePoco, bool>> where, params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public SecurityLoginsRolePoco GetSingle(Expression<Func<SecurityLoginsRolePoco, bool>> where, params Expression<Func<SecurityLoginsRolePoco, object>>[] navigationProperties)
		{
			IQueryable<SecurityLoginsRolePoco> pocos = GetAll().AsQueryable();
			return pocos.Where(where).FirstOrDefault();
		}

		public void Remove(params SecurityLoginsRolePoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (SecurityLoginsRolePoco poco in items)
				{
					cmd.CommandText = @"DELETE FROM dbo.Security_Logins_Roles WHERE Id = @Id";
					cmd.Parameters.AddWithValue("@Id", poco.Id);
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}

		public void Update(params SecurityLoginsRolePoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (SecurityLoginsRolePoco poco in items)
				{
					cmd.CommandText = @"UPDATE dbo.Security_Logins_Roles SET
										Login = @Login,
										Role = @Role,
										WHERE Id = @Id";

					cmd.Parameters.AddWithValue("@Id", poco.Id);
					cmd.Parameters.AddWithValue("@Login", poco.Login);
					cmd.Parameters.AddWithValue("@Role", poco.Role);
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}
	}
}
