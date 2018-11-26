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
	public class SecurityLoginRepository : BaseADO, IDataRepository<SecurityLoginPoco>
	{
		public void Add(params SecurityLoginPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (SecurityLoginPoco poco in items)
				{
					cmd.CommandText = @"INSERT INTO dbo.Security_Logins
										(Id, Login, Password, Created_Date, Password_Update_Date, Agreement_Accepted_Date,
										Is_Locked, Is_Inactive, Email_Address, Phone_Number, Full_Name, Force_Change_Password, Prefferred_Language)
										VALUES
										(@Id, @Login, @Password, @CreatedDate, @PasswordUpDt, @AgreementAccDt,
										@IsLocked, @IsInactive, @Email, @Phone, @FullName, @ForceChnPassword, @PrefLang)";

					cmd.Parameters.AddWithValue("@Id", poco.Id);
					cmd.Parameters.AddWithValue("@Login", poco.Login);
					cmd.Parameters.AddWithValue("@Password", poco.Password);
					cmd.Parameters.AddWithValue("@CreatedDate", poco.Created);
					cmd.Parameters.AddWithValue("@PasswordUpDt", poco.PasswordUpdate);
					cmd.Parameters.AddWithValue("@AgreementAccDt", poco.AgreementAccepted);
					cmd.Parameters.AddWithValue("@IsLocked", poco.IsLocked);
					cmd.Parameters.AddWithValue("@IsInactive", poco.IsInactive);
					cmd.Parameters.AddWithValue("@Email", poco.EmailAddress);
					cmd.Parameters.AddWithValue("@Phone", poco.PhoneNumber);
					cmd.Parameters.AddWithValue("@FullName", poco.FullName);
					cmd.Parameters.AddWithValue("@ForceChnpassword", poco.ForceChangePassword);
					cmd.Parameters.AddWithValue("@PrefLang", poco.PrefferredLanguage);

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

		public IList<SecurityLoginPoco> GetAll(params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
		{
			SecurityLoginPoco[] pocos = new SecurityLoginPoco[100];
			int position = 0;
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandText = @"Select * from dbo.Security_Logins";
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					SecurityLoginPoco poco = new SecurityLoginPoco();
					poco.Id = reader.GetGuid(0);
					poco.Login = reader.GetString(1);
					poco.Password = reader.GetString(2);
					poco.Created = reader.GetDateTime(3);
					if (!reader.IsDBNull(4))
					{
						poco.PasswordUpdate = reader.GetDateTime(4);
					}
					else
					{
						poco.PasswordUpdate = null;
					}
					if (!reader.IsDBNull(5))
					{
						poco.AgreementAccepted = reader.GetDateTime(5);
					}
					else
					{
						poco.AgreementAccepted = null;
					}
					poco.IsLocked = (bool)reader[6];
					poco.IsInactive = (bool)reader[7];
					poco.EmailAddress = reader.GetString(8);
					if (!reader.IsDBNull(9))
					{
						poco.PhoneNumber = reader.GetString(9);
					}
					else
					{
						poco.PhoneNumber = null;
					}
					if (!reader.IsDBNull(10))
					{
						poco.FullName = reader.GetString(10);
					}
					else
					{
						poco.FullName = null;
					}
					poco.ForceChangePassword = (bool)reader[11];
					if (!reader.IsDBNull(12))
					{
						poco.PrefferredLanguage = reader.GetString(12);
					}
					else
					{
						poco.PrefferredLanguage = null;
					}
					poco.TimeStamp = (byte[])reader[13];

					pocos[position] = poco;
					position++;
				}
				conn.Close();
			}
			return pocos.Where(a => a != null).ToList();
		}

		public IList<SecurityLoginPoco> GetList(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public SecurityLoginPoco GetSingle(Expression<Func<SecurityLoginPoco, bool>> where, params Expression<Func<SecurityLoginPoco, object>>[] navigationProperties)
		{
			IQueryable<SecurityLoginPoco> pocos = GetAll().AsQueryable();
			return pocos.Where(where).FirstOrDefault();
		}

		public void Remove(params SecurityLoginPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (SecurityLoginPoco poco in items)
				{
					cmd.CommandText = @"DELETE FROm dbo.Security_Logins WHERE Id = @Id";
					cmd.Parameters.AddWithValue("@Id", poco.Id);
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}

		public void Update(params SecurityLoginPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (SecurityLoginPoco poco in items)
				{
					cmd.CommandText = @"UPDATE dbo.Security_Logins SET
										Login = @Login,
										Password = @Password,
										Created_Date = @Created,
										Password_Update_Date = @PasswordUpDt,
										Agreement_Accepted_Date = @Agreement,
										Is_Locked = @IsLocked,
										Is_Inactive = @IsInactive,
										Email_Address = @Email,
										Phone_Number = @Phone,
										Full_Name = @FullName,
										Force_Change_Password = @ForceChgPassword,
										Prefferred_Language = @PrefLang
										WHERE Id = @Id";

					cmd.Parameters.AddWithValue("@Id", poco.Id);
					cmd.Parameters.AddWithValue("@Login", poco.Login);
					cmd.Parameters.AddWithValue("@Password", poco.Password);
					cmd.Parameters.AddWithValue("@Created", poco.Created);
					cmd.Parameters.AddWithValue("@PasswordUpDt", poco.PasswordUpdate);
					cmd.Parameters.AddWithValue("@Agreement", poco.AgreementAccepted);
					cmd.Parameters.AddWithValue("@IsLocked", poco.IsLocked);
					cmd.Parameters.AddWithValue("@IsInactive", poco.IsInactive);
					cmd.Parameters.AddWithValue("@Email", poco.EmailAddress);
					cmd.Parameters.AddWithValue("@Phone", poco.PhoneNumber);
					cmd.Parameters.AddWithValue("@FullName", poco.FullName);
					cmd.Parameters.AddWithValue("@ForceChgPassword", poco.ForceChangePassword);
					cmd.Parameters.AddWithValue("@PrefLang", poco.PrefferredLanguage);

					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}
	}
}
