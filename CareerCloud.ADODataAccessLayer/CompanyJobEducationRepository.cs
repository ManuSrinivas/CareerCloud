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
	public class CompanyJobEducationRepository : BaseADO, IDataRepository<CompanyJobEducationPoco>
	{
		public void Add(params CompanyJobEducationPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (CompanyJobEducationPoco poco in items)
				{
					cmd.CommandText = @"INSERT INTO dbo.Company_Job_Educations
										(Id, Job, Major, Importance)
										VALUES
										(@Id, @Job, @Major, @Importance)";

					cmd.Parameters.AddWithValue("@Id", poco.Id);
					cmd.Parameters.AddWithValue("@Job", poco.Job);
					cmd.Parameters.AddWithValue("@Major", poco.Major);
					cmd.Parameters.AddWithValue("@Importance", poco.Importance);
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

		public IList<CompanyJobEducationPoco> GetAll(params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
		{
			CompanyJobEducationPoco[] pocos = new CompanyJobEducationPoco[1100];
			int position = 0;
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandText = @"Select * from Company_Job_Educations";
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					CompanyJobEducationPoco poco = new CompanyJobEducationPoco();
					poco.Id = reader.GetGuid(0);
					poco.Job = reader.GetGuid(1);
					poco.Major = reader.GetString(2);
					poco.Importance = (short)reader[3];
					poco.TimeStamp = (byte[])reader[4];
					pocos[position] = poco;
					position++;
				}
				conn.Close();
			}
			return pocos.Where(a => a != null).ToList();
		}

		public IList<CompanyJobEducationPoco> GetList(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public CompanyJobEducationPoco GetSingle(Expression<Func<CompanyJobEducationPoco, bool>> where, params Expression<Func<CompanyJobEducationPoco, object>>[] navigationProperties)
		{
			IQueryable<CompanyJobEducationPoco> pocos = GetAll().AsQueryable();
			return pocos.Where(where).FirstOrDefault();
		}

		public void Remove(params CompanyJobEducationPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (CompanyJobEducationPoco poco in items)
				{
					cmd.CommandText = @"DELETE FROM dbo.Company_Job_Educations WHERE Id = @Id";

					cmd.Parameters.AddWithValue("@Id", poco.Id);
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}

		public void Update(params CompanyJobEducationPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (CompanyJobEducationPoco Poco in items)
				{
					cmd.CommandText = @"UPDATE dbo.Company_Job_Educations SET
										Job = @Job,
										Major = @Major,
										Importance = @Importance
										WHERE Id = @Id";

					cmd.Parameters.AddWithValue("@Id", Poco.Id);
					cmd.Parameters.AddWithValue("@Job", Poco.Job);
					cmd.Parameters.AddWithValue("@Major", Poco.Major);
					cmd.Parameters.AddWithValue("@Importance", Poco.Importance);
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}

		}
	}
}
