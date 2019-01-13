using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
	public class SystemCountryCodeLogic 
	{
		public IDataRepository<SystemCountryCodePoco> repository { get; set; }
		public SystemCountryCodeLogic(IDataRepository<SystemCountryCodePoco> repository)
		{
			this.repository = repository;
		}

		public SystemCountryCodePoco Get(string code)
		{
			return repository.GetSingle(c => c.Code == code);
		}

		public List<SystemCountryCodePoco> GetAll()
		{
			return repository.GetAll().ToList();
		}

		public void Delete(SystemCountryCodePoco[] pocos)
		{
			repository.Remove(pocos);
		}

		public void Add(SystemCountryCodePoco[] pocos)
		{
			Verify(pocos);
			repository.Add(pocos);
		}

		public void Update(SystemCountryCodePoco[] pocos)
		{
			Verify(pocos);
			repository.Update(pocos);
		}

		protected void Verify(SystemCountryCodePoco[] pocos)
		{
			List<ValidationException> exceptions = new List<ValidationException>();

			foreach (SystemCountryCodePoco poco in pocos)
			{
				if (string.IsNullOrEmpty(poco.Code))
				{
					exceptions.Add(new ValidationException(900, $"System country Code can't be empty"));
				}

				if (string.IsNullOrEmpty(poco.Name))
				{
					exceptions.Add(new ValidationException(901, $"System country Name can't be empty"));
				}
			}

			if (exceptions.Count > 0)
			{
				throw new AggregateException(exceptions);
			}
		}
	}
}
