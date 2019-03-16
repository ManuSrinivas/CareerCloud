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
	[Table("System_Country_Codes")]
	public class SystemCountryCodePoco
	{
		[Key]
		[DataMember]
		public string Code { get; set; }

		[DataMember]
		public string Name { get; set; }

		public virtual ICollection<ApplicantProfilePoco> ApplicantProfile { get; set; }

		public virtual ICollection<ApplicantWorkHistoryPoco> ApplicantWorkHistory { get; set; }
	}
}
