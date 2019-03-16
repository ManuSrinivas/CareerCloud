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
	[Table("Company_Job_Skills")]
	public class CompanyJobSkillPoco : IPoco
	{
		[Key]
		[DataMember]
		public Guid Id { get; set; }

		[DataMember]
		public Guid Job { get; set; }

		[DataMember]
		public string Skill { get; set; }

		[DataMember]
		[Column("Skill_Level")]
		public string SkillLevel { get; set; }

		[DataMember]
		public int Importance { get; set; }

		[DataMember]
		[Column("Time_Stamp")]
		public byte[] TimeStamp { get; set; }

		public virtual CompanyJobPoco CompanyJob { get; set; }
	}
}
