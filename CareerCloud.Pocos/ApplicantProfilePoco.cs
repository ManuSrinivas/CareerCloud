﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CareerCloud.Pocos
{
	[DataContract]
	[Table("Applicant_Profiles")]
	public class ApplicantProfilePoco : IPoco
	{
		[Key]
		[DataMember]
		public Guid Id { get; set; }

		[DataMember]
		public Guid Login { get; set; }

		[DataMember]
		[Column("Current_Salary")]
		public Decimal? CurrentSalary { get; set; }

		[DataMember]
		[Column("Current_Rate")]
		public Decimal? CurrentRate { get; set; }

		[DataMember]
		public string Currency { get; set; }

		[DataMember]
		[Column("Country_Code")]
		public string Country { get; set; }

		[DataMember]
		[Column("State_Province_Code")]
		public string Province { get; set; }

		[DataMember]
		[Column("Street_Address")]
		public String Street { get; set; }

		[DataMember]
		[Column("City_Town")]
		public string City { get; set; }

		[DataMember]
		[Column("Zip_Postal_Code")]
		public String PostalCode { get; set; }

		[DataMember]
		[Column("Time_Stamp")]
		public byte[] TimeStamp { get; set; }

		public virtual ICollection<ApplicantEducationPoco> ApplicantEducation { get; set; }

		public virtual SecurityLoginPoco SecurityLogin { get; set; }

		public virtual SystemCountryCodePoco SystemCountryCode { get; set; }

		public virtual ICollection<ApplicantJobApplicationPoco> ApplicantJobApplication { get; set; }

		public virtual ICollection<ApplicantResumePoco> ApplicantResume { get; set; }

		public virtual ICollection<ApplicantSkillPoco> ApplicantSkill { get; set; }

		public virtual ICollection<ApplicantWorkHistoryPoco> ApplicantWorkHistory { get; set; }

	}
}
