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
	public class ApplicantResumeRepository : BaseADO, IDataRepository<ApplicantResumePoco>
	{
		public void Add(params ApplicantResumePoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (ApplicantResumePoco poco in items)
				{
					cmd.CommandText = @"INSERT INTO dbo.Applicant_Resumes
										(Id, Applicant, Resume, Last_Updated)
										VALUES
										(@Id, @Applicant, @Resume, @LastUpdated)";
					cmd.Parameters.AddWithValue("@Id", poco.Id);
					cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
					cmd.Parameters.AddWithValue("@Resume", poco.Resume);
					cmd.Parameters.AddWithValue("@LastUpdated", poco.LastUpdated);
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

		public IList<ApplicantResumePoco> GetAll(params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
		{
			ApplicantResumePoco[] pocos = new ApplicantResumePoco[1000];
			int position = 0;
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandText = @"Select * From Applicant_Resumes";
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					ApplicantResumePoco poco = new ApplicantResumePoco();
					poco.Id = reader.GetGuid(0);
					poco.Applicant = reader.GetGuid(1);
					poco.Resume = reader.GetString(2);
					if (!reader.IsDBNull(3))
					{
						poco.LastUpdated = reader.GetDateTime(3);
					}
					else
					{
						poco.LastUpdated = null;
					}
					pocos[position] = poco;
					position++;
				}
				conn.Close();
			}
			return pocos.Where(a => a != null).ToList();
		}

		public IList<ApplicantResumePoco> GetList(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public ApplicantResumePoco GetSingle(Expression<Func<ApplicantResumePoco, bool>> where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
		{
			IQueryable<ApplicantResumePoco> pocos = GetAll().AsQueryable();
			return pocos.Where(where).FirstOrDefault();
		}

		public void Remove(params ApplicantResumePoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (ApplicantResumePoco poco in items)
				{
					cmd.CommandText = @"DELETE FROM Applicant_Resumes WHERE Id = @Id";
					cmd.Parameters.AddWithValue("@Id", poco.Id);
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}			
			}
		}

		public void Update(params ApplicantResumePoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (ApplicantResumePoco poco in items)
				{
					cmd.CommandText = @"UPDATE dbo.Applicant_Resumes SET
									Applicant = @Applicant,
									Resume = @Resume,
									Last_Updated = @LastUpdated
									WHERE Id = @Id";
					cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
					cmd.Parameters.AddWithValue("@Resume", poco.Resume);
					cmd.Parameters.AddWithValue("LastUpdated", poco.LastUpdated);
					cmd.Parameters.AddWithValue("@Id", poco.Id);
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}
	}
}
