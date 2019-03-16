using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.Pocos;

namespace CareerCloud.EntityFrameworkDataAccess
{
	class CareerCloudContext : DbContext
	{
		public CareerCloudContext(bool createProxy = true) : base(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString)//@"Data Source=LAPTOP-542KT1B3\HUMBERBRIDGING;Initial Catalog=JOB_PORTAL_DB;Integrated Security=True")//ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString)
		{
			Configuration.ProxyCreationEnabled = createProxy;
		}

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ApplicantProfilePoco>()
				.HasMany( (ApplicantProfilePoco a) => a.ApplicantEducation)
				.WithRequired( (ApplicantEducationPoco e) => e.ApplicantProfile)
				.HasForeignKey( (ApplicantEducationPoco e) => e.Applicant);

			modelBuilder.Entity<ApplicantProfilePoco>()
				.HasMany(a => a.ApplicantJobApplication)
				.WithRequired(e => e.ApplicantProfile)
				.HasForeignKey(e => e.Applicant);

			modelBuilder.Entity<ApplicantProfilePoco>()
				.HasMany(a => a.ApplicantResume)
				.WithRequired(e => e.ApplicantProfile)
				.HasForeignKey(e => e.Applicant);

			modelBuilder.Entity<ApplicantProfilePoco>()
				.HasMany(a => a.ApplicantSkill)
				.WithRequired(e => e.ApplicantProfile)
				.HasForeignKey(e => e.Applicant);

			modelBuilder.Entity<ApplicantProfilePoco>()
				.HasMany(a => a.ApplicantWorkHistory)
				.WithRequired(e => e.ApplicantProfile)
				.HasForeignKey(e => e.Applicant);

			modelBuilder.Entity<CompanyJobPoco>()
				.HasMany(a => a.ApplicantJobApplication)
				.WithRequired(e => e.CompanyJob)
				.HasForeignKey(e => e.Job);

			modelBuilder.Entity<CompanyJobPoco>()
				.HasMany(a => a.CompanyJobDescription)
				.WithRequired(e => e.CompanyJob)
				.HasForeignKey(e => e.Job);

			modelBuilder.Entity<CompanyJobPoco>()
				.HasMany(a => a.CompanyJobEducation)
				.WithRequired(e => e.CompanyJob)
				.HasForeignKey(e => e.Job);

			modelBuilder.Entity<CompanyJobPoco>()
				.HasMany(a => a.CompanyJobSkill)
				.WithRequired(e => e.CompanyJob)
				.HasForeignKey(e => e.Job);

			modelBuilder.Entity<CompanyProfilePoco>()
				.HasMany(a => a.CompanyDescription)
				.WithRequired(e => e.CompanyProfile)
				.HasForeignKey(e => e.Company);

			modelBuilder.Entity<CompanyProfilePoco>()
				.HasMany(a => a.CompanyJob)
				.WithRequired(e => e.CompanyProfile)
				.HasForeignKey(e => e.Company);

			modelBuilder.Entity<CompanyProfilePoco>()
				.HasMany(a => a.CompanyLocation)
				.WithRequired(e => e.CompanyProfile)
				.HasForeignKey(e => e.Company);

			modelBuilder.Entity<SecurityLoginPoco>()
				.HasMany(a => a.SecurityLoginsLog)
				.WithRequired(e => e.SecurityLogin)
				.HasForeignKey(e => e.Login);

			modelBuilder.Entity<SecurityLoginPoco>()
				.HasMany(a => a.SecurityLoginsRole)
				.WithRequired(e => e.SecurityLogin)
				.HasForeignKey(e => e.Login);

			modelBuilder.Entity<SecurityLoginPoco>()
				.HasMany(a => a.ApplicantProfile)
				.WithRequired(e => e.SecurityLogin)
				.HasForeignKey(e => e.Login);

			modelBuilder.Entity<SecurityRolePoco>()
				.HasMany(a => a.SecurityLoginsRole)
				.WithRequired(e => e.SecurityRole)
				.HasForeignKey(e => e.Role);

			modelBuilder.Entity<SystemCountryCodePoco>()
				.HasMany(a => a.ApplicantProfile)
				.WithRequired(e => e.SystemCountryCode)
				.HasForeignKey(e => e.Country);

			modelBuilder.Entity<SystemCountryCodePoco>()
				.HasMany(a => a.ApplicantWorkHistory)
				.WithRequired(e => e.SystemCountryCode)
				.HasForeignKey(e => e.CountryCode);

			modelBuilder.Entity<SystemLanguageCodePoco>()
				.HasMany(a => a.CompanyDescription)
				.WithRequired(e => e.SystemLanguageCode)
				.HasForeignKey(e => e.LanguageId);

			modelBuilder.Entity<ApplicantEducationPoco>()
				.Ignore(a => a.TimeStamp);

			modelBuilder.Entity<ApplicantJobApplicationPoco>()
				.Ignore(a => a.TimeStamp);

			modelBuilder.Entity<ApplicantProfilePoco>()
				.Ignore(a => a.TimeStamp);

			modelBuilder.Entity<ApplicantSkillPoco>()
				.Ignore(a => a.TimeStamp);

			modelBuilder.Entity<ApplicantWorkHistoryPoco>()
				.Ignore(a => a.TimeStamp);

			modelBuilder.Entity<CompanyDescriptionPoco>()
				.Ignore(a => a.TimeStamp);

			modelBuilder.Entity<CompanyJobDescriptionPoco>()
				.Ignore(a => a.TimeStamp);

			modelBuilder.Entity<CompanyJobEducationPoco>()
				.Ignore(a => a.TimeStamp);

			modelBuilder.Entity<CompanyJobPoco>()
				.Ignore(a => a.TimeStamp);

			modelBuilder.Entity<CompanyJobSkillPoco>()
				.Ignore(a => a.TimeStamp);

			modelBuilder.Entity<CompanyLocationPoco>()
				.Ignore(a => a.TimeStamp);

			modelBuilder.Entity<CompanyProfilePoco>()
				.Ignore(a => a.TimeStamp);

			modelBuilder.Entity<SecurityLoginPoco>()
				.Ignore(a => a.TimeStamp);

			modelBuilder.Entity<SecurityLoginsRolePoco>()
				.Ignore(a => a.TimeStamp);

			base.OnModelCreating(modelBuilder);
		}

		public DbSet<ApplicantEducationPoco> ApplicantEducations { get; set; }
		public DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
		public DbSet<ApplicantProfilePoco> ApplicantProfiles { get; set; }
		public DbSet<ApplicantResumePoco> ApplicantResumes { get; set; }
		public DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
		public DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistories { get; set; }
		public DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
		public DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
		public DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
		public DbSet<CompanyJobPoco> CompanyJobs { get; set; }
		public DbSet<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
		public DbSet<CompanyLocationPoco> CompanyLocations { get; set; }
		public DbSet<SecurityLoginPoco> SecurityLogins { get; set; }
		public DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
		public DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
		public DbSet<SecurityRolePoco> SecurityRoles { get; set; }
		public DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }
		public DbSet<SystemLanguageCodePoco> SystemLanguageCodes { get; set; }
	}
}
