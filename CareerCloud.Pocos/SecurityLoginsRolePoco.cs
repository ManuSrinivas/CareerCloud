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
	[Table("Security_Logins_Roles")]
	public class SecurityLoginsRolePoco : IPoco
	{
		[Key]
		[DataMember]
		public Guid Id { get; set; }

		[DataMember]
		public Guid Login { get; set; }

		[DataMember]
		public Guid Role { get; set; }

		[DataMember]
		[Column("Time_Stamp")]
		public byte[] TimeStamp { get; set; }

		public virtual SecurityLoginPoco SecurityLogin { get; set; }

		public virtual SecurityRolePoco SecurityRole { get; set; }
	}
}
