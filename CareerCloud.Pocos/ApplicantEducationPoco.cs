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
	[Table("Applicant_Educations")]
	public class ApplicantEducationPoco : IPoco
	{
		[Key]
		[DataMember]
		public Guid Id { get; set; }

		[DataMember]
		public Guid Applicant { get; set; }

		[DataMember]
		public string Major { get; set; }

		[DataMember]
		[Column("Certificate_Diploma")]
		public string CertificateDiploma { get; set; }

		[DataMember]
		[Column("Start_Date")]
		public DateTime? StartDate { get; set; }

		[DataMember]
		[Column("Completion_Date")]
		public DateTime? CompletionDate { get; set; }

		[DataMember]
		[Column("Completion_Percent")]
		public byte? CompletionPercent { get; set; }

		[DataMember]
		[Column("Time_Stamp")]
		public byte[] TimeStamp { get; set; }

		public virtual ApplicantProfilePoco ApplicantProfile { get; set; }
	}
}
