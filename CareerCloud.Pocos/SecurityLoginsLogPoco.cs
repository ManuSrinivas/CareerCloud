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
	[Table("Security_Logins_Log")]
	public class SecurityLoginsLogPoco : IPoco 
	{
		[Key]
		[DataMember]
		public Guid Id { get; set; }

		[DataMember]
		public Guid Login { get; set; }

		[DataMember]
		[Column("Source_IP")]
		public string SourceIP { get; set; }

		[DataMember]
		[DataType(DataType.Date)]
		[Column("Logon_Date")]
		public DateTime LogonDate { get; set; }

		[DataMember]
		[Column("Is_Succesful")]
		public bool IsSuccesful { get; set; }

		public virtual SecurityLoginPoco SecurityLogin { get; set; }
	}
}
