using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CareerCloud.BusinessLogicLayer;
using CareerCloud.EntityFrameworkDataAccess;
using CareerCloud.Pocos;

namespace CareerCloud.WCF
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
	public class Applicant : IApplicant
	{
		public void AddApplicantEducation(ApplicantEducationPoco[] items)
		{
			EFGenericRepository<ApplicantEducationPoco> ApplicantEducationRepo = new EFGenericRepository<ApplicantEducationPoco>(false);
			var Logic = new ApplicantEducationLogic(ApplicantEducationRepo);
			Logic.Add(items);
		}

		public void AddApplicantJobApplication(ApplicantJobApplicationPoco[] items)
		{
			EFGenericRepository<ApplicantJobApplicationPoco> ApplicantJobApplicationRepo = new EFGenericRepository<ApplicantJobApplicationPoco>(false);
			var Logic = new ApplicantJobApplicationLogic(ApplicantJobApplicationRepo);
			Logic.Add(items);
		}

		public void AddApplicantProfile(ApplicantProfilePoco[] items)
		{
			EFGenericRepository<ApplicantProfilePoco> ApplicantProfileRepo = new EFGenericRepository<ApplicantProfilePoco>(false);
			var Logic = new ApplicantProfileLogic(ApplicantProfileRepo);
			Logic.Add(items);
		}

		public void AddApplicantResume(ApplicantResumePoco[] items)
		{
			EFGenericRepository<ApplicantResumePoco> ApplicantResumeRepo = new EFGenericRepository<ApplicantResumePoco>(false);
			var Logic = new ApplicantResumeLogic(ApplicantResumeRepo);
			Logic.Add(items);
		}

		public void AddApplicantSkill(ApplicantSkillPoco[] items)
		{
			EFGenericRepository<ApplicantSkillPoco> ApplicantSkillRepo = new EFGenericRepository<ApplicantSkillPoco>(false);
			var Logic = new ApplicantSkillLogic(ApplicantSkillRepo);
			Logic.Add(items);
		}

		public void AddApplicantWorkHistory(ApplicantWorkHistoryPoco[] items)
		{
			EFGenericRepository<ApplicantWorkHistoryPoco> ApplicantWorkHistoryRepo = new EFGenericRepository<ApplicantWorkHistoryPoco>(false);
			var Logic = new ApplicantWorkHistoryLogic(ApplicantWorkHistoryRepo);
			Logic.Add(items);
		}

		public List<ApplicantEducationPoco> GetAllApplicantEducation()
		{
			EFGenericRepository<ApplicantEducationPoco> ApplicantEducationRepo = new EFGenericRepository<ApplicantEducationPoco>(false);
			var Logic = new ApplicantEducationLogic(ApplicantEducationRepo);
			return Logic.GetAll();
		}

		public List<ApplicantJobApplicationPoco> GetAllApplicantJobApplication()
		{
			EFGenericRepository<ApplicantJobApplicationPoco> ApplicantJobApplicationRepo = new EFGenericRepository<ApplicantJobApplicationPoco>(false);
			var Logic = new ApplicantJobApplicationLogic(ApplicantJobApplicationRepo);
			return Logic.GetAll();
		}

		public List<ApplicantProfilePoco> GetAllApplicantProfile()
		{
			EFGenericRepository<ApplicantProfilePoco> ApplicantProfileRepo = new EFGenericRepository<ApplicantProfilePoco>(false);
			var Logic = new ApplicantProfileLogic(ApplicantProfileRepo);
			return Logic.GetAll();
		}

		public List<ApplicantResumePoco> GetAllApplicantResume()
		{
			EFGenericRepository<ApplicantResumePoco> ApplicantResumeRepo = new EFGenericRepository<ApplicantResumePoco>(false);
			var Logic = new ApplicantResumeLogic(ApplicantResumeRepo);
			return Logic.GetAll();
		}

		public List<ApplicantSkillPoco> GetAllApplicantSkill()
		{
			EFGenericRepository<ApplicantSkillPoco> ApplicantSkillRepo = new EFGenericRepository<ApplicantSkillPoco>(false);
			var Logic = new ApplicantSkillLogic(ApplicantSkillRepo);
			return Logic.GetAll();
		}

		public List<ApplicantWorkHistoryPoco> GetAllApplicantWorkHistory()
		{
			EFGenericRepository<ApplicantWorkHistoryPoco> ApplicantWorkHistoryRepo = new EFGenericRepository<ApplicantWorkHistoryPoco>(false);
			var Logic = new ApplicantWorkHistoryLogic(ApplicantWorkHistoryRepo);
			return Logic.GetAll();
		}

		public ApplicantEducationPoco GetSingleApplicantEducation(string Id)
		{
			EFGenericRepository<ApplicantEducationPoco> ApplicantEducationRepo = new EFGenericRepository<ApplicantEducationPoco>(false);
			var Logic = new ApplicantEducationLogic(ApplicantEducationRepo);
			return Logic.Get(Guid.Parse(Id));
		}

		public ApplicantJobApplicationPoco GetSingleApplicantJobApplication(string Id)
		{
			EFGenericRepository<ApplicantJobApplicationPoco> ApplicantJobApplicationRepo = new EFGenericRepository<ApplicantJobApplicationPoco>(false);
			var Logic = new ApplicantJobApplicationLogic(ApplicantJobApplicationRepo);
			return Logic.Get(Guid.Parse(Id));
		}

		public ApplicantProfilePoco GetSingleApplicantProfile(string Id)
		{
			EFGenericRepository<ApplicantProfilePoco> ApplicantProfileRepo = new EFGenericRepository<ApplicantProfilePoco>(false);
			var Logic = new ApplicantProfileLogic(ApplicantProfileRepo);
			return Logic.Get(Guid.Parse(Id));
		}

		public ApplicantResumePoco GetSingleApplicantResume(string Id)
		{
			EFGenericRepository<ApplicantResumePoco> ApplicantResumeRepo = new EFGenericRepository<ApplicantResumePoco>(false);
			var Logic = new ApplicantResumeLogic(ApplicantResumeRepo);
			return Logic.Get(Guid.Parse(Id));
		}

		public ApplicantSkillPoco GetSingleApplicantSkill(string Id)
		{
			EFGenericRepository<ApplicantSkillPoco> ApplicantSkillRepo = new EFGenericRepository<ApplicantSkillPoco>(false);
			var Logic = new ApplicantSkillLogic(ApplicantSkillRepo);
			return Logic.Get(Guid.Parse(Id));
		}

		public ApplicantWorkHistoryPoco GetSingleApplicantWorkHistory(string Id)
		{
			EFGenericRepository<ApplicantWorkHistoryPoco> ApplicantWorkHistoryRepo = new EFGenericRepository<ApplicantWorkHistoryPoco>(false);
			var Logic = new ApplicantWorkHistoryLogic(ApplicantWorkHistoryRepo);
			return Logic.Get(Guid.Parse(Id));
		}

		public void RemoveApplicantEducation(ApplicantEducationPoco[] items)
		{
			EFGenericRepository<ApplicantEducationPoco> ApplicantEducationRepo = new EFGenericRepository<ApplicantEducationPoco>(false);
			var Logic = new ApplicantEducationLogic(ApplicantEducationRepo);
			Logic.Delete(items);
		}

		public void RemoveApplicantJobApplication(ApplicantJobApplicationPoco[] items)
		{
			EFGenericRepository<ApplicantJobApplicationPoco> ApplicantJobApplicationRepo = new EFGenericRepository<ApplicantJobApplicationPoco>(false);
			var Logic = new ApplicantJobApplicationLogic(ApplicantJobApplicationRepo);
			Logic.Delete(items);
		}

		public void RemoveApplicantProfile(ApplicantProfilePoco[] items)
		{
			EFGenericRepository<ApplicantProfilePoco> ApplicantProfileRepo = new EFGenericRepository<ApplicantProfilePoco>(false);
			var Logic = new ApplicantProfileLogic(ApplicantProfileRepo);
			Logic.Delete(items);
		}

		public void RemoveApplicantResume(ApplicantResumePoco[] items)
		{
			EFGenericRepository<ApplicantResumePoco> ApplicantResumeRepo = new EFGenericRepository<ApplicantResumePoco>(false);
			var Logic = new ApplicantResumeLogic(ApplicantResumeRepo);
			Logic.Delete(items);
		}

		public void RemoveApplicantSkill(ApplicantSkillPoco[] items)
		{
			EFGenericRepository<ApplicantSkillPoco> ApplicantSkillRepo = new EFGenericRepository<ApplicantSkillPoco>(false);
			var Logic = new ApplicantSkillLogic(ApplicantSkillRepo);
			Logic.Delete(items);
		}

		public void RemoveApplicantWorkHistory(ApplicantWorkHistoryPoco[] items)
		{
			EFGenericRepository<ApplicantWorkHistoryPoco> ApplicantWorkHistoryRepo = new EFGenericRepository<ApplicantWorkHistoryPoco>(false);
			var Logic = new ApplicantWorkHistoryLogic(ApplicantWorkHistoryRepo);
			Logic.Delete(items);
		}

		public void UpdateApplicantEducation(ApplicantEducationPoco[] items)
		{
			EFGenericRepository<ApplicantEducationPoco> ApplicantEducationRepo = new EFGenericRepository<ApplicantEducationPoco>(false);
			var Logic = new ApplicantEducationLogic(ApplicantEducationRepo);
			Logic.Update(items);
		}

		public void UpdateApplicantJobApplication(ApplicantJobApplicationPoco[] items)
		{
			EFGenericRepository<ApplicantJobApplicationPoco> ApplicantJobApplicationRepo = new EFGenericRepository<ApplicantJobApplicationPoco>(false);
			var Logic = new ApplicantJobApplicationLogic(ApplicantJobApplicationRepo);
			Logic.Update(items);
		}

		public void UpdateApplicantProfile(ApplicantProfilePoco[] items)
		{
			EFGenericRepository<ApplicantProfilePoco> ApplicantProfileRepo = new EFGenericRepository<ApplicantProfilePoco>(false);
			var Logic = new ApplicantProfileLogic(ApplicantProfileRepo);
			Logic.Update(items);
		}

		public void UpdateApplicantResume(ApplicantResumePoco[] items)
		{
			EFGenericRepository<ApplicantResumePoco> ApplicantResumeRepo = new EFGenericRepository<ApplicantResumePoco>(false);
			var Logic = new ApplicantResumeLogic(ApplicantResumeRepo);
			Logic.Update(items);
		}

		public void UpdateApplicantSkill(ApplicantSkillPoco[] items)
		{
			EFGenericRepository<ApplicantSkillPoco> ApplicantSkillRepo = new EFGenericRepository<ApplicantSkillPoco>(false);
			var Logic = new ApplicantSkillLogic(ApplicantSkillRepo);
			Logic.Update(items);
		}

		public void UpdateApplicantWorkHistory(ApplicantWorkHistoryPoco[] items)
		{
			EFGenericRepository<ApplicantWorkHistoryPoco> ApplicantWorkHistoryRepo = new EFGenericRepository<ApplicantWorkHistoryPoco>(false);
			var Logic = new ApplicantWorkHistoryLogic(ApplicantWorkHistoryRepo);
			Logic.Update(items);
		}
	}
}
