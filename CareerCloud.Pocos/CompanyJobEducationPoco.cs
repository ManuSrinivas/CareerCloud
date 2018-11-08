using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CareerCloud.Pocos
{
	[Table("Company_Job_Educations")]
	class CompanyJobEducationPoco : IPoco
	{
		[Key]
		public Guid Id { get; set; }

		public Guid Job { get; set; }

		public string Major { get; set; }

		public short Importance { get; set; }

		[Column("Time_Stamp")]
		public byte[] TimeStamp { get; set; }
	}
}
