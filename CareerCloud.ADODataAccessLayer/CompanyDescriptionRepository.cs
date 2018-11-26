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
	public class CompanyDescriptionRepository : BaseADO, IDataRepository<CompanyDescriptionPoco>
	{
		public void Add(params CompanyDescriptionPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (CompanyDescriptionPoco poco in items)
				{
					cmd.CommandText = @"INSERT INTO dbo.Company_Descriptions
										(Id, Company, LanguageId, Company_Name, Company_Description)
										VALUES
										(@Id, @Company, @LangId, @CompanyName, @CompanyDesc)";
					cmd.Parameters.AddWithValue("@Id", poco.Id);
					cmd.Parameters.AddWithValue("@Company", poco.Company);
					cmd.Parameters.AddWithValue("@LangId", poco.LanguageId);
					cmd.Parameters.AddWithValue("@CompanyName", poco.CompanyName);
					cmd.Parameters.AddWithValue("@CompanyDesc", poco.CompanyDescription);
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

		public IList<CompanyDescriptionPoco> GetAll(params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
		{
			CompanyDescriptionPoco[] pocos = new CompanyDescriptionPoco[1000];
			int position = 0;
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandText = @"Select * From Company_Descriptions";
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					CompanyDescriptionPoco poco = new CompanyDescriptionPoco();
					poco.Id = reader.GetGuid(0);
					poco.Company = reader.GetGuid(1);
					poco.LanguageId = reader.GetString(2);
					poco.CompanyName = reader.GetString(3);
					poco.CompanyDescription = reader.GetString(4);
					poco.TimeStamp = (byte[])reader[5];

					pocos[position] = poco;
					position++;
				}
				conn.Close();
			}
			return pocos.Where(a => a != null).ToList();
		}

		public IList<CompanyDescriptionPoco> GetList(Expression<Func<CompanyDescriptionPoco, bool>> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public CompanyDescriptionPoco GetSingle(Expression<Func<CompanyDescriptionPoco, bool>> where, params Expression<Func<CompanyDescriptionPoco, object>>[] navigationProperties)
		{
			IQueryable<CompanyDescriptionPoco> pocos = GetAll().AsQueryable();
			return pocos.Where(where).FirstOrDefault();
		}

		public void Remove(params CompanyDescriptionPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (CompanyDescriptionPoco poco in items)
				{
					cmd.CommandText = @"DELETE FROM dbo.Company_Descriptions WHERE Id = @Id";
					cmd.Parameters.AddWithValue("@Id", poco.Id);
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}

		public void Update(params CompanyDescriptionPoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (CompanyDescriptionPoco poco in items)
				{
					cmd.CommandText = @"UPDATE dbo.Company_Descriptions SET
										Company = @Company,
										LanguageId = @LangId,
										Company_Name = @CompanyName,
										Company_Description = @CompanyDesc
										WHERE Id = @Id";
					cmd.Parameters.AddWithValue("@Id", poco.Id);
					cmd.Parameters.AddWithValue("@Company", poco.Company);
					cmd.Parameters.AddWithValue("@CompanyName", poco.CompanyName);
					cmd.Parameters.AddWithValue("@CompanyDesc", poco.CompanyDescription);
					cmd.Parameters.AddWithValue("@LangId", poco.LanguageId);
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}
	}
}
