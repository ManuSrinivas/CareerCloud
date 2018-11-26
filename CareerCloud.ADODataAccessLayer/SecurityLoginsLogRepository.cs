using System;
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
	public class SecurityLoginsLogRepository : BaseADO, IDataRepository<SecurityLoginsLogPoco>
	{
		public void Add(params SecurityLoginsLogPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (SecurityLoginsLogPoco poco in items)
				{
					cmd.CommandText = @"INSERT INTO dbo.Security_Logins_Log
										(Id, Login, Source_IP, Logon_Date, Is_Succesful)
										VALUES
										(@Id, @Login, @SourceIP, @LogonDate, @IsSuccesful)";

					cmd.Parameters.AddWithValue("@Id", poco.Id);
					cmd.Parameters.AddWithValue("@Login", poco.Login);
					cmd.Parameters.AddWithValue("@SourceIP", poco.SourceIP);
					cmd.Parameters.AddWithValue("@LogonDate", poco.LogonDate);
					cmd.Parameters.AddWithValue("@IsSuccesful", poco.IsSuccesful);

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

		public IList<SecurityLoginsLogPoco> GetAll(params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
		{
			SecurityLoginsLogPoco[] pocos = new SecurityLoginsLogPoco[1800];
			int position = 0;
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandText = @"Select * From dbo.Security_Logins_Log";
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					SecurityLoginsLogPoco poco = new SecurityLoginsLogPoco();
					poco.Id = reader.GetGuid(0);
					poco.Login = reader.GetGuid(1);
					poco.SourceIP = reader.GetString(2);
					poco.LogonDate = reader.GetDateTime(3);
					poco.IsSuccesful = (bool)reader[4];

					pocos[position] = poco;
					position++;
				}
				conn.Close();
			}
			return pocos.Where(a => a != null).ToList();
		}

		public IList<SecurityLoginsLogPoco> GetList(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public SecurityLoginsLogPoco GetSingle(Expression<Func<SecurityLoginsLogPoco, bool>> where, params Expression<Func<SecurityLoginsLogPoco, object>>[] navigationProperties)
		{
			IQueryable<SecurityLoginsLogPoco> pocos = GetAll().AsQueryable();
			return pocos.Where(where).FirstOrDefault();
		}

		public void Remove(params SecurityLoginsLogPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (SecurityLoginsLogPoco poco in items)
				{
					cmd.CommandText = @"DELETE FROM dbo.Security_Logins_Log WHERE Id = @Id";
					cmd.Parameters.AddWithValue("@Id", poco.Id);
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}

		public void Update(params SecurityLoginsLogPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (SecurityLoginsLogPoco poco in items)
				{
					cmd.CommandText = @"UPDATE dbo.Security_Logins_Log SET
										Login = @Login,
										Source_IP = @SourceIP,
										Logon_Date = @LogonDate,
										Is_Succesful = @IsSuccesful
										WHERE Id = @Id";

					cmd.Parameters.AddWithValue("@Id", poco.Id);
					cmd.Parameters.AddWithValue("@Login", poco.Login);
					cmd.Parameters.AddWithValue("@SourceIP", poco.SourceIP);
					cmd.Parameters.AddWithValue("@LogonDate", poco.LogonDate);
					cmd.Parameters.AddWithValue("@IsSuccesful", poco.IsSuccesful);

					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}
	}
}
