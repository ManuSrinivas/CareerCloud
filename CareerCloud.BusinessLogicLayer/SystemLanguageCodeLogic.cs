using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.BusinessLogicLayer
{
	public class SystemLanguageCodeLogic
	{
		public IDataRepository<SystemLanguageCodePoco> repository { get; set; }
		public SystemLanguageCodeLogic(IDataRepository<SystemLanguageCodePoco> repository)
		{
			this.repository = repository;
		}

		public SystemLanguageCodePoco Get(string LanguageID)
		{
			return repository.GetSingle(c => c.LanguageID == LanguageID);
		}

		public List<SystemLanguageCodePoco> GetAll()
		{
			return repository.GetAll().ToList();
		}

		public void Delete(SystemLanguageCodePoco[] pocos)
		{
			repository.Remove(pocos);
		}

		public void Add(SystemLanguageCodePoco[] pocos)
		{
			Verify(pocos);
			repository.Add(pocos);
		}

		public void Update(SystemLanguageCodePoco[] pocos)
		{
			Verify(pocos);
			repository.Update(pocos);
		}

		protected void Verify(SystemLanguageCodePoco[] pocos)
		{
			List<ValidationException> exceptions = new List<ValidationException>();

			foreach (SystemLanguageCodePoco poco in pocos)
			{
				if (string.IsNullOrEmpty(poco.LanguageID))
				{
					exceptions.Add(new ValidationException(1000, $"System Language Id can't be empty"));
				}

				if (string.IsNullOrEmpty(poco.Name))
				{
					exceptions.Add(new ValidationException(1001, $"System language code Name can't be empty"));
				}

				if (string.IsNullOrEmpty(poco.NativeName))
				{
					exceptions.Add(new ValidationException(1002, $"System Language code Native name can't be empty"));
				}
			}

			if (exceptions.Count > 0)
			{
				throw new AggregateException(exceptions);
			}
		}
	}
}
