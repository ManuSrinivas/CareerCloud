using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CareerCloud.Pocos
{
	[DataContract]
	[Table("Company_Jobs")]
	public class CompanyJobPoco : IPoco
	{
		[Key]
		[DataMember]
		public Guid Id { get; set; }

		[DataMember]
		public Guid Company { get; set; }

		[DataMember]
		[DataType(DataType.Date)]
		[Column("Profile_Created")]
		public DateTime ProfileCreated { get; set; }

		[DataMember]
		[Column("Is_Inactive")]
		public bool IsInactive { get; set; }

		[DataMember]
		[Column("Is_Company_Hidden")]
		public bool IsCompanyHidden { get; set; }

		[DataMember]
		[Column("Time_Stamp")]
		public byte[] TimeStamp { get; set; }

		public virtual ICollection<ApplicantJobApplicationPoco> ApplicantJobApplication { get; set; }

		public virtual ICollection<CompanyJobEducationPoco> CompanyJobEducation { get; set; }

		public virtual ICollection<CompanyJobSkillPoco> CompanyJobSkill { get; set; }

		public virtual CompanyProfilePoco CompanyProfile { get; set; }

		public virtual ICollection<CompanyJobDescriptionPoco> CompanyJobDescription { get; set; }
	}
}
