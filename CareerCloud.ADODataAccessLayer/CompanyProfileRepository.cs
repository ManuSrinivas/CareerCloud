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
	public class CompanyProfileRepository : BaseADO, IDataRepository<CompanyProfilePoco>
	{
		public void Add(params CompanyProfilePoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (CompanyProfilePoco poco in items)
				{
					cmd.CommandText = @"INSERT INTO dbo.Company_Profiles
										(Id, Registration_Date, Company_Website, Contact_Phone, Contact_Name, Company_Logo)
										VALUES
										(@Id, @RegDate, @CompanyWebsite, @ConPhone, @ConName, @CompanyLogo)";

					cmd.Parameters.AddWithValue("@Id", poco.Id);
					cmd.Parameters.AddWithValue("@RegDate", poco.RegistrationDate);
					cmd.Parameters.AddWithValue("@CompanyWebsite", poco.CompanyWebsite);
					cmd.Parameters.AddWithValue("@ConPhone", poco.ContactPhone);
					cmd.Parameters.AddWithValue("@ConName", poco.ContactName);
					cmd.Parameters.AddWithValue("@CompanyLogo", poco.CompanyLogo);
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

		public IList<CompanyProfilePoco> GetAll(params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
		{
			CompanyProfilePoco[] pocos = new CompanyProfilePoco[250];
			int position = 0;
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandText = @"Select * From dbo.Company_Profiles";
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					CompanyProfilePoco poco = new CompanyProfilePoco();
					poco.Id = reader.GetGuid(0);
					poco.RegistrationDate = reader.GetDateTime(1);
					if (!reader.IsDBNull(2))
					{
						poco.CompanyWebsite = reader.GetString(2);
					}
					else
					{
						poco.CompanyWebsite = null;
					}
					poco.ContactPhone = reader.GetString(3);
					if (!reader.IsDBNull(4))
					{
						poco.ContactName = reader.GetString(4);
					}
					else
					{
						poco.ContactName = null;
					}
					if (!reader.IsDBNull(5))
					{
						poco.CompanyLogo = (byte[])reader[5];
					}
					else
					{
						poco.CompanyLogo = null;
					}
					poco.TimeStamp = (byte[])reader[6];

					pocos[position] = poco;
					position++;
				}
				conn.Close();
			}
			return pocos.Where(a => a != null).ToList();
		}

		public IList<CompanyProfilePoco> GetList(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public CompanyProfilePoco GetSingle(Expression<Func<CompanyProfilePoco, bool>> where, params Expression<Func<CompanyProfilePoco, object>>[] navigationProperties)
		{
			IQueryable<CompanyProfilePoco> pocos = GetAll().AsQueryable();
			return pocos.Where(where).FirstOrDefault();
		}

		public void Remove(params CompanyProfilePoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (CompanyProfilePoco poco in items)
				{
					cmd.CommandText = @"DELETE FROM dbo.Company_Profiles WHERE Id = @Id";
					cmd.Parameters.AddWithValue("@Id", poco.Id);
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}

		public void Update(params CompanyProfilePoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (CompanyProfilePoco poco in items)
				{
					cmd.CommandText = @"UPDATE dbo.Company_Profiles SET
										Registration_Date = @RegDate,
										Company_Website = @ComWebsite,
										Contact_Phone = @ConPhone,
										Contact_Name = @ConName,
										Company_Logo = @CompanyLogo
										WHERE Id = @Id";

					cmd.Parameters.AddWithValue("@Id", poco.Id);
					cmd.Parameters.AddWithValue("@ComWebsite", poco.CompanyWebsite);
					cmd.Parameters.AddWithValue("@ConPhone", poco.ContactPhone);
					cmd.Parameters.AddWithValue("@ConName", poco.ContactName);
					cmd.Parameters.AddWithValue("@CompanyLogo", poco.CompanyLogo);
					cmd.Parameters.AddWithValue("@RegDate", poco.RegistrationDate);
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}
	}
}
