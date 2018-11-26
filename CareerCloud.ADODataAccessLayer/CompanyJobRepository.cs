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
	public class CompanyJobRepository : BaseADO, IDataRepository<CompanyJobPoco>
	{
		public void Add(params CompanyJobPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (CompanyJobPoco poco in items)
				{
					cmd.CommandText = @"INSERT INTO dbo.Company_Jobs
										(Id, Company, Profile_Created, Is_Inactive, Is_Company_Hidden)
										VALUES
										(@Id, @Company, @ProfileCreated, @IsInactive, @IsCompanyHidden)";

					cmd.Parameters.AddWithValue("@Id", poco.Id);
					cmd.Parameters.AddWithValue("@Company", poco.Company);
					cmd.Parameters.AddWithValue("@ProfileCreated", poco.ProfileCreated);
					cmd.Parameters.AddWithValue("@IsInactive", poco.IsInactive);
					cmd.Parameters.AddWithValue("@IsCompanyHidden", poco.IsCompanyHidden);

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

		public IList<CompanyJobPoco> GetAll(params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
		{
			CompanyJobPoco[] pocos = new CompanyJobPoco[1100];
			int position = 0;
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandText = @"Select * From dbo.Company_Jobs";
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					CompanyJobPoco poco = new CompanyJobPoco();
					poco.Id = reader.GetGuid(0);
					poco.Company = reader.GetGuid(1);
					poco.ProfileCreated = reader.GetDateTime(2);
					poco.IsInactive = (bool)reader[3];
					poco.IsCompanyHidden = (bool)reader[4];
					if (!reader.IsDBNull(5))
					{
						poco.TimeStamp = (byte[])reader[5];
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

		public IList<CompanyJobPoco> GetList(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public CompanyJobPoco GetSingle(Expression<Func<CompanyJobPoco, bool>> where, params Expression<Func<CompanyJobPoco, object>>[] navigationProperties)
		{
			IQueryable<CompanyJobPoco> pocos = GetAll().AsQueryable();
			return pocos.Where(where).FirstOrDefault();
		}

		public void Remove(params CompanyJobPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (CompanyJobPoco poco in items)
				{
					cmd.CommandText = @"DELETE FROM dbo.Company_Jobs WHERE Id = @Id";

					cmd.Parameters.AddWithValue("@Id", poco.Id);
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}

		public void Update(params CompanyJobPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (CompanyJobPoco poco in items)
				{
					cmd.CommandText = @"UPDATE dbo.Company_Jobs SET
										Company = @Company,
										Profile_Created = @ProfileCreated,
										Is_Inactive = @IsInActive,
										Is_Company_Hidden = @IsCompHidden
										WHERE Id = @Id";

					cmd.Parameters.AddWithValue("@Id", poco.Id);
					cmd.Parameters.AddWithValue("@Company", poco.Company);
					cmd.Parameters.AddWithValue("@ProfileCreated", poco.ProfileCreated);
					cmd.Parameters.AddWithValue("@IsInactive", poco.IsInactive);
					cmd.Parameters.AddWithValue("@IsCompHidden", poco.IsCompanyHidden);
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}
	}
}
