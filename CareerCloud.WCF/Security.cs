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
	class Security : ISecurity
	{
		public void AddSecurityLogin(SecurityLoginPoco[] items)
		{
			EFGenericRepository<SecurityLoginPoco> SecurityLoginRepo = new EFGenericRepository<SecurityLoginPoco>(false);
			var Logic = new SecurityLoginLogic(SecurityLoginRepo);
			Logic.Add(items);
		}

		public void AddSecurityLoginsLog(SecurityLoginsLogPoco[] items)
		{
			EFGenericRepository<SecurityLoginsLogPoco> SecurityLoginsLogRepo = new EFGenericRepository<SecurityLoginsLogPoco>(false);
			var Logic = new SecurityLoginsLogLogic(SecurityLoginsLogRepo);
			Logic.Add(items);
		}

		public void AddSecurityLoginsRole(SecurityLoginsRolePoco[] items)
		{
			EFGenericRepository<SecurityLoginsRolePoco> SecurityLoginsRoleRepo = new EFGenericRepository<SecurityLoginsRolePoco>(false);
			var Logic = new SecurityLoginsRoleLogic(SecurityLoginsRoleRepo);
			Logic.Add(items);
		}

		public void AddSecurityRole(SecurityRolePoco[] items)
		{
			EFGenericRepository<SecurityRolePoco> SecurityRoleRepo = new EFGenericRepository<SecurityRolePoco>(false);
			var Logic = new SecurityRoleLogic(SecurityRoleRepo);
			Logic.Add(items);
		}

		public List<SecurityLoginPoco> GetAllSecurityLogin()
		{
			EFGenericRepository<SecurityLoginPoco> SecurityLoginRepo = new EFGenericRepository<SecurityLoginPoco>(false);
			var Logic = new SecurityLoginLogic(SecurityLoginRepo);
			return Logic.GetAll();
		}

		public List<SecurityLoginsLogPoco> GetAllSecurityLoginsLog()
		{
			EFGenericRepository<SecurityLoginsLogPoco> SecurityLoginsLogRepo = new EFGenericRepository<SecurityLoginsLogPoco>(false);
			var Logic = new SecurityLoginsLogLogic(SecurityLoginsLogRepo);
			return Logic.GetAll();
		}

		public List<SecurityLoginsRolePoco> GetAllSecurityLoginsRole()
		{
			EFGenericRepository<SecurityLoginsRolePoco> SecurityLoginsRoleRepo = new EFGenericRepository<SecurityLoginsRolePoco>(false);
			var Logic = new SecurityLoginsRoleLogic(SecurityLoginsRoleRepo);
			return Logic.GetAll();
		}

		public List<SecurityRolePoco> GetAllSecurityRole()
		{
			EFGenericRepository<SecurityRolePoco> SecurityRoleRepo = new EFGenericRepository<SecurityRolePoco>(false);
			var Logic = new SecurityRoleLogic(SecurityRoleRepo);
			return Logic.GetAll();
		}

		public SecurityLoginPoco GetSingleSecurityLogin(string Id)
		{
			EFGenericRepository<SecurityLoginPoco> SecurityLoginRepo = new EFGenericRepository<SecurityLoginPoco>(false);
			var Logic = new SecurityLoginLogic(SecurityLoginRepo);
			return Logic.Get(Guid.Parse(Id));
		}

		public SecurityLoginsLogPoco GetSingleSecurityLoginsLog(string Id)
		{
			EFGenericRepository<SecurityLoginsLogPoco> SecurityLoginsLogRepo = new EFGenericRepository<SecurityLoginsLogPoco>(false);
			var Logic = new SecurityLoginsLogLogic(SecurityLoginsLogRepo);
			return Logic.Get(Guid.Parse(Id));
		}

		public SecurityLoginsRolePoco GetSingleSecurityLoginsRole(string Id)
		{
			EFGenericRepository<SecurityLoginsRolePoco> SecurityLoginsRoleRepo = new EFGenericRepository<SecurityLoginsRolePoco>(false);
			var Logic = new SecurityLoginsRoleLogic(SecurityLoginsRoleRepo);
			return Logic.Get(Guid.Parse(Id));
		}

		public SecurityRolePoco GetSingleSecurityRole(string Id)
		{
			EFGenericRepository<SecurityRolePoco> SecurityRoleRepo = new EFGenericRepository<SecurityRolePoco>(false);
			var Logic = new SecurityRoleLogic(SecurityRoleRepo);
			return Logic.Get(Guid.Parse(Id));
		}

		public void RemoveSecurityLogin(SecurityLoginPoco[] items)
		{
			EFGenericRepository<SecurityLoginPoco> SecurityLoginRepo = new EFGenericRepository<SecurityLoginPoco>(false);
			var Logic = new SecurityLoginLogic(SecurityLoginRepo);
			Logic.Delete(items);
		}

		public void RemoveSecurityLoginsLog(SecurityLoginsLogPoco[] items)
		{
			EFGenericRepository<SecurityLoginsLogPoco> SecurityLoginsLogRepo = new EFGenericRepository<SecurityLoginsLogPoco>(false);
			var Logic = new SecurityLoginsLogLogic(SecurityLoginsLogRepo);
			Logic.Delete(items);
		}

		public void RemoveSecurityLoginsRole(SecurityLoginsRolePoco[] items)
		{
			EFGenericRepository<SecurityLoginsRolePoco> SecurityLoginsRoleRepo = new EFGenericRepository<SecurityLoginsRolePoco>(false);
			var Logic = new SecurityLoginsRoleLogic(SecurityLoginsRoleRepo);
			Logic.Delete(items);
		}

		public void RemoveSecurityRole(SecurityRolePoco[] items)
		{
			EFGenericRepository<SecurityRolePoco> SecurityRoleRepo = new EFGenericRepository<SecurityRolePoco>(false);
			var Logic = new SecurityRoleLogic(SecurityRoleRepo);
			Logic.Delete(items);
		}

		public void UpdateSecurityLogin(SecurityLoginPoco[] items)
		{
			EFGenericRepository<SecurityLoginPoco> SecurityLoginRepo = new EFGenericRepository<SecurityLoginPoco>(false);
			var Logic = new SecurityLoginLogic(SecurityLoginRepo);
			Logic.Update(items);
		}

		public void UpdateSecurityLoginsLog(SecurityLoginsLogPoco[] items)
		{
			EFGenericRepository<SecurityLoginsLogPoco> SecurityLoginsLogRepo = new EFGenericRepository<SecurityLoginsLogPoco>(false);
			var Logic = new SecurityLoginsLogLogic(SecurityLoginsLogRepo);
			Logic.Update(items);
		}

		public void UpdateSecurityLoginsRole(SecurityLoginsRolePoco[] items)
		{
			EFGenericRepository<SecurityLoginsRolePoco> SecurityLoginsRoleRepo = new EFGenericRepository<SecurityLoginsRolePoco>(false);
			var Logic = new SecurityLoginsRoleLogic(SecurityLoginsRoleRepo);
			Logic.Update(items);
		}

		public void UpdateSecurityRole(SecurityRolePoco[] items)
		{
			EFGenericRepository<SecurityRolePoco> SecurityRoleRepo = new EFGenericRepository<SecurityRolePoco>(false);
			var Logic = new SecurityRoleLogic(SecurityRoleRepo);
			Logic.Update(items);
		}
	}
}
