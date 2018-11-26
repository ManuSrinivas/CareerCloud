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
	public class SystemLanguageCodeRepository : BaseADO, IDataRepository<SystemLanguageCodePoco>
	{
		public void Add(params SystemLanguageCodePoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (SystemLanguageCodePoco poco in items)
				{
					cmd.CommandText = @"INSERT INTO dbo.System_Language_Codes (LanguageId, Name, Native_Name) VALUES (@LanguageId, @Name, @NativeName)";
					cmd.Parameters.AddWithValue("@LanguageId", poco.LanguageID);
					cmd.Parameters.AddWithValue("@Name", poco.Name);
					cmd.Parameters.AddWithValue("@NativeName", poco.NativeName);
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

		public IList<SystemLanguageCodePoco> GetAll(params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
		{
			SystemLanguageCodePoco[] pocos = new SystemLanguageCodePoco[5];
			int position = 0;
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandText = @"Select * from dbo.System_Language_Codes";
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					SystemLanguageCodePoco poco = new SystemLanguageCodePoco();
					poco.LanguageID = reader.GetString(0);
					poco.Name = reader.GetString(1);
					poco.NativeName = reader.GetString(2);

					pocos[position] = poco;
					position++;
				}
				conn.Close();
			}
			return pocos.Where(a => a != null).ToList();
		}

		public IList<SystemLanguageCodePoco> GetList(Expression<Func<SystemLanguageCodePoco, bool>> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public SystemLanguageCodePoco GetSingle(Expression<Func<SystemLanguageCodePoco, bool>> where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
		{
			IQueryable<SystemLanguageCodePoco> pocos = GetAll().AsQueryable();
			return pocos.Where(where).FirstOrDefault();
		}

		public void Remove(params SystemLanguageCodePoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (SystemLanguageCodePoco poco in items)
				{
					cmd.CommandText = @"DELETE FROM dbo.System_Language_Codes WHERE LanguageID = @LangId";
					cmd.Parameters.AddWithValue("@LangId", poco.LanguageID);
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}

		public void Update(params SystemLanguageCodePoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (SystemLanguageCodePoco poco in items)
				{
					cmd.CommandText = @"UPDATE dbo.System_Language_Codes SET Name = @Name, Native_Name = @NativeName WHERE LanguageID = @LangId";
					cmd.Parameters.AddWithValue("@LangId", poco.LanguageID);
					cmd.Parameters.AddWithValue("@Name", poco.Name);
					cmd.Parameters.AddWithValue("@NativeName", poco.NativeName);
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}
	}
}
