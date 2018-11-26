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
	public class ApplicantWorkHistoryRepository : BaseADO, IDataRepository<ApplicantWorkHistoryPoco>
	{
		public void Add(params ApplicantWorkHistoryPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (ApplicantWorkHistoryPoco poco in items)
				{
					cmd.CommandText = @"INSERT INTO dbo.Applicant_Work_History
										(Id, Applicant, Company_Name, Country_Code, Location, Job_Title,
										Job_Description, Start_Month, Start_Year, End_Month, End_Year)
										VALUES
										(@Id, @Applicant, @CompanyName, @Country, @Location, @JobTitle,
										@JobDesc, @StartMonth, @StartYear, @EndMonth, @EndYear)";
					cmd.Parameters.AddWithValue("@Id", poco.Id);
					cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
					cmd.Parameters.AddWithValue("@CompanyName", poco.CompanyName);
					cmd.Parameters.AddWithValue("@Country", poco.CountryCode);
					cmd.Parameters.AddWithValue("@Location", poco.Location);
					cmd.Parameters.AddWithValue("@JobTitle", poco.JobTitle);
					cmd.Parameters.AddWithValue("@JobDesc", poco.JobDescription);
					cmd.Parameters.AddWithValue("@StartMonth", poco.StartMonth);
					cmd.Parameters.AddWithValue("@StartYear", poco.StartYear);
					cmd.Parameters.AddWithValue("@EndMonth", poco.EndMonth);
					cmd.Parameters.AddWithValue("@EndYear", poco.EndYear);
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

		public IList<ApplicantWorkHistoryPoco> GetAll(params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
		{
			ApplicantWorkHistoryPoco[] pocos = new ApplicantWorkHistoryPoco[500];
			int position = 0;
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandText = @"Select * from Applicant_Work_History";
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					ApplicantWorkHistoryPoco poco = new ApplicantWorkHistoryPoco();
					poco.Id = reader.GetGuid(0);
					poco.Applicant = reader.GetGuid(1);
					poco.CompanyName = reader.GetString(2);
					poco.CountryCode = reader.GetString(3);
					poco.Location = reader.GetString(4);
					poco.JobTitle = reader.GetString(5);
					poco.JobDescription = reader.GetString(6);
					poco.StartMonth = (short)reader[7];
					poco.StartYear = (int)reader[8];
					poco.EndMonth = (short)reader[9];
					poco.EndYear = (int)reader[10];
					poco.TimeStamp = (byte[])reader[11];
					pocos[position] = poco;
					position++;
				}
				conn.Close();
			}
			return pocos.Where(a => a != null).ToList();
		}

		public IList<ApplicantWorkHistoryPoco> GetList(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public ApplicantWorkHistoryPoco GetSingle(Expression<Func<ApplicantWorkHistoryPoco, bool>> where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
		{
			IQueryable<ApplicantWorkHistoryPoco> pocos = GetAll().AsQueryable();
			return pocos.Where(where).FirstOrDefault();
		}

		public void Remove(params ApplicantWorkHistoryPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (ApplicantWorkHistoryPoco poco in items)
				{
					cmd.CommandText = @"DELETE FROM dbo.Applicant_Work_History WHERE Id = @Id";
					cmd.Parameters.AddWithValue("@Id", poco.Id);
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}

		public void Update(params ApplicantWorkHistoryPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (ApplicantWorkHistoryPoco poco in items)
				{
					cmd.CommandText = @"UPDATE dbo.Applicant_Work_History SET
										Applicant = @Applicant,
										Company_Name = @CompanyName,
										Country_Code = @CountryCode,
										Location = @Location,
										Job_Title = @JobTitle,
										Job_Description = @JobDesc,
										Start_Month = @StartMonth,
										Start_Year = @StartYear,
										End_Month = @EndMonth,
										End_Year = @EndYear
										WHERE Id = @Id";

					cmd.Parameters.AddWithValue("@Id", poco.Id);
					cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
					cmd.Parameters.AddWithValue("@CompanyName", poco.CompanyName);
					cmd.Parameters.AddWithValue("@CountryCode", poco.CountryCode);
					cmd.Parameters.AddWithValue("@Location", poco.Location);
					cmd.Parameters.AddWithValue("@JobTitle", poco.JobTitle);
					cmd.Parameters.AddWithValue("@JobDesc", poco.JobDescription);
					cmd.Parameters.AddWithValue("@StartMonth", poco.StartMonth);
					cmd.Parameters.AddWithValue("@StartYear", poco.StartYear);
					cmd.Parameters.AddWithValue("@EndMonth", poco.EndMonth);
					cmd.Parameters.AddWithValue("@EndYear", poco.EndYear);
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}
	}
}
