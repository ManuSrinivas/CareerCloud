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
	public class ApplicantProfileRepository : BaseADO, IDataRepository<ApplicantProfilePoco>
	{
		public void Add(params ApplicantProfilePoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (ApplicantProfilePoco poco in items)
				{
					cmd.CommandText = @"INSERT INTO dbo.Applicant_Profiles
								(Id, Login, Current_Salary, Current_Rate, Currency, Country_Code, 
								State_Province_Code, Street_Address, City_Town, Zip_Postal_Code)
								VALUES
								(@Id, @Login, @CurrSal, @CurrRate, @Currency, @CountryCode
								, @State, @Street, @City, @Zip)";
					cmd.Parameters.AddWithValue("@Id", poco.Id);
					cmd.Parameters.AddWithValue("@Login", poco.Login);
					cmd.Parameters.AddWithValue("@CurrSal", poco.CurrentSalary);
					cmd.Parameters.AddWithValue("@CurrRate", poco.CurrentRate);
					cmd.Parameters.AddWithValue("@Currency", poco.Currency);
					cmd.Parameters.AddWithValue("@CountryCode", poco.Country);
					cmd.Parameters.AddWithValue("@State", poco.Province);
					cmd.Parameters.AddWithValue("@Street", poco.Street);
					cmd.Parameters.AddWithValue("@City", poco.City);
					cmd.Parameters.AddWithValue("@Zip", poco.PostalCode);
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

		public IList<ApplicantProfilePoco> GetAll(params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
		{
			ApplicantProfilePoco[] pocos = new ApplicantProfilePoco[1000];
			int position = 0;
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				cmd.CommandText = @"Select * from dbo.Applicant_Profiles";
				conn.Open();
				SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					ApplicantProfilePoco poco = new ApplicantProfilePoco();
					poco.Id = reader.GetGuid(0);
					poco.Login = reader.GetGuid(1);
					if (!reader.IsDBNull(2))
					{
						poco.CurrentSalary = reader.GetDecimal(2);
					}
					else
					{
						poco.CurrentSalary = null;
					}
					if (!reader.IsDBNull(3))
					{
						poco.CurrentRate = reader.GetDecimal(3);
					}
					else
					{
						poco.CurrentRate = null;
					}
					if (!reader.IsDBNull(4))
					{
						poco.Currency = (string)reader[4];
					}
					else
					{
						poco.Currency = null;
					}
					if (!reader.IsDBNull(5))
					{
						poco.Country = reader.GetString(5);
					}
					else
					{
						poco.Country = null;
					}
					if (!reader.IsDBNull(6))
					{
						poco.Province = reader.GetString(6);
					}
					else
					{
						poco.Province = null;
					}
					if (!reader.IsDBNull(7))
					{
						poco.Street = reader.GetString(7);
					}
					else
					{
						poco.Street = null;
					}
					if (!reader.IsDBNull(8))
					{
						poco.City = reader.GetString(8);
					}
					else
					{
						poco.City = null;
					}
					if (!reader.IsDBNull(9))
					{
						poco.PostalCode = reader.GetString(9);
					}
					else
					{
						poco.PostalCode = null;
					}
					poco.TimeStamp = (byte[])reader["Time_Stamp"];
					pocos[position] = poco;
					position++;
				}
				conn.Close();
			}
			return pocos.Where(a => a != null).ToList();
		}

		public IList<ApplicantProfilePoco> GetList(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
		{
			throw new NotImplementedException();
		}

		public ApplicantProfilePoco GetSingle(Expression<Func<ApplicantProfilePoco, bool>> where, params Expression<Func<ApplicantProfilePoco, object>>[] navigationProperties)
		{
			IQueryable<ApplicantProfilePoco> pocos = GetAll().AsQueryable();
			return pocos.Where(where).FirstOrDefault();
		}

		public void Remove(params ApplicantProfilePoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (ApplicantProfilePoco poco in items)
				{
					cmd.CommandText = @"Delete from dbo.Applicant_Profiles where Id = @Id";
					cmd.Parameters.AddWithValue("@Id", poco.Id);
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}

		public void Update(params ApplicantProfilePoco[] items)
		{
			using (SqlConnection conn = new SqlConnection(connString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = conn;
				foreach (ApplicantProfilePoco poco in items)
				{
					cmd.CommandText = @"UPDATE dbo.Applicant_Profiles SET
										Login = @Login,
										Current_Salary = @CurrSal,
										Current_Rate = @CurrRate,
										Currency = @Curr,
										Country_Code = @Country,
										State_Province_Code = @State,
										Street_Address = @Street,
										City_Town = @City,
										Zip_Postal_Code = @Postal
										where Id = @Id";
					cmd.Parameters.AddWithValue("@Id", poco.Id);
					cmd.Parameters.AddWithValue("@Login", poco.Login);
					cmd.Parameters.AddWithValue("@CurrSal", poco.CurrentSalary);
					cmd.Parameters.AddWithValue("@CurrRate", poco.CurrentRate);
					cmd.Parameters.AddWithValue("@Curr", poco.Currency);
					cmd.Parameters.AddWithValue("@Country", poco.Country);
					cmd.Parameters.AddWithValue("@State", poco.Province);
					cmd.Parameters.AddWithValue("@Street", poco.Street);
					cmd.Parameters.AddWithValue("@City", poco.City);
					cmd.Parameters.AddWithValue("@Postal", poco.PostalCode);
					conn.Open();
					cmd.ExecuteNonQuery();
					conn.Close();
				}
			}
		}
	}
}
