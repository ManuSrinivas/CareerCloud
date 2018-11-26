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
	public class CompanyJobDescriptionRepository : BaseADO, IDataRepository<CompanyJobDescriptionPoco>
	{
		public void Add(params CompanyJobDescriptionPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (CompanyJobDescriptionPoco poco in items)
				{
					cmd.CommandText = @"INSERT INTO dbo.Company_Jobs_Descriptions
										(Id, Job, Job_Name, Job_Descriptions)
										VALUES
										(@Id, @Job, @JobName, @JobDesc)";

					cmd.Parameters.AddWithValue("@Id", poco.Id);
					cmd.Parameters.AddWithValue("@Job", poco.Job);
					cmd.Parameters.AddWithValue("@JobName", poco.JobName);
					cmd.Parameters.AddWithValue("@JobDesc", poco.JobDescriptions);

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

		public IList<CompanyJobDescriptionPoco> GetAll(params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
		{
			CompanyJobDescriptionPoco[] pocos = new CompanyJobDescriptionPoco[1500];
			int position = 0;
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandText = @"Select * from Company_Jobs_Descriptions";
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					CompanyJobDescriptionPoco poco = new CompanyJobDescriptionPoco();
					poco.Id = reader.GetGuid(0);
					poco.Job = reader.GetGuid(1);
					if (!reader.IsDBNull(2))
					{
						poco.JobName = reader.GetString(2);
					}
					else
					{
						poco.JobName = null;
					}
					if (!reader.IsDBNull(3))
					{
						poco.JobDescriptions = reader.GetString(3);
					}
					else
					{
						poco.JobDescriptions = null;
					}
					if (!reader.IsDBNull(4))
					{
						poco.TimeStamp = (byte[])reader[4];
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

		public IList<CompanyJobDescriptionPoco> GetList(Expression<Func<CompanyJobDescriptionPoco, bool>> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public CompanyJobDescriptionPoco GetSingle(Expression<Func<CompanyJobDescriptionPoco, bool>> where, params Expression<Func<CompanyJobDescriptionPoco, object>>[] navigationProperties)
		{
			IQueryable<CompanyJobDescriptionPoco> pocos = GetAll().AsQueryable();
			return pocos.Where(where).FirstOrDefault();
		}

		public void Remove(params CompanyJobDescriptionPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (CompanyJobDescriptionPoco poco in items)
				{
					cmd.CommandText = @"DELETE FROM dbo.Company_Jobs_Descriptions WHERE Id = @Id";

					cmd.Parameters.AddWithValue("@Id", poco.Id);
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}

		public void Update(params CompanyJobDescriptionPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (CompanyJobDescriptionPoco poco in items)
				{
					cmd.CommandText = @"UPDATE dbo.Company_Jobs_Descriptions SET
										Job = @Job,
										Job_Name = @JobName,
										Job_Descriptions = @JobDesc
										WHERE Id = @Id";

					cmd.Parameters.AddWithValue("@Id", poco.Id);
					cmd.Parameters.AddWithValue("@Job", poco.Job);
					cmd.Parameters.AddWithValue("@JobName", poco.JobName);
					cmd.Parameters.AddWithValue("@JobDesc", poco.JobDescriptions);
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}
	}
}
