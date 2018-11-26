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
	public class CompanyJobSkillRepository : BaseADO, IDataRepository<CompanyJobSkillPoco>
	{
		public void Add(params CompanyJobSkillPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (CompanyJobSkillPoco poco in items)
				{
					cmd.CommandText = @"INSERT INTO dbo.Company_Job_Skills
										(Id, Job, Skill, Skill_Level, Importance)
										VALUES
										(@Id, @Job, @Skill, @SkillLevel, @Importance)";

					cmd.Parameters.AddWithValue("@Id", poco.Id);
					cmd.Parameters.AddWithValue("@Job", poco.Job);
					cmd.Parameters.AddWithValue("@Skill", poco.Skill);
					cmd.Parameters.AddWithValue("@SkillLevel", poco.SkillLevel);
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

		public IList<CompanyJobSkillPoco> GetAll(params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
		{
			CompanyJobSkillPoco[] pocos = new CompanyJobSkillPoco[5100];
			int position = 0;
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandText = @"Select * From dbo.Company_Job_Skills";
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					CompanyJobSkillPoco poco = new CompanyJobSkillPoco();
					poco.Id = reader.GetGuid(0);
					poco.Job = reader.GetGuid(1);
					poco.Skill = reader.GetString(2);
					poco.SkillLevel = reader.GetString(3);
					poco.Importance = (int)reader[4];
					poco.TimeStamp = (byte[])reader[5];

					pocos[position] = poco;
					position++;
				}
				conn.Close();
			}
			return pocos.Where(a => a != null).ToList();
		}

		public IList<CompanyJobSkillPoco> GetList(Expression<Func<CompanyJobSkillPoco, bool>> where, params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public CompanyJobSkillPoco GetSingle(Expression<Func<CompanyJobSkillPoco, bool>> where, params Expression<Func<CompanyJobSkillPoco, object>>[] navigationProperties)
		{
			IQueryable<CompanyJobSkillPoco> pocos = GetAll().AsQueryable();
			return pocos.Where(where).FirstOrDefault();
		}

		public void Remove(params CompanyJobSkillPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (CompanyJobSkillPoco poco in items)
				{
					cmd.CommandText = @"DELETE FROM dbo.Company_Job_Skills WHERE Id = @Id";
					cmd.Parameters.AddWithValue("@Id", poco.Id);
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}

		public void Update(params CompanyJobSkillPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (CompanyJobSkillPoco poco in items)
				{
					cmd.CommandText = @"UPDATE dbo.Company_Job_Skills SET
										Job = @Job,
										Skill = @Skill,
										Skill_Level = @SkillLevel,
										Importance = @Importance
										WHERE Id = @Id";

					cmd.Parameters.AddWithValue("@Id", poco.Id);
					cmd.Parameters.AddWithValue("@Skill", poco.Skill);
					cmd.Parameters.AddWithValue("@SkillLevel", poco.SkillLevel);
					cmd.Parameters.AddWithValue("@Importance", poco.Importance);
					cmd.Parameters.AddWithValue("@Job", poco.Job);

					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}
	}
}
