using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.WCF
{
	class System : ISystem
	{
		public void AddSystemCountryCode(SystemCountryCodePoco[] items)
		{
			EFGenericRepository<SystemCountryCodePoco> SystemCountryCodeRepo = new EFGenericRepository<SystemCountryCodePoco>(false);
			var Logic = new SystemCountryCodeLogic(SystemCountryCodeRepo);
			Logic.Add(items);
		}

		public void AddSystemLanguageCode(SystemLanguageCodePoco[] items)
		{
			EFGenericRepository<SystemLanguageCodePoco> SystemLanguageCodeRepo = new EFGenericRepository<SystemLanguageCodePoco>(false);
			var Logic = new SystemLanguageCodeLogic(SystemLanguageCodeRepo);
			Logic.Add(items);
		}

		public List<SystemCountryCodePoco> GetAllSystemCountryCode()
		{
			EFGenericRepository<SystemCountryCodePoco> SystemCountryCodeRepo = new EFGenericRepository<SystemCountryCodePoco>(false);
			var Logic = new SystemCountryCodeLogic(SystemCountryCodeRepo);
			return Logic.GetAll();
		}

		public List<SystemLanguageCodePoco> GetAllSystemLanguageCode()
		{
			EFGenericRepository<SystemLanguageCodePoco> SystemLanguageCodeRepo = new EFGenericRepository<SystemLanguageCodePoco>(false);
			var Logic = new SystemLanguageCodeLogic(SystemLanguageCodeRepo);
			return Logic.GetAll();
		}

		public SystemCountryCodePoco GetSingleSystemCountryCode(string code)
		{
			EFGenericRepository<SystemCountryCodePoco> SystemCountryCodeRepo = new EFGenericRepository<SystemCountryCodePoco>(false);
			var Logic = new SystemCountryCodeLogic(SystemCountryCodeRepo);
			return Logic.Get(code);
		}

		public SystemLanguageCodePoco GetSingleSystemLanguageCode(string LanguageId)
		{
			EFGenericRepository<SystemLanguageCodePoco> SystemLanguageCodeRepo = new EFGenericRepository<SystemLanguageCodePoco>(false);
			var Logic = new SystemLanguageCodeLogic(SystemLanguageCodeRepo);
			return Logic.Get(LanguageId);
		}

		public void RemoveSystemCountryCode(SystemCountryCodePoco[] items)
		{
			EFGenericRepository<SystemCountryCodePoco> SystemCountryCodeRepo = new EFGenericRepository<SystemCountryCodePoco>(false);
			var Logic = new SystemCountryCodeLogic(SystemCountryCodeRepo);
			Logic.Delete(items);
		}

		public void RemoveSystemLanguageCode(SystemLanguageCodePoco[] items)
		{
			EFGenericRepository<SystemLanguageCodePoco> SystemLanguageCodeRepo = new EFGenericRepository<SystemLanguageCodePoco>(false);
			var Logic = new SystemLanguageCodeLogic(SystemLanguageCodeRepo);
			Logic.Delete(items);
		}

		public void UpdateSystemCountryCode(SystemCountryCodePoco[] items)
		{
			EFGenericRepository<SystemCountryCodePoco> SystemCountryCodeRepo = new EFGenericRepository<SystemCountryCodePoco>(false);
			var Logic = new SystemCountryCodeLogic(SystemCountryCodeRepo);
			Logic.Update(items);
		}

		public void UpdateSystemLanguageCode(SystemLanguageCodePoco[] items)
		{
			EFGenericRepository<SystemLanguageCodePoco> SystemLanguageCodeRepo = new EFGenericRepository<SystemLanguageCodePoco>(false);
			var Logic = new SystemLanguageCodeLogic(SystemLanguageCodeRepo);
			Logic.Update(items);
		}
	}
}
