using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.ADODataAccessLayer
{
	public class ApplicantJobApplicationRepository : BaseADO, IDataRepository<ApplicantJobApplicationPoco>
	{
		public void Add(params ApplicantJobApplicationPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (ApplicantJobApplicationPoco poco in items)
				{
					cmd.CommandText = @"INSERT INTO dbo.Applicant_Job_Applications
								   (Id, Applicant, Job, Application_Date)
								   VALUES (@Id, @Applicant, @Job, @Application_Date);";
					cmd.Parameters.AddWithValue("@Id", poco.Id);
					cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
					cmd.Parameters.AddWithValue("@Job", poco.Job);
					cmd.Parameters.AddWithValue("@Application_Date", poco.ApplicationDate);
				}
				conn.Open();
				cmd.ExecuteNonQuery();
				conn.Close();
			}
		}

		public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
		{
			throw new NotImplementedException();
		}

		public IList<ApplicantJobApplicationPoco> GetAll(params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
		{
			ApplicantJobApplicationPoco[] pocos = new ApplicantJobApplicationPoco[1000];
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand("Select * from dbo.Applicant_Job_Applications", conn);
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				int position = 0;
				while (reader.Read())
				{
					ApplicantJobApplicationPoco poco = new ApplicantJobApplicationPoco();
					poco.Id = reader.GetGuid(0);
					poco.Applicant = reader.GetGuid(1);
					poco.Job = reader.GetGuid(2);
					poco.ApplicationDate = reader.GetDateTime(3);
					poco.TimeStamp = (byte[])reader["Time_Stamp"];
					pocos[position] = poco;
					position++;
				}
				conn.Close();
			}
			return pocos.Where(a => a != null).ToList();
		}

		public IList<ApplicantJobApplicationPoco> GetList(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public ApplicantJobApplicationPoco GetSingle(Expression<Func<ApplicantJobApplicationPoco, bool>> where, params Expression<Func<ApplicantJobApplicationPoco, object>>[] navigationProperties)
		{
			IQueryable<ApplicantJobApplicationPoco> pocos = GetAll().AsQueryable();
			return pocos.Where(where).FirstOrDefault();
		}

		public void Remove(params ApplicantJobApplicationPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (ApplicantJobApplicationPoco poco in items)
				{
					cmd.CommandText = @"Delete from Applicant_Job_Applications where Id = @Id";
					cmd.Parameters.AddWithValue("@Id", poco.Id);
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}

		public void Update(params ApplicantJobApplicationPoco[] items)
		{
			using(SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (ApplicantJobApplicationPoco poco in items)
				{
					cmd.CommandText = @"UPDATE Applicant_Job_Applications SET
										Applicant = @Applicant,
										Job = @Job,
										Application_Date = @Application_Date
										WHERE Id = @Id;";
					cmd.Parameters.AddWithValue("@Id", poco.Id);
					cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
					cmd.Parameters.AddWithValue("@Job", poco.Job);
					cmd.Parameters.AddWithValue("@Application_Date", poco.ApplicationDate);
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}
	}
}
