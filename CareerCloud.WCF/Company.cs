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
	class Company : ICompany
	{
		public void AddCompanyDescription(CompanyDescriptionPoco[] items)
		{
			EFGenericRepository<CompanyDescriptionPoco> CompanyDescriptionRepo = new EFGenericRepository<CompanyDescriptionPoco>(false);
			var Logic = new CompanyDescriptionLogic(CompanyDescriptionRepo);
			Logic.Add(items);
		}

		public void AddCompanyJob(CompanyJobPoco[] items)
		{
			EFGenericRepository<CompanyJobPoco> CompanyJobRepo = new EFGenericRepository<CompanyJobPoco>(false);
			var Logic = new CompanyJobLogic(CompanyJobRepo);
			Logic.Add(items);
		}

		public void AddCompanyJobDescription(CompanyJobDescriptionPoco[] items)
		{
			EFGenericRepository<CompanyJobDescriptionPoco> CompanyJobDescriptionRepo = new EFGenericRepository<CompanyJobDescriptionPoco>(false);
			var Logic = new CompanyJobDescriptionLogic(CompanyJobDescriptionRepo);
			Logic.Add(items);
		}

		public void AddCompanyJobEducation(CompanyJobEducationPoco[] items)
		{
			EFGenericRepository<CompanyJobEducationPoco> CompanyJobEducationRepo = new EFGenericRepository<CompanyJobEducationPoco>(false);
			var Logic = new CompanyJobEducationLogic(CompanyJobEducationRepo);
			Logic.Add(items);
		}

		public void AddCompanyJobSkill(CompanyJobSkillPoco[] items)
		{
			EFGenericRepository<CompanyJobSkillPoco> CompanyJobSkillRepo = new EFGenericRepository<CompanyJobSkillPoco>(false);
			var Logic = new CompanyJobSkillLogic(CompanyJobSkillRepo);
			Logic.Add(items);
		}

		public void AddCompanyLocation(CompanyLocationPoco[] items)
		{
			EFGenericRepository<CompanyLocationPoco> CompanyLocationRepo = new EFGenericRepository<CompanyLocationPoco>(false);
			var Logic = new CompanyLocationLogic(CompanyLocationRepo);
			Logic.Add(items);
		}

		public void AddCompanyProfile(CompanyProfilePoco[] items)
		{
			EFGenericRepository<CompanyProfilePoco> CompanyProfileRepo = new EFGenericRepository<CompanyProfilePoco>(false);
			var Logic = new CompanyProfileLogic(CompanyProfileRepo);
			Logic.Add(items);
		}

		public List<CompanyDescriptionPoco> GetAllCompanyDescription()
		{
			EFGenericRepository<CompanyDescriptionPoco> CompanyDescriptionRepo = new EFGenericRepository<CompanyDescriptionPoco>(false);
			var Logic = new CompanyDescriptionLogic(CompanyDescriptionRepo);
			return Logic.GetAll();
		}

		public List<CompanyJobPoco> GetAllCompanyJob()
		{
			EFGenericRepository<CompanyJobPoco> CompanyJobRepo = new EFGenericRepository<CompanyJobPoco>(false);
			var Logic = new CompanyJobLogic(CompanyJobRepo);
			return Logic.GetAll();
		}

		public List<CompanyJobDescriptionPoco> GetAllCompanyJobDescription()
		{
			EFGenericRepository<CompanyJobDescriptionPoco> CompanyJobDescriptionRepo = new EFGenericRepository<CompanyJobDescriptionPoco>(false);
			var Logic = new CompanyJobDescriptionLogic(CompanyJobDescriptionRepo);
			return Logic.GetAll();
		}

		public List<CompanyJobEducationPoco> GetAllCompanyJobEducation()
		{
			EFGenericRepository<CompanyJobEducationPoco> CompanyJobEducationRepo = new EFGenericRepository<CompanyJobEducationPoco>(false);
			var Logic = new CompanyJobEducationLogic(CompanyJobEducationRepo);
			return Logic.GetAll();
		}

		public List<CompanyJobSkillPoco> GetAllCompanyJobSkill()
		{
			EFGenericRepository<CompanyJobSkillPoco> CompanyJobSkillRepo = new EFGenericRepository<CompanyJobSkillPoco>(false);
			var Logic = new CompanyJobSkillLogic(CompanyJobSkillRepo);
			return Logic.GetAll();
		}

		public List<CompanyLocationPoco> GetAllCompanyLocation()
		{
			EFGenericRepository<CompanyLocationPoco> CompanyLocationRepo = new EFGenericRepository<CompanyLocationPoco>(false);
			var Logic = new CompanyLocationLogic(CompanyLocationRepo);
			return Logic.GetAll();
		}

		public List<CompanyProfilePoco> GetAllCompanyProfile()
		{
			EFGenericRepository<CompanyProfilePoco> CompanyProfileRepo = new EFGenericRepository<CompanyProfilePoco>(false);
			var Logic = new CompanyProfileLogic(CompanyProfileRepo);
			return Logic.GetAll();
		}

		public CompanyDescriptionPoco GetSingleCompanyDescription(string Id)
		{
			EFGenericRepository<CompanyDescriptionPoco> CompanyDescriptionRepo = new EFGenericRepository<CompanyDescriptionPoco>(false);
			var Logic = new CompanyDescriptionLogic(CompanyDescriptionRepo);
			return Logic.Get(Guid.Parse(Id));
		}

		public CompanyJobPoco GetSingleCompanyJob(string Id)
		{
			EFGenericRepository<CompanyJobPoco> CompanyJobRepo = new EFGenericRepository<CompanyJobPoco>(false);
			var Logic = new CompanyJobLogic(CompanyJobRepo);
			return Logic.Get(Guid.Parse(Id));
		}

		public CompanyJobDescriptionPoco GetSingleCompanyJobDescription(string Id)
		{
			EFGenericRepository<CompanyJobDescriptionPoco> CompanyJobDescriptionRepo = new EFGenericRepository<CompanyJobDescriptionPoco>(false);
			var Logic = new CompanyJobDescriptionLogic(CompanyJobDescriptionRepo);
			return Logic.Get(Guid.Parse(Id));
		}

		public CompanyJobEducationPoco GetSingleCompanyJobEducation(string Id)
		{
			EFGenericRepository<CompanyJobEducationPoco> CompanyJobEducationRepo = new EFGenericRepository<CompanyJobEducationPoco>(false);
			var Logic = new CompanyJobEducationLogic(CompanyJobEducationRepo);
			return Logic.Get(Guid.Parse(Id));
		}

		public CompanyJobSkillPoco GetSingleCompanyJobSkill(string Id)
		{
			EFGenericRepository<CompanyJobSkillPoco> CompanyJobSkillRepo = new EFGenericRepository<CompanyJobSkillPoco>(false);
			var Logic = new CompanyJobSkillLogic(CompanyJobSkillRepo);
			return Logic.Get(Guid.Parse(Id));
		}

		public CompanyLocationPoco GetSingleCompanyLocation(string Id)
		{
			EFGenericRepository<CompanyLocationPoco> CompanyLocationRepo = new EFGenericRepository<CompanyLocationPoco>(false);
			var Logic = new CompanyLocationLogic(CompanyLocationRepo);
			return Logic.Get(Guid.Parse(Id));
		}

		public CompanyProfilePoco GetSingleCompanyProfile(string Id)
		{
			EFGenericRepository<CompanyProfilePoco> CompanyProfileRepo = new EFGenericRepository<CompanyProfilePoco>(false);
			var Logic = new CompanyProfileLogic(CompanyProfileRepo);
			return Logic.Get(Guid.Parse(Id));
		}

		public void RemoveCompanyDescription(CompanyDescriptionPoco[] items)
		{
			EFGenericRepository<CompanyDescriptionPoco> CompanyDescriptionRepo = new EFGenericRepository<CompanyDescriptionPoco>(false);
			var Logic = new CompanyDescriptionLogic(CompanyDescriptionRepo);
			Logic.Delete(items);
		}

		public void RemoveCompanyJob(CompanyJobPoco[] items)
		{
			EFGenericRepository<CompanyJobPoco> CompanyJobRepo = new EFGenericRepository<CompanyJobPoco>(false);
			var Logic = new CompanyJobLogic(CompanyJobRepo);
			Logic.Delete(items);
		}

		public void RemoveCompanyJobDescription(CompanyJobDescriptionPoco[] items)
		{
			EFGenericRepository<CompanyJobDescriptionPoco> CompanyJobDescriptionRepo = new EFGenericRepository<CompanyJobDescriptionPoco>(false);
			var Logic = new CompanyJobDescriptionLogic(CompanyJobDescriptionRepo);
			Logic.Delete(items);
		}

		public void RemoveCompanyJobEducation(CompanyJobEducationPoco[] items)
		{
			EFGenericRepository<CompanyJobEducationPoco> CompanyJobEducationRepo = new EFGenericRepository<CompanyJobEducationPoco>(false);
			var Logic = new CompanyJobEducationLogic(CompanyJobEducationRepo);
			Logic.Delete(items);
		}

		public void RemoveCompanyJobSkill(CompanyJobSkillPoco[] items)
		{
			EFGenericRepository<CompanyJobSkillPoco> CompanyJobSkillRepo = new EFGenericRepository<CompanyJobSkillPoco>(false);
			var Logic = new CompanyJobSkillLogic(CompanyJobSkillRepo);
			Logic.Delete(items);
		}

		public void RemoveCompanyLocation(CompanyLocationPoco[] items)
		{
			EFGenericRepository<CompanyLocationPoco> CompanyLocationRepo = new EFGenericRepository<CompanyLocationPoco>(false);
			var Logic = new CompanyLocationLogic(CompanyLocationRepo);
			Logic.Delete(items);
		}

		public void RemoveCompanyProfile(CompanyProfilePoco[] items)
		{
			EFGenericRepository<CompanyProfilePoco> CompanyProfileRepo = new EFGenericRepository<CompanyProfilePoco>(false);
			var Logic = new CompanyProfileLogic(CompanyProfileRepo);
			Logic.Delete(items);
		}

		public void UpdateCompanyDescription(CompanyDescriptionPoco[] items)
		{
			EFGenericRepository<CompanyDescriptionPoco> CompanyDescriptionRepo = new EFGenericRepository<CompanyDescriptionPoco>(false);
			var Logic = new CompanyDescriptionLogic(CompanyDescriptionRepo);
			Logic.Update(items);
		}

		public void UpdateCompanyJob(CompanyJobPoco[] items)
		{
			EFGenericRepository<CompanyJobPoco> CompanyJobRepo = new EFGenericRepository<CompanyJobPoco>(false);
			var Logic = new CompanyJobLogic(CompanyJobRepo);
			Logic.Update(items);
		}

		public void UpdateCompanyJobDescription(CompanyJobDescriptionPoco[] items)
		{
			EFGenericRepository<CompanyJobDescriptionPoco> CompanyJobDescriptionRepo = new EFGenericRepository<CompanyJobDescriptionPoco>(false);
			var Logic = new CompanyJobDescriptionLogic(CompanyJobDescriptionRepo);
			Logic.Update(items);
		}

		public void UpdateCompanyJobEducation(CompanyJobEducationPoco[] items)
		{
			EFGenericRepository<CompanyJobEducationPoco> CompanyJobEducationRepo = new EFGenericRepository<CompanyJobEducationPoco>(false);
			var Logic = new CompanyJobEducationLogic(CompanyJobEducationRepo);
			Logic.Update(items);
		}

		public void UpdateCompanyJobSkill(CompanyJobSkillPoco[] items)
		{
			EFGenericRepository<CompanyJobSkillPoco> CompanyJobSkillRepo = new EFGenericRepository<CompanyJobSkillPoco>(false);
			var Logic = new CompanyJobSkillLogic(CompanyJobSkillRepo);
			Logic.Update(items);
		}

		public void UpdateCompanyLocation(CompanyLocationPoco[] items)
		{
			EFGenericRepository<CompanyLocationPoco> CompanyLocationRepo = new EFGenericRepository<CompanyLocationPoco>(false);
			var Logic = new CompanyLocationLogic(CompanyLocationRepo);
			Logic.Update(items);
		}

		public void UpdateCompanyProfile(CompanyProfilePoco[] items)
		{
			EFGenericRepository<CompanyProfilePoco> CompanyProfileRepo = new EFGenericRepository<CompanyProfilePoco>(false);
			var Logic = new CompanyProfileLogic(CompanyProfileRepo);
			Logic.Update(items);
		}
	}
}
