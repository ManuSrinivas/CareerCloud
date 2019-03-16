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
	[Table("Company_Job_Educations")]
	public class CompanyJobEducationPoco : IPoco
	{
		[DataMember]
		[Key]
		public Guid Id { get; set; }

		[DataMember]
		public Guid Job { get; set; }

		[DataMember]
		public string Major { get; set; }

		[DataMember]
		public short Importance { get; set; }

		[DataMember]
		[Column("Time_Stamp")]
		public byte[] TimeStamp { get; set; }

		public virtual CompanyJobPoco CompanyJob { get; set; }
	}
}
