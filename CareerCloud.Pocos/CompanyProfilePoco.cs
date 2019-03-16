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
	[Table("Company_Profiles")]
	public class CompanyProfilePoco : IPoco
	{
		[Key]
		[DataMember]
		public Guid Id { get; set; }

		[DataMember]
		[Column("Registration_Date")]
		public DateTime RegistrationDate { get; set; }

		[DataMember]
		[Column("Company_Website")]
		public string CompanyWebsite { get; set; }

		[DataMember]
		[Column("Contact_Phone")]
		public string ContactPhone { get; set; }

		[DataMember]
		[Column("Contact_Name")]
		public string ContactName{ get; set; }

		[DataMember]
		[Column("Company_Logo")]
		public byte[] CompanyLogo { get; set; }

		[DataMember]
		[Column("Time_Stamp")]
		public byte[] TimeStamp { get; set; }

		public virtual ICollection<CompanyDescriptionPoco> CompanyDescription { get; set; }

		public virtual ICollection<CompanyJobPoco> CompanyJob { get; set; }

		public virtual ICollection<CompanyLocationPoco> CompanyLocation { get; set; }
	}
}
